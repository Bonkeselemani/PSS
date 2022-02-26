Imports PSS.Data
Imports PSS.Data.BOL
Imports PSS.Data.Buisness.Generic

Namespace BLL

	Public Class MsgDeviceMovement

#Region "SHARED METHODS"

		Public Shared Function MoveDeviceToWIPOwner( _
		  ByVal device_id As Integer, _
		  ByVal wipowner_id As Integer, _
		  ByVal wipownersub_id As Integer, _
		  ByVal cc_id As Integer, _
		  ByVal process_na As String, _
		  ByVal user_na As String) As Boolean

			Dim _retVal As Boolean = False
			Dim _cur_wipowner_id As Integer
			Dim _cur_wipownersub_id As Integer
			Dim _cur_wipowner_entrydt As String
			Dim _cur_wipowner_old_id As Integer
			Dim _cur_cc_id As Integer
			Dim _cur_cc_entry_dt As String
			Dim _wipowner As String
			Dim _wipownersubloc As String
			Dim _costcenter As String
			Dim _WIPOwnerMoveValid As Boolean = False
			Dim _CostCenterChangeValid As Boolean = False

			Try
				'' GET DEVICE
				Dim _device As New BOL.tDevice(device_id)
				_cur_cc_id = _device.cc_id
				_cur_cc_entry_dt = _device.CC_EntryDate.ToString()

				' GET MESSDATA
				Dim _messdata As New BOL.tMessData(device_id)
				_cur_wipowner_id = _messdata.wipowner_id
				_cur_wipownersub_id = _messdata.wipownersubloc_id
				_cur_wipowner_entrydt = _messdata.wipowner_EntryDt.ToString()
				_cur_wipowner_old_id = _messdata.wipowner_id_Old

				' GET WIP OWNER
				Dim _wo As New BOL.lwipowner(wipowner_id)
				_wipowner = _wo.wipowner_desc
				_wo = Nothing

				' GET WIP OWNER SUB LOCATION
				Dim _wosl As New BOL.lwipownersubloc(wipownersub_id)
				_wipownersubloc = _wosl.wipownersubloc_desc
				_wosl = Nothing

				' GET THE COST CENTER
				Dim _cc As New BOL.tcostcenter(cc_id)
				_costcenter = _cc.cc_desc
				_cc = Nothing

				' VALIDATE THE MOVE LOGIC HERE.
				_WIPOwnerMoveValid = ValidateWIPOwnerMove()
				' THROW EXCEPTION IF MOVE IS NOT VALID.
				If Not _WIPOwnerMoveValid Then
					Dim _cur_wo As New BOL.lwipowner(_cur_wipowner_id)
					Dim _cur_wipowner As String = _cur_wo.wipowner_desc
					If _cur_wipowner = "" Then
						Throw New Exception("Moving device to " & _wipowner & " is not valid.")
					Else
						Throw New Exception("Moving device from " & _cur_wipowner_id & " to " & _wipowner & " is not valid.")
					End If
				End If

				' UPDATES HERE
				If cc_id > 0 Then
					_device.cc_id = cc_id
					_device.CC_EntryDate = IIf(_wipowner = "In-Cell", Format(Now, "yyyy-MM-dd HH:mm:ss"), "")
					_device.ApplyChanges()
					_device = Nothing
				End If

				_messdata.wipowner_id = wipowner_id
				_messdata.wipownersubloc_id = wipownersub_id
				_messdata.wipowner_EntryDt = Date.Now()
				_messdata.wipowner_id_Old = _cur_wipowner_id
				_messdata.ApplyChanges()
				_messdata = Nothing

				' INSERT THE JOURNAL ENTRY.
				Dim _dwj As New BOL.tdevice_workstation_journal( _
				  device_id, _
				  1, _
				  _wipowner, _
				  _wipownersubloc, _
				  user_na, _
				  Environment.MachineName, _
				  process_na)
				_dwj.ApplyChanges()
				_dwj = Nothing

				' IF MOVING TO WAREHOUSE ADJUST TABLES.
				If wipowner_id = 201 Then
					AdjustDevice_WIPToWH(device_id, process_na, user_na)
				End If

				Return True
			Catch ex As Exception
				Throw ex
				Return False
			End Try

		End Function

		Private Shared Function ValidateWIPOwnerMove() As Boolean
			'THIS IS NOT YET IMPLETMENTED.'
			Return True
		End Function

		Private Shared Function ValidateCostCenterChange(ByVal costcenter As String, ByVal wipowner As String) As Boolean
			If costcenter <> "" AndAlso wipowner = "In-Cell" Then
				Return True
			ElseIf costcenter = "" Then
				Return True
			Else
				Return False
			End If
			Return False
		End Function

		Public Shared Function DeviceMovementJornalInsert( _
		 ByVal device_id As Integer, _
		 ByVal product_type_id As Integer, _
		 ByVal wipowner_id As Integer, _
		 ByVal wipownersubloc_id As Integer, _
		 ByVal prc_name As String)
			Dim _app As New BaseClasses.App()
			_app = BaseClasses.App.Create(0, "", "")
			' GET THE WIP OWNER
			Dim _wo As New BOL.lwipowner(wipowner_id)
			Dim _wo_desc As String = _wo.wipowner_desc
			_wo = Nothing
			' GET THE WIP SUB OWNER
			Dim _wosl As New BOL.lwipownersubloc(wipownersubloc_id)
			Dim _wosl_desc As String = _wosl.wipownersubloc_desc
			_wosl = Nothing
			' INSERT THE DEVICE JOURNAL ENTRY.
			Dim _dwj As New BOL.tdevice_workstation_journal( _
			 device_id, product_type_id, _wo_desc, _wosl_desc, _
			 _app.Fullname, _app.MachineName, prc_name)
			_dwj.ApplyChanges()
			_dwj = Nothing
		End Function

		Private Shared Function AdjustDevice_WIPToWH( _
		 ByVal device_id As Integer, _
		  ByVal process_na As String, _
		  ByVal user_na As String) As Boolean

			' Remove TQC information.
			Dim _qcRslt As Boolean = BLL.QaulityControl.RemoveAllQCForDevice(device_id)

			' Remove Billing information.
			Dim _billRslt As Boolean = BOL.tDeviceBill_Shared.RemoveAllBillingForDevice(device_id)

			' Adjust the tmessdata table fields.
			Dim _md As New tMessData(device_id)
			_md.EvalBillCode_ID = 0
			_md.EvalCharges = 0.0
			_md.EvalUserID = 0
			_md.QR_PSSWtyUpdateDT = ""
			_md.QR_PSSWtyUpdateUsrID = 0
			_md.qcresult_id = 0
			_md.qcwork_date = ""
			_md.aqlreject = 0
			_md.aqlreject_date = ""
			_md.ApplyChanges()
			_md = Nothing

			' Adjust the tdevice table fields.
			Dim _d As New tDevice(device_id)
			_d.Device_DateBill = ""
			_d.Device_DateShip = ""
			_d.Device_LaborCharge = 0
			_d.Device_PartCharge = 0.0
			_d.Device_ManufWrtyLaborCharge = 0.0
			_d.Device_ManufWrtyPartCharge = 0.0
			_d.Device_FinishedGoods = 0
			_d.Device_ShipWorkDate = ""
			_d.Ship_ID = 0
			_d.cc_id = 0
			_d.CC_EntryDate = ""
			_d.ApplyChanges()
			_d = Nothing


			' INSERT THE JOURNAL ENTRY.
			Dim _dwj As New BOL.tdevice_workstation_journal( _
			   device_id, 1, "WH", "", user_na, Environment.MachineName, "Billing and QC Removed.")
			_dwj.ApplyChanges()
			_dwj = Nothing

		End Function

#End Region

	End Class

End Namespace
