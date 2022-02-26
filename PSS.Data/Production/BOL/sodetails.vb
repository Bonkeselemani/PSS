Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic

Namespace BOL

	Public Class sodetails
#Region "DECLARATIONS"

		Private _sodetailsid As Integer = 0
		Private _soheaderid As Integer = 0
		Private _lineitemnumber As Integer = 0
		Private _itemcode As String = ""
		Private _productname As String = ""
		Private _quantity As Integer = 0
		Private _unitofmeasure As String = ""
		Private _baseprice As Decimal = 0
		Private _currencycode As String = ""
		Private _linetax1 As Decimal = 0
		Private _linetax2 As Decimal = 0
		Private _linetax3 As Decimal = 0
		Private _upc As String = ""
		Private _linediscount As Decimal = 0
		Private _returnfedextrackingnumber As String = ""
		Private _sku As String = ""
		Private _shipquantity As Integer = 0
		Private _model_id As Integer = 0
		Private _devconditionid As Integer = 0
		Private _cosmgradeid As Integer = 0
		Private _linelaborcharge As Decimal = 0
		Private _requiredsn As Integer = 0
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
		Public Sub New(ByVal SOHeaderID As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(SOHeaderID)
			_isDirty = False
			_isNew = False
		End Sub

#End Region
#Region "PROPERTIES"

		Public Property SODetailsID() As Integer
			Get
				Return _sodetailsid
			End Get
			Set(ByVal Value As Integer)
				_sodetailsid = Value
				_isDirty = True
			End Set
		End Property
		Public Property SOHeaderID() As Integer
			Get
				Return _soheaderid
			End Get
			Set(ByVal Value As Integer)
				_soheaderid = Value
				_isDirty = True
			End Set
		End Property
		Public Property LineItemNumber() As Integer
			Get
				Return _lineitemnumber
			End Get
			Set(ByVal Value As Integer)
				_lineitemnumber = Value
				_isDirty = True
			End Set
		End Property
		Public Property ItemCode() As String
			Get
				Return _itemcode
			End Get
			Set(ByVal Value As String)
				_itemcode = Value
				_isDirty = True
			End Set
		End Property
		Public Property ProductName() As String
			Get
				Return _productname
			End Get
			Set(ByVal Value As String)
				_productname = Value
				_isDirty = True
			End Set
		End Property
		Public Property Quantity() As Integer
			Get
				Return _quantity
			End Get
			Set(ByVal Value As Integer)
				_quantity = Value
				_isDirty = True
			End Set
		End Property
		Public Property UnitOfMeasure() As String
			Get
				Return _unitofmeasure
			End Get
			Set(ByVal Value As String)
				_unitofmeasure = Value
				_isDirty = True
			End Set
		End Property
		Public Property BasePrice() As Decimal
			Get
				Return _baseprice
			End Get
			Set(ByVal Value As Decimal)
				_baseprice = Value
				_isDirty = True
			End Set
		End Property
		Public Property CurrencyCode() As String
			Get
				Return _currencycode
			End Get
			Set(ByVal Value As String)
				_currencycode = Value
				_isDirty = True
			End Set
		End Property
		Public Property LineTax1() As Decimal
			Get
				Return _linetax1
			End Get
			Set(ByVal Value As Decimal)
				_linetax1 = Value
				_isDirty = True
			End Set
		End Property
		Public Property LineTax2() As Decimal
			Get
				Return _linetax2
			End Get
			Set(ByVal Value As Decimal)
				_linetax2 = Value
				_isDirty = True
			End Set
		End Property
		Public Property LineTax3() As Decimal
			Get
				Return _linetax3
			End Get
			Set(ByVal Value As Decimal)
				_linetax3 = Value
				_isDirty = True
			End Set
		End Property
		Public Property UPC() As String
			Get
				Return _upc
			End Get
			Set(ByVal Value As String)
				_upc = Value
				_isDirty = True
			End Set
		End Property
		Public Property LineDiscount() As Decimal
			Get
				Return _linediscount
			End Get
			Set(ByVal Value As Decimal)
				_linediscount = Value
				_isDirty = True
			End Set
		End Property
		Public Property ReturnFedExTrackingNumber() As String
			Get
				Return _returnfedextrackingnumber
			End Get
			Set(ByVal Value As String)
				_returnfedextrackingnumber = Value
				_isDirty = True
			End Set
		End Property
		Public Property SKU() As String
			Get
				Return _sku
			End Get
			Set(ByVal Value As String)
				_sku = Value
				_isDirty = True
			End Set
		End Property
		Public Property ShipQuantity() As Integer
			Get
				Return _shipquantity
			End Get
			Set(ByVal Value As Integer)
				_shipquantity = Value
				_isDirty = True
			End Set
		End Property
		Public Property Model_ID() As Integer
			Get
				Return _model_id
			End Get
			Set(ByVal Value As Integer)
				_model_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property DevConditionID() As Integer
			Get
				Return _devconditionid
			End Get
			Set(ByVal Value As Integer)
				_devconditionid = Value
				_isDirty = True
			End Set
		End Property
		Public Property CosmGradeID() As Integer
			Get
				Return _cosmgradeid
			End Get
			Set(ByVal Value As Integer)
				_cosmgradeid = Value
				_isDirty = True
			End Set
		End Property
		Public Property LineLaborCharge() As Decimal
			Get
				Return _linelaborcharge
			End Get
			Set(ByVal Value As Decimal)
				_linelaborcharge = Value
				_isDirty = True
			End Set
		End Property
		Public Property RequiredSN() As Integer
			Get
				Return _requiredsn
			End Get
			Set(ByVal Value As Integer)
				_requiredsn = Value
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

		Protected Sub GetData(ByVal SOHeaderID As Integer)
			Dim _sql As String = GetSelectStatement(SOHeaderID)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Private Sub PopulateObject(ByVal _dr As DataRow)
			_sodetailsid = ConvertToSomething(_dr("sodetailsid"), 0)
			_soheaderid = ConvertToSomething(_dr("soheaderid"), 0)
			_lineitemnumber = ConvertToSomething(_dr("lineitemnumber"), 0)
			_itemcode = ConvertToSomething(_dr("itemcode").ToString(), "")
			_productname = ConvertToSomething(_dr("productname").ToString(), "")
			_quantity = ConvertToSomething(_dr("quantity"), 0)
			_unitofmeasure = ConvertToSomething(_dr("unitofmeasure").ToString(), "")
			_baseprice = ConvertToSomething(_dr("baseprice"), 0.0)
			_currencycode = ConvertToSomething(_dr("currencycode").ToString(), "")
			_linetax1 = ConvertToSomething(_dr("linetax1"), 0.0)
			_linetax2 = ConvertToSomething(_dr("linetax2"), 0.0)
			_linetax3 = ConvertToSomething(_dr("linetax3"), 0.0)
			_upc = ConvertToSomething(_dr("upc").ToString(), "")
			_linediscount = ConvertToSomething(_dr("linediscount"), 0.0)
			_returnfedextrackingnumber = ConvertToSomething(_dr("returnfedextrackingnumber").ToString(), "")
			_sku = ConvertToSomething(_dr("sku").ToString(), "")
			_shipquantity = ConvertToSomething(_dr("shipquantity"), 0)
			_model_id = ConvertToSomething(_dr("model_id"), 0)
			_devconditionid = ConvertToSomething(_dr("devconditionid"), 0)
			_cosmgradeid = ConvertToSomething(_dr("cosmgradeid"), 0)
			_linelaborcharge = ConvertToSomething(_dr("linelaborcharge"), 0.0)
			_requiredsn = ConvertToSomething(_dr("requiredsn").ToString(), 0)
		End Sub
		Protected Function GetSelectStatement(ByVal SOHeaderID As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "SODetailsID, "
			_sql += "SOHeaderID, "
			_sql += "LineItemNumber, "
			_sql += "ItemCode, "
			_sql += "ProductName, "
			_sql += "Quantity, "
			_sql += "UnitOfMeasure, "
			_sql += "BasePrice, "
			_sql += "CurrencyCode, "
			_sql += "LineTax1, "
			_sql += "LineTax2, "
			_sql += "LineTax3, "
			_sql += "UPC, "
			_sql += "LineDiscount, "
			_sql += "ReturnFedExTrackingNumber, "
			_sql += "SKU, "
			_sql += "ShipQuantity, "
			_sql += "Model_ID, "
			_sql += "DevConditionID, "
			_sql += "CosmGradeID, "
			_sql += "LineLaborCharge, "
			_sql += "RequiredSN "
			_sql += "FROM saleorders.sodetails "
			_sql += "WHERE sodetailsid = " & SOHeaderID.ToString() & ""
			Return _sql
		End Function
		Public Sub ApplyChanges()
			If _isNew Then
				Throw New Exception("SODetails Insert not Implemented.")
				'_sodetailsid = Insert()
			ElseIf IsDeleted Then
				Throw New Exception("SODetails Delete not Implemented.")
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
				strSQL = "INSERT INTO saleorders.sodetails (" & _
				   "sodetailsid, " & _
				   "soheaderid, " & _
				   "lineitemnumber, " & _
				   "itemcode, " & _
				   "productname, " & _
				   "quantity, " & _
				   "unitofmeasure, " & _
				   "baseprice, " & _
				   "currencycode, " & _
				   "linetax1, " & _
				   "linetax2, " & _
				   "linetax3, " & _
				   "upc, " & _
				   "linediscount, " & _
				   "returnfedextrackingnumber, " & _
				   "sku, " & _
				   "shipquantity, " & _
				   "model_id, " & _
				   "devconditionid, " & _
				   "cosmgradeid, " & _
				   "linelaborcharge, " & _
				   "requiredsn " & _
				  ") " & _
				  "VALUES ( " & _
				   _sodetailsid & " , " & _
				   _soheaderid & " , " & _
				   _lineitemnumber & " , " & _
				   _itemcode & " , " & _
				   _productname & " , " & _
				   _quantity & " , " & _
				   _unitofmeasure & " , " & _
				   ConvertBackToNullString(_baseprice, False) & " , " & _
				   _currencycode & " , " & _
				   _linetax1 & " , " & _
				   _linetax2 & " , " & _
				   ConvertBackToNullString(_linetax3, False) & " , " & _
				   _upc & " , " & _
				   _linediscount & " , " & _
				   _returnfedextrackingnumber & " , " & _
				   _sku & " , " & _
				   _shipquantity & " , " & _
				   _model_id & " , " & _
				   _devconditionid & " , " & _
				   _cosmgradeid & " , " & _
				   _linelaborcharge & " , " & _
				   _requiredsn & "  " & _
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
				strSQL = "UPDATE saleorders.sodetails SET " & _
				   "sodetailsid = " & ConvertBackToNullString(_sodetailsid, False) & ", " & _
				   "soheaderid = " & ConvertBackToNullString(_soheaderid, False) & ", " & _
				   "lineitemnumber = " & ConvertBackToNullString(_lineitemnumber, False) & ", " & _
				   "itemcode = " & ConvertBackToNullString(_itemcode, True) & ", " & _
				   "productname = " & ConvertBackToNullString(_productname, True) & ", " & _
				   "quantity = " & ConvertBackToNullString(_quantity, False) & ", " & _
				   "unitofmeasure = " & ConvertBackToNullString(_unitofmeasure, True) & ", " & _
				   "baseprice = " & ConvertBackToNullString(_baseprice, False) & ", " & _
				   "currencycode = " & ConvertBackToNullString(_currencycode, True) & ", " & _
				   "linetax1 = " & ConvertBackToNullString(_linetax1, False) & ", " & _
				   "linetax2 = " & ConvertBackToNullString(_linetax2, False) & ", " & _
				   "linetax3 = " & ConvertBackToNullString(_linetax3, False) & ", " & _
				   "upc = " & ConvertBackToNullString(_upc, True) & ", " & _
				   "linediscount = " & ConvertBackToNullString(_linediscount, False) & ", " & _
				   "returnfedextrackingnumber = " & ConvertBackToNullString(_returnfedextrackingnumber, True) & ", " & _
				   "sku = " & ConvertBackToNullString(_sku, True) & ", " & _
				   "shipquantity = " & ConvertBackToNullString(_shipquantity, False) & ", " & _
				   "model_id = " & ConvertBackToNullString(_model_id, False) & ", " & _
				   "devconditionid = " & ConvertBackToNullString(_devconditionid, False) & ", " & _
				   "cosmgradeid = " & ConvertBackToNullString(_cosmgradeid, False) & ", " & _
				   "linelaborcharge = " & ConvertBackToNullString(_linelaborcharge, False) & ", " & _
				   "requiredsn = " & ConvertBackToNullString(_requiredsn, False) & ", " & _
				  ") " & _
				  "WHERE SOHearderID = " & _soheaderid.ToString() & "; "
				Return objDataProc.ExecuteNonQuery(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

#End Region
	End Class

	Public Class sodetailsCollection
#Region "DECLARATIONS"

		Inherits Collections.ArrayList
		Private _objDataProc As DBQuery.DataProc
		Private _dt As New DataTable()
		Private _list As New ArrayList()

#End Region
#Region "CONSTRUCTORS"

		Public Sub New(ByVal soheaderid As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(soheaderid)
		End Sub

#End Region
#Region "PROPERTIES"

		Public ReadOnly Property sodetailsDataTable() As DataTable
			Get
				Return _dt
			End Get
		End Property

#End Region
#Region "METHODS"

		Protected Sub GetData(ByVal soheaderid As Integer)
			Dim _sql As String = GetSelectStatement(soheaderid)
			_dt = _objDataProc.GetDataTable(_sql)
		End Sub

		Protected Function GetSelectStatement(ByVal soheaderid As Integer) As String
			Dim _sb As New StringBuilder()
			_sb.Append("SELECT ")
			_sb.Append("SODetailsID, ")
			_sb.Append("SOHeaderID, ")
			_sb.Append("LineItemNumber, ")
			_sb.Append("ItemCode, ")
			_sb.Append("ProductName, ")
			_sb.Append("Quantity, ")
			_sb.Append("UnitOfMeasure, ")
			_sb.Append("BasePrice, ")
			_sb.Append("CurrencyCode, ")
			_sb.Append("LineTax1, ")
			_sb.Append("LineTax2, ")
			_sb.Append("LineTax3, ")
			_sb.Append("UPC, ")
			_sb.Append("LineDiscount, ")
			_sb.Append("ReturnFedExTrackingNumber, ")
			_sb.Append("SKU, ")
			_sb.Append("ShipQuantity, ")
			_sb.Append("Model_ID, ")
			_sb.Append("DevConditionID, ")
			_sb.Append("CosmGradeID, ")
			_sb.Append("LineLaborCharge, ")
			_sb.Append("RequiredSN ")
			_sb.Append("FROM saleorders.sodetails ")
			_sb.Append("WHERE soheaderid = " & soheaderid.ToString() & " ")
			Return _sb.ToString()
		End Function

#End Region
	End Class

End Namespace
