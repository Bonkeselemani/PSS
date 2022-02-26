Imports System.String
Imports System.Data
Namespace BLL
	Public Class WHBoxMovement
#Region "DECLARATIONS"

		Private _dtSerials As New DataTable()
		Private _box_id As Integer = 0
		Private _cust_id As Integer = 0
		Private _prod_id As Integer = 0
		Private _cpl_id As Integer = 0
		Private _disp_id As Integer = 0
		Private _cpl_id_to As Integer = 0
		Private _user_id As Integer = 0

#End Region
#Region "CONSTRUCTORS"
		Public Sub New( _
		 ByVal box_id As Integer, _
		 ByVal cust_id As Integer, _
		 ByVal prod_id As Integer, _
		 ByVal disp_id As Integer, _
		 ByVal cpl_id As Integer, _
		 ByVal cpl_id_to As Integer, _
		 ByVal user_id As Integer)
			_box_id = box_id
			_cust_id = cust_id
			_prod_id = prod_id
			_disp_id = disp_id
			_cpl_id = cpl_id
			_cpl_id_to = cpl_id_to
			_user_id = user_id
		End Sub
#End Region
#Region "METHODS"
		Public Function ValidateBoxTransfer() As String
			Dim _retVal As String = ""
			Dim _bx As New BOL.wh_box(_box_id)
			Dim _model_id As Integer = _bx.model_id
			Dim _qty As Integer = _bx.quantity
			Dim workstation As String = ""
			Dim _disp_id As Integer = _bx.disp_id
			' VALIDATE BOX BELONGS TO CUSTOMER.
			If _bx.cust_id <> _cust_id Then
				_retVal = "Incorrect customer assigned to this box."
				' VALIDATE DISPOSITION.
			ElseIf _bx.disp_id <> _disp_id Then
				_retVal = "Disposition is not valid for this transfer."
				' VALIDATE FROM LOCATION.
			ElseIf _bx.cpl_id <> _cpl_id Then
				_retVal = "Incorrect current location for this transfer."
			Else
				' VALIDATE TO LOCATION.
				Dim _to_ok As Boolean = False
				Dim _wf As New BOL.tcustomer_prod_WfByLocAndDispCol(_bx.cpl_id, 0)
				Dim _dr As DataRow
				For Each _dr In _wf.tcustomer_prod_workflowDataTable.Rows()
					If _dr("cpl_id_to") = _cpl_id_to Then
						_to_ok = True
						Exit For
					End If
				Next
				If Not _to_ok Then
					_retVal = "The transfer destination is not valid for this box."
				End If
			End If
			' VALIDATE THE DEVICE QUANTITY IS ACCURATE.
			If _retVal = "" Then
				_retVal = ValidateDeviceQtyInBox(_box_id, _bx.quantity)
			End If
			Return _retVal
		End Function
		Private Function ValidateDeviceQtyInBox( _
		 ByVal box_id As Integer, _
		 ByVal qty As Integer) As String
			Dim _retVal As String = ""
			Dim _itmCol As New BOL.titem_wh_box_Collection(box_id)
			' TITEM QUANTITY VALIDATION.
			If _itmCol.titemDataTable.Rows.Count <> qty Then
				_retVal = "Number of devices does not match the box quantity"
			End If
			_itmCol = Nothing
			Return _retVal
		End Function
		Public Function PerformTransfer() As Boolean
			Dim _retVal As Boolean
			If ValidateBoxTransfer() <> "" Then
				_retVal = False
			Else
				_retVal = True
			End If
			' Transfer the box.
			' UPDATE WH_BOX.
			Dim _loc As New BOL.tcustomer_prod_locations(_cpl_id_to)
			Dim _wb As New BOL.wh_box(_box_id)
			Dim _clearBin As Boolean = False
			Dim _toLoc As String
			_wb.cpl_id = _cpl_id_to
			_wb.bin_id = IIf(_loc.allow_bin, _wb.bin_id, 0)
			_wb.ApplyChanges()
			_wb = Nothing
			_toLoc = _loc.loc_na
			_loc = Nothing
			' UPDATE TCELLOPT.
			Dim _tItemCol As New BOL.titem_wh_box_Collection(_box_id)
			Dim dr As DataRow
			For Each dr In _tItemCol.titemDataTable.Rows()
				Dim _co As New BOL.tcellopt(dr("device_id"))
				_co.WorkStation = _toLoc
				_co.WorkStationEntryDt = Date.Now()
				_co.ApplyChanges()
			Next
			_tItemCol = Nothing
			Return _retVal
		End Function
#End Region
	End Class
End Namespace