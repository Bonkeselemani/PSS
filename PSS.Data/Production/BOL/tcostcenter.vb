Imports System
Imports System.Collections
Imports System.Text
Imports System.Data
Imports System.Configuration
Imports PSS.Data.Buisness.Generic

Namespace BOL

	Public Class tcostcenter

#Region "DECLARATIONS"

		Private _cc_id As Integer = 0
		Private _cc_desc As String = ""
		Private _group_id As Integer = 0
		Private _uph_goal As Decimal = 0
		Private _cc_inactive As Byte = 0
		Private _cc_rcf As Integer = 0
		Private _cc_rof As Integer = 0
		Private _cc_uph_tier1 As Decimal = 0
		Private _cc_uph_tier2 As Decimal = 0
		Private _cc_tier1_rate As Decimal = 0
		Private _cc_tier2_rate As Decimal = 0
		Private _cc_reddotpercent As Decimal = 0
		Private _cc_faillimitpercent As Decimal = 0
		Private _cc_produceby_qctypeid As Integer = 0
		Private _cc_lunchstarttime As String = ""
		Private _cc_lunchendtime As String = ""
		Private _cc_screenrefreshsec As Short = 0
		Private _cc_specproj As Short = 0
		Private _wa_id As Short = 0
		Private _cc_bin As String = ""
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
		ByVal cc_id As Int32, _
		ByVal cc_desc As String, _
		ByVal group_id As Int32, _
		ByVal uph_goal As Decimal, _
		ByVal cc_inactive As Byte, _
		ByVal cc_rcf As Int32, _
		ByVal cc_rof As Int32, _
		ByVal cc_uph_tier1 As Decimal, _
		ByVal cc_uph_tier2 As Decimal, _
		ByVal cc_tier1_rate As Decimal, _
		ByVal cc_tier2_rate As Decimal, _
		ByVal cc_reddotpercent As Decimal, _
		ByVal cc_faillimitpercent As Decimal, _
		ByVal cc_produceby_qctypeid As Int32, _
		ByVal cc_lunchstarttime As String, _
		ByVal cc_lunchendtime As String, _
		ByVal cc_screenrefreshsec As Int16, _
		ByVal cc_specproj As Int16, _
		ByVal wa_id As Int16, _
		ByVal cc_bin As String _
		 )
			_cc_id = cc_id
			_cc_desc = cc_desc
			_group_id = group_id
			_uph_goal = uph_goal
			_cc_inactive = cc_inactive
			_cc_rcf = cc_rcf
			_cc_rof = cc_rof
			_cc_uph_tier1 = cc_uph_tier1
			_cc_uph_tier2 = cc_uph_tier2
			_cc_tier1_rate = cc_tier1_rate
			_cc_tier2_rate = cc_tier2_rate
			_cc_reddotpercent = cc_reddotpercent
			_cc_faillimitpercent = cc_faillimitpercent
			_cc_produceby_qctypeid = cc_produceby_qctypeid
			_cc_lunchstarttime = cc_lunchstarttime
			_cc_lunchendtime = cc_lunchendtime
			_cc_screenrefreshsec = cc_screenrefreshsec
			_cc_specproj = cc_specproj
			_wa_id = wa_id
			_cc_bin = cc_bin
		End Sub

