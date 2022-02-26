Namespace GeneralShift

    Module objShift

        Public Function getShift(ByVal vUser As String) As Integer

            Dim tmpShift As Integer = 0

            '//Asif is setting up a global variable
            '//Read this value and if it is greater than 0 then
            '//Return that value
            tmpShift = PSS.Core.Global.ApplicationUser.IDShift
            If tmpShift > 0 Then
                Return tmpShift
            End If
            '//If value is 0 then continue this process
            Dim lstTech As New PSS.Data.Production.tusers()
            Dim dtTech As DataTable = lstTech.GetCellTechList
            Dim tmpUser As String

            tmpUser = PSS.Core.Global.ApplicationUser.User

            Dim xCount As Integer
            Dim r As DataRow

            For xCount = 0 To dtTech.Rows.Count - 1
                r = dtTech.Rows(xCount)
                If tmpUser = r("user_fullname") Then
                    tmpShift = r("Shift_ID")
                    Exit For
                End If
            Next

            dtTech = Nothing

            Return tmpShift

        End Function



    End Module

End Namespace


