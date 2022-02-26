Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic

Namespace BOL

	Public Class tdevice_swscreen_journal

#Region "DECLARATIONS"

		Private _swsj_id As Integer = 0
		Private _incoming_box As String = ""
		Private _outgoing_box As String = ""
		Private _device_id As Integer = 0
		Private _device_sn As String = ""
		Private _resolution As String = ""
		Private _username As String = ""
		Private _crt_dt As String = ""
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
		ByVal swsj_id As Int32, _
		ByVal incoming_box As String, _
		ByVal outgoing_box As String, _
		ByVal device_id As Int32, _
		ByVal device_sn As String, _
		ByVal resolution As String, _
		ByVal username As String, _
		ByVal crt_dt As String _
		 )
			_swsj_id = swsj_id
			_incoming_box = incoming_box
			_outgoing_box = outgoing_box
			_device_id = device_id
			_device_sn = device_sn
			_resolution = resolution
			_username = username
			_crt_dt = crt_dt
			_isNew = (_swsj_id = 0)
		End Sub

		Protected Overrides Sub Finalize()		'
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

		Public Property swsj_id() As Integer
			Get
				Return _swsj_id
			End Get
			Set(ByVal Value As Integer)
				_swsj_id = Value
			End Set
		End Property
		Public Property incoming_box() As String
			Get
				Return _incoming_box
			End Get
			Set(ByVal Value As String)
				_incoming_box = Value
			End Set
		End Property
		Public Property outgoing_box() As String
			Get
				Return _outgoing_box
			End Get
			Set(ByVal Value As String)
				_outgoing_box = Value
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
		Public Property device_sn() As String
			Get
				Return _device_sn
			End Get
			Set(ByVal Value As String)
				_device_sn = Value
			End Set
		End Property
		Public Property resolution() As String
			Get
				Return _resolution
			End Get
			Set(ByVal Value As String)
				_device_sn = Value
			End Set
		End Property
		Public Property username() As String
			Get
				Return _username
			End Get
			Set(ByVal Value As String)
				_username = Value
			End Set
		End Property
		Public Property crt_dt() As String
			Get
				Return IIf(IsNew, Date.Now, _crt_dt)
			End Get
			Set(ByVal Value As String)
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

		Protected Overloads Sub GetData(ByVal id As Integer)
			Dim _sql As String = GetSelectStatement(id)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub

		Protected Overloads Sub GetData(ByVal device_sn As String)
			Dim _sql As String = GetSelectStatement(device_sn)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub

		Private Sub PopulateObject(ByVal _dr As DataRow)
			_swsj_id = DirectCast(_dr("swsj_id"), Integer)
			_incoming_box = _dr("incoming_box").ToString()
			_outgoing_box = _dr("outgoing_box").ToString()
			_device_id = DirectCast(_dr("device_id"), Integer)
			_device_sn = _dr("device_sn").ToString()
			_resolution = _dr("resolution").ToString()
			_username = _dr("username").ToString()
			_crt_dt = _dr("crt_dt").ToString()
		End Sub

		Protected Overloads Function GetSelectStatement(ByVal ID As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "swsj_id,"
			_sql += "incoming_box,"
			_sql += "outgoing_box,"
			_sql += "device_id,"
			_sql += "device_sn,"
			_sql += "resolution,"
			_sql += "username,"
			_sql += "crt_dt"
			_sql += "FROM cogs.tdevice_swscreen_journal "
			_sql += "WHERE device_id = " & ID.ToString() & ""
			Return _sql
		End Function

		Protected Overloads Function GetSelectStatement(ByVal device_sn As String) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "swsj_id,"
			_sql += "incoming_box,"
			_sql += "outgoing_box,"
			_sql += "device_id,"
			_sql += "device_sn,"
			_sql += "resolution,"
			_sql += "username,"
			_sql += "crt_dt"
			_sql += "FROM cogs.tdevice_swscreen_journal "
			_sql += "WHERE device_sn = '" & device_sn & "'; "
			Return _sql
		End Function

		Public Sub ApplyChanges()
			If _isNew Then
				_swsj_id = Insert()
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
				Dim _id As Integer
				objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
				'strToday = PSS.Data.Buisness.Generic.GetMySqlDateTime("%Y-%m-%d")
				_sb.Append("INSERT INTO production.tdevice_swscreen_journal (")
				_sb.Append("swsj_id, ")
				_sb.Append("incoming_box, ")
				_sb.Append("outgoing_box, ")
				_sb.Append("device_id, ")
				_sb.Append("device_sn, ")
				_sb.Append("resolution, ")
				_sb.Append("username, ")
				_sb.Append("crt_dt ")
				_sb.Append(") ")
				_sb.Append("VALUES ( ")
				_sb.Append(_swsj_id)
				_sb.Append(",'")
				_sb.Append(_incoming_box)
				_sb.Append("','")
				_sb.Append(_outgoing_box)
				_sb.Append("',")
				_sb.Append(_device_id)
				_sb.Append(",'")
				_sb.Append(_device_sn)
				_sb.Append("','")
				_sb.Append(_resolution)
				_sb.Append("','")
				_sb.Append(_username)
				_sb.Append("','")
				_sb.Append(_crt_dt)
				_sb.Append("');")
				_id = objDataProc.ExecuteScalarForInsert(_sb.ToString(), "tdevice_swscreen_journal")
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

	Public Class tdevice_swscreen_journalCollection

#Region "DECLARATIONS"

		Inherits Collections.ArrayList
		Private _objDataProc As DBQuery.DataProc
		Private _dt As New DataTable()
		Private _list As New ArrayList()

#End Region
#Region "CONSTRUCTORS"

		Public Sub New(ByVal swsj_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(swsj_id)
		End Sub

		Protected Overrides Sub Finalize()
			' Destructor
			_dt.Dispose()
			_objDataProc = Nothing
		End Sub

#End Region
#Region "PROPERTIES"

		Public ReadOnly Property tdevice_swscreen_journalDataTable() As DataTable
			Get
				Return _dt
			End Get
		End Property

#End Region
#Region "METHODS"

		Protected Sub GetData(ByVal outgoing_box As String)
			Dim _sql As String = GetSelectStatement(outgoing_box)
			_dt = _objDataProc.GetDataTable(_sql)
		End Sub
		Protected Function GetSelectStatement(ByVal outgoing_box As String) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "swsj_id,"
			_sql += "incoming_box,"
			_sql += "outgoing_box,"
			_sql += "device_id,"
			_sql += "device_sn,"
			_sql += "resolution,"
			_sql += "username,"
			_sql += "crt_dt"
			_sql += "FROM cogs.tdevice_swscreen_journal "
			_sql += "WHERE outgoing_box = " & outgoing_box & ""
			Return _sql
		End Function

#End Region

	End Class

End Namespace
