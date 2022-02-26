Imports PSS.Data

Namespace Rules

    Public Class Pricing

        Public Shared Function GetData() As DataView
            Return Buisness.Pricing.GetPrices.DefaultView
        End Function

        Public Shared Function Insert(ByVal pNum As String, ByVal pDesc As String, ByVal aCost As Double, ByVal sCost As Double, ByVal iInvFlg As Integer, ByVal iCPFlg As Integer, ByVal iMaxQty As Integer, ByVal strMaterialGrp As String) As Boolean
            If MsgBox("Are you sure you wish to insert this pricing?", MsgBoxStyle.YesNo, "Insert") = MsgBoxResult.Yes Then
                Try
                    Buisness.Pricing.InsertPrice(pNum, pDesc, aCost, sCost, iInvFlg, iCPFlg, iMaxQty, strMaterialGrp)
                    Return True
                Catch
                    Return False
                End Try
            End If
        End Function

        Public Shared Function Update(ByVal id As Integer, ByVal pNum As String, ByVal pDesc As String, ByVal aCost As Double, ByVal sCost As Double, ByVal iInvFlg As Integer, ByVal iCPFlg As Integer, ByVal iMaxQty As Integer, ByVal strMaterialGrp As String) As Boolean
            If MsgBox("Are you sure you wish to update this pricing?", MsgBoxStyle.YesNo, "Update") = MsgBoxResult.Yes Then
                Try
                    Buisness.Pricing.UpdatePrice(id, pNum, pDesc, aCost, sCost, iInvFlg, iCPFlg, iMaxQty, strMaterialGrp)
                    Return True
                Catch
                    Return False
                End Try
            End If
        End Function

        Public Shared Function Delete(ByVal id As Integer) As Boolean
            If MsgBox("Are you sure you wish to delete this pricing?", MsgBoxStyle.YesNo, "Delete") = MsgBoxResult.Yes Then
                Try
                    Return Buisness.Pricing.DeletePrice(id)
                Catch
                    Return False
                End Try
            End If
        End Function

        Private Shared Function doFormat(ByVal str As String, ByVal appsOnly As Boolean) As String
            Dim iRtr As String = Replace(str, "'", "''")
            If Not appsOnly Then
                iRtr = UCase(iRtr)
            End If
            Return iRtr
        End Function

    End Class

End Namespace