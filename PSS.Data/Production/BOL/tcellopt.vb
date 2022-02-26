Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic
Namespace BOL
	Public Class tcellopt
#Region "DECLARATIONS"

		Private _cellopt_id As Integer = 0
		Private _cellopt_msn As String = ""
		Private _cellopt_fname As String = ""
		Private _cellopt_lname As String = ""
		Private _cellopt_pop As String
		Private _cellopt_apc As String = ""
		Private _cellopt_claim As String = ""
		Private _cellopt_member As String = ""
		Private _cellopt_prodcode As String = ""
		Private _cellopt_datecode As String = ""
		Private _cellopt_modlenumb As String = ""
		Private _cellopt_courier As String = ""
		Private _cellopt_transceiver As String = ""
		Private _cellopt_imei As String = ""
		Private _cellopt_csn As String = ""
		Private _cellopt_csn_dec As String = ""
		Private _cellopt_min As String = ""
		Private _cellopt_carrmodcode As String = ""
		Private _cellopt_outmsn As String = ""
		Private _cellopt_outimei As String = ""
		Private _cellopt_outcsn As String = ""
		Private _cellopt_softverin As String = ""
		Private _cellopt_softverout As String = ""
		Private _cellopt_ssid As String = ""
		Private _cellopt_techid As String = ""
		Private _cellopt_aircarrcode As String = ""
		Private _cellopt_airtime As String = ""
		Private _cellopt_repairstatus As String = ""
		Private _cellopt_repairdate As String
		Private _cellopt_repairtime As String = ""
		Private _cellopt_failure As Integer = 0
		Private _cellopt_complaint As Integer = 0
		Private _cellopt_transaction As String = ""
		Private _cellopt_cycletime As String = ""
		Private _cellopt_sugin As String = ""
		Private _cellopt_sugout As String = ""
		Private _cellopt_verificationid As String = ""
		Private _cellopt_ptfunc As Integer = 0
		Private _cellopt_ptflash As Integer = 0
		Private _cellopt_ptrf As Integer = 0
		Private _cellopt_ptl As Integer = 0
		Private _cellopt_ptp As Integer = 0
		Private _cellopt_reconstatus As Boolean = False
		Private _cellopt_new As Boolean = False
		Private _device_id As Integer = 0
		Private _sc_id As Integer = 0
		Private _cellopt_wipowner As Integer = 0
		Private _cellopt_wipentrydt As String
		Private _cellopt_wipownerold As String = ""
		Private _workstation As String = ""
		Private _workstationentrydt As String
		Private _hasprebilllot As Boolean = False
		Private _comp_id As Integer = 0
		Private _skudiscrep As Boolean = False
		Private _rur_returntocust As Integer = 0
		Private _cellopt_techassigned As Integer = 0
		Private _cellopt_logictray As Integer = 0
		Private _cellopt_rework As Boolean = False
		Private _cellopt_refurbcompletedt As String
		Private _cellopt_refurbcompleteworkdt As String
		Private _cellopt_refurbcompleteuserid As Integer = 0
		Private _cellopt_refurbcompletelineid As Integer = 0
		Private _cellopt_techassigndate As String
		Private _cellopt_qcfailcode As Integer = 0
		Private _cellopt_qcreject As Boolean = False
		Private _wil_id As Integer = 0
		Private _manuf_sn As String = ""
		Private _outboundcosmgradeid As Integer = 0
		Private _inboundcosmgrade As Integer = 0
		Private _softkeycode As String = ""
		Private _pss_wrty_device_id As Integer = 0
		Private _pss_wrty_av_id As Integer = 0
		Private _pss_wrty_approval_dt As String
		Private _pss_wrty_approval_user_id As Integer = 0
		Private _sn_discp_av_id As Integer = 0
		Private _sn_discp_approved_dt As String
		Private _sn_discp_approved_user_id As Integer = 0
		Private _sn_discp_flag As Integer = 0
		Private _rptsent As Integer = 0
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

		Public Sub New(ByVal device_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(device_id)
			_isDirty = False
			_isNew = False
		End Sub

#End Region
#Region "PROPERTIES"

		Public Property CellOpt_ID() As Integer
			Get
				Return _cellopt_id
			End Get
			Set(ByVal Value As Integer)
				_cellopt_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_MSN() As String
			Get
				Return _cellopt_msn
			End Get
			Set(ByVal Value As String)
				_cellopt_msn = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_FName() As String
			Get
				Return _cellopt_fname
			End Get
			Set(ByVal Value As String)
				_cellopt_fname = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_LName() As String
			Get
				Return _cellopt_lname
			End Get
			Set(ByVal Value As String)
				_cellopt_lname = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_POP() As String
			Get
				Return _cellopt_pop
			End Get
			Set(ByVal Value As String)
				_cellopt_pop = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_APC() As String
			Get
				Return _cellopt_apc
			End Get
			Set(ByVal Value As String)
				_cellopt_apc = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_Claim() As String
			Get
				Return _cellopt_claim
			End Get
			Set(ByVal Value As String)
				_cellopt_claim = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_Member() As String
			Get
				Return _cellopt_member
			End Get
			Set(ByVal Value As String)
				_cellopt_member = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_ProdCode() As String
			Get
				Return _cellopt_prodcode
			End Get
			Set(ByVal Value As String)
				_cellopt_prodcode = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_DateCode() As String
			Get
				Return _cellopt_datecode
			End Get
			Set(ByVal Value As String)
				_cellopt_datecode = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_ModleNumb() As String
			Get
				Return _cellopt_modlenumb
			End Get
			Set(ByVal Value As String)
				_cellopt_modlenumb = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_Courier() As String
			Get
				Return _cellopt_courier
			End Get
			Set(ByVal Value As String)
				_cellopt_courier = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_Transceiver() As String
			Get
				Return _cellopt_transceiver
			End Get
			Set(ByVal Value As String)
				_cellopt_transceiver = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_IMEI() As String
			Get
				Return _cellopt_imei
			End Get
			Set(ByVal Value As String)
				_cellopt_imei = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_CSN() As String
			Get
				Return _cellopt_csn
			End Get
			Set(ByVal Value As String)
				_cellopt_csn = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_CSN_Dec() As String
			Get
				Return _cellopt_csn_dec
			End Get
			Set(ByVal Value As String)
				_cellopt_csn_dec = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_MIN() As String
			Get
				Return _cellopt_min
			End Get
			Set(ByVal Value As String)
				_cellopt_min = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_CarrModCode() As String
			Get
				Return _cellopt_carrmodcode
			End Get
			Set(ByVal Value As String)
				_cellopt_carrmodcode = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_OutMSN() As String
			Get
				Return _cellopt_outmsn
			End Get
			Set(ByVal Value As String)
				_cellopt_outmsn = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_OutIMEI() As String
			Get
				Return _cellopt_outimei
			End Get
			Set(ByVal Value As String)
				_cellopt_outimei = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_OutCSN() As String
			Get
				Return _cellopt_outcsn
			End Get
			Set(ByVal Value As String)
				_cellopt_outcsn = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_SoftVerIN() As String
			Get
				Return _cellopt_softverin
			End Get
			Set(ByVal Value As String)
				_cellopt_softverin = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_SoftVerOUT() As String
			Get
				Return _cellopt_softverout
			End Get
			Set(ByVal Value As String)
				_cellopt_softverout = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_SSID() As String
			Get
				Return _cellopt_ssid
			End Get
			Set(ByVal Value As String)
				_cellopt_ssid = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_TechID() As String
			Get
				Return _cellopt_techid
			End Get
			Set(ByVal Value As String)
				_cellopt_techid = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_AirCarrCode() As String
			Get
				Return _cellopt_aircarrcode
			End Get
			Set(ByVal Value As String)
				_cellopt_aircarrcode = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_Airtime() As String
			Get
				Return _cellopt_airtime
			End Get
			Set(ByVal Value As String)
				_cellopt_airtime = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_RepairStatus() As String
			Get
				Return _cellopt_repairstatus
			End Get
			Set(ByVal Value As String)
				_cellopt_repairstatus = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_RepairDate() As String
			Get
				Return _cellopt_repairdate
			End Get
			Set(ByVal Value As String)
				_cellopt_repairdate = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_RepairTime() As String
			Get
				Return _cellopt_repairtime
			End Get
			Set(ByVal Value As String)
				_cellopt_repairtime = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_Failure() As Integer
			Get
				Return _cellopt_failure
			End Get
			Set(ByVal Value As Integer)
				_cellopt_failure = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_Complaint() As Integer
			Get
				Return _cellopt_complaint
			End Get
			Set(ByVal Value As Integer)
				_cellopt_complaint = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_Transaction() As String
			Get
				Return _cellopt_transaction
			End Get
			Set(ByVal Value As String)
				_cellopt_transaction = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_CycleTime() As String
			Get
				Return _cellopt_cycletime
			End Get
			Set(ByVal Value As String)
				_cellopt_cycletime = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_SugIn() As String
			Get
				Return _cellopt_sugin
			End Get
			Set(ByVal Value As String)
				_cellopt_sugin = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_SugOut() As String
			Get
				Return _cellopt_sugout
			End Get
			Set(ByVal Value As String)
				_cellopt_sugout = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_VerificationID() As String
			Get
				Return _cellopt_verificationid
			End Get
			Set(ByVal Value As String)
				_cellopt_verificationid = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_PTfunc() As Integer
			Get
				Return _cellopt_ptfunc
			End Get
			Set(ByVal Value As Integer)
				_cellopt_ptfunc = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_PTflash() As Integer
			Get
				Return _cellopt_ptflash
			End Get
			Set(ByVal Value As Integer)
				_cellopt_ptflash = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_PTrf() As Integer
			Get
				Return _cellopt_ptrf
			End Get
			Set(ByVal Value As Integer)
				_cellopt_ptrf = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_PTL() As Integer
			Get
				Return _cellopt_ptl
			End Get
			Set(ByVal Value As Integer)
				_cellopt_ptl = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_PTP() As Integer
			Get
				Return _cellopt_ptp
			End Get
			Set(ByVal Value As Integer)
				_cellopt_ptp = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_ReconStatus() As Boolean
			Get
				Return _cellopt_reconstatus
			End Get
			Set(ByVal Value As Boolean)
				_cellopt_reconstatus = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_NEW() As Boolean
			Get
				Return _cellopt_new
			End Get
			Set(ByVal Value As Boolean)
				_cellopt_new = Value
				_isDirty = True
			End Set
		End Property
		Public Property Device_ID() As Integer
			Get
				Return _device_id
			End Get
			Set(ByVal Value As Integer)
				_device_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property SC_ID() As Integer
			Get
				Return _sc_id
			End Get
			Set(ByVal Value As Integer)
				_sc_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property Cellopt_WIPOwner() As Integer
			Get
				Return _cellopt_wipowner
			End Get
			Set(ByVal Value As Integer)
				_cellopt_wipowner = Value
				_isDirty = True
			End Set
		End Property
		Public Property Cellopt_WIPEntryDt() As String
			Get
				Return _cellopt_wipentrydt
			End Get
			Set(ByVal Value As String)
				_cellopt_wipentrydt = Value
				_isDirty = True
			End Set
		End Property
		Public Property Cellopt_WIPOwnerOld() As String
			Get
				Return _cellopt_wipownerold
			End Get
			Set(ByVal Value As String)
				_cellopt_wipownerold = Value
				_isDirty = True
			End Set
		End Property
		Public Property WorkStation() As String
			Get
				Return _workstation
			End Get
			Set(ByVal Value As String)
				_workstation = Value
				_isDirty = True
			End Set
		End Property
		Public Property WorkStationEntryDt() As String
			Get
				Return _workstationentrydt
			End Get
			Set(ByVal Value As String)
				_workstationentrydt = Value
				_isDirty = True
			End Set
		End Property
		Public Property HasPreBillLot() As Boolean
			Get
				Return _hasprebilllot
			End Get
			Set(ByVal Value As Boolean)
				_hasprebilllot = Value
				_isDirty = True
			End Set
		End Property
		Public Property Comp_ID() As Integer
			Get
				Return _comp_id
			End Get
			Set(ByVal Value As Integer)
				_comp_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property skuDiscrep() As Boolean
			Get
				Return _skudiscrep
			End Get
			Set(ByVal Value As Boolean)
				_skudiscrep = Value
				_isDirty = True
			End Set
		End Property
		Public Property RUR_ReturnToCust() As Integer
			Get
				Return _rur_returntocust
			End Get
			Set(ByVal Value As Integer)
				_rur_returntocust = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_TechAssigned() As Integer
			Get
				Return _cellopt_techassigned
			End Get
			Set(ByVal Value As Integer)
				_cellopt_techassigned = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_LogicTray() As Integer
			Get
				Return _cellopt_logictray
			End Get
			Set(ByVal Value As Integer)
				_cellopt_logictray = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_Rework() As Boolean
			Get
				Return _cellopt_rework
			End Get
			Set(ByVal Value As Boolean)
				_cellopt_rework = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_RefurbCompleteDt() As String
			Get
				Return _cellopt_refurbcompletedt
			End Get
			Set(ByVal Value As String)
				_cellopt_refurbcompletedt = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_RefurbCompleteWorkDt() As String
			Get
				Return _cellopt_refurbcompleteworkdt
			End Get
			Set(ByVal Value As String)
				_cellopt_refurbcompleteworkdt = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_RefurbCompleteUserID() As Integer
			Get
				Return _cellopt_refurbcompleteuserid
			End Get
			Set(ByVal Value As Integer)
				_cellopt_refurbcompleteuserid = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_RefurbCompleteLineID() As Integer
			Get
				Return _cellopt_refurbcompletelineid
			End Get
			Set(ByVal Value As Integer)
				_cellopt_refurbcompletelineid = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_TechAssignDate() As String
			Get
				Return _cellopt_techassigndate
			End Get
			Set(ByVal Value As String)
				_cellopt_techassigndate = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_QCFailCode() As Integer
			Get
				Return _cellopt_qcfailcode
			End Get
			Set(ByVal Value As Integer)
				_cellopt_qcfailcode = Value
				_isDirty = True
			End Set
		End Property
		Public Property CellOpt_QCReject() As Boolean
			Get
				Return _cellopt_qcreject
			End Get
			Set(ByVal Value As Boolean)
				_cellopt_qcreject = Value
				_isDirty = True
			End Set
		End Property
		Public Property WIL_ID() As Integer
			Get
				Return _wil_id
			End Get
			Set(ByVal Value As Integer)
				_wil_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property Manuf_SN() As String
			Get
				Return _manuf_sn
			End Get
			Set(ByVal Value As String)
				_manuf_sn = Value
				_isDirty = True
			End Set
		End Property
		Public Property OutBoundCosmGradeID() As Integer
			Get
				Return _outboundcosmgradeid
			End Get
			Set(ByVal Value As Integer)
				_outboundcosmgradeid = Value
				_isDirty = True
			End Set
		End Property
		Public Property InBoundCosmGrade() As Integer
			Get
				Return _inboundcosmgrade
			End Get
			Set(ByVal Value As Integer)
				_inboundcosmgrade = Value
				_isDirty = True
			End Set
		End Property
		Public Property SoftKeyCode() As String
			Get
				Return _softkeycode
			End Get
			Set(ByVal Value As String)
				_softkeycode = Value
				_isDirty = True
			End Set
		End Property
		Public Property PSS_Wrty_Device_ID() As Integer
			Get
				Return _pss_wrty_device_id
			End Get
			Set(ByVal Value As Integer)
				_pss_wrty_device_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property PSS_Wrty_AV_ID() As Integer
			Get
				Return _pss_wrty_av_id
			End Get
			Set(ByVal Value As Integer)
				_pss_wrty_av_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property PSS_Wrty_Approval_DT() As String
			Get
				Return _pss_wrty_approval_dt
			End Get
			Set(ByVal Value As String)
				_pss_wrty_approval_dt = Value
				_isDirty = True
			End Set
		End Property
		Public Property PSS_Wrty_Approval_User_ID() As Integer
			Get
				Return _pss_wrty_approval_user_id
			End Get
			Set(ByVal Value As Integer)
				_pss_wrty_approval_user_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property SN_Discp_AV_ID() As Integer
			Get
				Return _sn_discp_av_id
			End Get
			Set(ByVal Value As Integer)
				_sn_discp_av_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property SN_Discp_Approved_DT() As String
			Get
				Return _sn_discp_approved_dt
			End Get
			Set(ByVal Value As String)
				_sn_discp_approved_dt = Value
				_isDirty = True
			End Set
		End Property
		Public Property SN_Discp_Approved_User_ID() As Integer
			Get
				Return _sn_discp_approved_user_id
			End Get
			Set(ByVal Value As Integer)
				_sn_discp_approved_user_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property SN_Discp_Flag() As Integer
			Get
				Return _sn_discp_flag
			End Get
			Set(ByVal Value As Integer)
				_sn_discp_flag = Value
				_isDirty = True
			End Set
		End Property
		Public Property RptSent() As Integer
			Get
				Return _rptsent
			End Get
			Set(ByVal Value As Integer)
				_rptsent = Value
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
		Protected Sub GetData(ByVal device_id As Integer)
			Dim _sql As String = GetSelectStatement(device_id)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Private Sub PopulateObject(ByVal _dr As DataRow)

			_cellopt_id = ConvertToSomething(_dr("cellopt_id"), 0)
			_cellopt_msn = ConvertToSomething(_dr("cellopt_msn").ToString(), "")
			_cellopt_fname = ConvertToSomething(_dr("cellopt_fname").ToString(), "")
			_cellopt_lname = ConvertToSomething(_dr("cellopt_lname").ToString(), "")
			_cellopt_pop = ConvertToSomething(_dr("cellopt_pop").ToString(), "")
			_cellopt_apc = ConvertToSomething(_dr("cellopt_apc").ToString(), "")
			_cellopt_claim = ConvertToSomething(_dr("cellopt_claim").ToString(), "")
			_cellopt_member = ConvertToSomething(_dr("cellopt_member").ToString(), "")
			_cellopt_prodcode = ConvertToSomething(_dr("cellopt_prodcode").ToString(), "")
			_cellopt_datecode = ConvertToSomething(_dr("cellopt_datecode").ToString(), "")
			_cellopt_modlenumb = ConvertToSomething(_dr("cellopt_modlenumb").ToString(), "")
			_cellopt_courier = ConvertToSomething(_dr("cellopt_courier").ToString(), "")
			_cellopt_transceiver = ConvertToSomething(_dr("cellopt_transceiver").ToString(), "")
			_cellopt_imei = ConvertToSomething(_dr("cellopt_imei").ToString(), "")
			_cellopt_csn = ConvertToSomething(_dr("cellopt_csn").ToString(), "")
			_cellopt_csn_dec = ConvertToSomething(_dr("cellopt_csn_dec").ToString(), "")
			_cellopt_min = ConvertToSomething(_dr("cellopt_min").ToString(), "")
			_cellopt_carrmodcode = ConvertToSomething(_dr("cellopt_carrmodcode").ToString(), "")
			_cellopt_outmsn = ConvertToSomething(_dr("cellopt_outmsn").ToString(), "")
			_cellopt_outimei = ConvertToSomething(_dr("cellopt_outimei").ToString(), "")
			_cellopt_outcsn = ConvertToSomething(_dr("cellopt_outcsn").ToString(), "")
			_cellopt_softverin = ConvertToSomething(_dr("cellopt_softverin").ToString(), "")
			_cellopt_softverout = ConvertToSomething(_dr("cellopt_softverout").ToString(), "")
			_cellopt_ssid = ConvertToSomething(_dr("cellopt_ssid").ToString(), "")
			_cellopt_techid = ConvertToSomething(_dr("cellopt_techid").ToString(), "")
			_cellopt_aircarrcode = ConvertToSomething(_dr("cellopt_aircarrcode").ToString(), "")
			_cellopt_airtime = ConvertToSomething(_dr("cellopt_airtime").ToString(), "")
			_cellopt_repairstatus = ConvertToSomething(_dr("cellopt_repairstatus").ToString(), "")
			_cellopt_repairdate = ConvertToSomething(_dr("cellopt_repairdate").ToString(), "")
			_cellopt_repairtime = ConvertToSomething(_dr("cellopt_repairtime").ToString(), "")
			_cellopt_failure = ConvertToSomething(_dr("cellopt_failure"), 0)
			_cellopt_complaint = ConvertToSomething(_dr("cellopt_complaint"), 0)
			_cellopt_transaction = ConvertToSomething(_dr("cellopt_transaction").ToString(), "")
			_cellopt_cycletime = ConvertToSomething(_dr("cellopt_cycletime").ToString(), "")
			_cellopt_sugin = ConvertToSomething(_dr("cellopt_sugin").ToString(), "")
			_cellopt_sugout = ConvertToSomething(_dr("cellopt_sugout").ToString(), "")
			_cellopt_verificationid = ConvertToSomething(_dr("cellopt_verificationid").ToString(), "")
			_cellopt_ptfunc = ConvertToSomething(_dr("cellopt_ptfunc"), 0)
			_cellopt_ptflash = ConvertToSomething(_dr("cellopt_ptflash"), 0)
			_cellopt_ptrf = ConvertToSomething(_dr("cellopt_ptrf"), 0)
			_cellopt_ptl = ConvertToSomething(_dr("cellopt_ptl"), 0)
			_cellopt_ptp = ConvertToSomething(_dr("cellopt_ptp"), 0)
			_cellopt_reconstatus = IIf(_dr("cellopt_reconstatus"), 1, 0)
			_cellopt_new = IIf(_dr("cellopt_new") = 1, True, False)
			_device_id = ConvertToSomething(_dr("device_id"), 0)
			_sc_id = ConvertToSomething(_dr("sc_id"), 0)
			_cellopt_wipowner = ConvertToSomething(_dr("cellopt_wipowner"), 0)
			_cellopt_wipentrydt = ConvertToSomething(_dr("cellopt_wipentrydt").ToString(), "")
			_cellopt_wipownerold = ConvertToSomething(_dr("cellopt_wipownerold").ToString(), "")
			_workstation = ConvertToSomething(_dr("workstation").ToString(), "")
			_workstationentrydt = ConvertToSomething(_dr("workstationentrydt").ToString(), "")
			_hasprebilllot = IIf(_dr("hasprebilllot") = 1, True, False)
			_comp_id = ConvertToSomething(_dr("comp_id"), 0)
			_skudiscrep = IIf(_dr("skudiscrep") = 1, True, False)
			_rur_returntocust = _dr("rur_returntocust").ToString()
			_cellopt_techassigned = ConvertToSomething(_dr("cellopt_techassigned"), 0)
			_cellopt_logictray = ConvertToSomething(_dr("cellopt_logictray"), 0)
			_cellopt_rework = IIf(_dr("cellopt_rework") = 1, True, False)
			_cellopt_refurbcompletedt = ConvertToSomething(_dr("cellopt_refurbcompletedt").ToString(), "")
			_cellopt_refurbcompleteworkdt = ConvertToSomething(_dr("cellopt_refurbcompleteworkdt").ToString(), "")
			_cellopt_refurbcompleteuserid = ConvertToSomething(_dr("cellopt_refurbcompleteuserid"), 0)
			_cellopt_refurbcompletelineid = ConvertToSomething(_dr("cellopt_refurbcompletelineid"), 0)
			_cellopt_techassigndate = ConvertToSomething(_dr("cellopt_techassigndate").ToString(), "")
			_cellopt_qcfailcode = ConvertToSomething(_dr("cellopt_qcfailcode"), 0)
			_cellopt_qcreject = IIf(_dr("cellopt_qcreject") = 1, True, False)
			_wil_id = _dr("wil_id").ToString()
			_manuf_sn = ConvertToSomething(_dr("manuf_sn").ToString(), "")
			_outboundcosmgradeid = _dr("outboundcosmgradeid").ToString()
			_inboundcosmgrade = _dr("inboundcosmgrade").ToString()
			_softkeycode = ConvertToSomething(_dr("softkeycode").ToString(), "")
			_pss_wrty_device_id = ConvertToSomething(_dr("pss_wrty_device_id"), 0)
			_pss_wrty_av_id = _dr("pss_wrty_av_id").ToString()
			_pss_wrty_approval_dt = ConvertToSomething(_dr("pss_wrty_approval_dt").ToString(), "")
			_pss_wrty_approval_user_id = _dr("pss_wrty_approval_user_id").ToString()
			_sn_discp_av_id = ConvertToSomething(_dr("sn_discp_av_id"), 0)
			_sn_discp_approved_dt = ConvertToSomething(_dr("sn_discp_approved_dt").ToString(), "")
			_sn_discp_approved_user_id = ConvertToSomething(_dr("sn_discp_approved_user_id"), 0)
			_sn_discp_flag = ConvertToSomething(_dr("sn_discp_flag"), 0)
			_rptsent = _dr("rptsent").ToString()
		End Sub
		Protected Function GetSelectStatement(ByVal device_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "CellOpt_ID, "
			_sql += "CellOpt_MSN, "
			_sql += "CellOpt_FName, "
			_sql += "CellOpt_LName, "
			_sql += "CellOpt_POP, "
			_sql += "CellOpt_APC, "
			_sql += "CellOpt_Claim, "
			_sql += "CellOpt_Member, "
			_sql += "CellOpt_ProdCode, "
			_sql += "CellOpt_DateCode, "
			_sql += "CellOpt_ModleNumb, "
			_sql += "CellOpt_Courier, "
			_sql += "CellOpt_Transceiver, "
			_sql += "CellOpt_IMEI, "
			_sql += "CellOpt_CSN, "
			_sql += "CellOpt_CSN_Dec, "
			_sql += "CellOpt_MIN, "
			_sql += "CellOpt_CarrModCode, "
			_sql += "CellOpt_OutMSN, "
			_sql += "CellOpt_OutIMEI, "
			_sql += "CellOpt_OutCSN, "
			_sql += "CellOpt_SoftVerIN, "
			_sql += "CellOpt_SoftVerOUT, "
			_sql += "CellOpt_SSID, "
			_sql += "CellOpt_TechID, "
			_sql += "CellOpt_AirCarrCode, "
			_sql += "CellOpt_Airtime, "
			_sql += "CellOpt_RepairStatus, "
			_sql += "CellOpt_RepairDate, "
			_sql += "CellOpt_RepairTime, "
			_sql += "CellOpt_Failure, "
			_sql += "CellOpt_Complaint, "
			_sql += "CellOpt_Transaction, "
			_sql += "CellOpt_CycleTime, "
			_sql += "CellOpt_SugIn, "
			_sql += "CellOpt_SugOut, "
			_sql += "CellOpt_VerificationID, "
			_sql += "CellOpt_PTfunc, "
			_sql += "CellOpt_PTflash, "
			_sql += "CellOpt_PTrf, "
			_sql += "CellOpt_PTL, "
			_sql += "CellOpt_PTP, "
			_sql += "CellOpt_ReconStatus, "
			_sql += "CellOpt_NEW, "
			_sql += "Device_ID, "
			_sql += "SC_ID, "
			_sql += "Cellopt_WIPOwner, "
			_sql += "Cellopt_WIPEntryDt, "
			_sql += "Cellopt_WIPOwnerOld, "
			_sql += "WorkStation, "
			_sql += "WorkStationEntryDt, "
			_sql += "HasPreBillLot, "
			_sql += "Comp_ID, "
			_sql += "skuDiscrep, "
			_sql += "RUR_ReturnToCust, "
			_sql += "CellOpt_TechAssigned, "
			_sql += "CellOpt_LogicTray, "
			_sql += "CellOpt_Rework, "
			_sql += "CellOpt_RefurbCompleteDt, "
			_sql += "CellOpt_RefurbCompleteWorkDt, "
			_sql += "CellOpt_RefurbCompleteUserID, "
			_sql += "CellOpt_RefurbCompleteLineID, "
			_sql += "CellOpt_TechAssignDate, "
			_sql += "CellOpt_QCFailCode, "
			_sql += "CellOpt_QCReject, "
			_sql += "WIL_ID, "
			_sql += "Manuf_SN, "
			_sql += "OutBoundCosmGradeID, "
			_sql += "InBoundCosmGrade, "
			_sql += "SoftKeyCode, "
			_sql += "PSS_Wrty_Device_ID, "
			_sql += "PSS_Wrty_AV_ID, "
			_sql += "PSS_Wrty_Approval_DT, "
			_sql += "PSS_Wrty_Approval_User_ID, "
			_sql += "SN_Discp_AV_ID, "
			_sql += "SN_Discp_Approved_DT, "
			_sql += "SN_Discp_Approved_User_ID, "
			_sql += "SN_Discp_Flag, "
			_sql += "RptSent "
			_sql += "FROM production.tcellopt "
			_sql += "WHERE device_id = " & device_id.ToString() & ""
			Return _sql
		End Function
		Public Sub ApplyChanges()
			If _isNew Then
				_cellopt_id = Insert()
			ElseIf IsDeleted Then
				Throw New Exception("Delete not implemented.")
			ElseIf IsDirty Then
				Update()
			End If
		End Sub
		Protected Function Insert() As Integer
			Dim strSQL, strToday As String
			Try
				_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
				Dim _id As Integer
				strToday = PSS.Data.Buisness.Generic.GetMySqlDateTime("%Y-%m-%d")
				strSQL = "INSERT INTO production.tcellopt (" & _
				   "cellopt_id, " & _
				   "cellopt_msn, " & _
				   "cellopt_fname, " & _
				   "cellopt_lname, " & _
				   "cellopt_pop, " & _
				   "cellopt_apc, " & _
				   "cellopt_claim, " & _
				   "cellopt_member, " & _
				   "cellopt_prodcode, " & _
				   "cellopt_datecode, " & _
				   "cellopt_modlenumb, " & _
				   "cellopt_courier, " & _
				   "cellopt_transceiver, " & _
				   "cellopt_imei, " & _
				   "cellopt_csn, " & _
				   "cellopt_csn_dec, " & _
				   "cellopt_min, " & _
				   "cellopt_carrmodcode, " & _
				   "cellopt_outmsn, " & _
				   "cellopt_outimei, " & _
				   "cellopt_outcsn, " & _
				   "cellopt_softverin, " & _
				   "cellopt_softverout, " & _
				   "cellopt_ssid, " & _
				   "cellopt_techid, " & _
				   "cellopt_aircarrcode, " & _
				   "cellopt_airtime, " & _
				   "cellopt_repairstatus, " & _
				   "cellopt_repairdate, " & _
				   "cellopt_repairtime, " & _
				   "cellopt_failure, " & _
				   "cellopt_complaint, " & _
				   "cellopt_transaction, " & _
				   "cellopt_cycletime, " & _
				   "cellopt_sugin, " & _
				   "cellopt_sugout, " & _
				   "cellopt_verificationid, " & _
				   "cellopt_ptfunc, " & _
				   "cellopt_ptflash, " & _
				   "cellopt_ptrf, " & _
				   "cellopt_ptl, " & _
				   "cellopt_ptp, " & _
				   "cellopt_reconstatus, " & _
				   "cellopt_new, " & _
				   "device_id, " & _
				   "sc_id, " & _
				   "cellopt_wipowner, " & _
				   "cellopt_wipentrydt, " & _
				   "cellopt_wipownerold, " & _
				   "workstation, " & _
				   "workstationentrydt, " & _
				   "hasprebilllot, " & _
				   "comp_id, " & _
				   "skudiscrep, " & _
				   "rur_returntocust, " & _
				   "cellopt_techassigned, " & _
				   "cellopt_logictray, " & _
				   "cellopt_rework, " & _
				   "cellopt_refurbcompletedt, " & _
				   "cellopt_refurbcompleteworkdt, " & _
				   "cellopt_refurbcompleteuserid, " & _
				   "cellopt_refurbcompletelineid, " & _
				   "cellopt_techassigndate, " & _
				   "cellopt_qcfailcode, " & _
				   "cellopt_qcreject, " & _
				   "wil_id, " & _
				   "manuf_sn, " & _
				   "outboundcosmgradeid, " & _
				   "inboundcosmgrade, " & _
				   "softkeycode, " & _
				   "pss_wrty_device_id, " & _
				   "pss_wrty_av_id, " & _
				   "pss_wrty_approval_dt, " & _
				   "pss_wrty_approval_user_id, " & _
				   "sn_discp_av_id, " & _
				   "sn_discp_approved_dt, " & _
				   "sn_discp_approved_user_id, " & _
				   "sn_discp_flag, " & _
				   "rptsent " & _
				  ") " & _
				  "VALUES ( " & _
				   _cellopt_id & " , " & _
				   ConvertBackToNullString(_cellopt_msn, False) & " , " & _
				   ConvertBackToNullString(_cellopt_fname, False) & " , " & _
				   ConvertBackToNullString(_cellopt_lname, False) & " , " & _
				   ConvertBackToNullString(_cellopt_pop, False) & " , " & _
				   ConvertBackToNullString(_cellopt_apc, False) & " , " & _
				   ConvertBackToNullString(_cellopt_claim, False) & " , " & _
				   ConvertBackToNullString(_cellopt_member, False) & " , " & _
				   ConvertBackToNullString(_cellopt_prodcode, False) & " , " & _
				   ConvertBackToNullString(_cellopt_datecode, False) & " , " & _
				   ConvertBackToNullString(_cellopt_modlenumb, False) & " , " & _
				   ConvertBackToNullString(_cellopt_courier, False) & " , " & _
				   ConvertBackToNullString(_cellopt_transceiver, False) & " , " & _
				   ConvertBackToNullString(_cellopt_imei, False) & " , " & _
				   ConvertBackToNullString(_cellopt_csn, False) & " , " & _
				   ConvertBackToNullString(_cellopt_csn_dec, False) & " , " & _
				   ConvertBackToNullString(_cellopt_min, False) & " , " & _
				   ConvertBackToNullString(_cellopt_carrmodcode, False) & " , " & _
				   ConvertBackToNullString(_cellopt_outmsn, False) & " , " & _
				   ConvertBackToNullString(_cellopt_outimei, False) & " , " & _
				   ConvertBackToNullString(_cellopt_outcsn, False) & " , " & _
				   ConvertBackToNullString(_cellopt_softverin, False) & " , " & _
				   ConvertBackToNullString(_cellopt_softverout, False) & " , " & _
				   ConvertBackToNullString(_cellopt_ssid, False) & " , " & _
				   ConvertBackToNullString(_cellopt_techid, False) & " , " & _
				   ConvertBackToNullString(_cellopt_aircarrcode, False) & " , " & _
				   ConvertBackToNullString(_cellopt_airtime, False) & " , " & _
				   ConvertBackToNullString(_cellopt_repairstatus, False) & " , " & _
				   ConvertBackToNullString(_cellopt_repairdate, False) & " , " & _
				   ConvertBackToNullString(_cellopt_repairtime, False) & " , " & _
				   ConvertBackToNullString(_cellopt_failure, False) & " , " & _
				   ConvertBackToNullString(_cellopt_complaint, False) & " , " & _
				   ConvertBackToNullString(_cellopt_transaction, False) & " , " & _
				   ConvertBackToNullString(_cellopt_cycletime, False) & " , " & _
				   ConvertBackToNullString(_cellopt_sugin, False) & " , " & _
				   ConvertBackToNullString(_cellopt_sugout, False) & " , '" & _
				   _cellopt_verificationid & "' , " & _
				   _cellopt_ptfunc & " , " & _
				   _cellopt_ptflash & " , " & _
				   _cellopt_ptrf & " , " & _
				   _cellopt_ptl & " , " & _
				   _cellopt_ptp & " , " & _
				   IIf(_cellopt_reconstatus, 1, 0) & " , " & _
				   IIf(_cellopt_new, 1, 0) & " , " & _
				   ConvertBackToNullString(_device_id, False) & " , " & _
				   _sc_id & " , " & _
				   _cellopt_wipowner & " , " & _
				   ConvertToMySQLDateOrNullString(_cellopt_wipentrydt) & " , '" & _
				   _cellopt_wipownerold & "' , " & _
				   ConvertBackToNullString(_workstation, True) & " , " & _
				   ConvertToMySQLDateOrNullString(_workstationentrydt) & " , " & _
				   IIf(_hasprebilllot, 1, 0) & " , " & _
				   ConvertBackToNullString(_comp_id, False) & " , " & _
				   IIf(_skudiscrep, 1, 0) & " , " & _
				   _rur_returntocust & " , " & _
				   ConvertBackToNullString(_cellopt_techassigned, False) & " , " & _
				   ConvertBackToNullString(_cellopt_logictray, False) & " , " & _
				   IIf(_cellopt_rework, 1, 0) & " , " & _
				   ConvertBackToNullString(_cellopt_refurbcompletedt, False) & " , " & _
				   ConvertBackToNullString(_cellopt_refurbcompleteworkdt, False) & " , " & _
				   ConvertBackToNullString(_cellopt_refurbcompleteuserid, False) & " , " & _
				   ConvertBackToNullString(_cellopt_refurbcompletelineid, False) & " , " & _
				   ConvertBackToNullString(_cellopt_techassigndate, False) & " , " & _
				   ConvertBackToNullString(_cellopt_qcfailcode, False) & " , " & _
				   IIf(_cellopt_qcreject, 1, 0) & " , " & _
				   _wil_id & " , '" & _
				   _manuf_sn & "' , " & _
				   _outboundcosmgradeid & " , " & _
				   _inboundcosmgrade & " , " & _
				   ConvertBackToNullString(_softkeycode, False) & " , " & _
				   _pss_wrty_device_id & " , " & _
				   _pss_wrty_av_id & " , " & _
				   ConvertBackToNullString(_pss_wrty_approval_dt, False) & " , " & _
				   _pss_wrty_approval_user_id & " , " & _
				   _sn_discp_av_id & " , " & _
				   ConvertBackToNullString(_sn_discp_approved_dt, False) & " , " & _
				   _sn_discp_approved_user_id & " , " & _
				   _sn_discp_flag & " , " & _
				   _rptsent & "  " & _
				   ")"
				_id = _objDataProc.ExecuteScalarForInsert(strSQL, "production.tcellopt")
				_cellopt_id = _id
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
				strSQL = "UPDATE production.tcellopt SET " & _
				 "cellopt_wipowner = " & ConvertBackToNullString(_cellopt_wipowner, False) & ", " & _
				 "cellopt_wipentrydt = " & ConvertToMySQLDateOrNullString(_cellopt_wipentrydt) & ", " & _
				 "cellopt_wipownerold = " & ConvertBackToNullString(_cellopt_wipownerold, True) & ", " & _
				 "workstation = " & ConvertBackToNullString(_workstation, True) & ", " & _
				 "workstationentrydt = " & ConvertToMySQLDateOrNullString(_workstationentrydt) & " " & _
				 "WHERE device_id = " & _device_id.ToString() & "; "
				Return objDataProc.ExecuteNonQuery(strSQL)

				'"cellopt_msn = " & ConvertBackToNullString(_cellopt_msn, False) & ", " & _
				'"cellopt_fname = " & ConvertBackToNullString(_cellopt_fname, False) & ", " & _
				'"cellopt_lname = " & ConvertBackToNullString(_cellopt_lname, False) & ", " & _
				'"cellopt_pop = " & ConvertBackToNullString(_cellopt_pop, False) & ", " & _
				'"cellopt_apc = " & ConvertBackToNullString(_cellopt_apc, False) & ", " & _
				'"cellopt_claim = " & ConvertBackToNullString(_cellopt_claim, False) & ", " & _
				'"cellopt_member = " & ConvertBackToNullString(_cellopt_member, False) & ", " & _
				'"cellopt_prodcode = " & ConvertBackToNullString(_cellopt_prodcode, False) & ", " & _
				'"cellopt_datecode = " & ConvertBackToNullString(_cellopt_datecode, False) & ", " & _
				'"cellopt_modlenumb = " & ConvertBackToNullString(_cellopt_modlenumb, False) & ", " & _
				'"cellopt_courier = " & ConvertBackToNullString(_cellopt_courier, False) & ", " & _
				'"cellopt_transceiver = " & ConvertBackToNullString(_cellopt_transceiver, False) & ", " & _
				'"cellopt_imei = " & ConvertBackToNullString(_cellopt_imei, False) & ", " & _
				'"cellopt_csn = " & ConvertBackToNullString(_cellopt_csn, False) & ", " & _
				'"cellopt_csn_dec = " & ConvertBackToNullString(_cellopt_csn_dec, False) & ", " & _
				'"cellopt_min = " & ConvertBackToNullString(_cellopt_min, False) & ", " & _
				'"cellopt_carrmodcode = " & ConvertBackToNullString(_cellopt_carrmodcode, False) & ", " & _
				'"cellopt_outmsn = " & ConvertBackToNullString(_cellopt_outmsn, False) & ", " & _
				'"cellopt_outimei = " & ConvertBackToNullString(_cellopt_outimei, False) & ", " & _
				'"cellopt_outcsn = " & ConvertBackToNullString(_cellopt_outcsn, False) & ", " & _
				'"cellopt_softverin = " & ConvertBackToNullString(_cellopt_softverin, False) & ", " & _
				'"cellopt_softverout = " & ConvertBackToNullString(_cellopt_softverout, False) & ", " & _
				'"cellopt_ssid = " & ConvertBackToNullString(_cellopt_ssid, False) & ", " & _
				'"cellopt_techid = " & ConvertBackToNullString(_cellopt_techid, False) & ", " & _
				'"cellopt_aircarrcode = " & ConvertBackToNullString(_cellopt_aircarrcode, False) & ", " & _
				'"cellopt_airtime = " & ConvertBackToNullString(_cellopt_airtime, False) & ", " & _
				'"cellopt_repairstatus = " & ConvertBackToNullString(_cellopt_repairstatus, False) & ", " & _
				'"cellopt_repairdate = " & ConvertBackToNullString(_cellopt_repairdate, False) & ", " & _
				'"cellopt_repairtime = " & ConvertBackToNullString(_cellopt_repairtime, False) & ", " & _
				'"cellopt_failure = " & ConvertBackToNullString(_cellopt_failure, False) & ", " & _
				'"cellopt_complaint = " & ConvertBackToNullString(_cellopt_complaint, False) & ", " & _
				'"cellopt_transaction = " & ConvertBackToNullString(_cellopt_transaction, False) & ", " & _
				'"cellopt_cycletime = " & ConvertBackToNullString(_cellopt_cycletime, False) & ", " & _
				'"cellopt_sugin = " & ConvertBackToNullString(_cellopt_sugin, False) & ", " & _
				'"cellopt_sugout = " & ConvertBackToNullString(_cellopt_sugout, False) & ", " & _
				'"cellopt_verificationid = " & ConvertBackToNullString(_cellopt_verificationid, False) & ", " & _
				'"cellopt_ptfunc = " & ConvertBackToNullString(_cellopt_ptfunc, False) & ", " & _
				'"cellopt_ptflash = " & ConvertBackToNullString(_cellopt_ptflash, False) & ", " & _
				'"cellopt_ptrf = " & ConvertBackToNullString(_cellopt_ptrf, False) & ", " & _
				'"cellopt_ptl = " & ConvertBackToNullString(_cellopt_ptl, False) & ", " & _
				'"cellopt_ptp = " & ConvertBackToNullString(_cellopt_ptp, False) & ", " & _
				'"cellopt_reconstatus = " & ConvertBackToNullString(_cellopt_reconstatus, False) & ", " & _
				'"cellopt_new = " & ConvertBackToNullString(_cellopt_new, False) & ", " & _
				'"device_id = " & ConvertBackToNullString(_device_id, False) & ", " & _
				'"sc_id = " & ConvertBackToNullString(_sc_id, False) & ", " & _

				'"hasprebilllot = " & ConvertBackToNullString(_hasprebilllot, False) & ", " & _
				'"comp_id = " & ConvertBackToNullString(_comp_id, False) & ", " & _
				'"skudiscrep = " & ConvertBackToNullString(_skudiscrep, False) & ", " & _
				'"rur_returntocust = " & ConvertBackToNullString(_rur_returntocust, False) & ", " & _
				'"cellopt_techassigned = " & ConvertBackToNullString(_cellopt_techassigned, False) & ", " & _
				'"cellopt_logictray = " & ConvertBackToNullString(_cellopt_logictray, False) & ", " & _
				'"cellopt_rework = " & ConvertBackToNullString(_cellopt_rework, False) & ", " & _
				'"cellopt_refurbcompletedt = " & ConvertBackToNullString(_cellopt_refurbcompletedt, False) & ", " & _
				'"cellopt_refurbcompleteworkdt = " & ConvertBackToNullString(_cellopt_refurbcompleteworkdt, False) & ", " & _
				'"cellopt_refurbcompleteuserid = " & ConvertBackToNullString(_cellopt_refurbcompleteuserid, False) & ", " & _
				'"cellopt_refurbcompletelineid = " & ConvertBackToNullString(_cellopt_refurbcompletelineid, False) & ", " & _
				'"cellopt_techassigndate = " & ConvertBackToNullString(_cellopt_techassigndate, False) & ", " & _
				'"cellopt_qcfailcode = " & ConvertBackToNullString(_cellopt_qcfailcode, False) & ", " & _
				'"cellopt_qcreject = " & ConvertBackToNullString(_cellopt_qcreject, False) & ", " & _
				'"wil_id = " & ConvertBackToNullString(_wil_id, False) & ", " & _
				'"manuf_sn = " & ConvertBackToNullString(_manuf_sn, False) & ", " & _
				'"outboundcosmgradeid = " & ConvertBackToNullString(_outboundcosmgradeid, False) & ", " & _
				'"inboundcosmgrade = " & ConvertBackToNullString(_inboundcosmgrade, False) & ", " & _
				'"softkeycode = " & ConvertBackToNullString(_softkeycode, False) & ", " & _
				'"pss_wrty_device_id = " & ConvertBackToNullString(_pss_wrty_device_id, False) & ", " & _
				'"pss_wrty_av_id = " & ConvertBackToNullString(_pss_wrty_av_id, False) & ", " & _
				'"pss_wrty_approval_dt = " & ConvertBackToNullString(_pss_wrty_approval_dt, False) & ", " & _
				'"pss_wrty_approval_user_id = " & ConvertBackToNullString(_pss_wrty_approval_user_id, False) & ", " & _
				'"sn_discp_av_id = " & ConvertBackToNullString(_sn_discp_av_id, False) & ", " & _
				'"sn_discp_approved_dt = " & ConvertBackToNullString(_sn_discp_approved_dt, False) & ", " & _
				'"sn_discp_approved_user_id = " & ConvertBackToNullString(_sn_discp_approved_user_id, False) & ", " & _
				'"sn_discp_flag = " & ConvertBackToNullString(_sn_discp_flag, False) & ", " & _
				'"rptsent = " & ConvertBackToNullString(_rptsent, False) & ", " & _

			Catch ex As Exception
				Throw ex
			End Try
		End Function
#End Region
	End Class
	Public Class tcelloptCollection
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

		Public ReadOnly Property tcelloptDataTable() As DataTable
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
			Dim _sb As New StringBuilder()
			_sb.Append("SELECT ")
			_sb.Append("CellOpt_ID, ")
			_sb.Append("CellOpt_MSN, ")
			_sb.Append("CellOpt_FName, ")
			_sb.Append("CellOpt_LName, ")
			_sb.Append("CellOpt_POP, ")
			_sb.Append("CellOpt_APC, ")
			_sb.Append("CellOpt_Claim, ")
			_sb.Append("CellOpt_Member, ")
			_sb.Append("CellOpt_ProdCode, ")
			_sb.Append("CellOpt_DateCode, ")
			_sb.Append("CellOpt_ModleNumb, ")
			_sb.Append("CellOpt_Courier, ")
			_sb.Append("CellOpt_Transceiver, ")
			_sb.Append("CellOpt_IMEI, ")
			_sb.Append("CellOpt_CSN, ")
			_sb.Append("CellOpt_CSN_Dec, ")
			_sb.Append("CellOpt_MIN, ")
			_sb.Append("CellOpt_CarrModCode, ")
			_sb.Append("CellOpt_OutMSN, ")
			_sb.Append("CellOpt_OutIMEI, ")
			_sb.Append("CellOpt_OutCSN, ")
			_sb.Append("CellOpt_SoftVerIN, ")
			_sb.Append("CellOpt_SoftVerOUT, ")
			_sb.Append("CellOpt_SSID, ")
			_sb.Append("CellOpt_TechID, ")
			_sb.Append("CellOpt_AirCarrCode, ")
			_sb.Append("CellOpt_Airtime, ")
			_sb.Append("CellOpt_RepairStatus, ")
			_sb.Append("CellOpt_RepairDate, ")
			_sb.Append("CellOpt_RepairTime, ")
			_sb.Append("CellOpt_Failure, ")
			_sb.Append("CellOpt_Complaint, ")
			_sb.Append("CellOpt_Transaction, ")
			_sb.Append("CellOpt_CycleTime, ")
			_sb.Append("CellOpt_SugIn, ")
			_sb.Append("CellOpt_SugOut, ")
			_sb.Append("CellOpt_VerificationID, ")
			_sb.Append("CellOpt_PTfunc, ")
			_sb.Append("CellOpt_PTflash, ")
			_sb.Append("CellOpt_PTrf, ")
			_sb.Append("CellOpt_PTL, ")
			_sb.Append("CellOpt_PTP, ")
			_sb.Append("CellOpt_ReconStatus, ")
			_sb.Append("CellOpt_NEW, ")
			_sb.Append("Device_ID, ")
			_sb.Append("SC_ID, ")
			_sb.Append("Cellopt_WIPOwner, ")
			_sb.Append("Cellopt_WIPEntryDt, ")
			_sb.Append("Cellopt_WIPOwnerOld, ")
			_sb.Append("WorkStation, ")
			_sb.Append("WorkStationEntryDt, ")
			_sb.Append("HasPreBillLot, ")
			_sb.Append("Comp_ID, ")
			_sb.Append("skuDiscrep, ")
			_sb.Append("RUR_ReturnToCust, ")
			_sb.Append("CellOpt_TechAssigned, ")
			_sb.Append("CellOpt_LogicTray, ")
			_sb.Append("CellOpt_Rework, ")
			_sb.Append("CellOpt_RefurbCompleteDt, ")
			_sb.Append("CellOpt_RefurbCompleteWorkDt, ")
			_sb.Append("CellOpt_RefurbCompleteUserID, ")
			_sb.Append("CellOpt_RefurbCompleteLineID, ")
			_sb.Append("CellOpt_TechAssignDate, ")
			_sb.Append("CellOpt_QCFailCode, ")
			_sb.Append("CellOpt_QCReject, ")
			_sb.Append("WIL_ID, ")
			_sb.Append("Manuf_SN, ")
			_sb.Append("OutBoundCosmGradeID, ")
			_sb.Append("InBoundCosmGrade, ")
			_sb.Append("SoftKeyCode, ")
			_sb.Append("PSS_Wrty_Device_ID, ")
			_sb.Append("PSS_Wrty_AV_ID, ")
			_sb.Append("PSS_Wrty_Approval_DT, ")
			_sb.Append("PSS_Wrty_Approval_User_ID, ")
			_sb.Append("SN_Discp_AV_ID, ")
			_sb.Append("SN_Discp_Approved_DT, ")
			_sb.Append("SN_Discp_Approved_User_ID, ")
			_sb.Append("SN_Discp_Flag, ")
			_sb.Append("RptSent ")
			_sb.Append("FROM production.tcellopt ")
			_sb.Append("WHERE device_id = " & device_id.ToString() & " ")
			Return _sb.ToString()
		End Function

#End Region
	End Class
	Public Class tcelloptWsByPltCollection
		' COLLECTION OF WORKSTATIONS FOR THE DEVICES IN A PALLET.
#Region "DECLARATIONS"

		Inherits Collections.ArrayList
		Private _objDataProc As DBQuery.DataProc
		Private _dt As New DataTable()
		Private _list As New ArrayList()

#End Region
#Region "CONSTRUCTORS"

		Public Sub New(ByVal pallet_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(pallet_id)
		End Sub

#End Region
#Region "PROPERTIES"

		Public ReadOnly Property tcelloptDataTable() As DataTable
			Get
				Return _dt
			End Get
		End Property

#End Region
#Region "METHODS"

		Protected Sub GetData(ByVal pallet_id As Integer)
			Dim _sql As String = GetSelectStatement(pallet_id)
			_dt = _objDataProc.GetDataTable(_sql)
		End Sub

		Protected Function GetSelectStatement(ByVal pallet_id As Integer) As String
			Dim _sb As New StringBuilder()
			_sb.Append("SELECT DISTINCT ")
			_sb.Append("co.WorkStation ")
			_sb.Append("FROM production.tcellopt co ")
			_sb.Append("INNER JOIN production.tdevice d on co.device_id = d.device_id ")
			_sb.Append("WHERE d.pallett_id = " & pallet_id.ToString() & " ")
			Return _sb.ToString()
		End Function

#End Region
	End Class
End Namespace
