Option Explicit On 

Imports System
Imports System.Data
Imports System.Text
Imports MySql.Data
Imports System.IO
'Imports System.Runtime.InteropServices

Namespace Buisness.TracFoneFulfillmentKit
    Public Class TFFK_BYOP_SimplePackProcess
        Private _objDataProc As mySQL5

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

        Public Function getSN_DataTableDef() As DataTable
            Dim strSql As String = ""
            Dim dt, dt2 As DataTable
            Try
                strSql = "Select  'Box 1' as 'Box',0 as 'Row', '' as 'SN','Not Saved' as 'Status' limit 0;"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getProcessedBox_DataTableDef() As DataTable
            Dim strSql As String = ""
            Dim dt, dt2 As DataTable
            Try
                strSql = "Select 'Box 1' as 'Box', 0 as 'Qty of SN' limit 0;"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getSetUpSIM_CardData(ByVal iKMSet_ID As Integer) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT A.*,B.Model_Desc AS 'SIM',B.Model_LDesc AS 'SIM_Desc'" & Environment.NewLine
                strSql &= " FROM production.ttffk_kitting_items_setdetail A" & Environment.NewLine
                strSql &= " INNER JOIN production.tmodel_items B ON A.Component_Model_ID=B.Model_ID" & Environment.NewLine
                strSql &= " WHERE KMSet_ID=" & iKMSet_ID & ";" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function AreSNsAlreadySaved(ByVal strSNs As String) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable
            Try

                strSql = "SELECT A.*,B.Pack_WO_ID,C.KP_ID,D.KPD_ID,D.Model_ID as 'SIM_Model_ID',D.SN" & Environment.NewLine
                strSql &= " FROM production.tTFFK_Kitting_Items_SetMaster A" & Environment.NewLine
                strSql &= " LEFT JOIN production.ttffk_kitting_workorder B ON A.KMSet_ID=B.KMSet_ID" & Environment.NewLine
                strSql &= " LEFT JOIN production.ttffk_kitting_pack C ON B.Pack_WO_ID=C.Pack_WO_ID AND C.Carton_ID=0 AND InnerCarton_ID=0" & Environment.NewLine
                strSql &= " LEFT JOIN production.ttffk_kitting_packdetail D ON C.KP_ID=D.KP_ID" & Environment.NewLine
                strSql &= " WHERE A.Process_Type_ID=2  AND D.SN IN (" & strSNs & ");" & Environment.NewLine

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

        'Public Function CreateReceiptID(ByVal iDataSet_ID As Integer, ByVal iLoc_ID As Integer, ByVal iProd_ID As Integer, ByVal iUser_ID As Integer, ByVal strDatetime As String) As Integer
        '    Dim strSql As String = ""
        '    Dim strReceiptName As String = "FKBYOP" & Format(Now, "yyyyMMddHHmmss_fff")
        '    Dim iWO_ID As Integer = 0

        '    Try
        '        'SELECT WO_ID,WO_CustWo,WO_RecPalletName,WO_Date,WO_Quantity,WO_RAQnty,Loc_ID,Prod_ID FROM production.tWorkorder ;
        '        'SELECT WR_ID,WR_Name,Receipt_Date,Receipt_Qty,User_ID,Loc_ID,RMA,WO_ID,IDataSet_ID FROM warehouse.warehouse_receipt;
        '        strSql = "INSERT INTO production.tWorkorder (WO_CustWo,WO_RecPalletName,WO_Date,WO_Quantity,WO_RAQnty,Loc_ID,Prod_ID)" & _
        '                 " VALUES ('" & strReceiptName & "','" & strReceiptName & "','" & strDatetime & "',0,0," & iLoc_ID & "," & iProd_ID & ");"
        '        iWO_ID = Me._objDataProc.GetLastInsertedPrimaryKey(strSql, "production.tWorkOrder")

        '        strSql = "INSERT INTO warehouse.warehouse_receipt (WR_Name,Receipt_Date,Receipt_Qty,User_ID,Loc_ID,RMA,WO_ID,IDataSet_ID)" & _
        '                 " VALUES ('" & strReceiptName & "','" & strDatetime & "',0," & iUser_ID & "," & iLoc_ID & ",'" & strReceiptName & "'," & iWO_ID & "," & iDataSet_ID & ");"
        '        Return Me._objDataProc.GetLastInsertedPrimaryKey(strSql, "warehouse.warehouse_receipt")
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function

        Public Function SaveOpenBoxData(ByVal strWorkstation As String, ByVal iKMSet_ID As Integer, _
                                       ByVal dtSIM_SNs As DataTable, ByVal strUPC As String, _
                                       ByVal strItemUPC As String, ByVal iMasterItem_Model_ID As Integer, _
                                       ByVal iSIM_Model_ID As Integer, ByVal iIsKeySIM As Integer, ByVal iUserID As Integer) As Boolean

            Dim strSql As String = "", strSql2 As String = ""
            Dim i As Integer = 0
            Dim strDateTime As String = ""
            Dim iQty As Integer = 1
            Dim row As DataRow
            Dim objTFFK_BYOPKitting As New PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_BYOP_Kitting()
            Dim iPack_WO_ID As Integer = 0
            Dim iKP_ID As Integer = 0

            Try
                strDateTime = Format(Now, "yyyy-MM-dd HH:mm:ss")

                If Not dtSIM_SNs.Rows.Count > 1 Then Return False

                For Each row In dtSIM_SNs.Rows
                    iPack_WO_ID = objTFFK_BYOPKitting.CreateKittingPackID(iKMSet_ID, strWorkstation, "", "", 1, iUserID)

                    strSql = "INSERT INTO production.ttffk_kitting_pack (Pack_WO_ID, UPC,ItemUPC, Model_ID, Qty, UserID, DateTime_Pack) VALUES "
                    strSql &= "(" & iPack_WO_ID & ",'" & strUPC & "','" & strItemUPC & "'," & iMasterItem_Model_ID & "," & iQty & "," & iUserID & ",'" & strDateTime & "');"
                    iKP_ID = Me._objDataProc.GetLastInsertedPrimaryKey(strSql, "production.ttffk_kitting_pack")

                    strSql = "INSERT INTO production.ttffk_kitting_packdetail (KP_ID, Model_ID, SN, Qty, IsKeySIM, UserID, DateTime_Pack) VALUES "
                    strSql &= "(" & iKP_ID & "," & iSIM_Model_ID & ",'" & Convert.ToString(row("SN")).Trim & "'," & iQty & "," & iIsKeySIM & "," & iUserID & ",'" & strDateTime & "')"
                    i += Me._objDataProc.ExecuteNonQuery(strSql)

                    strSql = "Update production.ttffk_kitting_WorkOrder Set Closed =1 WHERE Pack_WO_ID=" & iPack_WO_ID
                    i += Me._objDataProc.ExecuteNonQuery(strSql)
                Next

                Return True
            Catch ex As Exception
                Throw ex
            Finally
                objTFFK_BYOPKitting = Nothing
            End Try
        End Function

        ' Build Inner Carton------------------------------------------------------------------------------------------------------------
        Public Function getInnerCartonAvailableItemData(ByVal strSN As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSN = strSN.Replace("'", "''")
                strSql = "SELECT @row_number:=@row_number+1 AS 'Row',m.* FROM" & Environment.NewLine
                strSql &= " (SELECT A.*,B.Pack_WO_ID,C.KP_ID,D.KPD_ID,D.Model_ID as 'SIM_Model_ID',D.SN" & Environment.NewLine
                strSql &= " ,E.Model_Desc as 'Master_Item',E.Model_LDesc as 'Master_Item_Desc'" & Environment.NewLine
                strSql &= " ,F.Model_Desc as 'SIM_Item',F.Model_LDesc as 'SIM_Item_Desc'" & Environment.NewLine
                strSql &= " FROM production.tTFFK_Kitting_Items_SetMaster A" & Environment.NewLine
                strSql &= " INNER JOIN production.ttffk_kitting_workorder B ON A.KMSet_ID=B.KMSet_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.ttffk_kitting_pack C ON B.Pack_WO_ID=C.Pack_WO_ID AND C.Carton_ID=0 AND InnerCarton_ID=0" & Environment.NewLine
                strSql &= " INNER JOIN production.ttffk_kitting_packdetail D ON C.KP_ID=D.KP_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tModel_items E ON A.Master_Model_ID=E.Model_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tModel_items F ON D.Model_ID=F.Model_ID" & Environment.NewLine
                strSql &= " WHERE A.Process_Type_ID=2  AND D.SN IN ('" & strSN & "')) m," & Environment.NewLine
                strSql &= " (SELECT @row_number:=0) AS t;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getInnerCarton_ReprintLabelData(ByVal strInnerCartonName As String) As DataTable
            Dim strSql As String = ""
            Try
                strInnerCartonName = strInnerCartonName.Replace("'", "''")
                strSql = "SELECT @row_number:=@row_number+1 AS 'Row',m.* FROM" & Environment.NewLine
                strSql &= " (SELECT A.*,B.Pack_WO_ID,C.KP_ID,D.KPD_ID,D.Model_ID as 'SIM_Model_ID',D.SN" & Environment.NewLine
                strSql &= " ,E.Model_Desc as 'Master_Item',E.Model_LDesc as 'Master_Item_Desc'" & Environment.NewLine
                strSql &= " ,F.Model_Desc as 'SIM_Item',F.Model_LDesc as 'SIM_Item_Desc',G.Carton_Name" & Environment.NewLine
                strSql &= " FROM production.tTFFK_Kitting_Items_SetMaster A" & Environment.NewLine
                strSql &= " INNER JOIN production.ttffk_kitting_workorder B ON A.KMSet_ID=B.KMSet_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.ttffk_kitting_pack C ON B.Pack_WO_ID=C.Pack_WO_ID AND C.InnerCarton_ID>0" & Environment.NewLine
                strSql &= " INNER JOIN production.ttffk_kitting_packdetail D ON C.KP_ID=D.KP_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tModel_items E ON A.Master_Model_ID=E.Model_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tModel_items F ON D.Model_ID=F.Model_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.ttffk_kitting_innercarton G ON C.InnerCarton_ID=G.InnerCarton_ID" & Environment.NewLine
                strSql &= " WHERE A.Process_Type_ID=2 AND G.Carton_Name IN ('" & strInnerCartonName & "')) m," & Environment.NewLine
                strSql &= " (SELECT @row_number:=0) AS t;" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function CreateInnerCartonName(ByVal strWorkstation As String, ByRef iInnerCarton_ID As Integer) As String
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim strInnerCartonName As String = ""
            'InnerCarton_ID, Carton_Name, ItemQty, Model_ID, Closed, UserID, DateTime_Carton, WorkStation, Carton_ID
            Try
                iInnerCarton_ID = 0
                strWorkstation = strWorkstation.Replace("'", "''")
                strSql = "INSERT INTO production.ttffk_kitting_InnerCarton (WorkStation) VALUES ('" & strWorkstation & "');"
                iInnerCarton_ID = Me._objDataProc.GetLastInsertedPrimaryKey(strSql, "production.ttffk_kitting_InnerCarton")

                strSql = "SELECT * FROM production.ttffk_kitting_InnerCarton WHERE InnerCarton_ID=" & iInnerCarton_ID
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then strInnerCartonName = Convert.ToString(dt.Rows(0).Item("Carton_Name"))

                Return strInnerCartonName

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function IsInnerCartonClosed(ByVal iInnerCarton_ID As Integer) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim bRet As Boolean = False

            Try
                strSql = "SELECT * FROM production.ttffk_kitting_InnerCarton  WHERE  InnerCarton_ID=" & iInnerCarton_ID & " AND Closed=0;"
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    bRet = False
                Else
                    bRet = True
                End If

                Return bRet

            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing
            End Try
        End Function

        Public Function SaveInnerCartonData(ByVal iInnerCarton_ID As Integer, ByVal iItemQty As Integer, ByVal iModel_ID As Integer, _
                                            ByVal iClosed As Integer, ByVal iUserID As Integer, ByVal strKP_IDs As String, ByVal strExpirationDate As String) As Integer
            Dim strSql As String = ""
            Dim strDatetime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            Dim i As Integer = 0

            'InnerCarton_ID, Carton_Name, ItemQty, Model_ID, Closed, UserID, DateTime_Carton, WorkStation, Carton_ID
            Try
                strSql = "UPDATE production.ttffk_kitting_InnerCarton SET ItemQty=" & iItemQty & ",Model_ID=" & iModel_ID & ",Closed=" & _
                         iClosed & ",UserID=" & iUserID & ",DateTime_Carton='" & strDatetime & "',ExpirationDate='" & strExpirationDate & "' WHERE InnerCarton_ID=" & iInnerCarton_ID & ";"
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                strSql = "UPDATE production.ttffk_kitting_pack SET InnerCarton_ID=" & iInnerCarton_ID & " WHERE KP_ID IN (" & strKP_IDs & ");"
                i += Me._objDataProc.ExecuteNonQuery(strSql)

                Return i

            Catch ex As Exception
                Throw ex
            End Try
        End Function


        Public Function Print_SP_InnerCarton_Label(ByVal strItemDesc As String, _
                                                ByVal strItem As String, _
                                                ByVal strItem_BarCode As String, _
                                                ByVal strUPC As String, _
                                                ByVal strUPC_Barcode As String, _
                                                ByVal strUPC_Desc As String, _
                                                ByVal strUPC_Desc_Barcode As String, _
                                                ByVal strMinSN As String, _
                                                ByVal strMaxSN As String, _
                                                ByVal strCartonNo As String, _
                                                ByVal strCartonNo_BarCode As String, _
                                                ByVal strCartonNo_Desc As String, _
                                                ByVal strCartonNo_Desc_BarCode As String, _
                                                ByVal strQty_Str As String, _
                                                ByVal strQty_Str_BarCode As String, _
                                                ByVal strVerControlNo As String, _
                                                ByVal strCountry As String, _
                                                ByVal strQR_Data As String, _
                                                ByVal strQR_Data_BarCode As String, _
                                                ByVal strPDF417_Data As String, _
                                                ByVal strPDF417_Data_BarCode As String, _
                                                ByVal strPrinterName As String, _
                                                ByVal iCopyNumber As Integer) As Integer
            Const strReportName As String = "TF_FK_BYOPKitting_SP_InnerCarton_Label.rpt"
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim objTFMisc As PSS.Data.Buisness.TracFone.clsMisc
            Try
                strItemDesc = strItemDesc.Replace("'", "''").Replace("\", "\\")
                strItem = strItem.Replace("'", "''").Replace("\", "\\")
                strUPC = strUPC.Replace("'", "''").Replace("\", "\\")
                strUPC_Barcode = strUPC_Barcode.Replace("'", "''").Replace("\", "\\")
                strUPC_Desc = strUPC_Desc.Replace("'", "''").Replace("\", "\\")
                strUPC_Desc_Barcode = strUPC_Desc_Barcode.Replace("'", "''").Replace("\", "\\")
                strMinSN = strMinSN.Replace("'", "''").Replace("\", "\\")
                strMaxSN = strMaxSN.Replace("'", "''").Replace("\", "\\")
                strCartonNo = strCartonNo.Replace("'", "''").Replace("\", "\\")
                strCartonNo_BarCode = strCartonNo_BarCode.Replace("'", "''").Replace("\", "\\")
                strCartonNo_Desc = strCartonNo_Desc.Replace("'", "''").Replace("\", "\\")
                strCartonNo_Desc_BarCode = strCartonNo_Desc_BarCode.Replace("'", "''").Replace("\", "\\")
                strQty_Str = strQty_Str.Replace("'", "''").Replace("\", "\\")
                strQty_Str_BarCode = strQty_Str_BarCode.Replace("'", "''").Replace("\", "\\")
                strVerControlNo = strVerControlNo.Replace("'", "''").Replace("\", "\\")
                strCountry = strCountry.Replace("'", "''").Replace("\", "\\")
                strQR_Data = strQR_Data.Replace("'", "''")
                strQR_Data_BarCode = strQR_Data_BarCode.Replace("'", "''")
                strPDF417_Data = strPDF417_Data.Replace("'", "''")
                strPDF417_Data_BarCode = strPDF417_Data_BarCode.Replace("'", "''")

                strSql = "Select '" & strItemDesc & "' as UItemDesc" & Environment.NewLine
                strSql &= ",'" & strItem & "' as Item" & Environment.NewLine
                strSql &= ",'" & strItem_BarCode & "' as Item_BarCode" & Environment.NewLine
                strSql &= ",'" & strUPC & "' as UPC" & Environment.NewLine
                strSql &= ",'" & strUPC_Barcode & "' as UPC_BarCode" & Environment.NewLine
                strSql &= ",'" & strUPC_Desc & "' as UPC_Desc" & Environment.NewLine
                strSql &= ",'" & strUPC_Desc_Barcode & "' as UPC_Desc_Barcode" & Environment.NewLine
                strSql &= ",'" & strMinSN & "' as MinSN" & Environment.NewLine
                strSql &= ",'" & strMaxSN & "' as MaxSN" & Environment.NewLine
                strSql &= ",'" & strCartonNo & "' as CartonNo" & Environment.NewLine
                strSql &= ",'" & strCartonNo_BarCode & "' as CartonNo_BarCode" & Environment.NewLine
                strSql &= ",'" & strCartonNo_Desc & "' as CartonNo_Desc" & Environment.NewLine
                strSql &= ",'" & strCartonNo_Desc_BarCode & "' as CartonNo_Desc_BarCode" & Environment.NewLine
                strSql &= ",'" & strQty_Str & "' as Qty_Str" & Environment.NewLine
                strSql &= ",'" & strQty_Str_BarCode & "' as Qty_str_barcode" & Environment.NewLine
                strSql &= ",'" & strVerControlNo & "' as VerControlNo" & Environment.NewLine
                strSql &= ",'" & strCountry & "' as Country" & Environment.NewLine
                strSql &= ",'" & strQR_Data & "' as QR_Data" & Environment.NewLine
                strSql &= ",'" & strQR_Data_BarCode & "' as QR_Data_BarCode" & Environment.NewLine
                strSql &= ",'" & strPDF417_Data & "' as PDF417_Data" & Environment.NewLine
                strSql &= ",'" & strPDF417_Data_BarCode & "' as PDF417_Data_BarCode" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                '**********************
                'Print Box lablel
                '**********************
                Try
                    objTFMisc = New PSS.Data.Buisness.TracFone.clsMisc()
                    If strPrinterName.Trim.Length > 0 Then
                        objTFMisc.PrintCrystalReportLabel(dt, strReportName, iCopyNumber, strPrinterName)
                    Else
                        objTFMisc.PrintCrystalReportLabel(dt, strReportName, iCopyNumber, )
                    End If
                Catch ex As Exception
                    'if strPrinterName is not available then try default printer
                    objTFMisc.PrintCrystalReportLabel(dt, strReportName, iCopyNumber, )
                End Try
                '**********************

                Return dt.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        'Build Master Carton ================================================================================================================================================
        Public Function getMasterCarton_AvailableInnerCartonData(ByVal strInnerCartonName As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim row As DataRow

            Try
                strInnerCartonName = strInnerCartonName.Replace("'", "''")
                strSql = "SELECT 0 as 'GID', @row_number:=@row_number+1 AS 'Row',m.* FROM" & Environment.NewLine
                strSql &= " (SELECT A.*,B.Pack_WO_ID,C.KP_ID,D.KPD_ID,D.Model_ID as 'SIM_Model_ID',D.SN" & Environment.NewLine
                strSql &= " ,E.Model_Desc as 'Master_Item',E.Model_LDesc as 'Master_Item_Desc'" & Environment.NewLine
                strSql &= " ,F.Model_Desc as 'SIM_Item',F.Model_LDesc as 'SIM_Item_Desc'" & Environment.NewLine
                strSql &= " ,G.Carton_Name as 'InnerCarton_Name',0 as 'InnerCarton_Qty',G.ExpirationDate as 'InnerCartonExpirationDate'" & Environment.NewLine
                strSql &= " FROM production.tTFFK_Kitting_Items_SetMaster A" & Environment.NewLine
                strSql &= " INNER JOIN production.ttffk_kitting_workorder B ON A.KMSet_ID=B.KMSet_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.ttffk_kitting_pack C ON B.Pack_WO_ID=C.Pack_WO_ID AND C.Carton_ID=0 AND InnerCarton_ID>0" & Environment.NewLine
                strSql &= " INNER JOIN production.ttffk_kitting_packdetail D ON C.KP_ID=D.KP_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tModel_items E ON A.Master_Model_ID=E.Model_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tModel_items F ON D.Model_ID=F.Model_ID" & Environment.NewLine
                strSql &= " INNER JOIN ttffk_kitting_innercarton G ON C.InnerCarton_ID=G.InnerCarton_ID AND G.Closed=1" & Environment.NewLine
                strSql &= " WHERE A.Process_Type_ID=2 AND G.Carton_Name = '" & strInnerCartonName & "') m," & Environment.NewLine
                strSql &= " (SELECT @row_number:=0) AS t;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                For Each row In dt.Rows
                    row.BeginEdit() : row("InnerCarton_Qty") = dt.Rows.Count : row.AcceptChanges()
                Next

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getMasterCarton_ReprintLabelData(ByVal strMasterCartonName As String) As DataTable
            Dim strSql As String = ""
            Try
                strMasterCartonName = strMasterCartonName.Replace("'", "''")
                strSql = " SELECT @row_number:=@row_number+1 AS 'Row',m.* FROM" & Environment.NewLine
                strSql &= " (SELECT A.*,B.Pack_WO_ID,C.KP_ID,D.KPD_ID,D.Model_ID as 'SIM_Model_ID',D.SN" & Environment.NewLine
                strSql &= " ,E.Model_Desc as 'Master_Item',E.Model_LDesc as 'Master_Item_Desc'" & Environment.NewLine
                strSql &= " ,F.Model_Desc as 'SIM_Item',F.Model_LDesc as 'SIM_Item_Desc'" & Environment.NewLine
                strSql &= " ,G.Carton_Name as 'MasterCarton_Name'" & Environment.NewLine
                strSql &= " FROM production.tTFFK_Kitting_Items_SetMaster A" & Environment.NewLine
                strSql &= " INNER JOIN production.ttffk_kitting_workorder B ON A.KMSet_ID=B.KMSet_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.ttffk_kitting_pack C ON B.Pack_WO_ID=C.Pack_WO_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.ttffk_kitting_packdetail D ON C.KP_ID=D.KP_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tModel_items E ON A.Master_Model_ID=E.Model_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tModel_items F ON D.Model_ID=F.Model_ID" & Environment.NewLine
                strSql &= " INNER JOIN ttffk_kitting_carton G ON C.Carton_ID=G.Carton_ID AND G.Closed=1" & Environment.NewLine
                strSql &= " WHERE A.Process_Type_ID=2 AND G.Carton_Name = '" & strMasterCartonName & "') m," & Environment.NewLine
                strSql &= " (SELECT @row_number:=0) AS t;" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function Print_SP_MasterCarton_Label(ByVal strItemDesc As String, _
                                              ByVal strItem As String, _
                                              ByVal strItem_BarCode As String, _
                                              ByVal strUPC As String, _
                                              ByVal strUPC_Barcode As String, _
                                              ByVal strUPC_Desc As String, _
                                              ByVal strUPC_Desc_Barcode As String, _
                                              ByVal strMinSN As String, _
                                              ByVal strMaxSN As String, _
                                              ByVal strCartonNo As String, _
                                              ByVal strCartonNo_BarCode As String, _
                                              ByVal strCartonNo_Desc As String, _
                                              ByVal strCartonNo_Desc_BarCode As String, _
                                              ByVal strQty_Str As String, _
                                              ByVal strQty_Str_BarCode As String, _
                                              ByVal strCaseQty_Str As String, _
                                              ByVal strCaseQty_Str_BarCode As String, _
                                              ByVal strVerControlNo As String, _
                                              ByVal strCountry As String, _
                                              ByVal strQR_Data As String, _
                                              ByVal strQR_Data_BarCode As String, _
                                              ByVal strPDF417_Data As String, _
                                              ByVal strPDF417_Data_BarCode As String, _
                                              ByVal strPrinterName As String, _
                                              ByVal iCopyNumber As Integer) As Integer
            Const strReportName As String = "TF_FK_BYOPKitting_SP_MasterCarton_Label.rpt"
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim objTFMisc As PSS.Data.Buisness.TracFone.clsMisc
            Try
                strItemDesc = strItemDesc.Replace("'", "''").Replace("\", "\\")
                strItem = strItem.Replace("'", "''").Replace("\", "\\")
                strUPC = strUPC.Replace("'", "''").Replace("\", "\\")
                strUPC_Barcode = strUPC_Barcode.Replace("'", "''").Replace("\", "\\")
                strUPC_Desc = strUPC_Desc.Replace("'", "''").Replace("\", "\\")
                strUPC_Desc_Barcode = strUPC_Desc_Barcode.Replace("'", "''").Replace("\", "\\")
                strMinSN = strMinSN.Replace("'", "''").Replace("\", "\\")
                strMaxSN = strMaxSN.Replace("'", "''").Replace("\", "\\")
                strCartonNo = strCartonNo.Replace("'", "''").Replace("\", "\\")
                strCartonNo_BarCode = strCartonNo_BarCode.Replace("'", "''").Replace("\", "\\")
                strCartonNo_Desc = strCartonNo_Desc.Replace("'", "''").Replace("\", "\\")
                strCartonNo_Desc_BarCode = strCartonNo_Desc_BarCode.Replace("'", "''").Replace("\", "\\")
                strQty_Str = strQty_Str.Replace("'", "''").Replace("\", "\\")
                strQty_Str_BarCode = strQty_Str_BarCode.Replace("'", "''").Replace("\", "\\")
                strCaseQty_Str = strCaseQty_Str.Replace("'", "''").Replace("\", "\\")
                strCaseQty_Str_BarCode = strCaseQty_Str_BarCode.Replace("'", "''").Replace("\", "\\")
                strVerControlNo = strVerControlNo.Replace("'", "''").Replace("\", "\\")
                strCountry = strCountry.Replace("'", "''").Replace("\", "\\")
                strQR_Data = strQR_Data.Replace("'", "''")
                strQR_Data_BarCode = strQR_Data_BarCode.Replace("'", "''")
                strPDF417_Data = strPDF417_Data.Replace("'", "''")
                strPDF417_Data_BarCode = strPDF417_Data_BarCode.Replace("'", "''")

                strSql = "Select '" & strItemDesc & "' as UItemDesc" & Environment.NewLine
                strSql &= ",'" & strItem & "' as Item" & Environment.NewLine
                strSql &= ",'" & strItem_BarCode & "' as Item_BarCode" & Environment.NewLine
                strSql &= ",'" & strUPC & "' as UPC" & Environment.NewLine
                strSql &= ",'" & strUPC_Barcode & "' as UPC_BarCode" & Environment.NewLine
                strSql &= ",'" & strUPC_Desc & "' as UPC_Desc" & Environment.NewLine
                strSql &= ",'" & strUPC_Desc_Barcode & "' as UPC_Desc_Barcode" & Environment.NewLine
                strSql &= ",'" & strMinSN & "' as MinSN" & Environment.NewLine
                strSql &= ",'" & strMaxSN & "' as MaxSN" & Environment.NewLine
                strSql &= ",'" & strCartonNo & "' as CartonNo" & Environment.NewLine
                strSql &= ",'" & strCartonNo_BarCode & "' as CartonNo_BarCode" & Environment.NewLine
                strSql &= ",'" & strCartonNo_Desc & "' as CartonNo_Desc" & Environment.NewLine
                strSql &= ",'" & strCartonNo_Desc_BarCode & "' as CartonNo_Desc_BarCode" & Environment.NewLine
                strSql &= ",'" & strQty_Str & "' as Qty_Str" & Environment.NewLine
                strSql &= ",'" & strQty_Str_BarCode & "' as Qty_str_Barcode" & Environment.NewLine
                strSql &= ",'" & strCaseQty_Str & "' as Other1" & Environment.NewLine
                strSql &= ",'" & strCaseQty_Str_BarCode & "' as Other1_Barcode" & Environment.NewLine
                strSql &= ",'" & strVerControlNo & "' as VerControlNo" & Environment.NewLine
                strSql &= ",'" & strCountry & "' as Country" & Environment.NewLine
                strSql &= ",'" & strQR_Data & "' as QR_Data" & Environment.NewLine
                strSql &= ",'" & strQR_Data_BarCode & "' as QR_Data_BarCode" & Environment.NewLine
                strSql &= ",'" & strPDF417_Data & "' as PDF417_Data" & Environment.NewLine
                strSql &= ",'" & strPDF417_Data_BarCode & "' as PDF417_Data_BarCode" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                '**********************
                'Print Box lablel
                '**********************
                Try
                    objTFMisc = New PSS.Data.Buisness.TracFone.clsMisc()
                    If strPrinterName.Trim.Length > 0 Then
                        objTFMisc.PrintCrystalReportLabel(dt, strReportName, iCopyNumber, strPrinterName)
                    Else
                        objTFMisc.PrintCrystalReportLabel(dt, strReportName, iCopyNumber, )
                    End If
                Catch ex As Exception
                    'if strPrinterName is not available then try default printer
                    objTFMisc.PrintCrystalReportLabel(dt, strReportName, iCopyNumber, )
                End Try
                '**********************

                Return dt.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        Public Function PrintPallet_Label(ByVal strPalletName As String, _
                                  ByVal strPalletNameCode As String, _
                                  ByVal iQty As Integer, _
                                  ByVal strQtyCode As String, _
                                  ByVal strMasterItem As String, _
                                  ByVal strMasterItemCode As String, _
                                  ByVal strDate As String, _
                                  ByVal strPrinterName As String, _
                                  ByVal iCopyNumber As Integer) As Integer
            Const strReportName As String = "TF_FK_BYOP_SP_Pallet_Label.rpt"
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim objTFMisc As PSS.Data.Buisness.TracFone.clsMisc
            ' Dim strDate As String = Format(Now, "MM/dd/yyyy")
            Try
                strPalletNameCode = strPalletNameCode.Replace("'", "''")
                strQtyCode = strQtyCode.Replace("'", "''")
                strPalletName = strPalletName.Replace("'", "''")
                strMasterItem = strMasterItem.Replace("'", "''")
                strMasterItemCode = strMasterItemCode.Replace("'", "''")

                strSql = "Select '" & strPalletName & "' as PalletName" & Environment.NewLine
                strSql &= "," & iQty & " as Qty" & Environment.NewLine
                strSql &= ",'" & strDate & "' as DateComp" & Environment.NewLine
                strSql &= ",'" & strPalletNameCode & "' as PalletNameCode" & Environment.NewLine
                strSql &= ",'" & strQtyCode & "' as QtyCode" & Environment.NewLine
                strSql &= ",'" & strMasterItem & "' as MasterItem" & Environment.NewLine
                strSql &= ",'" & strMasterItemCode & "' as MasterItemCode" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                '**********************
                'Print Box lablel
                '**********************
                Try
                    objTFMisc = New PSS.Data.Buisness.TracFone.clsMisc()
                    If strPrinterName.Trim.Length > 0 Then
                        objTFMisc.PrintCrystalReportLabel(dt, strReportName, iCopyNumber, strPrinterName)
                    Else
                        objTFMisc.PrintCrystalReportLabel(dt, strReportName, iCopyNumber, )
                    End If
                Catch ex As Exception
                    'if strPrinterName is not available then try default printer
                    objTFMisc.PrintCrystalReportLabel(dt, strReportName, iCopyNumber, )
                End Try
                '**********************

                Return dt.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function
    End Class
End Namespace