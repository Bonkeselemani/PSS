Option Explicit On 

Namespace Buisness.WarrantyClaim
    Public Class Huawei

        ''************************************************************************************************
        'Public Shared Function GetWrtyStatusAndLastDateInWrty(ByVal strDateCode As String) As DataRow
        '    Dim objWrty As UnderWarrantyNET1.Huawei
        '    Dim R1 As DataRow

        '    Try
        '        objWrty = New UnderWarrantyNET1.Huawei()
        '        Return objWrty.WStatusAndWCoverageByDate(strDateCode)

        '    Catch ex As Exception
        '        Throw ex
        '    Finally
        '        objWrty = Nothing
        '    End Try
        'End Function

        '************************************************************************************************
        Public Shared Function GetWrtyStatusAndLastDateInWrty(ByVal iManufMonth As Integer, ByVal iManufDay As Integer, ByVal iManufYear As Integer, ByVal dteReceiptDate As Date) As DataRow
            Dim objWrty As UnderWarrantyNET1.Huawei
            Dim R1 As DataRow
            Dim dteManuf As Date

            Try
                dteManuf = New Date(iManufYear, iManufMonth, iManufDay, 23, 59, 59)
                objWrty = New UnderWarrantyNET1.Huawei()
                Return objWrty.CalManufWarrantyStatus(dteManuf, dteReceiptDate)

            Catch ex As Exception
                Throw ex
            Finally
                objWrty = Nothing
            End Try
        End Function

        '************************************************************************************************

    End Class
End Namespace