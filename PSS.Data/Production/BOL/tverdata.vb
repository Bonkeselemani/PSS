Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic
Namespace BOL
	Public Class tverdata
#Region "DECLARATIONS"
		Private _trans_id As Integer = 0
		Private _wo_name As String = ""
		Private _device_sn As String = ""
		Private _device_id As Integer = 0
		Private _device_capcode As String = ""
		Private _device_model As String = ""
		Private _device_chnl_cd As String = ""
		Private _device_freq As String = ""
		Private _model_number As String = ""
		Private _ver_timestamp As String
		Private _loc_chg_date As String
		Private _newloadflag As Boolean = False
		Private _camewithfileflag As Boolean = False
		Private _rcvdflag As Boolean = False
		Private _loadfilename As String = ""
		Private _sku_number As String = ""
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
		Public Sub New(ByVal trans_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(trans_id)
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
		Public Property Trans_ID() As Integer
			Get
				Return _trans_id
			End Get
			Set(ByVal Value As Integer)
				_trans_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property WO_Name() As String
			Get
				Return _wo_name
			End Get
			Set(ByVal Value As String)
				_wo_name = Value
				_isDirty = True
			End Set
		End Property
		Public Property Device_SN() As String
			Get
				Return _device_sn
			End Get
			Set(ByVal Value As String)
				_device_sn = Value
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
		Public Property Device_CapCode() As String
			Get
				Return _device_capcode
			End Get
			Set(ByVal Value As String)
				_device_capcode = Value
				_isDirty = True
			End Set
		End Property
		Public Property Device_Model() As String
			Get
				Return _device_model
			End Get
			Set(ByVal Value As String)
				_device_model = Value
				_isDirty = True
			End Set
		End Property
		Public Property Device_Chnl_Cd() As String
			Get
				Return _device_chnl_cd
			End Get
			Set(ByVal Value As String)
				_device_chnl_cd = Value
				_isDirty = True
			End Set
		End Property
		Public Property Device_Freq() As String
			Get
				Return _device_freq
			End Get
			Set(ByVal Value As String)
				_device_freq = Value
				_isDirty = True
			End Set
		End Property
		Public Property Model_Number() As String
			Get
				Return _model_number
			End Get
			Set(ByVal Value As String)
				_model_number = Value
				_isDirty = True
			End Set
		End Property
		Public Property Ver_Timestamp() As String
			Get
				Return _ver_timestamp
			End Get
			Set(ByVal Value As String)
				_ver_timestamp = Value
				_isDirty = True
			End Set
		End Property
		Public Property Loc_Chg_Date() As String
			Get
				Return _loc_chg_date
			End Get
			Set(ByVal Value As String)
				_loc_chg_date = Value
				_isDirty = True
			End Set
		End Property
		Public Property NewLoadFlag() As Boolean
			Get
				Return _newloadflag
			End Get
			Set(ByVal Value As Boolean)
				_newloadflag = Value
				_isDirty = True
			End Set
		End Property
		Public Property CameWithFileFlag() As Boolean
			Get
				Return _camewithfileflag
			End Get
			Set(ByVal Value As Boolean)
				_camewithfileflag = Value
				_isDirty = True
			End Set
		End Property
		Public Property RcvdFlag() As Boolean
			Get
				Return _rcvdflag
			End Get
			Set(ByVal Value As Boolean)
				_rcvdflag = Value
				_isDirty = True
			End Set
		End Property
		Public Property LoadFileName() As String
			Get
				Return _loadfilename
			End Get
			Set(ByVal Value As String)
				_loadfilename = Value
				_isDirty = True
			End Set
		End Property
		Public Property SKU_Number() As String
			Get
				Return _sku_number
			End Get
			Set(ByVal Value As String)
				_sku_number = Value
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
		Protected Sub GetData(ByVal trans_id As Integer)
			Dim _sql As String = GetSelectStatement(trans_id)
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
			_trans_id = ConvertToSomething(_dr("trans_id"), 0)
			_wo_name = ConvertToSomething(_dr("wo_name").ToString(), "")
			_device_sn = ConvertToSomething(_dr("device_sn").ToString(), "")
			_device_id = ConvertToSomething(_dr("device_id"), 0)
			_device_capcode = ConvertToSomething(_dr("device_capcode").ToString(), "")
			_device_model = ConvertToSomething(_dr("device_model").ToString(), "")
			_device_chnl_cd = ConvertToSomething(_dr("device_chnl_cd").ToString(), "")
			_device_freq = ConvertToSomething(_dr("device_freq").ToString(), "")
			_model_number = ConvertToSomething(_dr("model_number").ToString(), "")
			_ver_timestamp = ConvertToSomething(_dr("ver_timestamp").ToString(), "")
			_loc_chg_date = ConvertToSomething(_dr("loc_chg_date").ToString(), "")
			_newloadflag = ConvertToSomething(_dr("newloadflag"), False)
			_camewithfileflag = ConvertToSomething(_dr("camewithfileflag"), False)
			_rcvdflag = ConvertToSomething(_dr("rcvdflag"), False)
			_loadfilename = ConvertToSomething(_dr("loadfilename").ToString(), "")
			_sku_number = ConvertToSomething(_dr("sku_number").ToString(), "")
		End Sub
		Protected Function GetSelectStatement(ByVal trans_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "Trans_ID, "
			_sql += "WO_Name, "
			_sql += "Device_SN, "
			_sql += "Device_ID, "
			_sql += "Device_CapCode, "
			_sql += "Device_Model, "
			_sql += "Device_Chnl_Cd, "
			_sql += "Device_Freq, "
			_sql += "Model_Number, "
			_sql += "Ver_Timestamp, "
			_sql += "Loc_Chg_Date, "
			_sql += "NewLoadFlag, "
			_sql += "CameWithFileFlag, "
			_sql += "RcvdFlag, "
			_sql += "LoadFileName, "
			_sql += "SKU_Number "
			_sql += "FROM production.tverdata "
			_sql += "WHERE trans_id = " & trans_id.ToString() & ""
			Return _sql
		End Function
		Protected Function GetSelectStatement(ByVal device_sn As String) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "Trans_ID, "
			_sql += "WO_Name, "
			_sql += "Device_SN, "
			_sql += "Device_ID, "
			_sql += "Device_CapCode, "
			_sql += "Device_Model, "
			_sql += "Device_Chnl_Cd, "
			_sql += "Device_Freq, "
			_sql += "Model_Number, "
			_sql += "Ver_Timestamp, "
			_sql += "Loc_Chg_Date, "
			_sql += "NewLoadFlag, "
			_sql += "CameWithFileFlag, "
			_sql += "RcvdFlag, "
			_sql += "LoadFileName, "
			_sql += "SKU_Number "
			_sql += "FROM production.tverdata "
			_sql += "WHERE device_sn = '" & device_sn & "' "
			_sql += "ORDER BY trans_id DESC; "
			Return _sql
		End Function
		Public Sub ApplyChanges()
			If _isNew Then
				_trans_id = Insert()
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
				strSQL = "INSERT INTO production.tverdata (" & _
				   "trans_id, " & _
				   "wo_name, " & _
				   "device_sn, " & _
				   "device_id, " & _
				   "device_capcode, " & _
				   "device_model, " & _
				   "device_chnl_cd, " & _
				   "device_freq, " & _
				   "model_number, " & _
				   "ver_timestamp, " & _
				   "loc_chg_date, " & _
				   "newloadflag, " & _
				   "camewithfileflag, " & _
				   "rcvdflag, " & _
				   "loadfilename, " & _
				   "sku_number " & _
				  ") " & _
				  "VALUES ( " & _
				   _trans_id & " , " & _
				   ConvertBackToNullString(_wo_name, False) & " , " & _
				   ConvertBackToNullString(_device_sn, False) & " , " & _
				   ConvertBackToNullString(_device_id, False) & " , " & _
				   ConvertBackToNullString(_device_capcode, False) & " , " & _
				   ConvertBackToNullString(_device_model, False) & " , " & _
				   ConvertBackToNullString(_device_chnl_cd, False) & " , " & _
				   ConvertBackToNullString(_device_freq, False) & " , " & _
				   ConvertBackToNullString(_model_number, False) & " , " & _
				   _ver_timestamp & " , " & _
				   _loc_chg_date & " , " & _
				   _newloadflag & " , " & _
				   _camewithfileflag & " , " & _
				   _rcvdflag & " , " & _
				   ConvertBackToNullString(_loadfilename, False) & " , " & _
				   ConvertBackToNullString(_sku_number, False) & "  " & _
				   ")"
				_id = objDataProc.ExecuteScalarForInsert(strSQL, "production.tverdata")
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
				strSQL = "UPDATE production.tverdata SET " & _
				   "trans_id = " & ConvertBackToNullString(_trans_id, False) & ", " & _
				   "wo_name = " & ConvertBackToNullString(_wo_name, False) & ", " & _
				   "device_sn = " & ConvertBackToNullString(_device_sn, False) & ", " & _
				   "device_id = " & ConvertBackToNullString(_device_id, False) & ", " & _
				   "device_capcode = " & ConvertBackToNullString(_device_capcode, False) & ", " & _
				   "device_model = " & ConvertBackToNullString(_device_model, False) & ", " & _
				   "device_chnl_cd = " & ConvertBackToNullString(_device_chnl_cd, False) & ", " & _
				   "device_freq = " & ConvertBackToNullString(_device_freq, False) & ", " & _
				   "model_number = " & ConvertBackToNullString(_model_number, False) & ", " & _
				   "ver_timestamp = " & ConvertBackToNullString(_ver_timestamp, False) & ", " & _
				   "loc_chg_date = " & ConvertBackToNullString(_loc_chg_date, False) & ", " & _
				   "newloadflag = " & ConvertBackToNullString(_newloadflag, False) & ", " & _
				   "camewithfileflag = " & ConvertBackToNullString(_camewithfileflag, False) & ", " & _
				   "rcvdflag = " & ConvertBackToNullString(_rcvdflag, False) & ", " & _
				   "loadfilename = " & ConvertBackToNullString(_loadfilename, False) & ", " & _
				   "sku_number = " & ConvertBackToNullString(_sku_number, False) & ", " & _
				  "WHERE Trans_ID = " & Trans_ID.ToString() & "; "
				Return objDataProc.ExecuteNonQuery(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Function
#End Region
	End Class
	Public Class tverdataCollection
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
		Public ReadOnly Property tverdataDataTable() As DataTable
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
			_sb.Append("Trans_ID, ")
			_sb.Append("WO_Name, ")
			_sb.Append("Device_SN, ")
			_sb.Append("Device_ID, ")
			_sb.Append("Device_CapCode, ")
			_sb.Append("Device_Model, ")
			_sb.Append("Device_Chnl_Cd, ")
			_sb.Append("Device_Freq, ")
			_sb.Append("Model_Number, ")
			_sb.Append("Ver_Timestamp, ")
			_sb.Append("Loc_Chg_Date, ")
			_sb.Append("NewLoadFlag, ")
			_sb.Append("CameWithFileFlag, ")
			_sb.Append("RcvdFlag, ")
			_sb.Append("LoadFileName, ")
			_sb.Append("SKU_Number ")
			_sb.Append("FROM production.tverdata; ")
			Return _sb.ToString()
		End Function
#End Region
	End Class
End Namespace
