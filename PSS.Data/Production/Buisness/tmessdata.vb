Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic

Namespace Buisness

	Public Class tMessData

#Region "DECLARATIONS"

		Private _md_id As Integer = 0
		Private _sn_changed As Byte = 0
		Private _sn_change_userid As Integer = 0
		Private _sn_change_date As Date
		Private _capcode As String = ""
		Private _capcode_old As String = ""
		Private _capcode_change_userid As Integer = 0
		Private _capcode_change_date As Date
		Private _baud_id As Byte = 0
		Private _baud_id_old As Byte = 0
		Private _baud_id_change_userid As Integer = 0
		Private _baud_id_change_date As Date
		Private _freq_id As Integer = 0
		Private _freq_id_old As Integer = 0
		Private _freq_id_change_userid As Integer = 0
		Private _freq_id_change_date As Date
		Private _label_userid As Integer = 0
		Private _label_workdate As Date
		Private _sku As String = ""
		Private _camewithfileflag As Byte = 0
		Private _wo_id As Integer = 0
		Private _device_id As Integer = 0
		Private _evalbillcode_id As Integer = 0
		Private _evalcharges As Decimal = 0
		Private _evaluserid As Integer = 0
		Private _evaldatetime As Date
		Private _final_billing_userid As Integer = 0
		Private _qr_psswtyupdatedt As Date
		Private _qr_psswtyupdateusrid As Integer = 0
		Private _wipowner_id As Short = 0
		Private _wipowner_entrydt As Date
		Private _wipowner_id_old As Short = 0
		Private _wipownersubloc_id As Short = 0
		Private _qcresult_id As Byte = 0
		Private _qcwork_date As Date
		Private _aqlreject As Byte = 0
		Private _aqlreject_date As Date
		Private _inventoryflag As Short = 0
		Private _rec_cust_id As Integer = 0
		Private _fcp_id As Integer = 0
		Private _updcust_userid As Integer = 0
		Private _updcust_dt As Date
		Private _prevcustid As Integer = 0
		Private _afspqty_id As Integer = 0
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
		ByVal md_id As Int32, _
		ByVal sn_changed As Byte, _
		ByVal sn_change_userid As Int32, _
		ByVal sn_change_date As DateTime, _
		ByVal capcode As String, _
		ByVal capcode_old As String, _
		ByVal capcode_change_userid As Int32, _
		ByVal capcode_change_date As DateTime, _
		ByVal baud_id As Byte, _
		ByVal baud_id_old As Byte, _
		ByVal baud_id_change_userid As Int32, _
		ByVal baud_id_change_date As DateTime, _
		ByVal freq_id As Int32, _
		ByVal freq_id_old As Int32, _
		ByVal freq_id_change_userid As Int32, _
		ByVal freq_id_change_date As DateTime, _
		ByVal label_userid As Int32, _
		ByVal label_workdate As DateTime, _
		ByVal sku As String, _
		ByVal camewithfileflag As Byte, _
		ByVal wo_id As Int32, _
		ByVal device_id As Int32, _
		ByVal evalbillcode_id As Int32, _
		ByVal evalcharges As Decimal, _
		ByVal evaluserid As Int32, _
		ByVal evaldatetime As DateTime, _
		ByVal evalflag As Int16, _
		ByVal final_billing_userid As Int32, _
		ByVal qr_psswtyupdatedt As DateTime, _
		ByVal qr_psswtyupdateusrid As Int32, _
		ByVal wipowner_id As Int16, _
		ByVal wipowner_entrydt As DateTime, _
		ByVal wipowner_id_old As Int16, _
		ByVal wipownersubloc_id As Int16, _
		ByVal qcresult_id As Byte, _
		ByVal qcwork_date As DateTime, _
		ByVal aqlreject As Byte, _
		ByVal aqlreject_date As DateTime, _
		ByVal inventoryflag As Int16, _
		ByVal rec_cust_id As Int32, _
		ByVal fcp_id As Int32, _
		ByVal updcust_userid As Int32, _
		ByVal updcust_dt As DateTime, _
		ByVal prevcustid As Int32, _
		ByVal afspqty_id As Int32 _
		 )
			_md_id = md_id
			_sn_changed = sn_changed
			_sn_change_userid = sn_change_userid
			_sn_change_date = sn_change_date
			_capcode = capcode
			_capcode_old = capcode_old
			_capcode_change_userid = capcode_change_userid
			_capcode_change_date = capcode_change_date
			_baud_id = baud_id
			_baud_id_old = baud_id_old
			_baud_id_change_userid = baud_id_change_userid
			_baud_id_change_date = baud_id_change_date
			_freq_id = freq_id
			_freq_id_old = freq_id_old
			_freq_id_change_userid = freq_id_change_userid
			_freq_id_change_date = freq_id_change_date
			_label_userid = label_userid
			_label_workdate = label_workdate
			_sku = sku
			_camewithfileflag = camewithfileflag
			_wo_id = wo_id
			_device_id = device_id
			_evalbillcode_id = evalbillcode_id
			_evalcharges = evalcharges
			_evaluserid = evaluserid
			_evaldatetime = evaldatetime
			_final_billing_userid = final_billing_userid
			_qr_psswtyupdatedt = qr_psswtyupdatedt
			_qr_psswtyupdateusrid = qr_psswtyupdateusrid
			_wipowner_id = wipowner_id
			_wipowner_entrydt = wipowner_entrydt
			_wipowner_id_old = wipowner_id_old
			_wipownersubloc_id = wipownersubloc_id
			_qcresult_id = qcresult_id
			_qcwork_date = qcwork_date
			_aqlreject = aqlreject
			_aqlreject_date = aqlreject_date
			_inventoryflag = inventoryflag
			_rec_cust_id = rec_cust_id
			_fcp_id = fcp_id
			_updcust_userid = updcust_userid
			_updcust_dt = updcust_dt
			_prevcustid = prevcustid
			_afspqty_id = afspqty_id
		End Sub

