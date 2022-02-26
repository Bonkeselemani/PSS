Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic

Namespace BOL

	Public Class ttf_bx_phn_asn

#Region "DECLARATIONS"

		Private _bpasn_id As Integer = 0
		Private _pallet As String = ""
		Private _carton As String = ""
		Private _loc_desc As String = ""
		Private _sku As String = ""
		Private _make As String = ""
		Private _model As String = ""
		Private _serial_nr As String = ""
		Private _crt_ts As String
		Private _crt_user_id As Integer = 0
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

		Public Sub New(ByVal bpasn_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(bpasn_id)
			_isDirty = False
			_isNew = False
		End Sub

		Public Sub New(ByVal sn As String)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(sn)
			_isDirty = False
			_isNew = False
		End Sub

		Public Sub New(ByVal pallet As String, ByVal carton As String, ByVal sku As String, ByVal sn As String)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(pallet, carton, sku, sn)
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
		ByVal bpasn_id As Integer, _
		ByVal pallet As String, _
		ByVal carton As String, _
		ByVal loc_desc As String, _
		ByVal sku As String, _
		ByVal make As String, _
		ByVal model As String, _
		ByVal serial_nr As String _
		 )
			_bpasn_id = bpasn_id
			_pallet = pallet
			_carton = carton
			_loc_desc = loc_desc
			_sku = sku
			_make = make
			_model = model
			_serial_nr = serial_nr
		End Sub

