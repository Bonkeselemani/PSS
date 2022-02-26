Namespace Interfaces

	Public Enum BILLING_POINT
		TRIAGE_BOXING = 1
		PRODUCED = 2
		DOCKSHIP = 3
	End Enum

	Public Interface ICustBilling
		' Process for Adding Labor Charge.
		Function AddLaborCharges(ByVal billing_point As BILLING_POINT, ByVal device_id As Integer, ByVal disp_id As Integer) As Boolean
		' Process for Adding Labor Charge.
		Function AddPartCharge()
		' Remove billing from device.
		Function RemoveBillingFromDevice(ByVal device_id As Integer)
	End Interface

End Namespace