#End Region
#Region "PROPERTIES"

		Public Property MD_ID() As Integer
			Get
				Return _md_id
			End Get
			Set(ByVal Value As Integer)
				_md_id = Value
			End Set
		End Property
		Public Property sn_changed() As Byte
			Get
				Return _sn_changed
			End Get
			Set(ByVal Value As Byte)
				_sn_changed = Value
				_isDirty = True
			End Set
		End Property
		Public Property sn_change_userid() As Integer
			Get
				Return _sn_change_userid
			End Get
			Set(ByVal Value As Integer)
				_sn_change_userid = Value
				_isDirty = True
			End Set
		End Property
		Public Property sn_change_date() As Date
			Get
				Return _sn_change_date
			End Get
			Set(ByVal Value As Date)
				_sn_change_date = Value
				_isDirty = True
			End Set
		End Property
		Public Property capcode() As String
			Get
				Return _capcode
			End Get
			Set(ByVal Value As String)
				_capcode = Value
				_isDirty = True
			End Set
		End Property
		Public Property capcode_old() As String
			Get
				Return _capcode_old
			End Get
			Set(ByVal Value As String)
				_capcode_old = Value
				_isDirty = True
			End Set
		End Property
		Public Property capcode_change_userid() As Integer
			Get
				Return _capcode_change_userid
			End Get
			Set(ByVal Value As Integer)
				_capcode_change_userid = Value
				_isDirty = True
			End Set
		End Property
		Public Property capcode_change_date() As Date
			Get
				Return _capcode_change_date
			End Get
			Set(ByVal Value As Date)
				_capcode_change_date = Value
				_isDirty = True
			End Set
		End Property
		Public Property baud_id() As Byte
			Get
				Return _baud_id
			End Get
			Set(ByVal Value As Byte)
				_baud_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property baud_id_old() As Byte
			Get
				Return _baud_id_old
			End Get
			Set(ByVal Value As Byte)
				_baud_id_old = Value
				_isDirty = True
			End Set
		End Property
		Public Property baud_id_change_userid() As Integer
			Get
				Return _baud_id_change_userid
			End Get
			Set(ByVal Value As Integer)
				_baud_id_change_userid = Value
				_isDirty = True
			End Set
		End Property
		Public Property baud_id_change_date() As Date
			Get
				Return _baud_id_change_date
			End Get
			Set(ByVal Value As Date)
				_baud_id_change_date = Value
				_isDirty = True
			End Set
		End Property
		Public Property freq_id() As Integer
			Get
				Return _freq_id
			End Get
			Set(ByVal Value As Integer)
				_freq_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property freq_id_old() As Integer
			Get
				Return _freq_id_old
			End Get
			Set(ByVal Value As Integer)
				_freq_id_old = Value
				_isDirty = True
			End Set
		End Property
		Public Property freq_id_change_userid() As Integer
			Get
				Return _freq_id_change_userid
			End Get
			Set(ByVal Value As Integer)
				_freq_id_change_userid = Value
				_isDirty = True
			End Set
		End Property
		Public Property freq_id_change_date() As Date
			Get
				Return _freq_id_change_date
			End Get
			Set(ByVal Value As Date)
				_freq_id_change_date = Value
				_isDirty = True
			End Set
		End Property
		Public Property label_userid() As Integer
			Get
				Return _label_userid
			End Get
			Set(ByVal Value As Integer)
				_label_userid = Value
				_isDirty = True
			End Set
		End Property
		Public Property label_workdate() As Date
			Get
				Return _label_workdate
			End Get
			Set(ByVal Value As Date)
				_label_workdate = Value
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
		Public Property CameWithFileFlag() As Byte
			Get
				Return _camewithfileflag
			End Get
			Set(ByVal Value As Byte)
				_camewithfileflag = Value
				_isDirty = True
			End Set
		End Property
		Public Property wo_id() As Integer
			Get
				Return _wo_id
			End Get
			Set(ByVal Value As Integer)
				_wo_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property device_id() As Integer
			Get
				Return _device_id
			End Get
			Set(ByVal Value As Integer)
				_device_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property EvalBillCode_ID() As Integer
			Get
				Return _evalbillcode_id
			End Get
			Set(ByVal Value As Integer)
				_evalbillcode_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property EvalCharges() As Decimal
			Get
				Return _evalcharges
			End Get
			Set(ByVal Value As Decimal)
				_evalcharges = Value
				_isDirty = True
			End Set
		End Property
		Public Property EvalUserID() As Integer
			Get
				Return _evaluserid
			End Get
			Set(ByVal Value As Integer)
				_evaluserid = Value
				_isDirty = True
			End Set
		End Property
		Public Property EvalDateTime() As Date
			Get
				Return _evaldatetime
			End Get
			Set(ByVal Value As Date)
				_evaldatetime = Value
				_isDirty = True
			End Set
		End Property
		Public ReadOnly Property EvalFlag() As Short
			Get
				Return IIf(_wipowner_id = 202, 1, 0)
			End Get
		End Property
		Public Property Final_Billing_UserID() As Integer
			Get
				Return _final_billing_userid
			End Get
			Set(ByVal Value As Integer)
				_final_billing_userid = Value
				_isDirty = True
			End Set
		End Property
		Public Property QR_PSSWtyUpdateDT() As Date
			Get
				Return _qr_psswtyupdatedt
			End Get
			Set(ByVal Value As Date)
				_qr_psswtyupdatedt = Value
				_isDirty = True
			End Set
		End Property
		Public Property QR_PSSWtyUpdateUsrID() As Integer
			Get
				Return _qr_psswtyupdateusrid
			End Get
			Set(ByVal Value As Integer)
				_qr_psswtyupdateusrid = Value
				_isDirty = True
			End Set
		End Property
		Public Property wipowner_id() As Short
			Get
				Return _wipowner_id
			End Get
			Set(ByVal Value As Short)
				_wipowner_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property wipowner_EntryDt() As Date
			Get
				Return _wipowner_entrydt
			End Get
			Set(ByVal Value As Date)
				_wipowner_entrydt = Value
				_isDirty = True
			End Set
		End Property
		Public Property wipowner_id_Old() As Short
			Get
				Return _wipowner_id_old
			End Get
			Set(ByVal Value As Short)
				_wipowner_id_old = Value
				_isDirty = True
			End Set
		End Property
		Public Property wipownersubloc_id() As Short
			Get
				Return _wipownersubloc_id
			End Get
			Set(ByVal Value As Short)
				_wipownersubloc_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property qcresult_id() As Byte
			Get
				Return _qcresult_id
			End Get
			Set(ByVal Value As Byte)
				_qcresult_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property qcwork_date() As Date
			Get
				Return _qcwork_date
			End Get
			Set(ByVal Value As Date)
				_qcwork_date = Value
				_isDirty = True
			End Set
		End Property
		Public Property aqlreject() As Byte
			Get
				Return _aqlreject
			End Get
			Set(ByVal Value As Byte)
				_aqlreject = Value
				_isDirty = True
			End Set
		End Property
		Public Property aqlreject_date() As Date
			Get
				Return _aqlreject_date
			End Get
			Set(ByVal Value As Date)
				_aqlreject_date = Value
				_isDirty = True
			End Set
		End Property
		Public Property InventoryFlag() As Short
			Get
				Return _inventoryflag
			End Get
			Set(ByVal Value As Short)
				_inventoryflag = Value
				_isDirty = True
			End Set
		End Property
		Public Property Rec_Cust_ID() As Integer
			Get
				Return _rec_cust_id
			End Get
			Set(ByVal Value As Integer)
				_rec_cust_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property FCP_ID() As Integer
			Get
				Return _fcp_id
			End Get
			Set(ByVal Value As Integer)
				_fcp_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property UpdCust_UserID() As Integer
			Get
				Return _updcust_userid
			End Get
			Set(ByVal Value As Integer)
				_updcust_userid = Value
				_isDirty = True
			End Set
		End Property
		Public Property UpdCust_DT() As Date
			Get
				Return _updcust_dt
			End Get
			Set(ByVal Value As Date)
				_updcust_dt = Value
				_isDirty = True
			End Set
		End Property
		Public Property PrevCustID() As Integer
			Get
				Return _prevcustid
			End Get
			Set(ByVal Value As Integer)
				_prevcustid = Value
				_isDirty = True
			End Set
		End Property
		Public Property AFSPQTY_ID() As Integer
			Get
				Return _afspqty_id
			End Get
			Set(ByVal Value As Integer)
				_afspqty_id = Value
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
			_md_id = ConvertToSomething(_dr("md_id"), 0)
			_sn_changed = ConvertToSomething(_dr("sn_changed"), 0)
			_sn_change_userid = ConvertToSomething(_dr("sn_change_userid"), 0)
			If Not _dr("sn_change_date") Is System.DBNull.Value Then _sn_change_date = DirectCast(_dr("sn_change_date"), DateTime)
			_capcode = _dr("capcode").ToString()
			_capcode_old = _dr("capcode_old").ToString()
			_capcode_change_userid = ConvertToSomething(_dr("capcode_change_userid"), 0)
			If Not _dr("capcode_change_date") Is System.DBNull.Value Then _capcode_change_date = DirectCast(_dr("capcode_change_date"), DateTime)
			_baud_id = ConvertToSomething(_dr("baud_id"), 0)
			_baud_id_old = ConvertToSomething(_dr("baud_id_old"), 0)
			_baud_id_change_userid = ConvertToSomething(_dr("baud_id_change_userid"), 0)
			If Not _dr("baud_id_change_date") Is System.DBNull.Value Then _baud_id_change_date = DirectCast(_dr("baud_id_change_date"), DateTime)
			_freq_id = ConvertToSomething(_dr("freq_id"), 0)
			_freq_id_old = ConvertToSomething(_dr("freq_id_old"), 0)
			_freq_id_change_userid = ConvertToSomething(_dr("freq_id_change_userid"), 0)
			If Not _dr("freq_id_change_date") Is System.DBNull.Value Then _freq_id_change_date = DirectCast(_dr("freq_id_change_date"), DateTime)
			_label_userid = ConvertToSomething(_dr("label_userid"), 0)
			If Not _dr("label_workdate") Is System.DBNull.Value Then _label_workdate = ConvertToSomething(_dr("label_workdate"), "")
			_sku = _dr("sku").ToString()
			_camewithfileflag = ConvertToSomething(_dr("camewithfileflag"), 0)
			_wo_id = ConvertToSomething(_dr("wo_id"), 0)
			_device_id = ConvertToSomething(_dr("device_id"), 0)
			_evalbillcode_id = ConvertToSomething(_dr("evalbillcode_id"), 0)
			_evalcharges = ConvertToSomething(_dr("evalcharges"), 0)
			_evaluserid = ConvertToSomething(_dr("evaluserid"), 0)
			If Not _dr("evaldatetime") Is System.DBNull.Value Then _evaldatetime = DirectCast(_dr("evaldatetime"), DateTime)
			_final_billing_userid = ConvertToSomething(_dr("final_billing_userid"), 0)
			If Not _dr("qr_psswtyupdatedt") Is System.DBNull.Value Then _qr_psswtyupdatedt = DirectCast(_dr("qr_psswtyupdatedt"), DateTime)
			_qr_psswtyupdateusrid = ConvertToSomething(_dr("qr_psswtyupdateusrid"), 0)
			_wipowner_id = ConvertToSomething(_dr("wipowner_id"), 0)
			If Not _dr("wipowner_entrydt") Is System.DBNull.Value Then _wipowner_entrydt = DirectCast(_dr("wipowner_entrydt"), DateTime)
			_wipowner_id_old = ConvertToSomething(_dr("wipowner_id_old"), 0)
			_wipownersubloc_id = ConvertToSomething(_dr("wipownersubloc_id"), 0)
			_qcresult_id = ConvertToSomething(_dr("qcresult_id"), 0)
			If Not _dr("qcwork_date") Is System.DBNull.Value Then _qcwork_date = DirectCast(_dr("qcwork_date"), DateTime)
			_aqlreject = ConvertToSomething(_dr("aqlreject"), 0)
			If Not _dr("aqlreject_date") Is System.DBNull.Value Then _aqlreject_date = DirectCast(_dr("aqlreject_date"), DateTime)
			_inventoryflag = ConvertToSomething(_dr("inventoryflag"), 0)
			_rec_cust_id = ConvertToSomething(_dr("rec_cust_id"), 0)
			_fcp_id = ConvertToSomething(_dr("fcp_id"), 0)
			_updcust_userid = ConvertToSomething(_dr("updcust_userid"), 0)
			If Not _dr("updcust_dt") Is System.DBNull.Value Then _updcust_dt = DirectCast(_dr("updcust_dt"), DateTime)
			_prevcustid = ConvertToSomething(_dr("prevcustid"), 0)
			_afspqty_id = ConvertToSomething(_dr("afspqty_id"), 0)
		End Sub

		Protected Function GetSelectStatement(ByVal ID As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "MD_ID, "
			_sql += "sn_changed , "
			_sql += "sn_change_userid, "
			_sql += "sn_change_date, "
			_sql += "capcode, "
			_sql += "capcode_old, "
			_sql += "capcode_change_userid, "
			_sql += "capcode_change_date, "
			_sql += "baud_id, "
			_sql += "baud_id_old, "
			_sql += "baud_id_change_userid, "
			_sql += "baud_id_change_date, "
			_sql += "freq_id, "
			_sql += "freq_id_old, "
			_sql += "freq_id_change_userid, "
			_sql += "freq_id_change_date, "
			_sql += "label_userid, "
			_sql += "label_workdate, "
			_sql += "SKU, "
			_sql += "CameWithFileFlag, "
			_sql += "wo_id, "
			_sql += "device_id, "
			_sql += "EvalBillCode_ID, "
			_sql += "EvalCharges, "
			_sql += "EvalUserID, "
			_sql += "EvalDateTime, "
			_sql += "EvalFlag, "
			_sql += "Final_Billing_UserID, "
			_sql += "QR_PSSWtyUpdateDT, "
			_sql += "QR_PSSWtyUpdateUsrID, "
			_sql += "wipowner_id, "
			_sql += "wipowner_EntryDt, "
			_sql += "wipowner_id_Old, "
			_sql += "wipownersubloc_id, "
			_sql += "qcresult_id, "
			_sql += "qcwork_date, "
			_sql += "aqlreject, "
			_sql += "aqlreject_date, "
			_sql += "InventoryFlag, "
			_sql += "Rec_Cust_ID, "
			_sql += "FCP_ID, "
			_sql += "UpdCust_UserID, "
			_sql += "UpdCust_DT, "
			_sql += "PrevCustID, "
			_sql += "AFSPQTY_ID "
			_sql += "FROM tmessdata "
			_sql += "WHERE device_id = " & ID.ToString() & ""
			Return _sql
		End Function

		Public Sub ApplyChanges()
			If _isNew Then
				_md_id = Insert()
			ElseIf IsDeleted Then
				Throw New Exception("Delete Not Implemented.")
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
				strSQL = "INSERT INTO cogs.tmessdata (" & _
				   "md_id, " & _
				   "sn_changed, " & _
				   "sn_change_userid, " & _
				   "sn_change_date, " & _
				   "capcode, " & _
				   "capcode_old, " & _
				   "capcode_change_userid, " & _
				   "capcode_change_date, " & _
				   "baud_id, " & _
				   "baud_id_old, " & _
				   "baud_id_change_userid, " & _
				   "baud_id_change_date, " & _
				   "freq_id, " & _
				   "freq_id_old, " & _
				   "freq_id_change_userid, " & _
				   "freq_id_change_date, " & _
				   "label_userid, " & _
				   "label_workdate, " & _
				   "sku, " & _
				   "camewithfileflag, " & _
				   "wo_id, " & _
				   "device_id, " & _
				   "evalbillcode_id, " & _
				   "evalcharges, " & _
				   "evaluserid, " & _
				   "evaldatetime, " & _
				   "evalflag, " & _
				   "final_billing_userid, " & _
				   "qr_psswtyupdatedt, " & _
				   "qr_psswtyupdateusrid, " & _
				   "wipowner_id, " & _
				   "wipowner_entrydt, " & _
				   "wipowner_id_old, " & _
				   "wipownersubloc_id, " & _
				   "qcresult_id, " & _
				   "qcwork_date, " & _
				   "aqlreject, " & _
				   "aqlreject_date, " & _
				   "inventoryflag, " & _
				   "rec_cust_id, " & _
				   "fcp_id, " & _
				   "updcust_userid, " & _
				   "updcust_dt, " & _
				   "prevcustid, " & _
				   "afspqty_id " & _
				  ") " & _
				  "VALUES ( " & _
				   _md_id.ToString() & "," & _
				   _sn_changed.ToString() & "," & _
				   _sn_change_userid.ToString() & "," & _
				   _sn_change_date.ToString() & "," & _
				   _capcode.ToString() & "," & _
				   _capcode_old.ToString() & "," & _
				   _capcode_change_userid.ToString() & "," & _
				   _capcode_change_date.ToString() & "," & _
				   _baud_id.ToString() & "," & _
				   _baud_id_old.ToString() & "," & _
				   _baud_id_change_userid.ToString() & "," & _
				   _baud_id_change_date.ToString() & "," & _
				   _freq_id.ToString() & "," & _
				   _freq_id_old.ToString() & "," & _
				   _freq_id_change_userid.ToString() & "," & _
				   _freq_id_change_date.ToString() & "," & _
				   _label_userid.ToString() & "," & _
				   _label_workdate.ToString() & "," & _
				   _sku.ToString() & "," & _
				   _camewithfileflag.ToString() & "," & _
				   _wo_id.ToString() & "," & _
				   _device_id.ToString() & "," & _
				   _evalbillcode_id.ToString() & "," & _
				   _evalcharges.ToString() & "," & _
				   _evaluserid.ToString() & "," & _
				   _evaldatetime.ToString() & "," & _
				   EvalFlag.ToString() & "," & _
				   _final_billing_userid.ToString() & "," & _
				   _qr_psswtyupdatedt.ToString() & "," & _
				   _qr_psswtyupdateusrid.ToString() & "," & _
				   _wipowner_id.ToString() & "," & _
				   _wipowner_entrydt.ToString() & "," & _
				   _wipowner_id_old.ToString() & "," & _
				   _wipownersubloc_id.ToString() & "," & _
				   _qcresult_id.ToString() & "," & _
				   _qcwork_date.ToString() & "," & _
				   _aqlreject.ToString() & "," & _
				   _aqlreject_date.ToString() & "," & _
				   _inventoryflag.ToString() & "," & _
				   _rec_cust_id.ToString() & "," & _
				   _fcp_id.ToString() & "," & _
				   _updcust_userid.ToString() & "," & _
				   _updcust_dt.ToString() & "," & _
				   _prevcustid.ToString() & "," & _
				   _afspqty_id.ToString() & _
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

		Protected Sub Update()
			' TODO: ADD ALL FIELDS TO THIS.
			Dim strToday As String
			Dim _sb As New StringBuilder()
			Dim _objDataProc As New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			Dim _id As Integer = _device_id
			Try
				_sb.Append("UPDATE production.tmessdata SET ")
				_sb.Append("EvalFlag = " & ConvertBackToNullString(EvalFlag.ToString(), False) & ", ")
				_sb.Append("wipowner_id = " & ConvertBackToNullString(_wipowner_id.ToString(), False) & ", ")
				_sb.Append("wipownersubloc_id = " & ConvertBackToNullString(_wipownersubloc_id.ToString(), False) & ", ")
				_sb.Append("wipowner_id_Old = wipowner_id, ")
				_sb.Append("wipowner_EntryDt = now() ")
				_sb.Append("WHERE device_id = " & _device_id.ToString() & " LIMIT 1; ")
				_objDataProc.ExecuteNonQuery(_sb.ToString())
			Catch ex As Exception
				Throw ex
			Finally
				_objDataProc = Nothing
				_sb = Nothing
			End Try
		End Sub

		Public Sub Delete()
			Dim sql As String = GetDeleteStatementForDeviceID()
			Try
				_objDataProc.ExecuteNonQuery(sql)
			Catch ex As Exception
				Throw ex
			End Try
		End Sub

		Public Sub SetNewWIPOwnerLocation( _
	ByVal device_id As Integer, _
	ByVal wipowner_id As Integer, _
	Optional ByVal wipowner_subloc_id As Integer = 0)
			' THIS WILL SET VALUES FOR A NEW WIPOWNER LOCATION.
			_wipowner_id = wipowner_id
			_wipownersubloc_id = wipowner_subloc_id
			_wipowner_entrydt = Format(Date.Now(), "MM/dd/yyyy HH:mm:ss")
		End Sub

		Protected Function GetDeleteStatementForDeviceID() As String
			Dim _sql As String
			_sql = "DELETE FROM production.tmessdata "
			_sql += "WHERE device_id = " & _device_id.ToString() & " LIMIT 1;"
			Return _sql
		End Function

#End Region

	End Class

	Public Class tMessDataCollection
#Region "DECLARATIONS"

		Inherits Collections.ArrayList
		Private _objDataProc As DBQuery.DataProc
		Private _dt As New DataTable()
		Private _list As New ArrayList()

#End Region
#Region "CONSTRUCTORS"

		Public Sub New(ByVal MD_ID As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(MD_ID)
		End Sub

#End Region
#Region "PROPERTIES"

		Public ReadOnly Property tMessDataDataTable() As DataTable
			Get
				Return _dt
			End Get
		End Property

#End Region
#Region "METHODS"

		Protected Sub GetData(ByVal MD_ID As Integer)
			Dim _sql As String = GetSelectStatement(MD_ID)
			_dt = _objDataProc.GetDataTable(_sql)
		End Sub

		Protected Function GetSelectStatement(ByVal ID As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "MD_ID"
			_sql += "sn_changed"
			_sql += "sn_change_userid"
			_sql += "sn_change_date"
			_sql += "capcode"
			_sql += "capcode_old"
			_sql += "capcode_change_userid"
			_sql += "capcode_change_date"
			_sql += "baud_id"
			_sql += "baud_id_old"
			_sql += "baud_id_change_userid"
			_sql += "baud_id_change_date"
			_sql += "freq_id"
			_sql += "freq_id_old"
			_sql += "freq_id_change_userid"
			_sql += "freq_id_change_date"
			_sql += "label_userid"
			_sql += "label_workdate"
			_sql += "SKU"
			_sql += "CameWithFileFlag"
			_sql += "wo_id"
			_sql += "device_id"
			_sql += "EvalBillCode_ID"
			_sql += "EvalCharges"
			_sql += "EvalUserID"
			_sql += "EvalDateTime"
			_sql += "EvalFlag"
			_sql += "Final_Billing_UserID"
			_sql += "QR_PSSWtyUpdateDT"
			_sql += "QR_PSSWtyUpdateUsrID"
			_sql += "wipowner_id"
			_sql += "wipowner_EntryDt"
			_sql += "wipowner_id_Old"
			_sql += "wipownersubloc_id"
			_sql += "qcresult_id"
			_sql += "qcwork_date"
			_sql += "aqlreject"
			_sql += "aqlreject_date"
			_sql += "InventoryFlag"
			_sql += "Rec_Cust_ID"
			_sql += "FCP_ID"
			_sql += "UpdCust_UserID"
			_sql += "UpdCust_DT"
			_sql += "PrevCustID"
			_sql += "AFSPQTY_ID"
			_sql += "FROM tmessdata "
			_sql += "WHERE device_id = " & ID.ToString() & ""
			Return _sql
		End Function

#End Region
	End Class

End Namespace
