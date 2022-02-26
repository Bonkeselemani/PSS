Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic

Namespace BOL

	Public Class warehouse_items

#Region "DECLARATIONS"

		Private _wi_id As Integer = 0
		Private _device_id As Integer = 0
		Private _serial As String = ""
		Private _sku_id As Integer = 0
		Private _date_received As String
		Private _pager_number As String = ""
		Private _cap_code As String = ""
		Private _rf_id As Integer = 0
		Private _physical_abuse_id As Integer = 0
		Private _holder_condition_id As Integer = 0
		Private _case_condition_id As Integer = 0
		Private _batterycover_condition_id As Integer = 0
		Private _wb_id As Integer = 0
		Private _wr_id As Integer = 0
		Private _labor_charge As Decimal = 0
		Private _billcode_id As Integer = 0
		Private _model_id As Integer = 0
		Private _freq_id As Integer = 0
		Private _baudrate_id As Integer = 0
		Private _comment As String = ""
		Private _management_type_id As Integer = 0
		Private _recpt_usrid As Integer = 0
		Private _devconditionid As Integer = 0
		Private _cosmgradeid As Integer = 0
		Private _sodetailsid As Integer = 0
		Private _softkeycode As String = ""
		Private _doa As Integer = 0
		Private _selfinflicted As Integer = 0
		Private _rptsent As Integer = 0
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

		Public Sub New(ByVal wi_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(wi_id)
			_isDirty = False
			_isNew = False
		End Sub


		Public Sub New(ByVal dr As DataRow)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			PopulateObject(dr)
			_isDirty = False
			_isNew = False
		End Sub
		Public Sub New( _
		ByVal wi_id As Integer, _
		ByVal device_id As Integer, _
		ByVal serial As String, _
		ByVal sku_id As Integer, _
		ByVal date_received As String, _
		ByVal pager_number As String, _
		ByVal cap_code As String, _
		ByVal rf_id As Integer, _
		ByVal physical_abuse_id As Integer, _
		ByVal holder_condition_id As Integer, _
		ByVal case_condition_id As Integer, _
		ByVal batterycover_condition_id As Integer, _
		ByVal wb_id As Integer, _
		ByVal wr_id As Integer, _
		ByVal labor_charge As Decimal, _
		ByVal billcode_id As Integer, _
		ByVal model_id As Integer, _
		ByVal freq_id As Integer, _
		ByVal baudrate_id As Integer, _
		ByVal comment As String, _
		ByVal management_type_id As Integer, _
		ByVal recpt_usrid As Integer, _
		ByVal devconditionid As Integer, _
		ByVal cosmgradeid As Integer, _
		ByVal sodetailsid As Integer, _
		ByVal softkeycode As String, _
		ByVal doa As Integer, _
		ByVal selfinflicted As Integer, _
		ByVal rptsent As Integer _
		 )
			_wi_id = wi_id
			_device_id = device_id
			_serial = serial
			_sku_id = sku_id
			_date_received = Date_Received
			_pager_number = Pager_Number
			_cap_code = Cap_Code
			_rf_id = RF_ID
			_physical_abuse_id = Physical_Abuse_ID
			_holder_condition_id = Holder_Condition_ID
			_case_condition_id = Case_Condition_ID
			_batterycover_condition_id = BatteryCover_Condition_ID
			_wb_id = WB_ID
			_wr_id = WR_ID
			_labor_charge = Labor_Charge
			_billcode_id = BillCode_ID
			_model_id = Model_ID
			_freq_id = Freq_ID
			_baudrate_id = BaudRate_ID
			_comment = Comment
			_management_type_id = Management_Type_ID
			_recpt_usrid = Recpt_UsrID
			_devconditionid = DevConditionID
			_cosmgradeid = CosmGradeID
			_sodetailsid = SODetailsID
			_softkeycode = SoftKeyCode
			_doa = DOA
			_selfinflicted = SelfInflicted
			_rptsent = RptSent
		End Sub

#End Region
#Region "PROPERTIES"

		Public Property WI_ID() As Integer
			Get
				Return _wi_id
			End Get
			Set(ByVal Value As Integer)
				_wi_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property Device_ID() As Integer
			Get
				Return _device_id
			End Get
			Set(ByVal Value As Integer)
				_device_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property Serial() As String
			Get
				Return _serial
			End Get
			Set(ByVal Value As String)
				_serial = Value
				_isDirty = True
			End Set
		End Property
		Public Property sku_id() As Integer
			Get
				Return _sku_id
			End Get
			Set(ByVal Value As Integer)
				_sku_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property Date_Received() As String
			Get
				Return _date_received
			End Get
			Set(ByVal Value As String)
				_date_received = Value
				_isDirty = True
			End Set
		End Property
		Public Property Pager_Number() As String
			Get
				Return _pager_number
			End Get
			Set(ByVal Value As String)
				_pager_number = Value
				_isDirty = True
			End Set
		End Property
		Public Property Cap_Code() As String
			Get
				Return _cap_code
			End Get
			Set(ByVal Value As String)
				_cap_code = Value
				_isDirty = True
			End Set
		End Property
		Public Property RF_ID() As Integer
			Get
				Return _rf_id
			End Get
			Set(ByVal Value As Integer)
				_rf_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property Physical_Abuse_ID() As Integer
			Get
				Return _physical_abuse_id
			End Get
			Set(ByVal Value As Integer)
				_physical_abuse_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property Holder_Condition_ID() As Integer
			Get
				Return _holder_condition_id
			End Get
			Set(ByVal Value As Integer)
				_holder_condition_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property Case_Condition_ID() As Integer
			Get
				Return _case_condition_id
			End Get
			Set(ByVal Value As Integer)
				_case_condition_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property BatteryCover_Condition_ID() As Integer
			Get
				Return _batterycover_condition_id
			End Get
			Set(ByVal Value As Integer)
				_batterycover_condition_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property WB_ID() As Integer
			Get
				Return _wb_id
			End Get
			Set(ByVal Value As Integer)
				_wb_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property WR_ID() As Integer
			Get
				Return _wr_id
			End Get
			Set(ByVal Value As Integer)
				_wr_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property Labor_Charge() As Decimal
			Get
				Return _labor_charge
			End Get
			Set(ByVal Value As Decimal)
				_labor_charge = Value
				_isDirty = True
			End Set
		End Property
		Public Property BillCode_ID() As Integer
			Get
				Return _billcode_id
			End Get
			Set(ByVal Value As Integer)
				_billcode_id = Value
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
		Public Property Freq_ID() As Integer
			Get
				Return _freq_id
			End Get
			Set(ByVal Value As Integer)
				_freq_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property BaudRate_ID() As Integer
			Get
				Return _baudrate_id
			End Get
			Set(ByVal Value As Integer)
				_baudrate_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property Comment() As String
			Get
				Return _comment
			End Get
			Set(ByVal Value As String)
				_comment = Value
				_isDirty = True
			End Set
		End Property
		Public Property Management_Type_ID() As Integer
			Get
				Return _management_type_id
			End Get
			Set(ByVal Value As Integer)
				_management_type_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property Recpt_UsrID() As Integer
			Get
				Return _recpt_usrid
			End Get
			Set(ByVal Value As Integer)
				_recpt_usrid = Value
				_isDirty = True
			End Set
		End Property
		Public Property DevConditionID() As Integer
			Get
				Return _devconditionid
			End Get
			Set(ByVal Value As Integer)
				_devconditionid = Value
				_isDirty = True
			End Set
		End Property
		Public Property CosmGradeID() As Integer
			Get
				Return _cosmgradeid
			End Get
			Set(ByVal Value As Integer)
				_cosmgradeid = Value
				_isDirty = True
			End Set
		End Property
		Public Property SODetailsID() As Integer
			Get
				Return _sodetailsid
			End Get
			Set(ByVal Value As Integer)
				_sodetailsid = Value
				_isDirty = True
			End Set
		End Property
		Public Property SoftKeyCode() As String
			Get
				Return _softkeycode
			End Get
			Set(ByVal Value As String)
				_softkeycode = Value
				_isDirty = True
			End Set
		End Property
		Public Property DOA() As Integer
			Get
				Return _doa
			End Get
			Set(ByVal Value As Integer)
				_doa = Value
				_isDirty = True
			End Set
		End Property
		Public Property SelfInflicted() As Integer
			Get
				Return _selfinflicted
			End Get
			Set(ByVal Value As Integer)
				_selfinflicted = Value
				_isDirty = True
			End Set
		End Property
		Public Property RptSent() As Integer
			Get
				Return _rptsent
			End Get
			Set(ByVal Value As Integer)
				_rptsent = Value
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

		Protected Sub GetData(ByVal wi_id As Integer)
			Dim _sql As String = GetSelectStatement(wi_id)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Private Sub PopulateObject(ByVal _dr As DataRow)

			_wi_id = _dr("wi_id").ToString()
			_device_id = _dr("device_id").ToString()
			_serial = ConvertToSomething(_dr("serial").ToString(), "")
			_sku_id = _dr("sku_id").ToString()
			_date_received = ConvertToSomething(_dr("date_received").ToString(), "")
			_pager_number = ConvertToSomething(_dr("pager_number").ToString(), "")
			_cap_code = ConvertToSomething(_dr("cap_code").ToString(), "")
			_rf_id = _dr("rf_id").ToString()
			_physical_abuse_id = _dr("physical_abuse_id").ToString()
			_holder_condition_id = _dr("holder_condition_id").ToString()
			_case_condition_id = _dr("case_condition_id").ToString()
			_batterycover_condition_id = _dr("batterycover_condition_id").ToString()
			_wb_id = _dr("wb_id").ToString()
			_wr_id = _dr("wr_id").ToString()
			_labor_charge = DirectCast(ConvertToSomething(_dr("labor_charge"), 0.0), Decimal)
			_billcode_id = DirectCast(ConvertToSomething(_dr("billcode_id"), 0), Integer)
			_model_id = _dr("model_id").ToString()
			_freq_id = _dr("freq_id").ToString()
			_baudrate_id = _dr("baudrate_id").ToString()
			_comment = ConvertToSomething(_dr("comment").ToString(), "")
			_management_type_id = _dr("management_type_id").ToString()
			_recpt_usrid = _dr("recpt_usrid").ToString()
			_devconditionid = _dr("devconditionid").ToString()
			_cosmgradeid = _dr("cosmgradeid").ToString()
			_sodetailsid = _dr("sodetailsid").ToString()
			_softkeycode = ConvertToSomething(_dr("softkeycode").ToString(), "")
			_doa = DirectCast(ConvertToSomething(_dr("doa"), 0), Integer)
			_selfinflicted = DirectCast(ConvertToSomething(_dr("selfinflicted"), 0), Integer)
			_rptsent = DirectCast(ConvertToSomething(_dr("rptsent"), 0), Integer)
		End Sub
		Protected Function GetSelectStatement(ByVal wi_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "WI_ID, "
			_sql += "Device_ID, "
			_sql += "Serial, "
			_sql += "Sku_id, "
			_sql += "Date_Received, "
			_sql += "Pager_Number, "
			_sql += "Cap_Code, "
			_sql += "RF_ID, "
			_sql += "Physical_Abuse_ID, "
			_sql += "Holder_Condition_ID, "
			_sql += "Case_Condition_ID, "
			_sql += "BatteryCover_Condition_ID, "
			_sql += "WB_ID, "
			_sql += "WR_ID, "
			_sql += "Labor_Charge, "
			_sql += "BillCode_ID, "
			_sql += "Model_ID, "
			_sql += "Freq_ID, "
			_sql += "BaudRate_ID, "
			_sql += "Comment, "
			_sql += "Management_Type_ID, "
			_sql += "Recpt_UsrID, "
			_sql += "DevConditionID, "
			_sql += "CosmGradeID, "
			_sql += "SODetailsID, "
			_sql += "SoftKeyCode, "
			_sql += "DOA, "
			_sql += "SelfInflicted, "
			_sql += "RptSent "
			_sql += "FROM production.warehouse_items "
			_sql += "WHERE wi_id = " & wi_id.ToString() & ""
			Return _sql
		End Function
		Public Sub ApplyChanges()
			Try
				If _isNew Then
					_wi_id = Insert()
				ElseIf IsDeleted Then
					' delete
				ElseIf IsDirty Then
					' Update
				End If
			Catch ex As Exception
				Throw ex
			End Try
		End Sub
		Protected Function Insert() As Integer
			Dim strSQL, strToday As String
			Try
				Dim _objDataProc As DBQuery.DataProc
				Dim _id As Integer
				_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
				strToday = PSS.Data.Buisness.Generic.GetMySqlDateTime("%Y-%m-%d")
				strSQL = "INSERT INTO warehouse.warehouse_items (" & _
				   "wi_id, " & _
				   "device_id, " & _
				   "serial, " & _
				  "sku_id, " & _
				   "date_received, " & _
				   "pager_number, " & _
				   "cap_code, " & _
				   "rf_id, " & _
				   "physical_abuse_id, " & _
				   "holder_condition_id, " & _
				   "case_condition_id, " & _
				   "batterycover_condition_id, " & _
				   "wb_id, " & _
				   "wr_id, " & _
				   "labor_charge, " & _
				   "billcode_id, " & _
				   "model_id, " & _
				   "freq_id, " & _
				   "baudrate_id, " & _
				   "comment, " & _
				   "management_type_id, " & _
				   "recpt_usrid, " & _
				   "devconditionid, " & _
				   "cosmgradeid, " & _
				   "sodetailsid, " & _
				   "softkeycode, " & _
				   "doa, " & _
				   "selfinflicted, " & _
				   "rptsent " & _
				  ") " & _
				  "VALUES ( " & _
				   _wi_id & " , " & _
				   _device_id & " , " & _
				   ConvertBackToNullString(_serial, True) & " , " & _
				   _sku_id & " , " & _
				   ConvertToMySQLDateOrNullString(_date_received) & " , " & _
				   ConvertBackToNullString(_pager_number, True) & " , " & _
				   ConvertBackToNullString(_cap_code, True) & " , " & _
				   _rf_id & " , " & _
				   _physical_abuse_id & " , " & _
				   _holder_condition_id & " , " & _
				   _case_condition_id & " , " & _
				   _batterycover_condition_id & " , " & _
				   ConvertBackToNullString(_wb_id, False) & " , " & _
				   _wr_id & " , " & _
				   _labor_charge & " , " & _
				   _billcode_id & " , " & _
				   _model_id & " , " & _
				   _freq_id & " , " & _
				   _baudrate_id & " , " & _
				   "'" & _comment & "' , " & _
				   _management_type_id & " , " & _
				   _recpt_usrid & " , " & _
				   _devconditionid & " , " & _
				   _cosmgradeid & " , " & _
				   _sodetailsid & " , " & _
				   ConvertBackToNullString(_softkeycode, True) & " , " & _
				   _doa & " , " & _
				   _selfinflicted & " , " & _
				   _rptsent & "  " & _
				   ")"
				_id = _objDataProc.ExecuteScalarForInsert(strSQL, "warehouse.warehouse_items")
				_wi_id = _id
				Return _id
			Catch ex As Exception
				If InStr(ex.Message, "Duplicate") > 0 Then
					Throw New Exception("Duplicate exists.")
				Else
					Throw ex
				End If
			End Try
		End Function
		Protected Function Update() As Integer
			Dim strSQL, strToday As String
			Try
				Dim objDataProc As DBQuery.DataProc
				Dim _id As Integer
				objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
				strToday = PSS.Data.Buisness.Generic.GetMySqlDateTime("%Y-%m-%d")
				strSQL = "UPDATE production.warehouse_items SET " & _
				   "wi_id = " & ConvertBackToNullString(_wi_id, False) & ", " & _
				   "device_id = " & ConvertBackToNullString(_device_id, False) & ", " & _
				   "serial = " & ConvertBackToNullString(_serial, False) & ", " & _
				   "sku_id = " & ConvertBackToNullString(_sku_id, False) & ", " & _
				   "date_received = " & ConvertBackToNullString(_date_received, False) & ", " & _
				   "pager_number = " & ConvertBackToNullString(_pager_number, False) & ", " & _
				   "cap_code = " & ConvertBackToNullString(_cap_code, False) & ", " & _
				   "rf_id = " & ConvertBackToNullString(_rf_id, False) & ", " & _
				   "physical_abuse_id = " & ConvertBackToNullString(_physical_abuse_id, False) & ", " & _
				   "holder_condition_id = " & ConvertBackToNullString(_holder_condition_id, False) & ", " & _
				   "case_condition_id = " & ConvertBackToNullString(_case_condition_id, False) & ", " & _
				   "batterycover_condition_id = " & ConvertBackToNullString(_batterycover_condition_id, False) & ", " & _
				   "wb_id = " & ConvertBackToNullString(_wb_id, False) & ", " & _
				   "wr_id = " & ConvertBackToNullString(_wr_id, False) & ", " & _
				   "labor_charge = " & ConvertBackToNullString(_labor_charge, False) & ", " & _
				   "billcode_id = " & ConvertBackToNullString(_billcode_id, False) & ", " & _
				   "model_id = " & ConvertBackToNullString(_model_id, False) & ", " & _
				   "freq_id = " & ConvertBackToNullString(_freq_id, False) & ", " & _
				   "baudrate_id = " & ConvertBackToNullString(_baudrate_id, False) & ", " & _
				   "comment = " & ConvertBackToNullString(_comment, False) & ", " & _
				   "management_type_id = " & ConvertBackToNullString(_management_type_id, False) & ", " & _
				   "recpt_usrid = " & ConvertBackToNullString(_recpt_usrid, False) & ", " & _
				   "devconditionid = " & ConvertBackToNullString(_devconditionid, False) & ", " & _
				   "cosmgradeid = " & ConvertBackToNullString(_cosmgradeid, False) & ", " & _
				   "sodetailsid = " & ConvertBackToNullString(_sodetailsid, False) & ", " & _
				   "softkeycode = " & ConvertBackToNullString(_softkeycode, False) & ", " & _
				   "doa = " & ConvertBackToNullString(_doa, False) & ", " & _
				   "selfinflicted = " & ConvertBackToNullString(_selfinflicted, False) & ", " & _
				   "rptsent = " & ConvertBackToNullString(_rptsent, False) & ", " & _
				  ") " & _
				  "WHERE WI_ID = " & WI_ID.ToString() & "; "
				Return objDataProc.ExecuteNonQuery(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

#End Region

	End Class


	Public Class warehouse_itemsCollection
#Region "DECLARATIONS"

		Inherits Collections.ArrayList
		Private _objDataProc As DBQuery.DataProc
		Private _dt As New DataTable()
		Private _list As New ArrayList()

#End Region
#Region "CONSTRUCTORS"

		Public Sub New(ByVal wr_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(wr_id)
		End Sub

#End Region
#Region "PROPERTIES"

		Public ReadOnly Property warehouse_itemsDataTable() As DataTable
			Get
				Return _dt
			End Get
		End Property

#End Region
#Region "METHODS"

		Protected Sub GetData(ByVal wr_id As Integer)
			Dim _sql As String = GetSelectStatement(wr_id)
			_dt = _objDataProc.GetDataTable(_sql)
		End Sub

		Protected Function GetSelectStatement(ByVal wr_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "WI_ID, "
			_sql += "Device_ID, "
			_sql += "Serial, "
			_sql += "Sku_id, "
			_sql += "Date_Received, "
			_sql += "Pager_Number, "
			_sql += "Cap_Code, "
			_sql += "RF_ID, "
			_sql += "Physical_Abuse_ID, "
			_sql += "Holder_Condition_ID, "
			_sql += "Case_Condition_ID, "
			_sql += "BatteryCover_Condition_ID, "
			_sql += "WB_ID, "
			_sql += "WR_ID, "
			_sql += "Labor_Charge, "
			_sql += "BillCode_ID, "
			_sql += "Model_ID, "
			_sql += "Freq_ID, "
			_sql += "BaudRate_ID, "
			_sql += "Comment, "
			_sql += "Management_Type_ID, "
			_sql += "Recpt_UsrID, "
			_sql += "DevConditionID, "
			_sql += "CosmGradeID, "
			_sql += "SODetailsID, "
			_sql += "SoftKeyCode, "
			_sql += "DOA, "
			_sql += "SelfInflicted, "
			_sql += "RptSent "
			_sql += "FROM production.warehouse_items "
			_sql += "WHERE wr_id = " & wr_id.ToString() & ""
			Return _sql
		End Function

#End Region
	End Class

End Namespace