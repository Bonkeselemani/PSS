Option Explicit On 

Imports System
Imports System.Data
Imports System.Text
Imports MySql.Data
Imports System.IO

Namespace Buisness.VV
    Public Class Vivint_WO_DockRecv
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

        Public Function GetVivintLocations(ByVal iCust_ID As Integer, ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "Select Loc_ID,Loc_Name from production.tlocation WHere Cust_ID=" & iCust_ID & ";"
                dt = Me._objDataProc.GetDataTable(strSql)

                If booAddSelectRow Then dt.LoadDataRow(New Object() {0, "--Select--"}, True)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetVivintNoWarranty() As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "Select modelids from production.exceptioncriteria WHere Description='VIVINT_WO_NOWARRANTY' and Active=1;"
                dt = Me._objDataProc.GetDataTable(strSql)


                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetVivintProduct(ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "Select prod_id,prod_desc from production.lproduct where prod_id=75 ;"
                dt = Me._objDataProc.GetDataTable(strSql)

                If booAddSelectRow Then dt.LoadDataRow(New Object() {0, "--Select--"}, True)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetVivintModel(ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "Select model_id,model_desc from production.tmodel where prod_id=75 and prodGrp_id=204;"
                dt = Me._objDataProc.GetDataTable(strSql)

                If booAddSelectRow Then dt.LoadDataRow(New Object() {0, "--Select--"}, True)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetLastInsertedId(ByVal tblName As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "Select last_insert_id() from '" & tblName & "';"
                dt = Me._objDataProc.GetDataTable(strSql)



                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function saveVivintWO(ByVal booAddSelectRow As Boolean, ByVal wo_custwo As String, ByVal wo_date As String, ByVal wo_quantity As Integer, ByVal wo_RaQnty As Integer, ByVal Loc_ID As String, ByVal Prod_ID As String, ByVal wo_timestamp As String, ByVal orderType_Id As String, ByVal gpid As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "insert into production.tworkorder(wo_custwo,wo_date,wo_quantity,wo_RaQnty,Loc_ID,Prod_ID,Group_id,wo_timestamp,orderType_Id) values('" & wo_custwo & "','" & wo_date & "'," & wo_quantity & "," & wo_quantity & ",'" & Loc_ID & "','" & Prod_ID & "','" & gpid & "','" & wo_timestamp & "',1);"
                Dim woId As Integer = Me._objDataProc.ExecuteScalarForInsert(strSql, "production.tworkorder")


                Return woId
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function saveVivintBoxId(ByVal booAddSelectRow As Boolean, ByVal warantyType As Integer, ByVal boxId As String, ByVal modelId As String, ByVal woId As String, ByVal OrderQty As Integer, ByVal whloc As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "insert into edi.twarehousebox (boxid,warrantyFlag,model_id,wo_id,order_qty,order_id,WHLocation) values('" & boxId & "'," & warantyType & ",'" & modelId & "'," & woId & "," & OrderQty & ",0,'" & whloc & "');"
                Dim Id As Integer = Me._objDataProc.ExecuteNonQuery(strSql)


                Return Id
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        Public Function getPoDetails(ByVal wo As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT t3.model_desc,t2.order_qty,t2.recv_qty,t2.model_id,t2.wo_id FROM production.tworkorder t1 , edi.twarehousebox t2,production.tmodel t3 WHERE t1.WO_ID=t2.WO_ID and t3.model_id=t2.model_id and t1.WO_custwo='" & wo & "';"
                dt = Me._objDataProc.GetDataTable(strSql)



                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function



        Public Function updateWoDetails(ByVal woId As String, ByVal modId As String, ByVal rec_qty As Integer) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim totQty, totRecv, totDiff, i As Integer

            Try
                strSql = "select order_qty,recv_qty,diff_qty from edi.twarehousebox where model_id='" & modId & "' and wo_ID='" & woId & "';"
                dt = Me._objDataProc.GetDataTable(strSql)
                totQty = CInt(dt.Rows(0).Item(0))
                totRecv = CInt(dt.Rows(0).Item(1)) + rec_qty
                totDiff = CInt(dt.Rows(0).Item(0)) - totRecv

                strSql = "Update edi.twarehousebox set recv_qty=" & totRecv & ",diff_qty=" & totDiff & ", closed=0 where model_id='" & modId & "' and wo_ID='" & woId & "';"
                i = Me._objDataProc.ExecuteNonQuery(strSql)



                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        Public Function updateTWorkOrder(ByVal woId As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim totQty, totRecv, totDiff, i As Integer

            Try

                strSql = "Update production.tworkorder set wo_closed=1 where  wo_ID='" & woId & "';"
                i = Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try

        End Function


    End Class
End Namespace