Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic

Namespace BOL

	Public Class twarehousebox

#Region "DECLARATIONS"

		Private _wb_id As Integer = 0
		Private _boxid As String = ""
		Private _funcrep As Integer = 0
		Private _wrtyexpedite As Integer = 0
		Private _warrantyflag As Integer = 0
		Private _model_id As Integer = 0
		Private _order_id As Integer = 0
		Private _closed As Integer = 0
		Private _whlocation As String = ""
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

		Public Sub New(ByVal wb_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(wb_id)
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
		ByVal wb_id As Integer, _
		ByVal boxid As String, _
		ByVal funcrep As Integer, _
		ByVal wrtyexpedite As Integer, _
		ByVal warrantyflag As Integer, _
		ByVal model_id As Integer, _
		ByVal order_id As Integer, _
		ByVal closed As Integer, _
		ByVal whlocation As String _
		 )
			_wb_id = wb_id
			_boxid = boxid
			_funcrep = funcrep
			_wrtyexpedite = wrtyexpedite
			_warrantyflag = warrantyflag
			_model_id = model_id
			_order_id = order_id
			_closed = closed
			_whlocation = whlocation
		End Sub

#End Region
#Region "PROPERTIES"

		Public Property wb_id() As Integer
			Get
				Return _wb_id
			End Get
			Set(ByVal Value As Integer)
				_wb_id = value
				_isDirty = True
			End Set
		End Property
		Public Property BoxID() As String
			Get
				Return _boxid
			End Get
			Set(ByVal Value As String)
				_boxid = value
				_isDirty = True
			End Set
		End Property
		Public Property FuncRep() As Integer
			Get
				Return _funcrep
			End Get
			Set(ByVal Value As Integer)
				_funcrep = value
				_isDirty = True
			End Set
		End Property
		Public Property WrtyExpedite() As Integer
			Get
				Return _wrtyexpedite
			End Get
			Set(ByVal Value As Integer)
				_wrtyexpedite = value
				_isDirty = True
			End Set
		End Property
		Public Property WarrantyFlag() As Integer
			Get
				Return _warrantyflag
			End Get
			Set(ByVal Value As Integer)
				_warrantyflag = value
				_isDirty = True
			End Set
		End Property
		Public Property Model_ID() As Integer
			Get
				Return _model_id
			End Get
			Set(ByVal Value As Integer)
				_model_id = value
				_isDirty = True
			End Set
		End Property
		Public Property Order_ID() As Integer
			Get
				Return _order_id
			End Get
			Set(ByVal Value As Integer)
				_order_id = value
				_isDirty = True
			End Set
		End Property
		Public Property Closed() As Integer
			Get
				Return _closed
			End Get
			Set(ByVal Value As Integer)
				_closed = value
				_isDirty = True
			End Set
		End Property
		Public Property WHLocation() As String
			Get
				Return _whlocation
			End Get
			Set(ByVal Value As String)
				_whlocation = value
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

		Protected Sub GetData(ByVal wb_id As Integer)
			Dim _sql As String = GetSelectStatement(wb_id)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Private Sub PopulateObject(ByVal _dr As DataRow)

			_wb_id = _dr("wb_id").ToString()
			_boxid = ConvertToSomething(_dr("boxid").ToString(), "")
			_funcrep = _dr("funcrep").ToString()
			_wrtyexpedite = DirectCast(ConvertToSomething(_dr("wrtyexpedite"), 0), Integer)
			_warrantyflag = _dr("warrantyflag").ToString()
			_model_id = _dr("model_id").ToString()
			_order_id = _dr("order_id").ToString()
			_closed = _dr("closed").ToString()
			_whlocation = ConvertToSomething(_dr("whlocation").ToString(), "")
		End Sub
		Protected Function GetSelectStatement(ByVal wb_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "wb_id, "
			_sql += "BoxID, "
			_sql += "FuncRep, "
			_sql += "WrtyExpedite, "
			_sql += "WarrantyFlag, "
			_sql += "Model_ID, "
			_sql += "Order_ID, "
			_sql += "Closed, "
			_sql += "WHLocation "
			_sql += "FROM production.twarehousebox "
			_sql += "WHERE wb_id = " & wb_id.ToString() & ""
			Return _sql
		End Function

		Public Sub ApplyChanges()
			If _isNew Then
				_wb_id = Insert()
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
				strSQL = "INSERT INTO production.twarehousebox (" & _
				   "wb_id, " & _
				   "boxid, " & _
				   "funcrep, " & _
				   "wrtyexpedite, " & _
				   "warrantyflag, " & _
				   "model_id, " & _
				   "order_id, " & _
				   "closed, " & _
				   "whlocation " & _
				  ") " & _
				  "VALUES ( " & _
				   _wb_id & " , " & _
				   ConvertBackToNullString(_boxid, False) & " , " & _
				   _funcrep & " , " & _
				   _wrtyexpedite & " , " & _
				   _warrantyflag & " , " & _
				   ConvertBackToNullString(_model_id, False) & " , " & _
				   ConvertBackToNullString(_order_id, False) & " , " & _
				   _closed & " , " & _
				   _whlocation & "  " & _
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
				strSQL = "UPDATE production.twarehousebox SET " & _
				   "wb_id = " & ConvertBackToNullString(_wb_id, False) & ", " & _
				   "boxid = " & ConvertBackToNullString(_boxid, False) & ", " & _
				   "funcrep = " & ConvertBackToNullString(_funcrep, False) & ", " & _
				   "wrtyexpedite = " & ConvertBackToNullString(_wrtyexpedite, False) & ", " & _
				   "warrantyflag = " & ConvertBackToNullString(_warrantyflag, False) & ", " & _
				   "model_id = " & ConvertBackToNullString(_model_id, False) & ", " & _
				   "order_id = " & ConvertBackToNullString(_order_id, False) & ", " & _
				   "closed = " & ConvertBackToNullString(_closed, False) & ", " & _
				   "whlocation = " & ConvertBackToNullString(_whlocation, False) & ", " & _
				  ") " & _
				  "WHERE wb_id = " & wb_id.ToString() & "; "
				Return objDataProc.ExecuteNonQuery(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

#End Region

	End Class


	Public Class twarehouseboxCollection
#Region "DECLARATIONS"

		Inherits Collections.ArrayList
		Private _objDataProc As DBQuery.DataProc
		Private _dt As New DataTable()
		Private _list As New ArrayList()
		Private _maxBoxNr As Integer = 0

#End Region
#Region "CONSTRUCTORS"

		Public Sub New(ByVal BoxPrefix As String)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(BoxPrefix)
		End Sub

#End Region
#Region "PROPERTIES"

		Public ReadOnly Property twarehouseboxDataTable() As DataTable
			Get
				Return _dt
			End Get
		End Property

		Public ReadOnly Property MaxBoxNr() As String
			Get
				Return _maxBoxNr
			End Get
		End Property

#End Region
#Region "METHODS"

		Protected Sub GetData(ByVal BoxPrefix As String)
			Dim _sql As String = GetSelectStatement(BoxPrefix)
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				_maxBoxNr = Mid(_dt.Rows(0)("boxid"), 8, 4)
			End If
		End Sub

		Protected Function GetSelectStatement(ByVal BoxPrefix As String) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "wb_id, "
			_sql += "BoxID, "
			_sql += "FuncRep, "
			_sql += "WrtyExpedite, "
			_sql += "WarrantyFlag, "
			_sql += "Model_ID, "
			_sql += "Order_ID, "
			_sql += "Closed, "
			_sql += "WHLocation "
			_sql += "FROM production.twarehousebox "
			_sql += "WHERE SUBSTRING(boxid,1,8) = '" & BoxPrefix & "' "
			_sql += "ORDER BY wb_id DESC "
			Return _sql
		End Function

#End Region
	End Class

	Public Class twarehouseMaxBoxNumber
#Region "DECLARATIONS"

		Private _objDataProc As DBQuery.DataProc
		Private _dt As New DataTable()
		Private _LastBoxNr As Integer = 0

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
				Dim _incr As Integer
				_prefix = Left(_LastBoxNr, 10)
				_incr = (Right(_LastBoxNr, 4) + 1)
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
				_LastBoxNr = _dt.Rows(0)("boxid").ToString()
			End If
		End Sub

		Protected Function GetSelectStatement(ByVal BoxPrefix As String) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "max(boxid) "
			_sql += "BoxID, "
			_sql += "FuncRep, "
			_sql += "WrtyExpedite, "
			_sql += "WarrantyFlag, "
			_sql += "Model_ID, "
			_sql += "Order_ID, "
			_sql += "Closed, "
			_sql += "WHLocation "
			_sql += "FROM edi.twarehousebox "
			_sql += "WHERE BoxID like '" & BoxPrefix & "%' "
			Return _sql
		End Function

#End Region
	End Class

End Namespace
