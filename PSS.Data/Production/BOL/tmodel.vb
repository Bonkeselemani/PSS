Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic

Namespace BOL
	Public Class tmodel
#Region "DECLARATIONS"

		Private _model_id As Integer = 0
		Private _model_desc As String = ""
		Private _model_type As Integer = 0
		Private _model_motosku As String = ""
		Private _model_tier As Integer = 0
		Private _model_flat As Integer = 0
		Private _model_hexsn As Boolean = False
		Private _manuf_id As Integer = 0
		Private _prod_id As Integer = 0
		Private _prodgrp_id As Integer = 0
		Private _ascprice_id As Integer = 0
		Private _rptgrp_id As Integer = 0
		Private _conv_id As Integer = 0
		Private _dcode_id As Integer = 0
		Private _model_gsm As Boolean = False
		Private _accessory As Integer = 0
		Private _upc_code As String = ""
		Private _user_id As Integer = 0
		Private _updatedate As String
		Private _weight_factor As System.Double = 0.0
		Private _goalhour As System.Double = 0.0
		Private _piecesperhour As Decimal = 0
		Private _piecepoint As System.Double = 0.0
		Private _pointgoal As System.Double = 0.0
		Private _autobillflg As Boolean = False
		Private _model_unlockcode As Boolean = False
		Private _custommodelgroup As Integer = 0
		Private _model_timestamp As String
		Private _model_volume As Boolean = False
		Private _mrp_status As Boolean = False
		Private _mrp_hide As Boolean = False
		Private _mrp_group As Boolean = False
		Private _manufmodelnumber As String = ""
		Private _altwrtydatecode As Integer = 0
		Private _has_bc As Boolean = False
		Private _cur_cust_dcode_id As Integer = 0
		Private _sw_process As Boolean = False
		Private _ks_capable As Boolean = False
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

		Public Sub New(ByVal model_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(model_id)
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
		ByVal model_id As Integer, _
		ByVal model_desc As String, _
		ByVal model_type As Integer, _
		ByVal model_motosku As String, _
		ByVal model_tier As Integer, _
		ByVal model_flat As Integer, _
		ByVal model_hexsn As Boolean, _
		ByVal manuf_id As Integer, _
		ByVal prod_id As Integer, _
		ByVal prodgrp_id As Integer, _
		ByVal ascprice_id As Integer, _
		ByVal rptgrp_id As Integer, _
		ByVal conv_id As Integer, _
		ByVal dcode_id As Integer, _
		ByVal model_gsm As Boolean, _
		ByVal accessory As Integer, _
		ByVal upc_code As String, _
		ByVal user_id As Integer, _
		ByVal updatedate As String, _
		ByVal weight_factor As System.Double, _
		ByVal goalhour As System.Double, _
		ByVal piecesperhour As Decimal, _
		ByVal piecepoint As System.Double, _
		ByVal pointgoal As System.Double, _
		ByVal autobillflg As Boolean, _
		ByVal model_unlockcode As Boolean, _
		ByVal custommodelgroup As Integer, _
		ByVal model_timestamp As String, _
		ByVal model_volume As Boolean, _
		ByVal mrp_status As Boolean, _
		ByVal mrp_hide As Boolean, _
		ByVal mrp_group As Boolean, _
		ByVal manufmodelnumber As String, _
		ByVal altwrtydatecode As Integer, _
		ByVal has_bc As Boolean, _
		ByVal cur_cust_dcode_id As Integer, _
		ByVal sw_process As Boolean, _
		ByVal ks_capable As Boolean _
		 )
			_model_id = model_id
			_model_desc = model_desc
			_model_type = model_type
			_model_motosku = model_motosku
			_model_tier = model_tier
			_model_flat = model_flat
			_model_hexsn = model_hexsn
			_manuf_id = manuf_id
			_prod_id = prod_id
			_prodgrp_id = prodgrp_id
			_ascprice_id = ascprice_id
			_rptgrp_id = rptgrp_id
			_conv_id = conv_id
			_dcode_id = dcode_id
			_model_gsm = model_gsm
			_accessory = accessory
			_upc_code = upc_code
			_user_id = user_id
			_updatedate = updatedate
			_weight_factor = weight_factor
			_goalhour = goalhour
			_piecesperhour = piecesperhour
			_piecepoint = piecepoint
			_pointgoal = pointgoal
			_autobillflg = autobillflg
			_model_unlockcode = model_unlockcode
			_custommodelgroup = custommodelgroup
			_model_timestamp = model_timestamp
			_model_volume = model_volume
			_mrp_status = mrp_status
			_mrp_hide = mrp_hide
			_mrp_group = mrp_group
			_manufmodelnumber = manufmodelnumber
			_altwrtydatecode = altwrtydatecode
			_has_bc = has_bc
			_cur_cust_dcode_id = cur_cust_dcode_id
			_sw_process = sw_process
			_ks_capable = ks_capable
		End Sub

