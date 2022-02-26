Option Explicit On
Imports System.Windows.Forms
Namespace Buisness
    Public Class ReworkPallets

        Private objMisc As Production.Misc
        Public dtRef, dtRUR, dtRTM As DataTable
        Public strRefPalletName As String = ""
        Public strRURPalletName As String = ""
        Public strRTMPalletName As String = ""
        Public iRefPallet_id As Integer = 0
        Public iRURPallet_id As Integer = 0
        Public iRTMPallet_id As Integer = 0


        '***************************************************
        Public Sub New()
            objMisc = New Production.Misc()
        End Sub
        '***************************************************
        Protected Overrides Sub Finalize()
            objMisc = Nothing
            MyBase.Finalize()
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

        '***************************************************
        'Get WO_ID for received pallet namel
        '***************************************************
        Public Function GetWOInfo(ByVal strRcvdPalletName As String)
            Dim strSql As String = ""

            Try
                strSql = "select tlocation.cust_id, tworkorder.* from tworkorder " & Environment.NewLine
                strSql &= "inner join tlocation on tworkorder.loc_id = tlocation.loc_id " & Environment.NewLine
                strSql &= "where WO_RecPalletName = '" & strRcvdPalletName & "';"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************
        'Get all devices for wo
        '***************************************************
        Public Function CreateShipDatatable(ByVal strRvdPalletName As String,
                                            ByVal strWO_IDs As String,
                                            ByVal lst As ListBox) As Integer

            Dim dt1, dt2 As DataTable
            Dim strSql As String = ""
            Dim R1, R2 As DataRow
            Dim NewRow As DataRow
            Dim strSNList As String = ""
            Dim i As Integer = 0

            Try
                '**************************
                'create sn list
                '**************************
                If lst.Items.Count > 0 Then
                    For i = 0 To lst.Items.Count - 1
                        If i = 0 Then
                            strSNList = "'" & Trim(lst.Items.Item(i)) & "'"
                        Else
                            strSNList &= ", " & "'" & Trim(lst.Items.Item(i)) & "'"
                        End If
                    Next i
                End If
                '**************************
                'Step1: Create data tables
                '**************************
                Me.CreateDataTable(dtRef)
                Me.CreateDataTable(dtRUR)
                Me.CreateDataTable(dtRTM)

                '*************************************************************
                strSql = "Select tdevice.*, tpretest_data.PTtf " & Environment.NewLine
                strSql &= "from tworkorder " & Environment.NewLine
                strSql &= "inner join tdevice on tworkorder.wo_id = tdevice.WO_ID " & Environment.NewLine
                strSql &= "left outer join tpretest_data on tdevice.Device_ID = tpretest_data.device_id " & Environment.NewLine
                'strSql &= "where WO_RecPalletName = '" & strRvdPalletName & "';"
                strSql &= "where tdevice.wo_id in (" & strWO_IDs & ") " & Environment.NewLine
                If strSNList <> "" Then
                    strSql &= "and tdevice.device_sn not in (" & strSNList & ");"
                End If

                Me.objMisc._SQL = strSql
                dt1 = Me.objMisc.GetDataTable
                'Create(dt1)

                If dt1.Rows.Count = 0 Then
                    Throw New Exception("Pallet not found.")
                End If

                For Each R1 In dt1.Rows
                    '*******************************************
                    'validate ship date, invoice and date billed
                    'Check if device shipped
                    If Not IsDBNull(R1("device_dateship")) Or Not IsDBNull(R1("pallett_id")) Then
                        Throw New Exception("SN " & R1("device_sn") & " has already assigned to a ship pallet. Can not auto-ship this work order. ")
                    End If

                    'check if device invoiced
                    If Not IsDBNull(R1("device_invoice")) Then
                        If R1("device_invoice") = 1 Then
                            Throw New Exception(R1("device_sn") & " has already invoiced. Can not auto-ship this work order. ")
                        End If
                    End If

                    'check if device billed
                    If IsDBNull(R1("Device_datebill")) Then
                        Throw New Exception(R1("device_sn") & " not billed. Can not auto-ship this work order. ")
                    ElseIf R1("Device_datebill").ToString = "0000-00-00 00:00:00" Then
                        Throw New Exception(R1("device_sn") & " not billed. Can not auto-ship this work order. ")
                    End If

                    'Check if pretest data existed
                    If R1("Loc_ID") = 2540 Then     'ATCLE 
                        If IsDBNull(R1("PTtf")) Then
                            Throw New Exception(R1("device_sn") & " has no pretest data.")
                        End If
                    End If
                    '*******************************************

                    If Not IsNothing(dt2) Then
                        dt2.Dispose()
                        dt2 = Nothing
                    End If

                    'Check for RTM'
                    strSql = "Select tdevicebill.billcode_id, lbillcodes.BillCode_Rule, lbillcodes.BillType_ID " & Environment.NewLine
                    strSql &= " from tdevicebill " & Environment.NewLine
                    strSql &= "inner join lbillcodes on tdevicebill.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                    strSql &= "where tdevicebill.device_id = " & R1("Device_ID") & " order by lbillcodes.billcode_rule desc;"
                    Me.objMisc._SQL = strSql
                    dt2 = Me.objMisc.GetDataTable
                    'create(dt2)

                    If dt2.Rows.Count = 0 Then
                        Throw New Exception("Nothing is billed on this device.")
                    End If
                    R2 = dt2.Rows(0)

                    Select Case R2("Billcode_rule")

                        Case 9  'RTM
                            '***************************************************
                            'Added by Lan on 11/14/2007. Prestest codes validation
                            'Pretest code 2515:   'Pass
                            'Pretest code 2516:   'Fail - RF Test
                            'Pretest code 2517:   'Fail - User Interface
                            'Pretest code 2518:   'Fail - Flash
                            'Pretest code 2519:   'RUR (Liquid Intrusion)
                            'Pretest code 2520:   'RUR (Physical Damage)
                            '***************************************************
                            'Check if pretest data existed
                            If R1("Loc_ID") = 2540 Then     'ATCLE 
                                If R1("PTtf") = 2515 _
                                   Or R1("PTtf") = 2519 _
                                   Or R1("PTtf") = 2520 Then
                                    Throw New Exception("SN """ & R1("device_sn") & """ has either Pass or RUR failure codes at pretest but billed with RTM.")
                                End If
                            End If

                            'Check if any part bill to this device
                            Me.Check_RUR_RTM_DeviceWithParts(R1("device_sn"), dt2)

                            'add this to dtRTM table'
                            NewRow = Me.dtRTM.NewRow
                            NewRow("device_id") = R1("device_id")
                            NewRow("device_sn") = R1("device_sn")
                            NewRow("loc_id") = R1("loc_id")
                            NewRow("model_id") = R1("model_id")
                            Me.dtRTM.Rows.Add(NewRow)
                            NewRow = Nothing
                            Me.dtRTM.AcceptChanges()
                        Case 1  'RUR
                            'Validate Pretest data
                            If R1("Loc_ID") = 2540 Then     'ATCLE
                                If R1("PTtf") = 2515 _
                                Or R1("PTtf") = 2516 _
                                Or R1("PTtf") = 2517 _
                                Or R1("PTtf") = 2518 Then
                                    Throw New Exception("SN """ & R1("device_sn") & """ has either Pass or RTM failure codes at pretest but billed with RUR.")
                                End If
                            End If

                            'Check if any part bill to this device
                            Me.Check_RUR_RTM_DeviceWithParts(R1("device_sn"), dt2)

                            'add this to dtRUR table
                            NewRow = Me.dtRUR.NewRow
                            NewRow("device_id") = R1("device_id")
                            NewRow("device_sn") = R1("device_sn")
                            NewRow("loc_id") = R1("loc_id")
                            NewRow("model_id") = R1("model_id")
                            Me.dtRUR.Rows.Add(NewRow)
                            NewRow = Nothing
                            Me.dtRUR.AcceptChanges()
                        Case 0  'REF
                            'Validate Pretest data
                            If R1("Loc_ID") = 2540 Then     'ATCLE 
                                If R1("PTtf") <> 2515 Then
                                    Throw New Exception("SN """ & R1("device_sn") & """ failed at pretest but has cosmetic billcodes.")
                                End If
                            End If

                            'add this to dtREF table
                            NewRow = dtRef.NewRow
                            NewRow("device_id") = R1("device_id")
                            NewRow("device_sn") = R1("device_sn")
                            NewRow("loc_id") = R1("loc_id")
                            NewRow("model_id") = R1("model_id")
                            Me.dtRef.Rows.Add(NewRow)
                            NewRow = Nothing
                            Me.dtRef.AcceptChanges()
                    End Select
                Next R1

                Return dt1.Rows.Count

            Catch ex As Exception
                Throw ex
            Finally
                Me.DisposeDT(dt1)
                Me.DisposeDT(dt2)
            End Try
        End Function


        Private Sub CreateDataTable(ByRef myDataTable As DataTable)
            Dim myDataColumn As DataColumn
            Try

                If Not IsNothing(myDataTable) Then
                    myDataTable.Dispose()
                    myDataTable = Nothing
                End If

                myDataTable = New DataTable()

                myDataColumn = New DataColumn()
                myDataColumn.DataType = System.Type.GetType("System.Int32")
                myDataColumn.ColumnName = "device_id"
                myDataTable.Columns.Add(myDataColumn)
                myDataColumn = Nothing

                myDataColumn = New DataColumn()
                myDataColumn.DataType = System.Type.GetType("System.String")
                myDataColumn.ColumnName = "device_sn"
                myDataTable.Columns.Add(myDataColumn)
                myDataColumn = Nothing

                myDataColumn = New DataColumn()
                myDataColumn.DataType = System.Type.GetType("System.Int32")
                myDataColumn.ColumnName = "loc_id"
                myDataTable.Columns.Add(myDataColumn)
                myDataColumn = Nothing

                myDataColumn = New DataColumn()
                myDataColumn.DataType = System.Type.GetType("System.Int32")
                myDataColumn.ColumnName = "model_id"
                myDataTable.Columns.Add(myDataColumn)
                myDataColumn = Nothing
            Catch ex As Exception
                Throw New Exception("Business.CreateDataTable: " + ex.Message.ToString)
            End Try

        End Sub

        Private Sub Check_RUR_RTM_DeviceWithParts(ByVal strDev_sn As String, _
                                                       ByVal dt1 As DataTable)
            Dim R1 As DataRow

            Try
                For Each R1 In dt1.Rows
                    '*********************************************
                    'Check if there are any parts billed
                    If R1("BillType_ID") = 2 Then
                        Throw New Exception("This device (" & strDev_sn & ") is RUR/RTM with parts. Can not auto-ship this work order.")
                    End If
                    '*********************************************
                Next R1
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Function CreateRWPalletName(ByVal iGroup As Integer, _
                                           ByVal strPalletType As String, _
                                           ByVal iCust_id As Integer, _
                                           ByVal dtWo As DataTable, _
                                           ByVal iModel_id As Integer) As Integer
            Dim strSql As String = ""
            Dim strPallet As String = ""

            '//Get the correct name for the pallet
            Dim mDate As String = (Format(Now, "MMddyy"))
            Dim defaultCount As String = "-01"
            Dim dt, dt1 As DataTable
            Dim r As DataRow
            Dim mInt As Integer = 0
            Dim iMax As Integer = 0
            Dim iPalletID As Long
            Dim iShipType As Integer = 0
            Dim strSkuLen As String = ""
            Dim strPalletSKU As String = ""
            Dim i As Integer = 0
            Dim strModelSku As String

            Try
                '*************************
                'set pallet shiptype
                '*************************
                Select Case strPalletType
                    Case "REF"
                        iShipType = 0
                    Case "RUR"
                        iShipType = 1
                    Case "RTM"
                        iShipType = 9
                End Select
                '*************************
                'set sku length
                '*************************
                If dtWo.Rows.Count > 0 Then
                    strPalletSKU = UCase(Microsoft.VisualBasic.Right(Trim(dtWo.Rows(0)("WO_CustWO")), 3))
                    If strPalletSKU = "{S}" Then
                        strSkuLen = "SHORT"
                    ElseIf strPalletSKU = "{L}" Then
                        strSkuLen = "LONG"
                    End If
                End If

                '******************************************************
                'lan add Group id in pallet name 10/20/2006 
                'If iGroup < 10 Then
                '    strPallet = "0" & iGroup & "-" & "RW" & strPalletType
                'Else
                '    strPallet = iGroup & "-" & "RW" & strPalletType
                'End If
                strSql = "SELECT Model_MotoSku from tmodel where Model_ID = " & iModel_id & ";"
                strModelSku = Me.objMisc.GetSingletonString(strSql)

                If iCust_id = 2219 Then
                    strPallet = "GS" & strModelSku & "R" & strPalletType
                End If
                mDate = strPallet & mDate
                '******************************************************
                'dt = ds.OrderEntrySelect("SELECT * FROM tpallett WHERE Pallett_Name LIKE '" & mDate & "%' ORDER BY Pallett_Name")
                strSql = "SELECT * FROM tpallett WHERE Pallett_Name LIKE '" & mDate & "%' ORDER BY Pallett_Name;"
                Me.objMisc._SQL = strSql
                dt = Me.objMisc.GetDataTable

                If dt.Rows.Count < 1 Then
                    strPallet = mDate & defaultCount                              '//Set Default
                Else

                    For Each r In dt.Rows
                        'mInt = CInt(Mid$(r("Pallett_Name"), 13, 3))                  '//Separate out counter value
                        mInt = CInt(Microsoft.VisualBasic.Right(Trim(r("Pallett_Name")), 2))
                        If mInt > iMax Then
                            iMax = mInt
                        End If
                    Next r
                    'r = dt.Rows(dt.Rows.Count - 1)                          '//Get Last Record
                    iMax += 1                                               '//Increment counter by 1
                    strPallet = mDate & "-" & iMax.ToString.PadLeft(2, "0") '//Concactenate the pallet name
                End If

                '//Insert new pallet to table
                strSql = "INSERT INTO tpallett (Pallett_Name, Pallett_ShipDate, Pallett_BulkShipped, Pallet_ShipType, cust_id, pallet_skuLen, model_id ) VALUES ('" & strPallet & "', '" & FormatDateShort(Now) & "', 2, " & iShipType & ", " & iCust_id & ", '" & strSkuLen & "', " & iModel_id & ");"
                Me.objMisc._SQL = strSql
                i = Me.objMisc.ExecuteNonQuery

                'get pallett_id
                If i > 0 Then
                    strSql = "select pallett_id from tpallett where Pallett_Name = '" & strPallet & "';"
                    Me.objMisc._SQL = strSql
                    dt1 = Me.objMisc.GetDataTable
                    If dt1.Rows.Count > 0 Then
                        iPalletID = dt1.Rows(0)("pallett_id")
                    End If
                End If

                'iPalletID = tblWO.idTransaction(strSql)

                If iPalletID = 0 Then
                    Throw New Exception("Error during create pallet.")
                End If

                Select Case strPalletType
                    Case "REF"
                        Me.strRefPalletName = strPallet
                        Me.iRefPallet_id = iPalletID
                    Case "RUR"
                        Me.strRURPalletName = strPallet
                        Me.iRURPallet_id = iPalletID
                    Case "RTM"
                        Me.strRTMPalletName = strPallet
                        Me.iRTMPallet_id = iPalletID
                End Select

                Return iPalletID
            Catch ex As Exception
                Throw ex
            Finally
                Me.DisposeDT(dt)
                Me.DisposeDT(dt1)
            End Try
        End Function

        Public Function FormatDateShort(ByVal valStartDate As Date) As String
            FormatDateShort = ""
            Dim vMnth As String
            Dim vDay As String
            Dim vYear As String
            Dim valDate As Date
            valDate = valStartDate
            vMnth = DatePart(DateInterval.Month, valDate)
            vDay = DatePart(DateInterval.Day, valDate)
            If Len(vDay) < 2 Then vDay = "0" & vDay
            If Len(vMnth) < 2 Then vMnth = "0" & vMnth
            vYear = DatePart(DateInterval.Year, valDate)
            FormatDateShort = vYear & "-" & vMnth & "-" & vDay
        End Function


        '***************************************************
        'Auto-ship RW pallet
        '***************************************************
        Public Function ShipReworkPallet(ByVal strFilePath As String, _
                                         ByVal strUserName As String, _
                                         ByVal iUser_id As Integer, _
                                         ByVal iWCLocation_ID As Integer, _
                                         ByVal iLine_ID As Integer, _
                                         ByVal iGroup_ID As Integer, _
                                         ByVal iShift_ID As Integer, _
                                         ByVal iCust_id As Integer, _
                                         ByVal dtWo As DataTable) As Integer
            Dim strSql As String = ""
            Dim i, j, p, itempPallet_ID, iProdID As Integer
            Dim strDevsID As String = ""
            Dim objMisc As New Buisness.Misc()
            Dim objBulkship As New Buisness.BulkShipping()
            Dim R1 As DataRow
            Dim iOverpack_ID, iShip_ID As Integer
            Dim strWorkDate As String = ""
            Dim dtProdID As DataTable

            Try
                '*********************************************
                'Set Bulk Ship global variable
                '*********************************************
                objBulkship.iCust_ID = iCust_id
                objBulkship.iGroup_ID = iGroup_ID
                objBulkship.iLoc_ID = Me.dtRef.Rows(0)("loc_id")
                objBulkship.dtWO = dtWo
                objBulkship.struser = strUserName
                objBulkship.iShiftID = iShift_ID
                objBulkship.iBulkShipped = 2    'Rework

                '***************************************************
                ' Define work date
                '***************************************************
                If iShift_ID = 0 Then Throw New Exception("System can't define shift ID.")
                strWorkDate = Generic.GetWorkDate(iShift_ID)
                If strWorkDate.Trim.Length = 0 Then Throw New Exception("System can't define work date.")
                '***************************************************

                If Me.dtRef.Rows.Count > 0 Then
                    itempPallet_ID = Me.CreateRWPalletName(iGroup_ID, "REF", iCust_id, dtWo, Me.dtRef.Rows(0)("model_id"))

                    If Me.iRefPallet_id = 0 Then
                        Throw New Exception("Pallet ID missing.")
                    End If
                    dtProdID = objBulkship.GetProdIDInPallet(iRefPallet_id)
                    If dtProdID.Rows.Count = 1 Then iProdID = CInt(dtProdID.Rows(0)("Prod_ID")) Else iProdID = 0
                    '*********************************************
                    'Step 1: Set Bulk Ship global variable
                    '*********************************************
                    objBulkship.iPallet_ID = Me.iRefPallet_id
                    objBulkship.strFilePath = strFilePath & Me.strRefPalletName & ".xls"
                    objBulkship.iShipType = 0   'Ref pallet
                    '*****************************************************
                    ''Step 2:: Create Overpack
                    '*****************************************************
                    iOverpack_ID = objBulkship.CreateOverPack(strWorkDate)
                    '*****************************************************
                    ''Step 3:: Create Masterpack
                    '*****************************************************
                    iShip_ID = objBulkship.CreateMasterPack(iOverpack_ID, iRefPallet_id, iProdID, )
                    'objBulkship.iShiftID = iShip_ID
                    '*****************************************************
                    For Each R1 In Me.dtRef.Rows
                        p += objMisc.UpdateDeviceWithPallet(R1("device_sn"), Me.iRefPallet_id, strWorkDate, iUser_id, iWCLocation_ID, iLine_ID, iGroup_ID)
                        '*************************************
                        ''Step 4:: Update tdevice table
                        '*************************************
                        i += objBulkship.UpdateDevice(R1("Device_id"), iProdID, iShip_ID, 5, strWorkDate, 1)
                        '*************************************
                        ''Step 5:: Update Repair Status
                        '*************************************
                        j += objBulkship.UpdateRepairStatus(R1("Device_id"))
                        '*************************************
                    Next R1

                    '*************************************
                    ''Step 7:: Update Pallet Ship Status
                    '*************************************
                    j = objBulkship.UpdatePalletShipStatus(0, Me.dtRef.Rows.Count, strWorkDate)
                    '*************************************
                    ''Step 7:: Close palett and create excel.
                    '*************************************
                    i = objMisc.ClosePallet(iCust_id, Me.iRefPallet_id, Me.strRefPalletName, Me.dtRef.Rows.Count, objBulkship.iShipType, 1, )
                    GC.Collect()
                    GC.WaitForPendingFinalizers()
                    System.Windows.Forms.Application.DoEvents()
                    '*************************************
                    ''Step 8:: Print Report (Exel)
                    '*************************************

                    If iGroup_ID = 14 Then
                        j = objBulkship.PrintExcelFile(strFilePath & Me.strRefPalletName & ".xls")
                        j = objBulkship.PrintExcelFile(strFilePath & Me.strRefPalletName & ".xls")
                    Else
                        j = objBulkship.PrintExcelFile(strFilePath & Me.strRefPalletName & ".xls")
                    End If
                    '*************************************
                End If

                System.Windows.Forms.Application.DoEvents()

                R1 = Nothing

                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                'Process RUR
                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                If Me.dtRUR.Rows.Count > 0 Then
                    itempPallet_ID = Me.CreateRWPalletName(iGroup_ID, "RUR", iCust_id, dtWo, Me.dtRUR.Rows(0)("model_id"))

                    If Me.iRURPallet_id = 0 Then
                        Throw New Exception("Pallet ID missing.")
                    End If
                    dtProdID = objBulkship.GetProdIDInPallet(iRefPallet_id)
                    If dtProdID.Rows.Count = 1 Then iProdID = CInt(dtProdID.Rows(0)("Prod_ID")) Else iProdID = 0
                    '*********************************************
                    'Step 1: Set Bulk Ship global variable
                    '*********************************************
                    objBulkship.iPallet_ID = Me.iRURPallet_id
                    objBulkship.strFilePath = strFilePath & Me.strRURPalletName & ".xls"
                    objBulkship.iShipType = 1   'RUR pallet
                    '*****************************************************
                    ''Step 2:: Create Overpack
                    '*****************************************************
                    iOverpack_ID = objBulkship.CreateOverPack(strWorkDate)
                    '*****************************************************
                    ''Step 3:: Create Masterpack
                    '*****************************************************
                    iShip_ID = objBulkship.CreateMasterPack(iOverpack_ID, iRURPallet_id, iProdID, )
                    'objBulkship.iShiftID = iShip_ID
                    '*****************************************************
                    For Each R1 In Me.dtRUR.Rows
                        p += objMisc.UpdateDeviceWithPallet(R1("device_sn"), Me.iRURPallet_id, strWorkDate, iUser_id, iWCLocation_ID, iLine_ID, iGroup_ID)
                        '*************************************
                        ''Step 4:: Update tdevice table
                        '*************************************
                        i += objBulkship.UpdateDevice(R1("Device_id"), iProdID, iShip_ID, 5, strWorkDate, 0)
                        '*************************************
                        ''Step 5:: Update Repair Status
                        '*************************************
                        j += objBulkship.UpdateRepairStatus(R1("Device_id"))
                        '*************************************
                    Next R1

                    '*************************************
                    ''Step 7:: Update Pallet Ship Status
                    '*************************************
                    j = objBulkship.UpdatePalletShipStatus(0, Me.dtRUR.Rows.Count, strWorkDate)
                    '*************************************
                    ''Step 7:: Close palett and create excel.
                    '*************************************
                    i = objMisc.ClosePallet(iCust_id, Me.iRURPallet_id, Me.strRURPalletName, objBulkship.iShipType, 1, )
                    GC.Collect()
                    GC.WaitForPendingFinalizers()
                    System.Windows.Forms.Application.DoEvents()
                    '*************************************
                    ''Step 8:: Print Report (Exel)
                    '*************************************
                    If iGroup_ID = 14 Then
                        j = objBulkship.PrintExcelFile(strFilePath & Me.strRURPalletName & ".xls")
                        j = objBulkship.PrintExcelFile(strFilePath & Me.strRURPalletName & ".xls")
                    Else
                        j = objBulkship.PrintExcelFile(strFilePath & Me.strRURPalletName & ".xls")
                    End If
                    '*************************************
                End If

                System.Windows.Forms.Application.DoEvents()

                R1 = Nothing

                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                'Process RTM
                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                If Me.dtRTM.Rows.Count > 0 Then
                    itempPallet_ID = Me.CreateRWPalletName(iGroup_ID, "RTM", iCust_id, dtWo, Me.dtRTM.Rows(0)("model_id"))

                    If Me.iRTMPallet_id = 0 Then
                        Throw New Exception("Pallet ID missing.")
                    End If

                    dtProdID = objBulkship.GetProdIDInPallet(iRefPallet_id)
                    If dtProdID.Rows.Count = 1 Then iProdID = CInt(dtProdID.Rows(0)("Prod_ID")) Else iProdID = 0
                    '*********************************************
                    'Step 1: Set Bulk Ship global variable
                    '*********************************************
                    objBulkship.iPallet_ID = Me.iRTMPallet_id
                    objBulkship.strFilePath = strFilePath & Me.strRTMPalletName & ".xls"
                    objBulkship.iShipType = 9   'RTM pallet
                    '*****************************************************
                    ''Step 2:: Create Overpack
                    '*****************************************************
                    iOverpack_ID = objBulkship.CreateOverPack(strWorkDate)
                    '*****************************************************
                    ''Step 3:: Create Masterpack
                    '*****************************************************
                    iShip_ID = objBulkship.CreateMasterPack(iOverpack_ID, iRTMPallet_id, iProdID)
                    'objBulkship.iShiftID = iShip_ID
                    '*****************************************************
                    For Each R1 In Me.dtRTM.Rows
                        p += objMisc.UpdateDeviceWithPallet(R1("device_sn"), Me.iRTMPallet_id, strWorkDate, iUser_id, iWCLocation_ID, iLine_ID, iGroup_ID)
                        '*************************************
                        ''Step 4:: Update tdevice table
                        '*************************************
                        i += objBulkship.UpdateDevice(R1("Device_id"), iProdID, iShip_ID, 5, strWorkDate, 0)
                        '*************************************
                        ''Step 5:: Update Repair Status
                        '*************************************
                        j += objBulkship.UpdateRepairStatus(R1("Device_id"))
                        '*************************************
                    Next R1

                    '*************************************
                    ''Step 6:: Update Pallet Ship Status
                    '*************************************
                    j = objBulkship.UpdatePalletShipStatus(0, Me.dtRTM.Rows.Count, strWorkDate)
                    '*************************************
                    ''Step 7:: Close palett and create excel.
                    '*************************************
                    i = objMisc.ClosePallet(iCust_id, Me.iRTMPallet_id, Me.strRTMPalletName, 1, objBulkship.iShipType)

                    GC.Collect()
                    GC.WaitForPendingFinalizers()
                    System.Windows.Forms.Application.DoEvents()
                    '*************************************
                    ''Step 8:: Print Report (Exel)
                    '*************************************
                    If iGroup_ID = 14 Then
                        j = objBulkship.PrintExcelFile(strFilePath & Me.strRTMPalletName & ".xls")
                        j = objBulkship.PrintExcelFile(strFilePath & Me.strRTMPalletName & ".xls")
                    Else
                        j = objBulkship.PrintExcelFile(strFilePath & Me.strRTMPalletName & ".xls")
                    End If
                End If

                System.Windows.Forms.Application.DoEvents()

                If Me.dtRef.Rows.Count > 0 Or Me.dtRUR.Rows.Count > 0 Or Me.dtRTM.Rows.Count > 0 Then
                    '*************************************
                    ''Step 9:: Close out workorders if any.
                    '*************************************
                    j = objBulkship.UpdateWOStatus(strWorkDate, 1)
                End If

                Return p
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtProdID)
                objMisc = Nothing : objBulkship = Nothing
                GC.Collect() : GC.WaitForPendingFinalizers()
            End Try
        End Function


        '***************************************************
        'Get Shipping pallett
        '***************************************************
        Public Function GetPallett_ID(ByVal strPallett_name As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "select * from tpallett where Pallett_Name = '" & strPallett_name & "';"

                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '***************************************************
        'Unship a device from rework pallett
        '***************************************************
        Public Function RemoveADeviceFromRWPallett(ByVal iGroup_id As Integer, _
                                                   ByVal strSN As String, _
                                                   ByVal drPallett As DataRow) As Integer
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim i As Integer = 0
            Dim j As Integer = 0
            Dim objBusinessMisc As New PSS.Data.Buisness.Misc()
            Dim objBulkShip As New PSS.Data.Buisness.BulkShipping()
            Dim strFilePath As String = ""

            Try
                '*************************
                'Assign report directory
                '*************************
                Select Case drPallett("cust_id")
                    Case 2019
                        strFilePath = "p:\dept\ATCLE\Palet packing list\"
                        'Case 2113
                        '    strFilePath = "p:\dept\Cellstar\Pallet packing list\"
                        'Case 2119
                        '    strFilePath = "p:\dept\Game Stop\Pallet packing list\"
                    Case Else
                        Throw New Exception("This sreen was designed to work for ATCLE rework pallet only. If you need to use this screen for different customer, contact IT.")
                End Select

                '******************************************
                'Step 1: Validate Device
                '******************************************
                strSql = "select * from tdevice where pallett_id = " & drPallett("pallett_id") & " and device_sn = '" & strSN & "';"
                Me.objMisc._SQL = strSql
                dt1 = objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    If dt1.Rows(0)("Device_Invoice") = 1 Then
                        MsgBox("Device already invoice, can not unship this device.", MsgBoxStyle.Critical, "Validate Serial Number")
                        Exit Function
                    End If
                Else
                    MsgBox("Serial Number either does not exist in the system or does not belong to the pallet.", MsgBoxStyle.Critical, "Validate Serial Number")
                    Exit Function
                End If

                '******************************************
                'Step 2: delete entry in tdailyproduction
                '******************************************
                strSql = "delete from tdailyproduction where device_id = " & dt1.Rows(0)("device_id") & ";"
                Me.objMisc._SQL = strSql
                i = Me.objMisc.ExecuteNonQuery
                '******************************************
                'Step 3: Unship device
                '******************************************
                strSql = "update tdevice, tcellopt " & Environment.NewLine
                strSql &= "set tdevice.Device_DateShip = NULL, " & Environment.NewLine
                strSql &= "tdevice.Device_ShipWorkDate  = NULL, " & Environment.NewLine
                strSql &= "tdevice.Ship_ID = NULL, tdevice.pallett_id = NULL, " & Environment.NewLine
                strSql &= "tdevice.Shift_ID_Ship = 0, tcellopt.Cellopt_WIPOwner = 5 " & Environment.NewLine
                strSql &= "where tdevice.device_id = tcellopt.device_id and " & Environment.NewLine
                strSql &= "tdevice.device_id = " & dt1.Rows(0)("device_id") & ";"
                Me.objMisc._SQL = strSql
                i = Me.objMisc.ExecuteNonQuery

                '***************************************
                'Step 4:: Close palett and create excel.
                '***************************************
                j = objBusinessMisc.ClosePallet(drPallett("cust_id"), drPallett("pallett_id"), drPallett("Pallett_name"), 1, drPallett("Pallet_ShipType"))

                GC.Collect()
                GC.WaitForPendingFinalizers()
                System.Windows.Forms.Application.DoEvents()
                '*****************************************
                'Step 4:: print excel.
                '*****************************************
                If iGroup_id = 14 Then
                    j = objBulkShip.PrintExcelFile(strFilePath & drPallett("Pallett_name") & ".xls")
                    j = objBulkShip.PrintExcelFile(strFilePath & drPallett("Pallett_name") & ".xls")
                Else
                    j = objBulkShip.PrintExcelFile(strFilePath & drPallett("Pallett_name") & ".xls")
                End If
                System.Windows.Forms.Application.DoEvents()

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                Me.DisposeDT(dt1)
                objBusinessMisc = Nothing
                objBulkShip = Nothing
            End Try
        End Function

    End Class
End Namespace