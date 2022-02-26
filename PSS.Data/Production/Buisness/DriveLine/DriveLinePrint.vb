Option Explicit On 

Imports System.Data
Imports System.IO
'Imports System.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine

Namespace Buisness


    Public Class DriveLinePrint

        Private _objDataProc As DBQuery.DataProc

        '********************************************************************************
        Public Function Print_ShipBoxLabel(ByVal strOrderName As String, _
                                              ByVal strRetailer As String, _
                                              ByVal strStoreNo As String, _
                                              ByVal strComponentName As String, _
                                              ByVal iLocNo As Integer, _
                                              ByVal iCopies As Integer) As Integer
            Dim strsql As String = ""
            Dim objRpt As ReportDocument
            Dim dt As DataTable

            Try
                strComponentName = strComponentName.Replace("'", "''")

                strsql = "Select '" & strComponentName & "' AS Model" & Environment.NewLine
                strsql &= ", '" & strRetailer & "' AS Serial" & Environment.NewLine
                strsql &= ",'" & iLocNo.ToString & "' AS DeviceID" & Environment.NewLine
                strsql &= ", '" & strOrderName & "' AS PSSSN" & Environment.NewLine
                strsql &= ", '" & strStoreNo & "' AS RecPalletName"

                Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                objRpt = New ReportDocument()

                With objRpt
                    .Load(PSS.Data.ConfigFile.GetBaseReportPath & "DriveLine_Ship_Box_Label.rpt")
                    dt = Me._objDataProc.GetDataTable(strsql)
                    If Not IsNothing(dt) Then .SetDataSource(dt)
                    .PrintOptions.PrinterName = "EasyCoder"
                    .Refresh()
                    .PrintToPrinter(iCopies, True, 0, 0)
                End With
            Catch ex As Exception
                Throw ex
            Finally
                Me._objDataProc = Nothing
                PSS.Data.Buisness.Generic.DisposeDT(dt)
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '********************************************************************************
        Public Function Print_ShipBoxLabel_RepID(ByVal strOrderName As String, _
                                                  ByVal strRetailer As String, _
                                                  ByVal strStoreNo As String, _
                                                  ByVal strComponentName As String, _
                                                  ByVal iLocNo As Integer, _
                                                  ByVal iCopies As Integer) As Integer
            Dim strsql As String = ""
            Dim objRpt As ReportDocument
            Dim dt As DataTable

            Try
                strComponentName = strComponentName.Replace("'", "''")

                strsql = "Select '" & strComponentName & "' AS Model" & Environment.NewLine
                strsql &= ", '" & strRetailer & "' AS Serial" & Environment.NewLine
                strsql &= ",'" & iLocNo.ToString & "' AS DeviceID" & Environment.NewLine
                strsql &= ", '" & strOrderName & "' AS PSSSN" & Environment.NewLine
                strsql &= ", '" & strStoreNo & "' AS RecPalletName"

                Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                objRpt = New ReportDocument()

                With objRpt
                    .Load(PSS.Data.ConfigFile.GetBaseReportPath & "DriveLine_Ship_Box_Label_RepID.rpt")
                    dt = Me._objDataProc.GetDataTable(strsql)
                    If Not IsNothing(dt) Then .SetDataSource(dt)
                    .PrintOptions.PrinterName = "EasyCoder"
                    .Refresh()
                    .PrintToPrinter(iCopies, True, 0, 0)
                End With
            Catch ex As Exception
                Throw ex
            Finally
                Me._objDataProc = Nothing
                PSS.Data.Buisness.Generic.DisposeDT(dt)
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '********************************************************************************
        Public Function Print_ManifestReport(ByVal strOrderNo As String, _
                                           ByVal strOrderDate As String, _
                                           ByVal strShipToName As String, _
                                           ByVal strToAddress As String, _
                                           ByVal strToCity As String, _
                                           ByVal strToState As String, _
                                           ByVal strToZip As String, _
                                           ByVal strPhone As String, _
                                           ByVal iTotalComponentsNum As Integer, _
                                           ByVal dtInput As DataTable, _
                                           ByVal iCopies As Integer) As Integer


            Dim row As DataRow, row2 As DataRow
            Dim i As Integer
            Dim objUniq As PSS.Data.Buisness.TracFone.Admin
            Dim UniqArrayList As New ArrayList()
            Dim dt As DataTable
            Dim objRpt As ReportDocument

            Try
                objUniq = New PSS.Data.Buisness.TracFone.Admin()
                dt = ManifestReportTableDefinition()

                i = 0
                For Each row In dtInput.Rows
                    'If i = 0 Then
                    '    row2 = dt.NewRow
                    '    row2("RMA") = strOrderNo : row2("IMEI") = strOrderDate
                    '    row2("ToName") = strShipToName : row2("ToAddress1") = strToAddress
                    '    row2("ToCity") = strToCity : row2("ToState") = strToState
                    '    row2("ToZip") = strToZip : row2("ToAddress2") = strPhone
                    '    row2("Pallett_Name") = "By StoreNo"
                    '    row2("Pallett_ID") = iTotalComponentsNum
                    '    dt.Rows.Add(row2)
                    'End If

                    row2 = dt.NewRow
                    row2("RMA") = strOrderNo : row2("IMEI") = strOrderDate
                    row2("ToName") = strShipToName : row2("ToAddress1") = strToAddress
                    row2("ToCity") = strToCity : row2("ToState") = strToState
                    row2("ToZip") = strToZip : row2("ToAddress2") = strPhone
                    row2("WOIDBarcode") = row("Retailer")
                    row2("Pallett_Name") = row("StoreNo") : row2("Model") = row("Component")
                    row2("Ship_ID") = row("shipQty")
                    row2("Pallett_ID") = iTotalComponentsNum
                    dt.Rows.Add(row2)

                    ' i += 1
                Next

                'For Each row In objUniq.SelectDistinct("Result", dtInput, "Component").Rows
                '    UniqArrayList.Add(row("Component"))
                'Next

                'For i = 0 To UniqArrayList.Count - 1
                '    Dim strComponent As String = UniqArrayList(i)
                '    Dim resultRows() As DataRow = dtInput.Select("Component='" & strComponent & "'")
                '    Dim strStoreNo As String
                '    Dim j As Integer = 0, iQty As Integer = 0
                '    Dim vObj As Object
                '    'If i = 0 Then
                '    '    row2 = dt.NewRow
                '    '    row2("Model") = ""
                '    '    dt.Rows.Add(row2) 'add empty row
                '    '    row2 = dt.NewRow
                '    '    row2("Pallett_Name") = "By Component"
                '    '    dt.Rows.Add(row2)
                '    'End If

                '    For Each row In resultRows
                '        If j = 0 Then
                '            strStoreNo = row("StoreNo")
                '        Else
                '            strStoreNo &= "," & row("StoreNo")
                '        End If
                '        vObj = row("ShipQty")
                '        If vObj Is Nothing Or vObj.ToString.Trim.Length = 0 Then
                '            iQty += 0
                '        Else
                '            iQty += vObj
                '        End If
                '        j += 1
                '    Next

                '    row2 = dt.NewRow
                '    row2("RMA") = strOrderNo : row2("IMEI") = strOrderDate
                '    row2("ToName") = strShipToName : row2("ToAddress1") = strToAddress
                '    row2("ToCity") = strToCity : row2("ToState") = strToState
                '    row2("ToZip") = strToZip : row2("ToAddress2") = strPhone
                '    row2("Pallett_Name") = strStoreNo : row2("Model") = strComponent
                '    row2("Pallett_ID") = iTotalComponentsNum
                '    row2("Ship_ID") = iQty
                '    dt.Rows.Add(row2)
                'Next

                ' i = dt.Rows.Count

                objRpt = New ReportDocument()
                With objRpt
                    .Load(PSS.Data.ConfigFile.GetBaseReportPath & "DriveLine_Shipping_Manifest Push.rpt") '"DriveLine Ship Manifest Push.rpt")
                    If Not IsNothing(dt) Then .SetDataSource(dt)
                    .Refresh()
                    .PrintToPrinter(iCopies, True, 0, 0)
                End With
            Catch ex As Exception
                Throw ex
            Finally
                Me._objDataProc = Nothing
                PSS.Data.Buisness.Generic.DisposeDT(dtInput)
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try

        End Function

        '******************************************************************
        Public Function ManifestReportTableDefinition() As DataTable
            Dim dTB As New DataTable()

            dTB.Columns.Add("RMA", GetType(String))  'OrderNo
            dTB.Columns.Add("WO_ID", GetType(Integer))
            dTB.Columns.Add("WOIDBarcode", GetType(String))
            dTB.Columns.Add("Pallett_Name", GetType(String)) 'StoreProd
            dTB.Columns.Add("Pallett_ID", GetType(Integer))
            dTB.Columns.Add("Ship_ID", GetType(Integer)) 'ShipQty 
            dTB.Columns.Add("ShipIDBarcode", GetType(String))
            dTB.Columns.Add("Model", GetType(String)) 'ProdStore
            dTB.Columns.Add("IMEI", GetType(String)) 'OrderDate
            dTB.Columns.Add("Device_ManufWrty", GetType(Integer))
            dTB.Columns.Add("RepairStatus", GetType(Integer))
            dTB.Columns.Add("ApprovedToRepair", GetType(Integer))
            dTB.Columns.Add("WarrantyStatus", GetType(String))
            dTB.Columns.Add("ShipTo_ID", GetType(Integer))
            dTB.Columns.Add("ToName", GetType(String)) 'ShipToName
            dTB.Columns.Add("ToAddress1", GetType(String)) 'ToAddress
            dTB.Columns.Add("ToAddress2", GetType(String)) 'Phone
            dTB.Columns.Add("ToCity", GetType(String)) 'ToCity
            dTB.Columns.Add("ToState", GetType(String)) 'ToState
            dTB.Columns.Add("ToZIP", GetType(String)) 'ToZip 

            'dTB.Columns.Add("OrderNo", GetType(String))
            'dTB.Columns.Add("OrderDate", GetType(String))
            'dTB.Columns.Add("ShipToName", GetType(String))
            'dTB.Columns.Add("ToAddress", GetType(String))
            'dTB.Columns.Add("ToCity", GetType(String))
            'dTB.Columns.Add("ToState", GetType(String))
            'dTB.Columns.Add("ToZip", GetType(String))
            'dTB.Columns.Add("Phone", GetType(String))
            'dTB.Columns.Add("StoreProd", GetType(String))
            'dTB.Columns.Add("ProdStore", GetType(String))
            'dTB.Columns.Add("ShipQty", GetType(Integer))
            'dTB.Columns.Add("Other1", GetType(String))
            'dTB.Columns.Add("Other2", GetType(String))
            'dTB.Columns.Add("Other3", GetType(Integer))
            'dTB.Columns.Add("Other4", GetType(Integer))

            Return dTB
        End Function

        '********************************************************************************
        Public Function Print_TestLabel(ByVal strOrderName As String, ByVal iCopies As Integer) As Integer
            Dim strsql As String = ""
            Dim objRpt As ReportDocument
            Dim dt As DataTable

            Try

                strsql = "Select '' AS Model" & Environment.NewLine
                strsql &= ", '' AS Serial" & Environment.NewLine
                strsql &= ", 0 AS DeviceID" & Environment.NewLine
                strsql &= ", '" & strOrderName & "' AS PSSSN" & Environment.NewLine
                strsql &= ", '' AS RecPalletName"

                Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                dt = Me._objDataProc.GetDataTable(strsql)
                objRpt = New ReportDocument()

                With objRpt
                    .Load(PSS.Data.ConfigFile.GetBaseReportPath & "DriveLine_Test_Label.rpt")
                    dt = Me._objDataProc.GetDataTable(strsql)
                    If Not IsNothing(dt) Then .SetDataSource(dt)
                    .PrintToPrinter(iCopies, True, 0, 0)
                End With
            Catch ex As Exception
                Throw ex
            Finally
                Me._objDataProc = Nothing
                PSS.Data.Buisness.Generic.DisposeDT(dt)
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function


    End Class
End Namespace
