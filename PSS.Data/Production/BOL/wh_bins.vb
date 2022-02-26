Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic

Namespace BOL

	Public Class wh_bins

#Region "DECLARATIONS"

		Private _bin_id As Integer = 0
		Private _bin_na As String = ""
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

		Public Sub New(ByVal bin_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(bin_id)
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
		ByVal bin_id As Integer, _
		ByVal bin_na As String, _
		ByVal crt_ts As String, _
		ByVal crt_user_id As Integer _
		 )
			_bin_id = bin_id
			_bin_na = bin_na
			_crt_ts = crt_ts
			_crt_user_id = crt_user_id
		End Sub

#End Region
#Region "PROPERTIES"

		Public Property bin_id() As Integer
			Get
				Return _bin_id
			End Get
			Set(ByVal Value As Integer)
				_bin_id = value
				_isDirty = True
			End Set
		End Property
		Public Property bin_na() As String
			Get
				Return _bin_na
			End Get
			Set(ByVal Value As String)
				_bin_na = value
				_isDirty = True
			End Set
		End Property
		Public ReadOnly Property crt_ts() As String
			Get
				Return _crt_ts
			End Get
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

		Protected Sub GetData(ByVal bin_id As Integer)
			Dim _sql As String = GetSelectStatement(bin_id)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Private Sub PopulateObject(ByVal _dr As DataRow)

			_bin_id = _dr("bin_id").ToString()
			_bin_na = ConvertToSomething(_dr("bin_na").ToString(), "")
			_crt_ts = ConvertToSomething(_dr("crt_ts").ToString(), "")
			_crt_user_id = _dr("crt_user_id").ToString()
		End Sub
		Protected Function GetSelectStatement(ByVal bin_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "bin_id, "
			_sql += "bin_na, "
			_sql += "crt_ts, "
			_sql += "crt_user_id "
			_sql += "FROM warehouse.wh_bins "
			_sql += "WHERE bin_id = " & bin_id.ToString() & ""
			Return _sql
		End Function

		Public Sub ApplyChanges()
			If _isNew Then
				_bin_id = Insert()
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
				strSQL = "INSERT INTO warehouse.wh_bins (" & _
				   "bin_na, " & _
				   "crt_user_id " & _
				  ") " & _
				  "VALUES ( '" & _
				   _bin_na & "', " & _
				   _crt_user_id & " " & _
				   ")"
				_id = objDataProc.ExecuteScalarForInsert(strSQL, "warehouse.wh_bins")
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
				strSQL = "UPDATE warehouse.wh_bins SET " & _
				   "bin_id = " & ConvertBackToNullString(_bin_id, False) & ", " & _
				   "bin_na = " & ConvertBackToNullString(_bin_na, False) & ", " & _
				   "crt_ts = " & ConvertBackToNullString(_crt_ts, False) & ", " & _
				   "crt_user_id = " & ConvertBackToNullString(_crt_user_id, False) & ", " & _
				  ") " & _
				  "WHERE bin_id = " & bin_id.ToString() & "; "
				Return objDataProc.ExecuteNonQuery(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

#End Region

	End Class


	Public Class wh_binsCollection
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

		Public ReadOnly Property wh_binsDataTable() As DataTable
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
			_sb.Append("bin_id, ")
			_sb.Append("bin_na, ")
			_sb.Append("crt_ts, ")
			_sb.Append("crt_user_id ")
			_sb.Append("FROM warehouse.wh_bins ")
			_sb.Append("ORDER BY bin_na ")
			Return _sb.ToString()
		End Function

#End Region
	End Class

End Namespace
