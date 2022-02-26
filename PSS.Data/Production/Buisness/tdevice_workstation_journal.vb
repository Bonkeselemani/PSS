Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic

Namespace buisness

	Public Class tdevice_workstation_journal

#Region "DECLARATIONS"

		Private _dwsj_id As Integer = 0
		Private _device_id As Integer = 0
		Private _ws_na As String = ""
		Private _wssl_na As String = ""
		Private _user_na As String = ""
		Private _cmp_na As String = ""
		Private _prc_na As String = ""
		Private _crt_dt As Date
		Private _isNew As System.Boolean = True
		Private _isDirty As System.Boolean = False
		Private _isDeleted As System.Boolean = False
		Private _isValid As System.Boolean = False
		Private _objDataProc As DBQuery.DataProc
#End Region
#Region "CONSTRUCTORS"

		Public Sub New(ByVal device_id As Integer, ByVal ws_na As String, ByVal wssl_na As String, _
		ByVal user_na As String, ByVal cmp_na As String, ByVal prc_na As String)
			_device_id = device_id
			_ws_na = ws_na
			_wssl_na = wssl_na
			_user_na = user_na
			_cmp_na = cmp_na
			_prc_na = prc_na
			_crt_dt = Date.Now.Date
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
		ByVal dwsj_id As Int32, _
		ByVal device_id As Int32, _
		ByVal ws_na As String, _
		ByVal wssl_na As String, _
		ByVal user_na As String, _
		ByVal cmp_na As String, _
		ByVal prc_na As String, _
		ByVal crt_dt As DateTime _
		 )
			_dwsj_id = dwsj_id
			_device_id = device_id
			_ws_na = ws_na
			_wssl_na = wssl_na
			_user_na = user_na
			_cmp_na = cmp_na
			_prc_na = prc_na
			_crt_dt = crt_dt
		End Sub

