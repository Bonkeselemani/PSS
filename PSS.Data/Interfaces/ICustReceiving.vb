Namespace Interfaces
	Public Interface ICustReceiving
		' Process for creating a box and device records.
		Function CreateBox(ByRef dt As DataTable, ByVal model_id As Integer, ByVal user_id As Integer, ByVal cpl_id As Integer, ByVal disp_id As Integer, ByVal apply_billing As Boolean) As Integer
		' Process for creating a box and device records.
		Function CreateBoxAndDevices(ByRef dt As DataTable, ByVal model_id As Integer, ByVal user_id As Integer, ByVal cpl_id As Integer, ByVal disp_id As Integer, ByVal apply_billing As Boolean) As Integer
		' Builds the box number to be used.
		Function GetBoxNumber(ByVal Prefix As String) As String
		' Inserts a record into the warehouse.wh_box table.
		Function InsertWh_box(ByVal box_name As String, ByVal cpl_id As Integer, ByVal disp_id As Integer) As Integer
		' Inserts a record into the edi.titem table.
		Function InsertTitem( _
		 ByVal qty As Integer, _
		 ByVal sn As String, _
		 ByVal device_id As Integer, _
		 ByVal whb_id As Integer, _
		 ByVal box_na As String) As Integer
		' Inserts a record into the production.tdevice table.
		Function InsertTdevice(ByVal sn As String, ByVal model_id As Integer) As Integer
		' Insert a record into the production.tcellopt table.
		Function Inserttcellopt(ByVal device_id As Integer, ByVal ws As String) As Integer
	End Interface
End Namespace
