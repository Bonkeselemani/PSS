Option Explicit On 

Imports System.Windows.Forms

Namespace Buisness
    Public Class WHCharge
        Private _objDataProc As DBQuery.DataProc

#Region "Constructor/Destructor"

        '******************************************************************
        Public Sub New()
            Try
                Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub


        '******************************************************************
        Protected Overrides Sub Finalize()
            Me._objDataProc = Nothing
            MyBase.Finalize()
        End Sub

        '******************************************************************
#End Region

        '*************************************************************************************
        Public Function GetTermCustomers(ByVal booAddSelectRow As Boolean) As DataTable

            Dim dt As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT distinct tcustomer.Cust_ID, Concat(tcustomer.Cust_Name1, ' ', if(tcustomer.Cust_Name2 is null, '', tcustomer.Cust_Name2)) as Cust_Name1 " & Environment.NewLine
                strSql += "FROM tcustomer " & Environment.NewLine
                strSql += "WHERE Cust_Inactive = 0 AND Pay_ID = 1" & Environment.NewLine
                strSql += "ORDER BY cust_name1;"
                dt = Me._objDataProc.GetDataTable(strSql)

                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '*************************************************************************************
        Public Function GetWHChargeDefitionList(ByVal iCustID As Integer, _
                                                ByVal booAddSelectRow As Boolean, _
                                                ByVal booActiveItemOnly As Boolean) As DataTable
            Dim dt As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT WHCType_ID, WHCType_Desc, WHCType_UnitMeasurement" & Environment.NewLine
                strSql &= ", WHCType_Charge, Cust_ID, Active " & Environment.NewLine
                strSql &= ", IF(Active = 1 , 'Yes', 'No') as 'Active?'" & Environment.NewLine
                strSql &= "FROM warehouse.whchargetypes " & Environment.NewLine
                strSql &= "WHERE Cust_ID = " & iCustID & Environment.NewLine
                If booActiveItemOnly = True Then strSql &= "AND Active = 1" & Environment.NewLine
                strSql += "ORDER BY WHCType_Desc "
                dt = Me._objDataProc.GetDataTable(strSql)

                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '*************************************************************************************
        Public Function GetWHChargeDefition(ByVal iCustID As Integer, ByVal strDesc As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT * FROM warehouse.whchargetypes " & Environment.NewLine
                strSql &= "WHERE Cust_ID = " & iCustID & Environment.NewLine
                strSql &= "AND WHCType_Desc = '" & strDesc & "'"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************
        Public Function GetWHCharge(ByVal iCustID As Integer, ByVal strDateStart As String, _
                                    ByVal strDateEnd As String, Optional ByVal iChargeType As Integer = 0) As DataTable
            Dim dt As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT A.WHCType_Desc as 'Type' " & Environment.NewLine
                strSql &= ", concat(A.WHC_Qty, ' ', A.WHCType_UnitMeasurement) as 'Quantity'" & Environment.NewLine
                strSql &= ", A.WHC_TotalCharge as 'Total Charge', A.WHC_Date as 'Invoice Date'" & Environment.NewLine
                strSql &= ", A.WHC_AddedDate as 'Added Date'" & Environment.NewLine
                strSql &= ", B.User_Fullname as 'Added by'" & Environment.NewLine
                strSql &= ", A.WHCType_ID, A.WHC_ID, A.WHC_Qty " & Environment.NewLine
                strSql &= "FROM warehouse.whcharge A" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN security.tusers B ON A.WHC_AddedByUsrID = B.User_ID" & Environment.NewLine
                strSql &= "WHERE A.Cust_ID = " & iCustID & Environment.NewLine
                strSql &= "AND A.WHC_Date between '" & strDateStart & "' AND '" & strDateEnd & "' " & Environment.NewLine
                If iChargeType > 0 Then strSql &= "AND A.WHCType_ID = " & iChargeType
                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '*************************************************************************************
        Public Function AddWarehouseCharge(ByVal iCustID As Integer, ByVal iWHCTypesID As Integer, _
                                           ByVal strWHCTypeDesc As String, ByVal strUnitMeasurement As String, _
                                           ByVal decQty As Decimal, ByVal decTotalCharge As Decimal, _
                                           ByVal strInvDate As String, ByVal iUserID As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "INSERT INTO warehouse.whcharge ( " & Environment.NewLine
                strSql &= " WHCType_ID, WHCType_Desc, WHCType_UnitMeasurement, WHC_Date, WHC_Qty" & Environment.NewLine
                strSql &= ", WHC_TotalCharge, WHC_AddedByUsrID, WHC_AddedDate, Cust_ID" & Environment.NewLine
                strSql &= ") VALUES ( " & Environment.NewLine
                strSql &= iWHCTypesID & ", '" & strWHCTypeDesc & "', '" & strUnitMeasurement & "', '" & strInvDate & "', " & decQty & Environment.NewLine
                strSql &= ", " & decTotalCharge & ", " & iUserID & ", now(), " & iCustID & Environment.NewLine
                strSql &= ") " & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************
        Public Function UpdateWarehouseCharge(ByVal iWHCID As Integer, ByVal decQty As Decimal, _
                                              ByVal decTotalCharge As Decimal, ByVal iUserID As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "UPDATE warehouse.whcharge  " & Environment.NewLine
                strSql &= " SET WHC_Qty = " & decQty & ", WHC_TotalCharge = " & decTotalCharge & Environment.NewLine
                strSql &= ", WHC_AddedByUsrID = " & iUserID & ", WHC_AddedDate = now()" & Environment.NewLine
                strSql &= "WHERE WHC_ID = " & iWHCID & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************
        Public Function AddWHChargeDefition(ByVal iCustID As Integer, ByVal strDesc As String, _
                                            ByVal strUnitOfMeasure As String, ByVal decCharge As Decimal) As Integer
            Dim strSql As String = ""

            Try
                strSql = "INSERT INTO warehouse.whchargetypes ( " & Environment.NewLine
                strSql &= " WHCType_Desc, WHCType_UnitMeasurement, WHCType_Charge, Cust_ID " & Environment.NewLine
                strSql &= ") VALUES ( " & Environment.NewLine
                strSql &= "'" & strDesc & "', '" & strUnitOfMeasure & "', " & decCharge & ", " & iCustID & Environment.NewLine
                strSql &= ") " & Environment.NewLine

                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************
        Public Function SetWHDefActiveFlag(ByVal strWHCTypeIDs As String, ByVal iActive As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "UPDATE warehouse.whchargetypes SET Active = " & iActive & Environment.NewLine
                strSql &= " WHERE WHCType_ID IN ( " & strWHCTypeIDs & ")" & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************

    End Class
End Namespace