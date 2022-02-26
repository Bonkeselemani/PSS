Option Explicit On 

Namespace Buisness
    Public Class RptData

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
        Public Function GetAPCData(ByVal strStartShipDate As String, _
                                   ByVal strEndShipDate As String, _
                                   ByVal iCustID As Integer, _
                                   ByVal iLocID As Integer, _
                                   ByRef dblTotalPartsCost As Double) As DataTable
            Dim dt, dtModels, dtAPCG As DataTable
            Dim strSql As String = ""
            Dim strExcpBillCodes As String = ""
            Dim R1, R2 As DataRow
            Dim decPartCost As Decimal = 0.0

            Try
                dblTotalPartsCost = 0.0

                strSql = "SELECT DISTINCT tmodel.Model_ID, Model_Desc as Model, count(*) as Qty, 0.00 as 'APC Goal', 0.00 as 'APC Actual' " & Environment.NewLine
                strSql &= "FROM tdevice  " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strSql &= "WHERE Device_ShipWorkDate between '" & strStartShipDate & "' and '" & strEndShipDate & "' " & Environment.NewLine
                strSql &= "AND tdevice.Loc_id = " & iLocID & Environment.NewLine
                If iLocID = 19 Then
                    'DBR an NER unit
                    strSql &= "AND (Ship_ID is null OR Ship_ID <> 9999919 )" & Environment.NewLine
                Else
                    strSql &= "AND Pallet_ShipType NOT IN (1,2,8,9, 10) " & Environment.NewLine
                End If
                strSql &= "GROUP BY tdevice.Model_ID " & Environment.NewLine
                strSql &= "ORDER BY Model_Desc "
                dtModels = Me._objDataProc.GetDataTable(strSql)

                If dtModels.Rows.Count > 0 Then
                    strSql = "select * from tavgpartcostgoal where cust_id =  " & iCustID & Environment.NewLine
                    dtAPCG = Me._objDataProc.GetDataTable(strSql)

                    For Each R1 In dtModels.Rows
                        strSql = "SELECT * " & Environment.NewLine
                        strSql &= "FROM tavgpartcostgoalexcpt " & Environment.NewLine
                        strSql &= "WHERE cust_id = " & iCustID & Environment.NewLine
                        strSql &= "AND model_id = " & R1("Model_ID") & Environment.NewLine
                        dt = Me._objDataProc.GetDataTable(strSql)

                        For Each R2 In dt.Rows
                            If strExcpBillCodes.Trim.Length > 0 Then strExcpBillCodes &= ", "
                            strExcpBillCodes &= R2("BillCode_ID")
                        Next R2

                        strSql = "SELECT if(SUM(tdevicebill.DBill_AvgCost) is null, 0.00, SUM(tdevicebill.DBill_AvgCost)) as PartsCost " & Environment.NewLine
                        strSql &= "FROM tdevice  " & Environment.NewLine
                        strSql &= "INNER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID " & Environment.NewLine
                        strSql &= "INNER JOIN lbillcodes ON tdevicebill.billcode_ID = lbillcodes.Billcode_ID " & Environment.NewLine
                        strSql &= "LEFT OUTER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                        strSql &= "WHERE Device_ShipWorkDate between '" & strStartShipDate & "' and '" & strEndShipDate & "' " & Environment.NewLine
                        strSql &= "AND tdevice.Loc_id = " & iLocID & Environment.NewLine
                        strSql &= "AND tdevice.Model_ID = " & R1("Model_ID") & Environment.NewLine
                        strSql &= "AND lbillcodes.BillType_ID = 2 " & Environment.NewLine
                        If strExcpBillCodes.Trim.Length > 0 Then strSql &= "AND tdevicebill.Billcode_ID NOT IN ( " & strExcpBillCodes & ")" & Environment.NewLine
                        If iLocID = 19 Then
                            'DBR an NER unit
                            strSql &= "AND (Ship_ID is null OR Ship_ID <> 9999919 )" & Environment.NewLine
                        Else
                            strSql &= "AND Pallet_ShipType NOT IN (1,2,8,9,10) " & Environment.NewLine
                        End If
                        decPartCost = Me._objDataProc.GetDoubleValue(strSql)
                        dblTotalPartsCost += decPartCost

                        R1.BeginEdit()
                        If dtAPCG.Select("Model_ID = " & R1("Model_ID")).Length > 0 Then R1("APC Goal") = dtAPCG.Select("Model_ID = " & R1("Model_ID"))(0)("APCG_Amt")
                        If R1("Qty") > 0 Then R1("APC Actual") = decPartCost / R1("Qty")
                        R1.EndEdit()
                        R1.AcceptChanges()

                        decPartCost = 0.0
                        strExcpBillCodes = ""
                        Generic.DisposeDT(dt)
                    Next R1

                    dtModels.Columns.Remove("Model_ID")
                    dtModels.AcceptChanges()
                End If

                Return dtModels
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                R2 = Nothing
                Generic.DisposeDT(dt)
                Generic.DisposeDT(dtModels)
                Generic.DisposeDT(dtAPCG)
            End Try
        End Function

        '******************************************************************

    End Class
End Namespace