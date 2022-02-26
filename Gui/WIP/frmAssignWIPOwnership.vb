Imports CrystalDecisions.CrystalReports.Engine

Public Class frmAssignWIPOwnership
    Inherits System.Windows.Forms.Form

    Private objMisc As PSS.Data.Buisness.Misc
    Private objInventory As PSS.Data.Buisness.Inventory
    Private strWorkDate As String = PSS.Core.[Global].ApplicationUser.Workdate
    Private iWO_or_PalletID_Flag As Integer = 0    '1:WO, 2:PalletID
    Private iPallet_ID As Integer = 0
    Private strShipPalletName As String = ""
    Private iShipPalletCount As Integer = 0
    Private iWO_ID As Integer = 0
    Private iFlag As Integer = 0       '1: Triage->Prod, 2: Prod->Prod, 3: Prod->AQL or AQL->AQL-Hold
    Private iNewGroup_ID As Integer = 0         'new group owner
    Private strNewOwner As String = ""
    Private iDeviceStatus As Integer = 0
    Private iAssignedGroup_ID As Integer = 0    'originally assigned in tworkorder table
    Private strAssignedOwner As String = ""     'origanal group
    Private iCurrentOwner As Integer = 0        'tcellopt.cellopt_WIPOwner
    Private strCurrentOwner As String = ""
    Private iReadyToTransferCount As Integer = 0
    Private itransferredCount As Integer = 0
    Private iHoldCount As Integer = 0
    Private iRcvdPalletCount As Integer = 0
    Private iShowSumm As Integer = 0
    'System.Net.Dns.GetHostName

    'Partial Pallet
    Private iWHPalletID As Integer = 0
    Private strRevPalletName As String = ""
    Private iOwnershipOf As Integer = 1         'selected by default(full); 2:partial
    '--------------
    Private Shared ctl As Control
    Private Shared HighLightColor As Color = Color.Yellow
    Private Shared WindowColor As Color = Color.White
    Private Shared EnterHandler As New EventHandler(AddressOf Enter_Event)
    Private Shared LeaveHandler As New EventHandler(AddressOf Leave_Event)


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        objMisc = New PSS.Data.Buisness.Misc()
        objInventory = New PSS.Data.Buisness.Inventory()
        Me.objMisc.WorkDt = strWorkDate

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
    Friend WithEvents cmdTakeOwnership As System.Windows.Forms.Button
    Friend WithEvents cmbNewOwner As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblIMEI As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnlOwnershipOf As System.Windows.Forms.Panel
    Friend WithEvents cmdReset As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents lstIMEIs As System.Windows.Forms.ListBox
    Friend WithEvents lblScannedQty As System.Windows.Forms.Label
    Friend WithEvents rbtnSomeDev As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnFull As System.Windows.Forms.RadioButton
    Friend WithEvents pnelSomeDev As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblPallet As System.Windows.Forms.Label
    Friend WithEvents pnlPallet As System.Windows.Forms.Panel
    Friend WithEvents lblHoldQty As System.Windows.Forms.Label
    Friend WithEvents lblCurrentOwner As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtIMEItoGetPallet As System.Windows.Forms.TextBox
    Friend WithEvents txtIMEI As System.Windows.Forms.TextBox
    Friend WithEvents lblReadyToTrans As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents lblWeeklySummary As System.Windows.Forms.Label
    Friend WithEvents lblDailySummary As System.Windows.Forms.Label
    Friend WithEvents lblLabelTotal As System.Windows.Forms.Label
    Friend WithEvents lblLabelTransferred As System.Windows.Forms.Label
    Friend WithEvents lblTransferred As System.Windows.Forms.Label
    Friend WithEvents lblLabelTrans As System.Windows.Forms.Label
    Friend WithEvents lblLabelHold As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblIMEI = New System.Windows.Forms.Label()
        Me.txtIMEItoGetPallet = New System.Windows.Forms.TextBox()
        Me.cmdTakeOwnership = New System.Windows.Forms.Button()
        Me.cmbNewOwner = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlOwnershipOf = New System.Windows.Forms.Panel()
        Me.rbtnSomeDev = New System.Windows.Forms.RadioButton()
        Me.rbtnFull = New System.Windows.Forms.RadioButton()
        Me.pnelSomeDev = New System.Windows.Forms.Panel()
        Me.cmdClearAll = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtIMEI = New System.Windows.Forms.TextBox()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.lstIMEIs = New System.Windows.Forms.ListBox()
        Me.lblScannedQty = New System.Windows.Forms.Label()
        Me.cmdReset = New System.Windows.Forms.Button()
        Me.pnlPallet = New System.Windows.Forms.Panel()
        Me.lblLabelTotal = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblLabelTransferred = New System.Windows.Forms.Label()
        Me.lblTransferred = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblLabelTrans = New System.Windows.Forms.Label()
        Me.lblLabelHold = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblPallet = New System.Windows.Forms.Label()
        Me.lblReadyToTrans = New System.Windows.Forms.Label()
        Me.lblHoldQty = New System.Windows.Forms.Label()
        Me.lblCurrentOwner = New System.Windows.Forms.Label()
        Me.lblWeeklySummary = New System.Windows.Forms.Label()
        Me.lblDailySummary = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.pnlOwnershipOf.SuspendLayout()
        Me.pnelSomeDev.SuspendLayout()
        Me.pnlPallet.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblIMEI
        '
        Me.lblIMEI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIMEI.Location = New System.Drawing.Point(12, 39)
        Me.lblIMEI.Name = "lblIMEI"
        Me.lblIMEI.Size = New System.Drawing.Size(160, 16)
        Me.lblIMEI.TabIndex = 0
        Me.lblIMEI.Text = "Scan IMEI to get Pallet:"
        Me.lblIMEI.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtIMEItoGetPallet
        '
        Me.txtIMEItoGetPallet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIMEItoGetPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIMEItoGetPallet.Location = New System.Drawing.Point(175, 36)
        Me.txtIMEItoGetPallet.Name = "txtIMEItoGetPallet"
        Me.txtIMEItoGetPallet.Size = New System.Drawing.Size(153, 22)
        Me.txtIMEItoGetPallet.TabIndex = 2
        Me.txtIMEItoGetPallet.Text = ""
        '
        'cmdTakeOwnership
        '
        Me.cmdTakeOwnership.BackColor = System.Drawing.Color.Silver
        Me.cmdTakeOwnership.Enabled = False
        Me.cmdTakeOwnership.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdTakeOwnership.ForeColor = System.Drawing.Color.Blue
        Me.cmdTakeOwnership.Location = New System.Drawing.Point(568, 76)
        Me.cmdTakeOwnership.Name = "cmdTakeOwnership"
        Me.cmdTakeOwnership.Size = New System.Drawing.Size(178, 54)
        Me.cmdTakeOwnership.TabIndex = 6
        Me.cmdTakeOwnership.Text = "ASSIGN OWNERSHIP"
        '
        'cmbNewOwner
        '
        Me.cmbNewOwner.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbNewOwner.Location = New System.Drawing.Point(130, 7)
        Me.cmbNewOwner.Name = "cmbNewOwner"
        Me.cmbNewOwner.Size = New System.Drawing.Size(200, 24)
        Me.cmbNewOwner.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Black
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Yellow
        Me.Label1.Location = New System.Drawing.Point(2, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(389, 70)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "WIP OWNERSHIP"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblIMEI, Me.txtIMEItoGetPallet, Me.cmbNewOwner, Me.Label3})
        Me.Panel2.Location = New System.Drawing.Point(393, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(352, 70)
        Me.Panel2.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(42, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 24)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "New Owner :"
        '
        'pnlOwnershipOf
        '
        Me.pnlOwnershipOf.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlOwnershipOf.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlOwnershipOf.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbtnSomeDev, Me.rbtnFull})
        Me.pnlOwnershipOf.Location = New System.Drawing.Point(393, 75)
        Me.pnlOwnershipOf.Name = "pnlOwnershipOf"
        Me.pnlOwnershipOf.Size = New System.Drawing.Size(172, 54)
        Me.pnlOwnershipOf.TabIndex = 1
        '
        'rbtnSomeDev
        '
        Me.rbtnSomeDev.Enabled = False
        Me.rbtnSomeDev.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnSomeDev.Location = New System.Drawing.Point(12, 26)
        Me.rbtnSomeDev.Name = "rbtnSomeDev"
        Me.rbtnSomeDev.Size = New System.Drawing.Size(148, 24)
        Me.rbtnSomeDev.TabIndex = 1
        Me.rbtnSomeDev.Text = "Devices on Hold"
        '
        'rbtnFull
        '
        Me.rbtnFull.Checked = True
        Me.rbtnFull.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnFull.Location = New System.Drawing.Point(12, 4)
        Me.rbtnFull.Name = "rbtnFull"
        Me.rbtnFull.Size = New System.Drawing.Size(148, 24)
        Me.rbtnFull.TabIndex = 0
        Me.rbtnFull.TabStop = True
        Me.rbtnFull.Text = "Full Pallet"
        '
        'pnelSomeDev
        '
        Me.pnelSomeDev.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnelSomeDev.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnelSomeDev.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdClearAll, Me.Label5, Me.txtIMEI, Me.cmdClear, Me.lstIMEIs, Me.lblScannedQty})
        Me.pnelSomeDev.Location = New System.Drawing.Point(393, 131)
        Me.pnelSomeDev.Name = "pnelSomeDev"
        Me.pnelSomeDev.Size = New System.Drawing.Size(352, 405)
        Me.pnelSomeDev.TabIndex = 3
        Me.pnelSomeDev.Visible = False
        '
        'cmdClearAll
        '
        Me.cmdClearAll.BackColor = System.Drawing.Color.Silver
        Me.cmdClearAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClearAll.Location = New System.Drawing.Point(224, 208)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(112, 32)
        Me.cmdClearAll.TabIndex = 24
        Me.cmdClearAll.Text = "CLEAR ALL"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(22, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(208, 16)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Scan IMEIs on Hold to transfer:  "
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtIMEI
        '
        Me.txtIMEI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIMEI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIMEI.Location = New System.Drawing.Point(23, 31)
        Me.txtIMEI.Name = "txtIMEI"
        Me.txtIMEI.Size = New System.Drawing.Size(174, 22)
        Me.txtIMEI.TabIndex = 23
        Me.txtIMEI.Text = ""
        '
        'cmdClear
        '
        Me.cmdClear.BackColor = System.Drawing.Color.Silver
        Me.cmdClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.Location = New System.Drawing.Point(224, 160)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(112, 32)
        Me.cmdClear.TabIndex = 3
        Me.cmdClear.Text = "CLEAR ONE"
        '
        'lstIMEIs
        '
        Me.lstIMEIs.Location = New System.Drawing.Point(23, 56)
        Me.lstIMEIs.Name = "lstIMEIs"
        Me.lstIMEIs.Size = New System.Drawing.Size(174, 303)
        Me.lstIMEIs.TabIndex = 2
        '
        'lblScannedQty
        '
        Me.lblScannedQty.BackColor = System.Drawing.Color.Black
        Me.lblScannedQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblScannedQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScannedQty.ForeColor = System.Drawing.Color.Lime
        Me.lblScannedQty.Location = New System.Drawing.Point(233, 64)
        Me.lblScannedQty.Name = "lblScannedQty"
        Me.lblScannedQty.Size = New System.Drawing.Size(88, 64)
        Me.lblScannedQty.TabIndex = 20
        Me.lblScannedQty.Text = "0"
        Me.lblScannedQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdReset
        '
        Me.cmdReset.BackColor = System.Drawing.Color.Silver
        Me.cmdReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReset.Location = New System.Drawing.Point(776, 16)
        Me.cmdReset.Name = "cmdReset"
        Me.cmdReset.Size = New System.Drawing.Size(88, 48)
        Me.cmdReset.TabIndex = 21
        Me.cmdReset.Text = "RESET SCREEN"
        '
        'pnlPallet
        '
        Me.pnlPallet.BackColor = System.Drawing.Color.Black
        Me.pnlPallet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlPallet.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblLabelTotal, Me.lblTotal, Me.lblLabelTransferred, Me.lblTransferred, Me.Label8, Me.lblLabelTrans, Me.lblLabelHold, Me.Label11, Me.lblPallet, Me.lblReadyToTrans, Me.lblHoldQty, Me.lblCurrentOwner})
        Me.pnlPallet.Location = New System.Drawing.Point(2, 75)
        Me.pnlPallet.Name = "pnlPallet"
        Me.pnlPallet.Size = New System.Drawing.Size(389, 166)
        Me.pnlPallet.TabIndex = 22
        '
        'lblLabelTotal
        '
        Me.lblLabelTotal.BackColor = System.Drawing.Color.Black
        Me.lblLabelTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLabelTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabelTotal.ForeColor = System.Drawing.Color.Lime
        Me.lblLabelTotal.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblLabelTotal.Location = New System.Drawing.Point(80, 58)
        Me.lblLabelTotal.Name = "lblLabelTotal"
        Me.lblLabelTotal.Size = New System.Drawing.Size(72, 20)
        Me.lblLabelTotal.TabIndex = 30
        Me.lblLabelTotal.Text = "Total:"
        Me.lblLabelTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.Color.Black
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.Lime
        Me.lblTotal.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblTotal.Location = New System.Drawing.Point(166, 58)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(80, 20)
        Me.lblTotal.TabIndex = 29
        Me.lblTotal.Text = "0"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLabelTransferred
        '
        Me.lblLabelTransferred.BackColor = System.Drawing.Color.Black
        Me.lblLabelTransferred.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLabelTransferred.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabelTransferred.ForeColor = System.Drawing.Color.Lime
        Me.lblLabelTransferred.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblLabelTransferred.Location = New System.Drawing.Point(16, 108)
        Me.lblLabelTransferred.Name = "lblLabelTransferred"
        Me.lblLabelTransferred.Size = New System.Drawing.Size(136, 20)
        Me.lblLabelTransferred.TabIndex = 28
        Me.lblLabelTransferred.Text = "Transferred:"
        Me.lblLabelTransferred.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTransferred
        '
        Me.lblTransferred.BackColor = System.Drawing.Color.Black
        Me.lblTransferred.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTransferred.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransferred.ForeColor = System.Drawing.Color.Lime
        Me.lblTransferred.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblTransferred.Location = New System.Drawing.Point(166, 108)
        Me.lblTransferred.Name = "lblTransferred"
        Me.lblTransferred.Size = New System.Drawing.Size(80, 20)
        Me.lblTransferred.TabIndex = 27
        Me.lblTransferred.Text = "0"
        Me.lblTransferred.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Black
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Lime
        Me.Label8.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label8.Location = New System.Drawing.Point(72, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 20)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Pallet:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLabelTrans
        '
        Me.lblLabelTrans.BackColor = System.Drawing.Color.Black
        Me.lblLabelTrans.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLabelTrans.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabelTrans.ForeColor = System.Drawing.Color.Lime
        Me.lblLabelTrans.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblLabelTrans.Location = New System.Drawing.Point(1, 83)
        Me.lblLabelTrans.Name = "lblLabelTrans"
        Me.lblLabelTrans.Size = New System.Drawing.Size(152, 20)
        Me.lblLabelTrans.TabIndex = 24
        Me.lblLabelTrans.Text = "Ready to Transfer:"
        Me.lblLabelTrans.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLabelHold
        '
        Me.lblLabelHold.BackColor = System.Drawing.Color.Black
        Me.lblLabelHold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLabelHold.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabelHold.ForeColor = System.Drawing.Color.Lime
        Me.lblLabelHold.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblLabelHold.Location = New System.Drawing.Point(64, 133)
        Me.lblLabelHold.Name = "lblLabelHold"
        Me.lblLabelHold.Size = New System.Drawing.Size(88, 20)
        Me.lblLabelHold.TabIndex = 26
        Me.lblLabelHold.Text = "On-Hold:"
        Me.lblLabelHold.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Black
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Lime
        Me.Label11.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label11.Location = New System.Drawing.Point(17, 33)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(136, 20)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "Current Owner:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPallet
        '
        Me.lblPallet.BackColor = System.Drawing.Color.Black
        Me.lblPallet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPallet.ForeColor = System.Drawing.Color.Lime
        Me.lblPallet.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblPallet.Location = New System.Drawing.Point(165, 8)
        Me.lblPallet.Name = "lblPallet"
        Me.lblPallet.Size = New System.Drawing.Size(194, 20)
        Me.lblPallet.TabIndex = 16
        Me.lblPallet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblReadyToTrans
        '
        Me.lblReadyToTrans.BackColor = System.Drawing.Color.Black
        Me.lblReadyToTrans.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblReadyToTrans.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReadyToTrans.ForeColor = System.Drawing.Color.Lime
        Me.lblReadyToTrans.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblReadyToTrans.Location = New System.Drawing.Point(166, 83)
        Me.lblReadyToTrans.Name = "lblReadyToTrans"
        Me.lblReadyToTrans.Size = New System.Drawing.Size(80, 20)
        Me.lblReadyToTrans.TabIndex = 17
        Me.lblReadyToTrans.Text = "0"
        Me.lblReadyToTrans.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblHoldQty
        '
        Me.lblHoldQty.BackColor = System.Drawing.Color.Black
        Me.lblHoldQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHoldQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHoldQty.ForeColor = System.Drawing.Color.Lime
        Me.lblHoldQty.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblHoldQty.Location = New System.Drawing.Point(166, 133)
        Me.lblHoldQty.Name = "lblHoldQty"
        Me.lblHoldQty.Size = New System.Drawing.Size(80, 20)
        Me.lblHoldQty.TabIndex = 22
        Me.lblHoldQty.Text = "0"
        Me.lblHoldQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCurrentOwner
        '
        Me.lblCurrentOwner.BackColor = System.Drawing.Color.Black
        Me.lblCurrentOwner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCurrentOwner.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentOwner.ForeColor = System.Drawing.Color.Lime
        Me.lblCurrentOwner.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCurrentOwner.Location = New System.Drawing.Point(166, 33)
        Me.lblCurrentOwner.Name = "lblCurrentOwner"
        Me.lblCurrentOwner.Size = New System.Drawing.Size(160, 20)
        Me.lblCurrentOwner.TabIndex = 19
        Me.lblCurrentOwner.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWeeklySummary
        '
        Me.lblWeeklySummary.BackColor = System.Drawing.Color.Black
        Me.lblWeeklySummary.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblWeeklySummary.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWeeklySummary.ForeColor = System.Drawing.Color.Lime
        Me.lblWeeklySummary.Location = New System.Drawing.Point(198, 243)
        Me.lblWeeklySummary.Name = "lblWeeklySummary"
        Me.lblWeeklySummary.Size = New System.Drawing.Size(193, 293)
        Me.lblWeeklySummary.TabIndex = 23
        '
        'lblDailySummary
        '
        Me.lblDailySummary.BackColor = System.Drawing.Color.Black
        Me.lblDailySummary.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDailySummary.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDailySummary.ForeColor = System.Drawing.Color.Lime
        Me.lblDailySummary.Location = New System.Drawing.Point(2, 243)
        Me.lblDailySummary.Name = "lblDailySummary"
        Me.lblDailySummary.Size = New System.Drawing.Size(194, 293)
        Me.lblDailySummary.TabIndex = 24
        '
        'frmAssignWIPOwnership
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(920, 676)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblDailySummary, Me.lblWeeklySummary, Me.pnlPallet, Me.pnelSomeDev, Me.pnlOwnershipOf, Me.Panel2, Me.Label1, Me.cmdTakeOwnership, Me.cmdReset})
        Me.Name = "frmAssignWIPOwnership"
        Me.Text = "WIP OWNERSHIP"
        Me.Panel2.ResumeLayout(False)
        Me.pnlOwnershipOf.ResumeLayout(False)
        Me.pnelSomeDev.ResumeLayout(False)
        Me.pnlPallet.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    '*********************************** LAN *******************************
    Private Shared Sub SetHandler(ByVal ctl As Control)
        AddHandler ctl.Enter, EnterHandler
        AddHandler ctl.Leave, LeaveHandler
        AddHandler ctl.Click, EnterHandler
    End Sub

    '******************************************************************************
    Private Shared Sub Enter_Event(ByVal sender As Object, ByVal e As EventArgs)
        Change_Color(sender, HighLightColor)
    End Sub

    '******************************************************************************
    Private Shared Sub Leave_Event(ByVal sender As Object, ByVal e As EventArgs)
        Change_Color(sender, WindowColor)
    End Sub

    '******************************************************************************
    Private Shared Sub Change_Color(ByVal sender As Object, ByVal color As Color)
        Dim Type As String = sender.GetType.Name.ToString

        Select Case Type
            Case "ComboBox"
                CType(sender, ComboBox).BackColor = color
            Case "TextBox"
                CType(sender, TextBox).BackColor = color
            Case Else
                'no other types should be hightlighted.

        End Select
    End Sub

    '******************************** lan *************************************
    Private Sub frmTakeWIPOwnership_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim dt1 As DataTable
        Dim i As Integer = 0
        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        'Handlers to highlight in custom colors
        SetHandler(Me.cmbNewOwner)
        SetHandler(Me.txtIMEI)
        SetHandler(Me.txtIMEItoGetPallet)

        Try
            '*******************************************
            Me.GetGroupInfoWithMachineName()
            'Load WIP Transfer Summary
            If iShowSumm = 1 Then
                'Daily Summary
                Me.lblDailySummary.Text = objMisc.LoadWIPTransferSummary(Format(Now(), "yyyy-MM-dd"))
                'Weekly Summary
                Me.lblWeeklySummary.Text = objMisc.LoadWIPTransferSummary()
            Else
                Me.lblWeeklySummary.Text = ""
            End If
            '*******************************************
            dt1 = objInventory.GetGroups(1)
            Me.cmbNewOwner.DataSource = dt1.DefaultView
            Me.cmbNewOwner.ValueMember = dt1.Columns("Group_ID").ToString
            Me.cmbNewOwner.DisplayMember = dt1.Columns("Group").ToString
            Me.cmbNewOwner.SelectedValue = 0
            '*******************************************
        Catch ex As Exception
            MessageBox.Show("frmTakeWIPOwnership_load." & ex.Message.ToString, "Display New Owner", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try

        Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub
    '*******************************************************************
    Private Sub GetGroupInfoWithMachineName()
        Dim dt1 As DataTable
        Dim R1 As DataRow
        Dim iGroup_ID As Integer = 0

        Try
            dt1 = objMisc.CheckIfMachineTiedToLine(System.Net.Dns.GetHostName)
            If dt1.Rows.Count > 0 Then
                R1 = dt1.Rows(0)
                If R1("Group_ID") = 5 Then
                    iShowSumm = 1
                End If
            Else
                iShowSumm = 0
            End If

        Catch ex As Exception
            Throw ex
        Finally
            R1 = Nothing
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try
    End Sub


    '**************************** lan *********************************
    Private Function GetDeviceInfo(ByVal strIMEISN As String) As Boolean
        'Dim strReturnValue As String = ""
        Dim blResult As Boolean = False

        If Trim(strIMEISN) = "" Then
            Me.txtIMEI.Focus()

        ElseIf iNewGroup_ID > 0 Then
            Try
                '-------------------
                blResult = objMisc.GetPalletInfoBySN(Trim(strIMEISN), _
                    iNewGroup_ID, _
                    strNewOwner, _
                    iPallet_ID, _
                    strShipPalletName, _
                    iShipPalletCount, _
                    iWO_ID, _
                    iCurrentOwner, _
                    strCurrentOwner, _
                    iAssignedGroup_ID, _
                    strAssignedOwner, _
                    iWHPalletID, _
                    strRevPalletName, _
                    iRcvdPalletCount, _
                    itransferredCount, _
                    iReadyToTransferCount, _
                    iHoldCount, _
                    iDeviceStatus)

                If Not blResult Then
                    ClearControls()
                    Me.cmbNewOwner.SelectedValue = 0
                    Me.txtIMEItoGetPallet.Text = ""
                    Return False
                End If

                'iRcvdPalletCount = objMisc.GetRcvdPalletCount(strPalletName)

                Me.lblCurrentOwner.Text = strCurrentOwner
                If iPallet_ID > 0 Then
                    Me.lblPallet.Text = strShipPalletName
                    Me.lblTotal.Text = iShipPalletCount
                    Me.lblLabelTransferred.Visible = False
                    Me.lblLabelHold.Visible = False
                    Me.lblLabelTrans.Visible = False
                    Me.lblTransferred.Visible = False   '& "/" & iRcvdPalletCount
                    Me.lblHoldQty.Visible = False    '& "/" & iRcvdPalletCount
                    Me.lblReadyToTrans.Visible = False   '& "/" & iRcvdPalletCount
                Else
                    Me.lblPallet.Text = strRevPalletName
                    Me.lblTotal.Text = iRcvdPalletCount
                    Me.lblLabelTransferred.Visible = True
                    Me.lblLabelHold.Visible = True
                    Me.lblLabelTrans.Visible = True
                    Me.lblTransferred.Text = itransferredCount '& "/" & iRcvdPalletCount
                    Me.lblHoldQty.Text = iHoldCount '& "/" & iRcvdPalletCount
                    Me.lblReadyToTrans.Text = iReadyToTransferCount '& "/" & iRcvdPalletCount
                    Me.lblTransferred.Visible = True
                    Me.lblHoldQty.Visible = True
                    Me.lblReadyToTrans.Visible = True
                End If

            Catch ex As Exception
                Me.ClearControls()
                Me.cmbNewOwner.SelectedValue = 0
                Me.txtIMEItoGetPallet.Text = ""
                Me.cmbNewOwner.Focus()
                'MessageBox.Show("frmTakeWIPOwnership.GetDeviceInfo." & ex.Message.ToString, "New Owner Relation", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Throw New Exception(ex.ToString)
            End Try
        Else
            Me.ClearControls()
            Me.cmbNewOwner.SelectedValue = 0
            Me.txtIMEItoGetPallet.Text = ""
            Me.cmbNewOwner.Focus()
            'MessageBox.Show("Select New Owner from the list.", "Select New Owner", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Throw New Exception("Select New Owner from the list.")
        End If
        Return True
    End Function


    '**************************** lan *********************************
    Private Sub txtIMEItoGetPallet_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIMEItoGetPallet.KeyUp

        Dim blnResutl As Boolean = True

        If e.KeyValue = 13 Then
            Try

                If Trim(txtIMEItoGetPallet.Text) = "" Then
                    Exit Sub
                End If

                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

                blnResutl = Me.GetDeviceInfo(Trim(txtIMEItoGetPallet.Text))
                If Not blnResutl Then
                    Exit Sub
                End If

                '-----------------------------------------------------
                'define iWO_or_PalletID_Flag: 1:WO, 2:ShipPalletID
                If iCurrentOwner = 5 And (iNewGroup_ID = 2 Or iNewGroup_ID = 3 Or iNewGroup_ID = 4) And iPallet_ID = 0 Then
                    iWO_or_PalletID_Flag = 1
                ElseIf iCurrentOwner = 2 And (iNewGroup_ID = 3 Or iNewGroup_ID = 4) And iPallet_ID = 0 Then
                    iWO_or_PalletID_Flag = 1
                ElseIf iCurrentOwner = 3 And (iNewGroup_ID = 2 Or iNewGroup_ID = 4) And iPallet_ID = 0 Then
                    iWO_or_PalletID_Flag = 1
                ElseIf iCurrentOwner = 4 And (iNewGroup_ID = 2 Or iNewGroup_ID = 3) And iPallet_ID = 0 Then
                    iWO_or_PalletID_Flag = 1
                ElseIf iCurrentOwner = 2 And (iNewGroup_ID = 6 Or iNewGroup_ID = 9) And iPallet_ID > 0 Then
                    iWO_or_PalletID_Flag = 2
                ElseIf iCurrentOwner = 3 And (iNewGroup_ID = 6 Or iNewGroup_ID = 10) And iPallet_ID > 0 Then
                    iWO_or_PalletID_Flag = 2
                ElseIf iCurrentOwner = 4 And (iNewGroup_ID = 6) And iPallet_ID > 0 Then
                    iWO_or_PalletID_Flag = 2
                ElseIf iCurrentOwner = 6 And _
                      (iNewGroup_ID = 2 Or iNewGroup_ID = 3 Or iNewGroup_ID = 4 Or iNewGroup_ID = 9 Or iNewGroup_ID = 10) And _
                       iPallet_ID > 0 Then
                    iWO_or_PalletID_Flag = 2
                ElseIf iCurrentOwner = 9 And (iNewGroup_ID = 6 Or iNewGroup_ID = 2) And iPallet_ID > 0 Then
                    iWO_or_PalletID_Flag = 2
                ElseIf iCurrentOwner = 10 And (iNewGroup_ID = 6 Or iNewGroup_ID = 3) And iPallet_ID > 0 Then
                    iWO_or_PalletID_Flag = 2
                ElseIf (((iCurrentOwner = 2 Or iCurrentOwner = 3 Or iCurrentOwner = 4) And iNewGroup_ID = 6) _
                             Or (iCurrentOwner = 6 And (iNewGroup_ID = 2 Or iNewGroup_ID = 3 Or iNewGroup_ID = 4 Or iNewGroup_ID = 9 Or iNewGroup_ID = 10)) _
                             Or (iCurrentOwner = 9 And (iNewGroup_ID = 6 Or iNewGroup_ID = 2)) _
                             Or (iCurrentOwner = 10 And (iNewGroup_ID = 6 Or iNewGroup_ID = 3))) _
                             And iPallet_ID = 0 Then

                    MessageBox.Show("A shipping pallet must exist before transfer from " & strCurrentOwner & " to " & strNewOwner & ".", "Current-Owner and New-Owner relation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.ClearControls()
                    Me.cmbNewOwner.SelectedValue = 0
                    Me.txtIMEItoGetPallet.Text = ""
                    Me.cmbNewOwner.Focus()
                    Exit Sub
                ElseIf ((iCurrentOwner = 2 And iNewGroup_ID = 3) _
                      Or (iCurrentOwner = 3 And iNewGroup_ID = 2)) _
                    And iPallet_ID > 0 Then
                    MessageBox.Show("A shipping pallet has been created by " & strCurrentOwner & ". Can not give ownership to " & strNewOwner & ".", "Current-Owner and New-Owner relation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.ClearControls()
                    Me.cmbNewOwner.SelectedValue = 0
                    Me.txtIMEItoGetPallet.Text = ""
                    Me.cmbNewOwner.Focus()
                    Exit Sub
                ElseIf (iCurrentOwner = 5 And (iNewGroup_ID = 2 Or iNewGroup_ID = 3 Or iNewGroup_ID = 4)) _
                         And iPallet_ID > 0 Then
                    MessageBox.Show("Transfer from " & strCurrentOwner & " to " & strNewOwner & " is not permited because this device belongs to a shipping pallet.", "Current-Owner and New-Owner relation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.ClearControls()
                    Me.cmbNewOwner.SelectedValue = 0
                    Me.txtIMEItoGetPallet.Text = ""
                    Me.cmbNewOwner.Focus()
                    Exit Sub
                Else
                    MessageBox.Show(strCurrentOwner & " to " & strNewOwner & " is not permitted.", "Current-Owner and New-Owner relation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.ClearControls()
                    Me.cmbNewOwner.SelectedValue = 0
                    Me.txtIMEItoGetPallet.Text = ""
                    Me.cmbNewOwner.Focus()
                    Exit Sub
                End If
                '-----------------------------------------------------

                If iCurrentOwner = 5 And iDeviceStatus = 0 Then

                    If itransferredCount = 0 And iReadyToTransferCount > 0 Then
                        Throw New Exception("Before transferring devices on 'HOLD', it is important to transfer devices that have been 'Ready for Transfer'.")
                    End If
                    If (iAssignedGroup_ID <> iNewGroup_ID) And itransferredCount > 0 Then
                        Throw New Exception("Part of this Pallet has already been given to " & strAssignedOwner & ". Can not give it to " & strNewOwner & ".")
                    End If


                    Me.rbtnFull.Enabled = False
                    Me.rbtnSomeDev.Enabled = True
                    Me.rbtnSomeDev.Checked = True
                    Me.txtIMEItoGetPallet.Text = ""
                    Me.txtIMEI.Focus()
                Else
                    Me.cmdTakeOwnership.Enabled = True
                    Me.rbtnSomeDev.Enabled = False
                    Me.rbtnFull.Enabled = True
                    Me.rbtnFull.Checked = True
                    Me.txtIMEItoGetPallet.SelectAll()
                End If
                txtIMEItoGetPallet.Text = ""
                Me.cmdTakeOwnership.Focus()
            Catch ex As Exception
                Me.ClearControls()
                Me.cmbNewOwner.SelectedValue = 0
                Me.txtIMEItoGetPallet.Text = ""
                Me.cmbNewOwner.Focus()
                MessageBox.Show(ex.ToString, "Get Device Info", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Cursor.Current = System.Windows.Forms.Cursors.Default
            End Try

        End If
    End Sub

    '**************************** lan *********************************
    Private Sub txtIMEI_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIMEI.KeyUp
        Try
            If e.KeyValue = 13 Then
                If Trim(txtIMEI.Text) = "" Then
                    Exit Sub
                End If
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
                AddDeviceToList(Trim(txtIMEI.Text))
                Cursor.Current = System.Windows.Forms.Cursors.Default
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Add IMEI to List", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*********************************** lan ***************************
    Private Sub AddDeviceToList(ByVal strIMEI As String)
        Dim j As Integer = 0
        Try

            'Check for duplicates in the list box
            If Me.lstIMEIs.Items.Count > 0 Then
                For j = 0 To Me.lstIMEIs.Items.Count - 1
                    If Trim(Me.txtIMEI.Text) = Me.lstIMEIs.Items.Item(j) Then
                        Me.txtIMEI.Text = ""
                        Me.txtIMEI.Focus()
                        Exit Sub
                    End If
                Next
            End If

            j = objMisc.CheckDeviceBelongToPallet(strIMEI, iWHPalletID)

            If j > 0 Then
                Me.lstIMEIs.Items.Add(strIMEI)
                Me.lblScannedQty.Text = Me.lstIMEIs.Items.Count
                Me.txtIMEI.Text = ""
                Me.txtIMEI.Focus()
                Me.cmdTakeOwnership.Enabled = True
            Else
                Throw New Exception("Device does not exist on the pallet with HOLD status.")
            End If

        Catch ex As Exception
            'MessageBox.Show(ex.ToString, "IMEI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Throw ex
        End Try
    End Sub


    '*********************************** lan ***************************
    Private Sub cmdTakeOwnership_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdTakeOwnership.Click

        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        Dim iUpdateResult As Integer = 0

        If MessageBox.Show("Are you sure you want to assign ownership?", "WIP Ownership", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.No Then
            ClearControls()
            Me.cmbNewOwner.SelectedValue = 0
            Me.txtIMEItoGetPallet.Text = ""
            Me.cmbNewOwner.Focus()
            Exit Sub
        End If

        '--------------validation : Current Owner -> New Owner
        If Not Validation() Then
            ClearControls()
            Me.cmbNewOwner.SelectedValue = 0
            Me.txtIMEItoGetPallet.Text = ""
            Me.cmbNewOwner.Focus()
            Exit Sub
        End If
        '--------------------


        Try
            Me.cmdTakeOwnership.Enabled = False

            If Me.rbtnFull.Checked = True Then

                'iPallet_ID, iAssignedGroup_ID, iNewGroup_ID, iWHPalletID, strRevPalletName
                iUpdateResult = objMisc.AssignOwnershipOfFull(iWO_or_PalletID_Flag, _
                                                              iCurrentOwner, _
                                                              iNewGroup_ID, _
                                                              iPallet_ID, _
                                                              iWHPalletID, _
                                                              strRevPalletName)

            ElseIf Me.rbtnSomeDev.Checked = True Then
                iUpdateResult = objMisc.AssignOwnershipOf_OnHoldDev(iWO_or_PalletID_Flag, _
                                                                    Me.lstIMEIs, _
                                                                    iCurrentOwner, _
                                                                    strCurrentOwner, _
                                                                    iNewGroup_ID, _
                                                                    strNewOwner, _
                                                                    iWHPalletID, _
                                                                    strRevPalletName)

            End If

            'If (iUpdateResult = dtWHR.Rows.Count) Then
            If iUpdateResult > 0 Then
                Dim iTrans As Integer = 0

                'Load WIP Transfer Summary
                If iShowSumm = 1 Then
                    'Daily Summary
                    Me.lblDailySummary.Text = objMisc.LoadWIPTransferSummary(Format(Now(), "yyyy-MM-dd"))
                    'Weekly Summary
                    Me.lblWeeklySummary.Text = objMisc.LoadWIPTransferSummary()
                Else
                    Me.lblWeeklySummary.Text = ""
                End If

                If iCurrentOwner = 5 And (iNewGroup_ID = 2 Or iNewGroup_ID = 3 Or iNewGroup_ID = 4) And iOwnershipOf = 1 Then
                    iTrans = iReadyToTransferCount
                ElseIf iCurrentOwner = 5 And (iNewGroup_ID = 2 Or iNewGroup_ID = 3 Or iNewGroup_ID = 4) And iOwnershipOf = 2 Then
                    iTrans = Me.lstIMEIs.Items.Count()

                ElseIf iCurrentOwner = 2 And (iNewGroup_ID = 3 Or iNewGroup_ID = 4) And iOwnershipOf = 1 Then
                    iTrans = iRcvdPalletCount
                ElseIf iCurrentOwner = 3 And (iNewGroup_ID = 2 Or iNewGroup_ID = 4) And iOwnershipOf = 1 Then
                    iTrans = iRcvdPalletCount
                ElseIf iCurrentOwner = 4 And (iNewGroup_ID = 2 Or iNewGroup_ID = 3) And iOwnershipOf = 1 Then
                    iTrans = iRcvdPalletCount

                ElseIf iCurrentOwner = 2 And (iNewGroup_ID = 6 Or iNewGroup_ID = 9) And iOwnershipOf = 1 Then
                    iTrans = iShipPalletCount
                ElseIf iCurrentOwner = 3 And (iNewGroup_ID = 6 Or iNewGroup_ID = 10) And iOwnershipOf = 1 Then
                    iTrans = iShipPalletCount
                ElseIf iCurrentOwner = 4 And (iNewGroup_ID = 6) And iOwnershipOf = 1 Then
                    iTrans = iShipPalletCount
                ElseIf iCurrentOwner = 6 And _
                      (iNewGroup_ID = 2 Or iNewGroup_ID = 3 Or iNewGroup_ID = 4 Or iNewGroup_ID = 9 Or iNewGroup_ID = 10) And _
                       iOwnershipOf = 1 Then
                    iTrans = iShipPalletCount
                ElseIf iCurrentOwner = 9 And (iNewGroup_ID = 6 Or iNewGroup_ID = 2) And iOwnershipOf = 1 Then
                    iTrans = iShipPalletCount
                ElseIf iCurrentOwner = 10 And (iNewGroup_ID = 6 Or iNewGroup_ID = 3) And iOwnershipOf = 1 Then
                    iTrans = iShipPalletCount
                End If

                MessageBox.Show(iTrans & " device(s) have been transfered to " & strNewOwner & ".", "WIP Ownership", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                'Dim rptApp As New CRAXDRT.Application()
                'Dim rpt As CRAXDRT.Report = rptApp.OpenReport(PSS.Core.Global.ReportPath & "WIP_Transfer_Count_New.rpt")
                Dim objRpt As ReportDocument
                Dim strQty As String = ""
                Dim iTotal As Integer = 0
                Dim i As Integer = 0

                objRpt = New ReportDocument()

                With objRpt
                    .Load(PSS.Core.[Global].ReportPath & "WIP_Transfer_Count_New.rpt")

                    If iWO_or_PalletID_Flag = 1 Then
                        .SetParameterValue("Pallet_Name", strRevPalletName)
                        iTotal = iRcvdPalletCount
                    Else
                        .SetParameterValue("Pallet_Name", strShipPalletName)
                        iTotal = iShipPalletCount
                    End If

                    strQty = iTrans & " of " & iTotal

                    .SetParameterValue("Quantity", strQty)
                    .SetParameterValue("Owner", strNewOwner)

                    .PrintToPrinter(3, True, 0, 0)
                End With

                'If iWO_or_PalletID_Flag = 1 Then
                '    rpt.ParameterFields.GetItemByName("Pallet_Name").AddCurrentValue(strRevPalletName)
                '    iTotal = iRcvdPalletCount
                'Else
                '    rpt.ParameterFields.GetItemByName("Pallet_Name").AddCurrentValue(strShipPalletName)
                '    iTotal = iShipPalletCount
                'End If

                'strQty = iTrans & " of " & iTotal

                'rpt.ParameterFields.GetItemByName("Quantity").AddCurrentValue(strQty)
                'rpt.ParameterFields.GetItemByName("Owner").AddCurrentValue(strNewOwner)
                ''rpt.PrintOut(False, 2)
                'For i = 0 To 2
                '    rpt.PrintOut(False, 1)
                'Next i
                'rpt = Nothing
            End If

        Catch ex As Exception
            MessageBox.Show("frmTakeOwnership.cmdTakeOwnership_click." & ex.Message.ToString, "Take Ownership", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            ClearControls()
            Me.cmbNewOwner.SelectedValue = 0
            Me.txtIMEItoGetPallet.Text = ""
            Me.cmbNewOwner.Focus()

            Cursor.Current = System.Windows.Forms.Cursors.Default
        End Try

    End Sub


    '*************************** lan ***********************************
    Private Function Validation() As Boolean

        Try

            If iCurrentOwner = 0 Then
                MessageBox.Show("Cannot find current WIPOwner.", "WIP Ownership", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return False
            ElseIf iCurrentOwner > 0 Then
                Select Case iCurrentOwner
                    Case 2  'cell 1 -> AQL, CELL 1 AQL-HOLD, CELL 2
                        If iNewGroup_ID = 3 And iHoldCount > 0 Then
                            MessageBox.Show("Can not transfer partial pallet from Cell 1 to Cell 2.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Return False
                        ElseIf iNewGroup_ID = 3 And iPallet_ID > 0 Then
                            MessageBox.Show("A shipping pallet already created by CELL 1. Cannot give ownership to CELL 2. Pallet must go to AQL.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Return False
                        ElseIf iNewGroup_ID = 6 Or iNewGroup_ID = 9 Or (iNewGroup_ID = 3 And iPallet_ID = 0) Then
                            Return True
                        Else
                            MessageBox.Show("The Current Owner is CELL 1 and New Owner must be CELL 2, AQL or CELLULAR 1 (AQL HOLD).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Return False
                        End If

                    Case 3                      'cell 2 -> AQL, CELL 2 AQL-HOLD, CELL 1
                        If iNewGroup_ID = 2 And iHoldCount > 0 Then
                            MessageBox.Show("Can not transfer partial pallet from Cell 2 to Cell 1.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Return False
                        ElseIf iNewGroup_ID = 2 And iPallet_ID > 0 Then
                            MessageBox.Show("A shipping pallet already created by CELL 2. Cannot give ownership to CELL 1. Pallet must go to AQL.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Return False
                        ElseIf iNewGroup_ID = 6 Or iNewGroup_ID = 10 Or (iNewGroup_ID = 2 And iPallet_ID = 0) Then
                            Return True
                        Else
                            MessageBox.Show("The Current Owner is CELL 2 and New Owner must be CELL 1, AQL or CELLULAR 2 (AQL HOLD).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Return False
                        End If

                    Case 4                      'cell 3
                        'If iGroup_ID = 6 Or iGroup_ID = 9 Then
                        '    Return True
                        'Else
                        MessageBox.Show("Can not give ownership to CELL 3.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        '    Return False
                        'End If
                        Return False

                    Case 5                      'triage -> CELL 1 OR CELL 2
                        If iNewGroup_ID = 2 Or iNewGroup_ID = 3 Then 'Or iNewGroup_ID = 4 Then
                            Return True
                        Else
                            MessageBox.Show("The Current Owner is TRIAGE and New Owner must be CELL 1 or CELL 2.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Return False
                        End If
                    Case 6                      'AQL -> CELLULAR 1 (AQL HOLD), CELLULAR 2 (AQL HOLD)
                        If (iNewGroup_ID = 9 And iAssignedGroup_ID = 2) Or _
                           (iNewGroup_ID = 10 And iAssignedGroup_ID = 3) Then
                            Return True
                        ElseIf (iNewGroup_ID = 9 And iAssignedGroup_ID = 3) Then
                            MessageBox.Show("This Pallet belongs to CELL 2. Cannot give ownership to CELLULAR 1 (AQL HOLD).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Return False
                        ElseIf (iNewGroup_ID = 10 And iAssignedGroup_ID = 2) Then
                            MessageBox.Show("This Pallet belongs to CELL 1. Cannot give ownership to CELLULAR 2 (AQL HOLD).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Return False
                        Else
                            MessageBox.Show("Current Owner is AQL and New Owner must be CELL 1 (AQL HOLD), CELL 2 (AQL HOLD).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Return False
                        End If
                    Case 7                      'Instransit
                        MessageBox.Show("Current Owner is Intransit and can not give ownership to any group.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Return False
                    Case 8                      'Warehouse
                        MessageBox.Show("Current Owner is Warehouse and can not give ownership to any group.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Return False
                    Case 9                      'CELLULAR 1 (AQL HOLD) -> AQL, CELL 1
                        If iNewGroup_ID = 6 Or iNewGroup_ID = 2 Then
                            Return True
                        Else
                            MessageBox.Show("The Current Owner is CELLULAR 1 (AQL HOLD) and New Owner must be AQL or CELL 1.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Return False
                        End If
                    Case 10                     'CELLULAR 2 (AQL HOLD)-> AQL, CELL 2
                        If iNewGroup_ID = 6 Or iNewGroup_ID = 3 Then
                            Return True
                        Else
                            MessageBox.Show("The Current Owner is CELLULAR 2 (AQL HOLD) and New Owner must be AQL or CELL 2.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Return False
                        End If
                    Case Else
                        'Return True

                End Select
            End If
        Catch ex As Exception
            MessageBox.Show("frmTakeOwnership.Validation()." & ex.Message.ToString, "Take Ownership", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try

    End Function


    '*************************** lan ***********************************
    Private Sub cmbNewOwner_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbNewOwner.SelectionChangeCommitted

        If Me.cmbNewOwner.SelectedValue > 0 Then
            ClearControls()
            Me.txtIMEItoGetPallet.Text = ""
            iNewGroup_ID = Me.cmbNewOwner.SelectedValue
            strNewOwner = Me.cmbNewOwner.Text
            Me.txtIMEItoGetPallet.Focus()
        Else
            Me.cmbNewOwner.Focus()
        End If

    End Sub

    '************************** lan ***********************************
    Private Sub ClearControls()

        Me.lblPallet.Text = ""
        Me.lblTotal.Text = "0"
        Me.lblCurrentOwner.Text = ""
        Me.lblReadyToTrans.Text = "0"
        Me.lblTransferred.Text = "0"
        Me.lblHoldQty.Text = "0"
        'Me.txtIMEItoGetPallet.Text = ""
        Me.txtIMEI.Text = ""
        Me.cmdTakeOwnership.Enabled = False
        Me.pnelSomeDev.Visible = False
        Me.lblScannedQty.Text = "0"
        Me.lstIMEIs.Items.Clear()
        Me.lstIMEIs.Refresh()
        iWO_or_PalletID_Flag = 0
        iPallet_ID = 0
        strShipPalletName = ""
        iShipPalletCount = 0
        iWO_ID = 0
        iFlag = 0        '1: Triage->Prod, 2: Prod->Prod, 3: Prod->AQL or AQL->AQL-Hold
        iNewGroup_ID = 0           'new group owner
        strNewOwner = ""
        iAssignedGroup_ID = 0      'originally assigned in tworkorder table
        strAssignedOwner = ""      'origanal group in tworkorder
        iCurrentOwner = 0          'tcellopt.cellopt_WIPOwner
        strCurrentOwner = ""
        iReadyToTransferCount = 0
        itransferredCount = 0
        iHoldCount = 0
        iRcvdPalletCount = 0
        'Partial Pallet
        iWHPalletID = 0
        strRevPalletName = ""
        iOwnershipOf = 1
        iDeviceStatus = 0
        Me.rbtnSomeDev.Enabled = False
        Me.rbtnFull.Checked = True

    End Sub

    '******************************** lan ******************************
    Protected Overrides Sub Finalize()
        objMisc = Nothing
        objInventory = Nothing
        MyBase.Finalize()
    End Sub


    '******************************* END LAN *******************************
    Private Sub rbtnFull_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnFull.CheckedChanged

        If Me.rbtnFull.Checked = True Then
            Me.pnelSomeDev.Visible = False
            Me.lstIMEIs.Items.Clear()
            Me.lstIMEIs.Refresh()
            Me.txtIMEI.Text = ""
            iOwnershipOf = 1
        End If

    End Sub


    '******************************* END LAN *******************************
    Private Sub rbtnSomeDev_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnSomeDev.CheckedChanged

        If Me.rbtnSomeDev.Checked = True Then

            Me.pnelSomeDev.Visible = True
            Me.lstIMEIs.Items.Clear()
            Me.lstIMEIs.Refresh()
            Me.txtIMEI.Text = ""
            Me.txtIMEI.Focus()
            iOwnershipOf = 2

        End If

    End Sub

    '******************************* END LAN *******************************
    Private Sub cmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReset.Click
        ClearControls()
        'Me.rbtnFull.Checked = True
        Me.cmbNewOwner.SelectedValue = 0
        Me.txtIMEItoGetPallet.Text = ""
        Me.cmbNewOwner.Focus()
    End Sub





    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        If Me.lstIMEIs.SelectedIndex <> -1 Then    'If nothing is selected
            Me.lstIMEIs.Items.RemoveAt(Me.lstIMEIs.SelectedIndex)
            Me.lstIMEIs.Refresh()
            Me.lblScannedQty.Text = lstIMEIs.Items.Count
        End If
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        If Me.lstIMEIs.Items.Count > 0 Then
            Me.lstIMEIs.Items.Clear()
            Me.lblScannedQty.Text = lstIMEIs.Items.Count
        End If
    End Sub
End Class

