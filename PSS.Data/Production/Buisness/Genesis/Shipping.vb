Option Explicit On 

Namespace Buisness.Genesis
    Public Class Shipping
        Private _objDataProc As DBQuery.DataProc

#Region "Constructor/Destructor"

        '*******************************************************************************************************
        Public Sub New()
            Try
                Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*******************************************************************************************************
        Protected Overrides Sub Finalize()
            Me._objDataProc = Nothing
            MyBase.Finalize()
        End Sub

        '*******************************************************************************************************
#End Region

        '*******************************************************************************************************
        Public Function GetOpenToShipSO(ByVal iLocID As Integer, ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT Distinct tworkorder.WO_ID, WO_CustWO FROM tworkorder  " & Environment.NewLine
                strSql &= "INNER JOIN tworkorderline ON tworkorder.WO_ID = tworkorderline.WO_ID " & Environment.NewLine
                strSql &= "WHERE Loc_ID = " & iLocID & " AND WO_Closed = 0 AND InvalidOrder = 0 " & Environment.NewLine
                strSql &= "AND ShippingClosed = 0" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--Select--"}, False)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '*******************************************************************************************************
        Public Function GetOpenToShipSOLines(ByVal iWOID As Integer, ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT WOL_ID, LineNo, ItemNo, ItemDesc, Quantity, PlannedShipmentDate, Model_ID, Tray_ID, WO_ID " & Environment.NewLine
                strSql &= "FROM tworkorderline WHERE WO_ID = " & iWOID & " AND ShippingClosed = 0"
                dt = Me._objDataProc.GetDataTable(strSql)

                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--Select--"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '*******************************************************************************************************
        Public Function GetOpenPalletPerSOLines(ByVal iCustID As Integer, ByVal iLocID As Integer, ByVal iWOID As Integer, ByVal iWOLineID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT Pallett_Name as 'Lot Name', LineNo as 'Line #', tpallett.* " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "INNER JOIN tworkorderline ON tpallett.WO_ID = tworkorderline.WO_ID AND tpallett.Pallet_SkuLen = tworkorderline.WOL_ID " & Environment.NewLine
                strSql &= "WHERE Loc_ID = " & iLocID & " And Cust_ID = " & iCustID & Environment.NewLine
                strSql &= "AND tpallett.WO_ID = " & iWOID & " AND Pallet_SkuLen = '" & iWOLineID & "'" & Environment.NewLine
                strSql &= "AND Pallett_ShipDate is null AND Pallett_ReadyToShipFlg = 0 AND Pallet_Invalid = 0 " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************
        Public Function GetWOLinePackingCount(ByVal iCustID As Integer, ByVal iLocID As Integer, ByVal iWOID As Integer, ByVal iWOLineID As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "SELECT count(*) as cnt " & Environment.NewLine
                strSql &= "FROM tpallett INNER JOIN tdevice ON tpallett.Pallett_ID = tdevice.Pallett_ID" & Environment.NewLine
                strSql &= "WHERE tpallett.Loc_ID = " & iLocID & " AND Cust_ID = " & iCustID & Environment.NewLine
                strSql &= "AND tpallett.WO_ID = " & iWOID & " AND Pallet_SkuLen = '" & iWOLineID & "'" & Environment.NewLine
                strSql &= "AND Pallet_Invalid = 0 " & Environment.NewLine
                Return Me._objDataProc.GetIntValue(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************
        Public Function CreatePallet(ByVal iCustID As Integer, ByVal iLocID As Integer, ByVal iWOID As Integer _
                                   , ByVal iWOLineID As Integer, ByVal iModelID As Integer) As Integer
            Dim strSql, strTodayDate, strPalletPrefix, strPalletName As String
            Dim iNextSeq As Integer = 0

            Try
                strSql = "" : strTodayDate = "" : strPalletPrefix = "" : strPalletName = ""
                strTodayDate = Buisness.Generic.GetMySqlDateTime("%y%m%d")
                strPalletPrefix = "GLS" & strTodayDate & "N"
                strPalletName = PSS.Data.Production.Shipping.GetPalletNameNextSeqNo(_objDataProc, iCustID, iLocID, strPalletPrefix, 2)

                Return PSS.Data.Production.Shipping.CreatePallet(iCustID, iLocID, iModelID, iWOID, strPalletName, 0, iWOLineID, 0, 0, 0)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************
        Public Function AssignDeviceToPallet(ByVal iPalletID As Integer, ByVal iDeviceID As Integer _
                                           , ByVal strLed1 As String, ByVal strLed2 As String, ByVal strLed3 As String, ByVal strLed4 As String _
                                           , ByVal strPSU As String, ByVal strBasePlate As String) As Integer
            Dim strSql As String = ""

            Try
                strSql = "UPDATE tdevice, tasndata " & Environment.NewLine
                strSql &= "SET Pallett_ID = " & iPalletID & Environment.NewLine
                strSql &= ", SN2 = '" & strLed1 & "'" & Environment.NewLine
                strSql &= ", SN3 = '" & strLed2 & "'" & Environment.NewLine
                strSql &= ", SN4 = '" & strLed3 & "'" & Environment.NewLine
                strSql &= ", SN5 = '" & strLed4 & "'" & Environment.NewLine
                strSql &= ", InPO = '" & strPSU & "'" & Environment.NewLine
                strSql &= ", InRMA = '" & strBasePlate & "'" & Environment.NewLine
                strSql &= "WHERE tdevice.Device_ID = tasndata.Device_ID " & Environment.NewLine
                strSql &= "AND tdevice.Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "AND (Pallett_ID is null or Pallett_ID = 0) " & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************
        Public Function RemoveSNfromPallet(ByVal iPalletID As Integer, ByVal iDeviceID As Integer ) As Integer
            Dim strSql As String = ""

            Try
                strSql = "UPDATE tdevice, tasndata " & Environment.NewLine
                strSql &= "SET Pallett_ID = null " & Environment.NewLine
                strSql &= ", SN2 = ''" & Environment.NewLine
                strSql &= ", SN3 = ''" & Environment.NewLine
                strSql &= ", SN4 = ''" & Environment.NewLine
                strSql &= ", SN5 = ''" & Environment.NewLine
                strSql &= ", InPO = ''" & Environment.NewLine
                strSql &= ", InRMA = ''" & Environment.NewLine
                strSql &= "WHERE tdevice.Device_ID = tasndata.Device_ID " & Environment.NewLine
                strSql &= "AND tdevice.Pallett_ID = " & iPalletID & Environment.NewLine
                If iDeviceID > 0 Then strSql &= "AND tdevice.Device_ID = " & iDeviceID & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************
        Public Function PrintBoxLabel(ByVal iPalletID As Integer, ByVal strReportName As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT Pallett_Name as PalletName" & Environment.NewLine
                strSql &= ", ItemNo as 'PartNum'" & Environment.NewLine
                strSql &= ", ItemDesc as 'PartDesc'" & Environment.NewLine
                strSql &= ", Pallett_QTY as 'PalletQty'" & Environment.NewLine
                strSql &= ", ShipToAddress as 'ShipToAdd1'" & Environment.NewLine
                strSql &= ", ShipToCity as 'ShipToCity'" & Environment.NewLine
                strSql &= ", ShipToState as 'ShipToState'" & Environment.NewLine
                strSql &= ", ShipToZipCode as 'ShipToZip'" & Environment.NewLine
                strSql &= ", ShipToContact as 'ShipToContactName'" & Environment.NewLine
                strSql &= ", tworkorderline.SalesOrder as 'OrderNo'" & Environment.NewLine
                strSql &= ", LineNo as 'OrderLineNo'" & Environment.NewLine
                strSql &= ", Quantity as 'OrderLineQty'" & Environment.NewLine
                strSql &= "FROM tpallett" & Environment.NewLine
                strSql &= "INNER JOIN tworkorderline ON tpallett.WO_ID = tworkorderline.WO_ID AND tpallett.Pallet_SkuLen = tworkorderline.WOL_ID" & Environment.NewLine
                strSql &= "INNER JOIN tworkorderinfo ON tpallett.WO_ID = tworkorderinfo.WO_ID" & Environment.NewLine
                strSql &= "WHERE tpallett.Pallett_ID = " & iPalletID & ";" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    PSS.Data.Buisness.TracFone.clsMisc.PrintCrystalReportLabel(dt, strReportName, 1)
                    Return dt.Rows.Count
                Else
                    Return dt.Rows.Count
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************
        Public Function SetShippingClosedFlag(ByVal iWOLineID As Integer, ByVal iValue As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "UPDATE tworkorderline SET ShippingClosed = " & iValue & Environment.NewLine
                strSql &= "WHERE tworkorderline.WOL_ID = " & iWOLineID & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************
        Public Function GetOpenToProducePallets(ByVal iCustID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT tmodel.Model_ID, tworkorder.WO_ID, tpallett.Cust_ID, tpallett.Loc_ID, tpallett.Pallett_ID, Pallet_ShipType" & Environment.NewLine
                strSql &= ", WO_CustWO as 'Order #', Pallett_Name as 'Lot Name', Model_Desc as 'Model', Pallett_QTY as  'Quantity'" & Environment.NewLine
                strSql &= "FROM tpallett" & Environment.NewLine
                strSql &= "INNER JOIN tworkorder ON tpallett.WO_ID = tworkorder.WO_ID" & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tpallett.Model_ID = tmodel.Model_ID" & Environment.NewLine
                strSql &= "WHERE tpallett.Cust_ID = 2427 and Pallett_ReadyToShipFlg = 1 and Pallett_ShipDate is null" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************
        Public Function ExtractSNs(ByVal iPalletID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT tdevice.Model_ID, tdevice.WO_ID, tdevice.Loc_ID, tdevice.Device_ID, Device_SN " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "WHERE Pallett_ID = " & iPalletID & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************



    End Class
End Namespace