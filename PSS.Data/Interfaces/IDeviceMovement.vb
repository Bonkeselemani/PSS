Namespace Interfaces

	Public Interface IDeviceMovement
		' Returns the next location name
		Function GetNextLocName(ByVal cpl_id As Integer) As String
		' Returns the next location name based on location and disposition.
		Function GetNextLocNameWithDisp(ByVal cpl_id As Integer, ByVal disp_id As Integer, Optional ByVal use_fail_loc As Boolean = False) As String
		' Returns the next location name
		Function GetNextLocID(ByVal cpl_id As Integer, Optional ByVal disp_id As Integer = 0, Optional ByVal use_fail_loc As Boolean = False) As Integer
		' Returns the next location name based on location and disposition.
		Function GetNextLocIDWithDisp(ByVal cpl_id As Integer, ByVal disp_id As Integer) As Integer
		' Moves a device.
		Function MoveDeviceToLoc(ByVal device_id As Integer, ByVal cpl_id_to As Integer, Optional ByVal wipowner As Integer = 0) As Boolean
	End Interface

End Namespace




