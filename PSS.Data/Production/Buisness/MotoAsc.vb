Imports eInfoDesigns.dbProvider.MySqlClient
Imports PSS.Data.Production

Namespace Buisness

    Public Class MotoAsc

        Public Shared Function GetInitialData(ByVal startDate As Date, ByVal endDate As Date) As DataTable
            Dim strSql As String = "SELECT Device_ID, Device_SN, Device_DateRec, Device_DateShip, Loc_ID, Model_ID " & _
                                             "FROM tdevice WHERE tdevice.Device_ManufWrty <> 0 " & _
                                             "AND (tdevice.Device_DateShip >='" & MyDate(startDate) & "') " & _
                                             "AND (tdevice.Device_DateShip <= '" & MyDate(endDate) & "');"
            Return GetDataTable(strSql)
        End Function

        Public Shared Function GetCompanyData(ByVal location As Integer) As String
            Dim strSql As String = "SELECT PCo_MotoCode FROM (lparentco INNER JOIN tcustomer " & _
                                             "ON lparentco.PCo_Id = tcustomer.PCo_ID) INNER JOIN tlocation ON " & _
                                             "tcustomer.Cust_ID = tlocation.Cust_ID WHERE " & _
                                             "tlocation.Loc_ID = " & location & ";"
            Return GetDataTable(strSql).Rows(0)(0)
        End Function

        Public Shared Function GetRepCodes(ByVal device As Integer) As DataTable
            Dim strSql As String = "SELECT DISTINCT(Repair_SDesc) FROM lrepaircodes " & _
                                             "INNER JOIN tdevicebill ON lrepaircodes.Repair_ID = " & _
                                             "tdevicebill.Repair_ID WHERE Device_ID = " & device & ";"
            Return GetDataTable(strSql)
        End Function

        Public Shared Function GetFailCodes(ByVal device As Integer) As DataTable
            Dim strSql As String = "SELECT DISTINCT(Fail_SDesc) FROM lfailcodes " & _
                                             "INNER JOIN tdevicebill ON lfailcodes.Fail_ID = " & _
                                             "tdevicebill.Fail_ID WHERE Device_ID = " & device & ";"
            Return GetDataTable(strSql)
        End Function

        Public Shared Function GetPartData(ByVal device As Integer, ByVal model As Integer) As DataTable
            Dim strSql As String = "SELECT DISTINCT(PSPrice_Number) FROM (lpsprice INNER JOIN tpsmap ON lpsprice.PSPrice_ID = " & _
                                             "tpsmap.PSPrice_ID) INNER JOIN tdevicebill ON tpsmap.BillCode_ID = " & _
                                             "tpsmap.BillCode_ID WHERE tdevicebill.Device_Id = " & device & " AND " & _
                                             "tpsmap.Model_ID = " & model & " AND tdevicebill.billcode_id = tpsmap.billcode_id " & _
                                             "AND PSPrice_AvgCost IS NOT NULL AND PSPrice_StndCost IS NOT NULL;"
            Return GetDataTable(strSql)
        End Function

        Public Shared Function GetSum(ByVal device As Integer) As Double
            Dim strSql As String = "SELECT SUM(ASCBill_Price) FROM tascbill WHERE Device_ID = " & device & ";"

            Dim retVal As Object = GetDataTable(strSql).Rows(0)(0)
            If IsDBNull(retVal) = False Then
                Return Convert.ToDouble(retVal)
            Else
                Return 0.0
            End If

        End Function

        Private Shared Function MyDate(ByVal [date] As Date) As String
            Return [date].Year & "-" & [date].Month & "-" & [date].Day
        End Function

        Private Shared Function GetDataTable(ByVal [string] As String) As DataTable
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable([string])
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function
    End Class

End Namespace
