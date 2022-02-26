Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic

Namespace BOL

	Public Class lwipowner

#Region "DECLARATIONS"

		Private _wipowner_id As Integer = 0
		Private _wipowner_desc As String = ""
		Private _ams_wipflow As Integer = 0
		Private _wipset As String = ""
		Private _inactive As Integer = 0
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
		ByVal wipowner_id As Int32, _
		ByVal wipowner_desc As String, _
		ByVal ams_wipflow As Int32, _
		ByVal wipset As String, _
		ByVal inactive As Int32 _
		 )
			_wipowner_id = wipowner_id
			_wipowner_desc = wipowner_desc
			_ams_wipflow = ams_wipflow
			_wipset = wipset
			_inactive = inactive
		End Sub

#End Region
#Region "PROPERTIES"

		Public Property wipowner_id() As Integer
			Get
				Return _wipowner_id
			End Get
			Set(ByVal Value As Integer)
				_wipowner_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property wipowner_desc() As String
			Get
				Return _wipowner_desc
			End Get
			Set(ByVal Value As String)
				_wipowner_desc = Value
				_isDirty = True
			End Set
		End Property
		Public Property AMS_WipFlow() As Integer
			Get
				Return _ams_wipflow
			End Get
			Set(ByVal Value As Integer)
				_ams_wipflow = Value
				_isDirty = True
			End Set
		End Property
		Public Property WipSet() As String
			Get
				Return _wipset
			End Get
			Set(ByVal Value As String)
				_wipset = Value
				_isDirty = True
			End Set
		End Property
		Public Property Inactive() As Integer
			Get
				Return _inactive
			End Get
			Set(ByVal Value As Integer)
				_inactive = Value
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
			_wipowner_id = _dr("wipowner_id")
			_wipowner_desc = _dr("wipowner_desc").ToString()
			_ams_wipflow = _dr("ams_wipflow")
			_wipset = _dr("wipset").ToString()
			_inactive = _dr("inactive")
		End Sub
		Protected Function GetSelectStatement(ByVal wipowner_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "wipowner_id, "
			_sql += "wipowner_desc, "
			_sql += "AMS_WipFlow, "
			_sql += "WipSet, "
			_sql += "Inactive "
			_sql += "FROM production.lwipowner "
			_sql += "WHERE wipowner_id = " & wipowner_id.ToString() & " "
			_sql += "UNION SELECT "
			_sql += "wipowner_id, "
			_sql += "wipowner_desc, "
			_sql += "AMS_WipFlow, "
			_sql += "WipSet, "
			_sql += "Inactive "
			_sql += "FROM production.lwipowner_set2 "
			_sql += "WHERE wipowner_id = " & wipowner_id.ToString() & "; "
			Return _sql
		End Function

		Public Sub ApplyChanges()
			If _isNew Then
				_wipowner_id = Insert()
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
				strSQL = "INSERT INTO production.lwipowner (" & _
				   "wipowner_id, " & _
				   "wipowner_desc, " & _
				   "ams_wipflow, " & _
				   "wipset, " & _
				   "inactive " & _
				  ") " & _
				  "VALUES ( " & _
				   _wipowner_id.ToString() & "," & _
				   _wipowner_desc.ToString() & "," & _
				   _ams_wipflow.ToString() & "," & _
				   _wipset.ToString() & "," & _
				   _inactive.ToString() & _
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


	Public Class lwipownerCollection
#Region "DECLARATIONS"

		Inherits Collections.ArrayList
		Private _objDataProc As DBQuery.DataProc
		Private _dt As New DataTable()
		Private _list As New ArrayList()

#End Region
#Region "CONSTRUCTORS"

		Public Sub New(ByVal wipowner_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData()
		End Sub

#End Region
#Region "PROPERTIES"

		Public ReadOnly Property lwipownerDataTable() As DataTable
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
			Dim _sql As String
			_sql = "SELECT "
			_sql += "wipowner_id, "
			_sql += "wipowner_desc, "
			_sql += "AMS_WipFlow, "
			_sql += "WipSet, "
			_sql += "Inactive "
			_sql += "FROM production.lwipowner "
			Return _sql
		End Function

#End Region
	End Class

End Namespace
