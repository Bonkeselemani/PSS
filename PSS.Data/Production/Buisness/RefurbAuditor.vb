Option Explicit On 

Namespace Buisness
    Public Class RefurbAuditor
        Private objMisc As Production.Misc

        '***************************************************
        'Get Parts Consumption
        '***************************************************
        Public Function GetPartsConsumption(ByVal iModelID As Integer, _
                                            ByVal iGroup_ID As Integer, _
                                            ByVal iCC_ID As Integer, _
                                            ByVal iBillerEmpNo As Integer, _
                                            ByVal strStartDt As String, _
                                            ByVal strEndDt As String) As DataTable

            Dim strsql As String = ""
            Dim dt1, dt2 As DataTable
            Dim R1, R2, drNewRow As DataRow
            Dim i As Integer = 0

            Try
                '********************************************
                'Get Consumed
                '********************************************
                strsql = "Select " & Environment.NewLine
                strsql &= "tdevice.model_id, " & Environment.NewLine
                strsql &= "tmodel.model_desc as 'Model', " & Environment.NewLine
                strsql &= "lpsprice.PSPrice_ID, " & Environment.NewLine
                strsql &= "lpsprice.PSPrice_Number as 'Part #', " & Environment.NewLine
                strsql &= "lpsprice.PSPrice_Desc as 'Part', " & Environment.NewLine
                strsql &= "Count(*) as 'Consumed', " & Environment.NewLine
                strsql &= "0 as 'Scrap' " & Environment.NewLine
                strsql &= "from tdevice " & Environment.NewLine
                strsql &= "inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & Environment.NewLine
                strsql &= "inner join tmodel on tdevice.model_id = tmodel.model_id " & Environment.NewLine
                strsql &= "inner join tdevicebill on tdevice.Device_ID = tdevicebill.Device_ID " & Environment.NewLine
                strsql &= "inner join lbillcodes on tdevicebill.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                strsql &= "inner join tpsmap on tdevicebill.BillCode_ID = tpsmap.BillCode_ID and tdevice.Model_ID = tpsmap.Model_ID " & Environment.NewLine
                strsql &= "inner join lpsprice on tpsmap.PSPrice_ID = lpsprice.PSPrice_ID " & Environment.NewLine
                strsql &= "where tworkorder.Group_ID = " & iGroup_ID & Environment.NewLine
                strsql &= "AND tdevice.Model_ID = " & iModelID & Environment.NewLine
                If iCC_ID > 0 Then strsql &= "AND tdevice.cc_id = " & iCC_ID & Environment.NewLine
                If iBillerEmpNo > 0 Then strsql &= "AND tdevicebill.User_ID = " & iBillerEmpNo & " " & Environment.NewLine
                strsql &= "AND lbillcodes.billtype_id = 2 " & Environment.NewLine
                strsql &= "AND tdevicebill.Date_Rec BETWEEN '" & strStartDt & "' AND '" & strEndDt & "' " & Environment.NewLine
                strsql &= "Group by tdevice.model_id, PSPrice_Number Order by Model, 'Part';"

                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable
                '********************************************
                'Get Scrap 
                '********************************************
                strsql = "Select tscrap.model_id, " & Environment.NewLine
                strsql &= "model_desc as 'Model', " & Environment.NewLine
                strsql &= "lpsprice.PSPrice_ID, " & Environment.NewLine
                strsql &= "tscrap.PSPrice_Number as 'Part #',  " & Environment.NewLine
                strsql &= "lpsprice.PSPrice_Desc as 'Part', " & Environment.NewLine
                strsql &= "sum(tscrap.tscrap_qty) as 'Scrap' " & Environment.NewLine
                strsql &= "from tscrap " & Environment.NewLine
                strsql &= "inner join tmodel on tscrap.model_id = tmodel.model_id " & Environment.NewLine
                strsql &= "INNER JOIN tdevice ON tscrap.Device_ID = tdevice.Device_ID " & Environment.NewLine
                strsql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                strsql &= "inner join lpsprice on tscrap.psprice_number = lpsprice.PSPrice_Number " & Environment.NewLine
                strsql &= "WHERE tscrap.WorkDate BETWEEN '" & strStartDt & "' and '" & strEndDt & "' " & Environment.NewLine
                strsql &= "AND tdevice.Model_ID = " & iModelID & Environment.NewLine
                strsql &= "AND (tdevice.Ship_ID is null or tdevice.Ship_ID <> 9999919 ) " & Environment.NewLine
                strsql &= "AND tworkorder.Group_ID = " & iGroup_ID & Environment.NewLine
                If iCC_ID > 0 Then strsql &= "AND tdevice.cc_id = " & iCC_ID & Environment.NewLine
                If iBillerEmpNo > 0 Then strsql &= "AND tscrap.empnum = " & iBillerEmpNo & " " & Environment.NewLine
                strsql &= "group by tscrap.Model_ID, 'Part #' Order by Model, 'Part';"

                objMisc._SQL = strsql
                dt2 = objMisc.GetDataTable
                '********************************************
                If dt2.Rows.Count > 0 Then
                    For Each R2 In dt2.Rows
                        For Each R1 In dt1.Rows
                            If R1("model_id") = R2("model_id") And R1("Part #") = R2("Part #") Then
                                R1.BeginEdit()
                                R1("Scrap") = R2("Scrap")
                                R1.EndEdit()
                                i = 1
                                Exit For
                            End If
                        Next R1
                        If i = 0 Then
                            drNewRow = Nothing
                            drNewRow = dt1.NewRow
                            drNewRow("model_id") = R2("model_id")
                            drNewRow("Model") = R2("Model")
                            drNewRow("PSPrice_ID") = R2("PSPrice_ID")
                            drNewRow("Part #") = R2("Part #")
                            drNewRow("Part") = R2("Part")
                            drNewRow("Scrap") = R2("Scrap")
                            dt1.Rows.Add(drNewRow)
                        End If

                        dt1.AcceptChanges()
                    Next R2

                End If

                dt1.AcceptChanges()

                Return dt1

            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt2) Then
                    dt2.Dispose()
                    dt2 = Nothing
                End If
            End Try
        End Function

        ''***************************************************
        ''Get Parts Consumption Summary by model for refurber
        ''***************************************************
        'Public Function GetPartsInfo(ByVal iModelID As Integer, _
        '                            ByVal iUserID As Integer, _
        '                            ByVal iEmployeeNo As Integer, _
        '                            ByVal strStartDt As String, _
        '                            ByVal strEndDt As String, _
        '                            ByVal iCustomModelGroup As Integer, _
        '                            ByVal strGroupTogether As String) _
        '                            As DataTable

        '    Dim strsql As String = ""
        '    Dim dt1, dt2 As DataTable
        '    Dim R1, R2, drNewRow As DataRow
        '    Dim i As Integer = 0

        '    Try
        '        '********************************************
        '        'Get Consumed
        '        '********************************************
        '        strsql = "Select " & Environment.NewLine
        '        strsql &= "tdevice.model_id, " & Environment.NewLine
        '        strsql &= "tmodel.model_desc as 'Model', " & Environment.NewLine
        '        strsql &= "lpsprice.PSPrice_ID, " & Environment.NewLine
        '        strsql &= "lpsprice.PSPrice_Number as 'Part #', " & Environment.NewLine
        '        strsql &= "lpsprice.PSPrice_Desc as 'Part', " & Environment.NewLine
        '        strsql &= "Count(*) as 'Consumed', " & Environment.NewLine
        '        strsql &= "0 as 'Scrap' " & Environment.NewLine
        '        strsql &= "from tcellopt " & Environment.NewLine
        '        strsql &= "inner join tdevice on tcellopt.Device_ID = tdevice.Device_ID " & Environment.NewLine
        '        strsql &= "inner join tmodel on tdevice.model_id = tmodel.model_id " & Environment.NewLine
        '        strsql &= "inner join tdevicebill on tdevice.Device_ID = tdevicebill.Device_ID " & Environment.NewLine
        '        strsql &= "inner join lbillcodes on tdevicebill.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
        '        strsql &= "inner join tpsmap on tdevicebill.BillCode_ID = tpsmap.BillCode_ID and tdevice.Model_ID = tpsmap.Model_ID " & Environment.NewLine
        '        strsql &= "inner join lpsprice on tpsmap.PSPrice_ID = lpsprice.PSPrice_ID " & Environment.NewLine

        '        strsql &= "where " & Environment.NewLine
        '        strsql &= "tcellopt.CellOpt_RefurbCompleteUserID = " & iUserID & " and " & Environment.NewLine
        '        strsql &= "lbillcodes.billtype_id = 2 and " & Environment.NewLine
        '        strsql &= "tcellopt.CellOpt_RefurbCompleteWorkDt >= '" & strStartDt & "' and " & Environment.NewLine
        '        strsql &= "tcellopt.CellOpt_RefurbCompleteWorkDt <= '" & strEndDt & "' and " & Environment.NewLine
        '        If Trim(strGroupTogether) = "" Then
        '            strsql &= "tdevice.model_id = " & iModelID & " " & Environment.NewLine
        '        ElseIf Trim(strGroupTogether) = "1" Then
        '            strsql &= "tmodel.CustomModelGroup = " & iCustomModelGroup & " " & Environment.NewLine
        '        End If

        '        strsql &= "Group by tdevice.model_id, PSPrice_Number Order by Model, 'Part';"

        '        objMisc._SQL = strsql
        '        dt1 = objMisc.GetDataTable
        '        '********************************************
        '        'Get Scrap 
        '        '********************************************
        '        strsql = "Select tscrap.model_id, " & Environment.NewLine
        '        strsql &= "model_desc as 'Model', " & Environment.NewLine
        '        strsql &= "lpsprice.PSPrice_ID, " & Environment.NewLine
        '        strsql &= "tscrap.PSPrice_Number as 'Part #',  " & Environment.NewLine
        '        strsql &= "lpsprice.PSPrice_Desc as 'Part', " & Environment.NewLine
        '        strsql &= "sum(tscrap.tscrap_qty) as 'Scrap' " & Environment.NewLine
        '        strsql &= "from tscrap " & Environment.NewLine
        '        strsql &= "inner join tmodel on tscrap.model_id = tmodel.model_id " & Environment.NewLine
        '        strsql &= "inner join lpsprice on tscrap.psprice_number = lpsprice.PSPrice_Number " & Environment.NewLine
        '        strsql &= "where workdate >= '" & strStartDt & "' and " & Environment.NewLine
        '        strsql &= "workdate <= '" & strEndDt & "' and " & Environment.NewLine
        '        strsql &= "empnum = " & iEmployeeNo & " and " & Environment.NewLine

        '        If Trim(strGroupTogether) = "" Then
        '            strsql &= "tscrap.model_id = " & iModelID & " " & Environment.NewLine
        '        ElseIf Trim(strGroupTogether) = "1" Then
        '            strsql &= "tmodel.CustomModelGroup = " & iCustomModelGroup & " " & Environment.NewLine
        '        End If
        '        strsql &= "group by tscrap.Model_ID, 'Part #' Order by Model, 'Part';"

        '        objMisc._SQL = strsql
        '        dt2 = objMisc.GetDataTable
        '        '********************************************
        '        If dt2.Rows.Count > 0 Then
        '            For Each R2 In dt2.Rows
        '                For Each R1 In dt1.Rows
        '                    If R1("model_id") = R2("model_id") And R1("Part #") = R2("Part #") Then
        '                        R1.BeginEdit()
        '                        R1("Scrap") = R2("Scrap")
        '                        R1.EndEdit()
        '                        i = 1
        '                        Exit For
        '                    End If
        '                Next R1
        '                If i = 0 Then
        '                    drNewRow = Nothing
        '                    drNewRow = dt1.NewRow
        '                    drNewRow("model_id") = R2("model_id")
        '                    drNewRow("Model") = R2("Model")
        '                    drNewRow("PSPrice_ID") = R2("PSPrice_ID")
        '                    drNewRow("Part #") = R2("Part #")
        '                    drNewRow("Part") = R2("Part")
        '                    drNewRow("Scrap") = R2("Scrap")
        '                    dt1.Rows.Add(drNewRow)
        '                End If

        '                dt1.AcceptChanges()
        '            Next R2

        '        End If



        '        'For Each R1 In dt1.Rows
        '        '    If Not IsDBNull(R1("Part #")) And Not IsDBNull(R1("model_id")) Then
        '        '        strsql = ""
        '        '        strsql = "select SUM(tscrap_qty) as 'Scrap' " & Environment.NewLine
        '        '        strsql &= "from tscrap " & Environment.NewLine
        '        '        strsql &= "where empnum = " & iRefurbEmpNo & " and " & Environment.NewLine
        '        '        strsql &= "workdate >= '" & strStartDt & "' and " & Environment.NewLine
        '        '        strsql &= "workdate <= '" & strEndDt & "' and " & Environment.NewLine
        '        '        strsql &= "tscrap.model_id = " & R1("model_id") & " and " & Environment.NewLine
        '        '        strsql &= "PSPrice_Number = '" & Trim(R1("Part #")) & "';"

        '        '        If Not IsNothing(dt2) Then
        '        '            dt2.Dispose()
        '        '            dt2 = Nothing
        '        '        End If
        '        '        objMisc._SQL = strsql
        '        '        dt2 = objMisc.GetDataTable

        '        '        For Each R2 In dt2.Rows
        '        '            R1.BeginEdit()
        '        '            R1("Scrap") = R2("Scrap")
        '        '            R1.EndEdit()
        '        '            Exit For
        '        '        Next R2
        '        '    Else
        '        '        Throw New Exception("'Model' or 'Part Number' could not be determined.")
        '        '    End If
        '        'Next R1
        '        dt1.AcceptChanges()

        '        Return dt1

        '    Catch ex As Exception
        '        Throw ex
        '    Finally
        '        If Not IsNothing(dt2) Then
        '            dt2.Dispose()
        '            dt2 = Nothing
        '        End If
        '    End Try
        'End Function

        '***************************************************
        'Load Users
        '***************************************************
        Public Function LoadUsers() As DataTable
            Dim dt As DataTable
            Try
                objMisc._SQL = "select user_id, user_fullname from security.tusers where EmployeeNo > 0 and user_inactive = 0 order by user_fullname;"
                dt = objMisc.GetDataTable
                InsertEmptyRow(dt, , "user_id", "user_fullname", , , "-- Select --")
                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************
        'Load Product
        '***************************************************
        Public Function LoadGroups() As DataTable
            Dim dt As DataTable
            Try
                objMisc._SQL = "Select Group_ID, Group_Desc from lgroups where MasterGroup = 1 order by Group_Desc;"
                dt = objMisc.GetDataTable
                InsertEmptyRow(dt, , "Group_ID", "Group_Desc", , , "-- Select --")
                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************
        'Load Product
        '***************************************************
        Public Function LoadProds() As DataTable
            Dim dt As DataTable
            Try
                objMisc._SQL = "Select Prod_ID, Prod_Desc from lproduct where Prod_Inactive = 0 order by Prod_Desc;"
                dt = objMisc.GetDataTable
                InsertEmptyRow(dt, , "Prod_ID", "Prod_Desc", , , "-- Select --")
                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************
        'Load Cell Lines
        '***************************************************
        Public Function LoadCellLines(ByVal iGroup_ID As Integer) As DataTable
            Dim dt As DataTable
            Try
                objMisc._SQL = "select cc_id, cc_desc from tcostcenter where group_id = " & iGroup_ID & " and cc_inactive = 0 order by cc_desc;"
                dt = objMisc.GetDataTable
                InsertEmptyRow(dt, , "cc_id", "cc_desc", , , "-- Select --")
                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************
        'Get Models Refurbed by an user
        '***************************************************
        Public Function GetInfoOnModelsRefurbedByUser(ByVal iUserID As Integer, _
                                                    ByVal strStartDt As String, _
                                                    ByVal strEndDt As String) _
                                                    As DataTable
            Dim strsql As String = ""

            Try
                strsql = "Select tmodel.Model_ID, " & Environment.NewLine
                strsql &= "tmodel.Model_Desc as Model, " & Environment.NewLine
                strsql &= "tmodel.CustomModelGroup, " & Environment.NewLine
                strsql &= "count(*) as Quantity, " & Environment.NewLine
                strsql &= "tmodelcustomgroup.GroupTogether " & Environment.NewLine

                strsql &= "from tcellopt " & Environment.NewLine
                strsql &= "inner join tdevice on tcellopt.Device_ID = tdevice.Device_ID " & Environment.NewLine
                strsql &= "inner join tmodel on tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strsql &= "left outer join tmodelcustomgroup on tmodel.CustomModelGroup = tmodelcustomgroup.CustomModelGroup " & Environment.NewLine

                strsql &= "where " & Environment.NewLine
                strsql &= "tcellopt.CellOpt_RefurbCompleteUserID = " & iUserID & " and " & Environment.NewLine
                strsql &= "tcellopt.CellOpt_RefurbCompleteWorkDt >= '" & strStartDt & "' and " & Environment.NewLine
                strsql &= "tcellopt.CellOpt_RefurbCompleteWorkDt <= '" & strEndDt & "' " & Environment.NewLine

                strsql &= "Group by tmodel.Model_ID Order by Model;"

                objMisc._SQL = strsql
                Return objMisc.GetDataTable

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************
        'Get Models and Qty by bill date and cell line
        '***************************************************
        Public Function GetBillingModelsQty(ByVal iGroup_ID As Integer, _
                                          ByVal icc_id As Integer, _
                                          ByVal iUsrID As Integer, _
                                          ByVal strStartDt As String, _
                                          ByVal strEndDt As String, _
                                          ByRef iOneDayTotalQty As Integer, _
                                          ByRef iOneWeekTotalQty As Integer, _
                                          ByRef decOneDayTotalCost As Decimal, _
                                          ByRef decWeekTotalCost As Decimal) As DataTable
            Dim strsql As String = ""
            Dim dt1, dt2 As DataTable
            Dim R1, R2 As DataRow
            Dim iModel_ID As Integer = 0
            Dim strDeviceID As String = ""

            Try
                strsql = "Select distinct tdevice.Device_ID, tmodel.Model_ID" & Environment.NewLine
                strsql &= ", tmodel.Model_Desc as Model, 0 as Qty, 0.00 as 'Avg Parts Cost(Fr Date)', 0.00 as 'Avg Parts Cost(Week of Fr)'" & Environment.NewLine
                strsql &= "from tdevice " & Environment.NewLine
                strsql &= "inner join tmodel on tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strsql &= "inner join tworkorder on tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                strsql &= "inner join tdevicebill on tdevice.Device_ID = tdevicebill.Device_ID " & Environment.NewLine
                strsql &= "inner join lbillcodes on tdevicebill.Billcode_ID = lbillcodes.Billcode_ID " & Environment.NewLine
                strsql &= "where lbillcodes.BillCode_Rule not in (1,2,8,9) " & Environment.NewLine
                strsql &= "AND tworkorder.Group_ID = " & iGroup_ID & Environment.NewLine
                If icc_id > 0 Then
                    strsql &= "AND tdevice.cc_id = " & icc_id & " " & Environment.NewLine
                End If
                If iUsrID > 0 Then
                    strsql &= "AND tdevicebill.User_ID = " & iUsrID & " " & Environment.NewLine
                End If
                strsql &= "AND tdevicebill.Date_Rec BETWEEN '" & strStartDt & "' AND '" & strEndDt & "' " & Environment.NewLine
                strsql &= "Order by Model;"

                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable

                dt2 = New DataTable()
                dt2 = dt1.Clone

                For Each R1 In dt1.Rows
                    If iModel_ID <> R1("Model_ID") Then
                        R2 = dt2.NewRow
                        R2("Model_ID") = R1("Model_ID")
                        R2("Model") = R1("Model")
                        R2("Qty") = dt1.Select("Model_ID = " & R1("Model_ID")).Length
                        R2("Avg Parts Cost(Fr Date)") = AvgPartsCost.GetAvgPartsCost(R1("Model_ID"), strStartDt, True, iGroup_ID, icc_id, iUsrID, iOneDayTotalQty, decOneDayTotalCost)
                        R2("Avg Parts Cost(Week of Fr)") = AvgPartsCost.GetAvgPartsCost(R1("Model_ID"), strStartDt, False, iGroup_ID, icc_id, iUsrID, iOneWeekTotalQty, decWeekTotalCost)
                        dt2.Rows.Add(R2)
                        dt2.AcceptChanges()
                        R2 = Nothing
                    End If
                    iModel_ID = R1("Model_ID")
                Next R1

                dt2.Columns.Remove("Device_ID")
                dt2.AcceptChanges()

                Return dt2
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************
        'Insert an empty row into the datatable
        '***************************************************
        Private Function InsertEmptyRow(ByRef dt As DataTable, _
                                        Optional ByVal iEmptyRowValue As Integer = 0, _
                                        Optional ByVal strFiledName1 As String = "", _
                                        Optional ByVal strFieldName2 As String = "", _
                                        Optional ByVal strFieldName3 As String = "", _
                                        Optional ByVal strFieldName4 As String = "", _
                                        Optional ByVal strEmptyRowDisplay As String = "")

            Dim R1 As DataRow
            Try
                R1 = dt.NewRow
                If strFiledName1 <> "" Then
                    R1(strFiledName1) = iEmptyRowValue
                End If
                If strFieldName2 <> "" Then
                    R1(strFieldName2) = strEmptyRowDisplay
                End If
                If strFieldName3 <> "" Then
                    R1(strFieldName3) = strEmptyRowDisplay
                End If

                dt.Rows.Add(R1)
            Catch ex As Exception
                Throw New Exception("Buisness.QC.InsertEmptyRow(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                R1 = Nothing
            End Try
        End Function
        Public Sub New()
            objMisc = New Production.Misc()
        End Sub

        Protected Overrides Sub Finalize()
            objMisc = Nothing
            MyBase.Finalize()
        End Sub
    End Class
End Namespace

