Option Explicit On 

Namespace Buisness
    Public Class RURPriceException

        Private _objDataProc As DBQuery.DataProc

        '******************************************************************
        Public Sub New()
            Try
                Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '******************************************************************
        Public Function GetCustomers(ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String
            Dim dt As DataTable
            Try
                strSql = "SELECT Cust_ID, Cust_Name1 " & Environment.NewLine
                strSql &= "FROM tcustomer  " & Environment.NewLine
                strSql &= "WHERE Cust_Name2 is null AND cust_id not in ( 198 ) " & Environment.NewLine
                strSql &= "AND Cust_Inactive = 0 " & Environment.NewLine
                strSql &= "ORDER BY Cust_Name1  " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow = True Then
                    dt.LoadDataRow(New Object() {0, "--Select--"}, False)
                End If
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetModels(ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String
            Dim dt As DataTable
            Try
                strSql = "SELECT Model_ID, Model_Desc  FROM tmodel  " & Environment.NewLine
                strSql &= "ORDER BY Model_Desc  " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow = True Then
                    dt.LoadDataRow(New Object() {0, "--Select--"}, False)
                End If
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetRURRegPriceByCust(ByVal iCustID As Integer) As DataTable
            Dim strSql As String
            Try
                strSql = "SELECT Prod_Desc as 'Product', MarkUp_RUR as 'RUR', MarkUp_NER as 'NER', Markup_NTF as 'NTF', Markup_RTM as 'RTM' " & Environment.NewLine
                strSql &= "FROM tcustmarkup " & Environment.NewLine
                strSql &= "INNER JOIN tcustomer ON tcustmarkup.Cust_ID = tcustomer.Cust_ID " & Environment.NewLine
                strSql &= "INNER JOIN lproduct ON tcustmarkup.Prod_ID = lproduct.Prod_ID " & Environment.NewLine
                strSql &= "WHERE Cust_Name2 is null AND tcustmarkup.cust_id = " & iCustID & " " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetRURExceptionPriceByCust(ByVal iCustID As Integer) As DataTable
            Dim strSql As String
            Try
                strSql = "SELECT RP_ID, trurpriceexception.Model_ID, Model_Desc as 'Model', RP_RUR as RUR, RP_NER as 'NER', RP_NTF as 'NTF', RP_RTM as 'RTM' " & Environment.NewLine
                strSql &= "FROM trurpriceexception  " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON trurpriceexception.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "WHERE Cust_ID = " & iCustID & " " & Environment.NewLine
                'strSql &= "AND trurpriceexception.Model_ID = 1128 " & Environment.NewLine
                strSql &= "AND RP_Inactive = 0 " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function AddUpdateExceptionRUR(ByVal iCustID As Integer, ByVal iModelID As Integer, _
                                              ByVal decRUR As Decimal, ByVal decNER As Decimal, _
                                              ByVal decNTF As Decimal, ByVal decRTM As Decimal) As Integer
            Dim strSql As String
            Dim iRPID As Integer = 0

            Try
                strSql = "SELECT RP_ID " & Environment.NewLine
                strSql &= "FROM trurpriceexception  " & Environment.NewLine
                strSql &= "WHERE Cust_ID = " & iCustID & " " & Environment.NewLine
                strSql &= "AND Model_ID = " & iModelID & Environment.NewLine
                iRPID = Me._objDataProc.GetIntValue(strSql)
                If iRPID > 0 Then
                    'UPDATE
                    strSql = "UPDATE trurpriceexception  " & Environment.NewLine
                    strSql &= "SET RP_RUR = " & decRUR & Environment.NewLine
                    strSql &= ", RP_NER = " & decNER & Environment.NewLine
                    strSql &= ", RP_NTF = " & decNTF & Environment.NewLine
                    strSql &= ", RP_RTM = " & decRTM & Environment.NewLine
                    strSql &= "WHERE RP_ID = " & iRPID & Environment.NewLine
                Else
                    'INSERT
                    strSql = "INSERT INTO trurpriceexception ( " & Environment.NewLine
                    strSql &= "RP_RUR, RP_NER " & Environment.NewLine
                    strSql &= ", RP_NTF, RP_RTM  " & Environment.NewLine
                    strSql &= ", Cust_ID, Model_ID  " & Environment.NewLine
                    strSql &= ") VALUES ( " & Environment.NewLine
                    strSql &= decRUR & ", " & decNER & Environment.NewLine
                    strSql &= ", " & decNTF & ", " & decRTM & Environment.NewLine
                    strSql &= ", " & iCustID & ", " & iModelID & Environment.NewLine
                    strSql &= ") " & Environment.NewLine
                End If
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************

    End Class
End Namespace