#End Region
#Region "PROPERTIES"

		Public Property Model_ID() As Integer
			Get
				Return _model_id
			End Get
			Set(ByVal Value As Integer)
				_model_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property Model_Desc() As String
			Get
				Return _model_desc
			End Get
			Set(ByVal Value As String)
				_model_desc = Value
				_isDirty = True
			End Set
		End Property
		Public Property Model_Type() As Integer
			Get
				Return _model_type
			End Get
			Set(ByVal Value As Integer)
				_model_type = Value
				_isDirty = True
			End Set
		End Property
		Public Property Model_MotoSku() As String
			Get
				Return _model_motosku
			End Get
			Set(ByVal Value As String)
				_model_motosku = Value
				_isDirty = True
			End Set
		End Property
		Public Property Model_Tier() As Integer
			Get
				Return _model_tier
			End Get
			Set(ByVal Value As Integer)
				_model_tier = Value
				_isDirty = True
			End Set
		End Property
		Public Property Model_Flat() As Integer
			Get
				Return _model_flat
			End Get
			Set(ByVal Value As Integer)
				_model_flat = Value
				_isDirty = True
			End Set
		End Property
		Public Property Model_HexSN() As Boolean
			Get
				Return _model_hexsn
			End Get
			Set(ByVal Value As Boolean)
				_model_hexsn = Value
				_isDirty = True
			End Set
		End Property
		Public Property Manuf_ID() As Integer
			Get
				Return _manuf_id
			End Get
			Set(ByVal Value As Integer)
				_manuf_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property Prod_ID() As Integer
			Get
				Return _prod_id
			End Get
			Set(ByVal Value As Integer)
				_prod_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property ProdGrp_ID() As Integer
			Get
				Return _prodgrp_id
			End Get
			Set(ByVal Value As Integer)
				_prodgrp_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property ASCPrice_ID() As Integer
			Get
				Return _ascprice_id
			End Get
			Set(ByVal Value As Integer)
				_ascprice_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property RptGrp_ID() As Integer
			Get
				Return _rptgrp_id
			End Get
			Set(ByVal Value As Integer)
				_rptgrp_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property Conv_ID() As Integer
			Get
				Return _conv_id
			End Get
			Set(ByVal Value As Integer)
				_conv_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property Dcode_ID() As Integer
			Get
				Return _dcode_id
			End Get
			Set(ByVal Value As Integer)
				_dcode_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property Model_GSM() As Boolean
			Get
				Return _model_gsm
			End Get
			Set(ByVal Value As Boolean)
				_model_gsm = Value
				_isDirty = True
			End Set
		End Property
		Public Property Accessory() As Integer
			Get
				Return _accessory
			End Get
			Set(ByVal Value As Integer)
				_accessory = Value
				_isDirty = True
			End Set
		End Property
		Public Property UPC_Code() As String
			Get
				Return _upc_code
			End Get
			Set(ByVal Value As String)
				_upc_code = Value
				_isDirty = True
			End Set
		End Property
		Public Property User_ID() As Integer
			Get
				Return _user_id
			End Get
			Set(ByVal Value As Integer)
				_user_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property UpdateDate() As String
			Get
				Return _updatedate
			End Get
			Set(ByVal Value As String)
				_updatedate = Value
				_isDirty = True
			End Set
		End Property
		Public Property Weight_Factor() As System.Double
			Get
				Return _weight_factor
			End Get
			Set(ByVal Value As System.Double)
				_weight_factor = Value
				_isDirty = True
			End Set
		End Property
		Public Property GoalHour() As System.Double
			Get
				Return _goalhour
			End Get
			Set(ByVal Value As System.Double)
				_goalhour = Value
				_isDirty = True
			End Set
		End Property
		Public Property PiecesPerHour() As Decimal
			Get
				Return _piecesperhour
			End Get
			Set(ByVal Value As Decimal)
				_piecesperhour = Value
				_isDirty = True
			End Set
		End Property
		Public Property PiecePoint() As System.Double
			Get
				Return _piecepoint
			End Get
			Set(ByVal Value As System.Double)
				_piecepoint = Value
				_isDirty = True
			End Set
		End Property
		Public Property PointGoal() As System.Double
			Get
				Return _pointgoal
			End Get
			Set(ByVal Value As System.Double)
				_pointgoal = Value
				_isDirty = True
			End Set
		End Property
		Public Property AutoBillFlg() As Boolean
			Get
				Return _autobillflg
			End Get
			Set(ByVal Value As Boolean)
				_autobillflg = Value
				_isDirty = True
			End Set
		End Property
		Public Property Model_UnlockCode() As Boolean
			Get
				Return _model_unlockcode
			End Get
			Set(ByVal Value As Boolean)
				_model_unlockcode = Value
				_isDirty = True
			End Set
		End Property
		Public Property CustomModelGroup() As Integer
			Get
				Return _custommodelgroup
			End Get
			Set(ByVal Value As Integer)
				_custommodelgroup = Value
				_isDirty = True
			End Set
		End Property
		Public Property Model_Timestamp() As String
			Get
				Return _model_timestamp
			End Get
			Set(ByVal Value As String)
				_model_timestamp = Value
				_isDirty = True
			End Set
		End Property
		Public Property Model_Volume() As Boolean
			Get
				Return _model_volume
			End Get
			Set(ByVal Value As Boolean)
				_model_volume = Value
				_isDirty = True
			End Set
		End Property
		Public Property MRP_Status() As Boolean
			Get
				Return _mrp_status
			End Get
			Set(ByVal Value As Boolean)
				_mrp_status = Value
				_isDirty = True
			End Set
		End Property
		Public Property MRP_Hide() As Boolean
			Get
				Return _mrp_hide
			End Get
			Set(ByVal Value As Boolean)
				_mrp_hide = Value
				_isDirty = True
			End Set
		End Property
		Public Property MRP_Group() As Boolean
			Get
				Return _mrp_group
			End Get
			Set(ByVal Value As Boolean)
				_mrp_group = Value
				_isDirty = True
			End Set
		End Property
		Public Property ManufModelNumber() As String
			Get
				Return _manufmodelnumber
			End Get
			Set(ByVal Value As String)
				_manufmodelnumber = Value
				_isDirty = True
			End Set
		End Property
		Public Property AltWrtyDateCode() As Integer
			Get
				Return _altwrtydatecode
			End Get
			Set(ByVal Value As Integer)
				_altwrtydatecode = Value
				_isDirty = True
			End Set
		End Property
		Public Property Has_BC() As Boolean
			Get
				Return _has_bc
			End Get
			Set(ByVal Value As Boolean)
				_has_bc = Value
				_isDirty = True
			End Set
		End Property
		Public Property cur_cust_dcode_id() As Integer
			Get
				Return _cur_cust_dcode_id
			End Get
			Set(ByVal Value As Integer)
				_cur_cust_dcode_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property sw_process() As Boolean
			Get
				Return _sw_process
			End Get
			Set(ByVal Value As Boolean)
				_sw_process = Value
				_isDirty = True
			End Set
		End Property
		Public Property ks_capable() As Boolean
			Get
				Return _ks_capable
			End Get
			Set(ByVal Value As Boolean)
				_ks_capable = Value
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

		Protected Sub GetData(ByVal Model_ID As Integer)
			Dim _sql As String = GetSelectStatement(Model_ID)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Private Sub PopulateObject(ByVal _dr As DataRow)

			_model_id = ConvertToSomething(_dr("model_id"), 0)
			_model_desc = ConvertToSomething(_dr("model_desc").ToString(), "")
			_model_type = ConvertToSomething(_dr("model_type"), 0)
			_model_motosku = ConvertToSomething(_dr("model_motosku").ToString(), "")
			_model_tier = ConvertToSomething(_dr("model_tier"), 0)
			_model_flat = ConvertToSomething(_dr("model_flat"), 0)
			_model_hexsn = ConvertBoolToIntString(_dr("model_hexsn"))
			_manuf_id = ConvertToSomething(_dr("manuf_id"), 0)
			_prod_id = ConvertToSomething(_dr("prod_id"), 0)
			_prodgrp_id = ConvertToSomething(_dr("prodgrp_id"), 0)
			_ascprice_id = ConvertToSomething(_dr("ascprice_id"), 0)
			_rptgrp_id = ConvertToSomething(_dr("rptgrp_id"), 0)
			_conv_id = ConvertToSomething(_dr("conv_id"), 0)
			_dcode_id = ConvertToSomething(_dr("dcode_id"), 0)
			_model_gsm = ConvertBoolToIntString(_dr("model_gsm"))
			_accessory = _dr("accessory").ToString()
			_upc_code = ConvertToSomething(_dr("upc_code").ToString(), "")
			_user_id = _dr("user_id").ToString()
			_updatedate = ConvertToSomething(_dr("updatedate").ToString(), "")
			_weight_factor = _dr("weight_factor").ToString()
			_goalhour = _dr("goalhour").ToString()
			_piecesperhour = ConvertToSomething(_dr("piecesperhour"), 0.0)
			_piecepoint = _dr("piecepoint").ToString()
			_pointgoal = _dr("pointgoal").ToString()
			_autobillflg = ConvertBoolToIntString(_dr("autobillflg"))
			_model_unlockcode = ConvertBoolToIntString(_dr("model_unlockcode"))
			_custommodelgroup = ConvertToSomething(_dr("custommodelgroup"), 0)
			_model_timestamp = ConvertToSomething(_dr("model_timestamp").ToString(), "")
			_model_volume = ConvertBoolToIntString(_dr("model_volume"))
			_mrp_status = ConvertBoolToIntString(_dr("mrp_status"))
			_mrp_hide = ConvertBoolToIntString(_dr("mrp_hide"))
			_mrp_group = ConvertBoolToIntString(_dr("mrp_group"))
			_manufmodelnumber = ConvertToSomething(_dr("manufmodelnumber").ToString(), "")
			_altwrtydatecode = _dr("altwrtydatecode").ToString()
			_has_bc = ConvertBoolToIntString(_dr("has_bc"))
			_cur_cust_dcode_id = ConvertToSomething(_dr("cur_cust_dcode_id"), 0)
			_sw_process = ConvertBoolToIntString(_dr("sw_process"))
			_ks_capable = ConvertBoolToIntString(_dr("ks_capable"))
		End Sub
		Protected Function GetSelectStatement(ByVal Model_ID As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "Model_ID, "
			_sql += "Model_Desc, "
			_sql += "Model_Type, "
			_sql += "Model_MotoSku, "
			_sql += "Model_Tier, "
			_sql += "Model_Flat, "
			_sql += "Model_HexSN, "
			_sql += "Manuf_ID, "
			_sql += "Prod_ID, "
			_sql += "ProdGrp_ID, "
			_sql += "ASCPrice_ID, "
			_sql += "RptGrp_ID, "
			_sql += "Conv_ID, "
			_sql += "Dcode_ID, "
			_sql += "Model_GSM, "
			_sql += "Accessory, "
			_sql += "UPC_Code, "
			_sql += "User_ID, "
			_sql += "UpdateDate, "
			_sql += "Weight_Factor, "
			_sql += "GoalHour, "
			_sql += "PiecesPerHour, "
			_sql += "PiecePoint, "
			_sql += "PointGoal, "
			_sql += "AutoBillFlg, "
			_sql += "Model_UnlockCode, "
			_sql += "CustomModelGroup, "
			_sql += "Model_Timestamp, "
			_sql += "Model_Volume, "
			_sql += "MRP_Status, "
			_sql += "MRP_Hide, "
			_sql += "MRP_Group, "
			_sql += "ManufModelNumber, "
			_sql += "AltWrtyDateCode, "
			_sql += "Has_BC, "
			_sql += "cur_cust_dcode_id, "
			_sql += "sw_process, "
			_sql += "ks_capable "
			_sql += "FROM production.tmodel "
			_sql += "WHERE model_id = " & Model_ID.ToString() & ""
			Return _sql
		End Function

		Public Sub ApplyChanges()
			If _isNew Then
				_model_id = Insert()
			ElseIf IsDeleted Then
				' delete
			ElseIf IsDirty Then
				' Update
			End If
		End Sub

		Protected Function Insert() As Integer
			Dim strSQL, strToday As String
			Try
				Dim objDataProc As DBQuery.DataProc
				Dim _id As Integer
				objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
				strToday = PSS.Data.Buisness.Generic.GetMySqlDateTime("%Y-%m-%d")
				strSQL = "INSERT INTO production.tmodel (" & _
				   "model_id, " & _
				   "model_desc, " & _
				   "model_type, " & _
				   "model_motosku, " & _
				   "model_tier, " & _
				   "model_flat, " & _
				   "model_hexsn, " & _
				   "manuf_id, " & _
				   "prod_id, " & _
				   "prodgrp_id, " & _
				   "ascprice_id, " & _
				   "rptgrp_id, " & _
				   "conv_id, " & _
				   "dcode_id, " & _
				   "model_gsm, " & _
				   "accessory, " & _
				   "upc_code, " & _
				   "user_id, " & _
				   "updatedate, " & _
				   "weight_factor, " & _
				   "goalhour, " & _
				   "piecesperhour, " & _
				   "piecepoint, " & _
				   "pointgoal, " & _
				   "autobillflg, " & _
				   "model_unlockcode, " & _
				   "custommodelgroup, " & _
				   "model_timestamp, " & _
				   "model_volume, " & _
				   "mrp_status, " & _
				   "mrp_hide, " & _
				   "mrp_group, " & _
				   "manufmodelnumber, " & _
				   "altwrtydatecode, " & _
				   "has_bc, " & _
				   "cur_cust_dcode_id, " & _
				   "sw_process, " & _
				   "ks_capable " & _
				  ") " & _
				  "VALUES ( " & _
				   _model_id & " , " & _
				   ConvertBackToNullString(_model_desc, False) & " , " & _
				   _model_type & " , " & _
				   ConvertBackToNullString(_model_motosku, False) & " , " & _
				   ConvertBackToNullString(_model_tier, False) & " , " & _
				   ConvertBackToNullString(_model_flat, False) & " , " & _
				   _model_hexsn & " , " & _
				   ConvertBackToNullString(_manuf_id, False) & " , " & _
				   ConvertBackToNullString(_prod_id, False) & " , " & _
				   ConvertBackToNullString(_prodgrp_id, False) & " , " & _
				   ConvertBackToNullString(_ascprice_id, False) & " , " & _
				   ConvertBackToNullString(_rptgrp_id, False) & " , " & _
				   _conv_id & " , " & _
				   ConvertBackToNullString(_dcode_id, False) & " , " & _
				   _model_gsm & " , " & _
				   ConvertBackToNullString(_accessory, False) & " , " & _
				   ConvertBackToNullString(_upc_code, False) & " , " & _
				   ConvertBackToNullString(_user_id, False) & " , " & _
				   ConvertBackToNullString(_updatedate, False) & " , " & _
				   ConvertBackToNullString(_weight_factor, False) & " , " & _
				   ConvertBackToNullString(_goalhour, False) & " , " & _
				   _piecesperhour & " , " & _
				   ConvertBackToNullString(_piecepoint, False) & " , " & _
				   ConvertBackToNullString(_pointgoal, False) & " , " & _
				   ConvertBackToNullString(_autobillflg, False) & " , " & _
				   _model_unlockcode & " , " & _
				   _custommodelgroup & " , " & _
				   _model_timestamp & " , " & _
				   ConvertBackToNullString(_model_volume, False) & " , " & _
				   ConvertBackToNullString(_mrp_status, False) & " , " & _
				   ConvertBackToNullString(_mrp_hide, False) & " , " & _
				   ConvertBackToNullString(_mrp_group, False) & " , " & _
				   _manufmodelnumber & " , " & _
				   _altwrtydatecode & " , " & _
				   _has_bc & " , " & _
				   ConvertBackToNullString(_cur_cust_dcode_id, False) & " , " & _
				   _sw_process & " , " & _
				   _ks_capable & "  " & _
				   ")"
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
				strSQL = "UPDATE production.tmodel SET " & _
				   "model_id = " & ConvertBackToNullString(_model_id, False) & ", " & _
				   "model_desc = " & ConvertBackToNullString(_model_desc, False) & ", " & _
				   "model_type = " & ConvertBackToNullString(_model_type, False) & ", " & _
				   "model_motosku = " & ConvertBackToNullString(_model_motosku, False) & ", " & _
				   "model_tier = " & ConvertBackToNullString(_model_tier, False) & ", " & _
				   "model_flat = " & ConvertBackToNullString(_model_flat, False) & ", " & _
				   "model_hexsn = " & ConvertBackToNullString(_model_hexsn, False) & ", " & _
				   "manuf_id = " & ConvertBackToNullString(_manuf_id, False) & ", " & _
				   "prod_id = " & ConvertBackToNullString(_prod_id, False) & ", " & _
				   "prodgrp_id = " & ConvertBackToNullString(_prodgrp_id, False) & ", " & _
				   "ascprice_id = " & ConvertBackToNullString(_ascprice_id, False) & ", " & _
				   "rptgrp_id = " & ConvertBackToNullString(_rptgrp_id, False) & ", " & _
				   "conv_id = " & ConvertBackToNullString(_conv_id, False) & ", " & _
				   "dcode_id = " & ConvertBackToNullString(_dcode_id, False) & ", " & _
				   "model_gsm = " & ConvertBackToNullString(_model_gsm, False) & ", " & _
				   "accessory = " & ConvertBackToNullString(_accessory, False) & ", " & _
				   "upc_code = " & ConvertBackToNullString(_upc_code, False) & ", " & _
				   "user_id = " & ConvertBackToNullString(_user_id, False) & ", " & _
				   "updatedate = " & ConvertBackToNullString(_updatedate, False) & ", " & _
				   "weight_factor = " & ConvertBackToNullString(_weight_factor, False) & ", " & _
				   "goalhour = " & ConvertBackToNullString(_goalhour, False) & ", " & _
				   "piecesperhour = " & ConvertBackToNullString(_piecesperhour, False) & ", " & _
				   "piecepoint = " & ConvertBackToNullString(_piecepoint, False) & ", " & _
				   "pointgoal = " & ConvertBackToNullString(_pointgoal, False) & ", " & _
				   "autobillflg = " & ConvertBackToNullString(_autobillflg, False) & ", " & _
				   "model_unlockcode = " & ConvertBackToNullString(_model_unlockcode, False) & ", " & _
				   "custommodelgroup = " & ConvertBackToNullString(_custommodelgroup, False) & ", " & _
				   "model_timestamp = " & ConvertBackToNullString(_model_timestamp, False) & ", " & _
				   "model_volume = " & ConvertBackToNullString(_model_volume, False) & ", " & _
				   "mrp_status = " & ConvertBackToNullString(_mrp_status, False) & ", " & _
				   "mrp_hide = " & ConvertBackToNullString(_mrp_hide, False) & ", " & _
				   "mrp_group = " & ConvertBackToNullString(_mrp_group, False) & ", " & _
				   "manufmodelnumber = " & ConvertBackToNullString(_manufmodelnumber, False) & ", " & _
				   "altwrtydatecode = " & ConvertBackToNullString(_altwrtydatecode, False) & ", " & _
				   "has_bc = " & ConvertBackToNullString(_has_bc, False) & ", " & _
				   "cur_cust_dcode_id = " & ConvertBackToNullString(_cur_cust_dcode_id, False) & ", " & _
				   "sw_process = " & ConvertBackToNullString(_sw_process, False) & ", " & _
				   "ks_capable = " & ConvertBackToNullString(_ks_capable, False) & ", " & _
				  ") " & _
				  "WHERE Model_ID = " & Model_ID.ToString() & "; "
				Return objDataProc.ExecuteNonQuery(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

#End Region

	End Class
	Public Class tmodelCollection
#Region "DECLARATIONS"

		Inherits Collections.ArrayList
		Private _objDataProc As DBQuery.DataProc
		Private _dt As New DataTable()
		Private _list As New ArrayList()

#End Region
#Region "CONSTRUCTORS"

		Public Sub New(ByVal cust_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(cust_id)
		End Sub

#End Region
#Region "PROPERTIES"

		Public ReadOnly Property tmodelDataTable() As DataTable
			Get
				Return _dt
			End Get
		End Property

#End Region
#Region "METHODS"

		Protected Sub GetData(ByVal cust_id As Integer)
			Dim _sql As String = GetSelectStatement(cust_id)
			_dt = _objDataProc.GetDataTable(_sql)
		End Sub

		Protected Function GetSelectStatement(ByVal cust_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "m.model_id, "
			_sql += "m.model_desc "
			_sql += "FROM production.tmodel m "
			_sql += "INNER JOIN tcustmodel_pssmodel_map map ON m.Model_ID = map.model_id "
			_sql += "WHERE map.cust_id = " & cust_id.ToString() & " "
			_sql += "ORDER BY m.model_desc;"
			Return _sql
		End Function

#End Region
	End Class
End Namespace
