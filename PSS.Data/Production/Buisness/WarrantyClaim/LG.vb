Option Explicit On 

Imports System.IO

Namespace Buisness.WarrantyClaim
    Public Class LG

        Public Const LG_Manuf_ID As Integer = 16
        Public _strLastDateInWarranty As String = Nothing
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

        '*********************************************************************************
        Public Function CalWarrantyStatus(ByVal strDateCode As String, _
                                          Optional ByVal strToday As String = "") As Integer
            Dim dteManuf, dteLastDateOfWrty, dte15MonthAfterManufDate As Date
            Dim iInWrty, iTodayYr, iManufYr As Integer
            Dim strLastDigitManufYr, strManufMonth As String

            Try
                If strDateCode.Trim.Length > 3 Then strDateCode = Left(strDateCode, 3)

                iInWrty = -1 : _strLastDateInWarranty = Nothing

                strLastDigitManufYr = Left(strDateCode, 1) : strManufMonth = Right(strDateCode, 2)

                '1:Get current date from server
                If strToday.Trim.Length = 0 Then strToday = Buisness.Generic.GetMySqlDateTime("%Y-%m-%d")

                iTodayYr = Year(CDate(strToday))

                'Construct Manufacture Year
                If CInt(Right(iTodayYr.ToString, 1)) >= CInt(strLastDigitManufYr) Then
                    iManufYr = CInt(Left(iTodayYr.ToString, 3) & strLastDigitManufYr)
                Else
                    iManufYr = CInt(Left((iTodayYr - 10).ToString, 3) & strLastDigitManufYr)
                End If

                ''2: construct manufacture date
                dteManuf = CDate(iManufYr.ToString & "-" & strManufMonth & "-" & Date.DaysInMonth(iManufYr, CInt(strManufMonth)).ToString)

                If dteManuf > CDate(strToday) Then Throw New Exception("System can't define manufacture date. Please contact IT.")

                '3: Add 15 months to manufacture date
                dte15MonthAfterManufDate = DateAdd(DateInterval.Month, 15, dteManuf)

                '4: construct last date of warranty
                dteLastDateOfWrty = CDate(Year(dte15MonthAfterManufDate) & "-" & Month(dte15MonthAfterManufDate) & "-" & Date.DaysInMonth(Year(dte15MonthAfterManufDate), Month(dte15MonthAfterManufDate)))

                If CDate(strToday) <= dteLastDateOfWrty Then iInWrty = 1 Else iInWrty = 0

                _strLastDateInWarranty = Format(dteLastDateOfWrty, "yyyy-MM-dd")

                Return iInWrty
            Catch ex As Exception
                CalWarrantyStatus = -1
                Throw ex
            Finally
                dteManuf = Nothing
                dteLastDateOfWrty = Nothing
                dte15MonthAfterManufDate = Nothing
            End Try
        End Function

        '*********************************************************************************

    End Class
End Namespace