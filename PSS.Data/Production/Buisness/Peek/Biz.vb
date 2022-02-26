Option Explicit On 

Namespace Buisness.Peek
    Public Class Biz
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

        '******************************************************************
#End Region

        '*************************************************************************
        Public Function LoadDevices(ByVal strFilePath As String, ByVal iShiftID As Integer) As Integer
            Dim strArrHeader() = New String() {"Model", "IMEI", "SIM"}
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet
            Dim strModelDesc, strIMEI, strSim, strSimItemNo As String
            Dim i, iModelID, iDeviceID, iWOID, iTrayID, iSeqNo As Integer
            Dim objRec As New PSS.Data.Production.Receiving()

            Try
                strModelDesc = "" : strIMEI = "" : strSim = "" : strSimItemNo = "PK-SIM-001"
                i = 1 : iModelID = 0 : iDeviceID = 0 : iWOID = 10640091 : iTrayID = 1145657 : iSeqNo = 0

                objExcel = New Excel.Application()
                objBook = objExcel.Workbooks.Open(strFilePath)
                objSheet = objExcel.Worksheets(1)
                objExcel.Visible = False

                '**************************************
                'Validate header
                '**************************************
                If objSheet.range("A" & i).value.ToString().Trim <> strArrHeader(0) Then
                    Throw New Exception("Header in column A must be """ & strArrHeader(0) & """.")
                ElseIf objSheet.range("B" & i).value.ToString().Trim <> strArrHeader(1) Then
                    Throw New Exception("Header in column B must be """ & strArrHeader(1) & """.")
                ElseIf objSheet.range("C" & i).value.ToString().Trim <> strArrHeader(2) Then
                    Throw New Exception("Header in column C must be """ & strArrHeader(2) & """.")
                Else
                    i += 1

                    If Not IsNothing(objSheet.range("A" & i).value) Then strModelDesc = objSheet.range("A" & i).value.ToString.Trim
                    If Not IsNothing(objSheet.range("B" & i).value) Then strIMEI = objSheet.range("B" & i).value.ToString.Trim
                    If Not IsNothing(objSheet.range("C" & i).value) Then strSim = objSheet.range("C" & i).value.ToString.Trim

                    While strModelDesc.Length > 0 AndAlso strIMEI.Length > 0 'AndAlso strSim.Length > 0
                        iModelID = Me.GetModelID(strModelDesc)

                        If iModelID = 0 Then Throw New Exception("Model ID is missing for item # (" & strModelDesc & ").")

                        iSeqNo = objRec.GetNextDeviceCountInTray(iTrayID) + 1

                        '1:Write to tdevice
                        iDeviceID = objRec.InsertIntoTdevice(strIMEI, PSS.Data.Buisness.Generic.GetWorkDate(iShiftID), iSeqNo, iTrayID, 2977, iWOID, iModelID, iShiftID, , , , )
                        If iDeviceID = 0 Then Throw New Exception("System has failed to insert a record into tdevice.")

                        If strSim.Trim.Length > 0 Then Me.RecordDeviceAccessories(iDeviceID, strSimItemNo & "|" & strSim)

                        '**********************************
                        'Reset loop variable
                        '**********************************
                        i += 1 : iModelID = 0 : iDeviceID = 0 : iSeqNo = 0
                        strModelDesc = "" : strIMEI = "" : strSim = ""
                        If Not IsNothing(objSheet.range("A" & i).value) Then strModelDesc = objSheet.range("A" & i).value.ToString.Trim
                        If Not IsNothing(objSheet.range("B" & i).value) Then strIMEI = objSheet.range("B" & i).value.ToString.Trim
                        If Not IsNothing(objSheet.range("C" & i).value) Then strSim = objSheet.range("C" & i).value.ToString.Trim
                        '**********************************
                    End While
                End If

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(objSheet) Then
                    objSheet = Nothing
                    Generic.NAR(objSheet)
                End If
                If Not IsNothing(objBook) Then
                    objBook.Close()
                    objBook = Nothing
                    Generic.NAR(objBook)
                End If
                If Not IsNothing(objExcel) Then
                    objExcel.Quit()
                    objExcel = Nothing
                    Generic.NAR(objExcel)
                End If

                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '*************************************************************************
        Private Function GetModelID(ByVal strModelDesc As String) As Integer
            Dim strSql As String
            Try
                strSql = "SELECT Model_ID FROM tmodel WHERE Model_Desc = '" & strModelDesc & "'"
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************
        Public Function RecordDeviceAccessories(ByVal iDeviceID As Integer, _
                                                 ByVal strAccessories As String) As Integer
            Dim strSql As String
            Dim dt As DataTable

            Try
                strSql = "SELECT * FROM devicewithaccessories WHERE Device_ID = " & iDeviceID
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count = 0 Then
                    strSql = "INSERT INTO devicewithaccessories ( " & Environment.NewLine
                    strSql &= "Device_ID, AccPartsNoAndID " & Environment.NewLine
                    strSql &= ") VALUES (" & Environment.NewLine
                    strSql &= iDeviceID & ", '" & strAccessories & "' " & Environment.NewLine
                    strSql &= " ); "
                Else
                    strSql = "UPDATE devicewithaccessories " & Environment.NewLine
                    strSql &= "SET AccPartsNoAndID = '" & strAccessories & "'" & Environment.NewLine
                    strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                End If

                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '*************************************************************************
        Public Function GetReturnOpenWorkOrder(ByVal strCustWO As String, _
                                               ByVal iProdID As Integer, _
                                               ByVal iLocID As Integer) As DataTable
            Dim strSql As String
            Try
                strSql = "SELECT tworkorder.*, Tray_ID FROM tworkorder " & Environment.NewLine
                strSql &= "INNER JOIN ttray ON tworkorder.WO_ID = ttray.WO_ID " & Environment.NewLine
                strSql &= "WHERE OrderType_ID = 1 AND WO_Closed = 0 AND Loc_ID = " & iLocID & " AND Prod_ID = " & iProdID & Environment.NewLine
                strSql &= "AND WO_CustWO = '" & strCustWO & "'" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************
        Public Function GetPeekDevice(ByVal iLocID As Integer, _
                                      ByVal strDeviceSN As String) As DataTable
            Dim strSql As String
            Try
                strSql = "SELECT Model_Desc, CustomerReturn , tdevice.* FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                strSql &= "WHERE Device_DateShip is null AND tdevice.Loc_ID = " & iLocID & Environment.NewLine
                strSql &= "AND Device_SN = '" & strDeviceSN & "'" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************
        Public Function ReceiveDevice(ByVal iDeviceID As Integer, _
                                      ByVal strWkDate As String) As Integer
            Dim strSql As String
            Try
                strSql = "UPDATE tdevice SET Device_FinishedGoods = 1, Device_DateRec = now(), Device_RecWorkDate = '" & strWkDate & "'" & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************
        Public Function GetRecQty(ByVal iWOID As Integer) As Integer
            Dim strSql As String
            Try
                strSql = "Select count(*) as cnt FROM tdevice WHERE Device_FinishedGoods = 1 AND WO_ID = " & iWOID & Environment.NewLine
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************
        Public Function GetShipmentDetail(ByVal iPackingSlipID As Integer) As DataSet
            Dim strSql As String = ""
            Dim dtHandset, dtAccessories As DataTable
            Dim ds As DataSet

            Try
                ds = New DataSet()

                strSql = "SELECT Device_ID, Device_SN, tmodel.Model_ID, Accessory, 1 as 'Qty' " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "INNER JOIN tdevice ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID" & Environment.NewLine
                strSql &= "WHERE tpallett.pkslip_id = " & iPackingSlipID & " AND Accessory = 0" & Environment.NewLine
                strSql &= "ORDER BY Device_ID"
                dtHandset = Me._objDataProc.GetDataTable(strSql)
                dtHandset.TableName = "HandSet"

                ds.Tables.Add(dtHandset)

                strSql = "SELECT Device_ID, Device_SN, tmodel.Model_ID, Accessory" & Environment.NewLine
                strSql &= ", right( Device_SN, length(Device_SN) - INSTR(Device_SN, 'Q') )  as 'Qty' " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "INNER JOIN tdevice ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID" & Environment.NewLine
                strSql &= "WHERE tpallett.pkslip_id = " & iPackingSlipID & " AND Accessory > 0 " & Environment.NewLine
                strSql &= "ORDER BY Device_ID"
                dtAccessories = Me._objDataProc.GetDataTable(strSql)
                dtAccessories.TableName = "Accessory"

                ds.Tables.Add(dtAccessories)

                Return ds
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtHandset)
                Generic.DisposeDT(dtAccessories)
                If Not IsNothing(ds) Then
                    ds.Dispose()
                    ds = Nothing
                End If
            End Try
        End Function

        '*************************************************************************
        Public Function GetAccessoryLaborByVolume(ByVal iVolume As Integer, _
                                                  ByVal iCustID As Integer) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT * FROM laborpricebyvolume WHERE Cust_ID = " & iCustID & " AND VolumeStart <= " & iVolume & " AND VolumeEnd >= " & iVolume & " AND Accessory > 0 "
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************
        Public Function GetHandSetLaborByVolume(ByVal iVolume As Integer, _
                                                ByVal iCustID As Integer) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT * FROM laborpricebyvolume WHERE Cust_ID = " & iCustID & " AND VolumeStart <= " & iVolume & " AND VolumeEnd >= " & iVolume & " AND Accessory = 0 "
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************
        Public Function UpdateLabor(ByVal iDeviceID As Integer, _
                                    ByVal decLabor As Decimal, _
                                    ByVal iLaobrLevel As Integer) As Integer
            Dim strSql As String = ""
            Try
                strSql = "UPDATE tdevice SET Device_DateBill = now() " & Environment.NewLine
                strSql &= ", Device_LaborLevel = " & iLaobrLevel & Environment.NewLine
                strSql &= ", Device_LaborCharge = " & decLabor & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************
        Public Function GetNoneBillingPeekManifests() As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT DISTINCT tpackingslip.* FROM tpackingslip " & Environment.NewLine
                strSql &= "WHERE tpackingslip.Cust_ID = 2288 AND pkslip_id in (  3790, 3783,3784,3787,3786,3789,3791,3782,3783,3784 )" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************

#Region "Kitting Process"

        '*************************************************************************
        Public Shared Function GetModelListAndItemsID() As DataTable
            Dim strSql As String = ""
            Dim dtModel, dtNavItems As DataTable
            Dim R1, drItems() As DataRow

            Try
                dtModel = Generic.GetModels(1, 12, , )
                dtModel.Columns.Add(New DataColumn("ItemsID", System.Type.GetType("System.Int32")))
                dtModel.AcceptChanges()

                strSql = "SELECT * FROM items WHERE NavVendorNumber = 'V01123'; " & Environment.NewLine
                dtNavItems = Connection5.GetDataTable(strSql)

                For Each R1 In dtModel.Rows
                    If R1("Model_id") <> 0 Then
                        drItems = dtNavItems.Select("NavItemID = '" & R1("Model_desc") & "'")

                        If drItems.Length = 1 Then
                            R1.BeginEdit()
                            R1("ItemsID") = drItems(0)("ItemsID")
                            R1.EndEdit()
                        ElseIf drItems.Length > 1 Then
                            Throw New Exception("Duplicate item # " & R1("Model_desc") & " in Navision system.")
                        Else
                            Throw New Exception("Item # " & R1("Model_desc") & " is missing in Navision system.")
                        End If
                    End If
                Next R1

                Return dtModel
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtModel)
                Generic.DisposeDT(dtNavItems)
            End Try
        End Function

        '*************************************************************************
        Public Shared Function GetOpenInventorySNAndSimNo(ByVal strSN As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT B.NavItemID, A.InventorySNID, A.ItemsID, C.AccPartsNoAndID " & Environment.NewLine
                strSql &= "FROM InventorySN A " & Environment.NewLine
                strSql &= "INNER JOIN items B ON A.ItemsID = B.ItemsID" & Environment.NewLine
                strSql &= "INNER JOIN devicewithaccessories C ON A.InventorySNID = C.InventorySNID" & Environment.NewLine
                strSql &= "WHERE SerialNumber = '" & strSN & "' " & Environment.NewLine
                strSql &= "AND packingslipsdetailsID is null;"
                Return Connection5.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**********************************************************************
        Public Shared Function GetLatestInventorySNAndSimNo(ByVal strSN As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT B.NavItemID, A.InventorySNID, A.ItemsID, C.AccPartsNoAndID " & Environment.NewLine
                strSql &= "FROM InventorySN A " & Environment.NewLine
                strSql &= "INNER JOIN items B ON A.ItemsID = B.ItemsID" & Environment.NewLine
                strSql &= "INNER JOIN devicewithaccessories C ON A.InventorySNID = C.InventorySNID" & Environment.NewLine
                strSql &= "WHERE SerialNumber = '" & strSN & "' " & Environment.NewLine
                strSql &= "ORDER BY A.InventorySNID DESC LIMIT 1;"
                Return Connection5.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**********************************************************************
        Public Shared Function PrintLabel(ByVal iInventorySNID As Integer, _
                                          ByVal strSimNo As String) As Integer
            Const strReportName As String = "Peek Unit Box Label Push.rpt"
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                'Print Label
                strSql = "SELECT NavItemID as 'Model' , UPCCode " & Environment.NewLine
                strSql &= ", SerialNumber as 'IMEI', '" & strSimNo & "' as SIMNo  " & Environment.NewLine
                strSql &= "FROM InventorySN INNER JOIN Items ON InventorySN.ItemsID = Items.ItemsID " & Environment.NewLine
                strSql &= "WHERE InventorySNID = " & iInventorySNID & Environment.NewLine
                dt = Connection5.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then TracFone.clsMisc.PrintCrystalReportLabel(dt, strReportName, 1, )

                Return dt.Rows.Count

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '**********************************************************************
        Public Shared Function SaveItemsID(ByVal iInventorySNID As Integer, _
                                           ByVal iItemsID As Integer) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0

            Try
                strSql = "UPDATE InventorySN " & Environment.NewLine
                strSql &= "SET ItemsID = " & iItemsID & Environment.NewLine
                strSql &= "WHERE InventorySNID = " & iInventorySNID & Environment.NewLine
                strSql &= "AND PackingSlipsDetailsID is null;"
                i = Connection5.ExecuteNonQueries(strSql)
                If i = 0 Then Throw New Exception("System has failed save ItemsID.")

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**********************************************************************
        Public Shared Function SaveSimNo(ByVal iInventorySNID As Integer, _
                                         ByVal strSimNo As String) As Integer
            Const strSimItemNo As String = "PK-SIM-001"
            Dim strSql As String = ""
            Dim i As Integer = 0

            Try
                strSql = "UPDATE devicewithaccessories " & Environment.NewLine
                strSql &= "SET AccPartsNoAndID = '" & strSimItemNo & "|" & strSimNo & "'" & Environment.NewLine
                strSql &= "WHERE InventorySNID = " & iInventorySNID
                i = Connection5.ExecuteNonQueries(strSql)
                If i = 0 Then Throw New Exception("System has failed save sim #.")

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**********************************************************************
        Public Function GetDeviceInWipByIMEICustID(ByVal strIMEI As String, _
                                                   ByVal iCustID As Integer, _
                                                   ByVal iModelID As Integer, _
                                                   ByVal iShiftID As Integer) As DataTable
            Const iWOID As Integer = 10642661
            Const iTrayID As Integer = 1153096
            Const iPeekLocID As Integer = 2977
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim objRec As PSS.Data.Production.Receiving
            Dim iSeqNo, iDeviceID As Integer

            Try
                strSql = "SELECT Model_Desc, tdevice.* " & Environment.NewLine
                strSql &= "FROM tdevice INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID" & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "WHERE Device_DateShip is null AND Device_SN = '" & strIMEI & "'" & Environment.NewLine
                strSql &= "AND Cust_ID = " & iCustID
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count = 0 Then
                    iSeqNo = 0 : iDeviceID = 0
                    objRec = New PSS.Data.Production.Receiving()

                    'Insert record in tdevice
                    iSeqNo = objRec.GetNextDeviceCountInTray(iTrayID) + 1

                    '1:Write to tdevice
                    iDeviceID = objRec.InsertIntoTdevice(strIMEI, PSS.Data.Buisness.Generic.GetWorkDate(iShiftID), iSeqNo, iTrayID, 2977, iWOID, iModelID, iShiftID, , , , )
                    If iDeviceID = 0 Then Throw New Exception("System has failed to insert a record into tdevice.")

                    strSql = "SELECT Model_Desc, tdevice.* " & Environment.NewLine
                    strSql &= "FROM tdevice INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID" & Environment.NewLine
                    strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                    strSql &= "WHERE Device_DateShip is null AND Device_SN = '" & strIMEI & "'" & Environment.NewLine
                    strSql &= "AND Cust_ID = " & iCustID
                    dt = Me._objDataProc.GetDataTable(strSql)
                End If

                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                objRec = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Function

        '**********************************************************************
        Public Function SaveModelID(ByVal iDeviceID As Integer, _
                                    ByVal iModelID As Integer, _
                                    ByVal strSimNo As String) As Integer
            Const strSimItemNo As String = "PK-SIM-001"
            Dim strSql As String = ""
            Dim i As Integer = 0

            Try
                'Update Sim 
                If strSimNo.Trim.Length > 0 Then
                    strSql = "UPDATE devicewithaccessories " & Environment.NewLine
                    strSql &= "INNER JOIN tdevice ON devicewithaccessories.Device_ID = tdevice.Device_ID " & Environment.NewLine
                    strSql &= "SET AccPartsNoAndID = '" & strSimItemNo & "|" & strSimNo & "'" & Environment.NewLine
                    strSql &= "WHERE devicewithaccessories.Device_ID = " & iDeviceID & Environment.NewLine
                    strSql &= "AND Device_DateShip is null AND Pallett_ID is null "
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                End If

                'Update Model 
                strSql = "UPDATE tdevice SET Model_ID = " & iModelID & Environment.NewLine
                strSql &= "WHERE tdevice.Device_ID = " & iDeviceID & Environment.NewLine
                'strSql &= "AND Device_DateShip is null AND Pallett_ID is null"
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                If i = 0 Then Throw New Exception("System has failed to update model ID.")

                Return i

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**********************************************************************
        Public Function SetDeviceShipDate(ByVal iDeviceID As Integer, _
                                          ByVal iShiftID As Integer) As Integer
            Const strSimItemNo As String = "PK-SIM-001"
            Dim strSql As String = ""
            Dim i As Integer = 0

            Try
                'Update Model 
                strSql = "UPDATE tdevice SET Device_DateShip = now(), Device_ShipWorkDate = now(), Shift_ID_Ship = " & iShiftID & Environment.NewLine
                strSql &= "WHERE tdevice.Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "AND Device_DateShip is null AND Pallett_ID is null"
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                If i = 0 Then Throw New Exception("System has failed to update ship date.")

                Return i

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************
        Public Function GetLastInsertDeviceIDByIMEICustID(ByVal strIMEI As String, ByVal iCustID As Integer) As DataTable
            Dim strsql As String = ""
            Try
                strsql = "SELECT tdevice.* from tdevice " & Environment.NewLine
                strsql &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strsql &= "WHERE Device_SN = '" & strIMEI & "' AND Cust_ID = " & iCustID & Environment.NewLine
                strsql &= "ORDER BY Device_ID DESC LIMIT 1"
                Return Me._objDataProc.GetDataTable(strsql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************

#End Region

    End Class
End Namespace