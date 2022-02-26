Option Explicit On 

Imports System
Imports System.Data
Imports System.Text
Imports MySql.Data
Imports System.IO

Namespace Buisness.VV
    Public Class Vivint_Kitting
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

        Public Function checkKittedDevice(ByVal devId As String) As DataTable
            Dim strsql As String = String.Empty
            Dim dt As DataTable

            Try

                strsql = "SELECT dkit_id FROM production.tdevice_kitting where device_id='" & devId & "'" & Environment.NewLine
             
                dt = Me._objDataProc.GetDataTable(strsql)

                Return dt

            Catch ex As Exception
                Throw ex
            End Try

        End Function

        Public Function kittingLimitCharges(ByVal custId As Integer, ByVal kittingLimit As Integer, ByVal modId As String) As DataTable
            Dim strsql As String = String.Empty
            Dim dt As DataTable

            Try

                strsql = "SELECT A.tcalim_amount FROM tcustaggregateLimit A" & Environment.NewLine
                strsql &= " INNER JOIN lBillcodes B ON A.Billcode_ID=B.BillCode_ID" & Environment.NewLine
                strsql &= " WHERE Cust_ID=" & custId & " AND A.Model_id='" & modId & "' AND A.BillCode_ID =" & kittingLimit & ";" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strsql)

                Return dt

            Catch ex As Exception
                Throw ex
            End Try

        End Function

        Public Function kittingCharges(ByVal custId As Integer, ByVal bilCode As Integer) As DataTable
            Dim strsql As String = String.Empty
            Dim dt As DataTable

            Try

                strsql = "SELECT sum(A.tcab_Amount) FROM tcustaggregatebilling A" & Environment.NewLine
                strsql &= " INNER JOIN lBillcodes B ON A.Billcode_ID=B.BillCode_ID" & Environment.NewLine
                strsql &= " WHERE Cust_ID=" & custId & " AND A.BillCode_ID =" & bilCode & ";" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strsql)

                Return dt

            Catch ex As Exception
                Throw ex
            End Try

        End Function

        Public Function getPrice(ByVal psPrice As String) As DataTable


            Try

                Dim strsql As String = String.Empty
                Dim dt As DataTable

                strsql = "SELECT PSPrice_AvgCost,PSPrice_StndCost,PSPrice_ID,PSPrice_Desc FROM  lpsprice WHERE PSPrice_Number='" & psPrice & "'"
                dt = Me._objDataProc.GetDataTable(strsql)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try

        End Function

        Public Function checkSN(ByVal sn As String) As DataTable
            Dim strsql As String = String.Empty
            Dim dt As DataTable

            Try
                strsql = "SELECT model_id,device_id,device_laborcharge,device_partcharge FROM production.tdevice WHERE device_sn='" & sn & "' AND device_dateship IS NULL "
                dt = Me._objDataProc.GetDataTable(strsql)

                Return dt

            Catch ex As Exception
                Throw ex
            End Try

        End Function

        Public Function getVivintKitting() As DataTable


            Dim strSql As String = String.Empty
            Dim dt As DataTable

            Try
                strSql = "SELECT kitting_setup,master_model_id FROM ttffk_kitting_items_setmaster A;"
                dt = Me._objDataProc.GetDataTable(strSql)

                'dt.LoadDataRow(New Object() {5, "--Select--"}, True)
                Return dt
            Catch ex As Exception

            End Try

        End Function

        Public Function GetBOMData(ByVal modId As String, ByVal custId As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try

                strSql = "SELECT  A.KMSet_ID,A.Kitting_SetUp,A.Master_Model_ID AS 'Device_Model_ID',C.Model_Desc" & Environment.NewLine
                strSql &= " ,B.Component_Model_ID AS 'PsPrice_ID',D.PSPrice_Number,D.PSPrice_Desc,B.Qty AS 'Part_Qty'" & Environment.NewLine
                strSql &= " ,E.Component_Model_ID AS 'ALt_PsPrice_ID',E.Qty AS 'Alt_Part_Qty',B.Component_Type,C.ShippedModel_Desc" & Environment.NewLine
                strSql &= " FROM ttffk_kitting_items_setmaster A" & Environment.NewLine
                strSql &= " INNER JOIN  ttffk_kitting_items_setdetail  B ON A.KMSet_ID=B.KMSet_ID" & Environment.NewLine
                strSql &= " INNER JOIN tModel C ON A.Master_Model_ID=C.Model_ID" & Environment.NewLine
                strSql &= " INNER JOIN lPsPrice D ON B.Component_Model_ID=D.PsPrice_ID" & Environment.NewLine
                strSql &= " LEFT JOIN ttffk_kitting_items_setdetail_alt E ON B.KDSet_ID=E.KDSet_ID" & Environment.NewLine
                strSql &= " LEFT JOIN lPsPrice F ON E.Component_Model_ID=F.PsPrice_ID" & Environment.NewLine
                strSql &= " WHERE A.IsActive=1 AND Cust_ID=" & custId & " AND A.Master_Model_ID='" & modId & "';" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)


                Return dt

            Catch ex As Exception
                Throw ex
            End Try

        End Function
        Public Function modelName(ByVal mdId As String) As DataTable


            Dim strSql As String = String.Empty
            Dim dt As DataTable


            Try

                strSql = "select shippedmodel from production.tmodel where Model_Desc='" & mdId & "'"
                dt = Me._objDataProc.GetDataTable(strSql)


                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function saveKitting(ByVal KMSet_ID, ByVal Device_ID, ByVal Device_LaborCharge, ByVal Device_PartCharge, ByVal User_ID, ByVal Device_DateKit) As Integer


            Dim strSql As String = String.Empty
            Dim savedNum As Integer

            Try

                strSql = "Insert into production.tdevice_Kitting " & vbCrLf
                strSql &= "(KMSet_ID,Device_ID,Device_LaborCharge,Device_PartCharge,User_ID,Device_DateKit) " & vbCrLf
                strSql &= "values ('" & KMSet_ID & "','" & Device_ID & "','" & Device_LaborCharge & "','" & Device_PartCharge & "','" & User_ID & "','" & Device_DateKit & "')"
                savedNum = Me._objDataProc.ExecuteNonQuery(strSql)


                Return savedNum

            Catch ex As Exception
                Throw ex
            End Try
        End Function


        Public Function saveKittingBill(ByVal Device_ID, ByVal RegPartPrice, ByVal AvgCost, ByVal StdCost, ByVal KMSet_ID, ByVal BillCode_ID, ByVal PSPrice_ID, ByVal Device_LaborCharge, ByVal Device_PartCharge) As Integer


            Dim strSql As String = String.Empty
            Dim savedNum As Integer

            Try

                strSql = "Insert into production.tdevice_KittingBill(Device_ID,RegPartPrice,AvgCost,StdCost,KMSet_ID,BillCode_ID,PSPrice_ID,Device_LaborCharge,Device_PartCharge) values ('" & Device_ID & "','" & RegPartPrice & " ','" & AvgCost & "','" & StdCost & "','" & KMSet_ID & "','" & BillCode_ID & "','" & PSPrice_ID & "','" & Device_LaborCharge & "','" & Device_PartCharge & "')"
                savedNum = Me._objDataProc.ExecuteNonQuery(strSql)


                Return savedNum

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getBillingData(ByVal custId As Integer, ByVal locId As Integer) As DataTable





        End Function


    End Class
End Namespace
