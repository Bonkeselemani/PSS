Imports PSS.Data

Namespace Rules

    Public Class BillCode

        Public Shared Function GetView() As DataView
            Return Buisness.BillCode.GetDataView.DefaultView
        End Function

        Public Shared Function DeleteBillCode(ByVal BillCode As Integer) As Boolean
            Try
                Buisness.BillCode.DeleteBillCode(BillCode)
                Return True
            Catch
                Return False
            End Try
        End Function

        Public Shared Function UpdateBillCode(ByVal desc As String, ByVal devid As Integer, ByVal rule As Integer, ByVal type As Integer, ByVal fail As Integer, ByVal repair As Integer, ByVal id As Integer) As Boolean
            Try
                Buisness.BillCode.UpdateBillCode(id, desc, devid, rule, type, fail, repair)
                Return True
            Catch
                Return False
            End Try
        End Function

        Public Shared Function InsertBillCode(ByVal desc As String, ByVal devid As Integer, ByVal rule As Integer, ByVal type As Integer, ByVal fail As Integer, ByVal repair As Integer) As Boolean
            Try
                Buisness.BillCode.InsertBillCode(doapps(desc), devid, rule, type, fail, repair)
                Return True
            Catch exp As Exception
                MsgBox(exp.ToString)
                Return False
            End Try
        End Function

        Private Shared Function doapps(ByVal [string] As String) As String
            Return Replace([string], "'", "''").ToString()
        End Function

        Public Shared Function GetBillTypes() As DataTable
            Return Buisness.BillCode.GetBillTypes()
        End Function

        Public Shared Function GetDeviceTypes() As DataTable
            Return Buisness.BillCode.GetDeviceTypes()
        End Function

        Public Shared Function GetFailCodes() As DataTable
            Return Buisness.BillCode.GetFailCodes
        End Function

        Public Shared Function GetRepCodes(Optional ByVal iProd_ID As Integer = 0) As DataTable
            Return Buisness.BillCode.GetRepCodes(iProd_ID)
        End Function

        Public Shared Function GetBillRules() As DataTable
            Return Buisness.BillCode.GetBillRules
        End Function

        Public Shared Function GetBillCode(ByVal billCode) As DataRow
            Return Buisness.BillCode.GetBillCode(billCode).Rows(0)
        End Function

    End Class

End Namespace