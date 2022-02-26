Namespace Buisness
    Public Class MessDemandData
        Private _objDataProc As DBQuery.DataProc

        Public Sub New()
            Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
        End Sub

        Public Function GetDemandData() As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT B.model_desc AS 'Model', C.freq_number AS 'Frequency', A.DailyDemand AS 'Daily Demand', A.Tier, IFNULL(A.AMModelDesc, '') AS 'AM Model Desc', IFNULL(A.Type, '') AS Type, A.ModelID, A.FreqID " & Environment.NewLine
                strSQL &= "FROM tMsgGoals A " & Environment.NewLine
                strSQL &= "INNER JOIN tmodel B ON B.model_id = A.ModelID " & Environment.NewLine
                strSQL &= "INNER JOIN lfrequency C ON C.freq_id = A.FreqID " & Environment.NewLine
                strSQL &= "ORDER BY B.model_desc, C.freq_number"

                Return Me._objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Sub UpdateData(ByVal dtDemandData As DataTable)
            Dim dr As DataRow
            Dim strSQL As String

            Try
                If Not IsNothing(dtDemandData) Then
                    For Each dr In dtDemandData.Rows
                        strSQL = "UPDATE tMsgGoals " & Environment.NewLine
                        strSQL &= "SET Tier = " & dr("Tier").ToString & ", DailyDemand = " & dr("Daily Demand").ToString & ", AMModelDesc = '" & dr("AM Model Desc").Trim & "', Type = '" & dr("Type") & "' " & Environment.NewLine
                        strSQL &= "WHERE ModelID = " & dr("ModelID") & " " & Environment.NewLine
                        strSQL &= "AND FreqID = " & dr("FreqID") & Environment.NewLine

                        Me._objDataProc.ExecuteNonQuery(strSQL)
                    Next dr
                End If
            Catch ex As Exception
                Throw ex
            Finally
                dr = Nothing
            End Try
        End Sub

        Public Function GetModelCount() As Integer
            Dim iCount As Integer = 0
            Dim strSQL As String
            Dim dt As DataTable

            Try
                strSQL = "SELECT DISTINCT ModelID " & Environment.NewLine
                strSQL &= "FROM tMsgGoals"

                dt = Me._objDataProc.GetDataTable(strSQL)

                If Not IsNothing(dt) Then iCount = dt.Rows.Count

                Return iCount
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Function
    End Class
End Namespace
