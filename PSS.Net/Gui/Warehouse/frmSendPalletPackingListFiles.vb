Imports CrystalDecisions.CrystalReports.Engine
Imports System.Web.Mail

Imports System.IO

Imports PSS.Core.Global

Public Class frmSendPalletPackingListFiles
    Inherits System.Windows.Forms.Form

    Private _objSPPLF As PSS.Data.Buisness.SendPalletPackingListFiles

    Private _dbTotalFileSize As Double = 0.0
    Private _strDir As String = ""
    Private _dtPallet As DataTable
    Private _dtPSPallet As DataTable
    Private _iManifestNum As Integer = 0
    Private _strUserName As String = Core.Global.ApplicationUser.User
    Private _iUserID As String = Core.Global.ApplicationUser.IDuser
    Private _strWork_Dt As String = Core.Global.ApplicationUser.Workdate
    Private _Cust_ID As Integer
    Private _Vivint_CustID As Integer = PSS.Data.Buisness.VV.Vivint.Vivint_CUSTOMER_ID
    Private _WIKO_CustID As Integer = PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID
    Private _Vinsmart_CustID As Integer = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID
    Private _Vivint_LocID As Integer = PSS.Data.Buisness.VV.Vivint.Vivint_VRQA_Loc_ID
    Private _Coolpad_CustID As Integer = PSS.Data.Buisness.CP.CoolPad.CoolPad_CUSTOMER_ID
    Private _WingTech_CustID As Integer = PSS.Data.Buisness.WingTech.WingTech.WingTech_CUSTOMER_ID
    Private _WingTechATT_CustID As Integer = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_CUSTOMER_ID
    Private _iWingTechATT_SP_LocID As Integer = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_Special_LOC_ID
    Private _objWIKO_SP As PSS.Data.Buisness.WIKO.WIKO_SpecialProject
    Private _iWIKO_SP_LocID As Integer = PSS.Data.Buisness.WIKO.WIKO.WIKO_Special_LOC_ID
    Private _iVinsmart_SP_LocID As Integer = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_Special_LOC_ID

    'Private _bIsWiKoSP_Teller As Boolean = False
    'Private _strWiKoSP_PO As String = ""
    'Private _iWiKoSP_ModelID As Integer = 0
    'Private _strWiKoSP_Country As String = ""
    'Private _strWiKoSP_MftCustPart As String = ""
    Private _bIsSP_MP As Boolean = False 'REDEFINE: Special Prject, and need Master Pallet
    Private _strSP_MP_PO As String = ""
    Private _iSP_MP_ModelID As Integer = 0
    Private _strSP_MP_Country As String = ""
    Private _strSP_MP_MftCustPart As String = ""
    Private _iDefaultCartonWeight As Integer = 18
    Private Loc_ID As Integer = 0

    Private _bHideTabOneControls As Boolean = True

