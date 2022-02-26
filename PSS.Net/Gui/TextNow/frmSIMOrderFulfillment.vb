Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text

Public Class frmSIMOrderFulfillment
    Inherits System.Windows.Forms.Form

    Private _iMenuCustID As Integer = 0
    Private _iLocID As Integer = 0
    Private _objTN As TN
    Private _dtProductDetail As DataTable
    Private _dtFilledCardSN As New DataTable()
    Private _dtFilledInsertPN As New DataTable()
    Private _iCarrierID As Integer = 22
    Private _iOrder_Sku_ID As Integer = 0
    Private _iOrder_InsertPN_DcodeID As Integer = 0
    Private _iOrder_kuType_DcodeID As Integer = 0
    Private _iOrder_SOHeaderID As Integer = 0
    Private _iOrder_SODetailsID As Integer = 0
    Private _iOrder_WO_ID As Integer = 0
    Dim _strInsertPN As String = ""
    Dim _bIsPrekit As Boolean = False
    Dim _dtKitSeesionResult As DataTable
    Dim _bIsMultipleInsertPNs As Boolean = False
    Dim _iPrekitSelectedInsertID As Integer = 0
    Dim _iLockedSelectionInsertID As Integer = 0

    Private _UserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
    Private _strComputerName As String = ""
    Private _BaseClass As PSS.Data.BaseClasses.CollectTrackingLog

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal iCust_ID As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me._iMenuCustID = iCust_ID
        Me._objTN = New TN()
        Me._iLocID = Me._objTN.LOCID
        Me._BaseClass = New PSS.Data.BaseClasses.CollectTrackingLog()
        Me._strComputerName = Me._BaseClass.GetComputerName

        Me._dtFilledCardSN.Columns.Add("Device_ID", GetType(Integer))
        Me._dtFilledCardSN.Columns.Add("SN", GetType(String))
        Me._dtFilledCardSN.Columns.Add("Sku_ID", GetType(Integer))
        Me._dtFilledCardSN.Columns.Add("WI_ID", GetType(Integer))
        Me._dtFilledCardSN.Columns.Add("SODetailsID", GetType(Integer))
        Me._dtFilledInsertPN.Columns.Add("Insert_decode_ID", GetType(Integer))
        Me._dtFilledInsertPN.Columns.Add("Insert PN", GetType(String))
        Me._dtFilledInsertPN.Columns.Add("sku_part_nr", GetType(String))
        Me._dtFilledInsertPN.Columns.Add("Insert_Desc", GetType(String))

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
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabOrder As System.Windows.Forms.TabPage
    Friend WithEvents tabPrekit As System.Windows.Forms.TabPage
    Friend WithEvents cboCustomer As C1.Win.C1List.C1Combo
    Friend WithEvents tdgData1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents pnlFillShip As System.Windows.Forms.Panel
    Friend WithEvents btnUndoSIMSN As System.Windows.Forms.Button
    Friend WithEvents btnUndoInsertPN As System.Windows.Forms.Button
    Friend WithEvents lblShipQty As System.Windows.Forms.Label
    Friend WithEvents txtShipQty As System.Windows.Forms.TextBox
    Friend WithEvents lblOrderRevDT As System.Windows.Forms.Label
    Friend WithEvents txtAssignedSIMCardSN As System.Windows.Forms.TextBox
    Friend WithEvents lblSIMCardSN As System.Windows.Forms.Label
    Friend WithEvents txtSIMCardSN As System.Windows.Forms.TextBox
    Friend WithEvents txtAssignedInsertPartNo As System.Windows.Forms.TextBox
    Friend WithEvents lblInsertPartNo As System.Windows.Forms.Label
    Friend WithEvents txtInsertPartNo As System.Windows.Forms.TextBox
    Friend WithEvents txtOrderRevDT As System.Windows.Forms.TextBox
    Friend WithEvents lblOrderQty As System.Windows.Forms.Label
    Friend WithEvents txtOrderQty As System.Windows.Forms.TextBox
    Friend WithEvents txtTrackingNo As System.Windows.Forms.TextBox
    Friend WithEvents cboShipCarrier As C1.Win.C1List.C1Combo
    Friend WithEvents lblTrackingNo As System.Windows.Forms.Label
    Friend WithEvents grbShipmentInfo As System.Windows.Forms.GroupBox
    Friend WithEvents txtZipCode As System.Windows.Forms.TextBox
    Friend WithEvents txtCoutry As System.Windows.Forms.TextBox
    Friend WithEvents txtState As System.Windows.Forms.TextBox
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtSku As System.Windows.Forms.TextBox
    Friend WithEvents lblOrderNo As System.Windows.Forms.Label
    Friend WithEvents txtOrderNo As System.Windows.Forms.TextBox
    Friend WithEvents lblSku As System.Windows.Forms.Label
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents btnSelectWO As System.Windows.Forms.Button
    Friend WithEvents btnCopyAll As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents lblInsertPN As System.Windows.Forms.Label
    Friend WithEvents lblSkuType As System.Windows.Forms.Label
    Friend WithEvents lblprekitCardDesc As System.Windows.Forms.Label
    Friend WithEvents lblPrekitCard As System.Windows.Forms.Label
    Friend WithEvents lblPrekitInsertDesc As System.Windows.Forms.Label
    Friend WithEvents lblprekitInsert As System.Windows.Forms.Label
    Friend WithEvents btnPreKit As System.Windows.Forms.Button
    Friend WithEvents txtPrekitCardSN As System.Windows.Forms.TextBox
    Friend WithEvents txtPrekitInsertPN As System.Windows.Forms.TextBox
    Friend WithEvents btnprekitSNUndo As System.Windows.Forms.Button
    Friend WithEvents lblSkuDesc As System.Windows.Forms.Label
    Friend WithEvents tdgData2 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnCopy2Clipboard As System.Windows.Forms.Button
    Friend WithEvents btnReject As System.Windows.Forms.Button
    Friend WithEvents btnReturnedOrder As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnCloseOrder As System.Windows.Forms.Button
    Friend WithEvents btnCloseOrderWithNtfctns As System.Windows.Forms.Button
    Friend WithEvents pnlCloseOrder As System.Windows.Forms.Panel
    Friend WithEvents lstICCID As System.Windows.Forms.ListBox
    Friend WithEvents lstInsert As System.Windows.Forms.ListBox
    Friend WithEvents btnDelOne As System.Windows.Forms.Button
    Friend WithEvents btnDelAll As System.Windows.Forms.Button
    Friend WithEvents pnlUnused As System.Windows.Forms.Panel
    Friend WithEvents lblOrderCount As System.Windows.Forms.Label
    Friend WithEvents tdgProductDetails As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnGetTrackingNo As System.Windows.Forms.Button
    Friend WithEvents btnCloseShip As System.Windows.Forms.Button
    Friend WithEvents btnRePrintLabel As System.Windows.Forms.Button
    Friend WithEvents btnChangeAddress As System.Windows.Forms.Button
    Friend WithEvents tabSetPrinter As System.Windows.Forms.TabPage
    Friend WithEvents btnSaveLabelPrinterSetup As System.Windows.Forms.Button
    Friend WithEvents cboPrinters As System.Windows.Forms.ComboBox
    Friend WithEvents tdgLabelPrinter As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnRefreshPrinterData As System.Windows.Forms.Button
    Friend WithEvents lblCurrentSetting As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkByOrderNo As System.Windows.Forms.CheckBox
    Friend WithEvents chkBySN As System.Windows.Forms.CheckBox
    Friend WithEvents cboPrekitInsertPN As C1.Win.C1List.C1Combo
    Friend WithEvents chkBoxLock As System.Windows.Forms.CheckBox
    Friend WithEvents btnGetLockOrders As System.Windows.Forms.Button
    Friend WithEvents btnUnlockOrder As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSIMOrderFulfillment))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtAssignedInsertPartNo = New System.Windows.Forms.TextBox()
        Me.txtOrderRevDT = New System.Windows.Forms.TextBox()
        Me.txtZipCode = New System.Windows.Forms.TextBox()
        Me.txtCoutry = New System.Windows.Forms.TextBox()
        Me.txtState = New System.Windows.Forms.TextBox()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.txtAddress2 = New System.Windows.Forms.TextBox()
        Me.txtAddress1 = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lblprekitCardDesc = New System.Windows.Forms.Label()
        Me.lblPrekitInsertDesc = New System.Windows.Forms.Label()
        Me.btnDelAll = New System.Windows.Forms.Button()
        Me.btnDelOne = New System.Windows.Forms.Button()
        Me.btnCopy2Clipboard = New System.Windows.Forms.Button()
        Me.btnReject = New System.Windows.Forms.Button()
        Me.btnReturnedOrder = New System.Windows.Forms.Button()
        Me.lblOrderCount = New System.Windows.Forms.Label()
        Me.btnCloseShip = New System.Windows.Forms.Button()
        Me.btnRefreshPrinterData = New System.Windows.Forms.Button()
        Me.btnGetLockOrders = New System.Windows.Forms.Button()
        Me.btnUnlockOrder = New System.Windows.Forms.Button()
        Me.txtAssignedSIMCardSN = New System.Windows.Forms.TextBox()
        Me.pnlFillShip = New System.Windows.Forms.Panel()
        Me.chkBySN = New System.Windows.Forms.CheckBox()
        Me.chkByOrderNo = New System.Windows.Forms.CheckBox()
        Me.btnRePrintLabel = New System.Windows.Forms.Button()
        Me.lstInsert = New System.Windows.Forms.ListBox()
        Me.lstICCID = New System.Windows.Forms.ListBox()
        Me.tdgProductDetails = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.pnlCloseOrder = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCloseOrderWithNtfctns = New System.Windows.Forms.Button()
        Me.btnCloseOrder = New System.Windows.Forms.Button()
        Me.lblOrderRevDT = New System.Windows.Forms.Label()
        Me.txtSIMCardSN = New System.Windows.Forms.TextBox()
        Me.txtTrackingNo = New System.Windows.Forms.TextBox()
        Me.cboShipCarrier = New C1.Win.C1List.C1Combo()
        Me.grbShipmentInfo = New System.Windows.Forms.GroupBox()
        Me.btnChangeAddress = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblOrderNo = New System.Windows.Forms.Label()
        Me.txtOrderNo = New System.Windows.Forms.TextBox()
        Me.lblSIMCardSN = New System.Windows.Forms.Label()
        Me.btnGetTrackingNo = New System.Windows.Forms.Button()
        Me.lblTrackingNo = New System.Windows.Forms.Label()
        Me.pnlUnused = New System.Windows.Forms.Panel()
        Me.lblSku = New System.Windows.Forms.Label()
        Me.txtSku = New System.Windows.Forms.TextBox()
        Me.lblSkuDesc = New System.Windows.Forms.Label()
        Me.lblInsertPartNo = New System.Windows.Forms.Label()
        Me.lblInsertPN = New System.Windows.Forms.Label()
        Me.txtInsertPartNo = New System.Windows.Forms.TextBox()
        Me.btnUndoInsertPN = New System.Windows.Forms.Button()
        Me.btnUndoSIMSN = New System.Windows.Forms.Button()
        Me.lblSkuType = New System.Windows.Forms.Label()
        Me.lblShipQty = New System.Windows.Forms.Label()
        Me.lblOrderQty = New System.Windows.Forms.Label()
        Me.txtOrderQty = New System.Windows.Forms.TextBox()
        Me.txtShipQty = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabOrder = New System.Windows.Forms.TabPage()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnCopyAll = New System.Windows.Forms.Button()
        Me.btnSelectWO = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.cboCustomer = New C1.Win.C1List.C1Combo()
        Me.tdgData1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.tabPrekit = New System.Windows.Forms.TabPage()
        Me.chkBoxLock = New System.Windows.Forms.CheckBox()
        Me.cboPrekitInsertPN = New C1.Win.C1List.C1Combo()
        Me.tdgData2 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnprekitSNUndo = New System.Windows.Forms.Button()
        Me.btnPreKit = New System.Windows.Forms.Button()
        Me.txtPrekitCardSN = New System.Windows.Forms.TextBox()
        Me.txtPrekitInsertPN = New System.Windows.Forms.TextBox()
        Me.lblPrekitCard = New System.Windows.Forms.Label()
        Me.lblprekitInsert = New System.Windows.Forms.Label()
        Me.tabSetPrinter = New System.Windows.Forms.TabPage()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblCurrentSetting = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnSaveLabelPrinterSetup = New System.Windows.Forms.Button()
        Me.tdgLabelPrinter = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.cboPrinters = New System.Windows.Forms.ComboBox()
        Me.pnlFillShip.SuspendLayout()
        CType(Me.tdgProductDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCloseOrder.SuspendLayout()
        CType(Me.cboShipCarrier, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbShipmentInfo.SuspendLayout()
        Me.pnlUnused.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tabOrder.SuspendLayout()
        CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPrekit.SuspendLayout()
        CType(Me.cboPrekitInsertPN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdgData2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabSetPrinter.SuspendLayout()
        CType(Me.tdgLabelPrinter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtAssignedInsertPartNo
        '
        Me.txtAssignedInsertPartNo.BackColor = System.Drawing.SystemColors.Info
        Me.txtAssignedInsertPartNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAssignedInsertPartNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAssignedInsertPartNo.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtAssignedInsertPartNo.Location = New System.Drawing.Point(200, 0)
        Me.txtAssignedInsertPartNo.Name = "txtAssignedInsertPartNo"
        Me.txtAssignedInsertPartNo.ReadOnly = True
        Me.txtAssignedInsertPartNo.Size = New System.Drawing.Size(8, 21)
        Me.txtAssignedInsertPartNo.TabIndex = 162
        Me.txtAssignedInsertPartNo.TabStop = False
        Me.txtAssignedInsertPartNo.Text = ""
        Me.ToolTip1.SetToolTip(Me.txtAssignedInsertPartNo, "Assigned to Order")
        Me.txtAssignedInsertPartNo.Visible = False
        '
        'txtOrderRevDT
        '
        Me.txtOrderRevDT.BackColor = System.Drawing.SystemColors.Info
        Me.txtOrderRevDT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOrderRevDT.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrderRevDT.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtOrderRevDT.Location = New System.Drawing.Point(80, 24)
        Me.txtOrderRevDT.Name = "txtOrderRevDT"
        Me.txtOrderRevDT.ReadOnly = True
        Me.txtOrderRevDT.Size = New System.Drawing.Size(192, 21)
        Me.txtOrderRevDT.TabIndex = 153
        Me.txtOrderRevDT.Text = ""
        Me.ToolTip1.SetToolTip(Me.txtOrderRevDT, "Full Name")
        '
        'txtZipCode
        '
        Me.txtZipCode.BackColor = System.Drawing.SystemColors.Info
        Me.txtZipCode.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtZipCode.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtZipCode.Location = New System.Drawing.Point(8, 136)
        Me.txtZipCode.Name = "txtZipCode"
        Me.txtZipCode.ReadOnly = True
        Me.txtZipCode.Size = New System.Drawing.Size(136, 23)
        Me.txtZipCode.TabIndex = 142
        Me.txtZipCode.Text = ""
        Me.ToolTip1.SetToolTip(Me.txtZipCode, "Zip Code")
        '
        'txtCoutry
        '
        Me.txtCoutry.BackColor = System.Drawing.SystemColors.Info
        Me.txtCoutry.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCoutry.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtCoutry.Location = New System.Drawing.Point(144, 136)
        Me.txtCoutry.Name = "txtCoutry"
        Me.txtCoutry.ReadOnly = True
        Me.txtCoutry.Size = New System.Drawing.Size(112, 23)
        Me.txtCoutry.TabIndex = 143
        Me.txtCoutry.Text = ""
        Me.ToolTip1.SetToolTip(Me.txtCoutry, "Country")
        '
        'txtState
        '
        Me.txtState.BackColor = System.Drawing.SystemColors.Info
        Me.txtState.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtState.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtState.Location = New System.Drawing.Point(144, 112)
        Me.txtState.Name = "txtState"
        Me.txtState.ReadOnly = True
        Me.txtState.Size = New System.Drawing.Size(112, 23)
        Me.txtState.TabIndex = 141
        Me.txtState.Text = ""
        Me.ToolTip1.SetToolTip(Me.txtState, "State")
        '
        'txtCity
        '
        Me.txtCity.BackColor = System.Drawing.SystemColors.Info
        Me.txtCity.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCity.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtCity.Location = New System.Drawing.Point(8, 112)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.ReadOnly = True
        Me.txtCity.Size = New System.Drawing.Size(136, 23)
        Me.txtCity.TabIndex = 140
        Me.txtCity.Text = ""
        Me.ToolTip1.SetToolTip(Me.txtCity, "City")
        '
        'txtAddress2
        '
        Me.txtAddress2.BackColor = System.Drawing.SystemColors.Info
        Me.txtAddress2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress2.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtAddress2.Location = New System.Drawing.Point(8, 88)
        Me.txtAddress2.Name = "txtAddress2"
        Me.txtAddress2.ReadOnly = True
        Me.txtAddress2.Size = New System.Drawing.Size(248, 23)
        Me.txtAddress2.TabIndex = 139
        Me.txtAddress2.Text = ""
        Me.ToolTip1.SetToolTip(Me.txtAddress2, "Address 2")
        '
        'txtAddress1
        '
        Me.txtAddress1.BackColor = System.Drawing.SystemColors.Info
        Me.txtAddress1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress1.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtAddress1.Location = New System.Drawing.Point(8, 64)
        Me.txtAddress1.Name = "txtAddress1"
        Me.txtAddress1.ReadOnly = True
        Me.txtAddress1.Size = New System.Drawing.Size(248, 23)
        Me.txtAddress1.TabIndex = 138
        Me.txtAddress1.Text = ""
        Me.ToolTip1.SetToolTip(Me.txtAddress1, "Address 1")
        '
        'txtName
        '
        Me.txtName.BackColor = System.Drawing.SystemColors.Info
        Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtName.Location = New System.Drawing.Point(8, 40)
        Me.txtName.Name = "txtName"
        Me.txtName.ReadOnly = True
        Me.txtName.Size = New System.Drawing.Size(248, 21)
        Me.txtName.TabIndex = 137
        Me.txtName.Text = ""
        Me.ToolTip1.SetToolTip(Me.txtName, "Full Name")
        '
        'lblprekitCardDesc
        '
        Me.lblprekitCardDesc.BackColor = System.Drawing.Color.Transparent
        Me.lblprekitCardDesc.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblprekitCardDesc.ForeColor = System.Drawing.Color.White
        Me.lblprekitCardDesc.Location = New System.Drawing.Point(120, 40)
        Me.lblprekitCardDesc.Name = "lblprekitCardDesc"
        Me.lblprekitCardDesc.Size = New System.Drawing.Size(256, 21)
        Me.lblprekitCardDesc.TabIndex = 174
        Me.lblprekitCardDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolTip1.SetToolTip(Me.lblprekitCardDesc, "Sku type, Sku")
        '
        'lblPrekitInsertDesc
        '
        Me.lblPrekitInsertDesc.BackColor = System.Drawing.Color.Transparent
        Me.lblPrekitInsertDesc.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrekitInsertDesc.ForeColor = System.Drawing.Color.White
        Me.lblPrekitInsertDesc.Location = New System.Drawing.Point(136, 96)
        Me.lblPrekitInsertDesc.Name = "lblPrekitInsertDesc"
        Me.lblPrekitInsertDesc.Size = New System.Drawing.Size(240, 21)
        Me.lblPrekitInsertDesc.TabIndex = 173
        Me.lblPrekitInsertDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolTip1.SetToolTip(Me.lblPrekitInsertDesc, "Insert Part Type")
        '
        'btnDelAll
        '
        Me.btnDelAll.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelAll.Location = New System.Drawing.Point(528, 0)
        Me.btnDelAll.Name = "btnDelAll"
        Me.btnDelAll.Size = New System.Drawing.Size(56, 24)
        Me.btnDelAll.TabIndex = 176
        Me.btnDelAll.TabStop = False
        Me.btnDelAll.Text = "Del All"
        Me.ToolTip1.SetToolTip(Me.btnDelAll, "Remove All ")
        '
        'btnDelOne
        '
        Me.btnDelOne.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelOne.Location = New System.Drawing.Point(456, 0)
        Me.btnDelOne.Name = "btnDelOne"
        Me.btnDelOne.Size = New System.Drawing.Size(64, 24)
        Me.btnDelOne.TabIndex = 175
        Me.btnDelOne.TabStop = False
        Me.btnDelOne.Text = "Del One"
        Me.ToolTip1.SetToolTip(Me.btnDelOne, "Remove one SN")
        '
        'btnCopy2Clipboard
        '
        Me.btnCopy2Clipboard.BackColor = System.Drawing.SystemColors.Control
        Me.btnCopy2Clipboard.Image = CType(resources.GetObject("btnCopy2Clipboard.Image"), System.Drawing.Bitmap)
        Me.btnCopy2Clipboard.Location = New System.Drawing.Point(248, 0)
        Me.btnCopy2Clipboard.Name = "btnCopy2Clipboard"
        Me.btnCopy2Clipboard.Size = New System.Drawing.Size(25, 22)
        Me.btnCopy2Clipboard.TabIndex = 170
        Me.ToolTip1.SetToolTip(Me.btnCopy2Clipboard, "Copy order# to clipboard")
        '
        'btnReject
        '
        Me.btnReject.BackColor = System.Drawing.Color.Green
        Me.btnReject.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReject.ForeColor = System.Drawing.Color.Snow
        Me.btnReject.Location = New System.Drawing.Point(472, 5)
        Me.btnReject.Name = "btnReject"
        Me.btnReject.Size = New System.Drawing.Size(64, 32)
        Me.btnReject.TabIndex = 153
        Me.btnReject.TabStop = False
        Me.btnReject.Text = "Reject"
        Me.ToolTip1.SetToolTip(Me.btnReject, "Reject an open order ")
        '
        'btnReturnedOrder
        '
        Me.btnReturnedOrder.BackColor = System.Drawing.Color.Green
        Me.btnReturnedOrder.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReturnedOrder.ForeColor = System.Drawing.Color.Snow
        Me.btnReturnedOrder.Location = New System.Drawing.Point(544, 5)
        Me.btnReturnedOrder.Name = "btnReturnedOrder"
        Me.btnReturnedOrder.Size = New System.Drawing.Size(64, 32)
        Me.btnReturnedOrder.TabIndex = 154
        Me.btnReturnedOrder.TabStop = False
        Me.btnReturnedOrder.Text = "Return"
        Me.ToolTip1.SetToolTip(Me.btnReturnedOrder, "Set shipped order as returned order")
        '
        'lblOrderCount
        '
        Me.lblOrderCount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrderCount.ForeColor = System.Drawing.Color.Lime
        Me.lblOrderCount.Location = New System.Drawing.Point(8, 28)
        Me.lblOrderCount.Name = "lblOrderCount"
        Me.lblOrderCount.Size = New System.Drawing.Size(56, 16)
        Me.lblOrderCount.TabIndex = 178
        Me.lblOrderCount.Text = "0"
        Me.ToolTip1.SetToolTip(Me.lblOrderCount, "Open order count")
        '
        'btnCloseShip
        '
        Me.btnCloseShip.BackColor = System.Drawing.Color.Green
        Me.btnCloseShip.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCloseShip.ForeColor = System.Drawing.Color.White
        Me.btnCloseShip.Location = New System.Drawing.Point(368, 232)
        Me.btnCloseShip.Name = "btnCloseShip"
        Me.btnCloseShip.Size = New System.Drawing.Size(128, 24)
        Me.btnCloseShip.TabIndex = 179
        Me.btnCloseShip.TabStop = False
        Me.btnCloseShip.Text = "Close && Ship Order"
        Me.ToolTip1.SetToolTip(Me.btnCloseShip, "Set shipped order as returned order")
        Me.btnCloseShip.Visible = False
        '
        'btnRefreshPrinterData
        '
        Me.btnRefreshPrinterData.BackColor = System.Drawing.Color.LightGray
        Me.btnRefreshPrinterData.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefreshPrinterData.Location = New System.Drawing.Point(112, 32)
        Me.btnRefreshPrinterData.Name = "btnRefreshPrinterData"
        Me.btnRefreshPrinterData.Size = New System.Drawing.Size(88, 32)
        Me.btnRefreshPrinterData.TabIndex = 103
        Me.btnRefreshPrinterData.Text = "Refresh"
        Me.ToolTip1.SetToolTip(Me.btnRefreshPrinterData, "Reload printers and current setting")
        '
        'btnGetLockOrders
        '
        Me.btnGetLockOrders.BackColor = System.Drawing.Color.MediumBlue
        Me.btnGetLockOrders.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGetLockOrders.ForeColor = System.Drawing.Color.Snow
        Me.btnGetLockOrders.Location = New System.Drawing.Point(624, 5)
        Me.btnGetLockOrders.Name = "btnGetLockOrders"
        Me.btnGetLockOrders.Size = New System.Drawing.Size(128, 32)
        Me.btnGetLockOrders.TabIndex = 179
        Me.btnGetLockOrders.TabStop = False
        Me.btnGetLockOrders.Text = "Get/Lock Orders"
        Me.ToolTip1.SetToolTip(Me.btnGetLockOrders, "Set shipped order as returned order")
        '
        'btnUnlockOrder
        '
        Me.btnUnlockOrder.BackColor = System.Drawing.Color.SteelBlue
        Me.btnUnlockOrder.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUnlockOrder.ForeColor = System.Drawing.Color.Snow
        Me.btnUnlockOrder.Location = New System.Drawing.Point(760, 5)
        Me.btnUnlockOrder.Name = "btnUnlockOrder"
        Me.btnUnlockOrder.Size = New System.Drawing.Size(128, 32)
        Me.btnUnlockOrder.TabIndex = 180
        Me.btnUnlockOrder.TabStop = False
        Me.btnUnlockOrder.Text = "Unlock Order(s)"
        Me.ToolTip1.SetToolTip(Me.btnUnlockOrder, "Set shipped order as returned order")
        '
        'txtAssignedSIMCardSN
        '
        Me.txtAssignedSIMCardSN.Name = "txtAssignedSIMCardSN"
        Me.txtAssignedSIMCardSN.TabIndex = 170
        Me.txtAssignedSIMCardSN.Text = ""
        '
        'pnlFillShip
        '
        Me.pnlFillShip.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlFillShip.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkBySN, Me.chkByOrderNo, Me.btnRePrintLabel, Me.btnDelAll, Me.btnDelOne, Me.lstInsert, Me.lstICCID, Me.tdgProductDetails, Me.pnlCloseOrder, Me.btnCopy2Clipboard, Me.lblOrderRevDT, Me.txtSIMCardSN, Me.txtOrderRevDT, Me.txtTrackingNo, Me.cboShipCarrier, Me.grbShipmentInfo, Me.lblOrderNo, Me.txtOrderNo, Me.lblSIMCardSN, Me.btnGetTrackingNo, Me.lblTrackingNo, Me.pnlUnused, Me.lblSkuType, Me.lblShipQty, Me.lblOrderQty, Me.txtOrderQty, Me.txtShipQty, Me.btnCloseShip})
        Me.pnlFillShip.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlFillShip.ForeColor = System.Drawing.Color.White
        Me.pnlFillShip.Location = New System.Drawing.Point(2, 232)
        Me.pnlFillShip.Name = "pnlFillShip"
        Me.pnlFillShip.Size = New System.Drawing.Size(1110, 272)
        Me.pnlFillShip.TabIndex = 148
        '
        'chkBySN
        '
        Me.chkBySN.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBySN.ForeColor = System.Drawing.Color.Aqua
        Me.chkBySN.Location = New System.Drawing.Point(440, 232)
        Me.chkBySN.Name = "chkBySN"
        Me.chkBySN.Size = New System.Drawing.Size(48, 24)
        Me.chkBySN.TabIndex = 182
        Me.chkBySN.Text = "By SN"
        Me.chkBySN.Visible = False
        '
        'chkByOrderNo
        '
        Me.chkByOrderNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkByOrderNo.ForeColor = System.Drawing.Color.Aqua
        Me.chkByOrderNo.Location = New System.Drawing.Point(544, 232)
        Me.chkByOrderNo.Name = "chkByOrderNo"
        Me.chkByOrderNo.Size = New System.Drawing.Size(40, 24)
        Me.chkByOrderNo.TabIndex = 181
        Me.chkByOrderNo.Text = "By OrderNo"
        Me.chkByOrderNo.Visible = False
        '
        'btnRePrintLabel
        '
        Me.btnRePrintLabel.ForeColor = System.Drawing.Color.Aqua
        Me.btnRePrintLabel.Location = New System.Drawing.Point(320, 240)
        Me.btnRePrintLabel.Name = "btnRePrintLabel"
        Me.btnRePrintLabel.Size = New System.Drawing.Size(96, 32)
        Me.btnRePrintLabel.TabIndex = 180
        Me.btnRePrintLabel.Text = "Reprint Shipment Label"
        Me.btnRePrintLabel.Visible = False
        '
        'lstInsert
        '
        Me.lstInsert.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstInsert.Location = New System.Drawing.Point(464, 46)
        Me.lstInsert.Name = "lstInsert"
        Me.lstInsert.Size = New System.Drawing.Size(120, 95)
        Me.lstInsert.TabIndex = 174
        '
        'lstICCID
        '
        Me.lstICCID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstICCID.Location = New System.Drawing.Point(288, 46)
        Me.lstICCID.Name = "lstICCID"
        Me.lstICCID.Size = New System.Drawing.Size(176, 95)
        Me.lstICCID.TabIndex = 173
        '
        'tdgProductDetails
        '
        Me.tdgProductDetails.AllowColMove = False
        Me.tdgProductDetails.AllowColSelect = False
        Me.tdgProductDetails.AllowFilter = False
        Me.tdgProductDetails.AllowSort = False
        Me.tdgProductDetails.AllowUpdate = False
        Me.tdgProductDetails.AlternatingRows = True
        Me.tdgProductDetails.BackColor = System.Drawing.Color.GhostWhite
        Me.tdgProductDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tdgProductDetails.CaptionHeight = 17
        Me.tdgProductDetails.FetchRowStyles = True
        Me.tdgProductDetails.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tdgProductDetails.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdgProductDetails.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.tdgProductDetails.Location = New System.Drawing.Point(288, 152)
        Me.tdgProductDetails.Name = "tdgProductDetails"
        Me.tdgProductDetails.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdgProductDetails.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdgProductDetails.PreviewInfo.ZoomFactor = 75
        Me.tdgProductDetails.RowHeight = 15
        Me.tdgProductDetails.Size = New System.Drawing.Size(504, 80)
        Me.tdgProductDetails.TabIndex = 172
        Me.tdgProductDetails.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
        "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
        "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
        "tion{AlignHorz:Center;}Style9{}Normal{Font:Tahoma, 8.25pt;}HighlightRow{ForeColo" & _
        "r:HighlightText;BackColor:Highlight;}Style12{}OddRow{}RecordSelector{AlignImage:" & _
        "Center;}Style13{}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;Fo" & _
        "reColor:ControlText;BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style11{}" & _
        "Style14{}Style15{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView" & _
        " AllowColMove=""False"" AllowColSelect=""False"" Name="""" AlternatingRowStyle=""True"" " & _
        "CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyl" & _
        "es=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidt" & _
        "h=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>78</Height><Cap" & _
        "tionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5" & _
        """ /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterB" & _
        "ar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent" & _
        "=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightR" & _
        "owStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=" & _
        """Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle paren" & _
        "t=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /" & _
        "><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 502, 78</ClientRect><Bor" & _
        "derSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.Mer" & _
        "geView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Norma" & _
        "l"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" " & _
        "me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me" & _
        "=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""Hi" & _
        "ghlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""O" & _
        "ddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me" & _
        "=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1<" & _
        "/vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>1" & _
        "7</DefaultRecSelWidth><ClientArea>0, 0, 502, 78</ClientArea><PrintPageHeaderStyl" & _
        "e parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob" & _
        ">"
        '
        'pnlCloseOrder
        '
        Me.pnlCloseOrder.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlCloseOrder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlCloseOrder.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.Label2, Me.btnCloseOrderWithNtfctns, Me.btnCloseOrder})
        Me.pnlCloseOrder.Location = New System.Drawing.Point(592, 2)
        Me.pnlCloseOrder.Name = "pnlCloseOrder"
        Me.pnlCloseOrder.Size = New System.Drawing.Size(200, 94)
        Me.pnlCloseOrder.TabIndex = 171
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(184, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Close && Ship Order"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(16, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(168, 34)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Did you receive an Endicia notification? "
        '
        'btnCloseOrderWithNtfctns
        '
        Me.btnCloseOrderWithNtfctns.BackColor = System.Drawing.SystemColors.Control
        Me.btnCloseOrderWithNtfctns.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCloseOrderWithNtfctns.ForeColor = System.Drawing.Color.Black
        Me.btnCloseOrderWithNtfctns.Location = New System.Drawing.Point(8, 56)
        Me.btnCloseOrderWithNtfctns.Name = "btnCloseOrderWithNtfctns"
        Me.btnCloseOrderWithNtfctns.Size = New System.Drawing.Size(72, 32)
        Me.btnCloseOrderWithNtfctns.TabIndex = 2
        Me.btnCloseOrderWithNtfctns.Text = "Yes"
        '
        'btnCloseOrder
        '
        Me.btnCloseOrder.BackColor = System.Drawing.SystemColors.Control
        Me.btnCloseOrder.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCloseOrder.ForeColor = System.Drawing.Color.Black
        Me.btnCloseOrder.Location = New System.Drawing.Point(88, 56)
        Me.btnCloseOrder.Name = "btnCloseOrder"
        Me.btnCloseOrder.Size = New System.Drawing.Size(80, 32)
        Me.btnCloseOrder.TabIndex = 1
        Me.btnCloseOrder.Text = "No"
        '
        'lblOrderRevDT
        '
        Me.lblOrderRevDT.BackColor = System.Drawing.Color.Transparent
        Me.lblOrderRevDT.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrderRevDT.ForeColor = System.Drawing.Color.White
        Me.lblOrderRevDT.Location = New System.Drawing.Point(0, 24)
        Me.lblOrderRevDT.Name = "lblOrderRevDT"
        Me.lblOrderRevDT.Size = New System.Drawing.Size(80, 21)
        Me.lblOrderRevDT.TabIndex = 161
        Me.lblOrderRevDT.Text = "Order Date:"
        Me.lblOrderRevDT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSIMCardSN
        '
        Me.txtSIMCardSN.BackColor = System.Drawing.Color.White
        Me.txtSIMCardSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSIMCardSN.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSIMCardSN.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtSIMCardSN.Location = New System.Drawing.Point(288, 24)
        Me.txtSIMCardSN.Name = "txtSIMCardSN"
        Me.txtSIMCardSN.Size = New System.Drawing.Size(296, 22)
        Me.txtSIMCardSN.TabIndex = 158
        Me.txtSIMCardSN.Text = ""
        '
        'txtTrackingNo
        '
        Me.txtTrackingNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTrackingNo.Location = New System.Drawing.Point(592, 120)
        Me.txtTrackingNo.Name = "txtTrackingNo"
        Me.txtTrackingNo.Size = New System.Drawing.Size(200, 21)
        Me.txtTrackingNo.TabIndex = 160
        Me.txtTrackingNo.Text = ""
        '
        'cboShipCarrier
        '
        Me.cboShipCarrier.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboShipCarrier.AutoCompletion = True
        Me.cboShipCarrier.AutoDropDown = True
        Me.cboShipCarrier.AutoSelect = True
        Me.cboShipCarrier.Caption = ""
        Me.cboShipCarrier.CaptionHeight = 17
        Me.cboShipCarrier.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboShipCarrier.ColumnCaptionHeight = 17
        Me.cboShipCarrier.ColumnFooterHeight = 17
        Me.cboShipCarrier.ColumnHeaders = False
        Me.cboShipCarrier.ContentHeight = 15
        Me.cboShipCarrier.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboShipCarrier.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboShipCarrier.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboShipCarrier.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboShipCarrier.EditorHeight = 15
        Me.cboShipCarrier.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
        Me.cboShipCarrier.ItemHeight = 15
        Me.cboShipCarrier.Location = New System.Drawing.Point(736, 240)
        Me.cboShipCarrier.MatchEntryTimeout = CType(2000, Long)
        Me.cboShipCarrier.MaxDropDownItems = CType(10, Short)
        Me.cboShipCarrier.MaxLength = 32767
        Me.cboShipCarrier.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboShipCarrier.Name = "cboShipCarrier"
        Me.cboShipCarrier.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboShipCarrier.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboShipCarrier.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboShipCarrier.Size = New System.Drawing.Size(56, 21)
        Me.cboShipCarrier.TabIndex = 147
        Me.cboShipCarrier.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:HotTrack;}Style3{}Inactive{ForeColor:InactiveCaptionText;Bac" & _
        "kColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{F" & _
        "oreColor:HighlightText;BackColor:Highlight;}Style1{}OddRow{}RecordSelector{Align" & _
        "Image:Center;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;Fore" & _
        "Color:ControlText;AlignVert:Center;}Style8{}Style10{}Style11{}Style9{AlignHorz:N" & _
        "ear;}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" N" & _
        "ame=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=" & _
        """17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 15" & _
        "6</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HSc" & _
        "rollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style9" & _
        """ /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" me" & _
        "=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Head" & _
        "ing"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inact" & _
        "iveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style8" & _
        """ /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle p" & _
        "arent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1L" & _
        "ist.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style pare" & _
        "nt=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""" & _
        "Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""N" & _
        "ormal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=" & _
        """Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Head" & _
        "ing"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><v" & _
        "ertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Defa" & _
        "ultRecSelWidth>17</DefaultRecSelWidth></Blob>"
        '
        'grbShipmentInfo
        '
        Me.grbShipmentInfo.BackColor = System.Drawing.Color.SteelBlue
        Me.grbShipmentInfo.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnChangeAddress, Me.txtZipCode, Me.txtCoutry, Me.txtState, Me.txtCity, Me.txtAddress2, Me.txtAddress1, Me.txtName, Me.Label12})
        Me.grbShipmentInfo.Location = New System.Drawing.Point(8, 72)
        Me.grbShipmentInfo.Name = "grbShipmentInfo"
        Me.grbShipmentInfo.Size = New System.Drawing.Size(264, 176)
        Me.grbShipmentInfo.TabIndex = 146
        Me.grbShipmentInfo.TabStop = False
        '
        'btnChangeAddress
        '
        Me.btnChangeAddress.BackColor = System.Drawing.Color.DarkGray
        Me.btnChangeAddress.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChangeAddress.ForeColor = System.Drawing.Color.Black
        Me.btnChangeAddress.Location = New System.Drawing.Point(96, 8)
        Me.btnChangeAddress.Name = "btnChangeAddress"
        Me.btnChangeAddress.Size = New System.Drawing.Size(160, 30)
        Me.btnChangeAddress.TabIndex = 144
        Me.btnChangeAddress.Text = "Change Address"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(1, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 16)
        Me.Label12.TabIndex = 136
        Me.Label12.Text = "Address:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOrderNo
        '
        Me.lblOrderNo.BackColor = System.Drawing.Color.Transparent
        Me.lblOrderNo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrderNo.ForeColor = System.Drawing.Color.White
        Me.lblOrderNo.Location = New System.Drawing.Point(8, 0)
        Me.lblOrderNo.Name = "lblOrderNo"
        Me.lblOrderNo.Size = New System.Drawing.Size(72, 21)
        Me.lblOrderNo.TabIndex = 139
        Me.lblOrderNo.Text = "Order No:"
        Me.lblOrderNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtOrderNo
        '
        Me.txtOrderNo.BackColor = System.Drawing.SystemColors.Info
        Me.txtOrderNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOrderNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrderNo.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtOrderNo.Location = New System.Drawing.Point(80, 0)
        Me.txtOrderNo.Name = "txtOrderNo"
        Me.txtOrderNo.ReadOnly = True
        Me.txtOrderNo.Size = New System.Drawing.Size(168, 21)
        Me.txtOrderNo.TabIndex = 138
        Me.txtOrderNo.Text = ""
        '
        'lblSIMCardSN
        '
        Me.lblSIMCardSN.BackColor = System.Drawing.Color.Transparent
        Me.lblSIMCardSN.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSIMCardSN.ForeColor = System.Drawing.Color.White
        Me.lblSIMCardSN.Location = New System.Drawing.Point(288, 6)
        Me.lblSIMCardSN.Name = "lblSIMCardSN"
        Me.lblSIMCardSN.Size = New System.Drawing.Size(112, 21)
        Me.lblSIMCardSN.TabIndex = 159
        Me.lblSIMCardSN.Text = "SIM Card SN"
        Me.lblSIMCardSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnGetTrackingNo
        '
        Me.btnGetTrackingNo.BackColor = System.Drawing.Color.Transparent
        Me.btnGetTrackingNo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGetTrackingNo.ForeColor = System.Drawing.Color.White
        Me.btnGetTrackingNo.Location = New System.Drawing.Point(672, 96)
        Me.btnGetTrackingNo.Name = "btnGetTrackingNo"
        Me.btnGetTrackingNo.Size = New System.Drawing.Size(120, 24)
        Me.btnGetTrackingNo.TabIndex = 153
        Me.btnGetTrackingNo.Text = "Get Tracking No"
        '
        'lblTrackingNo
        '
        Me.lblTrackingNo.BackColor = System.Drawing.Color.Transparent
        Me.lblTrackingNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTrackingNo.ForeColor = System.Drawing.Color.White
        Me.lblTrackingNo.Location = New System.Drawing.Point(592, 104)
        Me.lblTrackingNo.Name = "lblTrackingNo"
        Me.lblTrackingNo.Size = New System.Drawing.Size(112, 16)
        Me.lblTrackingNo.TabIndex = 150
        Me.lblTrackingNo.Text = "Tracking No:"
        Me.lblTrackingNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlUnused
        '
        Me.pnlUnused.BackColor = System.Drawing.Color.Azure
        Me.pnlUnused.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblSku, Me.txtSku, Me.lblSkuDesc, Me.lblInsertPartNo, Me.txtAssignedInsertPartNo, Me.txtAssignedSIMCardSN, Me.lblInsertPN, Me.txtInsertPartNo, Me.btnUndoInsertPN, Me.btnUndoSIMSN})
        Me.pnlUnused.Location = New System.Drawing.Point(608, 240)
        Me.pnlUnused.Name = "pnlUnused"
        Me.pnlUnused.Size = New System.Drawing.Size(120, 24)
        Me.pnlUnused.TabIndex = 144
        '
        'lblSku
        '
        Me.lblSku.BackColor = System.Drawing.Color.Transparent
        Me.lblSku.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSku.ForeColor = System.Drawing.Color.White
        Me.lblSku.Location = New System.Drawing.Point(64, 0)
        Me.lblSku.Name = "lblSku"
        Me.lblSku.Size = New System.Drawing.Size(8, 21)
        Me.lblSku.TabIndex = 141
        Me.lblSku.Text = "Sku :"
        Me.lblSku.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSku
        '
        Me.txtSku.BackColor = System.Drawing.SystemColors.Info
        Me.txtSku.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSku.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSku.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtSku.Location = New System.Drawing.Point(72, 0)
        Me.txtSku.Name = "txtSku"
        Me.txtSku.ReadOnly = True
        Me.txtSku.Size = New System.Drawing.Size(8, 21)
        Me.txtSku.TabIndex = 140
        Me.txtSku.Text = ""
        '
        'lblSkuDesc
        '
        Me.lblSkuDesc.BackColor = System.Drawing.Color.Transparent
        Me.lblSkuDesc.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSkuDesc.ForeColor = System.Drawing.Color.White
        Me.lblSkuDesc.Location = New System.Drawing.Point(184, 0)
        Me.lblSkuDesc.Name = "lblSkuDesc"
        Me.lblSkuDesc.Size = New System.Drawing.Size(8, 23)
        Me.lblSkuDesc.TabIndex = 169
        Me.lblSkuDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblSkuDesc.Visible = False
        '
        'lblInsertPartNo
        '
        Me.lblInsertPartNo.BackColor = System.Drawing.Color.Transparent
        Me.lblInsertPartNo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInsertPartNo.ForeColor = System.Drawing.Color.White
        Me.lblInsertPartNo.Location = New System.Drawing.Point(112, 0)
        Me.lblInsertPartNo.Name = "lblInsertPartNo"
        Me.lblInsertPartNo.Size = New System.Drawing.Size(8, 21)
        Me.lblInsertPartNo.TabIndex = 156
        Me.lblInsertPartNo.Text = "Insert Part No"
        Me.lblInsertPartNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblInsertPN
        '
        Me.lblInsertPN.BackColor = System.Drawing.Color.Transparent
        Me.lblInsertPN.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInsertPN.ForeColor = System.Drawing.Color.White
        Me.lblInsertPN.Location = New System.Drawing.Point(184, 0)
        Me.lblInsertPN.Name = "lblInsertPN"
        Me.lblInsertPN.Size = New System.Drawing.Size(8, 21)
        Me.lblInsertPN.TabIndex = 167
        Me.lblInsertPN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtInsertPartNo
        '
        Me.txtInsertPartNo.BackColor = System.Drawing.Color.White
        Me.txtInsertPartNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInsertPartNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInsertPartNo.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtInsertPartNo.Location = New System.Drawing.Point(96, 0)
        Me.txtInsertPartNo.Name = "txtInsertPartNo"
        Me.txtInsertPartNo.Size = New System.Drawing.Size(8, 21)
        Me.txtInsertPartNo.TabIndex = 159
        Me.txtInsertPartNo.Text = ""
        '
        'btnUndoInsertPN
        '
        Me.btnUndoInsertPN.Location = New System.Drawing.Point(224, 0)
        Me.btnUndoInsertPN.Name = "btnUndoInsertPN"
        Me.btnUndoInsertPN.Size = New System.Drawing.Size(8, 24)
        Me.btnUndoInsertPN.TabIndex = 165
        Me.btnUndoInsertPN.TabStop = False
        Me.btnUndoInsertPN.Text = "Undo"
        Me.btnUndoInsertPN.Visible = False
        '
        'btnUndoSIMSN
        '
        Me.btnUndoSIMSN.Location = New System.Drawing.Point(16, 0)
        Me.btnUndoSIMSN.Name = "btnUndoSIMSN"
        Me.btnUndoSIMSN.Size = New System.Drawing.Size(32, 24)
        Me.btnUndoSIMSN.TabIndex = 166
        Me.btnUndoSIMSN.TabStop = False
        Me.btnUndoSIMSN.Text = "Undo"
        '
        'lblSkuType
        '
        Me.lblSkuType.BackColor = System.Drawing.Color.Transparent
        Me.lblSkuType.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSkuType.ForeColor = System.Drawing.Color.White
        Me.lblSkuType.Location = New System.Drawing.Point(640, 240)
        Me.lblSkuType.Name = "lblSkuType"
        Me.lblSkuType.Size = New System.Drawing.Size(8, 21)
        Me.lblSkuType.TabIndex = 168
        Me.lblSkuType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblShipQty
        '
        Me.lblShipQty.BackColor = System.Drawing.Color.Transparent
        Me.lblShipQty.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShipQty.ForeColor = System.Drawing.Color.White
        Me.lblShipQty.Location = New System.Drawing.Point(144, 48)
        Me.lblShipQty.Name = "lblShipQty"
        Me.lblShipQty.Size = New System.Drawing.Size(72, 21)
        Me.lblShipQty.TabIndex = 163
        Me.lblShipQty.Text = "Ship Qty:"
        Me.lblShipQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblOrderQty
        '
        Me.lblOrderQty.BackColor = System.Drawing.Color.Transparent
        Me.lblOrderQty.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrderQty.ForeColor = System.Drawing.Color.White
        Me.lblOrderQty.Location = New System.Drawing.Point(0, 48)
        Me.lblOrderQty.Name = "lblOrderQty"
        Me.lblOrderQty.Size = New System.Drawing.Size(80, 21)
        Me.lblOrderQty.TabIndex = 152
        Me.lblOrderQty.Text = "Order Qty:"
        Me.lblOrderQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtOrderQty
        '
        Me.txtOrderQty.BackColor = System.Drawing.Color.Black
        Me.txtOrderQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOrderQty.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrderQty.ForeColor = System.Drawing.Color.Aqua
        Me.txtOrderQty.Location = New System.Drawing.Point(80, 48)
        Me.txtOrderQty.Name = "txtOrderQty"
        Me.txtOrderQty.ReadOnly = True
        Me.txtOrderQty.Size = New System.Drawing.Size(48, 23)
        Me.txtOrderQty.TabIndex = 151
        Me.txtOrderQty.Text = "0"
        Me.txtOrderQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtShipQty
        '
        Me.txtShipQty.BackColor = System.Drawing.Color.Black
        Me.txtShipQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShipQty.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShipQty.ForeColor = System.Drawing.Color.Aqua
        Me.txtShipQty.Location = New System.Drawing.Point(216, 48)
        Me.txtShipQty.Name = "txtShipQty"
        Me.txtShipQty.ReadOnly = True
        Me.txtShipQty.Size = New System.Drawing.Size(48, 23)
        Me.txtShipQty.TabIndex = 162
        Me.txtShipQty.Text = "0"
        Me.txtShipQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TabControl1
        '
        Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tabOrder, Me.tabPrekit, Me.tabSetPrinter})
        Me.TabControl1.Location = New System.Drawing.Point(8, 8)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1128, 536)
        Me.TabControl1.TabIndex = 148
        '
        'tabOrder
        '
        Me.tabOrder.BackColor = System.Drawing.Color.SteelBlue
        Me.tabOrder.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnUnlockOrder, Me.btnGetLockOrders, Me.btnReturnedOrder, Me.btnReject, Me.btnClear, Me.btnCopyAll, Me.btnSelectWO, Me.btnRefresh, Me.pnlFillShip, Me.cboCustomer, Me.tdgData1, Me.lblOrderCount})
        Me.tabOrder.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabOrder.Location = New System.Drawing.Point(4, 22)
        Me.tabOrder.Name = "tabOrder"
        Me.tabOrder.Size = New System.Drawing.Size(1120, 510)
        Me.tabOrder.TabIndex = 0
        Me.tabOrder.Text = "Fill Order"
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.Green
        Me.btnClear.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.Color.White
        Me.btnClear.Location = New System.Drawing.Point(400, 5)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(64, 32)
        Me.btnClear.TabIndex = 152
        Me.btnClear.Text = "Clear"
        '
        'btnCopyAll
        '
        Me.btnCopyAll.BackColor = System.Drawing.Color.DarkTurquoise
        Me.btnCopyAll.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopyAll.ForeColor = System.Drawing.Color.Black
        Me.btnCopyAll.Location = New System.Drawing.Point(920, 5)
        Me.btnCopyAll.Name = "btnCopyAll"
        Me.btnCopyAll.Size = New System.Drawing.Size(112, 32)
        Me.btnCopyAll.TabIndex = 151
        Me.btnCopyAll.TabStop = False
        Me.btnCopyAll.Text = "Copy All Rows"
        '
        'btnSelectWO
        '
        Me.btnSelectWO.BackColor = System.Drawing.Color.Green
        Me.btnSelectWO.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelectWO.ForeColor = System.Drawing.Color.White
        Me.btnSelectWO.Location = New System.Drawing.Point(248, 5)
        Me.btnSelectWO.Name = "btnSelectWO"
        Me.btnSelectWO.Size = New System.Drawing.Size(144, 32)
        Me.btnSelectWO.TabIndex = 150
        Me.btnSelectWO.Text = "Select Order To Fill"
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.Green
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.Location = New System.Drawing.Point(144, 5)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(96, 32)
        Me.btnRefresh.TabIndex = 149
        Me.btnRefresh.Text = "Refresh Order"
        '
        'cboCustomer
        '
        Me.cboCustomer.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboCustomer.AutoCompletion = True
        Me.cboCustomer.AutoDropDown = True
        Me.cboCustomer.AutoSelect = True
        Me.cboCustomer.Caption = ""
        Me.cboCustomer.CaptionHeight = 17
        Me.cboCustomer.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboCustomer.ColumnCaptionHeight = 17
        Me.cboCustomer.ColumnFooterHeight = 17
        Me.cboCustomer.ColumnHeaders = False
        Me.cboCustomer.ContentHeight = 15
        Me.cboCustomer.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboCustomer.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboCustomer.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCustomer.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboCustomer.EditorHeight = 15
        Me.cboCustomer.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
        Me.cboCustomer.ItemHeight = 15
        Me.cboCustomer.Location = New System.Drawing.Point(8, 6)
        Me.cboCustomer.MatchEntryTimeout = CType(2000, Long)
        Me.cboCustomer.MaxDropDownItems = CType(10, Short)
        Me.cboCustomer.MaxLength = 32767
        Me.cboCustomer.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboCustomer.Name = "cboCustomer"
        Me.cboCustomer.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboCustomer.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboCustomer.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboCustomer.Size = New System.Drawing.Size(128, 21)
        Me.cboCustomer.TabIndex = 142
        Me.cboCustomer.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:HotTrack;}Style3{}Inactive{ForeColor:InactiveCaptionText;Bac" & _
        "kColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{F" & _
        "oreColor:HighlightText;BackColor:Highlight;}Style1{}OddRow{}RecordSelector{Align" & _
        "Image:Center;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;Fore" & _
        "Color:ControlText;AlignVert:Center;}Style8{}Style10{}Style11{}Style9{AlignHorz:N" & _
        "ear;}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" N" & _
        "ame=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=" & _
        """17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 15" & _
        "6</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HSc" & _
        "rollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style9" & _
        """ /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" me" & _
        "=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Head" & _
        "ing"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inact" & _
        "iveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style8" & _
        """ /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle p" & _
        "arent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1L" & _
        "ist.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style pare" & _
        "nt=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""" & _
        "Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""N" & _
        "ormal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=" & _
        """Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Head" & _
        "ing"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><v" & _
        "ertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Defa" & _
        "ultRecSelWidth>17</DefaultRecSelWidth></Blob>"
        '
        'tdgData1
        '
        Me.tdgData1.AllowUpdate = False
        Me.tdgData1.AlternatingRows = True
        Me.tdgData1.BackColor = System.Drawing.Color.GhostWhite
        Me.tdgData1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tdgData1.CaptionHeight = 17
        Me.tdgData1.FetchRowStyles = True
        Me.tdgData1.FilterBar = True
        Me.tdgData1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tdgData1.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdgData1.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
        Me.tdgData1.Location = New System.Drawing.Point(8, 40)
        Me.tdgData1.Name = "tdgData1"
        Me.tdgData1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdgData1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdgData1.PreviewInfo.ZoomFactor = 75
        Me.tdgData1.RowHeight = 15
        Me.tdgData1.Size = New System.Drawing.Size(1104, 184)
        Me.tdgData1.TabIndex = 141
        Me.tdgData1.Text = "C1TrueDBGrid1"
        Me.tdgData1.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
        "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
        "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
        "tion{AlignHorz:Center;}Style1{}Normal{Font:Tahoma, 8.25pt;}HighlightRow{ForeColo" & _
        "r:HighlightText;BackColor:Highlight;}Style14{}OddRow{}RecordSelector{AlignImage:" & _
        "Center;}Style15{}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;F" & _
        "oreColor:ControlText;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}" & _
        "Style12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView" & _
        " Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" " & _
        "ColumnFooterHeight=""17"" FetchRowStyles=""True"" FilterBar=""True"" MarqueeStyle=""Dot" & _
        "tedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=" & _
        """1"" HorizontalScrollGroup=""1""><Height>182</Height><CaptionStyle parent=""Style2"" " & _
        "me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""" & _
        "EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><Footer" & _
        "Style parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><H" & _
        "eadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightR" & _
        "ow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle pa" & _
        "rent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Sty" & _
        "le11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me" & _
        "=""Style1"" /><ClientRect>0, 0, 1102, 182</ClientRect><BorderSide>0</BorderSide><B" & _
        "orderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedSt" & _
        "yles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style" & _
        " parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style pa" & _
        "rent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style par" & _
        "ent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style par" & _
        "ent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""" & _
        "Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style pa" & _
        "rent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>" & _
        "1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><C" & _
        "lientArea>0, 0, 1102, 182</ClientArea><PrintPageHeaderStyle parent="""" me=""Style1" & _
        "4"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
        '
        'tabPrekit
        '
        Me.tabPrekit.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tabPrekit.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkBoxLock, Me.cboPrekitInsertPN, Me.lblPrekitInsertDesc, Me.tdgData2, Me.btnprekitSNUndo, Me.btnPreKit, Me.txtPrekitCardSN, Me.txtPrekitInsertPN, Me.lblprekitCardDesc, Me.lblPrekitCard, Me.lblprekitInsert})
        Me.tabPrekit.Location = New System.Drawing.Point(4, 22)
        Me.tabPrekit.Name = "tabPrekit"
        Me.tabPrekit.Size = New System.Drawing.Size(1120, 510)
        Me.tabPrekit.TabIndex = 1
        Me.tabPrekit.Text = "Pre-Kit"
        '
        'chkBoxLock
        '
        Me.chkBoxLock.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBoxLock.ForeColor = System.Drawing.Color.MediumBlue
        Me.chkBoxLock.Location = New System.Drawing.Point(8, 8)
        Me.chkBoxLock.Name = "chkBoxLock"
        Me.chkBoxLock.Size = New System.Drawing.Size(264, 24)
        Me.chkBoxLock.TabIndex = 179
        Me.chkBoxLock.Text = "Lock Insert item if multiple Inserts"
        '
        'cboPrekitInsertPN
        '
        Me.cboPrekitInsertPN.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboPrekitInsertPN.AutoCompletion = True
        Me.cboPrekitInsertPN.AutoDropDown = True
        Me.cboPrekitInsertPN.AutoSelect = True
        Me.cboPrekitInsertPN.Caption = ""
        Me.cboPrekitInsertPN.CaptionHeight = 17
        Me.cboPrekitInsertPN.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboPrekitInsertPN.ColumnCaptionHeight = 17
        Me.cboPrekitInsertPN.ColumnFooterHeight = 17
        Me.cboPrekitInsertPN.ColumnHeaders = False
        Me.cboPrekitInsertPN.ContentHeight = 15
        Me.cboPrekitInsertPN.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboPrekitInsertPN.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboPrekitInsertPN.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPrekitInsertPN.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboPrekitInsertPN.EditorHeight = 15
        Me.cboPrekitInsertPN.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
        Me.cboPrekitInsertPN.ItemHeight = 15
        Me.cboPrekitInsertPN.Location = New System.Drawing.Point(32, 144)
        Me.cboPrekitInsertPN.MatchEntryTimeout = CType(2000, Long)
        Me.cboPrekitInsertPN.MaxDropDownItems = CType(10, Short)
        Me.cboPrekitInsertPN.MaxLength = 32767
        Me.cboPrekitInsertPN.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboPrekitInsertPN.Name = "cboPrekitInsertPN"
        Me.cboPrekitInsertPN.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboPrekitInsertPN.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboPrekitInsertPN.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboPrekitInsertPN.Size = New System.Drawing.Size(200, 21)
        Me.cboPrekitInsertPN.TabIndex = 178
        Me.cboPrekitInsertPN.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:HotTrack;}Style3{}Inactive{ForeColor:InactiveCaptionText;Bac" & _
        "kColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{F" & _
        "oreColor:HighlightText;BackColor:Highlight;}Style1{}OddRow{}RecordSelector{Align" & _
        "Image:Center;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;Fore" & _
        "Color:ControlText;AlignVert:Center;}Style8{}Style10{}Style11{}Style9{AlignHorz:N" & _
        "ear;}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" N" & _
        "ame=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=" & _
        """17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 15" & _
        "6</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HSc" & _
        "rollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style9" & _
        """ /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" me" & _
        "=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Head" & _
        "ing"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inact" & _
        "iveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style8" & _
        """ /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle p" & _
        "arent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1L" & _
        "ist.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style pare" & _
        "nt=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""" & _
        "Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""N" & _
        "ormal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=" & _
        """Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Head" & _
        "ing"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><v" & _
        "ertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Defa" & _
        "ultRecSelWidth>17</DefaultRecSelWidth></Blob>"
        '
        'tdgData2
        '
        Me.tdgData2.AllowColMove = False
        Me.tdgData2.AllowColSelect = False
        Me.tdgData2.AllowFilter = False
        Me.tdgData2.AllowSort = False
        Me.tdgData2.AllowUpdate = False
        Me.tdgData2.AlternatingRows = True
        Me.tdgData2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tdgData2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tdgData2.Caption = "Session Pre-Kitting Result (0)"
        Me.tdgData2.FetchRowStyles = True
        Me.tdgData2.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Flat
        Me.tdgData2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tdgData2.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdgData2.Images.Add(CType(resources.GetObject("resource.Images5"), System.Drawing.Bitmap))
        Me.tdgData2.Location = New System.Drawing.Point(360, 8)
        Me.tdgData2.Name = "tdgData2"
        Me.tdgData2.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdgData2.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdgData2.PreviewInfo.ZoomFactor = 75
        Me.tdgData2.RowSubDividerColor = System.Drawing.Color.LightBlue
        Me.tdgData2.Size = New System.Drawing.Size(456, 616)
        Me.tdgData2.TabIndex = 176
        Me.tdgData2.Text = "C1TrueDBGrid1"
        Me.tdgData2.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Al" & _
        "iceBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive{" & _
        "ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Capt" & _
        "ion{AlignHorz:Center;ForeColor:Navy;BackColor:LightSteelBlue;}Style9{}Normal{Fon" & _
        "t:Arial, 8.25pt;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style" & _
        "12{}OddRow{}RecordSelector{AlignImage:Center;}Style13{}Heading{Wrap:True;AlignVe" & _
        "rt:Center;Border:Flat,ControlDark,1, 1, 1, 1;ForeColor:ControlText;BackColor:Lig" & _
        "htSteelBlue;}Style8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style1{}" & _
        "</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" Allo" & _
        "wColSelect=""False"" Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnC" & _
        "aptionHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""True"" FilterBorderStyl" & _
        "e=""Flat"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth" & _
        "=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>599</Height><Cap" & _
        "tionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5" & _
        """ /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterB" & _
        "ar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent" & _
        "=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightR" & _
        "owStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=" & _
        """Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle paren" & _
        "t=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /" & _
        "><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 17, 456, 599</ClientRect><B" & _
        "orderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.M" & _
        "ergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Nor" & _
        "mal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading" & _
        """ me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" " & _
        "me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""" & _
        "HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=" & _
        """OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" " & _
        "me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>" & _
        "1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth" & _
        ">17</DefaultRecSelWidth><ClientArea>0, 0, 456, 616</ClientArea><PrintPageHeaderS" & _
        "tyle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></B" & _
        "lob>"
        '
        'btnprekitSNUndo
        '
        Me.btnprekitSNUndo.Location = New System.Drawing.Point(240, 64)
        Me.btnprekitSNUndo.Name = "btnprekitSNUndo"
        Me.btnprekitSNUndo.Size = New System.Drawing.Size(72, 24)
        Me.btnprekitSNUndo.TabIndex = 175
        Me.btnprekitSNUndo.Text = "Undo"
        '
        'btnPreKit
        '
        Me.btnPreKit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPreKit.Location = New System.Drawing.Point(32, 176)
        Me.btnPreKit.Name = "btnPreKit"
        Me.btnPreKit.Size = New System.Drawing.Size(200, 64)
        Me.btnPreKit.TabIndex = 172
        Me.btnPreKit.Text = "Complete"
        '
        'txtPrekitCardSN
        '
        Me.txtPrekitCardSN.BackColor = System.Drawing.Color.White
        Me.txtPrekitCardSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrekitCardSN.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrekitCardSN.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtPrekitCardSN.Location = New System.Drawing.Point(32, 64)
        Me.txtPrekitCardSN.Name = "txtPrekitCardSN"
        Me.txtPrekitCardSN.Size = New System.Drawing.Size(200, 21)
        Me.txtPrekitCardSN.TabIndex = 170
        Me.txtPrekitCardSN.Text = ""
        '
        'txtPrekitInsertPN
        '
        Me.txtPrekitInsertPN.BackColor = System.Drawing.Color.White
        Me.txtPrekitInsertPN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrekitInsertPN.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrekitInsertPN.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtPrekitInsertPN.Location = New System.Drawing.Point(32, 120)
        Me.txtPrekitInsertPN.Name = "txtPrekitInsertPN"
        Me.txtPrekitInsertPN.Size = New System.Drawing.Size(200, 21)
        Me.txtPrekitInsertPN.TabIndex = 171
        Me.txtPrekitInsertPN.Text = ""
        '
        'lblPrekitCard
        '
        Me.lblPrekitCard.BackColor = System.Drawing.Color.Transparent
        Me.lblPrekitCard.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrekitCard.ForeColor = System.Drawing.Color.Black
        Me.lblPrekitCard.Location = New System.Drawing.Point(32, 40)
        Me.lblPrekitCard.Name = "lblPrekitCard"
        Me.lblPrekitCard.Size = New System.Drawing.Size(96, 21)
        Me.lblPrekitCard.TabIndex = 171
        Me.lblPrekitCard.Text = "SIM Card SN"
        Me.lblPrekitCard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblprekitInsert
        '
        Me.lblprekitInsert.BackColor = System.Drawing.Color.Transparent
        Me.lblprekitInsert.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblprekitInsert.ForeColor = System.Drawing.Color.Black
        Me.lblprekitInsert.Location = New System.Drawing.Point(32, 96)
        Me.lblprekitInsert.Name = "lblprekitInsert"
        Me.lblprekitInsert.Size = New System.Drawing.Size(120, 21)
        Me.lblprekitInsert.TabIndex = 169
        Me.lblprekitInsert.Text = "Insert Part No"
        Me.lblprekitInsert.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabSetPrinter
        '
        Me.tabSetPrinter.BackColor = System.Drawing.Color.AliceBlue
        Me.tabSetPrinter.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label3, Me.btnRefreshPrinterData, Me.lblCurrentSetting, Me.Label5, Me.btnSaveLabelPrinterSetup, Me.tdgLabelPrinter, Me.cboPrinters})
        Me.tabSetPrinter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabSetPrinter.Location = New System.Drawing.Point(4, 22)
        Me.tabSetPrinter.Name = "tabSetPrinter"
        Me.tabSetPrinter.Size = New System.Drawing.Size(1120, 510)
        Me.tabSetPrinter.TabIndex = 2
        Me.tabSetPrinter.Text = "Set Printer"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.Location = New System.Drawing.Point(8, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 24)
        Me.Label3.TabIndex = 104
        Me.Label3.Text = "Set Label Printer"
        '
        'lblCurrentSetting
        '
        Me.lblCurrentSetting.AutoSize = True
        Me.lblCurrentSetting.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentSetting.Location = New System.Drawing.Point(8, 96)
        Me.lblCurrentSetting.Name = "lblCurrentSetting"
        Me.lblCurrentSetting.Size = New System.Drawing.Size(99, 15)
        Me.lblCurrentSetting.TabIndex = 101
        Me.lblCurrentSetting.Text = "Current Setting:"
        Me.lblCurrentSetting.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(32, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 23)
        Me.Label5.TabIndex = 100
        Me.Label5.Text = "Printers:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnSaveLabelPrinterSetup
        '
        Me.btnSaveLabelPrinterSetup.BackColor = System.Drawing.Color.LightGray
        Me.btnSaveLabelPrinterSetup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveLabelPrinterSetup.Location = New System.Drawing.Point(648, 64)
        Me.btnSaveLabelPrinterSetup.Name = "btnSaveLabelPrinterSetup"
        Me.btnSaveLabelPrinterSetup.Size = New System.Drawing.Size(112, 56)
        Me.btnSaveLabelPrinterSetup.TabIndex = 99
        Me.btnSaveLabelPrinterSetup.Text = "Save"
        '
        'tdgLabelPrinter
        '
        Me.tdgLabelPrinter.AlternatingRows = True
        Me.tdgLabelPrinter.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left)
        Me.tdgLabelPrinter.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tdgLabelPrinter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tdgLabelPrinter.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdgLabelPrinter.Images.Add(CType(resources.GetObject("resource.Images6"), System.Drawing.Bitmap))
        Me.tdgLabelPrinter.Location = New System.Drawing.Point(120, 96)
        Me.tdgLabelPrinter.Name = "tdgLabelPrinter"
        Me.tdgLabelPrinter.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdgLabelPrinter.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdgLabelPrinter.PreviewInfo.ZoomFactor = 75
        Me.tdgLabelPrinter.Size = New System.Drawing.Size(512, 216)
        Me.tdgLabelPrinter.TabIndex = 4
        Me.tdgLabelPrinter.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Caption{AlignHorz:Center;}Normal{Font:Microsoft Sans Serif, 8.25pt;Back" & _
        "Color:SteelBlue;}Selected{ForeColor:HighlightText;BackColor:Highlight;}Editor{}S" & _
        "tyle18{}Style19{}Style14{}Style15{}Style16{}Style17{}Style10{AlignHorz:Near;}Sty" & _
        "le11{}OddRow{BackColor:Lavender;}Style13{}Style12{}HighlightRow{ForeColor:Highli" & _
        "ghtText;BackColor:Highlight;}RecordSelector{AlignImage:Center;}Footer{}Style21{}" & _
        "Style20{}Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}EvenR" & _
        "ow{BackColor:AntiqueWhite;}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1, " & _
        "1, 1, 1;ForeColor:ControlText;BackColor:Control;}FilterBar{Font:Microsoft Sans S" & _
        "erif, 9.75pt, style=Bold;ForeColor:Red;BackColor:White;}Style4{}Style9{}Style8{}" & _
        "Style5{}Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}St" & _
        "yle7{}Style6{}Style1{}Style3{}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGr" & _
        "id.MergeView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaption" & _
        "Height=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelect" & _
        "orWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""" & _
        "1""><Height>216</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle" & _
        " parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><Fil" & _
        "terBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""S" & _
        "tyle3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading" & _
        """ me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><Inactive" & _
        "Style parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /" & _
        "><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle pare" & _
        "nt=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, " & _
        "0, 512, 216</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderSty" & _
        "le></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""No" & _
        "rmal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer" & _
        """ /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive""" & _
        " /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><" & _
        "Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" />" & _
        "<Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector""" & _
        " /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" />" & _
        "</NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</" & _
        "Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 512, 216</Cl" & _
        "ientArea><PrintPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle pa" & _
        "rent="""" me=""Style21"" /></Blob>"
        '
        'cboPrinters
        '
        Me.cboPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPrinters.Location = New System.Drawing.Point(112, 64)
        Me.cboPrinters.Name = "cboPrinters"
        Me.cboPrinters.Size = New System.Drawing.Size(528, 24)
        Me.cboPrinters.TabIndex = 2
        '
        'frmSIMOrderFulfillment
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(1144, 550)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1})
        Me.Name = "frmSIMOrderFulfillment"
        Me.Text = "frmSIMOrderFulfillment"
        Me.pnlFillShip.ResumeLayout(False)
        CType(Me.tdgProductDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCloseOrder.ResumeLayout(False)
        CType(Me.cboShipCarrier, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbShipmentInfo.ResumeLayout(False)
        Me.pnlUnused.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.tabOrder.ResumeLayout(False)
        CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPrekit.ResumeLayout(False)
        CType(Me.cboPrekitInsertPN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdgData2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabSetPrinter.ResumeLayout(False)
        CType(Me.tdgLabelPrinter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Form Load"
    Private Sub frmSIMOrderFulfillment_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As DataTable

        Try
            PSS.Core.Highlight.SetHighLight(Me)
            TabControl1.DrawMode = TabDrawMode.OwnerDrawFixed

            Me.lblCurrentSetting.Visible = False
            Me.tdgData1.Visible = False
            Me.chkBySN.Checked = True
            Me.chkByOrderNo.Checked = False

            'Populate customer
            dt = Generic.GetCustomers(True, )
            Misc.PopulateC1DropDownList(Me.cboCustomer, dt, "Cust_Name1", "Cust_ID")
            Me.cboCustomer.SelectedValue = Me._iMenuCustID
            If Me.cboCustomer.SelectedValue > 0 Then Me.cboCustomer.Enabled = False

            'Populate Shipment Carrier
            dt = Generic.GetShipCarriers
            dt.LoadDataRow(New Object() {"0", "--Select--"}, True)
            Misc.PopulateC1DropDownList(Me.cboShipCarrier, dt, "SC_Desc", "SC_ID")
            Me.cboShipCarrier.SelectedValue = Me._iCarrierID
            If Me.cboShipCarrier.SelectedValue > 0 Then Me.cboShipCarrier.Enabled = False

            'Bind TN open order data
            GetOpenOrderData()

			'Me.btnCloseOrder.Enabled = False
			pnlCloseOrder.Enabled = False
            Me.txtSIMCardSN.SelectAll() : Me.txtSIMCardSN.Focus()

            Me.tdgData2.Visible = False
            Me.pnlUnused.Visible = False
            Me.cboShipCarrier.Visible = False

            Me.cboPrekitInsertPN.Top = Me.txtPrekitInsertPN.Top
            Me.cboPrekitInsertPN.Left = Me.txtPrekitInsertPN.Left
            Me.cboPrekitInsertPN.Visible = False

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Generic.DisposeDT(dt)
        End Try
    End Sub
#End Region

#Region "Order"
    Private Sub GetOpenOrderData()
        Dim dt As DataTable
        Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn

        Try
            Cursor.Current = Cursors.WaitCursor

            Me.ResetAndClear()

            dt = Me._objTN.GetTNOpenOrder(Me._iMenuCustID, Me._UserID)

            With Me.tdgData1
                .DataSource = dt.DefaultView

                For Each dbgc In .Splits(0).DisplayColumns
                    dbgc.Locked = True
                    dbgc.AutoSize()
                Next dbgc

                .Splits(0).DisplayColumns("Sku").Width = 80
                .Splits(0).DisplayColumns("Sku_Part_Nr").Width = 80
                .Splits(0).DisplayColumns("Sku Type").Width = 80
                .Splits(0).DisplayColumns("Insert PN").Width = 80

                'Col 0 width
                .Splits(0).DisplayColumns("OutboundTrackingNumber").Width = 0
                .Splits(0).DisplayColumns("TransactionDatetime").Width = 0
                .Splits(0).DisplayColumns("TransactionID").Width = 0
                .Splits(0).DisplayColumns("SOHeaderID").Width = 0
                '.Splits(0).DisplayColumns("SODetailsID").Width = 0
                .Splits(0).DisplayColumns("WO_ID").Width = 0
                .Splits(0).DisplayColumns("Co_ID").Width = 0
                '.Splits(0).DisplayColumns("coi_id").Width = 0
                .Splits(0).DisplayColumns("Sku_ID").Width = 0
                .Splits(0).DisplayColumns("sku_type_decode_id").Width = 0
                .Splits(0).DisplayColumns("sku_insert_decode_id").Width = 0

            End With

            Me.lblOrderCount.Text = dt.Rows.Count
            Me.tdgData1.Visible = True

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "GetOpenOrderData", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor.Current = Cursors.Default
            Generic.DisposeDT(dt)
        End Try
    End Sub

    Private Sub BindCurrentSelectedOrderProductDetailData()
        Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn

        Try
            If Me._dtProductDetail.Rows.Count > 0 Then
                With Me.tdgProductDetails
                    .DataSource = Me._dtProductDetail.DefaultView

                    For Each dbgc In .Splits(0).DisplayColumns
                        dbgc.Locked = True
                        dbgc.AutoSize()
                    Next dbgc
                    .Splits(0).DisplayColumns("SoDetailsID").Width = 0
                    .Splits(0).DisplayColumns("Sku_ID").Width = 0
                    .Splits(0).DisplayColumns("LineItemNumber").Width = 0
                    .Splits(0).DisplayColumns("sku_type_decode_id").Width = 0
                    .Splits(0).DisplayColumns("sku_insert_decode_id").Width = 0
                End With
            Else
                MessageBox.Show("No order product detail data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "BindCurrentSelectedOrderProductDetailData", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Function OrderDataValidation() As Boolean
        Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
        Dim iRow As Integer = 0
        Dim strS As String = ""
        Dim dtProductDetail As DataTable
        Dim ArrLstSku As New ArrayList()
        Dim row As DataRow

        Try
            If Not Me._dtProductDetail.Rows.Count > 0 Then
                MessageBox.Show("No product detail data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            End If

            With Me.tdgData1
                For Each iRow In .SelectedRows 'should be one row
                    If IsDBNull(.Columns("Order No").CellText(iRow)) OrElse .Columns("Order No").CellText(iRow).ToString.Trim.Length = 0 Then
                        MessageBox.Show("No order number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return False
                    ElseIf IsDBNull(.Columns("Order Date").CellText(iRow)) OrElse .Columns("Order Date").CellText(iRow).ToString.Trim.Length = 0 Then
                        MessageBox.Show("The order has no Order Date.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return False
                    ElseIf IsDBNull(.Columns("Sku").CellText(iRow)) OrElse .Columns("Sku").CellText(iRow).ToString.Trim.Length = 0 Then
                        MessageBox.Show("The order has no Sku.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return False
                    ElseIf .Columns("Sku").CellText(iRow).ToString.Trim.Length > 0 Then
                        For Each row In Me._dtProductDetail.Rows
                            If Not Me._objTN.FoundSku(row("Sku")) Then
                                MessageBox.Show("Can't find this Sku '" & row("Sku") & "' in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Return False
                            End If
                        Next
                    End If

                    If IsDBNull(.Columns("Qty").CellText(iRow)) OrElse .Columns("Qty").CellText(iRow).ToString.Trim.Length = 0 Then
                        MessageBox.Show("The order has no Qty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return False
                    ElseIf .Columns("Qty").CellText(iRow).ToString.Trim.Length > 0 Then
                        Try
                            'Check total
                            Dim Val As Integer = Convert.ToInt16(.Columns("Qty").CellText(iRow).ToString)
                            Dim iTotalQty As Integer = Me._dtProductDetail.Compute("Sum([Order Qty])", String.Empty)
                            If Val <> iTotalQty Then
                                MessageBox.Show("Order qty <> product detail item qty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Return False
                            End If
                            'check if 0 for order qty of item
                            For Each row In Me._dtProductDetail.Rows
                                If row.IsNull("Order Qty") OrElse Not Int(row("Order Qty")) > 0 Then
                                    MessageBox.Show("No order qty for this item '" & row("Sku") & "' in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                    Return False
                                End If
                            Next
                        Catch ex As Exception
                            MessageBox.Show("Order qty <> product detail item qty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Return False
                        End Try
                    End If

                    If IsDBNull(.Columns("Name").CellText(iRow)) OrElse .Columns("Name").CellText(iRow).ToString.Trim.Length = 0 Then
                        MessageBox.Show("The order has no Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return False
                    ElseIf (IsDBNull(.Columns("Address 1").CellText(iRow)) OrElse .Columns("Address 1").CellText(iRow).ToString.Trim.Length = 0) _
                           AndAlso (IsDBNull(.Columns("Address 2").CellText(iRow)) OrElse .Columns("Address 2").CellText(iRow).ToString.Trim.Length = 0) Then
                        MessageBox.Show("The order has no Address.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return False
                    ElseIf IsDBNull(.Columns("City").CellText(iRow)) OrElse .Columns("City").CellText(iRow).ToString.Trim.Length = 0 Then
                        MessageBox.Show("The order has no City.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return False
                    ElseIf IsDBNull(.Columns("Insert PN").CellText(iRow)) OrElse .Columns("Insert PN").CellText(iRow).ToString.Trim.Length = 0 Then
                        MessageBox.Show("No Insert PN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return False
                    ElseIf IsDBNull(.Columns("Sku Type").CellText(iRow)) OrElse .Columns("Sku Type").CellText(iRow).ToString.Trim.Length = 0 Then
                        MessageBox.Show("No Sku Type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return False
                    ElseIf Not IsDBNull(.Columns("OutboundTrackingNumber").CellText(iRow)) AndAlso .Columns("OutboundTrackingNumber").CellText(iRow).ToString.Trim.Length > 0 Then
                        strS = "This order '" & .Columns("Order No").CellText(iRow).ToString & _
                               "' has a tracking number '" & .Columns("OutboundTrackingNumber").CellText(iRow).ToString.Trim & "'" & _
                               " which was created by " & .Columns("TransactionDatetime").CellText(iRow).ToString & ". See IT."
                        MessageBox.Show(strS, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return False
                    End If
                    Exit For
                Next
            End With

            Return True

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "PopulateSelectOrderToFill", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function OrderDataValidation_OldWay() As Boolean
        Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
        Dim iRow As Integer = 0
        Dim strS As String = ""

        Try
            With Me.tdgData1
                For Each iRow In .SelectedRows
                    If IsDBNull(.Columns("Order No").CellText(iRow)) OrElse .Columns("Order No").CellText(iRow).ToString.Trim.Length = 0 Then
                        MessageBox.Show("No order number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return False
                    ElseIf IsDBNull(.Columns("Order Date").CellText(iRow)) OrElse .Columns("Order Date").CellText(iRow).ToString.Trim.Length = 0 Then
                        MessageBox.Show("The order has no Order Date.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return False
                    ElseIf IsDBNull(.Columns("Sku").CellText(iRow)) OrElse .Columns("Sku").CellText(iRow).ToString.Trim.Length = 0 Then
                        MessageBox.Show("The order has no Sku.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return False
                    ElseIf .Columns("Sku").CellText(iRow).ToString.Trim.Length > 0 Then
                        Try
                            Dim Val As Integer = Convert.ToInt16(.Columns("Sku_ID").CellText(iRow).ToString)
                            If Not Val > 0 Then
                                MessageBox.Show("Can't find Sku '" & .Columns("Sku").CellText(iRow).ToString & "' in DB system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Return False
                            End If
                        Catch ex As Exception
                            MessageBox.Show("Can't find Sku '" & .Columns("Sku").CellText(iRow).ToString & "' in DB system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Return False
                        End Try
                    End If

                    If IsDBNull(.Columns("Qty").CellText(iRow)) OrElse .Columns("Qty").CellText(iRow).ToString.Trim.Length = 0 Then
                        MessageBox.Show("The order has no Qty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return False
                    ElseIf .Columns("Qty").CellText(iRow).ToString.Trim.Length > 0 Then
                        Try
                            Dim Val As Integer = Convert.ToInt16(.Columns("Qty").CellText(iRow).ToString)
                            If Val <> 1 Then
                                MessageBox.Show("Order Qty must equal to 1.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Return False
                            End If
                        Catch ex As Exception
                            MessageBox.Show("Order Qty must equal to 1.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Return False
                        End Try
                    End If

                    If IsDBNull(.Columns("Name").CellText(iRow)) OrElse .Columns("Name").CellText(iRow).ToString.Trim.Length = 0 Then
                        MessageBox.Show("The order has no Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return False
                    ElseIf (IsDBNull(.Columns("Address 1").CellText(iRow)) OrElse .Columns("Address 1").CellText(iRow).ToString.Trim.Length = 0) _
                           AndAlso (IsDBNull(.Columns("Address 2").CellText(iRow)) OrElse .Columns("Address 2").CellText(iRow).ToString.Trim.Length = 0) Then
                        MessageBox.Show("The order has no Address.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return False
                    ElseIf IsDBNull(.Columns("City").CellText(iRow)) OrElse .Columns("City").CellText(iRow).ToString.Trim.Length = 0 Then
                        MessageBox.Show("The order has no City.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return False
                    ElseIf IsDBNull(.Columns("Insert PN").CellText(iRow)) OrElse .Columns("Insert PN").CellText(iRow).ToString.Trim.Length = 0 Then
                        MessageBox.Show("No Insert PN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return False
                    ElseIf IsDBNull(.Columns("Sku Type").CellText(iRow)) OrElse .Columns("Sku Type").CellText(iRow).ToString.Trim.Length = 0 Then
                        MessageBox.Show("No Sku Type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return False
                    ElseIf Not IsDBNull(.Columns("OutboundTrackingNumber").CellText(iRow)) AndAlso .Columns("OutboundTrackingNumber").CellText(iRow).ToString.Trim.Length > 0 Then
                        strS = "This order '" & .Columns("Order No").CellText(iRow).ToString & _
                               "' has a tracking number '" & .Columns("OutboundTrackingNumber").CellText(iRow).ToString.Trim & "'" & _
                               " which was created by " & .Columns("TransactionDatetime").CellText(iRow).ToString & "."
                        MessageBox.Show(strS, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return False
                    End If

                    Exit For
                Next
            End With

            Return True

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "PopulateSelectOrderToFill", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub PopulateSelectedOrderToFill()
        Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
        Dim iRow As Integer = 0
        Dim strS As String = ""

        Try

            Me._dtProductDetail = Nothing

            'Validate data TN Clancellation request
            With Me.tdgData1
                For Each iRow In .SelectedRows 'must be one row
                    'Get product detail data
                    Me._dtProductDetail = Me._objTN.GetProductDetailData(Me._iMenuCustID, .Columns("SoHeaderID").CellText(iRow))

                    If Me._objTN.IsOrderCancelledByTextNow(.Columns("SoHeaderID").CellText(iRow)) Then
                        MessageBox.Show("TextNow requests to cancel this order '" & .Columns("Order No").CellText(iRow) & "'. Don't fill it.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        GetOpenOrderData()
                        Exit Sub
                    End If
                    Exit For
                Next
            End With

            'More validations
            If Not OrderDataValidation() Then Exit Sub

            With Me.tdgData1
                For Each iRow In .SelectedRows
                    Me.txtOrderNo.Text = .Columns("Order No").CellText(iRow)
                    Me.txtOrderRevDT.Text = .Columns("Order Date").CellText(iRow)
                    Me.txtOrderQty.Text = .Columns("Qty").CellText(iRow)

                    Me.txtName.Text = .Columns("Name").CellText(iRow)
                    Me.txtAddress1.Text = .Columns("Address 1").CellText(iRow)
                    Me.txtAddress2.Text = .Columns("Address 2").CellText(iRow)
                    Me.txtCity.Text = .Columns("City").CellText(iRow)
                    Me.txtZipCode.Text = .Columns("Zip Code").CellText(iRow)
                    Me.txtState.Text = .Columns("State").CellText(iRow)
                    Me.txtCoutry.Text = .Columns("Country").CellText(iRow)

                    Me._iOrder_SOHeaderID = .Columns("SoHeaderID").CellText(iRow)
                    Me._iOrder_WO_ID = .Columns("WO_ID").CellText(iRow)

                    BindCurrentSelectedOrderProductDetailData()

                    Me.txtSIMCardSN.SelectAll() : Me.txtSIMCardSN.Focus()

                    Me.btnSelectWO.Enabled = False
                    Me.tdgData1.Enabled = False
                    Me.btnRefresh.Enabled = False
                    Me.btnReject.Enabled = False
                    Me.btnGetLockOrders.Enabled = False
                    Me.btnUnlockOrder.Enabled = False

                    'send order no to clipboard
                    System.Windows.Forms.Clipboard.SetDataObject(Me.txtOrderNo.Text, False)
                    Exit For
                Next
            End With



        Catch ex As Exception
            MessageBox.Show(ex.ToString, "PopulateSelectOrderToFill", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Finally
            '    Generic.DisposeDT(dt)
        End Try
    End Sub

    Private Sub btnChangeAddress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeAddress.Click

        Try
            If (Me.txtOrderQty.Text = 0 AndAlso Me.txtShipQty.Text = 0) OrElse Me.txtOrderNo.Text.Trim.Length = 0 Then
                Exit Sub
            End If

            Dim fm As New frmChangeAddress(Me._iMenuCustID, Me._iOrder_SOHeaderID)
            fm.ShipFullName = Me.txtName.Text.Trim
            fm.Address1 = Me.txtAddress1.Text.Trim
            fm.Address2 = Me.txtAddress2.Text.Trim
            fm.City = Me.txtCity.Text.Trim
            fm.State = Me.txtState.Text.Trim
            fm.ZipCode = Me.txtZipCode.Text.Trim
            fm.Country = Me.txtCoutry.Text.Trim

            fm.ShowDialog()

            If fm.IsAddressInfoChanged Then
                Me.txtName.Text = fm.ShipFullName
                Me.txtAddress1.Text = fm.Address1
                Me.txtAddress2.Text = fm.Address2
                Me.txtCity.Text = fm.City
                Me.txtState.Text = fm.State
                Me.txtZipCode.Text = fm.ZipCode
                Me.txtCoutry.Text = fm.Country
            End If
            fm.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Sub btnChangeAddress_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub PopulateSelectedOrderToFill_OldWay()
        Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
        Dim iRow As Integer = 0
        Dim strS As String = ""

        Try

            'Validate data
            With Me.tdgData1
                For Each iRow In .SelectedRows 'must be one row
                    If Me._objTN.IsOrderCancelledByTextNow(.Columns("SoHeaderID").CellText(iRow)) Then
                        MessageBox.Show("TextNow requests to cancel this order '" & .Columns("Order No").CellText(iRow) & "'. Don't fill it.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        GetOpenOrderData()
                        Exit Sub
                    End If
                    Exit For
                Next
            End With

            If Not OrderDataValidation() Then Exit Sub

            With Me.tdgData1
                For Each iRow In .SelectedRows
                    Me.txtOrderNo.Text = .Columns("Order No").CellText(iRow)
                    Me.txtOrderRevDT.Text = .Columns("Order Date").CellText(iRow)
                    Me.txtSku.Text = .Columns("Sku").CellText(iRow)
                    Me.txtOrderQty.Text = .Columns("Qty").CellText(iRow)
                    Me.txtShipQty.Text = .Columns("Qty").CellText(iRow)
                    Me.txtName.Text = .Columns("Name").CellText(iRow)
                    Me.txtAddress1.Text = .Columns("Address 1").CellText(iRow)
                    Me.txtAddress2.Text = .Columns("Address 2").CellText(iRow)
                    Me.txtCity.Text = .Columns("City").CellText(iRow)
                    Me.txtZipCode.Text = .Columns("Zip Code").CellText(iRow)
                    Me.txtState.Text = .Columns("State").CellText(iRow)
                    Me.txtCoutry.Text = .Columns("Country").CellText(iRow)

                    Me.lblSkuDesc.Text = .Columns("sku_part_nr").CellText(iRow)
                    Me.lblInsertPN.Text = "(" & .Columns("Insert PN").CellText(iRow) & ")"
                    Me.lblSkuType.Text = "(" & .Columns("Sku Type").CellText(iRow) & ")"

                    Me._strInsertPN = .Columns("Insert PN").CellText(iRow)
                    Me._iOrder_Sku_ID = .Columns("Sku_ID").CellText(iRow)
                    Me._iOrder_kuType_DcodeID = .Columns("sku_type_decode_id").CellText(iRow)
                    Me._iOrder_InsertPN_DcodeID = .Columns("sku_insert_decode_id").CellText(iRow)
                    Me._iOrder_SOHeaderID = .Columns("SoHeaderID").CellText(iRow)
                    Me._iOrder_SODetailsID = .Columns("SoDetailsID").CellText(iRow)
                    Me._iOrder_WO_ID = .Columns("WO_ID").CellText(iRow)

                    Me.txtSIMCardSN.SelectAll() : Me.txtSIMCardSN.Focus()

                    Me.btnSelectWO.Enabled = False
                    Me.tdgData1.Enabled = False
                    Me.btnRefresh.Enabled = False
                    Me.btnReject.Enabled = False

                    'send order no to clipboard
                    System.Windows.Forms.Clipboard.SetDataObject(Me.txtOrderNo.Text, False)
                    Exit For
                Next
            End With



        Catch ex As Exception
            MessageBox.Show(ex.ToString, "PopulateSelectOrderToFill", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Finally
            '    Generic.DisposeDT(dt)
        End Try
    End Sub

    Private Sub btnSelectWO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectWO.Click
        PopulateSelectedOrderToFill()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        GetOpenOrderData()
    End Sub

    Private Sub tdgData1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdgData1.DoubleClick
        PopulateSelectedOrderToFill()
    End Sub

    Private Sub btnCopyAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCopyAll.Click
        Try
            Misc.CopyAllData(Me.tdgData1)
        Catch ex As Exception
            MessageBox.Show(ex.ToString, " btnCopyAll_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtSIMCardSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSIMCardSN.KeyUp
        Try
            If e.KeyCode = Keys.Enter AndAlso Me.txtSIMCardSN.Text.Trim.Length > 0 _
               AndAlso Me.tdgData1.Enabled = False AndAlso Me._dtProductDetail.Rows.Count > 0 Then
                ''Me.btnCloseOrder.Enabled = False
                'pnlCloseOrder.Enabled = False
                'If Me.ProcessOrderSN(Me.txtSIMCardSN.Text) Then
                '    Me.txtSIMCardSN.Enabled = False
                '    If Me._bIsPrekit Then
                '        Me.txtInsertPartNo.Enabled = False
                '        'Me.btnCloseOrder.Enabled = True
                '        pnlCloseOrder.Enabled = True
                '    Else
                '        Me.txtInsertPartNo.Text = ""
                '        Me.txtInsertPartNo.Enabled = True
                '        Me.txtInsertPartNo.SelectAll() : Me.txtInsertPartNo.Focus()
                '    End If
                'Else
                '    Me.txtSIMCardSN.SelectAll() : Me.txtSIMCardSN.Focus()
                'End If
                Me.ProcessOrderSN()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtSIMCardSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub txtInsertPartNo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtInsertPartNo.KeyUp
        Dim strSN As String = ""
        Dim dt As DataTable

        Try
            If e.KeyCode = Keys.Enter AndAlso Me.txtInsertPartNo.Text.Trim.Length > 0 AndAlso Me.txtSIMCardSN.Text.Trim.Length > 0 Then
                If Me.txtInsertPartNo.Text.Trim.ToUpper = Me._strInsertPN.Trim.ToUpper Then
                    'Me.btnCloseOrder.Enabled = True
                    pnlCloseOrder.Enabled = True
                Else
                    MessageBox.Show("No Insert Part Number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtInsertPartNo.SelectAll() : Me.txtInsertPartNo.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtInsertPartNo_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            dt = Nothing
        End Try
    End Sub

    Private Sub btnCloseOrderWithNtfctns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseOrderWithNtfctns.Click
        ' CLOSE AND SHIP ORDER THAT TRIGGERED ENDICIA NOTIFICATIONS.
        Try
            CloseAndShipOrder(True)
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnCloseOrder_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub btnCloseOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseOrder.Click
        ' CLOSE AND SHIP ORDER THAT DID NOT TRIGGERED ENDICIA NOTIFICATIONS.
        Try
            CloseAndShipOrder(False)
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnCloseOrder_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub CloseAndShipOrder(ByVal WithNotifications As Boolean)
        ' CLOSE AND SHIP THE ORDER.
        Dim strTrackingNo As String = ""
        Dim strMsg As String = ""
        Dim iIsPreKitted As Integer = 0
        Dim iBillCode_ID As Integer = 0
        Dim vFlatCharge As Single = 0.0
        Dim row As DataRow
        Dim strSN As String = ""
        Dim iException_Type_ID = 4169 'Endicia Notification in the lcodesdetail table, if WithNotifications=true

        Try
            'Check data valid
            If Not Me.txtOrderQty.Text = Me.txtShipQty.Text OrElse Not Me._dtFilledCardSN.Rows.Count = Me.txtOrderQty.Text Then
                MessageBox.Show("Order quantity has not been fulfiled. Can't close.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If Not Me._dtFilledCardSN.Rows.Count = Me._dtFilledInsertPN.Rows.Count Then
                MessageBox.Show("The card qty doesn't match the Insert qty. Can't close.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If Not Me._dtProductDetail.Rows.Count > 0 Then
                MessageBox.Show("No product detail data. Can't close.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            For Each row In Me._dtProductDetail.Rows
                If Not row("Order Qty") = row("Ship Qty") Then
                    MessageBox.Show("There is a discrepency between Order Qty and Ship Qty in the product detail data. Can't close.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Next

            'check TN cancellation request
            If Me._objTN.IsOrderCancelledByTextNow(Me._iOrder_SOHeaderID) Then
                strTrackingNo = Me._objTN.GetTackingNumber(Me._iOrder_SOHeaderID)
                strMsg = "TextNow requests to cancel this order '" & Me.txtOrderNo.Text & "'." & Environment.NewLine & "Don't fill it. The order will be cancelled after you click OK button."
                If strTrackingNo.Trim.Length > 0 Then
                    strMsg &= Environment.NewLine & "You need to cancel the shipment (tracking number is " & strTrackingNo.Trim & ") in Endicia."
                End If
                MessageBox.Show(strMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.ResetAndClear()
                Me.GetOpenOrderData()
                Exit Sub
            End If

            'Check shipment tracking number
            If Me.txtTrackingNo.Text.Trim.Length = 0 Then
                strTrackingNo = Me._objTN.GetTackingNumber(Me._iOrder_SOHeaderID)
                If strTrackingNo.Trim.Length > 0 Then Me.txtTrackingNo.Text = strTrackingNo
            Else
                strTrackingNo = Me.txtTrackingNo.Text
            End If
            If strTrackingNo.Trim.Length = 0 Then
                MessageBox.Show("No tracking number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            'ship/close order---------------------------------------------------------------------------
            Dim dt As DataTable, i As Integer = 0
            'Do validation again
            For Each row In Me._dtFilledCardSN.Rows
                strSN = row("SN")
                If Not ValidatePrekitSIMCardData(strSN.Trim, dt, True) Then
                    MessageBox.Show("Invalid BillCode_ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                dt = Nothing
            Next
            'ready to ship /close now
            iIsPreKitted = 1 'only prekitted cards are filled, so it must be 1
            iBillCode_ID = Me._objTN.GetFlatChargeBillCodeID(Me._iMenuCustID, Me._objTN.Billcode_ID1, Me._objTN.Billcode_ID2)
            If Not iBillCode_ID > 0 Then
                MessageBox.Show("Invalid BillCode_ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            vFlatCharge = Me._objTN.GetFlatCharge(Me._iMenuCustID, iBillCode_ID)

            If Not WithNotifications Then iException_Type_ID = 0

            Dim _shipdate As DateTime = Date.Now
            i = Me._objTN.UpdateTNShipCloseOrder(iIsPreKitted, Me._iOrder_WO_ID, Me._iOrder_SOHeaderID, _
                iBillCode_ID, iException_Type_ID, vFlatCharge, _
                Me._UserID, Format(_shipdate, "yyyy-MM-dd HH:mmss"), Me.cboShipCarrier.Text, strTrackingNo, Me._dtFilledCardSN)

            If i < 6 Then
                MessageBox.Show("Failed to update some data. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Me.ResetAndClear()
            Me.GetOpenOrderData()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnCloseShip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseShip.Click
        Me.CloseAndShipOrder_NewWay()
    End Sub

    Private Sub CloseAndShipOrder_NewWay()
        ' CLOSE AND SHIP THE ORDER.
        Dim strTrackingNo As String = ""
        Dim strMsg As String = ""
        Dim iIsPreKitted As Integer = 0
        Dim iBillCode_ID As Integer = 0
        Dim vFlatCharge As Single = 0.0
        Dim row As DataRow
        Dim strSN As String = ""
        Dim iException_Type_ID = 4169 'Endicia Notification in the lcodesdetail table, if WithNotifications=true

        Dim strFromAddressInfo As String = ""
        Dim strToAddressInfo As String = ""

        Try
            'Check data valid
            If (Me.txtOrderQty.Text = 0 AndAlso Me.txtShipQty.Text = 0) OrElse Me.txtOrderNo.Text.Trim.Length = 0 Then
                MessageBox.Show("Nothing to fill.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If Not Me.txtOrderQty.Text = Me.txtShipQty.Text OrElse Not Me._dtFilledCardSN.Rows.Count = Me.txtOrderQty.Text Then
                MessageBox.Show("Order quantity has not been fulfiled. Can't close.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If Not Me._dtFilledCardSN.Rows.Count = Me._dtFilledInsertPN.Rows.Count Then
                MessageBox.Show("The card qty doesn't match the Insert qty. Can't close.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If Not Me._dtProductDetail.Rows.Count > 0 Then
                MessageBox.Show("No product detail data. Can't close.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            For Each row In Me._dtProductDetail.Rows
                If Not row("Order Qty") = row("Ship Qty") Then
                    MessageBox.Show("There is a discrepency between Order Qty and Ship Qty in the product detail data. Can't close.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Next

            'check TN cancellation request
            'If Me._objTN.IsOrderCancelledByTextNow(Me._iOrder_SOHeaderID) Then
            '    strTrackingNo = Me._objTN.GetTackingNumber(Me._iOrder_SOHeaderID)
            '    strMsg = "TextNow requests to cancel this order '" & Me.txtOrderNo.Text & "'." & Environment.NewLine & "Don't fill it. The order will be cancelled after you click OK button."
            '    If strTrackingNo.Trim.Length > 0 Then
            '        strMsg &= Environment.NewLine & "You need to cancel the shipment (tracking number is " & strTrackingNo.Trim & ") in Endicia."
            '    End If
            '    MessageBox.Show(strMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '    Me.ResetAndClear()
            '    Me.GetOpenOrderData()
            '    Exit Sub
            'End If

            ''Check shipment tracking number
            'If Me.txtTrackingNo.Text.Trim.Length = 0 Then
            '    strTrackingNo = Me._objTN.GetTackingNumber(Me._iOrder_SOHeaderID)
            '    If strTrackingNo.Trim.Length > 0 Then Me.txtTrackingNo.Text = strTrackingNo
            'Else
            '    strTrackingNo = Me.txtTrackingNo.Text
            'End If
            'If strTrackingNo.Trim.Length = 0 Then
            '    MessageBox.Show("No tracking number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '    Exit Sub
            'End If

            'ship/close order---------------------------------------------------------------------------
            Dim dt As DataTable, i As Integer = 0
            'Do validation again
            For Each row In Me._dtFilledCardSN.Rows
                strSN = row("SN")
                If Not ValidatePrekitSIMCardData(strSN.Trim, dt, True) Then
                    MessageBox.Show("Invalid BillCode_ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                dt = Nothing
            Next
            'ready to ship /close now
            iIsPreKitted = 1 'only prekitted cards are filled, so it must be 1
            iBillCode_ID = Me._objTN.GetFlatChargeBillCodeID(Me._iMenuCustID, Me._objTN.Billcode_ID1, Me._objTN.Billcode_ID2)
            If Not iBillCode_ID > 0 Then
                MessageBox.Show("Invalid BillCode_ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            vFlatCharge = Me._objTN.GetFlatCharge(Me._iMenuCustID, iBillCode_ID)

            'If Not WithNotifications Then iException_Type_ID = 0
            iException_Type_ID = 0

            Dim _shipdate As DateTime = Date.Now
            i = Me._objTN.UpdateTNShipCloseOrder(iIsPreKitted, Me._iOrder_WO_ID, Me._iOrder_SOHeaderID, _
                                                 iBillCode_ID, iException_Type_ID, vFlatCharge, _
                                                 Me._UserID, Format(_shipdate, "yyyy-MM-dd HH:mmss"), _
                                                 Me.cboShipCarrier.Text, strTrackingNo, Me._dtFilledCardSN)

            If i < 6 Then
                MessageBox.Show("Failed to update some data. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            'Print shipment label
            strFromAddressInfo = "TextNow" & Environment.NewLine
            strFromAddressInfo &= "511 South Royal Lane" & Environment.NewLine
            strFromAddressInfo &= "Coppell TX 75019"

            strToAddressInfo = ""
            strToAddressInfo = Me.txtName.Text.Trim & Environment.NewLine
            strToAddressInfo &= Me.txtAddress1.Text.Trim & " " & Me.txtAddress2.Text.Trim & Environment.NewLine
            strToAddressInfo &= Me.txtCity.Text.Trim & ", " & Me.txtState.Text.Trim & " " & Me.txtZipCode.Text.Trim

            strFromAddressInfo = strFromAddressInfo.Replace(Environment.NewLine, "\r\n")
            strToAddressInfo = strToAddressInfo.Replace(Environment.NewLine, "\r\n")

            'PRT_ID, WorkStation, Printer_Name, UserID, UpdatedDateTime
            Dim strPrinterName As String = "", dtPrinter As DataTable
            dtPrinter = Me._objTN.GetLabelPrinterSettingrData(Me._strComputerName)
            If dtPrinter.Rows.Count > 0 AndAlso Not dtPrinter.Rows(0).IsNull("Printer_Name") Then strPrinterName = Convert.ToString(dtPrinter.Rows(0).Item("Printer_Name")).Trim()
            Me._objTN.PrintTextNowShipmentLabel(strFromAddressInfo, strToAddressInfo, Me.txtOrderNo.Text.Trim, strPrinterName, 1)

            Me.ResetAndClear()
            Me.GetOpenOrderData()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CloseAndShipOrder_OldWay(ByVal WithNotifications As Boolean)
        ' CLOSE AND SHIP THE ORDER.
        Dim strTrackingNo As String = ""
        Dim strMsg As String = ""
        Dim iIsPreKitted As Integer = 0
        Dim iBillCode_ID As Integer = 0
        Dim vFlatCharge As Single = 0.0
        Try
            If Not Me.txtSIMCardSN.Text.Trim.Length > 0 AndAlso Not Me.txtInsertPartNo.Text.Trim.Length > 0 Then Exit Sub

            If Me._objTN.IsOrderCancelledByTextNow(Me._iOrder_SOHeaderID) Then
                strTrackingNo = Me._objTN.GetTackingNumber(Me._iOrder_SOHeaderID)
                strMsg = "TextNow requests to cancel this order '" & Me.txtOrderNo.Text & "'." & Environment.NewLine & "Don't fill it. The order will be cancelled after you click OK button."
                If strTrackingNo.Trim.Length > 0 Then
                    strMsg &= Environment.NewLine & "You need to cancel the shipment (tracking number is " & strTrackingNo.Trim & ") in Endicia."
                End If
                MessageBox.Show(strMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.ResetAndClear()
                Me.GetOpenOrderData()
                Exit Sub
            End If

            If Me.txtSIMCardSN.Text.Trim.Length > 0 AndAlso Not Me.txtInsertPartNo.Text.Trim.Length > 0 Then
                MessageBox.Show("No Insert Part Number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtInsertPartNo.Enabled = True
                Me.txtInsertPartNo.SelectAll() : Me.txtInsertPartNo.Focus()
            ElseIf Not Me.txtSIMCardSN.Text.Trim.Length > 0 AndAlso Me.txtInsertPartNo.Text.Trim.Length > 0 Then
                MessageBox.Show("No SIM Card SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtSIMCardSN.Enabled = True
                Me.txtSIMCardSN.SelectAll() : Me.txtSIMCardSN.Focus()
            ElseIf Me.txtSIMCardSN.Text.Trim.Length > 0 AndAlso Me.txtInsertPartNo.Text.Trim.Length > 0 Then
                'tracking number
                If Me.txtTrackingNo.Text.Trim.Length = 0 Then
                    strTrackingNo = Me._objTN.GetTackingNumber(Me._iOrder_SOHeaderID)
                    If strTrackingNo.Trim.Length > 0 Then Me.txtTrackingNo.Text = strTrackingNo
                Else
                    strTrackingNo = Me.txtTrackingNo.Text
                End If
                If strTrackingNo.Trim.Length = 0 Then
                    MessageBox.Show("No tracking number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                'ship/close order
                Dim dt As DataTable, i As Integer = 0
                If ValidatePrekitSIMCardData(Me.txtSIMCardSN.Text.Trim, dt, True) Then
                    If Trim(dt.Rows(0).Item("Insert PN")).ToUpper = Me.txtInsertPartNo.Text.Trim.ToUpper _
                       AndAlso Me.txtInsertPartNo.Text.Trim.ToUpper = Me._strInsertPN.Trim.ToUpper Then

                        If Me._bIsPrekit Then iIsPreKitted = 1
                        iBillCode_ID = Me._objTN.GetFlatChargeBillCodeID(Me._iMenuCustID, Me._objTN.Billcode_ID1, Me._objTN.Billcode_ID2)
                        If Not iBillCode_ID > 0 Then
                            MessageBox.Show("Invalid BillCode_ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        End If
                        vFlatCharge = Me._objTN.GetFlatCharge(Me._iMenuCustID, iBillCode_ID)


                        Dim _shipdate As DateTime = Date.Now
                        i = Me._objTN.UpdateTNShipCloseOrder_OldWay(iIsPreKitted, dt.Rows(0).Item("WI_ID"), _
                         dt.Rows(0).Item("Device_ID"), Me._iOrder_WO_ID, Me._iOrder_SOHeaderID, _
                          Me._iOrder_SODetailsID, Me._iOrder_InsertPN_DcodeID, iBillCode_ID, vFlatCharge, _
                          Me.txtShipQty.Text, Me._UserID, Format(_shipdate, "yyyy-MM-dd HH:mmss"), Me.cboShipCarrier.Text, strTrackingNo)

                        ' Update the edi.tcust_order table with the ship date and if it has an Endicia notification.
                        Dim _tcust_order As New Data.BOL.tcust_order(txtOrderNo.Text)
                        _tcust_order.date_ship = _shipdate
                        If WithNotifications Then
                            ' 4169 = Endicia Notification in the lcodesdetail table.
                            _tcust_order.exception_type_id = 4169
                        End If
                        _tcust_order.ApplyChanges()
                        _tcust_order = Nothing

                        ' 
                        If i < 6 Then
                            MessageBox.Show("Failed to update some data. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        End If
                        Me.ResetAndClear()
                        Me.GetOpenOrderData()
                    Else
                        MessageBox.Show("Invalid Insert Part Number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtInsertPartNo.Enabled = True
                        Me.txtInsertPartNo.SelectAll() : Me.txtInsertPartNo.Focus()
                    End If
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ProcessOrderSN()
        Dim strSN As String = ""
        Dim dt As DataTable
        Dim row As DataRow
        Dim rowNew As DataRow
        Dim i As Integer = 0
        Dim iSoDetail_ID As Integer = 0
        Dim iInsertDcode_ID As Integer = 0

        Try
            strSN = Me.txtSIMCardSN.Text.Trim

            If strSN.Trim.Length = 0 Then
                MessageBox.Show("Please enter SIM Card SN (ICCID).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf Me.txtOrderQty.Text = Me.txtShipQty.Text Then
                MessageBox.Show("Fulfilled the order. Can't add card.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf ValidatePrekitSIMCardData(strSN, dt, True, Me._bIsPrekit) Then
                'no ship, yes prekit completed, then ready to Insert PN
                If Me._bIsPrekit Then
                    If CanFindMatchedOrderItem(dt.Rows(0).Item("Sku_ID"), dt.Rows(0).Item("Insert_decode_ID"), iSoDetail_ID) Then
                        If iSoDetail_ID > 0 Then
                            ' Check if the Device is already scanned in
                            For Each row In Me._dtFilledCardSN.Rows
                                If Trim(row("SN")).ToUpper = strSN.Trim.ToUpper Then
                                    MsgBox("This device is already scanned in. Try another one.", MsgBoxStyle.Information, "Device Scan")
                                    Me.txtSIMCardSN.Text = "" : Me.txtSIMCardSN.Focus()
                                    Exit Sub
                                End If
                            Next
                            If Me.IsIndividualOrderQtyFulfilled(iSoDetail_ID) Then
                                MessageBox.Show("Order qty is fulfilled for this type of SIM card.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            ElseIf Me.UpdateProductDetailQty(iSoDetail_ID, 1) Then 'ready
                                'Card data
                                rowNew = Me._dtFilledCardSN.NewRow
                                rowNew("Device_ID") = dt.Rows(0).Item("Device_ID")
                                rowNew("SN") = dt.Rows(0).Item("SN")
                                rowNew("Sku_ID") = dt.Rows(0).Item("Sku_ID")
                                rowNew("WI_ID") = dt.Rows(0).Item("WI_ID")
                                rowNew("SODetailsID") = iSoDetail_ID
                                Me._dtFilledCardSN.Rows.Add(rowNew)
                                'Insert PN data
                                rowNew = Me._dtFilledInsertPN.NewRow
                                rowNew("Insert_decode_ID") = dt.Rows(0).Item("Insert_decode_ID")
                                rowNew("Insert PN") = dt.Rows(0).Item("Insert PN")
                                rowNew("sku_part_nr") = dt.Rows(0).Item("sku_part_nr")
                                rowNew("Insert_Desc") = dt.Rows(0).Item("sku_part_nr") & " (" & dt.Rows(0).Item("Insert PN") & ")"
                                Me._dtFilledInsertPN.Rows.Add(rowNew)

                                'Bind data
                                Me.lstICCID.DataSource = Nothing : Me.lstInsert.DataSource = Nothing
                                Me.lstICCID.DataSource = Me._dtFilledCardSN.DefaultView
                                Me.lstInsert.DataSource = Me._dtFilledInsertPN.DefaultView

                                Me.lstICCID.ValueMember = "Device_ID" ' Me._dtFilledCardSN.Rows(0).Item("Device_ID").ToString
                                Me.lstICCID.DisplayMember = "SN" 'Me._dtFilledCardSN.Rows(0).Item("SN").ToString

                                Me.lstInsert.ValueMember = "Insert_decode_ID" 'Me._dtFilledInsertPN.Rows(0).Item("Insert_decode_ID").ToString
                                Me.lstInsert.DisplayMember = "Insert_Desc" 'Me._dtFilledInsertPN.Rows(0).Item("Insert PN").ToString

                                Me.txtShipQty.Text = Me.txtShipQty.Text + 1
                                If Me.txtOrderQty.Text = Me.txtShipQty.Text Then pnlCloseOrder.Enabled = True
                                Me.txtSIMCardSN.Text = "" : Me.txtSIMCardSN.Focus()
                            Else
                                MessageBox.Show("Failed to find SoDetailID. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        Else
                            MessageBox.Show("Failed to find SoDetailID. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        MessageBox.Show("SIM card type mismatch!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("It is not a prekitted card.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, " ProcessPrekitSN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            dt = Nothing
            Me.txtSIMCardSN.SelectAll() : Me.txtSIMCardSN.Focus()
        End Try
    End Sub

    Private Function CanFindMatchedOrderItem(ByVal iSku_ID As Integer, ByVal iInsertPN_ID As Integer, ByRef iSoDetail_ID As Integer) As Boolean
        Dim bRes As Boolean = False
        Dim row As DataRow
        Try
            For Each row In Me._dtProductDetail.Rows
                If row("sku_ID") = iSku_ID AndAlso row("sku_insert_decode_id") = iInsertPN_ID Then
                    iSoDetail_ID = row("SoDetailsID") : bRes = True
                    Exit For
                End If
            Next
            Return bRes
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "FindMatchedOrderItem", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Function

    Private Function UpdateProductDetailQty(ByVal iSoDetail_ID As Integer, ByVal iValue As Integer) As Boolean
        Dim bRes As Boolean = False
        Dim row As DataRow
        Try
            For Each row In Me._dtProductDetail.Rows
                If row("SoDetailsID") = iSoDetail_ID AndAlso Not row("order Qty") = row("Ship Qty") Then
                    row.BeginEdit()
                    row("Ship Qty") = row("Ship Qty") + (iValue)
                    row.AcceptChanges()
                    bRes = True : Exit For
                ElseIf row("SoDetailsID") = iSoDetail_ID AndAlso iValue < 0 Then
                    row.BeginEdit()
                    row("Ship Qty") = row("Ship Qty") + (iValue)
                    row.AcceptChanges()
                    bRes = True : Exit For
                End If
            Next
            Return bRes
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "UpdateProductDetailQty", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Function

    Private Function IsIndividualOrderQtyFulfilled(ByVal iSoDetail_ID As Integer) As Boolean
        Dim bRes As Boolean = False
        Dim row As DataRow
        Try
            For Each row In Me._dtProductDetail.Rows
                If row("SoDetailsID") = iSoDetail_ID AndAlso row("order Qty") = row("Ship Qty") Then
                    bRes = True : Exit For
                End If
            Next
            Return bRes
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "IsIndividualOrderQtyFulfilled", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Function

    Private Function ProcessOrderSN_OldWay(ByVal strSN As String) As Boolean
        Dim dt As DataTable
        Dim drNewRow, R1 As DataRow
        Dim i As Integer = 0
        Dim strSku As String = ""
        Dim strSkuType As String = ""
        Dim strInsertDesc As String = ""

        Try

            If strSN.Trim.Length = 0 Then
                MessageBox.Show("Please SIM Card SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf ValidatePrekitSIMCardData(strSN, dt, True, Me._bIsPrekit) Then
                'no ship, no prekit completed, then ready to Insert PN
                strSku = dt.Rows(0).Item("Sku")
                strSkuType = dt.Rows(0).Item("Sku Type")
                If strSkuType.Trim.Length > 0 AndAlso strSku.Trim.Length > 0 Then
                    If strSku.Trim.ToUpper = Me.txtSku.Text.Trim.ToUpper Then
                        If Me._bIsPrekit Then
                            Me.txtInsertPartNo.Text = dt.Rows(0).Item("Insert PN")
                        End If
                        Return True
                    Else
                        MessageBox.Show("Sku doesn't match.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                Else
                    MessageBox.Show("No Sku info.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, " ProcessPrekitSN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            dt = Nothing
        End Try

        Return False

    End Function

    Private Sub btnUndoSIMSN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUndoSIMSN.Click
        Try
            Me.txtSIMCardSN.Text = "" : Me.txtSIMCardSN.Enabled = True
            Me.txtInsertPartNo.Text = "" : Me.txtInsertPartNo.Enabled = False
            Me.txtTrackingNo.Text = ""
            Me.txtSIMCardSN.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnUndoSIMSN_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Me.ResetAndClear()
    End Sub

    Private Sub btnGetTrackingNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetTrackingNo.Click
        Dim strTrackingNo As String = ""
        Try
            strTrackingNo = Me._objTN.GetTackingNumber(Me._iOrder_SOHeaderID)
            If strTrackingNo.Trim.Length > 0 Then Me.txtTrackingNo.Text = strTrackingNo
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnGetTrackingNo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub btnCopy2Clipboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy2Clipboard.Click
        Try
            'send order no to clipboard
            System.Windows.Forms.Clipboard.SetDataObject(Me.txtOrderNo.Text, False)
        Catch ex As Exception
            MessageBox.Show(ex.ToString, " btnCopy2Clipboard_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub btnReject_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReject.Click
        Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
        Dim iRow As Integer = 0
        Dim iSOHeaderID As Integer = 0
        Dim strOrder As String = ""
        Try
            With Me.tdgData1
                If Not .SelectedRows.Count = 1 Then
                    MessageBox.Show("Please select one order to reject.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                For Each iRow In .SelectedRows
                    strOrder = .Columns("Order No").CellText(iRow)
                    iSOHeaderID = .Columns("SoHeaderID").CellText(iRow)
                    Dim strPrompt As String = "Do you want to reject Order " & strOrder & "? "
                    If MessageBox.Show(strPrompt, "TextNow Order Rejection", MessageBoxButtons.YesNo, _
                     MessageBoxIcon.Question) = DialogResult.Yes Then
                        Me._objTN.UpdateRejectInvalidOrder(iSOHeaderID, "Order Rejected", Me._UserID, Format(Now, "yyyy-MM-dd HH:mm:ss"))
                        GetOpenOrderData()
                        MessageBox.Show("Order " & strOrder & " has been rejected.", "TextNow Order Rejection", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    Exit For
                Next
            End With
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnReject_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnReturnedOrder_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReturnedOrder.Click
        Try
            Dim fm As New frmOrderReturned(Me._iMenuCustID)

            fm.ShowDialog()
            'fm.Show()
            'If fm.ShowDialog() = Windows.Forms.DialogResult.Yes Then
            '    MessageBox.Show("Successfully updated!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            'End If
            ' fm.Close()
            fm.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnReturnedOrder_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ResetAndClear()
        Dim row As DataRow
        Try
            Me.btnSelectWO.Enabled = True
            Me.tdgData1.Enabled = True
            Me.btnRefresh.Enabled = True
            Me.btnReject.Enabled = True
            Me.btnGetLockOrders.Enabled = True
            Me.btnUnlockOrder.Enabled = True
            Me.txtOrderNo.Text = ""
            Me.txtAddress1.Text = ""
            Me.txtAddress2.Text = ""
            Me.txtName.Text = ""
            Me.txtCity.Text = ""
            Me.txtCoutry.Text = ""
            Me.txtState.Text = ""
            Me.txtZipCode.Text = ""
            Me.txtSIMCardSN.Text = ""
            Me.txtInsertPartNo.Text = ""
            Me.txtSku.Text = ""
            Me.txtOrderRevDT.Text = ""
            Me.txtOrderQty.Text = 0
            Me.txtShipQty.Text = 0
            Me.txtTrackingNo.Text = ""
            Me.lblSkuDesc.Text = ""
            Me.lblSkuType.Text = ""
            Me.lblInsertPN.Text = ""

            Me._iOrder_InsertPN_DcodeID = 0
            Me._iOrder_Sku_ID = 0
            Me._iOrder_kuType_DcodeID = 0
            Me._iOrder_SOHeaderID = 0
            Me._strInsertPN = ""
            Me._bIsPrekit = False
            Me._iOrder_SOHeaderID = 0
            Me._iOrder_SODetailsID = 0
            Me._iOrder_WO_ID = 0

            'Me.btnCloseOrder.Enabled = False
            pnlCloseOrder.Enabled = False

            'for new method
            'Me._dtFilledCardSN = Nothing : Me._dtFilledInsertPN = Nothing
            Me._dtFilledCardSN.Rows.Clear() : Me._dtFilledInsertPN.Rows.Clear()
            Me.lstICCID.DataSource = Nothing : Me.lstInsert.DataSource = Nothing
            Me.lstICCID.Items.Clear() : Me.lstInsert.Items.Clear()
            Me._dtProductDetail = Nothing : Me.tdgProductDetails.DataSource = Nothing

            Me.txtSIMCardSN.Enabled = True
            Me.txtInsertPartNo.Enabled = False
            Me.tdgData1.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "ResetAndClear", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub btnDelOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelOne.Click
        Dim message, title, defaultValue As String
        Dim strValue As String = ""
        Dim row As DataRow
        Dim iSODetails_ID As Integer = 0
        Dim i As Integer = 0

        Try
            If Me._dtFilledCardSN.Rows.Count > 0 AndAlso Me._dtFilledInsertPN.Rows.Count > 0 _
            AndAlso Me.lstICCID.Items.Count > 0 AndAlso Me.lstInsert.Items.Count > 0 Then
                message = "Enter a Card SN (ICCID):"
                title = "SIM Card"
                defaultValue = ""
                ' Display message, title, and default value.
                strValue = InputBox(message, title, defaultValue)

                If strValue.Trim.Length > 0 Then
                    For Each row In Me._dtFilledCardSN.Rows
                        If Trim(row("SN")) = strValue.Trim.ToUpper Then
                            iSODetails_ID = row("SoDetailsID")
                            row.Delete() : Me._dtFilledInsertPN.Rows(i).Delete()
                            Me.UpdateProductDetailQty(iSODetails_ID, -1)
                            Me.txtShipQty.Text = Me.txtShipQty.Text - 1
                            Me.pnlCloseOrder.Enabled = False
                            Exit Sub
                        End If
                        i += 1
                    Next
                    MessageBox.Show("Not found. Deleted nothing.", " btnDelOne_Click(", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnDelOne_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.txtSIMCardSN.SelectAll() : Me.txtSIMCardSN.Focus()
        End Try
    End Sub

    Private Sub btnDelAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelAll.Click

        Try
            If Me._dtFilledCardSN.Rows.Count > 0 AndAlso Me._dtFilledInsertPN.Rows.Count > 0 _
               AndAlso Me.lstICCID.Items.Count > 0 AndAlso Me.lstInsert.Items.Count > 0 Then
                Dim result As Integer = MessageBox.Show("Do you want to remve all SIM cards?", "Delete all SNs", MessageBoxButtons.YesNo)
                If result = DialogResult.Yes Then
                    Me._dtFilledCardSN.Rows.Clear() : Me._dtFilledInsertPN.Rows.Clear()
                    Me.lstICCID.DataSource = Nothing : Me.lstInsert.DataSource = Nothing
                    Me.lstICCID.Items.Clear() : Me.lstInsert.Items.Clear()
                    Dim row As DataRow
                    For Each row In Me._dtProductDetail.Rows
                        row("Ship Qty") = 0
                    Next
                    Me.txtShipQty.Text = 0
                    Me.pnlCloseOrder.Enabled = False
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnDelAll_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.txtSIMCardSN.SelectAll() : Me.txtSIMCardSN.Focus()
        End Try
    End Sub

    Private Sub lstICCID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstICCID.SelectedIndexChanged
        Try
            Me.lstInsert.SelectedIndex = Me.lstICCID.SelectedIndex
        Catch ex As Exception
        End Try
    End Sub

    Private Sub lstInsert_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstInsert.SelectedIndexChanged
        Try
            Me.lstICCID.SelectedIndex = Me.lstInsert.SelectedIndex
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnRePrintLabel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRePrintLabel.Click
        Dim dt As DataTable
        Dim strOrderNo As String = ""
        Dim strSN As String = ""
        Dim strFromAddressInfo As String = ""
        Dim strToAddressInfo As String = ""
        Dim row As DataRow

        Try
            If Not Me.chkByOrderNo.Checked AndAlso Not Me.chkBySN.Checked Then
                MessageBox.Show("Please select a checkbox.", "info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If Me.chkByOrderNo.Checked Then
                strOrderNo = InputBox("Enter an order number:", "Enter OrderNo", "")
            ElseIf Me.chkBySN.Checked Then
                strSN = InputBox("Enter SIM card SN:", "Enter SN", "")
                If strSN.Trim.Length > 0 Then
                    dt = Me._objTN.GetSaleOrderNumberBySN(Me._iMenuCustID, strSN)
                    If dt.Rows.Count > 1 Then
                        MessageBox.Show("Found duplicate data.", "info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    ElseIf dt.Rows.Count < 1 Then
                        MessageBox.Show("Can't find it.", "info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    Else '=1
                        strOrderNo = dt.Rows(0).Item("PoNumber")
                    End If
                Else
                    MessageBox.Show("You didn't enter SN.", "info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If

            Cursor.Current = Cursors.WaitCursor

            If strOrderNo.Trim.Length > 0 Then

                strFromAddressInfo = "TextNow" & Environment.NewLine
                strFromAddressInfo &= "511 South Royal Lane" & Environment.NewLine
                strFromAddressInfo &= "Coppell TX 75019"

                'Order No, Name, Address 1, Address 2, City, State, Zip Code, Country, Order Date, Ship Date, Operator, Tracking No, ShipCarrier, OrderReturned, InvalidOrder, WorkOrderID, OrderStatusID, SoHeaderID
                dt = Me._objTN.GetShippedBulkOrderHeaderData(Me._iMenuCustID, "", strOrderNo.Trim)
                If dt.Rows.Count = 1 Then
                    For Each row In dt.Rows
                        strToAddressInfo = ""
                        strToAddressInfo = row("Name") & Environment.NewLine
                        strToAddressInfo &= row("Address 1") & " " & row("Address 2") & Environment.NewLine
                        strToAddressInfo &= row("City") & ", " & row("State") & " " & row("Zip Code")

                        strFromAddressInfo = strFromAddressInfo.Replace(Environment.NewLine, "\r\n")
                        strToAddressInfo = strToAddressInfo.Replace(Environment.NewLine, "\r\n")
                    Next

                    'PRT_ID, WorkStation, Printer_Name, UserID, UpdatedDateTime
                    Dim strPrinterName As String = "", dtPrinter As DataTable
                    dtPrinter = Me._objTN.GetLabelPrinterSettingrData(Me._strComputerName)
                    If dtPrinter.Rows.Count > 0 AndAlso Not dtPrinter.Rows(0).IsNull("Printer_Name") Then strPrinterName = Convert.ToString(dtPrinter.Rows(0).Item("Printer_Name")).Trim()
                    Me._objTN.PrintTextNowShipmentLabel(strFromAddressInfo, strToAddressInfo, strOrderNo.Trim, strPrinterName, 1)
                ElseIf dt.Rows.Count > 1 Then
                    MessageBox.Show("Found duplicate data for this order '" & strOrderNo & "'.", "info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Can't find this order '" & strOrderNo & "'.", "info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnRePrintLabel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub btnRefreshPrinterData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshPrinterData.Click
        Try
            Dim printer As String = ""
            Me.cboPrinters.Items.Clear()
            For Each printer In System.Drawing.Printing.PrinterSettings.InstalledPrinters
                Me.cboPrinters.Items.Add(printer)
            Next printer

            Me.BindLabelPrinterData()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnRefreshPrinterData_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub btnSaveLabelPrinterSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveLabelPrinterSetup.Click
        Dim dt As DataTable
        Try
            If Me.cboPrinters.Text.Trim.Length > 0 Then
                Me._objTN.InsertUpdateLabelPrinterSettingrData(Me._strComputerName, Me.cboPrinters.Text.Trim, Me._UserID, Format(Now, "yyyy-MM-dd HH:mm:ss"))
                Me.BindLabelPrinterData()
            Else
                MessageBox.Show("Please select a printer.", " btnDelOne_Click", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnRefreshPrinterData_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub BindLabelPrinterData()
        Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
        Dim dtLabelPrinterData As DataTable

        'PRT_ID, WorkStation, Printer_Name, UserID, UpdatedDateTime

        Try
            Me.lblCurrentSetting.Visible = False
            Me.tdgData1.Visible = False

            dtLabelPrinterData = Me._objTN.GetLabelPrinterSettingrData(Me._strComputerName)

            Me.tdgLabelPrinter.DataSource = Nothing
            If dtLabelPrinterData.Rows.Count > 0 Then
                With Me.tdgLabelPrinter
                    .DataSource = dtLabelPrinterData.DefaultView
                    For Each dbgc In .Splits(0).DisplayColumns
                        'Select Case dbgc.Name
                        '    Case "Printer_Name"
                        '        dbgc.Locked = False
                        '    Case Else
                        dbgc.Locked = True
                        'End Select
                        Select Case dbgc.Name
                            Case "Workstation", "Printer_Name"
                                dbgc.Visible = True
                            Case Else
                                dbgc.Visible = False
                        End Select
                        dbgc.AutoSize()
                    Next dbgc
                    '.Splits(0).DisplayColumns("Printer_Name").Width = 200
                    ' .Splits(0).DisplayColumns("Printer_Name").FetchStyle = True 'for fetchcellevent to fire
                    '.Splits(0).DisplayColumns("IsBYOP_Model").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    '.Splits(0).DisplayColumns("IsBYOP_Model").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                End With

                Me.lblCurrentSetting.Visible = True
                Me.tdgData1.Visible = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Sub BindLabelPrinterData", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub chkBySN_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkBySN.Click
        Try
            If Me.chkBySN.Checked Then
                Me.chkByOrderNo.Checked = False
            Else
                Me.chkByOrderNo.Checked = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Sub chkBySN_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub chkByOrderNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkByOrderNo.Click
        Try
            If Me.chkByOrderNo.Checked Then
                Me.chkBySN.Checked = False
            Else
                Me.chkBySN.Checked = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Sub chkByOrderNo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "Prekit"

    Private Sub txtPrekitCardSN_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPrekitCardSN.KeyUp
        Try
            If e.KeyCode = Keys.Enter AndAlso Me.txtPrekitCardSN.Text.Trim.Length > 0 Then
                Me.ProcessPrekitSN()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtPrekitCardSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub txtPrekitInsertPN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPrekitInsertPN.KeyUp
        Try
            If e.KeyCode = Keys.Enter AndAlso Me.txtPrekitCardSN.Text.Trim.Length > 0 Then
                Me.btnPreKit.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtPrekitCardSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub ProcessPrekitSN()
        Dim dt As DataTable, dtPNs As DataTable
        Dim drNewRow, R1 As DataRow
        Dim i As Integer = 0
        Dim strSN As String = ""
        Dim strSku As String = ""
        Dim strSkuType As String = ""
        Dim strInsertDesc As String = ""
        Dim iSku_ID As Integer = 0
        Dim rowNew As DataRow, row As DataRow
        Dim iIsMultipleInserts_1Yes0No As Integer = 0

        Try
            strSN = Me.txtPrekitCardSN.Text.Trim
            Me.lblprekitCardDesc.Text = ""
            Me.lblPrekitInsertDesc.Text = ""
            Me._bIsMultipleInsertPNs = False
            Me.cboPrekitInsertPN.Visible = False
            Me.txtPrekitInsertPN.Visible = True

            If strSN.Length = 0 Then
                MessageBox.Show("Please SIM Card SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtPrekitCardSN.SelectAll() : Me.txtPrekitCardSN.Focus() : Exit Sub
            End If

            If ValidatePrekitSIMCardData(strSN, dt) Then
                'no ship, no prekit completed, then ready to Insert PN
                strSku = dt.Rows(0).Item("Sku")
                strSkuType = dt.Rows(0).Item("Sku Type")
                iSku_ID = dt.Rows(0).Item("Sku_ID")

                iIsMultipleInserts_1Yes0No = dt.Rows(0).Item("IsMultipleInserts_1Yes0No")
                If strSkuType.Trim.Length > 0 AndAlso strSku.Trim.Length > 0 AndAlso iIsMultipleInserts_1Yes0No = 0 Then
                    Me.lblprekitCardDesc.Text = "(" & strSkuType.Trim & ", " & strSku.Trim & ")"
                    strInsertDesc = dt.Rows(0).Item("Insert PN")
                    If strInsertDesc.Trim.Length > 0 Then
                        Me.lblPrekitInsertDesc.Text = "(" & strInsertDesc.Trim & ")"
                        Me.txtPrekitCardSN.Enabled = False
                        Me.txtPrekitInsertPN.Enabled = True
                        Me.txtPrekitInsertPN.SelectAll() : Me.txtPrekitInsertPN.Focus()
                    Else
                        MessageBox.Show("No Insert PN info.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtPrekitCardSN.SelectAll() : Me.txtPrekitCardSN.Focus()
                    End If
                ElseIf strSkuType.Trim.Length > 0 AndAlso strSku.Trim.Length > 0 AndAlso iIsMultipleInserts_1Yes0No = 1 Then
                    Me._bIsMultipleInsertPNs = True
                    Me.cboPrekitInsertPN.Visible = True
                    Me.txtPrekitInsertPN.Visible = False
                    Me.lblPrekitInsertDesc.Text = ""
                    Me.lblprekitCardDesc.Text = "(" & strSkuType.Trim & ", " & strSku.Trim & ")"

                    dtPNs = Me._objTN.GetAddtionalInserts(iSku_ID) 'Sku_ID, Insert PN, sku_insert_decode_id
                    If Not dtPNs.Rows.Count > 0 Then Throw New Exception("Can't find additional Inserts! See IT.")
                    rowNew = dtPNs.NewRow
                    rowNew("sku_insert_decode_id") = dt.Rows(0).Item("sku_insert_decode_id") : rowNew("Insert PN") = dt.Rows(0).Item("Insert PN")
                    dtPNs.Rows.Add(rowNew)
                    dtPNs.LoadDataRow(New Object() {"0", "--Select--"}, True)
                    Misc.PopulateC1DropDownList(Me.cboPrekitInsertPN, dtPNs, "Insert PN", "sku_insert_decode_id")
                    'If Me._iPrekitSelectedInsertID > 0 Then
                    '    Me.cboPrekitInsertPN.SelectedValue = Me._iPrekitSelectedInsertID
                    '    Me.btnPreKit.Focus()
                    'Else
                    '    Me.cboPrekitInsertPN.SelectedValue = 0
                    '    Me.cboPrekitInsertPN.Focus()
                    'End If

                    If Me.chkBoxLock.Checked AndAlso Me._iLockedSelectionInsertID > 0 Then
                        Me.cboPrekitInsertPN.SelectedValue = Me._iLockedSelectionInsertID
                        Me.btnPreKit.Focus()
                    Else
                        Me.cboPrekitInsertPN.SelectedValue = 0
                        Me.cboPrekitInsertPN.Focus()
                    End If


                Else
                    MessageBox.Show("No Sku info.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtPrekitCardSN.SelectAll() : Me.txtPrekitCardSN.Focus()
                End If
            Else
                Me.txtPrekitCardSN.Enabled = True
                Me.txtPrekitInsertPN.Enabled = False
                Me.txtPrekitCardSN.SelectAll() : Me.txtPrekitCardSN.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, " ProcessPrekitSN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            dt = Nothing
        End Try
    End Sub


    Private Sub btnprekitSNUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnprekitSNUndo.Click
        Try
            Me.txtPrekitCardSN.Text = ""
            Me.txtPrekitInsertPN.Text = ""
            Me.lblprekitCardDesc.Text = ""
            Me.lblPrekitInsertDesc.Text = ""
            Me.txtPrekitCardSN.Enabled = True
            Me.txtPrekitInsertPN.Enabled = False
            Me.txtPrekitCardSN.SelectAll() : Me.txtPrekitCardSN.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnprekitSNUndo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub btnPreKit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreKit.Click
        Dim dt As DataTable, dtKitted As DataTable, i As Integer = 0
        Dim iSku_Insert_Decode_ID As Integer = 0

        Try
            If Me.txtPrekitCardSN.Text.Trim.Length > 0 AndAlso Not Me.txtPrekitInsertPN.Text.Trim.Length > 0 Then
                MessageBox.Show("No Insert Part Number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtPrekitInsertPN.Enabled = True
                Me.txtPrekitInsertPN.SelectAll() : Me.txtPrekitInsertPN.Focus()
            ElseIf Not Me.txtPrekitCardSN.Text.Trim.Length > 0 AndAlso Me.txtPrekitInsertPN.Text.Trim.Length > 0 Then
                MessageBox.Show("No SIM Card SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtPrekitCardSN.Enabled = True
                Me.txtPrekitCardSN.SelectAll() : Me.txtPrekitCardSN.Focus()

            ElseIf Me.txtPrekitCardSN.Text.Trim.Length > 0 AndAlso Me.txtPrekitInsertPN.Text.Trim.Length > 0 Then
                i = 0
                If ValidatePrekitSIMCardData(Me.txtPrekitCardSN.Text.Trim, dt) Then 'single Inertt for a sku
                    If Not (Me._bIsMultipleInsertPNs AndAlso cboPrekitInsertPN.SelectedValue > 0) AndAlso Trim(dt.Rows(0).Item("Insert PN")).ToUpper = Me.txtPrekitInsertPN.Text.Trim.ToUpper Then
                        iSku_Insert_Decode_ID = dt.Rows(0).Item("sku_insert_decode_id")
                        i = Me._objTN.UpdatePrekitData(dt.Rows(0).Item("WI_ID"), iSku_Insert_Decode_ID, Me._UserID, Format(Now, "yyyy-MM-dd HH:mm:ss"))
                        If i = 0 Then
                            MessageBox.Show("Failed to update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        End If

                        Me.ShowSessionPreKittingResult(dt)
                        Me.txtPrekitCardSN.Enabled = True
                        Me.txtPrekitCardSN.Text = "" : Me.txtPrekitCardSN.Focus()
                        Me.txtPrekitInsertPN.Enabled = False
                        Me.txtPrekitInsertPN.Text = ""
                        Me.lblprekitCardDesc.Text = ""
                        Me.lblPrekitInsertDesc.Text = ""

                    ElseIf Me._bIsMultipleInsertPNs AndAlso _
                           Trim(Me.cboPrekitInsertPN.DataSource.Table.Select("sku_insert_decode_id = " & cboPrekitInsertPN.SelectedValue)(0)("Insert PN")).ToUpper = Me.txtPrekitInsertPN.Text.Trim.ToUpper Then 'Multiple Inserts
                        iSku_Insert_Decode_ID = cboPrekitInsertPN.SelectedValue
                        i = Me._objTN.UpdatePrekitData(dt.Rows(0).Item("WI_ID"), iSku_Insert_Decode_ID, Me._UserID, Format(Now, "yyyy-MM-dd HH:mm:ss"))
                        If i = 0 Then
                            MessageBox.Show("Failed to update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        End If

                        dtKitted = Me._objTN.GetWHDeviceData(Me._iMenuCustID, Me._iLocID, Me.txtPrekitCardSN.Text.Trim)
                        Me.ShowSessionPreKittingResult(dtKitted)
                        Me.txtPrekitCardSN.Enabled = True
                        Me.txtPrekitCardSN.Text = "" : Me.txtPrekitCardSN.Focus()
                        Me.txtPrekitInsertPN.Enabled = False
                        Me._bIsMultipleInsertPNs = False

                        Me.cboPrekitInsertPN.Visible = False
                        Me.txtPrekitInsertPN.Text = ""
                        Me.lblprekitCardDesc.Text = ""
                        Me.lblPrekitInsertDesc.Text = ""
                        Me.txtPrekitInsertPN.Enabled = False
                        If Me.chkBoxLock.Checked AndAlso Me.cboPrekitInsertPN.SelectedValue > 0 Then
                            Me._iLockedSelectionInsertID = Me.cboPrekitInsertPN.SelectedValue
                        Else
                            Me.cboPrekitInsertPN.SelectedValue = 0
                        End If

                        Else
                            MessageBox.Show("Invalid Insert Part Number or abnormal info.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtPrekitInsertPN.Enabled = True
                            Me.txtPrekitInsertPN.SelectAll() : Me.txtPrekitInsertPN.Focus()
                        End If
                End If
            End If
            'If Me.txtPrekitCardSN.Text.Trim.Length > 0 AndAlso Not Me.txtPrekitInsertPN.Text.Trim.Length > 0 Then
            '    MessageBox.Show("No Insert Part Number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '    Me.txtPrekitInsertPN.Enabled = True
            '    Me.txtPrekitInsertPN.SelectAll() : Me.txtPrekitInsertPN.Focus()
            'ElseIf Not Me.txtPrekitCardSN.Text.Trim.Length > 0 AndAlso Me.txtPrekitInsertPN.Text.Trim.Length > 0 Then
            '    MessageBox.Show("No SIM Card SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '    Me.txtPrekitCardSN.Enabled = True
            '    Me.txtPrekitCardSN.SelectAll() : Me.txtPrekitCardSN.Focus()
            'ElseIf Me.txtPrekitCardSN.Text.Trim.Length > 0 AndAlso Me.txtPrekitInsertPN.Text.Trim.Length > 0 Then
            '    i = 0
            '    If ValidatePrekitSIMCardData(Me.txtPrekitCardSN.Text.Trim, dt) Then
            '        If Trim(dt.Rows(0).Item("Insert PN")).ToUpper = Me.txtPrekitInsertPN.Text.Trim.ToUpper Then
            '            i = Me._objTN.UpdatePrekitData(dt.Rows(0).Item("WI_ID"), dt.Rows(0).Item("sku_insert_decode_id"), _
            '                                           Me._UserID, Format(Now, "yyyy-MM-dd HH:mm:ss"))
            '            If i = 0 Then
            '                MessageBox.Show("Failed to update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '                Exit Sub
            '            End If

            '            Me.ShowSessionPreKittingResult(dt)
            '            Me.txtPrekitCardSN.Enabled = True
            '            Me.txtPrekitCardSN.Text = "" : Me.txtPrekitCardSN.Focus()
            '            Me.txtPrekitInsertPN.Enabled = False
            '            Me.txtPrekitInsertPN.Text = ""
            '            Me.lblprekitCardDesc.Text = ""
            '            Me.lblPrekitInsertDesc.Text = ""
            '        Else
            '            MessageBox.Show("Invalid Insert Part Number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '            Me.txtPrekitInsertPN.Enabled = True
            '            Me.txtPrekitInsertPN.SelectAll() : Me.txtPrekitInsertPN.Focus()
            '        End If
            '    End If
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, " btnPreKit_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            dt = Nothing
        End Try
    End Sub


    Private Function ValidatePrekitSIMCardData(ByVal strSN As String, _
                                               ByRef dt As DataTable, _
                                               Optional ByRef bFillOrder As Boolean = False, _
                                               Optional ByRef bIsPrekitted As Boolean = False) As Boolean
        Try
            dt = Me._objTN.GetWHDeviceData(Me._iMenuCustID, Me._iLocID, strSN)

            If Not dt.Rows.Count > 0 Then
                MessageBox.Show("Can't find this '" & strSN & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf dt.Rows.Count > 1 Then
                MessageBox.Show("Duplicate SIM card SN '" & strSN & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf dt.Rows(0).Item("Same SN") = 0 Then
                MessageBox.Show("SIM card SN in tdevice is not the same in warehouse_items.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else 'must 1 record
                If dt.Rows(0).Item("SODetailsID") = 0 AndAlso dt.Rows(0).Item("Kit_Insert_Decode_ID") > 0 Then
                    If bFillOrder Then
                        bIsPrekitted = True
                        Return True
                    Else
                        bIsPrekitted = False
                        MessageBox.Show("Already kitted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                ElseIf dt.Rows(0).Item("SODetailsID") > 0 AndAlso Not dt.Rows(0).IsNull("Device_DateShip") _
                        AndAlso Not dt.Rows(0).IsNull("SO_ShipDate") AndAlso dt.Rows(0).Item("Kit_Insert_Decode_ID") > 0 _
                        AndAlso Not dt.Rows(0).Item("OrderReturned") = 1 Then
                    MessageBox.Show("This SIM card (kit) is shipped out.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dt.Rows(0).Item("SODetailsID") > 0 AndAlso Not dt.Rows(0).IsNull("Device_DateShip") _
                        AndAlso Not dt.Rows(0).IsNull("SO_ShipDate") AndAlso dt.Rows(0).Item("Kit_Insert_Decode_ID") > 0 _
                        AndAlso dt.Rows(0).Item("OrderReturned") = 1 Then
                    MessageBox.Show("This SIM card has been destroyed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dt.Rows(0).Item("SODetailsID") > 0 AndAlso Not dt.Rows(0).IsNull("Device_DateShip") _
                       AndAlso Not dt.Rows(0).IsNull("SO_ShipDate") AndAlso dt.Rows(0).Item("Kit_Insert_Decode_ID") = 0 Then
                    MessageBox.Show("Exception: Sim card is shipped out, but Insert PN (Wharehouse_Items.Insert_Decode_ID) is not updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dt.Rows(0).Item("SODetailsID") > 0 AndAlso Not dt.Rows(0).IsNull("Device_DateShip") _
                    AndAlso dt.Rows(0).IsNull("SO_ShipDate") AndAlso dt.Rows(0).Item("Kit_Insert_Decode_ID") > 0 Then
                    MessageBox.Show("Exception: Sim card is shipped out, but SOHeader.ShipDate is not updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dt.Rows(0).Item("SODetailsID") > 0 AndAlso dt.Rows(0).IsNull("Device_DateShip") _
                    AndAlso Not dt.Rows(0).IsNull("SO_ShipDate") AndAlso dt.Rows(0).Item("Kit_Insert_Decode_ID") > 0 Then
                    MessageBox.Show("Exception: Sim card is shipped out, but tdevice.device_DateShip is not updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf bFillOrder AndAlso dt.Rows(0).Item("SODetailsID") = 0 AndAlso dt.Rows(0).Item("Kit_Insert_Decode_ID") = 0 Then
                    MessageBox.Show("Sim card is not prekitted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                ElseIf dt.Rows(0).Item("SODetailsID") = 0 AndAlso dt.Rows(0).Item("Kit_Insert_Decode_ID") = 0 Then
                    'no ship, no prekit completed, then ready to Insert PN
                    Return True
                Else
                    MessageBox.Show("Fails to validate.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            End If

            Return False
        Catch ex As Exception
            MessageBox.Show(ex.ToString, " ValidatePrekitSIMCardData", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Function

    Private Function ValidatePrekitSIMCardData_OldWay(ByVal strSN As String, _
                                               ByRef dt As DataTable, _
                                               Optional ByRef bFillOrder As Boolean = False, _
                                               Optional ByRef bIsPrekitted As Boolean = False) As Boolean
        Try
            dt = Me._objTN.GetWHDeviceData(Me._iMenuCustID, Me._iLocID, strSN)

            If Not dt.Rows.Count > 0 Then
                MessageBox.Show("Can't find this '" & strSN & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf dt.Rows.Count > 1 Then
                MessageBox.Show("Duplicate SIM card SN '" & strSN & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else 'must 1 record
                If dt.Rows(0).Item("SODetailsID") = 0 AndAlso dt.Rows(0).Item("Kit_Insert_Decode_ID") > 0 Then
                    If bFillOrder Then
                        bIsPrekitted = True
                        Return True
                    Else
                        bIsPrekitted = False
                        MessageBox.Show("Already kitted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                ElseIf dt.Rows(0).Item("SODetailsID") > 0 AndAlso Not dt.Rows(0).IsNull("Device_DateShip") _
                        AndAlso Not dt.Rows(0).IsNull("SO_ShipDate") AndAlso dt.Rows(0).Item("Kit_Insert_Decode_ID") > 0 _
                        AndAlso Not dt.Rows(0).Item("OrderReturned") = 1 Then
                    MessageBox.Show("This SIM card (kit) is shipped out.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dt.Rows(0).Item("SODetailsID") > 0 AndAlso Not dt.Rows(0).IsNull("Device_DateShip") _
                        AndAlso Not dt.Rows(0).IsNull("SO_ShipDate") AndAlso dt.Rows(0).Item("Kit_Insert_Decode_ID") > 0 _
                        AndAlso dt.Rows(0).Item("OrderReturned") = 1 Then
                    MessageBox.Show("This SIM card has been destroyed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dt.Rows(0).Item("SODetailsID") > 0 AndAlso Not dt.Rows(0).IsNull("Device_DateShip") _
                       AndAlso Not dt.Rows(0).IsNull("SO_ShipDate") AndAlso dt.Rows(0).Item("Kit_Insert_Decode_ID") = 0 Then
                    MessageBox.Show("Exception: Sim card is shipped out, but Insert PN (Wharehouse_Items.Insert_Decode_ID) is not updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dt.Rows(0).Item("SODetailsID") > 0 AndAlso Not dt.Rows(0).IsNull("Device_DateShip") _
                    AndAlso dt.Rows(0).IsNull("SO_ShipDate") AndAlso dt.Rows(0).Item("Kit_Insert_Decode_ID") > 0 Then
                    MessageBox.Show("Exception: Sim card is shipped out, but SOHeader.ShipDate is not updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dt.Rows(0).Item("SODetailsID") > 0 AndAlso dt.Rows(0).IsNull("Device_DateShip") _
                    AndAlso Not dt.Rows(0).IsNull("SO_ShipDate") AndAlso dt.Rows(0).Item("Kit_Insert_Decode_ID") > 0 Then
                    MessageBox.Show("Exception: Sim card is shipped out, but tdevice.device_DateShip is not updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dt.Rows(0).Item("SODetailsID") = 0 AndAlso dt.Rows(0).Item("Kit_Insert_Decode_ID") = 0 Then
                    'no ship, no prekit completed, then ready to Insert PN
                    Return True
                Else
                    MessageBox.Show("Fails to validate.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            End If

            Return False
        Catch ex As Exception
            MessageBox.Show(ex.ToString, " ValidatePrekitSIMCardData", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Function

    Private Sub ShowSessionPreKittingResult(ByVal dtKit As DataTable)
        Dim row As DataRow
        Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn

        Try
            Me.tdgData2.Visible = False

            If Me._dtKitSeesionResult Is Nothing Then
                Me._dtKitSeesionResult = dtKit.Copy
            Else
                For Each row In dtKit.Rows
                    Me._dtKitSeesionResult.ImportRow(row)
                Next
            End If

            With Me.tdgData2
                .DataSource = Me._dtKitSeesionResult.DefaultView 'bind data
                .Caption = "Session Pre-Kitting Result (" & Me._dtKitSeesionResult.Rows.Count.ToString & ")"
                For Each dbgc In .Splits(0).DisplayColumns 'auto width
                    dbgc.Locked = True
                    dbgc.AutoSize()
                Next dbgc

                'invisible cols
                .Splits(0).DisplayColumns("Device_DateShip").Visible = False
                .Splits(0).DisplayColumns("SO_ShipDate").Visible = False
                .Splits(0).DisplayColumns("Same SN").Visible = False

                'Col 0 width
                .Splits(0).DisplayColumns("InsertPN_UserID").Width = 0
                .Splits(0).DisplayColumns("InsertPN_Date").Width = 0
                .Splits(0).DisplayColumns("Sku_ID").Width = 0
                .Splits(0).DisplayColumns("sku_type_decode_id").Width = 0
                .Splits(0).DisplayColumns("sku_insert_decode_id").Width = 0
                .Splits(0).DisplayColumns("Kit_Insert_Decode_ID").Width = 0
                .Splits(0).DisplayColumns("SODetailsID").Width = 0
                .Splits(0).DisplayColumns("Device_ID").Width = 0
                .Splits(0).DisplayColumns("WI_ID").Width = 0

                .Visible = True
            End With

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "ShowSessionPreKittingResult", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboPrekitInsertPN_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPrekitInsertPN.SelectedValueChanged
        Try
            Me.txtPrekitInsertPN.Text = ""
            Me.lblPrekitInsertDesc.Text = ""
            If Me._bIsMultipleInsertPNs AndAlso Me.cboPrekitInsertPN.Visible AndAlso cboPrekitInsertPN.SelectedValue > 0 Then
                Me.txtPrekitInsertPN.Text = Me.cboPrekitInsertPN.DataSource.Table.Select("sku_insert_decode_id = " & cboPrekitInsertPN.SelectedValue)(0)("Insert PN")
                Me.lblPrekitInsertDesc.Text = Me.txtPrekitInsertPN.Text
                Me.btnPreKit.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "cboPrekitInsertPN_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

#End Region

#Region "Tab ControlDrawItem and selected"
    '***************************************************************************************************************
    Private Sub TabControl1_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles TabControl1.DrawItem
        Try
            Dim g As Graphics = e.Graphics
            Dim tp As TabPage = TabControl1.TabPages(e.Index)
            Dim br As Brush
            Dim sf As New StringFormat()
            Dim r As New RectangleF(e.Bounds.X, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height - 2)

            Dim xFont As Font


            sf.Alignment = StringAlignment.Center



            Dim strTitle As String = tp.Text

            'If the current index is the Selected Index, change the color
            If TabControl1.SelectedIndex = e.Index Then
                'this is the background color of the tabpage
                'you could make this a stndard color for the selected page
                br = New SolidBrush(tp.BackColor)
                'this is the background color of the tab page
                g.FillRectangle(br, e.Bounds)
                'this is the background color of the tab page
                'you could make this a stndard color for the selected page
                br = New SolidBrush(tp.ForeColor)
                'g.DrawString(strTitle, TabControl1.Font, br, r, sf)

                xFont = New Font(TabControl1.Font, FontStyle.Bold)
                g.DrawString(strTitle, xFont, br, r, sf)
            Else
                'these are the standard colors for the unselected tab pages
                br = New SolidBrush(Color.WhiteSmoke)
                g.FillRectangle(br, e.Bounds)
                br = New SolidBrush(Color.Black)
                'g.DrawString(strTitle, TabControl1.Font, br, r, sf)

                xFont = New Font(TabControl1.Font, FontStyle.Regular)
                g.DrawString(strTitle, xFont, br, r, sf)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedTab Is Me.tabPrekit Then
            If Me.txtPrekitCardSN.Enabled AndAlso Me.txtPrekitInsertPN.Text.Trim.Length = 0 Then
                Me.txtPrekitCardSN.SelectAll() : Me.txtPrekitCardSN.Focus()
                Me.txtPrekitInsertPN.Enabled = False
            End If
        ElseIf TabControl1.SelectedTab Is Me.tabOrder Then
            If Me.txtSIMCardSN.Enabled AndAlso Me.txtInsertPartNo.Text.Trim.Length = 0 Then
                Me.txtSIMCardSN.SelectAll() : Me.txtSIMCardSN.Focus()
                Me.txtInsertPartNo.Enabled = False
            End If
        End If
    End Sub
#End Region



    Private Sub btnGetLockOrders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetLockOrders.Click
        Try
            Dim fm As New frmTNSelectAndLockOrders(Me._iMenuCustID)
            fm.ShowDialog()

            Me.GetOpenOrderData()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Sub btnGetLockOrders_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUnlockOrder_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUnlockOrder.Click
        Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
        Dim iRow As Integer = 0
        Dim iSoHeaderID As Integer = 0

        Try
            If Not Me.tdgData1.SelectedRows.Count > 0 Then
                MessageBox.Show("Please select a row or rows to unlock.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            With Me.tdgData1
                For Each iRow In .SelectedRows 'should be one row

                    If IsDBNull(.Columns("SoHeaderID").CellText(iRow)) OrElse .Columns("SoHeaderID").CellText(iRow).ToString.Trim.Length = 0 Then
                        MessageBox.Show("No SoheaderID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        iSoHeaderID = .Columns("SoHeaderID").CellText(iRow)
                        Me._objTN.UpdateUnlockOrder(iSoHeaderID)
                    End If

                Next
            End With

            GetOpenOrderData()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Sub GetSelectedRowsAndLock", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
