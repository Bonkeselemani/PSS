Option Explicit On 

Imports CrystalDecisions.CrystalReports.Engine
Imports System.Windows.Forms
Imports System.Text
Imports PSS.Data.Buisness.Security
Imports PSS.Data.BOL

Namespace Buisness.TracFone
	Public Class clsMisc
#Region "DECLARATIONS"
		Public Const _iWHBoxSegDigitCnt As Integer = 4
		Private _objModelManuf As New PSS.Data.Buisness.ModManuf()
		Private _objDataProc As DBQuery.DataProc
#End Region
#Region "Constructor/Destructor"

		Public Sub New()
			Try
				Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			Catch ex As Exception
				Throw ex
			End Try
		End Sub

		Protected Overrides Sub Finalize()		'
			Try
				_objModelManuf = Nothing
				_objDataProc = Nothing
			Finally
				MyBase.Finalize()
			End Try
		End Sub

#End Region
#Region "HIDE FOR NOW"

		Public Function GetBoxStationCount(ByVal strBoxID As String) As DataTable
			Dim strSql As String

			Try
				strSql = "SELECT DISTINCT D.WorkStation, A.VN_ItemNo, Count(*) as cnt " & Environment.NewLine
				strSql &= ", if(E.Closed is null, 0, E.Closed) as Closed, G.Model_Desc " & Environment.NewLine
				strSql &= ", if(E.FuncRep is null, 0, E.FuncRep) as FuncRep, G.Model_ID, A.Order_ID, sum(Device_PartCharge) as PartCharge " & Environment.NewLine
				strSql &= "FROM edi.titem A " & Environment.NewLine
				strSql &= "INNER JOIN edi.torder B ON A.Order_ID = B.Order_ID " & Environment.NewLine
				strSql &= "INNER JOIN production.tworkorder C ON B.PSS_WO_ID = C.WO_ID " & Environment.NewLine
				strSql &= "INNER JOIN production.tcellopt D ON A.Device_ID = D.Device_ID " & Environment.NewLine
				strSql &= "LEFT OUTER JOIN edi.twarehousebox E ON A.wb_id = E.wb_id " & Environment.NewLine
				strSql &= "INNER JOIN production.tdevice F ON A.Device_ID = F.Device_ID " & Environment.NewLine
				strSql &= "INNER JOIN production.tmodel G ON F.Model_ID = G.Model_ID " & Environment.NewLine
				strSql &= "WHERE A.BoxID = '" & strBoxID & "' " & Environment.NewLine
				strSql &= "GROUP BY D.WorkStation, A.VN_ItemNo, G.Model_Desc " & Environment.NewLine
				strSql &= "ORDER BY cnt DESC " & Environment.NewLine
				Return Me._objDataProc.GetDataTable(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Public Function PushWBBoxToWorkArea(ByVal strBoxID As String, _
		  ByVal strToNewStation As String, _
		  ByVal iUserID As Integer, _
		  ByVal strScreenName As String, _
		  ByVal strFormName As String) As Integer
			Dim strSql As String
			Dim i As Integer = 0
			Dim dtClaimableDevice, dt As DataTable
			Dim R1 As DataRow

			Try
				If strBoxID.Trim.Length = 0 Then Throw New Exception("Box ID is empty. Can't set workstation.")
				strSql = ""

				'***********************************************
				'Re-Set Receipt Date ( use in warranty claim file )
				'Reason: TAT is 30 days
				'***********************************************
				If strToNewStation = "PRODUCTION STAGING" Then
					strSql = "SELECT A.Device_ID, A.LastDateInWrty, A.Manuf_Date, B.Device_SN, B.Device_ManufWrty, D.Manuf_ID, D.Manuf_Desc " & Environment.NewLine
					strSql &= "FROM edi.titem A " & Environment.NewLine
					strSql &= "INNER JOIN tdevice B ON A.Device_ID = B.Device_ID " & Environment.NewLine
					strSql &= "INNER JOIN tmodel C ON B.Model_ID = C.Model_ID " & Environment.NewLine
					strSql &= "INNER JOIN lmanuf D ON C.Manuf_ID = D.Manuf_ID " & Environment.NewLine
					strSql &= "WHERE A.BoxID = '" & strBoxID & "' " & Environment.NewLine
					strSql &= "AND D.Claimable = 1 AND B.Device_ManufWrty = 1 " & Environment.NewLine
					dtClaimableDevice = Me._objDataProc.GetDataTable(strSql)

					If dtClaimableDevice.Rows.Count > 0 Then
						For Each R1 In dtClaimableDevice.Rows
							If IsDBNull(R1("LastDateInWrty")) OrElse R1("LastDateInWrty").ToString.Trim.Length = 0 Then Throw New Exception("System could not define last warranty date for device '" & R1("Device_SN") & "'.")
							Me.ResetReceiptDateAndWrtyStatus(R1)
						Next R1
					End If
				End If

				'***********************************************
				strSql = "SELECT A.Device_ID, WorkStation FROM production.tcellopt A" & Environment.NewLine
				strSql &= "INNER JOIN edi.titem B ON A.Device_ID = B.Device_ID " & Environment.NewLine
				strSql &= "WHERE B.BoxID = '" & strBoxID & "' " & Environment.NewLine
				dt = Me._objDataProc.GetDataTable(strSql)
				If dt.Rows.Count = 0 Then Throw New Exception("Box is empty.")

				strSql = "UPDATE production.tcellopt A" & Environment.NewLine
				strSql &= "INNER JOIN edi.titem B ON A.Device_ID = B.Device_ID " & Environment.NewLine
				strSql &= "SET WorkStation = '" & strToNewStation & "', WorkStationEntryDt = now() " & Environment.NewLine
				strSql &= "WHERE B.BoxID = '" & strBoxID & "' " & Environment.NewLine
				i = Me._objDataProc.ExecuteNonQuery(strSql)

				Generic.SetTcelloptWorkstationJournal(dt, iUserID, strToNewStation, strScreenName, strFormName)

				' INSERT BOX/DEVICE HISTORY TO THE SW SCREEN JOURNAL FOR SW SCREEN PASSED BOXES.
				If strFormName = "TFSWScreenForBox" Then
					Dim strOldBoxID As String
					Dim _resolution As String = IIf(strToNewStation = "SW FAIL", "FAILED", "PASSED")
					Dim _dt As New DataTable()
					strOldBoxID = IIf(strToNewStation = "SW FAIL", strBoxID.Replace("SW", ""), strBoxID)
					_dt = clsMisc.GetWBDevicesPendingWS(strBoxID, strToNewStation)
					Dim _dr As DataRow
					For Each _dr In _dt.Rows()
						Dim _tdevice As New Data.BOL.tDevice(_dr("device_sn").ToString(), False)
						InsertDeviceSWScreenJournalRecords(_tdevice.Device_ID, _tdevice.Device_SN, strOldBoxID, strBoxID, _resolution, iUserID)
					Next _dr
				End If

				Return i
			Catch ex As Exception
				Throw ex
			Finally
				Generic.DisposeDT(dtClaimableDevice) : Generic.DisposeDT(dt)
			End Try
		End Function
		Public Function PushWBBoxToWHWIP(ByVal strBoxID As String, ByVal strToNewStation As String, ByVal strAcptedStation As String, _
		   ByVal iUserID As Integer, ByVal strScreenName As String, ByVal strFormName As String) As Integer
			Dim strSql, strNewBox As String
			Dim i, j, iNextSeqNo As Integer
			Dim dtOrgBox, dtNewBox, dtDevicesInBox, dtBoxCntByStation, dtWSJournal As DataTable
			Dim drDevices(), R1 As DataRow
			Dim iNewWHBoxID As Integer = 0

			Try
				If strBoxID.Trim.Length = 0 Then Throw New Exception("Box ID can't be blank.")

				'Validate original box
				dtOrgBox = Me.GetWHBox(strBoxID)
				If dtOrgBox.Rows.Count = 0 Then
					Throw New Exception("Box does not exist.")
				ElseIf dtOrgBox.Rows.Count > 1 Then
					Throw New Exception("Box ID existed more than one.")
				End If

				'Validate Accepted workstation
				If strAcptedStation.Trim.Length = 0 Then Throw New Exception("From workstation is missing in work flow process.")

				'Reset Warehouse location
				strSql = "UPDATE edi.twarehousebox SET WHLocation = '' WHERE wb_id = " & dtOrgBox.Rows(0)("wb_id")
				Me._objDataProc.ExecuteNonQuery(strSql)

				'Create new box if box has multiple station
				dtBoxCntByStation = Me.GetBoxStationCount(strBoxID)

				If dtBoxCntByStation.Rows.Count > 1 Then
					strNewBox = Microsoft.VisualBasic.Left(strBoxID, 11)

					iNextSeqNo = GetWHBoxNexSeqNo(strNewBox, _iWHBoxSegDigitCnt)
					If iNextSeqNo = 0 Then Throw New Exception("System has failed to get next box number.")
					strNewBox = strNewBox & iNextSeqNo.ToString.PadLeft(_iWHBoxSegDigitCnt, "0")

					dtNewBox = Me.GetWHBox(strNewBox, dtOrgBox.Rows(0)("Order_ID"))
					If dtNewBox.Rows.Count = 0 Then
						iNewWHBoxID = InsertEdiWarehouseBox(strNewBox, dtOrgBox.Rows(0)("FuncRep"), dtOrgBox.Rows(0)("WarrantyFlag"), dtOrgBox.Rows(0)("Order_ID"), dtOrgBox.Rows(0)("Model_ID"), dtOrgBox.Rows(0)("WrtyExpedite"), 0)
						If iNewWHBoxID = 0 Then Throw New Exception("System has failed to create new box.")
					Else
						iNewWHBoxID = dtNewBox.Rows(0)("wb_id")
					End If
				End If

				If dtBoxCntByStation.Rows.Count > 1 And iNewWHBoxID = 0 Then Throw New Exception("System has failed to create new box.")

				'get device in box
				dtDevicesInBox = Me.GetDevicesInWHBox(strBoxID, dtOrgBox.Rows(0)("Order_ID"))
				If dtDevicesInBox.Rows.Count = 0 Then Throw New Exception("Can't find any device in box.")

				dtWSJournal = New DataTable()
				dtWSJournal = dtDevicesInBox.Clone

				'Create Accepted station
				Dim strAcptedStationArr() As String = strAcptedStation.Split("|")
				Dim strOrEqualStation As String = ""
				Dim strAndNotEqualStation As String = ""
				For i = 0 To strAcptedStationArr.Length - 1
					If strAcptedStationArr(i).Trim.Length > 0 Then
						If strOrEqualStation.Trim.Length > 0 Then strOrEqualStation &= " OR "
						strOrEqualStation &= "Workstation = '" & strAcptedStationArr(i) & "'"

						If strAndNotEqualStation.Trim.Length > 0 Then strAndNotEqualStation &= " AND "
						strAndNotEqualStation &= "Workstation <> '" & strAcptedStationArr(i) & "'"
					End If
				Next i

				'Get next station devices
				drDevices = dtDevicesInBox.Select(strOrEqualStation)
				Dim strDeviceList As String = ""
				For i = 0 To drDevices.Length - 1
					If strDeviceList.Trim.Length > 0 Then strDeviceList &= ", "
					strDeviceList &= drDevices(i)("Device_ID")

					R1 = dtWSJournal.NewRow
					R1("Device_ID") = drDevices(i)("Device_ID") : R1("Workstation") = drDevices(i)("Workstation")
					dtWSJournal.Rows.Add(R1)
				Next i

				dtWSJournal.AcceptChanges()

				If strDeviceList.Trim.Length > 0 Then
					strSql = "UPDATE production.tcellopt A" & Environment.NewLine
					strSql &= "SET WorkStation = '" & strToNewStation & "', WorkStationEntryDt = now() " & Environment.NewLine
					strSql &= "WHERE A.Device_ID IN ( " & strDeviceList & " ) " & Environment.NewLine
					j = Me._objDataProc.ExecuteNonQuery(strSql)
					If j = 0 Then Throw New Exception("System has failed to push devices into " & strToNewStation & " workstation.")

					Generic.SetTcelloptWorkstationJournal(dtWSJournal, iUserID, strToNewStation, strScreenName, strFormName)
				End If

				'Split box
				If iNewWHBoxID > 0 Then
					'Get new box devices
					drDevices = dtDevicesInBox.Select(strAndNotEqualStation)
					strDeviceList = ""
					For i = 0 To drDevices.Length - 1
						If strDeviceList.Trim.Length > 0 Then strDeviceList &= ", "
						strDeviceList &= drDevices(i)("Device_ID")
					Next i

					If strDeviceList.Trim.Length > 0 Then
						strSql = "UPDATE edi.titem A" & Environment.NewLine
						strSql &= "SET A.wb_id = " & iNewWHBoxID & ", A.BoxID = '" & strNewBox & "'" & Environment.NewLine
						strSql &= "WHERE A.Device_ID IN ( " & strDeviceList & " ) " & Environment.NewLine
						j = Me._objDataProc.ExecuteNonQuery(strSql)
						If j = 0 Then Throw New Exception("System has failed to split box.")
					End If

					'Reprint label if split box happen
					If iNewWHBoxID > 0 Then
						Dim objTFRec = New TracFone.Receive()
						objTFRec.ReprintWHBox(strBoxID)
						objTFRec = Nothing
					End If
				End If

				Return j
			Catch ex As Exception
				Throw ex
			Finally
				Generic.DisposeDT(dtOrgBox) : Generic.DisposeDT(dtNewBox)
				Generic.DisposeDT(dtDevicesInBox) : Generic.DisposeDT(dtBoxCntByStation)
			End Try
        End Function
        Public Function getDeviceModelID(ByVal iDevice_ID As Integer) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim iModel_ID As Integer = 0

            Try
                strSql = "select * from tdevice where device_id = " & iDevice_ID.ToString
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    iModel_ID = dt.Rows(0).Item("Model_ID")
                End If
                Return iModel_ID
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function ResetWorkstationForNonBuffableDevice(ByVal iDevice_ID As Integer, ByVal strWorkstation As String) As Integer
            Dim strSql As String = ""
            Try
                strSql = "update tcellopt set workstation = '" & strWorkstation & "' where device_id = " & iDevice_ID.ToString
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Private Function ResetReceiptDateAndWrtyStatus(ByVal drDeviceInfo As DataRow) As Integer
            Dim strSql As String = ""
            Dim iInWrty As Integer = -1
            Dim dteToday, dteLastDateInWrty As DateTime

            Try
                dteToday = CDate(Generic.GetMySqlDateTime("%Y-%m-%d"))
                dteLastDateInWrty = CDate(CDate(drDeviceInfo("LastDateInWrty")).ToString("yyyy-MM-dd"))

                If dteToday <= dteLastDateInWrty Then iInWrty = 1 Else iInWrty = 0

                '**********************************
                'iInWrty must have value of 0 or 1. 
                ' 0: Out of warranty
                ' 1: In warranty
                '**********************************
                strSql = "UPDATE edi.titem, tdevice SET WrtyClaimReceiptDt = now() " & Environment.NewLine
                strSql &= ", Device_ManufWrty = " & iInWrty & Environment.NewLine
                strSql &= "WHERE tdevice.Device_ID = edi.titem.Device_ID AND tdevice.device_id = " & drDeviceInfo("Device_ID") & Environment.NewLine
                Me._objDataProc.ExecuteNonQuery(strSql)

                Return iInWrty
            Catch ex As Exception
                Throw ex
            Finally
                drDeviceInfo = Nothing
            End Try
        End Function
        Public Function GetSN() As DataTable
            Dim strSql, strSNs As String
            Dim dt As DataTable
            Dim dtSN As DataTable
            Dim R1 As DataRow

            Try
                strSql = "select distinct" & Environment.NewLine
                strSql &= "'BRIGHTSTAR CORPORATION' as 'ComName'," & Environment.NewLine
                strSql &= "'2000 USG DRIVE' as 'Address'," & Environment.NewLine
                strSql &= "'LIBERTYVILLE IL' as 'CityNState'," & Environment.NewLine
                strSql &= "'60048' as 'ZIP'," & Environment.NewLine
                strSql &= "'*70004588*' as 'TransOrderBar'," & Environment.NewLine
                strSql &= "'70004588' as 'TransOrder'," & Environment.NewLine
                strSql &= "'*TFMTW175RB*' as 'PartNumBar'," & Environment.NewLine
                strSql &= "'TFMTW175RB' as 'PartNum'," & Environment.NewLine
                strSql &= "'Tracfone MOTOROLA 175 GSM HANDSET ' as 'PartDesc'," & Environment.NewLine
                strSql &= "'*1128356*' as 'ShipmentIDBar'," & Environment.NewLine
                strSql &= "'1128356' as 'ShipmentID'," & Environment.NewLine
                strSql &= "'*TFMTW175REF091002N02*' as 'CartonIDBar'," & Environment.NewLine
                strSql &= "'TFMTW175REF091002N02' as 'CartonID'," & Environment.NewLine
                strSql &= "'1' as 'CartonNumX'," & Environment.NewLine
                strSql &= "'1' as 'CartonNumN'," & Environment.NewLine
                strSql &= "'*90*' as 'CartonQtyBar'," & Environment.NewLine
                strSql &= "'90' as 'CartonQty'," & Environment.NewLine
                strSql &= "'' as 'SNs'" & Environment.NewLine
                strSql &= "from tdevice A" & Environment.NewLine
                strSql &= "inner join tcustmodel_pssmodel_map B On A.Model_ID = B.Model_ID" & Environment.NewLine
                strSql &= "where loc_id = 2946;" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                strSql = "select Device_SN" & Environment.NewLine
                strSql &= "from tdevice A" & Environment.NewLine
                strSql &= "where loc_id = 2946;" & Environment.NewLine
                dtSN = Me._objDataProc.GetDataTable(strSql)

                For Each R1 In dtSN.Rows
                    strSNs &= R1("Device_SN") & ","
                Next R1

                dt.Rows(0).BeginEdit()
                dt.Rows(0)("SNs") = strSNs
                dt.Rows(0).EndEdit()
                dt.AcceptChanges()

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
                PSS.Data.Buisness.Generic.DisposeDT(dtSN)
            End Try
        End Function
        Public Shared Function PrintCrystalReportLabel(ByVal dt As DataTable, _
          ByVal strReportName As String, _
          ByVal iCopies As Integer, _
          Optional ByVal strPrinterName As String = "") As Integer
            Dim objRpt As ReportDocument
            Dim objDataProc As DBQuery.DataProc

            Try
                '*****************************
                '1: Print License Plate
                '*****************************
                If Not IsNothing(dt) Then
                    objRpt = New ReportDocument()

                    With objRpt
                        Dim pathFileNM As String = PSS.Data.ConfigFile.GetBaseReportPath & strReportName
                        If System.IO.File.Exists(pathFileNM) Then
                            .Load(PSS.Data.ConfigFile.GetBaseReportPath & strReportName)
                            .SetDataSource(dt)
                            If strPrinterName.Trim.Length > 0 Then .PrintOptions.PrinterName = strPrinterName
                            .PrintToPrinter(iCopies, True, 0, 0)
                        Else
                            MessageBox.Show(String.Concat("The report file was not found.", vbCrLf, pathFileNM), "Missing Report File", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End With
                End If
            Catch ex As Exception
                Throw ex
            Finally
                objRpt = Nothing
                objDataProc = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Function
        Public Shared Function PrintPlainCrystalReport(ByVal strReportName As String, _
          ByVal iCopies As Integer, _
          Optional ByVal strPrinterName As String = "") As Integer
            Dim objRpt As ReportDocument

            Try
                objRpt = New ReportDocument()

                With objRpt
                    .Load(PSS.Data.ConfigFile.GetBaseReportPath & strReportName)
                    If strPrinterName.Trim.Length > 0 Then .PrintOptions.PrinterName = strPrinterName
                    .Refresh()
                    .PrintToPrinter(iCopies, True, 0, 0)
                End With

            Catch ex As Exception
                Throw ex
            Finally
                objRpt = Nothing
            End Try
        End Function
        Public Function PushShipBoxToNextStation(ByVal iPalletID As Integer, ByVal strNextStation As String _
          , ByVal iUserID As Integer, ByVal strScreenName As String, ByVal strFormName As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim i As Integer

            Try
                strSql = "SELECT tcellopt.Device_ID, WorkStation FROM tcellopt " & Environment.NewLine
                strSql &= "INNER JOIN tdevice ON tcellopt.Device_ID = tdevice.Device_ID " & Environment.NewLine
                strSql &= "WHERE tdevice.Pallett_ID = " & iPalletID & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count = 0 Then Throw New Exception("Device list is empty for workstation journal.")

                strSql = "UPDATE tcellopt " & Environment.NewLine
                strSql &= "INNER JOIN tdevice ON tcellopt.Device_ID = tdevice.Device_ID " & Environment.NewLine
                strSql &= "SET WorkStation = '" & strNextStation & "', WorkStationEntryDt = now() " & Environment.NewLine
                strSql &= "WHERE tdevice.Pallett_ID = " & iPalletID & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                Generic.SetTcelloptWorkstationJournal(dt, iUserID, strNextStation, strScreenName, strFormName)

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function GetShipBoxStationCount(ByVal strPalletName As String) As DataTable
            ' THIS FUNCTION WILL RETURN A DATATABLE REFLECTING THE CURRENT WORKSTATION FROM THE TCELLOPT TABLE.
            Dim strSql As String = ""
            Try
                strSql = "SELECT Distinct A.*, C.WorkStation, cust_OutgoingSku " & Environment.NewLine
                strSql &= "FROM production.tpallett A " & Environment.NewLine
                strSql &= "INNER JOIN production.tdevice B ON A.Pallett_ID = B.Pallett_ID " & Environment.NewLine
                strSql &= "INNER JOIN production.tcellopt C ON B.Device_ID = C.Device_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN production.tcustmodel_pssmodel_map D ON A.Model_ID = D.Model_ID AND A.Cust_ID = D.Cust_ID " & Environment.NewLine
                strSql &= "WHERE A.Pallett_Name = '" & strPalletName & "' " & Environment.NewLine
                strSql &= "AND Pallet_Invalid = 0; " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function WriteTestResult(ByVal iDeviceID As Integer, _
          ByVal iTestTypeID As Integer, _
          ByVal iUsrID As Integer, _
          ByVal iTechUsrID As Integer, _
          ByVal iTestResult As Integer, _
          Optional ByVal iPalletID As Integer = 0, _
          Optional ByVal strPalletNumber As String = "", _
          Optional ByVal iPalletQty As Integer = 0, _
          Optional ByVal strFailDetails As String = "", _
          Optional ByVal iFailID As Integer = 0, _
          Optional ByVal iFinalTestUsrID As Integer = 0, _
          Optional ByVal iMachineCCID As Integer = 0, _
          Optional ByVal strFrStation As String = "", _
          Optional ByVal strToStation As String = "") As Integer
            Dim strSql As String
            Dim iNextNum As Integer = 0
            Dim iReject As Integer = 0
            Dim i As Integer = 0

            Try
                'write test result
                iNextNum = Generic.GetNextSeqNoInTtestdata(iDeviceID, iTestTypeID)

                If iNextNum > 1 Then iTestResult = 3

                If iMachineCCID > 0 AndAlso iTestTypeID = 13 Then
                    strSql = "Update tdevice Set cc_id = " & iMachineCCID & ", CC_EntryDate = now() WHERE cc_id = 0 and Device_ID = " & iDeviceID
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                End If

                strSql = "INSERT INTO ttestdata (TD_TestDt, TD_UsrID, TD_Sequence, Device_ID, Test_ID, QCResult_ID, TD_FailDetails "
                If iTechUsrID > 0 Then strSql &= ", CompletedTechUsrID "
                If iPalletID > 0 Then strSql &= ", Pallett_ID, Pallet_Name, Pallet_Qty "
                If iFailID > 0 Then strSql &= ", Fail_ID "
                If iFinalTestUsrID > 0 Then strSql &= ", FinalTestInspectorUsrID "
                strSql &= ", MachineCCID, FrWorkstation, ToWorkstation "

                strSql &= ") VALUES (" & Environment.NewLine
                strSql &= "  now() " & Environment.NewLine
                strSql &= ", " & iUsrID & " " & Environment.NewLine
                strSql &= ", " & iNextNum & " " & Environment.NewLine
                strSql &= ", " & iDeviceID & " " & Environment.NewLine
                strSql &= ", " & iTestTypeID & " " & Environment.NewLine
                strSql &= ", " & iTestResult & " " & Environment.NewLine
                strSql &= ", '" & strFailDetails & "' " & Environment.NewLine
                If iTechUsrID > 0 Then strSql &= ", " & iTechUsrID & " " & Environment.NewLine
                If iPalletID > 0 Then strSql &= ", " & iPalletID & ", '" & strPalletNumber & "', " & iPalletQty & Environment.NewLine
                If iFailID > 0 Then strSql &= ", " & iFailID & Environment.NewLine
                If iFinalTestUsrID > 0 Then strSql &= ", " & iFinalTestUsrID & Environment.NewLine
                strSql &= ", " & iMachineCCID & Environment.NewLine
                strSql &= ", '" & strFrStation & "', '" & strToStation & "' " & Environment.NewLine
                strSql &= ") " & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function GetPartsOfDevice(ByVal iDeviceID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT tdevicebill.Billcode_ID " & Environment.NewLine
                strSql &= "FROM production.tdevicebill " & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON tdevicebill.Billcode_ID = lbillcodes.Billcode_ID " & Environment.NewLine
                strSql &= "WHERE tdevicebill.Device_ID = " & iDeviceID & " " & Environment.NewLine
                strSql &= "AND BillType_ID = 2; " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function GetDeviceBoxID(ByVal strIMEI As String) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT OrderNo as 'Order#', BoxID as 'Box ID', Manuf_Date as 'Manuf Date', Workstation as 'Current Station' " & Environment.NewLine
                strSql &= "FROM edi.titem A  " & Environment.NewLine
                strSql &= "INNER JOIN production.tcellopt B ON A.Device_ID = B.Device_ID " & Environment.NewLine
                strSql &= "WHERE SN = '" & strIMEI & "'; " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function GetWIPOpenDeviceBoxID(ByVal strIMEI As String) As DataTable
            Dim strSql As String
            Try
                strSql = "SELECT OrderNo as 'Order#', BoxID as 'Box ID', Manuf_Date as 'Manuf Date', Workstation as 'Current Station' " & Environment.NewLine
                strSql &= "FROM edi.titem A  " & Environment.NewLine
                strSql &= "INNER JOIN production.tcellopt B ON A.Device_ID = B.Device_ID " & Environment.NewLine
                strSql &= "WHERE SN = '" & strIMEI & "' AND A.wipCompletionDate IS NULL; "
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function ChangeToFuncModel(ByVal iDeviceID As Integer, _
         ByVal strModelDesc As String, _
         ByVal iModelID As Integer) As Integer
            Dim strSql As String
            Dim iFuncModelID As Integer = 0

            Try
                ChangeToFuncModel = 0

                If strModelDesc.Trim.ToUpper.EndsWith("_FUN") = False Then
                    strModelDesc = strModelDesc & "_FUN"
                    iFuncModelID = iModelID
                Else
                    strSql = "SELECT Model_ID " & Environment.NewLine
                    strSql &= "FROM tmodel  " & Environment.NewLine
                    strSql &= "WHERE Model_Desc = '" & strModelDesc & "'; " & Environment.NewLine
                    iFuncModelID = Me._objDataProc.GetIntValue(strSql)
                End If

                If iFuncModelID = 0 Then Throw New Exception("Function version of this model (" & strModelDesc & ") is missing.")

                strSql = "UPDATE tdevice, edi.titem" & Environment.NewLine
                strSql &= "SET Model_ID = " & iFuncModelID & Environment.NewLine
                strSql &= ", FuncRep = 1 " & Environment.NewLine
                strSql &= "WHERE tdevice.Device_ID = edi.titem.Device_ID " & Environment.NewLine
                strSql &= "AND tdevice.Device_ID = " & iDeviceID & " ; " & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function GetBilledBatteryCoverQtyBoxes(ByVal strDateStart As String, _
           ByVal strDateEnd As String) As DataTable
            Dim strSql As String
            Dim dt, dt2 As DataTable
            Dim R1 As DataRow

            Try
                strSql = "SELECT Pallett_Name as 'Box', Pallett_ShipDate as 'Produced Date', pkslip_ID as 'Packing Slip ID' " & Environment.NewLine
                strSql &= ", '' as 'New Part #', '' as 'Use Part #', '' as 'RV Part #', Pallett_QTY as 'Box Qty'" & Environment.NewLine
                strSql &= ", count(N.BillCode_ID) as 'New Qty', count(U.BillCode_ID) as 'Use Qty', count(RV.BillCode_ID) as 'RV Qty' " & Environment.NewLine
                strSql &= "FROM tpallett INNER JOIN tdevice ON tpallett.Pallett_ID = tdevice.Pallett_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tdevicebill N ON tdevice.Device_ID = N.Device_ID AND N.billcode_id = 154 " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tdevicebill U ON tdevice.Device_ID = U.Device_ID AND U.billcode_id = 1869 " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tdevicebill RV ON tdevice.Device_ID = RV.Device_ID AND RV.billcode_id = 2510 " & Environment.NewLine
                strSql &= "WHERE Cust_ID = " & BuildShipPallet.TracFone_CUSTOMER_ID & Environment.NewLine
                strSql &= "AND Pallet_ShipType = 0 " & Environment.NewLine
                strSql &= "AND Pallett_ShipDate BETWEEN '" & strDateStart & "' AND '" & strDateEnd & "' " & Environment.NewLine
                strSql &= "GROUP BY Pallett_Name" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                strSql = "SELECT Distinct Pallett_Name as 'Box', Billcode_ID " & Environment.NewLine
                strSql &= ", IF(Part_Number is null, '', Part_Number) as Part_Number " & Environment.NewLine
                strSql &= "FROM tpallett INNER JOIN tdevice ON tpallett.Pallett_ID = tdevice.Pallett_ID " & Environment.NewLine
                strSql &= "INNER JOIN tdevicebill P ON tdevice.Device_ID = P.Device_ID AND P.billcode_id IN ( 154 , 1869, 2510 )" & Environment.NewLine
                strSql &= "WHERE Cust_ID = " & BuildShipPallet.TracFone_CUSTOMER_ID & Environment.NewLine
                strSql &= "AND Pallet_ShipType = 0 " & Environment.NewLine
                strSql &= "AND Pallett_ShipDate BETWEEN '" & strDateStart & "' AND '" & strDateEnd & "' " & Environment.NewLine
                dt2 = Me._objDataProc.GetDataTable(strSql)

                dt.Columns.Add(New DataColumn("Open Qty", System.Type.GetType("System.Int32")))

                For Each R1 In dt.Rows
                    R1.BeginEdit()
                    R1("Open Qty") = CInt(R1("Box Qty")) - (CInt(R1("New Qty")) + CInt(R1("Use Qty")) + CInt(R1("RV Qty")))
                    If dt2.Select("Box = '" & R1("Box") & "' AND Billcode_ID = 154").Length > 0 Then R1("New Part #") = dt2.Select("Box = '" & R1("Box") & "' AND Billcode_ID = 154")(0)("Part_Number")
                    If dt2.Select("Box = '" & R1("Box") & "' AND Billcode_ID = 1869").Length > 0 Then R1("Use Part #") = dt2.Select("Box = '" & R1("Box") & "' AND Billcode_ID = 1869")(0)("Part_Number")
                    If dt2.Select("Box = '" & R1("Box") & "' AND Billcode_ID = 2510").Length > 0 Then R1("RV Part #") = dt2.Select("Box = '" & R1("Box") & "' AND Billcode_ID = 2510")(0)("Part_Number")
                    R1.EndEdit()
                Next R1

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                Generic.DisposeDT(dt)
                Generic.DisposeDT(dt2)
            End Try
        End Function
        Public Function GetOpenQtyOfBatteryCoverByBox() As DataTable
            Dim strSql As String
            Dim dt, dt2 As DataTable
            Dim i As Integer
            Dim dr(), R1 As DataRow

            Try
                strSql = "SELECT Distinct tpallett.Pallett_ID, Pallett_Name as 'Box', Pallett_ShipDate as 'Produced Date' " & Environment.NewLine
                strSql &= ", Concat(if(PN.PSPrice_Number is null, 'NotMap', PN.PSPrice_Number), '|', if(PU.PSPrice_Number is null, 'NotMap', PU.PSPrice_Number), '|', if(PRV.PSPrice_Number is null, 'NotMap', PRV.PSPrice_Number) ) as 'New/Use/RV Part' " & Environment.NewLine
                strSql &= " ,CASE WHEN MDL.has_bc = 0 THEN 'NBCR' WHEN MDL.has_bc = 1 AND PN.PSPrice_Number is null THEN '' ELSE PN.PSPrice_Number END AS 'New Part #' " & Environment.NewLine
                strSql &= " ,CASE WHEN MDL.has_bc = 0 THEN 'NBCR' WHEN MDL.has_bc = 1 AND PU.PSPrice_Number is null THEN '' ELSE PU.PSPrice_Number END AS 'Use Part #' " & Environment.NewLine
                strSql &= " ,CASE WHEN MDL.has_bc = 0 THEN 'NBCR' WHEN MDL.has_bc = 1 AND PRV.PSPrice_Number is null THEN '' ELSE PRV.PSPrice_Number END AS 'RV Part #' " & Environment.NewLine
                'strSql &= ", if(PN.PSPrice_Number is null, '', PN.PSPrice_Number) as 'New Part #' " & Environment.NewLine
                'strSql &= ", if(PU.PSPrice_Number is null, '', PU.PSPrice_Number) as 'Use Part #' " & Environment.NewLine
                'strSql &= ", if(PRV.PSPrice_Number is null, '', PRV.PSPrice_Number) as 'RV Part #' " & Environment.NewLine
                strSql &= ", Pallett_QTY as 'Box Qty', Pallett_QTY as 'Open Qty'" & Environment.NewLine
                strSql &= ", 0 as 'New Qty', 0 as 'Use Qty', 0 as 'RV Qty'" & Environment.NewLine
                strSql &= ", MDL.has_bc " & Environment.NewLine
                strSql &= " FROM tpallett " & Environment.NewLine
                strSql &= " INNER JOIN tdevice ON tpallett.Pallett_ID = tdevice.Pallett_ID " & Environment.NewLine
                strSql &= " INNER JOIN tcellopt OPT ON tdevice.device_id = OPT.DEVICE_ID " & Environment.NewLine
                strSql &= " LEFT OUTER JOIN tmodel MDL ON tdevice.Model_id = MDL.model_id " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tpsmap N on tdevice.Model_id = N.Model_ID and N.BillCode_ID = 154 " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tpsmap U on tdevice.Model_id = U.Model_ID and U.BillCode_ID = 1869 " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tpsmap RV on tdevice.Model_id = RV.Model_ID and RV.BillCode_ID = 2510 " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lpsprice PN on N.PSPrice_ID = PN.PSPrice_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lpsprice PU on U.PSPrice_ID = PU.PSPrice_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lpsprice PRV on RV.PSPrice_ID = PRV.PSPrice_ID " & Environment.NewLine
                strSql &= "WHERE Cust_ID = " & BuildShipPallet.TracFone_CUSTOMER_ID & Environment.NewLine
                strSql &= "AND OPT.WORKSTATION = 'PRODUCTION COMPLETED' AND pkslip_ID is null AND Pallett_ShipDate is not null AND Pallet_ShipType = 0   " & Environment.NewLine
                'strSql &= "AND tpallett.WO_ID = 10642229 "
                'strSql &= "AND tpallett.pkslip_ID = 4882 "
                dt = Me._objDataProc.GetDataTable(strSql)

                '*****************************************************
                '1: Get billed new and use battery cover quantity
                '2: Calculate open quantity
                '*****************************************************
                For Each R1 In dt.Rows
                    dt2 = Me.GetBilledNewUseRVBatteryCoverQty(R1("Pallett_ID"))
                    If dt2.Rows.Count > 0 Then
                        R1.BeginEdit()
                        If dt2.Select("Billcode_ID = 154 ").Length > 0 Then R1("New Qty") = CInt(dt2.Select("Billcode_ID = 154 ")(0)("Qty"))
                        If dt2.Select("Billcode_ID = 1869 ").Length > 0 Then R1("Use Qty") = CInt(dt2.Select("Billcode_ID = 1869 ")(0)("Qty"))
                        If dt2.Select("Billcode_ID = 2510 ").Length > 0 Then R1("RV Qty") = CInt(dt2.Select("Billcode_ID = 2510 ")(0)("Qty"))
                        R1("Open Qty") = R1("Box Qty") - (CInt(R1("New Qty")) + CInt(R1("Use Qty")) + CInt(R1("RV Qty")))
                        R1.EndEdit()
                    End If
                Next R1


                '*************************************
                'Remove the one with zero open quatity
                '*************************************
                dr = dt.Select("[Open Qty] = 0")
                For i = 0 To dr.Length - 1
                    dt.Rows.Remove(dr(i))
                    dt.AcceptChanges()
                Next i
                '*************************************

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                dr = Nothing : R1 = Nothing
                Generic.DisposeDT(dt)
                Generic.DisposeDT(dt2)
            End Try
        End Function
        Public Function GetWSJ_for_nbcr_in_whrb() As DataTable
            ' GETS THE tcellopt_wstationjournal RECORDS WHERE THE DEVICES DO NOT REQUIRE 
            ' BATTERY COVERS AND THE BOX HAS BEEN THROUGH THE ASSIGN BATTERY COVER SCREEN.
            ' THIS IS BEING USED ON THE ASSIGN BATTERY COVER SCREEN TO REMOVE THE RECORDS 
            ' FROM THE LIST OF BOXES TO BE ASSIGNED BATTERY COVERS AND MOVED TO WH-RB.
            Dim _dt As DataTable
            Dim _sql As String = ""
            _sql &= "SELECT DISTINCT D.PALLETT_ID "
            _sql &= "FROM tdevice D "
            _sql &= "INNER JOIN tpallett P on D.pallett_id = P.pallett_id "
            _sql &= "INNER JOIN tmodel MDL on D.model_id = MDL.model_id "
            _sql &= "INNER JOIN tcellopt_wstationjournal WSJ on D.device_id = WSJ.device_id "
            _sql &= "WHERE WSJ.ToStation = 'WH-RB' AND WSJ.FormName = 'AssignBateryCover' "
            _sql &= "AND P.Cust_ID = " & BuildShipPallet.TracFone_CUSTOMER_ID.ToString() & " "
            _sql &= "AND pkslip_ID is null "
            _sql &= "AND Pallett_ShipDate is not null "
            _sql &= "AND Pallet_ShipType = 0 "
            _dt = Me._objDataProc.GetDataTable(_sql)
            Return _dt
        End Function
        Public Function Get_WHRB_Boxes(ByVal iCust_ID As Integer, Optional ByVal iPallet_ID As Integer = 0) As DataTable
            'Pallets, unshipped, Good Repaired Units, Workstation in WH-RB, TracFone
            Dim strSql As String
            Dim dt, dt2 As DataTable
            Dim row, row2 As DataRow

            Try
                strSql = "SELECT DISTINCT A.Pallett_Name AS 'Pallet Name',A.Pallett_ShipDate AS 'Produced Date',A.Pallett_QTY AS 'Box Qty'" & Environment.NewLine
                strSql &= " ,'' AS 'Bat. New Part',0 AS 'Bat. New Qty','' AS 'Bat. Use Part',0 AS 'Bat. Use Qty'" & Environment.NewLine
                strSql &= " ,'' AS 'Bat. RV Part',0 AS 'Bat. RV Qty',C.Workstation, A.Pallett_ID, M.HAS_BC" & Environment.NewLine
                strSql &= " FROM tpallett A" & Environment.NewLine
                strSql &= " INNER JOIN tdevice B ON A.Pallett_ID = B.Pallett_ID" & Environment.NewLine
                strSql &= " INNER JOIN tcellopt C ON B.Device_ID=C.Device_ID" & Environment.NewLine
                strSql &= " INNER JOIN TMODEL M ON A.MODEL_ID = M.MODEL_ID" & Environment.NewLine
                strSql &= " WHERE A.Cust_ID = " & iCust_ID & " AND C.Workstation='WH-RB'" & Environment.NewLine
                If iPallet_ID > 0 Then
                    strSql &= " AND A.Pallett_ID = " & iPallet_ID & Environment.NewLine
                End If
                strSql &= " AND A.pkslip_ID is null AND A.Pallett_ShipDate is not null AND A.Pallet_ShipType = 0;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                'assigned batteries data for each pallet
                For Each row In dt.Rows
                    iPallet_ID = row("pallett_id")
                    dt2 = GetAssignedBatteryData(iPallet_ID)
                    For Each row2 In dt2.Rows
                        row.BeginEdit()
                        If row2("BillCode_ID") = 154 Then
                            row("Bat. New Part") = row2("Part_Number")
                            row("Bat. New Qty") = row2("Battery Qty")
                        ElseIf row2("BillCode_ID") = 1869 Then
                            row("Bat. Use Part") = row2("Part_Number")
                            row("Bat. Use Qty") = row2("Battery Qty")
                        ElseIf row2("BillCode_ID") = 2510 Then
                            row("Bat. RV Part") = row2("Part_Number")
                            row("Bat. RV Qty") = row2("Battery Qty")
                        End If
                        row.AcceptChanges()
                    Next
                Next

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt) : Generic.DisposeDT(dt2)
            End Try
        End Function
        Public Function GetAssignedBatteryData(ByVal iPallet_ID As Integer) As DataTable
            'Assigned batteries for a pallet

            Dim strSql As String
            Dim dt As DataTable

            Try
                strSql = "SELECT B.BillCode_ID,C.BillCode_Desc" & Environment.NewLine
                strSql &= " ,IF(B.BillCode_ID=154, 'New',IF(B.BillCode_ID=1869, 'Use',IF(B.BillCode_ID=2510,'RV',''))) AS 'Battery'" & Environment.NewLine
                strSql &= " ,B.Part_Number,Count(B.BillCode_ID) AS 'Battery Qty'" & Environment.NewLine
                strSql &= " FROM tdevice A" & Environment.NewLine
                strSql &= " INNER JOIN tdevicebill B ON A.device_ID=B.device_ID" & Environment.NewLine
                strSql &= " INNER JOIN lbillcodes C ON B.BillCode_ID = C.BillCode_ID" & Environment.NewLine
                strSql &= " WHERE A.Pallett_ID=" & iPallet_ID & " AND B.BillCode_ID in (154,1869,2510)" & Environment.NewLine
                strSql &= " GROUP BY B.BillCode_ID,B.Part_Number,C.BillCode_Desc;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function
        Public Function GetAssignedBatteryDataDetails(ByVal iPallet_ID As Integer) As DataTable
            'Details: Assigned batteries for a pallet

            Dim strSql As String
            Dim dt As DataTable

            Try
                strSql = "SELECT B.DBill_ID,A.Device_ID,B.BillCode_ID,C.BillCode_Desc" & Environment.NewLine
                strSql &= " ,IF(B.BillCode_ID=154, 'New',IF(B.BillCode_ID=1869, 'Use',IF(B.BillCode_ID=2510,'RV',''))) AS 'Battery'" & Environment.NewLine
                strSql &= " ,B.Part_Number" & Environment.NewLine
                strSql &= " FROM tdevice A" & Environment.NewLine
                strSql &= " INNER JOIN tdevicebill B ON A.device_ID=B.device_ID" & Environment.NewLine
                strSql &= " INNER JOIN lbillcodes C ON B.BillCode_ID = C.BillCode_ID" & Environment.NewLine
                strSql &= " WHERE A.Pallett_ID=" & iPallet_ID & " AND B.BillCode_ID in (154,1869,2510);" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function
        Public Function UnassignBilledBatteryParts(ByVal strDeviceBilled_IDs As String) As Integer
            'Unassign batteries for devices, primary key DBill_ID in tdevicebill
            Dim strSql As String

            Try
                strSql = "DELETE FROM tdevicebill where DBill_ID in (" & strDeviceBilled_IDs & ");" & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Private Function GetBilledNewUseRVBatteryCoverQty(ByVal iPallettID As Integer) As DataTable
            Dim strSql As String
            Try
                strSql = "SELECT tdevicebill.Billcode_ID, count(*) as Qty " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID  " & Environment.NewLine
                strSql &= "WHERE Pallett_ID = " & iPallettID & Environment.NewLine
                strSql &= "AND Billcode_ID in ( 154, 1869, 2510 ) " & Environment.NewLine
                strSql &= "GROUP BY tdevicebill.Billcode_ID " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function GetOpenAndBilledBatteryCoverQtyInBox(ByVal strPalletName As String) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT tpallett.Pallett_ID, Pallett_Name , Pallett_ShipDate, pkslip_ID, Pallet_ShipType " & Environment.NewLine
                strSql &= ", Pallett_QTY as 'Box Qty'" & Environment.NewLine
                strSql &= ", if(PN.PSPrice_Number is null, '', PN.PSPrice_Number) as 'New Part #' " & Environment.NewLine
                strSql &= ", If(PU.PSPrice_Number is null, '', PU.PSPrice_Number) as 'Use Part #' " & Environment.NewLine
                strSql &= ", If(PRV.PSPrice_Number is null, '', PRV.PSPrice_Number) as 'RV Part #' " & Environment.NewLine
                strSql &= ", has_bc as 'Has BC'" & Environment.NewLine
                strSql &= ", count(BN.BillCode_ID) as 'Billed New Qty' " & Environment.NewLine
                strSql &= ", count(BU.BillCode_ID) as 'Billed Use Qty' " & Environment.NewLine
                strSql &= ", count(BRV.BillCode_ID) as 'Billed RV Qty' " & Environment.NewLine
                strSql &= "FROM tpallett INNER JOIN tdevice ON tpallett.Pallett_ID = tdevice.Pallett_ID " & Environment.NewLine
                strSql &= " LEFT OUTER JOIN tmodel MDL ON tdevice.Model_id = MDL.model_id " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tdevicebill BN ON tdevice.Device_ID = BN.Device_ID AND BN.billcode_id = 154 " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tdevicebill BU ON tdevice.Device_ID = BU.Device_ID AND BU.billcode_id = 1869 " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tdevicebill BRV ON tdevice.Device_ID = BRV.Device_ID AND BRV.billcode_id = 2510 " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tpsmap N on tdevice.Model_id = N.Model_ID and N.BillCode_ID = 154 " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tpsmap U on tdevice.Model_id = U.Model_ID and U.BillCode_ID = 1869 " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tpsmap RV on tdevice.Model_id = RV.Model_ID and RV.BillCode_ID = 2510 " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lpsprice PN on N.PSPrice_ID = PN.PSPrice_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lpsprice PU on U.PSPrice_ID = PU.PSPrice_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lpsprice PRV on RV.PSPrice_ID = PRV.PSPrice_ID " & Environment.NewLine
                strSql &= "WHERE Cust_ID = " & BuildShipPallet.TracFone_CUSTOMER_ID & Environment.NewLine
                strSql &= "AND Pallett_Name = '" & strPalletName & "'" & Environment.NewLine
                strSql &= "GROUP BY Pallett_Name "
                strSql &= ", has_bc " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function GetNoneBatteryBilledDeviceID(ByVal iPallettID As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT Distinct tdevice.Device_ID, tdevice.Model_ID " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID AND tdevicebill.billcode_id IN ( 154, 1869, 2510 ) " & Environment.NewLine
                strSql &= "WHERE Pallett_ID = " & iPallettID & Environment.NewLine
                strSql &= "AND DBill_ID is null" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function CreateBERInvoiceTransaction(ByVal iPalletID As Integer) As Integer
            Dim strSql As String = ""
            Try
                strSql = "INSERT INTO tracfoneberbox ( Pallett_ID, InsertDate, InvoiceDate ) VALUES (" & iPalletID & ", now(), now() ) ; " & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function IsNoPSDNeeded(ByVal iModelID As Integer) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim booResult As Boolean = False
            Dim strModelsArr() As String
            Dim i As Integer

            Try
                strSql = "SELECT * FROM exceptioncriteria WHERE Description = 'SKIP_PSD'  AND Active = 1" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    strModelsArr = dt.Rows(0)("ModelIDs").ToString.Split(",")

                    For i = 0 To strModelsArr.Length - 1
                        If strModelsArr(i).Trim.Equals(iModelID.ToString) Then
                            booResult = True : Exit For
                        End If
                    Next i
                End If

                Return booResult
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function
        Public Function IsNoSoftwareRefNeeded(ByVal iModelID As Integer) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim booResult As Boolean = False
            Dim strModelsArr() As String
            Dim i As Integer

            Try
                strSql = "SELECT * FROM exceptioncriteria WHERE Description = 'SKIP_SWREF' AND Active = 1" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    strModelsArr = dt.Rows(0)("ModelIDs").ToString.Split(",")

                    For i = 0 To strModelsArr.Length - 1
                        If strModelsArr(i).Trim.Equals(iModelID.ToString) Then
                            booResult = True : Exit For
                        End If
                    Next i
                End If

                Return booResult
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        Public Function IsTriageNeeded(ByVal iModelID As Integer) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim booResult As Boolean = False
            Dim i As Integer

            Try
                strSql = "SELECT * FROM production.tmodel WHERE Model_ID = " & iModelID
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 AndAlso dt.Rows(0).Item("IsTriaged") = 1 Then
                    booResult = True
                End If

                Return booResult
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        Public Function IsBuffable(ByVal iModelID As Integer) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim booResult As Boolean = False
            Dim strModelsArr() As String
            Dim i As Integer

            Try
                strSql = "SELECT * FROM exceptioncriteria WHERE Description = 'BUFFABLE' AND Active = 1" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    strModelsArr = dt.Rows(0)("ModelIDs").ToString.Split(",")

                    For i = 0 To strModelsArr.Length - 1
                        If strModelsArr(i).Trim.Equals(iModelID.ToString) Then
                            booResult = True : Exit For
                        End If
                    Next i
                End If

                Return booResult
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function
        Public Shared Function IsLCDDisplayBillcodeID(ByVal iBillcodeID As Integer) As Boolean
            Const strDesc As String = "TF_LCD_DISPLAY_BILLCODE_IDs"
            Dim dt As DataTable
            Dim booResult As Boolean = False
            Dim strModelsArr() As String
            Dim i As Integer

            Try
                dt = ModManuf.GetExceptionCriteria(strDesc)
                If dt.Rows.Count > 0 Then
                    strModelsArr = dt.Rows(0)("BillcodeIDs").ToString.Split(",")

                    For i = 0 To strModelsArr.Length - 1
                        If strModelsArr(i).Trim.Equals(iBillcodeID.ToString) Then
                            booResult = True : Exit For
                        End If
                    Next i
                End If

                Return booResult
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function
        Public Function GetWHBox(ByVal strBoxID As String, Optional ByVal iOrderID As Integer = 0) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT A.* FROM edi.twarehousebox A " & Environment.NewLine
                strSql &= "WHERE A.BoxID = '" & strBoxID & "' " & Environment.NewLine
                If iOrderID > 0 Then strSql &= "AND A.Order_ID = " & iOrderID
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function GetDevicesInWHBox(ByVal BoxID As String, Optional ByVal iOrderID As Integer = 0, Optional ByVal strSN As String = "") As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT A.Device_ID, A.SN, A.OrderNo, A.BoxID, A.Manuf_Date, B.Workstation, C.Model_ID, D.Manuf_ID " & Environment.NewLine
                strSql &= "FROM edi.titem A  " & Environment.NewLine
                strSql &= "INNER JOIN production.tcellopt B ON A.Device_ID = B.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN production.tdevice C ON A.Device_ID = C.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN production.tmodel D ON C.Model_ID = D.Model_ID " & Environment.NewLine
                strSql &= "WHERE BoxID = '" & BoxID & "' " & Environment.NewLine
                If iOrderID > 0 Then strSql &= "AND Order_ID = " & iOrderID & Environment.NewLine
                If strSN.Trim.Length > 0 Then strSql &= "AND A.SN = '" & strSN & "'"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function CompletedBERScreenBox(ByVal strBoxID As String, ByVal iOrderID As Integer, ByVal iModelID As Integer, ByVal iUserID As Integer _
           , ByVal strScreenName As String, ByVal strFormName As String) As Integer
            Const iTestTypeID As Integer = 16
            Dim strSql, strDevices, strNewBox, strWorkStation As String
            Dim dtOrgBox, dtNewBox, dtDevices, dtWSJournal As DataTable
            Dim drPassBerScreen(), drFailBerScreen(), R1 As DataRow
            Dim objTFRec As New TracFone.Receive()
            Dim i, j, iNewWHBoxID, iNextSeqNo As Integer

            Try
                ' If the box is functional and tagged in the tmodel table as sw_process 
                ' then move to SW SCREEN.
                Dim _model_type As Integer = IIf(Mid(strBoxID, 1, 1) = "F", 1, 0)
                If _objModelManuf.IsKillSwitchModel(iModelID) AndAlso _model_type = 1 Then
                    strWorkStation = "SW SCREEN"
                ElseIf Me.IsBuffable(iModelID) Then
                    strWorkStation = "PRE-BUFF"
                Else
                    strWorkStation = "WH-WIP"
                End If

                dtOrgBox = GetWHBox(strBoxID, iOrderID)
                If dtOrgBox.Rows.Count = 0 Then Throw New Exception("Invalid box " & strBoxID & ".")

                'Get devices in box
                dtDevices = Me.GetDevicesInWHBox(strBoxID, iOrderID)
                If dtDevices.Rows.Count = 0 Then Throw New Exception("Box " & strBoxID & " is empty.")

                dtWSJournal = New DataTable()
                dtWSJournal = dtDevices.Clone

                If dtDevices.Select("Workstation <> 'BER SCREEN'").Length > 0 Then
                    strNewBox = Microsoft.VisualBasic.Left(strBoxID, 11)

                    iNextSeqNo = GetWHBoxNexSeqNo(strNewBox, _iWHBoxSegDigitCnt)
                    If iNextSeqNo = 0 Then Throw New Exception("System has failed to get next box number.")
                    strNewBox = strNewBox & iNextSeqNo.ToString.PadLeft(_iWHBoxSegDigitCnt, "0")

                    dtNewBox = Me.GetWHBox(strNewBox, dtOrgBox.Rows(0)("Order_ID"))
                    If dtNewBox.Rows.Count = 0 Then
                        iNewWHBoxID = InsertEdiWarehouseBox(strNewBox, dtOrgBox.Rows(0)("FuncRep"), dtOrgBox.Rows(0)("WarrantyFlag"), dtOrgBox.Rows(0)("Order_ID"), dtOrgBox.Rows(0)("Model_ID"), dtOrgBox.Rows(0)("WrtyExpedite"), 0)
                        If iNewWHBoxID = 0 Then Throw New Exception("System has failed to create new box.")
                    Else
                        iNewWHBoxID = dtNewBox.Rows(0)("wb_id")
                    End If
                End If

                'Move BER SCREEN unit to WH-WIP
                drPassBerScreen = dtDevices.Select("Workstation = 'BER SCREEN'")
                strDevices = ""
                For i = 0 To drPassBerScreen.Length - 1
                    If strDevices.Trim.Length > 0 Then strDevices &= ", "
                    strDevices &= drPassBerScreen(i)("Device_ID").ToString

                    R1 = dtWSJournal.NewRow
                    R1("Device_ID") = drPassBerScreen(i)("Device_ID") : R1("Workstation") = drPassBerScreen(i)("Workstation")
                    dtWSJournal.Rows.Add(R1)
                Next i

                dtWSJournal.AcceptChanges()

                If strDevices.Trim.Length > 0 Then
                    strSql = "UPDATE tcellopt SET Workstation = '" & strWorkStation & "' WHERE Device_ID in ( " & strDevices & ");"
                    j = Me._objDataProc.ExecuteNonQuery(strSql)
                    If j = 0 Then Throw New Exception("System has failed to move unit to " & strWorkStation & ".")

                    'REMOVE BER SCREEN TEST RECORD: should never happen but in case we want to have only one record.
                    strSql = "DELETE FROM ttestdata " & Environment.NewLine
                    strSql &= "WHERE Device_ID in ( " & strDevices & " ) AND Test_ID = " & iTestTypeID
                    j = Me._objDataProc.ExecuteNonQuery(strSql)

                    'write into workstation journal
                    Generic.SetTcelloptWorkstationJournal(dtWSJournal, iUserID, strWorkStation, strScreenName, strFormName)
                End If

                'Move none BER SCREEN to different box.
                If iNewWHBoxID > 0 Then
                    drFailBerScreen = dtDevices.Select("Workstation <> 'BER SCREEN'")
                    strDevices = ""
                    For i = 0 To drFailBerScreen.Length - 1
                        If strDevices.Trim.Length > 0 Then strDevices &= ", "
                        strDevices &= drFailBerScreen(i)("Device_ID").ToString
                    Next i
                    If strDevices.Length > 0 Then
                        strSql = "UPDATE edi.titem " & Environment.NewLine
                        strSql &= "SET BoxID = '" & strNewBox & "' " & Environment.NewLine
                        strSql &= ", wb_id = " & iNewWHBoxID & " " & Environment.NewLine
                        strSql &= "WHERE Device_ID in ( " & strDevices & ");"
                        j = Me._objDataProc.ExecuteNonQuery(strSql)
                        If j = 0 Then Throw New Exception("System has failed to move unit to a different box.")

                        'REMOVE BER SCREEN TEST RECORD: should never happen but in case we want to have only one record.
                        strSql = "DELETE FROM ttestdata " & Environment.NewLine
                        strSql &= "WHERE Device_ID in ( " & strDevices & " ) AND Test_ID = " & iTestTypeID
                        Me._objDataProc.ExecuteNonQuery(strSql)
                    End If
                End If

                'Record fail BER Screen
                If Not IsNothing(drFailBerScreen) Then
                    For i = 0 To drFailBerScreen.Length - 1
                        Me.WriteTestResult(drFailBerScreen(i)("Device_ID"), iTestTypeID, iUserID, 0, 2, , , , , , , , )
                    Next i
                End If

                'Record pass BER Screen
                If Not IsNothing(drPassBerScreen) Then
                    For i = 0 To drPassBerScreen.Length - 1
                        Me.WriteTestResult(drPassBerScreen(i)("Device_ID"), iTestTypeID, iUserID, 0, 1, , , , , , , , )
                    Next i
                End If

                MessageBox.Show("Devices have been pushed to " & strWorkStation & " workstation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

                'Print box lablel
                objTFRec.ReprintWHBox(strBoxID)

                Return j
            Catch ex As Exception
                Throw ex
            Finally
                objTFRec = Nothing
                Generic.DisposeDT(dtOrgBox) : Generic.DisposeDT(dtNewBox) : Generic.DisposeDT(dtDevices)
            End Try
        End Function
        Public Function InsertEdiWarehouseBox(ByVal strBoxID As String, ByVal iFuncRep As Integer, ByVal iWrtyFlag As Integer _
          , ByVal iOrderID As Integer, ByVal iModelID As Integer, ByVal iWrtyExpedite As Integer, ByVal iClosed As Integer _
          , Optional ByVal strBoxStage As String = "") As Integer
            Dim strSql As String = ""

            Try
                strSql = "INSERT INTO edi.twarehousebox ( BoxID, FuncRep, WarrantyFlag, Order_ID, Model_ID, WrtyExpedite, closed " & Environment.NewLine
                If strBoxStage.Trim.Length > 0 Then strSql &= ",BoxStage" & Environment.NewLine
                strSql &= ") VALUES ( " & Environment.NewLine
                strSql &= "'" & strBoxID & "'" & Environment.NewLine
                strSql &= ", " & iFuncRep & Environment.NewLine
                strSql &= ", " & iWrtyFlag & Environment.NewLine
                strSql &= ", " & iOrderID & Environment.NewLine
                strSql &= ", " & iModelID & Environment.NewLine
                strSql &= ", " & iWrtyExpedite & Environment.NewLine
                strSql &= ", " & iClosed & Environment.NewLine
                If strBoxStage.Trim.Length > 0 Then strSql &= ", '" & strBoxStage & "'" & Environment.NewLine
                strSql &= "); " & Environment.NewLine
                Return Me._objDataProc.idTransaction(strSql, "edi.twarehousebox")

            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function GetPlannedShipment(ByVal strDateStart As String, ByVal strDateEnd As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT A.*, B.User_FullName FROM reports.TF_PlannedShipmentNotification A" & Environment.NewLine
                strSql &= "INNER JOIN security.tusers B ON A.PS_UserID = B.User_ID" & Environment.NewLine
                strSql &= "WHERE PS_DT BETWEEN '" & strDateStart & " 00:00:00' AND '" & strDateEnd & " 23:59:59' " & Environment.NewLine
                strSql &= "ORDER BY PS_DT DESC "
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function CreatePlannedShipment(ByVal iUserID As Integer) As Integer
            Dim strSql As String = ""
            Try
                strSql = "INSERT INTO reports.TF_PlannedShipmentNotification ( PS_DT, PS_UserID " & Environment.NewLine
                strSql &= ") VALUES ( " & Environment.NewLine
                strSql &= " now(), " & iUserID & Environment.NewLine
                strSql &= ") "
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function SetPreBuff(ByVal dtDevices As DataTable, ByVal drArrListPassBuff As ArrayList, ByVal strBoxName As String, _
           ByVal strNextStation As String, ByVal iTestTypeID As Integer, ByVal iUserID As Integer, _
           ByVal strScreenName As String, ByVal strFormName As String) As Integer
            Dim strSql As String = ""
            Dim i As Integer, iResult As Integer
            Dim R1 As DataRow
            Dim dt As DataTable

            Try
                If strBoxName.Trim.Length = 0 Then Throw New Exception("Box ID is empty. Can't set workstation.")

                'Get devices for workstation journal
                strSql = "SELECT tcellopt.Device_ID, Workstation FROM tcellopt INNER JOIN edi.titem ON tcellopt.Device_ID = edi.titem.Device_ID" & Environment.NewLine
                strSql &= "WHERE edi.titem.BoxID = '" & strBoxName & "'" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count = 0 Then Throw New Exception("System can't find a list of device(s) for workstation journal.")

                For Each R1 In dtDevices.Rows
                    If Not IsNothing(drArrListPassBuff) AndAlso drArrListPassBuff.IndexOf(R1("Device_ID")) >= 0 Then iResult = 1 Else iResult = 2

                    Me.WriteTestResult(R1("Device_ID"), iTestTypeID, iUserID, 0, iResult, , , , , , , , )
                Next R1

                strSql = "UPDATE tcellopt INNER JOIN edi.titem ON tcellopt.Device_ID = edi.titem.Device_ID" & Environment.NewLine
                strSql &= "SET WorkStation = '" & strNextStation & "'" & Environment.NewLine
                strSql &= ", WorkStationEntryDt = now(), WIL_ID = 0" & Environment.NewLine
                strSql &= "WHERE edi.titem.BoxID = '" & strBoxName & "'" & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)
                If i = 0 Then Throw New Exception("System has failed to set next workstation.")

                i += Generic.SetTcelloptWorkstationJournal(dt, iUserID, strNextStation, strScreenName, strFormName)

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt) : Generic.DisposeDT(dtDevices) : drArrListPassBuff = Nothing
            End Try
        End Function
        Public Function RemoveTestDataRecords(ByVal strDeviceIDs As String, ByVal iTestTypeID As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "DELETE FROM ttestdata WHERE Device_ID in ( " & strDeviceIDs & " ) AND Test_ID = " & iTestTypeID & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function GetBuffBillcode(ByVal iModelID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable, dtMapBillcode As DataTable

            Try
                dt = ModManuf.GetExceptionCriteria("BUFFABLE")
                If dt.Rows.Count = 0 Then
                    Throw New Exception("Can't define bill code.")
                ElseIf dt.Rows.Count > 1 Then
                    Throw New Exception("Duplicate record for buffable criteria.")
                Else
                    strSql = "SELECT DISTINCT lbillcodes.BillCode_ID, lbillcodes.BillCode_Desc, lpsprice.PSPrice_AvgCost, lpsprice.PSPrice_StndCost, lpsprice.PSPrice_Number " & Environment.NewLine
                    strSql &= "FROM tpsmap " & Environment.NewLine
                    strSql &= "INNER JOIN lbillcodes ON tpsmap.Billcode_ID = lbillcodes.billcode_ID" & Environment.NewLine
                    strSql &= "INNER JOIN lpsprice ON tpsmap.PSPrice_ID = lpsprice.PSPrice_ID" & Environment.NewLine
                    strSql &= "WHERE lbillcodes.Billcode_ID IN ( " & dt.Rows(0)("BillcodeIDs") & " ) " & Environment.NewLine
                    strSql &= "AND tpsmap.Model_ID = " & iModelID & Environment.NewLine
                    dtMapBillcode = Me._objDataProc.GetDataTable(strSql)
                End If

                Return dtMapBillcode
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function GetPreBuffPassedDevice() As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT ttestdata.Device_ID, ttestdata.QCResult_ID, tdevice.Model_ID FROM ttestdata " & Environment.NewLine
                strSql &= "INNER JOIN tdevice ON ttestdata.Device_ID = tdevice.Device_ID" & Environment.NewLine
                strSql &= "WHERE Test_ID = 15 " & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function GetAdminStationTranfer(ByVal booAddSelRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT B.wfp_ID as ID, B.wfp_Screenname as 'Desc', B.wfp_FrStation, B.wfp_ToStation, A.* " & Environment.NewLine
                strSql &= "FROM tracfoneadminstationtransf A INNER JOIN lworkflowprocess B ON A.wfp_ID = B.wfp_ID" & Environment.NewLine
                strSql &= "WHERE A.Active = 1 ORDER BY B.wfp_Screenname " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If booAddSelRow Then dt.LoadDataRow(New Object() {"0", "--Select--"}, True)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function RemoveWarehouseBox(ByVal iDeviceID As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "UPDATE edi.titem SET BoxID = '', wb_id = 0 " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function CreateWHBoxAndTransferToNewStation(ByVal dtDevs As DataTable, ByVal strNextStation As String, ByVal strAcceptableStation As String _
           , ByVal iuserID As Integer, ByVal strScreenname As String, ByVal strFormName As String) As Integer
            Dim strSql As String = "", strAllowStation() As String, strDeviceIDs As String = "", strToday As String = "", strBoxID As String, strModelDesc As String
            Dim dt, dtAcptedStation As DataTable
            Dim R1 As DataRow
            Dim i As Integer, iNextSeqNo As Integer = 1, iWHBoxID, iModelID, iFunc As Integer
            Dim objTFRec As TracFone.Receive

            Try
                strToday = Generic.MySQLServerDateTime(1)
                '*******************************************
                '1: Define Acceptable Workstation
                '*******************************************
                dtAcptedStation = New DataTable()
                dtAcptedStation.Columns.Add(New DataColumn("WorkStation", System.Type.GetType("System.String", False, True)))
                strAllowStation = strAcceptableStation.Split("|")
                For i = 0 To strAllowStation.Length - 1
                    If strAllowStation(i).Trim.Length > 0 Then
                        R1 = dtAcptedStation.NewRow
                        R1("WorkStation") = strAllowStation(i).Trim.ToLower
                        dtAcptedStation.Rows.Add(R1)
                    End If
                Next i
                dtAcptedStation.AcceptChanges()

                '*******************************************
                '2: Validate Devices
                '*******************************************
                For Each R1 In dtDevs.Rows
                    If strDeviceIDs.Length > 0 Then strDeviceIDs &= ", "
                    strDeviceIDs &= R1("Device_ID")
                Next R1

                strSql = "SELECT Distinct A.Model_ID, E.Model_Desc, A.Device_SN, WorkStation, Pallett_ID, Device_Dateship, Max(BillCode_Rule ) as MaxBillRule " & Environment.NewLine
                strSql &= "FROM tdevice A INNER JOIN tcellopt B ON A.Device_ID = B.Device_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tdevicebill C ON A.Device_ID = C.Device_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lbillcodes D ON C.Billcode_ID = D.Billcode_ID " & Environment.NewLine
                strSql &= "INNER JOIN tmodel E ON A.Model_ID = E.Model_ID " & Environment.NewLine
                strSql &= "WHERE A.Device_ID IN ( " & strDeviceIDs & " )" & Environment.NewLine
                strSql &= "GROUP BY A.Device_ID "
                dt = Me._objDataProc.GetDataTable(strSql)
                For Each R1 In dt.Rows
                    If Not IsDBNull(R1("Pallett_ID")) AndAlso CInt(R1("Pallett_ID")) > 0 Then
                        Throw New Exception("SN '" & R1("Device_SN").ToString & "' has already assigned to a pallet.")
                    ElseIf Not IsDBNull(R1("Device_Dateship")) Then
                        Throw New Exception("SN '" & R1("Device_SN").ToString & "' has been shipped.")
                    ElseIf Not IsDBNull(R1("MaxBillRule")) AndAlso CInt(R1("MaxBillRule")) > 0 Then
                        Throw New Exception("SN '" & R1("Device_SN").ToString & "' has been shipped.")
                    ElseIf R1("WorkStation").ToString.Trim.Length = 0 Then
                        Throw New Exception("SN '" & R1("Device_SN").ToString & "' does not belong to any workstation.")
                    ElseIf dtAcptedStation.Select("WorkStation = '" & R1("WorkStation").ToString.Trim.ToLower & "'").Length = 0 Then
                        Throw New Exception("Not accept any unit from '" & R1("WorkStation").ToString & "' workstation for SN " & R1("Device_SN").ToString & "'.")
                    End If
                Next R1

                iModelID = CInt(dtDevs.Rows(0)("Model_ID"))
                strModelDesc = dt.Rows(0)("Model_Desc").ToString

                If strModelDesc.Trim.ToUpper.EndsWith("_FUN") = True Then iFunc = 1 Else iFunc = 0

                '*******************************************
                '3: Create warehouse box
                '*******************************************
                If iFunc = 1 Then
                    strBoxID = "F" & CDate(strToday).ToString("yyyyMMdd") & "NN"
                Else
                    strBoxID = "C" & CDate(strToday).ToString("yyyyMMdd") & "NN"
                End If

                iNextSeqNo = GetWHBoxNexSeqNo(strBoxID, _iWHBoxSegDigitCnt)
                If iNextSeqNo = 0 Then Throw New Exception("System has failed to get next box number.")
                strBoxID = strBoxID & iNextSeqNo.ToString.PadLeft(_iWHBoxSegDigitCnt, "0")

                iWHBoxID = Me.InsertEdiWarehouseBox(strBoxID, iFunc, 0, 0, iModelID, 0, 1)
                If iWHBoxID = 0 Then Throw New Exception("System has failed to create new box.")

                '*******************************************
                '4: Get devices for workstation journal 
                '*******************************************
                strSql = "SELECT Device_ID, Workstation FROM tcellopt " & Environment.NewLine
                strSql &= "WHERE Device_ID in ( " & strDeviceIDs & " ) "
                dt = Me._objDataProc.GetDataTable(strSql)

                '*******************************************
                '5: Assign devices to new warehouse box
                '*******************************************
                strSql = "UPDATE edi.titem SET BoxID = '" & strBoxID & "', wb_id = " & iWHBoxID & Environment.NewLine
                strSql &= "WHERE Device_ID in ( " & strDeviceIDs & " ) "
                i = Me._objDataProc.ExecuteNonQuery(strSql)
                If i = 0 Then Throw New Exception("System has failed to assign units to the warehouse box.")

                strSql = "UPDATE tcellopt SET workstation = '" & strNextStation & "', WorkStationEntryDt = now() " & Environment.NewLine
                strSql &= "WHERE Device_ID in ( " & strDeviceIDs & " ) "
                i = Me._objDataProc.ExecuteNonQuery(strSql)
                If i = 0 Then Throw New Exception("System has failed to set new workstation.")

                '*******************************************
                '4: Write workstation journal 
                '*******************************************
                Generic.SetTcelloptWorkstationJournal(dt, iuserID, strNextStation, strScreenname, strFormName)

                '*******************************************
                '7: Print box
                '*******************************************
                objTFRec = New TracFone.Receive()


                If strNextStation = "SW HOLD" Then
                    objTFRec.PrintSwHoldWarehouseBoxID(strBoxID, strModelDesc, dtDevs.Rows.Count, "", iFunc, 0, 0)
                Else
                    objTFRec.PrintWarehouseBoxID(strBoxID, strModelDesc, dtDevs.Rows.Count, "", iFunc, 0, 0)
                End If

                '*******************************************

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                objTFRec = Nothing
                Generic.DisposeDT(dt) : Generic.DisposeDT(dtAcptedStation) : Generic.DisposeDT(dtDevs)
            End Try
        End Function
        Public Function GetWHBoxNexSeqNo(ByVal strBoxNamePreFix As String, ByVal iBoxSegDigitCnt As Integer) As Integer
            Dim strSql As String = ""
            Dim _sb As New StringBuilder()
            Dim iNextSeqNo As Integer
            Dim iNextSeqNo2 As Integer
            Dim dt As DataTable
            Dim dt2 As DataTable
            Dim _retVal As Integer
            Try
                ' GET THE MAX FROM THE TWAREHOUSEBOX TABLE.
                strSql = "SELECT max(right(BoxID, " & iBoxSegDigitCnt & " ) ) + 1 as NextSequenceNumber " & Environment.NewLine
                strSql &= "FROM edi.twarehousebox " & Environment.NewLine
                strSql &= "WHERE BoxID like '" & strBoxNamePreFix & "%' AND Length(BoxID) = " & (strBoxNamePreFix.Length + iBoxSegDigitCnt) & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 AndAlso Not IsDBNull(dt.Rows(0)("NextSequenceNumber")) Then
                    iNextSeqNo = CInt(dt.Rows(0)("NextSequenceNumber"))
                Else
                    iNextSeqNo = 1
                End If
                ' GET THE MAX FROM THE WH_BOX TABLE.
                _sb.Append("SELECT max(right(box_na, " & iBoxSegDigitCnt & " ) ) + 1 as NextSequenceNumber ")
                _sb.Append("FROM warehouse.wh_box ")
                _sb.Append("WHERE ")
                _sb.Append("box_na like '" & strBoxNamePreFix & "%' ")
                _sb.Append("AND ")
                _sb.Append("Length(box_na) = " & (strBoxNamePreFix.Length + iBoxSegDigitCnt) & " ")
                dt2 = Me._objDataProc.GetDataTable(_sb.ToString())
                If dt2.Rows.Count > 0 AndAlso Not IsDBNull(dt2.Rows(0)("NextSequenceNumber")) Then
                    iNextSeqNo2 = CInt(dt2.Rows(0)("NextSequenceNumber"))
                Else
                    iNextSeqNo2 = 1
                End If
                ' RETURN THE MAX NUMBER OF THE TWO TABLES.
                _retVal = IIf(iNextSeqNo > iNextSeqNo2, iNextSeqNo, iNextSeqNo2)
                Return _retVal
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

#End Region
#Region "TWSWScreening"

		Public Shared Function GetDeviceWS(ByVal device_id As Integer) As DataTable
			' THIS FUNCTION WILL GET THE DEVICE WORKSTATION FOR A SERIAL NUMBER.
			Dim _retVal As String = ""
			Dim _dt As New DataTable()
			Dim _sb As New StringBuilder()
			Dim _objDB As New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			_sb.Append("SELECT ")
			_sb.Append("d.device_id, ")
			_sb.Append("d.device_sn, ")
            _sb.Append("co.workstation, ")
            _sb.Append("d.model_id ")
			_sb.Append("FROM ")
			_sb.Append("tdevice d ")
			_sb.Append("LEFT JOIN tcellopt co on d.device_id = co.device_id ")
			_sb.Append("WHERE ")
			_sb.Append("d.device_id = ")
			_sb.Append(device_id.ToString() & " ")
			_sb.Append("; ")
			Try
				_dt = _objDB.GetDataTable(_sb.ToString())
				Return _dt
			Catch ex As Exception
				Throw ex
			Finally
				_objDB = Nothing
			End Try
		End Function
        Public Shared Function VerifyWBHasDevicesInWS(ByVal box_nr As String, ByVal cust_id As Integer, _
                                                      ByVal workstation As String) As Boolean
            ' VERIFIES THE BOX HAS DEVICES IN THE SPECIFIED WORKSTASTION FOR THE SPECIFIED CUSTOMER.
            Dim _dt As New DataTable()
            Dim _sb As New StringBuilder()
            Dim _objDB As New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            _sb.Append("SELECT ")
            _sb.Append("d.device_id, ")
            _sb.Append("d.device_sn, ")
            _sb.Append("co.workstation, ")
            _sb.Append("wb.order_id, ")
            _sb.Append("wb.boxid ")
            _sb.Append("FROM ")
            _sb.Append("tdevice d ")
            _sb.Append("INNER JOIN tlocation l ON d.loc_id = l.loc_id ")
            _sb.Append("INNER JOIN tcellopt co ON d.device_id = co.device_id ")
            _sb.Append("INNER JOIN edi.titem itm ON d.device_id = itm.device_id ")
            _sb.Append("INNER JOIN edi.twarehousebox wb ON itm.Boxid = wb.Boxid ")   'itm.order_id = wb.order_id ")
            _sb.Append("WHERE ")
            _sb.Append("wb.closed = 1 ")
            _sb.Append("AND ")
            _sb.Append("co.workstation = '")
            _sb.Append(workstation & "' ")
            _sb.Append("AND ")
            _sb.Append("itm.boxid = '")
            _sb.Append(box_nr & "' ")
            _sb.Append("AND ")
            _sb.Append("l.cust_id = '")
            _sb.Append(cust_id.ToString() & "' ")
            _sb.Append("; ")
            Try
                _dt = _objDB.GetDataTable(_sb.ToString())
                If _dt.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Return False
            Finally
                _dt.Dispose()
                _objDB = Nothing
            End Try
        End Function
        Public Shared Function GetWBDevices(ByVal box_nr As String) As DataTable
            ' THIS FUNCTION WILL GET ALL DEVICES ASSIGNED TO THE WAREHOUSE BOX.
            Dim _dt As New DataTable()
            Dim _sb As New StringBuilder()
            Dim _objDB As New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            _sb.Append("SELECT ")
            _sb.Append("d.device_id, ")
            _sb.Append("d.device_sn, ")
            _sb.Append("co.workstation, ")
            _sb.Append("itm.boxid ")
            _sb.Append("FROM ")
            _sb.Append("tdevice d ")
            _sb.Append("INNER JOIN tcellopt co ON d.device_id = co.device_id ")
            _sb.Append("INNER JOIN edi.titem itm ON d.device_id = itm.device_id ")
            _sb.Append("WHERE ")
            _sb.Append("itm.boxid = '")
            _sb.Append(box_nr & "' ")
            _sb.Append("; ")
            Try
                _dt = _objDB.GetDataTable(_sb.ToString())
                Return _dt
            Catch ex As Exception
                Throw ex
            Finally
                _dt.Dispose()
                _objDB = Nothing
            End Try
        End Function
        Public Shared Function GetWBDevicesUnProcessed(ByVal box_nr As String) As DataTable
            ' THIS FUNCTION WILL GET WAREHOUSE BOX DEVICES THAT HAVE NOT BEEN PROCESSED THROUGH THE SW SCREEN.
            Dim _dt As New DataTable()
            Dim _sb As New StringBuilder()
            Dim _objDB As New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            _sb.Append("SELECT ")
            _sb.Append("d.device_id, ")
            _sb.Append("d.device_sn, ")
            _sb.Append("co.workstation, ")
            _sb.Append("itm.boxid ")
            _sb.Append("FROM ")
            _sb.Append("tdevice d ")
            _sb.Append("INNER JOIN tcellopt co ON d.device_id = co.device_id ")
            _sb.Append("INNER JOIN edi.titem itm ON d.device_id = itm.device_id ")
            _sb.Append("LEFT JOIN production.tBoxDevicesInProcess bdip ON d.device_id = bdip.device_id ")
            _sb.Append("WHERE ")
            _sb.Append("itm.boxid = '")
            _sb.Append(box_nr & "' ")
            _sb.Append(" AND ")
            _sb.Append("bdip.to_ws IS NULL ")
            _sb.Append("; ")
            Try
                _dt = _objDB.GetDataTable(_sb.ToString())
                Return _dt
            Catch ex As Exception
                Throw ex
            Finally
                _dt.Dispose()
                _objDB = Nothing
            End Try
        End Function
        Public Shared Function GetWBDevicesPendingWS(ByVal box_nr As String, ByVal workstation As String) As DataTable
            ' THIS FUNCTION WILL GET WAREHOUSE BOX DEVICES THAT ARE PENDING A PARTICULAR WORKSTATION ASSIGNMENT.
            Dim _dt As New DataTable()
            Dim _sb As New StringBuilder()
            Dim _objDB As New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            _sb.Append("SELECT ")
            _sb.Append("device_sn, ")
            _sb.Append("device_ID ")
            _sb.Append("FROM ")
            _sb.Append("tBoxDevicesInProcess ")
            _sb.Append("WHERE ")
            _sb.Append("box_na = '")
            _sb.Append(box_nr & "' ")
            _sb.Append("AND ")
            _sb.Append("to_ws = '")
            _sb.Append(workstation & "' ")
            _sb.Append("; ")
            Try
                _dt = _objDB.GetDataTable(_sb.ToString())
                Return _dt
            Catch ex As Exception
                Throw ex
            Finally
                _dt.Dispose()
                _objDB = Nothing
            End Try
        End Function
        Public Shared Function IsDvcRdyToProcessForBx(ByVal box_nr As String, ByVal device_sn As String, ByVal workstation As String) As Boolean
            ' THIS FUNCTION WILL VERIFY DEVICE BELONGS TO THE A BOX.
            Dim _dt As New DataTable()
            Dim _sb As New StringBuilder()
            Dim _objDB As New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            _sb.Append("SELECT ")
            _sb.Append("d.device_id, ")
            _sb.Append("d.device_sn, ")
            _sb.Append("co.workstation, ")
            _sb.Append("itm.boxid, ")
            _sb.Append("dip.device_sn AS dip_device_sn, ")
            _sb.Append("dip.to_ws ")
            _sb.Append("FROM ")
            _sb.Append("tdevice d ")
            _sb.Append("INNER JOIN tlocation l ON d.loc_id = l.loc_id ")
            _sb.Append("INNER JOIN tcellopt co ON d.device_id = co.device_id ")
            _sb.Append("INNER JOIN edi.titem itm ON d.device_id = itm.device_id ")
            _sb.Append("LEFT JOIN production.tBoxDevicesInProcess dip ON d.device_id = dip.device_id ")
            _sb.Append("WHERE ")
            _sb.Append("co.workstation = '")
            _sb.Append(workstation & "' ")
            _sb.Append("AND ")
            _sb.Append("itm.boxid = '")
            _sb.Append(box_nr & "' ")
            _sb.Append("AND ")
            _sb.Append("d.device_sn = '")
            _sb.Append(device_sn & "' ")
            _sb.Append("; ")
            Try
                _dt = _objDB.GetDataTable(_sb.ToString())
                If _dt.Rows(0)("workstation") <> workstation Then
                    Throw New Exception("This device has been processed to the " & _dt.Rows(0)("workstation") & " workstation.")
                End If
                Return True
            Catch ex As Exception
                Throw ex
                Return False
            Finally
                _dt.Dispose()
                _objDB = Nothing
            End Try
        End Function
        Public Shared Function InsertBxDvcInProcess(ByVal box_na As String, ByVal device_id As Integer, ByVal device_sn As String, ByVal cur_ws As String, ByVal to_ws As String) As Integer
            ' THIS FUNCTION WILL INSERT A DEVICE RECORD INTO THE TBOXDEVICESINPROCESS TABLE.
            Dim _sb As New StringBuilder()
            Dim _result As Integer
            Dim _objDB As New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            _sb.Append("INSERT INTO tBoxDevicesInProcess( ")
            _sb.Append("box_na, ")
            _sb.Append("device_id, ")
            _sb.Append("device_sn, ")
            _sb.Append("cur_ws, ")
            _sb.Append("to_ws ")
            _sb.Append(") ")
            _sb.Append("VALUES ( '")
            _sb.Append(box_na & "', ")
            _sb.Append(device_id.ToString())
            _sb.Append(", '")
            _sb.Append(device_sn)
            _sb.Append("', '")
            _sb.Append(cur_ws & "', '")
            _sb.Append(to_ws & "' ")
            _sb.Append("); ")
            Try
                _result = _objDB.ExecuteScalarForInsert(_sb.ToString(), "tBoxDevicesInProcess")
                Return _result
            Catch ex As Exception
                Throw ex
            Finally
                _objDB = Nothing
            End Try
        End Function
        Public Shared Function RemovePendingDevice(ByVal sn_nr As String) As Boolean
            ' THIS FUNCTION REMOVES A DEVICE FROM THE TBOXDEVICESINPROCESS TABLE.
            Dim _sb As New StringBuilder()
            Dim _objDB As New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            _sb.Append("DELETE FROM ")
            _sb.Append("tboxdevicesinprocess ")
            _sb.Append("WHERE ")
            _sb.Append("device_sn = '")
            _sb.Append(sn_nr & "' ")
            _sb.Append("; ")
            Try
                _objDB.ExecuteNonQuery(_sb.ToString())
                Return True
            Catch ex As Exception
                Throw ex
                Return False
            Finally
                _objDB = Nothing
            End Try
        End Function
        Public Function SWScreenCloseBox(ByVal box_nr As String, ByVal user_id As Integer, ByVal pass_cnt As Integer, _
                                         ByVal fail_cnt As Integer) As Boolean ', ByVal bBuffable As Boolean) As Boolean
            ' THIS FUNCTION WILL CLOSE A BOX AND MOVE THE DEVICES AS APPROPRIATE.
            Dim _retVal As Boolean
            Dim _pushedCnt As Integer = 0
            Dim _failedCnt As Integer = 0
            Dim _toStation As String
            Dim _objTFRec As New PSS.Data.Buisness.TracFone.Receive()
            Try
                ' If bBuffable Then 'Hanel this after closed
                _toStation = GetToWSForWS("SW SCREEN") 'This will get PRE-BUFF 
                'Else
                '    _toStation = "WH-WIP"
                'End If
                If _toStation = "" Then
                    _retVal = False
                Else
                    If ChangeSWDeviceBoxNo(box_nr) Then
                        If pass_cnt > 0 Then
                            ' push rec box to next workstation.
                            _pushedCnt = PushWBBoxToWorkArea(box_nr, _toStation, user_id, "SW SCREEN", "TFSWScreenForBox")
                            ' Delete Box from tWBDevicesInProcess table.  
                            _retVal = RemoveBoxProcessedDevices(box_nr)
                        End If
                        If fail_cnt > 0 Then
                            ' push sw failed devices to SW FAIL.
                            _failedCnt = PushWBBoxToWorkArea(box_nr + "SW", "SW FAIL", user_id, "SW SCREEN", "TFSWScreenForBox")
                            ' The swf will remain in the table for now until moved to SW HOLD.
                        End If
                        ' print label if qty has changed.
                        If fail_cnt > 0 Then
                            _objTFRec.ReprintWHBox(box_nr)
                        End If
                        _retVal = True
                    Else
                        _retVal = False
                    End If
                End If
                Return _retVal
            Catch ex As Exception
                _retVal = False
                Return _retVal
            Finally
                _objTFRec = Nothing
            End Try
        End Function
        Public Shared Function GetToWSForWS(ByVal cur_ws As String) As String
            ' GET THE TOSTATION FIELD FROM THE LWORKFLOWPROCESS TABLE FOR THE CURRENT WORKSTATION.
            Dim _dt As New DataTable()
            Dim _sb As New StringBuilder()
            Dim _objDB As New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            _sb.Append("SELECT ")
            _sb.Append("wfp_tostation ")
            _sb.Append("FROM ")
            _sb.Append("lworkflowprocess wfp ")
            _sb.Append("WHERE ")
            _sb.Append("wfp.wfp_screenname = '")
            _sb.Append(cur_ws & "' ")
            _sb.Append("; ")
            Try
                _dt = _objDB.GetDataTable(_sb.ToString())
                If _dt.Rows.Count = 0 Then
                    Return ""
                Else
                    Return _dt.Rows(0)("wfp_tostation").ToString()
                End If
            Catch ex As Exception
                Throw ex
            Finally
                _dt.Dispose()
                _objDB = Nothing
            End Try
        End Function
        Private Function ChangeSWDeviceBoxNo(ByVal box_nr As String) As Boolean
            ' THIS FUNCTION WILL UPDATE THE BOX NUMBER FOR THE DEVICES THAT FAILED.
            ' THIS IS NOT A USABLE BOX OUTSIDE OF THIS SCREEN.
            Dim _sb As New StringBuilder()
            Dim _sb2 As New StringBuilder()
            Dim _objDB As New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            _sb.Append("UPDATE ")
            _sb.Append("tboxdevicesinprocess ")
            _sb.Append("SET ")
            _sb.Append("box_na = '")
            _sb.Append(box_nr & "SW' ")
            _sb.Append("WHERE ")
            _sb.Append("box_na = '")
            _sb.Append(box_nr & "' ")
            _sb.Append(" AND ")
            _sb.Append(" to_ws = 'SW FAIL' ")
            _sb.Append("; ")
            '
            _sb2.Append("UPDATE ")
            _sb2.Append("edi.titem itm ")
            _sb2.Append("INNER JOIN production.tboxdevicesinprocess bdip ON itm.device_id = bdip.device_id ")
            _sb2.Append("SET ")
            _sb2.Append("boxid = '")
            _sb2.Append(box_nr & "SW', ")
            _sb2.Append("wb_id = null ")
            _sb2.Append("WHERE ")
            _sb2.Append("itm.boxid = '")
            _sb2.Append(box_nr & "' ")
            _sb2.Append("AND ")
            _sb2.Append("bdip.to_ws = 'SW FAIL' ")
            _sb2.Append("; ")
            Try
                _objDB.ExecuteNonQuery(_sb.ToString())
                _objDB.ExecuteNonQuery(_sb2.ToString())
                Return True
            Catch ex As Exception
                Throw ex
                Return False
            Finally
                _objDB = Nothing
            End Try
        End Function
        Private Function RemoveBoxProcessedDevices(ByVal box_nr As String) As Boolean
            ' THIS FUNCTION WILL REMOVE PROCESSED DEVICES FROM THE TBOXDEVICESINPROCESS TABLE FOR A BOX.
            Dim _sb As New StringBuilder()
            Dim _objDB As New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            _sb.Append("DELETE FROM ")
            _sb.Append("tboxdevicesinprocess ")
            _sb.Append("WHERE ")
            _sb.Append("box_na = '")
            _sb.Append(box_nr & "' ")
            _sb.Append(" AND ")
            _sb.Append(" to_ws <> 'SW FAIL' ")
            _sb.Append("; ")
            Try
                _objDB.ExecuteNonQuery(_sb.ToString())
                Return True
            Catch ex As Exception
                Throw ex
                Return False
            Finally
                _objDB = Nothing
            End Try
        End Function
        Public Shared Function RemoveDvcFromSWFail(ByVal device_id As Integer) As Boolean
            ' THIS FUNCTION WILL REMOVED DEVICES THAT FAILED FROM THE TBOXDEVICESINPROCESS TABLE.
            Dim _sb As New StringBuilder()
            Dim _objDB As New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            _sb.Append("DELETE FROM ")
            _sb.Append("tboxdevicesinprocess ")
            _sb.Append("WHERE ")
            _sb.Append("device_id = ")
            _sb.Append(device_id.ToString() & " ")
            _sb.Append(" AND ")
            _sb.Append(" to_ws = 'SW FAIL' ")
            _sb.Append("; ")
            Try
                _objDB.ExecuteNonQuery(_sb.ToString())
                Return True
            Catch ex As Exception
                Throw ex
                Return False
            Finally
                _objDB = Nothing
            End Try
        End Function
        Public Shared Sub RemoveSWProcessQuestionsForDevice(ByVal device_id As Integer)
            ' THIS PROCUDURE WILL REMOVE ALL SOFTWARE PROCESS QUESTIONS FOR THE A DEVICE.
            Dim _sb As New StringBuilder()
            Dim _objDB As New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            _sb.Append("DELETE FROM ")
            _sb.Append("tdevice_question ")
            _sb.Append("WHERE ")
            _sb.Append("device_id = ")
            _sb.Append(device_id & " ")
            _sb.Append("; ")
            Try
                _objDB.ExecuteNonQuery(_sb.ToString())
            Catch ex As Exception
                Throw ex
            Finally
                _objDB = Nothing
            End Try
        End Sub
        Public Shared Sub InsertDeviceSWScreenJournalRecords(ByVal device_id As Integer, ByVal device_sn As String, ByVal incoming_box As String, ByVal outgoing_box As String, ByVal resolution As String, ByVal userid As Integer)
            ' THIS PROCUDURE WILL INSERT A NEW RECORD INTO THE TDEVICE_SWSCREEN_JOURNAL TABLE.
            'Dim _username As String = 
            'Dim _datetime As String = PSS.Data.Buisness.Security
            Try
                Dim _tdevice_swscreen_journal As New tdevice_swscreen_journal(0, incoming_box, _
                 outgoing_box, device_id, device_sn, resolution, userid.ToString(), Date.Now)
                _tdevice_swscreen_journal.ApplyChanges()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

#Region "FOR TECH REFURBISHED SCREEN."

        Public Function DoesDeviceRqrSWScreen(ByVal device_sn As String) As Boolean
            Dim _retVal As Boolean = True
            Dim _tdevice As New Data.BOL.tDevice(device_sn, False)
            Dim _model_id As Integer = 0


            ' Get device model id.
            _model_id = _tdevice.Model_ID
            ' Does Model require SW Screen.
            If _objModelManuf.IsKillSwitchModel(_model_id) Then
                ' Has software screen already been passed?
                'If HasDvcPassedSWScreen() Then
                '	_retVal = False
                'Else
                '	_retVal = True
                'End If
            Else
                _retVal = False
            End If
            Return _retVal
        End Function


#End Region

#End Region
#Region "TracFone NTF"
        Public Shared Function GetNTFDeviceBox(ByVal strBoxID As String, ByVal iCustID As Integer) As DataTable
            Dim strSql As String
            Dim dt As DataTable
            Dim _objDB As New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

            Try
                strSql = "SELECT A.Device_ID " & Environment.NewLine
                strSql &= "FROM edi.titem A " & Environment.NewLine
                strSql &= "INNER JOIN tdevice B ON B.Device_ID = A.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcellopt C ON C.Device_ID = A.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN tdevice_triaged_data D ON D.Device_ID = A.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN tlocation E ON E.Loc_ID = B.Loc_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcustomer F ON F.Cust_ID = E.Cust_ID " & Environment.NewLine
                strSql &= "WHERE A.BoxID = '" & strBoxID & "' " & Environment.NewLine
                strSql &= "AND F.Cust_ID = " & iCustID & Environment.NewLine
                strSql &= "AND FuncRep = 3 AND Incoming_NTF_Model_ID = 0; " & Environment.NewLine
                dt = _objDB.GetDataTable(strSql)

                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
                _objDB = Nothing
            End Try

        End Function

        Public Shared Function GetNTFDeviceID(ByVal iDeviceID As Integer, ByVal iCustID As Integer) As DataTable
            Dim strSql As String
            Dim dt As DataTable
            Dim _objDB As New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

            Try
                strSql = "SELECT A.Device_ID " & Environment.NewLine
                strSql &= "FROM edi.titem A " & Environment.NewLine
                strSql &= "INNER JOIN tdevice B ON B.Device_ID = A.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcellopt C ON C.Device_ID = A.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN tdevice_triaged_data D ON D.Device_ID = A.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN tlocation E ON E.Loc_ID = B.Loc_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcustomer F ON F.Cust_ID = E.Cust_ID " & Environment.NewLine
                strSql &= "WHERE A.Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "AND F.Cust_ID = " & iCustID & Environment.NewLine
                strSql &= "AND FuncRep = 3 AND Incoming_NTF_Model_ID = 0; " & Environment.NewLine
                dt = _objDB.GetDataTable(strSql)

                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
                _objDB = Nothing
            End Try

        End Function

#End Region
    End Class
End Namespace