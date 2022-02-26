Option Explicit On 

Imports CrystalDecisions.CrystalReports.Engine
Imports System.Text


Namespace Buisness

	Public Class MessReceive

		Private objMisc As Production.Misc
		Private _objDataProc As DBQuery.DataProc

		'***************************************************
		Public Sub New()
			objMisc = New Production.Misc()
			Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
		End Sub
		'***************************************************
		Protected Overrides Sub Finalize()
			objMisc = Nothing
			MyBase.Finalize()
		End Sub
		'***************************************************
		Private Sub NAR(ByVal o As Object)
			Try
				System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
			Catch
			Finally
				o = Nothing
			End Try
		End Sub

		'***************************************************
		Public Function GetAmeriMessDevInfo(ByVal strWO As String, _
							ByVal strSN As String) As DataTable
			Dim dt1 As DataTable
			Dim strSql As String = ""

			Try
				strSql = "Select * from tverdata where Device_SN = '" & strSN & "' and WO_Name = '" & strWO & "';"
				objMisc._SQL = strSql
				Return objMisc.GetDataTable
			Catch ex As Exception
				Throw ex
			Finally
				If Not IsNothing(dt1) Then
					dt1.Dispose()
					dt1 = Nothing
				End If
			End Try
		End Function

		'***************************************************
		Public Function GetMiscWOInfo(ByVal strWO As String, _
							 ByVal iCust_ID As Integer) As DataTable
			Dim strSql As String = ""

			Try
				strSql = "Select * from tmessmiscwodata where mmw_wo = '" & strWO & "' and cust_id = " & iCust_ID & ";"
				objMisc._SQL = strSql
				Return objMisc.GetDataTable

			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'***************************************************
		'Get Number of devices received for a WO
		'***************************************************
		Public Function GetWORcvdQty(ByVal iGWOID As Integer) As Integer
			Dim dt1 As DataTable
			Dim strSql As String = ""

			Try
				strSql = "Select Device_ID from tdevice where wo_id = " & iGWOID & ";"
				objMisc._SQL = strSql
				dt1 = objMisc.GetDataTable

				Return dt1.Rows.Count
			Catch ex As Exception
				Throw ex
			Finally
				If Not IsNothing(dt1) Then
					dt1.Dispose()
					dt1 = Nothing
				End If
			End Try
		End Function

		'***************************************************
		'Get purchase orders based on loc_ID
		'***************************************************
		Public Function GetPurchaseOrders(Optional ByVal iLoc_ID As Integer = 0) As DataTable
			Dim dt As DataTable
			Dim strSql As String = ""

			Try

				strSql = "select PO_id, PO_desc, Concat(PO_ID, '-', PO_Desc) as DisplayDesc from tpurchaseorder " & Environment.NewLine

				If iLoc_ID > 0 Then
					strSql &= "where loc_id = " & iLoc_ID & " "
				End If

				strSql &= "order by PO_desc;"

				objMisc._SQL = strSql
				dt = objMisc.GetDataTable

				InsertEmptyRow(dt, , "PO_id", "DisplayDesc", , , "-- Select --")

				Return dt
			Catch ex As Exception
				If Not IsNothing(dt) Then
					dt.Dispose()
					dt = Nothing
				End If
				Throw New Exception("Buisness.MessReceive.GetPurchaseOrders(): " & Environment.NewLine & ex.ToString)
			End Try
		End Function

		'***************************************************
		'Insert an empty row into the datatable
		'***************************************************
		Private Function InsertEmptyRow(ByRef dt As DataTable, _
										Optional ByVal iEmptyRowValue As Integer = 0, _
										Optional ByVal strFiledName1 As String = "", _
										Optional ByVal strFieldName2 As String = "", _
										Optional ByVal strFieldName3 As String = "", _
										Optional ByVal strFieldName4 As String = "", _
										Optional ByVal strEmptyRowDisplay As String = "")

			Dim R1 As DataRow

			Try
				R1 = dt.NewRow
				If strFiledName1 <> "" Then
					R1(strFiledName1) = iEmptyRowValue
				End If
				If strFieldName2 <> "" Then
					R1(strFieldName2) = strEmptyRowDisplay
				End If

				dt.Rows.Add(R1)
			Catch ex As Exception
				Throw New Exception("Buisness.MessReceive.InsertEmptyRow(): " & Environment.NewLine & ex.Message.ToString)
			Finally
				R1 = Nothing
			End Try
		End Function


        '***************************************************
        'Get workorder information for other messaging customers
        '***************************************************
        Public Function GetWOInfoOtherMessCustomer(ByVal strWO As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "Select " & Environment.NewLine
                strSql &= "tworkorder.WO_ID, " & Environment.NewLine
                strSql &= "tworkorder.WO_CustWO,  " & Environment.NewLine
                strSql &= "tworkorder.WO_Quantity,  " & Environment.NewLine
                strSql &= "tworkorder.WO_Memo,  " & Environment.NewLine
                strSql &= "tworkorder.WO_CameWithFile,  " & Environment.NewLine
                strSql &= "tworkorder.PO_ID,  " & Environment.NewLine
                strSql &= "tlocation.Loc_ID, " & Environment.NewLine
                strSql &= "tlocation.Loc_Name, " & Environment.NewLine
                strSql &= "tlocation.Loc_Address1, " & Environment.NewLine
                strSql &= "tlocation.Loc_Address2, " & Environment.NewLine
                strSql &= "tlocation.Loc_City, " & Environment.NewLine
                strSql &= "lstate.State_Short,  " & Environment.NewLine
                strSql &= "tlocation.Loc_Zip, " & Environment.NewLine
                strSql &= "lcountry.Cntry_Name,  " & Environment.NewLine
                strSql &= "tcustomer.Cust_Name1,  " & Environment.NewLine
                strSql &= "tpurchaseorder.PO_Desc, " & Environment.NewLine
                strSql &= "tcustomer.Cust_ID " & Environment.NewLine
                strSql &= "from tworkorder  " & Environment.NewLine
                strSql &= "inner join tlocation on tworkorder.loc_id = tlocation.Loc_ID  " & Environment.NewLine
                strSql &= "inner join tcustomer on tlocation.Cust_ID = tcustomer.Cust_ID  " & Environment.NewLine
                strSql &= "inner join lstate on tlocation.State_ID = lstate.State_ID  " & Environment.NewLine
                strSql &= "inner join lcountry on tlocation.Cntry_ID  = lcountry.Cntry_ID  " & Environment.NewLine
                strSql &= "left outer join tpurchaseorder on tworkorder.PO_ID = tpurchaseorder.PO_ID  " & Environment.NewLine

                strSql &= "Where tworkorder.WO_custWO = '" & strWO & "' " & Environment.NewLine
                strSql &= " and prod_id = 1;"

                objMisc._SQL = strSql
                Return objMisc.GetDataTable

            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '***************************************************
        'Get workorder information
        '***************************************************
        Public Function GetWOInfo(ByVal strWO As String, _
                ByVal iCust_id As Integer) As DataTable

            Dim strSql As String = ""

            Try
                strSql = "Select " & Environment.NewLine
                strSql &= "tworkorder.WO_ID, " & Environment.NewLine
                strSql &= "tworkorder.WO_CustWO,  " & Environment.NewLine
                strSql &= "tworkorder.WO_Quantity,  " & Environment.NewLine
                strSql &= "tworkorder.WO_Memo,  " & Environment.NewLine
                strSql &= "tworkorder.WO_CameWithFile,  " & Environment.NewLine
                strSql &= "tworkorder.PO_ID,  " & Environment.NewLine
                strSql &= "tlocation.Loc_ID, " & Environment.NewLine
                strSql &= "tlocation.Loc_Name, " & Environment.NewLine
                strSql &= "tlocation.Loc_Address1, " & Environment.NewLine
                strSql &= "tlocation.Loc_Address2, " & Environment.NewLine
                strSql &= "tlocation.Loc_City, " & Environment.NewLine
                strSql &= "lstate.State_Short,  " & Environment.NewLine
                strSql &= "tlocation.Loc_Zip, " & Environment.NewLine
                strSql &= "lcountry.Cntry_Name,  " & Environment.NewLine
                strSql &= "tcustomer.Cust_Name1,  " & Environment.NewLine
                strSql &= "tpurchaseorder.PO_Desc, " & Environment.NewLine
                strSql &= "tcustomer.Cust_ID " & Environment.NewLine
                strSql &= "from tworkorder  " & Environment.NewLine
                strSql &= "inner join tlocation on tworkorder.loc_id = tlocation.Loc_ID  " & Environment.NewLine
                strSql &= "inner join tcustomer on tlocation.Cust_ID = tcustomer.Cust_ID  " & Environment.NewLine
                strSql &= "inner join lstate on tlocation.State_ID = lstate.State_ID  " & Environment.NewLine
                strSql &= "inner join lcountry on tlocation.Cntry_ID  = lcountry.Cntry_ID  " & Environment.NewLine
                strSql &= "left outer join tpurchaseorder on tworkorder.PO_ID = tpurchaseorder.PO_ID  " & Environment.NewLine

                strSql &= "Where tworkorder.WO_custWO = '" & strWO & "' " & Environment.NewLine
                strSql &= " and tlocation.cust_id = " & iCust_id & Environment.NewLine
                strSql &= " and prod_id = 1;"

                objMisc._SQL = strSql
                Return objMisc.GetDataTable

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************
        'Create Baud number base on SKU
        '***************************************************
        Public Function CreateBaudRateFromSKU(ByVal strSKU As String) As String
            Dim strBaudNumber As String = ""
            Dim strSubStr As String = ""

            Try
                If Len(Trim(strSKU)) > 1 Then
                    If UCase(Mid(Trim(strSKU), 7, 2)) = "FL" Then       'Flex pager
                        strBaudNumber = "FLEX"
                    Else       'POCSAG logic
                        strSubStr = UCase(Mid(Trim(strSKU), 3, 1))

                        If strSubStr = "F" Then      'Pocsag 512
                            strBaudNumber = "POCSAG 512"
                        ElseIf strSubStr = "T" Then       'pocsag 1200
                            strBaudNumber = "POCSAG 1200"
                        ElseIf strSubStr = "4" Then       'pocsag 2400
                            strBaudNumber = "POCSAG 2400"
                        End If
                    End If
                End If

                Return strBaudNumber
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************
        'Get Baud_id
        '***************************************************
        Public Function GetBaudID(ByVal strBaudNumber As String) As Integer
            Dim strSql As String = ""
            Dim dt1 As DataTable

            Try
                strSql = "Select baud_id from lbaud where baud_Number = '" & strBaudNumber & "';"
                Me.objMisc._SQL = strSql
                dt1 = Me.objMisc.GetDataTable

                If dt1.Rows.Count = 0 Then
                    Throw New Exception("Baud number '" & strBaudNumber & "' does not exist in the system.")
                End If
                Return dt1.Rows(0)("baud_id")
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '***************************************************
        'Get freq_id base on chanel of sku
        '***************************************************
        Public Function GetFreqFromSKU(ByVal strSku As String) As DataRow
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim R1 As DataRow = Nothing
            Dim strChannel As String

            Try
                strChannel = Mid(strSku, 9, 3)
                strSql = "select freq_id, freq_number, freq_MotoCode from lchannel2frequency " & Environment.NewLine
                strSql &= "inner join lfrequency  on lfrequency.freq_Number  = lchannel2frequency.C2F_Frequency" & Environment.NewLine
                strSql &= "WHERE C2F_Channel = '" & strChannel & "';"
                Me.objMisc._SQL = strSql
                dt1 = Me.objMisc.GetDataTable

                If dt1.Rows.Count = 0 Then
                    'Throw New Exception("Can not find frequency number for channel '" & strChannel & ".")
                    'MsgBox("Can not find frequency number for channel '" & strChannel & ".", MsgBoxStyle.Information, "Get Frequency From SKU")
                Else
                    R1 = dt1.Rows(0)
                End If

                Return R1
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '***************************************************
        'Get freq_id
        '***************************************************
        Public Function GetFreqInfo(ByVal strFreq As String) As DataRow
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim R1 As DataRow = Nothing

            Try
                strSql = "select freq_id, freq_MotoCode from lfrequency " & Environment.NewLine
                strSql &= "WHERE lfrequency.freq_Number = '" & strFreq & "';"
                Me.objMisc._SQL = strSql
                dt1 = Me.objMisc.GetDataTable

                If dt1.Rows.Count = 0 Then
                    'Throw New Exception("Can not find frequency ID for Frequency '" & strFreq & "'.")
                Else
                    R1 = dt1.Rows(0)
                End If
                Return R1
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '************************************************************
        'Check if device exist in tdevice table without the ship date 
        '************************************************************
        'Public Function IsDeviceExisting(ByVal iCust_id As Integer, _
        '								 ByVal strDevice_sn As String) As Integer
        '	Dim strSql As String = ""
        '	Dim dt1 As DataTable
        '	Dim _device_id As Integer = 0

        '	Try
        '		strSql = "select tdevice.device_id " & Environment.NewLine
        '		strSql &= "from tdevice " & Environment.NewLine
        '		strSql &= "inner join tlocation on tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
        '		strSql &= "where device_sn = '" & strDevice_sn & "' " & Environment.NewLine
        '		strSql &= "and cust_id = " & iCust_id & Environment.NewLine
        '		strSql &= " and (Device_DateShip is null or Device_DateShip = '0000-00-00 00:00:00' or Device_DateShip = '');"
        '		Me.objMisc._SQL = strSql
        '		dt1 = Me.objMisc.GetDataTable

        '		If dt1.Rows.Count() > 0 Then
        '			_device_id = dt1.Rows(0)("device_id")
        '		End If

        '		Return _device_id
        '	Catch ex As Exception
        '		Throw ex
        '	Finally
        '		If Not IsNothing(dt1) Then
        '			dt1.Dispose()
        '			dt1 = Nothing
        '		End If
        '	End Try
        'End Function


        Public Function IsDeviceExisting(ByVal wo_custwo As String, ByVal device_sn As String) As DataTable
            Dim dt1 As DataTable
            Dim _sb As New StringBuilder()
            Try
                _sb.Append("SELECT ")
                _sb.Append("d.device_id, ")
                _sb.Append("d.device_sn, ")
                _sb.Append("d.wo_id, ")
                _sb.Append("d.device_daterec, ")
                _sb.Append("wo.wo_custwo, ")
                _sb.Append("wip.wipowner_desc, ")
                _sb.Append("loc.cust_id ")
                _sb.Append("FROM tdevice d ")
                _sb.Append("INNER JOIN tlocation loc on d.loc_id = loc.loc_id ")
                _sb.Append("INNER JOIN tmessdata md on d.device_id = md.device_id ")
                _sb.Append("INNER JOIN tworkorder wo on d.wo_id = wo.wo_id ")
                _sb.Append("LEFT JOIN lwipowner wip ON md.WipOwner_ID = wip.WipOwner_ID ")
                _sb.Append("WHERE ")
                _sb.Append("d.device_sn = '" & device_sn & "' and ")
                _sb.Append("wo_custwo <> '" & wo_custwo & "' and ")
                _sb.Append("IFNULL(d.device_dateship,'') = '' ")
                _sb.Append("ORDER BY d.device_daterec; ")
                Me.objMisc._SQL = _sb.ToString()
                dt1 = Me.objMisc.GetDataTable
                Return dt1
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function





        Public Function RemoveOpenLine(ByVal device_id As Integer) As Boolean
            Dim _removed As Boolean = False
            Dim _dt As New DataTable()
            Dim _sb As New StringBuilder()
            Try
                ' REMOVE BILLING RECORDS.
                _sb.Append("DELETE FROM production.tdevicebill WHERE device_id = " & device_id & "; ")
                If Me.objMisc.ExecuteNonQuery(_sb.ToString()) = -1 Then
                    Throw New Exception("The record could not be deleted.")
                End If
                ' REMOVE THE TMESSDATA RECORD.
                _sb = New StringBuilder()
                _sb.Append("DELETE FROM production.tmessdata WHERE device_id = " & device_id & "; ")
                If Me.objMisc.ExecuteNonQuery(_sb.ToString()) = -1 Then
                    Throw New Exception("The record could not be deleted.")
                End If
                ' REMOVE THE TDEVICE RECORD.
                _sb = New StringBuilder()
                _sb.Append("DELETE FROM production.tdevice WHERE device_id = " & device_id & "; ")
                If Me.objMisc.ExecuteNonQuery(_sb.ToString()) = -1 Then
                    Throw New Exception("The record could not be deleted.")
                End If
                Return True
            Catch ex As Exception
                Throw ex
                Return False
            End Try
        End Function

        '*******************************************************
        'Check if device exist in tdevice table within given wo
        '*******************************************************
        Public Function GetMessDevInfo_Tverdata(ByVal strWO_Name As String, _
           ByVal strDevice_sn As String) As DataTable
            Dim strSql As String = ""
            Dim strCapcode As String = ""

            Try
                strSql = "select * from tverdata " & Environment.NewLine
                'strSql &= "where WO_Name = '" & strWO_Name & "' " & Environment.NewLine
                strSql &= " where WO_Name = upper(left(replace(trim('" & strWO_Name & "'),' ',''),LENGTH('SPECIALWO')))" & Environment.NewLine
                strSql &= " and Device_sn = '" & strDevice_sn & "' " & Environment.NewLine
                strSql &= " and RcvdFlag = 0 order by trans_id desc;"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataTable

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        'Public Function GetDataForCheckingWIPWhileReceiving(ByVal iCust_ID As Integer, ByVal strSN As String) As DataTable
        '    Dim strSql As String = ""

        '    Try
        '        strSql = "SELECT A.Device_ID,A.Device_SN,A.Device_DateRec,A.Device_DateBill,A.Device_DateShip,E.pkslip_ID,A.Loc_ID,D.Cust_ID,C.Loc_Name AS 'Location',D.Cust_Name1 AS 'Customer'" & Environment.NewLine
        '        strSql &= " FROM tdevice A" & Environment.NewLine
        '        strSql &= " INNER JOIN tmessdata B ON A.Device_ID=B.Device_ID" & Environment.NewLine
        '        strSql &= " INNER JOIN tlocation C ON A.Loc_ID=C.Loc_ID" & Environment.NewLine
        '        strSql &= " INNER JOIN tcustomer D ON C.Cust_ID=D.Cust_ID" & Environment.NewLine
        '        strSql &= " LEFT JOIN tpallett E ON A.pallett_ID=E.Pallett_ID" & Environment.NewLine
        '        strSql &= " WHERE D.Cust_ID = " & iCust_ID & " AND A.Device_SN='" & strSN.Replace("'", "''") & "';" & Environment.NewLine
        '        Me.objMisc._SQL = strSql
        '        Return Me.objMisc.GetDataTable

        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function

        'Public Function UnlockReceivingUser() As Integer
        '    Dim strSql As String = ""

        '    Try
        '        strSql = "UPDATE zinuse SET InUse_Value = 0 WHERE InUse_Name = 'REC';"
        '        Me.objMisc._SQL = strSql
        '        Return Me.objMisc.ExecuteNonQuery
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function

        '*******************************************************
        'get all device in tray ID
        '*******************************************************
        Public Function GetDevInTray(ByVal iTray_id As Integer, _
          ByVal iLoc_id As Integer, _
          ByVal iModel_id As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "select Device_Cnt as 'Count', " & Environment.NewLine
                strSql &= "device_sn as 'Serial Number', " & Environment.NewLine
                strSql &= "tmessdata.capcode as 'Cap Code',  " & Environment.NewLine
                strSql &= "lfrequency.freq_Number as 'Frequency',  " & Environment.NewLine
                strSql &= "tmessdata.SKU,  " & Environment.NewLine
                strSql &= "lbaud.baud_Number as 'Baud Rate',  " & Environment.NewLine
                strSql &= "tmessdata.baud_id as Baud_id, " & Environment.NewLine
                strSql &= "tmessdata.freq_id as Freq_id, " & Environment.NewLine
                strSql &= "if(CameWithFileFlag = 1,'YES','NO') AS 'Came With File?', " & Environment.NewLine
                strSql &= "tdevice.Tray_ID, " & Environment.NewLine
                strSql &= "lfrequency.freq_MotoCode as 'freq_MotoCode'," & Environment.NewLine
                strSql &= "0 as 'Tverdata_TransID' " & Environment.NewLine
                strSql &= "from tdevice " & Environment.NewLine
                strSql &= "inner join tmessdata on tdevice.device_id = tmessdata.device_id " & Environment.NewLine
                strSql &= "left outer join lbaud on tmessdata.baud_id = lbaud.baud_id " & Environment.NewLine
                strSql &= "left outer join lfrequency on tmessdata.freq_id = lfrequency.freq_id " & Environment.NewLine
                strSql &= "where tray_id = " & iTray_id & " and " & Environment.NewLine
                strSql &= "model_id = " & iModel_id & Environment.NewLine
                strSql &= " and loc_id = " & iLoc_id & Environment.NewLine
                strSql &= "order by 'Count' asc;"

                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************
        'Get WO Information by tray ID
        '*******************************************************
        Public Function GetWOInfoByTray(ByVal iRecTray_ID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "select distinct mmw_wo, cust_id, model_id, Tray_Memo " & Environment.NewLine
                strSql &= "from tdevice " & Environment.NewLine
                strSql &= "inner join ttray on tdevice.tray_id = ttray.tray_id " & Environment.NewLine
                strSql &= "inner join tmessmiscwodata on tdevice.wo_id = tmessmiscwodata.pss_wo_id " & Environment.NewLine
                strSql &= "where tdevice.tray_id = " & iRecTray_ID & ";"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************
        'Receive all devices in tray:
        '   1:: Create tray
        '   2:: Add device to tdevice, tmessdata, tdevicemetro table
        '*******************************************************
        Public Function ReceiveDevicesInTray(ByVal strUserName As String, _
           ByVal iUser_id As Integer, _
           ByVal iShif_ID_Rec As Integer, _
           ByVal strWO_Name As String, _
           ByVal iWO_id As Integer, _
           ByVal iLoc_id As Integer, _
           ByVal iModel_id As Integer, _
           ByVal GdtRecDBGrid As DataTable, _
           ByRef iTray_id As Integer, _
           ByVal strTrayMemo As String, _
           ByVal iParentWO_ID As String, _
           ByVal iIsDBRTray As Integer, _
           ByVal bCheckWarranty As Boolean, _
           ByVal iWipOwnerID As Integer, _
           Optional ByVal bEvalReceive As Boolean = False) As Integer
            Dim strSql As String = ""
            Dim R1 As DataRow
            Dim dt1 As DataTable
            Dim i As Integer = 0
            Dim iInsertCnt As Integer = 0
            Dim iDevice_id As String = 0
            Dim strFailMsg As String = ""
            Dim objGen As New PSS.Data.Buisness.Generic()
            Dim strCurrDate As String = ""
            Dim strWorkDate As String = ""
            Dim objMessAdmin As New PSS.Data.Buisness.MessAdmin()
            Dim iIsPSSWarrantied As Integer = 1
            Dim iLastDeviceID As Integer = 0

            Try
                iTray_id = 0     'This value will send back to function

                strCurrDate = objGen.MySQLServerDateTime(1)
                strWorkDate = Mid(strCurrDate, 1, 10)

                For Each R1 In GdtRecDBGrid.Rows
                    If R1("Tray_ID") > 0 Then
                        iTray_id = R1("Tray_ID")
                    End If
                Next R1

                R1 = Nothing


                '******************
                '1::Create Tray
                '******************
                If iTray_id = 0 Then
                    Try
                        strSql = "INSERT INTO ttray " & Environment.NewLine
                        strSql &= "(Tray_RecUser,WO_ID, Tray_RecUserID "
                        If strTrayMemo <> "" Then
                            strSql &= ", Tray_Memo"
                        End If
                        strSql &= ") " & Environment.NewLine
                        strSql &= "VALUES " & Environment.NewLine
                        strSql &= "('" & strUserName & "', " & iWO_id & ", " & iUser_id
                        If strTrayMemo <> "" Then
                            strSql &= ", '" & strTrayMemo & "'"
                        End If
                        strSql &= ");"
                        Me.objMisc._SQL = strSql
                        iTray_id = Me.objMisc.idTransaction(strSql, "ttray")

                        If iTray_id = 0 Then
                            Throw New Exception("Tray could not be created.")
                        End If

                    Catch ex As Exception
                        Throw New Exception("Tray could not be created.")
                    End Try
                End If


                '************************
                '2:: Insert devices
                '************************
                For Each R1 In GdtRecDBGrid.Rows
                    If R1("Tray_ID") = 0 Then
                        '************************
                        '2.1:: Insert into tdevice
                        '************************
                        Try
                            iDevice_id = 0
                            iIsPSSWarrantied = 0

                            If iIsDBRTray = 0 And bCheckWarranty Then
                                iIsPSSWarrantied = IsPSSWarrantied(iLoc_id, R1("Serial Number"), iLastDeviceID)

                                If iIsPSSWarrantied = 1 Then iIsPSSWarrantied = IsRepairedDevice(iLastDeviceID)
                            End If

                            Select Case iLoc_id
                                Case PSS.Data.Buisness.SkyTel.Anna_LOC_ID, PSS.Data.Buisness.SkyTel.Lahey_LOC_ID, _
                                PSS.Data.Buisness.SkyTel.Masco_LOC_ID, PSS.Data.Buisness.SkyTel.Franciscan_LOC_ID, _
                                PSS.Data.Buisness.SkyTel.Maine_LOC_ID, PSS.Data.Buisness.SkyTel.SMHC_LOC_ID
                                    strSql = "INSERT into tdevice " & Environment.NewLine
                                    strSql &= "( " & Environment.NewLine
                                    strSql &= "Device_SN, " & Environment.NewLine
                                    strSql &= "Device_DateRec, " & Environment.NewLine
                                    strSql &= "Device_RecWorkDate, " & Environment.NewLine
                                    strSql &= "Device_Cnt, " & Environment.NewLine
                                    strSql &= "Tray_ID, " & Environment.NewLine
                                    strSql &= "Loc_ID, " & Environment.NewLine
                                    strSql &= "WO_ID, " & Environment.NewLine
                                    strSql &= "WO_ID_OUT, " & Environment.NewLine
                                    strSql &= "Model_ID, " & Environment.NewLine
                                    strSql &= "Shift_ID_Rec, " & Environment.NewLine
                                    strSql &= "Device_PSSWrty " & Environment.NewLine
                                    strSql &= ") " & Environment.NewLine
                                    strSql &= "VALUES " & Environment.NewLine
                                    strSql &= "( " & Environment.NewLine
                                    strSql &= "'" & R1("Serial Number") & "', " & Environment.NewLine
                                    strSql &= "'" & strCurrDate & "', " & Environment.NewLine
                                    strSql &= "'" & strWorkDate & "', " & Environment.NewLine
                                    'strSql &= iInsertCnt + 1 & ", " & Environment.NewLine
                                    strSql &= R1("Count") & ", " & Environment.NewLine
                                    strSql &= iTray_id & ", " & Environment.NewLine
                                    strSql &= iLoc_id & ", " & Environment.NewLine
                                    strSql &= iWO_id & ", " & Environment.NewLine
                                    strSql &= iWO_id & ", " & Environment.NewLine
                                    strSql &= R1("Model_ID") & ", " & Environment.NewLine
                                    strSql &= iShif_ID_Rec & ", " & Environment.NewLine
                                    strSql &= iIsPSSWarrantied.ToString & Environment.NewLine
                                    strSql &= ");"
                                Case Else
                                    strSql = "INSERT into tdevice " & Environment.NewLine
                                    strSql &= "( " & Environment.NewLine
                                    strSql &= "Device_SN, " & Environment.NewLine
                                    strSql &= "Device_DateRec, " & Environment.NewLine
                                    strSql &= "Device_RecWorkDate, " & Environment.NewLine
                                    strSql &= "Device_Cnt, " & Environment.NewLine
                                    strSql &= "Tray_ID, " & Environment.NewLine
                                    strSql &= "Loc_ID, " & Environment.NewLine
                                    strSql &= "WO_ID, " & Environment.NewLine
                                    strSql &= "WO_ID_OUT, " & Environment.NewLine
                                    strSql &= "Model_ID, " & Environment.NewLine
                                    strSql &= "Shift_ID_Rec, " & Environment.NewLine
                                    strSql &= "Device_PSSWrty " & Environment.NewLine
                                    strSql &= ") " & Environment.NewLine
                                    strSql &= "VALUES " & Environment.NewLine
                                    strSql &= "( " & Environment.NewLine
                                    strSql &= "'" & R1("Serial Number") & "', " & Environment.NewLine
                                    strSql &= "'" & strCurrDate & "', " & Environment.NewLine
                                    strSql &= "'" & strWorkDate & "', " & Environment.NewLine
                                    'strSql &= iInsertCnt + 1 & ", " & Environment.NewLine
                                    strSql &= R1("Count") & ", " & Environment.NewLine
                                    strSql &= iTray_id & ", " & Environment.NewLine
                                    strSql &= iLoc_id & ", " & Environment.NewLine
                                    strSql &= iWO_id & ", " & Environment.NewLine
                                    strSql &= iWO_id & ", " & Environment.NewLine
                                    strSql &= iModel_id & ", " & Environment.NewLine
                                    strSql &= iShif_ID_Rec & ", " & Environment.NewLine
                                    strSql &= iIsPSSWarrantied.ToString & Environment.NewLine
                                    strSql &= ");"
                            End Select


                            Me.objMisc._SQL = strSql
                            i += Me.objMisc.ExecuteNonQuery

                            If Not IsNothing(dt1) Then
                                dt1.Dispose()
                                dt1 = Nothing
                            End If

                            '************************
                            'Get Device ID
                            '************************
                            Select Case iLoc_id
                                Case PSS.Data.Buisness.SkyTel.Anna_LOC_ID, PSS.Data.Buisness.SkyTel.Lahey_LOC_ID, _
                                PSS.Data.Buisness.SkyTel.Masco_LOC_ID, PSS.Data.Buisness.SkyTel.Franciscan_LOC_ID, _
                                PSS.Data.Buisness.SkyTel.Maine_LOC_ID, PSS.Data.Buisness.SkyTel.SMHC_LOC_ID
                                    strSql = "select Device_ID from tdevice " & Environment.NewLine
                                    strSql &= "where Device_SN = '" & R1("Serial Number") & "' and " & Environment.NewLine
                                    strSql &= "Tray_ID = " & iTray_id & " and " & Environment.NewLine
                                    strSql &= "WO_ID = " & iWO_id & " and " & Environment.NewLine
                                    strSql &= "Model_ID = " & R1("Model_ID") & " and " & Environment.NewLine
                                    strSql &= "Loc_ID = " & iLoc_id & ";"
                                Case Else
                                    strSql = "select Device_ID from tdevice " & Environment.NewLine
                                    strSql &= "where Device_SN = '" & R1("Serial Number") & "' and " & Environment.NewLine
                                    strSql &= "Tray_ID = " & iTray_id & " and " & Environment.NewLine
                                    strSql &= "WO_ID = " & iWO_id & " and " & Environment.NewLine
                                    strSql &= "Model_ID = " & iModel_id & " and " & Environment.NewLine
                                    strSql &= "Loc_ID = " & iLoc_id & ";"
                            End Select

                            Me.objMisc._SQL = strSql
                            dt1 = Me.objMisc.GetDataTable

                            If dt1.Rows.Count > 0 Then
                                iDevice_id = dt1.Rows(0)("Device_ID")
                            Else
                                Exit For
                            End If

                        Catch ex As Exception
                            MsgBox("Error occur when insert a device into Tdevice." & Environment.NewLine & ex.ToString, MsgBoxStyle.Critical)
                            Exit For
                        End Try

                        '**************************
                        '2.2:: Insert into tmessdata
                        '**************************
                        Try
                            strSql = "INSERT INTO tmessdata " & Environment.NewLine
                            strSql &= "( " & Environment.NewLine
                            strSql &= "capcode, " & Environment.NewLine
                            strSql &= "SKU, " & Environment.NewLine
                            strSql &= "baud_id, " & Environment.NewLine
                            strSql &= "freq_id, " & Environment.NewLine
                            strSql &= "CameWithFileFlag, " & Environment.NewLine
                            strSql &= "wo_id, " & Environment.NewLine
                            strSql &= "device_id, " & Environment.NewLine
                            strSql &= "wipowner_id, " & Environment.NewLine
                            strSql &= "wipowner_EntryDt " & Environment.NewLine
                            If bEvalReceive Then
                                strSql &= ",EvalFlag " & Environment.NewLine
                            End If
                            strSql &= ") " & Environment.NewLine
                            strSql &= "VALUES " & Environment.NewLine
                            strSql &= "( " & Environment.NewLine
                            strSql &= "'" & R1("Cap Code") & "', " & Environment.NewLine
                            strSql &= "'" & R1("SKU") & "', " & Environment.NewLine
                            strSql &= R1("Baud_id") & ", " & Environment.NewLine
                            strSql &= R1("Freq_id") & ", " & Environment.NewLine
                            If R1("Came With File?") = "YES" Then
                                strSql &= "1, " & Environment.NewLine
                            Else
                                strSql &= "0, " & Environment.NewLine
                            End If
                            strSql &= iWO_id & ", " & Environment.NewLine
                            strSql &= iDevice_id & Environment.NewLine
                            strSql &= ", " & iWipOwnerID & Environment.NewLine
                            strSql &= ", now() " & Environment.NewLine
                            If bEvalReceive Then
                                strSql &= ",1" & Environment.NewLine
                            End If
                            strSql &= ");"

                            Me.objMisc._SQL = strSql
                            i += Me.objMisc.ExecuteNonQuery

                            ' ADD WORKSTATION JOURNAL RECORDS FOR THE DEVICE.
                            Dim _dwsj As New BOL.tdevice_workstation_journal(iDevice_id, 1, "Receiving", "", strUserName, Environment.MachineName, "Receiving")
                            _dwsj.ApplyChanges()
                            _dwsj = New BOL.tdevice_workstation_journal(iDevice_id, 1, IIf(iWipOwnerID = 201, "WH", "Pre-Eval"), "", strUserName, Environment.MachineName, "Receiving")
                            _dwsj.ApplyChanges()
                            _dwsj = Nothing

                        Catch ex As Exception
                            '*******************************************
                            'remove device in tdevice if error occur 
                            ' while insert device into tmessdata
                            '*******************************************
                            Try
                                MsgBox("Error occur when insert a device into Tmessdata." & Environment.NewLine & ex.ToString, MsgBoxStyle.Critical)
                                i += Me.DeleteDevice_TDevice(iDevice_id)
                            Catch exMessData As Exception
                            End Try

                            Exit For
                            '*******************************************
                        End Try


                        '*****************************
                        '2.3:: Insert into tdevicemetro
                        '*****************************
                        Try
                            strSql = "REPLACE INTO tdevicemetro " & Environment.NewLine
                            strSql &= "( " & Environment.NewLine
                            strSql &= "devicemetro_sn, " & Environment.NewLine
                            strSql &= "deviceMetro_SKU, " & Environment.NewLine
                            strSql &= "deviceMetro_CapCode, " & Environment.NewLine
                            strSql &= "deviceMetro_FreqCode, " & Environment.NewLine
                            strSql &= "Freq_ID, " & Environment.NewLine
                            strSql &= "Model_id, " & Environment.NewLine
                            strSql &= "Tray_ID, " & Environment.NewLine
                            strSql &= "WO_ID " & Environment.NewLine
                            strSql &= ") " & Environment.NewLine
                            strSql &= "VALUES " & Environment.NewLine
                            strSql &= "( " & Environment.NewLine
                            strSql &= "'" & R1("Serial Number") & "', " & Environment.NewLine
                            strSql &= "'" & R1("SKU") & "', " & Environment.NewLine
                            strSql &= "'" & R1("Cap Code") & "', " & Environment.NewLine
                            strSql &= "'" & R1("freq_MotoCode") & "', " & Environment.NewLine
                            strSql &= R1("Freq_id") & ", " & Environment.NewLine
                            Select Case iLoc_id
                                Case PSS.Data.Buisness.SkyTel.Anna_LOC_ID, PSS.Data.Buisness.SkyTel.Lahey_LOC_ID, _
                                PSS.Data.Buisness.SkyTel.Masco_LOC_ID, PSS.Data.Buisness.SkyTel.Franciscan_LOC_ID, _
                                PSS.Data.Buisness.SkyTel.Maine_LOC_ID, PSS.Data.Buisness.SkyTel.SMHC_LOC_ID
                                    strSql &= R1("Model_ID") & ", " & Environment.NewLine
                                Case Else
                                    strSql &= iModel_id & ", " & Environment.NewLine
                            End Select
                            strSql &= iTray_id & ", " & Environment.NewLine
                            strSql &= iWO_id & Environment.NewLine
                            strSql &= ");"

                            Me.objMisc._SQL = strSql
                            i += Me.objMisc.ExecuteNonQuery

                        Catch ex As Exception
                            ''''Try
                            ''''    MsgBox("Error occur when insert a device into tdevicemetro." & Environment.NewLine & ex.ToString, MsgBoxStyle.Critical)
                            ''''    'remove device in tdevice
                            ''''    i = Me.DeleteDevice_TDevice(iDevice_id)
                            ''''    'remove device in tmessdata
                            ''''    i = Me.DeleteDevice_TmessData(iDevice_id)

                            ''''Catch exDeviceMetro As Exception
                            ''''End Try
                            ''''Exit For
                        End Try

                        '*****************************
                        '2.4:: update RecFlg in Tverdata
                        '*****************************
                        Try
                            If R1("Tverdata_TransID") > 0 Then
                                strSql = "update tverdata set RcvdFlag = 1 " & Environment.NewLine
                                strSql &= ", device_id = " & iDevice_id & Environment.NewLine
                                If iParentWO_ID > 0 Then
                                    strSql &= ", WO_Name = '" & strWO_Name & "' " & Environment.NewLine
                                End If
                                strSql &= "where Trans_ID = " & R1("Tverdata_TransID") & ";"
                                Me.objMisc._SQL = strSql
                                i += Me.objMisc.ExecuteNonQuery
                            End If
                        Catch
                            Exit For        ''Should we continue?
                        End Try
                        '*****************************

                        iInsertCnt += 1
                    Else
                        strSql = "update tdevice set Device_Cnt = " & R1("Count") & Environment.NewLine
                        strSql &= "where Device_SN = '" & R1("Serial Number") & "' " & Environment.NewLine
                        strSql &= " and tray_id = " & R1("Tray_ID") & ";"
                        Me.objMisc._SQL = strSql
                        i += Me.objMisc.ExecuteNonQuery
                    End If

                Next R1

                Return iInsertCnt
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                objGen = Nothing
                objMessAdmin = Nothing
                If Not IsNothing(GdtRecDBGrid) Then
                    GdtRecDBGrid.Dispose()
                    GdtRecDBGrid = Nothing
                End If
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        Public Function IsPSSWarrantied(ByVal strDeviceSN As String, ByRef iLastDeviceID As Integer) As Integer
            Dim iLocID As Integer
            Dim strSQL As String

            Try
                strSQL = "SELECT Loc_ID " & Environment.NewLine
                strSQL &= "FROM tdevice " & Environment.NewLine
                strSQL &= "WHERE Device_SN = '" & strDeviceSN & "'"

                iLocID = Me._objDataProc.GetIntValue(strSQL)

                Return IsPSSWarrantied(iLocID, strDeviceSN, iLastDeviceID)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function IsPSSWarrantied(ByVal iLocID As Integer, ByVal strDeviceSN As String, ByRef iLastDeviceID As Integer) As Integer
            Dim iIsPSSWarrantied As Integer = 0
            Dim strSQL, strRecWorkDate As String
            Dim iYear, iMonth, iDay, iDaysInWrty As Integer
            Dim datRecWorkDate As Date
            Dim dr As DataRow

            Try
                'Get data for the most recent device ID with serial number strDeviceSN
                strSQL = "SELECT DATE_FORMAT(Device_RecWorkDate, '%Y-%m-%d') RecWorkDate, MAX(Device_ID) AS DeviceID " & Environment.NewLine
                strSQL &= "FROM tdevice " & Environment.NewLine
                strSQL &= "WHERE Device_SN = '" & strDeviceSN & "' " & Environment.NewLine
                strSQL &= "GROUP BY Device_SN"
                'strSQL &= "ORDER BY Device_ID DESC"

                dr = Me._objDataProc.GetDataRow(strSQL)

                If Not IsNothing(dr) Then
                    If Not IsDBNull(dr("DeviceID")) Then iLastDeviceID = dr("DeviceID")

                    If Not IsDBNull(dr("RecWorkDate")) Then
                        strRecWorkDate = dr("RecWorkDate")

                        If strRecWorkDate.Length > 0 Then
                            iYear = CInt(strRecWorkDate.Substring(0, 4))
                            iMonth = CInt(strRecWorkDate.Substring(strRecWorkDate.Length - 5, 2))
                            iDay = CInt(strRecWorkDate.Substring(strRecWorkDate.Length - 2, 2))

                            datRecWorkDate = New Date(iYear, iMonth, iDay)

                            strSQL = "SELECT A.CustWrty_DaysInWrty " & Environment.NewLine
                            strSQL &= "FROM tcustwrty A " & Environment.NewLine
                            strSQL &= "INNER JOIN tlocation B ON B.Cust_ID = A.Cust_ID " & Environment.NewLine
                            strSQL &= "WHERE B.Loc_ID = " & iLocID.ToString

                            iDaysInWrty = Me.objMisc.GetIntValue(strSQL)

                            If iDaysInWrty >= Math.Abs(DateDiff(DateInterval.Day, CDate(Generic.MySQLServerDateTime(1)), datRecWorkDate)) Then iIsPSSWarrantied = 1
                        End If
                    End If
                End If

                Return iIsPSSWarrantied
            Catch ex As Exception
                Throw ex
            Finally
                dr = Nothing
            End Try
        End Function

        Public Function IsRepairedDevice(ByVal iDeviceID As Integer) As Integer
            Dim iIsRepairedDevice As Integer = 0
            Dim iCount As Integer
            Dim strSQL As String

            Try
                strSQL = "SELECT COUNT(*) " & Environment.NewLine
                strSQL &= "FROM tdevicebill A " & Environment.NewLine
                strSQL &= "INNER JOIN lbillcodes B ON B.BillCode_ID = A.BillCode_ID " & Environment.NewLine
                strSQL &= "WHERE B.BillCode_Rule = 0 " & Environment.NewLine
                strSQL &= "AND A.Device_ID = " & iDeviceID.ToString

                iCount = Me._objDataProc.GetIntValue(strSQL)

                If iCount > 0 Then iIsRepairedDevice = 1

                Return iIsRepairedDevice
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************
        'Delete device from tdevice
        '*******************************************************
        Public Function DeleteDevice_TDevice(ByVal iDevice_ID As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "DELETE FROM tdevice where Device_ID = " & iDevice_ID & ";"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.ExecuteNonQuery
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************
        'Delete device from tmessdata
        '*******************************************************
        Public Function DeleteDevice_TmessData(ByVal iDevice_ID As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "DELETE FROM tmessdata where device_id = " & iDevice_ID & ";"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.ExecuteNonQuery
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************
        'Update tworkorder quantity
        '*******************************************************
        Public Function UpdatePSSWOQty(ByVal iWO_ID As Integer, _
         ByVal iTotalRcvdDevice As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "update tworkorder set WO_RAQnty = " & iTotalRcvdDevice & ", WO_Quantity = " & iTotalRcvdDevice & " where wo_id = " & iWO_ID & ";"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.ExecuteNonQuery
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************
        'print worksheet report
        '*******************************************************
        Public Shared Function PrintRecReport(ByVal iTray_ID As Integer, ByVal iPrintoutQty As Integer) As Integer
            Dim objRecWksht As RecWorksheet

            Try
                objRecWksht = New RecWorksheet()

                objRecWksht.PrintRecReport(iTray_ID, iPrintoutQty)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************
        'Get datatable for Messaging Flag: Shipped Qty comparing Forecasted Qty
        '******************************************************************************************************
        Public Function getShippedForecatedQtyData(ByVal iCust_ID As Integer, ByVal strWorkDate As String, ByRef strWeekDates As String) As DataTable
            Dim strSql As String = "", strDate As String
            Dim R1, R2 As DataRow
            Dim dt1, dt2, dt3 As DataTable
            Dim strFreqIDs, strBaudIDs, strModelIDs As String
            Dim strBegDate, strEndDate As String
            Dim myDate As Date, iCnt As Integer = 0
            Dim bFoundIt As Boolean = False

            Try
                'Get begin and end dates
                If IsDate(strWorkDate) Then myDate = CDate(strWorkDate) Else myDate = Now.Date
                If WeekdayName(Weekday(myDate)) = "Sunday" Then
                    strBegDate = Format(PSS.Data.Buisness.Generic.DateOfPreviousWeek(myDate, DayOfWeek.Monday, 1), "yyyy-MM-dd")
                Else
                    strBegDate = Format(PSS.Data.Buisness.Generic.DateOfPreviousWeek(myDate, DayOfWeek.Monday, 0), "yyyy-MM-dd")
                End If
                strEndDate = Format(CDate(strBegDate).AddDays(6), "yyyy-MM-dd")
                strWeekDates = strBegDate & " - " & strEndDate

                'Get last date
                strSql = "select date_format(max(Date),'%Y-%m-%d') strDate from tamsForecastedNeed where cust_ID=" & iCust_ID & ";"
                dt1 = Me._objDataProc.GetDataTable(strSql)

                If dt1.Rows.Count > 0 Then
                    strDate = dt1.Rows(0).Item(0)

                    'Get forecasted
                    strSql = "select 0 as 'Idx',D.Model_Desc,B.Baud_number,C.Freq_Number,A.Qty as 'Forecasted Qty',0 as 'Shipped Qty','' as 'Alert'" & Environment.NewLine
                    strSql &= ",A.AFN_ID,A.AMS_Orig_Model,A.AMS_Model,A.AMS_Baud,A.AMS_Freq,A.PSSI_Model_ID,A.PSSI_Baud_ID" & Environment.NewLine
                    strSql &= ",A.PSSI_Freq_ID,A.Date,A.Cust_ID,B.Baud_ID,C.Freq_ID,D.Model_ID, 0 as 'Idx_Original'" & Environment.NewLine
                    strSql &= " from tamsForecastedNeed A " & Environment.NewLine
                    strSql &= " inner join lbaud B on A.PSSI_Baud_ID=B.Baud_ID " & Environment.NewLine
                    strSql &= " inner join lfrequency C on A.PSSI_Freq_ID=C.Freq_ID " & Environment.NewLine
                    strSql &= " inner join tmodel D on A.PSSI_Model_ID=D.Model_ID " & Environment.NewLine
                    strSql &= " where A.PSSI_Baud_ID>0 and A.PSSI_Freq_ID>0 " & Environment.NewLine
                    strSql &= " and Cust_ID= " & iCust_ID & " and Date='" & strDate & "';" & Environment.NewLine
                    dt2 = Me._objDataProc.GetDataTable(strSql)
                    strModelIDs = "" : strFreqIDs = "" : strBaudIDs = ""
                    For Each R1 In dt2.Rows
                        If strModelIDs.Trim.Length = 0 Then strModelIDs = R1("model_ID") Else strModelIDs &= "," & R1("model_ID")
                        If strFreqIDs.Trim.Length = 0 Then strFreqIDs = R1("freq_ID") Else strFreqIDs &= "," & R1("freq_ID")
                        If strBaudIDs.Trim.Length = 0 Then strBaudIDs = R1("baud_ID") Else strBaudIDs &= "," & R1("baud_ID")
                    Next

                    'Get shipped
                    If strModelIDs.Trim.Length > 0 AndAlso strFreqIDs.Trim.Length > 0 AndAlso strBaudIDs.Trim.Length > 0 Then
                        strSql = " select A.Model_ID,B.Baud_ID,B.FreQ_ID,count(A.Model_ID) as Qty" & Environment.NewLine
                        strSql &= " from tdevice A" & Environment.NewLine
                        strSql &= " inner join tmessdata B on A.device_ID=B.device_ID" & Environment.NewLine
                        strSql &= " inner join tlocation C on A.Loc_ID=C.Loc_ID" & Environment.NewLine
                        strSql &= " where C.Cust_ID=" & iCust_ID & " and A.Device_DateShip between '" & strBegDate & " 00:00:00' and '" & strEndDate & " 23:59:59'" & Environment.NewLine
                        strSql &= " and A.Model_ID in (" & strModelIDs & ")" & Environment.NewLine
                        strSql &= " and B.Freq_ID in (" & strFreqIDs & ") and B.Baud_ID in (" & strBaudIDs & ")" & Environment.NewLine
                        strSql &= " group by A.Model_ID,B.Baud_ID,B.FreQ_ID;" & Environment.NewLine
                        dt3 = Me._objDataProc.GetDataTable(strSql)

                        iCnt = 0
                        For Each R1 In dt2.Rows
                            iCnt += 1 : bFoundIt = False
                            R1("Idx_Original") = iCnt
                            For Each R2 In dt3.Rows
                                If R1("Model_ID") = R2("Model_ID") AndAlso R1("Freq_ID") = R2("Freq_ID") AndAlso R1("Baud_ID") = R2("Baud_ID") Then
                                    R1("Shipped Qty") = R2("Qty")          'shipped
                                    If R1("Forecasted Qty") > R2("Qty") Then
                                        R1("Alert") = "Move to Production"
                                    End If
                                    R1.AcceptChanges()
                                    bFoundIt = True : Exit For
                                End If
                            Next
                            If Not bFoundIt Then
                                R1("Alert") = "Move to Production" : R1.AcceptChanges()
                            End If
                        Next
                    End If
                End If

                Return dt2

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '************************************************************************************************************************************
        Public Shared Function GetAMSNextWipOwner(ByVal iCustID As Integer, ByVal strScreenName As String, ByVal iFailed As Integer) As Integer
            Dim objMessRpt As Buisness.MessReports
            Dim strCustIDs As String
            Dim iWipOwnerID As Integer

            Try
                objMessRpt = New Buisness.MessReports()

                If Data.Buisness.MessLabel.IsAMSShareableInventoryCustomer(iCustID) = True Then
                    strCustIDs = objMessRpt.GetAMSMessCustIDs()
                    iWipOwnerID = Buisness.MessReceive.GetNextWipOwnerIDInWFP(strCustIDs, strScreenName, iFailed)
                    If iWipOwnerID = 0 Then Throw New Exception("System has failed to define next wip bucket.")
                End If

                Return iWipOwnerID
            Catch ex As Exception
                Throw ex
            Finally
                objMessRpt = Nothing
            End Try
        End Function

        '************************************************************************************************************************************
        Public Shared Function GetNextWipOwnerIDInWFP(ByVal strCustIDs As String, ByVal strScreenName As String, ByVal iFailed As Integer) As Integer
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = "", strWorkStation As String = ""
            Dim dt As DataTable
            Dim iWipOwner As Integer = 0

            Try
                strSql = "SELECT * FROM lworkflowprocess WHERE cust_IDs =  '" & strCustIDs & "' AND wfp_Screenname = '" & strScreenName & "'"
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                dt = objDataProc.GetDataTable(strSql)

                If dt.Rows.Count = 1 Then
                    If iFailed = 1 Then
                        strWorkStation = dt.Rows(0)("wfp_FailUnit_ToStation")
                    Else
                        strWorkStation = dt.Rows(0)("wfp_ToStation")
                    End If

                    iWipOwner = GetWipOwnerID(strWorkStation)
                ElseIf dt.Rows.Count > 1 Then
                    Throw New Exception("Duplicate line in work flow.")
                End If

                Return iWipOwner
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '************************************************************************************************************************************
        Public Shared Function GetWipOwnerID(ByVal strWipOwnerName As String) As Integer
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = ""
            Dim iWipOwner As Integer = 0

            Try
                strSql = "SELECT wipowner_id FROM lwipowner WHERE wipowner_desc = '" & strWipOwnerName & "'"
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetIntValue(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '************************************************************************************************************************************

    End Class
End Namespace