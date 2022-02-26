Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic

Namespace Buisness

	Public Class MsgOpenLinesQueue

#Region "DECLARATIONS"

		Private _olq_id As Integer = 0
		Private _device_sn As String = ""
		Private _crt_dt As Date
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

		Public Sub New(ByVal device_sn As String)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(device_sn)
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
		ByVal olq_id As Int32, _
		ByVal device_sn As String, _
		ByVal crt_dt As DateTime _
		 )
			_olq_id = olq_id
			_device_sn = device_sn
			_crt_dt = crt_dt
		End Sub

#End Region
#Region "PROPERTIES"

		Public Property olq_id() As Integer
			Get
				Return _olq_id
			End Get
			Set(ByVal Value As Integer)
				_olq_id = Value
			End Set
		End Property
		Public Property device_sn() As String
			Get
				Return _device_sn
			End Get
			Set(ByVal Value As String)
				_device_sn = Value
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
			Dim _sql As String = GetSelectStatement(id)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub

		Protected Sub GetData(ByVal device_sn As String)
			Dim _sql As String = GetSelectStatement(device_sn)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub

		Private Sub PopulateObject(ByVal _dr As DataRow)
			_olq_id = DirectCast(_dr("olq_id"), Integer)
			_device_sn = _dr("device_sn").ToString()
			_crt_dt = DirectCast(_dr("crt_dt"), DateTime)
		End Sub

		Protected Function GetSelectStatement(ByVal ID As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "olq_id"
			_sql += "device_sn"
			_sql += "crt_dt"
			_sql += "FROM tmsg_openlines_queue "
			_sql += "WHERE olq_id = " & ID.ToString() & ""
			Return _sql
		End Function

		Protected Function GetSelectStatement(ByVal device_sn As String) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "olq_id, "
			_sql += "device_sn, "
			_sql += "crt_dt "
			_sql += "FROM tmsg_openlines_queue "
			_sql += "WHERE device_sn = '" & device_sn & "';"
			Return _sql
		End Function

		Public Sub ApplyChanges()
			If _isNew Then
				_olq_id = Insert()
			ElseIf IsDeleted Then
				' delete
			ElseIf IsDirty Then
				'Update()
			End If
		End Sub

		Public Function Insert() As Integer
			Dim _sb As New StringBuilder()
			Try
				Dim objDataProc As DBQuery.DataProc
				Dim _id As Integer
				objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
				Dim strToday As String = PSS.Data.Buisness.Generic.GetMySqlDateTime("%Y-%m-%d").ToString()
				_sb.Append("INSERT INTO production.tmsg_openlines_queue (  ")
				_sb.Append("device_sn, ")
				_sb.Append("crt_dt ")
				_sb.Append(") ")
				_sb.Append("VALUES ( ")
				_sb.Append("'" & _device_sn & "', ")
				_sb.Append("'" & strToday.ToString() & "' ")
				_sb.Append("); ")
				_id = objDataProc.ExecuteScalarForInsert(_sb.ToString(), "tmsg_openlines_queue")
				Return _id
			Catch ex As Exception
				If InStr(ex.Message, "Duplicate") > 0 Then
					Throw New Exception("Duplicate exists.")
				Else
					Throw ex
				End If
			End Try
		End Function

		Public Sub Delete()
			_objDataProc.ExecuteNonQuery("DELETE FROM tmsg_openlines_queue WHERE olq_id = " & _olq_id.ToString() & ";")
		End Sub

#End Region

	End Class

	Public Class MsgOpenLinesQueueCollection
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

		Public ReadOnly Property MsgOpenLinesQueueDataTable() As DataTable
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
			_sb.Append("device_sn, ")
			_sb.Append("crt_dt ")
			_sb.Append("FROM ")
			_sb.Append("tmsg_openlines_queue ")
			_sb.Append("ORDER BY device_sn ")
			_sb.Append("; ")
			Return _sb.ToString()
		End Function

#End Region

	End Class

End Namespace