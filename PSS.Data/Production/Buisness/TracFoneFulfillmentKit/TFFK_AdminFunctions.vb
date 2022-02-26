Option Explicit On 

Imports System
Imports System.Data
Imports System.Text
Imports MySql.Data

Namespace Buisness.TracFoneFulfillmentKit
    Public Class TFFK_AdminFunctions
        Private _objDataProc As mySQL5
        Private dt As DataTable
   
#Region "Constructor/Destructor"

        '******************************************************************
        Public Sub New()
            Try
                Me._objDataProc = New mySQL5()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '******************************************************************
        Protected Overrides Sub Finalize()
            Me._objDataProc = Nothing
            MyBase.Finalize()
        End Sub

#End Region

#Region "View Available Models"

        Public Function getAvailableModels(ByVal dcodeId As Integer) As DataTable
            Dim strSql As String = "select Model_ID,Model_Desc from production.tmodel_items where Class_Dcode_Id='" & dcodeId & "'"
            dt = Me._objDataProc.GetDataTable(strSql)

            Return dt
        End Function

        Public Function getOneModel(ByVal modelId As Integer) As DataTable
            Dim strSql As String = "select * from production.tmodel_items where Model_ID='" & modelId & "'"
            dt = Me._objDataProc.GetDataTable(strSql)
            Return dt
        End Function



#End Region

#Region "New UPC"

        Public Function retrieveModeID() As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT MCode_ID,Mcode_desc from production.lcodesmaster"
                dt = Me._objDataProc.GetDataTable(strSql)
                Return dt

            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try

        End Function

        Public Function saveUPCDetaill(ByVal str As String) As Integer
            Dim dt As DataTable
            Dim strSql As String
            Try

                strSql = "INSERT INTO production.lcodesdetail (Dcode_SDesc,Dcode_LDesc,Prod_Id,Mcode_ID,User_Id,UpdatedDate)VALUES (" & str & ")"
                'msgbox(strSql)
                Dim id As Integer = Me._objDataProc.GetLastInsertedPrimaryKey(strSql, "production.lcodesdetail")

                Return id
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try

        End Function


        'Public Function GetUpc(ByVal Dcode_SDesc As String, ByVal Dcode_LDesc As String) As DataTable
        '    Dim dt As DataTable
        '    Dim strSql As String
        '    Try

        '        strSql = "SELECT  Dcode_Id from production.lcodesdetail as a where a.Dcode_SDesc ='" & Dcode_SDesc & "' "
        '        'msgbox(strSql)
        '        dt = Me._objDataProc.GetDataTable(strSql)
        '        Return dt

        '    Catch ex As Exception
        '        MsgBox(ex.Message.ToString)
        '    End Try

        'End Function

#End Region


#Region "Inventory WIP"
        Public Function InventoryWIPLocation() As DataTable
            Dim strSql As String = "select Order_ID, BoxID, Model_Desc, Model_LDesc, WHLocation, Workstation, PickLocation,"
            strSql &= "Qty from edi.twarehousebox A Inner join production.tmodel_items B On A.Model_ID=B.Model_ID;"
            dt = Me._objDataProc.GetDataTable(strSql)
            Return dt
        End Function



#End Region

#Region "Inventory Balance"
        Public Function loadInventoryBalance() As DataTable
            Dim strSql As String = "SELECT * FROM VIEWS.V_TFFK_TFINVN"
            dt = Me._objDataProc.GetDataTable(strSql)
            Return dt
        End Function



#End Region

