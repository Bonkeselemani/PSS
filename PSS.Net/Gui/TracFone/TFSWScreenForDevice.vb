Imports PSS.Data.Buisness.TracFone
Imports PSS.Data.Buisness

Public Class TFSWScreenForDevice
	Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

	Private Sub New()
		MyBase.New()

		'This call is required by the Windows Form Designer.
		InitializeComponent()

		'Add any initialization after the InitializeComponent() call

	End Sub

	'Form overrides dispose to clean up the component list.
	Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing Then
			If Not (components Is Nothing) Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(disposing)
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	Friend WithEvents pnlData As System.Windows.Forms.Panel
	Friend WithEvents lblDestination As System.Windows.Forms.Label
	Friend WithEvents cbRemoved As System.Windows.Forms.CheckBox
	Friend WithEvents cbKSEnabled As System.Windows.Forms.CheckBox
	Friend WithEvents cbPINLocked As System.Windows.Forms.CheckBox
	Friend WithEvents cbFPIssue As System.Windows.Forms.CheckBox
	Friend WithEvents cbScreenable As System.Windows.Forms.CheckBox
	Friend WithEvents cbRedDot As System.Windows.Forms.CheckBox
	Friend WithEvents btnCancel As System.Windows.Forms.Button
	Friend WithEvents btnSave As System.Windows.Forms.Button
	Friend WithEvents Label7 As System.Windows.Forms.Label
	Friend WithEvents txtSN As System.Windows.Forms.TextBox
	Friend WithEvents lblInfo As System.Windows.Forms.Label
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.pnlData = New System.Windows.Forms.Panel()
		Me.lblDestination = New System.Windows.Forms.Label()
		Me.cbRemoved = New System.Windows.Forms.CheckBox()
		Me.cbKSEnabled = New System.Windows.Forms.CheckBox()
		Me.cbPINLocked = New System.Windows.Forms.CheckBox()
		Me.cbFPIssue = New System.Windows.Forms.CheckBox()
		Me.cbScreenable = New System.Windows.Forms.CheckBox()
		Me.cbRedDot = New System.Windows.Forms.CheckBox()
		Me.btnCancel = New System.Windows.Forms.Button()
		Me.btnSave = New System.Windows.Forms.Button()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.txtSN = New System.Windows.Forms.TextBox()
		Me.lblInfo = New System.Windows.Forms.Label()
		Me.pnlData.SuspendLayout()
		Me.SuspendLayout()
		'
		'pnlData
		'
		Me.pnlData.BackColor = System.Drawing.SystemColors.Control
		Me.pnlData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.pnlData.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblDestination, Me.cbRemoved, Me.cbKSEnabled, Me.cbPINLocked, Me.cbFPIssue, Me.cbScreenable, Me.cbRedDot})
		Me.pnlData.Location = New System.Drawing.Point(8, 40)
		Me.pnlData.Name = "pnlData"
		Me.pnlData.Size = New System.Drawing.Size(624, 280)
		Me.pnlData.TabIndex = 3
		'
		'lblDestination
		'
		Me.lblDestination.BackColor = System.Drawing.Color.FromArgb(CType(213, Byte), CType(213, Byte), CType(213, Byte))
		Me.lblDestination.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblDestination.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblDestination.ForeColor = System.Drawing.Color.Blue
		Me.lblDestination.Location = New System.Drawing.Point(8, 240)
		Me.lblDestination.Name = "lblDestination"
		Me.lblDestination.Size = New System.Drawing.Size(608, 32)
		Me.lblDestination.TabIndex = 6
		Me.lblDestination.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'cbRemoved
		'
		Me.cbRemoved.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cbRemoved.Location = New System.Drawing.Point(168, 184)
		Me.cbRemoved.Name = "cbRemoved"
		Me.cbRemoved.Size = New System.Drawing.Size(304, 24)
		Me.cbRemoved.TabIndex = 5
		Me.cbRemoved.Tag = "6"
		Me.cbRemoved.Text = "Did you romove the Kill Switch/PIN?"
		'
		'cbKSEnabled
		'
		Me.cbKSEnabled.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cbKSEnabled.Location = New System.Drawing.Point(144, 152)
		Me.cbKSEnabled.Name = "cbKSEnabled"
		Me.cbKSEnabled.Size = New System.Drawing.Size(304, 24)
		Me.cbKSEnabled.TabIndex = 4
		Me.cbKSEnabled.Tag = "5"
		Me.cbKSEnabled.Text = "Kill Switch Enabled?"
		'
		'cbPINLocked
		'
		Me.cbPINLocked.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cbPINLocked.Location = New System.Drawing.Point(144, 120)
		Me.cbPINLocked.Name = "cbPINLocked"
		Me.cbPINLocked.Size = New System.Drawing.Size(304, 24)
		Me.cbPINLocked.TabIndex = 3
		Me.cbPINLocked.Tag = "4"
		Me.cbPINLocked.Text = "PIN Locked?"
		'
		'cbFPIssue
		'
		Me.cbFPIssue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cbFPIssue.Location = New System.Drawing.Point(120, 88)
		Me.cbFPIssue.Name = "cbFPIssue"
		Me.cbFPIssue.Size = New System.Drawing.Size(304, 24)
		Me.cbFPIssue.TabIndex = 2
		Me.cbFPIssue.Tag = "3"
		Me.cbFPIssue.Text = "Has Freeze/Power Issue?"
		'
		'cbScreenable
		'
		Me.cbScreenable.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cbScreenable.Location = New System.Drawing.Point(96, 56)
		Me.cbScreenable.Name = "cbScreenable"
		Me.cbScreenable.Size = New System.Drawing.Size(304, 24)
		Me.cbScreenable.TabIndex = 1
		Me.cbScreenable.Tag = "2"
		Me.cbScreenable.Text = "Screen-able?"
		'
		'cbRedDot
		'
		Me.cbRedDot.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cbRedDot.Location = New System.Drawing.Point(96, 24)
		Me.cbRedDot.Name = "cbRedDot"
		Me.cbRedDot.Size = New System.Drawing.Size(304, 24)
		Me.cbRedDot.TabIndex = 0
		Me.cbRedDot.Tag = "1"
		Me.cbRedDot.Text = "Has Red Dot?"
		'
		'btnCancel
		'
		Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
		Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnCancel.Location = New System.Drawing.Point(536, 328)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(96, 32)
		Me.btnCancel.TabIndex = 9
		Me.btnCancel.Text = "Cancel"
		'
		'btnSave
		'
		Me.btnSave.BackColor = System.Drawing.SystemColors.Control
		Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnSave.Location = New System.Drawing.Point(424, 328)
		Me.btnSave.Name = "btnSave"
		Me.btnSave.Size = New System.Drawing.Size(96, 32)
		Me.btnSave.TabIndex = 8
		Me.btnSave.Text = "Save"
		'
		'Label7
		'
		Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label7.Location = New System.Drawing.Point(8, 8)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(80, 23)
		Me.Label7.TabIndex = 10
		Me.Label7.Text = "Serial No."
		Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'txtSN
		'
		Me.txtSN.BackColor = System.Drawing.Color.White
		Me.txtSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtSN.Location = New System.Drawing.Point(96, 8)
		Me.txtSN.Name = "txtSN"
		Me.txtSN.ReadOnly = True
		Me.txtSN.Size = New System.Drawing.Size(200, 23)
		Me.txtSN.TabIndex = 11
		Me.txtSN.Text = ""
		'
		'lblInfo
		'
		Me.lblInfo.Location = New System.Drawing.Point(312, 8)
		Me.lblInfo.Name = "lblInfo"
		Me.lblInfo.Size = New System.Drawing.Size(320, 24)
		Me.lblInfo.TabIndex = 12
		'
		'TFSWScreenForDevice
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(642, 368)
		Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblInfo, Me.Label7, Me.txtSN, Me.btnCancel, Me.btnSave, Me.pnlData})
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Name = "TFSWScreenForDevice"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Tracfone Software Screen For Device"
		Me.pnlData.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub

