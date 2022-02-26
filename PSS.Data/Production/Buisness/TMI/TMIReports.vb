Option Explicit On 

Imports CrystalDecisions.CrystalReports.Engine

Namespace Buisness
    Public Class TMIReports

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

        '**************************************************************************
        Public Function CreateNeedParts(ByVal iLocID As Integer, ByVal strReportName As String, _
                                        ByVal strDateStart As String, ByVal strDateEnd As String) As Integer
            Dim strSql As String
            Dim dt As DataTable
            Dim objExcelRpt As ExcelReports

            Try
                strSql = "SELECT ClaimNo as 'Claim #', prod_desc as 'Product Type', Manuf_Desc as 'Manufacture', tmodel.model_desc as 'Model'" & Environment.NewLine
                strSql &= ", device_sn as 'PSS SN', tcellopt.manuf_sn as 'Manuf SN', Billcode_Desc as 'Billcode'" & Environment.NewLine
                strSql &= ", part_number as 'Part #', date_rec as 'Date', sum(Trans_Amount) as 'Qty'" & Environment.NewLine
                strSql &= "FROM tdevice INNER JOIN tmodel on tdevice.model_id = tmodel.model_id " & Environment.NewLine
                strSql &= "INNER JOIN tcellopt ON tdevice.device_id = tcellopt.device_ID " & Environment.NewLine
                strSql &= "INNER JOIN extendedwarranty ON tdevice.WO_ID = extendedwarranty.WO_ID " & Environment.NewLine
                strSql &= "INNER JOIN lmanuf ON tmodel.manuf_id = lmanuf.Manuf_ID " & Environment.NewLine
                strSql &= "INNER JOIN lproduct ON tmodel.prod_id = lproduct.prod_id " & Environment.NewLine
                strSql &= "INNER JOIN tdevicebillawap ON tdevice.device_id = tdevicebillawap.device_ID " & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON tdevicebillawap.billcode_id = lbillcodes.billcode_id " & Environment.NewLine
                strSql &= "WHERE tdevice.Loc_ID = " & iLocID & " AND device_dateship is null AND date_rec between '" & strDateStart & "' AND '" & strDateEnd & "'" & Environment.NewLine
                strSql &= "GROUP BY date_rec, tdevice.device_SN, tdevicebillawap.Billcode_ID, part_Number " & Environment.NewLine
                strSql &= "HAVING qty <> 0" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    objExcelRpt = New ExcelReports(False)
                    objExcelRpt.RunSimpleExcelFormat(dt, strReportName)
                    '*************************
                End If

                Return dt.Rows.Count

            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '**************************************************************************
        Public Function CreateBoxTrackingRpt(ByVal iCustID As Integer, ByVal strReportName As String, _
                                        ByVal strDateStart As String, ByVal strDateEnd As String) As Integer
            Dim strSql As String
            Dim dt As DataTable
            Dim objExcelRpt As ExcelReports
            Dim strCols(12) As String, i As Integer = 0

            Try
                strSql = "SELECT a.WO_ID as WorkOrder,REPLACE(a.Tel,'-','') as Phone,Shipto_Name as Customer," & Environment.NewLine
                strSql &= "Concat(a.Address1, if(Length(a.address2)>0, Concat(', ', a.Address2), '')) as Address," & Environment.NewLine
                strSql &= "a.City,c.State_Short as State," & Environment.NewLine
                strSql &= "if(Length(REPLACE(a.ZipCode,'-',''))>5, Concat(SUBSTRING(REPLACE(a.ZipCode,'-',''),1,5), '-', SUBSTRING(REPLACE(a.ZipCode,'-',''),6,Length(REPLACE(a.ZipCode,'-',''))-5)), a.ZipCode) as ZipCode," & Environment.NewLine
                strSql &= "a.ClaimNo as ClaimNumber,Date_Format(TrackCreatedDateTime,'%Y-%m-%d') as DateShipped,b.SC_Desc as ShippedMethod," & Environment.NewLine
                strSql &= "PSSI2Cust_TrackNo as Outbound_Tracking,Cust2PSSI_TrackNo as Return_Tracking," & Environment.NewLine
                strSql &= "TMIServiceClient" & Environment.NewLine
                strSql &= " FROM ExtendedWarranty a" & Environment.NewLine
                strSql &= " LEFT JOIN lShipCarrier b ON a.SC_ID=b.SC_ID" & Environment.NewLine
                strSql &= " LEFT JOIN lState c ON a.State_ID=c.State_ID" & Environment.NewLine
                strSql &= " LEFT JOIN tmi_Status d ON a.S_ID=d.S_ID" & Environment.NewLine
                strSql &= " WHERE a.S_ID=2 AND Cust_ID=" & iCustID & Environment.NewLine
                strSql &= " AND TrackCreatedDateTime BETWEEN '" & strDateStart & " 00:00:00'" & Environment.NewLine
                strSql &= " AND '" & strDateEnd & " 23:59:59'" & Environment.NewLine
                strSql &= " ORDER BY a.LoadedDateTime;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    For i = 0 To strCols.Length - 1
                        If i < 8 Then
                            strCols(i) = Number2Char(i + 1)
                        Else
                            strCols(i) = Number2Char(i + 2)
                        End If
                    Next i

                    objExcelRpt = New ExcelReports(False)
                    objExcelRpt.RunSimpleExcelFormat(dt, strReportName, strCols)
                    '*************************
                End If

                Return dt.Rows.Count

            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '**************************************************************************
        Public Function CreateBoxDaysAfterShippedRpt(ByVal iCustID As Integer, ByVal strReportName As String) As Integer
            Dim strSql As String
            Dim dt As DataTable
            Dim objExcelRpt As ExcelReports
            Dim strCols(14) As String, i As Integer = 0

            Try
                strSql = "SELECT Date_Format(TrackCreatedDateTime,'%Y-%m-%d') as DateShipped,To_Days(CURRENT_DATE) - To_Days(TrackCreatedDateTime) as DaysAfterShipped," & Environment.NewLine
                strSql &= "PSSI2Cust_TrackNo as Outbound_Tracking,Cust2PSSI_TrackNo as Return_Tracking," & Environment.NewLine
                strSql &= "a.WO_ID as WorkOrder,REPLACE(a.Tel,'-','') as Phone,Shipto_Name as Customer," & Environment.NewLine
                strSql &= "Concat(a.Address1, if(Length(a.address2)>0, Concat(', ', a.Address2), '')) as Address," & Environment.NewLine
                strSql &= "a.City,c.State_Short as State," & Environment.NewLine
                strSql &= "if(Length(REPLACE(a.ZipCode,'-',''))>5, Concat(SUBSTRING(REPLACE(a.ZipCode,'-',''),1,5), '-', SUBSTRING(REPLACE(a.ZipCode,'-',''),6,Length(REPLACE(a.ZipCode,'-',''))-5)), a.ZipCode) as ZipCode," & Environment.NewLine
                strSql &= "a.ClaimNo as ClaimNumber,b.SC_Desc as ShippedMethod,TMIServiceClient" & Environment.NewLine
                strSql &= " FROM ExtendedWarranty a" & Environment.NewLine
                strSql &= " LEFT JOIN lShipCarrier b ON a.SC_ID=b.SC_ID" & Environment.NewLine
                strSql &= " LEFT JOIN lState c ON a.State_ID=c.State_ID" & Environment.NewLine
                strSql &= " LEFT JOIN tmi_Status d ON a.S_ID=d.S_ID" & Environment.NewLine
                strSql &= " WHERE a.S_ID=2 AND Cust_ID=" & iCustID & Environment.NewLine
                strSql &= " ORDER BY a.LoadedDateTime;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    For i = 0 To strCols.Length - 1
                        If i < 1 Then
                            strCols(i) = Number2Char(i + 1)
                        Else
                            strCols(i) = Number2Char(i + 2)
                        End If
                    Next i

                    objExcelRpt = New ExcelReports(False)
                    objExcelRpt.RunSimpleExcelFormat(dt, strReportName, strCols)
                    '*************************
                End If

                Return dt.Rows.Count

            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '**************************************************************************
        Public Function Create30DayNonReturnChargeRpt(ByVal iCustID As Integer, ByVal strReportName As String, _
                                        ByVal strDateStart As String, ByVal strDateEnd As String) As Integer
            Dim strSql As String
            Dim dt As DataTable
            Dim objExcelRpt As ExcelReports
            Dim strCols(15) As String, DollarNumberCol(0) As String, i As Integer = 0

            Try
                strSql = "SELECT URP_Charge,Date_Format(URP_ChargedDate,'%Y-%m-%d') as URP_ChargedDate, Date_Format(TrackCreatedDateTime,'%Y-%m-%d') as DateShipped," & Environment.NewLine
                strSql &= "PSSI2Cust_TrackNo as Outbound_Tracking,Cust2PSSI_TrackNo as Return_Tracking," & Environment.NewLine
                strSql &= "a.WO_ID as WorkOrder,REPLACE(a.Tel,'-','') as Phone,Shipto_Name as Customer," & Environment.NewLine
                strSql &= "Concat(a.Address1, if(Length(a.address2)>0, Concat(', ', a.Address2), '')) as Address," & Environment.NewLine
                strSql &= "a.City,c.State_Short as State," & Environment.NewLine
                strSql &= "if(Length(REPLACE(a.ZipCode,'-',''))>5, Concat(SUBSTRING(REPLACE(a.ZipCode,'-',''),1,5), '-', SUBSTRING(REPLACE(a.ZipCode,'-',''),6,Length(REPLACE(a.ZipCode,'-',''))-5)), a.ZipCode) as ZipCode," & Environment.NewLine
                strSql &= "a.ClaimNo as ClaimNumber,b.SC_Desc as ShippedMethod,TMIServiceClient" & Environment.NewLine
                strSql &= " FROM ExtendedWarranty a" & Environment.NewLine
                strSql &= " LEFT JOIN lShipCarrier b ON a.SC_ID=b.SC_ID" & Environment.NewLine
                strSql &= " LEFT JOIN lState c ON a.State_ID=c.State_ID" & Environment.NewLine
                strSql &= " LEFT JOIN tmi_Status d ON a.S_ID=d.S_ID" & Environment.NewLine
                strSql &= " WHERE a.S_ID=8 AND Cust_ID=" & iCustID & Environment.NewLine
                strSql &= " AND a.URP_ChargedDate BETWEEN '" & strDateStart & " 00:00:00'" & Environment.NewLine
                strSql &= " AND '" & strDateEnd & " 23:59:59'" & Environment.NewLine
                strSql &= " ORDER BY a.LoadedDateTime;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    For i = 0 To strCols.Length - 1
                        strCols(i) = Number2Char(i + 2) 'all cols after A
                    Next i
                    DollarNumberCol(0) = Number2Char(1) 'Col A

                    objExcelRpt = New ExcelReports(False)
                    objExcelRpt.RunSimpleExcelFormat(dt, strReportName, strCols, DollarNumberCol)
                    '*************************
                End If

                Return dt.Rows.Count

            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function


        '**************************************************************************
        Public Function CreateWIPRpt(ByVal iCustID As Integer, ByVal strReportName As String) As Integer
            Dim strSql As String
            Dim dt As DataTable, row As DataRow
            Dim iDeviceID As Integer = 0
            Dim WorkPerformedStr As String = ""
            Dim objExcelRpt As ExcelReports
            Dim strCols(9) As String, i As Integer = 0

            Try
                strSql = "SELECT a.WO_ID as WorkOrder,e.Device_SN as 'PSSI_Serial Number', REPLACE(a.Tel,'-','') as Phone," & Environment.NewLine
                strSql &= "a.ClaimNo as 'Claim Number',Shipto_Name as Customer," & Environment.NewLine
                strSql &= "a.Brand,a.Model,f.Manuf_SN as SerialNo,'' as 'Work Performed',d.Description as PSSI_CurrentStatus," & Environment.NewLine
                strSql &= "Date_Format(a.LoadedDateTime,'%Y-%m-%d') as 'RMA Received Date'," & Environment.NewLine
                strSql &= "Date_Format(a.TrackCreatedDateTime,'%Y-%m-%d') as 'Return Kit Shipped Date'," & Environment.NewLine
                strSql &= "Date_Format(e.Device_DateRec,'%Y-%m-%d') as 'Unit Received Date'," & Environment.NewLine
                strSql &= "Date_Format(a.QuoteSubmittedDate,'%Y-%m-%d') as 'Quote Submitted Date',e.Device_ID" & Environment.NewLine
                strSql &= " FROM ExtendedWarranty a" & Environment.NewLine
                strSql &= " LEFT JOIN lShipCarrier b ON a.SC_ID=b.SC_ID" & Environment.NewLine
                strSql &= " LEFT JOIN lState c ON a.State_ID=c.State_ID" & Environment.NewLine
                strSql &= " LEFT JOIN tmi_Status d ON a.S_ID=d.S_ID" & Environment.NewLine
                strSql &= " LEFT JOIN tDevice e ON a.WO_ID=e.WO_ID" & Environment.NewLine
                strSql &= " LEFT JOIN tCellOpt f ON  e.Device_ID=f.Device_ID" & Environment.NewLine
                strSql &= " WHERE a.S_ID Not in (7,8,9) AND Cust_ID=" & iCustID & Environment.NewLine
                strSql &= " ORDER BY a.LoadedDateTime;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    For i = 0 To strCols.Length - 1
                        strCols(i) = Number2Char(i + 1)
                    Next i

                    For Each row In dt.Rows
                        iDeviceID = 0
                        If IsNumeric(row.Item("Device_ID")) Then
                            iDeviceID = row.Item("Device_ID")
                            WorkPerformedStr = WorkPerformedByDeviceID(iDeviceID)
                            row.BeginEdit()
                            row.Item("Work Performed") = WorkPerformedStr
                            row.AcceptChanges()
                            row.EndEdit()
                        End If
                    Next

                    dt.Columns.Remove("Device_ID") 'remove this column for the report

                    objExcelRpt = New ExcelReports(False)
                    objExcelRpt.RunSimpleExcelFormat(dt, strReportName, strCols)
                    '*************************
                End If

                Return dt.Rows.Count

            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '**************************************************************************
        Public Function CreateCompletedUnitsShippedRpt(ByVal iCustID As Integer, ByVal strReportName As String, _
                                        ByVal strDateStart As String, ByVal strDateEnd As String) As Integer
            Dim strSql As String
            Dim dt As DataTable, row As DataRow
            Dim iDeviceID As Integer = 0
            Dim WorkPerformedStr As String = ""
            Dim objExcelRpt As ExcelReports
            Dim strCols(10) As String, i As Integer = 0

            Try
                strSql = "SELECT a.WO_ID as WorkOrder, REPLACE(a.Tel,'-','') as Phone,a.Shipto_Name as Customer," & Environment.NewLine
                strSql &= "a.Brand,a.Model,f.Manuf_SN as Serial,a.ClaimNo as 'Claim Number','' as 'Work Performed'," & Environment.NewLine
                strSql &= "d.Description as Status," & Environment.NewLine
                strSql &= "Date_Format(e.Device_DateShip,'%Y-%m-%d') as 'Date Shipped'," & Environment.NewLine
                strSql &= "Final_PSSI2Cust_TrackNo Outbound_Tracking,e.Device_ID" & Environment.NewLine
                strSql &= " FROM ExtendedWarranty a" & Environment.NewLine
                strSql &= " LEFT JOIN tmi_Status d ON a.S_ID=d.S_ID" & Environment.NewLine
                strSql &= " LEFT JOIN tDevice e ON a.WO_ID=e.WO_ID" & Environment.NewLine
                strSql &= " LEFT JOIN tCellOpt f ON e.Device_ID=f.Device_ID" & Environment.NewLine
                strSql &= " WHERE a.S_ID in (7) AND Cust_ID=" & iCustID & Environment.NewLine
                strSql &= " AND e.Device_DateShip BETWEEN '" & strDateStart & " 00:00:00'" & Environment.NewLine
                strSql &= " AND '" & strDateEnd & " 23:59:59'" & Environment.NewLine
                strSql &= " UNION ALL" & Environment.NewLine
                strSql &= " SELECT a.WO_ID as WorkOrder, REPLACE(a.Tel,'-','') as Phone,a.Shipto_Name as Customer," & Environment.NewLine
                strSql &= "a.Brand,a.Model,f.Manuf_SN as Serial,a.ClaimNo as 'Claim Number','' as 'Work Performed'," & Environment.NewLine
                strSql &= "d.Description as Status," & Environment.NewLine
                strSql &= "Date_Format(a.URP_ChargedDate,'%Y-%m-%d') as 'Date Shipped'," & Environment.NewLine
                strSql &= "Final_PSSI2Cust_TrackNo Outbound_Tracking,e.Device_ID" & Environment.NewLine
                strSql &= " FROM ExtendedWarranty a" & Environment.NewLine
                strSql &= " LEFT JOIN tmi_Status d ON a.S_ID=d.S_ID" & Environment.NewLine
                strSql &= " LEFT JOIN tDevice e ON a.WO_ID=e.WO_ID" & Environment.NewLine
                strSql &= " LEFT JOIN tCellOpt f ON e.Device_ID=f.Device_ID" & Environment.NewLine
                strSql &= " WHERE a.S_ID in (8) AND Cust_ID=" & iCustID & Environment.NewLine
                strSql &= " AND a.URP_ChargedDate BETWEEN '" & strDateStart & " 00:00:00'" & Environment.NewLine
                strSql &= " AND '" & strDateEnd & " 23:59:59'" & Environment.NewLine
                strSql &= "  ORDER BY 'Date Shipped', Status desc;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    For i = 0 To strCols.Length - 1
                        If i < 9 Then
                            strCols(i) = Number2Char(i + 1)
                        Else
                            strCols(i) = Number2Char(i + 2)
                        End If
                    Next i

                    For Each row In dt.Rows
                        iDeviceID = 0
                        If IsNumeric(row.Item("Device_ID")) Then
                            iDeviceID = row.Item("Device_ID")
                            WorkPerformedStr = WorkPerformedByDeviceID(iDeviceID)
                            row.BeginEdit()
                            row.Item("Work Performed") = WorkPerformedStr
                            row.AcceptChanges()
                            row.EndEdit()
                        End If
                    Next

                    dt.Columns.Remove("Device_ID") 'remove this column for the report

                    'do report
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
        Public Function CreateInvoiceRpt(ByVal iCustID As Integer, ByVal strReportName As String, _
                                        ByVal strDateStart As String, ByVal strDateEnd As String) As Integer
            Dim strSql As String
            Dim dt As DataTable, row As DataRow
            Dim iDeviceID As Integer = 0
            Dim vRepairPartCharge As Double = 0, vLaborCharge As Double = 0, vTotalBill As Double = 0
            Dim vSumPart As Double = 0, vSumLabor As Double = 0, vSumTotal As Double = 0
            Dim vShipmentCharge As Double = 0, vSumShipment As Double = 0
            Dim WorkPerformedStr As String = ""
            Dim objExcelRpt As ExcelReports
            Dim strCols(10) As String, i As Integer = 0
            Dim DollarNumberCol(3) As String

            Try
                '01/22/2013  Use Device_PartCharge from tDevice, instead of sum(DBill_InvoiceAmt) from tDeviceBill
                strSql = "SELECT a.ClaimNo as 'Claim Number',a.WO_ID as WorkOrder, REPLACE(a.Tel,'-','') as Phone," & Environment.NewLine
                strSql &= "Shipto_Name as Customer,a.Type as ProductType," & Environment.NewLine
                strSql &= "a.Brand,a.Model,f.Manuf_SN as Serial,'' as 'Work Performed',a.RepairStatusCode," & Environment.NewLine
                strSql &= "Date_Format(e.Device_DateRec,'%Y-%m-%d') as 'Date Received'," & Environment.NewLine
                strSql &= "Date_Format(e.Device_DateShip,'%Y-%m-%d') as 'Date Shipped'," & Environment.NewLine
                strSql &= "e.Device_PartCharge as 'Total Part Price', if(e.Device_LaborCharge is null ,0, e.Device_LaborCharge) as 'Total Labor Price'," & Environment.NewLine
                strSql &= "if(e.Device_LaborCharge is null ,0, e.Device_LaborCharge) as 'Total Bill Price'," & Environment.NewLine
                strSql &= "e.Device_ID" & Environment.NewLine
                strSql &= " FROM ExtendedWarranty a" & Environment.NewLine
                strSql &= " LEFT JOIN tDevice e ON a.WO_ID=e.WO_ID" & Environment.NewLine
                strSql &= "  LEFT JOIN tCellOpt f ON  e.Device_ID=f.Device_ID" & Environment.NewLine
                strSql &= " WHERE a.S_ID in (7) AND Cust_ID=" & iCustID & Environment.NewLine
                strSql &= " AND e.Device_DateShip BETWEEN '" & strDateStart & " 00:00:00'" & Environment.NewLine
                strSql &= " AND '" & strDateEnd & " 23:59:59'" & Environment.NewLine
                strSql &= " UNION ALL" & Environment.NewLine
                strSql &= "SELECT a.ClaimNo as 'Claim Number',a.WO_ID as WorkOrder, REPLACE(a.Tel,'-','') as Phone," & Environment.NewLine
                strSql &= "Shipto_Name as Customer,a.Type as ProductType," & Environment.NewLine
                strSql &= "a.Brand,a.Model,f.Manuf_SN as Serial,'' as 'Work Performed',d.Description as RepairStatusCode," & Environment.NewLine
                strSql &= "'' as 'Date Received'," & Environment.NewLine
                strSql &= "Date_Format(a.URP_ChargedDate,'%Y-%m-%d') as 'Date Shipped'," & Environment.NewLine
                strSql &= "0.0 as 'Total Part Price', if(a.URP_Charge is null ,0, a.URP_Charge) as 'Total Labor Price'," & Environment.NewLine
                strSql &= "if(a.URP_Charge is null ,0, a.URP_Charge) as 'Total Bill Price'," & Environment.NewLine
                strSql &= "Null as Device_ID" & Environment.NewLine
                strSql &= " FROM ExtendedWarranty a" & Environment.NewLine
                strSql &= " LEFT JOIN tDevice e ON a.WO_ID=e.WO_ID" & Environment.NewLine
                strSql &= " LEFT JOIN tmi_status d ON a.S_ID=d.S_ID" & Environment.NewLine
                strSql &= "  LEFT JOIN tCellOpt f ON  e.Device_ID=f.Device_ID" & Environment.NewLine
                strSql &= " WHERE a.S_ID in (8) AND Cust_ID=" & iCustID & Environment.NewLine
                strSql &= " AND a.URP_ChargedDate BETWEEN '" & strDateStart & " 00:00:00'" & Environment.NewLine
                strSql &= " AND '" & strDateEnd & " 23:59:59'" & Environment.NewLine
                strSql &= " ORDER BY 'Date Shipped',RepairStatusCode;" & Environment.NewLine


                ''Using this the Old way
                'strSql = "SELECT a.ClaimNo as 'Claim Number',a.WO_ID as WorkOrder, REPLACE(a.Tel,'-','') as Phone," & Environment.NewLine
                'strSql &= "Shipto_Name as Customer,a.Type as ProductType," & Environment.NewLine
                'strSql &= "a.Brand,a.Model,f.Manuf_SN as Serial,'' as 'Work Performed',a.RepairStatusCode," & Environment.NewLine
                'strSql &= "Date_Format(e.Device_DateRec,'%Y-%m-%d') as 'Date Received'," & Environment.NewLine
                'strSql &= "Date_Format(e.Device_DateShip,'%Y-%m-%d') as 'Date Shipped'," & Environment.NewLine
                'strSql &= "0 as 'Total Part Price', if(e.Device_LaborCharge is null ,0, e.Device_LaborCharge) as 'Total Labor Price'," & Environment.NewLine
                'strSql &= "if(e.Device_LaborCharge is null ,0, e.Device_LaborCharge) as 'Total Bill Price'," & Environment.NewLine
                'strSql &= "e.Device_ID" & Environment.NewLine
                'strSql &= " FROM ExtendedWarranty a" & Environment.NewLine
                'strSql &= " LEFT JOIN tDevice e ON a.WO_ID=e.WO_ID" & Environment.NewLine
                'strSql &= "  LEFT JOIN tCellOpt f ON  e.Device_ID=f.Device_ID" & Environment.NewLine
                'strSql &= " WHERE a.S_ID in (7) AND Cust_ID=" & iCustID & Environment.NewLine
                'strSql &= " AND e.Device_DateShip BETWEEN '" & strDateStart & " 00:00:00'" & Environment.NewLine
                'strSql &= " AND '" & strDateEnd & " 23:59:59'" & Environment.NewLine
                'strSql &= " UNION ALL" & Environment.NewLine
                'strSql &= "SELECT a.ClaimNo as 'Claim Number',a.WO_ID as WorkOrder, REPLACE(a.Tel,'-','') as Phone," & Environment.NewLine
                'strSql &= "Shipto_Name as Customer,a.Type as ProductType," & Environment.NewLine
                'strSql &= "a.Brand,a.Model,f.Manuf_SN as Serial,'' as 'Work Performed',d.Description as RepairStatusCode," & Environment.NewLine
                'strSql &= "'' as 'Date Received'," & Environment.NewLine
                'strSql &= "Date_Format(a.URP_ChargedDate,'%Y-%m-%d') as 'Date Shipped'," & Environment.NewLine
                'strSql &= "0 as 'Total Part Price', if(a.URP_Charge is null ,0, a.URP_Charge) as 'Total Labor Price'," & Environment.NewLine
                'strSql &= "if(a.URP_Charge is null ,0, a.URP_Charge) as 'Total Bill Price'," & Environment.NewLine
                'strSql &= "Null as Device_ID" & Environment.NewLine
                'strSql &= " FROM ExtendedWarranty a" & Environment.NewLine
                'strSql &= " LEFT JOIN tDevice e ON a.WO_ID=e.WO_ID" & Environment.NewLine
                'strSql &= " LEFT JOIN tmi_status d ON a.S_ID=d.S_ID" & Environment.NewLine
                'strSql &= "  LEFT JOIN tCellOpt f ON  e.Device_ID=f.Device_ID" & Environment.NewLine
                'strSql &= " WHERE a.S_ID in (8) AND Cust_ID=" & iCustID & Environment.NewLine
                'strSql &= " AND a.URP_ChargedDate BETWEEN '" & strDateStart & " 00:00:00'" & Environment.NewLine
                'strSql &= " AND '" & strDateEnd & " 23:59:59'" & Environment.NewLine
                'strSql &= " ORDER BY 'Date Shipped',RepairStatusCode;" & Environment.NewLine

                'Disable the New way
                'strSql = "SELECT a.ClaimNo as 'Claim Number',a.WO_ID as WorkOrder, REPLACE(a.Tel,'-','') as Phone," & Environment.NewLine
                'strSql &= "Shipto_Name as Customer,a.Type as ProductType," & Environment.NewLine
                'strSql &= "a.Brand,a.Model,f.Manuf_SN as Serial,'' as 'Work Performed',a.RepairStatusCode," & Environment.NewLine
                'strSql &= "Date_Format(e.Device_DateRec,'%Y-%m-%d') as 'Date Received'," & Environment.NewLine
                'strSql &= "Date_Format(e.Device_DateShip,'%Y-%m-%d') as 'Date Shipped'," & Environment.NewLine
                'strSql &= "0 as 'Total Part Price', if(e.Device_LaborCharge is null ,0, e.Device_LaborCharge) as 'Total Labor Price'," & Environment.NewLine
                'strSql &= "if(a.Cust2PSSI_ShipmentCost is null,0,a.Cust2PSSI_ShipmentCost) + " & Environment.NewLine
                'strSql &= "if(a.PSSI2Cust_ShipmentCost is null,0,a.PSSI2Cust_ShipmentCost) + " & Environment.NewLine
                'strSql &= "if(a.Final_PSSI2Cust_ShipmentCost is null,0,a.Final_PSSI2Cust_ShipmentCost)  as 'Total Shipment Price'," & Environment.NewLine
                'strSql &= "if(e.Device_LaborCharge is null ,0, e.Device_LaborCharge) + if(a.Cust2PSSI_ShipmentCost is null,0,a.Cust2PSSI_ShipmentCost) + if(a.PSSI2Cust_ShipmentCost is null,0,a.PSSI2Cust_ShipmentCost) + " & Environment.NewLine
                'strSql &= "if(a.Final_PSSI2Cust_ShipmentCost is null,0,a.Final_PSSI2Cust_ShipmentCost)  as 'Total Bill Price'," & Environment.NewLine
                'strSql &= "e.Device_ID" & Environment.NewLine
                'strSql &= " FROM ExtendedWarranty a" & Environment.NewLine
                'strSql &= " LEFT JOIN tDevice e ON a.WO_ID=e.WO_ID" & Environment.NewLine
                'strSql &= " LEFT JOIN tCellOpt f ON  e.Device_ID=f.Device_ID" & Environment.NewLine
                'strSql &= " WHERE a.S_ID in (7) AND Cust_ID=" & iCustID & Environment.NewLine
                'strSql &= " AND e.Device_DateShip BETWEEN '" & strDateStart & " 00:00:00'" & Environment.NewLine
                'strSql &= " AND '" & strDateEnd & " 23:59:59'" & Environment.NewLine
                'strSql &= " UNION ALL" & Environment.NewLine
                'strSql &= "SELECT a.ClaimNo as 'Claim Number',a.WO_ID as WorkOrder, REPLACE(a.Tel,'-','') as Phone," & Environment.NewLine
                'strSql &= "Shipto_Name as Customer,a.Type as ProductType," & Environment.NewLine
                'strSql &= "a.Brand,a.Model,f.Manuf_SN as Serial,'' as 'Work Performed',d.Description as RepairStatusCode," & Environment.NewLine
                'strSql &= "'' as 'Date Received'," & Environment.NewLine
                'strSql &= "Date_Format(a.URP_ChargedDate,'%Y-%m-%d') as 'Date Shipped'," & Environment.NewLine
                'strSql &= "0 as 'Total Part Price', if(a.URP_Charge is null ,0, a.URP_Charge) as 'Total Labor Price'," & Environment.NewLine
                'strSql &= "if(a.Cust2PSSI_ShipmentCost is null,0,a.Cust2PSSI_ShipmentCost) + " & Environment.NewLine
                'strSql &= "if(a.PSSI2Cust_ShipmentCost is null,0,a.PSSI2Cust_ShipmentCost) + " & Environment.NewLine
                'strSql &= "if(a.Final_PSSI2Cust_ShipmentCost is null,0,a.Final_PSSI2Cust_ShipmentCost)  as 'Total Shipment Price'," & Environment.NewLine
                'strSql &= "if(a.URP_Charge is null ,0, a.URP_Charge)  + if(a.Cust2PSSI_ShipmentCost is null,0,a.Cust2PSSI_ShipmentCost) + if(a.PSSI2Cust_ShipmentCost is null,0,a.PSSI2Cust_ShipmentCost) + " & Environment.NewLine
                'strSql &= "if(a.Final_PSSI2Cust_ShipmentCost is null,0,a.Final_PSSI2Cust_ShipmentCost) as 'Total Bill Price'," & Environment.NewLine
                'strSql &= "Null as Device_ID" & Environment.NewLine
                'strSql &= " FROM ExtendedWarranty a" & Environment.NewLine
                'strSql &= " LEFT JOIN tDevice e ON a.WO_ID=e.WO_ID" & Environment.NewLine
                'strSql &= " LEFT JOIN tmi_status d ON a.S_ID=d.S_ID" & Environment.NewLine
                'strSql &= " LEFT JOIN tCellOpt f ON  e.Device_ID=f.Device_ID" & Environment.NewLine
                'strSql &= " WHERE a.S_ID in (8) AND Cust_ID=" & iCustID & Environment.NewLine
                'strSql &= " AND a.URP_ChargedDate BETWEEN '" & strDateStart & " 00:00:00'" & Environment.NewLine
                'strSql &= " AND '" & strDateEnd & " 23:59:59'" & Environment.NewLine
                'strSql &= " ORDER BY 'Date Shipped',RepairStatusCode;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    'Format cols
                    For i = 0 To strCols.Length - 1
                        strCols(i) = Number2Char(i + 1)
                    Next i
                    For i = 0 To DollarNumberCol.Length - 1
                        DollarNumberCol(i) = Number2Char(i + 13)
                    Next i

                    'Add work performed, and total part charge
                    For Each row In dt.Rows
                        iDeviceID = 0
                        If IsNumeric(row.Item("Device_ID")) Then
                            iDeviceID = row.Item("Device_ID")
                            WorkPerformedStr = WorkPerformedByDeviceID(iDeviceID)
                            '01/22/2013  Use Device_PartCharge from tDevice, instead of sum(DBill_InvoiceAmt) from tDeviceBill
                            '01/22/2013 so No need this: vRepairPartCharge = RepairPartChargeByDeviceID(iDeviceID) 
                            row.BeginEdit()
                            row.Item("Work Performed") = WorkPerformedStr
                            'row.Item("Total Part Price") = vRepairPartCharge
                            row.AcceptChanges()
                            row.EndEdit()
                        End If
                    Next

                    'Compute total and Reset Device_Invoice =1 
                    For Each row In dt.Rows
                        If IsNumeric(row.Item("Total Labor Price")) Then
                            vLaborCharge = row.Item("Total Labor Price")
                            vSumLabor += vLaborCharge
                        Else
                            vLaborCharge = 0
                        End If
                        If IsNumeric(row.Item("Total Part Price")) Then
                            vRepairPartCharge = row.Item("Total Part Price")
                            vSumPart += vRepairPartCharge
                        Else
                            vRepairPartCharge = 0
                        End If
                        'If IsNumeric(row.Item("Total Shipment Price")) Then
                        '    vShipmentCharge = row.Item("Total Shipment Price")
                        '    vSumShipment += vShipmentCharge
                        'Else
                        '    vShipmentCharge = 0
                        'End If
                        vTotalBill = vLaborCharge + vRepairPartCharge
                        ' vTotalBill = vLaborCharge + vRepairPartCharge + vShipmentCharge
                        vSumTotal += vTotalBill
                        row.BeginEdit()
                        row.Item("Total Bill Price") = vTotalBill
                        row.AcceptChanges()
                        row.EndEdit()

                        'Set Device_Invoice =1 in table tDevice after the invice created
                        If IsNumeric(row.Item("Device_ID")) Then  'For those 30-day-Non-Return devices, they have no invoice_ID
                            UpdateDeviceInvoiceFlagByDeviceID(row.Item("Device_ID"))
                        End If
                    Next

                    'Add a sum row
                    row = dt.NewRow()
                    row.Item("Claim Number") = "Total"
                    row.Item("Total Labor Price") = vSumLabor
                    row.Item("Total Part Price") = vSumPart
                    ' row.Item("Total Shipment Price") = vSumShipment
                    row.Item("Total Bill Price") = vSumTotal
                    dt.Rows.Add(row)

                    dt.Columns.Remove("Device_ID") 'remove this column for the report

                    'do report
                    objExcelRpt = New ExcelReports(False)
                    objExcelRpt.RunSimpleExcelFormat(dt, strReportName, strCols, DollarNumberCol)

                End If

                Return dt.Rows.Count

            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '**************************************************************************
        Private Sub UpdateDeviceInvoiceFlagByDeviceID(ByVal iDeviceID As Integer)
            Dim strSQL As String

            Try
                strSQL = "UPDATE TDEVICE SET Device_Invoice=1 WHERE Device_ID= " & iDeviceID & ";"
                Me._objDataProc.ExecuteNonQuery(strSQL)

            Catch ex As Exception

            End Try

        End Sub

        '**************************************************************************
        Private Function WorkPerformedByDeviceID(ByVal iDeviceID As Integer) As String
            Dim strSQL As String
            Dim dt As DataTable, R As DataRow
            Dim resultStr As String = ""

            Try
                'Notes moved to TechNotes table 2013-02-20
                'strSQL = "SELECT Notes FROM ttestdata WHERE device_ID = " & iDeviceID & ";"
                strSQL = "SELECT Notes FROM technotes WHERE device_ID = " & iDeviceID & ";"
                dt = Me._objDataProc.GetDataTable(strSQL)

                If dt.Rows.Count > 0 Then
                    For Each R In dt.Rows
                        If Trim(R.Item(0)).Length > 0 Then
                            resultStr += Trim(R.Item(0)) & " "
                        End If
                    Next
                End If

                Return resultStr

            Catch ex As Exception
                Return "No data retrieved! TMIReports: WorkPerformedByDeviceID - " & ex.Message
            End Try
        End Function
        '**************************************************************************
        Private Function RepairPartChargeByDeviceID(ByVal iDeviceID As Integer) As Double
            Dim strSQL As String
            Dim dt As DataTable, R As DataRow
            Dim resultStr As Double = 0

            'No need this for TMI 
            Try
                strSQL = "SELECT Device_ID,SUM(DBill_InvoiceAmt) as Amt, MAX(Date_Rec) as DateRec,COUNT(Device_ID) as RecNum" & Environment.NewLine
                strSQL &= " FROM tdevicebill" & Environment.NewLine
                strSQL &= " WHERE Device_ID =" & iDeviceID & Environment.NewLine
                strSQL &= " GROUP BY Device_ID;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSQL)

                If dt.Rows.Count > 0 Then
                    For Each R In dt.Rows
                        If IsNumeric(R.Item("Amt")) Then
                            resultStr = R.Item("Amt")
                            Exit For
                        End If
                    Next
                End If

                Return resultStr

            Catch ex As Exception
                Return -0.01 'if there -0.01 in the invoice report, it means there id error. Need to look at it manually
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

        '**************************************************************************
        Public Function CreateExceptionRepReport(ByVal strReportName As String) As Integer
            Dim strSql As String = ""
            Dim dt As datatable
            Dim objExcelRpt As ExcelReports

            Try
                strSql = "SELECT DISTINCT A.Device_SN as 'S/N', B.ClaimNo as 'Claim #'" & Environment.NewLine
                strSql &= ", B.EstimatedTechHrs as 'Est Tech Hrs'" & Environment.NewLine
                strSql &= ", B.QuoteSubmittedDate as 'Est Tech Hrs Date'" & Environment.NewLine
                strSql &= ", B.EstimatedPartCost as 'Est Part Cost'" & Environment.NewLine
                strSql &= ", B.EstimatedPartCost_date as 'Est Part Cost Date'" & Environment.NewLine
                strSql &= "FROM tdevice A INNER JOIN extendedwarranty B ON A.WO_ID = B.WO_ID" & Environment.NewLine
                strSql &= "INNER JOIN tdevicebill C ON A.Device_ID = C.Device_ID" & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes D On C.Billcode_ID = D.Billcode_ID AND D.Billtype_ID = 1" & Environment.NewLine
                strSql &= "WHERE A.Loc_ID = " & TMI.LOCID & Environment.NewLine
                strSql &= " AND A.Device_DateShip is null AND D.Billcode_Desc = 'Exception Repairs'"
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    objExcelRpt = New ExcelReports(False)
                    objExcelRpt.RunSimpleExcelFormat(dt, strReportName, New String() {"A", "B"}, New String() {"E"})
                End If

                Return dt.Rows.Count
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************************

    End Class
End Namespace