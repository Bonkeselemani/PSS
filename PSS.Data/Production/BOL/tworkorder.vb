Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic

Namespace BOL

	Public Class tworkorder

#Region "DECLARATIONS"

		Private _wo_id As Integer = 0
		Private _wo_custwo As String = ""
		Private _wo_date As String
		Private _wo_quantity As Integer = 0
		Private _wo_raqnty As Integer = 0
		Private _wo_discrepancy As String = ""
		Private _wo_ip As String = ""
		Private _wo_prl As String = ""
		Private _wo_label20 As String = ""
		Private _wo_datedock As String = ""
		Private _wo_memo As String = ""
		Private _wo_shipped As Boolean = False
		Private _wo_dateship As String = ""
		Private _wo_expcode As String = ""
		Private _wo_transceiver As String = ""
		Private _wo_apc_out As String = ""
		Private _wo_flexver As String = ""
		Private _wo_project As Boolean = False
		Private _loc_id As Integer = 0
		Private _prod_id As Integer = 0
		Private _shipto_id As Integer = 0
		Private _po_id As Integer = 0
		Private _webinfo_id As Integer = 0
		Private _comp_id As Integer = 0
		Private _group_id As Integer = 0
		Private _sku_id As Integer = 0
		Private _wo_channel As String = ""
		Private _wo_skulength As Boolean = False
		Private _wo_reject As Boolean = False
		Private _wo_noqc As Boolean = False
		Private _wo_specialproj As Boolean = False
		Private _wo_timestamp As String = ""
		Private _wo_closed As Boolean = False
		Private _wo_camewithfile As Boolean = False
		Private _wo_recpalletname As String = ""
		Private _wo_id_original As Integer = 0
		Private _customerreturn As Integer = 0
		Private _ordertype_id As Integer = 0
		Private _invalidorder As Integer = 0
		Private _enduser As Integer = 0
		Private _closepreorderpart As Integer = 0
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

		Public Sub New(ByVal wo_id)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(WO_ID)
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
		ByVal wo_id As Integer, _
		ByVal wo_custwo As String, _
		ByVal wo_date As String, _
		ByVal wo_quantity As Integer, _
		ByVal wo_raqnty As Integer, _
		ByVal wo_discrepancy As String, _
		ByVal wo_ip As String, _
		ByVal wo_prl As String, _
		ByVal wo_label20 As String, _
		ByVal wo_datedock As String, _
		ByVal wo_memo As String, _
		ByVal wo_shipped As Boolean, _
		ByVal wo_dateship As String, _
		ByVal wo_expcode As String, _
		ByVal wo_transceiver As String, _
		ByVal wo_apc_out As String, _
		ByVal wo_flexver As String, _
		ByVal wo_project As Boolean, _
		ByVal loc_id As Integer, _
		ByVal prod_id As Integer, _
		ByVal shipto_id As Integer, _
		ByVal po_id As Integer, _
		ByVal webinfo_id As Integer, _
		ByVal comp_id As Integer, _
		ByVal group_id As Integer, _
		ByVal sku_id As Integer, _
		ByVal wo_channel As String, _
		ByVal wo_skulength As Boolean, _
		ByVal wo_reject As Boolean, _
		ByVal wo_noqc As Boolean, _
		ByVal wo_specialproj As Boolean, _
		ByVal wo_timestamp As String, _
		ByVal wo_closed As Boolean, _
		ByVal wo_camewithfile As Boolean, _
		ByVal wo_recpalletname As String, _
		ByVal wo_id_original As Integer, _
		ByVal customerreturn As Integer, _
		ByVal ordertype_id As Integer, _
		ByVal invalidorder As Integer, _
		ByVal enduser As Integer, _
		ByVal closepreorderpart As Integer _
		 )
			_wo_id = wo_id
			_wo_custwo = wo_custwo
			_wo_date = wo_date
			_wo_quantity = wo_quantity
			_wo_raqnty = wo_raqnty
			_wo_discrepancy = wo_discrepancy
			_wo_ip = wo_ip
			_wo_prl = wo_prl
			_wo_label20 = wo_label20
			_wo_datedock = wo_datedock
			_wo_memo = wo_memo
			_wo_shipped = wo_shipped
			_wo_dateship = wo_dateship
			_wo_expcode = wo_expcode
			_wo_transceiver = wo_transceiver
			_wo_apc_out = wo_apc_out
			_wo_flexver = wo_flexver
			_wo_project = wo_project
			_loc_id = loc_id
			_prod_id = prod_id
			_shipto_id = shipto_id
			_po_id = po_id
			_webinfo_id = webinfo_id
			_comp_id = comp_id
			_group_id = group_id
			_sku_id = sku_id
			_wo_channel = wo_channel
			_wo_skulength = wo_skulength
			_wo_reject = wo_reject
			_wo_noqc = wo_noqc
			_wo_specialproj = wo_specialproj
			_wo_timestamp = wo_timestamp
			_wo_closed = wo_closed
			_wo_camewithfile = wo_camewithfile
			_wo_recpalletname = wo_recpalletname
			_wo_id_original = wo_id_original
			_customerreturn = customerreturn
			_ordertype_id = ordertype_id
			_invalidorder = invalidorder
			_enduser = enduser
			_closepreorderpart = closepreorderpart
		End Sub

