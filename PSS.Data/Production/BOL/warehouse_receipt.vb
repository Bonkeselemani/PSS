Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic

Namespace BOL

	Public Class warehouse_receipt

#Region "DECLARATIONS"

		Private _wr_id As Integer = 0
		Private _wr_name As String = ""
		Private _rf_id As Integer = 0
		Private _sc_id As Integer = 0
		Private _tracking As String = ""
		Private _account As String = ""
		Private _receipt_date As String
		Private _receipt_qty As Integer = 0
		Private _closed As Boolean = False
		Private _user_id As Integer = 0
		Private _cust_id As Integer = 0
		Private _loc_id As Integer = 0
		Private _rma As String = ""
		Private _wo_id As Integer = 0
		Private _isNew As System.Boolean = True
		Private _isDirty As System.Boolean = False
		Private _isDeleted As System.Boolean = False
		Private _isValid As System.Boolean = False
		Private _objDataProc As DBQuery.DataProc

		Private _cur_user_id As Integer

#End Region
#Region "CONSTRUCTORS"

		Public Sub New(ByVal user_id As Integer)
			_isNew = True
			_cur_user_id = user_id
		End Sub

		Public Sub New(ByVal wr_id As Integer, ByVal user_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(wr_id)
			_isDirty = False
			_isNew = False
			_cur_user_id = user_id
		End Sub


		Public Sub New(ByVal dr As DataRow)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			PopulateObject(dr)
			_isDirty = False
			_isNew = False
		End Sub
		Public Sub New( _
		ByVal wr_id As Integer, _
		ByVal wr_name As String, _
		ByVal rf_id As Integer, _
		ByVal sc_id As Integer, _
		ByVal tracking As String, _
		ByVal account As String, _
		ByVal receipt_date As String, _
		ByVal receipt_qty As Integer, _
		ByVal closed As Boolean, _
		ByVal user_id As Integer, _
		ByVal cust_id As Integer, _
		ByVal loc_id As Integer, _
		ByVal rma As String, _
		ByVal wo_id As Integer _
		 )
			_wr_id = wr_id
			_wr_name = wr_name
			_rf_id = rf_id
			_sc_id = sc_id
			_tracking = tracking
			_account = account
			_receipt_date = receipt_date
			_receipt_qty = receipt_qty
			_closed = closed
			_user_id = user_id
			_cust_id = cust_id
			_loc_id = loc_id
			_rma = rma
			_wo_id = wo_id
		End Sub

#End Region
#Region "PROPERTIES"

		Public Property WR_ID() As Integer
			Get
				Return _wr_id
			End Get
			Set(ByVal Value As Integer)
				_wr_id = value
				_isDirty = True
			End Set
		End Property
		Public Property WR_Name() As String
			Get
				Return _wr_name
			End Get
			Set(ByVal Value As String)
				_wr_name = value
				_isDirty = True
			End Set
		End Property
		Public Property RF_ID() As Integer
			Get
				Return _rf_id
			End Get
			Set(ByVal Value As Integer)
				_rf_id = value
				_isDirty = True
			End Set
		End Property
		Public Property SC_ID() As Integer
			Get
				Return _sc_id
			End Get
			Set(ByVal Value As Integer)
				_sc_id = value
				_isDirty = True
			End Set
		End Property
		Public Property Tracking() As String
			Get
				Return _tracking
			End Get
			Set(ByVal Value As String)
				_tracking = value
				_isDirty = True
			End Set
		End Property
		Public Property Account() As String
			Get
				Return _account
			End Get
			Set(ByVal Value As String)
				_account = value
				_isDirty = True
			End Set
		End Property
		Public Property Receipt_Date() As String
			Get
				Return _receipt_date
			End Get
			Set(ByVal Value As String)
				_receipt_date = value
				_isDirty = True
			End Set
		End Property
		Public Property Receipt_QTY() As Integer
			Get
				Return _receipt_qty
			End Get
			Set(ByVal Value As Integer)
				_receipt_qty = value
				_isDirty = True
			End Set
		End Property
		Public Property Closed() As Boolean
			Get
				Return _closed
			End Get
			Set(ByVal Value As Boolean)
				_closed = value
				_isDirty = True
			End Set
		End Property
		Public Property User_ID() As Integer
			Get
				Return _user_id
			End Get
			Set(ByVal Value As Integer)
				_user_id = value
				_isDirty = True
			End Set
		End Property
		Public Property Cust_ID() As Integer
			Get
				Return _cust_id
			End Get
			Set(ByVal Value As Integer)
				_cust_id = value
				_isDirty = True
			End Set
		End Property
		Public Property Loc_ID() As Integer
			Get
				Return _loc_id
			End Get
			Set(ByVal Value As Integer)
				_loc_id = value
				_isDirty = True
			End Set
		End Property
		Public Property RMA() As String
			Get
				Return _rma
			End Get
			Set(ByVal Value As String)
				_rma = value
				_isDirty = True
			End Set
		End Property
		Public Property WO_ID() As Integer
			Get
				Return _wo_id
			End Get
			Set(ByVal Value As Integer)
				_wo_id = value
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

		Protected Sub GetData(ByVal wr_id As Integer)
			Dim _sql As String = GetSelectStatement(wr_id)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Private Sub PopulateObject(ByVal _dr As DataRow)

			_wr_id = _dr("wr_id").ToString()
			_wr_name = ConvertToSomething(_dr("wr_name").ToString(), "")
			_rf_id = _dr("rf_id").ToString()
			_sc_id = _dr("sc_id").ToString()
			_tracking = ConvertToSomething(_dr("tracking").ToString(), "")
			_account = ConvertToSomething(_dr("account").ToString(), "")
			_receipt_date = ConvertToSomething(_dr("receipt_date").ToString(), "")
			_receipt_qty = _dr("receipt_qty").ToString()
			_closed = DirectCast(ConvertToSomething(_dr("closed"), False), Boolean)
			_user_id = _dr("user_id").ToString()
			_cust_id = _dr("cust_id").ToString()
			_loc_id = _dr("loc_id").ToString()
			_rma = ConvertToSomething(_dr("rma").ToString(), "")
			_wo_id = _dr("wo_id").ToString()
		End Sub
		Protected Function GetSelectStatement(ByVal wr_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "WR_ID, "
			_sql += "WR_Name, "
			_sql += "RF_ID, "
			_sql += "SC_ID, "
			_sql += "Tracking, "
			_sql += "Account, "
			_sql += "Receipt_Date, "
			_sql += "Receipt_QTY, "
			_sql += "Closed, "
			_sql += "User_ID, "
			_sql += "Cust_ID, "
			_sql += "Loc_ID, "
			_sql += "RMA, "
			_sql += "WO_ID "
			_sql += "FROM production.warehouse_receipt "
			_sql += "WHERE wr_id = " & wr_id.ToString() & ""
			Return _sql
		End Function

		Public Sub ApplyChanges()
			Try
				If _isNew Then
					_wr_id = Insert()
				ElseIf IsDeleted Then
					' delete
				ElseIf IsDirty Then
					' Update
				End If
			Catch ex As Exception
				Throw ex
			End Try
		End Sub

		Protected Function Insert() As Integer
			Dim strSQL, strToday As String
			Try
				Dim _objDataProc As DBQuery.DataProc
				Dim _id As Integer
				_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
				strToday = PSS.Data.Buisness.Generic.GetMySqlDateTime("%Y-%m-%d")
				strSQL = "INSERT INTO warehouse.warehouse_receipt (" & _
				   "wr_id, " & _
				   "wr_name, " & _
				   "rf_id, " & _
				   "sc_id, " & _
				   "tracking, " & _
				   "account, " & _
				   "receipt_date, " & _
				   "receipt_qty, " & _
				   "closed, " & _
				   "user_id, " & _
				   "cust_id, " & _
				   "loc_id, " & _
				   "rma, " & _
				   "wo_id " & _
				  ") " & _
				  "VALUES ( " & _
				   _wr_id.ToString() & " , " & _
				   ConvertBackToNullString(_wr_name, True) & " , " & _
				   _rf_id.ToString() & " , " & _
				   _sc_id.ToString() & " , " & _
				   "'" & _tracking.ToString & "' , " & _
				   ConvertBackToNullString(_account, True) & " , " & _
				   ConvertToMySQLDateOrNullString(_receipt_date) & " , " & _
				   _receipt_qty.ToString() & " , " & _
				   IIf(_closed, "1", "0") & " , " & _
				   _cur_user_id.ToString() & " , " & _
				   _cust_id.ToString() & " , " & _
				   _loc_id.ToString() & " , " & _
				   ConvertBackToNullString(_rma, False) & " , " & _
				   ConvertBackToNullString(_wo_id, False) & "  " & _
				   ")"
				_wr_id = _id
				_id = _objDataProc.ExecuteScalarForInsert(strSQL, "warehouse.warehouse_receipt")
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
				strSQL = "UPDATE production.warehouse_receipt SET " & _
				   "wr_id = " & ConvertBackToNullString(_wr_id, False) & ", " & _
				   "wr_name = " & ConvertBackToNullString(_wr_name, False) & ", " & _
				   "rf_id = " & ConvertBackToNullString(_rf_id, False) & ", " & _
				   "sc_id = " & ConvertBackToNullString(_sc_id, False) & ", " & _
				   "tracking = " & ConvertBackToNullString(_tracking, False) & ", " & _
				   "account = " & ConvertBackToNullString(_account, False) & ", " & _
				   "receipt_date = " & ConvertBackToNullString(_receipt_date, False) & ", " & _
				   "receipt_qty = " & ConvertBackToNullString(_receipt_qty, False) & ", " & _
				   "closed = " & ConvertBackToNullString(_closed, False) & ", " & _
				   "user_id = " & ConvertBackToNullString(_user_id, False) & ", " & _
				   "cust_id = " & ConvertBackToNullString(_cust_id, False) & ", " & _
				   "loc_id = " & ConvertBackToNullString(_loc_id, False) & ", " & _
				   "rma = " & ConvertBackToNullString(_rma, False) & ", " & _
				   "wo_id = " & ConvertBackToNullString(_wo_id, False) & ", " & _
				  ") " & _
				  "WHERE WR_ID = " & WR_ID.ToString() & "; "
				Return objDataProc.ExecuteNonQuery(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

#End Region

	End Class


	Public Class warehouse_receiptCollection
#Region "DECLARATIONS"

		Inherits Collections.ArrayList
		Private _objDataProc As DBQuery.DataProc
		Private _dt As New DataTable()
		Private _list As New ArrayList()

#End Region
#Region "CONSTRUCTORS"

		Public Sub New(ByVal loc_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(loc_id)
		End Sub

#End Region
#Region "PROPERTIES"

		Public ReadOnly Property warehouse_receiptDataTable() As DataTable
			Get
				Return _dt
			End Get
		End Property

#End Region
#Region "METHODS"

		Protected Sub GetData(ByVal loc_id As Integer)
			Dim _sql As String = GetSelectStatement(loc_id)
			_dt = _objDataProc.GetDataTable(_sql)
		End Sub

		Protected Function GetSelectStatement(ByVal loc_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "WR_ID, "
			_sql += "WR_Name, "
			_sql += "RF_ID, "
			_sql += "SC_ID, "
			_sql += "Tracking, "
			_sql += "Account, "
			_sql += "Receipt_Date, "
			_sql += "Receipt_QTY, "
			_sql += "Closed, "
			_sql += "User_ID, "
			_sql += "Cust_ID, "
			_sql += "Loc_ID, "
			_sql += "RMA, "
			_sql += "WO_ID "
			_sql += "FROM production.warehouse_receipt "
			_sql += "WHERE Loc_ID = " & loc_id.ToString() & ""
			Return _sql
		End Function

#End Region
	End Class

End Namespace
