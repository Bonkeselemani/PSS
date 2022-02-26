Option Explicit On 

Namespace Buisness.Billing
    Public Class BillingData

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

        '******************************************************************
        Public Function GetPartBillcodes(ByVal iCustID As Integer, _
                                         ByVal iModelID As Integer, _
                                         Optional ByVal iLessThanLaborLevel As Integer = 0, _
                                         Optional ByVal iGreaterThanLaborLevel As Integer = 0, _
                                         Optional ByVal iRVFlag As Integer = 0) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT lbillcodes.*, lpsprice.psprice_number, ReflowTypeID, lpsprice.PSPrice_ConsignedPart " & Environment.NewLine
                strSql &= "FROM lbillcodes " & Environment.NewLine
                strSql &= "INNER JOIN tpsmap ON lbillcodes.billcode_id = tpsmap.billcode_id " & Environment.NewLine
                strSql &= "INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tbilldisplayexceptions ON tpsmap.model_id = tbilldisplayexceptions.model_id AND tpsmap.billcode_id = tbilldisplayexceptions.billcode_id " & Environment.NewLine
                strSql &= "AND tbilldisplayexceptions.cust_id = " & iCustID & " " & Environment.NewLine
                strSql &= "WHERE tpsmap.model_id = " & iModelID & " " & Environment.NewLine
                strSql &= "AND billtype_id = 2 " & Environment.NewLine
                'strSql &= "AND lpsprice.psprice_consignedpart = 0 " & Environment.NewLine
                strSql &= "AND tpsmap.Inactive = 0 " & Environment.NewLine
                If iLessThanLaborLevel > 0 Then strSql &= "AND tpsmap.LaborLevel < " & iLessThanLaborLevel & Environment.NewLine
                If iGreaterThanLaborLevel > 0 Then strSql &= "AND tpsmap.LaborLevel > " & iGreaterThanLaborLevel & Environment.NewLine
                strSql &= "AND (tbilldisplayexceptions.cust_id is null or tbilldisplayexceptions.cust_id = " & iCustID & ") " & Environment.NewLine
                strSql &= "AND (tbilldisplayexceptions.display_type is null or tbilldisplayexceptions.tech = 0) " & Environment.NewLine
                strSql &= "AND lpsprice.RVFlag = " & iRVFlag & Environment.NewLine
                strSql &= "ORDER BY BillCode_Desc"

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************

    End Class
End Namespace