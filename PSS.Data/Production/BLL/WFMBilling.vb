Namespace BLL
	Public Class WFMBilling
		Inherits BaseClasses.CustBilling
#Region "CONSTRUCTORS"
		Sub New(ByVal user_id As Integer)
			MyBase.New()
			_user_id = user_id
			_cust_id = 2597
			_loc_id = 3402
			_prod_id = 2
		End Sub
#End Region
#Region "OVERRIDES"
		Public Overrides Function AddLaborCharges(ByVal billing_point As Interfaces.BILLING_POINT, ByVal device_id As Integer, ByVal disp_id As Integer) As Boolean
			Dim _cbp As New DataTable()
			Dim _bc_amt As Decimal
			' GET CUST LABOR CHARGES
			Dim _cust_billing_points_col As New BOL.tcust_billing_pointsCollection(billing_point, _cust_id, _prod_id, disp_id)
			_cbp = _cust_billing_points_col.tcust_billing_pointsDataTable
			Dim _cbp_dr As DataRow
			Dim _d As New BOL.tDevice(device_id)
			For Each _cbp_dr In _cbp.Rows()
				' ADD TDEVICEBILL RECORD.
				Dim _ab As New BOL.tcustaggregatebilling(_cust_id, _cbp_dr("billcode_id"))
				' GET THE BILLCODE AMOUNT.
				_bc_amt = _ab.tcab_Amount
				Dim _tdb As New BOL.tDeviceBill()
				_tdb.Device_ID = device_id
				_tdb.BillCode_ID = _cbp_dr("billcode_id")
				_tdb.DBill_InvoiceAmt = _bc_amt
				_tdb.User_ID = _user_id
				_tdb.ApplyChanges()

				' UPDATE LABOR CHARGE IN TDEVICE.
				_d.Device_LaborCharge = _d.Device_LaborCharge + _bc_amt
				_d.Device_DateBill = Date.Now
				' CLEAN UP.
				_tdb = Nothing
				_ab = Nothing
			Next
			' APPLY TDEVICE UPDATE.
			_d.ApplyChanges()
			_d = Nothing
			Return True
		End Function
		Public Overrides Function AddPartCharge()
			Throw New ExecutionEngineException("Not Implemented for this customer.")
		End Function
		Public Overrides Function RemoveBillingFromDevice(ByVal device_id As Integer)
			Dim _dt As New DataTable()
			Dim _dbCol As New BOL.tDeviceBillCollection(device_id)
			_dt = _dbCol.tDeviceBillDataTable().Copy
			_dbCol = Nothing
			Dim _dr As DataRow
			For Each _dr In _dt.Rows()
				Dim _id As Integer = _dr("dbill_id")
				Dim _db As New BOL.tDeviceBill(_id)
				_db.MarkForDelete()
				_db.ApplyChanges()
			Next
			_dt = Nothing
		End Function
#End Region
#Region "PROPERTIES"
		Public ReadOnly Property Prod_ID() As Integer
			Get
				Return _prod_id
			End Get
		End Property

#End Region
	End Class
End Namespace
