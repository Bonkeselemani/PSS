Option Explicit On 

Imports System
Imports System.Data
Imports System.Text
Imports MySql.Data
Imports System.IO

Namespace Buisness.VV
    Public Class Vivint
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
        Public Shared ReadOnly Property Vivint_CUSTOMER_ID() As Integer
            Get
                Return 2626
            End Get
        End Property

        Public Shared ReadOnly Property Vivint_VBP1_Loc_ID() As Integer
            Get
                Return 4486
            End Get
        End Property

        Public Shared ReadOnly Property Vivint_VRQA_Loc_ID() As Integer
            Get
                Return 4488
            End Get
        End Property

        Public Shared ReadOnly Property Vivint_VRQA_MCode_ID() As Integer
            Get
                Return 94
            End Get
        End Property

        'lproduct
        Public Shared ReadOnly Property Vivint_Product_ID() As Integer
            Get
                Return 75
            End Get
        End Property

        'lprodgrp
        Public Shared ReadOnly Property Vivint_ProductGroup_ID() As Integer
            Get
                Return 204
            End Get
        End Property

        'lgroups
        Public Shared ReadOnly Property Vivint_Group_ID() As Integer
            Get
                Return 134
            End Get
        End Property

        Public Shared ReadOnly Property Vivint_Kitting_BillCode_ID() As Integer
            Get
                Return 4613
            End Get
        End Property

        Public Shared ReadOnly Property Vivint_KittingLimit_BillCode_ID() As Integer
            Get
                Return 4614
            End Get
        End Property

        ''SeedStock data: BulkORderType_ID = 0, Bulk data: BulkORderType_ID = 1, End-User data: BulkORderType_ID = 2
        'Public Shared ReadOnly Property CoolPad_OrderTypeSeedStock_ID() As Integer
        '    Get
        '        Return 0
        '    End Get
        'End Property
        'Public Shared ReadOnly Property CoolPad_OrderTypeBulk_ID() As Integer
        '    Get
        '        Return 1
        '    End Get
        'End Property
        'Public Shared ReadOnly Property CoolPad_OrderTypeEndUser_ID() As Integer
        '    Get
        '        Return 2
        '    End Get
        'End Property



        'Public Shared ReadOnly Property CoolPad_RUR_LaborLevel() As Integer
        '    Get
        '        Return 17 'need recheck this
        '    End Get
        'End Property

        'Public Shared ReadOnly Property CoolPad_PrcGroup_ID() As Integer
        '    Get
        '        Return 337
        '    End Get
        'End Property



        Public Shared ReadOnly Property CoolPad_BER_BillCode_ID() As Integer
            Get
                Return 2325
            End Get
        End Property


        Public Shared ReadOnly Property CoolPad_BER_Limit_BillCode_ID() As Integer
            Get
                Return 4614
            End Get
        End Property

        Public Shared ReadOnly Property CoolPad_SCR_BillCode_ID() As Integer
            Get
                Return 4630
            End Get
        End Property

        'Public Shared ReadOnly Property CoolPad_RUR_BillCode_ID() As Integer
        '    Get
        '        Return 275
        '    End Get
        'End Property


        ''Public Shared ReadOnly Property CoolPad_MaxQtyInBox() As Integer
        ''    Get
        ''        Return 20 '20 SNs allowed in a box
        ''    End Get
        ''End Property

        Public Shared ReadOnly Property CoolPad_Received_WorkStation() As String
            Get
                Return "WH-WIP"
            End Get
        End Property

        'After Pretest
        Public Shared ReadOnly Property Vivint_PreBill_WorkStation() As String
            Get
                Return "PRE-BILL"
            End Get
        End Property

        'After TechBill
        Public Shared ReadOnly Property Vivint_Label_WorkStation() As String
            Get
                Return "LABEL"
            End Get
        End Property

        'After Label
        Public Shared ReadOnly Property Vivint_FQA_WorkStation() As String
            Get
                Return "FQA"
            End Get
        End Property

        'Public Shared ReadOnly Property Vivint_DeviceSwap_WorkStation() As String
        '    Get
        '        Return "SWAPPED"
        '    End Get
        'End Property

        Public Shared ReadOnly Property Vivint_BuildBoxReady_WorkStation() As String
            Get
                Return "PRODUCTION STAGING"
            End Get
        End Property

        Public Shared ReadOnly Property Vivint_BuildBox_WorkStation() As String
            Get
                Return "PRODUCE"
            End Get
        End Property

        Public Shared ReadOnly Property Vivint_ProduceBox_WorkStation() As String
            Get
                Return "PRODUCTION COMPLETED"
            End Get
        End Property

        Public Shared ReadOnly Property Vivint_Manifested_WorkStation() As String
            Get
                Return "IN-TRANSIT"
            End Get
        End Property

