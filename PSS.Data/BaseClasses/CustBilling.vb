Namespace BaseClasses
	Public MustInherit Class CustBilling
		Implements Interfaces.ICustBilling
#Region "DECLARATIONS"
		Friend _user_id As Integer
		Friend _cust_id As Integer = 0
		Friend _loc_id As Integer = 0
		Friend _prod_id As Integer = 0
#End Region
#Region "MUSTOVERRIDE"
		Public MustOverride Function AddLaborCharges(ByVal billing_point As Interfaces.BILLING_POINT, ByVal device_id As Integer, ByVal disp_id As Integer) As Boolean Implements Interfaces.ICustBilling.AddLaborCharges
		Public MustOverride Function AddPartCharge() Implements Interfaces.ICustBilling.AddPartCharge
		Public MustOverride Function RemoveBillingFromDevice(ByVal device_id As Integer) Implements Interfaces.ICustBilling.RemoveBillingFromDevice
#End Region
	End Class
End Namespace

