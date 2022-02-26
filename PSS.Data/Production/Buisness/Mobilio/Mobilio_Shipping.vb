Option Explicit On 

Namespace Buisness

    Public Class Mobilio_Shipping

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
        Public Function GetReadyToReturnOrders(ByVal iCustID As Integer, Optional ByVal iOrderID As Integer = 0) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT A.mb_OrderID, A.OrderRecDate as 'Order Rec Date', A.CompletedItemRecDate as 'Completed Item Rec Date'" & Environment.NewLine
                strSql &= ", A.po_number as 'PO', COUNT(*) AS Qty, A.shipment_transaction_ID as 'Shipment Trans ID'" & Environment.NewLine
                strSql &= ", A.ship_from_name as 'Name', A.ship_from_address as 'Address', A.ship_from_city as 'City'" & Environment.NewLine
                strSql &= ", A.ship_from_state as 'State', A.ship_from_zipcode as 'Zip' " & Environment.NewLine
                strSql &= "FROM tmb_order A " & Environment.NewLine
                strSql &= "INNER JOIN tmb_device B ON A.mb_OrderID = B.mb_OrderID_inbound " & Environment.NewLine
                strSql &= "INNER JOIN lcodesdetail C ON B.action_id = C.DCode_ID " & Environment.NewLine
                strSql &= "WHERE A.Cust_ID = " & iCustID & " AND A.OrderType = 1 AND A.HasReturn = 1 AND A.ReadyToShip = 1 AND A.OrderShipDate is null " & Environment.NewLine
                strSql &= "AND C.DCode_LDesc = 'Return' " & Environment.NewLine
                strSql &= "GROUP BY A.mb_OrderID " & Environment.NewLine
                If iOrderID > 0 Then strSql &= "AND A.mb_OrderID = " & iOrderID & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function ShipReturnOrder(ByVal iCustID As Integer, ByVal strDeviceIDs As String, ByVal iOrderID As Integer, ByVal iUserID As Integer _
                                        , ByVal iActionID As Integer, ByVal iQty As Integer, ByVal strOutBoundTrackingNo As String) As Integer
            Const iPalletShipType As Integer = 1
            Dim strSql As String = "", strToday As String = "", strShipType As String = "", strPalletName As String = ""
            Dim iPalletID As Integer, iMasterPackID As Integer, i As Integer
            Dim objPutAway As New Mobilio_PutAway_FinishedGoods()

            Try
                iMasterPackID = objPutAway.CreateMasterPack(iUserID, iQty)

                iPalletID = CreateShipPallet(iCustID, iPalletShipType, iOrderID, iUserID, iActionID, iQty, True, strPalletName)
                If iPalletID = 0 Then Throw New Exception("System has failed to create pallet.")

                strSql = "UPDATE tmb_device SET MP_ID_Outbound = " & iMasterPackID & ", mb_Pallet_ID = " & iPalletID & Environment.NewLine
                strSql &= ", mb_OrderID_Outbound = " & iOrderID & ", ShippedDate = now(), ShippedUserID = " & iUserID & Environment.NewLine
                strSql &= "WHERE mb_DeviceID in ( " & strDeviceIDs & " ) "
                i = Me._objDataProc.ExecuteNonQuery(strSql)
                If i = 0 Then Throw New Exception("System has failed to assign pallet id to device.")

                strSql = "UPDATE tmb_order SET OrderShipDate = now()" & Environment.NewLine
                strSql &= ", OrderShipUserID = " & iUserID & ", OutBoundTrackingNo = '" & strOutBoundTrackingNo & "'" & Environment.NewLine
                strSql &= "WHERE mb_OrderID = " & iOrderID
                i = Me._objDataProc.ExecuteNonQuery(strSql)
                If i = 0 Then Throw New Exception("System has failed to set ship date for order.")

                Return i
            Catch ex As Exception
                Throw New Exception("Mobilio_Shipping.CreateShipPallet():" & ex.Message)
            Finally
                objPutAway = Nothing
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function CreateShipPallet(ByVal iCustID As Integer, ByVal iPalletShipType As Integer, ByVal iOrderID As Integer, ByVal iUserID As Integer, _
                                         ByVal iActionID As Integer, ByVal iQty As Integer, ByVal booShipPallet As Boolean, ByRef strPalletName As String) As Integer
            Dim strSql As String = "", strToday As String = "", strShipType As String = ""
            Dim iPalletID As Integer

            Try
                If iPalletShipType = 0 Then strShipType = "P" Else strShipType = "R"

                strToday = Generic.MySQLServerDateTime(1)
                strSql = "SELECT mb_Pallet_ID FROM tmb_pallet WHERE Cust_ID = " & iCustID & " AND mb_OrderID = " & iOrderID & Environment.NewLine
                strSql &= "AND mb_Pallet_Invalid = 0 "
                iPalletID = Me._objDataProc.GetIntValue(strSql)

                If iPalletID = 0 Then
                    strPalletName = "MOB" & CDate(strToday).ToString("yyyyMMdd") & strShipType
                    strPalletName = Me.GetPalletNameNextSeqNo(iCustID, strPalletName, 3)
                    iPalletID = InsertPallet(iCustID, iOrderID, strPalletName, iUserID, iPalletShipType, iActionID, iQty, booShipPallet)
                End If

                Return iPalletID
            Catch ex As Exception
                Throw New Exception("Mobilio_Shipping.CreateShipPallet():" & ex.Message)
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function GetPalletNameNextSeqNo(ByVal iCustID As Integer, ByVal strPalletPrefix As String, ByVal iNumberLength As Integer) As String
            Dim strSQL As String
            Dim dt As DataTable
            Dim strPallett_Name As String = strPalletPrefix

            Try
                strSQL = "SELECT max(right(mb_Pallet_Name, " & iNumberLength & " ) ) + 1 as NextSequenceNumber " & Environment.NewLine
                strSQL &= "FROM tmb_pallet " & Environment.NewLine
                strSQL &= "WHERE mb_Pallet_Name like '" & strPalletPrefix & "%' " & Environment.NewLine
                strSQL &= "AND Cust_ID = " & iCustID & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSQL)
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0)("NextSequenceNumber")) Then
                        strPallett_Name &= dt.Rows(0)("NextSequenceNumber").ToString.Trim.PadLeft(iNumberLength, "0")
                    Else
                        strPallett_Name &= "1".PadLeft(iNumberLength, "0")
                    End If
                Else
                    strPallett_Name &= "1".PadLeft(iNumberLength, "0")
                End If

                Return strPallett_Name
            Catch ex As Exception
                Throw New Exception("Mobilio_Shipping.GetPalletNameNextSeqNo():" & ex.Message)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function InsertPallet(ByVal iCustID As Integer, ByVal iOrderID As Integer, ByVal strPalletName As String, ByVal iUserID As Integer _
                                     , ByVal iPalletShipType As Integer, ByVal iPalletDisposition As Integer, ByVal iPalletQty As Integer _
                                     , ByVal booShipPallet As Boolean) As Integer

            Dim strSql As String = ""
            Dim iPalletID As Integer = 0

            Try
                '******************************
                'check for duplicate pallet
                '******************************
                strSql = "Select count(*) as cnt From tmb_pallet where mb_Pallet_Name = '" & strPalletName & "' and Cust_ID = " & iCustID
                If Me._objDataProc.GetIntValue(strSql) > 0 Then Throw New Exception("System is trying to create pallet (" & strPalletName & ") which is already existed in system.")

                '******************************
                'Create pallet
                ''******************************
                strSql = "INSERT INTO tmb_pallet ( " & Environment.NewLine
                strSql &= " mb_Pallet_Name  " & Environment.NewLine
                strSql &= ", mb_Pallet_CreatedDate  " & Environment.NewLine
                strSql &= ", mb_Pallet_CreatedUserID " & Environment.NewLine

                If iPalletQty > 0 Then strSql &= ", mb_Pallet_Qty " & Environment.NewLine

                strSql &= ", mb_Pallet_ShipType " & Environment.NewLine
                strSql &= ", mb_OrderID " & Environment.NewLine
                strSql &= ", mb_action_id " & Environment.NewLine
                strSql &= ", Cust_ID " & Environment.NewLine
                If booShipPallet Then
                    strSql &= ", mb_Pallet_ShipDate " & Environment.NewLine
                    strSql &= ", mb_Pallet_ShippedUserID " & Environment.NewLine
                End If

                strSql &= ") VALUES (  " & Environment.NewLine
                strSql &= " '" & strPalletName & "' " & Environment.NewLine
                strSql &= ", now() " & Environment.NewLine
                strSql &= ", " & iUserID & " " & Environment.NewLine

                If iPalletQty > 0 Then strSql &= ", " & iPalletQty & " " & Environment.NewLine

                strSql &= ", " & iPalletShipType & " " & Environment.NewLine
                strSql &= ", " & iOrderID & " " & Environment.NewLine
                strSql &= ", " & iPalletDisposition & Environment.NewLine
                strSql &= ", " & iCustID & " " & Environment.NewLine

                If booShipPallet Then
                    strSql &= ", now() " & Environment.NewLine
                    strSql &= ", " & iUserID & Environment.NewLine
                End If
                strSql &= ")" & Environment.NewLine
                iPalletID = _objDataProc.idTransaction(strSql, "tpallett")

                If iPalletID = 0 Then iPalletID = GetPalletID(iCustID, strPalletName)

                Return iPalletID
            Catch ex As Exception
                Throw New Exception("Mobilio_Shipping.CreatePallet():" & ex.Message)
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function GetPalletID(ByVal iCustID As Integer, ByVal strPalletName As String) As Integer
            Dim strSQL As String
            Dim dt As DataTable
            Dim iPalletID As Integer = 0

            Try
                strSQL = "SELECT mb_Pallet_ID " & Environment.NewLine
                strSQL &= "FROM tmb_pallet " & Environment.NewLine
                strSQL &= "WHERE mb_Pallet_Name = '" & strPalletName & "' " & Environment.NewLine
                strSQL &= "AND Cust_ID = " & iCustID & Environment.NewLine
                strSQL &= "AND Pallet_Invalid = 0 " & Environment.NewLine
                dt = _objDataProc.GetDataTable(strSQL)
                If dt.Rows.Count > 1 Then
                    Throw New Exception("Duplicate record """ & strPalletName & """. Please contact IT.")
                ElseIf dt.Rows.Count = 1 Then
                    iPalletID = dt.Rows(0)("mb_Pallet_ID")
                End If

                Return iPalletID
            Catch ex As Exception
                Throw New Exception("Mobilio_Shipping.GetPalletID():" & ex.Message)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '***********************************************************************************************************************************

    End Class
End Namespace