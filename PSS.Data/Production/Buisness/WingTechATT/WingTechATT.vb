Option Explicit On 

Imports System
Imports System.Data
Imports System.Text
Imports MySql.Data

Namespace Buisness.WingTechATT

    Public Class WingTechATT
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
#Region "WingTechATT"
        Public Shared ReadOnly Property WingTechATT_CUSTOMER_ID() As Integer
            Get
                Return 2631
            End Get
        End Property
        Public Shared ReadOnly Property WingTechATT_SpecialProj_Type4() As String
            Get
                Return "U318Project"
            End Get
        End Property

        Public Shared ReadOnly Property WingTechATT_SpecialProj_Type3() As String
            Get
                Return "6K202Project"
            End Get
        End Property
        Public Shared ReadOnly Property WingTechATT_SpecialProj_Type2() As String
            Get
                Return "Teller"
            End Get
        End Property
        Public Shared ReadOnly Property WingTechATT_SpecialProj_Type1() As String
            Get
                Return "SP_Generic"
            End Get
        End Property
        Public Shared ReadOnly Property WingTechATT_SpecialProjType2_MODEL_ID() As Integer
            Get
                Return 5134
            End Get
        End Property
        Public Shared ReadOnly Property WingTechATT_AttCricket_LOC_ID() As Integer
            Get
                Return 4493
            End Get
        End Property

        Public Shared ReadOnly Property WingTechATT_AttCTDI_LOC_ID() As Integer
            Get
                Return 4494
            End Get
        End Property

        Public Shared ReadOnly Property WingTechATT_AttFedEx_LOC_ID() As Integer
            Get
                Return 4495
            End Get
        End Property
        Public Shared ReadOnly Property WingTechATT_Special_LOC_ID() As Integer
            Get
                Return 4496
            End Get
        End Property

        Public Shared ReadOnly Property WingTechATT_SeedStock_Model() As Integer
            Get
                Return 5251
            End Get
        End Property
        Public Shared ReadOnly Property WingTechATT_SeedBulk_Model() As Integer
            Get
                Return 5252
            End Get
        End Property
        Public Shared ReadOnly Property WingTechATT_6k() As Integer
            Get
                Return 4492
            End Get
        End Property

        Public Shared ReadOnly Property WingTechATT_AttCricket_MCode_ID() As Integer
            Get
                Return 90
            End Get
        End Property

        Public Shared ReadOnly Property WingTechATT_AttCTDI_MCode_ID() As Integer
            Get
                Return 91
            End Get
        End Property

        Public Shared ReadOnly Property WingTechATT_AttFedEx_MCode_ID() As Integer
            Get
                Return 91
            End Get
        End Property

        Public Shared ReadOnly Property WingTechATT_Product_ID() As Integer
            Get
                Return 2
            End Get
        End Property

        'SeedStock data: BulkORderType_ID = 0, Bulk data: BulkORderType_ID = 1 (all Cricket,ATT devices shoul be this), End-User data: BulkORderType_ID = 2 may have in future
        Public Shared ReadOnly Property WingTechATT_OrderTypeSeedStock_ID() As Integer
            Get
                Return 0
            End Get
        End Property
        Public Shared ReadOnly Property WingTechATT_OrderTypeBulk_ID() As Integer
            Get
                Return 1
            End Get
        End Property
        Public Shared ReadOnly Property WingTechATT_OrderTypeEndUser_ID() As Integer
            Get
                Return 2
            End Get
        End Property

        Public Shared ReadOnly Property WingTechATT_DeviceManufDate_MaxLength() As Integer
            Get
                Return 8
            End Get
        End Property

        Public Shared ReadOnly Property WingTechATT_DeviceManufDate_MinLength() As Integer
            Get
                Return 6
            End Get
        End Property

        Public Shared ReadOnly Property WingTechATT_SeedStock() As String
            Get
                Return "SeedStock"
            End Get
        End Property

        Public Shared ReadOnly Property WingTechATT_AttCTDI_Box_Prefix() As String
            Get
                Return "CS0"
            End Get
        End Property

        Public Shared ReadOnly Property WingTechATT_AttCTDI_Box_Postfix() As String
            Get
                Return "EMB"
            End Get
        End Property

        Public Shared ReadOnly Property WingTechATT_AttCTDI_BoxName_Len() As Integer
            Get
                Return 20
            End Get
        End Property

        'from table lgroups
        Public Shared ReadOnly Property WingTechATT_Group_ID() As Integer
            Get
                Return 139
            End Get
        End Property

        Public Shared ReadOnly Property WingTechATT_RUR_LaborLevel() As Integer
            Get
                Return 17
            End Get
        End Property

        Public Shared ReadOnly Property WingTechATT_PrcGroup_ID() As Integer
            Get
                Return 333
            End Get
        End Property

        'lprodgrp
        Public Shared ReadOnly Property WingTechATT_ProdGrp_ID() As Integer
            Get
                Return 203
            End Get
        End Property



        Public Shared ReadOnly Property WingTechATT_MaxQtyInBox() As Integer
            Get
                Return 20 '20 SNs allowed in a box
            End Get
        End Property

        Public Shared ReadOnly Property WingTechATT_SPMaxQtyInBox() As Integer
            Get
                Return 1000 '20 SNs allowed in a box
            End Get
        End Property

        Public Shared ReadOnly Property WingTechATT_Cricket_OEMCustomer_EMS() As String
            Get
                Return "Emblem Solutions" 'IW,  wrty falg=1, Wrranty Exchange
            End Get
        End Property

        Public Shared ReadOnly Property WingTechATT_Cricket_OEMCustomer_DOA() As String
            Get
                Return "Emblem Solutions DOA"  'OW, wrty flag=0, DOA
            End Get
        End Property

        Public Shared ReadOnly Property WingTechATT_Cricket_OEMCustomer_EMS_AccountCode() As String
            Get
                Return "569955"
            End Get
        End Property

        Public Shared ReadOnly Property WingTechATT_Cricket_OEMCustomer_DOA_AccountCode() As String
            Get
                Return "569969"
            End Get
        End Property

        Public Shared ReadOnly Property WingTechATT_FexEx_WexCode() As String
            Get
                Return "WEX"
            End Get
        End Property

        Public Shared ReadOnly Property WingTechATT_SeedStockSourceType_ATT() As String
            Get
                Return "ATT"
            End Get
        End Property

        Public Shared ReadOnly Property WingTechATT_SeedStockSourceType_Cricket() As String
            Get
                Return "Cricket"
            End Get
        End Property

        Public Shared ReadOnly Property WingTechATT_FexEx_PosCode() As String
            Get
                Return "POS"
            End Get
        End Property

        Public Shared ReadOnly Property WingTechATT_BER_BillCode_ID() As Integer
            Get
                Return 1020
            End Get
        End Property

        Public Shared ReadOnly Property WingTechATT_RUR_BillCode_ID() As Integer
            Get
                Return 4454
            End Get
        End Property

        Public Shared ReadOnly Property WingTechATT_RUR_BillCode_ID2() As Integer
            Get
                Return 276
            End Get
        End Property

        Public Shared ReadOnly Property WingTechATT_Swap_BillCode_ID() As Integer
            Get
                Return 4600
            End Get
        End Property

        Public Shared ReadOnly Property WingTechATT_Swap_PSPrice_ID() As Integer
            Get
                Return 31961
            End Get
        End Property

        Public Shared ReadOnly Property WingTechATT_Swap_LabelLevel() As Integer
            Get
                Return 15
            End Get
        End Property

        Public Shared ReadOnly Property WingTechATT_Received_WorkStation() As String
            Get
                Return "WH-WIP"
            End Get
        End Property

        'For REF2Seedstock----------------------------------------------------
        Public Shared ReadOnly Property WingTechATT_REF2SeedPallet_Cricket() As String
            Get
                Return "2631SDS20210301N001"
            End Get
        End Property

        Public Shared ReadOnly Property WingTechATT_REF2SeedPalletID_Cricket() As Integer
            Get
                Return 373884
            End Get
        End Property

        Public Shared ReadOnly Property WingTechATT_REF2SeedPallet_AttCTDI() As String
            Get
                Return "2631SDS20210301N002"
            End Get
        End Property

        Public Shared ReadOnly Property WingTechATT_REF2SeedPalletID_AttCTDI() As Integer
            Get
                Return 373885
            End Get
        End Property

        Public Shared ReadOnly Property WingTechATT_REF2SeedPallet_AttFedEx() As String
            Get
                Return "2631SDS20210301N003"
            End Get
        End Property

        Public Shared ReadOnly Property WingTechATT_REF2SeedPalletID_AttFedEx() As Integer
            Get
                Return 373886
            End Get
        End Property


        'Stages--------------------------------------------------------------
        'After Pretest
        Public Shared ReadOnly Property WingTechATT_PreBill_WorkStation() As String
            Get
                Return "PRE-BILL"
            End Get
        End Property

        'After TechBill
        Public Shared ReadOnly Property WingTechATT_Label_WorkStation() As String
            Get
                Return "LABEL"
            End Get
        End Property

        'After Label
        Public Shared ReadOnly Property WingTechATT_FQA_WorkStation() As String
            Get
                Return "FQA"
            End Get
        End Property

        Public Shared ReadOnly Property WingTechATT_DeviceSwap_WorkStation() As String
            Get
                Return "SWAPPED"
            End Get
        End Property

        'After Build/Produce
        Public Shared ReadOnly Property WingTechATT_BuildProduce_WorkStation() As String
            Get
                Return "IN-TRANSIT"
            End Get
        End Property


        'Work flow: RAM - Receiving - PreTest - TechBill - Label - FQA _RF Test - Flash - AQL - Build Box - Produce Box - Manifest
        'Workstation after each process: Receving - WH-WIP - Pre-Bill - Label
