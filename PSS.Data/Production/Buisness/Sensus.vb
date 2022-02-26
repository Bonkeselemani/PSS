Option Explicit On 

Imports CrystalDecisions.CrystalReports.Engine
Imports System.Windows.Forms
Imports System.IO

Namespace Buisness
    Public Class Sensus

        Private _objDataProc As DBQuery.DataProc
        Private _strDeptPath As String = "P:\Dept\Sensus\"
        Private _strShipManifestFolder As String = "Pallet Packing List\"

        '******************************************************************
        Public Sub New()
            Try
                Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '******************************************************************

#Region "Properties"
        '******************************************************************
        Public Shared ReadOnly Property SENSUS_CUSTOMER_ID() As Integer
            Get
                Return 2253
            End Get
        End Property

        '******************************************************************
        Public Shared ReadOnly Property SENSUS_LOCATION_ID() As Integer
            Get
                Return 2777
            End Get
        End Property

        '******************************************************************
        Public Shared ReadOnly Property SENSUS_GROUP_ID() As Integer
            Get
                Return 80
            End Get
        End Property

        '******************************************************************
        Public Shared ReadOnly Property PALLET_LIMIT() As Integer
            Get
                Return 96
            End Get
        End Property

        '******************************************************************
        Public ReadOnly Property SHIP_MANIFEST_LOC() As String
            Get
                Return Me._strDeptPath & Me._strShipManifestFolder
            End Get
        End Property

#End Region

