Option Explicit On 

Imports System.Windows.Forms

Namespace Buisness
    Public Class CustMaintNew

        Private _objDataProc As DBQuery.DataProc

        '****************************************************************
        Public Sub New()
            Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
        End Sub

        '****************************************************************
        Protected Overrides Sub Finalize()
            Me._objDataProc = Nothing
            MyBase.Finalize()
        End Sub

        '****************************************************************
        Public Function LoadAllDatatable(ByVal strTableName As String) As DataTable
            Dim strSql As String
            Dim dt1 As DataTable

            Try
                '*******************************
                '1:: Get lparent table
                '*******************************
                strSql = "SELECT * FROM " & strTableName & ";"
                dt1 = Me._objDataProc.GetDataTable(strSql)
                dt1.TableName = strTableName.ToString

                Return dt1
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

        '****************************************************************
        Public Function GetParentCompany(ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                'PCo_ID, PCo_Name, PCo_EndUser, PCo_MotoCode, PCo_DefMarkUp, PCo_DefRUR
                ', PCo_DefNER, PCo_FlatRateParts, PCo_DefWrtyDays, PssWrtyLabor_ID
                ', PSSWrtyParts_ID, PrcGroup_ID, PConv_ID, PCo_Active
                strSql = "SELECT * FROM lparentco ORDER BY PCo_Name " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--Select--"}, True)
                Return dt
            Catch ex As Exception : Throw ex
            Finally : Generic.DisposeDT(dt)
            End Try
        End Function

        '****************************************************************
        Public Function GetPricingGroup(ByVal booAddSelectRow As Boolean, _
                                        Optional ByVal iProdID As Integer = 0) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                'PrcGroup_ID, PrcGroup_SDesc, PrcGroup_LDesc, PrcGroup_Type, Prod_ID, ProdGrp_ID
                ', PrcType_ID, Cust_ID, LastUpdateDT, LastUpdateUserID
                strSql = "SELECT * FROM lpricinggroup "
                If iProdID > 0 Then strSql &= "WHERE Prod_ID = " & iProdID & Environment.NewLine
                strSql &= "ORDER BY prcGroup_LDesc"
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "", "--Select--"}, True)
                Return dt
            Catch ex As Exception : Throw ex
            Finally : Generic.DisposeDT(dt)
            End Try
        End Function

        '****************************************************************
        Public Function GetPSSPartWarranty(ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                'PSSWrtyParts_ID, PSSWrtyParts_Desc
                strSql = "SELECT * FROM lpsswrtyparts ORDER BY PSSWrtyParts_Desc"
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--Select--"}, True)
                Return dt
            Catch ex As Exception : Throw ex
            Finally : Generic.DisposeDT(dt)
            End Try
        End Function

        '****************************************************************
        Public Function GetPSSLaborWarranty(ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                'PSSWrtyLabor_ID, PSSWrtyLabor_Desc
                strSql = "SELECT * FROM lpsswrtylabor ORDER BY PSSWrtyLabor_Desc"
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--Select--"}, True)
                Return dt
            Catch ex As Exception : Throw ex
            Finally : Generic.DisposeDT(dt)
            End Try
        End Function

        '****************************************************************
        Public Function GetCustomersHasName1Only(ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT * FROM tcustomer WHERE Cust_Name2 is null ORDER BY cust_Name1"
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--Select--"}, True)
                Return dt
            Catch ex As Exception : Throw ex
            Finally : Generic.DisposeDT(dt)
            End Try
        End Function

        '****************************************************************
        Public Function GetPayMethod(ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                'Pay_ID, Pay_Desc
                strSql = "SELECT * FROM lpaymethod ORDER BY Pay_Desc"
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--Select--"}, True)
                Return dt
            Catch ex As Exception : Throw ex
            Finally : Generic.DisposeDT(dt)
            End Try
        End Function

        '****************************************************************
        Public Function GetSalePerson(ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Try
                strSql = "SELECT SlsP_ID, concat(SlsP_FirstName, '-', SlsP_LastName) as Name FROM tslsp WHERE SlsP_SSNum <> 'DELETE';"
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--Select--"}, True)
                Return dt
            Catch ex As Exception : Throw ex
            Finally : Generic.DisposeDT(dt)
            End Try
        End Function

        '****************************************************************
        Public Function CreateYesNoTable() As DataTable
            Dim dt1 As DataTable
            Dim R1 As DataRow

            Try

                dt1 = New DataTable("YesNo")
                Generic.AddNewColumnToDataTable(dt1, "ID", "System.Int32", "0")
                Generic.AddNewColumnToDataTable(dt1, "Desc", "System.String", "")
                R1 = dt1.NewRow
                R1("ID") = 1
                R1("Desc") = "YES"
                dt1.Rows.Add(R1)
                dt1.AcceptChanges()
                R1 = Nothing
                R1 = dt1.NewRow
                R1("ID") = 0
                R1("Desc") = "NO"
                dt1.Rows.Add(R1)
                dt1.AcceptChanges()
                R1 = Nothing

                Return dt1
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
            End Try
        End Function

        '****************************************************************
        Public Function GetInvoiceDateTypes(ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                'InvDateType_ID, InvDateType_Desc
                strSql = "SELECT * FROM invoicedatetype ORDER BY InvDateType_Desc"
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow = True Then dt.LoadDataRow(New Object() {"0", "--Select--"}, True)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '****************************************************************
        Public Function GetActiveDepts(ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT DepartmentID, DepartmentDesc FROM security.tlegiantdeptdata WHERE Active = 1 ORDER BY DepartmentDesc"
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--Select--"}, True)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '****************************************************************
        Public Function GetAggBillcodesByCustID(ByVal iCustID As Integer) As DataTable
            Dim strSql, strProdIDs As String
            Dim dt As DataTable
            Dim R1 As DataRow

            Try
                strSql = "" : strProdIDs = ""
                strSql = "SELECT Prod_ID FROM tcusttoprice WHERE Cust_ID = " & iCustID
                dt = Me._objDataProc.GetDataTable(strSql)
                For Each R1 In dt.Rows
                    If strProdIDs.Trim.Length > 0 Then strProdIDs &= ", "
                    strProdIDs &= R1("Prod_ID").ToString
                Next R1

                strSql = "SELECT Billcode_ID, Billcode_Desc " & Environment.NewLine
                strSql &= "FROM lbillcodes " & Environment.NewLine
                strSql &= "WHERE Device_ID in ( " & strProdIDs & ") AND AggBill = 1"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************
        Public Function GetAggChargeByCustomer(ByVal iCustID As Integer) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT Billcode_Desc as 'Billcode', tcab_Amount as 'Charge', Prod_Desc as 'Product', tcustaggregatebilling.BillCode_ID " & Environment.NewLine
                strSql &= "FROM tcustaggregatebilling " & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON tcustaggregatebilling.billcode_id = lbillcodes.billcode_id " & Environment.NewLine
                strSql &= "INNER JOIN lproduct ON lbillcodes.Device_ID = lproduct.Prod_ID " & Environment.NewLine
                strSql &= "WHERE Cust_ID = " & iCustID
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************
        Public Function InsertUpdateAggChargeByCustomer(ByVal iCustID As Integer, ByVal iBillcodeID As Integer, _
                                                        ByVal dbCharge As Double, ByVal iUserID As Integer) As Integer
            Dim strSql, strAction, strDateTime As String
            Dim dt As DataTable
            Dim i As Integer = 0

            Try
                strSql = "" : strAction = "" : strDateTime = Generic.MySQLServerDateTime(1)

                strSql = "SELECT * FROM tcustaggregatebilling WHERE Cust_ID = " & iCustID & " AND Billcode_ID = " & iBillcodeID
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 1 Then
                    MessageBox.Show("Duplicate record. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf dt.Rows.Count > 0 Then
                    If Convert.ToDouble(dt.Rows(0)("tcab_Amount")) = dbCharge Then
                        MessageBox.Show("No update needed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        strAction = "Update"
                        strSql = "UPDATE tcustaggregatebilling " & Environment.NewLine
                        strSql &= "SET tcab_Amount = " & dbCharge & ", LastUpdateDT = '" & strDateTime & "'" & Environment.NewLine
                        strSql &= ", LastUpdateUserID = " & iUserID & Environment.NewLine
                        strSql &= "WHERE tcab_ID = " & dt.Rows(0)("tcab_ID").ToString
                        i = Me._objDataProc.ExecuteNonQuery(strSql)
                        Me.WriteAggChargeHist(iCustID, iBillcodeID, dbCharge, strDateTime, iUserID, strAction)
                    End If
                Else
                    strAction = "Insert"
                    strSql = "INSERT INTO tcustaggregatebilling ( " & Environment.NewLine
                    strSql &= " billcode_id, tcab_Amount, Cust_ID" & Environment.NewLine
                    strSql &= ", LastUpdateDT, LastUpdateUserID " & Environment.NewLine
                    strSql &= ") VALUES (" & Environment.NewLine
                    strSql &= iBillcodeID & ", " & dbCharge & ", " & iCustID & Environment.NewLine
                    strSql &= ", '" & strDateTime & "', " & iUserID & Environment.NewLine
                    strSql &= ") " & Environment.NewLine

                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                    Me.WriteAggChargeHist(iCustID, iBillcodeID, dbCharge, strDateTime, iUserID, strAction)
                End If

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '****************************************************************
        Public Function DeleteAggChargeByCustomer(ByVal iCustID As Integer, ByVal iBillcodeID As Integer, ByVal iUserID As Integer) As Integer
            Dim strSql, strAction, strDateTime As String
            Dim dt As DataTable
            Dim i As Integer = 0

            Try
                strSql = "" : strAction = "" : strDateTime = Generic.MySQLServerDateTime(1)

                strSql = "SELECT * FROM tcustaggregatebilling WHERE Cust_ID = " & iCustID & " AND Billcode_ID = " & iBillcodeID
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 1 Then
                    MessageBox.Show("Duplicate record. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf dt.Rows.Count = 0 Then
                    MessageBox.Show("Record does not exist.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    strAction = "Delete"
                    strSql = "DELETE FROM tcustaggregatebilling " & Environment.NewLine
                    strSql &= "WHERE tcab_ID = " & dt.Rows(0)("tcab_ID").ToString

                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                    Me.WriteAggChargeHist(iCustID, iBillcodeID, Convert.ToDouble(dt.Rows(0)("tcab_Amount")), strDateTime, iUserID, strAction)
                End If

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '****************************************************************
        Private Function WriteAggChargeHist(ByVal iCustID As Integer, ByVal iBillcodeID As Integer, _
                                            ByVal dbCharge As Double, ByVal strDateTime As String, ByVal iUSerID As Integer, ByVal strAction As String) As Integer
            Dim strSql As String
            Try
                strSql = "INSERT INTO tcustaggregatebilling_hist ( " & Environment.NewLine
                strSql &= " billcode_id, tcab_Amount, Cust_ID" & Environment.NewLine
                strSql &= ", LastUpdateDT, LastUpdateUserID, Action" & Environment.NewLine
                strSql &= ") VALUES (" & Environment.NewLine
                strSql &= iBillcodeID & ", " & dbCharge & ", " & iCustID & Environment.NewLine
                strSql &= ", '" & strDateTime & "'" & ", " & iUSerID & ", '" & strAction & "'" & Environment.NewLine
                strSql &= ")" & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************
        Public Function GetStates(ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Try
                'State_ID, State_Short, State_Long, fk_cntry_ID
                strSql = "SELECT * FROM lstate ORDER BY State_Short ;"
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--Select--"}, True)
                Return dt
            Catch ex As Exception : Throw ex
            Finally : Generic.DisposeDT(dt)
            End Try
        End Function

        '****************************************************************
        Public Function GetCountries(ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Try
                'Cntry_ID, Cntry_Name, Cntry_ShortName, Cntry_Name2, Cntry_Name3
                strSql = "SELECT * FROM lcountry ORDER BY Cntry_ShortName ;"
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "", "--Select--"}, True)
                Return dt
            Catch ex As Exception : Throw ex
            Finally : Generic.DisposeDT(dt)
            End Try
        End Function

        '****************************************************************
        Public Function GetPartInventoryMethoid(ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Try
                'Invtrymdth_ID, Invtrymdth_Desc
                strSql = "SELECT * FROM linvtrymethod ORDER BY Invtrymdth_Desc ;"
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--Select--"}, True)
                Return dt
            Catch ex As Exception : Throw ex
            Finally : Generic.DisposeDT(dt)
            End Try
        End Function

        '****************************************************************
        Public Function GetCreditCardTypes(ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Try
                'CCType_ID, CCType_Desc, CCType_Numb, CCType_SCLength, CCType_Length, CCType_Length2, CCType_Prefix1, CCType_Prefix2, CCType_PrefixRange
                strSql = "SELECT * FROM lcctype ORDER BY CCType_Desc ;"
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--Select--"}, True)
                Return dt
            Catch ex As Exception : Throw ex
            Finally : Generic.DisposeDT(dt)
            End Try
        End Function

        '****************************************************************
        Public Function GetParentCompanyByName(ByVal strNewPCoName As String) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "Select * FROM lparentco WHERE PCo_name = '" & strNewPCoName & "' "
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception : Throw ex
            End Try
        End Function

        '****************************************************************
        Public Function UpdateParentCompanyName(ByVal iPCoID As Integer, ByVal strNewPCoName As String) As Integer
            Dim strSql As String = ""

            Try
                strSql = "UPDATE lparentco SET PCo_name = '" & strNewPCoName & "' WHERE pco_id = " & iPCoID
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception : Throw ex
            End Try
        End Function

        '****************************************************************
        Public Function SaveParentCompany(ByRef iPCoID As Integer, ByVal strPCoName As String, ByVal strMotoCode As String, _
                                          ByVal iPrcGroupID As Integer, ByVal dbMarkUp As Double, _
                                          ByVal dbRUR As Double, ByVal dbNER As Double, _
                                          ByVal iWrtyDays As Integer, ByVal iWrtyPartsID As Integer, _
                                          ByVal iWrtyLaborID As Integer, ByVal iEndUser As Integer, _
                                          ByVal iActive As Integer, ByVal iFlatRateParts As Integer) As Integer
            Dim strSql As String = ""
            Dim i As Integer

            Try
                'PCo_ID, PCo_Name, PCo_EndUser, PCo_MotoCode, PCo_DefMarkUp, PCo_DefRUR
                ', PCo_DefNER, PCo_FlatRateParts, PCo_DefWrtyDays, PssWrtyLabor_ID
                ', PSSWrtyParts_ID, PrcGroup_ID, PConv_ID, PCo_Active
                If iPCoID > 0 Then 'UPDATE
                    strSql = "UPDATE lparentco " & Environment.NewLine
                    strSql &= "SET PCo_MotoCode = '" & strMotoCode & "' " & Environment.NewLine
                    strSql &= ", PCo_DefMarkUp = " & dbMarkUp & ", PCo_DefRUR = " & dbRUR & Environment.NewLine
                    strSql &= ", PCo_DefNER = " & dbNER & ", PCo_DefWrtyDays = " & iWrtyDays & Environment.NewLine
                    strSql &= ", PSSWrtyParts_ID = " & iWrtyPartsID & ", PSSWrtyLabor_ID = " & iWrtyLaborID & Environment.NewLine
                    strSql &= ", PrcGroup_ID = " & iPrcGroupID & ", PCo_EndUser = " & iEndUser & Environment.NewLine
                    strSql &= ", PCo_Active = " & iActive & ", PCo_FlatRateParts = " & iFlatRateParts & Environment.NewLine
                    strSql &= "WHERE PCo_ID = " & iPCoID
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                Else
                    strSql = "INSERT INTO lparentco (" & Environment.NewLine
                    strSql &= "PCo_Name, PCo_MotoCode, PCo_DefMarkUp, PCo_DefRUR, PCo_DefNER, PCo_DefWrtyDays " & Environment.NewLine
                    strSql &= ", PSSWrtyParts_ID, PSSWrtyLabor_ID, PrcGroup_ID, PCo_EndUser, PCo_Active, PCo_FlatRateParts " & Environment.NewLine
                    strSql &= ") VALUES ( " & Environment.NewLine
                    strSql &= "'" & strPCoName & "', '" & strMotoCode & "', " & dbMarkUp & ", " & dbRUR & Environment.NewLine
                    strSql &= ", " & dbNER & ", " & iWrtyDays & ", " & iWrtyPartsID & ", " & iWrtyLaborID & Environment.NewLine
                    strSql &= ", " & iPrcGroupID & ", " & iEndUser & ", " & iActive & ", " & iFlatRateParts & Environment.NewLine
                    strSql &= ")"
                    iPCoID = Me._objDataProc.idTransaction(strSql, "lparentco")
                    i = iPCoID
                End If

                Return i
            Catch ex As Exception : Throw ex
            End Try
        End Function

        '****************************************************************
        Public Function UpdateCustFirstName(ByVal iCustID As Integer, ByVal strNewFirstName As String) As Integer
            Dim strSql As String = ""

            Try
                strSql = "UPDATE tcustomer SET cust_name1 = '" & strNewFirstName & "' WHERE Cust_ID = " & iCustID
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception : Throw ex
            End Try
        End Function

        '****************************************************************
        Public Function GetCustByFirstName(ByVal strCustFirstName As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT * FROM tcustomer WHERE cust_name1 = '" & strCustFirstName & "' "
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception : Throw ex
            End Try
        End Function

        '****************************************************************
        Public Function SaveCustomer(ByRef iCustID As Integer, ByVal strCustFName As String, _
                                     ByVal strCustLName As String, ByVal iRejectDays As Integer, _
                                     ByVal iRejTime As Integer, ByVal iRepNonWrty As Integer, _
                                     ByVal iReplLCD As Integer, ByVal iReceivingCrApp As Integer, _
                                     ByVal iShippingCrApp As Integer, ByVal iCollectSaleTax As Integer, _
                                     ByVal iInactive As Integer, ByVal iPayID As Integer, ByVal iPCoID As Integer, _
                                     ByVal iSalesPerson As Integer, ByVal iCustDetailInvoice As Integer, _
                                     ByVal iAggBilling As Integer, ByVal iReq100PercentAQL As Integer, _
                                     ByVal iDetailInvoiceDateType As Integer, ByVal iPredeterminePartNeed As Integer, _
                                     ByVal iDeptID As Integer, _
                                     ByVal strMemo As String, ByVal iUserID As Integer) As Integer
            Dim strSql, strDateTime As String
            Dim i As Integer = 0

            Try
                strDateTime = Generic.MySQLServerDateTime(1)

                If iCustID > 0 Then
                    strSql = "UPDATE tcustomer SET " & Environment.NewLine
                    strSql &= "Cust_Name1 = '" & strCustFName & "', Cust_RejectDays = " & iRejectDays & Environment.NewLine
                    If strCustLName.Trim.Length > 0 Then strSql &= ", Cust_Name2 = '" & strCustLName & "'" & Environment.NewLine
                    strSql &= ", Cust_RejectTimes = " & iRejTime & ", Cust_RepairNonWrty = " & iRepNonWrty & Environment.NewLine
                    strSql &= ", Cust_ReplaceLCD = " & iReplLCD & ", Cust_CrApproveRec = " & iReceivingCrApp & Environment.NewLine
                    strSql &= ", Cust_CrApproveShip = " & iShippingCrApp & ", Cust_CollSalesTax  = " & iCollectSaleTax & Environment.NewLine
                    strSql &= ", Cust_Inactive = " & iInactive & ", Pay_ID = " & iPayID & Environment.NewLine
                    strSql &= ", PCo_ID = " & iPCoID & ", SlsP_ID = " & iSalesPerson & Environment.NewLine
                    strSql &= ", Cust_InvoiceDetail = " & iCustDetailInvoice & ", Cust_AggBilling = " & iAggBilling & Environment.NewLine
                    strSql &= ", ReqAQLCheckOnAllUnit = " & iReq100PercentAQL & Environment.NewLine
                    strSql &= ", LastUpdateDT = '" & strDateTime & "', LastUpdateUserID = " & iUserID & Environment.NewLine
                    strSql &= ", InvDateType_ID = " & iDetailInvoiceDateType & ", PredeterminePartNeed = " & iPredeterminePartNeed & Environment.NewLine
                    strSql &= ", DepartmentID = " & iDeptID & Environment.NewLine
                    strSql &= ", Cust_Memo = '" & strMemo & "'" & Environment.NewLine
                    strSql &= " WHERE CUST_ID = " & iCustID
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                Else
                    strSql = "INSERT INTO tcustomer ( " & Environment.NewLine
                    strSql &= "Cust_Name1" & Environment.NewLine
                    If strCustLName.Trim.Length > 0 Then strSql &= ", Cust_Name2 " & Environment.NewLine
                    strSql &= ", Cust_RejectDays, Cust_RejectTimes, Cust_Inactive " & Environment.NewLine
                    strSql &= ", Cust_RepairNonWrty, Cust_ReplaceLCD, Cust_CrApproveRec" & Environment.NewLine
                    strSql &= ", Cust_CrApproveShip, Cust_CollSalesTax, Pay_ID, PCo_ID" & Environment.NewLine
                    strSql &= ", SlsP_ID, Cust_InvoiceDetail, Cust_Memo, Cust_AggBilling " & Environment.NewLine
                    strSql &= ", ReqAQLCheckOnAllUnit, LastUpdateDT, LastUpdateUserID " & Environment.NewLine
                    strSql &= ", InvDateType_ID, PredeterminePartNeed, DepartmentID " & Environment.NewLine
                    strSql &= ") VALUES ( " & Environment.NewLine
                    strSql &= "'" & strCustFName & "'" & Environment.NewLine
                    If strCustLName.Trim.Length > 0 Then strSql &= ", '" & strCustLName & "'" & Environment.NewLine
                    strSql &= ", " & iRejectDays & ", " & iRejTime & ", " & iInactive & Environment.NewLine
                    strSql &= ", " & iRepNonWrty & ", " & iReplLCD & ", " & iReceivingCrApp & Environment.NewLine
                    strSql &= ", " & iShippingCrApp & ", " & iCollectSaleTax & ", " & iPayID & ", " & iPCoID & Environment.NewLine
                    strSql &= ", " & iSalesPerson & ", " & iCustDetailInvoice & ", '" & strMemo & "', " & iAggBilling & Environment.NewLine
                    strSql &= ", " & iReq100PercentAQL & ", '" & strDateTime & "', " & iUserID & Environment.NewLine
                    strSql &= ", " & iDetailInvoiceDateType & ", " & iPredeterminePartNeed & ", " & iDeptID & Environment.NewLine
                    strSql &= ")"
                    iCustID = Me._objDataProc.idTransaction(strSql, "tcustomer")
                    i = iCustID
                End If

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************
        Public Function GetCustomerPssWrty(ByVal iCustID As Integer, ByVal iProdID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT * FROM tcustwrty WHERE Cust_ID = " & iCustID & " AND Prod_ID = " & iProdID
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************
        Public Function SaveCustomerWarranty(ByVal iCustID As Integer, ByVal iProdID As Integer, ByVal iDaysInWarranty As Integer, _
                                             ByVal iPSSWrtyPartsID As Integer, ByVal iPSSWrtyLaborID As Integer) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                dt = GetCustomerPssWrty(iCustID, iProdID)
                If dt.Rows.Count = 0 Then
                    strSql = "INSERT INTO tcustwrty ( " & Environment.NewLine
                    strSql &= "CustWrty_DaysinWrty, PSSWrtyParts_ID, PSSWrtyLabor_ID" & Environment.NewLine
                    strSql &= ", Prod_ID, Cust_ID " & Environment.NewLine
                    strSql &= ") VALUES (" & Environment.NewLine
                    strSql &= iDaysInWarranty & ", " & iPSSWrtyPartsID & ", " & iPSSWrtyLaborID & Environment.NewLine
                    strSql &= ", " & iProdID & ", " & iCustID & Environment.NewLine
                    strSql &= ") "
                    Return Me._objDataProc.ExecuteNonQuery(strSql)
                Else
                    strSql = "UPDATE tcustwrty SET CustWrty_DaysinWrty = " & iDaysInWarranty & Environment.NewLine
                    strSql &= ", PSSWrtyParts_ID = " & iPSSWrtyPartsID & ", PSSWrtyLabor_ID = " & iPSSWrtyLaborID & Environment.NewLine
                    strSql &= "WHERE Prod_ID = " & iProdID & " AND Cust_ID = " & iCustID & Environment.NewLine
                    Return Me._objDataProc.ExecuteNonQuery(strSql)
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '****************************************************************
        Public Function GetCustomerLocations(ByVal booAddSelectRow As Boolean, ByVal iCustID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT * FROM tlocation WHERE Cust_ID = " & iCustID & " ORDER BY Loc_Name"
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--Select--"}, True)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '****************************************************************
        Public Function GetCustomerLocByLocName(ByVal iCustID As Integer, ByVal strLocName As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT * FROM tlocation WHERE Cust_ID = " & iCustID & " AND Loc_Name = '" & strLocName & "'"
                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '****************************************************************
        Public Function SaveCustomerLocation(ByVal iLocID As Integer, ByVal strLocName As String, _
                                     ByVal strAddr1 As String, ByVal strAddr2 As String, _
                                     ByVal strCity As String, ByVal strZip As String, _
                                     ByVal strContact As String, ByVal strPhone As String, _
                                     ByVal strFax As String, ByVal strEmail As String, _
                                     ByVal iAfterMarket As Integer, ByVal iManifestDetail As Integer, _
                                     ByVal strMemo As String, ByVal strShipMemo As String, _
                                     ByVal iStateID As Integer, ByVal iCountryID As Integer, _
                                     ByVal iCustID As Integer) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0

            Try
                If iLocID > 0 Then
                    strSql = "UPDATE tlocation SET " & Environment.NewLine
                    strSql &= "Loc_Name = '" & strLocName & "', Loc_Address1 = '" & strAddr1 & "'" & Environment.NewLine
                    strSql &= ", Loc_Address2 = '" & strAddr2 & "', Loc_City = '" & strCity & "'" & Environment.NewLine
                    strSql &= ", Loc_Zip = '" & strZip & "', Loc_Contact = '" & strContact & "'" & Environment.NewLine
                    strSql &= ", Loc_Phone = '" & strPhone & "', Loc_Fax = '" & strFax & "'" & Environment.NewLine
                    strSql &= ", Loc_Email = '" & strEmail & "', Loc_AfterMarket = " & iAfterMarket & Environment.NewLine
                    strSql &= ", Loc_ManifestDetail = " & iManifestDetail & ", Loc_Memo = '" & strMemo & "'" & Environment.NewLine
                    strSql &= ", Loc_ShipMemo = '" & strShipMemo & "', State_ID = " & iStateID & Environment.NewLine
                    strSql &= ", Cntry_ID = " & iCountryID & ", Cust_ID = " & iCustID & Environment.NewLine
                    strSql &= "WHERE Loc_ID = " & iLocID & Environment.NewLine
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                Else
                    strSql = "INSERT INTO tlocation (" & Environment.NewLine
                    strSql &= "Loc_Name, Loc_Address1, Loc_Address2, Loc_City, Loc_Zip" & Environment.NewLine
                    strSql &= ", Loc_Contact, Loc_Phone, Loc_Fax, Loc_Email, Loc_AfterMarket " & Environment.NewLine
                    strSql &= ", Loc_ManifestDetail, Loc_Memo, Loc_ShipMemo, State_ID, Cntry_ID, Cust_ID" & Environment.NewLine
                    strSql &= ") VALUES (" & Environment.NewLine
                    strSql &= "'" & strLocName & "', '" & strAddr1 & "', '" & strAddr2 & "'" & Environment.NewLine
                    strSql &= ", '" & strCity & "', '" & strZip & "', '" & strContact & "'" & Environment.NewLine
                    strSql &= ", '" & strPhone & "', '" & strFax & "', '" & strEmail & "'" & Environment.NewLine
                    strSql &= ", " & iAfterMarket & ", " & iManifestDetail & ", '" & strMemo & "'" & Environment.NewLine
                    strSql &= ", '" & strShipMemo & "', " & iStateID & ", " & iCountryID & ", " & iCustID & Environment.NewLine
                    strSql &= ") " & Environment.NewLine
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                End If
                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************
        Public Function GetCreditCard(ByVal iCustID As Integer) As DataTable
            Dim strsql As String = ""

            Try
                strsql = "SELECT * FROM tcreditcard WHERE CUST_ID = " & iCustID & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strsql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************
        Public Function SaveCreditCard(ByVal iCustID As Integer, ByVal strCreditCardNo As String, _
                                       ByVal strAuthCode As String, ByVal strExpDate As String, _
                                       ByVal iCreditCardTypeID As Integer) As Integer
            Dim strsql, strEncDecErr As String
            Dim dt As DataTable

            Try
                strEncDecErr = ""
                dt = GetCreditCard(iCustID)
                If dt.Rows.Count = 0 Then
                    strsql = "INSERT INTO tcreditcard (" & Environment.NewLine
                    strsql &= "creditcard_num, creditcard_authcode, creditcard_expdate, ccardtype_id, Cust_ID " & Environment.NewLine
                    strsql &= ") VALUES (" & Environment.NewLine
                    strsql &= "'" & EncDec.Rijndael.Encrypt(strCreditCardNo, strEncDecErr) & "'" & Environment.NewLine
                    strsql &= ", '" & EncDec.Rijndael.Encrypt(strAuthCode, strEncDecErr) & "'" & Environment.NewLine
                    strsql &= ", " & strExpDate & "', " & iCreditCardTypeID & ", " & iCustID & Environment.NewLine
                    strsql &= ") "
                    Return Me._objDataProc.ExecuteNonQuery(strsql)
                Else
                    strsql = "UPDATE tcreditcard SET " & Environment.NewLine
                    strsql &= "creditcard_num = " & EncDec.Rijndael.Encrypt(strCreditCardNo, strEncDecErr) & " " & Environment.NewLine
                    strsql &= ", creditcard_authcode = '" & EncDec.Rijndael.Encrypt(strAuthCode, strEncDecErr) & "' " & Environment.NewLine
                    strsql &= ", creditcard_expdate = '" & strExpDate & "' " & Environment.NewLine
                    strsql &= ", ccardtype_id = " & iCreditCardTypeID & Environment.NewLine
                    strsql &= "WHERE Cust_ID = " & iCustID
                    Return Me._objDataProc.ExecuteNonQuery(strsql)
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************
        Public Function GetCustomerToPrice(ByVal iCustID As Integer, ByVal iProdID As Integer) As DataTable
            Dim strsql As String = ""

            Try
                strsql = "SELECT tcusttoprice.*, PrcGroup_LDesc FROM tcusttoprice " & Environment.NewLine
                strsql &= "INNER JOIN lpricinggroup ON tcusttoprice.PrcGroup_ID = lpricinggroup.PrcGroup_ID" & Environment.NewLine
                strsql &= "WHERE tcusttoprice.Cust_ID = " & iCustID & " And tcusttoprice.Prod_ID = " & iProdID & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strsql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************
        Public Function SaveCustomerToPrice(ByVal iCustID As Integer, ByVal iProdID As Integer, _
                                       ByVal iPrcGrpID As Integer, ByVal iUserID As Integer) As Integer
            Dim strsql, strDateTime As String
            Dim dt As DataTable
            Dim i As Integer

            Try
                strDateTime = Generic.MySQLServerDateTime(1)
                dt = GetCustomerToPrice(iCustID, iProdID)
                If dt.Rows.Count = 0 Then
                    strsql = "INSERT INTO tcusttoprice (" & Environment.NewLine
                    strsql &= " Cust_ID, PrcGroup_ID, Prod_ID, LastUpdateDT, LastUpdateUserID " & Environment.NewLine
                    strsql &= ") VALUES (" & Environment.NewLine
                    strsql &= "" & iCustID & ", " & iPrcGrpID & ", " & iProdID & Environment.NewLine
                    strsql &= ", '" & strDateTime & "', " & iUserID & Environment.NewLine
                    strsql &= ") "
                    i = Me._objDataProc.ExecuteNonQuery(strsql)
                Else
                    strsql = "UPDATE tcusttoprice SET " & Environment.NewLine
                    strsql &= "PrcGroup_ID = " & iPrcGrpID & ", LastUpdateDT = '" & strDateTime & "' " & Environment.NewLine
                    strsql &= ", LastUpdateUserID = " & iUserID & Environment.NewLine
                    strsql &= "WHERE CustToPrc_ID = " & dt.Rows(0)("CustToPrc_ID").ToString
                    i = Me._objDataProc.ExecuteNonQuery(strsql)
                End If

                If i > 0 Then SaveCustomerToPriceHist(iCustID, iProdID, iPrcGrpID, iUserID, strDateTime)

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '****************************************************************
        Public Function SaveCustomerToPriceHist(ByVal iCustID As Integer, ByVal iProdID As Integer, _
                                       ByVal iPrcGrpID As Integer, ByVal iUserID As Integer, ByVal strDateTime As String) As Integer
            Dim strsql As String

            Try
                strsql = "INSERT INTO tcusttoprice_hist (" & Environment.NewLine
                strsql &= " Cust_ID, PrcGroup_ID, Prod_ID, LastUpdateDT, LastUpdateUserID " & Environment.NewLine
                strsql &= ") VALUES (" & Environment.NewLine
                strsql &= "" & iCustID & ", " & iPrcGrpID & ", " & iProdID & Environment.NewLine
                strsql &= ", '" & strDateTime & "', " & iUserID & Environment.NewLine
                strsql &= ") "
                Return Me._objDataProc.ExecuteNonQuery(strsql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************
        Public Function GetCustomerMarkup(ByVal iCustID As Integer, ByVal iProdID As Integer) As DataTable
            Dim strsql As String = ""

            Try
                strsql = "SELECT * FROM tcustmarkup " & Environment.NewLine
                strsql &= "WHERE CUST_ID = " & iCustID & " And Prod_ID = " & iProdID & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strsql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************
        Public Function SaveCustomerMarkup(ByVal iCustID As Integer, ByVal iProdID As Integer, _
                                           ByVal dbMarkupRUR As Double, ByVal dbMarkupNER As Double, _
                                           ByVal dbMarkupNTF As Double, ByVal dbMarkupRTM As Double, _
                                           ByVal dbMarkupCust As Double, ByVal dbMarkupInventory As Double, _
                                           ByVal iMarkupPlusParts As Double, ByVal iInvtrymthdID As Integer, _
                                           ByVal iUserID As Integer) As Integer
            Dim strsql, strDateTime As String
            Dim dt As DataTable
            Dim i As Integer

            Try
                strDateTime = Generic.MySQLServerDateTime(1)
                dt = Me.GetCustomerMarkup(iCustID, iProdID)
                If dt.Rows.Count = 0 Then
                    ', Markup_Replacement, Markup_PlusRepl -- missing in user interface
                    strsql = "INSERT INTO tcustmarkup ( " & Environment.NewLine
                    strsql &= "Markup_RUR, Markup_NER, Markup_NTF, Markup_RTM, Markup_Cust, Markup_Invt " & Environment.NewLine
                    strsql &= ", Cust_ID, Prod_ID, Markup_PlusParts, Invtrymthd_ID " & Environment.NewLine
                    strsql &= ", LastUpdateDT, LastUpdateUserID" & Environment.NewLine
                    strsql &= ") VALUES (" & Environment.NewLine
                    strsql &= dbMarkupRUR & ", " & dbMarkupNER & ", " & dbMarkupNTF & ", " & dbMarkupRTM & Environment.NewLine
                    strsql &= ", " & dbMarkupCust & ", " & dbMarkupInventory & ", " & iCustID & Environment.NewLine
                    strsql &= ", " & iProdID & ", " & iMarkupPlusParts & ", " & iInvtrymthdID & Environment.NewLine
                    strsql &= ", '" & strDateTime & "', " & iUserID & Environment.NewLine
                    strsql &= ") "
                    i = Me._objDataProc.ExecuteNonQuery(strsql)
                Else
                    strsql = "UPDATE tcustmarkup SET Markup_RUR = " & dbMarkupRUR & Environment.NewLine
                    strsql &= ", Markup_NER = " & dbMarkupNER & ", Markup_NTF = " & dbMarkupNTF & Environment.NewLine
                    strsql &= ", Markup_RTM = " & dbMarkupRTM & ", Markup_Cust = " & dbMarkupCust & Environment.NewLine
                    strsql &= ", Markup_Invt = " & dbMarkupInventory & Environment.NewLine
                    strsql &= ", Markup_PlusParts = " & iMarkupPlusParts & Environment.NewLine
                    strsql &= ", Invtrymthd_ID = " & iInvtrymthdID & Environment.NewLine
                    strsql &= ", LastUpdateDT = '" & strDateTime & "', LastUpdateUserID = " & iUserID & Environment.NewLine
                    strsql &= "WHERE Markup_ID = " & dt.Rows(0)("MarkUp_ID").ToString
                    i = Me._objDataProc.ExecuteNonQuery(strsql)
                End If

                If i > 0 Then SaveCustomerMarkupHist(iCustID, iProdID, dbMarkupRUR, dbMarkupNER, _
                                            dbMarkupNTF, dbMarkupRTM, dbMarkupCust, dbMarkupInventory, _
                                            iMarkupPlusParts, iInvtrymthdID, iUserID, strDateTime)

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '****************************************************************
        Public Function SaveCustomerMarkupHist(ByVal iCustID As Integer, ByVal iProdID As Integer, _
                                           ByVal dbMarkupRUR As Double, ByVal dbMarkupNER As Double, _
                                           ByVal dbMarkupNTF As Double, ByVal dbMarkupRTM As Double, _
                                           ByVal dbMarkupCust As Double, ByVal dbMarkupInventory As Double, _
                                           ByVal iMarkupPlusParts As Double, ByVal iInvtrymthdID As Integer, _
                                           ByVal iUserID As Integer, ByVal strDateTime As String) As Integer
            Dim strsql As String

            Try
                strsql = "INSERT INTO tcustmarkup_hist ( " & Environment.NewLine
                strsql &= "Markup_RUR, Markup_NER, Markup_NTF, Markup_RTM, Markup_Cust, Markup_Invt " & Environment.NewLine
                strsql &= ", Cust_ID, Prod_ID, Markup_PlusParts, Invtrymthd_ID " & Environment.NewLine
                strsql &= ", LastUpdateDT, LastUpdateUserID" & Environment.NewLine
                strsql &= ") VALUES (" & Environment.NewLine
                strsql &= dbMarkupRUR & ", " & dbMarkupNER & ", " & dbMarkupNTF & ", " & dbMarkupRTM & Environment.NewLine
                strsql &= ", " & dbMarkupCust & ", " & dbMarkupInventory & ", " & iCustID & Environment.NewLine
                strsql &= ", " & iProdID & ", " & iMarkupPlusParts & ", " & iInvtrymthdID & Environment.NewLine
                strsql &= ", '" & strDateTime & "', " & iUserID & Environment.NewLine
                strsql &= ") "
                Return Me._objDataProc.ExecuteNonQuery(strsql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************

    End Class
End Namespace

