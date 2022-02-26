
Option Explicit On 

Namespace Buisness.WarrantyClaim
    Public Class ZTE

        '************************************************************************************************
        Public Shared Function GetWrtyStatusAndLastDateInWrty(ByVal iAltDateCode As Integer, _
                                                              ByVal strDateCode As String, _
                                                              Optional ByVal bAlphaMethod As Boolean = False) As DataRow
            Dim objWrty As UnderWarrantyNET1.ZTE
            Dim R1 As DataRow

            Try
                objWrty = New UnderWarrantyNET1.ZTE()
                If bAlphaMethod Then
                    Return objWrty.WStatusAndWCoverageByDate_AlphaMethod(iAltDateCode, strDateCode)
                Else
                    Return objWrty.WStatusAndWCoverageByDate(iAltDateCode, strDateCode)
                End If
                'Return objWrty.WStatusAndWCoverageByDate(iAltDateCode, strDateCode)

            Catch ex As Exception
                Throw ex
            Finally
                objWrty = Nothing
            End Try
        End Function

        '************************************************************************************************
        Public Shared Function GetAltWrtyDateCodeFlag(ByVal iModelID As Integer) As Integer
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc
            Dim dt As DataTable

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT AltWrtyDateCode FROM tmodel WHERE Model_ID = " & iModelID & Environment.NewLine
                dt = objDataProc.GetDataTable(strSql)
                If dt.Rows.Count = 0 Then Throw New Exception("Can't define alternative date code flag.")

                Return CInt(dt.Rows(0)(0))
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing : Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '************************************************************************************************


    End Class
End Namespace