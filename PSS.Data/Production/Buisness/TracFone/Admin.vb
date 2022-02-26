Option Explicit On 
Imports System.IO
Imports System.Windows.Forms
Imports System.Globalization

Namespace Buisness.TracFone

    Public Class Admin
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

#Region "Properties"

        Public Shared ReadOnly Property CUSTOMER_ID() As Integer
            Get
                Return 2258
            End Get
        End Property

        Public Shared ReadOnly Property LOC_ID() As Integer
            Get
                Return 2624
            End Get
        End Property

#End Region

        '*****************************************************************
        Public Function GetTFModel() As DataTable
            Dim strSql As String
            Dim dt As DataTable
            Try
                strSql = "SELECT a.Model_ID, Model_Desc" & Environment.NewLine
                strSql &= ", cust_MaterialCategory, cust_OutgoingDesc, cust_IncomingDesc, cust_OutgoingSku, cust_IncomingSku " & Environment.NewLine
                strSql &= "FROM tmodel a" & Environment.NewLine
                strSql &= "INNER JOIN tcustmodel_pssmodel_map b on a.model_id = b.model_id" & Environment.NewLine
                strSql &= "WHERE cust_id = 2258 order by cust_MaterialCategory, Model_Desc;"
                dt = Me._objDataProc.GetDataTable(strSql)
                dt.LoadDataRow(New Object() {"0", "--Select--"}, False)
                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************
        Public Function GetCelloptInfo(ByVal iDeviceID As Integer) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT * FROM tcellopt WHERE Device_ID = " & iDeviceID
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************
        Public Function GetAnyHighestLaborLvlBilledPart(ByVal iDeviceID As Integer, ByVal iModelID As Integer) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT tdevicebill.Billcode_ID, LaborLevel FROM tdevicebill " & Environment.NewLine
                strSql &= "INNER JOIN tpsmap ON tdevicebill.Billcode_ID = tpsmap.Billcode_ID AND Model_ID = " & iModelID & Environment.NewLine
                strSql &= "WHERE tdevicebill.Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "ORDER BY LaborLevel DESC LIMIT 1 "
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************
        Public Function GetEDIShipAddress() As DataSet
            Dim strSql As String = ""
            Dim ds As New DataSet()
            Dim dt As DataTable
            Dim i As Integer

            Try
                strSql = "SELECT distinct 0 as ID, name, IDCodeQuantifier, IDCode " & Environment.NewLine
                strSql &= "FROM edi.taddress where EntityIdentifiercode = 'SF' and  name <> 'TRACFONE EXCHANGE'" & Environment.NewLine
                strSql &= "ORDER BY name "
                dt = Me._objDataProc.GetDataTable(strSql)
                dt.TableName = "SF"

                For i = 0 To dt.Rows.Count - 1
                    dt.Rows(i).BeginEdit()
                    dt.Rows(i)("ID") = i + 1
                    dt.Rows(i).EndEdit()
                Next i
                dt.LoadDataRow(New Object() {"0", "--Select--"}, False)
                dt.AcceptChanges() : ds.Tables.Add(dt)

                dt = Nothing
                strSql = "SELECT distinct 0 as ID, name, IDCodeQuantifier, IDCode, Address1, City, State, Zip" & Environment.NewLine
                strSql &= "FROM edi.taddress where EntityIdentifiercode = 'ST' and  City is not null and State is not null and Zip is not null" & Environment.NewLine
                strSql &= "ORDER BY name "
                dt = Me._objDataProc.GetDataTable(strSql)
                dt.TableName = "ST"

                For i = 0 To dt.Rows.Count - 1
                    dt.Rows(i).BeginEdit()
                    dt.Rows(i)("ID") = i + 1
                    dt.Rows(i).EndEdit()
                Next i
                dt.LoadDataRow(New Object() {"0", "--Select--"}, False)
                dt.AcceptChanges() : ds.Tables.Add(dt)

                Return ds
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
                If Not IsNothing(ds) Then
                    ds.Dispose() : ds = Nothing
                End If
            End Try
        End Function

        '*****************************************************************
        Public Function GetGetModelIDByCustOutBoundSku(ByVal strTracfoneOutboundSku As String) As Integer
            Dim strSql As String = ""

            Try
                strSql = "SELECT Model_ID FROM tcustmodel_pssmodel_map " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tcustmodel_pssmodel_map.model_id = tmodel.Model_ID AND tcustmodel_pssmodel_map.cust_model_number = tmodel.Model_Desc " & Environment.NewLine
                strSql &= "WHERE cust_OutgoingSku = '" & strTracfoneOutboundSku & "' "
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************
        Public Function LoadWipOrders(ByVal dtData As DataTable) As Integer
            Dim strSql As String = ""
            Dim R1 As DataRow
            Dim dt As DataTable
            Dim booInsert As Boolean = True
            Dim i As Integer = 0

            Try
                For Each R1 In dtData.Rows
                    booInsert = True

                    strSql = "SELECT * FROM edi.twipwo WHERE WIPEntity = '" & R1("WIPEntity") & "'"
                    Generic.DisposeDT(dt)
                    dt = Me._objDataProc.GetDataTable(strSql)
                    If dt.Rows.Count = 0 Then
                        strSql = "SELECT * FROM edi.twipwo WHERE Model_ID = " & R1("Model_ID") & " AND ScheduledStartDate >= '" & R1("ScheduledStartDate") & "' AND ScheduledCompletionDate <= '" & R1("ScheduledCompletionDate") & "'"
                        Generic.DisposeDT(dt)
                        dt = Me._objDataProc.GetDataTable(strSql)
                        If dt.Rows.Count > 0 Then booInsert = False
                    Else
                        booInsert = False
                    End If

                    If booInsert = True Then
                        i += InsertWipOrder(CInt(R1("TransactionQty")), R1("CustItemNo").ToString.Trim.ToUpper, R1("WIPEntity").ToString.Trim.ToUpper, R1("ScheduledStartDate"), R1("ScheduledCompletionDate"), CInt(R1("Model_ID")))
                        'strSql = "INSERT INTO twipwo ( WipRefID, WipRefID_Desc, MsgRecordType, OrganizationName, TransactionQty " & Environment.NewLine
                        'strSql &= ", CustItemNo, WIPEntity, StatusType, ScheduledStartDate, ScheduledCompletionDate " & Environment.NewLine
                        'strSql &= ", GLNValue, Msg_ID, Model_ID  " & Environment.NewLine
                        'strSql &= ") values (  " & Environment.NewLine
                        'strSql &= "  '" & R1("WipRefID") & "', '" & R1("WipRefID_Desc") & "', '" & R1("MsgRecordType") & "', '" & R1("OrganizationName") & "', " & R1("TransactionQty") & " " & Environment.NewLine
                        'strSql &= ", '" & R1("CustItemNo") & "', '" & R1("WIPEntity") & "', " & R1("StatusType") & ", '" & R1("ScheduledStartDate") & "', '" & R1("ScheduledCompletionDate") & "' " & Environment.NewLine
                        'strSql &= ", '" & R1("GLNValue") & "', " & R1("Msg_ID") & ", " & R1("Model_ID") & "  " & Environment.NewLine
                        'strSql &= ");"

                        'i += Me._objDataProc.ExecuteNonQuery(strSql)
                    End If
                Next R1

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************
        Public Function InsertWipOrder(ByVal iTransactionQty As Integer, ByVal strCustItemNo As String, ByVal strWIPEntity As String _
                                     , ByVal strScheduledStartDate As String, ByVal strScheduledCompletionDate As String, ByVal iModelID As Integer) As Integer
            Const strWipRefID As String = "R7B"
            Const strWipRefID_Desc As String = "WO REQUEST"
            Const strMsgRecordType As String = "R7B"
            Const strOrganizationName As String = "PSSI_IO"
            Const iStatusType As Integer = 3
            Const strGLNValue As String = "1100001010554"
            Const iMsg_ID As Integer = 0
            Dim strSql As String = ""

            Try
                strSql = "INSERT INTO edi.twipwo ( WipRefID, WipRefID_Desc, MsgRecordType, OrganizationName, TransactionQty " & Environment.NewLine
                strSql &= ", CustItemNo, WIPEntity, StatusType, ScheduledStartDate, ScheduledCompletionDate " & Environment.NewLine
                strSql &= ", GLNValue, Msg_ID, Model_ID  " & Environment.NewLine
                strSql &= ") values (  " & Environment.NewLine
                strSql &= "  '" & strWipRefID & "', '" & strWipRefID_Desc & "', '" & strMsgRecordType & "', '" & strOrganizationName & "', " & iTransactionQty & " " & Environment.NewLine
                strSql &= ", '" & strCustItemNo & "', '" & strWIPEntity & "', " & iStatusType & ", '" & strScheduledStartDate & "', '" & strScheduledCompletionDate & "' " & Environment.NewLine
                strSql &= ", '" & strGLNValue & "', " & iMsg_ID & ", " & iModelID & "  " & Environment.NewLine
                strSql &= ");"

                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************
        Public Function UpdateWipOrder(ByVal iWIPWO_ID As Integer, ByVal iTransactionQty As Integer, ByVal strCustItemNo As String, _
                                       ByVal strWIPEntity As String, ByVal iModelID As Integer) As Integer
            Dim strSql As String = ""
            Try
                strCustItemNo = strCustItemNo.Replace("'", "''") : strWIPEntity = strWIPEntity.Replace("'", "''")
                strSql = "UPDATE  edi.twipwo SET TransactionQty =" & iTransactionQty & ",WIPEntity='" & strWIPEntity & "',CustItemNo='" & strCustItemNo & "',Model_ID=" & iModelID
                strSql &= " WHERE WIPWO_ID = " & iWIPWO_ID & ";" & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '************************************************************************************************************************
        Public Function GetOpen940() As DataTable
            Dim strSql, strToday As String
            Dim dt, dt1 As DataTable
            Dim R1, R2() As DataRow
            Dim i As Integer = 0

            Try
                strToday = Generic.MySQLServerDateTime()
                strSql = "SELECT A.Order_ID, A.OrderNo, A.IL_No, B.VN_ItemNo, A.OrderQty, A.RequestDate, A.PODate, A.Order_Type as 'Order Type'" & Environment.NewLine
                strSql &= ", if (A.OrderCancel = 1 , 'Yes', 'No') as 'Canceled?', A.OrderCancel_Date as 'Cancel Date'" & Environment.NewLine
                strSql &= "FROM edi.torder A " & Environment.NewLine
                strSql &= "INNER JOIN edi.torderdetail B ON A.Order_ID = B.Order_ID" & Environment.NewLine
                strSql &= "WHERE A.WO_ClosedDate is null AND OrderCancel = 0 " & Environment.NewLine
                strSql &= "UNION " & Environment.NewLine
                strSql &= "SELECT A.Order_ID, A.OrderNo, A.IL_No, B.VN_ItemNo, A.OrderQty, A.RequestDate, A.PODate, A.Order_Type as 'Order Type'" & Environment.NewLine
                strSql &= ", if (A.OrderCancel = 1 , 'Yes', 'No') as 'Canceled?', A.OrderCancel_Date as 'Cancel Date'" & Environment.NewLine
                strSql &= "FROM edi.torder A " & Environment.NewLine
                strSql &= "INNER JOIN edi.torderdetail B ON A.Order_ID = B.Order_ID" & Environment.NewLine
                strSql &= "WHERE A.WO_ClosedDate is null AND OrderCancel = 1 " & Environment.NewLine
                strSql &= "AND A.OrderCancel_Date > '" & DateAdd(DateInterval.Day, -7, CDate(strToday)).ToString("yyyy-MM-dd") & "'" & Environment.NewLine
                strSql &= "ORDER BY Order_ID"
                dt = Me._objDataProc.GetDataTable(strSql)

                strSql = "SELECT A.Order_ID, count(Device_ID) as Qty " & Environment.NewLine
                strSql &= "FROM edi.torder A " & Environment.NewLine
                strSql &= "INNER JOIN edi.titem B ON A.Order_ID = B.Order_ID" & Environment.NewLine
                strSql &= "WHERE A.WO_ClosedDate is null AND OrderCancel = 0 " & Environment.NewLine
                strSql &= "Group By A.Order_ID Having Qty > 1 " & Environment.NewLine
                strSql &= "UNION " & Environment.NewLine
                strSql &= "SELECT A.Order_ID, count(Device_ID) as Qty " & Environment.NewLine
                strSql &= "FROM edi.torder A " & Environment.NewLine
                strSql &= "INNER JOIN edi.titem B ON A.Order_ID = B.Order_ID" & Environment.NewLine
                strSql &= "WHERE A.WO_ClosedDate is null  AND OrderCancel = 1 " & Environment.NewLine
                strSql &= "AND A.OrderCancel_Date > '" & DateAdd(DateInterval.Day, -7, CDate(strToday)).ToString("yyyy-MM-dd") & "'" & Environment.NewLine
                strSql &= "Group By A.Order_ID Having Qty > 1 " & Environment.NewLine
                dt1 = Me._objDataProc.GetDataTable(strSql)

                For Each R1 In dt1.Rows
                    If dt.Select("Order_ID = " & R1("Order_ID")).Length > 0 Then
                        R2 = dt.Select("Order_ID = " & R1("Order_ID"))
                        For i = 0 To R2.Length - 1
                            dt.Rows.Remove(R2(i)) : dt.AcceptChanges()
                        Next i
                        R2 = Nothing
                    End If
                Next R1

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt) : Generic.DisposeDT(dt1)
                R1 = Nothing : R2 = Nothing
            End Try
        End Function

        '************************************************************************************************************************
        Public Function SetOrderCancelVal(ByVal iOrderCancelVal As Integer, ByVal strOrderIDs As String) As Integer
            Dim strSql As String

            Try
                strSql = "UPDATE edi.torder " & Environment.NewLine
                strSql &= "SET OrderCancel = " & iOrderCancelVal & ", OrderCancel_Date = now()" & Environment.NewLine
                strSql &= "WHERE Order_ID IN ( " & strOrderIDs & ") AND WO_ClosedDate is null and OrderCancel <> " & iOrderCancelVal & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '************************************************************************************************************************
        Public Function GetWHReceivedCount(ByVal strOrderIDs As String) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT Orderno, count(Device_ID) as cnt FROM edi.titem " & Environment.NewLine
                strSql &= "WHERE Order_ID in ( " & strOrderIDs & ")" & Environment.NewLine
                strSql &= "GROUP BY Order_ID Having cnt > 0" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '************************************************************************************************************************
        Public Function GetAvailableWipOrders() As DataTable
            Dim strSql As String

            Try
                strSql = " SELECT CustItemNo as 'Model', WIPEntity as 'Wip Order', TransactionQty,'' as 'Edit'" & Environment.NewLine
                strSql &= ", ScheduledStartDate, ScheduledCompletionDate,Model_ID,WIPWO_ID" & Environment.NewLine
                strSql &= "FROM edi.twipwo WHERE ScheduledCompletionDate >= DATE_FORMAT(now(), '%Y-%m-%d')"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '************************************************************************************************************************
        Public Function GetWipOrderDataByWIPWOID(ByVal iWIPWO_ID As Integer, ByVal iTransactionQty As Integer, _
                                                 ByVal iModel_ID As Integer, ByVal strWIPEntity As String, ByVal strCustItemNo As String) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT WIPWO_ID,TransactionQty,WIPEntity,CustItemNo,Model_ID" & Environment.NewLine
                strSql &= " ,IF(TransactionQty=" & iTransactionQty & ",'Yes','No') AS 'IsCorrectQty'" & Environment.NewLine
                strSql &= " ,IF(WIPEntity='" & strWIPEntity & "','Yes','No') AS 'IsCorrectWIPEntity'" & Environment.NewLine
                strSql &= " ,IF(CustItemNo='" & strCustItemNo & "','Yes','No') AS 'IsCorrectModel'" & Environment.NewLine
                strSql &= " ,IF(Model_ID=" & iModel_ID & ",'Yes','No') AS 'IsCorrectModelID'" & Environment.NewLine
                strSql &= " FROM edi.twipwo" & Environment.NewLine
                strSql &= " WHERE WIPWO_ID = " & iWIPWO_ID & ";" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '************************************************************************************************************************
        Public Function GetThisMonthWipEntityByModel(ByVal iModelID As Integer, ByVal strStartDateOfMonth As String, ByVal strEndDateOfMonth As String) As DataTable
            Dim strSql As String

            Try
                strSql = " SELECT CustItemNo as 'Model', WIPEntity as 'Wip Order', TransactionQty" & Environment.NewLine
                strSql &= ", ScheduledStartDate, ScheduledCompletionDate" & Environment.NewLine
                strSql &= "FROM edi.twipwo" & Environment.NewLine
                strSql &= "WHERE Model_ID = " & iModelID & " AND ScheduledStartDate >= '" & strStartDateOfMonth & "' AND ScheduledCompletionDate <= '" & strEndDateOfMonth & "'"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '************************************************************************************************************************
        Public Function GetWipEntityInfo(ByVal strWipEntity As String) As DataTable
            Dim strSql As String

            Try
                strSql = " SELECT CustItemNo as 'Model', WIPEntity as 'Wip Order', TransactionQty" & Environment.NewLine
                strSql &= ", ScheduledStartDate, ScheduledCompletionDate" & Environment.NewLine
                strSql &= "FROM edi.twipwo" & Environment.NewLine
                strSql &= "WHERE WIPEntity = '" & strWipEntity & "'"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '************************************************************************************************************************
        Public Function GetTracfoneOutBoundModelList(ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = " SELECT tmodel.Model_ID, cust_OutgoingSku as 'Model', Model_Desc " & Environment.NewLine
                strSql &= "FROM tmodel inner join tcustmodel_pssmodel_map on tmodel.Model_ID = tcustmodel_pssmodel_map.model_id" & Environment.NewLine
                strSql &= "WHERE cust_id  = 2258 AND cust_MaterialCategory = 'PHONE' AND Model_Desc not like '%_FUN'" & Environment.NewLine
                strSql &= "ORDER BY Model"
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow = True Then dt.LoadDataRow(New Object() {"0", "--Select--"}, False)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '************************************************************************************************************************
        Public Function LoadRURFalloutCountReport(ByVal strStartWeek As String, ByVal strEndWeek As String)
            Dim dtRURCodes, dtRecQtyByModels, dtRURDevices As DataTable
            'Excel Related variables
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet
            Dim R1, drArr() As DataRow
            Dim i, j, iStartLine As Integer
            Dim objArrData(0, 0) As Object
            Dim booCompleted As Boolean = False

            Try
                dtRURCodes = GetTracFoneRURCodes()
                '******************************************************************
                'Instantiate the excel related objects
                objExcel = New Excel.Application()      'Starts the Excel Session
                objBook = objExcel.Workbooks.Add                    'Add a Workbook
                objExcel.Application.Visible = True               'Make this false while going live
                objExcel.Application.DisplayAlerts = False
                objSheet = objBook.Worksheets.Item(1)
                'objSheet.Activate()
                '******************************************************************

                i = 0 : iStartLine = 1
                j = 0 : i = 0
                dtRecQtyByModels = Me.GetRecQtyByDateRange(2946, strStartWeek, strEndWeek)
                dtRURDevices = Me.GetRURCountByRecDateRange(2946, strStartWeek, strEndWeek)

                ReDim objArrData(dtRecQtyByModels.Rows.Count + 2, dtRURCodes.Rows.Count + 3)

                objArrData(i, j) = "Model " & strStartWeek & "" & strEndWeek
                objArrData(i, j + 1) = "Received"
                If dtRecQtyByModels.Rows.Count > 0 Then objArrData(dtRecQtyByModels.Rows.Count + 1, j + 1) = "=SUM(R[-" & (dtRecQtyByModels.Rows.Count).ToString & "]C:R[-1]C)" Else objArrData(dtRecQtyByModels.Rows.Count + 1, j + 1) = 0

                objArrData(i + dtRecQtyByModels.Rows.Count + 1, j) = "Total"
                For j = 0 To dtRURCodes.Rows.Count - 1
                    objArrData(i, j + 2) = dtRURCodes.Rows(j)("Billcode_Desc")
                    If dtRecQtyByModels.Rows.Count > 0 Then objArrData(dtRecQtyByModels.Rows.Count + 1, j + 2) = "=SUM(R[-" & (dtRecQtyByModels.Rows.Count).ToString & "]C:R[-1]C)" Else objArrData(dtRecQtyByModels.Rows.Count + 1, j + 2) = 0
                Next j
                objArrData(i, j + 2) = "Total"
                i += 1

                For Each R1 In dtRecQtyByModels.Rows
                    j = 0
                    objArrData(i, j) = R1("Model_Desc")
                    objArrData(i, j + 1) = R1("Qty")
                    For j = 0 To dtRURCodes.Rows.Count - 1
                        If Not IsDBNull(dtRURDevices.Compute("Sum(Qty)", "Model_ID = " & R1("Model_ID") & " AND Billcode_ID = " & dtRURCodes.Rows(j)("Billcode_ID"))) Then
                            objArrData(i, j + 2) = dtRURDevices.Compute("Sum(Qty)", "Model_ID = " & R1("Model_ID") & " AND Billcode_ID = " & dtRURCodes.Rows(j)("Billcode_ID"))
                        Else
                            objArrData(i, j + 2) = 0
                        End If
                    Next j

                    objArrData(i, j + 2) = "=SUM(RC[-" & (dtRURCodes.Rows.Count).ToString & "]:RC[-1])"
                    i += 1
                Next R1

                objSheet.Range("A" & iStartLine, Generic.CalExcelColLetter(dtRURCodes.Rows.Count + 3) & (iStartLine + dtRecQtyByModels.Rows.Count + 1)).Value = objArrData

                'strStartWeek = DateAdd(DateInterval.Day, 1, CDate(strEndWeek)).ToString("yyyy-MM-dd")
                'strEndWeek = DateAdd(DateInterval.Day, 6, CDate(strStartWeek)).ToString("yyyy-MM-dd")
                iStartLine = i + 3

                ''*****************************************
                ''Set horizontal alignment for the header
                ''*****************************************
                'objSheet.Range("A1:" & Generic.CalExcelColLetter(dt1.Columns.Count - 2) & "1").Select()
                'With objExcel.Selection
                '    .WrapText = True
                '    .HorizontalAlignment = Excel.Constants.xlCenter
                '    .VerticalAlignment = Excel.Constants.xlTop
                '    .font.bold = True
                '    .Font.ColorIndex = 5
                'End With

                'With objExcel.Selection.Interior
                '    .ColorIndex = 37
                '    .Pattern = Excel.Constants.xlSolid
                'End With

                ''Set Font
                'With objExcel.Selection
                '    .Font.Name = "Microsoft Sans Serif"
                'End With

                '*****************************************
                'Set column widths
                '*****************************************
                objSheet.Cells.EntireColumn.AutoFit()
                objSheet.Cells.EntireRow.AutoFit()

                ''*****************************************
                ''Set horizontal alignment for the header
                ''*****************************************
                'objSheet.Range("A1:" & Generic.CalExcelColLetter(dt2.Columns.Count) & "1").Select()
                'With objExcel.Selection
                '    .WrapText = True
                '    .HorizontalAlignment = Excel.Constants.xlCenter
                '    .VerticalAlignment = Excel.Constants.xlTop
                '    .font.bold = True
                '    .Font.ColorIndex = 5
                'End With

                'With objExcel.Selection.Interior
                '    .ColorIndex = 37
                '    .Pattern = Excel.Constants.xlSolid
                'End With

                ''Set Font
                'With objExcel.Selection
                '    .Font.Name = "Microsoft Sans Serif"
                'End With

                'objSheet.Range("A" & (dt2.Rows.Count + 2).ToString() & ":" & Generic.CalExcelColLetter(dt2.Columns.Count) & (dt2.Rows.Count + 2)).Select()
                'With objExcel.Selection
                '    .HorizontalAlignment = Excel.Constants.xlRight
                '    .font.bold = True
                'End With

                'objExcel.ActiveWindow.FreezePanes = False
                'objExcel.Range("A2:" & Generic.CalExcelColLetter(dt2.Columns.Count) & "2").Select()
                'objExcel.ActiveWindow.FreezePanes = True

                ''*****************************************
                ''Set column widths
                ''*****************************************
                'objSheet.Cells.EntireColumn.AutoFit()
                'objSheet.Cells.EntireRow.AutoFit()

                ''***********************************
                ''Set zoom
                ''***********************************
                'objBook.Sheets("Sheet1").Delete() : objBook.Sheets("Sheet2").Delete() : objBook.Sheets("Sheet3").Delete()
                'objExcel.ActiveWindow.Zoom = 70

                MsgBox("Completed.")

            Catch ex As Exception
                Throw New Exception("TracFone.Admin.LoadWIPSummary(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                Generic.DisposeDT(dtRURCodes) : Generic.DisposeDT(dtRecQtyByModels) : Generic.DisposeDT(dtRURDevices)
                objArrData = Nothing
                R1 = Nothing
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '************************************************************************************************************************
        Public Function GetTracFoneRURCodes() As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT Distinct lbillcodes.Billcode_ID, lbillcodes.Billcode_Desc " & Environment.NewLine
                strSql &= "FROM tpsmap inner join tcustmodel_pssmodel_map on tpsmap.Model_ID = tcustmodel_pssmodel_map.model_id and Cust_ID = 2258 " & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON tpsmap.Billcode_ID = lbillcodes.Billcode_ID AND BillType_ID = 1 AND BillCode_Rule = 1" & Environment.NewLine
                strSql &= "WHERE cust_MaterialCategory = 'PHONE'" & Environment.NewLine
                strSql &= "ORDER BY Billcode_Desc"
                Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '************************************************************************************************************************
        Public Function GetRecQtyByDateRange(ByVal iLocID As Integer, ByVal strStartDate As String, ByVal strEndDate As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT Model_Desc, Count(*) as Qty " & Environment.NewLine
                strSql &= "FROM tdevice INNER JOIN tmodel on tdevice.Model_ID = tmodel.Model_ID" & Environment.NewLine
                strSql &= "WHERE Loc_ID = " & iLocID & Environment.NewLine
                strSql &= "AND Device_DateRec BETWEEN '" & strStartDate & " 00:00:00' AND '" & strEndDate & " 23:59:59'" & Environment.NewLine
                strSql &= "GROUP BY tdevice.Model_ID " & Environment.NewLine
                strSql &= "ORDER BY Model_Desc"
                Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '************************************************************************************************************************
        Public Function GetRURCountByRecDateRange(ByVal iLocID As Integer, ByVal strStartDate As String, ByVal strEndDate As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT tdevice.Model_ID, lbillcodes.Billcode_ID, Count(*) as Qty " & Environment.NewLine
                strSql &= "FROM tdevice INNER JOIN tmodel on tdevice.Model_ID = tmodel.Model_ID AND Loc_ID = " & iLocID & " AND Device_DateRec BETWEEN '" & strStartDate & " 00:00:00' AND '" & strEndDate & " 23:59:59'" & Environment.NewLine
                strSql &= "INNER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID" & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON tdevicebill.BillCode_ID = lbillcodes.BillCode_ID AND BillType_ID = 1 AND lbillcodes.BillCode_Rule = 1" & Environment.NewLine
                strSql &= "WHERE Loc_ID = " & iLocID & Environment.NewLine
                strSql &= "AND Device_DateRec BETWEEN '" & strStartDate & " 00:00:00' AND '" & strEndDate & " 23:59:59'" & Environment.NewLine
                strSql &= "GROUP BY tdevice.Model_ID " & Environment.NewLine
                Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '************************************************************************************************************************
        Public Function GetDeviceIDFromIMEI(ByVal strIMEI As String) As Integer
            Dim strSQL As String

            Try
                strSQL = "SELECT device_id" & Environment.NewLine
                strSQL &= "FROM production.tdevice" & Environment.NewLine
                strSQL &= String.Format("WHERE device_sn = '{0}'", strIMEI)

                Return Me._objDataProc.GetIntValue(strSQL)
            Catch ex As Exception
                Throw ex
            End Try

        End Function

        Public Function GetModelIDAndManufIDFromIMEI(ByVal strIMEI As String) As DataRow
            Dim strSQL As String

            Try
                strSQL = "SELECT A.model_id, B.manuf_id" & Environment.NewLine
                strSQL &= "FROM production.tdevice A" & Environment.NewLine
                strSQL &= "INNER JOIN production.tmodel B ON A.model_id = B.model_id" & Environment.NewLine
                strSQL &= String.Format("WHERE A.device_sn = '{0}'", strIMEI)

                Return Me._objDataProc.GetDataRow(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetBoxTypeFromDeviceID(ByVal iDeviceID As Integer) As Integer
            Dim strSQL As String

            Try
                strSQL = "SELECT funcrep FROM edi.titem WHERE Device_ID = " & iDeviceID
                Return Me._objDataProc.GetIntValue(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetCurrentWarrantyData(ByVal iDeviceID As Integer) As DataRow
            Dim strSQL As String

            Try
                strSQL = "SELECT DATE_FORMAT(LastDateInWrty, '%Y-%M-%d') AS LastDateInWrty, Manuf_Date" & Environment.NewLine
                strSQL &= "FROM edi.titem" & Environment.NewLine
                strSQL &= String.Format("WHERE device_id = {0}", iDeviceID)

                Return Me._objDataProc.GetDataRow(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Sub UpdateTItemWrtyData(ByVal strIMEI As String, ByVal strLastDateInWrty As String, ByVal strWrtyDateCode As String)
            Dim strSQL As String

            Try
                strSQL = "UPDATE edi.titem" & Environment.NewLine
                strSQL &= String.Format("SET LastDateInWrty = '{0}', Manuf_Date = '{1}'", strLastDateInWrty, strWrtyDateCode) & Environment.NewLine
                strSQL &= String.Format("WHERE sn = '{0}'", strIMEI)

                Me._objDataProc.ExecuteNonQuery(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Function GetOrderID(ByVal strIMEI As String) As Integer
            Dim strSQL As String

            Try
                strSQL = "SELECT order_id" & Environment.NewLine
                strSQL &= "FROM edi.titem" & Environment.NewLine
                strSQL &= String.Format("WHERE sn = '{0}'", strIMEI)

                Return Me._objDataProc.GetIntValue(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetBoxID(ByVal iOrderID As Integer, ByVal iManufWrty As Integer) As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT wb_id, BoxID" & Environment.NewLine
                strSQL &= "FROM edi.twarehousebox" & Environment.NewLine
                strSQL &= String.Format("WHERE order_id = {0} AND WarrantyFlag = {1} AND closed = 0", iOrderID, iManufWrty) & Environment.NewLine
                strSQL &= "LIMIT 1"

                Return Me._objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Sub UpdateBoxIDWBID(ByVal strIMEI As String, ByVal strNewBoxID As String, ByVal iWBID As Integer)
            Dim strSQL As String

            Try
                strSQL = "UPDATE edi.titem" & Environment.NewLine
                strSQL &= String.Format("SET boxid = '{0}', wb_id = {1}", strNewBoxID, iWBID) & Environment.NewLine
                strSQL &= String.Format("WHERE sn = '{0}'", strIMEI)

                Me._objDataProc.ExecuteNonQuery(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub UpdateWrtyStatus(ByVal iDeviceID As Integer, ByVal iManufWrty As Integer)
            Dim strSQL As String

            Try
                strSQL = "UPDATE production.tdevice" & Environment.NewLine
                strSQL &= String.Format("SET device_manufwrty = {0}", iManufWrty) & Environment.NewLine
                strSQL &= String.Format("WHERE device_id = {0}", iDeviceID)

                Me._objDataProc.ExecuteNonQuery(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub UpdateDateCode(ByVal iDeviceID As Integer, ByVal strWrtyDateCode As Integer)
            Dim strSQL As String

            Try
                strSQL = "UPDATE production.tcellopt" & Environment.NewLine
                strSQL &= String.Format("SET cellopt_datecode = '{0}'", strWrtyDateCode) & Environment.NewLine
                strSQL &= String.Format("WHERE device_id = {0}", iDeviceID)

                Me._objDataProc.ExecuteNonQuery(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Function BoxExists(ByVal iPallettID As Integer) As Boolean
            Dim strSQL As String

            Try
                strSQL = "SELECT COUNT(*)" & Environment.NewLine
                strSQL &= "FROM production.tpallett" & Environment.NewLine
                strSQL &= String.Format("WHERE pallett_id = {0}", iPallettID)

                Return Me._objDataProc.GetIntValue(strSQL) > 0
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function BoxHasShipped(ByVal iPallettID As Integer) As Boolean
            Dim strSQL As String

            Try
                strSQL = "SELECT IF(pallett_shipdate IS NULL, 0, 1)" & Environment.NewLine
                strSQL &= "FROM production.tpallett" & Environment.NewLine
                strSQL &= String.Format("WHERE pallett_id = {0}", iPallettID)

                Return Me._objDataProc.GetIntValue(strSQL) = 1
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function BoxHasPackingSlip(ByVal iPallettID As Integer) As Boolean
            Dim strSQL As String

            Try
                strSQL = "SELECT IF(pkslip_id IS NULL OR pkslip_id = 0, 0, 1)" & Environment.NewLine
                strSQL &= "FROM production.tpallett" & Environment.NewLine
                strSQL &= String.Format("WHERE pallett_id = {0}", iPallettID)

                Return Me._objDataProc.GetIntValue(strSQL) = 1
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function BoxHasWorkOrder(ByVal iPallettID As Integer) As Boolean
            Dim strSQL As String

            Try
                strSQL = "SELECT IF(wo_id IS NULL OR wo_id = 0, 0, 1)" & Environment.NewLine
                strSQL &= "FROM production.tpallett" & Environment.NewLine
                strSQL &= String.Format("WHERE pallett_id = {0}", iPallettID)

                Return Me._objDataProc.GetIntValue(strSQL) = 1
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetMaxBoxMoveCount(ByVal iPallettID As Integer) As Integer
            Dim strSQL As String

            Try
                strSQL = "SELECT pallett_qty" & Environment.NewLine
                strSQL &= "FROM production.tpallett" & Environment.NewLine
                strSQL &= String.Format("WHERE pallett_id = {0}", iPallettID)

                Return Me._objDataProc.GetIntValue(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetBoxID(ByVal strBoxName As String, Optional ByVal iCust_ID As Integer = 0) As Integer
            Dim strSQL As String

            Try
                strSQL = "SELECT pallett_id" & Environment.NewLine
                strSQL &= "FROM production.tpallett" & Environment.NewLine
                strSQL &= String.Format("WHERE pallett_name = '{0}'", strBoxName)
                If iCust_ID > 0 Then strSQL &= " And Cust_ID=" & iCust_ID

                Return Me._objDataProc.GetIntValue(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetMaxBoxName(ByVal strTemplate As String) As String
            Dim strSQL As String

            Try
                strSQL = "SELECT MAX(pallett_name)" & Environment.NewLine
                strSQL &= "FROM production.tpallett" & Environment.NewLine
                strSQL &= String.Format("WHERE pallett_name LIKE '{0}%'", strTemplate)

                Return Me._objDataProc.GetSingletonString(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function InsertNewBox(ByVal iOldPallettID As Integer, ByVal strNewBoxName As String, ByVal iQty As Integer) As Integer
            Dim strSQL As String

            Try
                strSQL = "INSERT INTO production.tpallett (pallett_name, pallett_qty, pallett_shipdate, pallett_bulkshipped, pallett_readytoshipflg, pallet_shiptype, pallet_skulen, pallet_invalid, pallet_invalidusrid, awpflag, wo_id, model_id, cust_id, pallet_timestamp, dobflg, pallett_senddt, pallett_maxqty, pallet_weight, unitmeasurementcode, order_seqno, pallet_seqno, pkslip_id, loc_id, specialinvproject, pallettype_id, aql_qcresult_id)" & Environment.NewLine
                strSQL &= String.Format("SELECT '{0}', {1}, pallett_shipdate, pallett_bulkshipped, pallett_readytoshipflg, pallet_shiptype, pallet_skulen, pallet_invalid, pallet_invalidusrid, awpflag, wo_id, model_id, cust_id, pallet_timestamp, dobflg, pallett_senddt, pallett_maxqty, pallet_weight, unitmeasurementcode, order_seqno, pallet_seqno, pkslip_id, loc_id, specialinvproject, pallettype_id, aql_qcresult_id", strNewBoxName, iQty) & Environment.NewLine
                strSQL &= "FROM production.tpallett" & Environment.NewLine
                strSQL &= String.Format("WHERE pallett_id = {0}", iOldPallettID)

                Return Me._objDataProc.ExecuteNonQuery(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetDevicesInBox(ByVal iPallettID As Integer) As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT A.device_id, A.device_sn AS 'IMEI'" & Environment.NewLine
                strSQL &= "FROM production.tdevice A" & Environment.NewLine
                strSQL &= "INNER JOIN production.tpallett B ON A.pallett_id = B.pallett_id" & Environment.NewLine
                strSQL &= String.Format("WHERE B.pallett_id = {0}", iPallettID) & Environment.NewLine
                strSQL &= "ORDER BY IMEI"

                Return Me._objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Sub UpdateDeviceToNewBox(ByVal strDeviceIDsIn As String, ByVal iPallettID As Integer)
            Dim strSQL As String

            Try
                strSQL = "UPDATE production.tdevice" & Environment.NewLine
                strSQL &= String.Format("SET pallett_id = {0}", iPallettID) & Environment.NewLine
                strSQL &= String.Format("WHERE device_id IN ({0})", strDeviceIDsIn)

                Me._objDataProc.ExecuteNonQuery(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub UpdateOldBoxQuantity(ByVal iOldPallettID As Integer, ByVal iMovedQty As Integer)
            Dim strSQL As String

            Try
                strSQL = "UPDATE production.tpallett" & Environment.NewLine
                strSQL &= String.Format("SET pallett_qty = pallett_qty - {0}", iMovedQty) & Environment.NewLine
                strSQL &= String.Format("WHERE pallett_id = {0}", iOldPallettID)

                Me._objDataProc.ExecuteNonQuery(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub


        Public Function GetPQCReportData(ByVal iCustID As Integer, _
                                                 ByVal iLocID As Integer, _
                                                 ByVal strBegDT As String, _
                                                 ByVal strEndDT As String) As DataTable
            Dim strSql As String
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "select concat(trim(f.manuf_Desc),trim(e.cust_outgoingSku)) as Grp,f.manuf_Desc,e.cust_outgoingSku as Model,b.Pallet_ShipType," & Environment.NewLine
                strSql &= "a.Device_ManufWrty,a.Device_LaborCharge,d.model_desc" & Environment.NewLine
                strSql &= " from tdevice a" & Environment.NewLine
                strSql &= " inner join tpallett b on a.pallett_id = b.pallett_id" & Environment.NewLine
                strSql &= " inner join tpackingslip c on b.pkslip_id = c.pkslip_id" & Environment.NewLine
                strSql &= " inner join tmodel d on a.model_id = d.model_id" & Environment.NewLine
                strSql &= " inner join tcustmodel_pssmodel_map e on d.model_id = e.model_id and e.cust_id=" & iCustID & Environment.NewLine
                strSql &= " inner join lmanuf f on d.manuf_id = f.manuf_id" & Environment.NewLine
                strSql &= " where c.pkslip_createdt between '" & strBegDT & "' and '" & strEndDT & "'" & Environment.NewLine
                strSql &= " and b.Pallet_ShipType=0 and a.loc_id=" & iLocID & Environment.NewLine
                strSql &= " order by concat(trim(f.manuf_Desc),trim(e.cust_outgoingSku));"
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(objDataProc) Then objDataProc = Nothing
            End Try
        End Function

        '****************************************************************************************
        Public Sub CreatePQCReport(ByVal resultDataTable As DataTable, ByVal resultSummaryDataTable As DataTable, ByVal strDateRange As String)

            'Excel Related variables
            Dim objXL As Excel.Application
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook    ' Excel workbook
            Dim objSheet As Excel.Worksheet   ' Excel Worksheet
            'Dim strFileName As String = "Testing.xls"  'CStr(Format(CDate(strFromDt), "yyyy-MM-dd")) & "__" & CStr(Format(CDate(strToDt), "yyyy-MM-dd")) & "  " & Now.Minute & Now.Second & ".xls"
            Dim rng As Excel.Range

            Dim R1 As DataRow
            Dim i As Integer = 0, j As Integer = 0, strTotalColName As String
            Dim iRowStart As Integer = 3, iColStart As Integer = 1
            Dim iRow As Integer, iCol As Integer
            Dim strSourceRange As String, strCriteria As String, strSumRange As String

            Dim objSaveFileDialog As New SaveFileDialog()
            Dim strFileName = "Tracfone PQC Report"

            Try

                If resultDataTable.Rows.Count = 0 Then
                    MsgBox("There's no data .", MsgBoxStyle.Information)
                Else
                    '******************************************************************
                    'Instantiate the excel related objects
                    objExcel = New Excel.Application()      'Starts the Excel Session
                    objBook = objExcel.Workbooks.Add                    'Add a Workbook
                    objExcel.Application.Visible = False 'True             'Make this false while going live
                    objExcel.Application.DisplayAlerts = False
                    objSheet = objBook.Worksheets.Item(1)               'Select a Sheet 1 for this

                    objExcel.ActiveSheet.Pagesetup.Orientation = 2      ' 1 = Portrait ; 2 = landscape
                    objExcel.ActiveWindow.DisplayGridlines = False
                    objSheet.Name = "PQC Report"

                    'Detail Result Tables ------------------------------------------------------------------------------------------------------------
                    'fill header data
                    objSheet.Cells(iRowStart - 1, iColStart) = "TRIAGEING RESUTLS"
                    For j = 0 To resultDataTable.Columns.Count - 1 'fill header
                        iRow = iRowStart : iCol = j + iColStart
                        objSheet.Cells(iRow, iCol) = resultDataTable.Columns(j).ColumnName.ToString.Replace("_", " ")
                        If j = resultDataTable.Columns.Count - 1 Then 'for sum header
                            iCol += 1 : objSheet.Cells(iRow, iCol) = "Total Repairs (Func./Cos.)"
                            iCol += 1 : objSheet.Cells(iRow, iCol) = "Total Triaged"
                            iCol += 1 : objSheet.Cells(iRow, iCol) = "% NPF"
                        End If
                    Next

                    'header Bold
                    objSheet.Range(CalExcelColLetter(iColStart) & iRowStart - 1 & ":" & CalExcelColLetter(iColStart + resultDataTable.Columns.Count + 2) & iRowStart).Select()
                    With objExcel.Selection
                        .font.bold = True ': .HorizontalAlignment = Excel.Constants.xlCenter
                    End With
                    'Following do the same thing
                    'iRow = iRowStart - 1 : iCol = iColStart
                    'rng = objSheet.Range(objSheet.Cells(iRow, iCol), objSheet.Cells(iRow + 1, iCol + +resultDataTable.Columns.Count + 2))
                    'rng.Font.Bold = True

                    'Fill data and compute
                    For i = 0 To resultDataTable.Rows.Count - 1 'for eacj row
                        iRow = iRowStart + (i + 1)
                        For j = 0 To resultDataTable.Columns.Count - 1 'for each col
                            iCol = j + iColStart : objSheet.Cells(iRow, iCol) = resultDataTable.Rows(i).Item(j)
                            If j = resultDataTable.Columns.Count - 1 Then 'add sum cols
                                iCol += 1
                                objSheet.Cells(iRow, iCol).Formula = _
                                            "=SUM(" & CalExcelColLetter(iCol - 2) & iRow & _
                                            "+" & CalExcelColLetter(iCol - 1) & iRow & ")"
                                iCol += 1
                                objSheet.Cells(iRow, iCol).Formula = _
                                            "=SUM(" & CalExcelColLetter(iCol - 4) & iRow & _
                                            ":" & CalExcelColLetter(iCol - 2) & iRow & ")"
                                iCol += 1
                                rng = objSheet.Range(objSheet.Cells(iRow, iCol), objSheet.Cells(iRow, iCol))
                                rng.NumberFormat = "0.00%"
                                objSheet.Cells(iRow, iCol).Formula = _
                                            "=" & CalExcelColLetter(iCol - 5) & iRow & _
                                            "/" & CalExcelColLetter(iCol - 1) & iRow

                            End If
                        Next 'for each col

                        If i = resultDataTable.Rows.Count - 1 Then 'add total rows
                            'Total Row 1
                            iRow += 1 : iCol = iColStart
                            objSheet.Cells(iRow, iCol) = "Total"
                            iCol += 2
                            objSheet.Cells(iRow, iCol).Formula = _
                                        "=SUM(" & CalExcelColLetter(iCol) & iRowStart + 1 & _
                                        ":" & CalExcelColLetter(iCol) & iRow - 1 & ")"
                            iCol += 1
                            objSheet.Cells(iRow, iCol).Formula = _
                                               "=SUM(" & CalExcelColLetter(iCol) & iRowStart + 1 & _
                                               ":" & CalExcelColLetter(iCol) & iRow - 1 & ")"
                            iCol += 1
                            objSheet.Cells(iRow, iCol).Formula = _
                                               "=SUM(" & CalExcelColLetter(iCol) & iRowStart + 1 & _
                                               ":" & CalExcelColLetter(iCol) & iRow - 1 & ")"

                            iCol += 1
                            objSheet.Cells(iRow, iCol).Formula = _
                                        "=SUM(" & CalExcelColLetter(iCol - 2) & iRow & _
                                        "+" & CalExcelColLetter(iCol - 1) & iRow & ")"
                            iCol += 1
                            objSheet.Cells(iRow, iCol).Formula = _
                                        "=SUM(" & CalExcelColLetter(iCol - 4) & iRow & _
                                        ":" & CalExcelColLetter(iCol - 2) & iRow & ")"
                            strTotalColName = "$" & CalExcelColLetter(iCol) & "$" & iRow '$H$57
                            iCol += 1
                            rng = objSheet.Range(objSheet.Cells(iRow, iCol), objSheet.Cells(iRow, iCol))
                            rng.NumberFormat = "0.00%"
                            objSheet.Cells(iRow, iCol).Formula = _
                                        "=" & CalExcelColLetter(iCol - 5) & iRow & _
                                        "/" & CalExcelColLetter(iCol - 1) & iRow

                            'Total Row 2
                            iRow += 1 : iCol = iColStart
                            objSheet.Cells(iRow, iCol) = "% of Total"
                            For iCol = iColStart + 2 To 7
                                If iCol = 7 Then
                                    objSheet.Cells(iRow, iCol).Formula = _
                                                                     "=SUM(" & CalExcelColLetter(iCol - 4) & iRow - 1 & _
                                                                     ":" & CalExcelColLetter(iCol - 2) & iRow - 1 & ")"
                                Else
                                    rng = objSheet.Range(objSheet.Cells(iRow, iCol), objSheet.Cells(iRow, iCol))
                                    rng.NumberFormat = "0.00%"
                                    objSheet.Cells(iRow, iCol).Formula = _
                                                "=SUM(" & CalExcelColLetter(iCol) & iRow - 1 & _
                                                "/" & strTotalColName & ")"
                                End If
                            Next
                        End If 'add total rows
                    Next 'for eacj row

                    'Format last 2 summary rows
                    iRow = iRowStart + resultDataTable.Rows.Count + 1 : iCol = iColStart
                    rng = objSheet.Range(objSheet.Cells(iRow, iCol), objSheet.Cells(iRow + 1, iCol + resultDataTable.Columns.Count + 2))
                    rng.Font.Bold = True

                    'objSheet.Range(CalExcelColLetter(iCol) & iRow & ":" & CalExcelColLetter(iCol + resultDataTable.Columns.Count + 2) & iRow + 1).Select()
                    'With objExcel.Selection
                    '    .font.bold = True ':.MergeCells = True : .HorizontalAlignment = Excel.Constants.xlCenter 
                    'End With

                    'objSheet.Range(CalExcelColLetter(iCol) & iRow - 1 & ":" & CalExcelColLetter(iCol + 1) & iRow - 1).Select()
                    'With objExcel.Selection
                    '    .MergeCells = True : .HorizontalAlignment = Excel.Constants.xlCenter : .font.bold = True
                    'End With


                    'Add borders 
                    iRow = iRowStart - 1 : iCol = iColStart
                    rng = objSheet.Range(objSheet.Cells(iRow, iCol), objSheet.Cells(iRow + resultDataTable.Rows.Count + 3, iCol + resultDataTable.Columns.Count + 2))
                    rng.Borders.LineStyle = Excel.XlLineStyle.xlContinuous

                    'Merge cells 
                    rng = objSheet.Range(objSheet.Cells(iRow, iCol), objSheet.Cells(iRow, iCol + resultDataTable.Columns.Count + 2))
                    rng.MergeCells = True : rng.HorizontalAlignment = Excel.Constants.xlCenter
                    iRow = iRowStart + resultDataTable.Rows.Count + 1 : iCol = iColStart
                    rng = objSheet.Range(objSheet.Cells(iRow, iCol), objSheet.Cells(iRow, iCol + 1))
                    rng.MergeCells = True : rng.HorizontalAlignment = Excel.Constants.xlCenter
                    rng = objSheet.Range(objSheet.Cells(iRow + 1, iCol), objSheet.Cells(iRow + 1, iCol + 1))
                    rng.MergeCells = True : rng.HorizontalAlignment = Excel.Constants.xlCenter

                    'Summary Table 1 ---------------------------------------------------------------------------------------------------
                    iRow = iRowStart : iCol = iColStart + resultDataTable.Columns.Count + 3
                    objSheet.Cells(iRow - 1, iCol) = "Totals by Manufacturer"
                    objSheet.Cells(iRow, iCol) = "Manufacturer" : objSheet.Cells(iRow, iCol + 1) = "No Problem Found"
                    objSheet.Cells(iRow, iCol + 2) = "Reairs Out of Warranty" : objSheet.Cells(iRow, iCol + 3) = "Warranty Repairs"
                    objSheet.Cells(iRow, iCol + 4) = "Total Repairs (Func./Cos.)"

                    'Data fill
                    strSourceRange = "$" & CalExcelColLetter(iColStart) & "$" & iRow + 1 & ":$" & CalExcelColLetter(iColStart) & "$" & iRow + resultDataTable.Rows.Count
                    For i = 0 To resultSummaryDataTable.Rows.Count - 1
                        objSheet.Cells(iRow + 1 + i, iCol) = resultSummaryDataTable.Rows(i).Item("Manufcturer")
                        For j = 1 To 4
                            Dim strFormula As String = "=SUMIF(" & strSourceRange & ",$" & CalExcelColLetter(iCol) & iRow + 1 + i & _
                            "," & CalExcelColLetter(iColStart + 1 + j) & "$" & iRow + 1 & ":" & CalExcelColLetter(iColStart + 1 + j) & "$" & iRow + resultDataTable.Rows.Count & ")"
                            objSheet.Cells(iRow + 1 + i, iCol + j).Formula = strFormula
                        Next
                    Next
                    iRow = iRowStart + resultSummaryDataTable.Rows.Count + 1
                    objSheet.Cells(iRow, iCol) = "Total"
                    For j = 1 To 4
                        objSheet.Cells(iRow, iCol + j).Formula = "=SUM(" & CalExcelColLetter(iCol + j) & iRowStart + 1 & ":" & _
                                                                 CalExcelColLetter(iCol + j) & iRowStart + resultSummaryDataTable.Rows.Count
                    Next

                    'Font
                    iRow = iRowStart - 1 : iCol = iColStart + resultDataTable.Columns.Count + 3
                    rng = objSheet.Range(objSheet.Cells(iRow, iCol), objSheet.Cells(iRow + 1, iCol + 4))
                    rng.Font.Bold = True
                    iRow = iRowStart + resultSummaryDataTable.Rows.Count + 1
                    rng = objSheet.Range(objSheet.Cells(iRow, iCol), objSheet.Cells(iRow + 1, iCol + 4))
                    rng.Font.Bold = True
                    iRow = iRowStart + 1 : iCol = iColStart + resultDataTable.Columns.Count + 3
                    rng = objSheet.Range(objSheet.Cells(iRow, iCol), objSheet.Cells(iRowStart + resultSummaryDataTable.Rows.Count, iCol))
                    rng.Font.Bold = True

                    'Add borders 
                    iRow = iRowStart - 1 : iCol = iColStart + resultDataTable.Columns.Count + 3
                    rng = objSheet.Range(objSheet.Cells(iRow, iCol), objSheet.Cells(iRow + resultSummaryDataTable.Rows.Count + 2, iCol + 4))
                    rng.Borders.LineStyle = Excel.XlLineStyle.xlContinuous

                    'Merge cells 
                    iRow = iRowStart - 1 : iCol = iColStart + resultDataTable.Columns.Count + 3
                    rng = objSheet.Range(objSheet.Cells(iRow, iCol), objSheet.Cells(iRow, iCol + 4))
                    rng.MergeCells = True : rng.HorizontalAlignment = Excel.Constants.xlCenter

                    'Summary Table 2 (Tow tables) ---------------------------------------------------------------------------------------------------
                    iRow = iRowStart + resultSummaryDataTable.Rows.Count + 4 : iCol = iColStart + resultDataTable.Columns.Count + 3
                    objSheet.Cells(iRow, iCol) = "Totals by Manufacturer (FUNC)"
                    objSheet.Cells(iRow, iCol + 3) = "Totals by Manufacturer (COS)"
                    objSheet.Cells(iRow + 1, iCol) = "Manufacturer"
                    objSheet.Cells(iRow + 1, iCol + 3) = "Manufacturer"
                    objSheet.Cells(iRow + 1, iCol + 1) = "Totals"
                    objSheet.Cells(iRow + 1, iCol + 4) = "Totals"
                    'Fill data
                    For i = 0 To resultSummaryDataTable.Rows.Count - 1
                        objSheet.Cells(iRow + 2 + i, iCol) = resultSummaryDataTable.Rows(i).Item("Manufcturer")
                        objSheet.Cells(iRow + 2 + i, iCol + 3) = resultSummaryDataTable.Rows(i).Item("Manufcturer")
                        objSheet.Cells(iRow + 2 + i, iCol + 1) = resultSummaryDataTable.Rows(i).Item("TotalsFunc")
                        objSheet.Cells(iRow + 2 + i, iCol + 4) = resultSummaryDataTable.Rows(i).Item("TotalsCos")
                        If i = resultSummaryDataTable.Rows.Count - 1 Then
                            objSheet.Cells(iRow + 2 + i + 1, iCol) = "Total" : objSheet.Cells(iRow + 2 + i + 1, iCol + 3) = "Total"
                            objSheet.Cells(iRow + 2 + i + 1, iCol + 1) = "=SUM(" & CalExcelColLetter(iCol + 1) & _
                                                (iRow + 2 + i) - resultSummaryDataTable.Rows.Count + 1 & ":" & _
                                                CalExcelColLetter(iCol + 1) & iRow + 2 + i & ")"
                            objSheet.Cells(iRow + 2 + i + 1, iCol + 4) = "=SUM(" & CalExcelColLetter(iCol + 4) & _
                                                (iRow + 2 + i) - resultSummaryDataTable.Rows.Count + 1 & ":" & _
                                                CalExcelColLetter(iCol + 4) & iRow + 2 + i & ")"
                        End If
                    Next

                    'Font
                    rng = objSheet.Range(objSheet.Cells(iRow, iCol), objSheet.Cells(iRow + 1, iCol + 1)) : rng.Font.Bold = True
                    rng = objSheet.Range(objSheet.Cells(iRow, iCol + 3), objSheet.Cells(iRow + 1, iCol + 4)) : rng.Font.Bold = True
                    rng = objSheet.Range(objSheet.Cells(iRow, iCol), objSheet.Cells(iRow + resultSummaryDataTable.Rows.Count + 2, iCol)) : rng.Font.Bold = True
                    rng = objSheet.Range(objSheet.Cells(iRow, iCol + 3), objSheet.Cells(iRow + resultSummaryDataTable.Rows.Count + 2, iCol + 3)) : rng.Font.Bold = True
                    iRow = iRowStart + 2 * resultSummaryDataTable.Rows.Count + 6
                    rng = objSheet.Range(objSheet.Cells(iRow, iCol), objSheet.Cells(iRow, iCol + 1)) : rng.Font.Bold = True
                    rng = objSheet.Range(objSheet.Cells(iRow, iCol + 3), objSheet.Cells(iRow, iCol + 4)) : rng.Font.Bold = True

                    'Border
                    iRow = iRowStart + resultSummaryDataTable.Rows.Count + 4 : iCol = iColStart + resultDataTable.Columns.Count + 3
                    rng = objSheet.Range(objSheet.Cells(iRow, iCol), objSheet.Cells(iRow + resultSummaryDataTable.Rows.Count + 2, iCol + 1))
                    rng.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                    rng = objSheet.Range(objSheet.Cells(iRow, iCol + 3), objSheet.Cells(iRow + resultSummaryDataTable.Rows.Count + 2, iCol + 4))
                    rng.Borders.LineStyle = Excel.XlLineStyle.xlContinuous

                    'Merge
                    rng = objSheet.Range(objSheet.Cells(iRow, iCol), objSheet.Cells(iRow, iCol + 1))
                    rng.MergeCells = True : rng.HorizontalAlignment = Excel.Constants.xlCenter
                    rng = objSheet.Range(objSheet.Cells(iRow, iCol + 3), objSheet.Cells(iRow, iCol + 4))
                    rng.MergeCells = True : rng.HorizontalAlignment = Excel.Constants.xlCenter

                    'Text Alignment
                    rng = objSheet.Range(objSheet.Cells(iRow + 1, iCol + 1), objSheet.Cells(iRow + 1, iCol + 1)) : rng.HorizontalAlignment = Excel.Constants.xlRight
                    rng = objSheet.Range(objSheet.Cells(iRow + 1, iCol + 4), objSheet.Cells(iRow + 1, iCol + 4)) : rng.HorizontalAlignment = Excel.Constants.xlRight

                    '------------------------------------------------------------------------------------------------------------------
                    'Top row merge and add title for the sheet
                    objSheet.Cells(1, iColStart) = "PSSI: " & strFileName & " (" & strDateRange & ")"
                    rng = objSheet.Range(objSheet.Cells(1, iColStart), objSheet.Cells(1, iColStart + resultDataTable.Columns.Count + 7))
                    rng.Font.Bold = True : rng.MergeCells = True : rng.HorizontalAlignment = Excel.Constants.xlCenter

                    'set focus 
                    objSheet.Cells(1, 1).Select()

                    'Auto fit
                    objSheet.Cells.EntireColumn.AutoFit()
                    objSheet.Cells.EntireRow.AutoFit()

                    'Remove unused sheets
                    objExcel.Sheets("Sheet2").Delete()
                    objExcel.Sheets("Sheet3").Delete()

                    'Save Excel file
                    objSaveFileDialog.DefaultExt = "xls"
                    objSaveFileDialog.FileName = strFileName & ".xls"
                    objSaveFileDialog.ShowDialog()
                    strFileName = objSaveFileDialog.FileName

                    If strFileName.Trim.Length = 0 Then
                        MessageBox.Show("No file name has been selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        If strFileName.IndexOf("\") < 0 Then Exit Sub
                        If File.Exists(strFileName) = True Then Kill(strFileName)
                        objBook.SaveAs(strFileName)
                        MessageBox.Show("File has been saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If

            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(resultDataTable) Then
                    resultDataTable.Dispose()
                    resultDataTable = Nothing
                End If
                If Not IsNothing(resultSummaryDataTable) Then
                    resultSummaryDataTable.Dispose()
                    resultSummaryDataTable = Nothing
                End If
                R1 = Nothing

                'Excel clean up
                If Not IsNothing(objSheet) Then
                    objSheet = Nothing
                    NAR(objSheet)
                End If
                If Not IsNothing(objBook) Then
                    objBook.Close()
                    objBook = Nothing
                    NAR(objBook)
                End If
                If Not IsNothing(objExcel) Then
                    objExcel.Quit()
                    objExcel = Nothing
                    NAR(objExcel)
                End If
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()

            End Try
        End Sub

        '****************************************************************************************
        Public Function GetRepairsMasterData(ByVal iCustID As Integer, _
                                         ByVal iLocID As Integer, _
                                         ByVal strBegDT As String, _
                                         ByVal strEndDT As String, _
                                         ByVal strCols As String, _
                                         ByVal strAdditionalCols As String) As DataTable
            Dim strSql As String
            Dim objDataProc As DBQuery.DataProc

            Try

                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "(select a.device_SN as ESN, e.cust_IncomingSku as 'Model Code'," & strCols & Environment.NewLine
                strSql &= ",f.manuf_Desc,'' as CountYes,b.Pallet_ShipType,device_id" & strAdditionalCols & Environment.NewLine
                strSql &= " from tdevice a" & Environment.NewLine
                strSql &= " inner join tpallett b on a.pallett_id = b.pallett_id" & Environment.NewLine
                strSql &= " inner join tpackingslip c on b.pkslip_id = c.pkslip_id" & Environment.NewLine
                strSql &= " inner join tmodel d on a.model_id = d.model_id" & Environment.NewLine
                strSql &= " inner join tcustmodel_pssmodel_map e on d.model_id = e.model_id and e.cust_id=" & iCustID & Environment.NewLine
                strSql &= " inner join lmanuf f on d.manuf_id = f.manuf_id" & Environment.NewLine
                strSql &= " where c.pkslip_createdt between '" & strBegDT & "' and '" & strEndDT & "'" & Environment.NewLine
                strSql &= " and  b.Pallet_ShipType=0 and a.loc_id=" & iLocID & ")" & Environment.NewLine
                strSql &= " union all" & Environment.NewLine
                strSql &= " (select a.device_SN as ESN, e.cust_IncomingSku as 'Model Code'," & strCols & Environment.NewLine
                strSql &= ",f.manuf_Desc,'' as CountYes,b.Pallet_ShipType,device_id" & strAdditionalCols & Environment.NewLine
                strSql &= " from tdevice a" & Environment.NewLine
                strSql &= " inner join tpallett b on a.pallett_id = b.pallett_id" & Environment.NewLine
                strSql &= " inner join tpackingslip c on b.pkslip_id = c.pkslip_id" & Environment.NewLine
                strSql &= " inner join tmodel d on a.model_id = d.model_id" & Environment.NewLine
                strSql &= " inner join tcustmodel_pssmodel_map e on d.model_id = e.model_id and e.cust_id=" & iCustID & Environment.NewLine
                strSql &= " inner join lmanuf f on d.manuf_id = f.manuf_id" & Environment.NewLine
                strSql &= " where a.device_dateship between '" & strBegDT & "' and '" & strEndDT & "'" & Environment.NewLine
                strSql &= " and  b.Pallet_ShipType=1 and a.loc_id=" & iLocID & ")" & Environment.NewLine
                strSql &= " order by concat(trim(manuf_Desc),trim('Model Code'));" & Environment.NewLine
                Return objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(objDataProc) Then objDataProc = Nothing
            End Try
        End Function

        '****************************************************************************************
        Public Function GetBillCodes() As DataTable
            Dim strSql As String = ""

            Try
                strSql = "select TFB_ID,TFB_Desc,TFB_desc2,TFB_Type,TFB_Subtype,tfb_COSFUNC_Order " & Environment.NewLine
                strSql &= " from tracfonebillcode order by tfb_desc_Order" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try

        End Function

        '*************************************************************************************
        Public Function GetBillCodes4SummaryReport() As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT tfb_type, tfb_subtype, tfb_desc2, tfb_cosfunc_order, tfb_id, tfb_desc" & Environment.NewLine
                strSql &= " FROM tracfonebillcode" & Environment.NewLine
                strSql &= " WHERE Length(Trim(tfb_desc2)) > 0 AND tfb_type in ('COS','FUNC')" & Environment.NewLine
                strSql &= " ORDER BY tfb_type, tfb_cosfunc_order;"

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************
        Public Function GetBillCodesResult(ByVal iDeviceID As Integer, ByVal strDeviceBillTableName As String) As DataTable '(ByVal iDeviceID As Integer) As DataTable

            Dim strSql As String = ""
            Dim dt As DataTable, i As Integer = 0

            Try
                'strSql = "select tdevicebill.*,lbillcodes.BillCode_Desc,lbillcodes.BillCode_Rule,lbillcodes.BillType_ID" & Environment.NewLine
                'strSql &= ",lbilltype.BillType_LDesc,tracfonebillcodemap.tfbm_id, tracfonebillcode.tfb_id,tracfonebillcode.tfb_desc" & Environment.NewLine
                'strSql &= ",tracfonebillcode.tfb_desc2,tracfonebillcode.tfb_Type,tracfonebillcode.tfb_subtype,tracfonebillcode.tfb_CosFunc_order" & Environment.NewLine
                'strSql &= ",lcomplaint.comp_ID,lcomplaint.Comp_Code,lcomplaint.Comp_desc,laborlevel" & Environment.NewLine
                'strSql &= ",if(lbillcodes.Billtype_ID = 2 and LaborLevel > 0 , 'Replace', '') as 'Repair Action'" & Environment.NewLine
                'strSql &= ",if(tdevicebill.billcode_id in (1873,1875,1871,1811,1872), 'No Solution'," & Environment.NewLine
                'strSql &= "     if(tdevicebill.billcode_id in (275),'Abuse'," & Environment.NewLine
                'strSql &= "       if(tdevicebill.billcode_id in (267), 'Liquid Damage'," & Environment.NewLine
                'strSql &= "          if(tdevicebill.billcode_id in (991,1924), 'OBSO Destruction',''" & Environment.NewLine
                'strSql &= "             )" & Environment.NewLine
                'strSql &= "          )" & Environment.NewLine
                'strSql &= "       )" & Environment.NewLine
                'strSql &= "    )  as 'Scrap Reason'" & Environment.NewLine
                'strSql &= " from tdevice" & Environment.NewLine
                'strSql &= " inner join tdevicebill on tdevice.device_ID = tdevicebill.device_ID" & Environment.NewLine
                'strSql &= " inner join lbillcodes on tdevicebill.billcode_ID = lbillcodes.billcode_Id" & Environment.NewLine
                'strSql &= " inner join lbilltype on lbillcodes.Billtype_ID=lbilltype.Billtype_ID" & Environment.NewLine
                'strSql &= " inner join tpsmap on tdevice.model_ID = tpsmap.model_ID and tdevicebill.billcode_ID = tpsmap.billcode_ID" & Environment.NewLine
                'strSql &= " left join tracfonebillcodemap on tdevicebill.billcode_ID = tracfonebillcodemap.billcode_ID" & Environment.NewLine
                'strSql &= " left join tracfonebillcode on tracfonebillcodemap.TFB_ID = tracfonebillcode.TFB_ID" & Environment.NewLine
                'strSql &= " left JOIN lcomplaint ON tdevicebill.Comp_ID = lcomplaint.Comp_ID" & Environment.NewLine
                'strSql &= " where tdevice.device_id =" & iDeviceID & ";" & Environment.NewLine

                strSql = "select " & strDeviceBillTableName & ".*,lbillcodes.BillCode_Desc,lbillcodes.BillCode_Rule,lbillcodes.BillType_ID" & Environment.NewLine
                strSql &= ",lbilltype.BillType_LDesc,tracfonebillcodemap.tfbm_id, tracfonebillcode.tfb_id,tracfonebillcode.tfb_desc" & Environment.NewLine
                strSql &= ",tracfonebillcode.tfb_desc2,tracfonebillcode.tfb_Type,tracfonebillcode.tfb_subtype,tracfonebillcode.tfb_CosFunc_order" & Environment.NewLine
                strSql &= ",lcomplaint.comp_ID,lcomplaint.Comp_Code,lcomplaint.Comp_desc,laborlevel" & Environment.NewLine
                strSql &= ",if(lbillcodes.Billtype_ID = 2 and LaborLevel > 0 , 'Replace', '') as 'Repair Action'" & Environment.NewLine
                strSql &= ",if(" & strDeviceBillTableName & ".billcode_id in (1873,1875,1871,1811,1872), 'No Solution'," & Environment.NewLine
                strSql &= "     if(" & strDeviceBillTableName & ".billcode_id in (275),'Abuse'," & Environment.NewLine
                strSql &= "       if(" & strDeviceBillTableName & ".billcode_id in (267), 'Liquid Damage'," & Environment.NewLine
                strSql &= "          if(" & strDeviceBillTableName & ".billcode_id in (991,1924), 'OBSO Destruction',''" & Environment.NewLine
                strSql &= "             )" & Environment.NewLine
                strSql &= "          )" & Environment.NewLine
                strSql &= "       )" & Environment.NewLine
                strSql &= "    )  as 'Scrap Reason'" & Environment.NewLine
                strSql &= " from tdevice" & Environment.NewLine
                strSql &= " inner join " & strDeviceBillTableName & " on tdevice.device_ID = " & strDeviceBillTableName & ".device_ID" & Environment.NewLine
                strSql &= " inner join lbillcodes on " & strDeviceBillTableName & ".billcode_ID = lbillcodes.billcode_Id" & Environment.NewLine
                strSql &= " inner join lbilltype on lbillcodes.Billtype_ID=lbilltype.Billtype_ID" & Environment.NewLine
                strSql &= " inner join tpsmap on tdevice.model_ID = tpsmap.model_ID and " & strDeviceBillTableName & ".billcode_ID = tpsmap.billcode_ID" & Environment.NewLine
                strSql &= " left join tracfonebillcodemap on " & strDeviceBillTableName & ".billcode_ID = tracfonebillcodemap.billcode_ID" & Environment.NewLine
                strSql &= " left join tracfonebillcode on tracfonebillcodemap.TFB_ID = tracfonebillcode.TFB_ID" & Environment.NewLine
                strSql &= " left JOIN lcomplaint ON " & strDeviceBillTableName & ".Comp_ID = lcomplaint.Comp_ID" & Environment.NewLine
                strSql &= " where tdevice.device_id =" & iDeviceID & ";" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try

        End Function

        '*************************************************************************************
        Public Function GetBillCodesResult_Reflow(ByVal iDeviceID As Integer) As DataTable

            Dim strSql As String = ""
            Dim dt As DataTable, i As Integer = 0

            Try

                strSql &= " select treflowpart.device_ID,treflowpart.billcode_id,lbillcodes.BillCode_Desc,lbillcodes.BillCode_Rule,lbillcodes.BillType_ID" & Environment.NewLine
                strSql &= " ,lbilltype.BillType_LDesc,tracfonebillcodemap.tfbm_id, tracfonebillcode.tfb_id,tracfonebillcode.tfb_desc" & Environment.NewLine
                strSql &= " ,tracfonebillcode.tfb_desc2,tracfonebillcode.tfb_Type,tracfonebillcode.tfb_subtype,tracfonebillcode.tfb_CosFunc_order" & Environment.NewLine
                strSql &= " from treflowpart" & Environment.NewLine
                strSql &= " left join tracfonebillcodemap on treflowpart.billcode_ID = tracfonebillcodemap.billcode_ID" & Environment.NewLine
                strSql &= " left join tracfonebillcode on tracfonebillcodemap.TFB_ID = tracfonebillcode.TFB_ID" & Environment.NewLine
                strSql &= " inner join lbillcodes on treflowpart.billcode_ID = lbillcodes.billcode_Id" & Environment.NewLine
                strSql &= " inner join lbilltype on lbillcodes.Billtype_ID=lbilltype.Billtype_ID" & Environment.NewLine
                strSql &= " where treflowpart.device_id=" & iDeviceID & " and lbillcodes.billtype_id =2;" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try

        End Function


        Public Sub CreateExcelRepairsByIEMIReport(ByVal resultDataTable As DataTable, _
                                               ByVal strColBillCodesArray As ArrayList, _
                                               ByVal BillCodeDataTable4SummaryRpt As DataTable, _
                                               ByVal strDateRange As String, _
                                               ByVal bAdditionalCols As Boolean)

            'Excel Related variables
            Dim objXL As Excel.Application
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook    ' Excel workbook
            Dim objSheet As Excel.Worksheet   ' Excel Worksheet
            Dim objSheet2 As Excel.Worksheet ' Excel Worksheet

            'Dim strFileName As String = "Testing.xls"  'CStr(Format(CDate(strFromDt), "yyyy-MM-dd")) & "__" & CStr(Format(CDate(strToDt), "yyyy-MM-dd")) & "  " & Now.Minute & Now.Second & ".xls"
            Dim rng As Excel.Range

            Dim R1 As DataRow
            Dim i As Integer = 0, j As Integer = 0, strTotalColName As String
            Dim iRowStart As Integer = 3, iColStart As Integer = 1
            Dim iRow As Integer, iCol As Integer
            Dim iColBillCodesArray As New ArrayList()
            Dim strSourceRange As String, strCriteria As String, strSumRange As String

            Dim objSaveFileDialog As New SaveFileDialog()
            Dim strFileName = "Tracfone Report By IMEI"

            Try


                '******************************************************************
                'Instantiate the excel related objects
                objExcel = New Excel.Application()      'Starts the Excel Session
                objBook = objExcel.Workbooks.Add                    'Add a Workbook
                objExcel.Application.Visible = False 'True             'Make this false while going live
                objExcel.Application.DisplayAlerts = False
                objSheet = objBook.Worksheets.Item(1)               'Select  Sheet 1 for this
                objSheet2 = objBook.Worksheets.Item(2) 'Select  Sheet 2 for this

                objExcel.ActiveSheet.Pagesetup.Orientation = 2      ' 1 = Portrait ; 2 = landscape
                objExcel.ActiveWindow.DisplayGridlines = False
                objSheet.Name = "Details"
                objSheet2.Name = "Summary"


                'Fast way ----------------------------------------------------------
                ' Copy the DataTable to an object array
                Dim rawData As Object(,) = New Object(resultDataTable.Rows.Count, resultDataTable.Columns.Count - 1) {}

                ' Copy the column names to the first row of the object array
                For iCol = 0 To resultDataTable.Columns.Count - 1
                    rawData(0, iCol) = resultDataTable.Columns(iCol).ColumnName 'add excel column header name
                    If strColBillCodesArray.Contains(resultDataTable.Columns(iCol).ColumnName) Then 'get column index for billcode columns
                        iColBillCodesArray.Add(iCol + 1)
                    End If
                Next

                ' Copy the values to the object array
                For iCol = 0 To resultDataTable.Columns.Count - 1
                    For iRow = 0 To resultDataTable.Rows.Count - 1
                        If iCol = 0 Then
                            rawData(iRow + 1, iCol) = "'" & resultDataTable.Rows(iRow).ItemArray(iCol) 'first col ESN is numeric as text  by adding "'" before it
                        Else
                            rawData(iRow + 1, iCol) = resultDataTable.Rows(iRow).ItemArray(iCol)
                        End If

                    Next
                Next

                ' Fast data export to Excel
                'Dim excelRange As String = String.Format("A1:{0}{1}", CalExcelColLetter(resultDataTable.Columns.Count), resultDataTable.Rows.Count + 1)
                'objExcel.get_Range(excelRange, Type.Missing).Value2 = rawData
                'rng = objSheet.Range("A1", [String].Format("{0}{1}", CalExcelColLetter(resultDataTable.Columns.Count), resultDataTable.Rows.Count + 1))
                rng = objSheet.Range(CalExcelColLetter(iColStart) & iRowStart, [String].Format("{0}{1}", CalExcelColLetter(resultDataTable.Columns.Count), resultDataTable.Rows.Count + 1))
                rng.Value = rawData


                'Add fomula 
                If bAdditionalCols Then
                    For j = 0 To iColBillCodesArray.Count - 1
                        iRow = iRowStart - 1 : iCol = iColBillCodesArray(j) + (iColStart - 1)
                        objSheet.Cells(iRow, iCol).Formula = "=COUNTIF(" & CalExcelColLetter(iCol) & iRow + 2 & _
                                                             ":" & CalExcelColLetter(iCol) & resultDataTable.Rows.Count + 1 & ", ""Yes"")"
                    Next
                    For i = 0 To (resultDataTable.Rows.Count - 1) - (iRowStart - 1)
                        iRow = iRowStart + i + 1 : iCol = iColBillCodesArray(iColBillCodesArray.Count - 1) + (iColStart - 1) + 5 'to get CountYes column
                        objSheet.Cells(iRow, iCol).Formula = "=COUNTIF(" & CalExcelColLetter(iColBillCodesArray(0) + (iColStart - 1)) & iRow & _
                                                              ":" & CalExcelColLetter(iCol - 5) & iRow & ", ""Yes"")"
                    Next
                    '=COUNTIF(G4:G22438, "=Yes")
                End If

                'add filters button
                iRow = iRowStart : iCol = iColBillCodesArray(iColBillCodesArray.Count - 1) + (iColStart - 1) + 5
                rng = objSheet.Range(objSheet.Cells(iRow, iColStart), objSheet.Cells(iRow, iCol))
                rng.AutoFilter(Field:=1, [Operator]:=Excel.XlAutoFilterOperator.xlAnd)

                'Alignment all billcode columns
                iRow = iRowStart - 1 : iCol = iColBillCodesArray(0) + (iColStart - 1)
                rng = objSheet.Range(objSheet.Cells(iRow, iCol), objSheet.Cells(iRow + resultDataTable.Rows.Count - 1, iCol + iColBillCodesArray.Count - 1))
                rng.HorizontalAlignment = Excel.Constants.xlCenter

                'Border
                If bAdditionalCols Then
                    iRow = iRowStart - 1 : iCol = iColBillCodesArray(iColBillCodesArray.Count - 1) + (iColStart - 1) + 5 'to get CountYes column
                    rng = objSheet.Range(objSheet.Cells(iRow, iColStart), objSheet.Cells(iRow + resultDataTable.Rows.Count - 1, iCol))
                    rng.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                Else
                    iRow = iRowStart : iCol = iColBillCodesArray(iColBillCodesArray.Count - 1) + (iColStart - 1) + 4 'No CountYes column now
                    rng = objSheet.Range(objSheet.Cells(iRow, iColStart), objSheet.Cells(iRow + resultDataTable.Rows.Count - 1, iCol))
                    rng.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                End If

                'Auto fit
                ' objSheet.Cells.EntireColumn.AutoFit() 'Entire sheet
                iRow = iRowStart : iCol = iColBillCodesArray(iColBillCodesArray.Count - 1) + (iColStart - 1) + 5
                rng = objSheet.Range(objSheet.Cells(iRow, iColStart), objSheet.Cells((resultDataTable.Rows.Count - 1) + (iRowStart + 1), iCol))
                rng.Columns.AutoFit()
                objSheet.Cells.EntireRow.AutoFit()

                ' Automatically set the width on columns B and C. not work?
                'worksheet.Cells("B:C").Columns.AutoFit()
                '' Set the row height to automatic on rows 7 through 9.
                'worksheet.Cells("7:9").Rows.AutoFit()


                'Remove unused sheets
                objExcel.Sheets("Sheet3").Delete()

                'Set title at top-left cell
                objSheet.Cells(1, 1) = "PSSI: " & strFileName & " (" & strDateRange & ")"
                rng = objSheet.Range(objSheet.Cells(1, 1), objSheet.Cells(1, 1))
                rng.Font.Size = 10 : rng.Font.Bold = True

                'No good. can't delete, it tell when Autofilter turned on
                'remove unneeded row (the formula row) and col (the CountYes Column)
                'iRow = iRowStart - 1
                'rng = objSheet.Range(objSheet.Cells(iRow, iColStart), objSheet.Cells(iRow, 1))
                'rng.EntireRow.Delete()
                'no good
                ''Have to turn off the AutoFilter before removing a column which has AutoFilter turned on
                ''rng = objSheet.Range(objSheet.Cells(iRow, iColStart), objSheet.Cells(iRow, iCol))
                ''rng.AutoFilter(Field:=1, Operator:=Excel.XlAutoFilterOperator.)
                'objSheet.AutoFilterMode = False
                'iCol = iColBillCodesArray(iColBillCodesArray.Count - 1) + (iColStart - 1) + 5 'CountYes column
                'rng = objSheet.Range(objSheet.Cells(1, iCol), objSheet.Cells((resultDataTable.Rows.Count - 1) - (iRowStart - 1), iCol))
                'rng.EntireColumn.Delete()
                'objSheet.AutoFilterMode = True

                'set focus 
                objSheet.Cells(1, 1).Select()


                CreateRepairsSummary(resultDataTable, BillCodeDataTable4SummaryRpt, strColBillCodesArray, objSheet2)

                'Save Excel file----------------------------------------------------------------------------------------------------------
                objSaveFileDialog.DefaultExt = "xls" ' "xlsx"
                objSaveFileDialog.FileName = strFileName & ".xls" ' ".xlsx"
                objSaveFileDialog.ShowDialog()
                strFileName = objSaveFileDialog.FileName

                If strFileName.Trim.Length = 0 Then
                    MessageBox.Show("No file name has been selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    If strFileName.IndexOf("\") < 0 Then Exit Sub
                    If File.Exists(strFileName) = True Then Kill(strFileName)
                    objBook.SaveAs(strFileName)
                    MessageBox.Show("File has been saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(resultDataTable) Then
                    resultDataTable.Dispose()
                    resultDataTable = Nothing
                End If
                If Not IsNothing(BillCodeDataTable4SummaryRpt) Then
                    BillCodeDataTable4SummaryRpt.Dispose()
                    BillCodeDataTable4SummaryRpt = Nothing
                End If
                R1 = Nothing

                'Excel clean up
                If Not IsNothing(objSheet) Then
                    objSheet = Nothing
                    NAR(objSheet)
                End If
                If Not IsNothing(objSheet2) Then
                    objSheet = Nothing
                    NAR(objSheet2)
                End If
                If Not IsNothing(objBook) Then
                    objBook.Close()
                    objBook = Nothing
                    NAR(objBook)
                End If
                If Not IsNothing(objExcel) Then
                    objExcel.Quit()
                    objExcel = Nothing
                    NAR(objExcel)
                End If
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()

            End Try
        End Sub

        '*************************************************************************************
        Public Sub CreateRepairsSummary(ByVal resultDataTable As DataTable, _
                              ByVal BillCodeDataTable4SummaryRpt As DataTable, _
                              ByVal strColBillCodesArray As ArrayList, _
                              ByRef objSheet As Excel.Worksheet)
            Dim rng As Excel.Range
            Dim Row As DataRow, Col As DataColumn
            Dim i As Integer = 0, j As Integer = 0, k As Integer = 0, m As Integer = 0, strTotalColName As String
            Dim iRowStart As Integer = 1, iColStart As Integer = 1
            Dim iCnt1 As Integer = 0, iCnt2 As Integer = 0, iCnt3 As Integer = 0, tmpRow As Integer = 0
            Dim iRow As Integer, iCol As Integer, LastColNumber As Integer = 0
            Dim strColNamesArrList As New ArrayList(), iManufModelCodeCountArrList As New ArrayList()
            Dim tmpS As String = "", tmpS2 As String = ""
            Dim dsSummary As DataSet, dtTmp As DataTable
            Dim strCosmetic As String = "TOTAL COSMETIC", strFunc As String = "TOTAL FUNCTIONAL"
            Dim iCosmeticRow As Integer, iFuncRow As Integer

            Try

                'left side title, top left title
                objSheet.Cells(iRowStart, iColStart) = "REPAIRS BREAKDOWN BY MODEL"
                objSheet.Cells(iRowStart, iColStart + 1) = "TYPE OF REPAIR" & vbLf & " BY MODEL"
                rng = objSheet.Range(objSheet.Cells(iRowStart, iColStart + 1), objSheet.Cells(iRowStart + 1, iColStart + 2))
                rng.Interior.ColorIndex = 6 : rng.MergeCells = True : rng.VerticalAlignment = Excel.Constants.xlCenter
                rng.HorizontalAlignment = Excel.Constants.xlCenter

                'Fill COS, Desc
                For i = 0 To BillCodeDataTable4SummaryRpt.Rows.Count - 1
                    iRow = iRowStart + 2 + i : iCol = iColStart + 1
                    tmpS = BillCodeDataTable4SummaryRpt.Rows(i).Item(0) 'Type
                    If tmpS.Trim.ToUpper = "COS" Then
                        objSheet.Cells(iRow, iCol) = "Cosmetic Repaires" 'BillCodeDataTable.Rows(i).Item(0) 'Type
                        objSheet.Cells(iRow, iCol + 1) = BillCodeDataTable4SummaryRpt.Rows(i).Item(2) 'Desc
                    End If
                    If tmpS.Trim.ToUpper = "FUNC" Then
                        objSheet.Cells(iRow, iCol) = strCosmetic
                        iCosmeticRow = iRow
                        rng = objSheet.Range(objSheet.Cells(iRow, iCol), objSheet.Cells(iRow, iCol + 1))
                        rng.MergeCells = True
                        rng.Interior.ColorIndex = 6 : rng.HorizontalAlignment = Excel.Constants.xlCenter

                        rng = objSheet.Range(objSheet.Cells(iRow - i, iCol), objSheet.Cells(iRow - 1, iCol))
                        rng.Orientation = 90 : rng.Font.Size = 13
                        rng.MergeCells = True : rng.VerticalAlignment = Excel.Constants.xlCenter
                        rng.HorizontalAlignment = Excel.Constants.xlCenter
                        tmpRow = iRow
                        Exit For
                    End If
                Next

                'Fill FUNC, Desc
                iRow = tmpRow + 1 : iCnt1 = 0 : iCnt2 = 0 : iCnt3 = 0
                For i = 0 To BillCodeDataTable4SummaryRpt.Rows.Count - 1
                    tmpS = BillCodeDataTable4SummaryRpt.Rows(i).Item(0) 'Type
                    If tmpS.Trim.ToUpper = "FUNC" Then 'FUNC
                        If Not IsDBNull(BillCodeDataTable4SummaryRpt.Rows(i).Item(1)) Then 'Null
                            tmpS2 = BillCodeDataTable4SummaryRpt.Rows(i).Item(1) 'Subtype
                            objSheet.Cells(iRow, iCol) = tmpS2
                            objSheet.Cells(iRow, iCol + 1) = BillCodeDataTable4SummaryRpt.Rows(i).Item(2) 'Desc
                            If tmpS2.Trim.ToUpper = "LEVEL II" Then
                                iCnt1 += 1
                            ElseIf tmpS2.Trim.ToUpper = "LEVEL III" Then
                                If iCnt1 > 1 Then
                                    rng = objSheet.Range(objSheet.Cells(iRow - iCnt1, iCol), objSheet.Cells(iRow - 1, iCol))
                                    rng.Orientation = 90 : rng.Font.Size = 13
                                    rng.MergeCells = True : rng.VerticalAlignment = Excel.Constants.xlCenter
                                    rng.HorizontalAlignment = Excel.Constants.xlCenter
                                    iCnt1 = 0 : iCnt2 += 1
                                Else
                                    iCnt2 += 1
                                End If
                            End If
                        Else 'Null 
                            objSheet.Cells(iRow, iCol + 1) = BillCodeDataTable4SummaryRpt.Rows(i).Item(2) 'Desc
                            If iCnt2 > 1 Then
                                rng = objSheet.Range(objSheet.Cells(iRow - iCnt2, iCol), objSheet.Cells(iRow - 1, iCol))
                                rng.Orientation = 90 : rng.Font.Size = 13
                                rng.MergeCells = True : rng.VerticalAlignment = Excel.Constants.xlCenter
                                rng.HorizontalAlignment = Excel.Constants.xlCenter
                                iCnt2 = 0 : iCnt3 += 1
                            Else
                                iCnt3 += 1
                            End If
                        End If 'Null
                        iRow += 1
                    End If 'FUNC
                    If i = BillCodeDataTable4SummaryRpt.Rows.Count - 1 Then
                        If iCnt3 > 1 Then
                            rng = objSheet.Range(objSheet.Cells(iRow - iCnt3, iCol), objSheet.Cells(iRow - 1, iCol))
                            rng.Orientation = 90 : rng.Font.Size = 13
                            rng.MergeCells = True : rng.VerticalAlignment = Excel.Constants.xlCenter
                            rng.HorizontalAlignment = Excel.Constants.xlCenter
                            iCnt3 = 0
                        End If

                        objSheet.Cells(iRow, iCol) = strFunc
                        iFuncRow = iRow
                        rng = objSheet.Range(objSheet.Cells(iRow, iCol), objSheet.Cells(iRow, iCol + 1))
                        rng.MergeCells = True
                        rng.Interior.ColorIndex = 6 : rng.HorizontalAlignment = Excel.Constants.xlCenter

                        '1st left title
                        rng = objSheet.Range(objSheet.Cells(iRowStart, iColStart), objSheet.Cells(iRow, iColStart))
                        rng.Orientation = 90 : rng.Font.Size = 13
                        rng.Interior.ColorIndex = 6 : rng.MergeCells = True : rng.VerticalAlignment = Excel.Constants.xlCenter
                        rng.HorizontalAlignment = Excel.Constants.xlCenter

                        'All left Titles bold and border
                        rng = objSheet.Range(objSheet.Cells(iRowStart, iColStart), objSheet.Cells(iRow, iColStart + 2))
                        rng.Font.Bold = True : rng.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                    End If
                Next
                '-----------------------------------------------------------------------------------------------------------------------------------

                'Handle Summary data----------------------------------------------------------------------------------------------------------------
                dsSummary = BuildSummaryDataSet(resultDataTable, BillCodeDataTable4SummaryRpt)

                For Each Col In BillCodeDataTable4SummaryRpt.Columns
                    strColNamesArrList.Add(Col.ColumnName)
                Next

                'fill data to Excel sheet
                iCol = iColStart + 3 : m = 0
                For Each dtTmp In dsSummary.Tables
                    Dim strManuf As String = dtTmp.TableName
                    iRow = iRowStart
                    objSheet.Cells(iRow, iCol) = strManuf
                    iManufModelCodeCountArrList.Add(0)

                    For j = 0 To dtTmp.Columns.Count - 1
                        Dim strColName As String = dtTmp.Columns(j).ColumnName
                        If Not strColNamesArrList.Contains(strColName) Then
                            objSheet.Cells(iRow + 1, iCol) = strColName
                            Dim strType_Old, strType_New As String
                            strType_Old = dtTmp.Rows(0).Item("tfb_Type")
                            k = 0
                            For i = 0 To dtTmp.Rows.Count - 1
                                strType_New = dtTmp.Rows(i).Item("tfb_Type")
                                If strType_Old.Trim.ToUpper = strType_New.Trim.ToUpper Then
                                    objSheet.Cells(iRow + i + 2 + k, iCol) = dtTmp.Rows(i).Item(strColName)
                                Else
                                    k += 1
                                    objSheet.Cells(iRow + i + 2 + k, iCol) = dtTmp.Rows(i).Item(strColName)
                                    strType_Old = strType_New
                                End If
                            Next
                            iCol += 1
                            iManufModelCodeCountArrList(m) = iManufModelCodeCountArrList(m) + 1
                        End If
                    Next

                    m += 1
                Next
                LastColNumber = iCol - 1

                'Total rows
                iCol = iColStart + 3
                For j = iCol To LastColNumber
                    iRow = iCosmeticRow
                    objSheet.Cells(iRow, j).Formula = "=SUM(" & CalExcelColLetter(j) & iRowStart + 2 & _
                                                     ":" & CalExcelColLetter(j) & iRow - 1 & ")"

                    iRow = iFuncRow
                    objSheet.Cells(iRow, j).Formula = "=SUM(" & CalExcelColLetter(j) & iCosmeticRow + 1 & _
                                                     ":" & CalExcelColLetter(j) & iRow - 1 & ")"
                Next

                '
                'Total 2 rows
                rng = objSheet.Range(objSheet.Cells(iRowStart, iColStart + 3), objSheet.Cells(iRowStart + 1, LastColNumber))
                rng.Font.Bold = True : rng.Interior.ColorIndex = 6
                rng.VerticalAlignment = Excel.Constants.xlCenter : rng.HorizontalAlignment = Excel.Constants.xlCenter

                'Total rows
                rng = objSheet.Range(objSheet.Cells(iCosmeticRow, iColStart + 3), objSheet.Cells(iCosmeticRow, LastColNumber))
                rng.Font.Bold = True : rng.Interior.ColorIndex = 6
                rng.VerticalAlignment = Excel.Constants.xlCenter : rng.HorizontalAlignment = Excel.Constants.xlRight
                rng = objSheet.Range(objSheet.Cells(iFuncRow, iColStart + 3), objSheet.Cells(iFuncRow, LastColNumber))
                rng.Font.Bold = True : rng.Interior.ColorIndex = 6
                rng.VerticalAlignment = Excel.Constants.xlCenter : rng.HorizontalAlignment = Excel.Constants.xlRight

                'Border
                rng = objSheet.Range(objSheet.Cells(iRowStart, iColStart + 3), objSheet.Cells(iFuncRow, LastColNumber))
                rng.Borders.LineStyle = Excel.XlLineStyle.xlContinuous

                'Merge top Manuf cols
                iRow = iRowStart : iCol = iColStart + 3
                For i = 0 To iManufModelCodeCountArrList.Count - 1
                    j = iManufModelCodeCountArrList(i)
                    rng = objSheet.Range(objSheet.Cells(iRow, iCol), objSheet.Cells(iRow, iCol + j - 1))
                    iCol = iCol + j
                    rng.MergeCells = True
                Next

                '-----------------------------------------------------------------------------------------------------------------------------------

                'Auto fit
                objSheet.Cells.EntireColumn.AutoFit()
                objSheet.Cells.EntireRow.AutoFit()

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*************************************************************************************
        Private Function BuildSummaryDataSet(ByVal resultDataTable As DataTable, ByVal BillCodeDataTable4SummaryRpt As DataTable) As DataSet
            'resultDataTable must be sorted by Manuf_desc and Mode Code
            Dim i, j As Integer
            Dim dsTmp As DataSet = New DataSet("ManufAndModelCode")
            Dim dsSummary As DataSet = New DataSet("Summary")
            Dim strManuf, strModelCode As String
            Dim strTfbDesc, strTfbDesc2 As String
            Dim strModelCode_Old, strModelCode_New As String
            Dim dt As New DataTable(), dtTmp As DataTable
            Dim row As DataRow, row2 As DataRow

            Try
                'Get distinct manuf_desc
                dt = SelectDistinct("myTB", resultDataTable, "Manuf_Desc")

                'Get Distinct Model Code for each Manuf, create a dataset for them
                For Each row In dt.Rows
                    Dim dt2 As DataTable
                    strManuf = row("Manuf_Desc")
                    dt2 = getFilteredDataRowsAsDataTable(resultDataTable, "Manuf_Desc", strManuf)
                    dt2 = SelectDistinct("myTB", dt2, "Model Code")
                    dt2.TableName = strManuf
                    dsTmp.Tables.Add(dt2)
                Next

                'Build summary dataset: one table one Manuf for bill codes and model codes
                For Each dtTmp In dsTmp.Tables
                    Dim iCount As Integer = 0
                    Dim tmpArrList As New ArrayList()
                    Dim dt3 As DataTable = BillCodeDataTable4SummaryRpt.Copy
                    strManuf = dtTmp.TableName
                    For Each row In dtTmp.Rows
                        strModelCode = row("Model Code")
                        dt3.Columns.Add(strModelCode, GetType(Integer))
                        tmpArrList.Add(strModelCode)
                    Next
                    dt3.TableName = strManuf

                    For Each row2 In dt3.Rows
                        strTfbDesc = row2("tfb_desc")
                        For j = 0 To tmpArrList.Count - 1
                            strModelCode = tmpArrList(j)
                            iCount = getCountYes4ManufModelBCode(resultDataTable, strManuf, strModelCode, strTfbDesc)
                            row2.BeginEdit()
                            row2(strModelCode) = iCount
                            row2.AcceptChanges()
                            row2.EndEdit()
                        Next
                    Next
                    dsSummary.Tables.Add(dt3)
                Next
                'Me.DataGrid3.DataSource = dsSummary.Tables("LG")
                dsTmp = Nothing : dt = Nothing : dtTmp = Nothing

            Catch ex As Exception
                Throw ex
            End Try

            Return dsSummary

        End Function

        '****************************************************************************************
        Private Function getCountYes4ManufModelBCode(ByVal dt As DataTable, ByVal strManufDesc As String, ByVal strModelCode As String, ByVal strBillCode As String) As Integer
            Dim strExpression As String = "Manuf_desc='" & strManufDesc & "' And [Model Code]='" & strModelCode & "'"
            Dim dRow As DataRow() = dt.Select(strExpression)
            Dim i As Integer, iCount As Integer = 0
            Dim strColName As String = strBillCode
            Dim strYesNo As String = ""

            Try
                For i = 0 To dRow.Length - 1
                    strYesNo = dRow(i)(strColName).ToString()
                    If strYesNo.ToUpper = "YES" Then
                        iCount += 1
                    End If
                Next
            Catch ex As Exception
                Throw ex
            End Try

            Return iCount
        End Function

        '****************************************************************************************
        Private Function getFilteredDataRowsAsDataTable(ByVal dt As DataTable, ByVal strFieldName As String, ByVal strFilter As String) As DataTable
            ' The following line filters the data by "strFieldName = strFilter" and returns an array of DataRow
            Dim strExpression As String = strFieldName & "='" & strFilter & "'"
            Dim dRow As DataRow() = dt.Select(strExpression)
            Dim i As Integer

            Dim dTB As New DataTable()
            Dim row As DataRow

            Try
                dTB.Columns.Add("Model Code", GetType(String))

                For i = 0 To dRow.Length - 1
                    'Response.Write("Row " & dRow(i)("Model Code").ToString())
                    row = dTB.NewRow()
                    row("Model Code") = dRow(i)("Model Code").ToString()
                    dTB.Rows.Add(row)
                Next

            Catch ex As Exception
                Throw ex
            End Try

            Return dTB

        End Function

        '****************************************************************************************
        Public Function SelectDistinct(ByVal TableName As String, ByVal SourceTable As DataTable, ByVal FieldName As String) As DataTable
            Dim dt As New DataTable(TableName)
            Dim dr As DataRow

            Try
                dt.Columns.Add(FieldName, SourceTable.Columns(FieldName).DataType)
                Dim LastValue As Object = Nothing
                For Each dr In SourceTable.[Select]("", FieldName) 'For Each dr As DataRow In SourceTable.[Select]("", FieldName)
                    If LastValue Is Nothing OrElse Not (ColumnEqual(LastValue, dr(FieldName))) Then
                        LastValue = dr(FieldName)
                        dt.Rows.Add(New Object() {LastValue})
                    End If
                Next

            Catch ex As Exception
                Throw ex
            End Try

            Return dt

        End Function

        '****************************************************************************************
        Private Function ColumnEqual(ByVal A As Object, ByVal B As Object) As Boolean
            ' Compares two values to see if they are equal. Also compares DBNULL.Value.
            ' Note: If your DataTable contains object fields, then you must extend this
            ' function to handle them in a meaningful way if you intend to group on them.
            If A Is DBNull.Value AndAlso B Is DBNull.Value Then
                '  both are DBNull.Value
                Return True
            End If

            If A Is DBNull.Value OrElse B Is DBNull.Value Then
                '  only one is DBNull.Value
                Return False
            End If

            Return (A.Equals(B))
            ' value type standard comparison
        End Function

        '****************************************************************************************
        Public Function CalExcelColLetter(ByVal iColNo As Integer) As String
            Const iLetterADecNo As Integer = 65
            Const iTotalAlpha As Integer = 26
            Dim strExcelColLetter As String = ""
            Dim iFirstLetter As Integer = 0
            Dim iSecondLeter As Integer = 0
            Dim iTemp As Integer = 0

            Try
                If iColNo < 1 Then Return ""

                If iColNo <= iTotalAlpha Then
                    strExcelColLetter = Chr(iColNo + iLetterADecNo - 1)
                Else
                    iFirstLetter = Math.Floor(iColNo / 26)
                    iSecondLeter = iColNo Mod 26
                    If iSecondLeter = 0 Then
                        iSecondLeter = iTotalAlpha
                        iFirstLetter -= 1
                    End If
                    strExcelColLetter = Chr(iFirstLetter + iLetterADecNo - 1) & Chr(iSecondLeter + iLetterADecNo - 1)
                End If

                Return strExcelColLetter
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************
        Private Shared Sub NAR(ByVal o As Object)
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
            Catch
            Finally
                o = Nothing
            End Try
        End Sub

        '****************************************************************************************
        Public Function CalManufWrtyByWHRecDate_ZTE(ByVal iDeviceID As Integer, ByVal iOneDigitYr As Integer, ByVal iDayOfYear As Integer, ByVal dteRecDate As DateTime) As Boolean
            Dim objWrty As New UnderWarrantyNET1.ZTE()
            Dim R1 As DataRow
            Dim strsql As String = ""
            Dim i As Integer

            Try
                CalManufWrtyByWHRecDate_ZTE = False
                R1 = objWrty.WStatusCoverageByDate(iOneDigitYr, iDayOfYear, dteRecDate)
                strsql = "Update edi.titem SET WrtyStatus_ByWHRecDate = " & R1("WarrantyStatus") & ", LastDateInWrty= '" & CDate(R1("WarrantyCoverageByDate")).ToString("yyyy-MM-dd") & "' WHERE Device_ID = " & iDeviceID
                i = Me._objDataProc.ExecuteNonQuery(strsql)
                If i = 0 Then MessageBox.Show("System has failed to update Warranty Status.", "CalManufWrtyByWHRecDate_ZTE", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                CalManufWrtyByWHRecDate_ZTE = True
            Catch ex As Exception
                Throw ex
            Finally
                objWrty = Nothing
            End Try
        End Function

        '*****************************************************************************************************************************************
        Public Function LoadTFProducionPlanExcelData(ByVal strFileLocAndName As String) As DataTable
            Dim strHeader() As String = New String() {"Model", "Quantity", "PlanDate"}
            Dim xlApp As New Excel.Application()
            Dim xlWorkBook As Excel.Workbook = Nothing
            Dim xlWorkSheet1 As Excel.Worksheet = Nothing
            Dim HeaderNames As New ArrayList()

            Dim dt As New DataTable()
            Dim R1 As DataRow

            Dim strVal As String = ""
            Dim booHasFreq As Boolean = False
            Dim i As Integer, j As Integer, iRowsCnt, iColCnt, iModelID, iQty As Integer

            Dim dateValue As Date
            Dim dateTimeFormats As DateTimeFormatInfo

            Try

                If File.Exists(strFileLocAndName) Then

                    xlWorkBook = xlApp.Workbooks.Open(strFileLocAndName)

                    xlWorkSheet1 = xlWorkBook.Worksheets(1)
                    xlWorkSheet1.Select()
                    iRowsCnt = xlWorkBook.ActiveSheet.UsedRange.Rows.Count()
                    iColCnt = xlWorkBook.ActiveSheet.UsedRange.Columns.Count()

                    If iColCnt < strHeader.Length Then Throw New Exception("Excel does not contain enough column.")

                    'Check Header
                    For i = 1 To strHeader.Length '3 columns
                        If Microsoft.VisualBasic.IsDBNull(xlWorkSheet1.Cells(1, i).value) Then '.Range("A" & i).Value
                            Exit For
                        ElseIf Microsoft.VisualBasic.IsNothing(xlWorkSheet1.Cells(1, i).value) Then
                            Exit For
                        ElseIf xlWorkSheet1.Cells(1, i).value Is "" Or xlWorkSheet1.Cells(1, i).value Is Nothing Then
                            Exit For
                        Else
                            strVal = xlWorkSheet1.Cells(1, i).value.ToString.Trim()
                            Select Case i
                                Case 1
                                    If strVal.ToLower <> "model" Then Throw New Exception("Header of Column A must be 'Model'.")
                                Case 2
                                    If strVal.ToLower <> "quantity" Then Throw New Exception("Header of Column B must be 'Quantity'.")
                                Case 3
                                    If strVal.ToLower <> "plandate" Then Throw New Exception("Header of Column C must be 'PlanDate.")
                                    'Case Else
                                    '    Throw New Exception("Invalid colunm name " & strVal & ".")
                            End Select
                        End If
                    Next i

                    'Create datattable 
                    dt.Columns.Add(New DataColumn("RowNo", GetType(Integer)))
                    dt.Columns.Add(New DataColumn("Model_ID", GetType(Integer)))
                    dt.Columns.Add(strHeader(0), GetType(String)) 'Model
                    dt.Columns.Add(strHeader(1), GetType(Integer)) 'Quantity
                    dt.Columns.Add(strHeader(2), GetType(String)) 'PlanDate
                    dt.Columns.Add(New DataColumn("IsValid", GetType(String)))
                    dt.Columns.Add(New DataColumn("Status", GetType(String)))

                    'Get Data
                    i = 2
                    While True
                        R1 = dt.NewRow

                        If Microsoft.VisualBasic.IsDBNull(xlWorkSheet1.Cells(i, 1).value) _
                           OrElse Microsoft.VisualBasic.IsNothing(xlWorkSheet1.Cells(i, 1).value) _
                           OrElse xlWorkSheet1.Cells(i, 1).value Is "" Or xlWorkSheet1.Cells(i, 1).value Is Nothing Then Exit While

                        For j = 1 To 3
                            If Microsoft.VisualBasic.IsDBNull(xlWorkSheet1.Cells(i, j).value) _
                               OrElse Microsoft.VisualBasic.IsNothing(xlWorkSheet1.Cells(i, j).value) _
                               OrElse xlWorkSheet1.Cells(i, j).value Is "" Or xlWorkSheet1.Cells(i, j).value Is Nothing Then Throw New Exception("Column " & strHeader(j - 1) & " can't not be blank.")

                            strVal = xlWorkSheet1.Cells(i, j).value.ToString.Trim()
                            Select Case j
                                Case 1 'Model
                                    iModelID = Me.GetModelID(strVal)
                                    If iModelID > 0 Then R1("IsValid") = "Yes" Else R1("IsValid") = "No"
                                    R1(strHeader(0)) = strVal
                                    R1("Model_ID") = iModelID
                                Case 2 'Quantity
                                    If IsNumeric(strVal) Then
                                        iQty = Convert.ToInt32(strVal)
                                        R1(strHeader(1)) = iQty
                                    Else
                                        R1("IsValid") = "No"
                                    End If
                                Case 3 'PlanDate
                                    If IsDate(strVal) Then
                                        R1(strHeader(2)) = Format(CDate(strVal), "yyyy-MM-dd")
                                        'DateString = Format(CDate(strVal), "yyyy-MM-dd")
                                        dateValue = CDate(strVal) ' Date.Parse(DateString, CultureInfo.InvariantCulture)
                                        If Not dateValue.ToString("dddd").ToUpper = "MONDAY" Then
                                            R1("IsValid") = "No"
                                        ElseIf dateValue <= Now.Date Then
                                            R1("IsValid") = "No"
                                        End If
                                    Else
                                        R1("IsValid") = "No"
                                    End If
                            End Select
                        Next j

                        R1("RowNo") = i - 1
                        dt.Rows.Add(R1)
                        i += 1
                    End While

                Else
                    Throw New Exception("Can't find file.")
                End If

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(xlWorkSheet1) Then PSS.Data.Buisness.Generic.NAR(xlWorkSheet1)
                If Not IsNothing(xlWorkBook) Then
                    xlWorkBook.Close(False) : PSS.Data.Buisness.Generic.NAR(xlWorkBook)
                End If
                If Not IsNothing(xlApp) Then
                    xlApp.Quit() : PSS.Data.Buisness.Generic.NAR(xlApp)
                End If

                GC.Collect() : GC.WaitForPendingFinalizers()
                GC.Collect() : GC.WaitForPendingFinalizers()
            End Try
        End Function

        '*****************************************************************************************************************************************
        Public Function GetModelID(ByVal strModelDesc As String) As Integer
            Dim strSql As String = ""

            Try
                strSql = "SELECT Model_ID FROM tmodel WHERE Model_Desc = '" & strModelDesc & "'"
                Return Me._objDataProc.GetIntValue(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************************************************************************************
        Public Function IsTFProductionPlanDataExist(ByVal iModel_ID As Integer, ByVal strDate As String) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT * FROM cogs.ttf_wkly_plan WHERE Model_ID = " & iModel_ID & Environment.NewLine
                strSql &= " AND wklyplan_dt ='" & strDate & "';" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************************************************************************************
        Public Function InsertUpdateTFProductionPlanData(ByVal iModel_ID As Integer, _
                                                         ByVal iQty As Integer, _
                                                         ByVal strDate As String, _
                                                         ByVal bAllowUpdate As Boolean, _
                                                         ByRef iInsertNo As Integer, _
                                                         ByRef iUpdateNo As Integer) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim i As Integer = 0

            Try
                strSql = "SELECT * FROM cogs.ttf_wkly_plan WHERE Model_ID = " & iModel_ID & Environment.NewLine
                strSql &= " AND wklyplan_dt ='" & strDate & "';" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    If bAllowUpdate Then
                        strSql = "UPDATE cogs.ttf_wkly_plan SET Qty = " & iQty & Environment.NewLine
                        strSql &= " WHERE Model_ID = " & iModel_ID & " AND wklyplan_dt ='" & strDate & "';" & Environment.NewLine
                        i = Me._objDataProc.ExecuteNonQuery(strSql)
                        If i > 0 Then
                            iUpdateNo += 1
                        End If
                    End If
                    Return i
                Else
                    strSql = "INSERT INTO cogs.ttf_wkly_plan (Model_ID,qty,wklyplan_dt)" & Environment.NewLine
                    strSql &= " VALUES (" & iModel_ID & "," & iQty & ",'" & strDate & "');" & Environment.NewLine
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                    If i > 0 Then
                        iInsertNo += 1
                    End If
                    Return i
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ''*****************************************************************************************************************************************
        'Public Function InsertTFProductionPlanData(ByVal iModel_ID As Integer, ByVal iQty As Integer, ByVal strDate As String) As Integer
        '    Dim strSql As String = ""
        '    Dim dt As DataTable

        '    Try
        '        strSql = "INSERT INTO cogs.ttf_wkly_plan (Model_ID,qty,wklyplan_dt)" & Environment.NewLine
        '        strSql &= " VALUES (" & iModel_ID & "," & iQty & ",'" & strDate & "');" & Environment.NewLine
        '        Return Me._objDataProc.ExecuteNonQuery(strSql)
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function

        ''*****************************************************************************************************************************************
        'Public Function UpdateTFProductionPlanData2(ByVal iModel_ID As Integer, ByVal iQty As Integer, ByVal strDate As String) As Integer
        '    Dim strSql As String = ""
        '    Dim dt As DataTable

        '    Try
        '        strSql = "UPDATE cogs.ttf_wkly_plan SET Qty = " & iQty & Environment.NewLine
        '        strSql &= " WHERE Model_ID = " & iModel_ID & " AND wklyplan_dt ='" & strDate & "';" & Environment.NewLine
        '        Return Me._objDataProc.ExecuteNonQuery(strSql)
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function

        '*****************************************************************************************************************************************
        Public Function GetTFProductionPlanData(ByVal strDate As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim i As Integer = 0

            Try
                strSql = "SELECT 0 AS 'RowNo',A.Model_ID,B.Model_Desc AS 'Model'" & Environment.NewLine
                strSql &= " ,A.Qty as 'Quantity',A.wklyplan_dt AS 'PlanDate'" & Environment.NewLine
                strSql &= " ,wklyplan_id" & Environment.NewLine
                strSql &= " FROM cogs.ttf_wkly_plan A" & Environment.NewLine
                strSql &= " LEFT JOIN production.tmodel B ON A.Model_ID=B.Model_ID" & Environment.NewLine
                strSql &= " WHERE wklyplan_dt ='" & strDate & "';" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************************************************************************************
        Public Function UpdateTFProductionPlanData(ByVal iwklyplan_id As Integer, ByVal iQty As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "UPDATE cogs.ttf_wkly_plan SET Qty = " & iQty & Environment.NewLine
                strSql &= " WHERE wklyplan_id = " & iwklyplan_id & ";" & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************************************************************************************
        Public Function DeleteTFProductionPlanData(ByVal strwklyplan_ids As String) As Integer
            Dim strSql As String = ""

            Try
                strSql = "DELETE FROM cogs.ttf_wkly_plan" & Environment.NewLine
                strSql &= " WHERE wklyplan_id in (" & strwklyplan_ids & ");" & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '****************************************************************************************


    End Class

End Namespace