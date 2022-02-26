Option Explicit On 

Imports System
Imports System.Data
Imports System.Text
Imports MySql.Data

Namespace Buisness.TracFoneFulfillmentKit
    Public Class TFFK_BYOP_Kitting
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

        Public Function getActiveKittingSetUp(ByVal booAddSelectRow As Boolean, ByVal iProcessType_ID As Integer, Optional ByVal bAllColumns As Boolean = False) As DataTable
            Dim strSql As String = ""
            Dim dt, dt2 As DataTable
            Dim row As DataRow

            Try
                If bAllColumns Then strSql = "SELECT C.*,D.Model_Desc,D.Model_LDesc" & Environment.NewLine Else strSql = "SELECT C.KMSet_ID, C.Kitting_SetUp" & Environment.NewLine
                strSql &= " FROM production.tTFFK_Kitting_Items_SetMaster C" & Environment.NewLine
                strSql &= " INNER JOIN production.tmodel_items D ON C.Master_Model_ID=D.Model_ID" & Environment.NewLine
                strSql &= " WHERE C.IsActive=1 AND Process_Type_ID=" & iProcessType_ID & Environment.NewLine
                strSql &= " ORDER BY C.KMSet_ID" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, True)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        'Public Function getActiveKittingSetData_Old(ByVal iSetUp_ID As Integer) As DataTable
        '    Dim strSql As String = ""
        '    Dim dt As DataTable

        '    Try
        '        strSql = "SELECT C.Kitting_SetUp,D.Model_Desc AS 'Master_Item',C.UPC,C.ItemUPC,B.Model_Desc AS 'Component','' AS 'SN',A.Qty" & Environment.NewLine
        '        strSql &= " ,F.Model_Desc AS 'Alt_Component','' AS 'Alt_SN',E.Qty AS 'Alt_Qty'" & Environment.NewLine
        '        strSql &= " ,D.Model_LDesc AS 'Master_Desc',B.Model_LDesc AS 'Component_Desc',F.Model_LDesc AS 'Alt_Component_Desc'" & Environment.NewLine
        '        strSql &= " ,A.Component_Type,E.Component_Type AS 'Alt_Component_Type'" & Environment.NewLine
        '        strSql &= " ,C.Master_Model_ID,A.Component_Model_ID,IF(E.Component_Model_ID>0,E.Component_Model_ID ,0) AS 'Alt_Component_Model_ID'" & Environment.NewLine
        '        strSql &= " ,A.KMSet_ID,A.KDSet_ID,IF(E.KASet_ID>0,E.KASet_ID,0) AS 'KASet_ID',IF(E.KDSet_ID>0,E.KDSet_ID,0) AS 'Alt_KDSet_ID',0 AS 'WI_ID',0 AS 'Alt_WI_ID',0 AS 'WR_ID',A.OrderBy,A.IsKeySIM" & Environment.NewLine
        '        strSql &= " ,C.SIM_Qty,C.Alt_SIM_Qty,C.Collateral_Qty,C.PackQtyPerCarton,C.MaxCartonQtyPerPallet,HasItemUPC" & Environment.NewLine
        '        strSql &= " FROM production.ttffk_kitting_items_setdetail A" & Environment.NewLine
        '        strSql &= " INNER JOIN production.tmodel_items B ON A.Component_Model_ID=B.Model_ID" & Environment.NewLine
        '        strSql &= " INNER JOIN production.tTFFK_Kitting_Items_SetMaster C ON A.KMSet_ID=C.KMSet_ID" & Environment.NewLine
        '        strSql &= " INNER JOIN production.tmodel_items D ON C.Master_Model_ID=D.Model_ID" & Environment.NewLine
        '        strSql &= " LEFT JOIN production.ttffk_kitting_items_setdetail_Alt E ON A.KDSet_ID=E.KDSet_ID" & Environment.NewLine
        '        strSql &= " LEFT JOIN production.tmodel_items F ON E.Component_Model_ID=F.Model_ID" & Environment.NewLine
        '        strSql &= " WHERE C.IsActive=1 AND A.KMSet_ID=" & iSetUp_ID & Environment.NewLine
        '        strSql &= " ORDER BY A.KMSet_ID,A.IsKeySIM Desc,A.OrderBy;" & Environment.NewLine


        '        dt = Me._objDataProc.GetDataTable(strSql)

        '        Return dt
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function

        Public Sub getActiveKittingSetData(ByVal iSetUp_ID As Integer, _
                                           ByRef dtSIM As DataTable, _
                                           ByRef dtAltSIM As DataTable, _
                                           ByRef dtOtherComponents As DataTable)
            Dim strSql As String = ""

            Try
                strSql = "SELECT C.Kitting_Setup,D.Model_Desc AS 'Master_Item',C.UPC,C.ItemUPC,B.Model_Desc AS 'Component','' AS 'SN',A.Qty" & Environment.NewLine
                strSql &= " ,D.Model_LDesc AS 'Master_Desc',B.Model_LDesc AS 'Component_Desc'" & Environment.NewLine
                strSql &= " ,C.Master_Model_ID,A.Component_Model_ID,A.Component_Type" & Environment.NewLine
                strSql &= " ,A.KMSet_ID,A.KDSet_ID,0 AS 'KASet_ID',0 AS 'WI_ID',0 AS 'WR_ID',A.OrderBy,A.IsKeySIM" & Environment.NewLine
                strSql &= " ,C.SIM_Qty,C.Alt_SIM_Qty,C.Collateral_Qty,C.PackQtyPerCarton,C.MaxCartonQtyPerPallet,C.HasItemUPC" & Environment.NewLine
                strSql &= " FROM production.ttffk_kitting_items_setdetail A" & Environment.NewLine
                strSql &= " INNER JOIN production.tmodel_items B ON A.Component_Model_ID=B.Model_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tTFFK_Kitting_Items_SetMaster C ON A.KMSet_ID=C.KMSet_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tmodel_items D ON C.Master_Model_ID=D.Model_ID" & Environment.NewLine
                strSql &= " WHERE C.IsActive=1 AND A.Component_Type='SIM' AND A.KMSet_ID=" & iSetUp_ID & Environment.NewLine
                strSql &= " ORDER BY A.KMSet_ID,A.IsKeySIM Desc,A.OrderBy;"

                dtSIM = Me._objDataProc.GetDataTable(strSql)

                strSql = "SELECT C.Kitting_Setup,D.Model_Desc AS 'Master_Item',C.UPC,C.ItemUPC,F.Model_Desc AS 'Component','' AS 'SN',E.Qty" & Environment.NewLine
                strSql &= " ,F.Model_LDesc AS 'Master_Desc',F.Model_LDesc AS 'Component_Desc'" & Environment.NewLine
                strSql &= " ,C.Master_Model_ID,E.Component_Model_ID,E.Component_Type" & Environment.NewLine
                strSql &= " ,A.KMSet_ID,A.KDSet_ID,E.KASet_ID,0 AS 'WI_ID',0 AS 'WR_ID',E.OrderBy,A.IsKeySIM" & Environment.NewLine
                strSql &= " ,C.SIM_Qty,C.Alt_SIM_Qty,C.Collateral_Qty,C.PackQtyPerCarton,C.MaxCartonQtyPerPallet,C.HasItemUPC" & Environment.NewLine
                strSql &= " FROM production.ttffk_kitting_items_setdetail A" & Environment.NewLine
                strSql &= " INNER JOIN production.tmodel_items B ON A.Component_Model_ID=B.Model_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tTFFK_Kitting_Items_SetMaster C ON A.KMSet_ID=C.KMSet_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tmodel_items D ON C.Master_Model_ID=D.Model_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.ttffk_kitting_items_setdetail_Alt E ON A.KDSet_ID=E.KDSet_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tmodel_items F ON E.Component_Model_ID=F.Model_ID" & Environment.NewLine
                strSql &= " WHERE C.IsActive=1 AND E.Component_Type='Alt_SIM' AND A.KMSet_ID=" & iSetUp_ID & Environment.NewLine
                strSql &= " ORDER BY A.KMSet_ID,A.IsKeySIM Desc,A.OrderBy,E.OrderBy;"

                dtAltSIM = Me._objDataProc.GetDataTable(strSql)

                strSql = "SELECT C.Kitting_Setup,D.Model_Desc AS 'Master_Item',C.UPC,C.ItemUPC,B.Model_Desc AS 'Component','' AS 'SN',A.Qty" & Environment.NewLine
                strSql &= " ,D.Model_LDesc AS 'Master_Desc',B.Model_LDesc AS 'Component_Desc'" & Environment.NewLine
                strSql &= " ,C.Master_Model_ID,A.Component_Model_ID,A.Component_Type" & Environment.NewLine
                strSql &= " ,A.KMSet_ID,A.KDSet_ID,0 AS 'KASet_ID',0 AS 'WI_ID',0 AS 'WR_ID',A.OrderBy,A.IsKeySIM" & Environment.NewLine
                strSql &= " ,C.SIM_Qty,C.Alt_SIM_Qty,C.Collateral_Qty,C.PackQtyPerCarton,C.MaxCartonQtyPerPallet,C.HasItemUPC" & Environment.NewLine
                strSql &= " FROM production.ttffk_kitting_items_setdetail A" & Environment.NewLine
                strSql &= " INNER JOIN production.tmodel_items B ON A.Component_Model_ID=B.Model_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tTFFK_Kitting_Items_SetMaster C ON A.KMSet_ID=C.KMSet_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tmodel_items D ON C.Master_Model_ID=D.Model_ID" & Environment.NewLine
                strSql &= " WHERE C.IsActive=1 AND A.Component_Type='Collateral'  AND A.KMSet_ID=" & iSetUp_ID & Environment.NewLine
                strSql &= " ORDER BY A.KMSet_ID,A.IsKeySIM Desc,A.OrderBy;"

                dtOtherComponents = Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        'Public Function getKittingSIM(ByVal dtSetUpKittingData As DataTable) As DataTable
        '    Dim dt As DataTable
        '    Dim filteredRows() As DataRow
        '    Dim row As DataRow
        '    Dim strExp As String = "SIM"

        '    Try
        '        dt = dtSetUpKittingData.Clone

        '        filteredRows = dtSetUpKittingData.Select("Component_Type='" & strExp & "'")

        '        For Each row In filteredRows
        '            dt.ImportRow(row)
        '        Next

        '        Return dt
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function

        'Public Function getKittingAltSIM(ByVal dtSetUpKittingData As DataTable) As DataTable
        '    Dim dt As DataTable
        '    Dim filteredRows() As DataRow
        '    Dim row As DataRow
        '    Dim strExp As String = "Alt_SIM"

        '    Try
        '        dt = dtSetUpKittingData.Clone

        '        filteredRows = dtSetUpKittingData.Select("Alt_Component_Type='" & strExp & "'")

        '        For Each row In filteredRows
        '            dt.ImportRow(row)
        '        Next

        '        Return dt
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function

        'Public Function getKittingOtherComponents(ByVal dtSetUpKittingData As DataTable) As DataTable
        '    Dim dt As DataTable
        '    Dim filteredRows() As DataRow
        '    Dim row As DataRow

        '    Try
        '        dt = dtSetUpKittingData.Clone

        '        filteredRows = dtSetUpKittingData.Select("Component_Type <> 'SIM' OR Alt_Component_Type <> 'Alt_SIM'")

        '        For Each row In filteredRows
        '            dt.ImportRow(row)
        '        Next

        '        Return dt
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function

        Public Function IsKeySIMValid(ByVal dtSIM As DataTable, ByVal iRequiredSIMItem As Integer) As Boolean
            Dim row As DataRow
            Dim bRet As Boolean = False
            Dim iSum As Integer = 0

            Try
                For Each row In dtSIM.Rows
                    If Convert.ToInt32(row("IsKeySIM")) = 1 Then
                        iSum += 1
                    End If
                Next
                If iSum = Convert.ToInt32(iRequiredSIMItem) Then bRet = True

                Return bRet

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function AreSIMDuplicate(ByVal dtSIM As DataTable) As Boolean
            Dim row As DataRow
            Dim bRet As Boolean = False
            Dim arrLstSIMs As New ArrayList()

            Try
                For Each row In dtSIM.Rows
                    If Not arrLstSIMs.Contains(row("Component_Model_ID")) Then
                        arrLstSIMs.Add(row("Component_Model_ID"))
                    End If
                Next

                If Not arrLstSIMs.Count = dtSIM.Rows.Count Then bRet = True

                Return bRet

            Catch ex As Exception
                Throw ex
            End Try

        End Function

        Public Function getAvailableSN(ByVal strSN As String, ByVal iModel_IDs As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSN = strSN.Replace("'", "''")
                strSql = "SELECT  A.WI_ID,C.Model_desc AS 'Part',C.Model_LDesc  AS 'Part_Desc',A.Serial AS 'SN'" & Environment.NewLine
                strSql &= " ,A.KP_ID,A.Model_ID, A.WR_ID" & Environment.NewLine
                strSql &= " FROM warehouse.warehouse_items A" & Environment.NewLine
                strSql &= " INNER JOIN warehouse.warehouse_receipt B ON A.WR_ID=B.WR_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tmodel_items C ON A.Model_ID=C.Model_ID" & Environment.NewLine
                strSql &= " WHERE B.iDataSet_ID=2 AND KP_ID=0 AND A.model_ID in (" & iModel_IDs & ")  AND A.Serial='" & strSN & "';" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getAvailableOtherComponents(ByVal strModel_IDs As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT  A.WI_ID,C.Model_desc AS 'Part',C.Model_LDesc  AS 'Part_Desc',A.Serial AS 'SN'" & Environment.NewLine
                strSql &= " ,B.Receipt_QTY,B.Consumed_Qty, B.Receipt_Qty-B.Consumed_Qty AS 'Available_Qty'" & Environment.NewLine
                strSql &= " ,A.Model_ID, A.WR_ID,A.WI_ID" & Environment.NewLine
                strSql &= " FROM warehouse.warehouse_items A" & Environment.NewLine
                strSql &= " INNER JOIN warehouse.warehouse_receipt B ON A.WR_ID=B.WR_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tmodel_items C ON A.Model_ID=C.Model_ID" & Environment.NewLine
                strSql &= " WHERE B.iDataSet_ID=2 AND A.model_ID IN (" & strModel_IDs & ");" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getReprintLabelData(ByVal strSN As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSN = strSN.Replace("'", "''")

                strSql = "SELECT A.PAck_WO_ID,A.KMSet_ID,A.WIP_No,A.Target_Qty,A.Qty,A.Closed" & Environment.NewLine
                strSql &= " ,B.KP_ID,B.UPC,B.ItemUPC,C.Model_Desc as 'Master_Item',D.SN,B.Model_ID,D.KPD_ID" & Environment.NewLine
                strSql &= " FROM production.ttffk_kitting_Workorder A" & Environment.NewLine
                strSql &= " INNER JOIN production.ttffk_kitting_pack B ON A.Pack_WO_ID=B.Pack_WO_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tmodel_items C ON  B.Model_ID=C.Model_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.ttffk_kitting_packdetail D ON B.KP_ID=D.KP_ID AND D.IsKeySIM=1" & Environment.NewLine
                strSql &= " WHERE D.SN='" & strSN & "';" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getOpenPackWorkOrder(ByVal strWorkStation As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strWorkStation = strWorkStation.Replace("'", "''")
                strSql = "SELECT @row_number:=@row_number+1 AS 'Row',m.* FROM" & Environment.NewLine
                strSql &= " (SELECT B.Kitting_Setup,C.Model_Desc AS 'Master_Items',A.WorkStation" & Environment.NewLine
                strSql &= " ,A.WIP_No,A.Kitting_No,A.Target_Qty,A.Qty,D.User_Name AS 'User',A.DateTime_WO,A.Pack_WO_ID,A.KMSet_ID,B.Master_Model_ID" & Environment.NewLine
                strSql &= " FROM production.ttffk_kitting_Workorder A" & Environment.NewLine
                strSql &= " INNER JOIN production.ttffk_kitting_items_setmaster B ON A.KMSet_ID=B.KMSet_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tmodel_Items C ON B.Master_Model_ID=C.Model_ID" & Environment.NewLine
                strSql &= " LEFT JOIN security.tusers D ON A.UserID=D.User_ID" & Environment.NewLine
                strSql &= " WHERE A.Closed=0 AND WorkStation='" & strWorkStation & "'" & Environment.NewLine
                strSql &= " ORDER BY A.DateTime_WO) m," & Environment.NewLine
                strSql &= " (SELECT @row_number:=0) AS t;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getKittedPackData(ByVal iPack_WO_ID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Try
                strSql = "SELECT * FROM production.ttffk_kitting_pack WHERE Pack_WO_ID=" & iPack_WO_ID & " limit 1;"
                dt = Me._objDataProc.GetDataTable(strSql)
                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getSIM_Model_IDs(ByVal dtSIM As DataTable, ByVal dtAltSIM As DataTable, _
                                         Optional ByRef arrLstModelIDs As ArrayList = Nothing, _
                                         Optional ByRef bIsDuplicatedModelIDs As Boolean = False) As String

            Dim row As DataRow
            Dim iModel_ID As Integer = 0
            Dim strModel_IDs As String = ""
            Dim arrLstModelIDs_Unique As New ArrayList()

            Try
                For Each row In dtSIM.Rows
                    iModel_ID = Convert.ToInt32(row("Component_Model_ID"))
                    If strModel_IDs.Trim.Length = 0 Then
                        strModel_IDs = iModel_ID
                    Else
                        strModel_IDs &= "," & iModel_ID
                    End If
                    If Not arrLstModelIDs_Unique.Contains(iModel_ID) Then arrLstModelIDs_Unique.Add(iModel_ID)
                    arrLstModelIDs.Add(iModel_ID)
                Next
                For Each row In dtAltSIM.Rows
                    iModel_ID = Convert.ToInt32(row("Alt_Component_Model_ID"))
                    If strModel_IDs.Trim.Length = 0 Then
                        strModel_IDs = iModel_ID
                    Else
                        strModel_IDs &= "," & iModel_ID
                    End If
                    If Not arrLstModelIDs_Unique.Contains(iModel_ID) Then arrLstModelIDs_Unique.Add(iModel_ID)
                    arrLstModelIDs.Add(iModel_ID)
                Next

                If Not arrLstModelIDs_Unique.Count = arrLstModelIDs.Count Then bIsDuplicatedModelIDs = True

                Return strModel_IDs

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function IsSerialNumberAlreadyInList(ByVal dtSIM As DataTable, ByVal dtAltSIM As DataTable, ByVal strSN As String) As Boolean
            Dim row As DataRow
            Dim bRet As Boolean = False
            Dim strSN_Local As String = ""

            Try
                For Each row In dtSIM.Rows
                    strSN_Local = Convert.ToString(row("SN"))
                    If strSN_Local.Trim.ToUpper = strSN.Trim.ToUpper Then
                        bRet = True
                        Exit For
                    End If
                Next

                For Each row In dtAltSIM.Rows
                    strSN_Local = Convert.ToString(row("SN"))
                    If strSN_Local.Trim.ToUpper = strSN.Trim.ToUpper Then
                        bRet = True
                        Exit For
                    End If
                Next

                Return bRet
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function AreValidToAdd_SIM_AltSIM(ByVal dtSIM As DataTable, ByVal dtAltSIM As DataTable, ByVal iModel_ID_ToAdd As Integer) As Boolean
            'For only one SN is allowed for one SIM card with any Alt SIM card(s)
            Dim row, row2 As DataRow
            Dim bRet As Boolean = True
            Dim strSN_Local As String = ""
            Dim iModel_ID As Integer = 0
            Dim iKDSet_ID As Integer = 0

            Try
                For Each row In dtSIM.Rows
                    iModel_ID = Convert.ToInt32(row("Component_Model_ID"))
                    iKDSet_ID = Convert.ToInt32(row("KDSet_ID"))
                    strSN_Local = Convert.ToString(row("SN"))
                    If strSN_Local.Trim.Length > 0 AndAlso iModel_ID_ToAdd = iModel_ID Then
                        bRet = False 'found one is filled
                        Exit For
                    Else
                        For Each row2 In dtAltSIM.Rows
                            strSN_Local = Convert.ToString(row("SN"))
                            iModel_ID = Convert.ToInt32(row("Component_Model_ID"))
                            If iKDSet_ID = Convert.ToInt32(row2("KDSet_ID")) AndAlso strSN_Local.Trim.Length > 0 AndAlso iModel_ID_ToAdd = iModel_ID Then
                                bRet = False
                                Exit For
                            End If
                        Next
                    End If
                Next

                Return bRet
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function CreateKittingPackID(ByVal iKMSet_ID As Integer, ByVal strWorkStation As String, ByVal strWIP_No As String, _
                                            ByVal strKitting_No As String, ByVal iTarget_Qty As Integer, ByVal iUserID As Integer) As Integer
            Dim strSql As String = ""
            Dim strDateTime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

            'SELECT * FROM production.ttffk_kitting_WorkOrder;
            'Pack_WO_ID, KMSet_ID, WorkStation, WIP_No, Target_Qty, Qty, Closed, UserID, DateTime_Pack)
            Try
                strWorkStation = strWorkStation.Replace("'", "''") : strKitting_No = strKitting_No.Replace("'", "''")
                strSql = "INSERT INTO production.ttffk_kitting_WorkOrder (KMSet_ID,WorkStation,WIP_No,Kitting_No,Target_Qty,Qty,Closed,UserID,DateTime_WO) "
                strSql &= " VALUES (" & iKMSet_ID & ",'" & strWorkStation & "','" & strWIP_No & "','" & strKitting_No & "'," & iTarget_Qty & ",0,0," & iUserID & ",'" & strDateTime & "');"

                Return Me._objDataProc.GetLastInsertedPrimaryKey(strSql, "ttffk_kitting_WorkOrder")

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function SaveKittedData(ByVal dtSIM As DataTable, ByVal dtAltSIM As DataTable, _
                                       ByVal dtOtherComponents As DataTable, ByVal iMaster_WR_ID As Integer, _
                                       ByVal iPack_WO_ID As Integer, ByVal iUserID As Integer, ByVal bCloseWorkOrder As Boolean, ByRef iKitPack_KP_ID As Integer) As Boolean
            Dim strSql As String = "", strSql2 As String = ""
            Dim dt As DataTable
            Dim dtSIM_Final As DataTable
            Dim row As DataRow
            Dim iKMSet_ID As Integer = 0
            Dim iMaster_Model_ID As Integer = 0
            Dim strUPC As String = ""
            Dim iQty As Integer = 0
            Dim iWI_ID As Integer = 0
            Dim iWR_ID As Integer = 0
            Dim iKP_ID As Integer = 0
            Dim i As Integer = 0, j As Integer = 0
            Dim iIsKeySIM As Integer = 0
            Dim iModel_ID As Integer = 0
            Dim strSN As String = ""
            Dim strWI_IDs As String = ""
            Dim strWR_IDs As String = ""
            Dim strItemUPC As String = ""

            Dim strDateTime As String = ""

            Try
                'Form final SIM datatable
                dtSIM_Final = dtSIM.Clone
                For Each row In dtSIM.Rows
                    If Convert.ToString(row("SN")).Trim.Length > 0 Then
                        dtSIM_Final.ImportRow(row)
                    End If
                Next
                For Each row In dtAltSIM.Rows
                    If Convert.ToString(row("SN")).Trim.Length > 0 Then
                        dtSIM_Final.ImportRow(row)
                    End If
                Next

                'save pack data
                For Each row In dtSIM_Final.Rows
                    iKMSet_ID = Convert.ToInt32(row("KMSet_ID"))
                    iMaster_Model_ID = Convert.ToInt32(row("Master_Model_ID"))
                    strUPC = Convert.ToString(row("UPC"))
                    strItemUPC = Convert.ToString(row("ItemUPC"))
                    iQty = 1 'master item qty always =1
                    'iWI_ID = Convert.ToInt32(row("WI_ID"))
                    Exit For 'the first row
                Next

                strDateTime = Format(Now, "yyyy-MM-dd HH:mm:ss")
                strSql = "INSERT INTO production.ttffk_kitting_pack (Pack_WO_ID, UPC,ItemUPC, Model_ID, WR_ID, Qty, UserID, DateTime_Pack) " & _
                         "VALUES (" & _
                         iPack_WO_ID & ",'" & strUPC & "','" & strItemUPC & "'," & iMaster_Model_ID & "," & iMaster_WR_ID & "," & iQty & "," & iUserID & ",'" & strDateTime & "');"

                iKP_ID = Me._objDataProc.GetLastInsertedPrimaryKey(strSql, "ttffk_kitting_pack")
                iKitPack_KP_ID = iKP_ID
                If Not iKP_ID > 0 Then Return False

                strSql = "UPDATE warehouse.warehouse_receipt SET Consumed_Qty=Consumed_Qty+" & iQty & " WHERE WR_ID=" & iMaster_WR_ID
                i = Me._objDataProc.ExecuteNonQuery(strSql)
                If bCloseWorkOrder Then
                    strSql = "UPDATE production.ttffk_kitting_WorkOrder SET Qty=Qty+1, Closed=1 WHERE Pack_WO_ID=" & iPack_WO_ID
                    i += Me._objDataProc.ExecuteNonQuery(strSql)
                Else
                    strSql = "UPDATE production.ttffk_kitting_WorkOrder SET Qty=Qty+1 WHERE Pack_WO_ID=" & iPack_WO_ID
                    i += Me._objDataProc.ExecuteNonQuery(strSql)
                End If


                'Save SIM data
                j = 0

                strSql = "INSERT INTO production.ttffk_kitting_packdetail (KP_ID, Model_ID, SN, WI_ID, Qty, IsKeySIM, UserID, DateTime_Pack) "
                strSql &= "VALUES "
                For Each row In dtSIM_Final.Rows
                    j += 1
                    iModel_ID = Convert.ToInt32(row("Component_Model_ID"))
                    strSN = Convert.ToString(row("SN"))
                    iQty = Convert.ToInt32(row("Qty"))
                    iWI_ID = Convert.ToInt32(row("WI_ID"))
                    If j = 1 Then strWI_IDs = iWI_ID Else strWI_IDs &= "," & iWI_ID
                    iIsKeySIM = Convert.ToInt32(row("IsKeySIM"))
                    strDateTime = Format(Now, "yyyy-MM-dd HH:mm:ss")

                    strSql &= "(" & iKP_ID & "," & iModel_ID & ",'" & strSN & "'," & iWI_ID & "," & iQty & "," & iIsKeySIM & "," & iUserID & ",'" & strDateTime & "')"
                    If j = dtSIM_Final.Rows.Count Then strSql &= ";" Else strSql &= ","
                Next
                i += Me._objDataProc.ExecuteNonQuery(strSql)
                strSql = "UPDATE warehouse.warehouse_items SET KP_ID=1 WHERE WI_ID IN (" & strWI_IDs & ");"
                i += Me._objDataProc.ExecuteNonQuery(strSql)

                'Other components (items/models)
                j = 0
                strSql = "INSERT INTO production.ttffk_kitting_packdetail (KP_ID, Model_ID, SN, WR_ID, Qty, UserID, DateTime_Pack) "
                strSql &= "VALUES "
                strSql2 = "UPDATE(Warehouse.warehouse_receipt) "
                strSql2 &= "SET Consumed_QTY = CASE WR_ID "
                For Each row In dtOtherComponents.Rows
                    j += 1
                    iModel_ID = Convert.ToInt32(row("Component_Model_ID"))
                    strSN = Convert.ToString(row("SN"))
                    iQty = Convert.ToInt32(row("Qty"))
                    iWR_ID = Convert.ToInt32(row("WR_ID"))
                    If strWR_IDs.Trim.Length = 0 Then strWR_IDs = iWR_ID.ToString Else strWR_IDs &= "," & iWR_ID.ToString
                    strSql2 &= " WHEN " & iWR_ID.ToString & " THEN  Consumed_QTY+" & iQty.ToString
                    strDateTime = Format(Now, "yyyy-MM-dd HH:mm:ss")
                    strSql &= "(" & iKP_ID & "," & iModel_ID & ",'" & strSN & "'," & iWR_ID & "," & iQty & "," & iUserID & ",'" & strDateTime & "')"
                    If j = dtOtherComponents.Rows.Count Then strSql &= ";" Else strSql &= ","
                Next
                i += Me._objDataProc.ExecuteNonQuery(strSql)
                strSql2 &= " END WHERE WR_ID in (" & strWR_IDs & ");"
                i += Me._objDataProc.ExecuteNonQuery(strSql2)

                Return True
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        'Public Function IsModelOK(ByVal dtSIM As DataTable, ByVal dtAltSIM As DataTable, ByVal iModel_ID As Integer) As Boolean
        '    Dim row As DataRow
        '    Dim iModel_ID2 As Integer = 0
        '    Dim bRet As Boolean = False

        '    If iModel_ID > 0 Then
        '        For Each row In dtSIM.Rows
        '            iModel_ID2 = Convert.ToInt32(row("Component_Model_ID"))
        '            If iModel_ID2 = iModel_ID Then
        '                Return True
        '            End If
        '        Next
        '        For Each row In dtAltSIM.Rows
        '            iModel_ID2 = Convert.ToInt32(row("Alt_Component_Model_ID"))
        '            If iModel_ID2 = iModel_ID Then
        '                Return True
        '            End If
        '        Next
        '    End If

        '    Return False
        'End Function

        Public Function getTFFK_LabelPrinterName(ByVal iProcessType_ID As Integer, ByVal strWorkstationName As String, ByVal iKlb_ID As Integer) As String
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim row As DataRow
            Dim strRetPrinterName As String = ""
            'Process_Type, Label_Desc, Workstation, Printer_Name, Klb_ID, KLPRT_ID

            Try
                strWorkstationName = strWorkstationName.Replace("'", "''")

                strSql = "SELECT A.Process_Type,A.Label_Desc,IF(B.Workstation IS NULL OR LENGTH(TRIM(B.Workstation))=0, '',TRIM(B.Workstation)) AS 'Workstation'" & Environment.NewLine
                strSql &= " ,IF(B.Printer_Name IS NULL OR LENGTH(TRIM(B.Printer_Name))=0, '',TRIM(B.Printer_Name)) AS 'Printer_Name'" & Environment.NewLine
                strSql &= " ,A.Klb_ID,IF(B.KLPRT_ID>0,B.KLPRT_ID,0) AS 'KLPRT_ID'" & Environment.NewLine
                strSql &= " FROM production.ttffk_kitting_labels A" & Environment.NewLine
                strSql &= " LEFT JOIN production.ttffk_kitting_labelprinters B ON A.klb_ID=B.klb_ID" & Environment.NewLine
                strSql &= " WHERE A.Process_Type_ID=" & iProcessType_ID & " AND B.Workstation='" & strWorkstationName & "' AND A.Klb_ID=" & iKlb_ID & ";" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)
                For Each row In dt.Rows
                    strRetPrinterName = Convert.ToString(row("Printer_Name")).Trim
                Next
                Return strRetPrinterName
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        'Public Function getPack_ItemSku_LabelPrinterName() As String
        '    Dim strSql As String = ""
        '    Dim dt As DataTable
        '    Dim row As DataRow
        '    Dim strRetPrinterName As String = ""
        '    'KLPRT_ID, Label_Desc, Printer_Name, UserID, UpdatedDateTime
        '    Try
        '        strSql = "SELECT * FROM ttffk_kitting_labelprinters WHERE Label_Desc='Pack SKU Label';"
        '        dt = Me._objDataProc.GetDataTable(strSql)
        '        For Each row In dt.Rows
        '            strRetPrinterName = Convert.ToString(row("Printer_Name")).Trim
        '        Next
        '        Return strRetPrinterName
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function

        'Public Function getPack_UPCA_LabelPrinterName() As String
        '    Dim strSql As String = ""
        '    Dim dt As DataTable
        '    Dim row As DataRow
        '    Dim strRetPrinterName As String = ""
        '    'KLPRT_ID, Label_Desc, Printer_Name, UserID, UpdatedDateTime
        '    Try
        '        strSql = "SELECT * FROM ttffk_kitting_labelprinters WHERE Label_Desc= 'Pack UPC_A Label';"
        '        dt = Me._objDataProc.GetDataTable(strSql)
        '        For Each row In dt.Rows
        '            strRetPrinterName = Convert.ToString(row("Printer_Name")).Trim
        '        Next
        '        Return strRetPrinterName
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function

        'Public Function getMasterCarton_LabelPrinterName() As String
        '    Dim strSql As String = ""
        '    Dim dt As DataTable
        '    Dim row As DataRow
        '    Dim strRetPrinterName As String = ""
        '    'KLPRT_ID, Label_Desc, Printer_Name, UserID, UpdatedDateTime
        '    Try
        '        strSql = "SELECT * FROM ttffk_kitting_labelprinters WHERE Label_Desc='Carton Label';"
        '        dt = Me._objDataProc.GetDataTable(strSql)
        '        For Each row In dt.Rows
        '            strRetPrinterName = Convert.ToString(row("Printer_Name")).Trim
        '        Next
        '        Return strRetPrinterName
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function


        Public Function PrintPackItemSKU_Label(ByVal strSN As String, _
                                               ByVal strSNBarCode As String, _
                                               ByVal strItemSku As String, _
                                               ByVal strPrinterName As String, _
                                               ByVal iCopyNumber As Integer) As Integer
            Const strReportName As String = "TF_FK_BYOPKitting_Pack_Sku_Label.rpt"
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim objTFMisc As PSS.Data.Buisness.TracFone.clsMisc
            Try
                strSN = strSN.Replace("'", "''").Replace("\", "\\") : strSNBarCode = strSNBarCode.Replace("'", "''").Replace("\", "\\")
                strItemSku = strItemSku.Replace("'", "''")
                strSql = "Select '" & strSN & "' as SN " & Environment.NewLine
                strSql &= ", '" & strSNBarCode & "' as SNBarCode " & Environment.NewLine
                strSql &= ", '" & strItemSku & "' as ItemSku" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                '**********************
                'Print Box lablel
                '**********************
                Try
                    objTFMisc = New PSS.Data.Buisness.TracFone.clsMisc()
                    objTFMisc.PrintCrystalReportLabel(dt, strReportName, iCopyNumber, strPrinterName)
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

        Public Function PrintPackUPCA_Label(ByVal strItemSku As String, _
                                            ByVal strUPC_A As String, _
                                            ByVal strPrinterName As String, _
                                            ByVal iCopyNumber As Integer) As Integer
            Const strReportName As String = "TF_FK_BYOPKitting_Pack_UPC_Label.rpt"
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim objTFMisc As PSS.Data.Buisness.TracFone.clsMisc
            Try
                strUPC_A = strUPC_A.Replace("'", "''").Replace("\", "\\") : strItemSku = strItemSku.Replace("'", "''").Replace("\", "\\")

                strSql = "Select '" & strItemSku & "' as ItemSku " & Environment.NewLine
                strSql &= ", '" & strUPC_A & "' as UPC_A " & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                '**********************
                'Print Box lablel
                '**********************
                Try
                    objTFMisc = New PSS.Data.Buisness.TracFone.clsMisc()
                    objTFMisc.PrintCrystalReportLabel(dt, strReportName, iCopyNumber, strPrinterName)
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


        ' Build Master Carton------------------------------------------------------------------------------------------------------------
        Public Function getMasterCartonAvailableItemData(ByVal strSN As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSN = strSN.Replace("'", "''")
                strSql = "SELECT 0 as 'Row',A.Pack_WO_ID,A.KMSet_ID,A.WIP_No,A.Target_Qty,A.Qty,A.Closed" & Environment.NewLine
                strSql &= " ,B.KP_ID,B.UPC,B.ItemUPC,C.Model_Desc as 'Master_Item',D.SN,B.Model_ID,D.KPD_ID,B.Carton_ID" & Environment.NewLine
                strSql &= " FROM production.ttffk_kitting_Workorder A" & Environment.NewLine
                strSql &= " INNER JOIN production.ttffk_kitting_pack B ON A.Pack_WO_ID=B.Pack_WO_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tmodel_items C ON  B.Model_ID=C.Model_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.ttffk_kitting_packdetail D ON B.KP_ID=D.KP_ID AND D.IsKeySIM=1" & Environment.NewLine
                strSql &= " WHERE B.Carton_ID=0 AND D.SN='" & strSN & "';" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function CreateMasterCartonName(ByVal strWorkstation As String, ByRef iCarton_ID As Integer, Optional ByVal strNewCartonName_PreFix As String = "") As String
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim strCartonName As String = ""
            'Carton_ID, Carton_Name, ItemQty, Model_ID, Closed, UserID, DateTime_Carton, WorkStation
            Try
                iCarton_ID = 0
                strWorkstation = strWorkstation.Replace("'", "''") : strNewCartonName_PreFix = strNewCartonName_PreFix.Replace("'", "''")
                strSql = "INSERT INTO production.ttffk_kitting_Carton (WorkStation) VALUES ('" & strWorkstation & "');"
                iCarton_ID = Me._objDataProc.GetLastInsertedPrimaryKey(strSql, "ttffk_kitting_Carton")

                If strNewCartonName_PreFix.Trim.Length > 0 Then
                    strCartonName = strNewCartonName_PreFix & iCarton_ID.ToString.PadLeft(10, "0")
                    strSql = "UPDATE production.ttffk_kitting_Carton SET Carton_Name = '" & strCartonName & "' WHERE Carton_ID=" & iCarton_ID
                    Me._objDataProc.ExecuteNonQuery(strSql)
                Else
                    strSql = "SELECT * FROM production.ttffk_kitting_Carton WHERE Carton_ID=" & iCarton_ID
                    dt = Me._objDataProc.GetDataTable(strSql)

                    If dt.Rows.Count > 0 Then strCartonName = Convert.ToString(dt.Rows(0).Item("Carton_Name"))
                End If

                Return strCartonName

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function SaveMasterCartonData(ByVal iCarton_ID As Integer, ByVal iItemQty As Integer, ByVal iModel_ID As Integer, _
                                             ByVal iClosed As Integer, ByVal iUserID As Integer, ByVal strKP_IDs As String, ByVal iInnerCartonQty As Integer) As Integer
            Dim strSql As String = ""
            Dim strDatetime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            Dim i As Integer = 0

            'Carton_ID, Carton_Name, ItemQty, InnerCartonQty, Model_ID, Closed, UserID, DateTime_Carton, WorkStation
            Try
                strSql = "UPDATE production.ttffk_kitting_Carton SET ItemQty=" & iItemQty & ",InnerCartonQty=" & iInnerCartonQty & ",Model_ID=" & iModel_ID & ",Closed=" & _
                         iClosed & ",UserID=" & iUserID & ",DateTime_Carton='" & strDatetime & "' WHERE Carton_ID=" & iCarton_ID & ";"
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                strSql = "UPDATE production.ttffk_kitting_pack SET Carton_ID=" & iCarton_ID & " WHERE KP_ID IN (" & strKP_IDs & ");"
                i += Me._objDataProc.ExecuteNonQuery(strSql)

                Return i

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function IsCartonClosed(ByVal iCarton_ID As Integer) As Boolean
            Dim strSql As String = ""
            Dim strDatetime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            Dim dt As DataTable
            Dim bRet As Boolean = False

            Try
                strSql = "SELECT * FROM production.ttffk_kitting_Carton  WHERE Carton_ID=" & iCarton_ID & " AND Closed=0;"
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

        Public Function PrintMasterCarton_Label(ByVal strUPC As String, _
                                                ByVal strUPCCode As String, _
                                                ByVal iQty As Integer, _
                                                ByVal strQtyCode As String, _
                                                ByVal strItem As String, _
                                                ByVal strItemCode As String, _
                                                ByVal strTag As String, _
                                                ByVal strTagCode As String, _
                                                ByVal strSN1 As String, _
                                                ByVal strSN1Code As String, _
                                                ByVal strSN2 As String, _
                                                ByVal strSN2Code As String, _
                                                ByVal strSN3 As String, _
                                                ByVal strSN3Code As String, _
                                                ByVal strSN4 As String, _
                                                ByVal strSN4Code As String, _
                                                ByVal strSN5 As String, _
                                                ByVal strSN5Code As String, _
                                                ByVal strPrinterName As String, _
                                                ByVal iCopyNumber As Integer) As Integer
            Const strReportName As String = "TF_FK_BYOPKitting_Carton_Label.rpt"
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim objTFMisc As PSS.Data.Buisness.TracFone.clsMisc
            Try
                strUPC = strUPC.Replace("'", "''").Replace("\", "\\")
                strUPCCode = strUPCCode.Replace("'", "''").Replace("\", "\\")
                strQtyCode = strQtyCode.Replace("'", "''").Replace("\", "\\")
                strItem = strItem.Replace("'", "''").Replace("\", "\\")
                strItemCode = strItemCode.Replace("'", "''").Replace("\", "\\")
                strTag = strTag.Replace("'", "''").Replace("\", "\\")
                strTagCode = strTagCode.Replace("'", "''").Replace("\", "\\")
                strSN1 = strSN1.Replace("'", "''").Replace("\", "\\")
                strSN1Code = strSN1Code.Replace("'", "''").Replace("\", "\\")
                strSN2 = strSN2.Replace("'", "''").Replace("\", "\\")
                strSN2Code = strSN2Code.Replace("'", "''").Replace("\", "\\")
                strSN3 = strSN3.Replace("'", "''").Replace("\", "\\")
                strSN3Code = strSN3Code.Replace("'", "''").Replace("\", "\\")
                strSN4 = strSN4.Replace("'", "''").Replace("\", "\\")
                strSN4Code = strSN4Code.Replace("'", "''").Replace("\", "\\")
                strSN5 = strSN5.Replace("'", "''").Replace("\", "\\")
                strSN5Code = strSN5Code.Replace("'", "''").Replace("\", "\\")


                strSql = "Select '" & strUPC & "' as UPC" & Environment.NewLine
                strSql &= ",'" & strUPCCode & "' as UPCCode" & Environment.NewLine
                strSql &= "," & iQty & " as Qty" & Environment.NewLine
                strSql &= ",'" & strQtyCode & "' as QtyCode" & Environment.NewLine
                strSql &= ",'" & strItem & "' as Item" & Environment.NewLine
                strSql &= ",'" & strItemCode & "' as ItemCode" & Environment.NewLine
                strSql &= ",'" & strTag & "' as Tag" & Environment.NewLine
                strSql &= ",'" & strTagCode & "' as TagCode" & Environment.NewLine
                strSql &= ",'" & strSN1 & "' as SN1" & Environment.NewLine
                strSql &= ",'" & strSN1Code & "' as SN1Code" & Environment.NewLine
                strSql &= ",'" & strSN2 & "' as SN2" & Environment.NewLine
                strSql &= ",'" & strSN2Code & "' as SN2Code" & Environment.NewLine
                strSql &= ",'" & strSN3 & "' as SN3" & Environment.NewLine
                strSql &= ",'" & strSN3Code & "' as SN3Code" & Environment.NewLine
                strSql &= ",'" & strSN4 & "' as SN4" & Environment.NewLine
                strSql &= ",'" & strSN4Code & "' as SN4Code" & Environment.NewLine
                strSql &= ",'" & strSN5 & "' as SN5" & Environment.NewLine
                strSql &= ",'" & strSN5Code & "' as SN5Code" & Environment.NewLine


                dt = Me._objDataProc.GetDataTable(strSql)

                '**********************
                'Print Box lablel
                '**********************
                Try
                    objTFMisc = New PSS.Data.Buisness.TracFone.clsMisc()
                    objTFMisc.PrintCrystalReportLabel(dt, strReportName, iCopyNumber, strPrinterName)
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

        Public Function getCartonLabelData(ByVal strCartonName As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strCartonName = strCartonName.Replace("'", "''")

                strSql = "SELECT @row_number:=@row_number+1 AS 'Row',m.* FROM" & Environment.NewLine
                strSql &= " (SELECT A.Pack_WO_ID,A.KMSet_ID,A.WIP_No,A.Target_Qty,A.Qty,A.Closed" & Environment.NewLine
                strSql &= " ,B.KP_ID,B.UPC,B.ItemUPC,E.Carton_Name,E.ItemQty,C.Model_Desc as 'Master_Item',D.SN,B.Model_ID,D.KPD_ID,B.Carton_ID" & Environment.NewLine
                strSql &= " FROM production.ttffk_kitting_Workorder A" & Environment.NewLine
                strSql &= " INNER JOIN production.ttffk_kitting_pack B ON A.Pack_WO_ID=B.Pack_WO_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tmodel_items C ON  B.Model_ID=C.Model_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.ttffk_kitting_packdetail D ON B.KP_ID=D.KP_ID AND D.IsKeySIM=1" & Environment.NewLine
                strSql &= " INNER JOIN production.ttffk_kitting_carton E ON B.Carton_ID=E.Carton_ID" & Environment.NewLine
                strSql &= " WHERE E.Carton_Name='" & strCartonName & "') m," & Environment.NewLine
                strSql &= " (SELECT @row_number:=0) AS t;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        ' Build Pallet------------------------------------------------------------------------------------------------------------
        Public Function getPalletAvailableCartonData(ByVal strCartonName As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim iCarton_ID As Integer = 0
            Dim row As DataRow
            Dim dtTmp As DataTable

            Try
                strCartonName = strCartonName.Replace("'", "''")
                strSql = "SELECT 0 as 'Row',A.*,B.Model_Desc as 'Master_Item',0 as 'Process_Type_ID',0 as 'MaxCartonQtyPerPallet'" & Environment.NewLine
                strSql &= " FROM production.ttffk_kitting_carton A" & Environment.NewLine
                strSql &= " INNER JOIN production.tmodel_items B ON A.Model_ID=B.Model_ID" & Environment.NewLine
                strSql &= " WHERE A.Carton_Name ='" & strCartonName & "' AND A.Pallet_ID=0;"
                dt = Me._objDataProc.GetDataTable(strSql)

                For Each row In dt.Rows 'should be 1 row
                    'KMSet_ID, Kitting_Setup, Master_Model_ID, UPC, ItemUPC, SIM_Qty, Collateral_Qty, Alt_SIM_Qty, HasItemUPC, PackQtyPerCarton, MaxCartonQtyPerPallet, PackQtyPerInnerCarton
                    ', GTIN_InnerCarton_UPC, GTIN_MasterCarton_UPC, VersionControl, CountryOfOrigin, ExpirationDate, Process_Type_ID, UserID, UpdateDateTime, IsActive
                    iCarton_ID = Convert.ToInt32(row("Carton_ID"))
                    strSql = "SELECT A.* from production.tTFFK_Kitting_Items_SetMaster A" & Environment.NewLine
                    strSql &= " INNER JOIN production.ttffk_kitting_workorder B ON A.KMSet_ID=B.KMSet_ID" & Environment.NewLine
                    strSql &= " INNER JOIN production.ttffk_kitting_pack C ON B.Pack_WO_ID=C.Pack_WO_ID" & Environment.NewLine
                    strSql &= " WHERE C.Carton_ID=" & iCarton_ID & " LIMIT 1" & Environment.NewLine
                    dtTmp = Me._objDataProc.GetDataTable(strSql)
                    If dtTmp.Rows.Count > 0 Then
                        row.BeginEdit()
                        row("Process_Type_ID") = Convert.ToInt32(dtTmp.Rows(0).Item("Process_Type_ID"))
                        row("MaxCartonQtyPerPallet") = Convert.ToInt32(dtTmp.Rows(0).Item("MaxCartonQtyPerPallet"))
                        row.AcceptChanges()
                    End If
                Next

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function CreatePalletName(ByVal strWorkstation As String, ByRef iPallet_ID As Integer, Optional ByVal strNewPalletName_PreFix As String = "") As String
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim strPalletName As String = ""
            'Pallet_ID, Pallet_Name, Carton_Qty, Model_ID, Closed, UserID, DateTime_Carton, WorkStation
            Try
                iPallet_ID = 0
                strWorkstation = strWorkstation.Replace("'", "''")
                strSql = "INSERT INTO production.ttffk_kitting_pallet (WorkStation) VALUES ('" & strWorkstation & "');"
                iPallet_ID = Me._objDataProc.GetLastInsertedPrimaryKey(strSql, "ttffk_kitting_pallet")

                If strNewPalletName_PreFix.Trim.Length > 0 Then
                    strPalletName = strNewPalletName_PreFix & iPallet_ID.ToString.PadLeft(10, "0")
                    strSql = "UPDATE production.ttffk_kitting_pallet SET Pallet_Name = '" & strPalletName & "' WHERE pallet_ID=" & iPallet_ID
                    Me._objDataProc.ExecuteNonQuery(strSql)
                Else
                    strSql = "SELECT * FROM production.ttffk_kitting_pallet WHERE pallet_ID=" & iPallet_ID
                    dt = Me._objDataProc.GetDataTable(strSql)

                    If dt.Rows.Count > 0 Then strPalletName = Convert.ToString(dt.Rows(0).Item("Pallet_Name"))
                End If

                Return strPalletName

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function IsPalletClosed(ByVal iPallet_ID As Integer) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim bRet As Boolean = False

            Try
                strSql = "SELECT * FROM production.ttffk_kitting_pallet  WHERE Pallet_ID=" & iPallet_ID & " AND Closed=0;"
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

        Public Function IsCartonBuiltInPallet(ByVal strCartonName As String) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim bRet As Boolean = False

            Try
                strCartonName = strCartonName.Replace("'", "''")
                strSql = "SELECT * FROM production.ttffk_kitting_carton  WHERE Carton_Name='" & strCartonName & "' AND Pallet_ID>0;"
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    bRet = True
                Else
                    bRet = False
                End If

                Return bRet

            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing
            End Try
        End Function

        Public Function SavePalletData(ByVal iPallet_ID As Integer, ByVal iCartonQty As Integer, ByVal iModel_ID As Integer, _
                                       ByVal iClosed As Integer, ByVal iUserID As Integer, ByVal strCarton_IDs As String) As Integer
            Dim strSql As String = ""
            Dim strDatetime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            Dim i As Integer = 0

            'Pallet_ID, Pallet_Name, Carton_Qty, Model_ID, Closed, UserID, DateTime_Pallet, WorkStation
            Try
                strSql = "UPDATE production.ttffk_kitting_pallet SET Carton_Qty=" & iCartonQty & ",Model_ID=" & iModel_ID & ",Closed=" & _
                         iClosed & ",UserID=" & iUserID & ",DateTime_Pallet='" & strDatetime & "' WHERE pallet_ID=" & iPallet_ID & ";"
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                strSql = "UPDATE production.ttffk_kitting_carton SET pallet_ID=" & iPallet_ID & " WHERE Carton_ID IN (" & strCarton_IDs & ");"
                i += Me._objDataProc.ExecuteNonQuery(strSql)

                Return i

            Catch ex As Exception
                Throw ex
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
            Const strReportName As String = "TF_FK_BYOPKitting_Pallet_Label.rpt"
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
                    objTFMisc.PrintCrystalReportLabel(dt, strReportName, iCopyNumber, strPrinterName)
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


        'Public Function getPallet_LabelPrinterName() As String
        '    Dim strSql As String = ""
        '    Dim dt As DataTable
        '    Dim row As DataRow
        '    Dim strRetPrinterName As String = ""
        '    'KLPRT_ID, Label_Desc, Printer_Name, UserID, UpdatedDateTime
        '    Try
        '        strSql = "SELECT * FROM ttffk_kitting_labelprinters WHERE Label_Desc='Pallet Label';"
        '        dt = Me._objDataProc.GetDataTable(strSql)
        '        For Each row In dt.Rows
        '            strRetPrinterName = Convert.ToString(row("Printer_Name")).Trim
        '        Next
        '        Return strRetPrinterName
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function

        Public Function getPalletLabelData(ByVal strPalletName As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable, dtTmp As DataTable
            Dim iPallet_ID As Integer = 0
            Dim row As DataRow
            'Pallet_ID, Pallet_Name, Carton_Qty, Model_ID, Closed, UserID, DateTime_Pallet, WorkStation, Master_Item, Cumputed_Carton_Qty, DateTime_Pallet, Pallet_Date

            Try
                strPalletName = strPalletName.Replace("'", "''")
                strSql = "SELECT A.*,C.Model_desc as 'Master_Item',0 AS 'Cumputed_Carton_Qty',A.DateTime_Pallet,DATE_FORMAT(A.DateTime_Pallet,'%d/%m/%Y') as 'Pallet_Date'" & Environment.NewLine
                strSql &= " FROM production.ttffk_kitting_pallet A" & Environment.NewLine
                strSql &= " INNER JOIN  production.tmodel_items C ON A.Model_ID=C.Model_ID" & Environment.NewLine
                strSql &= " WHERE A.Closed=1 AND A.Pallet_Name='" & strPalletName & "';" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    For Each row In dt.Rows
                        iPallet_ID = Convert.ToInt32(row("Pallet_ID"))
                        strSql = "SELECT * FROM production.ttffk_kitting_carton WHERE Pallet_ID=" & iPallet_ID & ";"
                        dtTmp = Me._objDataProc.GetDataTable(strSql)
                        row.BeginEdit() : row("Cumputed_Carton_Qty") = dtTmp.Rows.Count : row.AcceptChanges()
                    Next
                End If

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        'Kitting Set Up=======================================================================================================================================================
        Public Function getAllFulfillmentKittingModels(ByVal bBYOPOnly As Boolean) As DataTable
            Dim strSql As String = ""
            'Row, Model_ID, Model, IsBYOP_Model, Model_Desc, Class, Subclass, Techology, UPC, Weight, Height, Width, Length, UPC_DCode_ID, Class_DCode_ID, SubClass_DCode_ID, Tech_Dcode_ID, Prod_ID, Has_BC, User_ID, UpdateDate
            'BYOP only: Row, Model_ID, Model, Qty, IsBYOP_Model, Model_Desc, Class, Subclass, Techology, UPC, Weight, Height, Width, Length, ss_DCode_ID, SubClass_DCode_ID, Tech_Dcode_ID, Prod_ID, Has_BC, User_ID, UpdateDate, Parent_Model, IsKeySIM, Parent_Model_ID

            Try
                strSql = "SELECT @row_number:=@row_number+1 AS 'Row',m.* FROM" & Environment.NewLine
                strSql &= " (Select A.Model_ID,A.Model_Desc AS 'Model'" & Environment.NewLine

                If bBYOPOnly Then strSql &= " ,1 as 'Qty'" & Environment.NewLine

                strSql &= " ,IF(A.IsBYOP_Model=1,'Yes','No') as 'IsBYOP_Model',A.Model_LDesc AS 'Model_Desc'" & Environment.NewLine
                strSql &= " ,C.DCode_SDesc as 'Class',D.DCode_SDesc as 'Subclass',E.DCode_SDesc as 'Techology',B.Dcode_SDesc AS 'UPC',A.Weight,A.Height,A.Width,A.Length" & Environment.NewLine
                strSql &= " ,A.UPC_DCode_ID,A.Class_DCode_ID,A.SubClass_DCode_ID,A.Tech_Dcode_ID,A.Prod_ID" & Environment.NewLine
                strSql &= " ,A.Has_BC,A.User_ID,A.UpdateDate" & Environment.NewLine

                If bBYOPOnly Then strSql &= " , 'Alternative SIM of ' as 'Parent_Model',0 as 'IsKeySIM',0 as 'Parent_Model_ID'" & Environment.NewLine

                strSql &= " from production.tmodel_items A" & Environment.NewLine
                strSql &= " left join production.lcodesdetail B ON A.UPC_DCode_ID=B.DCode_ID" & Environment.NewLine
                strSql &= " left join production.lcodesdetail C ON A.Class_DCode_ID=C.DCode_ID" & Environment.NewLine
                strSql &= " left join production.lcodesdetail D ON A.SubClass_DCode_ID=D.DCode_ID" & Environment.NewLine
                strSql &= " left join production.lcodesdetail E ON A.Tech_DCode_ID=E.DCode_ID" & Environment.NewLine

                If bBYOPOnly Then
                    strSql &= " Where A.IsBYOP_Model=1) m," & Environment.NewLine
                Else
                    strSql &= " ) m," & Environment.NewLine
                End If

                strSql &= " (SELECT @row_number:=0) AS t;" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)


            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function UpdateModelIsBYOP(ByVal iModel_ID As Integer, ByVal iIsBYOP_Yes1No0 As Integer) As Integer
            Dim strSql As String = ""
            Dim strDatetime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

            Try
                strSql = "UPDATE production.tmodel_items  SET IsBYOP_Model=" & iIsBYOP_Yes1No0 & " WHERE Model_ID=" & iModel_ID & ";"
                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function CreateKittingSetupProfileID(ByVal strMasterItem As String, ByVal iActive As Integer, _
                                                    ByRef strSetupProfileName As String, ByRef strPostFix As String, _
                                                    ByVal iUserID As Integer, ByVal strDateTime As String) As Integer
            Dim strSql As String = ""
            Dim iKMSet_ID As Integer = 0
            Dim i As Integer = 0

            Try
                strMasterItem = strMasterItem.Replace("'", "''")
                strSql = "INSERT INTO production.ttffk_kitting_items_setmaster (Kitting_Setup,IsActive,UserID,UpdateDateTime) "
                strSql &= "VALUES ('" & strMasterItem & "'," & iActive & "," & iUserID & ",'" & strDateTime & " ');"
                iKMSet_ID = Me._objDataProc.GetLastInsertedPrimaryKey(strSql, "ttffk_kitting_items_setmaster")

                strPostFix = " (S" & iKMSet_ID.ToString & ")"
                strSetupProfileName = strMasterItem & strPostFix
                strSql = "UPDATE production.ttffk_kitting_items_setmaster SET Kitting_Setup='" & strSetupProfileName & "' WHERE KMSet_ID=" & iKMSet_ID
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                Return iKMSet_ID

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function SaveKittingSetupProfileData(ByVal iKMSet_ID As Integer, ByVal iActive As Integer, _
                                                    ByVal dtMasterItem As DataTable, ByVal dtSIM As DataTable, _
                                                    ByVal dtAltSIM As DataTable, ByVal dtCollateral As DataTable, _
                                                    ByVal strUPC14 As String, ByVal strItemUPC As String, ByVal iHasItemUPC As Integer, _
                                                    ByVal iQtyPerCarton As Integer, ByVal iMaxQtyPerPallet As Integer, _
                                                    ByVal iUserID As Integer, ByVal strDateTime As String) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0, j As Integer = 0, k As Integer = 0
            Dim iModel_ID_MasterItem As Integer = 0
            Dim iModel_ID_SIM As Integer = 0
            Dim iModel_ID_AltSIM As Integer = 0
            Dim iModel_ID_AltSIM_Parent As Integer = 0
            Dim iModel_ID_Collateral As Integer = 0
            Dim row, row2 As DataRow
            Dim iQty As Integer = 0
            Dim iIsKeySIM As Integer = 0
            Dim iKDSet_ID As Integer = 0

            Try
                'ttffk_kitting_items_setmaster
                'KMSet_ID, Kitting_Setup, Master_Model_ID, UPC, ItemUPC, SIM_Qty, Collateral_Qty, Alt_SIM_Qty, HasItemUPC, 
                'PackQtyPerCarton, MaxCartonQtyPerPallet, UserID, UpdateDateTime, IsActive
                iModel_ID_MasterItem = Convert.ToInt32(dtMasterItem.Rows(0).Item("Model_ID"))
                strSql = "UPDATE production.ttffk_kitting_items_setmaster SET Master_Model_ID=" & iModel_ID_MasterItem & ",UPC='" & strUPC14 & "',ItemUPC='" & strItemUPC & "'" & _
                         ",SIM_Qty=" & dtSIM.Rows.Count & ",Collateral_Qty=" & dtCollateral.Rows.Count & ",Alt_SIM_Qty=" & dtAltSIM.Rows.Count & _
                         ",HasItemUPC=" & iHasItemUPC & ",PackQtyPerCarton=" & iQtyPerCarton & ",MaxCartonQtyPerPallet=" & iMaxQtyPerPallet & _
                         ",UserID=" & iUserID & ",UpdateDateTime='" & strDateTime & "',IsActive=" & iActive & _
                         " WHERE KMSet_ID=" & iKMSet_ID
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                'ttffk_kitting_items_setdetail
                'KDSet_ID, KMSet_ID, Component_Model_ID, Qty, Component_Type, OrderBy, IsKeySIM, UserID, UpdateDateTime
                dtSIM.DefaultView.Sort = "IsKeySIM DESC"
                Dim dtSIMSorted As DataTable = dtSIM.DefaultView.Table
                j = 0 : k = 0
                For Each row In dtSIMSorted.Rows
                    j += 1
                    iModel_ID_SIM = Convert.ToInt32(row("Model_ID"))
                    iQty = Convert.ToInt32(row("Qty"))
                    iIsKeySIM = Convert.ToInt32(row("IsKeySIM"))
                    strSql = "INSERT INTO production.ttffk_kitting_items_setdetail (KMSet_ID,Component_Model_ID,Qty,Component_Type,OrderBy,IsKeySIM,UserID,UpdateDateTime) "
                    strSql &= " VALUES (" & iKMSet_ID & "," & iModel_ID_SIM & "," & iQty & ",'SIM'," & j & "," & iIsKeySIM & "," & iUserID & ",'" & strDateTime & "');"

                    iKDSet_ID = Me._objDataProc.GetLastInsertedPrimaryKey(strSql, "ttffk_kitting_items_setdetail")

                    'ttffk_kitting_items_setdetail_alt 
                    'KASet_ID, KDSet_ID, Component_Model_ID, Qty, Component_Type, OrderBy, UserID, UpdateDateTime
                    For Each row2 In dtAltSIM.Rows
                        iModel_ID_AltSIM = Convert.ToInt32(row2("Model_ID"))
                        iModel_ID_AltSIM_Parent = Convert.ToInt32(row2("Parent_Model_ID"))
                        iQty = Convert.ToInt32(row2("Qty"))
                        If iModel_ID_AltSIM_Parent = iModel_ID_SIM Then
                            k += 1
                            strSql = "INSERT INTO production.ttffk_kitting_items_setdetail_alt (KDSet_ID,Component_Model_ID,Qty,Component_Type,OrderBy,UserID,UpdateDateTime) "
                            strSql &= " VALUES (" & iKDSet_ID & "," & iModel_ID_AltSIM & "," & iQty & ",'Alt_SIM'," & k & "," & iUserID & ",'" & strDateTime & "');"
                            i += Me._objDataProc.ExecuteNonQuery(strSql)
                        End If
                    Next
                Next

                For Each row In dtCollateral.Rows
                    j += 1 'clollateral save the same table, continute to use j  as OrderBy
                    iModel_ID_Collateral = Convert.ToInt32(row("Model_ID"))
                    iQty = Convert.ToInt32(row("Qty"))
                    strSql = "INSERT INTO production.ttffk_kitting_items_setdetail (KMSet_ID,Component_Model_ID,Qty,Component_Type,OrderBy,IsKeySIM,UserID,UpdateDateTime) "
                    strSql &= " VALUES (" & iKMSet_ID & "," & iModel_ID_Collateral & "," & iQty & ",'Collateral'," & j & ",0" & "," & iUserID & ",'" & strDateTime & "');"
                    i += Me._objDataProc.ExecuteNonQuery(strSql)
                Next

                Return i

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getLabelPrinterSetupData(ByVal strWorkstationName As String) As DataTable
            Dim strSql As String = ""
            Dim dt, dt2 As DataTable
            Dim row As DataRow
            Dim iKlb_ID As Integer = 0

            Try
                strWorkstationName = strWorkstationName.Replace("'", "''")

                'strSql = "SELECT @row_number:=@row_number+1 AS 'Row',m.* FROM" & Environment.NewLine
                'strSql &= " (SELECT A.Process_Type,A.Label_Desc,IF(B.Workstation IS NULL OR LENGTH(TRIM(B.Workstation))=0, '',TRIM(B.Workstation)) AS 'Workstation'" & Environment.NewLine
                'strSql &= " ,IF(B.Printer_Name IS NULL OR LENGTH(TRIM(B.Printer_Name))=0, 'Default Printer',TRIM(B.Printer_Name)) AS 'Printer_Name'" & Environment.NewLine
                'strSql &= " ,A.Klb_ID,IF(B.KLPRT_ID>0,B.KLPRT_ID,0) AS 'KLPRT_ID',A.OrderBy" & Environment.NewLine
                'strSql &= " FROM production.ttffk_kitting_labels A" & Environment.NewLine
                'strSql &= " LEFT JOIN production.ttffk_kitting_labelprinters B ON A.klb_ID=B.klb_ID" & Environment.NewLine
                'If strWorkstationName.Trim.Length > 0 Then strSql &= " WHERE B.Workstation='VMZANG'" & Environment.NewLine
                'strSql &= " ORDER BY A.OrderBy,A.Klb_ID) m," & Environment.NewLine
                'strSql &= " (SELECT @row_number:=0) AS t;" & Environment.NewLine

                'Row, Process_Type, Label_Desc, Workstation, Printer_Name,Printer_Name_Old, Klb_ID, KLPRT_ID, Process_Type_ID
                strSql = "SELECT @row_number:=@row_number+1 AS 'Row',m.* FROM" & Environment.NewLine
                strSql &= " (SELECT Process_Type,Label_Desc,'' AS 'Workstation','' AS 'Printer_Name','' AS 'Printer_Name_Old'" & Environment.NewLine
                strSql &= " ,Klb_ID,0 AS 'KLPRT_ID',Process_Type_ID" & Environment.NewLine
                strSql &= " FROM production.ttffk_kitting_labels" & Environment.NewLine
                strSql &= " ORDER BY Process_Type_ID,Klb_ID) m," & Environment.NewLine
                strSql &= " (SELECT @row_number:=0) AS t;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If strWorkstationName.Trim.Length > 0 Then
                    For Each row In dt.Rows
                        iKlb_ID = Convert.ToInt32(row("Klb_ID"))
                        'KLPRT_ID, WorkStation, Printer_Name,klb_id
                        strSql = "SELECT KLPRT_ID, IF(Workstation IS NULL OR LENGTH(TRIM(Workstation))=0, '',TRIM(Workstation)) AS 'Workstation'" & Environment.NewLine
                        strSql &= " ,IF(Printer_Name IS NULL OR LENGTH(TRIM(Printer_Name))=0, 'Default Printer',TRIM(Printer_Name)) AS 'Printer_Name'" & Environment.NewLine
                        strSql &= " ,Klb_ID" & Environment.NewLine
                        strSql &= " FROM ttffk_kitting_labelprinters" & Environment.NewLine
                        strSql &= " WHERE WorkStation='" & strWorkstationName & "' AND Klb_ID=" & iKlb_ID

                        dt2 = Me._objDataProc.GetDataTable(strSql)
                        If dt2.Rows.Count > 0 Then 'it is 1 row
                            row.BeginEdit() : row("Workstation") = strWorkstationName.Trim
                            row("Printer_Name") = dt2.Rows(0).Item("Printer_Name") : row("Printer_Name_Old") = dt2.Rows(0).Item("Printer_Name")
                            row("KLPRT_ID") = dt2.Rows(0).Item("KLPRT_ID") : row.AcceptChanges()
                        Else
                            row.BeginEdit() : row("Workstation") = strWorkstationName.Trim
                            row("Printer_Name") = "Default Printer" : row("Printer_Name_Old") = "Default Printer" : row.AcceptChanges()
                        End If
                    Next
                End If

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing : dt2 = Nothing
            End Try
        End Function

        Public Function SaveLabelPrinterData(ByVal strWorkstationName As String, ByVal strPrinterName As String, _
                                             ByRef iKlb_id As Integer, ByVal iUserID As Integer, ByVal strDateTime As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable

            'KLPRT_ID, WorkStation, klb_id, Printer_Name, UserID, UpdatedDateTime
            Try
                strWorkstationName = strWorkstationName.Trim.Replace("'", "''")
                strPrinterName = strPrinterName.Trim.Replace("'", "''")

                Select Case strPrinterName.Replace(" ", "").ToUpper
                    Case "DefaultPrinter".ToUpper, "DefaultPrinter".ToUpper, "Default_Printer".ToUpper, "Default-Printer".ToUpper
                        strPrinterName = ""
                End Select

                strSql = "SELECT * FROM production.ttffk_kitting_labelprinters WHERE WorkStation='" & strWorkstationName & "' AND Klb_id= " & iKlb_id
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then 'update
                    strSql = "UPDATE production.ttffk_kitting_labelprinters SET Printer_Name='" & strPrinterName & "' WHERE WorkStation='" & strWorkstationName & "' AND Klb_id= " & iKlb_id
                Else 'insert new
                    strSql = "INSERT INTO production.ttffk_kitting_labelprinters (WorkStation, Klb_id, Printer_Name, UserID, UpdatedDateTime) "
                    strSql &= "VALUES ('" & strWorkstationName & "'," & iKlb_id & ",'" & strPrinterName & "'," & iUserID & ",'" & strDateTime & " ');"
                End If

                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing
            End Try
        End Function
    End Class
End Namespace
