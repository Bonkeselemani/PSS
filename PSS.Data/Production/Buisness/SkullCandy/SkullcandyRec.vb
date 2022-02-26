Option Explicit On 

Imports CrystalDecisions.CrystalReports.Engine

Namespace Buisness
    Public Class SkullcandyRec
        Private _objDataProc As MySql4.DataProc

#Region "Constructor/Destructor"

        '******************************************************************
        Public Sub New()
            Try
                Me._objDataProc = New MySql4.DataProc(ConfigFile.GetConnectionInfo)
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

#Region "End User Recv"
        '*************************************************************************************
        Public Function GetDevicesCountInWIP(ByVal iLoc_ID As Integer, ByVal iWO_ID As Integer, ByVal strSN As String) As Integer
            Dim strSQL As String
            Dim dt As DataTable
            Dim tmpNum As Integer = 0

            Try
                strSQL = "SELECT Device_SN from tDevice" & Environment.NewLine
                strSQL &= " WHERE Loc_ID = " & iLoc_ID & Environment.NewLine
                strSQL &= " AND Device_DateShip is Null AND Device_SN = '" & strSN & "';" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSQL)
                If dt.Rows.Count > 0 Then
                    tmpNum = dt.Rows.Count
                End If
                Return tmpNum

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '*************************************************************************************
        Public Function GetDeviceRMACount(ByVal iLoc_ID As Integer, ByVal strRMA As String) As Integer
            Dim strSQL As String
            Dim dt As DataTable
            Dim tmpNum As Integer = 0

            Try
                strSQL = "SELECT InRMA from  tAsnData" & Environment.NewLine
                strSQL &= " WHERE Loc_ID = " & iLoc_ID & Environment.NewLine
                strSQL &= " AND InRMA = '" & strRMA & "';" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSQL)
                If dt.Rows.Count > 0 Then
                    tmpNum = dt.Rows.Count
                End If
                Return tmpNum

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '*************************************************************************************
        Public Function GetOpenPalletName(ByVal iCust_ID As Integer, ByVal iLoc_ID As Integer) As DataTable
            Dim strSQL As String
            Dim dt As DataTable
            Dim _objModManuf As ModManuf

            Try
                strSQL = "SELECT Pallett_ID,Pallett_Name from tPallett" & Environment.NewLine
                strSQL &= " WHERE Loc_ID = " & iLoc_ID & " And Cust_ID = " & iCust_ID & Environment.NewLine
                strSQL &= " AND Pallett_ShipDate is Null AND Pallet_ShipType=1 AND Pallet_Invalid=0;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSQL)
                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '*************************************************************************************
        Public Function ReceiveDeviceIntoWIP(ByVal iWOID As Integer, ByVal iModelID As Integer, ByVal strInRMA As String, _
                                             ByVal strSN As String, ByVal iShiftID As Integer, ByVal iUserID As Integer, _
                                             ByVal strUserName As String, ByVal iCCID As Integer, ByVal strDateCode As String, _
                                             ByVal iScrapPalletID As Integer, ByVal iMoldeID_EDI As Integer) As Integer
            Const strWorkStation As String = "RECEIVE"
            Dim iDeviceID, iCnt, i, iWipOwner, iManufWrty, iWHReceiptID, iPSSWrty, iTrayID As Integer
            Dim strWrkDate As String = ""
            Dim objRec As New PSS.Data.Production.Receiving()
            Dim objGP As New Data.Buisness.GenericProcess.clsGenericProcess()

            Try
                iDeviceID = 0 : iCnt = 0 : i = 0 : iWipOwner = 1 : iManufWrty = 0 : iWHReceiptID = 0

                'iPSSWrty = Me.CalPSSIWarranty(strSN, dteReceiptDate)

                strWrkDate = Generic.GetWorkDate(iShiftID)
                iTrayID = objRec.GetTrayID(iWOID)
                If iTrayID = 0 Then iTrayID = objRec.InsertIntoTtray(iUserID, strUserName, , )

                '1: Create device (Write to tDevice)
                iCnt = objRec.GetNextDeviceCountInTray(iTrayID) + 1
                iDeviceID = objRec.InsertIntoTdevice(strSN, strWrkDate, iCnt, iTrayID, Skullcandy.LOCID, iWOID, iModelID, iShiftID, iPSSWrty, iManufWrty, , iCCID, )
                If iDeviceID = 0 Then Throw New Exception("System has failed to insert into tdevice table.")

                '2: Create cellopt (Write to tCellOpt)
                i = objRec.InsertIntoTCellopt(iDeviceID, , , , , , , , , strDateCode, , , , , , , strWorkStation, , iWipOwner, strSN, )
                If i = 0 Then Throw New Exception("System has failed to insert into tcellopt.")

                '3:Update/Insert ASN Data
                i = objGP.InsertUpdateAsnData(iWOID, Skullcandy.LOCID, iModelID, iDeviceID, "", strInRMA, "", strSN, "", "", "", "", 0, 0, iUserID, 0, iMoldeID_EDI)
                If i = 0 Then Throw New Exception("System has failed to write data into tasndata table.")

                Return iDeviceID

            Catch ex As Exception
                Throw ex
            Finally
                objRec = Nothing : objGP = Nothing
            End Try
        End Function

        '*********************************************************************************************
        Public Shared Function SkullcandyAutoShip(ByVal iDeviceID As Integer, ByVal iPalletID As Integer, _
                                                  ByVal strWorkDate As String, ByVal iShiftID As Integer, ByVal strWorkstation As String) As Integer
            Dim strSql As String = ""
            Dim objDataProc As MySql4.DataProc
            Dim i As Integer

            Try
                If strWorkstation.Trim.Length > 0 Then
                    Dim objShip As New Production.Shipping()
                    i = objShip.UpdateShipInfo(iDeviceID, strWorkDate, iShiftID, iPalletID, )
                Else
                    objDataProc = New MySql4.DataProc(ConfigFile.GetConnectionInfo)
                    strSql = "UPDATE tdevice SET Pallett_ID = " & iPalletID & Environment.NewLine
                    strSql &= ", Device_DateShip = now(), Device_ShipWorkDate = '" & strWorkDate & "'" & Environment.NewLine
                    strSql &= ", Shift_ID_Ship = " & iShiftID & Environment.NewLine
                    strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                    i = objDataProc.ExecuteNonQuery(strSql)
                End If

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '*********************************************************************************************
        Public Function GetReqServiceBillcodes(ByVal strExceptionCriteriaName As String) As DataTable
            Dim strSql As String = ""
            Dim dt, dtBillcodes As DataTable

            Try
                dt = ModManuf.GetExceptionCriteria(strExceptionCriteriaName)
                If dt.Rows.Count > 0 AndAlso dt.Rows(0)("BillcodeIDs").ToString.Trim.Length > 0 Then
                    strSql = "SELECT * FROM lbillcodes WHERE Billcode_ID IN ( " & dt.Rows(0)("BillcodeIDs").ToString & ")"
                    dtBillcodes = _objDataProc.GetDataTable(strSql)
                Else
                    dtBillcodes = New DataTable()
                End If

                Return dtBillcodes
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt) : Generic.DisposeDT(dtBillcodes)
            End Try
        End Function

        '******************************************************************
#End Region

