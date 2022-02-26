Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic
Namespace BOL
	Public Class tpallet
#Region "DECLARATIONS"

		Private _pallett_id As Integer = 0
		Private _pallett_name As String = ""
		Private _pallett_shipdate As String
		Private _pallett_bulkshipped As Boolean = False
		Private _pallett_readytoshipflg As Boolean = False
		Private _pallet_shiptype As Integer = 0
		Private _pallet_skulen As String = ""
		Private _pallet_invalid As Integer = 0
		Private _pallet_invalidusrid As Integer = 0
		Private _awpflag As Boolean = False
		Private _wo_id As Integer = 0
		Private _model_id As Integer = 0
		Private _cust_id As Integer = 0
		Private _pallet_timestamp As String
		Private _dobflg As Boolean = False
		Private _pallett_senddt As String
		Private _pallett_maxqty As Integer = 0
		Private _pallett_qty As Integer = 0
		Private _pallet_weight As Integer = 0
		Private _unitmeasurementcode As String = ""
		Private _order_seqno As Integer = 0
		Private _pallet_seqno As Integer = 0
		Private _pkslip_id As Integer = 0
		Private _loc_id As Integer = 0
		Private _specialinvproject As Boolean = False
		Private _pallettype_id As Integer = 0
		Private _aql_qcresult_id As Integer = 0
		Private _aql_lot_id As Integer = 0
		Private _whlocation As String = ""
		Private _disp_id As Integer = 0
		Private _pallet_qc_passed As Integer = 0
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

		Public Sub New(ByVal pallett_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(pallett_id)
			_isDirty = False
			_isNew = False
		End Sub


		Public Sub New(ByVal pallett_name As String)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(pallett_name)
			_isDirty = False
			_isNew = False
		End Sub

#End Region
#Region "PROPERTIES"

		Public Property Pallett_ID() As Integer
			Get
				Return _pallett_id
			End Get
			Set(ByVal Value As Integer)
				_pallett_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property Pallett_Name() As String
			Get
				Return _pallett_name
			End Get
			Set(ByVal Value As String)
				_pallett_name = Value
				_isDirty = True
			End Set
		End Property
		Public Property Pallett_ShipDate() As String
			Get
				Return _pallett_shipdate
			End Get
			Set(ByVal Value As String)
				_pallett_shipdate = Value
				_isDirty = True
			End Set
		End Property
		Public Property Pallett_BulkShipped() As Boolean
			Get
				Return _pallett_bulkshipped
			End Get
			Set(ByVal Value As Boolean)
				_pallett_bulkshipped = Value
				_isDirty = True
			End Set
		End Property
		Public Property Pallett_ReadyToShipFlg() As Boolean
			Get
				Return _pallett_readytoshipflg
			End Get
			Set(ByVal Value As Boolean)
				_pallett_readytoshipflg = Value
				_isDirty = True
			End Set
		End Property
		Public Property Pallet_ShipType() As Integer
			Get
				Return _pallet_shiptype
			End Get
			Set(ByVal Value As Integer)
				_pallet_shiptype = Value
				_isDirty = True
			End Set
		End Property
		Public Property Pallet_SkuLen() As String
			Get
				Return _pallet_skulen
			End Get
			Set(ByVal Value As String)
				_pallet_skulen = Value
				_isDirty = True
			End Set
		End Property
		Public Property Pallet_Invalid() As Integer
			Get
				Return _pallet_invalid
			End Get
			Set(ByVal Value As Integer)
				_pallet_invalid = Value
				_isDirty = True
			End Set
		End Property
		Public Property Pallet_InvalidUsrID() As Integer
			Get
				Return _pallet_invalidusrid
			End Get
			Set(ByVal Value As Integer)
				_pallet_invalidusrid = Value
				_isDirty = True
			End Set
		End Property
		Public Property AWPFlag() As Boolean
			Get
				Return _awpflag
			End Get
			Set(ByVal Value As Boolean)
				_awpflag = Value
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
		Public Property Model_ID() As Integer
			Get
				Return _model_id
			End Get
			Set(ByVal Value As Integer)
				_model_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property Cust_ID() As Integer
			Get
				Return _cust_id
			End Get
			Set(ByVal Value As Integer)
				_cust_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property pallet_TimeStamp() As String
			Get
				Return _pallet_timestamp
			End Get
			Set(ByVal Value As String)
				_pallet_timestamp = Value
				_isDirty = True
			End Set
		End Property
		Public Property DOBFlg() As Boolean
			Get
				Return _dobflg
			End Get
			Set(ByVal Value As Boolean)
				_dobflg = Value
				_isDirty = True
			End Set
		End Property
		Public Property Pallett_SendDt() As String
			Get
				Return _pallett_senddt
			End Get
			Set(ByVal Value As String)
				_pallett_senddt = Value
				_isDirty = True
			End Set
		End Property
		Public Property Pallett_MaxQty() As Integer
			Get
				Return _pallett_maxqty
			End Get
			Set(ByVal Value As Integer)
				_pallett_maxqty = Value
				_isDirty = True
			End Set
		End Property
		Public Property Pallett_QTY() As Integer
			Get
				Return _pallett_qty
			End Get
			Set(ByVal Value As Integer)
				_pallett_qty = Value
				_isDirty = True
			End Set
		End Property
		Public Property Pallet_Weight() As Integer
			Get
				Return _pallet_weight
			End Get
			Set(ByVal Value As Integer)
				_pallet_weight = Value
				_isDirty = True
			End Set
		End Property
		Public Property UnitMeasurementCode() As String
			Get
				Return _unitmeasurementcode
			End Get
			Set(ByVal Value As String)
				_unitmeasurementcode = Value
				_isDirty = True
			End Set
		End Property
		Public Property Order_SeqNo() As Integer
			Get
				Return _order_seqno
			End Get
			Set(ByVal Value As Integer)
				_order_seqno = Value
				_isDirty = True
			End Set
		End Property
		Public Property Pallet_SeqNo() As Integer
			Get
				Return _pallet_seqno
			End Get
			Set(ByVal Value As Integer)
				_pallet_seqno = Value
				_isDirty = True
			End Set
		End Property
		Public Property pkslip_ID() As Integer
			Get
				Return _pkslip_id
			End Get
			Set(ByVal Value As Integer)
				_pkslip_id = Value
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
		Public Property SpecialInvProject() As Boolean
			Get
				Return _specialinvproject
			End Get
			Set(ByVal Value As Boolean)
				_specialinvproject = Value
				_isDirty = True
			End Set
		End Property
		Public Property PalletType_ID() As Integer
			Get
				Return _pallettype_id
			End Get
			Set(ByVal Value As Integer)
				_pallettype_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property AQL_QCResult_ID() As Integer
			Get
				Return _aql_qcresult_id
			End Get
			Set(ByVal Value As Integer)
				_aql_qcresult_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property AQL_Lot_ID() As Integer
			Get
				Return _aql_lot_id
			End Get
			Set(ByVal Value As Integer)
				_aql_lot_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property WHLocation() As String
			Get
				Return _whlocation
			End Get
			Set(ByVal Value As String)
				_whlocation = Value
				_isDirty = True
			End Set
		End Property
		Public Property disp_id() As Integer
			Get
				Return _disp_id
			End Get
			Set(ByVal Value As Integer)
				_disp_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property pallet_qc_passed() As Integer
			Get
				Return _pallet_qc_passed
			End Get
			Set(ByVal Value As Integer)
				_pallet_qc_passed = Value
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
		Protected Sub GetData(ByVal pallett_id As Integer)
			Dim _sql As String = GetSelectStatement(pallett_id, "")
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Protected Sub GetData(ByVal pallett_name As String)
			Dim _sql As String = GetSelectStatement(0, pallett_name)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Private Sub PopulateObject(ByVal _dr As DataRow)
			_pallett_id = ConvertToSomething(_dr("pallett_id"), 0)
			_pallett_name = ConvertToSomething(_dr("pallett_name").ToString(), "")
			_pallett_shipdate = ConvertToSomething(_dr("pallett_shipdate").ToString(), "")
			_pallett_bulkshipped = ConvertToSomething(_dr("pallett_bulkshipped"), False)
			_pallett_readytoshipflg = ConvertToSomething(_dr("pallett_readytoshipflg"), False)
			_pallet_shiptype = ConvertToSomething(_dr("pallet_shiptype"), 0)
			_pallet_skulen = ConvertToSomething(_dr("pallet_skulen").ToString(), "")
			_pallet_invalid = _dr("pallet_invalid").ToString()
			_pallet_invalidusrid = ConvertToSomething(_dr("pallet_invalidusrid"), 0)
			_awpflag = ConvertToSomething(_dr("awpflag"), False)
			_wo_id = ConvertToSomething(_dr("wo_id"), 0)
			_model_id = ConvertToSomething(_dr("model_id"), 0)
			_cust_id = ConvertToSomething(_dr("cust_id"), 0)
			_pallet_timestamp = ConvertToSomething(_dr("pallet_timestamp").ToString(), "")
			_dobflg = ConvertToSomething(_dr("dobflg"), False)
			_pallett_senddt = ConvertToSomething(_dr("pallett_senddt").ToString(), "")
			_pallett_maxqty = ConvertToSomething(_dr("pallett_maxqty"), 0)
			_pallett_qty = ConvertToSomething(_dr("pallett_qty"), 0)
			_pallet_weight = ConvertToSomething(_dr("pallet_weight"), 0)
			_unitmeasurementcode = ConvertToSomething(_dr("unitmeasurementcode").ToString(), "")
			_order_seqno = ConvertToSomething(_dr("order_seqno"), 0)
			_pallet_seqno = ConvertToSomething(_dr("pallet_seqno"), 0)
			_pkslip_id = ConvertToSomething(_dr("pkslip_id"), 0)
			_loc_id = ConvertToSomething(_dr("loc_id"), 0)
			_specialinvproject = IIf(_dr("specialinvproject"), "1", "0")
			_pallettype_id = ConvertToSomething(_dr("pallettype_id"), 0)
			_aql_qcresult_id = ConvertToSomething(_dr("aql_qcresult_id"), 0)
			_aql_lot_id = ConvertToSomething(_dr("aql_lot_id"), 0)
			_whlocation = ConvertToSomething(_dr("whlocation").ToString(), "")
			_disp_id = ConvertToSomething(_dr("disp_id"), 0)
			_pallet_qc_passed = ConvertToSomething(_dr("pallet_qc_passed"), 0)
		End Sub
		Protected Function GetSelectStatement(ByVal pallet_id As Integer, ByVal pallet_name As String) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "Pallett_ID, "
			_sql += "Pallett_Name, "
			_sql += "Pallett_ShipDate, "
			_sql += "Pallett_BulkShipped, "
			_sql += "Pallett_ReadyToShipFlg, "
			_sql += "Pallet_ShipType, "
			_sql += "Pallet_SkuLen, "
			_sql += "Pallet_Invalid, "
			_sql += "Pallet_InvalidUsrID, "
			_sql += "AWPFlag, "
			_sql += "WO_ID, "
			_sql += "Model_ID, "
			_sql += "Cust_ID, "
			_sql += "pallet_TimeStamp, "
			_sql += "DOBFlg, "
			_sql += "Pallett_SendDt, "
			_sql += "Pallett_MaxQty, "
			_sql += "Pallett_QTY, "
			_sql += "Pallet_Weight, "
			_sql += "UnitMeasurementCode, "
			_sql += "Order_SeqNo, "
			_sql += "Pallet_SeqNo, "
			_sql += "pkslip_ID, "
			_sql += "Loc_ID, "
			_sql += "SpecialInvProject, "
			_sql += "PalletType_ID, "
			_sql += "AQL_QCResult_ID, "
			_sql += "AQL_Lot_ID, "
			_sql += "WHLocation, "
			_sql += "disp_id, "
			_sql += "pallet_qc_passed "
			_sql += "FROM production.tpallett "
			_sql += "WHERE "
			If pallet_id > 0 Then
				_sql += "pallett_id = " & pallet_id.ToString() & "; "
			Else
				_sql += "pallett_name = '" & pallet_name & "'; "
			End If
			Return _sql
		End Function
		Public Sub MarkForDeletion()
			_isDeleted = True
		End Sub
		Public Sub ApplyChanges()
			If _isNew Then
				_pallett_id = Insert()
			ElseIf IsDeleted Then
				Delete()
			ElseIf IsDirty Then
				Update()
			End If
		End Sub
		Protected Function Insert() As Integer
			Dim strSQL, strToday As String
			Try
				Dim objDataProc As DBQuery.DataProc
				Dim _id As Integer
				objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
				strToday = PSS.Data.Buisness.Generic.GetMySqlDateTime("%Y-%m-%d")
				strSQL = "INSERT INTO production.tpallett (" & _
				   "pallett_name, " & _
				   "pallett_shipdate, " & _
				   "pallett_bulkshipped, " & _
				   "pallett_readytoshipflg, " & _
				   "pallet_shiptype, " & _
				   "pallet_skulen, " & _
				   "pallet_invalid, " & _
				   "pallet_invalidusrid, " & _
				   "awpflag, " & _
				   "wo_id, " & _
				   "model_id, " & _
				   "cust_id, " & _
				   "pallet_timestamp, " & _
				   "dobflg, " & _
				   "pallett_senddt, " & _
				   "pallett_maxqty, " & _
				   "pallett_qty, " & _
				   "pallet_weight, " & _
				   "unitmeasurementcode, " & _
				   "order_seqno, " & _
				   "pallet_seqno, " & _
				   "pkslip_id, " & _
				   "loc_id, " & _
				   "specialinvproject, " & _
				   "pallettype_id, " & _
				   "aql_qcresult_id, " & _
				   "aql_lot_id, " & _
				   "whlocation, " & _
				   "disp_id, " & _
				   "pallet_qc_passed " & _
				  ") " & _
				  "VALUES ( " & _
				   ConvertBackToNullString(_pallett_name, True) & " , " & _
				   ConvertToMySQLDateOrNullString(_pallett_shipdate) & " , " & _
				   ConvertBoolToIntString(_pallett_bulkshipped) & " , " & _
				   ConvertBoolToIntString(_pallett_readytoshipflg) & " , " & _
				   _pallet_shiptype & " , " & _
				   "'" & _pallet_skulen & "' , " & _
				   _pallet_invalid & " , " & _
				   ConvertBackToNullString(_pallet_invalidusrid, False) & " , " & _
				   ConvertBoolToIntString(_awpflag) & " , " & _
				   _wo_id & " , " & _
				   _model_id & " , " & _
				   ConvertBackToNullString(_cust_id, False) & " , " & _
				   ConvertToMySQLDateOrNullString(_pallet_timestamp) & " , " & _
				   ConvertBoolToIntString(_dobflg) & " , " & _
				   ConvertToMySQLDateOrNullString(_pallett_senddt) & " , " & _
				   ConvertBackToNullString(_pallett_maxqty, False) & " , " & _
				   ConvertBackToNullString(_pallett_qty, False) & " , " & _
				   ConvertBackToNullString(_pallet_weight, False) & " , " & _
				   ConvertBackToNullString(_unitmeasurementcode, False) & " , " & _
				   _order_seqno & " , " & _
				   ConvertBackToNullString(_pallet_seqno, False) & " , " & _
				   ConvertBackToNullString(_pkslip_id, False) & " , " & _
				   _loc_id & " , " & _
				   ConvertBoolToIntString(_specialinvproject) & " , " & _
				   ConvertBackToNullString(_pallettype_id, False) & " , " & _
				   _aql_qcresult_id & " , " & _
				   _aql_lot_id & " , " & _
				  "'" & _whlocation & "' ,  " & _
				  ConvertBackToNullString(_disp_id, False) & ", " & _
				  _pallet_qc_passed.ToString() & " " & _
				   ")"
				_id = objDataProc.ExecuteScalarForInsert(strSQL, "production.tpallett")
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
				strSQL = "UPDATE production.tpallett SET " & _
				   "pallett_id = " & ConvertBackToNullString(_pallett_id, False) & ", " & _
				   "pallett_name = " & ConvertBackToNullString(_pallett_name, True) & ", " & _
				   "pallett_shipdate = " & ConvertToMySQLDateOrNullString(_pallett_shipdate) & ", " & _
				   "pallett_bulkshipped = " & IIf(_pallett_bulkshipped, "1", "0") & ", " & _
				   "pallett_readytoshipflg = " & IIf(_pallett_readytoshipflg, 1, 0) & ", " & _
				   "pallet_shiptype = " & ConvertBackToNullString(_pallet_shiptype, False) & ", " & _
				   "pallet_skulen = " & ConvertBackToNullString(_pallet_skulen, True) & ", " & _
				   "pallet_invalid = " & ConvertBackToNullString(_pallet_invalid, False) & ", " & _
				   "pallet_invalidusrid = " & ConvertBackToNullString(_pallet_invalidusrid, False) & ", " & _
				   "awpflag = " & IIf(_awpflag, "1", "0") & ", " & _
				   "wo_id = " & ConvertBackToNullString(_wo_id, False) & ", " & _
				   "model_id = " & ConvertBackToNullString(_model_id, False) & ", " & _
				   "cust_id = " & ConvertBackToNullString(_cust_id, False) & ", " & _
				   "pallet_timestamp = " & ConvertBackToNullString(_pallet_timestamp, True) & ", " & _
				   "dobflg = " & IIf(_dobflg, "1", "0") & ", " & _
				   "pallett_senddt = " & ConvertToMySQLDateOrNullString(_pallett_senddt) & ", " & _
				   "pallett_maxqty = " & ConvertBackToNullString(_pallett_maxqty, False) & ", " & _
				   "pallett_qty = " & ConvertBackToNullString(_pallett_qty, False) & ", " & _
				   "pallet_weight = " & ConvertBackToNullString(_pallet_weight, False) & ", " & _
				   "unitmeasurementcode = " & ConvertBackToNullString(_unitmeasurementcode, True) & ", " & _
				   "order_seqno = " & ConvertBackToNullString(_order_seqno, False) & ", " & _
				   "pallet_seqno = " & ConvertBackToNullString(_pallet_seqno, False) & ", " & _
				   "pkslip_id = " & ConvertBackToNullString(_pkslip_id, False) & ", " & _
				   "loc_id = " & ConvertBackToNullString(_loc_id, False) & ", " & _
				   "specialinvproject = " & IIf(_specialinvproject, 1, 0) & ", " & _
				   "pallettype_id = " & ConvertBackToNullString(_pallettype_id, False) & ", " & _
				   "aql_qcresult_id = " & ConvertBackToNullString(_aql_qcresult_id, False) & ", " & _
				   "aql_lot_id = " & ConvertBackToNullString(_aql_lot_id, False) & ", " & _
				   "whlocation = " & ConvertBackToNullString(_whlocation, True) & ", " & _
				   "disp_id = " & ConvertBackToNullString(_disp_id, False) & ", " & _
				   "pallet_qc_passed = " & _pallet_qc_passed.ToString() & " " & _
				  "WHERE Pallett_ID = " & Pallett_ID.ToString() & "; "
				Return objDataProc.ExecuteNonQuery(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Protected Function Delete() As Integer
			Dim strSQL As String
			Try
				Dim objDataProc As DBQuery.DataProc
				Dim _cnt As Integer
				objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
				strSQL = " DELETE FROM production.tpallett WHERE pallett_id = " & _pallett_id.ToString() & "; "
				_cnt = objDataProc.ExecuteNonQuery(strSQL)
				Return _cnt
			Catch ex As Exception
				Throw ex
				Return 0
			End Try
		End Function
#End Region
	End Class
	Public Class tpallettCollection
#Region "DECLARATIONS"

		Inherits Collections.ArrayList
		Private _objDataProc As DBQuery.DataProc
		Private _dt As New DataTable()
		Private _list As New ArrayList()

#End Region
#Region "CONSTRUCTORS"

		Public Sub New()
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData()
		End Sub

#End Region
#Region "PROPERTIES"

		Public ReadOnly Property tpallettDataTable() As DataTable
			Get
				Return _dt
			End Get
		End Property

#End Region
#Region "METHODS"

		Protected Sub GetData()
			Dim _sql As String = GetSelectStatement()
			_dt = _objDataProc.GetDataTable(_sql)
		End Sub

		Protected Function GetSelectStatement() As String
			Dim _sb As New StringBuilder()
			_sb.Append("SELECT ")
			_sb.Append("Pallett_ID, ")
			_sb.Append("Pallett_Name, ")
			_sb.Append("Pallett_ShipDate, ")
			_sb.Append("Pallett_BulkShipped, ")
			_sb.Append("Pallett_ReadyToShipFlg, ")
			_sb.Append("Pallet_ShipType, ")
			_sb.Append("Pallet_SkuLen, ")
			_sb.Append("Pallet_Invalid, ")
			_sb.Append("Pallet_InvalidUsrID, ")
			_sb.Append("AWPFlag, ")
			_sb.Append("WO_ID, ")
			_sb.Append("Model_ID, ")
			_sb.Append("Cust_ID, ")
			_sb.Append("pallet_TimeStamp, ")
			_sb.Append("DOBFlg, ")
			_sb.Append("Pallett_SendDt, ")
			_sb.Append("Pallett_MaxQty, ")
			_sb.Append("Pallett_QTY, ")
			_sb.Append("Pallet_Weight, ")
			_sb.Append("UnitMeasurementCode, ")
			_sb.Append("Order_SeqNo, ")
			_sb.Append("Pallet_SeqNo, ")
			_sb.Append("pkslip_ID, ")
			_sb.Append("Loc_ID, ")
			_sb.Append("SpecialInvProject, ")
			_sb.Append("PalletType_ID, ")
			_sb.Append("AQL_QCResult_ID, ")
			_sb.Append("AQL_Lot_ID, ")
			_sb.Append("WHLocation, ")
			_sb.Append("disp_id, ")
			_sb.Append("pallet_qc_passed ")
			_sb.Append("FROM production.tpallett; ")
			Return _sb.ToString()
		End Function

#End Region
	End Class
	Public Class tpallett_MaxNumber
#Region "DECLARATIONS"

		Private _objDataProc As DBQuery.DataProc
		Private _dt As New DataTable()
		Private _LastpallettNr As String = ""

#End Region
#Region "CONSTRUCTORS"

		Public Sub New(ByVal pallettPrefix As String)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(pallettPrefix)
		End Sub

#End Region
#Region "PROPERTIES"
		Public ReadOnly Property LastpallettNr() As String
			Get
				Return _LastpallettNr
			End Get
		End Property
		Public ReadOnly Property NextpallettNr() As String
			Get
				Dim _retVal As String
				Dim _prefix As String
				Dim _incr As String
				_prefix = Left(_LastpallettNr, 11)
				_incr = Data.BaseClasses.StringFunctions.PadZeros(4, (Right(_LastpallettNr, 4) + 1))
				_retVal = _prefix & _incr
				Return _retVal
			End Get
		End Property
#End Region
#Region "METHODS"
		Protected Sub GetData(ByVal pallettPrefix As String)
			Dim _sql As String = GetSelectStatement(pallettPrefix)
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				_LastpallettNr = _dt.Rows(0)("pallett_name").ToString()
			Else
				_LastpallettNr = pallettPrefix & "0000"
			End If
		End Sub
		Protected Function GetSelectStatement(ByVal pallettPrefix As String) As String
			Dim _sb As New StringBuilder()
			_sb.Append("SELECT DISTINCT ")
			_sb.Append("pallett_name ")
			_sb.Append("FROM production.tpallett ")
			_sb.Append("WHERE pallett_name like '" & pallettPrefix & "%' ")
			_sb.Append("UNION SELECT ALL ")
			_sb.Append("box_na as pallett_name ")
			_sb.Append("FROM warehouse.wh_box ")
			_sb.Append("WHERE box_na like '" & pallettPrefix & "%' ")
			_sb.Append("ORDER BY pallett_name DESC; ")
			Return _sb.ToString()
		End Function
#End Region
	End Class
	Public Class tpallettWrkStnCollection
#Region "DECLARATIONS"

		Inherits Collections.ArrayList
		Private _objDataProc As DBQuery.DataProc
		Private _dt As New DataTable()
		Private _list As New ArrayList()
		Private _loc_id As Integer = 0

#End Region
#Region "CONSTRUCTORS"

		Public Sub New(ByVal loc_id As Integer, ByVal pallet_name As String)
			_loc_id = loc_id
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(pallet_name)
		End Sub

#End Region
#Region "PROPERTIES"
		Public ReadOnly Property tPalletDevWrkstns() As DataTable
			Get
				Return _dt
			End Get
		End Property
#End Region
#Region "METHODS"

		Protected Sub GetData(ByVal pallet_name As String)
			Dim _sql As String = GetSelectStatement(pallet_name)
			_dt = _objDataProc.GetDataTable(_sql)
		End Sub

		Protected Function GetSelectStatement(ByVal pallet_name As String) As String
			Dim _sb As New StringBuilder()
			_sb.Append("SELECT Distinct C.WorkStation ")
			_sb.Append("FROM production.tpallett A ")
			_sb.Append("INNER JOIN production.tdevice B ON A.Pallett_ID = B.Pallett_ID ")
			_sb.Append("INNER JOIN production.tcellopt C ON B.Device_ID = C.Device_ID ")
			_sb.Append("WHERE A.Pallett_Name = '" & pallet_name & "' ")
			_sb.Append("AND Pallet_Invalid = 0 ")
			_sb.Append("AND B.loc_id = " & _loc_id.ToString() & "; ")
			Return _sb.ToString()
		End Function

#End Region
	End Class
End Namespace
