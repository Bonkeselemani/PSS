Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic
Namespace BOL
	Public Class lbillcodes
#Region "DECLARATIONS"
		Private _billcode_id As Integer = 0
		Private _billcode_desc As String = ""
		Private _billcode_rule As Boolean = False
		Private _device_id As Integer = 0
		Private _billtype_id As Integer = 0
		Private _mclaimid As Integer = 0
		Private _fail_id As Integer = 0
		Private _repair_id As Integer = 0
		Private _conv_id As Integer = 0
		Private _atcgrp_id As Integer = 0
		Private _sys_timestamp As String
		Private _aggbill As Boolean = False
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
		Public Sub New(ByVal BillCode_ID As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(BillCode_ID)
			_isDirty = False
			_isNew = False
		End Sub
#End Region
#Region "PROPERTIES"
		Public Property BillCode_ID() As Integer
			Get
				Return _billcode_id
			End Get
			Set(ByVal Value As Integer)
				_billcode_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property BillCode_Desc() As String
			Get
				Return _billcode_desc
			End Get
			Set(ByVal Value As String)
				_billcode_desc = Value
				_isDirty = True
			End Set
		End Property
		Public Property BillCode_Rule() As Boolean
			Get
				Return _billcode_rule
			End Get
			Set(ByVal Value As Boolean)
				_billcode_rule = Value
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
		Public Property BillType_ID() As Integer
			Get
				Return _billtype_id
			End Get
			Set(ByVal Value As Integer)
				_billtype_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property MClaimID() As Integer
			Get
				Return _mclaimid
			End Get
			Set(ByVal Value As Integer)
				_mclaimid = Value
				_isDirty = True
			End Set
		End Property
		Public Property Fail_ID() As Integer
			Get
				Return _fail_id
			End Get
			Set(ByVal Value As Integer)
				_fail_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property Repair_ID() As Integer
			Get
				Return _repair_id
			End Get
			Set(ByVal Value As Integer)
				_repair_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property Conv_ID() As Integer
			Get
				Return _conv_id
			End Get
			Set(ByVal Value As Integer)
				_conv_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property ATCgrp_ID() As Integer
			Get
				Return _atcgrp_id
			End Get
			Set(ByVal Value As Integer)
				_atcgrp_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property sys_timestamp() As String
			Get
				Return _sys_timestamp
			End Get
			Set(ByVal Value As String)
				_sys_timestamp = Value
				_isDirty = True
			End Set
		End Property
		Public Property AggBill() As Boolean
			Get
				Return _aggbill
			End Get
			Set(ByVal Value As Boolean)
				_aggbill = Value
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
		Protected Sub GetData(ByVal BillCode_ID As Integer)
			Dim _sql As String = GetSelectStatement(BillCode_ID)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Private Sub PopulateObject(ByVal _dr As DataRow)

			_billcode_id = ConvertToSomething(_dr("billcode_id"), 0)
			_billcode_desc = ConvertToSomething(_dr("billcode_desc").ToString(), "")
			_billcode_rule = ConvertToSomething(_dr("billcode_rule"), False)
			_device_id = ConvertToSomething(_dr("device_id"), 0)
			_billtype_id = ConvertToSomething(_dr("billtype_id"), 0)
			_mclaimid = ConvertToSomething(_dr("mclaimid"), 0)
			_fail_id = ConvertToSomething(_dr("fail_id"), 0)
			_repair_id = ConvertToSomething(_dr("repair_id"), 0)
			_conv_id = ConvertToSomething(_dr("conv_id"), 0)
			_atcgrp_id = ConvertToSomething(_dr("atcgrp_id"), 0)
			_sys_timestamp = ConvertToSomething(_dr("sys_timestamp").ToString(), "")
			_aggbill = ConvertToSomething(_dr("aggbill"), False)
		End Sub
		Protected Function GetSelectStatement(ByVal BillCode_ID As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "BillCode_ID, "
			_sql += "BillCode_Desc, "
			_sql += "BillCode_Rule, "
			_sql += "Device_ID, "
			_sql += "BillType_ID, "
			_sql += "MClaimID, "
			_sql += "Fail_ID, "
			_sql += "Repair_ID, "
			_sql += "Conv_ID, "
			_sql += "ATCgrp_ID, "
			_sql += "sys_timestamp, "
			_sql += "AggBill "
			_sql += "FROM production.lbillcodes "
			_sql += "WHERE BillCode_ID = " & BillCode_ID.ToString() & ""
			Return _sql
		End Function
		Public Sub ApplyChanges()
			If _isNew Then
				_billcode_id = Insert()
			ElseIf IsDeleted Then
				' delete
				Throw New Exception("Delete not Implemented.")
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
				strSQL = "INSERT INTO production.lbillcodes (" & _
				   "billcode_id, " & _
				   "billcode_desc, " & _
				   "billcode_rule, " & _
				   "device_id, " & _
				   "billtype_id, " & _
				   "mclaimid, " & _
				   "fail_id, " & _
				   "repair_id, " & _
				   "conv_id, " & _
				   "atcgrp_id, " & _
				   "sys_timestamp, " & _
				   "aggbill " & _
				  ") " & _
				  "VALUES ( " & _
				   _billcode_id & " , " & _
				   ConvertBackToNullString(_billcode_desc, False) & " , " & _
				   ConvertBackToNullString(_billcode_rule, False) & " , " & _
				   _device_id & " , " & _
				   ConvertBackToNullString(_billtype_id, False) & " , " & _
				   _mclaimid & " , " & _
				   ConvertBackToNullString(_fail_id, False) & " , " & _
				   ConvertBackToNullString(_repair_id, False) & " , " & _
				   _conv_id & " , " & _
				   ConvertBackToNullString(_atcgrp_id, False) & " , " & _
				   _sys_timestamp & " , " & _
				   ConvertBackToNullString(_aggbill, False) & "  " & _
				   ")"
				_id = objDataProc.ExecuteScalarForInsert(strSQL, "production.lbillcodes")
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
				strSQL = "UPDATE production.lbillcodes SET " & _
				   "billcode_id = " & ConvertBackToNullString(_billcode_id, False) & ", " & _
				   "billcode_desc = " & ConvertBackToNullString(_billcode_desc, False) & ", " & _
				   "billcode_rule = " & ConvertBackToNullString(_billcode_rule, False) & ", " & _
				   "device_id = " & ConvertBackToNullString(_device_id, False) & ", " & _
				   "billtype_id = " & ConvertBackToNullString(_billtype_id, False) & ", " & _
				   "mclaimid = " & ConvertBackToNullString(_mclaimid, False) & ", " & _
				   "fail_id = " & ConvertBackToNullString(_fail_id, False) & ", " & _
				   "repair_id = " & ConvertBackToNullString(_repair_id, False) & ", " & _
				   "conv_id = " & ConvertBackToNullString(_conv_id, False) & ", " & _
				   "atcgrp_id = " & ConvertBackToNullString(_atcgrp_id, False) & ", " & _
				   "sys_timestamp = " & ConvertBackToNullString(_sys_timestamp, False) & ", " & _
				   "aggbill = " & ConvertBackToNullString(_aggbill, False) & ", " & _
				  "WHERE BillCode_ID = " & BillCode_ID.ToString() & "; "
				Return objDataProc.ExecuteNonQuery(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Function
#End Region
	End Class
	Public Class lbillcodesCollection
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
		Public ReadOnly Property lbillcodesDataTable() As DataTable
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
			_sb.Append("BillCode_ID, ")
			_sb.Append("BillCode_Desc, ")
			_sb.Append("BillCode_Rule, ")
			_sb.Append("Device_ID, ")
			_sb.Append("BillType_ID, ")
			_sb.Append("MClaimID, ")
			_sb.Append("Fail_ID, ")
			_sb.Append("Repair_ID, ")
			_sb.Append("Conv_ID, ")
			_sb.Append("ATCgrp_ID, ")
			_sb.Append("sys_timestamp, ")
			_sb.Append("AggBill ")
			_sb.Append("FROM production.lbillcodes; ")
			Return _sb.ToString()
		End Function
#End Region
	End Class
End Namespace
