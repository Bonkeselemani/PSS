Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic

Namespace BOL

	Public Class tFailCodes
#Region "DECLARATIONS"

		Private _fc_id As Integer = 0
		Private _fct_id As Integer = 0
		Private _fc_desc As String = ""
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

		Public Sub New(ByVal fc_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(fc_id)
			_isDirty = False
			_isNew = False
		End Sub

		Public Sub New(ByVal fct_id As Integer, ByVal fc_desc As String)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(fct_id, fc_desc)
			_isDirty = False
			_isNew = False
		End Sub





#End Region
#Region "PROPERTIES"

		Public Property fc_id() As Integer
			Get
				Return _fc_id
			End Get
			Set(ByVal Value As Integer)
				_fc_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property fct_id() As Integer
			Get
				Return _fct_id
			End Get
			Set(ByVal Value As Integer)
				_fct_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property fc_desc() As String
			Get
				Return _fc_desc
			End Get
			Set(ByVal Value As String)
				_fc_desc = Value
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

		Protected Sub GetData(ByVal fc_id As Integer)
			Dim _sql As String = GetSelectStatement(fc_id)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub

		Protected Sub GetData(ByVal fct_id As Integer, ByVal fc_desc As String)
			Dim _sql As String = GetSelectStatement(fct_id, fc_desc)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub






		Private Sub PopulateObject(ByVal _dr As DataRow)

			_fc_id = DirectCast(ConvertToSomething(_dr("fc_id"), 0), Integer)
			_fct_id = DirectCast(ConvertToSomething(_dr("fct_id"), 0), Integer)
			_fc_desc = ConvertToSomething(_dr("fc_desc").ToString(), "")
			_crt_ts = ConvertToSomething(_dr("crt_ts").ToString(), "")
			_crt_user_id = DirectCast(ConvertToSomething(_dr("crt_user_id"), 0), Integer)
		End Sub
		Protected Function GetSelectStatement(ByVal fc_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "fc_id, "
			_sql += "fct_id, "
			_sql += "fc_desc, "
			_sql += "crt_ts, "
			_sql += "crt_user_id "
			_sql += "FROM production.tfailcodes "
			_sql += "WHERE fc_id = " & fc_id.ToString() & ""
			Return _sql
		End Function

		Protected Function GetSelectStatement(ByVal fct_id As Integer, ByVal fc_desc As String) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "fc_id, "
			_sql += "fct_id, "
			_sql += "fc_desc, "
			_sql += "crt_ts, "
			_sql += "crt_user_id "
			_sql += "FROM production.tfailcodes "
			_sql += "WHERE fct_id = " & fct_id.ToString() & " "
			_sql += " AND "
			_sql += "fc_desc = '" & fc_desc & "'; "
			Return _sql
		End Function

		Public Sub ApplyChanges()
			If _isNew Then
				_fc_id = Insert()
			ElseIf IsDeleted Then
				Throw New Exception("Delete not Implemented.")
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
				strSQL = "INSERT INTO production.tfailcodes (" & _
				   "fc_id, " & _
				   "fct_id, " & _
				   "fc_desc, " & _
				   "crt_user_id " & _
				  ") " & _
				  "VALUES ( " & _
				   _fc_id & " , " & _
				   _fct_id & " , " & _
				   ConvertBackToNullString(_fc_desc, True) & " , " & _
				   _crt_user_id & "  " & _
				   ")"
				_id = objDataProc.ExecuteScalarForInsert(strSQL, "production.tfailcodes")
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
				strSQL = "UPDATE production.tfailcodes SET " & _
				   "fc_id = " & ConvertBackToNullString(_fc_id, False) & ", " & _
				   "fct_id = " & ConvertBackToNullString(_fct_id, False) & ", " & _
				   "fc_desc = " & ConvertBackToNullString(_fc_desc, False) & ", " & _
				   "crt_ts = " & ConvertBackToNullString(_crt_ts, False) & ", " & _
				   "crt_user_id = " & ConvertBackToNullString(_crt_user_id, False) & ", " & _
				  ") " & _
				  "WHERE fc_id = " & fc_id.ToString() & "; "
				Return objDataProc.ExecuteNonQuery(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

#End Region
	End Class

	Public Class tfailcodesCollection
#Region "DECLARATIONS"

		Inherits Collections.ArrayList
		Private _objDataProc As DBQuery.DataProc
		Private _dt As New DataTable()
		Private _list As New ArrayList()

#End Region
#Region "CONSTRUCTORS"

		Public Sub New(ByVal fct_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(fct_id)
		End Sub

#End Region
#Region "PROPERTIES"

		Public ReadOnly Property tfailcodesDataTable() As DataTable
			Get
				Return _dt
			End Get
		End Property

#End Region
#Region "METHODS"

		Protected Sub GetData(ByVal fct_id As Integer)
			Dim _sql As String = GetSelectStatement(fct_id)
			_dt = _objDataProc.GetDataTable(_sql)
		End Sub

		Protected Function GetSelectStatement(ByVal fct_id As Integer) As String
			Dim _sb As New StringBuilder()
			_sb.Append("SELECT ")
			_sb.Append("fc_id, ")
			_sb.Append("fct_id, ")
			_sb.Append("fc_desc, ")
			_sb.Append("crt_ts, ")
			_sb.Append("crt_user_id ")
			_sb.Append("FROM production.tfailcodes ")
			_sb.Append("WHERE fct_id = " & fct_id.ToString() & " ")
			Return _sb.ToString()
		End Function

#End Region
	End Class

End Namespace
