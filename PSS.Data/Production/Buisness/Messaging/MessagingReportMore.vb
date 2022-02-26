Option Explicit On 

Imports CrystalDecisions.CrystalReports.Engine
Imports System.Drawing.Printing
Imports System.IO
Imports system.Windows.Forms

Namespace Buisness
    Public Class MessagingReportMore
        Private _objDataProc As DBQuery.DataProc
        Private _strRptPath As String = "R:\PSSInet_Reports_Prod\"

        Structure FontAttributes
            Public strFontName, strFontStyle As String
            Public iFontSize, iFontColorIndex As Integer

            Public Sub New(ByVal strName As String, ByVal strStyle As String, ByVal iSize As Integer, Optional ByVal iColorIndex As Integer = 1)
                Me.strFontName = strName
                Me.strFontStyle = strStyle
                Me.iFontSize = iSize
                Me.iFontColorIndex = iColorIndex
            End Sub
        End Structure

        '***************************************************
        Public Sub New()
            Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
        End Sub
        '***************************************************
        Protected Overrides Sub Finalize()
            Me._objDataProc = Nothing
            MyBase.Finalize()
        End Sub
        '***************************************************
        Private Sub NAR(ByVal o As Object)
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
            Catch
            Finally
                o = Nothing
            End Try
        End Sub
        '***************************************************
        'Dispose dt
        '***************************************************
        Public Function DisposeDT(ByRef dt As DataTable)
            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If
        End Function

        '******************************************************************************************************************************************
        Public Sub CreateMessagingWHReport(ByVal strCustIDs As String, ByVal bInclAllColumns As Boolean, _
                                            ByVal bSummaryOnly As Boolean, ByVal bIncludeWIPHoldInSummaryReport As Boolean, _
                                            ByRef dtResult As DataTable)

            Dim strSQL, strRptName, strS As String
            Dim dt1, dt2, dt3, dtFinal, dtCustomers, dtWIPWorkStations, dtSummary, dtSummaryFinal As DataTable
            Dim dtDetails_1 As New DataTable(), dtDetails_2 As New DataTable()
            Dim dtTmp As DataTable
            Dim row, row2 As DataRow
            Dim rowNew As DataRow
            Dim i, j, k As Integer
            Dim arrListNewKeys As New ArrayList()
            Dim arrListWorkStationIDs As New ArrayList()
            Dim dtFilteredRows() As DataRow

            Try

                'WH: In WH workstation
                strSQL = "select IF(A.Loc_ID=3404 OR A.Loc_ID=3405, CONCAT_WS(' - ', I.Cust_name1, H.Loc_Name), I.Cust_name1) as 'Customer',H.Loc_Name as 'Location', A.device_SN as 'Serial Number',D.Model_desc as 'Model Desc',F.Freq_Number as 'Frequency'" & Environment.NewLine
                strSQL &= " ,G.Baud_number as 'Baud Rate',B.CapCode"
                strSQL &= " ,CASE WHEN B.wipowner_id < 201 THEN C.wipowner_desc ELSE wip2.wipowner_desc END AS 'WIP Location'"
                strSQL &= " ,if(B.wipowner_id=3,J.cc_desc,K.wipownersubloc_desc) as 'Sublocation'"
                strSQL &= " ,W.WO_CustWO as 'Work Order',date_format(A.device_daterec,'%Y-%m-%d') as 'Received Date'" & Environment.NewLine
                strSQL &= " ,date_format(A.device_dateship,'%Y-%m-%d') as 'Produced Date'" & Environment.NewLine
                strSQL &= " ,date_format(B.wipowner_EntryDt,'%Y-%m-%d') as 'Workstation Entry Date'" & Environment.NewLine
                strSQL &= " ,E.Pallett_Name as 'Box',B.wipowner_id,C.Ams_WIPFlow,A.Device_ID,D.model_ID,F.freq_ID,G.baud_ID,A.WO_ID,A.pallett_id,I.cust_id,A.Loc_ID" & Environment.NewLine
                strSQL &= " ,Concat_WS('_','k',A.Model_ID,F.Freq_ID,G.baud_ID) as 'NewKey',Concat_WS('_','k',wip2.wipowner_id) as 'NewWSID'" & Environment.NewLine
                strSQL &= " from tdevice A" & Environment.NewLine
                strSQL &= " inner join tmessdata B on A.device_id=B.device_id" & Environment.NewLine
                strSQL &= " inner join tmodel D on A.model_ID=D.model_ID" & Environment.NewLine
                strSQL &= " inner join tlocation H on A.Loc_ID=H.Loc_ID" & Environment.NewLine
                strSQL &= " inner join tcustomer I on H.Cust_ID=I.Cust_ID" & Environment.NewLine
                strSQL &= " inner join tworkorder W on A.WO_ID=W.WO_ID" & Environment.NewLine
                strSQL &= " LEFT join lwipowner C on B.wipowner_id=C.wipowner_id" & Environment.NewLine
                strSQL &= " LEFT join lwipowner_SET2 wip2 on B.wipowner_id = wip2.wipowner_id" & Environment.NewLine
                strSQL &= " left join lfrequency F on B.freq_ID=F.freq_ID" & Environment.NewLine
                strSQL &= " left join lbaud G on B.baud_ID=G.baud_ID" & Environment.NewLine
                strSQL &= " left join tpallett E on A.pallett_id=E.pallett_id" & Environment.NewLine
                strSQL &= " left join tcostcenter J on A.cc_ID=J.cc_ID" & Environment.NewLine
                strSQL &= " left join lwipownersubloc K on B.wipownersubloc_id=K.wipownersubloc_id" & Environment.NewLine
                strSQL &= " where  "
                strSQL &= " I.cust_id in (" & strCustIDs & ") and "
                strSQL &= " A.device_DateShip is null and "
                strSQL &= " B.wipowner_id =201 and "    ' include WH only
                strSQL &= " B.wipowner_id is not null;" & Environment.NewLine
                dt1 = Me._objDataProc.GetDataTable(strSQL)
                'dtResult = dt1
                'MessageBox.Show("dt1.Rows.Count=" & dt1.Rows.Count)

                'No data
                If dt1.Rows.Count = 0 Then
                    MessageBox.Show("No data for your request.", "Information", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
                    Exit Sub
                End If


                'Get customer names
                strSQL = "select cust_ID,Cust_Name1 as 'Customer',0 as 'CountVal' from tcustomer where cust_id in (" & strCustIDs & ");"
                dtCustomers = Me._objDataProc.GetDataTable(strSQL)

                'define datatable
                dtWIPWorkStations = WIPWorkStationTableDef()

                'Re-sort it
                Dim dView As DataView = dt1.DefaultView    'New DataView(dtDockShipped)
                Dim rowView
                dView.Sort = "Customer,Location,[Serial Number],[Model Desc],Frequency,[Baud Rate]"    ',Column3 Asc" 'Desc
                dtFinal = dt1.Clone
                For Each rowView In dView
                    row = rowView.Row
                    dtFinal.ImportRow(row)

                    'get uniques keys
                    If Not arrListNewKeys.Contains(row("NewKey")) Then
                        arrListNewKeys.Add(row("NewKey"))
                    End If
                    If Not arrListWorkStationIDs.Contains(row("NewWSID")) Then
                        arrListWorkStationIDs.Add(row("NewWSID"))
                        rowNew = dtWIPWorkStations.NewRow
                        rowNew("NewWSID") = row("NewWSID")
                        rowNew("WIP Location") = row("WIP Location")
                        rowNew("Ams_WIPFlow") = row("Ams_WIPFlow")
                        dtWIPWorkStations.Rows.Add(rowNew)
                    End If
                Next
                'dtResult = dtWIPWorkStations ' dtFinal
                dt1 = Nothing : dt2 = Nothing : dt3 = Nothing : dView = Nothing

                'Re-sort dtWIPWorkStations
                Dim dView2 As DataView = dtWIPWorkStations.DefaultView
                dView2.Sort = "Ams_WIPFlow"    ' "NewWSID"

                'Creat summary data
                dtSummary = WIPSummaryTableDef()
                For Each rowView In dView2    'add columns
                    Dim newColumn1 As New DataColumn(rowView.Row("WIP Location"), GetType(System.Int32)) : dtSummary.Columns.Add(newColumn1)
                Next
                Dim newColumn2 As New DataColumn("WIP Location Total", GetType(System.Int32)) : dtSummary.Columns.Add(newColumn2)
                Dim newColumn3 As New DataColumn("Split", GetType(System.String)) : dtSummary.Columns.Add(newColumn3)
                For Each row In dtCustomers.Rows
                    Dim newColumn1 As New DataColumn(row("Customer"), GetType(System.Int32)) : dtSummary.Columns.Add(newColumn1)
                Next
                Dim newColumn4 As New DataColumn("Customer Total", GetType(System.Int32)) : dtSummary.Columns.Add(newColumn4)
                Dim newColumn5 As New DataColumn("NewKey", GetType(String)) : dtSummary.Columns.Add(newColumn5)
                'dtResult = dtSummary
                dtTmp = dtFinal.Clone : j = 0
                For i = 0 To arrListNewKeys.Count - 1
                    strS = arrListNewKeys(i)
                    dtFilteredRows = dtFinal.Select("[NewKey]='" & strS & "'")
                    If dtFilteredRows.Length > 0 Then    'it should be > 0
                        k = 0 : dtTmp.Clear()
                        For Each row In dtFilteredRows
                            dtTmp.ImportRow(row)
                            If k = 0 Then
                                rowNew = dtSummary.NewRow
                                rowNew("Model Desc") = row("Model Desc")
                                rowNew("Frequency") = row("Frequency")
                                rowNew("Baud Rate") = row("Baud Rate")
                                rowNew("NewKey") = strS
                                dtSummary.Rows.Add(rowNew)
                            End If
                            k += 1
                        Next

                        'Update count for customers
                        If bIncludeWIPHoldInSummaryReport Then
                            For Each row In dtCustomers.Rows
                                Dim objVal As Object = dtTmp.Compute("Count(Cust_ID)", "Cust_ID=" & row("Cust_ID"))
                                If Not (objVal Is DBNull.Value) AndAlso objVal > 0 Then
                                    UpdateSummaryCountVal(dtSummary, j, row("Customer"), objVal)
                                End If
                            Next
                        Else
                            For Each row In dtCustomers.Rows
                                Dim objVal As Object = dtTmp.Compute("Count(Cust_ID)", "Cust_ID=" & row("Cust_ID") & " and wipowner_id<>6")
                                If Not (objVal Is DBNull.Value) AndAlso objVal > 0 Then
                                    UpdateSummaryCountVal(dtSummary, j, row("Customer"), objVal)
                                End If
                            Next
                        End If


                        'Updatecount for workstations
                        For Each rowView In dView2
                            strS = rowView("NewWSID")
                            Dim objVal As Object = dtTmp.Compute("Count(NewWSID)", "NewWSID='" & strS & "'")
                            If Not (objVal Is DBNull.Value) AndAlso objVal > 0 Then
                                UpdateSummaryCountVal(dtSummary, j, rowView("WIP Location"), objVal)
                            End If
                        Next

                        j += 1
                        'dtResult = dtSummary
                        'If j = 100 Then Exit Sub
                    Else
                        MessageBox.Show("Can't found summary data for NewKey '" & strS & "'.", "Information", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Warning)
                    End If
                Next
                'dtResult = dtSummary
                'Exit Sub

                'Re-sort  dtSummary
                dView = dtSummary.DefaultView
                dView.Sort = "[Model Desc],Frequency,[Baud Rate]"
                dtSummaryFinal = dtSummary.Clone
                If bIncludeWIPHoldInSummaryReport Then
                    For Each rowView In dView
                        row = rowView.Row
                        dtSummaryFinal.ImportRow(row)
                    Next
                Else
                    For Each rowView In dView
                        Dim iValSum As Integer = 0
                        row = rowView.Row
                        For Each row2 In dtWIPWorkStations.Rows
                            If Not Trim(row2("WIP Location")).ToString.ToUpper = "HOLD" Then
                                If Not row.IsNull(row2("WIP Location")) Then
                                    iValSum += row(row2("WIP Location"))
                                End If
                            End If
                        Next
                        If iValSum > 0 Then
                            dtSummaryFinal.ImportRow(row)
                        End If
                    Next
                End If
                dtSummary = Nothing

                'Remove unwanted columns if need
                If Not bInclAllColumns Then
                    dtFinal.Columns.Remove("wipowner_id") : dtFinal.Columns.Remove("Device_ID") : dtFinal.Columns.Remove("model_ID")
                    dtFinal.Columns.Remove("freq_ID") : dtFinal.Columns.Remove("baud_ID") : dtFinal.Columns.Remove("WO_ID")
                    dtFinal.Columns.Remove("pallett_id") : dtFinal.Columns.Remove("cust_id") : dtFinal.Columns.Remove("NewKey")
                    dtFinal.Columns.Remove("Ams_WIPFlow") : dtFinal.Columns.Remove("NewWSID") : dtSummaryFinal.Columns.Remove("NewKey")
                    dtFinal.Columns.Remove("Loc_ID")

                End If
        
                'Summary only
                If bSummaryOnly Then
                    dtFinal.Clear()
                    dtDetails_2.Clear()
                End If

                'Do Excel report
                Dim objExcelRpt As New PSS.Data.ExcelReports()
                strRptName = "Messaging WH Report " & Format(Now, "yyyyMMdd_HHmmss")
                'objExcelRpt.RunDetailSummaryExcelFormat_MultipleSheets(dtFinal, dtSummaryFinal, strRptName, "WIP", New String() {"A", "B", "C", "D", "E", "F", "H", "I", "J", "K", "L", "M"}, )
                objExcelRpt.RunDetailSummaryExcelFormat_MultipleSheets(dtFinal, dtDetails_2, dtSummaryFinal, strRptName, "Details", "Other", New String() {"A", "B", "C", "D", "E", "F", "H", "I", "J", "K", "L", "M"}, )

                dView = Nothing : dView2 = Nothing

            Catch ex As Exception
                Throw ex
            Finally
                dt1 = Nothing : dt2 = Nothing : dt3 = Nothing : dtFinal = Nothing : dtCustomers = Nothing : dtWIPWorkStations = Nothing
                dtTmp = Nothing : dtSummary = Nothing : dtSummaryFinal = Nothing ': dtDetails_1 = Nothing : dtDetails_2 = Nothing
            End Try
        End Sub

        '******************************************************************************************************************************************
        Public Sub CreateMessagingSendToLocationShipment(ByVal strBegDate As String, ByVal strEndDate As String)
            Dim strSQL, strRptName, strS As String
            Dim dt As DataTable

            Try
                strSQL = "select B.SC_Desc as 'Send To Location',C.Pallett_Name,A.Device_SN,A.AMOTR_ManifestDT as 'Manifest Date'" & Environment.NewLine
                strSQL &= " from tam_outtorep_manifest A" & Environment.NewLine
                strSQL &= " inner join tpallett C on A.pallett_ID=C.pallett_ID" & Environment.NewLine
                strSQL &= " left join tsubcontractor B on A.SC_ID=B.SC_ID" & Environment.NewLine
                strSQL &= " where A.AMOTR_ManifestDT between '" & strBegDate & " 00:00:00' and '" & strEndDate & " 23:59:59';" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSQL)
                'No data
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("No data for your request.", "Information", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
                    Exit Sub
                End If

                'Do Excel Rpt
                Dim objExcelRpt As New PSS.Data.ExcelReports()
                strRptName = "Messaging Send-To-Location Shipment " & Format(Now, "yyyyMMdd_HHmmss")
                objExcelRpt.RunSimpleExcelFormat(dt, strRptName, New String() {"A", "B", "C", "D"})

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '******************************************************************************************************************************************
        Private Sub UpdateSummaryCountVal(ByRef dtOutput As DataTable, ByVal iRowIdx As Integer, ByVal strCustomer As String, ByVal iCountVal As Integer)
            Dim col As DataColumn
            Try
                For Each col In dtOutput.Columns
                    If strCustomer.Trim.ToUpper = col.ColumnName.Trim.ToUpper Then
                        dtOutput.Rows(iRowIdx).Item(col.ColumnName) = iCountVal
                    End If
                Next
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '******************************************************************************************************************************************
        Private Function WIPSummaryTableDef() As DataTable
            Dim dTB As New DataTable()

            dTB.Columns.Add("Model Desc", GetType(String))
            dTB.Columns.Add("Frequency", GetType(String))
            dTB.Columns.Add("Baud Rate", GetType(String))

            Return dTB
        End Function

        '******************************************************************************************************************************************
        Private Function WIPWorkStationTableDef() As DataTable
            Dim dTB As New DataTable()

            dTB.Columns.Add("NewWSID", GetType(String))
            dTB.Columns.Add("WIP Location", GetType(String))
            dTB.Columns.Add("Ams_WIPFlow", GetType(Integer))

            Return dTB
        End Function

    End Class
End Namespace
