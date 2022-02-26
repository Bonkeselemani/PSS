Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic
Namespace BOL
	Public Class tDevice
#Region "DECLARATIONS"

		Private _device_id As Integer = 0
		Private _device_sn As String = ""
		Private _device_oldsn As String = ""
		Private _device_daterec As String = ""
		Private _device_datebill As String = ""
		Private _device_datebill_autobilled As String = ""
		Private _device_datebill_autobilled_temp As String = ""
		Private _device_dateship As String = ""
		Private _device_invoice As Byte = 0
		Private _device_manufwrty As Byte = 0
		Private _device_chgmanufwrty As Byte = 0
		Private _device_psswrty As Byte = 0
		Private _device_sendclaim As Byte = 0
		Private _device_reject As Byte = 0
		Private _device_laborlevel As Integer = 0
		Private _device_laborcharge As Decimal = 0
		Private _device_partcharge As Decimal = 0
		Private _device_laborlevel_autobilled As Integer = 0
		Private _device_laborcharge_autobilled As Double = 0
		Private _device_partcharge_autobilled As Decimal = 0
		Private _autobillflag As Short = 0
		Private _device_manufwrtylaborcharge As Decimal = 0
		Private _device_manufwrtypartcharge As Decimal = 0
		Private _device_qty As Short = 0
		Private _device_cnt As Integer = 0
		Private _device_finishedgoods As Byte = 0
		Private _device_recworkdate As String = ""
		Private _device_shipworkdate As String = ""
		Private _tray_id As Integer = 0
		Private _loc_id As Integer = 0
		Private _wo_id As Integer = 0
		Private _wo_id_out As Integer = 0
		Private _ship_id As Integer = 0
		Private _model_id As Integer = 0
		Private _webinfo_id As Integer = 0
		Private _sku_id As Integer = 0
		Private _pallett_id As Integer = 0
		Private _shift_id_rec As Integer = 0
		Private _shift_id_ship As Integer = 0
		Private _cc_id As Integer = 0
		Private _cc_entrydate As String = ""
		Private _repeatrepcnt As Integer = 0
		Private _lastrecdate As String = ""
		Private _lastdockshipdate As String = ""
		Private _isNew As System.Boolean = True
		Private _isDirty As System.Boolean = False
		Private _isDeleted As System.Boolean = False
		Private _isValid As System.Boolean = False
		Private _objDataProc As DBQuery.DataProc
