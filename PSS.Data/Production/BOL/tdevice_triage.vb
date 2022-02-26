Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic
Namespace BOL
	Public Class tdevice_triage
#Region "DECLARATIONS"

		Private _dt_id As Integer = 0
		Private _device_id As Integer = 0
		Private _fc_id As Integer = 0
		Private _whb_id_incoming As Integer = 0
		Private _disp_id As Integer = 0
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

		Public Sub New(ByVal device_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(device_id)
			_isDirty = False
			_isNew = False
		End Sub

		Public Sub New(ByVal sn As String)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(sn)
			_isDirty = False
			_isNew = False
		End Sub

#End Region
#Region "PROPERTIES"

		Public Property dt_id() As Integer
			Get
				Return _dt_id
			End Get
			Set(ByVal Value As Integer)
				_dt_id = Value
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
		Public Property fc_id() As Integer
			Get
				Return _fc_id
			End Get
			Set(ByVal Value As Integer)
				_fc_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property whb_id_incoming() As Integer
			Get
				Return _whb_id_incoming
			End Get
			Set(ByVal Value As Integer)
				_whb_id_incoming = Value
				_isDirty = True
			End Set
		End Property
		Public Property disp_id() As Integer
			Get
				Return _disp_id
			End Get
			Set(ByVal Value As Integer)
				_disp_id = Value
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
				_isValid = ( _
				 _device_id > 0 AndAlso _
				 _fc_id >= 0 AndAlso _
				 _crt_user_id > 0 _
				)
				Return _isValid
			End Get
		End Property

#End Region
#Region "METHODS"
		Protected Sub GetData(ByVal device_id As Integer)
			Dim _sql As String = GetSelectStatement(device_id)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Protected Sub GetData(ByVal sn As String)
			Dim _sql As String = GetSelectStatement(sn)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Private Sub PopulateObject(ByVal _dr As DataRow)

			_dt_id = DirectCast(ConvertToSomething(_dr("dt_id"), 0), Integer)
			_device_id = DirectCast(ConvertToSomething(_dr("device_id"), 0), Integer)
			_fc_id = DirectCast(ConvertToSomething(_dr("fc_id"), 0), Integer)
			_whb_id_incoming = DirectCast(ConvertToSomething(_dr("whb_id_incoming"), 0), Integer)
			_disp_id = DirectCast(ConvertToSomething(_dr("disp_id"), 0), Integer)
			_crt_ts = ConvertToSomething(_dr("crt_ts").ToString(), "")
			_crt_user_id = DirectCast(ConvertToSomething(_dr("crt_user_id"), 0), Integer)
		End Sub
		Protected Function GetSelectStatement(ByVal device_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "dtrg.dt_id, "
			_sql += "dtrg.device_id, "
			_sql += "dtrg.fc_id, "
			_sql += "dtrg.whb_id_incoming, "
			_sql += "dtrg.disp_id, "
			_sql += "dtrg.crt_ts, "
			_sql += "dtrg.crt_user_id "
			_sql += "FROM production.tdevice_triage dtrg "
			_sql += "INNER JOIN production.tdevice d ON	dtrg.device_id = d.device_id "
			_sql += "WHERE dtrg.device_id = " & device_id.ToString() & ""
			Return _sql
		End Function
		Protected Function GetSelectStatement(ByVal device_sn As String) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "dtrg.dt_id, "
			_sql += "dtrg.device_id, "
			_sql += "dtrg.fc_id, "
			_sql += "dtrg.whb_id_incoming, "
			_sql += "dtrg.disp_id, "
			_sql += "dtrg.crt_ts, "
			_sql += "dtrg.crt_user_id "
			_sql += "FROM production.tdevice_triage dtrg "
			_sql += "INNER JOIN production.tdevice d on dtrg.device_id = d.device_id "
			_sql += "WHERE d.device_sn = '" & device_sn & "' "
			Return _sql
		End Function
		Public Sub MarkForDeletion()
			_isDeleted = True
		End Sub
		Public Sub ApplyChanges()
			If _isNew Then
				_dt_id = Insert()
			ElseIf IsDeleted Then
				Delete()
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
				strSQL = "INSERT INTO production.tdevice_triage (" & _
				   "device_id, " & _
				   "fc_id, " & _
				   "whb_id_incoming, " & _
				   "disp_id, " & _
				   "crt_user_id " & _
				   ") " & _
				  "VALUES ( " & _
				   _device_id & " , " & _
				   _fc_id & " , " & _
				   _whb_id_incoming.ToString() & " , " & _
				   ConvertBackToNullString(_disp_id, False) & " , " & _
				   _crt_user_id & "  " & _
				   ");"
				_id = objDataProc.ExecuteScalarForInsert(strSQL, "production.tdevice_triage")
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
				strSQL = "UPDATE production.tdevice_triage SET " & _
				   "dt_id = " & ConvertBackToNullString(_dt_id, False) & ", " & _
				   "device_id = " & ConvertBackToNullString(_device_id, False) & ", " & _
				   "fc_id = " & ConvertBackToNullString(_fc_id, False) & ", " & _
				   "whb_id_incoming = " & ConvertBackToNullString(_whb_id_incoming, False) & ", " & _
				   "disp_id = " & ConvertBackToNullString(_disp_id, False) & ", " & _
				   "crt_ts = " & ConvertBackToNullString(_crt_ts, False) & ", " & _
				   "crt_user_id = " & ConvertBackToNullString(_crt_user_id, False) & ", " & _
				  ") " & _
				  "WHERE dt_id = " & dt_id.ToString() & "; "
				Return objDataProc.ExecuteNonQuery(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Protected Function Delete() As Integer
			Dim strSQL As String
			Try
				Dim objDataProc As DBQuery.DataProc
				Dim _cnt As Integer
				objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
				strSQL = " DELETE FROM production.tdevice_triage WHERE dt_id = " & _dt_id.ToString() & "; "
				_cnt = objDataProc.ExecuteNonQuery(strSQL)
				Return _cnt
			Catch ex As Exception
				Throw ex
				Return 0
			End Try
		End Function
#End Region
	End Class
	Public Class tdevice_triageCollection
#Region "DECLARATIONS"

		Inherits Collections.ArrayList
		Private _objDataProc As DBQuery.DataProc
		Private _dt As New DataTable()
		Private _list As New ArrayList()

#End Region
#Region "CONSTRUCTORS"

		Public Sub New(ByVal disp_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(disp_id)
		End Sub

#End Region
#Region "PROPERTIES"

		Public ReadOnly Property tdevice_triageDataTable() As DataTable
			Get
				Return _dt
			End Get
		End Property

#End Region
#Region "METHODS"

		Protected Sub GetData(ByVal disp_id As Integer)
			Dim _sql As String = GetSelectStatement(disp_id)
			_dt = _objDataProc.GetDataTable(_sql)
		End Sub

		Protected Function GetSelectStatement(ByVal disp_id As Integer) As String
			Dim _sb As New StringBuilder()
			_sb.Append("SELECT ")
			_sb.Append("dt_id, ")
			_sb.Append("device_id, ")
			_sb.Append("fc_id, ")
			_sb.Append("whb_id_incoming, ")
			_sb.Append("disp_id, ")
			_sb.Append("crt_ts, ")
			_sb.Append("crt_user_id ")
			_sb.Append("FROM production.tdevice_triage ")
			_sb.Append("WHERE disp_id = " & disp_id.ToString() & " ")
			Return _sb.ToString()
		End Function

#End Region
	End Class
End Namespace
