Option Explicit On 

Namespace Buisness
    Public Class FailCodesRepairCodes

#Region "Query"

        '**************************************************************
        Public Shared Function ActiveRepCodeQuery(ByVal iManufID As Integer, _
                                                 ByVal iProdID As Integer, _
                                                 ByVal iModelID As Integer, _
                                                 Optional ByVal strExcludeRepIDs As String = "") As String
            Dim strSql As String = ""

            Try
                strSql = "SELECT Repair_ID as ID, concat(Repair_SDesc, '-', Repair_LDesc) as 'Desc' " & Environment.NewLine
                strSql &= "FROM lrepaircodes  " & Environment.NewLine
                strSql &= "WHERE Repair_Inactive = 0 " & Environment.NewLine
                strSql &= "AND Prod_ID = " & iProdID & Environment.NewLine
                strSql &= "AND Manuf_ID = " & iManufID & Environment.NewLine
                strSql &= "AND Repair_Inactive = 0 " & Environment.NewLine
                If iModelID > 0 Then strSql &= "AND Model_ID = " & iModelID & Environment.NewLine
                If strExcludeRepIDs.Trim.Length > 0 Then strSql &= "AND Repair_ID not IN (" & strExcludeRepIDs & ")" & Environment.NewLine
                strSql &= "ORDER BY 'Desc'"

                Return strSql
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Shared Function ActiveFailCodeQuery(ByVal iManufID As Integer, _
                                                   ByVal iProdID As Integer, _
                                                   ByVal iModelID As Integer) As String
            Dim strSql As String = ""
            Try
                strSql = "SELECT Fail_ID as ID, concat(Fail_SDesc, '-', Fail_LDesc) as 'Desc' " & Environment.NewLine
                strSql &= "FROM lfailcodes  " & Environment.NewLine
                strSql &= "WHERE Fail_Inactive = 0 " & Environment.NewLine
                strSql &= "AND Prod_ID = " & iProdID & Environment.NewLine
                strSql &= "AND Manuf_ID = " & iManufID & Environment.NewLine
                strSql &= "AND Fail_Inactive = 0 " & Environment.NewLine
                If iModelID > 0 Then strSql &= "AND Model_ID = " & iModelID & Environment.NewLine
                strSql &= "ORDER BY 'Desc'"
                Return strSql
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Shared Function ActiveCosmeticFailCodeQuery(ByVal iManufID As Integer, _
                                                           ByVal iProdID As Integer, _
                                                           ByVal iModelID As Integer) As String
            Dim strSql As String = ""
            Try
                strSql = "SELECT Fail_ID as ID, concat(Fail_SDesc, '-', Fail_LDesc) as 'Desc' " & Environment.NewLine
                strSql &= "FROM lfailcodes  " & Environment.NewLine
                strSql &= "WHERE Fail_Inactive = 0 " & Environment.NewLine
                strSql &= "AND Prod_ID = " & iProdID & Environment.NewLine
                strSql &= "AND Manuf_ID = " & iManufID & Environment.NewLine
                strSql &= "AND Fail_Inactive = 0 " & Environment.NewLine
                If iModelID > 0 Then strSql &= "AND Model_ID = " & iModelID & Environment.NewLine
                strSql &= "AND Cosmetic = 1" & Environment.NewLine
                strSql &= "ORDER BY 'Desc'"
                Return strSql
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Shared Function ActiveFunctionalFailCodeQuery(ByVal iManufID As Integer, _
                                                             ByVal iProdID As Integer, _
                                                             ByVal iModelID As Integer) As String
            Dim strSql As String = ""
            Try
                strSql = "SELECT Fail_ID as ID, concat(Fail_SDesc, '-', Fail_LDesc) as 'Desc' " & Environment.NewLine
                strSql &= "FROM lfailcodes  " & Environment.NewLine
                strSql &= "WHERE Fail_Inactive = 0 " & Environment.NewLine
                strSql &= "AND Prod_ID = " & iProdID & Environment.NewLine
                strSql &= "AND Manuf_ID = " & iManufID & Environment.NewLine
                strSql &= "AND Fail_Inactive = 0 " & Environment.NewLine
                If iModelID > 0 Then strSql &= "AND Model_ID = " & iModelID & Environment.NewLine
                strSql &= "AND Functional = 1" & Environment.NewLine
                strSql &= "ORDER BY 'Desc'"
                Return strSql
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Shared Function ActiveBERFailCodeQuery(ByVal iManufID As Integer, _
                                                      ByVal iProdID As Integer, _
                                                      ByVal iModelID As Integer) As String
            Dim strSql As String = ""
            Try
                strSql = "SELECT Fail_ID as ID, concat(Fail_SDesc, '-', Fail_LDesc) as 'Desc' " & Environment.NewLine
                strSql &= "FROM lfailcodes  " & Environment.NewLine
                strSql &= "WHERE Fail_Inactive = 0 " & Environment.NewLine
                strSql &= "AND Prod_ID = " & iProdID & Environment.NewLine
                strSql &= "AND Manuf_ID = " & iManufID & Environment.NewLine
                strSql &= "AND Fail_Inactive = 0 " & Environment.NewLine
                If iModelID > 0 Then strSql &= "AND Model_ID = " & iModelID & Environment.NewLine
                strSql &= "AND BER = 1" & Environment.NewLine
                strSql &= "ORDER BY 'Desc'"
                Return strSql
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Shared Function ActiveRFFailCodeQuery(ByVal iManufID As Integer, _
                                                      ByVal iProdID As Integer, _
                                                      ByVal iModelID As Integer) As String
            Dim strSql As String = ""
            Try
                strSql = "SELECT Fail_ID as ID, concat(Fail_SDesc, '-', Fail_LDesc) as 'Desc' " & Environment.NewLine
                strSql &= "FROM lfailcodes  " & Environment.NewLine
                strSql &= "WHERE Fail_Inactive = 0 " & Environment.NewLine
                strSql &= "AND Prod_ID = " & iProdID & Environment.NewLine
                strSql &= "AND Manuf_ID = " & iManufID & Environment.NewLine
                strSql &= "AND Fail_Inactive = 0 " & Environment.NewLine
                If iModelID > 0 Then strSql &= "AND Model_ID = " & iModelID & Environment.NewLine
                strSql &= "AND RF = 1" & Environment.NewLine
                strSql &= "ORDER BY 'Desc'"
                Return strSql
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Shared Function ActiveRFAndFuncFailCodeQuery(ByVal iManufID As Integer, _
                                                      ByVal iProdID As Integer, _
                                                      ByVal iModelID As Integer) As String
            Dim strSql As String = ""
            Try
                strSql = "SELECT Fail_ID as ID, concat(Fail_SDesc, '-', Fail_LDesc) as 'Desc' " & Environment.NewLine
                strSql &= "FROM lfailcodes  " & Environment.NewLine
                strSql &= "WHERE Fail_Inactive = 0 " & Environment.NewLine
                strSql &= "AND Prod_ID = " & iProdID & Environment.NewLine
                strSql &= "AND Manuf_ID = " & iManufID & Environment.NewLine
                strSql &= "AND Fail_Inactive = 0 " & Environment.NewLine
                If iModelID > 0 Then strSql &= "AND Model_ID = " & iModelID & Environment.NewLine
                strSql &= "AND ( RF = 1 or Functional = 1 ) " & Environment.NewLine
                strSql &= "UNION " & Environment.NewLine
                strSql &= "SELECT Fail_ID as ID, concat(Fail_SDesc, '-', Fail_LDesc) as 'Desc' " & Environment.NewLine
                strSql &= "FROM lfailcodes  " & Environment.NewLine
                strSql &= "WHERE Fail_ID = 311 "
                strSql &= "ORDER BY 'Desc'"
                Return strSql
            Catch ex As Exception
                Throw ex
            End Try
        End Function

