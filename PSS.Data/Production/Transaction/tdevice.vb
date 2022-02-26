Imports System
Imports System.Data
Imports eInfoDesigns.dbProvider.MySqlClient
Imports PSS.Data
Imports System.Data.OleDb

Namespace Production

    Public Class tdevice
        Inherits TableBase

        '//----------------------------------------------------------------------------------------------------
        '// Class Constructor (zero arguments)
        '// Overloaded:	No
        '//----------------------------------------------------------------------------------------------------

        'Public Sub New()
        '    '--- Set up the select statement
        '    Dim strSql As String = "SELECT * FROM tdevice"
        '    '--- Set up the Connection
        '    _conn = Connection.GetConnection
        '    '--- Set up the data adapter
        '    _da = GetDataAdapter(strSql, _conn)
        '    '//--- Destroy object

        '    '//Craig Haney
        '    _conn.Close()
        '    _conn.Dispose()
        '    '//Craig Haney

        '    _conn = Nothing
        'End Sub

        Public Shared Function GetDataTableByTray(ByVal Tray As Int32) As DataTable
            Dim strSql As String = "SELECT * FROM tdevice WHERE Tray_ID = " & Tray & ";"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function GetDataTableBySN(ByVal valSN As String) As DataTable
            Dim strSql As String = "SELECT * FROM tdevice WHERE Device_SN = '" & valSN & "'"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function GetDataTableBySNPretest(ByVal valSN As String) As DataTable
            Dim strSql As String = "SELECT * FROM tdevice WHERE Device_SN = '" & valSN & "' AND Device_DateShip is null and pallett_id is null;"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function GetDataTableBySNTray(ByVal valSN As String, ByVal valTray As String) As DataTable
            Dim strSql As String = "SELECT * FROM tdevice WHERE Device_SN = '" & valSN & "' AND Tray_ID = " & valTray & ";"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function GetDuplicateDeviceData(ByVal SerialNum As String, ByVal WO As Int32) As DataTable
            Dim strSql As String = "SELECT * FROM tdevice WHERE WO_ID = " & WO & " AND Device_SN = '" & SerialNum & "';"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function GetRowByPK(ByVal pkVAL As Int32) As DataRow
            Dim strSql As String = "SELECT * FROM tdevice WHERE Device_ID = " & pkVAL
            Dim objDataProc As DBQuery.DataProc
            Dim dt As DataTable

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                dt = objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then Return dt.Rows(0) Else Return Nothing
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        Public Shared Function GetDeviceDataByLocationByPO(ByVal valLoc As Int32) As DataTable
            Dim strSql As String = "Select tdevice* from ((tdevice INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID) INNER JOIN tmodel ON tdevice.model_id = tmodel.model_id) where tdevice.device_DateShip is null and tdevice.device_DateBill is not null and tdevice.loc_id	= " & valLoc & " and tworkorder.PO_ID is not null and tmodel.prod_id = 1;"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function GetDeviceDataByLocation(ByVal valLoc As Int32) As DataTable
            Dim strSql As String = "Select tdevice.device_sn, tdevice.wo_id, tdevice.device_id, tdevice.tray_id, tdevice.device_manufwrty, tmodel.manuf_id, tmodel.prod_id from (tdevice INNER JOIN tmodel ON tdevice.model_id = tmodel.model_id) where device_DateShip is null and device_DateBill is not null and tmodel.prod_id = 1 and loc_id	= " & valLoc & ";"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function GetDeviceDataByCustomer(ByVal valLoc As Int32) As DataTable
            Dim strSQL As String = "Select tdevice.*, tcustomer.cust_id, tlocation.loc_name, tmodel.manuf_id, tmodel.prod_id from ((((tdevice INNER JOIN tshipchange ON tdevice.Loc_ID = tshipchange.Loc_ID)INNER JOIN tlocation ON tshipchange.loc_id = tlocation.loc_id) INNER JOIN tcustomer ON tlocation.cust_id = tcustomer.cust_ID)INNER JOIN tmodel ON tdevice.model_id = tmodel.model_id) where device_DateShip is null and device_DateBill is not null and tmodel.prod_id = 1 and tshipchange.Loc_id_To	= " & valLoc & ";"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function GetDataTableByTrayOrdered(ByVal ID As Int32) As DataTable
            Dim strSql As String = "SELECT * FROM tdevice WHERE tray_Id = " & ID & " ORDER BY Device_ID;"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function GetDeviceHistory(ByVal DeviceSN As String) As DataTable
            Dim strSql = "SELECT * FROM tdevice WHERE Device_SN = '" & DeviceSN & "' ORDER BY Device_DateRec DESC;"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function RemoveDataRowByDevice(ByVal ID As Int32) As Boolean
            Dim strSQL As String = "DELETE FROM tdevice WHERE Device_Id = " & ID & ";"
            Dim objDataProc As DBQuery.DataProc

            Try
                RemoveDataRowByDevice = False
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                objDataProc.ExecuteNonQuery(strSQL)

                RemoveDataRowByDevice = True
                Return True
            Catch ex As Exception
                RemoveDataRowByDevice = False
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function UpdateBillDateByDevice(ByVal ID As Int32, ByVal vDate As String) As Boolean
            Dim strSQL As String = "UPDATE tdevice SET Device_DateBill = '" & vDate & "'  WHERE Device_Id = " & ID & ";"
            Dim objDataProc As DBQuery.DataProc

            Try
                UpdateBillDateByDevice = False
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                objDataProc.ExecuteNonQuery(strSQL)

                UpdateBillDateByDevice = True
                Return True
            Catch ex As Exception
                UpdateBillDateByDevice = False
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function ShippingUpdateShipID(ByVal aSQL As String) As Boolean
            Dim objDataProc As DBQuery.DataProc

            Try
                ShippingUpdateShipID = False
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                objDataProc.ExecuteNonQuery(aSQL)

                ShippingUpdateShipID = True
                Return True
            Catch ex As Exception
                ShippingUpdateShipID = False
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function UpdateManufWrtyOUT(ByVal vDeviceID As Int32) As Boolean
            Dim strSQL As String = "UPDATE tdevice SET Device_ManufWrty = 0 WHERE Device_Id = " & vDeviceID & ";"
            Dim objDataProc As DBQuery.DataProc

            Try
                UpdateManufWrtyOUT = False
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                objDataProc.ExecuteNonQuery(strSQL)

                UpdateManufWrtyOUT = True
                Return True
            Catch ex As Exception
                UpdateManufWrtyOUT = False
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function TrayTransferUpdateData(ByVal valDeviceSN As Array, ByVal cntDevice As Integer, ByVal valOldTray As Int32, ByVal valNewTray As Int32, ByVal valWOID As Int32) As Boolean
            Dim xCount As Integer = 0
            Dim objDataProc As DBQuery.DataProc

            Try
                TrayTransferUpdateData = False

                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                For xCount = 0 To cntDevice - 1
                    Dim strSQL As String = "UPDATE tdevice SET Tray_ID = " & valNewTray & " WHERE ( (tray_ID = " & valOldTray & ") AND (WO_ID = " & valWOID & ") AND (Device_SN = '" & valDeviceSN(xCount) & "'));"
                    objDataProc.ExecuteNonQuery(strSQL)
                Next

                TrayTransferUpdateData = True
                Return True
            Catch ex As Exception
                TrayTransferUpdateData = False
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function ReceivingTransmitDeviceData(ByVal valDataGrid As DataTable, ByVal aDeviceType As String, ByVal aRecType As String, ByVal vShift As Integer, ByVal vWorkdate As String) As Boolean
            Dim objDataProc As DBQuery.DataProc

            Dim tmpSKU, tmpCAP As String
            Dim tmpTray, tmpWO As String
            Dim rMetro As DataRow

            Dim intDevice As Int32
            Dim insDevice As New PSS.Data.Production.tdevice()

            Dim dsMetroRead, lkpReadMetro As DataTable
            Dim blnMetro As Boolean
            Dim dsMetro As New PSS.Data.Production.tdevicemetro()
            Dim lkpMetro As New PSS.Data.Production.lmetrocall()
            Dim dsUpdateSKU As New PSS.Data.Production.Joins()
            Dim rLoc As DataRow
            Dim dsLoc As New PSS.Data.Production.tlocation()
            Dim vUpdateSKU As Int32 = 0
            Dim vUpdateWO As Int32 = 0
            Dim vFreq As String

            Dim vChannel As String
            Dim vSKU As String
            Dim arrCapCode(1) As String
            Dim vWarranty As String = ""
            Dim ds As PSS.Data.Production.Joins
            Dim rDataGrid As DataRow
            rDataGrid = valDataGrid.Rows(0)
            rLoc = dsLoc.GetRowByPK(rDataGrid("DeviceLocationID"))

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                '//This section is created to replace previous section - June 9, 2005
                If rLoc("Cust_ID") = 1 Or rLoc("Cust_ID") = 503 Or rLoc("Cust_ID") = 504 Or rLoc("Cust_ID") = 508 Or rLoc("Cust_ID") = 511 Or rLoc("Cust_ID") = 512 Or rLoc("Cust_ID") = 1661 Or rLoc("Cust_ID") = 1662 Then
                    '//Get WO_CustWO value
                    Dim drWO As DataRow = PSS.Data.Production.tworkorder.GetRowByPK(rDataGrid("DeviceWOID"))
                    Dim vWOname As String = drWO("WO_CustWO")
                    '//Get data from new table

                    Dim drUSA As DataRow = GetRowByWOname(vWOname, objDataProc)

                    vWarranty = UCase(drUSA("USA_CapLow"))
                    If UCase(drUSA("USA_CapLow")) <> "WARRANTY" Then

                        Dim vPad As Integer = drUSA("USA_Pad")
                        vChannel = drUSA("USA_Channel")
                        'vSKU = drUSA("USA_SKU") Replaced July 14 to get finished goods sku
                        vSKU = drUSA("USA_FinishedGoodsSKU")

                        Dim vCapLow As Integer = CInt(drUSA("USA_CapLow"))
                        Dim vCapHigh As Integer = CInt(drUSA("USA_CapHigh"))


                        vFreq = drUSA("USA_Freq")
                        Dim tmpDeviceCount As Integer = valDataGrid.Rows.Count
                        ReDim arrCapCode(tmpDeviceCount)

                        System.Windows.Forms.Application.DoEvents()


                        Dim foundRow As DataRow

                        '//Build CapCode Array
                        Dim dsCapCode As New PSS.Data.Production.Joins()
                        Dim dtCapCode As DataTable = dsCapCode.OrderEntrySelect("SELECT deviceMetro_CapCode FROM tdevicemetro WHERE WO_ID = " & rDataGrid("DeviceWOID") & " ORDER BY deviceMetro_CapCode")
                        '//This is new because sometimes the tdevicemetro table is not receiving the wo_id
                        'Dim dtCapCode As DataTable = dsCapCode.OrderEntrySelect("SELECT deviceMetro_CapCode FROM tdevice inner join tdevicemetro on tdevice.device_sn = tdevicemetro.devicemetro_sn WHERE tdevice.WO_ID = " & rDataGrid("DeviceWOID") & " ORDER BY deviceMetro_CapCode")


                        'cdh September 23 2005
                        Dim arrPrimaryKey(0) As DataColumn
                        arrPrimaryKey(0) = dtCapCode.Columns(0)
                        dtCapCode.PrimaryKey = arrPrimaryKey
                        'cdh September 23 2005

                        Dim strCapCode As String

                        Dim drCapCode As DataRow
                        Dim xCapCodeStr As String
                        Dim xCapCodeCount, xdtCapCode As Integer
                        Dim xCapCode As Integer
                        Dim blnCapCode As Boolean
                        xCapCodeCount = 1

                        If vCapLow <> 0 Or vCapHigh <> 0 Then

                            For xCapCode = vCapLow To vCapHigh
                                blnCapCode = False


                                strCapCode = xCapCode.ToString.PadLeft(vPad, "0")

                                'cdh September 23 2005
                                foundRow = dtCapCode.Rows.Find(strCapCode)

                                'foundRow = dtCapCode.Rows.Find(xCapCode)
                                ' Print the value of column 1 of the found row.
                                If Not (foundRow Is Nothing) Then
                                    blnCapCode = True
                                End If
                                'cdh September 23 2005


                                'For xdtCapCode = 0 To dtCapCode.Rows.Count - 1
                                'drCapCode = dtCapCode.Rows(xdtCapCode)
                                'If CInt(drCapCode("devicemetro_CapCode")) = xCapCode Then
                                ''//CapCode is in use
                                'blnCapCode = True
                                'Exit For
                                'End If
                                'Next
                                If blnCapCode = False Then
                                    '//Add to array
                                    xCapCodeStr = xCapCode.ToString.PadLeft(vPad, "0")
                                    'arrCapCode(xCapCodeCount) = xCapCode
                                    arrCapCode(xCapCodeCount) = xCapCodeStr
                                    xCapCodeCount += 1
                                    If xCapCodeCount > tmpDeviceCount Then Exit For
                                End If
                                '//New July 15, 2005
                                If xCapCodeCount > 49 Then Exit For
                            Next

                        End If

                        '//May 30, 2006
                        If vCapLow = 0 And vCapHigh = 0 Then

                            Dim vFileLoc As String = drUSA("USA_CapCodeFILE")
                            '//Get record of capcodes

                            Dim sConnectionstring As String
                            Dim objConn As New OleDbConnection()
                            Dim objCmdSelect As New OleDbCommand()
                            Dim objAdapter1 As New OleDbDataAdapter()
                            Dim dt As New DataTable()
                            Dim objDataset1 As New DataSet()
                            Dim xCount As Integer = 0
                            Dim r As DataRow
                            Dim vResponse As String

                            Dim strFile As String

                            '//Assigned location of file

                            Dim dtCapCodeNew As New DataTable()

                            '//Create a datatable of all values from the assigned file
                            sConnectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\" & vFileLoc & ";Extended Properties=Excel 8.0;"
                            objConn.ConnectionString = sConnectionstring
                            objConn.Open()
                            objCmdSelect.CommandText = ("SELECT * FROM [Sheet1$]") '
                            objCmdSelect.Connection = objConn
                            objAdapter1.SelectCommand = objCmdSelect
                            objAdapter1.Fill(dtCapCodeNew)
                            objAdapter1.Fill(objDataset1, "XLData")

                            xCapCodeCount = 1
                            ReDim arrCapCode(valDataGrid.Rows.Count)

                            arrPrimaryKey(0) = dtCapCodeNew.Columns(0)
                            dtCapCodeNew.PrimaryKey = arrPrimaryKey

                            Dim countCap As Integer
                            Dim rcount As DataRow

                            For countCap = 0 To dtCapCodeNew.Rows.Count - 1
                                'For xCapCode = vCapLow To vCapHigh
                                rcount = dtCapCodeNew.Rows(countCap)
                                blnCapCode = False
                                'strCapCode = xCapCode.ToString.PadLeft(vPad, "0")
                                strCapCode = rcount("CapCode").ToString.PadLeft(vPad, "0")
                                foundRow = dtCapCode.Rows.Find(strCapCode)

                                If Not (foundRow Is Nothing) Then
                                    blnCapCode = True
                                End If

                                If blnCapCode = False Then
                                    '//Add to array
                                    xCapCodeStr = xCapCode.ToString.PadLeft(vPad, "0")
                                    'arrCapCode(xCapCodeCount) = xCapCodeStr
                                    arrCapCode(xCapCodeCount) = strCapCode
                                    xCapCodeCount += 1
                                    If xCapCodeCount > tmpDeviceCount Then Exit For
                                End If
                                If xCapCodeCount > 49 Then Exit For
                                'Next
                            Next
                        End If
                        '//May 30, 2006


                        'cdh September 23 2005
                        '//Check to see if there are enough cap codes for the tray being inserted. If not the4n exit routine
                        If xCapCodeCount < tmpDeviceCount Then
                            MsgBox("This tray does not have enough capcodes to be complete. It currently needs " & tmpDeviceCount = xCapCodeCount & " to complete this tray. Please correct this problem and reload this tray.", MsgBoxStyle.Critical, "ERROR")
                            Exit Function
                        End If
                        'cdh September 23 2005

                        System.Windows.Forms.Application.DoEvents()
                    End If
                End If  'August 3, 2005

                '//This section is created to replace previous section - June 9, 2005

                Try

                    Dim xCount As Integer = 0
                    Dim strSQLFieldList, strSQLValueList As String

                    For xCount = 0 To valDataGrid.Rows.Count - 1
                        rDataGrid = valDataGrid.Rows(xCount)

                        strSQLFieldList = "("
                        strSQLValueList = "("

                        'Concatenate the string
                        If Not IsDBNull(rDataGrid("CountID")) Then
                            strSQLFieldList += "Device_Cnt,"
                            strSQLValueList += rDataGrid("CountID") & ","
                        End If

                        If Not IsDBNull(rDataGrid("DeviceSN")) Then
                            strSQLFieldList += "Device_SN,"
                            strSQLValueList += "'" & rDataGrid("DeviceSN") & "',"
                        End If

                        If Not IsDBNull(rDataGrid("DeviceDateEntered")) Then
                            strSQLFieldList += "Device_DateRec,"
                            strSQLValueList += "'" & rDataGrid("DeviceDateEntered") & "',"
                        End If

                        If Not IsDBNull(rDataGrid("DeviceDateBilled")) Then
                            strSQLFieldList += "Device_DateBill,"
                            strSQLValueList += "'" & rDataGrid("DeviceDateBilled") & "',"
                        End If

                        If Not IsDBNull(rDataGrid("DeviceDateShipped")) Then
                            strSQLFieldList += "Device_DateShip,"
                            strSQLValueList += "'" & rDataGrid("DeviceDateShipped") & "',"
                        End If

                        If Not IsDBNull(rDataGrid("DeviceManufWrty")) Then
                            strSQLFieldList += "Device_ManufWrty,"
                            If rDataGrid("DeviceManufWrty") = "S" Then
                                strSQLValueList += "1,"
                            ElseIf rDataGrid("DeviceManufWrty") = "E" Then
                                strSQLValueList += "2,"
                            Else
                                strSQLValueList += "0,"
                            End If
                        End If

                        If Not IsDBNull(rDataGrid("DeviceDBR")) Then
                            strSQLFieldList += "Device_Reject,"
                            If rDataGrid("DeviceDBR") = 1 Then
                                strSQLValueList += "1,"
                            Else
                                strSQLValueList += "0,"
                            End If
                        End If

                        If Not IsDBNull(rDataGrid("DeviceLaborLevel")) Then
                            strSQLFieldList += "Device_LaborLevel,"
                            strSQLValueList += "'" & rDataGrid("DeviceLaborLevel") & "',"
                        End If

                        If Not IsDBNull(rDataGrid("DeviceLaborCharge")) Then
                            strSQLFieldList += "Device_LaborCharge,"
                            strSQLValueList += "'" & rDataGrid("DeviceLaborCharge") & "',"
                        End If

                        If Not IsDBNull(rDataGrid("DeviceOldSN")) Then
                            strSQLFieldList += "Device_OldSN,"
                            strSQLValueList += "'" & rDataGrid("DeviceOldSN") & "',"
                        End If

                        If Not IsDBNull(rDataGrid("DevicePSSwrty")) Then
                            strSQLFieldList += "Device_PSSwrty,"
                            If rDataGrid("DevicePSSwrty") = "Yes" Then
                                strSQLValueList += "1,"
                            Else
                                strSQLValueList += "0,"
                            End If
                        End If

                        If Not IsDBNull(rDataGrid("DeviceTrayID")) Then
                            strSQLFieldList += "Tray_ID,"
                            strSQLValueList += rDataGrid("DeviceTrayID") & ","
                        End If

                        If Not IsDBNull(vShift) Then
                            strSQLFieldList += "Shift_ID_Rec,"
                            strSQLValueList += vShift & ","
                        End If

                        If Not IsDBNull(vWorkdate) Then
                            strSQLFieldList += "Device_RecWorkdate,"
                            strSQLValueList += "'" & vWorkdate & "',"
                        End If

                        If Not IsDBNull(rDataGrid("DeviceWOID")) Then
                            strSQLFieldList += "WO_ID,"
                            strSQLValueList += rDataGrid("DeviceWOID") & ","
                            strSQLFieldList += "WO_ID_OUT,"
                            strSQLValueList += rDataGrid("DeviceWOID") & ","
                        End If

                        If Not IsDBNull(rDataGrid("DeviceModelID")) Then
                            strSQLFieldList += "Model_ID,"
                            strSQLValueList += rDataGrid("DeviceModelID") & ","
                        End If

                        If Not IsDBNull(rDataGrid("SKU")) Then
                            strSQLFieldList += "Sku_ID,"
                            strSQLValueList += rDataGrid("SKU") & ","
                            vUpdateSKU = rDataGrid("SKU")
                            vUpdateWO = rDataGrid("DeviceWOID")
                        End If

                        If Not IsDBNull(rDataGrid("DeviceLocationID")) Then
                            strSQLFieldList += "Loc_ID"
                            strSQLValueList += rDataGrid("DeviceLocationID")
                        End If


                        strSQLFieldList += ")"
                        strSQLValueList += ")"

                        Dim strSQL As String
                        strSQL = "INSERT INTO tdevice " & strSQLFieldList & " VALUES " & strSQLValueList
                        intDevice = insDevice.idTransDev(strSQL)

                        '********************************************
                        'Added by Lan on 10/18/2007
                        'Add an entry into tmessdata table
                        '********************************************
                        Try
                            strSQL = "INSERT INTO tmessdata " & Environment.NewLine
                            strSQL &= "( " & Environment.NewLine
                            strSQL &= "capcode, " & Environment.NewLine
                            strSQL &= "SKU, " & Environment.NewLine
                            strSQL &= "baud_id, " & Environment.NewLine
                            strSQL &= "freq_id, " & Environment.NewLine
                            strSQL &= "CameWithFileFlag, " & Environment.NewLine
                            strSQL &= "wo_id, " & Environment.NewLine
                            strSQL &= "device_id " & Environment.NewLine
                            strSQL &= " ) VALUES ( " & Environment.NewLine
                            strSQL &= "'" & tmpCAP & "', " & Environment.NewLine
                            strSQL &= "'" & tmpSKU & "', " & Environment.NewLine
                            strSQL &= "0, " & Environment.NewLine
                            strSQL &= "0, " & Environment.NewLine
                            strSQL &= "0, " & Environment.NewLine
                            strSQL &= rDataGrid("DeviceWOID") & ", " & Environment.NewLine
                            strSQL &= intDevice & Environment.NewLine
                            strSQL &= ");"
                            insDevice.idTransDev(strSQL)
                        Catch ex As Exception
                            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Add Device Info To Tmessdata")
                        Finally
                        End Try
                        '********************************************

                        If vUpdateSKU > 0 And vUpdateWO > 0 Then
                            Try
                                Dim blnSKUupdate As Boolean = dsUpdateSKU.OrderEntryUpdateDelete("UPDATE tworkorder set SKU_ID = " & vUpdateSKU & " WHERE wo_id = " & vUpdateWO)
                            Catch ex As Exception
                            End Try
                        End If


                        '//Verizon SBC processing Start
                        rLoc = dsLoc.GetRowByPK(rDataGrid("DeviceLocationID"))
                        '//Craig D Haney September 10, 2004
                        If rLoc("Cust_ID") = 14 Or rLoc("Cust_ID") = 20 Or rLoc("Cust_ID") = 16 Then
                            If UCase(vWarranty) <> "WARRANTY" Then 'August 3, 2005

                                Dim intMetro As Integer = 0
                                If Len(Trim(rDataGrid("DeviceSN"))) > 0 Then
                                    tmpTray = rDataGrid("DeviceTrayID")
                                    tmpWO = rDataGrid("DeviceWOID")
                                    tmpSKU = vSKU
                                    Dim dtVer As DataTable
                                    Dim rVer As DataRow
                                    tmpCAP = 0
                                    vFreq = 0
                                    Try
                                        dtVer = ds.OrderEntrySelect("SELECT * FROM tverdata INNER JOIN tworkorder ON tverdata.WO_Name = tworkorder.WO_CustWO WHERE Device_SN = '" & rDataGrid("DeviceSN") & "'")
                                        rVer = dtVer.Rows(0)
                                    Catch ex As Exception
                                        '//Insert record into detail table
                                    End Try
                                    If rLoc("Cust_ID") = 16 Then
                                        blnMetro = dsMetro.InsertDetailRecord2(rDataGrid("DeviceSN"), "0000", "XXXXXXFLXX", rDataGrid("DeviceModelID"), rDataGrid("DeviceTrayID"), rDataGrid("DeviceWOID"), "931.3375", "XXXXXXFLXX")
                                    Else
                                        blnMetro = dsMetro.InsertDetailRecord2(rDataGrid("DeviceSN"), rVer("Device_CapCode"), rVer("SKU_Number"), rDataGrid("DeviceModelID"), rDataGrid("DeviceTrayID"), rDataGrid("DeviceWOID"), rVer("Device_Freq"), tmpSKU)
                                    End If

                                End If
                            End If 'August 3, 2005
                        End If
                        '//Verizon SBC Processing - END


                        '//Metrocall processing - START
                        rLoc = dsLoc.GetRowByPK(rDataGrid("DeviceLocationID"))
                        '//Craig D Haney September 10, 2004
                        If rLoc("Cust_ID") = 1 Or rLoc("Cust_ID") = 503 Or rLoc("Cust_ID") = 504 Or rLoc("Cust_ID") = 508 Or rLoc("Cust_ID") = 511 Or rLoc("Cust_ID") = 512 Or rLoc("Cust_ID") = 1661 Or rLoc("Cust_ID") = 1662 Then
                            If UCase(vWarranty) <> "WARRANTY" Then 'August 3, 2005
                                Dim intMetro As Integer = 0
                                If Len(Trim(rDataGrid("DeviceSN"))) > 0 Then
                                    tmpTray = rDataGrid("DeviceTrayID")
                                    tmpWO = rDataGrid("DeviceWOID")
                                    tmpSKU = vSKU
                                    tmpCAP = arrCapCode(xCount + 1)
                                    '//Insert record into detail table

                                    blnMetro = dsMetro.InsertDetailRecord(rDataGrid("DeviceSN"), tmpCAP, tmpSKU, rDataGrid("DeviceModelID"), rDataGrid("DeviceTrayID"), rDataGrid("DeviceWOID"), vFreq)
                                End If
                            End If 'August 3, 2005
                        End If
                        '//Metrocall processing - END
                        System.Windows.Forms.Application.DoEvents()

                        Try

                            If aDeviceType = "2" Then

                                '//Perform insert into tcellopt
                                Dim strSQLFieldListCellOpt As String
                                Dim strSQLValueListCellOpt As String

                                strSQLFieldListCellOpt = "("
                                strSQLValueListCellOpt = "("

                                If Not IsDBNull(rDataGrid("DeviceMSN")) Then
                                    strSQLFieldListCellOpt += "CellOpt_MSN,"
                                    strSQLValueListCellOpt += "'" & rDataGrid("DeviceMSN") & "',"
                                    strSQLFieldListCellOpt += "CellOpt_OutMSN,"
                                    strSQLValueListCellOpt += "'" & rDataGrid("DeviceMSN") & "',"
                                End If

                                If Not IsDBNull(rDataGrid("DeviceCustFName")) Then
                                    strSQLFieldListCellOpt += "CellOpt_FName,"
                                    strSQLValueListCellOpt += "'" & rDataGrid("DeviceCustFName") & "',"
                                End If

                                If Not IsDBNull(rDataGrid("APCcode")) Then
                                    strSQLFieldListCellOpt += "CellOpt_APC,"
                                    strSQLValueListCellOpt += "'" & rDataGrid("APCcode") & "',"
                                End If

                                If Not IsDBNull(rDataGrid("DeviceCustLName")) Then
                                    strSQLFieldListCellOpt += "CellOpt_LName,"
                                    strSQLValueListCellOpt += "'" & rDataGrid("DeviceCustLName") & "',"
                                End If

                                If Not IsDBNull(rDataGrid("DevicePOPDate")) Then
                                    strSQLFieldListCellOpt += "CellOpt_POP,"
                                    strSQLValueListCellOpt += "'" & rDataGrid("DevicePOPDate") & "',"
                                End If

                                If Not IsDBNull(rDataGrid("DeviceProdCode")) Then
                                    strSQLFieldListCellOpt += "CellOpt_ProdCode,"
                                    strSQLValueListCellOpt += "'" & rDataGrid("DeviceProdCode") & "',"
                                End If

                                If Not IsDBNull(rDataGrid("DeviceDateCode")) Then
                                    strSQLFieldListCellOpt += "CellOpt_DateCode,"
                                    strSQLValueListCellOpt += "'" & rDataGrid("DeviceDateCode") & "',"
                                End If

                                If Not IsDBNull(rDataGrid("DeviceModelNum")) Then
                                    strSQLFieldListCellOpt += "CellOpt_ModleNumb,"
                                    strSQLValueListCellOpt += "'" & rDataGrid("DeviceModelNum") & "',"
                                End If

                                If Not IsDBNull(rDataGrid("CourTrackIN")) Then
                                    strSQLFieldListCellOpt += "CellOpt_Courier,"
                                    strSQLValueListCellOpt += "'" & rDataGrid("CourTrackIN") & "',"
                                End If

                                If Not IsDBNull(rDataGrid("TransactionCode")) Then
                                    strSQLFieldListCellOpt += "CellOpt_Transaction,"
                                    strSQLValueListCellOpt += "'" & rDataGrid("TransactionCode") & "',"
                                End If


                                If Not IsDBNull(rDataGrid("TransceiverCode")) Then
                                    strSQLFieldListCellOpt += "CellOpt_Transceiver,"
                                    strSQLValueListCellOpt += "'" & rDataGrid("TransceiverCode") & "',"
                                End If

                                If Not IsDBNull(rDataGrid("IncomingIMEI")) Then
                                    strSQLFieldListCellOpt += "CellOpt_IMEI,"
                                    strSQLValueListCellOpt += "'" & rDataGrid("IncomingIMEI") & "',"
                                    strSQLFieldListCellOpt += "CellOpt_OutIMEI,"
                                    strSQLValueListCellOpt += "'" & rDataGrid("IncomingIMEI") & "',"
                                End If

                                If Not IsDBNull(rDataGrid("CSNnumber")) Then
                                    strSQLFieldListCellOpt += "CellOpt_CSN,"
                                    strSQLValueListCellOpt += "'" & rDataGrid("CSNnumber") & "',"
                                    strSQLFieldListCellOpt += "CellOpt_OutCSN,"
                                    strSQLValueListCellOpt += "'" & rDataGrid("CSNnumber") & "',"
                                End If

                                If Not IsDBNull(rDataGrid("DeviceMIN")) Then
                                    strSQLFieldListCellOpt += "CellOpt_MIN,"
                                    strSQLValueListCellOpt += "'" & rDataGrid("DeviceMIN") & "',"
                                End If

                                If Not IsDBNull(rDataGrid("DeviceCarrModelCode")) Then
                                    strSQLFieldListCellOpt += "CellOpt_CarrModCode,"
                                    strSQLValueListCellOpt += "'" & rDataGrid("DeviceCarrModelCode") & "',"
                                End If

                                If Not IsDBNull(rDataGrid("AirTimeCarrierCode")) Then
                                    strSQLFieldListCellOpt += "CellOpt_AirCarrCode,"
                                    strSQLValueListCellOpt += "'" & rDataGrid("AirTimeCarrierCode") & "',"
                                End If

                                If Not IsDBNull(rDataGrid("DeviceComplaint")) Then
                                    strSQLFieldListCellOpt += "CellOpt_Complaint,"
                                    strSQLValueListCellOpt += "'" & rDataGrid("DeviceComplaint") & "',"
                                End If

                                If Not IsDBNull(rDataGrid("Decimal")) Then
                                    strSQLFieldListCellOpt += "CellOpt_CSN_Dec,"
                                    strSQLValueListCellOpt += "'" & rDataGrid("Decimal") & "',"
                                End If


                                Try
                                    If Not IsDBNull(rDataGrid("SoftVerIN")) Then
                                        strSQLFieldListCellOpt += "CellOpt_SoftVerIN,"
                                        strSQLValueListCellOpt += "'" & rDataGrid("SoftVerIN") & "',"
                                    End If
                                Catch ex As Exception
                                End Try
                                Try
                                    If Not IsDBNull(rDataGrid("SoftVerOUT")) Then
                                        strSQLFieldListCellOpt += "CellOpt_SoftVerOUT,"
                                        strSQLValueListCellOpt += "'" & rDataGrid("SoftVerOUT") & "',"
                                    End If
                                Catch ex As Exception
                                End Try
                                Try
                                    If Not IsDBNull(rDataGrid("AirTimeAmt")) Then
                                        strSQLFieldListCellOpt += "CellOpt_AirTime,"
                                        strSQLValueListCellOpt += "'" & rDataGrid("AirTimeAmt") & "',"
                                    End If
                                Catch ex As Exception
                                End Try
                                Try
                                    If Not IsDBNull(rDataGrid("SUG")) Then
                                        strSQLFieldListCellOpt += "CellOpt_SugIn,"
                                        strSQLValueListCellOpt += "'" & rDataGrid("SUG") & "',"
                                    End If
                                Catch ex As Exception
                                End Try
                                Try
                                    If Not IsDBNull(rDataGrid("SUG")) Then
                                        strSQLFieldListCellOpt += "CellOpt_SugOut,"
                                        strSQLValueListCellOpt += "'" & rDataGrid("SUG") & "',"
                                    End If
                                Catch ex As Exception
                                End Try

                                strSQLFieldListCellOpt += "CellOpt_RepairStatus,"
                                strSQLValueListCellOpt += "'ARP',"

                                '//New August, 22, 2006
                                If rLoc("Cust_ID") = 2113 Then
                                    '//This will set wip owner to Todd Smith for Brightpoint
                                    strSQLFieldListCellOpt += "CellOpt_WIPOwner,"
                                    strSQLValueListCellOpt += "3 ,"
                                End If
                                '//New August, 22, 2006


                                strSQLFieldListCellOpt += "Device_ID"
                                strSQLValueListCellOpt += CStr(intDevice)

                                strSQLFieldListCellOpt += ")"
                                strSQLValueListCellOpt += ")"

                                ''''''''''''''''''''''''''''''''''
                                strSQL = "INSERT INTO tcellopt " & strSQLFieldListCellOpt & " VALUES " & strSQLValueListCellOpt
                                objDataProc.ExecuteNonQuery(strSQL)

                                Try
                                    strSQL = "INSERT INTO tdevicecodes (Device_ID, Dcode_ID) VALUES (" & CStr(intDevice) & ", " & rDataGrid("AirTimeCarrierCode") & ")"
                                    objDataProc.ExecuteNonQuery(strSQL)
                                Catch ex As Exception
                                End Try

                                'Insert Transaction Code
                                Try
                                    strSQL = "INSERT INTO tdevicecodes (Device_ID, Dcode_ID) VALUES (" & CStr(intDevice) & ", " & rDataGrid("TransactionCode") & ")"
                                    objDataProc.ExecuteNonQuery(strSQL)
                                Catch ex As Exception
                                End Try

                                'Insert Complaint Code
                                Try
                                    strSQL = "INSERT INTO tdevicecodes (Device_ID, Dcode_ID) VALUES (" & CStr(intDevice) & ", " & rDataGrid("DeviceComplaint") & ")"
                                    objDataProc.ExecuteNonQuery(strSQL)
                                Catch ex As Exception
                                End Try

                                'Insert APC Code
                                Try
                                    strSQL = "INSERT INTO tdevicecodes (Device_ID, Dcode_ID) VALUES (" & CStr(intDevice) & ", " & rDataGrid("APCcode") & ")"
                                    objDataProc.ExecuteNonQuery(strSQL)
                                Catch ex As Exception
                                End Try

                                'Insert Repair Status Code
                                Try
                                    strSQL = "INSERT INTO tdevicecodes (Device_ID, Dcode_ID) VALUES (" & CStr(intDevice) & ", 580)"
                                    objDataProc.ExecuteNonQuery(strSQL)
                                Catch ex As Exception
                                End Try

                                'Insert Return Code
                                If Not IsDBNull(rDataGrid("ReturnCode")) Then
                                    Try
                                        strSQL = "INSERT INTO tdevicecodes (Device_ID, Dcode_ID) VALUES (" & CStr(intDevice) & ", " & rDataGrid("ReturnCode") & ")"
                                        objDataProc.ExecuteNonQuery(strSQL)
                                    Catch ex As Exception
                                    End Try
                                End If

                                ''cmd2.Dispose()
                                ''
                            End If
                        Catch exp As Exception
                            MsgBox(exp.tostring)
                            MsgBox("Cell information could not be written to options table. Data write is incomplete.", MsgBoxStyle.OKOnly, "ERROR")
                        End Try
                        '//NEW for cellular

                        Try
                            If rDataGrid("ReconcileID") > 0 Then
                                strSQL = "UPDATE lcustrec SET rec_date = '" & rDataGrid("DeviceDateEntered") & "' WHERE rec_id = " & rDataGrid("ReconcileID")
                                objDataProc.ExecuteNonQuery(strSQL)
                            End If
                        Catch exp As Exception
                        End Try

                        Try
                            If aRecType = "5" Then
                                strSQL = "UPDATE tstagedetail SET StageD_daterec = '" & rDataGrid("DeviceDateEntered") & "' WHERE StageD_SN = '" & rDataGrid("DeviceSN") & "' AND StageD_LocID = " & rDataGrid("DeviceLocationID")
                                objDataProc.ExecuteNonQuery(strSQL)
                            End If
                        Catch ex As Exception
                        End Try

                    Next

                    System.Windows.Forms.Application.DoEvents()

                    Return True
                Catch ex As Exception
                    'oTrans.Rollback()
                    MsgBox(ex.ToString())
                    System.Windows.Forms.Application.DoEvents()
                    Return False
                End Try

                System.Windows.Forms.Application.DoEvents()
            Catch ex As Exception
                Throw ex
            Finally
                insDevice = Nothing
                arrCapCode = Nothing    '//New Craig Haney July 15, 2005
                ds = Nothing
            End Try
        End Function

        Private Shared Function GetRowByWOname(ByVal vWOname As String, ByRef objDataProc As DBQuery.DataProc) As DataRow
            Dim strSql As String = "SELECT * FROM tusatest WHERE USA_WO = '" & Trim(vWOname) & "'"
            Dim dt As New DataTable()

            Try
                dt = objDataProc.GetDataTable(strSql)

                If (dt.Rows.Count > 0) Then Return dt.Rows(0) Else Return Nothing
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

    End Class
End Namespace