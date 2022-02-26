Imports eInfoDesigns.dbProvider.MySqlClient
Imports PSS.Data.Production
Imports System.Windows.Forms

Namespace Buisness
    Public Class NewTech
        Private _objMisc As Production.Misc

        Public Sub New()
            Me._objMisc = New Production.Misc()
        End Sub

        '***********************************************************************
        Public Function GetGroupID(ByVal strHostname As String) As Integer
            Dim strSQL As String
            Dim dt As DataTable
            Dim iGroupID As Integer = 0

            Try
                strSQL = "SELECT tgrouplinemap.Group_ID " & Environment.NewLine
                strSQL &= "FROM lwclocation " & Environment.NewLine
                strSQL &= "INNER JOIN tgrouplinemap ON lwclocation.GrpLineMap_ID = tgrouplinemap.GrpLineMap_ID" & Environment.NewLine
                strSQL &= " WHERE lwclocation.WC_Machine = '" & strHostname & "'"

                dt = Me._objMisc.GetDataTable(strSQL)

                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0)("Group_ID")) Then iGroupID = dt.Rows(0)("Group_ID")
                End If

                Return iGroupID
            Catch ex As Exception
                Me._objMisc.DisplayMessage(ex.Message)
            Finally
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Function

        '***********************************************************************
        Public Function GetCellOptAndTechData(ByVal iDeviceID As Integer) As DataRow
            Dim strSQL As String

            Try
                strSQL = "SELECT tcellopt.*, User_Fullname, IF(WIL_SDESC is null, '', WIL_SDESC) as WIL_SDESC " & Environment.NewLine
                strSQL &= "FROM tcellopt " & Environment.NewLine
                strSQL &= "LEFT OUTER JOIN security.tusers U ON tcellopt.CellOpt_TechAssigned = U.User_ID " & Environment.NewLine
                strSQL &= "LEFT OUTER JOIN wipsublocmap ON tcellopt.WIL_ID = wipsublocmap.WIL_ID " & Environment.NewLine
                strSQL &= "WHERE tcellopt.Device_ID = " & iDeviceID & " " & Environment.NewLine

                Return Me._objMisc.GetDataRow(strSQL)
            Catch ex As Exception
                Me._objMisc.DisplayMessage(ex.Message)
            End Try
        End Function

        '***********************************************************************
        Public Function GetPartTransactionSummary(ByVal strMachineName As String, ByVal strPartNum As String) As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT * FROM tparttranssummary " & Environment.NewLine
                strSQL &= "WHERE tpts_Machine = '" & strMachineName & "' " & Environment.NewLine
                strSQL &= "AND tpts_ItemNo = '" & strPartNum & "'"

                Return Me._objMisc.GetDataTable(strSQL)
            Catch ex As Exception
                Me._objMisc.DisplayMessage(ex.Message)
            End Try
        End Function

        '***********************************************************************
        Public Sub UpdatePartTransactionSummarySetFlag(ByVal strMachineName As String, ByVal strPartNum As String)
            Dim strSQL As String

            Try
                strSQL = "UPDATE tparttranssummary " & Environment.NewLine
                strSQL &= "SET tpts_Flag = 1 " & Environment.NewLine
                strSQL &= "WHERE tpts_Machine = '" & strMachineName & "' " & Environment.NewLine
                strSQL &= "AND tpts_ItemNo = '" & strPartNum & "'"

                Me._objMisc.ExecuteNonQuery(strSQL)
            Catch ex As Exception
                Me._objMisc.DisplayMessage(ex.Message)
            End Try
        End Sub

        '***********************************************************************
        Public Function GetDevicesInTrayData(ByVal strTrayID As String) As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT * " & Environment.NewLine
                strSQL &= "FROM tdevice " & Environment.NewLine
                strSQL &= "WHERE tray_id = " & strTrayID & " "

                Return Me._objMisc.GetDataTable(strSQL)
            Catch ex As Exception
                Me._objMisc.DisplayMessage(ex.Message)
            End Try
        End Function

        '***********************************************************************
        Public Function InsertBillCodeData(ByVal iBillID As Integer, ByVal iDCodeID As Integer) As Boolean
            Dim strSQL As String

            Try
                strSQL = "INSERT INTO tpartscodes(DBill_ID, DCode_ID) " & Environment.NewLine
                strSQL &= "VALUES( " & iBillID.ToString & ", " & iDCodeID.ToString & ")"

                If Me._objMisc.ExecuteNonQuery(strSQL) = 0 Then
                    Return False
                Else
                    Return True
                End If
            Catch ex As Exception
                Me._objMisc.DisplayMessage(ex.Message)
            End Try
        End Function

        '***********************************************************************
        Public Function DeleteBillCellData(ByVal iBillID As Integer) As Boolean
            Dim strSQL As String

            Try
                strSQL = "DELETE FROM tbillcell " & Environment.NewLine
                strSQL &= "WHERE DBill_ID = " & iBillID.ToString

                If Me._objMisc.ExecuteNonQuery(strSQL) = 0 Then
                    Return False
                Else
                    Return True
                End If
            Catch ex As Exception
                Me._objMisc.DisplayMessage(ex.Message)
            End Try
        End Function

        '***********************************************************************
        Public Function InsertBillCellData(ByVal iSQLIndex As Integer, ByVal iRefDSNum As Integer, ByVal iBillID As Integer, Optional ByVal iMapID As Integer = Nothing) As Boolean
            Dim strSQL As String

            Try
                Select Case iSQLIndex
                    Case 1
                        strSQL = "INSERT INTO tbillcell (BCell_RefDSNum, DBill_ID, BMap_ID) " & Environment.NewLine
                        strSQL &= "VALUES (" & iRefDSNum.ToString & ", " & iBillID.ToString & ", " & iMapID.ToString & ")"

                    Case 2
                        strSQL = "INSERT INTO tbillcell (BCell_RefDSNum, DBill_ID, MMap_ID) " & Environment.NewLine
                        strSQL &= "VALUES (" & iRefDSNum.ToString & ", " & iBillID.ToString & ", " & iMapID.ToString & ")"

                    Case 3
                        strSQL = "INSERT INTO tbillcell (BCell_RefDSNum, DBill_ID) " & Environment.NewLine
                        strSQL &= "VALUES (" & iRefDSNum.ToString & ", " & iBillID.ToString & ")"
                End Select

                If Me._objMisc.ExecuteNonQuery(strSQL) = 0 Then
                    Return False
                Else
                    Return True
                End If
            Catch ex As Exception
                Me._objMisc.DisplayMessage(ex.Message)
            End Try
        End Function

        '***********************************************************************
        Public Function GetScrapParts(ByVal iDeviceID As Integer) As DataTable
            Dim strSQL As String
            Try
                strSQL = "SELECT * FROM tscrap WHERE Device_ID = " & iDeviceID & Environment.NewLine
                Return Me._objMisc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************
        Public Function DeletePartsCodeData(ByVal iBillID As Integer) As Boolean
            Dim strSQL As String

            Try
                strSQL = "DELETE FROM tpartscodes " & Environment.NewLine
                strSQL &= "WHERE DBill_ID = " & iBillID.ToString

                If Me._objMisc.ExecuteNonQuery(strSQL) = 0 Then
                    Return False
                Else
                    Return True
                End If
            Catch ex As Exception
                Me._objMisc.DisplayMessage(ex.Message)
            End Try
        End Function

        '***********************************************************************
        Public Function GetDataTableByDeviceBillCode(ByVal iDeviceID As Integer, ByVal iBillCodeID As Integer) As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT * " & Environment.NewLine
                strSQL &= "FROM tdevicebill " & Environment.NewLine
                strSQL &= "WHERE device_Id = " & iDeviceID.ToString & " " & Environment.NewLine
                strSQL &= "AND billcode_ID = " & iBillCodeID.ToString

                Return Me._objMisc.GetDataTable(strSQL)
            Catch ex As Exception
                Me._objMisc.DisplayMessage(ex.Message)
            End Try
        End Function

        '***********************************************************************
        Public Function GetMachineCount(ByVal strMachineName As String) As Integer
            Dim strSQL As String

            Try
                strSQL = "SELECT COUNT(*) " & Environment.NewLine
                strSQL &= "FROM lwclocation " & Environment.NewLine
                strSQL &= "WHERE wc_machine = '" & strMachineName & "'"

                Return Me._objMisc.GetIntValue(strSQL)
            Catch ex As Exception
                Me._objMisc.DisplayMessage(ex.Message)
            End Try
        End Function

        '***********************************************************************
        Public Function GetMachineGroupID(ByVal strMachineName As String) As Long
            Dim strSQL As String

            Try
                strSQL = "SELECT tgrouplinemap.Group_ID " & Environment.NewLine
                strSQL &= "FROM lwclocation " & Environment.NewLine
                strSQL &= "INNER JOIN tgrouplinemap ON lwclocation.GrpLineMap_ID = tgrouplinemap.GrpLineMap_ID " & Environment.NewLine
                strSQL &= "WHERE lwclocation.WC_Machine = '" & strMachineName & "'"

                Return Me._objMisc.GetLongValue(strSQL)
            Catch ex As Exception
                Me._objMisc.DisplayMessage(ex.Message)
            End Try
        End Function

        '***********************************************************************
        Public Function GetDeviceGroupID(ByVal iDeviceID As Integer) As Long
            Dim strSQL As String

            Try
                strSQL = "SELECT tworkorder.Group_ID " & Environment.NewLine
                strSQL &= "FROM tdevice " & Environment.NewLine
                strSQL &= "INNER JOIN tworkorder ON tdevice.wo_id = tworkorder.wo_id " & Environment.NewLine
                strSQL &= "WHERE tdevice.device_id = " & iDeviceID.ToString

                Return Me._objMisc.GetLongValue(strSQL)
            Catch ex As Exception
                Me._objMisc.DisplayMessage(ex.Message)
            End Try
        End Function

        '***********************************************************************
        Public Function GetWIPOwnerID(ByVal iDeviceID As Integer) As Long
            Dim strSQL As String

            Try
                strSQL = "SELECT tcellopt.cellopt_WIPOwner " & Environment.NewLine
                strSQL &= "FROM tdevice " & Environment.NewLine
                strSQL &= "INNER JOIN tcellopt ON tdevice.device_id = tcellopt.device_id " & Environment.NewLine
                strSQL &= "WHERE tdevice.device_id = " & iDeviceID.ToString

                Return Me._objMisc.GetLongValue(strSQL)
            Catch ex As Exception
                Me._objMisc.DisplayMessage(ex.Message)
            End Try
        End Function

        '***********************************************************************
        Public Function GetPreBillData(ByVal iDevice_ID As Integer) As DataRow
            Dim strSQL As String

            Try
                strSQL = "SELECT * " & Environment.NewLine
                strSQL &= "FROM tprebilllotdata " & Environment.NewLine
                strSQL &= "WHERE Device_ID = " & iDevice_ID.ToString & ";"

                Me._objMisc._SQL = strSQL
                Return Me._objMisc.GetDataRow()
            Catch ex As Exception
                Me._objMisc.DisplayMessage(ex.Message)
            End Try
        End Function

        '***********************************************************************
        Public Function IsDevHasPart(ByVal iDevice_ID As Integer) As Integer
            Dim strSQL As String
            Dim iCntPartNum As Integer = 0

            Try
                strSQL = "SELECT count(*) as Cnt  " & Environment.NewLine
                strSQL &= "FROM tdevicebill " & Environment.NewLine
                strSQL &= "INNER JOIN lbillcodes ON tdevicebill.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                strSQL &= "WHERE tdevicebill.Device_ID = " & iDevice_ID.ToString & Environment.NewLine
                strSQL &= "AND lbillcodes.BillType_ID = 2;"

                Me._objMisc._SQL = strSQL
                iCntPartNum = Me._objMisc.GetIntValue(strSQL)

                Return iCntPartNum
            Catch ex As Exception
                Me._objMisc.DisplayMessage(ex.Message)
            End Try
        End Function

        '***********************************************************************
        Public Function IsPreBillOpenForToday(ByVal strWorkDt As String) As Boolean
            Dim strSQL As String
            Dim iCnt As Integer = 0

            Try
                strSQL = "SELECT count(*) as Cnt  " & Environment.NewLine
                strSQL &= "FROM tprebilllotdata " & Environment.NewLine
                strSQL &= "WHERE PreBillLot_CreationDate = '" & strWorkDt & "';"

                Me._objMisc._SQL = strSQL
                iCnt = Me._objMisc.GetIntValue(strSQL)
                If iCnt > 0 Then
                    Return False
                Else
                    Return True
                End If
            Catch ex As Exception
                Me._objMisc.DisplayMessage(ex.Message)
            End Try
        End Function

        '***********************************************************************
        Public Function UpdateLockCode(ByVal iDeviceID As Integer) As Integer
            Dim strSql As String
            Dim dt1 As DataTable
            Dim strDeviceID As String = ""
            Dim strUnlockCode As String = ""
            Dim i As Integer = 0

            Try
                strSql = "Select * from tdyscerndata  where device_id = " & iDeviceID & ";"
                Me._objMisc._SQL = strSql
                dt1 = Me._objMisc.GetDataTable
                If dt1.Rows.Count > 0 Then
                    If Not IsDBNull(dt1.Rows(0)("dd_CustDeviceID")) Then
                        strDeviceID = dt1.Rows(0)("dd_CustDeviceID")
                    End If
                    If Not IsDBNull(dt1.Rows(0)("dd_UnlockCode")) Then
                        strUnlockCode = dt1.Rows(0)("dd_UnlockCode")
                    End If

                    If strDeviceID.Trim <> "" And strUnlockCode.Trim <> "" Then
                        Return 1
                    End If
                End If

                While strDeviceID = "" Or strUnlockCode = ""
                    If strDeviceID = "" Then
                        strDeviceID = InputBox("Enter Device ID:", "DeviceID", ).Trim
                    End If

                    If strUnlockCode = "" Then
                        strUnlockCode = InputBox("Enter Unlock Code:", "UnlockCode", ).Trim
                    End If

                    If strDeviceID <> "" And Not IsNumeric(strDeviceID) Then
                        strDeviceID = ""
                        MessageBox.Show("Invalid Device ID. Please re-enter.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If
                End While

                If strUnlockCode = 0.ToString Then strUnlockCode = ""

                If dt1.Rows.Count > 0 Then
                    strSql = "Update tdyscerndata " & Environment.NewLine
                    strSql &= "set dd_CustDeviceID = '" & strDeviceID & "' " & Environment.NewLine
                    strSql &= ", dd_UnlockCode = '" & strUnlockCode & "' " & Environment.NewLine
                    strSql &= "where dd_id = " & dt1.Rows(0)("dd_id")
                Else
                    strSql = "INSERT INTO tdyscerndata ( " & Environment.NewLine
                    strSql &= "dd_CustDeviceID,  dd_UnlockCode, Device_ID ) " & Environment.NewLine
                    strSql &= ") VALUES ( " & Environment.NewLine
                    strSql &= "'" & strDeviceID & "' " & Environment.NewLine
                    strSql &= ", '" & strUnlockCode & "' " & Environment.NewLine
                    strSql &= ", " & iDeviceID & "); " & Environment.NewLine
                End If

                Me._objMisc._SQL = strSql
                i = Me._objMisc.ExecuteNonQuery

                Return i
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Get Lock Code", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '***********************************************************************
        Public Function GetModelUnlockCode(ByVal iModel_ID As Integer) As Integer
            Dim strSql As String
            Dim dt1 As DataTable

            Try
                strSql = "Select Model_UnlockCode from tmodel where Model_ID = " & iModel_ID & ";"
                Return Me._objMisc.GetIntValue(strSql)

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Get Lock Code", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '***********************************************************************
		Public Function UpdateWipOwnerID(ByVal iDevice_ID As Integer, _
		   ByVal iProd_ID As Integer, _
		   ByVal iUserID As Integer, _
		   ByVal iWipOwnerOld As Integer, _
		   Optional ByVal booUpdateTechData As Boolean = True, _
		   Optional ByVal IsMsgDBRorNER As Boolean = False, _
		 Optional ByVal device_activity_msg As String = "New Tech UpdateWIPOwnerID") As Integer
			Dim strSql As String = ""
			Dim dt1 As DataTable
			Dim i As Integer = 0
			Dim iWipOwner As Integer = 0

			Try
				strSql = "SELECT DISTINCT BillCode_Rule FROM tdevicebill " & Environment.NewLine
				strSql &= "INNER JOIN lbillcodes ON tdevicebill.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
				strSql &= "WHERE tdevicebill.Device_ID = " & iDevice_ID.ToString & Environment.NewLine
				strSql &= "ORDER BY BillCode_Rule "
				dt1 = Me._objMisc.GetDataTable(strSql)

				If IsMsgDBRorNER Then
					' SET TO READY TO SHIP FOR MESSAGING DBR AND NER.
					iWipOwner = 5
				ElseIf dt1.Rows.Count = 0 Then
					iWipOwner = 3
				ElseIf CInt(dt1.Rows(0)("BillCode_Rule").ToString.Trim) > 1 Or CInt(dt1.Rows(0)("BillCode_Rule").ToString.Trim) = 2 Or CInt(dt1.Rows(0)("BillCode_Rule").ToString.Trim) = 8 Or CInt(dt1.Rows(0)("BillCode_Rule").ToString.Trim) = 9 Then
					iWipOwner = 4
				Else
					iWipOwner = 3
				End If

				If iProd_ID = 1 Then
					strSql = "UPDATE tmessdata SET wipowner_id_Old =  wipowner_id " & Environment.NewLine
					strSql &= ", wipowner_id = " & iWipOwner.ToString & Environment.NewLine
					strSql &= ", wipowner_EntryDt = now() " & Environment.NewLine
					strSql &= "WHERE device_id = " & iDevice_ID & ";"
					i = Me._objMisc.ExecuteNonQuery(strSql)

					' INSERT THE JOURNAL ENTRY.
					BLL.MsgDeviceMovement.DeviceMovementJornalInsert(iDevice_ID, 1, iWipOwner, 0, device_activity_msg)

				ElseIf iProd_ID = 9 And iWipOwnerOld = 6 Then
					'don't update wipwoner
				Else
					strSql = "UPDATE tcellopt SET cellopt_WipOwnerOld =  CellOpt_WIPOwner " & Environment.NewLine
					strSql &= ", CellOpt_WIPOwner = " & iWipOwner.ToString & Environment.NewLine
					strSql &= ", cellopt_WipEntryDt = now() " & Environment.NewLine
					If booUpdateTechData = True Then
						strSql &= ", CellOpt_TechAssigned = " & iUserID & Environment.NewLine
						strSql &= ", cellopt_techassigndate = now() " & Environment.NewLine
					End If
					strSql &= "WHERE device_id = " & iDevice_ID & ";"
					i = Me._objMisc.ExecuteNonQuery(strSql)
				End If

				'Unit come from hold bucket then reset costcenter
				If iWipOwnerOld = 6 And iProd_ID <> 9 Then
					strSql = "UPDATE tdevice SET cc_id = " & Generic.GetMachineCostCenterID() & Environment.NewLine
					strSql &= "WHERE device_id = " & iDevice_ID & ";"
					i = Me._objMisc.ExecuteNonQuery(strSql)
				End If

				Return i
			Catch ex As Exception
				Throw ex
			Finally
				If Not IsNothing(dt1) Then
					dt1.Dispose()
					dt1 = Nothing
				End If
			End Try
		End Function

		'***********************************************************************
		Public Function GetBillingSelectionInformation(ByVal iDeviceID As Integer, _
		  ByVal iCustID As Integer, _
		  Optional ByVal iPartOnly As Boolean = False) As DataTable
			Dim strSql As String = ""
			Dim dt As DataTable
			Dim R1 As DataRow
			Dim i As Integer = 0

			Try
				strSql = "SELECT 0 as 'Seq', '' as 'Complain Description' " & Environment.NewLine
				strSql &= ", '' as 'Main Category', B.Fail_SDesc as 'Fail Code', '' as FailDetails, '' as 'Fail At' " & Environment.NewLine
				strSql &= ", IF( B.Fail_LDesc is null, '', B.Fail_LDesc) as 'Fail Description' " & Environment.NewLine
				strSql &= ", F.user_fullname AS 'Failed Inspector' " & Environment.NewLine
				strSql &= ", IF( C.Repair_SDesc is null, '', C.Repair_SDesc) as 'Repair Code' " & Environment.NewLine
				strSql &= ", IF( C.Repair_LDesc is null, '', C.Repair_LDesc) as 'Repair Description' " & Environment.NewLine
				strSql &= ", D.Billcode_Desc as 'Part Desc' " & Environment.NewLine
				strSql &= ", IF( A.Part_Number is null, '',  A.Part_Number) as 'Part Number' " & Environment.NewLine
				strSql &= ", '' as 'Part SN', '' as 'Part IMEI',F.user_fullname as 'Tech', '' as Completed, '' as 'Completed Tech', '' as 'Completed Date' " & Environment.NewLine
				strSql &= ", A.Fail_ID, A.Repair_ID, A.Device_ID, 0 as RI_ID, A.Billcode_ID, 0 as PSPrice_ID, 0 as 'MC_ID' " & Environment.NewLine
				strSql &= "FROM tdevicebill A " & Environment.NewLine
				strSql &= "LEFT OUTER JOIN lfailcodes B ON A.Fail_ID = B.Fail_ID " & Environment.NewLine
				strSql &= "LEFT OUTER JOIN lrepaircodes C ON A.Repair_ID = C.Repair_ID " & Environment.NewLine
				strSql &= "LEFT OUTER JOIN lbillcodes D ON A.Billcode_ID = D.Billcode_ID " & Environment.NewLine
				strSql &= "LEFT OUTER JOIN lcomplaint E ON A.Comp_ID = E.Comp_ID " & Environment.NewLine
				strSql &= "LEFT OUTER JOIN security.tusers F ON A.User_ID = F.user_id " & Environment.NewLine
				strSql &= "WHERE A.Device_ID = " & iDeviceID & Environment.NewLine
				If iPartOnly = True Then strSql &= "AND D.BillType_ID = 2 " & Environment.NewLine
				strSql &= "ORDER BY A.DBill_ID DESC " & Environment.NewLine

				Me._objMisc._SQL = strSql
				dt = Me._objMisc.GetDataTable()

				Return dt
			Catch ex As Exception
				Throw ex
			Finally
				R1 = Nothing
				Generic.DisposeDT(dt)
			End Try
		End Function

		'***********************************************************************
		Public Function GetDeviceInfo(ByVal iDeviceID As Integer) As DataTable
			Dim strSql As String = ""

			Try
				strSql = "SELECT tdevice.*, tmodel.Prod_ID, tmodel.Manuf_ID, tmodel.Model_Desc, tmodel.ManufModelNumber" & Environment.NewLine
				strSql &= ", tcustomer.cust_id, tcustomer.cust_specialcodes, tcustomer.cust_CrBilling, tcustomer.cust_consignedparts " & Environment.NewLine
				strSql &= ", tcustomer.Cust_Name1, tcustomer.TechFailureCode " & Environment.NewLine
				strSql &= ", if(Manuf_Date is null, '', Manuf_Date) Manuf_Date, edi.titem.LastDateInWrty " & Environment.NewLine
				strSql &= "FROM tdevice " & Environment.NewLine
				strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
				strSql &= "INNER JOIN tlocation ON tdevice.loc_id = tlocation.loc_id " & Environment.NewLine
				strSql &= "INNER JOIN tcustomer ON tlocation.cust_id = tcustomer.cust_id" & Environment.NewLine
				strSql &= "LEFT OUTER JOIN edi.titem ON tdevice.Device_ID = edi.titem.Device_ID " & Environment.NewLine
				strSql &= "WHERE tdevice.Device_ID = " & iDeviceID & Environment.NewLine

				Me._objMisc._SQL = strSql
				Return Me._objMisc.GetDataTable()

			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'***********************************************************************
		Public Function GetMessData(ByVal iDeviceID As Integer) As DataRow
			Dim strSql As String = ""

			Try
				strSql = "SELECT *  " & Environment.NewLine
				strSql &= "FROM tmessdata " & Environment.NewLine
				strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
				Me._objMisc._SQL = strSql
				Return Me._objMisc.GetDataRow()

			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'***********************************************************************
		Public Function GetDeviceInWip(ByVal strDeviceSN As String, _
		 Optional ByVal iCustID As Integer = 0) As DataTable
			Dim strSql As String = ""

			Try
				strSql = "SELECT tdevice.*  " & Environment.NewLine
				strSql &= "FROM tdevice " & Environment.NewLine
				If iCustID > 0 Then strSql &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
				strSql &= "WHERE Device_SN = '" & strDeviceSN.Trim & "'" & Environment.NewLine
				strSql &= "AND Device_DateShip is null AND pallett_id is null " & Environment.NewLine
				If iCustID > 0 Then strSql &= "AND tlocation.Cust_ID = " & iCustID

				Me._objMisc._SQL = strSql
				Return Me._objMisc.GetDataTable()
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'***********************************************************************
		Public Function SendUnitToHold(ByVal iDeviceID As Integer, ByVal iProdID As Integer) As Integer
			Dim strSql As String = ""

			Try
				If iProdID = 1 Then
					strSql = "UPDATE tmessdata " & Environment.NewLine
					strSql &= "SET tmessdata.wipowner_id_Old = tmessdata.wipowner_id, tmessdata.wipowner_id = 6, tmessdata.wipowner_EntryDt = now() " & Environment.NewLine
					strSql &= "WHERE Device_ID = " & iDeviceID & " " & Environment.NewLine
				ElseIf iProdID = 9 Then				'DriveCam
					strSql = "UPDATE tcellopt, tdrivecamdata " & Environment.NewLine
					strSql &= "SET tcellopt.Cellopt_WIPOwnerOld = tcellopt.Cellopt_WIPOwner, tcellopt.Cellopt_WIPOwner = 6, tcellopt.Cellopt_WIPEntryDt = now() " & Environment.NewLine
					strSql &= ", OnHoldDate = now() " & Environment.NewLine
					strSql &= "WHERE tcellopt.Device_ID = tdrivecamdata.Device_ID and tcellopt.Device_ID = " & iDeviceID & " " & Environment.NewLine
				Else
					strSql = "UPDATE tcellopt " & Environment.NewLine
					strSql &= "SET tcellopt.Cellopt_WIPOwnerOld = tcellopt.Cellopt_WIPOwner, tcellopt.Cellopt_WIPOwner = 6, tcellopt.Cellopt_WIPEntryDt = now() " & Environment.NewLine
					strSql &= "WHERE Device_ID = " & iDeviceID & " " & Environment.NewLine
				End If

				Me._objMisc._SQL = strSql
				Return Me._objMisc.ExecuteNonQuery()

			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'***********************************************************************
		Public Function ScrapDriveCamUnit(ByVal iDeviceID As Integer, _
		 ByVal iShiftID As Integer) As Integer
			Dim strSql As String = ""

			Try
				strSql = "UPDATE tdevice, tcellopt " & Environment.NewLine
				strSql &= "SET " & Environment.NewLine
				strSql &= " Shift_ID_Ship = " & iShiftID & " " & Environment.NewLine
				strSql &= ", Device_SendClaim = 0 " & Environment.NewLine
				strSql &= ", Device_DateShip = now() " & Environment.NewLine
				strSql &= ", Device_ShipWorkDate = '" & Generic.GetWorkDate(iShiftID) & "' " & Environment.NewLine
				strSql &= ", Device_FinishedGoods = 0 " & " " & Environment.NewLine
				strSql &= ", Pallett_ID = " & DriveCam.RUR_SCRAP_PALLETID & Environment.NewLine
				strSql &= ", Device_LaborLevel = 0 " & Environment.NewLine
				strSql &= ", Device_LaborCharge = 0.00 " & Environment.NewLine
				strSql &= ", Cellopt_WIPOwnerOld = Cellopt_WIPOwner " & Environment.NewLine
				strSql &= ", Cellopt_WIPOwner = 7 " & " " & Environment.NewLine				 ' Ready Toship
				strSql &= ", Cellopt_WIPEntryDt  = now() " & Environment.NewLine
				strSql &= "WHERE tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
				strSql &= "AND tdevice.Device_ID = " & iDeviceID & " " & Environment.NewLine
				Me._objMisc._SQL = strSql
				Return Me._objMisc.ExecuteNonQuery()

			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'***********************************************************************
		Public Function GetDrivecamCFAppStatus(ByVal iDeviceID As Integer) As DataTable
			Dim strSql As String = ""

			Try
				strSql = "SELECT CompactFlashApproved, ReleaseFrHoldDate " & Environment.NewLine
				strSql &= "FROM tdrivecamdata " & Environment.NewLine
				strSql &= "WHERE tdrivecamdata.Device_ID = " & iDeviceID & " " & Environment.NewLine
				Me._objMisc._SQL = strSql
				Return Me._objMisc.GetDataTable()

			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'***********************************************************************
		Public Function IsCFApproved(ByVal iDeviceID As Integer) As Boolean
			Dim dt As DataTable

			Try
				dt = Me.GetDrivecamCFAppStatus(iDeviceID)
				If dt.Rows.Count > 0 AndAlso Not IsDBNull(dt.Rows(0)("ReleaseFrHoldDate")) And dt.Rows(0)("CompactFlashApproved") = 1 Then
					Return True
				Else
					Return False
				End If
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		''***********************************************************************
		'Public Function GetPSSNavPartBenchShelf(ByVal iModelID As Integer) As DataTable
		'    Dim strSql As String = ""
		'    Try
		'        strSql = "select tpsmap.billcode_id as BillCode, lpsprice.psprice_number as PartNumber, lpsprice.PSPrice_MaxQty from " & _
		'                                "tpsmap inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
		'                                "inner join tnav_item on lpsprice.psprice_number = tnav_item.No_ " & _
		'                                "where(tpsmap.model_id = " & iModelID & ") " & _
		'                                "and tnav_item.shelf_no_ = 'BENCH'"
		'        Me._objMisc._SQL = strSql
		'        Return Me._objMisc.GetDataTable()
		'    Catch ex As Exception
		'        Throw ex
		'    End Try
		'End Function

		'***********************************************************************
		Public Function GetWCActiveConsume() As Integer
			Dim strSql As String = ""
			Dim dt As DataTable

			Try
				strSql = "SELECT * FROM lwclocation WHERE WC_Machine = '" & System.Net.Dns.GetHostName & "'"
				Me._objMisc._SQL = strSql
				dt = Me._objMisc.GetDataTable()
				If dt.Rows.Count = 0 Then
					Return 0
				Else
					Return dt.Rows(0)("WC_ActiveConsume")
				End If

			Catch ex As Exception
				Throw ex
			Finally
				Generic.DisposeDT(dt)
			End Try
		End Function

		'***********************************************************************
		Public Function GetLatestRFTestResult(ByVal iDeviceID As Integer) As String
			Dim strSql As String = ""
			Dim dt As DataTable

			Try
				strSql = "SELECT concat(Test_desc, ' ', qcResult, if (ttestdata.QCResult_ID = 2, Concat(': ', Fail_SDesc, '-', Fail_LDesc), '')) as 'Result' " & Environment.NewLine
				strSql &= "FROM ttestdata " & Environment.NewLine
				strSql &= "INNER JOIN ltesttype ON ttestdata.Test_ID = ltesttype.Test_ID " & Environment.NewLine
				strSql &= "INNER JOIN lqcresult ON ttestdata.QCResult_ID = lqcresult.QCResult_ID " & Environment.NewLine
				strSql &= "LEFT OUTER JOIN lfailcodes on ttestdata.Fail_ID = lfailcodes.Fail_ID " & Environment.NewLine
				strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
				strSql &= "AND ltesttype.Test_Desc like 'RF%' " & Environment.NewLine
				strSql &= "ORDER BY ttestdata.td_id desc " & Environment.NewLine
				strSql &= "limit 1; " & Environment.NewLine
				Me._objMisc._SQL = strSql
				dt = Me._objMisc.GetDataTable()
				If dt.Rows.Count = 0 Then
					Return ""
				Else
					Return dt.Rows(0)("Result")
				End If

			Catch ex As Exception
				Throw ex
			Finally
				Generic.DisposeDT(dt)
			End Try
		End Function

		'***********************************************************************
		Public Function GetLatestQCTestResult(ByVal iDeviceID As Integer) As String
			Dim strSql As String = ""
			Dim dt As DataTable

			Try
				strSql = "SELECT concat(qctype, ' ', qcResult, if (tqc.QCResult_ID = 2, Concat(': ', Dcode_Sdesc, '-', Dcode_LDesc), '')) as 'Result' " & Environment.NewLine
				strSql &= "FROM tqc " & Environment.NewLine
				strSql &= "INNER JOIN lqctype ON tqc.qctype_id = lqctype.qctype_id " & Environment.NewLine
				strSql &= "INNER JOIN lqcresult ON tqc.QCResult_ID = lqcresult.QCResult_ID " & Environment.NewLine
				strSql &= "LEFT OUTER JOIN lcodesdetail on tqc.Dcode_ID = lcodesdetail.DCode_ID " & Environment.NewLine
				strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
				strSql &= "ORDER BY tqc.qc_id desc " & Environment.NewLine
				strSql &= "limit 1; " & Environment.NewLine
				Me._objMisc._SQL = strSql
				dt = Me._objMisc.GetDataTable()
				If dt.Rows.Count = 0 Then
					Return ""
				Else
					Return dt.Rows(0)("Result")
				End If

			Catch ex As Exception
				Throw ex
			Finally
				Generic.DisposeDT(dt)
			End Try
		End Function

		'***********************************************************************
		Public Function IsUnitCompletedRepair(ByVal iDeviceID As Integer) As Boolean
			Dim strSql As String = ""
			Dim dt As DataTable

			Try
				strSql = "SELECT * " & Environment.NewLine
				strSql &= "FROM ttestdata " & Environment.NewLine
				strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
				strSql &= "AND Test_ID  in ( 7, 13 ) " & Environment.NewLine
				strSql &= "ORDER BY TD_ID desc " & Environment.NewLine
				strSql &= "limit 1; " & Environment.NewLine
				Me._objMisc._SQL = strSql
				dt = Me._objMisc.GetDataTable()
				If dt.Rows.Count = 0 Then
					Return False
				ElseIf CInt(dt.Rows(0)("Test_ID")) = 7 Then
					Return True
				Else
					Return False
				End If

			Catch ex As Exception
				Throw ex
			Finally
				Generic.DisposeDT(dt)
			End Try
		End Function

		'***********************************************************************
		Public Function GetMachineMapLineID() As Integer
			Dim strSql As String = ""
			Dim dt As DataTable

			Try
				strSql = "SELECT Line_ID " & Environment.NewLine
				strSql &= "FROM lwclocation " & Environment.NewLine
				strSql &= "INNER JOIN tgrouplinemap ON lwclocation.GrpLineMap_ID = tgrouplinemap.GrpLineMap_ID " & Environment.NewLine
				strSql &= "WHERE lwclocation.WC_Machine = '" & System.Net.Dns.GetHostName & "'" & Environment.NewLine
				dt = Me._objMisc.GetDataTable(strSql)
				If dt.Rows.Count > 0 Then
					Return dt.Rows(0)("Line_ID")
				Else
					Return 0
				End If
			Catch ex As Exception
				Throw ex
			Finally
				Generic.DisposeDT(dt)
			End Try
		End Function

		'***********************************************************************
		Public Function UpdateRefurbCompletedData(ByVal iDeviceID As Integer, _
		   ByVal iQCReject As Integer, _
		   ByVal iUserID As Integer, _
		   ByVal iCompletedLineID As Integer, _
		   ByVal booUpdateTech As Boolean) As Integer
			Dim strSql As String = ""

			Try
				'//Update the qc result back to normal
				strSql = "UPDATE tcellopt SET CellOpt_QCReject = " & iQCReject & Environment.NewLine
				strSql &= ", CellOpt_RefurbCompleteDt = now() " & Environment.NewLine
				strSql &= ", CellOpt_RefurbCompleteWorkDt = now()" & Environment.NewLine
				strSql &= ", CellOpt_RefurbCompleteUserID = " & iUserID & " " & Environment.NewLine
				strSql &= ", CellOpt_RefurbCompleteLineID = " & iCompletedLineID & " " & Environment.NewLine
				If booUpdateTech = True Then
					strSql &= ", CellOpt_TechAssigned = " & iUserID & ", CellOpt_TechAssignDate = now() " & Environment.NewLine
				End If
				strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine

				Return Me._objMisc.ExecuteNonQuery(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'***********************************************************************
		Public Function GetBillCodesByBillRuleAndModel(ByVal iModelID As Integer, ByVal strBillRule As String) As DataTable
			Dim strSql As String = ""

			Try
				strSql = "SELECT lbillcodes.Billcode_ID, lbillcodes.Billcode_Desc " & Environment.NewLine
				strSql &= "FROM lbillcodes " & Environment.NewLine
				strSql &= "INNER JOIN tpsmap ON lbillcodes.Billcode_ID = tpsmap.Billcode_ID " & Environment.NewLine
				strSql &= "WHERE tpsmap.Model_ID = " & iModelID & Environment.NewLine
				strSql &= "AND lbillcodes.BillCode_Rule in ( " & strBillRule & ") " & Environment.NewLine
				Return Me._objMisc.GetDataTable(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'***********************************************************************
		Public Function GetTFTotalCharge(ByVal iCustID As Integer, ByVal iModelID As Integer, ByVal iManufID As Integer, ByVal iDeviceID As Integer, ByVal iManufWrtyFlag As Integer, _
		   ByVal iNewBillcodeID As Integer, ByVal iNewBillcodeLaborLevel As Integer, ByVal iNewBillcodeFailID As Integer, _
		   ByVal decNewBillcodeStandCost As Decimal, ByVal decCustMarkup As Decimal, ByVal iNewBillcodeType As Integer) As Decimal
			Dim strSql As String = ""
			Dim dtDBill, dtLaborTemplate, dtMaxClaimablePartLevel As DataTable
			Dim R1 As DataRow
			Dim decLaborCharge, decNewBillcodeInvAmt, decPartsFeeMarkUp, decTotalPartInvAmt As Decimal
			Dim iFunRep, iWrtyRep, iLaborLevel As Integer
			Dim objTFBillingData As TracFone.TFBillingData

			Try
				decLaborCharge = 0 : decNewBillcodeInvAmt = 0 : decPartsFeeMarkUp = 0 : decTotalPartInvAmt = 0
				iFunRep = 0 : iWrtyRep = 0 : iLaborLevel = 0
				'***************************************************************** 
				'PARTS 
				'***************************************************************** 
				strSql = "SELECT DBill_InvoiceAmt, tdevicebill.Fail_ID, tpsmap.LaborLevel, lbillcodes.BillType_ID " & Environment.NewLine
				strSql &= "FROM tdevice INNER JOIN tdevicebill ON tdevice.device_ID = tdevicebill.device_ID" & Environment.NewLine
				strSql &= "INNER JOIN tpsmap ON tdevice.Model_ID = tpsmap.Model_ID AND tdevicebill.Billcode_ID = tpsmap.Billcode_ID " & Environment.NewLine
				strSql &= "INNER JOIN lbillcodes ON tdevicebill.Billcode_ID = lbillcodes.Billcode_ID " & Environment.NewLine
				strSql &= "WHERE tdevice.Device_ID = " & iDeviceID
				dtDBill = Me._objMisc.GetDataTable(strSql)

				If iNewBillcodeID > 0 Then
					If decNewBillcodeStandCost = 0 Then
						decNewBillcodeInvAmt = 0.0
					ElseIf iNewBillcodeType = 1 Then					  'Service
						decNewBillcodeInvAmt = decNewBillcodeStandCost
					ElseIf iNewBillcodeType = 2 Then					  'Part
						decNewBillcodeInvAmt = Math.Round((decNewBillcodeStandCost * (decCustMarkup + 1) + 0.00499), 2)
					Else					  'Everything else
						decNewBillcodeInvAmt = Math.Round((decNewBillcodeStandCost * (decCustMarkup + 1) + 0.00499), 2)
					End If

					R1 = dtDBill.NewRow
					R1("DBill_InvoiceAmt") = decNewBillcodeInvAmt : R1("Fail_ID") = iNewBillcodeFailID : R1("LaborLevel") = iNewBillcodeLaborLevel : R1("BillType_ID") = iNewBillcodeType
					dtDBill.Rows.Add(R1) : dtDBill.AcceptChanges()
				End If

				If iManufWrtyFlag > 0 Then
					If Not IsDBNull(dtDBill.Compute("Sum(DBill_InvoiceAmt)", "BillType_ID = 2 AND ( Fail_ID = 0 or Fail_ID = 311) ")) Then
						decTotalPartInvAmt = dtDBill.Compute("Sum(DBill_InvoiceAmt)", "BillType_ID = 2 AND ( Fail_ID = 0 or Fail_ID = 311 ) ")
					End If

					If dtDBill.Select("BillType_ID = 2 AND Fail_ID <> 0 AND Fail_ID <> 311 AND Fail_ID <> 269 AND LaborLevel > 1 ").Length > 0 Then iWrtyRep = 1
				Else
					If Not IsDBNull(dtDBill.Compute("Sum(DBill_InvoiceAmt)", "BillType_ID = 2")) Then
						decTotalPartInvAmt = dtDBill.Compute("Sum(DBill_InvoiceAmt)", "BillType_ID = 2")
					End If
				End If

				If decTotalPartInvAmt > 0 Then decPartsFeeMarkUp = DeviceBilling.GetNonWrtyPartCostMarkUp(iDeviceID, iCustID, iModelID, iManufWrtyFlag, decTotalPartInvAmt)

				If Not IsDBNull(dtDBill.Compute("Max(LaborLevel)", "")) Then iLaborLevel = dtDBill.Compute("Max(LaborLevel)", "")

				'***************************************************************** 
				'LABOR
				'*****************************************************************
				If iWrtyRep = 0 AndAlso iManufWrtyFlag > 0 Then
					objTFBillingData = New TracFone.TFBillingData()
					dtMaxClaimablePartLevel = objTFBillingData.GetMaxClaimablePartsAndReflowTuningLevel(iDeviceID, iManufID)
					'Has no claimable part
					If dtMaxClaimablePartLevel.Rows.Count = 0 OrElse dtMaxClaimablePartLevel.Rows(0)("LaborLevel") < 2 Then
						iWrtyRep = 0
					Else					  'Has claimable parts
						iWrtyRep = 1
					End If
				End If

				strSql = "SELECT FuncRep FROM edi.titem WHERE Device_ID = " & iDeviceID & Environment.NewLine
				iFunRep = Me._objMisc.GetIntValue(strSql)
				strSql = "SELECT * FROM tracfonelabortemplate WHERE Active = 1 " & Environment.NewLine
				dtLaborTemplate = Me._objMisc.GetDataTable(strSql)
				If dtLaborTemplate.Rows.Count = 0 Then
					Throw New Exception("Labor matrix is missing.")
				ElseIf dtLaborTemplate.Select("FUN = " & iFunRep & " AND WrtyRep  = " & iWrtyRep & " AND Level = " & iLaborLevel).Length = 0 Then
					Throw New Exception("Labor matrix is missing for criteia FUN = " & iFunRep & ", Wrty Rep = " & iWrtyRep & ", Labor Level = " & iLaborLevel & ".")
				Else
					decLaborCharge = dtLaborTemplate.Select("FUN = " & iFunRep & " AND WrtyRep  = " & iWrtyRep & " AND Level = " & iLaborLevel)(0)("MaxLaborAmt")
				End If

				'***************************************************************** 
				Return (decLaborCharge + decTotalPartInvAmt + decPartsFeeMarkUp)
			Catch ex As Exception
				Throw ex
			Finally
				objTFBillingData = Nothing : R1 = Nothing
				Generic.DisposeDT(dtDBill) : Generic.DisposeDT(dtLaborTemplate) : Generic.DisposeDT(dtMaxClaimablePartLevel)
			End Try
		End Function

		'***********************************************************************
		Public Function SetPantechApproveToRepairData(ByVal iDeviceID As Integer, ByVal dbTotalPartCost As Double, ByVal iUserID As Integer) As Integer
			Dim strSql As String = ""

			Try
				If dbTotalPartCost > 0 Then
					strSql = "UPDATE pantechasn, tdevice SET ApprovedToRepairDate = null, ApprovedToRepairBy = null, ApprovedToRepair = 0, Device_Invoice = 0 " & Environment.NewLine
					strSql &= "WHERE pantechasn.Device_ID = tdevice.Device_ID AND pantechasn.Device_ID = " & iDeviceID & Environment.NewLine
				Else
					strSql = "UPDATE pantechasn, tdevice SET ApprovedToRepairDate = now(), ApprovedToRepairBy = " & iUserID & ", ApprovedToRepair = 1, Device_Invoice = 1 " & Environment.NewLine
					strSql &= "WHERE pantechasn.Device_ID = tdevice.Device_ID AND pantechasn.Device_ID = " & iDeviceID & Environment.NewLine
				End If
				Return Me._objMisc.ExecuteNonQuery(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'***********************************************************************
		Public Function GetContingentBillcodes(ByVal iBillcodeID As Integer, ByVal iModelID As Integer, ByVal iLocID As Integer) As DataTable
			Dim strSql As String = ""
			Try
				strSql = "SELECT * FROM tcontigentbilling " & Environment.NewLine
				strSql &= "WHERE cbill_Billcode_ID = " & iBillcodeID & Environment.NewLine
				strSql &= "AND cbill_Model_ID = " & iModelID & " And cbill_loc_id = " & iLocID
				Return Me._objMisc.GetDataTable(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'***********************************************************************
		Public Function GetTestResult_Triage(ByVal Device_ID As Integer) As String
			Dim strSql As String = ""
			Dim strResult As String = ""
			Dim dr As DataRow
			Dim dt As DataTable
			Try

				strSql = "SELECT Concat(Dcode_Sdesc, '-', Dcode_LDesc) as Fail, FailOther " & Environment.NewLine
				strSql &= "FROM tpretest_data p" & Environment.NewLine
				strSql &= "Inner Join lcodesdetail l on l.Dcode_id= p.PTtf" & Environment.NewLine
				strSql &= "WHERE Device_ID= " & Device_ID & Environment.NewLine
				Me._objMisc._SQL = strSql
				dt = Me._objMisc.GetDataTable()
				If dt.Rows.Count = 0 Then
					Return ""
				Else
					For Each dr In dt.Rows
						If strResult.Trim.Length > 0 Then strResult &= ", "
						strResult += dr("Fail")
					Next
					strResult &= Environment.NewLine & dt.Rows(0)("FailOther")
					Return strResult
				End If

			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'***********************************************************************
		Public Function GetTestResult_RF1(ByVal Device_ID As Integer) As String
			Dim strSql As String = ""
			Dim strResult As String = ""
			Dim dr As DataRow
			Dim dt As DataTable
			Try
				strSql = "SELECT Concat(Fail_SDesc, '-', Fail_LDesc) as 'Result'" & Environment.NewLine
				strSql &= "FROM ttestdata" & Environment.NewLine
				strSql &= "INNER JOIN ltesttype ON ttestdata.Test_ID = ltesttype.Test_ID" & Environment.NewLine
				strSql &= "INNER JOIN lqcresult ON ttestdata.QCResult_ID = lqcresult.QCResult_ID" & Environment.NewLine
				strSql &= "LEFT OUTER JOIN lfailcodes on ttestdata.Fail_ID = lfailcodes.Fail_ID" & Environment.NewLine
				strSql &= "WHERE Device_ID= " & Device_ID & Environment.NewLine
				strSql &= "AND ltesttype.Test_Desc = 'RF1'" & Environment.NewLine
				strSql &= "ORDER BY ttestdata.td_id desc ;" & Environment.NewLine
				Me._objMisc._SQL = strSql
				dt = Me._objMisc.GetDataTable()
				If dt.Rows.Count = 0 Then
					Return ""
				Else
					For Each dr In dt.Rows
						strResult += dr("Result") + ", "
					Next
					strResult = strResult.Substring(0, Len(strResult) - 2)					  'Remove last comma
					Return strResult
				End If

			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'***********************************************************************
		Public Function GetTestResult_RF2(ByVal Device_ID As Integer) As String

			Dim strSql As String = ""
			Dim strResult As String = ""
			Dim dr As DataRow
			Dim dt As DataTable
			Try
				strSql = "SELECT Concat(Fail_SDesc, '-', Fail_LDesc) as 'Result'" & Environment.NewLine
				strSql &= "FROM ttestdata" & Environment.NewLine
				strSql &= "INNER JOIN ltesttype ON ttestdata.Test_ID = ltesttype.Test_ID" & Environment.NewLine
				strSql &= "INNER JOIN lqcresult ON ttestdata.QCResult_ID = lqcresult.QCResult_ID" & Environment.NewLine
				strSql &= "LEFT OUTER JOIN lfailcodes on ttestdata.Fail_ID = lfailcodes.Fail_ID" & Environment.NewLine
				strSql &= "WHERE Device_ID= " & Device_ID & Environment.NewLine
				strSql &= "AND ltesttype.Test_Desc = 'RF2'" & Environment.NewLine
				strSql &= "ORDER BY ttestdata.td_id desc ;" & Environment.NewLine
				Me._objMisc._SQL = strSql
				dt = Me._objMisc.GetDataTable()
				If dt.Rows.Count = 0 Then
					Return ""
				Else
					For Each dr In dt.Rows
						strResult += dr("Result") + ", "
					Next
					strResult = strResult.Substring(0, Len(strResult) - 2)					  'Remove last comma
					Return strResult
				End If

			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'***********************************************************************
		Public Function GetTestResult_QC(ByVal Device_ID As Integer) As String
			Dim strSql As String = ""
			Dim dt As DataTable

			Try
				strSql = "SELECT case tqc.DCode_ID When 3408 then Concat(Dcode_Sdesc, '-', Dcode_LDesc,' (', QC_OtherFails, ')' ) else Concat(Dcode_Sdesc, '-', Dcode_LDesc) end as 'Result'" & Environment.NewLine
				strSql &= "FROM tqc " & Environment.NewLine
				strSql &= "INNER JOIN lqctype ON tqc.qctype_id = lqctype.qctype_id " & Environment.NewLine
				strSql &= "INNER JOIN lqcresult ON tqc.QCResult_ID = lqcresult.QCResult_ID " & Environment.NewLine
				strSql &= "LEFT OUTER JOIN lcodesdetail on tqc.Dcode_ID = lcodesdetail.DCode_ID " & Environment.NewLine
				strSql &= "WHERE Device_ID = " & Device_ID & Environment.NewLine
				strSql &= "ORDER BY tqc.qc_id desc " & Environment.NewLine
				strSql &= "limit 1; " & Environment.NewLine
				Me._objMisc._SQL = strSql
				dt = Me._objMisc.GetDataTable()
				If dt.Rows.Count = 0 Then
					Return ""
				Else
					Return dt.Rows(0)("Result")
				End If

			Catch ex As Exception
				Throw ex
			Finally
				Generic.DisposeDT(dt)
			End Try
		End Function

		'***********************************************************************
		Public Function GetAccessoryStatus(ByVal booAddSelectRow As Boolean) As DataTable
			Dim strSql As String = ""
			Dim dt As DataTable
			Try
				strSql = "SELECT Dcode_ID, Dcode_LDesc " & Environment.NewLine
				strSql &= "FROM lcodesdetail " & Environment.NewLine
				strSql &= "WHERE Mcode_ID = 49 And Dcode_ID <> 3411 " & Environment.NewLine
				strSql &= ";" & Environment.NewLine
				Me._objMisc._SQL = strSql
				dt = Me._objMisc.GetDataTable()

				If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)
				Return dt
			Catch ex As Exception
				Throw ex
			Finally
				Generic.DisposeDT(dt)
			End Try
		End Function

		'***********************************************************************
		Public Function GetSelectedAWAP(ByVal Device As Integer) As DataTable
			Try

				Dim strSql As String = ""
				strSql = "SELECT BillCode_ID, Part_Number, sum(Trans_Amount) as Trans_Amount " & Environment.NewLine
				strSql &= "FROM tdevicebillAWAP WHERE Device_ID = " & Device & Environment.NewLine
				strSql &= "GROUP BY BillCode_ID, Part_Number HAVING Trans_Amount > 0 "

				Me._objMisc._SQL = strSql
				Return Me._objMisc.GetDataTable()
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'***********************************************************************
		Public Function InsertIntoDeviceBillAWAP(ByVal iDevice As Integer, ByVal dbRegPartprice As Double, _
		 ByVal dbAvgCost As Double, ByVal dbStdCost As Double, _
		 ByVal dbInvAmt As Double, ByVal iBillcodeID As Integer, _
		 ByVal strPartNumber As String, ByVal iTransAmt As Integer, _
		 ByVal iUsrID As Integer, _
		 Optional ByVal iFailID As Integer = 0, _
		 Optional ByVal iRepID As Integer = 0, _
		 Optional ByVal iComplainID As Integer = 0) As Integer
			Dim strSql As String = ""
			Try
				strSql = "INSERT INTO tdevicebillawap ( DBill_RegPartPrice, DBill_AvgCost, DBill_StdCost, DBill_InvoiceAmt " & Environment.NewLine
				strSql &= ", Device_ID, BillCode_ID, Fail_ID, Repair_ID, User_ID, Date_Rec, Part_Number " & Environment.NewLine
				strSql &= ", Comp_ID, Trans_Amount" & Environment.NewLine
				strSql &= " ) VALUES (" & Environment.NewLine
				strSql &= dbRegPartprice & ", '" & dbAvgCost & "','" & dbStdCost & "' " & Environment.NewLine
				strSql &= ", '" & dbInvAmt & "', '" & iDevice & "' " & Environment.NewLine
				strSql &= ", '" & iBillcodeID & "','" & iFailID & "','" & iRepID & "'" & Environment.NewLine
				strSql &= ", '" & iUsrID & "', now(), '" & strPartNumber & "'" & Environment.NewLine
				strSql &= ", " & iComplainID & ", " & iTransAmt & Environment.NewLine
				strSql &= " ) ;"

				Me._objMisc._SQL = strSql
				Return Me._objMisc.ExecuteNonQuery()
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'***********************************************************************
		Public Function DeleteDeviceBillAWAP(ByVal iDeviceID As Integer, ByVal iBillcodeID As Integer, _
		 ByVal iUserID As Integer) As Integer
			Dim strSql As String = ""
			Dim dt As DataTable
			Dim R1 As DataRow
			Try

				strSql = "Select * from tdevicebillawap " & Environment.NewLine
				strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine()
				strSql &= "AND Billcode_ID = " & iBillcodeID & Environment.NewLine
				strSql &= "ORDER BY DBillAWAP_ID DESC LIMIT 1" & Environment.NewLine
				Me._objMisc._SQL = strSql
				dt = Me._objMisc.GetDataTable()

				If dt.Rows.Count = 0 Then
					Return 0
				ElseIf dt.Rows(0)("Trans_Amount") < 0 Then
					Return 0
				Else
					R1 = dt.Rows(0)
					Return Me.InsertIntoDeviceBillAWAP(iDeviceID, R1("DBill_RegPartPrice"), R1("DBill_AvgCost"), _
					R1("DBill_StdCost"), R1("DBill_InvoiceAmt"), R1("Billcode_ID"), R1("Part_Number"), _
					-1, iUserID, R1("Fail_ID"), R1("Repair_ID"), R1("Comp_ID"))
				End If
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'***********************************************************************
		Public Function DeleteDeviceBillAWAP(ByVal iDeviceID As Integer, ByVal iBillcodeID As Integer) As Integer
			Dim strSql As String = ""

			Try
				strSql = "DELETE FROM tdevicebillawap " & Environment.NewLine
				strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine()
				strSql &= "AND Billcode_ID = " & iBillcodeID & Environment.NewLine
				Return Me._objMisc.ExecuteNonQuery(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'***********************************************************************
		Public Function GetBillcodeTypes(ByVal strBillcodeIDList As String) As DataTable
			Dim strSql As String = ""
			Dim dt As DataTable

			Try
				strSql = "Select lbillcodes.*, 0 as Consumed from lbillcodes " & Environment.NewLine
				strSql &= "WHERE Billcode_ID in ( " & strBillcodeIDList & ")" & Environment.NewLine
				strSql &= "ORDER BY BillType_ID " & Environment.NewLine
				Me._objMisc._SQL = strSql
				Return Me._objMisc.GetDataTable()
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'***********************************************************************
		Public Function UpdateManufModel(ByVal iModelID As Integer, ByVal strManufModel As String) As Integer
			Dim strSql As String = ""

			Try
				strSql = "UPDATE tmodel SET ManufModelNumber = '" & strManufModel & "'" & Environment.NewLine
				strSql &= "WHERE Model_ID = " & iModelID & "" & Environment.NewLine
				Me._objMisc._SQL = strSql
				Return Me._objMisc.ExecuteNonQuery()
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'***********************************************************************
		Public Function GetSyxDeviceInfo(ByVal iDeviceID As Integer) As DataTable
			Dim strSql As String = ""

			Try
				strSql = "SELECT * " & Environment.NewLine
				strSql &= "FROM syxdata " & Environment.NewLine
				strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
				Me._objMisc._SQL = strSql
				Return Me._objMisc.GetDataTable()
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'***********************************************************************
		Public Function GetAWAPParts(ByVal iDeviceID As Integer) As DataTable
			Dim strSql As String = ""

			Try
				strSql = "SELECT * " & Environment.NewLine
				strSql &= "FROM tdevicebillawap " & Environment.NewLine
				strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
				Me._objMisc._SQL = strSql
				Return Me._objMisc.GetDataTable()
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'***********************************************************************
		Public Function GetTMINoteAndReason(ByVal iWOID As Integer) As DataRow
			Dim strSql, strNote, strReason As String
			Dim dt As DataTable
			Dim R1, drNewRow As DataRow

			Try
				strSql = "SELECT DISTINCT extendedwarranty.Note, extendedwarranty.Reason" & Environment.NewLine
				strSql &= "FROM extendedwarranty " & Environment.NewLine
				strSql &= "WHERE WO_ID = " & iWOID & Environment.NewLine
				Me._objMisc._SQL = strSql
				dt = Me._objMisc.GetDataTable()
				drNewRow = dt.NewRow
				drNewRow("Note") = "" : drNewRow("Reason") = ""
				For Each R1 In dt.Rows
					If drNewRow("Note").ToString.Trim.Length > 0 Then drNewRow("Note") &= "; "
					drNewRow("Note") &= R1("Note")
					If drNewRow("Reason").ToString.Trim.Length > 0 Then drNewRow("Reason") &= "; "
					drNewRow("Reason") &= R1("Reason")
				Next R1

				Return drNewRow
			Catch ex As Exception
				Throw ex
			Finally
				Generic.DisposeDT(dt)
			End Try
		End Function

		'***********************************************************************
		Public Function GetSyxImageAvailableStatus(ByVal iModelID As Integer) As Integer
			Dim strSql As String = ""

			Try
				strSql = "SELECT if(sum(HasImage) is null, 0, sum(HasImage)) as Cnt " & Environment.NewLine
				strSql &= "FROM imagelibrary WHERE Model_ID = " & iModelID & Environment.NewLine
				Return Me._objMisc.GetIntValue(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'***********************************************************************
		Public Function GetPartConsumedTrans(ByVal iDeviceID As Integer) As DataTable
			Dim strSql As String = ""
			Dim dt As DataTable
			Dim i As Integer

			Try
				strSql = "SELECT 0 as 'Seq', if (Trans_Amount = -1 , 'Remove', 'Add') as 'Action', tparttransaction.Date_Rec as 'Trans Date'" & Environment.NewLine
				strSql &= ", billcode_desc as 'Bill Code', part_number as 'Part #', user_fullname as 'Tech/Biller'" & Environment.NewLine
				strSql &= "FROM tdevice " & Environment.NewLine
				strSql &= "INNER JOIN tparttransaction on tdevice.device_id = tparttransaction.device_id" & Environment.NewLine
				strSql &= "INNER JOIN lbillcodes on tparttransaction.billcode_id = lbillcodes.billcode_id" & Environment.NewLine
				strSql &= "LEFT OUTER JOIN security.tusers on tparttransaction.User_ID = security.tusers.user_id" & Environment.NewLine
				strSql &= "where tdevice.Device_ID = " & iDeviceID & Environment.NewLine
				strSql &= "ORDER BY tparttransaction.Trans_ID;" & Environment.NewLine
				dt = Me._objMisc.GetDataTable(strSql)
				For i = 0 To dt.Rows.Count - 1
					dt.Rows(i).BeginEdit() : dt.Rows(i)("Seq") = i + 1 : dt.Rows(i).EndEdit()
				Next
				Return dt
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'***********************************************************************
		Public Function GetPartNeedTrans(ByVal iDeviceID As Integer) As DataTable
			Dim strSql As String = ""
			Dim dt As DataTable
			Dim i As Integer

			Try
				strSql = "SELECT 0 as 'Seq', if (Trans_Amount = -1 , 'Remove', 'Add') as 'Action', tdevicebillawap.Date_Rec as 'Trans Date'" & Environment.NewLine
				strSql &= ", billcode_desc as 'Bill Code', part_number as 'Part #', user_fullname as 'Tech/Biller'" & Environment.NewLine
				strSql &= "FROM tdevice " & Environment.NewLine
				strSql &= "INNER JOIN tdevicebillawap on tdevice.device_id = tdevicebillawap.device_id" & Environment.NewLine
				strSql &= "INNER JOIN lbillcodes on tdevicebillawap.billcode_id = lbillcodes.billcode_id" & Environment.NewLine
				strSql &= "LEFT OUTER JOIN security.tusers on tdevicebillawap.User_ID = security.tusers.user_id" & Environment.NewLine
				strSql &= "where tdevice.Device_ID = " & iDeviceID & Environment.NewLine
				strSql &= "ORDER BY tdevicebillawap.DBillAWAP_ID;" & Environment.NewLine
				dt = Me._objMisc.GetDataTable(strSql)
				For i = 0 To dt.Rows.Count - 1
					dt.Rows(i).BeginEdit() : dt.Rows(i)("Seq") = i + 1 : dt.Rows(i).EndEdit()
				Next
				Return dt
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		''***********************************************************************
		'Public Function GetTechNote(ByVal iDeviceID As Integer) As String
		'    Dim strSql, strNotes As String
		'    Dim dt As DataTable
		'    Dim i As Integer

		'    Try
		'        strSql = "" : strNotes = ""
		'        strSql = "SELECT distinct Notes FROM ttestdata " & Environment.NewLine
		'        strSql &= "WHERE Test_ID = 7 AND device_id = " & iDeviceID & " AND Notes <> '' " & Environment.NewLine
		'        dt = Me._objMisc.GetDataTable(strSql)
		'        For i = 0 To dt.Rows.Count - 1
		'            If strNotes.Trim.Length > 0 Then strNotes &= "; "
		'            strNotes &= dt.Rows(0)("Notes")
		'        Next i
		'        Return strNotes
		'    Catch ex As Exception
		'        Throw ex
		'    End Try
		'End Function

		'***********************************************************************
		Public Function GetExtenedWarrantyData(ByVal iWO As Integer) As DataTable
			Dim strSql As String = ""

			Try
				strSql = "SELECT * FROM extendedwarranty " & Environment.NewLine
				strSql &= "WHERE WO_ID = " & iWO & Environment.NewLine
				Return Me._objMisc.GetDataTable(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		''***********************************************************************
		'Public Function UpdateConsumpPartNoAndStdCost(ByVal iDeviceID As Integer, ByVal iBillcodeID As Integer, ByVal strPartNumber As String, _
		'                                              ByVal decAvgCost As Decimal, ByVal StndCost As Decimal) As Integer
		'    Dim strSql As String = ""
		'    Dim i As Integer = 0

		'    Try
		'        strSql = "UPDATE tdevicebill SET DBill_AvgCost = " & decAvgCost & ", DBill_StdCost = " & StndCost & Environment.NewLine
		'        strSql &= ", Part_Number = '" & strPartNumber & "'" & Environment.NewLine
		'        strSql &= "WHERE Device_ID = " & iDeviceID & " AND Billcode_ID = " & iBillcodeID & Environment.NewLine
		'        i = Me._objMisc.ExecuteNonQuery(strSql)

		'        'strSql = "UPDATE tparttransaction SET Part_Number = '" & strPartNumber & "'" & Environment.NewLine
		'        'strSql &= "WHERE Device_ID = " & iDeviceID & " AND Billcode_ID = " & iBillcodeID & Environment.NewLine
		'        'i = Me._objMisc.ExecuteNonQuery(strSql)

		'        Return i
		'    Catch ex As Exception
		'        Throw ex
		'    End Try
		'End Function

		''***********************************************************************
		'Public Function GetMaxPriceByCustModel(ByVal iCustID As Integer, ByVal iModelID As Integer) As Double
		'    Dim strSql As String = ""
		'    Dim dbMaxPrice As Integer = 0
		'    Dim dt As DataTable

		'    Try
		'        strSql = "SELECT CMPM_Price as 'MaxPrice' FROM production.custmaxprice_model " & Environment.NewLine
		'        strSql &= "WHERE Cust_ID = " & iCustID & " AND Model_ID = " & iModelID & Environment.NewLine
		'        dt = Me._objMisc.GetDataTable(strSql)

		'        If dt.Rows.Count > 0 Then dbMaxPrice = Convert.ToDouble(dt.Rows(0)("MaxPrice"))

		'        Return dbMaxPrice
		'    Catch ex As Exception
		'        Throw ex
		'    End Try
		'End Function

		'***********************************************************************
		Public Function IsPartSNNeeded(ByVal iCustID As Integer, ByVal iPartID As Integer) As Boolean
			Dim strSql As String = ""

			Try
				strSql = "SELECT CaptureSN FROM partsncapture " & Environment.NewLine
				strSql &= "WHERE Cust_ID = " & iCustID & " AND PSPrice_ID = " & iPartID & Environment.NewLine
				If Me._objMisc.GetIntValue(strSql) = 1 Then Return True Else Return False

			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'***********************************************************************
		Public Shared Function TechScreenComplaintList(ByVal valManuf As Integer, ByVal valProdID As Integer) As DataTable
			Dim strSql As String = "Select * from tcomplaint where tcomplaint.Manuf_ID = " & valManuf & " and tcomplaint.prod_id= " & valProdID
			Dim objDataProc As DBQuery.DataProc

			Try
				objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
				Return objDataProc.GetDataTable(strSql)

			Catch ex As Exception
				Throw ex
			Finally
				objDataProc = Nothing
			End Try
		End Function

		'***********************************************************************
		Public Function GetTechNotesString(ByVal iDeviceID As Integer, Optional ByVal iCust_ID As Integer = 0) As String
			Dim strSql As String = ""
			Dim dt As DataTable

			Try
				If iCust_ID = 2560 Then				'AIG
					strSql = " SELECT *" & Environment.NewLine
					strSql &= " FROM tCellOpt WHERE Device_ID=" & iDeviceID
					dt = Me._objMisc.GetDataTable(strSql)

					If dt.Rows.Count > 0 Then
						If dt.Rows(0).Item("SN_Discp_Flag") = 1 And dt.Rows(0).Item("SN_Discp_AV_ID") = 2 Then						 'SN discrepancy device and rejected. no need tech performance
							Return "Cancel - No Need Tech"
						End If
					End If
				End If

				strSql = "SELECT Notes " & Environment.NewLine
				strSql &= "FROM technotes " & Environment.NewLine
				strSql &= "WHERE Device_ID = " & iDeviceID
				Return Me._objMisc.GetSingletonString(strSql)

			Catch ex As Exception
				Throw ex
			Finally
				Generic.DisposeDT(dt)
			End Try
		End Function

		'***********************************************************************
		Public Function GetTechNotesInfo(ByVal iDeviceID As Integer) As DataTable
			Dim strSql As String = ""

			Try
				strSql = "SELECT Device_ID, Notes, Date_Format(UpdatedDT, '%m/%d/%Y') as UpdatedDT " & Environment.NewLine
				strSql &= ", IF(User_Fullname is null, '', User_FullName ) as  User_FullName " & Environment.NewLine
				strSql &= "FROM technotes " & Environment.NewLine
				strSql &= "LEFT OUTER JOIN security.tusers ON technotes.UserID = security.tusers.User_ID " & Environment.NewLine
				strSql &= "WHERE Device_ID = " & iDeviceID
				Return Me._objMisc.GetDataTable(strSql)

			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'***********************************************************************
		Public Function SaveTechNotes(ByVal iDeviceID As Integer, ByVal strTechNotes As String, ByVal iUserID As Integer) As Integer
			Dim strSql As String = ""

			Try
				strTechNotes = strTechNotes.Replace("'", "\'")
				strSql = "SELECT count(*) FROM technotes WHERE Device_ID = " & iDeviceID
				If Me._objMisc.GetIntValue(strSql) > 0 Then
					strSql = "UPDATE technotes SET Notes = '" & strTechNotes & "'" & Environment.NewLine
					strSql &= ", UserID = " & iUserID & ", UpdatedDT = now() " & Environment.NewLine
					strSql &= "WHERE Device_ID = " & iDeviceID
				Else
					strSql = "INSERT INTO technotes ( " & Environment.NewLine
					strSql &= "Device_ID, Notes, UserID, UpdatedDT " & Environment.NewLine
					strSql &= ") VAlUES (" & Environment.NewLine
					strSql &= iDeviceID & ", '" & strTechNotes & "', " & iUserID & ", now() " & Environment.NewLine
					strSql &= " ) "
				End If
				Return Me._objMisc.ExecuteNonQuery(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'*************************************************************************************************************
		Public Function GetTechFailureCodes(ByVal booAddSelectedRow As Boolean, ByVal iDeviceID As Integer) As DataTable
			Dim strSql As String = ""
			Dim dt As DataTable

			Try
				strSql = "SELECT lcodesdetail.DCode_ID, Dcode_SDesc, Dcode_Ldesc, Concat(trim(Dcode_SDesc), ' - ', trim(Dcode_Ldesc)) as DCode_SLDesc" & Environment.NewLine
				strSql &= " FROM tdevice INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
				strSql &= " INNER JOIN lcodesmaster ON tmodel.Prod_ID = lcodesmaster.Prod_ID AND lcodesmaster.TechScreen = 1 " & Environment.NewLine
				strSql &= " INNER JOIN lcodesdetail ON lcodesdetail.MCode_ID = lcodesmaster.MCode_ID " & Environment.NewLine
				strSql &= " WHERE tdevice.Device_ID = " & iDeviceID & " AND Dcode_Inactive = 0 order by lcodesdetail.Dcode_sdesc;" & Environment.NewLine

				dt = Me._objMisc.GetDataTable(strSql)

				If booAddSelectedRow Then dt.LoadDataRow(New Object() {"0", "", "", "--Select--"}, True)

				Return dt
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'*************************************************************************************************************
		Public Function GetTechFailureResult(ByVal iDevice_ID As Integer) As DataTable
			Dim strSql As String = ""

			Try
				strSql = "SELECT A.DCode_ID, B.Dcode_SDesc, B.Dcode_Ldesc, Concat(trim(B.Dcode_SDesc), ' - ', trim(B.Dcode_Ldesc)) as DCode_SLDesc" & Environment.NewLine
				strSql &= " FROM tTechFailureResult A" & Environment.NewLine
				strSql &= " INNER JOIN lcodesdetail B ON A.DCode_ID = B.DCode_ID" & Environment.NewLine
				strSql &= " WHERE A.Device_ID = " & iDevice_ID & ";" & Environment.NewLine
				Return Me._objMisc.GetDataTable(strSql)

			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'*************************************************************************************************************
		Public Sub SaveTechFailureResult(ByVal iDevice_ID As Integer, ByVal arrDCode_ID As ArrayList, _
		   ByVal iUser_ID As Integer, ByRef strErrMsg As String)
			Dim i, j As Integer
			Dim strSql, strDateTime As String

			Try
				strDateTime = Generic.MySQLServerDateTime(1)

				strErrMsg = ""
				strSql = "DELETE FROM tTechFailureResult WHERE Device_ID = " & iDevice_ID
				i = Me._objMisc.ExecuteNonQuery(strSql)

				For j = 0 To arrDCode_ID.Count - 1
					If Trim(arrDCode_ID(j)) <> "" Then
						strSql = "INSERT INTO tTechFailureResult (Device_ID, DCode_ID, User_ID, UpdatedDT)" & Environment.NewLine
						strSql &= " VALUES (" & iDevice_ID & "," & arrDCode_ID(j) & "," & iUser_ID & ",'" & strDateTime & "');" & Environment.NewLine
						i = Me._objMisc.ExecuteNonQuery(strSql)
						If Not i > 0 Then
							strErrMsg &= "Failed to save Dcode = " & arrDCode_ID(j) & "." & Environment.NewLine
						End If
					End If
				Next

			Catch ex As Exception
				Throw ex
			End Try
		End Sub

		'*************************************************************************************************************
		Public Function SetAWAPCompletedDate(ByVal iDevice_ID As Integer) As Integer
			Dim strSql As String

			Try
				strSql = "UPDATE tdevicebillawap SET CompleteDate = now() " & Environment.NewLine
				strSql &= "WHERE Device_ID = " & iDevice_ID & " AND CompleteDate is null " & Environment.NewLine
				Return Me._objMisc.ExecuteNonQuery(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'*************************************************************************************************************
		Public Function GetReclaimDevice(ByVal iLocID As Integer, ByVal strDeviceSN As String _
		  , Optional ByVal strWorkStation As String = "") As DataTable
			Dim strSql As String

			Try
				strSql = "SELECT tdevice.* , tcellopt.WorkStation, tpallett.pkslip_ID " & Environment.NewLine
				strSql &= "FROM tdevice " & Environment.NewLine
				strSql &= "LEFT OUTER JOIN tcellopt ON tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
				strSql &= "LEFT OUTER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
				strSql &= "WHERE tdevice.Device_SN = '" & strDeviceSN & "' AND tdevice.Loc_ID = " & iLocID & " AND tpallett.pkslip_ID is null " & Environment.NewLine
				If strWorkStation.Trim.Length > 0 Then strSql &= " AND tcellopt.Workstation in ( " & strWorkStation & " ) " & Environment.NewLine
				strSql &= "ORDER BY tdevice.Device_ID DESC LIMIT 1"
				Return Me._objMisc.GetDataTable(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'*************************************************************************************************************
		Public Function GetReclaimParts(ByVal iDeviceID As Integer) As DataTable
			Dim strSql As String

			Try
				strSql = "SELECT * FROM tdevicebill_reclaim " & Environment.NewLine
				strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
				Return Me._objMisc.GetDataTable(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'*************************************************************************************************************
		Public Function DeleteDeviceBillReclaim(ByVal iDeviceID As Integer, ByVal iBillcodeID As Integer) As Integer
			Dim strSql As String

			Try
				strSql = "DELETE FROM tdevicebill_reclaim " & Environment.NewLine
				strSql &= "WHERE Device_ID = " & iDeviceID & " AND Billcode_ID = " & iBillcodeID & Environment.NewLine
				Return Me._objMisc.ExecuteNonQuery(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'*************************************************************************************************************
		Public Function InsertIntoDeviceBillReclaim(ByVal iDeviceID As Integer, ByVal dbRegPartprice As Double, _
		 ByVal dbAvgCost As Double, ByVal dbStdCost As Double, ByVal iBillcodeID As Integer, _
		 ByVal strPartNumber As String, ByVal iUsrID As Integer) As Integer
			Dim strSql As String

			Try
				If IsReclaimBillCodeExisted(iDeviceID, iBillcodeID) = False Then
					strSql = "INSERT INTO tdevicebill_reclaim ( " & Environment.NewLine
					strSql &= " DBillReclaim_RegPartPrice, DBillReclaim_AvgCost, DBillReclaim_StdCost,  Device_ID, BillCode_ID, Part_Number, User_ID, Date_Rec " & Environment.NewLine
					strSql &= ") VALUES ( " & Environment.NewLine
					strSql &= dbRegPartprice & ", " & dbAvgCost & ", " & dbStdCost & ", " & iDeviceID & ", " & iBillcodeID & ", '" & strPartNumber & "'" & Environment.NewLine
					strSql &= ", " & iUsrID & ", now() " & Environment.NewLine
					strSql &= ") "
					Return Me._objMisc.ExecuteNonQuery(strSql)
				Else
					Return 1
				End If
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'*************************************************************************************************************
		Public Function IsReclaimBillCodeExisted(ByVal iDeviceID As Integer, ByVal iBillcodeID As Integer) As Boolean
			Dim strSql As String

			Try
				strSql = "SELECT count(*) as cnt FROM tdevicebill_reclaim WHERE Device_ID = " & iDeviceID & " AND Billcode_ID = " & iBillcodeID & Environment.NewLine
				If Me._objMisc.GetIntValue(strSql) > 0 Then Return True Else Return False
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'*************************************************************************************************************
		Public Function GetPartStdCost(ByVal strRegPart As String) As Decimal
			Dim strSql As String
			Dim dt As DataTable

			Try
				strSql = "SELECT PSPrice_StndCost FROM lpsprice WHERE PSPrice_Number = '" & strRegPart & "'" & Environment.NewLine
				dt = Me._objMisc.GetDataTable(strSql)
				If dt.Rows.Count = 0 Then
					Return 0.0
				Else
					Return CDec(dt.Rows(0)("PSPrice_StndCost"))
				End If
			Catch ex As Exception
				Throw ex
			Finally
				Generic.DisposeDT(dt)
			End Try
		End Function

		'*************************************************************************************************************
		Public Function GetPartQty(ByVal iDeviceID As Integer) As DataTable
			Dim strSql As String
			Dim dt As DataTable
			Dim R1 As DataRow

			Try
				strSql = "SELECT Billcode_Desc as 'Bill Code', Psprice_number as 'Part #', MaxInventory, 0.0 as 'Cage', 0.0 as 'Re-claim', 0.0 as CagePlusReclaim, B.Billcode_ID" & Environment.NewLine
				strSql &= "FROM tdevice A" & Environment.NewLine
				strSql &= "INNER JOIN tpsmap B ON A.Model_ID = B.Model_ID" & Environment.NewLine
				strSql &= "INNER JOIN lpsprice C ON B.Psprice_ID = C.Psprice_ID" & Environment.NewLine
				strSql &= "INNER JOIN lbillcodes D ON B.Billcode_ID = D.Billcode_ID" & Environment.NewLine
				strSql &= "WHERE A.Device_ID = " & iDeviceID & " AND RVFlag = 1" & Environment.NewLine
				strSql &= "ORDER BY Billcode_Desc "
				dt = Me._objMisc.GetDataTable(strSql)
				For Each R1 In dt.Rows
					R1.BeginEdit()
					R1("Cage") = Me.GetBinContentQty(R1("Part #"))
					R1("Re-claim") = Me.GetTodayPartReclaimQty(R1("Billcode_ID"))
					R1("CagePlusReclaim") = CInt(R1("Cage")) + CInt(R1("Re-claim"))
					R1.EndEdit()
				Next R1

				Return dt
			Catch ex As Exception
				Throw ex
			Finally
				Generic.DisposeDT(dt)
			End Try
		End Function

		'*************************************************************************************************************
		Public Function GetBinContentQty(ByVal strPartNumber As String) As Integer
			Dim strSql As String

			Try
				strSql = "SELECT sum(quantity) as Qty FROM cogs.tcogs_bincontent WHERE item_number = '" & strPartNumber & "'" & Environment.NewLine
				strSql &= "AND Bin_Location NOT IN ( 'WIP' ) "
				Return Me._objMisc.GetIntValue(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'*************************************************************************************************************
		Public Function GetTodayPartReclaimQty(ByVal iBillcodeID As Integer) As Integer
			Dim strSql As String, strToday As String
			Try
				strSql = " SELECT count(*) as cnt FROM tdevicebill_reclaim WHERE Billcode_ID = " & iBillcodeID & " AND date_rec = date_format(now(), '%Y-%m-%d') " & Environment.NewLine
				Return Me._objMisc.GetIntValue(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'*************************************************************************************************************
		Public Function IsDevHasReclaimParts(ByVal iDeviceID As Integer) As Boolean
			Dim strSql As String, strToday As String
			Try
				strSql = " SELECT count(*) as cnt FROM tdevicebill_reclaim WHERE Device_ID = " & iDeviceID & Environment.NewLine
				If Me._objMisc.GetIntValue(strSql) > 0 Then Return True Else Return False
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'*************************************************************************************************************

End Class
End Namespace
