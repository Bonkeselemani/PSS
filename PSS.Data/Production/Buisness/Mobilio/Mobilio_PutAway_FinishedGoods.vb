Option Explicit On 

Imports CrystalDecisions.CrystalReports.Engine

Namespace Buisness
    Public Class Mobilio_PutAway_FinishedGoods

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

#End Region

        '***********************************************************************************************************************************
        Public Function GetOpenToSortTotes() As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT A.mb_Tote_ID as 'Tote ID', Tote_Name as 'Tote Name', A.CreatedDate as 'Created Date'" & Environment.NewLine
                strSql &= ", B.User_FullName as 'Created By', count(*) as Qty" & Environment.NewLine
                strSql &= "FROM tmb_tote A INNER JOIN security.tusers B ON A.CreatedUserID = B.User_ID" & Environment.NewLine
                strSql &= "INNER JOIN tmb_device B ON A.mb_Tote_ID = B.mb_Tote_ID" & Environment.NewLine
                strSql &= "WHERE A.CompletedSortDate Is null And A.Closed = 1 " & Environment.NewLine
                strSql &= "Group By A.mb_Tote_ID "

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function GetDeviceByDeviceID(ByVal iDeviceID As Integer) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT * FROM tmb_device WHERE mb_DeviceID = " & iDeviceID
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function GetItemsInTote(ByVal iToteID As Integer) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT Tote_Item_SeqNo as 'Seq', item_esn_imei as 'ESN/IMEI', H.DCode_LDesc as 'Condtion'" & Environment.NewLine
                strSql &= ", lcodesdetail.DCode_LDesc as 'Disposition', item_sku as SKU " & Environment.NewLine
                strSql &= ", C.DCode_LDesc as 'OEM', D.DCode_LDesc as 'Model', N.DCode_LDesc as 'Technology'" & Environment.NewLine
                strSql &= ", E.DCode_LDesc as 'Carrier', F.DCode_LDesc as 'Find My iPhone', G.DCode_LDesc as 'Carrier Lock'" & Environment.NewLine
                strSql &= ", I.DCode_LDesc as 'Memory', J.DCode_LDesc as 'Color', K.DCode_LDesc as 'ESN/IMEI Checked'" & Environment.NewLine
                strSql &= ", L.DCode_LDesc as 'Battery Door Present', M.DCode_LDesc as 'Battery Present'" & Environment.NewLine
                strSql &= ", PutAway_Location, A.Tote_Name as 'Tote Name', A.ClosedDate as 'Close Date', B.User_FullName as 'Closed By'" & Environment.NewLine
                strSql &= ", A.mb_Tote_ID as 'Tote ID', B.mb_DeviceID as 'Device ID', B.mb_OrderID_Inbound as 'Order ID'" & Environment.NewLine
                strSql &= ", B.mb_MP_ID, B.mb_OrderID_Outbound, B.ShippedDate, B.action_id, B.response_action_id, B.discrepancyflag " & Environment.NewLine
                strSql &= "FROM tmb_tote A INNER JOIN security.tusers B ON A.ClosedUserID = B.User_ID" & Environment.NewLine
                strSql &= "INNER JOIN tmb_device B ON A.mb_Tote_ID = B.mb_Tote_ID" & Environment.NewLine
                strSql &= "INNER JOIN lcodesdetail ON B.action_id = lcodesdetail.Dcode_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail C ON B.item_oem_id = C.Dcode_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail D ON B.item_model_id = D.Dcode_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail E ON B.item_carrier_id = E.Dcode_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail F ON B.item_findmyiphone_id = F.Dcode_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail G ON B.item_carrier_lock_id = G.Dcode_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail H ON B.item_condition_id = H.Dcode_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail I ON B.item_memory_id = I.Dcode_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail J ON B.item_color_id = J.Dcode_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail K ON B.item_esn_imei_check_id = K.Dcode_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail L ON B.item_batterydoor_present_id = L.Dcode_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail M ON B.item_battery_present_id = M.Dcode_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail N ON B.item_technology_id = N.Dcode_ID" & Environment.NewLine
                strSql &= "WHERE A.mb_Tote_ID = " & iToteID
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function SortCompleted(ByVal strPutAwayLoc As String, ByVal iToteID As Integer, ByVal iQty As Integer, ByVal iUserID As Integer _
                                     , ByVal booCreateMasterPack As Boolean, ByVal strPrinterName As String) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0, iMasterPackID = 0

            Try
                '*****************************************
                '1: Completed Sort
                '*****************************************
                strSql = "UPDATE tmb_tote SET CompletedSortDate = now(), CompletedSortUserID = " & iUserID & Environment.NewLine
                strSql &= "WHERE mb_tote_ID = " & iToteID & " AND CompletedSortDate is null "
                i = Me._objDataProc.ExecuteNonQuery(strSql)
                If i = 0 Then Throw New Exception("System has failed to save data on put away item.")

                '*****************************************
                '2: Save put away location
                '*****************************************
                strSql = "UPDATE tmb_device SET PutAway_Location = '" & strPutAwayLoc & "' WHERE mb_Tote_ID = " & iToteID
                i = Me._objDataProc.ExecuteNonQuery(strSql)
                If i = 0 Then Throw New Exception("System has failed to save put away location.")

                '*****************************************
                '2: Create Master pack
                '*****************************************
                If booCreateMasterPack Then
                    iMasterPackID = Me.CreateMasterPack(iUserID, iQty)
                    AssignedDeviceToPutAwayMasterPack(iMasterPackID, iToteID)

                    PrintMasterPackBoxLabel(iMasterPackID, strPrinterName)
                    PrintMasterPackManifest(iMasterPackID)
                End If

                '*****************************************
                '3: Print Tote Manifest
                '*****************************************
                If booCreateMasterPack = False Then PrintToteManifest(iToteID)
                Return i
            Catch ex As Exception
                Throw New Exception("SortCompleted():" & ex.Message)
            End Try
        End Function

        '***********************************************************************************************************************************
        'Label #3 
        '***********************************************************************************************************************************
        Public Sub PrintMasterPackBoxLabel(ByVal iMasterPackID As Integer, ByVal strPrinterName As String)
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim objRpt As ReportDocument

            Try
                strSql = "select A.mb_MP_ID, if(length(A.mb_MP_ID)>9, cast(A.mb_MP_ID as char),lpad(A.mb_MP_ID,9,'0')) as 'rptID'" & Environment.NewLine
                strSql &= ", if(length(A.mb_MP_ID)>9, cast(A.mb_MP_ID as char),lpad(A.mb_MP_ID,9,'0')) as 'BoxID'" & Environment.NewLine
                strSql &= ",cast(cast(A.MP_Quantity as UNSIGNED) as char) as 'Quantity'" & Environment.NewLine
                strSql &= ",B.mb_tote_ID, if(length(B.mb_tote_ID)>9, cast(B.mb_tote_ID as char),lpad(B.mb_tote_ID,9,'0')) as 'ToteID'" & Environment.NewLine
                strSql &= ",B.mb_deviceID,if(length(B.mb_deviceID)>9, cast(B.mb_deviceID as char),lpad(B.mb_deviceID,9,'0')) as 'DeviceID'" & Environment.NewLine
                strSql &= " from tmb_masterpack A" & Environment.NewLine
                strSql &= " Inner join tmb_device B on A.mb_MP_ID=B.MB_MP_ID" & Environment.NewLine
                strSql &= " Inner join tmb_tote C on B.mb_Tote_ID=C.MB_Tote_ID" & Environment.NewLine
                strSql &= " where A.mb_MP_ID=" & iMasterPackID & ";" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    objRpt = New ReportDocument()
                    With objRpt
                        .Load(PSS.Data.ConfigFile.GetBaseReportPath & "Mobilio_Finish_Goods.rpt")
                        If Not IsNothing(dt) Then .SetDataSource(dt)
                        If strPrinterName.Trim.Length > 0 Then .PrintOptions.PrinterName = strPrinterName.Trim ' "EasyCoder" ' "EasyCoder44"

                        .Refresh()
                        .PrintToPrinter(1, True, 0, 0)
                    End With
                Else
                    Throw New Exception("PrintMasterPackBoxLabel: No data!")
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '***********************************************************************************************************************************
        'Same format as PrintToteManifest 
        '***********************************************************************************************************************************
        Public Sub PrintMasterPackManifest(ByVal iMasterPackID As Integer)
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim objRpt As ReportDocument

            Try
                strSql = "select B.Tote_item_SeqNo as 'ItemSeqNo',A.mb_MP_ID, if(length(A.mb_MP_ID)>9, cast(A.mb_MP_ID as char),lpad(A.mb_MP_ID,9,'0')) as 'rptID'" & Environment.NewLine
                strSql &= ", if(length(A.mb_MP_ID)>9, cast(A.mb_MP_ID as char),lpad(A.mb_MP_ID,9,'0')) as 'BoxID'" & Environment.NewLine
                strSql &= ",B.mb_tote_ID, if(length(B.mb_tote_ID)>9, cast(B.mb_tote_ID as char),lpad(B.mb_tote_ID,9,'0')) as 'ToteID'" & Environment.NewLine
                strSql &= ",cast(cast(A.MP_Quantity as UNSIGNED) as char) as 'Quantity', B.item_esn_imei as 'EsnImei'" & Environment.NewLine
                strSql &= ",F.Dcode_LDesc as 'Model',G.Dcode_LDesc as 'Memory',H.Dcode_LDesc as 'Color',I.Dcode_LDesc as 'CarrierLock',J.Dcode_LDesc as 'Carrier',K.Dcode_LDesc as 'Condition'" & Environment.NewLine
                strSql &= ",B.item_Sku as 'Sku',L.Dcode_LDesc as 'Other1',B.mb_deviceID,if(length(B.mb_deviceID)>9, cast(B.mb_deviceID as char),lpad(B.mb_deviceID,9,'0')) as 'DeviceID'" & Environment.NewLine
                strSql &= " from tmb_masterpack A" & Environment.NewLine
                strSql &= " Inner join tmb_device B on A.mb_MP_ID=B.MB_MP_ID" & Environment.NewLine
                strSql &= " Inner join tmb_tote C on B.mb_Tote_ID=C.MB_Tote_ID" & Environment.NewLine
                strSql &= " Left join lcodesdetail F on B.item_model_ID=F.Dcode_ID" & Environment.NewLine
                strSql &= " Left join lcodesdetail G on B.item_memory_ID=G.Dcode_ID" & Environment.NewLine
                strSql &= " left join lcodesdetail H on B.item_color_ID=H.Dcode_ID" & Environment.NewLine
                strSql &= " left join lcodesdetail I on B.item_carrier_Lock_ID=I.Dcode_ID" & Environment.NewLine
                strSql &= " left join lcodesdetail J on B.item_carrier_ID=J.Dcode_ID" & Environment.NewLine
                strSql &= " left join lcodesdetail K on B.item_condition_ID=K.Dcode_ID" & Environment.NewLine
                strSql &= " left join lcodesdetail L on B.action_id=L.Dcode_ID" & Environment.NewLine
                strSql &= " where A.mb_MP_ID=" & iMasterPackID & ";" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    objRpt = New ReportDocument()
                    With objRpt
                        .Load(PSS.Data.ConfigFile.GetBaseReportPath & "Finished_Goods_Carton_Contents_List.rpt")
                        If Not IsNothing(dt) Then .SetDataSource(dt)
                        .Refresh()
                        .PrintToPrinter(1, True, 0, 0)
                    End With
                Else
                    Throw New Exception("PrintMasterPackManifest: No data!")
                End If


            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '***********************************************************************************************************************************
        'PA/Finished Goods
        '***********************************************************************************************************************************
        Public Sub PrintToteManifest(ByVal iToteID As Integer)
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim objRpt As ReportDocument

            Try
                strSql = "select B.Tote_item_SeqNo as 'ItemSeqNo',A.mb_MP_ID, if(length(B.mb_tote_ID)>9, cast(B.mb_tote_ID as char),lpad(B.mb_tote_ID,9,'0')) as 'rptID'" & Environment.NewLine
                strSql &= ", if(length(A.mb_MP_ID)>9, cast(A.mb_MP_ID as char),lpad(A.mb_MP_ID,9,'0')) as 'BoxID'" & Environment.NewLine
                strSql &= ",B.mb_tote_ID, if(length(B.mb_tote_ID)>9, cast(B.mb_tote_ID as char),lpad(B.mb_tote_ID,9,'0')) as 'ToteID'" & Environment.NewLine
                strSql &= ",cast(cast(A.MP_Quantity as UNSIGNED) as char) as 'Quantity', B.item_esn_imei as 'ESNIMEI'" & Environment.NewLine
                strSql &= ",F.Dcode_LDesc as 'Model',G.Dcode_LDesc as 'Memory',H.Dcode_LDesc as 'Color',I.Dcode_LDesc as 'CarrierLock',J.Dcode_LDesc as 'Carrier',K.Dcode_LDesc as 'Condition'" & Environment.NewLine
                strSql &= ",B.item_Sku as 'Sku',L.Dcode_LDesc as 'Other1',B.mb_deviceID,if(length(B.mb_deviceID)>9, cast(B.mb_deviceID as char),lpad(B.mb_deviceID,9,'0')) as 'DeviceID'" & Environment.NewLine
                strSql &= " from tmb_masterpack A" & Environment.NewLine
                strSql &= " Inner join tmb_device B on A.mb_MP_ID=B.MB_MP_ID" & Environment.NewLine
                strSql &= " Inner join tmb_tote C on B.mb_Tote_ID=C.MB_Tote_ID" & Environment.NewLine
                strSql &= " Left join lcodesdetail F on B.item_model_ID=F.Dcode_ID" & Environment.NewLine
                strSql &= " Left join lcodesdetail G on B.item_memory_ID=G.Dcode_ID" & Environment.NewLine
                strSql &= " left join lcodesdetail H on B.item_color_ID=H.Dcode_ID" & Environment.NewLine
                strSql &= " left join lcodesdetail I on B.item_carrier_Lock_ID=I.Dcode_ID" & Environment.NewLine
                strSql &= " left join lcodesdetail J on B.item_carrier_ID=J.Dcode_ID" & Environment.NewLine
                strSql &= " left join lcodesdetail K on B.item_condition_ID=K.Dcode_ID" & Environment.NewLine
                strSql &= " left join lcodesdetail L on B.action_id=L.Dcode_ID" & Environment.NewLine
                strSql &= " where B.mb_tote_ID=" & iToteID & ";" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    objRpt = New ReportDocument()
                    With objRpt
                        .Load(PSS.Data.ConfigFile.GetBaseReportPath & "Finished_Goods_CartonTote_Contents_List.rpt")
                        If Not IsNothing(dt) Then .SetDataSource(dt)
                        .Refresh()
                        .PrintToPrinter(1, True, 0, 0)
                    End With
                Else
                    Throw New Exception("PrintToteManifest: No data!")
                End If


            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '***********************************************************************************************************************************
        Public Function CreateMasterPack(ByVal iUserID As Integer, ByVal iQty As Integer) As Integer
            Dim strSql As String = ""
            Dim iMasterPackID As Integer = 0

            Try
                strSql = "INSERT INTO tmb_masterpack ( CreatedDate, CreatedUserID, MP_Quantity ) VALUES ( now(), " & iUserID & ", " & iQty & " ) "
                iMasterPackID = Me._objDataProc.idTransaction(strSql, "tmb_masterpack")
                If iMasterPackID = 0 Then Throw New Exception("System has failed to create master pack id.")

                Return iMasterPackID
            Catch ex As Exception
                Throw New Exception("CreateMasterPack() : " & ex.Message)
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function AssignedDeviceToPutAwayMasterPack(ByVal iMasterPackID As Integer, ByVal iToteID As Integer) As Integer
            Dim strSql As String = ""
            Dim i As Integer

            Try
                strSql = "UPDATE tmb_device SET mb_MP_ID = " & iMasterPackID & " WHERE mb_Tote_ID = " & iToteID & " AND mb_MP_ID = 0 "
                i = Me._objDataProc.ExecuteNonQuery(strSql)
                If i = 0 Then Throw New Exception("System has failed to assign master pack id to items.")

                Return i
            Catch ex As Exception
                Throw New Exception("CreateMasterPack() : " & ex.Message)
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function GetServiceFees() As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT * FROM tmb_fee WHERE Active = 1"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function RemoveUnWantedServiceFees(ByVal imbDeviceID As Integer, ByVal strNeededFeeTypeIDs As String) As Integer
            Dim strSql As String = ""
            Try
                strSql = "DELETE FROM tmb_devicebill WHERE mb_DeviceID = " & imbDeviceID & " AND mb_fee_id NOT IN ( " & strNeededFeeTypeIDs & " ) "
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function IsServiceFeeExisted(ByVal imbDeviceID As Integer, ByVal iFeeTypeID As Integer) As Boolean
            Dim strSql As String = ""
            Try
                strSql = "SELECT count(*) AS cnt FROM tmb_devicebill WHERE mb_DeviceID = " & imbDeviceID & " AND mb_fee_id = " & iFeeTypeID
                If Me._objDataProc.GetIntValue(strSql) > 0 Then Return True Else Return False
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function AddServiceFee(ByVal imbDeviceID As Integer, ByVal iFeeTypeID As Integer, ByVal iServicePrice As Double, ByVal iUserID As Integer) As Integer
            Dim strSql As String = ""
            Try
                strSql = "INSERT INTO tmb_devicebill ( mb_DeviceID, mb_fee_id, mb_fee_price, Bill_Date, Bill_UserID " & Environment.NewLine
                strSql &= " ) VALUES ( " & Environment.NewLine
                strSql &= imbDeviceID & ", " & iFeeTypeID & ", " & iServicePrice & ", now(), " & iUserID & Environment.NewLine
                strSql &= ") " & Environment.NewLine

                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************

    End Class
End Namespace