Option Explicit On 

Namespace Buisness.WarrantyClaim
    Public Class Generic

        '******************************************************************************
        Public Shared Function Alcatel_GetWrtyStatusAndLastDateInWrty(ByVal strDateCode As String) As DataRow
            Dim objWrty As UnderWarrantyNET1.Alcatel
            Dim R1 As DataRow

            Try
                objWrty = New UnderWarrantyNET1.Alcatel()
                Return objWrty.WStatusAndWCoverageByDate(strDateCode)

            Catch ex As Exception
                Throw ex
            Finally
                objWrty = Nothing
            End Try
        End Function

        '******************************************************************************
        Public Shared Function Unimax_GetWrtyStatusAndLastDateInWrty(ByVal strDateCode As String) As DataRow
            Dim objWrty As UnderWarrantyNET1.Unimax
            Dim R1 As DataRow

            Try
                objWrty = New UnderWarrantyNET1.Unimax()
                Return objWrty.WStatusAndWCoverageByDate(strDateCode)

            Catch ex As Exception
                Throw ex
            Finally
                objWrty = Nothing
            End Try
        End Function

        '******************************************************************************

    End Class
End Namespace