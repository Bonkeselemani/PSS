Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic
Namespace BOL
	Public Class tcust_billing_points
#Region "DECLARATIONS"
		Private _cbp_id As Integer = 0
		Private _cust_id As Boolean = False
		Private _prod_id As Boolean = False
		Private _disp_id As Boolean = False
		Private _bp_id As Integer = 0
		Private _aql_req As Boolean = False
		Private _billcode_id As Integer = 0
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
		Public Sub New(ByVal cbp_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(cbp_id)
			_isDirty = False
			_isNew = False
		End Sub
#End Region
#Region "PROPERTIES"
		Public Property cbp_id() As Integer
			Get
				Return _cbp_id
			End Get
			Set(ByVal Value As Integer)
				_cbp_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property cust_id() As Boolean
			Get
				Return _cust_id
			End Get
			Set(ByVal Value As Boolean)
				_cust_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property prod_id() As Boolean
			Get
				Return _prod_id
			End Get
			Set(ByVal Value As Boolean)
				_prod_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property disp_id() As Boolean
			Get
				Return _disp_id
			End Get
			Set(ByVal Value As Boolean)
				_disp_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property bp_id() As Integer
			Get
				Return _bp_id
			End Get
			Set(ByVal Value As Integer)
				_bp_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property aql_req() As Boolean
			Get
				Return _aql_req
			End Get
			Set(ByVal Value As Boolean)
				_aql_req = Value
				_isDirty = True
			End Set
		End Property
		Public Property billcode_id() As Boolean
			Get
				Return _billcode_id
			End Get
			Set(ByVal Value As Boolean)
				_billcode_id = Value
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
		Protected Sub GetData(ByVal cbp_id As Integer)
			Dim _sql As String = GetSelectStatement(cbp_id)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Private Sub PopulateObject(ByVal _dr As DataRow)
			_cbp_id = ConvertToSomething(_dr("cbp_id"), 0)
			_cust_id = ConvertToSomething(_dr("cust_id"), False)
			_prod_id = ConvertToSomething(_dr("prod_id"), False)
			_disp_id = ConvertToSomething(_dr("disp_id"), False)
			_bp_id = ConvertToSomething(_dr("bp_id"), 0)
			_aql_req = ConvertToSomething(_dr("aql_req"), False)
			_billcode_id = ConvertToSomething(_dr("billcode_id"), 0)
			_crt_ts = ConvertToSomething(_dr("crt_ts").ToString(), "")
			_crt_user_id = ConvertToSomething(_dr("crt_user_id"), 0)
		End Sub
		Protected Function GetSelectStatement(ByVal cbp_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "cbp_id, "
			_sql += "cust_id, "
			_sql += "prod_id, "
			_sql += "disp_id, "
			_sql += "bp_id, "
			_sql += "aql_req, "
			_sql += "billcode_id, "
			_sql += "crt_ts, "
			_sql += "crt_user_id "
			_sql += "FROM production.tcust_billing_points "
			_sql += "WHERE cbp_id = " & cbp_id.ToString() & ""
			Return _sql
		End Function
		Public Sub ApplyChanges()
			If _isNew Then
				_cbp_id = Insert()
			ElseIf IsDeleted Then
				' delete
				Throw New Exception("Delete not Implemented.")
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
				strSQL = "INSERT INTO production.tcust_billing_points (" & _
				   "cbp_id, " & _
				   "cust_id, " & _
				   "prod_id, " & _
				   "disp_id, " & _
				   "bp_id, " & _
				   "aql_req, " & _
				   "billcode_id, " & _
				   "crt_ts, " & _
				   "crt_user_id " & _
				  ") " & _
				  "VALUES ( " & _
				   _cbp_id & " , " & _
				   ConvertBackToNullString(_cust_id, False) & " , " & _
				   ConvertBackToNullString(_prod_id, False) & " , " & _
				   ConvertBackToNullString(_disp_id, False) & " , " & _
				   _bp_id & " , " & _
				   ConvertBackToNullString(_aql_req, False) & " , " & _
				 _billcode_id & " , " & _
				   _crt_ts & " , " & _
				   ConvertBackToNullString(_crt_user_id, False) & "  " & _
				   ")"
				_id = objDataProc.ExecuteScalarForInsert(strSQL, "production.tcust_billing_points")
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
				strSQL = "UPDATE production.tcust_billing_points SET " & _
				   "cbp_id = " & ConvertBackToNullString(_cbp_id, False) & ", " & _
				   "cust_id = " & ConvertBackToNullString(_cust_id, False) & ", " & _
				   "prod_id = " & ConvertBackToNullString(_prod_id, False) & ", " & _
				   "disp_id = " & ConvertBackToNullString(_disp_id, False) & ", " & _
				   "bp_id = " & ConvertBackToNullString(_bp_id, False) & ", " & _
				   "aql_req = " & ConvertBackToNullString(_aql_req, False) & ", " & _
				   "crt_ts = " & ConvertBackToNullString(_crt_ts, False) & ", " & _
				   "crt_user_id = " & ConvertBackToNullString(_crt_user_id, False) & ", " & _
				  "WHERE cbp_id = " & cbp_id.ToString() & "; "
				Return objDataProc.ExecuteNonQuery(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Function
#End Region
	End Class
	Public Class tcust_billing_pointsCollection
#Region "DECLARATIONS"
		Inherits Collections.ArrayList
		Private _objDataProc As DBQuery.DataProc
		Private _dt As New DataTable()
		Private _list As New ArrayList()
#End Region
#Region "CONSTRUCTORS"
		Public Sub New(ByVal bp_id As Integer, ByVal cust_id As Integer, ByVal prod_id As Integer, ByVal disp_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(bp_id, cust_id, prod_id, disp_id)
		End Sub
#End Region
#Region "PROPERTIES"
		Public ReadOnly Property tcust_billing_pointsDataTable() As DataTable
			Get
				Return _dt
			End Get
		End Property
#End Region
#Region "METHODS"
		Protected Sub GetData(ByVal bp_id As Integer, ByVal cust_id As Integer, ByVal prod_id As Integer, ByVal disp_id As Integer)
			Dim _sql As String = GetSelectStatement(bp_id, cust_id, prod_id, disp_id)
			_dt = _objDataProc.GetDataTable(_sql)
		End Sub
		Protected Function GetSelectStatement(ByVal bp_id As Integer, ByVal cust_id As Integer, ByVal prod_id As Integer, ByVal disp_id As Integer) As String
			Dim _sb As New StringBuilder()
			_sb.Append("SELECT ")
			_sb.Append("cbp_id, ")
			_sb.Append("cust_id, ")
			_sb.Append("prod_id, ")
			_sb.Append("disp_id, ")
			_sb.Append("bp_id, ")
			_sb.Append("aql_req, ")
			_sb.Append("billcode_id, ")
			_sb.Append("crt_ts, ")
			_sb.Append("crt_user_id ")
			_sb.Append("FROM production.tcust_billing_points ")
			_sb.Append("WHERE ")
			_sb.Append("cust_id = " & cust_id.ToString() & " ")
			_sb.Append("AND ")
			_sb.Append("prod_id = " & prod_id.ToString() & " ")
			_sb.Append("AND ")
			_sb.Append("disp_id = " & disp_id.ToString() & " ")
			_sb.Append("AND ")
			_sb.Append("bp_id = " & bp_id.ToString() & "; ")
			Return _sb.ToString()
		End Function
#End Region
	End Class
End Namespace
