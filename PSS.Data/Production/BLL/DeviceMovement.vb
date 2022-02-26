Namespace BLL
	Public Class DeviceMovement
		Implements Interfaces.IDeviceMovement
		Private _user_id As Integer
		Public Sub New(ByVal user_id As Integer)
			MyBase.New()
			_user_id = user_id
		End Sub
		Public Function GetNextLocName(ByVal cpl_id As Integer) As String Implements Interfaces.IDeviceMovement.GetNextLocName
			' RETURNS THE NEXT LOCATION NAME
			Dim _next_cpl_id As Integer
			Dim _retVal As Integer
			Dim _loc As New Data.BOL.tcustomer_prod_workflow(cpl_id)
			_next_cpl_id = _loc.cpl_id_to
			_loc = Nothing
			_retVal = GetLocName(_next_cpl_id)
			Return _retVal
		End Function
		Public Function GetLocName(ByVal cpl_id As Integer) As String
			Dim _retVal As String
			Dim _cpl As New BOL.tcustomer_prod_locations(cpl_id)
			_retVal = _cpl.loc_na
			_cpl = Nothing
			Return _retVal
		End Function
		Public Function GetNextLocNameWithDisp(ByVal cpl_id As Integer, ByVal disp_id As Integer, Optional ByVal use_fail_loc As Boolean = False) As String Implements Interfaces.IDeviceMovement.GetNextLocNameWithDisp
			' RETURNS THE NEXT LOCATION NAME BASED ON LOCATION AND DISPOSITION.
			Dim _retVal As Integer
			Dim _loc As New Data.BOL.tcustomer_prod_workflow(cpl_id, disp_id, use_fail_loc)
			_retVal = _loc.cpl_id_to
			_loc = Nothing
			Return _retVal
		End Function
		Public Function GetNextLocID(ByVal cpl_id As Integer, Optional ByVal disp_id As Integer = 0, Optional ByVal use_fail_loc As Boolean = False) As Integer Implements Interfaces.IDeviceMovement.GetNextLocID
			' RETURNS THE NEXT LOCATION NAME
			Dim _retVal As Integer
			Dim _loc As New Data.BOL.tcustomer_prod_workflow(cpl_id, disp_id, use_fail_loc)
			_retVal = _loc.cpl_id_to
			_loc = Nothing
			Return _retVal
		End Function
		Public Function GetNextLocIDWithDisp(ByVal cpl_id As Integer, ByVal disp_id As Integer) As Integer Implements Interfaces.IDeviceMovement.GetNextLocIDWithDisp
			' RETURNS THE NEXT LOCATION NAME BASED ON LOCATION AND DISPOSITION.
			Dim _retVal As Integer
			Dim _loc As New Data.BOL.tcustomer_prod_workflow(cpl_id, disp_id)
			_retVal = _loc.cpl_id_to
			_loc = Nothing
			Return _retVal
		End Function
		Public Function MoveDeviceToLoc(ByVal device_id As Integer, ByVal cpl_id_to As Integer, Optional ByVal wipowner As Integer = 0) As Boolean Implements Interfaces.IDeviceMovement.MoveDeviceToLoc
			' MOVES A DEVICE.
			Dim _wsName As String = ""
			Dim _ws As New BOL.tcustomer_prod_locations(cpl_id_to)
			_wsName = _ws.loc_na
			_ws = Nothing
			' UPDATE TCELLOPT.
			Dim _co As New BOL.tcellopt(device_id)
			_co.WorkStation = _wsName
			_co.WorkStationEntryDt = Date.Now()
			If wipowner > 0 Then _co.Cellopt_WIPOwner = wipowner
			_co.ApplyChanges()
			_co = Nothing
		End Function
		Public Function GetNextLocForDisp(ByVal cpl_id As Integer, ByVal disp_id As Integer)

		End Function
		Public Function GetNextLoc(ByVal cpl_id As Integer) As Integer
			Dim _retVal As Integer
			Dim _loc As New Data.BOL.tcustomer_prod_workflow(cpl_id)
			_retVal = _loc.cpl_id_to
			_loc = Nothing
			Return _retVal
		End Function
		Public Function MoveBoxToLoc(ByVal whb_id As Integer, ByVal cpl_id_to As Integer)
			' MOVE THE BOX.
			Dim _wb As New BOL.wh_box(whb_id)
			_wb.cpl_id = cpl_id_to
			' MOVE THE DEVICES IN THE BOX.
			Dim _itmDt As New DataTable()
			Dim _itm As New BOL.titem_wh_box_Collection(whb_id)
			_itmDt = _itm.titemDataTable.Copy
			_itm = Nothing
			Dim _dr As DataRow()
			For Each _dr In _itmDt.Rows
				MoveDeviceToLoc(Convert.ToInt16(_dr("device_id")), cpl_id_to)
			Next
		End Function
		Public Function GetDevCntForPlt(ByVal pallet_id As Integer) As Integer
			Dim _retVal As Integer = 0
			Dim _dcbp As New BOL.tDeviceCollectionByPallett(pallet_id)
			_retVal = _dcbp.deviceDataTable.Rows.Count
			_dcbp = Nothing
		End Function
		Public Function GetDevWrkstnsForPlt(ByVal pallet_id As Integer) As DataTable
			Dim _dt As New DataTable()
			Dim _coWsByPlt As New BOL.tcelloptWsByPltCollection(pallet_id)
			_dt = _coWsByPlt.tcelloptDataTable.Copy
			_coWsByPlt = Nothing
			Return _dt
		End Function
		Public Function GetDevWrkstnsForWHBox(ByVal whb_id As Integer) As DataTable
			Dim _dt As New DataTable()
			Dim _itmWsByBox As New BOL.titemWrkStnByWHBoxCollection(whb_id)
			_dt = _itmWsByBox.titemWSDataTable.Copy
			_itmWsByBox = Nothing
			Return _dt
		End Function

	End Class
End Namespace