Imports CrystalDecisions.CrystalReports.Engine

Namespace Buisness
    Public Class ShipPalletReport
        ' Created by Yuri Sprague 19-Sep-2007
        Private _iCustID As Integer
        Private _iPalletID As Integer
        Private _iNumCopies As Integer
        Private _objDataProc As DBQuery.DataProc

        Public Sub New(ByVal iCustID As Integer, ByVal iPalletID As Integer, Optional ByVal iNumCopies As Integer = 1)
            Me._iCustID = iCustID
            Me._iPalletID = iPalletID
            Me._iNumCopies = Math.Max(1, iNumCopies)

            Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
        End Sub

        Public Sub GetCrystalReportOutput()
            Dim objRpt As ReportDocument
            Dim strSQL, strSN As String
            Dim strLot As String = ""
            Dim dt As DataTable
            Dim objBusinessMisc As Misc
            Dim strReportName As String
            'Dim objGSOpt As New PSS.Data.Buisness.GameStopOpt()
            Dim iDeviceCnt As Integer = 0

            Try
                strReportName = "Ship Pallet Label ATCLE Push.rpt"

                'If Me._iCustID = 2219 Then
                '    strReportName = "Ship Pallet Label GameStop Push.rpt"

                '    strSQL = "SELECT Device_SN " & Environment.NewLine
                '    strSQL &= "FROM tdevice " & Environment.NewLine
                '    strSQL &= "WHERE pallett_id = " & Me._iPalletID.ToString

                '    strSN = Me._objDataProc.GetSingletonString(strSQL)

                '    'Get lot number
                '    If strSN.Length > 0 Then
                '        objBusinessMisc = New Misc()

                '        'strLot = GetDevLotNo(strSN)
                '        strLot = objGSOpt.GameStopDeviceLotNum(strSN)
                '    End If
                'Else
                '    strReportName = "Ship Pallet Label ATCLE Push.rpt"
                'End If

                'Get device count first.
                strSQL = "SELECT COUNT(A.Device_ID) " & Environment.NewLine
                strSQL &= "FROM tdevice A " & Environment.NewLine
                strSQL &= "INNER JOIN tdailyproduction B ON B.Device_ID = A.Device_ID AND B.Pallett_ID = A.Pallett_ID " & Environment.NewLine
                strSQL &= "INNER JOIN tpallett C ON C.Pallett_ID = A.Pallett_ID " & Environment.NewLine
                strSQL &= "WHERE C.Pallett_ID = " & Me._iPalletID.ToString & " " & Environment.NewLine
                strSQL &= "GROUP BY C.Pallett_ID"

                iDeviceCnt = Me._objDataProc.GetIntValue(strSQL)

                strSQL = "SELECT " & iDeviceCnt.ToString & " AS DeviceCount, C.Pallett_Name AS PalletName, " & Environment.NewLine
                strSQL &= "(CASE WHEN C.Cust_ID IN ( 2019, 2254 ) THEN " & Environment.NewLine
                strSQL &= "   (CASE WHEN C.Pallet_ShipType = 0 THEN 'PASS' WHEN C.Pallet_ShipType IN (1, 9) THEN 'FAIL' ELSE '' END) " & Environment.NewLine
                strSQL &= "WHEN C.Cust_ID = 2219 THEN " & Environment.NewLine
                strSQL &= "   (CASE WHEN C.Pallet_ShipType = 0 THEN 'REFURBISHED' WHEN C.Pallet_ShipType = 1 THEN 'RUR' WHEN C.Pallet_ShipType = 8 THEN 'SCRAP' ELSE '' END) " & Environment.NewLine
                strSQL &= "WHEN C.Cust_ID IN ( 2113, 2245 ) THEN " & Environment.NewLine
                strSQL &= "   (CASE WHEN C.Pallet_ShipType = 0 THEN 'REFURBISHED' WHEN C.Pallet_ShipType IN (1, 9) THEN 'BER' ELSE '' END) " & Environment.NewLine
                strSQL &= "WHEN ( C.Cust_ID = 2249 OR E.Prod_ID = 7 ) THEN " & Environment.NewLine
                strSQL &= "   (CASE WHEN C.Pallet_ShipType = 0 THEN 'REFURBISHED' WHEN C.Pallet_ShipType IN (1, 9) THEN 'RUR' ELSE '' END) " & Environment.NewLine
                strSQL &= "ELSE '' " & Environment.NewLine
                strSQL &= "END) AS Result, " & Environment.NewLine
                strSQL &= "(CASE WHEN C.Cust_ID = 2019 THEN " & Environment.NewLine
                strSQL &= "   (CASE WHEN C.Pallet_ShipType = 0 THEN CONCAT(C.Pallet_SkuLen, ' Label') WHEN C.Pallet_ShipType = 1 THEN 'RUR' WHEN C.Pallet_ShipType = 9 THEN 'RTM' ELSE '' END) " & Environment.NewLine
                strSQL &= "ELSE E.Model_Desc " & Environment.NewLine
                strSQL &= "END) AS ShipType, " & Environment.NewLine
                strSQL &= "(CASE WHEN C.Pallet_ShipType = 0 THEN 'M' ELSE '' END) AS Var, " & Environment.NewLine
                strSQL &= "(CASE WHEN C.Cust_ID = 2219 THEN 'Approval:' ELSE 'Lead:' END) AS AppLead " & Environment.NewLine
                strSQL &= "FROM tdevice A " & Environment.NewLine
                strSQL &= "INNER JOIN tdailyproduction B ON B.Device_ID = A.Device_ID AND B.Pallett_ID = A.Pallett_ID " & Environment.NewLine
                strSQL &= "INNER JOIN tpallett C ON C.Pallett_ID = A.Pallett_ID " & Environment.NewLine
                strSQL &= "INNER JOIN tdailyproduction D ON D.Pallett_ID = C.Pallett_ID " & Environment.NewLine
                strSQL &= "INNER JOIN tmodel E ON A.Model_ID = E.Model_ID " & Environment.NewLine
                strSQL &= "WHERE C.Pallett_ID = " & Me._iPalletID.ToString & " " & Environment.NewLine
                strSQL &= "GROUP BY C.Pallett_ID"

                dt = Me._objDataProc.GetDataTable(strSQL)

                If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                    objRpt = New ReportDocument()

                    With objRpt
                        .Load(ConfigFile.GetBaseReportPath & strReportName)
                        .SetDataSource(dt)
                        .PrintToPrinter(Me._iNumCopies, True, 0, 0)
                    End With
                End If
            Catch ex As Exception
                Throw ex
            Finally
                ' objGSOpt = Nothing
            End Try
        End Sub

        '**********************************************************************
        'Get Lot number of SN; add by Lan 11/14/2006; only use for GS customer
        'Copied here and modified by Yuri Sprague 19-Sep-2007
        '**********************************************************************
        Private Function GetDevLotNo(ByVal strSN As String) As String
            Dim strSQL As String
            Dim dr1, dr2 As DataRow
            Dim strLot As String = ""

            Try
                'Step1: Get Received pallet
                strSQL = "SELECT tdevice.device_sn, tworkorder.WO_RecPalletName, cust_id " & Environment.NewLine
                strSQL &= "FROM tdevice " & Environment.NewLine
                strSQL &= "INNER JOIN tworkorder ON tdevice.wo_id = tworkorder.wo_id " & Environment.NewLine
                strSQL &= "INNER JOIN tlocation ON tdevice.loc_id = tlocation.loc_id" & Environment.NewLine
                strSQL &= "WHERE device_sn = '" & Trim(strSN) & "' " & Environment.NewLine
                strSQL &= "AND (device_dateship is null or device_dateship = '0000:00:00 00:00' OR device_dateship = '')"

                dr1 = Me._objDataProc.GetDataRow(strSQL)

                If Not IsNothing(dr1) Then
                    'Step2: Get device lot number
                    strSQL = "SELECT twarehousepallet.WHP_Lot, twarehousepallet.Model_ID " & Environment.NewLine
                    strSQL &= "FROM twarehousereceive " & Environment.NewLine
                    strSQL &= "INNER JOIN twarehousepallet ON twarehousereceive.WHPallet_ID = twarehousepallet.WHPallet_ID " & Environment.NewLine
                    strSQL &= "WHERE twarehousereceive.WHR_Dev_SN ='" & Trim(strSN) & "' " & Environment.NewLine
                    strSQL &= "AND twarehousepallet.WHPallet_Number = '" & dr1("WO_RecPalletName") & "' " & Environment.NewLine
                    strSQL &= "AND Cust_ID = " & dr1("cust_id")

                    dr2 = Me._objDataProc.GetDataRow(strSQL)

                    If Not IsNothing(dr2) Then
                        If Not IsDBNull(dr2("WHP_Lot")) Then
                            strLot = UCase(Trim(dr2("WHP_Lot")))
                        End If
                    Else
                        Throw New Exception("Device's SN does not exist in twarehousereceive or device was not received to the line.")
                    End If
                Else
                    Throw New Exception("Device's SN does not exist in tdevice or device already been ship.")
                End If

                Return strLot
            Catch ex As Exception
                Throw ex
            Finally
                dr1 = Nothing
                dr2 = Nothing
            End Try
        End Function
    End Class
End Namespace
