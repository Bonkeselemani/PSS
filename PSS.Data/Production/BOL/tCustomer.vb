Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic

Namespace BOL

	Public Class tcustomer

#Region "DECLARATIONS"

		Private _cust_id As Integer = 0
		Private _cust_name1 As String = ""
		Private _cust_name2 As String = ""
		Private _cust_inactive As Boolean = False
		Private _cust_invoicedetail As Boolean = False
		Private _plusparts As Integer = 0
		Private _cust_flatrateparts As Boolean = False
		Private _cust_autoship As Boolean = False
		Private _cust_stage As Boolean = False
		Private _cust_pallett As Boolean = False
		Private _cust_rejectdays As Integer = 0
		Private _cust_rejecttimes As Integer = 0
		Private _cust_repairnonwrty As Boolean = False
		Private _cust_replacelcd As Boolean = False
		Private _cust_hstech As Boolean = False
		Private _cust_specialcodes As Boolean = False
		Private _cust_crapproverec As Boolean = False
		Private _cust_crapproveship As Boolean = False
		Private _cust_collsalestax As Boolean = False
		Private _cust_memo As String = ""
		Private _cust_consignedparts As Boolean = False
		Private _biztype_id As Integer = 0
		Private _pay_id As Integer = 0
		Private _pco_id As Integer = 0
		Private _slsp_id As Integer = 0
		Private _cust_lvlshipcust As Boolean = False
		Private _cust_recrcncl As Boolean = False
		Private _cust_palletship As Boolean = False
		Private _cust_aggbilling As Boolean = False
		Private _cust_autobill As Integer = 0
		Private _cust_crbilling As Boolean = False
		Private _invdatetype_id As Integer = 0
		Private _predeterminepartneed As Integer = 0
		Private _departmentid As Integer = 0
		Private _reqaqlcheckonallunit As Integer = 0
		Private _lastupdatedt As String
		Private _lastupdateuserid As String = ""
		Private _tat As Integer = 0
		Private _techfailurecode As Integer = 0
		Private _reqoutboundtracking As Integer = 0
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

		Public Sub New(ByVal cust_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(cust_id)
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
		ByVal cust_id As Integer, _
		ByVal cust_name1 As String, _
		ByVal cust_name2 As String, _
		ByVal cust_inactive As Boolean, _
		ByVal cust_invoicedetail As Boolean, _
		ByVal plusparts As Integer, _
		ByVal cust_flatrateparts As Boolean, _
		ByVal cust_autoship As Boolean, _
		ByVal cust_stage As Boolean, _
		ByVal cust_pallett As Boolean, _
		ByVal cust_rejectdays As Integer, _
		ByVal cust_rejecttimes As Integer, _
		ByVal cust_repairnonwrty As Boolean, _
		ByVal cust_replacelcd As Boolean, _
		ByVal cust_hstech As Boolean, _
		ByVal cust_specialcodes As Boolean, _
		ByVal cust_crapproverec As Boolean, _
		ByVal cust_crapproveship As Boolean, _
		ByVal cust_collsalestax As Boolean, _
		ByVal cust_memo As String, _
		ByVal cust_consignedparts As Boolean, _
		ByVal biztype_id As Integer, _
		ByVal pay_id As Integer, _
		ByVal pco_id As Integer, _
		ByVal slsp_id As Integer, _
		ByVal cust_lvlshipcust As Boolean, _
		ByVal cust_recrcncl As Boolean, _
		ByVal cust_palletship As Boolean, _
		ByVal cust_aggbilling As Boolean, _
		ByVal cust_autobill As Integer, _
		ByVal cust_crbilling As Boolean, _
		ByVal invdatetype_id As Integer, _
		ByVal predeterminepartneed As Integer, _
		ByVal departmentid As Integer, _
		ByVal reqaqlcheckonallunit As Integer, _
		ByVal lastupdatedt As String, _
		ByVal lastupdateuserid As String, _
		ByVal tat As Integer, _
		ByVal techfailurecode As Integer, _
		ByVal reqoutboundtracking As Integer _
		 )
			_cust_id = cust_id
			_cust_name1 = cust_name1
			_cust_name2 = cust_name2
			_cust_inactive = cust_inactive
			_cust_invoicedetail = cust_invoicedetail
			_plusparts = plusparts
			_cust_flatrateparts = cust_flatrateparts
			_cust_autoship = cust_autoship
			_cust_stage = cust_stage
			_cust_pallett = cust_pallett
			_cust_rejectdays = cust_rejectdays
			_cust_rejecttimes = cust_rejecttimes
			_cust_repairnonwrty = cust_repairnonwrty
			_cust_replacelcd = cust_replacelcd
			_cust_hstech = cust_hstech
			_cust_specialcodes = cust_specialcodes
			_cust_crapproverec = cust_crapproverec
			_cust_crapproveship = cust_crapproveship
			_cust_collsalestax = cust_collsalestax
			_cust_memo = cust_memo
			_cust_consignedparts = cust_consignedparts
			_biztype_id = biztype_id
			_pay_id = pay_id
			_pco_id = pco_id
			_slsp_id = slsp_id
			_cust_lvlshipcust = cust_lvlshipcust
			_cust_recrcncl = cust_recrcncl
			_cust_palletship = cust_palletship
			_cust_aggbilling = cust_aggbilling
			_cust_autobill = cust_autobill
			_cust_crbilling = cust_crbilling
			_invdatetype_id = invdatetype_id
			_predeterminepartneed = predeterminepartneed
			_departmentid = departmentid
			_reqaqlcheckonallunit = reqaqlcheckonallunit
			_lastupdatedt = lastupdatedt
			_lastupdateuserid = lastupdateuserid
			_tat = tat
			_techfailurecode = techfailurecode
			_reqoutboundtracking = reqoutboundtracking
		End Sub

