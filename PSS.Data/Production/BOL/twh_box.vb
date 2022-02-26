Imports System
Imports System.Collections
Imports System.Text
Imports System.String
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic

Namespace BOL

	Public Class wh_box
#Region "DECLARATIONS"

		Private _whb_id As Integer = 0
		Private _box_na As String = ""
		Private _model_id As Integer = 0
		Private _closed As Boolean = False
		Private _ship_date As String = ""
		Private _quantity As Integer = 0
		Private _cust_id As Integer = 0
		Private _crt_ts As String = ""
		Private _crt_user_id As Integer = 0
		Private _bin_id As Integer = 0
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

		Public Sub New(ByVal whb_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(whb_id)
			_isDirty = False
			_isNew = False
		End Sub

		Public Sub New(ByVal box_na As String)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(box_na)
			_isDirty = False
			_isNew = False
		End Sub

#End Region
#Region "PROPERTIES"

		Public Property whb_id() As Integer
			Get
				Return _whb_id
			End Get
			Set(ByVal Value As Integer)
				_whb_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property box_na() As String
			Get
				Return _box_na
			End Get
			Set(ByVal Value As String)
				_box_na = Value
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
		Public Property closed() As Boolean
			Get
				Return _closed
			End Get
			Set(ByVal Value As Boolean)
				_closed = Value
				_isDirty = True
			End Set
		End Property
		Public Property ship_date() As String
			Get
				Return _ship_date
			End Get
			Set(ByVal Value As String)
				_ship_date = Value
				_isDirty = True
			End Set
		End Property
		Public Property quantity() As Integer
			Get
				Return _quantity
			End Get
			Set(ByVal Value As Integer)
				_quantity = Value
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
		Public Property bin_id() As Integer
			Get
				Return _bin_id
			End Get
			Set(ByVal Value As Integer)
				_bin_id = Value
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

		Protected Sub GetData(ByVal whb_id As Integer)
			Dim _sql As String = GetSelectStatement(whb_id)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Protected Sub GetData(ByVal box_na As String)
			Dim _sql As String = GetSelectStatement(box_na)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Private Sub PopulateObject(ByVal _dr As DataRow)
			_whb_id = ConvertToSomething(_dr("whb_id"), 0)
			_box_na = ConvertToSomething(_dr("box_na").ToString(), "")
			_model_id = ConvertToSomething(_dr("model_id"), 0)
			_closed = IIf(_dr("closed") = 1, True, False)
			_ship_date = ConvertToSomething(_dr("ship_date").ToString(), "")
			_quantity = _dr("quantity").ToString()
			_cust_id = ConvertToSomething(_dr("cust_id"), 0)
			_bin_id = ConvertToSomething(_dr("bin_id"), 0)
			_crt_ts = ConvertToSomething(_dr("crt_ts").ToString(), "")
			_crt_user_id = _dr("crt_user_id")
		End Sub
		Protected Function GetSelectStatement(ByVal whb_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "whb_id, "
			_sql += "box_na, "
			_sql += "model_id, "
			_sql += "closed, "
			_sql += "ship_date, "
			_sql += "quantity, "
			_sql += "cust_id, "
			_sql += "bin_id, "
			_sql += "crt_ts, "
			_sql += "crt_user_id "
			_sql += "FROM warehouse.wh_box "
			_sql += "WHERE whb_id = " & whb_id.ToString() & ""
			Return _sql
		End Function
		Protected Function GetSelectStatement(ByVal box_na As String) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "whb_id, "
			_sql += "box_na, "
			_sql += "model_id, "
			_sql += "closed, "
			_sql += "ship_date, "
			_sql += "quantity, "
			_sql += "cust_id, "
			_sql += "bin_id, "
			_sql += "crt_ts, "
			_sql += "crt_user_id "
			_sql += "FROM warehouse.wh_box "
			_sql += "WHERE box_na = '" & box_na & "'; "
			Return _sql
		End Function
		Public Sub ApplyChanges()
			If _isNew Then
				_whb_id = Insert()
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
				strSQL = "INSERT INTO warehouse.wh_box (" & _
				   "whb_id, " & _
				   "box_na, " & _
				   "model_id, " & _
				   "closed, " & _
				   "ship_date, " & _
				   "quantity, " & _
				   "cust_id, " & _
				   "crt_user_id " & _
				  ") " & _
				  "VALUES ( " & _
				   _whb_id & " , '" & _
				   _box_na & "' , " & _
				   _model_id & " , " & _
				   IIf(_closed, 1, 0) & " , " & _
				   ConvertToMySQLDateOrNullString(_ship_date) & " , " & _
				   _quantity & " , " & _
				   _cust_id & " , " & _
				   _crt_user_id & "  " & _
				   ")"
				_id = objDataProc.ExecuteScalarForInsert(strSQL, "warehouse.wh_box")
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
				strSQL = "UPDATE warehouse.wh_box SET " & _
				   "box_na = " & ConvertBackToNullString(_box_na, True) & ", " & _
				   "model_id = " & ConvertBackToNullString(_model_id, False) & ", " & _
				   "closed = " & IIf(_closed, 1, 0) & ", " & _
				   "ship_date = " & ConvertToMySQLDateOrNullString(_ship_date) & ", " & _
				   "quantity = " & ConvertBackToNullString(_quantity, False) & ", " & _
				   "cust_id = " & ConvertBackToNullString(_cust_id, False) & ", " & _
				   "bin_id = " & ConvertBackToNullString(_bin_id, False) & ", " & _
				   "crt_ts = " & ConvertToMySQLDateOrNullString(_crt_ts) & " " & _
				  "WHERE whb_id = " & whb_id.ToString() & "; "
				Return objDataProc.ExecuteNonQuery(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

#End Region
	End Class

	Public Class wh_box_readonly
#Region "DECLARATIONS"

		Private _whb_id As Integer = 0
		Private _box_na As String = ""
		Private _model_id As Integer = 0
		Private _model_desc As String
		Private _closed As Boolean = False
		Private _ship_date As String = ""
		Private _quantity As Integer = 0
		Private _cust_id As Integer = 0
		Private _cust_name As String = ""
		Private _bin_id As Integer = 0
		Private _crt_ts As String = ""
		Private _crt_user_id As Integer = 0
		Private _crt_user_name As String = ""
		Private _objDataProc As DBQuery.DataProc
#End Region
#Region "CONSTRUCTORS"

		Public Sub New(ByVal sn As String)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(sn)
		End Sub

#End Region
#Region "PROPERTIES"

		Public ReadOnly Property whb_id() As Integer
			Get
				Return _whb_id
			End Get
		End Property
		Public ReadOnly Property box_na() As String
			Get
				Return _box_na
			End Get
		End Property
		Public ReadOnly Property model_id() As Integer
			Get
				Return _model_id
			End Get
		End Property
		Public ReadOnly Property model_desc() As String
			Get
				Return _model_desc
			End Get
		End Property
		Public ReadOnly Property closed() As Boolean
			Get
				Return _closed
			End Get
		End Property
		Public ReadOnly Property ship_date() As String
			Get
				Return _ship_date
			End Get
		End Property
		Public ReadOnly Property quantity() As Integer
			Get
				Return _quantity
			End Get
		End Property
		Public ReadOnly Property cust_id() As Integer
			Get
				Return _cust_id
			End Get
		End Property
		Public ReadOnly Property cust_name() As String
			Get
				Return _cust_name
			End Get
		End Property
		Public ReadOnly Property bin_id() As Integer
			Get
				Return _bin_id
			End Get
		End Property
		Public ReadOnly Property crt_ts() As String
			Get
				Return _crt_ts
			End Get
		End Property
		Public ReadOnly Property crt_user_id() As Integer
			Get
				Return _crt_user_id
			End Get
		End Property
		Public ReadOnly Property crt_user_name() As String
			Get
				Return _crt_user_name
			End Get
		End Property

#End Region
#Region "METHODS"

		Protected Sub GetData(ByVal sn As String)
			Dim _sql As String = GetSelectStatement(sn)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Private Sub PopulateObject(ByVal _dr As DataRow)
			_whb_id = _dr("whb_id").ToString()
			_box_na = ConvertToSomething(_dr("box_na").ToString(), "")
			_model_id = _dr("model_id").ToString()
			_model_desc = _dr("model_desc").ToString()
			_closed = IIf(_dr("closed") = 1, True, False)
			_ship_date = ConvertToSomething(_dr("ship_date").ToString(), "")
			_quantity = _dr("quantity").ToString()
			_cust_id = _dr("cust_id").ToString()
			_cust_name = _dr("cust_name1").ToString()
			_bin_id = ConvertToSomething(_dr("bin_id"), 0)
			_crt_ts = ConvertToSomething(_dr("crt_ts").ToString(), "")
			_crt_user_id = _dr("crt_user_id").ToString()
			_crt_user_name = _dr("user_name").ToString()
		End Sub
		Protected Function GetSelectStatement(ByVal sn As String) As String
			Dim _sb As New StringBuilder()
			_sb.Append("SELECT ")
			_sb.Append("wb.whb_id, ")
			_sb.Append("wb.box_na, ")
			_sb.Append("wb.model_id, ")
			_sb.Append("m.model_desc, ")
			_sb.Append("wb.closed, ")
			_sb.Append("wb.ship_date, ")
			_sb.Append("wb.quantity, ")
			_sb.Append("wb.cust_id, ")
			_sb.Append("c.cust_name1, ")
			_sb.Append("wb.bin_id, ")
			_sb.Append("wb.crt_ts, ")
			_sb.Append("wb.crt_user_id, ")
			_sb.Append("u.user_name ")
			_sb.Append("FROM warehouse.wh_box wb  ")
			_sb.Append("INNER JOIN production.tmodel m ON wb.model_id = m.model_id ")
			_sb.Append("INNER JOIN production.tcustomer c ON wb.cust_id = c.cust_id ")
			_sb.Append("INNER JOIN edi.titem itm ON wb.whb_id = itm.whb_id ")
			_sb.Append("LEFT JOIN security.tusers u ON wb.crt_user_id = u.user_id ")
			_sb.Append("WHERE itm.sn = '" & sn & "'")
			Return _sb.ToString()
		End Function

#End Region
	End Class

	Public Class wh_boxCollection
#Region "DECLARATIONS"

		Inherits Collections.ArrayList
		Private _objDataProc As DBQuery.DataProc
		Private _dt As New DataTable()
		Private _list As New ArrayList()

#End Region
#Region "CONSTRUCTORS"

		Public Sub New(ByVal ship_date As String)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(ship_date)
		End Sub

#End Region
#Region "PROPERTIES"

		Public ReadOnly Property wh_boxDataTable() As DataTable
			Get
				Return _dt
			End Get
		End Property

#End Region
#Region "METHODS"

		Protected Sub GetData(ByVal ship_date As String)
			Dim _sql As String = GetSelectStatement(ship_date)
			_dt = _objDataProc.GetDataTable(_sql)
		End Sub

		Protected Function GetSelectStatement(ByVal ship_date As String) As String
			Dim _sb As New StringBuilder()
			_sb.Append("SELECT ")
			_sb.Append("whb_id, ")
			_sb.Append("box_na, ")
			_sb.Append("model_id, ")
			_sb.Append("closed, ")
			_sb.Append("ship_date, ")
			_sb.Append("quantity, ")
			_sb.Append("cust_id, ")
			_sb.Append("bin_id, ")
			_sb.Append("crt_ts, ")
			_sb.Append("crt_user_id ")
			_sb.Append("FROM warehouse.wh_box ")
			_sb.Append("WHERE ship_date = " & ship_date & " ")
			Return _sb.ToString()
		End Function

#End Region
	End Class

	Public Class wh_box_whwip_with_loc_collection
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

		Public ReadOnly Property wh_boxDataTable() As DataTable
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
			_sb.Append("wb.whb_id, ")
			_sb.Append("wb.box_na, ")
			_sb.Append("m.model_desc, ")
			_sb.Append("wb.quantity, ")
			_sb.Append("b.bin_na ")
			_sb.Append("FROM warehouse.wh_box wb ")
			_sb.Append("INNER JOIN warehouse.wh_bins b ON wb.bin_id = b.bin_id ")
			_sb.Append("INNER JOIN production.tmodel m ON wb.model_id = m.model_id ")
			_sb.Append("WHERE wb.bin_id IS NOT NULL ")
			_sb.Append("ORDER BY wb.box_na; ")
			Return _sb.ToString()
		End Function

#End Region
	End Class

	Public Class wh_box_whwip_no_loc_collection
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

		Public ReadOnly Property wh_boxDataTable() As DataTable
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
			_sb.Append("wb.whb_id, ")
			_sb.Append("wb.box_na, ")
			_sb.Append("m.model_desc, ")
			_sb.Append("wb.quantity ")
			_sb.Append("FROM warehouse.wh_box wb ")
			_sb.Append("INNER JOIN production.tmodel m ON wb.model_id = m.model_id ")
			_sb.Append("WHERE wb.bin_id IS NULL ")
			_sb.Append("ORDER BY wb.box_na; ")
			Return _sb.ToString()
		End Function

#End Region
	End Class

	Public Class twh_boxMaxNumber
#Region "DECLARATIONS"

		Private _objDataProc As DBQuery.DataProc
		Private _dt As New DataTable()
		Private _LastBoxNr As String = ""

#End Region
#Region "CONSTRUCTORS"

		Public Sub New(ByVal BoxPrefix As String)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(BoxPrefix)
		End Sub

#End Region
#Region "PROPERTIES"

		Public ReadOnly Property LastBoxNr() As String
			Get
				Return _LastBoxNr
			End Get
		End Property

		Public ReadOnly Property NextBoxNr() As String
			Get
				Dim _retVal As String
				Dim _prefix As String
				Dim _incr As String
				_prefix = Left(_LastBoxNr, 11)
				_incr = PadZeros(4, (Right(_LastBoxNr, 4) + 1))
				_retVal = _prefix & _incr
				Return _retVal
			End Get
		End Property

#End Region
#Region "METHODS"

		Protected Sub GetData(ByVal BoxPrefix As String)
			Dim _sql As String = GetSelectStatement(BoxPrefix)
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				_LastBoxNr = _dt.Rows(0)("box_na").ToString()
			Else
				_LastBoxNr = BoxPrefix & "0000"
			End If
		End Sub

		Protected Function GetSelectStatement(ByVal BoxPrefix As String) As String
			Dim _sb As New StringBuilder()
			_sb.Append("SELECT DISTINCT ")
			_sb.Append("box_na ")
			_sb.Append("FROM warehouse.wh_box ")
			_sb.Append("WHERE box_na like '" & BoxPrefix & "%' ")
			_sb.Append("ORDER BY whb_id DESC; ")
			Return _sb.ToString()
		End Function

		Private Function PadZeros(ByVal length As Integer, ByVal value As Integer) As String
			Dim _fmt As String = ""
			Dim _retVal As String = ""
			Dim i As Integer = 0
			For i = 1 To length
				_fmt = Concat(_fmt, "0")
			Next
			_retVal = value.ToString(_fmt)
			Return _retVal
		End Function

#End Region
	End Class

End Namespace