#End Region
#Region "CONSTRUCTORS"

		Public Sub New()
			_isNew = True
		End Sub

		Public Sub New(ByVal id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(id)
			_isDirty = False
			_isNew = False
		End Sub

		Public Sub New(ByVal device_sn As String, ByVal loc_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(device_sn, loc_id)
			_isDirty = False
			_isNew = False
		End Sub


		Public Sub New(ByVal device_sn As String, ByVal include_shipped As Boolean)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(device_sn, include_shipped)
			_isDirty = False
			_isNew = False
		End Sub






		Protected Overrides Sub Finalize()		'
			Try
				_objDataProc = Nothing
			Finally
				MyBase.Finalize()
				GC.Collect()
				GC.WaitForPendingFinalizers()
				GC.Collect()
				GC.WaitForPendingFinalizers()
			End Try
		End Sub

#End Region
#Region "PROPERTIES"

		Public Property Device_ID() As Integer
			Get
				Return _device_id
			End Get
			Set(ByVal Value As Integer)
				_device_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property Device_SN() As String
			Get
				Return _device_sn
			End Get
			Set(ByVal Value As String)
				_device_sn = Value
				_isDirty = True
			End Set
		End Property
		Public Property Device_OldSN() As String
			Get
				Return _device_oldsn
			End Get
			Set(ByVal Value As String)
				_device_oldsn = Value
				_isDirty = True
			End Set
		End Property
		Public Property Device_DateRec() As String
			Get
				Return _device_daterec
			End Get
			Set(ByVal Value As String)
				_device_daterec = Value
				_isDirty = True
			End Set
		End Property
		Public Property Device_DateBill() As String
			Get
				Return _device_datebill
			End Get
			Set(ByVal Value As String)
				_device_datebill = Value
				_isDirty = True
			End Set
		End Property
		Public Property Device_DateBill_AutoBilled() As String
			Get
				Return _device_datebill_autobilled
			End Get
			Set(ByVal Value As String)
				_device_datebill_autobilled = Value
				_isDirty = True
			End Set
		End Property
		Public Property Device_DateBill_AutoBilled_temp() As String
			Get
				Return _device_datebill_autobilled_temp
			End Get
			Set(ByVal Value As String)
				_device_datebill_autobilled_temp = Value
				_isDirty = True
			End Set
		End Property
		Public Property Device_DateShip() As String
			Get
				Return _device_dateship
			End Get
			Set(ByVal Value As String)
				_device_dateship = Value
				_isDirty = True
			End Set
		End Property
		Public Property Device_Invoice() As Byte
			Get
				Return _device_invoice
			End Get
			Set(ByVal Value As Byte)
				_device_invoice = Value
				_isDirty = True
			End Set
		End Property
		Public Property Device_ManufWrty() As Byte
			Get
				Return _device_manufwrty
			End Get
			Set(ByVal Value As Byte)
				_device_manufwrty = Value
				_isDirty = True
			End Set
		End Property
		Public Property Device_ChgManufWrty() As Byte
			Get
				Return _device_chgmanufwrty
			End Get
			Set(ByVal Value As Byte)
				_device_chgmanufwrty = Value
				_isDirty = True
			End Set
		End Property
		Public Property Device_PSSWrty() As Byte
			Get
				Return _device_psswrty
			End Get
			Set(ByVal Value As Byte)
				_device_psswrty = Value
				_isDirty = True
			End Set
		End Property
		Public Property Device_SendClaim() As Byte
			Get
				Return _device_sendclaim
			End Get
			Set(ByVal Value As Byte)
				_device_sendclaim = Value
				_isDirty = True
			End Set
		End Property
		Public Property Device_Reject() As Byte
			Get
				Return _device_reject
			End Get
			Set(ByVal Value As Byte)
				_device_reject = Value
				_isDirty = True
			End Set
		End Property
		Public Property Device_LaborLevel() As Integer
			Get
				Return _device_laborlevel
			End Get
			Set(ByVal Value As Integer)
				_device_laborlevel = Value
				_isDirty = True
			End Set
		End Property
		Public Property Device_LaborCharge() As Double
			Get
				Return _device_laborcharge
			End Get
			Set(ByVal Value As Double)
				_device_laborcharge = Value
				_isDirty = True
			End Set
		End Property
		Public Property Device_PartCharge() As Double
			Get
				Return _device_partcharge
			End Get
			Set(ByVal Value As Double)
				_device_partcharge = Value
				_isDirty = True
			End Set
		End Property
		Public Property Device_LaborLevel_AutoBilled() As Integer
			Get
				Return _device_laborlevel_autobilled
			End Get
			Set(ByVal Value As Integer)
				_device_laborlevel_autobilled = Value
				_isDirty = True
			End Set
		End Property
		Public Property Device_LaborCharge_AutoBilled() As Double
			Get
				Return _device_laborcharge_autobilled
			End Get
			Set(ByVal Value As Double)
				_device_laborcharge_autobilled = Value
				_isDirty = True
			End Set
		End Property
		Public Property Device_PartCharge_AutoBilled() As Double
			Get
				Return _device_partcharge_autobilled
			End Get
			Set(ByVal Value As Double)
				_device_partcharge_autobilled = Value
				_isDirty = True
			End Set
		End Property
		Public Property AutoBillFlag() As Short
			Get
				Return _autobillflag
			End Get
			Set(ByVal Value As Short)
				_autobillflag = Value
				_isDirty = True
			End Set
		End Property
		Public Property Device_ManufWrtyLaborCharge() As Double
			Get
				Return _device_manufwrtylaborcharge
			End Get
			Set(ByVal Value As Double)
				_device_manufwrtylaborcharge = Value
				_isDirty = True
			End Set
		End Property
		Public Property Device_ManufWrtyPartCharge() As Double
			Get
				Return _device_manufwrtypartcharge
			End Get
			Set(ByVal Value As Double)
				_device_manufwrtypartcharge = Value
				_isDirty = True
			End Set
		End Property
		Public Property Device_Qty() As Short
			Get
				Return _device_qty
			End Get
			Set(ByVal Value As Short)
				_device_qty = Value
				_isDirty = True
			End Set
		End Property
		Public Property Device_Cnt() As Integer
			Get
				Return _device_cnt
			End Get
			Set(ByVal Value As Integer)
				_device_cnt = Value
				_isDirty = True
			End Set
		End Property
		Public Property Device_FinishedGoods() As Byte
			Get
				Return _device_finishedgoods
			End Get
			Set(ByVal Value As Byte)
				_device_finishedgoods = Value
				_isDirty = True
			End Set
		End Property
		Public Property Device_RecWorkDate() As String
			Get
				Return _device_recworkdate
			End Get
			Set(ByVal Value As String)
				_device_recworkdate = Value
				_isDirty = True
			End Set
		End Property
		Public Property Device_ShipWorkDate() As String
			Get
				Return _device_shipworkdate
			End Get
			Set(ByVal Value As String)
				_device_shipworkdate = Value
				_isDirty = True
			End Set
		End Property
		Public Property Tray_ID() As Integer
			Get
				Return _tray_id
			End Get
			Set(ByVal Value As Integer)
				_tray_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property Loc_ID() As Integer
			Get
				Return _loc_id
			End Get
			Set(ByVal Value As Integer)
				_loc_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property WO_ID() As Integer
			Get
				Return _wo_id
			End Get
			Set(ByVal Value As Integer)
				_wo_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property WO_ID_Out() As Integer
			Get
				Return _wo_id_out
			End Get
			Set(ByVal Value As Integer)
				_wo_id_out = Value
				_isDirty = True
			End Set
		End Property
		Public Property Ship_ID() As Integer
			Get
				Return _ship_id
			End Get
			Set(ByVal Value As Integer)
				_ship_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property Model_ID() As Integer
			Get
				Return _model_id
			End Get
			Set(ByVal Value As Integer)
				_model_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property WebInfo_ID() As Integer
			Get
				Return _webinfo_id
			End Get
			Set(ByVal Value As Integer)
				_webinfo_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property Sku_ID() As Integer
			Get
				Return _sku_id
			End Get
			Set(ByVal Value As Integer)
				_sku_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property Pallett_ID() As Integer
			Get
				Return _pallett_id
			End Get
			Set(ByVal Value As Integer)
				_pallett_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property Shift_ID_Rec() As Integer
			Get
				Return _shift_id_rec
			End Get
			Set(ByVal Value As Integer)
				_shift_id_rec = Value
				_isDirty = True
			End Set
		End Property
		Public Property Shift_ID_Ship() As Integer
			Get
				Return _shift_id_ship
			End Get
			Set(ByVal Value As Integer)
				_shift_id_ship = Value
				_isDirty = True
			End Set
		End Property
		Public Property cc_id() As Integer
			Get
				Return _cc_id
			End Get
			Set(ByVal Value As Integer)
				_cc_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property CC_EntryDate() As String
			Get
				Return _cc_entrydate
			End Get
			Set(ByVal Value As String)
				_cc_entrydate = Value
				_isDirty = True
			End Set
		End Property
		Public Property RepeatRepCnt() As Integer
			Get
				Return _repeatrepcnt
			End Get
			Set(ByVal Value As Integer)
				_repeatrepcnt = Value
				_isDirty = True
			End Set
		End Property
		Public Property LastRecDate() As String
			Get
				Return _lastrecdate
			End Get
			Set(ByVal Value As String)
				_lastrecdate = Value
				_isDirty = True
			End Set
		End Property
		Public Property LastDockShipDate() As String
			Get
				Return _lastdockshipdate
			End Get
			Set(ByVal Value As String)
				_lastdockshipdate = Value
				_isDirty = True
			End Set
		End Property
		Public ReadOnly Property IsNew() As Boolean
			Get
				Return _isNew
			End Get
		End Property
		Public ReadOnly Property IsDirty() As Boolean
			Get
				Return _isDirty
			End Get
		End Property
		Public ReadOnly Property IsDeleted() As Boolean
			Get
				Return _isDeleted
			End Get
		End Property
		Public ReadOnly Property IsValid() As Boolean
			Get
				Return _isValid
			End Get
		End Property

#End Region
#Region "METHODS"

		Protected Sub GetData(ByVal id As Integer)
			Dim _sql As String = GetSelectStatement(id)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Protected Sub GetData(ByVal device_sn As String, ByVal loc_id As Integer)
			Dim _sql As String = GetSelectStatement(device_sn, loc_id)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Protected Sub GetData(ByVal device_sn As String, ByVal include_shipped As Boolean)
			Dim _sql As String = GetSelectStatement(device_sn, include_shipped)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Public Sub MarkDeleted()
			_isDeleted = True
		End Sub
		Private Sub PopulateObject(ByVal _dr As DataRow)
			_device_id = DirectCast(_dr("device_id"), Integer)
			_device_sn = _dr("device_sn").ToString()
			_device_oldsn = ConvertToSomething(_dr("device_oldsn").ToString(), "")
			_device_daterec = _dr("device_daterec").ToString()
			_device_datebill = _dr("device_datebill").ToString()
			_device_datebill_autobilled = _dr("device_datebill_autobilled").ToString()
			_device_datebill_autobilled_temp = _dr("device_datebill_autobilled_temp").ToString()
			_device_dateship = _dr("device_dateship").ToString()
			_device_invoice = ConvertToSomething(_dr("device_invoice"), 0)
			_device_manufwrty = ConvertToSomething(_dr("device_manufwrty"), 0)
			_device_chgmanufwrty = ConvertToSomething(_dr("device_chgmanufwrty"), 0)
			_device_psswrty = ConvertToSomething(_dr("device_psswrty"), 0)
			_device_sendclaim = ConvertToSomething(_dr("device_sendclaim"), 0)
			_device_reject = ConvertToSomething(_dr("device_reject"), 0)
			_device_laborlevel = DirectCast(ConvertToSomething(_dr("device_laborlevel"), 0), Integer)
			_device_laborcharge = DirectCast(ConvertToSomething(_dr("device_laborcharge"), New Decimal(0)), Decimal)
			_device_partcharge = DirectCast(ConvertToSomething(_dr("device_partcharge"), New Decimal(0)), Decimal)
			_device_laborlevel_autobilled = ConvertToSomething(_dr("device_laborlevel_autobilled"), 0)
			_device_laborcharge_autobilled = ConvertToSomething(_dr("device_laborcharge_autobilled"), 0)
			_device_partcharge_autobilled = DirectCast(ConvertToSomething(_dr("device_partcharge_autobilled"), New Decimal(0)), Decimal)
			_autobillflag = DirectCast(ConvertToSomething(_dr("autobillflag"), 0), Short)
			_device_manufwrtylaborcharge = DirectCast(ConvertToSomething(_dr("device_manufwrtylaborcharge"), New Decimal(0)), Decimal)
			_device_manufwrtypartcharge = DirectCast(ConvertToSomething(_dr("device_manufwrtypartcharge"), New Decimal(0)), Decimal)
			_device_qty = DirectCast(ConvertToSomething(_dr("device_qty"), 0), Short)
			_device_cnt = DirectCast(ConvertToSomething(_dr("device_cnt"), 0), Integer)
			_device_finishedgoods = ConvertToSomething(_dr("device_finishedgoods"), 0)
			_device_recworkdate = _dr("device_recworkdate").ToString()
			_device_shipworkdate = _dr("device_shipworkdate").ToString()
			_tray_id = DirectCast(ConvertToSomething(_dr("tray_id"), 0), Integer)
			_loc_id = DirectCast(ConvertToSomething(_dr("loc_id"), 0), Integer)
			_wo_id = DirectCast(ConvertToSomething(_dr("wo_id"), 0), Integer)
			_wo_id_out = DirectCast(ConvertToSomething(_dr("wo_id_out"), 0), Integer)
			_ship_id = DirectCast(ConvertToSomething(_dr("ship_id"), 0), Integer)
			_model_id = DirectCast(ConvertToSomething(_dr("model_id"), 0), Integer)
			_webinfo_id = DirectCast(ConvertToSomething(_dr("webinfo_id"), 0), Integer)
			_sku_id = DirectCast(ConvertToSomething(_dr("sku_id"), 0), Integer)
			_pallett_id = DirectCast(ConvertToSomething(_dr("pallett_id"), 0), Integer)
			_shift_id_rec = DirectCast(ConvertToSomething(_dr("shift_id_rec"), 0), Integer)
			_shift_id_ship = DirectCast(ConvertToSomething(_dr("shift_id_ship"), 0), Integer)
			_cc_id = DirectCast(ConvertToSomething(_dr("cc_id"), 0), Integer)
			_cc_entrydate = ConvertToSomething(_dr("cc_entrydate").ToString(), "")
			_repeatrepcnt = DirectCast(ConvertToSomething(_dr("repeatrepcnt"), 0), Integer)
			_lastrecdate = _dr("lastrecdate").ToString()
			_lastdockshipdate = _dr("lastdockshipdate").ToString()
		End Sub
		Public Function ApplyChanges() As Integer
			Try
				If _isNew Then
					Insert()
				ElseIf _isDirty Then
					Update()
				ElseIf _isDeleted Then
					Throw New Exception("Delete not implemented.")
				End If
				Return _device_id
			Catch ex As Exception
				Throw ex
			End Try

		End Function
		Protected Function Insert() As Integer
			Dim strSQL, strToday As String
			Try
				Dim objDataProc As DBQuery.DataProc
				Dim _id As Integer
				_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
				strToday = PSS.Data.Buisness.Generic.GetMySqlDateTime("%Y-%m-%d")
				strSQL = "INSERT INTO production.tdevice (" & _
				   "device_sn, " & _
				   "device_oldsn, " & _
				   "device_daterec, " & _
				   "device_datebill, " & _
				   "device_datebill_autobilled, " & _
				   "device_datebill_autobilled_temp, " & _
				   "device_dateship, " & _
				   "device_invoice, " & _
				   "device_manufwrty, " & _
				   "device_chgmanufwrty, " & _
				   "device_psswrty, " & _
				   "device_sendclaim, " & _
				   "device_reject, " & _
				   "device_laborlevel, " & _
				   "device_laborcharge, " & _
				   "device_partcharge, " & _
				   "device_laborlevel_autobilled, " & _
				   "device_laborcharge_autobilled, " & _
				   "device_partcharge_autobilled, " & _
				   "autobillflag, " & _
				   "device_manufwrtylaborcharge, " & _
				   "device_manufwrtypartcharge, " & _
				   "device_qty, " & _
				   "device_cnt, " & _
				   "device_finishedgoods, " & _
				   "device_recworkdate, " & _
				   "device_shipworkdate, " & _
				   "tray_id, " & _
				   "loc_id, " & _
				   "wo_id, " & _
				   "wo_id_out, " & _
				   "ship_id, " & _
				   "model_id, " & _
				   "webinfo_id, " & _
				   "sku_id, " & _
				   "pallett_id, " & _
				   "shift_id_rec, " & _
				   "shift_id_ship, " & _
				   "cc_id, " & _
				   "cc_entrydate, " & _
				   "repeatrepcnt, " & _
				   "lastrecdate, " & _
				   "lastdockshipdate " & _
				  ") " & _
				  "VALUES ( " & _
				   ConvertBackToNullString(_device_sn, True) & " , " & _
				   ConvertBackToNullString(_device_oldsn, True) & " , " & _
				   ConvertToMySQLDateOrNullString(_device_daterec) & " , " & _
				   ConvertToMySQLDateOrNullString(_device_datebill) & " , " & _
				   ConvertBackToNullString(_device_datebill_autobilled, False) & " , " & _
				   ConvertBackToNullString(_device_datebill_autobilled_temp, False) & " , " & _
				   ConvertToMySQLDateOrNullString(_device_dateship) & " , " & _
				   _device_invoice & " , " & _
				   _device_manufwrty & " , " & _
				   _device_chgmanufwrty & " , " & _
				   _device_psswrty & " , " & _
				   _device_sendclaim & " , " & _
				   _device_reject & " , " & _
				   ConvertBackToNullString(_device_laborlevel, False) & " , " & _
				   ConvertBackToNullString(_device_laborcharge, False) & " , " & _
				   _device_partcharge & " , " & _
				   ConvertBackToNullString(_device_laborlevel_autobilled, False) & " , " & _
				   ConvertBackToNullString(_device_laborcharge_autobilled, False) & " , " & _
				   _device_partcharge_autobilled & " , " & _
				   _autobillflag & " , " & _
				   _device_manufwrtylaborcharge & " , " & _
				   _device_manufwrtypartcharge & " , " & _
				   _device_qty & " , " & _
				   _device_cnt & " , " & _
				   _device_finishedgoods & " , " & _
				   ConvertToMySQLDateOrNullString(_device_recworkdate) & " , " & _
				   ConvertToMySQLDateOrNullString(_device_shipworkdate) & " , " & _
				   _tray_id & " , " & _
				   ConvertBackToNullString(_loc_id, False) & " , " & _
				   _wo_id.ToString() & " , " & _
				   ConvertBackToNullString(_wo_id_out, False) & " , " & _
				   ConvertBackToNullString(_ship_id, False) & " , " & _
				   ConvertBackToNullString(_model_id, False) & " , " & _
				   ConvertBackToNullString(_webinfo_id, False) & " , " & _
				   ConvertBackToNullString(_sku_id, False) & " , " & _
				   ConvertBackToNullString(_pallett_id, False) & " , " & _
				   _shift_id_rec & " , " & _
				   _shift_id_ship & " , " & _
				   _cc_id.ToString() & " , " & _
				   ConvertToMySQLDateOrNullString(_cc_entrydate) & " , " & _
				   _repeatrepcnt & " , " & _
				   ConvertToMySQLDateOrNullString(_lastrecdate) & " , " & _
				   ConvertToMySQLDateOrNullString(_lastdockshipdate) & "  " & _
				   ")"
				_id = _objDataProc.ExecuteScalarForInsert(strSQL, "production.tdevice")
				_device_id = _id
				Return _id
			Catch ex As Exception
				If InStr(ex.Message, "Duplicate") > 0 Then
					Throw New Exception("Duplicate exists.")
				Else
					Throw ex
				End If
			End Try
		End Function
		Private Function Update()
			Dim strToday As String
			Dim _sb As New StringBuilder()
			Dim _objDataProc As New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			Dim _id As Integer = _device_id
			Try
				_sb.Append("UPDATE production.tdevice SET ")
				_sb.Append("device_sn = '" & _device_sn.ToString() & "', ")
				_sb.Append("device_oldsn = " & ConvertBackToNullString(_device_oldsn.ToString(), True) & ", ")
				_sb.Append("device_daterec = " & ConvertToMySQLDateOrNullString(_device_daterec) & ", ")
				_sb.Append("device_datebill = " & ConvertToMySQLDateOrNullString(_device_datebill) & ", ")
				_sb.Append("device_datebill_autobilled = " & ConvertToMySQLDateOrNullString(_device_datebill_autobilled) & ", ")
				_sb.Append("device_datebill_autobilled_temp = " & ConvertToMySQLDateOrNullString(_device_datebill_autobilled_temp) & ", ")
				_sb.Append("device_dateship = " & ConvertToMySQLDateOrNullString(_device_dateship) & ", ")
				_sb.Append("device_invoice = " & _device_invoice.ToString() & ", ")
				_sb.Append("device_manufwrty = " & _device_manufwrty.ToString() & ", ")
				_sb.Append("device_chgmanufwrty = " & _device_chgmanufwrty.ToString() & ", ")
				_sb.Append("device_psswrty = " & _device_psswrty.ToString() & ", ")
				_sb.Append("device_sendclaim = " & _device_sendclaim.ToString() & ", ")
				_sb.Append("device_reject = " & _device_reject.ToString() & ", ")
				_sb.Append("device_laborlevel = " & _device_laborlevel.ToString() & ", ")
				_sb.Append("device_laborcharge = " & ConvertBackToNullString(_device_laborcharge.ToString(), False) & ", ")
				_sb.Append("device_partcharge = " & ConvertToSomething(_device_partcharge.ToString(), 0.0).ToString() & ", ")
				_sb.Append("device_laborlevel_autobilled = " & ConvertBackToNullString(_device_laborlevel_autobilled.ToString(), False) & ", ")
				_sb.Append("device_laborcharge_autobilled = " & ConvertBackToNullString(_device_laborcharge_autobilled.ToString(), False) & ", ")
				_sb.Append("device_partcharge_autobilled = " & ConvertBackToNullString(_device_partcharge_autobilled.ToString(), False) & ", ")
				_sb.Append("autobillflag = " & _autobillflag.ToString() & ", ")
				_sb.Append("device_manufwrtylaborcharge = " & ConvertToSomething(_device_manufwrtylaborcharge.ToString(), 0.0).ToString() & ", ")
				_sb.Append("device_manufwrtypartcharge = " & ConvertToSomething(_device_manufwrtypartcharge.ToString(), 0.0).ToString() & ", ")
				_sb.Append("device_qty = " & ConvertBackToNullString(_device_qty.ToString(), False) & ", ")
				_sb.Append("device_cnt = " & ConvertBackToNullString(_device_cnt.ToString(), False) & ", ")
				_sb.Append("device_finishedgoods = " & _device_finishedgoods.ToString() & ", ")
				_sb.Append("device_recworkdate = " & ConvertToMySQLDateOrNullString(_device_recworkdate) & ", ")
				_sb.Append("device_shipworkdate = " & ConvertToMySQLDateOrNullString(_device_shipworkdate) & ", ")
				_sb.Append("tray_id = " & ConvertBackToNullString(_tray_id.ToString(), False) & ", ")
				_sb.Append("loc_id = " & ConvertBackToNullString(_loc_id.ToString(), False) & ", ")
				_sb.Append("wo_id = " & ConvertBackToNullString(_wo_id.ToString(), False) & ", ")
				_sb.Append("wo_id_out = " & ConvertBackToNullString(_wo_id_out.ToString(), False) & ", ")
				_sb.Append("ship_id = " & ConvertBackToNullString(_ship_id.ToString(), False) & ", ")
				_sb.Append("model_id = " & ConvertBackToNullString(_model_id.ToString(), False) & ", ")
				_sb.Append("webinfo_id = " & ConvertBackToNullString(_webinfo_id.ToString(), False) & ", ")
				_sb.Append("sku_id = " & ConvertBackToNullString(_sku_id.ToString(), False) & ", ")
				_sb.Append("pallett_id = " & ConvertBackToNullString(_pallett_id.ToString(), False) & ", ")
				_sb.Append("shift_id_rec = " & _shift_id_rec.ToString() & ", ")
				_sb.Append("shift_id_ship = " & _shift_id_ship.ToString() & ", ")
				_sb.Append("cc_id = " & ConvertBackToNullString(_cc_id.ToString(), False) & ", ")
				_sb.Append("cc_entrydate = " & ConvertToMySQLDateOrNullString(_cc_entrydate) & ", ")
				_sb.Append("repeatrepcnt = " & _repeatrepcnt.ToString() & ", ")
				_sb.Append("lastrecdate = " & ConvertToMySQLDateOrNullString(_lastrecdate) & ", ")
				_sb.Append("lastdockshipdate = " & ConvertToMySQLDateOrNullString(_lastdockshipdate) & " ")
				_sb.Append("WHERE device_id = " & _device_id.ToString() & " LIMIT 1; ")
				_objDataProc.ExecuteNonQuery(_sb.ToString())
			Catch ex As Exception
				Throw ex
			Finally
				_objDataProc = Nothing
				_sb = Nothing
			End Try
		End Function
		Public Sub Delete()
			Dim sql As String = GetDeleteStatement()
			Try
				_objDataProc.ExecuteNonQuery(sql)
			Catch ex As Exception
				Throw ex
			End Try
		End Sub
		Protected Function GetSelectStatement(ByVal ID As Integer) As String
			Dim _sb As New StringBuilder()
			_sb.Append("SELECT ")
			_sb.Append("Device_ID, ")
			_sb.Append("Device_SN, ")
			_sb.Append("Device_OldSN, ")
			_sb.Append("Device_DateRec, ")
			_sb.Append("Device_DateBill, ")
			_sb.Append("Device_DateBill_AutoBilled, ")
			_sb.Append("Device_DateBill_AutoBilled_temp, ")
			_sb.Append("Device_DateShip, ")
			_sb.Append("Device_Invoice, ")
			_sb.Append("Device_ManufWrty, ")
			_sb.Append("Device_ChgManufWrty, ")
			_sb.Append("Device_PSSWrty, ")
			_sb.Append("Device_SendClaim, ")
			_sb.Append("Device_Reject, ")
			_sb.Append("Device_LaborLevel, ")
			_sb.Append("Device_LaborCharge, ")
			_sb.Append("Device_PartCharge, ")
			_sb.Append("Device_LaborLevel_AutoBilled, ")
			_sb.Append("Device_LaborCharge_AutoBilled, ")
			_sb.Append("Device_PartCharge_AutoBilled, ")
			_sb.Append("AutoBillFlag, ")
			_sb.Append("Device_ManufWrtyLaborCharge, ")
			_sb.Append("Device_ManufWrtyPartCharge, ")
			_sb.Append("Device_Qty, ")
			_sb.Append("Device_Cnt, ")
			_sb.Append("Device_FinishedGoods, ")
			_sb.Append("Device_RecWorkDate, ")
			_sb.Append("Device_ShipWorkDate, ")
			_sb.Append("Tray_ID, ")
			_sb.Append("Loc_ID, ")
			_sb.Append("WO_ID, ")
			_sb.Append("WO_ID_Out, ")
			_sb.Append("Ship_ID, ")
			_sb.Append("Model_ID, ")
			_sb.Append("WebInfo_ID, ")
			_sb.Append("Sku_ID, ")
			_sb.Append("Pallett_ID, ")
			_sb.Append("Shift_ID_Rec, ")
			_sb.Append("Shift_ID_Ship, ")
			_sb.Append("cc_id, ")
			_sb.Append("CC_EntryDate, ")
			_sb.Append("RepeatRepCnt, ")
			_sb.Append("LastRecDate, ")
			_sb.Append("LastDockShipDate ")
			_sb.Append("FROM ")
			_sb.Append("production.tdevice ")
			_sb.Append("WHERE ")
			_sb.Append("device_id = ")
			_sb.Append(ID.ToString() & " ")
			Return _sb.ToString()
		End Function
		Protected Function GetSelectStatement(ByVal device_sn As String, ByVal loc_id As Integer) As String
			Dim _sb As New StringBuilder()
			_sb.Append("SELECT ")
			_sb.Append("Device_ID, ")
			_sb.Append("Device_SN, ")
			_sb.Append("Device_OldSN, ")
			_sb.Append("Device_DateRec, ")
			_sb.Append("Device_DateBill, ")
			_sb.Append("Device_DateBill_AutoBilled, ")
			_sb.Append("Device_DateBill_AutoBilled_temp, ")
			_sb.Append("Device_DateShip, ")
			_sb.Append("Device_Invoice, ")
			_sb.Append("Device_ManufWrty, ")
			_sb.Append("Device_ChgManufWrty, ")
			_sb.Append("Device_PSSWrty, ")
			_sb.Append("Device_SendClaim, ")
			_sb.Append("Device_Reject, ")
			_sb.Append("Device_LaborLevel, ")
			_sb.Append("Device_LaborCharge, ")
			_sb.Append("Device_PartCharge, ")
			_sb.Append("Device_LaborLevel_AutoBilled, ")
			_sb.Append("Device_LaborCharge_AutoBilled, ")
			_sb.Append("Device_PartCharge_AutoBilled, ")
			_sb.Append("AutoBillFlag, ")
			_sb.Append("Device_ManufWrtyLaborCharge, ")
			_sb.Append("Device_ManufWrtyPartCharge, ")
			_sb.Append("Device_Qty, ")
			_sb.Append("Device_Cnt, ")
			_sb.Append("Device_FinishedGoods, ")
			_sb.Append("Device_RecWorkDate, ")
			_sb.Append("Device_ShipWorkDate, ")
			_sb.Append("Tray_ID, ")
			_sb.Append("Loc_ID, ")
			_sb.Append("WO_ID, ")
			_sb.Append("WO_ID_Out, ")
			_sb.Append("Ship_ID, ")
			_sb.Append("Model_ID, ")
			_sb.Append("WebInfo_ID, ")
			_sb.Append("Sku_ID, ")
			_sb.Append("Pallett_ID, ")
			_sb.Append("Shift_ID_Rec, ")
			_sb.Append("Shift_ID_Ship, ")
			_sb.Append("cc_id, ")
			_sb.Append("CC_EntryDate, ")
			_sb.Append("RepeatRepCnt, ")
			_sb.Append("LastRecDate, ")
			_sb.Append("LastDockShipDate ")
			_sb.Append("FROM ")
			_sb.Append("production.tdevice ")
			_sb.Append("WHERE ")
			_sb.Append("device_sn = '" & device_sn & "' ")
			_sb.Append(" AND loc_id = " & loc_id.ToString() & " ")
			_sb.Append("; ")
			Return _sb.ToString()
		End Function
		Protected Function GetSelectStatement(ByVal device_sn As String, ByVal include_shipped As Boolean) As String
			Dim _sb As New StringBuilder()
			_sb.Append("SELECT ")
			_sb.Append("Device_ID, ")
			_sb.Append("Device_SN, ")
			_sb.Append("Device_OldSN, ")
			_sb.Append("Device_DateRec, ")
			_sb.Append("Device_DateBill, ")
			_sb.Append("Device_DateBill_AutoBilled, ")
			_sb.Append("Device_DateBill_AutoBilled_temp, ")
			_sb.Append("Device_DateShip, ")
			_sb.Append("Device_Invoice, ")
			_sb.Append("Device_ManufWrty, ")
			_sb.Append("Device_ChgManufWrty, ")
			_sb.Append("Device_PSSWrty, ")
			_sb.Append("Device_SendClaim, ")
			_sb.Append("Device_Reject, ")
			_sb.Append("Device_LaborLevel, ")
			_sb.Append("Device_LaborCharge, ")
			_sb.Append("Device_PartCharge, ")
			_sb.Append("Device_LaborLevel_AutoBilled, ")
			_sb.Append("Device_LaborCharge_AutoBilled, ")
			_sb.Append("Device_PartCharge_AutoBilled, ")
			_sb.Append("AutoBillFlag, ")
			_sb.Append("Device_ManufWrtyLaborCharge, ")
			_sb.Append("Device_ManufWrtyPartCharge, ")
			_sb.Append("Device_Qty, ")
			_sb.Append("Device_Cnt, ")
			_sb.Append("Device_FinishedGoods, ")
			_sb.Append("Device_RecWorkDate, ")
			_sb.Append("Device_ShipWorkDate, ")
			_sb.Append("Tray_ID, ")
			_sb.Append("Loc_ID, ")
			_sb.Append("WO_ID, ")
			_sb.Append("WO_ID_Out, ")
			_sb.Append("Ship_ID, ")
			_sb.Append("Model_ID, ")
			_sb.Append("WebInfo_ID, ")
			_sb.Append("Sku_ID, ")
			_sb.Append("Pallett_ID, ")
			_sb.Append("Shift_ID_Rec, ")
			_sb.Append("Shift_ID_Ship, ")
			_sb.Append("cc_id, ")
			_sb.Append("CC_EntryDate, ")
			_sb.Append("RepeatRepCnt, ")
			_sb.Append("LastRecDate, ")
			_sb.Append("LastDockShipDate ")
			_sb.Append("FROM ")
			_sb.Append("production.tdevice ")
			_sb.Append("WHERE ")
			_sb.Append("device_sn = '" & device_sn & "' ")
			If Not include_shipped Then
				_sb.Append(" AND Device_DateShip IS NULL ")
			End If
			_sb.Append("; ")
			Return _sb.ToString()
		End Function
		Protected Function GetDeleteStatement() As String
			Dim _sql As String
			_sql = "DELETE FROM production.tdevice "
			_sql += "WHERE device_id = " & _device_id.ToString() & " LIMIT 1;"
			Return _sql
		End Function
		Public Sub SetNewCostCenter(ByVal device_id As Integer, ByVal cc_id As Integer)
			' THIS WILL SET VALUES FOR A NEW COST CENTER VALUES.
			_cc_id = cc_id
			_cc_entrydate = Format(Date.Now(), "MM/dd/yyyy HH:mm:ss")
		End Sub

#End Region
	End Class
	Public Class tDevice_ByWS_Readonly
#Region "DECLARATIONS"

		Private _device_id As Integer = 0
		Private _device_sn As String = ""
		Private _device_daterec As String = ""
		Private _device_datebill As String = ""
		Private _device_dateship As String = ""
		Private _device_invoice As Byte = 0
		Private _device_finishedgoods As Byte = 0
		Private _device_shipworkdate As String = ""
		Private _model_desc As String = ""
		Private _cust_name1 As String = ""
		Private _wipowner_desc As String = ""
		Private _wo_custwo As String = ""
		Private _boxid As String = ""
		Private _whb_id As Integer = 0
		Private _box_na As String = ""
		Private _objDataProc As DBQuery.DataProc

#End Region
#Region "CONSTRUCTORS"

		Public Sub New(ByVal cust_id As Integer, ByVal device_sn As String, ByVal Workstation As String)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(cust_id, device_sn, Workstation)
		End Sub

#End Region
#Region "PROPERTIES"

		Public ReadOnly Property Device_ID() As Integer
			Get
				Return _device_id
			End Get
		End Property
		Public ReadOnly Property Device_SN() As String
			Get
				Return _device_sn
			End Get
		End Property
		Public ReadOnly Property Device_DateRec() As String
			Get
				Return _device_daterec
			End Get
		End Property
		Public ReadOnly Property Device_DateBill() As String
			Get
				Return _device_datebill
			End Get
		End Property
		Public ReadOnly Property Device_DateShip() As String
			Get
				Return _device_dateship
			End Get
		End Property
		Public ReadOnly Property Device_Invoice() As Byte
			Get
				Return _device_invoice
			End Get
		End Property
		Public ReadOnly Property Device_FinishedGoods() As Byte
			Get
				Return _device_finishedgoods
			End Get
		End Property
		Public ReadOnly Property Device_ShipWorkDate() As String
			Get
				Return _device_shipworkdate
			End Get
		End Property
		Public ReadOnly Property Model_Desc() As String
			Get
				Return _model_desc
			End Get
		End Property
		Public ReadOnly Property Cust_Name1() As String
			Get
				Return _cust_name1
			End Get
		End Property
		Public ReadOnly Property WipOwner_Desc() As String
			Get
				Return _wipowner_desc
			End Get
		End Property
		Public ReadOnly Property WO_CustWO() As String
			Get
				Return _wo_custwo
			End Get
		End Property
		Public ReadOnly Property BoxID() As String
			Get
				Return _boxid
			End Get
		End Property
		Public ReadOnly Property WHB_ID() As Integer
			Get
				Return _whb_id
			End Get
		End Property
		Public ReadOnly Property Box_na() As String
			Get
				Return _box_na
			End Get
		End Property

#End Region
#Region "METHODS"

		Private Sub GetData(ByVal cust_id As Integer, ByVal device_sn As String, ByVal workstation As String)
			Dim _sql As String = GetSelectStatement(cust_id, device_sn, workstation)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Private Function GetSelectStatement(ByVal cust_id As Integer, ByVal device_sn As String, ByVal workstation As String) As String
			Dim _sb As New StringBuilder()
			_sb.Append("SELECT ")
			_sb.Append("d.device_id, ")
			_sb.Append("d.device_sn, ")
			_sb.Append("d.device_daterec, ")
			_sb.Append("d.device_datebill, ")
			_sb.Append("d.device_dateship, ")
			_sb.Append("d.device_shipworkdate, ")
			_sb.Append("d.device_invoice, ")
			_sb.Append("d.device_finishedgoods, ")
			_sb.Append("m.model_desc, ")
			_sb.Append("cust.cust_name1, ")
			_sb.Append("wip.wipowner_desc, ")
			_sb.Append("wo.wo_custwo, ")
			_sb.Append("itm.boxid, ")
			_sb.Append("itm.whb_id, ")
			_sb.Append("wb.box_na,")
			_sb.Append("co.workstation ")
			_sb.Append("FROM tdevice d ")
			_sb.Append("LEFT JOIN edi.titem itm on d.device_id = itm.device_id ")
			_sb.Append("LEFT JOIN tmessdata md on d.device_id = md.device_id ")
			_sb.Append("LEFT JOIN tmodel m on d.model_id = m.model_id ")
			_sb.Append("LEFT JOIN tworkorder wo on d.wo_id = wo.wo_id ")
			_sb.Append("LEFT JOIN tlocation loc on d.loc_id = loc.loc_id ")
			_sb.Append("LEFT JOIN tcustomer cust on loc.cust_id = cust.cust_id ")
			_sb.Append("LEFT JOIN tpallett p ON d.pallett_id = p.pallett_id ")
			_sb.Append("LEFT JOIN production.tcellopt co on d.device_id = co.device_id ")
			_sb.Append("LEFT JOIN lwipowner wip ON md.WipOwner_ID = wip.WipOwner_ID ")
			_sb.Append("LEFT JOIN warehouse.wh_box wb ON itm.whb_id = wb.whb_id ")
			_sb.Append("WHERE ")
			_sb.Append("cust.cust_id = " & cust_id.ToString & " ")
			_sb.Append("AND ")
			_sb.Append("device_sn = '" & device_sn & "' ")
			_sb.Append("AND ")
			_sb.Append("co.workstation = '" & workstation & "' ")
			_sb.Append("ORDER BY device_daterec DESC; ")
			Return _sb.ToString()
		End Function
		Private Sub PopulateObject(ByVal _dr As DataRow)
			_device_id = DirectCast(_dr("device_id"), Integer)
			_device_sn = _dr("device_sn").ToString()
			_device_daterec = _dr("device_daterec").ToString()
			_device_datebill = _dr("device_datebill").ToString()
			_device_dateship = _dr("device_dateship").ToString()
			_device_invoice = ConvertToSomething(_dr("device_invoice"), 0)
			_device_finishedgoods = ConvertToSomething(_dr("device_finishedgoods"), 0)
			_device_shipworkdate = _dr("device_shipworkdate").ToString()
			_model_desc = ConvertToSomething(_dr("model_desc"), "")
			_cust_name1 = ConvertToSomething(_dr("cust_name1"), "")
			_wipowner_desc = ConvertToSomething(_dr("wipowner_desc"), "")
			_wo_custwo = ConvertToSomething(_dr("wo_custwo"), "")
			_boxid = ConvertToSomething(_dr("boxid"), "")
			_whb_id = ConvertToSomething(_dr("whb_id"), 0)
			_box_na = ConvertToSomething(_dr("box_na"), "")
		End Sub

#End Region
	End Class
	Public Class tDeviceCollectionBySN
#Region "DECLARATIONS"

		Inherits Collections.ArrayList
		Private _objDataProc As DBQuery.DataProc
		Private _dt As New DataTable()
		Private _list As New ArrayList()

#End Region
#Region "CONSTRUCTORS"

		Public Sub New(ByVal device_sn As String)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(device_sn)
		End Sub

		Protected Overrides Sub Finalize()
			Try
				_dt = Nothing
				_objDataProc = Nothing
			Finally
				MyBase.Finalize()
			End Try
		End Sub

#End Region
#Region "PROPERTIES"

		Public ReadOnly Property deviceDataTable() As DataTable
			Get
				Return _dt
			End Get
		End Property

#End Region
#Region "METHODS"

		Protected Sub GetData(ByVal device_sn As String)
			Dim _sql As String = GetSelectStatement(device_sn)
			_dt = _objDataProc.GetDataTable(_sql)
		End Sub

		Protected Function GetSelectStatement(ByVal device_sn As String) As String
			Dim _sb As New StringBuilder()
			_sb.Append("SELECT ")
			_sb.Append("d.device_id, ")
			_sb.Append("d.device_sn, ")
			_sb.Append("m.model_desc as Model, ")
			_sb.Append("d.device_daterec Received, ")
			_sb.Append("d.device_datebill as Billed, ")
			_sb.Append("d.device_dateship, ")
			_sb.Append("d.device_shipworkdate as Produced, ")
			_sb.Append("d.device_invoice as Invoiced, ")
			_sb.Append("d.device_finishedgoods, ")
			_sb.Append("p.pallett_name as Pallet, ")
			_sb.Append("p.pallett_shipdate as Pallet_Closed_Date, ")
			_sb.Append("cust.cust_name1 as Customer, ")
			_sb.Append("wip.wipowner_desc WIP_Owner, ")
			_sb.Append("wo.wo_custwo as Cust_Work_Order ")
			_sb.Append("FROM tdevice d ")
			_sb.Append("LEFT JOIN tmessdata md on d.device_id = md.device_id ")
			_sb.Append("LEFT JOIN tmodel m on d.model_id = m.model_id ")
			_sb.Append("LEFT JOIN tworkorder wo on d.wo_id = wo.wo_id ")
			_sb.Append("LEFT JOIN tlocation loc on d.loc_id = loc.loc_id ")
			_sb.Append("LEFT JOIN tcustomer cust on loc.cust_id = cust.cust_id ")
			_sb.Append("LEFT JOIN tpallett p ON d.pallett_id = p.pallett_id ")
			_sb.Append("LEFT JOIN lwipowner wip ON md.WipOwner_ID = wip.WipOwner_ID ")
			_sb.Append("WHERE device_sn = '" & device_sn & "' ")
			_sb.Append("ORDER BY device_daterec DESC; ")
			Return _sb.ToString()
		End Function

#End Region
	End Class
	Public Class tDeviceCollectionByPallett
#Region "DECLARATIONS"

		Inherits Collections.ArrayList
		Private _objDataProc As DBQuery.DataProc
		Private _dt As New DataTable()
		Private _list As New ArrayList()

#End Region
#Region "CONSTRUCTORS"

		Public Sub New(ByVal pallett_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(pallett_id)
		End Sub

		Protected Overrides Sub Finalize()
			Try
				_dt = Nothing
				_objDataProc = Nothing
			Finally
				MyBase.Finalize()
			End Try
		End Sub

#End Region
#Region "PROPERTIES"

		Public ReadOnly Property deviceDataTable() As DataTable
			Get
				Return _dt
			End Get
		End Property

#End Region
#Region "METHODS"

		Protected Sub GetData(ByVal pallett_id As Integer)
			Dim _sql As String = GetSelectStatement(pallett_id)
			_dt = _objDataProc.GetDataTable(_sql)
		End Sub

		Protected Function GetSelectStatement(ByVal pallett_id As Integer) As String
			Dim _sb As New StringBuilder()
			_sb.Append("SELECT ")
			_sb.Append("d.device_id, ")
			_sb.Append("d.device_sn, ")
			_sb.Append("m.model_desc as Model, ")
			_sb.Append("d.device_daterec Received, ")
			_sb.Append("d.device_datebill as Billed, ")
			_sb.Append("d.device_dateship, ")
			_sb.Append("d.device_shipworkdate as Produced, ")
			_sb.Append("d.device_invoice as Invoiced, ")
			_sb.Append("p.pallett_name as Pallet, ")
			_sb.Append("p.pallett_shipdate as Pallet_Closed_Date, ")
			_sb.Append("cust.cust_name1 as Customer, ")
			_sb.Append("wip.wipowner_desc WIP_Owner, ")
			_sb.Append("wo.wo_custwo as Cust_Work_Order, ")
			_sb.Append("co.workstation ")
			_sb.Append("FROM tpallett p ")
			_sb.Append("INNER JOIN tDevice d ON p.pallett_id = d.pallett_id ")
			_sb.Append("INNER JOIN tcellopt co ON d.device_id = co.device_id ")
			_sb.Append("INNER JOIN tmodel m on d.model_id = m.model_id ")
			_sb.Append("INNER JOIN tlocation loc on d.loc_id = loc.loc_id ")
			_sb.Append("INNER JOIN tcustomer cust on loc.cust_id = cust.cust_id ")
			_sb.Append("LEFT JOIN tmessdata md on d.device_id = md.device_id ")
			_sb.Append("LEFT JOIN tworkorder wo on d.wo_id = wo.wo_id ")
			_sb.Append("LEFT JOIN lwipowner wip ON md.WipOwner_ID = wip.WipOwner_ID ")
			_sb.Append("WHERE d.pallett_id = " & pallett_id.ToString() & " ")
			_sb.Append("ORDER BY device_daterec DESC; ")
			Return _sb.ToString()
		End Function

#End Region
	End Class
	Public Class tDeviceCollectionByWHBox
#Region "DECLARATIONS"

		Inherits Collections.ArrayList
		Private _objDataProc As DBQuery.DataProc
		Private _dt As New DataTable()
		Private _list As New ArrayList()

#End Region
#Region "CONSTRUCTORS"

		Public Sub New(ByVal whb_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(whb_id)
		End Sub

		Public Sub New(ByVal box_na As String)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(box_na)
		End Sub

		Protected Overrides Sub Finalize()
			Try
				_dt = Nothing
				_objDataProc = Nothing
			Finally
				MyBase.Finalize()
			End Try
		End Sub

#End Region
#Region "PROPERTIES"

		Public ReadOnly Property deviceDataTable() As DataTable
			Get
				Return _dt
			End Get
		End Property

#End Region
#Region "METHODS"

		Protected Sub GetData(ByVal whb_id As Integer)
			Dim _sql As String = GetSelectStatement(whb_id)
			_dt = _objDataProc.GetDataTable(_sql)
		End Sub

		Protected Sub GetData(ByVal box_na As String)
			Dim _sql As String = GetSelectStatement(box_na)
			_dt = _objDataProc.GetDataTable(_sql)
		End Sub

		Protected Function GetSelectStatement(ByVal whb_id As Integer) As String
			Dim _sb As New StringBuilder()
			_sb.Append("SELECT ")
			_sb.Append("d.device_id, ")
			_sb.Append("d.device_sn, ")
			_sb.Append("m.model_desc as Model, ")
			_sb.Append("d.device_daterec Received, ")
			_sb.Append("d.device_datebill as Billed, ")
			_sb.Append("d.device_dateship, ")
			_sb.Append("d.device_shipworkdate as Produced, ")
			_sb.Append("d.device_invoice as Invoiced, ")
			_sb.Append("wb.box_na, ")
			_sb.Append("cust.cust_name1 as Customer, ")
			_sb.Append("wo.wo_custwo as Cust_Work_Order, ")
			_sb.Append("co.workstation ")
			_sb.Append("FROM warehouse.wh_box wb ")
			_sb.Append("INNER JOIN edi.titem i on wb.whb_id = i.whb_id ")
			_sb.Append("INNER JOIN tdevice d on i.device_id = d.device_id ")
			_sb.Append("INNER JOIN tmodel m on d.model_id = m.model_id ")
			_sb.Append("INNER JOIN tlocation loc on d.loc_id = loc.loc_id ")
			_sb.Append("INNER JOIN tcustomer cust on loc.cust_id = cust.cust_id ")
			_sb.Append("LEFT JOIN tworkorder wo on d.wo_id = wo.wo_id ")
			_sb.Append("LEFT JOIN tcellopt co ON d.device_id = co.device_id ")
			_sb.Append("WHERE wb.whb_id = " & whb_id & " ")
			_sb.Append("ORDER BY device_daterec DESC; ")
			Return _sb.ToString()
		End Function

		Protected Function GetSelectStatement(ByVal box_na As String) As String
			Dim _sb As New StringBuilder()
			_sb.Append("SELECT ")
			_sb.Append("d.device_id, ")
			_sb.Append("d.device_sn, ")
			_sb.Append("m.model_desc as Model, ")
			_sb.Append("d.device_daterec Received, ")
			_sb.Append("d.device_datebill as Billed, ")
			_sb.Append("d.device_dateship, ")
			_sb.Append("d.device_shipworkdate as Produced, ")
			_sb.Append("d.device_invoice as Invoiced, ")
			_sb.Append("wb.box_na, ")
			_sb.Append("cust.cust_name1 as Customer, ")
			_sb.Append("wo.wo_custwo as Cust_Work_Order, ")
			_sb.Append("co.workstation ")
			_sb.Append("FROM warehouse.wh_box wb ")
			_sb.Append("INNER JOIN edi.titem i on wb.whb_id = i.whb_id ")
			_sb.Append("INNER JOIN tdevice d on i.device_id = d.device_id ")
			_sb.Append("INNER JOIN tmodel m on d.model_id = m.model_id ")
			_sb.Append("INNER JOIN tlocation loc on d.loc_id = loc.loc_id ")
			_sb.Append("INNER JOIN tcustomer cust on loc.cust_id = cust.cust_id ")
			_sb.Append("LEFT JOIN tworkorder wo on d.wo_id = wo.wo_id ")
			_sb.Append("LEFT JOIN tcellopt co ON d.device_id = co.device_id ")
			_sb.Append("WHERE wb.box_na = '" & box_na & "' ")
			_sb.Append("ORDER BY device_daterec DESC; ")
			Return _sb.ToString()
		End Function

#End Region
	End Class
End Namespace
