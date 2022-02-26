Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic
Namespace BOL
	Public Class ttf_bx_phn_received
#Region "DECLARATIONS"

		Private _bpr_id As Integer = 0
		Private _date_rec As String
		Private _pallet As String = ""
		Private _carton As String = ""
		Private _loc_desc As String = ""
		Private _sku As String = ""
		Private _make As String = ""
		Private _model As String = ""
		Private _serial_nr As String = ""
		Private _pallet_diff As Boolean = False
		Private _carton_diff As Boolean = False
		Private _sn_extra As Boolean = False
		Private _sku_diff As Boolean = False
		Private _comments As String = ""
		Private _crt_ts As String
		Private _crt_by As Integer = 0
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

		Public Sub New(ByVal bpr_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(bpr_id)
			_isDirty = False
			_isNew = False
		End Sub

		Public Sub New(ByVal sn As String)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(sn)
			_isDirty = False
			_isNew = False
		End Sub



#End Region
#Region "PROPERTIES"

		Public Property bpr_id() As Integer
			Get
				Return _bpr_id
			End Get
			Set(ByVal Value As Integer)
				_bpr_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property date_rec() As String
			Get
				Return _date_rec
			End Get
			Set(ByVal Value As String)
				_date_rec = Value
				_isDirty = True
			End Set
		End Property
		Public Property pallet() As String
			Get
				Return _pallet
			End Get
			Set(ByVal Value As String)
				_pallet = Value
				_isDirty = True
			End Set
		End Property
		Public Property carton() As String
			Get
				Return _carton
			End Get
			Set(ByVal Value As String)
				_carton = Value
				_isDirty = True
			End Set
		End Property
		Public Property loc_desc() As String
			Get
				Return _loc_desc
			End Get
			Set(ByVal Value As String)
				_loc_desc = Value
				_isDirty = True
			End Set
		End Property
		Public Property sku() As String
			Get
				Return _sku
			End Get
			Set(ByVal Value As String)
				_sku = Value
				_isDirty = True
			End Set
		End Property
		Public Property make() As String
			Get
				Return _make
			End Get
			Set(ByVal Value As String)
				_make = Value
				_isDirty = True
			End Set
		End Property
		Public Property model() As String
			Get
				Return _model
			End Get
			Set(ByVal Value As String)
				_model = Value
				_isDirty = True
			End Set
		End Property
		Public Property serial_nr() As String
			Get
				Return _serial_nr
			End Get
			Set(ByVal Value As String)
				_serial_nr = Value
				_isDirty = True
			End Set
		End Property
		Public Property pallet_diff() As Boolean
			Get
				Return _pallet_diff
			End Get
			Set(ByVal Value As Boolean)
				_pallet_diff = Value
				_isDirty = True
			End Set
		End Property
		Public Property carton_diff() As Boolean
			Get
				Return _carton_diff
			End Get
			Set(ByVal Value As Boolean)
				_carton_diff = Value
				_isDirty = True
			End Set
		End Property
		Public Property sn_extra() As Boolean
			Get
				Return _sn_extra
			End Get
			Set(ByVal Value As Boolean)
				_sn_extra = Value
				_isDirty = True
			End Set
		End Property
		Public Property sku_diff() As Boolean
			Get
				Return _sku_diff
			End Get
			Set(ByVal Value As Boolean)
				_sku_diff = Value
				_isDirty = True
			End Set
		End Property
		Public Property comments() As String
			Get
				Return _comments
			End Get
			Set(ByVal Value As String)
				_comments = Value
			End Set
		End Property
		Public Property crt_ts() As String
			Get
				Return _crt_ts
			End Get
			Set(ByVal Value As String)
				_crt_ts = Value
				_isDirty = True
			End Set
		End Property
		Public Property crt_by() As Integer
			Get
				Return _crt_by
			End Get
			Set(ByVal Value As Integer)
				_crt_by = Value
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

		Protected Sub GetData(ByVal bpr_id As Integer)
			Dim _sql As String = GetSelectStatement(bpr_id)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub


		Protected Sub GetData(ByVal sn As String)
			Dim _sql As String = GetSelectStatement(sn)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Private Sub PopulateObject(ByVal _dr As DataRow)

			_bpr_id = _dr("bpr_id").ToString()
			_date_rec = ConvertToSomething(_dr("date_rec").ToString(), "")
			_pallet = ConvertToSomething(_dr("pallet").ToString(), "")
			_carton = ConvertToSomething(_dr("carton").ToString(), "")
			_loc_desc = ConvertToSomething(_dr("loc_desc").ToString(), "")
			_sku = ConvertToSomething(_dr("sku").ToString(), "")
			_make = ConvertToSomething(_dr("make").ToString(), "")
			_model = ConvertToSomething(_dr("model").ToString(), "")
			_serial_nr = ConvertToSomething(_dr("serial_nr").ToString(), "")
			_pallet_diff = IIf(_dr("pallet_diff") = 1, True, False)
			_carton_diff = IIf(_dr("carton_diff") = 1, True, False)
			_sn_extra = IIf(_dr("sn_extra") = 1, True, False)
			_sku_diff = IIf(_dr("sku_diff") = 1, True, False)
			_comments = ConvertToSomething(_dr("comments").ToString(), "")
			_crt_ts = ConvertToSomething(_dr("crt_ts").ToString(), "")
			_crt_by = _dr("crt_by").ToString()
		End Sub

		Protected Function GetSelectStatement(ByVal bpr_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "bpr_id, "
			_sql += "date_rec, "
			_sql += "pallet, "
			_sql += "carton, "
			_sql += "loc_desc, "
			_sql += "sku, "
			_sql += "make, "
			_sql += "model, "
			_sql += "serial_nr, "
			_sql += "pallet_diff, "
			_sql += "carton_diff, "
			_sql += "sn_extra, "
			_sql += "sku_diff, "
			_sql += "comments, "
			_sql += "crt_ts, "
			_sql += "crt_by "
			_sql += "FROM production.ttf_bx_phn_received "
			_sql += "WHERE bpr_id = " & bpr_id.ToString() & ""
			Return _sql
		End Function

		Protected Function GetSelectStatement(ByVal sn As String) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "bpr_id, "
			_sql += "date_rec, "
			_sql += "pallet, "
			_sql += "carton, "
			_sql += "loc_desc, "
			_sql += "sku, "
			_sql += "make, "
			_sql += "model, "
			_sql += "serial_nr, "
			_sql += "pallet_diff, "
			_sql += "carton_diff, "
			_sql += "sn_extra, "
			_sql += "sku_diff, "
			_sql += "comments, "
			_sql += "crt_ts, "
			_sql += "crt_by "
			_sql += "FROM production.ttf_bx_phn_received "
			_sql += "WHERE serial_nr = '" & sn & "' "
			Return _sql
		End Function

		Public Sub ApplyChanges()
			If _isNew Then
				_bpr_id = Insert()
			ElseIf IsDeleted Then
				' delete
			ElseIf IsDirty Then
				' Update
			End If
		End Sub

		Protected Function Insert() As Integer
			Dim strSQL, strToday As String
			Try
				Dim _objDataProc As DBQuery.DataProc
				Dim _id As Integer
				_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
				strToday = PSS.Data.Buisness.Generic.GetMySqlDateTime("%Y-%m-%d")
				strSQL = "INSERT INTO production.ttf_bx_phn_received (" & _
				   "date_rec, " & _
				   "pallet, " & _
				   "carton, " & _
				   "loc_desc, " & _
				   "sku, " & _
				   "make, " & _
				   "model, " & _
				   "serial_nr, " & _
				   "pallet_diff, " & _
				   "carton_diff, " & _
				   "sn_extra, " & _
				   "sku_diff, " & _
				   "comments, " & _
				   "crt_by " & _
				  ") " & _
				  "VALUES ( " & _
				   ConvertToMySQLDateOrNullString(_date_rec) & " , " & _
				   "'" & _pallet & "' , " & _
				   "'" & _carton & "' , " & _
				   "'" & _loc_desc & "' , " & _
				   "'" & _sku & "' , " & _
				   "'" & _make & "' , " & _
				   "'" & _model & "' , " & _
				   "'" & _serial_nr & "' , " & _
				   IIf(_pallet_diff, "1", "0") & " , " & _
				   IIf(_carton_diff, "1", "0") & " , " & _
				   IIf(_sn_extra, "1", "0") & " , " & _
				   IIf(_sku_diff, "1", "0") & " , " & _
				   "'" & comments & "', " & _
				   "'" & _crt_by & "'  " & _
				   ")"
				_id = _objDataProc.ExecuteScalarForInsert(strSQL, "ttf_bx_phn_received")
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
				strSQL = "UPDATE production.ttf_bx_phn_received SET " & _
				   "bpr_id = " & ConvertBackToNullString(_bpr_id, False) & ", " & _
				   "date_rec = " & ConvertBackToNullString(_date_rec, False) & ", " & _
				   "pallet = " & ConvertBackToNullString(_pallet, False) & ", " & _
				   "carton = " & ConvertBackToNullString(_carton, False) & ", " & _
				   "loc_desc = " & ConvertBackToNullString(_loc_desc, False) & ", " & _
				   "sku = " & ConvertBackToNullString(_sku, False) & ", " & _
				   "make = " & ConvertBackToNullString(_make, False) & ", " & _
				   "model = " & ConvertBackToNullString(_model, False) & ", " & _
				   "serial_nr = " & ConvertBackToNullString(_serial_nr, False) & ", " & _
				   "pallet_diff = " & ConvertBackToNullString(_pallet_diff, False) & ", " & _
				   "carton_diff = " & ConvertBackToNullString(_carton_diff, False) & ", " & _
				   "sn_extra = " & ConvertBackToNullString(_sn_extra, False) & ", " & _
				   "sku_diff = " & ConvertBackToNullString(_sku_diff, False) & ", " & _
				   "comments = " & ConvertBackToNullString(_comments, False) & ", " & _
				   "crt_ts = " & ConvertBackToNullString(_crt_ts, False) & ", " & _
				   "crt_by = " & ConvertBackToNullString(_crt_by, False) & ", " & _
				  ") " & _
				  "WHERE bpr_id = " & bpr_id.ToString() & "; "
				Return objDataProc.ExecuteNonQuery(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

#End Region
	End Class
	Public Class ttf_bx_phn_receivedCollection
#Region "DECLARATIONS"

		Inherits Collections.ArrayList
		Private _objDataProc As DBQuery.DataProc
		Private _dt As New DataTable()
		Private _list As New ArrayList()

#End Region
#Region "CONSTRUCTORS"

		Public Sub New(ByVal pallet As String)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(pallet)
		End Sub

		Public Sub New(ByVal pallet As String, ByVal carton As String)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(pallet, carton)
		End Sub

#End Region
#Region "PROPERTIES"

		Public ReadOnly Property ttf_bx_phn_receivedDataTable() As DataTable
			Get
				Return _dt
			End Get
		End Property

#End Region
#Region "METHODS"

		Protected Sub GetData(ByVal pallet As String)
			Dim _sql As String = GetSelectStatement(pallet)
			_dt = _objDataProc.GetDataTable(_sql)
		End Sub

		Protected Sub GetData(ByVal pallet As String, ByVal carton As String)
			Dim _sql As String = GetSelectStatement(pallet, carton)
			_dt = _objDataProc.GetDataTable(_sql)
		End Sub

		Protected Function GetSelectStatement(ByVal pallet As String) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "bpr_id, "
			_sql += "date_rec, "
			_sql += "pallet, "
			_sql += "carton, "
			_sql += "loc_desc, "
			_sql += "sku, "
			_sql += "make, "
			_sql += "model, "
			_sql += "serial_nr, "
			_sql += "pallet_diff, "
			_sql += "carton_diff, "
			_sql += "sn_extra, "
			_sql += "sku_diff, "
			_sql += "comments, "
			_sql += "crt_ts, "
			_sql += "crt_by "
			_sql += "FROM production.ttf_bx_phn_received "
			_sql += "WHERE pallet = '" & pallet & "'; "
			Return _sql
		End Function

		Protected Function GetSelectStatement(ByVal pallet As String, ByVal carton As String) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "bpr_id, "
			_sql += "date_rec, "
			_sql += "pallet, "
			_sql += "carton, "
			_sql += "loc_desc, "
			_sql += "sku, "
			_sql += "make, "
			_sql += "model, "
			_sql += "serial_nr, "
			_sql += "pallet_diff, "
			_sql += "carton_diff, "
			_sql += "sn_extra, "
			_sql += "sku_diff, "
			_sql += "comments, "
			_sql += "crt_ts, "
			_sql += "crt_by "
			_sql += "FROM production.ttf_bx_phn_received "
			_sql += "WHERE pallet = '" & pallet & "'"
			_sql += "AND carton = '" & carton & "'; "
			Return _sql
		End Function

#End Region
	End Class
End Namespace
