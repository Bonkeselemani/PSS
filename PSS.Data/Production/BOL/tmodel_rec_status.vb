Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic
Namespace BOL
	Public Class tmodel_rec_status
#Region "DECLARATIONS"
		Private _mrs_id As Integer = 0
		Private _prod_id As Integer = 0
		Private _model_id As Integer = 0
		Private _inactive As Integer = 0
		Private _keymodel As Integer = 0
		Private _user_id As Integer = 0
		Private _updatedatetime As String
		Private _equip_type As String = ""
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
		Public Sub New(ByVal mrs_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(mrs_id)
			_isDirty = False
			_isNew = False
		End Sub
		Public Sub New(ByVal model_id As Integer, ByVal inactive As Boolean)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(model_id, inactive)
			_isDirty = False
			_isNew = False
		End Sub
#End Region
#Region "PROPERTIES"
		Public Property mrs_id() As Integer
			Get
				Return _mrs_id
			End Get
			Set(ByVal Value As Integer)
				_mrs_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property prod_id() As Integer
			Get
				Return _prod_id
			End Get
			Set(ByVal Value As Integer)
				_prod_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property model_id() As Integer
			Get
				Return _model_id
			End Get
			Set(ByVal Value As Integer)
				_model_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property inactive() As Integer
			Get
				Return _inactive
			End Get
			Set(ByVal Value As Integer)
				_inactive = Value
				_isDirty = True
			End Set
		End Property
		Public Property KeyModel() As Integer
			Get
				Return _keymodel
			End Get
			Set(ByVal Value As Integer)
				_keymodel = Value
				_isDirty = True
			End Set
		End Property
		Public Property User_ID() As Integer
			Get
				Return _user_id
			End Get
			Set(ByVal Value As Integer)
				_user_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property UpdateDatetime() As String
			Get
				Return _updatedatetime
			End Get
			Set(ByVal Value As String)
				_updatedatetime = Value
				_isDirty = True
			End Set
		End Property
		Public Property equip_type() As String
			Get
				Return _equip_type
			End Get
			Set(ByVal Value As String)
				_equip_type = Value.ToUpper
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
		Protected Sub GetData(ByVal mrs_id As Integer)
			Dim _sql As String = GetSelectStatement(mrs_id)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Protected Sub GetData(ByVal model_id As Integer, ByVal inactive As Boolean)
			Dim _sql As String = GetSelectStatement(model_id, inactive)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Private Sub PopulateObject(ByVal _dr As DataRow)
			_mrs_id = _dr("mrs_id").ToString()
			_prod_id = _dr("prod_id").ToString()
			_model_id = _dr("model_id").ToString()
			_inactive = ConvertToSomething(_dr("inactive"), 0)
			_keymodel = ConvertToSomething(_dr("keymodel"), 0)
			_user_id = ConvertToSomething(_dr("user_id"), 0)
			_updatedatetime = ConvertToSomething(_dr("updatedatetime").ToString(), "")
			_equip_type = ConvertToSomething(_dr("equip_type").ToString(), "")
		End Sub
		Protected Function GetSelectStatement(ByVal mrs_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "mrs_id, "
			_sql += "prod_id, "
			_sql += "model_id, "
			_sql += "inactive, "
			_sql += "KeyModel, "
			_sql += "User_ID, "
			_sql += "UpdateDatetime, "
			_sql += "equip_type "
			_sql += "FROM production.tmodel_rec_status "
			_sql += "WHERE mrs_id = " & mrs_id.ToString() & ""
			Return _sql
		End Function
		Protected Function GetSelectStatement(ByVal model_id As Integer, ByVal inactive As Boolean) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "mrs_id, "
			_sql += "prod_id, "
			_sql += "model_id, "
			_sql += "inactive, "
			_sql += "KeyModel, "
			_sql += "User_ID, "
			_sql += "UpdateDatetime, "
			_sql += "equip_type "
			_sql += "FROM production.tmodel_rec_status "
			_sql += "WHERE model_id = " & model_id.ToString() & " "
			_sql += "AND inactive = " & IIf(inactive, "1", "0") & "; "
			Return _sql
		End Function
		Public Sub ApplyChanges()
			If _isNew Then
				_mrs_id = Insert()
			ElseIf IsDeleted Then
				' delete
				Throw New Exception("Delete not Impletmented.")
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
				strSQL = "INSERT INTO production.tmodel_rec_status (" & _
				   "mrs_id, " & _
				   "prod_id, " & _
				   "model_id, " & _
				   "inactive, " & _
				   "keymodel, " & _
				   "user_id, " & _
				   "updatedatetime, " & _
				   "equip_type " & _
				  ") " & _
				  "VALUES ( " & _
				   _mrs_id & " , " & _
				   _prod_id & " , " & _
				   _model_id & " , " & _
				   _inactive & " , " & _
				   _keymodel & " , " & _
				   _user_id & " , " & _
				   ConvertBackToNullString(_updatedatetime, False) & " , " & _
				   ConvertBackToNullString(_equip_type, False) & "  " & _
				   ")"
				_id = objDataProc.ExecuteScalarForInsert(strSQL, "production.tmodel_rec_status")
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
				strSQL = "UPDATE production.tmodel_rec_status SET " & _
				   "mrs_id = " & ConvertBackToNullString(_mrs_id, False) & ", " & _
				   "prod_id = " & ConvertBackToNullString(_prod_id, False) & ", " & _
				   "model_id = " & ConvertBackToNullString(_model_id, False) & ", " & _
				   "inactive = " & ConvertBackToNullString(_inactive, False) & ", " & _
				   "keymodel = " & ConvertBackToNullString(_keymodel, False) & ", " & _
				   "user_id = " & ConvertBackToNullString(_user_id, False) & ", " & _
				   "updatedatetime = " & ConvertToMySQLDateOrNullString(_updatedatetime) & ", " & _
				   "equip_type = " & ConvertBackToNullString(_equip_type, True) & " " & _
				  "WHERE mrs_id = " & mrs_id.ToString() & "; "
				Return objDataProc.ExecuteNonQuery(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Function
#End Region
	End Class
	Public Class tmodel_rec_statusCollection
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
		Public ReadOnly Property tmodel_rec_statusDataTable() As DataTable
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
			_sb.Append("mrs_id, ")
			_sb.Append("prod_id, ")
			_sb.Append("model_id, ")
			_sb.Append("inactive, ")
			_sb.Append("KeyModel, ")
			_sb.Append("User_ID, ")
			_sb.Append("UpdateDatetime, ")
			_sb.Append("equip_type ")
			_sb.Append("FROM production.tmodel_rec_status; ")
			Return _sb.ToString()
		End Function
#End Region
	End Class
End Namespace
