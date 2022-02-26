Namespace BaseClasses
	Public Class App
		Private Shared [Global] As App
		Private Shared _user_id As Integer
		Private Shared _username As String
		Private Shared _fullname As String
		Private Shared _machinename As String
		Public Shared Function Create(ByVal user_id As Integer, ByVal full_name As String, ByVal machine_name As String) As App
			If [Global] Is Nothing Then
				[Global] = New App()
				_user_id = user_id
				_fullname = full_name
				_machinename = machine_name
			End If
			Return [Global]
		End Function
		Public ReadOnly Property user_id() As Integer
			Get
				Return _user_id
			End Get
		End Property
		Public ReadOnly Property Fullname() As String
			Get
				Return _fullname
			End Get
		End Property
		Public ReadOnly Property MachineName() As String
			Get
				Return _machinename
			End Get
		End Property
	End Class
End Namespace
