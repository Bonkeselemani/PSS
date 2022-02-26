Imports CrystalDecisions.CrystalReports.Engine
Imports System.Windows.Forms

Namespace Buisness
    Public Class WarehouseReceive
        Private objMisc As Production.Misc
        Private _objDataProc As DBQuery.DataProc

        '******************************************************************
        Public Sub New()
            objMisc = New Production.Misc()
            Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
        End Sub
        '******************************************************************
        Protected Overrides Sub Finalize()
            objMisc = Nothing
            Me._objDataProc = Nothing
            MyBase.Finalize()
        End Sub

        '******************************************************************
        Private Sub NAR(ByVal o As Object)
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
            Catch
            Finally
                o = Nothing
            End Try
        End Sub

        '******************************************************************
        Public Function GetWHPalletInfo(ByVal strWHPallet_name As String, _
                                        ByVal iCust_id As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT Model_Desc, twarehousepallet.* " & Environment.NewLine
                strSql &= "FROM twarehousepallet " & Environment.NewLine
                strSql &= "INNER JOIN tmodel on twarehousepallet.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "WHERE twarehousepallet.WHPallet_Number = '" & strWHPallet_name & "' " & Environment.NewLine
                strSql &= "AND cust_id = " & iCust_id & " " & Environment.NewLine
                strSql &= "order by twarehousepallet.whpallet_id desc;"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataTable

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function LoadDeviceIntoWH(ByVal iWHPallet_id As Integer, _
                                         ByVal iMachineGroupID As Integer, _
                                         ByVal iUserID As Integer, _
                                         ByVal strManufDateCode As String, _
                                         ByVal iModel_ID As Integer, _
                                         ByVal strLot As String, _
                                         ByVal strSkid As String, _
                                         ByVal strSku As String, _
                                         ByVal strDevSN As String, _
                                         Optional ByVal iWHR_DevCondition As Integer = 0) As Integer
            Dim strFields As String = ""
            Dim strValues As String = ""
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim i As Integer = 0
            Dim strDateLoad As String = ""
            Dim objGen As New PSS.Data.Buisness.Generic()

            Try
                strDateLoad = objGen.MySQLServerDateTime(1)

                '*********************
                '1::Check WHPallet_id
                '*********************
                If iWHPallet_id = 0 Then
                    Throw New Exception("Warehouse pallet ID is missing. Can not receive this device into the system.")
                End If
                '************************************************
                '2:: Check if device already exist in this twarehousepalletload
                '************************************************
                strSql = "select count(*) as cnt from twarehousepalletload where WHP_PieceIdentifier = '" & strDevSN & "' and WHPallet_ID = " & iWHPallet_id & ";"
                Me.objMisc._SQL = strSql
                dt1 = Me.objMisc.GetDataTable

                If dt1.Rows(0)("cnt") > 0 Then
                    Throw New Exception("This Serial Number already scanned in.")
                End If

                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If

                '************************************************
                '3:: Check if device already exist in this twarehousereceive
                '************************************************
                strSql = "select count(*) as cnt from twarehousereceive where WHR_dev_SN = '" & strDevSN & "' and WHPallet_ID = " & iWHPallet_id & ";"
                Me.objMisc._SQL = strSql
                dt1 = Me.objMisc.GetDataTable

                If dt1.Rows(0)("cnt") > 0 Then
                    Throw New Exception("This Serial Number already scanned in.")
                End If

                '******************************************
                '4::insert device into twarehousepalletload
                '******************************************
                strSql = "INSERT INTO twarehousepalletload  " & Environment.NewLine
                strSql &= "( " & Environment.NewLine
                strSql &= "WHP_BinLocation, " & Environment.NewLine
                strSql &= "WHP_LoadNumber, " & Environment.NewLine
                strSql &= "WHP_PartNumber, " & Environment.NewLine
                strSql &= "WHP_PieceIdentifierOriginal, " & Environment.NewLine
                strSql &= "WHP_PieceIdentifier, " & Environment.NewLine
                strSql &= "WHP_DateLoaded, " & Environment.NewLine
                strSql &= "WHP_RcvdFlag, " & Environment.NewLine
                strSql &= "WHPallet_ID " & Environment.NewLine
                strSql &= ") " & Environment.NewLine
                strSql &= "VALUES " & Environment.NewLine
                strSql &= "( " & Environment.NewLine
                strSql &= "'" & strLot & "', " & Environment.NewLine
                strSql &= "'" & strSkid & "', " & Environment.NewLine
                strSql &= "'" & strSku & "', " & Environment.NewLine
                strSql &= "'" & strDevSN & "', " & Environment.NewLine
                strSql &= "'" & strDevSN & "', " & Environment.NewLine
                strSql &= "'" & strDateLoad & "', " & Environment.NewLine
                strSql &= "" & iMachineGroupID & ", " & Environment.NewLine
                strSql &= iWHPallet_id & " " & Environment.NewLine
                strSql &= ");"

                Me.objMisc._SQL = strSql
                i = Me.objMisc.ExecuteNonQuery

                '******************************************
                '5::insert device into twarehousereceive
                '******************************************
                strFields &= "WHR_Dev_SN " & Environment.NewLine
                strValues &= "'" & strDevSN & "' " & Environment.NewLine

                strFields &= ", WHR_Box_SN " & Environment.NewLine
                strValues &= ", null " & Environment.NewLine

                strFields &= ", WHR_DateLoaded " & Environment.NewLine
                strValues &= ", '" & strDateLoad & "' " & Environment.NewLine
                strFields &= ", WHR_WIPOwner " & Environment.NewLine
                strValues &= ", " & iMachineGroupID & " " & Environment.NewLine
                strFields &= ", User_ID " & Environment.NewLine
                strValues &= ", " & iUserID & " " & Environment.NewLine

                If iWHR_DevCondition > 0 Then
                    strFields &= ", WHR_DevCondition " & Environment.NewLine
                    strValues &= ", " & iWHR_DevCondition & " " & Environment.NewLine
                End If

                strFields &= ", WHPallet_ID " & Environment.NewLine
                strValues &= ", " & iWHPallet_id & " " & Environment.NewLine
                If strManufDateCode <> "" Then
                    strFields &= ", WHR_ManufDateCode " & Environment.NewLine
                    strValues &= ", '" & strManufDateCode & "' " & Environment.NewLine
                End If
                strFields &= ", Model_ID " & Environment.NewLine
                strValues &= ", " & iModel_ID & " " & Environment.NewLine

                strSql = "INSERT INTO twarehousereceive " & Environment.NewLine
                strSql &= "( " & Environment.NewLine
                strSql &= strFields
                strSql &= ") " & Environment.NewLine
                strSql &= "VALUES " & Environment.NewLine
                strSql &= "( " & Environment.NewLine
                strSql &= strValues
                strSql &= ");"
                Me.objMisc._SQL = strSql
                i = Me.objMisc.ExecuteNonQuery
                '******************************************
                Return i
            Catch ex As Exception
                Throw ex
            Finally
                objGen = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '******************************************************************
        Public Function CreateWHPallet(ByVal iCust_id As Integer, _
                                ByVal iModel_id As Integer, _
                                ByVal strModel_Desc As String, _
                                ByVal strLot As String, _
                                ByVal strSku As String, _
                                ByVal iSku_id As Integer, _
                                ByVal iFileQty As Integer, _
                                ByVal strDateLoadWorkDate As String) As Integer
            Dim strSql As String = ""
            Dim strFields As String = ""
            Dim strValues As String = ""
            Dim i As Integer = 0
            Dim strDateLoad As String = ""
            Dim objGen As New PSS.Data.Buisness.Generic()
            Dim dt1 As DataTable
            Dim strWHPallet_Number As String = ""
            Dim strSkidNum As String = ""
            Dim strModelSku As String = ""

            Try
                strDateLoad = objGen.MySQLServerDateTime(1)

                '*******************************
                'Define warehousepallet number
                '*******************************
                strModelSku = Me.GetModelMotosku(iModel_id)

                strSql = "Select WHP_skid " & Environment.NewLine
                strSql &= "FROM twarehousepallet " & Environment.NewLine
                strSql &= "WHERE Cust_ID = " & iCust_id & " " & Environment.NewLine
                strSql &= "AND WHP_Lot = '" & strLot & "'" & Environment.NewLine
                strSql &= "ORDER BY WHPallet_ID DESC;"
                dt1 = Me._objDataProc.GetDataTable(strSql)
                If dt1.Rows.Count = 0 Then
                    strSkidNum = "001"
                Else
                    strSkidNum = Format(dt1.Rows(0)("WHP_skid") + 1, "000")
                End If

                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If

                strWHPallet_Number = strModelSku & "L" & strLot & "S" & strSkidNum

                '**************************
                'Get if WHPallet exist
                '**************************
                strSql = "select WHPallet_ID  from twarehousepallet " & Environment.NewLine
                strSql &= "where WHPallet_Number = '" & strWHPallet_Number & "' and " & Environment.NewLine
                strSql &= "cust_id = " & iCust_id & " and model_id = " & iModel_id & ";"
                Me.objMisc._SQL = strSql
                dt1 = Me.objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    Throw New Exception("Pallet already existed in the system.")
                End If

                '**************************
                'Create Warehouse Pallet
                '**************************
                strFields &= "WHPallet_Number " & Environment.NewLine
                strValues &= "'" & strWHPallet_Number & "' " & Environment.NewLine

                If Len(Trim(strLot)) > 0 Then
                    strFields &= ", WHP_Lot " & Environment.NewLine
                    strValues &= ",'" & strLot & "' " & Environment.NewLine
                End If
                If Len(Trim(strSkidNum)) > 0 Then
                    strFields &= ", WHP_Skid " & Environment.NewLine
                    strValues &= ", '" & strSkidNum & "' " & Environment.NewLine
                End If
                If Len(Trim(strSku)) > 0 Then
                    strFields &= ", WHP_SKU " & Environment.NewLine
                    strValues &= ", '" & strSku & "' " & Environment.NewLine
                End If

                If iSku_id > 0 Then
                    strFields &= ", SKU_ID " & Environment.NewLine
                    strValues &= ", " & iSku_id & Environment.NewLine
                End If

                strFields &= ", Model_ID " & Environment.NewLine
                strValues &= ", " & iModel_id & " " & Environment.NewLine
                strFields &= ", WH_PalletType " & Environment.NewLine
                strValues &= ", 'Refurb' " & Environment.NewLine
                strFields &= ", WHDateLoaded " & Environment.NewLine
                strValues &= ", '" & strDateLoad & "' " & Environment.NewLine
                strFields &= ", WHWorkDateLoaded " & Environment.NewLine
                strValues &= ", '" & strDateLoadWorkDate & "' " & Environment.NewLine
                strFields &= ", WHPallet_NoBox " & Environment.NewLine
                strValues &= ", 1 " & Environment.NewLine
                strFields &= ", Cust_ID " & Environment.NewLine
                strValues &= ", " & iCust_id & Environment.NewLine
                strFields &= ", CameWithFileFlag " & Environment.NewLine
                strValues &= ", 0 " & Environment.NewLine
                strFields &= ", WHP_FileQty " & Environment.NewLine
                strValues &= ", " & iFileQty & Environment.NewLine


                strSql = "INSERT INTO twarehousepallet " & Environment.NewLine
                strSql &= "( " & Environment.NewLine
                strSql &= strFields
                strSql &= ") " & Environment.NewLine
                strSql &= "VALUES " & Environment.NewLine
                strSql &= "( " & Environment.NewLine
                strSql &= strValues
                strSql &= ");"

                Me.objMisc._SQL = strSql
                i = Me.objMisc.ExecuteNonQuery

                '************************************
                'Print Crystal Report
                '************************************
                Me.PrintPalletRpt(strWHPallet_Number, iFileQty, "Warehouse", strModel_Desc, New String() {"Warehouse Verification", "Production Verification", "Shipper Verification"}, 3)
                '************************************

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                objGen = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '******************************************************************
        Public Sub PrintPalletRpt(ByVal strWHPallet_Number As String, _
                                  ByVal iQty As Integer, _
                                  ByVal strType As String, _
                                  ByVal strResult As String, _
                                  ByVal strRptFooter() As String, _
                                  Optional ByVal iNumOfPrintOut As Integer = 1)
            Const strReportName As String = "Ship Pallet Label Push.rpt"
            Dim objDBRManifest As DBRManifest
            Dim objRpt As ReportDocument
            Dim dt1 As DataTable

            Try
                objDBRManifest = New DBRManifest()
                '************************************
                'Create Crystal Report
                '************************************

                dt1 = objDBRManifest.GetShipPalletData(strWHPallet_Number, iQty, strType, strResult, strRptFooter)

                If Not IsNothing(dt1) Then
                    objRpt = New ReportDocument()

                    With objRpt
                        .Load(PSS.Data.ConfigFile.GetBaseReportPath & strReportName)
                        .SetDataSource(dt1)
                        .PrintToPrinter(iNumOfPrintOut, True, 0, 0)
                    End With
                End If
                '************************************
            Catch ex As Exception
                MsgBox("Unable to print report.")
            Finally
                objDBRManifest = Nothing
                objRpt = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Sub

        '******************************************************************
        Public Function UpdateWHPallet(ByVal iWHPallet_ID As Integer, _
                                       ByVal strWHPallet_Number As String, _
                                       ByVal iModel_ID As Integer, _
                                       ByVal strModel_Desc As String, _
                                       ByVal iSku_ID As Integer, _
                                       ByVal strSku_Num As String, _
                                       ByVal iWHPallet_CountQty As Integer) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0

            Try
                strSql = "UPDATE twarehousepallet " & Environment.NewLine
                strSql &= "SET Model_ID = " & iModel_ID & Environment.NewLine
                strSql &= ", WHP_FileQty = " & iWHPallet_CountQty & Environment.NewLine
                strSql &= ", SKU_ID  = " & iSku_ID & Environment.NewLine
                strSql &= ", WHP_SKU = '" & strSku_Num & "'" & Environment.NewLine
                strSql &= "WHERE WHPallet_ID = " & iWHPallet_ID & ";"

                Me.objMisc._SQL = strSql
                i = Me.objMisc.ExecuteNonQuery

                '************************************
                'Print Crystal Report
                '************************************
                If i > 0 Then
                    Me.PrintPalletRpt(strWHPallet_Number, iWHPallet_CountQty, "Warehouse", strModel_Desc, New String() {"Warehouse Verification", "Production Verification", "Shipper Verification"})
                End If
                '************************************

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Sub IsDupl_WarehouseBucket(ByVal strDevice_sn As String, _
                                               ByVal iCust_ID As Integer, _
                                               ByVal iModel_ID As Integer, _
                                               ByVal strPalllet_number As String)
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim R1 As DataRow

            Try
                strSql = " SELECT WHPalletClosed, WHP_PalletRcvd, WHPallet_Number " & Environment.NewLine
                strSql &= "FROM twarehousepallet " & Environment.NewLine
                strSql &= "INNER JOIN twarehousepalletload on twarehousepallet.WHPallet_ID = twarehousepalletload.WHPallet_ID " & Environment.NewLine
                strSql &= "WHERE twarehousepalletload.WHP_PieceIdentifier = '" & strDevice_sn & "'" & Environment.NewLine
                strSql &= "AND Cust_ID = " & iCust_ID & " " & Environment.NewLine
                strSql &= "AND Model_ID = " & iModel_ID & ";"

                objMisc._SQL = strSql
                dt1 = objMisc.GetDataTable

                For Each R1 In dt1.Rows
                    If strPalllet_number.Trim.ToLower = R1("WHPallet_Number").ToString.Trim.ToLower Then
                        Throw New Exception("SN already scan in.")
                    ElseIf R1("WHPalletClosed") = 0 Or R1("WHP_PalletRcvd") = 0 Then
                        Throw New Exception("SN already belongs to a open warehouse pallet """ & R1("WHPallet_Number") & """.")
                    End If
                Next R1

            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                R1 = Nothing
            End Try
        End Sub

        '******************************************************************
        Public Function CloseWHPallet(ByVal strWHPallet_Number As String, _
                                      ByVal iWHPallet_id As Integer, _
                                      ByVal iRcvdQty As Integer, _
                                      ByVal iCntQty As Integer, _
                                      ByVal iCust_id As Integer, _
                                      ByVal iLoc_ID As Integer, _
                                      ByVal iProd_ID As Integer, _
                                      ByVal iMachineGroupID As Integer, _
                                      ByVal iShiftID As Integer, _
                                      ByVal iEmpNo As Integer, _
                                      ByVal iUserID As Integer, _
                                      ByVal strUserName As String, _
                                      ByVal strWorkDate As String, _
                                      ByVal dv As DataView, _
                                      Optional ByVal iWHPallet_Disc As Integer = 0, _
                                      Optional ByVal strModel_Desc As String = "") As Integer
            Dim strSql As String = ""
            Dim iWHPLoadQty As Integer = 0
            Dim iWHPRecQty As Integer = 0
            Dim i As Integer = 0
            Dim objDBRManifest As DBRManifest
            Dim objRpt As ReportDocument
            Dim dt, dt1 As DataTable
            ''Dim objGenBilling As PSS.Data.Buisness.GenerateBilling
            Dim objRec As Production.Receiving
            Dim iWO_ID As Integer = 0
            Dim iTray_ID As Integer = 0
            Dim R1 As DataRow
            Dim iCnt As Integer = 0
            Dim iDevice_ID As Integer = 0
            Dim booBilling As Boolean = False
            Dim iRefurbishedBillcode As Integer = 873
            Dim iCC_ID As Integer = 0

            Try
                '********************************************
                'check quantity of twarehousepalletload and twarehousereceive
                '********************************************
                iWHPLoadQty = Me.GetTotalWHLoad(iWHPallet_id)
                iWHPRecQty = Me.GetTotalWHRecDev(iWHPallet_id)
                If iWHPLoadQty <> iWHPRecQty Then
                    Throw New Exception("Quantity in twarehousepalletload table does not match with twarehousereceive table. Can not close this Pallet.")
                End If

                '********************************************
                'Update twarehousepallet
                '********************************************
                strSql = "UPDATE twarehousepallet " & Environment.NewLine
                strSql &= "SET WHP_CountedQty = " & iRcvdQty & Environment.NewLine
                strSql &= ", WHP_FileQty = " & iCntQty & Environment.NewLine
                strSql &= ", WHPalletClosed = 1 " & Environment.NewLine
                strSql &= ", WHP_PalletRcvd = 1 " & Environment.NewLine
                strSql &= ", WHPallet_Descrepency = " & iWHPallet_Disc & Environment.NewLine
                strSql &= "WHERE WHPallet_Number = '" & strWHPallet_Number & "' " & Environment.NewLine
                strSql &= "AND WHPallet_id = " & iWHPallet_id & " " & Environment.NewLine
                strSql &= "AND Cust_id = " & iCust_id & ";"
                objMisc._SQL = strSql
                i = objMisc.ExecuteNonQuery

                '************************************
                'Receive device into production
                '************************************
                objRec = New Production.Receiving()

                '************************
                '1:: Create WO
                '************************
                If iWO_ID = 0 Then
                    ''***************************************
                    ''Set model to group, REMINDER: CHANGE model_desc to model_id 
                    ''***************************************
                    'strSql = "SELECT a.model_id, model_desc, group_id from tmodeltogroup a" & Environment.NewLine
                    'strSql &= "INNER JOIN tmodel b on a.model_id = b.model_id" & Environment.NewLine
                    'strSql &= "WHERE model_desc = '" & strModel_Desc & "' and active = 1;"

                    'dt = _objDataProc.GetDataTable(strSql)
                    'If dt.Rows.Count = 1 Then
                    '    iMachineGroupID = dt.Rows(0)("group_id")
                    'ElseIf dt.Rows.Count > 1 Then
                    '    MessageBox.Show("There's duplicated model descriptions. Please contact IT", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    'End If
                    iWO_ID = objRec.InsertIntoTworkorder(strWHPallet_Number, _
                                                         strWHPallet_Number, _
                                                         iLoc_ID, _
                                                         iProd_ID, _
                                                         iMachineGroupID, _
                                                         , , , , CStr(dv.Table.Rows.Count), )
                End If
                If iWO_ID = 0 Then
                    Throw New Exception("System has failed to create 'Work Order'.")
                End If

                '***********************************
                '2:: Create Tray
                '***********************************
                iTray_ID = objRec.InsertIntoTtray(iUserID, strUserName, CStr(iWO_ID), )
                If iTray_ID = 0 Then
                    Throw New Exception("System has failed to create tray.")
                End If

                '***********************************
                'Loop through each device
                '***********************************
                If Not IsNothing(dv) Then
                    For Each R1 In dv.Table.Rows
                        iCnt += 1

                        '''************************
                        '''Define cost center
                        '''************************
                        ''If iCust_id = 2219 And R1("Model_ID") = 959 Then iCC_ID = 35 Else iCC_ID = 0

                        '************************
                        '3:: Insert into tdevice
                        '************************
                        iDevice_ID = objRec.InsertIntoTdevice(R1("Device SN"), _
                                                              strWorkDate, _
                                                              iCnt, _
                                                              iTray_ID, _
                                                              iLoc_ID, _
                                                              iWO_ID, _
                                                              R1("Model_ID"), _
                                                              iShiftID, _
                                                              0, , , iCC_ID)
                        If iDevice_ID = 0 Then
                            Throw New Exception("System has failed to insert into tdevice.")
                        End If

                        '************************
                        '4:: Insert into tcellopt
                        '************************
                        i = objRec.InsertIntoTCellopt(iDevice_ID, , , , , , , , , , , , , , )
                        If i = 0 Then
                            Throw New Exception("System has failed to insert into tcellopt.")
                        End If

                        If i = 0 Then
                            Throw New Exception("System has failed to write 'Customer Device ID' receive flag.")
                        End If

                        '******************************************
                        '5:: Update Device_ID in twarehousereceive
                        '******************************************
                        strSql = "UPDATE twarehousereceive SET Device_ID = " & iDevice_ID & " WHERE WHR_ID = " & R1("WHR_ID") & ";"
                        objMisc._SQL = strSql
                        i = objMisc.ExecuteNonQuery

                        '***************************
                        'Reset loop variable
                        '***************************
                        iDevice_ID = 0
                        '***************************
                    Next R1

                    ''''***************************
                    ''''Bill Refurb
                    ''''***************************
                    '''If iCust_id = 2219 AndAlso R1("Model_ID") <> 1175 Then     'Gamestop
                    '''    objGenBilling = New PSS.Data.Buisness.GenerateBilling()

                    '''    dt1 = Me._objDataProc.GetDataTable("Select * From tdevice where tray_id = " & iTray_ID)
                    '''    For Each R1 In dt1.Rows
                    '''        If Me.IsBillcodeExist(R1("Model_ID"), iRefurbishedBillcode) > 0 Then
                    '''            booBilling = objGenBilling.ab_ADD(R1("Device_ID"), iRefurbishedBillcode, iProd_ID, iUserID, strUserName, iEmpNo, iShiftID, strWorkDate)

                    '''            If booBilling = False Then
                    '''                Throw New Exception("System failed to bill ""billcode " & iRefurbishedBillcode & """ on ""device ID " & R1("Device_ID") & """")
                    '''            End If
                    '''        Else
                    '''            MessageBox.Show("Refurbished bill code is missing for this model. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '''        End If
                    '''    Next R1
                    '''End If
                    ''''***************************
                End If

                '************************************
                'print Crystal Report
                '************************************
                If iWHPallet_Disc = 1 Then
                    '************************************
                    'Print Crystal Report
                    '************************************
                    Me.PrintPalletRpt(strWHPallet_Number, iCntQty, strModel_Desc & " Discp", "Rcvd Qty: " & iRcvdQty, New String() {"Receiver Verification", "Production Verification", "Shipper Verification"})
                    '************************************
                End If

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing : objRec = Nothing
                ''objGenBilling = Nothing
                PSS.Data.Buisness.Generic.DisposeDT(dt)
                PSS.Data.Buisness.Generic.DisposeDT(dt1)
                If Not IsNothing(dv) Then
                    dv.Dispose()
                    dv = Nothing
                End If
            End Try
        End Function

        '**************************************************************
        Public Function IsBillcodeExist(ByVal iModel_ID As Integer, _
                                        ByVal iBillcode_ID As Integer) As Integer
            Dim strSql As String

            Try
                strSql = "Select count(*) from tpsmap where Model_ID = " & iModel_ID & " and billcode_id = " & iBillcode_ID & ";"
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetTotalWHLoad(ByVal iWHPallet_id As Integer) As Integer
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Try
                strSql = "select count(*) as cnt from twarehousepalletload where WHPallet_id = " & iWHPallet_id & ";"
                objMisc._SQL = strSql
                dt1 = objMisc.GetDataTable

                Return dt1.Rows(0)("cnt")

            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '******************************************************************
        Public Function GetTotalWHRecDev(ByVal iWHPallet_id As Integer) As Integer
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Try
                strSql = "select count(*) as cnt from twarehousereceive where WHPallet_id = " & iWHPallet_id & ";"
                objMisc._SQL = strSql
                dt1 = objMisc.GetDataTable

                Return dt1.Rows(0)("cnt")

            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '******************************************************************
        Public Function LoadRcvdDev(ByVal iWHPallet_id As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT twarehousepalletload.WHP_ID, twarehousereceive.WHR_ID, " & Environment.NewLine
                strSql &= "twarehousereceive.WHR_Dev_SN as 'Device SN', Model_Desc as Model, tmodel.Model_ID " & Environment.NewLine
                strSql &= "FROM twarehousereceive " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON twarehousereceive.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN twarehousepalletload ON  " & Environment.NewLine
                strSql &= "(twarehousereceive.WHPallet_ID = twarehousepalletload.WHPallet_ID   " & Environment.NewLine
                strSql &= "AND twarehousereceive.WHR_Dev_SN = twarehousepalletload.WHP_PieceIdentifier) " & Environment.NewLine
                strSql &= "WHERE twarehousepalletload.WHPallet_ID = " & iWHPallet_id & " " & Environment.NewLine
                strSql &= "ORDER BY WHR_ID desc;"
                objMisc._SQL = strSql
                Return objMisc.GetDataTable

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function DeleteRcvdDev(ByVal WHP_ID As Integer, _
                                      ByVal WHR_ID As Integer) As Integer
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim i As Integer = 0

            Try
                'delete twarehousepalletload
                strSql = "delete from twarehousepalletload where whp_id = " & WHP_ID & ";"
                objMisc._SQL = strSql
                i = objMisc.ExecuteNonQuery

                'delete twarehousereceive
                strSql = "delete from twarehousereceive where whr_id = " & WHR_ID & ";"
                objMisc._SQL = strSql
                i += objMisc.ExecuteNonQuery

                Return i

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function CheckDevInWIP(ByVal strDevice_sn As String, _
                                      ByVal iModel_id As Integer, _
                                      ByVal iCust_id As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "select tdevice.* from tdevice  " & Environment.NewLine
                strSql &= "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & Environment.NewLine
                strSql &= "where device_sn = '" & strDevice_sn & "' and  " & Environment.NewLine
                strSql &= "Device_DateShip is null  and  " & Environment.NewLine
                strSql &= "model_id = " & iModel_id & " and " & Environment.NewLine
                strSql &= "cust_id = " & iCust_id & " " & Environment.NewLine
                strSql &= "order by device_id desc;"
                objMisc._SQL = strSql
                Return objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetModelMotosku(ByVal iModel_ID As Integer) As String
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim strModelMotoSku As String = ""

            Try
                strSql = "select Model_MotoSKu from tmodel where model_id = " & iModel_ID & ";"
                objMisc._SQL = strSql
                dt1 = objMisc.GetDataTable
                If dt1.Rows.Count > 0 Then
                    If Not IsDBNull(dt1.Rows(0)("Model_MotoSKu")) Then
                        strModelMotoSku = dt1.Rows(0)("Model_MotoSKu")
                    End If
                End If

                Return strModelMotoSku
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '******************************************************************
        Public Function DeleteEmptyPallet(ByVal iWHPallet_id As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "delete from twarehousepallet where WHPallet_ID = " & iWHPallet_id & ";"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.ExecuteNonQuery
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetGSWHPalletByLot(ByVal iCust_ID As Integer, _
                                           ByVal strLotNum As String, _
                                           Optional ByVal iModel_ID As Integer = 0) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT WHPallet_ID, SKU_ID, tmodel.Model_ID, WHPallet_Number as WHPallet, " & Environment.NewLine
                strSql &= "WHP_FileQty as QTY,  WHP_Lot  as Lot, WHP_Skid as Skid, " & Environment.NewLine
                strSql &= "WHP_SKU as Sku,  Model_Desc as Model, " & Environment.NewLine
                strSql &= "WH_PalletType as PalletType, " & Environment.NewLine
                strSql &= "IF (WHPalletClosed = 1, 'YES', 'NO') as 'Pallet Closed', " & Environment.NewLine
                strSql &= "IF (WHP_PalletRcvd = 1, 'YES', 'NO') as 'Production Rec'" & Environment.NewLine
                strSql &= "FROM twarehousepallet " & Environment.NewLine
                strSql &= "INNER JOIN tmodel on twarehousepallet.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "WHERE Cust_ID = " & iCust_ID & " " & Environment.NewLine
                strSql &= "AND WHP_Lot = '" & strLotNum & "' " & Environment.NewLine
                If iModel_ID > 0 Then
                    strSql &= "AND twarehousepallet.Model_ID = " & iModel_ID & Environment.NewLine
                End If
                strSql &= "ORDER BY WHPallet_ID DESC;"

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************

    End Class
End Namespace