Imports eInfoDesigns.dbProvider.MySqlClient
Imports PSS.Data.Production
Imports System.Windows.Forms

Namespace Buisness

    Public Class SecurityAdmin
        Dim _objMisc As Production.Misc

        Public Sub New()
            Me._objMisc = New Production.Misc()
        End Sub

        Public Function GetGroupSelects() As DataTable
            Dim dt As DataTable
            Dim strSql As String
            Dim sf As New StackFrame(0)

            Try
                strSql = "SELECT Group_ID, Group_Desc " & Environment.NewLine
                strSql &= "FROM lgroups " & Environment.NewLine
                strSql &= "WHERE MasterGroup = 1 " & Environment.NewLine
                strSql &= "ORDER BY Group_Desc"

                dt = Me._objMisc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
            Finally
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Function

        Public Sub DisplayMessage(ByVal methInfo As Reflection.MethodBase, ByVal strMsg As String, Optional ByVal bIsErrMsg As Boolean = True)
            Me._objMisc.DisplayMessage(methInfo, strMsg, bIsErrMsg)
        End Sub

    End Class

End Namespace