#Region "Add New Model Tab"
        Public Function saveNewModel(ByVal str As String) As Integer
            Dim strSql As String
            Try

                strSql = "INSERT INTO PRODUCTION.TMODEL_ITEMS (Model_Desc,Model_LDesc,Prod_ID,Class_DCode_Id,SubClass_Dcode_Id,Tech_DCode_Id,Weight,Height,Width,Length,UPC_DCode_Id,User_Id,UpdateDate,IdataSet_Id)VALUES (" & str & ")"
                'msgbox(strSql)
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try

        End Function

        Public Function GetSubClassDcodeId(ByVal id As Integer) As DataTable
            'production.lcodesdetail MCode_Id=82 MCode_Id=83 hard coded relation ship between Dcodes 
            Dim strSql As String
            Dim dt As DataTable
            Dim i As Integer = 0
            Dim hs As String = "HS"
            Dim by As String = "BY"
            Dim sm As String = "SM"
            Dim cl As String = "CL"
            Dim tr As String = "TR"
            Try
                If id = 4231 Then
                    strSql = "select distinct Dcode_id,dcode_Sdesc  from production.lcodesdetail  where dcode_sdesc='" & hs & "' and mcode_id=83"
                ElseIf id = 6462 Then
                    strSql = "select distinct Dcode_id,dcode_Sdesc from  production.lcodesdetail  where dcode_sdesc='" & by & "' and mcode_id=83"
                ElseIf id = 50002 Then
                    strSql = "select distinct Dcode_id,dcode_Sdesc from  production.lcodesdetail  where dcode_sdesc='" & sm & "' and mcode_id=83"
                ElseIf id = 50001 Then
                    strSql = "select distinct Dcode_id,dcode_Sdesc from  production.lcodesdetail  where dcode_sdesc='" & cl & "' or dcode_sdesc='" & tr & "' and mcode_id=83"
                End If
                dt = Me._objDataProc.GetDataTable(strSql)
                Return dt

            Catch ex As Exception
                Throw ex
            End Try

        End Function

        Public Function GetUPC_DCODE_ID(ByVal id As String) As DataTable
            Dim strSql As String
            Dim dt As DataTable
            Dim i As Integer = 0

            Try
                strSql = "select Dcode_id,Dcode_Sdesc from production.lcodesdetail where dcode_Sdesc=" & id & ""
                dt = Me._objDataProc.GetDataTable(strSql)
                Return dt

            Catch ex As Exception
                Throw ex
            End Try

        End Function


        Public Function GetTechnology(ByVal id As Integer) As DataTable
            Dim strSql As String
            Dim dt As DataTable
            Dim i As Integer = 0

            Try
                strSql = "select Dcode_id,Dcode_Sdesc,Dcode_Ldesc from production.lcodesdetail where Mcode_id=" & id
                dt = Me._objDataProc.GetDataTable(strSql)
                Return dt

            Catch ex As Exception
                Throw ex
            End Try

        End Function