#End Region

#End Region

#Region "SQL Data"

        Public Function getWingTechATTModels(ByVal iCust_ID As Integer, ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT model_ID, model_Desc,Model_MotoSku,ASN_IN_SKU,ASN_IN_SKU_Desc,Model_LDesc,ShippedModel" & Environment.NewLine
                strSql &= " ,ShippedModel_Desc,Cust_IDs,Model_Tier,Model_Flat,Manuf_ID,Prod_ID,ProdGrp_ID,ASCPrice_ID,RptGrp_ID" & Environment.NewLine
                strSql &= " FROM production.tModel WHERE Cust_IDs LIKE  '%" & iCust_ID & "%' ORDER BY Model_Desc;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If booAddSelectRow Then dt.LoadDataRow(New Object() {0, "--Select--"}, True)

                Return dt

            Catch ex As Exception
                Throw ex

            End Try
        End Function

        Public Function getMaxReceivingBoxQty() As Integer 'For Receiving screen
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim iRet As Integer = 0

            Try
                strSql = "SELECT Description,CustIDs as 'Cust_ID', Generic AS 'Qty' FROM exceptioncriteria WHERE description = 'WingTechATT_REV_BOX_MAX_QTY' AND CustIds='" & Me.WingTechATT_CUSTOMER_ID.ToString & "'" & ";"

                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 AndAlso IsNumeric(dt.Rows(0).Item("Qty")) Then iRet = Convert.ToInt32(dt.Rows(0).Item("Qty"))

                Return iRet
            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing
            End Try
        End Function

        Public Function GetWingTechATT_SP_MasterPalletName(ByVal iCust_ID As Integer, ByVal iLoc_ID As Integer) As String
            Dim strSql As String = ""
            Dim strWingTechATT_BegMP_Name As String = "WGT0921059999"
            Dim dt As DataTable
            Dim strRet As String = ""
            Dim strTmp As String = ""
            Dim strPreFix As String = Left(strWingTechATT_BegMP_Name, 3)
            Dim iVal As Long = 0

            Try
                strSql = "SELECT * FROM tpackingslippallet WHERE Cust_ID=" & iCust_ID & " AND loc_ID=" & iLoc_ID & " AND LENGTH(MPallet_Name)= Length('" & strWingTechATT_BegMP_Name & "') AND LEFT(MPallet_Name,3) like 'WGT%'" & Environment.NewLine
                strSql &= " ORDER BY  MPallet_Name asc Limit 1;" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                'MPallet_ID, MPallet_Name, MLoadNo, PO, Desc1, Desc2, Desc3, Qty1, Qty2, Qty3, pkslip_ID, Cust_ID, Loc_ID, IsSameQtyPerBox
                If dt.Rows.Count > 0 Then
                    strTmp = dt.Rows(0).Item("MPallet_Name")
                    strTmp = strTmp.Replace(strPreFix, "")
                    iVal = strTmp
                    iVal = iVal - 1
                    strTmp = iVal.ToString
                    strTmp = strTmp.PadLeft("0921059999".Length, "0")
                    strRet = strPreFix & strTmp
                Else
                    strRet = strWingTechATT_BegMP_Name
                End If

                Return strRet

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

#End Region

    End Class
End Namespace