#End Region


        Public Function getMaxBuildBoxQty() As Integer 'for BuildBox screen
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim iRet As Integer = 0

            Try
                strSql = "SELECT Description,CustIDs as 'Cust_ID', Generic AS 'Qty' FROM exceptioncriteria WHERE description = 'VIVINT_BUILD_BOX_MAX_QTY' AND CustIds='" & Me.Vivint_CUSTOMER_ID.ToString & "'" & ";"

                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 AndAlso IsNumeric(dt.Rows(0).Item("Qty")) Then iRet = Convert.ToInt32(dt.Rows(0).Item("Qty"))

                Return iRet
            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing
            End Try
        End Function

        Public Function getMaxDockShipPalletQty() As Integer 'For Manifest DockShip
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim iRet As Integer = 0

            Try
                strSql = "SELECT Description,CustIDs as 'Cust_ID', Generic AS 'Qty' FROM exceptioncriteria WHERE description = 'VIVINT_SHIP_PALLET_MAX_QTY' AND CustIds='" & Me.Vivint_CUSTOMER_ID.ToString & "'" & ";"

                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 AndAlso IsNumeric(dt.Rows(0).Item("Qty")) Then iRet = Convert.ToInt32(dt.Rows(0).Item("Qty"))

                Return iRet
            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing
            End Try
        End Function

        Public Function getVivintModelData(ByVal iProd_ID As Integer, ByVal iProdGrp_ID As Integer, Optional ByVal bHasRecID As Boolean = False) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim i As Integer = 0
            Dim row As DataRow

            Try
                If bHasRecID Then
                    strSql = "SELECT 0 AS 'RecID', A.* from tmodel A where A.prodGrp_ID=" & iProdGrp_ID & " and prod_ID=" & iProd_ID & ";"
                    dt = Me._objDataProc.GetDataTable(strSql)
                    For Each row In dt.Rows
                        i += 1
                        row.BeginEdit() : row("RecID") = i : row.AcceptChanges()
                    Next
                Else
                    strSql = "SELECT  A.* from tmodel A where A.prodGrp_ID=" & iProdGrp_ID & " and prod_ID=" & iProd_ID & ";"
                    dt = Me._objDataProc.GetDataTable(strSql)
                End If

                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getWarrantyTypeData() As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT 0 AS 'Wrty_ID','OUT OF WARRANTY' AS 'Wrty_Desc','OW' AS 'BoxNamePart'" & Environment.NewLine
                strSql &= " UNION ALL" & Environment.NewLine
                strSql &= " SELECT 1 AS 'Wrty_ID','IN WARRANTY' AS 'Wrty_Desc','IW' AS 'BoxNamePart'" & Environment.NewLine
                strSql &= " UNION ALL" & Environment.NewLine
                strSql &= " SELECT 2 AS 'Wrty_ID','NO WARRANTY' AS 'Wrty_Desc','NW' AS 'BoxNamePart';" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function RemovePrefixSN(ByVal strSN As String, ByVal iCust_ID As Integer, _
                                       Optional ByVal iLoc_ID As Integer = 0, _
                                       Optional ByVal iModel_ID As Integer = 0) As String
            Dim strSql As String = ""
            Dim dt As DataTable, row As DataRow
            Dim strRet As String = strSN
            Dim strS As String = ""

            Try

                strSql = "SELECT Remove_Prefix FROM warehouse.SerialNumberPattern WHERE Cust_ID=" & iCust_ID
                If iLoc_ID > 0 Then strSql &= " AND Loc_ID=" & iLoc_ID
                If iModel_ID > 0 Then strSql &= " AND Model_ID=" & iModel_ID
                strSql &= " AND Remove_Prefix IS NOT NULL AND LENGTH(TRIM(Remove_Prefix))>0 AND IsActive=1;"

                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    For Each row In dt.Rows
                        If Not row.IsNull("Remove_Prefix") AndAlso Convert.ToString(row("Remove_Prefix")).Trim.Length > 0 Then
                            strS = Convert.ToString(row("Remove_Prefix")).Trim
                            If strSN.Trim.Length >= strS.Length AndAlso Left(strSN.Trim, strS.Length).ToUpper = strS.ToUpper Then
                                strRet = Right(strSN.Trim, strSN.Trim.Length - strS.Length)
                                Exit For
                            End If
                        End If
                    Next
                End If
            Catch ex As Exception
                Throw ex
            End Try

            Return strRet
        End Function
    End Class
End Namespace