Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic


Namespace Buisness

	Public Class tdevice_question
		Inherits Object

#Region "DECLARATIONS"

		Private _dq_id As Integer = 0
		Private _device_id As Integer = 0
		Private _q_id As Integer = 0
		Private _answer As String = ""
		Private _note As String = ""
		Private _crt_dt As Date
		Private _isNew As System.Boolean = True
		Private _isDirty As System.Boolean = False
		Private _isDeleted As System.Boolean = False
		Private _isValid As System.Boolean = False
		'Private dispose As Boolean = False
		Private strToday As String = DateTime.Now.ToString("yyyy-MM-dd")

#End Region
#Region "CONSTRUCTORS"

		Public Sub New()
			'_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			'_isNew = True
		End Sub
		Public Sub New(ByVal id As Integer)
			GetData(id)
			_isDirty = False
			_isNew = False
		End Sub
		Public Sub New(ByVal dr As DataRow)
			'_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			PopulateObject(dr)
			_isDirty = False
			_isNew = False
		End Sub
		Public Sub New( _
		ByVal device_id As Int32, _
		ByVal q_id As Int32, _
		ByVal answer As String, _
		ByVal note As String _
		)
			'_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			_device_id = device_id
			_q_id = q_id
			_answer = answer
			_note = note
		End Sub

		Public Sub Dispose()
			Try
				'_objDataProc = Nothing
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

		Public Property dq_id() As Integer
			Get
				Return _dq_id
			End Get
			Set(ByVal Value As Integer)
				_dq_id = Value
			End Set
		End Property
		Public Property device_id() As Integer
			Get
				Return _device_id
			End Get
			Set(ByVal Value As Integer)
				_device_id = Value
			End Set
		End Property
		Public Property q_id() As Integer
			Get
				Return _q_id
			End Get
			Set(ByVal Value As Integer)
				_q_id = Value
			End Set
		End Property
		Public Property answer() As String
			Get
				Return _answer
			End Get
			Set(ByVal Value As String)
				_answer = Value
			End Set
		End Property
		Public Property note() As String
			Get
				Return _note
			End Get
			Set(ByVal Value As String)
				_note = Value
			End Set
		End Property
		Public Property crt_dt() As Date
			Get
				Return _crt_dt
			End Get
			Set(ByVal Value As Date)
				_crt_dt = Value
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
			Dim _objDataProc As New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			Dim _sql As String = GetSelectStatement(id)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
			_objDataProc = Nothing
		End Sub
		Private Sub PopulateObject(ByVal _dr As DataRow)
			_dq_id = DirectCast(_dr("dq_id"), Integer)
			_device_id = DirectCast(_dr("device_id"), Integer)
			_q_id = DirectCast(_dr("q_id"), Integer)
			_answer = _dr("answer").ToString()
			_note = _dr("note").ToString()
			_crt_dt = DirectCast(_dr("crt_dt"), DateTime)
		End Sub
		Protected Function GetSelectStatement(ByVal ID As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "dq_id"
			_sql += "device_id"
			_sql += "q_id"
			_sql += "answer"
			_sql += "note"
			_sql += "crt_dt"
			_sql += "FROM tmodel "
			_sql += "WHERE MODEL_ID = " & ID.ToString() & ""
			Return _sql
		End Function

		Public Sub ApplyChanges()
			If _isNew Then
				_dq_id = Insert()
			ElseIf IsDeleted Then
				' delete
			ElseIf IsDirty Then
				'Update()
			End If
		End Sub

		Protected Function Insert() As Integer
			Dim strToday As String
			Dim _sb As New StringBuilder()
			Dim _objDataProc As New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			Try
				Dim _id As Integer
				_sb.Append("INSERT INTO production.tdevice_question ")
				_sb.Append("( ")
				_sb.Append("device_id, ")
				_sb.Append("q_id, ")
				_sb.Append("answer, ")
				_sb.Append("note ")
				_sb.Append(") ")
				_sb.Append("VALUES ")
				_sb.Append("( ")
				_sb.Append(device_id.ToString())
				_sb.Append(", ")
				_sb.Append(_q_id.ToString())
				_sb.Append(", '")
				_sb.Append(_answer)
				_sb.Append("', '")
				_sb.Append(_note)
				_sb.Append("'); ")
				_id = _objDataProc.ExecuteScalarForInsert(_sb.ToString, "tdevice_question")
				Return _id
			Catch ex As Exception
				If InStr(ex.Message, "Duplicate") > 0 Then
					Throw New Exception("Duplicate exists.")
				Else
					Throw ex
				End If
			Finally
				_objDataProc = Nothing
			End Try
		End Function

#End Region

	End Class

	Public Class tdevice_questionCollection

#Region "DECLARATIONS"

		Inherits Collections.ArrayList
		Private _objDataProc As DBQuery.DataProc
		Private _dt As New DataTable()
		Private _list As New ArrayList()

#End Region
#Region "CONSTRUCTORS"

		Public Sub New(ByVal device_id As Integer)
			Dim _objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(device_id)
			PopulateCollection()
			_objDataProc = Nothing
		End Sub

		Protected Overrides Sub Finalize()		'
			Try
				_dt = Nothing
				'_objDataProc = Nothing
			Finally
				MyBase.Finalize()
			End Try
		End Sub

#End Region
#Region "PROPERTIES"

		Public ReadOnly Property tdevice_questionDataTable() As DataTable
			Get
				Return _dt
			End Get
		End Property

#End Region
#Region "METHODS"

		Protected Sub GetData(ByVal device_id As Integer)
			Dim _sql As String = GetSelectStatement(device_id)
			_dt = _objDataProc.GetDataTable(_sql)
		End Sub
		Protected Function GetSelectStatement(ByVal device_id As Integer) As String
			Dim _sb As New StringBuilder()
			_sb.Append("SELECT ")
			_sb.Append("dq_id, ")
			_sb.Append("device_id, ")
			_sb.Append("q_id, ")
			_sb.Append("answer, ")
			_sb.Append("note, ")
			_sb.Append("crt_dt ")
			_sb.Append("FROM production.tdevice_question ")
			_sb.Append("WHERE ")
			_sb.Append("device_id = ")
			_sb.Append(device_id.ToString())
			_sb.Append("; ")
			Return _sb.ToString()
		End Function
		Public Function NeedQuestionsAnswered() As Boolean
			Dim _retVal As Boolean = True
			Dim _screenable As Boolean = False
			Dim _ks As Boolean = False
			Dim _removed As Boolean = False
			If Me.Count > 0 Then
				Dim _q As tdevice_question
				For Each _q In Me
					If _q.q_id = 2 Then _screenable = _q.answer
					If _q.q_id = 5 Then _ks = _q.answer
					If _q.q_id = 6 Then _removed = _q.answer
				Next
				If _screenable Then
					If _ks Then
						If _removed Then
							_retVal = False
						End If
					End If
				Else
					_retVal = False
				End If
			End If
			Return _retVal
		End Function
		Private Sub PopulateCollection()
			Dim dr As DataRow
			For Each dr In _dt.Rows()
				Dim _dq As New tdevice_question(dr)
				Me.Add(_dq)
			Next
		End Sub

#End Region

	End Class

End Namespace
