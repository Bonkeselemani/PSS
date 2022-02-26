Imports System
Imports System.Data
Imports eInfoDesigns.dbProvider.MySqlClient
Imports PSS.Data

Namespace Production

    Public Class tcustomer
        Inherits TableBase

        Public Shared Function GetRowByPK(ByVal pkVAL As Int32) As DataRow
            Dim strSql As String = "SELECT * FROM tcustomer WHERE Cust_ID = " & pkVAL
            Dim objDataProc As DBQuery.DataProc
            Dim dt As DataTable

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                dt = objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then Return dt.Rows(0) Else Return Nothing
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        Public Shared Function GetIDByParentCompany(ByVal companyid As String) As DataTable
            Dim strSql As String = "SELECT Cust_ID FROM tcustomer WHERE PCo_ID = " & companyid & ";"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function


        Public Shared Function GetCustomersOrdered() As DataTable
            Dim strSql As String = "SELECT DISTINCT * FROM tcustomer WHERE Cust_Name2 is null ORDER BY cust_Name1"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function


        Public Shared Function GetPalletCustomersOrdered() As DataTable
            Dim strSql As String = "SELECT * FROM tcustomer WHERE Cust_PalletShip = 1 ORDER BY cust_Name1"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function


        'Public Shared Function GetFirmOnlyList() As DataSet
        '    Dim strSql As String = "SELECT DISTINCT * FROM tcustomer WHERE Cust_Name2 is null ORDER BY cust_Name1"
        '    Dim objDataProc As DBQuery.DataProc
        '    Dim ds As New DataSet()
        '    Dim dt As DataTable

        '    Try
        '        objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
        '        dt = objDataProc.GetDataTable(strSql)
        '        dt.TableName = "tcustomer"
        '        ds.Tables.Add(dt)
        '        Return ds
        '    Catch ex As Exception
        '        Throw ex
        '    Finally
        '        objDataProc = Nothing
        '    End Try
        'End Function

        Public Shared Function GetDataOrdered() As DataSet
            Dim strSql As String = "SELECT * FROM tcustomer WHERE Cust_Name2 is null ORDER BY cust_Name1"
            Dim objDataProc As DBQuery.DataProc
            Dim ds As New DataSet()
            Dim dt As DataTable

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                dt = objDataProc.GetDataTable(strSql)
                dt.TableName = "tcustomer"
                ds.Tables.Add(dt)
                Return ds
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function RemoveDataRowByCustID(ByVal CustID As String) As Boolean
            Dim strSQL As String = "DELETE FROM tcustomer WHERE Cust_ID = " & CustID & ";"
            Dim objDataProc As DBQuery.DataProc

            Try
                RemoveDataRowByCustID = False
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                objDataProc.ExecuteNonQuery(strSQL)

                RemoveDataRowByCustID = True
                Return True
            Catch ex As Exception
                RemoveDataRowByCustID = False
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function GetRowByName(ByVal strVAL As String) As DataRow
            Dim strSql As String = "SELECT * FROM tcustomer WHERE Cust_Name1 = '" & Trim(strVAL) & "'"
            Dim objDataProc As DBQuery.DataProc
            Dim dt As DataTable

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                dt = objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then Return dt.Rows(0) Else Return Nothing
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

    End Class
End Namespace