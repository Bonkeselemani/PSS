Option Explicit On 

Imports CrystalDecisions.CrystalReports.Engine

Namespace Buisness

    Public Class NIReports
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

        Public Function CreateEDI_RAM_Status(ByVal iCustID As Integer, ByVal strReportName As String, _
                                        ByVal strDateStart As String, ByVal strDateEnd As String) As Integer
            Dim strSql As String
            Dim dt As DataTable
            Dim objExcelRpt As ExcelReports
            Dim strCols(27) As String, i As Integer = 0

            Try
                ' a.NI_DataSwitch, a.WO_ID, a.EW_ID, a.Cust_ID,
                strSql = "SELECT a.ClaimNo AS RMA_NO, a.ShipTo_Name,b.Description AS Status, a.Cust2PSSI_TrackNo," & Environment.NewLine
                strSql &= "a.LoadedDateTime, a.TrackCreatedDateTime, c.NI_Prod_Desc,a.RepairType, a.DefectType1, a.DefectType2, a.ErrDesc_ItemSKU AS ErrDescription," & Environment.NewLine
                strSql &= "a.Email, a.ServiceLevel, a.SerialNo, a.Language, a.Account, a.SenderReference, a.PurchaseDate,  a.Address1," & Environment.NewLine
                strSql &= "a.Address2, a.City, a.State_ShortName, a.ZipCode,a.Cntry_NAme, a.Tel, If(a.Warranty=1,'Yes','No') AS Warranty,a.Date AS EmailReceivedTime" & Environment.NewLine
                strSql &= ", if(e.SoftKeyCode is null, '', e.SoftKeyCode) as 'Soft Key Code' " & Environment.NewLine
                strSql &= " FROM extendedwarranty a " & Environment.NewLine
                strSql &= " LEFT JOIN ni_status b ON a.S_ID = b.S_ID" & Environment.NewLine
                strSql &= " LEFT JOIN ni_products c ON a.Prod_Code = c.NI_Prod_ID" & Environment.NewLine
                strSql &= " LEFT JOIN tdevice d ON a.WO_ID = d.WO_ID" & Environment.NewLine
                strSql &= " LEFT JOIN tcellopt e ON d.Device_ID = e.Device_ID" & Environment.NewLine
                strSql &= " WHERE a.NI_DataSwitch = 1 AND a.Cust_ID = " & iCustID & Environment.NewLine
                strSql &= " AND a.LoadedDateTime between '" & strDateStart & " 00:00:00' AND '" & strDateEnd & " 23:59:59'" & Environment.NewLine
                strSql &= " ORDER BY a.LoadedDateTime, a.EW_ID;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    For i = 0 To strCols.Length - 1
                        strCols(i) = Number2Char(i + 1)
                    Next i
                    objExcelRpt = New ExcelReports(False)
                    objExcelRpt.RunSimpleExcelFormat(dt, strReportName, strCols)
                End If

                Return dt.Rows.Count

            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '**************************************************************************
        Private Function Number2Char(ByVal vNumber) As String

            Dim iDiv As Double, iMod As Integer

            Number2Char = Nothing
            If vNumber < 1 Then Exit Function

            iDiv = vNumber
            While iDiv > 26
                iMod = iDiv Mod 26
                If iMod = 0 Then
                    iMod = 26
                    iDiv = iDiv - 1
                End If
                Number2Char = Chr(64 + iMod) & Number2Char
                iDiv = iDiv \ 26
            End While

            Number2Char = Chr(64 + iDiv) & Number2Char
        End Function

        '**********************************************************************************
        Public Function GetWIPData(ByVal booSummary As Boolean) As DataSet
            Dim strSql As String
            Dim dt1 As DataTable
            Dim drNewRow, R1 As DataRow
            Dim ds As DataSet

            Try
                ds = New DataSet()

                strSql = "SELECT C.Model_Desc as Model" & Environment.NewLine
                strSql &= ", IF(NI_Prod_Desc is null, '', NI_Prod_Desc) as 'Product Description'" & Environment.NewLine
                strSql &= ", A.Device_Sn as 'S/N'" & Environment.NewLine
                strSql &= ", IF(D.Warranty = 1, 'Yes', 'No') as 'Manuf Wrty' " & Environment.NewLine
                strSql &= ", IF(E.DCode_LDesc is null, '', E.Dcode_LDesc ) as 'Inbound Cosm Grade'" & Environment.NewLine
                strSql &= ", A.device_dateRec as 'Receipt Date', B.Workstation as 'Wip Location'" & Environment.NewLine
                strSql &= ", D.ClaimNo as 'RMA', D.ShipTo_Name as 'Ship to Name', D.Address1 as Address1, D.Address2 as Address2" & Environment.NewLine
                strSql &= ", D.City as City, D.State_ShortName as 'State', D.ZipCode as 'Zip', D.Cntry_name as 'Country', D.Email" & Environment.NewLine
                strSql &= ", D.PSSI_CurrentStatus as 'Status' , D.DefectType1 as 'Defect Type 1', D.DefectType2 as 'Defect Type 2'" & Environment.NewLine
                strSql &= ", D.ErrDesc_ItemSKU as 'Err Desc', D.SpecialNotes as 'Special Notes', D.ServiceLevel as 'Service Level'" & Environment.NewLine
                strSql &= ", D.RepairType as 'Rep Type'" & Environment.NewLine
                strSql &= ", IF(D.NI_DataSwitch = 1, 'End User', 'Bulk') as 'Work order Type'" & Environment.NewLine
                strSql &= ", D.Cust2PSSI_trackNo as 'Inbound Tracking #'" & Environment.NewLine
                strSql &= "FROM tdevice A" & Environment.NewLine
                strSql &= "INNER JOIN tcellopt B ON A.Device_ID = B.Device_ID" & Environment.NewLine
                strSql &= "INNER JOIN tmodel C ON A.Model_ID = C.Model_ID" & Environment.NewLine
                strSql &= "INNER JOIN extendedwarranty D ON A.Wo_ID = D.WO_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail E ON B.InBoundCosmGrade = E.DCode_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN ni_products F ON D.Prod_Code = F.NI_Prod_ID " & Environment.NewLine
                strSql &= "WHERE A.Loc_ID = " & NI.LOCID & " AND A.Device_DateShip is null" & Environment.NewLine
                strSql &= " UNION" & Environment.NewLine
                strSql &= "SELECT C.Model_Desc as Model" & Environment.NewLine
                strSql &= ", IF(NI_Prod_Desc is null, '', NI_Prod_Desc) as 'Product Description'" & Environment.NewLine
                strSql &= ", A.Serial as 'S/N'" & Environment.NewLine
                strSql &= ", IF(D.Warranty = 1, 'Yes', 'No') as 'Manuf Wrty' " & Environment.NewLine
                strSql &= ", '' as 'Inbound Cosm Grade' " & Environment.NewLine
                strSql &= ", A.Date_received as 'Receipt Date', 'WAREHOUSE' as 'Wip Location'" & Environment.NewLine
                strSql &= ", D.ClaimNo as 'RMA', D.ShipTo_Name as 'Ship to Name', D.Address1 as Address1, D.Address2 as Address2" & Environment.NewLine
                strSql &= ", D.City as City, D.State_ShortName as 'State', D.ZipCode as 'Zip', D.Cntry_name as 'Country', D.Email" & Environment.NewLine
                strSql &= ", D.PSSI_CurrentStatus as 'Status' , D.DefectType1 as 'Defect Type 1', D.DefectType2 as 'Defect Type 2'" & Environment.NewLine
                strSql &= ", D.ErrDesc_ItemSKU as 'Err Desc', D.SpecialNotes as 'Special Notes', D.ServiceLevel as 'Service Level'" & Environment.NewLine
                strSql &= ", D.RepairType as 'Rep Type'" & Environment.NewLine
                strSql &= ", IF(D.NI_DataSwitch = 1, 'End User', 'Bulk') as 'Work order Type'" & Environment.NewLine
                strSql &= ", D.Cust2PSSI_trackNo as 'Inbound Tracking #'" & Environment.NewLine
                strSql &= "FROM warehouse.warehouse_items A" & Environment.NewLine
                strSql &= "INNER JOIN warehouse.warehouse_receipt B ON A.WR_ID = B.WR_ID" & Environment.NewLine
                strSql &= "INNER JOIN tmodel C ON A.Model_ID = C.Model_ID" & Environment.NewLine
                strSql &= "INNER JOIN extendedwarranty D ON B.WO_ID = D.WO_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN ni_products F ON D.Prod_Code = F.NI_Prod_ID " & Environment.NewLine
                strSql &= "WHERE B.Loc_ID = " & NI.LOCID & " AND A.Device_ID = 0 AND A.SODetailsID = 0 AND A.DevConditionID = 3855 " & Environment.NewLine

                dt1 = Me._objDataProc.GetDataTable(strSql) : dt1.TableName = "Details"
                ds.Tables.Add(dt1)

                dt1 = Nothing : dt1 = New DataTable("Summary")

                If booSummary Then
                    '****************************************************************
                    'SHOULD GET THIS FROM DATABASE BUT DON'T WANT TO BLOCK PRODUCTION
                    '****************************************************************
                    dt1.Columns.Add("Model", System.Type.GetType("System.String", False, True))
                    dt1.Columns.Add("Wip Location", System.Type.GetType("System.String", False, True))
                    dt1.Columns.Add("Qty", System.Type.GetType("System.Int32", False, True))

                    For Each R1 In ds.Tables("Details").Rows
                        If dt1.Select("Model = '" & R1("Model").ToString & "' AND [Wip Location] = '" & R1("Wip Location").ToString & "'").Length = 0 Then
                            drNewRow = dt1.NewRow
                            drNewRow("Model") = R1("Model").ToString
                            drNewRow("Wip Location") = R1("Wip Location").ToString
                            drNewRow("Qty") = ds.Tables("Details").Select("Model = '" & R1("Model").ToString & "' AND [Wip Location] = '" & R1("Wip Location").ToString & "'").Length
                            dt1.Rows.Add(drNewRow)
                        End If
                    Next R1
                    dt1.AcceptChanges()
                    '****************************************************************
                End If

                ds.Tables.Add(dt1) : ds.AcceptChanges()

                Return ds

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt1)
                Generic.DisposeDS(ds)
            End Try
        End Function

        '**********************************************************************************
        Public Function CreateWIPReport(ByVal iLocID As Integer, ByVal strRptName As String) As Integer
            Dim ds As DataSet
            Dim objExcelRpt As ExcelReports

            Try
                ds = Me.GetWIPData(False)

                If ds.Tables("Details").Rows.Count > 0 Then
                    objExcelRpt = New ExcelReports(False)
                    objExcelRpt.RunSimpleExcelFormat(ds.Tables("Details"), strRptName, New String() {"C", "H", Generic.CalExcelColLetter(ds.Tables("Details").Columns.Count)}, )
                    '*************************
                End If

                Return ds.Tables("Details").Rows.Count

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDS(ds)
            End Try
        End Function

        '**********************************************************************************
        Public Function CreateReceiptReport(ByVal iLocID As Integer, ByVal strRptName As String, ByVal strDateStart As String, ByVal strDateEnd As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim objExcelRpt As ExcelReports

            Try
                strSql = "SELECT C.Model_Desc as Model" & Environment.NewLine
                strSql &= ", IF(NI_Prod_Desc is null, '', NI_Prod_Desc) as 'Product Description'" & Environment.NewLine
                strSql &= ", A.Device_Sn as 'S/N'" & Environment.NewLine
                strSql &= ", IF(D.Warranty = 1, 'Yes', 'No') as 'Manuf Wrty' " & Environment.NewLine
                strSql &= ", DATE_FORMAT(A.device_dateRec, '%m/%d/%Y') as 'Receipt Date', B.Workstation as 'Wip Location'" & Environment.NewLine
                strSql &= ", D.ClaimNo as 'RMA', D.ShipTo_Name as 'Ship to Name', D.Address1 as Address1, D.Address2 as Address2" & Environment.NewLine
                strSql &= ", D.City as City, D.State_ShortName as 'State', D.ZipCode as 'Zip', D.Cntry_name as 'Country', D.Email" & Environment.NewLine
                strSql &= ", D.PSSI_CurrentStatus as 'Status' , D.DefectType1 as 'Defect Type 1', D.DefectType2 as 'Defect Type 2'" & Environment.NewLine
                strSql &= ", D.ErrDesc_ItemSKU as 'Err Desc', D.SpecialNotes as 'Special Notes', D.ServiceLevel as 'Service Level'" & Environment.NewLine
                strSql &= ", D.RepairType as 'Rep Type'" & Environment.NewLine
                strSql &= ", IF(D.NI_DataSwitch = 1, 'End User', 'Bulk') as 'Work order Type'" & Environment.NewLine
                strSql &= ", D.Cust2PSSI_trackNo as 'Inbound Tracking #'" & Environment.NewLine
                strSql &= ", SoftKeyCode as 'Software KeyCode'" & Environment.NewLine
                strSql &= "FROM tdevice A" & Environment.NewLine
                strSql &= "INNER JOIN tcellopt B ON A.Device_ID = B.Device_ID" & Environment.NewLine
                strSql &= "INNER JOIN tmodel C ON A.Model_ID = C.Model_ID" & Environment.NewLine
                strSql &= "INNER JOIN extendedwarranty D ON A.Wo_ID = D.WO_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN ni_products E ON D.Prod_Code = E.NI_Prod_ID " & Environment.NewLine
                strSql &= "WHERE A.Loc_ID = " & NI.LOCID & " AND A.Device_DateRec BETWEEN '" & strDateStart & " 00:00:00' AND '" & strDateEnd & " 23:59:59'" & Environment.NewLine
                strSql &= " UNION" & Environment.NewLine
                strSql &= "SELECT C.Model_Desc as Model" & Environment.NewLine
                strSql &= ", IF(NI_Prod_Desc is null, '', NI_Prod_Desc) as 'Product Description'" & Environment.NewLine
                strSql &= ", A.Serial as 'S/N' " & Environment.NewLine
                strSql &= ", IF(D.Warranty = 1, 'Yes', 'No') as 'Manuf Wrty' " & Environment.NewLine
                strSql &= ", DATE_FORMAT(A.Date_received, '%m/%d/%Y') as 'Receipt Date', 'WAREHOUSE' as 'Wip Location'" & Environment.NewLine
                strSql &= ", D.ClaimNo as 'RMA', D.ShipTo_Name as 'Ship to Name', D.Address1 as Address1, D.Address2 as Address2" & Environment.NewLine
                strSql &= ", D.City as City, D.State_ShortName as 'State', D.ZipCode as 'Zip', D.Cntry_name as 'Country', D.Email" & Environment.NewLine
                strSql &= ", D.PSSI_CurrentStatus as 'Status' , D.DefectType1 as 'Defect Type 1', D.DefectType2 as 'Defect Type 2'" & Environment.NewLine
                strSql &= ", D.ErrDesc_ItemSKU as 'Err Desc', D.SpecialNotes as 'Special Notes', D.ServiceLevel as 'Service Level'" & Environment.NewLine
                strSql &= ", D.RepairType as 'Rep Type'" & Environment.NewLine
                strSql &= ", IF(D.NI_DataSwitch = 1, 'End User', 'Bulk') as 'Work order Type'" & Environment.NewLine
                strSql &= ", D.Cust2PSSI_trackNo as 'Inbound Tracking #'" & Environment.NewLine
                strSql &= ", A.SoftKeyCode as 'Software KeyCode'" & Environment.NewLine
                strSql &= "FROM warehouse.warehouse_items A" & Environment.NewLine
                strSql &= "INNER JOIN warehouse.warehouse_receipt B ON A.WR_ID = B.WR_ID" & Environment.NewLine
                strSql &= "INNER JOIN tmodel C ON A.Model_ID = C.Model_ID" & Environment.NewLine
                strSql &= "INNER JOIN extendedwarranty D ON B.WO_ID = D.WO_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN ni_products E ON D.Prod_Code = E.NI_Prod_ID " & Environment.NewLine
                strSql &= "WHERE B.Loc_ID = " & NI.LOCID & " AND A.DevConditionID = 3855 " & Environment.NewLine
                strSql &= "AND Date_Received BETWEEN '" & strDateStart & "' AND '" & strDateEnd & "' AND A.Device_ID = 0 "
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    objExcelRpt = New ExcelReports(False)
                    objExcelRpt.RunSimpleExcelFormat(dt, strRptName, New String() {"C", "G", Generic.CalExcelColLetter(dt.Columns.Count)}, )
                    '*************************
                End If

                Return dt.Rows.Count

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '**********************************************************************************
        Public Function CreateShipmentReport(ByVal iCustID As Integer, ByVal strRptName As String, ByVal strDateStart As String, ByVal strDateEnd As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim objExcelRpt As ExcelReports

            Try
                strSql = "SELECT A.PONumber as 'PO #', A.CustomerOrderNumber as 'Order #'" & Environment.NewLine
                strSql &= ", concat(A.CustomerFirstName, ' ', A.CustomerLastName) as 'Ship to Name'" & Environment.NewLine
                strSql &= ", A.CustomerAddress1 as 'Address1', A.CustomerAddress2 as 'Address2', A.CustomerAddress3 as 'Address3'" & Environment.NewLine
                strSql &= ", A.CustomerCity as 'City', A.CustomerState as 'State', A.CustomerPostalCode as 'Postal Code'" & Environment.NewLine
                strSql &= ", A.CustomerCountry as 'Country', A.CustomerPhone as 'Phone', A.CustomerEmail as 'Email'" & Environment.NewLine
                strSql &= ", A.CustomerOrderDate as 'Order Date', A.ShipDate, A.InboundTrackingNumber as 'Inbound Track #'" & Environment.NewLine
                strSql &= ", B.LineItemNumber as 'Line #', B.ItemCode as 'Item Code', B.ProductName as 'Product Description'" & Environment.NewLine
                strSql &= ", E.Serial as 'S/N' " & Environment.NewLine
                strSql &= ", IF(C.Dcode_L2desc is null, '', C.Dcode_LDesc) as 'Device Condition'" & Environment.NewLine
                strSql &= ", IF(D.Dcode_Ldesc is null, '', D.Dcode_Ldesc) as 'Cosmetic Grade'" & Environment.NewLine
                strSql &= ", A.ShipCarrier as 'Ship Carrier', A.OutboundTrackingNumber as 'Outbound Tracking #' " & Environment.NewLine
                strSql &= ", '                   ' as 'OrderType' " & Environment.NewLine
                strSql &= " FROM saleorders.soheader A" & Environment.NewLine
                strSql &= " INNER JOIN saleorders.sodetails B ON A.soheaderid = B.soheaderid" & Environment.NewLine
                strSql &= " INNER JOIN warehouse.warehouse_items E ON B.sodetailsID = E.sodetailsID" & Environment.NewLine
                strSql &= " LEFT OUTER JOIN production.lcodesdetail C on E.devconditionID = C.dcode_id" & Environment.NewLine
                strSql &= " LEFT OUTER JOIN production.lcodesdetail D on E.cosmgradeid = D.dcode_ID" & Environment.NewLine
                strSql &= " WHERE A.CUST_ID = " & iCustID & " And A.InvalidOrder = 0 AND OrderStatusID = 1 " & Environment.NewLine
                strSql &= " AND A.ShipDate BETWEEN '" & strDateStart & "' AND '" & strDateEnd & "'" & Environment.NewLine
                'strSql &= "ORDER BY A.PONumber "
                strSql &= " UNION ALL "
                strSql &= " SELECT A.PONumber as 'PO #', A.CustomerOrderNumber as 'Order #'" & Environment.NewLine
                strSql &= ", concat(A.CustomerFirstName, ' ', A.CustomerLastName) as 'Ship to Name'" & Environment.NewLine
                strSql &= ", A.CustomerAddress1 as 'Address1', A.CustomerAddress2 as 'Address2', A.CustomerAddress3 as 'Address3'" & Environment.NewLine
                strSql &= ", A.CustomerCity as 'City', A.CustomerState as 'State', A.CustomerPostalCode as 'Postal Code'" & Environment.NewLine
                strSql &= ", A.CustomerCountry as 'Country', A.CustomerPhone as 'Phone', A.CustomerEmail as 'Email'" & Environment.NewLine
                strSql &= ", A.CustomerOrderDate as 'Order Date', A.ShipDate, A.InboundTrackingNumber as 'Inbound Track #'" & Environment.NewLine
                strSql &= ", B.LineItemNumber as 'Line #', B.ItemCode as 'Item Code', B.ProductName as 'Product Description'" & Environment.NewLine
                strSql &= ", '' as 'S/N'" & Environment.NewLine
                strSql &= ", '' as 'Device Condition'" & Environment.NewLine
                strSql &= ", '' as 'Cosmetic Grade'" & Environment.NewLine
                strSql &= ", A.ShipCarrier as 'Ship Carrier', A.OutboundTrackingNumber as 'Outbound Tracking #'" & Environment.NewLine
                strSql &= ", A.OrderType as 'OrderType' " & Environment.NewLine
                strSql &= " FROM saleorders.soheader A" & Environment.NewLine
                strSql &= " INNER JOIN saleorders.sodetails B ON A.soheaderid = B.soheaderid" & Environment.NewLine
                strSql &= " WHERE A.CUST_ID = " & iCustID & " And A.InvalidOrder = 0 AND OrderStatusID = 1" & Environment.NewLine
                strSql &= " AND A.ShipDate BETWEEN '" & strDateStart & "' AND '" & strDateEnd & "' AND A.OrderType='SendSparePart'" & Environment.NewLine
                strSql &= " ORDER BY 'PO #';"

                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    objExcelRpt = New ExcelReports(False)
                    objExcelRpt.RunSimpleExcelFormat(dt, strRptName, New String() {"A", "B", "N", "O", Generic.CalExcelColLetter(dt.Columns.Count)}, )
                    '*************************
                End If

                Return dt.Rows.Count

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '**********************************************************************************
        Public Function CreateProdCompletedReport(ByVal iLOCID As Integer, ByVal strRptName As String, ByVal strDateStart As String, ByVal strDateEnd As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim objExcelRpt As ExcelReports

            Try
                strSql = "SELECT C.Model_Desc as Model" & Environment.NewLine
                strSql &= ", IF(NI_Prod_Desc is null, '', NI_Prod_Desc) as 'Product Description'" & Environment.NewLine
                strSql &= ", A.Device_Sn as 'S/N'" & Environment.NewLine
                strSql &= ", IF(D.Warranty = 1, 'Yes', 'No') as 'Manuf Wrty' " & Environment.NewLine
                strSql &= ", IF(A.Device_PSSWrty = 1, 'Yes', 'No') as 'PSS Wrty' " & Environment.NewLine
                strSql &= ", A.device_dateRec as 'Receipt Date', A.Device_Dateship as 'Prod Completed Date'" & Environment.NewLine
                strSql &= ", IF(F.Dcode_LDesc is null, '', F.Dcode_LDesc) as 'Inbound Cosm Grade' " & Environment.NewLine
                strSql &= ", IF(G.Dcode_LDesc is null, '', G.Dcode_LDesc) as 'Outbound Cosm Grade' " & Environment.NewLine
                strSql &= ", Pallett_Name as 'Pallet/Box Name'" & Environment.NewLine
                strSql &= ", A.Device_Laborcharge as 'Labor', A.Device_PartCharge as 'Part/Service Charge' " & Environment.NewLine
                strSql &= ", D.ClaimNo as 'RMA', D.ShipTo_Name as 'Ship to Name', D.Address1 as Address1, D.Address2 as Address2" & Environment.NewLine
                strSql &= ", D.City as City, D.State_ShortName as 'State', D.ZipCode as 'Zip', D.Cntry_name as 'Country', D.Email" & Environment.NewLine
                strSql &= ", D.PSSI_CurrentStatus as 'Status' , D.DefectType1 as 'Defect Type 1', D.DefectType2 as 'Defect Type 2'" & Environment.NewLine
                strSql &= ", D.ErrDesc_ItemSKU as 'Err Desc', D.SpecialNotes as 'Special Notes', D.ServiceLevel as 'Service Level'" & Environment.NewLine
                strSql &= ", D.RepairType as 'Rep Type'" & Environment.NewLine
                strSql &= ", IF(D.NI_DataSwitch = 1, 'End User', 'Bulk') as 'Work order Type'" & Environment.NewLine
                strSql &= ", D.Cust2PSSI_trackNo as 'Inbound Tracking #'" & Environment.NewLine
                strSql &= "FROM tdevice A" & Environment.NewLine
                strSql &= "INNER JOIN tcellopt B ON A.Device_ID = B.Device_ID" & Environment.NewLine
                strSql &= "INNER JOIN tmodel C ON A.Model_ID = C.Model_ID" & Environment.NewLine
                strSql &= "INNER JOIN extendedwarranty D ON A.Wo_ID = D.WO_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN ni_products E ON D.Prod_Code = E.NI_Prod_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail F ON B.InBoundCosmGrade = F.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail G ON B.OutBoundCosmGradeID = G.Dcode_ID " & Environment.NewLine
                strSql &= "INNER JOIN tpallett H ON A.Pallett_ID = H.Pallett_ID" & Environment.NewLine
                strSql &= "WHERE A.Loc_ID = " & NI.LOCID & " AND A.Device_DateShip BETWEEN '" & strDateStart & " 00:00:00' AND '" & strDateEnd & " 23:59:59'" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    objExcelRpt = New ExcelReports(False)
                    objExcelRpt.RunSimpleExcelFormat(dt, strRptName, New String() {"M", Generic.CalExcelColLetter(dt.Columns.Count)}, )
                    '*************************
                End If

                Return dt.Rows.Count

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '**********************************************************************************
        Public Function CreateInventoryReport(ByVal iCUSTOMERID As Integer, ByVal strRptName As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim objExcelRpt As ExcelReports

            Try
                strSql = "SELECT C.Model_Desc as Model" & Environment.NewLine
                strSql &= ", IF(H.cust_model_number is null, '', H.cust_model_number) as 'Part #' " & Environment.NewLine
                strSql &= ", IF(NI_Prod_Desc is null, '', NI_Prod_Desc) as 'Product Description'" & Environment.NewLine
                strSql &= ", A.Serial as 'S/N' " & Environment.NewLine
                strSql &= ", IF(D.Warranty = 1, 'Yes', 'No') as 'Manuf Wrty' " & Environment.NewLine
                strSql &= ", A.Date_received as 'Receipt Date'" & Environment.NewLine
                strSql &= ", IF(F.Dcode_L2desc is null, '', F.Dcode_LDesc) as 'Device Condition'" & Environment.NewLine
                strSql &= ", IF(G.Dcode_Ldesc is null, '', G.Dcode_Ldesc) as 'Cosmetic Grade'" & Environment.NewLine
                strSql &= ", D.ClaimNo as 'RMA'" & Environment.NewLine
                'strSql &= ", D.ShipTo_Name as 'Ship to Name', D.Address1 as Address1, D.Address2 as Address2" & Environment.NewLine
                'strSql &= ", D.City as City, D.State_ShortName as 'State', D.ZipCode as 'Zip', D.Cntry_name as 'Country'" & Environment.NewLine
                strSql &= ", D.PSSI_CurrentStatus as 'Status' , D.DefectType1 as 'Defect Type 1', D.DefectType2 as 'Defect Type 2'" & Environment.NewLine
                strSql &= ", D.ErrDesc_ItemSKU as 'Err Desc', D.SpecialNotes as 'Special Notes', D.ServiceLevel as 'Service Level'" & Environment.NewLine
                strSql &= ", D.RepairType as 'Rep Type'" & Environment.NewLine
                strSql &= ", IF(D.NI_DataSwitch = 1, 'End User', 'Bulk') as 'Work order Type'" & Environment.NewLine
                strSql &= ", D.Cust2PSSI_trackNo as 'Inbound Tracking #'" & Environment.NewLine
                strSql &= ", A.SoftKeyCode as 'Software KeyCode'" & Environment.NewLine
                strSql &= "FROM warehouse.warehouse_items A" & Environment.NewLine
                strSql &= "INNER JOIN warehouse.warehouse_receipt B ON A.WR_ID = B.WR_ID" & Environment.NewLine
                strSql &= "INNER JOIN tmodel C ON A.Model_ID = C.Model_ID" & Environment.NewLine
                strSql &= "INNER JOIN extendedwarranty D ON B.WO_ID = D.WO_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN ni_products E ON D.Prod_Code = E.NI_Prod_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN production.lcodesdetail F on A.devconditionID = F.dcode_id" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN production.lcodesdetail G on A.cosmgradeid = G.dcode_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN production.tcustmodel_pssmodel_map H on C.Model_ID = H.Model_ID AND H.Cust_ID = " & iCUSTOMERID & Environment.NewLine
                strSql &= "WHERE B.Loc_ID = " & NI.LOCID & " AND A.DevConditionID <> 3855 " & Environment.NewLine
                strSql &= "AND SODetailsID = 0"
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    objExcelRpt = New ExcelReports(False)
                    objExcelRpt.RunSimpleExcelFormat(dt, strRptName, New String() {"D", "I", Generic.CalExcelColLetter(dt.Columns.Count)}, )
                    '*************************
                End If

                Return dt.Rows.Count

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function


        '**********************************************************************************
        Public Function CreatePreTestReport(ByVal iLocID As Integer, ByVal strRptName As String, ByVal strDateStart As String, ByVal strDateEnd As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim objExcelRpt As ExcelReports

            Try
                strSql = "select A.Device_SN as 'SN', C.Model_desc as 'Model',B.Pretest_WKDT as 'Pretest_Date'" & Environment.NewLine
                strSql &= " ,D.Dcode_Ldesc as 'PreTest Result',F.Dcode_Ldesc 'Outbounding Grade',A.Device_ID,D.Dcode_id" & Environment.NewLine
                strSql &= " from tdevice A" & Environment.NewLine
                strSql &= " inner join tmodel C on A.Model_ID=C.Model_ID" & Environment.NewLine
                strSql &= " inner join tpretest_data B on A.device_ID=B.device_ID" & Environment.NewLine
                strSql &= " inner join lcodesdetail D on B.pttf=D.Dcode_id" & Environment.NewLine
                strSql &= " inner join tcellopt E on A.device_ID=E.device_ID" & Environment.NewLine
                strSql &= " left join lcodesdetail F on E.OutBoundCosmGradeID=F.Dcode_id" & Environment.NewLine
                strSql &= "  where A.loc_ID=" & iLocID & " and B.Pretest_WKDT between '" & strDateStart & " 00:00:00' AND '" & strDateEnd & " 23:59:59'" & Environment.NewLine
                strSql &= " order by B.Pretest_WKDT,A.Device_SN"

                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    objExcelRpt = New ExcelReports(False)
                    objExcelRpt.RunSimpleExcelFormat(dt, strRptName, New String() {"A", "B", "D", "E"}, )
                    '*************************
                End If

                Return dt.Rows.Count

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '**********************************************************************************
        Public Function CreateAQLTestReport(ByVal iLocID As Integer, ByVal strRptName As String, ByVal strDateStart As String, ByVal strDateEnd As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim objExcelRpt As ExcelReports

            Try
            
                strSql = "select A.Device_SN as 'SN', C.Model_desc as 'Model',B.QC_WorkDate as 'Test Date'" & Environment.NewLine
                strSql &= " ,E.QCType as 'QC Type',F.QCResult as 'QC Result',H.Dcode_Ldesc 'Outbounding Grade',A.Device_ID" & Environment.NewLine
                strSql &= " from tdevice A" & Environment.NewLine
                strSql &= " inner join tmodel C on A.Model_ID=C.Model_ID" & Environment.NewLine
                strSql &= " inner join tqc B on A.device_ID=B.device_ID" & Environment.NewLine
                strSql &= " Inner join lqctype E on B.QCType_ID=E.QCType_ID" & Environment.NewLine
                strSql &= " inner join lqcResult F on B.QCResult_ID=F.QCResult_ID" & Environment.NewLine
                strSql &= " inner join tcellopt G on A.device_ID=G.device_ID" & Environment.NewLine
                strSql &= " left join lcodesdetail H on G.OutBoundCosmGradeID=H.Dcode_id" & Environment.NewLine
                strSql &= "  where A.loc_ID=" & iLocID & " and B.QC_WorkDate  between  '" & strDateStart & " 00:00:00' AND '" & strDateEnd & " 23:59:59'" & Environment.NewLine
                strSql &= "  order by A.Device_ID,B.QC_Iteration;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    objExcelRpt = New ExcelReports(False)
                    objExcelRpt.RunSimpleExcelFormat(dt, strRptName, New String() {"A", "B", "D", "E", "F"}, )
                    '*************************
                End If

                Return dt.Rows.Count

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '**********************************************************************************
        Public Function CreateNIInvoiceDetailReport(ByVal iCust_ID As Integer, _
                                                    ByVal iLocID As Integer, _
                                                    ByVal strRptName As String, _
                                                    ByVal strDateStart As String, _
                                                    ByVal strDateEnd As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim objExcelRpt As ExcelReports

            Try

                strSql = "select A.Device_SN as 'SN', C.Model_desc as 'Model',B.QC_WorkDate as 'Test Date'" & Environment.NewLine
                strSql &= " ,E.QCType as 'QC Type',F.QCResult as 'QC Result',H.Dcode_Ldesc 'Outbounding Grade',A.Device_ID" & Environment.NewLine
                strSql &= " from tdevice A" & Environment.NewLine
                strSql &= " inner join tmodel C on A.Model_ID=C.Model_ID" & Environment.NewLine
                strSql &= " inner join tqc B on A.device_ID=B.device_ID" & Environment.NewLine
                strSql &= " Inner join lqctype E on B.QCType_ID=E.QCType_ID" & Environment.NewLine
                strSql &= " inner join lqcResult F on B.QCResult_ID=F.QCResult_ID" & Environment.NewLine
                strSql &= " inner join tcellopt G on A.device_ID=G.device_ID" & Environment.NewLine
                strSql &= " left join lcodesdetail H on G.OutBoundCosmGradeID=H.Dcode_id" & Environment.NewLine
                strSql &= " where A.loc_ID=" & iLocID & " and B.QC_WorkDate  between  '" & strDateStart & " 00:00:00' AND '" & strDateEnd & " 23:59:59'" & Environment.NewLine
                strSql &= " order by A.Device_ID,B.QC_Iteration;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    objExcelRpt = New ExcelReports(False)
                    objExcelRpt.RunSimpleExcelFormat(dt, strRptName, New String() {"A", "B", "D", "E", "F"}, )
                    '*************************
                End If

                Return dt.Rows.Count

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '**********************************************************************************
        Public Function CreateInvoiceReport(ByVal iCustID As Integer, _
                                            ByVal iLocID As Integer, _
                                            ByVal strRptName As String, _
                                            ByVal strDateStart As String, _
                                            ByVal strDateEnd As String, _
                                            ByVal bSummaryDetails As Boolean) As Integer
            Dim strSql As String = ""
            Dim ds As New DataSet()
            Dim ds2 As New DataSet()
            Dim dt, dtRepairedFinal, dtRepairedFinal2, dtWHRecv As DataTable
            Dim dtCTM, dtPackShip, dtTmp As DataTable
            ' Dim dtServices, dtParts As DataTable
            Dim filteredRows() As DataRow
            Dim row, tmpRow As DataRow
            Dim uniqueDeviceIDs As New ArrayList()
            Dim arrKeys As New ArrayList()
            Dim arrColNames As New ArrayList()
            Dim i As Integer = 0, k As Integer = 0
            Dim strCol As String = "", strS As String = "", strTmp As String = ""

            Dim objExcelRpt As ExcelReports
            Dim strStartDTime As String = strDateStart & " 00:00:00"
            Dim strEndDTime As String = strDateEnd & " 23:59:59"
            Dim strHeaderDates As String = Format(CDate(strDateStart), "M/d/yyyy") & " to " & Format(CDate(strDateEnd), "M/d/yyyy")
            Try

                'Repairs==============================================================================================
                strSql = "SELECT IF(H.NI_Prod_Desc IS NULL OR TRIM(H.NI_Prod_Desc)='',F.Model_Desc,H.NI_Prod_Desc) AS 'Model'" & Environment.NewLine
                strSql &= " ,IF(H.NI_SKU IS NULL OR TRIM(H.NI_SKU)='','n/a',H.NI_SKU) AS 'NI SKU'" & Environment.NewLine
                strSql &= " ,IF(H.NI_Prod_ID>0,H.NI_Prod_ID,'n/a') AS 'NI Product ID'" & Environment.NewLine
                strSql &= ",E.ClaimNo AS 'NI Order Number'" & Environment.NewLine
                strSql &= " ,A.device_SN AS 'Serial Number'"
                strSql &= " , 0.0 AS 'SC100', 0.0 AS 'SC200'" & Environment.NewLine
                strSql &= " , IF(B.BillCode_ID= 2324, B.DBill_InvoiceAmt, 0.0) AS 'SC300'" & Environment.NewLine
                strSql &= " , IF(B.BillCode_ID= 2325, B.DBill_InvoiceAmt, 0.0) AS 'SC400'" & Environment.NewLine
                'strSql &= " , 0.0 AS 'SC500'" & Environment.NewLine
                strSql &= " , IF(B.BillCode_ID= 2849, B.DBill_InvoiceAmt, 0.0) AS 'SC500'" & Environment.NewLine
                strSql &= " , IF(B.BillCode_ID= 2323 OR B.BillCode_ID= 2397, B.DBill_InvoiceAmt, 0.0) AS 'SC600'" & Environment.NewLine
                strSql &= " , IF(B.BillCode_ID= 3020, B.DBill_InvoiceAmt, 0.0) AS 'SC700'" & Environment.NewLine
                strSql &= " , IF(B.BillCode_ID= 2823, B.DBill_InvoiceAmt, 0.0) AS 'SC720'" & Environment.NewLine
                strSql &= " , 0.0 AS 'SC800'" & Environment.NewLine
                strSql &= " , IF(B.BillCode_ID>=2933 AND B.BillCode_ID<=2938, B.DBill_InvoiceAmt, 0.0) AS 'SC900'" & Environment.NewLine
                strSql &= " , 0.0 AS 'Subtotal Fees'" & Environment.NewLine
                strSql &= " , F.Model_Desc AS 'PSSI Model'" & Environment.NewLine
                strSql &= " , IF(B.BillCode_ID NOT IN (2323,2397,2324,2325,2849,3020,2823,2933,2934,2935,2936,2937,2938), B.DBill_InvoiceAmt, 0.0) AS 'Other ServicePart'" & Environment.NewLine
                strSql &= " ,IF(A.Device_PSSWrty=1,'Yes','No') AS 'PSS Warranty'" & Environment.NewLine
                strSql &= " ,IF(S.SelfInflicted>0, 'Yes','No') AS 'Customer Abuse',T.DCode_LDesc AS 'Abuse Reason'" & Environment.NewLine
                strSql &= " ,V.DCode_SDesc AS 'Grade In',W.DCode_SDesc AS 'Grade Out'" & Environment.NewLine
                strSql &= " ,IF(E.NI_DataSwitch=1,'End User','Bulk') AS 'OrderType'" & Environment.NewLine
                strSql &= " ,X.BulkORderType_Desc,'' AS 'Defect Class',A.Device_ShipWorkDate" & Environment.NewLine
                strSql &= " ,D.BillType_Ldesc,C.BillCode_Desc" & Environment.NewLine
                strSql &= " , CASE WHEN B.BillCode_ID= 2323 OR B.BillCode_ID= 2397 THEN 'SC600'" & Environment.NewLine
                strSql &= "        WHEN B.BillCode_ID= 2324 THEN 'SC300'" & Environment.NewLine
                strSql &= "        WHEN B.BillCode_ID= 2325 THEN 'SC400'" & Environment.NewLine
                strSql &= "        WHEN B.BillCode_ID= 2849 THEN 'SC500'" & Environment.NewLine
                strSql &= "        WHEN B.BillCode_ID= 3020 THEN 'SC700'" & Environment.NewLine
                strSql &= "        WHEN B.BillCode_ID= 2823 THEN 'SC720'" & Environment.NewLine
                strSql &= "        WHEN B.BillCode_ID>=2933 AND B.BillCode_ID<=2938 THEN 'SC900'" & Environment.NewLine
                strSql &= "        ELSE D.BillType_Ldesc" & Environment.NewLine
                strSql &= "   END AS 'Service Code'" & Environment.NewLine
                strSql &= " , CASE WHEN B.BillCode_ID= 2323 OR B.BillCode_ID= 2397 THEN 'Repair & Refurbish'" & Environment.NewLine
                strSql &= "        WHEN B.BillCode_ID= 2324 THEN 'Customer Abuse'" & Environment.NewLine
                strSql &= "        WHEN B.BillCode_ID= 2325 THEN 'Beyond-Economic-Repair'" & Environment.NewLine
                strSql &= "        WHEN B.BillCode_ID= 2849 THEN 'Power-On, Test, Triage, No-Fault-Found (NFF) and Sort'" & Environment.NewLine
                strSql &= "        WHEN B.BillCode_ID= 3020 THEN 'Scrapping Fee/Each'" & Environment.NewLine
                strSql &= "        WHEN B.BillCode_ID= 2823 THEN 'Reclamation & Parts Harvesting'" & Environment.NewLine
                strSql &= "        WHEN B.BillCode_ID>=2933 AND B.BillCode_ID<=2938 THEN 'Special Projects'" & Environment.NewLine
                strSql &= "        ELSE C.BillCode_Desc" & Environment.NewLine
                strSql &= "   END AS 'Service Desc'" & Environment.NewLine
                strSql &= " ,B.Part_Number,A.device_laborcharge AS 'Labor Charge',B.DBill_InvoiceAmt,'' AS 'DBill_InvoiceAmts',R.tcab_amount,'' AS 'tcab_amounts'" & Environment.NewLine
                strSql &= " ,'' AS 'Defect Class IDs','' AS 'Bill Code IDs','' AS 'DBill_IDs','' AS 'tcab_IDs','' AS 'BillType_IDs'" & Environment.NewLine
                strSql &= " ,A.device_ID,B.DBill_ID,B.BillCode_ID,C.Billtype_ID,F.Model_ID" & Environment.NewLine
                strSql &= " ,E.EW_ID,E.NI_DataSwitch,E.BulkORderType_ID,R.tcab_ID,G.NI_PMM_ID,A.Device_PSSWrty,S.SelfInflicted,S.WI_ID" & Environment.NewLine
                strSql &= " ,U.InBoundCosmGrade,U.OutBoundCosmGradeID" & Environment.NewLine
                strSql &= " FROM tdevice A" & Environment.NewLine
                strSql &= " INNER JOIN tdevicebill B ON A.device_ID=B.device_ID" & Environment.NewLine
                strSql &= " INNER JOIN lbillcodes C ON B.BillCode_ID=C.BillCode_ID" & Environment.NewLine
                strSql &= " INNER JOIN lbilltype D ON C.BillType_ID=D.BillType_ID" & Environment.NewLine
                strSql &= " INNER JOIN extendedwarranty E ON A.WO_ID=E.WO_ID AND E.Cust_ID=" & iCustID & Environment.NewLine
                strSql &= " INNER JOIN tmodel F ON A.model_ID=F.model_ID" & Environment.NewLine
                strSql &= " LEFT JOIN ni_product_pssi_model_map G ON F.model_ID=G.Model_ID" & Environment.NewLine
                strSql &= " LEFT JOIN ni_products H ON G.NI_prod_ID=H.NI_prod_ID" & Environment.NewLine
                strSql &= " LEFT JOIN tcustaggregatebilling R ON B.BillCode_ID=R.BillCode_ID AND R.Cust_ID=" & iCustID & Environment.NewLine
                strSql &= " LEFT JOIN warehouse.warehouse_items S ON A.Device_ID=S.Device_ID AND S.SelfInflicted>0" & Environment.NewLine
                strSql &= " LEFT JOIN lcodesdetail T ON S.SelfInflicted=T.Dcode_ID" & Environment.NewLine
                strSql &= " LEFT JOIN tcellopt U ON A.Device_ID=U.Device_ID" & Environment.NewLine
                strSql &= " LEFT JOIN lcodesdetail V ON V.Dcode_ID=U.InBoundCosmGrade" & Environment.NewLine
                strSql &= " LEFT JOIN lcodesdetail W ON W.Dcode_ID=U.OutBoundCosmGradeID" & Environment.NewLine
                strSql &= " LEFT JOIN ni_bulkordertype X ON E.BulkORderType_ID=X.BulkORderType_ID" & Environment.NewLine
                strSql &= " WHERE A.Loc_ID=" & iLocID & Environment.NewLine
                strSql &= " AND A.Device_ShipWorkDate BETWEEN '" & strStartDTime & "' AND ' " & strEndDTime & "'" & Environment.NewLine
                strSql &= " ORDER BY Model,'Serial Number',C.Billtype_ID,'Service Code';" & Environment.NewLine

                'Get all repaired data
                dt = Me._objDataProc.GetDataTable(strSql)
                'dtServices = dt.Clone : dtParts = dt.Clone
                dtRepairedFinal = dt.Clone

                'get unique Device IDs
                For Each row In dt.Rows
                    If Not uniqueDeviceIDs.Contains(row("device_ID")) Then
                        uniqueDeviceIDs.Add(row("device_ID"))
                    End If
                Next

                ''Services
                'filteredRows = dt.Select("BillType_ID=1")
                'For Each row In filteredRows
                '    dtServices.ImportRow(row)
                'Next
                ''Parts
                'filteredRows = dt.Select("BillType_ID<>1")
                'For Each row In filteredRows
                '    dtParts.ImportRow(row)
                'Next

                For i = 0 To uniqueDeviceIDs.Count - 1
                    filteredRows = dt.Select("Device_ID=" & uniqueDeviceIDs(i))

                    For Each row In filteredRows
                        strCol = "BillType_Ldesc"
                        row(strCol) = getConcatenatedString(filteredRows, strCol)
                        strCol = "BillCode_Desc"
                        row(strCol) = getConcatenatedString(filteredRows, strCol)
                        strCol = "Service Code"
                        row(strCol) = getConcatenatedString(filteredRows, strCol)
                        strCol = "Service Desc"
                        row(strCol) = getConcatenatedString(filteredRows, strCol)
                        strCol = "SC300"
                        row(strCol) = getRowSum(filteredRows, strCol)
                        strCol = "SC400"
                        row(strCol) = getRowSum(filteredRows, strCol)
                        strCol = "SC500"
                        row(strCol) = getRowSum(filteredRows, strCol)
                        strCol = "SC600"
                        row(strCol) = getRowSum(filteredRows, strCol)
                        strCol = "SC700"
                        row(strCol) = getRowSum(filteredRows, strCol)
                        strCol = "SC720"
                        row(strCol) = getRowSum(filteredRows, strCol)
                        strCol = "SC900"
                        row(strCol) = getRowSum(filteredRows, strCol)
                        strCol = "Other ServicePart"
                        row(strCol) = getRowSum(filteredRows, strCol)
                        strCol = "Part_Number"
                        row(strCol) = getConcatenatedString(filteredRows, strCol)
                        strCol = "DBill_InvoiceAmt" : strS = ""
                        row(strCol) = getRowSum(filteredRows, strCol, strS)
                        row("DBill_InvoiceAmts") = strS
                        strCol = "tcab_amount" : strS = ""
                        row(strCol) = getRowSum(filteredRows, strCol, strS)
                        row("tcab_amounts") = strS
                        strCol = "BillCode_ID"
                        row("Bill Code IDs") = getConcatenatedString(filteredRows, strCol)
                        strCol = "DBill_ID"
                        row("DBill_IDs") = getConcatenatedString(filteredRows, strCol)
                        strCol = "tcab_ID"
                        row("tcab_IDs") = getConcatenatedString(filteredRows, strCol)
                        strCol = "Billtype_ID"
                        row("Billtype_IDs") = getConcatenatedString(filteredRows, strCol)

                        row("Defect Class") = getDefectClass(row("device_ID"))
                        '
                        row.AcceptChanges()
                        dtRepairedFinal.ImportRow(row)

                        Exit For
                    Next
                Next

                'remove unwanted cols
                dtRepairedFinal.Columns.Remove("DBill_ID") : dtRepairedFinal.Columns.Remove("BillCode_ID")
                dtRepairedFinal.Columns.Remove("tcab_ID") : dtRepairedFinal.Columns.Remove("Billtype_ID")
                dtRepairedFinal.TableName = "Repairs"

                If bSummaryDetails Then
                    dtRepairedFinal.Columns.Remove("SC100") : dtRepairedFinal.Columns.Remove("SC200")
                    dtRepairedFinal.Columns.Remove("SC800")
                End If

                ds.Tables.Add(dtRepairedFinal)

                ' Warehouse Receiving=================================================================================
                strSql = "SELECT IF(Q.NI_Prod_Desc IS NULL OR TRIM(Q.NI_Prod_Desc)='',F.Model_Desc,Q.NI_Prod_Desc) AS 'Model'" & Environment.NewLine
                strSql &= " ,IF(Q.NI_SKU IS NULL OR TRIM(Q.NI_SKU)='','n/a',Q.NI_SKU) AS 'NI SKU'" & Environment.NewLine
                strSql &= " ,IF(Q.NI_Prod_ID>0,Q.NI_Prod_ID,'n/a') AS 'NI Product ID'" & Environment.NewLine
                strSql &= " ,E.ClaimNo AS 'NI Order Number'" & Environment.NewLine
                strSql &= " ,B.Serial AS 'Serial Number'" & Environment.NewLine
                strSql &= " ,B.Labor_Charge AS 'SC200'" & Environment.NewLine
                strSql &= " ,F.Model_Desc AS 'PSS Model'" & Environment.NewLine
                strSql &= " ,C.BillCode_Desc,D.BillType_LDesc,W.DCode_SDesc AS 'Condition'" & Environment.NewLine
                strSql &= " ,IF(E.NI_DataSwitch=1,'End User','Bulk') AS 'OrderType',IF(B.DOA=1,'Yes','No') AS 'DOA', B.Date_Received,R.tcab_amount" & Environment.NewLine
                strSql &= " ,A.WR_ID,B.WI_ID,E.EW_ID,E.WO_ID,B.BillCode_ID,D.BillType_ID,B.DevConditionID" & Environment.NewLine
                strSql &= " FROM warehouse.warehouse_receipt A" & Environment.NewLine
                strSql &= " INNER JOIN warehouse.warehouse_items B ON A.WR_ID=B.WR_ID" & Environment.NewLine
                strSql &= " INNER JOIN lbillcodes C ON B.BillCode_ID=C.BillCode_ID" & Environment.NewLine
                strSql &= " INNER JOIN lbilltype D ON C.BillType_ID=D.BillType_ID" & Environment.NewLine
                strSql &= " INNER JOIN extendedwarranty E ON A.WO_ID=E.WO_ID AND E.Cust_ID=" & iCustID & Environment.NewLine
                strSql &= " INNER JOIN tmodel F ON B.Model_ID=F.Model_ID" & Environment.NewLine
                strSql &= " LEFT JOIN ni_product_pssi_model_map P ON F.model_ID=P.Model_ID" & Environment.NewLine
                strSql &= " LEFT JOIN ni_products Q ON P.NI_prod_ID=Q.NI_prod_ID" & Environment.NewLine
                strSql &= " LEFT JOIN tcustaggregatebilling R ON B.BillCode_ID=R.BillCode_ID AND R.Cust_ID=" & iCustID & Environment.NewLine
                strSql &= " LEFT JOIN lcodesdetail W ON W.Dcode_ID=B.DevConditionID" & Environment.NewLine
                strSql &= " WHERE A.CUST_ID=" & iCustID & " AND B.DevConditionID <> 3857" & Environment.NewLine
                strSql &= " AND B.Date_Received BETWEEN '" & strStartDTime & "' AND ' " & strEndDTime & "'" & Environment.NewLine
                strSql &= " ORDER BY  Model,'Serial Number';" & Environment.NewLine

                dtWHRecv = Me._objDataProc.GetDataTable(strSql)
                dtWHRecv.TableName = "Receiving"

                ds.Tables.Add(dtWHRecv)

                'Call-Tag Mailing 
                strSql = "SELECT IF(Q.NI_Prod_Desc IS NULL OR TRIM(Q.NI_Prod_Desc)='','n/a',Q.NI_Prod_Desc) AS 'Model'" & Environment.NewLine
                strSql &= " ,IF(Q.NI_SKU IS NULL OR TRIM(Q.NI_SKU)='','n/a',Q.NI_SKU) AS 'NI SKU'" & Environment.NewLine
                strSql &= " ,IF(A.Prod_Code IS NULL OR TRIM(A.Prod_Code)='','n/a',A.Prod_Code) AS 'NI Product ID'" & Environment.NewLine
                strSql &= " ,A.ClaimNo AS 'NI Order Number'" & Environment.NewLine
                strSql &= " ,IF(A.SerialNo IS NULL OR TRIM(A.SerialNo)='','n/a',A.SerialNo) AS 'Serial Number'" & Environment.NewLine
                strSql &= " ,A.LabelCharge AS 'SC100'" & Environment.NewLine
                strSql &= " ,C.BillCode_Desc,D.BillType_LDesc,A.Cust2PSSI_TrackNo,A.TrackCreatedDateTime" & Environment.NewLine
                strSql &= " ,A.RepairType,A.ShipTo_Name,A.Address1,A.Address2,A.City,A.State_ShortName AS 'State'" & Environment.NewLine
                strSql &= " , A.ZipCode,A.Tel,A.Email" & Environment.NewLine
                strSql &= " ,IF(A.Warranty=1,'Yes','No') AS 'NI Warranty',IF(A.NI_DataSwitch=1,'End User','Bulk') AS 'OrderType'" & Environment.NewLine
                strSql &= " ,R.tcab_amount" & Environment.NewLine
                strSql &= " ,A.EW_ID,A.WO_ID,C.BillCode_ID,D.BillType_ID" & Environment.NewLine
                strSql &= " FROM extendedwarranty A" & Environment.NewLine
                strSql &= " INNER JOIN lbillcodes C ON A.BillCode_ID=C.BillCode_ID" & Environment.NewLine
                strSql &= " INNER JOIN lbilltype D ON C.BillType_ID=D.BillType_ID" & Environment.NewLine
                strSql &= " LEFT JOIN ni_products Q ON A.Prod_Code=Q.NI_prod_ID" & Environment.NewLine
                strSql &= " LEFT JOIN tcustaggregatebilling R ON A.BillCode_ID=R.BillCode_ID AND R.Cust_ID=" & iCustID & Environment.NewLine
                strSql &= " WHERE A.CUST_ID=" & iCustID & " AND A.BillCode_ID>0" & Environment.NewLine
                strSql &= " AND TrackCreatedDateTime BETWEEN '" & strStartDTime & "' AND ' " & strEndDTime & "'" & Environment.NewLine
                strSql &= " ORDER BY  Model,'Serial Number';" & Environment.NewLine

                dtCTM = Me._objDataProc.GetDataTable(strSql)
                dtCTM.TableName = "Call_Tag Mailing"

                ds.Tables.Add(dtCTM)


                'Pack and Shipment
                strSql = "SELECT  IF(Q.NI_Prod_Desc IS NULL OR TRIM(Q.NI_Prod_Desc)='',V.Model_Desc,Q.NI_Prod_Desc) AS 'Model'" & Environment.NewLine
                strSql &= " ,IF(Q.NI_SKU IS NULL OR TRIM(Q.NI_SKU)='','n/a',Q.NI_SKU) AS 'NI SKU'" & Environment.NewLine
                strSql &= " ,IF(Q.NI_Prod_ID IS NULL OR TRIM(Q.NI_Prod_ID)='','n/a',Q.NI_Prod_ID) AS 'NI Product ID'" & Environment.NewLine
                strSql &= " ,C.ClaimNo AS 'NI Order Number'" & Environment.NewLine
                strSql &= " ,IF(W.Serial IS NULL OR TRIM(W.Serial)='','n/a',W.Serial) AS 'Serial Number'" & Environment.NewLine
                strSql &= " ,A.OrderShipmentCharge AS 'SC800'" & Environment.NewLine
                strSql &= " ,K.BillCode_Desc,L.BillType_LDesc" & Environment.NewLine
                strSql &= " ,V.Model_Desc AS 'PSS Model Out',O.Model_Desc AS 'PSS Model In'" & Environment.NewLine
                strSql &= " ,'' AS 'Received SN', IF(C.SerialNo IS NULL OR TRIM(C.SerialNo)='','n/a',C.SerialNo) AS 'RMA SN'" & Environment.NewLine
                strSql &= " ,A.CustomerFirstName AS 'Ship To',A.CustomerAddress1,A.CustomerAddress2,A.CustomerCity AS 'City'" & Environment.NewLine
                strSql &= " ,A.CustomerState AS 'State',A.CustomerPostalCode AS 'ZipCode',A.CustomerCountry AS 'Country'" & Environment.NewLine
                strSql &= " ,A.CustomerEmail,A.PODate,A.CarrierSCACCode,A.ShipCarrier,A.OutboundTrackingNumber" & Environment.NewLine
                strSql &= " ,A.ShipDate,R.tcab_amount" & Environment.NewLine
                strSql &= " ,C.EW_ID,C.WO_ID,A.BillCode_ID,L.BillType_ID,V.Model_ID AS 'Model_ID Out',O.Model_ID AS 'Model_ID IN'" & Environment.NewLine
                strSql &= " ,W.WI_ID AS 'WI_ID Out',0 as 'Received WI_ID'" & Environment.NewLine
                strSql &= " FROM saleorders.SOheader A" & Environment.NewLine
                strSql &= " INNER JOIN saleorders.SODetails B ON A.SOHeaderID=B.SOHeaderID" & Environment.NewLine
                strSql &= " INNER JOIN extendedwarranty C ON A.WorkOrderID=C.WO_ID AND C.Cust_ID=" & iCustID & Environment.NewLine
                strSql &= " INNER JOIN lbillcodes K ON A.BillCode_ID = K.BillCode_ID" & Environment.NewLine
                strSql &= " INNER JOIN lbilltype L ON K.BillType_ID=L.BillType_ID" & Environment.NewLine
                strSql &= " INNER JOIN tmodel O ON O.Model_ID = B.Model_ID" & Environment.NewLine
                strSql &= " INNER JOIN warehouse.warehouse_items W ON B.SODetailsID=W.SODetailsID" & Environment.NewLine
                strSql &= " INNER JOIN tmodel V ON W.Model_ID = V.Model_ID" & Environment.NewLine
                strSql &= " LEFT JOIN ni_product_pssi_model_map P ON W.model_ID=P.Model_ID" & Environment.NewLine
                strSql &= " LEFT JOIN ni_products Q ON P.NI_prod_ID=Q.NI_prod_ID" & Environment.NewLine
                strSql &= " LEFT JOIN tcustaggregatebilling R ON A.BillCode_ID=R.BillCode_ID AND R.Cust_ID=" & iCustID & Environment.NewLine
                strSql &= " WHERE A.CUST_ID=" & iCustID & " AND A.InvalidOrder=0" & Environment.NewLine
                strSql &= " AND A.ShipDate BETWEEN '" & strStartDTime & "' AND ' " & strEndDTime & "'" & Environment.NewLine
                strSql &= " ORDER BY  Model,'Serial Number';" & Environment.NewLine

                dtPackShip = Me._objDataProc.GetDataTable(strSql)
                dtPackShip.TableName = "Pack and Shipment"

                ds.Tables.Add(dtPackShip)

                strS = ""
                If bSummaryDetails Then
                    objExcelRpt = New ExcelReports(False)
                    'objExcelRpt.RunSimpleExcelFormat_PerSheetPerTable(ds, strRptName, New String() {"A", "B", "D", "E", "N"})
                    objExcelRpt.RunNIInvoiceReport(ds, strRptName, strHeaderDates, bSummaryDetails, New String() {"A", "B", "C", "D", "E"})
                Else
                    Dim bFound As Boolean = False
                    Dim rowNew As DataRow
                    dtRepairedFinal2 = ds.Tables(0).Copy
                    For i = 1 To ds.Tables.Count - 1
                        AddNewRowForKeyCols(ds.Tables(i), dtRepairedFinal2)
                    Next

                    UpdateData(dtCTM, "SC100", dtRepairedFinal2)
                    UpdateData(dtWHRecv, "SC200", dtRepairedFinal2)
                    UpdateData(dtPackShip, "SC800", dtRepairedFinal2)

                    'sort
                    Dim dvRow As DataRowView
                    Dim dv As New DataView(dtRepairedFinal2)
                    Dim dtFinalSorted As DataTable = dv.Table.Clone
                    dv.Sort = "Model,Serial Number"
                    For Each dvRow In dv
                        dtFinalSorted.ImportRow(dvRow.Row)
                    Next

                    'set null if 0
                    For Each row In dtFinalSorted.Rows
                        For i = 1 To 9
                            strCol = "SC" & i.ToString & "00"
                            If Not row.IsNull(strCol) AndAlso row(strCol) = 0 Then row(strCol) = DBNull.Value
                        Next
                        If Not row.IsNull("SC720") AndAlso row("SC720") = 0 Then row("SC720") = DBNull.Value
                    Next

                    'Remove unwanted cols
                    For i = 16 To dtFinalSorted.Columns.Count - 1
                        arrColNames.Add(dtFinalSorted.Columns(i).ColumnName)
                    Next
                    For i = 0 To arrColNames.Count - 1
                        dtFinalSorted.Columns.Remove(arrColNames(i))
                    Next

                    dtFinalSorted.TableName = "NI_Invoice"
                    ds2.Tables.Add(dtFinalSorted)

                    objExcelRpt = New ExcelReports(False)
                    ' objExcelRpt.RunSimpleExcelFormat_PerSheetPerTable(ds2, strRptName, New String() {"A", "B", "D", "E", "N"})
                    objExcelRpt.RunNIInvoiceReport(ds2, strRptName, strHeaderDates, bSummaryDetails, New String() {"A", "B", "C", "D", "E"}, New String() {"F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P"})
                End If

                Return dt.Rows.Count

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '**********************************************************************************
        Private Function getConcatenatedString(ByVal dtRows() As DataRow, ByVal strCol As String) As String
            Dim row As DataRow
            Dim strS As String = ""
            Dim arrStr As New ArrayList()
            Dim i As Integer = 0

            For Each row In dtRows
                If Not row.IsNull(strCol) AndAlso Not Trim(row(strCol)).ToString = "" Then
                    If Not arrStr.Contains(Trim(row(strCol)).ToString) Then
                        arrStr.Add(Trim(row(strCol)).ToString)
                    End If
                End If
            Next

            For i = 0 To arrStr.Count - 1
                If i = 0 Then
                    strS = arrStr(i)
                Else
                    strS &= ", " & arrStr(i)
                End If
            Next

            Return strS
        End Function

        '**********************************************************************************
        Private Function getRowSum(ByVal dtRows() As DataRow, ByVal strCol As String, _
                                   Optional ByRef strSumItems As String = "") As Double
            Dim row As DataRow
            Dim dVal As Double = 0.0
            Dim i As Integer = 0
            Dim strS As String = ""

            For Each row In dtRows
                If Not row.IsNull(strCol) AndAlso Not Trim(row(strCol)).ToString = "" _
                   AndAlso IsNumeric(row(strCol)) AndAlso row(strCol) > 0.0 Then
                    dVal += CDbl(row(strCol))

                    If i = 0 Then
                        strS = Trim(row(strCol)).ToString
                    Else
                        strS &= ", " & Trim(row(strCol)).ToString
                    End If
                    i += 1
                End If
            Next
            strSumItems = strS

            Return dVal
        End Function

        '**********************************************************************************
        Private Sub AddNewRowForKeyCols(ByVal dt As DataTable, ByRef dtRepairedFinal As DataTable)
            Dim bFound As Boolean = False
            Dim row, tmpRow, rowNew As DataRow
            Dim strS As String = "", strTmp As String = ""

            For Each row In dt.Rows
                bFound = False
                strS = Trim(row("Model")).ToString & Trim(row("NI SKU")).ToString & Trim(row("NI Product ID")).ToString & _
                       Trim(row("NI Order Number")).ToString & Trim(row("Serial Number")).ToString

                For Each tmpRow In dtRepairedFinal.Rows
                    strTmp = Trim(tmpRow("Model")).ToString & Trim(tmpRow("NI SKU")).ToString & Trim(tmpRow("NI Product ID")).ToString & _
                             Trim(tmpRow("NI Order Number")).ToString & Trim(tmpRow("Serial Number")).ToString
                    If strS.ToUpper = strTmp.ToUpper Then
                        bFound = True : Exit For
                    End If
                Next

                If bFound = False Then
                    rowNew = dtRepairedFinal.NewRow
                    rowNew("Model") = row("Model") : rowNew("NI SKU") = row("NI SKU") : rowNew("NI Product ID") = row("NI Product ID")
                    rowNew("NI Order Number") = row("NI Order Number") : rowNew("Serial Number") = row("Serial Number")
                    dtRepairedFinal.Rows.Add(rowNew)
                End If
            Next
        End Sub

        '**********************************************************************************
        Private Sub UpdateData(ByVal dt As DataTable, ByVal strCol As String, ByRef dtRepairedFinal As DataTable)
            Dim bFound As Boolean = False
            Dim row, tmpRow, rowNew As DataRow
            Dim strS As String = "", strTmp As String = ""

            For Each row In dt.Rows
                bFound = False
                strS = Trim(row("Model")).ToString & Trim(row("NI SKU")).ToString & Trim(row("NI Product ID")).ToString & _
                       Trim(row("NI Order Number")).ToString & Trim(row("Serial Number")).ToString

                For Each tmpRow In dtRepairedFinal.Rows
                    strTmp = Trim(tmpRow("Model")).ToString & Trim(tmpRow("NI SKU")).ToString & Trim(tmpRow("NI Product ID")).ToString & _
                             Trim(tmpRow("NI Order Number")).ToString & Trim(tmpRow("Serial Number")).ToString
                    If strS.ToUpper = strTmp.ToUpper Then
                        tmpRow(strCol) = row(strCol) : tmpRow.AcceptChanges()
                        bFound = True : Exit For
                    End If
                Next

                'If bFound = False Then
                '    rowNew = dtRepairedFinal.NewRow
                '    rowNew("Model") = row("Model") : rowNew("NI SKU") = row("NI SKU") : rowNew("NI Product ID") = row("NI Product ID")
                '    rowNew("NI Order Number") = row("NI Order Number") : rowNew("Serial Number") = row("Serial Number")
                '    dtRepairedFinal.Rows.Add(rowNew)
                'End If
            Next
        End Sub

        '**********************************************************************************
        Private Function getDefectClass(ByVal iDevice_ID As Integer) As String
            Dim strSql As String
            Dim dt As DataTable
            Dim row As DataRow
            Dim strTmp As String = ""

            strSql = "SELECT  A.Device_DC_ID,A.Device_ID,A.DefectClass_ID,B.DefectClass_desc" & Environment.NewLine
            strSql &= " FROM ni_device_defectclass A" & Environment.NewLine
            strSql &= " INNER JOIN  ni_defectclass B ON A.DefectClass_ID=B.DefectClass_ID" & Environment.NewLine
            strSql &= " WHERE Device_ID= " & iDevice_ID & ";" & Environment.NewLine

            dt = Me._objDataProc.GetDataTable(strSql)

            For Each row In dt.Rows
                If strTmp.Trim.Length = 0 Then
                    strTmp = row("DefectClass_desc")
                Else
                    strTmp &= "," & row("DefectClass_desc")
                End If
            Next
            Return strTmp

        End Function
    End Class

End Namespace
