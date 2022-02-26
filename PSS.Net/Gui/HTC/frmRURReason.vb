Option Explicit On 

Imports PSS.Rules
Imports PSS.Core.Global

Public Class frmRURReason
    Inherits System.Windows.Forms.Form

    Public _booCancel As Boolean = False
    Public _iFailID As Integer = 0
    Public _iRepairID As Integer = 0

    Private _iDeviceID As Integer = 0
    Private _iModelID As Integer = 0
    Private _strStation As String = ""
    Private _objHTC As PSS.Data.Buisness.HTC
    Private _booReclaimParts As Boolean = False

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal iDeviceID As Integer, _
                   ByVal strStation As String, _
                   ByVal iModelID As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me._iDeviceID = iDeviceID
        Me._strStation = strStation
        Me._iModelID = iModelID
        Me._objHTC = New PSS.Data.Buisness.HTC()

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If

            If Not IsNothing(Me._objHTC) Then
                Me._objHTC = Nothing
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chklstRUR_Reasons As System.Windows.Forms.CheckedListBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.chklstRUR_Reasons = New System.Windows.Forms.CheckedListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(80, 208)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(104, 24)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        '
        'chklstRUR_Reasons
        '
        Me.chklstRUR_Reasons.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left)
        Me.chklstRUR_Reasons.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chklstRUR_Reasons.Location = New System.Drawing.Point(16, 24)
        Me.chklstRUR_Reasons.Name = "chklstRUR_Reasons"
        Me.chklstRUR_Reasons.Size = New System.Drawing.Size(240, 169)
        Me.chklstRUR_Reasons.TabIndex = 122
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(16, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 16)
        Me.Label1.TabIndex = 123
        Me.Label1.Text = "RUR Reasons"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'frmRURReason
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Teal
        Me.ClientSize = New System.Drawing.Size(274, 239)
        Me.ControlBox = False
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.chklstRUR_Reasons, Me.btnCancel})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmRURReason"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "RUR Reason"
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    Private Sub frmRURReason_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dtRepStatus As DataTable
        Dim R1 As DataRow
        Dim objDevice As Device
        Dim i As Integer = 0

        Try
            PSS.Core.Highlight.SetHighLight(Me)

            If Me._iDeviceID = 0 Then
                MessageBox.Show("Can't define device ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me._booCancel = True
                Me.Close()
            ElseIf Me._iModelID = 0 Then
                MessageBox.Show("Can't define Model ID. Please scan unit again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me._booCancel = True
                Me.Close()
            ElseIf IsNothing(Me._objHTC.HTC_RUR_TYPE_INFO) Then
                MessageBox.Show("The mapping of RUR type is missing. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me._booCancel = True
                Me.Close()
            ElseIf Me._objHTC.HTC_RUR_TYPE_INFO.Rows.Count = 0 Then
                MessageBox.Show("The mapping of RUR type is missing. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me._booCancel = True
                Me.Close()
            End If

            dtRepStatus = Me._objHTC.CheckDeviceRepairStatus(Me._iDeviceID)

            If dtRepStatus.Rows.Count > 0 Then
                If dtRepStatus.Rows(0)("BillCode_Rule") > 0 Then
                    MessageBox.Show("This is an " & dtRepStatus.Rows(0)("BillCodeRule_Desc") & " unit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me._booCancel = True
                    Me.Close()
                ElseIf dtRepStatus.Rows(0)("BillCode_Rule") = 0 And dtRepStatus.Rows(0)("BillType_ID") = 2 Then
                    'unit has parts bill to it
                    _booReclaimParts = True
                Else
                    'Only Services. Remove all services
                    objDevice = New Device(Me._iDeviceID)
                    For Each R1 In dtRepStatus.Rows
                        If R1("BillType_ID") = 1 Then
                            '******************
                            'Delete service
                            '******************
                            objDevice.DeletePart(R1("Billcode_ID"))
                            '***************************
                            'Keep delete repair history
                            '***************************
                            i = Me._objHTC.RemoveRepairRecordByUnbill(Me._iDeviceID, R1("Billcode_ID"), ApplicationUser.IDuser, Me._strStation, , , )
                            '***************************
                        End If
                    Next R1

                    '******************
                    'Update Labor
                    '******************
                    objDevice.Update()
                    '******************
                End If
            End If

            Me.PopulateRUROption()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "FormLoad", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dtRepStatus)
            R1 = Nothing
        End Try
    End Sub

    '******************************************************************
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me._booCancel = True
        Me.Close()
    End Sub

    '******************************************************************
    Private Sub PopulateRUROption()
        Dim dt As DataTable
        Try
            dt = Me._objHTC.GetRURResonOption()

            With Me.chklstRUR_Reasons
                .DataSource = dt.DefaultView
                .DisplayMember = "Dcode_L2desc"
                .ValueMember = "Dcode_ID"
            End With

        Catch ex As Exception
            Throw ex
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
        End Try
    End Sub

    '******************************************************************
    Private Sub chklstRUR_Reasons_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles chklstRUR_Reasons.ItemCheck
        Dim objDevice As Device = Nothing
        Dim i As Integer = 0
        Dim strNextWrkStation As String = ""

        Try
            If e.NewValue = CheckState.Checked Then
                If MessageBox.Show("Are you sure you want to RUR (" & Me.chklstRUR_Reasons.SelectedItem("Dcode_L2desc") & ") this unit?.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    e.NewValue = CheckState.Unchecked
                    Exit Sub
                Else
                    '******************************
                    'validate dcode of rur type
                    '******************************
                    If Me._objHTC.HTC_RUR_TYPE_INFO.Select("Dcode_ID = " & Me.chklstRUR_Reasons.SelectedItem("Dcode_ID")).Length = 0 Then
                        MessageBox.Show("The mapping of RUR type is missing. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me._booCancel = True
                        Me.Close()
                    End If
                    '******************************

                    If Me._booReclaimParts = False Then
                        '******************
                        '1: bill RUR
                        '******************
                        If PSS.Data.Buisness.Generic.IsBillcodeMapped(Me._iModelID, Me._objHTC.HTC_RUR_BILLCODEID) = 1 Then
                            objDevice = New Device(Me._iDeviceID)
                            objDevice.FailID = Me._iFailID
                            objDevice.RepairID = Me._iRepairID
                            objDevice.AddPart(Me._objHTC.HTC_RUR_BILLCODEID)
                            objDevice.Update()
                        Else
                            MessageBox.Show("RUR billcode was not mapped or existed more than one in the system for this model. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Me._booCancel = True
                            Me.Close()
                        End If
                    End If

                    '*****************************************************
                    '2: write faicode and repair code to thtcrepair table
                    '*****************************************************
                    i = Me._objHTC.InsertFailCodeRepCode_ToRepairTable(0, Me._iDeviceID, _
                                     Me._objHTC.HTC_RUR_TYPE_INFO.Select("Dcode_id = " & Me.chklstRUR_Reasons.SelectedItem("Dcode_ID"))(0)("MC_ID"), _
                                     Me.chklstRUR_Reasons.SelectedItem("Fail_ID"), _
                                     Me.chklstRUR_Reasons.SelectedItem("Repair_ID"), _
                                     Core.ApplicationUser.IDuser, _
                                     Me._strStation, 1, 0, Me._objHTC.HTC_RUR_BILLCODEID, _
                                     Me._objHTC.HTC_RUR_TYPE_INFO.Select("Dcode_id = " & Me.chklstRUR_Reasons.SelectedItem("Dcode_ID"))(0)("PSPrice_ID"), _
                                     Me._objHTC.HTC_RUR_TYPE_INFO.Select("Dcode_id = " & Me.chklstRUR_Reasons.SelectedItem("Dcode_ID"))(0)("Part_Number"), , )
                    Me._iFailID = Me.chklstRUR_Reasons.SelectedItem("Fail_ID")
                    Me._iRepairID = Me.chklstRUR_Reasons.SelectedItem("Repair_ID")
                    If i = 0 Then
                        MessageBox.Show("System failed to record Failcode and Repaircode. Please contact your supervisor.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me._booCancel = True
                        Me.Close()
                    End If

                    '***********************************
                    '3: write rur reason to tdevicecode
                    '***********************************
                    i = Me._objHTC.InsertRURFailCodeToTdevicecodes(Me._iDeviceID, Me.chklstRUR_Reasons.SelectedItem("Dcode_ID"))
                    If i = 0 Then
                        MessageBox.Show("System failed to record RUR reason. Please contact your supervisor.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me._booCancel = True
                        Me.Close()
                    End If

                    '*********************************************
                    '4: push utit to packaging or RECLAIM-PARTS
                    '*********************************************
                    If Me._booReclaimParts = False Then
                        strNextWrkStation = PSS.Data.Buisness.Generic.GetNextWorkStationInWFP(Me._strStation, Me._iModelID, Me._objHTC.HTC_CUSTOMER_ID, 1)
                    Else
                        strNextWrkStation = "RECLAIM PARTS"
                    End If

                    If strNextWrkStation.Trim.Length = 0 Then
                        MessageBox.Show("Can not find the next workstation of current " & Me._strStation.ToUpper & " station.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        i = Me._objHTC.PushUnitToNextWorkingStation(Me._iDeviceID, strNextWrkStation)
                        If i > 0 Then
                            MessageBox.Show("Device has moved to " & strNextWrkStation & " workstation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("System failed to push the device to " & strNextWrkStation & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me._booCancel = True
                            Me.Close()
                        End If
                    End If
                    '*********************************************

                    Me.Close()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "FormLoad", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************

End Class
