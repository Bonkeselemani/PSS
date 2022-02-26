Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic

Namespace BOL

	Public Class tDeviceBill
#Region "DECLARATIONS"

		Private _dbill_id As Integer = 0
		Private _dbill_regpartprice As Decimal = 0
		Private _dbill_avgcost As Decimal = 0
		Private _dbill_stdcost As Decimal = 0
		Private _dbill_invoiceamt As Decimal = 0
		Private _device_id As Integer = 0
		Private _billcode_id As Integer = 0
		Private _part_number As String = ""
		Private _fail_id As Integer = 0
		Private _repair_id As Integer = 0
		Private _comp_id As Integer = 0
		Private _user_id As Integer = 0
		Private _date_rec As String
		Private _replpartsn As String = ""
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

		Public Sub New(ByVal dbill_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(dbill_id)
			_isDirty = False
			_isNew = False
			_isDeleted = False
		End Sub

		Public Sub New(ByVal dr As DataRow)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			PopulateObject(dr)
			_isDirty = False
			_isNew = False
		End Sub
		Public Sub New( _
		ByVal dbill_id As Int32, _
		ByVal dbill_regpartprice As Decimal, _
		ByVal dbill_avgcost As Decimal, _
		ByVal dbill_stdcost As Decimal, _
		ByVal dbill_invoiceamt As Decimal, _
		ByVal device_id As Int32, _
		ByVal billcode_id As Int32, _
		ByVal part_number As String, _
		ByVal fail_id As Int32, _
		ByVal repair_id As Int32, _
		ByVal comp_id As Int32, _
		ByVal user_id As Int32, _
		ByVal date_rec As String, _
		ByVal replpartsn As String _
		 )
			_dbill_id = dbill_id
			_dbill_regpartprice = dbill_regpartprice
			_dbill_avgcost = dbill_avgcost
			_dbill_stdcost = dbill_stdcost
			_dbill_invoiceamt = dbill_invoiceamt
			_device_id = device_id
			_billcode_id = billcode_id
			_part_number = part_number
			_fail_id = fail_id
			_repair_id = repair_id
			_comp_id = comp_id
			_user_id = user_id
			_date_rec = date_rec
			_replpartsn = replpartsn
			_isDirty = True
			_isNew = True
			_isDeleted = False
		End Sub

#End Region
#Region "PROPERTIES"

		Public Property DBill_ID() As Integer
			Get
				Return _dbill_id
			End Get
			Set(ByVal Value As Integer)
				_dbill_id = Value
			End Set
		End Property
		Public Property DBill_RegPartPrice() As Decimal
			Get
				Return _dbill_regpartprice
			End Get
			Set(ByVal Value As Decimal)
				_dbill_regpartprice = Value
			End Set
		End Property
		Public Property DBill_AvgCost() As Decimal
			Get
				Return _dbill_avgcost
			End Get
			Set(ByVal Value As Decimal)
				_dbill_avgcost = Value
			End Set
		End Property
		Public Property DBill_StdCost() As Decimal
			Get
				Return _dbill_stdcost
			End Get
			Set(ByVal Value As Decimal)
				_dbill_stdcost = Value
			End Set
		End Property
		Public Property DBill_InvoiceAmt() As Decimal
			Get
				Return _dbill_invoiceamt
			End Get
			Set(ByVal Value As Decimal)
				_dbill_invoiceamt = Value
			End Set
		End Property
		Public Property Device_ID() As Integer
			Get
				Return _device_id
			End Get
			Set(ByVal Value As Integer)
				_device_id = Value
			End Set
		End Property
		Public Property BillCode_ID() As Integer
			Get
				Return _billcode_id
			End Get
			Set(ByVal Value As Integer)
				_billcode_id = Value
			End Set
		End Property
		Public Property Part_Number() As String
			Get
				Return _part_number
			End Get
			Set(ByVal Value As String)
				_part_number = Value
			End Set
		End Property
		Public Property Fail_ID() As Integer
			Get
				Return _fail_id
			End Get
			Set(ByVal Value As Integer)
				_fail_id = Value
			End Set
		End Property
		Public Property Repair_ID() As Integer
			Get
				Return _repair_id
			End Get
			Set(ByVal Value As Integer)
				_repair_id = Value
			End Set
		End Property
		Public Property Comp_ID() As Integer
			Get
				Return _comp_id
			End Get
			Set(ByVal Value As Integer)
				_comp_id = Value
			End Set
		End Property
		Public Property User_ID() As Integer
			Get
				Return _user_id
			End Get
			Set(ByVal Value As Integer)
				_user_id = Value
			End Set
		End Property
		Public Property Date_Rec() As String
			Get
				Return _date_rec
			End Get
			Set(ByVal Value As String)
				_date_rec = Value
			End Set
		End Property
		Public Property ReplPartSN() As String
			Get
				Return _replpartsn
			End Get
			Set(ByVal Value As String)
				_replpartsn = Value
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
		Protected Sub GetData(ByVal dbill_id As Integer)
			Dim _sql As String = GetSelectStatement(dbill_id)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Private Sub PopulateObject(ByVal _dr As DataRow)
			_dbill_id = ConvertToSomething(_dr("dbill_id"), 0)
			_dbill_regpartprice = ConvertToSomething(_dr("dbill_regpartprice"), 0.0)
			_dbill_avgcost = ConvertToSomething(_dr("dbill_avgcost"), 0.0)
			_dbill_stdcost = ConvertToSomething(_dr("dbill_stdcost"), 0.0)
			_dbill_invoiceamt = ConvertToSomething(_dr("dbill_invoiceamt"), 0.0)
			_device_id = ConvertToSomething(_dr("device_id"), 0)
			_billcode_id = ConvertToSomething(_dr("billcode_id"), 0)
			_part_number = _dr("part_number").ToString()
			_fail_id = ConvertToSomething(_dr("fail_id"), 0)
			_repair_id = ConvertToSomething(_dr("repair_id"), 0)
			_comp_id = ConvertToSomething(_dr("comp_id"), 0)
			_user_id = ConvertToSomething(_dr("user_id"), 0)
			_date_rec = _dr("date_rec").ToString()
			_replpartsn = _dr("replpartsn").ToString()
		End Sub
		Protected Function GetSelectStatement(ByVal dbill_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "DBill_ID, "
			_sql += "DBill_RegPartPrice, "
			_sql += "DBill_AvgCost, "
			_sql += "DBill_StdCost, "
			_sql += "DBill_InvoiceAmt, "
			_sql += "Device_ID, "
			_sql += "BillCode_ID, "
			_sql += "Part_Number, "
			_sql += "Fail_ID, "
			_sql += "Repair_ID, "
			_sql += "Comp_ID, "
			_sql += "User_ID, "
			_sql += "Date_Rec, "
			_sql += "ReplPartSN "
			_sql += "FROM tdevicebill "
			_sql += "WHERE dbill_id = " & dbill_id.ToString() & "; "
			Return _sql
		End Function
		Public Sub MarkForDelete()
			_isDeleted = True
		End Sub
		Public Sub ApplyChanges()
			If _isNew Then
				_dbill_id = Insert()
			ElseIf IsDeleted Then
				Delete()
			ElseIf IsDirty Then
				'Update()
			End If
		End Sub
		Protected Function Insert() As Integer
			Dim strSQL, strToday As String
			Try
				Dim objDataProc As DBQuery.DataProc
				Dim _id As Integer
				objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
				strToday = PSS.Data.Buisness.Generic.GetMySqlDateTime("%Y-%m-%d")
				strSQL = "INSERT INTO production.tdevicebill ( " & _
				 "dbill_regpartprice, " & _
				 "dbill_avgcost, " & _
				 "dbill_stdcost, " & _
				 "dbill_invoiceamt, " & _
				 "device_id, " & _
				 "billcode_id, " & _
				 "part_number, " & _
				 "fail_id, " & _
				 "repair_id, " & _
				 "comp_id, " & _
				 "user_id, " & _
				 "date_rec, " & _
				 "ReplPartSN " & _
				 ") " & _
				 "VALUES ( " & _
				_dbill_regpartprice & ", " & _
				ConvertBackToNullString(_dbill_avgcost, False) & ", " & _
				ConvertBackToNullString(_dbill_stdcost, False) & ", " & _
				ConvertBackToNullString(_dbill_invoiceamt, False) & ", " & _
				_device_id & ", " & _
				_billcode_id & ", " & _
				ConvertBackToNullString(_part_number.ToString(), True) & ", " & _
				_fail_id.ToString() & ", " & _
				_repair_id.ToString() & ", " & _
				_comp_id.ToString() & ", " & _
				_user_id.ToString() & ", " & _
				"'" & strToday & "', " & _
				"'" & _replpartsn & "' " & _
				") "
				_id = objDataProc.ExecuteScalarForInsert(strSQL, "production.tdevicebill")
				'_dbill_id = _id
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
			Throw New Exception("Not Implemented")
		End Function
		Protected Function Delete() As Integer
			Dim strSQL, strToday As String
			Try
				Dim objDataProc As DBQuery.DataProc
				Dim _cnt As Integer
				objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
				strToday = PSS.Data.Buisness.Generic.GetMySqlDateTime("%Y-%m-%d")
				strSQL = " DELETE FROM production.tdevicebill WHERE dbill_id = " & _dbill_id.ToString() & "; "
				_cnt = objDataProc.ExecuteNonQuery(strSQL)
				Return _cnt
			Catch ex As Exception
				Throw ex
				Return 0
			End Try
		End Function
#End Region
	End Class
	Public Class tDeviceBillCollection
#Region "DECLARATIONS"

		Inherits Collections.ArrayList
		Private _objDataProc As DBQuery.DataProc
		Private _dt As New DataTable()
		Private _list As New ArrayList()

#End Region
#Region "CONSTRUCTORS"

		Public Sub New(ByVal device_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(device_id)
		End Sub

#End Region
#Region "PROPERTIES"

		Public ReadOnly Property tDeviceBillDataTable() As DataTable
			Get
				Return _dt
			End Get
		End Property

#End Region
#Region "METHODS"

		Protected Sub GetData(ByVal device_id As Integer)
			Dim _sql As String = GetSelectStatement(device_id)
			_dt = _objDataProc.GetDataTable(_sql)
		End Sub

		Protected Function GetSelectStatement(ByVal device_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "DBill_ID, "
			_sql += "DBill_RegPartPrice, "
			_sql += "DBill_AvgCost, "
			_sql += "DBill_StdCost, "
			_sql += "DBill_InvoiceAmt, "
			_sql += "Device_ID, "
			_sql += "BillCode_ID, "
			_sql += "Part_Number, "
			_sql += "Fail_ID, "
			_sql += "Repair_ID, "
			_sql += "Comp_ID, "
			_sql += "User_ID, "
			_sql += "Date_Rec, "
			_sql += "ReplPartSN "
			_sql += "FROM tdevicebill "
			_sql += "WHERE device_id = " & device_id.ToString() & ""
			Return _sql
		End Function

		Public Sub RemoveAllBillingForDeviceID(ByVal device_id As Integer)
			Dim sql As String = GetDeleteStatementForDeviceID(device_id)
			Try
				_objDataProc.ExecuteNonQuery(sql)
			Catch ex As Exception
				Throw ex
			End Try
		End Sub

		Protected Function GetDeleteStatementForDeviceID(ByVal device_id As Integer) As String
			Dim _sql As String
			_sql = "DELETE FROM production.tdevicebill "
			_sql += "WHERE device_id = " & device_id.ToString() & ""
			Return _sql
		End Function

#End Region
	End Class
	Public Class tDeviceBill_Shared
		Public Sub New()
		End Sub
#Region "PUBLIC"

		Public Shared Function RemoveAllBillingForDevice(ByVal device_id As Integer) As Boolean
			Dim sql As String = GetBillingDeleteStatementForDevice(device_id)
			Try
				Dim _objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
				_objDataProc.ExecuteNonQuery(sql)
				Return True
			Catch ex As Exception
				Throw ex
			End Try
		End Function

#End Region
#Region "PRIVATE"

		Private Shared Function GetBillingDeleteStatementForDevice(ByVal device_id As Integer) As String
			Dim _sql As String
			_sql = "DELETE FROM production.tdevicebill "
			_sql += "WHERE device_id = " & device_id.ToString() & ""
			Return _sql
		End Function

#End Region
	End Class
	Public Class tDeviceBillShared
#Region "SHARED FUNCTIONS"
		Public Shared Function GetInvAmtForDevice(ByVal device_id As Integer) As Decimal
			Dim _objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			Dim _dt As New DataTable()
			Dim _retval As Decimal = 0.0
			Dim _sql As String = "SELECT SUM(dbill_invoiceamt) as inv_amt FROM tdevicebill WHERE device_id = " & device_id.ToString() & "; "
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				_retval = IIf(_dt.Rows(0)("inv_amt") Is System.DBNull.Value, 0.0, _dt.Rows(0)("inv_amt"))
			End If
			_objDataProc = Nothing
			_dt = Nothing
			Return _retval
		End Function
#End Region
	End Class
End Namespace
