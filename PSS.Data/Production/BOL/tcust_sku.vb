Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic

Namespace BOL

	Public Class tcust_sku

#Region "DECLARATIONS"

		Private _sku_id As Integer = 0
		Private _cust_id As Integer = 0
		Private _sku_type_decode_id As Integer = 0
		Private _sku_insert_decode_id As Integer = 0
		Private _sku As String = ""
		Private _sku_part_nr As String = ""
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

		Public Sub New(ByVal sku As String)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(sku)
			_isDirty = False
			_isNew = False
		End Sub

		Public Sub New(ByVal start_sn As Integer, ByVal end_sn As Integer)
			' USED TO VALIDATE A RANGE OF SERIAL NUMBERS AGAINST THE SKU.
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(start_sn, end_sn)
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
		ByVal sku_id As Integer, _
		ByVal cust_id As Integer, _
		ByVal sku_type_decode_id As Integer, _
		ByVal sku_insert_decode_id As Integer, _
		ByVal sku As String, _
		ByVal sku_part_nr As String, _
		ByVal crt_ts As DateTime, _
		ByVal crt_by_id As Integer _
		 )
			_sku_id = sku_id
			_cust_id = cust_id
			_sku_type_decode_id = sku_type_decode_id
			_sku_insert_decode_id = sku_insert_decode_id
			_sku = sku
			_sku_part_nr = sku_part_nr
			_crt_ts = crt_ts
			_crt_by_id = crt_by_id
		End Sub

