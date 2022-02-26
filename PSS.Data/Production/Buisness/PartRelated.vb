Option Explicit On 

Imports Microsoft.Data.Odbc
Imports System.Data.OleDb

Imports CrystalDecisions.CrystalReports.Engine

Namespace Buisness
    Public Class PartRelated
        Private _objDataProc As DBQuery.DataProc

#Region "General"

        '***************************************************
        Public Sub New()
            Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
        End Sub
        '***************************************************
        Protected Overrides Sub Finalize()
            Me._objDataProc = Nothing
            MyBase.Finalize()
        End Sub
        '***************************************************
        Private Sub NAR(ByVal o As Object)
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
            Catch
            Finally
                o = Nothing
            End Try
        End Sub


        '****************************************************************
        'This procedure deletes all items in a given table
        '****************************************************************
        Private Sub DeleteAllRecords(ByVal strTable As String)
            Dim strSQL As String = ""

            Try
                If Len(Trim(strTable)) = 0 Then
                    Throw New Exception("Buisness.PartRelated.DeleteAllRecords(): " & Environment.NewLine & "Table name need to be supplied to delete records from.")
                End If
                strSQL = "Delete from " & strTable & ";"
                Me._objDataProc.ExecuteNonQuery(strSQL)
            Catch ex As Exception
                Throw New Exception("Buisness.PartRelated.DeleteAllRecords(): " & Environment.NewLine & ex.Message.ToString)
            End Try
        End Sub


        '******************************************************************************************************************
        Private Function CreateLotName(ByVal strLocName As String, ByVal strDate As String, ByVal strModelDesc As String) As String
            Dim strLotName As String = ""

            Try
                strLotName = strLocName & "_" & strDate & "_" & strModelDesc.Replace(" ", "_")

                Return strLotName
            Catch ex As Exception
                Throw ex
            End Try
        End Function

#End Region

