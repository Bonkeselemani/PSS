Imports System.String
Imports System.Text

Namespace BLL

	' THIS CLASS IS A TEXTNOW SIMS RECEIVING BUSINESS LOGIC LAYER CLASS 
	' THAT WAS DESIGNED TO WORK WITH THE TEXTNOW BOL CLASSES.

	Public Class TNSIMReceiving

#Region "DECLARATIONS"

		Private _cust_id As Integer = 0
		Private _loc_id As Integer = 0
		Private _prod_id As Integer = 0
		Private _group_id As Integer = 0
		Private _user_id As Integer = 0
		Private _cdma_id As Integer = 4162
		Private _gsm_id As Integer = 4163

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
		End Sub

#End Region

#Region "TEST METHODS" ' Methods used for testing for valid entries.

		Public Function IsSNRangeValid(ByVal startSN As String, ByVal endSN As String, ByVal simTypeId As Integer) As Boolean
			' VALIDATES THE RANGE OF SERIAL NUMBERS CAN BE CREATED WITHOUT CONFLICT.
			Dim _retVal As Boolean = False
			Dim _objDataProc As New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			Dim _dt As New DataTable()
			Dim _sb As New StringBuilder()
			Dim _start As Decimal
			_start = Convert.ToDecimal(startSN)
			_sb.Append("SELECT ")
			_sb.Append("device_id, ")
			_sb.Append("device_sn ")
			_sb.Append("FROM production.tdevice ")
			_sb.Append("WHERE ")
			_sb.Append(" loc_id = 3400 ")
			_sb.Append(" AND ")
			Select Case simTypeId
				Case _cdma_id
					_sb.Append("LEFT(device_sn,LENGTH(device_sn)-1) BETWEEN ")
				Case _gsm_id
					_sb.Append("LEFT(device_sn,LENGTH(device_sn)-2) BETWEEN ")
				Case Else
					_sb.Append("9999 BETWEEN ")					  ' THIS ONE WILL NEVER BE VALID.
			End Select
			_sb.Append("'" & _start & "'")
			_sb.Append(" AND ")
			_sb.Append("'" & endSN & "'")
			_sb.Append(" LIMIT 1;")			 ' Limited to one because any is too many.
			_dt = _objDataProc.GetDataTable(_sb.ToString)
			If _dt.Rows.Count = 0 Then
				_retVal = True
			Else
				_retVal = False
			End If
			Return _retVal
		End Function

#End Region

