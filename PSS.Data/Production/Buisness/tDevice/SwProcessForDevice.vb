Imports System.Data
Imports system.Text

Namespace Buisness

	Public Class SwProcessForDevice

#Region "DECLARATIONS"

		Private _objDataProc As New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

		' values set to id values.
		Public Enum SWProcessQuestions
			RedDot = 1
			Screenable = 2
			HasFreezePowerIssue = 3
			PinLocked = 4
			KillSwitchedEnabled = 5
			KillSwitchRemoved = 6
		End Enum

		Dim _device_id As Integer
		Dim _hasRedDot As Boolean = False
		Dim _screenable As Boolean = False
		Dim _hasFreezePowerIssues As Boolean = False
		Dim _pinLocked As Boolean = False
		Dim _killSwitchEnabled As Boolean = False
		Dim _killSwitchRemoved As Boolean = False

#End Region
#Region "CONSTRUCTORS"

		Public Sub New(ByVal device_id As Integer)
			_device_id = device_id
			Dim _dt As New DataTable()
			_dt = GetData(device_id)
			PopulateObject(_dt)
			_dt = Nothing
		End Sub

		Protected Overrides Sub Finalize()		'
			Try
				_objDataProc = Nothing
			Finally
				MyBase.Finalize()
				GC.Collect()
				GC.WaitForPendingFinalizers()
				GC.Collect()
				GC.WaitForPendingFinalizers()
			End Try
		End Sub

#End Region
#Region "PROPERTIES"

		Public ReadOnly Property Device_id() As Integer
			Get
				Return _device_id
			End Get
		End Property
		Public Property RedDot() As Boolean
			Get
				Return _hasRedDot
			End Get
			Set(ByVal Value As Boolean)
				_hasRedDot = Value
			End Set
		End Property
		Public Property Screenable() As Boolean
			Get
				Return _screenable
			End Get
			Set(ByVal Value As Boolean)
				_screenable = Value
			End Set
		End Property
		Public Property HasFreezePowerIssue() As Boolean
			Get
				Return _hasFreezePowerIssues
			End Get
			Set(ByVal Value As Boolean)
				_hasFreezePowerIssues = Value
			End Set
		End Property
		Public Property PINLocked() As Boolean
			Get
				Return _pinLocked
			End Get
			Set(ByVal Value As Boolean)
				_pinLocked = Value
			End Set
		End Property
		Public Property KillSwitchEnabled() As Boolean
			Get
				Return _killSwitchEnabled
			End Get
			Set(ByVal Value As Boolean)
				_killSwitchEnabled = Value
			End Set
		End Property
		Public Property KillSwitchRemoved() As Boolean
			Get
				Return _killSwitchRemoved
			End Get
			Set(ByVal Value As Boolean)
				_killSwitchRemoved = Value
			End Set
		End Property

#End Region
#Region "METHODS"

		Protected Function GetData(ByVal device_id As Integer) As DataTable
			' RETREIVES THE DATA FROM THE DATABASE.
			Dim _dt As New DataTable()
			Dim _sql As String = GetSelectStatement(device_id)
			_dt = _objDataProc.GetDataTable(_sql)
			Return _dt.Copy
			_dt = Nothing
		End Function
		Protected Function GetSelectStatement(ByVal device_id As Integer) As String
			' BUILDS SQL STATEMENT.
			Dim _sb As New StringBuilder()
			_sb.Append("SELECT ")
			_sb.Append("dq_id, ")
			_sb.Append("device_id, ")
			_sb.Append("q_id, ")
			_sb.Append("answer, ")
			_sb.Append("note, ")
			_sb.Append("crt_dt ")
			_sb.Append("FROM production.tdevice_question ")
			_sb.Append("WHERE ")
			_sb.Append("device_id = ")
			_sb.Append(device_id.ToString())
			_sb.Append("; ")
			Return _sb.ToString()
		End Function
		Private Sub PopulateObject(ByVal dt As DataTable)
			' POPULATES THE OBJECT FROM A DATATABLE.
			Dim dr As DataRow
			For Each dr In dt.Rows()
				If dr("q_id") = SWProcessQuestions.RedDot Then _hasRedDot = dr("answer")
				If dr("q_id") = SWProcessQuestions.Screenable Then _screenable = dr("answer")
				If dr("q_id") = SWProcessQuestions.HasFreezePowerIssue Then _hasFreezePowerIssues = dr("answer")
				If dr("q_id") = SWProcessQuestions.PinLocked Then _pinLocked = dr("answer")
				If dr("q_id") = SWProcessQuestions.KillSwitchedEnabled Then _killSwitchEnabled = dr("answer")
				If dr("q_id") = SWProcessQuestions.KillSwitchRemoved Then _killSwitchRemoved = dr("answer")
			Next
		End Sub

#End Region

	End Class

End Namespace
