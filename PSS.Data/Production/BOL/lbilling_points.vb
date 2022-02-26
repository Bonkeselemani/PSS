Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic
Namespace BOL
	Public Class lbilling_points
#Region "DECLARATIONS"
		Private _bp_id As Integer = 0
		Private _bp_na As String = ""
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
		Public Sub New(ByVal bp_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(bp_id)
			_isDirty = False
			_isNew = False
		End Sub
#End Region
#Region "PROPERTIES"
		Public Property bp_id() As Integer
			Get
				Return _bp_id
			End Get
			Set(ByVal Value As Integer)
				_bp_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property bp_na() As String
			Get
				Return _bp_na
			End Get
			Set(ByVal Value As String)
				_bp_na = Value
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
		Protected Sub GetData(ByVal bp_id As Integer)
			Dim _sql As String = GetSelectStatement(bp_id)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Private Sub PopulateObject(ByVal _dr As DataRow)

			_bp_id = ConvertToSomething(_dr("bp_id"), 0)
			_bp_na = ConvertToSomething(_dr("bp_na").ToString(), "")
			_crt_ts = ConvertToSomething(_dr("crt_ts").ToString(), "")
			_crt_user_id = ConvertToSomething(_dr("crt_user_id"), 0)
		End Sub
		Protected Function GetSelectStatement(ByVal bp_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "bp_id, "
			_sql += "bp_na, "
			_sql += "crt_ts, "
			_sql += "crt_user_id "
			_sql += "FROM production.lbilling_points "
			_sql += "WHERE bp_id = " & bp_id.ToString() & ""
			Return _sql
		End Function
		Public Sub ApplyChanges()
			If _isNew Then
				_bp_id = Insert()
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
				strSQL = "INSERT INTO production.lbilling_points (" & _
				   "bp_id, " & _
				   "bp_na, " & _
				   "crt_ts, " & _
				   "crt_user_id " & _
				  ") " & _
				  "VALUES ( " & _
				   _bp_id & " , " & _
				   ConvertBackToNullString(_bp_na, False) & " , " & _
				   _crt_ts & " , " & _
				   ConvertBackToNullString(_crt_user_id, False) & "  " & _
				   ")"
				_id = objDataProc.ExecuteScalarForInsert(strSQL, "production.lbilling_points")
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
				strSQL = "UPDATE production.lbilling_points SET " & _
				   "bp_id = " & ConvertBackToNullString(_bp_id, False) & ", " & _
				   "bp_na = " & ConvertBackToNullString(_bp_na, False) & ", " & _
				   "crt_ts = " & ConvertBackToNullString(_crt_ts, False) & ", " & _
				   "crt_user_id = " & ConvertBackToNullString(_crt_user_id, False) & ", " & _
				  "WHERE bp_id = " & bp_id.ToString() & "; "
				Return objDataProc.ExecuteNonQuery(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Function
#End Region
	End Class
	Public Class lbilling_pointsCollection
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
		Public ReadOnly Property lbilling_pointsDataTable() As DataTable
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
			_sb.Append("bp_id, ")
			_sb.Append("bp_na, ")
			_sb.Append("crt_ts, ")
			_sb.Append("crt_user_id ")
			_sb.Append("FROM production.lbilling_points; ")
			Return _sb.ToString()
		End Function
#End Region
	End Class
End Namespace
