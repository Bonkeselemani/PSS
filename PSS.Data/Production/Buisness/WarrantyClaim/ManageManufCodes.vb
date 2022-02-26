Option Explicit On 

Namespace Buisness.WarrantyClaim
    Public Class ManageManufCodes
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

        '******************************************************************************************
        Public Function GetProdManufModelDataSet() As DataSet
            Dim strSql As String
            Dim dt As DataTable
            Dim ds As DataSet

            Try
                ds = New DataSet()

                strSql = "SELECT * FROM lmanuf WHERE Claimable = 1"
                dt = Me._objDataProc.GetDataTable(strSql)
                dt.TableName = "Manuf"
                ds.Tables.Add(dt)

                dt = Nothing
                strSql = "SELECT * FROM lproduct WHERE Prod_Inactive = 0"
                dt = Me._objDataProc.GetDataTable(strSql)
                dt.TableName = "Product"
                ds.Tables.Add(dt)

                dt = Nothing
                strSql = "SELECT * FROM tmodel " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                dt.TableName = "Model"
                ds.Tables.Add(dt)

                ds.AcceptChanges()

                Return ds
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
                Buisness.Generic.DisposeDS(ds)
            End Try
        End Function

        '******************************************************************************************
        Public Function GetFailCodeList(ByVal iManufID As Integer, _
                                        ByVal iProdID As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT Fail_ID, Fail_SDesc as 'Fault Code', Fail_LDesc as 'Fault Code Description', Fail_Inactive as 'Inactive' " & Environment.NewLine
                strSql &= "FROM lfailcodes " & Environment.NewLine
                strSql &= "WHERE Manuf_ID = " & iManufID & Environment.NewLine
                strSql &= "AND Prod_ID = " & iProdID & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************
        Public Function SetFailCodeListInactiveFlag(ByVal strFailIDs As String, _
                                                    ByVal iInactive As Integer) As Integer
            Dim strSql As String

            Try
                strSql = "UPDATE lfailcodes SET Fail_Inactive = " & iInactive & Environment.NewLine
                strSql &= "WHERE Fail_ID IN ( " & strFailIDs & ") " & Environment.NewLine

                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************
        Public Function GetFailCodeID(ByVal iManufID As Integer, _
                                      ByVal strFailCode As String) As Integer
            Dim strSql As String
            Dim dt As DataTable

            Try
                strSql = "SELECT Fail_ID FROM lfailcodes " & Environment.NewLine
                strSql &= "WHERE Fail_SDesc = '" & strFailCode & "' AND Manuf_ID = " & iManufID & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 1 Then
                    Throw New Exception("Duplicate in system for code """ & strFailCode & """.")
                ElseIf dt.Rows.Count = 0 Then
                    Return 0
                Else
                    Return dt.Rows(0)(0)
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************************************
        Public Function AddUpdateFailCodes(ByVal strFailCode As String, _
                                           ByVal strFailCodeDesc As String, _
                                           ByVal iInactive As Integer, _
                                           ByVal iManufID As Integer, _
                                           ByVal iProdID As Integer, _
                                           Optional ByVal iFailID As Integer = 0) As Integer
            Dim strSql As String
            Dim dt As DataTable

            Try
                If iFailID > 0 Then
                    'Update
                    strSql = "UPDATE lfailcodes SET Fail_Inactive = " & iInactive & Environment.NewLine
                    strSql &= ", Fail_LDesc = '" & strFailCodeDesc & "'" & Environment.NewLine
                    strSql &= "WHERE Fail_ID = " & iFailID & Environment.NewLine
                Else
                    strSql = "SELECT * FROM lfailcodes " & Environment.NewLine
                    strSql &= "WHERE Manuf_ID = " & iManufID & Environment.NewLine
                    strSql &= "AND Prod_ID = " & iProdID & Environment.NewLine
                    strSql &= "AND Fail_SDesc = '" & strFailCode & "'" & Environment.NewLine
                    dt = Me._objDataProc.GetDataTable(strSql)

                    If dt.Rows.Count > 1 Then
                        Throw New Exception("This codes """ & strFailCode & """ is duplicated in the system.")
                    ElseIf dt.Rows.Count = 1 Then
                        strSql = "UPDATE lfailcodes SET Fail_Inactive = " & iInactive & Environment.NewLine
                        strSql &= ", Fail_LDesc = '" & strFailCodeDesc & "'" & Environment.NewLine
                        strSql &= "WHERE Fail_ID = " & iFailID & Environment.NewLine
                    Else
                        strSql = "INSERT INTO lfailcodes ( " & Environment.NewLine
                        strSql &= "Fail_SDesc, Fail_LDesc, Fail_Inactive, Manuf_ID, Prod_ID " & Environment.NewLine
                        strSql &= ") VALUES (" & Environment.NewLine
                        strSql &= "'" & strFailCode & "', '" & strFailCodeDesc & "', " & iInactive & ", " & iManufID & ", " & iProdID & Environment.NewLine
                        strSql &= ")" & Environment.NewLine
                    End If
                End If

                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************************************
        Public Function GetRepairCodeList(ByVal iManufID As Integer, _
                                        ByVal iProdID As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT Repair_ID, Repair_SDesc as 'Repair Code', Repair_LDesc as 'Repair Code Description', Repair_Inactive as 'Inactive' " & Environment.NewLine
                strSql &= "FROM lrepaircodes " & Environment.NewLine
                strSql &= "WHERE Manuf_ID = " & iManufID & Environment.NewLine
                strSql &= "AND Prod_ID = " & iProdID

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************
        Public Function SetRepCodeListInactiveFlag(ByVal strRepIDs As String, _
                                                   ByVal iInactive As Integer) As Integer
            Dim strSql As String

            Try
                strSql = "UPDATE lrepaircodes SET Repair_Inactive = " & iInactive & Environment.NewLine
                strSql &= "WHERE Repair_ID IN ( " & strRepIDs & ") " & Environment.NewLine

                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************
        Public Function AddUpdateRepairCodes(ByVal strRepCode As String, _
                                             ByVal strRepCodeDesc As String, _
                                             ByVal iInactive As Integer, _
                                             ByVal iManufID As Integer, _
                                             ByVal iProdID As Integer, _
                                             Optional ByVal iRepID As Integer = 0) As Integer
            Dim strSql As String
            Dim dt As DataTable

            Try
                If iRepID > 0 Then
                    'Update
                    strSql = "UPDATE lrepaircodes SET Repair_Inactive = " & iInactive & Environment.NewLine
                    strSql &= ", Repair_LDesc = '" & strRepCodeDesc & "'" & Environment.NewLine
                    strSql &= "WHERE Repair_ID = " & iRepID & Environment.NewLine
                Else
                    strSql = "SELECT * FROM lrepaircodes " & Environment.NewLine
                    strSql &= "WHERE Manuf_ID = " & iManufID & Environment.NewLine
                    strSql &= "AND Prod_ID = " & iProdID & Environment.NewLine
                    strSql &= "AND Repair_SDesc = '" & strRepCode & "'" & Environment.NewLine
                    dt = Me._objDataProc.GetDataTable(strSql)

                    If dt.Rows.Count > 1 Then
                        Throw New Exception("This codes """ & strRepCode & """ is duplicated in the system.")
                    ElseIf dt.Rows.Count = 1 Then
                        strSql = "UPDATE lrepaircodes SET Repair_Inactive = " & iInactive & Environment.NewLine
                        strSql &= ", Repair_LDesc = '" & strRepCodeDesc & "'" & Environment.NewLine
                        strSql &= "WHERE Repair_ID = " & iRepID & Environment.NewLine
                    Else
                        strSql = "INSERT INTO lrepaircodes ( " & Environment.NewLine
                        strSql &= "Repair_SDesc, Repair_LDesc, Repair_Inactive, Manuf_ID, Prod_ID " & Environment.NewLine
                        strSql &= ") VALUES (" & Environment.NewLine
                        strSql &= "'" & strRepCode & "', '" & strRepCodeDesc & "', " & iInactive & ", " & iManufID & ", " & iProdID & Environment.NewLine
                        strSql &= ")" & Environment.NewLine
                    End If
                End If

                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************************************
        Public Function GetBillCodeFailCodeMap(ByVal iManufID As Integer, _
                                               ByVal iProdID As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT A.BFM_ID, A.BillCode_ID, C.Billcode_Desc as 'Bill Code Description' " & Environment.NewLine
                strSql &= ", B.Fail_SDesc as 'Fault Code', B.Fail_LDesc as 'Fault Code Description' " & Environment.NewLine
                strSql &= ", A.BFM_DispDesc as 'Fault Code Pop-up Description' " & Environment.NewLine
                strSql &= ", A.BFM_Inactive as 'Inactive'" & Environment.NewLine
                strSql &= "FROM tbillcodefailcodemap A" & Environment.NewLine
                strSql &= "INNER JOIN lfailcodes B ON A.Fail_ID = B.Fail_ID" & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes C on A.Billcode_ID = C.BillCode_ID" & Environment.NewLine
                strSql &= "WHERE A.Manuf_ID = " & iManufID & Environment.NewLine
                strSql &= "AND C.Device_ID = " & iProdID & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************
        Public Function SeBillCodeFailCodeMapInactiveFlag(ByVal strBCFCMapIDs As String, _
                                                          ByVal iInactive As Integer) As Integer
            Dim strSql As String

            Try
                strSql = "UPDATE tbillcodefailcodemap SET BFM_Inactive = " & iInactive & Environment.NewLine
                strSql &= "WHERE BFM_ID IN ( " & strBCFCMapIDs & ") " & Environment.NewLine

                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************
        Public Function IsBillcodeIDExisted(ByVal iProdID As Integer, _
                                            ByVal iBillCodeID As Integer) As Boolean
            Dim strSql As String

            Try
                strSql = "SELECT count(*) as cnt FROM lbillcodes" & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iProdID & " AND Billcode_ID = " & iBillCodeID & " " & Environment.NewLine

                If Me._objDataProc.GetIntValue(strSql) > 0 Then Return True Else Return False
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************
        Public Function AddUpdateBillCodeFailCodeMap(ByVal iManufID As Integer, _
                                                     ByVal iBillcodeID As Integer, _
                                                     ByVal iFailID As Integer, _
                                                     ByVal strDisplayDesc As String, _
                                                     ByVal iInactive As Integer, _
                                                     Optional ByVal iBCFCMapID As Integer = 0) As Integer
            Dim strSql As String
            Dim dt As DataTable

            Try
                If iBCFCMapID > 0 Then
                    'Update
                    strSql = "UPDATE tbillcodefailcodemap SET BFM_UpdateDT = now(), BFM_Inactive = " & iInactive & Environment.NewLine
                    strSql &= ", BFM_DispDesc = '" & strDisplayDesc & "'" & Environment.NewLine
                    strSql &= "WHERE BFM_ID = " & iBCFCMapID & Environment.NewLine
                Else
                    strSql = "SELECT * FROM tbillcodefailcodemap " & Environment.NewLine
                    strSql &= "WHERE Manuf_ID = " & iManufID & Environment.NewLine
                    strSql &= "AND Billcode_ID = " & iBillcodeID & Environment.NewLine
                    strSql &= "AND Fail_ID = '" & iFailID & "'" & Environment.NewLine
                    dt = Me._objDataProc.GetDataTable(strSql)

                    If dt.Rows.Count > 1 Then
                        Throw New Exception("Duplicate record for this map ( " & iManufID & ", " & iBillcodeID & ", " & iFailID & ").")
                    ElseIf dt.Rows.Count = 1 Then
                        strSql = "UPDATE tbillcodefailcodemap SET BFM_UpdateDT = now(), BFM_Inactive = " & iInactive & Environment.NewLine
                        strSql &= ", BFM_DispDesc = '" & strDisplayDesc & "'" & Environment.NewLine
                        strSql &= "WHERE BFM_ID = " & dt.Rows(0)("BFM_ID") & Environment.NewLine
                    Else
                        strSql = "INSERT INTO tbillcodefailcodemap ( " & Environment.NewLine
                        strSql &= "BFM_UpdateDT, Manuf_ID, Billcode_ID, Fail_ID, BFM_Inactive, BFM_DispDesc " & Environment.NewLine
                        strSql &= ") VALUES (" & Environment.NewLine
                        strSql &= "now(), " & iManufID & ", " & iBillcodeID & ", " & iFailID & ", " & iInactive & ", '" & strDisplayDesc & "' " & Environment.NewLine
                        strSql &= ")" & Environment.NewLine
                    End If
                End If

                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************************************
        Public Function GetBillCodePartMap(ByVal iManufID As Integer, _
                                           ByVal iProdID As Integer) As DataTable
            Dim strSql As String

            Try
                'strSql = "SELECT DISTINCT lbillcodes.BillCode_ID, BillCode_Desc as 'Bill Code Description'" & Environment.NewLine
                'strSql &= ", upper(PSPrice_Number) as 'Part #', PSPrice_Desc as 'Part Description' " & Environment.NewLine
                'strSql &= ", tpsmap.LaborLevel as 'Labor Level'" & Environment.NewLine
                'strSql &= ", if(lbillcodes.BillType_ID = 1, 'Service', 'Part') as 'Bill Code Type'" & Environment.NewLine
                'strSql &= ", Model_Desc as 'Model', tmodel.Model_ID" & Environment.NewLine
                'strSql &= ", IF(RefDesignator_SDesc IS NULL, '', RefDesignator_SDesc) as 'Reference Designator Alpha'" & Environment.NewLine
                'strSql &= ", IF(RefDesignator_LDesc IS NULL, '', RefDesignator_LDesc) as 'Reference Designator Numeric'" & Environment.NewLine
                'strSql &= ", IF(Inactive = 0, 'Yes', 'No') as 'Visible?'" & Environment.NewLine
                'strSql &= "FROM lbillcodes " & Environment.NewLine
                'strSql &= "INNER JOIN tpsmap ON lbillcodes.BillCode_ID = tpsmap.BillCode_ID" & Environment.NewLine
                'strSql &= "INNER JOIN lpsprice ON tpsmap.PSPrice_ID = lpsprice.PSPrice_ID" & Environment.NewLine
                'strSql &= "INNER JOIN tmodel ON tpsmap.Model_ID = tmodel.Model_ID" & Environment.NewLine
                'strSql &= "LEFT OUTER JOIN refdesignatormap ON tpsmap.Model_ID = refdesignatormap.Model_ID AND tpsmap.PSPrice_ID = refdesignatormap.PSPrice_ID " & Environment.NewLine
                'strSql &= "WHERE lbillcodes.Device_ID = " & iProdID & Environment.NewLine
                'strSql &= "AND tmodel.Manuf_ID = " & iManufID & Environment.NewLine

                strSql = "SELECT DISTINCT lbillcodes.BillCode_ID, BillCode_Desc as 'Bill Code Description'" & Environment.NewLine
                strSql &= ", upper(PSPrice_Number) as 'Part #', PSPrice_Desc as 'Part Description' " & Environment.NewLine
                strSql &= ",lfailcodes.Fail_SDesc as 'Fail Code'" & Environment.NewLine
                strSql &= ",lfailcodes.Fail_LDesc as 'FailCode Desc'" & Environment.NewLine
                strSql &= ", tpsmap.LaborLevel as 'Labor Level'" & Environment.NewLine
                strSql &= ", if(lbillcodes.BillType_ID = 1, 'Service', 'Part') as 'Bill Code Type'" & Environment.NewLine
                strSql &= ", Model_Desc as 'Model', tmodel.Model_ID" & Environment.NewLine
                strSql &= ", IF(RefDesignator_SDesc IS NULL, '', RefDesignator_SDesc) as 'Reference Designator Alpha'" & Environment.NewLine
                strSql &= ", IF(RefDesignator_LDesc IS NULL, '', RefDesignator_LDesc) as 'Reference Designator Numeric'" & Environment.NewLine
                strSql &= ", IF(Inactive = 0, 'Yes', 'No') as 'Visible?'" & Environment.NewLine
                strSql &= " FROM lbillcodes " & Environment.NewLine
                strSql &= " INNER JOIN tpsmap ON lbillcodes.BillCode_ID = tpsmap.BillCode_ID" & Environment.NewLine
                strSql &= " INNER JOIN lpsprice ON tpsmap.PSPrice_ID = lpsprice.PSPrice_ID" & Environment.NewLine
                strSql &= " INNER JOIN tmodel ON tpsmap.Model_ID = tmodel.Model_ID" & Environment.NewLine
                strSql &= " LEFT OUTER JOIN lfailcodes ON lfailcodes.Fail_ID = lbillcodes.Fail_ID" & Environment.NewLine
                strSql &= " LEFT OUTER JOIN refdesignatormap ON tpsmap.Model_ID = refdesignatormap.Model_ID AND tpsmap.PSPrice_ID = refdesignatormap.PSPrice_ID " & Environment.NewLine
                strSql &= " WHERE lbillcodes.Device_ID = " & iProdID & Environment.NewLine
                strSql &= " AND tmodel.Manuf_ID = " & iManufID & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************
        Public Function GetBillCodes(ByVal iProdID As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT DISTINCT lbillcodes.BillCode_ID, BillCode_Desc as 'Bill Code Description'" & Environment.NewLine
                strSql &= ", if(lbillcodes.BillType_ID = 1, 'Service', 'Part') as 'Bill Code Type'" & Environment.NewLine
                strSql &= "FROM lbillcodes " & Environment.NewLine
                strSql &= "WHERE lbillcodes.Device_ID = " & iProdID & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************
        Public Function GetRefDesignatorMap(ByVal iManufID As Integer, ByVal iProdID As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT DISTINCT RefMap_ID, A.PSPrice_ID, upper(PSPrice_Number) as 'Part #', PSPrice_Desc as 'Part Description', RefDesignator_SDesc as 'Alpha', RefDesignator_LDesc as 'Numeric' " & Environment.NewLine
                strSql &= ", A.Model_ID, Model_Desc as 'Model Description'" & Environment.NewLine
                strSql &= "FROM refdesignatormap A " & Environment.NewLine
                strSql &= "INNER JOIN lpsprice B ON A.PSPrice_ID = B.PSPrice_ID" & Environment.NewLine
                strSql &= "INNER JOIN tmodel C ON A.Model_ID = C.Model_ID " & Environment.NewLine
                strSql &= "WHERE C.Prod_ID = " & iProdID & " AND C.Manuf_ID = " & iManufID & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************
        Public Function GetPSPriceID(ByVal strPartNumber As String) As Integer
            Dim strSql As String

            Try
                strSql = "SELECT PSPrice_ID " & Environment.NewLine
                strSql &= "FROM lpsprice " & Environment.NewLine
                strSql &= "WHERE PSPrice_Number = '" & strPartNumber & "'" & Environment.NewLine
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************
        Public Function AddUpdateRefDesignatorMap(ByVal iModelID As Integer, _
                                                  ByVal iRefMapID As Integer, _
                                                  ByVal iPsPriceID As Integer, _
                                                  ByVal strAlpha As String, _
                                                  ByVal strNumeric As String, _
                                                  ByVal iUserID As Integer) As Integer
            Dim strSql As String
            Dim dt As DataTable

            Try
                If iRefMapID > 0 Then
                    'Update
                    strSql = "UPDATE refdesignatormap SET RefMap_UpdateDT = now(), RefMap_UpdateUsrID = " & iUserID & Environment.NewLine
                    strSql &= ", RefDesignator_SDesc = '" & strAlpha & "'" & Environment.NewLine
                    strSql &= ", RefDesignator_LDesc = '" & strNumeric & "'" & Environment.NewLine
                    strSql &= "WHERE RefMap_ID = " & iRefMapID & Environment.NewLine
                Else
                    strSql = "SELECT * FROM refdesignatormap " & Environment.NewLine
                    strSql &= "WHERE Model_ID = " & iModelID & Environment.NewLine
                    strSql &= "AND PSPrice_ID = " & iPsPriceID & Environment.NewLine
                    dt = Me._objDataProc.GetDataTable(strSql)

                    If dt.Rows.Count > 1 Then
                        Throw New Exception("Duplicate record for this map ( " & iModelID & ", " & iPsPriceID & ", " & strAlpha & ", " & strNumeric & ").")
                    ElseIf dt.Rows.Count = 1 Then
                        strSql = "UPDATE refdesignatormap SET RefMap_UpdateDT = now(), RefMap_UpdateUsrID = " & iUserID & Environment.NewLine
                        strSql &= ", RefDesignator_SDesc = '" & strAlpha & "'" & Environment.NewLine
                        strSql &= ", RefDesignator_LDesc = '" & strNumeric & "'" & Environment.NewLine
                        strSql &= "WHERE RefMap_ID = " & dt.Rows(0)("RefMap_ID") & Environment.NewLine
                    Else
                        strSql = "INSERT INTO refdesignatormap ( " & Environment.NewLine
                        strSql &= "RefMap_UpdateDT, RefMap_UpdateUsrID, Model_ID, PSPrice_ID, RefDesignator_SDesc, RefDesignator_LDesc " & Environment.NewLine
                        strSql &= ") VALUES (" & Environment.NewLine
                        strSql &= "now(), " & iUserID & ", " & iModelID & ", " & iPsPriceID & ", '" & strAlpha & "', '" & strNumeric & "' " & Environment.NewLine
                        strSql &= ")" & Environment.NewLine
                    End If
                End If

                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************************************
        Public Function IsPartMappedToModel(ByVal iModelID As Integer, ByVal iPspriceID As Integer) As Boolean
            Dim strSql As String

            Try
                strSql = "SELECT count(*) as cnt " & Environment.NewLine
                strSql &= "FROM tpsmap " & Environment.NewLine
                strSql &= "WHERE Model_ID = " & iModelID & " AND PSPrice_ID = " & iPspriceID & Environment.NewLine
                If Me._objDataProc.GetIntValue(strSql) > 0 Then Return True Else Return False
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************

    End Class
End Namespace