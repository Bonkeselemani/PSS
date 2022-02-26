Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic

Namespace BOL

	Public Class titem

#Region "DECLARATIONS"

		Private _item_id As Integer = 0
		Private _vn_itemno As String = ""
		Private _cb_itemno As String = ""
		Private _upcode As String = ""
		Private _gtinno As String = ""
		Private _assignedid As Integer = 0
		Private _packqty As Integer = 0
		Private _packqty_unitmeasurementcode As String = ""
		Private _qtyrequestedtobeship As Integer = 0
		Private _sizeofunitinpack As Integer = 0
		Private _sizeofunitinpack_unitmeasurementcode As String = ""
		Private _itemdesc_type As String = ""
		Private _itemdesc As String = ""
		Private _seqno As Integer = 0
		Private _relationshipcode As String = ""
		Private _prodqty As Integer = 0
		Private _prodqty_unitmeasurementcode As String = ""
		Private _sn As String = ""
		Private _hid As Integer = 0
		Private _phid As Integer = 0
		Private _ship_id As Integer = 0
		Private _pack_id As Integer = 0
		Private _tare_id As Integer = 0
		Private _order_id As Integer = 0
		Private _orderno As String = ""
		Private _device_id As Integer = 0
		Private _recvd_usrid As Integer = 0
		Private _msg_id As Integer = 0
		Private _whrno_id As Integer = 0
		Private _wipwo_id As Integer = 0
		Private _wiporderno As String = ""
		Private _wipcompletiondate As String
		Private _t864transsetctrlno As String = ""
		Private _discrepancyreason As String = ""
		Private _boxid As String = ""
		Private _wb_id As Integer = 0
		Private _bt_addr As String = ""
		Private _prod_code As String = ""
		Private _p_no As String = ""
		Private _hw_rev1 As String = ""
		Private _hw_rev2 As String = ""
		Private _manufprodsn As String = ""
		Private _manufseq As String = ""
		Private _manuf_date As String = ""
		Private _funcrep As Integer = 0
		Private _wrtyclaimreceiptdt As String
		Private _fsn_id As Integer = 0
		Private _lastdateinwrty As String
		Private _wrtyclaimableflg As Integer = 0
		Private _mc_id As Integer = 0
		Private _label_location As String = ""
		Private _wrty_labor As Decimal = 0
		Private _wrty_partcost As Decimal = 0
		Private _wrtystatus_bywhrecdate As Integer = 0
		Private _whb_id As Integer = 0
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

		Public Sub New(ByVal sn As String)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(sn)
			_isDirty = False
			_isNew = False
		End Sub

