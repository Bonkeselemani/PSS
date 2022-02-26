Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic

Namespace BOL

	Public Class tcust_sku_range

#Region "DECLARATIONS"

		Private _skur_id As Integer = 0
		Private _sku_id As Integer = 0
		Private _skur_start As Integer = 0
		Private _skur_end As Integer = 0
		Private _crt_ts As Date
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

		Public Sub New(ByVal skur_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(skur_id)
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
		ByVal skur_id As Integer, _
		ByVal sku_id As Integer, _
		ByVal skur_start As Integer, _
		ByVal skur_end As Integer, _
		ByVal crt_ts As DateTime, _
		ByVal crt_by_id As Integer _
		 )
			_skur_id = skur_id
			_sku_id = sku_id
			_skur_start = skur_start
			_skur_end = skur_end
			_crt_ts = crt_ts
			_crt_by_id = crt_by_id
		End Sub

#End Region
#Region "PROPERTIES"

		Public Property skur_id() As Integer
			Get
				Return _skur_id
			End Get
			Set(ByVal Value As Integer)
				_skur_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property sku_id() As Integer
			Get
				Return _sku_id
			End Get
			Set(ByVal Value As Integer)
				_sku_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property skur_start() As Integer
			Get
				Return _skur_start
			End Get
			Set(ByVal Value As Integer)
				_skur_start = Value
				_isDirty = True
			End Set
		End Property
		Public Property skur_end() As Integer
			Get
				Return _skur_end
			End Get
			Set(ByVal Value As Integer)
				_skur_end = Value
				_isDirty = True
			End Set
		End Property
		Public Property crt_ts() As Date
			Get
				Return _crt_ts
			End Get
			Set(ByVal Value As Date)
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

		Protected Sub GetData(ByVal skur_id As Integer)
			Dim _sql As String = GetSelectStatement(skur_id)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Private Sub PopulateObject(ByVal _dr As DataRow)

			_skur_id = _dr("skur_id").ToString()
			_sku_id = _dr("sku_id").ToString()
			_skur_start = _dr("skur_start").ToString()
			_skur_end = _dr("skur_end").ToString()
			_crt_ts = DirectCast(_dr("crt_ts"), DateTime)
			_crt_by_id = _dr("crt_by_id").ToString()
		End Sub
		Protected Function GetSelectStatement(ByVal skur_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "skur_id, "
			_sql += "sku_id, "
			_sql += "skur_start, "
			_sql += "skur_end, "
			_sql += "crt_ts, "
			_sql += "crt_by_id "
			_sql += "FROM production.tcust_sku_range "
			_sql += "WHERE skur_id = " & skur_id.ToString() & ""
			Return _sql
		End Function

		Public Sub ApplyChanges()
			If _isNew Then
				_skur_id = Insert()
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
				strSQL = "INSERT INTO production.tcust_sku_range (" & _
				   "skur_id, " & _
				   "sku_id, " & _
				   "skur_start, " & _
				   "skur_end, " & _
				   "crt_ts, " & _
				   "crt_by_id " & _
				  ") " & _
				  "VALUES ( " & _
				   _skur_id.ToString() & "," & _
				   _sku_id.ToString() & "," & _
				   _skur_start.ToString() & "," & _
				   _skur_end.ToString() & "," & _
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
				strSQL = "UPDATE production.tcust_sku_range SET " & _
				   "skur_id = " & ConvertBackToNullString(_skur_id, False) & ", " & _
				   "sku_id = " & ConvertBackToNullString(_sku_id, False) & ", " & _
				   "skur_start = " & ConvertBackToNullString(_skur_start, False) & ", " & _
				   "skur_end = " & ConvertBackToNullString(_skur_end, False) & ", " & _
				   "crt_ts = " & ConvertBackToNullString(_crt_ts, False) & ", " & _
				   "crt_by_id = " & ConvertBackToNullString(_crt_by_id, False) & ", " & _
				  ") " & _
				  "WHERE .skur_id = " & skur_id.ToString() & "; "
				Return objDataProc.ExecuteNonQuery(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

#End Region

	End Class


	Public Class tcust_sku_rangeCollection
#Region "DECLARATIONS"

		Inherits Collections.ArrayList
		Private _objDataProc As DBQuery.DataProc
		Private _dt As New DataTable()
		Private _list As New ArrayList()

#End Region
#Region "CONSTRUCTORS"

		Public Sub New(ByVal sku_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(sku_id)
		End Sub

#End Region
#Region "PROPERTIES"

		Public ReadOnly Property tcust_sku_rangeDataTable() As DataTable
			Get
				Return _dt
			End Get
		End Property

#End Region
#Region "METHODS"

		Protected Sub GetData(ByVal sku_id As Integer)
			Dim _sql As String = GetSelectStatement(sku_id)
			_dt = _objDataProc.GetDataTable(_sql)
		End Sub

		Protected Function GetSelectStatement(ByVal sku_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "skur_id, "
			_sql += "sku_id, "
			_sql += "skur_start, "
			_sql += "skur_end, "
			_sql += "crt_ts, "
			_sql += "crt_by_id "
			_sql += "FROM production.tcust_sku_range "
			_sql += "WHERE sku_id = " & sku_id.ToString() & ""
			Return _sql
		End Function

#End Region
	End Class

End Namespace