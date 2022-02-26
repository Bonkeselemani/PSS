Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic

Namespace BOL

	Public Class tCustProductFailCodes
#Region "DECLARATIONS"

		Private _cpfc_id As Integer = 0
		Private _cust_id As Integer = 0
		Private _prod_id As Integer = 0
		Private _fc_id As Integer = 0
		Private _active As Boolean = True
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
		Public Sub New(ByVal cpfc_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(cpfc_id)
			_isDirty = False
			_isNew = False
		End Sub

#End Region
#Region "PROPERTIES"

		Public Property cpfc_id() As Integer
			Get
				Return _cpfc_id
			End Get
			Set(ByVal Value As Integer)
				_cpfc_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property cust_id() As Integer
			Get
				Return _cust_id
			End Get
			Set(ByVal Value As Integer)
				_cust_id = Value
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
		Public Property fc_id() As Integer
			Get
				Return _fc_id
			End Get
			Set(ByVal Value As Integer)
				_fc_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property active() As Boolean
			Get
				Return _active
			End Get
			Set(ByVal Value As Boolean)
				_active = Value
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
				Return _isValid
			End Get
		End Property

#End Region
#Region "METHODS"

		Protected Sub GetData(ByVal cpfc_id As Integer)
			Dim _sql As String = GetSelectStatement(cpfc_id)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Private Sub PopulateObject(ByVal _dr As DataRow)

			_cpfc_id = DirectCast(ConvertToSomething(_dr("cpfc_id"), 0), Integer)
			_cust_id = DirectCast(ConvertToSomething(_dr("cust_id"), 0), Integer)
			_prod_id = DirectCast(ConvertToSomething(_dr("prod_id"), 0), Integer)
			_fc_id = DirectCast(ConvertToSomething(_dr("fc_id"), 0), Integer)
			_active = DirectCast(ConvertToSomething(_dr("active"), False), Boolean)
			_crt_ts = ConvertToSomething(_dr("crt_ts").ToString(), "")
			_crt_user_id = DirectCast(ConvertToSomething(_dr("crt_user_id"), 0), Integer)
		End Sub
		Protected Function GetSelectStatement(ByVal cpfc_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "cpfc_id, "
			_sql += "cust_id, "
			_sql += "prod_id, "
			_sql += "fc_id, "
			_sql += "active, "
			_sql += "crt_ts, "
			_sql += "crt_user_id "
			_sql += "FROM production.tcustproductfailcodes "
			_sql += "WHERE cpfc_id = " & cpfc_id.ToString() & ""
			Return _sql
		End Function
		Public Sub ApplyChanges()
			If _isNew Then
				_cpfc_id = Insert()
			ElseIf IsDeleted Then
				Throw New Exception("Delete not Implemented.")
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
				strSQL = "INSERT INTO production.tcustproductfailcodes (" & _
				   "cpfc_id, " & _
				   "cust_id, " & _
				   "prod_id, " & _
				   "fc_id, " & _
				   "active, " & _
				   "crt_user_id " & _
				  ") " & _
				  "VALUES ( " & _
				   _cpfc_id & " , " & _
				   _cust_id & " , " & _
				   _prod_id & " , " & _
				   _fc_id & " , " & _
				   IIf(_active, "1", "0") & " , " & _
				   _crt_user_id & "  " & _
				   ")"
				_id = objDataProc.ExecuteScalarForInsert(strSQL, "production.tcustproductfailcodes")
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
				strSQL = "UPDATE production.tcustproductfailcodes SET " & _
				   "cpfc_id = " & ConvertBackToNullString(_cpfc_id, False) & ", " & _
				   "cust_id = " & ConvertBackToNullString(_cust_id, False) & ", " & _
				   "prod_id = " & ConvertBackToNullString(_prod_id, False) & ", " & _
				   "fc_id = " & ConvertBackToNullString(_fc_id, False) & ", " & _
				   "active = " & ConvertBackToNullString(_active, False) & ", " & _
				   "crt_ts = " & ConvertBackToNullString(_crt_ts, False) & ", " & _
				   "crt_user_id = " & ConvertBackToNullString(_crt_user_id, False) & ", " & _
				  ") " & _
				  "WHERE cpfc_id = " & cpfc_id.ToString() & "; "
				Return objDataProc.ExecuteNonQuery(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

#End Region
	End Class

	Public Class tcustproductfailcodesCollection
#Region "DECLARATIONS"

		Inherits Collections.ArrayList
		Private _objDataProc As DBQuery.DataProc
		Private _dt As New DataTable()
		Private _list As New ArrayList()

#End Region
#Region "CONSTRUCTORS"

		Public Sub New(ByVal cust_id As Integer, ByVal prod_id As Integer, ByVal fct_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(cust_id, prod_id, fct_id)
		End Sub

#End Region
#Region "PROPERTIES"

		Public ReadOnly Property tcustproductfailcodesDataTable() As DataTable
			Get
				Return _dt
			End Get
		End Property

#End Region
#Region "METHODS"

		Protected Sub GetData(ByVal cust_id As Integer, ByVal prod_id As Integer, ByVal fct_id As Integer)
			Dim _sql As String = GetSelectStatement(cust_id, prod_id, fct_id)
			_dt = _objDataProc.GetDataTable(_sql)
		End Sub

		Protected Function GetSelectStatement(ByVal cust_id As Integer, ByVal prod_id As Integer, ByVal fct_id As Integer) As String
			Dim _sb As New StringBuilder()
			_sb.Append("SELECT ")
			_sb.Append("cpfc.cpfc_id, ")
			_sb.Append("cpfc.cust_id, ")
			_sb.Append("cpfc.prod_id, ")
			_sb.Append("cpfc.fc_id, ")
			_sb.Append("cpfc.active, ")
			_sb.Append("cpfc.crt_ts, ")
			_sb.Append("fc.fc_desc, ")
			_sb.Append("fct.fct_desc ")
			_sb.Append("FROM production.tcustproductfailcodes cpfc ")
			_sb.Append("INNER JOIN tfailcodes fc on cpfc.fc_id = fc.fc_id ")
			_sb.Append("INNER JOIN tfailcodetype fct on fc.fct_id = fct.fct_id ")
			_sb.Append("WHERE ")
			_sb.Append("cpfc.cust_id = " & cust_id.ToString() & " ")
			_sb.Append("AND ")
			_sb.Append("cpfc.prod_id = " & prod_id.ToString() & " ")
			_sb.Append("AND ")
			_sb.Append("fc.fct_id = " & fct_id.ToString() & " ")
			Return _sb.ToString()
		End Function

#End Region
	End Class

End Namespace
