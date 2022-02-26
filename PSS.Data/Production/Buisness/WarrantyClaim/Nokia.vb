Option Explicit On 

Imports System.Windows.Forms

Namespace Buisness.WarrantyClaim
    Public Class Nokia

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
        Public Shared Function GetWrtyStatusAndLastDateInWrty(ByVal strDateCode As String) As DataRow
            Dim objWrty As UnderWarrantyNET1.Nokia
           Dim R1 As DataRow

            Try
                objWrty = New UnderWarrantyNET1.Nokia()
                Return objWrty.WStatusAndWCoverageByDate(strDateCode)

            Catch ex As Exception
                Throw ex
            Finally
                objWrty = Nothing
            End Try
        End Function

        '******************************************************************
        Public Shared Function GetManufacturingCountryID(ByVal strCountryCodeChar As String) As Integer
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                strSql = "SELECT mc_id FROM nokiamanufcountrymap WHERE ManufCountryChar = '" & strCountryCodeChar & "'"
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetIntValue(strSql)

            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '******************************************************************

    End Class
End Namespace