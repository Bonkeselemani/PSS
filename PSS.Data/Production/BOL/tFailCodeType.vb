Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic
Namespace BOL
	Public Class tFailCodeType
#Region "DECLARATIONS"

		Private _fct_id As Integer = 0
		Private _cust_id As Integer = 0
		Private _disp_id As Integer = 0
		Private _fct_cd As String = ""
		Private _fct_desc As String = ""
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

		Public Sub New(ByVal fct_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(fct_id)
			_isDirty = False
			_isNew = False
		End Sub

#End Region
#Region "PROPERTIES"

		Public Property fct_id() As Integer
			Get
				Return _fct_id
			End Get
			Set(ByVal Value As Integer)
				_fct_id = Value
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
		Public Property disp_id() As Integer
			Get
				Return _disp_id
			End Get
			Set(ByVal Value As Integer)
				_disp_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property fct_cd() As String
			Get
				Return _fct_cd
			End Get
			Set(ByVal Value As String)
				_fct_cd = Value
				_isDirty = True
			End Set
		End Property
		Public Property fct_desc() As String
			Get
				Return _fct_desc
			End Get
			Set(ByVal Value As String)
				_fct_desc = Value
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

		Protected Sub GetData(ByVal fct_id As Integer)
			Dim _sql As String = GetSelectStatement(fct_id)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Private Sub PopulateObject(ByVal _dr As DataRow)
			_fct_id = ConvertToSomething(_dr("fct_id"), 0)
			_cust_id = ConvertToSomething(_dr("cust_id"), 0)
			_disp_id = ConvertToSomething(_dr("disp_id"), 0)
			_fct_cd = ConvertToSomething(_dr("fct_cd").ToString(), "")
			_fct_desc = ConvertToSomething(_dr("fct_desc").ToString(), "")
			_crt_ts = ConvertToSomething(_dr("crt_ts").ToString(), "")
			_crt_user_id = ConvertToSomething(_dr("crt_user_id"), 0)
		End Sub
		Protected Function GetSelectStatement(ByVal fct_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "fct_id, "
			_sql += "cust_id, "
			_sql += "disp_id, "
			_sql += "fct_cd, "
			_sql += "fct_desc, "
			_sql += "crt_ts, "
			_sql += "crt_user_id "
			_sql += "FROM production.tfailcodetype "
			_sql += "WHERE fct_id = " & fct_id.ToString() & ""
			Return _sql
		End Function
		Public Sub ApplyChanges()
			If _isNew Then
				_fct_id = Insert()
			ElseIf IsDeleted Then
				Throw New Exception("Delete not implemented.")
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
				strSQL = "INSERT INTO production.tfailcodetype (" & _
				   "fct_id, " & _
				   "cust_id, " & _
				   "disp_id, " & _
				   "fct_cd, " & _
				   "fct_desc, " & _
				   "crt_ts, " & _
				   "crt_user_id " & _
				  ") " & _
				  "VALUES ( " & _
				   _fct_id & " , " & _
				   _cust_id & " , " & _
				   _disp_id & " , " & _
				   _fct_cd & " , " & _
				   _fct_desc & " , " & _
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
				strSQL = "UPDATE production.tfailcodetype SET " & _
				   "fct_id = " & ConvertBackToNullString(_fct_id, False) & ", " & _
				   "cust_id = " & ConvertBackToNullString(_cust_id, False) & ", " & _
				   "disp_id = " & ConvertBackToNullString(_disp_id, False) & ", " & _
				   "fct_cd = " & ConvertBackToNullString(_fct_cd, False) & ", " & _
				   "fct_desc = " & ConvertBackToNullString(_fct_desc, False) & ", " & _
				   "crt_ts = " & ConvertBackToNullString(_crt_ts, False) & ", " & _
				   "crt_user_id = " & ConvertBackToNullString(_crt_user_id, False) & ", " & _
				  ") " & _
				  "WHERE fct_id = " & fct_id.ToString() & "; "
				Return objDataProc.ExecuteNonQuery(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

#End Region
	End Class
	Public Class tfailcodetypeCollection
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

		Public ReadOnly Property tfailcodetypeDataTable() As DataTable
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
			_sb.Append("fct_id, ")
			_sb.Append("cust_id, ")
			_sb.Append("disp_id, ")
			_sb.Append("fct_cd, ")
			_sb.Append("fct_desc, ")
			_sb.Append("crt_ts, ")
			_sb.Append("crt_user_id ")
			_sb.Append("FROM production.tfailcodetype ")
			_sb.Append("ORDER BY fct_desc")
			Return _sb.ToString()
		End Function

#End Region
	End Class
End Namespace
