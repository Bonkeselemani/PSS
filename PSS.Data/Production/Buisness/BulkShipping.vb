Option Explicit On 

Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.OleDb
Imports System.Text

Namespace Buisness
    Public Class BulkShipping
        Private objMisc As Production.Misc
        Public dtExcelSNs As New DataTable()
        Public dtWO As New DataTable()
        Private strsql As String = ""
        Public iLoc_ID As Integer = 0
        Public iBulkShipped As Integer = 0
        Public iShipType As Integer = 0
        Public struser As String = ""
        Public iShiftID As Integer = 0
        Public strFilePath As String = ""
        Public iPallet_ID As Integer = 0
        Public iGroup_ID As Integer = 0
        Public iCust_ID As Integer = 0
        Private _Cust_List As New ArrayList()

        
        '***************************************************
        Public Function MovePalletsFromAWPtoIntransit(ByVal iPallett_ID As Integer) As Integer
            Dim iWIPOwner As Integer = 5    'Ready To ship
            'Dim strWIPEntryDt As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")
            Dim strWIPEntryDt As String = ""
            Dim i As Integer = 0

            Try
                If iPallett_ID = 0 Then
                    Throw New Exception("Pallet not selected.")
                End If

                '*******************************************
                'STEP 1: Update WIP owner
                '*******************************************
                'Update tcellopt table
                strsql = "Update tcellopt, tdevice " & Environment.NewLine
                strsql &= "set tcellopt.Cellopt_WIPOwnerOld = Cellopt_WIPOwner, " & Environment.NewLine
                strsql &= "tcellopt.Cellopt_WIPOwner = " & iWIPOwner & ", " & Environment.NewLine        ' Group_ID = 7 for Intransit
                strsql &= "tcellopt.Cellopt_WIPEntryDt  = now() " & Environment.NewLine
                strsql &= "where tcellopt.device_id = tdevice.device_id and " & Environment.NewLine
                strsql &= "tdevice.pallett_id = " & iPallett_ID & ";"
                objMisc._SQL = strsql
                i = objMisc.ExecuteNonQuery

                '*******************************************
                'STEP 2: Update AWP Flag
                '*******************************************
                strsql = "Update tpallett " & Environment.NewLine
                strsql &= "Set tpallett.AWPFlag = 0 " & Environment.NewLine
                strsql &= "Where tpallett.Pallett_ID = " & iPallett_ID & ";"

                objMisc._SQL = strsql
                i = objMisc.ExecuteNonQuery
                '*******************************************

                Return i

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************
        Public Function GetPalletsReadyToBeShipped(ByVal iHoldStatus As Integer, _
                                                   ByVal iMachineGroup As Integer, _
                                                   Optional ByVal iCustID As Integer = 0) As DataTable
            Dim dt As DataTable

            Try
                strsql = "Select tpallett.pallett_id, " & Environment.NewLine
                strsql &= "tpallett.Pallett_Name as Pallet, " & Environment.NewLine
                strsql &= "Count(*) as 'Count', " & Environment.NewLine
                'strsql &= "if(tpallett.Pallet_ShipType=9,'RTM',if(tpallett.Pallet_ShipType=1,'RUR',if(tpallett.Pallet_ShipType=8,'SCR','REGULAR'))) as 'Ship Type', " & Environment.NewLine
                'strsql &= "if(Cust_ID=2219 and tpallett.Pallet_ShipType=9,'Incomplete',if(tpallett.Pallet_ShipType=9,'RTM',if(tpallett.Pallet_ShipType=1,'RUR',if(tpallett.Pallet_ShipType=8,'SCR',if(Cust_ID=1545 and tpallett.Pallet_ShipType=1,'DBR','REGULAR'))))) as 'Ship Type', " & Environment.NewLine
                strsql &= "if(Cust_ID=2219 and tpallett.Pallet_ShipType=9,'Incomplete',if(tpallett.Pallet_ShipType=9,'RTM',if(Cust_ID in(1545,2507,2508) and tpallett.Pallet_ShipType=1,'DBR',if(tpallett.Pallet_ShipType=8,'SCR',if(tpallett.Pallet_ShipType=1,'RUR','REGULAR'))))) as 'Ship Type', " & Environment.NewLine
                strsql &= "tpallett.Pallet_SkuLen as 'SKU Length', " & Environment.NewLine
                strsql &= "tpallett.Pallet_ShipType, " & Environment.NewLine
                strsql &= "tpallett.model_id, " & Environment.NewLine
                strsql &= "tdevice.Loc_ID, " & Environment.NewLine
                strsql &= "tworkorder.group_id, " & Environment.NewLine
                strsql &= "tpallett.Cust_ID " & Environment.NewLine
                strsql &= "FROM tpallett " & Environment.NewLine
                strsql &= "INNER JOIN tdevice on tpallett.Pallett_ID = tdevice.Pallett_ID " & Environment.NewLine
                strsql &= "INNER JOIN tworkorder on tdevice.wo_id = tworkorder.wo_id " & Environment.NewLine

                If iHoldStatus = 0 Or iHoldStatus = 1 Then
                    strsql &= "WHERE Pallett_ShipDate is null and tpallett.Pallett_ReadyToShipFlg = 1 " & Environment.NewLine
                ElseIf iHoldStatus = 2 Then
                    strsql &= "WHERE Pallett_ShipDate is not null and tpallett.Pallett_ReadyToShipFlg = 1 and tpallett.AWPFlag = 1 " & Environment.NewLine
                End If

                If iCustID > 0 Then
                    strsql &= " AND tpallett.Cust_ID = " & iCustID & Environment.NewLine
                Else
                    '****************************************************
                    'Lan added on 03/15/07. 
                    'allow users see pallets belong to machine group only 
                    If iMachineGroup = 2 Then   'CELL 1
                        strsql &= " AND (Pallett_Name like  '2%' or tpallett.Pallett_Name like 'HTC%' ) " & Environment.NewLine
                    ElseIf iMachineGroup = 3 Then  'CELL 2
                        strsql &= " AND (tpallett.Pallett_Name like 'HTC%' or tpallett.Pallett_Name like '2%' or tpallett.Pallett_Name like 'DS%' ) " & Environment.NewLine
                    ElseIf iMachineGroup = 14 Or iMachineGroup = 78 Then  'CELL 2
                        strsql &= " AND tpallett.Pallett_Name like 'GS%' " & Environment.NewLine
                    ElseIf iMachineGroup = 77 Then
                        strsql &= " AND (tpallett.Pallett_Name like 'ST%' or tpallett.Pallett_Name like 'PL%' or tpallett.Pallett_Name like 'PE%') " & Environment.NewLine
                    ElseIf iMachineGroup = SkyTel.SKYTEL_GROUPID Then  'iMachineGroup = 83 Then
                        strsql &= " AND (tpallett.Pallett_Name like 'SK%') " & Environment.NewLine
                    ElseIf iMachineGroup = SkyTel.MorrisCom_GROUPID Then '100
                        strsql &= " AND (tpallett.Pallett_Name like 'MR%') " & Environment.NewLine
                    ElseIf iMachineGroup = SkyTel.Propage_GROUPID Then '101
                        strsql &= " AND (tpallett.Pallett_Name like 'PR%') " & Environment.NewLine
                    ElseIf iMachineGroup = SkyTel.Aquis_GROUPID Then '96
                        strsql &= " AND (tpallett.Pallett_Name like 'AQ%') " & Environment.NewLine
                    Else
                        strsql &= " AND tpallett.Pallett_Name like '" & iMachineGroup & "%' " & Environment.NewLine
                    End If
                    ''****************************************************
                End If

                strsql &= "GROUP BY tpallett.Pallett_ID " & Environment.NewLine
                strsql &= "ORDER BY Pallet;"

                objMisc._SQL = strsql
                dt = objMisc.GetDataTable

                Dim dr As DataRow
                For Each dr In dt.Rows
                    If dr("Pallet_ShipType").ToString = "2" AndAlso (dr("Cust_ID").ToString = "1545" OrElse dr("Cust_ID").ToString = "2507" OrElse dr("Cust_ID").ToString = "2508") Then
                        dr.BeginEdit() : dr("Ship Type") = "NER" : dr.EndEdit()
                    End If
                Next dr
                dt.AcceptChanges()
                '*************************************************

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        Private Sub ResetTransfers(ByVal iHoldStatus As Integer, ByVal iMachineGroup As Integer)
            ' Check for cellular devices whose WIP ownership was transferred and transfer them back to the original owner.
            Dim dt As DataTable
            Dim dr As DataRow
            Dim iDeviceID As Integer
            Dim wott As PSS.Data.Buisness.WIPOwnershipTempTransfer

            Try
                strsql = "SELECT B.Device_ID AS DeviceID " & Environment.NewLine
                strsql &= "FROM tpallett A " & Environment.NewLine
                strsql &= "INNER JOIN tdevice B ON A.Pallett_ID = B.Pallett_ID " & Environment.NewLine
                strsql &= "INNER JOIN tworkorder C ON B.wo_id = C.wo_id " & Environment.NewLine

                If iHoldStatus = 0 Or iHoldStatus = 1 Then
                    strsql &= "WHERE A.Pallett_ShipDate IS NULL AND A.Pallett_ReadyToShipFlg = 1 " & Environment.NewLine
                ElseIf iHoldStatus = 2 Then
                    strsql &= "WHERE A.Pallett_ShipDate IS NOT NULL AND A.Pallett_ReadyToShipFlg = 1 AND A.AWPFlag = 1 " & Environment.NewLine
                End If

                If iMachineGroup = 2 Then   'CELL 1
                    strsql &= " AND A.Pallett_Name LIKE '1%' " & Environment.NewLine
                ElseIf iMachineGroup = 3 Then  'CELL 2
                    strsql &= " AND A.Pallett_Name LIKE '2%' " & Environment.NewLine
                ElseIf iMachineGroup = 14 Then  'CELL 2
                    strsql &= " AND A.Pallett_Name LIKE 'GS%' " & Environment.NewLine
                End If

                strsql &= "AND C.WO_ID_Original IS NOT NULL"

                objMisc._SQL = strsql
                dt = objMisc.GetDataTable

                If Not IsNothing(dt) Then
                    If dt.Rows.Count > 0 Then
                        wott = New PSS.Data.Buisness.WIPOwnershipTempTransfer()

                        For Each dr In dt.Rows
                            iDeviceID = CInt(dr("DeviceID"))

                            If iDeviceID > 0 Then wott.DeviceShipped(iDeviceID)
                        Next
                    End If
                End If
            Catch ex As Exception
                Throw ex
            Finally
                strsql = ""
            End Try
        End Sub

        '***************************************************
        Public Function PrintExcelFile(ByVal strPath As String, _
                                       Optional ByVal iNoOfCopies As Integer = 1) As Integer
            Dim objXL As Excel.Application
            Dim objSheet As Excel.Worksheet

            Try
                objXL = New Excel.Application()
                objXL.Workbooks.Open(strPath)
                objSheet = objXL.Worksheets.Item(1)               'Select a Sheet 1 for this
                objXL.Visible = True
                'objSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape
                objXL.ActiveWindow.SelectedSheets.PrintOut(Copies:=iNoOfCopies, Collate:=True)
                Return 1
            Catch ex As Exception
                Throw New Exception("Buisness.BulkShipping.PrintExcelFile: " & ex.Message.ToString)
            Finally
                'Excel clean up
                If Not IsNothing(objXL) Then
                    objXL.Quit()
                    NAR(objXL)
                    objXL = Nothing
                End If
                If Not IsNothing(objSheet) Then
                    NAR(objSheet)
                    objSheet = Nothing
                End If

                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function
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
        'This updates the repair status
        '***************************************************
        Public Function UpdateRepairStatus(ByVal iDevice_ID As Integer) As Integer
            Dim i As Integer
            Dim iDcode_ID As Integer = 587      'SHIPPED REPAIR STATUS
            Try
                strsql = "update tdevicecodes inner join lcodesdetail on tdevicecodes.Dcode_ID = lcodesdetail.Dcode_id " & Environment.NewLine
                strsql += "set tdevicecodes.dcode_id = " & iDcode_ID & Environment.NewLine
                strsql += " where device_id = " & iDevice_ID & " and " & Environment.NewLine
                strsql += "mcode_id = 10;"
                objMisc._SQL = strsql
                Return objMisc.ExecuteNonQuery()
                '*************************************************
            Catch ex As Exception
                Throw New Exception("Buisness.BulkShipping.UpdateRepairStatus: " & ex.Message.ToString)
            Finally
                strsql = ""
            End Try
        End Function

        '***************************************************
        'Flags the work order ready to be shipped if all devices 
        'for the WO are shipped
        '***************************************************
        Public Function UpdateWOStatus(ByVal strWorkDate As String, Optional ByVal iNoQC As Integer = 0) As Integer
            Dim dt1 As DataTable
            Dim R, R1 As DataRow
            Dim i As Integer = 0

            Try
                For Each R In dtWO.Rows
                    '********************************
                    'Get Device count of the devices to be shipped for a WO
                    objMisc._SQL = "Select Count(*) as cnt from tdevice where wo_id = " & R("WO_ID") & " and device_dateship is null;"
                    dt1 = objMisc.GetDataTable
                    R1 = dt1.Rows(0)
                    '********************************
                    If R1("cnt") <= 0 Then
                        strsql = "Update tworkorder " & Environment.NewLine
                        strsql += "set WO_Shipped = 1, WO_DateShip = '" & strWorkDate & "', WO_NoQc = " & iNoQC & " " & Environment.NewLine
                        strsql += "where WO_ID = " & R("WO_ID") & ";"
                        objMisc._SQL = strsql
                        i += objMisc.ExecuteNonQuery()
                    End If
                Next R
                Return i
            Catch ex As Exception
                Throw New Exception("Buisness.BulkShipping.UpdateWOStatus: " & ex.Message.ToString)
            Finally
                strsql = ""
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function
        '***************************************************
        'This create a new MasterPack
        '***************************************************
        Public Function CreateMasterPack(ByVal iOverPack_ID As Integer, ByVal iPallettID As Integer, ByVal iProdID As Integer, Optional ByVal iShipToID As Integer = 0) As Integer

            Try
                strsql = "insert into tship " & Environment.NewLine
                strsql &= "(ship_user, Prod_ID, OverPack_ID " & Environment.NewLine
                If iShipToID > 0 Then strsql &= ", ShipTo_ID " & Environment.NewLine
                strsql &= ") " & Environment.NewLine
                strsql &= "values ('" & struser & "', " & iProdID & ", " & iOverPack_ID & Environment.NewLine
                If iShipToID > 0 Then strsql &= ", " & iShipToID & Environment.NewLine
                strsql &= ");"
                Return objMisc.idTransaction(strsql, "tship")
            Catch ex As Exception
                Throw New Exception("Buisness.BulkShipping.CreateMasterPack: " & ex.Message.ToString)
            Finally
                strsql = ""
            End Try
        End Function

        '***************************************************
        Public Function CreateOverPack(ByVal strWorkDate As String) As Integer

            If iPallet_ID = 0 Then
                Throw New Exception("Pallet ID is missing")
            End If

            strsql = "insert into toverpack " & Environment.NewLine
            strsql += "(Overpack_shipdate, Pallett_ID, Overpack_Process) " & Environment.NewLine
            strsql += "values ('" & strWorkDate & "', " & iPallet_ID & ", " & iShipType & ");"

            Try
                Return objMisc.idTransaction(strsql, "toverpack")
            Catch ex As Exception
                Throw New Exception("Buisness.BulkShipping.CreateOverPack: " & ex.Message.ToString)
            Finally
                strsql = ""
            End Try
        End Function

        '********************************************
        Public Function UpdatePalletShipStatus(ByVal iHoldStatus As Integer, _
                                               ByVal iPallettQty As Integer, _
                                               ByVal strWorkDate As String) As Integer
            Try
                strsql = "UPDATE tpallett " & Environment.NewLine
                strsql &= "SET Pallett_ShipDate = '" & strWorkDate & "', " & Environment.NewLine
                strsql &= "Pallett_BulkShipped = " & iBulkShipped & ", " & Environment.NewLine
                strsql &= "AWPFlag = " & iHoldStatus & ", " & Environment.NewLine
                strsql &= "LOC_ID = " & iLoc_ID & ", " & Environment.NewLine
                strsql &= "Pallett_QTY = " & iPallettQty & " " & Environment.NewLine
                strsql &= "WHERE pallett_id = " & iPallet_ID & ";"
                objMisc._SQL = strsql
                Return objMisc.ExecuteNonQuery
            Catch ex As Exception
                Throw New Exception("Buisness.BulkShipping.UpdatePalletShipStatus :: " & ex.Message.ToString)
            Finally
                strsql = ""
            End Try
        End Function

        '***************************************************
        'Update Device table
        '***************************************************
        Public Function UpdateDevice(ByVal iDevice_ID As Integer, _
                                    ByVal iProdID As Integer, _
                                    ByVal iShip_ID As Integer, _
                                    ByVal iWipOwner_ID As Integer, _
                                    ByVal strWorkdate As String, _
                                    Optional ByVal iFinishedGoodsFlg As Integer = 1) As Integer

            'Dim strShipDate As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")
            Dim strShipDate As String = ""
            Dim i As Integer = 0

            Try
                '*****************************************
                'Update tdevice table
                strsql = "Update tdevice " & Environment.NewLine
                strsql += "set Ship_ID = " & iShip_ID & ", " & Environment.NewLine
                strsql += "Shift_ID_Ship = " & iShiftID & ", " & Environment.NewLine
                strsql += "Device_SendClaim = 0, " & Environment.NewLine
                strsql += "Device_DateShip = now(), " & Environment.NewLine
                strsql += "Device_ShipWorkDate = '" & strWorkdate & "', " & Environment.NewLine
                strsql += "Device_FinishedGoods = " & iFinishedGoodsFlg & " " & Environment.NewLine
                strsql += "where device_id = " & iDevice_ID & ";"
                objMisc._SQL = strsql
                i = objMisc.ExecuteNonQuery

                '*****************************************
                If iWipOwner_ID > 0 Then
                    If iProdID = 1 Then
                        Generic.SetTmessdataWipOwnerdataForDevices(iDevice_ID, iWipOwner_ID, 0, 0)
                    Else
                        'Update tcellopt table
                        strsql = "Update tcellopt " & Environment.NewLine
                        strsql += "set Cellopt_WIPOwnerOld = Cellopt_WIPOwner, " & Environment.NewLine
                        strsql += "Cellopt_WIPOwner = " & iWipOwner_ID.ToString & ", " & Environment.NewLine        ' Ready Toship
                        strsql += "Cellopt_WIPEntryDt  = now() " & Environment.NewLine
                        strsql += "where device_id = " & iDevice_ID & ";"
                        objMisc._SQL = strsql
                        Return objMisc.ExecuteNonQuery
                    End If
                End If
                Return i
            Catch ex As Exception
                Throw New Exception("Buisness.BulkShipping.UpdateDevice: " & ex.Message.ToString)
            Finally
                strsql = ""
            End Try
        End Function

        '********************************************
        'BulkShip
        '********************************************
        Public Function BulkShip(ByVal booPrintRpt As Boolean, _
                                 ByVal iHoldStatus As Integer, _
                                 ByVal iPallettQty As Integer, _
                                 Optional ByVal iNoOfManifestCopies As Integer = 1, _
                                 Optional ByVal iUpdateRepairStatus As Integer = 1, _
                                 Optional ByVal iWIPOwner As Integer = 5, Optional ByRef dt As DataTable = Nothing) As Integer

            'Dim iPallet_ID As Integer = 0
            Dim iOverpack_ID, iShip_ID, i, j, iProdID As Integer
            Dim R1 As DataRow
            Dim strWorkDate As String = ""
            Dim dtProdID As DataTable

            Try
                If iPallet_ID = 0 Then Throw New Exception("Pallet ID missing.")
                dtProdID = GetProdIDInPallet(iPallet_ID)
                If dtProdID.Rows.Count = 1 Then iProdID = CInt(dtProdID.Rows(0)("Prod_ID")) Else iProdID = 0
                '***************************************************
                ''Step :: Define work date
                '***************************************************
                If Me.iShiftID = 0 Then Throw New Exception("System can't define shift ID.")
                strWorkDate = Generic.GetWorkDate(Me.iShiftID)
                If strWorkDate.Trim.Length = 0 Then Throw New Exception("System can't define work date.")
                '****************************************************************************
                ''Step 2:: Create Overpack
                '****************************************************************************
                iOverpack_ID = CreateOverPack(strWorkDate)
                '****************************************************************************
                ''Step 3:: Create Masterpack
                '****************************************************************************
                iShip_ID = CreateMasterPack(iOverpack_ID, iPallet_ID, iProdID, )
                '****************************************************************************
                If Me._Cust_List.Contains(Me.iCust_ID) Then
                    For Each R1 In dt.Rows
                        '*************************************
                        ''Step 4:: Update tdevice table
                        '*************************************
                        i += UpdateDevice(R1("Device_id"), iProdID, iShip_ID, iWIPOwner, strWorkDate, )
                        '*************************************
                        ''Step 5:: Update Repair Status
                        'exclude Skytel 
                        '*************************************
                        If iUpdateRepairStatus > 0 Then j = UpdateRepairStatus(R1("Device_id"))
                        '*************************************
                    Next R1
                Else
                    For Each R1 In dtExcelSNs.Rows
                        '*************************************
                        ''Step 4:: Update tdevice table
                        '*************************************
                        i += UpdateDevice(R1("Device_id"), iProdID, iShip_ID, iWIPOwner, strWorkDate, )
                        '*************************************
                        ''Step 5:: Update Repair Status
                        'exclude Skytel 
                        '*************************************
                        If iUpdateRepairStatus > 0 Then j = UpdateRepairStatus(R1("Device_id"))
                        '*************************************
                    Next R1
                End If
                '*************************************
                ''Step 6:: Close out workorders if any.
                '*************************************
                j = UpdateWOStatus(strWorkDate)
                '*************************************
                ''Step 7:: Update Pallet Ship Status
                '*************************************
                j = UpdatePalletShipStatus(iHoldStatus, iPallettQty, strWorkDate)
                '*************************************
                ''Step 8:: Print Label (Ship_PalletLabel_ATCLE)
                '*************************************
                '''''''''''''PrintShippingPalletLabelRpt(iPallet_ID)
                '*************************************
                ''Step 9:: Print Report (Exel)
                '*************************************
                If booPrintRpt = True AndAlso Me.iCust_ID <> TracFone.BuildShipPallet.TracFone_CUSTOMER_ID Then
                    If iGroup_ID = 14 Then iNoOfManifestCopies = 2
                    j = PrintExcelFile(strFilePath, iNoOfManifestCopies)
                End If

                '****************************************************************************

                Return i
            Catch ex As Exception
                Throw New Exception("Buisness.BulkShipping.BulkShip(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                R1 = Nothing : Generic.DisposeDT(dtProdID)
            End Try
        End Function

        '********************************************
        Public Function GetSKU(ByVal strColName As String) As Integer
            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim R1, R2 As DataRow
            Dim i As Integer = 0

            Try
                For Each R1 In dtExcelSNs.Rows
                    '***************************
                    strsql = ""
                    strsql = "SELECT Device_SN, Device_daterec, SKU_Number " & Environment.NewLine
                    strsql &= "FROM tdevice " & Environment.NewLine
                    strsql &= "INNER JOIN tsku on tdevice.sku_id = tsku.sku_id " & Environment.NewLine
                    strsql &= "WHERE device_sn = '" & Trim(R1(strColName)) & "' " & Environment.NewLine
                    strsql += " AND tdevice.loc_id = " & iLoc_ID & Environment.NewLine
                    strsql += " AND device_dateship is null AND Device_Datebill is not null AND Device_datebill <> '0000-00-00 00:00:00' AND device_invoice = 0 " & Environment.NewLine
                    strsql += " Order by Device_daterec Desc;"

                    objMisc._SQL = strsql
                    dt1 = objMisc.GetDataTable

                    If dt1.Rows.Count = 0 Then
                        Throw New Exception("No devices found for the criterion.")
                    Else
                        R2 = dt1.Rows(0)
                        R1("SKU_Number") = R2("SKU_Number")
                        R1.AcceptChanges()
                        dtExcelSNs.AcceptChanges()
                        i += 1
                    End If

                    '***************************
                    If Not IsNothing(dt1) Then
                        dt1.Dispose()
                        dt1 = Nothing
                    End If
                    '***************************
                Next R1

                Return i
            Catch ex As Exception
                Throw New Exception("Buisness.BulkShipping.GetSKU(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                R1 = Nothing
                R2 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function


        '********************************************
        Public Function GetModel() As Integer
            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim R1, R2, R3 As DataRow
            Dim i As Integer = 0
            Dim ColNew As DataColumn
            Dim iWOExists As Integer = 0
            Dim NewRow As DataRow

            Try
                '***********************************************
                'Add WO_ID column to dtWO datatable
                '***********************************************
                If Not IsNothing(dtWO) Then
                    dtWO.Dispose()
                    dtWO = Nothing
                End If
                dtWO = New DataTable() '("WO")
                ColNew = New DataColumn("WO_ID")
                ColNew.DataType = System.Type.GetType("System.Int32")
                dtWO.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing
                '***********************************************

                Select Case iCust_ID
                    Case 2019, 2258      'ATCLE, TracFone
                        '***********************************************
                        For Each R1 In dtExcelSNs.Rows
                            i += ChechkModel(R1, R1("IMEI").ToString.Trim)
                        Next R1
                    Case 2113      'Brightpoint
                        '***********************************************
                        For Each R1 In dtExcelSNs.Rows
                            '***************************
                            i += ChechkModel(R1, R1("SN").ToString.Trim)
                        Next R1
                    Case 2219      'gamestop
                        '***********************************************
                        For Each R1 In dtExcelSNs.Rows
                            i += ChechkModel(R1, R1("Serial").ToString.Trim)
                        Next R1
                    Case 2238      'Trimble Mobile Solutions
                        '***********************************************
                        For Each R1 In dtExcelSNs.Rows
                            i += ChechkModel(R1, R1("SN").ToString.Trim)
                        Next R1

                    Case 2245      'Liquidity Services/Dyscern
                        '***********************************************
                        For Each R1 In dtExcelSNs.Rows
                            i += ChechkModel(R1, R1("IMEI").ToString.Trim)
                        Next R1

                    Case 2242, 2254, 2259, 2278     'Sonitrol, Plexus, PSS Exchange, Advantor Systems/Infrasafe
                        '***********************************************
                        For Each R1 In dtExcelSNs.Rows
                            i += ChechkModel(R1, R1("SN").ToString.Trim)
                        Next R1
                    Case 2249     'Demo
                        '***********************************************
                        For Each R1 In dtExcelSNs.Rows
                            i += ChechkModel(R1, R1("IMEI"))
                        Next R1
                    Case SkyTel.SKYTEL_CUSTOMER_ID, SkyTel.MorrisCom_CUSTOMER_ID, _
                         SkyTel.Propage_CUSTOMER_ID, SkyTel.Aquis_CUSTOMER_ID, SkyTel.CookPager_CUSTOMER_ID, _
                         SkyTel.ContactWireless_CUSTOMER_ID, SkyTel.A1WirelessComm_CUSTOMER_ID, SkyTel.AMS_CUSTOMER_ID, _
                         SkyTel.CriticalAlert_CUSTOMER_ID, SkyTel.Anna_CUSTOMER_ID, SkyTel.Lahey_CUSTOMER_ID, _
                           SkyTel.Masco_CUSTOMER_ID, SkyTel.Franciscan_CUSTOMER_ID, SkyTel.Maine_CUSTOMER_ID, _
                           SkyTel.SMHC_CUSTOMER_ID, SkyTel.ATS_CUSTOMER_ID

                        'HTC, SkyTel,MorrisCom, Propage
                        For Each R1 In dtExcelSNs.Rows
                            i += ChechkModel(R1, R1("SN"))
                        Next R1
                    Case Else
                        Throw New Exception("Cust_ID in tpallett needs to be updated.")
                End Select

                Return i
            Catch ex As Exception
                Throw New Exception("Buisness.BulkShipping.GetModel(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                R1 = Nothing
                R2 = Nothing
                R3 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '********************************************
        Public Function ChechkModel(ByRef drDevice As DataRow, _
                                     ByVal strSN As String) As Integer
            Dim strSql As String
            Dim dt1 As DataTable
            Dim R2, R3, NewRow As DataRow
            Dim iWOExists As Integer
            Dim i As Integer = 0
            Try
                '***************************
                strSql = "SELECT Device_id, Device_SN, Device_daterec, tdevice.Model_ID, wo_id " & Environment.NewLine
                strSql &= ", if(tcustmodel_pssmodel_map.cust_model_number is null, tmodel.Model_Desc, tcustmodel_pssmodel_map.cust_model_number ) as 'Model_Desc' " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.model_id = tmodel.model_id " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tcustmodel_pssmodel_map ON tdevice.model_id = tcustmodel_pssmodel_map.model_id AND tcustmodel_pssmodel_map.Cust_ID = " & Me.iCust_ID & Environment.NewLine
                strSql &= "WHERE device_sn = '" & strSN.Trim & "' " & Environment.NewLine
                strSql &= " AND tdevice.loc_id = " & iLoc_ID & Environment.NewLine
                strSql &= " AND device_dateship is null and device_invoice = 0 " & Environment.NewLine
                strSql &= " Order by Device_daterec Desc;"

                objMisc._SQL = strSql
                dt1 = objMisc.GetDataTable

                'If booVerifyShipped = False Then        'validations for first time shipments
                If dt1.Rows.Count = 0 Then
                    Throw New Exception("No devices found for the criterion(validate model).")
                ElseIf dt1.Rows.Count > 1 Then  'This checks if Serial Number (IMEI) exists more than once with unshipped status
                    Throw New Exception("'" & strSN.Trim & "' Serial Number (IMEI) exists more than once with unshipped status.")
                ElseIf dt1.Rows.Count = 1 Then
                    R2 = dt1.Rows(0)
                    drDevice("Model_ID") = R2("Model_ID")
                    drDevice("Model_Desc") = R2("Model_Desc")
                    drDevice("device_id") = R2("device_id")
                    drDevice("wo_id") = R2("wo_id")
                    drDevice.AcceptChanges()
                    dtExcelSNs.AcceptChanges()
                    i += 1
                End If

                '***************************
                'Get distinct workorders
                If dtWO.Rows.Count > 0 Then
                    iWOExists = 0
                    For Each R3 In dtWO.Rows
                        If drDevice("WO_ID") = R3("WO_ID") Then
                            iWOExists = 1
                        End If
                    Next R3
                    If iWOExists = 0 Then
                        NewRow = dtWO.NewRow()
                        NewRow("WO_ID") = drDevice("WO_ID")
                        dtWO.Rows.Add(NewRow)
                        NewRow = Nothing
                    End If
                Else
                    NewRow = dtWO.NewRow()
                    NewRow("WO_ID") = drDevice("WO_ID")
                    dtWO.Rows.Add(NewRow)
                    NewRow = Nothing
                End If
                '***************************

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                NewRow = Nothing
                R2 = Nothing
                R3 = Nothing
                Generic.DisposeDT(dt1)
            End Try
        End Function

        '********************************************
        Public Function GetBillcodeRule() As Integer
            Dim strsql As String = ""
            Dim dt1, dtNTF As DataTable
            Dim R1, R2, R3, row As DataRow
            Dim i As Integer = 0
            Dim objTFMisc As New PSS.Data.Buisness.TracFone.clsMisc()

            Try
                For Each R1 In dtExcelSNs.Rows

                    Select Case iCust_ID
                        Case 2019      'ATCLE
                            i += Me.CheckBillcodeRule(R1, Trim(R1("IMEI")), False)
                        Case 2113      'Brightpoint
                            i += Me.CheckBillcodeRule(R1, Trim(R1("SN")), False)
                        Case 2219      'gamestop
                            i += Me.CheckBillcodeRule(R1, Trim(R1("Serial")), False)
                        Case 2238      'Trimble Mobile Solutions
                            i += Me.CheckBillcodeRule(R1, Trim(R1("SN")), False)
                        Case 2245      'Liquidity Services/Dyscern
                            i += Me.CheckBillcodeRule(R1, Trim(R1("IMEI")), False)
                        Case 2242, 2254, 2259, 2278    'Sonitrol, Plexus Corp., PSS Exchange, Advantor Systems/Infrasafe
                            i += Me.CheckBillcodeRule(R1, Trim(R1("SN")), True)
                        Case 2249   'Demo
                            R1("BillCode_Rule") = 0
                            R1.AcceptChanges()
                            dtExcelSNs.AcceptChanges()
                            i += 1
                        Case SkyTel.SKYTEL_CUSTOMER_ID, SkyTel.MorrisCom_CUSTOMER_ID, _
                             SkyTel.Propage_CUSTOMER_ID, SkyTel.Aquis_CUSTOMER_ID, SkyTel.CookPager_CUSTOMER_ID, _
                             SkyTel.ContactWireless_CUSTOMER_ID, SkyTel.A1WirelessComm_CUSTOMER_ID, SkyTel.AMS_CUSTOMER_ID, _
                             SkyTel.CriticalAlert_CUSTOMER_ID, SkyTel.Anna_CUSTOMER_ID, SkyTel.Lahey_CUSTOMER_ID, _
                             SkyTel.Masco_CUSTOMER_ID, SkyTel.Franciscan_CUSTOMER_ID, SkyTel.Maine_CUSTOMER_ID, _
                             SkyTel.SMHC_CUSTOMER_ID, SkyTel.ATS_CUSTOMER_ID
                            i += Me.CheckBillcodeRule(R1, Trim(R1("SN")), False)
                        Case TracFone.BuildShipPallet.TracFone_CUSTOMER_ID
                            dtNTF = objTFMisc.GetNTFDeviceID(R1("Device_ID"), TracFone.BuildShipPallet.TracFone_CUSTOMER_ID)
                            If Not dtNTF.Rows.Count > 0 Then
                                i += Me.CheckBillcodeRule(R1, Trim(R1("IMEI")), True)
                            Else
                                i += 1
                            End If
                        Case Else
                            Throw New Exception("Cust_ID in tpallett needs to be updated.")
                    End Select

                    Generic.DisposeDT(dt1)
                    '***************************
                Next R1

                Return i
            Catch ex As Exception
                Throw New Exception("Buisness.BulkShipping.GetBillcodeRule(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                R1 = Nothing
                R2 = Nothing
                Generic.DisposeDT(dt1)
            End Try
        End Function

        '********************************************
        Public Function CheckBillcodeRule(ByRef drDevice As DataRow, _
                                          ByVal strSN As String, _
                                          ByVal booAllowRURHasParts As Boolean) As Integer
            Dim strSql As String
            Dim dt1 As DataTable
            Dim R2, R3 As DataRow
            Dim i As Integer = 0

            Try
                '***************************
                strSql = ""
                strSql = "Select tdevice.device_id, tdevice.device_sn, lbillcodes.BillCode_Rule, lbillcodes.billtype_id " & Environment.NewLine
                strSql += "from tdevice " & Environment.NewLine
                strSql += "inner join tdevicebill on tdevice.Device_ID = tdevicebill.Device_ID " & Environment.NewLine
                strSql += "inner join lbillcodes on tdevicebill.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                strSql += "where tdevice.device_sn = '" & strSN & "' " & Environment.NewLine
                strSql += " and tdevice.loc_id = " & Me.iLoc_ID & Environment.NewLine
                strSql += " and device_dateship is null and Device_Datebill is not null and Device_datebill <> '0000-00-00 00:00:00' and device_invoice = 0 " & Environment.NewLine
                strSql += " Order by Device_daterec Desc, Billcode_rule desc;"
                objMisc._SQL = strSql
                dt1 = objMisc.GetDataTable

                If dt1.Rows.Count = 0 Then
                    If Me.iCust_ID = 2258 AndAlso Me.iShipType > 0 Then
                        drDevice("BillCode_Rule") = Me.iShipType
                    Else
                        Throw New Exception("Device (" & strSN & ") not billed or already shipped or just does not exist in the database.")
                    End If
                Else
                    R2 = dt1.Rows(0)    'Take the first row only (Highest billcode_rule will be at the top)
                    drDevice("BillCode_Rule") = R2("BillCode_Rule")

                    If booAllowRURHasParts = False Then
                        'Check if RUR/RTM devices have any parts still billed to them
                        If R2("BillCode_Rule") <> 0 AndAlso R2("BillCode_Rule") <> 4 AndAlso R2("BillCode_Rule") <> 6 AndAlso R2("BillCode_Rule") <> 7 Then
                            For Each R3 In dt1.Rows
                                If R3("BillType_ID") = 2 Then drDevice("RURRTMHasParts") = "1"
                            Next R3
                        End If
                    End If

                    If Me.iCust_ID = 2258 AndAlso drDevice("BillCode_Rule") <> Me.iShipType Then drDevice("BillCode_Rule") = Me.iShipType

                    drDevice.AcceptChanges()
                    dtExcelSNs.AcceptChanges()
                    i += 1
                End If

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                R2 = Nothing
                R3 = Nothing
                Generic.DisposeDT(dt1)
            End Try
        End Function

        '********************************************
        Public Function ExtractSNs(Optional ByVal iShipped As Integer = 1) As Integer
            Dim sConnectionstring As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strFilePath & ";Extended Properties=Excel 8.0;"
            Dim objConn As New OleDbConnection()
            Dim objCmdSelect As New OleDbCommand()
            Dim objAdapter1 As New OleDbDataAdapter()
            Dim strsql1 As String = ""

            Dim R, R1 As DataRow
            Dim dt1 As DataTable
            Dim strDeviceSNs As String = ""
            Dim i As Integer = 1

            Try
                '***********************************
                'Added by Lan on 03/15/07
                'prevent user from ship open pallet
                '***********************************
                strsql1 = "select Pallett_ReadyToShipFlg  from tpallett where Pallett_id = " & iPallet_ID & ";"
                Me.objMisc._SQL = strsql1
                dt1 = Me.objMisc.GetDataTable
                If dt1.Rows.Count > 0 Then
                    If dt1.Rows(0)("Pallett_ReadyToShipFlg") = 0 Then
                        Throw New Exception("This Pallet may have been reopened. Please close this screen and reopen it.")
                    End If
                Else
                    Throw New Exception("Pallet does not exist.")
                End If
                '***********************************
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                If Not IsNothing(dtExcelSNs) Then
                    dtExcelSNs.Dispose()
                    dtExcelSNs = Nothing
                End If
                '***********************************
                Select Case iCust_ID
                    Case 2019, 2258     'ATCLE
                        dtExcelSNs = New DataTable()
                        objConn.ConnectionString = sConnectionstring
                        objConn.Open()
                        objCmdSelect.CommandText = ("SELECT IMEI, '' as BillCode_Rule, '' as Model_ID, '' as Model_Desc, '' as SKU_Number, '' as RURRTMHasParts, 0 as device_id, 0 as wo_id FROM [Sheet1$] where [IMEI] is not NULL order by [IMEI]")
                        objCmdSelect.Connection = objConn
                        objAdapter1.SelectCommand = objCmdSelect
                        objAdapter1.Fill(dtExcelSNs)
                        '***************************************
                        'Checks if the Excel file has duplicate IMEIs
                        '***************************************

                        If iShipped = 1 Then
                            strsql = "Select distinct Device_SN from tdevice where device_dateship is null and device_sn in ("
                        Else
                            strsql = "Select distinct Device_SN from tdevice where device_sn in ("
                        End If

                        For Each R In dtExcelSNs.Rows
                            '******************************************
                            'Check if the Device exists in the database
                            If iShipped = 1 Then
                                objMisc._SQL = "Select Count(*) cnt from tdevice where device_sn = '" & Trim(R("IMEI")) & "' and device_datebill is not null and device_datebill <> '0000-00-00 00:00:00' and device_dateship is null;"
                            Else
                                objMisc._SQL = "Select Count(*) cnt from tdevice where device_sn = '" & Trim(R("IMEI")) & "' order by Device_id desc;"
                            End If

                            dt1 = objMisc.GetDataTable
                            R1 = dt1.Rows(0)
                            If R1("cnt") = 0 Then
                                Throw New Exception("Device Serial Number (IMEI: " & Trim(R("IMEI")) & ") either is not billed or is already shipped or just does not exist in the database.")
                            End If

                            If Not IsNothing(dt1) Then
                                dt1.Dispose()
                                dt1 = Nothing
                            End If
                            '******************************************
                            'Match the Pallett
                            If iShipped = 1 Then
                                objMisc._SQL = "Select Pallett_ID from tdevice where device_sn = '" & Trim(R("IMEI")) & "' and (Device_Dateship is NULL or trim(Device_dateship) = '' or Device_dateship = '0000-00-00 00:00:00') order by Device_id desc;"
                            Else
                                objMisc._SQL = "Select Pallett_ID from tdevice where device_sn = '" & Trim(R("IMEI")) & "' order by Device_id desc;"
                            End If

                            dt1 = objMisc.GetDataTable
                            R1 = dt1.Rows(0)
                            If R1("Pallett_ID") <> iPallet_ID Then
                                Throw New Exception("Device Serial Number (IMEI: " & Trim(R("IMEI")) & ") does not belong to Pallet selected.")
                            End If
                            '******************************************
                            If i <> dtExcelSNs.Rows.Count Then
                                If Not IsDBNull(R("IMEI")) Then
                                    strDeviceSNs += "'" & Trim(R("IMEI")) & "',"
                                End If
                            Else
                                If Not IsDBNull(R("IMEI")) Then
                                    strDeviceSNs += "'" & Trim(R("IMEI")) & "'"
                                End If
                            End If
                            i += 1
                        Next R
                        strsql += strDeviceSNs & ");"

                    Case 2113      'Brightpoint
                        dtExcelSNs = New DataTable()
                        objConn.ConnectionString = sConnectionstring
                        objConn.Open()
                        objCmdSelect.CommandText = ("SELECT SN, '' as BillCode_Rule, '' as Model_ID, '' as Model_Desc, '' as SKU_Number, '' as RURRTMHasParts, 0 as device_id, 0 as wo_id FROM [Sheet1$] where [SN] is not NULL order by [SN]")
                        objCmdSelect.Connection = objConn
                        objAdapter1.SelectCommand = objCmdSelect
                        objAdapter1.Fill(dtExcelSNs)
                        '***************************************
                        'Checks if the Excel file has duplicate SNs
                        '***************************************
                        If iShipped = 1 Then
                            strsql = "Select distinct Device_SN from tdevice where device_dateship is null and device_sn in ("
                        Else
                            strsql = "Select distinct Device_SN from tdevice where and device_sn in ("
                        End If

                        For Each R In dtExcelSNs.Rows
                            '''If Trim(R("SN")) = "356862007331096" Then
                            '''    MsgBox("Stop")
                            '''End If
                            '******************************************
                            'Check if the Device exists in the database
                            If iShipped = 1 Then
                                objMisc._SQL = "Select Count(*) cnt from tdevice where device_sn = '" & Trim(R("SN")) & "' and device_datebill is not null and device_datebill <> '0000-00-00 00:00:00' and device_dateship is null;"
                            Else
                                objMisc._SQL = "Select Count(*) cnt from tdevice where device_sn = '" & Trim(R("SN")) & "' order by Device_id desc;"
                            End If

                            dt1 = objMisc.GetDataTable
                            R1 = dt1.Rows(0)
                            If R1("cnt") = 0 Then
                                Throw New Exception("Device Serial Number (SN: " & Trim(R("SN")) & ") either is not billed or is already shipped or just does not exist in the database.")
                            ElseIf R1("cnt") > 1 Then
                                Throw New Exception("Device Serial Number (SN: " & Trim(R("SN")) & ") exists twice without a ship date.")
                            End If

                            If Not IsNothing(dt1) Then
                                dt1.Dispose()
                                dt1 = Nothing
                            End If
                            '******************************************
                            'Match the Pallett
                            If iShipped = 1 Then
                                objMisc._SQL = "Select Pallett_ID from tdevice where device_sn = '" & Trim(R("SN")) & "' and (Device_Dateship is NULL or trim(Device_dateship) = '' or Device_dateship = '0000-00-00 00:00:00') order by Device_id desc;"
                            Else
                                objMisc._SQL = "Select Pallett_ID from tdevice where device_sn = '" & Trim(R("SN")) & "' order by Device_id desc;"
                            End If

                            dt1 = objMisc.GetDataTable
                            R1 = dt1.Rows(0)
                            If R1("Pallett_ID") <> iPallet_ID Then
                                Throw New Exception("Device Serial Number (SN: " & Trim(R("SN")) & ") does not belong to Pallet selected.")
                            End If
                            '******************************************
                            If i <> dtExcelSNs.Rows.Count Then
                                If Not IsDBNull(R("SN")) Then
                                    strDeviceSNs += "'" & Trim(R("SN")) & "',"
                                End If
                            Else
                                If Not IsDBNull(R("SN")) Then
                                    strDeviceSNs += "'" & Trim(R("SN")) & "'"
                                End If
                            End If
                            i += 1
                        Next R
                        strsql += strDeviceSNs & ");"

                    Case 2219      'gamestop
                        dtExcelSNs = New DataTable()
                        objConn.ConnectionString = sConnectionstring
                        objConn.Open()
                        objCmdSelect.CommandText = ("SELECT Serial, '' as BillCode_Rule, '' as Model_ID, '' as Model_Desc, '' as SKU_Number, '' as RURRTMHasParts, 0 as device_id, 0 as wo_id FROM [Sheet1$] where [Serial] is not NULL order by [Serial]")
                        objCmdSelect.Connection = objConn
                        objAdapter1.SelectCommand = objCmdSelect
                        objAdapter1.Fill(dtExcelSNs)
                        '***************************************
                        'Checks if the Excel file has duplicate SNs
                        '***************************************
                        If iShipped = 1 Then
                            strsql = "Select distinct Device_SN from tdevice where Loc_ID = " & Me.iLoc_ID & " and device_dateship is null and device_sn in ("
                        Else
                            strsql = "Select distinct Device_SN from tdevice where Loc_ID = " & Me.iLoc_ID & " and device_sn in ("
                        End If

                        For Each R In dtExcelSNs.Rows
                            '******************************************
                            'Check if the Device exists in the database
                            If iShipped = 1 Then
                                objMisc._SQL = "Select Count(*) cnt from tdevice where Loc_ID = " & Me.iLoc_ID & " and device_sn = '" & Trim(R("Serial")) & "' and device_datebill is not null and device_datebill <> '0000-00-00 00:00:00' and device_dateship is null;"
                            Else
                                objMisc._SQL = "Select Count(*) cnt from tdevice where Loc_ID = " & Me.iLoc_ID & " and device_sn = '" & Trim(R("Serial")) & "' order by Device_id desc;"
                            End If

                            dt1 = objMisc.GetDataTable
                            R1 = dt1.Rows(0)
                            If R1("cnt") = 0 Then
                                Throw New Exception("Device Serial Number (Serial: " & Trim(R("Serial")) & ") either is not billed or is already shipped or just does not exist in the database.")
                            End If

                            If Not IsNothing(dt1) Then
                                dt1.Dispose()
                                dt1 = Nothing
                            End If
                            '******************************************
                            'Match the Pallett
                            If iShipped = 1 Then
                                objMisc._SQL = "Select Pallett_ID from tdevice where Loc_ID = " & Me.iLoc_ID & " and device_sn = '" & Trim(R("Serial")) & "' and (Device_Dateship is NULL or trim(Device_dateship) = '' or Device_dateship = '0000-00-00 00:00:00') order by Device_id desc;"
                            Else
                                objMisc._SQL = "Select Pallett_ID from tdevice where Loc_ID = " & Me.iLoc_ID & " and device_sn = '" & Trim(R("Serial")) & "' order by Device_id desc;"
                            End If

                            dt1 = objMisc.GetDataTable
                            R1 = dt1.Rows(0)
                            If R1("Pallett_ID") <> iPallet_ID Then
                                Throw New Exception("Device Serial Number (Serial: " & Trim(R("Serial")) & ") does not belong to Pallet selected.")
                            End If
                            '******************************************
                            If i <> dtExcelSNs.Rows.Count Then
                                If Not IsDBNull(R("Serial")) Then
                                    strDeviceSNs += "'" & Trim(R("Serial")) & "',"
                                End If
                            Else
                                If Not IsDBNull(R("Serial")) Then
                                    strDeviceSNs += "'" & Trim(R("Serial")) & "'"
                                End If
                            End If
                            i += 1
                        Next R
                        strsql += strDeviceSNs & ");"

                    Case 2238      'Trimble Mobile Solutions
                        dtExcelSNs = New DataTable()
                        objConn.ConnectionString = sConnectionstring
                        objConn.Open()
                        objCmdSelect.CommandText = ("SELECT SN, '' as BillCode_Rule, '' as Model_ID, '' as Model_Desc, '' as SKU_Number, '' as RURRTMHasParts, 0 as device_id, 0 as wo_id FROM [Sheet1$] where [SN] is not NULL order by [SN]")
                        objCmdSelect.Connection = objConn
                        objAdapter1.SelectCommand = objCmdSelect
                        objAdapter1.Fill(dtExcelSNs)
                        '***************************************
                        'Checks if the Excel file has duplicate SNs
                        '***************************************
                        If iShipped = 1 Then
                            strsql = "Select distinct Device_SN from tdevice where Loc_ID = " & Me.iLoc_ID & " and device_dateship is null and device_sn in ("
                        Else
                            strsql = "Select distinct Device_SN from tdevice where Loc_ID = " & Me.iLoc_ID & " and and device_sn in ("
                        End If

                        For Each R In dtExcelSNs.Rows
                            '''If Trim(R("SN")) = "356862007331096" Then
                            '''    MsgBox("Stop")
                            '''End If
                            '******************************************
                            'Check if the Device exists in the database
                            If iShipped = 1 Then
                                objMisc._SQL = "Select Count(*) cnt from tdevice where Loc_ID = " & Me.iLoc_ID & " and device_sn = '" & Trim(R("SN")) & "' and device_datebill is not null and device_datebill <> '0000-00-00 00:00:00' and device_dateship is null;"
                            Else
                                objMisc._SQL = "Select Count(*) cnt from tdevice where Loc_ID = " & Me.iLoc_ID & " and device_sn = '" & Trim(R("SN")) & "' order by Device_id desc;"
                            End If

                            dt1 = objMisc.GetDataTable
                            R1 = dt1.Rows(0)
                            If R1("cnt") = 0 Then
                                Throw New Exception("Device Serial Number (SN: " & Trim(R("SN")) & ") either is not billed or is already shipped or just does not exist in the database.")
                            ElseIf R1("cnt") > 1 Then
                                Throw New Exception("Device Serial Number (SN: " & Trim(R("SN")) & ") exists twice without a ship date.")
                            End If

                            If Not IsNothing(dt1) Then
                                dt1.Dispose()
                                dt1 = Nothing
                            End If
                            '******************************************
                            'Match the Pallett
                            If iShipped = 1 Then
                                objMisc._SQL = "Select Pallett_ID from tdevice where Loc_ID = " & Me.iLoc_ID & " and device_sn = '" & Trim(R("SN")) & "' and (Device_Dateship is NULL or trim(Device_dateship) = '' or Device_dateship = '0000-00-00 00:00:00') order by Device_id desc;"
                            Else
                                objMisc._SQL = "Select Pallett_ID from tdevice where Loc_ID = " & Me.iLoc_ID & " and device_sn = '" & Trim(R("SN")) & "' order by Device_id desc;"
                            End If

                            dt1 = objMisc.GetDataTable
                            R1 = dt1.Rows(0)
                            If R1("Pallett_ID") <> iPallet_ID Then
                                Throw New Exception("Device Serial Number (SN: " & Trim(R("SN")) & ") does not belong to Pallet selected.")
                            End If
                            '******************************************
                            If i <> dtExcelSNs.Rows.Count Then
                                If Not IsDBNull(R("SN")) Then
                                    strDeviceSNs += "'" & Trim(R("SN")) & "',"
                                End If
                            Else
                                If Not IsDBNull(R("SN")) Then
                                    strDeviceSNs += "'" & Trim(R("SN")) & "'"
                                End If
                            End If
                            i += 1
                        Next R
                        strsql += strDeviceSNs & ");"
                    Case 2245      'Liquidity Services/Dyscern
                        dtExcelSNs = New DataTable()
                        objConn.ConnectionString = sConnectionstring
                        objConn.Open()
                        objCmdSelect.CommandText = ("SELECT IMEI, '' as BillCode_Rule, '' as Model_ID, '' as Model_Desc, '' as SKU_Number, '' as RURRTMHasParts, 0 as device_id, 0 as wo_id FROM [Sheet1$] where [IMEI] is not NULL order by [IMEI]")
                        objCmdSelect.Connection = objConn
                        objAdapter1.SelectCommand = objCmdSelect
                        objAdapter1.Fill(dtExcelSNs)
                        '***************************************
                        'Checks if the Excel file has duplicate IMEIs
                        '***************************************

                        If iShipped = 1 Then
                            strsql = "Select distinct Device_SN from tdevice where Loc_ID = " & Me.iLoc_ID & " and device_dateship is null and device_sn in ("
                        Else
                            strsql = "Select distinct Device_SN from tdevice where Loc_ID = " & Me.iLoc_ID & " and device_sn in ("
                        End If

                        For Each R In dtExcelSNs.Rows
                            '******************************************
                            'Check if the Device exists in the database
                            If iShipped = 1 Then
                                objMisc._SQL = "Select Count(*) cnt from tdevice where Loc_ID = " & Me.iLoc_ID & " and device_sn = '" & Trim(R("IMEI")) & "' and device_datebill is not null and device_datebill <> '0000-00-00 00:00:00' and device_dateship is null;"
                            Else
                                objMisc._SQL = "Select Count(*) cnt from tdevice where Loc_ID = " & Me.iLoc_ID & " and device_sn = '" & Trim(R("IMEI")) & "' order by Device_id desc;"
                            End If

                            dt1 = objMisc.GetDataTable
                            R1 = dt1.Rows(0)
                            If R1("cnt") = 0 Then
                                Throw New Exception("Device Serial Number (IMEI: " & Trim(R("IMEI")) & ") either is not billed or is already shipped or just does not exist in the database.")
                            End If

                            If Not IsNothing(dt1) Then
                                dt1.Dispose()
                                dt1 = Nothing
                            End If
                            '******************************************
                            'Match the Pallett
                            If iShipped = 1 Then
                                objMisc._SQL = "Select Pallett_ID from tdevice where Loc_ID = " & Me.iLoc_ID & " and device_sn = '" & Trim(R("IMEI")) & "' and (Device_Dateship is NULL or trim(Device_dateship) = '' or Device_dateship = '0000-00-00 00:00:00') order by Device_id desc;"
                            Else
                                objMisc._SQL = "Select Pallett_ID from tdevice where Loc_ID = " & Me.iLoc_ID & " and device_sn = '" & Trim(R("IMEI")) & "' order by Device_id desc;"
                            End If

                            dt1 = objMisc.GetDataTable
                            R1 = dt1.Rows(0)
                            If R1("Pallett_ID") <> iPallet_ID Then
                                Throw New Exception("Device Serial Number (IMEI: " & Trim(R("IMEI")) & ") does not belong to Pallet selected.")
                            End If
                            '******************************************
                            If i <> dtExcelSNs.Rows.Count Then
                                If Not IsDBNull(R("IMEI")) Then
                                    strDeviceSNs += "'" & Trim(R("IMEI")) & "',"
                                End If
                            Else
                                If Not IsDBNull(R("IMEI")) Then
                                    strDeviceSNs += "'" & Trim(R("IMEI")) & "'"
                                End If
                            End If
                            i += 1
                        Next R
                        strsql += strDeviceSNs & ");"
                    Case 2242, 2259, 2278      'Sonitrol, PSS Exchange, Advantor Systems/Infrasafe
                        dtExcelSNs = New DataTable()
                        objConn.ConnectionString = sConnectionstring
                        objConn.Open()
                        objCmdSelect.CommandText = ("SELECT SN, '' as BillCode_Rule, '' as Model_ID, '' as Model_Desc, '' as SKU_Number, '' as RURRTMHasParts, 0 as device_id, 0 as wo_id FROM [Sheet1$] where [SN] is not NULL order by [SN]")
                        objCmdSelect.Connection = objConn
                        objAdapter1.SelectCommand = objCmdSelect
                        objAdapter1.Fill(dtExcelSNs)
                        '***************************************
                        'Checks if the Excel file has duplicate IMEIs
                        '***************************************

                        If iShipped = 1 Then
                            strsql = "Select distinct Device_SN from tdevice where Loc_ID = " & Me.iLoc_ID & " and device_dateship is null and device_sn in ("
                        Else
                            strsql = "Select distinct Device_SN from tdevice where Loc_ID = " & Me.iLoc_ID & " and device_sn in ("
                        End If

                        For Each R In dtExcelSNs.Rows
                            '******************************************
                            'Check if the Device exists in the database
                            If iShipped = 1 Then
                                objMisc._SQL = "Select Count(*) cnt from tdevice where Loc_ID = " & Me.iLoc_ID & " and device_sn = '" & Trim(R("SN")) & "' and device_datebill is not null and device_datebill <> '0000-00-00 00:00:00' and device_dateship is null;"
                            Else
                                objMisc._SQL = "Select Count(*) cnt from tdevice where Loc_ID = " & Me.iLoc_ID & " and  device_sn = '" & Trim(R("SN")) & "' order by Device_id desc;"
                            End If

                            dt1 = objMisc.GetDataTable
                            R1 = dt1.Rows(0)
                            If R1("cnt") = 0 Then
                                Throw New Exception("Device Serial Number (SN: " & Trim(R("SN")) & ") either is not billed or is already shipped or just does not exist in the database.")
                            End If

                            If Not IsNothing(dt1) Then
                                dt1.Dispose()
                                dt1 = Nothing
                            End If
                            '******************************************
                            'Match the Pallett
                            If iShipped = 1 Then
                                objMisc._SQL = "Select Pallett_ID from tdevice where Loc_ID = " & Me.iLoc_ID & " and device_sn = '" & Trim(R("SN")) & "' and (Device_Dateship is NULL or trim(Device_dateship) = '' or Device_dateship = '0000-00-00 00:00:00') order by Device_id desc;"
                            Else
                                objMisc._SQL = "Select Pallett_ID from tdevice where Loc_ID = " & Me.iLoc_ID & " and device_sn = '" & Trim(R("SN")) & "' order by Device_id desc;"
                            End If

                            dt1 = objMisc.GetDataTable
                            R1 = dt1.Rows(0)
                            If R1("Pallett_ID") <> iPallet_ID Then
                                Throw New Exception("Device Serial Number (SN: " & Trim(R("SN")) & ") does not belong to Pallet selected.")
                            End If
                            '******************************************
                            If i <> dtExcelSNs.Rows.Count Then
                                If Not IsDBNull(R("SN")) Then
                                    strDeviceSNs += "'" & Trim(R("SN")) & "',"
                                End If
                            Else
                                If Not IsDBNull(R("SN")) Then
                                    strDeviceSNs += "'" & Trim(R("SN")) & "'"
                                End If
                            End If
                            i += 1
                        Next R
                        strsql += strDeviceSNs & ");"

                    Case 2249     'Demo
                        dtExcelSNs = New DataTable()
                        objConn.ConnectionString = sConnectionstring
                        objConn.Open()
                        objCmdSelect.CommandText = ("SELECT IMEI, '' as BillCode_Rule, '' as Model_ID, '' as Model_Desc, '' as SKU_Number, '' as RURRTMHasParts, 0 as device_id, 0 as wo_id FROM [Sheet1$] where [IMEI] is not NULL order by [IMEI]")
                        objCmdSelect.Connection = objConn
                        objAdapter1.SelectCommand = objCmdSelect
                        objAdapter1.Fill(dtExcelSNs)
                        '***************************************
                        'Checks if the Excel file has duplicate IMEIs
                        '***************************************

                        If iShipped = 1 Then
                            strsql = "Select distinct Device_SN from tdevice where Loc_ID = " & Me.iLoc_ID & " and device_dateship is null and device_sn in ("
                        Else
                            strsql = "Select distinct Device_SN from tdevice where Loc_ID = " & Me.iLoc_ID & " and device_sn in ("
                        End If

                        For Each R In dtExcelSNs.Rows
                            '******************************************
                            'Check if the Device exists in the database
                            If iShipped = 1 Then
                                objMisc._SQL = "Select Count(*) cnt from tdevice where Loc_ID = " & Me.iLoc_ID & " and device_sn = '" & Trim(R("IMEI")) & "' and device_dateship is null;"
                            Else
                                objMisc._SQL = "Select Count(*) cnt from tdevice where Loc_ID = " & Me.iLoc_ID & " and device_sn = '" & Trim(R("IMEI")) & "' order by Device_id desc;"
                            End If

                            dt1 = objMisc.GetDataTable
                            R1 = dt1.Rows(0)
                            If R1("cnt") = 0 Then
                                Throw New Exception("Device Serial Number (IMEI: " & Trim(R("IMEI")) & ") either is not billed or is already shipped or just does not exist in the database.")
                            End If

                            If Not IsNothing(dt1) Then
                                dt1.Dispose()
                                dt1 = Nothing
                            End If
                            '******************************************
                            'Match the Pallett
                            If iShipped = 1 Then
                                objMisc._SQL = "Select Pallett_ID from tdevice where Loc_ID = " & Me.iLoc_ID & " and device_sn = '" & Trim(R("IMEI")) & "' and (Device_Dateship is NULL or trim(Device_dateship) = '' or Device_dateship = '0000-00-00 00:00:00') order by Device_id desc;"
                            Else
                                objMisc._SQL = "Select Pallett_ID from tdevice where Loc_ID = " & Me.iLoc_ID & " and device_sn = '" & Trim(R("IMEI")) & "' order by Device_id desc;"
                            End If

                            dt1 = objMisc.GetDataTable
                            R1 = dt1.Rows(0)
                            If R1("Pallett_ID") <> iPallet_ID Then
                                Throw New Exception("Device Serial Number (IMEI: " & Trim(R("IMEI")) & ") does not belong to Pallet selected.")
                            End If
                            '******************************************
                            If i <> dtExcelSNs.Rows.Count Then
                                If Not IsDBNull(R("IMEI")) Then
                                    strDeviceSNs += "'" & Trim(R("IMEI")) & "',"
                                End If
                            Else
                                If Not IsDBNull(R("IMEI")) Then
                                    strDeviceSNs += "'" & Trim(R("IMEI")) & "'"
                                End If
                            End If
                            i += 1
                        Next R
                        strsql += strDeviceSNs & ");"
                    Case SkyTel.SKYTEL_CUSTOMER_ID, SkyTel.MorrisCom_CUSTOMER_ID, _
                           SkyTel.Propage_CUSTOMER_ID, SkyTel.Aquis_CUSTOMER_ID, SkyTel.CookPager_CUSTOMER_ID, _
                           SkyTel.ContactWireless_CUSTOMER_ID, SkyTel.A1WirelessComm_CUSTOMER_ID, SkyTel.AMS_CUSTOMER_ID, _
                           SkyTel.CriticalAlert_CUSTOMER_ID, SkyTel.Anna_CUSTOMER_ID, SkyTel.Lahey_CUSTOMER_ID, _
                           SkyTel.Masco_CUSTOMER_ID, SkyTel.Franciscan_CUSTOMER_ID, SkyTel.Maine_CUSTOMER_ID, _
                           SkyTel.SMHC_CUSTOMER_ID, SkyTel.ATS_CUSTOMER_ID
                        dtExcelSNs = New DataTable()

                        'Quick fix for - File should be ok. Don't have to do the above check
                        strsql = "SELECT Device_SN as SN, '' as BillCode_Rule, 0 as Model_ID, '' as Model_Desc, '' as SKU_Number, '' as RURRTMHasParts, Device_ID as device_id, WO_ID as wo_id FROM tdevice WHERE Loc_ID = " & Me.iLoc_ID & " AND pallett_ID = " & iPallet_ID & " order by Device_SN"
                        objMisc._SQL = strsql
                        dtExcelSNs = objMisc.GetDataTable
                    Case 2254      'Plexus Corp.
                        dtExcelSNs = New DataTable()
                        objConn.ConnectionString = sConnectionstring
                        objConn.Open()
                        objCmdSelect.CommandText = ("SELECT SN, '' as BillCode_Rule, '' as Model_ID, '' as Model_Desc, '' as SKU_Number, '' as RURRTMHasParts, 0 as device_id, 0 as wo_id FROM [Sheet1$] where [SN] is not NULL order by [SN]")
                        objCmdSelect.Connection = objConn
                        objAdapter1.SelectCommand = objCmdSelect
                        objAdapter1.Fill(dtExcelSNs)
                        '***************************************
                        'Checks if the Excel file has duplicate IMEIs
                        '***************************************

                        If iShipped = 1 Then
                            strsql = "Select distinct Device_SN from tdevice where Loc_ID = " & Me.iLoc_ID & " AND device_dateship is null and device_sn in ("
                        Else
                            strsql = "Select distinct Device_SN from tdevice where Loc_ID = " & Me.iLoc_ID & " and device_sn in ("
                        End If

                        For Each R In dtExcelSNs.Rows
                            '******************************************
                            'Check if the Device exists in the database
                            If iShipped = 1 Then
                                objMisc._SQL = "Select Count(*) cnt from tdevice where Loc_ID = " & Me.iLoc_ID & " and device_sn = '" & Trim(R("SN")) & "' and (Device_Dateship is NULL or trim(Device_dateship) = '' or Device_dateship = '0000-00-00 00:00:00') order by Device_id desc;"
                            Else
                                objMisc._SQL = "Select Count(*) cnt from tdevice where Loc_ID = " & Me.iLoc_ID & " and device_sn = '" & Trim(R("SN")) & "' and pallett_id = " & iPallet_ID & " order by Device_id desc;"
                            End If

                            dt1 = objMisc.GetDataTable
                            R1 = dt1.Rows(0)
                            If R1("cnt") = 0 Then
                                Throw New Exception("Device Serial Number (SN: " & Trim(R("SN")) & ") either is not billed or is already shipped or just does not exist in the database.")
                            End If

                            If Not IsNothing(dt1) Then
                                dt1.Dispose()
                                dt1 = Nothing
                            End If
                            '******************************************
                            'Match the Pallett
                            If iShipped = 1 Then
                                objMisc._SQL = "Select Pallett_ID from tdevice where Loc_ID = " & Me.iLoc_ID & " and device_sn = '" & Trim(R("SN")) & "' and (Device_Dateship is NULL or trim(Device_dateship) = '' or Device_dateship = '0000-00-00 00:00:00') order by Device_id desc;"
                            Else
                                objMisc._SQL = "Select Pallett_ID from tdevice where Loc_ID = " & Me.iLoc_ID & " and device_sn = '" & Trim(R("SN")) & "' and pallett_id = " & iPallet_ID & " order by Device_id desc;"
                            End If

                            dt1 = objMisc.GetDataTable
                            R1 = dt1.Rows(0)
                            If R1("Pallett_ID") <> iPallet_ID Then
                                Throw New Exception("Device Serial Number (SN: " & Trim(R("SN")) & ") does not belong to Pallet selected.")
                            End If
                            '******************************************
                            If i <> dtExcelSNs.Rows.Count Then
                                If Not IsDBNull(R("SN")) Then
                                    strDeviceSNs += "'" & Trim(R("SN")) & "',"
                                End If
                            Else
                                If Not IsDBNull(R("SN")) Then
                                    strDeviceSNs += "'" & Trim(R("SN")) & "'"
                                End If
                            End If
                            i += 1
                        Next R
                        strsql += strDeviceSNs & ");"




                    Case Else
                        Throw New Exception("Cust_ID in tpallett table needs to be updated.")
                End Select

                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable

                If dt1.Rows.Count <> dtExcelSNs.Rows.Count Then
                    Throw New Exception("Excel file has duplicate SN.")
                End If
                '***************************************

                Return dtExcelSNs.Rows.Count

            Catch ex As Exception
                Throw New Exception("Buisness.BulkShipping.ExtractSNs(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                If Not IsNothing(objConn) Then
                    objConn.Close()
                    objConn.Dispose()
                    objConn = Nothing
                End If
                If Not IsNothing(objCmdSelect) Then
                    objCmdSelect.Dispose()
                    objCmdSelect = Nothing
                End If
                If Not IsNothing(objAdapter1) Then
                    objAdapter1.Dispose()
                    objAdapter1 = Nothing
                End If
            End Try
        End Function

        '********************************************
        Public Function ExtractSNsFrExcelRpt(ByVal strSNColName As String, _
                                   Optional ByVal iShipped As Integer = 1) As Integer
            Dim sConnectionstring As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strFilePath & ";Extended Properties=Excel 8.0;"
            Dim objConn As New OleDbConnection()
            Dim objCmdSelect As New OleDbCommand()
            Dim objAdapter1 As New OleDbDataAdapter()
            Dim strsql1 As String = ""

            Dim R, R1 As DataRow
            Dim dt1 As DataTable
            Dim strDeviceSNs As String = ""
            Dim i As Integer = 1

            Try
                '***********************************
                'Added by Lan on 03/15/07
                'prevent user from ship open pallet
                '***********************************
                strsql1 = "select Pallett_ReadyToShipFlg  from tpallett where Pallett_id = " & iPallet_ID & ";"
                Me.objMisc._SQL = strsql1
                dt1 = Me.objMisc.GetDataTable
                If dt1.Rows.Count > 0 Then
                    If dt1.Rows(0)("Pallett_ReadyToShipFlg") = 0 Then
                        Throw New Exception("This Pallet may have been reopened. Please close this screen and reopen it.")
                    End If
                Else
                    Throw New Exception("Pallet does not exist.")
                End If
                '***********************************
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                If Not IsNothing(dtExcelSNs) Then
                    dtExcelSNs.Dispose()
                    dtExcelSNs = Nothing
                End If
                '***********************************
                dtExcelSNs = New DataTable()
                objConn.ConnectionString = sConnectionstring
                objConn.Open()
                objCmdSelect.CommandText = ("SELECT " & strSNColName & ", '' as BillCode_Rule, '' as Model_ID, '' as Model_Desc, '' as SKU_Number, '' as RURRTMHasParts, 0 as device_id, 0 as wo_id FROM [Sheet1$] where [SN] is not NULL order by [SN]")
                objCmdSelect.Connection = objConn
                objAdapter1.SelectCommand = objCmdSelect
                objAdapter1.Fill(dtExcelSNs)
                '***************************************
                'Checks if the Excel file has duplicate IMEIs
                '***************************************
                If iShipped = 1 Then
                    strsql = "Select distinct Device_SN from tdevice where Loc_ID = " & Me.iLoc_ID & " and device_dateship is null and device_sn in ("
                Else
                    strsql = "Select distinct Device_SN from tdevice where Loc_ID = " & Me.iLoc_ID & " and device_sn in ("
                End If

                For Each R In dtExcelSNs.Rows
                    '******************************************
                    'Check if the Device exists in the database
                    If iShipped = 1 Then
                        objMisc._SQL = "Select Count(*) cnt from tdevice where Loc_ID = " & Me.iLoc_ID & " and device_sn = '" & Trim(R("SN")) & "' and device_dateship is null;"
                    Else
                        objMisc._SQL = "Select Count(*) cnt from tdevice where Loc_ID = " & Me.iLoc_ID & " and device_sn = '" & Trim(R("SN")) & "' order by Device_id desc;"
                    End If
                    dt1 = objMisc.GetDataTable
                    R1 = dt1.Rows(0)
                    If R1("cnt") = 0 Then
                        Throw New Exception("Device Serial Number (" & Trim(R("SN")) & ") either is not billed or is already shipped or just does not exist in the database.")
                    End If

                    If Not IsNothing(dt1) Then
                        dt1.Dispose()
                        dt1 = Nothing
                    End If
                    '******************************************
                    'Match the Pallett
                    If iShipped = 1 Then
                        objMisc._SQL = "Select Pallett_ID from tdevice where Loc_ID = " & Me.iLoc_ID & " and  device_sn = '" & Trim(R("SN")) & "' and (Device_Dateship is NULL or trim(Device_dateship) = '' or Device_dateship = '0000-00-00 00:00:00') order by Device_id desc;"
                    Else
                        objMisc._SQL = "Select Pallett_ID from tdevice where Loc_ID = " & Me.iLoc_ID & " and device_sn = '" & Trim(R("SN")) & "' order by Device_id desc;"
                    End If
                    dt1 = objMisc.GetDataTable
                    R1 = dt1.Rows(0)
                    If R1("Pallett_ID") <> iPallet_ID Then
                        Throw New Exception("Device Serial Number ( " & Trim(R("SN")) & ") does not belong to  selected.")
                    End If
                    '******************************************
                    If i <> dtExcelSNs.Rows.Count Then
                        If Not IsDBNull(R(strSNColName)) Then
                            strDeviceSNs += "'" & Trim(R(strSNColName)) & "',"
                        End If
                    Else
                        If Not IsDBNull(R(strSNColName)) Then
                            strDeviceSNs += "'" & Trim(R(strSNColName)) & "'"
                        End If
                    End If
                    i += 1
                Next R
                strsql += strDeviceSNs & ");"

                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable

                If dt1.Rows.Count <> dtExcelSNs.Rows.Count Then
                    Throw New Exception("Excel file has duplicate SN.")
                End If
                '***************************************

                Return dtExcelSNs.Rows.Count

            Catch ex As Exception
                Throw New Exception("Buisness.BulkShipping.ExtractSNs(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                If Not IsNothing(objConn) Then
                    objConn.Close()
                    objConn.Dispose()
                    objConn = Nothing
                End If
                If Not IsNothing(objCmdSelect) Then
                    objCmdSelect.Dispose()
                    objCmdSelect = Nothing
                End If
                If Not IsNothing(objAdapter1) Then
                    objAdapter1.Dispose()
                    objAdapter1 = Nothing
                End If
            End Try
        End Function
        'iCust_ID = 2626 Or iCust_ID = 2627 Or iCust_ID = 2624 Or iCust_ID = 2630 Then
        '********************************************
        Public Sub New()
            objMisc = New Production.Misc()
            Me._Cust_List.Add(2631)
            Me._Cust_List.Add(2630)
            Me._Cust_List.Add(2629)
            Me._Cust_List.Add(2627)
            Me._Cust_List.Add(2624)
            Me._Cust_List.Add(2626)
        End Sub
        '********************************************
        Protected Overrides Sub Finalize()
            If Not IsNothing(dtExcelSNs) Then
                dtExcelSNs.Dispose()
                dtExcelSNs = Nothing
            End If
            If Not IsNothing(dtWO) Then
                dtWO.Dispose()
                dtWO = Nothing
            End If
            objMisc = Nothing
            MyBase.Finalize()
        End Sub

        '********************************************
        'Print shipping label
        '********************************************
        Public Sub PrintShippingPalletLabelRpt(ByVal iPalletID As Integer)
            Dim objShipPalRpt As ShipPalletReport

            Try
                objShipPalRpt = New ShipPalletReport(iCust_ID, iPalletID, 2)

                objShipPalRpt.GetCrystalReportOutput()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '********************************************************************************************************
        Public Function GetProdIDInPallet(ByVal iPalletID As Integer) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT DISTINCT Prod_ID FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID WHERE Pallett_ID = " & iPalletID
                Return Me.objMisc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************************************

    End Class
End Namespace