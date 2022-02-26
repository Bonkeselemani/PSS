Namespace Buisness
    Public Class clsAvailForProd
        Private objMisc As Production.Misc
        Private objWIP As PSS.Data.Buisness.WIP

        Public Function CreateReport(ByVal strStartWorkDate As String, _
                                        ByVal strEndWorkDate As String, _
                                        ByVal iCust_ID As Integer, _
                                        ByVal iProd_ID As Integer) As Integer
            Dim dtCust, dt1, dt2 As DataTable
            Dim RCust, R1, R2, RNewRow As DataRow
            Dim iMatched As Integer = 0
            Dim i As Integer = 1

            Dim iShippedQty As Integer = 0
            Dim iWarehouseQty As Integer = 0
            Dim iStageQty As Integer = 0
            Dim iProdUnitsQty As Integer = 0
            Dim iAwaitingBillingQty As Integer = 0

            Dim iShippedQty_Total As Integer = 0
            Dim iWarehouseQty_Total As Integer = 0
            Dim iStageQty_Total As Integer = 0
            Dim iProdUnitsQty_Total As Integer = 0
            Dim iAwaitingBillingQty_Total As Integer = 0

            'Excel Related variables
            'Dim objXL As Object = Nothing
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet

            Try
                '**********************************************
                'Instantiate the excel related objects
                '**********************************************
                objExcel = New Excel.Application()      'Starts the Excel Session
                objBook = objExcel.Workbooks.Add                    'Add a Workbook
                objExcel.Application.Visible = True                'Make this false while going live
                objExcel.Application.DisplayAlerts = False
                objSheet = objBook.Worksheets.Item(1)               'Select a Sheet 1 for this

                objSheet.Cells.Select()
                objExcel.Selection.NumberFormat = "@"

                '**********************************************
                'Get Distinct Customers
                '**********************************************
                dtCust = GetWIPCustomers(iCust_ID, iProd_ID)
                For Each RCust In dtCust.Rows
                    If i > 1 Then
                        i += 3
                    End If

                    'If RCust("Cust_ID") = 2019 Then
                    '    MsgBox("stop")
                    'End If

                    '**********************************************
                    'Write the Excel Customer header
                    '**********************************************
                    objExcel.Application.Cells(i, 1).Value = "Customer"
                    objExcel.Application.Cells(i, 2).Value = "Manufacturer"
                    objExcel.Application.Cells(i, 3).Value = "Model"
                    objExcel.Application.Cells(i, 4).Value = "Units Shipped"
                    objExcel.Application.Cells(i, 5).Value = "Warehouse Units"
                    objExcel.Application.Cells(i, 6).Value = "Stage Units"
                    objExcel.Application.Cells(i, 7).Value = "Production Units"
                    objExcel.Application.Cells(i, 8).Value = "Awaiting Billing"

                    '**********************************************
                    'Step 1: Get all open Models for this customer
                    '**********************************************
                    'Part A: Get Production WIP Models
                    dt1 = GetProductionWIPModels(RCust("Cust_ID"))

                    'Part B: Get all Warehouse WIP models (ONly for ATCLE-AWS(2019) and BRIGHTPOINT(2113) customers
                    If RCust("Cust_ID") = 2019 Or RCust("Cust_ID") = 2113 Then
                        dt2 = GetWarehouseModels(RCust("Cust_ID"))

                        'Merge Both Warehouse and ProdWIP Models in to one common list
                        For Each R2 In dt2.Rows
                            For Each R1 In dt1.Rows
                                If R2("Model_ID") = R1("Model_ID") Then
                                    iMatched = 1
                                    Exit For
                                End If
                            Next R1

                            If iMatched = 0 Then
                                'Add the model to dt1
                                RNewRow = dt1.NewRow
                                RNewRow("Cust_ID") = R2("Cust_ID")
                                RNewRow("Cust_Name1") = R2("Cust_Name1")
                                RNewRow("Manuf_Desc") = R2("Manuf_Desc")
                                RNewRow("Model_ID") = R2("Model_ID")
                                RNewRow("Model_Desc") = R2("Model_Desc")
                                RNewRow("prod_id") = R2("prod_id")
                                dt1.Rows.Add(RNewRow)
                                dt1.AcceptChanges()
                                RNewRow = Nothing
                            End If

                            iMatched = 0
                        Next R2
                    End If
                    '****************************************************
                    R1 = Nothing
                    R2 = Nothing
                    RNewRow = Nothing
                    If Not IsNothing(dt2) Then
                        dt2.Dispose()
                        dt2 = Nothing
                    End If
                    '****************************************************
                    For Each R1 In dt1.Rows
                        'If R1("Model_ID") = 887 Then
                        '    MsgBox("stop")
                        'End If
                        '****************************************************
                        'STEP 2: Get Units Shipped for the customer and Model
                        '****************************************************
                        iShippedQty = GetShippedQty(R1("Cust_ID"), R1("Model_ID"), strStartWorkDate, strEndWorkDate)
                        '****************************************************
                        'STEP 3: Get WarehouseUnits
                        '****************************************************
                        If RCust("Cust_ID") = 2019 Or RCust("Cust_ID") = 2113 Then
                            iWarehouseQty = GetWarehouseQty(R1("Cust_ID"), R1("Model_ID"))
                        End If
                        '****************************************************
                        'Step 4: Stage Units
                        '****************************************************
                        If RCust("Cust_ID") = 2019 Then
                            iStageQty = GetStageQty(R1("Cust_ID"), R1("Model_ID"))
                        End If
                        '****************************************************
                        'Step 5: Production Units
                        '****************************************************
                        iProdUnitsQty = GetProductionQty(R1("Cust_ID"), R1("Model_ID"), R1("Prod_ID"))
                        '****************************************************
                        'Step 6: Get Awaiting Billing Quantity
                        '****************************************************
                        iAwaitingBillingQty = iWarehouseQty + iStageQty
                        '****************************************************
                        'Write Excel Body
                        '****************************************************
                        i += 1
                        If Not IsDBNull(R1("cust_name1")) Then
                            objExcel.Application.Cells(i, 1).Value = R1("cust_name1")
                        End If
                        If Not IsDBNull(R1("Manuf_Desc")) Then
                            objExcel.Application.Cells(i, 2).Value = R1("Manuf_Desc")
                        End If
                        If Not IsDBNull(R1("Model_Desc")) Then
                            objExcel.Application.Cells(i, 3).Value = R1("Model_Desc")
                        End If

                        objExcel.Application.Cells(i, 4).Value = iShippedQty
                        objExcel.Application.Cells(i, 5).Value = iWarehouseQty
                        objExcel.Application.Cells(i, 6).Value = iStageQty
                        objExcel.Application.Cells(i, 7).Value = iProdUnitsQty
                        objExcel.Application.Cells(i, 8).Value = iAwaitingBillingQty

                        '****************************************************
                        'Step 7: Totals
                        '****************************************************
                        iShippedQty_Total += iShippedQty
                        iWarehouseQty_Total += iWarehouseQty
                        iStageQty_Total += iStageQty
                        iProdUnitsQty_Total += iProdUnitsQty
                        iAwaitingBillingQty_Total += iAwaitingBillingQty
                        '****************************************************
                        iShippedQty = 0
                        iWarehouseQty = 0
                        iStageQty = 0
                        iProdUnitsQty = 0
                        iAwaitingBillingQty = 0
                        '****************************************************
                    Next R1

                    '********************************************************
                    'Write TOTAL line for the Customer
                    '********************************************************
                    i += 1
                    objExcel.Application.Cells(i, 3).Value = "TOTAL"
                    objExcel.Application.Cells(i, 4).Value = iShippedQty_Total
                    objExcel.Application.Cells(i, 5).Value = iWarehouseQty_Total
                    objExcel.Application.Cells(i, 6).Value = iStageQty_Total
                    objExcel.Application.Cells(i, 7).Value = iProdUnitsQty_Total
                    objExcel.Application.Cells(i, 8).Value = iAwaitingBillingQty_Total

                    '********************************************************
                    iShippedQty_Total = 0
                    iWarehouseQty_Total = 0
                    iStageQty_Total = 0
                    iProdUnitsQty_Total = 0
                    iAwaitingBillingQty_Total = 0
                    '********************************************************
                Next RCust

                Return 1
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dtCust) Then
                    dtCust.Dispose()
                    dtCust = Nothing
                End If
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                If Not IsNothing(dt2) Then
                    dt2.Dispose()
                    dt2 = Nothing
                End If
                '*************************************
                'Excel clean up
                'If Not IsNothing(objSheet) Then
                '    objSheet = Nothing
                '    NAR(objSheet)
                'End If
                'If Not IsNothing(objBook) Then
                '    objBook.Close()
                '    objBook = Nothing
                '    NAR(objBook)
                'End If
                'If Not IsNothing(objExcel) Then
                '    objExcel.Quit()
                '    objExcel = Nothing
                '    NAR(objExcel)
                'End If
                GC.Collect()
                GC.WaitForPendingFinalizers()

            End Try

        End Function

        Private Function GetProductionQty(ByVal iCust_ID As Integer, _
                                        ByVal iModel_ID As Integer, _
                                        ByVal iProd_ID As Integer) As Integer
            Dim strsql As String = ""
            Dim R1 As DataRow
            Dim dt1 As DataTable
            Dim i As Integer = 0
            Try
                If iProd_ID = 2 Then    'Cell
                    'Cellular1
                    dt1 = objWIP.GetWIP(iCust_ID, 2, iModel_ID, "Refurb")
                    i = dt1.Rows.Count
                    If Not IsNothing(dt1) Then
                        dt1.Dispose()
                        dt1 = Nothing
                    End If

                    'Cellular2
                    dt1 = objWIP.GetWIP(iCust_ID, 3, iModel_ID, "Refurb")
                    i += dt1.Rows.Count

                    Return i
                ElseIf iProd_ID = 1 Then    'Messaging
                    strsql = "Select Count(*) as cnt " & Environment.NewLine
                    strsql &= "from tdevice " & Environment.NewLine
                    strsql &= "inner join tworkorder on tdevice.wo_id = tworkorder.WO_ID " & Environment.NewLine
                    strsql &= "inner join tlocation on tdevice.loc_id = tlocation.Loc_ID " & Environment.NewLine
                    strsql &= "where " & Environment.NewLine
                    strsql &= "tworkorder.Prod_ID = 1 and " & Environment.NewLine
                    strsql &= "tlocation.Cust_ID = " & iCust_ID & " and " & Environment.NewLine
                    strsql &= "tdevice.model_id = " & iModel_ID & " and " & Environment.NewLine
                    strsql &= "tdevice.Device_DateShip is NULL;"

                    objMisc._SQL = strsql
                    dt1 = objMisc.GetDataTable
                    R1 = dt1.Rows(0)
                    Return R1("cnt")
                End If


            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        Private Function GetStageQty(ByVal iCust_ID As Integer, _
                                    ByVal iModel_ID As Integer) As Integer
            Dim strsql As String = ""
            Dim R1 As DataRow
            Dim dt1 As DataTable
            Dim i As Integer = 0

            Try
                'Cellular1 Stage1 (Not Production Rcvd)
                dt1 = objWIP.GetTriageWIP1(iCust_ID, 5, iModel_ID, "Refurb")
                i = dt1.Rows.Count
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If

                'Cellular1 Stage1 (Production Rcvd)
                dt1 = objWIP.GetWIP(iCust_ID, 5, iModel_ID, "Refurb")
                i += dt1.Rows.Count
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If

                'Cellular2 Stage1 (Not Production Rcvd)
                dt1 = objWIP.GetTriageWIP1(iCust_ID, 11, iModel_ID, "Refurb")
                i += dt1.Rows.Count
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If

                'Cellular2 Stage1 (Production Rcvd)
                dt1 = objWIP.GetWIP(iCust_ID, 11, iModel_ID, "Refurb")
                i += dt1.Rows.Count

                Return i

            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        Private Function GetWarehouseQty(ByVal iCust_ID As Integer, _
                                        ByVal iModel_ID As Integer) As Integer
            Dim strsql As String = ""
            Dim R1 As DataRow
            Dim dt1 As DataTable

            Try
                If iCust_ID = 2019 Then     'ATCLE-AWS
                    strsql = "Select Count(*) as cnt " & Environment.NewLine
                    strsql &= "from twarehousepalletload " & Environment.NewLine
                    strsql &= "inner join twarehousepallet on twarehousepalletload.WHPallet_ID = twarehousepallet.WHPallet_ID " & Environment.NewLine
                    strsql &= "where whp_rcvdflag = 8 and " & Environment.NewLine
                    strsql &= "twarehousepallet.Cust_ID = " & iCust_ID & " and " & Environment.NewLine
                    strsql &= "twarehousepallet.WH_PalletType = 'Refurb' and " & Environment.NewLine
                    strsql &= "twarehousepallet.Model_ID = " & iModel_ID & ";"
                    objMisc._SQL = strsql
                    dt1 = objMisc.GetDataTable
                    R1 = dt1.Rows(0)
                    Return R1("cnt")
                ElseIf iCust_ID = 2113 Then 'Brightpoint
                    strsql = "Select  Count(*) as cnt " & Environment.NewLine
                    strsql &= "from cstincomingdata " & Environment.NewLine
                    strsql &= "inner join cs_partmap on cstincomingdata.csin_itemnum = cs_partmap.part_number " & Environment.NewLine
                    strsql &= "inner join tmodel on cs_partmap.model_id = tmodel.model_id " & Environment.NewLine
                    strsql &= "inner join lmanuf on tmodel.manuf_id = lmanuf.manuf_id " & Environment.NewLine
                    strsql &= "where closedstatussent = 0 and " & Environment.NewLine
                    strsql &= "cs_partmap.model_id = " & iModel_ID & " and " & Environment.NewLine
                    strsql &= "flgreceived = 0;"
                    objMisc._SQL = strsql
                    dt1 = objMisc.GetDataTable
                    R1 = dt1.Rows(0)
                    Return R1("cnt")
                End If
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try

        End Function

        Private Function GetShippedQty(ByVal iCust_ID As Integer, _
                                        ByVal iModel_ID As Integer, _
                                        ByVal strStartWorkDt As String, _
                                        ByVal strEndWorkDt As String) As Integer
            Dim strsql As String = ""
            Dim R1 As DataRow
            Dim dt1 As DataTable

            Try
                strsql = "Select tdevice.Device_ID " & Environment.NewLine
                strsql &= "from tdevice inner join tlocation on tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strsql &= "where tlocation.Cust_ID = " & iCust_ID & " and " & Environment.NewLine
                strsql &= "tdevice.Model_ID = " & iModel_ID & " and " & Environment.NewLine
                strsql &= "Device_ShipWorkDate >= '" & strStartWorkDt & "' and " & Environment.NewLine
                strsql &= "Device_ShipWorkDate <= '" & strEndWorkDt & "';"
                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable

                Return dt1.Rows.Count

            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        Private Function GetWIPCustomers(ByVal iCust_ID As Integer, _
                                        ByVal iProd_ID As Integer) As DataTable
            Dim strsql As String = ""

            Try
                strsql = "Select distinct tcustomer.cust_id, tcustomer.cust_name1, tmodel.prod_id " & Environment.NewLine
                strsql &= "from tdevice inner join tlocation on tdevice.loc_id = tlocation.loc_id " & Environment.NewLine
                strsql &= "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & Environment.NewLine
                strsql &= "inner join tmodel on tdevice.model_id = tmodel.Model_ID " & Environment.NewLine
                strsql &= "where tdevice.Device_DateShip is null and " & Environment.NewLine
                strsql &= "cust_name2 is null " & Environment.NewLine
                If iCust_ID > 0 Then
                    strsql &= " and tcustomer.cust_id = " & iCust_ID & " " & Environment.NewLine
                End If
                If iProd_ID > 0 Then
                    strsql &= " and tmodel.prod_id = " & iProd_ID & " " & Environment.NewLine
                Else
                    strsql &= " and tmodel.prod_id in (1, 2) " & Environment.NewLine
                End If

                strsql &= "order by tmodel.prod_id, cust_name1;"
                objMisc._SQL = strsql
                Return objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Private Function GetWarehouseModels(ByVal iCust_ID As Integer) As DataTable
            Dim strsql As String = ""

            Try
                If iCust_ID = 2019 Then
                    strsql = "Select Distinct 2019 as Cust_ID, 'ATCLE - AWS' as Cust_Name1, lmanuf.Manuf_Desc, tmodel.Model_ID, tmodel.Model_Desc, tmodel.prod_id " & Environment.NewLine
                    strsql &= "from twarehousepallet " & Environment.NewLine
                    strsql &= "inner join tmodel on twarehousepallet.Model_ID = tmodel.Model_ID " & Environment.NewLine
                    strsql &= "inner join lmanuf on tmodel.manuf_id = lmanuf.manuf_id " & Environment.NewLine
                    strsql &= "where twarehousepallet.WHP_PalletRcvd = 0 and " & Environment.NewLine
                    strsql &= "Cust_ID = 2019 and " & Environment.NewLine
                    strsql &= "twarehousepallet.WH_PalletType = 'Refurb' " & Environment.NewLine
                    strsql &= "order by tmodel.prod_id, tmodel.Model_ID;"
                ElseIf iCust_ID = 2113 Then
                    strsql = "Select Distinct 2113 as Cust_ID, 'Brightpoint' as Cust_Name1, lmanuf.Manuf_Desc, tmodel.Model_ID, tmodel.Model_Desc, tmodel.prod_id " & Environment.NewLine
                    strsql &= "from cstincomingdata " & Environment.NewLine
                    strsql &= "inner join cs_partmap on cstincomingdata.csin_itemnum = cs_partmap.part_number " & Environment.NewLine
                    strsql &= "inner join tmodel on cs_partmap.Model_ID = tmodel.Model_ID " & Environment.NewLine
                    strsql &= "inner join lmanuf on tmodel.manuf_id = lmanuf.manuf_id " & Environment.NewLine
                    strsql &= "where closedstatussent = 0 and " & Environment.NewLine
                    strsql &= "cs_partmap.model_id is not null and " & Environment.NewLine
                    strsql &= "flgreceived = 0 " & Environment.NewLine
                    strsql &= "order by tmodel.prod_id, tmodel.Model_ID;"
                End If

                objMisc._SQL = strsql
                Return objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Private Function GetProductionWIPModels(ByVal iCust_ID As Integer) As DataTable
            Dim strsql As String = ""

            Try
                strsql = "Select Distinct tcustomer.Cust_ID, tcustomer.Cust_Name1, lmanuf.Manuf_Desc, tmodel.Model_ID, tmodel.Model_Desc, tmodel.prod_id, '' as 'Units Shipped', '' as 'Warehouse Units', '' as 'Stage Units', '' as 'Production Units' " & Environment.NewLine
                strsql &= "from tdevice " & Environment.NewLine
                strsql &= "inner join tmodel on tdevice.model_id = tmodel.Model_ID " & Environment.NewLine
                strsql &= "inner join lmanuf on tmodel.manuf_id = lmanuf.manuf_id " & Environment.NewLine
                strsql &= "inner join tlocation on tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strsql &= "inner join tcustomer on tlocation.cust_id = tcustomer.Cust_ID " & Environment.NewLine
                strsql &= "where tdevice.Device_DateShip is null and " & Environment.NewLine
                strsql &= "tlocation.cust_id = " & iCust_ID & " " & Environment.NewLine
                strsql &= "order by tmodel.prod_id, tmodel.Model_ID;"
                objMisc._SQL = strsql
                Return objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Sub New()
            objMisc = New Production.Misc()
            objWIP = New PSS.Data.Buisness.WIP()
        End Sub
        Protected Overrides Sub Finalize()
            objMisc = Nothing
            objWIP = Nothing
            MyBase.Finalize()
        End Sub
        '**********************************************************
        Private Sub NAR(ByVal o As Object)
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
            Catch
            Finally
                o = Nothing
            End Try
        End Sub
        '**********************************************************
    End Class
End Namespace
