Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic

Public Class ModelFamily

#Region "DECLARATIONS"

    Private _modelfamiliesid As Integer = 0
    Private _name As String = ""
    Private _modelidset As String = ""
    Private _customerid As Integer = 0
    Private _modelidsandcustomerids As String = ""
    Private _lastupdatedt As Date
    Private _lastupdateuserid As Integer = 0
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
    Public Sub New(ByVal ModelFamilyID As Integer)
        _objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
        GetData(ModelFamilyID)
        _isNew = False
        _isDirty = False
    End Sub
    Public Sub New(ByVal dr As DataRow)
        _objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
        PopulateObject(dr)
        _isDirty = False
        _isNew = False
    End Sub
    Public Sub New( _
    ByVal modelfamiliesid As Int32, _
    ByVal name As String, _
    ByVal modelidset As String, _
    ByVal customerid As Int32, _
    ByVal modelidsandcustomerids As String, _
    ByVal lastupdatedt As DateTime, _
    ByVal lastupdateuserid As Int32 _
     )
        _modelfamiliesid = modelfamiliesid
        _name = name
        _modelidset = modelidset
        _customerid = customerid
        _modelidsandcustomerids = modelidsandcustomerids
        _lastupdatedt = lastupdatedt
        _lastupdateuserid = lastupdateuserid
    End Sub

#End Region
#Region "PROPERTIES"

    Public Property ModelFamiliesID() As Integer
        Get
            Return _modelfamiliesid
        End Get
        Set(ByVal Value As Integer)
            _modelfamiliesid = Value
        End Set
    End Property
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal Value As String)
            _name = Value
            _isDirty = True
        End Set
    End Property
    Public Property ModelIDSet() As String
        Get
            Return _modelidset
        End Get
        Set(ByVal Value As String)
            _modelidset = Value
        End Set
    End Property
    Public Property CustomerID() As Integer
        Get
            Return _customerid
        End Get
        Set(ByVal Value As Integer)
            _customerid = Value
            _isDirty = True
        End Set
    End Property
    Public Property ModelIDsAndCustomerIDs() As String
        Get
            Return _modelidsandcustomerids
        End Get
        Set(ByVal Value As String)
            _modelidsandcustomerids = Value
            _isDirty = True
        End Set
    End Property
    Public Property LastUpdateDT() As Date
        Get
            Return _lastupdatedt
        End Get
        Set(ByVal Value As Date)
            _lastupdatedt = Value
            _isDirty = True
        End Set
    End Property
    Public Property LastUpdateUserID() As Integer
        Get
            Return _lastupdateuserid
        End Get
        Set(ByVal Value As Integer)
            _lastupdateuserid = Value
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
        Dim _lst_upt_dt As String
        _modelfamiliesid = DirectCast(_dr("modelfamiliesid"), Integer)
        _name = _dr("name").ToString()
        _modelidset = _dr("modelidset").ToString()
        _customerid = DirectCast(_dr("customerid"), Integer)
        _modelidsandcustomerids = _dr("modelidsandcustomerids").ToString()
        _lst_upt_dt = _dr("lastupdatedt").ToString()
        If IsDate(_lst_upt_dt) Then
            _lastupdatedt = DirectCast(_dr("lastupdatedt"), DateTime)
        End If
        _lastupdateuserid = DirectCast(_dr("lastupdateuserid"), Integer)
    End Sub
    Protected Function GetSelectStatement(ByVal ID As Integer) As String
        Dim _sql As String
        _sql = "SELECT "
        _sql += "ModelFamiliesID, "
        _sql += "Name, "
        _sql += "ModelIDSet, "
        _sql += "CustomerID, "
        _sql += "ModelIDsAndCustomerIDs, "
        _sql += "LastUpdateDT, "
        _sql += "LastUpdateUserID "
        _sql += "FROM cogs.modelfamilies "
        _sql += "WHERE ModelFamiliesID = " & ID.ToString() & ""
        Return _sql
    End Function
    Public Sub ApplyChanges()
        If IsNew() Then
            _modelfamiliesid = Insert()
            _isNew = False
        ElseIf IsDeleted Then
            ' delete
        ElseIf IsDirty Then
            ' update
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
            strSQL = "INSERT INTO cogs.ModelFamilies (Name, customerid, LastUpdateDT, LastUpdateUserID )" & Environment.NewLine
            strSQL &= String.Format("VALUES ('{0}', {1}, '{2}', {3} )", Name, CustomerID, strToday, LastUpdateUserID)
            _id = objDataProc.ExecuteScalarForInsert(strSQL, "cogs.ModelFamilies")
            Data.Buisness.ModManuf.SaveModelFamilyCustMap(_customerid, _id, 0, 0, 0, LastUpdateUserID, 0)
            Return _id
        Catch ex As Exception
            If InStr(ex.Message, "Duplicate") > 0 Then
                Throw New Exception("Duplicate exists for this Model Family.")
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
            strSQL = "UPDATE cogs.ModelFamilies SET "
            strSQL &= "Name = '" & Name & "', "
            strSQL &= "LastUpdateDT = '" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "', "
            strSQL &= "LastUpdateUserID = " & Me.LastUpdateUserID.ToString() & " "
            strSQL &= "WHERE ModelFamiliesID = " & ModelFamiliesID.ToString()
            objDataProc.ExecuteNonQuery(strSQL)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Shared Sub SetData(ByVal [string] As String)
        Dim objDataProc As DBQuery.DataProc
        Try
            objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            objDataProc.ExecuteNonQuery([string])
        Catch ex As Exception
            Throw ex
        Finally
            objDataProc = Nothing
        End Try
    End Sub


#End Region
End Class

Public Class ModelFamilyCollection
#Region "DECLARATIONS"

    Inherits Collections.ArrayList
    Private _objDataProc As DBQuery.DataProc
    Private _dt As New DataTable()
    Private _list As New ArrayList()

#End Region
#Region "CONSTRUCTORS"

    Public Sub New(ByVal ModelFamiliesID As Integer)
        _objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
        GetData(ModelFamiliesID)
    End Sub

#End Region
#Region "PROPERTIES"

    Public ReadOnly Property ModelFamilyDataTable() As DataTable
        Get
            Return _dt
        End Get
    End Property

#End Region
#Region "METHODS"

    Protected Sub GetData(ByVal ModelFamiliesID As Integer)
        Dim _sql As String = GetSelectStatement(ModelFamiliesID)
        _dt = _objDataProc.GetDataTable(_sql)
    End Sub

    Protected Function GetSelectStatement(ByVal cust_id As Integer) As String
        Dim _sql As String
        _sql = "SELECT "
        _sql += "Cust_ID, "
        _sql += "Model_ID "
        _sql += "FROM tcustmodel_pssmodel_map "
        _sql += "WHERE cust_id = " & cust_id.ToString() & ""
        Return _sql
    End Function

#End Region
End Class


