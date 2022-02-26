Imports PSS.Data.Buisness.PartsMap

Namespace Rules

    Public Class PartsMap

        Public Shared Function MappedDataView() As DataView
            Return GetMappedData.DefaultView
        End Function

        Public Shared Function DeleteDataMap(ByVal id As Integer) As Boolean
            If MsgBox("Are you sure you want to delete this map?", MsgBoxStyle.YesNo, "Confirm Delete") = MsgBoxResult.Yes Then
                DeleteMap(id, PSS.Core.ApplicationUser.IDuser)
                Return True
            End If
            Return False
        End Function

        Public Shared Function UpdateDataMap(ByVal id As Integer) As Boolean
            Dim updateWin As New PSS.Gui.PartsMapEditWin(id)
            updateWin.ShowDialog()
            Return True
        End Function

        Public Shared Function NewDataMap() As Boolean
            Dim newWin As New PSS.Gui.PartsMapEditWin(0)
            Try
                newWin.ShowDialog()
                Return False
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function GetMappedDataItem(ByVal id) As DataRow
            Try
                Return PSS.Data.Buisness.PartsMap.GetMappedDataItem(id)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Sub InsertDataMap(ByVal Price As Integer, ByVal BillCode As Integer, ByVal Model As Integer, ByVal Product As Integer, ByVal LaborLevel As Integer, ByVal iLineOfBusinessID As Integer, ByVal iInvisible As Integer, ByVal iLaborLevel As Integer, ByVal iReflowTypeID As Integer)
            Try
                InsertMap(Price, BillCode, Model, Product, LaborLevel, iLineOfBusinessID, iInvisible, iLaborLevel, iReflowTypeID, PSS.Core.[Global].ApplicationUser.IDuser)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Sub UpdateDataMap(ByVal Price As Integer, ByVal BillCode As Integer, ByVal Model As Integer, ByVal Product As Integer, ByVal LaborLevel As Integer, ByVal iLineOfBusinessID As Integer, ByVal id As Integer, ByVal iInvisible As Integer, ByVal iLaborLevel As Integer, ByVal iReflowTypeID As Integer)
            Try
                UpdateMap(Price, BillCode, Model, Product, LaborLevel, iLineOfBusinessID, id, iInvisible, iLaborLevel, iReflowTypeID, PSS.Core.[Global].ApplicationUser.IDuser)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function GetModels() As DataTable
            Try
                Return PSS.Data.Buisness.ModManuf.GetModels
            Catch ex As Exception
                Throw ex
            End Try
        End Function

    End Class

End Namespace
