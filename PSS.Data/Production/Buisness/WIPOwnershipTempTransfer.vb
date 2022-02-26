Imports eInfoDesigns.dbProvider.MySqlClient
Imports PSS.Data.Production
imports System.Windows.Forms

Namespace Buisness
    Public Class WIPOwnershipTempTransfer
        Private Shared _objMisc As Production.Misc
        Private _strDeviceSN As String = Nothing
        Private _iDeviceID As Integer = 0

        Public Sub New()
            Me._objMisc = New Production.Misc()
        End Sub

        Public Sub New(ByVal strDeviceSN As String)
            Me._strDeviceSN = strDeviceSN
            Me._objMisc = New Production.Misc()

            GetDeviceID()
        End Sub

        Public Function IsValidDeviceSN() As Boolean
            Dim bIsValid As Boolean = False
            Dim strSql As String = "", strCount As String = ""
            Dim sf As New StackFrame(0)

            Try
                strSql &= "SELECT COUNT(Device_ID) AS Cnt " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "WHERE UPPER(Device_ID) = " & Me._iDeviceID

                strCount = Me._objMisc.GetSingletonString(strSql)

                If strCount.Trim.Length > 0 Then
                    If CInt(strCount) > 0 Then bIsValid = True
                End If

                Return bIsValid
            Catch ex As Exception
                Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
            End Try
        End Function

        Public Function DeviceAlreadyInList(ByVal lstDeviceSN As System.Windows.Forms.ListBox, ByVal strFieldName As String) As Boolean
            Dim bAlreadyInList As Boolean = False
            Dim iIndex As Integer
            Dim sf As New StackFrame(0)

            Try
                If lstDeviceSN.Items.Count > 0 Then
                    For iIndex = 0 To lstDeviceSN.Items.Count - 1
                        If lstDeviceSN.Items(iIndex)(strFieldName) = Me._strDeviceSN Then
                            bAlreadyInList = True

                            Exit For
                        End If
                    Next
                End If

                Return bAlreadyInList
            Catch ex As Exception
                Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
            End Try
        End Function

        Private Sub GetDeviceID()
            Dim strSql As String = "", strDeviceID As String = ""
            Dim iDeviceID As Integer = 0
            Dim sf As New StackFrame(0)

            Try
                strSql &= "SELECT Device_ID " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "WHERE UPPER(Device_SN) = '" & Me._strDeviceSN.ToUpper & "'"

                strDeviceID = Me._objMisc.GetSingletonString(strSql)

                If strDeviceID.Trim.Length > 0 Then
                    If CInt(strDeviceID) > 0 Then Me._iDeviceID = CInt(strDeviceID)
                End If
            Catch ex As Exception
                Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
            End Try
        End Sub

        Public Function IsValidDeviceForTransfer() As Boolean
            Dim bIsValid As Boolean = False
            Dim strSql As String = "", strCount As String = ""
            Dim sf As New StackFrame(0)

            Try
                strSql &= "SELECT COUNT(A.Device_ID) AS Cnt " & Environment.NewLine
                strSql &= "FROM tdevice A " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder B ON B.WO_ID = A.WO_ID " & Environment.NewLine
                strSql &= "WHERE A.Device_ID = " & Me._iDeviceID & " AND A.Device_Invoice != 1 AND B.WO_DateShip IS NULL AND B.WO_ID_Original IS NULL"

                strCount = Me._objMisc.GetSingletonString(strSql)

                If strCount.Trim.Length > 0 Then
                    If CInt(strCount) > 0 Then bIsValid = True
                End If

                Return bIsValid
            Catch ex As Exception
                Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
            End Try
        End Function

        Public Sub TransferDevices(ByVal strDeviceIDs As String)
            Dim strSql, strGrpDesc As String
            Dim dt1, dt2 As DataTable
            Dim dr1, dr2 As DataRow
            Dim iOldGrpID, iNewGrpID, i As Integer
            Dim iOldLine, iNewLine As Integer
            Dim iOldWOID, iNewWOID As Integer
            Dim bUpdateSuccessful = False
            Dim iDeviceID As Integer
            Dim sf As New StackFrame(0)

            Try
                ' First, get the necessary group data 
                strSql = "SELECT DISTINCT Device_ID, WO_ID " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "WHERE Device_ID IN (" & strDeviceIDs & ")"

                dt1 = Me._objMisc.GetDataTable(strSql)

                If Not IsNothing(dt1) Then
                    If dt1.Rows.Count > 0 Then
                        ' Create a new record in tworkorder and update both tdevice and tcellopt
                        For Each dr1 In dt1.Rows
                            iOldWOID = dr1("WO_ID")
                            iDeviceID = dr1("Device_ID")

                            strSql = "SELECT * " & Environment.NewLine
                            strSql &= "FROM tworkorder " & Environment.NewLine
                            strSql &= "WHERE WO_ID = " & iOldWOID.ToString

                            If Not IsNothing(dt2) Then dt2 = New DataTable()
                            dt2 = Me._objMisc.GetDataTable(strSql)

                            If Not IsNothing(dt2) Then
                                If dt2.Rows.Count > 0 Then
                                    ' Add a new record to tworkorder with WO_ID_Original set to the old work order ID
                                    dr2 = dt2.Rows(0)

                                    ' Switch group IDs
                                    iOldGrpID = dr2("Group_ID")
                                    iNewGrpID = iOldGrpID

                                    Select Case iOldGrpID
                                        Case 2
                                            iNewGrpID = 3
                                        Case 3
                                            iNewGrpID = 2
                                    End Select

                                    strSql = "INSERT INTO tworkorder (WO_CustWO, WO_Date, WO_Quantity, WO_RAQnty, WO_Discrepancy, WO_IP, WO_PRL, WO_Label20, " & Environment.NewLine
                                    strSql &= "WO_DateDock, WO_Memo, WO_Shipped, WO_DateShip, WO_ExpCode, WO_Transceiver, WO_APC_OUT, WO_FlexVer, WO_Project, " & Environment.NewLine
                                    strSql &= "Loc_ID, Prod_ID, ShipTo_ID, PO_ID, WebInfo_ID, Comp_ID, Group_ID, Sku_ID, WO_Channel, WO_SkuLength, WO_Reject, WO_NoQC, wo_timestamp, WO_CameWithFile, WO_RecPalletName, WO_ID_Original) " & Environment.NewLine
                                    strSql &= "VALUES (" & Environment.NewLine
                                    strSql &= ProcessDataField(dr2, "WO_CustWO") & ", " & Environment.NewLine
                                    strSql &= ProcessDataField(dr2, "WO_Date", True) & ", " & Environment.NewLine
                                    strSql &= ProcessDataField(dr2, "WO_Quantity") & ", " & Environment.NewLine
                                    strSql &= ProcessDataField(dr2, "WO_RAQnty") & ", " & Environment.NewLine
                                    strSql &= ProcessDataField(dr2, "WO_Discrepancy") & ", " & Environment.NewLine
                                    strSql &= ProcessDataField(dr2, "WO_IP") & ", " & Environment.NewLine
                                    strSql &= ProcessDataField(dr2, "WO_PRL") & ", " & Environment.NewLine
                                    strSql &= ProcessDataField(dr2, "WO_Label20") & ", " & Environment.NewLine
                                    strSql &= ProcessDataField(dr2, "WO_DateDock", False) & ", " & Environment.NewLine
                                    strSql &= ProcessDataField(dr2, "WO_Memo") & ", " & Environment.NewLine
                                    strSql &= ProcessDataField(dr2, "WO_Shipped") & ", " & Environment.NewLine
                                    strSql &= ProcessDataField(dr2, "WO_DateShip", False) & ", " & Environment.NewLine
                                    strSql &= ProcessDataField(dr2, "WO_ExpCode") & ", " & Environment.NewLine
                                    strSql &= ProcessDataField(dr2, "WO_Transceiver") & ", " & Environment.NewLine
                                    strSql &= ProcessDataField(dr2, "WO_APC_OUT") & ", " & Environment.NewLine
                                    strSql &= ProcessDataField(dr2, "WO_FlexVer") & ", " & Environment.NewLine
                                    strSql &= ProcessDataField(dr2, "WO_Project") & ", " & Environment.NewLine
                                    strSql &= ProcessDataField(dr2, "Loc_ID") & ", " & Environment.NewLine
                                    strSql &= ProcessDataField(dr2, "Prod_ID") & ", " & Environment.NewLine
                                    strSql &= ProcessDataField(dr2, "ShipTo_ID") & ", " & Environment.NewLine
                                    strSql &= ProcessDataField(dr2, "PO_ID") & ", " & Environment.NewLine
                                    strSql &= ProcessDataField(dr2, "WebInfo_ID") & ", " & Environment.NewLine
                                    strSql &= ProcessDataField(dr2, "Comp_ID") & ", " & Environment.NewLine
                                    strSql &= iNewGrpID & ", " & Environment.NewLine
                                    strSql &= ProcessDataField(dr2, "Sku_ID") & ", " & Environment.NewLine
                                    strSql &= ProcessDataField(dr2, "WO_Channel") & ", " & Environment.NewLine
                                    strSql &= ProcessDataField(dr2, "WO_SkuLength") & ", " & Environment.NewLine
                                    strSql &= ProcessDataField(dr2, "WO_Reject") & ", " & Environment.NewLine
                                    strSql &= ProcessDataField(dr2, "WO_NoQC") & ", " & Environment.NewLine
                                    strSql &= ProcessDataField(dr2, "wo_timestamp", True) & ", " & Environment.NewLine
                                    strSql &= ProcessDataField(dr2, "WO_CameWithFile") & ", " & Environment.NewLine
                                    strSql &= ProcessDataField(dr2, "WO_RecPalletName") & ", " & Environment.NewLine
                                    strSql &= iOldWOID.ToString & ")"

                                    bUpdateSuccessful = Me._objMisc.ExecuteNonQuery(strSql)
                                    dr2 = Nothing
                                End If ' dt2.Rows.Count > 0
                            End If ' Not IsNothing(dt2)

                            iNewWOID = 0

                            If bUpdateSuccessful Then
                                ' Now get the new work order ID.
                                strSql = "SELECT WO_ID " & Environment.NewLine
                                strSql &= "FROM tworkorder " & Environment.NewLine
                                strSql &= "WHERE WO_ID_Original = " & iOldWOID.ToString & " AND Group_ID = " & iNewGrpID.ToString & Environment.NewLine

                                If Not IsNothing(dt2) Then dt2 = New DataTable()
                                dt2 = Me._objMisc.GetDataTable(strSql)

                                If Not IsNothing(dt2) Then
                                    If dt2.Rows.Count > 0 Then iNewWOID = CInt(dt2.Rows(0)("WO_ID"))

                                    If iNewWOID > 0 Then
                                        ' Update tdevice with the new work order ID for the device
                                        strSql = "UPDATE tdevice " & Environment.NewLine
                                        strSql &= "SET WO_ID = " & iNewWOID.ToString & Environment.NewLine
                                        strSql &= "WHERE Device_ID = " & iDeviceID.ToString

                                        Me._objMisc.ExecuteNonQuery(strSql)
                                    End If
                                End If

                                ' Update tcellopt.  Reset Cellop_WIPOwner.
                                strSql = "SELECT A.Group_Desc AS GroupDesc " & Environment.NewLine
                                strSql &= "FROM lgroups A " & Environment.NewLine
                                strSql &= "INNER JOIN tcellopt B ON B.Cellopt_WIPOwner = A.Group_ID " & Environment.NewLine
                                strSql &= "WHERE B.Device_ID = " & dr1("Device_ID")

                                If Not IsNothing(dt2) Then dt2 = New DataTable()
                                dt2 = Me._objMisc.GetDataTable(strSql)
                                strGrpDesc = ""

                                If Not IsNothing(dt2) Then
                                    If dt2.Rows.Count > 0 Then
                                        ' Switch group IDs
                                        dr2 = dt2.Rows(0)
                                        strGrpDesc = dr2("GroupDesc")
                                        iOldLine = CInt(strGrpDesc.Substring(9, 1)) ' Get the number after "CELLULAR ".
                                        ' Only possible values for iNewLine are 1 and 2, where iOldLine-> iNewLine has the 
                                        ' mappings 1->2 and 2->1.
                                        iNewLine = 1 + (iOldLine Mod 2)
                                        strGrpDesc = strGrpDesc.Substring(0, 9) & iNewLine & strGrpDesc.Substring(10, strGrpDesc.Length - 10)
                                        dr2 = Nothing
                                    End If ' dt2.Rows.Count > 0
                                End If ' Not IsNothing(dt2)

                                If strGrpDesc.Length > 0 Then
                                    strSql = "SELECT Group_ID " & Environment.NewLine
                                    strSql &= "FROM lgroups " & Environment.NewLine
                                    strSql &= "WHERE UPPER(Group_Desc) = '" & strGrpDesc.ToUpper & "'"

                                    If Not IsNothing(dt2) Then dt2 = New DataTable()
                                    dt2 = Me._objMisc.GetDataTable(strSql)

                                    If Not IsNothing(dt2) Then
                                        If dt2.Rows.Count > 0 Then
                                            dr2 = dt2.Rows(0)
                                            iNewGrpID = CInt(dr2("Group_ID"))

                                            strSql = "UPDATE tcellopt " & Environment.NewLine
                                            strSql &= "SET Cellopt_WIPOwner = " & iNewGrpID & Environment.NewLine
                                            strSql &= "WHERE Device_ID = " & dr1("Device_ID")

                                            Me._objMisc.ExecuteNonQuery(strSql)
                                            dr2 = Nothing
                                        End If ' dt2.Rows.Count > 0
                                    End If ' Not IsNothing(dt2)
                                End If ' strGrpDesc.Length > 0
                            Else
                                Me._objMisc.DisplayMessage(sf.GetMethod, "New record not added to tworkorder for pallette.")
                            End If ' bUpdateSuccessful
                        Next ' dr1 In dt1.Rows
                    End If ' dt1.Rows.Count > 0
                End If ' Not IsNothing(dt1)
            Catch ex As Exception
                Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
            Finally
                dr1 = Nothing
                dr2 = Nothing

                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If

                If Not IsNothing(dt2) Then
                    dt2.Dispose()
                    dt2 = Nothing
                End If
            End Try
        End Sub

        Private Function ProcessDataField(ByVal dr As DataRow, ByVal strFieldName As String, Optional ByVal bDateTime As Boolean = True) As String
            Const chQuote As Char = Chr(34)
            Dim strRet As String = "'"
            Dim datVal As Date
            Dim sf As New StackFrame(0)

            Try
                If IsDBNull(dr(strFieldName)) Then
                    strRet = "NULL"
                Else
                    Select Case dr(strFieldName).GetType.ToString
                        Case "System.DateTime"
                            datVal = CDate(dr(strFieldName))

                            If bDateTime Then
                                strRet = chQuote & String.Format("{0}-{1:D2}-{2:D2} {3:D2}:{4:D2}:{5:D2}", datVal.Year, datVal.Month, datVal.Day, datVal.Hour, datVal.Minute, datVal.Second) & chQuote
                            Else ' Date only
                                strRet = chQuote & String.Format("{0}-{1:D2}-{2:D2}", datVal.Year, datVal.Month, datVal.Day) & chQuote
                            End If
                        Case "System.String"
                            strRet = chQuote & dr(strFieldName) & chQuote
                        Case Else
                            strRet = dr(strFieldName)
                    End Select
                End If

                Return strRet
            Catch ex As Exception
                Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
            End Try
        End Function

        Public Sub DeviceShipped(ByVal iDeviceID As Integer)
            ' Check cellular devices to see if they were part of a transferred shipment.  
            ' If so, update tdevice accordingly and drop the corresponding transfer record from tworkorder.
            Dim strSql As String
            Dim iWOIDNew, iWOIDOriginal As Integer
            Dim dt As DataTable
            Dim sf As New StackFrame(0)

            Try
                strSql = "SELECT A.WO_ID AS WO_ID, B.WO_ID_Original AS WO_ID_Original " & Environment.NewLine
                strSql &= "FROM tdevice A" & Environment.NewLine
                strSql &= "INNER JOIN tworkorder B ON B.WO_ID = A.WO_ID " & Environment.NewLine
                strSql &= "WHERE A.Device_ID = " & iDeviceID.ToString & " AND B.WO_ID_Original IS NOT NULL"

                dt = Me._objMisc.GetDataTable(strSql)

                If Not IsNothing(dt) Then
                    If dt.Rows.Count > 0 Then
                        ' Reset WO_ID back to the original in tdevice for ALL devices with the new workorder ID.
                        iWOIDNew = CInt(dt.Rows(0)("WO_ID"))
                        iWOIDOriginal = CInt(dt.Rows(0)("WO_ID_Original"))

                        strSql = "UPDATE tdevice " & Environment.NewLine
                        strSql &= "SET WO_ID = " & iWOIDOriginal.ToString & Environment.NewLine
                        strSql &= "WHERE WO_ID = " & iWOIDNew.ToString

                        If Me._objMisc.ExecuteNonQuery(strSql) Then
                            ' Drop the row from tworkorder with the new workorder ID.
                            strSql = "DELETE FROM tworkorder " & Environment.NewLine
                            strSql &= "WHERE WO_ID = " & iWOIDNew.ToString

                            Me._objMisc.ExecuteNonQuery(strSql)
                        End If
                    End If
                End If
            Catch ex As Exception
                Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
            End Try
        End Sub

#Region "Properties"
        Public ReadOnly Property DeviceID() As Integer
            Get
                Return Me._iDeviceID
            End Get
        End Property

        Public ReadOnly Property DeviceSN() As String
            Get
                Return Me._strDeviceSN
            End Get
        End Property
#End Region
    End Class
End Namespace
