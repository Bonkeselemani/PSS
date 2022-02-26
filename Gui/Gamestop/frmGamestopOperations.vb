Option Explicit On 

Imports PSS.Core.[Global]

Public Class frmGamestopOperations
    Inherits System.Windows.Forms.Form

    Private _objGamestopOpt As PSS.Data.Buisness.GameStopOpt

    Private GstrMachine As String = System.Net.Dns.GetHostName
    Private GstrUserName As String = ApplicationUser.User
    Private GiUser_ID As Integer = ApplicationUser.IDuser
    Private GiEmpNo As Integer = ApplicationUser.NumberEmp
    Private GiShift_ID As Integer = ApplicationUser.IDShift
    Private GstrWorkDate As String = ApplicationUser.Workdate
    Private GiMCCGroup_ID As String = 0
    Private GstrGroupDesc As String = ApplicationUser.Group_Desc

    Private Const GiCust_ID As Integer = 2219
    Private Const GiLoc_ID As Integer = 2743
    Private Const GiProd_ID As Integer = 5


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _objGamestopOpt = New PSS.Data.Buisness.GameStopOpt()
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblGroup As System.Windows.Forms.Label
    Friend WithEvents lblMachine As System.Windows.Forms.Label
    Friend WithEvents lblShift As System.Windows.Forms.Label
    Friend WithEvents lblWorkDate As System.Windows.Forms.Label
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblShipModel As System.Windows.Forms.Label
    Friend WithEvents txtBillDevSN As System.Windows.Forms.TextBox
    Friend WithEvents btnBillRemoveAll As System.Windows.Forms.Button
    Friend WithEvents btnBillRemoveOne As System.Windows.Forms.Button
    Friend WithEvents cmbBillModel As PSS.Gui.Controls.ComboBox
    Friend WithEvents lblBillScanCnt As System.Windows.Forms.Label
    Friend WithEvents lstBillSNs As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbBillBillcodes As PSS.Gui.Controls.ComboBox
    Friend WithEvents btnBill As System.Windows.Forms.Button
    Friend WithEvents btnBillBillRURScrap As System.Windows.Forms.Button
    Friend WithEvents tpgCreateShipPallet As System.Windows.Forms.TabPage
    Friend WithEvents tpgBill As System.Windows.Forms.TabPage
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents btnCreateShipPallet As System.Windows.Forms.Button
    Friend WithEvents btnCSP_CreatePallet As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbCSP_ShipType As PSS.Gui.Controls.ComboBox
    Friend WithEvents txtCSP_Qty As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbCSP_Model As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblBanner As System.Windows.Forms.Label
    Friend WithEvents btnCSP_Edit As System.Windows.Forms.Button
    Friend WithEvents btnCSP_Delete As System.Windows.Forms.Button
    Friend WithEvents btnCSP_Reprint As System.Windows.Forms.Button
    Friend WithEvents btnCSP_Cancel As System.Windows.Forms.Button
    Friend WithEvents lblCSP_EditPalletName As System.Windows.Forms.Label
    Friend WithEvents tpgEditManfDate As System.Windows.Forms.TabPage
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtEMD_SN As System.Windows.Forms.TextBox
    Friend WithEvents dgEMD_SNInfo As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnEMFD_Go As System.Windows.Forms.Button
    Friend WithEvents btnEditManufDate As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtEMD_NewManfDate As System.Windows.Forms.TextBox
    Friend WithEvents btnEMFD_UpdateNewMD As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmGamestopOperations))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnEditManufDate = New System.Windows.Forms.Button()
        Me.lblGroup = New System.Windows.Forms.Label()
        Me.btnBill = New System.Windows.Forms.Button()
        Me.lblMachine = New System.Windows.Forms.Label()
        Me.lblShift = New System.Windows.Forms.Label()
        Me.lblWorkDate = New System.Windows.Forms.Label()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.btnCreateShipPallet = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbBillBillcodes = New PSS.Gui.Controls.ComboBox()
        Me.lblShipModel = New System.Windows.Forms.Label()
        Me.btnBillBillRURScrap = New System.Windows.Forms.Button()
        Me.txtBillDevSN = New System.Windows.Forms.TextBox()
        Me.btnBillRemoveAll = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBillRemoveOne = New System.Windows.Forms.Button()
        Me.cmbBillModel = New PSS.Gui.Controls.ComboBox()
        Me.lblBillScanCnt = New System.Windows.Forms.Label()
        Me.lstBillSNs = New System.Windows.Forms.ListBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpgBill = New System.Windows.Forms.TabPage()
        Me.tpgCreateShipPallet = New System.Windows.Forms.TabPage()
        Me.lblCSP_EditPalletName = New System.Windows.Forms.Label()
        Me.btnCSP_Cancel = New System.Windows.Forms.Button()
        Me.btnCSP_Reprint = New System.Windows.Forms.Button()
        Me.btnCSP_Edit = New System.Windows.Forms.Button()
        Me.btnCSP_Delete = New System.Windows.Forms.Button()
        Me.btnCSP_CreatePallet = New System.Windows.Forms.Button()
        Me.cmbCSP_ShipType = New PSS.Gui.Controls.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCSP_Qty = New System.Windows.Forms.TextBox()
        Me.cmbCSP_Model = New PSS.Gui.Controls.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tpgEditManfDate = New System.Windows.Forms.TabPage()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnEMFD_UpdateNewMD = New System.Windows.Forms.Button()
        Me.txtEMD_NewManfDate = New System.Windows.Forms.TextBox()
        Me.btnEMFD_Go = New System.Windows.Forms.Button()
        Me.dgEMD_SNInfo = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtEMD_SN = New System.Windows.Forms.TextBox()
        Me.lblBanner = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tpgBill.SuspendLayout()
        Me.tpgCreateShipPallet.SuspendLayout()
        Me.tpgEditManfDate.SuspendLayout()
        CType(Me.dgEMD_SNInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left)
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnEditManufDate, Me.lblGroup, Me.btnBill, Me.lblMachine, Me.lblShift, Me.lblWorkDate, Me.lblUserName, Me.lblTitle, Me.btnCreateShipPallet})
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(160, 520)
        Me.Panel1.TabIndex = 1
        '
        'btnEditManufDate
        '
        Me.btnEditManufDate.BackColor = System.Drawing.Color.Black
        Me.btnEditManufDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditManufDate.ForeColor = System.Drawing.Color.Lime
        Me.btnEditManufDate.Location = New System.Drawing.Point(8, 304)
        Me.btnEditManufDate.Name = "btnEditManufDate"
        Me.btnEditManufDate.Size = New System.Drawing.Size(136, 24)
        Me.btnEditManufDate.TabIndex = 144
        Me.btnEditManufDate.Tag = "False"
        Me.btnEditManufDate.Text = "EDIT MF DATE"
        '
        'lblGroup
        '
        Me.lblGroup.BackColor = System.Drawing.Color.Transparent
        Me.lblGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroup.ForeColor = System.Drawing.Color.Lime
        Me.lblGroup.Location = New System.Drawing.Point(8, 72)
        Me.lblGroup.Name = "lblGroup"
        Me.lblGroup.Size = New System.Drawing.Size(136, 16)
        Me.lblGroup.TabIndex = 94
        Me.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnBill
        '
        Me.btnBill.BackColor = System.Drawing.Color.Black
        Me.btnBill.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBill.ForeColor = System.Drawing.Color.Lime
        Me.btnBill.Location = New System.Drawing.Point(9, 232)
        Me.btnBill.Name = "btnBill"
        Me.btnBill.Size = New System.Drawing.Size(135, 23)
        Me.btnBill.TabIndex = 1
        Me.btnBill.Tag = "False"
        Me.btnBill.Text = "BILL"
        '
        'lblMachine
        '
        Me.lblMachine.BackColor = System.Drawing.Color.Transparent
        Me.lblMachine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMachine.ForeColor = System.Drawing.Color.Lime
        Me.lblMachine.Location = New System.Drawing.Point(8, 96)
        Me.lblMachine.Name = "lblMachine"
        Me.lblMachine.Size = New System.Drawing.Size(136, 16)
        Me.lblMachine.TabIndex = 92
        Me.lblMachine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblShift
        '
        Me.lblShift.BackColor = System.Drawing.Color.Transparent
        Me.lblShift.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShift.ForeColor = System.Drawing.Color.Lime
        Me.lblShift.Location = New System.Drawing.Point(8, 144)
        Me.lblShift.Name = "lblShift"
        Me.lblShift.Size = New System.Drawing.Size(136, 16)
        Me.lblShift.TabIndex = 88
        Me.lblShift.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWorkDate
        '
        Me.lblWorkDate.BackColor = System.Drawing.Color.Transparent
        Me.lblWorkDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWorkDate.ForeColor = System.Drawing.Color.Lime
        Me.lblWorkDate.Location = New System.Drawing.Point(8, 168)
        Me.lblWorkDate.Name = "lblWorkDate"
        Me.lblWorkDate.Size = New System.Drawing.Size(136, 16)
        Me.lblWorkDate.TabIndex = 84
        Me.lblWorkDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUserName
        '
        Me.lblUserName.BackColor = System.Drawing.Color.Transparent
        Me.lblUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserName.ForeColor = System.Drawing.Color.Lime
        Me.lblUserName.Location = New System.Drawing.Point(8, 120)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(136, 16)
        Me.lblUserName.TabIndex = 83
        Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.Black
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle.Location = New System.Drawing.Point(2, 8)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(152, 40)
        Me.lblTitle.TabIndex = 93
        Me.lblTitle.Text = "GAMESTOP OPERATIONS"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCreateShipPallet
        '
        Me.btnCreateShipPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreateShipPallet.ForeColor = System.Drawing.Color.Lime
        Me.btnCreateShipPallet.Location = New System.Drawing.Point(8, 264)
        Me.btnCreateShipPallet.Name = "btnCreateShipPallet"
        Me.btnCreateShipPallet.Size = New System.Drawing.Size(136, 32)
        Me.btnCreateShipPallet.TabIndex = 143
        Me.btnCreateShipPallet.Tag = "False"
        Me.btnCreateShipPallet.Text = "CREATE SHIP PALLET"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(216, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 142
        Me.Label2.Text = "Bill Code:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbBillBillcodes
        '
        Me.cmbBillBillcodes.AutoComplete = True
        Me.cmbBillBillcodes.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBillBillcodes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBillBillcodes.ForeColor = System.Drawing.Color.Black
        Me.cmbBillBillcodes.ItemHeight = 13
        Me.cmbBillBillcodes.Location = New System.Drawing.Point(216, 24)
        Me.cmbBillBillcodes.Name = "cmbBillBillcodes"
        Me.cmbBillBillcodes.Size = New System.Drawing.Size(184, 21)
        Me.cmbBillBillcodes.TabIndex = 2
        '
        'lblShipModel
        '
        Me.lblShipModel.BackColor = System.Drawing.Color.Transparent
        Me.lblShipModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShipModel.ForeColor = System.Drawing.Color.Black
        Me.lblShipModel.Location = New System.Drawing.Point(8, 8)
        Me.lblShipModel.Name = "lblShipModel"
        Me.lblShipModel.Size = New System.Drawing.Size(48, 16)
        Me.lblShipModel.TabIndex = 107
        Me.lblShipModel.Text = "Model:"
        Me.lblShipModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnBillBillRURScrap
        '
        Me.btnBillBillRURScrap.BackColor = System.Drawing.Color.SteelBlue
        Me.btnBillBillRURScrap.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBillBillRURScrap.ForeColor = System.Drawing.Color.White
        Me.btnBillBillRURScrap.Location = New System.Drawing.Point(216, 304)
        Me.btnBillBillRURScrap.Name = "btnBillBillRURScrap"
        Me.btnBillBillRURScrap.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnBillBillRURScrap.Size = New System.Drawing.Size(96, 64)
        Me.btnBillBillRURScrap.TabIndex = 7
        Me.btnBillBillRURScrap.Text = "BILL"
        Me.btnBillBillRURScrap.Visible = False
        '
        'txtBillDevSN
        '
        Me.txtBillDevSN.BackColor = System.Drawing.Color.Yellow
        Me.txtBillDevSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBillDevSN.Location = New System.Drawing.Point(8, 64)
        Me.txtBillDevSN.MaxLength = 15
        Me.txtBillDevSN.Name = "txtBillDevSN"
        Me.txtBillDevSN.Size = New System.Drawing.Size(184, 20)
        Me.txtBillDevSN.TabIndex = 3
        Me.txtBillDevSN.Text = ""
        '
        'btnBillRemoveAll
        '
        Me.btnBillRemoveAll.BackColor = System.Drawing.Color.Red
        Me.btnBillRemoveAll.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBillRemoveAll.ForeColor = System.Drawing.Color.White
        Me.btnBillRemoveAll.Location = New System.Drawing.Point(216, 176)
        Me.btnBillRemoveAll.Name = "btnBillRemoveAll"
        Me.btnBillRemoveAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnBillRemoveAll.Size = New System.Drawing.Size(96, 32)
        Me.btnBillRemoveAll.TabIndex = 6
        Me.btnBillRemoveAll.Text = "REMOVE ALL SN FROM LIST"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(8, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 16)
        Me.Label1.TabIndex = 103
        Me.Label1.Text = "SN:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnBillRemoveOne
        '
        Me.btnBillRemoveOne.BackColor = System.Drawing.Color.Red
        Me.btnBillRemoveOne.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBillRemoveOne.ForeColor = System.Drawing.Color.White
        Me.btnBillRemoveOne.Location = New System.Drawing.Point(216, 136)
        Me.btnBillRemoveOne.Name = "btnBillRemoveOne"
        Me.btnBillRemoveOne.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnBillRemoveOne.Size = New System.Drawing.Size(96, 32)
        Me.btnBillRemoveOne.TabIndex = 5
        Me.btnBillRemoveOne.Text = "REMOVE ONE SN FROM LIST"
        '
        'cmbBillModel
        '
        Me.cmbBillModel.AutoComplete = True
        Me.cmbBillModel.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBillModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBillModel.ForeColor = System.Drawing.Color.Black
        Me.cmbBillModel.ItemHeight = 13
        Me.cmbBillModel.Location = New System.Drawing.Point(8, 24)
        Me.cmbBillModel.Name = "cmbBillModel"
        Me.cmbBillModel.Size = New System.Drawing.Size(184, 21)
        Me.cmbBillModel.TabIndex = 1
        '
        'lblBillScanCnt
        '
        Me.lblBillScanCnt.BackColor = System.Drawing.Color.Black
        Me.lblBillScanCnt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBillScanCnt.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBillScanCnt.ForeColor = System.Drawing.Color.Lime
        Me.lblBillScanCnt.Location = New System.Drawing.Point(216, 64)
        Me.lblBillScanCnt.Name = "lblBillScanCnt"
        Me.lblBillScanCnt.Size = New System.Drawing.Size(72, 32)
        Me.lblBillScanCnt.TabIndex = 140
        Me.lblBillScanCnt.Text = "0"
        Me.lblBillScanCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lstBillSNs
        '
        Me.lstBillSNs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstBillSNs.Location = New System.Drawing.Point(8, 88)
        Me.lstBillSNs.Name = "lstBillSNs"
        Me.lstBillSNs.Size = New System.Drawing.Size(184, 303)
        Me.lstBillSNs.TabIndex = 4
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpgBill, Me.tpgCreateShipPallet, Me.tpgEditManfDate})
        Me.TabControl1.Location = New System.Drawing.Point(160, 8)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(568, 504)
        Me.TabControl1.TabIndex = 3
        Me.TabControl1.Visible = False
        '
        'tpgBill
        '
        Me.tpgBill.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tpgBill.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblShipModel, Me.btnBillBillRURScrap, Me.Label1, Me.Label2, Me.btnBillRemoveAll, Me.lblBillScanCnt, Me.cmbBillBillcodes, Me.txtBillDevSN, Me.btnBillRemoveOne, Me.cmbBillModel, Me.lstBillSNs})
        Me.tpgBill.Location = New System.Drawing.Point(4, 25)
        Me.tpgBill.Name = "tpgBill"
        Me.tpgBill.Size = New System.Drawing.Size(560, 475)
        Me.tpgBill.TabIndex = 0
        '
        'tpgCreateShipPallet
        '
        Me.tpgCreateShipPallet.BackColor = System.Drawing.Color.SteelBlue
        Me.tpgCreateShipPallet.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblCSP_EditPalletName, Me.btnCSP_Cancel, Me.btnCSP_Reprint, Me.btnCSP_Edit, Me.btnCSP_Delete, Me.btnCSP_CreatePallet, Me.cmbCSP_ShipType, Me.Label5, Me.Label4, Me.txtCSP_Qty, Me.cmbCSP_Model, Me.Label3})
        Me.tpgCreateShipPallet.Location = New System.Drawing.Point(4, 25)
        Me.tpgCreateShipPallet.Name = "tpgCreateShipPallet"
        Me.tpgCreateShipPallet.Size = New System.Drawing.Size(560, 475)
        Me.tpgCreateShipPallet.TabIndex = 1
        '
        'lblCSP_EditPalletName
        '
        Me.lblCSP_EditPalletName.BackColor = System.Drawing.Color.Transparent
        Me.lblCSP_EditPalletName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCSP_EditPalletName.ForeColor = System.Drawing.Color.White
        Me.lblCSP_EditPalletName.Location = New System.Drawing.Point(16, 228)
        Me.lblCSP_EditPalletName.Name = "lblCSP_EditPalletName"
        Me.lblCSP_EditPalletName.Size = New System.Drawing.Size(248, 16)
        Me.lblCSP_EditPalletName.TabIndex = 117
        Me.lblCSP_EditPalletName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCSP_Cancel
        '
        Me.btnCSP_Cancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCSP_Cancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCSP_Cancel.ForeColor = System.Drawing.Color.Black
        Me.btnCSP_Cancel.Location = New System.Drawing.Point(176, 248)
        Me.btnCSP_Cancel.Name = "btnCSP_Cancel"
        Me.btnCSP_Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCSP_Cancel.Size = New System.Drawing.Size(88, 24)
        Me.btnCSP_Cancel.TabIndex = 116
        Me.btnCSP_Cancel.Tag = "0"
        Me.btnCSP_Cancel.Text = "Cancel Edit"
        Me.btnCSP_Cancel.Visible = False
        '
        'btnCSP_Reprint
        '
        Me.btnCSP_Reprint.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnCSP_Reprint.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCSP_Reprint.ForeColor = System.Drawing.Color.Black
        Me.btnCSP_Reprint.Location = New System.Drawing.Point(16, 203)
        Me.btnCSP_Reprint.Name = "btnCSP_Reprint"
        Me.btnCSP_Reprint.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCSP_Reprint.Size = New System.Drawing.Size(152, 24)
        Me.btnCSP_Reprint.TabIndex = 6
        Me.btnCSP_Reprint.Tag = "0"
        Me.btnCSP_Reprint.Text = "Reprint Pallet Label"
        '
        'btnCSP_Edit
        '
        Me.btnCSP_Edit.BackColor = System.Drawing.Color.LightCoral
        Me.btnCSP_Edit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCSP_Edit.ForeColor = System.Drawing.Color.White
        Me.btnCSP_Edit.Location = New System.Drawing.Point(16, 248)
        Me.btnCSP_Edit.Name = "btnCSP_Edit"
        Me.btnCSP_Edit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCSP_Edit.Size = New System.Drawing.Size(152, 24)
        Me.btnCSP_Edit.TabIndex = 7
        Me.btnCSP_Edit.Tag = "0"
        Me.btnCSP_Edit.Text = "Edit Pallet"
        Me.btnCSP_Edit.Visible = False
        '
        'btnCSP_Delete
        '
        Me.btnCSP_Delete.BackColor = System.Drawing.Color.Red
        Me.btnCSP_Delete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCSP_Delete.ForeColor = System.Drawing.Color.White
        Me.btnCSP_Delete.Location = New System.Drawing.Point(16, 288)
        Me.btnCSP_Delete.Name = "btnCSP_Delete"
        Me.btnCSP_Delete.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCSP_Delete.Size = New System.Drawing.Size(152, 24)
        Me.btnCSP_Delete.TabIndex = 8
        Me.btnCSP_Delete.Tag = "0"
        Me.btnCSP_Delete.Text = "Delete Pallet"
        Me.btnCSP_Delete.Visible = False
        '
        'btnCSP_CreatePallet
        '
        Me.btnCSP_CreatePallet.BackColor = System.Drawing.Color.Green
        Me.btnCSP_CreatePallet.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCSP_CreatePallet.ForeColor = System.Drawing.Color.White
        Me.btnCSP_CreatePallet.Location = New System.Drawing.Point(16, 162)
        Me.btnCSP_CreatePallet.Name = "btnCSP_CreatePallet"
        Me.btnCSP_CreatePallet.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCSP_CreatePallet.Size = New System.Drawing.Size(152, 24)
        Me.btnCSP_CreatePallet.TabIndex = 5
        Me.btnCSP_CreatePallet.Tag = "0"
        Me.btnCSP_CreatePallet.Text = "Create Pallet"
        '
        'cmbCSP_ShipType
        '
        Me.cmbCSP_ShipType.AutoComplete = True
        Me.cmbCSP_ShipType.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCSP_ShipType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCSP_ShipType.ForeColor = System.Drawing.Color.Black
        Me.cmbCSP_ShipType.ItemHeight = 13
        Me.cmbCSP_ShipType.Items.AddRange(New Object() {"PASS", "FAIL"})
        Me.cmbCSP_ShipType.Location = New System.Drawing.Point(16, 80)
        Me.cmbCSP_ShipType.Name = "cmbCSP_ShipType"
        Me.cmbCSP_ShipType.Size = New System.Drawing.Size(152, 21)
        Me.cmbCSP_ShipType.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(16, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(152, 16)
        Me.Label5.TabIndex = 112
        Me.Label5.Text = "Pallet Ship Type:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(16, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 16)
        Me.Label4.TabIndex = 111
        Me.Label4.Text = "Pallet Quantity:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCSP_Qty
        '
        Me.txtCSP_Qty.BackColor = System.Drawing.Color.Yellow
        Me.txtCSP_Qty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCSP_Qty.Location = New System.Drawing.Point(16, 120)
        Me.txtCSP_Qty.MaxLength = 15
        Me.txtCSP_Qty.Name = "txtCSP_Qty"
        Me.txtCSP_Qty.Size = New System.Drawing.Size(56, 20)
        Me.txtCSP_Qty.TabIndex = 4
        Me.txtCSP_Qty.Text = ""
        '
        'cmbCSP_Model
        '
        Me.cmbCSP_Model.AutoComplete = True
        Me.cmbCSP_Model.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCSP_Model.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCSP_Model.ForeColor = System.Drawing.Color.Black
        Me.cmbCSP_Model.ItemHeight = 13
        Me.cmbCSP_Model.Location = New System.Drawing.Point(16, 34)
        Me.cmbCSP_Model.Name = "cmbCSP_Model"
        Me.cmbCSP_Model.Size = New System.Drawing.Size(248, 21)
        Me.cmbCSP_Model.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(16, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 16)
        Me.Label3.TabIndex = 108
        Me.Label3.Text = "Model:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tpgEditManfDate
        '
        Me.tpgEditManfDate.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tpgEditManfDate.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label7, Me.btnEMFD_UpdateNewMD, Me.txtEMD_NewManfDate, Me.btnEMFD_Go, Me.dgEMD_SNInfo, Me.Label6, Me.txtEMD_SN})
        Me.tpgEditManfDate.Location = New System.Drawing.Point(4, 25)
        Me.tpgEditManfDate.Name = "tpgEditManfDate"
        Me.tpgEditManfDate.Size = New System.Drawing.Size(560, 475)
        Me.tpgEditManfDate.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(16, 184)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 16)
        Me.Label7.TabIndex = 116
        Me.Label7.Text = "New Manuf Date:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnEMFD_UpdateNewMD
        '
        Me.btnEMFD_UpdateNewMD.BackColor = System.Drawing.Color.SteelBlue
        Me.btnEMFD_UpdateNewMD.ForeColor = System.Drawing.Color.White
        Me.btnEMFD_UpdateNewMD.Location = New System.Drawing.Point(120, 197)
        Me.btnEMFD_UpdateNewMD.Name = "btnEMFD_UpdateNewMD"
        Me.btnEMFD_UpdateNewMD.Size = New System.Drawing.Size(136, 22)
        Me.btnEMFD_UpdateNewMD.TabIndex = 115
        Me.btnEMFD_UpdateNewMD.Text = "Update New Manuf Date"
        '
        'txtEMD_NewManfDate
        '
        Me.txtEMD_NewManfDate.BackColor = System.Drawing.Color.White
        Me.txtEMD_NewManfDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEMD_NewManfDate.Location = New System.Drawing.Point(16, 200)
        Me.txtEMD_NewManfDate.MaxLength = 4
        Me.txtEMD_NewManfDate.Name = "txtEMD_NewManfDate"
        Me.txtEMD_NewManfDate.Size = New System.Drawing.Size(96, 20)
        Me.txtEMD_NewManfDate.TabIndex = 3
        Me.txtEMD_NewManfDate.Text = ""
        '
        'btnEMFD_Go
        '
        Me.btnEMFD_Go.BackColor = System.Drawing.Color.SteelBlue
        Me.btnEMFD_Go.ForeColor = System.Drawing.Color.White
        Me.btnEMFD_Go.Location = New System.Drawing.Point(184, 23)
        Me.btnEMFD_Go.Name = "btnEMFD_Go"
        Me.btnEMFD_Go.Size = New System.Drawing.Size(40, 22)
        Me.btnEMFD_Go.TabIndex = 2
        Me.btnEMFD_Go.Text = "Go"
        '
        'dgEMD_SNInfo
        '
        Me.dgEMD_SNInfo.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.dgEMD_SNInfo.AllowUpdate = False
        Me.dgEMD_SNInfo.GroupByCaption = "Drag a column header here to group by that column"
        Me.dgEMD_SNInfo.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.dgEMD_SNInfo.Location = New System.Drawing.Point(16, 56)
        Me.dgEMD_SNInfo.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.dgEMD_SNInfo.Name = "dgEMD_SNInfo"
        Me.dgEMD_SNInfo.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dgEMD_SNInfo.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dgEMD_SNInfo.PreviewInfo.ZoomFactor = 75
        Me.dgEMD_SNInfo.Size = New System.Drawing.Size(528, 120)
        Me.dgEMD_SNInfo.TabIndex = 114
        Me.dgEMD_SNInfo.Text = "C1TrueDBGrid1"
        Me.dgEMD_SNInfo.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
        "ForeColor:HighlightText;BackColor:SteelBlue;}Style3{}Inactive{ForeColor:Inactive" & _
        "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
        "er;}Style1{}Normal{BackColor:LightSteelBlue;}HighlightRow{ForeColor:HighlightTex" & _
        "t;BackColor:Highlight;}Style14{}OddRow{}RecordSelector{AlignImage:Center;}Style1" & _
        "5{}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:Contr" & _
        "olText;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}Style12{}Style" & _
        "13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" Allow" & _
        "RowSizing=""None"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=" & _
        """17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidth=""16" & _
        """ VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>116</Height><Caption" & _
        "Style parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" />" & _
        "<EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" " & _
        "me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Gr" & _
        "oup"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowSt" & _
        "yle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Sty" & _
        "le4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""R" & _
        "ecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><St" & _
        "yle parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 524, 116</ClientRect><Border" & _
        "Side>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeV" & _
        "iew></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" " & _
        "me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=" & _
        """Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""S" & _
        "elected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""Highl" & _
        "ightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddR" & _
        "ow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""F" & _
        "ilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</ve" & _
        "rtSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>16</" & _
        "DefaultRecSelWidth><ClientArea>0, 0, 524, 116</ClientArea><PrintPageHeaderStyle " & _
        "parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(16, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 16)
        Me.Label6.TabIndex = 113
        Me.Label6.Text = "SN:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEMD_SN
        '
        Me.txtEMD_SN.BackColor = System.Drawing.Color.Yellow
        Me.txtEMD_SN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEMD_SN.Location = New System.Drawing.Point(16, 24)
        Me.txtEMD_SN.MaxLength = 30
        Me.txtEMD_SN.Name = "txtEMD_SN"
        Me.txtEMD_SN.Size = New System.Drawing.Size(160, 20)
        Me.txtEMD_SN.TabIndex = 1
        Me.txtEMD_SN.Text = ""
        '
        'lblBanner
        '
        Me.lblBanner.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblBanner.Location = New System.Drawing.Point(688, 0)
        Me.lblBanner.Name = "lblBanner"
        Me.lblBanner.Size = New System.Drawing.Size(40, 27)
        Me.lblBanner.TabIndex = 4
        '
        'frmGamestopOperations
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(736, 518)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblBanner, Me.TabControl1, Me.Panel1})
        Me.Name = "frmGamestopOperations"
        Me.Text = "Gamestop Operations"
        Me.Panel1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.tpgBill.ResumeLayout(False)
        Me.tpgCreateShipPallet.ResumeLayout(False)
        Me.tpgEditManfDate.ResumeLayout(False)
        CType(Me.dgEMD_SNInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '*******************************************************************
    Private Sub frmGamestopOperations_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            '********************************************
            Me.lblMachine.Text = GstrMachine
            Me.lblGroup.Text = Me.GstrGroupDesc
            Me.lblUserName.Text = GstrUserName
            Me.lblShift.Text = "Shift " & GiShift_ID
            Me.lblWorkDate.Text = Format(CDate(Me.GstrWorkDate), "MM/dd/yyyy")

            '********************************************
            'Get User Acess
            '********************************************
            If ApplicationUser.GetPermission("GamestopBillRURScrap") > 0 Then
                Me.btnBill.Tag = True
            End If

            If ApplicationUser.GetPermission("Gamestop_CreateShipPallet") > 0 Then
                Me.btnCreateShipPallet.Tag = True
            End If

            If ApplicationUser.GetPermission("Delete_GuitarHeroShipPallet") > 0 Then
                Me.btnCSP_Delete.Visible = True
                Me.btnCSP_Edit.Visible = True
            End If

            If ApplicationUser.GetPermission("ChangeManufDate") > 0 Then
                Me.btnEditManufDate.Tag = True
            End If

            GiMCCGroup_ID = PSS.Data.Buisness.Generic.GetMachineCostCenterGrpID()

            '********************************************
            'Set Banner label 
            '********************************************
            Me.lblBanner.Location = New System.Drawing.Point(160, 0)
            Me.lblBanner.Size = New System.Drawing.Size(720, 31)

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
        End Try
    End Sub

    '*******************************************************************

#Region "General"

    '*********************************************************
    Private Sub SetButtonProps(ByVal ctrl As Control, _
                                ByVal strBC As Color, _
                                ByVal strFC As Color)
        With ctrl
            .BackColor = strBC
            .ForeColor = strFC
        End With
    End Sub

    '*********************************************************
    Private Sub ShowHidePanels(ByRef ctrlTabpage As TabPage)
        Try
            MakeAllPanelsInvisible()
            Select Case ctrlTabpage.Name
                Case Me.tpgBill.Name   'Bill
                    If Me.btnBill.Tag = True Then
                        Me.TabControl1.Visible = True
                        Me.TabControl1.SelectedTab = ctrlTabpage

                        'Set Button Colors
                        SetButtonProps(Me.btnBill, Color.Orange, Color.Black)
                    End If
                Case Me.tpgCreateShipPallet.Name   'Create Ship Pallet
                    If Me.btnCreateShipPallet.Tag = True Then
                        Me.TabControl1.SelectedTab = ctrlTabpage
                        Me.TabControl1.Visible = True

                        'Set Button Colors
                        SetButtonProps(Me.btnCreateShipPallet, Color.Orange, Color.Black)
                    End If
                Case Me.tpgEditManfDate.Name   'Create Ship Pallet
                    If Me.btnEditManufDate.Tag = True Then
                        Me.TabControl1.SelectedTab = ctrlTabpage
                        Me.TabControl1.Visible = True

                        'Set Button Colors
                        SetButtonProps(Me.btnEditManufDate, Color.Orange, Color.Black)
                    End If
            End Select

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*********************************************************
    Private Sub ResetAllMenuButtons()
        Dim strBC As Color = Color.Black
        Dim strFC As Color = Color.Lime

        SetButtonProps(Me.btnBill, strBC, strFC)
        SetButtonProps(Me.btnCreateShipPallet, strBC, strFC)
        SetButtonProps(Me.btnEditManufDate, strBC, strFC)
    End Sub

    '*********************************************************
    Private Sub MakeAllPanelsInvisible()
        Me.TabControl1.Visible = False
    End Sub

    '*********************************************************
    Private Sub ClearAllPanels()
        ClearPanel_Bill()
        ResetAllMenuButtons()
    End Sub

#End Region

#Region "Main Menu Button Click Event"

    '*********************************************************
    Private Sub btnBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBill.Click
        Dim objGen As PSS.Data.Buisness.Generic

        Try
            If GiMCCGroup_ID <> 82 Then
                MessageBox.Show("Machine must be mapped to 'GAMESTOP' group.", "Machine Group", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            '******************************************************
            'Clear All controls in all panels
            ClearAllPanels()

            '******************************************************
            'check for user permition
            ShowHidePanels(Me.tpgBill)
            '******************************************************

            If Me.btnBill.Tag = True Then
                'Load model into combo box
                If Me.cmbBillModel.Items.Count = 0 Then
                    objGen = New PSS.Data.Buisness.Generic()
                    objGen.LoadModels(Me.cmbBillModel, Me.GiProd_ID, )
                    Me.cmbBillModel.SelectedValue = 0
                End If

                Me.cmbBillModel.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Ship Button Clicked", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            objGen = Nothing

            'Invoke Garbage Collector
            GC.Collect()
            GC.WaitForPendingFinalizers()
            GC.Collect()
            GC.WaitForPendingFinalizers()
        End Try
    End Sub

    '*********************************************************
    Private Sub btnCreateShipPallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateShipPallet.Click
        Dim objGen As PSS.Data.Buisness.Generic

        Try
            If GiMCCGroup_ID <> 82 Then
                MessageBox.Show("Machine must be mapped to 'GAMESTOP GUITAR HERO' group.", "Machine Group", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            '******************************************************
            'Clear All controls in all panels
            ClearAllPanels()

            '******************************************************
            'check for user permition
            ShowHidePanels(Me.tpgCreateShipPallet)
            '******************************************************

            If Me.btnCreateShipPallet.Tag = True Then
                'Load model into combo box
                If Me.cmbCSP_Model.Items.Count = 0 Then
                    objGen = New PSS.Data.Buisness.Generic()
                    objGen.LoadModels(Me.cmbCSP_Model, Me.GiProd_ID, )
                    Me.cmbCSP_Model.SelectedValue = 0
                End If

                Me.cmbCSP_Model.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Ship Button Clicked", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            objGen = Nothing

            'Invoke Garbage Collector
            GC.Collect()
            GC.WaitForPendingFinalizers()
            GC.Collect()
            GC.WaitForPendingFinalizers()
        End Try
    End Sub

    '*********************************************************
    Private Sub btnEditManufDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditManufDate.Click

        Try
            '******************************************************
            'Clear All controls in all panels
            ClearAllPanels()

            '******************************************************
            'check for user permition
            ShowHidePanels(Me.tpgEditManfDate)
            '******************************************************

            If Me.btnEditManufDate.Tag = True Then
                Me.txtEMD_SN.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            'Invoke Garbage Collector
            GC.Collect()
            GC.WaitForPendingFinalizers()
            GC.Collect()
            GC.WaitForPendingFinalizers()
        End Try
    End Sub

    '*********************************************************

#End Region

#Region "Bill"
    '*********************************************************
    Private Sub ClearPanel_Bill()

        Me.cmbBillModel.SelectedValue = 0

        If Me.cmbBillBillcodes.Items.Count > 0 Then
            Me.cmbBillBillcodes.SelectedValue = 0
        End If

        Me.txtBillDevSN.Text = ""
        Me.lblBillScanCnt.Text = ""

        If Me.lstBillSNs.Items.Count > 0 Then
            Me.lstBillSNs.Items.Clear()
            Me.lstBillSNs.Refresh()
        End If

        Me.btnBillBillRURScrap.Visible = False
    End Sub

    '*********************************************************
    Private Sub cmbBillModel_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBillModel.SelectionChangeCommitted
        Try
            If Me.cmbBillModel.SelectedValue > 0 Then
                If Me.cmbBillModel.SelectedValue = 881 Or Me.cmbBillModel.SelectedValue = 1112 Then
                    MessageBox.Show("You are not allow to bill scrap on XBox units.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.cmbBillModel.SelectedValue = 0
                Else
                    Me._objGamestopOpt.LoadRURSCRAPINCOMPLETEBillcodes(Me.cmbBillBillcodes, Me.GiProd_ID, Me.cmbBillModel.SelectedValue)
                    Me.lstBillSNs.Items.Clear()
                    Me.lstBillSNs.Refresh()
                    Me.btnBillBillRURScrap.Visible = False
                    Me.cmbBillBillcodes.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Model_SelectionChangeCommitted", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*********************************************************
    Private Sub cmbBillBillcodes_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBillBillcodes.SelectionChangeCommitted
        Try
            If Me.cmbBillModel.SelectedValue = 0 Then
                MessageBox.Show("Please select model.", "Billcode_SelectionChangeCommitted", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.cmbBillModel.Focus()
                Exit Sub
            End If

            If Me.cmbBillBillcodes.SelectedValue > 0 Then
                Me.lstBillSNs.Items.Clear()
                Me.lstBillSNs.Refresh()
                Me.btnBillBillRURScrap.Visible = False
                Me.txtBillDevSN.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Billcodes_SelectionChangeCommitted", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*********************************************************
    Private Sub txtBillDevSN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBillDevSN.KeyDown
        Dim i As Integer = 0
        Dim iDevice_ID As Integer = 0
        Dim iPallet_ID As Integer = 0
        Dim booDevModel As Boolean = False
        Dim objGen As New PSS.Data.Buisness.Generic()

        Try
            If e.KeyValue = 13 Then
                If Trim(Me.txtBillDevSN.Text) = "" Then
                    Exit Sub
                End If

                If Me.cmbBillModel.SelectedValue = 0 Then
                    MessageBox.Show("Please select model.", "SN KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.cmbBillModel.Focus()
                    Exit Sub
                End If

                If Me.cmbBillBillcodes.SelectedValue = 0 Then
                    MessageBox.Show("Please select billcode.", "SN KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.cmbBillBillcodes.Focus()
                    Exit Sub
                End If

                If Me.lstBillSNs.Items.Count >= 150 Then
                    MessageBox.Show("You have reached the limit of ""150 Devices"". Please click ""BILL"" button before you continue.", "SN KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtBillDevSN.SelectAll()
                    Exit Sub
                End If

                '***************************
                'Check for existing of device
                '***************************
                iDevice_ID = objGen.GetDevIDInWIPBySNCustID(UCase(Trim(Me.txtBillDevSN.Text)), Me.GiCust_ID)
                If iDevice_ID = 0 Then
                    MessageBox.Show("Device SN does not exist in WIP.", "SN KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtBillDevSN.SelectAll()
                    Exit Sub
                End If
                '***************************
                'Check if scaned SN has the same model with the user selected model.
                '***************************
                booDevModel = Me._objGamestopOpt.VerifyDeviceModel(iDevice_ID, Me.cmbBillModel.SelectedValue)
                If booDevModel = False Then
                    MessageBox.Show("Device SN is not """ & Me.cmbBillModel.SelectedItem(Me.cmbBillModel.DisplayMember) & """ model.", "SN KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtBillDevSN.SelectAll()
                    Exit Sub
                End If

                '**********************************
                'Check if device already palletized
                '**********************************
                iPallet_ID = Me._objGamestopOpt.GetDevicePallett_IDInWIP(iDevice_ID)
                If iPallet_ID <> 0 Then
                    MessageBox.Show("This device has a pallet assigned. Can't bill.", "SN KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtBillDevSN.SelectAll()
                    Exit Sub
                End If

                '*************************************************
                'Check for duplicate
                '*************************************************
                If Me.lstBillSNs.Items.Count > 0 Then
                    For i = 0 To Me.lstBillSNs.Items.Count - 1
                        If UCase(Trim(Me.txtBillDevSN.Text)) = Me.lstBillSNs.Items.Item(i) Then
                            MessageBox.Show("This device is already scanned in. Try another one.", "Scan SN", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.txtBillDevSN.Text = ""
                            Exit Sub
                        End If
                    Next i
                End If

                '*************************
                'Add SN into list
                '*************************
                Me.lstBillSNs.Items.Add(UCase(Trim(Me.txtBillDevSN.Text)))
                Me.lblBillScanCnt.Text = Me.lstBillSNs.Items.Count
                If Me.lstBillSNs.Items.Count > 0 Then
                    Me.btnBillBillRURScrap.Visible = True
                    Me.btnBillBillRURScrap.Text = "BILL " & Me.cmbBillBillcodes.SelectedItem(Me.cmbBillBillcodes.DisplayMember)
                End If

                Me.txtBillDevSN.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtBillDevSN_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            objGen = Nothing
        End Try
    End Sub

    '*********************************************************
    Private Sub btnBillRemoveOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBillRemoveOne.Click
        Dim strSelectedSN As String = ""
        Dim i As Integer = 0

        If Me.lstBillSNs.Items.Count = 0 Then
            Me.txtBillDevSN.Focus()
            Exit Sub
        Else

            '*****************************
            'Ask user for confirm message
            '*****************************
            If MessageBox.Show("Are you sure you want to clear one device?", "Remove ONE Serial Number", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

                '*****************
                'Get selected SN
                '*****************
                strSelectedSN = UCase(Trim(InputBox("Please scan SN", "SN")))
                If strSelectedSN = "" Then
                    Me.txtBillDevSN.Focus()
                    Exit Sub
                End If

                '*******************************
                'Remove selected SN in datatable
                '*******************************
                For i = 0 To Me.lstBillSNs.Items.Count - 1
                    If Me.lstBillSNs.Items.Item(i) = strSelectedSN Then
                        Me.lstBillSNs.Items.RemoveAt(i)
                        Exit For
                    End If
                Next i

                '***********************
                'Reset count label
                '***********************
                Me.lblBillScanCnt.Text = Me.lstBillSNs.Items.Count
                If Me.lstBillSNs.Items.Count > 0 Then
                    Me.btnBillBillRURScrap.Visible = True
                    Me.btnBillBillRURScrap.Text = "BILL " & Me.cmbBillBillcodes.SelectedItem(Me.cmbBillBillcodes.DisplayMember)
                End If
                '***********************
            End If
        End If

        Me.lblBillScanCnt.Text = Me.lstBillSNs.Items.Count
        Me.txtBillDevSN.Focus()
    End Sub

    '*********************************************************
    Private Sub btnBillRemoveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBillRemoveAll.Click
        If Me.lstBillSNs.Items.Count = 0 Then
            Me.txtBillDevSN.Focus()
            Exit Sub
        End If

        If MessageBox.Show("Are you sure you want to Clear the selected device?", "Remove ONE Serial Number", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            Me.lstBillSNs.Items.Clear()
            Me.lstBillSNs.Refresh()
            Me.lblBillScanCnt.Text = Me.lstBillSNs.Items.Count
            Me.btnBillBillRURScrap.Visible = False
        End If

        Me.txtBillDevSN.Focus()
    End Sub

    '*********************************************************
    Private Sub btnBillBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBillBillRURScrap.Click
        Dim i As Integer = 0

        Try
            If Me.lstBillSNs.Items.Count = 0 Then
                Exit Sub
            End If

            If Me.cmbBillBillcodes.SelectedValue = 0 Then
                MessageBox.Show("Please select billcode.", "Bill", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.cmbBillBillcodes.Focus()
                Exit Sub
            End If

            If MessageBox.Show("Are you sure you want Bill """ & Me.cmbBillBillcodes.SelectedItem(Me.cmbBillBillcodes.DisplayMember) & """ to all items in the list?", "Transfer Device to Salvage", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

                i = Me.BillRURSCRAPINCOMPLETE(Me.GiCust_ID, Me.cmbBillBillcodes.SelectedValue, Me.lstBillSNs)

                If i > 0 Then
                    MessageBox.Show("Bill completed.", "Bill", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.lstBillSNs.Items.Clear()
                    Me.lstBillSNs.Refresh()
                    Me.lblBillScanCnt.Text = Me.lstBillSNs.Items.Count
                    Me.btnBill.Visible = False
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Bill", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.txtBillDevSN.Focus()
        End Try
    End Sub

    '***************************************************************
    Public Function BillRURSCRAPINCOMPLETE(iCust_ID As Integer, _
                                 ByVal iBillcode_ID As Integer, _
                                 ByVal lstBillSNs As System.Windows.Forms.ListBox) As Integer

        Dim dt1 As DataTable
        Dim R1 As DataRow
        Dim iIndex, i, iDevice_ID As Integer
        Dim strSN As String = ""
        Dim objDevice As PSS.Rules.Device

        Try
            iIndex = 0 : i = 0 : iDevice_ID = 0
            For iIndex = 0 To lstBillSNs.Items.Count - 1
                strSN = UCase(Trim(lstBillSNs.Items.Item(iIndex)))

                iDevice_ID = PSS.Data.Buisness.Generic.GetDevIDInWIPBySNCustID(strSN, iCust_ID)
                objDevice = New PSS.Rules.Device(iDevice_ID)

                'remove all parts/services
                dt1 = Me._objGamestopOpt.GetPartsServicesOfDevice(iDevice_ID)
                For Each R1 In dt1.Rows
                    objDevice.DeletePart(R1("BillCode_ID"))
                Next R1
                'Bill RUR/Scrap/Incompleted
                objDevice.AddPart(iBillcode_ID)

                'update cellopt wipowner
                Me._objGamestopOpt.UpdateCelloptWipOwner(iDevice_ID, PSS.Core.ApplicationUser.IDuser)

                If Not IsNothing(objDevice) Then
                    objDevice.Dispose() : objDevice = Nothing
                End If
                iDevice_ID = 0 : R1 = Nothing
                PSS.Data.Buisness.Generic.DisposeDT(dt1)

            Next iIndex

            Return iIndex
        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(objDevice) Then
                objDevice.Dispose() : objDevice = Nothing
            End If
            R1 = Nothing : PSS.Data.Buisness.Generic.DisposeDT(dt1)
        End Try
    End Function

#End Region

#Region "Create Ship Palllet"

    '*********************************************************
    Private Sub cmbCSP_Model_SelectionChangeCommitted(ByVal sender As Object, _
                                                    ByVal e As System.EventArgs) _
                                                    Handles cmbCSP_Model.SelectionChangeCommitted
        If Me.cmbCSP_Model.SelectedValue <> 0 AndAlso Me.cmbCSP_Model.Text.Trim.StartsWith("GuitarHero") = False AndAlso Me.cmbCSP_Model.Text.Trim.StartsWith("RB Guitar") = False Then
            MessageBox.Show("This screen was designed for ""GuitarHero"". Please contact IT if you like to use it for a different model.", "Model SelectionChangeCommitted", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Me.cmbCSP_Model.SelectedValue = 0
        Else
            Me.txtCSP_Qty.Text = ""
            Me.cmbCSP_ShipType.SelectedIndex = -1
            Me.cmbCSP_ShipType.Focus()
        End If
    End Sub

    '*******************************************************************
    Private Sub cmbCSP_ShipType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCSP_ShipType.SelectedIndexChanged
        Me.txtCSP_Qty.Focus()
    End Sub

    '*******************************************************************
    Private Sub txtCSP_Qty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCSP_Qty.KeyPress
        If Not (e.KeyChar.IsDigit(e.KeyChar) Or e.KeyChar.IsControl(e.KeyChar)) Then
            e.Handled = True
        End If
    End Sub

    '*******************************************************************
    Private Sub btnCSP_CreatePallet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCSP_CreatePallet.Click
        Dim strPalletName As String = ""
        Dim dtShipPalletRpt As DataTable

        Try
            '******************************
            'Validate user input 
            '******************************
            If Me.cmbCSP_Model.SelectedValue = 0 Then
                MessageBox.Show("Please select customer.", "Create Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.cmbCSP_Model.Focus()
                Exit Sub
            End If

            If Me.cmbCSP_ShipType.SelectedIndex < 0 Then
                MessageBox.Show("Please select pallet ship type.", "Create Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.cmbCSP_ShipType.Focus()
                Exit Sub
            End If

            If Me.txtCSP_Qty.Text.ToString.Trim = "" Or Me.txtCSP_Qty.Text.Trim = 0 Then
                MessageBox.Show("Pallet quantity can't not be empty or zero.", "Create Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtCSP_Qty.Focus()
                Exit Sub
            End If

            If Me.cmbCSP_ShipType.Text = "PASS" And CInt(Me.txtCSP_Qty.Text.Trim) > 64 Then
                MessageBox.Show("Quantity for a pass pallet can't be more than 64.", "Create Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtCSP_Qty.Focus()
                Me.txtCSP_Qty.SelectAll()
                Exit Sub
                'ElseIf Me.cmbCSP_ShipType.Text = "FAIL" And CInt(Me.txtCSP_Qty.Text.Trim) > 200 Then
                '    MessageBox.Show("Quantity for a fail pallet can't be more than 200.", "Create Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                '    Me.txtCSP_Qty.Focus()
                '    Me.txtCSP_Qty.SelectAll()
                '    Exit Sub
            End If

            If MessageBox.Show("Are you sure you want to create pallet?", "Create Pallet", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Me.txtCSP_Qty.Focus()
                Exit Sub
            End If

            Me.Enabled = False
            Cursor.Current = Cursors.WaitCursor

            strPalletName = Me._objGamestopOpt.CreateGameStopShipPallet(Me.GiLoc_ID, Me.GiCust_ID, Me.GstrWorkDate, Me.cmbCSP_Model.SelectedValue, Me.cmbCSP_ShipType.SelectedIndex, CInt(Me.txtCSP_Qty.Text.Trim))

            '******************************
            'Print pallet label 
            '******************************
            dtShipPalletRpt = Me._objGamestopOpt.GetShipPalletData(strPalletName, CInt(Me.txtCSP_Qty.Text.Trim), Me.cmbCSP_Model.Text, Me.cmbCSP_ShipType.Text, New String() {"Shipper Verification:", "", "Leader Verification:"})
            Me._objGamestopOpt.PrintPalletLabel(dtShipPalletRpt, 4)

            '******************************
            'Reset control and set focus
            '******************************
            Me.txtCSP_Qty.Text = ""
            Me.txtCSP_Qty.Focus()

            MessageBox.Show("Pallet has been created.", "Delete Pallet", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Create Pallet", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default

            If Not IsNothing(dtShipPalletRpt) Then
                dtShipPalletRpt.Dispose()
                dtShipPalletRpt = Nothing
            End If
        End Try
    End Sub

    '*******************************************************************
    Private Sub btnCSP_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCSP_Delete.Click
        Dim str_pallet As String = ""
        Dim dtPalletInfo As DataTable
        Dim i As Integer = 0

        Try
            str_pallet = InputBox("Enter Pallet Name.", "Delete Pallet")
            If str_pallet = "" Then
                MessageBox.Show("Please enter a Pallet Name to delete.", "Delete Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            Me.Enabled = False

            '******************************
            'get palllet information 
            '******************************
            dtPalletInfo = Me._objGamestopOpt.GetPalletInfo(str_pallet, Me.GiCust_ID)
            If IsNothing(dtPalletInfo) Then
                MessageBox.Show("Pallet does not exist.", "Delete Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            ElseIf dtPalletInfo.Rows.Count = 0 Then
                MessageBox.Show("Pallet does not exist.", "Delete Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            ElseIf dtPalletInfo.Rows.Count > 1 Then
                MessageBox.Show("Pallet existed more than one in the system. Please contact IT.", "Delete Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            ElseIf Not IsDBNull(dtPalletInfo.Rows(0)("pkslip_ID")) Then
                MessageBox.Show("Pallet has already been packed. Can't delete.", "Delete Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            ElseIf Me._objGamestopOpt.IsDateEqualThisWeek(dtPalletInfo.Rows(0)("Pallett_ShipDate")) = False Then
                'CHECK IF DATA IS ALREADY POSTED.
                MessageBox.Show("Pallet has been posted for incentive program. Can't delete.", "Delete Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If Not IsDBNull(dtPalletInfo.Rows(0)("Model_Desc")) Then
                If dtPalletInfo.Rows(0)("Model_Desc").ToString.StartsWith("GuitarHero") = False And dtPalletInfo.Rows(0)("Model_Desc").ToString.StartsWith("RB Guitar") = False Then
                    MessageBox.Show("Pallet is not a GuitarHero pallet.", "Delete Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If

            If MessageBox.Show("Are you sure you want to DELETE pallet?", "Delete Pallet", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Me.txtCSP_Qty.Focus()
                Exit Sub
            End If

            Cursor.Current = Cursors.WaitCursor

            i = Me._objGamestopOpt.DeletePallet(dtPalletInfo.Rows(0)("Pallett_ID"))

            MessageBox.Show("Pallet has been deleted.", "Delete Pallet", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Edit Pallet", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '*******************************************************************
    Private Sub btnCSP_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCSP_Edit.Click
        If Me.btnCSP_Edit.Tag = 0 Then
            Me.PopulateEditInformation()
        Else
            Me.UpdatePalletQty()
        End If
    End Sub

    '*******************************************************************
    Private Sub PopulateEditInformation()
        Dim str_pallet As String = ""
        Dim dtPalletInfo As DataTable

        Try
            str_pallet = InputBox("Enter Pallet Name.", "Edit Pallet")
            If str_pallet = "" Then
                MessageBox.Show("Please enter a Pallet Name if you want to modify the pallet.", "Edit Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            Me.Enabled = False

            '******************************
            'get palllet information 
            '******************************
            dtPalletInfo = Me._objGamestopOpt.GetPalletInfo(str_pallet, Me.GiCust_ID)
            If IsNothing(dtPalletInfo) Then
                MessageBox.Show("Pallet does not exist.", "Edit Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            ElseIf dtPalletInfo.Rows.Count = 0 Then
                MessageBox.Show("Pallet does not exist.", "Edit Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            ElseIf dtPalletInfo.Rows.Count > 1 Then
                MessageBox.Show("Pallet name is existed more than one in the system. Please contact IT.", "Edit Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If Not IsDBNull(dtPalletInfo.Rows(0)("pkslip_ID")) Then
                MessageBox.Show("Pallet has already been packed.", "Edit Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            Cursor.Current = Cursors.WaitCursor

            '******************************
            'populate information
            '******************************
            If Not IsDBNull(dtPalletInfo.Rows(0)("Model_ID")) Then
                Me.cmbCSP_Model.SelectedValue = dtPalletInfo.Rows(0)("Model_ID")
                Me.cmbCSP_Model.Enabled = False
            End If
            If Not IsDBNull(dtPalletInfo.Rows(0)("Model_ID")) Then
                Me.cmbCSP_Model.SelectedValue = dtPalletInfo.Rows(0)("Model_ID")
                Me.cmbCSP_Model.Enabled = False
            End If

            If Not IsDBNull(dtPalletInfo.Rows(0)("Pallet_ShipType")) Then
                Me.cmbCSP_ShipType.SelectedIndex = dtPalletInfo.Rows(0)("Pallet_ShipType")
                Me.cmbCSP_ShipType.Enabled = False
            End If

            If Not IsDBNull(dtPalletInfo.Rows(0)("Pallett_QTY")) Then
                Me.txtCSP_Qty.Text = dtPalletInfo.Rows(0)("Pallett_QTY")
            End If

            Me.lblCSP_EditPalletName.Visible = True
            Me.lblCSP_EditPalletName.Text = dtPalletInfo.Rows(0)("Pallett_Name")

            Me.btnCSP_Edit.Text = "Update"
            Me.btnCSP_Edit.Tag = dtPalletInfo.Rows(0)("Pallett_ID")

            'Hide button
            Me.btnCSP_Cancel.Visible = True
            Me.btnCSP_CreatePallet.Visible = False
            Me.btnCSP_Reprint.Visible = False
            Me.btnCSP_Delete.Visible = False
            Me.txtCSP_Qty.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Edit Pallet", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default

            If Not IsNothing(dtPalletInfo) Then
                dtPalletInfo.Dispose()
                dtPalletInfo = Nothing
            End If
        End Try
    End Sub

    '*******************************************************************
    Private Sub UpdatePalletQty()
        Dim i As Integer
        Dim dtShipPalletRpt As DataTable

        Try
            '******************************
            'Validate user input 
            '******************************
            If Me.cmbCSP_Model.SelectedValue = 0 Then
                MessageBox.Show("Please select Model.", "Edit Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.cmbCSP_Model.Focus()
                Exit Sub
            End If

            If Me.cmbCSP_ShipType.SelectedIndex < 0 Then
                MessageBox.Show("Please select pallet ship type.", "Edit Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.cmbCSP_ShipType.Focus()
                Exit Sub
            End If

            If Me.txtCSP_Qty.Text.ToString.Trim = "" Or Me.txtCSP_Qty.Text.Trim = 0 Then
                MessageBox.Show("Pallet quantity can't not be empty or zero.", "Edit Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtCSP_Qty.Focus()
                Exit Sub
            End If

            If Me.cmbCSP_ShipType.Text = "PASS" And CInt(Me.txtCSP_Qty.Text.Trim) > 64 Then
                MessageBox.Show("Quantity for a pass pallet can't be more than 64.", "Edit Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtCSP_Qty.Focus()
                Me.txtCSP_Qty.SelectAll()
                Exit Sub
            ElseIf Me.cmbCSP_ShipType.Text = "FAIL" And CInt(Me.txtCSP_Qty.Text.Trim) > 125 Then
                MessageBox.Show("Quantity for a fail pallet can't be more than 125.", "Edit Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtCSP_Qty.Focus()
                Me.txtCSP_Qty.SelectAll()
                Exit Sub
            End If

            If MessageBox.Show("Are you sure you want to update pallet quantity?", "Edit Pallet", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Me.txtCSP_Qty.Focus()
                Exit Sub
            End If

            Me.Enabled = False
            Cursor.Current = Cursors.WaitCursor

            i = Me._objGamestopOpt.EditPalletQuantity(CInt(Me.btnCSP_Edit.Tag), CInt(Me.txtCSP_Qty.Text.Trim))

            '******************************
            'Print pallet label 
            '******************************
            '******************************
            'Print pallet label 
            '******************************
            dtShipPalletRpt = Me._objGamestopOpt.GetShipPalletData(Me.lblCSP_EditPalletName.Text.Trim, CInt(Me.txtCSP_Qty.Text.Trim), Me.cmbCSP_Model.Text, Me.cmbCSP_ShipType.Text, New String() {"Shipper Verification:", "", "Leader Verification:"})
            Me._objGamestopOpt.PrintPalletLabel(dtShipPalletRpt, 4)

            '******************************
            'Reset control and set focus
            '******************************
            Me.CSP_ResetAllCtrls()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Edit Pallet", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
            If Not IsNothing(dtShipPalletRpt) Then
                dtShipPalletRpt.Dispose()
                dtShipPalletRpt = Nothing
            End If
        End Try
    End Sub

    '*******************************************************************
    Private Sub btnCSP_Reprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCSP_Reprint.Click
        Dim strPalletName As String = ""
        Dim iPallet_Qty As Integer = 0
        Dim dtPalletInfo As DataTable
        Dim dtShipPalletRpt As DataTable

        Try
            strPalletName = InputBox("Enter Pallet Name.", "Reprint Pallet Label")
            If strPalletName = "" Then
                MessageBox.Show("Please enter a Pallet Name if you want to reprint the pallet label.", "Reprint Pallet Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            Me.Enabled = False
            Cursor.Current = Cursors.WaitCursor

            '******************************
            'get palllet information 
            '******************************
            dtPalletInfo = Me._objGamestopOpt.GetPalletInfo(strPalletName, Me.GiCust_ID)
            If IsNothing(dtPalletInfo) Then
                MessageBox.Show("Pallet does not exist.", "Reprint Pallet Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            ElseIf dtPalletInfo.Rows.Count = 0 Then
                MessageBox.Show("Pallet does not exist.", "Reprint Pallet Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            ElseIf dtPalletInfo.Rows.Count > 1 Then
                MessageBox.Show("Pallet name is existed more than one in the system. Please contact IT.", "Reprint Pallet Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If Not IsDBNull(dtPalletInfo.Rows(0)("Pallett_QTY")) Then
                iPallet_Qty = dtPalletInfo.Rows(0)("Pallett_QTY")
            End If

            '******************************
            'Print pallet label 
            '******************************
            dtShipPalletRpt = Me._objGamestopOpt.GetShipPalletData(strPalletName, iPallet_Qty, dtPalletInfo.Rows(0)("Model_Desc"), dtPalletInfo.Rows(0)("ShipType"), New String() {"Shipper Verification:", "", "Leader Verification:"})
            Me._objGamestopOpt.PrintPalletLabel(dtShipPalletRpt, 4)

            Me.txtCSP_Qty.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Reprint Pallet Label", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default

            If Not IsNothing(dtShipPalletRpt) Then
                dtShipPalletRpt.Dispose()
                dtShipPalletRpt = Nothing
            End If
            If Not IsNothing(dtPalletInfo) Then
                dtPalletInfo.Dispose()
                dtPalletInfo = Nothing
            End If
        End Try
    End Sub

    '*******************************************************************
    Private Sub btnCSP_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCSP_Cancel.Click
        CSP_ResetAllCtrls()
    End Sub

    '*******************************************************************
    Private Sub CSP_ResetAllCtrls()
        '******************************
        'Reset control and set focus
        '******************************
        Me.lblCSP_EditPalletName.Text = ""
        Me.btnCSP_Edit.Text = "Edit Pallet"
        Me.btnCSP_Edit.Tag = 0
        Me.btnCSP_Cancel.Visible = False
        Me.btnCSP_CreatePallet.Visible = True
        Me.btnCSP_Reprint.Visible = True
        Me.btnCSP_Delete.Visible = True
        Me.txtCSP_Qty.Text = ""
        Me.cmbCSP_ShipType.SelectedIndex = -1
        Me.cmbCSP_ShipType.Enabled = True
        Me.cmbCSP_Model.SelectedValue = 0
        Me.cmbCSP_Model.Enabled = True
        Me.cmbCSP_Model.Focus()
    End Sub

    '*******************************************************************


#End Region

#Region "Edit Manufacture Date"

    '*******************************************************************
    Private Sub txtEMD_SN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEMD_SN.KeyUp
        Try
            If e.KeyValue = 13 Then
                If Me.txtEMD_SN.Text.Trim = "" Then
                    Exit Sub
                Else
                    Me.ProcessSN()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.txtEMD_SN.Focus()
            Me.txtEMD_SN.SelectAll()
        End Try
    End Sub

    '*******************************************************************
    Private Sub btnEMFD_Go_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEMFD_Go.Click
        Try
            Me.ProcessSN()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.txtEMD_SN.Focus()
            Me.txtEMD_SN.SelectAll()
        End Try
    End Sub

    '*******************************************************************
    Private Sub ProcessSN()
        Dim dt As DataTable
        Dim iNumOfColumns As Integer
        Dim i As Integer

        Try
            Me.dgEMD_SNInfo.DataSource = Nothing

            dt = Me._objGamestopOpt.GetDeviceManufDate(Me.txtEMD_SN.Text.Trim.ToUpper)

            If Not IsNothing(dt) Then
                With Me.dgEMD_SNInfo
                    .DataSource = dt.DefaultView

                    iNumOfColumns = Me.dgEMD_SNInfo.Columns.Count

                    For i = 0 To (iNumOfColumns - 1)
                        'Heading style (Horizontal & Vertical Alignment to Center)
                        .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        .Splits(0).DisplayColumns(i).HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                        'Set individual column data horizontal alignment
                        .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        .Splits(0).DisplayColumns(i).Style.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

                        '.Splits(0).DisplayColumns(i).AllowFocus = False
                    Next i

                    'Hide specific column
                    .Splits(0).DisplayColumns("Device_ID").Visible = False
                    .Splits(0).DisplayColumns("Model_ID").Visible = False

                    ''Lock specific column from editing
                    '.Splits(0).DisplayColumns("SN").Locked = True
                    '.Splits(0).DisplayColumns("Date Ship").Locked = True
                    '.Splits(0).DisplayColumns("Model").Locked = True
                    '.Splits(0).DisplayColumns("Manufacture Date").Locked = True

                    'If .Row > -1 AndAlso (IsDBNull(.Columns("Date Ship").Text) Or .Columns("Date Ship").Text = "") Then
                    '    .Splits(0).DisplayColumns("Manufacture Date").AllowFocus = True
                    '    .Splits(0).DisplayColumns("Manufacture Date").Locked = False
                    'Else
                    '    .Splits(0).DisplayColumns("Manufacture Date").AllowFocus = False
                    '    .Splits(0).DisplayColumns("Manufacture Date").Locked = True
                    'End If
                End With
            End If

            Me.txtEMD_SN.Text = ""
            Me.txtEMD_SN.Focus()
        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If
        End Try
    End Sub

    '*******************************************************************
    Private Sub dgEMD_SNInfo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgEMD_SNInfo.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar)) Or Char.IsWhiteSpace(e.KeyChar) Then
            'Or sender.Columns("Manufacture Date").text.trim.length = 4
            e.Handled = True ' Allow only numbers and a period 
        End If
    End Sub

    '*******************************************************************
    Private Sub dgEMD_SNInfo_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles dgEMD_SNInfo.BeforeColUpdate
        Try
            If sender.Columns("Manufacture Date").text.trim.length <> 4 Then
                MessageBox.Show("Manufacture date must be 4 digits number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = False
                Me.dgEMD_SNInfo.Columns(e.ColIndex).Value = e.OldValue
            Else
                Me._objGamestopOpt.GetModelFromDateCode(sender.Columns(sender.Col).Text.Trim)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "BeforeColUpdate", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            e.Cancel = False
            Me.dgEMD_SNInfo.Columns(e.ColIndex).Value = e.OldValue
        End Try
    End Sub

    '*******************************************************************
    Private Sub dgEMD_SNInfo_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles dgEMD_SNInfo.AfterColUpdate
        Try
            If sender.Row > -1 Then
                Me._objGamestopOpt.UpdateDateCode(CInt(sender.Columns("Device_ID").Text), sender.Columns(sender.Col).Text.Trim)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "AfterColUpdate", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    '*******************************************************************
    Private Sub txtEMD_NewManfDate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEMD_NewManfDate.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar)) Or Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True ' Allow only numbers and a period 
        End If
    End Sub

    '*******************************************************************
    Private Sub btnEMFD_UpdateNewMD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEMFD_UpdateNewMD.Click
        Dim strNewManufDate As String

        Try
            If Me.txtEMD_NewManfDate.Text.Trim.Length = 0 Then
                MessageBox.Show("Please enter new Manufacture Date.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf Not IsNothing(Me.dgEMD_SNInfo.DataSource) Then
                If Me.dgEMD_SNInfo.RowCount > 0 Then
                    If Me.dgEMD_SNInfo.SelectedRows.Count = 0 Then
                        MessageBox.Show("You must select a row.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Me.dgEMD_SNInfo.SelectedRows.Count > 1 Then
                        MessageBox.Show("You can select only one row.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Me.dgEMD_SNInfo(Me.dgEMD_SNInfo.Row, 4).ToString.Trim.Length > 0 Then
                        MessageBox.Show("The selected SN already shipped.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Me.dgEMD_SNInfo(Me.dgEMD_SNInfo.Row, 3).ToString.Trim.Length > 0 Then
                        MessageBox.Show("The selected SN already assigned to a shipping Pallet.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        strNewManufDate = Me.txtEMD_NewManfDate.Text.Trim
                        Me.txtEMD_SN.Text = Me.dgEMD_SNInfo(Me.dgEMD_SNInfo.Row, 1).ToString.Trim.ToUpper
                        Me._objGamestopOpt.UpdateDateCode(CInt(Me.dgEMD_SNInfo(Me.dgEMD_SNInfo.Row, 0)), strNewManufDate)
                        MessageBox.Show("Completed.", "UpdateManufDate", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.txtEMD_NewManfDate.Text = ""
                        ProcessSN()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "UpdateNewMD", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '*******************************************************************

#End Region


End Class