#End Region
#Region "PROPERTIES"

		Public Property Item_ID() As Integer
			Get
				Return _item_id
			End Get
			Set(ByVal Value As Integer)
				_item_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property VN_ItemNo() As String
			Get
				Return _vn_itemno
			End Get
			Set(ByVal Value As String)
				_vn_itemno = Value
				_isDirty = True
			End Set
		End Property
		Public Property CB_ItemNo() As String
			Get
				Return _cb_itemno
			End Get
			Set(ByVal Value As String)
				_cb_itemno = Value
				_isDirty = True
			End Set
		End Property
		Public Property UPCode() As String
			Get
				Return _upcode
			End Get
			Set(ByVal Value As String)
				_upcode = Value
				_isDirty = True
			End Set
		End Property
		Public Property GTINNo() As String
			Get
				Return _gtinno
			End Get
			Set(ByVal Value As String)
				_gtinno = Value
				_isDirty = True
			End Set
		End Property
		Public Property AssignedID() As Integer
			Get
				Return _assignedid
			End Get
			Set(ByVal Value As Integer)
				_assignedid = Value
				_isDirty = True
			End Set
		End Property
		Public Property PackQty() As Integer
			Get
				Return _packqty
			End Get
			Set(ByVal Value As Integer)
				_packqty = Value
				_isDirty = True
			End Set
		End Property
		Public Property PackQty_UnitMeasurementCode() As String
			Get
				Return _packqty_unitmeasurementcode
			End Get
			Set(ByVal Value As String)
				_packqty_unitmeasurementcode = Value
				_isDirty = True
			End Set
		End Property
		Public Property QtyRequestedToBeShip() As Integer
			Get
				Return _qtyrequestedtobeship
			End Get
			Set(ByVal Value As Integer)
				_qtyrequestedtobeship = Value
				_isDirty = True
			End Set
		End Property
		Public Property SizeOfUnitInPack() As Integer
			Get
				Return _sizeofunitinpack
			End Get
			Set(ByVal Value As Integer)
				_sizeofunitinpack = Value
				_isDirty = True
			End Set
		End Property
		Public Property SizeOfUnitInPack_UnitMeasurementCode() As String
			Get
				Return _sizeofunitinpack_unitmeasurementcode
			End Get
			Set(ByVal Value As String)
				_sizeofunitinpack_unitmeasurementcode = Value
				_isDirty = True
			End Set
		End Property
		Public Property ItemDesc_Type() As String
			Get
				Return _itemdesc_type
			End Get
			Set(ByVal Value As String)
				_itemdesc_type = Value
				_isDirty = True
			End Set
		End Property
		Public Property ItemDesc() As String
			Get
				Return _itemdesc
			End Get
			Set(ByVal Value As String)
				_itemdesc = Value
				_isDirty = True
			End Set
		End Property
		Public Property SeqNo() As Integer
			Get
				Return _seqno
			End Get
			Set(ByVal Value As Integer)
				_seqno = Value
				_isDirty = True
			End Set
		End Property
		Public Property RelationShipCode() As String
			Get
				Return _relationshipcode
			End Get
			Set(ByVal Value As String)
				_relationshipcode = Value
				_isDirty = True
			End Set
		End Property
		Public Property ProdQty() As Integer
			Get
				Return _prodqty
			End Get
			Set(ByVal Value As Integer)
				_prodqty = Value
				_isDirty = True
			End Set
		End Property
		Public Property ProdQty_UnitMeasurementCode() As String
			Get
				Return _prodqty_unitmeasurementcode
			End Get
			Set(ByVal Value As String)
				_prodqty_unitmeasurementcode = Value
				_isDirty = True
			End Set
		End Property
		Public Property SN() As String
			Get
				Return _sn
			End Get
			Set(ByVal Value As String)
				_sn = Value
				_isDirty = True
			End Set
		End Property
		Public Property HID() As Integer
			Get
				Return _hid
			End Get
			Set(ByVal Value As Integer)
				_hid = Value
				_isDirty = True
			End Set
		End Property
		Public Property PHID() As Integer
			Get
				Return _phid
			End Get
			Set(ByVal Value As Integer)
				_phid = Value
				_isDirty = True
			End Set
		End Property
		Public Property Ship_ID() As Integer
			Get
				Return _ship_id
			End Get
			Set(ByVal Value As Integer)
				_ship_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property Pack_ID() As Integer
			Get
				Return _pack_id
			End Get
			Set(ByVal Value As Integer)
				_pack_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property Tare_ID() As Integer
			Get
				Return _tare_id
			End Get
			Set(ByVal Value As Integer)
				_tare_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property Order_ID() As Integer
			Get
				Return _order_id
			End Get
			Set(ByVal Value As Integer)
				_order_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property OrderNo() As String
			Get
				Return _orderno
			End Get
			Set(ByVal Value As String)
				_orderno = Value
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
		Public Property Recvd_UsrID() As Integer
			Get
				Return _recvd_usrid
			End Get
			Set(ByVal Value As Integer)
				_recvd_usrid = Value
				_isDirty = True
			End Set
		End Property
		Public Property Msg_ID() As Integer
			Get
				Return _msg_id
			End Get
			Set(ByVal Value As Integer)
				_msg_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property WHRNO_ID() As Integer
			Get
				Return _whrno_id
			End Get
			Set(ByVal Value As Integer)
				_whrno_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property WIPWO_ID() As Integer
			Get
				Return _wipwo_id
			End Get
			Set(ByVal Value As Integer)
				_wipwo_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property WIPOrderNo() As String
			Get
				Return _wiporderno
			End Get
			Set(ByVal Value As String)
				_wiporderno = Value
				_isDirty = True
			End Set
		End Property
		Public Property WipCompletionDate() As String
			Get
				Return _wipcompletiondate
			End Get
			Set(ByVal Value As String)
				_wipcompletiondate = Value
				_isDirty = True
			End Set
		End Property
		Public Property t864TransSetCtrlNo() As String
			Get
				Return _t864transsetctrlno
			End Get
			Set(ByVal Value As String)
				_t864transsetctrlno = Value
				_isDirty = True
			End Set
		End Property
		Public Property DiscrepancyReason() As String
			Get
				Return _discrepancyreason
			End Get
			Set(ByVal Value As String)
				_discrepancyreason = Value
				_isDirty = True
			End Set
		End Property
		Public Property BoxID() As String
			Get
				Return _boxid
			End Get
			Set(ByVal Value As String)
				_boxid = Value
				_isDirty = True
			End Set
		End Property
		Public Property wb_id() As Integer
			Get
				Return _wb_id
			End Get
			Set(ByVal Value As Integer)
				_wb_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property BT_Addr() As String
			Get
				Return _bt_addr
			End Get
			Set(ByVal Value As String)
				_bt_addr = Value
				_isDirty = True
			End Set
		End Property
		Public Property Prod_Code() As String
			Get
				Return _prod_code
			End Get
			Set(ByVal Value As String)
				_prod_code = Value
				_isDirty = True
			End Set
		End Property
		Public Property P_No() As String
			Get
				Return _p_no
			End Get
			Set(ByVal Value As String)
				_p_no = Value
				_isDirty = True
			End Set
		End Property
		Public Property HW_REV1() As String
			Get
				Return _hw_rev1
			End Get
			Set(ByVal Value As String)
				_hw_rev1 = Value
				_isDirty = True
			End Set
		End Property
		Public Property HW_REV2() As String
			Get
				Return _hw_rev2
			End Get
			Set(ByVal Value As String)
				_hw_rev2 = Value
				_isDirty = True
			End Set
		End Property
		Public Property ManufProdSN() As String
			Get
				Return _manufprodsn
			End Get
			Set(ByVal Value As String)
				_manufprodsn = Value
				_isDirty = True
			End Set
		End Property
		Public Property ManufSEQ() As String
			Get
				Return _manufseq
			End Get
			Set(ByVal Value As String)
				_manufseq = Value
				_isDirty = True
			End Set
		End Property
		Public Property Manuf_Date() As String
			Get
				Return _manuf_date
			End Get
			Set(ByVal Value As String)
				_manuf_date = Value
				_isDirty = True
			End Set
		End Property
		Public Property FuncRep() As Integer
			Get
				Return _funcrep
			End Get
			Set(ByVal Value As Integer)
				_funcrep = Value
				_isDirty = True
			End Set
		End Property
		Public Property WrtyClaimReceiptDt() As String
			Get
				Return _wrtyclaimreceiptdt
			End Get
			Set(ByVal Value As String)
				_wrtyclaimreceiptdt = Value
				_isDirty = True
			End Set
		End Property
		Public Property FSN_ID() As Integer
			Get
				Return _fsn_id
			End Get
			Set(ByVal Value As Integer)
				_fsn_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property LastDateInWrty() As String
			Get
				Return _lastdateinwrty
			End Get
			Set(ByVal Value As String)
				_lastdateinwrty = Value
				_isDirty = True
			End Set
		End Property
		Public Property WrtyClaimableFlg() As Integer
			Get
				Return _wrtyclaimableflg
			End Get
			Set(ByVal Value As Integer)
				_wrtyclaimableflg = Value
				_isDirty = True
			End Set
		End Property
		Public Property mc_id() As Integer
			Get
				Return _mc_id
			End Get
			Set(ByVal Value As Integer)
				_mc_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property Label_Location() As String
			Get
				Return _label_location
			End Get
			Set(ByVal Value As String)
				_label_location = Value
				_isDirty = True
			End Set
		End Property
		Public Property wrty_labor() As Decimal
			Get
				Return _wrty_labor
			End Get
			Set(ByVal Value As Decimal)
				_wrty_labor = Value
				_isDirty = True
			End Set
		End Property
		Public Property wrty_partcost() As Decimal
			Get
				Return _wrty_partcost
			End Get
			Set(ByVal Value As Decimal)
				_wrty_partcost = Value
				_isDirty = True
			End Set
		End Property
		Public Property WrtyStatus_ByWHRecDate() As Integer
			Get
				Return _wrtystatus_bywhrecdate
			End Get
			Set(ByVal Value As Integer)
				_wrtystatus_bywhrecdate = Value
				_isDirty = True
			End Set
		End Property

		Public Property whb_id() As Integer
			Get
				Return _whb_id
			End Get
			Set(ByVal Value As Integer)
				_whb_id = Value
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
		Protected Sub GetData(ByVal sn As String)
			Dim _sql As String = GetSelectStatement(sn)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Private Sub PopulateObject(ByVal _dr As DataRow)

			_item_id = ConvertToSomething(_dr("item_id"), 0)
			_vn_itemno = ConvertToSomething(_dr("vn_itemno").ToString(), "")
			_cb_itemno = ConvertToSomething(_dr("cb_itemno").ToString(), "")
			_upcode = ConvertToSomething(_dr("upcode").ToString(), "")
			_gtinno = ConvertToSomething(_dr("gtinno").ToString(), "")
			_assignedid = ConvertToSomething(_dr("assignedid"), 0)
			_packqty = ConvertToSomething(_dr("packqty"), 0)
			_packqty_unitmeasurementcode = ConvertToSomething(_dr("packqty_unitmeasurementcode").ToString(), "")
			_qtyrequestedtobeship = ConvertToSomething(_dr("qtyrequestedtobeship"), 0)
			_sizeofunitinpack = ConvertToSomething(_dr("sizeofunitinpack"), 0)
			_sizeofunitinpack_unitmeasurementcode = ConvertToSomething(_dr("sizeofunitinpack_unitmeasurementcode").ToString(), "")
			_itemdesc_type = ConvertToSomething(_dr("itemdesc_type").ToString(), "")
			_itemdesc = ConvertToSomething(_dr("itemdesc").ToString(), "")
			_seqno = ConvertToSomething(_dr("seqno"), 0)
			_relationshipcode = ConvertToSomething(_dr("relationshipcode").ToString(), "")
			_prodqty = ConvertToSomething(_dr("prodqty"), 0)
			_prodqty_unitmeasurementcode = ConvertToSomething(_dr("prodqty_unitmeasurementcode").ToString(), "")
			_sn = ConvertToSomething(_dr("sn").ToString(), "")
			_hid = ConvertToSomething(_dr("hid"), 0)
			_phid = ConvertToSomething(_dr("phid"), 0)
			_ship_id = ConvertToSomething(_dr("ship_id"), 0)
			_pack_id = ConvertToSomething(_dr("pack_id"), 0)
			_tare_id = ConvertToSomething(_dr("tare_id"), 0)
			_order_id = ConvertToSomething(_dr("order_id"), 0)
			_orderno = ConvertToSomething(_dr("orderno").ToString(), "")
			_device_id = ConvertToSomething(_dr("device_id"), 0)
			_recvd_usrid = ConvertToSomething(_dr("recvd_usrid"), 0)
			_msg_id = ConvertToSomething(_dr("msg_id"), 0)
			_whrno_id = ConvertToSomething(_dr("whrno_id"), 0)
			_wipwo_id = ConvertToSomething(_dr("wipwo_id"), 0)
			_wiporderno = ConvertToSomething(_dr("wiporderno").ToString(), "")
			_wipcompletiondate = ConvertToSomething(_dr("wipcompletiondate").ToString(), "")
			_t864transsetctrlno = ConvertToSomething(_dr("864transsetctrlno").ToString(), "")
			_discrepancyreason = ConvertToSomething(_dr("discrepancyreason").ToString(), "")
			_boxid = ConvertToSomething(_dr("boxid").ToString(), "")
			_wb_id = ConvertToSomething(_dr("wb_id"), 0)
			_bt_addr = ConvertToSomething(_dr("bt_addr").ToString(), "")
			_prod_code = ConvertToSomething(_dr("prod_code").ToString(), "")
			_p_no = ConvertToSomething(_dr("p_no").ToString(), "")
			_hw_rev1 = ConvertToSomething(_dr("hw_rev1").ToString(), "")
			_hw_rev2 = ConvertToSomething(_dr("hw_rev2").ToString(), "")
			_manufprodsn = ConvertToSomething(_dr("manufprodsn").ToString(), "")
			_manufseq = ConvertToSomething(_dr("manufseq").ToString(), "")
			_manuf_date = ConvertToSomething(_dr("manuf_date").ToString(), "")
			_funcrep = ConvertToSomething(_dr("funcrep"), 0)
			_wrtyclaimreceiptdt = ConvertToSomething(_dr("wrtyclaimreceiptdt").ToString(), "")
			_fsn_id = ConvertToSomething(_dr("fsn_id"), 0)
			_lastdateinwrty = ConvertToSomething(_dr("lastdateinwrty").ToString(), "")
			_wrtyclaimableflg = ConvertToSomething(_dr("wrtyclaimableflg"), 0)
			_mc_id = ConvertToSomething(_dr("mc_id"), 0)
			_label_location = ConvertToSomething(_dr("label_location").ToString(), "")
			_wrty_labor = ConvertToSomething(_dr("wrty_labor"), 0.0)
			_wrty_partcost = ConvertToSomething(_dr("wrty_partcost"), 0.0)
			_wrtystatus_bywhrecdate = ConvertToSomething(_dr("wrtystatus_bywhrecdate"), 0)
			_whb_id = ConvertToSomething(_dr("whb_id"), 0)
		End Sub
		Protected Function GetSelectStatement(ByVal device_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "Item_ID, "
			_sql += "VN_ItemNo, "
			_sql += "CB_ItemNo, "
			_sql += "UPCode, "
			_sql += "GTINNo, "
			_sql += "AssignedID, "
			_sql += "PackQty, "
			_sql += "PackQty_UnitMeasurementCode, "
			_sql += "QtyRequestedToBeShip, "
			_sql += "SizeOfUnitInPack, "
			_sql += "SizeOfUnitInPack_UnitMeasurementCode, "
			_sql += "ItemDesc_Type, "
			_sql += "ItemDesc, "
			_sql += "SeqNo, "
			_sql += "RelationShipCode, "
			_sql += "ProdQty, "
			_sql += "ProdQty_UnitMeasurementCode, "
			_sql += "SN, "
			_sql += "HID, "
			_sql += "PHID, "
			_sql += "Ship_ID, "
			_sql += "Pack_ID, "
			_sql += "Tare_ID, "
			_sql += "Order_ID, "
			_sql += "OrderNo, "
			_sql += "Device_ID, "
			_sql += "Recvd_UsrID, "
			_sql += "Msg_ID, "
			_sql += "WHRNO_ID, "
			_sql += "WIPWO_ID, "
			_sql += "WIPOrderNo, "
			_sql += "WipCompletionDate, "
			_sql += "864TransSetCtrlNo, "
			_sql += "DiscrepancyReason, "
			_sql += "BoxID, "
			_sql += "wb_id, "
			_sql += "BT_Addr, "
			_sql += "Prod_Code, "
			_sql += "P_No, "
			_sql += "HW_REV1, "
			_sql += "HW_REV2, "
			_sql += "ManufProdSN, "
			_sql += "ManufSEQ, "
			_sql += "Manuf_Date, "
			_sql += "FuncRep, "
			_sql += "WrtyClaimReceiptDt, "
			_sql += "FSN_ID, "
			_sql += "LastDateInWrty, "
			_sql += "WrtyClaimableFlg, "
			_sql += "mc_id, "
			_sql += "Label_Location, "
			_sql += "wrty_labor, "
			_sql += "wrty_partcost, "
			_sql += "WrtyStatus_ByWHRecDate, "
			_sql += "whb_id "
			_sql += "FROM edi.titem "
			_sql += "WHERE device_id = " & device_id.ToString() & " "
			Return _sql
		End Function
		Protected Function GetSelectStatement(ByVal sn As String) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "Item_ID, "
			_sql += "VN_ItemNo, "
			_sql += "CB_ItemNo, "
			_sql += "UPCode, "
			_sql += "GTINNo, "
			_sql += "AssignedID, "
			_sql += "PackQty, "
			_sql += "PackQty_UnitMeasurementCode, "
			_sql += "QtyRequestedToBeShip, "
			_sql += "SizeOfUnitInPack, "
			_sql += "SizeOfUnitInPack_UnitMeasurementCode, "
			_sql += "ItemDesc_Type, "
			_sql += "ItemDesc, "
			_sql += "SeqNo, "
			_sql += "RelationShipCode, "
			_sql += "ProdQty, "
			_sql += "ProdQty_UnitMeasurementCode, "
			_sql += "SN, "
			_sql += "HID, "
			_sql += "PHID, "
			_sql += "Ship_ID, "
			_sql += "Pack_ID, "
			_sql += "Tare_ID, "
			_sql += "Order_ID, "
			_sql += "OrderNo, "
			_sql += "Device_ID, "
			_sql += "Recvd_UsrID, "
			_sql += "Msg_ID, "
			_sql += "WHRNO_ID, "
			_sql += "WIPWO_ID, "
			_sql += "WIPOrderNo, "
			_sql += "WipCompletionDate, "
			_sql += "864TransSetCtrlNo, "
			_sql += "DiscrepancyReason, "
			_sql += "BoxID, "
			_sql += "wb_id, "
			_sql += "BT_Addr, "
			_sql += "Prod_Code, "
			_sql += "P_No, "
			_sql += "HW_REV1, "
			_sql += "HW_REV2, "
			_sql += "ManufProdSN, "
			_sql += "ManufSEQ, "
			_sql += "Manuf_Date, "
			_sql += "FuncRep, "
			_sql += "WrtyClaimReceiptDt, "
			_sql += "FSN_ID, "
			_sql += "LastDateInWrty, "
			_sql += "WrtyClaimableFlg, "
			_sql += "mc_id, "
			_sql += "Label_Location, "
			_sql += "wrty_labor, "
			_sql += "wrty_partcost, "
			_sql += "WrtyStatus_ByWHRecDate, "
			_sql += "whb_id "
			_sql += "FROM edi.titem "
			_sql += "WHERE sn = '" & sn & "' "
			Return _sql
		End Function
		Public Sub ApplyChanges()
			If _isNew Then
				_item_id = Insert()
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
				strToday = PSS.Data.buisness.Generic.GetMySqlDateTime("%Y-%m-%d")
				strSQL = "INSERT INTO edi.titem (" & _
				"vn_itemno, " & _
				"cb_itemno, " & _
				"upcode, " & _
				"gtinno, " & _
				"assignedid, " & _
				"packqty, " & _
				"packqty_unitmeasurementcode, " & _
				"qtyrequestedtobeship, " & _
				"sizeofunitinpack, " & _
				"sizeofunitinpack_unitmeasurementcode, " & _
				"itemdesc_type, " & _
				"itemdesc, " & _
				"seqno, " & _
				"relationshipcode, " & _
				"prodqty, " & _
				"prodqty_unitmeasurementcode, " & _
				"sn, " & _
				"hid, " & _
				"phid, " & _
				"ship_id, " & _
				"pack_id, " & _
				"tare_id, " & _
				"order_id, " & _
				"orderno, " & _
				"device_id, " & _
				"recvd_usrid, " & _
				"msg_id, " & _
				"whrno_id, " & _
				"wipwo_id, " & _
				"wiporderno, " & _
				"wipcompletiondate, " & _
				"864transsetctrlno, " & _
				"discrepancyreason, " & _
				"boxid, " & _
				"wb_id, " & _
				"bt_addr, " & _
				"prod_code, " & _
				"p_no, " & _
				"hw_rev1, " & _
				"hw_rev2, " & _
				"manufprodsn, " & _
				"manufseq, " & _
				"manuf_date, " & _
				"funcrep, " & _
				"wrtyclaimreceiptdt, " & _
				"fsn_id, " & _
				"lastdateinwrty, " & _
				"wrtyclaimableflg, " & _
				"mc_id, " & _
				"label_location, " & _
				"wrty_labor, " & _
				"wrty_partcost, " & _
				"wrtystatus_bywhrecdate, " & _
				"whb_id " & _
				  ") " & _
				  "VALUES ( " & _
				ConvertBackToNullString(_vn_itemno, False) & " , " & _
				ConvertBackToNullString(_cb_itemno, False) & " , " & _
				ConvertBackToNullString(_upcode, False) & " , " & _
				ConvertBackToNullString(_gtinno, False) & " , " & _
				ConvertToSomething(_assignedid, 0) & " , " & _
				ConvertToSomething(_packqty, 0) & " , " & _
				ConvertBackToNullString(_packqty_unitmeasurementcode, False) & " , " & _
				ConvertBackToNullString(_qtyrequestedtobeship, False) & " , " & _
				ConvertToSomething(_sizeofunitinpack, 0) & " , " & _
				ConvertBackToNullString(_sizeofunitinpack_unitmeasurementcode, False) & " , " & _
				ConvertBackToNullString(_itemdesc_type, False) & " , " & _
				ConvertBackToNullString(_itemdesc, False) & " , " & _
				ConvertBackToNullString(_seqno, False) & " , " & _
				ConvertBackToNullString(_relationshipcode, False) & " , " & _
				ConvertToSomething(_prodqty, 0) & " , '" & _
				ConvertToSomething(_prodqty_unitmeasurementcode, "") & "' , '" & _
				_sn & "' , " & _
				ConvertToSomething(_hid, 0) & " , " & _
				ConvertToSomething(_phid, 0) & " , " & _
				ConvertBackToNullString(_ship_id, False) & " , " & _
				ConvertBackToNullString(_pack_id, False) & " , " & _
				ConvertToSomething(_tare_id, 0) & " , " & _
				ConvertBackToNullString(_order_id, False) & " , '" & _
				ConvertToSomething(_orderno, "") & "' , " & _
				ConvertBackToNullString(_device_id, False) & " , " & _
				ConvertBackToNullString(_recvd_usrid, False) & " , " & _
				ConvertBackToNullString(_msg_id, False) & " , " & _
				ConvertBackToNullString(_whrno_id, False) & " , " & _
				ConvertBackToNullString(_wipwo_id, False) & " , " & _
				ConvertBackToNullString(_wiporderno, False) & " , " & _
				ConvertBackToNullString(_wipcompletiondate, False) & " , '" & _
				_t864transsetctrlno & "' , " & _
				ConvertBackToNullString(_discrepancyreason, False) & " , " & _
				ConvertBackToNullString(_boxid, True) & " , " & _
				ConvertBackToNullString(_wb_id, False) & " , '" & _
				ConvertToSomething(_bt_addr, "") & "' , " & _
				_prod_code & " , '" & _
				_p_no & "' , '" & _
				_hw_rev1 & "' , '" & _
				_hw_rev2 & "' , " & _
				ConvertBackToNullString(_manufprodsn, False) & " , " & _
				ConvertBackToNullString(_manufseq, False) & " , '" & _
				_manuf_date & "' , " & _
				ConvertToSomething(_funcrep, 0) & " , " & _
				ConvertBackToNullString(_wrtyclaimreceiptdt, False) & " , " & _
				ConvertBackToNullString(_fsn_id, False) & " , " & _
				ConvertBackToNullString(_lastdateinwrty, False) & " , " & _
				ConvertToSomething(_wrtyclaimableflg, 0) & " , " & _
				ConvertToSomething(_mc_id, 0) & " , " & _
				ConvertBackToNullString(_label_location, False) & " , " & _
				ConvertToSomething(_wrty_labor, 0) & " , " & _
				ConvertToSomething(_wrty_partcost, 0) & " , " & _
				_wrtystatus_bywhrecdate & " , " & _
				ConvertBackToNullString(_whb_id, False) & " " & _
				")"
				Item_ID = objDataProc.ExecuteScalarForInsert(strSQL, "edi.titem")
				_item_id = Item_ID
				Return Item_ID
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
				strToday = PSS.Data.buisness.Generic.GetMySqlDateTime("%Y-%m-%d")
				strSQL = "UPDATE edi.titem SET " & _
				"boxid = " & ConvertBackToNullString(_boxid, True) & ", " & _
				"wb_id = " & ConvertBackToNullString(_wb_id, False) & ", " & _
				"whb_id = " & ConvertBackToNullString(_whb_id, False) & " " & _
				"WHERE device_id = " & Device_ID.ToString() & "; "

				'"item_id = " & ConvertBackToNullString(_item_id, False) & ", " & _
				'"vn_itemno = " & ConvertBackToNullString(_vn_itemno, False) & ", " & _
				'"cb_itemno = " & ConvertBackToNullString(_cb_itemno, False) & ", " & _
				'"upcode = " & ConvertBackToNullString(_upcode, False) & ", " & _
				'"gtinno = " & ConvertBackToNullString(_gtinno, False) & ", " & _
				'"assignedid = " & ConvertBackToNullString(_assignedid, False) & ", " & _
				'"packqty = " & ConvertBackToNullString(_packqty, False) & ", " & _
				'"packqty_unitmeasurementcode = " & ConvertBackToNullString(_packqty_unitmeasurementcode, False) & ", " & _
				'"qtyrequestedtobeship = " & ConvertBackToNullString(_qtyrequestedtobeship, False) & ", " & _
				'"sizeofunitinpack = " & ConvertBackToNullString(_sizeofunitinpack, False) & ", " & _
				'"sizeofunitinpack_unitmeasurementcode = " & ConvertBackToNullString(_sizeofunitinpack_unitmeasurementcode, False) & ", " & _
				'"itemdesc_type = " & ConvertBackToNullString(_itemdesc_type, False) & ", " & _
				'"itemdesc = " & ConvertBackToNullString(_itemdesc, False) & ", " & _
				'"seqno = " & ConvertBackToNullString(_seqno, False) & ", " & _
				'"relationshipcode = " & ConvertBackToNullString(_relationshipcode, False) & ", " & _
				'"prodqty = " & ConvertBackToNullString(_prodqty, False) & ", " & _
				'"prodqty_unitmeasurementcode = " & ConvertBackToNullString(_prodqty_unitmeasurementcode, False) & ", " & _
				'"sn = " & ConvertBackToNullString(_sn, False) & ", " & _
				'"hid = " & ConvertBackToNullString(_hid, False) & ", " & _
				'"phid = " & ConvertBackToNullString(_phid, False) & ", " & _
				'"ship_id = " & ConvertBackToNullString(_ship_id, False) & ", " & _
				'"pack_id = " & ConvertBackToNullString(_pack_id, False) & ", " & _
				'"tare_id = " & ConvertBackToNullString(_tare_id, False) & ", " & _
				'"order_id = " & ConvertBackToNullString(_order_id, False) & ", " & _
				'"orderno = " & ConvertBackToNullString(_orderno, False) & ", " & _
				'"device_id = " & ConvertBackToNullString(_device_id, False) & ", " & _
				'"recvd_usrid = " & ConvertBackToNullString(_recvd_usrid, False) & ", " & _
				'"msg_id = " & ConvertBackToNullString(_msg_id, False) & ", " & _
				'"whrno_id = " & ConvertBackToNullString(_whrno_id, False) & ", " & _
				'"wipwo_id = " & ConvertBackToNullString(_wipwo_id, False) & ", " & _
				'"wiporderno = " & ConvertBackToNullString(_wiporderno, False) & ", " & _
				'"wipcompletiondate = " & ConvertBackToNullString(_wipcompletiondate, False) & ", " & _
				'"864transsetctrlno = " & ConvertBackToNullString(_t864transsetctrlno, False) & ", " & _
				'"discrepancyreason = " & ConvertBackToNullString(_discrepancyreason, False) & ", " & _
				'"bt_addr = " & ConvertBackToNullString(_bt_addr, False) & ", " & _
				'"prod_code = " & ConvertBackToNullString(_prod_code, False) & ", " & _
				'"p_no = " & ConvertBackToNullString(_p_no, False) & ", " & _
				'"hw_rev1 = " & ConvertBackToNullString(_hw_rev1, False) & ", " & _
				'"hw_rev2 = " & ConvertBackToNullString(_hw_rev2, False) & ", " & _
				'"manufprodsn = " & ConvertBackToNullString(_manufprodsn, False) & ", " & _
				'"manufseq = " & ConvertBackToNullString(_manufseq, False) & ", " & _
				'"manuf_date = " & ConvertBackToNullString(_manuf_date, False) & ", " & _
				'"funcrep = " & ConvertBackToNullString(_funcrep, False) & ", " & _
				'"wrtyclaimreceiptdt = " & ConvertBackToNullString(_wrtyclaimreceiptdt, False) & ", " & _
				'"fsn_id = " & ConvertBackToNullString(_fsn_id, False) & ", " & _
				'"lastdateinwrty = " & ConvertBackToNullString(_lastdateinwrty, False) & ", " & _
				'"wrtyclaimableflg = " & ConvertBackToNullString(_wrtyclaimableflg, False) & ", " & _
				'"mc_id = " & ConvertBackToNullString(_mc_id, False) & ", " & _
				'"label_location = " & ConvertBackToNullString(_label_location, False) & ", " & _
				'"wrty_labor = " & ConvertBackToNullString(_wrty_labor, False) & ", " & _
				'"wrty_partcost = " & ConvertBackToNullString(_wrty_partcost, False) & ", " & _
				'"wrtystatus_bywhrecdate = " & ConvertBackToNullString(_wrtystatus_bywhrecdate, False) & ", " & _

				Return objDataProc.ExecuteNonQuery(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Function

#End Region

	End Class

	Public Class titemCollection
		' This class is used to get a collection of records 
		' assigned to a boxid.
#Region "DECLARATIONS"

		Inherits Collections.ArrayList
		Private _objDataProc As DBQuery.DataProc
		Private _dt As New DataTable()
		Private _list As New ArrayList()

#End Region
#Region "CONSTRUCTORS"

		Public Sub New(ByVal BoxID As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(BoxID)
		End Sub

#End Region
#Region "PROPERTIES"

		Public ReadOnly Property titemDataTable() As DataTable
			Get
				Return _dt
			End Get
		End Property

#End Region
#Region "METHODS"

		Protected Sub GetData(ByVal BoxID As Integer)
			Dim _sql As String = GetSelectStatement(BoxID)
			_dt = _objDataProc.GetDataTable(_sql)
		End Sub

		Protected Function GetSelectStatement(ByVal BoxID As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "Item_ID, "
			_sql += "VN_ItemNo, "
			_sql += "CB_ItemNo, "
			_sql += "UPCode, "
			_sql += "GTINNo, "
			_sql += "AssignedID, "
			_sql += "PackQty, "
			_sql += "PackQty_UnitMeasurementCode, "
			_sql += "QtyRequestedToBeShip, "
			_sql += "SizeOfUnitInPack, "
			_sql += "SizeOfUnitInPack_UnitMeasurementCode, "
			_sql += "ItemDesc_Type, "
			_sql += "ItemDesc, "
			_sql += "SeqNo, "
			_sql += "RelationShipCode, "
			_sql += "ProdQty, "
			_sql += "ProdQty_UnitMeasurementCode, "
			_sql += "SN, "
			_sql += "HID, "
			_sql += "PHID, "
			_sql += "Ship_ID, "
			_sql += "Pack_ID, "
			_sql += "Tare_ID, "
			_sql += "Order_ID, "
			_sql += "OrderNo, "
			_sql += "Device_ID, "
			_sql += "Recvd_UsrID, "
			_sql += "Msg_ID, "
			_sql += "WHRNO_ID, "
			_sql += "WIPWO_ID, "
			_sql += "WIPOrderNo, "
			_sql += "WipCompletionDate, "
			_sql += "864TransSetCtrlNo, "
			_sql += "DiscrepancyReason, "
			_sql += "BoxID, "
			_sql += "wb_id, "
			_sql += "BT_Addr, "
			_sql += "Prod_Code, "
			_sql += "P_No, "
			_sql += "HW_REV1, "
			_sql += "HW_REV2, "
			_sql += "ManufProdSN, "
			_sql += "ManufSEQ, "
			_sql += "Manuf_Date, "
			_sql += "FuncRep, "
			_sql += "WrtyClaimReceiptDt, "
			_sql += "FSN_ID, "
			_sql += "LastDateInWrty, "
			_sql += "WrtyClaimableFlg, "
			_sql += "mc_id, "
			_sql += "Label_Location, "
			_sql += "wrty_labor, "
			_sql += "wrty_partcost, "
			_sql += "WrtyStatus_ByWHRecDate, "
			_sql += "whb_id "
			_sql += "FROM production.titem "
			_sql += "WHERE boxid = " & BoxID.ToString() & ""
			Return _sql
		End Function

#End Region
	End Class

	Public Class titem_wh_box_Collection
		' This class is used to get a collection of records 
		' assigned to a whb_id.
#Region "DECLARATIONS"

		Inherits Collections.ArrayList
		Private _objDataProc As DBQuery.DataProc
		Private _dt As New DataTable()
		Private _list As New ArrayList()

#End Region
#Region "CONSTRUCTORS"

		Public Sub New(ByVal whb_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(whb_id)
		End Sub

#End Region
#Region "PROPERTIES"

		Public ReadOnly Property titemDataTable() As DataTable
			Get
				Return _dt
			End Get
		End Property

#End Region
#Region "METHODS"

		Protected Sub GetData(ByVal whb_id As Integer)
			Dim _sql As String = GetSelectStatement(whb_id)
			_dt = _objDataProc.GetDataTable(_sql)
		End Sub

		Protected Function GetSelectStatement(ByVal whb_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "Item_ID, "
			_sql += "VN_ItemNo, "
			_sql += "CB_ItemNo, "
			_sql += "UPCode, "
			_sql += "GTINNo, "
			_sql += "AssignedID, "
			_sql += "PackQty, "
			_sql += "PackQty_UnitMeasurementCode, "
			_sql += "QtyRequestedToBeShip, "
			_sql += "SizeOfUnitInPack, "
			_sql += "SizeOfUnitInPack_UnitMeasurementCode, "
			_sql += "ItemDesc_Type, "
			_sql += "ItemDesc, "
			_sql += "SeqNo, "
			_sql += "RelationShipCode, "
			_sql += "ProdQty, "
			_sql += "ProdQty_UnitMeasurementCode, "
			_sql += "SN, "
			_sql += "HID, "
			_sql += "PHID, "
			_sql += "Ship_ID, "
			_sql += "Pack_ID, "
			_sql += "Tare_ID, "
			_sql += "Order_ID, "
			_sql += "OrderNo, "
			_sql += "Device_ID, "
			_sql += "Recvd_UsrID, "
			_sql += "Msg_ID, "
			_sql += "WHRNO_ID, "
			_sql += "WIPWO_ID, "
			_sql += "WIPOrderNo, "
			_sql += "WipCompletionDate, "
			_sql += "864TransSetCtrlNo, "
			_sql += "DiscrepancyReason, "
			_sql += "BoxID, "
			_sql += "wb_id, "
			_sql += "BT_Addr, "
			_sql += "Prod_Code, "
			_sql += "P_No, "
			_sql += "HW_REV1, "
			_sql += "HW_REV2, "
			_sql += "ManufProdSN, "
			_sql += "ManufSEQ, "
			_sql += "Manuf_Date, "
			_sql += "FuncRep, "
			_sql += "WrtyClaimReceiptDt, "
			_sql += "FSN_ID, "
			_sql += "LastDateInWrty, "
			_sql += "WrtyClaimableFlg, "
			_sql += "mc_id, "
			_sql += "Label_Location, "
			_sql += "wrty_labor, "
			_sql += "wrty_partcost, "
			_sql += "WrtyStatus_ByWHRecDate, "
			_sql += "whb_id "
			_sql += "FROM edi.titem "
			_sql += "WHERE whb_id = " & whb_id.ToString() & ""
			Return _sql
		End Function

#End Region
	End Class


	Public Class titemWrkStnByWHBoxCollection
		' This class is used to get a collection of workstations 
		' assigned to devices for a whb_id.
#Region "DECLARATIONS"

		Inherits Collections.ArrayList
		Private _objDataProc As DBQuery.DataProc
		Private _dt As New DataTable()
		Private _list As New ArrayList()

#End Region
#Region "CONSTRUCTORS"

		Public Sub New(ByVal whb_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(whb_id)
		End Sub

#End Region
#Region "PROPERTIES"

		Public ReadOnly Property titemWSDataTable() As DataTable
			Get
				Return _dt
			End Get
		End Property

#End Region
#Region "METHODS"

		Protected Sub GetData(ByVal whb_id As Integer)
			Dim _sql As String = GetSelectStatement(whb_id)
			_dt = _objDataProc.GetDataTable(_sql)
		End Sub

		Protected Function GetSelectStatement(ByVal whb_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT DISTINCT "
			_sql += "co.workstation "
			_sql += "FROM edi.titem itm "
			_sql += "INNER JOIN tcellopt co ON itm.device_id = co.device_id "
			_sql += "WHERE itm.whb_id = " & whb_id.ToString() & " "
			Return _sql
		End Function

#End Region
	End Class

End Namespace
