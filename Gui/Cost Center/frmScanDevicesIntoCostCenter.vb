Option Explicit On 

Imports PSS.Data.Buisness

Public Class frmScanDevicesIntoCostCenter
    Inherits System.Windows.Forms.Form

    Private _objSDTCC As ScanDeviceToCostCenter
    Private _iCC_ID As Integer = 0
    Private _iCC_GroupID As Integer = 0

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _objSDTCC = New ScanDeviceToCostCenter()

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
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblCostCenter As System.Windows.Forms.Label
    Friend WithEvents lblLineSide As System.Windows.Forms.Label
    Friend WithEvents lblMachine As System.Windows.Forms.Label
    Friend WithEvents lblGroup As System.Windows.Forms.Label
    Friend WithEvents lblLine As System.Windows.Forms.Label
    Friend WithEvents lblShift As System.Windows.Forms.Label
    Friend WithEvents lblWorkDate As System.Windows.Forms.Label
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSN As System.Windows.Forms.TextBox
    Friend WithEvents btnEnter As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblCostCenter = New System.Windows.Forms.Label()
        Me.lblLineSide = New System.Windows.Forms.Label()
        Me.lblMachine = New System.Windows.Forms.Label()
        Me.lblGroup = New System.Windows.Forms.Label()
        Me.lblLine = New System.Windows.Forms.Label()
        Me.lblShift = New System.Windows.Forms.Label()
        Me.lblWorkDate = New System.Windows.Forms.Label()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSN = New System.Windows.Forms.TextBox()
        Me.btnEnter = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblCostCenter, Me.lblLineSide, Me.lblMachine, Me.lblGroup, Me.lblLine, Me.lblShift, Me.lblWorkDate, Me.lblUserName})
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(614, 71)
        Me.Panel2.TabIndex = 88
        '
        'lblCostCenter
        '
        Me.lblCostCenter.BackColor = System.Drawing.Color.Transparent
        Me.lblCostCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostCenter.ForeColor = System.Drawing.Color.Lime
        Me.lblCostCenter.Location = New System.Drawing.Point(200, 25)
        Me.lblCostCenter.Name = "lblCostCenter"
        Me.lblCostCenter.Size = New System.Drawing.Size(178, 16)
        Me.lblCostCenter.TabIndex = 94
        Me.lblCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLineSide
        '
        Me.lblLineSide.BackColor = System.Drawing.Color.Transparent
        Me.lblLineSide.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLineSide.ForeColor = System.Drawing.Color.Lime
        Me.lblLineSide.Location = New System.Drawing.Point(29, 46)
        Me.lblLineSide.Name = "lblLineSide"
        Me.lblLineSide.Size = New System.Drawing.Size(146, 16)
        Me.lblLineSide.TabIndex = 93
        Me.lblLineSide.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMachine
        '
        Me.lblMachine.BackColor = System.Drawing.Color.Transparent
        Me.lblMachine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMachine.ForeColor = System.Drawing.Color.Lime
        Me.lblMachine.Location = New System.Drawing.Point(200, 4)
        Me.lblMachine.Name = "lblMachine"
        Me.lblMachine.Size = New System.Drawing.Size(178, 16)
        Me.lblMachine.TabIndex = 92
        Me.lblMachine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGroup
        '
        Me.lblGroup.BackColor = System.Drawing.Color.Transparent
        Me.lblGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroup.ForeColor = System.Drawing.Color.Lime
        Me.lblGroup.Location = New System.Drawing.Point(29, 4)
        Me.lblGroup.Name = "lblGroup"
        Me.lblGroup.Size = New System.Drawing.Size(146, 16)
        Me.lblGroup.TabIndex = 91
        Me.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLine
        '
        Me.lblLine.BackColor = System.Drawing.Color.Transparent
        Me.lblLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLine.ForeColor = System.Drawing.Color.Lime
        Me.lblLine.Location = New System.Drawing.Point(29, 25)
        Me.lblLine.Name = "lblLine"
        Me.lblLine.Size = New System.Drawing.Size(146, 16)
        Me.lblLine.TabIndex = 90
        Me.lblLine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblShift
        '
        Me.lblShift.BackColor = System.Drawing.Color.Transparent
        Me.lblShift.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShift.ForeColor = System.Drawing.Color.Lime
        Me.lblShift.Location = New System.Drawing.Point(402, 25)
        Me.lblShift.Name = "lblShift"
        Me.lblShift.Size = New System.Drawing.Size(178, 16)
        Me.lblShift.TabIndex = 88
        Me.lblShift.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWorkDate
        '
        Me.lblWorkDate.BackColor = System.Drawing.Color.Transparent
        Me.lblWorkDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWorkDate.ForeColor = System.Drawing.Color.Lime
        Me.lblWorkDate.Location = New System.Drawing.Point(402, 46)
        Me.lblWorkDate.Name = "lblWorkDate"
        Me.lblWorkDate.Size = New System.Drawing.Size(178, 16)
        Me.lblWorkDate.TabIndex = 84
        Me.lblWorkDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUserName
        '
        Me.lblUserName.BackColor = System.Drawing.Color.Transparent
        Me.lblUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserName.ForeColor = System.Drawing.Color.Lime
        Me.lblUserName.Location = New System.Drawing.Point(402, 4)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(178, 16)
        Me.lblUserName.TabIndex = 83
        Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(8, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 16)
        Me.Label1.TabIndex = 89
        Me.Label1.Text = "Serial Number:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSN
        '
        Me.txtSN.Location = New System.Drawing.Point(8, 96)
        Me.txtSN.Name = "txtSN"
        Me.txtSN.Size = New System.Drawing.Size(168, 20)
        Me.txtSN.TabIndex = 1
        Me.txtSN.Text = ""
        '
        'btnEnter
        '
        Me.btnEnter.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnEnter.Location = New System.Drawing.Point(192, 95)
        Me.btnEnter.Name = "btnEnter"
        Me.btnEnter.Size = New System.Drawing.Size(48, 24)
        Me.btnEnter.TabIndex = 2
        Me.btnEnter.Text = "Enter"
        '
        'frmScanDevicesIntoCostCenter
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(616, 422)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnEnter, Me.txtSN, Me.Label1, Me.Panel2})
        Me.Name = "frmScanDevicesIntoCostCenter"
        Me.Text = "Scan Devices into Cost Center"
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    '***********************************************************************
    Private Sub frmScanDevicesIntoCostCenter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer = 0

        Try
            i = CheckIfMachineTiedToLine()
            If i = 0 Then
                Throw New Exception("Machine is not associated with any 'Line'. Can't continue.")
            End If

            Me.txtSN.Focus()
        Catch ex As Exception
            MsgBox("Form_Load:: " & ex.Message.ToString, MsgBoxStyle.Critical)
        End Try
    End Sub

    '***********************************************************************
    Private Function CheckIfMachineTiedToLine() As Integer
        Dim dt1 As DataTable
        Dim R1 As DataRow
        Dim objMisc As New PSS.Data.Buisness.Misc()

        Try
            dt1 = objMisc.CheckIfMachineTiedToLine(System.Net.Dns.GetHostName)
            If dt1.Rows.Count = 0 Then
                Return 0
            End If

            If dt1.Rows.Count > 0 Then
                R1 = dt1.Rows(0)
                _iCC_GroupID = R1("CC_Group_ID")
                Me._iCC_ID = R1("cc_id")
                Me.lblCostCenter.Text = "Cost Center: " & R1("CostCenter")
                Me.lblGroup.Text = "Group: " & Trim(R1("Group_Desc"))
                Me.lblLine.Text = Trim(R1("Line_Number"))
                Me.lblLineSide.Text = Trim(R1("LineSide_Desc"))
            End If

            Me.lblMachine.Text = "Machine: " & System.Net.Dns.GetHostName
            Me.lblUserName.Text = "User: " & PSS.Core.[Global].ApplicationUser.User
            Me.lblShift.Text = "Shift: " & PSS.Core.[Global].ApplicationUser.IDShift
            Me.lblWorkDate.Text = "Work Date: " & Format(CDate(PSS.Core.[Global].ApplicationUser.Workdate), "MM/dd/yyyy")

            Return 1
        Catch ex As Exception
            Throw ex
        Finally

            R1 = Nothing
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
            objMisc = Nothing
        End Try
    End Function

    '***********************************************************************
    Private Sub btnEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnter.Click
        Me.ProcessSN()
    End Sub

    '***********************************************************************
    Private Sub txtSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp
        If e.KeyValue = 13 Then
            Me.ProcessSN()
        End If
    End Sub

    '***********************************************************************
    Private Sub ProcessSN()
        Dim i As Integer = 0

        Try
            If Me.txtSN.Text = "" Then
                Exit Sub
            Else
                i = _objSDTCC.TransferDeviceIntoCostCenter(Me._iCC_ID, Me._iCC_GroupID, Me.txtSN.Text.Trim.ToUpper)
                If i > 0 Then
                    MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtSN.Text = ""
                    Me.txtSN.Focus()
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            Me.txtSN.SelectAll()
            Me.txtSN.Focus()
        End Try
    End Sub

    '***********************************************************************

End Class
