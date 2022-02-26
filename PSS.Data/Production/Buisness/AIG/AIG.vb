Option Explicit On 

Imports System.Data
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine

Namespace Buisness
    Public Class AIG
        Public Const CUSTOMERID As Integer = 2560
        Public Const LOCID As Integer = 3361
        Public Const GROUPID As Integer = 113
        Public Const PRODID As Integer = 33
        Public Const _iMaxExcptRepCharge As Integer = 400
        Public Const strAwaitApproval_PSSWrty As String = "AWAIT APPROVAL (PSSWrty)"
        Public Const strAwaitApproval_Quote = "AWAIT APPROVAL (Quote)"
        Public Const strAwaitApproval_SN_Discrepancy As String = "AWAIT APPROVAL (SN Discp)"
        Public Const iAwaitApproval_WIPOwner_Hold = 6
        Public Const iCancelBillcode = 2557

        Public Enum enumPartPickStatus
            In_Cage = 1
            In_Production = 2
            Not_Received = 3
        End Enum

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

#Region "Receiving"
        '***********************************************************************************************************************
        Public Function GetOpenRecWorkOrder(ByVal iLocID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT tworkorder.WO_ID, ClaimNo as 'Claim #', Cust2PSSI_TrackNo as TrackNo, Type, Brand as 'Manufacture', Model" & Environment.NewLine
                strSql &= ", ShipTo_name as 'Name', Address1, City, State_Long as 'State', ZipCode, Tel, Email" & Environment.NewLine
                strSql &= ", IF(extendedwarranty.SerialNo is null , '', extendedwarranty.SerialNo) as 'EDI S/N'" & Environment.NewLine
                strSql &= ", tworkorder.WO_Quantity as Qty, extendedwarranty.State_ID, extendedwarranty.Cntry_ID" & Environment.NewLine
                strSql &= "FROM tworkorder " & Environment.NewLine
                strSql &= "INNER JOIN extendedwarranty On tworkorder.WO_ID = extendedwarranty.WO_ID" & Environment.NewLine
                strSql &= "INNER JOIN lstate On extendedwarranty.State_ID = lstate.State_ID" & Environment.NewLine
                strSql &= "WHERE Loc_ID = " & iLocID & " AND WO_Closed = 0 and InvalidOrder = 0 AND tworkorder.WO_Shipped = 0 " & Environment.NewLine
                strSql &= "Group by tworkorder.WO_ID, ClaimNo "
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************
        Public Function GetAIGAccessories(ByVal iProdID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT * FROM taccessories WHERE Prod_ID = " & iProdID & " AND Active = 1" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************
        Public Function CalExpectedShipDate(ByVal iCustID As Integer, ByVal iStateID As Integer) As String
            Dim strSql, strToday As String
            Dim iTAT, iFedexGroundSrvTransitDate, iDayInWIP, i As Integer
            Dim dteExpectedShipDate As Date = Nothing

            Try
                strSql = "" : strToday = "" : i = 0

                strSql = "SELECT TAT FROM tcustomer WHERE Cust_ID = " & iCustID & " " & Environment.NewLine
                iTAT = Me._objDataProc.GetIntValue(strSql)

                If iTAT > 0 Then
                    iFedexGroundSrvTransitDate = GetFedexGrndTransitDate(iStateID)

                    iDayInWIP = iTAT - iFedexGroundSrvTransitDate

                    If iDayInWIP > 0 Then
                        strToday = CDate(Generic.MySQLServerDateTime(1)).ToString("yyyy-MM-dd")
                        dteExpectedShipDate = CDate(strToday)

                        While i < iDayInWIP
                            dteExpectedShipDate = DateAdd(DateInterval.Day, 1, dteExpectedShipDate)
                            If Not (dteExpectedShipDate.DayOfWeek = DayOfWeek.Saturday OrElse dteExpectedShipDate.DayOfWeek = DayOfWeek.Sunday) Then
                                i += 1
                            End If
                        End While
                    End If
                    'strExpectedShipDate = DateAdd(DateInterval.Day, (iTAT - iFedexGroundSrvTransitDate), CDate(strToday)).ToString("yyyy-MM-dd")
                End If

                If Not IsNothing(dteExpectedShipDate) Then Return dteExpectedShipDate.ToString("yyyy-MM-dd") Else Return ""
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************
        Public Function GetFedexGrndTransitDate(ByVal iStateID As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "SELECT ShipDays FROM production.lpssishipdays WHERE State_ID = " & iStateID & " AND SC_ID = 2 "
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************
        Public Function ReceiveDeviceIntoWIP(ByVal iWOID As Integer, ByVal iTrayID As Integer, ByVal iModelID As Integer, _
                                             ByVal strManufSN As String, ByVal iShiftID As Integer, ByVal iUserID As Integer, _
                                             ByVal strUserName As String, ByVal iCCID As Integer, ByVal strWorkStation As String, _
                                             ByVal iPSSWrty As Integer, ByVal arlstAccessories As ArrayList, ByVal strExpectedShipDate As String, _
                                             ByVal iPssiStatusID As Integer, ByVal strPssiStatus As String, ByVal iWipownerID As Integer, _
                                             ByVal iPssWrtyOnDeviceID As Integer, ByVal iSNDiscpFlag As Integer) As Integer
            Dim objRec As PSS.Data.Production.Receiving
            Dim iDeviceID, iCnt, i, iManufWrty, j As Integer
            Dim strWrkDate, strMechanicalSN As String

            Try
                iDeviceID = 0 : iCnt = 0 : i = 0 : iManufWrty = 0 : j = 0
                : strMechanicalSN = ""
                strWrkDate = Generic.GetWorkDate(iShiftID)

                objRec = New PSS.Data.Production.Receiving()

                'Create device
                iCnt = objRec.GetNextDeviceCountInTray(iTrayID) + 1
                iDeviceID = objRec.InsertIntoTdevice(strManufSN, strWrkDate, iCnt, iTrayID, AIG.LOCID, iWOID, iModelID, iShiftID, iPSSWrty, iManufWrty, , iCCID, )
                If iDeviceID = 0 Then Throw New Exception("System has failed to insert into tdevice table.")

                'Create cellopt 
                If strMechanicalSN.Trim.Length = 0 Then strMechanicalSN = "NULL" 'DEFAULT VALUE
                i = objRec.InsertIntoTCellopt(iDeviceID, strMechanicalSN, , , , , , , , , , , , , , , strWorkStation, , iWipownerID, strManufSN, , iPssWrtyOnDeviceID, iSNDiscpFlag)
                If i = 0 Then Throw New Exception("System has failed to insert into tcellopt.")

                j = objRec.AddDeviceAccessories(iDeviceID, arlstAccessories, iUserID)

                Me.UpdateClaimStatus(iWOID, iPssiStatusID, strPssiStatus, strExpectedShipDate)

                PrintReceivingLabel(iDeviceID)

                Return iDeviceID

            Catch ex As Exception
                Throw ex
            Finally
                objRec = Nothing : arlstAccessories = Nothing
            End Try
        End Function

        '***********************************************************************************************************************
        Public Sub PrintReceivingLabel(ByVal iDeviceID As Integer)
            Dim i, j As Integer
            Dim strSql As String = ""
            Dim dtDevice, dtAccessories, dt As DataTable
            Dim drNewRow As DataRow
            Dim objRpt As ReportDocument

            Try
                strSql = "SELECT B.ClaimNo, A.Device_SN as 'SN', '' as Accessory, B.Brand, B.Type " & Environment.NewLine
                strSql &= ", B.Model, Date_Format(B.ExpectedShipDate, '%m/%d/%Y') as ExpectedShipDate, 0 as CurrentNo, 0 as TotalNo " & Environment.NewLine
                strSql &= "FROM tdevice A INNER JOIN extendedwarranty B ON A.WO_ID = B.WO_ID " & Environment.NewLine
                strSql &= "WHERE A.Device_ID = " & iDeviceID
                dtDevice = Me._objDataProc.GetDataTable(strSql)

                objRpt = New ReportDocument()

                With objRpt
                    .Load(PSS.Data.ConfigFile.GetBaseReportPath & "AIG_Receiving_Label.rpt")
                    If Not IsNothing(dtDevice) Then .SetDataSource(dtDevice)
                    .Refresh()
                    .PrintToPrinter(1, True, 0, 0)
                End With

                If dtDevice.Rows.Count > 0 Then
                    strSql = "SELECT B.AccessoryDesc as 'Accessory' " & Environment.NewLine
                    strSql &= "FROM tdevicerecaccessories A" & Environment.NewLine
                    strSql &= "INNER JOIN taccessories B ON A.A_ID = B.A_ID " & Environment.NewLine
                    strSql &= "WHERE A.Device_ID = " & iDeviceID
                    dtAccessories = Me._objDataProc.GetDataTable(strSql)
                    If dtAccessories.Rows.Count > 0 Then
                        For i = 0 To dtAccessories.Rows.Count - 1
                            dt = New DataTable()
                            dt = dtDevice.Clone

                            drNewRow = dt.NewRow
                            For j = 0 To dtDevice.Columns.Count - 1
                                drNewRow(j) = dtDevice.Rows(0)(j)
                            Next j

                            drNewRow("CurrentNo") = i + 1
                            drNewRow("TotalNo") = dtAccessories.Rows.Count
                            drNewRow("Accessory") = dtAccessories.Rows(i)("Accessory")
                            dt.Rows.Add(drNewRow) : dt.AcceptChanges()
                            With objRpt
                                .Load(PSS.Data.ConfigFile.GetBaseReportPath & "AIG_Receiving_Label.rpt")
                                If Not IsNothing(dtDevice) Then .SetDataSource(dt)
                                .Refresh()
                                .PrintToPrinter(1, True, 0, 0)
                            End With

                            Generic.DisposeDT(dt)
                        Next i
                    End If
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtDevice)
            End Try
        End Sub

        '***********************************************************************************************************************
        Public Function UpdateClaimStatus(ByVal iWO_ID As Integer, ByVal iPssStatusID As Integer, ByVal strStatus As String, Optional ByVal strExpectedShipDate As String = "") As Integer
            Dim strSql As String = ""

            Try
                strSql = "UPDATE extendedwarranty " & Environment.NewLine
                strSql &= "SET S_ID = " & iPssStatusID & ", PSSI_CurrentStatus = '" & strStatus & "'" & Environment.NewLine
                If strExpectedShipDate.Trim.Length > 0 Then strSql &= ", ExpectedShipDate = '" & strExpectedShipDate & "'" & Environment.NewLine
                strSql &= " WHERE WO_ID = " & iWO_ID & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************
        Public Function AddReceivingNotes(ByVal iTrayID As Integer, ByVal strNotes As String) As Integer
            Dim strSql As String = ""

            'remove unwanted 
            strNotes = strNotes.Replace("'", "''").Replace(vbCr, " ").Replace(vbLf, " ") 'vbCr and vbLf
            strNotes = System.Text.RegularExpressions.Regex.Replace(strNotes, "\s{2,}", " ")

            Try
                strSql = "UPDATE tTray SET Tray_Memo='" & strNotes & "' WHERE tray_ID=" & iTrayID
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************
        Public Function GetReceivingNotes(ByVal iWO_ID As Integer) As String
            Dim strSql As String = "", strResult As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT Tray_Memo FROM tTray WHERE WO_ID=" & iWO_ID
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 AndAlso Not IsDBNull(dt.Rows(0).Item("Tray_Memo")) Then
                    strResult = dt.Rows(0).Item("Tray_Memo")
                End If

                Return strResult

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************
        Public Function GetPartNeed(ByVal iWO_ID As Integer) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT tpartneed.*, IF(Nav_PO_Rec_Date is null, 'No', 'Yes') as 'Part Arrived' FROM tpartneed WHERE WO_ID = " & iWO_ID
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************
#End Region

#Region "Need Parts"

        '***********************************************************************************************************************
        Public Function GetOpenNotShip(ByVal iCustID As Integer, ByVal booAddSelectedRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim strCompletedWOIDs As String = ""

            Try
                'strSql = "SELECT extendedwarranty.*  FROM extendedwarranty " & Environment.NewLine
                'strSql &= "WHERE Cust_ID = " & iCustID & " AND extendedwarranty.WO_ID = 0 " & Environment.NewLine
                'strSql &= "UNION" & Environment.NewLine

                'strSql &= "SELECT extendedwarranty.*  FROM extendedwarranty " & Environment.NewLine
                'strSql &= "INNER JOIN tworkorder ON extendedwarranty.WO_ID = tworkorder.WO_ID" & Environment.NewLine
                'strSql &= "WHERE Cust_ID = " & iCustID & " AND extendedwarranty.WO_ID <> 0 AND WO_DateShip is null AND ClosePreOrderPart = 0 "

                'all columns
                'A.EW_ID,A.Cust_ID,A.ClaimNo,A.Date,A.PSSI2Cust_TrackNo,A.Cust2PSSI_TrackNo,A.SC_ID,A.WO_ID,A.Brand,A.Model,A.ShipTo_Name,
                'A.Address1,A.City,A.State_ID,A.Cntry_ID,A.Tel,A.Email,A.ZipCode,A.SerialNo,A.Address2,A.LoadedDateTime,A.TrackCreatedDateTime,
                'A.User_ID,A.Final_PSSI2Cust_TrackNo,A.PSSI_CurrentStatus,A.QuoteSubmittedDate,A.S_ID,A.ReturnBoxYesNo,A.State_ShortName,A.NI_DataSwitch,
                'A.Prod_Code,A.DefectType1,A.DefectType2,A.Language,A.PurchaseDate,A.EstimatedTechHrs,A.ErrDesc_ItemSKU,A.RepairType,A.ServiceLevel,
                'A.Warranty,A.ExpectedShipDate
                'strSql &= "SELECT if (B.ClosePreOrderPart=0, 'No','Yes' ) as 'Has Parts',A.ClaimNo,A.EW_ID,A.WO_ID,A.PSSI2Cust_TrackNo,A.Cust2PSSI_TrackNo " & Environment.NewLine
                'strSql &= ",A.Brand,A.Model,A.ShipTo_Name,A.Address1,A.Address2,A.City,A.Tel,A.Email,A.ZipCode,A.SerialNo,A.LoadedDateTime,A.TrackCreatedDateTime" & Environment.NewLine
                'strSql &= ",A.Prod_Code,A.DefectType1,A.DefectType2,A.ErrDesc_ItemSKU,A.ExpectedShipDate" & Environment.NewLine
                'strSql &= " FROM extendedwarranty A" & Environment.NewLine
                'strSql &= " INNER JOIN tworkorder B ON A.WO_ID = B.WO_ID" & Environment.NewLine
                'strSql &= " WHERE A.Cust_ID = " & iCustID & " AND A.WO_ID <> 0 AND B.WO_DateShip is null" & Environment.NewLine
                'strSql &= " ORDER BY B.ClosePreOrderPart;" & Environment.NewLine

                strSql = "SELECT A.* FROM extendedwarranty A" & Environment.NewLine
                strSql &= " INNER JOIN tworkorder B ON A.WO_ID = B.WO_ID" & Environment.NewLine
                strSql &= " WHERE A.Cust_ID = " & iCustID & " AND A.WO_ID <> 0 AND B.WO_DateShip is null AND B.ClosePreOrderPart = 0 " & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If booAddSelectedRow Then dt.LoadDataRow(New Object() {"0", iCustID, "--Select--"}, True)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '***********************************************************************************************************************
        Public Function GetPartNeeds(ByVal iWOID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Try
                strSql = "SELECT A.PN_ID, A.Part_Number as 'Part #', A.Part_Desc as 'Part Description', A.Notes, A.Qty, B.User_FullName as 'Trans User'" & Environment.NewLine
                strSql &= ", A.Trans_DateTime as 'Trans Date', Nav_PO as 'PO', Nav_PO_Purchase_Date as 'PO Date'" & Environment.NewLine
                strSql &= ", Nav_PO_Rec_Date as 'PO Receipt Date', C.User_FullName as 'Buyer', A.WO_ID, A.User_ID,A.Completed_User_ID" & Environment.NewLine
                strSql &= "FROM tpartneed A INNER JOIN security.tusers B ON A.User_ID = B.User_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN security.tusers C ON A.Buyer_User_ID = C.User_ID" & Environment.NewLine
                strSql &= "WHERE WO_ID = " & iWOID & " ORDER BY A.PN_ID ASC" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '***********************************************************************************************************************
        Public Function AddPartNeeds(ByVal iWOID As Integer, ByVal strPartNo As String, ByVal strPartDesc As String, _
                                      ByVal strNotes As String, ByVal iQty As Integer, ByVal iUserID As Integer, ByRef strMsg As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim i As Integer = 0

            Try
                strSql = "SELECT * " & Environment.NewLine
                strSql &= "FROM tpartneed " & Environment.NewLine
                strSql &= "WHERE WO_ID = " & iWOID & " AND Part_Number = '" & strPartNo & "'" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 1 Then
                    strMsg = "Duplicate entry for part # " & strPartNo & "."
                ElseIf dt.Rows.Count = 1 AndAlso Not IsDBNull(dt.Rows(0)("Nav_PO")) Then
                    strMsg = "Can't update after PO has been issued."
                ElseIf dt.Rows.Count = 1 AndAlso Not IsDBNull(dt.Rows(0)("CompletedDate")) Then
                    strMsg = "This claim has been completed."
                ElseIf dt.Rows.Count = 1 Then
                    strMsg = "Part # is added. Please select update function."
                Else
                    strSql = "INSERT INTO tpartneed ( Part_Number, Part_Desc, Notes, WO_ID, Qty, User_ID, Trans_DateTime " & Environment.NewLine
                    strSql &= ") VALUES ( " & Environment.NewLine
                    strSql &= "'" & strPartNo.Replace("'", "''") & "', '" & strPartDesc.Replace("'", "''") & "', '" & strNotes.Replace("'", "''") & "'" & Environment.NewLine
                    strSql &= ", " & iWOID & ", " & iQty & ", " & iUserID & ", now() " & Environment.NewLine
                    strSql &= ")"
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                End If

                Return i

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '***********************************************************************************************************************
        Public Function UpdatePartNeeds(ByVal iPartNeedID As Integer, ByVal strPartNo As String, ByVal strPartDesc As String, _
                                      ByVal strNotes As String, ByVal iQty As Integer, ByVal iUserID As Integer, ByRef strMsg As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim i As Integer = 0

            Try
                strSql = "SELECT * " & Environment.NewLine
                strSql &= "FROM tpartneed " & Environment.NewLine
                strSql &= "WHERE PN_ID = " & iPartNeedID
                dt = Me._objDataProc.GetDataTable(strSql)

                If Not IsDBNull(dt.Rows(0)("Nav_PO")) Then
                    strMsg = "Can't update after PO has been issued."
                ElseIf dt.Rows.Count = 1 AndAlso Not IsDBNull(dt.Rows(0)("CompletedDate")) Then
                    strMsg = "This claim has been completed."
                Else
                    strSql = "UPDATE tpartneed SET Part_Number = '" & strPartDesc.Replace("'", "''") & "'," & Environment.NewLine
                    strSql &= "Part_Desc = '" & strPartDesc.Replace("'", "''") & "'," & Environment.NewLine
                    strSql &= "Notes = '" & strNotes.Replace("'", "''") & "'," & Environment.NewLine
                    strSql &= "Qty = " & iQty & ", User_ID = " & iUserID & ", Trans_DateTime= now() " & Environment.NewLine
                    strSql &= "WHERE PN_ID = " & dt.Rows(0)("PN_ID")
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                End If

                Return i

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        ''***********************************************************************************************************************
        'Public Sub UpdateUserIDToCurrent(ByVal iWOID As Integer)
        '    Dim strSql As String = ""
        '    Dim dt As DataTable, row As DataRow
        '    Dim iPN_ID As Integer = 0, iOldPN_ID As Integer = 0, i, j As Integer
        '    Dim strHistory As String = ""
        '    Dim strOldTransDTime As String = ""
        '    Dim strLastTransDTime As String = ""
        '    Dim iLastUserID, iOldUserID As Integer

        '    Try
        '        'UserID_History,Trans_DateTime
        '        strSql = "SELECT * from tpartneed WHERE WO_ID = " & iWOID & " ORDER BY Trans_Datetime desc;" & Environment.NewLine
        '        dt = Me._objDataProc.GetDataTable(strSql)


        '        iLastUserID = dt.Rows(0).Item("User_ID")
        '        strLastTransDTime = Format(dt.Rows(0).Item("Trans_DateTime"), "yyyy-MM-dd HH:mm:ss")

        '        For i = 0 To dt.Rows.Count - 1
        '            If i = 0 Then
        '                iLastUserID = dt.Rows(0).Item("User_ID")
        '                strLastTransDTime = Format(dt.Rows(0).Item("Trans_DateTime"), "yyyy-MM-dd HH:mm:ss")
        '            Else
        '                iOldUserID = dt.Rows(i).Item("User_ID")
        '                strHistory = "" : strOldTransDTime = ""
        '                If Not iOldUserID = iLastUserID Then
        '                    iPN_ID = dt.Rows(i).Item("PN_ID")
        '                    If IsDate(dt.Rows(i).Item("Trans_DateTime")) Then
        '                        strOldTransDTime = Format(dt.Rows(i).Item("Trans_DateTime"), "yyyy-MM-dd HH:mm:ss")
        '                    End If
        '                    If Not IsDBNull(dt.Rows(i).Item("UserID_History")) Then
        '                        strHistory = dt.Rows(i).Item("UserID_History")
        '                    End If
        '                    If strHistory.Trim.Length > 0 Then
        '                        strHistory &= ";" & iOldUserID & "," & strOldTransDTime
        '                    Else
        '                        strHistory &= iOldUserID.ToString & "," & strOldTransDTime
        '                    End If
        '                    strSql = "UPDATE tpartneed SET User_ID=" & iLastUserID & ",Trans_DateTime='" & strLastTransDTime & "'," & Environment.NewLine
        '                    strSql &= "UserID_History='" & strHistory & "'" & Environment.NewLine
        '                    strSql &= " WHERE PN_ID =" & iPN_ID & Environment.NewLine
        '                    j = Me._objDataProc.ExecuteNonQuery(strSql)
        '                End If
        '            End If
        '        Next



        '    Catch ex As Exception
        '        Throw ex
        '    Finally
        '        Generic.DisposeDT(dt)
        '    End Try
        'End Sub


        '***********************************************************************************************************************
        Public Function CompletedPartEstimate(ByVal iWOID As Integer, ByVal iUserID As Integer) As Integer
            Dim strSql As String = ""
            Dim i As Integer
            Dim iSeqNo As Integer
            Dim dt As DataTable, row As DataRow

            Try

                'Find and Define SeqNo
                strSql = "SELECT Max(CompletedSeqNo) AS maxSeqNo" & Environment.NewLine
                strSql &= " FROM tPartNeed" & Environment.NewLine
                strSql &= " WHERE WO_ID=" & iWOID & " AND Date_Format(CompletedDate,'%Y-%m-%d') <= Date_Format(Now(),'%Y-%m-%d');" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                iSeqNo = 1
                For Each row In dt.Rows 'should be one row only
                    If Not row.IsNull("maxSeqNo") Then
                        iSeqNo = row("maxSeqNo") + 1 : Exit For
                    End If
                Next

                'Update tWorkOrder
                strSql = "UPDATE tworkorder SET ClosePreOrderPart = 1 " & Environment.NewLine
                strSql &= " WHERE WO_ID = " & iWOID & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                'Update tPartNeed
                strSql = "UPDATE tpartneed SET CompletedDate = now(), Completed_User_ID = " & iUserID & Environment.NewLine
                strSql &= ",CompletedSeqNo= " & iSeqNo & Environment.NewLine
                strSql &= " WHERE WO_ID = " & iWOID & " AND CompletedDate is null "
                i += Me._objDataProc.ExecuteNonQuery(strSql)

                Return i

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '***********************************************************************************************************************
        Public Function ReOpenCompletedPartEstimate(ByVal iWOID As Integer) As Integer
            Dim strSql As String = ""
            Dim i As Integer

            Try
                strSql = "UPDATE tworkorder SET ClosePreOrderPart = 0 " & Environment.NewLine
                strSql &= "WHERE WO_ID = " & iWOID & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************
        Public Function DeleteNeedPart(ByVal iPartNeedID As Integer) As Integer
            Dim strSql As String = ""
            Dim i As Integer

            Try
                strSql = "DELETE FROM tpartneed WHERE PN_ID = " & iPartNeedID
                i += Me._objDataProc.ExecuteNonQuery(strSql)

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************
        Public Function GetCompletedPartEstimateList(ByVal iLocID As Integer, ByVal _bEndUser As Boolean)
            Dim strSql As String = ""
            Try
                'strSql = "SELECT B.Part_Number as 'Part #', B.Part_Desc as 'Part Description', B.Notes, B.Qty, C.User_FullName as 'Trans User'" & Environment.NewLine
                'strSql &= ", B.Trans_DateTime as 'Trans Date', B.Nav_PO as 'PO', B.Nav_PO_Purchase_Date as 'PO Date'" & Environment.NewLine
                'strSql &= ", B.Nav_PO_Rec_Date as 'PO Receipt Date', D.User_FullName as 'Buyer', A.WO_CustWO as 'Claim#', A.WO_ID, B.PN_ID" & Environment.NewLine
                'strSql &= "FROM tworkorder A INNER JOIN tpartneed B ON A.WO_ID = B.WO_ID" & Environment.NewLine
                'strSql &= "INNER JOIN security.tusers C ON B.User_ID = C.User_ID " & Environment.NewLine
                'strSql &= "LEFT OUTER JOIN security.tusers D ON B.Buyer_User_ID = D.User_ID" & Environment.NewLine
                'strSql &= "WHERE Loc_ID = " & iLocID & Environment.NewLine
                'strSql &= "AND A.WO_DateShip is null AND A.ClosePreOrderPart = 1" & Environment.NewLine

                'strSql = "SELECT B.Part_Number as 'Part #', B.Part_Desc as 'Part Description', B.Notes, B.Qty, C.User_FullName as 'Trans User'" & Environment.NewLine
                'strSql &= " , B.Trans_DateTime as 'Trans Date', B.Nav_PO as 'PO', B.Nav_PO_Purchase_Date as 'PO Date' " & Environment.NewLine
                'strSql &= " , B.Nav_PO_Rec_Date as 'PO Receipt Date', D.User_FullName as 'Buyer', A.WO_CustWO as 'Claim#'" & Environment.NewLine
                'strSql &= " , Date_Format(F.Device_DateRec ,'%Y-%m-%d') as 'Rec Date',E.PSSI2Cust_TrackNo AS 'Outbound Track#'" & Environment.NewLine
                'strSql &= " , E.Cust2PSSI_TrackNo AS 'Inbound Track#'" & Environment.NewLine
                'strSql &= " , A.WO_ID, B.PN_ID,F.Device_ID,E.EW_ID" & Environment.NewLine
                'strSql &= " FROM tworkorder A INNER JOIN tpartneed B ON A.WO_ID = B.WO_ID" & Environment.NewLine
                'strSql &= " INNER JOIN security.tusers C ON B.User_ID = C.User_ID" & Environment.NewLine
                'strSql &= " LEFT OUTER JOIN security.tusers D ON B.Buyer_User_ID = D.User_ID" & Environment.NewLine
                'strSql &= " INNER JOIN extendedwarranty E ON A.WO_ID=E.WO_ID" & Environment.NewLine
                'strSql &= " INNER JOIN tdevice F ON E.WO_ID=F.WO_ID" & Environment.NewLine
                'strSql &= " WHERE F.Loc_ID  = " & iLocID & Environment.NewLine
                'strSql &= " AND A.WO_DateShip is null AND A.ClosePreOrderPart = 1;" & Environment.NewLine
                If _bEndUser Then
                    strSql = "SELECT A.WO_Closed, B.Part_Number as 'Part #', B.Part_Desc as 'Part Description', B.Notes, B.Qty" & Environment.NewLine
                    strSql &= "  , C.User_FullName as 'Part Requested By', B.CompletedDate as 'Part Requested Date'" & Environment.NewLine
                    strSql &= "  , B.Nav_PO as 'PO', B.Nav_PO_Purchase_Date as 'PO Date', Nav_PO_ETA_Date as 'PO ETA'" & Environment.NewLine
                    strSql &= "  , B.Nav_PO_Rec_Date as 'PO Receipt Date', D.User_FullName as 'Buyer', A.WO_CustWO as 'Claim #'" & Environment.NewLine
                    strSql &= "  , E.Brand, E.Model, E.Cust2PSSI_TrackNo AS 'Inbound Track#'" & Environment.NewLine
                    strSql &= "  , A.WO_ID, B.PN_ID" & Environment.NewLine
                    strSql &= "  FROM tworkorder A INNER JOIN tpartneed B ON A.WO_ID = B.WO_ID" & Environment.NewLine
                    strSql &= "  INNER JOIN security.tusers C ON B.User_ID = C.User_ID" & Environment.NewLine
                    strSql &= "  LEFT OUTER JOIN security.tusers D ON B.Buyer_User_ID = D.User_ID" & Environment.NewLine
                    strSql &= "  INNER JOIN extendedwarranty E ON A.WO_ID=E.WO_ID" & Environment.NewLine
                    strSql &= "  WHERE A.Loc_ID  = " & iLocID & Environment.NewLine
                    strSql &= " AND A.WO_DateShip is null AND A.ClosePreOrderPart = 1;" & Environment.NewLine
                Else
                    strSql = "SELECT A.WO_Closed, B.Part_Number as 'Part #', B.Part_Desc as 'Part Description', B.Notes, B.Qty" & Environment.NewLine
                    strSql &= "  , C.User_FullName as 'Part Requested By', B.CompletedDate as 'Part Requested Date'" & Environment.NewLine
                    strSql &= "  , B.Nav_PO as 'PO', B.Nav_PO_Purchase_Date as 'PO Date', Nav_PO_ETA_Date as 'PO ETA'" & Environment.NewLine
                    strSql &= "  , B.Nav_PO_Rec_Date as 'PO Receipt Date', D.User_FullName as 'Buyer', A.WO_CustWO as 'Claim #'" & Environment.NewLine
                    strSql &= "  , E.Brand, E.Model, E.Cust2PSSI_TrackNo AS 'Inbound Track#'" & Environment.NewLine
                    strSql &= "  , A.WO_ID, B.PN_ID " & Environment.NewLine
                    strSql &= "  FROM tworkorder A INNER JOIN tpartneed B ON A.WO_ID = B.WO_ID" & Environment.NewLine
                    strSql &= "  INNER JOIN security.tusers C ON B.User_ID = C.User_ID" & Environment.NewLine
                    strSql &= "  LEFT OUTER JOIN security.tusers D ON B.Buyer_User_ID = D.User_ID" & Environment.NewLine
                    strSql &= "  WHERE A.Loc_ID  = " & iLocID & Environment.NewLine
                    strSql &= " AND A.WO_DateShip is null AND A.ClosePreOrderPart = 1;" & Environment.NewLine
                End If

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************
        Public Function UpdatePO(ByVal strPN_IDs As String, ByVal strPO As String, ByVal iUserID As Integer) As Integer
            Dim strSql As String = ""
            Try
                strSql = "UPDATE tpartneed SET Buyer_User_ID = " & iUserID & ", Nav_PO = '" & strPO & "'" & Environment.NewLine
                strSql &= "WHERE PN_ID IN ( " & strPN_IDs & ") " & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************
        Public Function GetRecDevicesInWO(ByVal iWOID As Integer) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT tdevice.* FROM tdevice INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID" & Environment.NewLine
                strSql &= "WHERE tworkorder.WO_ID = " & iWOID & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************
        Public Function Get_SN_DiscrepancyData(ByVal iLoc_ID As Integer, ByVal iWOID As Integer) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT A.Device_ID,A.Device_SN,B.Manuf_SN,B.WorkStation,B.SN_Discp_Flag,B.SN_Discp_AV_ID,B.SN_Discp_Approved_DT,B.SN_Discp_Approved_User_ID,A.WO_ID" & Environment.NewLine
                strSql &= " FROM tDevice A" & Environment.NewLine
                strSql &= " INNER JOIN tCellOpt B ON A.Device_ID=B.Device_ID" & Environment.NewLine
                strSql &= " WHERE LOC_ID=" & iLoc_ID & " AND WO_ID=" & iWOID & ";" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************


#End Region

#Region "Parts Pick Ticket"
        '***********************************************************************************************************************
        Public Function GetPartsPickTicketData(ByVal strClaimNo As String, ByVal iCust_ID As Integer) As DataTable
            Dim strSql As String = ""
            Dim objDataProc As New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

            Try
                strSql = "SELECT A.ClaimNo,C.Part_Number,C.Part_Desc,C.Nav_PO_Bin AS Bin" & Environment.NewLine
                strSql &= ",C.Nav_PO AS PO,Date_Format(C.Nav_PO_Purchase_Date,'%Y-%m-%d') AS Purchase_Date,Date_Format(C.Nav_PO_ETA_Date,'%Y-%m-%d') AS ETA_Date" & Environment.NewLine
                strSql &= ",Date_Format(Nav_PO_Rec_Date,'%Y-%m-%d') As Recv_Date,Nav_PO_LineNo AS LineNo" & Environment.NewLine
                strSql &= ",Date_Format(C.Part_Prod_Order_DT,'%Y-%m-%d') AS Pick_Date,Date_Format(C.Part_Prod_Order_DT,'%Y-%m-%d') AS Prod_DT" & Environment.NewLine
                strSql &= ",IF(C.Nav_PO_Bin IS NULL,'" & enumPartPickStatus.Not_Received.ToString.Replace("_", " ") & "', " & Environment.NewLine
                strSql &= "   IF(C.Part_Prod_Order_DT IS NULL OR LENGTH(TRIM(C.Part_Prod_Order_DT))=0,'" & enumPartPickStatus.In_Cage.ToString.Replace("_", " ") & "','" & enumPartPickStatus.In_Production.ToString.Replace("_", " ") & "' )) AS Part_Status" & Environment.NewLine
                strSql &= ",TRIM(CONCAT(Type, ' ', Brand, ' ', Model)) AS Device_Desc,D.Model_Desc As Other1" & Environment.NewLine
                strSql &= ",IF(TRIM(A.SerialNo)=TRIM(B.Device_SN), B.Device_SN, CONCAT(B.Device_SN ,' (Recv)',', ',A.SerialNo,' (EDI)')) AS Device_SN" & Environment.NewLine
                strSql &= ",Date_Format(A.ExpectedShipDate,'%Y-%m-%d') AS ExpectedShipDate,A.EstimatedPrice,A.EstimatedPartCost,A.ShipTo_Name AS 'Device Owner'" & Environment.NewLine
                strSql &= ",Date_Format(A.LoadedDateTime,'%Y-%m-%d') AS RMACreatedDT,Date_Format(B.Device_DateRec,'%Y-%m-%d') AS DeviceRecvDT" & Environment.NewLine
                strSql &= ",A.Tel,A.Email,A.WO_ID,A.EW_ID,B.Device_ID,C.PN_ID" & Environment.NewLine
                strSql &= " FROM ExtendedWarranty A" & Environment.NewLine
                strSql &= " INNER JOIN tDevice B ON A.WO_ID=B.WO_ID" & Environment.NewLine
                strSql &= " INNER JOIN tPartNeed C ON B.WO_ID=C.WO_ID" & Environment.NewLine
                strSql &= " INNER JOIN tModel D ON B.Model_ID=D.Model_ID" & Environment.NewLine
                strSql &= " WHERE A.CUST_ID=" & iCust_ID & " AND B.Device_DateShip IS NULL" & Environment.NewLine
                strSql &= " AND A.ClaimNo='" & strClaimNo.Replace("'", "''") & "' ORDER BY Part_Status;" & Environment.NewLine

                Return objDataProc.GetDataTable(strSql)

                objDataProc = Nothing

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************
        Public Function UpdatePartsPickData(ByVal arrPN_IDs As ArrayList, ByVal strDateTime As String, ByVal iUser_ID As Integer) As Integer
            Dim strSql As String = ""
            Dim PNIDs As String = ""
            Dim i As Integer = 0

            Try
                For i = 0 To arrPN_IDs.Count - 1
                    If i = 0 Then
                        PNIDs = arrPN_IDs(i)
                    Else
                        PNIDs = "," & arrPN_IDs(i)
                    End If
                Next
                strSql = "UPDATE Production.tPartNeed SET Part_Prod_Order_DT='" & strDateTime & "'" & Environment.NewLine
                strSql &= ",Part_Prod_Order_User_ID=" & iUser_ID & Environment.NewLine
                strSql &= " WHERE PN_ID in (" & PNIDs & ")" & Environment.NewLine

                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '***********************************************************************************************************************

#End Region

#Region "Billing"

        '***********************************************************************************************************************
        Public Function NeedExceptionRepairsApproval(ByVal iDeviceID As Integer, ByVal iCustID As Integer) As Boolean
            Dim strSql As String = ""
            Dim booHasExceptionRep, booNeedExcptRepApproval As Boolean
            Dim decTotalPartCharge As Decimal = 0
            Dim dr As DataRow

            Try
                booHasExceptionRep = False : booNeedExcptRepApproval = False
                strSql = "SELECT count(*) as cnt FROM tdevicebill " & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON tdevicebill.billcode_ID = lbillcodes.Billcode_ID " & Environment.NewLine
                strSql &= "WHERE tdevicebill.Device_ID = " & iDeviceID & " AND Billcode_Desc = 'Exception Repairs'"
                If Me._objDataProc.GetIntValue(strSql) Then booHasExceptionRep = True

                If booHasExceptionRep Then
                    If HasQuoteApproval(iDeviceID) = True Then Exit Function
                    '**********************************
                    dr = CalExcptRepCharge(iDeviceID)
                    If (Convert.ToDouble(dr("LaborCharge")) + Convert.ToDouble(dr("PartCharge"))) > _iMaxExcptRepCharge Then booNeedExcptRepApproval = True
                    '**********************************
                End If

                Return booNeedExcptRepApproval
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************************************
        Public Function HasQuoteApproval(ByVal iDeviceID As Integer) As Boolean
            Dim strSql As String = ""
            Dim booHasQuoteApproval As Boolean = False
            Dim dt As DataTable

            Try
                strSql = "SELECT EstimatedPartCost_Date, EstimatedPartCost FROM tdevice A INNER JOIN extendedwarranty B ON A.WO_ID = B.WO_ID WHERE Device_ID = " & iDeviceID
                dt = Me._objDataProc.GetDataTable(strSql)

                If Not IsDBNull(dt.Rows(0)("EstimatedPartCost_Date")) Then booHasQuoteApproval = True

                Return booHasQuoteApproval
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '*************************************************************************************************************
        Public Function CalExcptRepCharge(ByVal iDeviceID As Integer) As DataRow
            Dim strSql As String = ""
            Dim dt1, dt2 As DataTable
            Dim dbLabor, dbPartCharge, dbMarkUp As Double

            Try
                strSql = "SELECT PricePerHour, 0 as TotalHour, 0.0 as LaborCharge, 0 as PartCharge, 0.0 as 'Markup' " & Environment.NewLine
                strSql &= "FROM tdevice INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strSql &= "INNER JOIN techprice ON tlocation.Cust_ID = techprice.Cust_ID " & Environment.NewLine
                strSql &= "WHERE tdevice.Device_ID = " & iDeviceID
                dt1 = Me._objDataProc.GetDataTable(strSql)

                If dt1.Rows.Count = 0 OrElse CInt(dt1.Rows(0)("PricePerHour")) = 0 Then Throw New Exception("Tech Rate is missing.")

                strSql = "SELECT Device_Laborcharge, extendedwarranty.* FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN extendedwarranty ON tdevice.WO_ID = extendedwarranty.WO_ID " & Environment.NewLine
                strSql &= "WHERE tdevice.Device_ID = " & iDeviceID
                dt2 = Me._objDataProc.GetDataTable(strSql)

                If dt2.Rows.Count = 0 OrElse Convert.ToInt16(dt2.Rows(0)("EstimatedTechHrs")) = 0 Then
                    Throw New Exception("Tech hour is missing.")
                    'ElseIf Convert.ToDecimal(dt.Rows(0)("EstimatedPartCost")) = 0 Then
                    '    Throw New Exception("Estimated part cost is missing.")
                End If

                dbLabor = CDec(dt1.Rows(0)("PricePerHour")) * CDec(dt2.Rows(0)("EstimatedTechHrs"))

                strSql = "SELECT Markup_Cust FROM tdevice INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcustmarkup ON tlocation.Cust_ID = tcustmarkup.Cust_ID AND tmodel.Prod_ID = tcustmarkup.Prod_ID " & Environment.NewLine
                strSql &= "WHERE tdevice.Device_ID = " & iDeviceID
                dbMarkUp = Me._objDataProc.GetDoubleValue(strSql)

                strSql = "SELECT SUM(" & (1 + dbMarkUp) & " * DBill_StdCost) AS 'PartCharge' FROM tdevicebill " & Environment.NewLine
                strSql &= "WHERE tdevicebill.Device_ID = " & iDeviceID
                dbPartCharge = Me._objDataProc.GetDoubleValue(strSql)

                dt1.Rows(0).BeginEdit()
                dt1.Rows(0)("TotalHour") = Convert.ToInt16(dt2.Rows(0)("EstimatedTechHrs"))
                dt1.Rows(0)("LaborCharge") = dbLabor
                dt1.Rows(0)("PartCharge") = dbPartCharge
                dt1.Rows(0)("Markup") = dbMarkUp
                dt1.Rows(0).EndEdit()

                Return dt1.Rows(0)
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt1) : Generic.DisposeDT(dt2)
            End Try
        End Function

        '*************************************************************************************************************
        Public Function BillExceptionRepairs(ByVal iDeviceID As Integer, ByVal dtBilledBillCode As DataTable) As Integer
            Dim i As Integer = 0

            Try
                If dtBilledBillCode.Select("Billcode_Desc = 'Depot Repaired'").Length > 0 Then
                    i = UpdatePartChargeToZero(iDeviceID)
                ElseIf dtBilledBillCode.Select("Billcode_Desc = 'Exception Repairs'").Length > 0 Then
                    i = UpdateExcptRepPartCharge(iDeviceID)
                ElseIf dtBilledBillCode.Select("Billcode_Desc = 'Exception Repairs Quote Rejected'").Length > 0 Then
                    i = UpdatePartChargeToZero(iDeviceID)
                ElseIf dtBilledBillCode.Select("Billcode_Desc = 'Scrap'").Length > 0 Then
                    i = UpdatePartChargeToZero(iDeviceID)
                ElseIf dtBilledBillCode.Select("Billcode_Desc = 'CANCEL'").Length > 0 Then
                    i = UpdatePartChargeToZero(iDeviceID)
                ElseIf dtBilledBillCode.Select("Billcode_Desc = 'PSS Warranty No Fault Found'").Length > 0 Then
                    i = UpdatePartChargeToZero(iDeviceID)
                ElseIf dtBilledBillCode.Select("Billcode_Desc = 'Repaired PSS Warranty'").Length > 0 Then
                    i = UpdatePartChargeToZero(iDeviceID)
                Else
                    i = UpdatePartChargeToZero(iDeviceID)
                End If

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ''***************************************************************************************************
        'Public Function GetTechHrCharge(ByVal iDeviceID As Integer) As Decimal
        '    Dim strSql As String = ""
        '    Dim dbTotalPartCharge As Double = 0
        '    Dim dbTotalEstimatePartCharge As Double = 0
        '    Dim i As Integer = 0
        '    Dim dbTechRate As Double = 0
        '    Dim dbTechHrs As Double = 0
        '    Dim dt, dtTotalPartCharge As DataTable

        '    Try
        '        strSql = "SELECT PricePerHour FROM tdevice INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
        '        strSql &= "INNER JOIN techprice ON tlocation.Cust_ID = techprice.Cust_ID " & Environment.NewLine
        '        strSql &= "WHERE tdevice.Device_ID = " & iDeviceID
        '        dbTechRate = Me._objDataProc.GetDoubleValue(strSql)

        '        strSql = "SELECT Device_Laborcharge, extendedwarranty.* FROM tdevice INNER JOIN extendedwarranty ON tdevice.WO_ID = extendedwarranty.WO_ID " & Environment.NewLine
        '        strSql &= "WHERE tdevice.Device_ID = " & iDeviceID
        '        dt = Me._objDataProc.GetDataTable(strSql)
        '        If booCheckTechHrAndEstPartCost Then
        '            If dt.Rows.Count = 0 OrElse Convert.ToInt16(dt.Rows(0)("EstimatedTechHrs")) = 0 Then
        '                Throw New Exception("Tech hour is missing.")
        '                'ElseIf Convert.ToDecimal(dt.Rows(0)("EstimatedPartCost")) = 0 Then
        '                '    Throw New Exception("Estimated part cost is missing.")
        '            End If
        '        End If

        '        If Not IsDBNull(dt.Rows(0)("EstimatedTechHrs")) Then dbTechHrs = Convert.ToDouble(dt.Rows(0)("EstimatedTechHrs"))

        '        'REMOVE MARKUP ON PART ESTIMATE COST. REQUESTED BY STEVE MULL 01/31/2013
        '        'If Not IsDBNull(dt.Rows(0)("EstimatedPartCost")) Then dbTotalEstimatePartCharge = Convert.ToDouble(dt.Rows(0)("EstimatedPartCost")) * (1 + decMarkup)
        '        If Not IsDBNull(dt.Rows(0)("EstimatedPartCost")) Then dbTotalEstimatePartCharge = Convert.ToDouble(dt.Rows(0)("EstimatedPartCost"))

        '        strSql = "UPDATE tdevicebill INNER JOIN lbillcodes ON tdevicebill.Billcode_ID = lbillcodes.Billcode_ID " & Environment.NewLine
        '        strSql &= "SET DBill_InvoiceAmt = (" & (1 + decMarkup) & " * DBill_StdCost) " & Environment.NewLine
        '        strSql &= "WHERE tdevicebill.Device_ID = " & iDeviceID & " AND BillType_ID IN ( 2, 3 ) "
        '        i = Me._objDataProc.ExecuteNonQuery(strSql)

        '        strSql = "SELECT SUM( DBill_InvoiceAmt) as TotalPartCharge " & Environment.NewLine
        '        strSql &= "FROM tdevicebill WHERE tdevicebill.Device_ID = " & iDeviceID
        '        dtTotalPartCharge = Me._objDataProc.GetDataTable(strSql)
        '        If dtTotalPartCharge.Rows.Count > 0 AndAlso Not IsDBNull(dtTotalPartCharge.Rows(0)("TotalPartCharge")) Then dbTotalPartCharge = Convert.ToDouble(dtTotalPartCharge.Rows(0)("TotalPartCharge"))

        '        'Override total part charge with estimate part cost plus mark up
        '        If dbTotalEstimatePartCharge > dbTotalPartCharge Then dbTotalPartCharge = dbTotalEstimatePartCharge

        '        strSql = "UPDATE tdevice set Device_PartCharge = " & dbTotalPartCharge & Environment.NewLine
        '        strSql &= ", Device_Laborcharge = (Device_Laborcharge + " & (dbTechRate * dbTechHrs) & ") " & Environment.NewLine
        '        strSql &= "WHERE tdevice.Device_ID = " & iDeviceID
        '        i = Me._objDataProc.ExecuteNonQuery(strSql)

        '        Return i
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function

        '***************************************************************************************************
        Public Function UpdateExcptRepPartCharge(ByVal iDeviceID As Integer) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0
            Dim dr As DataRow

            Try
                dr = Me.CalExcptRepCharge(iDeviceID)
                If IsNothing(dr) Then Throw New Exception("System has failed to calculate labor and part charge for exception repair.")

                strSql = "UPDATE tdevicebill INNER JOIN lbillcodes ON tdevicebill.Billcode_ID = lbillcodes.Billcode_ID " & Environment.NewLine
                strSql &= "SET DBill_InvoiceAmt = (" & (1 + Convert.ToDouble(dr("Markup"))) & " * DBill_StdCost) " & Environment.NewLine
                strSql &= "WHERE tdevicebill.Device_ID = " & iDeviceID
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                strSql = "UPDATE tdevice set Device_PartCharge = " & Convert.ToDouble(dr("PartCharge")) & Environment.NewLine
                strSql &= ", Device_Laborcharge = " & Convert.ToDouble(dr("LaborCharge")) & Environment.NewLine
                strSql &= "WHERE tdevice.Device_ID = " & iDeviceID
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                If (Convert.ToDouble(dr("LaborCharge")) + Convert.ToDouble(dr("PartCharge"))) > Me._iMaxExcptRepCharge Then
                    strSql = "UPDATE extendedwarranty INNER JOIN tdevice ON extendedwarranty.WO_ID = tdevice.WO_ID" & Environment.NewLine
                    strSql &= "SET EstimatedPartCost_Date = null, EstimatedPartCost = 0" & Environment.NewLine
                    strSql &= "WHERE Device_ID = " & iDeviceID
                    Me._objDataProc.ExecuteNonQuery(strSql)
                Else
                    strSql = "UPDATE extendedwarranty INNER JOIN tdevice ON extendedwarranty.WO_ID = tdevice.WO_ID" & Environment.NewLine
                    strSql &= "SET EstimatedPartCost_Date = now(), EstimatedPartCost = " & Convert.ToDouble(dr("PartCharge")) & Environment.NewLine
                    strSql &= "WHERE Device_ID = " & iDeviceID
                    Me._objDataProc.ExecuteNonQuery(strSql)
                End If

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************************
        Public Function UpdatePartChargeToZero(ByVal iDeviceID As Integer) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0

            Try
                strSql = "UPDATE tdevice, extendedwarranty SET Device_PartCharge = 0, EstimatedPartCost_Date = null, EstimatedPartCost = 0  " & Environment.NewLine
                strSql &= "WHERE extendedwarranty.WO_ID = tdevice.WO_ID AND tdevice.device_ID = " & iDeviceID
                i += Me._objDataProc.ExecuteNonQuery(strSql)
                If i = 0 Then Throw New Exception("System has failed to reset part charge.")

                strSql = "UPDATE tdevicebill INNER JOIN lbillcodes ON tdevicebill.Billcode_ID = lbillcodes.Billcode_ID " & Environment.NewLine
                strSql &= "SET DBill_InvoiceAmt = 0 " & Environment.NewLine
                strSql &= "WHERE tdevicebill.device_ID = " & iDeviceID
                i += Me._objDataProc.ExecuteNonQuery(strSql)
                If i = 0 Then Throw New Exception("System has failed to reset part charge.")

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************
        Public Function SetTechHour(ByVal iWOID As Integer, ByVal dbTechHour As Double) As Integer
            Dim strSql As String = ""

            Try
                strSql = "UPDATE extendedwarranty SET EstimatedTechHrs = " & dbTechHour & Environment.NewLine
                strSql &= "WHERE WO_ID = " & iWOID
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************
        Public Function GetExpectedShipDate(ByVal iWOID As Integer, ByVal iDeviceID As Integer, ByVal bIsByDeviceID As Boolean) As String
            Dim strSQL1 As String = "", strSQL2 As String = ""
            Dim dt As DataTable
            Dim myDate As Date
            Dim strResult As String = ""
            Dim iLocalWOID As Integer = 0

            Try
                If bIsByDeviceID Then
                    strSQL1 = "select WO_ID from tdevice where device_ID=" & iDeviceID
                    dt = Me._objDataProc.GetDataTable(strSQL1)
                    If dt.Rows.Count > 0 Then
                        If IsNumeric(dt.Rows(0).Item("WO_ID")) Then
                            iLocalWOID = dt.Rows(0).Item("WO_ID")
                        End If
                    End If
                    dt = Nothing
                Else
                    iLocalWOID = iWOID
                End If

                strSQL2 = "Select ExpectedShipDate from extendedwarranty" & Environment.NewLine
                strSQL2 &= " WHERE WO_ID = " & iLocalWOID

                dt = Me._objDataProc.GetDataTable(strSQL2)
                If dt.Rows.Count > 0 Then
                    If IsDate(dt.Rows(0).Item("ExpectedShipDate")) Then
                        myDate = dt.Rows(0).Item("ExpectedShipDate")
                        Return Format(myDate, "yyyy-MM-dd")
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************
        Public Function LoadFailureCodes(ByVal booAddSelectedRow As Boolean) As DataTable
            Dim dt As DataTable
            Dim iMCode_ID As Integer = 0
            Dim strSql As String = ""

            Try
                strSql = "SELECT DCode_ID, Dcode_SDesc, Dcode_Ldesc, Concat(trim(Dcode_SDesc), ' - ', trim(Dcode_Ldesc)) as DCode_SLDesc" & Environment.NewLine
                strSql &= " FROM lcodesdetail" & Environment.NewLine
                strSql &= " INNER JOIN lcodesmaster ON lcodesdetail.MCode_ID = lcodesmaster.MCode_ID" & Environment.NewLine
                strSql &= " WHERE TechScreen = 1 AND lcodesmaster.Prod_ID = 33 AND lcodesmaster.MCode_ID =59 AND Dcode_Inactive = 0  order by lcodesdetail.Dcode_sdesc;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If booAddSelectedRow Then dt.LoadDataRow(New Object() {"0", "Dcode_SDesc", "Dcode_Ldesc", "--Select--"}, True)

                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************
        Public Function ResetQuoteApproval(ByVal iWOID As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "UPDATE extendedwarranty SET EstimatedPrice = 0, EstimatedPartCost = 0, EstimatedPartCost_Date = null" & Environment.NewLine
                strSql &= ", Quote_AV_ID = 0, QuoteAprovedUserID = 0 , ApprovedBy = '' " & Environment.NewLine
                strSql &= "WHERE WO_ID = " & iWOID
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************
        Public Function SetPssiStatus(ByVal iWOID As Integer, ByVal iPSSIStatus_ID As Integer, ByVal strPSSIStatusDesc As String) As Integer
            Dim strSql As String = ""

            Try
                strSql = "UPDATE extendedwarranty SET S_ID = " & iPSSIStatus_ID & ", PSSI_CurrentStatus = '" & strPSSIStatusDesc & "'" & Environment.NewLine
                strSql &= "WHERE WO_ID = " & iWOID
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************

#End Region

#Region "Approval"

        '***********************************************************************************************************************
        Public Function GetApprovalData(ByVal iLocID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT tdevice.Device_SN, WorkStation,Cellopt_WIPOwner, cellopt_id, tdevice.device_ID, tdevice.WO_ID, tdevice.Model_ID " & Environment.NewLine
                strSql &= ", tcellopt.PSS_Wrty_Approval_DT , tcellopt.PSS_Wrty_AV_ID, tdevice.Device_PSSWrty " & Environment.NewLine
                strSql &= ",tcellopt.SN_Discp_Approved_DT,tcellopt.SN_Discp_AV_ID,tcellopt.SN_Discp_Flag,extendedwarranty.SerialNo as 'EDI S/N'" & Environment.NewLine
                strSql &= " FROM tdevice" & Environment.NewLine
                strSql &= " INNER JOIN tcellopt ON tdevice.device_ID = tcellopt.device_id " & Environment.NewLine
                strSql &= " INNER JOIN extendedwarranty ON tdevice.WO_ID=extendedwarranty.WO_ID" & Environment.NewLine
                strSql &= " WHERE loc_id = " & iLocID & " AND Device_DateShip is null AND " & Environment.NewLine
                strSql &= " (Cellopt_WIPOwner = " & Me.iAwaitApproval_WIPOwner_Hold & " OR (Device_PSSWrty = 1 AND PSS_Wrty_AV_ID = 0) OR (SN_Discp_Flag = 1 AND SN_Discp_AV_ID = 0))" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '***********************************************************************************************************************
        Public Function GetApprovalForQuoteCharges(ByVal iDeviceID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT Device_ID, Device_LaborCharge,Device_PartCharge " & Environment.NewLine
                strSql &= "FROM tdevice WHERE device_ID = " & iDeviceID & ";" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************
        Public Function UpdatePSSWrtyApproval(ByVal iCellOptID As Integer, ByVal strApprovalDateTime As String, _
                                              ByVal iUSerID As Integer, ByVal iApprovedValID As Integer) As Integer
            Dim strSql As String = ""
            Try

                strSql = "UPDATE tCellOpt SET Cellopt_WIPOwner = 5, WorkStation = 'Waiting QC', PSS_Wrty_AV_ID = " & iApprovedValID & Environment.NewLine
                strSql &= ", PSS_Wrty_Approval_DT = '" & strApprovalDateTime & "', PSS_Wrty_Approval_User_ID = " & iUSerID & Environment.NewLine
                strSql &= "WHERE cellopt_id = " & iCellOptID & ";"

                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************
        Public Function UpdateSNDiscrepancyApproval(ByVal iCellOptID As Integer, ByVal strApprovalDateTime As String, _
                                              ByVal iUSerID As Integer, ByVal iApprovedValID As Integer) As Integer
            Dim strSql As String = ""
            Try

                strSql = "UPDATE tCellOpt SET Cellopt_WIPOwner = 3, WorkStation = 'WAITING TECH', SN_Discp_AV_ID= " & iApprovedValID & Environment.NewLine
                strSql &= ", SN_Discp_Approved_DT = '" & strApprovalDateTime & "', SN_Discp_Approved_User_ID = " & iUSerID & Environment.NewLine
                strSql &= "WHERE cellopt_id = " & iCellOptID & ";"

                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************
        Public Function UpdateQuoteApproval(ByVal iCustID As Integer, ByVal iWOID As Integer, ByVal dbTotalCharge As Double, _
                                            ByVal EstimatedPartCost As Double, ByVal strApprovalDateTime As String, _
                                            ByVal iApprovalValID As Integer, ByVal strQuoteApprovedBy As String, ByVal iUserID As Integer, _
                                            ByVal iCelloptID As Integer, ByRef strErrMsg As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim i As Integer

            Try
                strSql = "Select * from extendedwarranty where WO_ID=" & iWOID & " and Cust_ID=" & iCustID
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count = 1 Then
                    strSql = "UPDATE extendedwarranty SET EstimatedPrice = " & dbTotalCharge & Environment.NewLine
                    strSql &= ", EstimatedPartCost = " & EstimatedPartCost & ", EstimatedPartCost_Date = '" & strApprovalDateTime & "' " & Environment.NewLine
                    strSql &= ", Quote_AV_ID = " & iApprovalValID & ", QuoteAprovedUserID = " & iUserID & ", ApprovedBy = '" & strQuoteApprovedBy & "'" & Environment.NewLine
                    strSql &= ", S_ID = 4, PSSI_CurrentStatus = 'Quote Submitted' " & Environment.NewLine
                    strSql &= "WHERE  WO_ID = " & iWOID & " AND Cust_ID = " & iCustID & Environment.NewLine
                    i = Me._objDataProc.ExecuteNonQuery(strSql)

                    If i > 0 Then
                        strSql = "UPDATE tCellOpt SET Cellopt_WIPOwner = 3, WorkStation = 'WAITING TECH'" & Environment.NewLine
                        strSql &= "WHERE cellopt_id = " & iCelloptID & ""
                        i = Me._objDataProc.ExecuteNonQuery(strSql)
                    Else 'Failed
                        strErrMsg = "System has failed to update quote info."
                        Return 0
                    End If
                Else
                    strErrMsg = "System has failed to update quote info."
                    Return 0
                End If

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************
        Public Function GetApprovedData(ByVal iDeviceID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT tcellopt.*, extendedwarranty.EstimatedPartCost_Date, EstimatedPartCost, EstimatedPrice" & Environment.NewLine
                strSql &= " FROM tdevice INNER JOIN tcellopt ON tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN extendedwarranty ON tdevice.WO_ID = extendedwarranty.WO_ID " & Environment.NewLine
                strSql &= "WHERE tdevice.device_ID = " & iDeviceID & ";" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************
        Public Function GetApprovedValue() As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT * FROM lapprovedvalue WHERE AV_ID > 0 " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '***********************************************************************************************************************
        Public Function SN_ExistsInEDI(ByVal iCust_ID As Integer, ByVal strSN As String) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                'Check all opem claims, see if there is one which includes thsi SN
                strSql = "SELECT * FROM extendedwarranty WHERE Cust_ID = " & iCust_ID & " AND S_ID<7 AND SerialNo ='" & strSN.Replace("'", "''") & "';"
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

        '***********************************************************************************************************************

#End Region

#Region "Print"
        '***********************************************************************************************************************
        Public Function Print_ServiceWorkOrderLetter(ByVal dt As DataTable, _
                                                     ByVal iCopies As Integer) As Integer

            Dim objRpt As ReportDocument

            Try
                objRpt = New ReportDocument()
                With objRpt
                    .Load(PSS.Data.ConfigFile.GetBaseReportPath & "AIG Service WO Push.rpt")
                    If Not IsNothing(dt) Then .SetDataSource(dt)
                    .Refresh()
                    .PrintToPrinter(iCopies, True, 0, 0)
                End With
            Catch ex As Exception
                Throw ex
            Finally
                Me._objDataProc = Nothing
                ' PSS.Data.Buisness.Generic.DisposeDT(dtInput)
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try

        End Function

        '***********************************************************************************************************************
        Public Function Print_RepairedPartPickTicket(ByVal dt As DataTable, _
                                                     ByVal iCopies As Integer) As Integer

            Dim objRpt As ReportDocument

            Try
                objRpt = New ReportDocument()
                With objRpt
                    .Load(PSS.Data.ConfigFile.GetBaseReportPath & "AIG Part Pick Ticket Push.rpt")
                    If Not IsNothing(dt) Then .SetDataSource(dt)
                    .Refresh()
                    .PrintToPrinter(iCopies, True, 0, 0)
                End With
            Catch ex As Exception
                Throw ex
            Finally
                Me._objDataProc = Nothing
                ' PSS.Data.Buisness.Generic.DisposeDT(dtInput)
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try

        End Function


#End Region

#Region "Search"

        '***********************************************************************************************************************
        Public Function GetSearchData(ByVal iCustID As Integer, ByVal strClaimNo As String) As DataTable
            Dim strSql As String = ""

            Try
                strClaimNo = strClaimNo.Replace("'", "")
                strSql = "SELECT ClaimNo as 'Claim #', ShipTo_Name as 'Customer Name', Address1 as 'Customer Address'" & Environment.NewLine
                strSql &= ", City as 'Customer City', State_ShortName as 'State', ZipCode as 'Zip', Tel as 'Phone #', Email as 'Email Address' " & Environment.NewLine
                strSql &= ", A.*, AV_Desc, C.user_fullname " & Environment.NewLine
                strSql &= "FROM extendedwarranty A LEFT OUTER JOIN lapprovedvalue B ON A.Quote_AV_ID = B.AV_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN security.tusers C ON A.QuoteAprovedUserID = C.user_id " & Environment.NewLine
                strSql &= "WHERE Cust_ID = " & iCustID & " AND A.ClaimNo like '%" & strClaimNo.Trim & "%'"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************
        Public Function GetDevicesInWorkorder(ByVal iWOID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT A.Device_ID, A.Device_SN, A.Device_PSSWrty, A.Device_DateRec, A.Device_DateShip, A.Device_Laborcharge, A.Device_PartCharge " & Environment.NewLine
                strSql &= ", B.WorkStation, C.Pallett_Name, D.AV_Desc, E.user_fullname " & Environment.NewLine
                strSql &= "FROM tdevice A INNER JOIN tcellopt B ON A.Device_ID = B.Device_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tpallett C ON A.Pallett_ID = C.Pallett_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lapprovedvalue D ON B.PSS_Wrty_AV_ID = D.AV_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN security.tusers E ON B.PSS_Wrty_Approval_User_ID = E.user_id " & Environment.NewLine
                strSql &= "WHERE A.WO_ID = " & iWOID
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************************
        Public Function HasExceptionRepairs(ByVal iDeviceID As Integer) As Boolean
            Dim strSql As String = ""

            Try
                strSql = "SELECT Count(*) as cnt " & Environment.NewLine
                strSql &= "FROM tdevicebill INNER JOIN lbillcodes ON tdevicebill.Billcode_ID = lbillcodes.Billcode_ID " & Environment.NewLine
                strSql &= "WHERE tdevicebill.Device_ID = " & iDeviceID & " AND Billcode_Desc IN ( 'Exception Repairs', 'Exception Repairs Quote Rejected' ) "
                If Me._objDataProc.GetIntValue(strSql) > 0 Then Return True Else Return False
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '***********************************************************************************************************************

#End Region

    End Class
End Namespace