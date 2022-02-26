Imports System.Text
Namespace BLL
	Public Class PalletFactory
		Private _objDataProc As DBQuery.DataProc
#Region "PUBLIC METHODS"
		Public Function CreateWfmNtfPallet(ByRef dt As DataTable, ByVal model_id As Integer, ByVal disp_id As Integer, ByVal user_id As Integer) As Integer
			' DAVID BRADLE  03-21-2017
			' CREATES A WFM PALLET.
			Dim _newId As Integer = 0
			Dim _newPalletNr As String = ""
			Dim _loc_id = 3402
			_newPalletNr = GetNewPalletNumber("N")
			Dim _p As New BOL.tpallet()
			_p.Cust_ID = 2597
			_p.Loc_ID = _loc_id
			_p.Model_ID = (model_id)
			_p.Pallet_Invalid = 0
			_p.Pallett_Name = _newPalletNr
			_p.Pallett_QTY = dt.Rows.Count()
			_p.disp_id = disp_id
			_p.Pallett_ReadyToShipFlg = True
			_p.ApplyChanges()
			_newId = _p.Pallett_ID
			ApplyDevicesToPallet(dt, _newId, _loc_id, _newPalletNr)
			_p = Nothing
			Return _newId
		End Function
		Public Sub RemoveAllDevicesFromPallet(ByVal pallet_id)
			' DAVID BRADLE  03-31-2017
			' DELETES ALL DEVICES IN A PALLET AND ADJUST THE PALLETS QUANTITY.
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			Dim _sb As New StringBuilder()
			' UPDATE THE TITEM RECORDS TO NOT REFLECT THE BOXID OF THE PALLET.
			_sb.Append("UPDATE edi.titem itm ")
			_sb.Append("INNER JOIN production.tdevice d ON itm.device_id = d.device_id ")
			_sb.Append("SET itm.boxid = '' ")
			_sb.Append("WHERE d.pallett_id = " & pallet_id.ToString() & " ")
			_sb.Append("; ")
			_objDataProc.ExecuteNonQuery(_sb.ToString())
			' UPDATE THE DEVICE RECORDS.
			_sb = New StringBuilder()
			_sb.Append("UPDATE production.tdevice SET ")
			_sb.Append("pallett_id = NULL ")
			_sb.Append("WHERE pallett_id = " & pallet_id.ToString() & " ")
			_sb.Append("; ")
			_objDataProc.ExecuteNonQuery(_sb.ToString())
			' UPDATE THE PALLET QUANTITY
			_sb = New StringBuilder()
			_sb.Append("UPDATE production.tpallett SET ")
			_sb.Append("pallett_qty = 0, ")
			_sb.Append("AQL_QCResult_ID = 0 ")
			_sb.Append("WHERE pallett_id = " & pallet_id.ToString() & " ")
			_sb.Append("; ")
			_objDataProc.ExecuteNonQuery(_sb.ToString())
			_objDataProc = Nothing
		End Sub
		Public Function GetPalletQty(ByVal pallet_id As Integer) As Integer
			' DAVID BRADLE  03-21-2017
			' RETURNS THE QUANTITY OF DEVICES ASSIGNED TO A PALLET.
			Dim _qty As Integer = 0
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			Dim _sb As New StringBuilder()
			' UPDATE THE DEVICE RECORDS.
			_sb.Append("SELECT count(device_id) ")
			_sb.Append("FROM tdevice ")
			_sb.Append("WHERE pallett_id = " & pallet_id.ToString() & " ")
			_sb.Append("; ")
			_qty = _objDataProc.GetIntValue(_sb.ToString())
			Return _qty
		End Function
		Public Sub DeletePallet(ByVal pallet_id As Integer)
			' DAVID BRADLE  03-31-2017
			' DELETES THE PALLET AFTER REMOVING ALL OF ITS DEVICES.
			RemoveAllDevicesFromPallet(pallet_id)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			Dim _sb As New StringBuilder()
			_sb.Append("DELETE FROM tpallett ")
			_sb.Append("WHERE pallett_id = " & pallet_id.ToString() & " ")
			_sb.Append("; ")
			_objDataProc.ExecuteNonQuery(_sb.ToString())
		End Sub
#End Region
#Region "PRIVATE METHODS"
		Private Sub ApplyDevicesToPallet(ByVal dt As DataTable, ByVal pallet_id As Integer, ByVal loc_id As Integer, ByVal box_na As String)
			Dim _dr As DataRow
			For Each _dr In dt.Rows()
				Dim _sn As String = _dr(0).ToString()
				Dim _d As New BOL.tDevice(_sn, loc_id)
				If _d.Device_ID < 1 Then
					Throw New Exception("Pallet created but not all devices have been applied to the pallet do to an error.")
				Else
					_d.Pallett_ID = pallet_id
					Dim _itm As New BOL.titem(_d.Device_ID)
					_itm.BoxID = box_na
					_d.ApplyChanges()
					_itm.ApplyChanges()
					_itm = Nothing
					_d = Nothing
				End If
			Next
		End Sub
		Private Function GetNewPalletNumber(ByVal Prefix As String) As String
			' Builds the pallett number to be used.
			Dim _prefix As String = Prefix
			Dim _warantyStatus As String = "OW"
			Dim _date As String = Date.Now.Date.ToString("yyyyMMdd")
			Dim _pallettNumber As String = ""
			Dim _retVal As String
			Dim _twhpallett As New Data.BOL.tpallett_MaxNumber(_prefix & _date & _warantyStatus)
			_pallettNumber = _twhpallett.NextpallettNr
			_twhpallett = Nothing
			_retVal = _pallettNumber
			Return _retVal
		End Function
#End Region
	End Class
End Namespace
