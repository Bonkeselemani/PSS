Public Class frmMessReceiving
    Inherits System.Windows.Forms.Form

    Private booMessAdminSecure As Boolean = False
    Private booMessRecSecure As Boolean = False
    Private booMessLabelSecure As Boolean = False
    Private booMessShipSecure As Boolean = False

    Private Const iPanelAdminIndex As Integer = 1
    Private Const iPanelRecIndex As Integer = 2
    Private Const iPanelLabelIndex As Integer = 3
    Private Const iPanelShipIndex As Integer = 4

#Region " Windows Form Designer generated code "

    Public Sub New()
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
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblBin As System.Windows.Forms.Label
    Friend WithEvents lblLineSide As System.Windows.Forms.Label
    Friend WithEvents lblMachine As System.Windows.Forms.Label
    Friend WithEvents lblGroup As System.Windows.Forms.Label
    Friend WithEvents lblLine As System.Windows.Forms.Label
    Friend WithEvents lblShift As System.Windows.Forms.Label
    Friend WithEvents lblWorkDate As System.Windows.Forms.Label
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdDelTray As System.Windows.Forms.Button
    Friend WithEvents cmdDelWO As System.Windows.Forms.Button
    Friend WithEvents cmdDelDevfromTray As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbCustomer As PSS.Gui.Controls.ComboBox
    Friend WithEvents cmdLoadFile As System.Windows.Forms.Button
    Friend WithEvents cmdUnship As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdUpdateFreq As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateCapcode As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateSKU As System.Windows.Forms.Button
    Friend WithEvents cmdChangeSN As System.Windows.Forms.Button
    Friend WithEvents cmdLabeling As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents cmdUpdatePO As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents cmd As System.Windows.Forms.Button
    Friend WithEvents pnlLabel As System.Windows.Forms.Panel
    Friend WithEvents pnlAdmin As System.Windows.Forms.Panel
    Friend WithEvents pnlReceive As System.Windows.Forms.Panel
    Friend WithEvents pnlShip As System.Windows.Forms.Panel
    Friend WithEvents cmdShip As System.Windows.Forms.Button
    Friend WithEvents cmdAdmin As System.Windows.Forms.Button
    Friend WithEvents cmdReceive As System.Windows.Forms.Button
    Friend WithEvents panelPallet As System.Windows.Forms.Panel
    Friend WithEvents txtDevSN As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmdClosePallet As System.Windows.Forms.Button
    Friend WithEvents btnClearAll As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents lstDevices As System.Windows.Forms.ListBox
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.pnlLabel = New System.Windows.Forms.Panel()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmdLabeling = New System.Windows.Forms.Button()
        Me.cmdShip = New System.Windows.Forms.Button()
        Me.cmdAdmin = New System.Windows.Forms.Button()
        Me.cmdReceive = New System.Windows.Forms.Button()
        Me.lblGroup = New System.Windows.Forms.Label()
        Me.lblLineSide = New System.Windows.Forms.Label()
        Me.lblLine = New System.Windows.Forms.Label()
        Me.lblBin = New System.Windows.Forms.Label()
        Me.lblMachine = New System.Windows.Forms.Label()
        Me.lblShift = New System.Windows.Forms.Label()
        Me.lblWorkDate = New System.Windows.Forms.Label()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.pnlAdmin = New System.Windows.Forms.Panel()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.cmd = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.cmdUpdatePO = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.cmdDelWO = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cmdChangeSN = New System.Windows.Forms.Button()
        Me.cmdDelDevfromTray = New System.Windows.Forms.Button()
        Me.cmdDelTray = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmdUpdateSKU = New System.Windows.Forms.Button()
        Me.cmdUpdateCapcode = New System.Windows.Forms.Button()
        Me.cmdUpdateFreq = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdUnship = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdLoadFile = New System.Windows.Forms.Button()
        Me.cmbCustomer = New PSS.Gui.Controls.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlReceive = New System.Windows.Forms.Panel()
        Me.pnlShip = New System.Windows.Forms.Panel()
        Me.cmbRecCustomer = New PSS.Gui.Controls.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbRecLocation = New PSS.Gui.Controls.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbModel = New PSS.Gui.Controls.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.panelPallet = New System.Windows.Forms.Panel()
        Me.txtDevSN = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmdClosePallet = New System.Windows.Forms.Button()
        Me.btnClearAll = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.lstDevices = New System.Windows.Forms.ListBox()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New PSS.Gui.Controls.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.pnlAdmin.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlReceive.SuspendLayout()
        Me.panelPallet.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlLabel
        '
        Me.pnlLabel.BackColor = System.Drawing.Color.DarkKhaki
        Me.pnlLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlLabel.Location = New System.Drawing.Point(922, 80)
        Me.pnlLabel.Name = "pnlLabel"
        Me.pnlLabel.Size = New System.Drawing.Size(88, 24)
        Me.pnlLabel.TabIndex = 0
        Me.pnlLabel.Visible = False
        '
        'lblHeader
        '
        Me.lblHeader.BackColor = System.Drawing.Color.Black
        Me.lblHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.Yellow
        Me.lblHeader.Location = New System.Drawing.Point(-1, 0)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(209, 71)
        Me.lblHeader.TabIndex = 2
        Me.lblHeader.Text = "MESSAGING OPERATIONS"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdLabeling, Me.cmdShip, Me.cmdAdmin, Me.cmdReceive, Me.lblGroup, Me.lblLineSide, Me.lblLine, Me.lblBin, Me.lblMachine, Me.lblShift, Me.lblWorkDate, Me.lblUserName})
        Me.Panel2.Location = New System.Drawing.Point(0, 71)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(208, 425)
        Me.Panel2.TabIndex = 3
        '
        'cmdLabeling
        '
        Me.cmdLabeling.BackColor = System.Drawing.Color.Black
        Me.cmdLabeling.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLabeling.ForeColor = System.Drawing.Color.Lime
        Me.cmdLabeling.Location = New System.Drawing.Point(11, 355)
        Me.cmdLabeling.Name = "cmdLabeling"
        Me.cmdLabeling.Size = New System.Drawing.Size(184, 23)
        Me.cmdLabeling.TabIndex = 96
        Me.cmdLabeling.Text = "LABEL"
        '
        'cmdShip
        '
        Me.cmdShip.BackColor = System.Drawing.Color.Black
        Me.cmdShip.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShip.ForeColor = System.Drawing.Color.Lime
        Me.cmdShip.Location = New System.Drawing.Point(11, 387)
        Me.cmdShip.Name = "cmdShip"
        Me.cmdShip.Size = New System.Drawing.Size(184, 23)
        Me.cmdShip.TabIndex = 95
        Me.cmdShip.Text = "SHIP"
        '
        'cmdAdmin
        '
        Me.cmdAdmin.BackColor = System.Drawing.Color.Black
        Me.cmdAdmin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAdmin.ForeColor = System.Drawing.Color.Lime
        Me.cmdAdmin.Location = New System.Drawing.Point(11, 291)
        Me.cmdAdmin.Name = "cmdAdmin"
        Me.cmdAdmin.Size = New System.Drawing.Size(184, 23)
        Me.cmdAdmin.TabIndex = 2
        Me.cmdAdmin.Text = "ADMIN"
        '
        'cmdReceive
        '
        Me.cmdReceive.BackColor = System.Drawing.Color.Black
        Me.cmdReceive.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReceive.ForeColor = System.Drawing.Color.Lime
        Me.cmdReceive.Location = New System.Drawing.Point(11, 323)
        Me.cmdReceive.Name = "cmdReceive"
        Me.cmdReceive.Size = New System.Drawing.Size(184, 23)
        Me.cmdReceive.TabIndex = 1
        Me.cmdReceive.Text = "RECEIVE"
        '
        'lblGroup
        '
        Me.lblGroup.BackColor = System.Drawing.Color.Transparent
        Me.lblGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroup.ForeColor = System.Drawing.Color.Lime
        Me.lblGroup.Location = New System.Drawing.Point(32, 24)
        Me.lblGroup.Name = "lblGroup"
        Me.lblGroup.Size = New System.Drawing.Size(146, 16)
        Me.lblGroup.TabIndex = 91
        Me.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLineSide
        '
        Me.lblLineSide.BackColor = System.Drawing.Color.Transparent
        Me.lblLineSide.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLineSide.ForeColor = System.Drawing.Color.Lime
        Me.lblLineSide.Location = New System.Drawing.Point(24, 72)
        Me.lblLineSide.Name = "lblLineSide"
        Me.lblLineSide.Size = New System.Drawing.Size(146, 16)
        Me.lblLineSide.TabIndex = 93
        Me.lblLineSide.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLine
        '
        Me.lblLine.BackColor = System.Drawing.Color.Transparent
        Me.lblLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLine.ForeColor = System.Drawing.Color.Lime
        Me.lblLine.Location = New System.Drawing.Point(24, 48)
        Me.lblLine.Name = "lblLine"
        Me.lblLine.Size = New System.Drawing.Size(146, 16)
        Me.lblLine.TabIndex = 90
        Me.lblLine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBin
        '
        Me.lblBin.BackColor = System.Drawing.Color.Transparent
        Me.lblBin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBin.ForeColor = System.Drawing.Color.Lime
        Me.lblBin.Location = New System.Drawing.Point(15, 120)
        Me.lblBin.Name = "lblBin"
        Me.lblBin.Size = New System.Drawing.Size(178, 16)
        Me.lblBin.TabIndex = 94
        Me.lblBin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMachine
        '
        Me.lblMachine.BackColor = System.Drawing.Color.Transparent
        Me.lblMachine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMachine.ForeColor = System.Drawing.Color.Lime
        Me.lblMachine.Location = New System.Drawing.Point(15, 104)
        Me.lblMachine.Name = "lblMachine"
        Me.lblMachine.Size = New System.Drawing.Size(178, 16)
        Me.lblMachine.TabIndex = 92
        Me.lblMachine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblShift
        '
        Me.lblShift.BackColor = System.Drawing.Color.Transparent
        Me.lblShift.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShift.ForeColor = System.Drawing.Color.Lime
        Me.lblShift.Location = New System.Drawing.Point(9, 160)
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
        Me.lblWorkDate.Location = New System.Drawing.Point(9, 184)
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
        Me.lblUserName.Location = New System.Drawing.Point(9, 144)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(178, 16)
        Me.lblUserName.TabIndex = 83
        Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlAdmin
        '
        Me.pnlAdmin.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlAdmin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlAdmin.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox6, Me.GroupBox5, Me.GroupBox4, Me.GroupBox3, Me.GroupBox2, Me.GroupBox1})
        Me.pnlAdmin.Location = New System.Drawing.Point(922, 120)
        Me.pnlAdmin.Name = "pnlAdmin"
        Me.pnlAdmin.Size = New System.Drawing.Size(87, 56)
        Me.pnlAdmin.TabIndex = 4
        Me.pnlAdmin.Visible = False
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmd})
        Me.GroupBox6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(230, 214)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(227, 82)
        Me.GroupBox6.TabIndex = 5
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Label Related"
        '
        'cmd
        '
        Me.cmd.BackColor = System.Drawing.Color.SteelBlue
        Me.cmd.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd.ForeColor = System.Drawing.Color.White
        Me.cmd.Location = New System.Drawing.Point(16, 32)
        Me.cmd.Name = "cmd"
        Me.cmd.Size = New System.Drawing.Size(184, 32)
        Me.cmd.TabIndex = 3
        Me.cmd.Text = "Setup Labels"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdUpdatePO, Me.Button7, Me.Button6, Me.cmdDelWO, Me.Button5, Me.Button3})
        Me.GroupBox5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(8, 247)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(216, 224)
        Me.GroupBox5.TabIndex = 4
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Work Order Related"
        '
        'cmdUpdatePO
        '
        Me.cmdUpdatePO.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdUpdatePO.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUpdatePO.ForeColor = System.Drawing.Color.White
        Me.cmdUpdatePO.Location = New System.Drawing.Point(16, 162)
        Me.cmdUpdatePO.Name = "cmdUpdatePO"
        Me.cmdUpdatePO.Size = New System.Drawing.Size(184, 23)
        Me.cmdUpdatePO.TabIndex = 8
        Me.cmdUpdatePO.Text = "Update PO"
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.SteelBlue
        Me.Button7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.ForeColor = System.Drawing.Color.White
        Me.Button7.Location = New System.Drawing.Point(16, 122)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(184, 35)
        Me.Button7.TabIndex = 7
        Me.Button7.Text = "Update Customer/Location for Work Order"
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.SteelBlue
        Me.Button6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.ForeColor = System.Drawing.Color.White
        Me.Button6.Location = New System.Drawing.Point(16, 24)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(184, 23)
        Me.Button6.TabIndex = 6
        Me.Button6.Text = "Change Work Order"
        '
        'cmdDelWO
        '
        Me.cmdDelWO.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdDelWO.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelWO.ForeColor = System.Drawing.Color.White
        Me.cmdDelWO.Location = New System.Drawing.Point(16, 191)
        Me.cmdDelWO.Name = "cmdDelWO"
        Me.cmdDelWO.Size = New System.Drawing.Size(184, 23)
        Me.cmdDelWO.TabIndex = 1
        Me.cmdDelWO.Text = "Delete Work Order"
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.SteelBlue
        Me.Button5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.White
        Me.Button5.Location = New System.Drawing.Point(16, 52)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(184, 23)
        Me.Button5.TabIndex = 5
        Me.Button5.Text = "Update Work Order Memo"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.SteelBlue
        Me.Button3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(16, 81)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(184, 35)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "Update Customer/Location for Work Order"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdChangeSN, Me.cmdDelDevfromTray, Me.cmdDelTray})
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(8, 103)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(216, 144)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Device Related"
        '
        'cmdChangeSN
        '
        Me.cmdChangeSN.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdChangeSN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdChangeSN.ForeColor = System.Drawing.Color.White
        Me.cmdChangeSN.Location = New System.Drawing.Point(16, 24)
        Me.cmdChangeSN.Name = "cmdChangeSN"
        Me.cmdChangeSN.Size = New System.Drawing.Size(184, 23)
        Me.cmdChangeSN.TabIndex = 5
        Me.cmdChangeSN.Text = "Change SN"
        '
        'cmdDelDevfromTray
        '
        Me.cmdDelDevfromTray.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdDelDevfromTray.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelDevfromTray.ForeColor = System.Drawing.Color.White
        Me.cmdDelDevfromTray.Location = New System.Drawing.Point(16, 54)
        Me.cmdDelDevfromTray.Name = "cmdDelDevfromTray"
        Me.cmdDelDevfromTray.Size = New System.Drawing.Size(184, 42)
        Me.cmdDelDevfromTray.TabIndex = 2
        Me.cmdDelDevfromTray.Text = "Delete One Device From Tray"
        '
        'cmdDelTray
        '
        Me.cmdDelTray.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdDelTray.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelTray.ForeColor = System.Drawing.Color.White
        Me.cmdDelTray.Location = New System.Drawing.Point(16, 103)
        Me.cmdDelTray.Name = "cmdDelTray"
        Me.cmdDelTray.Size = New System.Drawing.Size(184, 28)
        Me.cmdDelTray.TabIndex = 0
        Me.cmdDelTray.Text = "Delete all Devices in Tray"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdUpdateSKU, Me.cmdUpdateCapcode, Me.cmdUpdateFreq})
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(230, 8)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(226, 120)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Customer Data Related"
        '
        'cmdUpdateSKU
        '
        Me.cmdUpdateSKU.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdUpdateSKU.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUpdateSKU.ForeColor = System.Drawing.Color.White
        Me.cmdUpdateSKU.Location = New System.Drawing.Point(16, 86)
        Me.cmdUpdateSKU.Name = "cmdUpdateSKU"
        Me.cmdUpdateSKU.Size = New System.Drawing.Size(192, 23)
        Me.cmdUpdateSKU.TabIndex = 4
        Me.cmdUpdateSKU.Text = "Update SKU"
        '
        'cmdUpdateCapcode
        '
        Me.cmdUpdateCapcode.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdUpdateCapcode.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUpdateCapcode.ForeColor = System.Drawing.Color.White
        Me.cmdUpdateCapcode.Location = New System.Drawing.Point(16, 55)
        Me.cmdUpdateCapcode.Name = "cmdUpdateCapcode"
        Me.cmdUpdateCapcode.Size = New System.Drawing.Size(192, 23)
        Me.cmdUpdateCapcode.TabIndex = 3
        Me.cmdUpdateCapcode.Text = "Update Capcode"
        '
        'cmdUpdateFreq
        '
        Me.cmdUpdateFreq.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdUpdateFreq.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUpdateFreq.ForeColor = System.Drawing.Color.White
        Me.cmdUpdateFreq.Location = New System.Drawing.Point(16, 24)
        Me.cmdUpdateFreq.Name = "cmdUpdateFreq"
        Me.cmdUpdateFreq.Size = New System.Drawing.Size(192, 23)
        Me.cmdUpdateFreq.TabIndex = 2
        Me.cmdUpdateFreq.Text = "Update Frequency"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdUnship})
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(230, 127)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(227, 88)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Shipping Related"
        '
        'cmdUnship
        '
        Me.cmdUnship.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdUnship.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUnship.ForeColor = System.Drawing.Color.White
        Me.cmdUnship.Location = New System.Drawing.Point(16, 32)
        Me.cmdUnship.Name = "cmdUnship"
        Me.cmdUnship.Size = New System.Drawing.Size(184, 40)
        Me.cmdUnship.TabIndex = 3
        Me.cmdUnship.Text = "Unship Devices in a Ship Manifest"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdLoadFile, Me.cmbCustomer, Me.Label1})
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(216, 96)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Load File"
        '
        'cmdLoadFile
        '
        Me.cmdLoadFile.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdLoadFile.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLoadFile.ForeColor = System.Drawing.Color.White
        Me.cmdLoadFile.Location = New System.Drawing.Point(16, 61)
        Me.cmdLoadFile.Name = "cmdLoadFile"
        Me.cmdLoadFile.Size = New System.Drawing.Size(184, 23)
        Me.cmdLoadFile.TabIndex = 3
        Me.cmdLoadFile.Text = "Load File"
        '
        'cmbCustomer
        '
        Me.cmbCustomer.AutoComplete = True
        Me.cmbCustomer.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCustomer.ForeColor = System.Drawing.Color.Black
        Me.cmbCustomer.Location = New System.Drawing.Point(10, 33)
        Me.cmbCustomer.Name = "cmbCustomer"
        Me.cmbCustomer.Size = New System.Drawing.Size(196, 21)
        Me.cmbCustomer.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Customer:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlReceive
        '
        Me.pnlReceive.BackColor = System.Drawing.Color.LightYellow
        Me.pnlReceive.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlReceive.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel1, Me.panelPallet})
        Me.pnlReceive.Location = New System.Drawing.Point(209, 0)
        Me.pnlReceive.Name = "pnlReceive"
        Me.pnlReceive.Size = New System.Drawing.Size(655, 496)
        Me.pnlReceive.TabIndex = 5
        Me.pnlReceive.Visible = False
        '
        'pnlShip
        '
        Me.pnlShip.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.pnlShip.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlShip.Location = New System.Drawing.Point(922, 40)
        Me.pnlShip.Name = "pnlShip"
        Me.pnlShip.Size = New System.Drawing.Size(95, 32)
        Me.pnlShip.TabIndex = 6
        Me.pnlShip.Visible = False
        '
        'cmbRecCustomer
        '
        Me.cmbRecCustomer.AutoComplete = True
        Me.cmbRecCustomer.BackColor = System.Drawing.SystemColors.Window
        Me.cmbRecCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRecCustomer.ForeColor = System.Drawing.Color.Black
        Me.cmbRecCustomer.Location = New System.Drawing.Point(80, 48)
        Me.cmbRecCustomer.Name = "cmbRecCustomer"
        Me.cmbRecCustomer.Size = New System.Drawing.Size(196, 21)
        Me.cmbRecCustomer.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Customer:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbRecLocation
        '
        Me.cmbRecLocation.AutoComplete = True
        Me.cmbRecLocation.BackColor = System.Drawing.SystemColors.Window
        Me.cmbRecLocation.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRecLocation.ForeColor = System.Drawing.Color.Black
        Me.cmbRecLocation.Location = New System.Drawing.Point(80, 80)
        Me.cmbRecLocation.Name = "cmbRecLocation"
        Me.cmbRecLocation.Size = New System.Drawing.Size(196, 21)
        Me.cmbRecLocation.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Location:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbModel
        '
        Me.cmbModel.AutoComplete = True
        Me.cmbModel.BackColor = System.Drawing.SystemColors.Window
        Me.cmbModel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbModel.ForeColor = System.Drawing.Color.Black
        Me.cmbModel.Location = New System.Drawing.Point(80, 195)
        Me.cmbModel.Name = "cmbModel"
        Me.cmbModel.Size = New System.Drawing.Size(196, 21)
        Me.cmbModel.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 195)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 16)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Model:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'panelPallet
        '
        Me.panelPallet.BackColor = System.Drawing.Color.LightSteelBlue
        Me.panelPallet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panelPallet.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtDevSN, Me.Label10, Me.cmdClosePallet, Me.btnClearAll, Me.btnClear, Me.lstDevices, Me.lblCount, Me.Label6})
        Me.panelPallet.Location = New System.Drawing.Point(296, 8)
        Me.panelPallet.Name = "panelPallet"
        Me.panelPallet.Size = New System.Drawing.Size(340, 382)
        Me.panelPallet.TabIndex = 95
        Me.panelPallet.Visible = False
        '
        'txtDevSN
        '
        Me.txtDevSN.Location = New System.Drawing.Point(11, 108)
        Me.txtDevSN.Name = "txtDevSN"
        Me.txtDevSN.Size = New System.Drawing.Size(156, 20)
        Me.txtDevSN.TabIndex = 100
        Me.txtDevSN.Text = ""
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(11, 92)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(93, 16)
        Me.Label10.TabIndex = 99
        Me.Label10.Text = "Device IMEI:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClosePallet
        '
        Me.cmdClosePallet.BackColor = System.Drawing.Color.Green
        Me.cmdClosePallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClosePallet.ForeColor = System.Drawing.Color.White
        Me.cmdClosePallet.Location = New System.Drawing.Point(11, 341)
        Me.cmdClosePallet.Name = "cmdClosePallet"
        Me.cmdClosePallet.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClosePallet.Size = New System.Drawing.Size(157, 32)
        Me.cmdClosePallet.TabIndex = 92
        Me.cmdClosePallet.Text = "CLOSE PALLET"
        '
        'btnClearAll
        '
        Me.btnClearAll.BackColor = System.Drawing.Color.Red
        Me.btnClearAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearAll.ForeColor = System.Drawing.Color.White
        Me.btnClearAll.Location = New System.Drawing.Point(176, 224)
        Me.btnClearAll.Name = "btnClearAll"
        Me.btnClearAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnClearAll.Size = New System.Drawing.Size(148, 33)
        Me.btnClearAll.TabIndex = 91
        Me.btnClearAll.Text = "REMOVE ALL IMEIs"
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.Red
        Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.Color.White
        Me.btnClear.Location = New System.Drawing.Point(176, 184)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnClear.Size = New System.Drawing.Size(148, 32)
        Me.btnClear.TabIndex = 90
        Me.btnClear.Text = "REMOVE IMEI"
        '
        'lstDevices
        '
        Me.lstDevices.Location = New System.Drawing.Point(11, 135)
        Me.lstDevices.Name = "lstDevices"
        Me.lstDevices.Size = New System.Drawing.Size(156, 199)
        Me.lstDevices.TabIndex = 89
        '
        'lblCount
        '
        Me.lblCount.BackColor = System.Drawing.Color.Black
        Me.lblCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCount.ForeColor = System.Drawing.Color.Lime
        Me.lblCount.Location = New System.Drawing.Point(200, 144)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(98, 32)
        Me.lblCount.TabIndex = 97
        Me.lblCount.Text = "0"
        Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(224, 128)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 16)
        Me.Label6.TabIndex = 96
        Me.Label6.Text = "Count"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkKhaki
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label8, Me.ComboBox1, Me.Label7, Me.Label5, Me.Label3, Me.cmbRecCustomer, Me.Label4, Me.cmbRecLocation, Me.cmbModel, Me.Label2})
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(293, 496)
        Me.Panel1.TabIndex = 96
        Me.Panel1.Visible = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(288, 40)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "RECEIVING"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox1
        '
        Me.ComboBox1.AutoComplete = True
        Me.ComboBox1.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.ForeColor = System.Drawing.Color.Black
        Me.ComboBox1.Location = New System.Drawing.Point(80, 168)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(196, 21)
        Me.ComboBox1.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 168)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 16)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Customer:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(88, 112)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(184, 48)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Customer:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmMessReceiving
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(1028, 550)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlShip, Me.pnlAdmin, Me.Panel2, Me.lblHeader, Me.pnlLabel, Me.pnlReceive})
        Me.Name = "frmMessReceiving"
        Me.Text = "Messaging Operations Console"
        Me.Panel2.ResumeLayout(False)
        Me.pnlAdmin.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.pnlReceive.ResumeLayout(False)
        Me.panelPallet.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub cmdAdmin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdmin.Click
        ShowHidePanels(iPanelAdminIndex)
    End Sub
    Private Sub cmdReceive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReceive.Click
        ShowHidePanels(iPanelRecIndex)
    End Sub
    Private Sub cmdLabeling_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLabeling.Click
        ShowHidePanels(iPanelLabelIndex)
    End Sub
    Private Sub cmdShip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShip.Click
        ShowHidePanels(iPanelShipIndex)
    End Sub
    Private Sub ShowHidePanels(ByVal iPanelIndex As Integer)

        Try
            MakeAllPanelsInvisible()
            Select Case iPanelIndex
                Case 1
                    'STEP 1: Check the security for MessAdmin
                    booMessAdminSecure = UserHasAccessPrivilege(iPanelIndex)

                    booMessAdminSecure = True 'Comment this line when the above code is implemented
                    If booMessAdminSecure = True Then
                        Me.pnlAdmin.Visible = True
                    End If

                Case 2
                    'STEP 1: Check the security for MessAdmin
                    booMessRecSecure = UserHasAccessPrivilege(iPanelIndex)

                    booMessRecSecure = True 'Comment this line when the above code is implemented
                    If booMessRecSecure = True Then
                        Me.pnlReceive.Visible = True
                    End If
                Case 3
                    'STEP 1: Check the security for MessAdmin
                    booMessLabelSecure = UserHasAccessPrivilege(iPanelIndex)

                    booMessLabelSecure = True 'Comment this line when the above code is implemented
                    If booMessLabelSecure = True Then
                        Me.pnlLabel.Visible = True
                    End If
                Case 4
                    'STEP 1: Check the security for MessAdmin
                    booMessShipSecure = UserHasAccessPrivilege(iPanelIndex)

                    booMessShipSecure = True 'Comment this line when the above code is implemented
                    If booMessShipSecure = True Then
                        Me.pnlShip.Visible = True
                    End If
            End Select


        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Admin Button Clicked", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try

    End Sub

    Private Sub MakeAllPanelsInvisible()
        Me.pnlAdmin.Visible = False
        Me.pnlReceive.Visible = False
        Me.pnlLabel.Visible = False
        Me.pnlShip.Visible = False
    End Sub

    Private Function UserHasAccessPrivilege(ByVal iPanelIndex As Integer) As Boolean
        Try

        Catch ex As Exception

        End Try
    End Function




    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbModel As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbRecLocation As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbRecCustomer As PSS.Gui.Controls.ComboBox

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub frmMessReceiving_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            LoadCustomers()

        Catch ex As Exception
            MessageBox.Show("" & ex.ToString, "Load Form", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
        End Try
    End Sub

    Private Sub LoadCustomers()
        Dim dtCustomers As New DataTable()
        Dim objMisc As New PSS.Data.Buisness.Misc()

        Try
            dtCustomers = objMisc.GetCustomers(1)
            With Me.cmbCustomer
                .DataSource = dtCustomers.DefaultView
                .DisplayMember = dtCustomers.Columns("cust_name1").ToString
                .ValueMember = dtCustomers.Columns("Cust_ID").ToString
                .SelectedValue = 0
            End With
        Catch ex As Exception
            MsgBox("Error in frmCellShipPallet_Generic.LoadCustomers:: " & ex.Message.ToString, MsgBoxStyle.Critical)
        Finally
            If Not IsNothing(dtCustomers) Then
                dtCustomers.Dispose()
                dtCustomers = Nothing
            End If
            objMisc = Nothing
        End Try
    End Sub

    Private Sub cmbRecCustomer_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbRecCustomer.SelectionChangeCommitted
        If Me.cmbRecCustomer.SelectedValue > 0 Then

        End If
    End Sub
End Class