#End Region
#Region "DECLARATIONS"
	Private Enum Mode
		ByBox
		ByDevice
	End Enum
	Private _device As Data.BOL.tDevice
	Private _mode As Mode
	Private _box_nr As String
	Private _device_id As Integer = 0
	Private _device_sn As String = ""
	Private _defaultColor As Color
	Private _focusColor As Color = Color.SkyBlue
	Private _currentWS As String = ""
	Private _newWS As String = ""
	Private _newWSText As String = ""
	Private _snPendingWS As Boolean
	Private _editModeOn = False
    Private _loc_id = 2946
    Private _Model_ID As Integer = 0
    Private _bIsBuffable As Boolean = False
    Private _bSoftwareScreenInBilling As Boolean = False
#End Region
#Region "CONSTRUCTORS"

	Public Sub New(ByVal device_sn As String)
		MyBase.New()
		InitializeComponent()
		_device_sn = device_sn
		_mode = Mode.ByDevice
		_device = New Data.BOL.tDevice(_device_sn, False)
		_device_id = _device.Device_ID
		GetDeviceCurWS()
	End Sub
	Public Sub New(ByVal box_nr As String, ByVal device_sn As String)
		MyBase.New()
		InitializeComponent()
		_device_sn = device_sn
		_mode = Mode.ByBox
		_box_nr = box_nr
		_device = New Data.BOL.tDevice(_device_sn, False)
		_device_id = _device.Device_ID
		GetDeviceCurWS()
		_editModeOn = IsSNPendingWS()
    End Sub
    Public Sub New(ByVal device_sn As String, ByVal bSoftwareScreenInBilling As Boolean)
        MyBase.New()
        InitializeComponent()
        _device_sn = device_sn
        _bSoftwareScreenInBilling = bSoftwareScreenInBilling
        _mode = Mode.ByDevice
        _device = New Data.BOL.tDevice(_device_sn, False)
        _device_id = _device.Device_ID
        GetDeviceCurWS()
    End Sub
    Protected Overrides Sub Finalize()  '
        Try
            _device = Nothing
        Finally
            MyBase.Finalize()
            GC.Collect()
            GC.WaitForPendingFinalizers()
            GC.Collect()
            GC.WaitForPendingFinalizers()
        End Try
    End Sub