#End Region

        Public Function GetTFFKModel() As DataTable
            Dim strSql As String
            Dim dt As DataTable
            Dim i As Integer = 0

            Try
                strSql = "SELECT DISTINCT a.Model_ID, a.Model_Desc, a.Model_LDesc" & Environment.NewLine
                strSql &= "FROM production.tmodel_items a" & Environment.NewLine
                strSql &= "INNER JOIN warehouse.warehouse_items b ON a.Model_ID = b.Model_ID;" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                dt.LoadDataRow(New Object() {"0", "--Select--"}, False)
                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function


        Public Function GetAllModels() As DataTable
            Dim strSql As String
            Dim dt As DataTable
            Dim i As Integer = 0

            Try
                strSql = "SELECT Model_ID, Model_Desc" & Environment.NewLine
                strSql &= "FROM production.tmodel_items" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function


        Public Function GetTransData(ByVal modelID As Integer) As DataTable
            Dim strSql As String
            Dim dt As DataTable
            Dim i As Integer = 0

            Try
                strSql = "SELECT 'RC' AS 'Trans Type', DATE_FORMAT(c.Date_Received, '%m/%d/%Y') AS 'Trans Date', DATE_FORMAT(c.Date_Received,'%H:%i') AS 'Trans Time'" & Environment.NewLine
                strSql &= ", a.OrderQty AS 'Trans Qty', 'On-hand Qty' AS 'End Balance', e.user_name AS 'USER'" & Environment.NewLine
                strSql &= "FROM saleorders.soheader a" & Environment.NewLine
                strSql &= "INNER JOIN saleorders.sodetails b ON a.SOHeaderID = b.SOHeaderID" & Environment.NewLine
                strSql &= "INNER JOIN warehouse.warehouse_items c ON b.Model_ID = c.Model_ID" & Environment.NewLine
                strSql &= "INNER JOIN production.tmodel_items d ON b.Model_ID = d.Model_ID" & Environment.NewLine
                strSql &= "INNER JOIN security.tusers e ON c.Recpt_UsrID = e.user_id" & Environment.NewLine
                strSql &= "WHERE c.SODetailsID = 0 AND b.Model_ID = " & modelID & Environment.NewLine
                strSql &= "GROUP BY a.PONumber, b.Model_ID" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getOpenOrderData() As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim row As DataRow
            Dim i As Integer = 0

            Try
                strSql = "SELECT A.PoNumber as 'OrderNo', B.SKU, A.ExpectedDeliveryDate as 'Req. Ship'" & Environment.NewLine
                strSql &= " ,a.ShipCarrier as 'Current Ship Method', B.Quantity as 'No. Item'" & Environment.NewLine
                strSql &= " ,A.OrderQty as 'Total Order Qty'" & Environment.NewLine
                strSql &= " FROM saleorders.SoHeader A" & Environment.NewLine
                strSql &= " INNER JOIN saleorders.SoDetails B ON A.SoHeaderID=B.SoheaderID" & Environment.NewLine
                strSql &= " INNER JOIN production.tworkorder C ON A.WorkOrderID=C.WO_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tmodel_items D ON B.Model_ID = D.Model_ID" & Environment.NewLine
                strSql &= " WHERE A.iDataSet_ID=1 AND A.ShipDate is Null AND Workstation='Waiting'" & Environment.NewLine
                'strSql &= " GROUP BY OrderNo;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getOrderData() As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim row As DataRow
            Dim i As Integer = 0

            Try
                strSql = "SELECT A.PoNumber as 'OrderNo', A.ExpectedDeliveryDate as 'Req. Ship'" & Environment.NewLine
                strSql &= " ,a.ShipCarrier as 'Current Ship Method', Count(*) as 'No. Item'" & Environment.NewLine
                strSql &= " ,SUM(B.Quantity) as 'Total', '' as 'Expedite Ship Method'" & Environment.NewLine
                strSql &= " FROM saleorders.SoHeader A" & Environment.NewLine
                strSql &= " INNER JOIN saleorders.SoDetails B ON A.SoHeaderID=B.SoheaderID" & Environment.NewLine
                strSql &= " INNER JOIN production.tworkorder C ON A.WorkOrderID=C.WO_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tmodel_items D ON B.Model_ID = D.Model_ID" & Environment.NewLine
                strSql &= " WHERE A.iDataSet_ID=1 AND A.ShipDate is Null AND Workstation='Waiting'" & Environment.NewLine
                strSql &= " GROUP BY OrderNo;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getShipData() As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim row As DataRow
            Dim i As Integer = 0

            Try
                strSql = "SELECT ShipCarrier_ID as 'ShipCode', ShipMethod_LDesc as 'ShipMethod'" & Environment.NewLine
                strSql &= "FROM saleorders.shipcarriers" & Environment.NewLine
                strSql &= "WHERE ShipMethod_LDesc NOT LIKE '%Ground';" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function updateShip(ByVal order As Integer, ByVal value As Integer) As Integer
            Dim strSql As String
            Dim i As Integer = 0

            Try
                strSql = "UPDATE saleorders.soheader SET PriorityExpedite = 1 where PONumber = " & order & ";" & Environment.NewLine

                i = Me._objDataProc.ExecuteNonQuery(strSql)

                If i > 0 Then
                    strSql = "UPDATE saleorders.soheader SET ShipCarrier_ID = " & value & " where PONumber = " & order & ";" & Environment.NewLine

                    Return Me._objDataProc.ExecuteNonQuery(strSql)
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getPickLocationMatrix() As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT CONCAT(a.LocRow, a.LocCol) AS 'Pick Location', b.model_Desc AS 'Model', b.model_ID AS 'Model_ID'" & Environment.NewLine
                strSql &= "FROM saleorders.tpicklocationmatrix a" & Environment.NewLine
                strSql &= "LEFT JOIN production.tmodel_items b ON a.model_ID = b.model_ID" & Environment.NewLine
                strSql &= "ORDER BY a.LocRow, a.LocCol;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        Public Function updatePickLocationMatrix(ByVal strMatrix As String, ByVal iModelID As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "UPDATE saleorders.tpicklocationmatrix " & Environment.NewLine
                strSql &= "SET model_ID = " & iModelID & Environment.NewLine
                strSql &= "WHERE CONCAT(LocRow, LocCol) = '" & strMatrix & "';" & Environment.NewLine

                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        Public Function deletePickLocationMatrix(ByVal strLocation)
            Dim strSql As String = ""

            Try
                strSql = "delete from saleorders.tpicklocationmatrix where LocationName = '" & strLocation & "';"
                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetTFFKCompletedOrders(ByVal myDate As DateTime) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT SOHeaderID AS 'OrderID', PONumber AS 'Order No', ShipDate AS 'Ship Date', OrderQty AS 'Qty'" & Environment.NewLine
                strSql &= "FROM saleorders.soheader where ShipDate is not null and ShipDate >='" & myDate.ToString("yyyy") & "-" & myDate.ToString("MM") & "-" & myDate.ToString("dd") & "' order by ShipDate;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetTFFKCompletedDetails(ByVal orderID As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                'strSql = "SELECT A.SOHeaderID AS 'OrderID', B.SODetailsID AS 'DetailsID', A.PONumber As 'Order No', B.SKU AS 'SKU', C.`Serial` AS 'Serial No'" & Environment.NewLine
                'strSql &= "FROM saleorders.soheader A" & Environment.NewLine
                'strSql &= "INNER JOIN saleorders.sodetails B ON A.SOHeaderID = B.SOHeaderID" & Environment.NewLine
                'strSql &= "INNER JOIN warehouse.warehouse_items C ON B.SODetailsID = C.SODetailsID" & Environment.NewLine
                'strSql &= "WHERE A.SOHeaderID = '" & orderID & "';" & Environment.NewLine

                strSql = "SELECT A.ponumber,A.customerAddress1,A.CustomerCity,A.CustomerState,A.CustomerCountry," & Environment.NewLine
                strSql &= " A.orderQty FROM saleorders.soheader A where A.ponumber in ('" & orderID & "');" & Environment.NewLine



                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

    End Class
End Namespace

