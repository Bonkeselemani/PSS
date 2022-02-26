Option Explicit On 

Imports System.Data
Imports System.IO
'Imports System.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine

Namespace Buisness
    Public Class SkullcandyPrint

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


#End Region

        '********************************************************************************
        ' Public Function Print_ReceivingPalletReport(ByVal dtInput As DataTable, _
        '                                     ByVal iCopies As Integer) As Integer
        Public Function Print_ReceivingPalletReport(ByVal strPalletName As String, _
                                                    ByVal strModelDesc As String, _
                                                    ByVal strRetailer As String, _
                                                    ByVal iQty As Integer, _
                                                    ByVal iCopies As Integer) As Integer

            Dim row As DataRow, row2 As DataRow
            Dim i As Integer, iTotalQty As Integer = 0
            Dim dt As DataTable
            Dim objRpt As ReportDocument

            Try
                dt = ReportReceivingPalletTableDefinition()
                'i = 1
                'For Each row In dtInput.Rows
                'If i = 1 Then iTotalQty = dtInput.Compute("SUM(Qty)", "")
                row2 = dt.NewRow
                row2("PalletName") = strPalletName 'row("PalletName")
                row2("ModelDesc") = strModelDesc ' row("ModelDesc")
                row2("Qty") = iQty ' row("Qty")
                row2("TotalQty") = iQty ' iTotalQty
                row2("Model_ID") = 0 'row("Model_ID")
                row2("WO_ID") = 0 ' row("WO_ID")
                row2("Other1") = 0
                'If IsDate(row("UpdateDT")) Then
                '    row2("Other2") = Format(row("UpdateDT"), "yyyy-MM-dd")
                'Else
                '    row2("Other2") = row("UpdateDT")
                'End If
                row2("Other2") = strRetailer
                dt.Rows.Add(row2)
                'i += 1
                ' Next

                objRpt = New ReportDocument()
                With objRpt
                    .Load(PSS.Data.ConfigFile.GetBaseReportPath & "Skullcandy Receiving Pallet Push.rpt")
                    If Not IsNothing(dt) Then .SetDataSource(dt)
                    .Refresh()
                    .PrintToPrinter(iCopies, True, 0, 0)
                End With
            Catch ex As Exception
                Throw ex
            Finally
                ' PSS.Data.Buisness.Generic.DisposeDT(dtInput)
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try

        End Function

        '********************************************************************************
        Public Function Print_SKAstroWHReceivingReport(ByVal dtInput As DataTable, _
                                                    ByVal iCopies As Integer) As Integer

            Dim row As DataRow, row2 As DataRow
            Dim i As Integer, iTotalQty As Integer = 0
            Dim dt As DataTable
            Dim objRpt As ReportDocument

            Try
                dt = SkullcandyAstroWHReceivingTableDefinition()
                ' i = 1
                For Each row In dtInput.Rows
                    ' If i = 1 Then iTotalQty = dtInput.Compute("SUM(Qty)", "")
                    row2 = dt.NewRow
                    row2("WorkOrder") = row("WorkOrder")
                    row2("Model") = row("Model")
                    row2("ModelDesc") = row("ModelDesc")
                    row2("ItemDesc") = row("ItemDesc")
                    row2("Qty") = row("Qty")
                    row2("Retailer") = row("Retailer")
                    row2("Other1") = ""
                    row2("Other2") = ""
                    row2("Other3") = 0
                    row2("Other4") = 0
                    dt.Rows.Add(row2)
                    ' i += 1
                Next


                objRpt = New ReportDocument()
                With objRpt
                    .Load(PSS.Data.ConfigFile.GetBaseReportPath & "SkullcandyAstro Warehouse Receiving Push.rpt")
                    If Not IsNothing(dt) Then .SetDataSource(dt)
                    .Refresh()
                    .PrintToPrinter(iCopies, True, 0, 0)
                End With
            Catch ex As Exception
                Throw ex
            Finally
                ' PSS.Data.Buisness.Generic.DisposeDT(dtInput)
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try

        End Function

        '******************************************************************
        Public Function Print_AstroShipBoxMasterLabel(ByVal strProd As String, _
                                                      ByVal strProdDesc As String, _
                                                      ByVal strMasterCode As String, _
                                                      ByVal strOverPackName As String, _
                                                      ByVal iQty As Integer, _
                                                      ByVal iCopies As Integer) As Integer
            Dim strsql As String = ""
            Dim objRpt As ReportDocument
            Dim dt As DataTable

            Try

                strsql = "Select '" & strProd & "' AS Product" & Environment.NewLine
                strsql &= ", '" & strProdDesc & "' AS ProdDesc" & Environment.NewLine
                strsql &= "," & iQty & " AS Qty" & Environment.NewLine
                strsql &= ", '" & strMasterCode & "' AS MasterCode" & Environment.NewLine
                strsql &= ", '" & strOverPackName & "' AS Pallet" & Environment.NewLine
                strsql &= ", '' AS SN1,'' AS SN2,'' AS Other1,'' AS Other2,0 AS Other3,0 AS Other4" & Environment.NewLine

                objRpt = New ReportDocument()

                With objRpt
                    .Load(PSS.Data.ConfigFile.GetBaseReportPath & "Skullcandy ProdutionShip 1X2 Box Push.rpt") '"Skullcandy ProdutionShip 4X4 Pallet Push.rpt")
                    dt = Me._objDataProc.GetDataTable(strsql)
                    If Not IsNothing(dt) Then .SetDataSource(dt)
                    ' .PrintOptions.PrinterName = "EasyCoder12" ' "EasyCoder44"
                    .Refresh()
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

        '******************************************************************
        Public Function Print_AstroShipBoxLabel(ByVal strOverPackName As String, _
                                                      ByVal iCopies As Integer) As Integer
            Dim strsql As String = ""
            Dim objRpt As ReportDocument
            Dim dt As DataTable

            Try

                strsql = "Select '' AS Product" & Environment.NewLine
                strsql &= ", '' AS ProdDesc" & Environment.NewLine
                strsql &= ",0 AS Qty" & Environment.NewLine
                strsql &= ", '' AS MasterCode" & Environment.NewLine
                strsql &= ", '" & strOverPackName & "' AS Pallet" & Environment.NewLine
                strsql &= ", '' AS SN1,'' AS SN2,'' AS Other1,'' AS Other2,0 AS Other3,0 AS Other4" & Environment.NewLine

                objRpt = New ReportDocument()

                With objRpt
                    .Load(PSS.Data.ConfigFile.GetBaseReportPath & "Skullcandy ProdutionShip 1X2 Pallet Push.rpt")
                    dt = Me._objDataProc.GetDataTable(strsql)
                    If Not IsNothing(dt) Then .SetDataSource(dt)
                    '.PrintOptions.PrinterName = "EasyCoder12"
                    .Refresh()
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

        '******************************************************************
        Public Function Print_RetailInnerMasterPackLabel(ByVal strUPC As String, _
                                                         ByVal strModel As String, _
                                                         ByVal strDisposition As String, _
                                                         ByVal strShelfLocation As String, _
                                                         ByVal strMasterPackID As String, _
                                                         ByVal iQty As Integer, _
                                                         ByVal iCopies As Integer, _
                                                         Optional ByVal strPrinterName As String = "") As Integer

            'Both Inner Pack and Master Pack use the same label
            'let's use masterpack label for both

            Dim strsql As String = ""
            Dim objRpt As ReportDocument
            Dim dt As DataTable

            Try

                strsql = "Select '" & strUPC & "' AS UPC" & Environment.NewLine
                strsql &= ", '" & strModel & "' AS Model" & Environment.NewLine
                strsql &= ", '" & strDisposition & "' AS Disposition" & Environment.NewLine
                strsql &= ", '" & strShelfLocation & "' AS Disposition2" & Environment.NewLine
                strsql &= ", '" & strMasterPackID & "' AS Other1" & Environment.NewLine
                strsql &= "," & iQty & " AS Qty" & Environment.NewLine

                objRpt = New ReportDocument()

                With objRpt
                    .Load(PSS.Data.ConfigFile.GetBaseReportPath & "Skullcandy MaterPack Push.rpt")
                    dt = Me._objDataProc.GetDataTable(strsql)
                    If Not IsNothing(dt) Then .SetDataSource(dt)
                    If strPrinterName.Trim.Length > 0 Then
                        .PrintOptions.PrinterName = strPrinterName.Trim ' "EasyCoder" ' "EasyCoder44"
                    End If
                    .Refresh()
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


        '******************************************************************
        Public Function Print_RetailMasterPackLabel(ByVal iMP_ID As Integer, ByVal iCopies As Integer, ByVal strPrinterName As String) As Integer
            'ByVal strModel As String, _
            'ByVal strDisposition As String, _
            'ByVal strShelfLocation As String, _
            'ByVal strMasterPackID As String, _
            'ByVal iQty As Integer, _
            'ByVal iCopies As Integer) As Integer

            'Inner Pack 
            Dim strSQL As String = ""
            Dim objRpt As ReportDocument
            Dim dt As DataTable

            Try

                strSQL &= "select A.UPC,A.Sku AS Model,A.Location AS Disposition2,A.Qty,A.MP_ID AS InnerPackQty,A.MaxQty,A.TotalInnerPack,B.DCode_SDesc as Disposition,B.DCode_LDesc" & Environment.NewLine
                strSQL &= "from tsk_masterpack A" & Environment.NewLine
                strSQL &= "inner join lcodesdetail B on A.DCode_ID=B.DCode_ID" & Environment.NewLine
                strSQL &= "Where MP_ID=" & iMP_ID & Environment.NewLine


                'strSQL = "Select '" & strUPC & "' AS UPC" & Environment.NewLine
                'strSQL &= ", '" & strModel & "' AS Model" & Environment.NewLine
                'strSQL &= ", '" & strDisposition & "' AS Disposition" & Environment.NewLine
                'strSQL &= ", '" & strShelfLocation & "' AS Disposition2" & Environment.NewLine
                'strSQL &= ", '" & strMasterPackID & "' AS Other1" & Environment.NewLine
                'strSQL &= "," & iQty & " AS Qty" & Environment.NewLine

                objRpt = New ReportDocument()

                With objRpt
                    .Load(PSS.Data.ConfigFile.GetBaseReportPath & "Skullcandy MaterPack Push.rpt")
                    dt = Me._objDataProc.GetDataTable(strSQL)
                    If Not IsNothing(dt) Then .SetDataSource(dt)
                    If strPrinterName.Trim.Length > 0 Then
                        .PrintOptions.PrinterName = strPrinterName.Trim ' "EasyCoder" ' "EasyCoder44"
                    End If
                    .Refresh()
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

        '******************************************************************
        Public Function Print_RetailInnerPackLabel(ByVal iIP_ID As Integer, ByVal iCopies As Integer, ByVal strPrinterName As String) As Integer

            'Inner Pack 
            Dim strSQL As String = ""
            Dim objRpt As ReportDocument
            Dim dt As DataTable

            Try

                strSQL &= "select A.UPC, A.Sku AS Model " & Environment.NewLine
                strSQL &= ",B.DCode_SDesc as Disposition, A.Location AS Disposition2 " & Environment.NewLine
                strSQL &= ", A.Qty ,A.IP_ID AS InnerPackQty, A.MaxQty, A.MP_ID as MasterPackID, A.IP_ID as InnerPackID " & Environment.NewLine
                strSQL &= "from tsk_innerpack A" & Environment.NewLine
                strSQL &= "inner join lcodesdetail B on A.DCode_ID=B.DCode_ID" & Environment.NewLine
                strSQL &= "Where IP_ID=" & iIP_ID & Environment.NewLine


                'strSQL = "Select '" & strUPC & "' AS UPC" & Environment.NewLine
                'strSQL &= ", '" & strModel & "' AS Model" & Environment.NewLine
                'strSQL &= ", '" & strDisposition & "' AS Disposition" & Environment.NewLine
                'strSQL &= ", '" & strShelfLocation & "' AS Disposition2" & Environment.NewLine
                'strSQL &= ", '" & strMasterPackID & "' AS Other1" & Environment.NewLine
                'strSQL &= "," & iQty & " AS Qty" & Environment.NewLine

                objRpt = New ReportDocument()

                With objRpt
                    .Load(PSS.Data.ConfigFile.GetBaseReportPath & "Skullcandy InnerPack Push.rpt")
                    dt = Me._objDataProc.GetDataTable(strSQL)
                    If Not IsNothing(dt) Then .SetDataSource(dt)
                    If strPrinterName.Trim.Length > 0 Then
                        .PrintOptions.PrinterName = strPrinterName.Trim ' "EasyCoder" ' "EasyCoder44"
                    End If

                    .Refresh()
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

        '******************************************************************
        Public Function Print_RetailShelfLocationLabel(ByVal strDisposition As String, _
                                                       ByVal strShelfLocation As String, _
                                                       ByVal iCopies As Integer, _
                                                       ByVal iDeviceID As Integer, _
                                                       ByVal strPrinterName As String) As Integer

            'Both Inner Pack and Master Pack use the same label
            'let's use masterpack label for both

            Dim strsql As String = ""
            Dim objRpt As ReportDocument
            Dim dt As DataTable

            Try

                strsql = "Select '" & strDisposition & "' AS Disposition" & Environment.NewLine
                strsql &= ", '" & strShelfLocation & "' AS Localtion" & Environment.NewLine
                strsql &= ", '" & iDeviceID & "' AS Other1" & Environment.NewLine

                objRpt = New ReportDocument()

                With objRpt
                    .Load(PSS.Data.ConfigFile.GetBaseReportPath & "Skullcandy ShelfLocation Push.rpt")
                    dt = Me._objDataProc.GetDataTable(strsql)
                    If Not IsNothing(dt) Then .SetDataSource(dt)
                    If strPrinterName.Trim.Length > 0 Then
                        .PrintOptions.PrinterName = strPrinterName.Trim ' "EasyCoder" ' "EasyCoder44"
                    End If
                    .Refresh()
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

        '******************************************************************
        Public Function Print_AstroShipBoxSNLabel(ByVal strSN1 As String, _
                                                  ByVal strSN2 As String, _
                                                  ByVal iCopies As Integer) As Integer
            Dim strsql As String = ""
            Dim objRpt As ReportDocument
            Dim dt As DataTable

            Try
                strsql = "Select '' AS Product" & Environment.NewLine
                strsql &= ", '' AS ProdDesc" & Environment.NewLine
                strsql &= ",0 AS Qty" & Environment.NewLine
                strsql &= ", '' AS MasterCode" & Environment.NewLine
                strsql &= ", '' AS Pallet" & Environment.NewLine
                strsql &= ", '" & strSN1 & "' AS SN1,'" & strSN2 & "' AS SN2,'' AS Other1,'' AS Other2,0 AS Other3,0 AS Other4" & Environment.NewLine

                objRpt = New ReportDocument()

                With objRpt
                    .Load(PSS.Data.ConfigFile.GetBaseReportPath & "Skullcandy ProdutionShip 1X2 Bundle Push.rpt")
                    dt = Me._objDataProc.GetDataTable(strsql)
                    If Not IsNothing(dt) Then .SetDataSource(dt)
                    '.PrintOptions.PrinterName = "EasyCoder12"
                    .Refresh()
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

        '******************************************************************
        Public Function Print_RetailRMALabel(ByVal strRMA As String, ByVal iCopies As Integer, Optional ByVal strPrinterName As String = "") As Integer

            'Both Inner Pack and Master Pack use the same label
            'let's use masterpack label for both

            Dim strsql As String = ""
            Dim objRpt As ReportDocument
            Dim dt As DataTable

            Try
                strsql = "Select '" & strRMA & "' AS RMA" & Environment.NewLine

                objRpt = New ReportDocument()

                With objRpt
                    .Load(PSS.Data.ConfigFile.GetBaseReportPath & "Skullcandy RMA Number Push.rpt")
                    dt = Me._objDataProc.GetDataTable(strsql)
                    If Not IsNothing(dt) Then .SetDataSource(dt)
                    If strPrinterName.Trim.Length > 0 Then
                        .PrintOptions.PrinterName = strPrinterName.Trim ' "EasyCoder" ' "EasyCoder44"
                    End If
                    .Refresh()
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

        '******************************************************************
        Public Function Print_RetailPalletReport(ByVal iPallettID As String, ByVal iCopies As Integer) As Integer
            Dim strSQL As String = ""
            Dim objRpt As ReportDocument
            Dim dt As DataTable


            Try
                strSQL = "SELECT A.UPC as 'UPC', A.Sku as 'Sku'," & Environment.NewLine
                strSQL &= "B.Dcode_Ldesc as 'Disposition', C.Pallett_Name, CAST(MP_ID as CHAR) as 'MP_ID', CAST(Count(*) as CHAR) as 'Qty' " & Environment.NewLine
                strSQL &= "FROM tsk_device A INNER JOIN lcodesdetail B ON A.DCode_ID = B.Dcode_ID " & Environment.NewLine
                strSQL &= "INNER JOIN tpallett C ON A.Pallet_ID = C.Pallett_ID  " & Environment.NewLine
                strSQL &= "where C.Pallett_ID = " & iPallettID & Environment.NewLine
                strSQL &= "GROUP BY UPC, Sku, Disposition, C.Pallett_Name, MP_ID " & Environment.NewLine
                strSQL &= "union " & Environment.NewLine
                strSQL &= "select 'Total' as 'UPC', ' ' as 'Sku', ' '  as 'Disposition', C.Pallett_Name, Null as 'MP_ID', CAST(Count(*) as CHAR) as 'Qty'" & Environment.NewLine
                strSQL &= "from tsk_device A INNER JOIN lcodesdetail B ON A.DCode_ID = B.Dcode_ID" & Environment.NewLine
                strSQL &= "INNER JOIN tpallett C ON A.Pallet_ID = C.Pallett_ID " & Environment.NewLine
                strSQL &= "where C.Pallett_ID = " & iPallettID & Environment.NewLine
                strSQL &= "GROUP BY UPC, Sku, Disposition, C.Pallett_Name, MP_ID" & Environment.NewLine

                objRpt = New ReportDocument()

                With objRpt
                    .Load(PSS.Data.ConfigFile.GetBaseReportPath & "Skullcandy Pallet Push.rpt")
                    dt = Me._objDataProc.GetDataTable(strSQL)
                    If dt.Rows.Count > 0 Then

                        dt.Rows(dt.Rows.Count - 1).Item("Sku") = dt.Rows.Count - 1
                        dt.Rows(dt.Rows.Count - 1).Item("MP_ID") = DBNull.Value
                    End If

                    If Not IsNothing(dt) Then .SetDataSource(dt)

                    .Refresh()
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

        '******************************************************************
        Public Function ReportReceivingPalletTableDefinition() As DataTable
            Dim dTB As New DataTable()

            dTB.Columns.Add("PalletName", GetType(String))
            dTB.Columns.Add("ModelDesc", GetType(String))
            dTB.Columns.Add("Qty", GetType(Integer))
            dTB.Columns.Add("TotalQty", GetType(Integer))
            dTB.Columns.Add("Model_ID", GetType(Integer))
            dTB.Columns.Add("WO_ID", GetType(Integer))
            dTB.Columns.Add("Other1", GetType(Integer))
            dTB.Columns.Add("Other2", GetType(String))

            Return dTB
        End Function

        '******************************************************************
        Public Function SkullcandyAstroWHReceivingTableDefinition() As DataTable
            Dim dTB As New DataTable()

            dTB.Columns.Add("WorkOrder", GetType(String))
            dTB.Columns.Add("Model", GetType(String))
            dTB.Columns.Add("ModelDesc", GetType(String))
            dTB.Columns.Add("ItemDesc", GetType(String))
            dTB.Columns.Add("Qty", GetType(Integer))
            dTB.Columns.Add("Retailer", GetType(String))
            dTB.Columns.Add("Other1", GetType(String))
            dTB.Columns.Add("Other2", GetType(String))
            dTB.Columns.Add("Other3", GetType(Integer))
            dTB.Columns.Add("Other4", GetType(Integer))

            Return dTB
        End Function

    End Class
End Namespace