#Region " Windows Form Designer generated code "

    Public Sub New(Optional ByVal Cust_ID As Integer = 0)
        MyBase.New()
        Me._Cust_ID = Cust_ID
        'This call is required by the Windows Form Designer.
        InitializeComponent()


        'Add any initialization after the InitializeComponent() call
        Me._objSPPLF = New PSS.Data.Buisness.SendPalletPackingListFiles()
        Me._objWIKO_SP = New PSS.Data.Buisness.WIKO.WIKO_SpecialProject()
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            Try
                Me._objSPPLF = Nothing
                Me._objWIKO_SP = Nothing
            Catch ex As Exception
            End Try
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents lstFileName As System.Windows.Forms.ListBox
    Friend WithEvents cmdClearOne As System.Windows.Forms.Button
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents cmdSend As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblTotalFilesSize As System.Windows.Forms.Label
    Friend WithEvents lblScannedQty As System.Windows.Forms.Label
    Friend WithEvents lblCustomer As System.Windows.Forms.Label
    Friend WithEvents cmdPSClear As System.Windows.Forms.Button
    Friend WithEvents cmdPrintPS As System.Windows.Forms.Button
    Friend WithEvents txtPSPalletNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdPSClearAll As System.Windows.Forms.Button
    Friend WithEvents lblPSQty As System.Windows.Forms.Label
    Friend WithEvents lstPSPalletName As System.Windows.Forms.ListBox
    Friend WithEvents lblFileQty As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpgEmail As System.Windows.Forms.TabPage
    Friend WithEvents tpgPackingSlip As System.Windows.Forms.TabPage
    Friend WithEvents btnPSReprint As System.Windows.Forms.Button
    Friend WithEvents btnEditManifest As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblShift As System.Windows.Forms.Label
    Friend WithEvents lblWorkDate As System.Windows.Forms.Label
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents tpgWaitingShipment As System.Windows.Forms.TabPage
    Friend WithEvents grdWaitingShipment As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents lblWS_total As System.Windows.Forms.Label
    Friend WithEvents btnWS_CopySelected As System.Windows.Forms.Button
    Friend WithEvents btnWS_CopyAll As System.Windows.Forms.Button
    Friend WithEvents lblPalletType As System.Windows.Forms.Label
    Friend WithEvents gbSkidAndGaylordQty As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSkidQty As System.Windows.Forms.TextBox
    Friend WithEvents txtCartonQty As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboCarrierType As C1.Win.C1List.C1Combo
    Friend WithEvents txtTrackingNo As System.Windows.Forms.TextBox
    Friend WithEvents gbShipCarrierInfo As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtShippingCost As System.Windows.Forms.TextBox
    Friend WithEvents cmbCustomers As C1.Win.C1List.C1Combo
    Friend WithEvents cboPalletTypes As C1.Win.C1List.C1Combo
    Friend WithEvents btnReprintModelFreqRpt As System.Windows.Forms.Button
    Private WithEvents lblNoteDesc As System.Windows.Forms.Label
    Friend WithEvents btnReprintWiKoSPTellerMasterPalletLabel As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtMasterPallet As System.Windows.Forms.TextBox
    Friend WithEvents tpgMPDetails As System.Windows.Forms.TabPage
    Friend WithEvents btnRemoveMP As System.Windows.Forms.Button
    Friend WithEvents btnRemoveAllMPs As System.Windows.Forms.Button
    Friend WithEvents btnExportMPData As System.Windows.Forms.Button
    Friend WithEvents lblCartonWeight As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtCartonWeight As System.Windows.Forms.TextBox
    Friend WithEvents lstMPallets As System.Windows.Forms.ListBox
    Friend WithEvents lblAccount As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSendPalletPackingListFiles))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.lstFileName = New System.Windows.Forms.ListBox()
        Me.cmdClearOne = New System.Windows.Forms.Button()
        Me.cmdClearAll = New System.Windows.Forms.Button()
        Me.cmdSend = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblTotalFilesSize = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblFileQty = New System.Windows.Forms.Label()
        Me.lblScannedQty = New System.Windows.Forms.Label()
        Me.lblCustomer = New System.Windows.Forms.Label()
        Me.cmdPSClear = New System.Windows.Forms.Button()
        Me.cmdPrintPS = New System.Windows.Forms.Button()
        Me.lstPSPalletName = New System.Windows.Forms.ListBox()
        Me.txtPSPalletNumber = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdPSClearAll = New System.Windows.Forms.Button()
        Me.lblPSQty = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpgEmail = New System.Windows.Forms.TabPage()
        Me.cboPalletTypes = New C1.Win.C1List.C1Combo()
        Me.lblPalletType = New System.Windows.Forms.Label()
        Me.tpgPackingSlip = New System.Windows.Forms.TabPage()
        Me.btnReprintWiKoSPTellerMasterPalletLabel = New System.Windows.Forms.Button()
        Me.lblNoteDesc = New System.Windows.Forms.Label()
        Me.btnReprintModelFreqRpt = New System.Windows.Forms.Button()
        Me.gbShipCarrierInfo = New System.Windows.Forms.GroupBox()
        Me.txtShippingCost = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboCarrierType = New C1.Win.C1List.C1Combo()
        Me.txtTrackingNo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.gbSkidAndGaylordQty = New System.Windows.Forms.GroupBox()
        Me.txtCartonQty = New System.Windows.Forms.TextBox()
        Me.txtSkidQty = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnEditManifest = New System.Windows.Forms.Button()
        Me.btnPSReprint = New System.Windows.Forms.Button()
        Me.tpgWaitingShipment = New System.Windows.Forms.TabPage()
        Me.btnWS_CopySelected = New System.Windows.Forms.Button()
        Me.btnWS_CopyAll = New System.Windows.Forms.Button()
        Me.lblWS_total = New System.Windows.Forms.Label()
        Me.grdWaitingShipment = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.tpgMPDetails = New System.Windows.Forms.TabPage()
        Me.lblAccount = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtCartonWeight = New System.Windows.Forms.TextBox()
        Me.lblCartonWeight = New System.Windows.Forms.Label()
        Me.btnExportMPData = New System.Windows.Forms.Button()
        Me.btnRemoveAllMPs = New System.Windows.Forms.Button()
        Me.btnRemoveMP = New System.Windows.Forms.Button()
        Me.lstMPallets = New System.Windows.Forms.ListBox()
        Me.txtMasterPallet = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblShift = New System.Windows.Forms.Label()
        Me.lblWorkDate = New System.Windows.Forms.Label()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.cmbCustomers = New C1.Win.C1List.C1Combo()
        Me.TabControl1.SuspendLayout()
        Me.tpgEmail.SuspendLayout()
        CType(Me.cboPalletTypes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgPackingSlip.SuspendLayout()
        Me.gbShipCarrierInfo.SuspendLayout()
        CType(Me.cboCarrierType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSkidAndGaylordQty.SuspendLayout()
        Me.tpgWaitingShipment.SuspendLayout()
        CType(Me.grdWaitingShipment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgMPDetails.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.cmbCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(16, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Pallet Number:"
        '
        'txtFileName
        '
        Me.txtFileName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFileName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFileName.Location = New System.Drawing.Point(16, 72)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(192, 22)
        Me.txtFileName.TabIndex = 2
        Me.txtFileName.Text = ""
        '
        'lstFileName
        '
        Me.lstFileName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstFileName.ItemHeight = 16
        Me.lstFileName.Location = New System.Drawing.Point(16, 96)
        Me.lstFileName.Name = "lstFileName"
        Me.lstFileName.Size = New System.Drawing.Size(192, 324)
        Me.lstFileName.TabIndex = 3
        Me.lstFileName.TabStop = False
        '
        'cmdClearOne
        '
        Me.cmdClearOne.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdClearOne.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClearOne.ForeColor = System.Drawing.Color.White
        Me.cmdClearOne.Location = New System.Drawing.Point(240, 128)
        Me.cmdClearOne.Name = "cmdClearOne"
        Me.cmdClearOne.Size = New System.Drawing.Size(88, 24)
        Me.cmdClearOne.TabIndex = 5
        Me.cmdClearOne.Text = "Clear One"
        '
        'cmdClearAll
        '
        Me.cmdClearAll.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdClearAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClearAll.ForeColor = System.Drawing.Color.White
        Me.cmdClearAll.Location = New System.Drawing.Point(240, 168)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(88, 24)
        Me.cmdClearAll.TabIndex = 6
        Me.cmdClearAll.Text = "Clear All"
        '
        'cmdSend
        '
        Me.cmdSend.BackColor = System.Drawing.Color.Green
        Me.cmdSend.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSend.ForeColor = System.Drawing.Color.White
        Me.cmdSend.Location = New System.Drawing.Point(240, 368)
        Me.cmdSend.Name = "cmdSend"
        Me.cmdSend.Size = New System.Drawing.Size(104, 32)
        Me.cmdSend.TabIndex = 4
        Me.cmdSend.Text = "Send Files"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(224, 312)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 16)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Total size of files: "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTotalFilesSize
        '
        Me.lblTotalFilesSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalFilesSize.ForeColor = System.Drawing.Color.Red
        Me.lblTotalFilesSize.Location = New System.Drawing.Point(256, 328)
        Me.lblTotalFilesSize.Name = "lblTotalFilesSize"
        Me.lblTotalFilesSize.Size = New System.Drawing.Size(72, 16)
        Me.lblTotalFilesSize.TabIndex = 7
        Me.lblTotalFilesSize.Text = "0.00 MB"
        Me.lblTotalFilesSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(240, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 16)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Scan Qty :  "
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(240, 216)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 16)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "File Qty :  "
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lblFileQty
        '
        Me.lblFileQty.BackColor = System.Drawing.Color.Black
        Me.lblFileQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFileQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFileQty.ForeColor = System.Drawing.Color.Lime
        Me.lblFileQty.Location = New System.Drawing.Point(240, 232)
        Me.lblFileQty.Name = "lblFileQty"
        Me.lblFileQty.Size = New System.Drawing.Size(88, 40)
        Me.lblFileQty.TabIndex = 22
        Me.lblFileQty.Text = "0"
        Me.lblFileQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblScannedQty
        '
        Me.lblScannedQty.BackColor = System.Drawing.Color.Black
        Me.lblScannedQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblScannedQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScannedQty.ForeColor = System.Drawing.Color.Lime
        Me.lblScannedQty.Location = New System.Drawing.Point(240, 72)
        Me.lblScannedQty.Name = "lblScannedQty"
        Me.lblScannedQty.Size = New System.Drawing.Size(88, 40)
        Me.lblScannedQty.TabIndex = 21
        Me.lblScannedQty.Text = "0"
        Me.lblScannedQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCustomer
        '
        Me.lblCustomer.BackColor = System.Drawing.Color.Transparent
        Me.lblCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomer.ForeColor = System.Drawing.Color.White
        Me.lblCustomer.Location = New System.Drawing.Point(-4, 46)
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.Size = New System.Drawing.Size(80, 16)
        Me.lblCustomer.TabIndex = 11
        Me.lblCustomer.Text = "Customer :  "
        Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdPSClear
        '
        Me.cmdPSClear.BackColor = System.Drawing.SystemColors.Control
        Me.cmdPSClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPSClear.Location = New System.Drawing.Point(216, 104)
        Me.cmdPSClear.Name = "cmdPSClear"
        Me.cmdPSClear.Size = New System.Drawing.Size(88, 24)
        Me.cmdPSClear.TabIndex = 6
        Me.cmdPSClear.Text = "Clear One"
        '
        'cmdPrintPS
        '
        Me.cmdPrintPS.BackColor = System.Drawing.Color.Green
        Me.cmdPrintPS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrintPS.ForeColor = System.Drawing.Color.White
        Me.cmdPrintPS.Location = New System.Drawing.Point(216, 352)
        Me.cmdPrintPS.Name = "cmdPrintPS"
        Me.cmdPrintPS.Size = New System.Drawing.Size(320, 56)
        Me.cmdPrintPS.TabIndex = 2
        Me.cmdPrintPS.Text = "Create/Update Manifest"
        '
        'lstPSPalletName
        '
        Me.lstPSPalletName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstPSPalletName.ItemHeight = 16
        Me.lstPSPalletName.Location = New System.Drawing.Point(8, 48)
        Me.lstPSPalletName.Name = "lstPSPalletName"
        Me.lstPSPalletName.Size = New System.Drawing.Size(192, 372)
        Me.lstPSPalletName.TabIndex = 7
        '
        'txtPSPalletNumber
        '
        Me.txtPSPalletNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPSPalletNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPSPalletNumber.Location = New System.Drawing.Point(8, 24)
        Me.txtPSPalletNumber.Name = "txtPSPalletNumber"
        Me.txtPSPalletNumber.Size = New System.Drawing.Size(192, 22)
        Me.txtPSPalletNumber.TabIndex = 0
        Me.txtPSPalletNumber.Text = ""
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(8, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Pallet Number:"
        '
        'cmdPSClearAll
        '
        Me.cmdPSClearAll.BackColor = System.Drawing.SystemColors.Control
        Me.cmdPSClearAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPSClearAll.Location = New System.Drawing.Point(216, 152)
        Me.cmdPSClearAll.Name = "cmdPSClearAll"
        Me.cmdPSClearAll.Size = New System.Drawing.Size(88, 24)
        Me.cmdPSClearAll.TabIndex = 5
        Me.cmdPSClearAll.Text = "Clear All"
        '
        'lblPSQty
        '
        Me.lblPSQty.BackColor = System.Drawing.Color.Black
        Me.lblPSQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPSQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPSQty.ForeColor = System.Drawing.Color.Lime
        Me.lblPSQty.Location = New System.Drawing.Point(224, 24)
        Me.lblPSQty.Name = "lblPSQty"
        Me.lblPSQty.Size = New System.Drawing.Size(72, 40)
        Me.lblPSQty.TabIndex = 21
        Me.lblPSQty.Text = "0"
        Me.lblPSQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpgEmail, Me.tpgPackingSlip, Me.tpgWaitingShipment, Me.tpgMPDetails})
        Me.TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.TabControl1.Location = New System.Drawing.Point(0, 74)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(784, 473)
        Me.TabControl1.TabIndex = 6
        '
        'tpgEmail
        '
        Me.tpgEmail.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tpgEmail.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboPalletTypes, Me.lblPalletType, Me.lblTotalFilesSize, Me.cmdSend, Me.Label2, Me.txtFileName, Me.lstFileName, Me.Label1, Me.Label6, Me.cmdClearOne, Me.Label5, Me.cmdClearAll, Me.lblScannedQty, Me.lblFileQty})
        Me.tpgEmail.Location = New System.Drawing.Point(4, 22)
        Me.tpgEmail.Name = "tpgEmail"
        Me.tpgEmail.Size = New System.Drawing.Size(776, 447)
        Me.tpgEmail.TabIndex = 0
        Me.tpgEmail.Text = "Email ASN Files"
        '
        'cboPalletTypes
        '
        Me.cboPalletTypes.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboPalletTypes.Caption = ""
        Me.cboPalletTypes.CaptionHeight = 17
        Me.cboPalletTypes.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboPalletTypes.ColumnCaptionHeight = 17
        Me.cboPalletTypes.ColumnFooterHeight = 17
        Me.cboPalletTypes.ContentHeight = 15
        Me.cboPalletTypes.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboPalletTypes.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboPalletTypes.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPalletTypes.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboPalletTypes.EditorHeight = 15
        Me.cboPalletTypes.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.cboPalletTypes.ItemHeight = 15
        Me.cboPalletTypes.Location = New System.Drawing.Point(16, 24)
        Me.cboPalletTypes.MatchEntryTimeout = CType(2000, Long)
        Me.cboPalletTypes.MaxDropDownItems = CType(5, Short)
        Me.cboPalletTypes.MaxLength = 32767
        Me.cboPalletTypes.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboPalletTypes.Name = "cboPalletTypes"
        Me.cboPalletTypes.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboPalletTypes.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboPalletTypes.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboPalletTypes.Size = New System.Drawing.Size(192, 21)
        Me.cboPalletTypes.TabIndex = 1
        Me.cboPalletTypes.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style9{AlignHorz:Near;}OddRow{}Reco" & _
        "rdSelector{AlignImage:Center;}Heading{Wrap:True;AlignVert:Center;Border:Raised,," & _
        "1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{}Style11{}St" & _
        "yle1{}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" " & _
        "Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight" & _
        "=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 1" & _
        "56</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HS" & _
        "crollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style" & _
        "9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" m" & _
        "e=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Hea" & _
        "ding"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inac" & _
        "tiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style" & _
        "8"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle " & _
        "parent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1" & _
        "List.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style par" & _
        "ent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=" & _
        """Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""" & _
        "Normal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent" & _
        "=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Hea" & _
        "ding"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><" & _
        "vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Def" & _
        "aultRecSelWidth>17</DefaultRecSelWidth></Blob>"
        '
        'lblPalletType
        '
        Me.lblPalletType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPalletType.ForeColor = System.Drawing.Color.Black
        Me.lblPalletType.Location = New System.Drawing.Point(16, 8)
        Me.lblPalletType.Name = "lblPalletType"
        Me.lblPalletType.Size = New System.Drawing.Size(112, 16)
        Me.lblPalletType.TabIndex = 26
        Me.lblPalletType.Text = "Pallet Type:"
        '
        'tpgPackingSlip
        '
        Me.tpgPackingSlip.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tpgPackingSlip.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnReprintWiKoSPTellerMasterPalletLabel, Me.txtPSPalletNumber, Me.lblPSQty, Me.lblNoteDesc, Me.btnReprintModelFreqRpt, Me.gbShipCarrierInfo, Me.gbSkidAndGaylordQty, Me.btnEditManifest, Me.btnPSReprint, Me.Label3, Me.cmdPSClear, Me.cmdPSClearAll, Me.lstPSPalletName, Me.cmdPrintPS})
        Me.tpgPackingSlip.Location = New System.Drawing.Point(4, 22)
        Me.tpgPackingSlip.Name = "tpgPackingSlip"
        Me.tpgPackingSlip.Size = New System.Drawing.Size(776, 447)
        Me.tpgPackingSlip.TabIndex = 1
        Me.tpgPackingSlip.Text = "Manifest"
        '
        'btnReprintWiKoSPTellerMasterPalletLabel
        '
        Me.btnReprintWiKoSPTellerMasterPalletLabel.BackColor = System.Drawing.Color.CadetBlue
        Me.btnReprintWiKoSPTellerMasterPalletLabel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReprintWiKoSPTellerMasterPalletLabel.ForeColor = System.Drawing.Color.White
        Me.btnReprintWiKoSPTellerMasterPalletLabel.Location = New System.Drawing.Point(216, 312)
        Me.btnReprintWiKoSPTellerMasterPalletLabel.Name = "btnReprintWiKoSPTellerMasterPalletLabel"
        Me.btnReprintWiKoSPTellerMasterPalletLabel.Size = New System.Drawing.Size(320, 32)
        Me.btnReprintWiKoSPTellerMasterPalletLabel.TabIndex = 26
        Me.btnReprintWiKoSPTellerMasterPalletLabel.Text = "Reprint SP Master Pallet Label "
        '
        'lblNoteDesc
        '
        Me.lblNoteDesc.ForeColor = System.Drawing.Color.DarkOrchid
        Me.lblNoteDesc.Location = New System.Drawing.Point(120, 3)
        Me.lblNoteDesc.Name = "lblNoteDesc"
        Me.lblNoteDesc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblNoteDesc.Size = New System.Drawing.Size(344, 20)
        Me.lblNoteDesc.TabIndex = 25
        Me.lblNoteDesc.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'btnReprintModelFreqRpt
        '
        Me.btnReprintModelFreqRpt.BackColor = System.Drawing.Color.SteelBlue
        Me.btnReprintModelFreqRpt.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReprintModelFreqRpt.ForeColor = System.Drawing.Color.White
        Me.btnReprintModelFreqRpt.Location = New System.Drawing.Point(544, 272)
        Me.btnReprintModelFreqRpt.Name = "btnReprintModelFreqRpt"
        Me.btnReprintModelFreqRpt.Size = New System.Drawing.Size(168, 32)
        Me.btnReprintModelFreqRpt.TabIndex = 23
        Me.btnReprintModelFreqRpt.Text = "Reprint Model Freq Report"
        Me.btnReprintModelFreqRpt.Visible = False
        '
        'gbShipCarrierInfo
        '
        Me.gbShipCarrierInfo.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtShippingCost, Me.Label10, Me.Label9, Me.cboCarrierType, Me.txtTrackingNo, Me.Label8})
        Me.gbShipCarrierInfo.Location = New System.Drawing.Point(320, 96)
        Me.gbShipCarrierInfo.Name = "gbShipCarrierInfo"
        Me.gbShipCarrierInfo.Size = New System.Drawing.Size(312, 120)
        Me.gbShipCarrierInfo.TabIndex = 22
        Me.gbShipCarrierInfo.TabStop = False
        Me.gbShipCarrierInfo.Visible = False
        '
        'txtShippingCost
        '
        Me.txtShippingCost.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShippingCost.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShippingCost.Location = New System.Drawing.Point(88, 86)
        Me.txtShippingCost.Name = "txtShippingCost"
        Me.txtShippingCost.Size = New System.Drawing.Size(56, 22)
        Me.txtShippingCost.TabIndex = 3
        Me.txtShippingCost.Text = ""
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(14, 88)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 16)
        Me.Label10.TabIndex = 116
        Me.Label10.Text = "Cost :"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(24, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 16)
        Me.Label9.TabIndex = 115
        Me.Label9.Text = "Carrier:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboCarrierType
        '
        Me.cboCarrierType.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboCarrierType.AllowDrop = True
        Me.cboCarrierType.AutoCompletion = True
        Me.cboCarrierType.AutoDropDown = True
        Me.cboCarrierType.AutoSelect = True
        Me.cboCarrierType.Caption = ""
        Me.cboCarrierType.CaptionHeight = 17
        Me.cboCarrierType.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboCarrierType.ColumnCaptionHeight = 17
        Me.cboCarrierType.ColumnFooterHeight = 17
        Me.cboCarrierType.ContentHeight = 15
        Me.cboCarrierType.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboCarrierType.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboCarrierType.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCarrierType.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboCarrierType.EditorHeight = 15
        Me.cboCarrierType.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
        Me.cboCarrierType.ItemHeight = 15
        Me.cboCarrierType.Location = New System.Drawing.Point(88, 22)
        Me.cboCarrierType.MatchEntryTimeout = CType(2000, Long)
        Me.cboCarrierType.MaxDropDownItems = CType(5, Short)
        Me.cboCarrierType.MaxLength = 32767
        Me.cboCarrierType.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboCarrierType.Name = "cboCarrierType"
        Me.cboCarrierType.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboCarrierType.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboCarrierType.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboCarrierType.Size = New System.Drawing.Size(216, 21)
        Me.cboCarrierType.TabIndex = 1
        Me.cboCarrierType.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Yellow;}Selected{ForeColor:Hi" & _
        "ghlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;" & _
        "BackColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRo" & _
        "w{ForeColor:HighlightText;BackColor:Highlight;}Style9{AlignHorz:Near;}OddRow{Bac" & _
        "kColor:Yellow;}RecordSelector{AlignImage:Center;}Heading{Wrap:True;AlignVert:Cen" & _
        "ter;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}S" & _
        "tyle10{}Style11{}Style1{}</Data></Styles><Splits><C1.Win.C1List.ListBoxView Allo" & _
        "wColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17""" & _
        " ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Clie" & _
        "ntRect>0, 0, 116, 156</ClientRect><Height>156</Height><VScrollBar><Width>16</Wid" & _
        "th></VScrollBar><HScrollBar><Height>16</Height></HScrollBar><CaptionStyle parent" & _
        "=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyl" & _
        "e parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><Headi" & _
        "ngStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" " & _
        "me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent" & _
        "=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10" & _
        """ /><SelectedStyle parent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""St" & _
        "yle1"" /></C1.Win.C1List.ListBoxView></Splits><NamedStyles><Style parent="""" me=""N" & _
        "ormal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Foote" & _
        "r"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive" & _
        """ /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightR" & _
        "ow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /" & _
        "><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group" & _
        """ /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Mo" & _
        "dified</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth></Blob>"
        '
        'txtTrackingNo
        '
        Me.txtTrackingNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTrackingNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTrackingNo.Location = New System.Drawing.Point(88, 53)
        Me.txtTrackingNo.Name = "txtTrackingNo"
        Me.txtTrackingNo.Size = New System.Drawing.Size(216, 22)
        Me.txtTrackingNo.TabIndex = 2
        Me.txtTrackingNo.Text = ""
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(4, 57)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 16)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Tracking # :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gbSkidAndGaylordQty
        '
        Me.gbSkidAndGaylordQty.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtCartonQty, Me.txtSkidQty, Me.Label7, Me.Label4})
        Me.gbSkidAndGaylordQty.Location = New System.Drawing.Point(448, 16)
        Me.gbSkidAndGaylordQty.Name = "gbSkidAndGaylordQty"
        Me.gbSkidAndGaylordQty.Size = New System.Drawing.Size(232, 80)
        Me.gbSkidAndGaylordQty.TabIndex = 1
        Me.gbSkidAndGaylordQty.TabStop = False
        Me.gbSkidAndGaylordQty.Visible = False
        '
        'txtCartonQty
        '
        Me.txtCartonQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCartonQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCartonQty.Location = New System.Drawing.Point(168, 46)
        Me.txtCartonQty.Name = "txtCartonQty"
        Me.txtCartonQty.Size = New System.Drawing.Size(56, 22)
        Me.txtCartonQty.TabIndex = 2
        Me.txtCartonQty.Text = ""
        '
        'txtSkidQty
        '
        Me.txtSkidQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSkidQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSkidQty.Location = New System.Drawing.Point(168, 16)
        Me.txtSkidQty.Name = "txtSkidQty"
        Me.txtSkidQty.Size = New System.Drawing.Size(56, 22)
        Me.txtSkidQty.TabIndex = 1
        Me.txtSkidQty.Text = ""
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(16, 47)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(144, 16)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Carton/Gaylord Qty :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(16, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 16)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Skid Qty :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnEditManifest
        '
        Me.btnEditManifest.BackColor = System.Drawing.Color.Red
        Me.btnEditManifest.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditManifest.ForeColor = System.Drawing.Color.White
        Me.btnEditManifest.Location = New System.Drawing.Point(216, 224)
        Me.btnEditManifest.Name = "btnEditManifest"
        Me.btnEditManifest.Size = New System.Drawing.Size(320, 32)
        Me.btnEditManifest.TabIndex = 4
        Me.btnEditManifest.Text = "Edit Manifest"
        Me.btnEditManifest.Visible = False
        '
        'btnPSReprint
        '
        Me.btnPSReprint.BackColor = System.Drawing.Color.SteelBlue
        Me.btnPSReprint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPSReprint.ForeColor = System.Drawing.Color.White
        Me.btnPSReprint.Location = New System.Drawing.Point(216, 272)
        Me.btnPSReprint.Name = "btnPSReprint"
        Me.btnPSReprint.Size = New System.Drawing.Size(320, 32)
        Me.btnPSReprint.TabIndex = 3
        Me.btnPSReprint.Text = "Reprint Manifest"
        '
        'tpgWaitingShipment
        '
        Me.tpgWaitingShipment.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tpgWaitingShipment.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnWS_CopySelected, Me.btnWS_CopyAll, Me.lblWS_total, Me.grdWaitingShipment})
        Me.tpgWaitingShipment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tpgWaitingShipment.Location = New System.Drawing.Point(4, 22)
        Me.tpgWaitingShipment.Name = "tpgWaitingShipment"
        Me.tpgWaitingShipment.Size = New System.Drawing.Size(776, 447)
        Me.tpgWaitingShipment.TabIndex = 2
        Me.tpgWaitingShipment.Text = "Waiting Shipment"
        '
        'btnWS_CopySelected
        '
        Me.btnWS_CopySelected.BackColor = System.Drawing.Color.LightCoral
        Me.btnWS_CopySelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWS_CopySelected.ForeColor = System.Drawing.Color.White
        Me.btnWS_CopySelected.Location = New System.Drawing.Point(360, 5)
        Me.btnWS_CopySelected.Name = "btnWS_CopySelected"
        Me.btnWS_CopySelected.Size = New System.Drawing.Size(160, 24)
        Me.btnWS_CopySelected.TabIndex = 137
        Me.btnWS_CopySelected.Text = "Copy Selected Pallets"
        '
        'btnWS_CopyAll
        '
        Me.btnWS_CopyAll.BackColor = System.Drawing.Color.LightCoral
        Me.btnWS_CopyAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWS_CopyAll.ForeColor = System.Drawing.Color.White
        Me.btnWS_CopyAll.Location = New System.Drawing.Point(8, 4)
        Me.btnWS_CopyAll.Name = "btnWS_CopyAll"
        Me.btnWS_CopyAll.Size = New System.Drawing.Size(160, 24)
        Me.btnWS_CopyAll.TabIndex = 136
        Me.btnWS_CopyAll.Text = "Copy all Pallets"
        '
        'lblWS_total
        '
        Me.lblWS_total.BackColor = System.Drawing.Color.Black
        Me.lblWS_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWS_total.ForeColor = System.Drawing.Color.Lime
        Me.lblWS_total.Location = New System.Drawing.Point(536, 6)
        Me.lblWS_total.Name = "lblWS_total"
        Me.lblWS_total.Size = New System.Drawing.Size(96, 24)
        Me.lblWS_total.TabIndex = 135
        Me.lblWS_total.Text = "Total 100"
        Me.lblWS_total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblWS_total.Visible = False
        '
        'grdWaitingShipment
        '
        Me.grdWaitingShipment.AllowColMove = False
        Me.grdWaitingShipment.AllowColSelect = False
        Me.grdWaitingShipment.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.grdWaitingShipment.AllowUpdate = False
        Me.grdWaitingShipment.AllowUpdateOnBlur = False
        Me.grdWaitingShipment.AlternatingRows = True
        Me.grdWaitingShipment.BackColor = System.Drawing.Color.SteelBlue
        Me.grdWaitingShipment.FilterBar = True
        Me.grdWaitingShipment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdWaitingShipment.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdWaitingShipment.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
        Me.grdWaitingShipment.Location = New System.Drawing.Point(8, 32)
        Me.grdWaitingShipment.MaintainRowCurrency = True
        Me.grdWaitingShipment.Name = "grdWaitingShipment"
        Me.grdWaitingShipment.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdWaitingShipment.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdWaitingShipment.PreviewInfo.ZoomFactor = 75
        Me.grdWaitingShipment.RowHeight = 20
        Me.grdWaitingShipment.Size = New System.Drawing.Size(624, 392)
        Me.grdWaitingShipment.TabIndex = 134
        Me.grdWaitingShipment.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Transparent;}Se" & _
        "lected{ForeColor:ControlText;BackColor:Yellow;}Style3{}Inactive{ForeColor:Inacti" & _
        "veCaptionText;BackColor:InactiveCaption;}FilterBar{ForeColor:Red;BackColor:Trans" & _
        "parent;}Footer{}Caption{AlignHorz:Center;ForeColor:White;BackColor:Transparent;}" & _
        "Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt;BackColor:Control;AlignVert:Cen" & _
        "ter;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddRow{B" & _
        "ackColor:Transparent;}RecordSelector{AlignImage:Center;}Style13{}Heading{Wrap:Tr" & _
        "ue;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;AlignVert:Cent" & _
        "er;Border:Raised,,1, 1, 1, 1;ForeColor:Black;BackColor:LightSteelBlue;}Style8{}S" & _
        "tyle10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style1{}</Data></Styles><Split" & _
        "s><C1.Win.C1TrueDBGrid.MergeView HBarHeight=""10"" AllowColMove=""False"" AllowColSe" & _
        "lect=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""True"" CaptionHei" & _
        "ght=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" Marqu" & _
        "eeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Vertical" & _
        "ScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>388</Height><CaptionStyle pare" & _
        "nt=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowSt" & _
        "yle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style1" & _
        "3"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""S" & _
        "tyle12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent" & _
        "=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><Od" & _
        "dRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelec" & _
        "tor"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent" & _
        "=""Normal"" me=""Style1"" /><ClientRect>0, 0, 620, 388</ClientRect><BorderSide>0</Bo" & _
        "rderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Spli" & _
        "ts><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Headin" & _
        "g"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" " & _
        "/><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /" & _
        "><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /" & _
        "><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Sty" & _
        "le parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" " & _
        "/><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><" & _
        "horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRec" & _
        "SelWidth><ClientArea>0, 0, 620, 388</ClientArea><PrintPageHeaderStyle parent="""" " & _
        "me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
        '
        'tpgMPDetails
        '
        Me.tpgMPDetails.BackColor = System.Drawing.Color.Lavender
        Me.tpgMPDetails.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblAccount, Me.Label12, Me.txtCartonWeight, Me.lblCartonWeight, Me.btnExportMPData, Me.btnRemoveAllMPs, Me.btnRemoveMP, Me.lstMPallets, Me.txtMasterPallet, Me.Label11})
        Me.tpgMPDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tpgMPDetails.Location = New System.Drawing.Point(4, 22)
        Me.tpgMPDetails.Name = "tpgMPDetails"
        Me.tpgMPDetails.Size = New System.Drawing.Size(776, 447)
        Me.tpgMPDetails.TabIndex = 3
        Me.tpgMPDetails.Text = "MP Details"
        '
        'lblAccount
        '
        Me.lblAccount.ForeColor = System.Drawing.Color.Navy
        Me.lblAccount.Location = New System.Drawing.Point(152, 8)
        Me.lblAccount.Name = "lblAccount"
        Me.lblAccount.Size = New System.Drawing.Size(336, 24)
        Me.lblAccount.TabIndex = 107
        Me.lblAccount.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(392, 216)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 24)
        Me.Label12.TabIndex = 106
        Me.Label12.Text = "lbs."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCartonWeight
        '
        Me.txtCartonWeight.Location = New System.Drawing.Point(344, 216)
        Me.txtCartonWeight.Name = "txtCartonWeight"
        Me.txtCartonWeight.Size = New System.Drawing.Size(48, 22)
        Me.txtCartonWeight.TabIndex = 104
        Me.txtCartonWeight.Text = "0"
        Me.txtCartonWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCartonWeight
        '
        Me.lblCartonWeight.Location = New System.Drawing.Point(248, 216)
        Me.lblCartonWeight.Name = "lblCartonWeight"
        Me.lblCartonWeight.Size = New System.Drawing.Size(104, 24)
        Me.lblCartonWeight.TabIndex = 105
        Me.lblCartonWeight.Text = "Carton Weight:"
        Me.lblCartonWeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnExportMPData
        '
        Me.btnExportMPData.BackColor = System.Drawing.Color.Green
        Me.btnExportMPData.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportMPData.ForeColor = System.Drawing.Color.White
        Me.btnExportMPData.Location = New System.Drawing.Point(248, 248)
        Me.btnExportMPData.Name = "btnExportMPData"
        Me.btnExportMPData.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnExportMPData.Size = New System.Drawing.Size(216, 40)
        Me.btnExportMPData.TabIndex = 103
        Me.btnExportMPData.Text = "Export Detailed Data (Excel)"
        '
        'btnRemoveAllMPs
        '
        Me.btnRemoveAllMPs.BackColor = System.Drawing.Color.Red
        Me.btnRemoveAllMPs.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveAllMPs.ForeColor = System.Drawing.Color.White
        Me.btnRemoveAllMPs.Location = New System.Drawing.Point(248, 136)
        Me.btnRemoveAllMPs.Name = "btnRemoveAllMPs"
        Me.btnRemoveAllMPs.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnRemoveAllMPs.Size = New System.Drawing.Size(216, 30)
        Me.btnRemoveAllMPs.TabIndex = 102
        Me.btnRemoveAllMPs.Text = "Remove all Master Pallets"
        '
        'btnRemoveMP
        '
        Me.btnRemoveMP.BackColor = System.Drawing.Color.Red
        Me.btnRemoveMP.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveMP.ForeColor = System.Drawing.Color.White
        Me.btnRemoveMP.Location = New System.Drawing.Point(248, 104)
        Me.btnRemoveMP.Name = "btnRemoveMP"
        Me.btnRemoveMP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnRemoveMP.Size = New System.Drawing.Size(216, 30)
        Me.btnRemoveMP.TabIndex = 101
        Me.btnRemoveMP.Text = "Remove Master Pallet"
        '
        'lstMPallets
        '
        Me.lstMPallets.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstMPallets.ItemHeight = 16
        Me.lstMPallets.Location = New System.Drawing.Point(8, 64)
        Me.lstMPallets.Name = "lstMPallets"
        Me.lstMPallets.Size = New System.Drawing.Size(216, 372)
        Me.lstMPallets.TabIndex = 100
        '
        'txtMasterPallet
        '
        Me.txtMasterPallet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMasterPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMasterPallet.Location = New System.Drawing.Point(8, 32)
        Me.txtMasterPallet.Name = "txtMasterPallet"
        Me.txtMasterPallet.Size = New System.Drawing.Size(216, 22)
        Me.txtMasterPallet.TabIndex = 2
        Me.txtMasterPallet.Text = ""
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(8, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(208, 16)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Master Pallet Name:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblShift, Me.lblWorkDate, Me.lblUserName})
        Me.Panel1.Location = New System.Drawing.Point(248, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(456, 40)
        Me.Panel1.TabIndex = 12
        '
        'lblShift
        '
        Me.lblShift.BackColor = System.Drawing.Color.Transparent
        Me.lblShift.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShift.ForeColor = System.Drawing.Color.Lime
        Me.lblShift.Location = New System.Drawing.Point(144, 11)
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
        Me.lblWorkDate.Location = New System.Drawing.Point(280, 10)
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
        Me.lblUserName.Location = New System.Drawing.Point(8, 11)
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
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(248, 40)
        Me.lblTitle.TabIndex = 93
        Me.lblTitle.Text = "MANIFEST PROCESSING"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbCustomers
        '
        Me.cmbCustomers.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cmbCustomers.Caption = ""
        Me.cmbCustomers.CaptionHeight = 17
        Me.cmbCustomers.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cmbCustomers.ColumnCaptionHeight = 17
        Me.cmbCustomers.ColumnFooterHeight = 17
        Me.cmbCustomers.ContentHeight = 15
        Me.cmbCustomers.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cmbCustomers.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cmbCustomers.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCustomers.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbCustomers.EditorHeight = 15
        Me.cmbCustomers.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
        Me.cmbCustomers.ItemHeight = 15
        Me.cmbCustomers.Location = New System.Drawing.Point(80, 46)
        Me.cmbCustomers.MatchEntryTimeout = CType(2000, Long)
        Me.cmbCustomers.MaxDropDownItems = CType(5, Short)
        Me.cmbCustomers.MaxLength = 32767
        Me.cmbCustomers.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cmbCustomers.Name = "cmbCustomers"
        Me.cmbCustomers.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cmbCustomers.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cmbCustomers.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cmbCustomers.Size = New System.Drawing.Size(248, 21)
        Me.cmbCustomers.TabIndex = 0
        Me.cmbCustomers.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style1{}OddRow{}RecordSelector{Alig" & _
        "nImage:Center;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;For" & _
        "eColor:ControlText;AlignVert:Center;}Style8{}Style10{}Style11{}Style9{AlignHorz:" & _
        "Near;}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" " & _
        "Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight" & _
        "=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 1" & _
        "56</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HS" & _
        "crollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style" & _
        "9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" m" & _
        "e=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Hea" & _
        "ding"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inac" & _
        "tiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style" & _
        "8"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle " & _
        "parent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1" & _
        "List.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style par" & _
        "ent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=" & _
        """Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""" & _
        "Normal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent" & _
        "=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Hea" & _
        "ding"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><" & _
        "vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Def" & _
        "aultRecSelWidth>17</DefaultRecSelWidth></Blob>"
        '
        'frmSendPalletPackingListFiles
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(784, 550)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmbCustomers, Me.TabControl1, Me.lblCustomer, Me.lblTitle, Me.Panel1})
        Me.Name = "frmSendPalletPackingListFiles"
        Me.Text = "Manifest Process"
        Me.TabControl1.ResumeLayout(False)
        Me.tpgEmail.ResumeLayout(False)
        CType(Me.cboPalletTypes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgPackingSlip.ResumeLayout(False)
        Me.gbShipCarrierInfo.ResumeLayout(False)
        CType(Me.cboCarrierType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSkidAndGaylordQty.ResumeLayout(False)
        Me.tpgWaitingShipment.ResumeLayout(False)
        CType(Me.grdWaitingShipment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgMPDetails.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.cmbCustomers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    '#End Region

    '*******************************************************************
    Protected Overrides Sub Finalize()
        If Not IsNothing(Me._objSPPLF) Then
            Me._objSPPLF = Nothing
        End If
        MyBase.Finalize()
    End Sub

    '*******************************************************************
    Private Sub HideFirstTabControls()
        Dim ctrl As Control
        Dim i As Integer = 0
        Try
            Me.tpgEmail.Text = ""
            For Each ctrl In Me.tpgEmail.Controls
                ctrl.Visible = False
            Next
            Me.tpgEmail.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.ToString, " HideFirstTabControls", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub
    '*******************************************************************
    Private Sub frmSendPalletPackingListFiles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim R1 As DataRow
        Dim objDockShip As PSS.Data.Buisness.DockShipping
        Dim dt As DataTable

        Try
            PSS.Core.Highlight.SetHighLight(Me)

            Me.lblNoteDesc.Text = "" : Me.txtCartonWeight.Text = Me._iDefaultCartonWeight

            '********************************************
            'Get User Acess
            '********************************************
            If ApplicationUser.GetPermission("EditPackingSlip") > 0 Then Me.btnEditManifest.Visible = True

            'Hide tab 1 controls. No need this 2016-08-15
            If Me._bHideTabOneControls Then HideFirstTabControls()

            'Create datatable for Email ASN Files
            Me._dtPallet = New DataTable()
            PSS.Data.Buisness.Generic.AddNewColumnToDataTable(Me._dtPallet, "Pallett_ID", "System.Int32", "0")
            PSS.Data.Buisness.Generic.AddNewColumnToDataTable(Me._dtPallet, "Pallett_Name", "System.String", "")

            'Create datatable for Packing Slip
            Me._dtPSPallet = New DataTable()
            PSS.Data.Buisness.Generic.AddNewColumnToDataTable(Me._dtPSPallet, "pkslip_ID", "System.Int32", "0")
            PSS.Data.Buisness.Generic.AddNewColumnToDataTable(Me._dtPSPallet, "Pallett_ID", "System.Int32", "0")
            PSS.Data.Buisness.Generic.AddNewColumnToDataTable(Me._dtPSPallet, "Pallett_Name", "System.String", "")
            PSS.Data.Buisness.Generic.AddNewColumnToDataTable(Me._dtPSPallet, "WO_ID", "System.Int32", "0")

            Me.lblShift.Text = "Shift: " & Core.Global.ApplicationUser.IDShift
            Me.lblUserName.Text = Core.Global.ApplicationUser.User()
            Me.lblWorkDate.Text = Core.Global.ApplicationUser.Workdate

            objDockShip = New PSS.Data.Buisness.DockShipping()
            dt = objDockShip.GetShipCarriers(True)
            Misc.PopulateC1DropDownList(Me.cboCarrierType, dt, "SC_Desc", "SC_ID")

            PopulateCustomers()

            If Me._Cust_ID = PSS.Data.Buisness.VV.Vivint.Vivint_CUSTOMER_ID Then
                Try
                    Me.cmbCustomers.SelectedValue = PSS.Data.Buisness.VV.Vivint.Vivint_CUSTOMER_ID
                Catch ex As Exception
                End Try
                Me.TabControl1.SelectedIndex = 1
            ElseIf Me._Cust_ID = 2485 Then
                Me.cmbCustomers.SelectedValue = 2485 'SYX
                Me.TabControl1.SelectedIndex = 1
            Else
                Me.cmbCustomers.SelectedValue = 0 : Me.cmbCustomers.SelectAll() : Me.cmbCustomers.Focus()
                Me.TabControl1.SelectedIndex = 1 ' Me.TabControl1.SelectedIndex = 0
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "FormLoad Event", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            R1 = Nothing : objDockShip = Nothing : PSS.Data.Buisness.Generic.DisposeDT(dt)
        End Try
    End Sub

    '*******************************************************************
    Private Sub PopulateCustomers()
        Dim dt As DataTable
        Try
            dt = Me._objSPPLF.GetReadyToManifestCustomersList()
            Misc.PopulateC1DropDownList(Me.cmbCustomers, dt, "Cust_Name1", "Cust_ID")
            Me.cmbCustomers.SelectedValue = 0
        Catch ex As Exception
            Throw ex
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
        End Try
    End Sub

    '*******************************************************************
    Private Sub cmbCustomers_RowChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCustomers.RowChange

        Try
            'Watiing shipment tab
            PopulateWaitingShipmentGrid()

            'Reset listbox and datatable
            Me._dtPallet.Rows.Clear()
            Me.lstFileName.Items.Clear()
            Me.lblFileQty.Text = "0"
            Me.lblScannedQty.Text = Me._dtPallet.Rows.Count
            Me.lblTotalFilesSize.Text = "0.00"

            Me._dtPSPallet.Rows.Clear()
            Me.lstPSPalletName.Items.Clear()
            Me.lblPSQty.Text = Me.lstPSPalletName.Items.Count.ToString
            Me._iManifestNum = 0
            If Me.cmbCustomers.SelectedValue = 2219 Then
                Me._strDir = "P:\Dept\Game Stop\Pallet packing list\"
                Me.lblPalletType.Visible = False
                Me.cboPalletTypes.Visible = False
            Else
                Me._strDir = ""
                If Not Me._bHideTabOneControls Then
                    Me.lblPalletType.Visible = True
                    Me.cboPalletTypes.Visible = True
                End If
            End If

            Me.cboPalletTypes.DataSource = Nothing
            If Me.cmbCustomers.SelectedValue > 0 Then Me.PopulatePalletType(Me.cmbCustomers.SelectedValue)

            'GENESIS CUSTOMER
            If Me.cmbCustomers.SelectedValue = 2427 Then Me.gbSkidAndGaylordQty.Visible = True Else Me.gbSkidAndGaylordQty.Visible = False
            Me.txtSkidQty.Text = "" : Me.txtCartonQty.Text = ""

            If Me.cmbCustomers.SelectedValue > 0 AndAlso Me.cmbCustomers.DataSource.Table.Select("Cust_ID = " & Me.cmbCustomers.SelectedValue & " AND ReqOutboundTracking = 1").Length > 0 Then
                Me.gbShipCarrierInfo.Visible = True
            Else
                Me.gbShipCarrierInfo.Visible = False
            End If

            Me.btnReprintWiKoSPTellerMasterPalletLabel.Visible = False
            If Me.cmbCustomers.SelectedValue = _WIKO_CustID _
               OrElse Me.cmbCustomers.SelectedValue = Me._Vinsmart_CustID _
               OrElse Me.cmbCustomers.SelectedValue = Me._WingTechATT_CustID _
                OrElse Me.cmbCustomers.SelectedValue = Me._WingTech_CustID Then
                Me.gbShipCarrierInfo.Visible = True : Me.btnReprintWiKoSPTellerMasterPalletLabel.Visible = True
            ElseIf TabControl1.SelectedIndex = 3 AndAlso Me.cmbCustomers.SelectedValue <> Me._WIKO_CustID _
                   AndAlso Me.cmbCustomers.SelectedValue <> Me._Vinsmart_CustID _
                   AndAlso Me.cmbCustomers.SelectedValue <> Me._WingTechATT_CustID Then
                TabControl1.SelectedIndex = 1
                TabControl1.TabPages(TabControl1.SelectedIndex).Focus()
            End If

            If Me.cmbCustomers.SelectedValue = _Coolpad_CustID Then Me.gbShipCarrierInfo.Visible = True

            If Me.cmbCustomers.SelectedValue > 0 AndAlso Me.tpgPackingSlip.Visible = True AndAlso Data.Buisness.MessLabel.IsAMSShareableInventoryCustomer(Me.cmbCustomers.SelectedValue) Then
                Me.btnReprintModelFreqRpt.Visible = True
            Else
                Me.btnReprintModelFreqRpt.Visible = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "cmbCustomers_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
        'Private Sub cmbCustomer_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCustomer1.SelectionChangeCommitted
    End Sub

    '*******************************************************************
    Private Sub PopulatePalletType(ByVal iCustID As Integer)
        Dim dt As DataTable
        Dim R1 As DataRow
        Try
            Me.cboPalletTypes.DataSource = Nothing
            dt = New DataTable()
            PSS.Data.Buisness.Generic.AddNewColumnToDataTable(dt, "Pallet_ShipType", "System.Int32")
            PSS.Data.Buisness.Generic.AddNewColumnToDataTable(dt, "Pallet_ShipType_Desc", "System.String")
            If iCustID > 0 Then
                Select Case iCustID
                    Case 2019   'ATCLE
                        R1 = dt.NewRow
                        R1("Pallet_ShipType") = 0
                        R1("Pallet_ShipType_Desc") = "REGULAR"
                        dt.Rows.Add(R1)
                        R1 = Nothing
                        R1 = dt.NewRow
                        R1("Pallet_ShipType") = 10
                        R1("Pallet_ShipType_Desc") = "DISCREPANCY"
                        dt.Rows.Add(R1)
                        dt.AcceptChanges()
                    Case 2219   'GAMESTOP
                        R1 = dt.NewRow
                        R1("Pallet_ShipType") = 0
                        R1("Pallet_ShipType_Desc") = "REGULAR"
                        dt.Rows.Add(R1)
                        dt.AcceptChanges()
                    Case 14, Data.Buisness.SkyTel.Aquis_CUSTOMER_ID    'AMS
                        R1 = dt.NewRow
                        R1("Pallet_ShipType") = 1
                        R1("Pallet_ShipType_Desc") = "DBR"
                        dt.Rows.Add(R1)
                        R1 = Nothing
                        R1 = dt.NewRow
                        R1("Pallet_ShipType") = 2
                        R1("Pallet_ShipType_Desc") = "NER"
                        dt.Rows.Add(R1)
                        dt.AcceptChanges()
                    Case 1545     'SkyTel
                        R1 = dt.NewRow
                        R1("Pallet_ShipType") = 0
                        R1("Pallet_ShipType_Desc") = "REGULAR"
                        dt.Rows.Add(R1)
                        R1 = Nothing
                        R1 = dt.NewRow
                        R1("Pallet_ShipType") = 1
                        R1("Pallet_ShipType_Desc") = "DBR"
                        dt.Rows.Add(R1)
                        R1 = Nothing
                        R1 = dt.NewRow
                        R1("Pallet_ShipType") = 2
                        R1("Pallet_ShipType_Desc") = "NER"
                        dt.Rows.Add(R1)
                        dt.AcceptChanges()
                    Case 2507     'Morris Communication
                        R1 = dt.NewRow
                        R1("Pallet_ShipType") = 0
                        R1("Pallet_ShipType_Desc") = "REGULAR"
                        dt.Rows.Add(R1)
                        R1 = Nothing
                        R1 = dt.NewRow
                        R1("Pallet_ShipType") = 1
                        R1("Pallet_ShipType_Desc") = "DBR"
                        dt.Rows.Add(R1)
                        R1 = Nothing
                        R1 = dt.NewRow
                        R1("Pallet_ShipType") = 2
                        R1("Pallet_ShipType_Desc") = "NER"
                        dt.Rows.Add(R1)
                        dt.AcceptChanges()
                    Case 2508, Data.Buisness.SkyTel.CookPager_CUSTOMER_ID     'Propage
                        R1 = dt.NewRow
                        R1("Pallet_ShipType") = 0
                        R1("Pallet_ShipType_Desc") = "REGULAR"
                        dt.Rows.Add(R1)
                        R1 = Nothing
                        R1 = dt.NewRow
                        R1("Pallet_ShipType") = 1
                        R1("Pallet_ShipType_Desc") = "DBR"
                        dt.Rows.Add(R1)
                        R1 = Nothing
                        R1 = dt.NewRow
                        R1("Pallet_ShipType") = 2
                        R1("Pallet_ShipType_Desc") = "NER"
                        dt.Rows.Add(R1)
                        dt.AcceptChanges()
                    Case 2254     'Plexus Corp.
                        R1 = dt.NewRow
                        R1("Pallet_ShipType") = 0
                        R1("Pallet_ShipType_Desc") = "PASS"
                        dt.Rows.Add(R1)
                        R1 = Nothing
                        R1 = dt.NewRow
                        R1("Pallet_ShipType") = 1
                        R1("Pallet_ShipType_Desc") = "FAIL"
                        dt.Rows.Add(R1)
                    Case Else
                End Select
            End If

            Misc.PopulateC1DropDownList(Me.cboPalletTypes, dt, "Pallet_ShipType_Desc", "Pallet_ShipType")
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "PopulatePalletType", MessageBoxButtons.OK)
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
        End Try
    End Sub

    '*******************************************************************

#End Region

#Region "Email ASN File Tabpage"

    '*******************************************************************
    Private Sub cmdSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSend.Click
        Dim strFrom As String = "", strTo As String = "", strCc As String = "", strSubject As String = "", strBody As String = "Please see attached."
        Dim strDir As String = ""
        Dim strNewDir As String = ""        'move sended files to new folder
        Dim strDirAndFileName = "", strDestDirAndFileName = "", strFileExtensions = ".xls"
        Dim i As Integer = 0
        Dim objWarehouse As New PSS.Data.Buisness.Warehouse()
        Dim R1 As DataRow
        Dim strPallettIDs As String
        Dim arrlFilesName As ArrayList

        Try
            '******************************************
            'Validate user input
            '******************************************
            If Me.cmbCustomers.SelectedValue = 0 Then
                MessageBox.Show("Please select customer.", "Sending Ship Files", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.cmbCustomers.SelectAll() : Me.cmbCustomers.Focus() : Exit Sub
            ElseIf Me._strDir.Trim.Length = 0 Then
                MessageBox.Show("File directory is missing. Please select Pallet Type.", "Sending Ship Files", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.cboPalletTypes.Focus() : Exit Sub
            ElseIf Me.lstFileName.Items.Count = 0 Then
                Me.txtFileName.Focus()
                Exit Sub
            End If

            Me.cmdSend.Enabled = False

            '************************
            'Collect the pallett_ID 
            '************************
            For Each R1 In Me._dtPallet.Rows
                If strPallettIDs = "" Then
                    strPallettIDs &= R1("Pallett_ID")
                Else
                    strPallettIDs &= ", " & R1("Pallett_ID")
                End If
            Next R1

            '''***************************************************************
            ''Added by Lan on 11/15/2007  'Create XML Ship Report
            '''***************************************************************
            'If Me.cmbCustomers.SelectedValue = 2019 AndAlso Me.cboPalletTypes.Text = "REGULAR" Then
            '    If PSS.Data.Buisness.Generic.GetConstantDbValue("SENT_ATCLE_SHIP_XMLRPT").ToString = "1" Then
            '        Me.CreateATCLEXMLFIle(strPallettIDs)
            '    End If
            'End If
            ''***************************************************************

            '*****************************
            'Get Email List from database
            '*****************************
            strFrom = objWarehouse.GetEmailAddressList(Me.cmbCustomers.SelectedValue, "FROM", Me.cboPalletTypes.Text.Trim)
            strTo = objWarehouse.GetEmailAddressList(Me.cmbCustomers.SelectedValue, "TO", Me.cboPalletTypes.Text.Trim)
            strCc = objWarehouse.GetEmailAddressList(Me.cmbCustomers.SelectedValue, "CC", Me.cboPalletTypes.Text.Trim)
            If (Me.cmbCustomers.SelectedValue = 14 OrElse Me.cmbCustomers.SelectedValue = 1545 OrElse Me.cmbCustomers.SelectedValue = 2507 OrElse Me.cmbCustomers.SelectedValue = 2508 OrElse Me.cmbCustomers.SelectedValue = 444 OrElse Me.cmbCustomers.SelectedValue = 2563) AndAlso Me.cboPalletTypes.Text = "REGULAR" Then
                strTo = strTo.Replace("ITOperations@americanmessaging.net", "") : strTo = strTo.Replace(";;", ";")
                If strTo.Trim.StartsWith(";") Then strTo = strTo.Remove(0, 1)
                If strTo.Trim.EndsWith(";") Then strTo = strTo.Remove(strTo.Length - 1, 1)
                strCc = strTo.Replace("ITOperations@americanmessaging.net", "") : strTo = strTo.Replace(";;", ";")
                If strCc.Trim.StartsWith(";") Then strCc = strCc.Remove(0, 1)
                If strCc.Trim.EndsWith(";") Then strCc = strCc.Remove(strCc.Length - 1, 1)
            End If
            '*************************************************************************
            strDir = Me._strDir
            strNewDir = Me._strDir & "ARCHIVE FILES\" & Format(Now, "MMddyyyy-hhmm") & "\"
            If Me.cmbCustomers.SelectedValue = 2019 Then 'ATCLE
                If Me.cboPalletTypes.Text = "REGULAR" Then
                    strSubject = Format(Now, "MM/dd/yyyy") & " " & Me.cmbCustomers.Text & " ASN File(s)"
                ElseIf Me.cboPalletTypes.Text = "DISCREPANCY" Then
                    strSubject = Format(Now, "MM/dd/yyyy") & " " & Me.cmbCustomers.Text & " Discrepancy File(s)"
                End If
            ElseIf Me.cmbCustomers.SelectedValue = 2219 Then 'GameStop
                strSubject = Format(Now, "MM/dd/yyyy") & " Ship Manifest(s)"
                'If Me.cboPalletType.Text = "REGULAR" Then
                '    strSubject = Format(Now, "MM/dd/yyyy") & " Ship Manifest(s)"
                'ElseIf Me.cboPalletType.Text = "DISCREPANCY" Then
                '    strSubject = Format(Now, "MM/dd/yyyy") & " " & Me.cmbCustomer.Text & " Discrepancy Files"
                'End If
            ElseIf Me.cmbCustomers.SelectedValue = 14 Then 'AMS
                If Me.cboPalletTypes.Text = "DBR" Then
                    strSubject = Format(Now, "MM/dd/yyyy") & " DBR Report(s)"
                    strFileExtensions = ".txt"
                ElseIf Me.cboPalletTypes.Text = "NER" Then
                    strSubject = Format(Now, "MM/dd/yyyy") & " NER Report(s)"
                    strFileExtensions = ".txt"
                End If
            ElseIf Me.cmbCustomers.SelectedValue = 1545 Then
                If Me.cboPalletTypes.Text = "DBR" Then
                    strSubject = Format(Now, "MM/dd/yyyy") & " Shipment DBR Report(s)"
                    strFileExtensions = ".txt"
                ElseIf Me.cboPalletTypes.Text = "NER" Then
                    strSubject = Format(Now, "MM/dd/yyyy") & " Shipment NER Report(s)"
                    strFileExtensions = ".txt"
                ElseIf Me.cboPalletTypes.Text = "REGULAR" Then
                    strSubject = Format(Now, "MM/dd/yyyy") & " Shipment REPAIR Report(s)"
                End If
            ElseIf Me.cmbCustomers.SelectedValue = 2507 Then 'Morris Communication
                If Me.cboPalletTypes.Text = "DBR" Then
                    strSubject = Format(Now, "MM/dd/yyyy") & " Shipment DBR Report(s)"
                    strFileExtensions = ".txt"
                ElseIf Me.cboPalletTypes.Text = "NER" Then
                    strSubject = Format(Now, "MM/dd/yyyy") & " Shipment NER Report(s)"
                    strFileExtensions = ".txt"
                ElseIf Me.cboPalletTypes.Text = "REGULAR" Then
                    strSubject = Format(Now, "MM/dd/yyyy") & " Shipment REPAIR Report(s)"
                End If
            ElseIf Me.cmbCustomers.SelectedValue = 2508 Then 'Propage
                If Me.cboPalletTypes.Text = "DBR" Then
                    strSubject = Format(Now, "MM/dd/yyyy") & " Shipment DBR Report(s)"
                    strFileExtensions = ".txt"
                ElseIf Me.cboPalletTypes.Text = "NER" Then
                    strSubject = Format(Now, "MM/dd/yyyy") & " Shipment NER Report(s)"
                    strFileExtensions = ".txt"
                ElseIf Me.cboPalletTypes.Text = "REGULAR" Then
                    strSubject = Format(Now, "MM/dd/yyyy") & " Shipment REPAIR Report(s)"
                End If
            ElseIf Me.cmbCustomers.SelectedValue = Data.Buisness.SkyTel.CookPager_CUSTOMER_ID Then 'Cook Pager
                If Me.cboPalletTypes.Text = "DBR" Then
                    strSubject = Format(Now, "MM/dd/yyyy") & " Shipment DBR Report(s)"
                    strFileExtensions = ".txt"
                ElseIf Me.cboPalletTypes.Text = "NER" Then
                    strSubject = Format(Now, "MM/dd/yyyy") & " Shipment NER Report(s)"
                    strFileExtensions = ".txt"
                ElseIf Me.cboPalletTypes.Text = "REGULAR" Then
                    strSubject = Format(Now, "MM/dd/yyyy") & " Shipment REPAIR Report(s)"
                End If
            ElseIf Me.cmbCustomers.SelectedValue = Data.Buisness.SkyTel.Aquis_CUSTOMER_ID Then 'Aquis Pager
                If Me.cboPalletTypes.Text = "DBR" Then
                    strSubject = Format(Now, "MM/dd/yyyy") & " Shipment DBR Report(s)"
                    strFileExtensions = ".txt"
                ElseIf Me.cboPalletTypes.Text = "NER" Then
                    strSubject = Format(Now, "MM/dd/yyyy") & " Shipment NER Report(s)"
                    strFileExtensions = ".txt"
                ElseIf Me.cboPalletTypes.Text = "REGULAR" Then
                    strSubject = Format(Now, "MM/dd/yyyy") & " Shipment REPAIR Report(s)"
                End If
            Else
                MessageBox.Show("Can not define Customer.", "Sending Shipping Files", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            '*************************************************************************

            Me.Enabled = False

            '*************************************************
            '1:: Sending mail to Customer and copy PSSI
            '*************************************************
            If strTo <> "" Then
                'blnResult = SendMail(strFrom, strTo, strCc, strSubject, strBody, "", strDir, strFileExtensions)
                arrlFilesName = Me.GetFileNameList()
                i = Me._objSPPLF.SetPalletReadyToEmail(Me.cmbCustomers.SelectedValue, Core.ApplicationUser.IDuser, strFrom, strTo, strCc, strSubject, strBody, arrlFilesName, strDir, strFileExtensions)

                If i > 0 Then
                    ''************************************************
                    ''3:: Move all attachment file to archive folder
                    ''************************************************
                    'For i = 0 To Me.lstFileName.Items.Count - 1
                    '    '********************************************
                    '    'Text File, not all customer have text file
                    '    '********************************************
                    '    If strFileExtensions = ".txt" Then
                    '        strDirAndFileName = strDir & Trim(Me.lstFileName.Items.Item(i)) & ".txt"
                    '        'create diretory
                    '        If Directory.Exists(strNewDir) = False Then Directory.CreateDirectory(strNewDir)
                    '        strDestDirAndFileName = strNewDir & Trim(Me.lstFileName.Items.Item(i)) & ".txt"
                    '        'move sended files to Archive folder
                    '        If File.Exists(strDestDirAndFileName) = False Then File.Move(strDirAndFileName, strDestDirAndFileName)
                    '    End If
                    '    '********************************************
                    '    'Excel Files
                    '    '********************************************
                    '    strDirAndFileName = strDir & Trim(Me.lstFileName.Items.Item(i)) & ".xls"
                    '    'create diretory
                    '    If Directory.Exists(strNewDir) = False Then Directory.CreateDirectory(strNewDir)
                    '    strDestDirAndFileName = strNewDir & Trim(Me.lstFileName.Items.Item(i)) & ".xls"
                    '    'move sended files to Archive folder
                    '    If File.Exists(strDestDirAndFileName) = False Then File.Move(strDirAndFileName, strDestDirAndFileName)
                    'Next i

                    '************************************************
                    '4:: Write send date to database
                    '************************************************
                    i = Me._objSPPLF.SetSendDate(strPallettIDs, Me._strWork_Dt)
                    '************************************************

                    MessageBox.Show("Email has been sent sucessfully.", "Sending Ship Files", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Else
                    'Failed to send mail to PSSI staff
                End If
            Else
                'Don't need to send to customer or failed to send mail to Customer
            End If

            Me._dtPallet.Rows.Clear()
            Me.lstFileName.Items.Clear()
            Me.lblTotalFilesSize.Text = "0.0 MB"
            Me.lblScannedQty.Text = Me._dtPallet.Rows.Count
            Me._dbTotalFileSize = 0.0
            Me.lblFileQty.Text = ""
            Me.lblPalletType.Visible = True
            Me.cboPalletTypes.Visible = True
            Me.txtFileName.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Sending Ship Files", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            Me.cmdSend.Enabled = True

            If Not IsNothing(objWarehouse) Then
                objWarehouse = Nothing
            End If
            R1 = Nothing
        End Try
    End Sub

    ''*******************************************************************OK
    'Private Sub CreateATCLEXMLFIle(ByVal strPallettIDs As String)
    '    Dim i As Integer = 0
    '    Dim p As New Process()
    '    '*****************************************
    '    'Create XML report and upload to ATCLE ftp site
    '    '*****************************************
    '    Try
    '        'Create XML report 
    '        i = Me._objSPPLF.CreateXMLFile(strPallettIDs, Me._strUserName)

    '        'Upload file to FTP Site if report contains data
    '        If i > 0 Then
    '            If File.Exists("C:\ATC_UploadFiles\ATC_Put.bat") = True Then
    '                p.Start("C:\ATC_UploadFiles\ATC_Put.bat")
    '            Else
    '                '''Do something here
    '                SendMail("languyen@productsupportservices.com", _
    '                         "languyen@productsupportservices.com", "", _
    '                         Me._strWork_Dt & " Send ATCLE XML File", _
    '                         "Bat files are missing on computer " & System.Net.Dns.GetHostName & "." & Environment.NewLine & "User Name: " & Me._strUserName & Environment.NewLine & "Pallet IDs: " & strPallettIDs, _
    '                         "", _
    '                         "", ".xls")
    '            End If
    '        End If
    '    Catch ex As Exception
    '        '''Do something here
    '        SendMail("languyen@productsupportservices.com", _
    '                 "languyen@productsupportservices.com", "", _
    '                 Me._strWork_Dt & " Send ATCLE XML File", _
    '                 "Exception: " & ex.Message & Environment.NewLine & "User Name: " & Me._strUserName & Environment.NewLine & "Pallet IDs: " & strPallettIDs, _
    '                 "", _
    '                 "", ".xls")
    '    End Try
    'End Sub

    '*******************************************************************OK
    Private Function GetFileNameList() As ArrayList
        Dim i As Integer
        Dim arrlistFileLoc As New ArrayList()
        Dim strFileName As String

        Try
            For i = 0 To Me.lstFileName.Items.Count - 1
                strFileName = Trim(Me.lstFileName.Items.Item(i))
                arrlistFileLoc.Add(strFileName)
            Next i

            Return arrlistFileLoc
        Catch ex As Exception
            Throw New Exception("Message has not been sent." & ex.ToString)
        End Try
    End Function

    ''*******************************************************************OK
    'Private Function SendMail(ByVal strMailFrom As String, _
    '                      ByVal strMailTo As String, _
    '                      ByVal strMailCC As String, _
    '                      ByVal strSubject As String, _
    '                      ByVal strBody As String, _
    '                      ByVal strSmtpServer As String, _
    '                      ByVal strDir As String, _
    '                      ByVal strFileExtensions As String) As Boolean

    '    Dim objMail As New System.Web.Mail.MailMessage()
    '    Dim i As Integer = 0
    '    Dim strDirAndFileName As String = ""
    '    Dim booSendResult As Boolean = False

    '    Try
    '        objMail = New MailMessage()

    '        If strSmtpServer <> "" Then
    '            SmtpMail.SmtpServer = strSmtpServer
    '        End If

    '        objMail.From = strMailFrom
    '        objMail.To = strMailTo
    '        If strMailCC.Trim.Length > 0 Then objMail.Cc = strMailCC
    '        objMail.Subject = strSubject
    '        objMail.Body = strBody

    '        '******************************************
    '        'add attachment
    '        If strDir <> "" Then
    '            For i = 0 To Me.lstFileName.Items.Count - 1
    '                strDirAndFileName = strDir & Trim(Me.lstFileName.Items.Item(i)) & strFileExtensions
    '                Dim M1 As New MailAttachment(strDirAndFileName)
    '                objMail.Attachments.Add(M1)
    '                If Not IsNothing(M1) Then
    '                    M1 = Nothing
    '                    strDirAndFileName = ""
    '                End If
    '            Next i
    '        End If
    '        '******************************************

    '        objMail.BodyFormat = MailFormat.Text 'can be text also
    '        SmtpMail.Send(objMail)

    '        booSendResult = True

    '        Return booSendResult
    '    Catch ex As Exception
    '        Throw New Exception("Message has not been sent." & ex.ToString)
    '    Finally
    '        If Not IsNothing(objMail) Then
    '            objMail = Nothing
    '            SmtpMail.SmtpServer = Nothing
    '        End If
    '    End Try
    'End Function

    '*******************************************************************OK
    Private Sub txtFileName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFileName.KeyUp
        Dim strFileName As String = ""
        Dim objMisc As New PSS.Data.Buisness.Misc()
        Dim objBulkShip As New PSS.Data.Buisness.BulkShipping()
        Dim iPallett_id As Integer = 0
        Dim iExel_Qty As Integer = 0
        Dim dbTemp As Double = 0
        Dim dt1 As DataTable
        Dim R1 As DataRow

        If e.KeyValue = 13 Then

            Try
                '**********************
                'Validate input
                '**********************
                If Me.cmbCustomers.SelectedValue = 0 Then
                    MessageBox.Show("Please select customer.", "Scan Pallet Name", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtFileName.Text = ""
                    Me.cmbCustomers.SelectAll() : Me.cmbCustomers.Focus()
                    Exit Sub
                ElseIf Me._strDir.Trim.Length = 0 Then
                    MessageBox.Show("File directory is missing. Please select Pallet Type.", "Scan Pallet Name", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtFileName.Text = ""
                    Me.cboPalletTypes.Focus()
                    Exit Sub
                ElseIf Me.txtFileName.Text = "" Then
                    Exit Sub
                End If

                '************************
                'check for duplicate
                '************************
                Dim i As Integer = 0
                If Me.lstFileName.Items.Count > 0 Then
                    If Me.lstFileName.Items.IndexOf(Trim(Me.txtFileName.Text)) > -1 Then
                        MessageBox.Show("This pallet Number is already scanned in. Try another one.", "Pallet Name scan", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.txtFileName.Text = ""
                        Me.txtFileName.Focus()
                        Exit Sub
                    End If
                End If

                '*************************************
                'check pallet already ship in system
                '*************************************
                If Not Me._objSPPLF.CheckShippedPallet(Trim(Me.txtFileName.Text)) Then
                    MessageBox.Show("Pallet is not shipped in the system.", "Shipping Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                '****************************************************
                'assgin file name based on Reg or discrepancy pallet
                '****************************************************
                strFileName = Me._strDir & Trim(Me.txtFileName.Text) & ".xls"

                '**********************
                'check file exist
                '**********************
                If System.IO.File.Exists(strFileName) = False Then
                    MsgBox("The file name associated with the pallet number does not exist.")
                Else
                    '************************************
                    'check total size of attatched files
                    '************************************
                    dbTemp = Me._dbTotalFileSize + New FileInfo(strFileName).Length

                    If dbTemp > 10000000 Then
                        MessageBox.Show("Total size of attached files can not exceed 10MB.", "File Size", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Else
                        '********************************* added by Lan on 01/30/2007
                        'Verifying Pallet Qty & customer
                        '*********************************
                        dt1 = objMisc.GetPalletInfo_ByPallettName(Trim(Me.txtFileName.Text))
                        If dt1.Rows.Count > 0 Then

                            'CHECK PALLET TYPE
                            If Me.cmbCustomers.SelectedValue <> 2219 Then    'skip Gamestop
                                If Me.cboPalletTypes.SelectedValue <> dt1.Rows(0)("Pallet_ShipType") Then
                                    MsgBox("Pallet is not an " & Me.cboPalletTypes.Text & " pallet.")
                                    Me.txtFileName.SelectAll()
                                    Exit Sub
                                End If
                            End If
                            iPallett_id = dt1.Rows(0)("Pallett_ID")

                            '***********************
                            'Check Send date
                            '***********************
                            If Not IsDBNull(dt1.Rows(0)("Pallett_SendDt")) Then
                                MessageBox.Show("This Pallet already sent out on " & dt1.Rows(0)("Pallett_SendDt") & ".", "Check Pallet Sent Date", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                                Me.txtFileName.SelectAll()
                                Exit Sub
                            End If

                            If Me.cboPalletTypes.Text = "REGULAR" Or Me.cmbCustomers.SelectedValue = 2219 Then
                                '******************************************************
                                'Make sure scanned pallet belongs to selected customer
                                '******************************************************
                                If Not IsDBNull(dt1.Rows(0)("Cust_ID")) Then
                                    If dt1.Rows(0)("Cust_ID") <> Me.cmbCustomers.SelectedValue Then
                                        MessageBox.Show("Pallet does not belong to selected customer.", "Verify Pallet Ownership", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                                        Exit Sub
                                    End If
                                Else
                                    MessageBox.Show("Pallet does not belong to any customer.", "Verify Pallet Ownership", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                                    Exit Sub
                                End If

                                '**********************
                                'Check Manifest Qty
                                '**********************
                                If Me.cmbCustomers.SelectedValue = 14 Then
                                    Me.lblFileQty.Text = Me._objSPPLF.GetPalletQty(iPallett_id)
                                Else
                                    ''iPallett_id = objMisc.GetPalletID(Trim(Me.txtFileName.Text), 1)
                                    objBulkShip.iPallet_ID = iPallett_id
                                    objBulkShip.iLoc_ID = dt1.Rows(0)("Loc_ID")
                                    objBulkShip.iCust_ID = Me.cmbCustomers.SelectedValue
                                    objBulkShip.strFilePath = Me._strDir & Trim(Me.txtFileName.Text) & ".xls"

                                    'Get Pallet count
                                    iExel_Qty = objBulkShip.ExtractSNs(0)
                                    Me.lblFileQty.Text = iExel_Qty
                                End If
                            End If

                            '*********************
                            'Add Row to datatable
                            '*********************
                            R1 = Me._dtPallet.NewRow
                            R1("Pallett_Name") = Me.txtFileName.Text.Trim.ToUpper
                            R1("Pallett_ID") = iPallett_id
                            Me._dtPallet.Rows.Add(R1)
                            Me._dtPallet.AcceptChanges()

                            Me.lstFileName.Items.Add(Trim(Me.txtFileName.Text))

                            Me.lblScannedQty.Text = Me.lstFileName.Items.Count
                            Me._dbTotalFileSize = dbTemp
                            Me.lblTotalFilesSize.Text = Format((Me._dbTotalFileSize / 1000000.0), "00.00") & " MB"

                        Else
                            MessageBox.Show("Pallet does not exist in the system.", "Verify Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If
                        '********************************* added by Lan on 01/30/2007
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "FileName_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.txtFileName.Text = ""
                objMisc = Nothing
                objBulkShip = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End If
    End Sub

    '*******************************************************************OK
    Private Sub cmdClearOne_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdClearOne.Click
        Dim strDeletePalletName As String = ""
        Dim R1 As DataRow
        Dim iIndex As Integer = 0

        Try
            If Me.lstFileName.Items.Count = 0 Then
                Exit Sub
            End If

            'Get Pallet to be delete
            strDeletePalletName = Trim(InputBox("Pallet Name:", "Remove item From List"))

            If strDeletePalletName = "" Then
                Exit Sub
            End If

            iIndex = Me.lstFileName.Items.IndexOf(strDeletePalletName)

            If iIndex = -1 Then
                MessageBox.Show("Item does not exist in list", "Remove item From List", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtFileName.Focus()
                Exit Sub
            End If

            'Delete from datatable
            For Each R1 In Me._dtPallet.Rows
                If R1("Pallett_Name").ToString.Trim.ToUpper = strDeletePalletName.Trim.ToUpper Then
                    R1.Delete()
                    Exit For
                End If
            Next R1
            Me._dtPallet.AcceptChanges()

            'Delete from list
            Me.lstFileName.Items.RemoveAt(iIndex)
            Me.lstFileName.Refresh()

            'Reset counter
            Me.lblScannedQty.Text = Me.lstFileName.Items.Count
            Me.txtFileName.Text = ""
            Me.txtFileName.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Remove One Item", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*******************************************************************OK
    Private Sub cmdClearAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        If Me.lstFileName.Items.Count > 0 Then
            Me._dtPallet.Rows.Clear()
            Me.lstFileName.Items.Clear()
            Me.lstFileName.Refresh()
            Me.lblScannedQty.Text = Me.lstFileName.Items.Count
            Me.txtFileName.Text = ""
            Me.txtFileName.Focus()
        End If
    End Sub

    '*******************************************************************OK
    Private Sub rdbtnReg_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.lstFileName.Items.Clear()
        Me.txtFileName.Text = ""
        Me.txtFileName.Focus()
    End Sub

    '*******************************************************************OK
    Private Sub rdbtnDis_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.lstFileName.Items.Clear()
        Me.txtFileName.Text = ""
        Me.txtFileName.Focus()
    End Sub

    '*******************************************************************
    Private Sub cboPalletTypes_RowChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPalletTypes.RowChange
        'Private Sub cboPalletType_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPalletType1.SelectionChangeCommitted
        Try
            'Reset listbox and datatable
            Me._dtPallet.Rows.Clear()
            Me.lstFileName.Items.Clear()
            Me.lblFileQty.Text = "0"
            Me.lblScannedQty.Text = Me._dtPallet.Rows.Count
            Me.lblTotalFilesSize.Text = "0.00"

            Me._dtPSPallet.Rows.Clear()
            Me.lstPSPalletName.Items.Clear()
            Me.lblPSQty.Text = Me.lstPSPalletName.Items.Count.ToString
            Me._iManifestNum = 0
            Me._strDir = ""

            If Me.cmbCustomers.SelectedValue = 0 Then
                Me.cmbCustomers.SelectAll() : Me.cmbCustomers.Focus()
                Exit Sub
            Else
                If Me.cmbCustomers.SelectedValue = 2019 Then
                    If Me.cboPalletTypes.Text = "REGULAR" Then
                        Me._strDir = "P:\Dept\ATCLE\Palet packing list\"
                    ElseIf Me.cboPalletTypes.Text = "DISCREPANCY" Then
                        Me._strDir = "P:\Dept\ATCLE\Palet packing list\DISCREPANCY FOLDER\"
                    End If
                ElseIf Me.cmbCustomers.SelectedValue = 2219 Then
                    Me._strDir = "P:\Dept\Game Stop\Pallet packing list\"
                    'If Me.cboPalletTypes.Text = "REGULAR" Then
                    '    Me._strDir = "P:\Dept\Game Stop\Pallet packing list\"
                    'ElseIf Me.cboPalletTypes.Text = "DISCREPANCY" Then
                    '    Me._strDir = "P:\Dept\Game Stop\DISCREPANCY FOLDER\"
                    'End If
                ElseIf Me.cmbCustomers.SelectedValue = 14 Then
                    If Me.cboPalletTypes.Text = "DBR" Or Me.cboPalletTypes.Text = "NER" Then
                        Me._strDir = "P:\Dept\Messaging\DBR Manifest\"
                    End If
                ElseIf Me.cmbCustomers.SelectedValue = 1545 Then 'SkyTel
                    If Me.cboPalletTypes.Text = "REGULAR" Or Me.cboPalletTypes.Text = "DBR" Or Me.cboPalletTypes.Text = "NER" Then
                        Me._strDir = "P:\Dept\Skytel\Pallet Packing List\"
                    End If
                ElseIf Me.cmbCustomers.SelectedValue = 2507 Then 'Morris Communication
                    If Me.cboPalletTypes.Text = "REGULAR" Or Me.cboPalletTypes.Text = "DBR" Or Me.cboPalletTypes.Text = "NER" Then
                        Me._strDir = "P:\Dept\Morris Communication\Pallet Packing List\"
                    End If
                ElseIf Me.cmbCustomers.SelectedValue = 2508 Then 'Propage
                    If Me.cboPalletTypes.Text = "REGULAR" Or Me.cboPalletTypes.Text = "DBR" Or Me.cboPalletTypes.Text = "NER" Then
                        Me._strDir = "P:\Dept\Propage\Pallet Packing List\"
                    End If
                ElseIf Me.cmbCustomers.SelectedValue = Data.Buisness.SkyTel.CookPager_CUSTOMER_ID Then 'Cook Pager
                    If Me.cboPalletTypes.Text = "REGULAR" Or Me.cboPalletTypes.Text = "DBR" Or Me.cboPalletTypes.Text = "NER" Then
                        Me._strDir = "P:\Dept\CookPager\Pallet Packing List\"
                    End If
                ElseIf Me.cmbCustomers.SelectedValue = Data.Buisness.SkyTel.Aquis_CUSTOMER_ID Then 'Aquis Communications
                    If Me.cboPalletTypes.Text = "REGULAR" Or Me.cboPalletTypes.Text = "DBR" Or Me.cboPalletTypes.Text = "NER" Then
                        Me._strDir = "P:\Dept\Aquis\Pallet Packing List\"
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "cboPalletTypes_RowChange", MessageBoxButtons.OK)
        End Try
    End Sub

    '*******************************************************************
    Private Sub cboPalletTypes_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPalletTypes.Leave
        Try
            If Me.cmbCustomers.SelectedValue = 0 Then
                Exit Sub
            Else
                If Me.cmbCustomers.SelectedValue = 2019 Then
                    If Me.cboPalletTypes.Text = "REGULAR" Then
                        Me._strDir = "P:\Dept\ATCLE\Palet packing list\"
                    ElseIf Me.cboPalletTypes.Text = "DISCREPANCY" Then
                        Me._strDir = "P:\Dept\ATCLE\Palet packing list\DISCREPANCY FOLDER\"
                    End If
                ElseIf Me.cmbCustomers.SelectedValue = 2219 Then
                    Me._strDir = "P:\Dept\Game Stop\Pallet packing list\"
                    'If Me.cboPalletTypes.Text = "REGULAR" Then
                    '    Me._strDir = "P:\Dept\Game Stop\Pallet packing list\"
                    'ElseIf Me.cboPalletTypes.Text = "DISCREPANCY" Then
                    '    Me._strDir = "P:\Dept\Game Stop\DISCREPANCY FOLDER\"
                    'End If
                ElseIf Me.cmbCustomers.SelectedValue = 14 Then
                    If Me.cboPalletTypes.Text = "DBR" Or Me.cboPalletTypes.Text = "NER" Then
                        Me._strDir = "P:\Dept\Messaging\DBR Manifest\"
                    End If
                ElseIf Me.cmbCustomers.SelectedValue = 1545 Then 'SkyTel
                    If Me.cboPalletTypes.Text = "REGULAR" Or Me.cboPalletTypes.Text = "DBR" Or Me.cboPalletTypes.Text = "NER" Then
                        Me._strDir = "P:\Dept\Skytel\Pallet Packing List\"
                    End If
                ElseIf Me.cmbCustomers.SelectedValue = 2507 Then 'Morris Communication
                    If Me.cboPalletTypes.Text = "REGULAR" Or Me.cboPalletTypes.Text = "DBR" Or Me.cboPalletTypes.Text = "NER" Then
                        Me._strDir = "P:\Dept\Morris Communication\Pallet Packing List\"
                    End If
                ElseIf Me.cmbCustomers.SelectedValue = 2508 Then 'Propage
                    If Me.cboPalletTypes.Text = "REGULAR" Or Me.cboPalletTypes.Text = "DBR" Or Me.cboPalletTypes.Text = "NER" Then
                        Me._strDir = "P:\Dept\Propage\Pallet Packing List\"
                    End If
                ElseIf Me.cmbCustomers.SelectedValue = Data.Buisness.SkyTel.CookPager_CUSTOMER_ID Then 'Cook Pager
                    If Me.cboPalletTypes.Text = "REGULAR" Or Me.cboPalletTypes.Text = "DBR" Or Me.cboPalletTypes.Text = "NER" Then
                        Me._strDir = "P:\Dept\CookPager\Pallet Packing List\"
                    End If
                End If
                Me.txtFileName.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "cboPalletTypes_Leave", MessageBoxButtons.OK)
        End Try
    End Sub

    '*******************************************************************

#End Region

#Region "Create Manifest Tabpage"
    '*******************************************************************
    Private Sub tabModelMaster_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles TabControl1.DrawItem
        Try
            DrawTab(sender, e, Color.LightSteelBlue, Color.Blue, Color.AntiqueWhite, Color.Black)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OKOnly, "Error in tabModelMaster_DrawItem")
        End Try
    End Sub

    '*******************************************************************
    Private Sub DrawTab(ByVal sender As Object, _
                        ByVal e As System.Windows.Forms.DrawItemEventArgs, _
                        ByVal FocusedBackColor As Color, _
                        ByVal FocusedForeColor As Color, _
                        ByVal NonFocusedBackColor As Color, _
                        ByVal NonFocusedForeColor As Color)
        Dim f As Font
        Dim backBrush, foreBrush As Brush
        Dim sf As StringFormat
        Dim strTabName As String
        Dim rect As Rectangle
        Dim r As RectangleF
        Dim iAddX(), iAddY(), iAddHeight(), iAddWidth() As Integer

        Try
            sf = New StringFormat()
            f = New Font(e.Font, FontStyle.Regular)

            ReDim iAddX(1)
            ReDim iAddY(1)
            ReDim iAddHeight(1)
            ReDim iAddWidth(1)

            If e.Index = Me.TabControl1.SelectedIndex Then
                backBrush = New System.Drawing.SolidBrush(FocusedBackColor)
                foreBrush = New System.Drawing.SolidBrush(FocusedForeColor)

                Me.TabControl1.TabPages(e.Index).BackColor = FocusedBackColor

                iAddX(0) = 4
                iAddY(0) = -6
                iAddWidth(0) = -6
                iAddHeight(0) = 3
                iAddX(1) = 1
                iAddY(1) = 4
            Else
                backBrush = New System.Drawing.SolidBrush(NonFocusedBackColor)
                foreBrush = New System.Drawing.SolidBrush(NonFocusedForeColor)

                Me.TabControl1.TabPages(e.Index).BackColor = FocusedBackColor

                iAddX(0) = 1
                iAddY(0) = 0
                iAddWidth(0) = -1
                iAddHeight(0) = 1
                iAddX(1) = 0
                iAddY(1) = 4
            End If

            rect = New Rectangle(e.Bounds.X + iAddX(0), e.Bounds.Y + iAddY(0), e.Bounds.Width + iAddWidth(0), e.Bounds.Height + iAddHeight(0))

            sf.Alignment = StringAlignment.Center
            e.Graphics.FillRectangle(backBrush, rect)

            iAddWidth(1) = 0
            iAddHeight(1) = -4

            r = New RectangleF(e.Bounds.X + iAddX(1), e.Bounds.Y + iAddY(1), e.Bounds.Width + iAddWidth(1), e.Bounds.Height + iAddHeight(1))

            strTabName = Me.TabControl1.TabPages(e.Index).Text
            e.Graphics.DrawString(strTabName, f, foreBrush, r, sf)
        Catch ex As Exception
            Throw ex
        Finally
            sf.Dispose()
            f.Dispose()
            backBrush.Dispose()
            foreBrush.Dispose()
        End Try
    End Sub

    '*******************************************************************
    Private Sub cmdCreatePS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintPS.Click
        Me.CreateManifest()
    End Sub

    '*******************************************************************
    Private Sub CreateManifest()
        Dim iSelectedCustID, i, iPkslip_ID, iSkidQty, iGaylordQty, iShipCarrier As Integer
        Dim strSQL, strErr, strCustName, strTrackingNo As String
        Dim dt As DataTable
        Dim drArr() As DataRow
        Dim arrlstPalletNames As New ArrayList()
        Dim decShippingCost As Decimal = 0
        Dim objMessLabel As PSS.Data.Buisness.MessLabel
        Dim iSP_MP_DevQtyPerBox As Integer = 0
        Dim iSP_MP_BoxQtyPerMasterBox As Integer = 0
        Dim iSP_MP_ToalDevQty As Integer = 0
        Dim bIsSameDeviceQtyPerBox As Boolean = True

        Try
            '************************
            'Validate user input
            '************************
            If Me.cmbCustomers.SelectedValue = 0 Then
                MessageBox.Show("Please select a customer.", "Create Manifest", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.cmbCustomers.SelectAll() : Me.cmbCustomers.Focus()
            ElseIf Me.lstPSPalletName.Items.Count = 0 Or Me._dtPSPallet.Rows.Count = 0 Then
                MessageBox.Show("List is empty.", "Create Manifest", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtPSPalletNumber.SelectAll() : Me.txtPSPalletNumber.Focus()
            ElseIf Me.cmbCustomers.SelectedValue = 2427 AndAlso Me.txtSkidQty.Text.Trim.Length = 0 Then
                MessageBox.Show("Please enter skid quantity.", "Create Manifest", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtSkidQty.SelectAll() : Me.txtSkidQty.Focus()
            ElseIf Me.cmbCustomers.SelectedValue = 2427 AndAlso Me.txtCartonQty.Text.Trim.Length = 0 Then
                MessageBox.Show("Please enter carton/gaylord quantity.", "Create Manifest", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtCartonQty.SelectAll() : Me.txtCartonQty.Focus()
            ElseIf Me.gbShipCarrierInfo.Visible = True AndAlso Me.cboCarrierType.SelectedValue = 0 Then
                MessageBox.Show("Please select shipping carrier.", "Create Manifest", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.cboCarrierType.SelectAll() : Me.cboCarrierType.Focus()
            ElseIf Me.gbShipCarrierInfo.Visible = True AndAlso Me.txtTrackingNo.Text.Trim.Length = 0 Then
                MessageBox.Show("Please enter tracking #.", "Create Manifest", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.cboCarrierType.SelectAll() : Me.cboCarrierType.Focus()
            ElseIf Me.gbShipCarrierInfo.Visible = True AndAlso Me.txtShippingCost.Text.Trim.Length = 0 Then
                MessageBox.Show("Please enter shipping cost.", "Create Manifest", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.cboCarrierType.SelectAll() : Me.cboCarrierType.Focus()
            ElseIf Me.gbShipCarrierInfo.Visible = True AndAlso Convert.ToDouble(Me.txtShippingCost.Text) = 0 Then
                MessageBox.Show("Shipping cost can't be zero.", "Create Manifest", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.cboCarrierType.SelectAll() : Me.cboCarrierType.Focus()
            ElseIf Me._bIsSP_MP AndAlso (Me.cmbCustomers.SelectedValue = Me._WIKO_CustID OrElse Me.cmbCustomers.SelectedValue = Me._Vinsmart_CustID _
                   OrElse Me.cmbCustomers.SelectedValue = Me._WingTechATT_CustID) _
                   AndAlso Not IsQtyCorrectAndGetQty(iSP_MP_DevQtyPerBox, iSP_MP_BoxQtyPerMasterBox, iSP_MP_ToalDevQty, bIsSameDeviceQtyPerBox) Then
                MessageBox.Show("Invalid device count (Box Qty<>Device Qty)", "Create Manifest", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            ElseIf Me.cmbCustomers.SelectedValue = Me._WingTechATT_CustID AndAlso bIsSameDeviceQtyPerBox = False Then
                MessageBox.Show("Not the same qty per box in the master pallet. Invalid!", "Create Manifest", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
                'ElseIf MessageBox.Show("Are you sure you want to create a manifest for all pallet in the list?", "Create Manifest", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                ''

            Else
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                If Me.gbShipCarrierInfo.Visible = True Then
                    strTrackingNo = Me.txtTrackingNo.Text.Trim.ToUpper
                    iShipCarrier = Me.cboCarrierType.SelectedValue
                    If Me.txtShippingCost.Text.Trim.Length > 0 Then decShippingCost = Convert.ToDecimal(Me.txtShippingCost.Text)
                Else
                    strTrackingNo = "" : iShipCarrier = 0 : decShippingCost = 0
                End If

                '*****************************************
                ' Check for pallet IDs whose corresponding customer IDs don't match with the selected customer
                '*****************************************
                iSelectedCustID = Me.cmbCustomers.SelectedValue
                For i = 0 To Me.lstPSPalletName.Items.Count - 1
                    arrlstPalletNames.Add(Me.lstPSPalletName.Items.Item(i))
                Next i
                If Me.cmbCustomers.SelectedValue = 2577 Then 'Skullcandy Retail
                    dt = Me._objSPPLF.GetCustomerIDsAndNames(arrlstPalletNames, Me.cmbCustomers.SelectedValue)
                Else
                    dt = Me._objSPPLF.GetCustomerIDsAndNames(arrlstPalletNames)
                End If
                If Not IsNothing(dt) Then
                    drArr = dt.Select("CustID <> " & iSelectedCustID.ToString)
                    If drArr.Length > 0 Then
                        strCustName = Me.cmbCustomers.DataSource.Table.Select("Cust_ID = " & Me.cmbCustomers.SelectedValue)(0)("Cust_Name1")
                        strErr = "There are pallets selected which have a different customer from " & strCustName & ": "
                        For i = 0 To drArr.Length - 1
                            strErr &= drArr(i)("PalletName")
                            If i < drArr.Length - 1 Then strErr &= ", "
                        Next
                        strErr &= "."
                        MessageBox.Show(strErr, "Create Manifest", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                End If

                '****************************
                'Create packing splip report
                '****************************

                If Me.cmbCustomers.SelectedValue = 2427 Then
                    iSkidQty = Convert.ToInt32(Me.txtSkidQty.Text) : iGaylordQty = Convert.ToInt32(Me.txtCartonQty.Text)
                Else
                    iSkidQty = 0 : iGaylordQty = 0
                End If
                If Me._iManifestNum > 0 Then 'update
                    iPkslip_ID = Me._iManifestNum
                    If Me.gbShipCarrierInfo.Visible = True Then _objSPPLF.UpdateShippingCost(iPkslip_ID, iShipCarrier, strTrackingNo, decShippingCost)
                Else 'insert new
                    iPkslip_ID = Me._objSPPLF.CreatePackingSlip(iSelectedCustID, Me._iUserID, , strTrackingNo, , iShipCarrier, decShippingCost, iSkidQty, iGaylordQty)
                End If
                i = Me._objSPPLF.AssignManifestNumToPallets(Me._dtPSPallet, iPkslip_ID, Me._iUserID, Me.cmbCustomers.SelectedValue)
                'Added by Amazech-Thanga 07.07.2021
                If Me._Vinsmart_CustID = cmbCustomers.SelectedValue OrElse _WIKO_CustID = cmbCustomers.SelectedValue OrElse _Coolpad_CustID = cmbCustomers.SelectedValue _
                   OrElse _WingTech_CustID = cmbCustomers.SelectedValue OrElse (Me._bIsSP_MP AndAlso Me._WingTechATT_CustID = cmbCustomers.SelectedValue) _
                   OrElse Me._WingTechATT_CustID = cmbCustomers.SelectedValue Then
                    'no need to print packing slip 
                Else
                    Me._objSPPLF.PrintShipPackingSlip(iPkslip_ID, Me.cmbCustomers.SelectedValue)
                End If
                'print  Label for Vivint 
                If iSelectedCustID = _Vivint_CustID Then
                    _objSPPLF.PrintManifest_Vivint(iPkslip_ID)
                End If
                'print  Label for Vinsmart
                'If iSelectedCustID = _Vinsmart_CustId Then
                '    _objSPPLF.PrintManifest_Vivint(iPkslip_ID)
                'End If
                '***************************************
                'Print Report (CoolPad Rpt)
                '***************************************
                If iSelectedCustID = _Coolpad_CustID Then
                    Dim cpLocID As Integer
                    Dim dtPallett As DataTable = Me._objSPPLF.getPallett_Id(iPkslip_ID)
                    If dtPallett.Rows.Count > 0 Then
                        Me._objSPPLF.UpdateMExtendedWarranty(iShipCarrier, strTrackingNo, iPkslip_ID)
                        Loc_ID = dtpallett.rows(0)("Loc_ID")
                    End If
                    Dim RviResult As String
                    _objSPPLF.GenerateRvi(iPkslip_ID, Loc_ID)
                    Me._objSPPLF.PrintManifestCoolpad(iPkslip_ID, _Coolpad_CustID)

                    GoTo M
                End If
                'added by Amazech-Thanga 07.07.2021
                'Print Report (WingTech Rpt)
                '***************************************
                If iSelectedCustID = _WingTech_CustID Then
                    Dim dtPallett As DataTable = Me._objSPPLF.getPallett_Id(iPkslip_ID)
                    If dtPallett.Rows.Count > 0 Then
                        Me._objSPPLF.UpdateMExtendedWarranty(iShipCarrier, strTrackingNo, iPkslip_ID)
                        Loc_ID = dtpallett.rows(0)("Loc_ID")
                    End If
                    Dim RviResult As String
                    _objSPPLF.GenerateRvi(iPkslip_ID, Loc_ID)
                    Me._objSPPLF.PrintManifestWingTech(iPkslip_ID, _WingTech_CustID)

                    GoTo M
                End If
                '***************************************
                'Print Report (WIKO Rpt)
                '***************************************
                Dim strPrefixVinsmart As String = String.Empty
                If Me._bIsSP_MP AndAlso (iSelectedCustID = Me._WIKO_CustID OrElse iSelectedCustID = Me._Vinsmart_CustID OrElse iSelectedCustID = Me._WingTechATT_CustID) Then 'SP MP boxes==============================

                    Dim iModel_Id As Integer
                    Dim dtPallet As New DataTable()

                    dtPallet = Me._objSPPLF.getPallett_Id(iPkslip_ID)

                    If dtPallet.Rows.Count = 0 Then
                        Exit Sub
                    Else
                        Loc_ID = dtPallet.Rows(0)("Loc_ID")
                        iModel_Id = dtPallet.Rows(0)("Model_ID")
                    End If
                    Dim dtModel As DataTable = Me._objSPPLF.getModel_id(iModel_Id)
                    If dtModel.Rows.Count > 0 Then
                        If dtModel.Rows(0)("Model_Motosku") = "V340U" Then
                            strPrefixVinsmart = "PS01F01057"
                        ElseIf dtModel.Rows(0)("Model_Motosku") = "V350U" Then
                            strPrefixVinsmart = "PS01F01109"
                        End If
                    End If

                    Dim strPreFix_MasterPalletName As String
                    If iSelectedCustID = Me._WIKO_CustID Then
                        strPreFix_MasterPalletName = "PLT" & Format(Now, "yyMMdd") & "D"
                    ElseIf iSelectedCustID = Me._Vinsmart_CustID Then
                        strPreFix_MasterPalletName = strPrefixVinsmart & Format(Now, "yyMMdd")
                    End If
                    Dim iDigitLength As Integer = 3
                    Dim iNextSeqNo_MPallet As Integer = 0
                    Dim strMaterPalletName As String = strPreFix_MasterPalletName
                    Dim strPreFix_LoadNo As String = "PLT" & Format(Now, "yyMMdd") & "4"
                    Dim strLoadNo As String = strPreFix_LoadNo
                    Dim iNextSeqNo_Load As Integer = 0
                    Dim k As Integer = 0


                    'WingTech ATT SP ----------------------------------------------
                    If iSelectedCustID = Me._WingTechATT_CustID AndAlso Loc_ID = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_Special_LOC_ID Then
                        Dim objWingTechATT As New PSS.Data.Buisness.WingTechATT.WingTechATT()
                        strMaterPalletName = objWingTechATT.GetWingTechATT_SP_MasterPalletName(iSelectedCustID, PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_Special_LOC_ID)
                        strLoadNo = ""

                        're-compute qty
                        iSP_MP_DevQtyPerBox = iSP_MP_DevQtyPerBox + (4 * iSP_MP_DevQtyPerBox) ' (1 hotspot device plus 4 accessories for each device), so  50 per box
                        iSP_MP_ToalDevQty = iSP_MP_BoxQtyPerMasterBox * iSP_MP_DevQtyPerBox

                        'Save master pallet data
                        k = Me._objWIKO_SP.SaveMasterPallet(strMaterPalletName, strLoadNo, Me._strSP_MP_PO, Me._strSP_MP_MftCustPart, Me._strSP_MP_MftCustPart, _
                                                            Me._strSP_MP_Country, iSP_MP_DevQtyPerBox, iSP_MP_BoxQtyPerMasterBox, iSP_MP_ToalDevQty, _
                                                            iPkslip_ID, iSelectedCustID, PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_Special_LOC_ID, bIsSameDeviceQtyPerBox)

                        'Print master pallet label
                        Me._objWIKO_SP.PrintManifestMasterPalletLabel(strMaterPalletName, Me._strSP_MP_PO, strLoadNo, Me._strSP_MP_MftCustPart, Me._strSP_MP_MftCustPart, _
                                                                      iSP_MP_DevQtyPerBox, iSP_MP_BoxQtyPerMasterBox, iSP_MP_ToalDevQty, 1, bIsSameDeviceQtyPerBox, iSelectedCustID, Me._strSP_MP_Country)
                        objWingTechATT = Nothing
                    Else 'Other SP customers-----------------------------------------
                        'Example: PLT210513D001	PLT2105134001
                        'MPallet_Name, MLoadNo
                        iNextSeqNo_MPallet = Me._objWIKO_SP.GetMasterPalletNextSeqNo(strPreFix_MasterPalletName, iDigitLength, "MPallet_Name")
                        If iNextSeqNo_MPallet = 0 Then Throw New Exception("System has failed to get next master pallet number.")
                        strMaterPalletName = strMaterPalletName & iNextSeqNo_MPallet.ToString.PadLeft(iDigitLength, "0")

                        iNextSeqNo_Load = Me._objWIKO_SP.GetMasterPalletNextSeqNo(strPreFix_LoadNo, iDigitLength, "MLoadNo")
                        If iNextSeqNo_Load = 0 Then Throw New Exception("System has failed to get next master pallet number.")
                        strLoadNo = strLoadNo & iNextSeqNo_Load.ToString.PadLeft(iDigitLength, "0")

                        'Save master pallet data
                        k = Me._objWIKO_SP.SaveMasterPallet(strMaterPalletName, strLoadNo, Me._strSP_MP_PO, Me._strSP_MP_MftCustPart, Me._strSP_MP_MftCustPart, _
                                                            Me._strSP_MP_Country, iSP_MP_DevQtyPerBox, iSP_MP_BoxQtyPerMasterBox, iSP_MP_ToalDevQty, _
                                                            iPkslip_ID, iSelectedCustID, Me._iWIKO_SP_LocID, bIsSameDeviceQtyPerBox)

                        'Print master pallet label
                        Me._objWIKO_SP.PrintManifestMasterPalletLabel(strMaterPalletName, Me._strSP_MP_PO, strLoadNo, Me._strSP_MP_MftCustPart, Me._strSP_MP_MftCustPart, _
                                                                      iSP_MP_DevQtyPerBox, iSP_MP_BoxQtyPerMasterBox, iSP_MP_ToalDevQty, 1, bIsSameDeviceQtyPerBox, iSelectedCustID, "Vietnam")

                    End If

                ElseIf iSelectedCustID = Me._WIKO_CustID _
                 OrElse iSelectedCustID = Me._WingTechATT_CustID _
                OrElse iSelectedCustID = Me._Vinsmart_CustID Then
                    Dim dtPallett As DataTable = Me._objSPPLF.getPallett_Id(iPkslip_ID)
                    Dim iloc_id As Integer = dtPallett.Rows(0)("Loc_id")
                    Dim iPallett_ShipType As Integer = dtPallett.Rows(0)("Pallet_ShipType")
                    Dim strAccount As String = dtPallett.Rows(0)("Account")
                    If dtPallett.Rows.Count > 0 Then
                        Me._objSPPLF.UpdateMExtendedWarranty(iShipCarrier, strTrackingNo, iPkslip_ID)
                    End If

                    Me._objSPPLF.printManifest(iPkslip_ID, iloc_id, iPallett_ShipType, strAccount)
                    If iloc_id = PSS.Data.Buisness.WIKO.WIKO.WIKO_AttCricket_LOC_ID _
                    OrElse iloc_id = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCricket_LOC_ID _
                    OrElse iloc_id = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttCricket_LOC_ID Then
                        Me._objSPPLF.CreateCricket_ASN(iPkslip_ID, iloc_id)
                    Else
                        Me._objSPPLF.CreateATT_ASN(iPkslip_ID, iloc_id)
                    End If

                    GoTo M
                    '    'Added by Amazech-Thanga 07.08.2021
                    'ElseIf iSelectedCustID = _WingTechATT_custId Then
                    '    Dim dtPallett As DataTable = Me._objSPPLF.getPallett_Id(iPkslip_ID)
                    '    Dim iloc_id As Integer = dtPallett.Rows(0)("Loc_id")
                    '    If dtPallett.Rows.Count > 0 Then
                    '        Me._objSPPLF.UpdateMExtendedWarranty(iShipCarrier, strTrackingNo, iPkslip_ID)
                    '    End If

                    '    Me._objSPPLF.printManifest_WingTechATT(iPkslip_ID, iloc_id)
                    '    If iloc_id = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCricket_LOC_ID Then
                    '        Me._objSPPLF.CreateCricket_ASN(iPkslip_ID, iloc_id)
                    '    Else
                    '        Me._objSPPLF.CreateATT_ASN(iPkslip_ID, iloc_id)
                    '    End If

                    '    GoTo M
                End If
                '*************************************
                'Print Report (Menifest ModelFreq Rpt)
                '*************************************

                objMessLabel = New PSS.Data.Buisness.MessLabel()
                If objMessLabel.IsAMSShareableInventoryCustomer(Me.cmbCustomers.SelectedValue) _
                   OrElse Me.cmbCustomers.SelectedValue = PSS.Data.Buisness.SkyTel.Anna_CUSTOMER_ID _
                   OrElse Me.cmbCustomers.SelectedValue = PSS.Data.Buisness.SkyTel.Lahey_CUSTOMER_ID _
                   OrElse Me.cmbCustomers.SelectedValue = PSS.Data.Buisness.SkyTel.Masco_CUSTOMER_ID _
                   OrElse Me.cmbCustomers.SelectedValue = PSS.Data.Buisness.SkyTel.Franciscan_CUSTOMER_ID _
                   OrElse Me.cmbCustomers.SelectedValue = PSS.Data.Buisness.SkyTel.Maine_CUSTOMER_ID _
                   OrElse Me.cmbCustomers.SelectedValue = PSS.Data.Buisness.SkyTel.SMHC_CUSTOMER_ID Then
                    Me._objSPPLF.PrintManifestModelFreqLabel(iPkslip_ID, 1)
                End If

                '************************************
                'Reset controls and global variables
                '************************************
M:
                Me._dtPSPallet.Rows.Clear()
                Me._iManifestNum = 0

                Me.lstPSPalletName.Items.Clear() : Me.lstPSPalletName.Refresh()
                Me.lblPSQty.Text = Me._dtPSPallet.Rows.Count
                Me.txtPSPalletNumber.Text = "" : Me.lblNoteDesc.Text = ""
                Me._bIsSP_MP = False : Me._strSP_MP_Country = ""
                Me._strSP_MP_PO = "" : Me._iSP_MP_ModelID = 0 : Me._strSP_MP_MftCustPart = ""

                Me.txtSkidQty.Text = "" : Me.txtCartonQty.Text = ""
                Me.gbShipCarrierInfo.Visible = False : Me.cboCarrierType.SelectedValue = 0 : Me.txtTrackingNo.Text = "" : Me.txtShippingCost.Text = ""
                'Amazech- Thanga 07.07.2021, 08.07.2021
                If Me.cmbCustomers.SelectedValue = _Coolpad_CustID Or Me.cmbCustomers.SelectedValue = _WIKO_CustID Or Me.cmbCustomers.SelectedValue = _WingTech_CustID Or Me.cmbCustomers.SelectedValue = _WingTechATT_CustID Then
                    Me.gbShipCarrierInfo.Visible = True
                End If
                Me.txtPSPalletNumber.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Create Manifest", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True : Cursor.Current = Cursors.Default
            Me.txtPSPalletNumber.Focus()
            PSS.Data.Buisness.Generic.DisposeDT(dt)
            drArr = Nothing : arrlstPalletNames = Nothing : objMessLabel = Nothing
        End Try
    End Sub

    Private Function IsQtyCorrectAndGetQty(ByRef iSP_MP_DevQtyPerBox As Integer, ByRef iSP_MP_BoxQtyPerMasterBox As Integer, _
                                       ByRef iSP_MP_ToalDevQty As Integer, ByRef bIsSameDeviceQtyPerBox As Boolean) As Boolean
        Dim strPallett_IDs As String = ""
        Dim row As DataRow
        Dim iTotalBoxDeviceQty As Integer = 0
        Dim iTotalDeviceQty As Integer = 0
        Dim bRet As Boolean = False

        'Get all pallet IDs 
        For Each row In Me._dtPSPallet.Rows
            If strPallett_IDs.Trim.Length = 0 Then
                strPallett_IDs = row("Pallett_ID")
            Else
                strPallett_IDs &= "," & row("Pallett_ID")
            End If
        Next

        'Box count
        iSP_MP_BoxQtyPerMasterBox = Me._dtPSPallet.Rows.Count

        iTotalBoxDeviceQty = Me._objWIKO_SP.getSP_MP_PalletQty(strPallett_IDs, iSP_MP_DevQtyPerBox, bIsSameDeviceQtyPerBox)
        iTotalDeviceQty = Me._objWIKO_SP.getSP_MP_DeviceQty(strPallett_IDs)

        If iTotalBoxDeviceQty = iTotalDeviceQty Then
            iSP_MP_ToalDevQty = iTotalDeviceQty
            bRet = True
        End If

        Return bRet
    End Function
    '*******************************************************************


    Private Sub txtPSPalletNumber_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPSPalletNumber.KeyUp
        Dim iWOID As Integer = 0
        Dim R1 As DataRow
        Dim dtPalletInfo As DataTable
        Dim dtModel As New DataTable()
        Dim iModel_ID, iModel_ID2 As Integer
        Dim iPallet_ID As Integer = 0

        If e.KeyValue = 13 Then

            Try
                If Me.txtPSPalletNumber.Text.Trim = "" Then
                    Exit Sub
                ElseIf Me.cmbCustomers.SelectedValue = 0 Then
                    MessageBox.Show("Please Select Customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.cmbCustomers.SelectAll() : Me.cmbCustomers.Focus()
                ElseIf Me._dtPSPallet.Select("Pallett_Name = '" & Me.txtPSPalletNumber.Text.Trim & "'").Length > 0 Then
                    '***********************
                    'check for duplicate
                    '***********************
                    MessageBox.Show("This pallet/Lot Number is already scanned in.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtPSPalletNumber.Text = "" : Me.txtPSPalletNumber.Focus()
                Else
                    If Me._dtPSPallet.Rows.Count > 0 Then iWOID = Me._dtPSPallet.Rows(0)("WO_ID")
                    '****************************************
                    'check if pallet already has packing slip
                    '****************************************
                    dtPalletInfo = Me._objSPPLF.ValidateShippedPallet(Trim(Me.txtPSPalletNumber.Text), Me.cmbCustomers.SelectedValue, iWOID)
                    If IsNothing(dtPalletInfo) OrElse dtPalletInfo.Rows.Count = 0 Then
                        'MessageBox.Show("Pallet ID is not defined.", "Get Pallett ID", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.txtPSPalletNumber.Text = "" : Me.txtPSPalletNumber.Focus()
                    Else

                        If Me.cmbCustomers.SelectedValue = _Vivint_CustId AndAlso lstPSPalletName.Items.Count <> 0 Then
                            If _objSPPLF.CheckModel(Trim(Me.txtPSPalletNumber.Text), _Vivint_LocID) <> _objSPPLF.CheckModel(Trim(lstPSPalletName.Items.Item(0)), _Vivint_LocID) Then
                                MessageBox.Show("This pallet/Lot Number must have the same Model/Item SKU", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                Exit Sub
                            End If

                        ElseIf (Me.cmbCustomers.SelectedValue = Me._WIKO_CustID AndAlso dtPalletInfo.Rows(0).Item("Loc_ID") = Me._iWIKO_SP_LocID) _
                                OrElse (Me.cmbCustomers.SelectedValue = Me._Vinsmart_CustID AndAlso dtPalletInfo.Rows(0).Item("Loc_ID") = Me._iVinsmart_SP_LocID) _
                                OrElse (Me.cmbCustomers.SelectedValue = Me._WingTechATT_CustID AndAlso dtPalletInfo.Rows(0).Item("Loc_ID") = Me._iWingTechATT_SP_LocID) Then  ' if WIKo and SP Loc ID. Validate and handle WIKO SP Teller Box
                            Dim dt As DataTable, strTeller As String = ""
                            iPallet_ID = dtPalletInfo.Rows(0)("Pallett_ID")
                            'Account, Pallett_Name, Cntry_Name, OEM_RA, Cust_PO, Model_ID, loc_ID, Pallett_ID, Pallett_Qty, Qty,QtyOk_Yes0No1
                            If dtPalletInfo.Rows(0).Item("Loc_ID") = Me._iWingTechATT_SP_LocID Then
                                dt = Me._objWIKO_SP.getWingTechAttGenericProcessPalletDataForSP_MP(iPallet_ID, "SP_Generic", "India") 'For WingTech SP and required MP
                            Else
                                dt = Me._objWIKO_SP.getWiKoPalletDataForSP_MP(iPallet_ID) 'For all SP and required MP
                            End If

                            If lstPSPalletName.Items.Count = 0 AndAlso dt.Rows.Count = 1 Then 'first scanned box
                                If Not dt.Rows(0).IsNull("Account") AndAlso (Convert.ToString(dt.Rows(0).Item("Account")).Trim.ToUpper = PSS.Data.Buisness.WIKO.WIKO.WIKO_SpecialProj_Type2.Trim.ToUpper _
                                       OrElse Convert.ToString(dt.Rows(0).Item("Account")).Trim.ToUpper = PSS.Data.Buisness.WIKO.WIKO.WIKO_SpecialProj_Type3.Trim.ToUpper _
                                       OrElse Convert.ToString(dt.Rows(0).Item("Account")).Trim.ToUpper = PSS.Data.Buisness.WIKO.WIKO.WIKO_SpecialProj_Type4.Trim.ToUpper _
                                       OrElse Convert.ToString(dt.Rows(0).Item("Account")).Trim.ToUpper = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_SpecialProj_Type1.Trim.ToUpper _
                                       OrElse Convert.ToString(dt.Rows(0).Item("Account")).Trim.ToUpper = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_SpecialProj_Type2.Trim.ToUpper _
                                       OrElse Convert.ToString(dt.Rows(0).Item("Account")).Trim.ToUpper = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_SpecialProj_Type1.Trim.ToUpper) Then

                                    If getValidString(dt.Rows(0), "Cntry_Name").Length = 0 Then MessageBox.Show("No country!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) : Exit Sub
                                    If getValidString(dt.Rows(0), "Cust_PO").Length = 0 Then MessageBox.Show("No PO!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) : Exit Sub
                                    If Not dt.Rows(0).Item("Model_ID") > 0 Then MessageBox.Show("Invalid model_ID!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) : Exit Sub
                                    If Not dt.Rows(0).Item("QtyOk_Yes0No1") = 0 Then MessageBox.Show("The box qty is not equal to the device qty! See IT", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) : Exit Sub

                                    Me._strSP_MP_Country = getValidString(dt.Rows(0), "Cntry_Name")
                                    Me._strSP_MP_PO = getValidString(dt.Rows(0), "Cust_PO")
                                    Me._iSP_MP_ModelID = dt.Rows(0).Item("Model_ID")
                                    Me._strSP_MP_MftCustPart = getValidString(dt.Rows(0), "OEM_RA")
                                    Me._bIsSP_MP = True
                                    If Me.cmbCustomers.SelectedValue = Me._WIKO_CustID Then Me.lblNoteDesc.Text = "WiKo SP box for building Master Pallet"
                                    If Me.cmbCustomers.SelectedValue = Me._Vinsmart_CustID Then Me.lblNoteDesc.Text = "Vinsmart SP box for building Master Pallet"
                                    If Me.cmbCustomers.SelectedValue = Me._WingTechATT_CustID Then Me.lblNoteDesc.Text = "WingTechATT SP box for building Master Pallet"
                                Else
                                    Me._bIsSP_MP = False
                                End If
                            ElseIf lstPSPalletName.Items.Count = 0 AndAlso dt.Rows.Count > 1 Then 'validated  box 
                                Dim row1 As DataRow, bFoundSP_MP As Boolean = False
                                If Me.cmbCustomers.SelectedValue = Me._WIKO_CustID Then
                                    For Each row1 In dt.Rows
                                        If getValidString(row1, "Account").ToUpper = PSS.Data.Buisness.WIKO.WIKO.WIKO_SpecialProj_Type2.Trim.ToUpper _
                                           OrElse getValidString(row1, "Account").ToUpper = PSS.Data.Buisness.WIKO.WIKO.WIKO_SpecialProj_Type3.Trim.ToUpper _
                                           OrElse getValidString(row1, "Account").ToUpper = PSS.Data.Buisness.WIKO.WIKO.WIKO_SpecialProj_Type4.Trim.ToUpper Then
                                            bFoundSP_MP = True : Exit For
                                        End If
                                    Next
                                ElseIf Me.cmbCustomers.SelectedValue = Me._Vinsmart_CustID Then
                                    For Each row1 In dt.Rows
                                        If getValidString(row1, "Account").ToUpper = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_SpecialProj_Type1.Trim.ToUpper _
                                             OrElse getValidString(row1, "Account").ToUpper = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_SpecialProj_Type2.Trim.ToUpper Then
                                            bFoundSP_MP = True : Exit For
                                        End If
                                    Next
                                ElseIf Me.cmbCustomers.SelectedValue = Me._WingTechATT_CustID Then
                                    For Each row1 In dt.Rows
                                        If getValidString(row1, "Account").ToUpper = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_SpecialProj_Type1.Trim.ToUpper Then
                                            bFoundSP_MP = True : Exit For
                                        End If
                                    Next
                                End If
                                If bFoundSP_MP Then MessageBox.Show("It is SP MP box, but invalid box. See IT!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) : Exit Sub
                            ElseIf Me._bIsSP_MP AndAlso lstPSPalletName.Items.Count > 0 AndAlso dt.Rows.Count = 1 Then 'the 1st box is Teller, the rest must be Teller
                                If Not dt.Rows(0).IsNull("Account") AndAlso (Convert.ToString(dt.Rows(0).Item("Account")).Trim.ToUpper = PSS.Data.Buisness.WIKO.WIKO.WIKO_SpecialProj_Type2.Trim.ToUpper _
                                     OrElse Convert.ToString(dt.Rows(0).Item("Account")).Trim.ToUpper = PSS.Data.Buisness.WIKO.WIKO.WIKO_SpecialProj_Type3.Trim.ToUpper _
                                     OrElse Convert.ToString(dt.Rows(0).Item("Account")).Trim.ToUpper = PSS.Data.Buisness.WIKO.WIKO.WIKO_SpecialProj_Type4.Trim.ToUpper _
                                     OrElse Convert.ToString(dt.Rows(0).Item("Account")).Trim.ToUpper = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_SpecialProj_Type1.Trim.ToUpper _
                                     OrElse Convert.ToString(dt.Rows(0).Item("Account")).Trim.ToUpper = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_SpecialProj_Type2.Trim.ToUpper _
                                     OrElse Convert.ToString(dt.Rows(0).Item("Account")).Trim.ToUpper = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_SpecialProj_Type1.Trim.ToUpper) Then

                                    If getValidString(dt.Rows(0), "Cntry_Name").Length = 0 Then MessageBox.Show("No country!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) : Exit Sub
                                    If getValidString(dt.Rows(0), "Cust_PO").Length = 0 Then MessageBox.Show("No PO!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) : Exit Sub
                                    If Not dt.Rows(0).Item("Model_ID") > 0 Then MessageBox.Show("Invalid model_ID!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) : Exit Sub
                                    If Not dt.Rows(0).Item("QtyOk_Yes0No1") = 0 Then MessageBox.Show("The pallet qty is not equal to the device qty! See IT", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) : Exit Sub

                                    If getValidString(dt.Rows(0), "Cntry_Name") <> Me._strSP_MP_Country Then MessageBox.Show("No the same country!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) : Exit Sub
                                    If getValidString(dt.Rows(0), "Cust_PO") <> Me._strSP_MP_PO Then MessageBox.Show("No the same PO!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) : Exit Sub
                                    If dt.Rows(0).Item("Model_ID") <> Me._iSP_MP_ModelID Then MessageBox.Show("No the same SKU (model)!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) : Exit Sub
                                Else
                                    MessageBox.Show("Not a SP Box for Master Pallet!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) : Exit Sub
                                End If
                            ElseIf Me._bIsSP_MP AndAlso lstPSPalletName.Items.Count > 0 AndAlso dt.Rows.Count > 1 Then ' invalid if SP MP box
                                Dim row1 As DataRow, bFoundSP_MP As Boolean = False
                                If Me.cmbCustomers.SelectedValue = Me._WIKO_CustID Then
                                    For Each row1 In dt.Rows
                                        If getValidString(row1, "Account").ToUpper = PSS.Data.Buisness.WIKO.WIKO.WIKO_SpecialProj_Type2.Trim.ToUpper _
                                           OrElse getValidString(row1, "Account").ToUpper = PSS.Data.Buisness.WIKO.WIKO.WIKO_SpecialProj_Type3.Trim.ToUpper _
                                           OrElse getValidString(row1, "Account").ToUpper = PSS.Data.Buisness.WIKO.WIKO.WIKO_SpecialProj_Type4.Trim.ToUpper Then
                                            bFoundSP_MP = True : Exit For
                                        End If
                                    Next
                                ElseIf Me.cmbCustomers.SelectedValue = Me._Vinsmart_CustID Then
                                    For Each row1 In dt.Rows
                                        If getValidString(row1, "Account").ToUpper = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_SpecialProj_Type1.Trim.ToUpper _
                                             OrElse getValidString(row1, "Account").ToUpper = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_SpecialProj_Type2.Trim.ToUpper Then
                                            bFoundSP_MP = True : Exit For
                                        End If
                                    Next
                                ElseIf Me.cmbCustomers.SelectedValue = Me._WingTechATT_CustID Then
                                    For Each row1 In dt.Rows
                                        If getValidString(row1, "Account").ToUpper = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_SpecialProj_Type1.Trim.ToUpper Then
                                            bFoundSP_MP = True : Exit For
                                        End If
                                    Next
                                End If
                                If bFoundSP_MP Then MessageBox.Show("It is a SP Box for Master Pallet, but invalid box. See IT!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) : Exit Sub
                            End If
                            ElseIf Me._bIsSP_MP AndAlso (dtPalletInfo.Rows(0).Item("Loc_ID") <> Me._iWIKO_SP_LocID _
                                OrElse dtPalletInfo.Rows(0).Item("Loc_ID") <> Me._iVinsmart_SP_LocID _
                                OrElse dtPalletInfo.Rows(0).Item("Loc_ID") <> Me._iWingTechATT_SP_LocID) Then   'Not the same SP MP box
                                MessageBox.Show("Not a SP Box for Master Pallet!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                Exit Sub
                            End If

                            R1 = Me._dtPSPallet.NewRow
                            R1("Pallett_Name") = Trim(Me.txtPSPalletNumber.Text)
                            R1("Pallett_ID") = dtPalletInfo.Rows(0)("Pallett_ID")
                            R1("WO_ID") = dtPalletInfo.Rows(0)("WO_ID")
                            Me._dtPSPallet.Rows.Add(R1)
                            Me._dtPSPallet.AcceptChanges()
                            Me.lstPSPalletName.Items.Add(Trim(Me.txtPSPalletNumber.Text))
                            Me.lblPSQty.Text = Me._dtPSPallet.Rows.Count
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                Me.txtPSPalletNumber.SelectAll()
            Finally
                Me.txtPSPalletNumber.Text = ""
                R1 = Nothing
            End Try
        End If
    End Sub

    Private Function getValidString(ByVal dRow As DataRow, ByVal strColName As String) As String
        If dRow.IsNull(strColName) Then
            Return ""
        Else
            Return Convert.ToString(dRow.Item(strColName)).Trim
        End If
    End Function

    '*******************************************************************
    Private Sub cmdPSClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPSClear.Click
        Dim strDeletePalletName As String
        Dim iIndex As Integer = 0
        Dim R1 As DataRow

        Try
            If Me.lstPSPalletName.Items.Count = 0 Then
                Exit Sub
            End If

            'Get Pallet to be delete
            strDeletePalletName = Trim(InputBox("Pallet Name:", "Remove item From List"))

            If strDeletePalletName = "" Then
                Exit Sub
            End If

            iIndex = Me.lstPSPalletName.Items.IndexOf(strDeletePalletName)

            If iIndex = -1 Then
                MessageBox.Show("Item does not exist in list", "Remove item From List", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtFileName.Focus()
                Exit Sub
            End If

            'Delete from datatable
            For Each R1 In Me._dtPSPallet.Rows
                If R1("Pallett_Name").ToString.Trim.ToUpper = strDeletePalletName.Trim.ToUpper Then
                    If Me._iManifestNum > 0 Then
                        If Not IsDBNull(R1("pkslip_ID")) AndAlso R1("pkslip_ID") > 0 Then
                            Me._objSPPLF.RemoveManifestNumFrPallets(Me.cmbCustomers.SelectedValue, R1("Pallett_ID").ToString, Me._iUserID, Me._iManifestNum)
                        End If
                    End If
                    R1.Delete()
                    Exit For
                End If
            Next R1
            Me._dtPSPallet.AcceptChanges()

            'Delete from list
            Me.lstPSPalletName.Items.RemoveAt(iIndex)
            Me.lstPSPalletName.Refresh()

            'Reset counter
            Me.lblPSQty.Text = Me._dtPSPallet.Rows.Count
            Me.txtPSPalletNumber.Text = ""
            Me.txtPSPalletNumber.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Remove Item From List", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            R1 = Nothing
        End Try
    End Sub

    '*******************************************************************
    Private Sub cmdPSClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPSClearAll.Click
        Dim R1 As DataRow
        Dim strPallettIDs As String = ""

        Try
            If Me._dtPSPallet.Rows.Count > 0 Then
                If Me._iManifestNum > 0 Then
                    '*********************************
                    'Get all pallet ID
                    '*********************************
                    For Each R1 In Me._dtPSPallet.Rows
                        If strPallettIDs = "" Then
                            strPallettIDs = R1("Pallett_ID")
                        Else
                            strPallettIDs &= ", " & R1("Pallett_ID")
                        End If
                    Next R1
                    '*********************************
                    'Remove manifest number from pallet
                    '*********************************
                    Me._objSPPLF.RemoveManifestNumFrPallets(Me.cmbCustomers.SelectedValue, strPallettIDs, Me._iUserID, Me._iManifestNum)
                End If

                '*********************************
                'Reset controls and global variables
                '*********************************
                Me._dtPSPallet.Rows.Clear()
                Me.lstPSPalletName.Items.Clear()
                Me.lstPSPalletName.Refresh()
                Me.lblPSQty.Text = Me._dtPSPallet.Rows.Count
                Me.txtPSPalletNumber.Text = ""
                Me.txtPSPalletNumber.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Clear All Items", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            R1 = Nothing
        End Try
    End Sub

    '*******************************************************************
    Private Sub btnPSReprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPSReprint.Click
        Dim strPkslip_ID As String
        Dim iCustID As Integer = 0
        '_objSPPLF.GenerateRvi(48873)
        Try

            strPkslip_ID = InputBox("Manifest Number:", "Get Manifest Number").ToString.Trim

            If strPkslip_ID = "" Then
                Me.txtPSPalletNumber.Focus() : Exit Sub
            End If

            Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
            iCustID = Me._objSPPLF.GetCustomerIDByPackingSlipID(strPkslip_ID)
            If iCustID = _Vivint_CustId Then
                _objSPPLF.PrintManifest_Vivint(strPkslip_ID)
            ElseIf (iCustID = _WIKO_CustId) Then
                Dim dtPallett As DataTable = Me._objSPPLF.getPallett_Id(strPkslip_ID)
                Dim iloc_id As Integer = dtPallett.Rows(0)("Loc_id")
                Dim iPallett_ShipType As Integer = dtPallett.Rows(0)("Pallet_ShipType")
                Dim strAccount As String = dtPallett.Rows(0)("Account")
                _objSPPLF.printManifest(strPkslip_ID, iloc_id, iPallett_ShipType, strAccount)
            ElseIf (iCustID = _WingTechATT_custId) Then
                Dim dtPallett As DataTable = Me._objSPPLF.getPallett_Id(strPkslip_ID)
                Dim iloc_id As Integer = dtPallett.Rows(0)("Loc_id")
                _objSPPLF.printManifest_WingTechATT(strPkslip_ID, iloc_id)
            ElseIf (iCustID = _Coolpad_CustId) Then

                _objSPPLF.PrintManifestCoolpad(strPkslip_ID, _Coolpad_CustId)
                'Added by Amazech-Thanga 07.07.2021
            ElseIf (iCustID = _WingTech_CustId) Then

                _objSPPLF.PrintManifestWingTech(strPkslip_ID, _WingTech_CustId)
            Else
                Me._objSPPLF.PrintShipPackingSlip(CInt(strPkslip_ID), iCustID)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Reprint Manifest", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True : Cursor.Current = Cursors.Default
            Me.txtPSPalletNumber.Focus()
        End Try
    End Sub

    '*******************************************************************
    Private Sub btnEditManifest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditManifest.Click

        Dim strManifest_Num As String
        Dim dt1 As DataTable
        Dim R1 As DataRow
        Dim drNewRow As DataRow

        Try
            strManifest_Num = InputBox("Manifest Number:", "Get Manifest Number").ToString.Trim

            If strManifest_Num = "" Then
                Me.txtPSPalletNumber.Focus()
                Exit Sub
            End If

            '***********************************
            'Reset controls and global variable
            '***********************************
            Me.txtPSPalletNumber.Text = ""
            Me.lstPSPalletName.Items.Clear()
            Me.lstPSPalletName.Refresh()
            Me.lblPSQty.Text = Me._dtPSPallet.Rows.Count
            Me._dtPSPallet.Rows.Clear()
            Me._iManifestNum = 0

            '***********************************
            'Validate Manifest
            '***********************************
            dt1 = Me._objSPPLF.GetManifestInfo(CInt(strManifest_Num))
            If IsNothing(dt1) = True Then
                MessageBox.Show("Manifest does not exist.", "Edit Manifest", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtPSPalletNumber.Focus()
                Exit Sub
            ElseIf dt1.Rows.Count = 0 Then
                MessageBox.Show("Manifest does not exist.", "Edit Manifest", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtPSPalletNumber.Focus()
                Exit Sub
            Else
                If Not IsDBNull(dt1.Rows(0)("pkslip_invoiceDt")) Then
                    MessageBox.Show("Manifest has been invoiced. Can't edit.", "Edit Manifest", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtPSPalletNumber.Focus()
                    Exit Sub
                End If
            End If

            PSS.Data.Buisness.Generic.DisposeDT(dt1)

            '***********************************
            'Get Pallets
            '***********************************
            dt1 = Me._objSPPLF.GetPalletInfoByPackingSlipID(CInt(strManifest_Num))

            If dt1.Rows.Count > 0 Then
                Me._iManifestNum = CInt(strManifest_Num)
                Me.cmbCustomers.SelectedValue = dt1.Rows(0)("Cust_ID")
                If Not IsDBNull(dt1.Rows(0)("SC_ID")) Then Me.cboCarrierType.SelectedValue = Convert.ToInt64(dt1.Rows(0)("SC_ID"))
                If Not IsDBNull(dt1.Rows(0)("pkslip_TrackNo")) Then Me.txtTrackingNo.Text = dt1.Rows(0)("pkslip_TrackNo").ToString.Trim
                If Not IsDBNull(dt1.Rows(0)("ShipmentCost")) Then Me.txtShippingCost.Text = dt1.Rows(0)("ShipmentCost").ToString.Trim

                For Each R1 In dt1.Rows
                    drNewRow = Me._dtPSPallet.NewRow
                    drNewRow("pkslip_ID") = R1("pkslip_ID")
                    drNewRow("Pallett_ID") = R1("Pallett_ID")
                    drNewRow("Pallett_Name") = R1("Pallett_Name")
                    Me._dtPSPallet.Rows.Add(drNewRow)
                    Me._dtPSPallet.AcceptChanges()
                    drNewRow = Nothing

                    Me.lstPSPalletName.Items.Add(R1("Pallett_Name"))
                    Me.lblPSQty.Text = Me._dtPSPallet.Rows.Count
                Next R1
            End If

            'Jabil
            If Me.cmbCustomers.SelectedValue = 2462 Then Me.gbShipCarrierInfo.Visible = True Else Me.gbShipCarrierInfo.Visible = False

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Edit Manifest", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            R1 = Nothing
            PSS.Data.Buisness.Generic.DisposeDT(dt1)
            Me.txtPSPalletNumber.Focus()
        End Try
    End Sub

    '*******************************************************************
    Private Sub txtSkidQty_txtCartonPkgQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSkidQty.KeyPress, txtCartonQty.KeyPress
        Try
            If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then e.Handled = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtSkidQty_txtCartonPkgQty_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*******************************************************************
    Private Sub txtShippingCost_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtShippingCost.KeyPress
        Try
            If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso e.KeyChar.ToString <> "." Then
                e.Handled = True
            ElseIf Me.txtShippingCost.Text.Trim.IndexOf(".") > -1 AndAlso e.KeyChar.ToString = "." Then
                e.Handled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtShippingCost_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************************************************************************************************
    Private Sub btnReprintModelFreqRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintModelFreqRpt.Click
        Dim iPkslipID As Integer = 0
        Dim dt As DataTable

        Try
            iPkslipID = CInt(InputBox("Enter Manifest #:").Trim)
            If iPkslipID > 0 Then
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                'Print manifest ModelFreq
                Me._objSPPLF.PrintManifestModelFreqLabel(iPkslipID, 1)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnReprintModelFreqRpt_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True : Cursor.Current = Cursors.Default
        End Try
    End Sub

    '******************************************************************************************************************************************************
    Private Sub btnReprintWiKoSPTellerMasterPalletLabel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReprintWiKoSPTellerMasterPalletLabel.Click

        Dim strPkslip_ID As String
        Dim iCustID As Integer = Me.cmbCustomers.SelectedValue
        Dim iLocID As Integer = PSS.Data.Buisness.WIKO.WIKO.WIKO_Special_LOC_ID
        Dim iDefault_pkSlip_ID As Integer = 0
        Dim dt As DataTable
        Dim k As Integer = 0
        Dim bIsdameDeviceQtyPerBox As Boolean = True

        Try
            iDefault_pkSlip_ID = Me._objWIKO_SP.getWIKO_SpTellerManifest_MostRecent_pkSlipID

            If iDefault_pkSlip_ID > 0 Then
                strPkslip_ID = InputBox(" Manifest Number for SP MP Proccess" & Environment.NewLine & " (most recent manifest number as default if avaiable):", "Manifest Number", iDefault_pkSlip_ID.ToString).ToString.Trim
            Else
                strPkslip_ID = InputBox("Manifest Number for SP MP Proccess:", "Manifest Number", "").ToString.Trim
            End If

            If strPkslip_ID = "" Then
                Me.txtPSPalletNumber.Focus() : Exit Sub
            ElseIf Not IsNumeric(strPkslip_ID) Then
                MessageBox.Show("Invalid manifest number.", "Reprint Manifest Master Pallet Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'get Master Pallet Label data
            dt = Me._objWIKO_SP.getSP_MP_ManifestMasterPalletData(strPkslip_ID)

            If dt.Rows.Count = 0 Then
                MessageBox.Show("Either no master pallet label data or not a WIKO-SP-Teller-process manifest number.", "Reprint Manifest Master Pallet Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Else
                'Print master pallet label
                'MPallet_ID, MPallet_Name, MLoadNo, PO, Desc1, Desc2, Desc3, Qty1, Qty2, Qty3, pkslip_ID, Cust_ID, Loc_ID,IsSameQtyPerBox, pkslip_createDt
                If Convert.ToInt32(dt.Rows(0).Item("IsSameQtyPerBox")) = 0 Then bIsdameDeviceQtyPerBox = False
                Me._objWIKO_SP.PrintManifestMasterPalletLabel(dt.Rows(0).Item("MPallet_Name"), dt.Rows(0).Item("PO"), dt.Rows(0).Item("MLoadNo"), dt.Rows(0).Item("Desc1"), dt.Rows(0).Item("Desc2"), _
                                                               dt.Rows(0).Item("Qty1"), dt.Rows(0).Item("Qty2"), dt.Rows(0).Item("Qty3"), 1, bIsdameDeviceQtyPerBox, iCustID, "Vietnam")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtShippingCost_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub txtMasterPallet_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMasterPallet.KeyUp
        Dim strMPallet As String = ""
        Dim dt As DataTable
        Dim iCartonWeight As Integer = 0
        Dim i As Integer = 0
        Dim strAccount As String = ""

        Try
            If e.KeyValue = 13 AndAlso Me.txtMasterPallet.Text.Trim.Length > 0 Then
                strMPallet = Me.txtMasterPallet.Text.Trim
                If IsNumeric(Me.txtCartonWeight.Text) Then iCartonWeight = Me.txtCartonWeight.Text Else iCartonWeight = Me._iDefaultCartonWeight

                If Me.cmbCustomers.SelectedValue = Me._WingTechATT_CustID Then
                    dt = Me._objWIKO_SP.getGenericProcess_WingTechAttSPManifestMasterPalletDetailedData("'" & strMPallet & "'", iCartonWeight)
                    strAccount = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_SpecialProj_Type1
                    Me.lblAccount.Text = strAccount
                Else
                    If Me.lstMPallets.Items.Count = 0 Then 'get account

                        strAccount = Me._objWIKO_SP.getWIKO_SpTellerManifestMasterPalletAccount(strMPallet)

                        If strAccount.Trim.ToUpper = PSS.Data.Buisness.WIKO.WIKO.WIKO_SpecialProj_Type2.Trim.ToUpper _
                           OrElse strAccount.Trim.ToUpper = PSS.Data.Buisness.WIKO.WIKO.WIKO_SpecialProj_Type3.Trim.ToUpper _
                           OrElse strAccount.Trim.ToUpper = PSS.Data.Buisness.WIKO.WIKO.WIKO_SpecialProj_Type4.Trim.ToUpper _
                           OrElse strAccount.Trim.ToUpper = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_SpecialProj_Type1.Trim.ToUpper _
                           OrElse strAccount.Trim.ToUpper = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_SpecialProj_Type2.Trim.ToUpper Then
                            Me.lblAccount.Text = strAccount
                        Else
                            MessageBox.Show("Can't find  account/pallet data for '" & strMPallet & "', or the account is not defined.", "Manifest", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Me.lblAccount.Text = "" : Me.txtMasterPallet.SelectAll() : Me.txtMasterPallet.Focus() : Exit Sub
                        End If
                    Else
                        strAccount = Me._objWIKO_SP.getWIKO_SpTellerManifestMasterPalletAccount(strMPallet)
                        If strAccount.Trim.Length = 0 Then
                            MessageBox.Show("Can't find  account for '" & strMPallet & "', or the account is not defined.", "Manifest", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Me.txtMasterPallet.SelectAll() : Me.txtMasterPallet.Focus() : Exit Sub
                        ElseIf Not strAccount.Trim.ToUpper = Me.lblAccount.Text.Trim.ToUpper Then
                            MessageBox.Show("This master pallet '" & strMPallet & "' is '" & strAccount & "' account, not the '" & Me.lblAccount.Text & "' account .", "Manifest", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Me.txtMasterPallet.SelectAll() : Me.txtMasterPallet.Focus() : Exit Sub
                        End If
                    End If

                    dt = Me._objWIKO_SP.getWIKO_SpTellerManifestMasterPalletDetailedData("'" & strMPallet & "'", iCartonWeight, strAccount)
                End If

                If Not dt.Rows.Count > 0 Then
                    MessageBox.Show("Can't find  master pallet '" & strMPallet & "'", "Manifest", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.lblAccount.Text = "" : Me.txtMasterPallet.SelectAll() : Me.txtMasterPallet.Focus() : Exit Sub
                End If

                If Me.lstMPallets.Items.Count = 0 Then
                    Me.lstMPallets.Items.Add(strMPallet)
                    Me.txtMasterPallet.Text = "" : Me.txtMasterPallet.Focus()
                Else
                    For i = 0 To Me.lstMPallets.Items.Count - 1
                        If strMPallet.ToUpper = Convert.ToString(Me.lstMPallets.Items(i)).ToUpper Then
                            MessageBox.Show("Already scanned to the listbox.", "Manifest", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Me.txtMasterPallet.SelectAll() : Me.txtMasterPallet.Focus() : Exit Sub
                        End If
                    Next
                    Me.lstMPallets.Items.Add(strMPallet)
                    Me.txtMasterPallet.Text = "" : Me.txtMasterPallet.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnExportMPData_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub btnRemoveMP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemoveMP.Click
        Dim strMPalletName As String = ""
        Dim strMPalletName2 As String = ""
        Dim i As Integer = 0
        Dim arrlstNames As New ArrayList()

        Try
            strMPalletName = InputBox("Enter master pallet name to remove from the scanned list:", "Master Pallet name", "").ToString.Trim
            If strMPalletName.Trim.Length > 0 Then
                For i = 0 To Me.lstMPallets.Items.Count - 1
                    strMPalletName2 = Convert.ToString(Me.lstMPallets.Items(i))
                    If Not strMPalletName2.Trim.ToUpper = strMPalletName.Trim.ToUpper Then
                        arrlstNames.Add(strMPalletName2)
                    End If
                Next

                Me.lstMPallets.Items.Clear()
                For i = 0 To arrlstNames.Count - 1
                    Me.lstMPallets.Items.Add(arrlstNames(i))
                Next
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnExportMPData_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            If Me.lstMPallets.Items.Count = 0 Then Me.lblAccount.Text = ""
            Me.txtMasterPallet.Text = "" : Me.txtMasterPallet.Focus()
        End Try
    End Sub

    Private Sub btnRemoveAllMPs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemoveAllMPs.Click
        Try
            If Me.lstMPallets.Items.Count > 0 Then
                Me.lstMPallets.Items.Clear() : Me.lblAccount.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnExportMPData_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.txtMasterPallet.Text = "" : Me.txtMasterPallet.Focus()
        End Try
    End Sub

    Private Sub btnExportMPData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportMPData.Click
        Dim strMPalletNames As String = ""
        Dim dt As DataTable
        Dim i As Integer = 0
        Dim iCartonWeight As Integer = 0
        Dim strAccount As String = ""

        Try

            strAccount = Me.lblAccount.Text.Trim

            If strAccount.Length = 0 Then
                MessageBox.Show("No account info. See IT.", "Manifest", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If Me.lstMPallets.Items.Count > 0 Then
                If IsNumeric(Me.txtCartonWeight.Text) Then iCartonWeight = Me.txtCartonWeight.Text Else Me.txtCartonWeight.Text = Me._iDefaultCartonWeight : iCartonWeight = Me._iDefaultCartonWeight
                For i = 0 To Me.lstMPallets.Items.Count - 1
                    If strMPalletNames.Trim.Length = 0 Then
                        strMPalletNames = "'" & Convert.ToString(Me.lstMPallets.Items(i)) & "'"
                    Else
                        strMPalletNames &= ",'" & Convert.ToString(Me.lstMPallets.Items(i)) & "'"
                    End If
                Next

                If Me.cmbCustomers.SelectedValue = Me._WingTechATT_CustID Then
                    dt = Me._objWIKO_SP.getGenericProcess_WingTechAttSPManifestMasterPalletDetailedData(strMPalletNames, iCartonWeight)
                Else
                    dt = Me._objWIKO_SP.getWIKO_SpTellerManifestMasterPalletDetailedData(strMPalletNames, iCartonWeight, strAccount)
                End If


                If Not dt.Rows.Count > 0 Then
                    MessageBox.Show("No data! See IT.", "Manifest", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                Dim xReport As New Data.ExcelReports()
                If strAccount.Trim.ToUpper = PSS.Data.Buisness.WIKO.WIKO.WIKO_SpecialProj_Type2.Trim.ToUpper _
                   OrElse strAccount.Trim.ToUpper = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_SpecialProj_Type1.Trim.ToUpper _
                   OrElse strAccount.Trim.ToUpper = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_SpecialProj_Type2.Trim.ToUpper _
                   OrElse Me.cmbCustomers.SelectedValue = Me._WingTechATT_CustID Then
                    xReport.RunSimpleExcelFormat(dt, "Master_Pallet_Devices_" & Format(Now, "yyyyMMddHHmmss"), New String() {"A", "B", "C", "D"})
                    Me.lstMPallets.Items.Clear() : Me.lblAccount.Text = "" : Me.txtMasterPallet.Text = "" : Me.txtMasterPallet.Focus()
                ElseIf strAccount.Trim.ToUpper = PSS.Data.Buisness.WIKO.WIKO.WIKO_SpecialProj_Type3.Trim.ToUpper _
                       OrElse strAccount.Trim.ToUpper = PSS.Data.Buisness.WIKO.WIKO.WIKO_SpecialProj_Type4.Trim.ToUpper Then
                    xReport.RunSimpleExcelFormat(dt, "Master_Pallet_Devices_" & Format(Now, "yyyyMMddHHmmss"), New String() {"A", "B", "C", "D", "E"})
                    Me.lstMPallets.Items.Clear() : Me.lblAccount.Text = "" : Me.txtMasterPallet.Text = "" : Me.txtMasterPallet.Focus()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnExportMPData_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

#End Region

#Region "Waiting Shipment Tabpage"

    '*******************************************************************
    Private Sub tpgWaitingShipment_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpgWaitingShipment.VisibleChanged
        Try
            If sender.visible = True Then
                PopulateWaitingShipmentGrid()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "WaitingShipment tabpage VisibleChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*******************************************************************
    Private Sub PopulateWaitingShipmentGrid()
        Dim dt As DataTable

        Try
            'Reset controls
            Me.grdWaitingShipment.DataSource = Nothing
            Me.grdWaitingShipment.Visible = False
            Me.lblWS_total.Visible = False
            Me.btnWS_CopyAll.Visible = False
            Me.btnWS_CopySelected.Visible = False

            If Me.cmbCustomers.SelectedValue > 0 Then
                dt = Me._objSPPLF.GetPalletWaitingShipment(Me.cmbCustomers.SelectedValue)
                Me.grdWaitingShipment.DataSource = dt
                Me.grdWaitingShipment.Visible = True

                Me.SetGridLayout(Me.grdWaitingShipment, _
                                 Color.Black, _
                                 New Integer() {150, 150, 100, 80, 100}, _
                                 C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, _
                                 New Integer() {C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, C1.Win.C1TrueDBGrid.AlignHorzEnum.Far, C1.Win.C1TrueDBGrid.AlignHorzEnum.Far})
                Me.lblWS_total.Visible = True
                Me.lblWS_total.Text = "Total: " & dt.Rows.Count.ToString
                Me.btnWS_CopyAll.Visible = True
                Me.btnWS_CopySelected.Visible = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "PopulateWaitingShipmentGrid", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.grdWaitingShipment.Visible = False
            Me.lblWS_total.Visible = False
            Me.btnWS_CopyAll.Visible = False
            Me.btnWS_CopySelected.Visible = False
        End Try
    End Sub

    '*******************************************************************
    Private Sub SetGridLayout(ByRef grdPackingSlipCtrl As C1.Win.C1TrueDBGrid.C1TrueDBGrid, _
                                ByVal clrHeaderForeColor As Color, _
                                ByVal iArrColSize() As Integer, _
                                ByVal iHeaderAlignment As Integer, _
                                ByVal iArrRowAlignment() As Integer)
        Dim iNumOfColumns As Integer = grdPackingSlipCtrl.Columns.Count
        Dim i As Integer

        With grdPackingSlipCtrl
            'Heading style (Horizontal Alignment to Center)
            For i = 0 To (iNumOfColumns - 1)
                .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = iHeaderAlignment 'C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = clrHeaderForeColor
                .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = iArrRowAlignment(i) 'C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns(i).Width = iArrColSize(i)
            Next i
        End With
    End Sub

    '*******************************************************************
    Private Sub btnWS_CopyAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWS_CopyAll.Click
        Dim strData As String
        Dim iRow As Integer
        Dim booCompleteHeader As Boolean = False
        Dim strHeader As String = ""
        Dim col As C1.Win.C1TrueDBGrid.C1DataColumn

        Try
            If Me.grdWaitingShipment.RowCount > 0 And Me.grdWaitingShipment.Columns.Count > 0 Then
                'loop through each row
                For iRow = 0 To Me.grdWaitingShipment.RowCount - 1
                    'loop through each column
                    For Each col In Me.grdWaitingShipment.Columns
                        'header
                        If booCompleteHeader = False Then
                            strHeader = strHeader & col.Caption & vbTab
                        End If

                        'Data
                        strData = strData & col.CellText(iRow) & vbTab
                    Next col

                    'add new line to data
                    strData = strData & vbCrLf

                    'Stop collect header
                    booCompleteHeader = True
                Next iRow

                'combine header and data
                strData = strHeader & vbCrLf & strData

                'Copy Data to Clipboard
                System.Windows.Forms.Clipboard.SetDataObject(strData, False)

                ''print data
                'Me._objSPPLF.CreateExelReportToPrint(strData, Chr(65 + Me.grdWaitingShipment.Columns.Count - 1) & Me.grdWaitingShipment.RowCount + 1)
                'MessageBox.Show("Report has been printed out.", "Print Selected Row", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                MessageBox.Show("No data to print.", "Print Selected Row", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "btnWS_PrintAll_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*******************************************************************
    Private Sub btnWS_CopySelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWS_CopySelected.Click
        Dim strData As String
        Dim iRow As Integer
        Dim booCompleteHeader As Boolean = False
        Dim col As C1.Win.C1TrueDBGrid.C1DataColumn
        Dim strHeader As String = ""

        Try
            If Me.grdWaitingShipment.SelectedRows.Count > 0 And Me.grdWaitingShipment.SelectedCols.Count Then
                'loop through each selected row
                For Each iRow In Me.grdWaitingShipment.SelectedRows

                    'loop through each selected column
                    For Each col In Me.grdWaitingShipment.SelectedCols
                        'header
                        If booCompleteHeader = False Then
                            strHeader = strHeader & col.Caption & vbTab
                        End If
                        'data
                        strData = strData & col.CellText(iRow) & vbTab
                    Next col

                    'add new line to data
                    strData = strData & vbCrLf

                    'Stop collect header
                    booCompleteHeader = True
                Next iRow

                'combine header and data
                strData = strHeader & vbCrLf & strData

                'Copy Data to Clipboard
                System.Windows.Forms.Clipboard.SetDataObject(strData, False)

                'print data
                'Me._objSPPLF.CreateExelReportToPrint(strData, Chr(65 + Me.grdWaitingShipment.SelectedCols.Count - 1) & Me.grdWaitingShipment.SelectedRows.Count + 1)
                'MessageBox.Show("Report has been printed out.", "Print Selected Row", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                MessageBox.Show("Please select a range of cells to print.", "Print Selected Row", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "btnWS_printSelected_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*******************************************************************

#End Region

    '*******************************************************************

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        'TabControl1.TabPages(TabControl1.SelectedIndex).Focus()
        'TabControl1.TabPages(TabControl1.SelectedIndex).CausesValidation = True
        If Me._bHideTabOneControls AndAlso TabControl1.SelectedIndex = 0 Then
            TabControl1.SelectedIndex = 1
            TabControl1.TabPages(TabControl1.SelectedIndex).Focus()
        ElseIf TabControl1.SelectedIndex = 3 AndAlso Me.cmbCustomers.SelectedValue <> Me._WIKO_CustID _
              AndAlso Me.cmbCustomers.SelectedValue <> Me._Vinsmart_CustID _
              AndAlso Me.cmbCustomers.SelectedValue <> Me._WingTechATT_CustID Then
            TabControl1.SelectedIndex = 1
            TabControl1.TabPages(TabControl1.SelectedIndex).Focus()

            'ZFang: NOT YET. Only id Customer need Master Pallet. Even WingTechATT needs, this is not correct!
            '    'Added By Amazech-Thanga 07.08.2021
            'ElseIf TabControl1.SelectedIndex = 3 AndAlso Me.cmbCustomers.SelectedValue <> Me._WingTechATT_custId Then
            '    TabControl1.SelectedIndex = 1
            '    TabControl1.TabPages(TabControl1.SelectedIndex).Focus()
        End If

    End Sub
 
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class