#Region "Retailer Bulk Recv - Pallet"
        '******************************************************************
        Public Function GetOpenPalletWOData(ByVal iLoc_ID As Integer, ByVal strPalletWOPreFix As String) As DataTable
            Dim strSQL As String
            Dim dt As DataTable

            Try
                strSQL = "SELECT * from tWorkOrder" & Environment.NewLine
                strSQL &= " WHERE Loc_ID = " & iLoc_ID & " And LEFT(WO_CustWO," & strPalletWOPreFix.Trim.Length.ToString & ") = '" & strPalletWOPreFix & "'" & Environment.NewLine
                strSQL &= " AND WO_Closed=0;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSQL)
                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function IsPalletWOClosed(ByVal iWO_ID As Integer) As Boolean
            Dim strSQL As String
            Dim dt As DataTable
            Dim bRes As Boolean = False

            Try
                strSQL = "SELECT * from tWorkOrder" & Environment.NewLine
                strSQL &= " WHERE WO_ID = " & iWO_ID & ";" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSQL)

                If dt.Rows.Count > 0 Then
                    If dt.Rows(0).Item("WO_Closed") = 1 Then
                        bRes = True
                    End If
                End If

                Return bRes

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function


        '******************************************************************
        Public Function CreatePalletWO(ByVal iLoc_ID As Integer, _
                                       ByVal iProd_ID As Integer, _
                                       ByVal iGroup_ID As Integer, _
                                       ByVal iQty As Integer, _
                                       ByVal strDateTime As String, _
                                       ByVal strPalletWOName As String) As Integer


            'Create and close it
            Dim strSQL As String
            Dim dt As DataTable

            Try
                strSQL = "INSERT INTO tWorkOrder (Loc_ID,Prod_ID,Group_ID,WO_Quantity,WO_Date,WO_CustWO,WO_Closed)" & Environment.NewLine
                strSQL &= " Values (" & iLoc_ID & "," & iProd_ID & "," & iGroup_ID & "," & iQty & ",'" & strDateTime & "','" & strPalletWOName & "',1);"

                Me._objDataProc.ExecuteNonQuery(strSQL)

                'Newly inserted primary key
                strSQL = "SELECT LAST_INSERT_ID();"
                Return Me._objDataProc.GetIntValue(strSQL)

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetPalletWorkOrderData(ByVal iLoc_ID As Integer, ByVal strPalletWOName As String) As DataTable
            Dim strSQL As String
            Dim dt As DataTable

            Try
                strSQL = "SELECT * from tWorkOrder" & Environment.NewLine
                strSQL &= " WHERE Loc_ID = " & iLoc_ID & " And WO_CustWO= '" & strPalletWOName & "';" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSQL)
                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetModelsData(ByVal iCust_ID As Integer, _
                                      Optional ByVal strModelInclude As String = "") As DataTable
            'Bundle Models data----------------------------------------
            Dim strSQL As String
            Dim dt As DataTable

            Try
                strSQL &= "SELECT A.Model_ID,A.Model_Desc,A.Model_MotoSku,B.cust_IncomingSku,B.Cust_Model_Number,B.Cust_model_desc from tmodel A" & Environment.NewLine
                strSQL &= " INNER JOIN tcustmodel_pssmodel_map B ON A.Model_ID=B.Model_ID" & Environment.NewLine
                strSQL &= " WHERE B.Cust_ID=" & iCust_ID & Environment.NewLine
                If strModelInclude.Trim.Length > 0 Then
                    strSQL &= " AND A.Model_MotoSku in (" & strModelInclude & ")" & Environment.NewLine
                End If
                strSQL &= " ORDER BY B.cust_IncomingSku,A.Model_MotoSku;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSQL)

                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetBundlesAndModelsData(ByVal iCust_ID As Integer) As DataSet
            'Return a dataset including 2 tables for Bundle data, Models data
            Dim strSQL As String
            Dim dtBundle As DataTable
            Dim dtModel As DataTable
            Dim ds As New DataSet()
            Dim row As DataRow, row2 As DataRow
            Dim i As Integer = 0, j As Integer = 0
            Dim strColPrefix As String = Skullcandy.ASTRO_ShipColPreFix

            Try
                'Bundle data
                strSQL &= " SELECT 0 AS BundleID,B.cust_IncomingSku AS BundleName,Count(B.cust_IncomingSku) AS BundleCount" & Environment.NewLine
                strSQL &= " FROM tmodel A" & Environment.NewLine
                strSQL &= " INNER JOIN tcustmodel_pssmodel_map B ON A.Model_ID=B.Model_ID" & Environment.NewLine
                strSQL &= " WHERE B.Cust_ID=" & iCust_ID & Environment.NewLine
                strSQL &= " GROUP BY B.cust_IncomingSku" & Environment.NewLine
                strSQL &= " ORDER BY B.cust_IncomingSku;" & Environment.NewLine
                dtBundle = Me._objDataProc.GetDataTable(strSQL)

                'Model Data
                strSQL = "SELECT  0 AS RecID,0 AS BundleID,A.Model_ID,A.Model_Desc,A.Model_MotoSku" & Environment.NewLine
                strSQL &= ",'' AS ColName,B.Cust_Model_Number,B.cust_IncomingSku AS BundleName,B.cust_OutgoingSku" & Environment.NewLine
                strSQL &= ",B.cust_Model_Desc,B.cust_IncomingDesc,B.Cust_OutgoingDesc" & Environment.NewLine
                strSQL &= " FROM tmodel A" & Environment.NewLine
                strSQL &= " INNER JOIN tcustmodel_pssmodel_map B ON A.Model_ID=B.Model_ID" & Environment.NewLine
                strSQL &= " WHERE B.Cust_ID=" & iCust_ID & Environment.NewLine
                strSQL &= " ORDER BY B.cust_IncomingSku,A.Model_MotoSku;" & Environment.NewLine
                dtModel = Me._objDataProc.GetDataTable(strSQL)

                'Update Bundle IDs
                If dtBundle.Rows.Count > 0 And dtModel.Rows.Count > 0 Then
                    i = 0
                    For Each row In dtBundle.Rows 'create Bundle ID
                        i += 1
                        row("BundleID") = i
                    Next
                    dtBundle.AcceptChanges()
                    i = 0
                    For Each row In dtModel.Rows 'update Bundle ID
                        i += 1
                        row("RecID") = i
                        For Each row2 In dtBundle.Rows
                            If row2("BundleName") = row("BundleName") Then
                                row("BundleID") = row2("BundleID")
                                Exit For
                            End If
                        Next

                    Next
                    For Each row In dtBundle.Rows 'create colname
                        j = 0
                        For Each row2 In dtModel.Rows
                            If row("BundleID") = row2("BundleID") Then
                                j += 1
                                row2("ColName") = strColPrefix & j.ToString
                            End If
                        Next
                    Next
                    dtBundle.AcceptChanges()
                End If

                'Create ds
                dtBundle.TableName = "BundleData" : dtModel.TableName = "ModelData"
                ds.Tables.Add(dtBundle) : ds.Tables.Add(dtModel)

                Return ds

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDS(ds)
            End Try
        End Function

        '******************************************************************
        Public Function GetPalletWO_DetailedData(ByVal iLoc_ID As Integer, _
                                                 ByVal strBegDTime As String, _
                                                 ByVal strEndDTime As String, _
                                                 Optional ByVal iColOrder As Integer = 0) As DataTable
            Dim strSQL As String

            Try

                'strSQL = "SELECT IF(A.cust_model_number=A.cust_model_desc, B.model_desc, CONCAT(B.model_desc,' - ',A.cust_model_desc)) AS 'ModelDesc'" & Environment.NewLine
                'strSQL &= ",C.Quantity AS 'Qty',C.LineNo,D.WO_CustWO as 'PalletName', C.QuantityUpdateDate AS 'UpdateDT',C.OriginalQuantity AS 'PrevQty',A.Model_ID,C.WO_ID,C.WOL_ID" & Environment.NewLine
                'strSQL &= " FROM tcustmodel_pssmodel_map A" & Environment.NewLine
                'strSQL &= " INNER JOIN tModel B ON A.model_ID=B.model_ID" & Environment.NewLine
                'strSQL &= " INNER JOIN tworkorderline C ON A.model_ID=C.model_ID" & Environment.NewLine
                'strSQL &= " INNER JOIN tworkorder D ON D.WO_ID=C.WO_ID" & Environment.NewLine
                'strSQL &= " WHERE cust_ID=" & iCust_ID & " AND C.WO_ID=" & iWO_ID & " ORDER BY C.LineNo;" & Environment.NewLine

                If iColOrder = 0 Then
                    strSQL = "SELECT A.PO as 'RMA/RA #', C.RetailerName AS Retailer,D.Model_MotoSku AS Model,A.Quantity AS Qty,D.Model_Desc AS ModelDesc,A.ItemDesc" & Environment.NewLine
                    strSQL &= " ,B.WO_CustWO AS WorkOrder,B.WO_ID,A.WOR_ID,A.WOL_ID" & Environment.NewLine
                Else
                    strSQL = "SELECT B.WO_CustWO AS WorkOrder,C.RetailerName AS Retailer,D.Model_MotoSku AS Model,A.Quantity AS Qty,D.Model_Desc AS ModelDesc,A.ItemDesc" & Environment.NewLine
                    strSQL &= " ,B.WO_ID,A.WOR_ID,A.WOL_ID" & Environment.NewLine
                End If
                strSQL &= " FROM  tWorkOrderLine A" & Environment.NewLine
                strSQL &= " INNER JOIN tWorkOrder B ON A.WO_ID=B.WO_ID" & Environment.NewLine
                strSQL &= " INNER JOIN tWorkOrderRetailer C ON A.WOR_ID=C.WOR_ID" & Environment.NewLine
                strSQL &= " INNER JOIN tModel D ON A.Model_ID=D.Model_ID" & Environment.NewLine
                strSQL &= " WHERE B.Loc_ID=" & iLoc_ID & " AND WO_Closed=1" & Environment.NewLine
                strSQL &= " AND B.WO_Date BETWEEN '" & strBegDTime & "' AND '" & strEndDTime & "'" & Environment.NewLine
                strSQL &= " ORDER BY B.WO_Date DESC;"

                Return Me._objDataProc.GetDataTable(strSQL)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Sub InsertUpdatePalletReceivingData(ByVal strRMA As String, _
                                                   ByVal iModel_ID As Integer, _
                                                   ByVal iWO_ID As Integer, _
                                                   ByVal iQty As Integer, _
                                                   ByVal iWOR_ID As Integer, _
                                                   ByVal strItemDesc As String, _
                                                   ByVal strWODesc As String, _
                                                   ByRef strErrMsg As String)
            Dim strSQL As String, strDateTime As String
            Dim dt As DataTable
            Dim oldQty As Integer = 0, primID As Integer = 0
            Dim iLineNo As Integer = 0, j As Integer = 0
            strErrMsg = ""

            Try
                'strSQL = "SELECT * FROM tworkorderline WHERE WO_ID = " & iWO_ID & " AND Model_ID = " & iModel_ID
                'dt = Me._objDataProc.GetDataTable(strSQL)

                strDateTime = Generic.MySQLServerDateTime(1)

                'If dt.Rows.Count = 1 Then '1 exists, update it
                '    primID = dt.Rows(0).Item("WOL_ID") : oldQty = dt.Rows(0).Item("Quantity")
                '    strSQL = "UPDATE tworkorderline SET Quantity = " & iQty & ", OriginalQuantity = " & oldQty & ", QuantityUpdateDate = '" & strDateTime & "' WHERE WOL_ID = " & primID
                '    If Me._objDataProc.ExecuteNonQuery(strSQL) = 0 Then
                '        strErrMsg = "Failed to update."
                '    End If
                'ElseIf dt.Rows.Count > 1 Then '2 more exists' Holding when this happens.
                '    strErrMsg = "Found duplicate data (more than one). Holding to update."
                'Else 'New, Insert it
                dt = Nothing
                strSQL = "SELECT IF(MAX(LineNo)>0,MAX(LineNo),0) maxVal FROM tworkorderline WHERE WO_ID=" & iWO_ID & " AND WOR_ID=" & iWOR_ID & ";"
                dt = Me._objDataProc.GetDataTable(strSQL)
                iLineNo = dt.Rows(0).Item("maxVal") + 1

                strSQL = "INSERT INTO tworkorderline (SalesOrder,PO,LineNo,ItemNo,ItemDesc,Quantity,QuantityUpdateDate,Model_ID,WO_ID,WOR_ID)" & Environment.NewLine
                strSQL &= " Values ('" & strWODesc & "','" & strRMA & "','" & iLineNo & "','" & strItemDesc & "','" & strItemDesc & "'," & iQty & ",'" & strDateTime & "'," & iModel_ID & "," & iWO_ID & "," & iWOR_ID & ");"

                If Me._objDataProc.ExecuteNonQuery(strSQL) = 0 Then
                    strErrMsg = "Failed to save."
                End If
                'End If

            Catch ex As Exception
                strErrMsg = ex.ToString
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '******************************************************************
        Public Function DeletePalletWO_DetailedData(ByVal iWOL_ID As Integer, ByVal iWO_ID As Integer) As Integer

            Dim strSQL As String
            Dim i As Integer = 0

            Try
                strSQL = "DELETE FROM tworkorderline " & Environment.NewLine
                strSQL &= " WHERE WOL_ID = " & iWOL_ID
                i = Me._objDataProc.ExecuteNonQuery(strSQL)

                strSQL = "DELETE FROM tworkorder " & Environment.NewLine
                strSQL &= " WHERE WO_ID = " & iWO_ID
                i += Me._objDataProc.ExecuteNonQuery(strSQL)

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function UpdatePalletWO_ClosePallet(ByVal iWO_ID As Integer, ByVal iTotalQty As Integer) As Integer

            Dim strSQL As String

            Try
                strSQL = "UPDATE tWorkOrder" & Environment.NewLine
                strSQL &= " SET WO_Quantity = " & iTotalQty & ", WO_Closed=1" & Environment.NewLine
                strSQL &= " WHERE WO_ID = " & iWO_ID & ";" & Environment.NewLine

                Return Me._objDataProc.ExecuteNonQuery(strSQL)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetPalletWO_ClosedPalletNames(ByVal iLoc_ID As Integer, ByVal strStartDTime As String, ByVal strEndDTime As String, ByVal strPalletWOPreFix As String) As DataTable

            Dim strSQL As String
            Try
                strSQL = "SELECT WO_CustWO AS PalletName,WO_ID FROM tWorkOrder" & Environment.NewLine
                strSQL &= " WHERE Loc_ID = " & iLoc_ID & " And LEFT(WO_CustWO," & strPalletWOPreFix.Trim.Length.ToString & ") = '" & strPalletWOPreFix & "'" & Environment.NewLine
                strSQL &= " AND WO_Closed=1 AND WO_Date BETWEEN '" & strStartDTime & "' AND '" & strEndDTime & "'" & Environment.NewLine
                strSQL &= " ORDER BY WO_Date Desc "

                Return Me._objDataProc.GetDataTable(strSQL)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function AddRetailerName(ByVal strRetailerName As String) As Integer
            Dim strSQL As String
            Dim dt As DataTable
            Dim iWOR_ID As Integer = 0
            Dim i As Integer = 0

            Try
                strRetailerName = strRetailerName.Replace("'", "''")
                While strRetailerName.IndexOf("  ") <> -1 'Remove extra space
                    strRetailerName = strRetailerName.Replace("  ", " ")
                End While
                strSQL = "SELECT * FROM  tWorkOrderRetailer WHERE RetailerName ='" & strRetailerName & "';"
                dt = Me._objDataProc.GetDataTable(strSQL)

                If dt.Rows.Count > 0 Then
                    iWOR_ID = dt.Rows(0).Item("WOR_ID")
                    strSQL = "UPDATE tWorkOrderRetailer SET Active=1 WHERE WOR_ID= " & iWOR_ID & ";"
                    i = Me._objDataProc.ExecuteNonQuery(strSQL)
                Else
                    strSQL = "INSERT INTO tWorkOrderRetailer (RetailerName, Active) " & Environment.NewLine
                    strSQL &= " VALUES ('" & strRetailerName & "', 1);"
                    i = Me._objDataProc.ExecuteNonQuery(strSQL)
                End If

                Return i

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetRetailerNames() As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT WOR_ID,RetailerName,Active FROM  tWorkOrderRetailer WHERE Active=1;"
                Return Me._objDataProc.GetDataTable(strSQL)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function ChangeRetailerToInactive(ByVal iWOR_ID As Integer) As Integer
            Dim strSQL As String

            Try
                strSQL = "UPDATE tWorkOrderRetailer SET Active=0 WHERE WOR_ID= " & iWOR_ID & ";"
                Return Me._objDataProc.ExecuteNonQuery(strSQL)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************


