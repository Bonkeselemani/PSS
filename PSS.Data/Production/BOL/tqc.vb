Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic
Namespace BOL
	Public Class tqc
#Region "DECLARATIONS"

		Private _qc_id As Integer = 0
		Private _qc_date As String
		Private _qc_workdate As String
		Private _qc_iteration As Boolean = False
		Private _qctype_id As Boolean = False
		Private _qccredit As Integer = 0
		Private _qcresult_id As Boolean = False
		Private _inspector_id As Integer = 0
		Private _tech_id As Integer = 0
		Private _group_id As Integer = 0
		Private _line_id As Integer = 0
		Private _cc_id As Integer = 0
		Private _device_id As Integer = 0
		Private _dcode_id As Integer = 0
		Private _pallett_id As Integer = 0
		Private _qc_otherfails As String = ""
		Private _qcfailcomment As String = ""
		Private _bucketlot_id As Integer = 0
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
		Public Sub New(ByVal qc_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(qc_id)
			_isDirty = False
			_isNew = False
		End Sub
#End Region
#Region "PROPERTIES"
		Public Property QC_ID() As Integer
			Get
				Return _qc_id
			End Get
			Set(ByVal Value As Integer)
				_qc_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property QC_Date() As String
			Get
				Return _qc_date
			End Get
			Set(ByVal Value As String)
				_qc_date = Value
				_isDirty = True
			End Set
		End Property
		Public Property QC_WorkDate() As String
			Get
				Return _qc_workdate
			End Get
			Set(ByVal Value As String)
				_qc_workdate = Value
				_isDirty = True
			End Set
		End Property
		Public Property QC_Iteration() As Boolean
			Get
				Return _qc_iteration
			End Get
			Set(ByVal Value As Boolean)
				_qc_iteration = Value
				_isDirty = True
			End Set
		End Property
		Public Property QCType_ID() As Boolean
			Get
				Return _qctype_id
			End Get
			Set(ByVal Value As Boolean)
				_qctype_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property QCCredit() As Integer
			Get
				Return _qccredit
			End Get
			Set(ByVal Value As Integer)
				_qccredit = Value
				_isDirty = True
			End Set
		End Property
		Public Property QCResult_ID() As Boolean
			Get
				Return _qcresult_id
			End Get
			Set(ByVal Value As Boolean)
				_qcresult_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property Inspector_ID() As Integer
			Get
				Return _inspector_id
			End Get
			Set(ByVal Value As Integer)
				_inspector_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property Tech_ID() As Integer
			Get
				Return _tech_id
			End Get
			Set(ByVal Value As Integer)
				_tech_id = Value
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
		Public Property Line_ID() As Integer
			Get
				Return _line_id
			End Get
			Set(ByVal Value As Integer)
				_line_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property cc_id() As Integer
			Get
				Return _cc_id
			End Get
			Set(ByVal Value As Integer)
				_cc_id = Value
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
		Public Property DCode_ID() As Integer
			Get
				Return _dcode_id
			End Get
			Set(ByVal Value As Integer)
				_dcode_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property Pallett_ID() As Integer
			Get
				Return _pallett_id
			End Get
			Set(ByVal Value As Integer)
				_pallett_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property QC_OtherFails() As String
			Get
				Return _qc_otherfails
			End Get
			Set(ByVal Value As String)
				_qc_otherfails = Value
				_isDirty = True
			End Set
		End Property
		Public Property QCFailComment() As String
			Get
				Return _qcfailcomment
			End Get
			Set(ByVal Value As String)
				_qcfailcomment = Value
				_isDirty = True
			End Set
		End Property
		Public Property BucketLot_ID() As Integer
			Get
				Return _bucketlot_id
			End Get
			Set(ByVal Value As Integer)
				_bucketlot_id = Value
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
		Protected Sub GetData(ByVal qc_id As Integer)
			Dim _sql As String = GetSelectStatement(qc_id)
			Dim _dt As New DataTable()
			_dt = _objDataProc.GetDataTable(_sql)
			If _dt.Rows.Count > 0 Then
				PopulateObject(_dt.Rows(0))
			End If
		End Sub
		Private Sub PopulateObject(ByVal _dr As DataRow)

			_qc_id = ConvertToSomething(_dr("qc_id"), 0)
			_qc_date = ConvertToSomething(_dr("qc_date").ToString(), "")
			_qc_workdate = ConvertToSomething(_dr("qc_workdate").ToString(), "")
			_qc_iteration = ConvertToSomething(_dr("qc_iteration"), False)
			_qctype_id = ConvertToSomething(_dr("qctype_id"), False)
			_qccredit = _dr("qccredit").ToString()
			_qcresult_id = ConvertToSomething(_dr("qcresult_id"), False)
			_inspector_id = ConvertToSomething(_dr("inspector_id"), 0)
			_tech_id = ConvertToSomething(_dr("tech_id"), 0)
			_group_id = ConvertToSomething(_dr("group_id"), 0)
			_line_id = ConvertToSomething(_dr("line_id"), 0)
			_cc_id = ConvertToSomething(_dr("cc_id"), 0)
			_device_id = ConvertToSomething(_dr("device_id"), 0)
			_dcode_id = ConvertToSomething(_dr("dcode_id"), 0)
			_pallett_id = _dr("pallett_id").ToString()
			_qc_otherfails = ConvertToSomething(_dr("qc_otherfails").ToString(), "")
			_qcfailcomment = ConvertToSomething(_dr("qcfailcomment").ToString(), "")
			_bucketlot_id = ConvertToSomething(_dr("bucketlot_id"), 0)
		End Sub
		Protected Function GetSelectStatement(ByVal qc_id As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "QC_ID, "
			_sql += "QC_Date, "
			_sql += "QC_WorkDate, "
			_sql += "QC_Iteration, "
			_sql += "QCType_ID, "
			_sql += "QCCredit, "
			_sql += "QCResult_ID, "
			_sql += "Inspector_ID, "
			_sql += "Tech_ID, "
			_sql += "Group_ID, "
			_sql += "Line_ID, "
			_sql += "cc_id, "
			_sql += "Device_ID, "
			_sql += "DCode_ID, "
			_sql += "Pallett_ID, "
			_sql += "QC_OtherFails, "
			_sql += "QCFailComment, "
			_sql += "BucketLot_ID "
			_sql += "FROM production.tqc "
			_sql += "WHERE qc_id = " & qc_id.ToString() & ""
			Return _sql
		End Function
		Public Sub MarkDeleted()
			_isDeleted = True
		End Sub
		Public Sub ApplyChanges()
			If _isNew Then
				_qc_id = Insert()
			ElseIf IsDeleted Then
				Delete()
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
				strSQL = "INSERT INTO production.tqc (" & _
				   "qc_id, " & _
				   "qc_date, " & _
				   "qc_workdate, " & _
				   "qc_iteration, " & _
				   "qctype_id, " & _
				   "qccredit, " & _
				   "qcresult_id, " & _
				   "inspector_id, " & _
				   "tech_id, " & _
				   "group_id, " & _
				   "line_id, " & _
				   "cc_id, " & _
				   "device_id, " & _
				   "dcode_id, " & _
				   "pallett_id, " & _
				   "qc_otherfails, " & _
				   "qcfailcomment, " & _
				   "bucketlot_id " & _
				  ") " & _
				  "VALUES ( " & _
				   _qc_id & " , " & _
				   ConvertBackToNullString(_qc_date, False) & " , " & _
				   ConvertBackToNullString(_qc_workdate, False) & " , " & _
				   _qc_iteration & " , " & _
				   _qctype_id & " , " & _
				   _qccredit & " , " & _
				   _qcresult_id & " , " & _
				   _inspector_id & " , " & _
				   _tech_id & " , " & _
				   _group_id & " , " & _
				   _line_id & " , " & _
				   _cc_id & " , " & _
				   _device_id & " , " & _
				   _dcode_id & " , " & _
				   ConvertBackToNullString(_pallett_id, False) & " , " & _
				   _qc_otherfails & " , " & _
				   _qcfailcomment & " , " & _
				   _bucketlot_id & "  " & _
				   ")"
				_id = objDataProc.ExecuteScalarForInsert(strSQL, "production.tqc")
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
				strSQL = "UPDATE production.tqc SET " & _
				   "qc_id = " & ConvertBackToNullString(_qc_id, False) & ", " & _
				   "qc_date = " & ConvertBackToNullString(_qc_date, False) & ", " & _
				   "qc_workdate = " & ConvertBackToNullString(_qc_workdate, False) & ", " & _
				   "qc_iteration = " & ConvertBackToNullString(_qc_iteration, False) & ", " & _
				   "qctype_id = " & ConvertBackToNullString(_qctype_id, False) & ", " & _
				   "qccredit = " & ConvertBackToNullString(_qccredit, False) & ", " & _
				   "qcresult_id = " & ConvertBackToNullString(_qcresult_id, False) & ", " & _
				   "inspector_id = " & ConvertBackToNullString(_inspector_id, False) & ", " & _
				   "tech_id = " & ConvertBackToNullString(_tech_id, False) & ", " & _
				   "group_id = " & ConvertBackToNullString(_group_id, False) & ", " & _
				   "line_id = " & ConvertBackToNullString(_line_id, False) & ", " & _
				   "cc_id = " & ConvertBackToNullString(_cc_id, False) & ", " & _
				   "device_id = " & ConvertBackToNullString(_device_id, False) & ", " & _
				   "dcode_id = " & ConvertBackToNullString(_dcode_id, False) & ", " & _
				   "pallett_id = " & ConvertBackToNullString(_pallett_id, False) & ", " & _
				   "qc_otherfails = " & ConvertBackToNullString(_qc_otherfails, False) & ", " & _
				   "qcfailcomment = " & ConvertBackToNullString(_qcfailcomment, False) & ", " & _
				   "bucketlot_id = " & ConvertBackToNullString(_bucketlot_id, False) & ", " & _
				  "WHERE QC_ID = " & QC_ID.ToString() & "; "
				Return objDataProc.ExecuteNonQuery(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Protected Function Delete() As Integer
			Dim strSQL As String = ""
			Try
				Dim _cnt As Integer = 0
				Dim objDataProc As DBQuery.DataProc
				objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
				strSQL = " DELETE FROM production.tqc WHERE qc_id = " & _qc_id.ToString() & "; "
				_cnt = objDataProc.ExecuteNonQuery(strSQL)
				Return _cnt
			Catch ex As Exception
				Throw ex
				Return 0
			End Try
		End Function
#End Region
	End Class
	Public Class tqcCollection
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
		Public ReadOnly Property tqcDataTable() As DataTable
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
			_sb.Append("QC_ID, ")
			_sb.Append("QC_Date, ")
			_sb.Append("QC_WorkDate, ")
			_sb.Append("QC_Iteration, ")
			_sb.Append("QCType_ID, ")
			_sb.Append("QCCredit, ")
			_sb.Append("QCResult_ID, ")
			_sb.Append("Inspector_ID, ")
			_sb.Append("Tech_ID, ")
			_sb.Append("Group_ID, ")
			_sb.Append("Line_ID, ")
			_sb.Append("cc_id, ")
			_sb.Append("Device_ID, ")
			_sb.Append("DCode_ID, ")
			_sb.Append("Pallett_ID, ")
			_sb.Append("QC_OtherFails, ")
			_sb.Append("QCFailComment, ")
			_sb.Append("BucketLot_ID ")
			_sb.Append("FROM production.tqc; ")
			Return _sb.ToString()
		End Function
#End Region
	End Class
	Public Class tqcDeviceQcCollection
#Region "DECLARATIONS"
		Inherits Collections.ArrayList
		Private _objDataProc As DBQuery.DataProc
		Private _dt As New DataTable()
		Private _list As New ArrayList()
#End Region
#Region "CONSTRUCTORS"
		Public Sub New(ByVal device_id As Integer, ByVal qctype_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData(device_id, qctype_id)
		End Sub
#End Region
#Region "PROPERTIES"
		Public ReadOnly Property tqcDataTable() As DataTable
			Get
				Return _dt
			End Get
		End Property
#End Region
#Region "METHODS"
		Protected Sub GetData(ByVal device_id As Integer, ByVal qctype_id As Integer)
			Dim _sql As String = GetSelectStatement(device_id, qctype_id)
			_dt = _objDataProc.GetDataTable(_sql)
		End Sub
		Protected Function GetSelectStatement(ByVal device_id As Integer, ByVal qctype_id As Integer) As String
			Dim _sb As New StringBuilder()
			_sb.Append("SELECT ")
			_sb.Append("tqc.QC_ID, ")
			_sb.Append("tqc.QC_Date, ")
			_sb.Append("tqc.QC_WorkDate, ")
			_sb.Append("tqc.QC_Iteration, ")
			_sb.Append("tqc.QCType_ID, ")
			_sb.Append("tqc.QCCredit, ")
			_sb.Append("tqc.QCResult_ID, ")
			_sb.Append("tqc.Inspector_ID, ")
			_sb.Append("tqc.Tech_ID, ")
			_sb.Append("tqc.Group_ID, ")
			_sb.Append("tqc.Line_ID, ")
			_sb.Append("tqc.cc_id, ")
			_sb.Append("tqc.Device_ID, ")
			_sb.Append("tqc.DCode_ID, ")
			_sb.Append("tqc.Pallett_ID, ")
			_sb.Append("tqc.QC_OtherFails, ")
			_sb.Append("tqc.QCFailComment, ")
			_sb.Append("tqc.BucketLot_ID, ")
			_sb.Append("qcr.qcresult ")
			_sb.Append("FROM production.tqc ")
			_sb.Append("LEFT JOIN lqcresult qcr on tqc.qcresult_id = qcr.qcresult_id ")
			_sb.Append("WHERE tqc.qctype_id = " & qctype_id.ToString() & " ")
			_sb.Append("AND tqc.device_id = " & device_id.ToString() & " ")
			_sb.Append("ORDER BY tqc.QC_Date DESC")
			Return _sb.ToString()
		End Function
#End Region
	End Class
End Namespace
