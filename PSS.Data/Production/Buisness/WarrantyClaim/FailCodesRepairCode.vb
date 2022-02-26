Option Explicit On 

Namespace Buisness.WarrantyClaim
    Public Class FailCodesRepairCodes

        '**************************************************************
        Public Shared Function SaveReflowPart(ByVal iDeviceID As Integer, _
                                              ByVal iBillcodeID As Integer, _
                                              ByVal iFailID As Integer, _
                                              ByVal iRepID As Integer, _
                                              ByVal iUserID As Integer) As Integer
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim i As Integer = 0

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT * " & Environment.NewLine
                strSql &= "FROM treflowpart  " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "AND Billcode_ID = " & iBillcodeID & Environment.NewLine

                dt = objDataProc.GetDataTable(strSql)

                strSql = ""
                If dt.Rows.Count > 0 Then
                    If IsDBNull(dt.Rows(0)("Fail_ID")) Or IsDBNull(dt.Rows(0)("Repair_ID")) Then
                        strSql = "UPDATE treflowpart" & Environment.NewLine
                        strSql &= "SET Fail_ID = " & iFailID & Environment.NewLine
                        strSql &= ", Repair_ID = " & iRepID & Environment.NewLine
                        strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                        strSql &= "AND Billcode_ID = " & iBillcodeID & Environment.NewLine
                    ElseIf dt.Rows(0)("Fail_ID") = 0 Or dt.Rows(0)("Repair_ID") = 0 Or dt.Rows(0)("Fail_ID") <> iFailID Or dt.Rows(0)("Repair_ID") <> iRepID Then
                        strSql = "UPDATE treflowpart" & Environment.NewLine
                        strSql &= "SET Fail_ID = " & iFailID & Environment.NewLine
                        strSql &= ", Repair_ID = " & iRepID & Environment.NewLine
                        strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                        strSql &= "AND Billcode_ID = " & iBillcodeID & Environment.NewLine
                    End If
                Else
                    strSql = "INSERT INTO treflowpart ( " & Environment.NewLine
                    strSql &= "Device_ID, Billcode_ID, Fail_ID, Repair_ID, User_ID, TransactionDate " & Environment.NewLine
                    strSql &= ") VALUES ( " & Environment.NewLine
                    strSql &= iDeviceID & ", " & iBillcodeID & ", " & iFailID & ", " & iRepID & ", " & iUserID & ", now()" & Environment.NewLine
                    strSql &= ") " & Environment.NewLine
                End If

                If strSql.Trim.Length > 0 Then i = objDataProc.ExecuteNonQuery(strSql)

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '**************************************************************
        Public Shared Function DeleteReflowPart(ByVal iDeviceID As Integer, _
                                      ByVal iBillcodeID As Integer) As Integer
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = ""

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "DELETE " & Environment.NewLine
                strSql &= "FROM treflowpart  " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "AND Billcode_ID = " & iBillcodeID & Environment.NewLine

                Return objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Shared Function GetReflowPartCount(ByVal iDeviceID As Integer) As Integer
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = ""

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT count(*) as cnt " & Environment.NewLine
                strSql &= "FROM treflowpart  " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine

                Return objDataProc.GetIntValue(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Shared Function GetExistingReflowParts(ByVal iDeviceID As Integer) As DataTable
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = ""

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT * " & Environment.NewLine
                strSql &= "FROM treflowpart  " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine

                Return objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Shared Sub GetRepFailMap(ByRef iRepID As Integer, _
                                        ByRef iFailID As Integer, _
                                        ByVal iBillcode As Integer, _
                                        ByVal iModelID As Integer, _
                                        ByVal iCustID As Integer)
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT if(Repair_ID is null, 0, Repair_ID) as Repair_ID, if(Fail_ID is null, 0, Fail_ID) as Fail_ID " & Environment.NewLine
                strSql &= "FROM tbillmap  " & Environment.NewLine
                strSql &= "WHERE Cust_ID = " & iCustID & Environment.NewLine
                strSql &= "AND Model_ID = " & iModelID & Environment.NewLine
                strSql &= "AND Billcode_ID = " & iBillcode & Environment.NewLine

                dt = objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    iRepID = dt.Rows(0)("Repair_ID") : iFailID = dt.Rows(0)("Fail_ID")
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '**************************************************************
        Public Shared Sub GetReflowFailRepDesc(ByRef strFailDesc As String, _
                                               ByRef strRepDesc As String, _
                                               ByVal iBillcodeID As Integer, _
                                               ByVal iDeviceID As Integer)
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT Concat('Fail Code:', Fail_LDesc) as Fail_LDesc, Concat('Repair Code:', Repair_LDesc) as Repair_LDesc " & Environment.NewLine
                strSql &= "FROM treflowpart  " & Environment.NewLine
                strSql &= "INNER JOIN lfailcodes ON treflowpart.Fail_ID = lfailcodes.Fail_ID " & Environment.NewLine
                strSql &= "INNER JOIN lrepaircodes ON treflowpart.Repair_ID = lrepaircodes.Repair_ID " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "AND Billcode_ID = " & iBillcodeID & Environment.NewLine

                dt = objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    strFailDesc = dt.Rows(0)("Fail_LDesc") : strRepDesc = dt.Rows(0)("Repair_LDesc")
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '**************************************************************
        Public Shared Function GetFailCodeListFromBillcodeMap(ByVal iManufID As Integer, _
                                                              ByVal iBillcodeID As Integer, _
                                                              Optional ByVal booAddSelectRow As Boolean = False) As DataTable
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT Fail_ID, BFM_DispDesc as FailDesc" & Environment.NewLine
                strSql &= "FROM tbillcodefailcodemap " & Environment.NewLine
                strSql &= "WHERE Manuf_ID = " & iManufID & Environment.NewLine
                strSql &= "AND Billcode_id = " & iBillcodeID & Environment.NewLine
                strSql &= "AND BFM_Inactive = 0 " & Environment.NewLine
                strSql &= "ORDER BY BFM_DispDesc" & Environment.NewLine

                dt = objDataProc.GetDataTable(strSql)

                If booAddSelectRow = True Then dt.LoadDataRow(New Object() {"0", "--Select--"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '**************************************************************
        Public Shared Function GetRepairCodeList(ByVal iManufID As Integer, _
                                                 ByVal iProdID As Integer, _
                                                 Optional ByVal iRepairLevel As Integer = 0, _
                                                 Optional ByVal strRepairType As String = "", _
                                                 Optional ByVal iRepairID As Integer = 0, _
                                                 Optional ByVal booAddSelectRow As Boolean = False, _
                                                 Optional ByVal bConcatReapirLSDesc As Boolean = False) As DataTable
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = ""
            Dim dt As DataTable

            'Do not modify this SQL which is used by many places through PSS.NET
            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                If Not bConcatReapirLSDesc Then
                    strSql = "SELECT Repair_ID, Repair_LDesc" & Environment.NewLine
                Else
                    strSql = "SELECT Repair_ID, concat(Repair_LDesc, ' (', Repair_SDesc, ')') as Repair_LDesc, Repair_SDesc" & Environment.NewLine
                End If
                strSql &= "FROM lrepaircodes " & Environment.NewLine
                strSql &= "WHERE Manuf_ID = " & iManufID & Environment.NewLine
                strSql &= "AND Prod_ID = " & iProdID & Environment.NewLine
                strSql &= "AND Repair_Inactive = 0 " & Environment.NewLine
                If strRepairType.Trim.Length > 0 Then strSql &= "AND Repair_Type = '" & strRepairType.Trim & "'" & Environment.NewLine
                If iRepairID > 0 Then strSql &= "AND Repair_ID = " & iRepairID & Environment.NewLine
                If iRepairLevel > 0 Then strSql &= "AND Repair_Level = " & iRepairLevel & Environment.NewLine
                strSql &= "ORDER BY Repair_LDesc" & Environment.NewLine

                dt = objDataProc.GetDataTable(strSql)

                If booAddSelectRow = True Then dt.LoadDataRow(New Object() {"0", "--Select--"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '**************************************************************
        Public Shared Function GetCelloptData(ByVal iDeviceID As Integer) As DataTable
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = ""

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT * " & Environment.NewLine
                strSql &= "FROM tcellopt " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                Return objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Shared Function UpdateCelloptData(ByVal iDeviceID As Integer, _
                                                 ByVal strCSN As String, _
                                                 ByVal strSjugNo As String, _
                                                 ByVal strSoftVersion As String) As Integer
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = ""
            Dim strUpdateData As String = ""

            Try
                If strCSN.Trim.Length > 0 Or strSjugNo.Trim.Length > 0 Or strSoftVersion.Trim.Length > 0 Then
                    objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                    If strCSN.Trim.Length > 0 Then strUpdateData &= " tcellopt.CellOpt_CSN = '" & strCSN & "'" & Environment.NewLine
                    If strSjugNo.Trim.Length > 0 Then
                        If strUpdateData.Trim.Length > 0 Then strUpdateData &= ", "
                        strUpdateData &= " tcellopt.CellOpt_SugIn = '" & strSjugNo & "'" & Environment.NewLine
                    End If
                    If strSoftVersion.Trim.Length > 0 Then
                        If strUpdateData.Trim.Length > 0 Then strUpdateData &= ", "
                        strUpdateData &= " tcellopt.CellOpt_SoftVerIN = '" & strSoftVersion & "'" & Environment.NewLine
                    End If

                    If strUpdateData.Trim.Length > 0 Then
                        strSql = "UPDATE tcellopt " & Environment.NewLine
                        strSql &= "SET " & strUpdateData & "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                        Return objDataProc.ExecuteNonQuery(strSql)
                    Else
                        Return 0
                    End If
                Else
                    Return 0
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Shared Function GetFailCodesListAllCols(ByVal iManufID As Integer, _
                                               ByVal ProdID As Integer) As DataTable
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = ""
            Dim strUpdateData As String = ""

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "Select * from tfailcodes where tfailcodes.Manuf_ID = " & iManufID & " and tfailcodes.prod_id= " & ProdID
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Shared Function GetAllActiveSymtomCodeList(ByVal iManufID As Integer, _
                                                 ByVal iProdID As Integer, _
                                                 Optional ByVal booAddSelectRow As Boolean = False) As DataTable
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT Comp_ID, Comp_Desc FROM lcomplaint WHERE Comp_Inactive = 0 AND Manuf_ID = " & iManufID & " AND Prod_ID =  " & iProdID & Environment.NewLine
                strSql &= "ORDER BY Comp_Desc" & Environment.NewLine

                dt = objDataProc.GetDataTable(strSql)

                If booAddSelectRow = True Then dt.LoadDataRow(New Object() {"0", "--Select--"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '**************************************************************
        Public Shared Function GetAllActiveFailCodeList(ByVal iManufID As Integer, _
                                                        ByVal iProdID As Integer, _
                                                        Optional ByVal booAddSelectRow As Boolean = False) As DataTable
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT Fail_ID, Fail_LDesc as FailDesc FROM lfailcodes WHERE Fail_Inactive = 0 AND Manuf_ID = " & iManufID & " AND Prod_ID =  " & iProdID & Environment.NewLine
                strSql &= "ORDER BY Fail_LDesc" & Environment.NewLine

                dt = objDataProc.GetDataTable(strSql)

                If booAddSelectRow = True Then dt.LoadDataRow(New Object() {"0", "--Select--"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '**************************************************************
        Public Shared Function GetMaterialGroupWrtyForPartNumber(ByVal strPartNumber As String) As DataTable
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "select * from lpsprice where PSPrice_Number='" & strPartNumber & "';" & Environment.NewLine
                dt = objDataProc.GetDataTable(strSql)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function


        ''**************************************************************
        'Public Shared Function GetRepairCodeDataForMertialGroupWrty(ByVal strMatGrpWrtyClaim As String) As DataTable
        '    Dim objDataProc As DBQuery.DataProc
        '    Dim strSql As String = ""
        '    Dim dt As DataTable

        '    Try
        '        objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
        '        strSql = "select * from lpsprice where PSPrice_Number='" & strPartNumber & "';" & Environment.NewLine
        '        dt = objDataProc.GetDataTable(strSql)
        '        Return dt
        '    Catch ex As Exception
        '        Throw ex
        '    Finally
        '        Buisness.Generic.DisposeDT(dt)
        '    End Try
        'End Function

        '**************************************************************

    End Class
End Namespace