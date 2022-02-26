Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic
Namespace BOL
	Public Class tdispositions
#Region "DECLARATIONS"
		Private _disp_id As Integer = 0
		Private _disp_cd As String = ""
		Private _disp_na As String = ""
		Private _crt_ts As String = ""
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
		Public Sub New(ByVal disp_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(disp_id)
			_isDirty = False
			_isNew = False
		End Sub
#End Region
#Region "PROPERTIES"
		Public Property disp_id() As Integer
			Get
				Return _disp_id
			End Get
			Set(ByVal Value As Integer)
				_disp_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property disp_cd() As String
			Get
				Return _disp_cd
			End Get
			Set(ByVal Value As String)
				_disp_cd = Value
				_isDirty = True
			End Set
		End Property
		Public Property disp_na() As String
			Get
				Return _disp_na
			End Get
			Set(ByVal Value As String)
				_disp_na = Value
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
		Protected Sub GetData(ByVal disp_id As Integer)
			Dim _sql As String = GetSelectStatement(disp_id)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Private Sub PopulateObject(ByVal _dr As DataRow)

			_disp_id = DirectCast(ConvertToSomething(_dr("disp_id"), 0), Integer)
			_disp_cd = ConvertToSomething(_dr("disp_cd").ToString(), "")
			_disp_na = ConvertToSomething(_dr("disp_na").ToString(), "")
			_crt_ts = ConvertToSomething(_dr("crt_ts").ToString(), "")
			_crt_user_id = ConvertToSomething(_dr("crt_user_id"), 0)
		End Sub
		Protected Function GetSelectStatement(ByVal disp_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "disp_id, "
			_sql += "disp_cd, "
			_sql += "disp_na, "
			_sql += "crt_ts, "
			_sql += "crt_user_id "
			_sql += "FROM production.tdispositions "
			_sql += "WHERE disp_id = " & disp_id.ToString() & ""
			Return _sql
		End Function
		Public Sub ApplyChanges()
			If _isNew Then
				_disp_id = Insert()
			ElseIf IsDeleted Then
				' delete
			ElseIf IsDirty Then
				Update()
			End If
		End Sub
		Protected Function Insert() As Integer
			Dim strSQL As String
			Try
				Dim objDataProc As DBQuery.DataProc
				Dim _id As Integer
				objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
				strSQL = "INSERT INTO production.tdispositions (" & _
				   "disp_cd, " & _
				   "disp_na, " & _
				   "crt_user_id " & _
				  ") " & _
				  "VALUES ( " & _
				   ConvertBackToNullString(_disp_cd, True) & " , " & _
				   ConvertBackToNullString(_disp_na, True) & " , " & _
				   ConvertBackToNullString(_crt_user_id, False) & "  " & _
				   "); "
				_id = objDataProc.ExecuteScalarForInsert(strSQL, "production.tdispositions")
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
				strSQL = "UPDATE production.tdispositions SET " & _
				   "disp_id = " & ConvertBackToNullString(_disp_id, False) & ", " & _
				   "disp_cd = " & ConvertBackToNullString(_disp_cd, True) & ", " & _
				   "disp_na = " & ConvertBackToNullString(_disp_na, True) & ", " & _
				   "crt_ts = " & ConvertToMySQLDateOrNullString(_crt_ts) & ", " & _
				   "crt_user_id = " & ConvertBackToNullString(_crt_user_id, False) & " " & _
				  " " & _
				  "WHERE disp_id = " & disp_id.ToString() & "; "
				Return objDataProc.ExecuteNonQuery(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Function
#End Region
	End Class
	Public Class tdispositionsCollection
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
		Public ReadOnly Property tdispositionsDataTable() As DataTable
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
			_sb.Append("disp_id, ")
			_sb.Append("disp_cd, ")
			_sb.Append("disp_na, ")
			_sb.Append("crt_ts, ")
			_sb.Append("crt_user_id ")
			_sb.Append("FROM production.tdispositions ")
			_sb.Append("ORDER BY disp_cd; ")
			Return _sb.ToString()
		End Function
#End Region
	End Class
End Namespace
