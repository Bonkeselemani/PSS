Imports CrystalDecisions.CrystalReports.Engine

Namespace Buisness
    Public Class RecWorksheet
        Private _objDataProc As DBQuery.DataProc

        Public Sub New()
            Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
        End Sub

        Public Function PrintRecReport(ByVal iTray_id As Integer, ByVal iPrintoutQty As Integer) As Integer
            Dim strRptPath As String
            Dim objRpt, objSubRpt As ReportDocument
            Dim dt, dtBillCodes As DataTable
            Dim i, iModelID, iLocID As Integer

            Try
                dt = GetRecWorksheetData(iTray_id)

                If Not IsNothing(dt) Then
                    strRptPath = PSS.Data.ConfigFile.GetBaseReportPath
                    objRpt = New ReportDocument()

                    With objRpt
                        .Load(strRptPath & "Rec Worksheet Push.rpt")
                        .SetDataSource(dt)

                        CrystalReports.FormatCRDateTimeTextBoxes(objRpt, "Times New Roman")
                        .PrintToPrinter(iPrintoutQty, True, 0, 0)
                    End With
                Else
                    Me._objDataProc.DisplayMessage("Unable to obtain data for the Rec Worksheet report.", 3, False)
                End If
            Catch ex As Exception
                Me._objDataProc.DisplayMessage(ex.Message)
            End Try
        End Function

        Private Function GetRecWorksheetData(ByVal iTrayID As Integer) As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT DISTINCT A.Tray_ID AS TrayID, DATE_FORMAT(A.Device_DateRec, '%b %e, %Y') AS DevDateRec" & Environment.NewLine
                strSQL &= ", A.Device_SN AS DeviceSN, A.Device_Cnt AS DeviceCnt, G.Loc_Name AS LocName " & Environment.NewLine
                strSQL &= ", G.Loc_City AS City, L.State_Short AS StateShort, E.WO_ID AS WOID, E.WO_CustWO AS CustWO" & Environment.NewLine
                strSQL &= ", A.Model_ID AS ModelID, H.Model_Desc AS ModelDesc " & Environment.NewLine
                strSQL &= ", D.Tray_RecUser AS TrayRecUser, J.Prod_ID AS ProdID, G.Loc_Memo AS LocMemo" & Environment.NewLine
                strSQL &= ", A.Device_Reject AS DeviceReject, A.Device_ManufWrty AS DeviceManufWrty, A.Device_PSSWrty AS DevicePSSWrty " & Environment.NewLine
                strSQL &= ", K.Cust_RepairNonWrty AS CustRepNonWrty, K.Cust_ReplaceLCD AS CustReplaceLCD, K.Cust_Name1 AS CustName1" & Environment.NewLine
                strSQL &= ", IFNULL(K.Cust_Name2, '') AS CustName2, J.Prod_Desc AS ProdDesc, E.Prod_ID AS 'ProdID(1)' " & Environment.NewLine
                strSQL &= ", IFNULL(E.WO_IP, '') AS WOIP, IFNULL(E.WO_PRL, '') AS WOPRL, IFNULL(M.Pay_Desc, '') AS PayDesc" & Environment.NewLine
                strSQL &= ", IFNULL(D.Tray_Memo, '') AS TrayMemo, F.PO_ID AS POID " & Environment.NewLine
                strSQL &= ", CONCAT('*', A.Device_SN, '*') AS BarcodeSN, CONCAT('*', CAST(A.Tray_ID AS CHAR), '*') AS BarcodeTray" & Environment.NewLine
                strSQL &= ", IF(J.Prod_ID = 1, 'Pager', 'Cell Phone') AS Device" & Environment.NewLine
                strSQL &= ", IF(E.Prod_ID = 2, CONCAT('  IP - ',  E.WO_IP ), '  ') AS IPText " & Environment.NewLine
                strSQL &= ", CONCAT('Authorize LCD/Flip Assy Replacements - ', IF(K.Cust_ReplaceLCD = 1, 'Yes ', 'No ')) AS LCDRepair" & Environment.NewLine
                strSQL &= ", CONCAT('Level ', IF(J.Prod_ID = 1, 'III', 'II')) AS RepairLevel" & Environment.NewLine
                strSQL &= ", CONCAT('Authorize Non-Warranty Repairs - ', IF(K.Cust_RepairNonWrty = 1, 'Yes ', 'No ')) AS NonWrty " & Environment.NewLine
                strSQL &= ", (CASE WHEN A.Device_ManufWrty = 0 THEN '-' WHEN  A.Device_ManufWrty = 1 THEN 'S' WHEN A.Device_ManufWrty = 2 THEN 'E' ELSE ''END) AS OEM" & Environment.NewLine
                strSQL &= ", IF(E.Prod_ID = 2, CONCAT('  PRL - ', E.WO_PRL), ' ') AS PRLText" & Environment.NewLine
                strSQL &= ", IF(A.Device_PSSWrty = 0, '-', 'Y') AS PSSWarranty " & Environment.NewLine
                strSQL &= ", IF(E.Prod_ID = 2, CONCAT('  SKU - ', C.Sku_Number), ' ') AS SKUText" & Environment.NewLine
                strSQL &= ", IF(E.Prod_ID = 2, CONCAT('  SW Ver. - ', B.CellOpt_SoftVerIN), ' ') AS SoftwareText " & Environment.NewLine
                strSQL &= ", A.Loc_ID AS LocID " & Environment.NewLine
                strSQL &= ", tshipto.ShipTo_Name AS WOShipToName " & Environment.NewLine
                strSQL &= ", tshipto.ShipTo_Address1 AS WOShipToAdd1 " & Environment.NewLine
                strSQL &= ", tshipto.ShipTo_Address2 AS WOShipToAdd2 " & Environment.NewLine
                strSQL &= ", tshipto.ShipTo_City AS WOShipToCity " & Environment.NewLine
                strSQL &= ", lstate.State_Short AS WOShipToState " & Environment.NewLine
                strSQL &= ", tshipto.ShipTo_Zip AS WOShipToZip " & Environment.NewLine
                strSQL &= ", lcountry.Cntry_Name AS WOShipToCountry " & Environment.NewLine
                strSQL &= ", tshipto.Tel AS WOShipToPhone " & Environment.NewLine
                strSQL &= ", tshipto.Email AS WOShipToEmail " & Environment.NewLine
                strSQL &= ", if(tcellopt.RUR_ReturnToCust is null, '', tcellopt.RUR_ReturnToCust) as RURReturnToCustomer " & Environment.NewLine
                strSQL &= "FROM tdevice A " & Environment.NewLine
                strSQL &= "LEFT JOIN tcellopt B ON B.Device_ID = A.Device_ID " & Environment.NewLine
                strSQL &= "LEFT JOIN tsku C ON C.Sku_ID = A.Sku_ID " & Environment.NewLine
                strSQL &= "INNER JOIN ttray D ON D.Tray_ID = A.Tray_ID " & Environment.NewLine
                strSQL &= "INNER JOIN tworkorder E ON E.WO_ID = D.WO_ID " & Environment.NewLine
                strSQL &= "LEFT JOIN tpurchaseorder F ON F.PO_ID = E.PO_ID " & Environment.NewLine
                strSQL &= "INNER JOIN tlocation G ON G.Loc_ID = A.Loc_ID " & Environment.NewLine
                strSQL &= "INNER JOIN tmodel H ON H.Model_ID = A.Model_ID " & Environment.NewLine
                'strSQL &= "INNER JOIN tpsmap I ON I.Model_ID = H.Model_ID " & Environment.NewLine
                strSQL &= "INNER JOIN lproduct J ON J.Prod_ID = H.Prod_ID " & Environment.NewLine
                strSQL &= "INNER JOIN tcustomer K ON K.Cust_ID = G.Cust_ID " & Environment.NewLine
                strSQL &= "INNER JOIN lstate L ON L.State_ID = G.State_ID " & Environment.NewLine
                strSQL &= "INNER JOIN lpaymethod M ON M.Pay_ID = K.Pay_ID " & Environment.NewLine
                strSQL &= "LEFT OUTER JOIN tshipto ON E.ShipTo_ID = tshipto.ShipTo_ID" & Environment.NewLine
                strSQL &= "LEFT OUTER JOIN lstate ON tshipto.State_Id = lstate.State_ID" & Environment.NewLine
                strSQL &= "LEFT OUTER JOIN lcountry ON lcountry.Cntry_ID = tshipto.Cntry_ID" & Environment.NewLine
                strSQL &= "LEFT OUTER JOIN tcellopt ON A.Device_ID = tcellopt.Device_ID" & Environment.NewLine
                strSQL &= "WHERE A.Tray_ID = " & iTrayID.ToString & " " & Environment.NewLine
                strSQL &= "ORDER BY A.Device_Cnt"

                Return Me._objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Private Function GetModelIDInString(ByVal dt As DataTable) As String
            Dim strModelIDIn As String = ""
            Dim dr As DataRow
            Dim arrlstModelIDs As ArrayList

            Try
                arrlstModelIDs = New ArrayList()

                For Each dr In dt.Rows
                    If arrlstModelIDs.IndexOf(dr("ModelID")) = -1 Then
                        arrlstModelIDs.Add(dr("ModelID"))
                        strModelIDIn &= dr("ModelID") & ", "
                    End If
                Next

                If strModelIDIn.EndsWith(", ") Then strModelIDIn = strModelIDIn.Substring(0, strModelIDIn.Length - 2)

                Return strModelIDIn
            Catch ex As Exception
                Throw ex
            Finally
                dr = Nothing
            End Try
        End Function

        Private Function GetModelID(ByVal dt As DataTable) As Integer
            Dim iModelID As Integer = 0
            Dim dr As DataRow

            Try
                For Each dr In dt.Rows
                    If Not IsDBNull(dr("ModelID")) Then iModelID = dr("ModelID")

                    If iModelID > 0 Then Exit For
                Next dr

                Return iModelID
            Catch ex As Exception
                Throw ex
            Finally
                dr = Nothing
            End Try
        End Function

        Private Function GetLocID(ByVal dt As DataTable) As Integer
            Dim iLoclID As Integer = 0
            Dim dr As DataRow

            Try
                For Each dr In dt.Rows
                    If Not IsDBNull(dr("LocID")) Then iLoclID = dr("LocID")

                    If iLoclID > 0 Then Exit For
                Next dr

                Return iLoclID
            Catch ex As Exception
                Throw ex
            Finally
                dr = Nothing
            End Try
        End Function

        Private Function GetBillCodesData(ByVal iModelID As Integer, ByVal iLocID As Integer) As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT A.Model_ID AS ModelID, B.BillCode_Desc AS BillCodeDesc, A.LaborLvl_ID AS LaborLvlID, " & Environment.NewLine
                strSQL &= "A.Prod_ID AS ProdID, B.BillCode_ID AS MapBillCodeID, A.BillCode_ID AS BillCodeID, A.Inactive AS Inactive " & Environment.NewLine
                strSQL &= "FROM tpsmap A " & Environment.NewLine
                strSQL &= "INNER JOIN lbillcodes B ON B.BillCode_ID = A.BillCode_ID " & Environment.NewLine
                strSQL &= "WHERE A.Model_ID = " & iModelID.ToString & " " & Environment.NewLine

                'For American Messagibg (iLocID = 19):
                'Don't display LCD bill code (13) for AE or AG models.
                'Don't display Crystal Used bill code (21) for AG or BF models.
                If iLocID = 19 Then
                    Select Case iModelID
                        Case 2
                            strSQL &= "AND (NOT (B.BillCode_ID = 13 OR B.BillCode_ID = 21)) " & Environment.NewLine

                        Case 3, 276, 1936
                            strSQL &= "AND B.BillCode_ID <> 13 " & Environment.NewLine

                        Case 7
                            strSQL &= "AND B.BillCode_ID <> 21 " & Environment.NewLine
                    End Select
                Else
                    Select Case iModelID
                        Case 2
                            strSQL &= "AND (NOT (B.BillCode_ID = 13)) " & Environment.NewLine
                    End Select
                End If

                strSQL &= "ORDER BY B.BillCode_ID"

                Return Me._objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class
End Namespace
