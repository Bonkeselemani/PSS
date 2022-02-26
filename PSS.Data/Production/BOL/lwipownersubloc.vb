Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic

Namespace BOL

	Public Class lwipownersubloc

#Region "DECLARATIONS"

		Private _wipownersubloc_id As Integer = 0
		Private _wipownersubloc_desc As String = ""
		Private _wipowner_id As Integer = 0
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


		Public Sub New(ByVal dr As DataRow)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			PopulateObject(dr)
			_isDirty = False
			_isNew = False
		End Sub
		Public Sub New( _
		ByVal wipownersubloc_id As Int32, _
		ByVal wipownersubloc_desc As String, _
		ByVal wipowner_id As Int32 _
		 )
			_wipownersubloc_id = wipownersubloc_id
			_wipownersubloc_desc = wipownersubloc_desc
			_wipowner_id = wipowner_id
		End Sub

#End Region
#Region "PROPERTIES"

		Public Property wipownersubloc_id() As Integer
			Get
				Return _wipownersubloc_id
			End Get
			Set(ByVal Value As Integer)
				_wipownersubloc_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property wipownersubloc_desc() As String
			Get
				Return _wipownersubloc_desc
			End Get
			Set(ByVal Value As String)
				_wipownersubloc_desc = Value
				_isDirty = True
			End Set
		End Property
		Public Property wipowner_id() As Integer
			Get
				Return _wipowner_id
			End Get
			Set(ByVal Value As Integer)
				_wipowner_id = Value
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
		Private Sub PopulateObject(ByVal _dr As DataRow)

			_wipownersubloc_id = _dr("wipownersubloc_id")
			_wipownersubloc_desc = _dr("wipownersubloc_desc").ToString()
			_wipowner_id = _dr("wipowner_id")
		End Sub
		Protected Function GetSelectStatement(ByVal wipownersubloc_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "wipownersubloc_id, "
			_sql += "wipownersubloc_desc, "
			_sql += "wipowner_id "
			_sql += "FROM production.lwipownersubloc "
			_sql += "WHERE wipownersubloc_id = " & wipownersubloc_id.ToString() & ""
			Return _sql
		End Function

		Public Sub ApplyChanges()
			If _isNew Then
				_wipownersubloc_id = Insert()
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
				strSQL = "INSERT INTO production.lwipownersubloc (" & _
				   "wipownersubloc_id, " & _
				   "wipownersubloc_desc, " & _
				   "wipowner_id " & _
				  ") " & _
				  "VALUES ( " & _
				   _wipownersubloc_id.ToString() & "," & _
				   _wipownersubloc_desc.ToString() & "," & _
				   _wipowner_id.ToString() & _
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

#End Region

	End Class

	Public Class lwipownersublocCollection
#Region "DECLARATIONS"

		Inherits Collections.ArrayList
		Private _objDataProc As DBQuery.DataProc
		Private _dt As New DataTable()
		Private _list As New ArrayList()

#End Region
#Region "CONSTRUCTORS"

		Public Sub New(ByVal wipownersubloc_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(wipownersubloc_id)
		End Sub

#End Region
#Region "PROPERTIES"

		Public ReadOnly Property lwipownersublocDataTable() As DataTable
			Get
				Return _dt
			End Get
		End Property

#End Region
#Region "METHODS"

		Protected Sub GetData(ByVal wipowner_id As Integer)
			Dim _sql As String = GetSelectStatement(wipowner_id)
			_dt = _objDataProc.GetDataTable(_sql)
		End Sub

		Protected Function GetSelectStatement(ByVal wipowner_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "wipownersubloc_id, "
			_sql += "wipownersubloc_desc, "
			_sql += "wipowner_id "
			_sql += "FROM production.lwipownersubloc "
			_sql += "WHERE XXXXX_ID = " & wipowner_id.ToString() & ""
			Return _sql
		End Function

#End Region
	End Class

End Namespace