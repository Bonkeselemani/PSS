Option Explicit On 

Imports System.Xml
Imports System.Xml.XmlWriter
Imports system.IO
Imports system.IO.StreamWriter
Imports System.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine

Namespace Buisness

    Public Class SendPalletPackingListFiles
        Private _objDataProc As DBQuery.DataProc

        '*******************************************************************
        Public Sub New()
            Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
        End Sub
        Private _objVivint As PSS.Data.Buisness.VV.Vivint
        Private _objCoolpad As PSS.Data.Buisness.CP.CoolPad
        '*******************************************************************
        Public Function GetCustomerIDsAndNames(ByVal arrlstPalletNames As ArrayList, Optional ByVal iMenuCust_ID As Integer = 0) As DataTable
            Dim strSQL As String
            Dim en As IEnumerator
            Dim bFirst As Boolean = True

            Try
                strSQL = "SELECT DISTINCT D.cust_id AS CustID, B.pallett_name AS PalletName " & Environment.NewLine
                If iMenuCust_ID = 2577 Then 'Skullcandy retail
                    strSQL &= "FROM tsk_device A" & Environment.NewLine
                    strSQL &= "INNER JOIN tpallett B ON B.pallett_id = A.pallet_id " & Environment.NewLine
                Else
                    strSQL &= "FROM tdevice A " & Environment.NewLine
                    strSQL &= "INNER JOIN tpallett B ON B.pallett_id = A.pallett_id " & Environment.NewLine
                End If

                If iMenuCust_ID = 2577 Then
                    strSQL &= "INNER JOIN tlocation C ON C.Loc_ID = B.Loc_ID " & Environment.NewLine
                Else
                    strSQL &= "INNER JOIN tlocation C ON C.Loc_ID = A.Loc_ID " & Environment.NewLine
                End If
                strSQL &= "INNER JOIN tcustomer D ON D.Cust_ID = C.Cust_ID " & Environment.NewLine
                strSQL &= "WHERE B.pallett_name IN ("

                en = arrlstPalletNames.GetEnumerator

                While en.MoveNext
                    If Not bFirst Then strSQL &= ", "

                    strSQL &= "'" & en.Current & "'"

                    If bFirst Then bFirst = False
                End While

                strSQL &= ")"

                Return Me._objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Me._objDataProc.DisplayMessage(ex.Message)
            End Try
        End Function

        '*******************************************************************
        Public Function GetPalletIDs(ByVal arrlstPalletNames As ArrayList) As DataTable
            Dim strSQL As String
            Dim en As IEnumerator
            Dim bFirst As Boolean = True

            Try
                strSQL = "SELECT pallett_id, IF(Model_ID IN (1083, 1086, 1087, 1088, 1089, 1090, 1093), 1, 0) AS IsGH " & Environment.NewLine
                strSQL &= "FROM tpallett " & Environment.NewLine
                strSQL &= "WHERE pallett_name IN ("

                en = arrlstPalletNames.GetEnumerator

                While en.MoveNext
                    If Not bFirst Then strSQL &= ", "

                    strSQL &= "'" & en.Current & "'"

                    If bFirst Then bFirst = False
                End While

                strSQL &= ")"

                Return Me._objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Me._objDataProc.DisplayMessage(ex.Message)
            End Try
        End Function

        ''*******************************************************************
        'Public Function GetReportData(ByVal dtPalletIDs As DataTable, _
        '                              ByVal bNoCustInfo As Boolean, _
        '                              ByVal strSlipNum As String) As DataTable
        '    Dim dr As DataRow
        '    Dim strSQL As String
        '    Dim iPalletCount() As Integer = {0, 0}

        '    Try
        '        iPalletCount(0) = dtPalletIDs.Select("IsGH = 0").Length
        '        iPalletCount(1) = dtPalletIDs.Select("IsGH = 1").Length

        '        If iPalletCount(0) > 0 Then
        '            If bNoCustInfo Then
        '                strSQL = "SELECT E.Pallett_ID AS PalletID, E.Pallett_Name AS PalletName, C.Device_ID AS DeviceID, F.Model_Desc AS ModelDesc, E.Pallet_ShipType AS PalletShipType, E.Pallet_SkuLen AS PalletSkuLen, " & Environment.NewLine
        '            Else
        '                strSQL = "SELECT E.Pallett_ID AS PalletID, E.Pallett_Name AS PalletName, C.Device_ID AS DeviceID, F.Model_Desc AS ModelDesc, E.Pallet_ShipType AS PalletShipType, A.Cust_Name1 AS CustName, " & Environment.NewLine
        '                'strSQL &= "(CASE WHEN UPPER(F.Model_Desc) = 'GAMECUBE' THEN REPLACE(B.Loc_Address1, '625', '633') ELSE B.Loc_Address1 END) AS Address1, " & Environment.NewLine
        '                strSQL &= "B.Loc_Address1 AS Address1, " & Environment.NewLine
        '                strSQL &= "B.Loc_Address2 AS Address2, B.Loc_City AS City, D.State_Long AS State, B.Loc_Zip AS ZIP, E.Pallet_SkuLen AS PalletSkuLen, A.Cust_ID AS CustID, " & Environment.NewLine
        '            End If

        '            strSQL &= "'" & strSlipNum & "' AS SlipNumber, " & Environment.NewLine
        '            strSQL &= "(CASE WHEN A.Cust_ID = 2019 THEN " & Environment.NewLine
        '            strSQL &= "(CASE WHEN E.Pallet_ShipType = 0 THEN 'PASS' ELSE 'FAIL' END) " & Environment.NewLine
        '            strSQL &= "WHEN A.Cust_ID = 2219 THEN " & Environment.NewLine
        '            strSQL &= "(CASE WHEN E.Pallet_ShipType = 0 THEN 'Refurbished' WHEN E.Pallet_ShipType = 1 THEN 'RUR' WHEN E.Pallet_ShipType = 8 THEN 'Scrap' WHEN E.Pallet_ShipType = 9 THEN 'Incomplete' ELSE '' END) " & Environment.NewLine
        '            strSQL &= "END) AS PassFail, " & Environment.NewLine
        '            strSQL &= "(CASE WHEN A.Cust_ID = 2219 THEN 'AUDITED BY' ELSE 'TOTAL WEIGHT' END) AS CustomField1 " & Environment.NewLine
        '            strSQL &= "FROM tcustomer A " & Environment.NewLine
        '            strSQL &= "INNER JOIN tlocation B ON B.Cust_ID = A.Cust_ID " & Environment.NewLine
        '            strSQL &= "INNER JOIN tdevice C ON C.Loc_ID = B.Loc_ID " & Environment.NewLine
        '            strSQL &= "INNER JOIN lstate D ON D.State_ID = B.State_ID " & Environment.NewLine
        '            strSQL &= "INNER JOIN tpallett E ON E.Pallett_ID= C.Pallett_ID " & Environment.NewLine
        '            strSQL &= "INNER JOIN tmodel F ON F.Model_ID = C.Model_ID " & Environment.NewLine
        '            strSQL &= "WHERE E.Pallett_ID IN ("

        '            For Each dr In dtPalletIDs.Rows
        '                If dr("IsGH") = 0 Then strSQL &= dr("Pallett_ID") & ", "
        '            Next

        '            If strSQL.EndsWith(", ") Then strSQL = strSQL.Substring(0, strSQL.Length - 2)

        '            strSQL &= ") " & Environment.NewLine
        '            strSQL &= "AND E.Model_ID <> 1083 " & Environment.NewLine 'Not Guitar Hero
        '            'strSQL &= "ORDER BY PallettID, DeviceID"
        '        End If

        '        If iPalletCount(0) > 0 And iPalletCount(1) > 0 Then strSQL &= "UNION " & Environment.NewLine

        '        If iPalletCount(1) > 0 Then
        '            If bNoCustInfo Then
        '                strSQL = "SELECT E.Pallett_ID AS PalletID, E.Pallett_Name AS PalletName, E.Pallett_Qty AS DeviceID, F.Model_Desc AS ModelDesc, E.Pallet_ShipType AS PalletShipType, E.Pallet_SkuLen AS PalletSkuLen, " & Environment.NewLine
        '            Else
        '                strSQL = "SELECT E.Pallett_ID AS PalletID, E.Pallett_Name AS PalletName, E.Pallett_Qty AS DeviceID, F.Model_Desc AS ModelDesc, E.Pallet_ShipType AS PalletShipType, A.Cust_Name1 AS CustName, " & Environment.NewLine
        '                'strSQL &= "(CASE WHEN UPPER(F.Model_Desc) = 'GAMECUBE' THEN REPLACE(B.Loc_Address1, '625', '633') ELSE B.Loc_Address1 END) AS Address1, " & Environment.NewLine
        '                strSQL &= "B.Loc_Address1 AS Address1, " & Environment.NewLine
        '                strSQL &= "B.Loc_Address2 AS Address2, B.Loc_City AS City, D.State_Long AS State, B.Loc_Zip AS ZIP, E.Pallet_SkuLen AS PalletSkuLen, A.Cust_ID AS CustID, " & Environment.NewLine
        '            End If

        '            strSQL &= "'" & strSlipNum & "' AS SlipNumber, " & Environment.NewLine
        '            strSQL &= "(CASE WHEN E.Pallet_ShipType = 0 THEN 'PASS' ELSE 'FAIL' END) AS PassFail, " & Environment.NewLine
        '            strSQL &= "'AUDITED BY'  AS CustomField1 " & Environment.NewLine
        '            strSQL &= "FROM tcustomer A " & Environment.NewLine
        '            strSQL &= "INNER JOIN tlocation B ON B.Cust_ID = A.Cust_ID " & Environment.NewLine
        '            'strSQL &= "INNER JOIN tdevice C ON C.Loc_ID = B.Loc_ID " & Environment.NewLine
        '            strSQL &= "INNER JOIN lstate D ON D.State_ID = B.State_ID " & Environment.NewLine
        '            strSQL &= "INNER JOIN tpallett E ON E.Loc_ID= B.Loc_ID " & Environment.NewLine
        '            'strSQL &= "INNER JOIN tpallett E ON E.Pallett_ID= C.Pallett_ID " & Environment.NewLine
        '            strSQL &= "INNER JOIN tmodel F ON F.Model_ID = E.Model_ID " & Environment.NewLine
        '            strSQL &= "WHERE E.Pallett_ID IN ("

        '            For Each dr In dtPalletIDs.Rows
        '                If dr("IsGH") = 1 Then strSQL &= dr("Pallett_ID") & ", "
        '            Next

        '            If strSQL.EndsWith(", ") Then strSQL = strSQL.Substring(0, strSQL.Length - 2)

        '            strSQL &= ") " & Environment.NewLine
        '            strSQL &= "AND E.Model_ID = 1083 " & Environment.NewLine 'Guitar Hero
        '        End If

        '        If iPalletCount(0) > 0 Or iPalletCount(1) > 0 Then strSQL &= "ORDER BY E.Pallett_ID, Model_Desc"

        '        Return Me._objDataProc.GetDataTable(strSQL)
        '    Catch ex As Exception
        '        Throw ex
        '    Finally
        '        If Not IsNothing(dtPalletIDs) Then
        '            dtPalletIDs.Dispose()
        '            dtPalletIDs = Nothing
        '        End If
        '    End Try
        'End Function

        '*******************************************************************
        Public Function GetPackingSlipReportData(ByVal bNoCustInfo As Boolean, _
                                                 ByVal strSlipNum As String, Optional ByVal iCust_ID As Integer = 0) As DataTable
            Dim dr, dr2 As DataRow
            Dim strSQL, strS As String
            Dim dtPalletInfo As DataTable
            Dim iPalletQty As Integer = 0
            Dim dtTmp As New DataTable()

            Try
                If bNoCustInfo Then
                    strSQL = "SELECT A.Pallett_ID AS PalletID, A.Pallett_Name AS PalletName, A.Pallet_ShipType AS PalletShipType " & Environment.NewLine
                    strSQL &= ", If (E.Model_Desc is null, '', E.Model_Desc ) AS ModelDesc,A.Pallet_SeqNo " & Environment.NewLine
                    strSQL &= ", '' AS CustName, '' AS Address1, " & Environment.NewLine
                    strSQL &= "'' AS Address2, '' AS City, '' AS State, '' AS ZIP, '' AS CustID " & Environment.NewLine
                Else
                    strSQL = "SELECT A.Pallett_ID AS PalletID, A.Pallett_Name AS PalletName, A.Pallet_ShipType AS PalletShipType " & Environment.NewLine
                    strSQL &= ", If (E.Model_Desc is null, '', E.Model_Desc ) AS ModelDesc,A.Pallet_SeqNo " & Environment.NewLine
                    'strSQL &= "(CASE WHEN UPPER(E.Model_Desc) = 'GAMECUBE' THEN REPLACE(B.Loc_Address1, '625', '633') ELSE B.Loc_Address1 END) AS Address1, " & Environment.NewLine
                    strSQL &= ", IF(B.Loc_ID=3404 OR B.Loc_ID=3405, CONCAT_WS(' - ', C.Cust_Name1,B.Loc_Name),C.Cust_Name1) AS CustName, B.Loc_Address1 AS Address1, " & Environment.NewLine
                    strSQL &= "B.Loc_Address2 AS Address2, B.Loc_City AS City, D.State_Long AS State, B.Loc_Zip AS ZIP, C.Cust_ID AS CustID " & Environment.NewLine
                End If

                '2371

                strSQL &= ", if( A.Cust_ID = 1545, '', A.Pallet_SkuLen ) AS PalletSkuLen " & Environment.NewLine
                strSQL &= ", '" & strSlipNum & "' AS SlipNumber, " & Environment.NewLine
                strSQL &= "IF( A.Pallett_QTY is null, 0, A.Pallett_QTY) AS PallettQty, " & Environment.NewLine
                strSQL &= "(CASE WHEN A.Cust_ID in ( 2019, 2254, 2371 ) THEN " & Environment.NewLine
                strSQL &= "(CASE WHEN A.Pallet_ShipType = 0 THEN 'PASS' ELSE 'FAIL' END) " & Environment.NewLine
                strSQL &= "WHEN (A.Cust_ID IN (2245, 2242 ) OR E.Prod_ID = 7 ) THEN " & Environment.NewLine
                strSQL &= "(CASE WHEN A.Pallet_ShipType = 0 THEN 'PASS' ELSE 'DBR' END) " & Environment.NewLine
                strSQL &= "WHEN A.Cust_ID IN (14, 1545, 2507, 2508 ) THEN " & Environment.NewLine '  strSQL &= "WHEN A.Cust_ID IN (14, 1545 ) THEN " & Environment.NewLine
                strSQL &= "(CASE WHEN A.Pallet_ShipType = 0 THEN 'REF' WHEN A.Pallet_ShipType = 1 THEN 'DBR' WHEN A.Pallet_ShipType = 2 THEN 'NER' ELSE '' END) " & Environment.NewLine
                strSQL &= "WHEN A.Cust_ID = 2219 THEN " & Environment.NewLine
                strSQL &= "(CASE WHEN A.Model_ID IN (1083, 1086, 1087, 1088, 1089, 1090, 1093, 1175) THEN IF( A.Pallet_ShipType = 0 , 'PASSED', 'FAILED') ELSE " & Environment.NewLine
                strSQL &= "(CASE WHEN A.Pallet_ShipType = 0 THEN 'Refurbished' WHEN A.Pallet_ShipType = 1 THEN 'RUR' WHEN A.Pallet_ShipType = 8 THEN 'Scrap' WHEN A.Pallet_ShipType = 9 THEN 'Incomplete' ELSE '' END) END) " & Environment.NewLine
                strSQL &= "WHEN E.Prod_ID = 5 THEN (CASE WHEN A.Pallet_ShipType = 0 THEN 'Refurbished' WHEN A.Pallet_ShipType = 1 THEN 'RUR' WHEN A.Pallet_ShipType = 8 THEN 'Scrap' WHEN A.Pallet_ShipType = 9 THEN 'Incomplete' ELSE '' END) " & Environment.NewLine
                strSQL &= "END) AS PassFail, " & Environment.NewLine
                strSQL &= "(CASE WHEN A.Cust_ID = 2219 THEN 'AUDITED BY' ELSE 'TOTAL WEIGHT' END) AS CustomField1 " & Environment.NewLine
                strSQL &= ", IF( lshipcarrier.SC_Desc IS NULL, '', lshipcarrier.SC_Desc) as Carrier " & Environment.NewLine
                strSQL &= ", IF( tpackingslip.pkslip_TrackNo IS NULL, '', tpackingslip.pkslip_TrackNo) as TrackingNo " & Environment.NewLine
                strSQL &= ", Date_format(pkslip_createDt, '%m/%d/%Y') as PackingDate, date_format(pkslip_createDt, '%h:%m:%s %p') as PackingTime" & Environment.NewLine
                strSQL &= "FROM tpallett A " & Environment.NewLine
                strSQL &= "INNER JOIN tlocation B ON A.Loc_ID = B.Loc_ID " & Environment.NewLine
                strSQL &= "INNER JOIN tcustomer C ON B.Cust_ID = C.Cust_ID " & Environment.NewLine
                strSQL &= "INNER JOIN lstate D ON B.State_ID = D.State_ID " & Environment.NewLine
                strSQL &= "INNER JOIN tpackingslip ON A.pkslip_ID = tpackingslip.pkslip_ID " & Environment.NewLine
                strSQL &= "LEFT OUTER JOIN lshipcarrier ON tpackingslip.SC_ID = lshipcarrier.SC_ID " & Environment.NewLine
                strSQL &= "LEFT OUTER JOIN tmodel E ON A.Model_ID = E.Model_ID " & Environment.NewLine
                strSQL &= "WHERE A.pkslip_ID = " & Convert.ToInt64(strSlipNum)

                dtPalletInfo = Me._objDataProc.GetDataTable(strSQL)

                If iCust_ID = 2577 Then 'skullcandy retail
                    For Each dr In dtPalletInfo.Rows
                        If dr("PallettQty") = 0 Then
                            strSQL = "SELECT SUM(Quantity) FROM tBulkReceive WHERE Pallett_ID = " & dr("PalletID") & ";"
                            iPalletQty = Me._objDataProc.GetIntValue(strSQL)
                            dr.BeginEdit()
                            dr("PallettQty") = iPalletQty
                            dr.EndEdit()
                            dtPalletInfo.AcceptChanges()
                        End If
                        strSQL = "SELECT DCode_LDesc, count(DCode_LDesc) FROM tBulkReceive A" & Environment.NewLine
                        strSQL &= "INNER JOIN  lcodesdetail B ON A.DCode_ID=B.DCode_ID" & Environment.NewLine
                        strSQL &= "WHERE A.Pallett_ID=221573" & Environment.NewLine
                        strSQL &= "GROUP BY DCode_LDesc;" & Environment.NewLine
                        dtTmp = Me._objDataProc.GetDataTable(strSQL)
                        strS = ""
                        For Each dr2 In dtTmp.Rows
                            If strS.Trim.Length = 0 Then
                                strS = dr2("DCode_LDesc")
                            Else
                                strS &= ", " & dr2("DCode_LDesc")
                            End If
                        Next
                        dr.BeginEdit()
                        dr("ModelDesc") = strS 'for disposition
                        dr.EndEdit()
                        dtPalletInfo.AcceptChanges()
                    Next dr
                Else
                    For Each dr In dtPalletInfo.Rows
                        If dr("PallettQty") = 0 Then
                            strSQL = "SELECT count(*) FROM tdevice WHERE Pallett_ID = " & dr("PalletID") & ";"
                            iPalletQty = Me._objDataProc.GetIntValue(strSQL)
                            dr.BeginEdit()
                            dr("PallettQty") = iPalletQty
                            dr.EndEdit()
                            dtPalletInfo.AcceptChanges()
                        End If
                    Next dr
                End If

                Return dtPalletInfo
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dtPalletInfo) Then
                    dtPalletInfo.Dispose() : dtPalletInfo = Nothing
                    dtTmp.Dispose() : dtTmp = Nothing
                End If
            End Try
        End Function

        '*******************************************************************
        Public Function GetManifestWarehouseLabelData(ByVal dt As DataTable) As DataTable
            Dim row As DataRow
            Dim strSQL As String = ""
            Dim iNum As Integer
            Dim i As Integer = 0
            Dim strDate As String, dDate As Date
            Dim dtResult As DataTable
            Dim iTotal As Integer = 0
            Dim iQty As Integer = 0

            Try

                If dt.Rows.Count > 0 Then
                    iTotal = dt.Compute("SUM(PallettQty)", "")
                    For Each row In dt.Rows
                        i += 1
                        strDate = row("PackingDate") : iQty = row("PallettQty")
                        If IsDate(strDate) Then
                            dDate = CDate(strDate)
                            strDate = Format(dDate, "dd-MMM-yyyy")
                        End If
                        If i = 1 Then
                            strSQL = "SELECT '" & row("CustName") & "' AS Customer,'" & row("SlipNumber") & "' AS ManifestID," & Environment.NewLine
                            strSQL &= "'" & strDate & "' AS ManifestDate,'" & row("PAlletName") & "' AS PalletName," & Environment.NewLine
                            strSQL &= "'Box " & i.ToString & " of " & dt.Rows.Count & "                           ' AS BoxDesc,'" & iQty.ToString & "' AS Other2" & Environment.NewLine
                        Else
                            strSQL &= " UNION ALL SELECT '" & row("CustName") & "' AS Customer,'" & row("SlipNumber") & "' AS ManifestID," & Environment.NewLine
                            strSQL &= "'" & strDate & "' AS ManifestDate,'" & row("PAlletName") & "' AS PalletName," & Environment.NewLine
                            strSQL &= "'Box " & i.ToString & " of " & dt.Rows.Count & "' AS BoxDesc,'" & iQty.ToString & "' AS Other2" & Environment.NewLine
                        End If
                        If i = dt.Rows.Count Then
                            strSQL &= " UNION ALL SELECT '' AS Customer,0 AS ManifestID," & Environment.NewLine
                            strSQL &= "'' AS ManifestDate,'' AS PalletName," & Environment.NewLine
                            strSQL &= "'Total Shipment Quantity' AS BoxDesc,'" & iTotal.ToString & "' AS Other2" & Environment.NewLine
                        End If
                    Next

                    dtResult = Me._objDataProc.GetDataTable(strSQL)
                End If

                Return dtResult

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************
        Public Function GetPackingSlipReportData_Genesis(ByVal strSlipNum As String) As DataTable
            Dim strSQL As String
            Dim dtPalletInfo As DataTable

            Try
                strSQL = "SELECT A.Pallett_ID AS PalletID, A.Pallett_Name AS PalletName, A.Pallet_ShipType AS PalletShipType " & Environment.NewLine
                strSQL &= ", ItemNo AS ModelDesc " & Environment.NewLine
                strSQL &= ", C.ShipToContact AS CustName, C.ShipToAddress AS Address1 " & Environment.NewLine
                strSQL &= ", if(C.ShipToAddress2 is null, '', C.ShipToAddress2) AS Address2 " & Environment.NewLine
                strSQL &= ", C.ShipToCity AS City, C.ShipToState AS State, C.ShipToZipCode AS ZIP, A.Cust_ID AS CustID " & Environment.NewLine
                strSQL &= ", concat('Line # ', D.LineNo) AS PalletSkuLen " & Environment.NewLine
                strSQL &= ", Cast(A.pkslip_id as Char) AS SlipNumber " & Environment.NewLine
                strSQL &= ", '' AS PassFail " & Environment.NewLine
                strSQL &= ", 'TOTAL WEIGHT' AS CustomField1, count(*) as PallettQty, SkidQty as SkidQty, GaylordQty as GaylordQty, A.WO_ID" & Environment.NewLine
                strSQL &= "FROM tpallett A " & Environment.NewLine
                strSQL &= "INNER JOIN tdevice B ON A.Pallett_ID = B.Pallett_ID " & Environment.NewLine
                strSQL &= "INNER JOIN tworkorderinfo C ON B.WO_ID = C.WO_ID " & Environment.NewLine
                strSQL &= "INNER JOIN tworkorderline D ON A.WO_ID = D.WO_ID AND A.Pallet_SkuLen = D.WOL_ID " & Environment.NewLine
                strSQL &= "INNER JOIN tpackingslip E ON A.pkslip_id = E.pkslip_id " & Environment.NewLine
                strSQL &= "WHERE A.pkslip_id = " & strSlipNum & Environment.NewLine
                strSQL &= "GROUP BY A.Pallett_ID " & Environment.NewLine

                dtPalletInfo = Me._objDataProc.GetDataTable(strSQL)

                Return dtPalletInfo
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtPalletInfo)
            End Try
        End Function

        '*******************************************************************
        Public Function GetReadyToManifestCustomersList() As DataTable
            Dim strSql As String
            Dim dt1 As DataTable

            Try

                strSql = "SELECT DISTINCT tcustomer.Cust_ID, tcustomer.Cust_Name1, ReqOutboundTracking" & Environment.NewLine
                strSql &= "FROM tcustomer " & Environment.NewLine
                strSql &= "INNER JOIN tpallett ON tcustomer.Cust_ID = tpallett.Cust_ID " & Environment.NewLine
                strSql &= "WHERE pkslip_ID is null and Pallett_ShipDate > '2008-01-01' and pay_id = 1 and Cust_Name2 is null " & Environment.NewLine
                strSql &= "AND tcustomer.Cust_ID NOT IN ( 2258 ) " & Environment.NewLine
                strSql &= "AND tcustomer.Cust_Inactive = 0 "
                strSql &= "ORDER BY cust_name1;"
                dt1 = Me._objDataProc.GetDataTable(strSql)
                dt1.LoadDataRow(New Object() {"0", "--SELECT--", "0"}, False)

                Return dt1
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt1)
            End Try
        End Function

        '*******************************************************************
        Public Function CheckShippedPallet(ByVal strPalletName As String) As Boolean
            Dim dt As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT count(*) as cnt " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "WHERE tpallett.Pallett_Name = '" & strPalletName & "' AND " & Environment.NewLine
                strSql &= "tpallett.Pallett_ShipDate is not null AND tpallett.AWPFlag <> 1;"

                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows(0)("cnt") > 0 Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Function

        '*******************************************************************
        Public Function CreateXMLFile(ByVal strPalletIDs As String, _
                                      ByVal strUserName As String) As Integer
            Dim strSql As String = ""
            Dim dt1, dt2 As DataTable
            Dim R1, R2 As DataRow
            Dim xmlTextWriter As xmlTextWriter
            Dim i As Integer = 0
            Dim strFieldName As String
            Dim strFieldValue As String
            Dim strWriteXMLto As String = "P:\Dept\ATCLE\ATCLE_XML_Data\"
            Dim strXMLFileName As String
            Dim strLogFileLoc As String = "P:\Dept\ATCLE\Log\ATCLE_XML_Ship_Rpt.txt"
            Dim strLogData As String
            Dim strDT As String
            Dim iFileNum As Integer = 1

            Try

                '************************************************************
                'STEP 1     Get device info (Device Level Info)
                strSql = "SELECT " & Environment.NewLine
                strSql &= "tdevice.device_id, " & Environment.NewLine
                strSql &= "tpallett.Pallet_ShipType, " & Environment.NewLine
                strSql &= "tcellopt.cellopt_PTL, " & Environment.NewLine
                strSql &= "tcellopt.cellopt_PTP, " & Environment.NewLine
                strSql &= "'HEADER_SEG' AS SEGNAM, " & Environment.NewLine          '1
                strSql &= "'A' AS TRNTYP, " & Environment.NewLine                   '2
                strSql &= "tdevice.Device_SN AS DTLNUM, " & Environment.NewLine     '3
                strSql &= "'3' AS UC_REPPRV, " & Environment.NewLine                '4
                'strSql &= "latcle_codes.UC_REP_CELL, " & Environment.NewLine     '5
                strSql &= "'2RP3CELL01' as UC_REP_CELL, " & Environment.NewLine     '5
                strSql &= "lcodesdetail.Dcode_Sdesc as UC_REPSTS, " & Environment.NewLine           '6
                strSql &= "twarehousepalletload.WHP_PartNumber AS PRTNUM, " & Environment.NewLine   '7
                strSql &= "IF (WHP_ClientID is NULL, '', WHP_ClientID) AS PRT_CLIENT_ID, " & Environment.NewLine      '8
                strSql &= "DATE_FORMAT(tdevice.Device_DateBill, '%Y%m%d%H%i%s') AS ADDDTE, " & Environment.NewLine  '9
                strSql &= "'PSSI' AS RFTEST, " & Environment.NewLine            '10
                strSql &= "'PSSI' AS FUNCTST, " & Environment.NewLine           '11
                strSql &= "'PSSI' as FLSHRST, " & Environment.NewLine           '12
                strSql &= "'0' AS POLBUF, " & Environment.NewLine               '13
                strSql &= "'0' AS COSREP, " & Environment.NewLine               '14
                strSql &= "'----' AS RETCOD, " & Environment.NewLine            '15
                strSql &= "'----' AS TRBFND, " & Environment.NewLine            '16
                strSql &= "'0' AS 'MATCH', " & Environment.NewLine              '17
                strSql &= "'0' AS ABUSE, " & Environment.NewLine                '18
                strSql &= "'----' AS COMMENT1, " & Environment.NewLine          '19
                strSql &= "'----' AS COMMENT2, " & Environment.NewLine          '20
                strSql &= "'----' as SERIALNUM, " & Environment.NewLine         '21
                strSql &= "'----' as CALLTIMER, " & Environment.NewLine         '22
                strSql &= "'0' AS WARRANTY, " & Environment.NewLine             '23
                strSql &= "'PSSI' as UC_REP_USR_ID, " & Environment.NewLine     '24
                strSql &= "DATE_FORMAT(tdevice.Device_DateBill, '%Y%m%d%H%i%s') as REPDTE, " & Environment.NewLine  '25
                strSql &= "'----' as NWSVER, " & Environment.NewLine            '26
                strSql &= "'----' as ORGCOD, " & Environment.NewLine            '27
                strSql &= "'----' as PRLNUM, " & Environment.NewLine            '28
                'strSql &= "'----' as RMANUM, " & Environment.NewLine            '29
                strSql &= "'0' as CALLTIMER_HOUR, " & Environment.NewLine       '30
                strSql &= "'0' as CALLTIMER_MIN, " & Environment.NewLine        '31
                strSql &= "'----' as TRBCOD, " & Environment.NewLine            '32
                'strSql &= "'----' as RCVKEY, " & Environment.NewLine            '33
                strSql &= "'0' as FUNREP, " & Environment.NewLine               '34
                strSql &= "'----' as FINQA, " & Environment.NewLine             '35
                strSql &= "'0' as NOFAULT, " & Environment.NewLine              '36
                strSql &= "IF (WHP_ClientID is NULL, '', WHP_ClientID) AS CLIENT_ID, " & Environment.NewLine          '37
                strSql &= "'EXTPRV03' as DEVCOD, " & Environment.NewLine        '38
                strSql &= "'PSSI' as USR_ID " & Environment.NewLine             '39

                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tpretest_data ON tdevice.Device_ID = tpretest_data.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN latcle_codes ON tpretest_data.PTtf = latcle_codes.DCode_ID " & Environment.NewLine
                strSql &= "INNER JOIN lcodesdetail ON tpretest_data.PTtf = lcodesdetail.Dcode_ID " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder ON tdevice.wo_ID = tworkorder.wo_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcellopt on tdevice.device_id = tcellopt.device_id " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_Id = tmodel.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN lmanuf ON tmodel.Manuf_ID = lmanuf.Manuf_ID " & Environment.NewLine
                strSql &= "INNER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strSql &= "INNER JOIN twarehousepallet on tworkorder.WO_RecPalletName = twarehousepallet.WHPallet_Number " & Environment.NewLine
                strSql &= "INNER JOIN twarehousepalletload on tdevice.device_sn = twarehousepalletload.WHP_PieceIdentifier and twarehousepallet.WHPallet_ID = twarehousepalletload.WHPallet_ID " & Environment.NewLine
                strSql &= "WHERE tdevice.loc_ID = 2540 " & Environment.NewLine
                'strsql &= " AND Device_DateShip >= '" & strStartDtTime & "'" & Environment.NewLine
                'strsql &= " AND Device_DateShip <= '" & strEndDtTime & "'" & Environment.NewLine

                'strSql &= " and tdevice.pallett_id in ( " & strPalletIDs & " ) " & Environment.NewLine
                strSql &= "AND tdevice.pallett_id in ( " & strPalletIDs & " ) " & Environment.NewLine
                strSql &= "AND WHP_ClientID IS NOT NULL " & Environment.NewLine
                strSql &= "ORDER BY tpallett.Pallet_ShipType;"

                dt1 = Me._objDataProc.GetDataTable(strSql)

                If dt1.Rows.Count > 0 Then
                    strDT = Generic.MySQLServerDateTime(1)

                    strXMLFileName = "PSSI_" & Format(CDate(strDT), "yyyyMMdd") & "_"

                    iFileNum = Format(Me.GetATCLE_XMLShipRptNum(strXMLFileName), "###")
                    strXMLFileName &= iFileNum & ".XML"

                    ''************************************************************
                    xmlTextWriter = New xmlTextWriter(strWriteXMLto & strXMLFileName, System.Text.Encoding.ASCII)
                    xmlTextWriter.Formatting = Formatting.Indented

                    xmlTextWriter.WriteStartElement("UC_TR_INB_IFD")    '(1)

                    '************************************************************
                    xmlTextWriter.WriteStartElement("CTRL_SEG")         '(2)
                    xmlTextWriter.WriteElementString("TRNNAM", "UC_TR_INB")
                    xmlTextWriter.WriteElementString("TRNVER", "DCS V5.0")

                    '************************************************************
                    For Each R1 In dt1.Rows

                        'STEP 3 Build Header
                        xmlTextWriter.WriteStartElement("HEADER_SEG") 'Open Device header   (3)

                        'Write Device header data here
                        For i = 1 To 37     '37 fields in header
                            Me.SetXMLFieldData(i, R1, strFieldName, strFieldValue)
                            xmlTextWriter.WriteElementString(strFieldName, strFieldValue)   '(4) Header String Open and Close
                        Next i

                        i = 1

                        xmlTextWriter.WriteEndElement()     'Close Device Header        (3)
                    Next R1
                    '************************************************************

                    xmlTextWriter.WriteEndElement()     '(2)
                    xmlTextWriter.WriteEndElement()     '(1)        'New

                    xmlTextWriter.Close()

                    '*****************************************************
                    'Write Report information to table  tatcle_xmlshiprpt
                    '*****************************************************
                    strSql = "INSERT INTO tatcle_xmlshiprpt ( " & Environment.NewLine
                    strSql &= "Rpt_SendDt " & Environment.NewLine
                    strSql &= ",  Rpt_Name " & Environment.NewLine
                    strSql &= ",  Rpt_Pallett_IDs " & Environment.NewLine
                    strSql &= ",  Rpt_Qty " & Environment.NewLine
                    strSql &= ",  Rpt_UserName " & Environment.NewLine
                    strSql &= ") VALUES ( " & Environment.NewLine
                    strSql &= "'" & strDT & "'" & Environment.NewLine
                    strSql &= ", '" & strXMLFileName & "'" & Environment.NewLine
                    strSql &= ", '" & strPalletIDs & "'" & Environment.NewLine
                    strSql &= ",  " & dt1.Rows.Count & " " & Environment.NewLine
                    strSql &= ", '" & strUserName & "'" & Environment.NewLine
                    strSql &= ");"
                    Me._objDataProc.ExecuteNonQuery(strSql)

                    '**************************
                    'Write to log file
                    '**************************
                    FileOpen(1, strLogFileLoc, OpenMode.Append)   'Open TXT file
                    strLogData &= strDT & " FileName:" & strXMLFileName & " User: " & strUserName & vbCrLf
                    strLogData &= vbTab & "Pallet ID List: " & strPalletIDs & vbCrLf
                    PrintLine(1, strLogData)
                End If

                Return dt1.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                Reset()
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                R2 = Nothing
                If Not IsNothing(dt2) Then
                    dt2.Dispose()
                    dt2 = Nothing
                End If
            End Try
        End Function

        '*******************************************************************
        'XML Tags/fields mapping
        Private Sub SetXMLFieldData(ByVal iIndex As Integer, _
                                    ByVal R1 As DataRow, _
                                    ByRef strFieldName As String, _
                                    ByRef strFieldValue As String)
            strFieldName = ""
            strFieldValue = ""

            If IsDBNull(R1) Then
                strFieldName = "ERROR"
                strFieldValue = ""
                Exit Sub
            End If

            Select Case iIndex
                Case 1
                    strFieldName = "SEGNAM"
                    If Not IsDBNull(R1("SEGNAM")) Then
                        strFieldValue = R1("SEGNAM")
                    End If
                    Exit Sub
                Case 2
                    strFieldName = "TRNTYP"
                    If Not IsDBNull(R1("TRNTYP")) Then
                        strFieldValue = R1("TRNTYP")
                    End If
                    Exit Sub
                Case 3
                    strFieldName = "DTLNUM"
                    If Not IsDBNull(R1("DTLNUM")) Then
                        strFieldValue = R1("DTLNUM")
                    End If
                    Exit Sub
                Case 4
                    strFieldName = "UC_REPPRV"
                    If Not IsDBNull(R1("UC_REPPRV")) Then
                        strFieldValue = R1("UC_REPPRV")
                    End If
                    Exit Sub
                Case 5
                    strFieldName = "UC_REP_CELL"
                    If Not IsDBNull(R1("UC_REP_CELL")) Then
                        strFieldValue = R1("UC_REP_CELL")
                    End If
                    Exit Sub
                Case 6
                    strFieldName = "UC_REPSTS"
                    If Not IsDBNull(R1("UC_REPSTS")) Then
                        strFieldValue = R1("UC_REPSTS")
                    End If
                    Exit Sub
                Case 7
                    strFieldName = "PRTNUM"
                    If Not IsDBNull(R1("PRTNUM")) Then
                        strFieldValue = R1("PRTNUM")
                    End If
                    Exit Sub
                Case 8
                    strFieldName = "PRT_CLIENT_ID"
                    If Not IsDBNull(R1("PRT_CLIENT_ID")) Then
                        strFieldValue = R1("PRT_CLIENT_ID")
                    End If
                    Exit Sub
                Case 9
                    strFieldName = "ADDDTE"
                    If Not IsDBNull(R1("ADDDTE")) Then
                        strFieldValue = R1("ADDDTE")
                    End If
                    Exit Sub
                Case 10
                    strFieldName = "RFTEST"
                    If Not IsDBNull(R1("RFTEST")) Then
                        strFieldValue = R1("RFTEST")
                    End If
                    Exit Sub
                Case 11
                    strFieldName = "FUNCTST"
                    If Not IsDBNull(R1("FUNCTST")) Then
                        strFieldValue = R1("FUNCTST")
                    End If
                    Exit Sub
                Case 12
                    strFieldName = "FLSHRST"
                    If Not IsDBNull(R1("FLSHRST")) Then
                        strFieldValue = R1("FLSHRST")
                    End If
                    Exit Sub
                Case 13
                    strFieldName = "POLBUF"
                    If Not IsDBNull(R1("POLBUF")) Then
                        strFieldValue = R1("POLBUF")
                    End If
                    Exit Sub
                Case 14
                    strFieldName = "COSREP"
                    If Not IsDBNull(R1("COSREP")) Then
                        strFieldValue = R1("COSREP")
                    End If
                    Exit Sub
                Case 15
                    strFieldName = "RETCOD"
                    If Not IsDBNull(R1("RETCOD")) Then
                        strFieldValue = R1("RETCOD")
                    End If
                    Exit Sub
                Case 16
                    strFieldName = "TRBFND"
                    If Not IsDBNull(R1("TRBFND")) Then
                        strFieldValue = R1("TRBFND")
                    End If
                    Exit Sub
                Case 17
                    strFieldName = "MATCH"
                    If Not IsDBNull(R1("MATCH")) Then
                        strFieldValue = R1("MATCH")
                    End If
                    Exit Sub
                Case 18
                    strFieldName = "ABUSE"
                    If Not IsDBNull(R1("ABUSE")) Then
                        strFieldValue = R1("ABUSE")
                    End If
                    Exit Sub
                Case 19
                    strFieldName = "COMMENT1"
                    If Not IsDBNull(R1("COMMENT1")) Then
                        strFieldValue = R1("COMMENT1")
                    End If
                    Exit Sub
                Case 20
                    strFieldName = "COMMENT2"
                    If Not IsDBNull(R1("COMMENT2")) Then
                        strFieldValue = R1("COMMENT2")
                    End If
                    Exit Sub
                Case 21
                    strFieldName = "SERIALNUM"
                    If Not IsDBNull(R1("SERIALNUM")) Then
                        strFieldValue = R1("SERIALNUM")
                    End If
                    Exit Sub
                Case 22
                    strFieldName = "CALLTIMER"
                    If Not IsDBNull(R1("CALLTIMER")) Then
                        strFieldValue = R1("CALLTIMER")
                    End If
                    Exit Sub
                Case 23
                    strFieldName = "WARRANTY"
                    If Not IsDBNull(R1("WARRANTY")) Then
                        strFieldValue = R1("WARRANTY")
                    End If
                    Exit Sub
                Case 24
                    strFieldName = "UC_REP_USR_ID"
                    If Not IsDBNull(R1("UC_REP_USR_ID")) Then
                        strFieldValue = R1("UC_REP_USR_ID")
                    End If
                    Exit Sub
                Case 25
                    strFieldName = "REPDTE"
                    If Not IsDBNull(R1("REPDTE")) Then
                        strFieldValue = R1("REPDTE")
                    End If
                    Exit Sub
                Case 26
                    strFieldName = "NWSVER"
                    If Not IsDBNull(R1("NWSVER")) Then
                        strFieldValue = R1("NWSVER")
                    End If
                    Exit Sub
                Case 27
                    strFieldName = "ORGCOD"
                    If Not IsDBNull(R1("ORGCOD")) Then
                        strFieldValue = R1("ORGCOD")
                    End If
                    Exit Sub
                Case 28
                    strFieldName = "PRLNUM"
                    If Not IsDBNull(R1("PRLNUM")) Then
                        strFieldValue = R1("PRLNUM")
                    End If
                    Exit Sub
                    'Case 29
                    '    strFieldName = "RMANUM"
                    '    If Not IsDBNull(R1("RMANUM")) Then
                    '        strFieldValue = R1("RMANUM")
                    '    End If
                    '    Exit Sub
                Case 29
                    strFieldName = "CALLTIMER_HOUR"
                    If Not IsDBNull(R1("CALLTIMER_HOUR")) Then
                        strFieldValue = R1("CALLTIMER_HOUR")
                    End If
                    Exit Sub
                Case 30
                    strFieldName = "CALLTIMER_MIN"
                    If Not IsDBNull(R1("CALLTIMER_MIN")) Then
                        strFieldValue = R1("CALLTIMER_MIN")
                    End If
                    Exit Sub
                Case 31
                    strFieldName = "TRBCOD"
                    If Not IsDBNull(R1("TRBCOD")) Then
                        strFieldValue = R1("TRBCOD")
                    End If
                    Exit Sub
                    'Case 33
                    '    strFieldName = "RCVKEY"
                    '    If Not IsDBNull(R1("RCVKEY")) Then
                    '        strFieldValue = R1("RCVKEY")
                    '    End If
                    '    Exit Sub
                Case 32
                    strFieldName = "FUNREP"
                    If Not IsDBNull(R1("FUNREP")) Then
                        strFieldValue = R1("FUNREP")
                    End If
                    Exit Sub
                Case 33
                    strFieldName = "FINQA"
                    If Not IsDBNull(R1("FINQA")) Then
                        strFieldValue = R1("FINQA")
                    End If
                    Exit Sub
                Case 34
                    strFieldName = "NOFAULT"
                    If Not IsDBNull(R1("NOFAULT")) Then
                        strFieldValue = R1("NOFAULT")
                    End If
                    Exit Sub
                Case 35
                    strFieldName = "CLIENT_ID"
                    If Not IsDBNull(R1("CLIENT_ID")) Then
                        strFieldValue = R1("CLIENT_ID")
                    End If
                    Exit Sub
                Case 36
                    strFieldName = "DEVCOD"
                    If Not IsDBNull(R1("DEVCOD")) Then
                        strFieldValue = R1("DEVCOD")
                    End If
                    Exit Sub
                Case 37
                    strFieldName = "USR_ID"
                    If Not IsDBNull(R1("USR_ID")) Then
                        strFieldValue = R1("USR_ID")
                    End If
                    Exit Sub
            End Select
        End Sub

        '*******************************************************************
        Private Function GetATCLE_XMLShipRptNum(ByVal strRptPrefix As String) As Integer
            Dim strSql As String
            Dim iRptNum As Integer

            Try
                strSql = "SELECT count(*) + 1 as RptNum " & Environment.NewLine
                strSql &= "FROM tatcle_xmlshiprpt " & Environment.NewLine
                strSql &= "WHERE Rpt_Name LIKE '" & strRptPrefix & "%' ;"

                iRptNum = Me._objDataProc.GetIntValue(strSql)

                Return iRptNum
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************
        Public Function SetSendDate(ByVal strPallettIDs As String, _
                                    ByVal strWork_Dt As String) As Integer
            Dim strSql As String

            Try
                strSql = "UPDATE tpallett " & Environment.NewLine
                strSql &= "SET Pallett_SendDt = '" & strWork_Dt & "'" & Environment.NewLine
                strSql &= "WHERE Pallett_ID in (" & strPallettIDs & ");"

                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************
        Public Function GetPalletQty(ByVal iPallett_ID As Integer) As Integer
            Dim strSql As String

            Try
                strSql = "SELECT count(*) as cnt " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "WHERE Pallett_ID = " & iPallett_ID & ";"

                Return Me._objDataProc.GetIntValue(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************
        Public Function CreatePackingSlip(ByVal iCust_ID As Integer, _
                                          ByVal iUserID As Integer, _
                                          Optional ByVal iShipToID As Integer = 0, _
                                          Optional ByVal strTrackingNo As String = "", _
                                          Optional ByVal strDockShipDate As String = "", _
                                          Optional ByVal iShipCarrierID As Integer = 0, _
                                          Optional ByVal decShippingCost As Decimal = 0.0, _
                                          Optional ByVal iSkidQty As Integer = 0, _
                                          Optional ByVal iCartonQty As Integer = 0) As Integer
            Dim strSql As String
            Dim i As Integer

            Try
                strSql = "INSERT INTO tpackingslip ( " & Environment.NewLine
                strSql &= "pkslip_createDt " & Environment.NewLine
                strSql &= ", Cust_ID " & Environment.NewLine
                strSql &= ", pkslip_usrID " & Environment.NewLine
                strSql &= ", ShipmentCost " & Environment.NewLine
                If iShipToID > 0 Then strSql &= ", ShipTo_ID " & Environment.NewLine
                If strTrackingNo.Trim.Length > 0 Then
                    strSql &= ", tpackingslip.pkslip_TrackNo " & Environment.NewLine
                    strSql &= ", tpackingslip.pkslip_DockShipDate " & Environment.NewLine
                    strSql &= ", tpackingslip.pkslip_DSUpdateUserID " & Environment.NewLine
                    strSql &= ", tpackingslip.pkSlip_DSUpdateDate " & Environment.NewLine
                End If
                If iShipCarrierID > 0 Then strSql &= ", SC_ID " & Environment.NewLine
                If iSkidQty > 0 Then strSql &= ", SkidQty " & Environment.NewLine
                If iCartonQty > 0 Then strSql &= ", GaylordQty " & Environment.NewLine
                strSql &= ") VALUES ( " & Environment.NewLine
                strSql &= "now() " & Environment.NewLine
                strSql &= ", " & iCust_ID & " " & Environment.NewLine
                strSql &= ", " & iUserID & " " & Environment.NewLine
                strSql &= ", " & decShippingCost & " " & Environment.NewLine
                If iShipToID > 0 Then strSql &= ", " & iShipToID & Environment.NewLine
                If strTrackingNo.Trim.Length > 0 Then
                    strSql &= ", '" & strTrackingNo & "' " & Environment.NewLine
                    If strDockShipDate.Trim.Length = 0 Then strSql &= ", now() " & Environment.NewLine Else strSql &= ", '" & strDockShipDate & "' " & Environment.NewLine
                    strSql &= ", " & iUserID & Environment.NewLine
                    strSql &= ", now() " & Environment.NewLine
                End If
                If iShipCarrierID > 0 Then strSql &= ", " & iShipCarrierID & Environment.NewLine
                If iSkidQty > 0 Then strSql &= ", " & iSkidQty & Environment.NewLine
                If iCartonQty > 0 Then strSql &= ", " & iCartonQty & Environment.NewLine
                strSql &= ");"
                i = Me._objDataProc.idTransaction(strSql, "tpackingslip")

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************
        Public Function UpdatePackingSlipInvoiceInfo(ByVal iInvoiceWeek As Integer, _
                                                     ByVal strWrkDt As String, _
                                                     ByVal iUserID As Integer, _
                                                     ByVal iPkslipID As Integer) As Integer
            Dim strSql As String
            Dim i As Integer

            Try
                strSql = "UPDATE tpackingslip SET " & Environment.NewLine
                strSql &= "pkslip_invoiceUsrID = " & iUserID & " " & Environment.NewLine
                strSql &= ", pkslip_invoiceDt = '" & strWrkDt & "' " & Environment.NewLine
                strSql &= ", pkslip_invoiceWk " & iInvoiceWeek & " " & Environment.NewLine
                strSql &= "WHERE pkslip_ID = " & iPkslipID & ";"
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************

        Public Function CheckModel(ByVal pallett_name As String, ByVal Loc_id As Integer) As Integer
            Dim strSql As String
            Dim i As Integer
            Dim dt As New DataTable()
            Try
                strSql = "SELECT model_id FROM tpallett where pallett_name ='" & pallett_name & "' and loc_id=" & Loc_id & "" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                Return dt.Rows(0)("model_id")
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '***************************************************************************

        Public Function ValidateShippedPallet(ByVal strPalletName As String, _
                                              ByVal iCust_ID As Integer, _
                                              ByVal iWOID As Integer) As DataTable
            Dim dt As DataTable
            Dim strSql As String
            Dim dtDeviceInfo As New DataTable()
            Try
                ValidateShippedPallet = Nothing

                strSql = "SELECT * " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "WHERE tpallett.Pallett_Name = '" & strPalletName & "' " & Environment.NewLine
                strSql &= "AND Cust_ID = " & iCust_ID & ";"

                dt = Me._objDataProc.GetDataTable(strSql)

                'Skullcandy Retail, Old process. Create Pallet by copy pallet from tBulkRecPallet
                If iCust_ID = 2577 AndAlso dt.Rows.Count = 0 Then
                    Dim dtOldProcess As DataTable, iPalletID As Integer = 0
                    strSql = "SELECT tbulkrecpallet.PalletCreateDate as Pallett_ShipDate,tbulkreceive.dcode_ID,lcodesdetail.Dcode_LDesc" & Environment.NewLine
                    strSql &= " ,count(*) as RecNum,tbulkrecpallet.BRP_ID,tbulkreceive.Pallett_ID,sum(tbulkreceive.Quantity) as Qty" & Environment.NewLine
                    strSql &= " FROM tbulkreceive INNER JOIN tbulkrecpallet on tbulkreceive.BRP_ID = tbulkrecpallet.BRP_ID" & Environment.NewLine
                    strSql &= " inner join lcodesdetail on tbulkreceive.dcode_ID = lcodesdetail.dcode_ID" & Environment.NewLine
                    strSql &= " where tbulkreceive.Cust_ID=" & iCust_ID & " and PalletName = '" & strPalletName & "'" & Environment.NewLine
                    strSql &= " group by tbulkrecpallet.PalletCreateDate,tbulkreceive.dcode_ID,tbulkrecpallet.BRP_ID,tbulkreceive.Pallett_ID;" & Environment.NewLine
                    dtOldProcess = Me._objDataProc.GetDataTable(strSql)
                    If dtOldProcess.Rows.Count = 0 Then
                        MessageBox.Show("Skullcandy Retail Old Process: Pallet/Lot name does not exist for the selected customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Exit Function
                    ElseIf dtOldProcess.Rows.Count > 1 Then
                        MessageBox.Show("Skullcandy Retail Old Process: Pallet/Lot existed more than one in the system. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Exit Function
                    ElseIf dtOldProcess.Rows(0)("Pallett_ID") > 0 Then
                        MessageBox.Show("Skullcandy Retail Old Process: Pallett_ID already in this box. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Exit Function
                    Else 'create pallet in tPallet
                        Dim objSkullcandy As New Skullcandy()
                        Dim strDate As String, dDate As Date
                        If IsDate(dtOldProcess.Rows(0)("Pallett_ShipDate")) Then
                            dDate = dtOldProcess.Rows(0)("Pallett_ShipDate")
                            strDate = Format(dDate, "yyyy-MM-dd")
                        Else
                            strDate = Format(Now, "yyyy-MM-dd")
                        End If
                        iPalletID = objSkullcandy.SkullcandyRetail_OldProcess_CreatePalletID(strPalletName, strDate, _
                                                                                  dtOldProcess.Rows(0)("DCode_ID"), iCust_ID, 3380, _
                                                                                  dtOldProcess.Rows(0)("Qty"), dtOldProcess.Rows(0)("BRP_ID"))
                        If iPalletID > 0 Then
                            strSql = "SELECT * " & Environment.NewLine
                            strSql &= "FROM tpallett " & Environment.NewLine
                            strSql &= "WHERE tpallett.Pallett_Name = '" & strPalletName & "' " & Environment.NewLine
                            strSql &= "AND Cust_ID = " & iCust_ID & ";"
                            dt = Me._objDataProc.GetDataTable(strSql)
                        Else
                            MessageBox.Show("Skullcandy Retail Old Process: Failed to create pallet before dockship.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Exit Function
                        End If
                    End If
                End If
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Pallet/Lot name does not exist for the selected customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf dt.Rows.Count > 1 Then
                    MessageBox.Show("Pallet/Lot existed more than one in the system. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf dt.Rows.Count = 1 Then
                    If IsDBNull(dt.Rows(0)("Pallett_ShipDate")) Then
                        Throw New Exception("Pallet is not shipped in the system.")
                    ElseIf (dt.Rows(0)("AWPFlag")) = 1 Then
                        Throw New Exception("Pallet is waiting for part.")
                    ElseIf Not IsDBNull(dt.Rows(0)("pkslip_ID")) Then
                        Throw New Exception("Pallet is already assigned packing slip #" & dt.Rows(0)("pkslip_ID") & ".")
                    ElseIf iCust_ID = 2427 AndAlso iWOID > 0 AndAlso dt.Select("WO_ID <> " & iWOID).Length > 0 Then
                        MessageBox.Show("This customer does not allow mix orders.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Else
                        If iCust_ID = _objVivint.Vivint_CUSTOMER_ID Then
                            dtDeviceInfo = GetDeviceInfo(dt.Rows(0)("pallett_id"), dt.Rows(0)("Loc_id")) 'check if the pallet id conatins a device whith no date ship
                            If dtDeviceInfo.Rows.Count > 0 Then
                                Throw New Exception("There is a device with no Date ship ")
                            End If
                        End If
                        Return dt
                    End If
                End If
            Catch ex As Exception
                Throw New System.Exception(ex.Message)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '*******************************************************************
        Public Function RemoveManifestNumFrPallets(ByVal iCust_ID As Integer, _
                                                   ByVal strPallettIDs As String, _
                                                   ByVal iUserID As Integer, _
                                                   ByVal iPkslip_ID As Integer) As Integer
            Dim strSql As String
            Dim i As Integer = 0

            Try
                If iCust_ID = 14 Then
                    strSql = "UPDATE tpallett, tdevice, tmessdata " & Environment.NewLine
                    strSql &= "SET pkslip_ID = null " & Environment.NewLine
                    strSql &= ", tmessdata.wipowner_id_Old = tmessdata.wipowner_id " & Environment.NewLine
                    strSql &= ", tmessdata.wipowner_id = 5 " & Environment.NewLine
                    strSql &= ", tmessdata.wipowner_EntryDt = now() " & Environment.NewLine
                    strSql &= "WHERE tpallett.Pallett_ID = tdevice.Pallett_ID AND tdevice.Device_ID = tmessdata.Device_ID " & Environment.NewLine
                    strSql &= "AND tpallett.Pallett_ID IN ( " & strPallettIDs & " ) " & Environment.NewLine
                    strSql &= "AND tpallett.Cust_ID = " & iCust_ID & ";" & Environment.NewLine
                Else
                    strSql = "UPDATE tpallett, tdevice, tcellopt " & Environment.NewLine
                    strSql &= "SET pkslip_ID = null " & Environment.NewLine
                    strSql &= ", tcellopt.Cellopt_WIPOwnerOld = tcellopt.Cellopt_WIPOwner " & Environment.NewLine
                    strSql &= ", tcellopt.Cellopt_WIPOwner = 5 " & Environment.NewLine
                    strSql &= ", tcellopt.Cellopt_WIPEntryDt = now() " & Environment.NewLine
                    strSql &= "WHERE tpallett.Pallett_ID = tdevice.Pallett_ID AND tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                    strSql &= "AND tpallett.Pallett_ID IN ( " & strPallettIDs & " ) " & Environment.NewLine
                    strSql &= "AND tpallett.Cust_ID = " & iCust_ID & ";" & Environment.NewLine
                End If

                i = Me._objDataProc.ExecuteNonQuery(strSql)

                i += Me.UpdateManifestUsrID(iPkslip_ID, iUserID)

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        Public Function GetDeviceInfo(ByVal iPallett_ID As Integer, ByVal loc_id As Integer) As DataTable
            Dim strSql As String
            Try
                strSql = "select * from tdevice  where pallett_id= " & iPallett_ID & " and Device_DateShip is null and Loc_id=" & loc_id & " " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '*******************************************************************
        Public Function UpdateManifestUsrID(ByVal iPkslipID As Integer, _
                                            ByVal iUserID As Integer) As Integer
            Dim strSql As String

            Try
                strSql = "UPDATE tpackingslip SET " & Environment.NewLine
                strSql &= "pkslip_usrID = " & iUserID & Environment.NewLine
                strSql &= "WHERE pkslip_id = " & iPkslipID & ";" & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GenerateRvi(ByVal Pallet_List As Integer, ByVal iLoc_ID As Integer) As String
            Dim strFile As String
            Dim strLocation As String
            Dim dtTime As DateTime = Now
            dtTime = dtTime.ToUniversalTime
            Dim res As String = dtTime.ToString("yyyyMMddTHHmmssZ")
            Dim _dtShipment As New DataTable()
            If iLoc_ID = PSS.Data.Buisness.CP.CoolPad.CoolPad_CP1_Loc_ID OrElse iLoc_ID = PSS.Data.Buisness.CP.CoolPad.CoolPad_Special_LOC_ID Then
                strLocation = "P:\OUTBOUND\COOLPAD\RVIS\"
                strFile = "RVI_COO_" & res & "_S" & Now.ToString("yyyyMMddHHMMss") & ".xml"
            ElseIf iLoc_ID = PSS.Data.Buisness.WingTech.WingTech.WingTech_CP1_Loc_ID Then
                strLocation = "P:\OUTBOUND\WINGTECH\T-MOBILE\"
                strFile = "RVI_WIT_" & res & "_S" & Now.ToString("yyyyMMddHHMMss") & ".xml"
            End If
            Dim strFilename As String = strLocation & strFile
            Dim strSql3 As String = ""
            Dim carrier, palletName As String
            carrier = "FedEx"

            '*** IF(D.loc_id = 4497 added in the query to eliminate empty RepairLevel for Coolpad SP.  Charles Hummer  19-Jul-2021
            strSql3 &= "SELECT  'Z_SHIPMENT_RESULT' AS Event, 'REPAIR' AS Type, Retailer AS PlantID, A.ACCOUNT AS Vendor, D.device_id AS InternalDeviceID ," & Environment.NewLine
            strSql3 &= "EW_ID AS ReverseLogisticsVisitDeviceID,serialNo  AS IMEI, device_SN  AS NewIMEI,'' AS AppleSerialNumber, '' AS NewAppleSerialNumber ,'L' AS StatusCode," & Environment.NewLine
            strSql3 &= "IF(Device_Laborlevel=15,0,coalesce(Device_Laborlevel,0)) AS RepairLevel, " & Environment.NewLine
            strSql3 &= " pallett_Shipdate AS StartDatetime,pallett_Shipdate AS EndDatetime, Item_SKU AS SKU,IF(D.loc_id=4487,'COOLPAD','WingTech') AS Make, Model,'' AS Brand," & Environment.NewLine
            strSql3 &= "Warranty_Desc AS RepairProgramType,OEM_RA AS RMANumber, ClaimNo AS PurchaseOrderNumber,ClaimLineNo AS PurchaseOrderLineNumber,Retailer2 AS ShipToID,Retailer2 AS ReturnPlantID," & Environment.NewLine
            strSql3 &= " '" & carrier & "' AS Carrier, E.pkslip_trackNo AS CarrierTrackingNumber,PSSI2Cust_BillofLading AS BillofLading, pallett_Name AS PalletID,pallett_Name  AS MasterCartonID,'' AS HardwareVersion," & Environment.NewLine
            strSql3 &= "'' AS SoftwareVersion " & Environment.NewLine
            strSql3 &= "FROM extendedwarranty A" & Environment.NewLine
            strSql3 &= "inner join Edi.twarehousebox B ON  A.wb_id = B.wb_id" & Environment.NewLine
            strSql3 &= "Inner join production.tpallett  C ON D.Pallett_ID = C.Pallett_ID " & Environment.NewLine
            strSql3 &= "inner join tdevice D ON D.device_id=A.device_id " & Environment.NewLine
            strSql3 &= "inner join tpackingslip E ON E.Pkslip_ID=C.Pkslip_ID " & Environment.NewLine
            'strSql3 &= "INNER JOIN llaborlvl E ON Device_Laborlevel=laborlvl_id" & Environment.NewLine
            strSql3 &= "WHERE D.loc_id = '" & iLoc_ID & "' And pallett_shipdate Is Not NULL and C.Pkslip_ID  =" & Pallet_List & "  AND bulkordertype_id =1 " & Environment.NewLine
            strSql3 &= "UNION " & Environment.NewLine
            strSql3 &= "SELECT  'Z_SHIPMENT_RESULT' AS Event, 'REPAIR' AS Type, Retailer AS PlantID,A.ACCOUNT AS Vendor, D.device_id AS InternalDeviceID ," & Environment.NewLine
            strSql3 &= "EW_ID AS ReverseLogisticsVisitDeviceID,serialNo  AS IMEI,device_SN   AS NewIMEI,'' AS AppleSerialNumber, '' AS NewAppleSerialNumber ,'L' AS StatusCode," & Environment.NewLine
            strSql3 &= "IF(Device_Laborlevel=15,0,coalesce(Device_Laborlevel,0)) AS RepairLevel, " & Environment.NewLine
            strSql3 &= " pallett_Shipdate AS StartDatetime,pallett_Shipdate AS EndDatetime, Item_SKU AS SKU,IF(D.loc_id=4487,'COOLPAD','WingTech') AS Make, Model,'' AS Brand," & Environment.NewLine
            strSql3 &= "Warranty_Desc AS RepairProgramType,OEM_RA AS RMANumber, ClaimNo AS PurchaseOrderNumber,ClaimLineNo AS PurchaseOrderLineNumber,Retailer2 AS ShipToID,Retailer2 AS ReturnPlantID," & Environment.NewLine
            strSql3 &= " '" & carrier & "' AS Carrier,E.pkslip_trackNo AS CarrierTrackingNumber,PSSI2Cust_BillofLading AS BillofLading, pallett_Name AS PalletID,pallett_Name  AS MasterCartonID,'' AS HardwareVersion," & Environment.NewLine
            strSql3 &= "'' AS SoftwareVersion " & Environment.NewLine
            strSql3 &= "FROM extendedwarranty A" & Environment.NewLine
            strSql3 &= "inner join Edi.twarehousebox B ON  A.wb_id = B.wb_id" & Environment.NewLine
            strSql3 &= "Inner join production.tpallett  C ON D.Pallett_ID = C.Pallett_ID " & Environment.NewLine
            strSql3 &= "inner join tdevice D ON D.device_id=A.Swapped_Device_ID" & Environment.NewLine
            strSql3 &= "inner join tpackingslip E ON E.Pkslip_ID=C.Pkslip_ID " & Environment.NewLine
            'strSql3 &= "INNER JOIN llaborlvl E ON Device_Laborlevel=laborlvl_id" & Environment.NewLine
            strSql3 &= "WHERE D.loc_id = '" & iLoc_ID & "' And pallett_shipdate Is Not NULL and C.Pkslip_ID  =" & Pallet_List & " " & Environment.NewLine
            _dtShipment = Me._objDataProc.GetDataTable(strSql3)

            If _dtShipment.Rows.Count > 0 Then
                WriteToXMLFile(_dtShipment, strFilename)
                Return strFilename
            Else
                Return "Failed"
            End If
            _dtShipment.Clear()
        End Function


        Protected Sub WriteToXMLFile(ByVal dt As DataTable, ByVal strFileName As String)
            Dim arRequiredField() As String = {"Event", "Type", "StatusCode", "RepairLevel", "RepairProgramType", "StartDatetime", "EndDatetime", _
             "PlantID", "Vendor", "NewIMEI", "IMEI", "InternalDeviceID", "ReverseLogisticsVisitDeviceID", "SKU"} ', _   
            Dim intEnum As Integer = 4
            Dim bIsBER As Boolean = False
            Dim column As DataColumn
            Dim bIsPass As Boolean
            'Dim xmlWriterSet As New XmlWriterSettings()
            Dim dtFailedRVI As New DataTable()
            Dim Dtmaterials As New DataTable()
            Dim dtOutcomes As New DataTable()
            dtFailedRVI = dt.Clone
            Dim strIMEI, StrNewIMEI As String
            Dim strDevice_id As String = String.Empty
            Dim xmlWrit As New XmlTextWriter(strFileName, System.Text.Encoding.UTF8)
            xmlWrit.Formatting = Formatting.Indented
            'xmlWrit.Indentation = 4
            Dim arrColumnsRvi As New ArrayList()
            For Each column In dt.Columns
                arrColumnsRvi.Add(column.ColumnName)
            Next
            If dt.Rows.Count = 0 Then
                Exit Sub
            End If
            Dim i As Integer
            Dim strFields As String

            xmlWrit.WriteStartDocument()
            xmlWrit.WriteStartElement("RVIS")
            Dim dr As DataRow
            For Each dr In dt.Rows
                For Each strFields In arRequiredField

                    If Trim(dr(strFields).ToString) = String.Empty Then
                        dtFailedRVI.NewRow()
                        dtFailedRVI.ImportRow(dr)
                        GoTo skipEmptyRow
                    End If
                Next
                bIsPass = False
                xmlWrit.WriteStartElement("RVI")
                For i = 0 To arrColumnsRvi.Count - 1

                    Dim strTagValue As String = dr(arrColumnsRvi(i).ToString).ToString
                    Dim strTagName As String = arrColumnsRvi(i).ToString

                    If strTagValue <> "" And (strTagName = "StartDatetime" Or strTagName = "EndDatetime") Then
                        Dim dateConverted As String = Convert.ToDateTime(strTagValue).ToString("yyyy-MM-ddTHH:MM:ssZ")
                        strTagValue = dateConverted.ToString
                    End If
                    Dim strpalled_id As String = dr("PalletID")
                    If strpalled_id.IndexOf("B") <> -1 Then
                        bIsBER = True
                    End If
                    If strTagName = "InternalDeviceID" Then
                        strDevice_id = strTagValue
                    End If
                    If strTagName = "IMEI" Then
                        strIMEI = strTagValue
                    End If
                    If strTagName = "NewIMEI" Then
                        StrNewIMEI = strTagValue
                    End If
                    If bIsBER And strTagName = "StatusCode" Then
                        strTagValue = "U"
                    End If
                    If bIsBER And strTagName = "RepairLevel" Then
                        strTagValue = "X"
                    End If
                    xmlWrit.WriteStartElement(strTagName)
                    xmlWrit.WriteRaw(strTagValue)
                    xmlWrit.WriteFullEndElement()

                Next
                '------------------OUTCOMES AND MATERIALS FOR TRIAGE, REPAIR, SHIPPING -------------------

                If intEnum = 4 Then
                    dtOutcomes = outcomesValue(strIMEI)
                    '---------------------------FOR TRAIGE, RAPAIR OR SHIPPING------------------------------
                    Dim arrColOutcome As New ArrayList()
                    Dim columnOutcome As DataColumn
                    For Each columnOutcome In dtOutcomes.Columns
                        arrColOutcome.Add(columnOutcome.ColumnName)
                    Next
                    xmlWrit.WriteStartElement("Outcomes")
                    'If Not bIsPass Then
                    Dim drOutocmes As DataRow
                    For Each drOutocmes In dtOutcomes.Rows
                        If drOutocmes("FaultCode").ToString <> "P" Then
                            xmlWrit.WriteStartElement("Outcome")
                            Dim j As Integer
                            For j = 0 To arrColOutcome.Count - 1
                                Dim strTemp As String = drOutocmes(arrColOutcome(j).ToString).ToString
                                Dim strTempTag As String = arrColOutcome(j).ToString
                                xmlWrit.WriteStartElement(strTempTag)
                                xmlWrit.WriteRaw(strTemp)
                                xmlWrit.WriteFullEndElement()
                            Next
                            xmlWrit.WriteFullEndElement()
                        End If
                    Next
                    'End If
                    xmlWrit.WriteFullEndElement()
                End If

                If intEnum = 4 Then  '---------------------------FOR RAPAIR OR SHIPPING ------------------------------
                    Dtmaterials = MaterialsValue(StrNewIMEI)
                    Dim drMaterials As DataRow
                    Dim arrColMaterials As New ArrayList()
                    Dim columnMaterials As DataColumn
                    For Each columnMaterials In Dtmaterials.Columns
                        arrColMaterials.Add(columnMaterials.ColumnName)
                    Next
                    xmlWrit.WriteStartElement("Materials")
                    For Each drMaterials In Dtmaterials.Rows
                        If drMaterials("MaterialCode").ToString <> "BER" Then
                            Dim k As Integer
                            xmlWrit.WriteStartElement("Material")
                            For k = 0 To arrColMaterials.Count - 1
                                Dim strTemp As String = drMaterials(arrColMaterials(k).ToString).ToString
                                xmlWrit.WriteStartElement(arrColMaterials(k).ToString)
                                xmlWrit.WriteRaw(strTemp)
                                xmlWrit.WriteFullEndElement()
                            Next
                            xmlWrit.WriteFullEndElement()
                        End If
                    Next
                    xmlWrit.WriteFullEndElement()
                End If
                xmlWrit.WriteFullEndElement()

                strDevice_id_List += "" + strDevice_id + ","

skipEmptyRow: Next
            xmlWrit.WriteEndDocument()
            Dim xmlsave As New XmlDocument()
            xmlsave.Save(xmlWrit)
            xmlWrit.Close()
            updateDB(strDevice_id_List)

        End Sub

        '-------------------------------------------------
        Private Function MaterialsValue(ByVal SN As String) As DataTable
            Dim dtMaterials As New DataTable()
            Dim strSql As String
            strSql = "  SELECT psprice_desc AS MaterialDescription,IF (LOC_ID=4491,'WingTech','COOLPAD' ) AS MaterialAllocation,IF (LOC_ID=4491,'WingTech','COOLPAD' ) AS MaterialMake ,part_Number AS MaterialCode ,PSPrice_InventoryPart AS MaterialQuantity,'0.0' as MaterialExpense " & Environment.NewLine
            strSql &= "FROM tdevice A" & Environment.NewLine
            strSql &= "INNER JOIN tdevicebill E ON A.device_Id= E.device_Id" & Environment.NewLine
            strSql &= "INNER JOIN production.lpsprice D ON  D.PSPrice_Number=E.part_Number" & Environment.NewLine
            strSql &= "  WHERE device_SN= '" & SN & "' AND part_Number NOT IN ('Swap') " & Environment.NewLine
            dtMaterials = Me._objDataProc.GetDataTable(strSql)
            Dim i As Integer = dtMaterials.Rows.Count
            Return dtMaterials
        End Function

        Private Function outcomesValue(ByVal SN As String) As DataTable
            Dim dtOutcomes As New DataTable()
            Dim strSql As String = ""
            strSql &= "SELECT DISTINCT(Dcode_Sdesc) as FaultCode,Dcode_Ldesc as FaultCodeDefinition,Ocode_sdesc as TMOOutcomeCodes, Material_Class as  MaterialClass  " & Environment.NewLine
            strSql &= "FROM tdevice A" & Environment.NewLine
            strSql &= "INNER JOIN tpretest_data C ON A.device_Id= C.device_Id " & Environment.NewLine
            strSql &= "INNER JOIN lcodesdetail B ON B.Dcode_id=C.Pttf" & Environment.NewLine
            strSql &= "WHERE  A.device_SN ='" & SN & "'  " & Environment.NewLine
            dtOutcomes = Me._objDataProc.GetDataTable(strSql)
            Dim i As Integer = dtOutcomes.Rows.Count
            Return dtOutcomes
        End Function
        '---------------------------------------

        Private strSNList, strDevice_id_List As String
        Private Sub updateDB(ByVal strSN As String)
            Try
                If Not IsDBNull(strSN) Then
                    Dim strSNUpdated As String = strSN.Remove(strSN.Length - 1, 1)

                    Dim strSql As String = String.Empty
                    strSql &= "update extendedwarranty set ship_Ack=1 ,ship_Ack_DTime=current_date()  WHERE Device_id IN ( " & strSNUpdated & " )   and cust_id=" & PSS.Data.Buisness.CP.CoolPad.CoolPad_CUSTOMER_ID & " " & Environment.NewLine
                    Me._objDataProc.ExecuteNonQuery(strSql)
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub



        Public Function UpdateMExtendedWarranty(ByVal pkCarrier As String, _
                                                  ByVal trckNo As String, ByVal pkslip_id As Integer) As Integer
            Dim strSql As String

            Try
                strSql = "UPDATE extendedwarranty,tdevice,tpallett SET " & Environment.NewLine
                strSql &= " PSSI2Cust_TrackNo = '" & trckNo & "'  " & Environment.NewLine
                strSql &= ",PSSI2Cust_Carrier='" & pkCarrier & "'  WHERE pkslip_id = " & pkslip_id & " and tpallett.pallett_id=tdevice.pallett_id and extendedwarranty.device_id=tdevice.device_id ;" & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getModel_id(ByVal Model_Id As Integer) As DataTable
            Dim strSql As String
            Dim dt As DataTable
            Try
                strSql = "SELECT Model_MotoSku    FROM tmodel WHERE Model_id=" & Model_Id & ""
                dt = Me._objDataProc.GetDataTable(strSql)
                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function getPallett_Id(ByVal pId As Integer) As DataTable
            Dim strSql As String
            Dim dt As DataTable
            Try
                strSql = "SELECT pallett_id,Loc_id,model_id,Pallet_ShipType,account  FROM tpallett WHERE pkslip_id=" & pId & ""
                dt = Me._objDataProc.GetDataTable(strSql)
                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '*******************************************************************
        Public Function AssignManifestNumToPallets(ByVal dtPSPallet As DataTable, _
                                                   ByVal iPkslip_ID As Integer, _
                                                   ByVal iUserID As Integer, _
                                                   ByVal iCust_ID As Integer) As Integer
            Dim strSql As String
            Dim strPalletIDs As String
            Dim R1 As DataRow
            Dim i As Integer = 0, j As Integer = 0

            Try
                For Each R1 In dtPSPallet.Rows
                    If strPalletIDs = "" Then
                        strPalletIDs = R1("Pallett_ID")
                    Else
                        strPalletIDs &= "," & R1("Pallett_ID")
                    End If
                Next R1

                'Update pallet seq number as needed
                If Data.Buisness.MessLabel.IsAMSShareableInventoryCustomer(iCust_ID) _
                   OrElse iCust_ID = PSS.Data.Buisness.SkyTel.Anna_CUSTOMER_ID _
                   OrElse iCust_ID = PSS.Data.Buisness.SkyTel.Lahey_CUSTOMER_ID _
                   OrElse iCust_ID = PSS.Data.Buisness.SkyTel.Masco_CUSTOMER_ID _
                   OrElse iCust_ID = PSS.Data.Buisness.SkyTel.Franciscan_CUSTOMER_ID _
                   OrElse iCust_ID = PSS.Data.Buisness.SkyTel.Maine_CUSTOMER_ID _
                   OrElse iCust_ID = PSS.Data.Buisness.SkyTel.SMHC_CUSTOMER_ID Then 'check customers
                    For Each R1 In dtPSPallet.Rows
                        j += 1
                        strSql = "UPDATE tpallett SET " & Environment.NewLine
                        strSql &= "Pallet_SeqNo= " & j & " " & Environment.NewLine
                        strSql &= "WHERE Pallett_ID =" & R1("Pallett_ID") & ";" & Environment.NewLine
                        i += Me._objDataProc.ExecuteNonQuery(strSql)
                    Next
                End If

                'Update related tables
                If strPalletIDs <> "" Then
                    strSql = "UPDATE tpallett SET " & Environment.NewLine
                    strSql &= "pkslip_ID = " & iPkslip_ID & " " & Environment.NewLine
                    strSql &= "WHERE Pallett_ID IN ( " & strPalletIDs & " );" & Environment.NewLine
                    i += Me._objDataProc.ExecuteNonQuery(strSql)

                    i += Me.UpdateManifestUsrID(iPkslip_ID, iUserID)

                    If iCust_ID = SkyTel.AMS_CUSTOMER_ID OrElse iCust_ID = SkyTel.SKYTEL_CUSTOMER_ID OrElse _
                       iCust_ID = SkyTel.MorrisCom_CUSTOMER_ID OrElse iCust_ID = SkyTel.Propage_CUSTOMER_ID OrElse _
                       iCust_ID = SkyTel.Aquis_CUSTOMER_ID OrElse iCust_ID = SkyTel.CookPager_CUSTOMER_ID OrElse _
                       iCust_ID = SkyTel.CriticalAlert_CUSTOMER_ID OrElse iCust_ID = SkyTel.Anna_CUSTOMER_ID Or _
                       iCust_ID = SkyTel.Lahey_CUSTOMER_ID OrElse iCust_ID = SkyTel.Masco_CUSTOMER_ID OrElse _
                       iCust_ID = SkyTel.Maine_CUSTOMER_ID OrElse iCust_ID = SkyTel.Franciscan_CUSTOMER_ID OrElse _
                       iCust_ID = SkyTel.SMHC_CUSTOMER_ID OrElse iCust_ID = SkyTel.A1WirelessComm_CUSTOMER_ID OrElse _
                       iCust_ID = SkyTel.ATS_CUSTOMER_ID Then   'American Messaging
                        strSql = "UPDATE tdevice, tmessdata SET tmessdata.wipowner_id_Old = tmessdata.wipowner_id " & Environment.NewLine
                        strSql &= ", tmessdata.wipowner_id = 7 " & Environment.NewLine
                        strSql &= ", tmessdata.wipowner_EntryDt =  now() " & Environment.NewLine
                        strSql &= "WHERE tdevice.Device_id = tmessdata.Device_id AND Pallett_ID IN ( " & strPalletIDs & " );"
                        i += Me._objDataProc.ExecuteNonQuery(strSql)
                    ElseIf iCust_ID = 2577 Then
                        'do nothing with scrap box
                    Else
                        strSql = "UPDATE tdevice, tcellopt SET tcellopt.Cellopt_WIPOwnerOld = tcellopt.Cellopt_WIPOwner " & Environment.NewLine
                        strSql &= ", tcellopt.Cellopt_WIPOwner = 7 " & Environment.NewLine
                        strSql &= ", tcellopt.Cellopt_WIPEntryDt = now() " & Environment.NewLine
                        strSql &= ", tcellopt.Workstation = 'INTRANSIT', tcellopt.WorkStationEntryDt = now(), tcellopt.WIL_ID = 0 " & Environment.NewLine
                        strSql &= "WHERE tdevice.Device_id = tcellopt.Device_ID AND Pallett_ID IN ( " & strPalletIDs & " );"
                        i += Me._objDataProc.ExecuteNonQuery(strSql)
                    End If
                End If

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                Generic.DisposeDT(dtPSPallet)
            End Try
        End Function

        '*******************************************************************
        Public Function AssignManifestNumToPallet(ByVal iPalletID As Integer, _
                                                   ByVal iPkslip_ID As Integer, _
                                                   ByVal iUserID As Integer, _
                                                   ByVal iCust_ID As Integer) As Integer
            Dim strSql As String
            Dim i As Integer = 0

            Try

                strSql = "UPDATE tpallett SET " & Environment.NewLine
                strSql &= "pkslip_ID = " & iPkslip_ID & " " & Environment.NewLine
                strSql &= "WHERE Pallett_ID = " & iPalletID & ";" & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                i += Me.UpdateManifestUsrID(iPkslip_ID, iUserID)

                If iCust_ID = 14 Or iCust_ID = SkyTel.SKYTEL_CUSTOMER_ID Or iCust_ID = SkyTel.MorrisCom_CUSTOMER_ID Or iCust_ID = SkyTel.Propage_CUSTOMER_ID _
                Or iCust_ID = SkyTel.A1WirelessComm_CUSTOMER_ID Or iCust_ID = SkyTel.ATS_CUSTOMER_ID Then   'American Messaging
                    strSql = "UPDATE tdevice, tmessdata SET tmessdata.wipowner_id_Old = tmessdata.wipowner_id " & Environment.NewLine
                    strSql &= ", tmessdata.wipowner_id = 7 " & Environment.NewLine
                    strSql &= ", tmessdata.wipowner_EntryDt =  now() " & Environment.NewLine
                    strSql &= "WHERE tdevice.Device_id = tmessdata.Device_id AND Pallett_ID = " & iPalletID & ";"
                    i += Me._objDataProc.ExecuteNonQuery(strSql)
                Else
                    strSql = "UPDATE tdevice, tcellopt SET tcellopt.Cellopt_WIPOwnerOld = tcellopt.Cellopt_WIPOwner " & Environment.NewLine
                    strSql &= ", tcellopt.Cellopt_WIPOwner = 7 " & Environment.NewLine
                    strSql &= ", tcellopt.Cellopt_WIPEntryDt = now() " & Environment.NewLine
                    strSql &= ", tcellopt.Workstation = 'INTRANSIT', tcellopt.WorkStationEntryDt = now(), tcellopt.WIL_ID = 0 " & Environment.NewLine
                    strSql &= "WHERE tdevice.Device_id = tcellopt.Device_ID AND Pallett_ID = " & iPalletID & " ;"
                    i += Me._objDataProc.ExecuteNonQuery(strSql)
                End If

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************
        Public Function GetPalletInfoByPackingSlipID(ByVal iPkslip_ID As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT tpallett.*, IF(Model_ID IN (1083, 1086, 1087, 1088, 1089, 1090, 1093), 1, 0) AS IsGH, SC_ID, pkslip_TrackNo, ShipmentCost " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tpackingslip ON tpallett.pkslip_ID = tpackingslip.pkslip_ID " & Environment.NewLine
                strSql &= "WHERE tpallett.pkslip_ID = " & iPkslip_ID & ";" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************
        Public Function GetManifestInfo(ByVal iPkslip_ID As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT * " & Environment.NewLine
                strSql &= "FROM tpackingslip " & Environment.NewLine
                strSql &= "WHERE pkslip_ID = " & iPkslip_ID & ";" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************
        Public Function GetPalletWaitingShipment(ByVal iCust_ID As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT Model_Desc as Model, Pallett_Name PalletName,  " & Environment.NewLine
                strSql &= "Pallett_ShipDate as CompletionDate, " & Environment.NewLine
                strSql &= "count(*) as QTY, " & Environment.NewLine
                strSql &= "(CASE WHEN tpallett.Cust_ID = 2019 THEN " & Environment.NewLine
                strSql &= "(CASE WHEN Pallet_ShipType = 0 THEN 'Refurbished' WHEN Pallet_ShipType = 1 THEN 'RUR' WHEN Pallet_ShipType = 9 THEN 'RTM' ELSE '' END) " & Environment.NewLine
                strSql &= "WHEN tpallett.Cust_ID = 2219 THEN " & Environment.NewLine
                strSql &= "(CASE WHEN tpallett.Model_ID IN (1083, 1086, 1087, 1088, 1089, 1090, 1093) THEN IF( Pallet_ShipType = 0 , 'PASS', 'FAIL') ELSE " & Environment.NewLine
                strSql &= "(CASE WHEN Pallet_ShipType = 0 THEN 'Refurbished' WHEN Pallet_ShipType = 1 THEN 'RUR' WHEN Pallet_ShipType = 8 THEN 'Scrap' WHEN Pallet_ShipType = 9 THEN 'Incomplete' ELSE '' END) " & Environment.NewLine
                strSql &= "END) " & Environment.NewLine
                strSql &= "END) AS PalletShipType " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tpallett.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN tdevice on tpallett.Pallett_ID = tdevice.Pallett_ID " & Environment.NewLine
                strSql &= "WHERE Cust_ID = " & iCust_ID & " " & Environment.NewLine
                strSql &= "AND Pallett_ShipDate is not null " & Environment.NewLine
                strSql &= "AND Pallett_ShipDate >= '2008-02-25' " & Environment.NewLine
                strSql &= "AND pkslip_ID is null " & Environment.NewLine
                strSql &= "AND tpallett.Model_ID not in (1083, 1086, 1087, 1088, 1089, 1090) " & Environment.NewLine
                strSql &= "GROUP BY tpallett.Pallett_ID " & Environment.NewLine
                strSql &= "UNION " & Environment.NewLine
                strSql &= "SELECT Model_Desc as Model, Pallett_Name PalletName " & Environment.NewLine
                strSql &= ", Pallett_ShipDate as CompletionDate " & Environment.NewLine
                strSql &= ", Pallett_QTY as QTY " & Environment.NewLine
                strSql &= ", IF( Pallet_ShipType = 0 , 'PASS', 'FAIL') PalletShipType " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tpallett.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "WHERE Cust_ID = " & iCust_ID & " " & Environment.NewLine
                strSql &= "AND Pallett_ShipDate is not null " & Environment.NewLine
                strSql &= "AND Pallett_ShipDate >= '2008-02-11' " & Environment.NewLine
                strSql &= "AND pkslip_ID is null " & Environment.NewLine
                strSql &= "AND SpecialInvProject = 1 " & Environment.NewLine
                strSql &= "AND Pallet_Invalid = 0 " & Environment.NewLine
                strSql &= "ORDER BY Model, PalletShipType,  CompletionDate" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************
        'Public Function GetInvoiceFlag(ByVal iPkslip_ID As Integer) As Integer
        '    Dim strSql As String

        '    Try
        '        strSql = 
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function

        '******************************************************************
        Public Sub PrintShipPackingSlip(ByVal iPkslip_ID As Integer, ByVal iCustID As Integer)
            Dim dt2 As DataTable
            Dim bNoCustInfo As Boolean = False
            Dim objRpt As ReportDocument
            Dim strRptName As String = "", strRptName2 As String = ""
            Dim strReportLoc As String = PSS.Data.ConfigFile.GetBaseReportPath()
            Dim iWOID As Integer = 0

            Try
                If iCustID = 2627 Then
                    Exit Sub
                End If
                If (MessageBox.Show("Do you want to print 'Customer Information' on 'Manifest'?", "Confirm Customer Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes) Then
                    'strRptName = strReportLoc & "Ship Packing Slip Push.rpt"
                    strRptName = strReportLoc & "Ship Packing Slip With Qty Push.rpt"

                Else
                    'strRptName = strReportLoc & "Ship Packing Slip No Customer Info Push.rpt"
                    strRptName = strReportLoc & "Ship Packing Slip No Customer Info With Qty Push.rpt"
                    bNoCustInfo = True
                End If

                'dt2 = Me._objSPPLF.GetReportData(dtPallet, bNoCustInfo, strPkslipNum)
                If iCustID = 2427 Then
                    dt2 = Me.GetPackingSlipReportData_Genesis(Format(iPkslip_ID, "000000").ToString)
                    If dt2.Rows.Count > 0 Then
                        iWOID = dt2.Rows(0)("WO_ID")
                        If dt2.Select("WO_ID <> " & iWOID).Length > 0 Then Throw New Exception("Manifest contains mixed order.")
                    End If
                ElseIf iCustID = 2627 Then
                    dt2 = Me.GetPackingSlipReportData(bNoCustInfo, Format(iPkslip_ID, "000000").ToString, iCustID)
                ElseIf iCustID = 2577 Then 'skullcandy retail
                    dt2 = Me.GetPackingSlipReportData(bNoCustInfo, Format(iPkslip_ID, "000000").ToString, iCustID)
                Else
                    dt2 = Me.GetPackingSlipReportData(bNoCustInfo, Format(iPkslip_ID, "000000").ToString)
                End If

                If dt2.Rows.Count > 0 Then
                    objRpt = New ReportDocument()

                    'Print Manifest rpt
                    With objRpt
                        .Load(strRptName)
                        .SetDataSource(dt2)

                        If bNoCustInfo Then
                            .PrintToPrinter(1, True, 0, 0)
                        Else
                            If iCustID = 2219 Then     'GameStop
                                .PrintToPrinter(6, True, 0, 0)
                            ElseIf iCustID = 2485 Then     'Syx
                                .PrintToPrinter(1, True, 0, 0)
                            Else
                                .PrintToPrinter(3, True, 0, 0)
                            End If
                        End If
                    End With

                    'Print Warehouse Label rpt
                    If Data.Buisness.MessLabel.IsAMSShareableInventoryCustomer(iCustID) _
                        OrElse iCustID = PSS.Data.Buisness.SkyTel.Anna_CUSTOMER_ID _
                        OrElse iCustID = PSS.Data.Buisness.SkyTel.Lahey_CUSTOMER_ID _
                        OrElse iCustID = PSS.Data.Buisness.SkyTel.Masco_CUSTOMER_ID _
                        OrElse iCustID = PSS.Data.Buisness.SkyTel.Franciscan_CUSTOMER_ID _
                        OrElse iCustID = PSS.Data.Buisness.SkyTel.Maine_CUSTOMER_ID _
                        OrElse iCustID = PSS.Data.Buisness.SkyTel.SMHC_CUSTOMER_ID Then
                        strRptName2 = strReportLoc & "Messaging Manifest Warehouse Label.rpt"
                        Dim dtTmp As DataTable = Me.GetManifestWarehouseLabelData(dt2)
                        If dtTmp.Rows.Count > 0 Then
                            With objRpt
                                .Load(strRptName2)
                                .SetDataSource(dtTmp)
                                .Refresh()
                                .PrintToPrinter(1, True, 0, 0)
                            End With
                        End If
                    End If
                Else
                    MessageBox.Show("Manifest is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt2)
            End Try
        End Sub

        '******************************************************************
        Public Sub CreateExelReportToPrint(ByVal strData As String, _
                                           Optional ByVal strBorderColEnd As String = "", _
                                           Optional ByVal iPrintOrDisplay As Integer = 1)
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet

            Try

                '**************************************************
                'Instantiate the excel related objects
                objExcel = New Excel.Application()      'Starts the Excel Session
                objBook = objExcel.Workbooks.Add                    'Add a Workbook
                objExcel.Application.Visible = True                 'Make excel invisible to user

                objExcel.Application.DisplayAlerts = False
                objSheet = objBook.Worksheets.Item(1)               'Select a Sheet 1 for this
                objExcel.ActiveSheet.Pagesetup.Orientation = 1      ' 1 = Portrait ; 2 = landscape

                '*****************************************
                'format header
                '*****************************************
                objSheet.Rows("1:1").Select()
                With objExcel.Selection
                    .WrapText = False
                    .font.bold = True
                    .Font.ColorIndex = 5
                End With

                'Set data to text format
                If strBorderColEnd <> "" Then
                    objSheet.Range("A1:" & strBorderColEnd).Select()
                    objExcel.Selection.NumberFormat = "@"
                End If

                'Write data to excel file
                System.Windows.Forms.Clipboard.SetDataObject(strData, False)
                objSheet.Paste()

                '*****************************************
                'Set the borders for the whole report
                '*****************************************
                If strBorderColEnd <> "" Then
                    objSheet.Range("A1:" & strBorderColEnd).Select()
                    objExcel.Selection.NumberFormat = "@"
                    'Set Font
                    With objExcel.Selection
                        .Font.Name = "Microsoft Sans Serif"
                        .Font.Size = 11
                        .HorizontalAlignment = Excel.Constants.xlCenter
                        .VerticalAlignment = Excel.Constants.xlCenter
                    End With

                    objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.XlLineStyle.xlLineStyleNone
                    objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.XlLineStyle.xlLineStyleNone
                    With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
                        .LineStyle = Excel.XlLineStyle.xlContinuous 'xlContinuous
                        .Weight = Excel.XlBorderWeight.xlThin
                        .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                    End With
                    With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
                        .LineStyle = Excel.XlLineStyle.xlContinuous
                        .Weight = Excel.XlBorderWeight.xlThin
                        .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                    End With
                    With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
                        .LineStyle = Excel.XlLineStyle.xlContinuous
                        .Weight = Excel.XlBorderWeight.xlThin
                        .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                    End With
                    With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
                        .LineStyle = Excel.XlLineStyle.xlContinuous
                        .Weight = Excel.XlBorderWeight.xlThin
                        .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                    End With
                    With objExcel.Selection.Borders(Excel.XlBordersIndex.xlInsideVertical)
                        .LineStyle = Excel.XlLineStyle.xlContinuous
                        .Weight = Excel.XlBorderWeight.xlThin
                        .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                    End With
                    With objExcel.Selection.Borders(Excel.XlBordersIndex.xlInsideHorizontal)
                        .LineStyle = Excel.XlLineStyle.xlContinuous
                        .Weight = Excel.XlBorderWeight.xlThin
                        .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                    End With
                End If
                '************************************************
                'set all cell to be auto-fit 
                objSheet.Cells.Select()
                objSheet.Cells.EntireColumn.AutoFit()
                objSheet.Cells.EntireRow.AutoFit()
                ''*************************************************

                '***********************
                'Print Report
                '***********************
                If iPrintOrDisplay = 1 Then
                    objExcel.ActiveWindow.SelectedSheets.PrintOut(Copies:=1, Collate:=True)
                End If

            Catch ex As Exception
                Throw ex
            Finally
                System.Windows.Forms.Application.DoEvents()
                '*************************************
                'Excel clean up
                If iPrintOrDisplay <> 2 Then    'Display Data
                    If Not IsNothing(objSheet) Then
                        NAR(objSheet)
                    End If
                    If Not IsNothing(objBook) Then
                        objBook.Close(False)
                        NAR(objBook)
                    End If
                    If Not IsNothing(objExcel) Then
                        objExcel.Quit()
                        NAR(objExcel)
                    End If
                End If
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Sub

        '*******************************************************************


        '*******************************************************************
        Public Function GetShipmentSummary(ByVal iPackingSlip_ID As Integer, _
                                           ByVal strPkSlipCreationDate As String) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT lpad(tpackingslip.pkslip_id, 6, '000000') as 'Manifest Num', Model_desc as Model, lfrequency.freq_Number as Frequency, count(*) as Quantity " & Environment.NewLine
                strSql &= "FROM tpackingslip " & Environment.NewLine
                strSql &= "INNER JOIN tpallett on tpackingslip.pkslip_ID = tpallett.pkslip_ID " & Environment.NewLine
                strSql &= "INNER JOIN tdevice on tpallett.Pallett_ID = tdevice.Pallett_ID " & Environment.NewLine
                strSql &= "INNER JOIN tmodel on tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN tmessdata on tdevice.Device_ID = tmessdata.device_id " & Environment.NewLine
                strSql &= "INNER JOIN lfrequency on tmessdata.freq_id = lfrequency.freq_id " & Environment.NewLine
                strSql &= "WHERE tpackingslip.Cust_ID = 14 " & Environment.NewLine
                strSql &= "AND tpallett.Pallet_ShipType = 0 " & Environment.NewLine
                strSql &= "AND tpallett.pkslip_ID is not null " & Environment.NewLine
                strSql &= "AND tpallett.Pallett_Name like 'AMREP%' " & Environment.NewLine
                If iPackingSlip_ID > 0 Then
                    strSql &= "AND tpackingslip.pkslip_ID = " & iPackingSlip_ID & Environment.NewLine
                Else
                    strSql &= "AND tpallett.Pallett_Name like 'AMREP" & Format(CDate(strPkSlipCreationDate), "yyyyMMdd") & "N%' " & Environment.NewLine
                End If
                strSql &= "GROUP BY 'Manifest Num', tdevice.Model_ID, tmessdata.freq_id " & Environment.NewLine
                strSql &= "ORDER BY 'Manifest Num', tmodel.Model_Desc, lfrequency.freq_Number;" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************
        Public Function GetCustomerIDByPackingSlipID(ByVal strPkslipID As Integer) As Integer
            Dim strSql As String

            Try
                strSql = "SELECT Cust_ID " & Environment.NewLine
                strSql &= "FROM tpackingslip " & Environment.NewLine
                strSql &= "WHERE tpackingslip.pkslip_ID = " & strPkslipID & Environment.NewLine
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************
        Public Function UpdateShippingCost(ByVal iPkslip_ID As Integer, ByVal iShipCarrier As Integer, ByVal strTrackingNo As String, ByVal decShippingCost As Decimal) As Integer
            Dim strSql As String

            Try
                strSql = "UPDATE tpackingslip " & Environment.NewLine
                strSql &= "SET ShipmentCost = " & decShippingCost & Environment.NewLine
                strSql &= ", pkslip_TrackNo = '" & strTrackingNo & "'" & Environment.NewLine
                strSql &= ", SC_ID = " & iShipCarrier & Environment.NewLine
                strSql &= "WHERE tpackingslip.pkslip_ID = " & iPkslip_ID & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**********************************************************************************************************************************
        Public Function SetPalletReadyToEmail(ByVal iCustID As Integer, ByVal iUserID As Integer, ByVal strFrom As String, ByVal strTo As String, ByVal strCc As String _
                                            , ByVal strSubject As String, ByVal strBody As String, ByVal arrlFileName As ArrayList, ByVal strDir As String _
                                            , ByVal strFileExtensions As String) As Integer

            Const iSeqNoDigitCnt As Integer = 2
            Dim strSql As String = "", strEmailID As String = "", strToday As String
            Dim dt As DataTable
            Dim i As Integer, iSeqNo As Integer, j As Integer, iPalletID As Integer

            Try
                strToday = CDate(Generic.MySQLServerDateTime(i)).ToString("yyyyMMdd")
                strEmailID = strToday & "N"

                strSubject = AddMysqlSpecialChar(strSubject)
                strBody = AddMysqlSpecialChar(strBody)
                strDir = AddMysqlSpecialChar(strDir)

                For i = 0 To arrlFileName.Count - 1
                    strSql = "SELECT Pallett_ID FROM tpallett WHERE Cust_ID = " & iCustID & " AND Pallett_Name = '" & arrlFileName(i) & "'"
                    iPalletID = Me._objDataProc.GetIntValue(strSql)

                    strSql = "SELECT * FROM temailPalletPackingList WHERE Cust_ID = " & iCustID & " AND File_Name = '" & arrlFileName(i) & strFileExtensions & "'"
                    dt = Me._objDataProc.GetDataTable(strSql)

                    'Create Email ID
                    If i = 0 Then
                        iSeqNo = GetEmailPackingListEmailIDSeqNo(strEmailID, iSeqNoDigitCnt)
                        strEmailID = strToday & "N" & iSeqNo.ToString.PadLeft(iSeqNoDigitCnt, "0")
                    End If

                    If dt.Rows.Count = 0 Then
                        strSql = "INSERT INTO temailPalletPackingList (" & Environment.NewLine
                        strSql &= " Cust_ID, File_Name, Pallett_ID, File_Loc, Subject, Body" & Environment.NewLine
                        strSql &= ", EmailList_From, EmailList_To, EmailList_CC, Prod_SendDate, EmailID, Prod_UserID " & Environment.NewLine
                        strSql &= ") VALUES ( " & Environment.NewLine
                        strSql &= iCustID & ", '" & arrlFileName(i) & strFileExtensions & "', " & iPalletID & ", '" & strDir & "', '" & strSubject & "', '" & strBody & "' " & Environment.NewLine
                        strSql &= ", '" & strFrom & "', '" & strTo & "', '" & strCc & "', now(), '" & strEmailID & "', " & iUserID & Environment.NewLine
                        strSql &= " ) "
                    Else
                        strSql = "UPDATE temailPalletPackingList" & Environment.NewLine
                        strSql &= "SET Pallett_ID = " & iPalletID & ", File_Loc = '" & strDir & "', Subject = '" & strSubject & "', Body = '" & strBody & "'" & Environment.NewLine
                        strSql &= ", EmailList_From = '" & strFrom & "', EmailList_To = '" & strTo & "', EmailList_CC = '" & strCc & "'" & Environment.NewLine
                        strSql &= ", EmailID = '" & strEmailID & "'" & Environment.NewLine
                        strSql &= "WHERE EP_ID = " & dt.Rows(0)("EP_ID") & Environment.NewLine
                    End If

                    j += Me._objDataProc.ExecuteNonQuery(strSql)
                Next i

                Return j
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '**********************************************************************************************************************************
        Public Function GetEmailPackingListEmailIDSeqNo(ByVal strEmailIDPrefix As String, ByVal iSeqNoDigitCnt As Integer) As Integer
            Dim strSQL As String
            Dim dt As DataTable
            Dim iNextNo As Integer = 1

            Try
                strSQL = "SELECT max(right(EmailID, " & iSeqNoDigitCnt & " ) ) + 1 as NextSequenceNumber " & Environment.NewLine
                strSQL &= "FROM temailPalletPackingList " & Environment.NewLine
                strSQL &= "WHERE EmailID like '" & strEmailIDPrefix & "%' " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSQL)
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0)("NextSequenceNumber")) Then iNextNo = CInt(dt.Rows(0)("NextSequenceNumber"))
                End If

                Return iNextNo
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '**********************************************************************************************************************************
        Private Function AddMysqlSpecialChar(ByVal strVal As String) As String
            Try
                strVal = strVal.Replace("\", "\\")
                strVal = strVal.Replace("'", "\'")
                Return strVal
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function GetAccount(ByVal device_id As Integer, ByVal iLoc_Id As Integer) As Integer
            Dim dtrow As DataRow
            Dim strSql As String = ""
            Dim orderType As Integer
            Dim dt As DataTable
            Try
                strSql = "SELECT A.Account " & Environment.NewLine
                strSql &= "FROM extendedwarranty A " & Environment.NewLine
                strSql &= "INNER JOIN tdevice B ON A.device_id=B.Device_id" & Environment.NewLine
                strSql &= " where B.device_id = " & device_id & " AND B.Loc_id= " & iLoc_Id & " AND A.Account in ('ATT','Cricket') " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                Return dt.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function
        '**********************************************************************************************************************************
        Public Sub printManifest(ByVal ipkslipId As Integer, ByVal iLocID As Integer, ByVal iPallettType As Integer, ByVal Account As String)
            Dim R1, R2 As DataRow
            Dim dt2 As New DataTable()
            Dim strSql As String = String.Empty
            Dim dt As New DataTable()
            Dim i As Integer
            Dim strreturnToName As String = String.Empty
            Dim strreturnAddress1 As String = String.Empty
            Dim strReturnCity As String = String.Empty
            Dim strPO As String = String.Empty
            If iLocID = PSS.Data.Buisness.WIKO.WIKO.WIKO_AttCricket_LOC_ID _
                                OrElse iLocID = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCricket_LOC_ID _
                                OrElse iLocID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttCricket_LOC_ID Then
                If iPallettType = 1 OrElse Account = PSS.Data.Buisness.WIKO.WIKO.WIKO_Cricket_OEMCustomer_DOA_AccountCode Then
                    strreturnToName = "TINNO USA INC"
                    strreturnAddress1 = "2301 West Plano Parkway, Suite 102"
                    strReturnCity = "Plano, TX 75075"
                    strPO = "N/A"
                Else
                    strreturnToName = "Ingram Micro Mobility Fort Worth"
                    strreturnAddress1 = "14500 FAA Blvd Suite 100"
                    strReturnCity = "Fort Worth, TX 76155"
                End If
            Else
                If iPallettType = 1 OrElse Account = PSS.Data.Buisness.WIKO.WIKO.WIKO_FexEx_PosCode Then
                    strreturnToName = "TINNO USA INC"
                    strreturnAddress1 = "2301 West Plano Parkway, Suite 102"
                    strReturnCity = "Plano, TX 75075"
                    strPO = "N/A"
                Else
                    strreturnToName = "AT&T OEM Warranty / Group O"
                    strreturnAddress1 = "2101 Eagle Parkway"
                    strReturnCity = "Fort Worth, TX 76177"
                End If
            End If
            strSql = "SELECT tdevice.device_id, extendedwarranty.Account, tpallett.Pallett_Name as PalletName, " & Environment.NewLine
            strSql &= " extendedwarranty.Item_SKU as ItemSku,ClaimNo as po,Pallett_Qty as PallettQty,tpallett.pkslip_ID as SlipNumber, " & Environment.NewLine
            strSql &= " PSSI2Cust_TrackNo as TrackingNo,Warranty_Desc as ModelDesc,'" & strreturnToName & "' as returnToName,'" & strreturnAddress1 & "' as returnAddress1,'" & strReturnCity & "'  as ReturnCity,ReturnState, " & Environment.NewLine
            strSql &= " ReturnZip,SC_Desc as Carrier FROM tpallett  " & Environment.NewLine
            strSql &= " INNER JOIN tdevice ON tpallett.Pallett_ID=tdevice.Pallett_ID" & Environment.NewLine
            strSql &= " INNER JOIN extendedwarranty ON extendedwarranty.Device_ID=tdevice.Device_ID" & Environment.NewLine
            strSql &= " INNER JOIN lshipcarrier ON extendedwarranty.PSSI2Cust_carrier=lshipcarrier.SC_ID" & Environment.NewLine
            strSql &= " INNER JOIN tcellopt  ON tcellopt.Device_ID=tdevice.Device_ID" & Environment.NewLine
            strSql &= " inner JOIN tpackingslip ON tpackingslip.pkslip_ID=tpallett.pkslip_ID AND tpackingslip.pkslip_ID=" & ipkslipId & " GROUP BY  Pallett_Name " & Environment.NewLine

            dt = Me._objDataProc.GetDataTable(strSql)
            For Each R1 In dt.Rows
                i = GetAccount(Trim(R1("Device_id")), iLocID)
                dt2 = GetDeviceInfosWiko(Trim(R1("Device_id")), i)
                For Each R2 In dt2.Rows
                    If strPO.Trim.Length > 0 Then
                        R1("PO") = strPO
                    Else
                        R1("PO") = R2("PO")
                    End If

                    R1("ItemSku") = R2("ItemSku")
                    R1("ModelDesc") = R2("ModelDesc")
                Next
            Next

            Dim objRpt As New ReportDocument()
            With objRpt
                If iLocID = PSS.Data.Buisness.WIKO.WIKO.WIKO_AttCricket_LOC_ID _
                    OrElse iLocID = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCricket_LOC_ID _
                    OrElse iLocID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttCricket_LOC_ID Then
                    .Load(PSS.Data.ConfigFile.GetBaseReportPath & "WikoCricketPackingSlip.rpt")
                Else
                    .Load(PSS.Data.ConfigFile.GetBaseReportPath & "WikoATTPackingSlip.rpt")
                End If
                .SetDataSource(dt)
                .Refresh()
                .PrintToPrinter(1, True, 0, 0)
            End With
        End Sub

        Public Sub printManifest_WingTechATT(ByVal ipkslipId As Integer, ByVal iLocID As Integer)
            Dim R1, R2 As DataRow
            Dim dt2 As New DataTable()
            Dim strSql As String = String.Empty
            Dim dt As New DataTable()
            Dim i As Integer
            strSql = "SELECT tdevice.device_id,extendedwarranty.Account,tpallett.Pallett_Name as PalletName,extendedwarranty.Item_SKU as ItemSku,ClaimNo as po,Pallett_Qty as PallettQty,tpallett.pkslip_ID as SlipNumber,PSSI2Cust_TrackNo as TrackingNo,Warranty_Desc as ModelDesc,returnToName,returnAddress1,ReturnCity,ReturnState,ReturnZip,SC_Desc as Carrier FROM tpallett  " & Environment.NewLine
            strSql &= " INNER JOIN tdevice ON tpallett.Pallett_ID=tdevice.Pallett_ID" & Environment.NewLine
            strSql &= " INNER JOIN extendedwarranty ON extendedwarranty.Device_ID=tdevice.Device_ID" & Environment.NewLine
            strSql &= " INNER JOIN lshipcarrier ON extendedwarranty.PSSI2Cust_carrier=lshipcarrier.SC_ID" & Environment.NewLine
            strSql &= " INNER JOIN tcellopt  ON tcellopt.Device_ID=tdevice.Device_ID" & Environment.NewLine
            strSql &= " inner JOIN tpackingslip ON tpackingslip.pkslip_ID=tpallett.pkslip_ID AND tpackingslip.pkslip_ID=" & ipkslipId & " GROUP BY  Pallett_Name " & Environment.NewLine

            dt = Me._objDataProc.GetDataTable(strSql)
            For Each R1 In dt.Rows
                i = GetAccount(Trim(R1("Device_id")), iLocID)
                dt2 = GetDeviceInfosWiko(Trim(R1("Device_id")), i)
                For Each R2 In dt2.Rows
                    R1("PO") = R2("PO")
                    R1("ItemSku") = R2("ItemSku")
                    R1("ModelDesc") = R2("ModelDesc")
                Next
            Next

            Dim objRpt As New ReportDocument()
            With objRpt
                If iLocID = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCricket_LOC_ID Then
                    .Load(PSS.Data.ConfigFile.GetBaseReportPath & "WingTechATTCricketPackingSlip.rpt")
                Else
                    .Load(PSS.Data.ConfigFile.GetBaseReportPath & "WingTechATTPackingSlip.rpt")
                End If
                .SetDataSource(dt)
                .Refresh()
                .PrintToPrinter(1, True, 0, 0)
            End With
        End Sub

        Public Sub CreateATT_ASN(ByVal ipkslipId As Integer, ByVal iLocID As Integer)
            Dim strFile As String
            Dim dtTime As DateTime = Now
            Dim strSerialNo As ArrayList
            Dim strLocation As String
            If iLocID = PSS.Data.Buisness.WIKO.WIKO.WIKO_AttCTDI_LOC_ID _
            OrElse iLocID = PSS.Data.Buisness.WIKO.WIKO.WIKO_AttFedEx_LOC_ID Then
                strLocation = "P:\OUTBOUND\WIKO\ATT\"
            ElseIf iLocID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttCTDI_LOC_ID _
            OrElse iLocID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttFedEx_LOC_ID Then
                strLocation = "P:\OUTBOUND\VINSMART\ATT\"
            ElseIf iLocID = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCTDI_LOC_ID _
            OrElse iLocID = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttFedEx_LOC_ID Then
                strLocation = "P:\OUTBOUND\WINGTECH\ATT\"
            End If
            Dim strDate As String = dtTime.ToString("yyyyMMddhhmmsss")
            Dim i, j As Integer
            Dim R1, R2 As DataRow
            Dim dt As New DataTable()
            Dim dt2 As New DataTable()
            Dim strSql3 As String = ""
            strSql3 &= "SELECT  '' AS invlin, '' AS untqty,if(C.Pallet_ShipType<>1,ClaimNo,'N/A') AS invnum,'' AS vndlod,pallett_Name AS vndsub,device_SN as vnddtl" & Environment.NewLine
            strSql3 &= ",Item_SKU AS vndprt ,'' AS vndtrk,'' AS prt_client_id,IF(C.Pallet_ShipType=0,'Refurb',IF (C.Pallet_ShipType=2,'RUR','')) AS condition, " & Environment.NewLine
            strSql3 &= " E.pkslip_trackNo AS bill_of_lading" & Environment.NewLine
            strSql3 &= "FROM extendedwarranty A" & Environment.NewLine
            strSql3 &= "Inner join production.tpallett  C ON D.Pallett_ID = C.Pallett_ID " & Environment.NewLine
            strSql3 &= "inner join tdevice D ON D.device_id=A.device_id " & Environment.NewLine
            strSql3 &= "inner join tpackingslip E ON E.Pkslip_ID=C.Pkslip_ID " & Environment.NewLine
            strSql3 &= "WHERE pallett_shipdate Is Not NULL and C.Pkslip_ID  =" & ipkslipId & " AND if(C.Pallet_ShipType<>1, A.Account not in ('ATT','CRICKET' ),A.Item_SKU IS NOT NULL)" & Environment.NewLine
            strSql3 &= " UNION SELECT  '' AS invlin, '' AS untqty,if(C.Pallet_ShipType<>1,ClaimNo,'N/A') AS invnum,'' AS vndlod,pallett_Name AS vndsub,device_SN as vnddtl" & Environment.NewLine
            strSql3 &= ",Item_SKU AS vndprt ,'' AS vndtrk,'' AS prt_client_id,IF(C.Pallet_ShipType=0,'Refurb',IF (C.Pallet_ShipType=2,'RUR','')) AS condition, " & Environment.NewLine
            strSql3 &= " E.pkslip_trackNo AS bill_of_lading" & Environment.NewLine
            strSql3 &= "FROM extendedwarranty A" & Environment.NewLine
            strSql3 &= "Inner join production.tpallett  C ON D.Pallett_ID = C.Pallett_ID " & Environment.NewLine
            strSql3 &= "inner join tdevice D ON D.device_id=A.swapped_device_id " & Environment.NewLine
            strSql3 &= "inner join tpackingslip E ON E.Pkslip_ID=C.Pkslip_ID " & Environment.NewLine
            strSql3 &= "WHERE pallett_shipdate Is Not NULL and C.Pkslip_ID  =" & ipkslipId & "" & Environment.NewLine
            dt = Me._objDataProc.GetDataTable(strSql3)
            strFile = "EMBASN" & strDate & dt.Rows(0)("invnum") & ".xlsx"
            Dim strFilename As String = strLocation & strFile
            If dt.Rows.Count > 0 Then
                CreateExcelFile_ATT(dt, strFilename)
            End If
            dt.Clear()

        End Sub

        Private Sub IMEITobeshipped(ByVal strSerialNo As ArrayList, ByVal strFilenametxt As String)
            Dim writer As StreamWriter = New StreamWriter("myfile.txt")
            writer.WriteLine("two 2")
        End Sub

        Public Sub CreateCricket_ASN(ByVal ipkslipId As Integer, ByVal iLocID As Integer)
            Dim strFile As String
            Dim dtTime As DateTime = Now
            Dim _dtShipment As New DataTable()
            Dim strLocation As String
            Dim strPrefix As String
            If iLocID = PSS.Data.Buisness.WIKO.WIKO.WIKO_AttCricket_LOC_ID Then
                strLocation = "P:\OUTBOUND\WIKO\CRICKET\"
                strPrefix = "WiKoOutBoundData"
            ElseIf iLocID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttCricket_LOC_ID Then
                strLocation = "P:\OUTBOUND\VINSMART\CRICKET\"
                strPrefix = "VinsmartOutBoundData"
            ElseIf iLocID = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCricket_LOC_ID Then
                strLocation = "P:\OUTBOUND\WINGTECH\CRICKET\"
                strPrefix = "WingTechOutBoundData"

            End If

            Dim strDate As String = dtTime.ToString("yyyyMMddhhmmsss")
            Dim strReasonForFailure As String
            Dim i As Integer
            Dim strSql As String = ""

            strSql &= " SELECT  IF(DATE IS NULL,'', IF(DATE_FORMAT(DATE,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(DATE,'%m/%d/%Y'))) AS 'IMM RA Create Date',ClaimNo AS 'IMM RA Number',A.Account AS 'IMM-OEM Customer Account Number'" & Environment.NewLine
            strSql &= " ,ShipTo_Name AS 'OEM/Customer Name',IF(Carrier_Dock_Date  IS NULL,'', IF(DATE_FORMAT(Carrier_Dock_Date ,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(Carrier_Dock_Date ,'%m/%d/%Y'))) AS 'Carrier Dock Date'" & Environment.NewLine
            strSql &= " ,IF(IMM_Dock_Date  IS NULL,'', IF(DATE_FORMAT(IMM_Dock_Date,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(IMM_Dock_Date ,'%m/%d/%Y')))  AS 'IMM Dock Date',Customer_Work_Number AS 'IMM Work Ticket Number'" & Environment.NewLine
            strSql &= ",  IF( A.Account  ='569955' ,'Warranty Exchange', IF( A.Account  ='569969' ,'DOA', 'Underfined'  )  ) as 'Service Category - IMM Return Type' " & Environment.NewLine
            strSql &= " ,  IF(C.Pallet_ShipType=0 AND swapped_device_id>0,'Replacement',IF(C.Pallet_ShipType=2,'RUR',if(C.Pallet_ShipType=0,'Refurbished',if(C.Pallet_ShipType=1,'BER','')))) as 'DA Return Reason-EU Failure', SerialNo   AS 'Cricket Claimed IMEI',Item_SKU AS 'Cricket Claimed SKU',Item_Desc as 'Cricket Claimed Handset Description',device_sn AS 'OEM Replacement IMEI',IMM_Shipped_SKU as 'IMM Shipped SKU'" & Environment.NewLine
            strSql &= " ,IF(Original_To_RA_Date  IS NULL,'', IF(DATE_FORMAT(Original_To_RA_Date,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(Original_To_RA_Date ,'%m/%d/%Y'))) AS 'Original Order Date to RA Create Date (EU BRE Web Only)'" & Environment.NewLine
            strSql &= " ,Pass_Cos as 'Handset Pass Cosmetics',Pass_Fun as 'Handset pass functional test',Pass_Flash as 'Handset Pass Flash Successful',Pass_RF as 'Handset pass RF test',IF(Dcode_Sdesc='P','',IF(C.Pallet_ShipType=0 AND swapped_device_id>0 AND Dcode_Sdesc IS NULL,'1000', CONVERT((RIGHT(CONCAT('0000', Dcode_Sdesc), 4)), CHAR) ))   AS 'IMM Failure Code'" & Environment.NewLine
            strSql &= " ,IF(Dcode_Sdesc='P','',IF(C.Pallet_ShipType=0 AND swapped_device_id>0 AND Dcode_Sdesc IS NULL,'Replacement Device',IF( CONVERT((RIGHT(CONCAT('0000', Dcode_Sdesc), 4)), CHAR) ='0039' ,'NTF- No Trouble Found',Dcode_LDesc )))    as 'Failure Reason' ,Kit_Complete as 'Kit Complete'" & Environment.NewLine
            strSql &= " ,IF(POP_Date IS NULL,'', IF(DATE_FORMAT(POP_Date,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(POP_Date,'%m/%d/%Y'))) AS 'DA/COS-POP'" & Environment.NewLine
            strSql &= " ,IF(POR_Date IS NULL,'', IF(DATE_FORMAT(POR_Date,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(POR_Date,'%m/%d/%Y'))) AS 'DA/COS-POR'" & Environment.NewLine
            strSql &= ", IF(Activation_Date IS NULL,'', IF(DATE_FORMAT(Activation_Date,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(Activation_Date,'%m/%d/%Y'))) as 'WEX Activation Date',OEM_RA as 'OEM RA',IMM_Order as 'IMM Order'" & Environment.NewLine
            strSql &= " ,IF(pkslip_CreateDt IS NULL,'', IF(DATE_FORMAT(pkslip_CreateDt,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(pkslip_CreateDt,'%m/%d/%Y'))) AS 'Ship Date',E.pkslip_trackNo as 'Tracking Number',Pallett_name as 'Pallet Id',C.pallett_id as 'Carton Id'" & Environment.NewLine
            strSql &= "   FROM production.extendedwarranty A" & Environment.NewLine
            strSql &= " INNER JOIN production.tdevice B ON A.swapped_device_id= B.device_id " & Environment.NewLine
            strSql &= " INNER JOIN production.tpallett C ON C.pallett_id=B.pallett_id" & Environment.NewLine
            strSql &= " LEFT JOIN production.tPretest_Data F ON A.device_ID=F.device_ID" & Environment.NewLine
            strSql &= " LEFT JOIN production.lcodesdetail G ON F.pttf=G.Dcode_ID" & Environment.NewLine
            strSql &= "INNER join tpackingslip E ON E.Pkslip_ID=C.Pkslip_ID " & Environment.NewLine
            strSql &= " WHERE E.pkslip_id =" & ipkslipId & " AND B.LOC_ID=" & iLocID & "" & Environment.NewLine
            strSql &= " GROUP BY  SerialNo " & Environment.NewLine
            strSql &= " UNION " & Environment.NewLine
            strSql &= " SELECT  IF(DATE IS NULL,'', IF(DATE_FORMAT(DATE,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(DATE,'%m/%d/%Y'))) AS 'IMM RA Create Date',ClaimNo AS 'IMM RA Number',A.Account AS 'IMM-OEM Customer Account Number'" & Environment.NewLine
            strSql &= " ,ShipTo_Name AS 'OEM/Customer Name',IF(Carrier_Dock_Date  IS NULL,'', IF(DATE_FORMAT(Carrier_Dock_Date ,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(Carrier_Dock_Date ,'%m/%d/%Y'))) AS 'Carrier Dock Date'" & Environment.NewLine
            strSql &= " ,IF(IMM_Dock_Date  IS NULL,'', IF(DATE_FORMAT(IMM_Dock_Date,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(IMM_Dock_Date ,'%m/%d/%Y')))  AS 'IMM Dock Date',Customer_Work_Number AS 'IMM Work Ticket Number'" & Environment.NewLine
            strSql &= ",  IF( A.Account  ='569955' ,'Warranty Exchange', IF( A.Account  ='569969' ,'DOA', 'Underfined'  )  ) as 'Service Category - IMM Return Type' " & Environment.NewLine
            strSql &= " ,  IF(C.Pallet_ShipType=0 AND swapped_device_id>0,'Replacement',IF(C.Pallet_ShipType=2,'RUR',if(C.Pallet_ShipType=0,'Refurbished',if(C.Pallet_ShipType=1,'BER','')))) as 'DA Return Reason-EU Failure', SerialNo   AS 'Cricket Claimed IMEI',Item_SKU AS 'Cricket Claimed SKU',Item_Desc as 'Cricket Claimed Handset Description','' AS 'OEM Replacement IMEI',IMM_Shipped_SKU as 'IMM Shipped SKU'" & Environment.NewLine
            strSql &= " ,IF(Original_To_RA_Date  IS NULL,'', IF(DATE_FORMAT(Original_To_RA_Date,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(Original_To_RA_Date ,'%m/%d/%Y'))) AS 'Original Order Date to RA Create Date (EU BRE Web Only)'" & Environment.NewLine
            strSql &= " ,Pass_Cos as 'Handset Pass Cosmetics',Pass_Fun as 'Handset pass functional test',Pass_Flash as 'Handset Pass Flash Successful',Pass_RF as 'Handset pass RF test',IF(Dcode_Sdesc='P','',IF(C.Pallet_ShipType=0 AND swapped_device_id>0 AND Dcode_Sdesc IS NULL,'1000', CONVERT((RIGHT(CONCAT('0000', Dcode_Sdesc), 4)), CHAR) ))   AS 'IMM Failure Code'" & Environment.NewLine
            strSql &= " ,IF(Dcode_Sdesc='P','',IF(C.Pallet_ShipType=0 AND swapped_device_id>0 AND Dcode_Sdesc IS NULL,'Replacement Device',IF( CONVERT((RIGHT(CONCAT('0000', Dcode_Sdesc), 4)), CHAR) ='0039' ,'NTF- No Trouble Found',Dcode_LDesc )))    as 'Failure Reason' ,Kit_Complete as 'Kit Complete'" & Environment.NewLine
            strSql &= " ,IF(POP_Date IS NULL,'', IF(DATE_FORMAT(POP_Date,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(POP_Date,'%m/%d/%Y'))) AS 'DA/COS-POP'" & Environment.NewLine
            strSql &= " ,IF(POR_Date IS NULL,'', IF(DATE_FORMAT(POR_Date,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(POR_Date,'%m/%d/%Y'))) AS 'DA/COS-POR'" & Environment.NewLine
            strSql &= ", IF(Activation_Date IS NULL,'', IF(DATE_FORMAT(Activation_Date,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(Activation_Date,'%m/%d/%Y'))) as 'WEX Activation Date',OEM_RA as 'OEM RA',IMM_Order as 'IMM Order'" & Environment.NewLine
            strSql &= " ,IF(pkslip_CreateDt IS NULL,'', IF(DATE_FORMAT(pkslip_CreateDt,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(pkslip_CreateDt,'%m/%d/%Y'))) AS 'Ship Date',E.pkslip_trackNo as 'Tracking Number',Pallett_name as 'Pallet Id',C.pallett_id as 'Carton Id'" & Environment.NewLine
            strSql &= "   FROM production.extendedwarranty A" & Environment.NewLine
            strSql &= " INNER JOIN production.tdevice B ON A.device_id= B.device_id " & Environment.NewLine
            strSql &= " INNER JOIN production.tpallett C ON C.pallett_id=B.pallett_id" & Environment.NewLine
            strSql &= " LEFT JOIN production.tPretest_Data F ON A.device_ID=F.device_ID" & Environment.NewLine
            strSql &= " LEFT JOIN production.lcodesdetail G ON F.pttf=G.Dcode_ID" & Environment.NewLine
            strSql &= "INNER join tpackingslip E ON E.Pkslip_ID=C.Pkslip_ID " & Environment.NewLine
            strSql &= " WHERE E.pkslip_id =" & ipkslipId & " AND B.LOC_ID=" & iLocID & "  AND if(C.Pallet_ShipType<>1, A.Account not in ('ATT','CRICKET' ),A.Item_SKU IS NOT NULL) " & Environment.NewLine
            strSql &= " GROUP BY  SerialNo " & Environment.NewLine
            _dtShipment = Me._objDataProc.GetDataTable(strSql)
            strFile = strPrefix & Date.Now.Month & "_" & Date.Now.Day & "_" & Date.Now.Year & Date.Now.Hour & Date.Now.Minute & Date.Now.Second & ".xlsx"
            Dim strFilename As String = strLocation & strFile
            If _dtShipment.Rows.Count > 0 Then
                CreateExcelFileCricket(_dtShipment, strFilename)
            End If
            _dtShipment.Clear()
        End Sub

        Private Sub CreateExcelFile_ATT(ByVal dt1 As DataTable, ByVal strRptPath As String)
            Dim i, j As Integer
            Dim xlApp As Excel.Application
            Dim dtcolumn As DataColumn
            Dim xlWorkBook As Excel.Workbook
            Dim xlWorkSheet As Excel.Worksheet
            Dim misValue As Object = System.Reflection.Missing.Value
            xlApp = New Excel.ApplicationClass()
            xlWorkBook = xlApp.Workbooks.Add(misValue)
            xlWorkSheet = xlWorkBook.Sheets("sheet1")

            xlApp.Cells(1, 1).Value = "invlin"
            xlApp.Cells(1, 2).Value = "untqty"
            xlApp.Cells(1, 3).Value = "invnum"
            xlApp.Cells(1, 4).Value = "vndlod"
            xlApp.Cells(1, 5).Value = "vndsub"
            xlApp.Cells(1, 6).Value = "vnddtl"
            xlApp.Cells(1, 7).Value = "vndprt"
            xlApp.Cells(1, 8).Value = "vndtrk"
            xlApp.Cells(1, 9).Value = "prt_client_id"
            xlApp.Cells(1, 10).Value = "condition"
            xlApp.Cells(1, 11).Value = "bill_of_lading"
            'Format cells Data Type
            '*****************************************
            'dt1.Columns.Remove("Device_id")
            xlWorkSheet.Range("A1", "L" & (dt1.Rows.Count + 1)).NumberFormat = "@"
            For i = 0 To dt1.Rows.Count - 1
                For j = 0 To dt1.Columns.Count - 1
                    xlWorkSheet.Cells(i + 2, j + 1) = dt1.Rows(i).Item(j)
                Next
            Next
            xlWorkSheet.Range("A1", "L" & (dt1.Rows.Count + 1)).Value = xlWorkSheet.Range("A1", "L" & (dt1.Rows.Count + 1)).Value
            xlWorkSheet.SaveAs(strRptPath)
            xlWorkBook.Close()
            xlApp.Quit()

            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)
            MsgBox("You can find the file " & strRptPath)
        End Sub

        Private Sub CreateExcelFileCricket(ByVal dt1 As DataTable, ByVal strRptPath As String)
            Dim i, j As Integer
            Dim xlApp As Excel.Application
            Dim dtcolumn As DataColumn
            Dim xlWorkBook As Excel.Workbook
            Dim xlWorkSheet As Excel.Worksheet
            Dim arrData(0, 0) As String
            Dim R1, R2 As DataRow
            Dim misValue As Object = System.Reflection.Missing.Value
            xlApp = New Excel.ApplicationClass()
            xlWorkBook = xlApp.Workbooks.Add(misValue)
            xlWorkSheet = xlWorkBook.Sheets("sheet1")

            xlApp.Cells(1, 1).Value = "IMM RA Create Date"
            xlApp.Cells(1, 2).Value = "IMM RA NUMBER"
            xlApp.Cells(1, 3).Value = "IMM - OEM Customer Account Number"
            xlApp.Cells(1, 4).Value = "OEM/Customer Name"
            xlApp.Cells(1, 5).Value = "Carrier Dock Date"
            xlApp.Cells(1, 6).Value = "IMM DOCK DATE"
            xlApp.Cells(1, 7).Value = "IMM Work Ticket number"
            xlApp.Cells(1, 8).Value = "Service Category - IMM Return Type "
            xlApp.Cells(1, 9).Value = "DA Return Reason - EU Failure"
            xlApp.Cells(1, 10).Value = "Cricket Claimed IMEI"
            xlApp.Cells(1, 11).Value = "Cricket Claim SKU "
            xlApp.Cells(1, 12).Value = "Cricket Claimed Handset Description"
            xlApp.Cells(1, 13).Value = "OEM Replacement IMEI"
            xlApp.Cells(1, 14).Value = "IMM Shipped SKU"
            xlApp.Cells(1, 15).Value = "Original Order Date to RA Create Date (EU BRE Web Only)"
            xlApp.Cells(1, 16).Value = "Handset Pass Cosmetic"
            xlApp.Cells(1, 17).Value = "Handset pass functional test"
            xlApp.Cells(1, 18).Value = "Handset Pass Flash Successful"
            xlApp.Cells(1, 19).Value = "Handset pass RF test"
            xlApp.Cells(1, 20).Value = "IMM Failure Code"
            xlApp.Cells(1, 21).Value = "Failure Reason"
            xlApp.Cells(1, 22).Value = "Kit Complete"
            xlApp.Cells(1, 23).Value = "DA/COS - POP"
            xlApp.Cells(1, 24).Value = "DA/COS - POR"
            xlApp.Cells(1, 25).Value = "WEX Activation Date"
            xlApp.Cells(1, 26).Value = "OEM RMA"
            xlApp.Cells(1, 27).Value = "IMM Order"
            xlApp.Cells(1, 28).Value = "Ship Date"
            xlApp.Cells(1, 29).Value = "Tracking Number"

            xlApp.Cells(1, 30).Value = "Pallet ID"
            xlApp.Cells(1, 31).Value = "Carton ID"

            'Format cells Data Type
            '*****************************************
            xlWorkSheet.Range("A1", "AE" & (dt1.Rows.Count + 1)).NumberFormat = "@"
            For i = 0 To dt1.Rows.Count - 1
                For j = 0 To dt1.Columns.Count - 1
                    xlWorkSheet.Cells(i + 2, j + 1) = dt1.Rows(i).Item(j)
                Next
            Next
            xlWorkSheet.Range("B1", "C" & (dt1.Rows.Count + 3)).NumberFormat = 0
            xlWorkSheet.Range("G1", "G" & (dt1.Rows.Count + 3)).NumberFormat = 0
            xlWorkSheet.Range("Z1", "Z" & (dt1.Rows.Count + 3)).NumberFormat = 0
            xlWorkSheet.Range("A1", "AE" & (dt1.Rows.Count + 1)).Value = xlWorkSheet.Range("A1", "AE" & (dt1.Rows.Count + 1)).Value
            xlWorkSheet.Range("B1", "C" & (dt1.Rows.Count + 3)).NumberFormat = 0
            xlWorkSheet.Range("G1", "G" & (dt1.Rows.Count + 3)).NumberFormat = 0
            xlWorkSheet.Range("Z1", "Z" & (dt1.Rows.Count + 3)).NumberFormat = 0
            Dim worksheets As Excel.Sheets = xlWorkBook.Worksheets
            worksheets(1).Delete()
            worksheets(2).Delete()
            xlWorkSheet.SaveAs(strRptPath)
            xlWorkBook.Close()
            xlApp.Quit()
            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)
            MsgBox("You can find the file " & strRptPath)
        End Sub

        Private Sub releaseObject(ByVal obj As Object)
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
                obj = Nothing
            Catch ex As Exception
                obj = Nothing
            Finally
                GC.Collect()
            End Try
        End Sub
        Private Sub NAR(ByVal o As Object)
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
            Catch
            Finally
                o = Nothing
            End Try

        End Sub

        Public Sub PrintManifestCoolpad(ByVal pltId As String, ByVal iCustID As Integer)
            Dim strSql As String = String.Empty
            Dim dt As New DataTable()
            Dim dt2 As New DataTable()
            Dim i As Integer
            Dim R1, R2 As DataRow

            strSql = "(SELECT tdevice.device_id,tpallett.Pallett_Name as PalletName,'' as ItemSku,''  as PO,Pallett_Qty as PallettQty,tpallett.pkslip_ID as SlipNumber,pkslip_createDt as Packingdate,PSSI2Cust_TrackNo as TrackingNo,'' as ModelDesc,'' AS returnToName,'' AS returnAddress1,'' AS ReturnCity, '' AS ReturnState,'' AS ReturnZip,SC_Desc as Carrier FROM tpallett  " & Environment.NewLine
            strSql &= " INNER JOIN tdevice ON tpallett.Pallett_ID=tdevice.Pallett_ID" & Environment.NewLine
            strSql &= " INNER JOIN extendedwarranty ON extendedwarranty.Device_ID=tdevice.Device_ID" & Environment.NewLine
            strSql &= " INNER JOIN lshipcarrier ON extendedwarranty.PSSI2Cust_carrier=lshipcarrier.SC_ID" & Environment.NewLine
            strSql &= " INNER JOIN tcellopt  ON tcellopt.Device_ID=tdevice.Device_ID" & Environment.NewLine
            strSql &= " inner JOIN tpackingslip ON tpackingslip.pkslip_ID=tpallett.pkslip_ID AND tpackingslip.pkslip_ID='" & pltId & "' GROUP BY  Pallett_Name )" & Environment.NewLine
            dt = Me._objDataProc.GetDataTable(strSql)
            For Each R1 In dt.Rows
                dt2 = GetDeviceInfos(Trim(R1("Device_id")))
                For Each R2 In dt2.Rows
                    If (Trim(R2("PO").ToString)).Length <> 0 Then
                        R1("PO") = R2("PO")
                        R1("ItemSku") = R2("ItemSku")
                        R1("ModelDesc") = R2("ModelDesc")
                        R1("returnToName") = R2("returnToName")
                        R1("returnAddress1") = R2("returnAddress1")
                        R1("ReturnCity") = R2("ReturnCity")
                        R1("ReturnState") = R2("ReturnState")
                        R1("ReturnZip") = R2("ReturnZip")
                    End If
                Next
            Next
            Dim objRpt As New ReportDocument()
            With objRpt
                .Load(PSS.Data.ConfigFile.GetBaseReportPath & "CoolpadPackingSlip.rpt")
                .SetDataSource(dt)
                .Refresh()
                .PrintToPrinter(1, True, 0, 0)
            End With
        End Sub

        Public Sub PrintManifestWingTech(ByVal pltId As String, ByVal iCustID As Integer)
            Dim strSql As String = String.Empty
            Dim dt As New DataTable()
            Dim dt2 As New DataTable()
            Dim i As Integer
            Dim R1, R2 As DataRow

            strSql = "(SELECT tdevice.device_id,tpallett.Pallett_Name as PalletName,'' as ItemSku,''  as PO,Pallett_Qty as PallettQty,tpallett.pkslip_ID as SlipNumber,pkslip_createDt as Packingdate,PSSI2Cust_TrackNo as TrackingNo,'' as ModelDesc,'' AS returnToName,'' AS returnAddress1,'' AS ReturnCity, '' AS ReturnState,'' AS ReturnZip,SC_Desc as Carrier FROM tpallett  " & Environment.NewLine
            strSql &= " INNER JOIN tdevice ON tpallett.Pallett_ID=tdevice.Pallett_ID" & Environment.NewLine
            strSql &= " INNER JOIN extendedwarranty ON extendedwarranty.Device_ID=tdevice.Device_ID" & Environment.NewLine
            strSql &= " INNER JOIN lshipcarrier ON extendedwarranty.PSSI2Cust_carrier=lshipcarrier.SC_ID" & Environment.NewLine
            strSql &= " INNER JOIN tcellopt  ON tcellopt.Device_ID=tdevice.Device_ID" & Environment.NewLine
            strSql &= " inner JOIN tpackingslip ON tpackingslip.pkslip_ID=tpallett.pkslip_ID AND tpackingslip.pkslip_ID='" & pltId & "' GROUP BY  Pallett_Name )" & Environment.NewLine
            dt = Me._objDataProc.GetDataTable(strSql)
            For Each R1 In dt.Rows
                dt2 = GetDeviceInfos(Trim(R1("Device_id")))
                For Each R2 In dt2.Rows
                    If (Trim(R2("PO").ToString)).Length <> 0 Then
                        R1("PO") = R2("PO")
                        R1("ItemSku") = R2("ItemSku")
                        R1("ModelDesc") = R2("ModelDesc")
                        R1("returnToName") = R2("returnToName")
                        R1("returnAddress1") = R2("returnAddress1")
                        R1("ReturnCity") = R2("ReturnCity")
                        R1("ReturnState") = R2("ReturnState")
                        R1("ReturnZip") = R2("ReturnZip")
                    End If
                Next
            Next
            Dim objRpt As New ReportDocument()
            With objRpt
                .Load(PSS.Data.ConfigFile.GetBaseReportPath & "WingTechPackingSlip.rpt")
                .SetDataSource(dt)
                .Refresh()
                .PrintToPrinter(1, True, 0, 0)
            End With
        End Sub

        Public Function GetDeviceInfos(ByVal iDeviceId As Integer) As DataTable
            Dim strSql As String = String.Empty
            Dim dt As New DataTable()
            strSql = "SELECT extendedwarranty.Item_SKU  as ItemSku, ClaimNo  as PO,Warranty_Desc as ModelDesc,returnToName,returnAddress1,ReturnCity,ReturnState, ReturnZip FROM extendedwarranty  " & Environment.NewLine
            strSql &= "where device_id = " & iDeviceId & "  or swapped_device_id= " & iDeviceId & " " & Environment.NewLine
            dt = Me._objDataProc.GetDataTable(strSql)
            Return dt
        End Function


        Public Function GetDeviceInfosWiko(ByVal iDeviceId As Integer, ByVal ibulkorder_id As Integer) As DataTable
            Dim strSql As String = String.Empty
            Dim dt As New DataTable()
            strSql = "SELECT extendedwarranty.Item_SKU  as ItemSku, ClaimNo  as PO,Warranty_Desc as ModelDesc FROM extendedwarranty  " & Environment.NewLine
            If ibulkorder_id = 1 Then
                strSql &= "where swapped_device_id = " & iDeviceId & " " & Environment.NewLine
            Else
                strSql &= "where  device_id= " & iDeviceId & " " & Environment.NewLine
            End If

            dt = Me._objDataProc.GetDataTable(strSql)
            Return dt
        End Function

        Public Sub PrintManifestModelFreqLabel(ByVal iPkslipID As Integer, ByVal iCopies As Integer)
            Dim strSQL As String
            Dim dt As DataTable
            Dim row As DataRow
            Dim iTotal As Integer = 0, iPkslipQty As Integer = 0

            Try
                'Get qty in all pallets in this manifest Packing slip
                strSQL = "select SUM(Pallett_QTY) as Pallett_QTY from tPallett where Pkslip_ID =" & iPkslipID & ";"
                dt = Me._objDataProc.GetDataTable(strSQL)
                iPkslipQty = Convert.ToInt32(dt.Rows(0)("Pallett_QTY"))

                'Get devices, freq, models in pallet
                'strSQL = " SELECT B.Pallett_ID as PalletID, B.Pallett_ID as PalleID2,B.PAllett_Name as PalletName" & Environment.NewLine
                'strSQL = " SELECT " & iPkslipID & " as PalletID, B.Pallett_ID as PalleID2,B.PAllett_Name as PalletName" & Environment.NewLine
                strSQL = " SELECT " & iPkslipID & " as PalletID, 0 as PalleID2,'' as PalletName" & Environment.NewLine
                strSQL &= " ,if(Max(B.Pallett_ShipDate) is null,Date_Format(Now(),'%Y-%m-%d'),Date_Format(Max(B.Pallett_ShipDate),'%Y-%m-%d')) as PalletDate" & Environment.NewLine
                strSQL &= " ,E.Cust_Name1 as Customer,F.Model_Desc as Model, D.freq_Number as Freq,Count(*) as Qty,Count(*) as Qty1" & Environment.NewLine
                strSQL &= " FROM tdevice A" & Environment.NewLine
                strSQL &= " INNER JOIN tPallett B ON A.Pallett_ID=B.Pallett_ID" & Environment.NewLine
                strSQL &= " INNER JOIN tmessdata C on A.Device_ID = C.Device_ID" & Environment.NewLine
                strSQL &= " INNER JOIN lfrequency D ON C.freq_id = D.freq_id" & Environment.NewLine
                strSQL &= " INNER JOIN tCustomer E ON B.Cust_ID=E.Cust_ID" & Environment.NewLine
                strSQL &= " INNER JOIN tModel F ON A.Model_ID=F.Model_ID" & Environment.NewLine
                strSQL &= " WHERE B.Pkslip_ID =" & iPkslipID & Environment.NewLine
                strSQL &= " GROUP BY E.Cust_Name1,F.Model_Desc,D.freq_Number;"
                'strSQL &= " GROUP BY B.Pallett_ID,B.PAllett_Name,E.Cust_Name1,F.Model_Desc,D.freq_Number;" & Environment.NewLine
                dt = _objDataProc.GetDataTable(strSQL)

                If dt.Rows.Count > 0 Then
                    iTotal = dt.Compute("sum(Qty)", "") 'total count
                    If dt.Rows.Count > 1 Then 'add toltal row
                        row = dt.NewRow : row("Qty") = iTotal : row("Qty1") = iTotal
                        row("Customer") = "Total" : dt.Rows.Add(row) : dt.AcceptChanges()
                    End If

                    If iPkslipQty = iTotal Then 'check if same
                        Dim objRpt As ReportDocument
                        objRpt = New ReportDocument()
                        With objRpt
                            .Load(PSS.Data.ConfigFile.GetBaseReportPath & "Messaging Manifest ModelFreq Label.rpt")
                            .SetDataSource(dt)
                            .Refresh()
                            .PrintToPrinter(iCopies, True, 0, 0)
                        End With
                    Else
                        Throw New Exception("Qty in pallet is not equal to Qty of devices count!")
                    End If
                Else
                    Throw New Exception("No data to print!")
                End If

            Catch ex As Exception
                Throw New Exception("Buisness.SendPalletPackingListFiles.PrintManifestModelFreqLabel(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub
        Public Function PrintManifest_Vivint(ByVal iPkslip_ID As Integer) As Integer

            Dim strReportName As String = "vivintLabel_Manifest.rpt"
            Dim strSql As String
            Dim dt As DataTable
            Dim dtLabel As New DataTable()
            Dim i As Integer = 0, j As Integer = 0, k As Integer = 10
            Dim rowNew As DataRow
            Dim strS As String = ""
            Dim strCol As String = "", strCol_Code As String = ""
            Dim iVal As Integer = 0
            Dim FontEncoder As New IDAutomation.NetAssembly.FontEncoder()
            Try
                ' pallett_Name as pallettname , pallett_Name as pallettnamecode ,
                strSql = "SELECT ShippedModel as itemsku,Count(Device_id) as qty,(Count(Device_id)) AS qtycode ,LPAD(pkslip_id,9,'0')AS pkslip_id,LPAD(pkslip_id,9,'0') as  pkslip_idcode " & Environment.NewLine
                strSql &= " FROM tpallett A" & Environment.NewLine
                strSql &= " INNER JOIN tdevice C ON A.pallett_id=C.pallett_id" & Environment.NewLine
                strSql &= " INNER JOIN tmodel B ON B.Model_ID=A.Model_ID" & Environment.NewLine
                strSql &= " WHERE A.pkslip_ID =" & iPkslip_ID & " group by pkslip_id  " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                dtLabel.Columns.Add("itemsku", GetType(String))
                dtLabel.Columns.Add("qty", GetType(String))
                dtLabel.Columns.Add("qtycode", GetType(String))
                dtLabel.Columns.Add("pkslip_id", GetType(String))
                dtLabel.Columns.Add("pkslip_idcode", GetType(String))
                For i = 0 To dt.Rows.Count - 1
                    rowNew = dtLabel.NewRow()

                    strS = dt.Rows(i).Item("qtyCode")
                    If strS.Trim.Length > 0 Then strS = ReplaceChar(FontEncoder.Code128a(strS.Trim))
                    rowNew("qtyCode") = strS
                    strS = dt.Rows(i).Item("pkslip_idcode")
                    If strS.Trim.Length > 0 Then strS = ReplaceChar(FontEncoder.Code128a(strS.Trim))
                    rowNew("pkslip_idcode") = strS
                    rowNew("qty") = ReplaceChar(dt.Rows(i).Item("qty"))
                    rowNew("itemsku") = ReplaceChar(dt.Rows(i).Item("itemsku"))
                    rowNew("pkslip_id") = ReplaceChar(dt.Rows(i).Item("pkslip_id"))
                    dtLabel.Rows.Add(rowNew)
                    dtLabel.AcceptChanges()
                    If dt.Rows.Count > 0 Then
                        PSS.Data.Buisness.TracFone.clsMisc.PrintCrystalReportLabel(dtLabel, strReportName, 1)
                        If i = dt.Rows.Count - 1 Then
                            Return dt.Rows.Count
                        End If

                    Else
                        Return dt.Rows.Count
                    End If
                    dtLabel.Clear()
                Next
                'Print


            Catch ex As Exception
                Throw ex
            End Try


        End Function

        Public Function PrintManifest_Visnamrt(ByVal iPkslip_ID As Integer) As Integer

            Dim strReportName As String = "vivintLabel_Manifest.rpt"
            Dim strSql As String
            Dim dt As DataTable
            Dim dtLabel As New DataTable()
            Dim i As Integer = 0, j As Integer = 0, k As Integer = 10
            Dim rowNew As DataRow
            Dim strS As String = ""
            Dim strCol As String = "", strCol_Code As String = ""
            Dim iVal As Integer = 0
            Dim FontEncoder As New IDAutomation.NetAssembly.FontEncoder()
            Try
                ' pallett_Name as pallettname , pallett_Name as pallettnamecode ,
                strSql = "SELECT ShippedModel as itemsku,Count(Device_id) as qty,(Count(Device_id)) AS qtycode ,LPAD(pkslip_id,9,'0')AS pkslip_id,LPAD(pkslip_id,9,'0') as  pkslip_idcode " & Environment.NewLine
                strSql &= " FROM tpallett A" & Environment.NewLine
                strSql &= " INNER JOIN tdevice C ON A.pallett_id=C.pallett_id" & Environment.NewLine
                strSql &= " INNER JOIN tmodel B ON B.Model_ID=A.Model_ID" & Environment.NewLine
                strSql &= " WHERE A.pkslip_ID =" & iPkslip_ID & " group by pkslip_id  " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                dtLabel.Columns.Add("itemsku", GetType(String))
                dtLabel.Columns.Add("qty", GetType(String))
                dtLabel.Columns.Add("qtycode", GetType(String))
                dtLabel.Columns.Add("pkslip_id", GetType(String))
                dtLabel.Columns.Add("pkslip_idcode", GetType(String))
                For i = 0 To dt.Rows.Count - 1
                    rowNew = dtLabel.NewRow()

                    strS = dt.Rows(i).Item("qtyCode")
                    If strS.Trim.Length > 0 Then strS = ReplaceChar(FontEncoder.Code128a(strS.Trim))
                    rowNew("qtyCode") = strS
                    strS = dt.Rows(i).Item("pkslip_idcode")
                    If strS.Trim.Length > 0 Then strS = ReplaceChar(FontEncoder.Code128a(strS.Trim))
                    rowNew("pkslip_idcode") = strS
                    rowNew("qty") = ReplaceChar(dt.Rows(i).Item("qty"))
                    rowNew("itemsku") = ReplaceChar(dt.Rows(i).Item("itemsku"))
                    rowNew("pkslip_id") = ReplaceChar(dt.Rows(i).Item("pkslip_id"))
                    dtLabel.Rows.Add(rowNew)
                    dtLabel.AcceptChanges()
                    If dt.Rows.Count > 0 Then
                        PSS.Data.Buisness.TracFone.clsMisc.PrintCrystalReportLabel(dtLabel, strReportName, 1)
                        If i = dt.Rows.Count - 1 Then
                            Return dt.Rows.Count
                        End If

                    Else
                        Return dt.Rows.Count
                    End If
                    dtLabel.Clear()
                Next
                'Print


            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function ReplaceChar(ByVal strS As String) As String
            Try
                strS.Trim()
                strS.Replace("'", "''").Replace("\", "\\")

                Return strS
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '**********************************************************************************************************************************




    End Class
    Public Class xmlwrite

    End Class
End Namespace