#End Region
#Region "PROPERTIES"

		Public Property cc_id() As Integer
			Get
				Return _cc_id
			End Get
			Set(ByVal Value As Integer)
				_cc_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property cc_desc() As String
			Get
				Return _cc_desc
			End Get
			Set(ByVal Value As String)
				_cc_desc = Value
				_isDirty = True
			End Set
		End Property
		Public Property group_id() As Integer
			Get
				Return _group_id
			End Get
			Set(ByVal Value As Integer)
				_group_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property uph_goal() As Decimal
			Get
				Return _uph_goal
			End Get
			Set(ByVal Value As Decimal)
				_uph_goal = Value
				_isDirty = True
			End Set
		End Property
		Public Property cc_inactive() As Byte
			Get
				Return _cc_inactive
			End Get
			Set(ByVal Value As Byte)
				_cc_inactive = Value
				_isDirty = True
			End Set
		End Property
		Public Property cc_rcf() As Integer
			Get
				Return _cc_rcf
			End Get
			Set(ByVal Value As Integer)
				_cc_rcf = Value
				_isDirty = True
			End Set
		End Property
		Public Property cc_rof() As Integer
			Get
				Return _cc_rof
			End Get
			Set(ByVal Value As Integer)
				_cc_rof = Value
				_isDirty = True
			End Set
		End Property
		Public Property cc_uph_tier1() As Decimal
			Get
				Return _cc_uph_tier1
			End Get
			Set(ByVal Value As Decimal)
				_cc_uph_tier1 = Value
				_isDirty = True
			End Set
		End Property
		Public Property cc_uph_tier2() As Decimal
			Get
				Return _cc_uph_tier2
			End Get
			Set(ByVal Value As Decimal)
				_cc_uph_tier2 = Value
				_isDirty = True
			End Set
		End Property
		Public Property cc_tier1_rate() As Decimal
			Get
				Return _cc_tier1_rate
			End Get
			Set(ByVal Value As Decimal)
				_cc_tier1_rate = Value
				_isDirty = True
			End Set
		End Property
		Public Property cc_tier2_rate() As Decimal
			Get
				Return _cc_tier2_rate
			End Get
			Set(ByVal Value As Decimal)
				_cc_tier2_rate = Value
				_isDirty = True
			End Set
		End Property
		Public Property cc_redDotPercent() As Decimal
			Get
				Return _cc_reddotpercent
			End Get
			Set(ByVal Value As Decimal)
				_cc_reddotpercent = Value
				_isDirty = True
			End Set
		End Property
		Public Property cc_failLimitPercent() As Decimal
			Get
				Return _cc_faillimitpercent
			End Get
			Set(ByVal Value As Decimal)
				_cc_faillimitpercent = Value
				_isDirty = True
			End Set
		End Property
		Public Property cc_produceBy_QCTypeID() As Integer
			Get
				Return _cc_produceby_qctypeid
			End Get
			Set(ByVal Value As Integer)
				_cc_produceby_qctypeid = Value
				_isDirty = True
			End Set
		End Property
		Public Property cc_lunchStartTime() As String
			Get
				Return _cc_lunchstarttime
			End Get
			Set(ByVal Value As String)
				_cc_lunchstarttime = Value
				_isDirty = True
			End Set
		End Property
		Public Property cc_lunchEndTime() As String
			Get
				Return _cc_lunchendtime
			End Get
			Set(ByVal Value As String)
				_cc_lunchendtime = Value
				_isDirty = True
			End Set
		End Property
		Public Property cc_screenRefreshSec() As Short
			Get
				Return _cc_screenrefreshsec
			End Get
			Set(ByVal Value As Short)
				_cc_screenrefreshsec = Value
				_isDirty = True
			End Set
		End Property
		Public Property cc_specproj() As Short
			Get
				Return _cc_specproj
			End Get
			Set(ByVal Value As Short)
				_cc_specproj = Value
				_isDirty = True
			End Set
		End Property
		Public Property wa_id() As Short
			Get
				Return _wa_id
			End Get
			Set(ByVal Value As Short)
				_wa_id = Value
				_isDirty = True
			End Set
		End Property
		Public Property cc_bin() As String
			Get
				Return _cc_bin
			End Get
			Set(ByVal Value As String)
				_cc_bin = Value
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

			_cc_id = _dr("cc_id")
			_cc_desc = _dr("cc_desc").ToString()
			_group_id = _dr("group_id")
			_uph_goal = DirectCast(_dr("uph_goal"), Decimal)
			_cc_inactive = DirectCast(_dr("cc_inactive"), Byte)
			_cc_rcf = _dr("cc_rcf")
			_cc_rof = _dr("cc_rof")
			_cc_uph_tier1 = DirectCast(_dr("cc_uph_tier1"), Decimal)
			_cc_uph_tier2 = DirectCast(_dr("cc_uph_tier2"), Decimal)
			_cc_tier1_rate = DirectCast(_dr("cc_tier1_rate"), Decimal)
			_cc_tier2_rate = DirectCast(_dr("cc_tier2_rate"), Decimal)
			_cc_reddotpercent = DirectCast(_dr("cc_reddotpercent"), Decimal)
			_cc_faillimitpercent = DirectCast(_dr("cc_faillimitpercent"), Decimal)
			_cc_produceby_qctypeid = _dr("cc_produceby_qctypeid")
			_cc_lunchstarttime = _dr("cc_lunchstarttime").ToString()
			_cc_lunchendtime = _dr("cc_lunchendtime").ToString()
			_cc_screenrefreshsec = _dr("cc_screenrefreshsec")
			_cc_specproj = _dr("cc_specproj")
			_wa_id = _dr("wa_id")
			_cc_bin = _dr("cc_bin").ToString()
		End Sub
		Protected Function GetSelectStatement(ByVal ID As Integer) As String
			Dim _sql As String
			_sql = "SELECT "
			_sql += "cc_id, "
			_sql += "cc_desc, "
			_sql += "group_id, "
			_sql += "uph_goal, "
			_sql += "cc_inactive, "
			_sql += "cc_rcf, "
			_sql += "cc_rof, "
			_sql += "cc_uph_tier1, "
			_sql += "cc_uph_tier2, "
			_sql += "cc_tier1_rate, "
			_sql += "cc_tier2_rate, "
			_sql += "cc_redDotPercent, "
			_sql += "cc_failLimitPercent, "
			_sql += "cc_produceBy_QCTypeID, "
			_sql += "cc_lunchStartTime, "
			_sql += "cc_lunchEndTime, "
			_sql += "cc_screenRefreshSec, "
			_sql += "cc_specproj, "
			_sql += "wa_id, "
			_sql += "cc_bin "
			_sql += "FROM production.tcostcenter "
			Return _sql
		End Function

		Public Sub ApplyChanges()
			If _isNew Then
				_cc_id = Insert()
			ElseIf IsDeleted Then
				' delete
			ElseIf IsDirty Then
				' Update
			End If
		End Sub

		Protected Function Insert() As Integer
			Dim strSQL, strToday As String
			Try
				Dim objDataProc As DBQuery.DataProc
				Dim _id As Integer
				objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
				strToday = PSS.Data.Buisness.Generic.GetMySqlDateTime("%Y-%m-%d")
				strSQL = "INSERT INTO production.tcostcenter (" & _
				   "cc_id, " & _
				   "cc_desc, " & _
				   "group_id, " & _
				   "uph_goal, " & _
				   "cc_inactive, " & _
				   "cc_rcf, " & _
				   "cc_rof, " & _
				   "cc_uph_tier1, " & _
				   "cc_uph_tier2, " & _
				   "cc_tier1_rate, " & _
				   "cc_tier2_rate, " & _
				   "cc_reddotpercent, " & _
				   "cc_faillimitpercent, " & _
				   "cc_produceby_qctypeid, " & _
				   "cc_lunchstarttime, " & _
				   "cc_lunchendtime, " & _
				   "cc_screenrefreshsec, " & _
				   "cc_specproj, " & _
				   "wa_id, " & _
				   "cc_bin " & _
				  ") " & _
				  "VALUES ( " & _
				   _cc_id.ToString() & "," & _
				   _cc_desc.ToString() & "," & _
				   _group_id.ToString() & "," & _
				   _uph_goal.ToString() & "," & _
				   _cc_inactive.ToString() & "," & _
				   _cc_rcf.ToString() & "," & _
				   _cc_rof.ToString() & "," & _
				   _cc_uph_tier1.ToString() & "," & _
				   _cc_uph_tier2.ToString() & "," & _
				   _cc_tier1_rate.ToString() & "," & _
				   _cc_tier2_rate.ToString() & "," & _
				   _cc_reddotpercent.ToString() & "," & _
				   _cc_faillimitpercent.ToString() & "," & _
				   _cc_produceby_qctypeid.ToString() & "," & _
				   _cc_lunchstarttime.ToString() & "," & _
				   _cc_lunchendtime.ToString() & "," & _
				   _cc_screenrefreshsec.ToString() & "," & _
				   _cc_specproj.ToString() & "," & _
				   _wa_id.ToString() & "," & _
				   _cc_bin.ToString() & _
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