#End Region

#Region "Retailer Production Recv"


        '******************************************************************
        Public Function GetAstro_OpenPalletBox(ByVal iLoc_ID As Integer, ByVal booAddSelectedRow As Boolean) As DataTable
            Dim strSQL As String
            Dim dt As DataTable

            Try
                strSQL = " SELECT A.WOL_ID,B.WO_CustWO AS WorkOrder,C.RetailerName AS Retailer,D.Model_MotoSku AS Model,A.Quantity AS Qty" & Environment.NewLine
                strSQL &= " ,D.Model_Desc AS ModelDesc,A.ItemDesc,D.Model_ID,B.WO_ID,A.WOR_ID" & Environment.NewLine
                strSQL &= " FROM  tWorkOrderLine A" & Environment.NewLine
                strSQL &= " INNER JOIN tWorkOrder B ON A.WO_ID=B.WO_ID" & Environment.NewLine
                strSQL &= " INNER JOIN tWorkOrderRetailer C ON A.WOR_ID=C.WOR_ID" & Environment.NewLine
                strSQL &= " INNER JOIN tModel D ON A.Model_ID=D.Model_ID" & Environment.NewLine
                strSQL &= " WHERE B.Loc_ID=" & iLoc_ID & " AND B.WO_Closed=1 AND NOT A.ReceivingClosed >0" & Environment.NewLine
                strSQL &= " ORDER BY B.WO_CustWO Desc;"

                dt = Me._objDataProc.GetDataTable(strSQL)

                If booAddSelectedRow Then dt.LoadDataRow(New Object() {0, "--Select--"}, True)

                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetAstro_PalletBoxReceivedDevices(ByVal iLoc_ID As Integer, ByVal iWO_ID As Integer, ByVal iModel_ID As Integer) As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT Device_ID, Device_SN,Model_ID,Device_DateRec" & Environment.NewLine
                strSQL &= " FROM tDevice" & Environment.NewLine
                strSQL &= " WHERE Loc_ID= " & iLoc_ID & "  AND WO_ID=" & iWO_ID & " AND Model_ID =" & iModel_ID & ";" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSQL)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetPalletBoxWOProductionReceivingDetailData(ByVal iLoc_ID As Integer, ByVal strPalletBoxWO As String) As DataTable
            Dim strSQL As String

            Try
                strPalletBoxWO = strPalletBoxWO.Replace("'", "''")

                strSQL = " SELECT B.WO_CustWO AS WorkOrder,C.RetailerName AS Retailer,D.Model_MotoSku AS Model,A.Quantity AS Qty" & Environment.NewLine
                strSQL &= " ,D.Model_Desc AS ModelDesc,A.ItemDesc,D.Model_ID,B.WO_ID,A.WOR_ID,A.WOL_ID" & Environment.NewLine
                strSQL &= " FROM  tWorkOrderLine A" & Environment.NewLine
                strSQL &= " INNER JOIN tWorkOrder B ON A.WO_ID=B.WO_ID" & Environment.NewLine
                strSQL &= " INNER JOIN tWorkOrderRetailer C ON A.WOR_ID=C.WOR_ID" & Environment.NewLine
                strSQL &= " INNER JOIN tModel D ON A.Model_ID=D.Model_ID" & Environment.NewLine
                strSQL &= " WHERE B.Loc_ID=" & iLoc_ID & " AND WO_Closed=1 AND A.ReceivingClosed=0" & Environment.NewLine
                strSQL &= " AND A.Salesorder='" & strPalletBoxWO & "' AND B.WO_CustWO='" & strPalletBoxWO & "';"

                Return Me._objDataProc.GetDataTable(strSQL)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************
        Public Function GetDevicesInWIP(ByVal iLoc_ID As Integer, ByVal strArrLstSNs As ArrayList) As DataTable
            'Devices in WIP for Loc_ID, SNs
            Dim strSQL As String
            Dim strSNs As String = ""
            Dim i As Integer

            Try
                For i = 0 To strArrLstSNs.Count - 1
                    If i = 0 Then
                        strSNs = "'" & strArrLstSNs(i) & "'"
                    Else
                        strSNs &= ",'" & strArrLstSNs(i) & "'"
                    End If
                Next

                strSQL &= "SELECT Device_SN from tDevice" & Environment.NewLine
                strSQL &= " WHERE Loc_ID =" & iLoc_ID & Environment.NewLine
                strSQL &= " AND (Device_DateShip is Null" & Environment.NewLine
                strSQL &= " OR LENGTH(TRIM(Device_DateShip))=0 OR TRIM(Device_DateShip) ='0000-00-00 00:00:00')" & Environment.NewLine
                strSQL &= " AND Device_SN IN (" & strSNs & ");" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSQL)

            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '*************************************************************************************
        Public Function ReceiveAstro_DeviceIntoWIP(ByVal iWOID As Integer, ByVal iModelID As Integer, _
                                             ByVal strSN As String, ByVal iShiftID As Integer, ByVal iUserID As Integer, _
                                             ByVal strUserName As String, ByVal iCCID As Integer, _
                                             ByVal iLocID As Integer, ByVal iTrayID As Integer, ByVal iWipOwner As Integer, ByVal strWorkStation As String, _
                                             ByRef strErrMsg As String, Optional ByVal iScrapPalletID As Integer = 0) As Integer

            Dim iDeviceID, iCnt, i, j, iManufWrty
            Dim objRec As New PSS.Data.Production.Receiving()

            Dim strWorkDate As String = ""
            Dim strDateTime As String
            Dim DTime As Date
            Dim strSQL As String = Nothing

            Try
                iDeviceID = 0 : iCnt = 1 : i = 0 : iManufWrty = 0
                strErrMsg = ""

                strWorkDate = Generic.GetWorkDate(iShiftID)
                If IsDate(Generic.MySQLServerDateTime) Then
                    DTime = Generic.MySQLServerDateTime
                    strDateTime = Format(DTime, "yyyy-MM-dd HH:mm:ss")
                Else
                    strDateTime = Format(Now, "yyyy-MM-dd HH:mm:ss")
                End If

                iTrayID = objRec.GetTrayID(iWOID)
                If iTrayID = 0 Then iTrayID = objRec.InsertIntoTtray(iUserID, strUserName, , )

                '1: Create device (Write to tDevice)
                strSQL = "INSERT into tdevice (Device_SN,Device_DateRec,Device_RecWorkDate,Device_Cnt,Tray_ID,Loc_ID,WO_ID,Model_ID" & Environment.NewLine
                strSQL &= ",Shift_ID_Rec,Device_ManufWrty,cc_id" & Environment.NewLine
                If iScrapPalletID > 0 Then strSQL &= ",Pallett_ID" & Environment.NewLine
                strSQL &= ") VALUES ( " & Environment.NewLine
                strSQL &= "'" & strSN & "','" & strDateTime & "','" & strWorkDate & "'" & Environment.NewLine
                strSQL &= "," & iCnt & "," & iTrayID & "," & iLocID & "," & iWOID & "," & iModelID & "," & iShiftID & Environment.NewLine
                strSQL &= "," & iManufWrty & "," & iCCID & Environment.NewLine
                If iScrapPalletID > 0 Then strSQL &= "," & iScrapPalletID & Environment.NewLine
                strSQL &= ");"
                i = Me._objDataProc.ExecuteNonQuery(strSQL)
                'Newly inserted primary key 'Device_ID'
                strSQL = "SELECT LAST_INSERT_ID();"
                iDeviceID = Me._objDataProc.GetIntValue(strSQL)

                If iDeviceID > 0 Then
                    '2: Create cellopt (Write to tCellOpt)
                    j = objRec.InsertIntoTCellopt(iDeviceID, , , , , , , , , , , , , , , , strWorkStation, , iWipOwner, strSN, )
                    If j = 0 Then strErrMsg &= "Failled to insert into tCellOpt " & Environment.NewLine
                Else
                    strErrMsg &= "Failled to insert into tDevice " & Environment.NewLine
                End If

                Return iDeviceID

            Catch ex As Exception
                strErrMsg = ex.ToString
            End Try
        End Function

        '******************************************************************
        Public Function ReceiveAstro_CloseBoxReceiving(ByVal iWOL_ID As Integer) As Integer
            Dim strSQL As String

            Try
                strSQL = " UPDATE tworkorderline SET ReceivingClosed=1 WHERE WOL_ID=" & iWOL_ID & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSQL)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function ReceiveAstro_GetReceivedData(ByVal iLoc_ID As Integer, ByVal strBegDTime As String, ByVal strEndDTime As String) As DataTable
            Dim strSQL As String

            Try

                strSQL = "SELECT C.SalesOrder AS BoxWO,A.Device_SN AS SN,C.ItemDesc,E.Model_Desc AS ModelDesc,E.Model_MotoSku AS ShortName,B.WorkStation,"
                strSQL &= " D.RetailerName AS Retailer,A.Device_DateRec AS ReceivedTime,if (C.ReceivingClosed=1, 'Closed','Open') AS RecvStatus,A.Device_ID,A.WO_ID,WOL_ID" & Environment.NewLine
                strSQL &= " FROM tdevice A" & Environment.NewLine
                strSQL &= " INNER JOIN tcellopt B ON A.Device_ID=B.Device_ID" & Environment.NewLine
                strSQL &= " INNER JOIN tworkorderline C ON A.WO_ID=C.WO_ID" & Environment.NewLine
                strSQL &= " INNER JOIN tworkorderretailer D ON C.WOR_ID=D.WOR_ID" & Environment.NewLine
                strSQL &= " INNER JOIN tmodel E ON A.Model_ID=E.Model_ID" & Environment.NewLine
                strSQL &= " WHERE A.Loc_ID= " & iLoc_ID & " AND A.Device_DateRec BETWEEN '" & strBegDTime & "' AND '" & strEndDTime & "'" & Environment.NewLine
                strSQL &= " ORDER BY A.Device_DateRec Desc;" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSQL)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
