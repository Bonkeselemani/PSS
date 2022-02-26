Option Explicit On 

Imports CrystalDecisions.CrystalReports.Engine

Namespace Buisness
    Public Class GameStopOpt
        Private _objDataProc As DBQuery.DataProc

        '****************************************************************
        Public Sub New()
            Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
        End Sub

        '****************************************************************
        Protected Overrides Sub Finalize()
            Me._objDataProc = Nothing
            MyBase.Finalize()
        End Sub

        '****************************************************************
        Public Function GetShipPalletData(ByVal strPalletName As String, _
                                          ByVal iCount As Integer, _
                                          ByVal strResult As String, _
                                          ByVal strShipType As String, _
                                          ByVal strFooter() As String) As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT " & iCount.ToString & " AS DeviceCount, '" & strPalletName & "' AS PalletName, '" & strResult & "' AS Result, '" & strShipType & "' AS ShipType, '' AS Var, '" & strFooter(0) & "' AS Footer1, '" & strFooter(1) & "' AS Footer2, '" & strFooter(2) & "' AS Footer3"

                Return Me._objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************
        Public Function PrintPalletLabel(ByVal dtShipPalletRpt As DataTable, _
                                         ByVal iPrintQty As Integer)
            Const strReportName As String = "Ship Pallet Label Push.rpt"
            Dim objRpt As ReportDocument

            Try
                '************************************
                'Create Crystal Report
                '************************************
                If Not IsNothing(dtShipPalletRpt) Then
                    objRpt = New ReportDocument()

                    With objRpt
                        .Load(PSS.Data.ConfigFile.GetBaseReportPath & strReportName)
                        .SetDataSource(dtShipPalletRpt)
                        .PrintToPrinter(iPrintQty, True, 0, 0)
                    End With
                End If
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(objRpt) Then
                    objRpt.Dispose()
                    objRpt = Nothing
                End If
                If Not IsNothing(dtShipPalletRpt) Then
                    dtShipPalletRpt.Dispose()
                    dtShipPalletRpt = Nothing
                End If
            End Try
        End Function

        '****************************************************************
        Public Function GetPalletInfo(ByVal str_pallet As String, _
                                      ByVal iCust_ID As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT tpallett.* " & Environment.NewLine
                strSql &= ", IF(Pallet_ShipType = 0 , 'PASS', 'FAIL') as ShipType " & Environment.NewLine
                strSql &= ", Model_Desc " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tpallett.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "WHERE Pallett_Name = '" & str_pallet & "'" & Environment.NewLine
                strSql &= "AND Cust_ID = " & iCust_ID & ";"

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************
        Public Function CreateGameStopShipPallet(ByVal iLoc_ID As Integer, _
                                                ByVal iCust_ID As Integer, _
                                                ByVal strWk_Dt As String, _
                                                ByVal iModel_ID As Integer, _
                                                ByVal iShipType As Integer, _
                                                ByVal iPallett_QTY As Integer) As String
            Dim strSQL As String
            Dim dt As DataTable
            Dim strPallettName As String = ""
            Dim strModel_ShortDesc As String = ""
            Dim i As Integer = 0
            Dim strPalletResult As String = ""

            Try
                '*************************************
                'Get Model short description
                '*************************************
                strSQL = "SELECT Model_MotoSku FROM tmodel WHERE Model_ID = " & iModel_ID & ";"
                strModel_ShortDesc = Me._objDataProc.GetSingletonString(strSQL)
                If strModel_ShortDesc = "" Then
                    Throw New Exception("Can't find short description of the selected model.")
                End If

                If iShipType = 0 Then
                    strPalletResult = "P"
                Else
                    strPalletResult = "F"
                End If

                strPallettName = "GS" & strModel_ShortDesc & Format(CDate(strWk_Dt), "MMddyy")

                strSQL = "SELECT max(right(Pallett_Name, 3) ) + 1 as Pallett_Num " & Environment.NewLine
                strSQL &= "FROM tpallett " & Environment.NewLine
                strSQL &= "WHERE Pallett_Name like '" & strPallettName & "%' " & Environment.NewLine
                strSQL &= "AND Cust_ID = " & iCust_ID & Environment.NewLine
                strSQL &= "AND Loc_ID = " & iLoc_ID & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSQL)
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0)("Pallett_Num")) Then
                        strPallettName &= strPalletResult & Format(dt.Rows(0)("Pallett_Num"), "000")
                    Else
                        strPallettName &= strPalletResult & "001"
                    End If
                Else
                    strPallettName &= strPalletResult & "001"
                End If

                strSQL = "INSERT INTO tpallett (  " & Environment.NewLine
                strSQL &= "Pallett_Name,  " & Environment.NewLine
                strSQL &= "Pallett_ShipDate,  " & Environment.NewLine
                strSQL &= "Pallett_BulkShipped,  " & Environment.NewLine
                strSQL &= "Pallett_ReadyToShipFlg,  " & Environment.NewLine
                strSQL &= "Pallet_ShipType, " & Environment.NewLine
                strSQL &= "Model_ID,  " & Environment.NewLine
                strSQL &= "Pallett_QTY,  " & Environment.NewLine
                strSQL &= "Cust_ID,  " & Environment.NewLine
                strSQL &= "Loc_ID,  " & Environment.NewLine
                strSQL &= "SpecialInvProject " & Environment.NewLine
                strSQL &= ") VALUES (  " & Environment.NewLine
                strSQL &= "'" & strPallettName & "', " & Environment.NewLine
                strSQL &= "'" & strWk_Dt & "', " & Environment.NewLine
                strSQL &= "1, " & Environment.NewLine
                strSQL &= "1, " & Environment.NewLine
                strSQL &= iShipType & ", " & Environment.NewLine
                strSQL &= iModel_ID & ", " & Environment.NewLine
                strSQL &= iPallett_QTY & ",  " & Environment.NewLine
                strSQL &= iCust_ID & ", " & Environment.NewLine
                strSQL &= iLoc_ID & ", 1 );" & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSQL)

                Return strPallettName
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Function

        '*********************************************************************
        Public Function EditPalletQuantity(ByVal iPallett_ID As Integer, _
                                           ByVal iPallett_Qty As Integer) As Integer
            Dim strSQL As String

            Try
                strSQL = "UPDATE tpallett SET  " & Environment.NewLine
                strSQL &= "Pallett_QTY =   " & iPallett_Qty & " " & Environment.NewLine
                strSQL &= "WHERE Pallett_ID =  " & iPallett_ID & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSQL)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************
        Public Function DeletePallet(ByVal iPallett_ID As Integer) As Integer
            Dim strSQL As String

            Try
                strSQL = "DELETE FROM tpallett " & Environment.NewLine
                strSQL &= "WHERE Pallett_ID =  " & iPallett_ID & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSQL)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************
        Public Function GetDeviceManufDate(ByVal strSN As String) As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT tdevice.Device_ID, Device_SN as SN, tdevice.Model_ID " & Environment.NewLine
                strSQL &= ", IF(tdevice.Pallett_ID is null, '', tpallett.Pallett_Name) as ShipPallet " & Environment.NewLine
                strSQL &= ", Device_DateShip as 'Date Ship', Model_Desc as Model, WHR_ManufDateCode as 'Manufacture Date' " & Environment.NewLine
                strSQL &= "FROM tdevice " & Environment.NewLine
                strSQL &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSQL &= "INNER JOIN twarehousereceive on tdevice.Device_ID = twarehousereceive.Device_ID " & Environment.NewLine
                strSQL &= "LEFT OUTER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strSQL &= "WHERE device_sn = '" & strSN & "'" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSQL)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************
        Public Function UpdateDateCode(ByVal iDevice_ID As Integer, _
                                       ByVal strManufDate As String) As Integer
            Dim strSQL As String
            Dim iModel_ID As Integer = 0

            Try
                iModel_ID = Me.GetModelFromDateCode(strManufDate)

                strSQL = "Update tdevice, twarehousereceive " & Environment.NewLine
                strSQL &= "SET tdevice.Model_ID = " & iModel_ID & Environment.NewLine
                strSQL &= ", twarehousereceive.Model_ID = " & iModel_ID & Environment.NewLine
                strSQL &= ", twarehousereceive.WHR_ManufDateCode = '" & strManufDate & "'" & Environment.NewLine
                strSQL &= "WHERE tdevice.Device_ID = twarehousereceive.Device_ID " & Environment.NewLine
                strSQL &= "AND tdevice.Device_ID = " & iDevice_ID & "" & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSQL)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************
        Public Function GetModelFromDateCode(ByVal strDateCode As String) As Integer
            Dim iYear As Integer = 0
            Dim iMonth As Integer = 0
            Dim iModel_ID As Integer = 0

            Try
                If strDateCode = "0000" Then
                    iModel_ID = 1112
                Else
                    If Mid(strDateCode, 3, 1) = 9 Then
                        iYear = CInt("19" & Microsoft.VisualBasic.Right(strDateCode, 2))
                    Else
                        iYear = CInt("20" & Microsoft.VisualBasic.Right(strDateCode, 2))
                    End If

                    If iYear < 1997 Or iYear > Year(Now()) Then
                        Throw New Exception("Invalid manufacture year.")
                    End If

                    iMonth = CInt(Microsoft.VisualBasic.Left(strDateCode, 2))
                    If (iMonth < 12 And iYear = 2002) Or iYear < 2002 Then
                        iModel_ID = 1112
                    Else
                        iModel_ID = 881
                    End If
                End If

                Return iModel_ID
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************
        Public Function IsDateEqualThisWeek(ByVal strPallett_ShipDate As String) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim booResult As Boolean = False
            Dim strMonOfShipDate As String = ""
            Dim strMonOfNow As String = ""
            Dim strSvrTodayDate As String = ""

            Try
                strSvrTodayDate = Generic.GetWorkDate(1)
                strMonOfShipDate = Format(DateAdd(DateInterval.Day, (Weekday(CDate(strPallett_ShipDate), FirstDayOfWeek.Monday) - 1) * -1, CDate(strPallett_ShipDate)), "yyyy-MM-dd")
                strMonOfNow = Format(DateAdd(DateInterval.Day, (Weekday(CDate(strSvrTodayDate), FirstDayOfWeek.Monday) - 1) * -1, CDate(strSvrTodayDate)), "yyyy-MM-dd")
                strSql = "select week('" & strMonOfShipDate & "') as ShipWeek, week('" & strMonOfNow & "') as TodayWeek " & Environment.NewLine
                strSql &= ", Year('" & strMonOfShipDate & "') as ShipYear, Year('" & strMonOfNow & "') as TodayYear "
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.rows.count > 0 Then
                    If dt.Rows(0)("TodayWeek") = dt.Rows(0)("ShipWeek") And dt.Rows(0)("TodayYear") = dt.Rows(0)("ShipYear") Then
                        booResult = True
                    End If
                End If

                Return booResult
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '*********************************************************************
        Public Function GetPartsServicesOfDevice(ByVal iDeviceID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT tdevicebill.BillCode_ID " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tdevicebill ON  tdevice.Device_ID = tdevicebill.Device_ID " & Environment.NewLine
                strSql &= "WHERE tdevice.device_id = " & iDeviceID
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************
        Public Function UpdateCelloptWipOwner(ByVal iDeviceID As Integer, ByVal iUserID As Integer) As Integer
            Dim strSql As String = ""

            Try
                'Update wipowner to different bucket
                strSql = "UPDATE tcellopt SET cellopt_WipOwnerOld =  CellOpt_WIPOwner " & Environment.NewLine
                strSql &= ", CellOpt_WIPOwner = 4 " & Environment.NewLine
                strSql &= ", cellopt_WipEntryDt = now() " & Environment.NewLine
                strSql &= ", CellOpt_TechAssigned = " & iUserID & Environment.NewLine
                strSql &= ", cellopt_techassigndate = now() " & Environment.NewLine
                strSql &= "WHERE device_id = " & iDeviceID & ";"

                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************
        Public Function GetDevicePallett_IDInWIP(ByVal iDevice_ID As Integer) As Integer
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim iPallett_ID As Integer = 0

            Try
                strSql &= "SELECT Pallett_ID " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDevice_ID & ";"
                dt1 = Me._objDataProc.GetDataTable(strSql)

                If dt1.Rows.Count > 0 Then
                    If Not IsDBNull(dt1.Rows(0)("Pallett_ID")) Then
                        iPallett_ID = dt1.Rows(0)("Pallett_ID")
                    End If
                End If

                Return iPallett_ID
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt1)
            End Try
        End Function

        '***************************************************************
        Public Function VerifyDeviceModel(ByVal iDevice_ID As Integer, _
                                          ByVal iModel_ID As Integer) As Boolean
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim booResult As Boolean = False

            Try
                strSql &= "SELECT Model_ID " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDevice_ID & Environment.NewLine
                'strSql &= "AND Model_ID = " & iModel_ID & ";"

                dt1 = Me._objDataProc.GetDataTable(strSql)

                If dt1.Rows.Count > 0 Then
                    If (iModel_ID = 881 Or iModel_ID = 1112) And (dt1.Rows(0)("Model_ID") = 881 Or dt1.Rows(0)("Model_ID") = 1112) Then
                        booResult = True
                    ElseIf iModel_ID = dt1.Rows(0)("Model_ID") Then
                        booResult = True
                    Else
                        booResult = False
                    End If
                End If

                Return booResult
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt1)
            End Try
        End Function

        '***************************************************************
        Public Sub LoadRURSCRAPINCOMPLETEBillcodes(ByRef cmbBillBillcodes As System.Windows.Forms.ComboBox, _
                                                   ByVal iProd_ID As Integer, _
                                                   ByVal iModel_ID As Integer)
            Dim strSql As String = ""
            Dim dt1 As DataTable

            Try
                strSql &= "SELECT distinct lbillcodes.BillCode_ID, BillCode_Desc " & Environment.NewLine
                strSql &= "FROM tpsmap " & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes on tpsmap.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                strSql &= "WHERE tpsmap.Inactive = 0 " & Environment.NewLine
                strSql &= "AND Model_ID = " & iModel_ID & " " & Environment.NewLine
                strSql &= "AND Prod_ID = " & iProd_ID & Environment.NewLine
                strSql &= "AND tpsmap.billcode_ID in (874, 875, 1033);"
                dt1 = Me._objDataProc.GetDataTable(strSql)
                dt1.LoadDataRow(New Object() {"0", "-- Select --"}, False)

                '******************************************************
                'Populate the Combo Box
                With cmbBillBillcodes
                    .DataSource = dt1.DefaultView
                    .DisplayMember = dt1.Columns("BillCode_Desc").ToString
                    .ValueMember = dt1.Columns("BillCode_ID").ToString
                    .SelectedValue = 0
                End With
                '*******************************************************

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt1)
            End Try
        End Sub

        '***************************************************************
        Public Function IsGameStopDevice(ByVal strDeviceSN As String) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim booIsGameStopDevice As Boolean = False
            Dim iCnt As Integer

            Try
                strSql &= "SELECT COUNT(*) AS Cnt " & Environment.NewLine
                strSql &= "FROM tdevice A " & Environment.NewLine
                strSql &= "INNER JOIN tlocation B ON B.Loc_ID = A.Loc_ID " & Environment.NewLine
                strSql &= "WHERE B.Cust_ID = 2219 AND A.Device_DateBill IS NOT NULL AND A.Device_DateShip IS NULL AND A.Device_DateRec IS NOT NULL AND A.Device_SN = '" & strDeviceSN & "';"
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count = 1 Then
                    If Not IsDBNull(dt.Rows(0)("Cnt")) Then
                        iCnt = CInt(dt.Rows(0)("Cnt"))
                        If iCnt > 0 Then booIsGameStopDevice = True
                    End If
                End If

                Return booIsGameStopDevice
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '***************************************************************
        Public Function GameStopDeviceLotNum(ByVal strDeviceSN As String) As String
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim strLotNum As String = ""

            Try
                strSql &= "SELECT WHP_Lot " & Environment.NewLine
                strSql &= "FROM twarehousepallet A " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder B ON B.WO_RecPalletName = A.WHPallet_Number " & Environment.NewLine
                strSql &= "INNER JOIN tdevice C ON C.wo_id = B.wo_id " & Environment.NewLine
                strSql &= "WHERE C.Device_SN = '" & strDeviceSN & "' " & Environment.NewLine
                strSql &= "ORDER BY C.Device_ID DESC LIMIT 1;"
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0)("WHP_Lot")) Then strLotNum = dt.Rows(0)("WHP_Lot")
                End If

                Return strLotNum
            Catch ex As Exception
                Throw ex
            Finally
                  Generic.DisposeDT(dt)
            End Try
        End Function

        '*********************************************************************

    End Class
End Namespace
