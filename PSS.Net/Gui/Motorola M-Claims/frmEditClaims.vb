Namespace Gui.MClaims

    Public Class frmEditClaims
        Inherits System.Windows.Forms.Form
        Private objMotoSubcontract_Biz As PSS.Data.Buisness.MotorolaSubcontract_Biz
        Private iDeviceId As Integer = 0
        Private iClaimType As Integer
        Private myDataTable As New DataTable()
        Private dtParts As New DataTable()
        Private objMyLib As MyLib.Utility
        Private iRefDesigCode As Integer = 0
        Private iFailureCode As Integer = 0

        '******************************************************
        'State Variables
        '******************************************************
        Private strDeviceSn, strDateRec, strDateRepaired, strDateShip, strCSNin, strCSNOut, strMSNin, strMSNOut As String
        Private strIMEIin, strIMEIOut, strTransceiver, strDatePOP, strSoftIn, strSoftOut, strAirtime As String
        Private iTechID, iDcodeID_CarrCode, iDcodeID_Transaction, iDcodeID_Complaint, iDcodeID_APC, iDcodeID_Problem, iDcodeID_Repair As Integer

        '******************************************************

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iClaim_Type As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            iClaimType = iClaim_Type
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
        Friend WithEvents txtClaimNum As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents lstClaims As System.Windows.Forms.ListBox
        Friend WithEvents btnUpdateClaim As System.Windows.Forms.Button
        Friend WithEvents cmdClearScreen As System.Windows.Forms.Button
        Friend WithEvents cmdRemoveItem As System.Windows.Forms.Button
        Friend WithEvents cmdClearClaims As System.Windows.Forms.Button
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents TabComponents As System.Windows.Forms.TabPage
        Friend WithEvents GrpDeviceInfo1 As System.Windows.Forms.GroupBox
        Friend WithEvents lblModel As System.Windows.Forms.Label
        Friend WithEvents Label28 As System.Windows.Forms.Label
        Friend WithEvents dtpDateShp As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents dtpDateRep As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpDateRec As System.Windows.Forms.DateTimePicker
        Friend WithEvents label4 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtDevice_SN As System.Windows.Forms.TextBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents GrpDeviceInfo2 As System.Windows.Forms.GroupBox
        Friend WithEvents dtpDatePurchase As System.Windows.Forms.DateTimePicker
        Friend WithEvents txtSoftOut As System.Windows.Forms.TextBox
        Friend WithEvents Label18 As System.Windows.Forms.Label
        Friend WithEvents txtSoftIn As System.Windows.Forms.TextBox
        Friend WithEvents Label17 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents txtAirtime As System.Windows.Forms.TextBox
        Friend WithEvents Label16 As System.Windows.Forms.Label
        Friend WithEvents txtTransaceiver As System.Windows.Forms.TextBox
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents cmbTech As System.Windows.Forms.ComboBox
        Friend WithEvents Label25 As System.Windows.Forms.Label
        Friend WithEvents txtIMEIOut As System.Windows.Forms.TextBox
        Friend WithEvents Label23 As System.Windows.Forms.Label
        Friend WithEvents txtIMEIIn As System.Windows.Forms.TextBox
        Friend WithEvents Label24 As System.Windows.Forms.Label
        Friend WithEvents txtMSNOut As System.Windows.Forms.TextBox
        Friend WithEvents Label21 As System.Windows.Forms.Label
        Friend WithEvents txtMSNIn As System.Windows.Forms.TextBox
        Friend WithEvents Label22 As System.Windows.Forms.Label
        Friend WithEvents txtCSNOut As System.Windows.Forms.TextBox
        Friend WithEvents Label20 As System.Windows.Forms.Label
        Friend WithEvents txtCSNIn As System.Windows.Forms.TextBox
        Friend WithEvents Label19 As System.Windows.Forms.Label
        Friend WithEvents grpCodes As System.Windows.Forms.GroupBox
        Friend WithEvents cmbComplaintCode As System.Windows.Forms.ComboBox
        Friend WithEvents Label15 As System.Windows.Forms.Label
        Friend WithEvents cmbRepCode As System.Windows.Forms.ComboBox
        Friend WithEvents Label14 As System.Windows.Forms.Label
        Friend WithEvents cmbProbCode As System.Windows.Forms.ComboBox
        Friend WithEvents Label13 As System.Windows.Forms.Label
        Friend WithEvents cmbAPCCode As System.Windows.Forms.ComboBox
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents cmbTransactionCode As System.Windows.Forms.ComboBox
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents cmbCarrCode As System.Windows.Forms.ComboBox
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents grpParts As System.Windows.Forms.GroupBox
        Friend WithEvents cmdClearChanges As System.Windows.Forms.Button
        Friend WithEvents grpPartChanges As System.Windows.Forms.GroupBox
        Friend WithEvents grdPartChages As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents Label27 As System.Windows.Forms.Label
        Friend WithEvents btnUpdateGrid As System.Windows.Forms.Button
        Friend WithEvents cmbFailure As System.Windows.Forms.ComboBox
        Friend WithEvents lblCaptionFailure As System.Windows.Forms.Label
        Friend WithEvents cmbRefDesig As System.Windows.Forms.ComboBox
        Friend WithEvents lblCaptionRefDesgn As System.Windows.Forms.Label
        Friend WithEvents txtRefDesignator As System.Windows.Forms.TextBox
        Friend WithEvents Label26 As System.Windows.Forms.Label
        Friend WithEvents grdParts As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents TabClaim As System.Windows.Forms.TabPage
        Friend WithEvents TabRMAInfo As System.Windows.Forms.TabPage
        Friend WithEvents GrpRMAInfo As System.Windows.Forms.GroupBox
        Friend WithEvents lblRMANumber As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents lblWO_ID As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Label29 As System.Windows.Forms.Label
        Friend WithEvents cmdCreateFile As System.Windows.Forms.Button
        Friend WithEvents lblHeading As System.Windows.Forms.Label
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents lblClaimNumber As System.Windows.Forms.Label
        Friend WithEvents lblClaimSent As System.Windows.Forms.Label
        Friend WithEvents Label30 As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmEditClaims))
            Dim GridLines1 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
            Dim GridLines2 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.txtClaimNum = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.cmdCreateFile = New System.Windows.Forms.Button()
            Me.cmdClearClaims = New System.Windows.Forms.Button()
            Me.cmdRemoveItem = New System.Windows.Forms.Button()
            Me.lstClaims = New System.Windows.Forms.ListBox()
            Me.btnUpdateClaim = New System.Windows.Forms.Button()
            Me.cmdClearScreen = New System.Windows.Forms.Button()
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.TabClaim = New System.Windows.Forms.TabPage()
            Me.grpCodes = New System.Windows.Forms.GroupBox()
            Me.cmbComplaintCode = New System.Windows.Forms.ComboBox()
            Me.Label15 = New System.Windows.Forms.Label()
            Me.cmbRepCode = New System.Windows.Forms.ComboBox()
            Me.Label14 = New System.Windows.Forms.Label()
            Me.cmbProbCode = New System.Windows.Forms.ComboBox()
            Me.Label13 = New System.Windows.Forms.Label()
            Me.cmbAPCCode = New System.Windows.Forms.ComboBox()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.cmbTransactionCode = New System.Windows.Forms.ComboBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.cmbCarrCode = New System.Windows.Forms.ComboBox()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.GrpDeviceInfo2 = New System.Windows.Forms.GroupBox()
            Me.dtpDatePurchase = New System.Windows.Forms.DateTimePicker()
            Me.txtSoftOut = New System.Windows.Forms.TextBox()
            Me.Label18 = New System.Windows.Forms.Label()
            Me.txtSoftIn = New System.Windows.Forms.TextBox()
            Me.Label17 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.txtAirtime = New System.Windows.Forms.TextBox()
            Me.Label16 = New System.Windows.Forms.Label()
            Me.txtTransaceiver = New System.Windows.Forms.TextBox()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.cmbTech = New System.Windows.Forms.ComboBox()
            Me.Label25 = New System.Windows.Forms.Label()
            Me.txtIMEIOut = New System.Windows.Forms.TextBox()
            Me.Label23 = New System.Windows.Forms.Label()
            Me.txtIMEIIn = New System.Windows.Forms.TextBox()
            Me.Label24 = New System.Windows.Forms.Label()
            Me.txtMSNOut = New System.Windows.Forms.TextBox()
            Me.Label21 = New System.Windows.Forms.Label()
            Me.txtMSNIn = New System.Windows.Forms.TextBox()
            Me.Label22 = New System.Windows.Forms.Label()
            Me.txtCSNOut = New System.Windows.Forms.TextBox()
            Me.Label20 = New System.Windows.Forms.Label()
            Me.txtCSNIn = New System.Windows.Forms.TextBox()
            Me.Label19 = New System.Windows.Forms.Label()
            Me.GrpDeviceInfo1 = New System.Windows.Forms.GroupBox()
            Me.lblModel = New System.Windows.Forms.Label()
            Me.Label28 = New System.Windows.Forms.Label()
            Me.dtpDateShp = New System.Windows.Forms.DateTimePicker()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.dtpDateRep = New System.Windows.Forms.DateTimePicker()
            Me.dtpDateRec = New System.Windows.Forms.DateTimePicker()
            Me.label4 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtDevice_SN = New System.Windows.Forms.TextBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.TabComponents = New System.Windows.Forms.TabPage()
            Me.grpParts = New System.Windows.Forms.GroupBox()
            Me.cmdClearChanges = New System.Windows.Forms.Button()
            Me.grpPartChanges = New System.Windows.Forms.GroupBox()
            Me.grdPartChages = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label27 = New System.Windows.Forms.Label()
            Me.btnUpdateGrid = New System.Windows.Forms.Button()
            Me.cmbFailure = New System.Windows.Forms.ComboBox()
            Me.lblCaptionFailure = New System.Windows.Forms.Label()
            Me.cmbRefDesig = New System.Windows.Forms.ComboBox()
            Me.lblCaptionRefDesgn = New System.Windows.Forms.Label()
            Me.txtRefDesignator = New System.Windows.Forms.TextBox()
            Me.Label26 = New System.Windows.Forms.Label()
            Me.grdParts = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.TabRMAInfo = New System.Windows.Forms.TabPage()
            Me.GrpRMAInfo = New System.Windows.Forms.GroupBox()
            Me.lblRMANumber = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.lblWO_ID = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.Label29 = New System.Windows.Forms.Label()
            Me.lblHeading = New System.Windows.Forms.Label()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.lblClaimNumber = New System.Windows.Forms.Label()
            Me.lblClaimSent = New System.Windows.Forms.Label()
            Me.Label30 = New System.Windows.Forms.Label()
            Me.Panel1.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.TabControl1.SuspendLayout()
            Me.TabClaim.SuspendLayout()
            Me.grpCodes.SuspendLayout()
            Me.GrpDeviceInfo2.SuspendLayout()
            Me.GrpDeviceInfo1.SuspendLayout()
            Me.TabComponents.SuspendLayout()
            Me.grpParts.SuspendLayout()
            Me.grpPartChanges.SuspendLayout()
            CType(Me.grdPartChages, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.grdParts, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabRMAInfo.SuspendLayout()
            Me.GrpRMAInfo.SuspendLayout()
            Me.SuspendLayout()
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.DarkKhaki
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtClaimNum, Me.Label1})
            Me.Panel1.Location = New System.Drawing.Point(9, 1)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(271, 40)
            Me.Panel1.TabIndex = 56
            '
            'txtClaimNum
            '
            Me.txtClaimNum.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtClaimNum.Location = New System.Drawing.Point(130, 9)
            Me.txtClaimNum.Name = "txtClaimNum"
            Me.txtClaimNum.Size = New System.Drawing.Size(118, 22)
            Me.txtClaimNum.TabIndex = 5
            Me.txtClaimNum.Text = ""
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Red
            Me.Label1.Location = New System.Drawing.Point(10, 9)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(120, 23)
            Me.Label1.TabIndex = 4
            Me.Label1.Text = "Claim Number:"
            '
            'GroupBox1
            '
            Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdCreateFile, Me.cmdClearClaims, Me.cmdRemoveItem, Me.lstClaims})
            Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
            Me.GroupBox1.Location = New System.Drawing.Point(829, 69)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(139, 411)
            Me.GroupBox1.TabIndex = 58
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Claims"
            '
            'cmdCreateFile
            '
            Me.cmdCreateFile.BackColor = System.Drawing.Color.DarkKhaki
            Me.cmdCreateFile.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdCreateFile.ForeColor = System.Drawing.Color.Red
            Me.cmdCreateFile.Location = New System.Drawing.Point(8, 376)
            Me.cmdCreateFile.Name = "cmdCreateFile"
            Me.cmdCreateFile.Size = New System.Drawing.Size(120, 24)
            Me.cmdCreateFile.TabIndex = 65
            Me.cmdCreateFile.Text = "Create File"
            '
            'cmdClearClaims
            '
            Me.cmdClearClaims.BackColor = System.Drawing.Color.DarkKhaki
            Me.cmdClearClaims.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdClearClaims.ForeColor = System.Drawing.Color.Navy
            Me.cmdClearClaims.Location = New System.Drawing.Point(8, 344)
            Me.cmdClearClaims.Name = "cmdClearClaims"
            Me.cmdClearClaims.Size = New System.Drawing.Size(120, 24)
            Me.cmdClearClaims.TabIndex = 63
            Me.cmdClearClaims.Text = "Clear Claims"
            '
            'cmdRemoveItem
            '
            Me.cmdRemoveItem.BackColor = System.Drawing.Color.DarkKhaki
            Me.cmdRemoveItem.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdRemoveItem.ForeColor = System.Drawing.Color.Navy
            Me.cmdRemoveItem.Location = New System.Drawing.Point(8, 312)
            Me.cmdRemoveItem.Name = "cmdRemoveItem"
            Me.cmdRemoveItem.Size = New System.Drawing.Size(120, 24)
            Me.cmdRemoveItem.TabIndex = 62
            Me.cmdRemoveItem.Text = "Remove Claim"
            '
            'lstClaims
            '
            Me.lstClaims.ItemHeight = 16
            Me.lstClaims.Location = New System.Drawing.Point(8, 24)
            Me.lstClaims.Name = "lstClaims"
            Me.lstClaims.Size = New System.Drawing.Size(120, 276)
            Me.lstClaims.TabIndex = 0
            '
            'btnUpdateClaim
            '
            Me.btnUpdateClaim.BackColor = System.Drawing.Color.DarkKhaki
            Me.btnUpdateClaim.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnUpdateClaim.ForeColor = System.Drawing.Color.Red
            Me.btnUpdateClaim.Location = New System.Drawing.Point(8, 488)
            Me.btnUpdateClaim.Name = "btnUpdateClaim"
            Me.btnUpdateClaim.Size = New System.Drawing.Size(640, 24)
            Me.btnUpdateClaim.TabIndex = 59
            Me.btnUpdateClaim.Text = "Update Claim"
            '
            'cmdClearScreen
            '
            Me.cmdClearScreen.BackColor = System.Drawing.Color.DarkKhaki
            Me.cmdClearScreen.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdClearScreen.ForeColor = System.Drawing.Color.Navy
            Me.cmdClearScreen.Location = New System.Drawing.Point(659, 488)
            Me.cmdClearScreen.Name = "cmdClearScreen"
            Me.cmdClearScreen.Size = New System.Drawing.Size(165, 24)
            Me.cmdClearScreen.TabIndex = 61
            Me.cmdClearScreen.Text = "Clear Claim Details"
            '
            'TabControl1
            '
            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabClaim, Me.TabComponents, Me.TabRMAInfo})
            Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TabControl1.Location = New System.Drawing.Point(8, 56)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(816, 424)
            Me.TabControl1.TabIndex = 62
            '
            'TabClaim
            '
            Me.TabClaim.BackColor = System.Drawing.Color.PaleGoldenrod
            Me.TabClaim.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpCodes, Me.GrpDeviceInfo2, Me.GrpDeviceInfo1})
            Me.TabClaim.ForeColor = System.Drawing.SystemColors.Control
            Me.TabClaim.Location = New System.Drawing.Point(4, 22)
            Me.TabClaim.Name = "TabClaim"
            Me.TabClaim.Size = New System.Drawing.Size(808, 398)
            Me.TabClaim.TabIndex = 0
            Me.TabClaim.Text = "Claim Info"
            '
            'grpCodes
            '
            Me.grpCodes.BackColor = System.Drawing.Color.Transparent
            Me.grpCodes.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmbComplaintCode, Me.Label15, Me.cmbRepCode, Me.Label14, Me.cmbProbCode, Me.Label13, Me.cmbAPCCode, Me.Label11, Me.cmbTransactionCode, Me.Label10, Me.cmbCarrCode, Me.Label9})
            Me.grpCodes.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grpCodes.ForeColor = System.Drawing.Color.Navy
            Me.grpCodes.Location = New System.Drawing.Point(16, 212)
            Me.grpCodes.Name = "grpCodes"
            Me.grpCodes.Size = New System.Drawing.Size(779, 174)
            Me.grpCodes.TabIndex = 56
            Me.grpCodes.TabStop = False
            Me.grpCodes.Text = "Codes"
            '
            'cmbComplaintCode
            '
            Me.cmbComplaintCode.Location = New System.Drawing.Point(176, 66)
            Me.cmbComplaintCode.Name = "cmbComplaintCode"
            Me.cmbComplaintCode.Size = New System.Drawing.Size(530, 22)
            Me.cmbComplaintCode.TabIndex = 41
            Me.cmbComplaintCode.TabStop = False
            '
            'Label15
            '
            Me.Label15.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label15.ForeColor = System.Drawing.Color.Black
            Me.Label15.Location = New System.Drawing.Point(49, 66)
            Me.Label15.Name = "Label15"
            Me.Label15.Size = New System.Drawing.Size(136, 23)
            Me.Label15.TabIndex = 40
            Me.Label15.Text = "Complaint Code:"
            '
            'cmbRepCode
            '
            Me.cmbRepCode.Location = New System.Drawing.Point(176, 142)
            Me.cmbRepCode.Name = "cmbRepCode"
            Me.cmbRepCode.Size = New System.Drawing.Size(530, 22)
            Me.cmbRepCode.TabIndex = 39
            Me.cmbRepCode.TabStop = False
            '
            'Label14
            '
            Me.Label14.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label14.ForeColor = System.Drawing.Color.Black
            Me.Label14.Location = New System.Drawing.Point(26, 142)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(160, 23)
            Me.Label14.TabIndex = 38
            Me.Label14.Text = "Repair Action Code:"
            '
            'cmbProbCode
            '
            Me.cmbProbCode.Location = New System.Drawing.Point(176, 116)
            Me.cmbProbCode.Name = "cmbProbCode"
            Me.cmbProbCode.Size = New System.Drawing.Size(530, 22)
            Me.cmbProbCode.TabIndex = 37
            Me.cmbProbCode.TabStop = False
            '
            'Label13
            '
            Me.Label13.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label13.ForeColor = System.Drawing.Color.Black
            Me.Label13.Location = New System.Drawing.Point(13, 116)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(176, 23)
            Me.Label13.TabIndex = 36
            Me.Label13.Text = "Problem Found Code:"
            '
            'cmbAPCCode
            '
            Me.cmbAPCCode.Location = New System.Drawing.Point(176, 91)
            Me.cmbAPCCode.Name = "cmbAPCCode"
            Me.cmbAPCCode.Size = New System.Drawing.Size(530, 22)
            Me.cmbAPCCode.TabIndex = 35
            Me.cmbAPCCode.TabStop = False
            '
            'Label11
            '
            Me.Label11.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.ForeColor = System.Drawing.Color.Black
            Me.Label11.Location = New System.Drawing.Point(94, 91)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(88, 23)
            Me.Label11.TabIndex = 34
            Me.Label11.Text = "APC Code:"
            '
            'cmbTransactionCode
            '
            Me.cmbTransactionCode.Location = New System.Drawing.Point(176, 41)
            Me.cmbTransactionCode.Name = "cmbTransactionCode"
            Me.cmbTransactionCode.Size = New System.Drawing.Size(530, 22)
            Me.cmbTransactionCode.TabIndex = 33
            Me.cmbTransactionCode.TabStop = False
            '
            'Label10
            '
            Me.Label10.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.Black
            Me.Label10.Location = New System.Drawing.Point(38, 42)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(144, 23)
            Me.Label10.TabIndex = 32
            Me.Label10.Text = "Transaction Code:"
            '
            'cmbCarrCode
            '
            Me.cmbCarrCode.Location = New System.Drawing.Point(176, 15)
            Me.cmbCarrCode.Name = "cmbCarrCode"
            Me.cmbCarrCode.Size = New System.Drawing.Size(530, 22)
            Me.cmbCarrCode.TabIndex = 31
            Me.cmbCarrCode.TabStop = False
            '
            'Label9
            '
            Me.Label9.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.Black
            Me.Label9.Location = New System.Drawing.Point(72, 17)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(110, 23)
            Me.Label9.TabIndex = 30
            Me.Label9.Text = "Carrier Code:"
            '
            'GrpDeviceInfo2
            '
            Me.GrpDeviceInfo2.BackColor = System.Drawing.Color.Transparent
            Me.GrpDeviceInfo2.Controls.AddRange(New System.Windows.Forms.Control() {Me.dtpDatePurchase, Me.txtSoftOut, Me.Label18, Me.txtSoftIn, Me.Label17, Me.Label5, Me.txtAirtime, Me.Label16, Me.txtTransaceiver, Me.Label12, Me.cmbTech, Me.Label25, Me.txtIMEIOut, Me.Label23, Me.txtIMEIIn, Me.Label24, Me.txtMSNOut, Me.Label21, Me.txtMSNIn, Me.Label22, Me.txtCSNOut, Me.Label20, Me.txtCSNIn, Me.Label19})
            Me.GrpDeviceInfo2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GrpDeviceInfo2.ForeColor = System.Drawing.Color.Blue
            Me.GrpDeviceInfo2.Location = New System.Drawing.Point(16, 89)
            Me.GrpDeviceInfo2.Name = "GrpDeviceInfo2"
            Me.GrpDeviceInfo2.Size = New System.Drawing.Size(779, 122)
            Me.GrpDeviceInfo2.TabIndex = 55
            Me.GrpDeviceInfo2.TabStop = False
            '
            'dtpDatePurchase
            '
            Me.dtpDatePurchase.CustomFormat = "yyyy-MM-dd hh:mm:ss"
            Me.dtpDatePurchase.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpDatePurchase.Location = New System.Drawing.Point(396, 69)
            Me.dtpDatePurchase.Name = "dtpDatePurchase"
            Me.dtpDatePurchase.Size = New System.Drawing.Size(180, 22)
            Me.dtpDatePurchase.TabIndex = 70
            Me.dtpDatePurchase.Value = New Date(1753, 1, 1, 0, 0, 0, 0)
            '
            'txtSoftOut
            '
            Me.txtSoftOut.Location = New System.Drawing.Point(417, 95)
            Me.txtSoftOut.Name = "txtSoftOut"
            Me.txtSoftOut.Size = New System.Drawing.Size(112, 22)
            Me.txtSoftOut.TabIndex = 69
            Me.txtSoftOut.Text = ""
            '
            'Label18
            '
            Me.Label18.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label18.ForeColor = System.Drawing.Color.Black
            Me.Label18.Location = New System.Drawing.Point(281, 95)
            Me.Label18.Name = "Label18"
            Me.Label18.Size = New System.Drawing.Size(144, 23)
            Me.Label18.TabIndex = 68
            Me.Label18.Text = "Software Ver Out:"
            '
            'txtSoftIn
            '
            Me.txtSoftIn.Location = New System.Drawing.Point(144, 95)
            Me.txtSoftIn.Name = "txtSoftIn"
            Me.txtSoftIn.Size = New System.Drawing.Size(112, 22)
            Me.txtSoftIn.TabIndex = 65
            Me.txtSoftIn.Text = ""
            '
            'Label17
            '
            Me.Label17.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label17.ForeColor = System.Drawing.Color.Black
            Me.Label17.Location = New System.Drawing.Point(15, 95)
            Me.Label17.Name = "Label17"
            Me.Label17.Size = New System.Drawing.Size(133, 23)
            Me.Label17.TabIndex = 64
            Me.Label17.Text = "Software Ver In:"
            '
            'Label5
            '
            Me.Label5.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.Black
            Me.Label5.Location = New System.Drawing.Point(270, 71)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(136, 23)
            Me.Label5.TabIndex = 62
            Me.Label5.Text = "Date Purchased:"
            '
            'txtAirtime
            '
            Me.txtAirtime.Location = New System.Drawing.Point(646, 95)
            Me.txtAirtime.Name = "txtAirtime"
            Me.txtAirtime.Size = New System.Drawing.Size(125, 22)
            Me.txtAirtime.TabIndex = 61
            Me.txtAirtime.Text = ""
            '
            'Label16
            '
            Me.Label16.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label16.ForeColor = System.Drawing.Color.Black
            Me.Label16.Location = New System.Drawing.Point(579, 97)
            Me.Label16.Name = "Label16"
            Me.Label16.Size = New System.Drawing.Size(80, 23)
            Me.Label16.TabIndex = 60
            Me.Label16.Text = "Air Time:"
            '
            'txtTransaceiver
            '
            Me.txtTransaceiver.Location = New System.Drawing.Point(144, 69)
            Me.txtTransaceiver.MaxLength = 9
            Me.txtTransaceiver.Name = "txtTransaceiver"
            Me.txtTransaceiver.Size = New System.Drawing.Size(112, 22)
            Me.txtTransaceiver.TabIndex = 59
            Me.txtTransaceiver.Text = ""
            '
            'Label12
            '
            Me.Label12.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label12.ForeColor = System.Drawing.Color.Black
            Me.Label12.Location = New System.Drawing.Point(8, 70)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(136, 23)
            Me.Label12.TabIndex = 58
            Me.Label12.Text = "Tansceiver Code:"
            '
            'cmbTech
            '
            Me.cmbTech.Location = New System.Drawing.Point(646, 69)
            Me.cmbTech.Name = "cmbTech"
            Me.cmbTech.Size = New System.Drawing.Size(125, 22)
            Me.cmbTech.TabIndex = 57
            Me.cmbTech.TabStop = False
            '
            'Label25
            '
            Me.Label25.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label25.ForeColor = System.Drawing.Color.Black
            Me.Label25.Location = New System.Drawing.Point(584, 72)
            Me.Label25.Name = "Label25"
            Me.Label25.Size = New System.Drawing.Size(72, 23)
            Me.Label25.TabIndex = 56
            Me.Label25.Text = "Tech ID:"
            '
            'txtIMEIOut
            '
            Me.txtIMEIOut.Location = New System.Drawing.Point(536, 45)
            Me.txtIMEIOut.MaxLength = 15
            Me.txtIMEIOut.Name = "txtIMEIOut"
            Me.txtIMEIOut.Size = New System.Drawing.Size(234, 22)
            Me.txtIMEIOut.TabIndex = 55
            Me.txtIMEIOut.Text = ""
            '
            'Label23
            '
            Me.Label23.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label23.ForeColor = System.Drawing.Color.Black
            Me.Label23.Location = New System.Drawing.Point(458, 47)
            Me.Label23.Name = "Label23"
            Me.Label23.Size = New System.Drawing.Size(80, 23)
            Me.Label23.TabIndex = 54
            Me.Label23.Text = "IMEI Out:"
            '
            'txtIMEIIn
            '
            Me.txtIMEIIn.Location = New System.Drawing.Point(536, 19)
            Me.txtIMEIIn.MaxLength = 15
            Me.txtIMEIIn.Name = "txtIMEIIn"
            Me.txtIMEIIn.Size = New System.Drawing.Size(234, 22)
            Me.txtIMEIIn.TabIndex = 53
            Me.txtIMEIIn.Text = ""
            '
            'Label24
            '
            Me.Label24.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label24.ForeColor = System.Drawing.Color.Black
            Me.Label24.Location = New System.Drawing.Point(469, 22)
            Me.Label24.Name = "Label24"
            Me.Label24.Size = New System.Drawing.Size(74, 23)
            Me.Label24.TabIndex = 52
            Me.Label24.Text = "IMEI In:"
            '
            'txtMSNOut
            '
            Me.txtMSNOut.Location = New System.Drawing.Point(315, 43)
            Me.txtMSNOut.MaxLength = 11
            Me.txtMSNOut.Name = "txtMSNOut"
            Me.txtMSNOut.Size = New System.Drawing.Size(115, 22)
            Me.txtMSNOut.TabIndex = 51
            Me.txtMSNOut.Text = ""
            '
            'Label21
            '
            Me.Label21.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label21.ForeColor = System.Drawing.Color.Black
            Me.Label21.Location = New System.Drawing.Point(240, 46)
            Me.Label21.Name = "Label21"
            Me.Label21.Size = New System.Drawing.Size(82, 23)
            Me.Label21.TabIndex = 50
            Me.Label21.Text = "MSN Out:"
            '
            'txtMSNIn
            '
            Me.txtMSNIn.Location = New System.Drawing.Point(315, 18)
            Me.txtMSNIn.MaxLength = 11
            Me.txtMSNIn.Name = "txtMSNIn"
            Me.txtMSNIn.Size = New System.Drawing.Size(115, 22)
            Me.txtMSNIn.TabIndex = 49
            Me.txtMSNIn.Text = ""
            '
            'Label22
            '
            Me.Label22.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label22.ForeColor = System.Drawing.Color.Black
            Me.Label22.Location = New System.Drawing.Point(251, 22)
            Me.Label22.Name = "Label22"
            Me.Label22.Size = New System.Drawing.Size(71, 23)
            Me.Label22.TabIndex = 48
            Me.Label22.Text = "MSN In:"
            '
            'txtCSNOut
            '
            Me.txtCSNOut.Location = New System.Drawing.Point(87, 43)
            Me.txtCSNOut.MaxLength = 11
            Me.txtCSNOut.Name = "txtCSNOut"
            Me.txtCSNOut.Size = New System.Drawing.Size(115, 22)
            Me.txtCSNOut.TabIndex = 43
            Me.txtCSNOut.Text = ""
            '
            'Label20
            '
            Me.Label20.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label20.ForeColor = System.Drawing.Color.Black
            Me.Label20.Location = New System.Drawing.Point(14, 44)
            Me.Label20.Name = "Label20"
            Me.Label20.Size = New System.Drawing.Size(80, 23)
            Me.Label20.TabIndex = 42
            Me.Label20.Text = "CSN Out:"
            '
            'txtCSNIn
            '
            Me.txtCSNIn.Location = New System.Drawing.Point(87, 18)
            Me.txtCSNIn.MaxLength = 11
            Me.txtCSNIn.Name = "txtCSNIn"
            Me.txtCSNIn.Size = New System.Drawing.Size(115, 22)
            Me.txtCSNIn.TabIndex = 41
            Me.txtCSNIn.Text = ""
            '
            'Label19
            '
            Me.Label19.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label19.ForeColor = System.Drawing.Color.Black
            Me.Label19.Location = New System.Drawing.Point(25, 21)
            Me.Label19.Name = "Label19"
            Me.Label19.Size = New System.Drawing.Size(71, 23)
            Me.Label19.TabIndex = 40
            Me.Label19.Text = "CSN In:"
            '
            'GrpDeviceInfo1
            '
            Me.GrpDeviceInfo1.BackColor = System.Drawing.Color.Transparent
            Me.GrpDeviceInfo1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label30, Me.lblClaimSent, Me.lblModel, Me.Label28, Me.dtpDateShp, Me.Label3, Me.dtpDateRep, Me.dtpDateRec, Me.label4, Me.Label2, Me.txtDevice_SN, Me.Label6})
            Me.GrpDeviceInfo1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GrpDeviceInfo1.ForeColor = System.Drawing.Color.Navy
            Me.GrpDeviceInfo1.Location = New System.Drawing.Point(16, 16)
            Me.GrpDeviceInfo1.Name = "GrpDeviceInfo1"
            Me.GrpDeviceInfo1.Size = New System.Drawing.Size(779, 73)
            Me.GrpDeviceInfo1.TabIndex = 53
            Me.GrpDeviceInfo1.TabStop = False
            Me.GrpDeviceInfo1.Text = "Device Info"
            '
            'lblModel
            '
            Me.lblModel.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModel.ForeColor = System.Drawing.Color.Black
            Me.lblModel.Location = New System.Drawing.Point(335, 19)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(89, 23)
            Me.lblModel.TabIndex = 23
            '
            'Label28
            '
            Me.Label28.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label28.ForeColor = System.Drawing.Color.Black
            Me.Label28.Location = New System.Drawing.Point(277, 19)
            Me.Label28.Name = "Label28"
            Me.Label28.Size = New System.Drawing.Size(59, 13)
            Me.Label28.TabIndex = 22
            Me.Label28.Text = "Model:"
            '
            'dtpDateShp
            '
            Me.dtpDateShp.CustomFormat = "yyyy-MM-dd hh:mm:ss"
            Me.dtpDateShp.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpDateShp.Location = New System.Drawing.Point(588, 44)
            Me.dtpDateShp.Name = "dtpDateShp"
            Me.dtpDateShp.Size = New System.Drawing.Size(180, 22)
            Me.dtpDateShp.TabIndex = 21
            Me.dtpDateShp.Value = New Date(1753, 1, 1, 0, 0, 0, 0)
            '
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.Black
            Me.Label3.Location = New System.Drawing.Point(474, 46)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(120, 23)
            Me.Label3.TabIndex = 20
            Me.Label3.Text = "Date Shipped:"
            '
            'dtpDateRep
            '
            Me.dtpDateRep.CustomFormat = "yyyy-MM-dd hh:mm:ss"
            Me.dtpDateRep.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpDateRep.Location = New System.Drawing.Point(122, 44)
            Me.dtpDateRep.Name = "dtpDateRep"
            Me.dtpDateRep.Size = New System.Drawing.Size(208, 22)
            Me.dtpDateRep.TabIndex = 19
            Me.dtpDateRep.Value = New Date(1753, 1, 1, 0, 0, 0, 0)
            '
            'dtpDateRec
            '
            Me.dtpDateRec.CustomFormat = "yyyy-MM-dd hh:mm:ss"
            Me.dtpDateRec.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpDateRec.Location = New System.Drawing.Point(588, 15)
            Me.dtpDateRec.Name = "dtpDateRec"
            Me.dtpDateRec.Size = New System.Drawing.Size(180, 22)
            Me.dtpDateRec.TabIndex = 18
            Me.dtpDateRec.Value = New Date(1753, 1, 1, 0, 0, 0, 0)
            '
            'label4
            '
            Me.label4.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.label4.ForeColor = System.Drawing.Color.Black
            Me.label4.Location = New System.Drawing.Point(7, 46)
            Me.label4.Name = "label4"
            Me.label4.Size = New System.Drawing.Size(120, 23)
            Me.label4.TabIndex = 16
            Me.label4.Text = "Date Repaired:"
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.Black
            Me.Label2.Location = New System.Drawing.Point(466, 18)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(128, 23)
            Me.Label2.TabIndex = 14
            Me.Label2.Text = "Date Received:"
            '
            'txtDevice_SN
            '
            Me.txtDevice_SN.Location = New System.Drawing.Point(122, 15)
            Me.txtDevice_SN.MaxLength = 11
            Me.txtDevice_SN.Name = "txtDevice_SN"
            Me.txtDevice_SN.Size = New System.Drawing.Size(121, 22)
            Me.txtDevice_SN.TabIndex = 13
            Me.txtDevice_SN.Text = ""
            '
            'Label6
            '
            Me.Label6.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.Black
            Me.Label6.Location = New System.Drawing.Point(7, 17)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(128, 23)
            Me.Label6.TabIndex = 12
            Me.Label6.Text = "Serial Number:"
            '
            'TabComponents
            '
            Me.TabComponents.BackColor = System.Drawing.Color.PaleGoldenrod
            Me.TabComponents.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpParts})
            Me.TabComponents.ForeColor = System.Drawing.SystemColors.Control
            Me.TabComponents.Location = New System.Drawing.Point(4, 22)
            Me.TabComponents.Name = "TabComponents"
            Me.TabComponents.Size = New System.Drawing.Size(808, 398)
            Me.TabComponents.TabIndex = 1
            Me.TabComponents.Text = "Component Info"
            '
            'grpParts
            '
            Me.grpParts.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdClearChanges, Me.grpPartChanges, Me.Label27, Me.btnUpdateGrid, Me.cmbFailure, Me.lblCaptionFailure, Me.cmbRefDesig, Me.lblCaptionRefDesgn, Me.txtRefDesignator, Me.Label26, Me.grdParts})
            Me.grpParts.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grpParts.ForeColor = System.Drawing.Color.Navy
            Me.grpParts.Location = New System.Drawing.Point(15, 6)
            Me.grpParts.Name = "grpParts"
            Me.grpParts.Size = New System.Drawing.Size(779, 329)
            Me.grpParts.TabIndex = 56
            Me.grpParts.TabStop = False
            Me.grpParts.Text = "Parts"
            '
            'cmdClearChanges
            '
            Me.cmdClearChanges.BackColor = System.Drawing.Color.DarkKhaki
            Me.cmdClearChanges.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdClearChanges.Location = New System.Drawing.Point(514, 204)
            Me.cmdClearChanges.Name = "cmdClearChanges"
            Me.cmdClearChanges.Size = New System.Drawing.Size(238, 24)
            Me.cmdClearChanges.TabIndex = 73
            Me.cmdClearChanges.Text = "Clear Parts (Changes)"
            '
            'grpPartChanges
            '
            Me.grpPartChanges.Controls.AddRange(New System.Windows.Forms.Control() {Me.grdPartChages})
            Me.grpPartChanges.Location = New System.Drawing.Point(10, 227)
            Me.grpPartChanges.Name = "grpPartChanges"
            Me.grpPartChanges.Size = New System.Drawing.Size(761, 93)
            Me.grpPartChanges.TabIndex = 72
            Me.grpPartChanges.TabStop = False
            Me.grpPartChanges.Text = "Parts (Changes)"
            '
            'grdPartChages
            '
            Me.grdPartChages.AllowColMove = False
            Me.grdPartChages.AllowColSelect = False
            Me.grdPartChages.AllowFilter = False
            Me.grdPartChages.AllowRowSelect = False
            Me.grdPartChages.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.grdPartChages.AllowSort = False
            Me.grdPartChages.AllowUpdate = False
            Me.grdPartChages.AllowUpdateOnBlur = False
            Me.grdPartChages.BackColor = System.Drawing.Color.DarkKhaki
            Me.grdPartChages.CaptionHeight = 17
            Me.grdPartChages.CollapseColor = System.Drawing.Color.Black
            Me.grdPartChages.DataChanged = False
            Me.grdPartChages.BackColor = System.Drawing.Color.Empty
            Me.grdPartChages.ExpandColor = System.Drawing.Color.Black
            Me.grdPartChages.GroupByCaption = "Drag a column header here to group by that column"
            Me.grdPartChages.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.grdPartChages.Location = New System.Drawing.Point(7, 18)
            Me.grdPartChages.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
            Me.grdPartChages.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.grdPartChages.Name = "grdPartChages"
            Me.grdPartChages.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.grdPartChages.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.grdPartChages.PreviewInfo.ZoomFactor = 75
            Me.grdPartChages.PrintInfo.ShowOptionsDialog = False
            Me.grdPartChages.RecordSelectorWidth = 16
            GridLines1.Color = System.Drawing.Color.DarkGray
            GridLines1.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single
            Me.grdPartChages.RowDivider = GridLines1
            Me.grdPartChages.RowHeight = 15
            Me.grdPartChages.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.grdPartChages.ScrollTips = False
            Me.grdPartChages.Size = New System.Drawing.Size(746, 69)
            Me.grdPartChages.TabIndex = 71
            Me.grdPartChages.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Normal{Font:Verdana, 9pt, style=Bold;BackColor:DarkKhaki;}HighlightRow{ForeC" & _
            "olor:HighlightText;BackColor:Highlight;}Style1{}OddRow{}RecordSelector{AlignImag" & _
            "e:Center;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColo" & _
            "r:ControlText;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}Style12" & _
            "{}Style13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowC" & _
            "olMove=""False"" AllowColSelect=""False"" AllowRowSelect=""False"" Name="""" AllowRowSiz" & _
            "ing=""None"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" M" & _
            "arqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidth=""16"" Vert" & _
            "icalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 742, 65</ClientR" & _
            "ect><BorderSide>0</BorderSide><CaptionStyle parent=""Style2"" me=""Style10"" /><Edit" & _
            "orStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8""" & _
            " /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer" & _
            """ me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""" & _
            "Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><I" & _
            "nactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""St" & _
            "yle9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedSty" & _
            "le parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win" & _
            ".C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><St" & _
            "yle parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style " & _
            "parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style p" & _
            "arent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style paren" & _
            "t=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style pare" & _
            "nt=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style p" & _
            "arent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyl" & _
            "es><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Def" & _
            "aultRecSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 742, 65</ClientArea></B" & _
            "lob>"
            '
            'Label27
            '
            Me.Label27.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label27.ForeColor = System.Drawing.Color.Purple
            Me.Label27.Location = New System.Drawing.Point(336, 183)
            Me.Label27.Name = "Label27"
            Me.Label27.Size = New System.Drawing.Size(112, 11)
            Me.Label27.TabIndex = 67
            Me.Label27.Text = "Numeric Values Only"
            '
            'btnUpdateGrid
            '
            Me.btnUpdateGrid.BackColor = System.Drawing.Color.DarkKhaki
            Me.btnUpdateGrid.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnUpdateGrid.Location = New System.Drawing.Point(514, 174)
            Me.btnUpdateGrid.Name = "btnUpdateGrid"
            Me.btnUpdateGrid.Size = New System.Drawing.Size(238, 24)
            Me.btnUpdateGrid.TabIndex = 66
            Me.btnUpdateGrid.Text = "Update Parts (Changes)"
            '
            'cmbFailure
            '
            Me.cmbFailure.Location = New System.Drawing.Point(251, 153)
            Me.cmbFailure.Name = "cmbFailure"
            Me.cmbFailure.Size = New System.Drawing.Size(216, 22)
            Me.cmbFailure.TabIndex = 65
            Me.cmbFailure.TabStop = False
            '
            'lblCaptionFailure
            '
            Me.lblCaptionFailure.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCaptionFailure.ForeColor = System.Drawing.Color.Black
            Me.lblCaptionFailure.Location = New System.Drawing.Point(146, 154)
            Me.lblCaptionFailure.Name = "lblCaptionFailure"
            Me.lblCaptionFailure.Size = New System.Drawing.Size(112, 23)
            Me.lblCaptionFailure.TabIndex = 64
            Me.lblCaptionFailure.Text = "Failure Code:"
            '
            'cmbRefDesig
            '
            Me.cmbRefDesig.Location = New System.Drawing.Point(251, 201)
            Me.cmbRefDesig.Name = "cmbRefDesig"
            Me.cmbRefDesig.Size = New System.Drawing.Size(216, 22)
            Me.cmbRefDesig.TabIndex = 63
            Me.cmbRefDesig.TabStop = False
            '
            'lblCaptionRefDesgn
            '
            Me.lblCaptionRefDesgn.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCaptionRefDesgn.ForeColor = System.Drawing.Color.Black
            Me.lblCaptionRefDesgn.Location = New System.Drawing.Point(40, 201)
            Me.lblCaptionRefDesgn.Name = "lblCaptionRefDesgn"
            Me.lblCaptionRefDesgn.Size = New System.Drawing.Size(224, 23)
            Me.lblCaptionRefDesgn.TabIndex = 62
            Me.lblCaptionRefDesgn.Text = "Reference Designator Code:"
            '
            'txtRefDesignator
            '
            Me.txtRefDesignator.Location = New System.Drawing.Point(251, 177)
            Me.txtRefDesignator.MaxLength = 9
            Me.txtRefDesignator.Name = "txtRefDesignator"
            Me.txtRefDesignator.Size = New System.Drawing.Size(80, 22)
            Me.txtRefDesignator.TabIndex = 61
            Me.txtRefDesignator.Text = ""
            '
            'Label26
            '
            Me.Label26.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label26.ForeColor = System.Drawing.Color.Black
            Me.Label26.Location = New System.Drawing.Point(16, 177)
            Me.Label26.Name = "Label26"
            Me.Label26.Size = New System.Drawing.Size(248, 23)
            Me.Label26.TabIndex = 60
            Me.Label26.Text = "Reference Designator Number:"
            '
            'grdParts
            '
            Me.grdParts.AllowColMove = False
            Me.grdParts.AllowColSelect = False
            Me.grdParts.AllowFilter = False
            Me.grdParts.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.grdParts.AllowSort = True
            Me.grdParts.AllowUpdate = False
            Me.grdParts.AllowUpdateOnBlur = False
            Me.grdParts.BackColor = System.Drawing.Color.DarkKhaki
            Me.grdParts.CaptionHeight = 19
            Me.grdParts.CollapseColor = System.Drawing.Color.Black
            Me.grdParts.DataChanged = False
            Me.grdParts.BackColor = System.Drawing.Color.Empty
            Me.grdParts.ExpandColor = System.Drawing.Color.Black
            Me.grdParts.GroupByCaption = "Drag a column header here to group by that column"
            Me.grdParts.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.grdParts.Location = New System.Drawing.Point(11, 17)
            Me.grdParts.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
            Me.grdParts.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.grdParts.Name = "grdParts"
            Me.grdParts.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.grdParts.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.grdParts.PreviewInfo.ZoomFactor = 75
            Me.grdParts.PrintInfo.ShowOptionsDialog = False
            Me.grdParts.RecordSelectorWidth = 16
            GridLines2.Color = System.Drawing.Color.DarkGray
            GridLines2.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single
            Me.grdParts.RowDivider = GridLines2
            Me.grdParts.RowHeight = 15
            Me.grdParts.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.grdParts.ScrollTips = False
            Me.grdParts.Size = New System.Drawing.Size(757, 127)
            Me.grdParts.TabIndex = 0
            Me.grdParts.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Normal{Font:Verdana, 9pt, style=Bold;BackColor:DarkKhaki;}HighlightRow{ForeC" & _
            "olor:HighlightText;BackColor:Highlight;}Style1{}OddRow{AlignHorz:Center;BackColo" & _
            "r:Control;AlignVert:Center;}RecordSelector{AlignImage:Center;}Heading{Wrap:True;" & _
            "AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Contr" & _
            "ol;}Style8{}Style10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style9{}</Data></" & _
            "Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelec" & _
            "t=""False"" Name="""" AllowRowSizing=""None"" CaptionHeight=""17"" ColumnCaptionHeight=""" & _
            "17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=" & _
            """16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Clie" & _
            "ntRect>0, 0, 753, 123</ClientRect><BorderSide>0</BorderSide><CaptionStyle parent" & _
            "=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyl" & _
            "e parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13""" & _
            " /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Sty" & _
            "le12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""" & _
            "HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddR" & _
            "owStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelecto" & _
            "r"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""" & _
            "Normal"" me=""Style1"" /></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Sty" & _
            "le parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""" & _
            "Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Hea" & _
            "ding"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Norm" & _
            "al"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Norm" & _
            "al"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" " & _
            "me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Cap" & _
            "tion"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSp" & _
            "lits><Layout>None</Layout><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientArea" & _
            ">0, 0, 753, 123</ClientArea></Blob>"
            '
            'TabRMAInfo
            '
            Me.TabRMAInfo.BackColor = System.Drawing.Color.PaleGoldenrod
            Me.TabRMAInfo.Controls.AddRange(New System.Windows.Forms.Control() {Me.GrpRMAInfo})
            Me.TabRMAInfo.ForeColor = System.Drawing.SystemColors.Control
            Me.TabRMAInfo.Location = New System.Drawing.Point(4, 22)
            Me.TabRMAInfo.Name = "TabRMAInfo"
            Me.TabRMAInfo.Size = New System.Drawing.Size(808, 398)
            Me.TabRMAInfo.TabIndex = 2
            Me.TabRMAInfo.Text = "RMA Info"
            '
            'GrpRMAInfo
            '
            Me.GrpRMAInfo.BackColor = System.Drawing.Color.Transparent
            Me.GrpRMAInfo.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblRMANumber, Me.Label8, Me.lblWO_ID, Me.Label7})
            Me.GrpRMAInfo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GrpRMAInfo.ForeColor = System.Drawing.Color.Navy
            Me.GrpRMAInfo.Location = New System.Drawing.Point(24, 32)
            Me.GrpRMAInfo.Name = "GrpRMAInfo"
            Me.GrpRMAInfo.Size = New System.Drawing.Size(592, 47)
            Me.GrpRMAInfo.TabIndex = 52
            Me.GrpRMAInfo.TabStop = False
            Me.GrpRMAInfo.Text = "RMA Info"
            '
            'lblRMANumber
            '
            Me.lblRMANumber.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRMANumber.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblRMANumber.Location = New System.Drawing.Point(368, 20)
            Me.lblRMANumber.Name = "lblRMANumber"
            Me.lblRMANumber.Size = New System.Drawing.Size(216, 23)
            Me.lblRMANumber.TabIndex = 23
            '
            'Label8
            '
            Me.Label8.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.Black
            Me.Label8.Location = New System.Drawing.Point(147, 20)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(240, 23)
            Me.Label8.TabIndex = 22
            Me.Label8.Text = "Customer Reference Number:"
            '
            'lblWO_ID
            '
            Me.lblWO_ID.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWO_ID.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblWO_ID.Location = New System.Drawing.Point(69, 19)
            Me.lblWO_ID.Name = "lblWO_ID"
            Me.lblWO_ID.Size = New System.Drawing.Size(64, 23)
            Me.lblWO_ID.TabIndex = 21
            '
            'Label7
            '
            Me.Label7.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.Black
            Me.Label7.Location = New System.Drawing.Point(8, 19)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(64, 23)
            Me.Label7.TabIndex = 20
            Me.Label7.Text = "WO ID:"
            '
            'Label29
            '
            Me.Label29.Location = New System.Drawing.Point(246, 49)
            Me.Label29.Name = "Label29"
            Me.Label29.Size = New System.Drawing.Size(578, 24)
            Me.Label29.TabIndex = 63
            '
            'lblHeading
            '
            Me.lblHeading.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.lblHeading.BackColor = System.Drawing.Color.MidnightBlue
            Me.lblHeading.Font = New System.Drawing.Font("Comic Sans MS", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblHeading.ForeColor = System.Drawing.Color.White
            Me.lblHeading.Location = New System.Drawing.Point(296, 0)
            Me.lblHeading.Name = "lblHeading"
            Me.lblHeading.Size = New System.Drawing.Size(704, 40)
            Me.lblHeading.TabIndex = 64
            Me.lblHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Panel2
            '
            Me.Panel2.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.Panel2.BackColor = System.Drawing.Color.MidnightBlue
            Me.Panel2.Location = New System.Drawing.Point(968, 0)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(48, 557)
            Me.Panel2.TabIndex = 65
            '
            'Panel3
            '
            Me.Panel3.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.Panel3.BackColor = System.Drawing.Color.MidnightBlue
            Me.Panel3.Location = New System.Drawing.Point(0, 525)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(992, 32)
            Me.Panel3.TabIndex = 67
            '
            'lblClaimNumber
            '
            Me.lblClaimNumber.BackColor = System.Drawing.Color.MidnightBlue
            Me.lblClaimNumber.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblClaimNumber.ForeColor = System.Drawing.Color.White
            Me.lblClaimNumber.Location = New System.Drawing.Point(309, 8)
            Me.lblClaimNumber.Name = "lblClaimNumber"
            Me.lblClaimNumber.Size = New System.Drawing.Size(91, 23)
            Me.lblClaimNumber.TabIndex = 68
            Me.lblClaimNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblClaimSent
            '
            Me.lblClaimSent.BackColor = System.Drawing.Color.Transparent
            Me.lblClaimSent.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblClaimSent.ForeColor = System.Drawing.Color.Black
            Me.lblClaimSent.Location = New System.Drawing.Point(428, 47)
            Me.lblClaimSent.Name = "lblClaimSent"
            Me.lblClaimSent.Size = New System.Drawing.Size(24, 16)
            Me.lblClaimSent.TabIndex = 70
            Me.lblClaimSent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label30
            '
            Me.Label30.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label30.ForeColor = System.Drawing.Color.Black
            Me.Label30.Location = New System.Drawing.Point(332, 48)
            Me.Label30.Name = "Label30"
            Me.Label30.Size = New System.Drawing.Size(99, 13)
            Me.Label30.TabIndex = 71
            Me.Label30.Text = "Claim Sent:"
            Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'frmEditClaims
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.AutoScroll = True
            Me.BackColor = System.Drawing.Color.PaleGoldenrod
            Me.ClientSize = New System.Drawing.Size(992, 557)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblClaimNumber, Me.Panel3, Me.Panel2, Me.lblHeading, Me.Label29, Me.TabControl1, Me.cmdClearScreen, Me.btnUpdateClaim, Me.GroupBox1, Me.Panel1})
            Me.Name = "frmEditClaims"
            Me.Text = "Edit Claims"
            Me.Panel1.ResumeLayout(False)
            Me.GroupBox1.ResumeLayout(False)
            Me.TabControl1.ResumeLayout(False)
            Me.TabClaim.ResumeLayout(False)
            Me.grpCodes.ResumeLayout(False)
            Me.GrpDeviceInfo2.ResumeLayout(False)
            Me.GrpDeviceInfo1.ResumeLayout(False)
            Me.TabComponents.ResumeLayout(False)
            Me.grpParts.ResumeLayout(False)
            Me.grpPartChanges.ResumeLayout(False)
            CType(Me.grdPartChages, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.grdParts, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabRMAInfo.ResumeLayout(False)
            Me.GrpRMAInfo.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        '**************************************************************
        Private Sub frmEditClaims_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Enter

            With Me
                .cmbCarrCode.SelectedValue = 0
                .cmbAPCCode.SelectedValue = 0
                .cmbComplaintCode.SelectedValue = 0
                .cmbProbCode.SelectedValue = 0
                .cmbRepCode.SelectedValue = 0
                .cmbTransactionCode.SelectedValue = 0
                .cmbTech.SelectedValue = 0
                .cmbRefDesig.SelectedValue = 0
                .cmbFailure.SelectedValue = 0
            End With

        End Sub

        '**************************************************************
        Private Sub frmEditClaims_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim objTechs As New PSS.Data.Production.tusers()
            Dim myDataRow As DataRow

            Try
                If iClaimType = 0 Then
                    Me.lblHeading.Text = "ASC Claims"
                ElseIf iClaimType = 1 Then
                    Me.lblHeading.Text = "Sub Claims"
                End If

                CreatePartsUpdateTable()

                '********************************************************
                'Load Tech IDs
                '********************************************************
                dt = objTechs.GetCellTechList

                'Insert an empty row into the datatable
                myDataRow = dt.NewRow
                myDataRow("Tech_ID") = 0
                myDataRow("User_FullName") = ""
                dt.Rows.Add(myDataRow)
                myDataRow = Nothing

                Me.cmbTech.DataSource = dt.DefaultView
                Me.cmbTech.DisplayMember = dt.Columns("User_FullName").ToString
                Me.cmbTech.ValueMember = dt.Columns("Tech_ID").ToString
                Me.cmbTech.SelectedValue = 0

                '**************************
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If

                '********************************************************
                'Load Carrier Codes
                '********************************************************
                objMotoSubcontract_Biz = New PSS.Data.Buisness.MotorolaSubcontract_Biz()
                dt = objMotoSubcontract_Biz.GetCodes(1, 2, 1)

                Me.cmbCarrCode.DataSource = dt.DefaultView
                Me.cmbCarrCode.DisplayMember = dt.Columns("Dcode_LDesc").ToString
                Me.cmbCarrCode.ValueMember = dt.Columns("Dcode_ID").ToString

                '**************************
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If

                '********************************************************
                'Load Transaction Codes
                '********************************************************
                objMotoSubcontract_Biz = New PSS.Data.Buisness.MotorolaSubcontract_Biz()
                dt = objMotoSubcontract_Biz.GetCodes(1, 2, 8)

                Me.cmbTransactionCode.DataSource = dt.DefaultView
                Me.cmbTransactionCode.DisplayMember = dt.Columns("Dcode_LDesc").ToString
                Me.cmbTransactionCode.ValueMember = dt.Columns("Dcode_ID").ToString

                '**************************
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If

                '********************************************************
                'Load Complaint Codes
                '********************************************************
                objMotoSubcontract_Biz = New PSS.Data.Buisness.MotorolaSubcontract_Biz()
                dt = objMotoSubcontract_Biz.GetCodes(1, 2, 5)

                Me.cmbComplaintCode.DataSource = dt.DefaultView
                Me.cmbComplaintCode.DisplayMember = dt.Columns("Dcode_LDesc").ToString
                Me.cmbComplaintCode.ValueMember = dt.Columns("Dcode_ID").ToString

                '**************************
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If

                '********************************************************
                'Load APC Codes
                '********************************************************
                objMotoSubcontract_Biz = New PSS.Data.Buisness.MotorolaSubcontract_Biz()
                dt = objMotoSubcontract_Biz.GetCodes(1, 2, 6)

                Me.cmbAPCCode.DataSource = dt.DefaultView
                Me.cmbAPCCode.DisplayMember = dt.Columns("Dcode_SDesc").ToString
                Me.cmbAPCCode.ValueMember = dt.Columns("Dcode_ID").ToString

                '**************************
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If

                '********************************************************
                'Load Problem Found Codes
                '********************************************************
                objMotoSubcontract_Biz = New PSS.Data.Buisness.MotorolaSubcontract_Biz()
                dt = objMotoSubcontract_Biz.GetCodes(1, 2, 9)

                Me.cmbProbCode.DataSource = dt.DefaultView
                Me.cmbProbCode.DisplayMember = dt.Columns("Dcode_LDesc").ToString
                Me.cmbProbCode.ValueMember = dt.Columns("Dcode_ID").ToString

                '**************************
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If

                '********************************************************
                'Load Repair Action Codes
                '********************************************************
                objMotoSubcontract_Biz = New PSS.Data.Buisness.MotorolaSubcontract_Biz()
                dt = objMotoSubcontract_Biz.GetCodes(1, 2, 3)

                Me.cmbRepCode.DataSource = dt.DefaultView
                Me.cmbRepCode.DisplayMember = dt.Columns("Dcode_LDesc").ToString
                Me.cmbRepCode.ValueMember = dt.Columns("Dcode_ID").ToString

                '**************************
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                '********************************************************
                'Load Ref Design code
                '********************************************************
                objMotoSubcontract_Biz = New PSS.Data.Buisness.MotorolaSubcontract_Biz()
                dt = objMotoSubcontract_Biz.GetCodes(1, 2, 11)

                Me.cmbRefDesig.DataSource = dt.DefaultView
                Me.cmbRefDesig.DisplayMember = dt.Columns("Dcode_LDesc").ToString
                Me.cmbRefDesig.ValueMember = dt.Columns("Dcode_ID").ToString

                '**************************
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                '********************************************************
                'Load failure codes
                '********************************************************
                objMotoSubcontract_Biz = New PSS.Data.Buisness.MotorolaSubcontract_Biz()
                dt = objMotoSubcontract_Biz.GetCodes(1, 2, 4)

                Me.cmbFailure.DataSource = dt.DefaultView
                Me.cmbFailure.DisplayMember = dt.Columns("Dcode_LDesc").ToString
                Me.cmbFailure.ValueMember = dt.Columns("Dcode_ID").ToString

                '**************************
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                '********************************************************

            Catch ex As Exception
                MsgBox("Error in frmEditClaims_Load:: " & ex.Message, MsgBoxStyle.Critical)
            Finally
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If

                objTechs = Nothing
                objMotoSubcontract_Biz = Nothing
            End Try


            '********************************************************

        End Sub
        '**************************************************************
        Private Sub txtClaimNum_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtClaimNum.KeyDown
            If e.KeyValue = 13 Then
                GetDeviceInfo()
            End If
        End Sub
        '**************************************************************
        Private Sub btnUpdateClaim_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateClaim.Click
            Dim strsql As String = ""
            Dim iCounter As Integer = 0
            Dim R1 As DataRow

            Dim strRetVar As String
            'Dim i As Integer = 0

            objMotoSubcontract_Biz = New PSS.Data.Buisness.MotorolaSubcontract_Biz()

            Try
                '********************************************************************************************
                'Validations
                '********************************************************************************************
                'Serial Number, CSN in, CSN Out
                If Trim(Me.txtIMEIIn.Text) = "" Then      'If it is not a GSM phone
                    If Len(Trim(Me.txtDevice_SN.Text)) <> 11 Then
                        MsgBox("'Serial Number' must be 11 characters long.", MsgBoxStyle.Critical, "Motorola Rules")
                        Exit Sub
                    End If
                    If Len(Trim(Me.txtCSNIn.Text)) <> 11 Then
                        MsgBox("'CSN In' must be 11 characters long.", MsgBoxStyle.Critical, "Motorola Rules")
                        Exit Sub
                    End If
                    If Len(Trim(Me.txtCSNOut.Text)) <> 11 Then
                        MsgBox("'CSN Out' must be 11 characters long.", MsgBoxStyle.Critical, "Motorola Rules")
                        Exit Sub
                    End If
                Else    'if it is a GSM phone
                    If Len(Trim(Me.txtDevice_SN.Text)) <> 11 And Len(Trim(Me.txtDevice_SN.Text)) <> 10 Then
                        MsgBox("'Serial Number' must be either 10 or 11 characters long for a GSM phone.", MsgBoxStyle.Critical, "Motorola Rules")
                        Exit Sub
                    End If
                    If Len(Trim(Me.txtMSNIn.Text)) <> 10 Then
                        MsgBox("'MSN In' must be 10 characters long for a GSM phone.", MsgBoxStyle.Critical, "Motorola Rules")
                        Exit Sub
                    End If
                    If Len(Trim(Me.txtMSNOut.Text)) <> 10 Then
                        MsgBox("'MSN Out' must be 10 characters long for a GSM phone.", MsgBoxStyle.Critical, "Motorola Rules")
                        Exit Sub
                    End If
                End If
                '********************************
                'TansceiverCode
                If Len(Trim(Me.txtTransaceiver.Text)) <> 9 Then
                    MsgBox("Transceiver Code (SUG number) must be 9 character long.", MsgBoxStyle.Critical, "Motorola Rules")
                    Exit Sub
                End If
                '********************************
                'bill_date/repair_date earlier than receive date
                If Me.dtpDateRep.Text <> "" And Not Me.dtpDateRec.Text <> "" Then
                    If Me.dtpDateRep.Value < Me.dtpDateRec.Value Then
                        MsgBox("'Date of Repair' can't be before 'Date Received'.", MsgBoxStyle.Critical, "Motorola Rules")
                        Exit Sub
                    End If
                End If
                '********************************
                ''Date of Purchase' can't be later than 'Date Received'
                If Me.dtpDatePurchase.Text <> "" And Me.dtpDateRec.Text <> "" Then
                    If Me.dtpDatePurchase.Value > Me.dtpDateRec.Value Then
                        MsgBox("'Date of Purchase' can't be later than 'Date Received'.", MsgBoxStyle.Critical, "Motorola Rules")
                        Exit Sub
                    End If
                End If
                '********************************
                'Air time carrier code is missing
                If Me.cmbCarrCode.SelectedValue = 0 Then
                    MsgBox("'Airtime Carrier Code' required.", MsgBoxStyle.Critical, "Motorola Rules")
                    Exit Sub
                End If
                '********************************
                '"'Transaction Code' is missing."
                If Me.cmbTransactionCode.SelectedValue = 0 Then
                    MsgBox("'Transaction Code' required.", MsgBoxStyle.Critical, "Motorola Rules")
                    Exit Sub
                End If
                '********************************
                '"'APC Code' is missing."
                If Me.cmbAPCCode.SelectedValue = 0 Then
                    MsgBox("'APC Code' required.", MsgBoxStyle.Critical, "Motorola Rules")
                    Exit Sub
                End If
                '********************************
                ''Repair Action Code' is missing.
                If Me.cmbRepCode.SelectedValue = 0 Then
                    MsgBox("'Repair Action Code' required.", MsgBoxStyle.Critical, "Motorola Rules")
                    Exit Sub
                End If
                '********************************
                ''Problem Found Code' is missing.
                If Me.cmbProbCode.SelectedValue = 0 Then
                    MsgBox("'Problem Found Code' required.", MsgBoxStyle.Critical, "Motorola Rules")
                    Exit Sub
                End If
                '********************************
                ''Complaint Code' is missing.
                If Me.cmbComplaintCode.SelectedValue = 0 Then
                    MsgBox("'Complaint Code' required.", MsgBoxStyle.Critical, "Motorola Rules")
                    Exit Sub
                End If
                '********************************
                ''Tech ID' is missing.
                If Me.cmbTech.SelectedValue = 0 Then
                    MsgBox("'Tech ID' required.", MsgBoxStyle.Critical, "Motorola Rules")
                    Exit Sub
                End If
                '********************************
                ''Software Version In' is missing.
                If Me.txtSoftIn.Text = "" Then
                    MsgBox("'Software Version In' required.", MsgBoxStyle.Critical, "Motorola Rules")
                    Exit Sub
                End If
                '********************************
                ''Software Version Out' is missing.
                If Me.txtSoftOut.Text = "" Then
                    MsgBox("'Software Version Out' required.", MsgBoxStyle.Critical, "Motorola Rules")
                    Exit Sub
                End If

                '********************************
                'Airtime
                If Me.txtAirtime.Text = "" Then
                    MsgBox("'Airtime' required.", MsgBoxStyle.Critical, "Motorola Rules")
                    Exit Sub
                End If
                '********************************
                'IMEI and ESN/CSN Logic

                If Trim(Me.txtIMEIIn.Text) <> "" Then       'GSM Phone
                    '********
                    If Trim(Me.txtIMEIOut.Text) = "" Then
                        'imei out is missing
                        MsgBox("'IMEI Out' is missing.", MsgBoxStyle.Critical, "Motorola Rules")
                        Exit Sub
                    End If
                    '********
                    'Check if the MSN IN is there
                    If Trim(Me.txtMSNIn.Text) = "" Then
                        'imei out is missing
                        MsgBox("'MSN In' is missing.", MsgBoxStyle.Critical, "Motorola Rules")
                        Exit Sub
                    End If
                    '********
                    'Check if the MSN Out is there
                    If Trim(Me.txtMSNOut.Text) = "" Then
                        'imei out is missing
                        'strRetVar += "'MSN Out' is missing." + vbCrLf
                        MsgBox("'MSN Out' is missing.", MsgBoxStyle.Critical, "Motorola Rules")
                        Exit Sub
                    End If
                    '********
                    'Check if CSN In is there
                    If Trim(Me.txtCSNIn.Text) <> "" Then
                        MsgBox("'CSN In' not allowed for GSM phones.", MsgBoxStyle.Critical, "Motorola Rules")
                        Exit Sub
                    End If
                    '********
                    'Check if CSN Out is there
                    If Trim(Me.txtCSNOut.Text) <> "" Then
                        MsgBox("'CSN Out' not allowed for GSM phones.", MsgBoxStyle.Critical, "Motorola Rules")
                        Exit Sub
                    End If
                    '********
                Else                                    'Non-GSM Phone
                    '********
                    If Trim(Me.txtIMEIOut.Text) <> "" Then
                        MsgBox("'IMEI Out' is not allowed for a non-GSM phone.", MsgBoxStyle.Critical, "Motorola Rules")
                        Exit Sub
                    End If
                    '********
                    If Trim(Me.txtCSNIn.Text) = "" Then
                        MsgBox("'CSN In' is missing for a non-GSM phone.", MsgBoxStyle.Critical, "Motorola Rules")
                        Exit Sub
                    Else
                        If Len(Trim(Me.txtCSNIn.Text)) <> 11 Then
                            MsgBox("'CSN In' can be 11 characters long only.", MsgBoxStyle.Critical, "Motorola Rules")
                            Exit Sub
                        End If
                    End If
                    '********
                    If Trim(Me.txtCSNOut.Text) = "" Then
                        MsgBox("'CSN Out' is missing for a non-GSM phone.", MsgBoxStyle.Critical, "Motorola Rules")
                        Exit Sub
                    Else
                        If Len(Trim(Me.txtCSNOut.Text)) <> 11 Then
                            MsgBox("'CSN Out' can be 11 characters long only.", MsgBoxStyle.Critical, "Motorola Rules")
                            Exit Sub
                        End If
                    End If
                    '********
                End If

                '********************************
                'RefDesigNum
                If Trim(Me.txtRefDesignator.Text) <> "" Then
                    If Not IsNumeric(Trim(Me.txtRefDesignator.Text)) Then
                        MsgBox("'Reference Designator Number' must be a numeric value.", MsgBoxStyle.Critical, "Motorola Rules")
                        Exit Sub
                    End If
                End If

                '********************************************************************************************
                'Data comparison with original data and build the query
                '********************************************************************************************
                'STEP1: Update tdevice

                strsql = "UPDATE tdevice set "
                If Trim(strDeviceSn) <> Trim(Me.txtDevice_SN.Text) Then
                    strsql += "Device_SN = '" & Trim(Me.txtDevice_SN.Text) & "'" & Environment.NewLine
                    iCounter += 1
                End If
                If Trim(strDateRec) <> Trim(Me.dtpDateRec.Text) And Me.dtpDateRec.Text <> "1753-01-01 12:00:00" Then
                    If iCounter <> 0 Then
                        strsql += ", "
                    End If
                    strsql += "Device_DateRec = '" & Trim(Me.dtpDateRec.Text) & "'" & Environment.NewLine
                    iCounter += 1
                End If
                If Trim(strDateRepaired) <> Trim(Me.dtpDateRep.Text) And Me.dtpDateRep.Text <> "1753-01-01 12:00:00" Then   'Bill date is repair date
                    If iCounter <> 0 Then
                        strsql += ", "
                    End If
                    strsql += "Device_DateBill = '" & Trim(Me.dtpDateRep.Text) & "'" & Environment.NewLine
                    iCounter += 1
                End If
                If iClaimType = 0 Then
                    If Trim(strDateShip) <> Trim(Me.dtpDateShp.Text) And Me.dtpDateShp.Text <> "1753-01-01 12:00:00" Then    'Bill date is repair date
                        If iCounter <> 0 Then
                            strsql += ", "
                        End If
                        strsql += "Device_DateShip = '" & Trim(Me.dtpDateShp.Text) & "'" & Environment.NewLine
                        iCounter += 1
                    End If
                End If
                strsql += " Where device_id = " & iDeviceId

                If iCounter > 0 Then
                    iCounter = objMotoSubcontract_Biz.ExecuteNonQueries(strsql)
                End If
                '*********Update the tpallett with the ship date
                strsql = ""
                iCounter = 0
                If iClaimType = 1 Then
                    If (Trim(strDateShip) & " 12:00:00") <> Trim(Me.dtpDateShp.Text) And Me.dtpDateShp.Text <> "1753-01-01 12:00:00" Then    'Bill date is repair date
                        strsql = "Update tpallett inner join tdevice on tdevice.pallett_id = tpallett.pallett_id set tpallett.pallett_shipdate = '" & Trim(Me.dtpDateShp.Text) & "' Where tdevice.device_id = " & iDeviceId & ";"
                        iCounter = objMotoSubcontract_Biz.ExecuteNonQueries(strsql)
                    End If
                End If
                '*************************************************************************************
                'STEP 2:::  Update tcellopt

                strsql = ""
                iCounter = 0

                strsql = "UPDATE tcellopt set "
                If Trim(strCSNin) <> Trim(Me.txtCSNIn.Text) Then
                    strsql += "Cellopt_CSN = '" & Trim(Me.txtCSNIn.Text) & "'" & Environment.NewLine
                    iCounter += 1
                End If
                If Trim(strCSNOut) <> Trim(Me.txtCSNOut.Text) Then
                    If iCounter <> 0 Then
                        strsql += ", "
                    End If
                    strsql += "Cellopt_OutCSN = '" & Trim(Me.txtCSNOut.Text) & "'" & Environment.NewLine
                    iCounter += 1
                End If
                If Trim(strMSNin) <> Trim(Me.txtMSNIn.Text) Then
                    If iCounter <> 0 Then
                        strsql += ", "
                    End If
                    strsql += "Cellopt_MSN = '" & Trim(Me.txtMSNIn.Text) & "'" & Environment.NewLine
                    iCounter += 1
                End If
                If Trim(strMSNOut) <> Trim(Me.txtMSNOut.Text) Then
                    If iCounter <> 0 Then
                        strsql += ", "
                    End If
                    strsql += "Cellopt_OutMSN = '" & Trim(Me.txtMSNOut.Text) & "'" & Environment.NewLine
                    iCounter += 1
                End If
                If Trim(strIMEIin) <> Trim(Me.txtIMEIIn.Text) Then
                    If iCounter <> 0 Then
                        strsql += ", "
                    End If
                    strsql += "Cellopt_IMEI = '" & Trim(Me.txtIMEIIn.Text) & "'" & Environment.NewLine
                    iCounter += 1
                End If
                If Trim(strIMEIOut) <> Trim(Me.txtIMEIOut.Text) Then
                    If iCounter <> 0 Then
                        strsql += ", "
                    End If
                    strsql += "Cellopt_OutIMEI = '" & Trim(Me.txtIMEIOut.Text) & "'" & Environment.NewLine
                    iCounter += 1
                End If
                If Trim(strTransceiver) <> Trim(Me.txtTransaceiver.Text) Then
                    If iCounter <> 0 Then
                        strsql += ", "
                    End If
                    strsql += "Cellopt_Transceiver = '" & Trim(Me.txtTransaceiver.Text) & "'" & Environment.NewLine
                    iCounter += 1
                End If
                If Trim(strDatePOP) <> Trim(Me.dtpDatePurchase.Text) And Me.dtpDatePurchase.Text <> "1753-01-01 12:00:00" Then
                    If iCounter <> 0 Then
                        strsql += ", "
                    End If
                    strsql += "Cellopt_POP = '" & Trim(Me.dtpDatePurchase.Text) & "'" & Environment.NewLine
                    iCounter += 1
                End If
                If Trim(strSoftIn) <> Trim(Me.txtSoftIn.Text) Then
                    If iCounter <> 0 Then
                        strsql += ", "
                    End If
                    strsql += "Cellopt_SoftVerIn = '" & Trim(Me.txtSoftIn.Text) & "'" & Environment.NewLine
                    iCounter += 1
                End If
                If Trim(strSoftOut) <> Trim(Me.txtSoftOut.Text) Then
                    If iCounter <> 0 Then
                        strsql += ", "
                    End If
                    strsql += "Cellopt_SoftVerOut = '" & Trim(Me.txtSoftOut.Text) & "'" & Environment.NewLine
                    iCounter += 1
                End If
                If Trim(strAirtime) <> Trim(Me.txtAirtime.Text) Then
                    If iCounter <> 0 Then
                        strsql += ", "
                    End If
                    strsql += "Cellopt_Airtime = '" & Trim(Me.txtAirtime.Text) & "'" & Environment.NewLine
                    iCounter += 1
                End If
                If iTechID <> Me.cmbTech.SelectedValue Then
                    If iCounter <> 0 Then
                        strsql += ", "
                    End If
                    strsql += "Cellopt_TechID = '" & Me.cmbTech.SelectedValue & "'" & Environment.NewLine
                    iCounter += 1
                End If

                strsql += " Where device_id = " & iDeviceId

                If iCounter > 0 Then
                    iCounter = objMotoSubcontract_Biz.ExecuteNonQueries(strsql)
                End If
                '**************************************************************************************
                'STEP 3::       Update tdevicecodes

                strsql = ""
                iCounter = 0

                If iDcodeID_CarrCode <> Me.cmbCarrCode.SelectedValue Then
                    If iDcodeID_CarrCode > 0 Then
                        strsql = "UPDATE tdevicecodes set dcode_id = " & Me.cmbCarrCode.SelectedValue & " where device_id = " & iDeviceId & " and Dcode_ID = " & iDcodeID_CarrCode & ";"
                    Else
                        strsql = "Replace into tdevicecodes (device_id, dcode_id) values (" & iDeviceId & ", " & Me.cmbCarrCode.SelectedValue & ");"
                    End If

                    If strsql <> "" Then
                        iCounter = objMotoSubcontract_Biz.ExecuteNonQueries(strsql)
                    End If
                End If

                strsql = ""
                iCounter = 0

                If iDcodeID_Transaction <> Me.cmbTransactionCode.SelectedValue Then
                    If iDcodeID_Transaction > 0 Then
                        strsql = "UPDATE tdevicecodes set dcode_id = " & Me.cmbTransactionCode.SelectedValue & " where device_id = " & iDeviceId & " and Dcode_ID = " & iDcodeID_Transaction & ";"
                    Else
                        strsql = "Replace into tdevicecodes (device_id, dcode_id) values (" & iDeviceId & ", " & Me.cmbTransactionCode.SelectedValue & ");"
                    End If
                    If strsql <> "" Then
                        iCounter = objMotoSubcontract_Biz.ExecuteNonQueries(strsql)
                    End If
                End If

                strsql = ""
                iCounter = 0

                If iDcodeID_Complaint <> Me.cmbComplaintCode.SelectedValue Then
                    If iDcodeID_Complaint > 0 Then
                        strsql = "UPDATE tdevicecodes set dcode_id = " & Me.cmbComplaintCode.SelectedValue & " where device_id = " & iDeviceId & " and Dcode_ID = " & iDcodeID_Complaint & ";"
                    Else
                        strsql = "Replace into tdevicecodes (device_id, dcode_id) values (" & iDeviceId & ", " & Me.cmbComplaintCode.SelectedValue & ");"
                    End If
                    If strsql <> "" Then
                        iCounter = objMotoSubcontract_Biz.ExecuteNonQueries(strsql)
                    End If
                End If

                strsql = ""
                iCounter = 0

                If iDcodeID_APC <> Me.cmbAPCCode.SelectedValue Then
                    If iDcodeID_APC > 0 Then
                        strsql = "UPDATE tdevicecodes set dcode_id = " & Me.cmbAPCCode.SelectedValue & " where device_id = " & iDeviceId & " and Dcode_ID = " & iDcodeID_APC & ";"
                    Else
                        strsql = "Replace into tdevicecodes (device_id, dcode_id) values (" & iDeviceId & ", " & Me.cmbAPCCode.SelectedValue & ");"
                    End If
                    If strsql <> "" Then
                        iCounter = objMotoSubcontract_Biz.ExecuteNonQueries(strsql)
                    End If
                End If

                strsql = ""
                iCounter = 0

                If iDcodeID_Problem <> Me.cmbProbCode.SelectedValue Then
                    If iDcodeID_Problem > 0 Then
                        strsql = "UPDATE tdevicecodes set dcode_id = " & Me.cmbProbCode.SelectedValue & " where device_id = " & iDeviceId & " and Dcode_ID = " & iDcodeID_Problem & ";"
                    Else
                        strsql = "Replace into tdevicecodes (device_id, dcode_id) values (" & iDeviceId & ", " & Me.cmbProbCode.SelectedValue & ");"
                    End If
                    If strsql <> "" Then
                        iCounter = objMotoSubcontract_Biz.ExecuteNonQueries(strsql)
                    End If
                End If

                strsql = ""
                iCounter = 0

                If iDcodeID_Repair <> Me.cmbRepCode.SelectedValue Then
                    If iDcodeID_Repair > 0 Then
                        strsql = "UPDATE tdevicecodes set dcode_id = " & Me.cmbRepCode.SelectedValue & " where device_id = " & iDeviceId & " and Dcode_ID = " & iDcodeID_Repair & ";"
                    Else
                        strsql = "Replace into tdevicecodes (device_id, dcode_id) values (" & iDeviceId & ", " & Me.cmbRepCode.SelectedValue & ");"
                    End If
                    If strsql <> "" Then
                        iCounter = objMotoSubcontract_Biz.ExecuteNonQueries(strsql)
                    End If
                End If

                '**************************************************************************************
                'STEP 4::: Update Parts codes
                iCounter = 0

                If Not IsNothing(myDataTable) Then
                    For Each R1 In myDataTable.Rows

                        'Step A
                        iCounter = 0
                        strsql = ""
                        If R1("Dcode_ID_Old") <> R1("Dcode_ID_New") Then
                            strsql = "Update tpartscodes set DCode_ID = " & R1("Dcode_ID_New") & " Where tpartscode_id = " & R1("tPartsCode_ID") & ";"
                            iCounter = objMotoSubcontract_Biz.ExecuteNonQueries(strsql)
                        End If

                        'STEP B
                        iCounter = 0
                        strsql = ""
                        If R1("RefDesigNum") <> "" Then
                            strsql = "Update tbillcell set BCell_RefDSNum = " & R1("RefDesigNum") & " Where DBill_ID = " & R1("DBill_ID") & ";"
                            iCounter = objMotoSubcontract_Biz.ExecuteNonQueries(strsql)
                        End If
                    Next
                End If

                '**************************************************************************************
                MsgBox("Claim is updated.", MsgBoxStyle.Information)
                ClearControls()

            Catch ex As Exception
                MsgBox("Error in btnUpdateClaim_Click:: " & ex.Message, MsgBoxStyle.Critical)
            Finally
                objMotoSubcontract_Biz = Nothing
            End Try

        End Sub

        '***********************************************************************************************
        Private Sub grdParts_RowColChange(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles grdParts.RowColChange
            Dim R1 As DataRow
            Dim i As Integer = 0
            

            Try
                If Me.grdParts.Columns.Count <> 0 Then
                    Me.txtRefDesignator.Text = Me.grdParts.Columns("RefDesigNum").Value
                    If Not IsDBNull(Me.grdParts.Columns("mcode_id").Value) Then
                        If CStr(Me.grdParts.Columns("mcode_id").Value) = "11" Then       'Reference Designator Code

                            If CStr(Me.grdParts.Columns("dcode_id").Value) <> "" Then
                                Me.cmbRefDesig.SelectedValue = Me.grdParts.Columns("dcode_id").Value
                            Else
                                Me.cmbRefDesig.SelectedValue = 0    'Select the empty space
                            End If

                            Me.cmbRefDesig.Visible = True
                            Me.lblCaptionRefDesgn.Visible = True
                            Me.cmbFailure.Visible = False
                            Me.lblCaptionFailure.Visible = False

                        ElseIf CStr(Me.grdParts.Columns("mcode_id").Value) = "4" Then    'Failure Code

                            If CStr(Me.grdParts.Columns("dcode_id").Value) <> "" Then
                                Me.cmbFailure.SelectedValue = Me.grdParts.Columns("dcode_id").Value
                            Else
                                Me.cmbFailure.SelectedValue = 0    'Select the empty space
                            End If

                            Me.cmbRefDesig.Visible = False
                            Me.lblCaptionRefDesgn.Visible = False
                            Me.cmbFailure.Visible = True
                            Me.lblCaptionFailure.Visible = True
                        End If

                    Else
                        iFailureCode = 0
                        iRefDesigCode = 0

                        'Determine what is being edited 
                        For Each R1 In dtParts.Rows

                            If R1("DBill_ID") = Me.grdParts.Columns("DBill_ID").Value Then
                                If IsDBNull(R1("MCode_ID")) Then
                                    '' Do nothing
                                ElseIf CStr(Trim(R1("MCode_ID"))) = "11" Then       'Ref Designator
                                    iRefDesigCode = 1
                                ElseIf CStr(Trim(R1("MCode_ID"))) = "4" Then        'Failure
                                    iFailureCode = 1
                                End If
                            End If

                        Next R1
                        '***************************
                        'Both Missing
                        '***************************
                        If iRefDesigCode = 0 And iFailureCode = 0 Then

                            Me.cmbFailure.SelectedValue = 0    'Select the empty space
                            Me.cmbRefDesig.SelectedValue = 0    'Select the empty space
                            Me.cmbRefDesig.Visible = True
                            Me.lblCaptionRefDesgn.Visible = True
                            Me.cmbFailure.Visible = True
                            Me.lblCaptionFailure.Visible = True

                        ElseIf iRefDesigCode = 0 Then
                            If CStr(Me.grdParts.Columns("dcode_id").Value) <> "" Then
                                Me.cmbRefDesig.SelectedValue = Me.grdParts.Columns("dcode_id").Value
                            Else
                                Me.cmbRefDesig.SelectedValue = 0    'Select the empty space
                            End If

                            Me.cmbRefDesig.Visible = True
                            Me.lblCaptionRefDesgn.Visible = True
                            Me.cmbFailure.Visible = False
                            Me.lblCaptionFailure.Visible = False

                        ElseIf iFailureCode = 0 Then
                            If CStr(Me.grdParts.Columns("dcode_id").Value) <> "" Then
                                Me.cmbFailure.SelectedValue = Me.grdParts.Columns("dcode_id").Value
                            Else
                                Me.cmbFailure.SelectedValue = 0    'Select the empty space
                            End If

                            Me.cmbRefDesig.Visible = False
                            Me.lblCaptionRefDesgn.Visible = False
                            Me.cmbFailure.Visible = True
                            Me.lblCaptionFailure.Visible = True
                        End If



                    End If
                End If
            Catch ex As Exception
                MsgBox("Error in grdParts_RowColChange:: " & ex.Message, MsgBoxStyle.Critical)
            Finally
                ''
            End Try
        End Sub
        '**************************************************************
        Private Sub btnUpdateGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateGrid.Click

            Dim myDataRow As DataRow
            Dim R1 As DataRow
            Dim i As Integer = 0

            If IsNothing(myDataTable) Then
                CreatePartsUpdateTable()
            End If

            Try
                If Not IsDBNull(Me.grdParts.Columns("mcode_id").Value) Then
                    If Me.grdParts.Columns("mcode_id").Value = "11" Then
                        If Me.grdParts.Columns("Dcode_ID").Value <> Me.cmbRefDesig.SelectedValue Or Me.grdParts.Columns("RefDesigNum").Value <> Me.txtRefDesignator.Text Then

                            'Update grid
                            'Me.grdParts.Columns("Part_Description").Value = Me.cmbRefDesig.Text

                            'Check if the tPartsCode_ID is already added to the table
                            For Each myDataRow In myDataTable.Rows
                                If Me.grdParts.Columns("tPartsCode_ID").Value = myDataRow("tPartsCode_ID") Then
                                    i = 1
                                    myDataRow.BeginEdit()

                                    myDataRow("Part_Number") = Me.grdParts.Columns("Part_Number").Value
                                    myDataRow("Code_Description_Old") = Me.grdParts.Columns("Code_Description").Value
                                    myDataRow("Code_Description_New") = Me.cmbRefDesig.Text
                                    myDataRow("tPartsCode_ID") = Me.grdParts.Columns("tPartsCode_ID").Value
                                    myDataRow("DCode_ID_Old") = Me.grdParts.Columns("DCode_ID").Value
                                    myDataRow("DCode_ID_New") = Me.cmbRefDesig.SelectedValue
                                    myDataRow("RefDesigNum") = Me.txtRefDesignator.Text
                                    myDataRow("DBill_ID") = Me.grdParts.Columns("DBill_ID").Value
                                    myDataRow.EndEdit()
                                    Exit For
                                End If
                            Next

                            If i = 0 Then
                                'Add row to MyDatatTable
                                myDataRow = myDataTable.NewRow
                                myDataRow("Part_Number") = Me.grdParts.Columns("Part_Number").Value
                                myDataRow("Code_Description_Old") = Me.grdParts.Columns("Code_Description").Value
                                myDataRow("Code_Description_New") = Me.cmbRefDesig.Text
                                myDataRow("tPartsCode_ID") = Me.grdParts.Columns("tPartsCode_ID").Value
                                myDataRow("DCode_ID_Old") = Me.grdParts.Columns("DCode_ID").Value
                                myDataRow("DCode_ID_New") = Me.cmbRefDesig.SelectedValue
                                myDataRow("RefDesigNum") = Me.txtRefDesignator.Text
                                myDataRow("DBill_ID") = Me.grdParts.Columns("DBill_ID").Value
                                myDataTable.Rows.Add(myDataRow)
                                myDataRow = Nothing
                            End If

                        End If
                    Else
                        If Me.grdParts.Columns("Dcode_ID").Value <> Me.cmbFailure.SelectedValue Or Me.grdParts.Columns("RefDesigNum").Value <> Me.txtRefDesignator.Text Then
                            'Update grid
                            'Me.grdParts.Columns("Part_Description").Value = Me.cmbFailure.Text

                            'Check if the tPartsCode_ID is already added to the table
                            For Each myDataRow In myDataTable.Rows
                                If Me.grdParts.Columns("tPartsCode_ID").Value = myDataRow("tPartsCode_ID") Then
                                    i = 1
                                    myDataRow.BeginEdit()
                                    myDataRow("Part_Number") = Me.grdParts.Columns("Part_Number").Value
                                    myDataRow("Code_Description_Old") = Me.grdParts.Columns("Code_Description").Value
                                    myDataRow("Code_Description_New") = Me.cmbFailure.Text
                                    myDataRow("tPartsCode_ID") = Me.grdParts.Columns("tPartsCode_ID").Value
                                    myDataRow("DCode_ID_Old") = Me.grdParts.Columns("DCode_ID").Value
                                    myDataRow("DCode_ID_New") = Me.cmbFailure.SelectedValue
                                    myDataRow("RefDesigNum") = Me.txtRefDesignator.Text
                                    myDataRow("DBill_ID") = Me.grdParts.Columns("DBill_ID").Value
                                    myDataRow.EndEdit()
                                    Exit For
                                End If
                            Next

                            If i = 0 Then
                                'Add row to MyDatatTable
                                myDataRow = myDataTable.NewRow
                                myDataRow("Part_Number") = Me.grdParts.Columns("Part_Number").Value
                                myDataRow("Code_Description_Old") = Me.grdParts.Columns("Code_Description").Value
                                myDataRow("Code_Description_New") = Me.cmbFailure.Text
                                myDataRow("tPartsCode_ID") = Me.grdParts.Columns("tPartsCode_ID").Value
                                myDataRow("DCode_ID_Old") = Me.grdParts.Columns("DCode_ID").Value
                                myDataRow("DCode_ID_New") = Me.cmbFailure.SelectedValue
                                myDataRow("RefDesigNum") = Me.txtRefDesignator.Text
                                myDataRow("DBill_ID") = Me.grdParts.Columns("DBill_ID").Value
                                myDataTable.Rows.Add(myDataRow)
                                myDataRow = Nothing
                            End If


                        End If
                    End If
                Else
                    i = 0
                    For Each R1 In dtParts.Rows
                        If Me.grdParts.Columns("DBill_ID").Value = R1("DBill_ID") Then

                            If iRefDesigCode = 0 And iFailureCode = 0 Then

                                'Update row based on Ref Design Num, Failure Codes
                                If i = 0 Then
                                    'Add the Failure Code here
                                    'Add row to MyDatatTable
                                    myDataRow = myDataTable.NewRow
                                    myDataRow("Part_Number") = Me.grdParts.Columns("Part_Number").Value
                                    myDataRow("Code_Description_Old") = Me.grdParts.Columns("Code_Description").Value
                                    myDataRow("Code_Description_New") = Me.cmbFailure.Text
                                    myDataRow("tPartsCode_ID") = R1("tPartsCode_ID")
                                    myDataRow("DCode_ID_Old") = Me.grdParts.Columns("DCode_ID").Value
                                    myDataRow("DCode_ID_New") = Me.cmbFailure.SelectedValue
                                    myDataRow("RefDesigNum") = Me.txtRefDesignator.Text
                                    myDataRow("DBill_ID") = Me.grdParts.Columns("DBill_ID").Value
                                    myDataTable.Rows.Add(myDataRow)
                                    myDataRow = Nothing

                                    i = 1
                                Else
                                    'Add RefDesig COde here
                                    'Add row to MyDatatTable
                                    myDataRow = myDataTable.NewRow
                                    myDataRow("Part_Number") = Me.grdParts.Columns("Part_Number").Value
                                    myDataRow("Code_Description_Old") = Me.grdParts.Columns("Code_Description").Value
                                    myDataRow("Code_Description_New") = Me.cmbRefDesig.Text
                                    myDataRow("tPartsCode_ID") = R1("tPartsCode_ID")
                                    myDataRow("DCode_ID_Old") = Me.grdParts.Columns("DCode_ID").Value
                                    myDataRow("DCode_ID_New") = Me.cmbRefDesig.SelectedValue
                                    myDataRow("RefDesigNum") = Me.txtRefDesignator.Text
                                    myDataRow("DBill_ID") = Me.grdParts.Columns("DBill_ID").Value
                                    myDataTable.Rows.Add(myDataRow)
                                    myDataRow = Nothing

                                    Exit For
                                End If
                            ElseIf iRefDesigCode = 0 Then
                                myDataRow = myDataTable.NewRow
                                myDataRow("Part_Number") = Me.grdParts.Columns("Part_Number").Value
                                myDataRow("Code_Description_Old") = Me.grdParts.Columns("Code_Description").Value
                                myDataRow("Code_Description_New") = Me.cmbRefDesig.Text
                                myDataRow("tPartsCode_ID") = R1("tPartsCode_ID")
                                myDataRow("DCode_ID_Old") = Me.grdParts.Columns("DCode_ID").Value
                                myDataRow("DCode_ID_New") = Me.cmbRefDesig.SelectedValue
                                myDataRow("RefDesigNum") = Me.txtRefDesignator.Text
                                myDataRow("DBill_ID") = Me.grdParts.Columns("DBill_ID").Value
                                myDataTable.Rows.Add(myDataRow)
                                myDataRow = Nothing

                                Exit For
                            ElseIf iFailureCode = 0 Then

                                myDataRow = myDataTable.NewRow
                                myDataRow("Part_Number") = Me.grdParts.Columns("Part_Number").Value
                                myDataRow("Code_Description_Old") = Me.grdParts.Columns("Code_Description").Value
                                myDataRow("Code_Description_New") = Me.cmbFailure.Text
                                myDataRow("tPartsCode_ID") = Me.grdParts.Columns("tPartsCode_ID").Value
                                myDataRow("DCode_ID_Old") = Me.grdParts.Columns("DCode_ID").Value
                                myDataRow("DCode_ID_New") = Me.cmbFailure.SelectedValue
                                myDataRow("RefDesigNum") = Me.txtRefDesignator.Text
                                myDataRow("DBill_ID") = Me.grdParts.Columns("DBill_ID").Value
                                myDataTable.Rows.Add(myDataRow)
                                myDataRow = Nothing

                                Exit For
                            End If
                        End If
                    Next R1

                End If

                '************************************************************
                Me.txtRefDesignator.Text = ""
                Me.cmbRefDesig.SelectedValue = 0
                Me.cmbFailure.SelectedValue = 0

                Me.grdPartChages.DataSource = myDataTable.DefaultView

            Catch ex As Exception
                MsgBox("Error in btnUpdateGrid_Click:: " & ex.Message, MsgBoxStyle.Critical)
            Finally
                ''
            End Try

            '************************************************************
        End Sub
        '*****************************************************************************
        Private Sub cmdCreateFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreateFile.Click

            Dim strDeviceIDs As String
            Dim i As Integer
            '**********************************************
            'Build string with device_ids from the list box
            '**********************************************
            strDeviceIDs = "("

            For i = 0 To (Me.lstClaims.Items.Count - 1)
                If i = 0 Then
                    strDeviceIDs &= Me.lstClaims.Items(i)
                Else
                    strDeviceIDs &= ", " & Me.lstClaims.Items(i)
                End If
            Next

            strDeviceIDs &= ")"
            '**********************************************
            'Comment this part out once done
            '**********************************************
            'strDeviceIDs = ""
            'strDeviceIDs = "(3814073, 3814509, 3814511, 3814512, 3814515, 3814516, 3814518, 3814519, 3814520, 3814521, 3814522, 3814523, 3814524, 3814525, 3814529, 3814530, 3814533, 3814535, 3814536, 3814537, 3814538, 3814541, 3814554, 3814555, 3814556, 3814557, 3814558, 3814561, 3814571, 3814577, 3814578, 3814581, 3814582, 3814583, 3814584, 3814585, 3814596, 3814597, 3814598, 3814599, 3814600, 3814601, 3814602, 3814603, 3814604, 3814605, 3814606, 3814607, 3814608)"
            'strDeviceIDs = "(4029209, 4029859, 4182198, 4188665, 4189114, 4193647, 4193742, 4193766, 4193782, 4193893, 4193973, 4194023, 4217194, 4217195, 4217196, 4217197, 4217198, 4217199, 4217200, 4217201, 4217203, 4217204, 4217206, 4217208, 4217209, 4217210, 4217211, 4217212, 4217213, 4217424, 4217425, 4217426, 4217427, 4217444, 4217445, 4217446, 4217447, 4217448, 4217554, 4217555, 4217556, 4217557, 4217558, 4217574, 4217576, 4217577, 4217578, 4217594, 4217595, 4217596, 4217597, 4217598, 4217601, 4217602, 4217603, 4217634, 4217636, 4217637, 4217639, 4217640, 4217641, 4217642, 4217643, 4217659, 4217660, 4217661, 4217662, 4217663, 4217680, 4217681, 4217682, 4217683, 4217685, 4217686, 4217687, 4217688, 4217704, 4217705, 4217706, 4217707, 4217708, 4217724, 4217725, 4217726, 4217727, 4217728, 4217759, 4217760, 4217761, 4217762, 4217763, 4217840, 4217843, 4217844, 4217847, 4217849, 4217850, 4217851, 4217852, 4217853, 4217855, 4217856, 4217857, 4217858, 4217859, 4217860, 4217861, 4217862, 4217863, 4217864, 4217865, 4217866, 4217867, 4217869, 4217870, 4217871, 4217872, 4217873, 4217874, 4217875, 4217876, 4217877, 4217878, 4217880, 4217881, 4217882, 4217883, 4217884, 4217885, 4217886, 4217887, 4217888, 4217890, 4217891, 4217892, 4217893, 4217894, 4217895, 4217896, 4217897, 4217898, 4217899, 4217900, 4217901, 4217902, 4217903, 4217908, 4217909, 4217910, 4217912, 4217913, 4217914, 4217915, 4217916, 4217917, 4217918, 4217920, 4217921, 4217922, 4217923, 4217924, 4217925, 4217926, 4217927, 4217928, 4217929, 4217930, 4217931, 4217932, 4217933, 4217934, 4217935, 4217937, 4217938, 4217939, 4217940, 4217941, 4217943, 4217954, 4217955, 4217956, 4217957, 4217959, 4217961, 4217962, 4217963, 4217964, 4217965, 4217966, 4217967, 4217975, 4217976, 4217977, 4217978, 4217979, 4217981, 4217982, 4217983, 4217989, 4217991, 4217994, 4217995, 4217996, 4217997, 4217999, 4218001, 4218002, 4218003, 4218004, 4218005, 4218006, 4218007, 4218008, 4218009, 4218011, 4218012, 4218014, 4218016, 4218017, 4218018, 4218019, 4218020, 4218022, 4218023, 4218024, 4218025, 4218026, 4218029, 4218030, 4218031, 4218032, 4218034, 4218035, 4218037, 4218039, 4218040, 4218041, 4218042, 4218043, 4218044, 4218045, 4218046, 4218047, 4218048, 4218054, 4218055, 4218056, 4218057, 4218058, 4218059, 4218060, 4218061, 4218062, 4218063, 4218064, 4218065, 4218066, 4218067, 4218068, 4218075, 4218076, 4218077, 4219500, 4219501, 4219502, 4219504, 4219555, 4219556, 4219557, 4219559, 4219568, 4219569, 4219570, 4219571, 4219572, 4219573, 4219575, 4219576, 4219577, 4219578, 4219579, 4219582, 4219583, 4219584, 4219585, 4219586, 4219588, 4219589, 4219590, 4219591, 4219592, 4219593, 4219594, 4219595, 4219596, 4219597, 4219600, 4219601, 4219602, 4219633, 4219634, 4219635, 4219636, 4219637, 4219649, 4219650, 4219651, 4219652, 4219653, 4219684, 4219685, 4219686, 4219687, 4219688, 4219704, 4219705, 4219706, 4219707, 4219708, 4219709, 4219710, 4219712, 4219713, 4219719, 4219720, 4219721, 4219722, 4219723, 4219724, 4219725, 4219726, 4219727, 4219728, 4219752, 4219753, 4219754, 4219755, 4219756, 4219757, 4219758, 4219760, 4219761, 4219762, 4219763, 4219764, 4219765, 4219766, 4219790, 4219793, 4219800, 4219801, 4219802, 4219803, 4219804, 4219805, 4219806, 4219807, 4219809, 4219810, 4219811, 4219812, 4219813, 4219814, 4219820, 4219825, 4219826, 4219827, 4219828, 4219829, 4219835, 4219836, 4219837, 4219838, 4219839, 4219840, 4219841, 4219842, 4219843, 4219844, 4219855, 4219858, 4219859, 4219860, 4219861, 4219862, 4219863, 4219864, 4219865, 4219866, 4219867, 4219868, 4219869, 4219902, 4219904, 4219905, 4219906, 4219979, 4219980, 4219981, 4219982, 4219983, 4219984, 4219985, 4219986, 4219987, 4219988, 4219990, 4219991, 4219992, 4219993, 4220019, 4220020, 4220021, 4220022, 4220023, 4220031, 4220032, 4220033, 4220034, 4220035, 4220041, 4220042, 4220043, 4220045, 4220574, 4220575, 4220576, 4220577, 4220578, 4220608, 4220609, 4220610, 4220611, 4220612, 4220693, 4220694, 4220695, 4220696, 4220697, 4220698, 4220699, 4220700, 4220701, 4220702, 4220708, 4220709, 4220710, 4220711, 4220712, 4220713, 4220714, 4220715, 4220716, 4220717, 4220718, 4220719, 4220720, 4220721, 4220723, 4220724, 4220725, 4220726, 4220727, 4220728, 4220729, 4220731, 4220732, 4220733, 4220734, 4220736, 4220737, 4220738, 4220740, 4220741, 4220742, 4220748, 4220749, 4220751, 4220752, 4220758, 4220759, 4220760, 4220761, 4220762, 4220763, 4220764, 4220765, 4220766, 4220767, 4220778, 4220780, 4220781, 4220782, 4224143, 4224144, 4224145, 4224146, 4224147, 4224153, 4224154, 4224155, 4224156, 4224157, 4224159, 4224164, 4224166, 4224167, 4224173, 4224174, 4224175, 4224176, 4224177)"

            '**********************************************
            CreateFile(strDeviceIDs)


        End Sub
        '*****************************************************************************
        Protected Overrides Sub Finalize()
            MyBase.Finalize()
            DisposeDataTable()
            Me.Close()
            Me.Dispose()
        End Sub

        '***************************************************************************
        'Disposes the class level data table
        '*****************************************
        Private Sub DisposeDataTable()
            Try
                If Not IsNothing(myDataTable) Then
                    If Not IsDBNull(myDataTable) Then
                        myDataTable.Dispose()
                    End If
                    myDataTable = Nothing
                End If
                If Not IsNothing(dtParts) Then
                    If Not IsDBNull(dtParts) Then
                        dtParts.Dispose()
                    End If
                    dtParts = Nothing
                End If

            Catch ex As Exception
                Throw New Exception("frmMotoSubCOntShipping.DisposeDatatable: " + ex.Message.ToString)
            End Try
        End Sub
        '****************************************************************************
        Private Sub CreatePartsUpdateTable()
            Dim myDataColumn As DataColumn
            Try

                If Not IsNothing(myDataTable) Then
                    myDataTable.Dispose()
                    myDataTable = Nothing
                    myDataTable = New DataTable()
                End If

                myDataColumn = New DataColumn()
                myDataColumn.DataType = System.Type.GetType("System.String")
                myDataColumn.ColumnName = "Part_Number"
                myDataTable.Columns.Add(myDataColumn)
                myDataColumn = Nothing

                myDataColumn = New DataColumn()
                myDataColumn.DataType = System.Type.GetType("System.String")
                myDataColumn.ColumnName = "Code_Description_Old"
                myDataTable.Columns.Add(myDataColumn)
                myDataColumn = Nothing

                myDataColumn = New DataColumn()
                myDataColumn.DataType = System.Type.GetType("System.String")
                myDataColumn.ColumnName = "Code_Description_New"
                myDataTable.Columns.Add(myDataColumn)
                myDataColumn = Nothing

                myDataColumn = New DataColumn()
                myDataColumn.DataType = System.Type.GetType("System.String")
                myDataColumn.ColumnName = "RefDesigNum"
                myDataTable.Columns.Add(myDataColumn)
                myDataColumn = Nothing

                myDataColumn = New DataColumn()
                myDataColumn.DataType = System.Type.GetType("System.Int32")
                myDataColumn.ColumnName = "tPartsCode_ID"
                myDataTable.Columns.Add(myDataColumn)
                myDataColumn = Nothing

                myDataColumn = New DataColumn()
                myDataColumn.DataType = System.Type.GetType("System.Int32")
                myDataColumn.ColumnName = "DCode_ID_Old"
                myDataTable.Columns.Add(myDataColumn)
                myDataColumn = Nothing

                myDataColumn = New DataColumn()
                myDataColumn.DataType = System.Type.GetType("System.Int32")
                myDataColumn.ColumnName = "DCode_ID_New"
                myDataTable.Columns.Add(myDataColumn)
                myDataColumn = Nothing

                myDataColumn = New DataColumn()
                myDataColumn.DataType = System.Type.GetType("System.Int32")
                myDataColumn.ColumnName = "DBill_ID"
                myDataTable.Columns.Add(myDataColumn)
                myDataColumn = Nothing
            Catch ex As Exception
                Throw New Exception("frmMotoSubCOntShipping.CreatePartsUpdateTable: " + ex.Message.ToString)
            End Try

        End Sub

        '*****************************************************************************
        'Clear Fields
        '*****************************************************************************
        Private Sub ClearControls()

            With Me
                .iDeviceId = 0

                .lblWO_ID.Text = ""
                .lblRMANumber.Text = ""

                .lblClaimNumber.Text = ""
                .txtDevice_SN.Text = ""
                .dtpDateRec.Text = "1753-01-01 12:00:00"
                .dtpDateRep.Text = "1753-01-01 12:00:00"
                .dtpDateShp.Text = "1753-01-01 12:00:00"

                .txtCSNIn.Text = ""
                .txtCSNOut.Text = ""
                .txtMSNIn.Text = ""
                .txtMSNOut.Text = ""
                .txtIMEIIn.Text = ""
                .txtIMEIOut.Text = ""
                .txtTransaceiver.Text = ""
                .dtpDatePurchase.Text = "1753-01-01 12:00:00"
                .cmbTech.SelectedValue = 0
                .txtSoftIn.Text = ""
                .txtSoftOut.Text = ""
                .txtAirtime.Text = ""

                .cmbCarrCode.SelectedValue = 0
                .cmbAPCCode.SelectedValue = 0
                .cmbComplaintCode.SelectedValue = 0
                .cmbProbCode.SelectedValue = 0
                .cmbRepCode.SelectedValue = 0
                .cmbTransactionCode.SelectedValue = 0

                .grdParts.ClearFields()
                .myDataTable.Clear()
                .cmbRefDesig.SelectedValue = 0
                .cmbFailure.SelectedValue = 0
                .txtRefDesignator.Text = ""

            End With

            strDeviceSn = ""
            strDateRec = ""
            strDateRepaired = ""
            strDateShip = ""

            strCSNin = ""
            strCSNOut = ""
            strMSNin = ""
            strMSNOut = ""
            strIMEIin = ""
            strIMEIOut = ""
            strTransceiver = ""
            strDatePOP = ""
            strSoftIn = ""
            strSoftOut = ""
            strAirtime = ""

            iTechID = 0
            iDcodeID_CarrCode = 0
            iDcodeID_Transaction = 0
            iDcodeID_Complaint = 0
            iDcodeID_APC = 0
            iDcodeID_Problem = 0
            iDcodeID_Repair = 0
        End Sub
        '*****************************************************************************
        Private Sub cmdClearChanges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearChanges.Click
            Me.grdPartChages.ClearFields()
            CreatePartsUpdateTable()
        End Sub
        '*****************************************************************************
        Private Sub cmdClearScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearScreen.Click
            ClearControls()
        End Sub
        '*****************************************************************************
        Private Sub lstClaims_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstClaims.DoubleClick
            GetDeviceInfo()
        End Sub
        '*****************************************************************************
        Private Sub GetDeviceInfo()

            Dim dt As DataTable
            Dim R1 As DataRow
            Dim iCntr As Integer = 0
            Dim i As Integer
            Dim iModel_ID As Integer

            'Reinitialse
            iDeviceId = 0
            ClearControls()

            If Me.txtClaimNum.Text <> "" Then
                iDeviceId = Trim(Me.txtClaimNum.Text)
                Me.txtClaimNum.Text = ""
            ElseIf CStr(Me.lstClaims.SelectedItem) <> "" Then
                iDeviceId = Me.lstClaims.SelectedItem
            End If
            Me.lblClaimNumber.Text = iDeviceId

            Try
                i = 0
                '**************************************************************
                'Check if the Claim belongs to the Claim type selected
                '**************************************************************
                objMotoSubcontract_Biz = New PSS.Data.Buisness.MotorolaSubcontract_Biz()
                dt = objMotoSubcontract_Biz.DeviceBlongsToClaimType(iDeviceId, iClaimType)

                For Each R1 In dt.Rows
                    If R1("ClaimBelongs") = 0 Then
                        i = 1
                        MsgBox("This claim doesn't belong to the customer you have selected in the menu.", MsgBoxStyle.Exclamation)
                        ClearControls()
                        Exit Sub
                    End If
                Next
                If i = 0 Then
                    '***********************************************
                    'Loop through List of Claims to see if the claim being searched is already added
                    iCntr = 0
                    If Me.lstClaims.Items.Count > 0 Then
                        For i = 0 To (Me.lstClaims.Items.Count - 1)
                            If Me.lstClaims.Items(i) = iDeviceId Then
                                iCntr = 1
                                Exit For
                            End If
                        Next
                    End If
                    If iCntr = 0 Then
                        Me.lstClaims.Items.Add(iDeviceId)
                        Me.lstClaims.Sorted = True
                        Me.lstClaims.SelectedItem = iDeviceId
                    End If
                    '***********************************************
                End If
                '**************************
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                '**************************************************************
                'STEP1
                'Get WO and Device related info
                '**************************************************************
                dt = objMotoSubcontract_Biz.GetWOInfoByDeviceID(iDeviceId, iClaimType)

                For Each R1 In dt.Rows
                    Me.lblWO_ID.Text = R1("WO_ID")
                    Me.lblRMANumber.Text = Trim(R1("WO_CustWO"))

                    Me.txtDevice_SN.Text = Trim(R1("Device_SN"))
                    strDeviceSn = Trim(R1("Device_SN"))
                    Me.lblClaimSent.Text = R1("Device_SendClaim")

                    If R1("Device_DateRec") <> "" Then
                        Me.dtpDateRec.Text = Trim(R1("Device_DateRec"))
                        strDateRec = Trim(R1("Device_DateRec"))
                    End If

                    If Trim(R1("Device_DateBill")) <> "" And Trim(R1("Device_DateBill")) <> "0000-00-00 00:00:00" And Not IsDBNull(R1("Device_DateBill")) Then
                        Me.dtpDateRep.Text = Trim(R1("Device_DateBill"))
                        strDateRepaired = Trim(R1("Device_DateBill"))
                    End If

                    If iClaimType = 0 Then
                        If R1("Device_DateShip") <> "" Then
                            Me.dtpDateShp.Text = Trim(R1("Device_DateShip"))
                            strDateShip = Trim(R1("Device_DateShip"))
                        End If
                    ElseIf iClaimType = 1 Then
                        If R1("Pallett_ShipDate") <> "" Then
                            Me.dtpDateShp.Text = Trim(R1("Pallett_ShipDate"))
                            strDateShip = Trim(R1("Pallett_ShipDate"))
                        End If
                    End If

                    iModel_ID = R1("Model_ID")

                Next

                '**************************
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                '**************************************************************
                'STEP2
                'Get DeviceInfo from tcellopt table
                '**************************************************************
                dt = objMotoSubcontract_Biz.GetDeviceInfoFromCellOptByDeviceID(iDeviceId)

                For Each R1 In dt.Rows
                    Me.txtCSNIn.Text = Trim(R1("cellopt_csn"))
                    strCSNin = Trim(R1("cellopt_csn"))
                    Me.txtCSNOut.Text = Trim(R1("cellopt_outcsn"))
                    strCSNOut = Trim(R1("cellopt_outcsn"))
                    Me.txtMSNIn.Text = Trim(R1("cellopt_msn"))
                    strMSNin = Trim(R1("cellopt_msn"))
                    Me.txtMSNOut.Text = Trim(R1("cellopt_outmsn"))
                    strMSNOut = Trim(R1("cellopt_outmsn"))

                    Me.txtIMEIIn.Text = Trim(R1("cellopt_imei"))
                    strIMEIin = Trim(R1("cellopt_imei"))
                    Me.txtIMEIOut.Text = Trim(R1("cellopt_outimei"))
                    strIMEIOut = Trim(R1("cellopt_outimei"))
                    Me.txtTransaceiver.Text = Trim(R1("cellopt_transceiver"))
                    strTransceiver = Trim(R1("cellopt_transceiver"))

                    If R1("cellopt_pop") <> "" Then
                        Me.dtpDatePurchase.Text = Trim(R1("cellopt_pop"))
                        strDatePOP = Trim(R1("cellopt_pop"))
                    End If

                    If R1("cellopt_techid") = "" Then
                        Me.cmbTech.SelectedValue = 0
                    Else
                        Me.cmbTech.SelectedValue = Trim(R1("cellopt_techid"))
                        iTechID = CInt(Trim(R1("cellopt_techid")))
                    End If

                    Me.txtSoftIn.Text = Trim(R1("cellopt_softverin"))
                    strSoftIn = Trim(R1("cellopt_softverin"))
                    Me.txtSoftOut.Text = Trim(R1("cellopt_softverout"))
                    strSoftOut = Trim(R1("cellopt_softverout"))
                    Me.txtAirtime.Text = Trim(R1("cellopt_Airtime"))
                    strAirtime = Trim(R1("cellopt_Airtime"))
                Next

                '**************************
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If

                '**************************************************************
                'STEP3
                'Get Model info
                '**************************************************************
                dt = objMotoSubcontract_Biz.GetModelInfo(iModel_ID)

                For Each R1 In dt.Rows
                    Me.lblModel.Text = Trim(R1("Model_Desc"))
                Next

                '**************************
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If

                '**************************************************************
                'STEP3
                'Get Codes
                '**************************************************************
                dt = objMotoSubcontract_Biz.GetCodesByDeviceID(iDeviceId)

                For Each R1 In dt.Rows

                    Select Case R1("MCode_ID")
                        Case 1  'Carrier code
                            If Me.cmbCarrCode.SelectedValue <> R1("DCode_ID") Then
                                Me.cmbCarrCode.SelectedValue = R1("DCode_ID")
                                iDcodeID_CarrCode = R1("DCode_ID")
                            End If
                        Case 3  'Repair action code
                            Me.cmbRepCode.SelectedValue = R1("DCode_ID")
                            iDcodeID_Repair = R1("DCode_ID")
                        Case 5  'Complaint code
                            Me.cmbComplaintCode.SelectedValue = R1("DCode_ID")
                            iDcodeID_Complaint = R1("DCode_ID")
                        Case 6  'APC Code
                            Me.cmbAPCCode.SelectedValue = R1("DCode_ID")
                            iDcodeID_APC = R1("DCode_ID")
                        Case 8  'Transaction code
                            Me.cmbTransactionCode.SelectedValue = R1("DCode_ID")
                            iDcodeID_Transaction = R1("DCode_ID")
                        Case 9  'Prob Found code
                            Me.cmbProbCode.SelectedValue = R1("DCode_ID")
                            iDcodeID_Problem = R1("DCode_ID")
                    End Select
                Next

                '**************************
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If

                '**************************************************************
                'STEP4
                'Fill the parts grid
                '**************************************************************
                'Here destroy the previous instance of the data table that fills the Parts Grid
                If Not IsNothing(dtParts) Then
                    dtParts.Dispose()
                    dtParts = Nothing
                    dtParts = New DataTable()
                End If

                dtParts = objMotoSubcontract_Biz.GetPartsCodesByDeviceID(iDeviceId, iClaimType)

                Me.grdParts.ClearFields()
                Me.grdParts.DataSource = dtParts.DefaultView

                '**************************************************************
            Catch ex As Exception
                MsgBox("Error in txtClaimNum_KeyDown:: " & ex.Message, MsgBoxStyle.Critical)
            Finally
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If

                objMotoSubcontract_Biz = Nothing
            End Try
            'End If
        End Sub
        '**************************************************************
        Private Sub cmdRemoveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveItem.Click
            If Me.lstClaims.SelectedIndex <> -1 Then    'If nothing is selected
                Me.lstClaims.Items.RemoveAt(Me.lstClaims.SelectedIndex)
                Me.lstClaims.Refresh()
                If Me.lstClaims.Items.Count = 0 Then
                    ClearControls()
                End If
            End If
        End Sub
        '**************************************************************
        Private Sub cmdClearClaims_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearClaims.Click
            Me.lstClaims.Items.Clear()
            If Me.lstClaims.Items.Count = 0 Then
                ClearControls()
            End If
        End Sub
        '**************************************************************
        Private Sub CreateFile(ByVal strDeviceIDs As String)

            'First construct the name of the file and open the file
            Dim strFilePath As String
            Dim strMonth As String
            Dim strDay As String
            Dim strYear As String
            Dim strHour As String
            Dim strMinute As String
            Dim strSecond As String
            Dim strVar As String
            Dim CurDtTime As DateTime
            Dim strMascCode As String
            Dim strMotoPath As String
            Dim strLogPath As String

            If iClaimType = 0 Then          'ASC Claims
                strMascCode = "US021553"
                strMotoPath = "R:\_Motorola_ASC_Claims\"
            ElseIf iClaimType = 1 Then      'SUB Claims
                strMascCode = "US021939"
                strMotoPath = "Y:\"     'C:\Motorola\DataFiles\   is mapped on Crystal's machine as Y Drive  For SUB Claims
                strLogPath = "R:\_Motorola_SUB_Claims\"
            End If

            '***********************************************************
            'Construct the File name and File Path in the format "SIFT" + Short date format (DDMMYYYY)
            'without slashes and open the file for appending.
            '***********************************************************
            CurDtTime = Now()
            strMonth = DatePart(DateInterval.Month, CurDtTime)
            strDay = DatePart(DateInterval.Day, CurDtTime)
            strYear = DatePart(DateInterval.Year, CurDtTime)
            strHour = DatePart(DateInterval.Hour, CurDtTime)      'Get the HOUR part from the datetime
            strMinute = DatePart(DateInterval.Minute, CurDtTime)  'Get the MINUTE part from the datetime
            strSecond = DatePart(DateInterval.Second, CurDtTime)

            'Pad with Zeros
            If Len(strDay) < 2 Then strDay = "0" & strDay
            If Len(strMonth) < 2 Then strMonth = "0" & strMonth
            If Len(strHour) < 2 Then strHour = "0" & strHour
            If Len(strMinute) < 2 Then strMinute = "0" & strMinute
            If Len(strSecond) < 2 Then strSecond = "0" & strSecond

            strFilePath = strMotoPath & strMascCode & strMonth & strDay & strYear & strHour & strMinute & strSecond & ".DAT"
            'Open the file
            FileOpen(1, strFilePath, OpenMode.Append)

            '*******************************************************************************************
            'Header Line 1
            '*******************************************************************************************
            strVar = "HDR " + "CLMCRT" + strDay + "/" + strMonth + "/" + strYear + " " + strHour + ":" + strMinute + strMascCode + vbCrLf
            '*******************************************************************************************
            'Header Line 2
            '*******************************************************************************************
            strVar = strVar + "HDR2" + vbCrLf
            '*******************************************************************************************
            'Header Line 3
            '*******************************************************************************************
            strVar = strVar + "HDR3"
            PrintLine(1, strVar)
            strVar = ""
            '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
            Dim dtClaimInfo As DataTable
            Dim dtComponentDetail As DataTable
            Dim R1 As DataRow
            Dim R2 As DataRow
            Dim strMsg As String
            Dim i As Integer
            Dim icount As Integer = 0

            Try
                '******************************************************************
                'Instantiate MyLib Object
                '******************************************************************
                objMyLib = New MyLib.Utility()
                '*******************************************************************************************
                'Write Claim Information to DAT file
                '*******************************************************************************************
                'Request Business layer for Motorolla Warranty Data
                objMotoSubcontract_Biz = New PSS.Data.Buisness.MotorolaSubcontract_Biz()
                dtClaimInfo = objMotoSubcontract_Biz.GetMotorolaWIPInfo(strDeviceIDs)
                dtComponentDetail = objMotoSubcontract_Biz.GetMotorolaWIPDetailInfo(strDeviceIDs, strMascCode)

                'Write claim information to Warranty Data to file here
                If Not IsNothing(dtClaimInfo) And Not IsNothing(dtComponentDetail) Then
                    i = 2
                    For Each R1 In dtClaimInfo.Rows

                        icount += 1
                        '*************************************************************
                        'Write to DAT file
                        '*************************************************************
                        PrintLine(1, R1("CLM"), _
                                    TAB(47), R1("ConsumerSurname"), _
                                    TAB(566), UCase(R1("CountryCode")), _
                                    TAB(569), R1("CourierTrackingIn"), _
                                    TAB(589), R1("CourierTrackingOut"), _
                                    TAB(609), R1("WarrantyClaim"), _
                                    TAB(621), UCase(Trim(R1("CustRefNum"))), _
                                    TAB(641), UCase(R1("AirtimeCarCode")), _
                                    TAB(647), UCase(R1("TransactionCode")), _
                                    TAB(650), UCase(R1("Product_APCcode")), _
                                    TAB(654), UCase(R1("TansceiverCode")), _
                                    TAB(694), UCase(R1("IncomingMSN")), _
                                    TAB(708), UCase(R1("OutgoingMSN")), _
                                    TAB(722), UCase(R1("IncomingIMEI")), _
                                    TAB(740), UCase(R1("OutgoingIMEI")), _
                                    TAB(767), UCase(R1("RepairStatus")), _
                                    TAB(810), R1("DateReceived"), _
                                    TAB(840), R1("DateShipped"), _
                                    TAB(850), R1("TimeShipped"), _
                                    TAB(855), R1("ReapairDate"), _
                                    TAB(865), R1("RepairTime"), _
                                    TAB(873), R1("RepairCycleTime"), _
                                    TAB(889), UCase(R1("POPWarrantyClaim")), _
                                    TAB(890), R1("DateofPurchase"), _
                                    TAB(900), UCase(R1("IncomingESNorCSN")), _
                                    TAB(911), UCase(R1("OutgoingESNorCSN")), _
                                    TAB(922), R1("SoftwareVersionIn"), _
                                    TAB(932), R1("SoftwareVersionOut"), _
                                    TAB(942), UCase(R1("CustomerComplaint")), _
                                    TAB(950), R1("TechnicianID"), _
                                    TAB(959), UCase(R1("PrimaryProbFoundCode")), _
                                    TAB(975), UCase(R1("PrimaryRepairAction")), _
                                    TAB(1002), R1("Airtime"), _
                                    TAB(1124), "")

                        For Each R2 In dtComponentDetail.Rows
                            '*************************************************************
                            'Write to DAT file
                            '*************************************************************
                            If R1("WarrantyClaim") = R2("WarrantyClaim") Then

                                i = i + 1

                                PrintLine(1, R2("CMP"), _
                                    TAB(4), UCase(R2("MASCCode")), _
                                    TAB(12), R2("WarrantyClaim"), _
                                    TAB(24), UCase(R2("MotoPartNumber")), _
                                    TAB(44), R2("QttyReplaced"), _
                                    TAB(46), R2("QttyExchanged"), _
                                    TAB(48), UCase(R2("RepairOrRefurbish")), _
                                    TAB(49), UCase(R2("RefDesignator")), _
                                    TAB(55), R2("RefDesigNum"), _
                                    TAB(61), UCase(R2("PartFailureCode")), _
                                    TAB(66), R2("ResolderOrReplace"), _
                                    TAB(228), "")
                            End If
                        Next
                        i = i + 2
                    Next
                End If

                '*******************************************************************************************
                'Trailer. Write to the DAT file
                '*******************************************************************************************
                PrintLine(1, "TRA")

                'Update Device_Sendclaim = 1 here if need to

            Catch ne As NullReferenceException
                strMsg = Now() & Space(10) & "Data missing or not found. " + ne.Message.ToString
            Catch ex As Exception
                'Job messed up message
                strMsg = Now() & Space(10) & "Error in creating File. " + ex.Message.ToString
            Finally
                '**********************************************
                Reset()     'Close DAT file
                '**********************************************
                If Not IsNothing(dtComponentDetail) Then
                    dtComponentDetail.Dispose()
                    dtComponentDetail = Nothing
                End If
                '**********************************************
                If strMsg = "" Then
                    'job well done message
                    strMsg = Now() & Space(10) & "File is successfully generated. Number of Claims in file are " & icount
                End If
                '**********************************************
                If Not IsNothing(dtClaimInfo) Then
                    dtClaimInfo.Dispose()
                    dtClaimInfo = Nothing
                End If
                '**********************************************
                If Not IsNothing(objMotoSubcontract_Biz) Then
                    objMotoSubcontract_Biz = Nothing
                End If
                '**********************************************
                'WriteToLogFile(strMsg)
                '**********************************************
                objMyLib.WriteToLogFile(strMsg, strLogPath + "MotoWarrantyLog.txt")
                '*******************************************************************************
                If Not IsNothing(objMyLib) Then
                    objMyLib = Nothing
                End If
                '**********************************************
                MsgBox("File was successfully created. Number of claims in the file = " & icount, MsgBoxStyle.Information)
            End Try
        End Sub

        '**************************************************************



    End Class
End Namespace
