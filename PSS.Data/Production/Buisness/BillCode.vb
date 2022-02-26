Imports eInfoDesigns.dbProvider.MySqlClient
Imports PSS.Data.Production

Namespace Buisness

    Public Class BillCode

        Public Shared Function GetDataView() As DataTable
            '            Dim strSql As String = "SELECT BillCode_ID AS 'Bill Code', BillCode_Desc AS Description, BillRule_Desc AS 'Bill Rule', " & _
            '                                            "BillType_LDesc AS 'Bill Type', Fail_LDesc AS 'Fail Code', Repair_LDesc AS 'Repair Code' " & _
            '                                            "FROM (((lbillcodes INNER JOIN lbilltype ON lbillcodes.BillType_ID = lbilltype.BillType_ID) " & _
            '                                            "LEFT OUTER JOIN lbillrule ON lbillcodes.BillCode_Rule = lbillrule.BillRule_ID)" & _
            '                                            "LEFT OUTER JOIN lfailcodes ON lbillcodes.Fail_ID = lfailcodes.Fail_ID) " & _
            '                                            "LEFT OUTER JOIN lrepaircodes ON lbillcodes.Repair_ID = lrepaircodes.Repair_ID " & _
            '                                            "ORDER BY BillCode_ID, BillCode_Desc;"
            Dim strSql As String = "SELECT BillCode_ID AS 'Bill Code', BillCode_Desc AS Description, lproduct.prod_desc as 'Device Type',  BillRule_Desc AS 'Bill Rule' " & _
                                            ", BillType_LDesc AS 'Bill Type', Fail_LDesc AS 'Fail Code', Repair_LDesc AS 'Repair Code', lproduct.prod_id " & _
                                            ", if (AggBill = 1, 'Yes', 'No') as Aggegrate " & _
                                            "FROM ((((lbillcodes INNER JOIN lbilltype ON lbillcodes.BillType_ID = lbilltype.BillType_ID) " & _
                                            "LEFT OUTER JOIN lbillrule ON lbillcodes.BillCode_Rule = lbillrule.BillRule_ID)" & _
                                            "LEFT OUTER JOIN lfailcodes ON lbillcodes.Fail_ID = lfailcodes.Fail_ID) " & _
                                            "LEFT OUTER JOIN lproduct ON lbillcodes.device_id = lproduct.prod_id) " & _
                                            "LEFT OUTER JOIN lrepaircodes ON lbillcodes.Repair_ID = lrepaircodes.Repair_ID " & _
                                            "ORDER BY BillCode_Desc, BillCode_ID;"
            Return GetDataTable(strSql)
        End Function

        Public Shared Function DeleteBillCode(ByVal BillCode As Integer)
            Dim strSql As String = "DELETE FROM lbillcodes WHERE Billcode_ID = " & BillCode & ";"
            SetData(strSql)
        End Function

        '*******************************************************************************************************************
        Public Shared Function InsertBillCode(ByVal desc As String, ByVal devid As Integer, ByVal rule As Int32, ByVal type As Int32, ByVal fail As Int32, ByVal repair As Int32, ByVal iAggBilling As Integer)
            '//Get the maximum value for ID code
            Dim dID As New PSS.Data.Production.lbillcodes()
            Dim rID As DataRow
            Dim intID As Int32
            Dim strSql As String = ""

            Try
                rID = dID.GetMaxBillCode
                intID = Convert.ToInt32(rID("BC_ID")) + 1
                strSql = "INSERT INTO lbillcodes (BillCode_ID, BillCode_Desc, Device_ID,  BillCode_Rule, BillType_ID, Fail_ID, Repair_ID, AggBill ) " & _
                         "VALUES (" & intID & ",'" & doapps(desc) & "'," & devid & ",'" & rule & "','" & type & "','" & fail & "','" & repair & "', " & iAggBilling & ");"
                SetData(strSql)
            Catch ex As Exception
                Throw ex
            End Try
            Return intID
        End Function

        '*******************************************************************************************************************

        Public Shared Function UpdateBillCode(ByVal id As Int32, ByVal desc As String, ByVal devid As Integer, ByVal rule As Int32, ByVal type As Int32, ByVal fail As Int32, ByVal repair As Int32, ByVal iAggBilling As Integer)
            Dim strSql As String = "UPDATE lbillcodes SET BillCode_Desc = '" & doapps(desc) & "', Device_ID = " & devid & ", BillCode_Rule = '" & rule & "', BillType_ID = '" & _
                                              type & "', Fail_ID = '" & fail & "', Repair_ID = '" & repair & "', AggBill = " & iAggBilling & " WHERE BillCode_ID = '" & id & "';"
            SetData(strSql)
        End Function

        Public Shared Function GetBillCode(ByVal billCode As Integer) As DataTable
            'Dim strSql As String = "SELECT BillCode_ID, BillCode_Desc, BillRule_Desc, BillType_LDesc, Fail_LDesc, Repair_LDesc " & _
            '                                "FROM (((lbillcodes INNER JOIN lbilltype ON lbillcodes.BillType_ID = lbilltype.BillType_ID) " & _
            '                                "LEFT OUTER JOIN lbillrule ON lbillcodes.BillCode_Rule = lbillrule.BillRule_ID)" & _
            '                                "LEFT OUTER JOIN lfailcodes ON lbillcodes.Fail_ID = lfailcodes.Fail_ID) " & _
            '                                "LEFT OUTER JOIN lrepaircodes ON lbillcodes.Repair_ID = lrepaircodes.Repair_ID " & _
            '                                "WHERE BillCode_ID = " & billCode & ";"
            Dim strSql As String = "SELECT BillCode_ID, BillCode_Desc, BillRule_Desc, BillType_LDesc, Fail_LDesc, Repair_LDesc, lproduct.prod_desc, AggBill " & _
                                            "FROM ((((lbillcodes INNER JOIN lbilltype ON lbillcodes.BillType_ID = lbilltype.BillType_ID) " & _
                                            "LEFT OUTER JOIN lbillrule ON lbillcodes.BillCode_Rule = lbillrule.BillRule_ID)" & _
                                            "LEFT OUTER JOIN lfailcodes ON lbillcodes.Fail_ID = lfailcodes.Fail_ID) " & _
                                            "LEFT OUTER JOIN lproduct ON lbillcodes.device_id = lproduct.prod_id) " & _
                                            "LEFT OUTER JOIN lrepaircodes ON lbillcodes.Repair_ID = lrepaircodes.Repair_ID " & _
                                            "WHERE BillCode_ID = " & billCode & ";"


            Return GetDataTable(strSql)
        End Function

        Public Shared Function GetBillRules() As DataTable
            Dim strSql As String = "SELECT BillRule_ID, BillRule_Desc FROM lbillrule WHERE Active = 1 ORDER BY BillRule_Desc;"
            Return GetDataTable(strSql)
        End Function

        Public Shared Function GetBillTypes() As DataTable
            Dim strSql As String = "SELECT BillType_ID, BillType_LDesc FROM lbilltype ORDER BY BillType_LDesc;"
            Return GetDataTable(strSql)
        End Function

        Public Shared Function GetDeviceTypes() As DataTable
            Dim strSql As String = "SELECT Prod_ID, Prod_Desc FROM lproduct ORDER BY Prod_Desc;"
            Return GetDataTable(strSql)
        End Function

        Public Shared Function GetFailCodes() As DataTable
            Dim strSql As String = "SELECT Fail_ID, Fail_LDesc FROM lfailcodes ORDER BY Fail_LDesc;"
            Return GetDataTable(strSql)
        End Function

        Public Shared Function GetRepCodes(Optional ByVal iProd_ID As Integer = 0) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT Repair_ID, Repair_LDesc " & Environment.NewLine
                strSql &= "FROM lrepaircodes " & Environment.NewLine
                strSql &= "WHERE Repair_Inactive = 0 " & Environment.NewLine
                If iProd_ID > 0 Then
                    strSql &= "AND Prod_ID = " & iProd_ID & Environment.NewLine
                End If
                strSql &= "ORDER BY Repair_LDesc;"
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Private Shared Function doapps(ByVal [string] As String) As String
            Return Replace([string], "'", "''").ToString()
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

        Private Shared Sub SetData(ByVal [string] As String)
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                objDataProc.ExecuteNonQuery([string])
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Sub
    End Class

End Namespace