
Imports PSS.Core.Global

Public Class frmMessConsole
    Inherits System.Windows.Forms.Form

    Private objMessAdmin As PSS.Data.Buisness.MessAdmin
    Private objMessReceive As PSS.Data.Buisness.MessReceive
    Private objMessLabel As PSS.Data.Buisness.MessLabel
    Private objMessShip As PSS.Data.Buisness.MessShip

    Private strMachine As String = System.Net.Dns.GetHostName
    Private strUserName As String = PSS.Core.Global.ApplicationUser.User
    Private iUserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
    Private iShiftID As Integer = PSS.Core.Global.ApplicationUser.IDShift
    Private strWorkDate As String = PSS.Core.Global.ApplicationUser.Workdate

    Private booMessAdminSecure As Boolean = False
    Private booMessRecSecure As Boolean = False
    Private booMessLabelSecure As Boolean = False
    Private booMessShipSecure As Boolean = False

    Private Const iPanelAdminIndex As Integer = 1
    Private Const iPanelRecIndex As Integer = 2
    Private Const iPanelLabelIndex As Integer = 3
    Private Const iPanelShipIndex As Integer = 4

    Private iGWOID As Integer = 0

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
    Friend WithEvents lblMachine As System.Windows.Forms.Label
    Friend WithEvents lblShift As System.Windows.Forms.Label
    Friend WithEvents lblWorkDate As System.Windows.Forms.Label
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdDelTray As System.Windows.Forms.Button
    Friend WithEvents cmdDelWO As System.Windows.Forms.Button
    Friend WithEvents cmdDelDevfromTray As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
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
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblRecCount As System.Windows.Forms.Label
    Friend WithEvents lstRecDevices As System.Windows.Forms.ListBox
    Friend WithEvents btnRecClear As System.Windows.Forms.Button
    Friend WithEvents btnRecClearAll As System.Windows.Forms.Button
    Friend WithEvents cmdRecTray As System.Windows.Forms.Button
    Friend WithEvents txtRecDevSN As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbRecLocation As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbRecCustomer As PSS.Gui.Controls.ComboBox
    Friend WithEvents cmbAdminCustomer As PSS.Gui.Controls.ComboBox
    Friend WithEvents txtRecWO As System.Windows.Forms.TextBox
    Friend WithEvents lblRecAddress As System.Windows.Forms.Label
    Friend WithEvents txtRecWOMemo As System.Windows.Forms.TextBox
    Friend WithEvents cmbRecModel As PSS.Gui.Controls.ComboBox
    Friend WithEvents lblRecBaud As System.Windows.Forms.Label
    Friend WithEvents lblRecFreq As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cmbRecPO As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblRecWOQty As System.Windows.Forms.Label
    Friend WithEvents cmdRecReprintManifest As System.Windows.Forms.Button
    Friend WithEvents lblRecSKU As System.Windows.Forms.Label
    Friend WithEvents lblRecAMCapCode As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents gbCustData As System.Windows.Forms.GroupBox
    Friend WithEvents lblRecUMCapLow As System.Windows.Forms.Label
    Friend WithEvents lblRecUMCapHigh As System.Windows.Forms.Label


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.pnlLabel = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmdLabeling = New System.Windows.Forms.Button()
        Me.cmdShip = New System.Windows.Forms.Button()
        Me.cmdAdmin = New System.Windows.Forms.Button()
        Me.cmdReceive = New System.Windows.Forms.Button()
        Me.lblMachine = New System.Windows.Forms.Label()
        Me.lblShift = New System.Windows.Forms.Label()
        Me.lblWorkDate = New System.Windows.Forms.Label()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.pnlAdmin = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
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
        Me.cmbAdminCustomer = New PSS.Gui.Controls.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlReceive = New System.Windows.Forms.Panel()
        Me.cmdRecReprintManifest = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cmbRecPO = New PSS.Gui.Controls.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.gbCustData = New System.Windows.Forms.GroupBox()
        Me.pnlRecAMCapCode = New System.Windows.Forms.Panel()
        Me.lblRecAMCapCode = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.pnlRecUMCapCode = New System.Windows.Forms.Panel()
        Me.lblRecUMCapLow = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblRecUMCapHigh = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblRecBaud = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblRecFreq = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblRecSKU = New System.Windows.Forms.Label()
        Me.lblRecWOQty = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnRecClearAll = New System.Windows.Forms.Button()
        Me.btnRecClear = New System.Windows.Forms.Button()
        Me.lstRecDevices = New System.Windows.Forms.ListBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblRecCount = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmdRecTray = New System.Windows.Forms.Button()
        Me.txtRecDevSN = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbRecModel = New PSS.Gui.Controls.ComboBox()
        Me.txtRecWOMemo = New System.Windows.Forms.TextBox()
        Me.cmbRecLocation = New PSS.Gui.Controls.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblRecAddress = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbRecCustomer = New PSS.Gui.Controls.ComboBox()
        Me.txtRecWO = New System.Windows.Forms.TextBox()
        Me.pnlShip = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.pnlLabel.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlAdmin.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlReceive.SuspendLayout()
        Me.gbCustData.SuspendLayout()
        Me.pnlRecAMCapCode.SuspendLayout()
        Me.pnlRecUMCapCode.SuspendLayout()
        Me.pnlShip.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlLabel
        '
        Me.pnlLabel.BackColor = System.Drawing.Color.DarkKhaki
        Me.pnlLabel.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label13})
        Me.pnlLabel.Location = New System.Drawing.Point(1016, 344)
        Me.pnlLabel.Name = "pnlLabel"
        Me.pnlLabel.Size = New System.Drawing.Size(680, 520)
        Me.pnlLabel.TabIndex = 5
        Me.pnlLabel.Visible = False
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Black
        Me.Label13.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Lime
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(680, 40)
        Me.Label13.TabIndex = 99
        Me.Label13.Text = "LABEL"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblHeader
        '
        Me.lblHeader.BackColor = System.Drawing.Color.Black
        Me.lblHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.Yellow
        Me.lblHeader.Location = New System.Drawing.Point(-1, 0)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(209, 88)
        Me.lblHeader.TabIndex = 1
        Me.lblHeader.Text = "MESSAGING OPERATIONS CONSOLE"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdLabeling, Me.cmdShip, Me.cmdAdmin, Me.cmdReceive, Me.lblMachine, Me.lblShift, Me.lblWorkDate, Me.lblUserName})
        Me.Panel2.Location = New System.Drawing.Point(0, 80)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(208, 440)
        Me.Panel2.TabIndex = 2
        '
        'cmdLabeling
        '
        Me.cmdLabeling.BackColor = System.Drawing.Color.Black
        Me.cmdLabeling.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLabeling.ForeColor = System.Drawing.Color.Lime
        Me.cmdLabeling.Location = New System.Drawing.Point(11, 368)
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
        Me.cmdShip.Location = New System.Drawing.Point(11, 400)
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
        Me.cmdAdmin.Location = New System.Drawing.Point(11, 304)
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
        Me.cmdReceive.Location = New System.Drawing.Point(11, 336)
        Me.cmdReceive.Name = "cmdReceive"
        Me.cmdReceive.Size = New System.Drawing.Size(184, 23)
        Me.cmdReceive.TabIndex = 1
        Me.cmdReceive.Text = "RECEIVE"
        '
        'lblMachine
        '
        Me.lblMachine.BackColor = System.Drawing.Color.Transparent
        Me.lblMachine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMachine.ForeColor = System.Drawing.Color.Lime
        Me.lblMachine.Location = New System.Drawing.Point(8, 64)
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
        Me.lblShift.Location = New System.Drawing.Point(8, 112)
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
        Me.lblWorkDate.Location = New System.Drawing.Point(8, 136)
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
        Me.lblUserName.Location = New System.Drawing.Point(8, 88)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(178, 16)
        Me.lblUserName.TabIndex = 83
        Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlAdmin
        '
        Me.pnlAdmin.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlAdmin.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label11, Me.GroupBox6, Me.GroupBox5, Me.GroupBox4, Me.GroupBox3, Me.GroupBox2, Me.GroupBox1})
        Me.pnlAdmin.Location = New System.Drawing.Point(936, 16)
        Me.pnlAdmin.Name = "pnlAdmin"
        Me.pnlAdmin.Size = New System.Drawing.Size(680, 520)
        Me.pnlAdmin.TabIndex = 3
        Me.pnlAdmin.Visible = False
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Black
        Me.Label11.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Lime
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(680, 40)
        Me.Label11.TabIndex = 98
        Me.Label11.Text = "ADMIN"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmd})
        Me.GroupBox6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(230, 255)
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
        Me.GroupBox5.Location = New System.Drawing.Point(8, 288)
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
        Me.GroupBox4.Location = New System.Drawing.Point(8, 144)
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
        Me.GroupBox3.Location = New System.Drawing.Point(230, 49)
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
        Me.GroupBox2.Location = New System.Drawing.Point(230, 168)
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
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdLoadFile, Me.cmbAdminCustomer, Me.Label1})
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 49)
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
        'cmbAdminCustomer
        '
        Me.cmbAdminCustomer.AutoComplete = True
        Me.cmbAdminCustomer.BackColor = System.Drawing.SystemColors.Window
        Me.cmbAdminCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAdminCustomer.ForeColor = System.Drawing.Color.Black
        Me.cmbAdminCustomer.Location = New System.Drawing.Point(10, 33)
        Me.cmbAdminCustomer.Name = "cmbAdminCustomer"
        Me.cmbAdminCustomer.Size = New System.Drawing.Size(196, 21)
        Me.cmbAdminCustomer.TabIndex = 2
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
        Me.pnlReceive.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlReceive.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdRecReprintManifest, Me.Label17, Me.Label19, Me.cmbRecPO, Me.Label22, Me.gbCustData, Me.Label5, Me.btnRecClearAll, Me.btnRecClear, Me.lstRecDevices, Me.Label10, Me.lblRecCount, Me.Label6, Me.cmdRecTray, Me.txtRecDevSN, Me.Label9, Me.cmbRecModel, Me.txtRecWOMemo, Me.cmbRecLocation, Me.Label7, Me.lblRecAddress, Me.Label2, Me.Label3, Me.Label4, Me.cmbRecCustomer, Me.txtRecWO})
        Me.pnlReceive.Location = New System.Drawing.Point(208, 0)
        Me.pnlReceive.Name = "pnlReceive"
        Me.pnlReceive.Size = New System.Drawing.Size(712, 520)
        Me.pnlReceive.TabIndex = 4
        Me.pnlReceive.Visible = False
        '
        'cmdRecReprintManifest
        '
        Me.cmdRecReprintManifest.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdRecReprintManifest.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRecReprintManifest.ForeColor = System.Drawing.Color.White
        Me.cmdRecReprintManifest.Location = New System.Drawing.Point(581, 455)
        Me.cmdRecReprintManifest.Name = "cmdRecReprintManifest"
        Me.cmdRecReprintManifest.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRecReprintManifest.Size = New System.Drawing.Size(112, 40)
        Me.cmdRecReprintManifest.TabIndex = 115
        Me.cmdRecReprintManifest.Text = "REPRINT MANIFEST"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Black
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Lime
        Me.Label17.Location = New System.Drawing.Point(591, 313)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(93, 50)
        Me.Label17.TabIndex = 114
        Me.Label17.Text = "0"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(569, 297)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(136, 16)
        Me.Label19.TabIndex = 113
        Me.Label19.Text = "WO RCVD. COUNT"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbRecPO
        '
        Me.cmbRecPO.AutoComplete = True
        Me.cmbRecPO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbRecPO.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRecPO.ForeColor = System.Drawing.Color.Black
        Me.cmbRecPO.Location = New System.Drawing.Point(134, 154)
        Me.cmbRecPO.Name = "cmbRecPO"
        Me.cmbRecPO.Size = New System.Drawing.Size(242, 21)
        Me.cmbRecPO.TabIndex = 5
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(44, 157)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(80, 16)
        Me.Label22.TabIndex = 111
        Me.Label22.Text = "PO:"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gbCustData
        '
        Me.gbCustData.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlRecAMCapCode, Me.pnlRecUMCapCode, Me.Label14, Me.lblRecBaud, Me.Label12, Me.lblRecFreq, Me.Label16, Me.lblRecSKU, Me.lblRecWOQty, Me.Label18})
        Me.gbCustData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCustData.Location = New System.Drawing.Point(26, 345)
        Me.gbCustData.Name = "gbCustData"
        Me.gbCustData.Size = New System.Drawing.Size(351, 160)
        Me.gbCustData.TabIndex = 108
        Me.gbCustData.TabStop = False
        Me.gbCustData.Text = "Customer Data"
        Me.gbCustData.Visible = False
        '
        'pnlRecAMCapCode
        '
        Me.pnlRecAMCapCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlRecAMCapCode.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblRecAMCapCode, Me.Label23})
        Me.pnlRecAMCapCode.Location = New System.Drawing.Point(7, 16)
        Me.pnlRecAMCapCode.Name = "pnlRecAMCapCode"
        Me.pnlRecAMCapCode.Size = New System.Drawing.Size(336, 40)
        Me.pnlRecAMCapCode.TabIndex = 113
        '
        'lblRecAMCapCode
        '
        Me.lblRecAMCapCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecAMCapCode.ForeColor = System.Drawing.Color.Black
        Me.lblRecAMCapCode.Location = New System.Drawing.Point(116, 10)
        Me.lblRecAMCapCode.Name = "lblRecAMCapCode"
        Me.lblRecAMCapCode.Size = New System.Drawing.Size(92, 16)
        Me.lblRecAMCapCode.TabIndex = 107
        Me.lblRecAMCapCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(36, 10)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(64, 16)
        Me.Label23.TabIndex = 100
        Me.Label23.Text = "Cap Low:"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlRecUMCapCode
        '
        Me.pnlRecUMCapCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlRecUMCapCode.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblRecUMCapLow, Me.Label8, Me.lblRecUMCapHigh, Me.Label21})
        Me.pnlRecUMCapCode.Location = New System.Drawing.Point(7, 16)
        Me.pnlRecUMCapCode.Name = "pnlRecUMCapCode"
        Me.pnlRecUMCapCode.Size = New System.Drawing.Size(336, 40)
        Me.pnlRecUMCapCode.TabIndex = 112
        '
        'lblRecUMCapLow
        '
        Me.lblRecUMCapLow.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecUMCapLow.ForeColor = System.Drawing.Color.Black
        Me.lblRecUMCapLow.Location = New System.Drawing.Point(72, 10)
        Me.lblRecUMCapLow.Name = "lblRecUMCapLow"
        Me.lblRecUMCapLow.Size = New System.Drawing.Size(78, 16)
        Me.lblRecUMCapLow.TabIndex = 107
        Me.lblRecUMCapLow.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(-8, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 16)
        Me.Label8.TabIndex = 100
        Me.Label8.Text = "Cap Low:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRecUMCapHigh
        '
        Me.lblRecUMCapHigh.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecUMCapHigh.ForeColor = System.Drawing.Color.Black
        Me.lblRecUMCapHigh.Location = New System.Drawing.Point(240, 16)
        Me.lblRecUMCapHigh.Name = "lblRecUMCapHigh"
        Me.lblRecUMCapHigh.Size = New System.Drawing.Size(78, 16)
        Me.lblRecUMCapHigh.TabIndex = 111
        Me.lblRecUMCapHigh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(160, 16)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(64, 16)
        Me.Label21.TabIndex = 110
        Me.Label21.Text = "Cap High:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(21, 87)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 16)
        Me.Label14.TabIndex = 104
        Me.Label14.Text = "Frequency:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRecBaud
        '
        Me.lblRecBaud.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecBaud.ForeColor = System.Drawing.Color.Black
        Me.lblRecBaud.Location = New System.Drawing.Point(125, 111)
        Me.lblRecBaud.Name = "lblRecBaud"
        Me.lblRecBaud.Size = New System.Drawing.Size(112, 16)
        Me.lblRecBaud.TabIndex = 101
        Me.lblRecBaud.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(21, 111)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 16)
        Me.Label12.TabIndex = 102
        Me.Label12.Text = "Baud Rate:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRecFreq
        '
        Me.lblRecFreq.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecFreq.ForeColor = System.Drawing.Color.Black
        Me.lblRecFreq.Location = New System.Drawing.Point(125, 87)
        Me.lblRecFreq.Name = "lblRecFreq"
        Me.lblRecFreq.Size = New System.Drawing.Size(112, 16)
        Me.lblRecFreq.TabIndex = 103
        Me.lblRecFreq.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(53, 63)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(56, 16)
        Me.Label16.TabIndex = 106
        Me.Label16.Text = "SKU:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRecSKU
        '
        Me.lblRecSKU.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecSKU.ForeColor = System.Drawing.Color.Black
        Me.lblRecSKU.Location = New System.Drawing.Point(125, 63)
        Me.lblRecSKU.Name = "lblRecSKU"
        Me.lblRecSKU.Size = New System.Drawing.Size(112, 16)
        Me.lblRecSKU.TabIndex = 105
        Me.lblRecSKU.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRecWOQty
        '
        Me.lblRecWOQty.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecWOQty.ForeColor = System.Drawing.Color.Black
        Me.lblRecWOQty.Location = New System.Drawing.Point(125, 136)
        Me.lblRecWOQty.Name = "lblRecWOQty"
        Me.lblRecWOQty.Size = New System.Drawing.Size(112, 16)
        Me.lblRecWOQty.TabIndex = 108
        Me.lblRecWOQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(5, 136)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(104, 16)
        Me.Label18.TabIndex = 109
        Me.Label18.Text = "Work Order Qty:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Black
        Me.Label5.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Orange
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(712, 40)
        Me.Label5.TabIndex = 97
        Me.Label5.Text = "RECEIVE"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnRecClearAll
        '
        Me.btnRecClearAll.BackColor = System.Drawing.Color.Red
        Me.btnRecClearAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRecClearAll.ForeColor = System.Drawing.Color.White
        Me.btnRecClearAll.Location = New System.Drawing.Point(597, 212)
        Me.btnRecClearAll.Name = "btnRecClearAll"
        Me.btnRecClearAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnRecClearAll.Size = New System.Drawing.Size(80, 37)
        Me.btnRecClearAll.TabIndex = 11
        Me.btnRecClearAll.Text = "REMOVE ALL SNs"
        '
        'btnRecClear
        '
        Me.btnRecClear.BackColor = System.Drawing.Color.Red
        Me.btnRecClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRecClear.ForeColor = System.Drawing.Color.White
        Me.btnRecClear.Location = New System.Drawing.Point(597, 164)
        Me.btnRecClear.Name = "btnRecClear"
        Me.btnRecClear.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnRecClear.Size = New System.Drawing.Size(80, 37)
        Me.btnRecClear.TabIndex = 10
        Me.btnRecClear.Text = "REMOVE ONE SN"
        '
        'lstRecDevices
        '
        Me.lstRecDevices.Location = New System.Drawing.Point(405, 90)
        Me.lstRecDevices.Name = "lstRecDevices"
        Me.lstRecDevices.Size = New System.Drawing.Size(156, 342)
        Me.lstRecDevices.TabIndex = 8
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(405, 43)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(93, 16)
        Me.Label10.TabIndex = 99
        Me.Label10.Text = "Device SN:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRecCount
        '
        Me.lblRecCount.BackColor = System.Drawing.Color.Black
        Me.lblRecCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRecCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecCount.ForeColor = System.Drawing.Color.Lime
        Me.lblRecCount.Location = New System.Drawing.Point(591, 58)
        Me.lblRecCount.Name = "lblRecCount"
        Me.lblRecCount.Size = New System.Drawing.Size(93, 50)
        Me.lblRecCount.TabIndex = 97
        Me.lblRecCount.Text = "0"
        Me.lblRecCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(587, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 16)
        Me.Label6.TabIndex = 96
        Me.Label6.Text = "TRAY COUNT"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdRecTray
        '
        Me.cmdRecTray.BackColor = System.Drawing.Color.Green
        Me.cmdRecTray.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRecTray.ForeColor = System.Drawing.Color.White
        Me.cmdRecTray.Location = New System.Drawing.Point(405, 442)
        Me.cmdRecTray.Name = "cmdRecTray"
        Me.cmdRecTray.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRecTray.Size = New System.Drawing.Size(157, 62)
        Me.cmdRecTray.TabIndex = 9
        Me.cmdRecTray.Text = "RECEIVE TRAY"
        '
        'txtRecDevSN
        '
        Me.txtRecDevSN.Location = New System.Drawing.Point(405, 59)
        Me.txtRecDevSN.MaxLength = 30
        Me.txtRecDevSN.Name = "txtRecDevSN"
        Me.txtRecDevSN.Size = New System.Drawing.Size(156, 20)
        Me.txtRecDevSN.TabIndex = 7
        Me.txtRecDevSN.Text = ""
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(8, 237)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(120, 16)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Work Order Memo:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbRecModel
        '
        Me.cmbRecModel.AutoComplete = True
        Me.cmbRecModel.BackColor = System.Drawing.SystemColors.Window
        Me.cmbRecModel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRecModel.ForeColor = System.Drawing.Color.Black
        Me.cmbRecModel.Location = New System.Drawing.Point(134, 183)
        Me.cmbRecModel.Name = "cmbRecModel"
        Me.cmbRecModel.Size = New System.Drawing.Size(242, 21)
        Me.cmbRecModel.TabIndex = 3
        '
        'txtRecWOMemo
        '
        Me.txtRecWOMemo.Location = New System.Drawing.Point(133, 239)
        Me.txtRecWOMemo.MaxLength = 75
        Me.txtRecWOMemo.Multiline = True
        Me.txtRecWOMemo.Name = "txtRecWOMemo"
        Me.txtRecWOMemo.Size = New System.Drawing.Size(243, 49)
        Me.txtRecWOMemo.TabIndex = 6
        Me.txtRecWOMemo.Text = ""
        '
        'cmbRecLocation
        '
        Me.cmbRecLocation.AutoComplete = True
        Me.cmbRecLocation.BackColor = System.Drawing.SystemColors.Window
        Me.cmbRecLocation.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRecLocation.ForeColor = System.Drawing.Color.Black
        Me.cmbRecLocation.Location = New System.Drawing.Point(134, 87)
        Me.cmbRecLocation.Name = "cmbRecLocation"
        Me.cmbRecLocation.Size = New System.Drawing.Size(242, 21)
        Me.cmbRecLocation.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(48, 211)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 16)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Work Order:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRecAddress
        '
        Me.lblRecAddress.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecAddress.Location = New System.Drawing.Point(134, 118)
        Me.lblRecAddress.Name = "lblRecAddress"
        Me.lblRecAddress.Size = New System.Drawing.Size(242, 32)
        Me.lblRecAddress.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(57, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Customer:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(65, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Location:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(73, 185)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 16)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Model:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbRecCustomer
        '
        Me.cmbRecCustomer.AutoComplete = True
        Me.cmbRecCustomer.BackColor = System.Drawing.SystemColors.Window
        Me.cmbRecCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRecCustomer.ForeColor = System.Drawing.Color.Black
        Me.cmbRecCustomer.Location = New System.Drawing.Point(134, 59)
        Me.cmbRecCustomer.Name = "cmbRecCustomer"
        Me.cmbRecCustomer.Size = New System.Drawing.Size(242, 21)
        Me.cmbRecCustomer.TabIndex = 1
        '
        'txtRecWO
        '
        Me.txtRecWO.Location = New System.Drawing.Point(134, 211)
        Me.txtRecWO.MaxLength = 30
        Me.txtRecWO.Name = "txtRecWO"
        Me.txtRecWO.Size = New System.Drawing.Size(242, 20)
        Me.txtRecWO.TabIndex = 4
        Me.txtRecWO.Text = ""
        '
        'pnlShip
        '
        Me.pnlShip.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.pnlShip.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label15})
        Me.pnlShip.Location = New System.Drawing.Point(952, 496)
        Me.pnlShip.Name = "pnlShip"
        Me.pnlShip.Size = New System.Drawing.Size(680, 520)
        Me.pnlShip.TabIndex = 6
        Me.pnlShip.Visible = False
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Black
        Me.Label15.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Lime
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(680, 40)
        Me.Label15.TabIndex = 100
        Me.Label15.Text = "SHIP"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmMessConsole
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(1028, 550)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlShip, Me.pnlAdmin, Me.Panel2, Me.lblHeader, Me.pnlLabel, Me.pnlReceive})
        Me.Name = "frmMessConsole"
        Me.Text = "Messaging Operations Console"
        Me.pnlLabel.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.pnlAdmin.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.pnlReceive.ResumeLayout(False)
        Me.gbCustData.ResumeLayout(False)
        Me.pnlRecAMCapCode.ResumeLayout(False)
        Me.pnlRecUMCapCode.ResumeLayout(False)
        Me.pnlShip.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Protected Overrides Sub Finalize()
        'Dispose all object
        DisposeAllGlobalObjs()

        MyBase.Finalize()
    End Sub

    '*********************************************************
    Private Sub cmdAdmin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdmin.Click
        Try
            'check for user permition
            ShowHidePanels(iPanelAdminIndex)


        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Admin Button Clicked", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*********************************************************
    Private Sub cmdReceive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReceive.Click
        Try
            If Me.cmbRecCustomer.Items.Count = 0 Then
                LoadCustomers(Me.cmbRecCustomer)
            End If
            If Me.cmbRecModel.Items.Count = 0 Then
                LoadModels(Me.cmbRecModel)
            End If

            ShowHidePanels(iPanelRecIndex)
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Admin Button Clicked", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*********************************************************
    Private Sub cmdLabeling_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLabeling.Click
        Try
            ShowHidePanels(iPanelLabelIndex)
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Admin Button Clicked", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*********************************************************
    Private Sub cmdShip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShip.Click
        Try
            ShowHidePanels(iPanelShipIndex)
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Admin Button Clicked", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*********************************************************
    Private Sub ShowHidePanels(ByVal iPanelIndex As Integer)

        Try
            MakeAllPanelsInvisible()
            Select Case iPanelIndex
                Case 1
                    If booMessAdminSecure = False Then
                        booMessAdminSecure = UserHasAccessPrivilege(iPanelIndex)
                    End If

                    If booMessAdminSecure = True Then
                        Me.pnlAdmin.Visible = True

                        If IsNothing(Me.objMessAdmin) Then
                            Me.objMessAdmin = New PSS.Data.Buisness.MessAdmin()
                        End If
                    End If

                Case 2
                    If booMessRecSecure = False Then
                        booMessRecSecure = UserHasAccessPrivilege(iPanelIndex)
                    End If
                    If booMessRecSecure = True Then
                        Me.pnlReceive.Visible = True

                        If IsNothing(Me.objMessReceive) Then
                            Me.objMessReceive = New PSS.Data.Buisness.MessReceive()
                        End If
                    End If
                Case 3
                    If booMessLabelSecure = False Then
                        booMessLabelSecure = UserHasAccessPrivilege(iPanelIndex)
                    End If
                    If booMessLabelSecure = True Then
                        Me.pnlLabel.Visible = True

                        If IsNothing(Me.objMessLabel) Then
                            Me.objMessLabel = New PSS.Data.Buisness.MessLabel()
                        End If
                    End If
                Case 4
                    If booMessShipSecure = False Then
                        booMessShipSecure = UserHasAccessPrivilege(iPanelIndex)
                    End If
                    If booMessShipSecure = True Then
                        Me.pnlShip.Visible = True

                        If IsNothing(Me.objMessShip) Then
                            Me.objMessShip = New PSS.Data.Buisness.MessShip()
                        End If
                    End If
            End Select

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    '*********************************************************
    Private Sub MakeAllPanelsInvisible()
        Me.pnlAdmin.Visible = False
        Me.pnlReceive.Visible = False
        Me.pnlLabel.Visible = False
        Me.pnlShip.Visible = False
    End Sub

    '*********************************************************
    Private Sub DisposeAllGlobalObjs()
        If Not IsNothing(Me.objMessAdmin) Then
            Me.objMessAdmin = Nothing
        End If
        If Not IsNothing(Me.objMessReceive) Then
            Me.objMessReceive = Nothing
        End If
        If Not IsNothing(Me.objMessLabel) Then
            Me.objMessLabel = Nothing
        End If
        If Not IsNothing(Me.objMessShip) Then
            Me.objMessShip = Nothing
        End If
    End Sub


    '*********************************************************
    Private Function UserHasAccessPrivilege(ByVal iPanelIndex As Integer) As Boolean
        Dim booResult As Boolean = False

        Try
            Select Case iPanelIndex
                Case 1
                    If ApplicationUser.GetPermission("MessAdmin") > 0 Then
                        booResult = True
                    End If
                Case 2
                    If ApplicationUser.GetPermission("MessReceive") > 0 Then
                        booResult = True
                    End If
                Case 3
                    If ApplicationUser.GetPermission("MessLabel") > 0 Then
                        booResult = True
                    End If
                Case 4
                    If ApplicationUser.GetPermission("MessShip") > 0 Then
                        booResult = True
                    End If
            End Select

            Return booResult
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '*********************************************************
    Private Sub frmMessConsole_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer = 0

        Try
            i = CheckIfMachineTiedToLine()
            If i = 0 Then
                Throw New Exception("Machine is not associated with any 'Line'. Can't continue.")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*********************************************************
    Private Function CheckIfMachineTiedToLine() As Integer
        Dim dt1 As DataTable
        Dim R1 As DataRow
        'Dim objMisc As New PSS.Data.Buisness.Misc()

        Try
            'dt1 = objMisc.CheckIfMachineTiedToLine(strMachine)
            'If dt1.Rows.Count = 0 Then
            '    Return 0
            'End If

            'For Each R1 In dt1.Rows
            '    iGroup_ID = R1("Group_ID")
            '    strGroup = Trim(R1("Group_Desc"))
            '    iLine_ID = R1("Line_ID")
            '    strLineNumber = Trim(R1("Line_Number"))
            '    iLineSide_ID = R1("LineSide_ID")
            '    strLineSide = Trim(R1("LineSide_Desc"))
            '    'strBin = Trim(R1("WC_Location"))
            '    iWCLocation_ID = R1("WCLocation_ID")
            'Next R1

            'Me.lblGroup.Text = "Group: " & strGroup
            'Me.lblLine.Text = strLineNumber
            'Me.lblLineSide.Text = strLineSide
            Me.lblMachine.Text = "Machine: " & strMachine
            Me.lblUserName.Text = "User: " & strUserName
            Me.lblShift.Text = "Shift: " & iShiftID
            Me.lblWorkDate.Text = "Date: " & Format(CDate(strWorkDate), "MM/dd/yyyy hh:mm:ss")

            Return 1
        Catch ex As Exception
            Throw ex
        Finally
            R1 = Nothing
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
            'objMisc = Nothing
        End Try
    End Function

    '*********************************************************
    Private Sub LoadCustomers(ByRef cmbCust As ComboBox)
        Dim dtCustomers As New DataTable()
        Dim objMisc As New PSS.Data.Buisness.Misc()

        Try
            dtCustomers = objMisc.GetCustomers(1)
            With cmbCust
                .DataSource = dtCustomers.DefaultView
                .DisplayMember = dtCustomers.Columns("cust_name1").ToString
                .ValueMember = dtCustomers.Columns("Cust_ID").ToString
                .SelectedValue = 0
            End With
        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(dtCustomers) Then
                dtCustomers.Dispose()
                dtCustomers = Nothing
            End If
            objMisc = Nothing
        End Try
    End Sub

    '*********************************************************
    Private Sub LoadModels(ByRef cmbModel As ComboBox)
        Dim dtModels As New DataTable()
        Dim objMisc As New PSS.Data.Buisness.Misc()

        Try
            dtModels = objMisc.GetModels(1, 0)
            With cmbModel
                .DataSource = dtModels.DefaultView
                .DisplayMember = dtModels.Columns("Model_Desc").ToString
                .ValueMember = dtModels.Columns("Model_ID").ToString
                .SelectedValue = 0
            End With

        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(dtModels) Then
                dtModels.Dispose()
                dtModels = Nothing
            End If
            objMisc = Nothing
        End Try
    End Sub

    '*********************************************************
    Private Sub LoadLocations(ByRef cmbLoc As ComboBox, _
                                ByVal iCust_id As Integer)
        Dim dtLoc As DataTable
        Dim R1 As DataRow
        Dim objMisc As New PSS.Data.Buisness.Misc()

        Try
            If iCust_id = 0 Then
                Exit Sub
            End If

            dtLoc = objMisc.GetLocations(iCust_id)
            '**************************************************
            'Fill the Customer combo box
            '**************************************************
            With cmbLoc
                .DataSource = dtLoc.DefaultView
                .ValueMember = dtLoc.Columns("Loc_id").ToString
                .DisplayMember = dtLoc.Columns("Loc_Name").ToString
                If dtLoc.Rows.Count = 2 Then
                    For Each R1 In dtLoc.Rows
                        If R1("Loc_id") <> 0 Then
                            .SelectedValue = R1("Loc_id")
                            Me.LocationSelectionChangeCommited()
                        End If
                    Next R1
                Else
                    .SelectedValue = 0
                End If

            End With
            '**************************************************
        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(dtLoc) Then
                dtLoc.Dispose()
                dtLoc = Nothing
            End If
            objMisc = Nothing
        End Try
    End Sub

    '*********************************************************
    Private Sub LoadPOs(ByRef cmbPO As ComboBox, _
                       ByVal iLoc_id As Integer)
        Dim dtPO As DataTable

        Try
            If iLoc_id = 0 Then
                Exit Sub
            End If

            dtPO = Me.objMessReceive.GetPurchaseOrders(iLoc_id)
            '**************************************************
            'Fill the Customer combo box
            '**************************************************
            With cmbPO
                .DataSource = dtPO.DefaultView
                .ValueMember = dtPO.Columns("PO_id").ToString
                .DisplayMember = dtPO.Columns("DisplayDesc").ToString
                .SelectedValue = 0
            End With
            '**************************************************
        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(dtPO) Then
                dtPO.Dispose()
                dtPO = Nothing
            End If
        End Try
    End Sub

    '*********************************************************
    Private Sub cmbRecCustomer_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbRecCustomer.SelectionChangeCommitted
        If Me.cmbRecCustomer.SelectedValue > 0 Then
            'Populate location
            LoadLocations(Me.cmbRecLocation, Me.cmbRecCustomer.SelectedValue)

            'Make controls invisible
            ShowHideRecControls()

            'Change text in groupbox
            Select Case Me.cmbRecCustomer.SelectedValue
                Case 1
                    Me.gbCustData.Text = "USA Mobility WO Related Data"
                    Me.pnlUMCapCode.Visible = True
                Case 14
                    Me.gbCustData.Text = "American Messaging Device Related Data"
                Case 16
                    Me.gbCustData.Text = "American Messaging (SBC Paging) Device Related Data"
                Case 20
                    Me.gbCustData.Text = "American Messaging II Device Related Data"
            End Select

            Me.cmbRecLocation.Focus()
        ElseIf Me.cmbRecCustomer.SelectedValue = 0 Then
            Me.cmbRecLocation.SelectedValue = 0
            Me.lblRecAddress.Text = ""
            Me.cmbRecLocation.SelectedValue = 0
        End If
    End Sub

    '*********************************************************
    Private Sub ShowHideRecControls()

    End Sub

    '*********************************************************
    Private Sub cmbRecLocation_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbRecLocation.SelectionChangeCommitted
        Try
            If Me.cmbRecLocation.SelectedValue > 0 Then
                Me.LocationSelectionChangeCommited()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Select Location", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*********************************************************
    Private Sub LocationSelectionChangeCommited()
        Try
            '****************
            'Display Address
            '****************
            Me.lblRecAddress.Text = Me.objMessReceive.GetCustLocAddress(Me.cmbRecLocation.SelectedValue)

            '*************************
            'populate purchase orders
            '*************************
            Me.LoadPOs(Me.cmbRecPO, Me.cmbRecLocation.SelectedValue)

            Me.cmbRecModel.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*********************************************************
    Private Sub cmbRecModel_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbRecModel.SelectionChangeCommitted
        If Me.cmbRecModel.SelectedValue > 0 Then
            Me.txtRecWO.Focus()
        End If
    End Sub
    '*********************************************************
    Private Sub txtRecWO_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRecWO.Leave
        Dim dt1, dt2 As DataTable
        Dim R1 As DataRow

        Try
            If Trim(Me.txtRecWO.Text) = "" Then
                Exit Sub
            End If
            If Me.cmbRecLocation.SelectedValue = 0 Then
                Exit Sub
            End If
            '**************************************
            'Based on Customer pull data
            Select Case Me.cmbRecCustomer.SelectedValue
                Case 1

                Case 2

                Case Else


            End Select






            dt1 = objMessReceive.GetUSAMobilityWOInfo(Trim(Me.txtRecWO.Text), Me.cmbRecLocation.SelectedValue)

            If dt1.Rows.Count = 1 Then
                R1 = dt1.Rows(0)
            ElseIf dt1.Rows.Count > 1 Then
                Throw New Exception("More than one Work Order found for the criterion.")
            Else
                Throw New Exception("Work Order not found.")
            End If

            'WO_ID
            If Not IsDBNull(R1("wo_id")) Then
                iGWOID = R1("wo_id")
            Else
                iGWOID = 0
            End If

            'Cap Low
            If Not IsDBNull(R1("USA_CapLow")) Then
                Me.lblRecUMCapLow.Text = R1("USA_CapLow")
            Else
                Me.lblRecUMCapLow.Text = ""
            End If

            If Not IsDBNull(R1("USA_CapHigh")) Then
                Me.lblRecUMCapHigh.Text = R1("USA_CapHigh")
            Else
                Me.lblRecUMCapHigh.Text = ""
            End If

            'WO_ID
            If Not IsDBNull(R1("wo_id")) Then
                iGWOID = R1("wo_id")
            End If

            'WO_ID
            If Not IsDBNull(R1("wo_id")) Then
                iGWOID = R1("wo_id")
            End If

            'WO_ID
            If Not IsDBNull(R1("wo_id")) Then
                iGWOID = R1("wo_id")
            End If
            '**************************************
            'Get Number of Devices Rcvd for the WO
            Me.lblRecWOQty.Text = objMessReceive.GetWORcvdQty(iGWOID)


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally

        End Try



    End Sub


    '*********************************************************
    Private Sub cmbRecPO_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbRecPO.SelectionChangeCommitted

    End Sub

    '*********************************************************
    Private Sub txtRecWOMemo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRecWOMemo.KeyUp

    End Sub

    '*********************************************************
    Private Sub txtRecDevSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRecDevSN.KeyUp
        Dim booDuplicate As Boolean

        If e.KeyValue = 13 Then

            Try
                If Trim(Me.txtRecDevSN.Text) = "" Then
                    Exit Sub
                End If

                '**********************
                '1:: Check Duplicate
                '**********************
                booDuplicate = IsDuplicate(Trim(Me.txtRecDevSN.Text), Me.lstRecDevices)

                If booDuplicate = True Then
                    Exit Sub
                End If
                '**********************
                'Add to listbox
                '**********************
                Me.lstRecDevices.Items.Add(UCase(Trim(Me.txtRecDevSN.Text)))


            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Scan SN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.txtRecDevSN.Text = ""
            End Try

        End If
    End Sub

    '*********************************************************
    Private Function IsDuplicate(ByVal strSN As String, _
                                ByVal lstListBox As ListBox) As Boolean
        Dim booResult As Boolean = False
        Dim i As Integer = 0

        Try
            If lstListBox.Items.Count > 0 Then
                For i = 0 To lstListBox.Items.Count - 1
                    If UCase(Trim(strSN)) = lstListBox.Items.Item(i) Then
                        MessageBox.Show("This device is already scanned in. Try another one.", "Device SN scan", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        booResult = True
                        Exit For
                    End If
                Next i
            End If

            Return booResult
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '*********************************************************
    Private Sub btnRecClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecClear.Click
        Try
            ClearOneItemInListBox(Me.lstRecDevices)
            Me.lblRecCount.Text = lstRecDevices.Items.Count
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Remove a SN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*********************************************************
    Private Sub btnRecClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecClearAll.Click
        Try
            ClearAllItemInListBox(Me.lstRecDevices)

            Me.lblRecCount.Text = lstRecDevices.Items.Count
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Remove all SN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*********************************************************
    Private Sub ClearOneItemInListBox(ByRef lstListBox As ListBox)
        Try
            If Me.lstRecDevices.SelectedIndex <> -1 Then    'If nothing is selected
                Me.lstRecDevices.Items.RemoveAt(Me.lstRecDevices.SelectedIndex)
                Me.lstRecDevices.Refresh()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*********************************************************
    Private Sub ClearAllItemInListBox(ByRef lstListBox As ListBox)
        Try
            If lstListBox.Items.Count > 0 Then
                lstListBox.Items.Clear()
                lstRecDevices.Refresh()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*********************************************************










    Friend WithEvents Label21 As System.Windows.Forms.Label

    Private Sub pnlUSAMobCapCode_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlRecUMCapCode.Paint

    End Sub

    Private Sub cmdRecTray_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRecTray.Click

    End Sub

    Private Sub pnlReceive_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlReceive.Paint

    End Sub
    Friend WithEvents pnlRecUMCapCode As System.Windows.Forms.Panel
    Friend WithEvents pnlRecAMCapCode As System.Windows.Forms.Panel
End Class
