Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic

Namespace BOL

	Public Class soheader
#Region "DECLARATIONS"

		Private _soheaderid As Integer = 0
		Private _cust_id As Integer = 0
		Private _customerfirstname As String = ""
		Private _customerlastname As String = ""
		Private _customeraddress1 As String = ""
		Private _customeraddress2 As String = ""
		Private _customeraddress3 As String = ""
		Private _customercity As String = ""
		Private _customerstate As String = ""
		Private _customerpostalcode As String = ""
		Private _customercountry As String = ""
		Private _customerphone As String = ""
		Private _ponumber As String = ""
		Private _podate As String
		Private _customerordernumber As String = ""
		Private _workorderid As Integer = 0
		Private _customeremail As String = ""
		Private _customerorderdate As String
		Private _ordersubtotal As Decimal = 0
		Private _orderdiscount As Decimal = 0
		Private _ordertax1 As Decimal = 0
		Private _ordertax2 As Decimal = 0
		Private _ordertax3 As Decimal = 0
		Private _billcode_id As Integer = 0
		Private _ordershipmentcharge As Decimal = 0
		Private _shipdate As String
		Private _shipuserid As Integer = 0
		Private _transmitdate As String
		Private _receipttimestamp As String
		Private _invalidorder As Integer = 0
		Private _invalidorder_userid As Integer = 0
		Private _reasonorderinvalid As String = ""
		Private _invalidorder_datetime As String
		Private _orderstatusid As Integer = 0
		Private _inputerrormessage As String = ""
		Private _inputerrormessagesent As Integer = 0
		Private _outputerrormessage As String = ""
		Private _outputerrormessagesent As Integer = 0
		Private _inboundtrackingnumber As String = ""
		Private _outboundtrackingnumber As String = ""
		Private _outboundxmlfile As String = ""
		Private _billto_name As String = ""
		Private _billto_address1 As String = ""
		Private _billto_address2 As String = ""
		Private _billto_address3 As String = ""
		Private _billto_city As String = ""
		Private _billto_state As String = ""
		Private _billto_postalcode As String = ""
		Private _billto_country As String = ""
		Private _billto_phone As String = ""
		Private _message As String = ""
		Private _freightpaymentmethodcode As String = ""
		Private _carrierscaccode As String = ""
		Private _edi_filename As String = ""
		Private _shipcarrier As String = ""
		Private _fishbowlorderid As String = ""
		Private _fishbowlcustomername As String = ""
		Private _laborcharge As System.Double = 0.0
		Private _ordercreatedbyusrid As Integer = 0
		Private _ordercreateddate As String
		Private _edi_ref_zz As String = ""
		Private _edi_isa_ctrlno As Integer = 0
		Private _ordertype As String = ""
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
		Public Sub New(ByVal soheaderid As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(soheaderid)
			_isDirty = False
			_isNew = False
		End Sub

		Public Sub New(ByVal tracking_number As String)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(tracking_number)
			_isDirty = False
			_isNew = False
		End Sub


#End Region
#Region "PROPERTIES"

		Public Property SOHeaderID() As Integer
			Get
				Return _soheaderid
			End Get
			Set(ByVal Value As Integer)
				_soheaderid = Value
				_isDirty = True
			End Set
		End Property
		Public Property Cust_ID() As Integer
			Get
				Return _cust_id
			End Get
			Set(ByVal Value As Integer)
				_cust_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property CustomerFirstName() As String
			Get
				Return _customerfirstname
			End Get
			Set(ByVal Value As String)
				_customerfirstname = Value
				_isDirty = True
			End Set
		End Property
		Public Property CustomerLastName() As String
			Get
				Return _customerlastname
			End Get
			Set(ByVal Value As String)
				_customerlastname = Value
				_isDirty = True
			End Set
		End Property
		Public Property CustomerAddress1() As String
			Get
				Return _customeraddress1
			End Get
			Set(ByVal Value As String)
				_customeraddress1 = Value
				_isDirty = True
			End Set
		End Property
		Public Property CustomerAddress2() As String
			Get
				Return _customeraddress2
			End Get
			Set(ByVal Value As String)
				_customeraddress2 = Value
				_isDirty = True
			End Set
		End Property
		Public Property CustomerAddress3() As String
			Get
				Return _customeraddress3
			End Get
			Set(ByVal Value As String)
				_customeraddress3 = Value
				_isDirty = True
			End Set
		End Property
		Public Property CustomerCity() As String
			Get
				Return _customercity
			End Get
			Set(ByVal Value As String)
				_customercity = Value
				_isDirty = True
			End Set
		End Property
		Public Property CustomerState() As String
			Get
				Return _customerstate
			End Get
			Set(ByVal Value As String)
				_customerstate = Value
				_isDirty = True
			End Set
		End Property
		Public Property CustomerPostalCode() As String
			Get
				Return _customerpostalcode
			End Get
			Set(ByVal Value As String)
				_customerpostalcode = Value
				_isDirty = True
			End Set
		End Property
		Public Property CustomerCountry() As String
			Get
				Return _customercountry
			End Get
			Set(ByVal Value As String)
				_customercountry = Value
				_isDirty = True
			End Set
		End Property
		Public Property CustomerPhone() As String
			Get
				Return _customerphone
			End Get
			Set(ByVal Value As String)
				_customerphone = Value
				_isDirty = True
			End Set
		End Property
		Public Property PONumber() As String
			Get
				Return _ponumber
			End Get
			Set(ByVal Value As String)
				_ponumber = Value
				_isDirty = True
			End Set
		End Property
		Public Property PODate() As String
			Get
				Return _podate
			End Get
			Set(ByVal Value As String)
				_podate = Value
				_isDirty = True
			End Set
		End Property
		Public Property CustomerOrderNumber() As String
			Get
				Return _customerordernumber
			End Get
			Set(ByVal Value As String)
				_customerordernumber = Value
				_isDirty = True
			End Set
		End Property
		Public Property WorkOrderID() As Integer
			Get
				Return _workorderid
			End Get
			Set(ByVal Value As Integer)
				_workorderid = Value
				_isDirty = True
			End Set
		End Property
		Public Property CustomerEmail() As String
			Get
				Return _customeremail
			End Get
			Set(ByVal Value As String)
				_customeremail = Value
				_isDirty = True
			End Set
		End Property
		Public Property CustomerOrderDate() As String
			Get
				Return _customerorderdate
			End Get
			Set(ByVal Value As String)
				_customerorderdate = Value
				_isDirty = True
			End Set
		End Property
		Public Property OrderSubtotal() As Decimal
			Get
				Return _ordersubtotal
			End Get
			Set(ByVal Value As Decimal)
				_ordersubtotal = Value
				_isDirty = True
			End Set
		End Property
		Public Property OrderDiscount() As Decimal
			Get
				Return _orderdiscount
			End Get
			Set(ByVal Value As Decimal)
				_orderdiscount = Value
				_isDirty = True
			End Set
		End Property
		Public Property OrderTax1() As Decimal
			Get
				Return _ordertax1
			End Get
			Set(ByVal Value As Decimal)
				_ordertax1 = Value
				_isDirty = True
			End Set
		End Property
		Public Property OrderTax2() As Decimal
			Get
				Return _ordertax2
			End Get
			Set(ByVal Value As Decimal)
				_ordertax2 = Value
				_isDirty = True
			End Set
		End Property
		Public Property OrderTax3() As Decimal
			Get
				Return _ordertax3
			End Get
			Set(ByVal Value As Decimal)
				_ordertax3 = Value
				_isDirty = True
			End Set
		End Property
		Public Property BillCode_ID() As Integer
			Get
				Return _billcode_id
			End Get
			Set(ByVal Value As Integer)
				_billcode_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property OrderShipmentCharge() As Decimal
			Get
				Return _ordershipmentcharge
			End Get
			Set(ByVal Value As Decimal)
				_ordershipmentcharge = Value
				_isDirty = True
			End Set
		End Property
		Public Property ShipDate() As String
			Get
				Return _shipdate
			End Get
			Set(ByVal Value As String)
				_shipdate = Value
				_isDirty = True
			End Set
		End Property
		Public Property ShipUserID() As Integer
			Get
				Return _shipuserid
			End Get
			Set(ByVal Value As Integer)
				_shipuserid = Value
				_isDirty = True
			End Set
		End Property
		Public Property TransmitDate() As String
			Get
				Return _transmitdate
			End Get
			Set(ByVal Value As String)
				_transmitdate = Value
				_isDirty = True
			End Set
		End Property
		Public Property ReceiptTimestamp() As String
			Get
				Return _receipttimestamp
			End Get
			Set(ByVal Value As String)
				_receipttimestamp = Value
				_isDirty = True
			End Set
		End Property
		Public Property InvalidOrder() As Integer
			Get
				Return _invalidorder
			End Get
			Set(ByVal Value As Integer)
				_invalidorder = Value
				_isDirty = True
			End Set
		End Property
		Public Property InvalidOrder_UserID() As Integer
			Get
				Return _invalidorder_userid
			End Get
			Set(ByVal Value As Integer)
				_invalidorder_userid = Value
				_isDirty = True
			End Set
		End Property
		Public Property ReasonOrderInvalid() As String
			Get
				Return _reasonorderinvalid
			End Get
			Set(ByVal Value As String)
				_reasonorderinvalid = Value
				_isDirty = True
			End Set
		End Property
		Public Property InvalidOrder_DateTime() As String
			Get
				Return _invalidorder_datetime
			End Get
			Set(ByVal Value As String)
				_invalidorder_datetime = Value
				_isDirty = True
			End Set
		End Property
		Public Property OrderStatusID() As Integer
			Get
				Return _orderstatusid
			End Get
			Set(ByVal Value As Integer)
				_orderstatusid = Value
				_isDirty = True
			End Set
		End Property
		Public Property InputErrormessage() As String
			Get
				Return _inputerrormessage
			End Get
			Set(ByVal Value As String)
				_inputerrormessage = Value
				_isDirty = True
			End Set
		End Property
		Public Property InputErrorMessageSent() As Integer
			Get
				Return _inputerrormessagesent
			End Get
			Set(ByVal Value As Integer)
				_inputerrormessagesent = Value
				_isDirty = True
			End Set
		End Property
		Public Property OutputErrorMessage() As String
			Get
				Return _outputerrormessage
			End Get
			Set(ByVal Value As String)
				_outputerrormessage = Value
				_isDirty = True
			End Set
		End Property
		Public Property OutputErrorMessageSent() As Integer
			Get
				Return _outputerrormessagesent
			End Get
			Set(ByVal Value As Integer)
				_outputerrormessagesent = Value
				_isDirty = True
			End Set
		End Property
		Public Property InboundTrackingNumber() As String
			Get
				Return _inboundtrackingnumber
			End Get
			Set(ByVal Value As String)
				_inboundtrackingnumber = Value
				_isDirty = True
			End Set
		End Property
		Public Property OutboundTrackingNumber() As String
			Get
				Return _outboundtrackingnumber
			End Get
			Set(ByVal Value As String)
				_outboundtrackingnumber = Value
				_isDirty = True
			End Set
		End Property
		Public Property OutboundXMLFile() As String
			Get
				Return _outboundxmlfile
			End Get
			Set(ByVal Value As String)
				_outboundxmlfile = Value
				_isDirty = True
			End Set
		End Property
		Public Property BillTo_Name() As String
			Get
				Return _billto_name
			End Get
			Set(ByVal Value As String)
				_billto_name = Value
				_isDirty = True
			End Set
		End Property
		Public Property BillTo_Address1() As String
			Get
				Return _billto_address1
			End Get
			Set(ByVal Value As String)
				_billto_address1 = Value
				_isDirty = True
			End Set
		End Property
		Public Property BillTo_Address2() As String
			Get
				Return _billto_address2
			End Get
			Set(ByVal Value As String)
				_billto_address2 = Value
				_isDirty = True
			End Set
		End Property
		Public Property BillTo_Address3() As String
			Get
				Return _billto_address3
			End Get
			Set(ByVal Value As String)
				_billto_address3 = Value
				_isDirty = True
			End Set
		End Property
		Public Property BillTo_City() As String
			Get
				Return _billto_city
			End Get
			Set(ByVal Value As String)
				_billto_city = Value
				_isDirty = True
			End Set
		End Property
		Public Property BillTo_State() As String
			Get
				Return _billto_state
			End Get
			Set(ByVal Value As String)
				_billto_state = Value
				_isDirty = True
			End Set
		End Property
		Public Property BillTo_PostalCode() As String
			Get
				Return _billto_postalcode
			End Get
			Set(ByVal Value As String)
				_billto_postalcode = Value
				_isDirty = True
			End Set
		End Property
		Public Property BillTo_Country() As String
			Get
				Return _billto_country
			End Get
			Set(ByVal Value As String)
				_billto_country = Value
				_isDirty = True
			End Set
		End Property
		Public Property BillTo_Phone() As String
			Get
				Return _billto_phone
			End Get
			Set(ByVal Value As String)
				_billto_phone = Value
				_isDirty = True
			End Set
		End Property
		Public Property Message() As String
			Get
				Return _message
			End Get
			Set(ByVal Value As String)
				_message = Value
				_isDirty = True
			End Set
		End Property
		Public Property FreightPaymentMethodCode() As String
			Get
				Return _freightpaymentmethodcode
			End Get
			Set(ByVal Value As String)
				_freightpaymentmethodcode = Value
				_isDirty = True
			End Set
		End Property
		Public Property CarrierSCACCode() As String
			Get
				Return _carrierscaccode
			End Get
			Set(ByVal Value As String)
				_carrierscaccode = Value
				_isDirty = True
			End Set
		End Property
		Public Property EDI_FileName() As String
			Get
				Return _edi_filename
			End Get
			Set(ByVal Value As String)
				_edi_filename = Value
				_isDirty = True
			End Set
		End Property
		Public Property ShipCarrier() As String
			Get
				Return _shipcarrier
			End Get
			Set(ByVal Value As String)
				_shipcarrier = Value
				_isDirty = True
			End Set
		End Property
		Public Property FishBowlOrderID() As String
			Get
				Return _fishbowlorderid
			End Get
			Set(ByVal Value As String)
				_fishbowlorderid = Value
				_isDirty = True
			End Set
		End Property
		Public Property FishBowlCustomerName() As String
			Get
				Return _fishbowlcustomername
			End Get
			Set(ByVal Value As String)
				_fishbowlcustomername = Value
				_isDirty = True
			End Set
		End Property
		Public Property LaborCharge() As System.Double
			Get
				Return _laborcharge
			End Get
			Set(ByVal Value As System.Double)
				_laborcharge = Value
				_isDirty = True
			End Set
		End Property
		Public Property OrderCreatedByUsrID() As Integer
			Get
				Return _ordercreatedbyusrid
			End Get
			Set(ByVal Value As Integer)
				_ordercreatedbyusrid = Value
				_isDirty = True
			End Set
		End Property
		Public Property OrderCreatedDate() As String
			Get
				Return _ordercreateddate
			End Get
			Set(ByVal Value As String)
				_ordercreateddate = Value
				_isDirty = True
			End Set
		End Property
		Public Property EDI_REF_ZZ() As String
			Get
				Return _edi_ref_zz
			End Get
			Set(ByVal Value As String)
				_edi_ref_zz = Value
				_isDirty = True
			End Set
		End Property
		Public Property EDI_ISA_CtrlNo() As Integer
			Get
				Return _edi_isa_ctrlno
			End Get
			Set(ByVal Value As Integer)
				_edi_isa_ctrlno = Value
				_isDirty = True
			End Set
		End Property
		Public Property OrderType() As String
			Get
				Return _ordertype
			End Get
			Set(ByVal Value As String)
				_ordertype = Value
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

		Protected Sub GetData(ByVal soheaderid As Integer)
			Dim _sql As String = GetSelectStatement(soheaderid)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub


		Protected Sub GetData(ByVal tracking_number As String)
			Dim _sql As String = GetSelectStatement(tracking_number)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub


		Private Sub PopulateObject(ByVal _dr As DataRow)

			_soheaderid = _dr("soheaderid").ToString()
			_cust_id = _dr("cust_id").ToString()
			_customerfirstname = ConvertToSomething(_dr("customerfirstname").ToString(), "")
			_customerlastname = ConvertToSomething(_dr("customerlastname").ToString(), "")
			_customeraddress1 = ConvertToSomething(_dr("customeraddress1").ToString(), "")
			_customeraddress2 = ConvertToSomething(_dr("customeraddress2").ToString(), "")
			_customeraddress3 = ConvertToSomething(_dr("customeraddress3").ToString(), "")
			_customercity = ConvertToSomething(_dr("customercity").ToString(), "")
			_customerstate = ConvertToSomething(_dr("customerstate").ToString(), "")
			_customerpostalcode = ConvertToSomething(_dr("customerpostalcode").ToString(), "")
			_customercountry = ConvertToSomething(_dr("customercountry").ToString(), "")
			_customerphone = ConvertToSomething(_dr("customerphone").ToString(), "")
			_ponumber = ConvertToSomething(_dr("ponumber").ToString(), "")
			_podate = ConvertToSomething(_dr("podate").ToString(), "")
			_customerordernumber = ConvertToSomething(_dr("customerordernumber").ToString(), "")
			_workorderid = _dr("workorderid").ToString()
			_customeremail = ConvertToSomething(_dr("customeremail").ToString(), "")
			_customerorderdate = ConvertToSomething(_dr("customerorderdate").ToString(), "")
			_ordersubtotal = DirectCast(ConvertToSomething(_dr("ordersubtotal"), 0.0), Decimal)
			_orderdiscount = DirectCast(ConvertToSomething(_dr("orderdiscount"), 0.0), Decimal)
			_ordertax1 = DirectCast(ConvertToSomething(_dr("ordertax1"), 0.0), Decimal)
			_ordertax2 = DirectCast(ConvertToSomething(_dr("ordertax2"), 0.0), Decimal)
			_ordertax3 = DirectCast(ConvertToSomething(_dr("ordertax3"), 0.0), Decimal)
			_billcode_id = DirectCast(ConvertToSomething(_dr("billcode_id"), 0), Integer)
			_ordershipmentcharge = DirectCast(ConvertToSomething(_dr("ordershipmentcharge"), 0.0), Decimal)
			_shipdate = ConvertToSomething(_dr("shipdate").ToString(), "")
			_shipuserid = _dr("shipuserid").ToString()
			_transmitdate = ConvertToSomething(_dr("transmitdate").ToString(), "")
			_receipttimestamp = ConvertToSomething(_dr("receipttimestamp").ToString(), "")
			_invalidorder = _dr("invalidorder").ToString()
			_invalidorder_userid = _dr("invalidorder_userid").ToString()
			_reasonorderinvalid = ConvertToSomething(_dr("reasonorderinvalid").ToString(), "")
			_invalidorder_datetime = ConvertToSomething(_dr("invalidorder_datetime").ToString(), "")
			_orderstatusid = _dr("orderstatusid").ToString()
			_inputerrormessage = ConvertToSomething(_dr("inputerrormessage").ToString(), "")
			_inputerrormessagesent = _dr("inputerrormessagesent").ToString()
			_outputerrormessage = ConvertToSomething(_dr("outputerrormessage").ToString(), "")
			_outputerrormessagesent = _dr("outputerrormessagesent").ToString()
			_inboundtrackingnumber = ConvertToSomething(_dr("inboundtrackingnumber").ToString(), "")
			_outboundtrackingnumber = ConvertToSomething(_dr("outboundtrackingnumber").ToString(), "")
			_outboundxmlfile = ConvertToSomething(_dr("outboundxmlfile").ToString(), "")
			_billto_name = ConvertToSomething(_dr("billto_name").ToString(), "")
			_billto_address1 = ConvertToSomething(_dr("billto_address1").ToString(), "")
			_billto_address2 = ConvertToSomething(_dr("billto_address2").ToString(), "")
			_billto_address3 = ConvertToSomething(_dr("billto_address3").ToString(), "")
			_billto_city = ConvertToSomething(_dr("billto_city").ToString(), "")
			_billto_state = ConvertToSomething(_dr("billto_state").ToString(), "")
			_billto_postalcode = ConvertToSomething(_dr("billto_postalcode").ToString(), "")
			_billto_country = ConvertToSomething(_dr("billto_country").ToString(), "")
			_billto_phone = ConvertToSomething(_dr("billto_phone").ToString(), "")
			_message = ConvertToSomething(_dr("message").ToString(), "")
			_freightpaymentmethodcode = ConvertToSomething(_dr("freightpaymentmethodcode").ToString(), "")
			_carrierscaccode = ConvertToSomething(_dr("carrierscaccode").ToString(), "")
			_edi_filename = ConvertToSomething(_dr("edi_filename").ToString(), "")
			_shipcarrier = ConvertToSomething(_dr("shipcarrier").ToString(), "")
			_fishbowlorderid = ConvertToSomething(_dr("fishbowlorderid").ToString(), "")
			_fishbowlcustomername = ConvertToSomething(_dr("fishbowlcustomername").ToString(), "")
			_laborcharge = _dr("laborcharge").ToString()
			_ordercreatedbyusrid = ConvertToSomething(_dr("ordercreatedbyusrid"), 0)
			_ordercreateddate = ConvertToSomething(_dr("ordercreateddate").ToString(), "")
			_edi_ref_zz = ConvertToSomething(_dr("edi_ref_zz").ToString(), "")
			_edi_isa_ctrlno = ConvertToSomething(_dr("edi_isa_ctrlno"), 0)
			_ordertype = ConvertToSomething(_dr("ordertype").ToString(), "")
		End Sub

		Protected Function GetSelectStatement(ByVal tracking_number As String) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "SOHeaderID, "
			_sql += "Cust_ID, "
			_sql += "CustomerFirstName, "
			_sql += "CustomerLastName, "
			_sql += "CustomerAddress1, "
			_sql += "CustomerAddress2, "
			_sql += "CustomerAddress3, "
			_sql += "CustomerCity, "
			_sql += "CustomerState, "
			_sql += "CustomerPostalCode, "
			_sql += "CustomerCountry, "
			_sql += "CustomerPhone, "
			_sql += "PONumber, "
			_sql += "PODate, "
			_sql += "CustomerOrderNumber, "
			_sql += "WorkOrderID, "
			_sql += "CustomerEmail, "
			_sql += "CustomerOrderDate, "
			_sql += "OrderSubtotal, "
			_sql += "OrderDiscount, "
			_sql += "OrderTax1, "
			_sql += "OrderTax2, "
			_sql += "OrderTax3, "
			_sql += "BillCode_ID, "
			_sql += "OrderShipmentCharge, "
			_sql += "ShipDate, "
			_sql += "ShipUserID, "
			_sql += "TransmitDate, "
			_sql += "ReceiptTimestamp, "
			_sql += "InvalidOrder, "
			_sql += "InvalidOrder_UserID, "
			_sql += "ReasonOrderInvalid, "
			_sql += "InvalidOrder_DateTime, "
			_sql += "OrderStatusID, "
			_sql += "InputErrormessage, "
			_sql += "InputErrorMessageSent, "
			_sql += "OutputErrorMessage, "
			_sql += "OutputErrorMessageSent, "
			_sql += "InboundTrackingNumber, "
			_sql += "OutboundTrackingNumber, "
			_sql += "OutboundXMLFile, "
			_sql += "BillTo_Name, "
			_sql += "BillTo_Address1, "
			_sql += "BillTo_Address2, "
			_sql += "BillTo_Address3, "
			_sql += "BillTo_City, "
			_sql += "BillTo_State, "
			_sql += "BillTo_PostalCode, "
			_sql += "BillTo_Country, "
			_sql += "BillTo_Phone, "
			_sql += "Message, "
			_sql += "FreightPaymentMethodCode, "
			_sql += "CarrierSCACCode, "
			_sql += "EDI_FileName, "
			_sql += "ShipCarrier, "
			_sql += "FishBowlOrderID, "
			_sql += "FishBowlCustomerName, "
			_sql += "LaborCharge, "
			_sql += "OrderCreatedByUsrID, "
			_sql += "OrderCreatedDate, "
			_sql += "EDI_REF_ZZ, "
			_sql += "EDI_ISA_CtrlNo, "
			_sql += "OrderType "
			_sql += "FROM saleorders.soheader "
			_sql += "WHERE OutboundTrackingNumber = '" & tracking_number & "'; "
			Return _sql
		End Function

		Protected Function GetSelectStatement(ByVal soheaderid As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "SOHeaderID, "
			_sql += "Cust_ID, "
			_sql += "CustomerFirstName, "
			_sql += "CustomerLastName, "
			_sql += "CustomerAddress1, "
			_sql += "CustomerAddress2, "
			_sql += "CustomerAddress3, "
			_sql += "CustomerCity, "
			_sql += "CustomerState, "
			_sql += "CustomerPostalCode, "
			_sql += "CustomerCountry, "
			_sql += "CustomerPhone, "
			_sql += "PONumber, "
			_sql += "PODate, "
			_sql += "CustomerOrderNumber, "
			_sql += "WorkOrderID, "
			_sql += "CustomerEmail, "
			_sql += "CustomerOrderDate, "
			_sql += "OrderSubtotal, "
			_sql += "OrderDiscount, "
			_sql += "OrderTax1, "
			_sql += "OrderTax2, "
			_sql += "OrderTax3, "
			_sql += "BillCode_ID, "
			_sql += "OrderShipmentCharge, "
			_sql += "ShipDate, "
			_sql += "ShipUserID, "
			_sql += "TransmitDate, "
			_sql += "ReceiptTimestamp, "
			_sql += "InvalidOrder, "
			_sql += "InvalidOrder_UserID, "
			_sql += "ReasonOrderInvalid, "
			_sql += "InvalidOrder_DateTime, "
			_sql += "OrderStatusID, "
			_sql += "InputErrormessage, "
			_sql += "InputErrorMessageSent, "
			_sql += "OutputErrorMessage, "
			_sql += "OutputErrorMessageSent, "
			_sql += "InboundTrackingNumber, "
			_sql += "OutboundTrackingNumber, "
			_sql += "OutboundXMLFile, "
			_sql += "BillTo_Name, "
			_sql += "BillTo_Address1, "
			_sql += "BillTo_Address2, "
			_sql += "BillTo_Address3, "
			_sql += "BillTo_City, "
			_sql += "BillTo_State, "
			_sql += "BillTo_PostalCode, "
			_sql += "BillTo_Country, "
			_sql += "BillTo_Phone, "
			_sql += "Message, "
			_sql += "FreightPaymentMethodCode, "
			_sql += "CarrierSCACCode, "
			_sql += "EDI_FileName, "
			_sql += "ShipCarrier, "
			_sql += "FishBowlOrderID, "
			_sql += "FishBowlCustomerName, "
			_sql += "LaborCharge, "
			_sql += "OrderCreatedByUsrID, "
			_sql += "OrderCreatedDate, "
			_sql += "EDI_REF_ZZ, "
			_sql += "EDI_ISA_CtrlNo, "
			_sql += "OrderType "
			_sql += "FROM saleorders.soheader "
			_sql += "WHERE soheaderid = " & soheaderid.ToString() & ""
			Return _sql
		End Function
		Public Sub ApplyChanges()
			If _isNew Then
				Throw New Exception("SOHeader insert not Implemented.")
				'_SOHeaderID = Insert()
			ElseIf IsDeleted Then
				Throw New Exception("SOHeader delete not Implemented.")
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
				strSQL = "INSERT INTO saleorders.soheader (" & _
				   "soheaderid, " & _
				   "cust_id, " & _
				   "customerfirstname, " & _
				   "customerlastname, " & _
				   "customeraddress1, " & _
				   "customeraddress2, " & _
				   "customeraddress3, " & _
				   "customercity, " & _
				   "customerstate, " & _
				   "customerpostalcode, " & _
				   "customercountry, " & _
				   "customerphone, " & _
				   "ponumber, " & _
				   "podate, " & _
				   "customerordernumber, " & _
				   "workorderid, " & _
				   "customeremail, " & _
				   "customerorderdate, " & _
				   "ordersubtotal, " & _
				   "orderdiscount, " & _
				   "ordertax1, " & _
				   "ordertax2, " & _
				   "ordertax3, " & _
				   "billcode_id, " & _
				   "ordershipmentcharge, " & _
				   "shipdate, " & _
				   "shipuserid, " & _
				   "transmitdate, " & _
				   "receipttimestamp, " & _
				   "invalidorder, " & _
				   "invalidorder_userid, " & _
				   "reasonorderinvalid, " & _
				   "invalidorder_datetime, " & _
				   "orderstatusid, " & _
				   "inputerrormessage, " & _
				   "inputerrormessagesent, " & _
				   "outputerrormessage, " & _
				   "outputerrormessagesent, " & _
				   "inboundtrackingnumber, " & _
				   "outboundtrackingnumber, " & _
				   "outboundxmlfile, " & _
				   "billto_name, " & _
				   "billto_address1, " & _
				   "billto_address2, " & _
				   "billto_address3, " & _
				   "billto_city, " & _
				   "billto_state, " & _
				   "billto_postalcode, " & _
				   "billto_country, " & _
				   "billto_phone, " & _
				   "message, " & _
				   "freightpaymentmethodcode, " & _
				   "carrierscaccode, " & _
				   "edi_filename, " & _
				   "shipcarrier, " & _
				   "fishbowlorderid, " & _
				   "fishbowlcustomername, " & _
				   "laborcharge, " & _
				   "ordercreatedbyusrid, " & _
				   "ordercreateddate, " & _
				   "edi_ref_zz, " & _
				   "edi_isa_ctrlno, " & _
				   "ordertype " & _
				  ") " & _
				  "VALUES ( " & _
				   _soheaderid & " , " & _
				   _cust_id & " , " & _
				   _customerfirstname & " , " & _
				   _customerlastname & " , " & _
				   _customeraddress1 & " , " & _
				   _customeraddress2 & " , " & _
				   _customeraddress3 & " , " & _
				   _customercity & " , " & _
				   _customerstate & " , " & _
				   _customerpostalcode & " , " & _
				   _customercountry & " , " & _
				   _customerphone & " , " & _
				   _ponumber & " , " & _
				   ConvertBackToNullString(_podate, False) & " , " & _
				   _customerordernumber & " , " & _
				   _workorderid & " , " & _
				   _customeremail & " , " & _
				   ConvertBackToNullString(_customerorderdate, False) & " , " & _
				   _ordersubtotal & " , " & _
				   _orderdiscount & " , " & _
				   _ordertax1 & " , " & _
				   _ordertax2 & " , " & _
				   _ordertax3 & " , " & _
				   _billcode_id & " , " & _
				   _ordershipmentcharge & " , " & _
				   ConvertBackToNullString(_shipdate, False) & " , " & _
				   _shipuserid & " , " & _
				   ConvertBackToNullString(_transmitdate, False) & " , " & _
				   _receipttimestamp & " , " & _
				   _invalidorder & " , " & _
				   _invalidorder_userid & " , " & _
				   ConvertBackToNullString(_reasonorderinvalid, False) & " , " & _
				   ConvertBackToNullString(_invalidorder_datetime, False) & " , " & _
				   _orderstatusid & " , " & _
				   _inputerrormessage & " , " & _
				   _inputerrormessagesent & " , " & _
				   _outputerrormessage & " , " & _
				   _outputerrormessagesent & " , " & _
				   _inboundtrackingnumber & " , " & _
				   _outboundtrackingnumber & " , " & _
				   _outboundxmlfile & " , " & _
				   _billto_name & " , " & _
				   _billto_address1 & " , " & _
				   _billto_address2 & " , " & _
				   _billto_address3 & " , " & _
				   _billto_city & " , " & _
				   _billto_state & " , " & _
				   _billto_postalcode & " , " & _
				   _billto_country & " , " & _
				   _billto_phone & " , " & _
				   _message & " , " & _
				   _freightpaymentmethodcode & " , " & _
				   _carrierscaccode & " , " & _
				   ConvertBackToNullString(_edi_filename, False) & " , " & _
				   _shipcarrier & " , " & _
				   ConvertBackToNullString(_fishbowlorderid, False) & " , " & _
				   ConvertBackToNullString(_fishbowlcustomername, False) & " , " & _
				   _laborcharge & " , " & _
				   ConvertBackToNullString(_ordercreatedbyusrid, False) & " , " & _
				   ConvertBackToNullString(_ordercreateddate, False) & " , " & _
				   _edi_ref_zz & " , " & _
				   ConvertBackToNullString(_edi_isa_ctrlno, False) & " , " & _
				   ConvertBackToNullString(_ordertype, False) & "  " & _
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
				strSQL = "UPDATE saleorders.soheader SET " & _
				"shipdate = " & ConvertToMySQLDateOrNullString(_shipdate) & ", " & _
				"shipuserid = " & ConvertBackToNullString(_shipuserid, False) & ", " & _
				"invalidorder = " & ConvertBackToNullString(_invalidorder, False) & ", " & _
				"invalidorder_userid = " & ConvertBackToNullString(_invalidorder_userid, False) & ", " & _
				"reasonorderinvalid = " & ConvertBackToNullString(_reasonorderinvalid, True) & ", " & _
				"invalidorder_datetime = " & ConvertToMySQLDateOrNullString(_invalidorder_datetime) & " " & _
				  " " & _
				  "WHERE SOHeaderID = " & SOHeaderID.ToString() & "; "
				Return objDataProc.ExecuteNonQuery(strSQL)

				'"cust_id = " & ConvertBackToNullString(_cust_id, False) & ", " & _
				'"customerfirstname = " & ConvertBackToNullString(_customerfirstname, False) & ", " & _
				'"customerlastname = " & ConvertBackToNullString(_customerlastname, False) & ", " & _
				'"customeraddress1 = " & ConvertBackToNullString(_customeraddress1, False) & ", " & _
				'"customeraddress2 = " & ConvertBackToNullString(_customeraddress2, False) & ", " & _
				'"customeraddress3 = " & ConvertBackToNullString(_customeraddress3, False) & ", " & _
				'"customercity = " & ConvertBackToNullString(_customercity, False) & ", " & _
				'"customerstate = " & ConvertBackToNullString(_customerstate, False) & ", " & _
				'"customerpostalcode = " & ConvertBackToNullString(_customerpostalcode, False) & ", " & _
				'"customercountry = " & ConvertBackToNullString(_customercountry, False) & ", " & _
				'"customerphone = " & ConvertBackToNullString(_customerphone, False) & ", " & _
				'"ponumber = " & ConvertBackToNullString(_ponumber, False) & ", " & _
				'"podate = " & ConvertBackToNullString(_podate, False) & ", " & _
				'"customerordernumber = " & ConvertBackToNullString(_customerordernumber, False) & ", " & _
				'"workorderid = " & ConvertBackToNullString(_workorderid, False) & ", " & _
				'"customeremail = " & ConvertBackToNullString(_customeremail, False) & ", " & _
				'"customerorderdate = " & ConvertBackToNullString(_customerorderdate, False) & ", " & _
				'"ordersubtotal = " & ConvertBackToNullString(_ordersubtotal, False) & ", " & _
				'"orderdiscount = " & ConvertBackToNullString(_orderdiscount, False) & ", " & _
				'"ordertax1 = " & ConvertBackToNullString(_ordertax1, False) & ", " & _
				'"ordertax2 = " & ConvertBackToNullString(_ordertax2, False) & ", " & _
				'"ordertax3 = " & ConvertBackToNullString(_ordertax3, False) & ", " & _
				'"billcode_id = " & ConvertBackToNullString(_billcode_id, False) & ", " & _
				'"ordershipmentcharge = " & ConvertBackToNullString(_ordershipmentcharge, False) & ", " & _
				'"transmitdate = " & ConvertBackToNullString(_transmitdate, False) & ", " & _
				'"receipttimestamp = " & ConvertBackToNullString(_receipttimestamp, False) & ", " & _
				'"orderstatusid = " & ConvertBackToNullString(_orderstatusid, False) & ", " & _
				'"inputerrormessage = " & ConvertBackToNullString(_inputerrormessage, False) & ", " & _
				'"inputerrormessagesent = " & ConvertBackToNullString(_inputerrormessagesent, False) & ", " & _
				'"outputerrormessage = " & ConvertBackToNullString(_outputerrormessage, False) & ", " & _
				'"outputerrormessagesent = " & ConvertBackToNullString(_outputerrormessagesent, False) & ", " & _
				'"inboundtrackingnumber = " & ConvertBackToNullString(_inboundtrackingnumber, False) & ", " & _
				'"outboundtrackingnumber = " & ConvertBackToNullString(_outboundtrackingnumber, False) & ", " & _
				'"outboundxmlfile = " & ConvertBackToNullString(_outboundxmlfile, False) & ", " & _
				'"billto_name = " & ConvertBackToNullString(_billto_name, False) & ", " & _
				'"billto_address1 = " & ConvertBackToNullString(_billto_address1, False) & ", " & _
				'"billto_address2 = " & ConvertBackToNullString(_billto_address2, False) & ", " & _
				'"billto_address3 = " & ConvertBackToNullString(_billto_address3, False) & ", " & _
				'"billto_city = " & ConvertBackToNullString(_billto_city, False) & ", " & _
				'"billto_state = " & ConvertBackToNullString(_billto_state, False) & ", " & _
				'"billto_postalcode = " & ConvertBackToNullString(_billto_postalcode, False) & ", " & _
				'"billto_country = " & ConvertBackToNullString(_billto_country, False) & ", " & _
				'"billto_phone = " & ConvertBackToNullString(_billto_phone, False) & ", " & _
				'"message = " & ConvertBackToNullString(_message, False) & ", " & _
				'"freightpaymentmethodcode = " & ConvertBackToNullString(_freightpaymentmethodcode, False) & ", " & _
				'"carrierscaccode = " & ConvertBackToNullString(_carrierscaccode, False) & ", " & _
				'"edi_filename = " & ConvertBackToNullString(_edi_filename, False) & ", " & _
				'"shipcarrier = " & ConvertBackToNullString(_shipcarrier, False) & ", " & _
				'"fishbowlorderid = " & ConvertBackToNullString(_fishbowlorderid, False) & ", " & _
				'"fishbowlcustomername = " & ConvertBackToNullString(_fishbowlcustomername, False) & ", " & _
				'"laborcharge = " & ConvertBackToNullString(_laborcharge, False) & ", " & _
				'"ordercreatedbyusrid = " & ConvertBackToNullString(_ordercreatedbyusrid, False) & ", " & _
				'"ordercreateddate = " & ConvertBackToNullString(_ordercreateddate, False) & ", " & _
				'"edi_ref_zz = " & ConvertBackToNullString(_edi_ref_zz, False) & ", " & _
				'"edi_isa_ctrlno = " & ConvertBackToNullString(_edi_isa_ctrlno, False) & ", " & _
				'"ordertype = " & ConvertBackToNullString(_ordertype, False) & ", " & _
			Catch ex As Exception
				Throw ex
			End Try
		End Function

#End Region
	End Class

	Public Class soheaderCollection
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

		Public ReadOnly Property soheaderDataTable() As DataTable
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
			Dim _sb As New StringBuilder()
			_sb.Append("SELECT ")
			_sb.Append("SOHeaderID, ")
			_sb.Append("Cust_ID, ")
			_sb.Append("CustomerFirstName, ")
			_sb.Append("CustomerLastName, ")
			_sb.Append("CustomerAddress1, ")
			_sb.Append("CustomerAddress2, ")
			_sb.Append("CustomerAddress3, ")
			_sb.Append("CustomerCity, ")
			_sb.Append("CustomerState, ")
			_sb.Append("CustomerPostalCode, ")
			_sb.Append("CustomerCountry, ")
			_sb.Append("CustomerPhone, ")
			_sb.Append("PONumber, ")
			_sb.Append("PODate, ")
			_sb.Append("CustomerOrderNumber, ")
			_sb.Append("WorkOrderID, ")
			_sb.Append("CustomerEmail, ")
			_sb.Append("CustomerOrderDate, ")
			_sb.Append("OrderSubtotal, ")
			_sb.Append("OrderDiscount, ")
			_sb.Append("OrderTax1, ")
			_sb.Append("OrderTax2, ")
			_sb.Append("OrderTax3, ")
			_sb.Append("BillCode_ID, ")
			_sb.Append("OrderShipmentCharge, ")
			_sb.Append("ShipDate, ")
			_sb.Append("ShipUserID, ")
			_sb.Append("TransmitDate, ")
			_sb.Append("ReceiptTimestamp, ")
			_sb.Append("InvalidOrder, ")
			_sb.Append("InvalidOrder_UserID, ")
			_sb.Append("ReasonOrderInvalid, ")
			_sb.Append("InvalidOrder_DateTime, ")
			_sb.Append("OrderStatusID, ")
			_sb.Append("InputErrormessage, ")
			_sb.Append("InputErrorMessageSent, ")
			_sb.Append("OutputErrorMessage, ")
			_sb.Append("OutputErrorMessageSent, ")
			_sb.Append("InboundTrackingNumber, ")
			_sb.Append("OutboundTrackingNumber, ")
			_sb.Append("OutboundXMLFile, ")
			_sb.Append("BillTo_Name, ")
			_sb.Append("BillTo_Address1, ")
			_sb.Append("BillTo_Address2, ")
			_sb.Append("BillTo_Address3, ")
			_sb.Append("BillTo_City, ")
			_sb.Append("BillTo_State, ")
			_sb.Append("BillTo_PostalCode, ")
			_sb.Append("BillTo_Country, ")
			_sb.Append("BillTo_Phone, ")
			_sb.Append("Message, ")
			_sb.Append("FreightPaymentMethodCode, ")
			_sb.Append("CarrierSCACCode, ")
			_sb.Append("EDI_FileName, ")
			_sb.Append("ShipCarrier, ")
			_sb.Append("FishBowlOrderID, ")
			_sb.Append("FishBowlCustomerName, ")
			_sb.Append("LaborCharge, ")
			_sb.Append("OrderCreatedByUsrID, ")
			_sb.Append("OrderCreatedDate, ")
			_sb.Append("EDI_REF_ZZ, ")
			_sb.Append("EDI_ISA_CtrlNo, ")
			_sb.Append("OrderType ")
			_sb.Append("FROM saleorders.soheader ")
			_sb.Append("WHERE cust_id = " & cust_id.ToString() & " ")
			_sb.Append(" AND ")
			_sb.Append("shipdate IS NULL ")
			_sb.Append("ORDER BY ReceiptTimestamp; ")
			Return _sb.ToString()
		End Function

#End Region
	End Class

End Namespace
