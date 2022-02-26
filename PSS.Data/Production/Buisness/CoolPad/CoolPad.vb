Option Explicit On 

Imports System
Imports System.Data
Imports System.Text
Imports MySql.Data
Imports System.IO

Namespace Buisness.CP
    Public Class CoolPad
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
        Public Shared ReadOnly Property CoolPad_CUSTOMER_ID() As Integer
            Get
                Return 2627
            End Get
        End Property

        Public Shared ReadOnly Property CoolPad_CP1_Loc_ID() As Integer
            Get
                Return 4487
            End Get
        End Property

        Public Shared ReadOnly Property CoolPad_Special_LOC_ID() As Integer
            Get
                Return 4497
            End Get
        End Property

        Public Shared ReadOnly Property CoolPad_CP1_MCode_ID() As Integer
            Get
                Return 93
            End Get
        End Property

        Public Shared ReadOnly Property CoolPad_Product_ID() As Integer
            Get
                Return 2
            End Get
        End Property

        'RepairProgramType
        Public Shared ReadOnly Property CoolPad_RepairProgramType() As ArrayList
            Get
                Dim arrList As New ArrayList()
                arrList.Add("OUT OF WARRANTY")
                arrList.Add("IN WARRANTY")
                arrList.Add("DOA")
                arrList.Add("EWP")
                arrList.Add("SCAR")

                Return arrList
            End Get
        End Property

        'SeedStock data: BulkORderType_ID = 0, Bulk data: BulkORderType_ID = 1, End-User data: BulkORderType_ID = 2
        Public Shared ReadOnly Property CoolPad_OrderTypeSeedStock_ID() As Integer
            Get
                Return 0
            End Get
        End Property
        Public Shared ReadOnly Property CoolPad_OrderTypeBulk_ID() As Integer
            Get
                Return 1
            End Get
        End Property
        Public Shared ReadOnly Property CoolPad_OrderTypeEndUser_ID() As Integer
            Get
                Return 2
            End Get
        End Property

        'lgroups
        Public Shared ReadOnly Property CoolPad_Group_ID() As Integer
            Get
                Return 135
            End Get
        End Property

        Public Shared ReadOnly Property CoolPad_RUR_LaborLevel() As Integer
            Get
                Return 17 'need recheck this
            End Get
        End Property

        Public Shared ReadOnly Property CoolPad_PrcGroup_ID() As Integer
            Get
                Return 337
            End Get
        End Property

        Public Shared ReadOnly Property CoolPad_ProdGrp_ID() As Integer
            Get
                Return 205
            End Get
        End Property

        Public Shared ReadOnly Property CoolPad_BER_BillCode_ID() As Integer
            Get
                Return 1020
            End Get
        End Property

        Public Shared ReadOnly Property CoolPad_RUR_BillCode_ID() As Integer
            Get
                Return 275
            End Get
        End Property

        Public Shared ReadOnly Property CoolPad_RUR_BillCode_ID2() As Integer
            Get
                Return 267
            End Get
        End Property

        Public Shared ReadOnly Property CoolPad_Swap_BillCode_ID() As Integer
            Get
                Return 4600
            End Get
        End Property

        Public Shared ReadOnly Property CoolPad_Swap_PSPrice_ID() As Integer
            Get
                Return 31961
            End Get
        End Property

        Public Shared ReadOnly Property CoolPad_Swap_LabelLevel() As Integer
            Get
                Return 15
            End Get
        End Property

        'Public Shared ReadOnly Property CoolPad_MaxQtyInBox() As Integer
        '    Get
        '        Return 20 '20 SNs allowed in a box
        '    End Get
        'End Property

        Public Shared ReadOnly Property Coolpad_REF2SeedPallet() As String
            Get
                Return "2627SDS20210301N001"
            End Get
        End Property

        Public Shared ReadOnly Property Coolpad_REF2SeedPalletID() As Integer
            Get
                Return 373887
            End Get
        End Property

        Public Shared ReadOnly Property CoolPad_Received_WorkStation() As String
            Get
                Return "WH-WIP"
            End Get
        End Property

        'After Pretest
        Public Shared ReadOnly Property CoolPad_PreBill_WorkStation() As String
            Get
                Return "PRE-BILL"
            End Get
        End Property

        'After TechBill
        Public Shared ReadOnly Property CoolPad_Label_WorkStation() As String
            Get
                Return "LABEL"
            End Get
        End Property

        'After Label
        Public Shared ReadOnly Property CoolPad_FQA_WorkStation() As String
            Get
                Return "FQA"
            End Get
        End Property

        Public Shared ReadOnly Property CoolPad_DeviceSwap_WorkStation() As String
            Get
                Return "SWAPPED"
            End Get
        End Property

        Public Shared ReadOnly Property CoolPad_BuildBoxReady_WorkStation() As String
            Get
                Return "PRODUCTION STAGING"
            End Get
        End Property

        Public Shared ReadOnly Property CoolPad_BuildBox_WorkStation() As String
            Get
                Return "PRODUCE"
            End Get
        End Property

        Public Shared ReadOnly Property CoolPad_ProduceBox_WorkStation() As String
            Get
                Return "PRODUCTION COMPLETED"
            End Get
        End Property

        Public Shared ReadOnly Property CoolPad_Manifested_WorkStation() As String
            Get
                Return "IN-TRANSIT"
            End Get
        End Property

#End Region

        Public Function getMaxReceivingBoxQty() As Integer 'For Receiving screen
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim iRet As Integer = 0

            Try
                strSql = "SELECT Description,CustIDs as 'Cust_ID', Generic AS 'Qty' FROM exceptioncriteria WHERE description = 'COOLPAD_REV_BOX_MAX_QTY' AND CustIds='" & Me.CoolPad_CUSTOMER_ID.ToString & "'" & ";"

                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 AndAlso IsNumeric(dt.Rows(0).Item("Qty")) Then iRet = Convert.ToInt32(dt.Rows(0).Item("Qty"))

                Return iRet
            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing
            End Try
        End Function

        Public Function getMaxBuildBoxQty() As Integer 'for BuildBox screen
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim iRet As Integer = 0

            Try
                strSql = "SELECT Description,CustIDs as 'Cust_ID', Generic AS 'Qty' FROM exceptioncriteria " & vbCrLf
                strSql &= "WHERE description = 'COOLPAD_BUILD_BOX_MAX_QTY' AND CustIds='" & Me.CoolPad_CUSTOMER_ID.ToString & "'" & ";"

                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 AndAlso IsNumeric(dt.Rows(0).Item("Qty")) Then
                    iRet = Convert.ToInt32(dt.Rows(0).Item("Qty"))
                    Return iRet
                Else
                    Return 0
                End If

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
                strSql = "SELECT Description,CustIDs as 'Cust_ID', Generic AS 'Qty' FROM exceptioncriteria WHERE description = 'COOLPAD_SHIP_PALLET_MAX_QTY' AND CustIds='" & Me.CoolPad_CUSTOMER_ID.ToString & "'" & ";"

                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 AndAlso IsNumeric(dt.Rows(0).Item("Qty")) Then iRet = Convert.ToInt32(dt.Rows(0).Item("Qty"))

                Return iRet
            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing
            End Try
        End Function

    End Class
End Namespace