Option Explicit On 

Imports System
Imports System.Data
Imports System.Text
Imports MySql.Data

Namespace Buisness.WIKO
    Public Class WIKO
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
#Region "WIKO"
        Public Shared ReadOnly Property WIKO_CUSTOMER_ID() As Integer
            Get
                Return 2624
            End Get
        End Property
        Public Shared ReadOnly Property WIKO_SpecialProj_Type4() As String
            Get
                Return "U318Project"
            End Get
        End Property
        Public Shared ReadOnly Property WIKO_SpecialProj_Type3() As String
            Get
                Return "6K202Project"
            End Get
        End Property
        Public Shared ReadOnly Property WIKO_SpecialProj_Type2() As String
            Get
                Return "Teller"
            End Get
        End Property
        Public Shared ReadOnly Property WIKO_SpecialProj_Type1() As String
            Get
                Return "SP1"
            End Get
        End Property
        Public Shared ReadOnly Property WIKO_SpecialProjType2_MODEL_ID() As Integer
            Get
                Return 5134
            End Get
        End Property
        Public Shared ReadOnly Property WIKO_AttCricket_LOC_ID() As Integer
            Get
                Return 4484
            End Get
        End Property

        Public Shared ReadOnly Property WIKO_AttCTDI_LOC_ID() As Integer
            Get
                Return 4483
            End Get
        End Property

        Public Shared ReadOnly Property WIKO_AttFedEx_LOC_ID() As Integer
            Get
                Return 4485
            End Get
        End Property

        Public Shared ReadOnly Property WIKO_Special_LOC_ID() As Integer
            Get
                Return 4490
            End Get
        End Property

        Public Shared ReadOnly Property WIKO_6k() As Integer
            Get
                Return 4492
            End Get
        End Property

        Public Shared ReadOnly Property WIKO_AttCricket_MCode_ID() As Integer
            Get
                Return 90
            End Get
        End Property

        Public Shared ReadOnly Property WIKO_AttCTDI_MCode_ID() As Integer
            Get
                Return 91
            End Get
        End Property

        Public Shared ReadOnly Property WIKO_AttFedEx_MCode_ID() As Integer
            Get
                Return 91
            End Get
        End Property

        Public Shared ReadOnly Property WIKO_Product_ID() As Integer
            Get
                Return 2
            End Get
        End Property

        'SeedStock data: BulkORderType_ID = 0, Bulk data: BulkORderType_ID = 1 (all Cricket,ATT devices shoul be this), End-User data: BulkORderType_ID = 2 may have in future
        Public Shared ReadOnly Property WIKO_OrderTypeSeedStock_ID() As Integer
            Get
                Return 0
            End Get
        End Property
        Public Shared ReadOnly Property WIKO_OrderTypeBulk_ID() As Integer
            Get
                Return 1
            End Get
        End Property
        Public Shared ReadOnly Property WIKO_OrderTypeEndUser_ID() As Integer
            Get
                Return 2
            End Get
        End Property

        Public Shared ReadOnly Property WIKO_DeviceManufDate_MaxLength() As Integer
            Get
                Return 8
            End Get
        End Property

        Public Shared ReadOnly Property WIKO_DeviceManufDate_MinLength() As Integer
            Get
                Return 6
            End Get
        End Property

        Public Shared ReadOnly Property WIKO_SeedStock() As String
            Get
                Return "SeedStock"
            End Get
        End Property

        Public Shared ReadOnly Property WIKO_AttCTDI_Box_Prefix() As String
            Get
                Return "CS0"
            End Get
        End Property

        Public Shared ReadOnly Property WIKO_AttCTDI_Box_Postfix() As String
            Get
                Return "EMB"
            End Get
        End Property

        Public Shared ReadOnly Property WIKO_AttCTDI_BoxName_Len() As Integer
            Get
                Return 20
            End Get
        End Property

        'from table lgroups
        Public Shared ReadOnly Property WIKO_Group_ID() As Integer
            Get
                Return 133
            End Get
        End Property

        Public Shared ReadOnly Property WIKO_RUR_LaborLevel() As Integer
            Get
                Return 17
            End Get
        End Property

        Public Shared ReadOnly Property WIKO_PrcGroup_ID() As Integer
            Get
                Return 333
            End Get
        End Property

        'lprodgrp
        Public Shared ReadOnly Property WIKO_ProdGrp_ID() As Integer
            Get
                Return 203
            End Get
        End Property

        Public Shared ReadOnly Property WIKO_MaxQtyInBox() As Integer
            Get
                Return 20 '20 SNs allowed in a box
            End Get
        End Property

        Public Shared ReadOnly Property WIKO_SPMaxQtyInBox() As Integer
            Get
                Return 1000 '20 SNs allowed in a box
            End Get
        End Property

        Public Shared ReadOnly Property WIKO_Cricket_OEMCustomer_EMS() As String
            Get
                Return "Emblem Solutions" 'IW,  wrty falg=1, Wrranty Exchange
            End Get
        End Property

        Public Shared ReadOnly Property WIKO_Cricket_OEMCustomer_DOA() As String
            Get
                Return "Emblem Solutions DOA" 'OW, wrty flag=0, DOA
            End Get
        End Property

        Public Shared ReadOnly Property WIKO_Cricket_OEMCustomer_EMS_AccountCode() As String
            Get
                Return "569955"
            End Get
        End Property

        Public Shared ReadOnly Property WIKO_Cricket_OEMCustomer_DOA_AccountCode() As String
            Get
                Return "569969"
            End Get
        End Property

        Public Shared ReadOnly Property WIKO_FexEx_WexCode() As String
            Get
                Return "WEX"
            End Get
        End Property

        Public Shared ReadOnly Property WIKO_SeedStockSourceType_ATT() As String
            Get
                Return "ATT"
            End Get
        End Property

        Public Shared ReadOnly Property WIKO_SeedStockSourceType_Cricket() As String
            Get
                Return "Cricket"
            End Get
        End Property

        Public Shared ReadOnly Property WIKO_FexEx_PosCode() As String
            Get
                Return "POS"
            End Get
        End Property

        Public Shared ReadOnly Property WIKO_BER_BillCode_ID() As Integer
            Get
                Return 1020
            End Get
        End Property

        Public Shared ReadOnly Property WIKO_RUR_BillCode_ID() As Integer
            Get
                Return 275
            End Get
        End Property

        Public Shared ReadOnly Property WIKO_RUR_BillCode_ID2() As Integer
            Get
                Return 267
            End Get
        End Property

        Public Shared ReadOnly Property WIKO_RUR_Unrepaired_BillCode_ID() As Integer
            Get
                Return 4454
            End Get
        End Property


        Public Shared ReadOnly Property WIKO_Swap_BillCode_ID() As Integer
            Get
                Return 4600
            End Get
        End Property

        Public Shared ReadOnly Property WIKO_Swap_PSPrice_ID() As Integer
            Get
                Return 31961
            End Get
        End Property

        Public Shared ReadOnly Property WIKO_Swap_LabelLevel() As Integer
            Get
                Return 15
            End Get
        End Property

        Public Shared ReadOnly Property WIKO_Received_WorkStation() As String
            Get
                Return "WH-WIP"
            End Get
        End Property

        'For REF2Seedstock----------------------------------------------------
        Public Shared ReadOnly Property WIKO_REF2SeedPallet_Cricket() As String
            Get
                Return "2624SDS20210301N001"
            End Get
        End Property

        Public Shared ReadOnly Property WIKO_REF2SeedPalletID_Cricket() As Integer
            Get
                Return 373884
            End Get
        End Property

        Public Shared ReadOnly Property WIKO_REF2SeedPallet_AttCTDI() As String
            Get
                Return "2624SDS20210301N002"
            End Get
        End Property

        Public Shared ReadOnly Property WIKO_REF2SeedPalletID_AttCTDI() As Integer
            Get
                Return 373885
            End Get
        End Property

        Public Shared ReadOnly Property WIKO_REF2SeedPallet_AttFedEx() As String
            Get
                Return "2624SDS20210301N003"
            End Get
        End Property

        Public Shared ReadOnly Property WIKO_REF2SeedPalletID_AttFedEx() As Integer
            Get
                Return 373886
            End Get
        End Property


        'Stages--------------------------------------------------------------
        'After Pretest
        Public Shared ReadOnly Property WIKO_PreBill_WorkStation() As String
            Get
                Return "PRE-BILL"
            End Get
        End Property

        'After TechBill
        Public Shared ReadOnly Property WIKO_Label_WorkStation() As String
            Get
                Return "LABEL"
            End Get
        End Property

        'After Label
        Public Shared ReadOnly Property WIKO_FQA_WorkStation() As String
            Get
                Return "FQA"
            End Get
        End Property

        Public Shared ReadOnly Property WIKO_DeviceSwap_WorkStation() As String
            Get
                Return "SWAPPED"
            End Get
        End Property

        'After Build/Produce
        Public Shared ReadOnly Property WIKO_BuildProduce_WorkStation() As String
            Get
                Return "IN-TRANSIT"
            End Get
        End Property


        'Work flow: RAM - Receiving - PreTest - TechBill - Label - FQA _RF Test - Flash - AQL - Build Box - Produce Box - Manifest
        'Workstation after each process: Receving - WH-WIP - Pre-Bill - Label
