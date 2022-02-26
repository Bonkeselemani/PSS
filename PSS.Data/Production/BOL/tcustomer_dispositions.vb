Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic
Namespace BOL
	Public Class tcustomer_dispositions
#Region "DECLARATIONS"
		Private _cd_id As Integer = 0
		Private _cust_id As Integer = 0
		Private _prod_id As Integer = 0
		Private _disp_id As Integer = 0
		Private _cust_default As Boolean = False
		Private _active As Boolean = False
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

		Public Sub New(ByVal cd_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(cd_id)
			_isDirty = False
			_isNew = False
		End Sub

#End Region
#Region "PROPERTIES"

		Public Property cd_id() As Integer
			Get
				Return _cd_id
			End Get
			Set(ByVal Value As Integer)
				_cd_id = Value
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
		Public Property disp_id() As Integer
			Get
				Return _disp_id
			End Get
			Set(ByVal Value As Integer)
				_disp_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property cust_default() As Boolean
			Get
				Return _cust_default
			End Get
			Set(ByVal Value As Boolean)
				_cust_default = Value
				_isDirty = True
			End Set
		End Property
		Public Property active() As Boolean
			Get
				Return _active
			End Get
			Set(ByVal Value As Boolean)
				_active = Value
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

		Protected Sub GetData(ByVal cd_id As Integer)
			Dim _sql As String = GetSelectStatement(cd_id)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Private Sub PopulateObject(ByVal _dr As DataRow)

			_cd_id = DirectCast(ConvertToSomething(_dr("cd_id"), 0), Integer)
			_cust_id = DirectCast(ConvertToSomething(_dr("cust_id"), 0), Integer)
			_prod_id = DirectCast(ConvertToSomething(_dr("prod_id"), 0), Integer)
			_disp_id = DirectCast(ConvertToSomething(_dr("disp_id"), 0), Integer)
			_cust_default = DirectCast(ConvertToSomething(_dr("cust_default"), False), Boolean)
			_crt_ts = ConvertToSomething(_dr("crt_ts").ToString(), "")
			_crt_user_id = DirectCast(ConvertToSomething(_dr("crt_user_id"), 0), Integer)
		End Sub
		Protected Function GetSelectStatement(ByVal cd_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "cd_id, "
			_sql += "cust_id, "
			_sql += "prod_id, "
			_sql += "disp_id, "
			_sql += "cust_default, "
			_sql += "active, "
			_sql += "crt_ts, "
			_sql += "crt_user_id "
			_sql += "FROM production.tcustomer_dispositions "
			_sql += "WHERE cd_id = " & cd_id.ToString() & "; "
			Return _sql
		End Function

		Public Sub ApplyChanges()
			If _isNew Then
				_cd_id = Insert()
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
				strSQL = "INSERT INTO production.tcustomer_dispositions (" & _
				   "cd_id, " & _
				   "cust_id, " & _
				   "prod_id, " & _
				   "disp_id, " & _
				   "cust_default, " & _
				   "active, " & _
				   "crt_ts, " & _
				   "crt_user_id " & _
				  ") " & _
				  "VALUES ( " & _
				   _cd_id & " , " & _
				   _cust_id & " , " & _
				   _prod_id & " , " & _
				   _disp_id & " , " & _
				   _cust_default & " , " & _
				   IIf(_active, "1", "0") & " , " & _
				   _crt_ts & " , " & _
				   _crt_user_id & "  " & _
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
				strSQL = "UPDATE production.tcustomer_dispositions SET " & _
				   "cd_id = " & ConvertBackToNullString(_cd_id, False) & ", " & _
				   "cust_id = " & ConvertBackToNullString(_cust_id, False) & ", " & _
				   "prod_id = " & ConvertBackToNullString(_prod_id, False) & ", " & _
				   "disp_id = " & ConvertBackToNullString(_disp_id, False) & ", " & _
				   "cust_default = " & ConvertBackToNullString(_cust_default, False) & ", " & _
				   "active = " & IIf(_active, "1", "0") & ", " & _
				   "crt_ts = " & ConvertBackToNullString(_crt_ts, False) & ", " & _
				   "crt_user_id = " & ConvertBackToNullString(_crt_user_id, False) & ", " & _
				  ") " & _
				  "WHERE cd_id = " & cd_id.ToString() & "; "
				Return objDataProc.ExecuteNonQuery(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

#End Region
	End Class
	Public Class tcustomer_dispositionsCollection
#Region "DECLARATIONS"

		Inherits Collections.ArrayList
		Private _objDataProc As DBQuery.DataProc
		Private _dt As New DataTable()
		Private _list As New ArrayList()

#End Region
#Region "CONSTRUCTORS"

		Public Sub New(ByVal cust_id As Integer, ByVal include_inactive As Boolean)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(cust_id, include_inactive)
		End Sub

#End Region
#Region "PROPERTIES"

		Public ReadOnly Property tcustomer_dispositionsDataTable() As DataTable
			Get
				Return _dt
			End Get
		End Property

#End Region
#Region "METHODS"

		Protected Sub GetData(ByVal cust_id As Integer, ByVal include_inactive As Boolean)
			Dim _sql As String = GetSelectStatement(cust_id, include_inactive)
			_dt = _objDataProc.GetDataTable(_sql)
		End Sub

		Protected Function GetSelectStatement(ByVal cust_id As Integer, ByVal include_inactive As Boolean) As String
			Dim _sb As New StringBuilder()
			_sb.Append("SELECT ")
			_sb.Append("cd.cd_id, ")
			_sb.Append("cd.cust_id, ")
			_sb.Append("cd.prod_id, ")
			_sb.Append("cd.disp_id, ")
			_sb.Append("cd.cust_default, ")
			_sb.Append("cd.crt_ts, ")
			_sb.Append("cd.crt_user_id, ")
			_sb.Append("d.disp_cd, ")
			_sb.Append("d.disp_na ")
			_sb.Append("FROM production.tcustomer_dispositions cd ")
			_sb.Append("INNER JOIN production.tdispositions d ON cd.disp_id = d.disp_id ")
			_sb.Append("WHERE cd.cust_id = " & cust_id.ToString() & " ")
			If Not include_inactive Then
				_sb.Append("AND active = 1 ")
			End If
			_sb.Append("ORDER BY cd.disp_id; ")
			Return _sb.ToString()
		End Function

#End Region
	End Class
End Namespace