#End Region
#Region "FORM EVENTS"

	Private Sub TFSWScreenForDevice_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
		txtSN.Text = _device_sn
		lblInfo.Text = IIf(_mode = Mode.ByBox, _box_nr, "")
        EnableCheckboxes()
        If Not _bSoftwareScreenInBilling Then
            SetDestinationLabel()
        End If
	End Sub

#End Region
#Region "CONTROL EVENTS"

	Private Sub cbRedDot_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbRedDot.Enter
		cbRedDot.BackColor = _focusColor
	End Sub
	Private Sub cbScreenable_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbScreenable.Enter
		cbScreenable.BackColor = _focusColor
	End Sub
	Private Sub cbFPIssue_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbFPIssue.Enter
		cbFPIssue.BackColor = _focusColor
	End Sub
	Private Sub cbPINLocked_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbPINLocked.Enter
		cbPINLocked.BackColor = _focusColor
	End Sub
	Private Sub cbKSEnabled_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbKSEnabled.Enter
		cbKSEnabled.BackColor = _focusColor
	End Sub
	Private Sub cbRemoved_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbRemoved.Enter
		cbRemoved.BackColor = _focusColor
	End Sub
	Private Sub cbRedDot_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbRedDot.Leave
		cbRedDot.BackColor = _defaultColor
	End Sub
	Private Sub cbScreenable_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbScreenable.Leave
		cbScreenable.BackColor = _defaultColor
	End Sub
	Private Sub cbFPIssue_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbFPIssue.Leave
		cbFPIssue.BackColor = _defaultColor
	End Sub
	Private Sub cbPINLocked_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbPINLocked.Leave
		cbPINLocked.BackColor = _defaultColor
	End Sub
	Private Sub cbKSEnabled_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbKSEnabled.Leave
		cbKSEnabled.BackColor = _defaultColor
	End Sub
	Private Sub cbRemoved_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbRemoved.Leave
		cbRemoved.BackColor = _defaultColor
	End Sub
	Private Sub cbRedDot_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbRedDot.CheckedChanged
		EnableCheckboxes()
		SetDestinationLabel()
	End Sub
	Private Sub cbScreenable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbScreenable.CheckedChanged
		ClearRelatedCheckBoxes()
		EnableCheckboxes()
		SetDestinationLabel()
	End Sub
	Private Sub cbFPIssue_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbFPIssue.CheckedChanged
		ClearRelatedCheckBoxes()
		EnableCheckboxes()
		SetDestinationLabel()
	End Sub
	Private Sub cbPINLocked_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPINLocked.CheckedChanged
		EnableCheckboxes()
		SetDestinationLabel()
	End Sub
	Private Sub cbKSEnabled_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbKSEnabled.CheckedChanged
		ClearRelatedCheckBoxes()
		EnableCheckboxes()
		SetDestinationLabel()
	End Sub
	Private Sub cbRemoved_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbRemoved.CheckedChanged
		EnableCheckboxes()
		SetDestinationLabel()
	End Sub
	Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
		Dim _dlgr As New DialogResult()
		Dim _msg As String = "Cancel the processing of this device?"
		_dlgr = MessageBox.Show(_msg, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
		Me.Close()
	End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Me._bSoftwareScreenInBilling Then
            Try
                If SaveRecord_InBillingScreen() Then
                    Me.Close()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, Me.Text & ": btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            Dim _dlgr As New DialogResult()
            Dim _msg As String = "Continue to Save this record to " & _newWSText & "?"
            _dlgr = MessageBox.Show(_msg, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If _dlgr = DialogResult.Yes Then
                Try
                    If SaveRecord() Then
                        Me.Close()
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
    End Sub

#End Region
#Region "PROPERTIES"

    Private ReadOnly Property RedDotEnabled() As Boolean
        Get
            Return pnlData.Visible
        End Get
    End Property
    Private ReadOnly Property ScreenableEnabled() As Boolean
        Get
            Return pnlData.Visible
        End Get
    End Property
    Private ReadOnly Property FPIssueEnabled() As Boolean
        Get
            Return pnlData.Visible AndAlso cbScreenable.Checked
        End Get
    End Property
    Private ReadOnly Property PINLockedEnabled() As Boolean
        Get
            Return pnlData.Visible AndAlso cbScreenable.Checked AndAlso cbFPIssue.Checked = False
        End Get
    End Property
    Private ReadOnly Property KSEnabledEnabled() As Boolean
        Get
            Return pnlData.Visible AndAlso cbScreenable.Checked AndAlso cbFPIssue.Checked = False
        End Get
    End Property
    Private ReadOnly Property RemovedEnabled() As Boolean
        Get
            Return pnlData.Visible AndAlso cbScreenable.Checked AndAlso cbFPIssue.Checked = False AndAlso cbKSEnabled.Checked
        End Get
    End Property

#End Region
#Region "METHODS"

    Private Sub GetDeviceCurWS()
        Dim _dt As New DataTable()
        ' Dim objTFMisc As New Data.Buisness.TracFone.clsMisc()
        _dt = clsMisc.GetDeviceWS(_device_id)
        If _dt.Rows.Count = 0 Then
            MessageBox.Show("Device was not found.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        Else
            _device_id = _dt.Rows(0)("device_id")
            _currentWS = _dt.Rows(0)("workstation")
            _Model_ID = _dt.Rows(0)("model_id")
            '_bIsBuffable = objTFMisc.IsBuffable(_Model_ID)
            GetAnswersForDevice(_device_id)
        End If
    End Sub
    Private Sub SetDestinationLabel()

        If _bSoftwareScreenInBilling Then
            lblDestination.Text = ""
            lblDestination.Visible = False
            Exit Sub
        End If

        If (cbScreenable.Checked) Then
            If (cbFPIssue.Checked) Then
                _newWS = "SW FAIL"
                _newWSText = "SOFTWARE FAIL"
            ElseIf (cbKSEnabled.Checked AndAlso cbRemoved.Checked) Then
                _newWS = "PRE-BUFF"
                'If Me._bIsBuffable Then 'let us handle buffable when box is lcose
                '    _newWS = "PRE-BUFF"
                'Else
                '    _newWS = "WH-WIP"
                'End If
                _newWSText = "RECEIVING BOX"
            ElseIf (cbKSEnabled.Checked AndAlso cbRemoved.Checked = False) Then
                _newWS = "SW FAIL"
                _newWSText = "SOFTWARE FAIL"
            ElseIf (cbKSEnabled.Checked = False) Then
                _newWS = "PRE-BUFF"
                'If Me._bIsBuffable Then
                '    _newWS = "PRE-BUFF"
                'Else
                '    _newWS = "WH-WIP"
                'End If
                _newWSText = "RECEIVING BOX"
            Else
                _newWS = "PRE-BUFF"
                'If Me._bIsBuffable Then
                '    _newWS = "PRE-BUFF"
                'Else
                '    _newWS = "WH-WIP"
                'End If
                _newWSText = "RECEIVING BOX"
            End If
        Else
            _newWS = "PRE-BUFF"
            'If Me._bIsBuffable Then
            '    _newWS = "PRE-BUFF"
            'Else
            '    _newWS = "WH-WIP"
            'End If
            _newWSText = "RECEIVING BOX"
        End If

        lblDestination.Text = "DESTINATION: " & _newWSText
        ' Debug.Write(_Model_ID)
    End Sub
    Private Sub EnableCheckboxes()
        cbRedDot.Enabled = RedDotEnabled()
        cbScreenable.Enabled = ScreenableEnabled()
        cbFPIssue.Enabled = FPIssueEnabled()
        cbPINLocked.Enabled = PINLockedEnabled()
        cbKSEnabled.Enabled = KSEnabledEnabled()
        cbRemoved.Enabled = RemovedEnabled()
    End Sub
    Private Sub ClearRelatedCheckBoxes()
        If cbScreenable.Checked = False Then
            cbFPIssue.Checked = False
            cbPINLocked.Checked = False
            cbKSEnabled.Checked = False
            cbRemoved.Checked = False
        End If
        If cbFPIssue.Checked Then
            cbPINLocked.Checked = False
            cbKSEnabled.Checked = False
            cbRemoved.Checked = False
        End If
        If cbKSEnabled.Checked = False Then
            cbRemoved.Checked = False
        End If
    End Sub


    Private Function SaveRecord() As Boolean
        ' ADD DEVICE TO tBoxDevicesInProcess.
        Dim _result As Integer
        Dim _device_sn As String = txtSN.Text
        Dim _questions As New PSS.Data.BOL.tquestionCollection(1)
        Try
            PSS.Data.Buisness.TracFone.clsMisc.RemoveSWProcessQuestionsForDevice(_device_id)
            Dim i As Integer = 1
            Dim _ctrl_tagged As Control
            'Dim _device_question As PSS.Data.Buisness.tdevice_question
            For i = 1 To 7
                For Each _ctrl_tagged In Me.pnlData.Controls
                    If TypeOf _ctrl_tagged Is Windows.Forms.CheckBox Then
                        If _ctrl_tagged.Tag = i Then
                            Dim _answer As Boolean = DirectCast(_ctrl_tagged, CheckBox).Checked
                            Dim _device_question = New PSS.Data.BOL.tdevice_question(_device_id, i, _answer, "")
                            _device_question.ApplyChanges()
                            _device_question.Dispose()
                            _device_question = Nothing
                        End If
                    End If
                Next
            Next
            PSS.Data.Buisness.TracFone.clsMisc.RemovePendingDevice(_device_sn)
            _result = PSS.Data.Buisness.TracFone.clsMisc.InsertBxDvcInProcess(_box_nr, _device_id, _device_sn, _currentWS, _newWS)
            _questions = Nothing
            Return True
        Catch ex As Exception
            MessageBox.Show("Unable to process this device." & vbCrLf & vbCrLf & ex.Message)
            Return False
        End Try
    End Function

    '*********************************************************************************************************************
    Private Function SaveRecord_InBillingScreen() As Boolean
        ' ADD DEVICE TO tBoxDevicesInProcess.
        Dim _device_sn As String = txtSN.Text
        Dim _questions As New PSS.Data.BOL.tquestionCollection(1)
        Try
            PSS.Data.Buisness.TracFone.clsMisc.RemoveSWProcessQuestionsForDevice(_device_id)
            Dim i As Integer = 1
            Dim _ctrl_tagged As Control
            'Dim _device_question As PSS.Data.Buisness.tdevice_question
            For i = 1 To 7
                For Each _ctrl_tagged In Me.pnlData.Controls
                    If TypeOf _ctrl_tagged Is Windows.Forms.CheckBox Then
                        If _ctrl_tagged.Tag = i Then
                            Dim _answer As Boolean = DirectCast(_ctrl_tagged, CheckBox).Checked
                            Dim _device_question = New PSS.Data.BOL.tdevice_question(_device_id, i, _answer, "")
                            _device_question.ApplyChanges()
                            _device_question.Dispose()
                            _device_question = Nothing
                        End If
                    End If
                Next
            Next
            PSS.Data.Buisness.TracFone.clsMisc.RemovePendingDevice(_device_sn)
            _questions = Nothing
            Return True
        Catch ex As Exception
            MessageBox.Show("Unable to process this device." & vbCrLf & vbCrLf & ex.Message)
            Return False
        End Try
    End Function

    Private Function IsSNPendingWS()
        If _snPendingWS Then
            _editModeOn = True
        End If
    End Function

    Private Function GetAnswersForDevice(ByVal device_id As Integer) As DataTable()
        Dim _SWProcessForDevice As New Data.BLL.SwProcessForDevice(_device_id)
        cbRedDot.Checked = _SWProcessForDevice.RedDot
        cbScreenable.Checked = _SWProcessForDevice.Screenable
        cbFPIssue.Checked = _SWProcessForDevice.HasFreezePowerIssue
        cbPINLocked.Checked = _SWProcessForDevice.PINLocked
        cbKSEnabled.Checked = _SWProcessForDevice.KillSwitchEnabled
        cbRemoved.Checked = _SWProcessForDevice.KillSwitchRemoved
    End Function

#End Region

End Class
