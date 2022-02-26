Option Explicit On
Imports System.Windows.Forms
Namespace Buisness
    Public Class BillGroupsAdmin

        Private _objDataProc As DBQuery.DataProc

        '***************************************************
        Public Sub New()
            Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
        End Sub
        '***************************************************
        Protected Overrides Sub Finalize()
            Me._objDataProc = Nothing
            MyBase.Finalize()
        End Sub
        '***************************************************


        '*****************************************************************
        Public Function GetCustomerList() As DataTable
            Dim strSQL As String
            Try
                strSQL = "SELECT cust_id as Cust_ID, cust_name1 as Cust_Name " & Environment.NewLine
                strSQL &= "FROM tcustomer " & Environment.NewLine
                strSQL &= "WHERE Cust_Inactive = 0 AND Cust_AutoBill = 1 " & Environment.NewLine
                strSQL &= "ORDER BY cust_name1;"

                Return _objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************
        Public Function GetManufacturerList() As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT manuf_id as Manuf_ID, manuf_desc as Manuf_Desc " & Environment.NewLine
                strSQL &= "FROM lmanuf " & Environment.NewLine
                strSQL &= "ORDER BY manuf_desc;"
                Return _objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************
        Public Function GetModelList(ByVal iManuf_ID As Integer) As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT Model_ID, Model_Desc " & Environment.NewLine
                strSQL &= "FROM tmodel " & Environment.NewLine
                strSQL &= "WHERE manuf_id = " & iManuf_ID & Environment.NewLine
                strSQL &= "ORDER BY model_desc"
                Return _objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************
        Public Function GetEnterpriseList(ByVal iCust As Long) As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT ent_id as Ent_ID, ent_shortdesc as Ent_Desc " & Environment.NewLine
                strSQL &= "FROM cs_enterprise " & Environment.NewLine
                strSQL &= "WHERE ent_AB = 1 " & Environment.NewLine
                strSQL &= "AND cust_id = " & iCust & Environment.NewLine
                strSQL &= "ORDER BY ent_shortdesc;"
                Return _objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************
        Public Function DoesBillCodeExist(ByVal iCust_ID As Long, _
                                        ByVal iModel_ID As Integer, _
                                        ByVal strEnterprise As String, _
                                        ByVal strBillGrp As String, _
                                        ByVal iBillCode_ID As Integer) As Boolean
            Dim strSQL As String
            Dim dt As DataTable

            Try
                strSQL = "SELECT * " & Environment.NewLine
                strSQL &= "FROM tbillgroup " & Environment.NewLine
                strSQL &= "WHERE bg_cust_id = " & iCust_ID & " " & Environment.NewLine
                strSQL &= "AND bg_model_id = " & iModel_ID & " " & Environment.NewLine
                strSQL &= "AND bg_enterprise = '" & strEnterprise & "' " & Environment.NewLine
                strSQL &= "AND bg_bill_group = '" & strBillGrp & "' " & Environment.NewLine
                strSQL &= "AND billcode_id = " & iBillCode_ID & ";"
                dt = _objDataProc.GetDataTable(strSQL)

                If dt.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Function

        '*****************************************************************
        Public Function DoesBillGroupExist(ByVal iCust_ID As Long, _
                                           ByVal iModel_ID As Integer, _
                                           ByVal strEnterprise As String, _
                                           ByVal strBillGrp As String) As Boolean
            Dim strSQL As String
            Dim dt As DataTable

            Try
                strSQL = "SELECT * " & Environment.NewLine
                strSQL &= "FROM tbillgroup " & Environment.NewLine
                strSQL &= "WHERE bg_cust_id = " & iCust_ID & " " & Environment.NewLine
                strSQL &= "AND bg_model_id = " & iModel_ID & " " & Environment.NewLine
                strSQL &= "AND bg_enterprise = '" & strEnterprise & "' " & Environment.NewLine
                strSQL &= "AND bg_bill_group = '" & strBillGrp & "';"
                dt = _objDataProc.GetDataTable(strSQL)

                If dt.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Function

        '*****************************************************************
        Public Function InsertNewRecord_ToBillGroup(ByVal iCust_ID As Long, _
                                                    ByVal iModel_ID As Integer, _
                                                    ByVal strEnterprise As String, _
                                                    ByVal strBillGrpName As String, _
                                                    ByVal iBillCode_ID As Integer, _
                                                    ByVal iInactive As Integer, _
                                                    ByVal iBillLevel As Integer) As Integer
            Dim strSQL As String
            Dim i As Integer = 0

            Try
                strSQL = "INSERT INTO tbillgroup( "
                strSQL &= "bg_cust_id "
                strSQL &= ", bg_model_id "
                strSQL &= ", bg_enterprise "
                strSQL &= ", bg_bill_group "
                strSQL &= ", billcode_id "
                strSQL &= ", bg_level "
                strSQL &= ", bg_inactive "
                strSQL &= ") VALUES ( " & Environment.NewLine
                strSQL &= iCust_ID & Environment.NewLine
                strSQL &= ", " & iModel_ID & Environment.NewLine
                strSQL &= ", '" & strEnterprise & "' " & Environment.NewLine
                strSQL &= ", '" & strBillGrpName & "' " & Environment.NewLine
                strSQL &= ", " & iBillCode_ID & Environment.NewLine
                strSQL &= ", " & iBillLevel & Environment.NewLine
                strSQL &= ", " & iInactive & ");"
                i = _objDataProc.ExecuteNonQuery(strSQL)

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************
        Public Function GetBillLevel(ByVal iCust_ID As Long, _
                                     ByVal iModel_ID As Integer) As Integer
            Dim strSQL As String
            Dim dt1 As DataTable
            Dim i As Integer = 0
            Dim iBillLevel As Integer = 0

            Try
                strSQL = "SELECT mbl_level " & Environment.NewLine
                strSQL &= "FROM tmodelbilllevel " & Environment.NewLine
                strSQL &= "WHERE mbl_cust_id = " & iCust_ID & " " & Environment.NewLine
                strSQL &= "And mbl_model_id = " & iModel_ID & ";"

                dt1 = Me._objDataProc.GetDataTable(strSQL)
                If dt1.Rows.Count = 0 Then
                    iBillLevel = 0
                    Me.InsertModelBillLevel(iCust_ID, iModel_ID, iBillLevel)
                Else
                    iBillLevel = dt1.Rows(0)("mbl_level")
                End If

                Return iBillLevel
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '*****************************************************************
        Public Function InsertModelBillLevel(ByVal iCust_ID As Integer, _
                                             ByVal iModel_ID As Integer, _
                                             ByVal iBillLevel As Integer) As Integer
            Dim strSql As String

            Try
                strSql = "INSERT INTO tmodelbilllevel ( " & Environment.NewLine
                strSql &= "mbl_cust_id " & Environment.NewLine
                strSql &= ", mbl_model_id " & Environment.NewLine
                strSql &= ", mbl_level " & Environment.NewLine
                strSql &= ") VALUES ( " & Environment.NewLine
                strSql &= iCust_ID & Environment.NewLine
                strSql &= ", " & iModel_ID & " " & Environment.NewLine
                strSql &= ", " & iBillLevel & " );"

                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************
        Public Function GetBillGroupInfo_ByCustModEnt(ByVal iCust_ID As Integer, _
                                                      ByVal iModel_ID As Integer, _
                                                      ByVal strEnterprise As String) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT * " & Environment.NewLine
                strSql &= "FROM tbillgroup " & Environment.NewLine
                strSql &= "WHERE bg_cust_id = " & iCust_ID & " " & Environment.NewLine
                strSql &= "AND bg_model_id = " & iModel_ID & " " & Environment.NewLine
                strSql &= "AND bg_enterprise = '" & strEnterprise & "';"

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '*****************************************************************
        Public Function GetAllBillCodes_OfModel(ByVal iModel_ID As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT psprice_number as psprice, PSPrice_Desc, psprice_stndcost, " & Environment.NewLine
                strSql &= "tpsmap.billcode_id, laborlvl_id, lbillcodes.billcode_desc, tpsmap.LaborLevel, tpsmap.Inactive as tpsmapInactive " & Environment.NewLine
                strSql &= "FROM tpsmap " & Environment.NewLine
                strSql &= "INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id " & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON tpsmap.billcode_id = lbillcodes.billcode_id " & Environment.NewLine
                strSql &= "WHERE tpsmap.model_id = " & iModel_ID & " " & Environment.NewLine
                strSql &= "AND billtype_id = 2 " & Environment.NewLine
                strSql &= "ORDER BY tpsmap.LaborLevel, lbillcodes.billcode_desc;"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************
        Public Function GetTV_enterprise(ByVal iCust_ID As Long) As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT DISTINCT bg_enterprise " & Environment.NewLine
                strSQL &= "FROM tbillgroup " & Environment.NewLine
                strSQL &= "WHERE bg_cust_id = " & iCust_ID & " " & Environment.NewLine
                strSQL &= "ORDER BY bg_enterprise;"
                Return Me._objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************
        Public Function GetTV_manufacturer(ByVal iCust_ID As Long, _
                                           ByVal strEnterprise As String) As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT DISTINCT lmanuf.manuf_desc, lmanuf.manuf_id " & Environment.NewLine
                strSQL &= "FROM tbillgroup " & Environment.NewLine
                strSQL &= "INNER JOIN tmodel ON tbillgroup.bg_model_id = tmodel.model_id " & Environment.NewLine
                strSQL &= "INNER JOIN lmanuf ON tmodel.manuf_id = lmanuf.manuf_id " & Environment.NewLine
                strSQL &= "WHERE bg_cust_id = " & iCust_ID & " " & Environment.NewLine
                strSQL &= "AND bg_enterprise = '" & strEnterprise & "' " & Environment.NewLine
                strSQL &= "ORDER BY manuf_desc;"
                Return Me._objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************
        Public Function GetTV_Model(ByVal iCust_ID As Long, _
                                    ByVal strEnterprise As String, _
                                    ByVal iManuf_ID As Integer) As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT DISTINCT tmodel.model_desc, tmodel.model_id " & Environment.NewLine
                strSQL &= "FROM tbillgroup " & Environment.NewLine
                strSQL &= "INNER JOIN tmodel ON tbillgroup.bg_model_id = tmodel.model_id " & Environment.NewLine
                strSQL &= "INNER JOIN lmanuf ON tmodel.manuf_id = lmanuf.manuf_id " & Environment.NewLine
                strSQL &= "WHERE bg_cust_id = " & iCust_ID & " " & Environment.NewLine
                strSQL &= "AND bg_enterprise = '" & strEnterprise & "' " & Environment.NewLine
                strSQL &= "AND lmanuf.manuf_id = " & iManuf_ID & " " & Environment.NewLine
                strSQL &= "ORDER BY manuf_desc;"
                Return Me._objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************
        Public Sub PopulateTreeView(ByRef treeViewCtrl As System.Windows.Forms.TreeView, _
                                    ByVal iCust_ID As Long)
            Dim dtENT As DataTable
            Dim dtManuf As DataTable
            Dim dtModel As DataTable

            Dim drENT As DataRow
            Dim drManuf As DataRow
            Dim drModel As DataRow

            Dim iCount As Integer = 0
            Dim jCount As Integer = 0
            Dim kCount As Integer = 0
            Dim lCount As Integer = 0
            Dim mCount As Integer = 0

            Dim nodp As TreeNode
            Dim nodc As TreeNode
            Dim nodc1 As TreeNode

            Try
                treeViewCtrl.Visible = False
                treeViewCtrl.Nodes.Clear()

                dtENT = GetTV_enterprise(iCust_ID)

                For iCount = 0 To dtENT.Rows.Count - 1
                    drENT = dtENT.Rows(iCount)

                    nodp = New TreeNode(drENT("bg_enterprise"))
                    treeViewCtrl.Nodes.Add(nodp)
                    nodp.Expand()

                    dtManuf = GetTV_manufacturer(iCust_ID, drENT("bg_enterprise"))
                    For jCount = 0 To dtManuf.Rows.Count - 1
                        drManuf = dtManuf.Rows(jCount)

                        nodc = New TreeNode(drManuf("manuf_desc"))
                        nodp.Nodes.Add(nodc)

                        nodc.Expand()

                        dtModel = GetTV_Model(iCust_ID, drENT("bg_enterprise"), drManuf("manuf_id"))
                        For kCount = 0 To dtModel.Rows.Count - 1
                            drModel = dtModel.Rows(kCount)

                            nodc1 = New TreeNode(drModel("Model_desc"))
                            nodc.Nodes.Add(nodc1)

                            nodc1.Expand()

                            'Reset loop variable
                            drModel = Nothing
                            nodc1 = Nothing
                        Next kCount

                        'Reset loop variable
                        drManuf = Nothing
                        nodc = Nothing
                    Next jCount

                    'Reset loop variable
                    drENT = Nothing
                    nodp = Nothing

                Next iCount

                treeViewCtrl.Visible = True
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*****************************************************************
        Public Function GetMarkup(ByVal iCust_ID As Long) As Double
            Dim strSql As String
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim x As Integer

            Try
                strSql = "SELECT Markup_Cust, Markup_PlusParts " & Environment.NewLine
                strSql &= "FROM tcustmarkup " & Environment.NewLine
                strSql &= "WHERE Cust_ID = " & iCust_ID & ";"
                dt1 = Me._objDataProc.GetDataTable(strSql)

                For Each R1 In dt1.Rows
                    If R1("Markup_PlusParts") = 1 Then
                        Return R1("Markup_Cust")
                    Else
                        Return 0
                    End If
                Next R1

            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '*****************************************************************
        Public Function GetModelTarget(ByVal iCust_ID As Long, _
                                  ByVal iModel_ID As Integer, _
                                  ByVal strEnterprise As String) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT tmodeltarget.*  " & Environment.NewLine
                strSql &= "FROM tmodeltarget " & Environment.NewLine
                strSql &= "WHERE tmodeltarget.MT_model_id = " & iModel_ID & "  " & Environment.NewLine
                strSql &= "AND tmodeltarget.MT_cust_id = " & iCust_ID & "  " & Environment.NewLine
                strSql &= "AND MT_enterprise = '" & strEnterprise & "';"
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************
        Public Function GetLvl3LaborCharge(ByVal iCust_ID As Integer, _
                                           ByVal iModel_ID As Integer) As Decimal
            Dim strSql As String
            Dim dt1 As DataTable
            Dim dbLvl3LaborCharge As Decimal = 0

            Try
                strSql = "SELECT LaborPrc_RegPrc as Labor " & Environment.NewLine
                strSql &= "FROM tlaborprc " & Environment.NewLine
                strSql &= "INNER JOIN tcusttoprice ON tlaborprc.PrcGroup_ID = tcusttoprice.PrcGroup_ID" & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tlaborprc.ProdGrp_ID = tmodel.Model_Tier " & Environment.NewLine
                strSql &= "WHERE tmodel.Model_ID = " & iModel_ID & " " & Environment.NewLine
                strSql &= "AND tcusttoprice.Cust_ID = " & iCust_ID & " " & Environment.NewLine
                strSql &= "AND tlaborprc.LaborLvl_ID = 3;"

                dt1 = Me._objDataProc.GetDataTable(strSql)

                If dt1.Rows.Count > 0 Then
                    If Not IsDBNull(dt1.Rows(0)("Labor")) Then
                        dbLvl3LaborCharge = dt1.Rows(0)("Labor")
                    End If
                End If

                Return dbLvl3LaborCharge
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function


        '''*****************************************************************
        ''Public Function GetNewBillGroupName() As String
        ''    Dim strSql As String
        ''    Dim dt1 As DataTable
        ''    Dim iMaxBG_No As Integer = 0
        ''    Dim strNewBillGrpName As String

        ''    Try
        ''        strSql = "SELECT MAX( right(BGD_Desc, length(BGD_Desc) -2 ) ) as MaxBillGrp from tbillgroupdescription;;"
        ''        dt1 = Me._objDataProc.GetDataTable(strSql)

        ''        If dt1.Rows.Count > 0 Then
        ''            iMaxBG_No = dt1.Rows(0)("MaxBillGrp")
        ''        End If

        ''        strNewBillGrpName = "BG" & iMaxBG_No + 1

        ''        strSql = "INSERT INTO tbillgroupdescription (BGD_Desc) VALUES ('" & strNewBillGrpName & "');"
        ''        Me._objDataProc.ExecuteNonQuery(strSql)

        ''        Return strNewBillGrpName
        ''    Catch ex As Exception
        ''        Throw ex
        ''    Finally
        ''        If Not IsNothing(dt1) Then
        ''            dt1.Dispose()
        ''            dt1 = Nothing
        ''        End If
        ''    End Try
        ''End Function

        '*****************************************************************
        Public Function CalcBillGrpTotal(ByVal iCust_ID As Long, _
                                       ByVal iModel_ID As Integer, _
                                       ByVal strEnterprise As String, _
                                       ByVal strBillGrpName As String, _
                                       ByVal dbCust_Markup As Double) As Double
            Dim strSql As String
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim dbTotal As Double = 0

            Try
                'Add any initialization after the InitializeComponent() call
                strSql = "SELECT tbillgroup.bg_bill_group as BG, sum( ( lpsprice.psprice_stndcost * " & (1 + dbCust_Markup) & ") + 0.00499) as sumPrice " & Environment.NewLine
                strSql &= "FROM tbillgroup " & Environment.NewLine
                strSql &= "INNER JOIN tpsmap ON (tbillgroup.bg_model_id = tpsmap.model_id AND tbillgroup.billcode_id = tpsmap.billcode_id) " & Environment.NewLine
                strSql &= "INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id " & Environment.NewLine
                strSql &= "WHERE bg_cust_id = " & iCust_ID & " "
                strSql &= "AND bg_model_id = " & iModel_ID & " "
                strSql &= "AND bg_enterprise = '" & strEnterprise & "' "
                strSql &= "AND bg_bill_group = '" & strBillGrpName & "' " & Environment.NewLine
                strSql &= "AND bg_inactive = 0 " & Environment.NewLine
                strSql &= "GROUP BY tbillgroup.bg_bill_group;"
                dt1 = Me._objDataProc.GetDataTable(strSql)

                If dt1.Rows.Count > 0 Then
                    dbTotal = Format(CDbl(dt1.Rows(0)("sumPrice")), "###0.00")
                End If

                Return dbTotal
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '*****************************************************************
        Public Function SetBillGroupToInactive(ByVal iCust_ID As Integer, _
                                               ByVal iModel_ID As Integer, _
                                               ByVal strEnterprise As String, _
                                               ByVal strBillGrpName As String) As Integer
            Dim strSql As String

            Try
                strSql = "UPDATE tbillgroup " & Environment.NewLine
                strSql &= "SET bg_Inactive = 1 " & Environment.NewLine
                strSql &= "WHERE bg_cust_id = " & iCust_ID & Environment.NewLine
                strSql &= "AND bg_model_id = " & iModel_ID & Environment.NewLine
                strSql &= "AND bg_enterprise = '" & strEnterprise & "'" & Environment.NewLine
                strSql &= "AND bg_bill_group = '" & strBillGrpName & "';"

                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************
        Public Sub UpdateBillcodes_Status(ByVal iCust_ID As Integer, _
                                          ByVal iModel_ID As Integer, _
                                          ByVal strEnt As String)
            Dim strSql As String
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim iModelBillcode_InactiveFlag As Integer
            Dim i As Integer

            Try
                strSql = "SELECT DISTINCT bg_model_id, billcode_id " & Environment.NewLine
                strSql &= "FROM tbillgroup " & Environment.NewLine
                strSql &= "WHERE bg_cust_id = " & iCust_ID & Environment.NewLine
                strSql &= "AND bg_model_id = " & iModel_ID & Environment.NewLine
                strSql &= "AND bg_enterprise = '" & strEnt & "' " & Environment.NewLine
                strSql &= "AND bg_Inactive = 0;"

                dt1 = Me._objDataProc.GetDataTable(strSql)

                For Each R1 In dt1.Rows
                    iModelBillcode_InactiveFlag = Me.GetModelBillcode_InactiveStatus(R1("bg_model_id"), R1("billcode_id"))

                    If iModelBillcode_InactiveFlag = -1 Or iModelBillcode_InactiveFlag = 1 Then
                        i += Me.SetBilGrpBillcodes_InactiveFlg(iCust_ID, R1("bg_model_id"), R1("billcode_id"), 1)
                    End If
                Next R1

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*****************************************************************
        Public Function GetModelBillcode_InactiveStatus(ByVal iModel_ID As Integer, _
                                                        ByVal iBillcodes As Integer) As Integer
            Dim strSql As String
            Dim dt1 As DataTable
            Dim iInactiveFlg As Integer = -1

            Try
                strSql = "SELECT Inactive " & Environment.NewLine
                strSql &= "FROM tpsmap " & Environment.NewLine
                strSql &= "WHERE Model_ID = " & iModel_ID & Environment.NewLine
                strSql &= "AND Billcode_ID = " & iBillcodes & ";"

                dt1 = Me._objDataProc.GetDataTable(strSql)
                If dt1.Rows.Count > 0 Then
                    iInactiveFlg = dt1.Rows(0)("Inactive")
                End If

                Return iInactiveFlg
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '*****************************************************************
        Public Function SetBilGrpBillcodes_InactiveFlg(ByVal iCust_ID As Integer, _
                                                       ByVal iModel_ID As Integer, _
                                                       ByVal iBillcode_ID As Integer, _
                                                       ByVal iInactiveVal As Integer) As Integer
            Dim strSql As String

            Try
                strSql = "UPDATE tbillgroup " & Environment.NewLine
                strSql &= "SET bg_Inactive = " & iInactiveVal & Environment.NewLine
                strSql &= "WHERE bg_cust_id = " & iCust_ID & Environment.NewLine
                strSql &= "AND bg_model_id = " & iModel_ID & Environment.NewLine
                strSql &= "AND billcode_id = " & iBillcode_ID & ";"
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************


    End Class
End Namespace