#End Region
#Region "PROPERTIES"

		Public Property WO_ID() As Integer
			Get
				Return _wo_id
			End Get
			Set(ByVal Value As Integer)
				_wo_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property WO_CustWO() As String
			Get
				Return _wo_custwo
			End Get
			Set(ByVal Value As String)
				_wo_custwo = Value
				_isDirty = True
			End Set
		End Property
		Public Property WO_Date() As String
			Get
				Return _wo_date
			End Get
			Set(ByVal Value As String)
				_wo_date = Value
				_isDirty = True
			End Set
		End Property
		Public Property WO_Quantity() As Integer
			Get
				Return _wo_quantity
			End Get
			Set(ByVal Value As Integer)
				_wo_quantity = Value
				_isDirty = True
			End Set
		End Property
		Public Property WO_RAQnty() As Integer
			Get
				Return _wo_raqnty
			End Get
			Set(ByVal Value As Integer)
				_wo_raqnty = Value
				_isDirty = True
			End Set
		End Property
		Public Property WO_Discrepancy() As String
			Get
				Return _wo_discrepancy
			End Get
			Set(ByVal Value As String)
				_wo_discrepancy = Value
				_isDirty = True
			End Set
		End Property
		Public Property WO_IP() As String
			Get
				Return _wo_ip
			End Get
			Set(ByVal Value As String)
				_wo_ip = Value
				_isDirty = True
			End Set
		End Property
		Public Property WO_PRL() As String
			Get
				Return _wo_prl
			End Get
			Set(ByVal Value As String)
				_wo_prl = Value
				_isDirty = True
			End Set
		End Property
		Public Property WO_Label20() As String
			Get
				Return _wo_label20
			End Get
			Set(ByVal Value As String)
				_wo_label20 = Value
				_isDirty = True
			End Set
		End Property
		Public Property WO_DateDock() As String
			Get
				Return _wo_datedock
			End Get
			Set(ByVal Value As String)
				_wo_datedock = Value
				_isDirty = True
			End Set
		End Property
		Public Property WO_Memo() As String
			Get
				Return _wo_memo
			End Get
			Set(ByVal Value As String)
				_wo_memo = Value
				_isDirty = True
			End Set
		End Property
		Public Property WO_Shipped() As Boolean
			Get
				Return _wo_shipped
			End Get
			Set(ByVal Value As Boolean)
				_wo_shipped = Value
				_isDirty = True
			End Set
		End Property
		Public Property WO_DateShip() As String
			Get
				Return _wo_dateship
			End Get
			Set(ByVal Value As String)
				_wo_dateship = Value
				_isDirty = True
			End Set
		End Property
		Public Property WO_ExpCode() As String
			Get
				Return _wo_expcode
			End Get
			Set(ByVal Value As String)
				_wo_expcode = Value
				_isDirty = True
			End Set
		End Property
		Public Property WO_Transceiver() As String
			Get
				Return _wo_transceiver
			End Get
			Set(ByVal Value As String)
				_wo_transceiver = Value
				_isDirty = True
			End Set
		End Property
		Public Property WO_APC_OUT() As String
			Get
				Return _wo_apc_out
			End Get
			Set(ByVal Value As String)
				_wo_apc_out = Value
				_isDirty = True
			End Set
		End Property
		Public Property WO_FlexVer() As String
			Get
				Return _wo_flexver
			End Get
			Set(ByVal Value As String)
				_wo_flexver = Value
				_isDirty = True
			End Set
		End Property
		Public Property WO_Project() As Boolean
			Get
				Return _wo_project
			End Get
			Set(ByVal Value As Boolean)
				_wo_project = Value
				_isDirty = True
			End Set
		End Property
		Public Property Loc_ID() As Integer
			Get
				Return _loc_id
			End Get
			Set(ByVal Value As Integer)
				_loc_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property Prod_ID() As Integer
			Get
				Return _prod_id
			End Get
			Set(ByVal Value As Integer)
				_prod_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property ShipTo_ID() As Integer
			Get
				Return _shipto_id
			End Get
			Set(ByVal Value As Integer)
				_shipto_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property PO_ID() As Integer
			Get
				Return _po_id
			End Get
			Set(ByVal Value As Integer)
				_po_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property WebInfo_ID() As Integer
			Get
				Return _webinfo_id
			End Get
			Set(ByVal Value As Integer)
				_webinfo_id = Value
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
		Public Property Group_ID() As Integer
			Get
				Return _group_id
			End Get
			Set(ByVal Value As Integer)
				_group_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property Sku_ID() As Integer
			Get
				Return _sku_id
			End Get
			Set(ByVal Value As Integer)
				_sku_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property WO_Channel() As String
			Get
				Return _wo_channel
			End Get
			Set(ByVal Value As String)
				_wo_channel = Value
				_isDirty = True
			End Set
		End Property
		Public Property WO_SkuLength() As Boolean
			Get
				Return _wo_skulength
			End Get
			Set(ByVal Value As Boolean)
				_wo_skulength = Value
				_isDirty = True
			End Set
		End Property
		Public Property WO_Reject() As Boolean
			Get
				Return _wo_reject
			End Get
			Set(ByVal Value As Boolean)
				_wo_reject = Value
				_isDirty = True
			End Set
		End Property
		Public Property WO_NoQC() As Boolean
			Get
				Return _wo_noqc
			End Get
			Set(ByVal Value As Boolean)
				_wo_noqc = Value
				_isDirty = True
			End Set
		End Property
		Public Property WO_SpecialProj() As Boolean
			Get
				Return _wo_specialproj
			End Get
			Set(ByVal Value As Boolean)
				_wo_specialproj = Value
				_isDirty = True
			End Set
		End Property
		Public Property wo_timestamp() As String
			Get
				Return _wo_timestamp
			End Get
			Set(ByVal Value As String)
				_wo_timestamp = Value
				_isDirty = True
			End Set
		End Property
		Public Property WO_Closed() As Boolean
			Get
				Return _wo_closed
			End Get
			Set(ByVal Value As Boolean)
				_wo_closed = Value
				_isDirty = True
			End Set
		End Property
		Public Property WO_CameWithFile() As Boolean
			Get
				Return _wo_camewithfile
			End Get
			Set(ByVal Value As Boolean)
				_wo_camewithfile = Value
				_isDirty = True
			End Set
		End Property
		Public Property WO_RecPalletName() As String
			Get
				Return _wo_recpalletname
			End Get
			Set(ByVal Value As String)
				_wo_recpalletname = Value
				_isDirty = True
			End Set
		End Property
		Public Property WO_ID_Original() As Integer
			Get
				Return _wo_id_original
			End Get
			Set(ByVal Value As Integer)
				_wo_id_original = Value
				_isDirty = True
			End Set
		End Property
		Public Property CustomerReturn() As Integer
			Get
				Return _customerreturn
			End Get
			Set(ByVal Value As Integer)
				_customerreturn = Value
				_isDirty = True
			End Set
		End Property
		Public Property OrderType_ID() As Integer
			Get
				Return _ordertype_id
			End Get
			Set(ByVal Value As Integer)
				_ordertype_id = Value
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
		Public Property EndUser() As Integer
			Get
				Return _enduser
			End Get
			Set(ByVal Value As Integer)
				_enduser = Value
				_isDirty = True
			End Set
		End Property
		Public Property ClosePreOrderPart() As Integer
			Get
				Return _closepreorderpart
			End Get
			Set(ByVal Value As Integer)
				_closepreorderpart = Value
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

		Protected Sub GetData(ByVal wo_id As Integer)
			Dim _sql As String = GetSelectStatement(wo_id)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Private Sub PopulateObject(ByVal _dr As DataRow)

			_wo_id = DirectCast(ConvertToSomething(_dr("wo_id"), 0), Integer)
			_wo_custwo = ConvertToSomething(_dr("wo_custwo").ToString(), "")
			_wo_date = ConvertToSomething(_dr("wo_date").ToString(), "")
			_wo_quantity = DirectCast(ConvertToSomething(_dr("wo_quantity"), 0), Integer)
			_wo_raqnty = DirectCast(ConvertToSomething(_dr("wo_raqnty"), 0), Integer)
			_wo_discrepancy = ConvertToSomething(_dr("wo_discrepancy").ToString(), "")
			_wo_ip = ConvertToSomething(_dr("wo_ip").ToString(), "")
			_wo_prl = ConvertToSomething(_dr("wo_prl").ToString(), "")
			_wo_label20 = ConvertToSomething(_dr("wo_label20").ToString(), "")
			_wo_datedock = ConvertToSomething(_dr("wo_datedock").ToString(), "")
			_wo_memo = ConvertToSomething(_dr("wo_memo").ToString(), "")
			_wo_shipped = IIf(_dr("wo_shipped") = 1, True, False)
			_wo_dateship = ConvertToSomething(_dr("wo_dateship").ToString(), "")
			_wo_expcode = ConvertToSomething(_dr("wo_expcode").ToString(), "")
			_wo_transceiver = ConvertToSomething(_dr("wo_transceiver").ToString(), "")
			_wo_apc_out = ConvertToSomething(_dr("wo_apc_out").ToString(), "")
			_wo_flexver = ConvertToSomething(_dr("wo_flexver").ToString(), "")
			_wo_project = IIf(_dr("wo_project") = 1, True, False)
			_loc_id = ConvertToSomething(_dr("loc_id"), 0)
			_prod_id = ConvertToSomething(_dr("prod_id"), 0)
			_shipto_id = ConvertToSomething(_dr("shipto_id"), 0)
			_po_id = ConvertToSomething(_dr("po_id"), 0)
			_webinfo_id = ConvertToSomething(_dr("webinfo_id"), 0)
			_comp_id = ConvertToSomething(_dr("comp_id"), 0)
			_group_id = ConvertToSomething(_dr("group_id"), 0)
			_sku_id = ConvertToSomething(_dr("sku_id"), 0)
			_wo_channel = ConvertToSomething(_dr("wo_channel").ToString(), "")
			_wo_skulength = IIf(_dr("wo_skulength") = 1, True, False)
			_wo_reject = IIf(_dr("wo_reject") = 1, True, False)
			_wo_noqc = IIf(_dr("wo_noqc") = 1, True, False)
			_wo_specialproj = IIf(_dr("wo_specialproj") = 1, True, False)
			_wo_timestamp = ConvertToSomething(_dr("wo_timestamp").ToString(), "")
			_wo_closed = IIf(_dr("wo_closed") = 1, True, False)
			_wo_camewithfile = IIf(_dr("wo_camewithfile") = 1, True, False)
			_wo_recpalletname = ConvertToSomething(_dr("wo_recpalletname").ToString(), "")
			_wo_id_original = ConvertToSomething(_dr("wo_id_original"), 0)
			_customerreturn = _dr("customerreturn").ToString()
			_ordertype_id = _dr("ordertype_id").ToString()
			_invalidorder = _dr("invalidorder").ToString()
			_enduser = _dr("enduser").ToString()
			_closepreorderpart = _dr("closepreorderpart").ToString()
		End Sub
		Protected Function GetSelectStatement(ByVal wo_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "WO_ID, "
			_sql += "WO_CustWO, "
			_sql += "WO_Date, "
			_sql += "WO_Quantity, "
			_sql += "WO_RAQnty, "
			_sql += "WO_Discrepancy, "
			_sql += "WO_IP, "
			_sql += "WO_PRL, "
			_sql += "WO_Label20, "
			_sql += "WO_DateDock, "
			_sql += "WO_Memo, "
			_sql += "WO_Shipped, "
			_sql += "WO_DateShip, "
			_sql += "WO_ExpCode, "
			_sql += "WO_Transceiver, "
			_sql += "WO_APC_OUT, "
			_sql += "WO_FlexVer, "
			_sql += "WO_Project, "
			_sql += "Loc_ID, "
			_sql += "Prod_ID, "
			_sql += "ShipTo_ID, "
			_sql += "PO_ID, "
			_sql += "WebInfo_ID, "
			_sql += "Comp_ID, "
			_sql += "Group_ID, "
			_sql += "Sku_ID, "
			_sql += "WO_Channel, "
			_sql += "WO_SkuLength, "
			_sql += "WO_Reject, "
			_sql += "WO_NoQC, "
			_sql += "WO_SpecialProj, "
			_sql += "wo_timestamp, "
			_sql += "WO_Closed, "
			_sql += "WO_CameWithFile, "
			_sql += "WO_RecPalletName, "
			_sql += "WO_ID_Original, "
			_sql += "CustomerReturn, "
			_sql += "OrderType_ID, "
			_sql += "InvalidOrder, "
			_sql += "EndUser, "
			_sql += "ClosePreOrderPart "
			_sql += "FROM production.tworkorder "
			_sql += "WHERE wo_id = " & wo_id.ToString() & ""
			Return _sql
		End Function
		Public Sub ApplyChanges()
			Try
				If _isNew Then
					_wo_id = Insert()
				ElseIf IsDeleted Then
					' delete
				ElseIf IsDirty Then
					Update()
				End If
			Catch ex As Exception
				Throw ex
			End Try
		End Sub
		Private Function Insert() As Integer
			Dim _objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			Dim strSQL As String = ""
			Dim strToday As String = ""
			Try
				Dim _id As Integer
				strToday = PSS.Data.Buisness.Generic.GetMySqlDateTime("%Y-%m-%d")
				strSQL = "INSERT INTO production.tworkorder (" & _
				   "wo_custwo, " & _
				   "wo_date, " & _
				   "wo_quantity, " & _
				   "wo_raqnty, " & _
				   "wo_discrepancy, " & _
				   "wo_ip, " & _
				   "wo_prl, " & _
				   "wo_label20, " & _
				   "wo_datedock, " & _
				   "wo_memo, " & _
				   "wo_shipped, " & _
				   "wo_dateship, " & _
				   "wo_expcode, " & _
				   "wo_transceiver, " & _
				   "wo_apc_out, " & _
				   "wo_flexver, " & _
				   "wo_project, " & _
				   "loc_id, " & _
				   "prod_id, " & _
				   "shipto_id, " & _
				   "po_id, " & _
				   "webinfo_id, " & _
				   "comp_id, " & _
				   "group_id, " & _
				   "sku_id, " & _
				   "wo_channel, " & _
				   "wo_skulength, " & _
				   "wo_reject, " & _
				   "wo_noqc, " & _
				   "wo_specialproj, " & _
				   "wo_closed, " & _
				   "wo_camewithfile, " & _
				   "wo_recpalletname, " & _
				   "wo_id_original, " & _
				   "customerreturn, " & _
				   "ordertype_id, " & _
				   "invalidorder, " & _
				   "enduser, " & _
				   "closepreorderpart " & _
				  ") " & _
				  "VALUES ( " & _
				   ConvertBackToNullString(_wo_custwo, True) & " , " & _
				  ConvertToMySQLDateOrNullString(_wo_date) & " , " & _
				   _wo_quantity & " , " & _
				   _wo_raqnty & " , " & _
				   ConvertBackToNullString(_wo_discrepancy, True) & " , " & _
				   ConvertBackToNullString(_wo_ip, True) & " , " & _
				   ConvertBackToNullString(_wo_prl, True) & " , " & _
				   "'" & _wo_label20 & "', " & _
				   ConvertToMySQLDateOrNullString(_wo_datedock) & " , " & _
				   ConvertBackToNullString(_wo_memo, True) & " , " & _
				   IIf(_wo_shipped, "1", "0") & " , " & _
				   ConvertBackToNullString(_wo_dateship, False) & " , " & _
				   ConvertBackToNullString(_wo_expcode, True) & " , " & _
				   ConvertBackToNullString(_wo_transceiver, True) & " , " & _
				   ConvertBackToNullString(_wo_apc_out, True) & " , " & _
				   ConvertBackToNullString(_wo_flexver, True) & " , " & _
				   IIf(_wo_project, "1", "0") & " , " & _
				   ConvertBackToNullString(_loc_id, False) & " , " & _
				   ConvertBackToNullString(_prod_id, False) & " , " & _
				   ConvertBackToNullString(_shipto_id, False) & " , " & _
				   ConvertBackToNullString(_po_id, False) & " , " & _
				   ConvertBackToNullString(_webinfo_id, False) & " , " & _
				   ConvertBackToNullString(_comp_id, False) & " , " & _
				   _group_id & " , " & _
				   ConvertBackToNullString(_sku_id, False) & " , " & _
				   ConvertBackToNullString(_wo_channel, False) & " , " & _
				   IIf(_wo_skulength, "", "0") & " , " & _
				   IIf(_wo_reject, "1", "0") & " , " & _
				   IIf(_wo_noqc, "1", "0") & " , " & _
				   IIf(_wo_specialproj, "1", "0") & " , " & _
				   IIf(_wo_closed, "1", "0") & " , " & _
				   IIf(_wo_camewithfile, "1", "0") & " , " & _
				   ConvertBackToNullString(_wo_recpalletname, False) & " , " & _
				   ConvertBackToNullString(_wo_id_original, False) & " , " & _
				   _customerreturn & " , " & _
				   _ordertype_id & " , " & _
				   _invalidorder & " , " & _
				   _enduser & " , " & _
				   _closepreorderpart & "  " & _
				   ")"
				_id = _objDataProc.ExecuteScalarForInsert(strSQL, "production.tworkorder")
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
				strSQL = "UPDATE production.tworkorder SET " & _
				"wo_shipped = " & IIf(_wo_shipped, "1", "0") & ", " & _
				"wo_dateship = " & ConvertToMySQLDateOrNullString(_wo_dateship) & ", " & _
				"wo_closed = " & IIf(_wo_closed, "1", "0") & " " & _
				  " " & _
				  "WHERE WO_ID = " & WO_ID.ToString() & "; "
				Return objDataProc.ExecuteNonQuery(strSQL)

				'"wo_custwo = " & ConvertBackToNullString(_wo_custwo, False) & ", " & _
				'"wo_date = " & ConvertBackToNullString(_wo_date, False) & ", " & _
				'"wo_quantity = " & ConvertBackToNullString(_wo_quantity, False) & ", " & _
				'"wo_raqnty = " & ConvertBackToNullString(_wo_raqnty, False) & ", " & _
				'"wo_discrepancy = " & ConvertBackToNullString(_wo_discrepancy, False) & ", " & _
				'"wo_ip = " & ConvertBackToNullString(_wo_ip, False) & ", " & _
				'"wo_prl = " & ConvertBackToNullString(_wo_prl, False) & ", " & _
				'"wo_label20 = " & ConvertBackToNullString(_wo_label20, False) & ", " & _
				'"wo_datedock = " & ConvertBackToNullString(_wo_datedock, False) & ", " & _
				'"wo_memo = " & ConvertBackToNullString(_wo_memo, False) & ", " & _
				'"wo_expcode = " & ConvertBackToNullString(_wo_expcode, False) & ", " & _
				'"wo_transceiver = " & ConvertBackToNullString(_wo_transceiver, False) & ", " & _
				'"wo_apc_out = " & ConvertBackToNullString(_wo_apc_out, False) & ", " & _
				'"wo_flexver = " & ConvertBackToNullString(_wo_flexver, False) & ", " & _
				'"wo_project = " & ConvertBackToNullString(_wo_project, False) & ", " & _
				'"loc_id = " & ConvertBackToNullString(_loc_id, False) & ", " & _
				'"prod_id = " & ConvertBackToNullString(_prod_id, False) & ", " & _
				'"shipto_id = " & ConvertBackToNullString(_shipto_id, False) & ", " & _
				'"po_id = " & ConvertBackToNullString(_po_id, False) & ", " & _
				'"webinfo_id = " & ConvertBackToNullString(_webinfo_id, False) & ", " & _
				'"comp_id = " & ConvertBackToNullString(_comp_id, False) & ", " & _
				'"group_id = " & ConvertBackToNullString(_group_id, False) & ", " & _
				'"sku_id = " & ConvertBackToNullString(_sku_id, False) & ", " & _
				'"wo_channel = " & ConvertBackToNullString(_wo_channel, False) & ", " & _
				'"wo_skulength = " & ConvertBackToNullString(_wo_skulength, False) & ", " & _
				'"wo_reject = " & ConvertBackToNullString(_wo_reject, False) & ", " & _
				'"wo_noqc = " & ConvertBackToNullString(_wo_noqc, False) & ", " & _
				'"wo_specialproj = " & ConvertBackToNullString(_wo_specialproj, False) & ", " & _
				'"wo_timestamp = " & ConvertBackToNullString(_wo_timestamp, False) & ", " & _
				'"wo_camewithfile = " & ConvertBackToNullString(_wo_camewithfile, False) & ", " & _
				'"wo_recpalletname = " & ConvertBackToNullString(_wo_recpalletname, False) & ", " & _
				'"wo_id_original = " & ConvertBackToNullString(_wo_id_original, False) & ", " & _
				'"customerreturn = " & ConvertBackToNullString(_customerreturn, False) & ", " & _
				'"ordertype_id = " & ConvertBackToNullString(_ordertype_id, False) & ", " & _
				'"invalidorder = " & ConvertBackToNullString(_invalidorder, False) & ", " & _
				'"enduser = " & ConvertBackToNullString(_enduser, False) & ", " & _
				'"closepreorderpart = " & ConvertBackToNullString(_closepreorderpart, False) & ", " & _

			Catch ex As Exception
				Throw ex
			End Try
		End Function

#End Region

	End Class


	Public Class tworkorderCollection
#Region "DECLARATIONS"

		Inherits Collections.ArrayList
		Private _objDataProc As DBQuery.DataProc
		Private _dt As New DataTable()
		Private _list As New ArrayList()

#End Region
#Region "CONSTRUCTORS"

		Public Sub New(ByVal loc_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(loc_id)
		End Sub

#End Region
#Region "PROPERTIES"

		Public ReadOnly Property tworkorderDataTable() As DataTable
			Get
				Return _dt
			End Get
		End Property

#End Region
#Region "METHODS"

		Protected Sub GetData(ByVal loc_id As Integer)
			Dim _sql As String = GetSelectStatement(loc_id)
			_dt = _objDataProc.GetDataTable(_sql)
		End Sub

		Protected Function GetSelectStatement(ByVal loc_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "WO_ID, "
			_sql += "WO_CustWO, "
			_sql += "WO_Date, "
			_sql += "WO_Quantity, "
			_sql += "WO_RAQnty, "
			_sql += "WO_Discrepancy, "
			_sql += "WO_IP, "
			_sql += "WO_PRL, "
			_sql += "WO_Label20, "
			_sql += "WO_DateDock, "
			_sql += "WO_Memo, "
			_sql += "WO_Shipped, "
			_sql += "WO_DateShip, "
			_sql += "WO_ExpCode, "
			_sql += "WO_Transceiver, "
			_sql += "WO_APC_OUT, "
			_sql += "WO_FlexVer, "
			_sql += "WO_Project, "
			_sql += "Loc_ID, "
			_sql += "Prod_ID, "
			_sql += "ShipTo_ID, "
			_sql += "PO_ID, "
			_sql += "WebInfo_ID, "
			_sql += "Comp_ID, "
			_sql += "Group_ID, "
			_sql += "Sku_ID, "
			_sql += "WO_Channel, "
			_sql += "WO_SkuLength, "
			_sql += "WO_Reject, "
			_sql += "WO_NoQC, "
			_sql += "WO_SpecialProj, "
			_sql += "wo_timestamp, "
			_sql += "WO_Closed, "
			_sql += "WO_CameWithFile, "
			_sql += "WO_RecPalletName, "
			_sql += "WO_ID_Original, "
			_sql += "CustomerReturn, "
			_sql += "OrderType_ID, "
			_sql += "InvalidOrder, "
			_sql += "EndUser, "
			_sql += "ClosePreOrderPart "
			_sql += "FROM production.tworkorder "
			_sql += "WHERE loc_id = " & loc_id.ToString() & ""
			Return _sql
		End Function

#End Region
	End Class

End Namespace
