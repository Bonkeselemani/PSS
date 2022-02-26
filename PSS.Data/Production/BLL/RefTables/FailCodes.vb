Namespace BLL.RefTables

	Public Class FailCodes

		Private _user_id As Integer = 0

		Private Sub New()
		End Sub

		Public Sub New(ByVal user_id As Integer)
			_user_id = user_id
		End Sub

		Public Enum Failcode_Type
			Visual = 1
			Software = 2
			Functional = 3
			Cosmetic = 4
		End Enum

		Public Function AddNewFailCode( _
		 ByVal cust_id As Integer, _
		 ByVal prod_id As Integer, _
		 ByVal failcode_type As Failcode_Type, _
		 ByVal failcode_desc As String) As Boolean
			Dim _fc As New BOL.tFailCodes()
			Dim _fc_id As Integer = 0
			' GET EXISTING FAIL CODE IF IT EXISTS.
			_fc = New BOL.tFailCodes(failcode_type, failcode_desc)
			' INSERT THE FAIL CODE IF IT DOES NOT EXIST.
			If _fc.fc_id < 1 Then
				_fc = New BOL.tFailCodes()
				_fc.fc_desc = failcode_desc
				_fc.fct_id = failcode_type
				_fc.crt_user_id = _user_id
				_fc.ApplyChanges()
			End If
			_fc_id = _fc.fc_id
			_fc = Nothing
			' INSERT THE NEW FAILCODE ASSIGNMENT FOR THE CURRENT CUSTOMER.
			Dim _cpfc As New BOL.tCustProductFailCodes()
			_cpfc.fc_id = _fc_id
			_cpfc.cust_id = cust_id
			_cpfc.prod_id = prod_id
			_cpfc.crt_user_id = _user_id
			_cpfc.ApplyChanges()
			_cpfc = Nothing
			Return True
		End Function

	End Class

End Namespace
