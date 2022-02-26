Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic

Namespace BOL

	Public Class tcust_order

#Region "DECLARATIONS"

		Private _co_id As Integer = 0
		Private _cust_id As Integer = 0
		Private _loc_id As Integer = 0
		Private _wo_id As Integer = 0
		Private _co_nr As String = ""
		Private _full_na As String = ""
		Private _first_na As String = ""
		Private _middle_na As String = ""
		Private _last_na As String = ""
		Private _addr1 As String = ""
		Private _addr2 As String = ""
		Private _city As String = ""
		Private _state_id As Integer = 0
		Private _postal_cd As String = ""
		Private _country_id As Integer = 0
		Private _phone As String = ""
		Private _email As String = ""
		Private _date_rec As String
		Private _date_to_fill As String
		Private _date_ship As String
		Private _exception_type_id As Integer = 0
		Private _crt_ts As String
		Private _crt_by_id As Integer = 0
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
		Public Sub New(ByVal co_nr As String)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(co_nr)
			_isDirty = False
			_isNew = False
		End Sub

#End Region
#Region "PROPERTIES"

		Public Property co_id() As Integer
			Get
				Return _co_id
			End Get
			Set(ByVal Value As Integer)
				_co_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property cust_id() As Integer
			Get
				Return _cust_id
			End Get
			Set(ByVal Value As Integer)
				_cust_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property loc_id() As Integer
			Get
				Return _loc_id
			End Get
			Set(ByVal Value As Integer)
				_loc_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property wo_id() As Integer
			Get
				Return _wo_id
			End Get
			Set(ByVal Value As Integer)
				_wo_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property co_nr() As String
			Get
				Return _co_nr
			End Get
			Set(ByVal Value As String)
				_co_nr = Value
				_isDirty = True
			End Set
		End Property
		Public Property full_na() As String
			Get
				Return _full_na
			End Get
			Set(ByVal Value As String)
				_full_na = Value
				_isDirty = True
			End Set
		End Property
		Public Property first_na() As String
			Get
				Return _first_na
			End Get
			Set(ByVal Value As String)
				_first_na = Value
				_isDirty = True
			End Set
		End Property
		Public Property middle_na() As String
			Get
				Return _middle_na
			End Get
			Set(ByVal Value As String)
				_middle_na = Value
				_isDirty = True
			End Set
		End Property
		Public Property last_na() As String
			Get
				Return _last_na
			End Get
			Set(ByVal Value As String)
				_last_na = Value
				_isDirty = True
			End Set
		End Property
		Public Property addr1() As String
			Get
				Return _addr1
			End Get
			Set(ByVal Value As String)
				_addr1 = Value
				_isDirty = True
			End Set
		End Property
		Public Property addr2() As String
			Get
				Return _addr2
			End Get
			Set(ByVal Value As String)
				_addr2 = Value
				_isDirty = True
			End Set
		End Property
		Public Property city() As String
			Get
				Return _city
			End Get
			Set(ByVal Value As String)
				_city = Value
				_isDirty = True
			End Set
		End Property
		Public Property state_id() As Integer
			Get
				Return _state_id
			End Get
			Set(ByVal Value As Integer)
				_state_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property postal_cd() As String
			Get
				Return _postal_cd
			End Get
			Set(ByVal Value As String)
				_postal_cd = Value
				_isDirty = True
			End Set
		End Property
		Public Property country_id() As Integer
			Get
				Return _country_id
			End Get
			Set(ByVal Value As Integer)
				_country_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property phone() As String
			Get
				Return _phone
			End Get
			Set(ByVal Value As String)
				_phone = Value
				_isDirty = True
			End Set
		End Property
		Public Property email() As String
			Get
				Return _email
			End Get
			Set(ByVal Value As String)
				_email = Value
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
		Public Property date_to_fill() As String
			Get
				Return _date_to_fill
			End Get
			Set(ByVal Value As String)
				_date_to_fill = Value
				_isDirty = True
			End Set
		End Property
		Public Property date_ship() As String
			Get
				Return _date_ship
			End Get
			Set(ByVal Value As String)
				_date_ship = Value
				_isDirty = True
			End Set
		End Property
		Public Property exception_type_id() As Integer
			Get
				Return _exception_type_id
			End Get
			Set(ByVal Value As Integer)
				_exception_type_id = Value
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
		Public Property crt_by_id() As Integer
			Get
				Return _crt_by_id
			End Get
			Set(ByVal Value As Integer)
				_crt_by_id = Value
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
		Protected Sub GetData(ByVal co_nr As String)
			Dim _sql As String = GetSelectStatement(co_nr)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Private Sub PopulateObject(ByVal _dr As DataRow)
			_co_id = ConvertToSomething(_dr("co_id"), 0)
			_cust_id = ConvertToSomething(_dr("cust_id"), 0)
			_loc_id = ConvertToSomething(_dr("loc_id"), 0)
			_wo_id = ConvertToSomething(_dr("wo_id"), 0)
			_co_nr = _dr("co_nr").ToString()
			_full_na = _dr("full_na").ToString()
			_first_na = _dr("first_na").ToString()
			_middle_na = _dr("middle_na").ToString()
			_last_na = _dr("last_na").ToString()
			_addr1 = _dr("addr1").ToString()
			_addr2 = _dr("addr2").ToString()
			_city = _dr("city").ToString()
			_state_id = ConvertToSomething(_dr("state_id"), 0)
			_postal_cd = _dr("postal_cd").ToString()
			_country_id = ConvertToSomething(_dr("country_id"), 0)
			_phone = _dr("phone").ToString()
			_email = _dr("email").ToString()
			_date_rec = _dr("date_rec").ToString()
			_date_to_fill = _dr("date_to_fill").ToString()
			_date_ship = _dr("date_ship").ToString()
			_exception_type_id = _dr("exception_type_id")
			_crt_ts = _dr("crt_ts").ToString()
			_crt_by_id = ConvertToSomething(_dr("crt_by_id"), 0)
		End Sub
		Protected Function GetSelectStatement(ByVal ID As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "co_id, "
			_sql += "cust_id, "
			_sql += "loc_id, "
			_sql += "wo_id, "
			_sql += "co_nr, "
			_sql += "full_na, "
			_sql += "first_na, "
			_sql += "middle_na, "
			_sql += "last_na, "
			_sql += "addr1, "
			_sql += "addr2, "
			_sql += "city, "
			_sql += "state_id, "
			_sql += "postal_cd, "
			_sql += "country_id, "
			_sql += "phone, "
			_sql += "email, "
			_sql += "date_rec, "
			_sql += "date_to_fill, "
			_sql += "date_ship, "
			_sql += "exception_type_id, "
			_sql += "crt_ts, "
			_sql += "crt_by_id "
			_sql += "FROM edi.tcust_order "
			_sql += "WHERE co_id = " & ID.ToString() & ""
			Return _sql
		End Function
		Protected Function GetSelectStatement(ByVal co_nr As String) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "co_id, "
			_sql += "cust_id, "
			_sql += "loc_id, "
			_sql += "wo_id, "
			_sql += "co_nr, "
			_sql += "full_na, "
			_sql += "first_na, "
			_sql += "middle_na, "
			_sql += "last_na, "
			_sql += "addr1, "
			_sql += "addr2, "
			_sql += "city, "
			_sql += "state_id, "
			_sql += "postal_cd, "
			_sql += "country_id, "
			_sql += "phone, "
			_sql += "email, "
			_sql += "date_rec, "
			_sql += "date_to_fill, "
			_sql += "date_ship, "
			_sql += "exception_type_id, "
			_sql += "crt_ts, "
			_sql += "crt_by_id "
			_sql += "FROM edi.tcust_order "
			_sql += "WHERE co_nr = '" & co_nr & "'; "
			Return _sql
		End Function
		Public Sub ApplyChanges()
			If _isNew Then
				_co_id = Insert()
			ElseIf IsDeleted Then
				' delete
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
				strSQL = "INSERT INTO edi.tcust_order (" & _
				   "co_id, " & _
				   "cust_id, " & _
				   "loc_id, " & _
				   "wo_id, " & _
				   "co_nr, " & _
				   "full_na, " & _
				   "first_na, " & _
				   "middle_na, " & _
				   "last_na, " & _
				   "addr1, " & _
				   "addr2, " & _
				   "city, " & _
				   "state_id, " & _
				   "postal_cd, " & _
				   "country_id, " & _
				   "phone, " & _
				   "email, " & _
				   "date_rec, " & _
				   "date_to_fill, " & _
				   "date_ship, " & _
				   "exception_type_id, " & _
				   "crt_ts, " & _
				   "crt_by_id " & _
				  ") " & _
				  "VALUES ( " & _
				   _co_id.ToString() & "," & _
				   _cust_id.ToString() & "," & _
				   _loc_id.ToString() & "," & _
				   _wo_id.ToString() & "," & _
				   _co_nr.ToString() & "," & _
				   _full_na.ToString() & "," & _
				   _first_na.ToString() & "," & _
				   _middle_na.ToString() & "," & _
				   _last_na.ToString() & "," & _
				   _addr1.ToString() & "," & _
				   _addr2.ToString() & "," & _
				   _city.ToString() & "," & _
				   _state_id.ToString() & "," & _
				   _postal_cd.ToString() & "," & _
				   _country_id.ToString() & "," & _
				   _phone.ToString() & "," & _
				   _email.ToString() & "," & _
				   _date_rec.ToString() & "," & _
				   _date_to_fill.ToString() & "," & _
				   _date_ship.ToString() & "," & _
				   _exception_type_id.ToString() & "," & _
				   _crt_ts.ToString() & "," & _
				   _crt_by_id.ToString() & _
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
				strSQL = "UPDATE edi.tcust_order SET " & _
				   "cust_id = " & ConvertBackToNullString(_cust_id, False) & ", " & _
				   "loc_id = " & ConvertBackToNullString(_loc_id, False) & ", " & _
				   "wo_id = " & ConvertBackToNullString(_wo_id, False) & ", " & _
				   "co_nr = " & ConvertBackToNullString(_co_nr, True) & ", " & _
				   "full_na = " & ConvertBackToNullString(_full_na, True) & ", " & _
				   "first_na = " & ConvertBackToNullString(_first_na, True) & ", " & _
				   "middle_na = " & ConvertBackToNullString(_middle_na, True) & ", " & _
				   "last_na = " & ConvertBackToNullString(_last_na, True) & ", " & _
				   "addr1 = " & ConvertBackToNullString(_addr1, True) & ", " & _
				   "addr2 = " & ConvertBackToNullString(_addr2, True) & ", " & _
				   "city = " & ConvertBackToNullString(_city, True) & ", " & _
				   "state_id = " & ConvertBackToNullString(_state_id, False) & ", " & _
				   "postal_cd = " & ConvertBackToNullString(_postal_cd, True) & ", " & _
				   "country_id = " & ConvertBackToNullString(_country_id, False) & ", " & _
				   "phone = " & ConvertBackToNullString(_phone, True) & ", " & _
				   "email = " & ConvertBackToNullString(_email, True) & ", " & _
				   "date_rec = " & ConvertToMySQLDateOrNullString(_date_rec) & ", " & _
				   "date_to_fill = " & ConvertToMySQLDateOrNullString(_date_to_fill) & ", " & _
				   "date_ship = " & ConvertToMySQLDateOrNullString(_date_ship) & ", " & _
				   "exception_type_id = " & ConvertBackToNullString(_exception_type_id, False) & " " & _
				  "WHERE co_id = " & co_id.ToString() & "; "
				Return objDataProc.ExecuteNonQuery(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

#End Region

	End Class


	Public Class tcust_orderCollection
#Region "DECLARATIONS"

		Inherits Collections.ArrayList
		Private _objDataProc As DBQuery.DataProc
		Private _dt As New DataTable()
		Private _list As New ArrayList()

#End Region
#Region "CONSTRUCTORS"

		Public Sub New(ByVal loc_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(loc_id)
		End Sub

		Public Sub New(ByVal loc_id As Integer, ByVal start_date As Date, ByVal end_date As Date)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(loc_id, start_date, end_date)
		End Sub





#End Region
#Region "PROPERTIES"

		Public ReadOnly Property tcust_orderDataTable() As DataTable
			Get
				Return _dt
			End Get
		End Property

#End Region
#Region "METHODS"

		Protected Sub GetData(ByVal loc_id As Integer)
			Dim _sql As String = GetSelectStatement(loc_id)
			_dt = _objDataProc.GetDataTable(_sql)
		End Sub

		Protected Sub GetData(ByVal loc_id As Integer, ByVal start_date As Date, ByVal end_date As Date)
			Dim _sql As String = GetSelectStatement(loc_id, start_date, end_date)
			_dt = _objDataProc.GetDataTable(_sql)
		End Sub

		Protected Function GetSelectStatement(ByVal loc_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "co_id, "
			_sql += "cust_id, "
			_sql += "loc_id, "
			_sql += "wo_id, "
			_sql += "co_nr, "
			_sql += "full_na, "
			_sql += "first_na, "
			_sql += "middle_na, "
			_sql += "last_na, "
			_sql += "addr1, "
			_sql += "addr2, "
			_sql += "city, "
			_sql += "state_id, "
			_sql += "postal_cd, "
			_sql += "country_id, "
			_sql += "phone, "
			_sql += "email, "
			_sql += "date_rec, "
			_sql += "date_to_fill, "
			_sql += "date_ship, "
			_sql += "exception_type_id, "
			_sql += "crt_ts, "
			_sql += "crt_by_id "
			_sql += "FROM edi.tcust_order "
			_sql += "WHERE loc_id = " & loc_id.ToString() & ""
			Return _sql
		End Function

		Protected Function GetSelectStatement(ByVal loc_id As Integer, ByVal start_date As Date, ByVal end_date As Date) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "co_id, "
			_sql += "cust_id, "
			_sql += "loc_id, "
			_sql += "wo_id, "
			_sql += "co_nr, "
			_sql += "full_na, "
			_sql += "first_na, "
			_sql += "middle_na, "
			_sql += "last_na, "
			_sql += "addr1, "
			_sql += "addr2, "
			_sql += "city, "
			_sql += "state_id, "
			_sql += "postal_cd, "
			_sql += "country_id, "
			_sql += "phone, "
			_sql += "email, "
			_sql += "date_rec, "
			_sql += "date_to_fill, "
			_sql += "date_ship, "
			_sql += "exception_type_id, "
			_sql += "crt_ts, "
			_sql += "crt_by_id "
			_sql += "FROM edi.tcust_order "
			_sql += "WHERE loc_id = " & loc_id.ToString() & " "
			_sql += " AND "
			_sql += "date_rec BETWEEN "
			_sql += ConvertToMySQLDateOrNullString(start_date)
			_sql += " AND "
			_sql += ConvertToMySQLDateOrNullString(end_date)
			_sql += " ORDER BY co_nr; "
			Return _sql
		End Function

#End Region
	End Class

End Namespace