#End Region
#Region "PROPERTIES"

		Public Property sku_id() As Integer
			Get
				Return _sku_id
			End Get
			Set(ByVal Value As Integer)
				_sku_id = Value
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
		Public Property sku_type_decode_id() As Integer
			Get
				Return _sku_type_decode_id
			End Get
			Set(ByVal Value As Integer)
				_sku_type_decode_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property sku_insert_decode_id() As Integer
			Get
				Return _sku_insert_decode_id
			End Get
			Set(ByVal Value As Integer)
				_sku_insert_decode_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property sku() As String
			Get
				Return _sku
			End Get
			Set(ByVal Value As String)
				_sku = Value
				_isDirty = True
			End Set
		End Property
		Public Property sku_part_nr() As String
			Get
				Return _sku_part_nr
			End Get
			Set(ByVal Value As String)
				_sku_part_nr = Value
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
		Protected Sub GetData(ByVal sku As String)
			Dim _sql As String = GetSelectStatement(sku)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Protected Sub GetData(ByVal start_sn As Integer, ByVal end_sn As Integer)
			Dim _sql As String = GetSelectStatement(start_sn, end_sn)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Private Sub PopulateObject(ByVal _dr As DataRow)

			_sku_id = _dr("sku_id").ToString()
			_cust_id = _dr("cust_id").ToString()
			_sku_type_decode_id = _dr("sku_type_decode_id").ToString()
			_sku_insert_decode_id = _dr("sku_insert_decode_id").ToString()
			_sku = _dr("sku").ToString()
			_sku_part_nr = _dr("sku_part_nr").ToString()
			_crt_ts = DirectCast(_dr("crt_ts"), DateTime)
			_crt_by_id = _dr("crt_by_id").ToString()
		End Sub
		Protected Function GetSelectStatement(ByVal ID As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "sku_id, "
			_sql += "cust_id, "
			_sql += "sku_type_decode_id, "
			_sql += "sku_insert_decode_id, "
			_sql += "sku, "
			_sql += "sku_part_nr, "
			_sql += "crt_ts, "
			_sql += "crt_by_id "
			_sql += "FROM production.tcust_sku "
			_sql += "WHERE sku_id = " & ID.ToString() & ""
			Return _sql
		End Function
		Protected Function GetSelectStatement(ByVal sku As String) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "sku_id, "
			_sql += "cust_id, "
			_sql += "sku_type_decode_id, "
			_sql += "sku_insert_decode_id, "
			_sql += "sku, "
			_sql += "sku_part_nr, "
			_sql += "crt_ts, "
			_sql += "crt_by_id "
			_sql += "FROM production.tcust_sku "
			_sql += "WHERE sku = '" & sku & "'"
			Return _sql
		End Function
		Protected Function GetSelectStatement(ByVal start_sn As Integer, ByVal end_sn As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "sku_id, "
			_sql += "cust_id, "
			_sql += "sku_type_decode_id, "
			_sql += "sku_insert_decode_id, "
			_sql += "sku, "
			_sql += "sku_part_nr, "
			_sql += "crt_ts, "
			_sql += "crt_by_id "
			_sql += "FROM production.tcust_sku s "
			_sql += "INNER JOIN production.tcust_sku_range sr ON s.sku_id = sr.sku_id "
			_sql += "WHERE "
			_sql += "'" & start_sn.ToString() & "' BETWEEN sr.skur_start AND sr.skur_end "
			_sql += " AND "
			_sql += end_sn.ToString() & " BETWEEN sr.skur_start AND sr.skur_end; "
			Return _sql
		End Function
		Public Sub ApplyChanges()
			If _isNew Then
				_sku_id = Insert()
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
				strSQL = "INSERT INTO production.tcust_sku (" & _
				   "sku_id, " & _
				   "cust_id, " & _
				   "sku_type_decode_id, " & _
				   "sku_insert_decode_id, " & _
				   "sku, " & _
				   "sku_part_nr, " & _
				   "crt_ts, " & _
				   "crt_by_id " & _
				  ") " & _
				  "VALUES ( " & _
				   _sku_id.ToString() & "," & _
				   _cust_id.ToString() & "," & _
				   _sku_type_decode_id.ToString() & "," & _
				   _sku_insert_decode_id.ToString() & "," & _
				   _sku.ToString() & "," & _
				   _sku_part_nr.ToString() & "," & _
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
				strSQL = "UPDATE production.tcust_sku SET " & _
				   "sku_id = " & ConvertBackToNullString(_sku_id, False) & ", " & _
				   "cust_id = " & ConvertBackToNullString(_cust_id, False) & ", " & _
				   "sku_type_decode_id = " & ConvertBackToNullString(_sku_type_decode_id, False) & ", " & _
				   "sku_insert_decode_id = " & ConvertBackToNullString(_sku_insert_decode_id, False) & ", " & _
				   "sku = " & ConvertBackToNullString(_sku, False) & ", " & _
				   "sku_part_nr = " & ConvertBackToNullString(_sku_part_nr, False) & ", " & _
				   "crt_ts = " & ConvertBackToNullString(_crt_ts, False) & ", " & _
				   "crt_by_id = " & ConvertBackToNullString(_crt_by_id, False) & ", " & _
				  ") " & _
				  "WHERE .sku_id = " & sku_id.ToString() & "; "
				Return objDataProc.ExecuteNonQuery(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

#End Region

	End Class

	Public Class tcust_skuCollection

#Region "DECLARATIONS"

		Inherits Collections.ArrayList
		Private _objDataProc As DBQuery.DataProc
		Private _dt As New DataTable()
		Private _list As New ArrayList()

#End Region
#Region "CONSTRUCTORS"

		Public Sub New(ByVal cust_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(cust_id)
		End Sub

#End Region
#Region "PROPERTIES"

		Public ReadOnly Property tcust_skuDataTable() As DataTable
			Get
				Return _dt
			End Get
		End Property

#End Region
#Region "METHODS"

		Protected Sub GetData(ByVal cust_id As Integer)
			Dim _sql As String = GetSelectStatement(cust_id)
			_dt = _objDataProc.GetDataTable(_sql)
		End Sub

		Protected Function GetSelectStatement(ByVal cust_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "sku_id, "
			_sql += "cust_id, "
			_sql += "sku_type_decode_id, "
			_sql += "sku_insert_decode_id, "
			_sql += "sku, "
			_sql += "sku_part_nr, "
			_sql += "crt_ts, "
			_sql += "crt_by_id "
			_sql += "FROM production.tcust_sku "
			_sql += "WHERE cust_id = " & cust_id.ToString() & ""
			Return _sql
		End Function

#End Region

	End Class

End Namespace