#End Region

	End Class


	Public Class tcostcenterCollection
#Region "DECLARATIONS"

		Inherits Collections.ArrayList
		Private _objDataProc As DBQuery.DataProc
		Private _dt As New DataTable()
		Private _list As New ArrayList()

#End Region
#Region "CONSTRUCTORS"

		Public Sub New(ByVal cc_id As Integer)
			_objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			GetData()
		End Sub

#End Region
#Region "PROPERTIES"

		Public ReadOnly Property tcostcenterDataTable() As DataTable
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
			_sql += "cc_id, "
			_sql += "cc_desc, "
			_sql += "group_id, "
			_sql += "uph_goal, "
			_sql += "cc_inactive, "
			_sql += "cc_rcf, "
			_sql += "cc_rof, "
			_sql += "cc_uph_tier1, "
			_sql += "cc_uph_tier2, "
			_sql += "cc_tier1_rate, "
			_sql += "cc_tier2_rate, "
			_sql += "cc_redDotPercent, "
			_sql += "cc_failLimitPercent, "
			_sql += "cc_produceBy_QCTypeID, "
			_sql += "cc_lunchStartTime, "
			_sql += "cc_lunchEndTime, "
			_sql += "cc_screenRefreshSec, "
			_sql += "cc_specproj, "
			_sql += "wa_id, "
			_sql += "cc_bin "
			_sql += "FROM production.tcostcenter "
			Return _sql
		End Function

#End Region

	End Class

End Namespace
