Option Explicit On 

Imports System.Data.SqlClient

Namespace Buisness
    Public Class Legiant

        '******************************************************************
        Public Function GetLegiantLoginHrs(ByVal iEENo As Integer, _
                                           ByVal strDate As String) As Decimal
            Dim strSql As String
            Dim dt As DataTable
            Dim decHrs As Decimal = 0.0
            Try
                strSql = "SELECT (DATEDIFF(Minute, [RoundedInTime], [RoundedOutTime] ) / 60.0) AS Hrs, GETDATE() as 'Now', [RoundedInTime] as 'InTime' " & Environment.NewLine
                strSql &= "FROM Legiant.dbo.PunchSet A " & Environment.NewLine
                strSql &= "INNER JOIN Legiant.dbo.Employee B ON B.EmployeeKey = A.EmployeeKey" + Environment.NewLine
                strSql &= "WHERE CAST(B.EmployeeNumber AS INT) = " & iEENo & Environment.NewLine
                strSql &= "AND A.ReportDate = '" & strDate & "' " & Environment.NewLine
                dt = Me.GetLegiantDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0)("Hrs")) Then decHrs = dt.Rows(0)("Hrs")
                    If decHrs < 0.1 And strDate = Format(dt.Rows(0)("Now"), "yyyy-MM-dd") Then decHrs = DateDiff(DateInterval.Hour, dt.Rows(0)("InTime"), dt.Rows(0)("Now"))
                End If

                Return decHrs
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function IsLegiantLogin(ByVal iEENum As Integer, _
                                       ByVal strDate As String) As Boolean
            Dim strSql As String
            Dim dt As DataTable = Nothing

            Try
                strSql = "SELECT CAST(B.EmployeeNumber AS INT) AS EmployeeNo, LEFT(CONVERT(VARCHAR(19), RoundedInTime, 120), 10) AS InDate, RIGHT(CONVERT(VARCHAR(19), RoundedInTime, 120), 8) AS StartTime" & Environment.NewLine
                strSql &= "FROM Legiant.dbo.PunchSet A" & Environment.NewLine
                strSql &= "INNER JOIN Legiant.dbo.Employee B ON B.EmployeeKey = A.EmployeeKey" + Environment.NewLine
                strSql &= "WHERE CAST(B.EmployeeNumber AS INT) = " & iEENum & Environment.NewLine
                strSql &= "AND LEFT(CONVERT(VARCHAR(19), A.RoundedInTime, 120), 10) = '" & strDate & "';"
                dt = Me.GetLegiantDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                'Return true if login Legiant is down
                IsLegiantLogin = True
            Finally
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Function

        '******************************************************************
        Public Function GetLegiantTimeCardHrs(ByVal strEENum As String, _
                                             ByVal strDate As String) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT CAST(B.EmployeeNumber AS INT) AS 'EE#' " & Environment.NewLine
                strSql &= ", LEFT(CONVERT(VARCHAR(19), ReportDate, 120), 10) AS RptDate " & Environment.NewLine
                'strSql &= ", RIGHT(CONVERT(VARCHAR(19), RoundedInTime, 120), 8) AS StartTime" & Environment.NewLine
                'strSql &= ", RIGHT(CONVERT(VARCHAR(19), RoundedOutTime, 120), 8) AS EndTime" & Environment.NewLine
                strSql &= ", SUM((((SUBSTRING(CONVERT(VARCHAR(19), RoundedOutTime , 120), 12, 2) * 3600) - " & Environment.NewLine
                strSql &= "    (SUBSTRING(CONVERT(VARCHAR(19), RoundedInTime, 120), 12, 2) * 3600) ) + " & Environment.NewLine
                strSql &= "   ((SUBSTRING(CONVERT(VARCHAR(19), RoundedOutTime , 120), 15, 2) * 60 ) - " & Environment.NewLine
                strSql &= "    (SUBSTRING(CONVERT(VARCHAR(19), RoundedInTime, 120), 15, 2) * 60 ) ) + " & Environment.NewLine
                strSql &= "   ((SUBSTRING(CONVERT(VARCHAR(19), RoundedOutTime , 120), 18, 2) * 1)  - " & Environment.NewLine
                strSql &= "    (SUBSTRING(CONVERT(VARCHAR(19), RoundedInTime, 120), 18, 2) * 1 ) ) ) / 3600.0) AS LegiantHrs " & Environment.NewLine
                strSql &= "FROM Legiant.dbo.PunchSet A " & Environment.NewLine
                strSql &= "INNER JOIN Legiant.dbo.Employee B ON B.EmployeeKey = A.EmployeeKey" + Environment.NewLine
                strSql &= "WHERE CAST(B.EmployeeNumber AS INT) IN ( " & strEENum & ")" & Environment.NewLine
                strSql &= "AND LEFT(CONVERT(VARCHAR(19), A.ReportDate, 120), 10) = '" & strDate & "' " & Environment.NewLine
                strSql &= "GROUP BY B.EmployeeNumber, A.ReportDate "
                Return Me.GetLegiantDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetLegiantLoginTime(ByVal strEENum As String, _
                                            ByVal strDate As String) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT CAST(B.EmployeeNumber AS INT) AS 'EE#' " & Environment.NewLine
                strSql &= ", RoundedInTime as 'In' " & Environment.NewLine
                strSql &= ", RoundedOutTime as 'Out' " & Environment.NewLine
                strSql &= "FROM Legiant.dbo.PunchSet A " & Environment.NewLine
                strSql &= "INNER JOIN Legiant.dbo.Employee B ON B.EmployeeKey = A.EmployeeKey" + Environment.NewLine
                strSql &= "WHERE CAST(B.EmployeeNumber AS INT) IN ( " & strEENum & ")" & Environment.NewLine
                strSql &= "AND LEFT(CONVERT(VARCHAR(19), A.ReportDate, 120), 10) = '" & strDate & "' " & Environment.NewLine
                Return Me.GetLegiantDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Private Function GetLegiantDataTable(ByVal strSql As String) As DataTable
            Dim objLegiantConn As SqlConnection = Nothing
            Dim objCommand As SqlCommand = Nothing
            Dim objAdapter As SqlDataAdapter = Nothing
            Dim dt As DataTable = Nothing

            Try
                objLegiantConn = GetLegiantConnection()
                objLegiantConn.Open()

                objCommand = New SqlCommand(strSql, objLegiantConn)
                objAdapter = New SqlDataAdapter()
                dt = New DataTable()

                objAdapter.SelectCommand = objCommand
                objAdapter.Fill(dt)
                objAdapter.Dispose()

                objCommand = New SqlCommand(strSql, objLegiantConn)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(objLegiantConn) Then
                    If objLegiantConn.State = ConnectionState.Open Then objLegiantConn.Close()
                End If
                If Not IsNothing(objAdapter) Then
                    objAdapter.Dispose()
                    objAdapter = Nothing
                End If
                If Not IsNothing(objCommand) Then
                    objCommand.Dispose()
                    objCommand = Nothing
                End If
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Function

        '******************************************************************
        Private Function GetLegiantConnection() As SqlConnection
            Dim objLegiantConn As SqlConnection = Nothing
            Dim strConn As String
            Try
                strConn = "user id=pssi;password=Reports3970;server=PHQ-MAIN;Trusted_Connection=no;database=master;connection timeout=30"
                objLegiantConn = New SqlConnection(strConn)
                Return objLegiantConn
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************

    End Class
End Namespace
