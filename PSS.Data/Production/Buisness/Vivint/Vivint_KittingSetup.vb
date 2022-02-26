Option Explicit On 

Imports System
Imports System.Data
Imports System.Text
Imports MySql.Data
Imports System.IO

Namespace Buisness.VV
    Public Class Vivint_KittingSetup
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
        Public Function geMappedPartBillCodeData(ByVal iModel_ID As Integer) As DataTable
            Dim strSql As String = ""
            Dim i As Integer = 0
            Dim dt As DataTable
            Dim row As DataRow

            Try
                strSql = "SELECT 0 AS 'RecID', lbillcodes.BillCode_Desc,lpsprice.PSPrice_Number AS 'Part_Number', lpsprice.PSPrice_ID, lbillcodes.BillCode_ID, 1 AS 'Qty',LaborLvl_ID, PSPrice_AvgCost," & Environment.NewLine
                strSql &= " PSPrice_StndCost, BillCode_Rule, BillType_ID, If(Fail_ID is null, 0, Fail_ID) as Fail_ID , Repair_ID," & Environment.NewLine
                strSql &= " tmodel.ASCPrice_ID, lascprice.ASCPrice_Price, tmodel.Manuf_ID" & Environment.NewLine
                strSql &= " , tmodel.Prod_ID" & Environment.NewLine
                strSql &= " , tpsmap.LaborLevel" & Environment.NewLine
                strSql &= " , lpsprice.RVFlag, lpsprice.PSPrice_ConsignedPart, lpsprice.MaxInventory" & Environment.NewLine
                strSql &= " FROM tpsmap" & Environment.NewLine
                strSql &= " INNER JOIN lbillcodes ON tpsmap.BillCode_ID =lbillcodes.BillCode_ID" & Environment.NewLine
                strSql &= " INNER JOIN lpsprice ON tpsmap.PSPrice_ID = lpsprice.PSPrice_ID" & Environment.NewLine
                strSql &= " INNER JOIN lascprice ON tmodel.ASCPrice_ID = lascprice.ASCPrice_ID" & Environment.NewLine
                strSql &= " INNER JOIN tmodel ON tpsmap.Model_ID = tmodel.Model_ID" & Environment.NewLine
                strSql &= " WHERE tpsmap.Model_ID = " & iModel_ID & " AND lbillcodes.BillType_ID=2" & Environment.NewLine
                strSql &= " ORDER BY lbillcodes.BillCode_Desc" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)
                For Each row In dt.Rows
                    i += 1
                    row.BeginEdit() : row("RecID") = i : row.AcceptChanges()
                Next

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function SaveKittingSetData(ByVal strKitSetName As String, ByVal iModel_ID As Integer, ByVal iUser_ID As Integer, _
                                           ByVal strDatetime As String, ByVal iCust_ID As Integer, ByVal dtParts As DataTable, _
                                           ByVal dtParts_RV As DataTable) As Integer
            Dim strSql As String = ""
            Dim iKMSet_ID As Integer = 0
            Dim i As Integer = 0, j As Integer = 0
            Dim iPartQty As Integer = dtParts.Rows.Count
            Dim strValues As String = ""
            Dim row As DataRow
            Dim dt As DataTable
            Dim strHistory_KMSet_IDs As String = ""
            Dim iTotalPartRowsCount As Integer = 0

            Try
                'find history setting for the model
                strSql = "Select * from  production.ttffk_kitting_items_setmaster WHERE Master_Model_ID=" & iModel_ID & " AND Cust_ID=" & iCust_ID
                dt = Me._objDataProc.GetDataTable(strSql)
                For Each row In dt.Rows
                    If strHistory_KMSet_IDs.Trim.Length = 0 Then
                        strHistory_KMSet_IDs = row("KMSet_ID")
                    Else
                        strHistory_KMSet_IDs &= "," & row("KMSet_ID")
                    End If
                Next

                'KMSet_ID, Kitting_Setup, Master_Model_ID, UPC, ItemUPC, SIM_Qty, Collateral_Qty, Alt_SIM_Qty, HasItemUPC, PackQtyPerCarton, MaxCartonQtyPerPallet, PackQtyPerInnerCarton,
                'GTIN_InnerCarton_UPC, GTIN_MasterCarton_UPC, VersionControl, CountryOfOrigin, ExpirationDate, HasExpirationDate, Process_Type_ID, UserID, UpdateDateTime,Cust_ID, IsActive
                strSql = "INSERT INTO production.ttffk_kitting_items_setmaster " & Environment.NewLine
                strSql &= "(Kitting_Setup, Master_Model_ID, Collateral_Qty, Process_Type_ID, UserID, UpdateDateTime,Cust_ID, IsActive)" & Environment.NewLine
                strSql &= " VALUES('" & strKitSetName & "'," & iModel_ID & "," & iPartQty & ",1," & iUser_ID & ",'" & strDatetime & "'," & iCust_ID & ",1);"
                i = Me._objDataProc.ExecuteNonQuery(strSql)
                strSql = "SELECT LAST_INSERT_ID();" 'get primary key after Insert
                iKMSet_ID = Me._objDataProc.GetIntValue(strSql)


                ' KDSet_ID, KMSet_ID, Component_Model_ID, Qty, Component_Type, OrderBy, IsKeySIM, UserID, UpdateDateTime
                strSql = "INSERT INTO production.ttffk_kitting_items_setdetail (KMSet_ID, Component_Model_ID, Qty, Component_Type, OrderBy, IsKeySIM, UserID, UpdateDateTime)" & Environment.NewLine
                strSql &= " VALUES"

                'RecID, BillCode_Desc, Part_Number, PSPrice_ID, BillCode_ID, Qty,LaborLvl_ID, PSPrice_AvgCost, PSPrice_StndCost, BillCode_Rule, 
                'BillType_ID(, Fail_ID, Repair_ID, ASCPrice_ID, ASCPrice_Price, Manuf_ID, Prod_ID, LaborLevel, RVFlag, PSPrice_ConsignedPart, MaxInventory
                iTotalPartRowsCount = dtParts.Rows.Count + dtParts_RV.Rows.Count
                For Each row In dtParts.Rows
                    j += 1
                    If j = iTotalPartRowsCount Then
                        strValues &= "(" & iKMSet_ID & "," & row("PSPrice_ID") & "," & row("Qty") & ",'Part'," & j & ",0," & iUser_ID & ",'" & strDatetime & "');" & Environment.NewLine
                    Else
                        strValues &= "(" & iKMSet_ID & "," & row("PSPrice_ID") & "," & row("Qty") & ",'Part'," & j & ",0," & iUser_ID & ",'" & strDatetime & "')," & Environment.NewLine
                    End If
                Next
                For Each row In dtParts_RV.Rows
                    j += 1
                    If j = iTotalPartRowsCount Then
                        strValues &= "(" & iKMSet_ID & "," & row("PSPrice_ID") & "," & row("Qty") & ",'Part_RV'," & j & ",0," & iUser_ID & ",'" & strDatetime & "');" & Environment.NewLine
                    Else
                        strValues &= "(" & iKMSet_ID & "," & row("PSPrice_ID") & "," & row("Qty") & ",'Part_RV'," & j & ",0," & iUser_ID & ",'" & strDatetime & "')," & Environment.NewLine
                    End If
                Next

                strSql &= strValues

                i += Me._objDataProc.ExecuteNonQuery(strSql)

                'set history setting for the model
                strSql = "UPDATE production.ttffk_kitting_items_setmaster SET IsActive=0 WHERE KMSet_ID IN (" & strHistory_KMSet_IDs & ");"
                i += Me._objDataProc.ExecuteNonQuery(strSql)

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function IsPostiveInteger(ByVal S As String) As Boolean
            Try
                If Convert.ToInt32(S) Then
                    If Convert.ToInt32(S) > 0 Then
                        Return True
                    Else
                        Return False
                    End If
                Else
                    If S = 0 Then
                        Return True
                    End If
                End If
            Catch
                Return False
            End Try

            Return False
        End Function
    End Class
End Namespace