#Region "Build Ship Pallet"

        '******************************************************************
        Public Function GetOpenPalletByLine(ByVal strPalletPrefix As String, ByVal iModelID As Integer) As DataTable
            Dim strSql As String
            Dim dt As DataTable
            Dim R1 As DataRow

            Try
                strSql = "SELECT Model_ID, tpallett.Pallett_ID, tpallett.pkslip_ID, tpallett.Pallett_Name as 'Pallet Name', Pallet_SkuLen as 'Location', 0 as Qty " + Environment.NewLine
                strSql += "FROM tpallett " + Environment.NewLine
                strSql += "WHERE tpallett.Pallett_Name like '" + strPalletPrefix + "%'" + Environment.NewLine
                strSql += "AND tpallett.Loc_ID = " + Me.SENSUS_LOCATION_ID.ToString + Environment.NewLine
                strSql += "AND tpallett.Model_ID = " + iModelID.ToString + Environment.NewLine
                strSql += "AND tpallett.Pallett_ShipDate is null " + Environment.NewLine
                strSql += "AND Pallet_Invalid = 0 " + Environment.NewLine
                strSql += "ORDER BY Pallet_SkuLen " + Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                For Each R1 In dt.Rows
                    R1.BeginEdit()
                    R1("Qty") = CInt(Me.GetPalletQty(R1("Pallett_ID")))
                    R1.EndEdit()
                    dt.AcceptChanges()
                Next R1

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
                R1 = Nothing
            End Try
        End Function

        '******************************************************************
        Public Function GetPalletQty(ByVal iPalletID As Integer) As Integer
            Dim strSql As String
            Try
                strSql = "SELECT count(*) as Qty FROM tdevice WHERE Pallett_ID = " + iPalletID.ToString
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetSensusDeviceInWip(ByVal strSN As String) As DataTable
            Dim strSql As String
            Try
                strSql = "SELECT sd_RMA_Num, sd_DateShipped, sd_RR_Num, tsensusdata.Device_ID " + Environment.NewLine
                strSql += ", tdevice.Device_DateShip, Device_LaborCharge, tdevice.Model_ID as 'DeviceModelID' " + Environment.NewLine
                strSql += ", tpallett.* " + Environment.NewLine
                strSql += ", if(sd_Status = 'Dispose Upon Receipt', 'PSS', if(sd_QALoc = 1, 'Sensus', sd_loc)) as 'ShipLoc'" + Environment.NewLine
                strSql += "FROM tsensusdata " + Environment.NewLine
                strSql += "LEFT OUTER JOIN tdevice ON tsensusdata.Device_ID = tdevice.Device_ID " + Environment.NewLine
                strSql += "LEFT OUTER JOIN tpallett ON tdevice.pallett_ID = tpallett.Pallett_ID " + Environment.NewLine
                strSql += "WHERE sd_SN = '" + strSN + "' " + Environment.NewLine
                strSql += "AND ( Device_DateShip is null or Device_DateShip = '' or Device_DateShip = '0000-00-00 00:00:00' ) " + Environment.NewLine
                strSql += "ORDER BY tsensusdata.Device_ID desc;"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetSensusDeviceLatestRecord(ByVal strSN As String) As DataTable
            Dim strSql As String
            Try
                strSql = "SELECT tsensusdata.* " + Environment.NewLine
                strSql += ", tdevice.Device_DateShip, Device_LaborCharge " + Environment.NewLine
                strSql += ", tpallett.* " + Environment.NewLine
                strSql += "FROM tsensusdata " + Environment.NewLine
                strSql += "LEFT OUTER JOIN tdevice ON tsensusdata.Device_ID = tdevice.Device_ID " + Environment.NewLine
                strSql += "LEFT OUTER JOIN tpallett ON tdevice.pallett_ID = tpallett.Pallett_ID " + Environment.NewLine
                strSql += "WHERE sd_SN = '" + strSN + "' " + Environment.NewLine
                'strSql += "AND ( Device_DateShip is null or Device_DateShip = '' or Device_DateShip = '0000-00-00 00:00:00' ) " + Environment.NewLine
                strSql += "ORDER BY tsensusdata.Device_ID desc;"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function IsSNEligibleForAddToPallet(ByVal iPalletID As Integer, _
                                                  ByVal strRR As String, _
                                                  ByVal strPalletName As String, _
                                                  ByVal strShipToLoc As String) As Boolean
            Dim strSql As String
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim booResult As Boolean = False
            Dim strMsg As String = ""

            Try
                strSql = "SELECT DISTINCT tsensusdata.sd_RR_Num as 'RR#', 0 as 'RR Qty', count(*) as 'On Pallet Qty' " + Environment.NewLine
                strSql += "FROM tdevice " + Environment.NewLine
                strSql += "INNER JOIN tsensusdata ON tdevice.Device_ID = tsensusdata.Device_ID " + Environment.NewLine
                strSql += "WHERE pallett_ID = " + iPalletID.ToString + Environment.NewLine
                strSql += "AND (sd_Status is null or sd_Status <> 'Dispose Upon Receipt')" + Environment.NewLine
                strSql += "GROUP BY tsensusdata.sd_RR_Num " + Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    For Each R1 In dt.Rows
                        R1.BeginEdit()
                        R1("RR Qty") = Me.GetRRQty(R1("RR#"))
                        strMsg += R1("RR#").ToString.ToUpper + " = " + R1("RR Qty").ToString + Environment.NewLine
                        R1.EndEdit()
                        R1.AcceptChanges()
                    Next R1

                    If dt.Compute("Sum([RR Qty])", "") > Me.PALLET_LIMIT Then
                        MessageBox.Show("Total units of RRs in pallet have exceeded the limit of 96. " & strMsg & "Please adjust that and continue.", "Pallet Limitation", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ElseIf dt.Select("[RR#] = '" & strRR & "'").Length = 0 And (dt.Compute("Sum([RR Qty])", "") + Me.GetRRQty(strRR)) > Me.PALLET_LIMIT Then
                        MessageBox.Show("RR quantity of this unit combine together with current open pallet(" & strPalletName & ") will exceed the limit of " & Me.PALLET_LIMIT & ". Please set them a side for next pallet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ElseIf dt.Select("[RR#] = '" & strRR & "'").Length > 0 Then
                        booResult = True
                    Else
                        booResult = True
                    End If
                Else
                    booResult = True
                End If

                Return booResult
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetRRQty(ByVal strRRNum As String) As Integer
            Dim strSql As String
            Try
                strSql = "SELECT count(*) as cnt FROM tsensusdata " & Environment.NewLine
                strSql &= "INNER JOIN tdevice on tsensusdata.Device_ID = tdevice.Device_ID " & Environment.NewLine
                strSql &= "WHERE sd_RR_Num = '" + strRRNum + "' AND (sd_Status is null or sd_Status <> 'Dispose Upon Receipt') " & Environment.NewLine
                strSql &= "AND Device_DateShip is null; "
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function CreateShipPallet(ByVal strPalletPrefix As String, _
                                         ByVal strSkuLength As String, _
                                         ByVal iModelID As Integer, _
                                         ByVal iUsrID As Integer, _
                                         ByRef strRetPalletName As String) As Integer
            Dim strSql As String = ""
            Dim strDate As String = ""
            Dim strPalletName As String = ""
            Dim iPalletID As Integer = 0
            Dim i As Integer = 0
            Dim dtShipLoc, dt As DataTable

            Try
                strSql = "SELECT * FROM tpallett " & Environment.NewLine
                strSql &= "WHERE cust_ID = " & Me.SENSUS_CUSTOMER_ID & Environment.NewLine
                strSql &= "AND Model_ID = " & iModelID & Environment.NewLine
                strSql &= "AND Pallet_Invalid = 0  " & Environment.NewLine
                strSql &= "AND Pallet_SkuLen = '" & strSkuLength & "' " & Environment.NewLine
                strSql &= "AND Pallett_ShipDate is null"
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    iPalletID = dt.Rows(0)("Pallett_ID")
                    strRetPalletName = dt.Rows(0)("Pallett_Name")
                Else
                    '******************************
                    'Get ship to ID
                    '******************************
                    strSql = "Select * from tcustshiptoloc WHERE cust_ID = " & Me.SENSUS_CUSTOMER_ID & " AND CS_Inactive = 0 AND CS_Desc = '" & strSkuLength & "'"
                    dtShipLoc = Me._objDataProc.GetDataTable(strSql)

                    If dtShipLoc.Rows.Count = 0 Then
                        Throw New Exception("No ship address found for this location (" & strSkuLength & "). Please contact IT.")
                    ElseIf dtShipLoc.Rows.Count > 1 Then
                        Throw New Exception("More than one ship address found for this location (" & strSkuLength & "). Please contact IT.")
                    Else
                        '******************************
                        'construct pallet name
                        '******************************
                        strDate = Generic.GetMySqlDateTime("%y%m%d")

                        strPalletPrefix = strPalletPrefix + strDate + Left(strSkuLength, 1)

                        strPalletName = Me.DefinePalletName(strPalletPrefix)

                        '******************************
                        'check for duplicate pallet
                        '******************************
                        strSql = "Select count(*) as cnt From tpallett where Pallett_Name = '" & strPalletName & "' and Loc_ID = " & Me.SENSUS_LOCATION_ID
                        If Me._objDataProc.GetIntValue(strSql) > 0 Then Throw New Exception("System is trying to create pallet (" & strPalletName & ") which is already existed in system.")

                        '******************************
                        'Create pallet
                        ''******************************
                        strSql = "INSERT INTO tpallett ( " & Environment.NewLine
                        strSql &= "Pallett_Name " & Environment.NewLine
                        strSql &= ", Pallet_SkuLen " & Environment.NewLine
                        strSql &= ", Pallett_ReadyToShipFlg " & Environment.NewLine
                        strSql &= ", Pallet_ShipType " & Environment.NewLine
                        strSql &= ", Cust_ID  " & Environment.NewLine
                        strSql &= ", Loc_ID  " & Environment.NewLine
                        strSql &= ", Model_ID  " & Environment.NewLine
                        strSql &= ") VALUES (  " & Environment.NewLine
                        strSql &= "'" & strPalletName & "' " & Environment.NewLine
                        strSql &= ", '" & strSkuLength & "' " & Environment.NewLine
                        strSql &= ", 1 " & Environment.NewLine
                        strSql &= ", 0  " & Environment.NewLine
                        strSql &= ", " & Me.SENSUS_CUSTOMER_ID & " " & Environment.NewLine
                        strSql &= ", " & Me.SENSUS_LOCATION_ID & Environment.NewLine
                        strSql &= ", " & iModelID & Environment.NewLine
                        strSql &= ");" & Environment.NewLine
                        iPalletID = Me._objDataProc.idTransaction(strSql, "tpallett")

                        If iPalletID = 0 Then iPalletID = Me.GetPalletID(strPalletName, strSkuLength)

                        '******************************
                        'Set Ship to address of pallet
                        '******************************
                        i = Me.CreateShipToLocation(iUsrID, iPalletID, dtShipLoc.Rows(0)("ShipTo_ID"))
                        If i = 0 Then Throw New Exception("System has failed to create ship to address for new pallet(" & strPalletName & ").")
                        strRetPalletName = strPalletName

                        '******************************
                    End If
                End If

                Return iPalletID
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtShipLoc)
            End Try
        End Function

        '******************************************************************
        Public Function CreateShipToLocation(ByVal iUsrID As Integer, _
                                             ByVal iPalletID As Integer, _
                                             ByVal iShipTo_ID As Integer) As Integer
            Dim strSQL As String

            Try
                strSQL = "INSERT INTO tpalletshiptoloc ( " & Environment.NewLine
                strSQL &= "PS_RecDt " & Environment.NewLine
                strSQL &= ", PS_UsrID " & Environment.NewLine
                strSQL &= ", Pallett_ID " & Environment.NewLine
                strSQL &= ", ShipTo_ID " & Environment.NewLine
                strSQL &= " ) VALUES (" & Environment.NewLine
                strSQL &= "now() " & Environment.NewLine
                strSQL &= ", " & iUsrID & " " & Environment.NewLine
                strSQL &= ", " & iPalletID & " " & Environment.NewLine
                strSQL &= ", " & iShipTo_ID & " " & Environment.NewLine
                strSQL &= "); " & Environment.NewLine

                Return Me._objDataProc.ExecuteNonQuery(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Private Function DefinePalletName(ByVal strPalletPrefix As String) As String
            Dim strSQL As String
            Dim dt As DataTable
            Dim strPallett_Name As String = strPalletPrefix

            Try
                strSQL = "SELECT max(right(Pallett_Name, 3) ) + 1 as Pallett_Num " & Environment.NewLine
                strSQL &= "FROM tpallett " & Environment.NewLine
                strSQL &= "WHERE Pallett_Name like '" & strPalletPrefix & "%' " & Environment.NewLine
                strSQL &= "AND Cust_ID = " & Me.SENSUS_CUSTOMER_ID & Environment.NewLine
                strSQL &= "AND Loc_ID = " & Me.SENSUS_LOCATION_ID & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSQL)
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0)("Pallett_Num")) Then
                        strPallett_Name &= Format(dt.Rows(0)("Pallett_Num"), "000")
                    Else
                        strPallett_Name &= "001"
                    End If
                Else
                    strPallett_Name &= "001"
                End If

                Return strPallett_Name
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function AssignUnitToPallet(ByVal iPalletID As Integer, _
                                           ByVal iDeviceID As Integer, _
                                           ByVal iUserID As Integer) As Integer
            Dim strSQL As String
            Dim iPalletizeSeq As Integer = 0
            Try
                iPalletizeSeq = GetMaxPaletizeSequence(iPalletID)
                If iPalletizeSeq = 0 Then iPalletizeSeq += 1
                strSQL = "UPDATE tdevice, tsensusdata " + Environment.NewLine
                strSQL += "SET tdevice.Pallett_ID = " + iPalletID.ToString + Environment.NewLine
                strSQL += ", tsensusdata.Palletize_UsrID = " + iUserID.ToString + Environment.NewLine
                strSQL += ", tsensusdata.Palletize_Seq = " + iPalletizeSeq.ToString + Environment.NewLine
                strSQL += "WHERE tdevice.Device_ID = tsensusdata.Device_ID " + Environment.NewLine
                strSQL += "AND tdevice.Device_ID = " + iDeviceID.ToString + Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Private Function GetMaxPaletizeSequence(ByVal iPalletID As Integer) As Integer
            Dim strSQL As String

            Try
                strSQL = "SELECT (max(Palletize_Seq) + 1) as 'NextSeqNo' " + Environment.NewLine
                strSQL += "FROM tsensusdata " + Environment.NewLine
                strSQL += "INNER JOIN tdevice ON tsensusdata.Device_ID = tdevice.Device_ID " & Environment.NewLine
                strSQL += "WHERE pallett_id = " + iPalletID.ToString + " " & Environment.NewLine
                Return Me._objDataProc.GetIntValue(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetPalletID(ByVal strPalletName As String, _
                                    ByVal strSkuLength As String) As Integer
            Dim strSQL As String

            Try
                strSQL = "SELECT Pallett_ID FROM tpallett " + Environment.NewLine
                strSQL += "WHERE Pallett_Name = '" + strPalletName + "' " + Environment.NewLine
                strSQL += "AND Pallet_SkuLen = '" + strSkuLength + "' " + Environment.NewLine
                strSQL += "AND Cust_ID = " + Me.SENSUS_CUSTOMER_ID.ToString + Environment.NewLine
                strSQL += "AND Loc_ID = " + Me.SENSUS_LOCATION_ID.ToString + Environment.NewLine
                strSQL += "ORDER BY Pallett_ID Desc;"
                Return Me._objDataProc.GetIntValue(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function IsExistedInTdevicebill(ByVal iDeviceID As Integer) As Boolean
            Dim strSQL As String

            Try
                strSQL = "SELECT count(*) as cnt FROM tdevicebill where Device_ID = " + iDeviceID.ToString + Environment.NewLine
                If Me._objDataProc.GetIntValue(strSQL) > 0 Then Return True Else Return False
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function RemoveUnitFrPallet(ByVal iDeviceID As Integer, _
                                           ByVal iPalletID As Integer) As Integer
            Dim strSql As String

            Try
                strSql = "UPDATE tdevice, tsensusdata " + Environment.NewLine
                strSql += "SET tdevice.Pallett_ID = null " + Environment.NewLine
                strSql += ", tsensusdata.Palletize_UsrID = null " + Environment.NewLine
                strSql += ", tsensusdata.Palletize_Seq = 0 " + Environment.NewLine
                strSql += "WHERE tdevice.Device_ID = tsensusdata.Device_ID " + Environment.NewLine
                strSql += "AND tdevice.Device_ID = " + iDeviceID.ToString + Environment.NewLine
                strSql += "AND tdevice.Pallett_ID = " + iPalletID.ToString + Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function DeleteEmptyPallet(ByVal iPalletID As Integer, _
                                          ByVal iUsrID As Integer) As Integer
            Dim strSql As String

            Try
                strSql = "UPDATE tpallett SET Pallett_QTY = 0, Pallet_Invalid = 1, Pallet_InvalidUsrID = " + iUsrID.ToString + Environment.NewLine
                strSql += "WHERE Pallett_ID = " + iPalletID.ToString + Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function IsEligibleToCloseAndShip(ByVal iPalletID As Integer, ByVal strLoc As String) As Boolean
            Dim strSql As String
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim booResult As Boolean = False
            Dim strMsg As String = ""
            Dim iNoPalletAssignUnit As Integer = 0

            Try
                IsEligibleToCloseAndShip = booResult

                strSql = "SELECT DISTINCT tsensusdata.sd_RR_Num as 'RR#', 0 as 'RR Qty', count(*) as 'On Pallet Qty' " + Environment.NewLine
                strSql += "FROM tdevice " + Environment.NewLine
                strSql += "INNER JOIN tsensusdata ON tdevice.Device_ID = tsensusdata.Device_ID " + Environment.NewLine
                strSql += "WHERE pallett_ID = " + iPalletID.ToString + Environment.NewLine
                strSql += "AND (sd_Status is null or sd_Status <> 'Dispose Upon Receipt')" + Environment.NewLine
                strSql += "GROUP BY tsensusdata.sd_RR_Num " + Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    For Each R1 In dt.Rows
                        R1.BeginEdit()
                        R1("RR Qty") = Me.GetRRQty(R1("RR#"))
                        strMsg += R1("RR#").ToString.ToUpper + " = " + R1("RR Qty").ToString + Environment.NewLine
                        R1.EndEdit()
                        R1.AcceptChanges()
                    Next R1

                    If dt.Compute("Sum([RR Qty])", "") > Me.PALLET_LIMIT Then
                        MessageBox.Show("Total units of RRs in pallet have exceeded the limit of " & Me.PALLET_LIMIT & ". " & strMsg & "Please adjust that and continue.", "Pallet Limitation", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        For Each R1 In dt.Rows
                            iNoPalletAssignUnit = 0
                            iNoPalletAssignUnit = Me.GetUnitsOfRRWithoutPalletID(R1("RR#"))
                            If iNoPalletAssignUnit > 0 Then
                                If MessageBox.Show("There are at least " & iNoPalletAssignUnit & " units without pallet ID." & Environment.NewLine & "Cannot close pallet with incomplete RR." & Environment.NewLine & "Would you like to print discrepancy report?", "Pallet Limitation", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then Me.PrintSensusPalletOpenRRUnits(iPalletID)
                                Exit Function
                            End If
                        Next R1

                        If dt.Compute("Sum([On Pallet Qty])", "") <> dt.Compute("Sum([RR Qty])", "") Then
                            MessageBox.Show("There are discrepancy between pallet quantity and total RR quantity." & Environment.NewLine & "Pallet Qty:" & dt.Compute("Sum([RR Qty])", "") & Environment.NewLine & "RRs Qty:" & dt.Compute("Sum([On Pallet Qty])", "") & Environment.NewLine & "Please make that adjustment before continue.", "Pallet Limitation", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Function
                        End If

                        booResult = True
                    End If
                Else
                    MessageBox.Show("No RR# is existing in pallet.", "Pallet Limitation", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                Return booResult
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetUnitsOfRRWithoutPalletID(ByVal strRRNum As String) As Integer
            Dim strSql As String
            Try
                strSql = "SELECT count(*) as cnt " & Environment.NewLine
                strSql &= "FROM tsensusdata " & Environment.NewLine
                strSql &= "INNER JOIN tdevice ON tsensusdata.Device_ID = tdevice.Device_ID " & Environment.NewLine
                strSql &= "WHERE tsensusdata.sd_RR_Num = '" & strRRNum & "'" & Environment.NewLine
                strSql += "AND (sd_Status is null or sd_Status <> 'Dispose Upon Receipt')" + Environment.NewLine
                strSql &= "AND ( tdevice.Pallett_ID is null or tdevice.Pallett_ID = 0 )" & Environment.NewLine
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '******************************************************************
        Public Function CloseAndShipPallet(ByVal iPalletID As Integer, _
                                           ByVal strPalletName As String, _
                                           ByVal strModelDesc As String, _
                                           ByVal strLoc As String, _
                                           ByVal iShiftID As Integer, _
                                           ByVal iUserID As Integer) As Integer
            Const iCopies As Integer = 2
            Dim strSql As String
            Dim iQty As Integer = 0
            Dim i As Integer = 0

            Try
                iQty = Me.GetPalletQty(iPalletID)
                Me.PrintSensusPalletLabel(strPalletName, iQty, strLoc, strModelDesc, iCopies)

                '*****************************
                '2: Write Ship date to Pallet
                '*****************************
                strSql = "UPDATE tdevice, tsensusdata " + Environment.NewLine
                strSql += "SET Device_DateShip = now() " + Environment.NewLine
                strSql += ", Device_ShipWorkDate = '" + Generic.GetWorkDate(iShiftID) + "' " + Environment.NewLine
                strSql += ", Shift_ID_Ship = " + iShiftID.ToString + Environment.NewLine
                strSql += ", tsensusdata.ProdShip_UsrID = " + iUserID.ToString + Environment.NewLine
                strSql += "WHERE tdevice.Device_ID = tsensusdata.Device_ID " & Environment.NewLine
                strSql += "AND tdevice.Pallett_ID = " + iPalletID.ToString + Environment.NewLine
                strSql += "AND tdevice.Loc_ID = " + Me.SENSUS_LOCATION_ID.ToString + Environment.NewLine
                strSql += "AND tdevice.Device_DateShip is null " + Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)
                If i = 0 Then Throw New Exception("System has failed to ship devices on the pallet.")

                '*****************************
                '3: Write Ship date to Pallet
                '*****************************
                strSql = "UPDATE tpallett " + Environment.NewLine
                strSql += "SET Pallett_ShipDate = now() " + Environment.NewLine
                strSql += ", Pallett_BulkShipped = 1 " + Environment.NewLine
                strSql += ", Pallett_QTY = " + iQty.ToString + Environment.NewLine
                strSql += "WHERE tpallett.Pallett_ID = " + iPalletID.ToString + Environment.NewLine
                strSql += "AND tpallett.Loc_ID = " + Me.SENSUS_LOCATION_ID.ToString + Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)
                If i = 0 Then Throw New Exception("System has failed to ship pallet.")

                '************************
                '4: Create Excel File
                '************************
                i = Me.CreateAndPrintManifestReport(iPalletID, strPalletName, strLoc, iCopies)

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function PrintSensusPalletLabel(ByVal strPalletName As String, _
                                               ByVal iQty As Integer, _
                                               ByVal strLoc As String, _
                                               ByVal strModelDesc As String, _
                                               ByVal iCopies As Integer) As Integer
            Const strReportName As String = "Ship Pallet Label Push.rpt"
            Dim dt As DataTable
            Dim objDBRManifest As DBRManifest
            Dim i As Integer = 0

            Try
                objDBRManifest = New DBRManifest()

                '*****************************
                '1: Print License Plate
                '*****************************
                dt = objDBRManifest.GetShipPalletData(strPalletName, iQty, strModelDesc, strLoc, New String() {"Leader Verification:", "", "Shipper Verification:"})

                Return Me.PrintCrystalRpt(dt, strReportName, iCopies)
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
                objDBRManifest = Nothing
            End Try
        End Function

        '******************************************************************
        Public Function CreateAndPrintManifestReport(ByVal iPalletID As Integer, _
                                                     ByVal strFileName As String, _
                                                     ByVal strLoc As String, _
                                                     ByVal iPrintCopyNo As Integer) As Integer
            Const iTotalHeader As Integer = 1
            'Excel Related variables
            Dim objDataProc As DBQuery.DataProc
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet
            Dim xlBI As Excel.XlBordersIndex() = {Excel.XlBordersIndex.xlEdgeLeft, Excel.XlBordersIndex.xlEdgeTop, Excel.XlBordersIndex.xlEdgeBottom, _
                Excel.XlBordersIndex.xlEdgeRight, Excel.XlBordersIndex.xlInsideVertical, Excel.XlBordersIndex.xlInsideHorizontal}

            Dim strFilePath, strSql As String
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim objArr(,) As Object
            Dim i, j As Integer

            Try
                strFilePath = Me._strDeptPath + _strShipManifestFolder + strFileName + ".xls"

                strSql = "SELECT 0 as 'Line#' " & Environment.NewLine
                strSql += ", Model_Desc as 'Model', tsensusdata.sd_RMA_Num as 'RMA', tsensusdata.sd_RR_Num as 'RR#' " + Environment.NewLine
                strSql += ", tsensusdata.sd_SN as 'SN',  tsensusdata.sd_Meter_ID as 'Meter ID' " + Environment.NewLine
                strSql += "FROM tdevice " + Environment.NewLine
                strSql += "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " + Environment.NewLine
                strSql += "INNER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID " + Environment.NewLine
                strSql += "INNER JOIN tsensusdata ON tdevice.Device_ID = tsensusdata.Device_ID " + Environment.NewLine
                strSql += "WHERE tdevice.Pallett_ID = " + iPalletID.ToString + " " + Environment.NewLine
                strSql += "ORDER BY tsensusdata.sd_RR_Num " + Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                'Create Line #
                i = 0
                For Each R1 In dt.Rows
                    i += 1
                    R1.BeginEdit()
                    R1("Line#") = i
                    R1.EndEdit()
                    R1.AcceptChanges()
                Next R1
                dt.AcceptChanges()

                If dt.Rows.Count > 0 Then
                    ReDim objArr(dt.Rows.Count + iTotalHeader, dt.Columns.Count)

                    ''Write title & total
                    'objArr(0, 0) = "Pallet Manifest"
                    'objArr(1, 0) = "Pallet ID: " + strFileName
                    'objArr(2, 0) = "Destination: " + strLoc
                    'objArr(3, 0) = "Total: " + dt.Rows.Count.ToString

                    'Write Header
                    For i = 0 To dt.Columns.Count - 1
                        objArr(iTotalHeader - 1, i) = dt.Columns(i).Caption
                    Next i

                    'Write Data
                    For i = 0 To dt.Rows.Count - 1
                        For j = 0 To dt.Columns.Count - 1
                            objArr(i + iTotalHeader, j) = dt.Rows(i)(j)
                        Next
                    Next i

                    'Instantiate Excel Object
                    objExcel = New Excel.Application()      'Starts the Excel Session
                    objBook = objExcel.Workbooks.Add                    'Add a Workbook
                    objExcel.Application.Visible = True                'Make this false while going live
                    objExcel.Application.DisplayAlerts = False
                    objSheet = objBook.Worksheets.Item(1)               'Select a Sheet 1 for this

                    objExcel.ActiveSheet.Pagesetup.Orientation = 2      ' 1 = Portrait ; 2 = landscape

                    '*******************************
                    'set text format
                    '*******************************
                    For i = 1 To dt.Columns.Count - 1
                        objSheet.Columns(i + 1).Select()
                        objExcel.Selection.NumberFormat = "@"
                    Next i

                    objSheet.Range("A1" & ":" & Generic.CalExcelColLetter(dt.Columns.Count) & (dt.Rows.Count + iTotalHeader).ToString).Value = objArr

                    ''*******************************
                    ''Titles & Total
                    ''*******************************
                    'objSheet.Range("A1:" & Generic.CalExcelColLetter(dt.Columns.Count) & (iTotalHeader - 1).ToString).HorizontalAlignment = Excel.Constants.xlLeft
                    'objSheet.Range("A1:" & Generic.CalExcelColLetter(dt.Columns.Count) & (iTotalHeader - 1).ToString).VerticalAlignment = Excel.Constants.xlCenter
                    ''*******************************
                    'With objSheet.Range("A1:" & Generic.CalExcelColLetter(dt.Columns.Count) & (iTotalHeader - 1).ToString).Font
                    '    .Name = "Arial"
                    '    .FontStyle = "Bold"
                    '    .Size = 14
                    '    .Underline = False
                    '    .ColorIndex = 25
                    'End With
                    'objSheet.Range("A1", Generic.CalExcelColLetter(dt.Columns.Count) & (1).ToString).Merge()
                    'objSheet.Range("A2", Generic.CalExcelColLetter(dt.Columns.Count) & (2).ToString).Merge()
                    'objSheet.Range("A3", Generic.CalExcelColLetter(dt.Columns.Count) & (3).ToString).Merge()
                    'objSheet.Range("A4", Generic.CalExcelColLetter(dt.Columns.Count) & (4).ToString).Merge()

                    '*******************************
                    'header
                    '*******************************
                    objSheet.Range("A" & iTotalHeader & ":" & Generic.CalExcelColLetter(dt.Columns.Count) & iTotalHeader.ToString).HorizontalAlignment = Excel.Constants.xlCenter
                    objSheet.Range("A" & iTotalHeader & ":" & Generic.CalExcelColLetter(dt.Columns.Count) & iTotalHeader.ToString).VerticalAlignment = Excel.Constants.xlCenter
                    '*******************************
                    With objSheet.Range("A" & iTotalHeader & ":" & Generic.CalExcelColLetter(dt.Columns.Count) & iTotalHeader.ToString).Font
                        .Name = "Arial"
                        .FontStyle = "Bold"
                        .Size = 8
                        .Underline = False
                        .ColorIndex = 25
                    End With
                    objExcel.Range("A" & iTotalHeader & ":" & Generic.CalExcelColLetter(dt.Columns.Count) & iTotalHeader.ToString).Select()
                    objExcel.Selection.Interior.ColorIndex = 15 'LIGHT GRAY

                    '*******************************
                    'set border
                    '*******************************
                    objExcel.Range("A" & iTotalHeader & ":" & Generic.CalExcelColLetter(dt.Columns.Count) & (dt.Rows.Count + iTotalHeader).ToString).Select()
                    objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.Constants.xlNone
                    objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.Constants.xlNone

                    For j = 0 To xlBI.Length - 1
                        With objExcel.Selection.Borders(xlBI(j))
                            .LineStyle = Excel.XlLineStyle.xlContinuous
                            .Weight = Excel.XlBorderWeight.xlThin
                            .ColorIndex = Excel.Constants.xlAutomatic
                        End With
                    Next j

                    '*******************************
                    'Set column with
                    '*******************************
                    ExcelReports.SetCellWidths(objSheet, dt)

                    ''*******************************
                    '' Freeze column headers area
                    ''*******************************
                    'objExcel.ActiveWindow.FreezePanes = False
                    'objExcel.Range("A1:" & Generic.CalExcelColLetter(dt.Columns.Count) & (2).ToString).Select()
                    'objExcel.ActiveWindow.FreezePanes = True

                    '*******************************
                    With objSheet.PageSetup
                        .Orientation = Excel.XlPageOrientation.xlLandscape
                        .LeftHeader = "&""Arial,Bold""&14Pallet Manifest" & Chr(10) & "Pallet ID: " & strFileName & Chr(10) & "Destination: " & strLoc & Chr(10) & "Total: " & dt.Rows.Count.ToString
                        .LeftFooter = "** PSS Confidential **"
                        .CenterFooter = "&P of &N"
                        .RightFooter = "&D&' @'&T"
                        .HeaderMargin = -25
                        .TopMargin = 100
                        .RightMargin = -25
                        .LeftMargin = -25
                        '.FitToPagesWide = 1
                        '.FitToPagesTall = 1
                    End With

                    '*******************************
                    'Save file
                    '*******************************
                    objBook.SaveAs(strFilePath)
                    ''***********************************
                    ''print Report
                    ''***********************************
                    'objExcel.ActiveWindow.SelectedSheets.PrintOut(Copies:=iPrintCopyNo, Collate:=True)
                    ''***********************************

                End If
                Return dt.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
                xlBI = Nothing
                objArr = Nothing

                '*************************************
                'Excel clean up
                If Not IsNothing(objSheet) Then
                    Generic.NAR(objSheet)
                End If
                If Not IsNothing(objBook) Then
                    objBook.Close(False)
                    NAR(objBook)
                End If
                If Not IsNothing(objExcel) Then
                    objExcel.Quit()
                    NAR(objExcel)
                End If
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '******************************************************************
        Private Sub NAR(ByRef o As Object)
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
            Catch
            Finally
                o = Nothing
            End Try
        End Sub

        '******************************************************************
        Public Function GetSensusPalletInfoByName(ByVal strPalletName As String) As DataTable
            Dim strSql As String
            Try
                strSql = "SELECT tpallett.*, Model_Desc " & Environment.NewLine
                strSql &= ", if(A.user_fullname is null, '', A.user_fullname) as 'Delete User' " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tpallett.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN security.tusers A ON tpallett.Pallet_InvalidUsrID = A.user_id " & Environment.NewLine
                strSql &= "WHERE Pallett_Name = '" & strPalletName & "' " & Environment.NewLine
                strSql &= "AND Loc_ID = " & Me.SENSUS_LOCATION_ID
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function ReOpenPallet(ByVal iPalletID As Integer) As Integer
            Dim strSql As String
            Try
                strSql = "UPDATE tpallett, tdevice " & Environment.NewLine
                strSql &= "SET Pallett_ShipDate = null, Pallett_BulkShipped = 0 " & Environment.NewLine
                strSql &= ", Device_DateShip = null, Device_ShipWorkDate = null, Shift_ID_Ship = 0 " & Environment.NewLine
                strSql &= "WHERE tpallett.Pallett_ID = tdevice.Pallett_ID AND tpallett.Pallett_ID = " & iPalletID & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetRRQtyOfPallet(ByVal iPalletID As Integer) As DataTable
            Dim strSql As String
            Dim dt As DataTable
            Dim R1 As DataRow
            Try
                strSql = "SELECT tsensusdata.sd_loc, tsensusdata.sd_RR_Num as 'RR#', count(*) as 'On Pallet Qty', 0 as 'RR Qty', 0 as 'Open Qty' " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tsensusdata on tdevice.Device_ID = tsensusdata.Device_ID " & Environment.NewLine
                strSql &= "WHERE pallett_id = " & iPalletID & Environment.NewLine
                strSql &= "AND (sd_Status is null or sd_Status <> 'Dispose Upon Receipt') " & Environment.NewLine
                strSql &= "GROUP BY tsensusdata.sd_RR_Num " & Environment.NewLine
                strSql &= "ORDER BY tsensusdata.sd_RR_Num " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                For Each R1 In dt.Rows
                    R1.BeginEdit()
                    R1("RR Qty") = Me.GetRRQty(R1("RR#"))
                    R1("Open Qty") = R1("RR Qty") - R1("On Pallet Qty")
                    R1.EndEdit()
                    R1.AcceptChanges()
                Next R1

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function PrintSensusPalletDetailRpt(ByVal strPalletName As String) As Integer
            Const strReportName As String = "Sensus Pallet Detail Push.rpt"
            Dim strSql As String
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim strRRs As String = ""
            Dim iPalletID As Integer = 0

            Try
                'Get RR in Pallett
                strSql = "SELECT DISTINCT tsensusdata.sd_RR_Num, tpallett.Pallett_ID " & Environment.NewLine
                strSql &= "FROM tsensusdata " & Environment.NewLine
                strSql &= "INNER JOIN tdevice ON tsensusdata.Device_ID = tdevice.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strSql &= "WHERE Pallett_Name = '" & strPalletName & "' " & Environment.NewLine
                strSql &= "AND tpallett.Loc_ID = " & Me.SENSUS_LOCATION_ID & " " & Environment.NewLine
                strSql += "AND (sd_Status is null or sd_Status <> 'Dispose Upon Receipt')" + Environment.NewLine
                strSql &= "ORDER BY tsensusdata.sd_RR_Num " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Pallet is either empty or belonged to a different customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    iPalletID = dt.Rows(0)("Pallett_ID")
                    For Each R1 In dt.Rows
                        If strRRs.Trim.Length > 0 Then strRRs &= ", "
                        strRRs &= "'" & R1("sd_RR_Num").ToString.Trim & "'"
                    Next R1

                    Generic.DisposeDT(dt)

                    strSql = "SELECT 'Pallet Detail' as 'Title' " & Environment.NewLine
                    strSql &= ", '" & strPalletName & "' as PalletName " & Environment.NewLine
                    strSql &= ", '" & Me.GetPalletQty(iPalletID) & "' as PalletQty " & Environment.NewLine
                    strSql &= ", if(Pallet_ShipType is null, 0, Pallet_ShipType ) as PalletShipType " & Environment.NewLine
                    strSql &= ", Model_Desc as ModelDesc " & Environment.NewLine
                    strSql &= ", Device_SN as SN " & Environment.NewLine
                    strSql &= ", concat('*', Device_SN, '*') as SN_Barcode " & Environment.NewLine
                    strSql &= ", sd_RMA_Num as 'RMA' " & Environment.NewLine
                    strSql &= ", sd_RR_Num as 'RR' " & Environment.NewLine
                    strSql &= ", concat('*', sd_RMA_Num, '*') as 'RMA_Barcode' " & Environment.NewLine
                    strSql &= ", concat('*', sd_RR_Num, '*') as 'RR_Barcode' " & Environment.NewLine
                    strSql &= ", if(pkslip_ID  is null, '', pkslip_ID ) as PackingListID " & Environment.NewLine
                    strSql &= ", 0 as RR_Qty " & Environment.NewLine
                    strSql &= ", Palletize_Seq as ScanSequence " & Environment.NewLine
                    strSql &= ", if(Palletize_Seq > 0, 'YES', 'No' ) as 'OnPallet?' " & Environment.NewLine
                    strSql &= "FROM tsensusdata " & Environment.NewLine
                    strSql &= "INNER JOIN tdevice ON tsensusdata.Device_ID = tdevice.Device_ID " & Environment.NewLine
                    strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                    strSql &= "WHERE sd_RR_Num IN (" & strRRs & ") " & Environment.NewLine
                    strSql += "AND (sd_Status is null OR sd_Status <> 'Dispose Upon Receipt' ) " + Environment.NewLine
                    strSql += "AND Device_DateShip is null " + Environment.NewLine
                    'strSql &= "Group By tsensusdata.sd_RR_Num " & Environment.NewLine
                    strSql &= "ORDER BY tsensusdata.Palletize_Seq desc" & Environment.NewLine
                    dt = Me._objDataProc.GetDataTable(strSql)

                    For Each R1 In dt.Rows
                        R1.BeginEdit()
                        R1("RR_Qty") = Me.GetRRQty(R1("RR"))
                        R1.EndEdit()
                        R1.AcceptChanges()
                    Next R1

                    Me.PrintCrystalRpt(dt, strReportName, 1)
                End If

                Return dt.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function PrintSensusPalletOpenRRUnits(ByVal iPalletID As Integer) As Integer
            Const strReportName As String = "Sensus Pallet Detail Push.rpt"
            Dim strSql As String
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim strRRs As String = ""
            Dim strPalletName As String = ""

            Try
                'Get RR in Pallett
                strSql = "SELECT DISTINCT tsensusdata.sd_RR_Num, Pallett_Name " & Environment.NewLine
                strSql &= "FROM tsensusdata " & Environment.NewLine
                strSql &= "INNER JOIN tdevice ON tsensusdata.Device_ID = tdevice.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strSql &= "WHERE tpallett.Pallett_ID = " & iPalletID.ToString & " " & Environment.NewLine
                strSql &= "AND tpallett.Loc_ID = " & Me.SENSUS_LOCATION_ID & " " & Environment.NewLine
                strSql += "AND (sd_Status is null or sd_Status <> 'Dispose Upon Receipt')" + Environment.NewLine
                strSql &= "ORDER BY tsensusdata.sd_RR_Num " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Pallet is either empty or belonged to a different customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    strPalletName = dt.Rows(0)("Pallett_Name")
                    For Each R1 In dt.Rows
                        If strRRs.Trim.Length > 0 Then strRRs &= ", "
                        strRRs &= "'" & R1("sd_RR_Num").ToString.Trim & "'"
                    Next R1

                    Generic.DisposeDT(dt)

                    strSql = "SELECT 'Pallet Detail' as 'Title' " & Environment.NewLine
                    strSql &= ", '" & strPalletName & "' as PalletName " & Environment.NewLine
                    strSql &= ", '" & Me.GetPalletQty(iPalletID) & "' as PalletQty " & Environment.NewLine
                    strSql &= ", if(Pallet_ShipType is null, 0, Pallet_ShipType ) as PalletShipType " & Environment.NewLine
                    strSql &= ", Model_Desc as ModelDesc " & Environment.NewLine
                    strSql &= ", Device_SN as SN " & Environment.NewLine
                    strSql &= ", concat('*', Device_SN, '*') as SN_Barcode " & Environment.NewLine
                    strSql &= ", sd_RMA_Num as 'RMA' " & Environment.NewLine
                    strSql &= ", sd_RR_Num as 'RR' " & Environment.NewLine
                    strSql &= ", concat('*', sd_RMA_Num, '*') as 'RMA_Barcode' " & Environment.NewLine
                    strSql &= ", concat('*', sd_RR_Num, '*') as 'RR_Barcode' " & Environment.NewLine
                    strSql &= ", if(pkslip_ID  is null, '', pkslip_ID ) as PackingListID " & Environment.NewLine
                    strSql &= ", 0 as RR_Qty " & Environment.NewLine
                    strSql &= ", Palletize_Seq as ScanSequence " & Environment.NewLine
                    strSql &= ", if((tdevice.Pallett_ID is not null or tdevice.Pallett_ID > 0) , 'Yes', 'No' ) as 'OnPallet?' " & Environment.NewLine
                    strSql &= "FROM tsensusdata " & Environment.NewLine
                    strSql &= "INNER JOIN tdevice ON tsensusdata.Device_ID = tdevice.Device_ID " & Environment.NewLine
                    strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                    strSql &= "WHERE sd_RR_Num IN (" & strRRs & ") " & Environment.NewLine
                    strSql += "AND sd_Status <> 'Dispose Upon Receipt'" + Environment.NewLine
                    strSql &= "AND tdevice.Pallett_ID is null " & Environment.NewLine
                    'strSql &= "Group By tsensusdata.sd_RR_Num " & Environment.NewLine
                    strSql &= "ORDER BY tsensusdata.sd_RR_Num " & Environment.NewLine
                    dt = Me._objDataProc.GetDataTable(strSql)

                    For Each R1 In dt.Rows
                        R1.BeginEdit()
                        R1("RR_Qty") = Me.GetRRQty(R1("RR"))
                        R1.EndEdit()
                        R1.AcceptChanges()
                    Next R1

                    Me.PrintCrystalRpt(dt, strReportName, 1)
                End If

                Return dt.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Shared Function PrintCrystalRpt(ByVal dt As DataTable, _
                                        ByVal strRptName As String, _
                                        ByVal iCopies As Integer) As Integer
            Dim objRpt As ReportDocument
            Try
                If Not IsNothing(dt) Then
                    objRpt = New ReportDocument()

                    With objRpt
                        .Load(PSS.Data.ConfigFile.GetBaseReportPath & strRptName)
                        .SetDataSource(dt)
                        .PrintToPrinter(iCopies, True, 0, 0)
                    End With
                End If
                Return 1
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetPalletDetails(ByVal iPalletID As Integer) As DataTable
            Dim strSql As String = ""
            Dim strRRs As String = ""
            Dim dt As DataTable
            Dim R1 As DataRow

            Try
                'Get RR in Pallett
                strSql = "SELECT DISTINCT tsensusdata.sd_RR_Num" & Environment.NewLine
                strSql &= "FROM tsensusdata " & Environment.NewLine
                strSql &= "INNER JOIN tdevice ON tsensusdata.Device_ID = tdevice.Device_ID " & Environment.NewLine
                strSql &= "WHERE tdevice.Pallett_ID = " & iPalletID & " " & Environment.NewLine
                strSql &= "AND (sd_Status is null or sd_Status <> 'Dispose Upon Receipt') " & Environment.NewLine
                strSql &= "ORDER BY tsensusdata.sd_RR_Num " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Pallet is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    For Each R1 In dt.Rows
                        If strRRs.Trim.Length > 0 Then strRRs &= ", "
                        strRRs &= "'" & R1("sd_RR_Num").ToString.Trim & "'"
                    Next R1

                    Generic.DisposeDT(dt)

                    strSql = "SELECT concat('Pallet Detail', '      ', Pallett_Name) as 'Title' " & Environment.NewLine
                    'strSql &= ", Palletize_Seq as ScanSeq" & Environment.NewLine
                    strSql &= ", Device_SN as 'S/N' " & Environment.NewLine
                    strSql &= ", if((tdevice.Pallett_ID is not null or tdevice.Pallett_ID = 0) , 'Yes', 'No' ) as 'OnPallet?' " & Environment.NewLine
                    strSql &= ", sd_RMA_Num as 'RMA' " & Environment.NewLine
                    strSql &= ", sd_RR_Num as 'RR' " & Environment.NewLine
                    strSql &= ", sd_loc as 'Manuf Location' " & Environment.NewLine
                    strSql &= ", if(Pallet_SkuLen is null, '', Pallet_SkuLen ) as 'Ship To Location' " & Environment.NewLine
                    strSql &= ", Model_Desc as ModelDesc " & Environment.NewLine
                    strSql &= ", concat('*', Device_SN, '*') as SN_Barcode " & Environment.NewLine
                    strSql &= ", concat('*', sd_RMA_Num, '*') as 'RMA_Barcode' " & Environment.NewLine
                    strSql &= ", concat('*', sd_RR_Num, '*') as 'RR_Barcode' " & Environment.NewLine
                    strSql &= "FROM tsensusdata " & Environment.NewLine
                    strSql &= "INNER JOIN tdevice ON tsensusdata.Device_ID = tdevice.Device_ID " & Environment.NewLine
                    strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                    strSql &= "WHERE sd_RR_Num IN (" & strRRs & ") " & Environment.NewLine
                    strSql &= "AND sd_Status <> 'Dispose Upon Receipt' " & Environment.NewLine
                    'strSql &= "Group By tsensusdata.sd_RR_Num " & Environment.NewLine
                    strSql &= "ORDER BY tsensusdata.Palletize_Seq desc" & Environment.NewLine
                    dt = Me._objDataProc.GetDataTable(strSql)
                End If
                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetRRDetails(ByVal strRRNo As String) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT concat('RR Detail', '          ', sd_RR_Num) as 'Title' " & Environment.NewLine
                'strSql &= ", Palletize_Seq as ScanSeq" & Environment.NewLine
                strSql &= ", sd_sn as 'S/N' " & Environment.NewLine
                strSql &= ", if(Palletize_Seq > 0 , 'Yes', 'No' ) as 'OnPallet?' " & Environment.NewLine
                strSql &= ", sd_RMA_Num as 'RMA' " & Environment.NewLine
                strSql &= ", sd_loc as 'Manuf Location' " & Environment.NewLine
                strSql &= ", if(Palletize_Seq = 0, '', if(sd_Status = 'Dispose Upon Receipt', 'PSS', if(sd_QALoc = 1, 'Sensus', sd_loc)) ) as 'Ship To Location' " & Environment.NewLine
                strSql &= ", Model_Desc as ModelDesc " & Environment.NewLine
                strSql &= ", concat('*', sd_sn, '*') as SN_Barcode " & Environment.NewLine
                strSql &= ", concat('*', sd_RMA_Num, '*') as 'RMA_Barcode' " & Environment.NewLine
                strSql &= ", concat('*', sd_RR_Num, '*') as 'RR_Barcode' " & Environment.NewLine
                strSql &= ", if(Pallett_Name is null, '', Pallett_Name) as 'Pallet Name' " & Environment.NewLine
                strSql &= ", if(Device_DateShip is null, '', Device_DateShip) as 'Date Produced' " & Environment.NewLine
                strSql &= "FROM tsensusdata " & Environment.NewLine
                strSql &= "INNER JOIN tdevice ON tsensusdata.Device_ID = tdevice.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strSql &= "WHERE sd_RR_Num = '" & strRRNo & "' " & Environment.NewLine
                strSql &= "AND (sd_Status is null or sd_Status <> 'Dispose Upon Receipt') " & Environment.NewLine
                'strSql &= "Group By tsensusdata.sd_RR_Num " & Environment.NewLine
                strSql &= "ORDER BY tsensusdata.Palletize_Seq desc" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetModelInPallet(ByVal iPalletID As Integer) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT Distinct tmodel.Model_ID, tmodel.Model_Desc " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "WHERE Pallett_ID = " & iPalletID & " " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetOpenPalletCount(ByVal iModelID As Integer, ByVal strPallet_SkuLen As String) As Integer
            Dim strSql As String = ""
            Try
                strSql = "SELECT count(*) as cnt " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "WHERE Model_ID = " & iModelID & " " & Environment.NewLine
                strSql &= "AND Pallet_SkuLen = '" & strPallet_SkuLen & "' " & Environment.NewLine
                strSql &= "AND Pallet_Invalid = 0" & Environment.NewLine
                strSql &= "AND Cust_ID = " & Me.SENSUS_CUSTOMER_ID & Environment.NewLine
                strSql &= "AND Pallett_ShipDate is null " & Environment.NewLine
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetInvoiceCount(ByVal iPalletID As Integer) As Integer
            Dim strSql As String = ""
            Try
                strSql = "SELECT count(*) as cnt " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "WHERE Pallett_ID = " & iPalletID & " " & Environment.NewLine
                strSql &= "AND Device_Invoice = 1 " & Environment.NewLine
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function EmptyPallet(ByVal iPalletID As Integer) As Integer
            Dim strSql As String = ""
            Try
                strSql = "UPDATE tdevice, tsensusdata " + Environment.NewLine
                strSql += "SET tdevice.Pallett_ID = null " + Environment.NewLine
                strSql += ", tsensusdata.Palletize_UsrID = null " + Environment.NewLine
                strSql += ", tsensusdata.Palletize_Seq = 0 " + Environment.NewLine
                strSql += "WHERE tdevice.Device_ID = tsensusdata.Device_ID " + Environment.NewLine
                strSql += "AND tdevice.Pallett_ID = " + iPalletID.ToString + Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************

#End Region

#Region "Packing List"

            '******************************************************************
        Public Function GetSensusShipToAddress(ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String
            Dim dt As DataTable

            Try
                strSql = "SELECT ShipTo_ID, CS_Desc, Cust_ID " & Environment.NewLine
                strSql &= "FROM tcustshiptoloc " & Environment.NewLine
                strSql &= "WHERE CS_Inactive = 0 " & Environment.NewLine
                strSql &= "AND tcustshiptoloc.Cust_ID = " & Me.SENSUS_CUSTOMER_ID & " " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow = True Then dt.LoadDataRow(New Object() {"0", "-- SELECT --", "0"}, False)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetSensusWaitingToShipPallet() As DataTable
            Dim strSql As String
            Try
                strSql = "SELECT Pallett_Name as 'Pallet Name'  " & Environment.NewLine
                strSql &= ", Pallett_ShipDate as 'Prod Completed Date' " & Environment.NewLine
                strSql &= ", Pallett_QTY as QTY " & Environment.NewLine
                'strSql &= ", (CASE WHEN Pallet_ShipType = 0 THEN 'Refurbished' WHEN Pallet_ShipType = 1 THEN 'RUR' ELSE '' END) AS 'Ship Type' " & Environment.NewLine
                strSql &= ", if(CS_Desc is null, '', CS_Desc) AS 'Ship to Location' " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tpalletshiptoloc ON tpallett.pallett_id = tpalletshiptoloc.Pallett_id " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tshipto ON tpalletshiptoloc.ShipTo_ID = tshipto.ShipTo_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tcustshiptoloc ON tshipto.ShipTo_ID = tcustshiptoloc.ShipTo_ID AND tpallett.Cust_ID = tcustshiptoloc.Cust_ID " & Environment.NewLine
                strSql &= "WHERE tpallett.Cust_ID = " & Me.SENSUS_CUSTOMER_ID & " " & Environment.NewLine
                strSql &= "AND Pallett_ShipDate is not null " & Environment.NewLine
                strSql &= "AND pkslip_ID is null " & Environment.NewLine
                strSql &= "ORDER BY tpallett.Pallett_ID " & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetSensusReadyToMoveToCEM() As DataTable
            Dim strSql As String
            Try
                strSql = "SELECT DISTINCT tsensusdata.sd_RMA_Num as 'RMA' " & Environment.NewLine
                strSql &= ", concat('*', trim(tsensusdata.sd_RMA_Num), '*') as 'RMA_Barcode' " & Environment.NewLine
                strSql &= ", tsensusdata.sd_RR_Num as 'RR#' " & Environment.NewLine
                strSql &= ", concat('*', trim(tsensusdata.sd_RR_Num), '*') as 'RR_Barcode' " & Environment.NewLine
                strSql &= ", count(*) as Qty " & Environment.NewLine
                strSql &= "FROM tsensusdata " & Environment.NewLine
                strSql &= "WHERE tsensusdata.sd_DateShipped is null " & Environment.NewLine
                strSql &= "GROUP BY tsensusdata.sd_RMA_Num " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetSensusPalletInfo(ByVal strPalletName As String) As DataTable
            Dim strSql As String
            Try
                strSql = "SELECT tpallett.* " & Environment.NewLine
                strSql &= ", tpalletshiptoloc.ShipTo_ID " & Environment.NewLine
                strSql &= ", if(A.user_fullname is null, '', A.user_fullname) as 'Deleted By User' " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tpalletshiptoloc ON tpallett.pallett_id = tpalletshiptoloc.Pallett_id  " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN security.tusers A ON tpallett.Pallet_InvalidUsrID = A.User_ID  " & Environment.NewLine
                strSql &= "WHERE Pallett_Name = '" & strPalletName & "'" & Environment.NewLine
                strSql &= "AND cust_ID = " & Me.SENSUS_CUSTOMER_ID & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Sub PrintPackingList(ByVal iPkslip_ID As Integer, ByVal iCopyNumber As Integer)
            Dim dt2 As DataTable
            Dim objRpt As ReportDocument
            Dim strRptName As String = ""
            Dim strReportLoc As String = PSS.Data.ConfigFile.GetBaseReportPath()

            Try
                strRptName = strReportLoc & "Sensus Packing Slip Push.rpt"

                dt2 = Me.GetPackingListReportData(Format(iPkslip_ID, "000000").ToString)
                If dt2.Rows.Count > 0 Then
                    objRpt = New ReportDocument()

                    With objRpt
                        .Load(strRptName)
                        .SetDataSource(dt2)
                        .PrintToPrinter(iCopyNumber, True, 0, 0)
                    End With
                Else
                    MessageBox.Show("Packing list is empty.", "PrintPackingList", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt2)
            End Try
        End Sub

        '******************************************************************
        Private Function GetPackingListReportData(ByVal strPkslipID As String) As DataTable
            Dim dr As DataRow
            Dim strSQL As String
            Dim dtPalletInfo As DataTable
            Dim iPalletQty As Integer = 0
            Dim i As Integer = 1

            Try
                strSQL = "SELECT C.ShipTo_Name AS CustName " & Environment.NewLine
                strSQL &= ", C.ShipTo_Address1 AS Address1 " & Environment.NewLine
                strSQL &= ", C.ShipTo_Address2 AS Address2 " & Environment.NewLine
                strSQL &= ", C.ShipTo_City AS City, D.State_Long AS State, C.ShipTo_Zip AS ZIP " & Environment.NewLine
                strSQL &= ", '" & strPkslipID & "' AS SlipNumber " & Environment.NewLine
                strSQL &= ", 0 as Counter " & Environment.NewLine
                strSQL &= ", A.Pallet_SkuLen as RTVNumber " & Environment.NewLine
                strSQL &= ", If (E.Model_Desc is null, '', E.Model_Desc ) AS Model " & Environment.NewLine
                strSQL &= ", If (F.Sku_PartNo is null, '', F.Sku_PartNo ) AS PartNumber " & Environment.NewLine
                strSQL &= ", IF( A.Pallett_QTY is null, 0, A.Pallett_QTY) AS Qty " & Environment.NewLine
                strSQL &= ", (CASE WHEN A.Pallet_ShipType = 0 THEN '' ELSE '' END) as BoxType " & Environment.NewLine
                strSQL &= ", A.Pallett_Name as PalletName " & Environment.NewLine
                strSQL &= ", A.Pallet_ShipType as PalletShipType " & Environment.NewLine
                strSQL &= ", A.Pallet_SkuLen AS PalletSkuLen " & Environment.NewLine
                strSQL &= ", A.Cust_ID AS CustID " & Environment.NewLine
                strSQL &= ",'AUDITED BY' AS CustomField1 " & Environment.NewLine
                strSQL &= "FROM tpallett A " & Environment.NewLine
                strSQL &= "INNER JOIN tpackingslip B ON A.pkslip_ID = B.pkslip_ID " & Environment.NewLine
                strSQL &= "INNER JOIN tshipto C ON B.ShipTo_ID = C.ShipTo_ID " & Environment.NewLine
                strSQL &= "INNER JOIN lstate D ON C.State_ID = D.State_Id " & Environment.NewLine
                strSQL &= "LEFT OUTER JOIN tmodel E ON A.Model_ID = E.Model_ID " & Environment.NewLine
                strSQL &= "LEFT OUTER JOIN tsku F ON E.Model_ID = F.Model_ID AND A.Cust_ID = F.Cust_ID " & Environment.NewLine
                strSQL &= "WHERE A.pkslip_ID = " & Convert.ToInt64(strPkslipID) & Environment.NewLine

                dtPalletInfo = Me._objDataProc.GetDataTable(strSQL)

                For Each dr In dtPalletInfo.Rows
                    dr.BeginEdit()
                    If dr("Qty") = 0 Then
                        strSQL = "SELECT count(*) FROM tdevice WHERE Pallett_ID = " & dr("PalletID") & ";"
                        iPalletQty = Me._objDataProc.GetIntValue(strSQL)
                        dr("Qty") = iPalletQty
                    End If
                    dr("Counter") = i
                    dr.EndEdit()
                    dtPalletInfo.AcceptChanges()
                    i += 1
                Next dr

                Return dtPalletInfo
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtPalletInfo)
            End Try
        End Function

        '******************************************************************

#End Region

#Region "Search"
        Public Function GetSensusSearchData(ByVal strSearchBy As String, _
                                            ByVal strSearchCriteria As String, _
                                            ByVal strDate As String) As DataTable
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim strSql As String = ""
            Dim i As Integer = 0

            Try
                strSql = "SELECT 0 as 'Line #' " & Environment.NewLine
                strSql &= ", Device_SN as 'SN' " & Environment.NewLine
                strSql &= ", sd_Meter_ID as 'Meter ID' " & Environment.NewLine
                strSql &= ", tmodel.Model_Desc as 'Model' " & Environment.NewLine
                strSql &= ", sd_RMA_Num as 'RMA' " & Environment.NewLine
                strSql &= ", sd_RR_Num as 'RR#' " & Environment.NewLine
                strSql &= ", sd_loc as 'Location' " & Environment.NewLine
                strSql &= ", if(sd_DateRecvd is null, '', DATE_FORMAT(sd_DateRecvd, '%m/%d/%y %H:%m:%s')  ) as 'Sensus Rec Date' " & Environment.NewLine
                strSql &= ", if(sd_DateShipped is null, '', DATE_FORMAT(sd_DateShipped, '%m/%d/%y %H:%m:%s')  ) as 'CEM Date' " & Environment.NewLine
                strSql &= ", if(Device_DateShip is null, '', DATE_FORMAT(Device_DateShip, '%m/%d/%y %H:%m:%s')  ) as 'Prod Ship Date' " & Environment.NewLine
                strSql &= ", if(Pallett_Name is null, '', Pallett_Name ) as 'Pallet Name' " & Environment.NewLine
                strSql &= ", if(tpackingslip.pkslip_ID is null, '', tpackingslip.pkslip_ID ) as 'Packing List #' " & Environment.NewLine
                strSql &= ", if(tpackingslip.pkslip_createDt is null, '', DATE_FORMAT(tpackingslip.pkslip_createDt, '%m/%d/%y %H:%m:%s') ) as 'Packing List Date' " & Environment.NewLine
                strSql &= ", if(tshipto.ShipTo_Name is null, '', ShipTo_Name) as 'Ship To' " & Environment.NewLine
                strSql &= ", if(A.user_fullname is null, '', A.user_fullname ) as 'Palletizing User'  " & Environment.NewLine
                strSql &= ", if(B.user_fullname is null, '', B.user_fullname ) as 'Prod Shipper' " & Environment.NewLine
                strSql &= ", if(C.user_fullname is null, '', C.user_fullname ) as 'Packing User' " & Environment.NewLine
                strSql &= ", if(SC_Desc is null, '', SC_Desc ) as 'Dock Shipping Carrier' " & Environment.NewLine
                strSql &= ", if(pkslip_TrackNo is null, '', pkslip_TrackNo ) as 'Dock Shipping Tracking #' " & Environment.NewLine
                strSql &= ", if(pkslip_DockShipDate is null, '', DATE_FORMAT(pkslip_DockShipDate, '%m/%d/%y %H:%m:%s') ) as 'Dock Ship Date' " & Environment.NewLine
                strSql &= ", if(D.user_fullname is null, '', D.user_fullname ) as 'Dock Shipper' " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN tsensusdata ON tdevice.Device_ID = tsensusdata.Device_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tpackingslip ON tpallett.pkslip_ID = tpackingslip.pkslip_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tshipto ON tpackingslip.ShipTo_ID = tshipto.ShipTo_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lshipcarrier ON tpackingslip.SC_ID = lshipcarrier.SC_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN security.tusers A ON tsensusdata.Palletize_UsrID  = A.User_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN security.tusers B ON tsensusdata.ProdShip_UsrID = B.User_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN security.tusers C ON tpackingslip.pkslip_usrID  = C.User_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN security.tusers D ON tpackingslip.pkslip_DSUpdateUserID  = D.User_ID " & Environment.NewLine
                Select Case strSearchBy.Trim.ToUpper
                    Case "Serial Number".ToUpper
                        strSql &= "WHERE device_sn = '" & strSearchCriteria.Trim & "' " & Environment.NewLine
                    Case "Meter ID".ToUpper
                        strSql &= "WHERE sd_Meter_ID = '" & strSearchCriteria.Trim & "' " & Environment.NewLine
                    Case "RR#".ToUpper
                        strSql &= "WHERE sd_RR_Num = '" & strSearchCriteria.Trim & "' " & Environment.NewLine
                    Case "RMA".ToUpper
                        strSql &= "WHERE sd_RMA_Num = '" & strSearchCriteria.Trim & "' " & Environment.NewLine
                    Case "Rec Date".ToUpper
                        strSql &= "WHERE DATE_FORMAT(sd_DateRecvd, '%Y-%m-%d') = '" & strDate.Trim & "' " & Environment.NewLine
                    Case "Prod Ship Date".ToUpper
                        strSql &= "WHERE DATE_FORMAT(Device_DateShip, '%Y-%m-%d') = '" & strDate.Trim & "' " & Environment.NewLine
                    Case "CEM Date".ToUpper
                        strSql &= "WHERE DATE_FORMAT(Device_DateShip, '%Y-%m-%d') = '" & strDate.Trim & "' " & Environment.NewLine
                    Case "Pallet Name".ToUpper
                        strSql &= "WHERE Pallett_Name = '" & strSearchCriteria.Trim & "' " & Environment.NewLine
                    Case "Packing List #".ToUpper
                        strSql &= "WHERE tpackingslip.pkslip_ID = " & strSearchCriteria.Trim & " " & Environment.NewLine
                    Case Else
                        MessageBox.Show("Not enough criteria to perform search.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Function
                End Select
                strSql &= "ORDER BY tdevice.Device_ID  " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                For Each R1 In dt.Rows
                    i += 1
                    R1.BeginEdit()
                    R1("Line #") = i
                    R1.EndEdit()
                    R1.AcceptChanges()
                Next R1

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Function
#End Region

#Region "RMA Shipment Report"

        '******************************************************************
        Public Function CreateTodayRMAShipmentRpt() As DataTable
            Const strRptBaseDir As String = "R:\_SENSUS\SHIPMENT_REPORTS\"
            'Const strRptBaseDir As String = "C:\"
            Dim objExcel As Excel.Application    ' Excel application
            Dim objWorkbook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet
            Dim xlBI As Excel.XlBordersIndex() = {Excel.XlBordersIndex.xlEdgeLeft, Excel.XlBordersIndex.xlEdgeTop, Excel.XlBordersIndex.xlEdgeBottom, _
                Excel.XlBordersIndex.xlEdgeRight, Excel.XlBordersIndex.xlInsideVertical, Excel.XlBordersIndex.xlInsideHorizontal}
            Dim strSql As String = ""
            Dim dtPkSlip, dtSData, dtDData As DataTable
            Dim R1, R2 As DataRow
            Dim strArrHeaders() = New String() {"Customer", "RMA No", "Date Issued", "Date Received", "On Hand", "Skid #", "Shipping Carrier", "Date Shipped", "Tracking Number"}
            Dim strArrTitles() = New String() {"RMA Shipment To", "Shipment #", "# of Skids in Shipment", "# of Meters in Shipment"}
            Dim strArrDetailHeaders() = New String() {"Customer", "RMA No", "Skid #", "Serial Number", "Meter Identifier", "Part Number"}
            Dim objArrData(,) As Object
            Dim iRow, j, k As Integer
            Dim strFileName As String = ""

            Try
                dtPkSlip = Me.GetNoEmailSensusPackSlipID()

                If dtPkSlip.Rows.Count > 0 Then
                    'Prepare report
                    objExcel = New Excel.Application()
                    objExcel.Application.DisplayAlerts = False

                    For Each R1 In dtPkSlip.Rows

                        Generic.DisposeDT(dtSData)
                        Generic.DisposeDT(dtDData)
                        dtSData = Me.GetRMAShipmentRptSummaryData(R1("pkslip_ID"))
                        dtDData = Me.GetRMAShipmentRptDetailData(R1("pkslip_ID"))

                        If dtSData.Rows.Count > 0 Then
                            strFileName = dtSData.Rows(0)("Location") & "_" & Format(Now(), "yyyyMMdd") & "_" & R1("pkslip_ID") & ".xls"

                            '**************************
                            'Save File path for email
                            '**************************
                            R1.BeginEdit()
                            R1("FilePath") = strRptBaseDir & strFileName
                            R1("Location") = dtSData.Rows(0)("Location")
                            R1.EndEdit()
                            R1.AcceptChanges()
                            '**************************

                            If File.Exists(strRptBaseDir & strFileName) = False Then
                                objWorkbook = objExcel.Workbooks.Add
                                objSheet = objWorkbook.sheets("Sheet1")
                                objExcel.Visible = True
                                'objSheet.Activate()
                                objSheet.Name = dtSData.Rows(0)("Location") & " Shipment #" & R1("pkslip_ID") & ""

                                iRow = 2

                                '***************************************
                                'Title
                                '***************************************
                                ReDim objArrData(strArrTitles.Length, 2)

                                For j = 0 To strArrTitles.Length - 1
                                    objArrData(j, 0) = strArrTitles(j)
                                    If j = 0 Then
                                        objArrData(j, 1) = dtSData.Rows(0)("Location")
                                    ElseIf j = 1 Then
                                        objArrData(j, 1) = R1("pkslip_ID")
                                    ElseIf j = 2 Then
                                        objArrData(j, 1) = Me.GetPalletCntOnPackingSlip(R1("pkslip_ID"))
                                    ElseIf j = 3 Then
                                        objArrData(j, 1) = dtSData.Compute("Sum([On Hand])", "")
                                    End If
                                Next j

                                'post data to excel in title section
                                objSheet.Range("A" & iRow.ToString & ":B" & (iRow + strArrTitles.Length).ToString).Value = objArrData
                                With objSheet.Range("A" & iRow.ToString & ":B" & (iRow + strArrTitles.Length).ToString).Font
                                    .Name = "Arial"
                                    .FontStyle = "Bold"
                                    .Size = 10
                                    .ColorIndex = 25
                                End With
                                objSheet.Range("A" & (iRow + strArrTitles.Length).ToString).Font.Size = 12
                                objSheet.Range("B" & iRow.ToString & ":B" & (iRow + strArrTitles.Length).ToString).HorizontalAlignment = Excel.Constants.xlCenter

                                '***************************************
                                'Report data
                                '***************************************
                                iRow += strArrTitles.Length + 1
                                ReDim objArrData(dtSData.Rows.Count + 2, strArrHeaders.Length)

                                For j = 0 To strArrHeaders.Length - 1
                                    objArrData(0, j) = strArrHeaders(j)
                                Next j

                                For j = 0 To dtSData.Rows.Count - 1
                                    For k = 0 To strArrHeaders.Length - 1
                                        objArrData(j + 1, k) = dtSData.Rows(j)(k)
                                    Next k
                                Next j
                                objArrData(j + 1, 4) = "=SUM(R[-1]C:R[-" & dtSData.Rows.Count & "]C)"
                                objSheet.Range("A" & iRow.ToString & ":" & Generic.CalExcelColLetter(strArrHeaders.Length) & (iRow + dtSData.Rows.Count + 2)).Value = objArrData
                                objSheet.Range("A" & iRow.ToString & ":" & Generic.CalExcelColLetter(strArrHeaders.Length) & (iRow + dtSData.Rows.Count + 2)).Font.FontStyle = "Bold"
                                objSheet.Range("A" & iRow.ToString & ":" & Generic.CalExcelColLetter(strArrHeaders.Length) & iRow).HorizontalAlignment = Excel.Constants.xlCenter
                                objSheet.Range("B" & (iRow + 1).ToString & ":" & "B" & (iRow + dtSData.Rows.Count + 1)).HorizontalAlignment = Excel.Constants.xlCenter
                                objSheet.Range("A" & iRow.ToString & ":" & Generic.CalExcelColLetter(strArrHeaders.Length) & iRow.ToString).Font.Size = 12
                                objSheet.Range("C" & (iRow + 1).ToString & ":" & "D" & (iRow + dtSData.Rows.Count + 1).ToString).NumberFormat = "MM/dd/yyyy"
                                objSheet.Range("H" & (iRow + 1).ToString & ":" & "H" & (iRow + dtSData.Rows.Count + 1).ToString).NumberFormat = "MM/dd/yyyy"
                                objSheet.Range("I" & (iRow + 1).ToString & ":" & "I" & (iRow + dtSData.Rows.Count + 1).ToString).NumberFormat = "@"

                                objExcel.Range("A" & (iRow).ToString & ":" & Generic.CalExcelColLetter(strArrHeaders.Length) & (iRow + dtSData.Rows.Count + 1).ToString).Select()
                                objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.Constants.xlNone
                                objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.Constants.xlNone
                                For j = 0 To xlBI.Length - 1
                                    With objExcel.Selection.Borders(xlBI(j))
                                        .LineStyle = Excel.XlLineStyle.xlContinuous
                                        .Weight = Excel.XlBorderWeight.xlThin
                                        .ColorIndex = Excel.Constants.xlAutomatic
                                    End With
                                Next j

                                '***************************************
                                'Set colunm width
                                '***************************************
                                objSheet.Columns("A:A").ColumnWidth = 33.57
                                objSheet.Columns("B:B").ColumnWidth = 15.14
                                objSheet.Columns("C:C").ColumnWidth = 13.86
                                objSheet.Columns("D:D").ColumnWidth = 16.86
                                objSheet.Columns("E:E").ColumnWidth = 11.86
                                objSheet.Columns("F:F").ColumnWidth = 17.14
                                objSheet.Columns("G:G").ColumnWidth = 21.14
                                objSheet.Columns("H:H").ColumnWidth = 16.14
                                objSheet.Columns("I:I").ColumnWidth = 21.14

                                '***************************************
                                'Detail Page
                                '***************************************
                                objSheet = objWorkbook.sheets("Sheet2")
                                'objSheet.Activate()
                                objSheet.Name = "Detail"

                                iRow = 1
                                objArrData = Nothing

                                ReDim objArrData(dtDData.Rows.Count + 1, strArrDetailHeaders.Length)

                                For j = 0 To strArrDetailHeaders.Length - 1
                                    objArrData(0, j) = strArrDetailHeaders(j)
                                Next j

                                For j = 0 To dtDData.Rows.Count - 1
                                    For k = 0 To strArrDetailHeaders.Length - 1
                                        objArrData(j + 1, k) = dtDData.Rows(j)(k)
                                    Next k
                                Next j

                                objSheet.Range("A" & iRow.ToString & ":" & Generic.CalExcelColLetter(strArrDetailHeaders.Length) & (iRow + dtDData.Rows.Count + 1)).Value = objArrData
                                objSheet.Range("A" & iRow.ToString & ":" & Generic.CalExcelColLetter(strArrDetailHeaders.Length) & iRow).Font.FontStyle = "Bold"
                                objSheet.Range("A" & iRow.ToString & ":" & Generic.CalExcelColLetter(strArrDetailHeaders.Length) & iRow).HorizontalAlignment = Excel.Constants.xlCenter
                                objSheet.Range("A" & iRow.ToString & ":" & Generic.CalExcelColLetter(strArrDetailHeaders.Length) & iRow.ToString).Font.Size = 12
                                objSheet.Range("A" & iRow.ToString & ":" & Generic.CalExcelColLetter(strArrDetailHeaders.Length) & iRow.ToString).Font.ColorIndex = 55
                                objSheet.Range("A" & iRow.ToString & ":" & Generic.CalExcelColLetter(strArrDetailHeaders.Length) & (iRow + dtDData.Rows.Count).ToString).NumberFormat = "@"

                                objExcel.Range("A" & (iRow).ToString & ":" & Generic.CalExcelColLetter(strArrDetailHeaders.Length) & (iRow + dtDData.Rows.Count).ToString).Select()
                                objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.Constants.xlNone
                                objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.Constants.xlNone
                                For j = 0 To xlBI.Length - 1
                                    With objExcel.Selection.Borders(xlBI(j))
                                        .LineStyle = Excel.XlLineStyle.xlContinuous
                                        .Weight = Excel.XlBorderWeight.xlThin
                                        .ColorIndex = Excel.Constants.xlAutomatic
                                    End With
                                Next j

                                '***************************************
                                'Set colunm width
                                '***************************************
                                objSheet.Columns("A:A").ColumnWidth = 33.57
                                objSheet.Columns("B:B").ColumnWidth = 15.14
                                objSheet.Columns("C:C").ColumnWidth = 15.86
                                objSheet.Columns("D:D").ColumnWidth = 18.43
                                objSheet.Columns("E:E").ColumnWidth = 18.43
                                objSheet.Columns("F:F").ColumnWidth = 18.43

                                '***************************************
                                'Save and Close work book
                                '***************************************
                                objWorkbook.SaveAs(strRptBaseDir & strFileName)
                                If Not IsNothing(objSheet) Then
                                    Me.NAR(objSheet)
                                End If
                                If Not IsNothing(objWorkbook) Then
                                    objWorkbook.Close(False)
                                    NAR(objWorkbook)
                                End If
                                '***************************************
                            End If 'File not exist
                        End If  'Data Exist
                    Next R1
                End If

                Return dtPkSlip

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtPkSlip)
                Generic.DisposeDT(dtSData)
                xlBI = Nothing
                objArrData = Nothing
                strArrTitles = Nothing
                strArrHeaders = Nothing
                R1 = Nothing
                R2 = Nothing

                '*************************************
                'Excel clean up
                If Not IsNothing(objSheet) Then
                    Me.NAR(objSheet)
                End If
                If Not IsNothing(objWorkbook) Then
                    objWorkbook.Close(False)
                    NAR(objWorkbook)
                End If
                If Not IsNothing(objExcel) Then
                    objExcel.Quit()
                    NAR(objExcel)
                End If
                If Not IsNothing(objExcel) Then
                    objExcel.Quit()
                    NAR(objExcel)
                End If
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '******************************************************************
        Private Function GetRMAShipmentRptSummaryData(ByVal iPkSlipNo As Integer) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT if(tsensusdata.sd_CompanyName is null, '', tsensusdata.sd_CompanyName) as 'Customer' " & Environment.NewLine
                strSql &= ", sd_RMA_Num as 'RMA No' " & Environment.NewLine
                strSql &= ", if(sd_DateIssued is null, '', sd_DateIssued) as 'Date Issued' " & Environment.NewLine
                strSql &= ", sd_DateRecvd as 'Date Received' " & Environment.NewLine
                strSql &= ", count(*) as 'On Hand' " & Environment.NewLine
                strSql &= ", Pallett_Name as 'Skid #' " & Environment.NewLine
                strSql &= ", SC_Desc as 'Shipping Carrier' " & Environment.NewLine
                strSql &= ", pkslip_DockShipDate as 'Date Shipped' " & Environment.NewLine
                strSql &= ", pkslip_TrackNo as ' Tracking Number' " & Environment.NewLine
                strSql &= ", Pallet_SkuLen as 'Location' " & Environment.NewLine
                strSql &= "FROM tpackingslip " & Environment.NewLine
                strSql &= "INNER JOIN lshipcarrier ON tpackingslip.SC_ID = lshipcarrier.SC_ID " & Environment.NewLine
                strSql &= "INNER JOIN tpallett ON tpackingslip.pkslip_ID = tpallett.pkslip_ID " & Environment.NewLine
                strSql &= "INNER JOIN tdevice ON tpallett.Pallett_ID = tdevice.Pallett_ID " & Environment.NewLine
                strSql &= "INNER JOIN tsensusdata ON tdevice.Device_ID = tsensusdata.Device_ID " & Environment.NewLine
                strSql &= "WHERE tpallett.pkslip_ID = " & iPkSlipNo & Environment.NewLine
                strSql &= "GROUP BY sd_RMA_Num, sd_CompanyName, Pallett_Name " & Environment.NewLine
                strSql &= "ORDER BY sd_RMA_Num, sd_CompanyName, Pallett_Name "
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Private Function GetRMAShipmentRptDetailData(ByVal iPkSlipNo As Integer) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT if(tsensusdata.sd_CompanyName is null, '', tsensusdata.sd_CompanyName) as 'Customer' " & Environment.NewLine
                strSql &= ", sd_RMA_Num as 'RMA No' " & Environment.NewLine
                strSql &= ", Pallett_Name as 'Skid #' " & Environment.NewLine
                strSql &= ", sd_SN as 'Serial Number' " & Environment.NewLine
                strSql &= ", sd_Meter_ID as 'Meter Identifier' " & Environment.NewLine
                strSql &= ", if(sd_StyleNum is null, '', sd_StyleNum) as 'Part Number' " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "INNER JOIN tdevice ON tpallett.Pallett_ID = tdevice.Pallett_ID " & Environment.NewLine
                strSql &= "INNER JOIN tsensusdata ON tdevice.Device_ID = tsensusdata.Device_ID " & Environment.NewLine
                strSql &= "WHERE tpallett.pkslip_ID = " & iPkSlipNo & Environment.NewLine
                strSql &= "ORDER BY sd_RMA_Num, sd_CompanyName, Pallett_Name "
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Private Function GetNoEmailSensusPackSlipID() As DataTable
            Dim strSql As String = ""
            Try
                'Get all packing slips are waiting to be email
                strSql = "SELECT tpackingslip.pkslip_ID, '' as FilePath, '' as Location, ShipTo_ID  " & Environment.NewLine
                strSql &= "FROM tpackingslip " & Environment.NewLine
                strSql &= "WHERE Cust_ID = " & Me.SENSUS_CUSTOMER_ID & Environment.NewLine
                strSql &= "AND date_format(pkslip_createDt, '%Y-%m-%d') >= '2009-05-14' " & Environment.NewLine
                strSql &= "AND pkslip_TrackNo is not null " & Environment.NewLine
                strSql &= "AND pkslip_DockShipDate is not null " & Environment.NewLine
                strSql &= "AND pkslip_SendMailDate is null " & Environment.NewLine
                'strSql &= "AND date_format(pkslip_createDt, '%Y-%m-%d') = '2009-05-14' "
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Private Function GetPalletCntOnPackingSlip(ByVal iPkSlipNo As Integer) As Integer
            Dim strSql As String = ""
            Try
                strSql = "SELECT count(*) as cnt FROM tpallett " & Environment.NewLine
                strSql &= "WHERE pkslip_ID = " & iPkSlipNo & Environment.NewLine
                Return CInt(Me._objDataProc.GetIntValue(strSql))
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************

#End Region

#Region "Rec No File Device"
        '******************************************************************
        Public Function GetSensusPartNoList(Optional ByVal booAddSelectRow As Boolean = False) As DataTable
            Dim strSql As String
            Dim dt As DataTable
            Dim R1 As DataRow

            Try
                strSql = "SELECT sensusPartNoID, ShortDesc FROM tsensuspartno WHERE Active = 1 " + Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
                R1 = Nothing
            End Try
        End Function

        '******************************************************************
        Public Function GetShipToLocation(Optional ByVal booAddSelectRow As Boolean = False) As DataTable
            Dim strSql As String
            Dim dt As DataTable
            Dim R1 As DataRow

            Try
                strSql = "SELECT SensusLocationID, ShortName FROM tsensuslocation WHERE Active = 1 " + Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
                R1 = Nothing
            End Try
        End Function

        '******************************************************************
        Public Function ReceivedNoFileUnit(ByVal iModelID As Integer, ByVal strSN As String _
                                         , ByVal strRMA As String, ByVal strPartNo As String _
                                         , ByVal strShipToLoc As String, ByVal strWrkDate As String _
                                         , ByVal iShiftID As Integer, ByVal iMeterType As Integer _
                                         , ByVal booDispose As Boolean) As Integer
            Const iWOID As Integer = 10646634
            Const iTrayID As Integer = 1155889
            Const strCompanyName As String = "Sensus"
            Dim objRec As New PSS.Data.Production.Receiving()
            Dim iSeqNo, iDeviceID, i As Integer
            Dim strStatus, strRRNum, strMeterID, strMeterForm, strShipCarrier, strShipMethod, strTrackingNum, strStyleNum As String

            Try
                If booDispose = True Then strStatus = "Dispose Upon Receipt" Else strStatus = "Ship to CEM"
                strRRNum = strRMA

                iSeqNo = 0 : iDeviceID = 0 : i = 0
                strMeterID = "" : strMeterForm = "" : strShipCarrier = "" : strShipMethod = "" : strTrackingNum = ""
                strStyleNum = ""

                iSeqNo = objRec.GetNextDeviceCountInTray(iTrayID) + 1
                iDeviceID = objRec.InsertIntoTdevice(strSN, strWrkDate, iSeqNo, iTrayID, Sensus.SENSUS_LOCATION_ID, iWOID, iModelID, iShiftID, , , , )
                If iDeviceID = 0 Then Throw New Exception("System failed to write data to tdevice.")

                i = InsertIntoTsensusdata(strRMA, strRRNum, strMeterID, strSN, strMeterForm, strWrkDate, _
                                          strShipToLoc, 0, strShipCarrier, strShipMethod, strTrackingNum, _
                                          strCompanyName, strWrkDate, strStyleNum, strWrkDate, strPartNo, _
                                          strStatus, iMeterType, 0, iDeviceID)
                If i = 0 Then Throw New Exception("System failed to write data to tsensusdata.")

                Return iDeviceID
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Private Function InsertIntoTsensusdata(ByVal strRMA As String, _
                                            ByVal strRRNum As String, _
                                            ByVal strMeterID As String, _
                                            ByVal strSN As String, _
                                            ByVal strMeterForm As String, _
                                            ByVal strRecDate As String, _
                                            ByVal strLoc As String, _
                                            ByVal iQALoc As Integer, _
                                            ByVal strShipCarrier As String, _
                                            ByVal strShipMethod As String, _
                                            ByVal strTrackingNum As String, _
                                            ByVal strCompanyName As String, _
                                            ByVal strDateIssued As String, _
                                            ByVal strStyleNum As String, _
                                            ByVal strShipDate As String, _
                                            ByVal strPartNoModelDesc As String, _
                                            ByVal strStatus As String, _
                                            ByVal iMeterType As Integer, _
                                            ByVal iBlankSN As Integer, _
                                            ByVal iDeviceID As Integer) As Integer

            Dim strSql As String = ""
            Dim dteRec, dteShip As DateTime
            Dim iSDID As Integer = 0

            Try
                ''Date CEM'd (PSSI)(14)  Part Number/Model Description(15)	 Status(16)	    Meter Type(17)

                dteRec = DateTime.Parse(strRecDate)
                strRecDate = dteRec.ToString("yyyy-MM-dd HH:mm:ss")
                If strShipDate.Trim.Length > 0 Then
                    dteShip = DateTime.Parse(strShipDate)
                    strShipDate = dteShip.ToString("yyyy-MM-dd HH:mm:ss")
                End If

                If (strDateIssued.Trim().Length > 0) Then strDateIssued = DateTime.Parse(strDateIssued).ToString("yyyy-MM-dd HH:mm:ss")
                strSql = "INSERT INTO tsensusdata ( " + Environment.NewLine
                strSql += "sd_RMA_Num " + Environment.NewLine
                strSql += ", sd_RR_Num " + Environment.NewLine
                strSql += ", sd_Meter_ID " + Environment.NewLine
                strSql += ", sd_SN " + Environment.NewLine
                strSql += ", sd_Meter_Form " + Environment.NewLine
                strSql += ", sd_loc " + Environment.NewLine
                strSql += ", sd_QALoc " + Environment.NewLine
                strSql += ", sd_DateRecvd " + Environment.NewLine
                strSql += ", sd_ShippingCarrier " + Environment.NewLine
                strSql += ", sd_ShippingMethod " + Environment.NewLine
                strSql += ", sd_TrackingNum " + Environment.NewLine
                strSql += ", sd_CompanyName " + Environment.NewLine
                strSql += ", sd_DateIssued " + Environment.NewLine
                strSql += ", sd_StyleNum " + Environment.NewLine
                strSql += ", sd_PartNum " + Environment.NewLine
                strSql += ", sd_DateLoad " + Environment.NewLine
                If strShipDate.Trim.Length > 0 Then strSql += ", sd_DateShipped " + Environment.NewLine
                If strStatus.Trim.Length > 0 Then strSql += ", sd_Status " + Environment.NewLine
                strSql += ", sd_MeterType " + Environment.NewLine
                strSql += ", sd_BlankSN " + Environment.NewLine
                strSql += ", Device_ID " + Environment.NewLine
                strSql += ", HasFile " + Environment.NewLine
                strSql += ") VALUES ( " + Environment.NewLine
                strSql += " '" + strRMA + "' " + Environment.NewLine
                strSql += ", '" + strRRNum + "' " + Environment.NewLine
                strSql += ", '" + strMeterID + "' " + Environment.NewLine
                strSql += ", '" + strSN + "' " + Environment.NewLine
                strSql += ", '" + strMeterForm + "' " + Environment.NewLine
                strSql += ", '" + strLoc + "' " + Environment.NewLine
                strSql += ", " + iQALoc.ToString + " " + Environment.NewLine
                strSql += ", '" + strRecDate + "' " + Environment.NewLine
                strSql += ", '" + strShipCarrier + "' " + Environment.NewLine
                strSql += ", '" + strShipMethod + "' " + Environment.NewLine
                strSql += ", '" + strTrackingNum + "' " + Environment.NewLine
                strSql += ", '" + strCompanyName + "' " + Environment.NewLine
                strSql += ", '" + strDateIssued + "' " + Environment.NewLine
                strSql += ", '" + strStyleNum + "' " + Environment.NewLine
                strSql += ", '" + strPartNoModelDesc + "' " + Environment.NewLine
                strSql += ", now() " + Environment.NewLine
                If strShipDate.Trim.Length > 0 Then strSql += ", '" + strShipDate + "' " + Environment.NewLine
                If strStatus.Trim.Length > 0 Then strSql += ", '" + strStatus + "' " + Environment.NewLine
                strSql += ", " + iMeterType.ToString + Environment.NewLine
                strSql += ", " + iBlankSN.ToString + Environment.NewLine
                strSql += ", " + iDeviceID.ToString() + " " + Environment.NewLine
                strSql += ", 0 " + Environment.NewLine
                strSql += ") " + Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetSensusModelList(ByVal booAddSelectRow As Boolean)
            Dim strSql As String = ""
            Dim dt As DataTable
            Try
                strSql = "SELECT distinct tmodel.Model_id, Model_desc, Model_MotoSku, Prod_ID, UPC_Code, B.cust_model_number as 'MeterType' " & Environment.NewLine
                strSql &= "FROM tmodel " & Environment.NewLine
                strSql &= "INNER JOIN tcustmodel_pssmodel_map B ON tmodel.Model_ID = B.Model_ID " & Environment.NewLine
                strSql &= "WHERE Prod_ID = 8 "
                dt = Me._objDataProc.GetDataTable(strSql)

                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetSearchData(ByVal strSearchCriteria As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                If strSearchCriteria.Trim.Length > 0 Then
                    strSql = "SELECT Query FROM production.selqueries WHERE QueryName = 'SensusSearch' AND Active = 1; " & Environment.NewLine
                    dt = Connection5.GetDataTable(strSql)

                    If dt.Rows.Count > 0 Then
                        strSql = dt.Rows(0)(0).ToString() & " AND " & strSearchCriteria
                        Return Me._objDataProc.GetDataTable(strSql)
                    End If
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************

#End Region


    End Class
End Namespace
