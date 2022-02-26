Option Explicit On 

Namespace Buisness

    Public Class TransferDevices
        Private _objDataProc As DBQuery.DataProc

        '*********************************************************
        Public Sub New()
            Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
        End Sub

        '*********************************************************
        Protected Overrides Sub Finalize()
            Me._objDataProc = Nothing
            MyBase.Finalize()
        End Sub

        '***************************************************
        'Dispose dt
        '***************************************************
        Public Function DisposeDT(ByRef dt As DataTable)
            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If
        End Function

        '*********************************************************
        Public Function GetDeviceQtyInWipBucket(ByVal iProd_ID As Integer, _
                                                ByVal iWipOwnerID As Integer, _
                                                ByVal iLocID As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT Model_Desc as Model, COUNT(*) AS Qty " & Environment.NewLine
                strSql &= "FROM tdevice  " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.wo_ID " & Environment.NewLine
                strSql &= "INNER JOIN tmessdata on tdevice.Device_ID = tmessdata.device_id " & Environment.NewLine
                strSql &= "INNER JOIN tmodel on tdevice.model_id = tmodel.model_ID "
                strSql &= "WHERE tworkorder.Prod_ID = " & iProd_ID & " " & Environment.NewLine
                strSql &= "AND tmessdata.WipOwner_ID = " & iWipOwnerID.ToString & " " & Environment.NewLine
                strSql &= "AND tdevice.Loc_ID = " & iLocID & Environment.NewLine
                strSql &= "Group by tdevice.Loc_ID, Model_Desc " & Environment.NewLine
                strSql &= "Order by Model_Desc;"
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************
        Public Function CheckShipDate(ByVal iTray_ID As String, _
                                      ByVal iProd_ID As Integer) As Boolean
            Dim strSql As String

            Try
                strSql = "SELECT count(*) as cnt FROM tdevice  " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder on tdevice.Wo_ID = tworkorder.WO_ID " & Environment.NewLine
                strSql &= "WHERE Tray_ID = " & iTray_ID & Environment.NewLine
                strSql &= "AND Prod_ID = " & iProd_ID & Environment.NewLine
                strSql &= "AND (Device_DateShip is not null and Device_DateShip <> '0000-00-00 00:00:00' and Device_DateShip <> '');"

                If Me._objDataProc.GetIntValue(strSql) > 0 Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************
        Public Function TranferDevIntoPreCellWIPBucket(ByVal strItemType As String, _
                                                       ByVal strItem As String, _
                                                       ByVal iProd_ID As Integer, _
                                                       ByVal iLocID As Integer) As String
            Dim strSql As String
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim strReturnMsg As String = ""

            Try
                strSql = "SELECT Distinct tmessdata.wipowner_id FROM tdevice  " & Environment.NewLine
                strSql &= "INNER JOIN tmessdata on tdevice.Device_ID = tmessdata.device_id " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder on tdevice.Wo_ID = tworkorder.WO_ID " & Environment.NewLine
                If strItemType = "TrayID" Then
                    strSql &= "WHERE Tray_ID = " & strItem & Environment.NewLine
                Else
                    strSql &= "WHERE Device_SN = '" & strItem & "'" & Environment.NewLine
                End If
                strSql &= " AND Prod_ID = " & iProd_ID & Environment.NewLine
                strSql &= "AND (Device_DateShip is null or Device_DateShip = '0000-00-00 00:00:00' or Device_DateShip = '') " & Environment.NewLine
                strSql &= "AND tdevice.Loc_ID = " & iLocID
                dt1 = Me._objDataProc.GetDataTable(strSql)

                If dt1.Rows.Count = 0 Then
                    strReturnMsg = "Can't find " & strItemType & " in WIP."
                ElseIf dt1.Rows.Count > 1 Then
                    strReturnMsg = strItemType & " contains multiple 'Wip Location'. Can't transfer to Pre-Cell."
                ElseIf dt1.Rows.Count = 1 Then
                    If dt1.Rows(0)("wipowner_id") = 2 Then
                        strReturnMsg = strItemType & " has already scanned."
                    ElseIf (dt1.Rows(0)("wipowner_id") <> 0 And dt1.Rows(0)("wipowner_id") <> 1 And dt1.Rows(0)("wipowner_id") <> 6) Then
                        strReturnMsg = strItemType & " does not belong to Receive or Hold bucket. Can't transfer to Pre-Cell."
                    Else
                        strSql = "UPDATE tdevice, tmessdata " & Environment.NewLine
                        strSql &= "SET tmessdata.wipowner_id_Old = tmessdata.wipowner_id " & Environment.NewLine
                        strSql &= ", tmessdata.wipowner_id = 2 " & Environment.NewLine
                        strSql &= ", tmessdata.wipowner_EntryDt =  now() " & Environment.NewLine
                        strSql &= "WHERE tdevice.Device_ID = tmessdata.device_id " & Environment.NewLine
                        If strItemType = "TrayID" Then
                            strSql &= "AND Tray_ID = " & strItem & Environment.NewLine
                        Else
                            strSql &= "AND Device_SN = '" & strItem & "'" & Environment.NewLine
                        End If
                        strSql &= "AND (Device_DateShip is null or Device_DateShip = '0000-00-00 00:00:00' or Device_DateShip = '') " & Environment.NewLine
                        strSql &= "AND Loc_ID = " & iLocID

                        Me._objDataProc.ExecuteNonQuery(strSql)
                    End If
                End If

                Return strReturnMsg
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                Me.DisposeDT(dt1)
            End Try
        End Function

        '*********************************************************
        Public Function TranferDevIntoHoldWIPBucket(ByVal strItemType As String, _
                                                    ByVal strItem As String, _
                                                    ByVal iProd_ID As Integer, _
                                                    ByVal iLocID As Integer) As String
            Dim strSql As String
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim strReturnMsg As String = ""

            Try
                strSql = "SELECT Distinct tmessdata.wipowner_id FROM tdevice  " & Environment.NewLine
                strSql &= "INNER JOIN tmessdata on tdevice.Device_ID = tmessdata.device_id " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder on tdevice.Wo_ID = tworkorder.WO_ID " & Environment.NewLine
                If strItemType = "TrayID" Then
                    strSql &= "WHERE Tray_ID = " & strItem & Environment.NewLine
                Else
                    strSql &= "WHERE Device_SN = '" & strItem & "' " & Environment.NewLine
                End If
                strSql &= "AND Prod_ID = " & iProd_ID & Environment.NewLine
                strSql &= "AND (Device_DateShip is null or Device_DateShip = '0000-00-00 00:00:00' or Device_DateShip = '') " & Environment.NewLine
                strSql &= "AND tdevice.Loc_ID = " & iLocID
                dt1 = Me._objDataProc.GetDataTable(strSql)

                If dt1.Rows.Count = 0 Then
                    strReturnMsg = "Can't find " & strItemType & " in WIP."
                ElseIf dt1.Rows.Count = 1 And dt1.Rows(0)("wipowner_id") = 6 Then
                    strReturnMsg = strItemType & " has already scanned."
                ElseIf dt1.Rows.Count > 1 Then
                    strReturnMsg = strItemType & " contains multiple 'Wip Location'. Can't transfer to Hold bucket."
                Else
                    strSql = "UPDATE tdevice, tmessdata " & Environment.NewLine
                    strSql &= "SET tmessdata.wipowner_id_Old = tmessdata.wipowner_id " & Environment.NewLine
                    strSql &= ", tmessdata.wipowner_id = 6 " & Environment.NewLine
                    strSql &= ", tmessdata.wipowner_EntryDt = now() " & Environment.NewLine
                    strSql &= "WHERE tdevice.Device_ID = tmessdata.device_id " & Environment.NewLine
                    If strItemType = "TrayID" Then
                        strSql &= "AND Tray_ID = " & strItem & Environment.NewLine
                    Else
                        strSql &= "AND Device_SN = '" & strItem & "'" & Environment.NewLine
                    End If
                    strSql &= "AND (Device_DateShip is null or Device_DateShip = '0000-00-00 00:00:00' or Device_DateShip = '') " & Environment.NewLine
                    strSql &= "AND Loc_ID = " & iLocID
                    Me._objDataProc.ExecuteNonQuery(strSql)
                End If

                Return strReturnMsg
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                Me.DisposeDT(dt1)
            End Try
        End Function

        '*********************************************************


    End Class

End Namespace