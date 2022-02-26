Option Explicit On 

Imports System.Data
Imports System.IO
'Imports System.Windows.Forms


Namespace Buisness

    Public Class DriveLine

        Public Const CUSTOMERID As Integer = 2546
        Public Const LOCID As Integer = 3360
        Public Const GROUPID As Integer = 112
        Private _objDataProc As DBQuery.DataProc

        Public Const RepTableName As String = "RepData"
        Public Const ProdTableName As String = "ProdData"


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


#End Region

#Region "SQL Data Functions"



        '******************************************************************
        Public Function InsertDriveLineOrderData(ByVal iCust_ID As Integer, _
                                        ByVal strClaimNo As String, _
                                        ByVal strDate As String, _
                                        ByVal strLoadedDateTime As String, _
                                        ByVal strShipTo_Name As String, _
                                        ByVal strAddress1 As String, _
                                        ByVal strAddress2 As String, _
                                        ByVal strCity As String, _
                                        ByVal strTel As String, _
                                        ByVal strZipCode As String, _
                                        ByVal strState_ShortName As String, _
                                        ByVal strRetailer As String, _
                                        ByVal strProj As String, _
                                        ByVal strRep As String, _
                                        ByVal strSourceFile As String, _
                                        ByVal iCntry_ID As Integer, _
                                        ByVal iUser_ID As Integer, _
                                        ByVal iReturnBoxYesNo As Integer, _
                                        ByVal iWO_ID As Integer) As Integer
            'Insert order data, and return primary key EW_ID
            Dim strSql As String = ""
            Dim i As Integer = 0

            Try

                strSql = "INSERT INTO Production.ExtendedWarranty " & Environment.NewLine
                strSql &= " (Cust_ID,ClaimNo,Date,LoadedDateTime,ShipTo_Name," & Environment.NewLine
                strSql &= "Address1,Address2,City,Tel,ZipCode," & Environment.NewLine
                strSql &= "State_ShortName,Retailer,Project_ID,Rep_ID,SourceFile,Cntry_ID,User_ID,ReturnBoxYesNo,WO_ID)" & Environment.NewLine
                strSql &= " VALUES ( " & iCust_ID & ",'" & strClaimNo & "','" & strDate & "','" & strLoadedDateTime & "','" & strShipTo_Name & "','" & _
                                     strAddress1 & "','" & strAddress2 & "','" & strCity & "','" & strTel & "','" & strZipCode & "','" & _
                                     strState_ShortName & "','" & strRetailer & "','" & strProj & "','" & strRep & "','" & strSourceFile & "'," & _
                                     iCntry_ID & "," & iUser_ID & "," & iReturnBoxYesNo & "," & iWO_ID & ");"

                i = Me._objDataProc.ExecuteNonQuery(strSql)
                If i = 0 Then 'failed
                    Return 0
                Else
                    strSql = "SELECT LAST_INSERT_ID();"
                    Return Me._objDataProc.GetIntValue(strSql)
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function InsertDriveLineStoreData(ByVal iEW_ID As Integer, _
                                                ByVal strStoreNo As String, _
                                                ByVal strAddress1 As String, _
                                                ByVal strAddress2 As String, _
                                                ByVal strCity As String, _
                                                ByVal strState As String, _
                                                ByVal strZipCode As String, _
                                                ByVal strRetailer As String) As Integer
            'Insert store data, and return primary key DLStore_ID
            Dim strSql As String = ""
            Dim i As Integer = 0

            Try
                strSql = "INSERT INTO production.tdriveline_stores " & Environment.NewLine
                strSql &= " (EW_ID,RetailerStoreNo,DLAddress1,DLAddress2,DLCity,DLState,DLZipCode,Retailer)" & Environment.NewLine
                strSql &= " VALUES ( " & iEW_ID & ",'" & strStoreNo & "','" & strAddress1 & "','" & strAddress2 & "','" & strCity & "','" & _
                                     strState & "','" & strZipCode & "','" & strRetailer & "');" & Environment.NewLine

                i = Me._objDataProc.ExecuteNonQuery(strSql)
                If i = 0 Then 'failed
                    Return 0
                Else
                    strSql = "SELECT LAST_INSERT_ID();"
                    Return Me._objDataProc.GetIntValue(strSql)
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function InsertDriveLineProdComponentData(ByVal iEW_ID As Integer, _
                                                        ByVal iDLStore_ID As Integer, _
                                                        ByVal strProdctName As String, _
                                                        ByVal iQty As Integer, _
                                                        ByVal strUOM As String) As Integer
            'Insert components data, and return primary key DLDetail_ID
            Dim strSql As String = ""
            Dim i As Integer = 0

            Try
                strSql = "INSERT INTO Production.tdriveline_dertails  " & Environment.NewLine
                strSql &= " (EW_ID,DLStore_ID,ProductName,Quantity,UnitOfMeasure)" & Environment.NewLine
                strSql &= " VALUES ( " & Environment.NewLine
                strSql &= iEW_ID & "," & iDLStore_ID & ",'" & strProdctName & "'," & iQty & ",'" & strUOM & "');" & Environment.NewLine

                i = Me._objDataProc.ExecuteNonQuery(strSql)
                If i = 0 Then 'failed
                    Return 0
                Else
                    strSql = "SELECT LAST_INSERT_ID();"
                    Return Me._objDataProc.GetIntValue(strSql)
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function DriveLineCheckDuplicatedOrder(ByVal strClaimNoAndWO_CustWO As String, ByVal iCust_ID As Integer, ByVal iLoc_ID As Integer) As String

            Dim strSQL1 As String = "", strSQL2 As String = ""
            Dim dt1 As DataTable, dt2 As DataTable
            Dim strMsg As String = ""

            Try
                strSQL1 = "SELECT * FROM Production.ExtendedWarranty  " & Environment.NewLine
                strSQL1 &= " WHERE ClaimNo='" & strClaimNoAndWO_CustWO & "'" & Environment.NewLine
                strSQL1 &= " AND Cust_ID=" & iCust_ID & ";"
                dt1 = Me._objDataProc.GetDataTable(strSQL1)

                strSQL2 = "SELECT * FROM Production.tWorkOrder  " & Environment.NewLine
                strSQL2 &= " WHERE WO_CustWO='" & strClaimNoAndWO_CustWO & "'" & Environment.NewLine
                strSQL2 &= " AND Loc_ID=" & iLoc_ID & ";"
                dt2 = Me._objDataProc.GetDataTable(strSQL2)


                If dt1.Rows.Count > 0 AndAlso dt2.Rows.Count > 0 Then
                    strMsg = "Found a duplicate order '" & strClaimNoAndWO_CustWO & "' in tables 'Production.tWorkOrder' and 'Production.ExtendedWarranty'."
                ElseIf dt1.Rows.Count > 0 Then
                    strMsg = "Found a duplicate order '" & strClaimNoAndWO_CustWO & "' in table 'Production.ExtendedWarranty'."
                ElseIf dt2.Rows.Count > 0 Then
                    strMsg = "Found a duplicate order '" & strClaimNoAndWO_CustWO & "' in table 'Production.tWorkOrder'."
                End If

                Return strMsg

            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '******************************************************************
        Public Function UpdateDriveLineWorkOrderQty(ByVal iWO_ID As Integer, ByVal iQty As Integer) As Integer

            Dim strSql As String = ""

            Try

                strSql = "Update production.tWorkorder set WO_RAQnty = " & iQty & " WHERE WO_ID=" & iWO_ID & ";"

                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function FoundOrderExist(ByVal strClaimNo As String) As Boolean

            Dim strSql As String = ""
            Dim dt As DataTable

            Try

                strSql = "SELECT * FROM ExtendedWarranty " & Environment.NewLine
                strSql &= " WHERE ClaimNo='" & strClaimNo & "';" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function CreateAndGetWorkOrder(ByVal WOCustWOStr As String, ByVal LocID As Integer, _
                                                 ByVal GroupID As Integer, ByVal iClose As Integer, ByVal iWO_Quantity As Integer) As Integer
            Try
                Dim strSQL As String = String.Empty
                Dim i As Integer = 0

                WOCustWOStr = WOCustWOStr.Replace("'", "''")

                strSQL = "INSERT INTO tWorkOrder " & Environment.NewLine
                strSQL &= " (WO_CustWO,WO_Date,Loc_ID,Group_ID,WO_Closed,WO_CameWithFile,WO_RAQnty)" & Environment.NewLine
                strSQL &= " VALUES ( " & Environment.NewLine
                strSQL &= "'" & WOCustWOStr & "'," & Environment.NewLine
                strSQL &= "now()," & Environment.NewLine
                strSQL &= LocID & "," & Environment.NewLine
                strSQL &= GroupID & "," & Environment.NewLine
                strSQL &= iClose & "," & Environment.NewLine
                strSQL &= "1," & iWO_Quantity & ");" & Environment.NewLine

                i = Me._objDataProc.ExecuteNonQuery(strSQL)

                If i = 0 Then 'failed 
                    Return 0
                Else
                    strSQL = "SELECT LAST_INSERT_ID();"
                    Return Me._objDataProc.GetIntValue(strSQL)
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '******************************************************************
        'Private Function GetCorrectStr(ByVal strS As String) As String
        '    Dim strTmp As String = "''"
        '    If strS.Trim.Length > 0 Then
        '        strTmp = "'" & strS.Trim.Replace("'", "''") & "'"
        '    End If
        '    Return strTmp
        'End Function

        '******************************************************************
        Public Function GetRetailersData() As DataTable

            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT * from tdriveline_retailers order by RetailerName1;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '******************************************************************
        Public Function GetDriveLineOpenOrders() As DataTable

            Dim strSQL As String = ""
            Dim dt As DataTable

            Try
                'strSQL = "SELECT b.ClaimNo AS OrderName,b.Retailer,b.Project_ID,b.Rep_ID,b.ShipTo_Name," & Environment.NewLine
                strSQL = "SELECT b.ClaimNo AS OrderName,b.Project_ID,b.Rep_ID,b.ShipTo_Name," & Environment.NewLine
                strSQL &= "CONCAT(CASE WHEN length(Trim(b.Address1))>0 THEN b.Address1 ELSE '' END," & Environment.NewLine
                strSQL &= "       CASE WHEN length(Trim(b.Address2))>0 THEN CONCAT(', ', b.Address2) ELSE '' END)" & Environment.NewLine
                strSQL &= "AS Address,b.City,b.ZipCode,b.State_ShortName AS State,0 AS ShipDays,b.Tel AS Phone,DATE_FORMAT(b.LoadedDateTime ,'%m/%d/%Y') AS OrderDate," & Environment.NewLine
                strSQL &= "b.EW_ID,a.WO_ID,a.WO_RAQnty,a.WO_Closed,b.Cust_ID,c.Cust_Name1 AS Customer,a.Loc_ID" & Environment.NewLine
                strSQL &= " FROM production.tworkorder a" & Environment.NewLine
                strSQL &= " INNER JOIN production.extendedwarranty b ON a.wo_ID=b.WO_ID" & Environment.NewLine
                strSQL &= " INNER JOIN production.tcustomer c ON b.Cust_ID=c.Cust_ID" & Environment.NewLine
                strSQL &= " WHERE a.loc_ID=3360 AND b.cust_ID=2546 AND a.WO_DateShip IS Null AND a.WO_Closed=0" & Environment.NewLine
                strSQL &= " ORDER BY b.ClaimNo;"

                dt = Me._objDataProc.GetDataTable(strSQL)

                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetFedExShipDays() As DataTable
            'Use AIG FedExShip Days-------------------------------------------

            Dim strSQL As String = ""
            Dim dt As DataTable

            Try
                strSQL = "SELECT A.ShipDays,B.State_Short,B.State_Long, A.State_ID" & Environment.NewLine
                strSQL &= " FROM lpssishipdays A" & Environment.NewLine
                strSQL &= " INNER JOIN lstate B ON A.State_ID=B.State_ID" & Environment.NewLine
                strSQL &= " WHERE A.Cust_ID=" & PSS.Data.Buisness.AIG.CUSTOMERID & ";" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSQL)

                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetDriveLineClosedOrder(ByVal strWO_CustWO As String) As DataTable

            Dim strSQL As String = ""
            Dim dt As DataTable
            strWO_CustWO = strWO_CustWO.Replace("'", "''")

            Try
                strSQL = "SELECT b.ClaimNo AS OrderName,b.Retailer,b.Project_ID,b.Rep_ID,a.WO_DateShip,b.ShipTo_Name," & Environment.NewLine
                strSQL &= "CONCAT(CASE WHEN length(Trim(b.Address1))>0 THEN b.Address1 ELSE '' END," & Environment.NewLine
                strSQL &= "       CASE WHEN length(Trim(b.Address2))>0 THEN CONCAT(', ', b.Address2) ELSE '' END)" & Environment.NewLine
                strSQL &= "AS Address,b.City,b.ZipCode,b.State_ShortName AS State,b.Tel AS Phone,DATE_FORMAT(b.LoadedDateTime ,'%m/%d/%Y') AS OrderDate," & Environment.NewLine
                strSQL &= "b.EW_ID,a.WO_ID,a.WO_RAQnty,a.WO_Closed,b.Cust_ID,c.Cust_Name1 AS Customer,a.Loc_ID" & Environment.NewLine
                strSQL &= " FROM production.tworkorder a" & Environment.NewLine
                strSQL &= " INNER JOIN production.extendedwarranty b ON a.wo_ID=b.WO_ID" & Environment.NewLine
                strSQL &= " INNER JOIN production.tcustomer c ON b.Cust_ID=c.Cust_ID" & Environment.NewLine
                strSQL &= " WHERE a.WO_CustWO='" & strWO_CustWO & "' AND a.loc_ID=3360 AND b.cust_ID=2546 AND a.WO_DateShip IS Not Null AND a.WO_Closed=1;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSQL)

                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetDriveLineClosedOrder_ProjectIDs() As DataTable

            Dim strSQL As String = ""
            Dim dt As DataTable

            Try
                strSQL = "SELECT DISTINCT b.Project_ID" & Environment.NewLine
                strSQL &= " FROM production.tworkorder a" & Environment.NewLine
                strSQL &= " INNER JOIN production.extendedwarranty b ON a.wo_ID=b.WO_ID" & Environment.NewLine
                strSQL &= " INNER JOIN production.tcustomer c ON b.Cust_ID=c.Cust_ID" & Environment.NewLine
                strSQL &= " WHERE a.loc_ID=3360 AND b.cust_ID=2546 AND a.WO_DateShip IS Not Null AND a.WO_Closed=1" & Environment.NewLine
                strSQL &= " ORDER BY a.WO_DateShip desc,b.Project_ID;" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSQL)

                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '******************************************************************
        Public Function GetDriveLine_ProjectIDs(ByVal booAddSelectedRow As Boolean) As DataTable

            Dim strSQL As String = ""
            Dim dt As DataTable

            Try
                strSQL = "select distinct Project_ID from extendedwarranty" & Environment.NewLine
                strSQL &= " where cust_ID=" & CUSTOMERID & "  and Project_ID is not null  and length(trim(Project_ID)) >0" & Environment.NewLine
                strSQL &= " order by LoadedDateTime desc;"

                dt = Me._objDataProc.GetDataTable(strSQL)

                If booAddSelectedRow Then dt.LoadDataRow(New Object() {"--Select--"}, True)

                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetDriveLine_ProductComponentNames(ByVal StrProjectID As String) As DataTable

            Dim strSQL As String = ""
            Dim dt As DataTable

            Try
                strSQL &= "select distinct A.ProductName" & Environment.NewLine
                strSQL &= " FROM tdriveline_dertails A" & Environment.NewLine
                strSQL &= " Left Join extendedwarranty B on A.EW_ID=B.EW_ID" & Environment.NewLine
                strSQL &= " Where B.cust_ID=" & CUSTOMERID & " and B.project_ID='" & StrProjectID & "'" & Environment.NewLine
                strSQL &= " ORDER BY A.ProductName;"

                dt = Me._objDataProc.GetDataTable(strSQL)

                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '******************************************************************
        Public Function GetDriveLine_StockLocationHasDefined(ByVal StrProjectID As String) As Boolean

            Dim strSQL As String = ""
            Dim dt As DataTable
            Dim bRes As Boolean = False

            Try
                strSQL &= "SELECT * FROM tdriveline_bin where Project_ID='" & StrProjectID & "';" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSQL)
                If dt.Rows.Count > 0 Then
                    bRes = True
                End If

                Return bRes

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetDriveLineClosedOrder_ByProjectID(ByVal strProjectID As String) As DataTable

            Dim strSQL As String = ""
            Dim dt As DataTable
            strProjectID = strProjectID.Replace("'", "''")

            Try
                'strSQL = "SELECT '' AS CloseTime,b.ClaimNo AS OrderName,b.Retailer,b.Project_ID,b.Rep_ID,a.WO_DateShip,b.ShipTo_Name," & Environment.NewLine
                'strSQL = "SELECT '' AS CloseTime,b.ClaimNo AS OrderName,b.Project_ID,b.Rep_ID,a.WO_DateShip,b.ShipTo_Name," & Environment.NewLine
                strSQL = "SELECT b.ClaimNo AS OrderName,b.Project_ID,b.Rep_ID,a.WO_DateShip,b.ShipTo_Name," & Environment.NewLine
                strSQL &= "CONCAT(CASE WHEN length(Trim(b.Address1))>0 THEN b.Address1 ELSE '' END," & Environment.NewLine
                strSQL &= "       CASE WHEN length(Trim(b.Address2))>0 THEN CONCAT(', ', b.Address2) ELSE '' END)" & Environment.NewLine
                strSQL &= "AS Address,b.City,b.ZipCode,b.State_ShortName AS State,b.Tel AS Phone,DATE_FORMAT(b.LoadedDateTime ,'%m/%d/%Y') AS OrderDate," & Environment.NewLine
                strSQL &= "b.EW_ID,a.WO_ID,a.WO_RAQnty,a.WO_Closed,b.Cust_ID,c.Cust_Name1 AS Customer,a.Loc_ID" & Environment.NewLine
                strSQL &= " FROM production.tworkorder a" & Environment.NewLine
                strSQL &= " INNER JOIN production.extendedwarranty b ON a.wo_ID=b.WO_ID" & Environment.NewLine
                strSQL &= " INNER JOIN production.tcustomer c ON b.Cust_ID=c.Cust_ID" & Environment.NewLine
                strSQL &= " WHERE b.Project_ID='" & strProjectID & "' AND a.loc_ID=3360 AND b.cust_ID=2546 AND a.WO_DateShip IS Not Null AND a.WO_Closed=1;" & Environment.NewLine


                dt = Me._objDataProc.GetDataTable(strSQL)

                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetDriveLineClosedTime(ByVal iEW_ID As Integer) As DataTable

            Dim strSQL As String = ""
            Dim dt As DataTable

            Try
                strSQL = " select Max(ShipDateTime) as CloseTime from production.tdriveline_dertails WHERE EW_ID =" & iEW_ID & ";" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSQL)

                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '******************************************************************
        Public Function GetDriveLineOrderDetails(ByVal iEW_ID As Integer, ByVal strProjectID As String, Optional ByVal bDataAfterOrderClosed As Boolean = False) As DataTable

            Dim strSQL As String = ""
            Dim dt As DataTable

            Try
                'If bDataAfterOrderClosed Then
                '    strSQL = "SELECT 1 as RowID,'Yes' as Print,a.Retailer,a.RetailerStoreNo AS StoreNo,b.ProductName AS Component ,b.Quantity AS OrderQty, b.ShipQuantity AS ShipQty, b.UnitOfMeasure AS UOM," & Environment.NewLine
                'Else
                '    'strSQL = "SELECT 1 as RowID,a.RetailerStoreNo AS StoreNo,b.ProductName AS Component ,b.Quantity AS OrderQty, 0 AS ShipQty, b.UnitOfMeasure AS UOM," & Environment.NewLine
                '    strSQL = "SELECT 1 as RowID,a.Retailer,a.RetailerStoreNo AS StoreNo,b.ProductName AS Component ,b.Quantity AS OrderQty, b.Quantity AS ShipQty, b.UnitOfMeasure AS UOM," & Environment.NewLine
                'End If

                'strSQL &= "CONCAT(CASE WHEN length(Trim(a.DLAddress1))>0 THEN a.DLAddress1 ELSE '' END," & Environment.NewLine
                'strSQL &= "       CASE WHEN length(Trim(a.DLAddress2))>0 THEN CONCAT(', ', a.DLAddress2) ELSE '' END)" & Environment.NewLine
                'strSQL &= "AS Address,a.DLCity AS City,a.DLState AS State,a.DLZipCode AS ZipCode,b.DLStore_ID,a.EW_ID,b.DLDetail_ID" & Environment.NewLine
                'strSQL &= " FROM production.tdriveline_stores a" & Environment.NewLine
                'strSQL &= " INNER JOIN production.tdriveline_dertails b ON a.EW_ID=b.EW_ID AND a.DLStore_ID=b.DLStore_ID" & Environment.NewLine
                'strSQL &= " WHERE a.EW_ID=" & iEW_ID & Environment.NewLine
                'strSQL &= " ORDER BY a.RetailerStoreNo,b.ProductName"

                If bDataAfterOrderClosed Then
                    strSQL = "SELECT 1 as RowID,'Yes' as Print,a.Retailer,a.RetailerStoreNo AS StoreNo,b.ProductName AS Component ,b.Quantity AS OrderQty, b.ShipQuantity AS ShipQty, 0 AS Bin, b.UnitOfMeasure AS UOM," & Environment.NewLine
                Else
                    strSQL = "SELECT 1 as RowID,a.Retailer,a.RetailerStoreNo AS StoreNo,b.ProductName AS Component ,b.Quantity AS OrderQty, b.Quantity AS ShipQty, 0 AS Bin, b.UnitOfMeasure AS UOM," & Environment.NewLine
                End If
                strSQL &= "CONCAT(CASE WHEN length(Trim(a.DLAddress1))>0 THEN a.DLAddress1 ELSE '' END," & Environment.NewLine
                strSQL &= "       CASE WHEN length(Trim(a.DLAddress2))>0 THEN CONCAT(', ', a.DLAddress2) ELSE '' END)" & Environment.NewLine
                strSQL &= "AS Address,a.DLCity AS City,a.DLState AS State,a.DLZipCode AS ZipCode,b.DLStore_ID,a.EW_ID,b.DLDetail_ID" & Environment.NewLine
                strSQL &= " FROM production.tdriveline_stores a" & Environment.NewLine
                strSQL &= " INNER JOIN production.tdriveline_dertails b ON a.EW_ID=b.EW_ID AND a.DLStore_ID=b.DLStore_ID" & Environment.NewLine
                strSQL &= " WHERE a.EW_ID=" & iEW_ID & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSQL)

                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function UpdateAndCloseWorkOrder(ByVal iWO_ID As Integer, ByVal iLoc_ID As Integer, _
                                                ByVal iWO_Quantity As Integer, ByVal strShipDate As String) As Integer
            Try
                Dim strSQL As String = String.Empty

                strSQL = "UPDATE production.tWorkOrder " & Environment.NewLine
                strSQL &= " SET WO_Shipped=1,WO_Closed=1, WO_DateShip='" & strShipDate & "'," & _
                          "WO_Quantity=" & iWO_Quantity & _
                          " WHERE Loc_ID=" & iLoc_ID & " AND WO_ID=" & iWO_ID
                Return Me._objDataProc.ExecuteNonQuery(strSQL)

            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '******************************************************************
        Public Function UpdateAndCloseWorkOrder_Components(ByVal iDLDetail_ID As Integer, _
                                                           ByVal iShipQty As Integer, _
                                                           ByVal iShipUserID As Integer, _
                                                           ByVal strShipDateTime As String) As Integer
            Try
                Dim strSQL As String = String.Empty

                strSQL = "UPDATE production.tdriveline_dertails " & Environment.NewLine
                strSQL &= " SET ShipQuantity=" & iShipQty & ", ShipUserID=" & iShipUserID & _
                          ",ShipDateTime='" & strShipDateTime & "'" & _
                          " WHERE DLDetail_ID=" & iDLDetail_ID

                Return Me._objDataProc.ExecuteNonQuery(strSQL)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function InsertDriveLineOrderData_Discrepancy(ByVal iCust_ID As Integer, _
                                                             ByVal strOrderName As String, _
                                                             ByVal strProj As String, _
                                                             ByVal strRep As String, _
                                                             ByVal strShipTo_Name As String, _
                                                             ByVal strAddress1 As String, _
                                                             ByVal strAddress2 As String, _
                                                             ByVal strCity As String, _
                                                             ByVal strStateName As String, _
                                                             ByVal strZipCode As String, _
                                                             ByVal strTel As String, _
                                                             ByVal strSourceFile As String, _
                                                             ByVal strLoadedDateTime As String, _
                                                             ByVal iUser_ID As Integer, _
                                                             ByVal iDiscrepancyStatus As Integer) As Integer

            Dim strSql As String = ""
            Dim i As Integer = 0

            Try

                strSql = "INSERT INTO Production.tDriveLine_DiscRep " & Environment.NewLine
                strSql &= " (Cust_ID,OrderName,Project_ID,Rep_ID," & Environment.NewLine
                strSql &= "ShipTo_Name,Address1,Address2,City,StateName," & Environment.NewLine
                strSql &= "ZipCode,Tel,SourceFile,LoadedDateTime,User_ID,DiscrenpcyStatus)" & Environment.NewLine
                strSql &= " VALUES ( " & iCust_ID & ",'" & strOrderName & "','" & strProj & "','" & strRep & "','" & _
                                     strShipTo_Name & "','" & strAddress1 & "','" & strAddress2 & "','" & strCity & "','" & strStateName & "','" & _
                                     strZipCode & "','" & strTel & "','" & strSourceFile & "','" & strLoadedDateTime & "'," & _
                                     iUser_ID & "," & iDiscrepancyStatus & ");"

                i = Me._objDataProc.ExecuteNonQuery(strSql)
                If i = 0 Then 'failed
                    Return 0
                Else
                    strSql = "SELECT LAST_INSERT_ID();"
                    Return Me._objDataProc.GetIntValue(strSql)
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function InsertDriveLineStoreData_Discrepancy(ByVal iDR_ID As Integer, _
                                                             ByVal strStoreNo As String, _
                                                             ByVal strDRAddress1 As String, _
                                                             ByVal strDRAddress2 As String, _
                                                             ByVal strDRCity As String, _
                                                             ByVal strDRStateName As String, _
                                                             ByVal strDRZipCode As String, _
                                                             ByVal strRetailer As String) As Integer

            Dim strSql As String = ""
            Dim i As Integer = 0

            Try

                strSql = "INSERT INTO Production.tDriveLine_DiscStores " & Environment.NewLine
                strSql &= " (DR_ID,RetailerStoreNo,DRAddress1,DRAddress2,DRCity,DRState,DRZipCode, Retailer)" & Environment.NewLine
                strSql &= " VALUES ( " & iDR_ID & ",'" & strStoreNo & "','" & strDRAddress1 & "','" & strDRAddress2 & "','" & strDRCity & "','" & strDRStateName & "','" & _
                                     strDRZipCode & "','" & strRetailer & "');"

                i = Me._objDataProc.ExecuteNonQuery(strSql)
                If i = 0 Then 'failed
                    Return 0
                Else
                    strSql = "SELECT LAST_INSERT_ID();"
                    Return Me._objDataProc.GetIntValue(strSql)
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function InsertDriveLineProdComponentData_Discrepancy(ByVal iDR_ID As Integer, _
                                                                     ByVal iDRStore_ID As Integer, _
                                                                     ByVal strProdctName As String, _
                                                                     ByVal iQty As Integer, _
                                                                     ByVal strLoadDateTime As String) As Integer

            Dim strSql As String = ""
            Dim i As Integer = 0

            Try
                strSql = "INSERT INTO Production.tDriveLine_DiscDetails  " & Environment.NewLine
                strSql &= " (DR_ID,DRStore_ID,ProductName,Quantity,LoadDateTime)" & Environment.NewLine
                strSql &= " VALUES ( " & Environment.NewLine
                strSql &= iDR_ID & "," & iDRStore_ID & ",'" & strProdctName & "'," & iQty & ",'" & strLoadDateTime & "');" & Environment.NewLine

                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function ClearUpDemoData() As Integer

            Try
                Dim strSQL As String = String.Empty
                Dim i As Integer = 0

                strSQL = "delete FROM tdriveline_stores;"
                i = Me._objDataProc.ExecuteNonQuery(strSQL)

                strSQL = "delete FROM tdriveline_dertails;"
                i += Me._objDataProc.ExecuteNonQuery(strSQL)

                strSQL = "delete from tworkorder where wo_ID> 10669824-10 and loc_ID=3360;"
                i += Me._objDataProc.ExecuteNonQuery(strSQL)

                strSQL = "delete from extendedwarranty where ew_ID >15091-10 and cust_ID=2546;"
                i += Me._objDataProc.ExecuteNonQuery(strSQL)

                strSQL = "delete from tDriveLine_DiscRep;"
                i += Me._objDataProc.ExecuteNonQuery(strSQL)

                strSQL = "delete from tDriveLine_DiscStores;"
                i += Me._objDataProc.ExecuteNonQuery(strSQL)

                strSQL = "delete from tDriveLine_DiscDetails;"
                i += Me._objDataProc.ExecuteNonQuery(strSQL)

                Return i

            Catch ex As Exception
                Throw ex
            End Try

        End Function