#End Region
#Region "PROPERTIES"

		Public Property dwsj_id() As Integer
			Get
				Return _dwsj_id
			End Get
			Set(ByVal Value As Integer)
				_dwsj_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property device_id() As Integer
			Get
				Return _device_id
			End Get
			Set(ByVal Value As Integer)
				_device_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property ws_na() As String
			Get
				Return _ws_na
			End Get
			Set(ByVal Value As String)
				_ws_na = Value
				_isDirty = True
			End Set
		End Property
		Public Property wssl_na() As String
			Get
				Return _wssl_na
			End Get
			Set(ByVal Value As String)
				_wssl_na = Value
				_isDirty = True
			End Set
		End Property
		Public Property user_na() As String
			Get
				Return _user_na
			End Get
			Set(ByVal Value As String)
				_user_na = Value
				_isDirty = True
			End Set
		End Property
		Public Property cmp_na() As String
			Get
				Return _cmp_na
			End Get
			Set(ByVal Value As String)
				_cmp_na = Value
				_isDirty = True
			End Set
		End Property
		Public Property prc_na() As String
			Get
				Return _prc_na
			End Get
			Set(ByVal Value As String)
				_prc_na = Value
				_isDirty = True
			End Set
		End Property
		Public Property crt_dt() As Date
			Get
				Return _crt_dt
			End Get
			Set(ByVal Value As Date)
				_crt_dt = Value
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

			_dwsj_id = DirectCast(_dr("dwsj_id"), Integer)
			_device_id = DirectCast(_dr("device_id"), Integer)
			_ws_na = _dr("ws_na").ToString()
			_wssl_na = _dr("wssl_na").ToString()
			_user_na = _dr("user_na").ToString()
			_cmp_na = _dr("cmp_na").ToString()
			_prc_na = _dr("prc_na").ToString()
			_crt_dt = DirectCast(_dr("crt_dt"), DateTime)
		End Sub
		Protected Function GetSelectStatement(ByVal dwsj_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "dwsj_id"
			_sql += "device_id"
			_sql += "ws_na"
			_sql += "wssl_na"
			_sql += "user_na"
			_sql += "cmp_na"
			_sql += "prc_na"
			_sql += "crt_dt"
			_sql += "FROM production.tdevice_workstation_journal "
			_sql += "WHERE dwsj_id = " & dwsj_id.ToString() & ""
			Return _sql
		End Function
		Protected Function GetIDOfCurrentSelectStatement(ByVal device_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "MAX(dwsj_id)"
			_sql += "FROM production.tdevice_workstation_journal "
			_sql += "WHERE device_id = " & device_id.ToString() & ""
			Return _sql
		End Function
		Public Sub ApplyChanges()
			If _isNew Then
				' compare current to new.
				If Not CompareCurrentToNew() Then
					_dwsj_id = Insert()
				End If
			ElseIf IsDeleted Then
				' delete
			ElseIf IsDirty Then
				' Update
			End If
		End Sub
		Private Function CompareCurrentToNew() As Boolean
			' Compares the current workstation to the new workstation.
			Dim cur_ws_na As String = ""
			Dim cur_wssl_na As String = ""
			Dim cur_prc_na As String = ""
			Dim _col As New tdevice_workstation_journalCollection(_device_id, True)
			If _col.tdevice_workstation_journalDataTable.Rows.Count > 0 Then
				cur_ws_na = _col.tdevice_workstation_journalDataTable.Rows(0)("ws_na")
				cur_wssl_na = _col.tdevice_workstation_journalDataTable.Rows(0)("wssl_na")
				cur_prc_na = _col.tdevice_workstation_journalDataTable.Rows(0)("prc_na")
			End If
			Dim _retVal As Boolean = False
			If cur_ws_na = _ws_na AndAlso cur_wssl_na = _wssl_na AndAlso cur_prc_na = _prc_na Then
				_retVal = True
			End If
			_col = Nothing
			Return _retVal
		End Function
		Protected Function Insert() As Integer
			Dim strSQL, strToday As String
			Try
				Dim objDataProc As DBQuery.DataProc
				Dim _id As Integer
				objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
				strToday = PSS.Data.buisness.Generic.GetMySqlDateTime("%Y-%m-%d")
				strSQL = "INSERT INTO production.tdevice_workstation_journal (" & _
				   "dwsj_id, " & _
				   "device_id, " & _
				   "ws_na, " & _
				   "wssl_na, " & _
				   "user_na, " & _
				   "cmp_na, " & _
				   "prc_na, " & _
				   "crt_dt " & _
				  ") " & _
				  "VALUES ( " & _
				   _dwsj_id.ToString() & "," & _
				   _device_id.ToString() & ",'" & _
				   _ws_na.ToString() & "','" & _
				   _wssl_na.ToString() & "','" & _
				   _user_na.ToString() & "','" & _
				   _cmp_na.ToString() & "','" & _
				   _prc_na.ToString() & "','" & _
				   Format(Now, "yyyy-MM-dd hh:mm:ss") & "'" & _
				   ")"
				_id = objDataProc.ExecuteScalarForInsert(strSQL, "tdevice_workstation_journal")
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


	Public Class tdevice_workstation_journalCollection
#Region "DECLARATIONS"

		Inherits Collections.ArrayList
		Private _objDataProc As DBQuery.DataProc
		Private _dt As New DataTable()
		Private _list As New ArrayList()

#End Region
#Region "CONSTRUCTORS"

		Public Sub New(ByVal device_id As Integer, Optional ByVal sort_desc As Boolean = False)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(device_id, sort_desc)
		End Sub

#End Region
#Region "PROPERTIES"

		Public ReadOnly Property tdevice_workstation_journalDataTable() As DataTable
			Get
				Return _dt
			End Get
		End Property

#End Region
#Region "METHODS"

		Protected Sub GetData(ByVal device_id As Integer, Optional ByVal sort_desc As Boolean = False)
			Dim _sql As String = GetSelectStatement(device_id, sort_desc)
			_dt = _objDataProc.GetDataTable(_sql)
		End Sub
		Protected Function GetSelectStatement(ByVal device_id As Integer, Optional ByVal sort_desc As Boolean = False) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "dwsj_id, "
			_sql += "device_id, "
			_sql += "ws_na, "
			_sql += "wssl_na, "
			_sql += "user_na, "
			_sql += "cmp_na, "
			_sql += "prc_na, "
			_sql += "crt_dt "
			_sql += "FROM production.tdevice_workstation_journal "
			_sql += "WHERE device_id = " & device_id.ToString() & " "
			_sql += "ORDER BY dwsj_id "
			If sort_desc Then
				_sql += "DESC "
			End If
			Return _sql
		End Function

#End Region
	End Class

End Namespace