#End Region
#Region "PROPERTIES"

		Public Property Cust_ID() As Integer
			Get
				Return _cust_id
			End Get
			Set(ByVal Value As Integer)
				_cust_id = value
				_isDirty = True
			End Set
		End Property
		Public Property Cust_Name1() As String
			Get
				Return _cust_name1
			End Get
			Set(ByVal Value As String)
				_cust_name1 = value
				_isDirty = True
			End Set
		End Property
		Public Property Cust_Name2() As String
			Get
				Return _cust_name2
			End Get
			Set(ByVal Value As String)
				_cust_name2 = value
				_isDirty = True
			End Set
		End Property
		Public Property Cust_Inactive() As Boolean
			Get
				Return _cust_inactive
			End Get
			Set(ByVal Value As Boolean)
				_cust_inactive = value
				_isDirty = True
			End Set
		End Property
		Public Property Cust_InvoiceDetail() As Boolean
			Get
				Return _cust_invoicedetail
			End Get
			Set(ByVal Value As Boolean)
				_cust_invoicedetail = value
				_isDirty = True
			End Set
		End Property
		Public Property PlusParts() As Integer
			Get
				Return _plusparts
			End Get
			Set(ByVal Value As Integer)
				_plusparts = value
				_isDirty = True
			End Set
		End Property
		Public Property Cust_FlatRateParts() As Boolean
			Get
				Return _cust_flatrateparts
			End Get
			Set(ByVal Value As Boolean)
				_cust_flatrateparts = value
				_isDirty = True
			End Set
		End Property
		Public Property Cust_AutoShip() As Boolean
			Get
				Return _cust_autoship
			End Get
			Set(ByVal Value As Boolean)
				_cust_autoship = value
				_isDirty = True
			End Set
		End Property
		Public Property Cust_Stage() As Boolean
			Get
				Return _cust_stage
			End Get
			Set(ByVal Value As Boolean)
				_cust_stage = value
				_isDirty = True
			End Set
		End Property
		Public Property Cust_Pallett() As Boolean
			Get
				Return _cust_pallett
			End Get
			Set(ByVal Value As Boolean)
				_cust_pallett = value
				_isDirty = True
			End Set
		End Property
		Public Property Cust_RejectDays() As Integer
			Get
				Return _cust_rejectdays
			End Get
			Set(ByVal Value As Integer)
				_cust_rejectdays = value
				_isDirty = True
			End Set
		End Property
		Public Property Cust_RejectTimes() As Integer
			Get
				Return _cust_rejecttimes
			End Get
			Set(ByVal Value As Integer)
				_cust_rejecttimes = value
				_isDirty = True
			End Set
		End Property
		Public Property Cust_RepairNonWrty() As Boolean
			Get
				Return _cust_repairnonwrty
			End Get
			Set(ByVal Value As Boolean)
				_cust_repairnonwrty = value
				_isDirty = True
			End Set
		End Property
		Public Property Cust_ReplaceLCD() As Boolean
			Get
				Return _cust_replacelcd
			End Get
			Set(ByVal Value As Boolean)
				_cust_replacelcd = value
				_isDirty = True
			End Set
		End Property
		Public Property Cust_HSTech() As Boolean
			Get
				Return _cust_hstech
			End Get
			Set(ByVal Value As Boolean)
				_cust_hstech = value
				_isDirty = True
			End Set
		End Property
		Public Property Cust_SpecialCodes() As Boolean
			Get
				Return _cust_specialcodes
			End Get
			Set(ByVal Value As Boolean)
				_cust_specialcodes = value
				_isDirty = True
			End Set
		End Property
		Public Property Cust_CrApproveRec() As Boolean
			Get
				Return _cust_crapproverec
			End Get
			Set(ByVal Value As Boolean)
				_cust_crapproverec = value
				_isDirty = True
			End Set
		End Property
		Public Property Cust_CrApproveShip() As Boolean
			Get
				Return _cust_crapproveship
			End Get
			Set(ByVal Value As Boolean)
				_cust_crapproveship = value
				_isDirty = True
			End Set
		End Property
		Public Property Cust_CollSalesTax() As Boolean
			Get
				Return _cust_collsalestax
			End Get
			Set(ByVal Value As Boolean)
				_cust_collsalestax = value
				_isDirty = True
			End Set
		End Property
		Public Property Cust_Memo() As String
			Get
				Return _cust_memo
			End Get
			Set(ByVal Value As String)
				_cust_memo = value
				_isDirty = True
			End Set
		End Property
		Public Property Cust_ConsignedParts() As Boolean
			Get
				Return _cust_consignedparts
			End Get
			Set(ByVal Value As Boolean)
				_cust_consignedparts = value
				_isDirty = True
			End Set
		End Property
		Public Property BizType_ID() As Integer
			Get
				Return _biztype_id
			End Get
			Set(ByVal Value As Integer)
				_biztype_id = value
				_isDirty = True
			End Set
		End Property
		Public Property Pay_ID() As Integer
			Get
				Return _pay_id
			End Get
			Set(ByVal Value As Integer)
				_pay_id = value
				_isDirty = True
			End Set
		End Property
		Public Property PCo_ID() As Integer
			Get
				Return _pco_id
			End Get
			Set(ByVal Value As Integer)
				_pco_id = value
				_isDirty = True
			End Set
		End Property
		Public Property SlsP_ID() As Integer
			Get
				Return _slsp_id
			End Get
			Set(ByVal Value As Integer)
				_slsp_id = value
				_isDirty = True
			End Set
		End Property
		Public Property Cust_lvlShipCust() As Boolean
			Get
				Return _cust_lvlshipcust
			End Get
			Set(ByVal Value As Boolean)
				_cust_lvlshipcust = value
				_isDirty = True
			End Set
		End Property
		Public Property Cust_RecRcncl() As Boolean
			Get
				Return _cust_recrcncl
			End Get
			Set(ByVal Value As Boolean)
				_cust_recrcncl = value
				_isDirty = True
			End Set
		End Property
		Public Property Cust_PalletShip() As Boolean
			Get
				Return _cust_palletship
			End Get
			Set(ByVal Value As Boolean)
				_cust_palletship = value
				_isDirty = True
			End Set
		End Property
		Public Property Cust_AggBilling() As Boolean
			Get
				Return _cust_aggbilling
			End Get
			Set(ByVal Value As Boolean)
				_cust_aggbilling = value
				_isDirty = True
			End Set
		End Property
		Public Property Cust_AutoBill() As Integer
			Get
				Return _cust_autobill
			End Get
			Set(ByVal Value As Integer)
				_cust_autobill = value
				_isDirty = True
			End Set
		End Property
		Public Property Cust_CrBilling() As Boolean
			Get
				Return _cust_crbilling
			End Get
			Set(ByVal Value As Boolean)
				_cust_crbilling = value
				_isDirty = True
			End Set
		End Property
		Public Property InvDateType_ID() As Integer
			Get
				Return _invdatetype_id
			End Get
			Set(ByVal Value As Integer)
				_invdatetype_id = value
				_isDirty = True
			End Set
		End Property
		Public Property PredeterminePartNeed() As Integer
			Get
				Return _predeterminepartneed
			End Get
			Set(ByVal Value As Integer)
				_predeterminepartneed = value
				_isDirty = True
			End Set
		End Property
		Public Property DepartmentID() As Integer
			Get
				Return _departmentid
			End Get
			Set(ByVal Value As Integer)
				_departmentid = value
				_isDirty = True
			End Set
		End Property
		Public Property ReqAQLCheckOnAllUnit() As Integer
			Get
				Return _reqaqlcheckonallunit
			End Get
			Set(ByVal Value As Integer)
				_reqaqlcheckonallunit = value
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
		Public Property LastUpdateUserID() As String
			Get
				Return _lastupdateuserid
			End Get
			Set(ByVal Value As String)
				_lastupdateuserid = value
				_isDirty = True
			End Set
		End Property
		Public Property TAT() As Integer
			Get
				Return _tat
			End Get
			Set(ByVal Value As Integer)
				_tat = value
				_isDirty = True
			End Set
		End Property
		Public Property TechFailureCode() As Integer
			Get
				Return _techfailurecode
			End Get
			Set(ByVal Value As Integer)
				_techfailurecode = value
				_isDirty = True
			End Set
		End Property
		Public Property ReqOutboundTracking() As Integer
			Get
				Return _reqoutboundtracking
			End Get
			Set(ByVal Value As Integer)
				_reqoutboundtracking = value
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

		Protected Sub GetData(ByVal cust_id As Integer)
			Dim _sql As String = GetSelectStatement(cust_id)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Private Sub PopulateObject(ByVal _dr As DataRow)

			_cust_id = DirectCast(ConvertToSomething(_dr("cust_id"), 0), Integer)
			_cust_name1 = ConvertToSomething(_dr("cust_name1").ToString(), "")
			_cust_name2 = ConvertToSomething(_dr("cust_name2").ToString(), "")
			_cust_inactive = _dr("cust_inactive")
			_cust_invoicedetail = _dr("cust_invoicedetail")
			_plusparts = _dr("plusparts")
			_cust_flatrateparts = _dr("cust_flatrateparts")
			_cust_autoship = _dr("cust_autoship")
			_cust_stage = _dr("cust_stage")
			_cust_pallett = _dr("cust_pallett")
			_cust_rejectdays = DirectCast(ConvertToSomething(_dr("cust_rejectdays"), 0), Integer)
			_cust_rejecttimes = DirectCast(ConvertToSomething(_dr("cust_rejecttimes"), 0), Integer)
			_cust_repairnonwrty = _dr("cust_repairnonwrty")
			_cust_replacelcd = _dr("cust_replacelcd")
			_cust_hstech = _dr("cust_hstech")
			_cust_specialcodes = _dr("cust_specialcodes")
			_cust_crapproverec = _dr("cust_crapproverec")
			_cust_crapproveship = _dr("cust_crapproveship")
			_cust_collsalestax = _dr("cust_collsalestax")
			_cust_memo = ConvertToSomething(_dr("cust_memo").ToString(), "")
			_cust_consignedparts = _dr("cust_consignedparts")
			_biztype_id = DirectCast(ConvertToSomething(_dr("biztype_id"), 0), Integer)
			_pay_id = DirectCast(ConvertToSomething(_dr("pay_id"), 0), Integer)
			_pco_id = DirectCast(ConvertToSomething(_dr("pco_id"), 0), Integer)
			_slsp_id = DirectCast(ConvertToSomething(_dr("slsp_id"), 0), Integer)
			_cust_lvlshipcust = _dr("cust_lvlshipcust")
			_cust_recrcncl = _dr("cust_recrcncl")
			_cust_palletship = _dr("cust_palletship")
			_cust_aggbilling = _dr("cust_aggbilling")
			_cust_autobill = _dr("cust_autobill").ToString()
			_cust_crbilling = _dr("cust_crbilling")
			_invdatetype_id = _dr("invdatetype_id").ToString()
			_predeterminepartneed = _dr("predeterminepartneed").ToString()
			_departmentid = _dr("departmentid").ToString()
			_reqaqlcheckonallunit = _dr("reqaqlcheckonallunit").ToString()
			_lastupdatedt = ConvertToSomething(_dr("lastupdatedt").ToString(), "")
			_lastupdateuserid = ConvertToSomething(_dr("lastupdateuserid").ToString(), "")
			_tat = _dr("tat").ToString()
			_techfailurecode = _dr("techfailurecode").ToString()
			_reqoutboundtracking = _dr("reqoutboundtracking").ToString()
		End Sub
		Protected Function GetSelectStatement(ByVal cust_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "Cust_ID, "
			_sql += "Cust_Name1, "
			_sql += "Cust_Name2, "
			_sql += "Cust_Inactive, "
			_sql += "Cust_InvoiceDetail, "
			_sql += "PlusParts, "
			_sql += "Cust_FlatRateParts, "
			_sql += "Cust_AutoShip, "
			_sql += "Cust_Stage, "
			_sql += "Cust_Pallett, "
			_sql += "Cust_RejectDays, "
			_sql += "Cust_RejectTimes, "
			_sql += "Cust_RepairNonWrty, "
			_sql += "Cust_ReplaceLCD, "
			_sql += "Cust_HSTech, "
			_sql += "Cust_SpecialCodes, "
			_sql += "Cust_CrApproveRec, "
			_sql += "Cust_CrApproveShip, "
			_sql += "Cust_CollSalesTax, "
			_sql += "Cust_Memo, "
			_sql += "Cust_ConsignedParts, "
			_sql += "BizType_ID, "
			_sql += "Pay_ID, "
			_sql += "PCo_ID, "
			_sql += "SlsP_ID, "
			_sql += "Cust_lvlShipCust, "
			_sql += "Cust_RecRcncl, "
			_sql += "Cust_PalletShip, "
			_sql += "Cust_AggBilling, "
			_sql += "Cust_AutoBill, "
			_sql += "Cust_CrBilling, "
			_sql += "InvDateType_ID, "
			_sql += "PredeterminePartNeed, "
			_sql += "DepartmentID, "
			_sql += "ReqAQLCheckOnAllUnit, "
			_sql += "LastUpdateDT, "
			_sql += "LastUpdateUserID, "
			_sql += "TAT, "
			_sql += "TechFailureCode, "
			_sql += "ReqOutboundTracking "
			_sql += "FROM production.tcustomer "
			_sql += "WHERE cust_id = " & cust_id.ToString() & ""
			Return _sql
		End Function

		Public Sub ApplyChanges()
			If _isNew Then
				_cust_id = Insert()
			ElseIf IsDeleted Then
				' delete
			ElseIf IsDirty Then
				' Update
			End If
		End Sub

		Protected Function Insert() As Integer
			Throw New Exception("Not Implemented")

			Dim _id As Integer
			Dim strSQL, strToday As String
			'Try
			'	Dim objDataProc As DBQuery.DataProc
			'	objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
				'strToday = PSS.Data.Buisness.Generic.GetMySqlDateTime("%Y-%m-%d")
				'strSQL = "INSERT INTO production.tcustomer (" & _
				'   "cust_id, " & _
				'   "cust_name1, " & _
				'   "cust_name2, " & _
				'   "cust_inactive, " & _
				'   "cust_invoicedetail, " & _
				'   "plusparts, " & _
				'   "cust_flatrateparts, " & _
				'   "cust_autoship, " & _
				'   "cust_stage, " & _
				'   "cust_pallett, " & _
				'   "cust_rejectdays, " & _
				'   "cust_rejecttimes, " & _
				'   "cust_repairnonwrty, " & _
				'   "cust_replacelcd, " & _
				'   "cust_hstech, " & _
				'   "cust_specialcodes, " & _
				'   "cust_crapproverec, " & _
				'   "cust_crapproveship, " & _
				'   "cust_collsalestax, " & _
				'   "cust_memo, " & _
				'   "cust_consignedparts, " & _
				'   "biztype_id, " & _
				'   "pay_id, " & _
				'   "pco_id, " & _
				'   "slsp_id, " & _
				'   "cust_lvlshipcust, " & _
				'   "cust_recrcncl, " & _
				'   "cust_palletship, " & _
				'   "cust_aggbilling, " & _
				'   "cust_autobill, " & _
				'   "cust_crbilling, " & _
				'   "invdatetype_id, " & _
				'   "predeterminepartneed, " & _
				'   "departmentid, " & _
				'   "reqaqlcheckonallunit, " & _
				'   "lastupdatedt, " & _
				'   "lastupdateuserid, " & _
				'   "tat, " & _
				'   "techfailurecode, " & _
				'   "reqoutboundtracking " & _
				'  ") " & _
				'  "VALUES ( " & _
				'   _cust_id & " , " & _
				'   ConvertBackToNullString(_cust_name1, False) & " , " & _
				'   ConvertBackToNullString(_cust_name2, False) & " , " & _
				'   _cust_inactive & " , " & _
				'   ConvertBackToNullString(_cust_invoicedetail, False) & " , " & _
				'   ConvertBackToNullString(_plusparts, False) & " , " & _
				'   _cust_flatrateparts & " , " & _
				'   ConvertBackToNullString(_cust_autoship, False) & " , " & _
				'   _cust_stage & " , " & _
				'   _cust_pallett & " , " & _
				'   ConvertBackToNullString(_cust_rejectdays, False) & " , " & _
				'   ConvertBackToNullString(_cust_rejecttimes, False) & " , " & _
				'   _cust_repairnonwrty & " , " & _
				'   ConvertBackToNullString(_cust_replacelcd, False) & " , " & _
				'   _cust_hstech & " , " & _
				'   _cust_specialcodes & " , " & _
				'   ConvertBackToNullString(_cust_crapproverec, False) & " , " & _
				'   ConvertBackToNullString(_cust_crapproveship, False) & " , " & _
				'   ConvertBackToNullString(_cust_collsalestax, False) & " , " & _
				'   ConvertBackToNullString(_cust_memo, False) & " , " & _
				'   ConvertBackToNullString(_cust_consignedparts, False) & " , " & _
				'   _biztype_id & " , " & _
				'   ConvertBackToNullString(_pay_id, False) & " , " & _
				'   ConvertBackToNullString(_pco_id, False) & " , " & _
				'   ConvertBackToNullString(_slsp_id, False) & " , " & _
				'   ConvertBackToNullString(_cust_lvlshipcust, False) & " , " & _
				'   ConvertBackToNullString(_cust_recrcncl, False) & " , " & _
				'   ConvertBackToNullString(_cust_palletship, False) & " , " & _
				'   ConvertBackToNullString(_cust_aggbilling, False) & " , " & _
				'   _cust_autobill & " , " & _
				'   ConvertBackToNullString(_cust_crbilling, False) & " , " & _
				'   _invdatetype_id & " , " & _
				'   _predeterminepartneed & " , " & _
				'   _departmentid & " , " & _
				'   _reqaqlcheckonallunit & " , " & _
				'   ConvertBackToNullString(_lastupdatedt, False) & " , " & _
				'   _lastupdateuserid & " , " & _
				'   _tat & " , " & _
				'   _techfailurecode & " , " & _
				'   _reqoutboundtracking & "  " & _
				'   ")"
				Return _id
			'Catch ex As Exception
			'	If InStr(ex.Message, "Duplicate") > 0 Then
			'		Throw New Exception("Duplicate exists.")
			'	Else
			'		Throw ex
			'	End If
			'End Try
		End Function

		Protected Function Update() As Integer
			Throw New Exception("Not Implemented")

			Dim strSQL, strToday As String
			Try
				Dim objDataProc As DBQuery.DataProc
				Dim _id As Integer
				objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
				'	strToday = PSS.Data.Buisness.Generic.GetMySqlDateTime("%Y-%m-%d")
				'	strSQL = "UPDATE production.tcustomer SET " & _
				'	   "cust_id = " & ConvertBackToNullString(_cust_id, False) & ", " & _
				'	   "cust_name1 = " & ConvertBackToNullString(_cust_name1, False) & ", " & _
				'	   "cust_name2 = " & ConvertBackToNullString(_cust_name2, False) & ", " & _
				'	   "cust_inactive = " & ConvertBackToNullString(_cust_inactive, False) & ", " & _
				'	   "cust_invoicedetail = " & ConvertBackToNullString(_cust_invoicedetail, False) & ", " & _
				'	   "plusparts = " & ConvertBackToNullString(_plusparts, False) & ", " & _
				'	   "cust_flatrateparts = " & ConvertBackToNullString(_cust_flatrateparts, False) & ", " & _
				'	   "cust_autoship = " & ConvertBackToNullString(_cust_autoship, False) & ", " & _
				'	   "cust_stage = " & ConvertBackToNullString(_cust_stage, False) & ", " & _
				'	   "cust_pallett = " & ConvertBackToNullString(_cust_pallett, False) & ", " & _
				'	   "cust_rejectdays = " & ConvertBackToNullString(_cust_rejectdays, False) & ", " & _
				'	   "cust_rejecttimes = " & ConvertBackToNullString(_cust_rejecttimes, False) & ", " & _
				'	   "cust_repairnonwrty = " & ConvertBackToNullString(_cust_repairnonwrty, False) & ", " & _
				'	   "cust_replacelcd = " & ConvertBackToNullString(_cust_replacelcd, False) & ", " & _
				'	   "cust_hstech = " & ConvertBackToNullString(_cust_hstech, False) & ", " & _
				'	   "cust_specialcodes = " & ConvertBackToNullString(_cust_specialcodes, False) & ", " & _
				'	   "cust_crapproverec = " & ConvertBackToNullString(_cust_crapproverec, False) & ", " & _
				'	   "cust_crapproveship = " & ConvertBackToNullString(_cust_crapproveship, False) & ", " & _
				'	   "cust_collsalestax = " & ConvertBackToNullString(_cust_collsalestax, False) & ", " & _
				'	   "cust_memo = " & ConvertBackToNullString(_cust_memo, False) & ", " & _
				'	   "cust_consignedparts = " & ConvertBackToNullString(_cust_consignedparts, False) & ", " & _
				'	   "biztype_id = " & ConvertBackToNullString(_biztype_id, False) & ", " & _
				'	   "pay_id = " & ConvertBackToNullString(_pay_id, False) & ", " & _
				'	   "pco_id = " & ConvertBackToNullString(_pco_id, False) & ", " & _
				'	   "slsp_id = " & ConvertBackToNullString(_slsp_id, False) & ", " & _
				'	   "cust_lvlshipcust = " & ConvertBackToNullString(_cust_lvlshipcust, False) & ", " & _
				'	   "cust_recrcncl = " & ConvertBackToNullString(_cust_recrcncl, False) & ", " & _
				'	   "cust_palletship = " & ConvertBackToNullString(_cust_palletship, False) & ", " & _
				'	   "cust_aggbilling = " & ConvertBackToNullString(_cust_aggbilling, False) & ", " & _
				'	   "cust_autobill = " & ConvertBackToNullString(_cust_autobill, False) & ", " & _
				'	   "cust_crbilling = " & ConvertBackToNullString(_cust_crbilling, False) & ", " & _
				'	   "invdatetype_id = " & ConvertBackToNullString(_invdatetype_id, False) & ", " & _
				'	   "predeterminepartneed = " & ConvertBackToNullString(_predeterminepartneed, False) & ", " & _
				'	   "departmentid = " & ConvertBackToNullString(_departmentid, False) & ", " & _
				'	   "reqaqlcheckonallunit = " & ConvertBackToNullString(_reqaqlcheckonallunit, False) & ", " & _
				'	   "lastupdatedt = " & ConvertBackToNullString(_lastupdatedt, False) & ", " & _
				'	   "lastupdateuserid = " & ConvertBackToNullString(_lastupdateuserid, False) & ", " & _
				'	   "tat = " & ConvertBackToNullString(_tat, False) & ", " & _
				'	   "techfailurecode = " & ConvertBackToNullString(_techfailurecode, False) & ", " & _
				'	   "reqoutboundtracking = " & ConvertBackToNullString(_reqoutboundtracking, False) & ", " & _
				'	  ") " & _
				'	  "WHERE Cust_ID = " & Cust_ID.ToString() & "; "
				Return objDataProc.ExecuteNonQuery(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

#End Region

	End Class

	Public Class tcustomerCollection
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

		Public ReadOnly Property tcustomerDataTable() As DataTable
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
			Dim _sql As String
			_sql = "SELECT "
			_sql += "Cust_ID, "
			_sql += "Cust_Name1 "
			'_sql += "Cust_Name2, "
			'_sql += "Cust_Inactive, "
			'_sql += "Cust_InvoiceDetail, "
			'_sql += "PlusParts, "
			'_sql += "Cust_FlatRateParts, "
			'_sql += "Cust_AutoShip, "
			'_sql += "Cust_Stage, "
			'_sql += "Cust_Pallett, "
			'_sql += "Cust_RejectDays, "
			'_sql += "Cust_RejectTimes, "
			'_sql += "Cust_RepairNonWrty, "
			'_sql += "Cust_ReplaceLCD, "
			'_sql += "Cust_HSTech, "
			'_sql += "Cust_SpecialCodes, "
			'_sql += "Cust_CrApproveRec, "
			'_sql += "Cust_CrApproveShip, "
			'_sql += "Cust_CollSalesTax, "
			'_sql += "Cust_Memo, "
			'_sql += "Cust_ConsignedParts, "
			'_sql += "BizType_ID, "
			'_sql += "Pay_ID, "
			'_sql += "PCo_ID, "
			'_sql += "SlsP_ID, "
			'_sql += "Cust_lvlShipCust, "
			'_sql += "Cust_RecRcncl, "
			'_sql += "Cust_PalletShip, "
			'_sql += "Cust_AggBilling, "
			'_sql += "Cust_AutoBill, "
			'_sql += "Cust_CrBilling, "
			'_sql += "InvDateType_ID, "
			'_sql += "PredeterminePartNeed, "
			'_sql += "DepartmentID, "
			'_sql += "ReqAQLCheckOnAllUnit, "
			'_sql += "LastUpdateDT, "
			'_sql += "LastUpdateUserID, "
			'_sql += "TAT, "
			'_sql += "TechFailureCode, "
			'_sql += "ReqOutboundTracking "
			_sql += "FROM production.tcustomer; "
			Return _sql
		End Function

#End Region
	End Class

	Public Class tcustomerFilteredCollection
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

		Public ReadOnly Property tcustomerDataTable() As DataTable
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
			Dim _sql As String
			_sql = "SELECT "
			_sql += "c.Cust_ID as cust_id, "
			_sql += "c.Cust_Name1 as cust_name1 "
			_sql += "FROM production.tcustomer c "
			_sql += "INNER JOIN production.tcustomer_list_filter clf ON c.cust_id = clf.cust_id "
			_sql += "ORDER BY c.cust_name1; "
			Return _sql
		End Function

#End Region
	End Class

End Namespace
