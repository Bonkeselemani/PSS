Namespace Buisness
    Public Class ScrapParts
        Private objMisc As Production.Misc

        Public Function GetScrapCount(ByVal iDevice_ID As Integer, _
                                    ByVal iModel_ID As Integer, _
                                    ByVal iBillcode_id As Integer) As Integer
            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim i As Integer = 0

            Try
                strsql = "Select Sum(tscrap_qty) as 'ScrapCount' " & Environment.NewLine
                strsql &= "from tscrap " & Environment.NewLine
                strsql &= "where " & Environment.NewLine
                strsql &= "tscrap.device_id = " & iDevice_ID & " and " & Environment.NewLine
                strsql &= "tscrap.model_id = " & iModel_ID & " and " & Environment.NewLine
                strsql &= "tscrap.billcode_id = " & iBillcode_id & ";"

                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    R1 = dt1.Rows(0)
                    If Not IsDBNull(R1("ScrapCount")) Then
                        i = R1("ScrapCount")
                    End If
                End If

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function



        Public Function ScrapParts(ByVal iDevice_ID As Integer, _
                            ByVal iModelID As Integer, _
                            ByVal iBillcode_ID As Integer, _
                            ByVal iProdID As Integer, _
                            ByVal iEmpNo As Integer, _
                            ByVal strWorkDate As String, _
                            ByVal iCount As Integer, _
                            ByVal iUserID As Integer) As Integer

            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim iPSMapID As Integer = 0
            Dim strPSPriceNum As String = ""
            Dim i As Integer = 0

            Try
                If iCount = -1 Then
                    i = GetScrapCount(iDevice_ID, iModelID, iBillcode_ID)
                    If i = 0 Then
                        Return i
                    End If
                End If
                '*****************************************
                'Get Part Data
                strsql = "Select psmap_id, PSPrice_Number " & Environment.NewLine
                strsql &= "from tpsmap " & Environment.NewLine
                strsql &= "inner join lpsprice on tpsmap.PSPrice_ID = lpsprice.PSPrice_ID " & Environment.NewLine
                strsql &= "where model_id = " & iModelID & " and " & Environment.NewLine
                strsql &= "billcode_id = " & iBillcode_ID & ";"

                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    R1 = dt1.Rows(0)
                    If Not IsDBNull(R1("psmap_id")) Then
                        iPSMapID = R1("psmap_id")
                    End If
                    If Not IsDBNull(R1("PSPrice_Number")) Then
                        strPSPriceNum = Trim(R1("PSPrice_Number"))
                    End If
                Else
                    Throw New Exception("This part was not mapped by Materials Department.")
                End If
                '*****************************************
                'Insert into tscrap table
                strsql = "insert into tscrap(" & Environment.NewLine

                strsql &= "tscrap_qty, " & Environment.NewLine
                strsql &= "psmap_id, " & Environment.NewLine
                strsql &= "billcode_id, " & Environment.NewLine
                strsql &= "psprice_number, " & Environment.NewLine
                strsql &= "device_id, " & Environment.NewLine
                strsql &= "workdate, " & Environment.NewLine
                strsql &= "user_id, " & Environment.NewLine
                strsql &= "empnum, " & Environment.NewLine
                strsql &= "computerName, " & Environment.NewLine
                strsql &= "prod_id, " & Environment.NewLine
                strsql &= "model_id, " & Environment.NewLine
                strsql &= "entryDate) " & Environment.NewLine

                strsql &= "values (" & Environment.NewLine

                strsql &= iCount & ", " & Environment.NewLine
                strsql &= iPSMapID & ", " & Environment.NewLine
                strsql &= iBillcode_ID & ", " & Environment.NewLine
                strsql &= "'" & strPSPriceNum & "', " & Environment.NewLine
                strsql &= iDevice_ID & ", " & Environment.NewLine
                strsql &= "'" & strWorkDate & "', " & Environment.NewLine
                strsql &= iUserID & ", " & Environment.NewLine
                strsql &= iEmpNo & ", " & Environment.NewLine
                strsql &= "'" & System.Net.Dns.GetHostName & "', " & Environment.NewLine
                strsql &= iProdID & ", " & Environment.NewLine
                strsql &= iModelID & ", " & Environment.NewLine
                strsql &= "'" & Format(Now(), "yyyy-MM-dd HH:mm:ss") & "');"
                objMisc._SQL = strsql
                i = objMisc.ExecuteNonQuery
                '*****************************************

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function









        Public Sub New()
            objMisc = New Production.Misc()
        End Sub

        Protected Overrides Sub Finalize()
            objMisc = Nothing
            MyBase.Finalize()
        End Sub
    End Class
End Namespace


