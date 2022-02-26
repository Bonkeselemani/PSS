Imports PSS.Data.Production
Imports eInfoDesigns.dbProvider.MySqlClient

Namespace Buisness

    Public Class Pricing
        Private _objDataProc As MySql4.DataProc

        '*********************************************************************************
        Public Sub New()
            Try
                _objDataProc = New MySql4.DataProc(ConfigFile.GetConnectionInfo)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*********************************************************************************

#Region "Labor"

        '*********************************************************************************
        Public Function GetPrcGrpType(ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                'PGType_ID, PGType_Desc
                strSql = "SELECT * FROM lpgtype "
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--Select--"}, True)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '*********************************************************************************
        Public Function GetPrcType(ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                'PrcType_ID, PrcType_Desc
                strSql = "SELECT * FROM lpricingtype "
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--Select--"}, True)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '*********************************************************************************
        Public Function GetPrcGrp(ByVal booAddSelectRow As Boolean, ByVal iProdID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT * FROM lpricinggroup WHERE Prod_ID = " & iProdID & Environment.NewLine
                strSql &= "ORDER BY PrcGroup_LDesc"
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "", "--Select--"}, True)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '*********************************************************************************
        Public Function GetLaborLevel(ByVal booAddSelectRow As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT * FROM llaborlvl WHERE Active = 1 ORDER BY LaborLvl_Desc "
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--Select--"}, True)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '*********************************************************************************
        Public Function GetProdGrp(ByVal booAddSelectRow As Integer, ByVal iProdID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT ProdGrp_ID, ProdGrp_LDesc, Prod_ID " & Environment.NewLine
                strSql &= "FROM lprodgrp WHERE Prod_ID = " & iProdID & Environment.NewLine
                strSql &= "ORDER BY ProdGrp_LDesc"
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--Select--", "0"}, True)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '*********************************************************************************
        Public Function GetLaborPrice(ByVal iPrcGrpID As Integer, ByVal iProdID As Integer, _
                                      Optional ByVal iProdGrpID As Integer = 0, _
                                      Optional ByVal iLaborLevelID As Integer = 0) As DataTable
            Dim strSql As String
            Try
                strSql = "SELECT LaborPrc_RegPrc AS 'Reg', LaborPrc_WrtyPrc as 'Warranty'" & Environment.NewLine
                strSql &= ", lprodgrp.ProdGrp_LDesc" & Environment.NewLine
                strSql &= ", if(llaborlvl.laborlvl_id = 0, 'Flat Rate', LaborLvl_Desc) as LaborLvl_Desc " & Environment.NewLine
                strSql &= ", Prod_Desc, LaborPrc_Desc " & Environment.NewLine
                strSql &= ", LastUpdateDT, User_Fullname as 'User', lprodgrp.Prod_ID" & Environment.NewLine
                strSql &= ", tlaborprc.LaborPrc_ID, tlaborprc.PrcGroup_ID, tlaborprc.LaborLvl_ID, tlaborprc.ProdGrp_ID " & Environment.NewLine
                strSql &= "FROM tlaborprc " & Environment.NewLine
                strSql &= "INNER JOIN lprodgrp ON tlaborprc.prodgrp_id = lprodgrp.prodgrp_id" & Environment.NewLine
                strSql &= "INNER JOIN llaborlvl ON tlaborprc.laborlvl_id = llaborlvl.laborlvl_id" & Environment.NewLine
                strSql &= "INNER JOIN lproduct ON lprodgrp.Prod_ID = lproduct.Prod_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN security.tusers ON tlaborprc.LastUpdateUserID = security.tusers.User_ID" & Environment.NewLine
                strSql &= "WHERE tlaborprc.prcgroup_id = " & iPrcGrpID & Environment.NewLine
                strSql &= "AND lprodgrp.prod_id = " & iProdID & Environment.NewLine
                If iProdGrpID > 0 Then strSql &= "AND tlaborprc.prodgrp_id = " & iProdGrpID & Environment.NewLine
                If iLaborLevelID > 0 Then strSql &= "AND tlaborprc.laborlvl_id = " & iLaborLevelID & Environment.NewLine
                strSql &= "ORDER BY lprodgrp.prodgrp_LDesc "

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************************
        Public Function GetLaborPriceExcpt(ByVal iPrcGrpID As Integer) As DataTable
            Dim strSql As String
            Try
                strSql = "SELECT lpricinggroup.PrcGroup_LDesc AS 'Pricing Group', lprodgrp.ProdGrp_LDesc as 'Product Group'" & Environment.NewLine
                strSql &= ", lbillcodes.BillCode_Desc as 'Billcode', tbillexcpttype.BillExcptType_Desc as 'Exception Type' " & Environment.NewLine
                strSql &= "FROM tbillexcpt " & Environment.NewLine
                strSql &= "INNER JOIN lpricinggroup ON tbillexcpt.PrcGroup_ID = lpricinggroup.PrcGroup_ID " & Environment.NewLine
                strSql &= " INNER JOIN lprodgrp ON tbillexcpt.ProdGrp_ID = lprodgrp.ProdGrp_ID " & Environment.NewLine
                strSql &= " INNER JOIN lbillcodes ON tbillexcpt.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                strSql &= " INNER JOIN tbillexcpttype ON tbillexcpt.BillExcptType_ID = tbillexcpttype.BillExcptType_ID " & Environment.NewLine
                strSql &= " WHERE tbillexcpt.PrcGroup_ID = " & iPrcGrpID & Environment.NewLine
                strSql &= " ORDER BY ProdGrp_LDesc, BillCode_Desc"

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************************
        Public Function SetLaborPrice(ByVal strLaborPrcDesc As String, _
                                      ByVal iPrcGrpID As Integer, _
                                      ByVal iProdGrpID As Integer, _
                                      ByVal iLaborLvlID As Integer, _
                                      ByVal dbRegLabor As Double, _
                                      ByVal dbWrtyLabor As Double, _
                                      ByVal iUserID As Integer) As Integer
            Dim strSql, strTodayDateTime As String
            Dim dt As DataTable
            Dim i As Integer = 0

            Try
                strTodayDateTime = Generic.MySQLServerDateTime(1)

                strSql = "SELECT * FROM tlaborprc " & Environment.NewLine
                strSql &= " WHERE PrcGroup_ID = " & iPrcGrpID & Environment.NewLine
                strSql &= " AND ProdGrp_ID = " & iProdGrpID & Environment.NewLine
                strSql &= "AND LaborLvl_ID = " & iLaborLvlID & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 1 Then
                    Throw New Exception("Duplicate entry. Please contact IT.")
                ElseIf dt.Rows.Count = 0 Then
                    strSql = "INSERT INTO tlaborprc ( " & Environment.NewLine
                    strSql &= "LaborPrc_Desc, LaborPrc_RegPrc, LaborPrc_WrtyPrc " & Environment.NewLine
                    strSql &= ", PrcGroup_ID, LaborLvl_ID, ProdGrp_ID " & Environment.NewLine
                    strSql &= ", LastUpdateDT, LastUpdateUserID " & Environment.NewLine
                    strSql &= ") VALUES ( " & Environment.NewLine
                    strSql &= " '" & strLaborPrcDesc & "'" & Environment.NewLine
                    strSql &= ", " & dbRegLabor & Environment.NewLine
                    strSql &= ", " & dbWrtyLabor & Environment.NewLine
                    strSql &= ", " & iPrcGrpID & Environment.NewLine
                    strSql &= ", " & iLaborLvlID & Environment.NewLine
                    strSql &= ", " & iProdGrpID & Environment.NewLine
                    strSql &= ", '" & strTodayDateTime & "', " & iUserID & Environment.NewLine
                    strSql &= ")"
                Else
                    If Convert.ToDouble(dt.Rows(0)("LaborPrc_RegPrc")) = dbRegLabor AndAlso Convert.ToDouble(dt.Rows(0)("LaborPrc_WrtyPrc")) = dbWrtyLabor Then Throw New Exception("No update needed.")
                    If Not IsDBNull(dt.Rows(0)("LaborPrc_Desc")) Then strLaborPrcDesc = dt.Rows(0)("LaborPrc_Desc").ToString Else strLaborPrcDesc = ""

                    strSql = "UPDATE tlaborprc  " & Environment.NewLine
                    strSql &= "SET LaborPrc_RegPrc = " & dbRegLabor & Environment.NewLine
                    strSql &= ", LaborPrc_WrtyPrc = " & dbWrtyLabor & Environment.NewLine
                    strSql &= ", LastUpdateDT = '" & strTodayDateTime & "', LastUpdateUserID = " & iUserID & Environment.NewLine
                    strSql &= " WHERE LaborPrc_ID = " & dt.Rows(0)("LaborPrc_ID").ToString & Environment.NewLine
                End If

                i = Me._objDataProc.ExecuteNonQuery(strSql)

                i = WriteLaborPriceUpdateHist(strLaborPrcDesc, dbRegLabor, dbWrtyLabor, iPrcGrpID, iProdGrpID, iLaborLvlID, strTodayDateTime, iUserID)

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '*********************************************************************************
        Private Function WriteLaborPriceUpdateHist(ByVal strLaborPrcDesc As String, _
                                                   ByVal dbRegPrice As Double, _
                                                   ByVal dbWrtyPrice As Double, _
                                                   ByVal iPrcGrpID As Integer, _
                                                   ByVal iProdGrpID As Integer, _
                                                   ByVal iLaborLvlID As Integer, _
                                                   ByVal strDateTime As String, _
                                                   ByVal iUserID As Integer) As Integer
            Dim strSql As String = ""
            Try
                strSql = "INSERT INTO tlaborprc_hist ( " & Environment.NewLine
                strSql &= "LaborPrc_Desc, LaborPrc_RegPrc" & Environment.NewLine
                strSql &= ", LaborPrc_WrtyPrc, PrcGroup_ID" & Environment.NewLine
                strSql &= ", ProdGrp_ID, LaborLvl_ID" & Environment.NewLine
                strSql &= ", LastUpdateDT, LastUpdateUserID" & Environment.NewLine
                strSql &= ") VALUES (" & Environment.NewLine
                strSql &= " '" & strLaborPrcDesc & "', " & dbRegPrice & Environment.NewLine
                strSql &= ", " & dbWrtyPrice & ", " & iPrcGrpID & Environment.NewLine
                strSql &= ", " & iProdGrpID & ", " & iLaborLvlID & Environment.NewLine
                strSql &= ", '" & strDateTime & "', " & iUserID & Environment.NewLine
                strSql &= ")"
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************************
        Public Function IsPricingGroupExisted(ByVal iProdID As Integer, ByVal strPrcGrpLongDesc As String) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT * FROM lpricinggroup " & Environment.NewLine
                strSql &= "WHERE PrcGroup_LDesc = '" & strPrcGrpLongDesc & "' AND Prod_ID = " & iProdID & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then Return True Else Return False
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '*********************************************************************************
        Public Function AddPricingGroup(ByVal strPrcGrpShortDesc As String, _
                                        ByVal strPrcGrpLongDesc As String, _
                                        ByVal iPrcGrpTypeID As Integer, _
                                        ByVal iProdID As Integer, _
                                        ByVal iPrcTypeID As Integer, _
                                        ByVal iUserID As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "INSERT INTO lpricinggroup ( " & Environment.NewLine
                strSql &= " PrcGroup_SDesc, PrcGroup_LDesc, PrcGroup_Type" & Environment.NewLine
                strSql &= ", Prod_ID, PrcType_ID, LastUpdateDT, LastUpdateUserID " & Environment.NewLine
                strSql &= ") VALUES ( " & Environment.NewLine
                strSql &= "'" & strPrcGrpShortDesc & "', '" & strPrcGrpLongDesc & "', " & iPrcGrpTypeID & Environment.NewLine
                strSql &= ", " & iProdID & ", " & iPrcTypeID & ", now(), " & iUserID & Environment.NewLine
                strSql &= ")"
                Return Me._objDataProc.idTransaction(strSql, "lpricinggroup")
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************************

#End Region

#Region "Part"


        '**************************************************************************************************************
        Public Shared Function GetPartInfo(ByVal strPartNo As String) As DataRow
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc
            Dim dt As DataTable

            Try
                strSql = "SELECT * " & Environment.NewLine
                strSql &= "FROM lpsprice WHERE PSPrice_Number = '" & strPartNo & "'"
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                dt = objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then Return dt.Rows(0) Else Return Nothing
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Function

        '**************************************************************************************************************
        Public Shared Function GetPartCount(ByVal strPartNo As String) As Integer
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                strSql = "SELECT count(*) as cnt " & Environment.NewLine
                strSql &= "FROM lpsprice WHERE PSPrice_Number = '" & strPartNo & "'"
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************************************************************
        Public Shared Function GetPSPriceID(ByVal strPartNo As String) As Integer
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc
            Dim dt As DataTable

            Try
                strSql = "SELECT PSPrice_ID " & Environment.NewLine
                strSql &= "FROM lpsprice WHERE PSPrice_Number = '" & strPartNo & "'"
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                dt = objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then Return dt.Rows(0)("PSPrice_ID") Else Return 0
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '**************************************************************************************************************
        Public Shared Function GetPrices() As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT PSPrice_ID AS Id, PSPrice_Number AS 'Part Number', " & Environment.NewLine
                strSql &= "PSPrice_Desc AS Description, PSPrice_AvgCost AS 'Avg. Cost', " & Environment.NewLine
                strSql &= "PSPrice_StndCost AS 'Std. Cost'" & Environment.NewLine
                strSql &= ", if(PSPrice_InventoryPart = 1, 'YES', 'NO') as 'Inventory Part'" & Environment.NewLine
                strSql &= ", if(PSPrice_ConsignedPart = 1, 'YES', 'NO') as 'Consigned Part'" & Environment.NewLine
                strSql &= ", PSPrice_MaxQty as 'Max Qty' " & Environment.NewLine
                strSql &= ", MatGrp_WrtyClaim as 'Material Group' " & Environment.NewLine
                strSql &= ", if(RVFlag = 1, 'Yes', 'No') as 'RV Part?' " & Environment.NewLine
                strSql &= "FROM lpsprice ORDER BY PSPrice_Number, PSPrice_Desc;"
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************************************************************
        Public Shared Sub InsertPrice(ByVal pNum As String, ByVal pDesc As String, ByVal aCost As Double _
                                    , ByVal sCost As Double, ByVal iInvFlg As Integer, ByVal iCPFlg As Integer _
                                    , ByVal iMaxQty As Integer, ByVal strMaterialGrp As String)
            Dim strSql As String = ""
            Dim iRVFlag As Integer = 0

            Try
                If strMaterialGrp.Trim = "1" OrElse pNum.Trim.ToLower.EndsWith("_rv") Then iRVFlag = 1
                strSql = "INSERT INTO lpsprice ( " & Environment.NewLine
                strSql &= " PSPrice_Number, PSPrice_Desc, PSPrice_AvgCost, PSPrice_StndCost, PSPrice_InventoryPart" & Environment.NewLine
                strSql &= ", PSPrice_ConsignedPart, PSPrice_MaxQty, MatGrp_WrtyClaim, RVFlag " & Environment.NewLine
                strSql &= ") VALUES (" & Environment.NewLine
                strSql &= "'" & pNum & "','" & pDesc & "'," & aCost & "," & sCost & ", " & iInvFlg & Environment.NewLine
                strSql &= ", " & iCPFlg & ", " & iMaxQty & ", '" & strMaterialGrp & "', " & iRVFlag & Environment.NewLine
                strSql &= ");"
                SetData(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '**************************************************************************************************************
        Public Shared Sub UpdatePrice(ByVal id As Integer, ByVal pNum As String, ByVal pDesc As String, ByVal aCost As Double _
                                    , ByVal sCost As Double, ByVal iInvFlg As Integer, ByVal iCPFlg As Integer _
                                    , ByVal iMaxQty As Integer, ByVal strMaterialGrp As String)

            Dim strSql As String
            Dim iRVFlag As Integer = 0

            Try
                If strMaterialGrp.Trim = "1" OrElse pNum.Trim.ToLower.EndsWith("_rv") Then iRVFlag = 1
                strSql = "UPDATE lpsprice " & Environment.NewLine
                strSql &= "SET PSPrice_Number = '" & pNum & "' " & Environment.NewLine
                strSql &= ", PSPrice_Desc = '" & pDesc & "'" & Environment.NewLine
                strSql &= ", PSPrice_AvgCost = " & aCost & "" & Environment.NewLine
                strSql &= ", PSPrice_StndCost = " & sCost & "" & Environment.NewLine
                strSql &= ", PSPrice_InventoryPart = " & iInvFlg & "" & Environment.NewLine
                strSql &= ", PSPrice_ConsignedPart = " & iCPFlg & "" & Environment.NewLine
                strSql &= ", PSPrice_MaxQty = " & iMaxQty & "" & Environment.NewLine
                strSql &= ", MatGrp_WrtyClaim = '" & strMaterialGrp & "' " & Environment.NewLine
                strSql &= ", RVFlag = " & iRVFlag & " " & Environment.NewLine
                strSql &= "WHERE PSPrice_ID = " & id & ";"

                SetData(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function DeletePrice(ByVal id As Integer) As Boolean
            Dim strSql As String = "SELECT Count(PSPrice_ID) FROM tpsmap WHERE PSPrice_ID = " & id & ";"
            If GetDataTable(strSql).Rows(0)(0) = 0 Then
                strSql = "DELETE FROM lpsprice WHERE PSPrice_ID = " & id & ";"
                SetData(strSql)
                Return True
            Else
                Return False
            End If
        End Function
#End Region

#Region "Shared Data Processing"
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
#End Region

#Region "Set Max Charge To Rep"

        ''*********************************************************************************
        'Public Function GetMaxChargeToRepair(ByVal iCustID As Integer, ByVal iModelID As Integer) As DataTable
        '    Dim strSql As String = ""

        '    Try
        '        'CMPM_ID, Cust_ID, Model_ID, CMPM_Price, CMPM_AddDate, CMPM_AddByUserID
        '        strSql = "SELECT * FROM custmaxprice_model " & Environment.NewLine
        '        strSql &= "WHERE Cust_ID = " & iCustID & " AND Model_ID = " & iModelID
        '        Return Me._objDataProc.GetDataTable(strSql)
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function

        ''*********************************************************************************
        'Public Function SetMaxChargeToRepair(ByVal iCustID As Integer, ByVal iModelID As Integer, _
        '                                     ByVal dbMaxPrice As Double, ByVal iUserID As Integer, _
        '                                     ByRef strMsg As String) As Integer
        '    Dim strSql, strDateTime As String
        '    Dim dt As DataTable
        '    Dim i As Integer = 0

        '    Try
        '        strMsg = "" : strSql = "" : strDateTime = Generic.MySQLServerDateTime(1)
        '        dt = GetMaxChargeToRepair(iCustID, iModelID)
        '        If dt.Rows.Count > 1 Then
        '            Throw New Exception("Duplicate entry on maxium price to repair. Please contact IT.")
        '        ElseIf dt.Rows.Count = 1 AndAlso Convert.ToDouble(dt.Rows(0)("CMPM_Price")) = dbMaxPrice Then
        '            '  strMsg = "No update needed on maxium price to repair."
        '        ElseIf dt.Rows.Count = 1 AndAlso Convert.ToDouble(dt.Rows(0)("CMPM_Price")) <> dbMaxPrice Then
        '            strSql = "UPDATE custmaxprice_model  " & Environment.NewLine
        '            strSql &= "SET CMPM_Price = " & dbMaxPrice & Environment.NewLine
        '            strSql &= ", CMPM_AddDate = '" & strDateTime & "', CMPM_AddByUserID = " & iUserID & Environment.NewLine
        '            strSql &= "WHERE CMPM_ID = " & dt.Rows(0)("CMPM_ID") & Environment.NewLine
        '            i = Me._objDataProc.ExecuteNonQuery(strSql)
        '            If i > 0 Then WriteMaxPriceToRepairHistory(iCustID, iModelID, dbMaxPrice, strDateTime, iUserID)
        '        Else
        '            strSql = "INSERT custmaxprice_model ( " & Environment.NewLine
        '            strSql &= " Cust_ID, Model_ID, CMPM_Price" & Environment.NewLine
        '            strSql &= ", CMPM_AddDate, CMPM_AddByUserID" & Environment.NewLine
        '            strSql &= ") VALUES (" & Environment.NewLine
        '            strSql &= iCustID & ", " & iModelID & ", " & dbMaxPrice & Environment.NewLine
        '            strSql &= ", '" & strDateTime & "', " & iUserID & Environment.NewLine
        '            strSql &= ") "
        '            i = Me._objDataProc.ExecuteNonQuery(strSql)
        '            If i > 0 Then WriteMaxPriceToRepairHistory(iCustID, iModelID, dbMaxPrice, strDateTime, iUserID)
        '        End If

        '    Catch ex As Exception
        '        Throw ex
        '    Finally
        '        Generic.DisposeDT(dt)
        '    End Try
        'End Function

        '*********************************************************************************
        Public Function WriteMaxPriceToRepairHistory(ByVal iCustID As Integer, ByVal iModelID As Integer, _
                                      ByVal dbMaxPrice As Double, ByVal strDateTime As String, ByVal iUserID As Integer) As Integer
            Dim strSql As String

            Try
                'CMPMH_ID, Cust_ID, Model_ID, CMPM_Price, CMPM_AddDate, CMPM_AddByUserID
                strSql = "INSERT custmaxprice_model_hist ( " & Environment.NewLine
                strSql &= " Cust_ID, Model_ID, CMPM_Price" & Environment.NewLine
                strSql &= ", CMPM_AddDate, CMPM_AddByUserID" & Environment.NewLine
                strSql &= ") VALUES (" & Environment.NewLine
                strSql &= iCustID & ", " & iModelID & ", " & dbMaxPrice & Environment.NewLine
                strSql &= ", '" & strDateTime & "', " & iUserID & Environment.NewLine
                strSql &= ") "
                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************************

#End Region

    End Class

End Namespace
