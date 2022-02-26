Option Explicit On 

Imports System
Imports System.Data
Imports System.Text
Imports MySql.Data


Namespace Buisness.TracFoneFulfillmentKit
    Public Class TFFK_Receiving

        Private _objDataProc As mySQL5

#Region "Constructor/Destructor"

        '******************************************************************
        Public Sub New()
            Try
                Me._objDataProc = New mySQL5()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '******************************************************************
        Protected Overrides Sub Finalize()
            Me._objDataProc = Nothing
            MyBase.Finalize()
        End Sub

#End Region

        Public Function getTestData() As DataTable
            Dim strSql As String = ""

            Try
                strSql = "Select" & Environment.NewLine
                strSql &= " A.Model_Desc,A.Model_LDesc,B.Dcode_SDesc AS 'UPC',A.Weight,C.DCode_SDesc as 'Class'" & Environment.NewLine
                strSql &= " ,D.DCode_SDesc as 'Subclass',A.Height,A.Width,A.Length,E.DCode_SDesc as 'Techology'" & Environment.NewLine
                strSql &= " ,A.UPC_DCode_ID,A.Class_DCode_ID,A.SubClass_DCode_ID,A.Tech_Dcode_ID,A.Prod_ID,A.Has_BC,A.User_ID,A.UpdateDate,A.Model_ID" & Environment.NewLine
                strSql &= "  from production.tmodel_items A" & Environment.NewLine
                strSql &= "  left join production.lcodesdetail B ON A.UPC_DCode_ID=B.DCode_ID" & Environment.NewLine
                strSql &= "  left join production.lcodesdetail C ON A.Class_DCode_ID=C.DCode_ID" & Environment.NewLine
                strSql &= "  left join production.lcodesdetail D ON A.SubClass_DCode_ID=D.DCode_ID" & Environment.NewLine
                strSql &= "  left join production.lcodesdetail E ON A.Tech_DCode_ID=E.DCode_ID;" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function InertTestData() As Integer
            Dim strSql As String = ""

            Try
                strSql = "Insert Into test.mytest (Field1)" & Environment.NewLine
                strSql &= " Values" & Environment.NewLine
                strSql &= " ('b123')," & Environment.NewLine
                strSql &= " ('b234')," & Environment.NewLine
                strSql &= " ('b345');" & Environment.NewLine

                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function UpdateTestData() As Integer
            Dim strSql As String = ""

            Try
                strSql = "Update  test.mytest set Field1='9999999' where ID=10;" & Environment.NewLine

                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function InertTestDataGetLastInsertKey() As Integer
            Dim strSql As String = ""

            Try
                strSql = "Insert Into test.mytest2 (Field1)" & Environment.NewLine
                strSql &= " Values" & Environment.NewLine
                strSql &= " ('b123')," & Environment.NewLine
                strSql &= " ('b234')," & Environment.NewLine
                strSql &= " ('b345');" & Environment.NewLine

                Return Me._objDataProc.GetLastInsertedPrimaryKey(strSql, "test.mytest2")

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function InertTestDataGetLastInsertKey2() As Integer
            Dim strSql As String = ""

            Try
                strSql = "Insert Into test.mytest2 (Field1,Field2)" & Environment.NewLine
                strSql &= " Values" & Environment.NewLine
                strSql &= " ('b345',1122334455);" & Environment.NewLine

                Return Me._objDataProc.GetLastInsertedPrimaryKey(strSql, "test.mytest2")

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function InertTestDataGetLastInsertKey3() As Integer
            Dim strSql As String = ""

            Try
                strSql = "Insert Into test.mytest2 (Field1,Field2)" & Environment.NewLine
                strSql &= " Values" & Environment.NewLine
                strSql &= " ('b234',11111)," & Environment.NewLine
                strSql &= " ('b345',22222);" & Environment.NewLine

                Return Me._objDataProc.GetLastInsertedPrimaryKey(strSql, "test.mytest2")

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetOpenOrderDetails(ByVal strOrderNo As String) As DataTable
            Dim strSql As String = ""

            Try
                strOrderNo = strOrderNo.Replace("'", "''")
                'strSql = "SELECT A.OrderNo,D.VN_ItemNo as 'Item',B.QtyOrdered as 'Order_Qty',0 as Rec_Qty,D.SN" & Environment.NewLine
                'strSql &= " ,IF(B.Model_ID = E.Model_ID,'Yes','No') as 'IsItemMatched',IF(D.VN_ItemNo = E.Model_Desc,'Yes','No') as 'IsItemDescMatched'" & Environment.NewLine
                'strSql &= " ,G.Cust_Name1 as 'Customer',F.Loc_Name,D.Device_ID,D.WR_ID,B.OD_ID,A.OrderNo,A.Order_ID,B.Model_ID,C.WO_ID,C.Loc_ID,F.Cust_ID,D.Item_ID" & Environment.NewLine
                'strSql &= " FROM edi.torder A" & Environment.NewLine
                'strSql &= " INNER JOIN edi.torderdetail B ON A.order_ID=B.Order_ID" & Environment.NewLine
                'strSql &= " INNER JOIN production.tworkorder C ON A.OrderNo=C.WO_CustWO" & Environment.NewLine
                'strSql &= " INNER JOIN production.tLocation F ON C.Loc_ID=F.Loc_ID" & Environment.NewLine
                'strSql &= " INNER JOIN production.tcustomer G ON F.Cust_ID=G.Cust_ID" & Environment.NewLine
                'strSql &= " INNER JOIN edi.titem D ON A.OrderNo=D.OrderNo" & Environment.NewLine
                'strSql &= " LEFT JOIN production.tmodel_items E ON B.Model_ID = E.Model_ID AND E.iDataSet_ID=1" & Environment.NewLine
                'strSql &= " WHERE A.OrderNo='" & strOrderNo & "' AND C.WO_Closed=0;" & Environment.NewLine
                strSql = "SELECT A.OrderNo,D.VN_ItemNo as 'Item',B.QtyOrdered as 'Order_Qty',0 as Rec_Qty,B.QtyOrdered as 'EDI856_Qty',D.SN" & Environment.NewLine
                strSql &= "  ,IF(B.Model_ID = E.Model_ID,'Yes','No') as 'IsItemMatched',IF(D.VN_ItemNo = E.Model_Desc,'Yes','No') as 'IsItemDescMatched'" & Environment.NewLine
                strSql &= " ,if(E.iModelSet=2,'Phone',if(E.iModelSet=3,'Raw Material','Undefined')) as 'Class'" & Environment.NewLine
                strSql &= "  ,G.Cust_Name1 as 'Customer',F.Loc_Name,D.Device_ID,D.WR_ID,B.OD_ID,A.Order_ID,B.Model_ID,C.WO_ID,C.Loc_ID,F.Cust_ID,E.iModelSet,D.Item_ID" & Environment.NewLine
                strSql &= " FROM edi.torder A" & Environment.NewLine
                strSql &= " INNER JOIN edi.torderdetail B ON A.order_ID=B.Order_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tworkorder C ON A.OrderNo=C.WO_CustWO" & Environment.NewLine
                strSql &= " INNER JOIN production.tLocation F ON C.Loc_ID=F.Loc_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tcustomer G ON F.Cust_ID=G.Cust_ID" & Environment.NewLine
                strSql &= " INNER JOIN edi.titem D ON A.OrderNo=D.OrderNo" & Environment.NewLine
                strSql &= " INNER JOIN production.tmodel_items E ON B.Model_ID = E.Model_ID AND E.iDataSet_ID=1" & Environment.NewLine
                strSql &= " WHERE A.OrderNo='" & strOrderNo & "' AND C.WO_Closed=0;" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetOpenOrder(ByVal strOrderNo As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim row As DataRow
            Dim i As Integer = 0

            Try
                strOrderNo = strOrderNo.Replace("'", "''")
                'strSql = "SELECT D.VN_ItemNo as 'Item',COUNT(B.QtyOrdered) as 'Order_Qty',0 as 'Rec_Qty','Open' as 'Status'" & Environment.NewLine
                'strSql &= " ,A.OrderNo,G.Cust_Name1 as 'Customer',F.Loc_Name,A.OrderNo,A.Order_ID,B.Model_ID,C.WO_ID,0 as 'Recv_WR_ID',C.Loc_ID,F.Cust_ID" & Environment.NewLine
                'strSql &= " FROM edi.torder A" & Environment.NewLine
                'strSql &= " INNER JOIN edi.torderdetail B ON A.order_ID=B.Order_ID" & Environment.NewLine
                'strSql &= " INNER JOIN production.tworkorder C ON A.OrderNo=C.WO_CustWO" & Environment.NewLine
                'strSql &= " INNER JOIN production.tLocation F ON C.Loc_ID=F.Loc_ID" & Environment.NewLine
                'strSql &= " INNER JOIN production.tcustomer G ON F.Cust_ID=G.Cust_ID" & Environment.NewLine
                'strSql &= " INNER JOIN edi.titem D ON A.OrderNo=D.OrderNo" & Environment.NewLine
                'strSql &= " LEFT JOIN production.tmodel_items E ON B.Model_ID = E.Model_ID AND E.iDataSet_ID=1" & Environment.NewLine
                'strSql &= " WHERE A.OrderNo='" & strOrderNo & "' AND C.WO_Closed=0" & Environment.NewLine
                'strSql &= " GROUP BY  A.OrderNo,D.VN_ItemNo;" & Environment.NewLine

                strSql = "SELECT D.VN_ItemNo as 'Item',A.OrderQty as 'Order_Qty',0 as 'Rec_Qty',COUNT(B.QtyOrdered) as 'EDI856_Qty','Open' as 'Status'" & Environment.NewLine
                strSql &= " ,if(E.iModelSet=2,'Phone',if(E.iModelSet=3,'Raw Material','Undefined')) as 'Class'" & Environment.NewLine
                strSql &= "  ,A.OrderNo,G.Cust_Name1 as 'Customer',F.Loc_Name,A.Order_ID,B.Model_ID,C.WO_ID,0 as 'RowID'" & Environment.NewLine
                strSql &= " ,0 as 'Recv_WR_ID',C.Loc_ID,F.Cust_ID,E.iModelSet" & Environment.NewLine
                strSql &= " FROM edi.torder A" & Environment.NewLine
                strSql &= " INNER JOIN edi.torderdetail B ON A.order_ID=B.Order_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tworkorder C ON A.OrderNo=C.WO_CustWO" & Environment.NewLine
                strSql &= " INNER JOIN production.tLocation F ON C.Loc_ID=F.Loc_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tcustomer G ON F.Cust_ID=G.Cust_ID" & Environment.NewLine
                strSql &= " INNER JOIN edi.titem D ON A.OrderNo=D.OrderNo" & Environment.NewLine
                strSql &= " INNER JOIN production.tmodel_items E ON B.Model_ID = E.Model_ID AND E.iDataSet_ID=1" & Environment.NewLine
                strSql &= " WHERE A.OrderNo='" & strOrderNo & "' AND C.WO_Closed=0" & Environment.NewLine
                strSql &= " GROUP BY  A.OrderNo,D.VN_ItemNo;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                i = 0
                For Each row In dt.Rows
                    i = +1
                    row.BeginEdit() : row("RowID") = i : row.AcceptChanges()
                Next

                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function ReceiveDevices(ByRef dtDevices As DataTable, _
                                       ByVal strRMA As String, _
                                       ByVal iWO_ID As Integer, _
                                       ByVal iLoc_ID As Integer, _
                                       ByVal iModel_ID As Integer, _
                                       ByVal iUserID As Integer, _
                                       ByVal strWB_IDs As String, _
                                       ByVal strRecDateTime As String, _
                                       ByRef iRecv_WR_ID As Integer, _
                                       ByRef errMsg As String) As Boolean

            Dim strSql As String = ""
            Dim dtInsertedDevices, dtWH, dtTmp As DataTable
            Dim strSQL_Part As String = ""
            Dim strSQL_Part_Two As String = ""
            Dim strSQL_Part_Three As String = ""
            Dim strItemIDs As String = ""
            Dim strWorkStation As String = "WH-WIP"
            Dim strPrefixItemBoxName As String = "FK"
            Dim iDataSet_ID As Integer = 1

            Dim row As DataRow
            Dim iWR_ID As Integer = 0
            Dim i As Integer = 0, k As Integer = 0

            Dim bRet As Boolean = False

            Try
                errMsg = ""

                'Save to tdevice---------------------------------------------------------
                For Each row In dtDevices.Rows
                    k += 1
                    If strSQL_Part.Trim.Length = 0 Then
                        strSQL_Part = "('" & Trim(row("SN")).ToString.Replace("'", "''") & "','" & strRecDateTime & "'," & _
                                      iModel_ID & "," & iLoc_ID & "," & iWO_ID & "," & Convert.ToInt32(row("Item_ID")).ToString & ")"
                        strItemIDs = Convert.ToInt32(row("Item_ID")).ToString
                    Else
                        strSQL_Part &= ",('" & Trim(row("SN")).ToString.Replace("'", "''") & "','" & strRecDateTime & "'," & _
                                      iModel_ID & "," & iLoc_ID & "," & iWO_ID & "," & Convert.ToInt32(row("Item_ID")).ToString & ")"
                        strItemIDs &= "," & Convert.ToInt32(row("Item_ID")).ToString
                    End If
                    If k = dtDevices.Rows.Count Then strSQL_Part &= ";"
                Next

                strSql = "SELECT * FROM production.tdevice WHERE Item_ID in (" & strItemIDs & ");"
                dtTmp = Me._objDataProc.GetDataTable(strSql)
                If dtTmp.Rows.Count > 0 Then
                    bRet = False : errMsg = "At least," & dtTmp.Rows.Count & " devices were received. Can't receive them to tdevice. See IT. " & Environment.NewLine
                    Exit Try
                End If

                strSql = "INSERT INTO production.tdevice (Device_SN,Device_DateRec,Model_ID,Loc_ID,WO_ID,Item_ID)"
                strSql &= " VALUES" & strSQL_Part
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                If Not i > 0 Then
                    bRet = False : errMsg = "Failed to insert devices to tdevice. " & Environment.NewLine
                    Exit Try
                End If

                strSql = "SELECT device_ID,Item_ID,Device_SN FROM production.tdevice where Item_ID in (" & strItemIDs & ");"
                dtInsertedDevices = Me._objDataProc.GetDataTable(strSql)

                If Not dtDevices.Rows.Count = dtInsertedDevices.Rows.Count Then
                    bRet = False : errMsg = "Device count doesn't match Inserted devices count. " & Environment.NewLine
                    Exit Try
                End If

                'Update edi.titem, Insert to tCellopt -----------------------------------------------------------------------------
                strSQL_Part = "" : k = 0 : i = 0 : strSQL_Part_Two = ""
                For Each row In dtInsertedDevices.Rows
                    strSQL_Part &= " WHEN " & Convert.ToInt32(row("item_ID")).ToString & " THEN " & Convert.ToInt32(row("Device_ID")).ToString

                    k += 1
                    If strSQL_Part_Two.Trim.Length = 0 Then
                        strSQL_Part_Two = "(" & Convert.ToInt32(row("Device_ID")).ToString & ",'" & strWorkStation & "','" & Trim(row("Device_SN")).ToString.Replace("'", "''") & "')"
                    Else
                        strSQL_Part_Two &= ",(" & Convert.ToInt32(row("Device_ID")).ToString & ",'" & strWorkStation & "','" & Trim(row("Device_SN")).ToString.Replace("'", "''") & "')"
                    End If
                    If k = dtInsertedDevices.Rows.Count Then strSQL_Part_Two &= ";"
                Next
                strSql = "UPDATE  edi.titem" & Environment.NewLine
                strSql &= " SET Device_ID  = CASE Item_ID" & Environment.NewLine
                strSql &= strSQL_Part & " END "
                strSql &= " WHERE Item_ID IN (" & strItemIDs & ");"
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                strSql = "INSERT INTO production.tcellopt (Device_ID,Workstation,Manuf_SN)" & Environment.NewLine
                strSql &= " VALUES " & strSQL_Part_Two & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                'warehouse_receipt,warehouse_Items
                dtWH = Me.CreateWarehouseReceiptBox(strPrefixItemBoxName, strRMA, dtDevices.Rows.Count, iLoc_ID, iWO_ID, iDataSet_ID, iUserID, strRecDateTime)
                If Not dtWH.Rows.Count > 0 Then
                    bRet = False : errMsg = "Can't find receipt box." & Environment.NewLine
                    Exit Try
                End If
                iWR_ID = Convert.ToInt32(dtWH.Rows(0).Item("WR_ID"))

                If Not dtInsertedDevices.Rows.Count = dtDevices.Rows.Count Then
                    bRet = False : errMsg = "Received device count doesn't match EDI device count." & Environment.NewLine
                    Exit Try
                End If
                k = 0 : strSQL_Part_Three = ""
                For Each row In dtInsertedDevices.Rows ' dtDevices.Rows
                    k += 1
                    If strSQL_Part_Three.Trim.Length = 0 Then
                        strSQL_Part_Three = "(" & iWR_ID & "," & Convert.ToInt32(row("Device_ID")).ToString & "," & _
                                              iModel_ID & ",'" & Trim(row("Device_SN")).ToString.Replace("'", "''") & _
                                              "'," & iUserID & ",'" & strRecDateTime & "')"
                    Else
                        strSQL_Part_Three &= ",(" & iWR_ID & "," & Convert.ToInt32(row("Device_ID")).ToString & "," & _
                                              iModel_ID & ",'" & Trim(row("Device_SN")).ToString.Replace("'", "''") & _
                                              "'," & iUserID & ",'" & strRecDateTime & "')"
                    End If
                    If k = dtInsertedDevices.Rows.Count Then strSQL_Part_Three &= ";"
                Next
                strSql = "INSERT INTO warehouse.warehouse_items (WR_ID,Device_ID,Model_ID,Serial,Recpt_UsrID,Date_Received)" & Environment.NewLine
                strSql &= " VALUES " & strSQL_Part_Three & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                ' updates edi.titem
                strSql = "UPDATE edi.titem SET WR_ID=" & iWR_ID & " WHERE Item_ID in (" & strItemIDs & ");"
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                'close edi.twarehousebox
                strSql = "UPDATE edi.twarehousebox SET WR_ID= " & iWR_ID & ",Workstation = '" & strWorkStation & "', Closed=1" & Environment.NewLine
                strSql &= " WHERE wb_id in (" & strWB_IDs & ");" & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                iRecv_WR_ID = iWR_ID
                bRet = True

            Catch ex As Exception
                bRet = False
                Throw ex
            End Try

            Return bRet
        End Function


        Public Function AreWarehouseSNsDuplicate(ByVal strSNs As String, Optional ByRef strArrLst As ArrayList = Nothing) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim bRet As Boolean = False
            Dim row As DataRow

            Try
                strSql = "SELECT * from warehouse.warehouse_items" & Environment.NewLine
                strSql &= " WHERE Serial in (" & strSNs & ") AND SoDetailsID >0;" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    For Each row In dt.Rows
                        strArrLst.Add(row("serial"))
                    Next
                    bRet = True
                End If

                Return bRet
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function AreDeviceSNsDuplicate(ByVal strSNs As String, Optional ByRef strArrLst As ArrayList = Nothing) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim bRet As Boolean = False
            Dim row As DataRow

            Try
                strSql = "SELECT * from production.tdevice" & Environment.NewLine
                strSql &= " WHERE Device_SN in (" & strSNs & ") AND Device_DateShip IS NULL;" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    For Each row In dt.Rows
                        strArrLst.Add(row("Device_SN"))
                    Next
                    bRet = True
                End If

                Return bRet
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetSkidBoxes(ByVal strWB_IDs As String) As DataTable
            Dim strSql As String = ""

            Try

                strSql = "SELECT * FROM edi.twarehousebox WHERE WB_ID in (" & strWB_IDs & ");"

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetOrderItemsSkidTableDef() As DataTable
            Dim strSql As String = ""

            Try

                strSql = "SELECT 0 as 'Skid',0 as 'Qty', '' as 'Item','' as 'OrderNo','' as 'BoxName',0 as 'wb_ID';"

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function CreateWHRecvBoxID(ByVal iModelID As Integer, _
                                          ByVal iOrder_ID As Integer, _
                                          ByVal iFuncRep As Integer, _
                                          ByVal iQty As Integer, _
                                          ByVal strPrefixBoxName As String, _
                                          ByVal strBoxStage As String, _
                                          Optional ByVal strWorkStation As String = "", _
                                          Optional ByVal strWhLocation As String = "") As DataTable
            Dim strSql As String = ""
            Dim strSvrDTime As String = ""
            Dim iNextSeqNo As Integer = 0
            Dim strBoxID As String = ""
            Dim iWHBoxID As Integer = 0
            Dim iWrtyFlag As Integer = 0
            Dim iWrtyExpInLess31Days As Integer = 0
            'Dim dt As DataTable
            'Dim R1 As DataRow
            Dim objTFFK As New TFFK()

            Try
                strSvrDTime = Format(CDate(Generic.MySQLServerDateTime()), "yyyyMMdd")
                If strSvrDTime.Trim.Length = 0 Then strSvrDTime = Format(Now(), "yyyyMMdd")

                strBoxID &= strPrefixBoxName & strSvrDTime & "-"

                iNextSeqNo = objTFFK.GetWHBoxNexSeqNo(strBoxID, objTFFK._iWHBoxSegDigitCnt)
                If iNextSeqNo = 0 Then Throw New Exception("System has failed to get next box number.")
                strBoxID = strBoxID & iNextSeqNo.ToString.PadLeft(objTFFK._iWHBoxSegDigitCnt, "0")

                iWHBoxID = objTFFK.InsertEdiWarehouseBox(strBoxID, iFuncRep, iWrtyFlag, iOrder_ID, iModelID, iWrtyExpInLess31Days, iQty, 0, strBoxStage, strWorkStation, strWhLocation)
                If iWHBoxID = 0 Then Throw New Exception("System has failed to create new box.")

                strSql = "Select * from edi.twarehousebox where wb_ID=" & iWHBoxID
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            Finally
                objTFFK = Nothing
            End Try
        End Function

        Public Function CreateWarehouseReceiptBox(ByVal strPrefixBoxName As String, _
                                           ByVal strRMA As String, _
                                           ByVal iOrderItemQty As Integer, _
                                           ByVal iLoc_ID As Integer, _
                                           ByVal iWO_ID As Integer, _
                                           ByVal iDataSet_ID As Integer, _
                                           ByVal iUserID As Integer, _
                                           ByVal strDateTime As String) As DataTable
            Dim strSql As String = ""
            Dim strSvrDTime As String = ""
            Dim iNextSeqNo As Integer = 0
            Dim strBoxName As String = ""
            Dim iWR_ID As Integer = 0


            Dim objTFFK As New TFFK()

            Try
                strSvrDTime = Format(CDate(Generic.MySQLServerDateTime()), "yyyyMMdd")
                If strSvrDTime.Trim.Length = 0 Then strSvrDTime = Format(Now(), "yyyyMMdd")

                strBoxName &= strPrefixBoxName & strSvrDTime & "-"

                iNextSeqNo = objTFFK.GetWarehouseReceiptBoxNexSeqNo(strBoxName, objTFFK._iWHBoxSegDigitCnt)
                If iNextSeqNo = 0 Then Throw New Exception("System has failed to get next box number.")
                strBoxName = strBoxName & iNextSeqNo.ToString.PadLeft(objTFFK._iWHBoxSegDigitCnt, "0")

                strSql = "INSERT INTO  warehouse.warehouse_Receipt (WR_Name,RMA,Receipt_QTY,Closed,Loc_ID,WO_ID,iDataSet_ID,User_ID,Receipt_Date)" & Environment.NewLine
                strSql &= " VALUES" & Environment.NewLine
                strSql &= "('" & strBoxName & "','" & strRMA & "'," & iOrderItemQty & ",0," & iLoc_ID & "," & iWO_ID & "," & iDataSet_ID & "," & iUserID & ",'" & strDateTime & "');"
                iWR_ID = Me._objDataProc.GetLastInsertedPrimaryKey(strSql, "warehouse.warehouse_Receipt")

                strSql = "Select * from warehouse.warehouse_Receipt where WR_ID=" & iWR_ID
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            Finally
                objTFFK = Nothing
            End Try
        End Function

        Public Function PrintWarehouseFKRecBoxID(ByVal strBoxName As String, _
                                                 ByVal strModel As String, _
                                                 ByVal iBoxQty As Integer, _
                                                 ByVal strTFPoNo As String, _
                                                 ByVal strMfgPoNo As String, _
                                                 ByVal strReceiptDate As String, _
                                                 ByVal strReceiptNo As String, _
                                                 ByVal iCopyNumber As Integer) As Integer
            Const strReportName As String = "TF_FK_Receiving_Label.rpt"
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim objTFMisc As PSS.Data.Buisness.TracFone.clsMisc
            Try
                strSql = "Select '" & strBoxName & "' as BoxName " & Environment.NewLine
                strSql &= ", '" & strModel & "' as Model_Desc " & Environment.NewLine
                strSql &= ", " & iBoxQty & " as Qty " & Environment.NewLine
                strSql &= ", '" & strTFPoNo & "' as TFPoNo" & Environment.NewLine
                strSql &= ", '" & strMfgPoNo & "' as MfgPoNo" & Environment.NewLine
                strSql &= ", '" & strReceiptDate & "' as ReceiptDate" & Environment.NewLine
                strSql &= ", '" & strReceiptNo & "' as ReceiptNo" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                '**********************
                'Print Box lablel
                '**********************
                Try
                    objTFMisc = New PSS.Data.Buisness.TracFone.clsMisc()
                    objTFMisc.PrintCrystalReportLabel(dt, strReportName, iCopyNumber, "2DBoxLabel")
                Catch ex As Exception
                    '2DBoxLabel is not available then try default printer
                    objTFMisc.PrintCrystalReportLabel(dt, strReportName, iCopyNumber, )
                End Try
                '**********************

                Return dt.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        Public Function PrintPickLocation(ByVal strModel As String, _
                                                 ByVal iBoxQty As Integer, _
                                                 ByVal strPickLoc As String, _
                                                 ByVal iCopyNumber As Integer) As Integer
            Const strReportName As String = "TF_FK_Pick_Location.rpt"
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim objTFMisc As PSS.Data.Buisness.TracFone.clsMisc
            Try
                strSql = "Select '" & strModel & "' as Item " & Environment.NewLine
                strSql &= ", " & iBoxQty & " as Qty " & Environment.NewLine
                strSql &= ", '" & strPickLoc & "' as Location" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                '**********************
                'Print Box lablel
                '**********************
                Try
                    objTFMisc = New PSS.Data.Buisness.TracFone.clsMisc()
                    objTFMisc.PrintCrystalReportLabel(dt, strReportName, iCopyNumber, "BrotherP")
                Catch ex As Exception
                    'BotherP regular laser printer is not available then try default printer
                    objTFMisc.PrintCrystalReportLabel(dt, strReportName, iCopyNumber, )
                End Try
                '**********************

                Return dt.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        Public Function PrintQuarantineBoxLabel(ByVal strBoxName As String, _
                                                 ByVal strModel As String, _
                                                 ByVal iBoxQty As Integer, _
                                                 ByVal strQuarantineDate As String, _
                                                 ByVal iCopyNumber As Integer) As Integer
            Const strReportName As String = "TF_FK_Quarantine_Label.rpt"
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim objTFMisc As PSS.Data.Buisness.TracFone.clsMisc
            Try
                strSql = "Select '" & strBoxName & "' as BoxName " & Environment.NewLine
                strSql &= ", '" & strModel & "' as Model_Desc " & Environment.NewLine
                strSql &= ", " & iBoxQty & " as Qty " & Environment.NewLine
                strSql &= ", '" & strQuarantineDate & "' as Other1" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                '**********************
                'Print Box lablel
                '**********************
                Try
                    objTFMisc = New PSS.Data.Buisness.TracFone.clsMisc()
                    objTFMisc.PrintCrystalReportLabel(dt, strReportName, iCopyNumber, "2DBoxLabel")
                Catch ex As Exception
                    '2DBoxLabel is not available then try default printer
                    objTFMisc.PrintCrystalReportLabel(dt, strReportName, iCopyNumber, )
                End Try
                '**********************

                Return dt.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        ' Box Transfer
        Public Function getReceivedWHWIPBox(ByVal strBoxName As String) As DataTable
            Dim strSql As String = ""

            Try
                strBoxName = strBoxName.Replace("'", "''")
                strSql = "SELECT A.*, C.Model_desc,date_format(B.Receipt_Date,'%Y-%m-%d') as 'Receipt_Date',B.RMA as 'PO Number', if(A.Model_ID is Null or A.Model_ID =0, 'No','Yes') as 'HasModel'" & Environment.NewLine
                strSql &= " ,if(A.WHLocation is Null or trim(A.WHLocation) ='', 'No','Yes') as 'HasWHLocation'" & Environment.NewLine
                strSql &= " FROM edi.twarehousebox A" & Environment.NewLine
                strSql &= " INNER JOIN warehouse.warehouse_Receipt B ON A.WR_ID=B.WR_ID" & Environment.NewLine
                strSql &= " LEFT JOIN production.tmodel_Items C ON A.Model_ID=C.Model_ID" & Environment.NewLine
                strSql &= " WHERE A.BoxStage ='FK Received' AND WorkStation ='WH-WIP' AND A.Closed=1 AND A.BoxID='" & strBoxName & "';" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function UpdateWarehouseBoxLocation(ByVal iwb_ID As Integer, ByVal strWhLocation As String) As Integer
            Dim strSql As String = ""

            Try
                strSql = "UPDATE edi.twarehousebox SET WHLocation='" & strWhLocation.Replace("'", "''")
                strSql &= "' WHERE wb_id =" & iwb_ID & ";"

                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function CloseWorkorder(ByVal iWO_ID As Integer, ByVal iReceivedQty As Integer) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0

            Try
                strSql = "UPDATE production.tWorkorder SET WO_Closed=1, WO_RAQnty=" & iReceivedQty & " WHERE WO_ID=" & iWO_ID & ";"
                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        'Public Function getQuarantineTableDef() As DataTable
        '    Dim strSql As String = ""

        '    Try
        '        strSql = "SELECT 0 as 'Row',0 as 'PalletRow','' as 'IMEI','' as 'Pallet', '' as 'Item',  0 as 'WI_ID' limit 0;"
        '        Return Me._objDataProc.GetDataTable(strSql)

        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function

        Public Function getWhWIP_InPickBoxData(ByVal strBoxName As String) As DataTable
            Dim strSql As String = ""

            Try
                strBoxName = strBoxName.Replace("'", "''")
                strSql = "SELECT B.Serial as 'SN',A.BoxID as 'Pallet_Name',C.Model_Desc as 'Pallet_Item',0 as 'R1',0 as 'R2',B.SoDetailsID,B.PSSI_BoxLabel_Name" & Environment.NewLine
                strSql &= " ,D.Model_Desc as 'SN_Item',A.*,B.Model_ID as 'SN_Model_ID',B.WI_ID,R. Receipt_Date,E.OrderNo" & Environment.NewLine
                strSql &= " FROM edi.twarehousebox A" & Environment.NewLine
                strSql &= " INNER JOIN warehouse.warehouse_Items B ON A.WR_ID=B.WR_ID" & Environment.NewLine
                strSql &= " INNER JOIN warehouse.warehouse_Receipt R ON A.WR_ID=R.WR_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tmodel_Items C ON A.Model_ID=C.Model_ID AND C.Class_DCode_ID in (4231,6462)" & Environment.NewLine
                strSql &= " INNER JOIN production.tmodel_Items D ON B.Model_ID=D.Model_ID AND D.Class_DCode_ID in (4231,6462)" & Environment.NewLine
                strSql &= " LEFT JOIN edi.torder E ON A.Order_ID=E.Order_ID" & Environment.NewLine
                strSql &= " WHERE A.Closed=1 AND  LENGTH(TRIM(A.WHLocation))>0 AND  A.WorkStation IN ('WH-WIP','In-Pick') AND A.BoxID='" & strBoxName & "';" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class
End Namespace