#End Region

        Public Function LoadExcelData(ByVal strExcelPathFile As String, _
                                      ByVal arrProdComponentNames As ArrayList, _
                                      ByRef strErrMsg_Rep As String, _
                                      ByRef strErrMsg_Prod As String) As DataSet
            'Rep Data must be in Excel Sheet 1; Product Component Data must be in Excel Sheet 2
            'First row has header names

            Dim HeaderNames_Rep As ArrayList = RepData_GetHeaderNames()
            Dim HeaderNames_Prod As ArrayList = ProdComponentData_GetHeaderNames()
            Dim HeaderNamesColIndex_Rep As New ArrayList(), HeaderNamesColIndex_Prod As New ArrayList()
            Dim arrProdComponentNames_NewCols As New ArrayList()
            Dim dt_Rep As DataTable = RepData_ExcelTableDefinition()
            Dim dt_Prod As DataTable = ProdComponentData_ExcelTableDefinition()
            Dim row As DataRow
            Dim dtSet As New DataSet()

            Dim UsedRowsNum1 As Integer = 0, UsedColsNum1 As Integer = 0
            Dim UsedRowsNum2 As Integer = 0, UsedColsNum2 As Integer = 0
            Dim i As Integer = 0, j As Integer = 0, k As Integer = 0, myIndex As Integer
            Dim strColName As String = ""
            Dim strHeaderNameNotFound_Rep As String = "", strHeaderNameNotFound_Prod As String = ""
            Dim strUID As String = "", strTmp As String = "", objV As Object
            Dim tmpArr As New ArrayList()

            Dim xlApp As New Excel.Application()
            Dim xlWorkBook As Excel.Workbook = Nothing
            Dim xlWorkSheet1 As Excel.Worksheet = Nothing
            Dim xlWorkSheet2 As Excel.Worksheet = Nothing

            Try
                strErrMsg_Rep = "" : strErrMsg_Prod = ""
                If File.Exists(strExcelPathFile) Then
                    xlWorkBook = xlApp.Workbooks.Open(strExcelPathFile)

                    xlWorkSheet1 = xlWorkBook.Worksheets(1)
                    xlWorkSheet1.Select()
                    UsedRowsNum1 = xlWorkBook.ActiveSheet.UsedRange.Rows.Count()
                    UsedColsNum1 = xlWorkBook.ActiveSheet.UsedRange.Columns.Count()
                    'For i = 1 To UsedRowsNum1
                    '    objV = xlWorkSheet1.Cells(i, 1).value
                    '    If objV Is Nothing Then
                    '        UsedRowsNum1 = i - 1 : Exit For
                    '    Else
                    '        strTmp = objV
                    '        If Not strTmp.Trim.Length > 0 Then
                    '            UsedRowsNum1 = i - 1 : Exit For
                    '        End If
                    '    End If
                    'Next
                    'Alternative works
                    'For i = 1 To UsedRowsNum1
                    '    If Microsoft.VisualBasic.IsDBNull(xlWorkSheet1.Cells(i, 1).value) Then '.Range("A" & i).Value
                    '        Exit For
                    '    ElseIf Microsoft.VisualBasic.IsNothing(xlWorkSheet1.Cells(i, 1).value) Then
                    '        Exit For
                    '    ElseIf xlWorkSheet1.Cells(i, 1).value Is "" Or xlWorkSheet1.Cells(i, 1).value Is Nothing Then
                    '        Exit For
                    '    Else
                    '        strTmp = xlWorkSheet1.Cells(i, 1).value
                    '        If strTmp.Trim.Length > 0 Then
                    '            UsedRowsNum1 = i
                    '        Else
                    '            Exit For
                    '        End If
                    '    End If
                    'Next
                    ' MessageBox.Show("UsedRowsNum1=" & UsedRowsNum1)

                    'Get colmun number until empty cell (first row, col)
                    Try
                        For j = 1 To UsedColsNum1
                            objV = xlWorkSheet1.Cells(1, j).value
                            If objV Is Nothing Then
                                UsedColsNum1 = j - 1 : Exit For 'if empty, stop
                            End If
                            strTmp = xlWorkSheet1.Cells(1, j).value
                            If Not strTmp.Trim.Length > 0 Then
                                UsedColsNum1 = j - 1 : Exit For 'if spaces, stop
                            End If
                        Next
                    Catch ex As Exception
                    End Try
                    'MessageBox.Show("UsedRowsNum =" & UsedRowsNum & "   UsedColsNum=" & UsedColsNum)

                    '1. Validate header names: Rep----------------------------------------------------
                    If UsedRowsNum1 > 0 AndAlso UsedColsNum1 > 0 Then
                        For j = 1 To UsedColsNum1 'get header names
                            strColName = xlWorkSheet1.Cells(1, j).value
                            tmpArr.Add(strColName.Trim.ToUpper)
                        Next 'j
                        For i = 0 To HeaderNames_Rep.Count - 1 'Check 
                            strColName = HeaderNames_Rep(i)
                            If tmpArr.Contains(strColName) Then  'True
                                myIndex = tmpArr.IndexOf(strColName)
                                HeaderNamesColIndex_Rep.Add(myIndex)
                            Else 'False
                                If strHeaderNameNotFound_Rep.Trim.Length > 0 Then
                                    strHeaderNameNotFound_Rep &= "," & strColName
                                Else
                                    strHeaderNameNotFound_Rep &= strColName
                                End If
                            End If
                        Next
                    Else
                        strHeaderNameNotFound_Rep = "Sheet 1 has no enough header data!" & Environment.NewLine
                    End If

                    xlWorkSheet2 = xlWorkBook.Worksheets(2)
                    xlWorkSheet2.Select()
                    UsedRowsNum2 = xlWorkBook.ActiveSheet.UsedRange.Rows.Count()
                    UsedColsNum2 = xlWorkBook.ActiveSheet.UsedRange.Columns.Count()

                    'Get colmun number until empty cell (first row, col)
                    Try
                        For j = 1 To UsedColsNum2
                            objV = xlWorkSheet2.Cells(1, j).value
                            If objV Is Nothing Then UsedColsNum2 = j - 1 : Exit For 'if empty, stop
                            strTmp = xlWorkSheet2.Cells(1, j).value
                            If Not strTmp.Trim.Length > 0 Then UsedColsNum2 = j - 1 : Exit For 'if spaces, stop
                        Next
                    Catch ex As Exception
                    End Try

                    '2. Validate header names: Prod------------------------------------------------------
                    If UsedRowsNum2 > 0 AndAlso UsedColsNum2 >= HeaderNames_Prod.Count + 1 Then 'at least 1 product component
                        tmpArr.Clear()
                        For j = 1 To HeaderNames_Prod.Count 'get header names for store,address i
                            strColName = xlWorkSheet2.Cells(1, j).value
                            tmpArr.Add(strColName.Trim.ToUpper)
                        Next 'j
                        For i = 0 To HeaderNames_Prod.Count - 1 'Check required header names
                            strColName = HeaderNames_Prod(i)
                            If tmpArr.Contains(strColName) Then  'True
                                myIndex = tmpArr.IndexOf(strColName)
                                HeaderNamesColIndex_Prod.Add(myIndex)
                            Else 'False
                                If strHeaderNameNotFound_Prod.Trim.Length > 0 Then
                                    strHeaderNameNotFound_Prod &= "," & strColName
                                Else
                                    strHeaderNameNotFound_Prod &= strColName
                                End If
                            End If
                        Next
                        For j = HeaderNames_Prod.Count + 1 To UsedColsNum2 'get header names for prod components
                            strColName = xlWorkSheet2.Cells(1, j).value
                            arrProdComponentNames.Add(strColName)
                            HeaderNamesColIndex_Prod.Add(j)
                        Next 'j

                    Else
                        strHeaderNameNotFound_Prod = "Sheet 2 has no enough header data!" & Environment.NewLine
                    End If


                    '3. Load Rep Data---------------------------------------------------------------------------------------------
                    If strHeaderNameNotFound_Rep.Trim.Length > 0 Then
                        'MessageBox.Show("Can't find header column name:" & strHeaderNameNotFound & " in the first row of the Excel file")
                        strErrMsg_Rep = "Can't find header column name:" & strHeaderNameNotFound_Rep & " in the first row of the Excel Work Sheet 1" & Environment.NewLine
                    ElseIf HeaderNames_Rep.Count <> HeaderNamesColIndex_Rep.Count Then
                        'MessageBox.Show("Header column name problem. Make sure your Excel file has correct format!")
                        strErrMsg_Rep = "Header column name problem. Make sure your Excel file has correct format!" & Environment.NewLine
                    Else
                        'Load Excdel data into datatable
                        For i = 2 To UsedRowsNum1 'go through each row of the Excelsheet
                            row = dt_Rep.NewRow()
                            For k = 0 To HeaderNames_Rep.Count - 1 'each column
                                strColName = HeaderNames_Rep(k)
                                j = HeaderNamesColIndex_Rep(k) + 1
                                row(strColName) = xlWorkSheet1.Cells(i, j).value
                            Next
                            Try 'stop if empty row 
                                objV = xlWorkSheet1.Cells(i, 1).value 'each row for col 1
                                If objV Is Nothing Then Exit For 'if empty, stop
                                strTmp = xlWorkSheet1.Cells(i, 1).value
                                If Not strTmp.Trim.Length > 0 Then Exit For 'if spaces, stop
                            Catch ex As Exception
                            End Try
                            row("RawRecID") = i - 1
                            dt_Rep.Rows.Add(row)
                        Next
                        If dt_Rep.Rows.Count > 0 Then
                            dt_Rep.TableName = RepTableName
                            dtSet.Tables.Add(dt_Rep)
                        End If
                    End If

                    '4. Load Prod Data---------------------------------------------------------------------------------------------
                    If strHeaderNameNotFound_Prod.Trim.Length > 0 Then
                        'MessageBox.Show("Can't find header column name:" & strHeaderNameNotFound & " in the first row of the Excel file")
                        strErrMsg_Prod = "Can't find header column name:" & strHeaderNameNotFound_Prod & " in the first row of the Excel Work Sheet 2" & Environment.NewLine
                    ElseIf HeaderNames_Prod.Count + arrProdComponentNames.Count <> HeaderNamesColIndex_Prod.Count Then
                        'MessageBox.Show("Header column name problem. Make sure your Excel file has correct format!")
                        strErrMsg_Prod = "Header column name problem. Make sure your Excel file has correct format!" & Environment.NewLine
                    Else
                        'Modify table dt_Prod by adding prod component data
                        For i = 0 To arrProdComponentNames.Count - 1
                            Dim newColumn As New DataColumn("CP" & i + 1, GetType(Integer))
                            ' newColumn.DefaultValue = "Your DropDownList value"
                            dt_Prod.Columns.Add(newColumn)
                            arrProdComponentNames_NewCols.Add("CP" & i + 1)
                        Next

                        'Load Excdel data into datatable
                        For i = 2 To UsedRowsNum2 'go through each row of the Excelsheet
                            Try
                                objV = xlWorkSheet2.Cells(i, 1).value 'each row for col 1
                                If objV Is Nothing Then Exit For 'if empty, stop
                                strTmp = xlWorkSheet2.Cells(i, 1).value
                                If Not strTmp.Trim.Length > 0 Then Exit For 'if spaces, stop
                            Catch ex As Exception
                            End Try
                            row = dt_Prod.NewRow()
                            For k = 0 To HeaderNames_Prod.Count - 1 'for basic store, address data
                                strColName = HeaderNames_Prod(k)
                                j = HeaderNamesColIndex_Prod(k) + 1
                                row(strColName) = xlWorkSheet2.Cells(i, j).value
                            Next
                            k = 0
                            For j = HeaderNames_Prod.Count + 1 To HeaderNames_Prod.Count + arrProdComponentNames.Count 'for prod Component data
                                strColName = arrProdComponentNames_NewCols(k)
                                k += 1
                                Try
                                    If IsNumeric(xlWorkSheet2.Cells(i, j).value) Then
                                        row(strColName) = xlWorkSheet2.Cells(i, j).value 'Just use j. No need to use this to get col index:  HeaderNamesColIndex_Prod
                                    End If
                                Catch ex As Exception
                                End Try
                            Next
                            row("RawRecID") = i - 1
                            dt_Prod.Rows.Add(row)
                        Next
                        If dt_Prod.Rows.Count > 0 Then
                            dt_Prod.TableName = ProdTableName
                            dtSet.Tables.Add(dt_Prod)
                        End If
                    End If

                    If Not IsNothing(xlWorkSheet1) Then
                        PSS.Data.Buisness.Generic.NAR(xlWorkSheet1)
                    End If
                    If Not IsNothing(xlWorkSheet2) Then
                        PSS.Data.Buisness.Generic.NAR(xlWorkSheet2)
                    End If
                    If Not IsNothing(xlWorkBook) Then
                        xlWorkBook.Close(False)
                        PSS.Data.Buisness.Generic.NAR(xlWorkBook)
                    End If
                    If Not IsNothing(xlApp) Then
                        xlApp.Quit()
                        PSS.Data.Buisness.Generic.NAR(xlApp)
                    End If

                    Return dtSet

                End If

            Catch ex As Exception
                strErrMsg_Rep = "Function LoadExcelData: " & ex.ToString
                dt_Rep = Nothing : dt_Prod = Nothing
                Return dtSet
            Finally
                dt_Rep = Nothing : dt_Prod = Nothing
                If Not IsNothing(xlWorkSheet1) Then
                    PSS.Data.Buisness.Generic.NAR(xlWorkSheet1)
                End If
                If Not IsNothing(xlWorkSheet2) Then
                    PSS.Data.Buisness.Generic.NAR(xlWorkSheet2)
                End If
                If Not IsNothing(xlWorkBook) Then
                    xlWorkBook.Close(False)
                    PSS.Data.Buisness.Generic.NAR(xlWorkBook)
                End If
                If Not IsNothing(xlApp) Then
                    xlApp.Quit()
                    PSS.Data.Buisness.Generic.NAR(xlApp)
                End If
            End Try

        End Function


        '******************************************************************
        Public Function RepData_ExcelTableDefinition() As DataTable
            Dim dTB As New DataTable()
            Dim row As DataRow
            dTB.Columns.Add("RawRecID", GetType(Integer))
            dTB.Columns.Add("RETAILER ID", GetType(String))
            dTB.Columns.Add("PROJECT", GetType(String))
            dTB.Columns.Add("REPI", GetType(String))
            dTB.Columns.Add("STORE NO", GetType(String))
            dTB.Columns.Add("REP FIRST NAME", GetType(String))
            dTB.Columns.Add("REP LAST NAME", GetType(String))
            dTB.Columns.Add("REP ADDRESS", GetType(String))
            dTB.Columns.Add("REP ADDRESS 2", GetType(String))
            dTB.Columns.Add("REP CITY", GetType(String))
            dTB.Columns.Add("REP STATE", GetType(String))
            dTB.Columns.Add("REP ZIP", GetType(String))
            dTB.Columns.Add("REP PHONE", GetType(String))

            Return dTB
        End Function

        '******************************************************************
        Public Function RepData_GetHeaderNames() As ArrayList
            Dim arrNames As New ArrayList()
            Dim tmpDT As DataTable = RepData_ExcelTableDefinition()
            Dim i As Integer = 0, tmpS As String = ""

            Try
                For i = 0 To tmpDT.Columns.Count - 1
                    tmpS = tmpDT.Columns(i).ColumnName.ToUpper.Trim
                    If tmpS <> "RawRecID".ToUpper Then
                        arrNames.Add(tmpS)
                    End If
                Next
                tmpDT = Nothing

                Return arrNames

            Catch ex As Exception
                Throw ex
            End Try

        End Function

        '******************************************************************
        Public Function ProdComponentData_ExcelTableDefinition() As DataTable
            Dim dTB As New DataTable()
            Dim row As DataRow
            dTB.Columns.Add("RawRecID", GetType(Integer))
            dTB.Columns.Add("STORE NO", GetType(String))
            dTB.Columns.Add("RETAILER", GetType(String))
            dTB.Columns.Add("ADDRESS 1", GetType(String))
            dTB.Columns.Add("CITY", GetType(String))
            dTB.Columns.Add("STATE", GetType(String))
            dTB.Columns.Add("ZIP", GetType(String))
            Return dTB
        End Function

        '******************************************************************
        Public Function RetailersTableDefinition() As DataTable
            Dim dTB As New DataTable()
            dTB.Columns.Add("RetailerShortName", GetType(String))
            dTB.Columns.Add("RetailerFullName", GetType(String))
            Return dTB
        End Function

        '******************************************************************
        Public Function StoreComponentsTableDefinition() As DataTable
            Dim dTB As New DataTable()
            dTB.Columns.Add("ColName", GetType(String))
            dTB.Columns.Add("ProdName", GetType(String))
            dTB.Columns.Add("ProdQty", GetType(Integer))
            Return dTB
        End Function



        '******************************************************************
        Public Function ProdComponentData_GetHeaderNames() As ArrayList
            Dim arrNames As New ArrayList()
            Dim tmpDT As DataTable = ProdComponentData_ExcelTableDefinition()
            Dim i As Integer = 0, tmpS As String = ""

            Try
                For i = 0 To tmpDT.Columns.Count - 1
                    tmpS = tmpDT.Columns(i).ColumnName.ToUpper.Trim
                    If tmpS <> "RawRecID".ToUpper Then
                        arrNames.Add(tmpS)
                    End If
                Next
                tmpDT = Nothing

                Return arrNames

            Catch ex As Exception
                Throw ex
            End Try

        End Function


        '******************************************************************
        Public Function GetDriveLineRetailersData(ByRef errMsg As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT * from tdriveline_retailers order by RetailerName1;"
                dt = Me._objDataProc.GetDataTable(strSql)
                errMsg = ""
                Return dt
            Catch ex As Exception
                errMsg = ex.ToString
                Return Nothing
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function InsertOrUpdateDriveLineRetailersData(ByVal strSQL As String) As Integer

            Try
                Return Me._objDataProc.ExecuteNonQuery(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '******************************************************************
        Public Function FoundDriveLineRetailerShortName(ByVal strRetailerName As String) As ArrayList
            Dim strSQL1 As String, strSQL2 As String = ""
            Dim dt As DataTable
            Dim strRet As New ArrayList()
            Dim strCol As String = "", col As DataColumn, row As DataRow

            Try
                strSQL1 = "SELECT * from tdriveline_retailers;"
                dt = Me._objDataProc.GetDataTable(strSQL1)
                For Each col In dt.Columns
                    If col.ColumnName <> "RetailerShortName" Then
                        If strSQL2.Trim.Length = 0 Then
                            strSQL2 = "SELECT RetailerShortName," & col.ColumnName & " as FullName from tdriveline_retailers Where " & col.ColumnName & " = '" & strRetailerName & "'"
                        Else
                            strSQL2 &= " UNION ALL SELECT RetailerShortName," & col.ColumnName & " as FullName from tdriveline_retailers Where " & col.ColumnName & " = '" & strRetailerName & "'"
                        End If
                    End If
                Next
                dt = Me._objDataProc.GetDataTable(strSQL2)
                For Each row In dt.Rows
                    strRet.Add(row("RetailerShortName"))
                Next

                Return strRet
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function InsertUpdateStockLocation(ByVal iBinLocationNo As Integer, _
                                                  ByVal strBinLocation As String, _
                                                  ByVal strProjectID As String, _
                                                  ByVal iUSerID As Integer, _
                                                  ByVal strDateTime As String) As Integer
            Dim strSQL As String = ""
            Dim dt As DataTable
            Dim iID As Integer

            Try
                strSQL = "SELECT * FROM tdriveline_bin where BinOrder =" & iBinLocationNo & " AND Project_ID='" & strProjectID & "';"
                dt = Me._objDataProc.GetDataTable(strSQL)

                If dt.Rows.Count = 0 Then
                    strSQL = "INSERT INTO tdriveline_bin (Project_ID,BinName,BinOrder,UserID,UpdateDateTime)" & Environment.NewLine
                    strSQL &= " VALUES ('" & strProjectID & "','" & strBinLocation & "'," & Environment.NewLine
                    strSQL &= iBinLocationNo & "," & iUSerID & ",'" & strDateTime & "');"
                    Return Me._objDataProc.ExecuteNonQuery(strSQL)
                Else
                    iID = dt.Rows(0).Item("DBin_ID")
                    strSQL = "UPDATE tdriveline_bin  SET Project_ID='" & strProjectID & "'," & Environment.NewLine
                    strSQL &= "BinName='" & strBinLocation & "'," & Environment.NewLine
                    strSQL &= "BinOrder=" & iBinLocationNo & "," & Environment.NewLine
                    strSQL &= "UserID=" & iUSerID & "," & Environment.NewLine
                    strSQL &= "UpdateDateTime='" & strDateTime & "'," & Environment.NewLine
                    strSQL &= " WHERE DBin_ID=" & iID & ";"
                    Return Me._objDataProc.ExecuteNonQuery(strSQL)
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Sub InsertLocationComponentAssigmentResult(ByVal iDBin_ID As Integer, _
                                                               ByVal strComponentName As String, _
                                                               ByVal iProdOrder As Integer, _
                                                               ByVal iUSerID As Integer, _
                                                               ByVal strDateTime As String, _
                                                               ByRef strErrMsg As String)
            Dim strSQL As String = ""
            Dim dt As DataTable
            Dim iID As Integer
            Dim i, j As Integer

            strErrMsg = ""

            Try

                strSQL = "INSERT INTO tdriveline_binassignment (DBin_ID,ProductName,ProdOrder,UserID,UpdateDateTime)" & Environment.NewLine
                strSQL &= " VALUES (" & iDBin_ID & ",'" & strComponentName.Replace("'", "''") & "'," & Environment.NewLine
                strSQL &= iProdOrder & "," & iUSerID & ",'" & strDateTime & "');"
                j = Me._objDataProc.ExecuteNonQuery(strSQL)
                If Not j > 0 Then
                    strErrMsg = "Failed to save!"
                End If

            Catch ex As Exception
                'Throw ex
                strErrMsg = ex.ToString
            End Try
        End Sub

        '******************************************************************
        Public Function ClearComponentAssigment(ByVal iDBin_ID As Integer) As Integer
            Dim strSQL As String = ""

            Try
                'Clear this bin
                strSQL = "DELETE FROM tdriveline_binassignment where DBin_ID =" & iDBin_ID & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSQL)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetDriveLine_StockLocationData(ByVal strProjectID As String) As DataTable
            Dim strSQL As String = ""

            Try
                strSQL = "SELECT BinOrder AS 'LocNo',BinName AS 'Location',Project_ID,DBin_ID" & Environment.NewLine
                strSQL &= " FROM tdriveline_bin WHERE Project_ID='" & strProjectID & "';"
                Return Me._objDataProc.GetDataTable(strSQL)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetDriveLine_LocationBinComponents(ByVal iBin_ID As Integer) As DataTable
            Dim strSQL As String = ""

            Try
                strSQL = "SELECT ProductName FROM  tdriveline_binassignment" & Environment.NewLine
                strSQL &= " WHERE DBin_ID=" & iBin_ID & " ORDER BY ProdOrder"
                Return Me._objDataProc.GetDataTable(strSQL)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetDriveLine_LocationComponentAssignmentData(ByVal strProject_ID As String) As DataTable
            Dim strSQL As String = ""

            Try
                strSQL = "select B.Project_ID,B.BinName AS 'Location',B.BinOrder AS LocNo" & Environment.NewLine
                strSQL &= ",A.ProductName AS 'Component',A.ProdOrder AS 'ORD'" & Environment.NewLine
                strSQL &= ",B.DBin_ID,A.DAS_ID" & Environment.NewLine
                strSQL &= " FROM tdriveline_binassignment A" & Environment.NewLine
                strSQL &= " inner join tdriveline_bin B on A.DBin_ID=B.DBin_ID" & Environment.NewLine
                strSQL &= " Where Project_ID='" & strProject_ID & "'" & Environment.NewLine
                strSQL &= " ORDER BY B.Project_ID,B.BinOrder,A.ProdOrder;" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSQL)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetDriveLine_TotalQuantitiesOfComponents(ByVal strProject_ID As String) As DataTable
            Dim strSQL As String = ""

            Try
                'strSQL = " select  A.ProductName, count(A.ProductName) as 'Count'" & Environment.NewLine
                'strSQL &= " FROM tdriveline_dertails A" & Environment.NewLine
                'strSQL &= " Inner Join extendedwarranty B on A.EW_ID=B.EW_ID" & Environment.NewLine
                'strSQL &= " Where B.cust_ID=2546 and B.project_ID='" & strProject_ID & "'" & Environment.NewLine
                'strSQL &= " Group By A.ProductName;" & Environment.NewLine
                strSQL = " select  A.ProductName, count(A.ProductName) as 'StoreCount',sum(Quantity) as 'ComponentCount'" & Environment.NewLine
                strSQL &= " FROM tdriveline_dertails A" & Environment.NewLine
                strSQL &= " Inner Join extendedwarranty B on A.EW_ID=B.EW_ID" & Environment.NewLine
                strSQL &= " Where B.cust_ID=2546 and B.project_ID='" & strProject_ID & "'" & Environment.NewLine
                strSQL &= " Group By A.ProductName;" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSQL)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetDriveLine_TotalQuantitiesOfStores4Project(ByVal strProject_ID As String) As Integer
            Dim strSQL As String = ""
            Dim iRes As Integer = 0
            Dim dt As DataTable

            Try
                strSQL &= " SELECT count(A.RetailerStoreNo) As TotalStoreCount FROM tdriveline_stores A" & Environment.NewLine
                strSQL &= " INNER JOIN Extendedwarranty B ON A.EW_ID=B.EW_ID" & Environment.NewLine
                strSQL &= " WHERE B.Project_ID='" & strProject_ID & "'" & Environment.NewLine
                strSQL &= " GROUP BY B.Project_ID;" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSQL)

                If dt.Rows.Count > 0 Then
                    iRes = Convert.ToInt32(dt.Rows(0).Item("TotalStoreCount"))
                End If

                Return iRes
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '******************************************************************
        Public Function ReOrderTable(ByVal dt_in As DataTable, ByVal ColumnOrder() As Integer) As DataTable
            Dim dt As New DataTable()
            Dim dr As DataRow
            Dim c, c_in, key() As DataColumn
            Dim i As Integer
            Try
                dt.TableName = dt_in.TableName
                ' copy the schema of each columns
                For i = 0 To UBound(ColumnOrder)
                    c_in = dt_in.Columns(ColumnOrder(i))
                    c = New DataColumn(c_in.ColumnName)
                    c.DataType = c_in.DataType
                    c.AllowDBNull = c_in.AllowDBNull
                    c.MaxLength = c_in.MaxLength
                    c.AutoIncrement = c_in.AutoIncrement
                    c.AutoIncrementSeed = c_in.AutoIncrementSeed
                    c.AutoIncrementStep = c_in.AutoIncrementStep
                    dt.Columns.Add(c)
                Next
                ' copy the primary keys
                ReDim key(UBound(dt_in.PrimaryKey))
                For i = 0 To UBound(dt_in.PrimaryKey)
                    key(i) = dt.Columns(dt_in.PrimaryKey(i).ColumnName)
                Next
                dt.PrimaryKey = key
                ' copy the data
                For Each dr In dt_in.Rows()
                    dt.ImportRow(dr)
                Next
                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '******************************************************************




    End Class

End Namespace

