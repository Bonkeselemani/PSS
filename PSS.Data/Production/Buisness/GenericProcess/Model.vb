Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic

Public Class Model

#Region "DECLARATIONS"

    Private _model_id As Integer = 0
    Private _model_desc As String = ""
    Private _model_type As Short = 0
    Private _model_motosku As String = ""
    Private _model_tier As Integer = 0
    Private _model_flat As Integer = 0
    Private _model_hexsn As Byte = 0
    Private _manuf_id As Integer = 0
    'Private _manuf_desc As String = ""
    Private _prod_id As Integer = 0
    Private _prodgrp_id As Integer = 0
    Private _ascprice_id As Integer = 0
    Private _rptgrp_id As Integer = 0
    Private _conv_id As Integer = 0
    Private _dcode_id As Integer = 0
    Private _model_gsm As Byte = 0
    Private _accessory As Short = 0
    Private _upc_code As String = ""
    Private _user_id As Integer = 0
    Private _updatedate As Date
    Private _weight_factor As Decimal = 0
    Private _goalhour As Decimal = 0
    Private _piecesperhour As Decimal = 0
    Private _piecepoint As Decimal = 0
    Private _pointgoal As Decimal = 0
    Private _autobillflg As Byte = 0
    Private _model_unlockcode As Byte = 0
    Private _custommodelgroup As Short = 0
    Private _model_timestamp As Date
    Private _model_volume As Byte = 0
    Private _mrp_status As Byte = 0
    Private _mrp_hide As Byte = 0
    Private _mrp_group As Byte = 0
    Private _manufmodelnumber As String = ""
    Private _altwrtydatecode As Short = 0
    Private _hasBC As Byte = 1
    Private _isNew As System.Boolean = True
    Private _isDirty As System.Boolean = False
    Private _isDeleted As System.Boolean = False
    Private _isValid As System.Boolean = False
    Private _objDataProc As DBQuery.DataProc
#End Region
#Region "CONSTRUCTORS"

    Public Sub New()
        _objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
        _isNew = True
    End Sub
    Public Sub New(ByVal model_id As Integer)
        _objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
        _model_id = model_id
        GetData(_model_id)
    End Sub
    Public Sub New(ByVal dr As DataRow)
        _objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
        PopulateObject(dr)
        _isDirty = False
        _isNew = False
    End Sub

    'ByVal manuf_desc As String, _

    Public Sub New( _
    ByVal model_id As Int32, _
    ByVal model_desc As String, _
    ByVal model_type As Int16, _
    ByVal model_motosku As String, _
    ByVal model_tier As Int32, _
    ByVal model_flat As Int32, _
    ByVal model_hexsn As Byte, _
    ByVal manuf_id As Int32, _
    ByVal prod_id As Int32, _
    ByVal prodgrp_id As Int32, _
    ByVal ascprice_id As Int32, _
    ByVal rptgrp_id As Int32, _
    ByVal conv_id As Int32, _
    ByVal dcode_id As Int32, _
    ByVal model_gsm As Byte, _
    ByVal accessory As Int16, _
    ByVal upc_code As String, _
    ByVal user_id As Int32, _
    ByVal updatedate As DateTime, _
    ByVal weight_factor As Decimal, _
    ByVal goalhour As Decimal, _
    ByVal piecesperhour As Decimal, _
    ByVal piecepoint As Decimal, _
    ByVal pointgoal As Decimal, _
    ByVal autobillflg As Byte, _
    ByVal model_unlockcode As Byte, _
    ByVal custommodelgroup As Int16, _
    ByVal model_timestamp As DateTime, _
    ByVal model_volume As Byte, _
    ByVal mrp_status As Byte, _
    ByVal mrp_hide As Byte, _
    ByVal mrp_group As Byte, _
    ByVal manufmodelnumber As String, _
    ByVal altwrtydatecode As Int16, _
    ByVal hasbc As Byte)
        _model_id = model_id
        _model_desc = model_desc
        _model_type = model_type
        _model_motosku = model_motosku
        _model_tier = model_tier
        _model_flat = model_flat
        _model_hexsn = model_hexsn
        _manuf_id = manuf_id
        ' _manuf_desc = manuf_desc
        _prod_id = prod_id
        _prodgrp_id = ConvertToSomething(prodgrp_id, 0)
        _ascprice_id = ConvertToSomething(ascprice_id, 0)
        _rptgrp_id = ConvertToSomething(rptgrp_id, 0)
        _conv_id = ConvertToSomething(conv_id, 0)
        _dcode_id = dcode_id
        _model_gsm = model_gsm
        _accessory = accessory
        _upc_code = upc_code
        _user_id = ConvertToSomething(user_id, 0)
        _updatedate = updatedate
        _weight_factor = weight_factor
        _goalhour = goalhour
        _piecesperhour = piecesperhour
        _piecepoint = piecepoint
        _pointgoal = pointgoal
        _autobillflg = autobillflg
        _model_unlockcode = model_unlockcode
        _custommodelgroup = custommodelgroup
        _model_timestamp = model_timestamp
        _model_volume = model_volume
        _mrp_status = mrp_status
        _mrp_hide = mrp_hide
        _mrp_group = mrp_group
        _manufmodelnumber = manufmodelnumber
        _altwrtydatecode = altwrtydatecode
        _hasBC = hasbc
    End Sub

