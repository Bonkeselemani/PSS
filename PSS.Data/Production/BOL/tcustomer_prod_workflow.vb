Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic
Namespace BOL
	Public Class tcustomer_prod_workflow
#Region "DECLARATIONS"
		Private _cpw_id As Integer = 0
		Private _cpl_id As Integer = 0
		Private _cpl_id_to As Integer = 0
		Private _disp_id As Integer = 0
		Private _active As Boolean = False
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
		Public Sub New(ByVal cpw_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(cpw_id, "")
			_isDirty = False
			_isNew = False
		End Sub
		Public Sub New(ByVal cpl_id As Integer, ByVal disp_id As Integer, Optional ByVal use_fail_loc As Boolean = False)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(cpl_id, disp_id, use_fail_loc)
			_isDirty = False
			_isNew = False
		End Sub

		Public Sub New(ByVal cpl_id As Integer, ByVal use_fail_loc As Boolean)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(cpl_id, use_fail_loc)
			_isDirty = False
			_isNew = False
		End Sub


		Public Sub New(ByVal loc_na As String)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(0, loc_na)
			_isDirty = False
			_isNew = False
		End Sub




#End Region
#Region "PROPERTIES"
		Public Property cpw_id() As Integer
			Get
				Return _cpw_id
			End Get
			Set(ByVal Value As Integer)
				_cpw_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property cpl_id() As Integer
			Get
				Return _cpl_id
			End Get
			Set(ByVal Value As Integer)
				_cpl_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property cpl_id_to() As Integer
			Get
				Return _cpl_id_to
			End Get
			Set(ByVal Value As Integer)
				_cpl_id_to = Value
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
		Protected Sub GetData(ByVal cpw_id As Integer, ByVal loc_na As String)
			Dim _sql As String = GetSelectStatement(cpw_id, loc_na)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Protected Sub GetData(ByVal cpl_id As Integer, ByVal disp_id As Integer, Optional ByVal use_fail_loc As Boolean = False)
			Dim _sql As String = GetSelectStatement(cpl_id, disp_id, use_fail_loc)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Protected Sub GetData(ByVal cpl_id As Integer, Optional ByVal use_fail_loc As Boolean = False)
			Dim _sql As String = GetSelectStatement(cpl_id, 0, use_fail_loc)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Private Sub PopulateObject(ByVal _dr As DataRow)
			_cpw_id = ConvertToSomething(_dr("cpw_id"), 0)
			_cpl_id = ConvertToSomething(_dr("cpl_id"), 0)
			_cpl_id_to = ConvertToSomething(_dr("cpl_id_to"), 0)
			_disp_id = ConvertToSomething(_dr("disp_id"), 0)
			_active = IIf(_dr("active") = 1, True, False)
			_crt_ts = ConvertToSomething(_dr("crt_ts").ToString(), "")
			_crt_user_id = ConvertToSomething(_dr("crt_user_id"), 0)
		End Sub
		Protected Function GetSelectStatement(ByVal cpw_id As Integer, ByVal loc_na As String) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "wf.cpw_id, "
			_sql += "wf.cpl_id, "
			_sql += "wf.cpl_id_to, "
			_sql += "wf.disp_id, "
			_sql += "wf.active, "
			_sql += "wf.crt_ts, "
			_sql += "wf.crt_user_id "
			_sql += "FROM production.tcustomer_prod_workflow wf "
			_sql += "INNER JOIN production.tcustomer_prod_locations cpl on wf.cpl_id = cpl.cpl_id "
			_sql += "WHERE "
			If cpw_id > 0 Then
				_sql += "wf.cpw_id = " & cpw_id.ToString() & " "
			Else
				_sql += "cpl.loc_na = '" & loc_na & "' "
			End If
			_sql += "AND disp_id = 0; "
			Return _sql
		End Function
		Protected Function GetSelectStatement(ByVal cpl_id As Integer, ByVal disp_id As Integer, Optional ByVal use_fail_loc As Boolean = False) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "cpw_id, "
			_sql += "cpl_id, "
			_sql += "cpl_id_to, "
			_sql += "disp_id, "
			_sql += "active, "
			_sql += "crt_ts, "
			_sql += "crt_user_id "
			_sql += "FROM production.tcustomer_prod_workflow "
			_sql += "WHERE cpl_id = " & cpl_id.ToString() & " "
			_sql += "AND disp_id = " & disp_id.ToString() & " "
			If use_fail_loc Then
				_sql += "AND on_fail = 1 "
			Else
				_sql += "AND on_fail = 0 "
			End If
			_sql += "; "
			Return _sql
		End Function

		Public Sub ApplyChanges()
			If _isNew Then
				_cpw_id = Insert()
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
				strSQL = "INSERT INTO production.tcustomer_prod_workflow (" & _
				   "cpl_id, " & _
				   "cpl_id_to, " & _
				   "disp_id, " & _
				   "active, " & _
				   "crt_user_id " & _
				  ") " & _
				  "VALUES ( " & _
				   _cpl_id & " , " & _
				   _cpl_id_to & " , " & _
				   ConvertBackToNullString(_disp_id, False) & " , " & _
				   _active & " , " & _
				   _crt_user_id & "  " & _
				   ")"
				_id = objDataProc.ExecuteScalarForInsert(strSQL, "production.tcustomer_prod_workflow")
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
				strSQL = "UPDATE production.tcustomer_prod_workflow SET " & _
				   "cpw_id = " & ConvertBackToNullString(_cpw_id, False) & ", " & _
				   "cpl_id = " & ConvertBackToNullString(_cpl_id, False) & ", " & _
				   "cpl_id_to = " & ConvertBackToNullString(_cpl_id_to, False) & ", " & _
				   "disp_id = " & ConvertBackToNullString(_disp_id, False) & ", " & _
				   "active = " & IIf(_active, "1", "0") & ", " & _
				   "crt_ts = " & ConvertToMySQLDateOrNullString(_crt_ts) & ", " & _
				   "crt_user_id = " & ConvertBackToNullString(_crt_user_id, False) & ", " & _
				  ") " & _
				  "WHERE cpw_id = " & cpw_id.ToString() & "; "
				Return objDataProc.ExecuteNonQuery(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Function
#End Region
	End Class
	Public Class tcustomer_prod_workflowCollection
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
		Public ReadOnly Property tcustomer_prod_workflowDataTable() As DataTable
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
			_sb.Append("SELECT DISTINCT ")
			_sb.Append("cpw.cpl_id, ")
			_sb.Append("cpw.cpl_id_to, ")
			_sb.Append("cpw.disp_id, ")
			_sb.Append("cpw.active, ")
			_sb.Append("l1.loc_na AS loc_from, ")
			_sb.Append("l2.loc_na AS loc_to, ")
			_sb.Append("disp.disp_na ")
			_sb.Append("FROM production.tcustomer_prod_workflow cpw ")
			_sb.Append("INNER JOIN production.tcustomer_prod_locations l1 ON cpw.cpl_id = l1.cpl_id ")
			_sb.Append("INNER JOIN production.tcustomer_prod_locations l2 ON cpw.cpl_id_to = l2.cpl_id ")
			_sb.Append("LEFT JOIN production.tdispositions disp ON cpw.disp_id = disp.disp_id ")
			_sb.Append("ORDER BY l1.loc_na, disp.disp_na ")
			Return _sb.ToString()
		End Function
#End Region
	End Class
	Public Class tcustomer_prod_WfByLocAndDispCol
#Region "DECLARATIONS"
		Inherits Collections.ArrayList
		Private _objDataProc As DBQuery.DataProc
		Private _dt As New DataTable()
		Private _list As New ArrayList()
#End Region
#Region "CONSTRUCTORS"
		Public Sub New(ByVal cpl_id As Integer, ByVal disp_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(cpl_id, disp_id)
		End Sub
#End Region
#Region "PROPERTIES"
		Public ReadOnly Property tcustomer_prod_workflowDataTable() As DataTable
			Get
				Return _dt
			End Get
		End Property
#End Region
#Region "METHODS"
		Protected Sub GetData(ByVal cpl_id As Integer, ByVal disp_id As Integer)
			Dim _sql As String = GetSelectStatement(cpl_id, disp_id)
			_dt = _objDataProc.GetDataTable(_sql)
		End Sub
		Protected Function GetSelectStatement(ByVal cpl_id As Integer, ByVal disp_id As Integer) As String
			Dim _sb As New StringBuilder()
			_sb.Append("SELECT DISTINCT ")
			_sb.Append("cpw.cpl_id, ")
			_sb.Append("cpw.cpl_id_to, ")
			_sb.Append("cpw.disp_id, ")
			_sb.Append("cpw.active, ")
			_sb.Append("cpl.loc_na ")
			_sb.Append("FROM production.tcustomer_prod_workflow cpw ")
			_sb.Append("INNER JOIN production.tcustomer_prod_locations cpl ON cpw.cpl_id_to = cpl.cpl_id ")
			_sb.Append("WHERE cpw.cpl_id = " & cpl_id.ToString() & " ")
			If disp_id > 0 Then
				_sb.Append("AND disp_id is null or disp_id = " & disp_id.ToString() & " ")
			End If
			Return _sb.ToString()
		End Function
#End Region
	End Class
End Namespace
