Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic
Namespace BOL
	Public Class tdevicecodes
#Region "DECLARATIONS"
		Private _devicecode_id As Integer = 0
		Private _device_id As Integer = 0
		Private _dcode_id As Integer = 0
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
		Public Sub New(ByVal devicecode_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(devicecode_id)
			_isDirty = False
			_isNew = False
		End Sub
		Public Sub New(ByVal device_id As Integer, ByVal dcode_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(device_id, dcode_id)
			_isDirty = False
			_isNew = False
		End Sub
#End Region
#Region "PROPERTIES"
		Public Property devicecode_id() As Integer
			Get
				Return _devicecode_id
			End Get
			Set(ByVal Value As Integer)
				_devicecode_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property Device_ID() As Integer
			Get
				Return _device_id
			End Get
			Set(ByVal Value As Integer)
				_device_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property Dcode_ID() As Integer
			Get
				Return _dcode_id
			End Get
			Set(ByVal Value As Integer)
				_dcode_id = Value
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
		Protected Sub GetData(ByVal devicecode_id As Integer)
			Dim _sql As String = GetSelectStatement(devicecode_id)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Protected Sub GetData(ByVal device_id As Integer, ByVal dcode_id As Integer)
			Dim _sql As String = GetSelectStatement(device_id, dcode_id)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Private Sub PopulateObject(ByVal _dr As DataRow)

			_devicecode_id = _dr("devicecode_id").ToString()
			_device_id = ConvertToSomething(_dr("device_id"), 0)
			_dcode_id = ConvertToSomething(_dr("dcode_id"), 0)
		End Sub
		Protected Function GetSelectStatement(ByVal devicecode_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "devicecode_id, "
			_sql += "Device_ID, "
			_sql += "Dcode_ID "
			_sql += "FROM production.tdevicecodes "
			_sql += "WHERE devicecode_id = " & devicecode_id.ToString() & ""
			Return _sql
		End Function
		Protected Function GetSelectStatement(ByVal device_id As Integer, ByVal dcode_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "devicecode_id, "
			_sql += "Device_ID, "
			_sql += "Dcode_ID "
			_sql += "FROM production.tdevicecodes "
			_sql += "WHERE device_id = " & device_id.ToString() & " "
			_sql += "AND dcode_id = " & dcode_id.ToString() & " "
			Return _sql
		End Function
		Public Sub ApplyChanges()
			If _isNew Then
				_devicecode_id = Insert()
			ElseIf IsDeleted Then
				Delete()
			ElseIf IsDirty Then
				Update()
			End If
		End Sub
		Protected Function Insert() As Integer
			Dim strSQL, strToday As String
			Try
				Dim objDataProc As DBQuery.DataProc
				Dim _id As Integer
				objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
				strToday = PSS.Data.Buisness.Generic.GetMySqlDateTime("%Y-%m-%d")
				strSQL = "INSERT INTO production.tdevicecodes (" & _
				   "devicecode_id, " & _
				   "device_id, " & _
				   "dcode_id " & _
				  ") " & _
				  "VALUES ( " & _
				   _devicecode_id & " , " & _
				   _device_id & " , " & _
				   _dcode_id & "  " & _
				   ")"
				_id = objDataProc.ExecuteScalarForInsert(strSQL, "production.tdevicecodes")
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
				strSQL = "UPDATE production.tdevicecodes SET " & _
				   "devicecode_id = " & ConvertBackToNullString(_devicecode_id, False) & ", " & _
				   "device_id = " & ConvertBackToNullString(_device_id, False) & ", " & _
				   "dcode_id = " & ConvertBackToNullString(_dcode_id, False) & ", " & _
				  "WHERE devicecode_id = " & devicecode_id.ToString() & "; "
				Return objDataProc.ExecuteNonQuery(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Protected Function Delete() As Integer
			Dim _sb As New StringBuilder()
			Dim strToday As String
			Try
				Dim objDataProc As DBQuery.DataProc
				Dim _id As Integer
				objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
				_sb.Append("DELETE FROM ")
				_sb.Append("production.tdevicecodes ")
				_sb.Append("WHERE ")
				_sb.Append("devicecode_id = " & devicecode_id.ToString() & " ")
				_sb.Append(";")
				Return objDataProc.ExecuteNonQuery(_sb.ToString())
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Public Sub MarkDeleted()
			_isDeleted = True
		End Sub
#End Region
	End Class
	Public Class tdevicecodesCollection
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

		Public ReadOnly Property tdevicecodesDataTable() As DataTable
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
			_sb.Append("devicecode_id, ")
			_sb.Append("Device_ID, ")
			_sb.Append("Dcode_ID ")
			_sb.Append("FROM production.tdevicecodes; ")
			Return _sb.ToString()
		End Function
#End Region
	End Class
End Namespace
