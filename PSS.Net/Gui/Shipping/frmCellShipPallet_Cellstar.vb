Imports Microsoft.VisualBasic

Public Class frmCellShipPallet_Cellstar
    Inherits System.Windows.Forms.Form
    Private objMisc As PSS.Data.Buisness.Misc
    Private iLine_ID As Integer = 0
    Private iGroup_ID As Integer = 0
    Private strLineNumber As String = ""
    Private strGroup As String = ""
    Private iLineSide_ID As Integer = 0
    Private strLineSide As String = ""
    Private strMachine As String = System.Net.Dns.GetHostName
    Private strUserName As String = PSS.Core.Global.ApplicationUser.User
    Private iUserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
    Private iShiftID As Integer = PSS.Core.Global.ApplicationUser.IDShift
    Private strWorkDate As String = PSS.Core.Global.ApplicationUser.Workdate
    Private strBin As String = ""
    Private iModel_ID As Integer = 0
    Private iWCLocation_ID As Integer = 0
    Private strShortModelName As String = ""
    Private strPalletName As String = ""
    Private strPalletNameInitials As String = ""
    Private iPallet_ID As Integer = 0
    Private strShipType As String = ""
    Private strSkuLength As String = ""
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        objMisc = New PSS.Data.Buisness.Misc()
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
    Private WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblShift As System.Windows.Forms.Label
    Friend WithEvents lblWorkDate As System.Windows.Forms.Label
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents lblLine As System.Windows.Forms.Label
    Friend WithEvents lblGroup As System.Windows.Forms.Label
    Friend WithEvents lblMachine As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents cmbModel As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbShipType As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSN As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents lstDevices As System.Windows.Forms.ListBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblLineSide As System.Windows.Forms.Label
    Friend WithEvents lblBin As System.Windows.Forms.Label
    Friend WithEvents PanelSKULen As System.Windows.Forms.Panel
    Friend WithEvents cmdCreatePallet As System.Windows.Forms.Button
    Friend WithEvents cmbSkuLen As PSS.Gui.Controls.ComboBox
    Friend WithEvents lblPalletName As System.Windows.Forms.Label
    Friend WithEvents panelPallet As System.Windows.Forms.Panel
    Friend WithEvents grdPallets As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents panelShipType As System.Windows.Forms.Panel
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents panelCriterion As System.Windows.Forms.Panel
    Friend WithEvents cmdClosePallet As System.Windows.Forms.Button
    Friend WithEvents btnClearAll As System.Windows.Forms.Button
    Friend WithEvents cmdReopenPallet As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblUserProd As System.Windows.Forms.Label
    Friend WithEvents lblLineProd As System.Windows.Forms.Label
    Friend WithEvents lblGroupProd As System.Windows.Forms.Label
    Friend WithEvents grdProd As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblShiftProd As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents PanelPalletList As System.Windows.Forms.Panel
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lblWeeklyGroupProd As System.Windows.Forms.Label
    Friend WithEvents lblWeeklyLineProd As System.Windows.Forms.Label
    Friend WithEvents lblWeeklyUserProd As System.Windows.Forms.Label
    Friend WithEvents lblWeeklyShiftProd As System.Windows.Forms.Label
    Friend WithEvents grdWeeklyProd As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtDevSN As System.Windows.Forms.TextBox
    Friend WithEvents cmdReprintPalletLabel As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCellShipPallet_Cellstar))
        Dim GridLines1 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
        Dim GridLines2 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
        Dim GridLines3 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
        Me.lbl = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblBin = New System.Windows.Forms.Label()
        Me.lblLineSide = New System.Windows.Forms.Label()
        Me.lblMachine = New System.Windows.Forms.Label()
        Me.lblGroup = New System.Windows.Forms.Label()
        Me.lblLine = New System.Windows.Forms.Label()
        Me.lblShift = New System.Windows.Forms.Label()
        Me.lblWorkDate = New System.Windows.Forms.Label()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.cmbModel = New PSS.Gui.Controls.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.cmbShipType = New PSS.Gui.Controls.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbSkuLen = New PSS.Gui.Controls.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.panelPallet = New System.Windows.Forms.Panel()
        Me.txtDevSN = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmdClosePallet = New System.Windows.Forms.Button()
        Me.btnClearAll = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.lstDevices = New System.Windows.Forms.ListBox()
        Me.txtSN = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblPalletName = New System.Windows.Forms.Label()
        Me.cmdReopenPallet = New System.Windows.Forms.Button()
        Me.PanelSKULen = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdCreatePallet = New System.Windows.Forms.Button()
        Me.grdPallets = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.panelShipType = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.panelCriterion = New System.Windows.Forms.Panel()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.grdWeeklyProd = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.lblWeeklyGroupProd = New System.Windows.Forms.Label()
        Me.lblWeeklyLineProd = New System.Windows.Forms.Label()
        Me.lblWeeklyUserProd = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblWeeklyShiftProd = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblGroupProd = New System.Windows.Forms.Label()
        Me.lblLineProd = New System.Windows.Forms.Label()
        Me.lblUserProd = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblShiftProd = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.grdProd = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.PanelPalletList = New System.Windows.Forms.Panel()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.cmdReprintPalletLabel = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.panelPallet.SuspendLayout()
        Me.PanelSKULen.SuspendLayout()
        CType(Me.grdPallets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelShipType.SuspendLayout()
        Me.panelCriterion.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.grdWeeklyProd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.grdProd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelPalletList.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl
        '
        Me.lbl.BackColor = System.Drawing.Color.Black
        Me.lbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.Yellow
        Me.lbl.Location = New System.Drawing.Point(3, 2)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(229, 70)
        Me.lbl.TabIndex = 7
        Me.lbl.Text = "BUILD CELL SHIP PALLETS"
        Me.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblBin, Me.lblLineSide, Me.lblMachine, Me.lblGroup, Me.lblLine, Me.lblShift, Me.lblWorkDate, Me.lblUserName})
        Me.Panel2.Location = New System.Drawing.Point(235, 1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(614, 71)
        Me.Panel2.TabIndex = 87
        '
        'lblBin
        '
        Me.lblBin.BackColor = System.Drawing.Color.Transparent
        Me.lblBin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBin.ForeColor = System.Drawing.Color.Lime
        Me.lblBin.Location = New System.Drawing.Point(200, 25)
        Me.lblBin.Name = "lblBin"
        Me.lblBin.Size = New System.Drawing.Size(178, 16)
        Me.lblBin.TabIndex = 94
        Me.lblBin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel6.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmbModel, Me.Label5, Me.Button4})
        Me.Panel6.Location = New System.Drawing.Point(234, 74)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(272, 66)
        Me.Panel6.TabIndex = 88
        '
        'cmbModel
        '
        Me.cmbModel.AutoComplete = True
        Me.cmbModel.BackColor = System.Drawing.SystemColors.Window
        Me.cmbModel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbModel.ForeColor = System.Drawing.Color.Black
        Me.cmbModel.Location = New System.Drawing.Point(100, 20)
        Me.cmbModel.Name = "cmbModel"
        Me.cmbModel.Size = New System.Drawing.Size(143, 21)
        Me.cmbModel.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(38, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 16)
        Me.Label5.TabIndex = 81
        Me.Label5.Text = "Model:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(144, 245)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(200, 31)
        Me.Button4.TabIndex = 66
        Me.Button4.TabStop = False
        Me.Button4.Text = "Generate Report"
        '
        'cmbShipType
        '
        Me.cmbShipType.AutoComplete = True
        Me.cmbShipType.BackColor = System.Drawing.SystemColors.Window
        Me.cmbShipType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbShipType.ForeColor = System.Drawing.Color.Black
        Me.cmbShipType.Items.AddRange(New Object() {"REFURBISHED", "RUR", "RTM"})
        Me.cmbShipType.Location = New System.Drawing.Point(92, 12)
        Me.cmbShipType.Name = "cmbShipType"
        Me.cmbShipType.Size = New System.Drawing.Size(143, 21)
        Me.cmbShipType.TabIndex = 84
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 16)
        Me.Label1.TabIndex = 85
        Me.Label1.Text = "Ship Type:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbSkuLen
        '
        Me.cmbSkuLen.AutoComplete = True
        Me.cmbSkuLen.BackColor = System.Drawing.SystemColors.Window
        Me.cmbSkuLen.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSkuLen.ForeColor = System.Drawing.Color.Black
        Me.cmbSkuLen.Items.AddRange(New Object() {"LONG", "SHORT"})
        Me.cmbSkuLen.Location = New System.Drawing.Point(92, 12)
        Me.cmbSkuLen.Name = "cmbSkuLen"
        Me.cmbSkuLen.Size = New System.Drawing.Size(143, 21)
        Me.cmbSkuLen.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(-1, 13)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 16)
        Me.Label8.TabIndex = 83
        Me.Label8.Text = "SKU Length:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'panelPallet
        '
        Me.panelPallet.BackColor = System.Drawing.Color.LightSteelBlue
        Me.panelPallet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panelPallet.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtDevSN, Me.Label10, Me.cmdClosePallet, Me.btnClearAll, Me.btnClear, Me.lstDevices, Me.txtSN, Me.Label2, Me.lblCount, Me.Label3, Me.lblPalletName})
        Me.panelPallet.Location = New System.Drawing.Point(508, 74)
        Me.panelPallet.Name = "panelPallet"
        Me.panelPallet.Size = New System.Drawing.Size(340, 382)
        Me.panelPallet.TabIndex = 94
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
        Me.btnClearAll.Location = New System.Drawing.Point(180, 175)
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
        Me.btnClear.Location = New System.Drawing.Point(180, 136)
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
        'txtSN
        '
        Me.txtSN.Location = New System.Drawing.Point(11, 63)
        Me.txtSN.Name = "txtSN"
        Me.txtSN.Size = New System.Drawing.Size(156, 20)
        Me.txtSN.TabIndex = 88
        Me.txtSN.Text = ""
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(11, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 16)
        Me.Label2.TabIndex = 87
        Me.Label2.Text = "Box IMEI:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCount
        '
        Me.lblCount.BackColor = System.Drawing.Color.Black
        Me.lblCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCount.ForeColor = System.Drawing.Color.Lime
        Me.lblCount.Location = New System.Drawing.Point(205, 76)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(98, 32)
        Me.lblCount.TabIndex = 97
        Me.lblCount.Text = "0"
        Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(225, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 16)
        Me.Label3.TabIndex = 96
        Me.Label3.Text = "Count"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPalletName
        '
        Me.lblPalletName.BackColor = System.Drawing.Color.Black
        Me.lblPalletName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPalletName.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPalletName.ForeColor = System.Drawing.Color.Lime
        Me.lblPalletName.Location = New System.Drawing.Point(10, 5)
        Me.lblPalletName.Name = "lblPalletName"
        Me.lblPalletName.Size = New System.Drawing.Size(318, 32)
        Me.lblPalletName.TabIndex = 98
        Me.lblPalletName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdReopenPallet
        '
        Me.cmdReopenPallet.BackColor = System.Drawing.Color.Red
        Me.cmdReopenPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReopenPallet.ForeColor = System.Drawing.Color.White
        Me.cmdReopenPallet.Location = New System.Drawing.Point(27, 122)
        Me.cmdReopenPallet.Name = "cmdReopenPallet"
        Me.cmdReopenPallet.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdReopenPallet.Size = New System.Drawing.Size(213, 32)
        Me.cmdReopenPallet.TabIndex = 104
        Me.cmdReopenPallet.Text = "REOPEN  PALLET"
        '
        'PanelSKULen
        '
        Me.PanelSKULen.BackColor = System.Drawing.Color.LightSteelBlue
        Me.PanelSKULen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelSKULen.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button1, Me.Label8, Me.cmbSkuLen})
        Me.PanelSKULen.Location = New System.Drawing.Point(8, 63)
        Me.PanelSKULen.Name = "PanelSKULen"
        Me.PanelSKULen.Size = New System.Drawing.Size(253, 48)
        Me.PanelSKULen.TabIndex = 95
        Me.PanelSKULen.Visible = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(144, 245)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(200, 31)
        Me.Button1.TabIndex = 66
        Me.Button1.TabStop = False
        Me.Button1.Text = "Generate Report"
        '
        'cmdCreatePallet
        '
        Me.cmdCreatePallet.BackColor = System.Drawing.Color.Green
        Me.cmdCreatePallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCreatePallet.ForeColor = System.Drawing.Color.White
        Me.cmdCreatePallet.Location = New System.Drawing.Point(27, 122)
        Me.cmdCreatePallet.Name = "cmdCreatePallet"
        Me.cmdCreatePallet.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCreatePallet.Size = New System.Drawing.Size(214, 32)
        Me.cmdCreatePallet.TabIndex = 100
        Me.cmdCreatePallet.Text = "CREATE PALLET"
        Me.cmdCreatePallet.Visible = False
        '
        'grdPallets
        '
        Me.grdPallets.AllowColMove = False
        Me.grdPallets.AllowColSelect = False
        Me.grdPallets.AllowFilter = False
        Me.grdPallets.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.grdPallets.AllowSort = False
        Me.grdPallets.AllowUpdate = False
        Me.grdPallets.AllowUpdateOnBlur = False
        Me.grdPallets.CaptionHeight = 17
        Me.grdPallets.CollapseColor = System.Drawing.Color.White
        Me.grdPallets.DataChanged = False
        Me.grdPallets.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.grdPallets.ExpandColor = System.Drawing.Color.White
        Me.grdPallets.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdPallets.ForeColor = System.Drawing.Color.White
        Me.grdPallets.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdPallets.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.grdPallets.Location = New System.Drawing.Point(27, 9)
        Me.grdPallets.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
        Me.grdPallets.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.grdPallets.Name = "grdPallets"
        Me.grdPallets.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdPallets.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdPallets.PreviewInfo.ZoomFactor = 75
        Me.grdPallets.PrintInfo.ShowOptionsDialog = False
        Me.grdPallets.RecordSelectorWidth = 16
        GridLines1.Color = System.Drawing.Color.DarkGray
        GridLines1.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single
        Me.grdPallets.RowDivider = GridLines1
        Me.grdPallets.RowHeight = 20
        Me.grdPallets.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.grdPallets.ScrollTips = False
        Me.grdPallets.Size = New System.Drawing.Size(214, 106)
        Me.grdPallets.TabIndex = 101
        Me.grdPallets.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:White;Ba" & _
        "ckColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Center;ForeColor:W" & _
        "hite;}Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt, style=Bold;BackColor:Lig" & _
        "htSteelBlue;ForeColor:White;AlignVert:Center;}HighlightRow{ForeColor:HighlightTe" & _
        "xt;BackColor:Highlight;}Style12{}OddRow{BackColor:LightSteelBlue;}RecordSelector" & _
        "{AlignImage:Center;ForeColor:White;}Style13{}Heading{Wrap:True;Font:Microsoft Sa" & _
        "ns Serif, 8.25pt, style=Bold;AlignHorz:Center;AlignVert:Center;Border:Raised,,1," & _
        " 1, 1, 1;ForeColor:Blue;BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style" & _
        "11{}Style14{}Style15{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.Merge" & _
        "View AllowColMove=""False"" AllowColSelect=""False"" Name="""" AllowRowSizing=""None"" C" & _
        "aptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=" & _
        """DottedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidth=""16"" VerticalScrollGr" & _
        "oup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 210, 102</ClientRect><Border" & _
        "Side>0</BorderSide><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle par" & _
        "ent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterB" & _
        "arStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style" & _
        "3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me" & _
        "=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyl" & _
        "e parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><Re" & _
        "cordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""" & _
        "Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1TrueDBGr" & _
        "id.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=" & _
        """Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Hea" & _
        "ding"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Norm" & _
        "al"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" " & _
        "me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal""" & _
        " me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Norm" & _
        "al"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSpl" & _
        "its>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelW" & _
        "idth>16</DefaultRecSelWidth><ClientArea>0, 0, 210, 102</ClientArea></Blob>"
        '
        'panelShipType
        '
        Me.panelShipType.BackColor = System.Drawing.Color.LightSteelBlue
        Me.panelShipType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panelShipType.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button3, Me.Label1, Me.cmbShipType})
        Me.panelShipType.Location = New System.Drawing.Point(8, 6)
        Me.panelShipType.Name = "panelShipType"
        Me.panelShipType.Size = New System.Drawing.Size(253, 48)
        Me.panelShipType.TabIndex = 102
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(144, 245)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(200, 31)
        Me.Button3.TabIndex = 66
        Me.Button3.TabStop = False
        Me.Button3.Text = "Generate Report"
        '
        'panelCriterion
        '
        Me.panelCriterion.BackColor = System.Drawing.Color.LightSteelBlue
        Me.panelCriterion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panelCriterion.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button5, Me.panelShipType, Me.PanelSKULen, Me.cmdCreatePallet})
        Me.panelCriterion.Location = New System.Drawing.Point(234, 142)
        Me.panelCriterion.Name = "panelCriterion"
        Me.panelCriterion.Size = New System.Drawing.Size(272, 166)
        Me.panelCriterion.TabIndex = 103
        Me.panelCriterion.Visible = False
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(144, 245)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(200, 31)
        Me.Button5.TabIndex = 66
        Me.Button5.TabStop = False
        Me.Button5.Text = "Generate Report"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label20, Me.Panel4, Me.Label4, Me.Panel3})
        Me.Panel1.Location = New System.Drawing.Point(3, 74)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(229, 454)
        Me.Panel1.TabIndex = 107
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(2, 232)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(150, 16)
        Me.Label20.TabIndex = 113
        Me.Label20.Text = "Weekly Production:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel4.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label21, Me.grdWeeklyProd, Me.lblWeeklyGroupProd, Me.lblWeeklyLineProd, Me.lblWeeklyUserProd, Me.Label15, Me.Label16, Me.Label17, Me.Label18, Me.lblWeeklyShiftProd})
        Me.Panel4.Location = New System.Drawing.Point(5, 249)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(216, 198)
        Me.Panel4.TabIndex = 112
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(3, 78)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(180, 16)
        Me.Label21.TabIndex = 111
        Me.Label21.Text = "Line Production by Model:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grdWeeklyProd
        '
        Me.grdWeeklyProd.AllowColMove = False
        Me.grdWeeklyProd.AllowColSelect = False
        Me.grdWeeklyProd.AllowFilter = False
        Me.grdWeeklyProd.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.grdWeeklyProd.AllowSort = False
        Me.grdWeeklyProd.AllowUpdate = False
        Me.grdWeeklyProd.AllowUpdateOnBlur = False
        Me.grdWeeklyProd.CaptionHeight = 17
        Me.grdWeeklyProd.CollapseColor = System.Drawing.Color.Black
        Me.grdWeeklyProd.DataChanged = False
        Me.grdWeeklyProd.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.grdWeeklyProd.ExpandColor = System.Drawing.Color.Black
        Me.grdWeeklyProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdWeeklyProd.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdWeeklyProd.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
        Me.grdWeeklyProd.Location = New System.Drawing.Point(3, 94)
        Me.grdWeeklyProd.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
        Me.grdWeeklyProd.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.grdWeeklyProd.Name = "grdWeeklyProd"
        Me.grdWeeklyProd.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdWeeklyProd.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdWeeklyProd.PreviewInfo.ZoomFactor = 75
        Me.grdWeeklyProd.PrintInfo.ShowOptionsDialog = False
        Me.grdWeeklyProd.RecordSelectorWidth = 16
        GridLines2.Color = System.Drawing.Color.DarkGray
        GridLines2.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single
        Me.grdWeeklyProd.RowDivider = GridLines2
        Me.grdWeeklyProd.RowHeight = 20
        Me.grdWeeklyProd.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.grdWeeklyProd.ScrollTips = False
        Me.grdWeeklyProd.Size = New System.Drawing.Size(205, 96)
        Me.grdWeeklyProd.TabIndex = 110
        Me.grdWeeklyProd.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
        "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
        "er;}Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt, style=Bold;BackColor:Black" & _
        ";AlignVert:Center;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Sty" & _
        "le12{}OddRow{BackColor:LightSteelBlue;}RecordSelector{AlignImage:Center;}Style13" & _
        "{}Heading{Wrap:True;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Cent" & _
        "er;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:C" & _
        "enter;}Style8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style1{}</Data" & _
        "></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSe" & _
        "lect=""False"" Name="""" AllowRowSizing=""None"" CaptionHeight=""17"" ColumnCaptionHeigh" & _
        "t=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWid" & _
        "th=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><C" & _
        "lientRect>0, 0, 201, 92</ClientRect><BorderSide>0</BorderSide><CaptionStyle pare" & _
        "nt=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowSt" & _
        "yle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style1" & _
        "3"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""S" & _
        "tyle12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent" & _
        "=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><Od" & _
        "dRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelec" & _
        "tor"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent" & _
        "=""Normal"" me=""Style1"" /></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><S" & _
        "tyle parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent" & _
        "=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""H" & _
        "eading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""No" & _
        "rmal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""No" & _
        "rmal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading" & _
        """ me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""C" & _
        "aption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horz" & _
        "Splits><Layout>None</Layout><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientAr" & _
        "ea>0, 0, 201, 92</ClientArea></Blob>"
        '
        'lblWeeklyGroupProd
        '
        Me.lblWeeklyGroupProd.BackColor = System.Drawing.Color.Transparent
        Me.lblWeeklyGroupProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWeeklyGroupProd.ForeColor = System.Drawing.Color.Lime
        Me.lblWeeklyGroupProd.Location = New System.Drawing.Point(140, 57)
        Me.lblWeeklyGroupProd.Name = "lblWeeklyGroupProd"
        Me.lblWeeklyGroupProd.Size = New System.Drawing.Size(64, 16)
        Me.lblWeeklyGroupProd.TabIndex = 89
        Me.lblWeeklyGroupProd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWeeklyLineProd
        '
        Me.lblWeeklyLineProd.BackColor = System.Drawing.Color.Transparent
        Me.lblWeeklyLineProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWeeklyLineProd.ForeColor = System.Drawing.Color.Lime
        Me.lblWeeklyLineProd.Location = New System.Drawing.Point(140, 22)
        Me.lblWeeklyLineProd.Name = "lblWeeklyLineProd"
        Me.lblWeeklyLineProd.Size = New System.Drawing.Size(64, 16)
        Me.lblWeeklyLineProd.TabIndex = 88
        Me.lblWeeklyLineProd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWeeklyUserProd
        '
        Me.lblWeeklyUserProd.BackColor = System.Drawing.Color.Transparent
        Me.lblWeeklyUserProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWeeklyUserProd.ForeColor = System.Drawing.Color.Lime
        Me.lblWeeklyUserProd.Location = New System.Drawing.Point(140, 5)
        Me.lblWeeklyUserProd.Name = "lblWeeklyUserProd"
        Me.lblWeeklyUserProd.Size = New System.Drawing.Size(64, 16)
        Me.lblWeeklyUserProd.TabIndex = 87
        Me.lblWeeklyUserProd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Lime
        Me.Label15.Location = New System.Drawing.Point(5, 57)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(128, 16)
        Me.Label15.TabIndex = 86
        Me.Label15.Text = "Group Production:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Lime
        Me.Label16.Location = New System.Drawing.Point(5, 22)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(118, 16)
        Me.Label16.TabIndex = 85
        Me.Label16.Text = "Line Production:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Lime
        Me.Label17.Location = New System.Drawing.Point(5, 5)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(118, 16)
        Me.Label17.TabIndex = 84
        Me.Label17.Text = "User Production:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Lime
        Me.Label18.Location = New System.Drawing.Point(5, 40)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(118, 16)
        Me.Label18.TabIndex = 90
        Me.Label18.Text = "Shift Production:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWeeklyShiftProd
        '
        Me.lblWeeklyShiftProd.BackColor = System.Drawing.Color.Transparent
        Me.lblWeeklyShiftProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWeeklyShiftProd.ForeColor = System.Drawing.Color.Lime
        Me.lblWeeklyShiftProd.Location = New System.Drawing.Point(140, 40)
        Me.lblWeeklyShiftProd.Name = "lblWeeklyShiftProd"
        Me.lblWeeklyShiftProd.Size = New System.Drawing.Size(64, 16)
        Me.lblWeeklyShiftProd.TabIndex = 91
        Me.lblWeeklyShiftProd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(4, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(132, 16)
        Me.Label4.TabIndex = 111
        Me.Label4.Text = "Daily Production:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblGroupProd, Me.lblLineProd, Me.lblUserProd, Me.Label9, Me.Label7, Me.Label6, Me.Label11, Me.lblShiftProd, Me.Label13, Me.grdProd})
        Me.Panel3.Location = New System.Drawing.Point(5, 25)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(216, 199)
        Me.Panel3.TabIndex = 110
        '
        'lblGroupProd
        '
        Me.lblGroupProd.BackColor = System.Drawing.Color.Transparent
        Me.lblGroupProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroupProd.ForeColor = System.Drawing.Color.Lime
        Me.lblGroupProd.Location = New System.Drawing.Point(140, 58)
        Me.lblGroupProd.Name = "lblGroupProd"
        Me.lblGroupProd.Size = New System.Drawing.Size(64, 16)
        Me.lblGroupProd.TabIndex = 89
        Me.lblGroupProd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLineProd
        '
        Me.lblLineProd.BackColor = System.Drawing.Color.Transparent
        Me.lblLineProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLineProd.ForeColor = System.Drawing.Color.Lime
        Me.lblLineProd.Location = New System.Drawing.Point(140, 23)
        Me.lblLineProd.Name = "lblLineProd"
        Me.lblLineProd.Size = New System.Drawing.Size(64, 16)
        Me.lblLineProd.TabIndex = 88
        Me.lblLineProd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUserProd
        '
        Me.lblUserProd.BackColor = System.Drawing.Color.Transparent
        Me.lblUserProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserProd.ForeColor = System.Drawing.Color.Lime
        Me.lblUserProd.Location = New System.Drawing.Point(140, 5)
        Me.lblUserProd.Name = "lblUserProd"
        Me.lblUserProd.Size = New System.Drawing.Size(64, 16)
        Me.lblUserProd.TabIndex = 87
        Me.lblUserProd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Lime
        Me.Label9.Location = New System.Drawing.Point(5, 58)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(128, 16)
        Me.Label9.TabIndex = 86
        Me.Label9.Text = "Group Production:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Lime
        Me.Label7.Location = New System.Drawing.Point(5, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(118, 16)
        Me.Label7.TabIndex = 85
        Me.Label7.Text = "Line Production:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Lime
        Me.Label6.Location = New System.Drawing.Point(5, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(118, 16)
        Me.Label6.TabIndex = 84
        Me.Label6.Text = "User Production:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Lime
        Me.Label11.Location = New System.Drawing.Point(5, 41)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(118, 16)
        Me.Label11.TabIndex = 90
        Me.Label11.Text = "Shift Production:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblShiftProd
        '
        Me.lblShiftProd.BackColor = System.Drawing.Color.Transparent
        Me.lblShiftProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShiftProd.ForeColor = System.Drawing.Color.Lime
        Me.lblShiftProd.Location = New System.Drawing.Point(140, 41)
        Me.lblShiftProd.Name = "lblShiftProd"
        Me.lblShiftProd.Size = New System.Drawing.Size(64, 16)
        Me.lblShiftProd.TabIndex = 91
        Me.lblShiftProd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(3, 81)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(180, 18)
        Me.Label13.TabIndex = 109
        Me.Label13.Text = "Line Production by Model:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grdProd
        '
        Me.grdProd.AllowColMove = False
        Me.grdProd.AllowColSelect = False
        Me.grdProd.AllowFilter = False
        Me.grdProd.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.grdProd.AllowSort = False
        Me.grdProd.AllowUpdate = False
        Me.grdProd.AllowUpdateOnBlur = False
        Me.grdProd.CaptionHeight = 17
        Me.grdProd.CollapseColor = System.Drawing.Color.Black
        Me.grdProd.DataChanged = False
        Me.grdProd.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.grdProd.ExpandColor = System.Drawing.Color.Black
        Me.grdProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdProd.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdProd.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
        Me.grdProd.Location = New System.Drawing.Point(3, 99)
        Me.grdProd.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
        Me.grdProd.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.grdProd.Name = "grdProd"
        Me.grdProd.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdProd.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdProd.PreviewInfo.ZoomFactor = 75
        Me.grdProd.PrintInfo.ShowOptionsDialog = False
        Me.grdProd.RecordSelectorWidth = 16
        GridLines3.Color = System.Drawing.Color.DarkGray
        GridLines3.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single
        Me.grdProd.RowDivider = GridLines3
        Me.grdProd.RowHeight = 20
        Me.grdProd.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.grdProd.ScrollTips = False
        Me.grdProd.Size = New System.Drawing.Size(205, 92)
        Me.grdProd.TabIndex = 108
        Me.grdProd.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
        "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
        "er;}Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignVert:Cente" & _
        "r;BackColor:Black;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Sty" & _
        "le12{}OddRow{BackColor:LightSteelBlue;}RecordSelector{AlignImage:Center;}Style13" & _
        "{}Heading{Wrap:True;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Cent" & _
        "er;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Co" & _
        "ntrol;}Style8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style9{}</Data" & _
        "></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSe" & _
        "lect=""False"" Name="""" AllowRowSizing=""None"" CaptionHeight=""17"" ColumnCaptionHeigh" & _
        "t=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWid" & _
        "th=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><C" & _
        "lientRect>0, 0, 201, 88</ClientRect><BorderSide>0</BorderSide><CaptionStyle pare" & _
        "nt=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowSt" & _
        "yle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style1" & _
        "3"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""S" & _
        "tyle12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent" & _
        "=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><Od" & _
        "dRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelec" & _
        "tor"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent" & _
        "=""Normal"" me=""Style1"" /></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><S" & _
        "tyle parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent" & _
        "=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""H" & _
        "eading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""No" & _
        "rmal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""No" & _
        "rmal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading" & _
        """ me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""C" & _
        "aption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horz" & _
        "Splits><Layout>None</Layout><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientAr" & _
        "ea>0, 0, 201, 88</ClientArea></Blob>"
        '
        'PanelPalletList
        '
        Me.PanelPalletList.BackColor = System.Drawing.Color.LightSteelBlue
        Me.PanelPalletList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelPalletList.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button6, Me.grdPallets, Me.cmdReopenPallet})
        Me.PanelPalletList.Location = New System.Drawing.Point(234, 142)
        Me.PanelPalletList.Name = "PanelPalletList"
        Me.PanelPalletList.Size = New System.Drawing.Size(272, 166)
        Me.PanelPalletList.TabIndex = 108
        '
        'Button6
        '
        Me.Button6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Location = New System.Drawing.Point(144, 245)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(200, 31)
        Me.Button6.TabIndex = 66
        Me.Button6.TabStop = False
        Me.Button6.Text = "Generate Report"
        '
        'cmdReprintPalletLabel
        '
        Me.cmdReprintPalletLabel.BackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdReprintPalletLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReprintPalletLabel.ForeColor = System.Drawing.Color.Black
        Me.cmdReprintPalletLabel.Location = New System.Drawing.Point(578, 472)
        Me.cmdReprintPalletLabel.Name = "cmdReprintPalletLabel"
        Me.cmdReprintPalletLabel.Size = New System.Drawing.Size(200, 32)
        Me.cmdReprintPalletLabel.TabIndex = 109
        Me.cmdReprintPalletLabel.Text = "REPRINT PALLET LABEL"
        '
        'frmCellShipPallet_Cellstar
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(1028, 628)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdReprintPalletLabel, Me.PanelPalletList, Me.Panel1, Me.panelCriterion, Me.panelPallet, Me.Panel6, Me.Panel2, Me.lbl})
        Me.Name = "frmCellShipPallet_Cellstar"
        Me.Text = "Auto Ship Devices"
        Me.Panel2.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.panelPallet.ResumeLayout(False)
        Me.PanelSKULen.ResumeLayout(False)
        CType(Me.grdPallets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelShipType.ResumeLayout(False)
        Me.panelCriterion.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.grdWeeklyProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        CType(Me.grdProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelPalletList.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    '*********************************************************
    Private Sub LoadModels()
        Dim dtModels As New DataTable()
        Try
            dtModels = objMisc.GetModels(2, 1)
            With Me.cmbModel
                .DataSource = dtModels.DefaultView
                .DisplayMember = dtModels.Columns("Model_Desc").ToString
                .ValueMember = dtModels.Columns("Model_ID").ToString
                .SelectedValue = 0
            End With

        Catch ex As Exception
            MsgBox("Error in frmBulkShipping.LoadModels:: " & ex.Message.ToString, MsgBoxStyle.Critical)
        Finally
            If Not IsNothing(dtModels) Then
                dtModels.Dispose()
                dtModels = Nothing
            End If
        End Try
    End Sub
    '*********************************************************
    Protected Overrides Sub Finalize()
        objMisc = Nothing
        MyBase.Finalize()
    End Sub
    '*********************************************************
    Private Sub frmCellShipPallet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer = 0

        Try
            LoadModels()
            i = CheckIfMachineTiedToLine()
            If i = 0 Then
                Throw New Exception("Machine is not associated with any 'Line'. Can't continue.")
            End If
            LoadCellProductionNumbers()
            LoadWeeklyCellProductionNumbers()

        Catch ex As Exception
            MessageBox.Show("frmCellShipPallet_Cellstar.frmCellShipPallet_Load: " & Environment.NewLine & ex.Message.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try

    End Sub

    Private Sub LoadWeeklyCellProductionNumbers()
        Dim dt1 As DataTable
        Dim R1 As DataRow
        Dim iUserProd As Integer = 0
        Dim iShiftProd As Integer = 0
        Dim iLineProd As Integer = 0
        Dim iGroupProd As Integer = 0

        Try
            '**********************************************
            'Get production numbers by Line, Shift, User and Group
            dt1 = objMisc.LoadCellProductionNumbers(strWorkDate, iGroup_ID, 1)
            For Each R1 In dt1.Rows
                'get User Production
                If iUserID = R1("User_ID") Then
                    iUserProd += 1
                End If
                'Get Line Production
                If iLine_ID = R1("Line_ID") Then
                    iLineProd += 1
                End If
                'Get Group Production
                If iGroup_ID = R1("Group_ID") Then
                    iGroupProd += 1
                End If
                'Shift Production
                If iShiftID = R1("Shift_ID") Then
                    iShiftProd += 1
                End If
            Next R1

            Me.lblWeeklyUserProd.Text = iUserProd
            Me.lblWeeklyLineProd.Text = iLineProd
            Me.lblWeeklyGroupProd.Text = iGroupProd
            Me.lblWeeklyShiftProd.Text = iShiftProd
            '**********************************************
            R1 = Nothing
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
            '**********************************************
            dt1 = objMisc.LoadCellProductionNumbersByModel(strWorkDate, iLine_ID, 1)
            Me.grdWeeklyProd.DataSource = Nothing
            Me.grdWeeklyProd.DataSource = dt1.DefaultView
            SetGrdWeeklyProdProperties()
            '**********************************************

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

    Private Sub LoadCellProductionNumbers()
        Dim dt1 As DataTable
        Dim R1 As DataRow
        Dim iUserProd As Integer = 0
        Dim iShiftProd As Integer = 0
        Dim iLineProd As Integer = 0
        Dim iGroupProd As Integer = 0

        Try
            '**********************************************
            'Get production numbers by Line, Shift, User and Group
            dt1 = objMisc.LoadCellProductionNumbers(strWorkDate, iGroup_ID, 0)
            For Each R1 In dt1.Rows
                'get User Production
                If iUserID = R1("User_ID") Then
                    iUserProd += 1
                End If
                'Get Line Production
                If iLine_ID = R1("Line_ID") Then
                    iLineProd += 1
                End If
                'Get Group Production
                If iGroup_ID = R1("Group_ID") Then
                    iGroupProd += 1
                End If
                'Shift Production
                If iShiftID = R1("Shift_ID") Then
                    iShiftProd += 1
                End If
            Next R1

            Me.lblUserProd.Text = iUserProd
            Me.lblLineProd.Text = iLineProd
            Me.lblGroupProd.Text = iGroupProd
            Me.lblShiftProd.Text = iShiftProd
            '**********************************************
            R1 = Nothing
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
            '**********************************************
            dt1 = objMisc.LoadCellProductionNumbersByModel(strWorkDate, iLine_ID, 0)
            Me.grdProd.DataSource = Nothing
            Me.grdProd.DataSource = dt1.DefaultView
            SetGrdProdProperties()
            '**********************************************

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

    Private Sub SetGrdWeeklyProdProperties()
        Dim iNumOfColumns As Integer = Me.grdProd.Columns.Count
        Dim i As Integer

        With Me.grdWeeklyProd
            'Heading style (Horizontal Alignment to Center)
            For i = 0 To (iNumOfColumns - 1)
                .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Next
            'header forecolor
            .Splits(0).DisplayColumns(1).HeadingStyle.ForeColor = .ForeColor.Black
            .Splits(0).DisplayColumns(2).HeadingStyle.ForeColor = .ForeColor.Black

            'Set individual column data horizontal alignment
            .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Body Forecolor
            .Splits(0).DisplayColumns(1).Style.ForeColor = .ForeColor.Black
            .Splits(0).DisplayColumns(2).Style.ForeColor = .ForeColor.Black

            'Set Column Widths
            .Splits(0).DisplayColumns(1).Width = 100
            .Splits(0).DisplayColumns(2).Width = 48

            .Splits(0).DisplayColumns(0).Visible = False

        End With

        'grdWeeklyProd
    End Sub

    Private Sub SetGrdProdProperties()
        Dim iNumOfColumns As Integer = Me.grdProd.Columns.Count
        Dim i As Integer

        With Me.grdProd
            'Heading style (Horizontal Alignment to Center)
            For i = 0 To (iNumOfColumns - 1)
                .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Next
            'header forecolor
            .Splits(0).DisplayColumns(1).HeadingStyle.ForeColor = .ForeColor.Black
            .Splits(0).DisplayColumns(2).HeadingStyle.ForeColor = .ForeColor.Black

            'Set individual column data horizontal alignment
            .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Body Forecolor
            .Splits(0).DisplayColumns(1).Style.ForeColor = .ForeColor.Black
            .Splits(0).DisplayColumns(2).Style.ForeColor = .ForeColor.Black

            'Set Column Widths
            .Splits(0).DisplayColumns(1).Width = 100
            .Splits(0).DisplayColumns(2).Width = 48

            .Splits(0).DisplayColumns(0).Visible = False

        End With

    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click

        Dim str_sn As String = ""
        Dim i As Integer = 0

        Try
            '************************
            'Validations
            If Me.iPallet_ID = 0 Then
                Throw New Exception("Pallet is not selected.")
            ElseIf Trim(Me.strPalletName) = "" Then
                Throw New Exception("Pallet is not selected.")
            End If
            '************************
            'Me.cmbModel.Focus()
            str_sn = InputBox("Enter SN.", "Cell Ship Pallet")
            If str_sn = "" Then
                Throw New Exception("Please enter a SN if you want to remove it from the selected pallet.")
            End If

            'Me.lblCount.Text = 0
            'Me.lstDevices.DataSource = Nothing

            i = objMisc.RemoveSNfromPallet(iPallet_ID, str_sn)
            If i = 0 Then
                Throw New Exception("SN entered was not removed from Pallet.")
            End If

            Me.RefreshSNList()
            Me.LoadCellProductionNumbers()
            Me.LoadWeeklyCellProductionNumbers()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Clear SN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub btnClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearAll.Click
        Dim str_sn As String = ""
        Dim i As Integer = 0

        If MessageBox.Show("Are you sure you want to remove all devices from this Pallet?", "Clear All SNs", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.No Then
            Exit Sub
        End If

        Try
            '************************
            'Validations
            If Me.iPallet_ID = 0 Then
                Throw New Exception("Pallet is not selected.")
            ElseIf Trim(Me.strPalletName) = "" Then
                Throw New Exception("Pallet is not selected.")
            End If
            '************************
            i = objMisc.RemoveSNfromPallet(iPallet_ID, )
            If i = 0 Then
                Throw New Exception("No Sns were removed from Pallet.")
            End If

            RefreshSNList()
            Me.LoadCellProductionNumbers()
            Me.LoadWeeklyCellProductionNumbers()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Clear All SNs", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.txtSN.Focus()
        End Try
    End Sub

    Private Function CheckIfMachineTiedToLine() As Integer
        Dim dt1 As DataTable
        Dim R1 As DataRow

        Try
            dt1 = objMisc.CheckIfMachineTiedToLine(strMachine)
            If dt1.Rows.Count = 0 Then
                Return 0
            End If

            For Each R1 In dt1.Rows
                iGroup_ID = R1("Group_ID")
                strGroup = Trim(R1("Group_Desc"))
                iLine_ID = R1("Line_ID")
                strLineNumber = Trim(R1("Line_Number"))
                iLineSide_ID = R1("LineSide_ID")
                strLineSide = Trim(R1("LineSide_Desc"))
                strBin = Trim(R1("WC_Location"))
                iWCLocation_ID = R1("WCLocation_ID")
            Next R1

            Me.lblGroup.Text = "Group: " & strGroup
            Me.lblLine.Text = strLineNumber
            Me.lblLineSide.Text = strLineSide
            Me.lblMachine.Text = "Machine: " & strMachine
            Me.lblUserName.Text = "User: " & strUserName
            Me.lblShift.Text = "Shift: " & iShiftID
            Me.lblWorkDate.Text = "Work Date: " & Format(CDate(strWorkDate), "MM/dd/yyyy")
            Me.lblBin.Text = "BIN: " & strBin

            Return 1
        Catch ex As Exception
            Throw ex
        Finally
            R1 = Nothing
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try
    End Function

    Private Sub cmbShipType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbShipType.SelectedIndexChanged

        Try
            '***************************************
            Me.cmbSkuLen.Text = ""
            Me.PanelSKULen.Visible = False
            Me.panelPallet.Visible = False
            Me.lblPalletName.Text = ""
            Me.txtSN.Text = ""
            Me.txtDevSN.Text = ""
            Me.lstDevices.DataSource = Nothing

            'Globals
            strPalletName = ""
            iPallet_ID = 0
            strShipType = ""
            '***************************************
            strShipType = Me.cmbShipType.SelectedItem
            If strShipType = "REFURBISHED" Then
                Me.PanelSKULen.Visible = True
                Me.panelPallet.Visible = False
                Me.cmdCreatePallet.Visible = False
            Else
                'Check if an open pallet is available
                GetPalletInfo()
                'Check if the pallet is already created for the criterion
                If strPalletName = "" Then
                    ConstructPalletName()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Select Ship Type", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try

    End Sub

    Private Sub cmbModel_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbModel.SelectionChangeCommitted
        Dim i As Integer = 0
        Dim strGroupChar As String = Microsoft.VisualBasic.Right(Trim(strGroup), 1)

        Try
            '*****************************
            Me.cmbShipType.Text = ""
            Me.cmbSkuLen.Text = ""
            Me.grdPallets.ClearFields()
            Me.panelPallet.Visible = False
            Me.lblPalletName.Text = ""
            Me.txtSN.Text = ""
            Me.txtDevSN.Text = ""
            Me.lstDevices.DataSource = Nothing
            Me.cmdCreatePallet.Visible = False
            Me.PanelSKULen.Visible = False


            'Globals
            iModel_ID = 0
            strShortModelName = ""
            strPalletName = ""
            iPallet_ID = 0
            '*****************************
            iModel_ID = Me.cmbModel.SelectedValue

            If iModel_ID = 0 Then
                Exit Sub
            End If

            strShortModelName = objMisc.GetShortModelName(iModel_ID)
            If Trim(strShortModelName) = "" Then
                strShortModelName = InputBox("This Model does not have a 'Short Name'. Please input it now to continue.")
                If Trim(strShortModelName) = "" Then
                    Me.cmbModel.SelectedValue = 0
                    iModel_ID = 0
                    Throw New Exception("You must input a 'Short Model Name'. Can't continue.")
                Else
                    'Save the Short Name
                    i = objMisc.SaveShortModelName(iModel_ID, strShortModelName)
                End If
            End If

            'RefreshPalletGrid(strGroupChar, strShortModelName)
            RefreshPalletGrid(strGroupChar)

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Select Model", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

        End Try
    End Sub
    'Private Sub RefreshPalletGrid(ByVal strGroupChar As String, _
    '                                ByVal strShortModelName As String)
    Private Sub RefreshPalletGrid(ByVal strGroupChar As String)
        Dim dt1 As DataTable
        Try
            If iModel_ID = 0 Then
                Exit Sub
            End If

            Me.grdPallets.ClearFields()
            'Public Function GetOpenPalletsForModel(ByVal strGroupChar As String, _
            'ByVal strShortModelName As String, _
            'ByVal iModel_ID As Integer) _
            'As DataTable


            'Get all open pallets for a model
            dt1 = objMisc.GetOpenPalletsForModel(strGroupChar, strShortModelName, iModel_ID)
            'A max of 4 open pallets allowed at one time.
            If dt1.Rows.Count < 4 Then
                'Move the PanelPalletList down
                'Me.PanelPalletList.Top = 359
                Me.PanelPalletList.Top = Me.panelCriterion.Top + Me.panelCriterion.Height + 2
                System.Windows.Forms.Application.DoEvents()
                panelCriterion.Visible = True
            Else
                'Move the PanelPalletList up
                'Me.PanelPalletList.Top = 164
                Me.PanelPalletList.Top = Me.panelCriterion.Top
                System.Windows.Forms.Application.DoEvents()
                panelCriterion.Visible = False
            End If
            Me.grdPallets.DataSource = dt1.DefaultView
            SetGridProperties()
        Catch ex As Exception
        Finally
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try

    End Sub
    Private Sub SetGridProperties()
        Dim iNumOfColumns As Integer = Me.grdPallets.Columns.Count
        Dim i As Integer

        With Me.grdPallets
            'Heading style (Horizontal Alignment to Center)
            For i = 0 To (iNumOfColumns - 1)
                .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Next
            'header forecolor
            .Splits(0).DisplayColumns(0).HeadingStyle.ForeColor = .ForeColor.Black
            .Splits(0).DisplayColumns(1).HeadingStyle.ForeColor = .ForeColor.Black
            .Splits(0).DisplayColumns(2).HeadingStyle.ForeColor = .ForeColor.Black
            .Splits(0).DisplayColumns(3).HeadingStyle.ForeColor = .ForeColor.Black

            'Set individual column data horizontal alignment
            .Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            .Splits(0).DisplayColumns(3).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

            'Body Forecolor
            .Splits(0).DisplayColumns(0).Style.ForeColor = .ForeColor.Black
            .Splits(0).DisplayColumns(1).Style.ForeColor = .ForeColor.Black
            .Splits(0).DisplayColumns(2).Style.ForeColor = .ForeColor.Black
            .Splits(0).DisplayColumns(3).Style.ForeColor = .ForeColor.Black

            'Set Column Widths
            .Splits(0).DisplayColumns(0).Width = 100
            .Splits(0).DisplayColumns(1).Width = 150
            .Splits(0).DisplayColumns(2).Width = 150
            .Splits(0).DisplayColumns(3).Width = 150

            'Make some columns invisible
            .Splits(0).DisplayColumns(0).Visible = False
            .Splits(0).DisplayColumns(1).Visible = False
            .Splits(0).DisplayColumns(2).Visible = False

        End With
    End Sub

    Private Sub cmbSkuLen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSkuLen.SelectedIndexChanged
        Try
            '***************************************
            Me.panelPallet.Visible = False
            Me.lblPalletName.Text = ""
            Me.txtSN.Text = ""
            Me.txtDevSN.Text = ""
            Me.lstDevices.DataSource = Nothing
            '***************************************
            strSkuLength = Me.cmbSkuLen.SelectedItem
            'Check if an open pallet is available
            GetPalletInfo()
            'Check if the pallet is already created for the criterion
            If strPalletName = "" Then
                ConstructPalletName()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Select Ship Type", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try

    End Sub

    Private Function ConstructPalletName() As String
        Dim strGroupChar As String = ""
        Dim strSkuChar As String = ""
        Dim strdt As String = Format(CDate(strWorkDate), "MMddyy")
        Dim strLastAlphaInPallet As String = ""
        Dim strShipTypeChars As String = ""

        Try
            If iPallet_ID = 0 Then
                strGroupChar = Microsoft.VisualBasic.Right(Trim(strGroup), 1)
                strShipTypeChars = Microsoft.VisualBasic.Left(strShipType, 3)

                If strShipType <> "REFURBISHED" Then
                    strSkuChar = "F"    'Hardcode F for Sku Length for RUR/RTMs
                Else
                    strSkuChar = Microsoft.VisualBasic.Left(Trim(strSkuLength), 1)
                End If

                'Get the last Alphabet 
                strLastAlphaInPallet = objMisc.GetLastCharFromPalletName(strGroupChar, strdt)
                strPalletName = strGroupChar & strShortModelName & strSkuChar & strShipTypeChars & strdt & strLastAlphaInPallet
                strPalletNameInitials = strGroupChar & strShortModelName & strSkuChar & strShipTypeChars
                Me.cmdCreatePallet.Visible = True
                Me.panelPallet.Visible = False
            Else
                Me.cmdCreatePallet.Visible = False
                Me.lblPalletName.Text = strPalletName
                Me.panelPallet.Visible = True
                Me.RefreshSNList()
                Me.txtSN.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub GetPalletInfo()
        Dim strGroupChar As String = ""
        Dim strpalletString As String = ""
        Dim strSkuChar As String = ""
        Dim strShipTypeChars As String = ""
        Dim dt1 As DataTable
        Dim R1 As DataRow

        Try
            strGroupChar = Microsoft.VisualBasic.Right(Trim(strGroup), 1)
            strShipTypeChars = Microsoft.VisualBasic.Left(strShipType, 3)
            If strShipType <> "REFURBISHED" Then
                strSkuChar = "F"
            Else
                strSkuChar = Microsoft.VisualBasic.Left(Trim(strSkuLength), 1)
            End If

            strpalletString = strGroupChar & strShortModelName & strSkuChar & strShipTypeChars
            dt1 = objMisc.GetPalletInfo(strpalletString)

            If dt1.Rows.Count > 0 Then
                R1 = dt1.Rows(0)
                strPalletName = R1("Pallett_Name")
                iPallet_ID = R1("Pallett_ID").ToString
                Me.panelPallet.Visible = True
                Me.cmdCreatePallet.Visible = False
                Me.RefreshSNList()
                Me.txtSN.Focus()
            Else
                strPalletName = ""
                iPallet_ID = 0
                Me.panelPallet.Visible = False
                Me.cmdCreatePallet.Visible = True
            End If
            Me.lblPalletName.Text = strPalletName

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdCreatePallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreatePallet.Click
        Dim strGroupChar As String = Microsoft.VisualBasic.Right(Trim(strGroup), 1)
        Try
            '************************
            'Validations
            If Trim(Me.strPalletName) = "" Then
                Throw New Exception("Pallet Name missing.")
            ElseIf Trim(strShipType) = "" Then
                Throw New Exception("Ship Type is not selected.")
            ElseIf Trim(strShipType) = "REFURBISHED" Then
                If Trim(strSkuLength) = "" Then
                    Throw New Exception("Ship Type is not selected.")
                End If
            End If
            '************************
            iPallet_ID = objMisc.CreatePallet(strPalletName, strShipType, strSkuLength, strPalletNameInitials, iModel_ID)
            Me.cmdCreatePallet.Visible = False
            Me.panelPallet.Visible = True
            Me.lblPalletName.Text = strPalletName
            'RefreshPalletGrid(strGroupChar, strShortModelName)
            RefreshPalletGrid(strGroupChar)
            Me.RefreshSNList()
            Me.txtSN.Focus()
        Catch ex As Exception
            MessageBox.Show("cmdCreatePallet_Click: " & ex.ToString, "Create Pallet", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub Asif()
        With Me.grdProd
            Dim x As String = .Splits(0).DisplayColumns(0).Width & "-" & _
                                .Splits(0).DisplayColumns(1).Width


            MsgBox(x)
        End With

    End Sub
    Private Sub cmdClosePallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClosePallet.Click
        Dim i As Integer = 0
        Dim strGroupChar As String = Microsoft.VisualBasic.Right(Trim(strGroup), 1)

        Try
            '************************
            If MessageBox.Show("Are you sure you want to close this Pallet?", "Close Pallet", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Exit Sub
            End If
            '************************
            'Validations
            If Me.iPallet_ID = 0 Then
                Throw New Exception("Pallet is not selected.")
            ElseIf Trim(Me.strPalletName) = "" Then
                Throw New Exception("Pallet is not selected.")
            End If

            If Me.lstDevices.Items.Count = 0 Then
                Throw New Exception("There are no devices on this Pallet.")
            End If
            '************************
            i = objMisc.ClosePallet(iPallet_ID, strPalletName)
            If i = 0 Then
                Throw New Exception("Pallet was not closed due to an error. Please contact IT.")
            End If

            'RefreshPalletGrid(strGroupChar, strShortModelName)
            RefreshPalletGrid(strGroupChar)
            '******************************
            'Reset Screen control properties.
            Me.lblPalletName.Text = ""
            Me.strPalletName = ""
            Me.iPallet_ID = 0
            Me.lblCount.Text = 0
            Me.lstDevices.DataSource = Nothing
            Me.panelPallet.Visible = False
            '******************************
        Catch ex As Exception
            MessageBox.Show("cmdCreatePallet_Click: " & ex.ToString, "Create Pallet", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub InitializePalletVar()
        Try
            If Me.grdPallets.Columns.Count = 0 Then
                Exit Sub
            End If
            If Trim(Me.grdPallets.Columns("Pallet").Value) = "" Then
                Exit Sub
            End If
            Me.panelPallet.Visible = True
            Me.lblPalletName.Text = Me.grdPallets.Columns("Pallet").Value
            strPalletName = Me.grdPallets.Columns("Pallet").Value
            iPallet_ID = CInt(Me.grdPallets.Columns("Pallett_id").Value)
            '*****
            Select Case Me.grdPallets.Columns("Pallet_ShipType").Value.ToString
                Case "0"
                    strShipType = "REFURBISHED"
                Case "1"
                    strShipType = "RUR"
                Case "9"
                    strShipType = "RTM"
            End Select
            '*******
            strSkuLength = Me.grdPallets.Columns("Pallet_SkuLen").Value.ToString
            Me.RefreshSNList()
            '*******************************************
            Me.txtSN.Focus()

        Catch ex As Exception
            MessageBox.Show("cmdCreatePallet_Click: " & ex.ToString, "Create Pallet", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub grdPallets_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdPallets.Click
        InitializePalletVar()
    End Sub

    Private Sub grdPallets_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles grdPallets.RowColChange
        InitializePalletVar()
    End Sub

    Private Sub RefreshSNList()
        Dim dt1 As DataTable
        Try
            '************************
            'Validations
            If Me.iPallet_ID = 0 Then
                Throw New Exception("Pallet is not selected.")
            ElseIf Trim(Me.strPalletName) = "" Then
                Throw New Exception("Pallet is not selected.")
            End If
            '*******************************************
            'Get all devices add put them in them in list box for a pallet
            dt1 = objMisc.GetAllSNsForPallet(iPallet_ID)
            Me.lstDevices.DataSource = dt1.DefaultView
            Me.lstDevices.ValueMember = dt1.Columns("device_id").ToString
            Me.lstDevices.DisplayMember = dt1.Columns("device_sn").ToString
            '*******************************************
            Me.lblCount.Text = dt1.Rows.Count
        Catch ex As Exception
            Throw ex
        Finally
            Me.txtSN.Focus()
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try
    End Sub

    Private Sub ProcessSN()
        Dim i As Integer = 0
        Dim strGroupChar As String = Microsoft.VisualBasic.Right(Trim(strGroup), 1)
        Dim strSN As String = UCase(Trim(txtSN.Text))
        Dim strSkuChar As String = ""
        Dim strShipTypeChars As String = ""

        Try
            'If e.KeyValue = 13 Then
            '************************
            'Validations
            If Me.iPallet_ID = 0 Then
                Throw New Exception("Pallet is not selected.")
            ElseIf Trim(Me.strPalletName) = "" Then
                Throw New Exception("Pallet is not selected.")
            ElseIf Trim(Me.txtSN.Text) = "" Then
                Exit Sub
            End If
            '***************************************************
            'Step 1: Check REF/RUR/RTM, RUR/RTM with parts
            strShipTypeChars = Microsoft.VisualBasic.Left(strShipType, 3)
            i = objMisc.CheckDevice_REF_RUR_RTM(strSN, strShipTypeChars)
            '***************************************************
            'Step 2: Check if the Device is already scanned in
            i = objMisc.CheckPalletAlreadyAssigned(strSN)
            If i = 0 Then
                MsgBox("This device already has a pallet assigned. Can't put it on this pallet.", MsgBoxStyle.Information, "CheckPalletAlreadyAssigned")
                Me.txtSN.Text = ""
                Me.txtDevSN.Text = ""
                Me.txtSN.Focus()
                Exit Sub
            End If
            '***************************************************
            'Step 3: Check if the Device is already scanned in
            For i = 0 To Me.lstDevices.Items.Count - 1
                If UCase(Trim(Me.lstDevices.Items(i).ToString)) = strSN Then
                    MsgBox("This device is already scanned in. Try another one.", MsgBoxStyle.Information, "Device Scan")
                    Me.txtSN.Text = ""
                    Me.txtDevSN.Text = ""
                    Me.txtSN.Focus()
                    Exit Sub
                End If
            Next
            '***************************************************
            'Step 4: Check if this device belongs to group Pallett is tied to
            i = objMisc.CheckDeviceGroup(strSN, iGroup_ID)

            '***************************************************
            'Step 5: Check device model
            i = objMisc.CheckDeviceModel(strSN, strShortModelName)
            If i = 0 Then
                MsgBox("This device is of a different model. Can't put it on this pallet.", MsgBoxStyle.Information, "CheckDeviceModel")
                Me.txtSN.Text = ""
                Me.txtDevSN.Text = ""
                Me.txtSN.Focus()
                Exit Sub
            End If
            '***************************************************
            'Step 6: Check if a wrong sku length Device is being scanned in to this pallet
            If strShipType = "REFURBISHED" Then
                strSkuChar = Microsoft.VisualBasic.Left(Trim(strSkuLength), 1)
                i = objMisc.CheckDeviceSKULength(strSN, strSkuChar)
                If i = 0 Then
                    MsgBox("This device is of wrong SKU length. Can't put it on this pallet.", MsgBoxStyle.Information, "CheckDeviceSKULength")
                    Me.txtSN.Text = ""
                    Me.txtDevSN.Text = ""
                    Me.txtSN.Focus()
                    Exit Sub
                End If
            End If
            '***************************************************
            'if above all is fine then add it to the list and update the database
            i = objMisc.UpdateDeviceWithPallet(strSN, iPallet_ID, strWorkDate, iUserID, iWCLocation_ID, iLine_ID, iGroup_ID)
            '***************************************************
            Me.RefreshSNList()
            Me.LoadCellProductionNumbers()
            Me.LoadWeeklyCellProductionNumbers()
            Me.txtSN.Text = ""
            Me.txtDevSN.Text = ""
            Me.txtSN.Focus()

            'End If
        Catch ex As Exception
            MessageBox.Show("ProcessSN: " & ex.ToString, "Device Scan", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.txtSN.Text = ""
            Me.txtDevSN.Text = ""
            Me.txtSN.Focus()
        End Try
    End Sub

    Private Sub txtSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp
        If e.KeyValue = 13 Then
            If Trim(Me.txtSN.Text) = "" Then
                'MessageBox.Show("Please scan in the 'Box IMEI'.", "Scan Box IMEI", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                Me.txtDevSN.Text = ""
                Me.txtDevSN.Focus()
            End If
        End If
    End Sub
    Private Sub txtDevSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDevSN.KeyUp
        If e.KeyValue = 13 Then

            If Trim(Me.txtSN.Text) = "" Then
                MessageBox.Show("Please scan in the 'Box IMEI' first.", "Scan Box IMEI", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            ElseIf Trim(Me.txtDevSN.Text) = "" Then
                MessageBox.Show("Please scan in the 'Device IMEI' first.", "Scan Device IMEI", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If Trim(UCase(Me.txtDevSN.Text)) = Trim(UCase(Me.txtSN.Text)) Then
                ProcessSN()
            Else
                MessageBox.Show("'Box IMEI' and 'Device IMEI' do not match. Can't put it on pallet.", "Scan Device IMEI", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtDevSN.Text = ""
                Me.txtDevSN.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub cmdReopenPallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReopenPallet.Click
        Dim str_pallet As String = ""
        Dim i As Integer = 0
        Dim strGroupChar As String = Microsoft.VisualBasic.Right(Trim(strGroup), 1)

        Try
            '************************
            str_pallet = InputBox("Enter Pallet ID.", "Reopen Pallet")
            If str_pallet = "" Then
                Throw New Exception("Please enter a Pallet Id if you want to remove it from the selected pallet.")
            End If

            i = objMisc.ReopenPallet(str_pallet)
            If i = 0 Then
                Throw New Exception("Pallet was not reopened.")
            End If

            'RefreshPalletGrid(strGroupChar, strShortModelName)
            RefreshPalletGrid(strGroupChar)

            '************************
            Me.lstDevices.DataSource = Nothing
            Me.lblCount.Text = "0"
            Me.lblPalletName.Text = ""
            Me.strPalletName = ""
            Me.iPallet_ID = 0
            Me.panelPallet.Visible = False
            '************************
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Reopen Pallet.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub



    Private Sub cmdReprintPalletLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReprintPalletLabel.Click
        Dim str_pallet As String = ""
        Dim iPalletID As Integer = 0

        Try
            str_pallet = InputBox("Enter Pallet Name.", "Reprint Pallet Label")
            If str_pallet = "" Then
                Throw New Exception("Please enter a Pallet Name if you want to reprint the pallet label.")
            End If

            Me.cmdReprintPalletLabel.Enabled = False
            Cursor.Current = Cursors.WaitCursor

            iPalletID = objMisc.GetPalletID(Trim(str_pallet), 1)
            If iPalletID > 0 Then
                objMisc.PrintPalletDeviceCountRpt(iPalletID)
            Else
                Throw New Exception("Pallet Name was not defined in system.")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Reprint Pallet Label.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.cmdReprintPalletLabel.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub
End Class

