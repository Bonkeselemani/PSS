Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic

Namespace BOL

	Public Class tcust_order_item

#Region "DECLARATIONS"

		Private _coi_id As Integer = 0
		Private _co_id As Integer = 0
		Private _prod_id As Integer = 0
		Private _item_nr As String = ""
		Private _qty As Integer = 0
		Private _crt_ts As Date
		Private _crt_by_id As Integer = 0
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

		Public Sub New(ByVal id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(id)
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
		ByVal coi_id As Integer, _
		ByVal co_id As Integer, _
		ByVal prod_id As Integer, _
		ByVal item_nr As String, _
		ByVal qty As Integer, _
		ByVal crt_ts As DateTime, _
		ByVal crt_by_id As Integer _
		 )
			_coi_id = coi_id
			_co_id = co_id
			_prod_id = prod_id
			_item_nr = item_nr
			_qty = qty
			_crt_ts = crt_ts
			_crt_by_id = crt_by_id
		End Sub

#End Region
#Region "PROPERTIES"

		Public Property coi_id() As Integer
			Get
				Return _coi_id
			End Get
			Set(ByVal Value As Integer)
				_coi_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property co_id() As Integer
			Get
				Return _co_id
			End Get
			Set(ByVal Value As Integer)
				_co_id = Value
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
		Public Property item_nr() As String
			Get
				Return _item_nr
			End Get
			Set(ByVal Value As String)
				_item_nr = Value
				_isDirty = True
			End Set
		End Property
		Public Property qty() As Integer
			Get
				Return _qty
			End Get
			Set(ByVal Value As Integer)
				_qty = Value
				_isDirty = True
			End Set
		End Property
		Public Property crt_ts() As Date
			Get
				Return _crt_ts
			End Get
			Set(ByVal Value As Date)
				_crt_ts = Value
				_isDirty = True
			End Set
		End Property
		Public Property crt_by_id() As Integer
			Get
				Return _crt_by_id
			End Get
			Set(ByVal Value As Integer)
				_crt_by_id = Value
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

		Protected Sub GetData(ByVal id As Integer)
			Dim _sql As String = GetSelectStatement(id)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Private Sub PopulateObject(ByVal _dr As DataRow)

			_coi_id = _dr("coi_id").ToString()
			_co_id = _dr("co_id").ToString()
			_prod_id = _dr("prod_id").ToString()
			_item_nr = _dr("item_nr").ToString()
			_qty = _dr("qty").ToString()
			_crt_ts = DirectCast(_dr("crt_ts"), DateTime)
			_crt_by_id = _dr("crt_by_id").ToString()
		End Sub
		Protected Function GetSelectStatement(ByVal ID As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "coi_id, "
			_sql += "co_id, "
			_sql += "prod_id, "
			_sql += "item_nr, "
			_sql += "qty, "
			_sql += "crt_ts, "
			_sql += "crt_by_id "
			_sql += "FROM production.tcust_order_item "
			_sql += "WHERE coi_id = " & ID.ToString() & ""
			Return _sql
		End Function

		Public Sub ApplyChanges()
			If _isNew Then
				_coi_id = Insert()
			ElseIf IsDeleted Then
				' delete
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
				strSQL = "INSERT INTO production.tcust_order_item (" & _
				   "coi_id, " & _
				   "co_id, " & _
				   "prod_id, " & _
				   "item_nr, " & _
				   "qty, " & _
				   "crt_ts, " & _
				   "crt_by_id " & _
				  ") " & _
				  "VALUES ( " & _
				   _coi_id.ToString() & "," & _
				   _co_id.ToString() & "," & _
				   _prod_id.ToString() & "," & _
				   _item_nr.ToString() & "," & _
				   _qty.ToString() & "," & _
				   _crt_ts.ToString() & "," & _
				   _crt_by_id.ToString() & _
				   ")"
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
				strSQL = "UPDATE production.tcust_order_item SET " & _
				   "coi_id = " & ConvertBackToNullString(_coi_id, False) & ", " & _
				   "co_id = " & ConvertBackToNullString(_co_id, False) & ", " & _
				   "prod_id = " & ConvertBackToNullString(_prod_id, False) & ", " & _
				   "item_nr = " & ConvertBackToNullString(_item_nr, False) & ", " & _
				   "qty = " & ConvertBackToNullString(_qty, False) & ", " & _
				   "crt_ts = " & ConvertBackToNullString(_crt_ts, False) & ", " & _
				   "crt_by_id = " & ConvertBackToNullString(_crt_by_id, False) & ", " & _
				  ") " & _
				  "WHERE .coi_id = " & coi_id.ToString() & "; "
				Return objDataProc.ExecuteNonQuery(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

#End Region

	End Class


	Public Class tcust_order_itemCollection
#Region "DECLARATIONS"

		Inherits Collections.ArrayList
		Private _objDataProc As DBQuery.DataProc
		Private _dt As New DataTable()
		Private _list As New ArrayList()

#End Region
#Region "CONSTRUCTORS"

		Public Sub New(ByVal co_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(co_id)
		End Sub

#End Region
#Region "PROPERTIES"

		Public ReadOnly Property tcust_order_itemDataTable() As DataTable
			Get
				Return _dt
			End Get
		End Property

#End Region
#Region "METHODS"

		Protected Sub GetData(ByVal co_id As Integer)
			Dim _sql As String = GetSelectStatement(co_id)
			_dt = _objDataProc.GetDataTable(_sql)
		End Sub

		Protected Function GetSelectStatement(ByVal co_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "coi_id, "
			_sql += "co_id, "
			_sql += "prod_id, "
			_sql += "item_nr, "
			_sql += "qty, "
			_sql += "crt_ts, "
			_sql += "crt_by_id "
			_sql += "FROM production.tcust_order_item "
			_sql += "WHERE co_id = " & co_id.ToString() & ""
			Return _sql
		End Function

#End Region
	End Class

End Namespace