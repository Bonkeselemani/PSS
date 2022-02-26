Option Explicit On 

Imports PSS.Data.Buisness
Imports PSS.Core.Global

Public Class frmHTCReports
    Inherits System.Windows.Forms.Form

    Private _objHTC As HTC

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _objHTC = New HTC()
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If

            _objHTC = Nothing
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cboGroups As PSS.Gui.Controls.ComboBox
    Friend WithEvents txtDailyGoal As System.Windows.Forms.TextBox
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboStations As PSS.Gui.Controls.ComboBox
    Friend WithEvents lblGroups As System.Windows.Forms.Label
    Friend WithEvents lblDailyGoal As System.Windows.Forms.Label
    Friend WithEvents chkIncludeWeekend As System.Windows.Forms.CheckBox
    Friend WithEvents lblStations As System.Windows.Forms.Label
    Friend WithEvents btnUPHCals As System.Windows.Forms.Button
    Friend WithEvents btnScrapCount As System.Windows.Forms.Button
    Friend WithEvents btnWip As System.Windows.Forms.Button
    Friend WithEvents btnRecShipByRMARpt As System.Windows.Forms.Button
    Friend WithEvents btnShipDetailByIMEIRpt As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cboStations = New PSS.Gui.Controls.ComboBox()
        Me.lblStations = New System.Windows.Forms.Label()
        Me.chkIncludeWeekend = New System.Windows.Forms.CheckBox()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.cboGroups = New PSS.Gui.Controls.ComboBox()
        Me.lblGroups = New System.Windows.Forms.Label()
        Me.txtDailyGoal = New System.Windows.Forms.TextBox()
        Me.lblDailyGoal = New System.Windows.Forms.Label()
        Me.btnUPHCals = New System.Windows.Forms.Button()
        Me.btnScrapCount = New System.Windows.Forms.Button()
        Me.btnWip = New System.Windows.Forms.Button()
        Me.btnShipDetailByIMEIRpt = New System.Windows.Forms.Button()
        Me.btnRecShipByRMARpt = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboStations, Me.lblStations, Me.chkIncludeWeekend, Me.lblEndDate, Me.dtpStartDate, Me.lblStartDate, Me.dtpEndDate, Me.cboGroups, Me.lblGroups, Me.txtDailyGoal, Me.lblDailyGoal})
        Me.Panel1.Location = New System.Drawing.Point(1, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(519, 94)
        Me.Panel1.TabIndex = 1
        '
        'cboStations
        '
        Me.cboStations.AutoComplete = True
        Me.cboStations.BackColor = System.Drawing.SystemColors.Window
        Me.cboStations.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboStations.ForeColor = System.Drawing.Color.Black
        Me.cboStations.Location = New System.Drawing.Point(312, 35)
        Me.cboStations.Name = "cboStations"
        Me.cboStations.Size = New System.Drawing.Size(184, 21)
        Me.cboStations.TabIndex = 5
        '
        'lblStations
        '
        Me.lblStations.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStations.ForeColor = System.Drawing.Color.Lime
        Me.lblStations.Location = New System.Drawing.Point(248, 37)
        Me.lblStations.Name = "lblStations"
        Me.lblStations.Size = New System.Drawing.Size(64, 16)
        Me.lblStations.TabIndex = 107
        Me.lblStations.Text = "Station:"
        Me.lblStations.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkIncludeWeekend
        '
        Me.chkIncludeWeekend.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIncludeWeekend.ForeColor = System.Drawing.Color.Lime
        Me.chkIncludeWeekend.Location = New System.Drawing.Point(64, 64)
        Me.chkIncludeWeekend.Name = "chkIncludeWeekend"
        Me.chkIncludeWeekend.Size = New System.Drawing.Size(152, 16)
        Me.chkIncludeWeekend.TabIndex = 3
        Me.chkIncludeWeekend.Text = "Include Weekend"
        '
        'lblEndDate
        '
        Me.lblEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEndDate.ForeColor = System.Drawing.Color.Lime
        Me.lblEndDate.Location = New System.Drawing.Point(0, 40)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(64, 16)
        Me.lblEndDate.TabIndex = 104
        Me.lblEndDate.Text = "End Date"
        Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpStartDate
        '
        Me.dtpStartDate.CustomFormat = "MM/dd/yyyy"
        Me.dtpStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDate.Location = New System.Drawing.Point(64, 6)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(152, 20)
        Me.dtpStartDate.TabIndex = 1
        '
        'lblStartDate
        '
        Me.lblStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStartDate.ForeColor = System.Drawing.Color.Lime
        Me.lblStartDate.Location = New System.Drawing.Point(0, 8)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(64, 16)
        Me.lblStartDate.TabIndex = 103
        Me.lblStartDate.Text = "Start Date"
        Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "MM/dd/yyyy"
        Me.dtpEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDate.Location = New System.Drawing.Point(64, 35)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(152, 20)
        Me.dtpEndDate.TabIndex = 2
        Me.dtpEndDate.Value = New Date(2007, 8, 8, 0, 0, 0, 0)
        '
        'cboGroups
        '
        Me.cboGroups.AutoComplete = True
        Me.cboGroups.BackColor = System.Drawing.SystemColors.Window
        Me.cboGroups.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGroups.ForeColor = System.Drawing.Color.Black
        Me.cboGroups.Location = New System.Drawing.Point(312, 6)
        Me.cboGroups.Name = "cboGroups"
        Me.cboGroups.Size = New System.Drawing.Size(184, 21)
        Me.cboGroups.TabIndex = 4
        '
        'lblGroups
        '
        Me.lblGroups.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroups.ForeColor = System.Drawing.Color.Lime
        Me.lblGroups.Location = New System.Drawing.Point(248, 8)
        Me.lblGroups.Name = "lblGroups"
        Me.lblGroups.Size = New System.Drawing.Size(64, 16)
        Me.lblGroups.TabIndex = 100
        Me.lblGroups.Text = "Group:"
        Me.lblGroups.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDailyGoal
        '
        Me.txtDailyGoal.Location = New System.Drawing.Point(312, 64)
        Me.txtDailyGoal.Name = "txtDailyGoal"
        Me.txtDailyGoal.Size = New System.Drawing.Size(55, 20)
        Me.txtDailyGoal.TabIndex = 6
        Me.txtDailyGoal.Text = ""
        '
        'lblDailyGoal
        '
        Me.lblDailyGoal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDailyGoal.ForeColor = System.Drawing.Color.Lime
        Me.lblDailyGoal.Location = New System.Drawing.Point(232, 64)
        Me.lblDailyGoal.Name = "lblDailyGoal"
        Me.lblDailyGoal.Size = New System.Drawing.Size(80, 16)
        Me.lblDailyGoal.TabIndex = 98
        Me.lblDailyGoal.Text = "Daily Goal:"
        Me.lblDailyGoal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnUPHCals
        '
        Me.btnUPHCals.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnUPHCals.Location = New System.Drawing.Point(8, 104)
        Me.btnUPHCals.Name = "btnUPHCals"
        Me.btnUPHCals.Size = New System.Drawing.Size(208, 48)
        Me.btnUPHCals.TabIndex = 2
        Me.btnUPHCals.Text = "UPH Calculation"
        '
        'btnScrapCount
        '
        Me.btnScrapCount.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnScrapCount.Location = New System.Drawing.Point(8, 168)
        Me.btnScrapCount.Name = "btnScrapCount"
        Me.btnScrapCount.Size = New System.Drawing.Size(208, 48)
        Me.btnScrapCount.TabIndex = 3
        Me.btnScrapCount.Text = "Scrap Count"
        '
        'btnWip
        '
        Me.btnWip.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnWip.Location = New System.Drawing.Point(8, 232)
        Me.btnWip.Name = "btnWip"
        Me.btnWip.Size = New System.Drawing.Size(208, 48)
        Me.btnWip.TabIndex = 4
        Me.btnWip.Text = "WIP (Copy data to Clipboard)"
        '
        'btnShipDetailByIMEIRpt
        '
        Me.btnShipDetailByIMEIRpt.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnShipDetailByIMEIRpt.Location = New System.Drawing.Point(8, 296)
        Me.btnShipDetailByIMEIRpt.Name = "btnShipDetailByIMEIRpt"
        Me.btnShipDetailByIMEIRpt.Size = New System.Drawing.Size(208, 48)
        Me.btnShipDetailByIMEIRpt.TabIndex = 5
        Me.btnShipDetailByIMEIRpt.Text = "Ship Detail by IMEI"
        '
        'btnRecShipByRMARpt
        '
        Me.btnRecShipByRMARpt.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnRecShipByRMARpt.Location = New System.Drawing.Point(248, 104)
        Me.btnRecShipByRMARpt.Name = "btnRecShipByRMARpt"
        Me.btnRecShipByRMARpt.Size = New System.Drawing.Size(208, 48)
        Me.btnRecShipByRMARpt.TabIndex = 6
        Me.btnRecShipByRMARpt.Text = "Receiving && Shipping by RMA Report"
        '
        'frmHTCReports
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(528, 365)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRecShipByRMARpt, Me.btnShipDetailByIMEIRpt, Me.btnWip, Me.btnScrapCount, Me.btnUPHCals, Me.Panel1})
        Me.Name = "frmHTCReports"
        Me.Text = "HTC Reports"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    Private Sub frmHTCReports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.dtpStartDate.Value = Now
            Me.dtpEndDate.Value = Now
            Me.txtDailyGoal.Text = 3.5
            Me.LoadMasterGroups()
            Me.LoadProdStations()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "frmHTCReports_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '******************************************************************
    Private Sub LoadMasterGroups()
        Dim dt As DataTable
        Try
            dt = Me._objHTC.GetHTCGroups(True)
            With Me.cboGroups
                .DataSource = Nothing
                .DataSource = dt.DefaultView
                .DisplayMember = dt.Columns("Group_Desc").ToString
                .ValueMember = dt.Columns("Group_ID").ToString
                If dt.Rows.Count = 2 Then .SelectedValue = dt.Rows(0)("Group_ID") Else .SelectedValue = 0
            End With
        Catch ex As Exception
            Throw ex
        Finally
            Generic.DisposeDT(dt)
        End Try
    End Sub

    '******************************************************************
    Private Sub LoadProdStations()
        Dim dt As DataTable

        Try
            dt = Me._objHTC.GetProdStation(True)
            With Me.cboStations
                .DataSource = dt.DefaultView
                .DisplayMember = dt.Columns("Test_Desc2").ToString
                .ValueMember = dt.Columns("Test_ID").ToString
                .SelectedValue = 7
            End With

        Catch ex As Exception
            Throw ex
        Finally
            Generic.DisposeDT(dt)
        End Try
    End Sub

    '******************************************************************
    Private Sub txtDailyGoal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDailyGoal.KeyPress
        Try
            If Not Char.IsDigit(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtDailyGoal_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '******************************************************************
    Private Sub btnUPHCals_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUPHCals.Click
        Dim iDailyGoal As Integer = 0

        Try
            If Me.dtpEndDate.Value < Me.dtpStartDate.Value Then
                MsgBox("'Start Date' can't be before 'End Date'.", MsgBoxStyle.Information, "UPHCals")
            ElseIf Me.cboGroups.SelectedValue = 0 Then
                MsgBox("Please select group.", MsgBoxStyle.Information, "UPHCals")
            ElseIf Me.cboStations.SelectedValue = 0 Then
                MsgBox("Please select workstation.", MsgBoxStyle.Information, "UPHCals")
            ElseIf Me.txtDailyGoal.Text.Trim.Length = 0 Then
                MsgBox("Please enter UPH daily goal.", MsgBoxStyle.Information, "UPHCals")
            End If

            iDailyGoal = Me.txtDailyGoal.Text

            Me.Enabled = False
            Me._objHTC.CreateRef_Incentive_Rpt(Me.dtpStartDate.Value, Me.dtpEndDate.Value, Me.cboGroups.SelectedValue, Me.cboStations.SelectedValue, Me.txtDailyGoal.Text, )

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnUPHCals_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Enabled = True
        End Try
    End Sub

    '******************************************************************
    Private Sub btnScrapCount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScrapCount.Click
        Try
            If Me.dtpEndDate.Value < Me.dtpStartDate.Value Then
                MsgBox("'Start Date' can't be before 'End Date'.", MsgBoxStyle.Information, "Scrap Count")
                Exit Sub
            End If

            Me.Enabled = False
            Me._objHTC.CreateScrapCntByEE_Rpt(Me.dtpStartDate.Value, Me.dtpEndDate.Value, Me.cboGroups.SelectedValue)

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnScrapCount_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Enabled = True
        End Try
    End Sub

    '******************************************************************
    Private Sub btnWip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWip.Click
        Try
            Me.Enabled = False
            Me._objHTC.CopyWipReportDataToClipboard()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnWip_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Enabled = True
        End Try
    End Sub

    '******************************************************************
    Private Sub btnShipDetailByIMEIRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShipDetailByIMEIRpt.Click
        Try
            If Me.dtpEndDate.Value < Me.dtpStartDate.Value Then
                MsgBox("'Start Date' can't be before 'End Date'.", MsgBoxStyle.Information, "Intransit Ship")
            ElseIf Me.cboGroups.SelectedValue = 0 Then
                MsgBox("Please select group.", MsgBoxStyle.Information, "Intransit Ship")
            Else
                Me.Enabled = False
                Me._objHTC.CreateInTransitShipRpt(Me.dtpStartDate.Value, Me.dtpEndDate.Value)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnIntransitShipDetailRpt_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Enabled = True
        End Try
    End Sub

    '******************************************************************
    Private Sub btnRecShipByRMARpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecShipByRMARpt.Click
        Try
            Me.Enabled = False
            Me._objHTC.RecevingAndShippingByRMARpt()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnRecShipByRMARpt_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Enabled = True
        End Try
    End Sub

    '******************************************************************

End Class