#End Region

#Region "Astro Build Bundle & Production Ship"

        '******************************************************************
        Public Function Astro_ProdShip_WIPData(ByVal iLoc_ID As Integer, ByVal strSN As String) As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT A.Device_ID,A.Device_SN,A.Device_DateRec,A.Device_DateBill, A.Device_DateShip,A.Device_Invoice,A.Device_ManufWrty" & Environment.NewLine
                strSQL &= ",A.Device_ChgManufWrty,A.Device_PSSWrty, A.Device_LaborLevel,A.Device_LaborCharge,A.Device_PartCharge" & Environment.NewLine
                strSQL &= ",A.Device_ManufWrtyLaborCharge,A.Device_ManufWrtyPartCharge,A.Device_Qty,A.Device_Cnt,A.Device_RecWorkDate" & Environment.NewLine
                strSQL &= ",A.Device_ShipWorkDate,A.Tray_ID,A.Loc_ID,A.WO_ID,A.WO_ID_Out,A.Ship_ID,A.Model_ID, A.Pallett_ID,A.Shift_ID_Rec" & Environment.NewLine
                strSQL &= ",A.Shift_ID_Ship,A.cc_id,B.WOL_ID,B.SalesOrder,B.LineNo,B.ItemNo,B.ItemDesc,B.ItemDesc2,B.Quantity" & Environment.NewLine
                strSQL &= ",B.ReceivingClosed,B.ShippingClosed,B.WOR_ID,C.CellOpt_ID,C.Cellopt_WIPOwner" & Environment.NewLine
                strSQL &= ",C.Cellopt_WIPEntryDt,C.Cellopt_WIPOwnerOld,C.WorkStation,C.WorkStationEntryDt,C.Manuf_SN" & Environment.NewLine
                strSQL &= " FROM  tDevice A" & Environment.NewLine
                strSQL &= " INNER JOIN tWorkOrderLine B ON A.WO_ID=B.WO_ID" & Environment.NewLine
                strSQL &= " INNER JOIN tCellOpt C ON A.Device_ID=C.Device_ID" & Environment.NewLine
                strSQL &= " WHERE Loc_ID =" & iLoc_ID & Environment.NewLine
                strSQL &= " AND (A.Device_DateShip is Null" & Environment.NewLine
                strSQL &= " OR LENGTH(TRIM(A.Device_DateShip))=0 OR TRIM(A.Device_DateShip) ='0000-00-00 00:00:00')" & Environment.NewLine
                strSQL &= " AND (NOT A.Pallett_ID>0 OR A.Pallett_ID is NULL)" & Environment.NewLine
                strSQL &= " AND A.Device_SN ='" & strSN & "';"

                Return Me._objDataProc.GetDataTable(strSQL)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function Astro_ProdShip_CreateShipID(ByVal strUser As String, _
                                                    ByVal strShipDTime As String, _
                                                    ByVal iProdID As Integer, ByVal iOverPackID As Integer) As Integer

            'Return Ship_ID
            Dim strSQL As String
            Dim iShip_ID As Integer = 0, i As Integer = 0

            Try

                strSQL = "INSERT INTO tShip SET Ship_User = '" & strUser & "', Ship_Date = '" & strShipDTime & "', Prod_ID = " & iProdID & ", OverPack_ID = " & iOverPackID
                i = Me._objDataProc.ExecuteNonQuery(strSQL)

                If i > 0 Then
                    'Newly inserted primary key
                    strSQL = "SELECT LAST_INSERT_ID();"
                    iShip_ID = Me._objDataProc.GetIntValue(strSQL)
                End If

                Return iShip_ID

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function Astro_ProdShip_DeviceBilled(ByVal iLoc_ID As Integer, _
                                                    ByVal iDevice_ID As Integer) As Boolean

            Dim strSQL As String
            Dim bRes As Boolean = False
            Dim dt As DataTable

            Try

                strSQL = " SELECT * FROM tDevice" & Environment.NewLine
                strSQL &= " WHERE Loc_ID=" & iLoc_ID & " AND Device_ID = " & iDevice_ID & Environment.NewLine
                strSQL &= " AND (Device_DateBill is Not Null" & Environment.NewLine
                strSQL &= " OR LENGTH(TRIM(Device_DateBill))>0 OR TRIM(Device_DateBill) <> '0000-00-00 00:00:00');" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSQL)
                If dt.Rows.Count > 0 Then
                    bRes = True
                End If

                Return bRes

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function Astro_ProdShip_OpenBoxPallet(ByVal iLoc_ID As Integer, ByVal iModel_ID As Integer) As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT Pallett_ID, Pallett_Name as 'Pallet Name', cust_model_number as 'Bundle', Pallet_SkuLen" & Environment.NewLine
                strSQL &= " FROM tpallett A" & Environment.NewLine
                strSQL &= " INNER JOIN tcustmodel_pssmodel_map B ON A.Model_ID = B.Model_ID AND A.Cust_ID = B.Cust_ID " & Environment.NewLine
                strSQL &= " WHERE A.Loc_ID = " & iLoc_ID & " AND Pallett_ShipDate is null " & Environment.NewLine
                strSQL &= " AND A.Model_ID = " & iModel_ID & " AND Pallet_Invalid = 0 "

                Return Me._objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************
        Public Function Astro_ProdShip_GetBoxDevices(ByVal iLoc_ID As Integer, ByVal iOverPackID As Integer, ByRef dtCountInBundle As DataTable) As DataTable
            'Devices in WIP for Loc_ID, SNs
            Dim strSQL As String
            Dim strSNs As String = ""

            Dim i As Integer

            Try
                strSQL = " SELECT A.Ship_ID, count(A.Ship_ID) AS CountInBundle FROM tDevice A" & Environment.NewLine
                strSQL &= "INNER JOIN tship B ON A.Ship_ID = B.Ship_ID " & Environment.NewLine
                strSQL &= "  WHERE A.Loc_ID =" & iLoc_ID & Environment.NewLine
                strSQL &= "  AND B.OverPack_ID =" & iOverPackID & Environment.NewLine
                strSQL &= " GROUP BY A.Ship_ID;" & Environment.NewLine

                dtCountInBundle = Me._objDataProc.GetDataTable(strSQL)

                strSQL = "SELECT A.* FROM tDevice A " & Environment.NewLine
                strSQL &= "INNER JOIN tship B ON A.Ship_ID = B.Ship_ID " & Environment.NewLine
                strSQL &= " WHERE A.Loc_ID =" & iLoc_ID & Environment.NewLine
                strSQL &= " AND B.OverPack_ID = " & iOverPackID & Environment.NewLine
                strSQL &= " ORDER BY A.Ship_ID;"

                Return Me._objDataProc.GetDataTable(strSQL)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function Astro_ProdShip_UpdateDevice(ByVal iArrLstDeviceIDs As ArrayList, _
                                                    ByVal iShipID As Integer, _
                                                    ByVal iDeviceSeqCnt As Integer, _
                                                    ByVal iCellOptWIPOwner As Integer, _
                                                    ByVal strWorkStation As String, _
                                                    ByRef strErrMsg As String) As Integer

            Dim strSQL As String
            Dim i As Integer = 0, j As Integer = 0
            Dim DeviceIDs As String = ""

            Try
                strErrMsg = ""
                'Form  device ID string
                For i = 0 To iArrLstDeviceIDs.Count - 1
                    If i = 0 Then
                        DeviceIDs = iArrLstDeviceIDs(i)
                    Else
                        DeviceIDs &= "," & iArrLstDeviceIDs(i)
                    End If
                Next

                'Update tDevice
                i = 0
                strSQL = "UPDATE tDevice SET Ship_ID = " & iShipID & ", Device_Cnt =" & iDeviceSeqCnt & Environment.NewLine
                strSQL &= " WHERE Device_ID IN (" & DeviceIDs & ") " & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSQL)
                If Not i > 0 Then strErrMsg = "Failed to update tDevice table (device_ID: " & DeviceIDs & ")." & Environment.NewLine

                'Update tCellOpt
                strSQL = "UPDATE tCellOpt SET Cellopt_WIPOwner = " & iCellOptWIPOwner & ", WorkStation = '" & strWorkStation & "'" & Environment.NewLine
                strSQL &= " WHERE Device_ID IN (" & DeviceIDs & ") " & Environment.NewLine
                j = Me._objDataProc.ExecuteNonQuery(strSQL)
                If Not j > 0 Then strErrMsg &= "Failed to update tCellOpt table (device_ID: " & DeviceIDs & ")." & Environment.NewLine

                Return i + j

            Catch ex As Exception
                strErrMsg &= ex.ToString
            End Try
        End Function

        '******************************************************************
        Public Function Astro_ProdShip_UndoUpdateDevice(ByVal iArrLstDeviceIDs As ArrayList, _
                                                        ByRef strErrMsg As String) As Integer

            Dim strSQL As String
            Dim i As Integer = 0, j As Integer = 0, iShip_ID As Integer = 0
            Dim DeviceIDs As String = "", ShipIDs As String = ""
            Dim dt As DataTable, row As DataRow

            Try
                strErrMsg = ""
                'Form  device ID string
                For i = 0 To iArrLstDeviceIDs.Count - 1
                    If i = 0 Then
                        DeviceIDs = iArrLstDeviceIDs(i)
                    Else
                        DeviceIDs &= "," & iArrLstDeviceIDs(i)
                    End If
                Next

                'Get ship IDs
                strSQL = "SELECT * FROM tDevice WHERE Device_ID in (" & DeviceIDs & ");"
                dt = Me._objDataProc.GetDataTable(strSQL)
                i = 0
                For Each row In dt.Rows
                    If row.IsNull("Ship_ID") Then
                    Else
                        If IsNumeric(row("Ship_ID")) Then
                            If i = 0 Then
                                ShipIDs = CInt(row("Ship_ID")).ToString
                            Else
                                ShipIDs &= "," & CInt(row("Ship_ID")).ToString
                            End If
                        End If
                    End If
                Next

                'Update tDevice
                i = 0
                strSQL = "UPDATE tDevice SET Ship_ID = NULL, Device_Cnt = 0 " & Environment.NewLine
                strSQL &= " WHERE Device_ID IN ( " & DeviceIDs & " ) " & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSQL)
                If Not i > 0 Then
                    strErrMsg = "Failed to update tDevice table (device_ID: " & DeviceIDs & ")." & Environment.NewLine
                End If

                'Delete Ship id from tship
                strSQL = "Delete FROM tShip WHERE SHip_ID IN (" & ShipIDs & ");"
                j = Me._objDataProc.ExecuteNonQuery(strSQL)

                Return i

            Catch ex As Exception
                'Throw ex
                strErrMsg &= "Failed to update." & Environment.NewLine & ex.ToString
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '*********************************************************************************************
        Public Function Astro_ProdShip_ShippedDeviceData(ByVal iLoc_ID As Integer, _
                                                         ByVal strBeginDate As String, _
                                                         ByVal strEndDate As String) As DataSet
            'Data for reprinting Astro production shipment labels
            Dim strSQL As String, strSQL1 As String, strSQL2 As String
            Dim strName1 As String = "PalletData"
            Dim strName2 As String = "DeviceData"
            Dim dt As DataTable
            Dim ds As New DataSet()

            Try

                'strSQL2 = "SELECT A.Device_SN, E.cust_model_desc, E.cust_IncomingDesc, E.cust_OutgoingDesc, A.Device_ID, A.Ship_ID, A.Model_ID, D.Model_Desc, D.Model_MotoSKu" & Environment.NewLine
                'strSQL &= ", toverpack.OverPack_ID, toverpack.OverPackName " & Environment.NewLine
                'strSQL &= " FROM tDevice A" & Environment.NewLine
                'strSQL &= " INNER JOIN tCellOpt C ON A.Device_ID=C.Device_ID" & Environment.NewLine
                'strSQL &= " INNER JOIN tModel D ON A.Model_ID=D.Model_ID" & Environment.NewLine
                'strSQL &= " INNER JOIN tCustmodel_pssmodel_map E ON D.Model_ID = E.Model_ID " & Environment.NewLine
                'strSQL &= " INNER JOIN tship On A.Ship_ID = tship.Ship_ID " & Environment.NewLine
                'strSQL &= " INNER JOIN toverpack On tship.OverPack_ID = toverpack.OverPack_ID " & Environment.NewLine
                'strSQL &= " WHERE A.Loc_ID = " & iLoc_ID & Environment.NewLine
                'strSQL &= " AND (Device_DateShip is Not Null " & Environment.NewLine
                'strSQL &= " OR LENGTH(TRIM(Device_DateShip))> 0 OR TRIM(Device_DateShip) <> '0000-00-00 00:00:00')" & Environment.NewLine
                'strSQL &= " AND Device_FinishedGoods = 1 " & Environment.NewLine
                'strSQL &= " AND Device_DateShip Between '" & strBeginDate & "' AND '" & strEndDate & "'" & Environment.NewLine
                'strSQL &= " ORDER BY A.Ship_ID,D.Model_MotoSKu " & Environment.NewLine

                strSQL1 = "SELECT Distinct OverPack_Name, toverpack.OverPack_ID" & Environment.NewLine
                strSQL2 = "SELECT toverpack.OverPack_Name,A.Device_SN,E.cust_model_desc,E.cust_IncomingDesc,E.cust_OutgoingDesc,A.Device_ID" & Environment.NewLine
                strSQL2 &= ",tship.OverPack_ID,A.Ship_ID,A.Model_ID,D.Model_Desc,D.Model_MotoSKu" & Environment.NewLine

                strSQL &= "  FROM tDevice A" & Environment.NewLine
                strSQL &= "  INNER JOIN tCellOpt C ON A.Device_ID=C.Device_ID" & Environment.NewLine
                strSQL &= "  INNER JOIN tModel D ON A.Model_ID=D.Model_ID" & Environment.NewLine
                strSQL &= "  INNER JOIN tCustmodel_pssmodel_map E ON D.Model_ID = E.Model_ID" & Environment.NewLine
                strSQL &= "  INNER JOIN tship On A.Ship_ID = tship.Ship_ID" & Environment.NewLine
                strSQL &= "  INNER JOIN toverpack On tship.OverPack_ID = toverpack.OverPack_ID" & Environment.NewLine
                strSQL &= "  WHERE A.Loc_ID = " & iLoc_ID & " AND toverpack.Closed=1" & Environment.NewLine
                strSQL &= "  AND toverpack.OverPack_ShipDate  Between '" & strBeginDate & "' AND '" & strEndDate & "'" & Environment.NewLine
                strSQL &= " ORDER BY A.Ship_ID,D.Model_MotoSKu;"

                dt = Me._objDataProc.GetDataTable(strSQL1 & strSQL)
                If dt.Rows.Count > 0 Then
                    dt.TableName = strName1
                    ds.Tables.Add(dt.Copy)

                    dt = Me._objDataProc.GetDataTable(strSQL2 & strSQL)
                    dt.TableName = strName2
                    ds.Tables.Add(dt.Copy)
                End If

                Return ds

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDS(ds)
                Generic.DisposeDT(dt)
            End Try
        End Function

        '***************************************************************************************************
        Public Function Astro_GetModelIDsInOverPack(ByVal iOverPackID As Integer)
            Dim strSql As String = ""

            Try
                strSql = "SELECT DISTINCT tdevice.Model_ID FROM tdevice INNER JOIN tship ON tdevice.Ship_ID = tship.Ship_ID WHERE OverPack_ID = " & iOverPackID
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************************
        Public Function Astro_GetDeviceBillByOverPackAndBillcode(ByVal iOverPackID As Integer, ByVal iBillcodeID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT tdevicebill.* FROM tdevice" & Environment.NewLine
                strSql &= "INNER JOIN tship ON tdevice.Ship_ID = tship.Ship_ID " & Environment.NewLine
                strSql &= "INNER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID " & Environment.NewLine
                strSql &= "WHERE tship.OverPack_ID = " & iOverPackID & " AND tdevicebill.Billcode_ID = " & iBillcodeID
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************************
        Public Function Astro_CreateSkAstroOverPack(ByVal iCustID As Integer, ByVal iLocID As Integer, ByVal iModelID As Integer, _
                                                    ByVal iPalletShipType As Integer, ByVal strCustModelNo As String) As Integer
            Const strPreFix As String = "SCAS"
            Const iSeqNoLength As Integer = 3
            Dim strSql As String = "", strToday As String = "", strOverPackName As String = "", strPalletShipType As String = ""
            Dim iNextSqlNo As Integer = 0, iOverPackID As Integer
            Dim objShip As New Production.Shipping()
            Dim dt As DataTable

            Try
                dt = Me.Astro_GetOpenOverPacks(iCustID, iLocID, iPalletShipType, strCustModelNo)
                If dt.Rows.Count > 1 Then
                    Throw New Exception("Multiple open overpack existed. Please contact IT.")
                ElseIf dt.Rows.Count = 1 Then
                    iOverPackID = CInt(dt.Rows(0)("OverPack_ID"))
                Else
                    If iPalletShipType = 0 Then strPalletShipType = "P" Else strPalletShipType = "F"
                    strToday = Generic.GetMySqlDateTime("%Y%m%d")
                    strOverPackName = strPreFix & strToday & strPalletShipType
                    iNextSqlNo = objShip.GetOverPackNextSeqNo(iLocID, strOverPackName, iSeqNoLength)
                    strOverPackName &= iNextSqlNo.ToString.Trim.PadLeft(iSeqNoLength, "0")
                    iOverPackID = objShip.CreateOverPackWithName(iLocID, iModelID, strOverPackName, iPalletShipType)
                    If iOverPackID = 0 Then Throw New Exception("System has failed to create overpack id.")
                End If

                Return iOverPackID
            Catch ex As Exception
                Throw ex
            Finally
                objShip = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Function

        '***************************************************************************************************
        Public Function Astro_GetOpenOverPacks(ByVal iCustID As Integer, ByVal iLocID As Integer, ByVal ipalletShipType As Integer, ByVal strCustModelNo As String) As DataTable
            Dim strsql As String = ""
            Try
                strsql = "SELECT Distinct A.*, B.cust_model_number as 'ModelName'  FROM toverpack A" & Environment.NewLine
                strsql &= "INNER JOIN tcustmodel_pssmodel_map B ON A.Model_ID = B.Model_ID AND B.Cust_ID = " & iCustID & Environment.NewLine
                strsql &= "WHERE A.Loc_ID = " & iLocID & " AND A.Pallett_ID is null AND A.Closed = 0 " & Environment.NewLine
                strsql &= "AND A.OverPack_Process = " & ipalletShipType & Environment.NewLine
                If strCustModelNo.Trim.Length > 0 Then strsql &= "AND B.cust_model_number = '" & strCustModelNo & "'"
                strsql &= "GROUP BY A.OverPack_ID"
                Return Me._objDataProc.GetDataTable(strsql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************************
        Public Function Astro_GetCustomerModelNumberByDevice(ByVal iDeviceID As Integer) As String
            Dim strsql As String = ""
            Try
                strsql = "SELECT C.cust_model_number as 'ModelName'  FROM tdevice A" & Environment.NewLine
                strsql &= "INNER JOIN tlocation B ON A.Loc_ID = B.Loc_ID " & Environment.NewLine
                strsql &= "INNER JOIN tcustmodel_pssmodel_map C ON A.Model_ID = C.Model_ID AND B.Cust_ID = C.Cust_ID " & Environment.NewLine
                strsql &= "WHERE A.Device_ID = " & iDeviceID
                Return Me._objDataProc.GetSingletonString(strsql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************************
        Public Function Astro_GetCustomerModelList(ByVal iCustID As Integer, ByVal booAddSelectRow As Boolean) As DataTable
            Dim strsql As String = ""
            Dim dt As DataTable
            Dim i As Integer
            Dim R1 As DataTable

            Try
                strsql = "SELECT 0 as ID, cust_model_number as 'ModelName' " & Environment.NewLine
                strsql &= "FROM tcustmodel_pssmodel_map " & Environment.NewLine
                strsql &= "WHERE Cust_ID = " & iCustID & Environment.NewLine
                strsql &= "ORDER BY cust_model_number"
                dt = Me._objDataProc.GetDataTable(strsql)
                For i = 0 To dt.Rows.Count - 1
                    dt.Rows(i).BeginEdit()
                    dt.Rows(i)("ID") = i + 1
                    dt.Rows(i).EndEdit()
                Next i

                If booAddSelectRow Then
                    dt.LoadDataRow(New Object() {"0", "--Select--"}, True)
                End If

                dt.AcceptChanges()

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '***************************************************************************************************
        Public Function Astro_GetPalletShipTypes() As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim drNewRow As DataRow

            Try
                strSql = "SELECT 0 as 'ShipTypeID', 'REF' as 'ShipTypeSDesc', 'REFURBISHED' as 'ShipTypeLDesc' " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                drNewRow = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Function

        '***************************************************************************************************
        Public Function Astro_ProdShip_GetMasterPackBoxes(ByVal iPalletID As Integer) As DataTable
            Dim strsql As String = ""

            Try
                strsql = "SELECT toverpack.* , count(*) as Qty " & Environment.NewLine
                strsql &= "FROM tdevice " & Environment.NewLine
                strsql &= "INNER JOIN tship ON tdevice.Ship_ID = tship.Ship_ID " & Environment.NewLine
                strsql &= "INNER JOIN toverpack ON tship.OverPack_ID = toverpack.OverPack_ID " & Environment.NewLine
                strsql &= "WHERE tdevice.Pallett_ID = " & iPalletID & Environment.NewLine
                strsql &= "GROUP BY toverpack.OverPack_ID ORDER BY OverPack_Name"
                Return Me._objDataProc.GetDataTable(strsql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************************
        Public Function Astro_ProdShip_CreatePallet(ByVal iCustID As Integer, ByVal iLocID As Integer, ByVal iModelID As Integer, ByVal strSkuLen As String, ByVal iPalletShipType As Integer) As Integer
            Dim strSql As String
            Dim objShipping As New PSS.Data.Production.Shipping()
            Dim strPalletName As String, strToday As String
            Dim objDataProc As DBQuery.DataProc
            Dim iPalletID As Integer
            Dim dt As DataTable

            Try
                dt = Me.Astro_ProdShip_OpenBoxPallet(iLocID, iModelID)
                If dt.Rows.Count > 1 Then
                    Throw New Exception("Pallet name " & strPalletName & " existed more than one in the system. Please contact IT.")
                ElseIf dt.Rows.Count = 1 Then
                    If dt.Rows(0)("Pallet_SkuLen").ToString.Trim.ToLower <> strSkuLen.Trim.ToLower OrElse dt.Rows(0)("Bundle").ToString.Trim.ToLower <> strSkuLen.Trim.ToLower Then
                        Throw New Exception("Pallet existed with a different sku length. Please contact IT.")
                    Else
                        iPalletID = CInt(dt.Rows(0)("Pallett_ID"))
                    End If
                Else
                    'Form a name
                    objShipping = New PSS.Data.Production.Shipping()

                    strToday = Generic.MySQLServerDateTime(1)
                    objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                    strPalletName = Skullcandy.PalletShip_Prefix & CDate(strToday).ToString("yyMMdd") & "N"
                    strPalletName = objShipping.GetPalletNameNextSeqNo(objDataProc, iCustID, iLocID, strPalletName, 3)

                    dt = objShipping.GetPalletInfoByName(strPalletName, iCustID)
                    If dt.Rows.Count = 0 Then
                        'Ccreate Box pallet name
                        iPalletID = PSS.Data.Production.Shipping.CreatePallet(iCustID, iLocID, iModelID, 0, strPalletName, iPalletShipType, strSkuLen, 0, 0, 0)
                    ElseIf dt.Rows.Count = 1 Then
                        If dt.Rows(0)("Pallet_SkuLen").ToString.Trim.Length <> strSkuLen Then
                            Throw New Exception("Pallet existed with a different sku length. Please contact IT.")
                        ElseIf Not IsDBNull("Pallett_ShipDate") Then
                            Throw New Exception("Pallet existed with a ship date. Please contact IT.")
                        Else
                            iPalletID = CInt(dt.Rows(0)("Pallett_ID"))
                        End If
                    Else
                        Throw New Exception("Pallet name " & strPalletName & " existed more than one in the system. Please contact IT.")
                    End If
                End If

                Return iPalletID
            Catch ex As Exception
                Throw ex
            Finally
                objShipping = Nothing : objDataProc = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Function

        '***************************************************************************************************
        Public Function Astro_GetPalletInfoByName(ByVal strPalletName As String, ByVal iCustID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT A.*, cust_model_number as 'Bundle'" & Environment.NewLine
                strSql &= " FROM tpallett A" & Environment.NewLine
                strSql &= " INNER JOIN tcustmodel_pssmodel_map B ON A.Model_ID = B.Model_ID AND A.Cust_ID = B.Cust_ID " & Environment.NewLine
                strSql &= " WHERE A.Cust_ID = " & iCustID & " AND Pallett_Name = '" & strPalletName & "'" & Environment.NewLine
                strSql &= " AND Pallet_Invalid = 0 "
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************************
        Public Function Astro_GetDeviceInOverPack(ByVal iCustID As Integer, ByVal iLocID As Integer, ByVal strOverPackName As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT Distinct D.*, A.Device_SN, A.Pallett_ID as DevicePalletID, cust_model_number as 'Bundle', IF(Device_Dateship is null, '', Device_dateShip) as Device_DateShip " & Environment.NewLine
                strSql &= " FROM tdevice A" & Environment.NewLine
                strSql &= " INNER JOIN tcustmodel_pssmodel_map B ON A.Model_ID = B.Model_ID AND B.Cust_ID = " & iCustID & Environment.NewLine
                strSql &= " INNER JOIN tship C ON A.Ship_ID = C.Ship_ID " & Environment.NewLine
                strSql &= " INNER JOIN toverpack D ON C.OverPack_ID = D.OverPack_ID " & Environment.NewLine
                strSql &= " WHERE A.Loc_ID = " & iLocID & " AND OverPack_Name = '" & strOverPackName & "'" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************************
        Public Function Astro_CloseAndShipOverPack(ByVal iCustID As Integer, ByVal iOverPackID As Integer, ByVal iShiftID As Integer, ByVal iPalletShipType As Integer) As Integer
            Dim objProdShip As New Production.Shipping()
            Dim strSql As String = "", strWrkDate As String = "", strShipIDs As String = ""
            Dim iDeviceFinishedGoods As Integer, i As Integer
            Dim dt As DataTable
            Dim R1 As DataRow

            Try
                'validate over pack
                strSql = "SELECT * FROM toverpack WHERE OverPack_ID = " & iOverPackID
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count = 0 Then
                    Throw New Exception("Overpack ID (" & iOverPackID & ") does not exist.")
                ElseIf dt.Rows(0)("Closed").ToString.Trim = "1" Then
                    Throw New Exception("Overpack ID (" & iOverPackID & ") has been closed.")
                ElseIf Not IsDBNull(dt.Rows(0)("Pallett_ID")) AndAlso CInt(dt.Rows(0)("Pallett_ID")) > 0 Then
                    Throw New Exception("Overpack ID (" & iOverPackID & ") has assigned to a pallet.")
                End If

                'Check Ship Date
                strSql = "SELECT count(*) as cnt " & Environment.NewLine
                strSql &= "FROM tdevice INNER JOIN tship ON tdevice.Ship_ID = tship.Ship_ID " & Environment.NewLine
                strSql &= "WHERE OverPack_ID = " & iOverPackID & " AND Device_DateShip is not null " & Environment.NewLine
                If Me._objDataProc.GetIntValue(strSql) > 0 Then Throw New Exception("Some units in box have been shipped. Please refresh your screen.")

                'Check Model
                strSql = "SELECT DISTINCT cust_model_number " & Environment.NewLine
                strSql &= "FROM tdevice INNER JOIN tship ON tdevice.Ship_ID = tship.Ship_ID " & Environment.NewLine
                strSql &= " INNER JOIN tcustmodel_pssmodel_map ON tdevice.Model_ID = tcustmodel_pssmodel_map.Model_ID AND tcustmodel_pssmodel_map.Cust_ID = " & iCustID & Environment.NewLine
                strSql &= "WHERE OverPack_ID = " & iOverPackID & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 1 Then Throw New Exception("Box has mix model. Please contact IT.")

                'Get list of ship IDs
                strSql = "SELECT distinct tdevice.Ship_ID FROM tdevice INNER JOIN tship ON tdevice.ship_id = tship.ship_id " & Environment.NewLine
                strSql &= "WHERE OverPack_ID = " & iOverPackID
                dt = Me._objDataProc.GetDataTable(strSql)
                For Each R1 In dt.Rows
                    If strShipIDs.Trim.Length > 0 Then strShipIDs &= ", "
                    strShipIDs &= R1("Ship_ID").ToString
                Next R1

                If iPalletShipType = 0 Then iDeviceFinishedGoods = 1 Else iDeviceFinishedGoods = 0
                strWrkDate = Generic.GetWorkDate(iShiftID)
                If strWrkDate.Trim.Length = 0 Then Throw New Exception("System has failed to define work date.")

                'Update tdevice, tcellopt
                strSql = "UPDATE tdevice, tcellopt SET Device_DateShip = now(), Device_ShipWorkDate = '" & strWrkDate & "'" & Environment.NewLine
                strSql &= ", Shift_ID_Ship = " & iShiftID & ", Device_FinishedGoods = " & iDeviceFinishedGoods & Environment.NewLine
                strSql &= ", Cellopt_WIPOwnerOld = Cellopt_WIPOwner , Cellopt_WIPOwner = 5 , Cellopt_WIPEntryDt = now(), WorkStation = 'PRODUCTION COMPLETED', WorkStationEntryDt = now() " & Environment.NewLine
                strSql &= " WHERE tdevice.Device_ID = tcellopt.Device_ID AND tdevice.Ship_ID IN ( " & strShipIDs & ") " & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)
                If i = 0 Then Throw New Exception("System has failed to save ship information in tdevice and tcellopt.")

                strSql = "UPDATE toverpack SET Closed = 1, ClosedDateTime = now(), OverPack_ShipDate = now() WHERE OverPack_ID in ( " & iOverPackID & " ) "
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '***************************************************************************************************
        Public Function Astro_ProdShip_AssignOverPackToPallet(ByVal iLocID As Integer, ByVal iPalletID As Integer, ByVal iOverPackID As Integer) As Integer
            Dim strSql As String = ""
            Dim i As Integer

            Try
                strSql = "UPDATE tdevice  " & Environment.NewLine
                strSql &= " INNER JOIN tship ON tdevice.Ship_ID = tship.Ship_ID " & Environment.NewLine
                strSql &= " SET tdevice.Pallett_ID = " & iPalletID & Environment.NewLine
                strSql &= " WHERE tdevice.Loc_ID = " & iLocID & " AND tship.OverPack_ID = " & iOverPackID & Environment.NewLine
                strSql &= " AND tdevice.Pallett_ID is null "
                i = Me._objDataProc.ExecuteNonQuery(strSql)
                If i = 0 Then Throw New Exception("System has failed to assign pallet id to device.")

                strSql = "UPDATE toverpack  " & Environment.NewLine
                strSql &= " SET Pallett_ID = " & iPalletID & Environment.NewLine
                strSql &= " WHERE OverPack_ID = " & iOverPackID & Environment.NewLine
                strSql &= " AND Pallett_ID is null"
                i = Me._objDataProc.ExecuteNonQuery(strSql)
                If i = 0 Then Throw New Exception("System has failed to assign pallet id to device.")

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************************
        Public Function Astro_ProdShip_RemoveOverPackFrPallet(ByVal iLocID As Integer, ByVal iOverPackID As Integer) As Integer
            Dim strSql As String = ""
            Dim i As Integer

            Try
                strSql = "UPDATE tdevice  " & Environment.NewLine
                strSql &= " INNER JOIN tship ON tdevice.Ship_ID = tship.Ship_ID " & Environment.NewLine
                strSql &= " SET tdevice.Pallett_ID = null " & Environment.NewLine
                strSql &= " WHERE tdevice.Loc_ID = " & iLocID & " AND tship.OverPack_ID = " & iOverPackID & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                strSql = "UPDATE toverpack  " & Environment.NewLine
                strSql &= " SET Pallett_ID = null " & Environment.NewLine
                strSql &= " WHERE OverPack_ID = " & iOverPackID & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************************
        Public Function Astro_ProdShip_RemoveAllOverPacksFrPallet(ByVal iLocID As Integer, ByVal iPalletID As Integer) As Integer
            Dim strSql As String = ""
            Dim i As Integer

            Try
                strSql = "UPDATE tdevice  " & Environment.NewLine
                strSql &= " SET tdevice.Pallett_ID = null " & Environment.NewLine
                strSql &= " WHERE tdevice.Loc_ID = " & iLocID & " AND Pallett_ID = " & iPalletID & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                strSql = "UPDATE toverpack  " & Environment.NewLine
                strSql &= " SET Pallett_ID = null " & Environment.NewLine
                strSql &= " WHERE Pallett_ID = " & iPalletID & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************************
        Public Function Astro_ProdShip_ClosePallet(ByVal iPalletID As Integer, ByVal iPalletQty As Integer, ByVal iShiftID As Integer) As Integer
            Dim objProdShip As New Production.Shipping()
            Dim strSQL As String, strWrkDate As String = ""
            Dim i As Integer = 0

            Try
                strWrkDate = Generic.GetWorkDate(iShiftID)
                If strWrkDate.Trim.Length = 0 Then Throw New Exception("System has failed to define work date.")

                'Update tDevice
                i = 0
                strSQL = "UPDATE tpallett " & Environment.NewLine
                strSQL &= " SET Pallett_ShipDate = now() , Pallett_BulkShipped = 1, Pallett_ReadyToShipFlg = 1, Pallett_QTY = " & iPalletQty & Environment.NewLine
                strSQL &= " WHERE Pallett_ID = " & iPalletID & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSQL)
                If i = 0 Then Throw New Exception("System has failed to save ship information in tpallet.")

                objProdShip.UpdateWOStatus(iPalletID, strWrkDate, )

                Return i

            Catch ex As Exception
                Throw ex
            Finally
                objProdShip = Nothing
            End Try
        End Function

        '***************************************************************************************************
        Public Function Astro_ProdShip_CreateOverPackByPalletAndDeletePallet(ByVal iCustID As Integer, ByVal strPalletName As String, ByVal iUserID As Integer) As Integer
            Dim strSql As String = ""
            Dim i As Integer, iOverPackID As Integer
            Dim dt, dtOverPack As DataTable
            Dim objProdShip As New Production.Shipping()

            Try
                dt = objProdShip.GetPalletInfoByName(strPalletName, iCustID)
                If dt.Rows.Count = 0 Then
                    Throw New Exception("Pallet does not existed.")
                ElseIf dt.Rows.Count > 1 Then
                    Throw New Exception("Pallet existed more than one the system.")
                ElseIf Not IsDBNull(dt.Rows(0)("pkslip_ID")) AndAlso CInt(dt.Rows(0)("pkslip_ID")) > 0 Then
                    Throw New Exception("Pallet has been dock shipped.")
                Else
                    strSql = "SELECT * FROM toverpack WHERE OverPack_Name = '" & strPalletName & "'"
                    dtOverPack = Me._objDataProc.GetDataTable(strSql)
                    If dtOverPack.Rows.Count > 0 Then Throw New Exception("Over pack existed.")

                    iOverPackID = objProdShip.CreateOverPackWithName(CInt(dt.Rows(0)("Loc_ID")), CInt(dt.Rows(0)("Model_ID")), dt.Rows(0)("Pallett_Name").ToString, CInt(dt.Rows(0)("Pallet_ShipType")))
                    strSql = "UPDATE tship INNER JOIN tdevice ON tship.ship_id = tdevice.Ship_ID  " & Environment.NewLine
                    strSql &= " SET tship.OverPack_ID = " & iOverPackID & Environment.NewLine
                    strSql &= " WHERE tdevice.Pallett_ID = " & CInt(dt.Rows(0)("Pallett_ID")) & Environment.NewLine
                    i = Me._objDataProc.ExecuteNonQuery(strSql)

                    strSql = "UPDATE tdevice SET Pallett_ID = null " & Environment.NewLine
                    strSql &= " WHERE tdevice.Pallett_ID = " & CInt(dt.Rows(0)("Pallett_ID")) & Environment.NewLine
                    i = Me._objDataProc.ExecuteNonQuery(strSql)

                    strSql = "UPDATE toverpack  " & Environment.NewLine
                    strSql &= " SET OverPack_ShipDate = '" & CDate(dt.Rows(0)("Pallett_ShipDate")).ToString("yyyy-MM-dd HH:mm:ss") & "', Closed = 1, ClosedDateTime = now() " & Environment.NewLine
                    strSql &= " WHERE OverPack_ID = " & iOverPackID & Environment.NewLine
                    i = Me._objDataProc.ExecuteNonQuery(strSql)

                    strSql = "UPDATE tpallett SET Pallet_Invalid = 1, Pallet_InvalidUsrID = " & iUserID & Environment.NewLine
                    strSql &= " WHERE Pallett_ID = " & CInt(dt.Rows(0)("Pallett_ID")) & Environment.NewLine
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                End If

                Return iOverPackID
            Catch ex As Exception
                Throw ex
            Finally
                objProdShip = Nothing
                Generic.DisposeDT(dt) : Generic.DisposeDT(dtOverPack)
            End Try
        End Function

        '***************************************************************************************************

#End Region

            '*********************************************************************************************



    End Class
End Namespace
