Option Explicit On 

Imports CrystalDecisions.CrystalReports.Engine

Namespace Buisness.TracFone
    Public Class Warehouse

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

#Region "Fill Open Order"

        '******************************************************************
        Public Function GetTFOpenOrder(Optional ByVal iCust_ID As Integer = 0) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT D.WO_ID, D.WO_CustWO, A.PODate, A.OrderQty, A.Order_ID, B.VN_ItemNo, B.LineItemDetail " & Environment.NewLine
                strSql &= ", B.Model_ID, E.Name, E.Address1, E.City, E.State, E.Zip, E.IDCode " & Environment.NewLine
                strSql &= "FROM edi.torder A " & Environment.NewLine
                strSql &= "INNER JOIN edi.torderdetail B ON A.Order_ID = B.Order_ID " & Environment.NewLine
                If iCust_ID = PSS.Data.Buisness.WFM.CUSTOMER_ID Then
                    strSql &= "INNER JOIN production.tcustmodel_pssmodel_map C ON B.Model_ID = C.Model_ID AND Cust_ID = " & iCust_ID & Environment.NewLine
                Else
                    strSql &= "INNER JOIN production.tcustmodel_pssmodel_map C ON B.Model_ID = C.Model_ID AND Cust_ID = 2258 " & Environment.NewLine
                End If
                strSql &= "INNER JOIN production.tworkorder D ON A.PSS_WO_ID = D.WO_ID " & Environment.NewLine
                strSql &= "INNER JOIN edi.taddress E ON A.Order_ID = E.Order_ID AND E.EntityIdentifiercode = 'ST' " & Environment.NewLine
                strSql &= "WHERE A.Order_Type = 'OUT' " & Environment.NewLine
                strSql &= "AND D.WO_Closed = 0 " & Environment.NewLine
                strSql &= "AND A.OrderCancel = 0 " & Environment.NewLine
                strSql &= "ORDER BY WO_CustWO " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetTFAvailableBox(Optional ByVal iModelID As Integer = 0) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT Distinct Pallett_Name as 'Box', Model_Desc as 'Model', Pallett_Qty as 'Qty' " & Environment.NewLine
                strSql &= ", IF(Pallet_ShipType = 0, 'REFURBISHED', IF(Pallet_ShipType = 1, 'BER', IF(Pallet_ShipType = 10, 'Return to BrightStart', IF(Pallet_ShipType = 11, 'Return to Cooper', IF(Pallet_ShipType = 12, 'Forward to Repair', ''))))) AS 'Box Type' " & Environment.NewLine
                strSql &= "FROM production.tpallett A " & Environment.NewLine
                strSql &= "INNER JOIN production.tmodel B ON A.Model_ID = B.Model_ID " & Environment.NewLine
                strSql &= "WHERE cust_ID = 2258 AND A.pkslip_ID is null " & Environment.NewLine
                strSql &= "AND Pallet_ShipType <> 1 " & Environment.NewLine
                If iModelID > 0 Then strSql &= "AND A.Model_ID = " & iModelID & Environment.NewLine
                strSql &= "AND A.Pallet_Invalid  = 0 " & Environment.NewLine
                strSql &= "AND A.Pallett_ShipDate is not null AND Pallett_BulkShipped = 1 " & Environment.NewLine
                strSql &= "AND A.WO_ID = 0 " & Environment.NewLine
                'strSql &= "GROUP BY  A.Pallett_ID " & Environment.NewLine
                strSql &= " ORDER BY 'Box Type' desc,Model,Box;"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetWFMAvailableBox(Optional ByVal iModelID As Integer = 0, Optional ByVal bOnlyWHNTFBoxesAndAccessary As Boolean = False) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT Distinct Pallett_Name as 'Box', Model_Desc as 'Model', Pallett_Qty as 'Qty', 'Accessary' AS 'Box Type'" & Environment.NewLine
                strSql &= " FROM production.tpallett A" & Environment.NewLine
                strSql &= " INNER JOIN production.tmodel B ON A.Model_ID = B.Model_ID" & Environment.NewLine
                strSql &= " WHERE cust_ID = " & PSS.Data.Buisness.WFM.CUSTOMER_ID & " AND A.pkslip_ID is null" & Environment.NewLine
                strSql &= " AND Pallet_ShipType <> 1" & Environment.NewLine
                strSql &= " AND A.Pallet_Invalid  = 0" & Environment.NewLine
                strSql &= " AND A.Pallett_ShipDate is not null AND Pallett_BulkShipped = 1" & Environment.NewLine
                strSql &= " AND A.WO_ID = 0" & Environment.NewLine
                strSql &= " UNION ALL" & Environment.NewLine
                strSql &= " SELECT Distinct A.Pallett_Name as 'Box', B.Model_Desc as 'Model', A.Pallett_Qty as 'Qty',C.Disp_CD AS 'Box Type'" & Environment.NewLine
                strSql &= " FROM production.tpallett A" & Environment.NewLine
                strSql &= " INNER JOIN production.tmodel B ON A.Model_ID = B.Model_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tdispositions C ON A.Disp_ID=C.Disp_ID" & Environment.NewLine
                strSql &= " WHERE cust_ID = " & PSS.Data.Buisness.WFM.CUSTOMER_ID & " AND A.pkslip_ID is null" & Environment.NewLine
                strSql &= " AND A.disp_ID=5" & Environment.NewLine
                strSql &= " AND A.Pallet_Invalid  = 0" & Environment.NewLine
                strSql &= " AND A.Pallett_ShipDate is not null" & Environment.NewLine
                strSql &= " AND A.WO_ID = 0"
                If bOnlyWHNTFBoxesAndAccessary Then strSql &= " AND LENGTH(TRIM(A.WHLocation))>0"
                strSql &= " ORDER BY 'Box Type',Model,Box" & Environment.NewLine
                strSql &= ";" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '******************************************************************
        Public Function GetBoxTemplate() As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT Pallett_ID, Pallett_Name, Pallett_Qty, Pallet_Weight, 0 as Manuf_ID " & Environment.NewLine
                strSql &= "FROM production.tpallett " & Environment.NewLine
                strSql &= "Limit 0" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetShipCarriersWithACACCode(ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Try
                strSql = "select SC_ID, SC_Desc from lshipcarrier where SC_Active = 1 AND SCAC_Code is not null order by SC_Desc"
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow = True Then dt.LoadDataRow(New Object() {"0", "-- Select --"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function PrintBoxReadyToBeFilled(ByVal strOrderNo As String, _
                                                ByVal strItemNo As String, _
                                                ByVal strItemDesc As String, _
                                                ByVal iOrderQty As Integer, _
                                                ByVal iModelID As Integer) As Integer
            Const strReportName As String = "TF Ready To Be Fill Boxes.rpt"
            Dim dt As DataTable
            Dim objRpt As ReportDocument
            Dim strSql As String = ""

            Try
                strSql = "SELECT '" & strOrderNo & "' as OrderNo " & Environment.NewLine
                strSql &= ", '" & strItemNo & "' as ItemNo " & Environment.NewLine
                strSql &= ", '" & strItemDesc & "' as ItemDesc " & Environment.NewLine
                strSql &= ", " & iOrderQty & " as OrderQty " & Environment.NewLine
                strSql &= ", A.Pallett_Name as BoxID " & Environment.NewLine
                strSql &= ", A.Pallett_QTY as BoxQty " & Environment.NewLine
                strSql &= ", B.cust_OutgoingDesc as BoxItemNo " & Environment.NewLine
                strSql &= ", B.cust_OutgoingSku  as BoxItemDesc " & Environment.NewLine
                strSql &= "FROM production.tpallett A " & Environment.NewLine
                strSql &= "INNER JOIN production.tcustmodel_pssmodel_map B ON A.Model_ID = B.Model_ID AND A.Cust_ID = B.Cust_ID" & Environment.NewLine
                strSql &= "WHERE A.cust_id = " & TracFone.BuildShipPallet.TracFone_CUSTOMER_ID & Environment.NewLine
                strSql &= "AND Pallett_ShipDate is not null " & Environment.NewLine
                strSql &= "AND pkslip_ID is null " & Environment.NewLine
                strSql &= "AND Pallet_Invalid  = 0 " & Environment.NewLine
                strSql &= "AND A.WO_ID = 0 " & Environment.NewLine
                strSql &= "AND A.Model_ID = " & iModelID & Environment.NewLine
                strSql &= "Order By A.Pallett_ShipDate, A.Pallett_QTY " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If Not IsNothing(dt) Then
                    objRpt = New ReportDocument()

                    With objRpt
                        .Load(PSS.Data.ConfigFile.GetBaseReportPath & strReportName)
                        .SetDataSource(dt)
                        .PrintToPrinter(1, True, 0, 0)
                    End With
                End If
            Catch ex As Exception
                Throw ex
            Finally
                objRpt = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetPalletsInfo(ByVal strBoxIDs As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT * " & Environment.NewLine
                strSql &= "FROM production.tpallett " & Environment.NewLine
                strSql &= "WHERE Pallett_ID in (" & strBoxIDs & ");" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function FillSaleOrder(ByVal dtBoxIDs As DataTable, _
                                      ByVal iWO_ID As Integer, _
                                      ByVal iUseID As Integer, _
                                      Optional ByVal iCust_ID As Integer = 0) As Integer
            Dim strSql As String = ""
            Dim i, j, iTotalBoxInOrder As Integer
            Dim R1 As DataRow

            Try
                i = 0 : j = 0 : iTotalBoxInOrder = 0
                For Each R1 In dtBoxIDs.Rows
                    j += 1
                    strSql = "UPDATE tpallett " & Environment.NewLine
                    strSql &= "SET WO_ID = " & iWO_ID & Environment.NewLine
                    strSql &= ", Pallet_Weight = " & R1("Pallet_Weight") & Environment.NewLine
                    strSql &= ", UnitMeasurementCode  = 'BL'" & Environment.NewLine
                    strSql &= ", Order_SeqNo  = " & j & Environment.NewLine
                    strSql &= "WHERE tpallett.Pallett_ID = " & R1("Pallett_ID") & " " & Environment.NewLine
                    strSql &= "AND tpallett.WO_ID = 0;" & Environment.NewLine
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                Next R1

                strSql = "UPDATE production.tworkorder, edi.torder " & Environment.NewLine
                strSql &= "SET WO_Closed = 1 " & Environment.NewLine
                strSql &= ", WO_RAQnty = WO_Quantity " & Environment.NewLine
                strSql &= ", WO_ClosedDate = now() " & Environment.NewLine
                strSql &= ", WO_ClosedUsrID = " & iUseID & Environment.NewLine
                strSql &= "WHERE production.tworkorder.WO_ID = edi.torder.PSS_WO_ID AND WO_ID = " & iWO_ID & Environment.NewLine
                strSql &= "AND WO_Closed = 0;"
                i += Me._objDataProc.ExecuteNonQuery(strSql)

                '*****************************
                'Print 4 x 4 lalel
                '*****************************
                iTotalBoxInOrder = Me.GetMaxBoxNoInOrder(iWO_ID)

                If iCust_ID = PSS.Data.Buisness.WFM.CUSTOMER_ID Then
                    For Each R1 In dtBoxIDs.Rows
                        If R1("Manuf_ID") <> 220 Then '220=WFM accessary
                            Me.Print2DBarcodeBoxLabel(R1("Pallett_ID"), iTotalBoxInOrder, , iCust_ID)
                        End If
                    Next R1
                Else
                    For Each R1 In dtBoxIDs.Rows
                        If R1("Manuf_ID") <> 53 Then '53=TF Accessary
                            Me.Print2DBarcodeBoxLabel(R1("Pallett_ID"), iTotalBoxInOrder, , iCust_ID)
                        End If
                    Next R1
                End If

                '*****************************
                'Print Packing List lalel
                '*****************************
                Me.PrintPackingListReport(iWO_ID, iTotalBoxInOrder, iCust_ID)
                '***************************** 

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                Buisness.Generic.DisposeDT(dtBoxIDs)
            End Try
        End Function

        '******************************************************************
        Public Function Print2DBarcodeBoxLabel(ByVal iPalletID As Integer, _
                                               ByVal iTotalBoxInOrder As Integer, _
                                               Optional ByVal booTalBarcode As Boolean = False, _
                                               Optional ByVal iCust_ID As Integer = 0) As Integer
            Const strBoxLabelReportName As String = "TF 2D Box Label Push.rpt"
            Const strBoxLabelReportName_AB As String = "TF 2D Box Label Additional Barcode Push.rpt"
            Dim strSql, strSNs As String
            Dim dt, dt2 As DataTable
            Dim R1 As DataRow

            Try
                strSql = "SELECT DISTINCT A.Pallett_ID, E.Name as 'ComName' " & Environment.NewLine
                strSql &= ", E.Address1 as 'Address' " & Environment.NewLine
                strSql &= ", CONCAT(E.City, ', ', E.State) as 'CityNState' " & Environment.NewLine
                strSql &= ", E.Zip as 'ZIP' " & Environment.NewLine
                strSql &= ", CONCAT('*', C.OrderNo, '*') as 'TransOrderBar' " & Environment.NewLine
                strSql &= ", C.OrderNo as 'TransOrder' " & Environment.NewLine
                strSql &= ", CONCAT('*', D.VN_ItemNo, '*') as 'PartNumBar' " & Environment.NewLine
                strSql &= ", D.VN_ItemNo as 'PartNum' " & Environment.NewLine
                strSql &= ", D.LineItemDetail as 'PartDesc' " & Environment.NewLine
                'If iCust_ID = PSS.Data.Buisness.WFM.CUSTOMER_ID Then
                '    strSql &= ", CONCAT('*', 999999, '*') as 'ShipmentIDBar' " & Environment.NewLine
                '    strSql &= ", 999999 as 'ShipmentID' " & Environment.NewLine
                'Else
                '    strSql &= ", CONCAT('*', B.Tray_ID, '*') as 'ShipmentIDBar' " & Environment.NewLine
                '    strSql &= ", B.Tray_ID as 'ShipmentID' " & Environment.NewLine
                'End If
                strSql &= ", CONCAT('*', B.Tray_ID, '*') as 'ShipmentIDBar' " & Environment.NewLine
                strSql &= ", B.Tray_ID as 'ShipmentID' " & Environment.NewLine
                strSql &= ", CONCAT('*', A.Pallett_Name, '*') as 'CartonIDBar' " & Environment.NewLine
                strSql &= ", A.Pallett_Name as 'CartonID' " & Environment.NewLine
                strSql &= ", A.Order_SeqNo as 'CartonNumX' " & Environment.NewLine
                strSql &= ", 0 as 'CartonNumN' " & Environment.NewLine
                strSql &= ", '' as 'CartonQtyBar' " & Environment.NewLine
                strSql &= ", '' as 'CartonQty' " & Environment.NewLine
                strSql &= ", A.Pallett_QTY as 'BarcodeSNQty' " & Environment.NewLine
                strSql &= ", '' as 'SNs' " & Environment.NewLine
                strSql &= "FROM production.tpallett A " & Environment.NewLine
                'If iCust_ID <> PSS.Data.Buisness.WFM.CUSTOMER_ID Then
                '    strSql &= "INNER JOIN production.ttray B ON A.WO_ID = B.WO_ID " & Environment.NewLine
                'End If
                strSql &= "INNER JOIN production.ttray B ON A.WO_ID = B.WO_ID " & Environment.NewLine
                strSql &= "INNER JOIN edi.torder C ON A.WO_ID = C.PSS_WO_ID " & Environment.NewLine
                strSql &= "INNER JOIN edi.torderdetail D ON C.Order_ID = D.Order_ID " & Environment.NewLine
                strSql &= "INNER JOIN edi.taddress E ON C.Order_ID = E.Order_ID AND E.EntityIdentifierCode = 'ST' " & Environment.NewLine
                strSql &= "WHERE A.Pallett_ID = " & iPalletID & "; " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count = 0 Then
                    Throw New Exception("No data found while system try to print box label.")
                ElseIf dt.Rows.Count > 1 Then
                    Throw New Exception("Duplicate record occur while printing box label.")
                Else
                    If dt.Rows.Count > 0 Then
                        For Each R1 In dt.Rows
                            strSNs = ""
                            strSNs = Me.GetSNsInBox(R1("Pallett_ID"))
                            R1.BeginEdit()
                            R1("SNs") = strSNs
                            R1("CartonNumN") = iTotalBoxInOrder
                            R1("CartonQty") = Format(iTotalBoxInOrder, "000")
                            R1("CartonQtyBar") = "*" & R1("CartonQty") & "*"
                            R1.EndEdit()
                        Next R1
                    End If
                    dt.AcceptChanges()

                    '**********************************
                    'Print Label
                    '**********************************
                    If booTalBarcode = True Then
                        PrintTalBarCodeBoxLabel(dt)
                    Else
                        '*********************************************
                        'Slit SNs list into 2 label 
                        'Reason: PDF417 can't encode string of 90 SNs
                        '*********************************************
                        If dt.Rows(0)("SNs").ToString.Split(",").Length > 45 Then
                            dt2 = Me.SplitSNListBarcodes(dt)
                        End If
                        clsMisc.PrintCrystalReportLabel(dt, strBoxLabelReportName, 1, "2DBoxLabel")
                        If Not IsNothing(dt2) Then clsMisc.PrintCrystalReportLabel(dt2, strBoxLabelReportName_AB, 1, "2DBoxLabel")
                        '*********************************************
                    End If
                    '**********************************
                End If

                Return dt.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetSNsInBox(ByVal iPalletID As Integer) As String
            Dim strSql As String
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim strSNs As String = ""

            Try
                strSql = "SELECT DISTINCT A.Device_SN " & Environment.NewLine
                strSql &= "FROM production.tdevice A " & Environment.NewLine
                strSql &= "WHERE A.Pallett_ID = " & iPalletID & "; " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                For Each R1 In dt.Rows
                    If strSNs.Trim.Length > 0 Then strSNs &= ","
                    'strSNs &= Left(R1("Device_SN"), R1("Device_SN").ToString.Trim.Length - 1)
                    strSNs &= R1("Device_SN")
                Next R1

                Return strSNs
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetMaxBoxNoInOrder(ByVal iWOID As Integer) As Integer
            Dim strSql As String
            Try
                strSql = "Select Max(Order_SeqNo) as MaxBoxInOrder FROM tpallett WHERE WO_ID = " & iWOID & ";"
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetNoneCageRBWSCount(ByVal iPalletID As Integer) As Integer
            Dim strSql As String
            Try
                strSql = "Select count(*) as cnt " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tcellopt ON tdevice.device_id = tcellopt.Device_ID " & Environment.NewLine
                strSql &= "WHERE Pallett_ID = " & iPalletID & Environment.NewLine
                strSql &= "AND WorkStation <> 'WH-RB' " & Environment.NewLine
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '******************************************************************
        Public Function GetNoneWHFloorCount(ByVal iPalletID As Integer) As Integer
            Dim strSql As String
            Try
                strSql = "Select count(*) as cnt " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tcellopt ON tdevice.device_id = tcellopt.Device_ID " & Environment.NewLine
                strSql &= "WHERE Pallett_ID = " & iPalletID & Environment.NewLine
                strSql &= "AND WorkStation <> 'WH-FLOOR' " & Environment.NewLine
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Private Function PrintTalBarCodeBoxLabel(ByVal dtData As DataTable) As Boolean
            Const strFilePatth As String = "C:\BoxLabel\2DBarcode.xls"
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet

            Dim strArrData(8, 2) As String
            Dim R1 As DataRow

            Try
                PrintTalBarCodeBoxLabel = False

                objExcel = New Excel.Application()
                objBook = objExcel.Workbooks.Open(strFilePatth)

                objSheet = objExcel.Worksheets(1)
                objExcel.Visible = True
                'objExcel.Application.DisplayAlerts = False

                For Each R1 In dtData.Rows
                    ''Column E data
                    'strArrData(0, 0) = "Product Support Services, Inc."
                    'strArrData(1, 0) = R1("CartonID")
                    'strArrData(2, 0) = "Ship To:"
                    'strArrData(3, 0) = R1("ComName")
                    'strArrData(4, 0) = R1("Address")
                    'strArrData(5, 0) = R1("CityNState")
                    'strArrData(6, 0) = ""
                    'If R1("SNs").ToString.Trim.Length > 1422 Then strArrData(7, 0) = Left(R1("SNs"), 1422) Else strArrData(7, 0) = R1("SNs")

                    ''Column F data
                    'strArrData(0, 1) = R1("TransOrder")
                    'strArrData(1, 1) = ""
                    'strArrData(2, 1) = "Shipment ID:"
                    'strArrData(3, 1) = R1("ShipmentID")
                    'strArrData(4, 1) = ""
                    'strArrData(5, 1) = "Carton Number " & R1("CartonNumX") & " of " & R1("CartonNumN")
                    'strArrData(6, 1) = ""
                    'strArrData(7, 1) = ""
                    'objSheet.Range("E2:F9").Value = strArrData

                    ''Column E data
                    objExcel.Application.Cells(2, 5).Value = "Product Support Services, Inc."
                    objExcel.Application.Cells(3, 5).Value = R1("CartonID")
                    objExcel.Application.Cells(4, 5).Value = "Ship To:"
                    objExcel.Application.Cells(5, 5).Value = R1("ComName")
                    objExcel.Application.Cells(6, 5).Value = R1("Address")
                    objExcel.Application.Cells(7, 5).Value = R1("CityNState")
                    objExcel.Application.Cells(8, 5).Value = ""
                    If R1("SNs").ToString.Trim.Length > 1421 Then objExcel.Application.Cells(9, 5).Value = Left(R1("SNs"), 1421) Else objExcel.Application.Cells(9, 5).Value = R1("SNs")

                    ''Column F data
                    objExcel.Application.Cells(2, 6).Value = R1("TransOrder")
                    objExcel.Application.Cells(3, 6).Value = ""
                    objExcel.Application.Cells(4, 6).Value = "Shipment ID:"
                    objExcel.Application.Cells(5, 6).Value = R1("ShipmentID")
                    objExcel.Application.Cells(6, 6).Value = ""
                    objExcel.Application.Cells(7, 6).Value = "Carton Number " & R1("CartonNumX") & " of " & R1("CartonNumN")
                    objExcel.Application.Cells(8, 6).Value = ""
                    objExcel.Application.Cells(9, 6).Value = ""


                    'objExcel.ActiveWorkbook.Save()
                    objExcel.ActiveWindow.SelectedSheets.PrintOut(Copies:=1, Collate:=True)
                Next R1

                objExcel.ActiveWorkbook.Save()

                Return True
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                Generic.DisposeDT(dtData)

                '*************************************
                'Excel clean up
                If Not IsNothing(objSheet) Then
                    Generic.NAR(objSheet)
                End If
                If Not IsNothing(objExcel) Then
                    objExcel.Quit()
                    Generic.NAR(objExcel)
                End If
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
            End Try
        End Function

        '******************************************************************
        Private Function SplitSNListBarcodes(ByRef dt As DataTable) As DataTable
            Dim strArrSNs() As String
            Dim strSNList1, strSNList2 As String
            Dim i As Integer = 0
            Dim dt2 As DataTable
            Dim R1 As DataRow

            Try
                strSNList1 = "" : strSNList2 = ""
                '*****************************
                '1: Print License Plate
                '*****************************
                If Not IsNothing(dt) Then
                    strArrSNs = dt.Rows(0)("SNs").ToString.Split(",")

                    If strArrSNs.Length > 45 Then
                        For i = 0 To strArrSNs.Length - 1
                            If i < 45 Then
                                If strSNList1.Trim.Length > 0 Then strSNList1 &= ","
                                strSNList1 &= strArrSNs(i)
                            Else
                                If strSNList2.Trim.Length > 0 Then strSNList2 &= ","
                                strSNList2 &= strArrSNs(i)
                            End If
                        Next i

                        dt2 = New DataTable()
                        dt2 = dt.Clone
                        R1 = dt2.NewRow
                        For i = 0 To dt.Columns.Count - 1
                            R1(i) = dt.Rows(0)(i)
                        Next i
                        R1("BarcodeSNQty") = strArrSNs.Length - 45
                        R1("SNs") = strSNList2
                        dt2.Rows.Add(R1)
                        dt2.AcceptChanges()

                        dt.Rows(0).BeginEdit()
                        dt.Rows(0)("BarcodeSNQty") = 45
                        dt.Rows(0)("SNs") = strSNList1
                        dt.Rows(0).EndEdit()
                        dt.Rows(0).AcceptChanges()
                    End If
                End If

                Return dt2
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt2)
            End Try
        End Function

        '******************************************************************
        Public Function GetDeviceWithoutBatteryCover(ByVal iPalletID As Integer) As DataTable
            Const iNewBatCoverBillcodeID As Integer = 154
            Const iUsedBatCoverBillcodeID As Integer = 1869
            Const iRVBatCoverBillcodeID As Integer = 2510
            Dim strSql As String = ""

            Try
                strSql = "SELECT Device_SN FROM tdevice" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tdevicebill ON tdevice.device_id = tdevicebill.device_id " & Environment.NewLine
                strSql &= "AND billcode_id in  ( " & iNewBatCoverBillcodeID & ", " & iUsedBatCoverBillcodeID & ", " & iRVBatCoverBillcodeID & " )" & Environment.NewLine
                strSql &= "WHERE pallett_id =  " & iPalletID & " AND dbill_id is null;"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************

#End Region

#Region "Create Packing Slip"

        '******************************************************************
        Public Function GetOrderFilledBoxCnt(ByVal iWOID As Integer) As Integer
            Dim strSql As String
            Try
                strSql = "SELECT count(*) as cnt " & Environment.NewLine
                strSql &= "FROM production.tpallett A " & Environment.NewLine
                strSql &= "WHERE A.WO_ID = " & iWOID & Environment.NewLine
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetTFOrderReadyForPackingSlip(ByVal iCust_ID As Integer) As DataTable
            Dim strSql As String
            Try
                strSql = "SELECT DISTINCT B.OrderNo as 'Order #', C.cust_OutgoingSku as 'Model', count(*) as 'Box Qty', sum(Pallett_QTY) as 'Unit Qty' " & Environment.NewLine
                strSql &= "FROM production.tpallett A " & Environment.NewLine
                strSql &= "INNER JOIN edi.torder B on A.WO_ID = B.PSS_WO_ID " & Environment.NewLine
                strSql &= "INNER JOIN production.tcustmodel_pssmodel_map C ON A.Model_ID = C.Model_ID " & Environment.NewLine
                strSql &= "WHERE A.pkslip_ID is null " & Environment.NewLine
                strSql &= "AND A.Cust_ID = " & iCust_ID & Environment.NewLine 'TracFone.BuildShipPallet.TracFone_CUSTOMER_ID & Environment.NewLine
                strSql &= "GROUP BY B.OrderNo; " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetTFOrderReadyForPackingSlipTemplateTable() As DataTable
            Dim strSql As String
            Try
                strSql = "SELECT '' as 'Order #', 0 as WO_ID, 0 as Pallet_SeqNo, 0 as 'Box Qty', 0 as 'Unit Qty' limit 0; " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetOrderToBeManifestByOrderNo(ByVal strOrderNo As String, ByVal iCust_ID As Integer) As DataTable
            Dim strSql As String
            Try
                strSql = "SELECT A.*, B.WO_Closed, B.WO_CustWO, C.cust_OutgoingSku, C.cust_OutgoingDesc " & Environment.NewLine
                strSql &= "FROM production.tpallett A " & Environment.NewLine
                strSql &= "INNER JOIN production.tworkorder B on A.WO_ID = B.WO_ID " & Environment.NewLine
                strSql &= "INNER JOIN production.tcustmodel_pssmodel_map C ON A.Model_ID = C.Model_ID " & Environment.NewLine
                strSql &= "WHERE B.WO_CustWO = '" & strOrderNo & "'" & Environment.NewLine
                strSql &= "AND A.Cust_ID = " & iCust_ID & Environment.NewLine  'BuildShipPallet.TracFone_CUSTOMER_ID & Environment.NewLine
                strSql &= "AND A.Pallet_Invalid  = 0 " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetOrdersToBeManifestbyWOIDs(ByVal strWOIDs As String, ByVal iCust_ID As Integer) As DataTable
            Dim strSql As String
            Try
                strSql = "SELECT A.*, B.WO_Closed, B.WO_CustWO, C.cust_OutgoingSku, C.cust_OutgoingDesc " & Environment.NewLine
                strSql &= "FROM production.tpallett A " & Environment.NewLine
                strSql &= "INNER JOIN production.tworkorder B on A.WO_ID = B.WO_ID " & Environment.NewLine
                strSql &= "INNER JOIN production.tcustmodel_pssmodel_map C ON A.Model_ID = C.Model_ID " & Environment.NewLine
                strSql &= "WHERE B.WO_ID in (" & strWOIDs & " ) " & Environment.NewLine
                strSql &= "AND A.Cust_ID = " & iCust_ID & Environment.NewLine 'BuildShipPallet.TracFone_CUSTOMER_ID & Environment.NewLine
                strSql &= "AND A.Pallet_Invalid  = 0 " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function CreateManifest(ByVal dtOrders As DataTable, ByVal strWOIDs As String, ByVal iUserID As Integer, ByVal iShipCarrierID As Integer, _
                                       ByVal strTrackingNo As String, ByVal strScreenName As String, ByVal strFormName As String, ByVal iCust_ID As Integer) As Integer
            Const strToWorkstation As String = "INTRANSIT"
            Dim strSql As String = ""
            Dim i, j, iPkslip_ID, iTotalBoxInOrder As Integer
            Dim R1 As DataRow
            Dim dt As DataTable

            Try
                i = 0 : j = 0 : iPkslip_ID = 0 : iTotalBoxInOrder = 0

                'Get List of device to record workstation journal 
                strSql = "SELECT tcellopt.Device_ID, Workstation FROM tcellopt " & Environment.NewLine
                strSql &= "INNER JOIN tdevice ON tcellopt.Device_ID = tdevice.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strSql &= "WHERE tpallett.WO_ID IN ( " & strWOIDs & " ) " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                strSql = "INSERT INTO tpackingslip ( " & Environment.NewLine
                strSql &= "tpackingslip.pkslip_createDt " & Environment.NewLine
                strSql &= ", tpackingslip.Cust_ID " & Environment.NewLine
                strSql &= ", tpackingslip.pkslip_usrID " & Environment.NewLine
                strSql &= ", tpackingslip.pkslip_TrackNo " & Environment.NewLine
                strSql &= ", tpackingslip.pkslip_DockShipDate " & Environment.NewLine
                strSql &= ", tpackingslip.pkslip_DSUpdateUserID " & Environment.NewLine
                strSql &= ", tpackingslip.pkSlip_DSUpdateDate " & Environment.NewLine
                strSql &= ", tpackingslip.SC_ID " & Environment.NewLine
                strSql &= ") VALUES ( " & Environment.NewLine
                strSql &= "now() " & Environment.NewLine
                strSql &= ", " & iCust_ID & Environment.NewLine ' TracFone.BuildShipPallet.TracFone_CUSTOMER_ID & " " & Environment.NewLine
                strSql &= ", " & iUserID & " " & Environment.NewLine
                strSql &= ", '" & strTrackingNo & "' " & Environment.NewLine
                strSql &= ", now() " & Environment.NewLine
                strSql &= ", " & iUserID & Environment.NewLine
                strSql &= ", now() " & Environment.NewLine
                strSql &= ", " & iShipCarrierID & Environment.NewLine
                strSql &= ");"
                iPkslip_ID = Me._objDataProc.idTransaction(strSql, "tpackingslip")
                If iPkslip_ID = 0 Then Throw New Exception("System has failed to creat manifest ID.")

                For Each R1 In dtOrders.Rows
                    j += 1
                    strSql = "UPDATE tpallett " & Environment.NewLine
                    strSql &= "SET pkslip_ID = " & iPkslip_ID & Environment.NewLine
                    strSql &= ", Pallet_SeqNo = " & R1("Pallet_SeqNo") & Environment.NewLine
                    strSql &= "WHERE tpallett.WO_ID = " & R1("WO_ID") & Environment.NewLine
                    strSql &= "AND (pkslip_ID is null or pkslip_ID = 0);" & Environment.NewLine
                    i += Me._objDataProc.ExecuteNonQuery(strSql)

                    strSql = "UPDATE tcellopt " & Environment.NewLine
                    strSql &= "INNER JOIN tdevice ON tcellopt.Device_ID = tdevice.Device_ID " & Environment.NewLine
                    strSql &= "INNER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                    strSql &= "SET WorkStation = '" & strToWorkstation & "'" & Environment.NewLine
                    strSql &= ", WorkStationEntryDt = now()" & Environment.NewLine
                    strSql &= ", Cellopt_WIPOwner = 7, Cellopt_WIPOwnerOld = Cellopt_WIPEntryDt, Cellopt_WIPEntryDt = now() " & Environment.NewLine
                    strSql &= "WHERE tpallett.WO_ID = " & R1("WO_ID") & Environment.NewLine
                    i += Me._objDataProc.ExecuteNonQuery(strSql)
                Next R1

                Generic.SetTcelloptWorkstationJournal(dt, iUserID, strToWorkstation, strScreenName, strFormName)

                '''*****************************
                '''Print Packing List Report (2 copies)
                '''HAS MOVED TO FILL ORDER SCREEN
                '''*****************************
                ''For Each R1 In dtOrders.Rows
                ''    iTotalBoxInOrder = 0
                ''    iTotalBoxInOrder = Me.GetMaxBoxNoInOrder(R1("WO_ID"))
                ''    Me.PrintPackingListReport(R1("WO_ID"), iTotalBoxInOrder)
                ''Next R1

                '*****************************
                'Print Bill of Lading
                '*****************************
                PrintBillsOfLadingReport(iPkslip_ID, iCust_ID)
                '*****************************
                'Print Pallet Label
                '*****************************
                Me.PrintShipmentLabelReport(iPkslip_ID, iCust_ID)
                '*****************************
                Return iPkslip_ID
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                Buisness.Generic.DisposeDT(dtOrders)
            End Try
        End Function

        '******************************************************************
        Public Function CreateBERManifest(ByVal strPalletIDs As String, ByVal iUserID As Integer, _
                                          ByVal strScreenName As String, ByVal strFormName As String) As Integer

            Const strToWorkstation As String = "INTRANSIT"
            Dim strSql As String = ""
            Dim i, iPkslip_ID, iTotalBoxInOrder As Integer
            Dim R1 As DataRow
            Dim dt As DataTable

            Try
                i = 0 : iPkslip_ID = 0 : iTotalBoxInOrder = 0

                strSql = "SELECT tdevice.Device_ID, Workstation " & Environment.NewLine
                strSql &= "FROM tdevice INNER JOIN tcellopt ON tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                strSql &= "WHERE Pallett_ID IN ( " & strPalletIDs & " ) " & Environment.NewLine
                strSql &= "AND (pkslip_ID is null or pkslip_ID = 0)" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                strSql = "INSERT INTO tpackingslip ( " & Environment.NewLine
                strSql &= "tpackingslip.pkslip_createDt " & Environment.NewLine
                strSql &= ", tpackingslip.Cust_ID " & Environment.NewLine
                strSql &= ", tpackingslip.pkslip_usrID " & Environment.NewLine
                strSql &= ", tpackingslip.pkslip_DockShipDate " & Environment.NewLine
                strSql &= ", tpackingslip.pkslip_DSUpdateUserID " & Environment.NewLine
                strSql &= ", tpackingslip.pkSlip_DSUpdateDate " & Environment.NewLine
                strSql &= ") VALUES ( " & Environment.NewLine
                strSql &= "now() " & Environment.NewLine
                strSql &= ", " & TracFone.BuildShipPallet.TracFone_CUSTOMER_ID & " " & Environment.NewLine
                strSql &= ", " & iUserID & " " & Environment.NewLine
                strSql &= ", now() " & Environment.NewLine
                strSql &= ", " & iUserID & Environment.NewLine
                strSql &= ", now() " & Environment.NewLine
                strSql &= ");"
                iPkslip_ID = Me._objDataProc.idTransaction(strSql, "tpackingslip")
                If iPkslip_ID = 0 Then Throw New Exception("System has failed to creat manifest ID.")

                strSql = "UPDATE tpallett " & Environment.NewLine
                strSql &= "SET pkslip_ID = " & iPkslip_ID & Environment.NewLine
                strSql &= "WHERE tpallett.Pallett_ID IN ( " & strPalletIDs & " ) " & Environment.NewLine
                strSql &= "AND (pkslip_ID is null or pkslip_ID = 0);" & Environment.NewLine
                i += Me._objDataProc.ExecuteNonQuery(strSql)

                strSql = "UPDATE tcellopt " & Environment.NewLine
                strSql &= "INNER JOIN tdevice ON tcellopt.Device_ID = tdevice.Device_ID " & Environment.NewLine
                strSql &= "SET WorkStation = '" & strToWorkstation & "'" & Environment.NewLine
                strSql &= ", WorkStationEntryDt = now()" & Environment.NewLine
                strSql &= ", Cellopt_WIPOwner = 7, Cellopt_WIPOwnerOld = Cellopt_WIPEntryDt, Cellopt_WIPEntryDt = now() " & Environment.NewLine
                strSql &= "WHERE tdevice.Pallett_ID IN ( " & strPalletIDs & ") " & Environment.NewLine
                i += Me._objDataProc.ExecuteNonQuery(strSql)

                Generic.SetTcelloptWorkstationJournal(dt, iUserID, strToWorkstation, strScreenName, strFormName)

                Dim objSPPLF As New Buisness.SendPalletPackingListFiles()
                objSPPLF.PrintShipPackingSlip(iPkslip_ID, TracFone.BuildShipPallet.TracFone_CUSTOMER_ID)

                Return iPkslip_ID
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
            End Try
        End Function

        '******************************************************************
        Public Function PrintPackingListReport(ByVal iWOID As Integer, _
                                               ByVal iTotalBoxInOrder As Integer, _
                                               Optional ByVal iCust_ID As Integer = 0) As Integer
            Const strPackingListReportName As String = "TF Packing List Push.rpt"
            Dim strSql As String
            Dim dt As DataTable

            Try
                strSql = "SELECT DISTINCT B.Tray_ID AS 'PackingListNo'" & Environment.NewLine
                'strSql &= ", F.SC_Desc AS 'CarrierName'" & Environment.NewLine
                strSql &= ", D.OrderNo AS 'WHTransfOrderNo'" & Environment.NewLine
                strSql &= ", E.VN_ItemNo AS 'PartNo'" & Environment.NewLine
                strSql &= ", E.LineItemDetail AS 'PartDesc'" & Environment.NewLine
                strSql &= ", D.OrderQty AS 'QtyOrdered'" & Environment.NewLine
                strSql &= ", SUM(A.Pallett_QTY) AS 'QtyShipped'" & Environment.NewLine
                strSql &= ", 0 AS 'QtyBackOrder'" & Environment.NewLine
                strSql &= ", Max(A.Order_SeqNo) AS 'NumberOfBox'" & Environment.NewLine
                If iCust_ID = PSS.Data.Buisness.WFM.CUSTOMER_ID Then
                    strSql &= ", 'WFM(TracFone)' AS 'Customer'" & Environment.NewLine
                ElseIf iCust_ID = 2258 Then 'TracFone
                    strSql &= ", 'TracFone' AS 'Customer'" & Environment.NewLine
                End If
                strSql &= "FROM production.tpallett A" & Environment.NewLine
                strSql &= "INNER JOIN production.ttray B ON  A.WO_ID = B.WO_ID" & Environment.NewLine
                'strSql &= "INNER JOIN production.tpackingslip C ON A.Pkslip_ID = C.Pkslip_ID" & Environment.NewLine
                strSql &= "INNER JOIN edi.torder D ON A.WO_ID = D.PSS_WO_ID" & Environment.NewLine
                strSql &= "INNER JOIN edi.torderdetail E ON D.Order_ID = E.Order_ID" & Environment.NewLine
                'strSql &= "INNER JOIN production.lshipcarrier F ON C.SC_ID = F.SC_ID" & Environment.NewLine
                strSql &= "WHERE A.WO_ID = " & iWOID & Environment.NewLine
                strSql &= "GROUP BY A.WO_ID;" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                clsMisc.PrintCrystalReportLabel(dt, strPackingListReportName, 2, )
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function PrintBillsOfLadingReport(ByVal iPackingListID As Integer, ByVal iCust_ID As Integer) As Integer
            Const BillsOfLadingReportName As String = "TF Bills of Lading Push.rpt"
            Dim strSql As String
            Dim dt As DataTable

            Try
                strSql = "SELECT DISTINCT F.Name AS 'ShipToName'" & Environment.NewLine
                strSql &= ", F.Address1 AS 'ShipToAddress'" & Environment.NewLine
                strSql &= ", F.City AS 'ShipToCity'" & Environment.NewLine
                strSql &= ", F.Zip AS 'ShipToZip'" & Environment.NewLine
                strSql &= ", F.State AS 'ShipToState'" & Environment.NewLine
                strSql &= ", Date_Format(A.pkslip_DockShipDate, '%m/%d/%Y') AS 'ShipDate'" & Environment.NewLine
                strSql &= ", C.SC_Desc AS 'Carrier'" & Environment.NewLine
                strSql &= ", Count(*) AS 'TotalBox'" & Environment.NewLine
                strSql &= ", Max(Pallet_SeqNo) AS 'TotalPallet'" & Environment.NewLine
                strSql &= ", Sum(Pallet_Weight) AS 'GrossWeight'" & Environment.NewLine
                strSql &= ", '62820' AS 'NMFC_Code'" & Environment.NewLine
                strSql &= ", 'Cell Phone' AS 'NMFC_Desc'" & Environment.NewLine
                strSql &= ", D.OrderNo AS 'OrderNo'" & Environment.NewLine
                strSql &= ", E.VN_ItemNo AS 'PartNo'" & Environment.NewLine
                strSql &= ", E.LineItemDetail AS 'PartDesc'" & Environment.NewLine
                strSql &= ", pkslip_TrackNo AS 'TrackingNo'" & Environment.NewLine
                strSql &= ", A.pkslip_ID AS 'PackingSlip_ID'" & Environment.NewLine
                If iCust_ID = PSS.Data.Buisness.WFM.CUSTOMER_ID Then
                    strSql &= ", 'WFM(TracFone)' AS 'Customer'" & Environment.NewLine
                ElseIf iCust_ID = TracFone.BuildShipPallet.TracFone_CUSTOMER_ID Then
                    strSql &= ", 'TracFone' AS 'Customer'" & Environment.NewLine
                End If
                strSql &= "FROM production.tpackingslip A" & Environment.NewLine
                strSql &= "INNER JOIN production.tpallett B ON A.pkslip_ID = B.pkslip_ID" & Environment.NewLine
                strSql &= "INNER JOIN production.lshipcarrier C ON A.SC_ID = C.SC_ID" & Environment.NewLine
                strSql &= "INNER JOIN edi.torder D ON B.WO_ID = D.PSS_WO_ID" & Environment.NewLine
                strSql &= "INNER JOIN edi.torderdetail E ON D.Order_ID = E.Order_ID" & Environment.NewLine
                strSql &= "INNER JOIN edi.taddress F ON D.Order_ID = F.Order_ID  AND F.EntityIdentifierCode = 'ST'" & Environment.NewLine
                strSql &= "WHERE A.pkslip_ID = " & iPackingListID & Environment.NewLine
                strSql &= "GROUP BY A.pkslip_ID, B.WO_ID ;" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                clsMisc.PrintCrystalReportLabel(dt, BillsOfLadingReportName, 1, )
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function PrintShipmentLabelReport(ByVal iPackingListID As Integer, ByVal iCust_ID As Integer) As Integer
            Const BillsOfLadingReportName As String = "TF Pallet Label Push.rpt"
            Dim strSql As String
            Dim dt, dt1, dtPallet As DataTable
            Dim R1, drNewRow, drArr() As DataRow
            Dim i, j As Integer

            Try
                j = 0 : j = 0

                strSql = "SELECT DISTINCT " & Environment.NewLine
                strSql &= "B.Pallet_SeqNo AS 'PalletNo', count(*) as cnt" & Environment.NewLine
                strSql &= "FROM production.tpackingslip A" & Environment.NewLine
                strSql &= "INNER JOIN production.tpallett B ON A.pkslip_ID = B.pkslip_ID" & Environment.NewLine
                strSql &= "WHERE A.pkslip_ID = " & iPackingListID & Environment.NewLine
                strSql &= "GROUP BY Pallet_SeqNo ORDER BY Pallet_SeqNo ;" & Environment.NewLine
                dt1 = Me._objDataProc.GetDataTable(strSql)

                strSql = "SELECT DISTINCT E.Name AS 'ShipToName'" & Environment.NewLine
                strSql &= ", E.Address1 AS 'ShipToAddress'" & Environment.NewLine
                strSql &= ", E.City AS 'ShipToCity'" & Environment.NewLine
                strSql &= ", E.Zip AS 'ShipToZip'" & Environment.NewLine
                strSql &= ", E.State AS 'ShipToState'" & Environment.NewLine
                strSql &= ", D.OrderNo AS 'PONo'" & Environment.NewLine
                strSql &= ", Count(*) AS 'CartonQty'" & Environment.NewLine
                strSql &= ", A.pkslip_TrackNo AS 'TrackingNo'" & Environment.NewLine
                strSql &= ", F.Tray_ID AS 'PackingListNo'" & Environment.NewLine
                strSql &= ", B.Pallet_SeqNo AS 'PalletNo'" & Environment.NewLine
                strSql &= ", MAX(Pallet_SeqNo) as 'PalletTotal'" & Environment.NewLine
                If iCust_ID = PSS.Data.Buisness.WFM.CUSTOMER_ID Then
                    strSql &= ", 'WFM(TracFone)' AS 'Customer'" & Environment.NewLine
                ElseIf iCust_ID = TracFone.BuildShipPallet.TracFone_CUSTOMER_ID Then
                    strSql &= ", 'TracFone' AS 'Customer'" & Environment.NewLine
                End If
                strSql &= "FROM production.tpackingslip A" & Environment.NewLine
                strSql &= "INNER JOIN production.tpallett B ON A.pkslip_ID = B.pkslip_ID" & Environment.NewLine
                strSql &= "INNER JOIN production.lshipcarrier C ON A.SC_ID = C.SC_ID" & Environment.NewLine
                strSql &= "INNER JOIN edi.torder D ON B.WO_ID = D.PSS_WO_ID" & Environment.NewLine
                strSql &= "INNER JOIN edi.taddress E ON D.Order_ID = E.Order_ID  AND E.EntityIdentifierCode = 'ST'" & Environment.NewLine
                strSql &= "INNER JOIN production.ttray F ON B.WO_ID = F.WO_ID" & Environment.NewLine
                strSql &= "WHERE A.pkslip_ID = " & iPackingListID & Environment.NewLine
                strSql &= "GROUP BY A.pkslip_ID, B.WO_ID, Pallet_SeqNo ;" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt1.Rows.Count > 0 Then
                    For Each R1 In dt1.Rows
                        Buisness.Generic.DisposeDT(dtPallet)
                        drNewRow = Nothing
                        dtPallet = New DataTable()
                        dtPallet = dt.Clone

                        drArr = dt.Select("PalletNo = " & R1("PalletNo"))
                        For j = 0 To drArr.Length - 1
                            drNewRow = Nothing
                            drNewRow = dtPallet.NewRow
                            For i = 0 To dt.Columns.Count - 1
                                drNewRow(i) = drArr(j)(i)
                            Next i
                            drNewRow("PalletTotal") = dt.Compute("MAX(PalletTotal)", "")
                            drNewRow("CartonQty") = R1("cnt")
                            dtPallet.Rows.Add(drNewRow)
                        Next j
                        dtPallet.AcceptChanges()
                        clsMisc.PrintCrystalReportLabel(dtPallet, BillsOfLadingReportName, 1, )
                    Next R1
                End If
            Catch ex As Exception
                Throw ex
            Finally
                drArr = Nothing
                R1 = Nothing
                drNewRow = Nothing
                Buisness.Generic.DisposeDT(dt)
                Buisness.Generic.DisposeDT(dtPallet)
                Buisness.Generic.DisposeDT(dt1)
            End Try
        End Function

        '******************************************************************
        Public Function GetPkSlipToReprint(ByVal iOrderNo As Integer) As DataTable
            Dim strSql As String
            Try
                strSql = "SELECT distinct pkslip_id, wo_closed FROM tpallett a" & Environment.NewLine
                strSql &= "INNER JOIN tworkorder b on a.wo_id = b.wo_id" & Environment.NewLine
                strSql &= "WHERE b.wo_custwo = " & iOrderNo & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function


#End Region

        '******************************************************************
        Public Function GetDiposeShipToAddress(ByVal iCustID As Integer, _
                                               ByVal booAddSelectedRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt, dtShipToAddr As DataTable

            Try
                dtShipToAddr = New DataTable()

                strSql = "SELECT Shipto_IDs FROM  disposeshiptoaddress WHERE Cust_ID = " & iCustID & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    strSql = "SELECT * FROM tshipto WHERE shipto_id in ( " & dt.Rows(0)("Shipto_IDs") & " )"
                    dtShipToAddr = Me._objDataProc.GetDataTable(strSql)
                    If booAddSelectedRow = True Then dtShipToAddr.LoadDataRow(New Object() {"0", "--SELECT--"}, False)
                End If

                Return dtShipToAddr
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
                Generic.DisposeDT(dtShipToAddr)
            End Try
        End Function

        '******************************************************************
        Public Function GetReadyToManifestBERBoxes(ByVal iCustID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT distinct tpallett.Pallett_ID, Pallett_Name as 'Box', Pallett_QTY as 'Box Qty', count(*) as 'Station Qty' " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "INNER JOIN tdevice ON tpallett.Pallett_ID = tdevice.Pallett_ID " & Environment.NewLine
                strSql &= "AND Pallett_ShipDate is not null AND Cust_ID = " & iCustID & " AND Pallet_ShipType = 1 " 'AND pkslip_ID is null " & Environment.NewLine
                strSql &= "INNER JOIN tcellopt ON tdevice.Device_ID = tcellopt.Device_ID" & Environment.NewLine
                strSql &= "WHERE Workstation = 'BER COMPLETE'" & Environment.NewLine
                strSql &= "GROUP BY tpallett.Pallett_ID"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetReadyToManifestBERBoxInfo(ByVal strBox As String, ByVal iCustID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT tpallett.Pallett_ID, Pallett_Name as 'Box', Pallett_ShipDate, Pallet_ShipType, pkslip_ID , WorkStation, count(*) as 'Station Qty' " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "INNER JOIN tdevice ON tpallett.Pallett_ID = tdevice.Pallett_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcellopt ON tdevice.Device_ID = tcellopt.Device_ID" & Environment.NewLine
                strSql &= "WHERE Pallett_Name = '" & strBox & "'" & Environment.NewLine
                strSql &= "AND Cust_ID = " & iCustID & Environment.NewLine
                strSql &= "GROUP BY tpallett.Pallett_ID, WorkStation "
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ''******************************************************************
        'Public Function IsBoxBeenToTearDown(ByVal PalletID As Integer) As Boolean
        '    Dim strSql As String = ""

        '    Try
        '        IsBoxBeenToTearDown = False
        '        strSql = "SELECT count(*) as cnt " & Environment.NewLine
        '        strSql &= "FROM tracfoneberbox " & Environment.NewLine
        '        strSql &= "WHERE Pallett_ID = '" & PalletID & "'" & Environment.NewLine

        '        If Me._objDataProc.GetIntValue(strSql) > 0 Then Return True Else Return False
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function

        '******************************************************************
        Public Function GetBoxData(ByVal strPalletID As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT Pallett_Name" & Environment.NewLine
                strSql &= ", if(Pallett_ShipDate is null, '', Pallett_ShipDate) as Pallett_ShipDate" & Environment.NewLine
                strSql &= ", Pallet_ShipType" & Environment.NewLine
                strSql &= ", if (pkslip_ID is null, 0 , pkslip_ID) as pkslip_ID" & Environment.NewLine
                strSql &= ", WorkStation " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "INNER JOIN tdevice ON tpallett.Pallett_ID = tdevice.Pallett_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcellopt ON tdevice.Device_ID = tcellopt.Device_ID" & Environment.NewLine
                strSql &= "WHERE tpallett.Pallett_ID in ( " & strPalletID & " )" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************

#Region "Assign WH Box To WH Location"

        '***********************************************************************************************************************
        Public Function GetWHLocationBoxes(ByVal strStations As String, _
                                           Optional ByVal bEmptyWHLocation As Boolean = False, _
                                           Optional ByVal bDisplayMultipleWorkstation As Boolean = False) As DataTable
            Dim strSql As String = ""

            Try
                If bDisplayMultipleWorkstation Then
                    strSql = "SELECT A.BoxID, count(*) as Qty, WHLocation, Model_Desc as 'Model',D.WorkStation,'' AS 'MultipleWS'" & Environment.NewLine
                Else
                    strSql = "SELECT A.BoxID, count(*) as Qty, WHLocation, Model_Desc as 'Model',D.WorkStation" & Environment.NewLine
                End If
                strSql &= " FROM edi.twarehousebox A INNER JOIN edi.titem B ON A.wb_id = B.wb_id" & Environment.NewLine
                strSql &= " INNER JOIN production.tdevice C ON B.Device_ID = C.Device_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tcellopt D ON B.Device_ID = D.Device_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tmodel E ON C.Model_ID = E.Model_ID" & Environment.NewLine
                strSql &= " WHERE D.Workstation IN ( " & strStations & ")" & Environment.NewLine
                If bEmptyWHLocation Then
                    strSql &= " AND NOT (TRIM(WHLocation) <> '') " & Environment.NewLine
                Else
                    strSql &= " AND TRIM(WHLocation) <> '' " & Environment.NewLine
                End If
                strSql &= " GROUP BY A.BoxID"

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************
        Public Function AssignWHLocation(ByVal strBoxName As String, ByVal strWHLocation As String) As Integer
            Dim strSql As String = ""

            Try
                strSql = "UPDATE edi.twarehousebox SET WHLocation = '" & strWHLocation & "' " & Environment.NewLine
                strSql &= "WHERE BoxID = '" & strBoxName & "'" & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************

#End Region

    End Class
End Namespace