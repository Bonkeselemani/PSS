Option Explicit On 

Imports System
Imports System.Data
Imports System.Text
Imports MySql.Data
Imports System.IO

Namespace Buisness.VV
    Public Class Vivint_DeviceRecv
        Private _objDataProc As DBQuery.DataProc
        Private _objUnderWarrantyNET1 As UnderWarrantyNET1.Vivint

#Region "Constructor/Destructor"

        '******************************************************************
        Public Sub New()
            Try
                Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Me._objUnderWarrantyNET1 = New UnderWarrantyNET1.Vivint()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub


        '******************************************************************
        Protected Overrides Sub Finalize()
            Me._objDataProc = Nothing
            Me._objUnderWarrantyNET1 = Nothing
            MyBase.Finalize()
        End Sub

        '******************************************************************
#End Region

        Public Function getOpenWODockBoxOrders(ByVal iCust_ID As Integer, ByVal iLoc_ID As Integer, ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT DIstinct A.WO_ID, A.WO_CustWO" & Environment.NewLine
                strSql &= " FROM production.tWorkOrder A" & Environment.NewLine
                strSql &= " INNER JOIN edi.TWarehouseBox B ON A.WO_ID=B.WO_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tLocation C ON A.Loc_ID=C.Loc_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tCustomer D ON C.Cust_ID=D.Cust_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tModel E ON B.Model_ID=E.Model_ID" & Environment.NewLine
                strSql &= " WHERE D.Cust_ID=" & iCust_ID & " AND A.Loc_ID=" & iLoc_ID & " AND A.WO_Closed=1 AND B.Closed=0;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow Then dt.LoadDataRow(New Object() {0, "--Select--"}, True)

                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getOpenWODockBoxOrderModels(ByVal iCust_ID As Integer, ByVal iLoc_ID As Integer, ByVal iWO_ID As Integer, ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT B.Model_ID, E.Model_Desc,B.WB_ID" & Environment.NewLine
                strSql &= " FROM production.tWorkOrder A" & Environment.NewLine
                strSql &= " INNER JOIN edi.TWarehouseBox B ON A.WO_ID=B.WO_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tLocation C ON A.Loc_ID=C.Loc_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tCustomer D ON C.Cust_ID=D.Cust_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tModel E ON B.Model_ID=E.Model_ID" & Environment.NewLine
                strSql &= " WHERE D.Cust_ID=" & iCust_ID & " AND A.Loc_ID=" & iLoc_ID & " AND A.WO_Closed=1 AND B.Closed=0 AND A.WO_ID =" & iWO_ID & ";" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow Then dt.LoadDataRow(New Object() {0, "--Select--", 0}, True)

                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getOpenWODockBoxDetailData(ByVal iCust_ID As Integer, ByVal iLoc_ID As Integer, ByVal iWB_ID As Integer) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT A.WO_ID, A.WO_CustWO, A.WO_Date, A.WO_Quantity, A.WO_RAQnty, A.WO_Discrepancy, A.Loc_ID, A.Prod_ID, A.Group_ID, A.Sku_ID, A.WO_Closed, A.OrderType_ID" & Environment.NewLine
                strSql &= " , B.wb_id, B.BoxID, B.FuncRep, B.WrtyExpedite, B.WarrantyFlag, B.Model_ID, B.Order_Qty, B.Recv_Qty, B.Diff_Qty, B.Order_ID, B.Closed, B.WHLocation, B.BoxStage" & Environment.NewLine
                strSql &= " , C.Cust_ID, D.Cust_Name1,E.Model_Desc" & Environment.NewLine
                strSql &= " FROM production.tWorkOrder A" & Environment.NewLine
                strSql &= " INNER JOIN edi.TWarehouseBox B ON A.WO_ID=B.WO_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tLocation C ON A.Loc_ID=C.Loc_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tCustomer D ON C.Cust_ID=D.Cust_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tModel E ON B.Model_ID=E.Model_ID" & Environment.NewLine
                strSql &= " WHERE D.Cust_ID=" & iCust_ID & " AND A.Loc_ID=" & iLoc_ID & " AND A.WO_Closed=1 AND B.Closed=0 AND B.wb_id = " & iWB_ID & ";" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getReceivedDevicesDef() As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT '' AS 'Device_SN', 0 AS 'Device_ID' limit 0;" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getReceivedUnshipped(ByVal iLoc_ID As Integer, ByVal strSN As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSN = strSN.Replace("'", "''")
                strSql = "select * from production.tdevice where Loc_ID=" & iLoc_ID & " AND Device_DateShip IS NULL AND Device_SN ='" & strSN & "';"
                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getSNPattern() As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Try
                strSql &= " SELECT SNP_id AS ID,Cust_Name1 AS Customer,Model_Desc,SN_Pattern,updateDateTime as Date " & Environment.NewLine
                strSql &= "from warehouse.SerialNumberPattern A" & Environment.NewLine
                strSql &= "INNER JOIN tCustomer B ON A.Cust_id=B.Cust_id" & Environment.NewLine
                strSql &= "INNER JOIN tmodel C ON A.Model_id=C.Model_id;" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        Public Function CreateSNPattern(ByVal iCust_Id As Integer, _
                                           ByVal iModel_id As Integer, _
                                           ByVal strSNPattern As String, _
                                           ByVal iUser_ID As Integer) As Integer
            Dim strSql As String
            strSql = "INSERT INTO warehouse.SerialNumberPattern ( " & Environment.NewLine
            strSql &= "Cust_id " & Environment.NewLine
            strSql &= ", Model_id " & Environment.NewLine
            strSql &= ", SN_Pattern " & Environment.NewLine
            strSql &= ", User_ID  " & Environment.NewLine
            strSql &= ", UpdateDateTime  " & Environment.NewLine
            strSql &= ") VALUES (  " & Environment.NewLine
            strSql &= " " & iCust_Id & "  " & Environment.NewLine
            strSql &= ", " & iModel_id & Environment.NewLine
            strSql &= ", '" & strSNPattern & Environment.NewLine
            strSql &= "', " & iUser_ID & " " & Environment.NewLine
            strSql &= ", CURRENT_TIMESTAMP() );" & Environment.NewLine
            Return Me._objDataProc.ExecuteNonQuery(strSql)

        End Function

        Public Function checkDevicesDuplicate(ByVal iLoc_ID As Integer, ByVal strSN As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Try
                strSN = strSN.Replace("'", "''")
                strSql = "  SELECT * FROM extendedwarranty where serialNo ='" & strSN & "'" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function checkDevicesRequested(ByVal iLoc_ID As Integer, ByVal strSN As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSN = strSN.Replace("'", "''")
                strSql = "  SELECT  SerialNo,pallett_name,C.pkslip_id,Po_requested FROM extendedwarranty A " & Environment.NewLine
                strSql &= " INNER JOIN production.tdevice B ON A.device_ID =B.device_ID " & Environment.NewLine
                strSql &= " Inner join production.tpallett  C ON C.Pallett_ID = B.Pallett_ID" & Environment.NewLine
                strSql &= " LEFT join production.tpackingslip D  ON D.pkslip_id = C.pkslip_id" & Environment.NewLine
                strSql &= " where   Device_SN ='" & strSN & "'  " & Environment.NewLine
                'strSql = "select * from production.tdevice where Loc_ID=" & iLoc_ID & " AND Device_DateShip IS NULL AND Device_SN ='" & strSN & "';"
                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetVivintModels(ByVal iCust_ID As Integer, ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable


            Try
                strSql = "Select * from tmodel where prodGrp_ID=204 and prod_ID=75  " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow Then dt.LoadDataRow(New Object() {0, "--Select--"}, True)
                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getTrayID(ByVal iUser_ID As Integer, ByVal strUser As String, ByVal iWO_ID As Integer, ByVal strMemo As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim iRet As Integer = 0

            Try
                strUser = strUser.Replace("'", "''") : strMemo = strMemo.Replace("'", "''")

                strSql = "INSERT INTO production.tTray (Tray_RecUserID, Tray_RecUser, WO_ID, Tray_Memo) VALUES (" & iUser_ID & ",'" & strUser & "'," & iWO_ID & ",'" & strMemo & "');"

                iRet = Me._objDataProc.ExecuteScalarForInsert(strSql, "production.tTray")

                Return iRet
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function ReceiveDeviceIntoSystem(ByVal iCust_ID As Integer, ByVal iLoc_ID As Integer, ByVal strPoNumber As String, ByVal iWO_ID As Integer, ByVal iModel_ID As Integer, ByVal strSN As String, _
                                                ByVal strManufDateCode As String, ByVal strDateTime As String, ByVal strWorkDate As String, ByVal strItemSku As String, _
                                                ByVal iShift_ID As Integer, ByVal iTray_ID As Integer, ByVal iWB_ID As Integer, _
                                                ByVal iWrtyFlag As Integer, ByVal strWrtyDesc As String, ByRef iDevice_ID As Integer, _
                                                ByVal strManufTime As String, ByVal strWrtyExpirationTime As String) As Boolean
            Dim strSql As String = ""
            Dim bRet As Boolean = False
            Dim strReceivedWorkStation = PSS.Data.Buisness.VV.Vivint.CoolPad_Received_WorkStation

            Dim i As Integer = 0

            Try
                strSN = strSN.Replace("'", "''") : strManufDateCode = strManufDateCode.Replace("'", "''")
                strItemSku = strItemSku.Replace("'", "''") : strWrtyDesc = strWrtyDesc.Replace("'", "''")
                strPoNumber = strPoNumber.Replace("'", "''") : strManufTime = strManufTime.Replace("'", "''")
                strWrtyExpirationTime = strWrtyExpirationTime.Replace("'", "''")

                strSql = "INSERT INTO production.tDevice (Device_SN,Device_DateRec,Device_Qty,Device_Cnt,Device_RecWorkDate,Loc_ID,WO_ID,Model_ID,Shift_ID_Rec,Tray_ID,Device_ManufWrty)" & _
                        " VALUES ('" & strSN & "','" & strDateTime & "',1,1,'" & strWorkDate & "'," & iLoc_ID & "," & iWO_ID & "," & iModel_ID & "," & iShift_ID & "," & iTray_ID & "," & iWrtyFlag & ");"
                i = Me._objDataProc.ExecuteNonQuery(strSql)
                strSql = "SELECT LAST_INSERT_ID();" 'get primary key after Insert
                iDevice_ID = Me._objDataProc.GetIntValue(strSql)

                If iDevice_ID > 0 Then
                    strSql = "INSERT INTO production.tCellOpt (Device_ID,CellOpt_DateCode, WorkStation, WorkStationEntryDt,CellOpt_IMEI)" & _
                             " VALUES (" & iDevice_ID & ",'" & strManufDateCode & "','" & strReceivedWorkStation & "','" & strDateTime & "','" & strSN & "');"
                    i += Me._objDataProc.ExecuteNonQuery(strSql)

                    'No need. This has been done in WO Duck screen. WO was created before receiving
                    'strSql = "UPDATE production.tWorkOrder SET WO_Closed =1, WO_RAQnty =1, Group_ID = " & PSS.Data.Buisness.CP.CoolPad.CoolPad_Group_ID & " WHERE WO_ID = " & iWO_ID & ";"
                    'i += Me._objDataProc.ExecuteNonQuery(strSql)

                    strSql = "INSERT INTO production.extendedwarranty (Cust_ID,Loc_ID,Device_ID,wb_id,WO_ID,SerialNo,item_Sku,ClaimNo,Warranty,Warranty_Desc,Manuf_Time,Wrty_Expiration_Time,LoadedDateTime)"
                    strSql &= " VALUES (" & iCust_ID & "," & iLoc_ID & "," & iDevice_ID & "," & iWB_ID & "," & iWO_ID & ",'" & strSN & "','" & strItemSku & "','" & strPoNumber & "'," & _
                              iWrtyFlag & ",'" & strWrtyDesc & "','" & strManufTime & "','" & strWrtyExpirationTime & "','" & strDateTime & "');"

                    i += Me._objDataProc.ExecuteNonQuery(strSql)

                    bRet = True
                End If

                Return bRet

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function CloseReceivingBox(ByVal iWB_ID As Integer) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0

            Try
                strSql = "UPDATE edi.tWarehouseBox SET Closed =1 Where wb_id =" & iWB_ID
                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function IsModelDeviceAutomaticWrty(ByVal iModel_ID As Integer) As Boolean
            Dim strSql As String = ""
            Dim bRet As Boolean = False
            Dim dt As DataTable, row As DataRow
            Dim strModelIDs As String = ""
            Dim strS() As String
            Dim i As Integer = 0

            Try
                strSql = "SELECT ModelIDs FROM exceptioncriteria WHERE Description ='VIVINT_WO_NOWARRANTY' AND Active=1;" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                For Each row In dt.Rows 'one row if any
                    strModelIDs = Convert.ToString(row("ModelIDs"))
                    Exit For
                Next
                If strModelIDs.Trim.Length > 0 Then
                    strS = strModelIDs.Split(",")
                    For i = 0 To strS.Length - 1
                        If Convert.ToInt32(strS(i)) = iModel_ID Then
                            bRet = True
                            Exit For
                        End If
                    Next
                End If
                Return bRet
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getVivintChiconyWrtyData(ByVal strSN As String, ByVal dReceivingDate As Date) As DataTable

            Try
                Return Me._objUnderWarrantyNET1.getVivintChiconyWrty(strSN, dReceivingDate)

            Catch ex As Exception
                Throw ex
            End Try
        End Function



    End Class
End Namespace