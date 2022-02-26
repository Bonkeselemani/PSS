Option Explicit On 

Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO

Namespace Production
    Public Class Shipping
        Private objMisc As Production.Misc

        '***************************************************
        Public Sub New()
            objMisc = New Production.Misc()
        End Sub

        Protected Overrides Sub Finalize()
            objMisc = Nothing
            MyBase.Finalize()
        End Sub
        '***************************************************

        '**************************************************************
        Public Function UpdateShipInfo(ByVal iDevice_ID As Integer, _
                                        ByVal strShipWorkDate As String, ByVal iShift_ID As Integer, _
                                        Optional ByVal iPallet_ID As Integer = 0, Optional ByVal iShip_ID As Integer = 0, _
                                        Optional ByVal iFinishedGood As Integer = -1, Optional ByVal strWorkStation As String = "") As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0

            Try
                ''Update ship information in tdevice
                strSql = "UPDATE tdevice, tcellopt " & Environment.NewLine
                strSql &= "SET Device_DateShip = now() " & Environment.NewLine
                strSql &= ", Device_ShipWorkDate = '" & strShipWorkDate & "' " & Environment.NewLine
                strSql &= ", Shift_ID_Ship = " & iShift_ID & Environment.NewLine
                If iPallet_ID > 0 Then strSql &= ", Pallett_ID = " & iPallet_ID & Environment.NewLine
                If iShip_ID > 0 Then strSql &= ", Ship_ID = " & iShip_ID & Environment.NewLine
                If iFinishedGood > -1 Then strSql &= ", Device_FinishedGoods = " & iFinishedGood & Environment.NewLine
                strSql &= ", Cellopt_WIPEntryDt = now() " & Environment.NewLine
                strSql &= ", Cellopt_WIPOwnerOld = Cellopt_WIPOwner " & Environment.NewLine
                strSql &= ", Cellopt_WIPOwner = 5 " & Environment.NewLine
                If strWorkStation.Trim.Length > 0 Then strSql &= ", WorkStationEntryDt = now(), WorkStation = '" & strWorkStation & "' " & Environment.NewLine
                strSql &= "WHERE tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                strSql &= "AND tdevice.Device_ID = " & iDevice_ID & ";"

                Me.objMisc._SQL = strSql
                i = Me.objMisc.ExecuteNonQuery

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function InsertIntoTdailyproduction(ByVal strWorkDate As String, _
                                                   ByVal iUserID As Integer, _
                                                   ByVal iWCLocation_ID As Integer, _
                                                   ByVal iLine_ID As Integer, _
                                                   ByVal iGroup_ID As Integer, _
                                                   ByVal iDevice_ID As Integer, _
                                                   ByVal iPallett_ID As Integer) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0
            Dim dt1 As DataTable
            Dim R1 As DataRow

            Try
                '*****************
                'Check if DeviceID and PallettID exists together in daily production
                strSql = "SELECT Count(*) as cnt FROM tdailyproduction WHERE device_id = " & iDevice_ID & " and Pallett_ID = " & iPallett_ID & ";"
                objMisc._SQL = strSql
                dt1 = objMisc.GetDataTable
                R1 = dt1.Rows(0)

                If R1("cnt") = 0 Then
                    'STEP 2: Update tdailyproduction table
                    strSql = "INSERT INTO tdailyproduction " & Environment.NewLine
                    strSql += "(DP_Date, User_ID, WCLocation_ID, Line_ID, Group_ID, Device_ID, Pallett_ID) " & Environment.NewLine
                    strSql += "values " & Environment.NewLine
                    strSql += "('" & strWorkDate & "', " & iUserID & ", " & iWCLocation_ID & ", " & iLine_ID & ", " & iGroup_ID & ", " & iDevice_ID & ", " & iPallett_ID & ");"
                    objMisc._SQL = strSql
                    i = objMisc.ExecuteNonQuery

                    If i = 0 Then
                        MsgBox("Device could not be added to daily production.")
                    End If
                End If

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

        '**************************************************************
        Public Shared Function RemoveSNfromPallet(ByVal iPallettID As Integer, _
                                                  Optional ByVal iDeviceID As Integer = 0) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                If iDeviceID > 0 Then
                    'Update tdevice table
                    strSql = "Update tdevice set Pallett_ID = NULL, WO_ID_Out = NULL where pallett_id = " & iPallettID.ToString & " and device_id = " & iDeviceID.ToString & " and device_dateship is null"
                    i = objDataProc.ExecuteNonQuery(strSql)

                Else
                    'STEP 1: Get all devices for the pallet
                    strSql = "Select count(*) as cnt from tdevice where pallett_id = " & iPallettID.ToString

                    If objDataProc.GetIntValue(strSql) = 0 Then
                        Throw New Exception("No devices found on this pallet or box.")
                    End If

                    'STEP 2: Update tdevice table
                    strSql = "Update tdevice set Pallett_ID = NULL, WO_ID_Out = NULL where pallett_id = " & iPallettID.ToString & " and device_dateship is null"

                    i = objDataProc.ExecuteNonQuery(strSql)
                End If

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '**************************************************************
        Public Shared Function AssignDeviceToPallet(ByVal iDeviceID As Integer, _
                                                    ByVal iPalletID As Integer) As Integer
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = ""

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "UPDATE tdevice " & Environment.NewLine
                strSql &= "SET pallett_id = " & iPalletID.ToString & Environment.NewLine
                strSql &= "WHERE device_ID = " & iDeviceID.ToString
                Return objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '******************************************************************
        Public Shared Function DeleteEmptyPallet(ByVal iPalletID As Integer, _
                                                 ByVal iUsrID As Integer, _
                                                 Optional ByVal bDelete As Boolean = False) As Integer
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "Select Count(*) as cnt from tdevice where pallett_id = " & iPalletID.ToString

                If objDataProc.GetIntValue(strSql) = 0 Then
                    'reset pallett as invalid
                    If bDelete Then
                        strSql = "Delete from tpallett WHERE Pallett_ID = " & iPalletID.ToString & ";"
                        Return objDataProc.ExecuteNonQuery(strSql)
                    Else
                        strSql = "UPDATE tpallett SET Pallett_QTY = 0, Pallet_Invalid = 1, Pallet_InvalidUsrID = " + iUsrID.ToString + Environment.NewLine
                        strSql += "WHERE Pallett_ID = " + iPalletID.ToString + Environment.NewLine
                        Return objDataProc.ExecuteNonQuery(strSql)
                    End If
                 
                Else
                    Throw New Exception("This is not an empty Box/Pallet.")
                End If

            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '**************************************************************
        Public Shared Function PrintPalletLicensePlate(ByVal strPalletName As String, _
                                                ByVal iModelID As Integer, _
                                                ByVal strPalletType As String, _
                                                ByVal iPalletQty As Integer, _
                                                ByVal iPrintCopies As Integer, _
                                                Optional ByVal strBaud As String = "") As Integer
            Const strReportName As String = "Ship Pallet Label New Push.rpt"
            Dim dt As DataTable
            Dim objRpt As ReportDocument
            Dim objDBRManifest As PSS.Data.Buisness.DBRManifest
            Dim iQty As Integer = 0
            Dim i As Integer = 0
            Dim strModel As String = ""

            Try
                If iPrintCopies > 0 Then
                    objDBRManifest = New PSS.Data.Buisness.DBRManifest()
                    strModel = PSS.Data.Buisness.Generic.GetModelDesc(iModelID)
                    '*****************************
                    '1: Print License Plate
                    '*****************************
                    dt = objDBRManifest.GetShipPalletData(strPalletName, iPalletQty, strModel, strPalletType, New String() {"Leader Verification:", "", "Shipper Verification:"}, strBaud)

                    If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                        objRpt = New ReportDocument()

                        With objRpt
                            .Load(PSS.Data.ConfigFile.GetBaseReportPath & strReportName)
                            .SetDataSource(dt)
                            .PrintToPrinter(iPrintCopies, True, 0, 0)
                        End With
                    End If
                End If
            Catch ex As Exception
                Throw ex
            Finally
                objRpt = Nothing
                objDBRManifest = Nothing
            End Try
        End Function
        '**************************************************************
        Public Shared Function PrintCustomerPallet(ByVal strCustomerName As String, _
                                                   ByVal strPalletName As String, _
                                                   ByVal iModelID As Integer, _
                                                   ByVal strPalletType As String, _
                                                   ByVal iPalletQty As Integer, _
                                                   ByVal iPrintCopies As Integer) As Integer

            Const strReportName As String = "Ship Pallet Label Customer.rpt"
            Dim dt As DataTable
            Dim objRpt As ReportDocument
            Dim objDBRManifest As PSS.Data.Buisness.DBRManifest
            Dim iQty As Integer = 0
            Dim i As Integer = 0
            Dim strModel As String = ""

            Try
                If iPrintCopies > 0 Then
                    objDBRManifest = New PSS.Data.Buisness.DBRManifest()
                    strModel = PSS.Data.Buisness.Generic.GetModelDesc(iModelID)

                    dt = objDBRManifest.GetShipCustomerData(strCustomerName, strPalletName, iPalletQty, strModel, strPalletType, New String() {"Leader Verification:", "", "Shipper Verification:"})

                    If Not IsNothing(dt) Then
                        objRpt = New ReportDocument()

                        With objRpt
                            .Load(PSS.Data.ConfigFile.GetBaseReportPath & strReportName)
                            .SetDataSource(dt)
                            .PrintToPrinter(iPrintCopies, True, 0, 0)
                        End With
                    End If
                End If
            Catch ex As Exception
                Throw ex
            Finally
                objRpt = Nothing
                objDBRManifest = Nothing
            End Try
        End Function

        '**************************************************************
        Public Shared Function PrintBoxLabel(ByVal strPalletName As String) As Integer
            Const strReportName As String = "Box Label Push.rpt"
            Dim dt As DataTable
            Dim objRpt As ReportDocument
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = ""

            Try
                '*****************************
                '1: Print License Plate
                '*****************************
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT '" & strPalletName & "' as BoxID, '*" & strPalletName & "*' as BoxBarcode "
                dt = objDataProc.GetDataTable(strSql)

                If Not IsNothing(dt) Then
                    objRpt = New ReportDocument()

                    With objRpt
                        .Load(PSS.Data.ConfigFile.GetBaseReportPath & strReportName)
                        .SetDataSource(dt)
                        'Why searching for specific printer name? Because it uses 2 printers
                        'One for Mainifest Excel sheet, one for label
                        'One of these two printers is shared printer from other pc or server; one local LPT1
                        'printer for Excel must be defaut
                        'Label printer's name has to be "EasyCoder", for example, 
                        .PrintOptions.PrinterName = "EasyCoder"
                        '.PrintOptions.PaperSize = ""
                        .PrintToPrinter(1, True, 0, 0)
                    End With
                End If
            Catch ex As Exception
                Throw ex
            Finally
                objRpt = Nothing
                objDataProc = Nothing
            End Try
        End Function



        '**************************************************************
        Public Shared Function PrintVivintBoxLabel(ByVal dt As DataTable) As Integer
            Const strReportName As String = "Vivint_Pallett_BoxId.rpt"

            Dim objRpt As ReportDocument
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = ""

            Try
                '*****************************
                '1: Print License Plate
                '*****************************

                If Not IsNothing(dt) Then
                    objRpt = New ReportDocument()

                    With objRpt
                        .Load(PSS.Data.ConfigFile.GetBaseReportPath & strReportName)
                        .SetDataSource(dt)
                        'Why searching for specific printer name? Because it uses 2 printers
                        'One for Mainifest Excel sheet, one for label
                        'One of these two printers is shared printer from other pc or server; one local LPT1
                        'printer for Excel must be defaut
                        'Label printer's name has to be "EasyCoder", for example, 
                        '.PrintOptions.PaperSize = ""
                        .PrintToPrinter(1, True, 0, 0)
                    End With
                End If
            Catch ex As Exception
                Throw ex
            Finally
                objRpt = Nothing
                objDataProc = Nothing
            End Try
        End Function
        '**************************************************************

        '**************************************************************
        Public Shared Function PrintVivintKittedLabel(ByVal dt As DataTable) As Integer
            Const strReportName As String = "Vivint_Kit_Device.rpt"

            Dim objRpt As ReportDocument
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = ""

            Try
                '*****************************
                '1: Print License Plate
                '*****************************

                If Not IsNothing(dt) Then
                    objRpt = New ReportDocument()

                    With objRpt
                        .Load(PSS.Data.ConfigFile.GetBaseReportPath & strReportName)
                        .SetDataSource(dt)
                        'Why searching for specific printer name? Because it uses 2 printers
                        'One for Mainifest Excel sheet, one for label
                        'One of these two printers is shared printer from other pc or server; one local LPT1
                        'printer for Excel must be defaut
                        'Label printer's name has to be "EasyCoder", for example, 
                        '.PrintOptions.PaperSize = ""
                        .PrintToPrinter(2, True, 0, 0)
                    End With
                End If
            Catch ex As Exception
                Throw ex
            Finally
                objRpt = Nothing
                objDataProc = Nothing
            End Try
        End Function
        '**************************************************************

        Public Shared Function Print4x4GenericShipBoxLabel(ByVal iPalletID As Integer, _
                                                           ByVal strReportName As String, _
                                                           ByVal iPrintCopies As Integer, _
                                                           Optional ByVal PrintAQLLotName As Boolean = False) As Integer

            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc
            Dim dt As DataTable
            Dim objRpt As ReportDocument

            Try
                If iPrintCopies > 0 Then
                    objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                    strSql = "SELECT Pallett_Name as 'PalletName', Pallett_QTY as PalletQty, Model_Desc as 'ModelDesc'  " & Environment.NewLine
                    strSql &= ", IF(Pallettype_LDesc is null, '', Pallettype_LDesc) as 'PalletResult' " & Environment.NewLine
                    strSql &= ", IF(tpallett.WO_ID is null, 0, tpallett.WO_ID) as WOID " & Environment.NewLine
                    strSql &= ", IF(tworkorder.WO_CustWO is null, '', tworkorder.WO_CustWO) as WODesc " & Environment.NewLine
                    strSql &= ", tpallett.Pallet_ShipType " & Environment.NewLine
                    If PrintAQLLotName = True Then
                        strSql &= ", AQL_Lot.AQL_Lot_Name as AQLLotName " & Environment.NewLine
                    End If
                    strSql &= "FROM tpallett INNER JOIN tmodel ON tpallett.Model_ID = tmodel.Model_ID" & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN lpallettype ON tpallett.PalletType_ID = lpallettype.PalletType_ID" & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN tworkorder ON tpallett.WO_ID = tworkorder.WO_ID" & Environment.NewLine
                    If PrintAQLLotName = True Then
                        strSql &= "LEFT OUTER JOIN AQL_Lot ON tpallett.AQL_Lot_ID = AQL_Lot.AQL_Lot_ID" & Environment.NewLine
                    End If
                    strSql &= "WHERE Pallett_ID = " & iPalletID & "" & Environment.NewLine
                    dt = objDataProc.GetDataTable(strSql)

                    '*****************************
                    '1: Print License Plate
                    '*****************************
                    If Not IsNothing(dt) Then
                        objRpt = New ReportDocument()

                        With objRpt
                            '.Load(PSS.Data.ConfigFile.GetBaseReportPath & strReportName)
                            .Load(strReportName)
                            .SetDataSource(dt)
                            .PrintToPrinter(iPrintCopies, True, 0, 0)
                        End With
                    End If
                End If
            Catch ex As Exception
                Throw ex
            Finally
                objRpt = Nothing
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '**************************************************************
        Public Shared Function Print4x4JabilShipBoxLabel(ByVal iPalletID As Integer, _
                                                           ByVal strReportName As String, _
                                                           ByVal iPrintCopies As Integer) As Integer
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc
            Dim dt As DataTable
            Dim objRpt As ReportDocument

            Try
                If iPrintCopies > 0 Then
                    objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                    strSql = "SELECT Pallett_Name as 'PalletName', Pallett_QTY as PalletQty, '' as 'ModelDesc'  " & Environment.NewLine
                    strSql &= ", IF(Pallettype_LDesc is null, '', Pallettype_LDesc) as 'PalletResult' " & Environment.NewLine
                    strSql &= ", IF(tpallett.WO_ID is null, 0, tpallett.WO_ID) as WOID " & Environment.NewLine
                    strSql &= ", IF(tworkorder.WO_CustWO is null, '', tworkorder.WO_CustWO) as WODesc " & Environment.NewLine
                    strSql &= ", tpallett.Pallet_ShipType " & Environment.NewLine
                    'strSql &= "FROM tpallett INNER JOIN tmodel ON tpallett.Model_ID = tmodel.Model_ID" & Environment.NewLine
                    strSql &= "FROM tpallett" & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN lpallettype ON tpallett.PalletType_ID = lpallettype.PalletType_ID" & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN tworkorder ON tpallett.WO_ID = tworkorder.WO_ID" & Environment.NewLine
                    strSql &= "WHERE Pallett_ID = " & iPalletID & "" & Environment.NewLine
                    dt = objDataProc.GetDataTable(strSql)

                    '*****************************
                    '1: Print License Plate
                    '*****************************
                    If Not IsNothing(dt) Then
                        objRpt = New ReportDocument()

                        With objRpt
                            '.Load(PSS.Data.ConfigFile.GetBaseReportPath & strReportName)
                            .Load(strReportName)
                            .SetDataSource(dt)
                            .PrintToPrinter(iPrintCopies, True, 0, 0)
                        End With
                    End If
                End If
            Catch ex As Exception
                Throw ex
            Finally
                objRpt = Nothing
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '**************************************************************
        Public Shared Function GetPalletInfoByName(ByVal strPalletName As String, _
                                                   Optional ByVal iCustID As Integer = 0) As DataTable
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = ""

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT distinct tpallett.*, pt_id" & Environment.NewLine
                strSql &= ", IF(Pallettype_SDesc is null, '', Pallettype_SDesc) AS Pallettype_SDesc" & Environment.NewLine
                strSql &= ", IF(Pallettype_LDesc is null, '', Pallettype_LDesc) AS Pallettype_LDesc" & Environment.NewLine
                strSql &= ", IF(Model_Desc is null, '', Model_Desc) AS Model_Desc" & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lpallettype ON tpallett.PalletType_ID = lpallettype.PalletType_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tmodel ON tpallett.Model_ID = tmodel.Model_ID" & Environment.NewLine
                strSql &= "WHERE Pallett_Name = '" & strPalletName & "'" & Environment.NewLine
                If iCustID > 0 Then strSql &= "AND Cust_ID = " & iCustID & Environment.NewLine
                Return objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '**************************************************************
        Public Shared Function ReopenPallet(ByVal iPalletID As Integer) As Integer
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = ""

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "update tpallett inner join tdevice on tpallett.Pallett_ID = tdevice.Pallett_ID " & Environment.NewLine
                strSql += "Set tpallett.Pallett_ReadyToShipFlg = 0 " & Environment.NewLine
                strSql += "where tpallett.Pallett_ID = " & iPalletID & " and tdevice.Device_DateShip is NULL and Pallett_ReadyToShipFlg = 1"

                Return objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '**************************************************************
        Public Shared Function CreatePallet(ByVal iCustID As Integer, ByVal iLocID As Integer _
                                          , ByVal iModelID As Integer, ByVal iWOID As Integer, ByVal strPalletName As String _
                                          , ByVal iPalletShipType As Integer, ByVal strPallet_SkuLen As String, ByVal iPallettMaxQty As Integer _
                                          , ByVal dblPalletWeight As Double, ByVal iPalletTypeID As Integer) As Integer
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = ""
            Dim iPalletID As Integer = 0

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                '******************************
                'check for duplicate pallet
                '******************************
                strSql = "Select count(*) as cnt From tpallett where Pallett_Name = '" & strPalletName & "' and Loc_ID = " & iLocID
                If objDataProc.GetIntValue(strSql) > 0 Then Throw New Exception("System is trying to create pallet (" & strPalletName & ") which is already existed in system.")

                '******************************
                'Create pallet
                ''******************************
                strSql = "INSERT INTO tpallett ( " & Environment.NewLine
                strSql &= " Cust_ID  " & Environment.NewLine
                strSql &= ", Loc_ID  " & Environment.NewLine
                strSql &= ", Model_ID " & Environment.NewLine
                strSql &= ", WO_ID " & Environment.NewLine
                strSql &= ", Pallett_Name " & Environment.NewLine
                strSql &= ", Pallet_ShipType " & Environment.NewLine
                strSql &= ", Pallet_SkuLen " & Environment.NewLine
                strSql &= ", Pallett_MaxQty " & Environment.NewLine
                strSql &= ", Pallet_Weight " & Environment.NewLine
                If iPalletTypeID > 0 Then strSql &= ", PalletType_ID " & Environment.NewLine
                strSql &= ") VALUES (  " & Environment.NewLine
                strSql &= " " & iCustID & " " & Environment.NewLine
                strSql &= ", " & iLocID & " " & Environment.NewLine
                strSql &= ", " & iModelID & " " & Environment.NewLine
                strSql &= ", " & iWOID & " " & Environment.NewLine
                strSql &= ", '" & strPalletName & "' " & Environment.NewLine
                strSql &= ", " & iPalletShipType & " " & Environment.NewLine
                strSql &= ", '" & strPallet_SkuLen & "' " & Environment.NewLine
                strSql &= ", " & iPallettMaxQty & " " & Environment.NewLine
                strSql &= ", " & dblPalletWeight & " " & Environment.NewLine
                If iPalletTypeID > 0 Then strSql &= ", " & iPalletTypeID & Environment.NewLine
                strSql &= ");" & Environment.NewLine
                iPalletID = objDataProc.idTransaction(strSql, "tpallett")

                If iPalletID = 0 Then iPalletID = GetPalletID(objDataProc, iCustID, iLocID, strPalletName)

                Return iPalletID
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Shared Function GetPalletID(ByRef objDataProc As DBQuery.DataProc, ByVal iCustID As Integer _
                                  , ByVal iLocID As Integer, ByVal strPalletName As String) As Integer
            Dim strSQL As String
            Dim dt As DataTable
            Dim iPalletID As Integer = 0

            Try
                strSQL = "SELECT Pallett_ID " & Environment.NewLine
                strSQL &= "FROM tpallett " & Environment.NewLine
                strSQL &= "WHERE Pallett_Name = '" & strPalletName & "' " & Environment.NewLine
                strSQL &= "AND Cust_ID = " & iCustID & Environment.NewLine
                strSQL &= "AND Loc_ID = " & iLocID & Environment.NewLine
                strSQL &= "AND Pallet_Invalid = 0 " & Environment.NewLine
                dt = objDataProc.GetDataTable(strSQL)
                If dt.Rows.Count > 1 Then
                    Throw New Exception("Duplicate record """ & strPalletName & """. Please contact IT.")
                ElseIf dt.Rows.Count = 1 Then
                    iPalletID = dt.Rows(0)("Pallett_ID")
                End If

                Return iPalletID
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Shared Function GetPalletNameNextSeqNo(ByRef objDataProc As DBQuery.DataProc, ByVal iCustID As Integer, ByVal iLocID As Integer _
                                                    , ByVal strPalletPrefix As String, ByVal iNumberLength As Integer) As String
            Dim strSQL As String
            Dim dt As DataTable
            Dim strPallett_Name As String = strPalletPrefix

            Try
                strSQL = "SELECT max(right(Pallett_Name, " & iNumberLength & " ) ) + 1 as NextSequenceNumber " & Environment.NewLine
                strSQL &= "FROM tpallett " & Environment.NewLine
                strSQL &= "WHERE Pallett_Name like '" & strPalletPrefix & "%' " & Environment.NewLine
                strSQL &= "AND Cust_ID = " & iCustID & Environment.NewLine
                strSQL &= "AND Loc_ID = " & iLocID & Environment.NewLine
                dt = objDataProc.GetDataTable(strSQL)
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0)("NextSequenceNumber")) Then
                        strPallett_Name &= dt.Rows(0)("NextSequenceNumber").ToString.Trim.PadLeft(iNumberLength, "0")
                    Else
                        strPallett_Name &= "1".PadLeft(iNumberLength, "0")
                    End If
                Else
                    strPallett_Name &= "1".PadLeft(iNumberLength, "0")
                End If

                Return strPallett_Name
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetPalletName(ByVal iPalletID As Integer) As String
            Dim strSQL As String

            Try
                strSQL = "SELECT Pallett_Name " & Environment.NewLine
                strSQL &= "FROM tpallett " & Environment.NewLine
                strSQL &= "WHERE Pallett_ID = " & iPalletID & " " & Environment.NewLine

                Return Me.objMisc.GetSingletonString(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function GetWorkorderInfo(ByVal iWOID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT * " & Environment.NewLine
                strSql &= "FROM tworkorder " & Environment.NewLine
                strSql &= "WHERE WO_ID = " & iWOID & Environment.NewLine
                Return Me.objMisc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function GetUnshipPalletByWO(ByVal iWOID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT * " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "WHERE WO_ID = " & iWOID & " AND Pallett_ShipDate is null " & Environment.NewLine
                Return Me.objMisc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function GetShippedCountByWO(ByVal iWOID As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "SELECT count(*) as cnt " & Environment.NewLine
                strSql &= "FROM tworkorder INNER JOIN tdevice On tworkorder.WO_ID = tdevice.WO_ID " & Environment.NewLine
                strSql &= "WHERE tworkorder.WO_ID = " & iWOID & " AND Device_DateShip is not null " & Environment.NewLine
                Return Me.objMisc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function GetReadyToShipCountByWO(ByVal iWOID As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "SELECT count(*) as cnt " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "WHERE WO_ID = " & iWOID & " AND Device_DateShip is null " & Environment.NewLine
                Return Me.objMisc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************
        Public Function GetProjectTypes(ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String
            Dim dt As DataTable

            Try
                strSql = "SELECT pt_id, pt_desc, pt_SDesc, Prod_ID " & Environment.NewLine
                strSql &= "FROM lprojecttype " & Environment.NewLine
                dt = Me.objMisc.GetDataTable(strSql)

                If booAddSelectRow = True Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function GetShipPalletTypes(ByVal booAddSelectRow As Boolean, _
                                          ByVal iProjectType As Integer) As DataTable
            Dim strSql As String
            Dim dt As DataTable

            Try
                strSql = "SELECT * " & Environment.NewLine
                strSql &= "FROM lpallettype " & Environment.NewLine
                strSql &= "WHERE Pt_id = " & iProjectType & " AND Active = 1 " & Environment.NewLine
                dt = Me.objMisc.GetDataTable(strSql)

                If booAddSelectRow = True Then dt.LoadDataRow(New Object() {"0", "0", "", "--SELECT--"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function GetAvailablePallets(ByVal booAddSelectRow As Boolean, ByVal iLocID As Integer, ByVal iCustID As Integer, _
                                            ByVal iReadyToProduce As Integer, _
                                            Optional ByVal iModelID As Integer = 0, Optional ByVal iWOID As Integer = 0, _
                                            Optional ByVal iPallet_ShipType As Integer = -1, Optional ByVal strSkuLen As String = "", _
                                            Optional ByVal iPalletType_ID As Integer = 0, _
                                            Optional ByVal strPalletPrefix As String = "") As DataTable
            Dim strSql As String
            Dim dt As DataTable

            Try
                strSql = "SELECT tpallett.* " & Environment.NewLine
                strSql &= ", IF(Model_Desc IS NULL, '', Model_Desc) AS Model_Desc " & Environment.NewLine
                strSql &= ", IF(WO_CustWo IS NULL, '', WO_CustWo) AS WO_CustWo " & Environment.NewLine
                strSql &= ", IF(Pallettype_SDesc IS NULL, '', Pallettype_SDesc) AS Pallettype_SDesc" & Environment.NewLine
                strSql &= ", IF(Pallettype_LDesc IS NULL, '', Pallettype_LDesc) AS Pallettype_LDesc " & Environment.NewLine
                strSql &= ", IF(NoPartAllow IS NULL, -1, NoPartAllow) AS NoPartAllow " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                If iModelID > 0 Then strSql &= "INNER JOIN tmodel ON tpallett.Model_ID = tmodel.Model_ID" & Environment.NewLine Else strSql &= "LEFT OUTER JOIN tmodel ON tpallett.Model_ID = tmodel.Model_ID" & Environment.NewLine
                If iWOID > 0 Then strSql &= "INNER JOIN tworkorder ON tpallett.WO_ID = tworkorder.WO_ID" & Environment.NewLine Else strSql &= "LEFT OUTER JOIN tworkorder ON tpallett.WO_ID = tworkorder.WO_ID" & Environment.NewLine
                If iPallet_ShipType <> -1 Then strSql &= "INNER JOIN lpallettype ON tpallett.PalletType_ID = lpallettype.PalletType_ID" & Environment.NewLine Else strSql &= "LEFT OUTER JOIN lpallettype ON tpallett.PalletType_ID = lpallettype.PalletType_ID" & Environment.NewLine
                strSql &= "WHERE tpallett.Loc_ID = " & iLocID & " AND tpallett.Cust_ID = " & iCustID & Environment.NewLine
                strSql &= "AND Pallett_ShipDate is null AND Pallet_Invalid = 0" & Environment.NewLine
                strSql &= "AND Pallett_ReadyToShipFlg = " & iReadyToProduce & Environment.NewLine
                If iModelID > 0 Then strSql &= "AND tpallett.Model_ID = " & iModelID & Environment.NewLine
                If iWOID > 0 Then strSql &= "AND tpallett.WO_ID = " & iWOID & Environment.NewLine
                If iPallet_ShipType <> -1 Then strSql &= "AND tpallett.Pallet_ShipType = " & iPallet_ShipType & Environment.NewLine
                If strSkuLen.Trim.Length > 0 Then strSql &= "AND tpallett.Pallet_SkuLen = " & strSkuLen & Environment.NewLine
                If iPalletType_ID > 0 Then strSql &= "AND tpallett.PalletType_ID = " & iPalletType_ID & Environment.NewLine
                If strPalletPrefix.Trim.Length > 0 Then strSql &= "AND Pallett_Name like '" & strPalletPrefix & "'" & Environment.NewLine
                dt = Me.objMisc.GetDataTable(strSql)

                If booAddSelectRow = True Then dt.LoadDataRow(New Object() {"0", "0", "--SELECT--"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************
        Public Shared Sub WriteDataToFile(ByVal strFileLoc As String, _
                                    ByVal strOutputData As String)
            Dim objWriter As StreamWriter
            Try
                objWriter = New StreamWriter(strFileLoc)
                objWriter.Write(strOutputData)
            Catch ex As Exception
                Throw ex
            Finally
                objWriter.Close()
                If Not IsNothing(objWriter) Then
                    objWriter = Nothing
                End If
            End Try
        End Sub

        '*******************************************************************************************************************
        Public Function GetDeviceSNs(ByVal iPalletID As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT * FROM tdevice WHERE Pallett_ID = " & iPalletID & " ORDER BY Device_ID ASC " & Environment.NewLine
                Return Me.objMisc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function GetDeviceSNsInOverPack(ByVal iOverPackID As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT tdevice.* FROM tdevice INNER JOIN tship ON tdevice.Ship_ID = tship.Ship_ID WHERE OverPack_ID = " & iOverPackID & " ORDER BY Device_ID ASC " & Environment.NewLine
                Return Me.objMisc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function GetDeviceWithPartsOnPallet(ByVal iPalletID As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT distinct Device_SN " & Environment.NewLine
                strSql &= "FROM tdevice INNER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON tdevicebill.Billcode_ID = lbillcodes.Billcode_ID AND lbillcodes.BillType_ID = 2" & Environment.NewLine
                strSql &= "WHERE tdevice.Pallett_ID = " & iPalletID & Environment.NewLine
                Return Me.objMisc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function CreateOverPack(ByVal iPalletID As Integer, _
                                       ByVal iPalletShipType As Integer, _
                                       ByVal strWorkDt As String) As Integer
            Dim strSql As String

            Try
                strSql = "insert into toverpack " & Environment.NewLine
                strSql += "(Overpack_shipdate, Pallett_ID, Overpack_Process) " & Environment.NewLine
                strSql += "values ( '" & strWorkDt & "', " & iPalletID & ", " & iPalletShipType & ");"

                Return Me.objMisc.idTransaction(strSql, "toverpack")
            Catch ex As Exception
                Throw ex
            Finally
                strSql = ""
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function CreateMasterPack(ByVal strUser As String, ByVal iProdID As Integer, ByVal iOverPack_ID As Integer, Optional ByVal iShipToID As Integer = 0) As Integer
            Dim strSql As String

            Try
                strSql = "insert into tship " & Environment.NewLine
                strSql &= "(ship_user, Prod_ID, OverPack_ID " & Environment.NewLine
                If iShipToID > 0 Then strSql &= ", ShipTo_ID " & Environment.NewLine
                strSql &= ") " & Environment.NewLine
                strSql &= "values ('" & strUser & "', " & iProdID & ", " & iOverPack_ID & Environment.NewLine
                If iShipToID > 0 Then strSql &= ", " & iShipToID & Environment.NewLine
                strSql &= ");"
                Return objMisc.idTransaction(strSql, "tship")
            Catch ex As Exception
                Throw New Exception("Buisness.BulkShipping.CreateMasterPack: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function UpdateDevicesShipInfo(ByVal iPalletID As Integer, _
                                              ByVal iShiftID As Integer, _
                                              ByVal iShip_ID As Integer, _
                                              ByVal strWorkDt As String, _
                                              ByVal iWipOwner_ID As Integer, _
                                              ByVal booWipOwnerOnCellopt As Boolean, _
                                              Optional ByVal iFinishedGoodsFlg As Integer = 1) As Integer
            'Dim strShipDate As String = ""
            Dim i As Integer = 0
            Dim strSql As String = ""

            Try

                '*****************************************
                'Update tdevice table
                strSql = "Update tdevice " & Environment.NewLine
                strSql += "set Ship_ID = " & iShip_ID & ", " & Environment.NewLine
                strSql += "Shift_ID_Ship = " & iShiftID & ", " & Environment.NewLine
                strSql += "Device_SendClaim = 0, " & Environment.NewLine
                strSql += "Device_DateShip = now(), " & Environment.NewLine
                strSql += "Device_ShipWorkDate = '" & strWorkDt & "', " & Environment.NewLine
                strSql += "Device_FinishedGoods = " & iFinishedGoodsFlg & " " & Environment.NewLine
                strSql += "WHERE Pallett_ID = " & iPalletID & ";"
                i = objMisc.ExecuteNonQuery(strSql)

                '*****************************************
                If iWipOwner_ID > 0 Then
                    If booWipOwnerOnCellopt = True Then
                        'Update tcellopt table
                        strSql = "UPDATE tcellopt " & Environment.NewLine        ' Ready Toship
                        strSql += "INNER JOIN tdevice ON tcellopt.Device_ID = tdevice.Device_ID" & Environment.NewLine
                        strSql += "SET Cellopt_WIPOwnerOld = Cellopt_WIPOwner, " & Environment.NewLine
                        strSql += "Cellopt_WIPOwner = " & iWipOwner_ID.ToString & ", " & Environment.NewLine        ' Ready Toship
                        strSql += "Cellopt_WIPEntryDt  = now() " & Environment.NewLine
                        strSql += "WHERE tdevice.Pallett_ID = " & iPalletID & ";"
                        Return objMisc.ExecuteNonQuery(strSql)
                    Else
                        'Update tmessdata table
                        strSql = "UPDATE tmessdata " & Environment.NewLine
                        strSql += "INNER JOIN tdevice ON tmessdata.Device_ID = tdevice.Device_ID" & Environment.NewLine
                        strSql += "SET wipowner_id_Old = wipowner_id, " & Environment.NewLine
                        strSql += "wipowner_id = 7, " & Environment.NewLine        ' Ready Toship
                        strSql += "wipowner_EntryDt = now() " & Environment.NewLine
                        strSql += "WHERE tdevice.Pallett_ID = " & iPalletID & ";"
                        Return objMisc.ExecuteNonQuery(strSql)
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function BulkShip(ByVal iHoldStatus As Integer, _
                                 ByVal iPalletID As Integer, _
                                 ByVal iPallettQty As Integer, _
                                 ByVal iPalletShipType As Integer, _
                                 ByVal strUser As String, _
                                 ByVal iProdID As Integer, _
                                 ByVal iShiftID As Integer, _
                                 ByVal iLocID As Integer, _
                                 Optional ByVal iShiptoID As Integer = 0, _
                                 Optional ByVal iWIPOwner As Integer = 5) As Integer
            Dim iOverpack_ID, iShip_ID, i, j, iDeviceFinishedGood As Integer
            Dim booWipOwnerOnCellopt As Boolean = True
            Dim strWorkDt As String = ""

            Try
                If iProdID = 1 Then booWipOwnerOnCellopt = False
                If iPalletShipType = 0 Then iDeviceFinishedGood = 1
                strWorkDt = PSS.Data.Buisness.Generic.GetWorkDate(iShiftID)

                '****************************************************************************
                ''Step 1:: Create Overpack
                '****************************************************************************
                iOverpack_ID = Me.CreateOverPack(iPalletID, iPalletShipType, strWorkDt)
                If iOverpack_ID = 0 Then Throw New Exception("System has failed to create overpack.")
                '****************************************************************************
                ''Step 2:: Create Masterpack
                '****************************************************************************
                iShip_ID = Me.CreateMasterPack(strUser, iProdID, iOverpack_ID, iShiptoID)
                If iShip_ID = 0 Then Throw New Exception("System has failed to create masterpack.")
                '****************************************************************************
                ''Step 3:: Update tdevice, tcellopt or tmessdata table
                '****************************************************************************
                i = UpdateDevicesShipInfo(iPalletID, iShiftID, iShip_ID, strWorkDt, iWIPOwner, booWipOwnerOnCellopt, iDeviceFinishedGood)
                '*************************************
                ''Step 4:: Close out workorders if any.
                '*************************************
                j = UpdateWOStatus(iPalletID, strWorkDt, )
                '*************************************
                ''Step 5:: Update Pallet Ship Status
                '*************************************
                j = UpdatePalletShipStatus(iPalletID, iPallettQty, iHoldStatus, strWorkDt, iLocID)
                '****************************************************************************
                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        'Flags the work order ready to be shipped if all devices for the WO are shipped
        '*******************************************************************************************************************
        Public Function UpdateWOStatus(ByVal iPalletID As Integer, _
                                       ByVal strWorkDt As String, _
                                       Optional ByVal iNoQC As Integer = 0) As Integer
            Dim strSql As String = ""
            Dim dtWO As DataTable
            Dim R1 As DataRow
            Dim i, iNotYetShipDevCnt As Integer

            Try
                strSql = "SELECT DISTINCT WO_ID FROM tdevice WHERE pallett_ID = " & iPalletID
                dtWO = objMisc.GetDataTable(strSql)
                For Each R1 In dtWO.Rows
                    '********************************
                    'Get Device count of the devices to be shipped for a WO
                    strSql = "Select Count(*) as cnt from tdevice where wo_id = " & R1("WO_ID") & " and device_dateship is null;"
                    iNotYetShipDevCnt = objMisc.GetIntValue(strSql)
                    '********************************
                    If iNotYetShipDevCnt <= 0 Then
                        strSql = "UPDATE tworkorder " & Environment.NewLine
                        strSql += "SET WO_Shipped = 1, WO_DateShip = '" & strWorkDt & "', WO_NoQc = " & iNoQC & " " & Environment.NewLine
                        strSql += "WHERE WO_ID = " & R1("WO_ID") & ";"
                        i += objMisc.ExecuteNonQuery(strSql)
                    End If
                Next R1

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing : PSS.Data.Buisness.Generic.DisposeDT(dtWO)
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function UpdatePalletShipStatus(ByVal iPalletID As Integer, _
                                               ByVal iPallettQty As Integer, _
                                               ByVal iHoldStatus As Integer, _
                                               ByVal strWorkDt As String, _
                                               ByVal iLocID As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "UPDATE tpallett " & Environment.NewLine
                strSql &= "SET Pallett_ShipDate = '" & strWorkDt & "', " & Environment.NewLine
                strSql &= "Pallett_BulkShipped = 1, " & Environment.NewLine
                strSql &= "AWPFlag = " & iHoldStatus & ", " & Environment.NewLine
                strSql &= "LOC_ID = " & iLocID & ", " & Environment.NewLine
                strSql &= "Pallett_QTY = " & iPallettQty & " " & Environment.NewLine
                strSql &= "WHERE pallett_id = " & iPalletID & ";"
                Return objMisc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function GetProdIDOfPallet(ByVal iPalletID As Integer) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT DISTINCT Prod_ID FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID" & Environment.NewLine
                strSql &= "WHERE pallett_id = " & iPalletID & ";"
                dt = objMisc.GetDataTable(strSql)
                If dt.Rows.Count > 1 Then
                    Throw New Exception("Multiple product existed.")
                Else
                    Return dt.Rows(0)("Prod_ID")
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '*******************************************************************************************************************
        Public Function UpdatePalletQuantity(ByVal iPalletID As Integer, _
                                                     ByVal iPallettQty As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "UPDATE tpallett " & Environment.NewLine
                strSql &= "SET Pallett_QTY = " & iPallettQty & " " & Environment.NewLine
                strSql &= "WHERE pallett_id = " & iPalletID & ";"
                Return objMisc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function GetOpenPallet(ByVal iLocID As Integer, ByVal iCustID As Integer, _
                                      Optional ByVal strSkuLen As String = "", _
                                      Optional ByVal strPalletPrefix As String = "") As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT tpallett.* " & Environment.NewLine
                strSql &= ", if ( Model_Desc is null, '', Model_Desc ) as Model" & Environment.NewLine
                strSql &= ", Pallettype_SDesc, Pallettype_LDesc " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tmodel ON tpallett.Model_ID = tmodel.Model_ID" & Environment.NewLine
                strSql &= "INNER JOIN lpallettype ON tpallett.PalletType_ID = lpallettype.PalletType_ID" & Environment.NewLine
                strSql &= "WHERE tpallett.Loc_ID = " & iLocID & " AND tpallett.Cust_ID = " & iCustID & Environment.NewLine
                strSql &= "AND Pallett_ReadyToShipFlg = 0 AND Pallett_ShipDate is null " & Environment.NewLine
                strSql &= "AND Pallet_Invalid = 0 " & Environment.NewLine
                If strSkuLen.Trim.Length > 0 Then strSql &= "AND Pallet_SkuLen = '" & strSkuLen & "'" & Environment.NewLine
                If strPalletPrefix.Trim.Length > 0 Then strSql &= "AND Pallett_Name like '" & strPalletPrefix & "%'" & Environment.NewLine
                strSql &= "ORDER BY Pallett_name " & Environment.NewLine
                Return Me.objMisc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function CreatePallet(ByVal iCustID As Integer, ByVal iLocID As Integer, _
                                     ByVal iModelID As Integer, ByVal iPalletTypeID As Integer, ByVal iPallet_ShipType As Integer, _
                                     ByVal strPalletType_SDesc As String, ByVal strBeginningChar As String) As Integer
            Dim strSvrDate, strPalletName As String
            Dim iPalletID As Integer = 0
            Dim objDataProc As DBQuery.DataProc

            Try
                strSvrDate = Format(CDate(PSS.Data.Buisness.Generic.MySQLServerDateTime()), "yyMMdd")
                strPalletName = strBeginningChar & strSvrDate & strPalletType_SDesc

                '*********************************************
                'Get Pallet next sequence number
                '*********************************************
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strPalletName = Me.GetPalletNameNextSeqNo(objDataProc, iCustID, iLocID, strPalletName, 4)

                '*********************************************
                'Create Pallet
                '*********************************************
                Return Me.CreatePallet(iCustID, iLocID, iModelID, 0, strPalletName, iPallet_ShipType, "", 0, 0, iPalletTypeID)

            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '********************************************************************************************************
        Public Function GetShipIDByPallet(ByVal iPalletID As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "select Ship_ID from tship where ShipPallett = " & iPalletID
                Return Me.objMisc.GetIntValue(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function GetOverPackIDByName(ByVal iLocID As Integer, ByVal strOverPackName As String, Optional ByVal iModelID As Integer = 0) As Integer
            Dim strSql As String = ""

            Try
                strSql = "SELECT OverPack_ID FROM toverpack WHERE Loc_ID = " & iLocID & " AND OverPack_Name = '" & strOverPackName & "'" & Environment.NewLine
                If iModelID > 0 Then strSql &= " AND Model_ID = " & Environment.NewLine
                Return Me.objMisc.GetIntValue(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function CreateOverPackWithName(ByVal iLocID As Integer, ByVal iModelID As Integer, ByVal strOverPackName As String, ByVal iPalletShipType As Integer) As Integer
            Dim strSql As String

            Try
                strSql = "INSERT INTO toverpack ( " & Environment.NewLine
                strSql += " OverPack_Name, OverPack_Process, Model_ID, Loc_ID " & Environment.NewLine
                strSql += ") VALUES ( " & Environment.NewLine
                strSql += "'" & strOverPackName & "', " & iPalletShipType & ", " & iModelID & ", " & iLocID & Environment.NewLine
                strSql += ") "

                Return Me.objMisc.idTransaction(strSql, "toverpack")
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function GetOverPackNextSeqNo(ByVal iLocID As Integer, ByVal strOverPackPreFixName As String, ByVal iNumberLength As Integer) As Integer
            Dim strSQL As String
            Dim dt As DataTable
            Dim iNextSeqNo As Integer = 1

            Try
                strSQL = "SELECT max(right(OverPack_Name, " & iNumberLength & " ) ) + 1 as NextSequenceNumber " & Environment.NewLine
                strSQL &= "FROM toverpack " & Environment.NewLine
                strSQL &= "WHERE OverPack_Name like '" & strOverPackPreFixName & "%' " & Environment.NewLine
                strSQL &= "AND Loc_ID = " & iLocID & Environment.NewLine
                dt = Me.objMisc.GetDataTable(strSQL)
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0)("NextSequenceNumber")) Then
                        iNextSeqNo = CInt(dt.Rows(0)("NextSequenceNumber"))
                    End If
                End If

                Return iNextSeqNo
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function UpdateWOStatus(ByVal strWorkDate As String, ByVal iPalletID As Integer, Optional ByVal iNoQC As Integer = 0) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim R As DataRow
            Dim i As Integer = 0

            Try
                strSql = "SELECT distinct WO_ID FROM tdevice WHERE Pallett_ID = " & iPalletID
                dt = Me.objMisc.GetDataTable(strSql)
                For Each R In dt.Rows
                    '********************************
                    'Get Device count of the devices to be shipped for a WO
                    strSql = "Select Count(*) as cnt from tdevice where wo_id = " & R("WO_ID") & " and device_dateship is null;"
                    If Me.objMisc.GetIntValue(strSql) = 0 Then
                        strSql = "UPDATE tworkorder " & Environment.NewLine
                        strSql += "SET WO_Shipped = 1, WO_DateShip = '" & strWorkDate & "', WO_NoQc = " & iNoQC & " " & Environment.NewLine
                        strSql += "WHERE WO_ID = " & R("WO_ID") & ";"
                        i += objMisc.ExecuteNonQuery(strSql)
                    End If
                Next R
                Return i
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '*******************************************************************************************************************

    End Class
End Namespace