#End Region

        '**************************************************************
        Public Shared Function GetDataTable(ByVal strSql As String, _
                                            Optional ByVal booAddSelectRow As Boolean = False) As DataTable
            Dim objDataProc As DBQuery.DataProc
            Dim dt As DataTable

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                dt = objDataProc.GetDataTable(strSql)

                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '**************************************************************
        Public Shared Function SaveReflowPart(ByVal iDeviceID As Integer, _
                                              ByVal iBillcodeID As Integer, _
                                              ByVal iFailID As Integer, _
                                              ByVal iRepID As Integer, _
                                              ByVal iUserID As Integer) As Integer
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim i As Integer = 0

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT * " & Environment.NewLine
                strSql &= "FROM treflowpart  " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "AND Billcode_ID = " & iBillcodeID & Environment.NewLine

                dt = objDataProc.GetDataTable(strSql)

                strSql = ""
                If dt.Rows.Count > 0 Then
                    If IsDBNull(dt.Rows(0)("Fail_ID")) Or IsDBNull(dt.Rows(0)("Repair_ID")) Then
                        strSql = "UPDATE treflowpart" & Environment.NewLine
                        strSql &= "SET Fail_ID = " & iFailID & Environment.NewLine
                        strSql &= ", Repair_ID = " & iRepID & Environment.NewLine
                        strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                        strSql &= "AND Billcode_ID = " & iBillcodeID & Environment.NewLine
                    ElseIf dt.Rows(0)("Fail_ID") = 0 Or dt.Rows(0)("Repair_ID") = 0 Or dt.Rows(0)("Fail_ID") <> iFailID Or dt.Rows(0)("Repair_ID") <> iRepID Then
                        strSql = "UPDATE treflowpart" & Environment.NewLine
                        strSql &= "SET Fail_ID = " & iFailID & Environment.NewLine
                        strSql &= ", Repair_ID = " & iRepID & Environment.NewLine
                        strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                        strSql &= "AND Billcode_ID = " & iBillcodeID & Environment.NewLine
                    End If
                Else
                    strSql = "INSERT INTO treflowpart ( " & Environment.NewLine
                    strSql &= "Device_ID, Billcode_ID, Fail_ID, Repair_ID, User_ID " & Environment.NewLine
                    strSql &= ") VALUES ( " & Environment.NewLine
                    strSql &= iDeviceID & ", " & iBillcodeID & ", " & iFailID & ", " & iRepID & ", " & iUserID & Environment.NewLine
                    strSql &= ") " & Environment.NewLine
                End If

                If strSql.Trim.Length > 0 Then i = objDataProc.ExecuteNonQuery(strSql)

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '**************************************************************
        Public Shared Function DeleteReflowPart(ByVal iDeviceID As Integer, _
                                      ByVal iBillcodeID As Integer) As Integer
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = ""

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "DELETE " & Environment.NewLine
                strSql &= "FROM treflowpart  " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "AND Billcode_ID = " & iBillcodeID & Environment.NewLine

                Return objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Shared Function GetReflowPartCount(ByVal iDeviceID As Integer) As Integer
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = ""

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT count(*) as cnt " & Environment.NewLine
                strSql &= "FROM treflowpart  " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine

                Return objDataProc.GetIntValue(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Shared Function GetExistingReflowParts(ByVal iDeviceID As Integer) As DataTable
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = ""

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT * " & Environment.NewLine
                strSql &= "FROM treflowpart  " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine

                Return objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Shared Sub GetRepFailMap(ByRef iRepID As Integer, _
                                        ByRef iFailID As Integer, _
                                        ByVal iBillcode As Integer, _
                                        ByVal iModelID As Integer, _
                                        ByVal iCustID As Integer)
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT if(Repair_ID is null, 0, Repair_ID) as Repair_ID, if(Fail_ID is null, 0, Fail_ID) as Fail_ID " & Environment.NewLine
                strSql &= "FROM tbillmap  " & Environment.NewLine
                strSql &= "WHERE Cust_ID = " & iCustID & Environment.NewLine
                strSql &= "AND Model_ID = " & iModelID & Environment.NewLine
                strSql &= "AND Billcode_ID = " & iBillcode & Environment.NewLine

                dt = objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    iRepID = dt.Rows(0)("Repair_ID") : iFailID = dt.Rows(0)("Fail_ID")
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '**************************************************************
        Public Shared Sub GetReflowFailRepDesc(ByRef strFailDesc As String, _
                                               ByRef strRepDesc As String, _
                                               ByVal iBillcodeID As Integer, _
                                               ByVal iDeviceID As Integer)
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT Concat('Fail Code:', Fail_LDesc) as Fail_LDesc, Concat('Repair Code:', Repair_LDesc) as Repair_LDesc " & Environment.NewLine
                strSql &= "FROM treflowpart  " & Environment.NewLine
                strSql &= "INNER JOIN lfailcodes ON treflowpart.Fail_ID = lfailcodes.Fail_ID " & Environment.NewLine
                strSql &= "INNER JOIN lrepaircodes ON treflowpart.Repair_ID = lrepaircodes.Repair_ID " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "AND Billcode_ID = " & iBillcodeID & Environment.NewLine

                dt = objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    strFailDesc = dt.Rows(0)("Fail_LDesc") : strRepDesc = dt.Rows(0)("Repair_LDesc")
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '**************************************************************


    End Class
End Namespace