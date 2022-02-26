Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic
Namespace BOL
	Public Class lproduct
#Region "DECLARATIONS"

		Private _prod_id As Integer = 0
		Private _prod_desc As String = ""
		Private _prod_inactive As Boolean = False
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
		Public Sub New(ByVal Prod_ID As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(Prod_ID)
			_isDirty = False
			_isNew = False
		End Sub
#End Region
#Region "PROPERTIES"

		Public Property Prod_ID() As Integer
			Get
				Return _prod_id
			End Get
			Set(ByVal Value As Integer)
				_prod_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property Prod_Desc() As String
			Get
				Return _prod_desc
			End Get
			Set(ByVal Value As String)
				_prod_desc = Value
				_isDirty = True
			End Set
		End Property
		Public Property Prod_Inactive() As Boolean
			Get
				Return _prod_inactive
			End Get
			Set(ByVal Value As Boolean)
				_prod_inactive = Value
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
		Protected Sub GetData(ByVal Prod_ID As Integer)
			Dim _sql As String = GetSelectStatement(Prod_ID)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Private Sub PopulateObject(ByVal _dr As DataRow)
			_prod_id = ConvertToSomething(_dr("prod_id"), 0)
			_prod_desc = ConvertToSomething(_dr("prod_desc").ToString(), "")
			_prod_inactive = ConvertToSomething(_dr("prod_inactive"), False)
		End Sub
		Protected Function GetSelectStatement(ByVal Prod_ID As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "Prod_ID, "
			_sql += "Prod_Desc, "
			_sql += "Prod_Inactive "
			_sql += "FROM production.lproduct "
			_sql += "WHERE Prod_ID = " & Prod_ID.ToString() & ""
			Return _sql
		End Function
		Public Sub ApplyChanges()
			If _isNew Then
				_prod_id = Insert()
			ElseIf IsDeleted Then
				' delete
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
				strSQL = "INSERT INTO production.lproduct (" & _
				   "prod_desc, " & _
				   "prod_inactive " & _
				  ") " & _
				  "VALUES ( " & _
				   ConvertBackToNullString(_prod_desc, True) & " , " & _
				   IIf(_prod_inactive, 1, 0) & "  " & _
				   ")"
				_id = objDataProc.ExecuteScalarForInsert(strSQL, "production.lproduct")
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
				strSQL = "UPDATE production.lproduct SET " & _
				   "prod_id = " & ConvertBackToNullString(_prod_id, False) & ", " & _
				   "prod_desc = " & ConvertBackToNullString(_prod_desc, True) & ", " & _
				   "prod_inactive = " & IIf(_prod_inactive, 1, 0).ToString() & " " & _
				  "WHERE Prod_ID = " & Prod_ID.ToString() & "; "
				Return objDataProc.ExecuteNonQuery(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Function
#End Region
	End Class
	Public Class lproductCollection
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
		Public ReadOnly Property lproductDataTable() As DataTable
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
			_sb.Append("Prod_ID, ")
			_sb.Append("Prod_Desc, ")
			_sb.Append("Prod_Inactive ")
			_sb.Append("FROM production.lproduct ")
			_sb.Append("ORDER BY prod_desc; ")
			Return _sb.ToString()
		End Function
#End Region
	End Class
End Namespace