#End Region
#Region "PROPERTIES"

    Public Property Model_ID() As Integer
        Get
            Return _model_id
        End Get
        Set(ByVal Value As Integer)
            _model_id = value
        End Set
    End Property
    Public Property Model_Desc() As String
        Get
            Return _model_desc
        End Get
        Set(ByVal Value As String)
            _model_desc = value
        End Set
    End Property
    Public Property Model_Type() As Short
        Get
            Return _model_type
        End Get
        Set(ByVal Value As Short)
            _model_type = value
        End Set
    End Property
    Public Property Model_MotoSku() As String
        Get
            Return _model_motosku
        End Get
        Set(ByVal Value As String)
            _model_motosku = value
        End Set
    End Property
    Public Property Model_Tier() As Integer
        Get
            Return _model_tier
        End Get
        Set(ByVal Value As Integer)
            _model_tier = value
        End Set
    End Property
    Public Property Model_Flat() As Integer
        Get
            Return _model_flat
        End Get
        Set(ByVal Value As Integer)
            _model_flat = value
        End Set
    End Property
    Public Property Model_HexSN() As Byte
        Get
            Return _model_hexsn
        End Get
        Set(ByVal Value As Byte)
            _model_hexsn = value
        End Set
    End Property
    Public Property Manuf_ID() As Integer
        Get
            Return _manuf_id
        End Get
        Set(ByVal Value As Integer)
            _manuf_id = value
        End Set
    End Property
    'Public Property Manuf_Desc() As String
    '    Get
    '        Return _manuf_desc
    '    End Get
    '    Set(ByVal Value As String)
    '        _manuf_desc = Value
    '    End Set
    'End Property
    Public Property Prod_ID() As Integer
        Get
            Return _prod_id
        End Get
        Set(ByVal Value As Integer)
            _prod_id = Value
        End Set
    End Property
    Public Property ProdGrp_ID() As Integer
        Get
            Return _prodgrp_id
        End Get
        Set(ByVal Value As Integer)
            _prodgrp_id = Value
        End Set
    End Property
    Public Property ASCPrice_ID() As Integer
        Get
            Return _ascprice_id
        End Get
        Set(ByVal Value As Integer)
            _ascprice_id = Value
        End Set
    End Property
    Public Property RptGrp_ID() As Integer
        Get
            Return _rptgrp_id
        End Get
        Set(ByVal Value As Integer)
            _rptgrp_id = Value
        End Set
    End Property
    Public Property Conv_ID() As Integer
        Get
            Return _conv_id
        End Get
        Set(ByVal Value As Integer)
            _conv_id = Value
        End Set
    End Property
    Public Property Dcode_ID() As Integer
        Get
            Return _dcode_id
        End Get
        Set(ByVal Value As Integer)
            _dcode_id = Value
        End Set
    End Property
    Public Property Model_GSM() As Byte
        Get
            Return _model_gsm
        End Get
        Set(ByVal Value As Byte)
            _model_gsm = Value
        End Set
    End Property
    Public Property Accessory() As Short
        Get
            Return _accessory
        End Get
        Set(ByVal Value As Short)
            _accessory = Value
        End Set
    End Property
    Public Property UPC_Code() As String
        Get
            Return _upc_code
        End Get
        Set(ByVal Value As String)
            _upc_code = Value
        End Set
    End Property
    Public Property User_ID() As Integer
        Get
            Return _user_id
        End Get
        Set(ByVal Value As Integer)
            _user_id = Value
        End Set
    End Property
    Public Property UpdateDate() As Date
        Get
            Return _updatedate
        End Get
        Set(ByVal Value As Date)
            _updatedate = Value
        End Set
    End Property
    Public Property Weight_Factor() As Decimal
        Get
            Return _weight_factor
        End Get
        Set(ByVal Value As Decimal)
            _weight_factor = Value
        End Set
    End Property
    Public Property GoalHour() As Decimal
        Get
            Return _goalhour
        End Get
        Set(ByVal Value As Decimal)
            _goalhour = Value
        End Set
    End Property
    Public Property PiecesPerHour() As Decimal
        Get
            Return _piecesperhour
        End Get
        Set(ByVal Value As Decimal)
            _piecesperhour = Value
        End Set
    End Property
    Public Property PiecePoint() As Decimal
        Get
            Return _piecepoint
        End Get
        Set(ByVal Value As Decimal)
            _piecepoint = Value
        End Set
    End Property
    Public Property PointGoal() As Decimal
        Get
            Return _pointgoal
        End Get
        Set(ByVal Value As Decimal)
            _pointgoal = Value
        End Set
    End Property
    Public Property AutoBillFlg() As Byte
        Get
            Return _autobillflg
        End Get
        Set(ByVal Value As Byte)
            _autobillflg = Value
        End Set
    End Property
    Public Property Model_UnlockCode() As Byte
        Get
            Return _model_unlockcode
        End Get
        Set(ByVal Value As Byte)
            _model_unlockcode = Value
        End Set
    End Property
    Public Property CustomModelGroup() As Short
        Get
            Return _custommodelgroup
        End Get
        Set(ByVal Value As Short)
            _custommodelgroup = Value
        End Set
    End Property
    Public Property Model_Timestamp() As Date
        Get
            Return _model_timestamp
        End Get
        Set(ByVal Value As Date)
            _model_timestamp = Value
        End Set
    End Property
    Public Property Model_Volume() As Byte
        Get
            Return _model_volume
        End Get
        Set(ByVal Value As Byte)
            _model_volume = Value
        End Set
    End Property
    Public Property MRP_Status() As Byte
        Get
            Return _mrp_status
        End Get
        Set(ByVal Value As Byte)
            _mrp_status = Value
        End Set
    End Property
    Public Property MRP_Hide() As Byte
        Get
            Return _mrp_hide
        End Get
        Set(ByVal Value As Byte)
            _mrp_hide = Value
        End Set
    End Property
    Public Property MRP_Group() As Byte
        Get
            Return _mrp_group
        End Get
        Set(ByVal Value As Byte)
            _mrp_group = Value
        End Set
    End Property
    Public Property ManufModelNumber() As String
        Get
            Return _manufmodelnumber
        End Get
        Set(ByVal Value As String)
            _manufmodelnumber = Value
        End Set
    End Property
    Public Property AltWrtyDateCode() As Short
        Get
            Return _altwrtydatecode
        End Get
        Set(ByVal Value As Short)
            _altwrtydatecode = Value
        End Set
    End Property

    Public Property Has_BC() As Byte
        Get
            Return _hasBC
        End Get
        Set(ByVal Value As Byte)
            _hasBC = Value
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

        _model_id = _dr("model_id")
        '_model_desc = _dr("model_desc").ToString()
        _model_type = _dr("model_type")
        _model_motosku = _dr("model_motosku").ToString()
        _model_tier = _dr("model_tier")
        _model_flat = _dr("model_flat")
        _model_hexsn = DirectCast(_dr("model_hexsn"), Byte)
        _manuf_id = _dr("manuf_id")
        '_manuf_desc = _dr("manuf_desc").ToString()
        _prod_id = _dr("prod_id")
        _prodgrp_id = ConvertToSomething(_dr("prodgrp_id"), 0)
        _ascprice_id = ConvertToSomething(_dr("ascprice_id"), 0)
        _rptgrp_id = ConvertToSomething(_dr("rptgrp_id"), 0)
        _conv_id = ConvertToSomething(_dr("conv_id"), 0)
        _dcode_id = ConvertToSomething(_dr("dcode_id"), 0)
        _model_gsm = DirectCast(_dr("model_gsm"), Byte)
        _accessory = _dr("accessory")
        _upc_code = _dr("upc_code").ToString()
        _user_id = ConvertToSomething(_dr("user_id"), 0)
        _updatedate = DirectCast(_dr("updatedate"), DateTime)
        _weight_factor = ConvertToSomething(_dr("weight_factor"), 0)
        _goalhour = ConvertToSomething(_dr("goalhour"), 0)
        _piecesperhour = ConvertToSomething(_dr("piecesperhour"), 0)
        _piecepoint = ConvertToSomething(_dr("piecepoint"), 0)
        _pointgoal = ConvertToSomething(_dr("pointgoal"), 0)
        _autobillflg = ConvertToSomething(_dr("autobillflg"), 0)
        _model_unlockcode = ConvertToSomething(_dr("model_unlockcode"), 0)
        _custommodelgroup = _dr("custommodelgroup")
        _model_timestamp = DirectCast(_dr("model_timestamp"), DateTime)
        _model_volume = ConvertToSomething(_dr("model_volume"), 0)
        _mrp_status = DirectCast(_dr("mrp_status"), Byte)
        _mrp_hide = DirectCast(_dr("mrp_hide"), Byte)
        _mrp_group = DirectCast(_dr("mrp_group"), Byte)
        _manufmodelnumber = _dr("manufmodelnumber").ToString()
        _altwrtydatecode = _dr("altwrtydatecode")
        _hasBC = _dr("has_bc")
    End Sub
    Protected Function GetSelectStatement(ByVal ID As Integer) As String
        Dim _sql As String
        _sql = "SELECT "
        _sql += "Model_ID, "
        _sql += "Model_Desc, "
        _sql += "Model_Type, "
        _sql += "Model_MotoSku, "
        _sql += "Model_Tier, "
        _sql += "Model_Flat, "
        _sql += "Model_HexSN, "
        _sql += "Manuf_ID, "
        '_sql += "Manuf_desc, "
        _sql += "Prod_ID, "
        _sql += "ProdGrp_ID, "
        _sql += "ASCPrice_ID, "
        _sql += "RptGrp_ID, "
        _sql += "Conv_ID, "
        _sql += "Dcode_ID, "
        _sql += "Model_GSM, "
        _sql += "Accessory, "
        _sql += "UPC_Code, "
        _sql += "User_ID, "
        _sql += "UpdateDate, "
        _sql += "Weight_Factor, "
        _sql += "GoalHour, "
        _sql += "PiecesPerHour, "
        _sql += "PiecePoint, "
        _sql += "PointGoal, "
        _sql += "AutoBillFlg, "
        _sql += "Model_UnlockCode, "
        _sql += "CustomModelGroup, "
        _sql += "Model_Timestamp, "
        _sql += "Model_Volume, "
        _sql += "MRP_Status, "
        _sql += "MRP_Hide, "
        _sql += "MRP_Group, "
        _sql += "ManufModelNumber, "
        _sql += "AltWrtyDateCode, "
        _sql += "Has_BC "
        _sql += "FROM tmodel "
        _sql += "WHERE MODEL_ID = " & ID.ToString() & ""
        Return _sql
    End Function

