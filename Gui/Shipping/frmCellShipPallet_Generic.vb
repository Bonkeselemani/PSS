Option Explicit On 

Imports CrystalDecisions.CrystalReports.Engine
Imports Microsoft.VisualBasic
Imports PSS.Misc
Imports System.Drawing.Printing
Imports PSS.Data.Buisness

Public Class frmCellShipPallet_Generic
    Inherits System.Windows.Forms.Form
    Private objMisc As PSS.Data.Buisness.Misc
    Private iLine_ID As Integer = 0
    Private iGroup_ID As Integer = 0
    Private strLineNumber As String = ""
    Private strGroup As String = ""
    Private iLineSide_ID As Integer = 0
    Private strLineSide As String = ""
    Private strMachine As String = System.Net.Dns.GetHostName
    Private strUserName As String = PSS.Core.[Global].ApplicationUser.User
    Private iUserID As Integer = PSS.Core.[Global].ApplicationUser.IDuser
    Private iShiftID As Integer = PSS.Core.[Global].ApplicationUser.IDShift
    Private strWorkDate As String = PSS.Core.[Global].ApplicationUser.Workdate
    Private strBin As String = ""
    Private iModel_ID As Integer = 0
    Private iWCLocation_ID As Integer = 0
    Private strShortModelName As String = ""
    Private strPalletName As String = ""
    Private strPalletNameInitials As String = ""
    Private iPallet_ID As Integer = 0
    Private strShipType As String = ""
    Private strSkuLength As String = ""
    Private strGroupChar As String = ""

    Private strLot As String = ""
    Private strPrevSN As String = ""
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
    Friend WithEvents cmbShipType As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents lstDevices As System.Windows.Forms.ListBox
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblLineSide As System.Windows.Forms.Label
    Friend WithEvents lblBin As System.Windows.Forms.Label
    Friend WithEvents cmdCreatePallet As System.Windows.Forms.Button
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
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmdReprintPalletLabel As System.Windows.Forms.Button
    Friend WithEvents cmbCustomer As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSN As System.Windows.Forms.TextBox
    Friend WithEvents chkNoPalLbl As System.Windows.Forms.CheckBox
    Friend WithEvents grdProd As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents grdWeeklyProd As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents chkSNBarcode As System.Windows.Forms.CheckBox
    Friend WithEvents cmdDevNotShip As System.Windows.Forms.Button
    Friend WithEvents cmdReprintPrevSN As System.Windows.Forms.Button
    Friend WithEvents lblLot As System.Windows.Forms.Label
    Friend WithEvents cmdDeletePallett As System.Windows.Forms.Button
    Friend WithEvents cmbSkuLen As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents PanelSKULen As System.Windows.Forms.Panel
    Friend WithEvents lblSkuLen As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCellShipPallet_Generic))
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
        Me.cmbCustomer = New PSS.Gui.Controls.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbModel = New PSS.Gui.Controls.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.cmbShipType = New PSS.Gui.Controls.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.panelPallet = New System.Windows.Forms.Panel()
        Me.lblSkuLen = New System.Windows.Forms.Label()
        Me.lblLot = New System.Windows.Forms.Label()
        Me.chkNoPalLbl = New System.Windows.Forms.CheckBox()
        Me.txtSN = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmdClosePallet = New System.Windows.Forms.Button()
        Me.btnClearAll = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.lstDevices = New System.Windows.Forms.ListBox()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblPalletName = New System.Windows.Forms.Label()
        Me.chkSNBarcode = New System.Windows.Forms.CheckBox()
        Me.cmdReopenPallet = New System.Windows.Forms.Button()
        Me.cmdCreatePallet = New System.Windows.Forms.Button()
        Me.grdPallets = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.panelShipType = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.panelCriterion = New System.Windows.Forms.Panel()
        Me.PanelSKULen = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbSkuLen = New PSS.Gui.Controls.ComboBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.grdWeeklyProd = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Label21 = New System.Windows.Forms.Label()
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
        Me.grdProd = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.lblGroupProd = New System.Windows.Forms.Label()
        Me.lblLineProd = New System.Windows.Forms.Label()
        Me.lblUserProd = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblShiftProd = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.PanelPalletList = New System.Windows.Forms.Panel()
        Me.cmdDeletePallett = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.cmdReprintPalletLabel = New System.Windows.Forms.Button()
        Me.cmdDevNotShip = New System.Windows.Forms.Button()
        Me.cmdReprintPrevSN = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.panelPallet.SuspendLayout()
        CType(Me.grdPallets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelShipType.SuspendLayout()
        Me.panelCriterion.SuspendLayout()
        Me.PanelSKULen.SuspendLayout()
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
        Me.lbl.Location = New System.Drawing.Point(4, 2)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(293, 87)
        Me.lbl.TabIndex = 7
        Me.lbl.Text = "BUILD SHIP PALLETS"
        Me.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblBin, Me.lblLineSide, Me.lblMachine, Me.lblGroup, Me.lblLine, Me.lblShift, Me.lblWorkDate, Me.lblUserName})
        Me.Panel2.Location = New System.Drawing.Point(301, 1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(897, 88)
        Me.Panel2.TabIndex = 87
        '
        'lblBin
        '
        Me.lblBin.BackColor = System.Drawing.Color.Transparent
        Me.lblBin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBin.ForeColor = System.Drawing.Color.Lime
        Me.lblBin.Location = New System.Drawing.Point(389, 31)
        Me.lblBin.Name = "lblBin"
        Me.lblBin.Size = New System.Drawing.Size(228, 20)
        Me.lblBin.TabIndex = 94
        Me.lblBin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLineSide
        '
        Me.lblLineSide.BackColor = System.Drawing.Color.Transparent
        Me.lblLineSide.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLineSide.ForeColor = System.Drawing.Color.Lime
        Me.lblLineSide.Location = New System.Drawing.Point(3, 57)
        Me.lblLineSide.Name = "lblLineSide"
        Me.lblLineSide.Size = New System.Drawing.Size(335, 19)
        Me.lblLineSide.TabIndex = 93
        Me.lblLineSide.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMachine
        '
        Me.lblMachine.BackColor = System.Drawing.Color.Transparent
        Me.lblMachine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMachine.ForeColor = System.Drawing.Color.Lime
        Me.lblMachine.Location = New System.Drawing.Point(389, 5)
        Me.lblMachine.Name = "lblMachine"
        Me.lblMachine.Size = New System.Drawing.Size(228, 20)
        Me.lblMachine.TabIndex = 92
        Me.lblMachine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGroup
        '
        Me.lblGroup.BackColor = System.Drawing.Color.Transparent
        Me.lblGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroup.ForeColor = System.Drawing.Color.Lime
        Me.lblGroup.Location = New System.Drawing.Point(3, 5)
        Me.lblGroup.Name = "lblGroup"
        Me.lblGroup.Size = New System.Drawing.Size(335, 20)
        Me.lblGroup.TabIndex = 91
        Me.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLine
        '
        Me.lblLine.BackColor = System.Drawing.Color.Transparent
        Me.lblLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLine.ForeColor = System.Drawing.Color.Lime
        Me.lblLine.Location = New System.Drawing.Point(3, 31)
        Me.lblLine.Name = "lblLine"
        Me.lblLine.Size = New System.Drawing.Size(335, 20)
        Me.lblLine.TabIndex = 90
        Me.lblLine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblShift
        '
        Me.lblShift.BackColor = System.Drawing.Color.Transparent
        Me.lblShift.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShift.ForeColor = System.Drawing.Color.Lime
        Me.lblShift.Location = New System.Drawing.Point(645, 31)
        Me.lblShift.Name = "lblShift"
        Me.lblShift.Size = New System.Drawing.Size(228, 20)
        Me.lblShift.TabIndex = 88
        Me.lblShift.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWorkDate
        '
        Me.lblWorkDate.BackColor = System.Drawing.Color.Transparent
        Me.lblWorkDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWorkDate.ForeColor = System.Drawing.Color.Lime
        Me.lblWorkDate.Location = New System.Drawing.Point(645, 57)
        Me.lblWorkDate.Name = "lblWorkDate"
        Me.lblWorkDate.Size = New System.Drawing.Size(228, 19)
        Me.lblWorkDate.TabIndex = 84
        Me.lblWorkDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUserName
        '
        Me.lblUserName.BackColor = System.Drawing.Color.Transparent
        Me.lblUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserName.ForeColor = System.Drawing.Color.Lime
        Me.lblUserName.Location = New System.Drawing.Point(645, 5)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(228, 20)
        Me.lblUserName.TabIndex = 83
        Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel6.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmbCustomer, Me.Label2, Me.cmbModel, Me.Label5, Me.Button4})
        Me.Panel6.Location = New System.Drawing.Point(300, 91)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(348, 82)
        Me.Panel6.TabIndex = 88
        '
        'cmbCustomer
        '
        Me.cmbCustomer.AutoComplete = True
        Me.cmbCustomer.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCustomer.ForeColor = System.Drawing.Color.Black
        Me.cmbCustomer.Location = New System.Drawing.Point(128, 9)
        Me.cmbCustomer.Name = "cmbCustomer"
        Me.cmbCustomer.Size = New System.Drawing.Size(183, 25)
        Me.cmbCustomer.TabIndex = 82
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(10, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 20)
        Me.Label2.TabIndex = 83
        Me.Label2.Text = "Customer:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbModel
        '
        Me.cmbModel.AutoComplete = True
        Me.cmbModel.BackColor = System.Drawing.SystemColors.Window
        Me.cmbModel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbModel.ForeColor = System.Drawing.Color.Black
        Me.cmbModel.Location = New System.Drawing.Point(128, 42)
        Me.cmbModel.Name = "cmbModel"
        Me.cmbModel.Size = New System.Drawing.Size(183, 25)
        Me.cmbModel.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(10, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 20)
        Me.Label5.TabIndex = 81
        Me.Label5.Text = "Model:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(184, 302)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(256, 39)
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
        Me.cmbShipType.Location = New System.Drawing.Point(118, 15)
        Me.cmbShipType.Name = "cmbShipType"
        Me.cmbShipType.Size = New System.Drawing.Size(189, 25)
        Me.cmbShipType.TabIndex = 84
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(15, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 20)
        Me.Label1.TabIndex = 85
        Me.Label1.Text = "Ship Type:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'panelPallet
        '
        Me.panelPallet.BackColor = System.Drawing.Color.LightSteelBlue
        Me.panelPallet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panelPallet.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblSkuLen, Me.lblLot, Me.chkNoPalLbl, Me.txtSN, Me.Label10, Me.cmdClosePallet, Me.btnClearAll, Me.btnClear, Me.lstDevices, Me.lblCount, Me.Label3, Me.lblPalletName, Me.chkSNBarcode})
        Me.panelPallet.Location = New System.Drawing.Point(650, 91)
        Me.panelPallet.Name = "panelPallet"
        Me.panelPallet.Size = New System.Drawing.Size(548, 422)
        Me.panelPallet.TabIndex = 94
        Me.panelPallet.Visible = False
        '
        'lblSkuLen
        '
        Me.lblSkuLen.BackColor = System.Drawing.Color.Salmon
        Me.lblSkuLen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSkuLen.Font = New System.Drawing.Font("Verdana", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSkuLen.ForeColor = System.Drawing.Color.Black
        Me.lblSkuLen.Location = New System.Drawing.Point(266, 345)
        Me.lblSkuLen.Name = "lblSkuLen"
        Me.lblSkuLen.Size = New System.Drawing.Size(266, 50)
        Me.lblSkuLen.TabIndex = 104
        Me.lblSkuLen.Text = "FIG 8"
        Me.lblSkuLen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblSkuLen.Visible = False
        '
        'lblLot
        '
        Me.lblLot.BackColor = System.Drawing.Color.Black
        Me.lblLot.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLot.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLot.ForeColor = System.Drawing.Color.Lime
        Me.lblLot.Location = New System.Drawing.Point(426, 6)
        Me.lblLot.Name = "lblLot"
        Me.lblLot.Size = New System.Drawing.Size(106, 40)
        Me.lblLot.TabIndex = 103
        Me.lblLot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkNoPalLbl
        '
        Me.chkNoPalLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkNoPalLbl.ForeColor = System.Drawing.Color.Black
        Me.chkNoPalLbl.Location = New System.Drawing.Point(266, 276)
        Me.chkNoPalLbl.Name = "chkNoPalLbl"
        Me.chkNoPalLbl.Size = New System.Drawing.Size(210, 30)
        Me.chkNoPalLbl.TabIndex = 101
        Me.chkNoPalLbl.Text = "DON'T PRINT PALLET LABEL"
        '
        'txtSN
        '
        Me.txtSN.Location = New System.Drawing.Point(14, 73)
        Me.txtSN.Name = "txtSN"
        Me.txtSN.Size = New System.Drawing.Size(200, 22)
        Me.txtSN.TabIndex = 100
        Me.txtSN.Text = ""
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(14, 53)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(119, 20)
        Me.Label10.TabIndex = 99
        Me.Label10.Text = "Device IMEI:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdClosePallet
        '
        Me.cmdClosePallet.BackColor = System.Drawing.Color.Green
        Me.cmdClosePallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClosePallet.ForeColor = System.Drawing.Color.White
        Me.cmdClosePallet.Location = New System.Drawing.Point(14, 360)
        Me.cmdClosePallet.Name = "cmdClosePallet"
        Me.cmdClosePallet.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClosePallet.Size = New System.Drawing.Size(201, 40)
        Me.cmdClosePallet.TabIndex = 92
        Me.cmdClosePallet.Text = "CLOSE PALLET"
        '
        'btnClearAll
        '
        Me.btnClearAll.BackColor = System.Drawing.Color.Red
        Me.btnClearAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearAll.ForeColor = System.Drawing.Color.White
        Me.btnClearAll.Location = New System.Drawing.Point(265, 216)
        Me.btnClearAll.Name = "btnClearAll"
        Me.btnClearAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnClearAll.Size = New System.Drawing.Size(189, 41)
        Me.btnClearAll.TabIndex = 91
        Me.btnClearAll.Text = "REMOVE ALL IMEIs"
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.Red
        Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.Color.White
        Me.btnClear.Location = New System.Drawing.Point(265, 168)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnClear.Size = New System.Drawing.Size(189, 39)
        Me.btnClear.TabIndex = 90
        Me.btnClear.Text = "REMOVE IMEI"
        '
        'lstDevices
        '
        Me.lstDevices.ItemHeight = 16
        Me.lstDevices.Location = New System.Drawing.Point(14, 106)
        Me.lstDevices.Name = "lstDevices"
        Me.lstDevices.Size = New System.Drawing.Size(200, 228)
        Me.lstDevices.TabIndex = 89
        '
        'lblCount
        '
        Me.lblCount.BackColor = System.Drawing.Color.Black
        Me.lblCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCount.ForeColor = System.Drawing.Color.Lime
        Me.lblCount.Location = New System.Drawing.Point(297, 94)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(125, 39)
        Me.lblCount.TabIndex = 97
        Me.lblCount.Text = "0"
        Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(323, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 19)
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
        Me.lblPalletName.Location = New System.Drawing.Point(13, 6)
        Me.lblPalletName.Name = "lblPalletName"
        Me.lblPalletName.Size = New System.Drawing.Size(407, 40)
        Me.lblPalletName.TabIndex = 98
        Me.lblPalletName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkSNBarcode
        '
        Me.chkSNBarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSNBarcode.ForeColor = System.Drawing.Color.Black
        Me.chkSNBarcode.Location = New System.Drawing.Point(266, 305)
        Me.chkSNBarcode.Name = "chkSNBarcode"
        Me.chkSNBarcode.Size = New System.Drawing.Size(231, 29)
        Me.chkSNBarcode.TabIndex = 102
        Me.chkSNBarcode.Text = "DON'T PRINT SN BARCODE LABEL"
        '
        'cmdReopenPallet
        '
        Me.cmdReopenPallet.BackColor = System.Drawing.Color.Red
        Me.cmdReopenPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReopenPallet.ForeColor = System.Drawing.Color.White
        Me.cmdReopenPallet.Location = New System.Drawing.Point(35, 151)
        Me.cmdReopenPallet.Name = "cmdReopenPallet"
        Me.cmdReopenPallet.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdReopenPallet.Size = New System.Drawing.Size(272, 39)
        Me.cmdReopenPallet.TabIndex = 104
        Me.cmdReopenPallet.Text = "REOPEN  PALLET"
        '
        'cmdCreatePallet
        '
        Me.cmdCreatePallet.BackColor = System.Drawing.Color.Green
        Me.cmdCreatePallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCreatePallet.ForeColor = System.Drawing.Color.White
        Me.cmdCreatePallet.Location = New System.Drawing.Point(35, 158)
        Me.cmdCreatePallet.Name = "cmdCreatePallet"
        Me.cmdCreatePallet.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCreatePallet.Size = New System.Drawing.Size(273, 39)
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
        Me.grdPallets.CaptionHeight = 19
        Me.grdPallets.CollapseColor = System.Drawing.Color.White
        Me.grdPallets.ExpandColor = System.Drawing.Color.White
        Me.grdPallets.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdPallets.ForeColor = System.Drawing.Color.White
        Me.grdPallets.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdPallets.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.grdPallets.Location = New System.Drawing.Point(35, 11)
        Me.grdPallets.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.grdPallets.Name = "grdPallets"
        Me.grdPallets.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdPallets.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdPallets.PreviewInfo.ZoomFactor = 75
        Me.grdPallets.RowHeight = 20
        Me.grdPallets.Size = New System.Drawing.Size(273, 131)
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
        "11{}Style14{}Style15{}Style16{}Style17{}Style1{}</Data></Styles><Splits><C1.Win." & _
        "C1TrueDBGrid.MergeView HBarHeight=""25"" VBarHeight=""26"" AllowColMove=""False"" Allo" & _
        "wColSelect=""False"" Name="""" AllowRowSizing=""None"" CaptionHeight=""17"" ColumnCaptio" & _
        "nHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelec" & _
        "torWidth=""20"" DefRecSelWidth=""20"" VerticalScrollGroup=""1"" HorizontalScrollGroup=" & _
        """1""><Height>127</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyl" & _
        "e parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><Fi" & _
        "lterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""" & _
        "Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Headin" & _
        "g"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><Inactiv" & _
        "eStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" " & _
        "/><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle par" & _
        "ent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0," & _
        " 0, 269, 127</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderSt" & _
        "yle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""N" & _
        "ormal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Foote" & _
        "r"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive" & _
        """ /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" />" & _
        "<Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /" & _
        "><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector" & _
        """ /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /" & _
        "></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None<" & _
        "/Layout><DefaultRecSelWidth>20</DefaultRecSelWidth><ClientArea>0, 0, 269, 127</C" & _
        "lientArea><PrintPageHeaderStyle parent="""" me=""Style16"" /><PrintPageFooterStyle p" & _
        "arent="""" me=""Style17"" /></Blob>"
        '
        'panelShipType
        '
        Me.panelShipType.BackColor = System.Drawing.Color.LightSteelBlue
        Me.panelShipType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panelShipType.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button3, Me.Label1, Me.cmbShipType})
        Me.panelShipType.Location = New System.Drawing.Point(10, 10)
        Me.panelShipType.Name = "panelShipType"
        Me.panelShipType.Size = New System.Drawing.Size(324, 59)
        Me.panelShipType.TabIndex = 102
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(184, 302)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(256, 39)
        Me.Button3.TabIndex = 66
        Me.Button3.TabStop = False
        Me.Button3.Text = "Generate Report"
        '
        'panelCriterion
        '
        Me.panelCriterion.BackColor = System.Drawing.Color.LightSteelBlue
        Me.panelCriterion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panelCriterion.Controls.AddRange(New System.Windows.Forms.Control() {Me.PanelSKULen, Me.Button5, Me.panelShipType, Me.cmdCreatePallet})
        Me.panelCriterion.Location = New System.Drawing.Point(300, 175)
        Me.panelCriterion.Name = "panelCriterion"
        Me.panelCriterion.Size = New System.Drawing.Size(348, 222)
        Me.panelCriterion.TabIndex = 103
        Me.panelCriterion.Visible = False
        '
        'PanelSKULen
        '
        Me.PanelSKULen.BackColor = System.Drawing.Color.LightSteelBlue
        Me.PanelSKULen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelSKULen.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button1, Me.Label8, Me.cmbSkuLen})
        Me.PanelSKULen.Location = New System.Drawing.Point(10, 79)
        Me.PanelSKULen.Name = "PanelSKULen"
        Me.PanelSKULen.Size = New System.Drawing.Size(324, 59)
        Me.PanelSKULen.TabIndex = 103
        Me.PanelSKULen.Visible = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(184, 302)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(256, 39)
        Me.Button1.TabIndex = 66
        Me.Button1.TabStop = False
        Me.Button1.Text = "Generate Report"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(-1, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(114, 20)
        Me.Label8.TabIndex = 83
        Me.Label8.Text = "SKU Length:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbSkuLen
        '
        Me.cmbSkuLen.AutoComplete = True
        Me.cmbSkuLen.BackColor = System.Drawing.Color.Salmon
        Me.cmbSkuLen.Font = New System.Drawing.Font("Verdana", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSkuLen.ForeColor = System.Drawing.Color.Black
        Me.cmbSkuLen.ItemHeight = 20
        Me.cmbSkuLen.Items.AddRange(New Object() {"", "GFI", "FIG 8"})
        Me.cmbSkuLen.Location = New System.Drawing.Point(118, 11)
        Me.cmbSkuLen.Name = "cmbSkuLen"
        Me.cmbSkuLen.Size = New System.Drawing.Size(189, 28)
        Me.cmbSkuLen.TabIndex = 2
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(184, 302)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(256, 39)
        Me.Button5.TabIndex = 66
        Me.Button5.TabStop = False
        Me.Button5.Text = "Generate Report"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label20, Me.Panel4, Me.Label4, Me.Panel3})
        Me.Panel1.Location = New System.Drawing.Point(4, 91)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(293, 560)
        Me.Panel1.TabIndex = 107
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(3, 286)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(192, 20)
        Me.Label20.TabIndex = 113
        Me.Label20.Text = "Weekly Production:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel4.Controls.AddRange(New System.Windows.Forms.Control() {Me.grdWeeklyProd, Me.Label21, Me.lblWeeklyGroupProd, Me.lblWeeklyLineProd, Me.lblWeeklyUserProd, Me.Label15, Me.Label16, Me.Label17, Me.Label18, Me.lblWeeklyShiftProd})
        Me.Panel4.Location = New System.Drawing.Point(6, 307)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(277, 245)
        Me.Panel4.TabIndex = 112
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
        Me.grdWeeklyProd.CaptionHeight = 19
        Me.grdWeeklyProd.CollapseColor = System.Drawing.Color.White
        Me.grdWeeklyProd.ExpandColor = System.Drawing.Color.White
        Me.grdWeeklyProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdWeeklyProd.ForeColor = System.Drawing.Color.White
        Me.grdWeeklyProd.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdWeeklyProd.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
        Me.grdWeeklyProd.Location = New System.Drawing.Point(4, 116)
        Me.grdWeeklyProd.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.grdWeeklyProd.Name = "grdWeeklyProd"
        Me.grdWeeklyProd.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdWeeklyProd.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdWeeklyProd.PreviewInfo.ZoomFactor = 75
        Me.grdWeeklyProd.RowHeight = 20
        Me.grdWeeklyProd.Size = New System.Drawing.Size(262, 118)
        Me.grdWeeklyProd.TabIndex = 112
        Me.grdWeeklyProd.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:White;Ba" & _
        "ckColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Center;ForeColor:W" & _
        "hite;}Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignVert:Cen" & _
        "ter;ForeColor:White;BackColor:LightSteelBlue;}HighlightRow{ForeColor:HighlightTe" & _
        "xt;BackColor:Highlight;}Style14{}OddRow{BackColor:LightSteelBlue;}RecordSelector" & _
        "{ForeColor:White;AlignImage:Center;}Style15{}Heading{Wrap:True;Font:Microsoft Sa" & _
        "ns Serif, 8.25pt, style=Bold;AlignHorz:Center;BackColor:Control;Border:Raised,,1" & _
        ", 1, 1, 1;ForeColor:Blue;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style" & _
        "11{}Style12{}Style13{}Style16{}Style17{}Style9{}</Data></Styles><Splits><C1.Win." & _
        "C1TrueDBGrid.MergeView HBarHeight=""25"" VBarHeight=""26"" AllowColMove=""False"" Allo" & _
        "wColSelect=""False"" Name="""" AllowRowSizing=""None"" CaptionHeight=""17"" ColumnCaptio" & _
        "nHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelec" & _
        "torWidth=""20"" DefRecSelWidth=""20"" VerticalScrollGroup=""1"" HorizontalScrollGroup=" & _
        """1""><Height>114</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyl" & _
        "e parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><Fi" & _
        "lterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""" & _
        "Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Headin" & _
        "g"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><Inactiv" & _
        "eStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" " & _
        "/><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle par" & _
        "ent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0," & _
        " 0, 258, 114</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderSt" & _
        "yle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""N" & _
        "ormal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Foote" & _
        "r"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive" & _
        """ /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" />" & _
        "<Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /" & _
        "><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector" & _
        """ /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /" & _
        "></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None<" & _
        "/Layout><DefaultRecSelWidth>20</DefaultRecSelWidth><ClientArea>0, 0, 258, 114</C" & _
        "lientArea><PrintPageHeaderStyle parent="""" me=""Style16"" /><PrintPageFooterStyle p" & _
        "arent="""" me=""Style17"" /></Blob>"
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(4, 96)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(230, 20)
        Me.Label21.TabIndex = 111
        Me.Label21.Text = "Line Production by Model:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWeeklyGroupProd
        '
        Me.lblWeeklyGroupProd.BackColor = System.Drawing.Color.Transparent
        Me.lblWeeklyGroupProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWeeklyGroupProd.ForeColor = System.Drawing.Color.Lime
        Me.lblWeeklyGroupProd.Location = New System.Drawing.Point(179, 70)
        Me.lblWeeklyGroupProd.Name = "lblWeeklyGroupProd"
        Me.lblWeeklyGroupProd.Size = New System.Drawing.Size(82, 20)
        Me.lblWeeklyGroupProd.TabIndex = 89
        Me.lblWeeklyGroupProd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWeeklyLineProd
        '
        Me.lblWeeklyLineProd.BackColor = System.Drawing.Color.Transparent
        Me.lblWeeklyLineProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWeeklyLineProd.ForeColor = System.Drawing.Color.Lime
        Me.lblWeeklyLineProd.Location = New System.Drawing.Point(179, 27)
        Me.lblWeeklyLineProd.Name = "lblWeeklyLineProd"
        Me.lblWeeklyLineProd.Size = New System.Drawing.Size(82, 20)
        Me.lblWeeklyLineProd.TabIndex = 88
        Me.lblWeeklyLineProd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWeeklyUserProd
        '
        Me.lblWeeklyUserProd.BackColor = System.Drawing.Color.Transparent
        Me.lblWeeklyUserProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWeeklyUserProd.ForeColor = System.Drawing.Color.Lime
        Me.lblWeeklyUserProd.Location = New System.Drawing.Point(179, 6)
        Me.lblWeeklyUserProd.Name = "lblWeeklyUserProd"
        Me.lblWeeklyUserProd.Size = New System.Drawing.Size(82, 20)
        Me.lblWeeklyUserProd.TabIndex = 87
        Me.lblWeeklyUserProd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Lime
        Me.Label15.Location = New System.Drawing.Point(6, 70)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(164, 20)
        Me.Label15.TabIndex = 86
        Me.Label15.Text = "Group Production:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Lime
        Me.Label16.Location = New System.Drawing.Point(6, 27)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(151, 20)
        Me.Label16.TabIndex = 85
        Me.Label16.Text = "Line Production:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Lime
        Me.Label17.Location = New System.Drawing.Point(6, 6)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(151, 20)
        Me.Label17.TabIndex = 84
        Me.Label17.Text = "User Production:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Lime
        Me.Label18.Location = New System.Drawing.Point(6, 49)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(151, 20)
        Me.Label18.TabIndex = 90
        Me.Label18.Text = "Shift Production:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWeeklyShiftProd
        '
        Me.lblWeeklyShiftProd.BackColor = System.Drawing.Color.Transparent
        Me.lblWeeklyShiftProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWeeklyShiftProd.ForeColor = System.Drawing.Color.Lime
        Me.lblWeeklyShiftProd.Location = New System.Drawing.Point(179, 49)
        Me.lblWeeklyShiftProd.Name = "lblWeeklyShiftProd"
        Me.lblWeeklyShiftProd.Size = New System.Drawing.Size(82, 20)
        Me.lblWeeklyShiftProd.TabIndex = 91
        Me.lblWeeklyShiftProd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(5, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(169, 20)
        Me.Label4.TabIndex = 111
        Me.Label4.Text = "Daily Production:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.AddRange(New System.Windows.Forms.Control() {Me.grdProd, Me.lblGroupProd, Me.lblLineProd, Me.lblUserProd, Me.Label9, Me.Label7, Me.Label6, Me.Label11, Me.lblShiftProd, Me.Label13})
        Me.Panel3.Location = New System.Drawing.Point(6, 31)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(277, 245)
        Me.Panel3.TabIndex = 110
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
        Me.grdProd.CaptionHeight = 19
        Me.grdProd.CollapseColor = System.Drawing.Color.White
        Me.grdProd.ExpandColor = System.Drawing.Color.White
        Me.grdProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdProd.ForeColor = System.Drawing.Color.White
        Me.grdProd.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdProd.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
        Me.grdProd.Location = New System.Drawing.Point(4, 122)
        Me.grdProd.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.grdProd.Name = "grdProd"
        Me.grdProd.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdProd.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdProd.PreviewInfo.ZoomFactor = 75
        Me.grdProd.RowHeight = 20
        Me.grdProd.Size = New System.Drawing.Size(262, 114)
        Me.grdProd.TabIndex = 110
        Me.grdProd.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:White;Ba" & _
        "ckColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Center;ForeColor:W" & _
        "hite;}Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignVert:Cen" & _
        "ter;ForeColor:White;BackColor:LightSteelBlue;}HighlightRow{ForeColor:HighlightTe" & _
        "xt;BackColor:Highlight;}Style14{}OddRow{BackColor:LightSteelBlue;}RecordSelector" & _
        "{ForeColor:White;AlignImage:Center;}Style15{}Heading{Wrap:True;Font:Microsoft Sa" & _
        "ns Serif, 8.25pt, style=Bold;AlignHorz:Center;BackColor:Control;Border:Raised,,1" & _
        ", 1, 1, 1;ForeColor:Blue;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style" & _
        "11{}Style12{}Style13{}Style16{}Style17{}Style9{}</Data></Styles><Splits><C1.Win." & _
        "C1TrueDBGrid.MergeView HBarHeight=""25"" VBarHeight=""26"" AllowColMove=""False"" Allo" & _
        "wColSelect=""False"" Name="""" AllowRowSizing=""None"" CaptionHeight=""17"" ColumnCaptio" & _
        "nHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelec" & _
        "torWidth=""20"" DefRecSelWidth=""20"" VerticalScrollGroup=""1"" HorizontalScrollGroup=" & _
        """1""><Height>110</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyl" & _
        "e parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><Fi" & _
        "lterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""" & _
        "Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Headin" & _
        "g"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><Inactiv" & _
        "eStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" " & _
        "/><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle par" & _
        "ent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0," & _
        " 0, 258, 110</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderSt" & _
        "yle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""N" & _
        "ormal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Foote" & _
        "r"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive" & _
        """ /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" />" & _
        "<Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /" & _
        "><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector" & _
        """ /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /" & _
        "></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None<" & _
        "/Layout><DefaultRecSelWidth>20</DefaultRecSelWidth><ClientArea>0, 0, 258, 110</C" & _
        "lientArea><PrintPageHeaderStyle parent="""" me=""Style16"" /><PrintPageFooterStyle p" & _
        "arent="""" me=""Style17"" /></Blob>"
        '
        'lblGroupProd
        '
        Me.lblGroupProd.BackColor = System.Drawing.Color.Transparent
        Me.lblGroupProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroupProd.ForeColor = System.Drawing.Color.Lime
        Me.lblGroupProd.Location = New System.Drawing.Point(179, 72)
        Me.lblGroupProd.Name = "lblGroupProd"
        Me.lblGroupProd.Size = New System.Drawing.Size(82, 19)
        Me.lblGroupProd.TabIndex = 89
        Me.lblGroupProd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLineProd
        '
        Me.lblLineProd.BackColor = System.Drawing.Color.Transparent
        Me.lblLineProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLineProd.ForeColor = System.Drawing.Color.Lime
        Me.lblLineProd.Location = New System.Drawing.Point(179, 28)
        Me.lblLineProd.Name = "lblLineProd"
        Me.lblLineProd.Size = New System.Drawing.Size(82, 20)
        Me.lblLineProd.TabIndex = 88
        Me.lblLineProd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUserProd
        '
        Me.lblUserProd.BackColor = System.Drawing.Color.Transparent
        Me.lblUserProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserProd.ForeColor = System.Drawing.Color.Lime
        Me.lblUserProd.Location = New System.Drawing.Point(179, 6)
        Me.lblUserProd.Name = "lblUserProd"
        Me.lblUserProd.Size = New System.Drawing.Size(82, 20)
        Me.lblUserProd.TabIndex = 87
        Me.lblUserProd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Lime
        Me.Label9.Location = New System.Drawing.Point(6, 72)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(164, 19)
        Me.Label9.TabIndex = 86
        Me.Label9.Text = "Group Production:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Lime
        Me.Label7.Location = New System.Drawing.Point(6, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(151, 20)
        Me.Label7.TabIndex = 85
        Me.Label7.Text = "Line Production:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Lime
        Me.Label6.Location = New System.Drawing.Point(6, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(151, 20)
        Me.Label6.TabIndex = 84
        Me.Label6.Text = "User Production:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Lime
        Me.Label11.Location = New System.Drawing.Point(6, 51)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(151, 19)
        Me.Label11.TabIndex = 90
        Me.Label11.Text = "Shift Production:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblShiftProd
        '
        Me.lblShiftProd.BackColor = System.Drawing.Color.Transparent
        Me.lblShiftProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShiftProd.ForeColor = System.Drawing.Color.Lime
        Me.lblShiftProd.Location = New System.Drawing.Point(179, 51)
        Me.lblShiftProd.Name = "lblShiftProd"
        Me.lblShiftProd.Size = New System.Drawing.Size(82, 19)
        Me.lblShiftProd.TabIndex = 91
        Me.lblShiftProd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(4, 100)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(230, 22)
        Me.Label13.TabIndex = 109
        Me.Label13.Text = "Line Production by Model:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PanelPalletList
        '
        Me.PanelPalletList.BackColor = System.Drawing.Color.LightSteelBlue
        Me.PanelPalletList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelPalletList.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdDeletePallett, Me.Button6, Me.grdPallets, Me.cmdReopenPallet})
        Me.PanelPalletList.Location = New System.Drawing.Point(300, 400)
        Me.PanelPalletList.Name = "PanelPalletList"
        Me.PanelPalletList.Size = New System.Drawing.Size(348, 251)
        Me.PanelPalletList.TabIndex = 108
        '
        'cmdDeletePallett
        '
        Me.cmdDeletePallett.BackColor = System.Drawing.Color.Red
        Me.cmdDeletePallett.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDeletePallett.ForeColor = System.Drawing.Color.White
        Me.cmdDeletePallett.Location = New System.Drawing.Point(35, 197)
        Me.cmdDeletePallett.Name = "cmdDeletePallett"
        Me.cmdDeletePallett.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdDeletePallett.Size = New System.Drawing.Size(272, 40)
        Me.cmdDeletePallett.TabIndex = 105
        Me.cmdDeletePallett.Text = "DELETE EMPTY PALLET"
        '
        'Button6
        '
        Me.Button6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Location = New System.Drawing.Point(184, 302)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(256, 39)
        Me.Button6.TabIndex = 66
        Me.Button6.TabStop = False
        Me.Button6.Text = "Generate Report"
        '
        'cmdReprintPalletLabel
        '
        Me.cmdReprintPalletLabel.BackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdReprintPalletLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReprintPalletLabel.ForeColor = System.Drawing.Color.Black
        Me.cmdReprintPalletLabel.Location = New System.Drawing.Point(655, 523)
        Me.cmdReprintPalletLabel.Name = "cmdReprintPalletLabel"
        Me.cmdReprintPalletLabel.Size = New System.Drawing.Size(256, 40)
        Me.cmdReprintPalletLabel.TabIndex = 109
        Me.cmdReprintPalletLabel.Text = "REPRINT PALLET LABEL"
        '
        'cmdDevNotShip
        '
        Me.cmdDevNotShip.BackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdDevNotShip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDevNotShip.ForeColor = System.Drawing.Color.Black
        Me.cmdDevNotShip.Location = New System.Drawing.Point(655, 573)
        Me.cmdDevNotShip.Name = "cmdDevNotShip"
        Me.cmdDevNotShip.Size = New System.Drawing.Size(256, 39)
        Me.cmdDevNotShip.TabIndex = 110
        Me.cmdDevNotShip.Text = "GAME STOP DEVICES YET TO BE SHIPPED REPORT"
        Me.cmdDevNotShip.Visible = False
        '
        'cmdReprintPrevSN
        '
        Me.cmdReprintPrevSN.BackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdReprintPrevSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReprintPrevSN.ForeColor = System.Drawing.Color.Black
        Me.cmdReprintPrevSN.Location = New System.Drawing.Point(932, 573)
        Me.cmdReprintPrevSN.Name = "cmdReprintPrevSN"
        Me.cmdReprintPrevSN.Size = New System.Drawing.Size(256, 39)
        Me.cmdReprintPrevSN.TabIndex = 111
        Me.cmdReprintPrevSN.Text = "REPRINT PREVIOUS SN LABEL"
        Me.cmdReprintPrevSN.Visible = False
        '
        'frmCellShipPallet_Generic
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(1208, 678)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdReprintPrevSN, Me.cmdDevNotShip, Me.cmdReprintPalletLabel, Me.PanelPalletList, Me.Panel1, Me.panelCriterion, Me.panelPallet, Me.Panel6, Me.Panel2, Me.lbl})
        Me.Name = "frmCellShipPallet_Generic"
        Me.Text = "Auto Ship Devices"
        Me.Panel2.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.panelPallet.ResumeLayout(False)
        CType(Me.grdPallets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelShipType.ResumeLayout(False)
        Me.panelCriterion.ResumeLayout(False)
        Me.PanelSKULen.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.grdWeeklyProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        CType(Me.grdProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelPalletList.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub cmbCustomer_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCustomer.SelectionChangeCommitted
        Try
            '*****************************
            Me.cmbShipType.Text = ""
            Me.cmbShipType.Items.Clear()
            Me.grdPallets.ClearFields()
            Me.panelPallet.Visible = False
            Me.lblPalletName.Text = ""
            Me.txtSN.Text = ""
            Me.lstDevices.DataSource = Nothing
            Me.cmdCreatePallet.Visible = False
            'Me.PanelSelectPrinter.Visible = False

            'Globals
            iModel_ID = 0
            strShortModelName = ""
            strPalletName = ""
            iPallet_ID = 0

            Me.SetShipType(True)
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub SetShipType(ByVal booLoadModel As Boolean)
        Try
            'Me.cmbShipType.Items.Clear()  'Lan add 10/22/2006
            '*****************************
            Select Case Me.cmbCustomer.SelectedValue
                Case 2113   'Brightpoint
                    Me.cmbShipType.Items.Clear()
                    Me.cmbShipType.Items.Add("REFURBISHED")
                    Me.cmbShipType.Items.Add("BER")
                    Me.cmbShipType.Items.Add("CANCELLED")
                    Me.chkNoPalLbl.Checked = True
                    strGroupChar = "2"
                    '************************************
                    Me.cmdDevNotShip.Visible = False            'add by Lan 11/16/2006
                    Me.cmdReprintPrevSN.Visible = False         'add by Lan 11/17/2006
                    'Me.lblLot.Visible = False                   'add by Lan 11/17/2006
                    Me.lblLot.Visible = True                    'Changed by Lan 08/27/2007
                    Me.chkSNBarcode.Visible = False             'add by Lan 11/17/2006
                    If booLoadModel = True Then LoadModels(2)
                    '************************************
                Case 2219   'Gamestop
                    Me.cmbShipType.Items.Clear()
                    Me.cmbShipType.Items.Add("REFURBISHED")
                    Me.cmbShipType.Items.Add("RUR")
                    Me.cmbShipType.Items.Add("SCRAP")
                    Me.cmbShipType.Items.Add("INCOMPLETE")      'add by Lan 12/04/2006
                    Me.chkNoPalLbl.Checked = False
                    strGroupChar = "GS"
                    'Me.PanelSelectPrinter.Visible = True
                    '************************************
                    Me.cmdDevNotShip.Visible = True             'add by Lan 11/16/2006
                    Me.cmdReprintPrevSN.Visible = True          'add by Lan 11/17/2006
                    Me.lblLot.Visible = True                    'add by Lan 11/17/2006
                    Me.chkSNBarcode.Visible = True              'add by Lan 11/17/2006
                    If booLoadModel = True Then LoadModels(5)
                    '************************************
                Case 2238   'Trimble Mobile Solutions
                    Me.cmbShipType.Items.Clear()
                    Me.cmbShipType.Items.Add("REFURBISHED")
                    Me.cmbShipType.Items.Add("BER")
                    Me.cmbShipType.Items.Add("CANCELLED")
                    Me.chkNoPalLbl.Checked = True
                    strGroupChar = "2"
                    '************************************
                    Me.cmdDevNotShip.Visible = False            'add by Lan 11/16/2006
                    Me.cmdReprintPrevSN.Visible = False         'add by Lan 11/17/2006
                    Me.lblLot.Visible = True                    'Changed by Lan 08/27/2007
                    Me.chkSNBarcode.Visible = False             'add by Lan 11/17/2006
                    If booLoadModel = True Then LoadModels(6)
                    '************************************
                Case 2245   'Liquidity Services/Dyscern
                    Me.cmbShipType.Items.Add("REFURBISHED")
                    Me.cmbShipType.Items.Add("RUR")
                    Me.chkNoPalLbl.Checked = False
                    strGroupChar = "DS"
                    '************************************
                    Me.cmdDevNotShip.Visible = False            'add by Lan 11/16/2006
                    Me.cmdReprintPrevSN.Visible = False         'add by Lan 11/17/2006
                    Me.lblLot.Visible = True                    'Changed by Lan 08/27/2007
                    Me.chkSNBarcode.Visible = False             'add by Lan 11/17/2006
                    If booLoadModel = True Then LoadModels(2)
                    '************************************
                Case 2242    'Sonitrol
                    Me.cmbShipType.Items.Clear()
                    Me.cmbShipType.Items.Add("REFURBISHED")
                    Me.cmbShipType.Items.Add("RUR")
                    Me.chkNoPalLbl.Checked = False
                    strGroupChar = "ST"
                    '************************************
                    Me.cmdDevNotShip.Visible = False            'add by Lan 11/16/2006
                    Me.cmdReprintPrevSN.Visible = False         'add by Lan 11/17/2006
                    Me.lblLot.Visible = True                    'Changed by Lan 08/27/2007
                    Me.chkSNBarcode.Visible = False             'add by Lan 11/17/2006
                    If booLoadModel = True Then LoadModels(7)
                    '************************************
                Case 2254   'Plexus Corp.
                    Me.cmbShipType.Items.Clear()
                    Me.cmbShipType.Items.Add("PASSED")
                    Me.cmbShipType.Items.Add("FAILED")
                    Me.chkNoPalLbl.Checked = False
                    strGroupChar = "PL"
                    '************************************
                    Me.cmdDevNotShip.Visible = False            'add by Lan 07/28/2009
                    Me.cmdReprintPrevSN.Visible = False         'add by Lan 07/28/2009
                    Me.lblLot.Visible = False                   'Changed by Lan 07/28/2009
                    Me.chkSNBarcode.Visible = False             'add by Lan 07/28/2009
                    If booLoadModel = True Then LoadModels(7)
                    '************************************
                Case 2259    'PSS Exchange
                    Me.cmbShipType.Items.Clear()
                    Me.cmbShipType.Items.Add("REFURBISHED")
                    Me.cmbShipType.Items.Add("RUR")
                    Me.chkNoPalLbl.Checked = False
                    strGroupChar = "PE"
                    '************************************
                    Me.cmdDevNotShip.Visible = False            'add by Lan 11/16/2006
                    Me.cmdReprintPrevSN.Visible = False         'add by Lan 11/17/2006
                    Me.lblLot.Visible = True                    'Changed by Lan 08/27/2007
                    Me.chkSNBarcode.Visible = False             'add by Lan 11/17/2006
                    If booLoadModel = True Then LoadModels(7)
                Case 2278    'Advantor Systems/Infrasafe
                    Me.cmbShipType.Items.Clear()
                    Me.cmbShipType.Items.Add("REFURBISHED")
                    Me.cmbShipType.Items.Add("RUR")
                    Me.chkNoPalLbl.Checked = False
                    strGroupChar = "AS"
                    '************************************
                    Me.cmdDevNotShip.Visible = False            'add by Lan 11/16/2006
                    Me.cmdReprintPrevSN.Visible = False         'add by Lan 11/17/2006
                    Me.lblLot.Visible = True                    'Changed by Lan 08/27/2007
                    Me.chkSNBarcode.Visible = False             'add by Lan 11/17/2006
                    If booLoadModel = True Then LoadModels(7)
                    '************************************
                Case Else
                    Me.cmbCustomer.SelectedValue = 0
                    Throw New Exception("This screen is not setup to work for this customer.")
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Private Sub LoadPrinters()
    '    Dim pkInstalledPrinters As String

    '    Me.cmbPrinters.Items.Clear()
    '    Me.cmbPrinters.Items.Add("-- Select --")

    '    ' Find all printers installed
    '    For Each pkInstalledPrinters In _
    '        PrinterSettings.InstalledPrinters
    '        Me.cmbPrinters.Items.Add(pkInstalledPrinters)
    '    Next pkInstalledPrinters

    '    ' Set the combo to the first printer in the list
    '    Me.cmbPrinters.SelectedIndex = 0
    'End Sub

    Private Sub LoadCustomers()
        Dim dtCustomers As New DataTable()
        Try
            dtCustomers = objMisc.GetCustomers(, "2113, 2219, 2238, 2245, 2242, 2249, 2254, 2259, 2278 ")
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
        End Try
    End Sub

    '*********************************************************
    Private Sub LoadModels(ByVal iProd_ID As Integer)
        Dim dtModels As New DataTable()
        Try
            dtModels = objMisc.GetModels(iProd_ID, 1)
            With Me.cmbModel
                .DataSource = dtModels.DefaultView
                .DisplayMember = dtModels.Columns("Model_Desc").ToString
                .ValueMember = dtModels.Columns("Model_ID").ToString
                .SelectedValue = 0
            End With

        Catch ex As Exception
            MsgBox("Error in frmCellShipPallet_Generic.LoadModels:: " & ex.Message.ToString, MsgBoxStyle.Critical)
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
        Dim iParentGroupID As Integer = PSS.Core.[Global].ApplicationUser.GroupID

        Try
            LoadCustomers()
            '**************************************
            'LAN add this 10/23/2006
            If iParentGroupID = 14 Or iParentGroupID = 78 Then
                Me.cmbCustomer.SelectedValue = 2219
                LoadModels(5)

                Me.cmbShipType.Items.Clear()
                Me.cmbShipType.Items.Add("REFURBISHED")
                Me.cmbShipType.Items.Add("RUR")
                Me.cmbShipType.Items.Add("SCRAP")
                Me.cmbShipType.Items.Add("INCOMPLETE")  'add by Lan 12/04/2006
                Me.chkNoPalLbl.Checked = False
                strGroupChar = "GS"
                'Me.PanelSelectPrinter.Visible = True

                If PSS.Core.[Global].ApplicationUser.GetPermission("GSGetDevicesNotShipRpt") > 0 Then
                    Me.cmdDevNotShip.Visible = True     'add by Lan 11/16/2006
                Else
                    Me.cmdDevNotShip.Visible = False    'add by Lan 11/16/2006
                End If

                Me.cmdReprintPrevSN.Visible = True  'add by Lan 11/17/2006
                Me.cmdReprintPrevSN.Enabled = False 'add by Lan 11/17/2006
                Me.lblLot.Visible = True            'add by Lan 11/17/2006
                Me.chkSNBarcode.Visible = True      'add by Lan 11/17/2006
            ElseIf iParentGroupID = 3 Then
                Me.cmbCustomer.SelectedValue = 2113
                LoadModels(2)

                Me.cmbShipType.Items.Clear()
                Me.cmbShipType.Items.Add("REFURBISHED")
                Me.cmbShipType.Items.Add("BER")
                Me.cmbShipType.Items.Add("CANCELLED")
                Me.chkNoPalLbl.Checked = False
                strGroupChar = "2"
                '************************************
                Me.cmdDevNotShip.Visible = False            'add by Lan 11/16/2006
                Me.cmdReprintPrevSN.Visible = False         'add by Lan 11/17/2006
                Me.lblLot.Visible = False                   'add by Lan 11/17/2006
                Me.lblLot.Visible = True                    'Changed by Lan 08/27/2007
                Me.chkSNBarcode.Visible = False             'add by Lan 11/17/2006
                '************************************
            End If
            '**************************************

            'LoadModels()
            i = CheckIfMachineTiedToLine()
            If i = 0 Then
                MessageBox.Show("Machine is not associated with any 'Line'. Can't continue.", "Validate Computer", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.Close()
            End If
            LoadCellProductionNumbers()
            LoadWeeklyCellProductionNumbers()
            'LoadPrinters()

            If iParentGroupID <> 2 And iParentGroupID <> 3 And iParentGroupID <> 14 And iParentGroupID <> 77 And iParentGroupID <> 78 Then
                MessageBox.Show("Machine is not associated with a right group. Can't continue.", "Validate Computer", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("frmCellShipPallet_Generic.frmCellShipPallet_Load: " & Environment.NewLine & ex.Message.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
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
            'condition was added by lan on 07/09-2007
            ' to display only good unit if group_id = gamestop
            '**********************************************
            'dt1 = objMisc.LoadCellProductionNumbersByModel(strWorkDate, iLine_ID, 1 )
            If iGroup_ID = 14 Or iGroup_ID = 2 Then
                dt1 = objMisc.LoadCellProductionNumbersByModel(strWorkDate, iLine_ID, 1, iGroup_ID)
            Else
                dt1 = objMisc.LoadCellProductionNumbersByModel(strWorkDate, iLine_ID, 1, )
            End If

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
            'condition was added by lan on 07/09-2007
            ' to display only good unit if group_id = gamestop
            '**********************************************
            'dt1 = objMisc.LoadCellProductionNumbersByModel(strWorkDate, iLine_ID, 0)

            If iGroup_ID = 14 Or iGroup_ID = 2 Then
                dt1 = objMisc.LoadCellProductionNumbersByModel(strWorkDate, iLine_ID, 0, iGroup_ID)
            Else
                dt1 = objMisc.LoadCellProductionNumbersByModel(strWorkDate, iLine_ID, 0, )
            End If

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
        Dim objBp As New PSS.Data.Buisness.Brightpoint()

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

            '**************************************
            'Added by Lan on 08/27/2007
            '**************************************
            If Me.cmbCustomer.SelectedValue = 2113 And Me.lstDevices.Items.Count = 0 Then
                objBp.SetDOBFlag(Me.iPallet_ID, 0)
                Me.lblLot.Text = ""
            End If
            '**************************************

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Clear SN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            objBp = Nothing
        End Try
    End Sub

    Private Sub btnClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearAll.Click
        Dim str_sn As String = ""
        Dim i As Integer = 0
        Dim objBP As New PSS.Data.Buisness.Brightpoint()

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

            '***********************************
            'Add by Lan 11/17/2006
            strPrevSN = ""
            '***********************************

            '**************************************
            'Added by Lan on 08/27/2007
            '**************************************
            If Me.cmbCustomer.SelectedValue = 2113 And Me.lstDevices.Items.Count = 0 Then
                objBP.SetDOBFlag(Me.iPallet_ID, 0)
                Me.lblLot.Text = ""
            End If
            '**************************************
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Clear All SNs", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.txtSN.Focus()
            objBP = Nothing
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
            If Me.cmbShipType.SelectedIndex < 0 Then
                Exit Sub
            End If

            '***************************************
            'Me.cmbSkuLen.Text = ""
            'Me.PanelSKULen.Visible = False
            Me.panelPallet.Visible = False
            Me.lblPalletName.Text = ""
            Me.txtSN.Text = ""
            'Me.txtDevSN.Text = ""
            Me.lstDevices.DataSource = Nothing
            cmdCreatePallet.Visible = False
            If Me.cmbModel.SelectedValue > 0 AndAlso Me.cmbModel.SelectedValue <> 881 AndAlso (Me.cmbModel.SelectedValue <> 1175 And Me.cmbShipType.Text <> "FAILED") Then cmdCreatePallet.Visible = True

            'Globals
            strPalletName = ""
            iPallet_ID = 0
            strShipType = ""
            '***************************************
            strShipType = Me.cmbShipType.SelectedItem
            'Check if an open pallet is available
            GetPalletInfo()

            'Check if the pallet is already created for the criterion
            '12/05/2006
            'Added this condition let them RL group 
            'create multiple Pallets of the same type 
            If Me.cmbCustomer.SelectedValue <> 2219 Then
                If strPalletName = "" Then
                    ConstructPalletName()
                End If
            ElseIf (Me.cmbModel.SelectedValue = 881 And strShipType = "REFURBISHED") Or (Me.cmbCustomer.SelectedValue = 2219 AndAlso iModel_ID = 1175 AndAlso Me.cmbShipType.SelectedItem = "FAILED") Then
                Me.PanelSKULen.Visible = True
                Me.lblSkuLen.Visible = True
                Me.lblSkuLen.Text = ""
                Me.cmbSkuLen.SelectedIndex = 0
            Else
                Me.cmbSkuLen.SelectedIndex = 0
                Me.lblSkuLen.Text = ""
                Me.PanelSKULen.Visible = False
                ConstructPalletName()
            End If

            ''If strShipType = "REFURBISHED" Then
            ''    'Me.PanelSKULen.Visible = True
            ''    Me.panelPallet.Visible = False
            ''    Me.cmdCreatePallet.Visible = False
            ''Else
            ''    'Check if an open pallet is available
            ''    GetPalletInfo()
            ''    'Check if the pallet is already created for the criterion
            ''    If strPalletName = "" Then
            ''        ConstructPalletName()
            ''    End If
            ''End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Select Ship Type", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub cmbModel_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbModel.SelectionChangeCommitted
        Dim i As Integer = 0
        'Dim strGroupChar As String = Microsoft.VisualBasic.Right(Trim(strGroup), 1)

        Try
            '*****************************
            Me.cmbShipType.Text = ""
            Me.cmbSkuLen.Text = ""
            Me.grdPallets.ClearFields()
            Me.panelPallet.Visible = False
            Me.lblPalletName.Text = ""
            Me.txtSN.Text = ""
            'Me.txtDevSN.Text = ""
            Me.lstDevices.DataSource = Nothing
            Me.cmdCreatePallet.Visible = False
            Me.PanelSKULen.Visible = False
            Me.cmdCreatePallet.Visible = False

            'Globals
            iModel_ID = 0
            strShortModelName = ""
            strPalletName = ""
            iPallet_ID = 0
            '*****************************
            iModel_ID = Me.cmbModel.SelectedValue

            If iModel_ID = 0 Then
                Exit Sub
            ElseIf Me.cmbCustomer.SelectedValue = 0 Then
                MessageBox.Show("Please Select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.cmbModel.SelectedValue = 0
                Me.cmbCustomer.Focus()
                Exit Sub
            End If

            '**************************************
            'Added on 10-13-2009 for XBox360 Test
            '**************************************
            If Me.cmbCustomer.SelectedValue > 0 AndAlso Me.cmbCustomer.SelectedValue = 2219 AndAlso iModel_ID = 1175 Then
                Me.cmbShipType.Items.Clear()
                Me.cmbShipType.Items.Add("PASSED")
                Me.cmbShipType.Items.Add("FAILED")
                'clear combo Sku Length and set
                Me.cmbSkuLen.Items.Clear()
                Me.cmbSkuLen.Items.Add("")
                'Me.cmbSkuLen.Items.Add("MANUFACTURED 2005")
                Me.cmbSkuLen.Items.Add("ROL/E")
                Me.cmbSkuLen.Items.Add("MECHANICAL")
            Else
                Me.SetShipType(False)
                Me.cmbSkuLen.Items.Clear()
                Me.cmbSkuLen.Items.Add("")
                Me.cmbSkuLen.Items.Add("GFI")
                Me.cmbSkuLen.Items.Add("FIG 8")
            End If
            '**************************************

            If iModel_ID = 881 Then
                Me.PanelSKULen.Visible = True
                Me.cmbSkuLen.SelectedIndex = 0
                Me.cmbSkuLen.Text = ""
            Else
                Me.cmbSkuLen.SelectedIndex = 0
                Me.cmbSkuLen.Text = ""
                Me.PanelSKULen.Visible = False
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
            'RefreshPalletGrid(strGroupChar)
            RefreshPalletGrid()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Select Model", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    'Private Sub RefreshPalletGrid(ByVal strGroupChar As String, _
    '                                ByVal strShortModelName As String)
    'Private Sub RefreshPalletGrid(ByVal strGroupChar As String)
    Private Sub RefreshPalletGrid()
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
            dt1 = objMisc.GetOpenPalletsForModel(strGroupChar, strShortModelName, iModel_ID, Me.cmbCustomer.SelectedValue)
            'A max of 4 open pallets allowed at one time.
            If Me.cmbCustomer.SelectedValue <> 2219 Then
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
            Else
                Me.PanelPalletList.Top = Me.panelCriterion.Top + Me.panelCriterion.Height + 2
                System.Windows.Forms.Application.DoEvents()
                panelCriterion.Visible = True
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
            .Splits(0).DisplayColumns("Model_ID").Visible = False
        End With
    End Sub

    Private Sub cmbSkuLen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSkuLen.SelectedIndexChanged
        Try
            '***************************************
            Me.panelPallet.Visible = False
            Me.lblPalletName.Text = ""
            Me.txtSN.Text = ""
            'Me.txtDevSN.Text = ""
            Me.lstDevices.DataSource = Nothing
            If Me.cmbCustomer.SelectedValue = 0 Or Me.cmbModel.SelectedValue = 0 Or Me.cmbShipType.SelectedIndex < 0 Then Exit Sub
            '***************************************
            strSkuLength = Me.cmbSkuLen.SelectedItem
            ''Check if an open pallet is available
            'GetPalletInfo()
            ''Check if the pallet is already created for the criterion
            ConstructPalletName()

            '***************************************
            If Me.cmbCustomer.SelectedValue = 2219 AndAlso iModel_ID = 1175 AndAlso Me.cmbShipType.SelectedItem = "FAILED" AndAlso Me.cmbSkuLen.SelectedIndex > 0 Then
                If Not IsNothing(Me.grdPallets.DataSource) AndAlso Me.grdPallets.DataSource.Table.Rows.count > 0 Then
                    If Me.grdPallets.DataSource.Table.select("Pallet_SkuLen = '" & Me.cmbSkuLen.SelectedItem & "'").length > 0 Then cmdCreatePallet.Visible = False Else cmdCreatePallet.Visible = True
                End If
            ElseIf Me.cmbCustomer.SelectedValue = 2219 AndAlso iModel_ID = 881 AndAlso Me.cmbShipType.SelectedItem = "REFURBISHED" AndAlso Me.cmbSkuLen.SelectedIndex > 0 Then
                If Not IsNothing(Me.grdPallets.DataSource) AndAlso Me.grdPallets.DataSource.Table.Rows.count > 0 Then
                    If Me.grdPallets.DataSource.Table.select("Pallet_SkuLen = '" & Me.cmbSkuLen.SelectedItem & "'").length > 0 Then cmdCreatePallet.Visible = False Else cmdCreatePallet.Visible = True
                End If
            Else
                If Not IsNothing(Me.grdPallets.DataSource) AndAlso Me.grdPallets.DataSource.Table.Rows.count > 0 Then
                    If Me.grdPallets.DataSource.Table.select("Pallet_ShipType = " & Me.GetPalletShipTypeID(Me.cmbShipType.SelectedItem) & "").length > 0 Then cmdCreatePallet.Visible = False Else cmdCreatePallet.Visible = True
                Else
                    cmdCreatePallet.Visible = True
                End If
            End If
            '***************************************
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Select Ship Type", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Function ConstructPalletName() As String
        'Dim strGroupChar As String = ""
        'Dim strSkuChar As String = ""
        Dim strdt As String = Format(CDate(strWorkDate), "MMddyy")
        Dim strLastAlphaInPallet As String = ""
        Dim strShipTypeChars As String = ""

        Try
            If Me.cmbCustomer.SelectedValue <> 2219 Then
                If iPallet_ID = 0 Then
                    'strGroupChar = Microsoft.VisualBasic.Right(Trim(strGroup), 1)
                    strShipTypeChars = Microsoft.VisualBasic.Left(strShipType, 3)

                    'If strShipType <> "REFURBISHED" Then
                    '    strSkuChar = "F"    'Hardcode F for Sku Length for RUR/RTMs
                    'Else
                    '    strSkuChar = Microsoft.VisualBasic.Left(Trim(strSkuLength), 1)
                    'End If

                    'Get the last Alphabet 
                    strLastAlphaInPallet = objMisc.GetLastCharFromPalletName(strGroupChar, strdt)
                    strPalletName = strGroupChar & strShortModelName & strShipTypeChars & strdt & strLastAlphaInPallet
                    strPalletNameInitials = strGroupChar & strShortModelName & strShipTypeChars
                    If Me.cmbCustomer.SelectedValue > 0 AndAlso Me.cmbModel.SelectedValue > 0 AndAlso Me.cmbShipType.SelectedIndex > 0 Then
                        If Not IsNothing(Me.grdPallets.DataSource) Then
                            If Me.grdPallets.DataSource.Table.Select("Model_ID = " & Me.cmbModel.SelectedValue & " and Pallet_ShipType = " & Me.GetPalletShipTypeID(Me.cmbShipType.SelectedItem)).length = 0 Then
                                Me.cmdCreatePallet.Visible = True
                            End If
                        Else
                            Me.cmdCreatePallet.Visible = True
                        End If
                    End If
                Else
                    Me.cmdCreatePallet.Visible = False
                    Me.lblPalletName.Text = strPalletName
                    Me.panelPallet.Visible = True
                    Me.RefreshSNList()
                    Me.txtSN.Focus()
                End If

            Else
                'If iPallet_ID = 0 Then
                'strGroupChar = Microsoft.VisualBasic.Right(Trim(strGroup), 1)
                strShipTypeChars = Microsoft.VisualBasic.Left(strShipType, 3)

                'If strShipType <> "REFURBISHED" Then
                '    strSkuChar = "F"    'Hardcode F for Sku Length for RUR/RTMs
                'Else
                '    strSkuChar = Microsoft.VisualBasic.Left(Trim(strSkuLength), 1)
                'End If

                'Get the last Alphabet 
                strLastAlphaInPallet = objMisc.GetLastCharFromPalletName(strGroupChar & strShortModelName, strdt)
                strPalletName = strGroupChar & strShortModelName & strShipTypeChars & strdt & strLastAlphaInPallet
                strPalletNameInitials = strGroupChar & strShortModelName & strShipTypeChars
                If Me.cmbCustomer.SelectedValue > 0 AndAlso Me.cmbModel.SelectedValue > 0 AndAlso Me.cmbShipType.SelectedIndex > -1 Then
                    If Not IsNothing(Me.grdPallets.DataSource) Then
                        If Me.grdPallets.DataSource.Table.Select("Model_ID = " & Me.cmbModel.SelectedValue & " and Pallet_ShipType = " & Me.GetPalletShipTypeID(Me.cmbShipType.SelectedItem)).length = 0 Then
                            Me.cmdCreatePallet.Visible = True
                        End If
                    Else
                        Me.cmdCreatePallet.Visible = True
                    End If
                End If
                Me.panelPallet.Visible = False
                'Else
                '    Me.cmdCreatePallet.Visible = False
                '    Me.lblPalletName.Text = strPalletName
                '    Me.panelPallet.Visible = True
                '    Me.RefreshSNList()
                '    Me.txtSN.Focus()
                'End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub GetPalletInfo()
        'Dim strGroupChar As String = ""
        Dim strpalletString As String = ""
        'Dim strSkuChar As String = ""
        Dim strShipTypeChars As String = ""
        Dim dt1 As DataTable
        Dim R1 As DataRow

        Try
            'strGroupChar = Microsoft.VisualBasic.Right(Trim(strGroup), 1)
            strShipTypeChars = Microsoft.VisualBasic.Left(strShipType, 3)

            'If strShipType <> "REFURBISHED" Then
            '    strSkuChar = "F"
            'Else
            '    strSkuChar = Microsoft.VisualBasic.Left(Trim(strSkuLength), 1)
            'End If

            'strpalletString = strGroupChar & strShortModelName & strSkuChar & strShipTypeChars
            strpalletString = strGroupChar & strShortModelName & strShipTypeChars
            dt1 = objMisc.GetPalletInfo(strpalletString, Me.cmbCustomer.SelectedValue)

            If dt1.Rows.Count > 0 Then
                R1 = dt1.Rows(0)
                strPalletName = R1("Pallett_Name")
                iPallet_ID = R1("Pallett_ID").ToString
                Me.panelPallet.Visible = True

                '12/05/2006
                'Added this condition let them RL group 
                'create multiple Pallets of the same type 
                'If Me.cmbCustomer.SelectedValue <> 2219 Then
                '    Me.cmdCreatePallet.Visible = False
                'Else
                '    Me.cmdCreatePallet.Visible = True
                'End If
                Me.cmdCreatePallet.Visible = False

                Me.RefreshSNList()
                Me.txtSN.Focus()
            Else
                strPalletName = ""
                iPallet_ID = 0
                Me.panelPallet.Visible = False
                'Me.cmdCreatePallet.Visible = True
            End If
            Me.lblPalletName.Text = strPalletName

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdCreatePallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreatePallet.Click
        'Dim strGroupChar As String = Microsoft.VisualBasic.Right(Trim(strGroup), 1)
        Try
            '************************
            'Validations
            If Me.cmbCustomer.SelectedValue = 0 Then
                Throw New Exception("Select a customer.")
            ElseIf Trim(Me.strPalletName) = "" Then
                Throw New Exception("Pallet Name missing.")
            ElseIf Trim(strShipType) = "" Then
                Throw New Exception("Ship Type is not selected.")
            ElseIf (Me.cmbModel.SelectedValue = 881 And Trim(strShipType) = "REFURBISHED") Or (Me.cmbModel.SelectedValue = 1175 And Trim(strShipType) = "FAILED") Then
                If Trim(strSkuLength) = "" Then
                    Throw New Exception("SKU Length is not selected.")
                End If
            Else
                strSkuLength = ""
            End If

            Me.Enabled = False
            Cursor.Current = Cursors.WaitCursor

            'if me.cmbSkuLen.SelectedItem
            '************************
            iPallet_ID = objMisc.CreatePallet(strPalletName, strShipType, strPalletNameInitials, iModel_ID, Me.cmbCustomer.SelectedValue, strSkuLength)
            'If Me.cmbCustomer.SelectedValue <> 2219 Then
            '    Me.cmdCreatePallet.Visible = False
            'End If
            Me.cmdCreatePallet.Visible = False
            Me.panelPallet.Visible = True
            Me.lblPalletName.Text = strPalletName
            'RefreshPalletGrid(strGroupChar, strShortModelName)
            'RefreshPalletGrid(strGroupChar)
            RefreshPalletGrid()
            Me.RefreshSNList()
            Me.txtSN.Focus()
        Catch ex As Exception
            MessageBox.Show("cmdCreatePallet_Click: " & ex.ToString, "Create Pallet", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
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
        Dim iPrtRpt As Integer = 0
        'Dim strGroupChar As String = Microsoft.VisualBasic.Right(Trim(strGroup), 1)
        Dim dtShipPalletRpt As DataTable
        Dim objGamestopOpt As PSS.Data.Buisness.GameStopOpt

        Try
            If Me.cmbCustomer.SelectedValue = 0 Then
                Throw New Exception("Please select Customer.")
            End If
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
            If Me.chkNoPalLbl.Checked = True Then
                iPrtRpt = 0
            Else
                iPrtRpt = 3
            End If

            Me.Enabled = False
            Cursor.Current = Cursors.WaitCursor

            If Me.cmbCustomer.SelectedValue = 2219 Then
                If Me.iModel_ID = 881 Or Me.iModel_ID = 1112 Then
                    '******************************
                    'Added by Lan on 04/16/08
                    'Print pallet label 
                    '******************************
                    i = objMisc.ClosePallet(Me.cmbCustomer.SelectedValue, iPallet_ID, strPalletName, Me.lstDevices.Items.Count, Me.cmbShipType.SelectedValue, , )
                    objGamestopOpt = New PSS.Data.Buisness.GameStopOpt()
                    dtShipPalletRpt = objGamestopOpt.GetShipPalletData(strPalletName, Me.lstDevices.Items.Count.ToString, Me.cmbModel.Text & " " & Me.strSkuLength, Me.strShipType, New String() {"Shipper:", "", "Approval:"})
                    objGamestopOpt.PrintPalletLabel(dtShipPalletRpt, 3)
                ElseIf Me.iModel_ID = 1175 Then
                    i = objMisc.ClosePallet(Me.cmbCustomer.SelectedValue, iPallet_ID, strPalletName, Me.lstDevices.Items.Count, Me.cmbShipType.SelectedValue, , )
                    objGamestopOpt = New PSS.Data.Buisness.GameStopOpt()
                    dtShipPalletRpt = objGamestopOpt.GetShipPalletData(strPalletName, Me.lstDevices.Items.Count.ToString, Me.cmbModel.Text, Me.strShipType & " " & Me.strSkuLength, New String() {"Shipper:", "", "Approval:"})
                    objGamestopOpt.PrintPalletLabel(dtShipPalletRpt, 3)
                Else
                    i = objMisc.ClosePallet(Me.cmbCustomer.SelectedValue, iPallet_ID, strPalletName, Me.lstDevices.Items.Count, Me.cmbShipType.SelectedValue, , )
                    objGamestopOpt = New PSS.Data.Buisness.GameStopOpt()
                    dtShipPalletRpt = objGamestopOpt.GetShipPalletData(strPalletName, Me.lstDevices.Items.Count.ToString, Me.cmbModel.Text, Me.strShipType, New String() {"Shipper:", "", "Approval:"})
                    objGamestopOpt.PrintPalletLabel(dtShipPalletRpt, 3)
                End If
            Else
                i = objMisc.ClosePallet(Me.cmbCustomer.SelectedValue, iPallet_ID, strPalletName, Me.lstDevices.Items.Count, Me.cmbShipType.SelectedValue, iPrtRpt, )
            End If

            If i = 0 Then
                Throw New Exception("Pallet was not closed due to an error. Please contact IT.")
            End If

            'RefreshPalletGrid(strGroupChar, strShortModelName)
            'RefreshPalletGrid(strGroupChar)
            RefreshPalletGrid()
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
        Finally
            If Not IsNothing(dtShipPalletRpt) Then
                dtShipPalletRpt.Dispose()
                dtShipPalletRpt = Nothing
            End If
            objGamestopOpt = Nothing

            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub InitializePalletVar()
        Dim objBP As New PSS.Data.Buisness.Brightpoint()

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
            Me.iModel_ID = CInt(Me.grdPallets.Columns("Model_ID").Value)
            Me.cmbShipType.SelectedValue = Me.grdPallets.Columns("Pallet_ShipType").Value

            '*****
            Select Case Me.cmbCustomer.SelectedValue
                Case 2019      'ATCLE
                    Select Case Me.grdPallets.Columns("Pallet_ShipType").Value.ToString
                        Case "0"
                            strShipType = "REFURBISHED"
                        Case "1"
                            strShipType = "RUR"
                        Case "9"
                            strShipType = "RTM"
                    End Select
                Case 2113      'Brightpoint
                    Select Case Me.grdPallets.Columns("Pallet_ShipType").Value.ToString
                        Case "0"
                            strShipType = "REFURBISHED"
                        Case "1"
                            strShipType = "BER"
                        Case "9"
                            strShipType = "BER"
                        Case "10"
                            strShipType = "CANCELLED"
                    End Select
                    '******************************
                    'Added by Lan on 08/27/2007
                    '******************************
                    If objBP.IsDOBPallet(iPallet_ID) = True Then
                        Me.lblLot.Text = "Dobson Pallet"
                    Else
                        Me.lblLot.Text = ""
                    End If
                    '******************************
                Case 2219      'Gamestop
                    If Me.iModel_ID <> 1175 Then
                        Select Case Me.grdPallets.Columns("Pallet_ShipType").Value.ToString
                            Case "0"
                                strShipType = "REFURBISHED"
                            Case "1"
                                strShipType = "RUR"
                            Case "8"
                                strShipType = "SCRAP"
                            Case "9"            'added by Lan 12/04/2006
                                strShipType = "INCOMPLETE UNIT"
                        End Select
                    Else
                        Select Case Me.grdPallets.Columns("Pallet_ShipType").Value.ToString
                            Case "0"
                                strShipType = "PASSED"
                            Case "1"
                                strShipType = "FAILED"
                        End Select
                    End If
                Case 2238      'Trimble Mobile Solutions
                    Select Case Me.grdPallets.Columns("Pallet_ShipType").Value.ToString
                        Case "0"
                            strShipType = "REFURBISHED"
                        Case "1"
                            strShipType = "BER"
                        Case "9"
                            strShipType = "BER"
                        Case "10"
                            strShipType = "CANCELLED"
                    End Select
                Case 2245      'Liquidity Services/Dyscern
                    Select Case Me.grdPallets.Columns("Pallet_ShipType").Value.ToString
                        Case "0"
                            strShipType = "REFURBISHED"
                        Case "1"
                            strShipType = "RUR"
                    End Select
                Case 2242      'Sonitrol
                    Select Case Me.grdPallets.Columns("Pallet_ShipType").Value.ToString
                        Case "0"
                            strShipType = "REFURBISHED"
                        Case "1"
                            strShipType = "RUR"
                    End Select
                Case 2249
                    Select Case Me.grdPallets.Columns("Pallet_ShipType").Value.ToString
                        Case "0"
                            strShipType = "REFURBISHED"
                        Case "1"
                            strShipType = "RUR"
                    End Select
                Case 2254      'Plexus Corp.
                    Select Case Me.grdPallets.Columns("Pallet_ShipType").Value.ToString
                        Case "0"
                            strShipType = "PASSED"
                        Case "1"
                            strShipType = "FAILED"
                    End Select
                Case Else
            End Select

            '*******************************************
            strSkuLength = Me.grdPallets.Columns("Pallet_SkuLen").Value.ToString

            If Me.cmbModel.SelectedValue = 881 Or (Me.cmbModel.SelectedValue = 1175 And Trim(strShipType) = "FAILED") Then
                Me.lblSkuLen.Visible = True
                Me.lblSkuLen.Text = strSkuLength
            Else
                Me.lblSkuLen.Visible = False
                Me.lblSkuLen.Text = ""
            End If
            '*******************************************

            Me.RefreshSNList()
            Me.txtSN.Focus()

        Catch ex As Exception
            MessageBox.Show("cmdCreatePallet_Click: " & ex.ToString, "Create Pallet", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            objBP = Nothing
        End Try
    End Sub

    Private Sub grdPallets_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdPallets.Click
        Me.cmbShipType.Text = ""
        Me.cmbSkuLen.Text = ""
        cmdCreatePallet.Visible = False
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

            '*******************************************
            'Added by Lan 11/17/2006
            If Me.cmbCustomer.SelectedValue = 2219 Then
                'Dim dtSN As DataTable
                'Dim objDt As PSS.Data.Buisness.CellStarBER
                'objDt = New PSS.Data.Buisness.CellStarBER()
                Dim strLstBoxSN As String = ""

                'dtSN = objDt.GetSelectedDt("select device_sn from tdevice where pallett_id = " & iPallet_ID & ";")
                If dt1.Rows.Count > 0 Then
                    strLstBoxSN = dt1.Rows(0)("device_sn")
                    strLot = objMisc.GetDevLotNo(UCase(Trim(strLstBoxSN)))
                    Me.lblLot.Text = strLot
                Else
                    strLot = ""
                    Me.lblLot.Text = ""
                End If

                '''clean up object
                ''If Not IsNothing(dtSN) Then
                ''    dtSN.Dispose()
                ''    dtSN = Nothing
                ''End If
                ''If Not IsNothing(objDt) Then
                ''    objDt = Nothing
                ''End If

                'Add 2006/11/28 disable reprint barcodelabel button if user switch pallet
                Me.cmdReprintPrevSN.Enabled = False
            End If
            '*******************************************
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
        'Dim strGroupChar As String = Microsoft.VisualBasic.Right(Trim(strGroup), 1)
        Dim strSN As String = UCase(Trim(txtSN.Text))
        'Dim strSkuChar As String = ""
        Dim strShipTypeChars As String = ""
        Dim objBP As New PSS.Data.Buisness.Brightpoint()
        Dim iQCChkFlg As Integer = 0
        Dim objQC As PSS.Data.Buisness.QC
        Dim iCustID As Integer = Me.cmbCustomer.SelectedValue
        Dim objDevice As PSS.Rules.Device
        Dim dt As DataTable

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
            ElseIf Me.cmbCustomer.SelectedValue = 0 Then
                Throw New Exception("Customer is not selected.")
            End If

            '***************************************************
            'Added by Lan on 09/16/2007
            'Prevent the user from adding more devices to closed pallet.
            'This happen when a pallet open at the 2 computer, computer 1 
            '  close the pallet and refesh the screen while the other computer screen 
            '  did not get refresh. This check will force the user to refresh the screen.
            '***************************************************
            i = Me.objMisc.IsPalletClosed(Me.iPallet_ID)
            If i = -1 Then
                MsgBox("Pallet ID does not exist.", MsgBoxStyle.Information, "CheckPalletAlreadyClosed")
                Exit Sub
            ElseIf i = 1 Then
                MsgBox("This ""Pallet"" was closed by other user. Please refesh the screen to get the update.", MsgBoxStyle.Information, "CheckPalletAlreadyClosed")
                Exit Sub
            End If
            i = 0

            '****************************************************
            'XBOX 360 Testing unit only
            'Autobill pass or fail billcode base on ship type
            '****************************************************
            If Me.cmbCustomer.SelectedValue = 2219 AndAlso Me.cmbModel.SelectedValue = 1175 Then
                dt = Generic.GetDeviceInfoInWIP(Me.txtSN.Text.Trim.ToLower, iCustID)
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Device does not exist in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtSN.SelectAll()
                    Me.txtSN.Focus()
                    Exit Sub
                ElseIf dt.Rows.Count > 1 Then
                    MessageBox.Show("Device exist more than one in WIP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtSN.SelectAll()
                    Me.txtSN.Focus()
                    Exit Sub
                Else
                    If Me.strShipType = "PASSED" Then
                        ''*************************************************
                        ''Fail unit if manufacture year before or at 2005
                        ''*************************************************
                        'If Mid(Me.txtSN.Text.Trim, 8, 1) <= 5 Then
                        '    MessageBox.Show("This unit was manufacturer before year 2006 therefore you need to fail it.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        '    Me.txtSN.SelectAll()
                        '    Exit Sub
                        'End If

                        '*************************************************
                        objDevice = New PSS.Rules.Device(dt.Rows(0)("Device_ID"))
                        If Generic.IsBillcodeExisted(dt.Rows(0)("Device_ID"), 1664) = True Then 'fail
                            objDevice.DeletePart(1664)
                        End If
                        If Generic.IsBillcodeExisted(dt.Rows(0)("Device_ID"), 1663) = False Then    'pass
                            objDevice.AddPart(1663)
                        End If
                        objDevice.Update()
                    ElseIf Me.strShipType = "FAILED" Then
                        objDevice = New PSS.Rules.Device(dt.Rows(0)("Device_ID"))
                        If Generic.IsBillcodeExisted(dt.Rows(0)("Device_ID"), 1663) = True Then   'pass
                            objDevice.DeletePart(1663)
                        End If
                        If Generic.IsBillcodeExisted(dt.Rows(0)("Device_ID"), 1664) = False Then    'fail
                            objDevice.AddPart(1664)
                        End If
                        objDevice.Update()
                    Else
                        Throw New Exception("Can't define ship type.")
                    End If
                End If
            End If

            '***************************************************
            'Step 1: Check REF/RUR/RTM, RUR/RTM with parts
            strShipTypeChars = Microsoft.VisualBasic.Left(strShipType, 3)
            i = objMisc.CheckDevice_REF_RUR_RTM(strSN, strShipTypeChars, Me.cmbCustomer.SelectedValue)

            '***************************************************
            'Added by Lan on 08/27/2007: Can not put any DOB device on to RUR or RTM pallet
            If Me.cmbCustomer.SelectedValue = 2113 And (UCase(Trim(strShipTypeChars)) = "RUR" Or UCase(Trim(strShipTypeChars)) = "BER") Then   'Brightpoint
                i = objMisc.CheckDOBSalvageDevice(strSN, Me.cmbCustomer.SelectedValue)
            End If

            '***************************************************
            'Added by Lan on 08/27/2007: Set DOBFlg in tpallett if pallett contain Dobson devices 
            If Me.cmbCustomer.SelectedValue = 2113 Then     'Brightpoint
                i = objMisc.ValidatePalletAndDevice_Enterprise(Me.iPallet_ID, strSN, Me.lstDevices.Items.Count, Me.cmbCustomer.SelectedValue)

                '******************************
                If objBP.IsDOBPallet(iPallet_ID) = True Then
                    Me.lblLot.Text = "Dobson Pallet"
                Else
                    Me.lblLot.Text = ""
                End If
                '******************************
            End If

            '***************************************************
            'Step 2: Check if the Device is already scanned in
            i = objMisc.CheckPalletAlreadyAssigned(strSN)
            If i = 0 Then
                MsgBox("This device already has a pallet assigned. Can't put it on this pallet.", MsgBoxStyle.Information, "CheckPalletAlreadyAssigned")
                Me.txtSN.Text = ""
                'Me.txtDevSN.Text = ""
                Me.txtSN.Focus()
                Exit Sub
            End If

            '***************************************************
            'Step 3: Check if the Device is already scanned in
            For i = 0 To Me.lstDevices.Items.Count - 1
                If UCase(Trim(Me.lstDevices.Items(i).ToString)) = strSN Then
                    MsgBox("This device is already scanned in. Try another one.", MsgBoxStyle.Information, "Device Scan")
                    Me.txtSN.Text = ""
                    'Me.txtDevSN.Text = ""
                    Me.txtSN.Focus()
                    Exit Sub
                End If
            Next

            ''***************************************************
            ''Step 4: Check if this device belongs to group Pallett is tied to
            'i = objMisc.CheckDeviceGroup(strSN, iGroup_ID)

            '***************************************************
            'Step 5: Check device model
            If strShipType <> "REFURBISHED" And Me.cmbCustomer.SelectedValue = 2219 And (Me.iModel_ID = 881 Or Me.iModel_ID = 1112) Then
                'Edit on 07/14/2008 allows GameStop to mix Xbox and XBox GFI model for non-refurbished pallet only
                i = objMisc.GetDeviceModel(strSN)
                If i <> 881 And i <> 1112 Then
                    MsgBox("This device is of a different model. Can't put it on this pallet.", MsgBoxStyle.Information, "Check Device Model")
                    Me.txtSN.Text = ""
                    'Me.txtDevSN.Text = ""
                    Me.txtSN.Focus()
                    Exit Sub
                End If
            Else
                i = objMisc.CheckDeviceModel(strSN, strShortModelName, iCustID)
                If i = 0 Then
                    MsgBox("This device is of a different model. Can't put it on this pallet.", MsgBoxStyle.Information, "Check Device Model")
                    Me.txtSN.Text = ""
                    'Me.txtDevSN.Text = ""
                    Me.txtSN.Focus()
                    Exit Sub
                End If
            End If

            '***************************************************
            'STEP 6: Check if the QC Check needs to be done and
            ' Device has been passed in all QC Steps.
            '***************************************************
            objQC = New PSS.Data.Buisness.QC()
            If strShipType = "REFURBISHED" Then
                If Me.cmbCustomer.SelectedValue = 2113 Then        'Check for Brightpoint only
                    iQCChkFlg = objMisc.IsQCCheckNeeded(strSN)
                    If iQCChkFlg = 1 Then
                        '***************************
                        'Check Functional, FQA, Cosmetic
                        Me.objMisc.CheckDeviceQC(strSN)
                        '***************************
                        'Added by Lan on 10/03/2007. 
                        'Prevent failed AQL unit to be added to pass pallet
                        If objQC.CheckAQLFailed(strSN) = True Then
                            Throw New Exception("Device has been failed at AQL test.")
                        End If
                        '***************************
                    End If  'QC Check needed
                ElseIf Me.cmbCustomer.SelectedValue = 2245 Then 'Liquidity Services/Dyscern
                    If objMisc.IsQCPassedByQCType(strSN, 2) = False Then
                        Throw New Exception("Device has not been QC PASSED in FQA Test.")
                    ElseIf objMisc.IsQCPassedByQCType(strSN, 4) = False Then
                        Throw New Exception("Device has not been QC PASSED in AQL Test.")
                    End If
                ElseIf Me.cmbCustomer.SelectedValue = 2219 And Me.iModel_ID <> 1175 Then  'GameStop and XBOX model
                    If objMisc.IsQCPassedByQCType(strSN, 1) = False Then    'Function
                        Throw New Exception("Device has not been QC PASSED in Functional Test from " & PSS.Data.Buisness.Generic.GetCostCenterDescOfDeviceInWIP(strSN, Me.cmbCustomer.SelectedValue) & ".")
                    ElseIf objQC.CheckAQLFailed(strSN) = True Then
                        '***************************
                        'Prevent failed AQL unit to be added to pass pallet
                        Throw New Exception("Device has been failed at AQL test.")
                    End If
                    '***************************
                ElseIf Me.cmbCustomer.SelectedValue = 2249 Then
                    If objMisc.IsQCPassedByQCType(strSN, 1) = False Then    'Function
                        Throw New Exception("Device has not been QC PASSED in Functional Test from " & PSS.Data.Buisness.Generic.GetCostCenterDescOfDeviceInWIP(strSN, Me.cmbCustomer.SelectedValue) & ".")
                    ElseIf objQC.CheckAQLFailed(strSN) = True Then
                        '***************************
                        'Prevent failed AQL unit to be added to pass pallet
                        Throw New Exception("Device has been failed at AQL test.")
                    End If
                End If  'Customer
            End If  'strShipType

            '***************************************************
            'Print SN Barcode Label
            '***************************************************
            If Me.cmbCustomer.SelectedValue = 2219 AndAlso Me.iModel_ID <> 1175 Then     'for GAMESTOP only
                '***************************************************
                'add by Lan 11/14/2006. This will prevent mixing lot
                '***************************************************
                Dim strSNLot As String = ""
                strSNLot = objMisc.GetDevLotNo(strSN)
                If strSNLot <> "" Then
                    If Me.lstDevices.Items.Count = 0 Then
                        strLot = strSNLot
                    Else
                        ''For now, It is ok to mix lot 
                        'If strLot <> strSNLot Then
                        '    Throw New Exception(Environment.NewLine & "The current pallet is for Lot " & strLot & ". This device belongs to Lot " & strSNLot & " Can not put it on this pallet." & Environment.NewLine)
                        'End If
                    End If
                Else
                    Throw New Exception(Environment.NewLine & "Can not find lot number for this device." & Environment.NewLine)
                End If
                '****************************************************
                If strShipType = "REFURBISHED" Then
                    If Me.chkSNBarcode.Checked = False Then
                        PrintSNLabel(strSN)
                    End If
                End If
            End If

            '***************************************************
            'if above all is fine then add it to the list and update the database
            '***************************************************
            i = objMisc.UpdateDeviceWithPallet(strSN, iPallet_ID, strWorkDate, iUserID, iWCLocation_ID, iLine_ID, iGroup_ID)

            '***************************************************
            'Added by Lan 11/17/2006. Reprint barcode label of last SN
            '***************************************************
            If Me.cmbCustomer.SelectedValue = 2219 AndAlso Me.iModel_ID <> 1175 Then
                Me.strPrevSN = strSN
                Me.cmdReprintPrevSN.Enabled = True
            End If
            '***************************************************

            Me.RefreshSNList()
            Me.LoadCellProductionNumbers()
            Me.LoadWeeklyCellProductionNumbers()
            Me.txtSN.Text = ""
            'Me.txtDevSN.Text = ""
            Me.txtSN.Focus()

            'End If
        Catch ex As Exception
            MessageBox.Show("ProcessSN: " & ex.ToString, "Device Scan", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.txtSN.Text = ""
            'Me.txtDevSN.Text = ""
            Me.txtSN.Focus()
        Finally
            objBP = Nothing
            objQC = Nothing
            objDevice = Nothing
            Generic.DisposeDT(dt)
        End Try
    End Sub

    Private Sub PrintSNLabel(ByVal strSN As String)
        Dim rptApp As ReportDocument
        Dim strReportLoc As String

        Try
            strReportLoc = PSS.Data.ConfigFile.GetBaseReportPath

            rptApp = New ReportDocument()

            With rptApp
                .Load(strReportLoc & "SN Barcode Label Push.rpt")
                .SetParameterValue("Device SN", strSN)
                '.PrintOptions.PrinterName = PSS.Data.ConfigFile.GetBarcodePrinterName
                .PrintToPrinter(1, True, 0, 0)
                .Close()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "SN Barcode Label", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtSN_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp
        If e.KeyValue = 13 Then
            If Me.cmbCustomer.SelectedValue = 0 Then
                Throw New Exception("Please select Customer.")
            End If
            If Trim(Me.txtSN.Text) = "" Then
                'MessageBox.Show("Please scan in the 'Box IMEI'.", "Scan Box IMEI", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            ElseIf Me.cmbModel.SelectedValue = 881 And strShipType = "REFURBISHED" And Me.lstDevices.Items.Count >= 36 Then     'XBOX
                MessageBox.Show("Quantity for a REFURBISHED pallet can't be more than 36.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.txtSN.SelectAll()
                Exit Sub
            Else
                ProcessSN()
            End If
        End If
    End Sub

    Private Sub cmdReopenPallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReopenPallet.Click
        Dim str_pallet As String = ""
        Dim i As Integer = 0
        'Dim strGroupChar As String = Microsoft.VisualBasic.Right(Trim(strGroup), 1)

        Try
            If Me.cmbCustomer.SelectedValue = 0 Then
                Throw New Exception("Please select Customer.")
            End If
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
            'RefreshPalletGrid(strGroupChar)
            RefreshPalletGrid()

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
                '********************
                'Lan add 11/17/2006
                If Me.cmbCustomer.SelectedValue = 0 Then
                    Throw New Exception("Please select customer.")
                End If
                '********************
                objMisc.PrintPalletDeviceCountRpt(iPalletID, Me.cmbCustomer.SelectedValue)
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


    '******************************************************************************
    'add by Lan 11/16/2006. Display all device have not ship
    Private Sub cmdDevNotShip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDevNotShip.Click
        Const strTabPageTitle As String = "GameStop Devices Not Shipped"
        Dim frmReport As RptViewer
        Dim frmRP As frmReportParameters
        Dim win As Crownwood.Magic.Controls.TabPage

        Try
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmReportParameters(strTabPageTitle, Data.CrystalReports.Report_Call.SHIPPING_GAMESTOP_DEVICES_NOT_SHIPPED))
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            frmReport = Nothing
        End Try

    End Sub

    Private Sub OpenWin(ByVal strTabPageTitle As String, ByRef win As Crownwood.Magic.Controls.TabPage, ByRef objForm As Object)
        Try
            win = New Crownwood.Magic.Controls.TabPage(strTabPageTitle, objForm)

            Gui.MainWin.MainWin.wrkArea.TabPages.Add(win)
            win.Selected = True
        Catch ex As Exception
            MessageBox.Show("A problem has occurred in Gui.MainWin.MenuMain.OpenWin: " & ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************************
    'add by Lan 11/16/2006. Reprint last scan sn label
    Private Sub cmdReprintPrevSN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReprintPrevSN.Click
        If strPrevSN <> "" Then
            PrintSNLabel(strPrevSN)
        Else
            '''MessageBox.Show("Can not find last scan SN.", "Reprint Previous scan SN", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub cmdDeletePallett_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeletePallett.Click
        Dim i As Integer = 0

        Try
            If iPallet_ID = 0 Then
                Exit Sub
            End If
            If MessageBox.Show("Are you sure you want to delete this Pallet?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                i = objMisc.DeletePallet(iPallet_ID)
                MessageBox.Show("Pallet has been deleted.")

                RefreshPalletGrid()

                Me.lblPalletName.Text = ""
                strShipType = ""
                Me.lblPalletName.Text = ""
                Me.panelPallet.Visible = False
                iPallet_ID = 0
                strPalletName = ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Function GetPalletShipTypeID(ByVal strShipTypeDesc As String) As Integer
        Dim i As Integer = -1

        If Me.cmbCustomer.SelectedValue = 2254 Or (Me.cmbCustomer.SelectedValue = 2219 And Me.cmbModel.SelectedValue = 1175) Then
            Select Case strShipType
                Case "PASSED"
                    i = 0
                Case "FAILED"
                    i = 1
            End Select
        Else
            Select Case strShipType
                Case "REFURBISHED"
                    i = 0
                Case "RUR"
                    i = 1
                Case "RTM"
                    i = 9
                Case "BER"
                    i = 1
                Case "SCRAP"
                    i = 8
                Case "INCOMPLETE"       'added by Lan 12/04/2004
                    i = 9
                Case "CANCELLED"
                    i = 10
            End Select
        End If

        Return i
    End Function
End Class