#Region "PreBill & Billing"

        '*****************************************************************
        Public Function GetPreBillLotNames() As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT DISTINCT PreBillLot_Name " & Environment.NewLine
                strSQL &= "FROM tprebilllotdata " & Environment.NewLine
                strSQL &= "WHERE PreBillLot_DispensedDate IS NULL " & Environment.NewLine
                strSQL &= "ORDER BY PreBillLot_Name"

                Return Me._objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************
        Public Function GetPreBillReportData() As DataTable
            Dim _Conn As OdbcConnection
            Dim MyCmd As OdbcCommand
            Dim MyDA As OdbcDataAdapter
            Dim strSQL As String
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim i As Integer = 0
            Dim strDT As String

            Try
                strDT = Generic.MySQLServerDateTime(1)

                strSQL = "SELECT DISTINCT A.PreBillLot_Name, C.Model_Desc, F.PSPrice_Number, F.PSPrice_Desc" & Environment.NewLine
                strSQL &= ", COUNT(F.PSPrice_Desc) AS BilledQty, '0' as NavQty, '0' as OnOrderQty, A.PreBillLot_Qty " & Environment.NewLine
                strSQL &= "FROM tprebilllotdata A " & Environment.NewLine
                strSQL &= "INNER JOIN tdevice B ON B.Device_ID = A.Device_ID " & Environment.NewLine
                strSQL &= "INNER JOIN tmodel C ON C.Model_ID = B.Model_ID " & Environment.NewLine
                strSQL &= "INNER JOIN tdevicebill D ON D.Device_ID = B.Device_ID " & Environment.NewLine
                strSQL &= "INNER JOIN tpsmap E ON E.Model_ID = C.Model_ID AND E.BillCode_ID = D.BillCode_ID " & Environment.NewLine
                strSQL &= "INNER JOIN lpsprice F ON F.PSPrice_ID = E.PSPrice_ID " & Environment.NewLine
                strSQL &= "INNER JOIN lbillcodes G ON G.BillCode_ID = D.BillCode_ID " & Environment.NewLine
                strSQL &= "WHERE A.PreBillLot_Inactive = 0 " & Environment.NewLine
                strSQL &= "AND A.PreBillLot_ShipCompleted = 0 " & Environment.NewLine
                strSQL &= "AND G.BillType_ID = 2 " & Environment.NewLine '1 is service, 2 is parts
                strSQL &= "GROUP BY  A.PreBillLot_Name, C.Model_Desc, F.PSPrice_Number, F.PSPrice_Desc" & Environment.NewLine
                strSQL &= "ORDER BY A.PreBillLot_Name, C.Model_Desc, F.PSPrice_Desc"

                dt1 = Me._objDataProc.GetDataTable(strSQL)

                ''_Conn = New OdbcConnection("DSN=Navision Database")
                ''_Conn.Open()
                ''MyDA = New OdbcDataAdapter()

                ''**************************************
                ''Get the Bin Content table from Navision
                '' and write to PSS database
                ''**************************************
                'Me.ImportBinContentFromNavisionToPSSI(_Conn, MyCmd, MyDA, strDT)
                ''**************************************
                ''Get the Bin table Info from Navision
                ''**************************************
                'Me.ImportBinFromNavisionToPSSI(_Conn, MyCmd, MyDA, strDT)
                ''**************************************
                ''Get the Item table Info from Navision
                ''**************************************
                'Me.ImportItemsFromNavisionToPSSI(_Conn, MyCmd, MyDA, strDT)

                Return dt1
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(_Conn) Then
                    If _Conn.State = ConnectionState.Open Then
                        _Conn.Close()
                    End If
                    _Conn.Dispose()
                    _Conn = Nothing
                End If
                If Not IsNothing(MyCmd) Then
                    MyCmd.Dispose()
                    MyCmd = Nothing
                End If
                If Not IsNothing(MyDA) Then
                    MyDA.Dispose()
                    MyDA = Nothing
                End If
            End Try
        End Function

        '*****************************************************************
        Public Function ClosePreBillLot(ByVal strLotName As String, _
                                        ByVal iUserID As Integer, _
                                        ByVal strWorkDate As String, _
                                        ByVal iNewWipOwner As Integer) As Integer
            Dim strSQL As String
            Dim strSvrDT As String = ""

            Try
                strSvrDT = Generic.MySQLServerDateTime(1)

                strSQL = "UPDATE tprebilllotdata, tcellopt " & Environment.NewLine
                strSQL &= "SET PreBillLot_Dispenser_ID = " & iUserID.ToString & Environment.NewLine
                strSQL &= ", PreBillLot_DispensedDate = '" & strWorkDate & "' " & Environment.NewLine
                strSQL &= ", PreBillLot_Inactive = 1 " & Environment.NewLine
                strSQL &= ", tcellopt.Cellopt_WIPOwnerOld = tcellopt.Cellopt_WIPOwner " & Environment.NewLine
                strSQL &= ", tcellopt.Cellopt_WIPOwner = " & iNewWipOwner & " " & Environment.NewLine
                strSQL &= ", tcellopt.Cellopt_WIPEntryDt = '" & strSvrDT & "' " & Environment.NewLine
                strSQL &= "WHERE tprebilllotdata.device_id =  tcellopt.Device_ID " & Environment.NewLine
                strSQL &= "AND PreBillLot_Name = '" & strLotName & "';"
                Return Me._objDataProc.ExecuteNonQuery(strSQL)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************
        Public Function GetPreBillLotStatus(ByVal strLotName As String, _
                                            ByVal iCurrentWip As Integer) As Integer
            Dim strSQL As String
            Dim dt1 As DataTable
            Dim iLotStatus As Integer

            Try
                strSQL = "SELECT DISTINCT PreBillLot_Inactive  " & Environment.NewLine
                strSQL &= "FROM tprebilllotdata " & Environment.NewLine
                strSQL &= "INNER JOIN tcellopt ON tprebilllotdata.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                strSQL &= "WHERE PreBillLot_Name = '" & strLotName & "' " & Environment.NewLine
                strSQL &= "AND tcellopt.Cellopt_WIPOwner = " & iCurrentWip & ";"
                dt1 = Me._objDataProc.GetDataTable(strSQL)

                If dt1.Rows.Count > 0 Then
                    iLotStatus = dt1.Rows(0)("PreBillLot_Inactive")
                Else
                    iLotStatus = -1
                End If

                Return iLotStatus
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '*****************************************************************
        Public Function RollBackPreBillLotToWaitingParts(ByVal strLotName As String, _
                                                         ByVal iUserID As Integer, _
                                                         ByVal strWorkDate As String, _
                                                         ByVal iWP_GrpID As Integer) As Integer
            Dim strSQL As String
            Dim strSvrDT As String = ""

            Try
                strSQL = "UPDATE tprebilllotdata, tcellopt " & Environment.NewLine
                strSQL &= "SET PreBillLot_RollbackUser_ID = " & iUserID.ToString & Environment.NewLine
                strSQL &= ", PreBillLot_RollbackDate = '" & strWorkDate & "' " & Environment.NewLine
                strSQL &= ", PreBillLot_Inactive = 0 " & Environment.NewLine
                strSQL &= ", PreBillLot_Dispenser_ID = 0 " & Environment.NewLine
                strSQL &= ", PreBillLot_DispensedDate = null " & Environment.NewLine
                strSQL &= ", PreBillLot_ShipCompleted = 0 " & Environment.NewLine
                strSQL &= ", tcellopt.Cellopt_WIPOwnerOld = tcellopt.Cellopt_WIPOwner " & Environment.NewLine
                strSQL &= ", tcellopt.Cellopt_WIPOwner = " & iWP_GrpID & "" & Environment.NewLine
                strSQL &= ", tcellopt.Cellopt_WIPEntryDt = now() " & Environment.NewLine
                strSQL &= "WHERE tprebilllotdata.device_id =  tcellopt.Device_ID " & Environment.NewLine
                strSQL &= "AND PreBillLot_Name = '" & strLotName & "';"
                Return Me._objDataProc.ExecuteNonQuery(strSQL)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************
        Public Sub GetInactivePreBillLotAndShipQty()
            Dim strSQL As String
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim objGen As Data.Buisness.Generic

            Try
                strSQL = "SELECT DISTINCT PreBillLot_Name, PreBillLot_Qty, 0 as ShipQty" & Environment.NewLine
                strSQL &= "FROM tprebilllotdata " & Environment.NewLine
                strSQL &= "WHERE tprebilllotdata.PreBillLot_Inactive = 1 " & Environment.NewLine
                strSQL &= "AND tprebilllotdata.PreBillLot_ShipCompleted = 0 " & Environment.NewLine
                strSQL &= "ORDER BY PreBillLot_Name asc; "
                dt1 = Me._objDataProc.GetDataTable(strSQL)

                If dt1.Rows.Count > 0 Then
                    objGen = New Data.Buisness.Generic()
                    For Each R1 In dt1.Rows
                        R1.BeginEdit()
                        R1("ShipQty") = Me.GetShipQty_OfPreBillLot(Trim(R1("PreBillLot_Name")))

                        If R1("PreBillLot_Qty") = R1("ShipQty") Then
                            strSQL = "UPDATE tprebilllotdata "
                            strSQL &= "SET PreBillLot_ShipCompleted = 1 "
                            strSQL &= "WHERE PreBillLot_Name = '" & R1("PreBillLot_Name") & "';"
                            Me._objDataProc.ExecuteNonQuery(strSQL)

                            R1.Delete()
                        End If

                        R1.EndEdit()
                    Next R1

                    dt1.AcceptChanges()

                    objGen.CreateExelReport(dt1, 0, , 1, 0, 0, 0, "")
                End If

            Catch ex As Exception
                Throw ex
            Finally
                objGen = Nothing
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Sub

        '*****************************************************************
        Public Function GetShipQty_OfPreBillLot(ByVal strPreBillLotName As String) As Integer
            Dim strSQL As String

            Try
                strSQL = "SELECT count(*) as cnt " & Environment.NewLine
                strSQL &= "FROM tdevice " & Environment.NewLine
                strSQL &= "INNER JOIN tprebilllotdata on tdevice.Device_ID = tprebilllotdata.Device_ID " & Environment.NewLine
                strSQL &= "WHERE tprebilllotdata.PreBillLot_Name = '" & strPreBillLotName & "' " & Environment.NewLine
                strSQL &= "AND tdevice.Device_DateShip is not null;"
                Return Me._objDataProc.GetIntValue(strSQL)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************
        Public Function CloseTodaysPreBill(ByVal iLocID As Integer, ByVal iUserID As Integer, ByVal iShiftID As Integer) As Integer
            Dim strSQL As String
            Dim dtModelData, dtDeviceData, dtOutput, dtRptOutput As DataTable
            Dim dsPreBill As DataSet
            Dim drel As DataRelation
            Dim drDeviceData(), drModelData, drOutput, drRptOutput As DataRow
            Dim i, j, iExists As Integer
            Dim objRpt As ReportDocument
            Dim strLotName, strDeviceIDs, strNow, str As String

            Try
                strLotName = "" : strDeviceIDs = "" : strNow = ""
                i = 0 : j = 0 : iExists = 0
                strNow = Generic.GetMySqlDateTime("%Y%m%d%H%m%s")
                '*******************************************************
                'Get model of open (no lot assigned) prebill devices
                '*******************************************************
                strSQL = "SELECT DISTINCT A.Model_ID, C.Model_Desc " & Environment.NewLine
                strSQL &= "FROM tdevice A " & Environment.NewLine
                strSQL &= "INNER JOIN tcellopt B ON A.Device_ID = B.Device_ID " & Environment.NewLine
                strSQL &= "INNER JOIN tmodel C ON C.Model_ID = A.Model_ID " & Environment.NewLine
                strSQL &= "WHERE A.Loc_ID = " & iLocID & Environment.NewLine
                strSQL &= "AND B.Cellopt_WIPOwner = 8 " & Environment.NewLine
                strSQL &= "AND B.HasPreBillLot = 0 " & Environment.NewLine
                strSQL &= "ORDER BY C.Model_Desc"
                dtModelData = Me._objDataProc.GetDataTable(strSQL)

                If Not IsNothing(dtModelData) Then
                    If dtModelData.Rows.Count > 0 Then

                        '**************************************
                        'Get all open prebill devices
                        '**************************************
                        strSQL = "SELECT A.Device_ID, A.Device_SN, A.Model_ID " & Environment.NewLine
                        strSQL &= "FROM tdevice A " & Environment.NewLine
                        strSQL &= "INNER JOIN tcellopt B ON A.Device_ID = B.Device_ID " & Environment.NewLine
                        strSQL &= "WHERE A.Loc_ID = " & iLocID & Environment.NewLine
                        strSQL &= "AND B.Cellopt_WIPOwner = 8 " & Environment.NewLine
                        strSQL &= "AND B.HasPreBillLot = 0 " & Environment.NewLine
                        strSQL &= "ORDER BY A.Model_ID, A.Device_SN"

                        dtDeviceData = Me._objDataProc.GetDataTable(strSQL)

                        If Not IsNothing(dtDeviceData) Then
                            dsPreBill = New DataSet("PreBill Data")

                            dsPreBill.Tables.Add(dtModelData)
                            dsPreBill.Tables.Add(dtDeviceData)

                            drel = New DataRelation("Models to Devices", dtModelData.Columns("Model_ID"), dtDeviceData.Columns("Model_ID"))

                            dsPreBill.Relations.Add(drel)

                            'Create datatable for a lot
                            dtOutput = CreatePreBillOutputDataTable()

                            'Create and populate datatable for Crystal Report
                            dtRptOutput = CreatePreBillReportDataTable()

                            For Each drModelData In dtModelData.Rows
                                strLotName = CreateLotName(iLocID.ToString, strNow, drModelData("Model_Desc"))
                                drDeviceData = drModelData.GetChildRows("Models to Devices")

                                If drDeviceData.Length > 0 Then
                                    dtRptOutput.Clear()

                                    For i = 0 To drDeviceData.Length - 1
                                        '************************************************************************
                                        'Make sure there are no duplicates in the tprebilllotdata table
                                        '************************************************************************
                                        strSQL = "SELECT COUNT(*) AS Cnt " & Environment.NewLine
                                        strSQL &= "FROM tprebilllotdata " & Environment.NewLine
                                        strSQL &= "WHERE Device_ID = " & drDeviceData(i)("Device_ID")

                                        iExists = Me._objDataProc.GetIntValue(strSQL)

                                        If iExists > 0 Then
                                            MsgBox("This Device SN """ & drModelData("Device_SN") & """ has a lot assigned to it. Can not add to the new lot. Please contact IT immediately.")
                                        Else
                                            '***************************
                                            'Build Lot table
                                            '***************************
                                            drOutput = dtOutput.NewRow

                                            drOutput("PreBillLotName") = strLotName
                                            drOutput("DeviceID") = drDeviceData(i)("Device_ID")
                                            drOutput("UserID") = iUserID
                                            drOutput("ModelDesc") = drModelData("Model_Desc")
                                            drOutput("DeviceSN") = drDeviceData(i)("Device_SN").ToString
                                            drOutput("LotQty") = drDeviceData.Length.ToString

                                            dtOutput.Rows.Add(drOutput)
                                            dtOutput.AcceptChanges()

                                            '***************************
                                            'Build Report table
                                            '***************************
                                            drRptOutput = dtRptOutput.NewRow

                                            drRptOutput("PreBillLotName") = drOutput("PreBillLotName")
                                            drRptOutput("ModelDesc") = drOutput("ModelDesc")
                                            drRptOutput("DeviceSN") = drOutput("DeviceSN")
                                            drRptOutput("LotQty") = drOutput("LotQty")

                                            dtRptOutput.Rows.Add(drRptOutput)
                                            dtRptOutput.AcceptChanges()

                                            '***************************
                                            'Build Device ID
                                            '***************************
                                            If strDeviceIDs = "" Then
                                                strDeviceIDs &= drDeviceData(i)("Device_ID")
                                            Else
                                                strDeviceIDs &= ", " & drDeviceData(i)("Device_ID")
                                            End If
                                        End If

                                        iExists = 0
                                    Next i

                                    '***************************
                                    'Print the Crystal Report
                                    '***************************
                                    objRpt = New ReportDocument()

                                    With objRpt
                                        .Load(ConfigFile.GetBaseReportPath & "PreBillOpen Push.rpt")
                                        .SetDataSource(dtRptOutput)
                                        .PrintToPrinter(1, True, 0, 0)
                                        .Close()
                                    End With

                                    objRpt = Nothing
                                End If
                            Next drModelData

                            '*********************************
                            'Insert  data into tprebilllotdata
                            '*********************************
                            For Each drOutput In dtOutput.Rows
                                strSQL = "INSERT INTO tprebilllotdata ( " & Environment.NewLine
                                strSQL &= "PreBillLot_Name " & Environment.NewLine
                                strSQL &= ", Device_ID " & Environment.NewLine
                                strSQL &= ", PreBillLot_CreationDate " & Environment.NewLine
                                strSQL &= ", User_ID " & Environment.NewLine
                                strSQL &= ", PreBillLot_Inactive " & Environment.NewLine
                                strSQL &= ", PreBillLot_Qty " & Environment.NewLine
                                strSQL &= ") VALUES ( " & Environment.NewLine
                                strSQL &= "'" & drOutput("PreBillLotName") & "' " & Environment.NewLine
                                strSQL &= ", " & drOutput("DeviceID") & " " & Environment.NewLine
                                strSQL &= ", now() " & Environment.NewLine
                                strSQL &= ", " & drOutput("UserID") & " " & Environment.NewLine
                                strSQL &= ", 0 " & Environment.NewLine
                                strSQL &= ", " & drOutput("LotQty") & Environment.NewLine
                                strSQL &= ")"

                                j += Me._objDataProc.ExecuteNonQuery(strSQL)
                            Next drOutput

                            '*********************************
                            'Update HasPreBillLot in tcellopt
                            '*********************************
                            strSQL = "UPDATE tcellopt " & Environment.NewLine
                            strSQL &= "SET HasPreBillLot = 1 " & Environment.NewLine
                            strSQL &= "WHERE Device_ID in (" & strDeviceIDs & ")"

                            j += Me._objDataProc.ExecuteNonQuery(strSQL)
                            '*********************************
                        End If
                    End If
                End If

                Return j
            Catch ex As Exception
                Throw ex
            Finally
                drModelData = Nothing : drOutput = Nothing : drRptOutput = Nothing
                Generic.DisposeDT(dtModelData) : Generic.DisposeDT(dtDeviceData)
                Generic.DisposeDT(dtOutput) : Generic.DisposeDT(dtRptOutput)
            End Try
        End Function

        '******************************************************************************************************************
        Private Function CreatePreBillOutputDataTable() As DataTable
            Dim dt As DataTable

            Try
                dt = New DataTable("PreBill Output Data")

                dt.Columns.Add(New DataColumn("PreBillLotName", System.Type.GetType("System.String")))
                dt.Columns.Add(New DataColumn("DeviceID", System.Type.GetType("System.Int32")))
                dt.Columns.Add(New DataColumn("UserID", System.Type.GetType("System.Int32")))
                dt.Columns.Add(New DataColumn("ModelDesc", System.Type.GetType("System.String")))
                dt.Columns.Add(New DataColumn("DeviceSN", System.Type.GetType("System.String")))
                dt.Columns.Add(New DataColumn("LotQty", System.Type.GetType("System.Int32")))

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************************************************************
        Private Function CreatePreBillReportDataTable() As DataTable
            Dim dt As DataTable

            Try
                dt = New DataTable("PreBill Report Data")

                dt.Columns.Add(New DataColumn("PreBillLotName", System.Type.GetType("System.String")))
                dt.Columns.Add(New DataColumn("ModelDesc", System.Type.GetType("System.String")))
                dt.Columns.Add(New DataColumn("DeviceSN", System.Type.GetType("System.String")))
                dt.Columns.Add(New DataColumn("LotQty", System.Type.GetType("System.Int32")))

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function


        '******************************************************************************************************************
        Public Function GetPreBillLotBySN(ByVal strSN As String, ByVal iLocID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT tprebilllotdata.* " & Environment.NewLine
                strSql &= "FROM tdevice  " & Environment.NewLine
                strSql &= "INNER JOIN tprebilllotdata ON  tdevice.Device_ID = tprebilllotdata.Device_ID  " & Environment.NewLine
                strSql &= "WHERE tdevice.Loc_ID = " & iLocID & Environment.NewLine
                strSql &= "AND Device_sn = '" & strSN & "';"
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************
        Public Sub PrintPreBillLotDetailsRpt(ByVal strLotName As String)
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim objRpt As ReportDocument

            Try
                strSql = "SELECT PreBillLot_Name as PreBillLotName, Model_Desc as ModelDesc, Device_SN as DeviceSN, PreBillLot_Qty as LotQty" & Environment.NewLine
                strSql &= "FROM tprebilllotdata  " & Environment.NewLine
                strSql &= "INNER JOIN tdevice ON tprebilllotdata.Device_ID = tdevice.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "WHERE PreBillLot_Name = '" & strLotName & "';"
                dt1 = Me._objDataProc.GetDataTable(strSql)

                If dt1.Rows.Count > 0 Then
                    '***************************
                    'Print the Crystal Report
                    '***************************
                    objRpt = New ReportDocument()

                    With objRpt
                        .Load(ConfigFile.GetBaseReportPath & "PreBillOpen Push.rpt")
                        .SetDataSource(dt1)
                        .PrintToPrinter(1, True, 0, 0)
                        .Close()
                    End With
                End If
            Catch ex As Exception
                Throw ex
            Finally
                objRpt = Nothing
                Generic.DisposeDT(dt1)
            End Try
        End Sub

#End Region

#Region "Navision Related"

        '****************************************************************
        'This procedure imports Bin Content table in to PSS database
        '****************************************************************
        Public Function ImportBinContentFromNavisionToPSSI(ByRef _Conn As OdbcConnection, _
                                                           ByRef MyCmd As OdbcCommand, _
                                                           ByRef MyDA As OdbcDataAdapter, _
                                                           ByVal strDate As String) As Integer
            Dim strSql As String = ""
            Dim dt1 As New DataTable()
            Dim R1 As DataRow
            Dim i As Integer = 0
            Dim strBinCode As String = ""
            Dim strItemNo As String = ""
            Dim iQuantity As Integer = 0

            Try
                '**************************************
                'Get the Item table Info from Navision
                '**************************************
                strSql = "Select ""Bin Code"", ""Item No_"", Quantity from ""Bin Content"""
                MyCmd = New OdbcCommand(strSql, _Conn)
                MyDA.SelectCommand = MyCmd
                MyDA.Fill(dt1)

                MyCmd.Dispose()
                MyCmd = Nothing

                If dt1.Rows.Count > 0 Then
                    '**************************************
                    'Delete All  records from tnav_BinContent
                    '**************************************
                    DeleteAllRecords("tnav_BinContent")

                    '**************************************
                    'Insert in to PSS Database table tnav_BinContent
                    '**************************************
                    For Each R1 In dt1.Rows

                        If IsDBNull(R1("Bin Code")) Then
                            strBinCode = ""
                        Else
                            If Len(Trim(R1("Bin Code"))) = 0 Then
                                strBinCode = ""
                            Else
                                strBinCode = Replace(Replace(Trim(R1("Bin Code")), "'", "''"), """", """""")
                            End If
                        End If

                        If IsDBNull(R1("Item No_")) Then
                            strItemNo = ""
                        Else
                            If Len(Trim(R1("Item No_"))) = 0 Then
                                strItemNo = ""
                            Else
                                strItemNo = Replace(Replace(Trim(R1("Item No_")), "'", "''"), """", """""")
                            End If
                        End If

                        If IsDBNull(R1("Quantity")) Then
                            iQuantity = 0
                        Else
                            iQuantity = R1("Quantity")
                        End If

                        If Len(strBinCode) > 0 Then

                            strSql = ""
                            strSql = "Insert into tnav_BinContent " & Environment.NewLine
                            strSql &= "(Bin_Code, Item_No_, Quantity, ImportDate) " & Environment.NewLine
                            strSql &= "Values ('" & strBinCode & "', " & Environment.NewLine

                            If strItemNo = "" Then
                                strSql &= "NULL, " & Environment.NewLine
                            Else
                                strSql &= "'" & strItemNo & "', " & Environment.NewLine
                            End If

                            strSql &= iQuantity & ", " & Environment.NewLine
                            strSql &= "'" & strDate & "');"

                            i += Me._objDataProc.ExecuteNonQuery(strSql)

                        End If

                    Next R1
                    '**************************************
                End If

                Return i
            Catch ex As Microsoft.Data.Odbc.OdbcException
                Throw New Exception("Buisness.PartRelated.ImportBinContentFromNavisionToPSSI(): " & Environment.NewLine & "Could not connect to Navision.")
            Catch ex As Exception
                Throw New Exception("Buisness.PartRelated.ImportBinContentFromNavisionToPSSI(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '****************************************************************
        'This procedure imports Bin table in to PSS database
        '****************************************************************
        Public Function ImportBinFromNavisionToPSSI(ByRef _Conn As OdbcConnection, _
                                                    ByRef MyCmd As OdbcCommand, _
                                                    ByRef MyDA As OdbcDataAdapter, _
                                                    ByVal strDate As String) As Integer
            Dim strSql As String = ""
            Dim dt1 As New DataTable()
            Dim R1 As DataRow
            Dim i As Integer = 0
            Dim strCode As String = ""
            Dim strDesc As String = ""

            Try
                '**************************************
                'Get the Item table Info from Navision
                '**************************************
                strSql = "SELECT Code, Description FROM Bin "
                MyCmd = New OdbcCommand(strSql, _Conn)
                MyDA.SelectCommand = MyCmd
                MyDA.Fill(dt1)

                MyCmd.Dispose()
                MyCmd = Nothing

                If dt1.Rows.Count > 0 Then
                    '**************************************
                    'Delete All  records from tnav_BinContent
                    '**************************************
                    DeleteAllRecords("tnav_Bin")

                    '**************************************
                    'Insert in to PSS Database table tnav_BinContent
                    '**************************************
                    For Each R1 In dt1.Rows

                        If IsDBNull(R1("Code")) Then
                            strCode = ""
                        Else
                            If Len(Trim(R1("Code"))) = 0 Then
                                strCode = ""
                            Else
                                strCode = Trim(R1("Code"))
                            End If
                        End If

                        If IsDBNull(R1("Description")) Then
                            strDesc = ""
                        Else
                            If Len(Trim(R1("Description"))) = 0 Then
                                strDesc = ""
                            Else
                                strDesc = Replace(Trim(R1("Description")), "'", "")
                            End If
                        End If

                        If Len(strCode) > 0 Then
                            strSql = ""
                            strSql = "Insert into tnav_Bin " & Environment.NewLine
                            strSql &= "(Bin_Code, Bin_Desc, Bin_ImportDate) " & Environment.NewLine
                            strSql &= "Values ('" & strCode & "', '" & strDesc & "' , '" & strDate & "');" & Environment.NewLine

                            i += Me._objDataProc.ExecuteNonQuery(strSql)
                        End If

                    Next R1
                    '**************************************
                End If

                Return i
            Catch ex As Microsoft.Data.Odbc.OdbcException
                Throw New Exception("Buisness.PartRelated.ImportBinContentFromNavisionToPSSI(): " & Environment.NewLine & "Could not connect to Navision.")
            Catch ex As Exception
                Throw New Exception("Buisness.PartRelated.ImportBinContentFromNavisionToPSSI(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '****************************************************************
        'This procedure retrieves all Bench items from Navision and stores 
        'it in PSS database
        '****************************************************************
        Public Function ImportItemsFromNavisionToPSSI(ByRef _Conn As OdbcConnection, _
                                                      ByRef MyCmd As OdbcCommand, _
                                                      ByRef MyDA As OdbcDataAdapter, _
                                                      ByVal strDate As String) As Integer
            Dim strSql As String = ""
            Dim dt1 As New DataTable()
            Dim R1 As DataRow
            Dim i As Integer = 0
            Dim strDesc As String = ""
            Dim strShelfNo As String = ""
            Dim strNo As String = ""
            Dim iIndirectCost As Integer = 0
            Dim iQtyOnPurch As Integer = 0

            Try
                '**************************************
                'Get the Item table Info from Navision
                '**************************************
                strSql = "Select No_, Description, ""Shelf No_"", ""Indirect Cost %"", ""Qty_ on Purch_ Order"" as QtyOnPurch FROM Item"
                MyCmd = New OdbcCommand(strSql, _Conn)
                MyDA.SelectCommand = MyCmd
                MyDA.Fill(dt1)

                MyCmd.Dispose()
                MyCmd = Nothing

                If dt1.Rows.Count > 0 Then
                    '**************************************
                    'Delete All  records from tnav_item
                    '**************************************
                    DeleteAllRecords("tnav_item")

                    '**************************************
                    'Insert in to PSS Database table tnav_item
                    '**************************************
                    For Each R1 In dt1.Rows

                        If IsDBNull(R1("Description")) Then
                            strDesc = ""
                        Else
                            If Len(Trim(R1("Description"))) = 0 Then
                                strDesc = ""
                            Else
                                strDesc = Replace(Replace(Trim(R1("Description")), "'", "''"), """", """""")
                            End If
                        End If

                        If IsDBNull(R1("Shelf No_")) Then
                            strShelfNo = ""
                        Else
                            If Len(Trim(R1("Shelf No_"))) = 0 Then
                                strShelfNo = ""
                            Else
                                strShelfNo = Replace(Replace(Trim(R1("Shelf No_")), "'", "''"), """", """""")
                            End If
                        End If

                        If IsDBNull(R1("No_")) Then
                            strNo = ""
                        Else
                            If Len(Trim(R1("No_"))) = 0 Then
                                strNo = ""
                            Else
                                strNo = Replace(Replace(Trim(R1("No_")), "'", "''"), """", """""")
                            End If
                        End If

                        If IsDBNull(R1("Indirect Cost %")) Then
                            iIndirectCost = 0
                        Else
                            If Len(Trim(R1("Indirect Cost %"))) = 0 Then
                                iIndirectCost = 0
                            Else
                                iIndirectCost = R1("Indirect Cost %")
                            End If
                        End If

                        'iQtyOnPurch
                        If IsDBNull(R1("QtyOnPurch")) Then
                            iQtyOnPurch = 0
                        Else
                            If Len(Trim(R1("QtyOnPurch"))) = 0 Then
                                iQtyOnPurch = 0
                            Else
                                iQtyOnPurch = R1("QtyOnPurch")
                            End If
                        End If

                        If Len(strNo) > 0 Then
                            strSql = ""
                            strSql = "Insert into tnav_item " & Environment.NewLine
                            strSql &= "(No_, Description, Shelf_No_, MaxQty, QtyOnPurch, ImportDate) " & Environment.NewLine
                            strSql &= "Values ('" & strNo & "', " & Environment.NewLine

                            If strDesc = "" Then
                                strSql &= "NULL, " & Environment.NewLine
                            Else
                                strSql &= "'" & strDesc & "', " & Environment.NewLine
                            End If

                            If strShelfNo = "" Then
                                strSql &= "NULL, " & Environment.NewLine
                            Else
                                strSql &= "'" & strShelfNo & "', " & Environment.NewLine
                            End If

                            strSql &= iIndirectCost & ", " & Environment.NewLine
                            strSql &= iQtyOnPurch & ", " & Environment.NewLine
                            strSql &= "'" & strDate & "');"

                            i += Me._objDataProc.ExecuteNonQuery(strSql)
                        End If

                    Next R1
                    '**************************************
                End If

                Return i
            Catch ex As Microsoft.Data.Odbc.OdbcException
                Throw New Exception("PartRelated.ImportItemsFromNavisionToPSSI(): " & Environment.NewLine & "Could not connect to Navision.")
            Catch ex As Exception
                Throw New Exception("PartRelated.ImportItemsFromNavisionToPSSI(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function
#End Region

#Region "Parts Recovery"

        '******************************************************************************************************************

        Public Function InsertRemovePartRecovery(ByVal Device_ID As Integer, ByVal PSPrice_ID As Integer, ByVal UserID As Integer) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Try
                strSql = "SELECT * From PartRecovery" & Environment.NewLine
                strSql &= " where Device_ID=" & Device_ID & Environment.NewLine
                strSql &= " And PSPrice_ID=" & PSPrice_ID & Environment.NewLine
                dt = _objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    strSql = "Delete From PartRecovery" & Environment.NewLine
                    strSql &= " where Device_ID=" & Device_ID & Environment.NewLine
                    strSql &= " And PSPrice_ID=" & PSPrice_ID & Environment.NewLine
                    Return _objDataProc.ExecuteNonQuery(strSql)
                Else
                    strSql = "Insert PartRecovery (Device_ID,PSPrice_ID,TransUserID,TransDate) Values (" & Environment.NewLine
                    strSql &= Device_ID & "," & Environment.NewLine
                    strSql &= PSPrice_ID & "," & Environment.NewLine
                    strSql &= UserID & "," & Environment.NewLine
                    strSql &= " now())" & Environment.NewLine
                    Return _objDataProc.ExecuteNonQuery(strSql)
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '******************************************************************************************************************

        Public Function Label_PrintPartsRecoveryLabel(ByVal PartRecovery_ID As Integer)
            Dim strsql As String = ""
            Dim dtPartLabel As DataTable
            Dim rptDoc As New ReportDocument()
            Dim strRptPath As String = "P:\Dept\Labels\" & System.Net.Dns.GetHostName & "\"
            Const strRptName = "PartsRecovery.rpt"

            strsql = "Select PartRecovery_ID, PSPrice_Number, PSPrice_Desc " & Environment.NewLine
            strsql &= "From PartRecovery p " & Environment.NewLine
            strsql &= "Left join lpsprice l on p.PSPrice_ID=l.PSPrice_ID " & Environment.NewLine
            strsql &= "Where PartRecovery_ID=" & PartRecovery_ID & Environment.NewLine
            dtPartLabel = _objDataProc.GetDataTable(strsql)

            Try
                With rptDoc
                    .Load(strRptPath & strRptName)
                    If Not IsNothing(dtPartLabel) Then
                        .SetDataSource(dtPartLabel)
                        .PrintToPrinter(1, True, 0, 0)
                    End If
                    .Close()
                End With
            Catch ex As Exception
                Throw ex
            End Try
        End Function
#End Region


    End Class
End Namespace
