
Option Explicit On 

Imports system.IO
Imports System.Windows.Forms

Namespace Buisness
    Public Class AvgPartsCost

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
        Public Function GetAllDetailAPCG() As DataTable
            Dim strSql As String
            Try
                strSql = "SELECT Cust_Name1 as 'Customer', Model_Desc as 'Model', tavgpartcostgoal.APCG_Amt as 'Avg Parts Cost', tavgpartcostgoal.Cust_ID, tavgpartcostgoal.Model_ID " & Environment.NewLine
                strSql &= " FROM tavgpartcostgoal " & Environment.NewLine
                strSql &= "INNER JOIN tcustomer ON tavgpartcostgoal.Cust_ID = tcustomer.Cust_ID " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tavgpartcostgoal.Model_ID = tmodel.Model_ID " & Environment.NewLine
                'strSql &= "WHERE Cust_ID = " & iCustID & Environment.NewLine
                'strSql &= "AND Model_ID = " & iModelID
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function UpdateAvgPartCostGoal(ByVal iCustID As Integer, _
                                              ByVal iModelID As Integer, _
                                              ByVal decAvgPartCostAmt As Decimal) As Integer
            Dim strSql As String
            Dim dt As DataTable
            Try
                strSql = "SELECT * FROM tavgpartcostgoal WHERE Cust_ID = " & iCustID & " AND Model_ID = " & iModelID
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    strSql = "UPDATE tavgpartcostgoal " & Environment.NewLine
                    strSql &= "SET APCG_Amt = " & decAvgPartCostAmt & Environment.NewLine
                    strSql &= "WHERE APCG_ID = " & dt.Rows(0)("APCG_ID")
                    Return Me._objDataProc.ExecuteNonQuery(strSql)
                Else
                    strSql = "INSERT INTO tavgpartcostgoal " & Environment.NewLine
                    strSql &= "( Cust_ID, Model_ID, APCG_Amt ) " & Environment.NewLine
                    strSql &= " VALUES " & Environment.NewLine
                    strSql &= "( " & iCustID & Environment.NewLine
                    strSql &= ", " & iModelID & Environment.NewLine
                    strSql &= ", " & decAvgPartCostAmt & Environment.NewLine
                    strSql &= " ) " & Environment.NewLine
                    Return Me._objDataProc.ExecuteNonQuery(strSql)
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetAPCGAmt(ByVal iCustID As Integer, _
                                            ByVal iModelID As Integer) As Decimal
            Dim strSql As String
            Try
                strSql = "SELECT if(APCG_Amt is null, 0.00, APCG_Amt) as 'APCG' FROM tavgpartcostgoal WHERE Cust_ID = " & iCustID & " AND Model_ID = " & iModelID
                Return Me._objDataProc.GetDoubleValue(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetUnitPartCost(ByVal iCustID As Integer, _
                                        ByVal iModelID As Integer, _
                                        ByVal iDeviceID As Integer) As Decimal
            Dim strSql As String
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim strExceptionBillcodeIDs As String = ""

            Try
                strSql = "SELECT Billcode_ID " & Environment.NewLine
                strSql &= "FROM tavgpartcostgoalexcpt " & Environment.NewLine
                strSql &= "WHERE Model_ID = " & iModelID & Environment.NewLine
                strSql &= "AND Cust_ID = " & iCustID & Environment.NewLine
                strSql &= "AND Active  = 1"
                dt = Me._objDataProc.GetDataTable(strSql)
                For Each R1 In dt.Rows
                    If strExceptionBillcodeIDs.Trim.Length > 0 Then strExceptionBillcodeIDs &= ", "
                    strExceptionBillcodeIDs &= R1("Billcode_ID")
                Next R1

                strSql = "SELECT if(Sum(DBill_AvgCost) is null, 0.00, Sum(DBill_AvgCost) ) as 'Unit Parts Cost' " & Environment.NewLine
                strSql &= "FROM tdevicebill  " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & "  " & Environment.NewLine
                If strExceptionBillcodeIDs.Trim.Length > 0 Then strSql &= "AND Billcode_ID not in ( " & strExceptionBillcodeIDs & ") " & Environment.NewLine
                Return Me._objDataProc.GetDoubleValue(strSql)

            Catch ex As Exception
                Throw ex
            Finally
                strSql = Nothing
                strExceptionBillcodeIDs = Nothing
                R1 = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Sub GetUnitsPartsCostAndTodayAPC(ByVal iCustID As Integer, _
                                                ByVal iLocID As Integer, _
                                                ByVal iModelID As Integer, _
                                                ByVal iDeviceID As Integer, _
                                                ByRef decUnitPartsCost As Decimal, _
                                                ByRef decTodayAvgPartsCost As Decimal)
            Dim strSql As String
            Dim dt As DataTable
            Dim strExceptionBillcodeIDs As String = ""
            Dim strDeviceIDs As String = ""
            Dim R1 As DataRow
            Dim iTotalUnits As Integer = 0

            Try
                'get exception bill codes
                strSql = "SELECT Billcode_ID " & Environment.NewLine
                strSql &= "FROM tavgpartcostgoalexcpt " & Environment.NewLine
                strSql &= "WHERE Model_ID = " & iModelID & Environment.NewLine
                strSql &= "AND Cust_ID = " & iCustID & Environment.NewLine
                strSql &= "AND Active  = 1"
                dt = Me._objDataProc.GetDataTable(strSql)
                For Each R1 In dt.Rows
                    If strExceptionBillcodeIDs.Trim.Length > 0 Then strExceptionBillcodeIDs &= ", "
                    strExceptionBillcodeIDs &= R1("Billcode_ID")
                Next R1

                Generic.DisposeDT(dt)

                'get distinct unit get bill today
                strSql = "SELECT Distinct tdevice.Device_ID " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID " & Environment.NewLine
                strSql &= "INNER join lbillcodes on tdevicebill.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                strSql &= "WHERE tdevice.Loc_ID = " & iLocID & Environment.NewLine
                strSql &= "AND tdevice.Model_ID = " & iModelID & Environment.NewLine
                strSql &= "AND lbillcodes.BillCode_Rule in ( 0, 4, 5, 6,7 )  " & Environment.NewLine
                strSql &= "AND tdevicebill.Date_Rec = Date_format(now(), '%Y-%m-%d')" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                For Each R1 In dt.Rows
                    If strDeviceIDs.Trim.Length > 0 Then strDeviceIDs &= ", "
                    strDeviceIDs &= R1("Device_ID")
                Next R1

                iTotalUnits = dt.Rows.Count

                Generic.DisposeDT(dt)

                If strDeviceIDs.Trim.Length > 0 Then
                    strSql = "SELECT tdevicebill.Device_ID, sum(tdevicebill.DBill_AvgCost) as 'Unit Part Cost' " & Environment.NewLine
                    strSql &= "FROM tdevicebill " & Environment.NewLine
                    strSql &= "WHERE tdevicebill.Device_ID IN ( " & strDeviceIDs & ") " & Environment.NewLine
                    If strExceptionBillcodeIDs.Trim.Length > 0 Then strSql &= "AND tdevicebill.Billcode_ID not in ( " & strExceptionBillcodeIDs & ") " & Environment.NewLine
                    strSql &= "GROUP BY tdevicebill.Device_ID " & Environment.NewLine
                    dt = Me._objDataProc.GetDataTable(strSql)

                    'Cal unit's part cost
                    If dt.Select("Device_ID = " & iDeviceID).Length > 0 Then
                        decUnitPartsCost = dt.Compute("Sum([Unit Part Cost])", "Device_ID = " & iDeviceID)
                    Else
                        'When the scaned unit billed parts b/f today, unit will not show in query
                        'therefore need to get it separate.
                        decUnitPartsCost = Me.GetUnitPartCost(iCustID, iModelID, iDeviceID)
                    End If

                    'Cal Today Average Part Cost
                    If Not IsDBNull(dt.Compute("Sum([Unit Part Cost])", "")) Then decTodayAvgPartsCost = dt.Compute("Sum([Unit Part Cost])", "") / CDbl(iTotalUnits) Else decTodayAvgPartsCost = 0.0
                Else
                    'if current unit is the first one then get part cost of current unit
                    decUnitPartsCost = Me.GetUnitPartCost(iCustID, iModelID, iDeviceID)
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '******************************************************************
        Public Shared Function GetAvgPartsCost(ByVal iModelID As Integer, _
                                          ByVal strDate As String, _
                                          ByVal booOneDay As Boolean, _
                                          ByVal iGroup_ID As Integer, _
                                          ByVal icc_id As Integer, _
                                          ByVal iUsrID As Integer, _
                                          ByRef iTotalQty As Integer, _
                                          ByRef decTotalCost As Decimal) As Decimal
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String
            Dim dt, dt2 As DataTable
            Dim strDeviceIDs As String = ""
            Dim R1, R2 As DataRow
            Dim strStartDt As String = ""
            Dim strEndDt As String = ""
            Dim iDeviceQty As Integer = 0
            Dim drArrExpBillcode As DataRow()
            Dim i As Integer = 0
            Dim decReturnVal As Decimal = 0.0

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                'Exception billcodes
                strSql = "SELECT Cust_ID, Billcode_ID " & Environment.NewLine
                strSql &= "FROM tavgpartcostgoalexcpt " & Environment.NewLine
                strSql &= "WHERE Model_ID = " & iModelID & Environment.NewLine
                strSql &= "AND Active  = 1"
                dt = objDataProc.GetDataTable(strSql)

                'Device Qty
                strSql = "SELECT Distinct tdevice.Device_ID " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                strSql &= "INNER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID " & Environment.NewLine
                strSql &= "INNER join lbillcodes on tdevicebill.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                strSql &= "WHERE tdevice.Model_ID = " & iModelID & Environment.NewLine
                strSql &= "AND tworkorder.Group_ID = " & iGroup_ID & Environment.NewLine
                strSql &= "AND lbillcodes.BillCode_Rule not in ( 1,2,8,9 ) " & Environment.NewLine
                If icc_id > 0 Then
                    strSql &= "AND tdevice.cc_id = " & icc_id & " " & Environment.NewLine
                End If
                If iUsrID > 0 Then
                    strSql &= "AND tdevicebill.User_ID = " & iUsrID & " " & Environment.NewLine
                End If
                If booOneDay = True Then
                    strSql &= "AND tdevicebill.Date_Rec = '" & strDate & "' " & Environment.NewLine
                Else
                    strStartDt = Format(DateAdd(DateInterval.Day, (Weekday(CDate(strDate), FirstDayOfWeek.Monday) - 1) * -1, CDate(strDate)), "yyyy-MM-dd")
                    strEndDt = Format(DateAdd(DateInterval.Day, 6, CDate(strStartDt)), "yyyy-MM-dd")
                    strSql &= "AND tdevicebill.Date_Rec BETWEEN '" & strStartDt & "' AND '" & strEndDt & "' " & Environment.NewLine
                End If

                dt2 = objDataProc.GetDataTable(strSql)
                For Each R1 In dt2.Rows
                    If strDeviceIDs.Trim.Length > 0 Then strDeviceIDs &= ", "
                    strDeviceIDs &= R1("Device_ID")
                Next R1

                iDeviceQty = dt2.Rows.Count
                iTotalQty += iDeviceQty

                Generic.DisposeDT(dt2)

                'Cal parts cost and avg parts cost
                If strDeviceIDs.Trim.Length > 0 Then
                    strSql = "SELECT Cust_ID, tdevicebill.Billcode_ID, sum(tdevicebill.DBill_AvgCost) as 'Cost' " & Environment.NewLine
                    strSql &= "FROM tdevice " & Environment.NewLine
                    strSql &= "INNER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID " & Environment.NewLine
                    strSql &= "INNER join lbillcodes on tdevicebill.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                    strSql &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                    strSql &= "WHERE tdevice.Model_ID = " & iModelID & Environment.NewLine
                    strSql &= "AND lbillcodes.BillCode_Rule not in ( 1,2,8,9 ) " & Environment.NewLine
                    strSql &= "AND lbillcodes.billType_ID = 2 " & Environment.NewLine
                    strSql &= "AND tdevice.Device_ID in (" & strDeviceIDs & " )" & Environment.NewLine
                    strSql &= "Group by Cust_ID, Billcode_ID "
                    dt2 = objDataProc.GetDataTable(strSql)

                    For Each R1 In dt.Rows
                        drArrExpBillcode = dt2.Select("Cust_ID = " & R1("Cust_ID") & " AND Billcode_ID = " & R1("Billcode_ID"))

                        For i = 0 To drArrExpBillcode.Length - 1
                            R2 = drArrExpBillcode(i)
                            R2.BeginEdit()
                            R2("Cost") = 0.0
                            R2.AcceptChanges()
                        Next i

                        drArrExpBillcode = Nothing
                    Next R1

                    If dt2.Rows.Count > 0 AndAlso Not IsDBNull(dt2.Compute("Sum(Cost)", "")) Then decReturnVal = dt2.Compute("Sum(Cost)", "") / iDeviceQty
                    If dt2.Rows.Count > 0 AndAlso Not IsDBNull(dt2.Compute("Sum(Cost)", "")) Then decTotalCost += dt2.Compute("Sum(Cost)", "")
                End If

                Return decReturnVal
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                R2 = Nothing
                Generic.DisposeDT(dt)
                Generic.DisposeDT(dt2)
            End Try
        End Function

        '******************************************************************

    End Class
End Namespace