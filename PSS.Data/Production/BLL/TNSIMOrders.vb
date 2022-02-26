Imports System.Text
Imports PSS.Data.Buisness.Generic

Namespace BLL

	Public Class TNSIMOrders

#Region "DECLARATIONS"

		Private _cust_id As Integer = 0
		Private _loc_id As Integer = 0
		Private _prod_id As Integer = 0
		Private _group_id As Integer = 0
		Private _user_id As Integer = 0
		Private _objDataProc As DBQuery.DataProc

#End Region
#Region "CONSTRUCTORS"

		Public Sub New(ByVal user_id As Integer)
			Dim _tn As New Buisness.TN()
			_cust_id = _tn.CUSTOMERID
			_loc_id = _tn.LOCID
			_prod_id = _tn.PRODID
			_group_id = _tn.GROUPID
			_tn = Nothing
			_user_id = user_id
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
		End Sub

#End Region
#Region "RETURNS"

		Public Function ProcessReturn(ByVal tracking_number As String, ByVal sn As String, ByVal reason As String) As Boolean
			Dim _soheaderid As Integer
			Dim _device_id As Integer = 0
			Dim _wo_id As Integer = 0

			' UPDATE SOHEADER.
			Dim _soh As New BOL.soheader(tracking_number)
			_soheaderid = _soh.SOHeaderID
			_soh.ShipDate = ""
			_soh.ShipUserID = 0
			_soh.InvalidOrder = 1
			_soh.InvalidOrder_UserID = _user_id
			_soh.ReasonOrderInvalid = reason
			_soh.InvalidOrder_DateTime = Date.Now
			_soh.ApplyChanges()
			_soh = Nothing

			' UPDATE SODETAILS.
			Dim _sod As New BOL.sodetails(_soheaderid)
			_sod.SODetailsID = 0
			_sod.ApplyChanges()
			_sod = Nothing

			' UPDATE TDEVICE.
			Dim _device As New BOL.tDevice(sn, _loc_id)
			_device_id = _device.Device_ID
			_wo_id = _device.WO_ID
			_device.Device_DateShip = ""
			_device.Device_ShipWorkDate = ""
			_device.Device_FinishedGoods = 0
			_device.WO_ID = 0
			'_device.Device_LaborLevel = 0
			'_device.Device_LaborCharge = 0.0
			_device.ApplyChanges()
			_device = Nothing

			' UPDATE TWORKORDER.
			Dim _wo As New BOL.tworkorder(_wo_id)
			_wo.WO_Closed = 0
			_wo.WO_Shipped = False
			_wo.WO_DateShip = ""
			_wo.ApplyChanges()
			_wo = Nothing

			' REMOVE TDEVICEBILL RECORDS.
			Dim _dbCol As New BOL.tDeviceBillCollection(_device_id)
			Dim _dr As DataRow
			For Each _dr In _dbCol.tDeviceBillDataTable.Rows()
				Dim _dbill_id As Integer = _dr("DBill_ID")
				Dim _db As New BOL.tDeviceBill(_dbill_id)
				_db.MarkForDelete()
				_db.ApplyChanges()
				_db = Nothing
			Next

			Return True

		End Function

#End Region

	End Class

End Namespace

