Imports PSS.Data.Production
Imports eInfoDesigns.dbProvider.MySqlClient

Namespace Buisness

    Public Class PartsMap
        Private _objMySqlData As MySql4.DataProc

        '***********************************************************************************************************************
        Public Sub New()
            Try
                _objMySqlData = New MySql4.DataProc(ConfigFile.GetConnectionInfo)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '***********************************************************************************************************************
        Public Shared Function SetInvisibleField(ByVal strPSPriceIDs As String, ByVal iInvisibleVal As Integer) As Integer
            Dim objDataProc As DBQuery.DataProc
            Dim strSQL As String

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSQL = "UPDATE tpsmap SET Inactive = " & iInvisibleVal & " WHERE PSMap_ID IN ( " & strPSPriceIDs & ") AND Inactive <> " & iInvisibleVal
                Return objDataProc.ExecuteNonQuery(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************
        Public Shared Function GetMappedData(Optional ByVal iModelID As Integer = 0, Optional ByVal iBillTypeID As Integer = 0) As DataTable
            Dim strSQL As String
            Dim strCriteria As String = ""

            strSQL = "SELECT tmodel.Model_Desc AS 'Model' " & Environment.NewLine
            strSQL &= ", lpsprice.PSPrice_Number AS 'Part' " & Environment.NewLine
            strSQL &= ", lbillcodes.BillCode_Desc AS 'Bill Code' " & Environment.NewLine
            strSQL &= ", llaborlvl.LaborLvl_Desc AS 'Labor Level' " & Environment.NewLine
            strSQL &= ", tpsmap.LaborLevel " & Environment.NewLine
            strSQL &= ", lproduct.Prod_Desc AS 'Product' " & Environment.NewLine
            strSQL &= ", tpsmap.PSMap_ID " & Environment.NewLine
            strSQL &= ", tpsmap.Prod_ID " & Environment.NewLine
            strSQL &= ", tpsmap.PSPrice_ID " & Environment.NewLine
            strSQL &= ", tpsmap.Billcode_ID " & Environment.NewLine
            strSQL &= ", tpsmap.LaborLvl_ID " & Environment.NewLine
            strSQL &= ", tpsmap.LOB_ID " & Environment.NewLine
            strSQL &= ", tpsmap.Inactive " & Environment.NewLine
            strSQL &= ", LineOfBusiness.LOB_Desc AS 'Line of Business' " & Environment.NewLine
            strSQL &= ", if(tpsmap.Inactive = 1, 'No', 'Yes') as 'Visible?' " & Environment.NewLine
            strSQL &= ", if(lbillcodes.BillType_ID = 1, 'Service', 'Part') as 'Billcode Type' " & Environment.NewLine
            strSQL &= ", if(lbillrule.BillRule_Desc is null, 'REPAIR', BillRule_Desc) as 'Bill Rule' " & Environment.NewLine
            strSQL &= ", reflowtypes.ReflowTypeID, reflowtypes.ReflowType_Desc as 'Reflow Type' " & Environment.NewLine
            strSQL &= ", if(security.tusers.User_Fullname is null, '', security.tusers.User_Fullname) as 'Last Updated User' " & Environment.NewLine
            strSQL &= ", tpsmap.UpdateDate as 'Last Updated Date' " & Environment.NewLine
            strSQL &= ", lpsprice.PSPrice_AvgCost as 'Avg Cost', lpsprice.PSPrice_StndCost as 'Unit Cost', lpsprice.PSPrice_LastDirectCost as 'Last Direct Cost' "
            strSQL &= "FROM lproduct " & Environment.NewLine
            strSQL &= "INNER JOIN llaborlvl ON tpsmap.LaborLvl_ID = llaborlvl.LaborLvl_ID " & Environment.NewLine
            strSQL &= "INNER JOIN lbillcodes ON tpsmap.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
            strSQL &= "INNER JOIN tmodel ON tpsmap.Model_ID = tmodel.Model_ID " & Environment.NewLine
            strSQL &= "INNER JOIN lpsprice ON tpsmap.PSPrice_ID = lpsprice.PSPrice_ID " & Environment.NewLine
            strSQL &= "INNER JOIN tpsmap ON lproduct.Prod_ID = tpsmap.Prod_ID " & Environment.NewLine
            strSQL &= "INNER JOIN LineOfBusiness ON tpsmap.LOB_ID = LineOfBusiness.LOB_ID " & Environment.NewLine
            strSQL &= "INNER JOIN reflowtypes ON tpsmap.ReflowTypeID = reflowtypes.ReflowTypeID " & Environment.NewLine
            strSQL &= "LEFT OUTER JOIN lbillrule ON lbillcodes.BillCode_Rule = lbillrule.BillRule_ID " & Environment.NewLine
            strSQL &= "LEFT OUTER JOIN security.tusers ON tpsmap.User_ID = security.tusers.User_ID " & Environment.NewLine
            If iModelID > 0 Then strCriteria &= "WHERE tpsmap.Model_ID = " & iModelID & Environment.NewLine
            If iBillTypeID > 0 Then
                If strCriteria.Trim.Length > 0 Then strCriteria &= " AND " Else strCriteria &= " WHERE "
                strCriteria &= "lbillcodes.BillType_ID = " & iBillTypeID & Environment.NewLine
            End If
            If strCriteria.Trim.Length > 0 Then strSQL &= strCriteria
            strSQL &= "ORDER BY lproduct.Prod_ID, tmodel.Model_Desc, llaborlvl.LaborLvl_ID"

            Return GetDataTable(strSQL)
        End Function

        Public Shared Function GetMappedDataItem(ByVal id As Integer) As DataRow
            Dim strSQL As String

            strSQL = "SELECT tpsmap.PSMap_ID, " & Environment.NewLine
            strSQL &= "tmodel.Model_Desc AS 'Model', " & Environment.NewLine
            strSQL &= "lpsprice.PSPrice_Number AS 'Part', " & Environment.NewLine
            strSQL &= "lbillcodes.BillCode_Desc AS 'Bill Code', " & Environment.NewLine
            strSQL &= "llaborlvl.LaborLvl_Desc AS 'Labor Level', " & Environment.NewLine
            strSQL &= "lproduct.Prod_Desc AS 'Product', " & Environment.NewLine
            strSQL &= "LineOfBusiness.LOB_Desc AS 'Line of Business' " & Environment.NewLine
            strSQL &= ", lproduct.Prod_ID " & Environment.NewLine
            strSQL &= ", tmodel.Model_ID " & Environment.NewLine
            strSQL &= ", lpsprice.PSPrice_ID " & Environment.NewLine
            strSQL &= ", lbillcodes.Billcode_ID " & Environment.NewLine
            strSQL &= ", llaborlvl.LaborLvl_ID " & Environment.NewLine
            strSQL &= ", LineOfBusiness.LOB_ID " & Environment.NewLine
            strSQL &= ", tpsmap.Inactive " & Environment.NewLine
            strSQL &= ", tpsmap.ReflowTypeID " & Environment.NewLine
            strSQL &= "FROM lproduct " & Environment.NewLine
            strSQL &= "INNER JOIN llaborlvl ON tpsmap.LaborLvl_ID = llaborlvl.LaborLvl_ID " & Environment.NewLine
            strSQL &= "INNER JOIN lbillcodes ON tpsmap.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
            strSQL &= "INNER JOIN tmodel ON tpsmap.Model_ID = tmodel.Model_ID " & Environment.NewLine
            strSQL &= "INNER JOIN lpsprice ON tpsmap.PSPrice_ID = lpsprice.PSPrice_ID " & Environment.NewLine
            strSQL &= "INNER JOIN tpsmap ON lproduct.Prod_ID = tpsmap.Prod_ID " & Environment.NewLine
            strSQL &= "INNER JOIN LineOfBusiness ON tpsmap.LOB_ID = LineOfBusiness.LOB_ID " & Environment.NewLine
            strSQL &= "WHERE PSMap_ID = " & id.ToString & Environment.NewLine
            strSQL &= "ORDER BY lproduct.Prod_ID, tmodel.Model_Desc, tpsmap.billcode_id,llaborlvl.LaborLvl_ID"

            Return GetDataTable(strSQL).Rows(0)
        End Function

        '*******************************************************************************************************************************
        Public Shared Sub InsertMap(ByVal Price As Integer, ByVal BillCode As Integer, ByVal Model As Integer, ByVal Product As Integer, ByVal iLaborLevelID As Integer, ByVal iLineOfBusinessID As Integer, ByVal iInvisible As Integer, ByVal iLaborLevel As Integer, ByVal iReflowTypeID As Integer, ByVal iUserID As Integer)
            Dim strSQL As String

            Try
                strSQL = "INSERT INTO tpsmap (PSPrice_ID, BillCode_ID, Model_ID, Prod_ID, LaborLvl_ID, LOB_ID, Inactive, LaborLevel, ReflowTypeID, User_ID, UpdateDate)" & Environment.NewLine
                strSQL &= "VALUES (" & Price.ToString & ", " & BillCode.ToString & ", " & Model.ToString & ", " & Product.ToString & ", " & iLaborLevelID.ToString & ", " & iLineOfBusinessID.ToString & ", " & iInvisible.ToString & ", " & iLaborLevel.ToString & ", " & iReflowTypeID & ", " & iUserID & ", now() )"
                SetData(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*******************************************************************************************************************************
        Public Shared Sub UpdateMap(ByVal Price As Integer, ByVal BillCode As Integer, ByVal Model As Integer, ByVal Product As Integer, ByVal LaborLevel As Integer, ByVal iLineOfBusinessID As Integer, ByVal id As Integer, ByVal iInvisible As Integer, ByVal iLaborLevel As Integer, ByVal iReflowTypeID As Integer, ByVal iUserID As Integer)
            Dim strSQL As String
            Dim R1 As DataRow

            Try
                R1 = GetMapRecord(id)

                strSQL = "UPDATE tpsmap SET PSPrice_ID = " & Price.ToString & ", BillCode_ID = " & BillCode.ToString & ", Model_ID = " & Model.ToString & ", " & Environment.NewLine
                strSQL &= "Prod_ID = " & Product.ToString & ", LaborLvl_ID = " & LaborLevel.ToString & ", LOB_ID = " & iLineOfBusinessID.ToString & ", Inactive = " & iInvisible.ToString & ", LaborLevel = " & iLaborLevel.ToString & ", ReflowTypeID = " & iReflowTypeID & ", User_ID = " & iUserID & ", UpdateDate = now() " & Environment.NewLine
                strSQL &= "WHERE PSMap_ID = " & id.ToString
                SetData(strSQL)

                'Write history
                WritePartMapJournal(R1, iUserID, "Update")
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*******************************************************************************************************************************
        Public Shared Sub DeleteMap(ByVal id As Integer, ByVal iUserID As Integer)
            Dim strSQL As String
            Dim R1 As DataRow
            Try
                R1 = GetMapRecord(id)

                strSQL = "DELETE FROM tpsmap" & Environment.NewLine
                strSQL &= "WHERE PSMap_ID = " & id.ToString
                SetData(strSQL)

                'Write history
                WritePartMapJournal(R1, iUserID, "Delete")
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*******************************************************************************************************************************
        Public Shared Function GetMapRecord(ByVal iMapID As Integer) As DataRow
            Dim strSQL As String
            Dim dt As DataTable

            Try
                strSQL = "SELECT * FROM tpsmap" & Environment.NewLine
                strSQL &= "WHERE PSMap_ID = " & iMapID.ToString

                dt = GetDataTable(strSQL)
                If dt.Rows.Count > 0 Then Return dt.Rows(0) Else Return Nothing
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '*******************************************************************************************************************************
        Public Shared Function WritePartMapJournal(ByVal drRowRecord As DataRow, ByVal iUserID As Integer, ByVal strUpdateType As String) As Integer
            Dim strSQL As String
            Dim dt As DataTable

            Try
                If Not IsNothing(drRowRecord) Then
                    strSQL = "INSERT INTO tpsmapjournal ( " & Environment.NewLine
                    strSQL &= " PSMap_ID " & Environment.NewLine
                    strSQL &= ", PSPrice_ID" & Environment.NewLine
                    strSQL &= ", BillCode_ID" & Environment.NewLine
                    strSQL &= ", Model_ID" & Environment.NewLine
                    strSQL &= ", Prod_ID" & Environment.NewLine
                    strSQL &= ", LaborLvl_ID" & Environment.NewLine
                    strSQL &= ", LaborLevel" & Environment.NewLine
                    strSQL &= ", CustFlg" & Environment.NewLine
                    strSQL &= ", Inactive" & Environment.NewLine
                    strSQL &= ", CanReflow" & Environment.NewLine
                    strSQL &= ", ReflowTypeID" & Environment.NewLine
                    strSQL &= ", LOB_ID" & Environment.NewLine
                    strSQL &= ", User_ID" & Environment.NewLine
                    strSQL &= ", UpdateDate" & Environment.NewLine
                    strSQL &= ", UpdateType" & Environment.NewLine
                    strSQL &= ") VALUES ( " & Environment.NewLine
                    strSQL &= drRowRecord("PSMap_ID").ToString & Environment.NewLine
                    strSQL &= ", " & drRowRecord("PSPrice_ID").ToString & Environment.NewLine
                    strSQL &= ", " & drRowRecord("BillCode_ID").ToString & Environment.NewLine
                    strSQL &= ", " & drRowRecord("Model_ID").ToString & Environment.NewLine
                    strSQL &= ", " & drRowRecord("Prod_ID").ToString & Environment.NewLine
                    strSQL &= ", " & drRowRecord("LaborLvl_ID").ToString & Environment.NewLine
                    strSQL &= ", " & drRowRecord("LaborLevel").ToString & Environment.NewLine
                    strSQL &= ", " & drRowRecord("CustFlg").ToString & Environment.NewLine
                    strSQL &= ", " & drRowRecord("Inactive").ToString & Environment.NewLine
                    strSQL &= ", " & drRowRecord("CanReflow").ToString & Environment.NewLine
                    strSQL &= ", " & drRowRecord("ReflowTypeID").ToString & Environment.NewLine
                    strSQL &= ", " & drRowRecord("LOB_ID").ToString & Environment.NewLine
                    strSQL &= ", " & iUserID & Environment.NewLine
                    strSQL &= ", now() " & Environment.NewLine
                    strSQL &= ", '" & strUpdateType & "'" & Environment.NewLine
                    strSQL &= ") " & Environment.NewLine
                    SetData(strSQL)
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '*******************************************************************************************************************************

        Public Shared Function Products() As DataTable
            Dim strsql As String = "SELECT prod_id, prod_desc FROM lproduct;"
            Return GetDataTable(strsql)
        End Function

        Public Shared Function Pricing() As DataTable
            ''Dim strSql As String = "SELECT psprice_id, psprice_desc FROM lpsprice WHERE psprice_desc is not null ORDER BY psprice_desc;"
            Dim strSql As String = "SELECT psprice_id, psprice_number FROM lpsprice WHERE psprice_number is not null ORDER BY psprice_number;"
            'Dim strSql As String = "SELECT lpsprice.psprice_id, psprice_number, tpsmap.prod_id FROM (lpsprice INNER JOIN tpsmap ON lpsprice.psprice_id = tpsmap.psprice_id) WHERE psprice_number is not null ORDER BY psprice_number;"
            Return GetDataTable(strSql)
        End Function

        Public Shared Function LaborLevels() As DataTable
            Dim strSql As String = "SELECT laborlvl_id, laborlvl_desc, LaborLevel FROM llaborlvl ORDER BY laborlvl_desc;"
            Return GetDataTable(strSql)
        End Function

        Public Shared Function LinesOfBusiness() As DataTable
            Dim strSQL As String

            strSQL = "SELECT LOB_ID, LOB_Desc" & Environment.NewLine
            strSQL &= "FROM LineOfBusiness" & Environment.NewLine
            strSQL &= "ORDER BY LOB_Desc"

            Return GetDataTable(strSQL)
        End Function

        Public Shared Function ReflowTypes() As DataTable
            Dim strSQL As String
            Try
                strSQL = "SELECT ReflowTypeID, ReflowType_Desc" & Environment.NewLine
                strSQL &= "FROM reflowtypes" & Environment.NewLine
                strSQL &= "ORDER BY ReflowType_Desc"

                Return GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '******************************************************************************
        '   Created By: Lan Nguyen
        ' Created Date: 12/17/2009
        'This function: 1. Get all active billcode in tbilldefaultntfpart by customer and model
        ' New DB Table: tbilldefaultntfpart
        '******************************************************************************
        Public Shared Function GetDefaultPartForNTFUnit(ByVal iCustID As Integer, ByVal iModelID As Integer) As DataTable
            Dim strSQL As String
            Try
                strSQL = "SELECT Billcode_Desc as 'Bill code' " & Environment.NewLine
                strSQL &= "FROM tbilldefaultntfpart A " & Environment.NewLine
                strSQL &= "INNER JOIN lbillcodes B ON A.Billcode_ID = B.Billcode_ID " & Environment.NewLine
                strSQL &= "WHERE Cust_ID = " & iCustID & " AND Model_ID = " & iModelID & Environment.NewLine
                strSQL &= "AND A.Active = 1" & Environment.NewLine
                strSQL &= "ORDER BY Billcode_Desc"

                Return GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************
        '   Created By: Lan Nguyen
        ' Created Date: 12/17/2009
        'This function: 1. Insert/update new billcode into tbilldefaultntfpart table
        '       Reason: Some customer require good unit ship out with part(s).
        '               This record will be billed in shipping screen as a default part
        '               for all NTF device.                
        ' New DB Table: tbilldefaultntfpart
        '******************************************************************************
        Public Shared Function SetAsDefaultPartForNTF(ByVal iCustID As Integer, ByVal iModelID As Integer, ByVal iBillCodeID As Integer) As Integer
            Dim strSQL As String
            Dim dt As DataTable
            Try
                strSQL = "SELECT * " & Environment.NewLine
                strSQL &= "FROM tbilldefaultntfpart " & Environment.NewLine
                strSQL &= "WHERE Cust_ID = " & iCustID & " AND Model_ID = " & iModelID & " AND Billcode_ID = " & iBillCodeID & Environment.NewLine
                dt = GetDataTable(strSQL)
                If dt.Rows.Count > 0 Then
                    strSQL = "UPDATE tbilldefaultntfpart " & Environment.NewLine
                    strSQL &= "SET Active = 1 " & Environment.NewLine
                    strSQL &= "WHERE Cust_ID = " & iCustID & " AND Model_ID = " & iModelID & " AND Billcode_ID = " & iBillCodeID & Environment.NewLine
                Else
                    strSQL = "INSERT INTO tbilldefaultntfpart ( " & Environment.NewLine
                    strSQL &= "Cust_ID, Model_ID, Billcode_ID  " & Environment.NewLine
                    strSQL &= ") VALUES ( " & Environment.NewLine
                    strSQL &= iCustID & ", " & iModelID & ", " & iBillCodeID & Environment.NewLine
                    strSQL &= ");"
                End If
                SetData(strSQL)

                Return 1
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************

        Private Shared Function doapps(ByVal [string] As String) As String
            Return Replace([string], "'", "''")
        End Function

        Private Shared Function GetDataTable(ByVal [string] As String) As DataTable
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable([string])
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Private Shared Sub SetData(ByVal [string] As String)
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                objDataProc.ExecuteNonQuery([string])
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Sub

        '***********************************************************************************************************************
        Public Function GetModelsByCustomer(ByVal iCustID As Integer, ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT Model_ID, Model_Desc FROM tcustomer " & Environment.NewLine
                strSql &= "INNER JOIN tcusttoprice ON tcustomer.Cust_ID = tcusttoprice.Cust_ID " & Environment.NewLine
                strSql &= "INNER JOIN tmodel On tcusttoprice.Prod_ID = tmodel.Prod_ID " & Environment.NewLine
                strSql &= "WHERE tcustomer.Cust_ID = " & iCustID
                dt = Me._objMySqlData.GetDataTable(strSql)
                If booAddSelectRow = True Then dt.LoadDataRow(New Object() {"0", "--Select--"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '***********************************************************************************************************************
        Public Function GetBOMPartID(ByVal iModelID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT lpsprice.PSPrice_ID, Concat(Psprice_Number, ' - ', PSPrice_Desc) as PartNoDesc" & Environment.NewLine
                strSql &= "FROM tpsmap " & Environment.NewLine
                strSql &= "INNER JOIN lpsprice ON tpsmap.PSPrice_ID = lpsprice.PSPrice_ID " & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes On tpsmap.Billcode_ID = lbillcodes.Billcode_ID " & Environment.NewLine
                strSql &= "WHERE tpsmap.Model_ID = " & iModelID & " AND BillType_ID = 2 " & Environment.NewLine
                strSql &= "GROUP BY lpsprice.PSPrice_ID ORDER BY PartNoDesc"
                Return Me._objMySqlData.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex

            End Try
        End Function

        '***********************************************************************************************************************
        Public Function GetPartSNCaptureConfig(ByVal iCustID As Integer, _
                                               ByVal iModelID As Integer, _
                                               ByVal booCollectSNOnly As Boolean) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT partsncapture.* " & Environment.NewLine
                strSql &= "FROM partsncapture " & Environment.NewLine
                strSql &= "INNER JOIN tpsmap ON partsncapture.PSPrice_ID = tpsmap.PSPrice_ID " & Environment.NewLine
                strSql &= "WHERE partsncapture.Cust_ID = " & iCustID & " AND tpsmap.Model_ID = " & iModelID & Environment.NewLine
                If booCollectSNOnly = True Then strSql &= " AND CaptureSN = 1 "
                Return Me._objMySqlData.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************
        Public Function SetPartSerialNumberCapture(ByVal iCustID As Integer, ByVal dt As DataTable) As Integer
            Dim i As Integer
            Dim strSql As String = ""
            Dim R1 As DataRow
            Dim dtExistingRecord As DataTable

            Try
                strSql = ""
                For Each R1 In dt.Rows
                    strSql = "SELECT * FROM partsncapture " & Environment.NewLine
                    strSql &= "WHERE Cust_ID = " & iCustID & " AND PSPrice_ID = " & R1("PSPrice_ID").ToString & Environment.NewLine
                    dtExistingRecord = Me._objMySqlData.GetDataTable(strSql)
                    If dtExistingRecord.Rows.Count = 0 Then
                        strSql = "INSERT INTO partsncapture (Cust_ID, PSPrice_ID, CaptureSN " & Environment.NewLine
                        strSql &= ") VALUES ( " & Environment.NewLine
                        strSql &= iCustID.ToString & ", " & R1("PSPrice_ID").ToString & ", " & R1("CollectSN").ToString
                        strSql &= ")"
                    Else
                        strSql = "UPDATE partsncapture SET CaptureSN = " & R1("CollectSN").ToString & Environment.NewLine
                        strSql &= "WHERE PSNC_ID = " & dtExistingRecord.Rows(0)("PSNC_ID").ToString
                    End If
                    i = Me._objMySqlData.ExecuteNonQuery(strSql)
                Next R1

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '***************************************************************************************
        Public Function GetBillCodesForReportMappedData(ByVal iBillColdeID As Integer) As DataTable

            Dim strSql As String = ""

            Try
                strSql = "SELECT TFBM_ID,TFB_ID,BillCode_ID FROM tracfonebillcodemap WHERE BillCode_ID=" & iBillColdeID & ";"
                Return Me._objMySqlData.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ''***************************************************************************************
        'Public Function Found_BillCodeID(ByVal iBillColdeID As Integer) As DataTable
        '    Dim strSql As String = ""

        '    Try
        '        strSql = "select * from lbillcodes where billcode_ID=" & iBillColdeID & ";"
        '        Return Me._objMySqlData.GetDataTable(strSql)

        '    Catch ex As Exception
        '        Throw ex

        '    End Try
        'End Function


        '***************************************************************************************
        Public Function Found_TFBID(ByVal iTFB_ID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "select * from  tracfonebillcode where tfb_ID=" & iTFB_ID & ";"
                Return Me._objMySqlData.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************
        Public Function DeleteMapInTracfoneBillCodeMap(ByVal iTFBM_ID As Integer) As Integer
            Dim strSql As String = ""
            Try
                strSql = "DELETE FROM TracfoneBillCodeMap WHERE tfbm_ID=" & iTFBM_ID & ";"
                Return Me._objMySqlData.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************
        Public Function UpdateMapInTracfoneBillCodeMap(ByVal iTFBM_ID As Integer, _
                                                       ByVal iBillCode_ID As Integer, _
                                                       ByVal iTFB_ID As Integer, _
                                                       ByVal strDTime As String, _
                                                       ByVal iUserID As Integer) As Integer
            Dim strSql As String = ""
            Try
                strSql = "UPDATE TracfoneBillCodeMap SET Billcode_ID=" & iBillCode_ID & Environment.NewLine
                strSql &= ",tfb_ID=" & iTFB_ID & Environment.NewLine
                strSql &= ",LastUpdateDT='" & strDTime & "'" & Environment.NewLine
                strSql &= ",LastUpdateUserID=" & iUserID & Environment.NewLine
                strSql &= " WHERE tfbm_ID=" & iTFBM_ID & ";"

                Return Me._objMySqlData.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************
        Public Function InsertMapInTracfoneBillCodeMap(ByVal iBillCode_ID As Integer, _
                                                       ByVal iTFB_ID As Integer, _
                                                       ByVal strDTime As String, _
                                                       ByVal iUserID As Integer) As Integer

            Dim strSql As String = ""
            Try
                strSql = "INSERT INTO TracfoneBillCodeMap (TFB_ID,Billcode_ID,LastUpdateDT,LastUpdateUserID)" & Environment.NewLine
                strSql &= " VALUES (" & iTFB_ID & "," & iBillCode_ID & ",'" & strDTime & "'," & iUserID & ");"

                Return Me._objMySqlData.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************

    End Class

End Namespace