#End Region

#End Region

#Region "SQL Data"

        Public Function getWIKOModels(ByVal iCust_ID As Integer, ByVal booAddSelectRow As Boolean) As DataTable
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
                strSql = "SELECT Description,CustIDs as 'Cust_ID', Generic AS 'Qty' FROM exceptioncriteria WHERE description = 'WIKO_REV_BOX_MAX_QTY' AND CustIds='" & Me.WIKO_CUSTOMER_ID.ToString & "'" & ";"

                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 AndAlso IsNumeric(dt.Rows(0).Item("Qty")) Then iRet = Convert.ToInt32(dt.Rows(0).Item("Qty"))

                Return iRet
            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing
            End Try
        End Function

        Public Function getUserComplaint(ByVal iCust_ID As Integer, ByVal iLoc_ID As Integer, ByVal iDevice_ID As Integer) As String
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim strRet As String = ""


            Try
                If iCust_ID = Me.WIKO_CUSTOMER_ID And iLoc_ID = Me.WIKO_AttCTDI_LOC_ID Then
                    strSql = "SELECT Return_Reason AS 'UserCompliant',Cust_ID,Loc_ID FROM production.extendedwarranty WHERE Device_ID=" & iDevice_ID & " And Cust_ID=" & iCust_ID & " And Loc_ID=" & iLoc_ID & ";"
                    dt = Me._objDataProc.GetDataTable(strSql)
                ElseIf iCust_ID = Me.WIKO_CUSTOMER_ID And (iLoc_ID = Me.WIKO_AttCricket_LOC_ID OrElse iLoc_ID = Me.WIKO_AttFedEx_LOC_ID) Then
                    strSql = "SELECT Failure_Reason AS 'UserCompliant',Cust_ID,Loc_ID FROM production.extendedwarranty WHERE Device_ID=" & iDevice_ID & " And Cust_ID=" & iCust_ID & " And Loc_ID=" & iLoc_ID & ";"
                    dt = Me._objDataProc.GetDataTable(strSql)
                End If

                If dt.Rows.Count > 0 AndAlso Not dt.Rows(0).IsNull("UserCompliant") Then strRet = dt.Rows(0).Item("UserCompliant")

                Return strRet
            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing
            End Try
        End Function

        '

#End Region

    End Class
End Namespace