#End Region

End Class


Public Class ModelCollection
#Region "DECLARATIONS"

    Inherits Collections.ArrayList
    Private _objDataProc As DBQuery.DataProc
    Private _dt As New DataTable()
    Private _list As New ArrayList()

#End Region
#Region "CONSTRUCTORS"

    Public Sub New(ByVal Model_ID As Integer)
        _objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
        GetData(Model_ID)
    End Sub

#End Region
#Region "PROPERTIES"

    Public ReadOnly Property ModelDataTable() As DataTable
        Get
            Return _dt
        End Get
    End Property

#End Region
#Region "METHODS"

    Protected Sub GetData(ByVal Model_ID As Integer)
        Dim _sql As String = GetSelectStatement(Model_ID)
        _dt = _objDataProc.GetDataTable(_sql)
    End Sub

    Protected Function GetSelectStatement(ByVal cust_id As Integer) As String
        Dim _sql As String
        _sql = "SELECT MAN.manuf_desc, M.* "
        _sql += "FROM tmodel M "
        _sql += "INNER JOIN tcustmodel_pssmodel_map MAP ON M.model_id = MAP.model_id "
        _sql += "INNER JOIN lmanuf MAN on M.manuf_id = MAN.manuf_id "
        _sql += "WHERE MAP.cust_id = " & cust_id.ToString() & ""
        Return _sql
    End Function

#End Region
End Class