#Region "WORKER METHODS"

		Public Function GenerateSNs(ByVal sku As String, ByVal start_sn As String, ByVal end_sn As String, ByVal comments As String) As Boolean
			' GENERATES SERIAL NUMBER FROM THE STARTING NUMBER TO THE ENDING NUMBER.
			' ALSO CREATES THE RECORDS IN THE DATABASE TO RECEIVE THE ITEMS.
			Dim _snPrefix As String
			Dim _snStart As Integer
			Dim _snEnd As Integer
			Dim _count As Integer
			Dim _snSuffix As String
			Dim _wr_id As Integer
			Dim _device_id As Integer
			Dim _wh_item_id As Integer
			Dim _wo_id As Integer
			Dim _sku_id As Integer
			Dim _sku As String
			Dim _simTypeId As Integer = 0
			Dim _wr_name As String
			Dim _i As Integer = 0
			Dim _iStr As String = ""
			Try
				' GET THE SKU INFORMATION.
				Dim _tCustSku As New BOL.tcust_sku(sku)
				Dim _newSerial As String = ""
				_sku_id = _tCustSku.sku_id
				_simTypeId = _tCustSku.sku_type_decode_id
				_sku = _tCustSku.sku
				_wr_name = _sku & "_" & Date.Now.ToString("yyyyMMddHHmmss").ToString()
				' GET THE SERIAL NUMBER OBJECTS.
				Select Case _simTypeId
					Case _cdma_id					  ' CDMA SIMS
						Dim _startCdma As New BOL.CDMASim(start_sn)
						Dim _endCdma As New BOL.CDMASim(end_sn)
						_count = _endCdma.Incremental - _startCdma.Incremental + 1
						_snStart = _startCdma.Incremental
						_snEnd = _endCdma.Incremental
						_wo_id = CreateWorkOrder(_sku_id, _wr_name, _count, comments)
						_wr_id = CreateWarehouseReceipt(sku, _wo_id, _wr_name, _count)
						' GENERATION OF SERIAL NUMBERS.
						Dim _curCdma As BOL.CDMASim
						_i = _snStart
						For _i = _snStart To _snEnd
							_iStr = Data.BaseClasses.StringFunctions.PadZeros(5, _i.ToString())
							Dim _snCkSum As String = "0"							' place holder
							_curCdma = New BOL.CDMASim(_startCdma.Prefix & _iStr & _snCkSum)
							_newSerial = _curCdma.SerialNumber_Calculated
							_device_id = CreateDevice(_wr_id, _newSerial)
							_wh_item_id = CreateWHItem(_wr_id, _sku_id, _newSerial, _device_id)
							_curCdma = Nothing
						Next
						_startCdma = Nothing
						_endCdma = Nothing
					Case _gsm_id					  ' GSM SIMS
						Dim _startGsm As New BOL.GSMSim(start_sn)
						Dim _endGsm As New BOL.GSMSim(end_sn)
						_count = _endGsm.Incremental - _startGsm.Incremental + 1
						_snStart = _startGsm.Incremental
						_snEnd = _endGsm.Incremental

						_wo_id = CreateWorkOrder(_sku_id, _wr_name, _count, comments)
						_wr_id = CreateWarehouseReceipt(sku, _wo_id, _wr_name, _count)
						' GENERATION OF SERIAL NUMBERS.
						Dim _curGsm As BOL.GSMSim
						_i = _snStart
						For _i = _snStart To _snEnd
							_iStr = Data.BaseClasses.StringFunctions.PadZeros(5, _i.ToString())
							Dim _snCkSum As String = "0"							' place holder
							_curGsm = New BOL.GSMSim(_startGsm.Prefix & _iStr & _snCkSum & _startGsm.Suffix)
							_newSerial = _curGsm.SerialNumber_Calculated
							_device_id = CreateDevice(_wr_id, _newSerial)
							_wh_item_id = CreateWHItem(_wr_id, _sku_id, _newSerial, _device_id)
							_curGsm = Nothing
						Next
						_startGsm = Nothing
						_endGsm = Nothing
					Case Else
						Throw New Exception("Invalid SKU Type")
				End Select
				Return True
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Private Function CreateWarehouseReceipt(ByVal sku As String, ByVal wo_id As Integer, ByVal wr_name As String, ByVal sn_count As Integer) As Integer
			' CREATES A WAREHOUSE_RECEIPT RECORD.
			Dim _retVal As Integer = 0
			Dim _wr As New BOL.warehouse_receipt(_user_id)
			_wr.WR_Name = wr_name
			_wr.Receipt_Date = Date.Now.Date()
			_wr.Receipt_QTY = sn_count
			_wr.Cust_ID = _cust_id
			_wr.Loc_ID = _loc_id
			_wr.WO_ID = wo_id
			_wr.Closed = True
			_wr.ApplyChanges()
			_retVal = _wr.WR_ID
			_wr = Nothing
			Return _retVal
		End Function

		Private Function CreateWorkOrder(ByVal sku_id As Integer, ByVal cust_wo As String, ByVal qty As Integer, ByVal comments As String) As Integer
			' CREATES A WORKORDER RECORD.
			Dim _retVal As Integer = 0
			Dim _tworkorder As New BOL.tworkorder()
			_tworkorder.WO_Date = Date.Now.Date()
			_tworkorder.WO_CustWO = cust_wo
			_tworkorder.WO_Quantity = qty
			_tworkorder.Loc_ID = _loc_id
			_tworkorder.Prod_ID = _prod_id
			_tworkorder.Sku_ID = sku_id
			_tworkorder.WO_Memo = comments
			_tworkorder.WO_Closed = True
			_tworkorder.EndUser = _user_id
			_tworkorder.ApplyChanges()
			_retVal = _tworkorder.WO_ID
			_tworkorder = Nothing
			Return _retVal
		End Function

		Private Function CreateDevice(ByVal wr_id As Integer, ByVal sn As String) As Integer
			' CREATES A TDEVICE RECORD.
			Dim _id As Integer = 0
			Dim _tdevice As New BOL.tDevice()
			_tdevice.Device_SN = sn
			_tdevice.Device_DateRec = Date.Now
			_tdevice.Device_Qty = 1
			_tdevice.Device_Cnt = 1
			_tdevice.Device_RecWorkDate = Date.Now.Date()
			_tdevice.Loc_ID = _loc_id
			_tdevice.ApplyChanges()
			_id = _tdevice.Device_ID
			_tdevice = Nothing
			Return _id
		End Function

		Private Function CreateWHItem(ByVal wr_id As Integer, ByVal sku_id As Integer, ByVal sn As String, ByVal device_id As Integer) As Integer
			' CREATES A WAREHOUSE_ITEM RECORD.
			Dim _id As Integer = 0
			Dim _wh_item As New BOL.warehouse_items()
			_wh_item.Device_ID = device_id
			_wh_item.Serial = sn
			_wh_item.Date_Received = Date.Now.Date
			_wh_item.WR_ID = wr_id
			_wh_item.sku_id = sku_id
			_wh_item.ApplyChanges()
			_id = _wh_item.WI_ID
			_wh_item = Nothing
			Return _id
		End Function

		Public Function GetCheckSumValue(ByVal dataString As String) As Integer
			' GETS THE VALID CHECKSUM FOR A SERIAL NUMBER STRING.
			Dim sum As Integer = 0
			Dim odd As Boolean = True
			Dim i As Integer = 0
			For i = dataString.Length - 1 To 0 Step -1
				If odd = True Then
					Dim tSum As Integer = Convert.ToInt32(dataString.Chars(i).ToString()) * 2
					If tSum >= 10 Then
						Dim tData As String = tSum.ToString()
						tSum = Convert.ToInt32(tData.Chars(0).ToString()) + Convert.ToInt32(tData.Chars(1).ToString())
					End If
					sum += tSum
				Else
					sum += Convert.ToInt32(dataString.Chars(i).ToString())
				End If
				odd = Not odd
			Next i
			Dim _result As Integer = (((sum \ 10) + 1) * 10) - sum
			Return (IIf(_result = 10, 0, _result))
		End Function

		'Public Function PadZeros(ByVal length As Integer, ByVal value As Integer) As String
		'	' PADS NUMBERS WITH ZEROS.
		'	Dim _fmt As String = ""
		'	Dim _retVal As String = ""
		'	Dim i As Integer = 0
		'	For i = 1 To length
		'		_fmt = Concat(_fmt, "0")
		'	Next
		'	_retVal = value.ToString(_fmt)
		'	Return _retVal
		'End Function

#End Region

#Region "OTHER METHODS"

		Protected Overrides Sub Finalize()
			MyBase.Finalize()
		End Sub

#End Region

	End Class

End Namespace
