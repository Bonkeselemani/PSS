Public Class genAutoBill

    Dim objMisc As PSS.Data.Production.Misc
    Dim strSQL As String

    Protected Overrides Sub Finalize()
        objMisc = Nothing
        MyBase.Finalize()
    End Sub

    Public Function ab_ADD(ByVal DeviceID As Long, ByVal BillCodeID As Integer, ByVal iProd As Integer) As Boolean

        Dim myDev As New PSS.Rules.Device(DeviceID)
        Try
            If iProd = 1 Then 'MESSAGING DEVICE
                myDev.AddPart(BillCodeID)
            ElseIf iProd = 2 Then 'CELLULAR DEVICE
                myDev.AddPartCELL(BillCodeID, 0, 0)
            ElseIf iProd = 5 Then
                myDev.AddPartCELL(BillCodeID, 0, 0)
            Else
                Return False
            End If
            Return True
        Catch ex As Exception
            Return False
        Finally
            myDev.Update()
            myDev.Close()
            myDev = Nothing
        End Try
    End Function

    Public Function ab_DELETE(ByVal DeviceID As Long, ByVal BillCodeID As Integer) As Boolean

        Dim myDev As New PSS.Rules.Device(DeviceID)
        Try
            myDev.DeletePart(BillCodeID)
            Return True
        Catch ex As Exception
            Return False
        Finally
            myDev.Update()
            myDev.Close()
            myDev = Nothing
        End Try
    End Function

End Class
