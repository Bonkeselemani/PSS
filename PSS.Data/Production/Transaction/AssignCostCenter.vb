Option Explicit On 

Namespace Production
    Public Class AssignCostCenter
        Private _objMisc As Production.Misc

        Public Sub New()
            _objMisc = New Production.Misc()
        End Sub

        Protected Overrides Sub Finalize()
            _objMisc = Nothing
            MyBase.Finalize()
        End Sub

        Public Function GetCostCenterID() As Integer
            Dim iCCID As Integer = 0
            Dim strMachineName, strSQL As String

            Try
                strMachineName = System.Net.Dns.GetHostName

                strSQL = "SELECT A.cc_id" & Environment.NewLine
                strSQL &= "FROM production.tcostcenter A" & Environment.NewLine
                strSQL &= "INNER JOIN production.tcostcentermapping B ON B.cc_id = A.cc_id" & Environment.NewLine
                strSQL &= "INNER JOIN production.lwclocation C ON C.WCLocation_ID = B.WCLocation_ID" & Environment.NewLine
                strSQL &= "WHERE C.WC_Machine = '" & strMachineName & "'"

                iCCID = Me._objMisc.GetIntValue(strSQL)

                Return iCCID
            Catch ex As Exception
                Throw New Exception("Business.Tansaction.GetCostCenterID():: " & ex.ToString)
            End Try
        End Function

        Public Function IsValidTray(ByVal strTrayID As String) As Boolean
            Dim strSQL As String
            Dim bValid() As Boolean = {False, False}

            Try
                strSQL = "SELECT COUNT(*)" & Environment.NewLine
                strSQL &= "FROM production.tdevice" & Environment.NewLine
                strSQL &= "WHERE tray_id = '" & strTrayID & "'"

                bValid(0) = IIf(Me._objMisc.GetIntValue(strSQL) > 0, True, False)

                If bValid(0) Then
                    strSQL = "SELECT COUNT(*)" & Environment.NewLine
                    strSQL &= "FROM production.tdevice" & Environment.NewLine
                    strSQL &= "WHERE tray_id = '" & strTrayID & "'" & Environment.NewLine
                    strSQL &= "AND Device_DateShip IS NOT NULL"

                    bValid(1) = IIf(Me._objMisc.GetIntValue(strSQL) > 0, False, True)
                End If

                Return bValid(0) And bValid(1)
            Catch ex As Exception
                Throw New Exception("Business.Tansaction.IsValidTray():: " & ex.ToString)
            End Try
        End Function

        Public Function IsTrayAssigned(ByVal strTrayID As String) As String
            Dim strIsTrayAssigned As String = ""
            Dim strSQL As String
            Dim dr As DataRow

            Try
                strSQL = "SELECT DISTINCT A.cc_desc" & Environment.NewLine
                strSQL &= "FROM production.tcostcenter A" & Environment.NewLine
                strSQL &= "INNER JOIN production.tdevice B ON B.cc_id = A.cc_id" & Environment.NewLine
                strSQL &= "WHERE B.Tray_ID = " & strTrayID & Environment.NewLine
                strSQL &= "ORDER BY A.cc_id DESC"

                dr = Me._objMisc.GetDataRow(strSQL)

                If Not IsNothing(dr) Then strIsTrayAssigned = IIf(Not IsDBNull(dr(0)), dr(0), "")

                Return strIsTrayAssigned
            Catch ex As Exception
                Throw New Exception("Business.Tansaction.isTrayAssigned():: " & ex.ToString)
            End Try
        End Function

        Public Function AssignCostCenterToTray(ByVal strTrayID As String, ByVal iCCID As Integer) As Integer
            Dim strSQL As String

            Try
                strSQL = "UPDATE production.tdevice, tmessdata " & Environment.NewLine
                strSQL &= "SET cc_id = " & iCCID.ToString & Environment.NewLine
                strSQL &= ", tmessdata.wipowner_id_Old = tmessdata.wipowner_id " & Environment.NewLine
                strSQL &= ", tmessdata.wipowner_id = 3 " & Environment.NewLine
                strSQL &= ", tmessdata.wipowner_EntryDt =  '" & PSS.Data.Buisness.Generic.MySQLServerDateTime(1) & "' " & Environment.NewLine
                strSQL &= "WHERE tdevice.device_id = tmessdata.device_id AND tray_id = '" & strTrayID & "'"

                Return Me._objMisc.ExecuteNonQuery(strSQL)
            Catch ex As Exception
                Throw New Exception("Business.Tansaction.AssignCostCenter():: " & ex.ToString)
            End Try
        End Function

        Public Function AssignCostCenterToUnit(ByVal iDeviceID As String, _
                                               ByVal iCCID As Integer, _
                                               ByVal iProdID As Integer, _
                                               Optional ByVal strWorkStation As String = "") As Integer
            Dim strSQL As String

            Try
                If iProdID = 1 Then
                    strSQL = "UPDATE production.tdevice, tmessdata " & Environment.NewLine
                    strSQL &= "SET cc_id = " & iCCID.ToString & ", CC_EntryDate = now()" & Environment.NewLine
                    strSQL &= ", tmessdata.wipowner_id_Old = tmessdata.wipowner_id " & Environment.NewLine
                    strSQL &= ", tmessdata.wipowner_id = 3, wipownersubloc_id = 0 " & Environment.NewLine
                    strSQL &= ", tmessdata.wipowner_EntryDt =  now() " & Environment.NewLine
                    strSQL &= "WHERE tdevice.device_id = tmessdata.device_id AND tdevice.Device_ID = " & iDeviceID & Environment.NewLine
                Else
                    strSQL = "UPDATE production.tdevice, tcellopt " & Environment.NewLine
                    strSQL &= "SET cc_id = " & iCCID.ToString & ", CC_EntryDate = now()" & Environment.NewLine
                    strSQL &= ", Cellopt_WIPOwnerOld = Cellopt_WIPOwner " & Environment.NewLine
                    strSQL &= ", Cellopt_WIPOwner = 3 " & Environment.NewLine
                    strSQL &= ", Cellopt_WIPOwnerOld =  now() " & Environment.NewLine
                    If strWorkStation.Trim.Length > 0 Then
                        strSQL &= ", WorkStation = '" & strWorkStation & "'" & Environment.NewLine
                        strSQL &= ", WorkStationEntryDt = now() " & Environment.NewLine
                    End If
                    strSQL &= "WHERE tdevice.device_id = tcellopt.device_id AND tdevice.Device_ID = " & iDeviceID & Environment.NewLine
                End If

                Return Me._objMisc.ExecuteNonQuery(strSQL)
            Catch ex As Exception
                Throw New Exception("Business.Tansaction.AssignCostCenter():: " & ex.ToString)
            End Try
        End Function

        Public Function ValidateMachGrpAndDevGrp(ByVal iTrayID As Integer) As Boolean
            Dim strSQL As String
            Dim dt As DataTable

            Try
                ValidateMachGrpAndDevGrp = False

                strSQL = "SELECT distinct tworkorder.Group_ID " & Environment.NewLine
                strSQL &= "FROM tdevice " & Environment.NewLine
                strSQL &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                strSQL &= "WHERE tdevice.Tray_ID = " & iTrayID & Environment.NewLine
                strSQL &= "AND tworkorder.Group_ID = " & PSS.Data.Buisness.Generic.GetMachineCostCenterGrpID & " " & Environment.NewLine

                dt = Me._objMisc.GetDataTable(strSQL)
                If dt.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Throw New Exception("Business.Tansaction.AssignCostCenter():: " & ex.ToString)
            End Try
        End Function


    End Class
End Namespace
