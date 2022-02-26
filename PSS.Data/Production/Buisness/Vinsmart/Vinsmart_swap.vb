Option Explicit On 
Imports System
Imports System.Data
Imports System.Text
Imports MySql.Data

Namespace Buisness.Vinsmart
    Public Class Vinsmart_swap
        Private _dtSource, _dtDestination As New DataTable()
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

        Public Function getDeviceData(ByVal iCust_ID As Integer, ByVal iLoc_ID As Integer, ByVal strSN As String, ByVal iBulkORderType_ID As Integer, _
                                      ByVal strVinsmartCricketOrATT As String) As DataTable
            Dim strSql As String = ""
            Dim strVinsmartCricketSeedstock As String = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_SeedStockSourceType_Cricket.Trim.Replace("'", "''")
            Dim strVinsmartAttSeedstock As String = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_SeedStockSourceType_ATT.Trim.Replace("'", "''")
            Dim strVinsmartFilterOutSeedStock As String = "'" & strVinsmartCricketSeedstock & "'" & ",'" & strVinsmartAttSeedstock & "'"

            Try
                strSN = strSN.Replace("'", "''")

                strSql = "SELECT 0 as RecID,F.Device_SN AS 'Swapped_SN','' AS 'SeedStock_SN',A.Item_SKU,G.Model_Desc AS 'PSS_Model',F.Device_ID,A.Swapped_Device_ID,A.SerialNo AS 'ASN_SN',A.SerialNo2" & Environment.NewLine
                strSql &= " ,F.Device_DateRec,F.Device_DateBill,F.Device_DateShip" & Environment.NewLine
                strSql &= " ,IF(F.Device_LaborCharge IS NULL, 0.00,F.Device_LaborCharge) AS 'Device_LaborCharge',IF(F.Device_PartCharge IS NULL, 0.00,F.Device_PartCharge) AS 'Device_PartCharge'" & Environment.NewLine
                strSql &= " ,A.EW_ID,C.Cust_Name1 AS 'Customer', D.Loc_Name AS 'Loc',A.wb_ID,E.BoxID,G.ASN_In_SKU,F.Model_ID" & Environment.NewLine
                strSql &= " ,F.Pallett_ID,A.Model AS 'ASN_Model',A.Project_ID AS 'ASN_ID',A.OEM_RA,A.Rep_ID AS 'Delivery'" & Environment.NewLine
                strSql &= " ,A.ClaimNo AS 'PoNumber',A.ClaimLineNo As 'PoLineNumber',IF(A.FirstUseDate  IS NULL,'', IF(DATE_FORMAT(A.FirstUseDate,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(A.FirstUseDate ,'%Y-%m-%d')))  AS 'FirstUseDate'" & Environment.NewLine
                strSql &= " ,IF(A.LastUseDate  IS NULL,'', IF(DATE_FORMAT(A.LastUseDate,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(A.LastUseDate ,'%Y-%m-%d')))  AS 'LastDate',A.Reason AS 'Customer Complaint'" & Environment.NewLine
                strSql &= " ,A.Item_Desc,A.Channel,A.In_Pallet_ID,A.In_Carton_ID,A.Account AS 'VendorID',A.Retailer AS 'PlantID',A.ShipTo_Name2 'ShipToID',A.Retailer2 AS 'ReturnPlantID'" & Environment.NewLine
                strSql &= " ,IF(A.IMM_Shipped_Date IS NULL,'',IF(DATE_FORMAT(A.IMM_Shipped_Date,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(A.IMM_Shipped_Date ,'%Y-%m-%d')))  AS 'ShipDate'" & Environment.NewLine
                strSql &= " ,A.Cust2PSSI_Carrier,A.Cust2PSSI_TrackNo,A.Cust2PSSI_BillofLading,A.ShipTo_Name AS 'ShipToName',A.Address1 AS 'ShipToAddress1',A.Address2 AS 'ShipAddress2'" & Environment.NewLine
                strSql &= " ,A.City AS 'ShipCity',A.State_Name AS 'ShipState',A.ZipCode AS 'ShiPZip',A.ReturnToName,A.ReturnAddress1,A.ReturnAddress2,A.ReturnCity,A.ReturnState" & Environment.NewLine
                strSql &= " ,A.ReturnZip,A.ReturnPhone,A.ReturnPhoneExt,A.BillToName,A.BillToAttn,A.Warranty_Desc AS 'RepairProgramType',A.Failure_Code AS 'FaultCode',A.Failure_Reason AS 'FaultCodeDefinition'" & Environment.NewLine
                strSql &= " ,B.WO_CustWO AS 'Work_Order',F.Device_ManufWrty,IF(B.WO_Closed>0,'CLOSED','RECEIVING') AS 'WorkStation',  SourceFile,A.WO_ID,A.Cust_ID,A.Loc_ID,B.WO_Closed,E.Closed AS 'Box_Closed'" & Environment.NewLine
                strSql &= " FROM production.extendedwarranty A" & Environment.NewLine
                strSql &= " INNER JOIN production.tWorkOrder B ON A.WO_ID=B.WO_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tCustomer C ON A.Cust_ID=C.Cust_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tLocation D ON A.Loc_ID=D.Loc_ID" & Environment.NewLine
                strSql &= " INNER JOIN edi.tWarehouseBox E ON A.wb_ID=E.wb_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tDevice F ON A.Device_ID=F.Device_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tModel G ON F.Model_ID=G.Model_ID" & Environment.NewLine
                ' strSql &= " WHERE A.Cust_ID=" & iCust_ID & " and A.Loc_ID=" & iLoc_ID & " AND A.BulkORderType_ID=" & iBulkORderType_ID & Environment.NewLine

                If iCust_ID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID Then
                    If iBulkORderType_ID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_OrderTypeBulk_ID Then 'None seedstock
                        strSql &= " WHERE A.Cust_ID=" & iCust_ID & " AND A.Account NOT IN (" & strVinsmartFilterOutSeedStock & ")" & Environment.NewLine
                    ElseIf iBulkORderType_ID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_OrderTypeSeedStock_ID Then 'Seedstock
                        If iLoc_ID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttCricket_LOC_ID _
                           AndAlso strVinsmartCricketOrATT.Trim.ToUpper = strVinsmartCricketSeedstock.Trim.ToUpper Then 'Cricket
                            strSql &= " WHERE A.Cust_ID=" & iCust_ID & " AND A.Account  IN ('" & strVinsmartCricketSeedstock & "')" & Environment.NewLine
                        ElseIf (iLoc_ID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttCTDI_LOC_ID Or iLoc_ID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttFedEx_LOC_ID) _
                          AndAlso strVinsmartCricketOrATT.Trim.ToUpper = strVinsmartAttSeedstock.Trim.ToUpper Then
                            strSql &= " WHERE A.Cust_ID=" & iCust_ID & " AND A.Account  IN ('" & strVinsmartAttSeedstock & "')" & Environment.NewLine

                        Else
                            Throw New Exception("Failed to determine Vinsmart seedstock location.")
                        End If
                        Else
                        Throw New Exception("Failed to determine Vinsmart device info.")
                    End If
                Else
                    strSql &= " WHERE A.Cust_ID=" & iCust_ID & " and A.Loc_ID=" & iLoc_ID & " AND A.BulkORderType_ID=" & iBulkORderType_ID & Environment.NewLine
                End If

                strSql &= " AND F.Device_DateShip IS NULL AND F.Pallett_ID IS NULL" & Environment.NewLine
                strSql &= " AND F.Device_SN = '" & strSN & "'"
                strSql &= " ORDER BY F.Device_DateRec DESC;"

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getDeviceBillData(ByVal iDevice_ID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "select * from tdevicebill where device_ID = " & iDevice_ID
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function Is_BER_Device(ByVal iDevice_ID As Integer, ByVal iBER_BillCode_ID As Integer) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim bRet As Boolean = False

            Try
                strSql = "select * from tdevicebill where device_ID = " & iDevice_ID & " AND BillCode_ID=" & iBER_BillCode_ID
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then bRet = True

                Return bRet

            Catch ex As Exception
                Throw ex
            End Try
        End Function


        Public Function Has_Swap_Bill_Code(ByVal iDevice_ID As Integer, ByVal iSwap_BillCode_ID As Integer) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim bRet As Boolean = False

            Try
                strSql = "select * from tdevicebill where device_ID = " & iDevice_ID & " AND BillCode_ID=" & iSwap_BillCode_ID
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then bRet = True

                Return bRet

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getPartNumberData(ByVal iPSPrice_ID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT * FROM  lpsPrice WHERE psPrice_ID= " & iPSPrice_ID
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getLaborChargeData(ByVal iLaborLvl_ID As Integer, ByVal iPrcGroup_ID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT * FROM tlaborprc WHERE LaborLvl_ID = " & iLaborLvl_ID & "  AND PrcGroup_ID = " & iPrcGroup_ID  ' AND ProdGrp_ID = 209;"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function UpdateSwappedData(ByVal iDevice_ID As Integer, ByVal iOriginal_Device_ID As Integer, ByVal iSwap_BillCode_ID As Integer, ByVal strPartNum As String, _
                                          ByVal iUserID As Integer, ByVal strDateTime As String, ByVal dLaborCharge As Single, _
                                          ByVal dPartCharge As Single, ByVal iLaborLevel As Integer, ByVal strWorkStation As String) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0
            Dim bRet As Boolean = False

            Try
                strSql = "INSERT INTO production.tDeviceBill (DBill_RegPartPrice, DBill_AvgCost, DBill_StdCost, DBill_InvoiceAmt, Device_ID, " & Environment.NewLine
                strSql &= "BillCode_ID, Part_Number, Fail_ID, Repair_ID, Comp_ID, User_ID, Date_Rec, ReplPartSN" & Environment.NewLine
                strSql &= " ) VALUES " & Environment.NewLine
                strSql &= "(0.00,0.00,0.00,0.00," & iDevice_ID & "," & iSwap_BillCode_ID & ",'" & strPartNum & "',0,0,NULL," & iUserID & ",'" & strDateTime & "','');" & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                strSql = "UPDATE production.tDevice SET Device_DateBill='" & strDateTime & "', Device_LaborLevel=" & iLaborLevel & ", Device_LaborCharge=" & dLaborCharge & ", Device_PartCharge = " & dPartCharge & " WHERE device_ID =" & iDevice_ID
                i += Me._objDataProc.ExecuteNonQuery(strSql)

                strSql = "UPDATE production.tCellopt SET Workstation = '" & strWorkStation & "', WorkStationEntryDt = '" & strDateTime & "' WHERE device_ID = " & iDevice_ID
                i += Me._objDataProc.ExecuteNonQuery(strSql)

                strSql = "UPDATE production.Extendedwarranty SET Swapped_Device_ID = " & iDevice_ID & " WHERE device_ID = " & iOriginal_Device_ID
                i += Me._objDataProc.ExecuteNonQuery(strSql)

                Return i

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '

        'Private arrSN() As String = {123456060014101, 123456060020868, 123456060031063, 123456060038092, 123456060156233, 123456060220542, 123456060262544, 123456060314824, 123456060330929, 123456060333527, 123456060410267, 123456060450610, 123456060452921, 123456060470857, 123456060490905, 123456060498296, 123456060529074, 123456060576919, 123456060585597, 123456060652819}
        'Private arrSeedStock() As String = {123456060014123, 123456060020833, 123456060031044, 123456060038055, 123456060156255, 123456060220566, 123456060262577, 123456060314899, 123456060330910, 123456060333572, 123456060410200, 123456060450600, 123456060452900, 123456060470896, 123456060490996, 123456060498285, 123456060529085, 123456060576974, 123456060585547, 123456060652898}
        'Public Function createSource() As DataTable
        '    Dim strValue As String
        '    With _dtSource.Columns
        '        .Add("Model_ID", GetType(String))
        '        .Add("Mode_desc", GetType(String))
        '        .Add("SN", GetType(String))
        '        .Add("Swaped_SN", GetType(String))
        '        .Add("ASN_Model", GetType(String))
        '        .Add("ASN_SKU", GetType(String))

        '        .Add("Device_Source", GetType(String))

        '    End With
        '    For Each strValue In arrSN
        '        Dim R As DataRow = _dtSource.NewRow
        '        R("Model_ID") = "5045"
        '        R("Mode_desc") = "CP3311ATMO"
        '        R("ASN_Model") = "3311A"
        '        R("ASN_SKU") = "X58760"
        '        R("SN") = strValue
        '        R("Swaped_SN") = ""
        '        R("Device_Source") = ""
        '        _dtSource.Rows.Add(R)
        '    Next
        '    Return _dtSource
        'End Function
        'Public Function createDataDestination() As DataTable
        '    With _dtDestination.Columns
        '        .Add("Model_ID", GetType(String))
        '        .Add("Mode_desc", GetType(String))
        '        .Add("SeedStock_SN", GetType(String))
        '        .Add("ASN_Model", GetType(String))
        '        .Add("ASN_SKU", GetType(String))

        '    End With
        '    Dim strValue As String
        '    For Each strValue In arrSeedStock
        '        Dim R As DataRow = _dtDestination.NewRow
        '        R("Model_ID") = "5045"
        '        R("Mode_desc") = "CP3311ATMO"
        '        R("ASN_Model") = "3311A"
        '        R("ASN_SKU") = "X58760"
        '        R("SeedStock_SN") = strValue
        '        _dtDestination.Rows.Add(R)
        '    Next
        '    Return _dtDestination
        'End Function

        'Public Function updatedbg(ByVal intSeedStock As Int64, ByVal intSN As Int64, Optional ByRef bcondition As Boolean = True) As DataTable

        '    Dim drRow As DataRow
        '    For Each drRow In _dtSource.Rows
        '        Dim strdataTemp As String = drRow("Swaped_SN")
        '        If strdataTemp = intSeedStock.ToString Then
        '            Windows.Forms.MessageBox.Show("The Serial Number is already used, please select a new one")

        '            Return _dtSource

        '            Exit Function
        '        End If
        '    Next

        '    Dim myRow() As DataRow
        '    myRow = _dtSource.Select("SN =  " & intSN)
        '    myRow(0)("Swaped_SN") = intSeedStock


        '    Return _dtSource


        'End Function

        'Private Function checkSeedStock(ByVal lSeedstock As Long) As Boolean



        'End Function
    End Class
End Namespace