Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic

Namespace BOL

	Public Class tcustaggregatebilling

#Region "DECLARATIONS"

		Private _tcab_id As Integer = 0
		Private _billcode_id As Integer = 0
		Private _tcab_amount As System.Double = 0
		Private _cust_id As Integer = 0
		Private _lastupdatedt As String
		Private _lastupdateuserid As Integer = 0
		Private _startdate As String
		Private _enddate As String
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

		Public Sub New(ByVal Cust_ID As Integer, ByVal billcode_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(Cust_ID, billcode_id)
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
		ByVal tcab_id As Integer, _
		ByVal billcode_id As Integer, _
		ByVal tcab_amount As System.Double, _
		ByVal cust_id As Integer, _
		ByVal lastupdatedt As String, _
		ByVal lastupdateuserid As Integer, _
		ByVal startdate As String, _
		ByVal enddate As String _
		 )
			_tcab_id = tcab_id
			_billcode_id = billcode_id
			_tcab_amount = tcab_amount
			_cust_id = cust_id
			_lastupdatedt = lastupdatedt
			_lastupdateuserid = lastupdateuserid
			_startdate = startdate
			_enddate = enddate
		End Sub

#End Region
#Region "PROPERTIES"

		Public Property tcab_ID() As Integer
			Get
				Return _tcab_id
			End Get
			Set(ByVal Value As Integer)
				_tcab_id = value
				_isDirty = True
			End Set
		End Property
		Public Property billcode_id() As Integer
			Get
				Return _billcode_id
			End Get
			Set(ByVal Value As Integer)
				_billcode_id = value
				_isDirty = True
			End Set
		End Property
		Public Property tcab_Amount() As System.Double
			Get
				Return _tcab_amount
			End Get
			Set(ByVal Value As System.Double)
				_tcab_amount = value
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
		Public Property LastUpdateDT() As String
			Get
				Return _lastupdatedt
			End Get
			Set(ByVal Value As String)
				_lastupdatedt = value
				_isDirty = True
			End Set
		End Property
		Public Property LastUpdateUserID() As Integer
			Get
				Return _lastupdateuserid
			End Get
			Set(ByVal Value As Integer)
				_lastupdateuserid = value
				_isDirty = True
			End Set
		End Property
		Public Property StartDate() As String
			Get
				Return _startdate
			End Get
			Set(ByVal Value As String)
				_startdate = value
				_isDirty = True
			End Set
		End Property
		Public Property EndDate() As String
			Get
				Return _enddate
			End Get
			Set(ByVal Value As String)
				_enddate = value
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

		Protected Sub GetData(ByVal Cust_ID As Integer, ByVal billcode_id As Integer)
			Dim _sql As String = GetSelectStatement(Cust_ID, billcode_id)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Private Sub PopulateObject(ByVal _dr As DataRow)

			_tcab_id = ConvertToSomething(_dr("tcab_id"), 0)
			_billcode_id = ConvertToSomething(_dr("billcode_id"), 0)
			_tcab_amount = _dr("tcab_amount")
			_cust_id = ConvertToSomething(_dr("cust_id"), 0)
			_lastupdatedt = ConvertToSomething(_dr("lastupdatedt").ToString(), "")
			_lastupdateuserid = _dr("lastupdateuserid").ToString()
			_startdate = ConvertToSomething(_dr("startdate").ToString(), "")
			_enddate = ConvertToSomething(_dr("enddate").ToString(), "")
		End Sub
		Protected Function GetSelectStatement(ByVal Cust_ID As Integer, ByVal billcode_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "tcab_ID, "
			_sql += "billcode_id, "
			_sql += "tcab_Amount, "
			_sql += "Cust_ID, "
			_sql += "LastUpdateDT, "
			_sql += "LastUpdateUserID, "
			_sql += "StartDate, "
			_sql += "EndDate "
			_sql += "FROM production.tcustaggregatebilling "
			_sql += "WHERE cust_id = " & Cust_ID.ToString() & " "
			_sql += "AND billcode_id = " & billcode_id.ToString() & "; "
			Return _sql
		End Function

		Public Sub ApplyChanges()
			If _isNew Then
				_tcab_id = Insert()
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
				strSQL = "INSERT INTO production.tcustaggregatebilling (" & _
				   "tcab_id, " & _
				   "billcode_id, " & _
				   "tcab_amount, " & _
				   "cust_id, " & _
				   "lastupdatedt, " & _
				   "lastupdateuserid, " & _
				   "startdate, " & _
				   "enddate " & _
				  ") " & _
				  "VALUES ( " & _
				   _tcab_id & " , " & _
				   ConvertBackToNullString(_billcode_id, False) & " , " & _
				   ConvertBackToNullString(_tcab_amount, False) & " , " & _
				   ConvertBackToNullString(_cust_id, False) & " , " & _
				   ConvertBackToNullString(_lastupdatedt, False) & " , " & _
				   _lastupdateuserid & " , " & _
				   ConvertBackToNullString(_startdate, False) & " , " & _
				   ConvertBackToNullString(_enddate, False) & "  " & _
				   ")"
				_id = objDataProc.ExecuteScalarForInsert(strSQL, "production.tcustaggregatebilling")
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
				strSQL = "UPDATE production.tcustaggregatebilling SET " & _
				   "tcab_id = " & ConvertBackToNullString(_tcab_id, False) & ", " & _
				   "billcode_id = " & ConvertBackToNullString(_billcode_id, False) & ", " & _
				   "tcab_amount = " & ConvertBackToNullString(_tcab_amount, False) & ", " & _
				   "cust_id = " & ConvertBackToNullString(_cust_id, False) & ", " & _
				   "lastupdatedt = " & ConvertBackToNullString(_lastupdatedt, False) & ", " & _
				   "lastupdateuserid = " & ConvertBackToNullString(_lastupdateuserid, False) & ", " & _
				   "startdate = " & ConvertBackToNullString(_startdate, False) & ", " & _
				   "enddate = " & ConvertBackToNullString(_enddate, False) & ", " & _
				  "WHERE tcab_ID = " & tcab_ID.ToString() & "; "
				Return objDataProc.ExecuteNonQuery(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

#End Region

	End Class


	Public Class tcustaggregatebillingCollection
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

		Public ReadOnly Property tcustaggregatebillingDataTable() As DataTable
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
			_sb.Append("tcab_ID, ")
			_sb.Append("billcode_id, ")
			_sb.Append("tcab_Amount, ")
			_sb.Append("Cust_ID, ")
			_sb.Append("LastUpdateDT, ")
			_sb.Append("LastUpdateUserID, ")
			_sb.Append("StartDate, ")
			_sb.Append("EndDate ")
			_sb.Append("FROM production.tcustaggregatebilling; ")
			Return _sb.ToString()
		End Function

#End Region
	End Class

End Namespace
