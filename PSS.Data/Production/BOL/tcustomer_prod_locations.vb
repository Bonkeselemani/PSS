Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic
Namespace BOL
	Public Class tcustomer_prod_locations
#Region "DECLARATIONS"
		Private _cpl_id As Integer = 0
		Private _cust_id As Integer = 0
		Private _prod_id As Integer = 0
		Private _loc_na As String = ""
		Private _allow_bin As Boolean = False
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
		Public Sub New(ByVal cpl_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(cpl_id)
			_isDirty = False
			_isNew = False
		End Sub
#End Region
#Region "PROPERTIES"
		Public Property cpl_id() As Integer
			Get
				Return _cpl_id
			End Get
			Set(ByVal Value As Integer)
				_cpl_id = Value
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
		Public Property prod_id() As Integer
			Get
				Return _prod_id
			End Get
			Set(ByVal Value As Integer)
				_prod_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property loc_na() As String
			Get
				Return _loc_na
			End Get
			Set(ByVal Value As String)
				_loc_na = Value
				_isDirty = True
			End Set
		End Property
		Public Property allow_bin() As Boolean
			Get
				Return _allow_bin
			End Get
			Set(ByVal Value As Boolean)
				_allow_bin = Value
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
		Protected Sub GetData(ByVal _cpl_id As Integer)
			Dim _sql As String = GetSelectStatement(_cpl_id)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Private Sub PopulateObject(ByVal _dr As DataRow)
			_cpl_id = ConvertToSomething(_dr("cpl_id"), 0)
			_cust_id = ConvertToSomething(_dr("cust_id"), 0)
			_prod_id = ConvertToSomething(_dr("prod_id"), 0)
			_loc_na = ConvertToSomething(_dr("loc_na").ToString(), "")
			_allow_bin = IIf(_dr("allow_bin") = 1, True, False)
			_crt_ts = ConvertToSomething(_dr("crt_ts").ToString(), "")
			_crt_user_id = ConvertToSomething(_dr("crt_user_id"), 0)
		End Sub
		Protected Function GetSelectStatement(ByVal cpl_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "cpl_id, "
			_sql += "cust_id, "
			_sql += "prod_id, "
			_sql += "loc_na, "
			_sql += "allow_bin, "
			_sql += "crt_ts, "
			_sql += "crt_user_id "
			_sql += "FROM production.tcustomer_prod_locations "
			_sql += "WHERE cpl_id = " & cpl_id.ToString() & ""
			Return _sql
		End Function
		Public Sub ApplyChanges()
			If _isNew Then
				_cpl_id = Insert()
			ElseIf IsDeleted Then
				Throw New Exception("Delete not allowed on this table.")
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
				strSQL = "INSERT INTO production.tcustomer_prod_locations (" & _
				   "cust_id, " & _
				   "prod_id, " & _
				   "loc_na, " & _
				   "allow_bin, " & _
				   "crt_user_id " & _
				  ") " & _
				  "VALUES ( " & _
				   _cust_id & " , " & _
				   _prod_id & " , " & _
				   _loc_na & " , " & _
				   IIf(_allow_bin, "1", "0") & " , " & _
				   _crt_user_id & "  " & _
				   ")"
				_id = objDataProc.ExecuteScalarForInsert(strSQL, "production.tcustomer_prod_locations")
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
				strSQL = "UPDATE production.tcustomer_prod_locations SET " & _
				   "cpl_id = " & ConvertBackToNullString(_cpl_id, False) & ", " & _
				   "loc_na = " & ConvertBackToNullString(_loc_na, True) & ", " & _
				   "allow_bin = " & IIf(allow_bin, 1, 0) & " " & _
				  "WHERE cpl_id = " & cpl_id.ToString() & "; "
				Return objDataProc.ExecuteNonQuery(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Function
#End Region
	End Class
	Public Class tcustomer_prod_locationsCollection
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
		Public Sub New(ByVal cust_id As Integer, ByVal prod_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData()
		End Sub
#End Region
#Region "PROPERTIES"
		Public ReadOnly Property tcustomer_prod_locationsDataTable() As DataTable
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
			_sb.Append("cpl.cpl_id, ")
			_sb.Append("c.cust_name1, ")
			_sb.Append("p.prod_desc, ")
			_sb.Append("cpl.loc_na, ")
			_sb.Append("cpl.crt_ts, ")
			_sb.Append("cpl.crt_user_id ")
			_sb.Append("FROM production.tcustomer_prod_locations cpl ")
			_sb.Append("INNER JOIN production.tcustomer c ON cpl.cust_id = c.cust_id ")
			_sb.Append("INNER JOIN production.lproduct p ON cpl.prod_id = p.prod_id ")
			_sb.Append("ORDER BY cpl.loc_na; ")
			Return _sb.ToString()
		End Function
		Protected Sub GetData(ByVal cust_id As Integer, ByVal prod_id As Integer)
			Dim _sql As String = GetSelectStatement(cust_id, prod_id)
			_dt = _objDataProc.GetDataTable(_sql)
		End Sub
		Protected Function GetSelectStatement(ByVal cust_id As Integer, ByVal prod_id As Integer) As String
			Dim _sb As New StringBuilder()
			_sb.Append("SELECT ")
			_sb.Append("cpl_id, ")
			_sb.Append("cust_id, ")
			_sb.Append("prod_id, ")
			_sb.Append("loc_na, ")
			_sb.Append("crt_ts, ")
			_sb.Append("crt_user_id ")
			_sb.Append("FROM production.tcustomer_prod_locations ")
			_sb.Append("WHERE cust_id = " & cust_id.ToString() & " ")
			_sb.Append("AND prod_id = " & prod_id.ToString() & " ")
			_sb.Append("ORDER BY loc_na ")
			Return _sb.ToString()
		End Function
#End Region
	End Class

	Public Class tcustomer_prod_BinlocationsCollection
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
		Public Sub New(ByVal cust_id As Integer, ByVal prod_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData()
		End Sub
#End Region
#Region "PROPERTIES"
		Public ReadOnly Property BinlocationsDataTable() As DataTable
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
			_sb.Append("cpl.cpl_id, ")
			_sb.Append("c.cust_name1, ")
			_sb.Append("p.prod_desc, ")
			_sb.Append("cpl.loc_na, ")
			_sb.Append("cpl.crt_ts, ")
			_sb.Append("cpl.crt_user_id ")
			_sb.Append("FROM production.tcustomer_prod_locations cpl ")
			_sb.Append("INNER JOIN production.tcustomer c ON cpl.cust_id = c.cust_id ")
			_sb.Append("INNER JOIN production.lproduct p ON cpl.prod_id = p.prod_id ")
			_sb.Append("WHERE cpl.allow_bin = 1 ")
			_sb.Append("ORDER BY cpl.loc_na; ")
			Return _sb.ToString()
		End Function
		Protected Sub GetData(ByVal cust_id As Integer, ByVal prod_id As Integer)
			Dim _sql As String = GetSelectStatement(cust_id, prod_id)
			_dt = _objDataProc.GetDataTable(_sql)
		End Sub
		Protected Function GetSelectStatement(ByVal cust_id As Integer, ByVal prod_id As Integer) As String
			Dim _sb As New StringBuilder()
			_sb.Append("SELECT ")
			_sb.Append("cpl_id, ")
			_sb.Append("cust_id, ")
			_sb.Append("prod_id, ")
			_sb.Append("loc_na, ")
			_sb.Append("crt_ts, ")
			_sb.Append("crt_user_id ")
			_sb.Append("FROM production.tcustomer_prod_locations ")
			_sb.Append("WHERE cust_id = " & cust_id.ToString() & " ")
			_sb.Append("AND prod_id = " & prod_id.ToString() & " ")
			_sb.Append("AND cpl.allow_bin = 1 ")
			_sb.Append("ORDER BY loc_na ")
			Return _sb.ToString()
		End Function
#End Region
	End Class




End Namespace
