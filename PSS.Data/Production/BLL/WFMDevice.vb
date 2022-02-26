Imports System.Text
Namespace BLL
	Public Class WFMDevice
#Region "DECLARATIONS"
		Private _cust_id = 2597
		Private _loc_id = 3402
#End Region
#Region "CONSTRUCTORS"
		Public Sub New()
		End Sub
#End Region
#Region "METHODS"
		Public Function GetDeviceInfo(Optional ByVal serial_nr As String = "", Optional ByVal box_nr As String = "") As DataTable
			Dim _objDataProc As New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			Dim _dt As New DataTable()
			Dim _sb As New StringBuilder()
			_sb.Append("SELECT ")
			_sb.Append("rec.date_rec as init_date_rec, ")
			_sb.Append("pallet as init_pallet, ")
			_sb.Append("carton as init_carton, ")
			_sb.Append("sku as init_sku, ")
			_sb.Append("serial_nr, ")
			_sb.Append("d.device_id, ")
			_sb.Append("itm.sn, ")
			_sb.Append("d.device_daterec, ")
			_sb.Append("m.Model_Desc, ")
			_sb.Append("wb.box_na, ")
			_sb.Append("loc.loc_na as 'box_loc_na', ")
			_sb.Append("wb.quantity, ")
			_sb.Append("bins.bin_na, ")
			_sb.Append("co.workstation, ")
			_sb.Append("disp.disp_cd, ")
			_sb.Append("co.workstationentrydt, ")
			_sb.Append("d.device_dateship, ")
			_sb.Append("u.user_fullname AS TriageBy, ")
			_sb.Append("dt.crt_ts AS TrgCrtDt, ")
			_sb.Append("plt.pallett_name ")
			_sb.Append("FROM ttf_bx_phn_received rec ")
			_sb.Append("LEFT JOIN edi.titem itm on rec.serial_nr = itm.sn ")
			_sb.Append("LEFT JOIN tdevice d on itm.Device_ID = d.device_id ")
			_sb.Append("left join warehouse.wh_box wb on itm.whb_id = wb.whb_id ")
			_sb.Append("left join tmodel m on d.model_id = m.model_id ")
			_sb.Append("left join tcellopt co on d.device_id = co.device_id ")
			_sb.Append("left join warehouse.wh_bins bins on wb.bin_id = bins.bin_id ")
			_sb.Append("left join tcustomer_prod_locations loc on wb.cpl_id = loc.cpl_id ")
			_sb.Append("left join tdevice_triage dt on d.device_id = dt.device_id ")
			_sb.Append("left join tdispositions disp on dt.disp_id = disp.disp_id ")
			_sb.Append("left join security.tusers u on dt.crt_user_id = u.user_id ")
			_sb.Append("left join tpallett plt on d.pallett_id = plt.pallett_id ")
			_sb.Append("WHERE ")
			_sb.Append("1 = 1 ")
			If serial_nr <> "" Then
				_sb.Append("AND  rec.serial_nr = '" & serial_nr & "' ")
			End If
			If box_nr <> "" Then
				_sb.Append("AND  wb.box_na = '" & box_nr & "' ")
			End If
			_sb.Append("ORDER BY d.device_daterec; ")
			_dt = _objDataProc.GetDataTable(_sb.ToString())
			_objDataProc = Nothing
			_sb = Nothing
			Return _dt
		End Function
		Public Sub RemoveDeviceFromBox(ByVal device_id As Integer, ByVal whb_id As Integer)
			' UPDATE TITEM TO REMOVE WHB_ID.
			Dim _itm As New BOL.titem(device_id)
			_itm.whb_id = 0
			_itm.BoxID = ""
			_itm.ApplyChanges()
			_itm = Nothing
			' UPDATE THE QUANTITY OF THE WH_BOX RECORD.
			Dim _whb As New BOL.wh_box(whb_id)
			Dim _qty As Integer = _whb.quantity
			If _whb.quantity > 0 Then
				_whb.quantity = _qty - 1
				_whb.ApplyChanges()
			Else
				'Throw New Exception("Box has a quantity of zero and this device has been removed from the box.")
			End If
			_whb = Nothing
		End Sub
		Public Sub SetDeviceCostCenter(ByVal device_id As Integer, ByVal cc_id As Integer)
			Dim _d As New BOL.tDevice()
			_d.cc_id = cc_id
			_d.CC_EntryDate = Date.Now
			_d.ApplyChanges()
			_d = Nothing
		End Sub
#End Region
	End Class
End Namespace
