Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic

Namespace Buisness

	Public Class tquestion

#Region "DECLARATIONS"

		Private _q_id As Integer = 0
		Private _qg_id As Integer = 0
		Private _q_txt As String = ""
		Private _q_parent_id As Integer = 0
		Private _q_rule As String = ""
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
		ByVal q_id As Int32, _
		ByVal qg_id As Int32, _
		ByVal q_txt As String, _
		ByVal q_parent_id As Int32, _
		ByVal q_rule As String _
		 )
			_q_id = q_id
			_qg_id = qg_id
			_q_txt = q_txt
			_q_parent_id = q_parent_id
			_q_rule = q_rule
		End Sub

		Protected Overrides Sub Finalize()
			Try
				_objDataProc = Nothing
			Finally
				MyBase.Finalize()
				GC.Collect()
				GC.WaitForPendingFinalizers()
				GC.Collect()
				GC.WaitForPendingFinalizers()
			End Try
		End Sub

#End Region
#Region "PROPERTIES"

		Public Property q_id() As Integer
			Get
				Return _q_id
			End Get
			Set(ByVal Value As Integer)
				_q_id = Value
			End Set
		End Property
		Public Property qg_id() As Integer
			Get
				Return _qg_id
			End Get
			Set(ByVal Value As Integer)
				_qg_id = Value
			End Set
		End Property
		Public Property q_txt() As String
			Get
				Return _q_txt
			End Get
			Set(ByVal Value As String)
				_q_txt = Value
			End Set
		End Property
		Public Property q_parent_id() As Integer
			Get
				Return _q_parent_id
			End Get
			Set(ByVal Value As Integer)
				_q_parent_id = Value
			End Set
		End Property
		Public Property q_rule() As String
			Get
				Return _q_rule
			End Get
			Set(ByVal Value As String)
				_q_rule = Value
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

			_q_id = DirectCast(_dr("q_id"), Integer)
			_qg_id = DirectCast(_dr("qg_id"), Integer)
			_q_txt = _dr("q_txt").ToString()
			_q_parent_id = DirectCast(_dr("q_parent_id"), Integer)
			_q_rule = _dr("q_rule").ToString()
		End Sub
		Protected Function GetSelectStatement(ByVal ID As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "q_id"
			_sql += "qg_id"
			_sql += "q_txt"
			_sql += "q_parent_id"
			_sql += "q_rule"
			_sql += "FROM tmodel "
			_sql += "WHERE MODEL_ID = " & ID.ToString() & ""
			Return _sql
		End Function

		Public Sub ApplyChanges()
			If _isNew Then
				_q_id = Insert()
			ElseIf IsDeleted Then
				' delete
			ElseIf IsDirty Then
				'Update()
			End If
		End Sub

		Protected Function Insert() As Integer
			Dim strToday As String
			Dim _sb As New StringBuilder()
			Try
				Dim objDataProc As DBQuery.DataProc
				Dim _id As Integer = 0
				objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
				strToday = PSS.Data.Buisness.Generic.GetMySqlDateTime("%Y-%m-%d")
				_sb.Append("INSERT INTO cogs.tquestion ( ")
				_sb.Append("q_id, ")
				_sb.Append("qg_id, ")
				_sb.Append("q_txt, ")
				_sb.Append("q_parent_id, ")
				_sb.Append("q_rule) ")
				_sb.Append("VALUES ( ")
				_sb.Append(_q_id)
				_sb.Append(", ")
				_sb.Append(_qg_id)
				_sb.Append(", ")
				_sb.Append(_q_txt)
				_sb.Append("_q_parent_id, ")
				_sb.Append(_q_rule)
				_sb.Append("); ")
				_id = _objDataProc.ExecuteScalarForInsert(_sb.ToString(), "cogs.tquestion")
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

	Public Class tquestionCollection
#Region "DECLARATIONS"

		Inherits Collections.ArrayList
		Private _objDataProc As DBQuery.DataProc
		Private _dt As New DataTable()
		Private _list As New ArrayList()

#End Region
#Region "CONSTRUCTORS"

		Public Sub New(ByVal qg_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(qg_id)
		End Sub

#End Region
#Region "PROPERTIES"

		Public ReadOnly Property tquestionDataTable() As DataTable
			Get
				Return _dt
			End Get
		End Property

#End Region
#Region "METHODS"

		Protected Sub GetData(ByVal qg_id As Integer)
			Dim _sql As String = GetSelectStatement(qg_id)
			_dt = _objDataProc.GetDataTable(_sql)
		End Sub

		Protected Function GetSelectStatement(ByVal qg_id As Integer) As String
			Dim _sb As New StringBuilder()
			_sb.Append("SELECT ")
			_sb.Append("q_id, ")
			_sb.Append("qg_id, ")
			_sb.Append("q_txt, ")
			_sb.Append("q_parent_id, ")
			_sb.Append("q_rule ")
			_sb.Append("FROM ")
			_sb.Append("production.tquestion ")
			_sb.Append("WHERE ")
			_sb.Append("qg_id = ")
			_sb.Append(qg_id & " ")
			_sb.Append("; ")
			Return _sb.ToString()
		End Function

#End Region
	End Class

End Namespace