#End Region
#Region "PROPERTIES"

		Public Property bpasn_id() As Integer
			Get
				Return _bpasn_id
			End Get
			Set(ByVal Value As Integer)
				_bpasn_id = value
				_isDirty = True
			End Set
		End Property
		Public Property pallet() As String
			Get
				Return _pallet
			End Get
			Set(ByVal Value As String)
				_pallet = value
				_isDirty = True
			End Set
		End Property
		Public Property carton() As String
			Get
				Return _carton
			End Get
			Set(ByVal Value As String)
				_carton = value
				_isDirty = True
			End Set
		End Property
		Public Property loc_desc() As String
			Get
				Return _loc_desc
			End Get
			Set(ByVal Value As String)
				_loc_desc = value
				_isDirty = True
			End Set
		End Property
		Public Property sku() As String
			Get
				Return _sku
			End Get
			Set(ByVal Value As String)
				_sku = value
				_isDirty = True
			End Set
		End Property
		Public Property make() As String
			Get
				Return _make
			End Get
			Set(ByVal Value As String)
				_make = value
				_isDirty = True
			End Set
		End Property
		Public Property model() As String
			Get
				Return _model
			End Get
			Set(ByVal Value As String)
				_model = value
				_isDirty = True
			End Set
		End Property
		Public Property serial_nr() As String
			Get
				Return _serial_nr
			End Get
			Set(ByVal Value As String)
				_serial_nr = value
				_isDirty = True
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
		Public Property crt_user_id() As Integer
			Get
				Return _crt_user_id
			End Get
			Set(ByVal Value As Integer)
				_crt_user_id = Value
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

		Protected Sub GetData(ByVal bpasn_id As Integer)
			Dim _sql As String = GetSelectStatement(bpasn_id)
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
		Protected Sub GetData(ByVal pallet As String, ByVal carton As String, ByVal sku As String, ByVal sn As String)
			Dim _sql As String = GetSelectStatement(pallet, carton, sku, sn)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Private Sub PopulateObject(ByVal _dr As DataRow)
			_bpasn_id = _dr("bpasn_id").ToString()
			_pallet = ConvertToSomething(_dr("pallet").ToString(), "")
			_carton = ConvertToSomething(_dr("carton").ToString(), "")
			_loc_desc = ConvertToSomething(_dr("loc_desc").ToString(), "")
			_sku = ConvertToSomething(_dr("sku").ToString(), "")
			_make = ConvertToSomething(_dr("make").ToString(), "")
			_model = ConvertToSomething(_dr("model").ToString(), "")
			_serial_nr = ConvertToSomething(_dr("serial_nr").ToString(), "")
			_crt_ts = ConvertToSomething(_dr("crt_ts").ToString(), "")
			_crt_user_id = ConvertToSomething(_dr("crt_user_id").ToString(), 0)
		End Sub
		Protected Function GetSelectStatement(ByVal bpasn_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "bpasn_id, "
			_sql += "pallet, "
			_sql += "carton, "
			_sql += "loc_desc, "
			_sql += "sku, "
			_sql += "make, "
			_sql += "model, "
			_sql += "serial_nr, "
			_sql += "crt_ts, "
			_sql += "crt_user_id "
			_sql += "FROM edi.ttf_bx_phn_asn "
			_sql += "WHERE bpasn_id = " & bpasn_id.ToString() & ""
			Return _sql
		End Function
		Protected Function GetSelectStatement(ByVal sn As String) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "bpasn_id, "
			_sql += "pallet, "
			_sql += "carton, "
			_sql += "loc_desc, "
			_sql += "sku, "
			_sql += "make, "
			_sql += "model, "
			_sql += "serial_nr, "
			_sql += "crt_ts, "
			_sql += "crt_user_id "
			_sql += "FROM edi.ttf_bx_phn_asn "
			_sql += "WHERE serial_nr = '" & sn & "'"
			Return _sql
		End Function
		Protected Function GetSelectStatement(ByVal pallet As String, ByVal carton As String, ByVal sku As String, ByVal sn As String) As String
			Dim _sb As New StringBuilder()
			_sb.Append("SELECT ")
			_sb.Append("bpasn_id, ")
			_sb.Append("pallet, ")
			_sb.Append("carton, ")
			_sb.Append("loc_desc, ")
			_sb.Append("sku, ")
			_sb.Append("make, ")
			_sb.Append("model, ")
			_sb.Append("serial_nr, ")
			_sb.Append("crt_ts, ")
			_sb.Append("crt_user_id ")
			_sb.Append("FROM edi.ttf_bx_phn_asn  ")
			_sb.Append("WHERE  ")
			_sb.Append("pallet = '" & pallet & "' AND ")
			If carton <> "" Then
				_sb.Append("carton = '" & carton & "' AND ")
			End If
			If sku <> "" Then
				_sb.Append("sku = '" & sku & "' AND ")
			End If
			If sn <> "" Then
				_sb.Append("serial_nr = '" & sn & "' AND ")
			End If
			_sb.Append("; ")
			_sb.Replace("AND ;", " LIMIT 1;")
			Return _sb.ToString()
		End Function
		Public Sub ApplyChanges()
			If _isNew Then
				_bpasn_id = Insert()
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
				strSQL = "INSERT INTO edi.ttf_bx_phn_asn (" & _
				   "pallet, " & _
				   "carton, " & _
				   "loc_desc, " & _
				   "sku, " & _
				   "make, " & _
				   "model, " & _
				   "serial_nr, " & _
				   "crt_user_id " & _
				  ") " & _
				  "VALUES ( " & _
				   ConvertBackToNullString(_pallet, True) & " , " & _
				   ConvertBackToNullString(_carton, True) & " , " & _
				   ConvertBackToNullString(_loc_desc, True) & " , " & _
				   ConvertBackToNullString(_sku, True) & " , " & _
				   ConvertBackToNullString(_make, True) & " , " & _
				   ConvertBackToNullString(_model, True) & " , " & _
				   ConvertBackToNullString(_serial_nr, True) & ",  " & _
				   ConvertBackToNullString(_crt_user_id, False) & "  " & _
				   ")"
				_id = objDataProc.ExecuteScalarForInsert(strSQL, "edi.ttf_bx_phn_asn")
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
				strSQL = "UPDATE edi.ttf_bx_phn_asn SET " & _
				   "bpasn_id = " & ConvertBackToNullString(_bpasn_id, False) & ", " & _
				   "pallet = " & ConvertBackToNullString(_pallet, False) & ", " & _
				   "carton = " & ConvertBackToNullString(_carton, False) & ", " & _
				   "loc_desc = " & ConvertBackToNullString(_loc_desc, False) & ", " & _
				   "sku = " & ConvertBackToNullString(_sku, False) & ", " & _
				   "make = " & ConvertBackToNullString(_make, False) & ", " & _
				   "model = " & ConvertBackToNullString(_model, False) & ", " & _
				   "serial_nr = " & ConvertBackToNullString(_serial_nr, False) & ", " & _
				   "crt_user_id = " & ConvertBackToNullString(_crt_user_id, False) & " " & _
				  ") " & _
				  "WHERE bpasn_id = " & bpasn_id.ToString() & "; "
				Return objDataProc.ExecuteNonQuery(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

#End Region

	End Class


	Public Class ttf_bx_phn_asnCollection
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

#End Region
#Region "PROPERTIES"

		Public ReadOnly Property ttf_bx_phn_asnDataTable() As DataTable
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

		Protected Function GetSelectStatement(ByVal pallet As String) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "bpasn_id, "
			_sql += "pallet, "
			_sql += "carton, "
			_sql += "loc_desc, "
			_sql += "sku, "
			_sql += "make, "
			_sql += "model, "
			_sql += "serial_nr, "
			_sql += "crt_ts, "
			_sql += "crt_user_id "
			_sql += "FROM edi.ttf_bx_phn_asn "
			_sql += "WHERE Pallet = '" & pallet.ToString() & "'"
			Return _sql
		End Function

#End Region
	End Class

End Namespace
