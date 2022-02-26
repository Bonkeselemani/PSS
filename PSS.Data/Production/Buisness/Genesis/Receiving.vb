Option Explicit On 

Namespace Buisness.Genesis
    Public Class Receiving
        Private _objDataProc As DBQuery.DataProc

#Region "Constructor/Destructor"

        '*******************************************************************************************************
        Public Sub New()
            Try
                Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*******************************************************************************************************
        Protected Overrides Sub Finalize()
            Me._objDataProc = Nothing
            MyBase.Finalize()
        End Sub

        '*******************************************************************************************************
#End Region

#Region "Shared Function"

        '*******************************************************************************************************
        Public Shared Function GetOpenDeviceInfoByLocation(ByVal iLoc As Integer, ByVal strSN As String) As DataTable
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc
            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT WO_CustWO, tdevice.* " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID  " & Environment.NewLine
                strSql &= "WHERE tdevice.Loc_ID  = " & iLoc & " AND Device_SN = '" & strSN & "'" & Environment.NewLine
                strSql &= "AND Device_Dateship is null"
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************

#End Region

        '*******************************************************************************************************
        Public Function GetOpenToRecSO(ByVal iLocID As Integer, ByVal booAddSelectRow As Boolean)
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT Distinct tworkorder.WO_ID, WO_CustWO FROM tworkorder  " & Environment.NewLine
                strSql &= "INNER JOIN tworkorderline ON tworkorder.WO_ID = tworkorderline.WO_ID " & Environment.NewLine
                strSql &= "WHERE Loc_ID = " & iLocID & " AND WO_Closed = 0 AND InvalidOrder = 0 " & Environment.NewLine
                strSql &= "AND ReceivingClosed = 0" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--Select--"}, False)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '*******************************************************************************************************
        Public Function GetOpenToRecSOLines(ByVal iWOID As Integer, ByVal booAddSelectRow As Boolean _
                                          , ByVal iUserID As Integer, ByVal strUserName As String)
            Dim strSql, strUpdateVal As String
            Dim dt As DataTable
            Dim iModelID, iTrayID As Integer
            Dim R1 As DataRow
            Dim objRec As Production.Receiving
            Dim booReselectData As Boolean = False

            Try
                strSql = "" : strUpdateVal = "" : iModelID = 0 : iTrayID = 0
                strSql = "SELECT Tray_ID, LineNo, ItemNo, ItemDesc, Quantity, PlannedShipmentDate, Model_ID, WO_ID, WOL_ID, UnitPrice " & Environment.NewLine
                strSql &= "FROM tworkorderline WHERE WO_ID = " & iWOID & " AND ReceivingClosed = 0"
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    For Each R1 In dt.Rows

                        If R1("Model_ID") = 0 OrElse R1("Tray_ID") = 0 Then
                            'Check for missing Model ID 
                            If R1("Model_ID") = 0 Then
                                strSql = "SELECT Model_ID FROM tmodel WHERE Model_Desc = '" & R1("ItemNo") & "'"
                                iModelID = Me._objDataProc.GetIntValue(strSql)
                            End If

                            'Check for missing Tray ID 
                            If R1("Tray_ID") = 0 Then
                                objRec = New Production.Receiving()
                                iTrayID = objRec.InsertIntoTtray(iUserID, strUserName, iWOID, )
                            End If

                            If iModelID > 0 Then strUpdateVal = "SET Model_ID = " & iModelID
                            If iTrayID > 0 Then
                                If strUpdateVal.Trim.Length = 0 Then strUpdateVal = "SET Tray_ID = " & iTrayID Else strUpdateVal &= ", Tray_ID = " & iTrayID
                            End If
                        End If

                        If strUpdateVal.Length > 0 Then
                            strSql = "UPDATE tworkorderline " & strUpdateVal & " WHERE WOL_ID = " & R1("WOL_ID")
                            Me._objDataProc.ExecuteNonQuery(strSql)
                            booReselectData = True
                        End If

                        iModelID = 0 : iTrayID = 0
                    Next R1

                    If booReselectData = True Then
                        strSql = "SELECT WOL_ID, LineNo, ItemNo, ItemDesc, Quantity, PlannedShipmentDate, Model_ID, Tray_ID, WO_ID " & Environment.NewLine
                        strSql &= "FROM tworkorderline WHERE WO_ID = " & iWOID
                        dt = Me._objDataProc.GetDataTable(strSql)
                    End If
                End If

                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--Select--"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                objRec = Nothing
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '*******************************************************************************************************
        Public Function GetWODeviceData(ByVal iWOID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT Device_ID, Tray_ID, if(Device_DateShip is null, '', Device_DateShip) as Device_DateShip " & Environment.NewLine
                strSql &= "FROM tdevice WHERE WO_ID = " & iWOID
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************
        Public Function GetTrayCount(ByVal iTrayID As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "SELECT count(*) as cnt FROM tdevice WHERE Tray_ID = " & iTrayID
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************
        Public Function GetOrderInfo(ByVal iLocID As Integer, ByVal strSO As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT WO_custWO as 'Order #', LineNo, ItemNo, ItemDesc, Quantity, Device_SN as 'Serial #'" & Environment.NewLine
                strSql &= ", Device_DateRec as 'Receipt Date', Device_DateShip as 'Produced Date'" & Environment.NewLine
                strSql &= ", SN2 as 'LED 1' , SN3 AS 'LED 2', SN4 AS 'LED 3', SN5 AS 'LED 4', InPO as 'PSU', InRMA as 'Base Plate' " & Environment.NewLine
                strSql &= ", if( Pallett_name is null, '', Pallett_Name) as 'Lot Name'" & Environment.NewLine
                strSql &= ", if( pkslip_id is null, '', pkslip_id) as 'Manifest ID', tworkorderline.PlannedShipmentDate" & Environment.NewLine
                strSql &= "FROM tworkorder " & Environment.NewLine
                strSql &= "INNER JOIN tworkorderline ON tworkorder.WO_ID = tworkorderline.WO_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tdevice ON tworkorderline.WO_ID = tdevice.WO_ID AND tdevice.Tray_ID = tworkorderline.Tray_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tasndata ON tdevice.Device_ID = tasndata.Device_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID" & Environment.NewLine
                strSql &= "WHERE tworkorder.Loc_id =  " & iLocID & " AND WO_CustWO = '" & strSO & "'" & Environment.NewLine
                strSql &= "Order BY LineNo;" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************
        Public Function SetReceivingClosedFlag(ByVal iWOLineID As Integer, ByVal iValue As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "UPDATE tworkorderline SET ReceivingClosed = " & iValue & Environment.NewLine
                strSql &= "WHERE tworkorderline.WOL_ID = " & iWOLineID & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************
        Public Function GetUnitPrice(ByVal iWOLineID As Integer) As Double
            Dim strSql As String = ""

            Try
                strSql = "SELECT UnitPrice FROM tworkorderline " & Environment.NewLine
                strSql &= "WHERE tworkorderline.WOL_ID = " & iWOLineID & Environment.NewLine
                Return Me._objDataProc.GetDoubleValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************

    End Class
End Namespace