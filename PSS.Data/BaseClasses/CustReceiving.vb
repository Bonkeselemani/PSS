Namespace BaseClasses
	Public MustInherit Class CustReceiving
		Implements Interfaces.ICustReceiving
#Region "DECLARATIONS"
		Friend _dtSerials As New DataTable()
		'Friend _cpl_id_from As Integer
		Friend _disp_id As Integer
		Friend _model_id As Integer
		Friend _qty As Integer
		Friend _user_id As Integer
		Friend _cust_id As Integer = 0
		Friend _loc_id As Integer = 0
#End Region
#Region "MUSTOVERRIDE"
		MustOverride Function GetBoxNumber(ByVal Prefix As String) As String Implements Interfaces.ICustReceiving.GetBoxNumber
#End Region
#Region "BASE METHODS"
		Sub New(ByVal user_id As Integer)
			_user_id = user_id
		End Sub

		Function InsertTdevice( _
		 ByVal sn As String, _
		 ByVal model_id As Integer) _
		 As Integer Implements Interfaces.ICustReceiving.InsertTdevice
			' Inserts a record into the production.tdevice table.
			Dim _device As New BOL.tDevice()
			_device.Device_SN = sn
			_device.Device_DateRec = Date.Now
			_device.Device_RecWorkDate = Date.Now.Date
			_device.Device_Qty = 1
			_device.Loc_ID = _loc_id
			_device.Model_ID = model_id
			_device.ApplyChanges()
			Return _device.Device_ID
		End Function

		Function CreateBox( _
		 ByRef dt As DataTable, _
		 ByVal model_id As Integer, _
		 ByVal user_id As Integer, _
		 ByVal cpl_id As Integer, _
		 ByVal disp_id As Integer, _
		ByVal apply_billing As Boolean) _
		 As Integer Implements Interfaces.ICustReceiving.CreateBox
			' PROCESS FOR CREATING A BOX.
			Dim _box_nr As String
			Dim _dr As DataRow
			Dim _boxid As Integer
			Dim _dm As New Data.BLL.DeviceMovement(_user_id)
			Dim _WsName As String = _dm.GetLocName(cpl_id)
			Dim _disp As New BOL.tdispositions(disp_id)
			Dim _prefix As String = _disp.disp_cd.Substring(0, 1)
			_disp = Nothing
			_user_id = user_id
			_model_id = model_id
			_qty = dt.Rows.Count
			_box_nr = GetBoxNumber(_prefix)
			_boxid = InsertWh_box(_box_nr, cpl_id, disp_id)
			' GET THE WORKSTATION DESTINATION FOR THIS CUSTOMER BASED ON THE DISPOSITION.
			For Each _dr In dt.Rows
				' GET DEVICE_ID.
				Dim _sn As String = _dr("sn").ToString()
				Dim _d As New BOL.tDevice(_sn, _loc_id)
				Dim _device_id As Integer = _d.Device_ID
				_d = Nothing
				UpdateWorkstation(_device_id, _boxid, _box_nr, _WsName)
				' APPLY BILLING HERE IF NEEDED.
				If apply_billing Then
					Dim _tdb As New BLL.WFMBilling(_user_id)
					_tdb.AddLaborCharges(Interfaces.BILLING_POINT.TRIAGE_BOXING, _device_id, disp_id)
				End If
			Next
			Return _boxid
		End Function

		Function CreateBoxAndDevices( _
		 ByRef dt As DataTable, _
		 ByVal model_id As Integer, _
		 ByVal user_id As Integer, _
		 ByVal cpl_id As Integer, _
		 ByVal disp_id As Integer, _
		ByVal apply_billing As Boolean) _
		 As Integer Implements Interfaces.ICustReceiving.CreateBoxAndDevices
			' Process for creating a box.
			Dim _box_nr As String
			Dim _dr As DataRow
			Dim _boxid As Integer
			Dim _newWs As String = ""
			Dim _prefix As String = ""

			_newWs = GetTargetLocation(cpl_id)

			If disp_id > 0 Then
				_prefix = _newWs.Substring(0, 1)
			Else
				_prefix = "R"
			End If
			_user_id = user_id
			_model_id = model_id
			_qty = dt.Rows.Count
			_box_nr = GetBoxNumber(_prefix)
			_boxid = InsertWh_box(_box_nr, cpl_id, disp_id)
			For Each _dr In dt.Rows
				Dim _item_id As Integer
				Dim _device_id As Integer
				Dim _co_id As Integer
				' HANDLE THE BOXING OF THE DEVICES.
				_device_id = InsertTdevice(_dr("sn").ToString(), model_id)
				_item_id = InsertTitem(_qty, _dr("sn").ToString(), _device_id, _boxid, _box_nr)
				_co_id = Inserttcellopt(_device_id, _newWs)

				'' APPLY BILLING HERE IF NEEDED.
				'If apply_billing Then
				'	Dim _tdb As New Data.BLL.WFMBilling(_user_id)
				'	If Not _tdb.AddLaborCharges(Interfaces.BILLING_POINT.TRIAGE_BOXING, _device_id, disp_id) Then
				'		Throw New Exception("Unable to apply Labor Charges one or more devices.")
				'	End If
				'End If
			Next
			Return _boxid
		End Function

		Private Sub UpdateWorkstation( _
		  ByVal device_id As Integer, _
		  ByVal whb_id As Integer, _
		  ByVal box_name As String, _
		  ByVal ws As String)
			' GET THE TITEM RECORD TO AQURIRE THE DEVICE_ID AND 
			' UPDATE THE WHB_ID and BOXID FIELDS.
			Dim _device_id As Integer
			Dim _itm As New BOL.titem(device_id)
			_itm.BoxID = box_name
			_itm.wb_id = 0
			_itm.whb_id = whb_id
			_itm.ApplyChanges()
			_itm = Nothing
			' UPDATE THE WORKSTATION IN TCELLOPT.
			Dim _co As New BOL.tcellopt(device_id)
			_co.WorkStation = ws
			_co.WorkStationEntryDt = Date.Now
			_co.ApplyChanges()
			_co = Nothing
		End Sub

		Function InsertWh_box( _
		 ByVal box_name As String, _
		 ByVal cpl_id As Integer, _
		 ByVal disp_id As Integer) _
		 As Integer Implements Interfaces.ICustReceiving.InsertWh_box
			' Inserts a record into the warehouse.wh_box table.
			Dim _wb As New BOL.wh_box()
			_wb.box_na = box_name
			_wb.cpl_id = cpl_id
			_wb.closed = 1
			_wb.crt_user_id = _user_id
			_wb.cust_id = _cust_id
			_wb.model_id = _model_id
			_wb.disp_id = disp_id
			_wb.quantity = _qty
			_wb.crt_user_id = _user_id
			_wb.ApplyChanges()
			Return _wb.whb_id
		End Function

		Function InsertTitem( _
		 ByVal qty As Integer, _
		 ByVal sn As String, _
		 ByVal device_id As Integer, _
		 ByVal whb_id As Integer, _
		 ByVal box_na As String) _
		 As Integer Implements Interfaces.ICustReceiving.InsertTitem
			' Inserts a record into the edi.titem table.
			Dim _itm As New BOL.titem()
			_itm.SN = sn
			_itm.Device_ID = device_id
			_itm.Prod_Code = "2"
			_itm.BoxID = box_na
			_itm.whb_id = whb_id
			_itm.ApplyChanges()
			Return _itm.Item_ID
		End Function

		Function Inserttcellopt( _
		 ByVal device_id As Integer, _
		ByVal ws As String) _
		 As Integer Implements Interfaces.ICustReceiving.Inserttcellopt
			' Insert a record into the production.tcellopt table.
			Dim _co As New BOL.tcellopt()
			_co.Device_ID = device_id
			_co.WorkStation = ws
			_co.WorkStationEntryDt = Date.Now
			_co.ApplyChanges()
			Return _co.CellOpt_ID
		End Function

		Function GetTargetLocation( _
		 ByVal cpl_id_from As Integer, _
		 ByVal disp_id As Integer) As String
			' GET THE WORKSTATION DESTINATION FOR THIS CUSTOMER BASED ON THE DISPOSITION.
			Dim _wf As New BOL.tcustomer_prod_workflow(cpl_id_from, disp_id)
			Dim _ws_id As String = _wf.cpl_id_to
			_wf = Nothing
			Dim _loc As New BOL.tcustomer_prod_locations(_ws_id)
			Dim _ws As String = _loc.loc_na
			_loc = Nothing
			Return _ws
		End Function

		Function GetTargetLocation(ByVal cpl_id_to As Integer) As String
			' GET THE WORKSTATION.
			Dim _loc As New BOL.tcustomer_prod_locations(cpl_id_to)
			Dim _ws As String = _loc.loc_na
			_loc = Nothing
			Return _ws
		End Function

#End Region
	End Class
End Namespace
