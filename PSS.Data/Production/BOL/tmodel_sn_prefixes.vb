Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic

Namespace BOL

	Public Class tmodel_sn_prefixes

#Region "DECLARATIONS"

		Private _msp_id As Integer = 0
		Private _model_id As Integer = 0
		Private _prefix As String = ""
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

		Public Sub New(ByVal msp_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(msp_id)
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
		ByVal msp_id As Integer, _
		ByVal model_id As Integer, _
		ByVal prefix As String _
		 )
			_msp_id = msp_id
			_model_id = model_id
			_prefix = prefix
		End Sub

#End Region
#Region "PROPERTIES"

		Public Property msp_id() As Integer
			Get
				Return _msp_id
			End Get
			Set(ByVal Value As Integer)
				_msp_id = value
				_isDirty = True
			End Set
		End Property
		Public Property model_id() As Integer
			Get
				Return _model_id
			End Get
			Set(ByVal Value As Integer)
				_model_id = value
				_isDirty = True
			End Set
		End Property
		Public Property prefix() As String
			Get
				Return _prefix
			End Get
			Set(ByVal Value As String)
				_prefix = value
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

		Protected Sub GetData(ByVal msp_id As Integer)
			Dim _sql As String = GetSelectStatement(msp_id)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Private Sub PopulateObject(ByVal _dr As DataRow)

			_msp_id = _dr("msp_id").ToString()
			_model_id = _dr("model_id").ToString()
			_prefix = ConvertToSomething(_dr("prefix").ToString(), "")
		End Sub
		Protected Function GetSelectStatement(ByVal msp_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "msp_id, "
			_sql += "model_id, "
			_sql += "prefix "
			_sql += "FROM production.tmodel_sn_prefixes "
			_sql += "WHERE msp_id = " & msp_id.ToString() & ""
			Return _sql
		End Function
		Public Sub MarkDeleted()
			_isDeleted = True
		End Sub
		Public Sub ApplyChanges()
			If _isNew Then
				_msp_id = Insert()
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
				strSQL = "INSERT INTO production.tmodel_sn_prefixes (" & _
				   "msp_id, " & _
				   "model_id, " & _
				   "prefix " & _
				  ") " & _
				  "VALUES ( " & _
				   _msp_id & " , " & _
				   _model_id & " , '" & _
				   _prefix & "'  " & _
				   ")"
				_id = objDataProc.ExecuteScalarForInsert(strSQL, "production.tmodel_sn_prefixes")
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
				strSQL = "UPDATE production.tmodel_sn_prefixes SET " & _
				   "msp_id = " & ConvertBackToNullString(_msp_id, False) & ", " & _
				   "model_id = " & ConvertBackToNullString(_model_id, False) & ", " & _
				   "prefix = " & ConvertBackToNullString(_prefix, False) & ", " & _
				  ") " & _
				  "WHERE msp_id = " & msp_id.ToString() & "; "
				Return objDataProc.ExecuteNonQuery(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Protected Function Delete() As Integer
			Dim strSQL, strToday As String
			Try
				Dim objDataProc As DBQuery.DataProc
				Dim _cnt As Integer
				objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
				strSQL = " DELETE FROM production.tmodel_sn_prefixes WHERE msp_id = " & msp_id.ToString() & "; "
				_cnt = objDataProc.ExecuteNonQuery(strSQL)
				Return _cnt
			Catch ex As Exception
				Throw ex
				Return 0
			End Try
		End Function

#End Region

	End Class


	Public Class tmodel_sn_prefixesCollection
#Region "DECLARATIONS"

		Inherits Collections.ArrayList
		Private _objDataProc As DBQuery.DataProc
		Private _dt As New DataTable()
		Private _list As New ArrayList()

#End Region
#Region "CONSTRUCTORS"

		Public Sub New(ByVal model_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(model_id)
		End Sub

#End Region
#Region "PROPERTIES"

		Public ReadOnly Property tmodel_sn_prefixesDataTable() As DataTable
			Get
				Return _dt
			End Get
		End Property

#End Region
#Region "METHODS"

		Protected Sub GetData(ByVal model_id As Integer)
			Dim _sql As String = GetSelectStatement(model_id)
			_dt = _objDataProc.GetDataTable(_sql)
		End Sub

		Protected Function GetSelectStatement(ByVal model_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "msp_id, "
			_sql += "model_id, "
			_sql += "prefix "
			_sql += "FROM production.tmodel_sn_prefixes "
			_sql += "WHERE model_id = " & model_id.ToString() & ""
			Return _sql
		End Function

#End Region
	End Class

End Namespace
