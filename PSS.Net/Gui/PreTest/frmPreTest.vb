Imports PSS.Data
Imports PSS.Core
Imports PSS.Rules
Imports PSS.Core.Global
Imports PSS.Data.Buisness

Namespace Gui.pretest

    Public Class frmPreTest
        Inherits System.Windows.Forms.Form

#Region "DECLARATIONS"

		Public Shared mReturnCode As Int16
		Public Shared returnWaitState As Int16 = 0
		Private _strScreenName As String = ""
		Private _iMenuCustID As Integer = 0
		Private _iMenuProdID As Integer = 0

		Private _iTechID As Integer = PSS.Core.Global.ApplicationUser.IDtech
		Private _iWCLocation_ID As Integer = 0
		Private _iGrpLineMap_ID As Integer = 0
		Private _objPreTest As Data.Buisness.PreTest
		Private _bChangePretestStatus As Boolean
		Private _iPretestResult As Integer = 0
		Private _dtFailcodes As DataTable
		Private _iDevice_ID As Integer = 0
		Private _icc_id As Integer = 0
		Private _booUpdateCCIDFlag As Boolean = False
		Private _iInWarranty As Integer = 0
		Private _iManufID As Integer = 0
		Private _iModelID As Integer = 0
		Private _iFuncRep As Integer = 0
		Private _booLoadData As Boolean = False
		Private _booCheckCompMap As Boolean = True
        Private _iWOID As Integer = 0
        Private _bIsWIKO_Customer As Boolean = False
		Private _dtControls As New DataTable()
        Private _strGroup As String = String.Empty
#End Region

#Region " Windows Form Designer generated code "

        Public Sub New(Optional ByVal strScreenName As String = "", _
           Optional ByVal iCustID As Integer = 0, _
           Optional ByVal iProdID As Integer = 0, _
           Optional ByVal booSelectInboundCosmGrade As Boolean = False, _
           Optional ByVal booCheckCompMapping As Boolean = True, _
           Optional ByVal bIsWIKO As Boolean = False)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._objPreTest = New Data.Buisness.PreTest()
            _strScreenName = strScreenName
            If Me._strScreenName = "Test, Triage and Sort" Then Label3.Text = strScreenName
            _iMenuCustID = iCustID
            _iMenuProdID = iProdID
            _booCheckCompMap = booCheckCompMapping
            Me._bIsWIKO_Customer = bIsWIKO

            Me.pnlInboundCosmGrade.Visible = booSelectInboundCosmGrade
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
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents txtDeviceSN As System.Windows.Forms.TextBox
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents lblUserName As System.Windows.Forms.Label
        Friend WithEvents lblWorkDate As System.Windows.Forms.Label
        Friend WithEvents lblShift As System.Windows.Forms.Label
        Friend WithEvents lblMachine As System.Windows.Forms.Label
        Friend WithEvents lblLineSide As System.Windows.Forms.Label
        Friend WithEvents lblGroup As System.Windows.Forms.Label
        Friend WithEvents lblLine As System.Windows.Forms.Label
        Friend WithEvents Button2 As System.Windows.Forms.Button
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents lblTotalPassed As System.Windows.Forms.Label
        Friend WithEvents lblTotalFailed As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents btnFail As System.Windows.Forms.Button
        Friend WithEvents btnPass As System.Windows.Forms.Button
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents btnSave As System.Windows.Forms.Button
        Friend WithEvents pnlFailCodes As System.Windows.Forms.Panel
        Friend WithEvents cmdRemove As System.Windows.Forms.Button
        Friend WithEvents lstFailCodes As System.Windows.Forms.ListBox
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents grdHistory As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents lblSN As System.Windows.Forms.Label
        Friend WithEvents btnDelete As System.Windows.Forms.Button
        Friend WithEvents lblPretestTotal As System.Windows.Forms.Label
        Friend WithEvents btnAssignCostCenter As System.Windows.Forms.Button
        Friend WithEvents lblCostCenterDesc As System.Windows.Forms.Label
        Friend WithEvents cboPFCodes As C1.Win.C1List.C1Combo
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents cboCustomers As C1.Win.C1List.C1Combo
        Friend WithEvents lblMainInputName As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents cboMoveTo As C1.Win.C1List.C1Combo
        Friend WithEvents pnlMoveToStation As System.Windows.Forms.Panel
        Friend WithEvents lblDevRepType As System.Windows.Forms.Label
        Friend WithEvents lblDateCode As System.Windows.Forms.Label
        Friend WithEvents lblWrtyStatus As System.Windows.Forms.Label
        Friend WithEvents chkDoNotMove As System.Windows.Forms.CheckBox
        Friend WithEvents btnCompleteBox As System.Windows.Forms.Button
        Friend WithEvents LabelFailOther As System.Windows.Forms.Label
        Friend WithEvents txtFailOther As System.Windows.Forms.TextBox
        Friend WithEvents cboProduct As C1.Win.C1List.C1Combo
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents cboCosmGrade As C1.Win.C1List.C1Combo
        Friend WithEvents pnlInboundCosmGrade As System.Windows.Forms.Panel
        Friend WithEvents lblRepType As System.Windows.Forms.Label
        Friend WithEvents cboSelfInflicted As C1.Win.C1List.C1Combo
        Friend WithEvents lblSelfInflicted As System.Windows.Forms.Label
        Friend WithEvents lblModelLabel As System.Windows.Forms.Label
        Friend WithEvents lblDeviceSNLabel As System.Windows.Forms.Label
        Friend WithEvents lblDeviceID As System.Windows.Forms.Label
        Friend WithEvents lblDeviceSN As System.Windows.Forms.Label
        Friend WithEvents btnNIKeyboardFail2 As System.Windows.Forms.Button
        Friend WithEvents btnNIKeyboardFail1 As System.Windows.Forms.Button
        Friend WithEvents btnNIKeyboardPass As System.Windows.Forms.Button
        Friend WithEvents lblModel As System.Windows.Forms.Label
        Friend WithEvents lblModelID As System.Windows.Forms.Label
        Friend WithEvents pnlNIKeyBoard As System.Windows.Forms.Panel
        Friend WithEvents chkNI_KeyboardTestBilling As System.Windows.Forms.CheckBox
        Friend WithEvents lblFC_CustLoc As System.Windows.Forms.Label
        Friend WithEvents txtUserComplaint As System.Windows.Forms.TextBox
        Friend WithEvents grpBoxUserComplaint As System.Windows.Forms.GroupBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPreTest))
            Me.btnClear = New System.Windows.Forms.Button()
            Me.txtDeviceSN = New System.Windows.Forms.TextBox()
            Me.lblMainInputName = New System.Windows.Forms.Label()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.lblPretestTotal = New System.Windows.Forms.Label()
            Me.lblTotalFailed = New System.Windows.Forms.Label()
            Me.lblUserName = New System.Windows.Forms.Label()
            Me.lblWorkDate = New System.Windows.Forms.Label()
            Me.lblShift = New System.Windows.Forms.Label()
            Me.lblMachine = New System.Windows.Forms.Label()
            Me.lblLineSide = New System.Windows.Forms.Label()
            Me.lblGroup = New System.Windows.Forms.Label()
            Me.lblLine = New System.Windows.Forms.Label()
            Me.Button2 = New System.Windows.Forms.Button()
            Me.lblTotalPassed = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.btnFail = New System.Windows.Forms.Button()
            Me.btnPass = New System.Windows.Forms.Button()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.cboProduct = New C1.Win.C1List.C1Combo()
            Me.chkDoNotMove = New System.Windows.Forms.CheckBox()
            Me.cboCustomers = New C1.Win.C1List.C1Combo()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.lblCostCenterDesc = New System.Windows.Forms.Label()
            Me.btnSave = New System.Windows.Forms.Button()
            Me.pnlFailCodes = New System.Windows.Forms.Panel()
            Me.lblFC_CustLoc = New System.Windows.Forms.Label()
            Me.LabelFailOther = New System.Windows.Forms.Label()
            Me.txtFailOther = New System.Windows.Forms.TextBox()
            Me.pnlMoveToStation = New System.Windows.Forms.Panel()
            Me.cboMoveTo = New C1.Win.C1List.C1Combo()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.cmdRemove = New System.Windows.Forms.Button()
            Me.lstFailCodes = New System.Windows.Forms.ListBox()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.cboPFCodes = New C1.Win.C1List.C1Combo()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.btnDelete = New System.Windows.Forms.Button()
            Me.grdHistory = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.lblSN = New System.Windows.Forms.Label()
            Me.btnAssignCostCenter = New System.Windows.Forms.Button()
            Me.lblDevRepType = New System.Windows.Forms.Label()
            Me.lblDateCode = New System.Windows.Forms.Label()
            Me.lblWrtyStatus = New System.Windows.Forms.Label()
            Me.btnCompleteBox = New System.Windows.Forms.Button()
            Me.cboCosmGrade = New C1.Win.C1List.C1Combo()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.pnlInboundCosmGrade = New System.Windows.Forms.Panel()
            Me.cboSelfInflicted = New C1.Win.C1List.C1Combo()
            Me.lblSelfInflicted = New System.Windows.Forms.Label()
            Me.lblRepType = New System.Windows.Forms.Label()
            Me.lblModelLabel = New System.Windows.Forms.Label()
            Me.lblDeviceSNLabel = New System.Windows.Forms.Label()
            Me.lblDeviceID = New System.Windows.Forms.Label()
            Me.lblDeviceSN = New System.Windows.Forms.Label()
            Me.btnNIKeyboardFail2 = New System.Windows.Forms.Button()
            Me.btnNIKeyboardFail1 = New System.Windows.Forms.Button()
            Me.btnNIKeyboardPass = New System.Windows.Forms.Button()
            Me.lblModel = New System.Windows.Forms.Label()
            Me.lblModelID = New System.Windows.Forms.Label()
            Me.pnlNIKeyBoard = New System.Windows.Forms.Panel()
            Me.chkNI_KeyboardTestBilling = New System.Windows.Forms.CheckBox()
            Me.txtUserComplaint = New System.Windows.Forms.TextBox()
            Me.grpBoxUserComplaint = New System.Windows.Forms.GroupBox()
            Me.Panel2.SuspendLayout()
            Me.Panel1.SuspendLayout()
            CType(Me.cboProduct, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlFailCodes.SuspendLayout()
            Me.pnlMoveToStation.SuspendLayout()
            CType(Me.cboMoveTo, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboPFCodes, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel3.SuspendLayout()
            CType(Me.grdHistory, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboCosmGrade, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlInboundCosmGrade.SuspendLayout()
            CType(Me.cboSelfInflicted, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlNIKeyBoard.SuspendLayout()
            Me.grpBoxUserComplaint.SuspendLayout()
            Me.SuspendLayout()
            '
            'btnClear
            '
            Me.btnClear.BackColor = System.Drawing.Color.SteelBlue
            Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClear.ForeColor = System.Drawing.Color.White
            Me.btnClear.Location = New System.Drawing.Point(784, 100)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(104, 60)
            Me.btnClear.TabIndex = 4
            Me.btnClear.Text = "CLEAR     (ESC)"
            '
            'txtDeviceSN
            '
            Me.txtDeviceSN.BackColor = System.Drawing.Color.White
            Me.txtDeviceSN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtDeviceSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDeviceSN.Location = New System.Drawing.Point(120, 79)
            Me.txtDeviceSN.Name = "txtDeviceSN"
            Me.txtDeviceSN.Size = New System.Drawing.Size(272, 20)
            Me.txtDeviceSN.TabIndex = 2
            Me.txtDeviceSN.Tag = ""
            Me.txtDeviceSN.Text = ""
            '
            'lblMainInputName
            '
            Me.lblMainInputName.BackColor = System.Drawing.Color.Transparent
            Me.lblMainInputName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMainInputName.ForeColor = System.Drawing.Color.Black
            Me.lblMainInputName.Location = New System.Drawing.Point(32, 79)
            Me.lblMainInputName.Name = "lblMainInputName"
            Me.lblMainInputName.Size = New System.Drawing.Size(80, 19)
            Me.lblMainInputName.TabIndex = 114
            Me.lblMainInputName.Text = "Device SN:"
            Me.lblMainInputName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Panel2
            '
            Me.Panel2.BackColor = System.Drawing.Color.Black
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblPretestTotal, Me.lblTotalFailed, Me.lblUserName, Me.lblWorkDate, Me.lblShift, Me.lblMachine, Me.lblLineSide, Me.lblGroup, Me.lblLine, Me.Button2, Me.lblTotalPassed})
            Me.Panel2.Location = New System.Drawing.Point(179, 1)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(709, 71)
            Me.Panel2.TabIndex = 120
            '
            'lblPretestTotal
            '
            Me.lblPretestTotal.BackColor = System.Drawing.Color.Black
            Me.lblPretestTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPretestTotal.ForeColor = System.Drawing.Color.Lime
            Me.lblPretestTotal.Location = New System.Drawing.Point(468, 41)
            Me.lblPretestTotal.Name = "lblPretestTotal"
            Me.lblPretestTotal.Size = New System.Drawing.Size(224, 19)
            Me.lblPretestTotal.TabIndex = 102
            Me.lblPretestTotal.Text = "U"
            Me.lblPretestTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblTotalFailed
            '
            Me.lblTotalFailed.BackColor = System.Drawing.Color.Black
            Me.lblTotalFailed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTotalFailed.ForeColor = System.Drawing.Color.Lime
            Me.lblTotalFailed.Location = New System.Drawing.Point(468, 24)
            Me.lblTotalFailed.Name = "lblTotalFailed"
            Me.lblTotalFailed.Size = New System.Drawing.Size(224, 18)
            Me.lblTotalFailed.TabIndex = 101
            Me.lblTotalFailed.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblUserName
            '
            Me.lblUserName.BackColor = System.Drawing.Color.Transparent
            Me.lblUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblUserName.ForeColor = System.Drawing.Color.Lime
            Me.lblUserName.Location = New System.Drawing.Point(242, 6)
            Me.lblUserName.Name = "lblUserName"
            Me.lblUserName.Size = New System.Drawing.Size(208, 19)
            Me.lblUserName.TabIndex = 100
            Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblWorkDate
            '
            Me.lblWorkDate.BackColor = System.Drawing.Color.Transparent
            Me.lblWorkDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWorkDate.ForeColor = System.Drawing.Color.Lime
            Me.lblWorkDate.Location = New System.Drawing.Point(242, 24)
            Me.lblWorkDate.Name = "lblWorkDate"
            Me.lblWorkDate.Size = New System.Drawing.Size(208, 18)
            Me.lblWorkDate.TabIndex = 99
            Me.lblWorkDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblShift
            '
            Me.lblShift.BackColor = System.Drawing.Color.Transparent
            Me.lblShift.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblShift.ForeColor = System.Drawing.Color.Lime
            Me.lblShift.Location = New System.Drawing.Point(242, 41)
            Me.lblShift.Name = "lblShift"
            Me.lblShift.Size = New System.Drawing.Size(208, 19)
            Me.lblShift.TabIndex = 98
            Me.lblShift.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblMachine
            '
            Me.lblMachine.BackColor = System.Drawing.Color.Transparent
            Me.lblMachine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMachine.ForeColor = System.Drawing.Color.Lime
            Me.lblMachine.Location = New System.Drawing.Point(9, 41)
            Me.lblMachine.Name = "lblMachine"
            Me.lblMachine.Size = New System.Drawing.Size(208, 19)
            Me.lblMachine.TabIndex = 97
            Me.lblMachine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblLineSide
            '
            Me.lblLineSide.BackColor = System.Drawing.Color.Transparent
            Me.lblLineSide.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLineSide.ForeColor = System.Drawing.Color.Lime
            Me.lblLineSide.Location = New System.Drawing.Point(66, 24)
            Me.lblLineSide.Name = "lblLineSide"
            Me.lblLineSide.Size = New System.Drawing.Size(65, 18)
            Me.lblLineSide.TabIndex = 96
            Me.lblLineSide.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblGroup
            '
            Me.lblGroup.BackColor = System.Drawing.Color.Transparent
            Me.lblGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblGroup.ForeColor = System.Drawing.Color.Lime
            Me.lblGroup.Location = New System.Drawing.Point(9, 6)
            Me.lblGroup.Name = "lblGroup"
            Me.lblGroup.Size = New System.Drawing.Size(216, 19)
            Me.lblGroup.TabIndex = 95
            Me.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblLine
            '
            Me.lblLine.BackColor = System.Drawing.Color.Transparent
            Me.lblLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLine.ForeColor = System.Drawing.Color.Lime
            Me.lblLine.Location = New System.Drawing.Point(9, 24)
            Me.lblLine.Name = "lblLine"
            Me.lblLine.Size = New System.Drawing.Size(66, 18)
            Me.lblLine.TabIndex = 94
            Me.lblLine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Button2
            '
            Me.Button2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Button2.Location = New System.Drawing.Point(168, 286)
            Me.Button2.Name = "Button2"
            Me.Button2.Size = New System.Drawing.Size(234, 37)
            Me.Button2.TabIndex = 66
            Me.Button2.TabStop = False
            Me.Button2.Text = "Generate Report"
            '
            'lblTotalPassed
            '
            Me.lblTotalPassed.BackColor = System.Drawing.Color.Black
            Me.lblTotalPassed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTotalPassed.ForeColor = System.Drawing.Color.Lime
            Me.lblTotalPassed.Location = New System.Drawing.Point(468, 6)
            Me.lblTotalPassed.Name = "lblTotalPassed"
            Me.lblTotalPassed.Size = New System.Drawing.Size(224, 19)
            Me.lblTotalPassed.TabIndex = 84
            Me.lblTotalPassed.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Black
            Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.Yellow
            Me.Label3.Location = New System.Drawing.Point(1, 1)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(178, 71)
            Me.Label3.TabIndex = 119
            Me.Label3.Text = "Pretest"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.Black
            Me.Label2.Location = New System.Drawing.Point(8, 52)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(104, 16)
            Me.Label2.TabIndex = 122
            Me.Label2.Text = "Product Type:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnFail
            '
            Me.btnFail.BackColor = System.Drawing.Color.SteelBlue
            Me.btnFail.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnFail.ForeColor = System.Drawing.Color.White
            Me.btnFail.Location = New System.Drawing.Point(576, 100)
            Me.btnFail.Name = "btnFail"
            Me.btnFail.Size = New System.Drawing.Size(192, 60)
            Me.btnFail.TabIndex = 3
            Me.btnFail.Text = "FAIL(F12)"
            '
            'btnPass
            '
            Me.btnPass.BackColor = System.Drawing.Color.SteelBlue
            Me.btnPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPass.ForeColor = System.Drawing.Color.White
            Me.btnPass.Location = New System.Drawing.Point(416, 100)
            Me.btnPass.Name = "btnPass"
            Me.btnPass.Size = New System.Drawing.Size(144, 60)
            Me.btnPass.TabIndex = 2
            Me.btnPass.Tag = "2515"
            Me.btnPass.Text = "PASS (F9)"
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboProduct, Me.chkDoNotMove, Me.cboCustomers, Me.Label1, Me.lblMainInputName, Me.txtDeviceSN, Me.Label2, Me.lblCostCenterDesc})
            Me.Panel1.Location = New System.Drawing.Point(0, 71)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(400, 129)
            Me.Panel1.TabIndex = 1
            '
            'cboProduct
            '
            Me.cboProduct.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboProduct.Caption = ""
            Me.cboProduct.CaptionHeight = 17
            Me.cboProduct.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboProduct.ColumnCaptionHeight = 17
            Me.cboProduct.ColumnFooterHeight = 17
            Me.cboProduct.ContentHeight = 15
            Me.cboProduct.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboProduct.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboProduct.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboProduct.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboProduct.EditorHeight = 15
            Me.cboProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboProduct.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboProduct.ItemHeight = 15
            Me.cboProduct.Location = New System.Drawing.Point(120, 52)
            Me.cboProduct.MatchEntryTimeout = CType(2000, Long)
            Me.cboProduct.MaxDropDownItems = CType(5, Short)
            Me.cboProduct.MaxLength = 32767
            Me.cboProduct.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboProduct.Name = "cboProduct"
            Me.cboProduct.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboProduct.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboProduct.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboProduct.Size = New System.Drawing.Size(272, 21)
            Me.cboProduct.TabIndex = 1
            Me.cboProduct.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
            "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Microsoft" & _
            " Sans Serif, 8.25pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:" & _
            "Highlight;}Style9{AlignHorz:Near;}OddRow{}RecordSelector{AlignImage:Center;}Head" & _
            "ing{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;B" & _
            "ackColor:Control;}Style8{}Style10{}Style11{}Style1{}</Data></Styles><Splits><C1." & _
            "Win.C1List.ListBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""1" & _
            "7"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" Hori" & _
            "zontalScrollGroup=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height" & _
            "><VScrollBar><Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScr" & _
            "ollBar><CaptionStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow" & _
            """ me=""Style7"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""G" & _
            "roup"" me=""Style11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowS" & _
            "tyle parent=""HighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""St" & _
            "yle4"" /><OddRowStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""" & _
            "RecordSelector"" me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><S" & _
            "tyle parent=""Normal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedSt" & _
            "yles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style" & _
            " parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style pa" & _
            "rent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style par" & _
            "ent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style pa" & _
            "rent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style" & _
            " parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSpli" & _
            "ts>1</horzSplits><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelW" & _
            "idth></Blob>"
            '
            'chkDoNotMove
            '
            Me.chkDoNotMove.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkDoNotMove.ForeColor = System.Drawing.Color.Blue
            Me.chkDoNotMove.Location = New System.Drawing.Point(120, 107)
            Me.chkDoNotMove.Name = "chkDoNotMove"
            Me.chkDoNotMove.Size = New System.Drawing.Size(280, 16)
            Me.chkDoNotMove.TabIndex = 3
            Me.chkDoNotMove.Text = "Do not move to the next workstation"
            Me.chkDoNotMove.Visible = False
            '
            'cboCustomers
            '
            Me.cboCustomers.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboCustomers.Caption = ""
            Me.cboCustomers.CaptionHeight = 17
            Me.cboCustomers.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboCustomers.ColumnCaptionHeight = 17
            Me.cboCustomers.ColumnFooterHeight = 17
            Me.cboCustomers.ContentHeight = 15
            Me.cboCustomers.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboCustomers.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboCustomers.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCustomers.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCustomers.EditorHeight = 15
            Me.cboCustomers.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCustomers.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboCustomers.ItemHeight = 15
            Me.cboCustomers.Location = New System.Drawing.Point(120, 24)
            Me.cboCustomers.MatchEntryTimeout = CType(2000, Long)
            Me.cboCustomers.MaxDropDownItems = CType(5, Short)
            Me.cboCustomers.MaxLength = 32767
            Me.cboCustomers.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCustomers.Name = "cboCustomers"
            Me.cboCustomers.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCustomers.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCustomers.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCustomers.Size = New System.Drawing.Size(271, 21)
            Me.cboCustomers.TabIndex = 0
            Me.cboCustomers.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
            "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Microsoft" & _
            " Sans Serif, 8.25pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:" & _
            "Highlight;}Style1{}OddRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;B" & _
            "ackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Cente" & _
            "r;}Style8{}Style10{}Style11{}Style9{AlignHorz:Near;}</Data></Styles><Splits><C1." & _
            "Win.C1List.ListBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""1" & _
            "7"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" Hori" & _
            "zontalScrollGroup=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height" & _
            "><VScrollBar><Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScr" & _
            "ollBar><CaptionStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow" & _
            """ me=""Style7"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""G" & _
            "roup"" me=""Style11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowS" & _
            "tyle parent=""HighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""St" & _
            "yle4"" /><OddRowStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""" & _
            "RecordSelector"" me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><S" & _
            "tyle parent=""Normal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedSt" & _
            "yles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style" & _
            " parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style pa" & _
            "rent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style par" & _
            "ent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style pa" & _
            "rent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style" & _
            " parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSpli" & _
            "ts>1</horzSplits><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelW" & _
            "idth></Blob>"
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Black
            Me.Label1.Location = New System.Drawing.Point(8, 28)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(104, 16)
            Me.Label1.TabIndex = 123
            Me.Label1.Text = "Customer:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCostCenterDesc
            '
            Me.lblCostCenterDesc.BackColor = System.Drawing.Color.Transparent
            Me.lblCostCenterDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCostCenterDesc.ForeColor = System.Drawing.Color.Blue
            Me.lblCostCenterDesc.Location = New System.Drawing.Point(8, 2)
            Me.lblCostCenterDesc.Name = "lblCostCenterDesc"
            Me.lblCostCenterDesc.Size = New System.Drawing.Size(376, 22)
            Me.lblCostCenterDesc.TabIndex = 122
            Me.lblCostCenterDesc.Text = "Cost Center H"
            Me.lblCostCenterDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnSave
            '
            Me.btnSave.BackColor = System.Drawing.Color.Green
            Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSave.ForeColor = System.Drawing.Color.White
            Me.btnSave.Location = New System.Drawing.Point(705, 408)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(184, 64)
            Me.btnSave.TabIndex = 6
            Me.btnSave.Text = "SAVE (F5)"
            '
            'pnlFailCodes
            '
            Me.pnlFailCodes.BackColor = System.Drawing.Color.LightSteelBlue
            Me.pnlFailCodes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlFailCodes.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblFC_CustLoc, Me.LabelFailOther, Me.txtFailOther, Me.pnlMoveToStation, Me.cmdRemove, Me.lstFailCodes, Me.Label7, Me.cboPFCodes})
            Me.pnlFailCodes.Location = New System.Drawing.Point(0, 400)
            Me.pnlFailCodes.Name = "pnlFailCodes"
            Me.pnlFailCodes.Size = New System.Drawing.Size(673, 168)
            Me.pnlFailCodes.TabIndex = 5
            Me.pnlFailCodes.Visible = False
            '
            'lblFC_CustLoc
            '
            Me.lblFC_CustLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblFC_CustLoc.ForeColor = System.Drawing.Color.MediumBlue
            Me.lblFC_CustLoc.Location = New System.Drawing.Point(88, 8)
            Me.lblFC_CustLoc.Name = "lblFC_CustLoc"
            Me.lblFC_CustLoc.Size = New System.Drawing.Size(304, 16)
            Me.lblFC_CustLoc.TabIndex = 128
            Me.lblFC_CustLoc.Text = "FC Cust Loc"
            '
            'LabelFailOther
            '
            Me.LabelFailOther.Location = New System.Drawing.Point(8, 120)
            Me.LabelFailOther.Name = "LabelFailOther"
            Me.LabelFailOther.Size = New System.Drawing.Size(100, 12)
            Me.LabelFailOther.TabIndex = 127
            Me.LabelFailOther.Text = "Fail Other:"
            Me.LabelFailOther.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtFailOther
            '
            Me.txtFailOther.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(224, Byte), CType(192, Byte))
            Me.txtFailOther.Location = New System.Drawing.Point(8, 136)
            Me.txtFailOther.Name = "txtFailOther"
            Me.txtFailOther.Size = New System.Drawing.Size(448, 20)
            Me.txtFailOther.TabIndex = 126
            Me.txtFailOther.Text = ""
            '
            'pnlMoveToStation
            '
            Me.pnlMoveToStation.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboMoveTo, Me.Label4})
            Me.pnlMoveToStation.Location = New System.Drawing.Point(464, -8)
            Me.pnlMoveToStation.Name = "pnlMoveToStation"
            Me.pnlMoveToStation.Size = New System.Drawing.Size(200, 56)
            Me.pnlMoveToStation.TabIndex = 125
            Me.pnlMoveToStation.Visible = False
            '
            'cboMoveTo
            '
            Me.cboMoveTo.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboMoveTo.Caption = ""
            Me.cboMoveTo.CaptionHeight = 17
            Me.cboMoveTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboMoveTo.ColumnCaptionHeight = 17
            Me.cboMoveTo.ColumnFooterHeight = 17
            Me.cboMoveTo.ContentHeight = 15
            Me.cboMoveTo.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboMoveTo.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboMoveTo.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboMoveTo.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboMoveTo.EditorHeight = 15
            Me.cboMoveTo.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboMoveTo.ItemHeight = 15
            Me.cboMoveTo.Location = New System.Drawing.Point(8, 24)
            Me.cboMoveTo.MatchEntryTimeout = CType(2000, Long)
            Me.cboMoveTo.MaxDropDownItems = CType(5, Short)
            Me.cboMoveTo.MaxLength = 32767
            Me.cboMoveTo.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboMoveTo.Name = "cboMoveTo"
            Me.cboMoveTo.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboMoveTo.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboMoveTo.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboMoveTo.Size = New System.Drawing.Size(184, 21)
            Me.cboMoveTo.TabIndex = 124
            Me.cboMoveTo.Text = "C1Combo1"
            Me.cboMoveTo.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.Black
            Me.Label4.Location = New System.Drawing.Point(8, 8)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(97, 16)
            Me.Label4.TabIndex = 123
            Me.Label4.Text = "Move To:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cmdRemove
            '
            Me.cmdRemove.BackColor = System.Drawing.Color.SteelBlue
            Me.cmdRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdRemove.ForeColor = System.Drawing.Color.White
            Me.cmdRemove.Location = New System.Drawing.Point(464, 96)
            Me.cmdRemove.Name = "cmdRemove"
            Me.cmdRemove.Size = New System.Drawing.Size(84, 37)
            Me.cmdRemove.TabIndex = 3
            Me.cmdRemove.Text = "REMOVE"
            '
            'lstFailCodes
            '
            Me.lstFailCodes.Location = New System.Drawing.Point(8, 48)
            Me.lstFailCodes.Name = "lstFailCodes"
            Me.lstFailCodes.Size = New System.Drawing.Size(448, 69)
            Me.lstFailCodes.TabIndex = 2
            '
            'Label7
            '
            Me.Label7.BackColor = System.Drawing.Color.Transparent
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.Black
            Me.Label7.Location = New System.Drawing.Point(9, 8)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(84, 16)
            Me.Label7.TabIndex = 71
            Me.Label7.Text = "Fail Code:"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cboPFCodes
            '
            Me.cboPFCodes.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboPFCodes.Caption = ""
            Me.cboPFCodes.CaptionHeight = 17
            Me.cboPFCodes.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboPFCodes.ColumnCaptionHeight = 17
            Me.cboPFCodes.ColumnFooterHeight = 17
            Me.cboPFCodes.ContentHeight = 15
            Me.cboPFCodes.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboPFCodes.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboPFCodes.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboPFCodes.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboPFCodes.EditorHeight = 15
            Me.cboPFCodes.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.cboPFCodes.ItemHeight = 15
            Me.cboPFCodes.Location = New System.Drawing.Point(8, 24)
            Me.cboPFCodes.MatchEntryTimeout = CType(2000, Long)
            Me.cboPFCodes.MaxDropDownItems = CType(5, Short)
            Me.cboPFCodes.MaxLength = 32767
            Me.cboPFCodes.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboPFCodes.Name = "cboPFCodes"
            Me.cboPFCodes.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboPFCodes.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboPFCodes.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboPFCodes.Size = New System.Drawing.Size(448, 21)
            Me.cboPFCodes.TabIndex = 122
            Me.cboPFCodes.Text = "C1Combo1"
            Me.cboPFCodes.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Panel3
            '
            Me.Panel3.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel3.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnDelete, Me.grdHistory, Me.Label8, Me.lblSN})
            Me.Panel3.Location = New System.Drawing.Point(0, 256)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(889, 144)
            Me.Panel3.TabIndex = 6
            '
            'btnDelete
            '
            Me.btnDelete.BackColor = System.Drawing.Color.Red
            Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnDelete.ForeColor = System.Drawing.Color.White
            Me.btnDelete.Location = New System.Drawing.Point(450, 4)
            Me.btnDelete.Name = "btnDelete"
            Me.btnDelete.Size = New System.Drawing.Size(177, 27)
            Me.btnDelete.TabIndex = 1
            Me.btnDelete.Text = "Delete (Are you sure?)"
            Me.btnDelete.Visible = False
            '
            'grdHistory
            '
            Me.grdHistory.GroupByCaption = "Drag a column header here to group by that column"
            Me.grdHistory.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.grdHistory.Location = New System.Drawing.Point(7, 32)
            Me.grdHistory.Name = "grdHistory"
            Me.grdHistory.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.grdHistory.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.grdHistory.PreviewInfo.ZoomFactor = 75
            Me.grdHistory.Size = New System.Drawing.Size(873, 96)
            Me.grdHistory.TabIndex = 14
            Me.grdHistory.Text = "C1TrueDBGrid1"
            Me.grdHistory.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Style9{}Normal{BackColor:LightSteelBlue;}HighlightRow{ForeColor:HighlightTex" & _
            "t;BackColor:Highlight;}Style12{}OddRow{}RecordSelector{AlignImage:Center;}Style1" & _
            "3{}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:Contro" & _
            "lText;BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style" & _
            "15{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView HBarHeight=""2" & _
            "4"" Name="""" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" M" & _
            "arqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Vert" & _
            "icalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>92</Height><CaptionStyle p" & _
            "arent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRo" & _
            "wStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Sty" & _
            "le13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me" & _
            "=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle par" & _
            "ent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" />" & _
            "<OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSe" & _
            "lector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style par" & _
            "ent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 869, 92</ClientRect><BorderSide>0</" & _
            "BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Sp" & _
            "lits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Head" & _
            "ing"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption" & _
            """ /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected""" & _
            " /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow""" & _
            " /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><S" & _
            "tyle parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar" & _
            """ /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits" & _
            "><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultR" & _
            "ecSelWidth><ClientArea>0, 0, 869, 92</ClientArea><PrintPageHeaderStyle parent=""""" & _
            " me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'Label8
            '
            Me.Label8.BackColor = System.Drawing.Color.Transparent
            Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.Black
            Me.Label8.Location = New System.Drawing.Point(4, 8)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(137, 19)
            Me.Label8.TabIndex = 74
            Me.Label8.Text = "Pretest History for "
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblSN
            '
            Me.lblSN.BackColor = System.Drawing.Color.Transparent
            Me.lblSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSN.ForeColor = System.Drawing.Color.Red
            Me.lblSN.Location = New System.Drawing.Point(150, 7)
            Me.lblSN.Name = "lblSN"
            Me.lblSN.Size = New System.Drawing.Size(218, 19)
            Me.lblSN.TabIndex = 76
            Me.lblSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnAssignCostCenter
            '
            Me.btnAssignCostCenter.BackColor = System.Drawing.Color.DarkOrange
            Me.btnAssignCostCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnAssignCostCenter.ForeColor = System.Drawing.Color.White
            Me.btnAssignCostCenter.Location = New System.Drawing.Point(672, 512)
            Me.btnAssignCostCenter.Name = "btnAssignCostCenter"
            Me.btnAssignCostCenter.Size = New System.Drawing.Size(23, 32)
            Me.btnAssignCostCenter.TabIndex = 121
            Me.btnAssignCostCenter.Text = "ASSIGN TRAY TO COST CENTER"
            Me.btnAssignCostCenter.Visible = False
            '
            'lblDevRepType
            '
            Me.lblDevRepType.BackColor = System.Drawing.Color.Black
            Me.lblDevRepType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblDevRepType.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDevRepType.ForeColor = System.Drawing.Color.Lime
            Me.lblDevRepType.Location = New System.Drawing.Point(416, 168)
            Me.lblDevRepType.Name = "lblDevRepType"
            Me.lblDevRepType.Size = New System.Drawing.Size(144, 32)
            Me.lblDevRepType.TabIndex = 136
            Me.lblDevRepType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.lblDevRepType.Visible = False
            '
            'lblDateCode
            '
            Me.lblDateCode.BackColor = System.Drawing.Color.Black
            Me.lblDateCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblDateCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDateCode.ForeColor = System.Drawing.Color.Lime
            Me.lblDateCode.Location = New System.Drawing.Point(784, 168)
            Me.lblDateCode.Name = "lblDateCode"
            Me.lblDateCode.Size = New System.Drawing.Size(104, 32)
            Me.lblDateCode.TabIndex = 135
            Me.lblDateCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.lblDateCode.Visible = False
            '
            'lblWrtyStatus
            '
            Me.lblWrtyStatus.BackColor = System.Drawing.Color.Black
            Me.lblWrtyStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblWrtyStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWrtyStatus.ForeColor = System.Drawing.Color.Lime
            Me.lblWrtyStatus.Location = New System.Drawing.Point(576, 168)
            Me.lblWrtyStatus.Name = "lblWrtyStatus"
            Me.lblWrtyStatus.Size = New System.Drawing.Size(192, 32)
            Me.lblWrtyStatus.TabIndex = 134
            Me.lblWrtyStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.lblWrtyStatus.Visible = False
            '
            'btnCompleteBox
            '
            Me.btnCompleteBox.BackColor = System.Drawing.Color.DarkOrange
            Me.btnCompleteBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCompleteBox.ForeColor = System.Drawing.Color.White
            Me.btnCompleteBox.Location = New System.Drawing.Point(708, 480)
            Me.btnCompleteBox.Name = "btnCompleteBox"
            Me.btnCompleteBox.Size = New System.Drawing.Size(179, 64)
            Me.btnCompleteBox.TabIndex = 137
            Me.btnCompleteBox.Text = "COMPLETE BOX"
            Me.btnCompleteBox.Visible = False
            '
            'cboCosmGrade
            '
            Me.cboCosmGrade.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboCosmGrade.Caption = ""
            Me.cboCosmGrade.CaptionHeight = 17
            Me.cboCosmGrade.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboCosmGrade.ColumnCaptionHeight = 17
            Me.cboCosmGrade.ColumnFooterHeight = 17
            Me.cboCosmGrade.ContentHeight = 15
            Me.cboCosmGrade.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboCosmGrade.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboCosmGrade.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCosmGrade.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCosmGrade.EditorHeight = 15
            Me.cboCosmGrade.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCosmGrade.Images.Add(CType(resources.GetObject("resource.Images5"), System.Drawing.Bitmap))
            Me.cboCosmGrade.ItemHeight = 15
            Me.cboCosmGrade.Location = New System.Drawing.Point(120, 0)
            Me.cboCosmGrade.MatchEntryTimeout = CType(2000, Long)
            Me.cboCosmGrade.MaxDropDownItems = CType(5, Short)
            Me.cboCosmGrade.MaxLength = 32767
            Me.cboCosmGrade.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCosmGrade.Name = "cboCosmGrade"
            Me.cboCosmGrade.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCosmGrade.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCosmGrade.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCosmGrade.Size = New System.Drawing.Size(271, 21)
            Me.cboCosmGrade.TabIndex = 0
            Me.cboCosmGrade.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
            "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Microsoft" & _
            " Sans Serif, 8.25pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:" & _
            "Highlight;}Style1{}OddRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;B" & _
            "ackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Cente" & _
            "r;}Style8{}Style10{}Style11{}Style9{AlignHorz:Near;}</Data></Styles><Splits><C1." & _
            "Win.C1List.ListBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""1" & _
            "7"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" Hori" & _
            "zontalScrollGroup=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height" & _
            "><VScrollBar><Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScr" & _
            "ollBar><CaptionStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow" & _
            """ me=""Style7"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""G" & _
            "roup"" me=""Style11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowS" & _
            "tyle parent=""HighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""St" & _
            "yle4"" /><OddRowStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""" & _
            "RecordSelector"" me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><S" & _
            "tyle parent=""Normal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedSt" & _
            "yles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style" & _
            " parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style pa" & _
            "rent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style par" & _
            "ent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style pa" & _
            "rent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style" & _
            " parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSpli" & _
            "ts>1</horzSplits><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelW" & _
            "idth></Blob>"
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.Black
            Me.Label5.Location = New System.Drawing.Point(8, 0)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(104, 16)
            Me.Label5.TabIndex = 123
            Me.Label5.Text = "Cosm Grade:"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'pnlInboundCosmGrade
            '
            Me.pnlInboundCosmGrade.BackColor = System.Drawing.Color.LightSteelBlue
            Me.pnlInboundCosmGrade.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlInboundCosmGrade.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboSelfInflicted, Me.lblSelfInflicted, Me.lblRepType, Me.cboCosmGrade, Me.Label5})
            Me.pnlInboundCosmGrade.Location = New System.Drawing.Point(0, 200)
            Me.pnlInboundCosmGrade.Name = "pnlInboundCosmGrade"
            Me.pnlInboundCosmGrade.Size = New System.Drawing.Size(888, 56)
            Me.pnlInboundCosmGrade.TabIndex = 2
            Me.pnlInboundCosmGrade.Visible = False
            '
            'cboSelfInflicted
            '
            Me.cboSelfInflicted.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboSelfInflicted.Caption = ""
            Me.cboSelfInflicted.CaptionHeight = 17
            Me.cboSelfInflicted.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboSelfInflicted.ColumnCaptionHeight = 17
            Me.cboSelfInflicted.ColumnFooterHeight = 17
            Me.cboSelfInflicted.ContentHeight = 15
            Me.cboSelfInflicted.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboSelfInflicted.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboSelfInflicted.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboSelfInflicted.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboSelfInflicted.EditorHeight = 15
            Me.cboSelfInflicted.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboSelfInflicted.Images.Add(CType(resources.GetObject("resource.Images6"), System.Drawing.Bitmap))
            Me.cboSelfInflicted.ItemHeight = 15
            Me.cboSelfInflicted.Location = New System.Drawing.Point(120, 24)
            Me.cboSelfInflicted.MatchEntryTimeout = CType(2000, Long)
            Me.cboSelfInflicted.MaxDropDownItems = CType(5, Short)
            Me.cboSelfInflicted.MaxLength = 32767
            Me.cboSelfInflicted.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboSelfInflicted.Name = "cboSelfInflicted"
            Me.cboSelfInflicted.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboSelfInflicted.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboSelfInflicted.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboSelfInflicted.Size = New System.Drawing.Size(271, 21)
            Me.cboSelfInflicted.TabIndex = 138
            Me.cboSelfInflicted.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
            "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Microsoft" & _
            " Sans Serif, 8.25pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:" & _
            "Highlight;}Style9{AlignHorz:Near;}OddRow{}RecordSelector{AlignImage:Center;}Head" & _
            "ing{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;B" & _
            "ackColor:Control;}Style8{}Style10{}Style11{}Style1{}</Data></Styles><Splits><C1." & _
            "Win.C1List.ListBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""1" & _
            "7"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" Hori" & _
            "zontalScrollGroup=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height" & _
            "><VScrollBar><Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScr" & _
            "ollBar><CaptionStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow" & _
            """ me=""Style7"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""G" & _
            "roup"" me=""Style11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowS" & _
            "tyle parent=""HighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""St" & _
            "yle4"" /><OddRowStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""" & _
            "RecordSelector"" me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><S" & _
            "tyle parent=""Normal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedSt" & _
            "yles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style" & _
            " parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style pa" & _
            "rent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style par" & _
            "ent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style pa" & _
            "rent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style" & _
            " parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSpli" & _
            "ts>1</horzSplits><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelW" & _
            "idth></Blob>"
            '
            'lblSelfInflicted
            '
            Me.lblSelfInflicted.BackColor = System.Drawing.Color.Transparent
            Me.lblSelfInflicted.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSelfInflicted.ForeColor = System.Drawing.Color.Black
            Me.lblSelfInflicted.Location = New System.Drawing.Point(8, 24)
            Me.lblSelfInflicted.Name = "lblSelfInflicted"
            Me.lblSelfInflicted.Size = New System.Drawing.Size(104, 16)
            Me.lblSelfInflicted.TabIndex = 139
            Me.lblSelfInflicted.Text = "Self Inflicted:"
            Me.lblSelfInflicted.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblRepType
            '
            Me.lblRepType.BackColor = System.Drawing.Color.Black
            Me.lblRepType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblRepType.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRepType.ForeColor = System.Drawing.Color.Lime
            Me.lblRepType.Location = New System.Drawing.Point(416, 2)
            Me.lblRepType.Name = "lblRepType"
            Me.lblRepType.Size = New System.Drawing.Size(464, 32)
            Me.lblRepType.TabIndex = 137
            Me.lblRepType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblModelLabel
            '
            Me.lblModelLabel.BackColor = System.Drawing.Color.Transparent
            Me.lblModelLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModelLabel.Location = New System.Drawing.Point(0, 120)
            Me.lblModelLabel.Name = "lblModelLabel"
            Me.lblModelLabel.Size = New System.Drawing.Size(64, 16)
            Me.lblModelLabel.TabIndex = 144
            Me.lblModelLabel.Text = "Model:"
            Me.lblModelLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'lblDeviceSNLabel
            '
            Me.lblDeviceSNLabel.BackColor = System.Drawing.Color.Transparent
            Me.lblDeviceSNLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDeviceSNLabel.Location = New System.Drawing.Point(24, 96)
            Me.lblDeviceSNLabel.Name = "lblDeviceSNLabel"
            Me.lblDeviceSNLabel.Size = New System.Drawing.Size(40, 16)
            Me.lblDeviceSNLabel.TabIndex = 143
            Me.lblDeviceSNLabel.Text = "SN:"
            Me.lblDeviceSNLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'lblDeviceID
            '
            Me.lblDeviceID.BackColor = System.Drawing.Color.Transparent
            Me.lblDeviceID.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDeviceID.ForeColor = System.Drawing.Color.LightSlateGray
            Me.lblDeviceID.Location = New System.Drawing.Point(432, 104)
            Me.lblDeviceID.Name = "lblDeviceID"
            Me.lblDeviceID.Size = New System.Drawing.Size(48, 8)
            Me.lblDeviceID.TabIndex = 142
            Me.lblDeviceID.Text = "0"
            Me.lblDeviceID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDeviceSN
            '
            Me.lblDeviceSN.BackColor = System.Drawing.Color.Transparent
            Me.lblDeviceSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDeviceSN.Location = New System.Drawing.Point(70, 96)
            Me.lblDeviceSN.Name = "lblDeviceSN"
            Me.lblDeviceSN.Size = New System.Drawing.Size(360, 24)
            Me.lblDeviceSN.TabIndex = 141
            Me.lblDeviceSN.Text = "A NI device sn"
            '
            'btnNIKeyboardFail2
            '
            Me.btnNIKeyboardFail2.BackColor = System.Drawing.Color.Transparent
            Me.btnNIKeyboardFail2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnNIKeyboardFail2.ForeColor = System.Drawing.Color.White
            Me.btnNIKeyboardFail2.Location = New System.Drawing.Point(272, 8)
            Me.btnNIKeyboardFail2.Name = "btnNIKeyboardFail2"
            Me.btnNIKeyboardFail2.Size = New System.Drawing.Size(184, 80)
            Me.btnNIKeyboardFail2.TabIndex = 2
            Me.btnNIKeyboardFail2.Text = "FAIL - TEST STRIP & OTHER"
            Me.btnNIKeyboardFail2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnNIKeyboardFail1
            '
            Me.btnNIKeyboardFail1.BackColor = System.Drawing.Color.Transparent
            Me.btnNIKeyboardFail1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnNIKeyboardFail1.ForeColor = System.Drawing.Color.White
            Me.btnNIKeyboardFail1.Location = New System.Drawing.Point(120, 8)
            Me.btnNIKeyboardFail1.Name = "btnNIKeyboardFail1"
            Me.btnNIKeyboardFail1.Size = New System.Drawing.Size(144, 80)
            Me.btnNIKeyboardFail1.TabIndex = 1
            Me.btnNIKeyboardFail1.Text = "FAIL - TEST STRIP"
            Me.btnNIKeyboardFail1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnNIKeyboardPass
            '
            Me.btnNIKeyboardPass.BackColor = System.Drawing.Color.Transparent
            Me.btnNIKeyboardPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnNIKeyboardPass.ForeColor = System.Drawing.Color.White
            Me.btnNIKeyboardPass.Location = New System.Drawing.Point(16, 8)
            Me.btnNIKeyboardPass.Name = "btnNIKeyboardPass"
            Me.btnNIKeyboardPass.Size = New System.Drawing.Size(96, 80)
            Me.btnNIKeyboardPass.TabIndex = 0
            Me.btnNIKeyboardPass.Text = "PASS"
            '
            'lblModel
            '
            Me.lblModel.BackColor = System.Drawing.Color.Transparent
            Me.lblModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModel.Location = New System.Drawing.Point(70, 120)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(352, 24)
            Me.lblModel.TabIndex = 139
            Me.lblModel.Text = "A NI Model"
            '
            'lblModelID
            '
            Me.lblModelID.BackColor = System.Drawing.Color.Transparent
            Me.lblModelID.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModelID.ForeColor = System.Drawing.Color.LightSlateGray
            Me.lblModelID.Location = New System.Drawing.Point(432, 128)
            Me.lblModelID.Name = "lblModelID"
            Me.lblModelID.Size = New System.Drawing.Size(48, 8)
            Me.lblModelID.TabIndex = 140
            Me.lblModelID.Text = "0"
            Me.lblModelID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'pnlNIKeyBoard
            '
            Me.pnlNIKeyBoard.BackColor = System.Drawing.Color.SlateGray
            Me.pnlNIKeyBoard.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblModelLabel, Me.lblDeviceSNLabel, Me.lblDeviceID, Me.lblDeviceSN, Me.btnNIKeyboardFail2, Me.btnNIKeyboardFail1, Me.btnNIKeyboardPass, Me.lblModel, Me.lblModelID})
            Me.pnlNIKeyBoard.Location = New System.Drawing.Point(408, 328)
            Me.pnlNIKeyBoard.Name = "pnlNIKeyBoard"
            Me.pnlNIKeyBoard.Size = New System.Drawing.Size(488, 152)
            Me.pnlNIKeyBoard.TabIndex = 138
            '
            'chkNI_KeyboardTestBilling
            '
            Me.chkNI_KeyboardTestBilling.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkNI_KeyboardTestBilling.ForeColor = System.Drawing.Color.Blue
            Me.chkNI_KeyboardTestBilling.Location = New System.Drawing.Point(416, 72)
            Me.chkNI_KeyboardTestBilling.Name = "chkNI_KeyboardTestBilling"
            Me.chkNI_KeyboardTestBilling.Size = New System.Drawing.Size(240, 24)
            Me.chkNI_KeyboardTestBilling.TabIndex = 139
            Me.chkNI_KeyboardTestBilling.Text = "NI Keybaord Test Billing"
            '
            'txtUserComplaint
            '
            Me.txtUserComplaint.BackColor = System.Drawing.Color.LightSteelBlue
            Me.txtUserComplaint.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.txtUserComplaint.Location = New System.Drawing.Point(8, 16)
            Me.txtUserComplaint.Multiline = True
            Me.txtUserComplaint.Name = "txtUserComplaint"
            Me.txtUserComplaint.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.txtUserComplaint.Size = New System.Drawing.Size(390, 32)
            Me.txtUserComplaint.TabIndex = 140
            Me.txtUserComplaint.Text = ""
            '
            'grpBoxUserComplaint
            '
            Me.grpBoxUserComplaint.BackColor = System.Drawing.Color.LightSteelBlue
            Me.grpBoxUserComplaint.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtUserComplaint})
            Me.grpBoxUserComplaint.Location = New System.Drawing.Point(0, 576)
            Me.grpBoxUserComplaint.Name = "grpBoxUserComplaint"
            Me.grpBoxUserComplaint.Size = New System.Drawing.Size(400, 52)
            Me.grpBoxUserComplaint.TabIndex = 141
            Me.grpBoxUserComplaint.TabStop = False
            Me.grpBoxUserComplaint.Text = "User Complaint"
            '
            'frmPreTest
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(888, 638)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpBoxUserComplaint, Me.chkNI_KeyboardTestBilling, Me.pnlNIKeyBoard, Me.pnlInboundCosmGrade, Me.btnCompleteBox, Me.lblDevRepType, Me.lblDateCode, Me.lblWrtyStatus, Me.btnAssignCostCenter, Me.Panel3, Me.btnSave, Me.pnlFailCodes, Me.Panel1, Me.btnFail, Me.btnPass, Me.Panel2, Me.Label3, Me.btnClear})
            Me.Name = "frmPreTest"
            Me.Text = "PreTest"
            Me.Panel2.ResumeLayout(False)
            Me.Panel1.ResumeLayout(False)
            CType(Me.cboProduct, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlFailCodes.ResumeLayout(False)
            Me.pnlMoveToStation.ResumeLayout(False)
            CType(Me.cboMoveTo, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboPFCodes, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel3.ResumeLayout(False)
            CType(Me.grdHistory, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboCosmGrade, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlInboundCosmGrade.ResumeLayout(False)
            CType(Me.cboSelfInflicted, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlNIKeyBoard.ResumeLayout(False)
            Me.grpBoxUserComplaint.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "FORM EVENTS"

		Private Sub frmPreTest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
			Dim i As Integer = 0
			Dim iCustID As Integer = 0
			Dim dt, dt2 As DataTable

			Try
				Me.pnlNIKeyBoard.Visible = False : Me.lblModel.Visible = False
				Me.chkNI_KeyboardTestBilling.Checked = False
                Me.grpBoxUserComplaint.Visible = False

				i = CheckIfMachineTiedToLine()
                Me.lblFC_CustLoc.Text = ""

				If Me._iMenuCustID = NI.CUSTOMERID Then				'NI
					If Me._strScreenName = "Test, Triage and Sort" Then
						Me.btnPass.Text = "Pass"
						Me.btnFail.Text = "Reclamation"
						Me.btnSave.Visible = False
					Else
						Me.btnPass.Text = "Process To Tech"
						Me.btnFail.Text = "Scrap"
						Me.btnFail.Visible = False
						Me.btnSave.Visible = False
					End If
					Me.chkNI_KeyboardTestBilling.Visible = True
				Else
					Me.chkNI_KeyboardTestBilling.Visible = False
				End If

				If _booCheckCompMap AndAlso (i = 0 Or Me._icc_id = 0) Then
					MessageBox.Show("Machine is not associated with any 'Line'. Can't continue.", "Check Machine Mapping", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.Enabled = False
                    Exit Sub
                    ' Me.Close()
				End If
                '
                If _bIsWIKO_Customer Then
                    If Generic.GetCustIDByMachine = _iMenuCustID Then
                        GoTo loadproduct
                    ElseIf Generic.GetCustIDByMachine() = _iMenuCustID Then
                        GoTo loadproduct
                    ElseIf Generic.GetCustIDByMachine() = _iMenuCustID Then
                        GoTo loadproduct
                    Else
                        MessageBox.Show("Please select PreTest submenu from " & _strGroup.ToUpper & "  Menu ", "Check " & _strGroup.ToUpper & "Menu", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.Enabled = False
                        Exit Sub
                    End If
                End If
                '********************
                'Load Product type
                '********************
loadproduct:    Me._booLoadData = True : LoadProductTypes() : Me._booLoadData = False : Me.cboProduct.SelectedValue = Me._iMenuProdID
                If IsDBNull(Me.cboProduct.SelectedValue) OrElse IsNothing(Me.cboProduct.SelectedValue) OrElse Me.cboProduct.SelectedValue = 0 Then
                    Select Case Me.lblGroup.Tag
                        Case 1, 83       'Messaging
                            Me.cboProduct.SelectedValue = 1
                        Case 2, 3, 4, 5, 11, 85        'Cellular 1, 2, 3, cell1 staging, cell2 staging
                            Me.cboProduct.SelectedValue = 2
                        Case 14         'Gaming
                            Me.cboProduct.SelectedValue = 5
                        Case 94         'Appliance
                            Me.cboProduct.SelectedValue = 17
                        Case Else
                            Me.cboProduct.SelectedValue = 0
                    End Select
                End If
                '****************************************
                'Load Customer
                '***************************************
                If _iMenuCustID = 0 Then iCustID = Generic.GetCustIDByMachine() Else iCustID = _iMenuCustID

                Me.cboCustomers.DataSource = Nothing
                dt = Generic.GetCustomers(True, Me.cboProduct.SelectedValue)
                Misc.PopulateC1DropDownList(Me.cboCustomers, dt, "Cust_Name1", "Cust_ID")
                Me.cboCustomers.SelectedValue = iCustID

                If _iMenuCustID > 0 Then
                    If Me._iMenuCustID = PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID Then
                        dt = Me._objPreTest.GetMoveToFailStation(True, True, False, True)
                        Misc.PopulateC1DropDownList(Me.cboMoveTo, dt, "ToStation", "ID")
                        Me.cboMoveTo.SelectedValue = 0
                        Me.pnlMoveToStation.Visible = True
                    End If

                    Me.cboCustomers.Enabled = False
                    Me.txtDeviceSN.Focus()
                End If
                '***************************
                'Define Fail code datatable
                '***************************
                Me._dtFailcodes = New DataTable()
                Buisness.Generic.AddNewColumnToDataTable(Me._dtFailcodes, "DCode_ID", "System.Int32", )
                Buisness.Generic.AddNewColumnToDataTable(Me._dtFailcodes, "DCode_LDesc", "System.String", )
                Buisness.Generic.AddNewColumnToDataTable(Me._dtFailcodes, "tpretest_id", "System.Int32", "0")    '0:Add 1:Delete

                '***************************
                If Me.cboProduct.SelectedValue > 0 Then
                    LoadPFCodes(iCustID)
                    Me.LoadUserPassFailNumber()
                End If

                If Me._iMenuCustID = PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID Then
                    Me.lblMainInputName.Text = "IMEI/MEID:"
                    Me.chkDoNotMove.Visible = True
                    Me.btnCompleteBox.Visible = True
                End If

                '****************************************
                'Load inbound cosmetic grade, and Self Inflicted reason
                '****************************************
                If Me.pnlInboundCosmGrade.Visible = True Then
                    dt = Generic.GetCosmeticGrades(True)
                    Misc.PopulateC1DropDownList(Me.cboCosmGrade, dt, "DCode_LDesc", "DCode_ID")
                    Me.cboCosmGrade.SelectedValue = 0

                    dt2 = Generic.GetSelfInflictedReasons(True)
                    Misc.PopulateC1DropDownList(Me.cboSelfInflicted, dt2, "DCode_LDesc", "DCode_ID")
                    Me.cboSelfInflicted.SelectedValue = -1

                End If
                '****************************************
                'Set User Permission for delete record
                '****************************************
                If ApplicationUser.GetPermission("DeletePretestRecord") > 0 AndAlso (Me._iMenuCustID <> 2258 Or Me.cboCustomers.SelectedValue <> 2258) Then
                    Me.btnDelete.Visible = True
                Else
                    Me.btnDelete.Visible = False
                End If

                Me.txtFailOther.Text = ""

                Me.txtDeviceSN.Focus()
            Catch ex As Exception
				MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error in FormLoad")
			Finally
				Generic.DisposeDT(dt)
				Me._booLoadData = False
			End Try
		End Sub

#End Region

		'*****************************************************************
		Private Function CheckIfMachineTiedToLine() As Integer
			Dim dt1 As DataTable
			Dim R1 As DataRow
			Dim objMisc As New PSS.Data.Buisness.Misc()

			Try
				dt1 = objMisc.CheckIfMachineTiedToLine(System.Net.Dns.GetHostName)
				If dt1.Rows.Count = 0 Then
					Return 0
				End If

				'Me.lblGroup.Text = "Group: " & dt1.Rows(0)("Group_Desc")
				'Me.lblGroup.Tag = dt1.Rows(0)("Group_ID")
                Me.lblGroup.Text = "Group: " & dt1.Rows(0)("CC_Group_Desc")
                _strGroup = dt1.Rows(0)("CC_Group_Desc")
				Me.lblGroup.Tag = dt1.Rows(0)("CC_Group_ID")
				Me.lblLine.Text = dt1.Rows(0)("Line_Number")
				Me.lblLine.Tag = dt1.Rows(0)("Line_ID")
				Me.lblLineSide.Text = dt1.Rows(0)("LineSide_Desc")
				Me._iWCLocation_ID = dt1.Rows(0)("WCLocation_ID")
				Me._iGrpLineMap_ID = dt1.Rows(0)("GrpLineMap_ID")
				Me.lblMachine.Text = "Machine: " & System.Net.Dns.GetHostName
				Me.lblUserName.Text = "User: " & PSS.Core.Global.ApplicationUser.User
				Me.lblUserName.Tag = PSS.Core.Global.ApplicationUser.IDuser
				Me.lblShift.Text = "Shift: " & PSS.Core.Global.ApplicationUser.IDShift
				Me.lblWorkDate.Tag = PSS.Core.Global.ApplicationUser.Workdate
				Me.lblWorkDate.Text = "Work Date: " & Format(CDate(Me.lblWorkDate.Tag), "MM/dd/yyyy")
				Me.lblCostCenterDesc.Text = "Cost Center " & dt1.Rows(0)("CostCenter")
				Me._icc_id = dt1.Rows(0)("cc_id")

				If Me._booCheckCompMap Then
					If dt1.Rows(0)("Group_ID") = 0 Then
						MessageBox.Show("Machine does not map to any group, line and side.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
						If MainWin.MainWin.wrkArea.TabPages.Count > 0 Then
							MainWin.MainWin.wrkArea.TabPages.RemoveAt(MainWin.MainWin.wrkArea.SelectedIndex)
						Else
							MainWin.MainWin.wrkArea.TabPages.Clear()
						End If
					ElseIf dt1.Rows(0)("CC_Group_ID") = 0 Then
						MessageBox.Show("Machine does not map to any cost center.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
						If MainWin.MainWin.wrkArea.TabPages.Count > 0 Then
							MainWin.MainWin.wrkArea.TabPages.RemoveAt(MainWin.MainWin.wrkArea.SelectedIndex)
						Else
							MainWin.MainWin.wrkArea.TabPages.Clear()
						End If
					ElseIf dt1.Rows(0)("Group_ID") <> dt1.Rows(0)("CC_Group_ID") Then
						MessageBox.Show("Group of line and group of cost center are not the same. Please correct the mapping.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
						If MainWin.MainWin.wrkArea.TabPages.Count > 0 Then
							MainWin.MainWin.wrkArea.TabPages.RemoveAt(MainWin.MainWin.wrkArea.SelectedIndex)
						Else
							MainWin.MainWin.wrkArea.TabPages.Clear()
						End If
					ElseIf Me._iMenuCustID > 0 AndAlso Not IsDBNull(dt1.Rows(0)("CCG_CustID")) Then
						If Me._iMenuCustID <> dt1.Rows(0)("CCG_CustID") Then
							MessageBox.Show("This screen is not designed to work for the current mapped group.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
							If MainWin.MainWin.wrkArea.TabPages.Count > 0 Then
								MainWin.MainWin.wrkArea.TabPages.RemoveAt(MainWin.MainWin.wrkArea.SelectedIndex)
							Else
								MainWin.MainWin.wrkArea.TabPages.Clear()
							End If
						End If
					End If
				End If

				Return 1
			Catch ex As Exception
				Throw ex
			Finally
				R1 = Nothing
				Generic.DisposeDT(dt1)
				objMisc = Nothing
			End Try
		End Function

		'*****************************************************************
		Private Sub LoadProductTypes()
			Dim dtProd As New DataTable()
			Dim objQC As New PSS.Data.Buisness.QC()

			Try
				dtProd = objQC.LoadProductTypes
				Misc.PopulateC1DropDownList(Me.cboProduct, dtProd, "prod_desc", "prod_id")
				With Me.cboProduct
					.DataSource = dtProd.DefaultView
					.SelectedValue = 0
				End With

			Catch ex As Exception
				MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
			Finally
				objQC.DisposeDT(dtProd)
				objQC = Nothing
			End Try
		End Sub

		'*****************************************************************
        Private Sub LoadPFCodes(Optional ByVal iCust_ID As Integer = 0)
            Dim dt As DataTable

            Try
                If Me.cboProduct.SelectedValue = 0 Then
                    Me.cboPFCodes.DataSource = Nothing
                    Me.cboPFCodes.Text = ""
                    Exit Sub
                End If

                Me.cboPFCodes.DataSource = Nothing
                'MessageBox.Show("LoadPFCodes: Customer_ID=" & iCust_ID & "  prod_ID=" & Me.cboProduct.SelectedValue)
                If iCust_ID = PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID Then
                    'WiKo loads failcode after scan SN in ProcessSN sub routine
                    'dt = Me._objPreTest.GetPFCodesComboData(Me.cboProduct.SelectedValue, iCust_ID)
                    ' MessageBox.Show("1: " & dt.Rows.Count)
                    'ElseIf iCust_ID = PSS.Data.Buisness.CP.CoolPad.CoolPad_CUSTOMER_ID Then
                    'All other specific customers are changed to there
                ElseIf iCust_ID = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_CUSTOMER_ID Then

                ElseIf iCust_ID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID Then

                Else
                    dt = Me._objPreTest.GetPFCodesComboData(Me.cboProduct.SelectedValue)
                    'MessageBox.Show("2: " & dt.Rows.Count)
                End If


                If Not IsNothing(dt) Then
                    Misc.PopulateC1DropDownList(cboPFCodes, dt, "DCode_LDesc", "DCode_ID")
                    Me.cboPFCodes.SelectedValue = 0
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error in LoadPFCodes")
            End Try
        End Sub

        '*****************************************************************
        Private Sub LoadUserPassFailNumber()
            Dim iArr() As Integer

            Try
                If Me.cboProduct.SelectedValue = 0 Then Exit Sub

                iArr = Me._objPreTest.GetLoadUserPassFailNumber(Me.cboProduct.SelectedValue, Me._iWCLocation_ID, Me._iTechID, Me.lblWorkDate.Tag)

                If Not IsNothing(iArr) Then
                    Me.lblTotalFailed.Text = "Total Passed: " & iArr(0).ToString
                    Me.lblTotalPassed.Text = "Total Failed: " & iArr(1).ToString.ToString
                    Me.lblPretestTotal.Text = "Total: " & (iArr(0) + iArr(1)).ToString
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Load User Pass/Fail Number")
            End Try
        End Sub

        '*****************************************************************
        Private Sub ProcessSN()
            Dim objQC As New PSS.Data.Buisness.QC()
            Dim iDevice_ID As Integer = 0
            Dim iModel_ID As Integer = 0
            Dim strSN As String = ""
            Dim strDevice_ccDesc As String = ""
            Dim iDeviceCCID As Integer = 0
            Dim dt1 As DataTable
            Dim strWorkStation As String = ""
            Dim bHaspretestHistory As Boolean = False
            Dim arrNIKeyboardModelIDs As New ArrayList()

            Try
                strSN = Me.txtDeviceSN.Text.Trim
                Me._booUpdateCCIDFlag = False
                Me.grpBoxUserComplaint.Visible = False

                If Me.cboCustomers.SelectedValue > 0 Then
                    Dim objVivint As New PSS.Data.Buisness.VV.Vivint()
                    Me.txtDeviceSN.Text = objVivint.RemovePrefixSN(strSN, Me.cboCustomers.SelectedValue)
                    strSN = Me.txtDeviceSN.Text.Trim
                    objVivint = Nothing
                End If


                If Me.txtDeviceSN.Text.Trim.Length = 0 Then
                    Exit Sub
                End If

                'NI keyboard units
                arrNIKeyboardModelIDs.Add("3965") : arrNIKeyboardModelIDs.Add("3962") : arrNIKeyboardModelIDs.Add("3966")

                If Me.cboProduct.SelectedValue = 1 And Me._icc_id = 0 Then
                    MessageBox.Show("This machine is not mapped to any 'Cost Center'.", "Pretest", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtDeviceSN.Text = ""
                    Exit Sub
                ElseIf Me.cboCustomers.SelectedValue = 0 Then
                    MessageBox.Show("Please select customer.", "Pretest", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.cboCustomers.Focus()
                    Exit Sub
                End If

                Me.Clear(False)

                If Me.cboProduct.SelectedValue = 0 Then
                    MessageBox.Show("Please select Product.", "Pretest", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtDeviceSN.Text = strSN
                    Exit Sub
                ElseIf Me._iGrpLineMap_ID = 0 Or Me._iWCLocation_ID = 0 Then
                    MessageBox.Show("Group ID missing. This machine is not mapped to any Group.", "Pretest", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtDeviceSN.Text = strSN
                    Exit Sub
                End If

                'Check if this device is actually of the product type selected.
                If Me.cboProduct.SelectedValue <> objQC.GetDeviceProductType(strSN, Me.cboCustomers.SelectedValue) Then
                    MessageBox.Show("The device scanned in is not of the Product type selected on the screen.", "Pretest", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtDeviceSN.Text = strSN
                    Exit Sub
                End If


                '******************************************
                'Get Device info and model type(Wip down/Non-WipeDown)
                ''******************************************
                dt1 = Me._objPreTest.GetPretestDeviceInfoInWIP(strSN, Me.cboCustomers.SelectedValue)

                If dt1.Rows.Count = 1 Then
                    Dim ctrl As Control, row As DataRow, strCtrlName As String = ""

                    '====================Check for NI Keyboard model====================================
                    iModel_ID = CInt(dt1.Rows(0).Item("Model_ID"))
                    iDevice_ID = CInt(dt1.Rows(0).Item("Device_ID"))
                    If Me.cboCustomers.SelectedValue = NI.CUSTOMERID AndAlso arrNIKeyboardModelIDs.Contains(iModel_ID.ToString) AndAlso Me.chkNI_KeyboardTestBilling.Checked Then
                        Me._dtControls = getInitialControlsVisibleTable()
                        For Each ctrl In Me.Controls       'keep visible state
                            strCtrlName = ctrl.Name
                            For Each row In Me._dtControls.Rows
                                If Trim(row("CtrlName")).ToUpper = strCtrlName.Trim.ToUpper Then
                                    row.BeginEdit()
                                    If ctrl.Visible = True Then
                                        row("CtrlVisibleState") = 1
                                    Else
                                        row("CtrlVisibleState") = 0
                                    End If
                                    row.AcceptChanges()
                                    Exit For
                                End If
                            Next
                        Next
                        ' Me.DataGrid1.DataSource = Me._dtControls

                        With Me.pnlNIKeyBoard
                            .Top = Me.Panel1.Top + 30 : .Left = Me.Panel1.Left + Me.Panel1.Width + 1
                            Me.lblDeviceSN.Text = strSN : Me.lblDeviceID.Text = iDevice_ID
                            Me.lblModel.Text = dt1.Rows(0).Item("Model_Desc") : Me.lblModelID.Text = iModel_ID

                            Me.btnNIKeyboardFail1.Text = "FAIL - TEST " & Environment.NewLine & "STRIP"
                            Me.btnNIKeyboardFail2.Text = "FAIL - TEST " & Environment.NewLine & "STRIP && OTHER"

                            .Visible = True : Me.lblModel.Visible = True : Me.lblModelID.Visible = True
                            'Me.btnPass.Visible = False : Me.btnFail.Visible = False : Me.btnClear.Visible = False

                            For Each ctrl In Me.Controls       'Make invisible
                                strCtrlName = ctrl.Name
                                For Each row In Me._dtControls.Rows
                                    If Trim(row("CtrlName")).ToUpper = strCtrlName.Trim.ToUpper Then
                                        If row("CtrlVisibleState") = 1 Then ctrl.Visible = False
                                        Exit For
                                    End If
                                Next
                            Next

                        End With

                        Exit Sub
                    End If


                    '===================================================================================


                    '****************************************************************
                    'Native Instruments: Get Repair type
                    '****************************************************************
                    If Me.cboCustomers.SelectedValue = NI.CUSTOMERID Then
                        Dim strRepairType As String()
                        strRepairType = NI.GetRepairType(dt1.Rows(0)("WO_ID"))
                        If strRepairType.Length <> 2 Then Throw New Exception("Invalid return value of repair type.")
                        Me.lblRepType.Tag = strRepairType(0) : Me.lblRepType.Text = strRepairType(1)
                        Dim drCellopt As DataRow = Generic.GetCelloptData(dt1.Rows(0)("Device_ID"))
                        If IsNothing(drCellopt) Then
                            Throw New Exception("Cellopt data is missing.")
                        ElseIf drCellopt("WorkStation").ToString.Trim.ToUpper = "WAREHOUSE" Then
                            Throw New Exception("Can't process unit in Warehouse station.")
                        End If

                        If Me._strScreenName = "Test, Triage and Sort" AndAlso NI.IsBulkWorkOrder(CInt(dt1.Rows(0)("WO_ID"))) = False Then
                            MessageBox.Show("Unit does not belong to bulk order. Can't perform 'Test, Triage and Sort'.", "Pretest", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Me.txtDeviceSN.Text = strSN
                            Exit Sub
                        End If
                    End If
                    '******************************************
                    'tracfone only: check current station
                    '******************************************
                    If Me._iMenuCustID = PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID Then
                        strWorkStation = dt1.Rows(0)("WorkStation").ToString.Trim.ToUpper
                        If Misc.ValidateFrStationOfScreenInWorkFlow(Me._strScreenName, strWorkStation, PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, 0) = False Then
                            Me.txtDeviceSN.Text = "" : Me.txtDeviceSN.Focus()
                            Exit Sub
                        End If

                        Me.pnlMoveToStation.Visible = True
                        If Not IsDBNull(dt1.Rows(0)("ManufDate")) AndAlso dt1.Rows(0)("ManufDate").ToString.Trim.Length > 0 Then
                            Me.lblWrtyStatus.Visible = True
                            Me.lblDateCode.Visible = True
                            Me.lblDateCode.Text = dt1.Rows(0)("ManufDate")
                            If dt1.Rows(0)("Device_ManufWrty") Then Me.lblWrtyStatus.Text = "IN WARRANTY" Else Me.lblWrtyStatus.Text = "OUT OF WARRANTY"
                        End If
                    End If
                    '******************************************

                    iDevice_ID = dt1.Rows(0)("Device_ID")
                    Me._iInWarranty = dt1.Rows(0)("Device_ManufWrty")
                    Me._iManufID = dt1.Rows(0)("Manuf_ID")
                    Me._iModelID = dt1.Rows(0)("Model_ID")
                    If Me.cboCustomers.SelectedValue = 2258 Then Me._iFuncRep = dt1.Rows(0)("FuncRep")
                    Me._iWOID = dt1.Rows(0)("WO_ID")

                    'Assinge CC_ID if not yet
                    If Me.cboProduct.SelectedValue = 1 _
                       OrElse Me._iMenuCustID = PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID _
                       OrElse Me._iMenuCustID = PSS.Data.Buisness.CP.CoolPad.CoolPad_CUSTOMER_ID _
                       OrElse Me._iMenuCustID = PSS.Data.Buisness.VV.Vivint.Vivint_CUSTOMER_ID _
                       OrElse Me._iMenuCustID = PSS.Data.Buisness.WingTech.WingTech.WingTech_CUSTOMER_ID OrElse Me._iMenuCustID = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_CUSTOMER_ID OrElse Me._iMenuCustID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID Then                           'added by Amazech-Thanga 07.08.2021

                        If Not IsDBNull(dt1.Rows(0)("cc_id")) Then iDeviceCCID = dt1.Rows(0)("cc_id")
                        If iDeviceCCID <> 0 AndAlso Me._icc_id <> iDeviceCCID Then
                            strDevice_ccDesc = Buisness.Generic.GetCostCenterDescOfDevice(iDevice_ID)
                            If strDevice_ccDesc <> "" Then
                                MessageBox.Show("This device belongs to " & strDevice_ccDesc & ".", "Pretest", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Else
                                MessageBox.Show("This device does not belong to any Cost Center.", "Pretest", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            End If

                            Me.txtDeviceSN.SelectAll()
                            Exit Sub
                        End If
                        If iDeviceCCID = 0 Then Me._booUpdateCCIDFlag = True
                    End If

                    Me._iDevice_ID = iDevice_ID
                    Me.lblSN.Text = strSN
                    Me.LoadPretestHistory(iDevice_ID, bHaspretestHistory)

                    '****************************************************************
                    'Display Warranty status, Manufacture Date code and Repair type
                    '****************************************************************
                    If Me.cboCustomers.SelectedValue = 2258 Then
                        Me.lblDevRepType.Visible = True
                        If dt1.Rows(0)("FuncRep") = 1 Then Me.lblDevRepType.Text = "Functional" Else Me.lblDevRepType.Text = "Cosmetic"
                        Me.btnCompleteBox.Visible = True
                    End If

                    If dt1.Rows(0)("ManufDate").ToString.Trim.Length > 0 Then
                        Me.lblWrtyStatus.Visible = True
                        Me.lblDateCode.Visible = True
                        Me.lblDateCode.Text = dt1.Rows(0)("ManufDate")
                        If dt1.Rows(0)("Device_ManufWrty") Then Me.lblWrtyStatus.Text = "In Warranty" Else Me.lblWrtyStatus.Text = "Out of Warranty"
                    End If

                    '****************************************************************
                    'WiKo: locad failcode for location
                    If Me._iMenuCustID = PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID Then
                        Dim iWiKo_Loc_ID As Integer = dt1.Rows(0)("Loc_ID")
                        Dim iWiKo_MCode_ID As Integer = 0
                        Dim iProd_ID As Integer = 0
                        Dim dtFC As DataTable

                        cboPFCodes.ClearItems()

                        Me.lblFC_CustLoc.Text = Me._objPreTest.getCustomerLocation(Me._iMenuCustID, iWiKo_Loc_ID)
                        Select Case iWiKo_Loc_ID
                            Case PSS.Data.Buisness.WIKO.WIKO.WIKO_AttCricket_LOC_ID
                                iWiKo_MCode_ID = PSS.Data.Buisness.WIKO.WIKO.WIKO_AttCricket_MCode_ID
                            Case PSS.Data.Buisness.WIKO.WIKO.WIKO_Special_LOC_ID
                                iWiKo_MCode_ID = PSS.Data.Buisness.WIKO.WIKO.WIKO_AttCricket_MCode_ID
                            Case PSS.Data.Buisness.WIKO.WIKO.WIKO_AttCTDI_LOC_ID
                                iWiKo_MCode_ID = PSS.Data.Buisness.WIKO.WIKO.WIKO_AttCTDI_MCode_ID
                            Case PSS.Data.Buisness.WIKO.WIKO.WIKO_AttFedEx_LOC_ID
                                iWiKo_MCode_ID = PSS.Data.Buisness.WIKO.WIKO.WIKO_AttFedEx_MCode_ID
                        End Select

                        If iWiKo_MCode_ID > 0 Then
                            dtFC = Me._objPreTest.GetWiKo_FailedCodes(Me.cboProduct.SelectedValue, iWiKo_MCode_ID)
                            If Not IsNothing(dtFC) Then
                                Misc.PopulateC1DropDownList(cboPFCodes, dtFC, "DCode_LDesc", "DCode_ID")
                                Me.cboPFCodes.SelectedValue = 0
                            End If
                        Else
                            MessageBox.Show("Invalid MCode_ID for WiKo location.  See IT.", "Pretest", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        End If
                    End If

                    'Load user complaint (ONLY FOR WIKO ATT CTDI) >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    If Me._iMenuCustID = PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID Then
                        Dim iThisLocID As Integer = 0
                        Try
                            iThisLocID = dt1.Rows(0).Item("Loc_ID")
                        Catch ex As Exception
                        End Try
                        ' Me._iDevice_ID
                        If iThisLocID = PSS.Data.Buisness.WIKO.WIKO.WIKO_AttCTDI_LOC_ID Then
                            Dim objWIKO As New PSS.Data.Buisness.WIKO.WIKO()
                            Dim strUserComplaint As String
                            strUserComplaint = objWIKO.getUserComplaint(Me._iMenuCustID, iThisLocID, Me._iDevice_ID)
                            Me.txtUserComplaint.Text = strUserComplaint
                            Me.grpBoxUserComplaint.Top = Me.Panel1.Top + Me.Panel1.Height
                            Me.grpBoxUserComplaint.Left = Me.Panel1.Left
                            Me.grpBoxUserComplaint.Visible = True
                            objWIKO = Nothing
                        End If
                    End If

                    '****************************************************************
                    'WingTechATT: locad failcode for location added by AMAzech-Thanga 07.08.2021
                    If Me._iMenuCustID = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_CUSTOMER_ID Then
                        Dim iWingTechATT_Loc_ID As Integer = dt1.Rows(0)("Loc_ID")
                        Dim iWingTechATT_MCode_ID As Integer = 0
                        Dim iProd_ID As Integer = 0
                        Dim dtFC As DataTable

                        cboPFCodes.ClearItems()

                        Me.lblFC_CustLoc.Text = Me._objPreTest.getCustomerLocation(Me._iMenuCustID, iWingTechATT_Loc_ID)
                        Select Case iWingTechATT_Loc_ID
                            Case PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCricket_LOC_ID
                                iWingTechATT_MCode_ID = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCricket_MCode_ID
                            Case PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_Special_LOC_ID
                                iWingTechATT_MCode_ID = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCricket_MCode_ID
                            Case PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCTDI_LOC_ID
                                iWingTechATT_MCode_ID = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCTDI_MCode_ID
                            Case PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttFedEx_LOC_ID
                                iWingTechATT_MCode_ID = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttFedEx_MCode_ID
                        End Select

                        If iWingTechATT_MCode_ID > 0 Then
                            dtFC = Me._objPreTest.GetWiKo_FailedCodes(Me.cboProduct.SelectedValue, iWingTechATT_MCode_ID)
                            If Not IsNothing(dtFC) Then
                                Misc.PopulateC1DropDownList(cboPFCodes, dtFC, "DCode_LDesc", "DCode_ID")
                                Me.cboPFCodes.SelectedValue = 0
                            End If
                        Else
                            MessageBox.Show("Invalid MCode_ID for WingTechATT location.  See IT.", "Pretest", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        End If
                    End If


                    'Vinsmart: locad failcode for location added by Amazech-Thanga 07.09.2021
                    If Me._iMenuCustID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID Then
                        Dim iVinsmart_Loc_ID As Integer = dt1.Rows(0)("Loc_ID")
                        Dim iVinsmart_MCode_ID As Integer = 0
                        Dim iProd_ID As Integer = 0
                        Dim dtFC As DataTable

                        cboPFCodes.ClearItems()

                        Me.lblFC_CustLoc.Text = Me._objPreTest.getCustomerLocation(Me._iMenuCustID, iVinsmart_Loc_ID)
                        Select Case iVinsmart_Loc_ID
                            Case PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttCricket_LOC_ID
                                iVinsmart_MCode_ID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttCricket_MCode_ID
                            Case PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_Special_LOC_ID
                                iVinsmart_MCode_ID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_SP_MCode_ID
                            Case PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttCTDI_LOC_ID
                                iVinsmart_MCode_ID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttCTDI_MCode_ID
                            Case PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttFedEx_LOC_ID
                                iVinsmart_MCode_ID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttFedEx_MCode_ID
                        End Select

                        If iVinsmart_MCode_ID > 0 Then
                            dtFC = Me._objPreTest.GetWiKo_FailedCodes(Me.cboProduct.SelectedValue, iVinsmart_MCode_ID)
                            If Not IsNothing(dtFC) Then
                                Misc.PopulateC1DropDownList(cboPFCodes, dtFC, "DCode_LDesc", "DCode_ID")
                                Me.cboPFCodes.SelectedValue = 0
                            End If
                        Else
                            MessageBox.Show("Invalid MCode_ID for Vinsmart location.  See IT.", "Pretest", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        End If
                    End If
                    '--------------------Coolpad : Located failcode for loaction ----------------------


                    If Me._iMenuCustID = PSS.Data.Buisness.CP.CoolPad.CoolPad_CUSTOMER_ID Then
                        Dim iCoolpad_Loc_ID As Integer = dt1.Rows(0)("Loc_ID")
                        Dim iCoolpad_MCode_ID As Integer = 0
                        Dim iProd_ID As Integer = 0
                        Dim dtFC As DataTable

                        cboPFCodes.ClearItems()

                        Me.lblFC_CustLoc.Text = Me._objPreTest.getCustomerLocation(Me._iMenuCustID, iCoolpad_Loc_ID)
                        Select Case iCoolpad_Loc_ID
                            Case PSS.Data.Buisness.CP.CoolPad.CoolPad_CP1_Loc_ID
                                iCoolpad_MCode_ID = PSS.Data.Buisness.CP.CoolPad.CoolPad_CP1_MCode_ID
                            Case PSS.Data.Buisness.CP.CoolPad.CoolPad_Special_LOC_ID
                                iCoolpad_MCode_ID = PSS.Data.Buisness.CP.CoolPad.CoolPad_CP1_MCode_ID
                        End Select

                        If iCoolpad_MCode_ID > 0 Then
                            dtFC = Me._objPreTest.GetWiKo_FailedCodes(Me.cboProduct.SelectedValue, iCoolpad_MCode_ID)

                            If Not IsNothing(dtFC) Then
                                Misc.PopulateC1DropDownList(cboPFCodes, dtFC, "DCode_LDesc", "DCode_ID")
                                Me.cboPFCodes.SelectedValue = 0


                            End If
                        Else
                            MessageBox.Show("Invalid MCode_ID for Coolpad location.  See IT.", "Pretest", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        End If
                    End If

                    '--------------------WingTech : Located failcode for loaction ---------------------- added By Amazech- Thanga 07.06.2021


                    If Me._iMenuCustID = PSS.Data.Buisness.WingTech.WingTech.WingTech_CUSTOMER_ID Then
                        Dim iWingTech_Loc_ID As Integer = dt1.Rows(0)("Loc_ID")
                        Dim iWingTech_MCode_ID As Integer = 0
                        Dim iProd_ID As Integer = 0
                        Dim dtFC As DataTable

                        cboPFCodes.ClearItems()

                        Me.lblFC_CustLoc.Text = Me._objPreTest.getCustomerLocation(Me._iMenuCustID, iWingTech_Loc_ID)
                        Select Case iWingTech_Loc_ID
                            Case PSS.Data.Buisness.WingTech.WingTech.WingTech_CP1_Loc_ID
                                iWingTech_MCode_ID = PSS.Data.Buisness.WingTech.WingTech.WingTech_CP1_MCode_ID
                        End Select

                        If iWingTech_MCode_ID > 0 Then
                            dtFC = Me._objPreTest.GetWiKo_FailedCodes(Me.cboProduct.SelectedValue, iWingTech_MCode_ID)

                            If Not IsNothing(dtFC) Then
                                Misc.PopulateC1DropDownList(cboPFCodes, dtFC, "DCode_LDesc", "DCode_ID")
                                Me.cboPFCodes.SelectedValue = 0


                            End If
                        Else
                            MessageBox.Show("Invalid MCode_ID for WingTech location.  See IT.", "Pretest", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        End If
                    End If

                    '--------------------VIVINT : Located failcode for loaction Added by Bonke ----------------------
                    ' IT IS NOT A GOOD WAY TO SET IF FOR EACH CUSTOMER, WE CAN USE IF...... ELSEIF......ENDIF
                    If Me._iMenuCustID = PSS.Data.Buisness.VV.Vivint.Vivint_CUSTOMER_ID Then
                        Dim iVivint_Loc_ID As Integer = dt1.Rows(0)("Loc_ID")
                        Dim iVivint_MCode_ID As Integer = 0
                        Dim iProd_ID As Integer = 0
                        Dim dtFC As DataTable

                        cboPFCodes.ClearItems()

                        Me.lblFC_CustLoc.Text = Me._objPreTest.getCustomerLocation(Me._iMenuCustID, iVivint_Loc_ID)
                        Select Case iVivint_Loc_ID
                            Case PSS.Data.Buisness.VV.Vivint.Vivint_VRQA_Loc_ID
                                iVivint_MCode_ID = PSS.Data.Buisness.VV.Vivint.Vivint_VRQA_MCode_ID
                        End Select

                        If iVivint_MCode_ID > 0 Then
                            dtFC = Me._objPreTest.GetWiKo_FailedCodes(Me.cboProduct.SelectedValue, iVivint_MCode_ID)
                            Dim ic As Integer = dtfc.Rows.Count
                            If Not IsNothing(dtFC) Then
                                Misc.PopulateC1DropDownList(cboPFCodes, dtFC, "DCode_LDesc", "DCode_ID")
                                Me.cboPFCodes.SelectedValue = 0
                                Dim i As Integer = cboPFCodes.ListCount()

                            End If
                        Else
                            MessageBox.Show("Invalid MCode_ID for vivint location.  See IT.", "Pretest", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        End If
                    ElseIf Me.cboCustomers.SelectedValue = PSS.Data.Buisness.Misc.WYZE_Cust_ID Then 'this has single location
                        Dim dtFC As DataTable
                        cboPFCodes.ClearItems()
                        dtFC = Me._objPreTest.GetWYZE_FailedCodes(Me.cboProduct.SelectedValue, PSS.Data.Buisness.Misc.WYZE_MCode_ID)
                        If Not IsNothing(dtFC) Then
                            Misc.PopulateC1DropDownList(cboPFCodes, dtFC, "DCode_LDesc", "DCode_ID")
                            Me.cboPFCodes.SelectedValue = 0
                        Else
                            MessageBox.Show("Can't find failure codes for WYZE Security Devices.  See IT.", "Pretest", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        End If
                    End If

                    '*************************************************************
                    'Only allow one pretest for each device, lock it (Tina's project, May 2013)
                    'added by amazech-thanga 07.06.2021(wingtech Filter)07.08.2021(WingTechATT Filter) , 07.09.2021 for Vinsmart
                    If Not (Me.cboCustomers.SelectedValue = PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID OrElse Me.cboCustomers.SelectedValue = PSS.Data.Buisness.CP.CoolPad.CoolPad_CUSTOMER_ID OrElse Me.cboCustomers.SelectedValue = PSS.Data.Buisness.WingTech.WingTech.WingTech_CUSTOMER_ID OrElse Me.cboCustomers.SelectedValue = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_CUSTOMER_ID OrElse Me.cboCustomers.SelectedValue = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID) Then
                        If bHaspretestHistory Then
                            MessageBox.Show("This device '" & strSN & "' has been already pretested! Can't perform a pretest again! Please see QC Manager or IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.btnPass.Enabled = False
                            Me.btnFail.Enabled = False
                            Me.btnSave.Enabled = False
                            Me.txtDeviceSN.Focus()
                            Exit Sub

                        Else
                            Me.btnPass.Enabled = True
                            Me.btnFail.Enabled = True
                            Me.btnSave.Enabled = True
                        End If
                    End If
                ElseIf dt1.Rows.Count = 0 Then
                    MessageBox.Show("Can't define Device SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    MessageBox.Show("Device exist more than one in WIP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error in ProcessSN")
                Me.Clear(False)
            Finally
                objQC = Nothing
            End Try
        End Sub

        '*****************************************************************
        Private Sub LoadPretestHistory(ByVal iDevice_ID As Integer, _
           Optional ByRef HasPretestHistory As Boolean = False)
            Dim dt1 As DataTable
            Dim i As Integer
            Dim R1 As DataRow

            Try
                '**********************************************
                'Get history data and populate data to controls and variable
                '**********************************************
                dt1 = Me._objPreTest.GetPretestHistory(iDevice_ID)

                If dt1.Rows.Count > 0 Then
                    HasPretestHistory = True
                    If dt1.Rows(0)("QCResult_ID") = 1 Then     'Passed
                        Me.btnPass.BackColor = Color.Green
                    Else      'Failed
                        Me.btnFail.BackColor = Color.Red

                        'Clear controls and variables
                        Me.pnlFailCodes.Visible = True
                        Me.lstFailCodes.Items.Clear()
                        Me.lstFailCodes.Refresh()
                        Me._dtFailcodes.Rows.Clear()

                        For Each R1 In dt1.Rows
                            Try
                                For i = 0 To Me.cboPFCodes.DataSource.Table.rows.count - 1
                                    If R1("DCode_ID") = Me.cboPFCodes.DataSource.Table.rows(i)("Dcode_ID") Then
                                        Me.cboPFCodes.SelectedValue = R1("DCode_ID")
                                        Me.AddFailCode(Me.cboPFCodes.DataSource.Table.rows(i)("DCode_LDesc"), R1("tpretest_id"))
                                        Exit For
                                    End If
                                Next i
                            Catch ex As Exception
                            End Try
                        Next R1
                    End If

                    '************************************************
                    'Set data grid layout
                    ''***********************************************
                    Me.grdHistory.DataSource = Nothing
                    Me.grdHistory.DataSource = dt1
                    Me.SetPretestHistoryGridLayout(Me.grdHistory, _
                     Color.Black, _
                     New Integer() {80, 80, 70, 170, 170}, _
                     C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, _
                     New Integer() {C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, C1.Win.C1TrueDBGrid.AlignHorzEnum.Near}, _
                     New String() {"QCResult_ID", "DCode_ID", "tech_id", "tpretest_id", "Device_ID"}, )
                    '************************************************
                End If

                Me.btnSave.Visible = True
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
            End Try
        End Sub

        '*******************************************************************
        Private Sub SetPretestHistoryGridLayout(ByRef grdCtrl As C1.Win.C1TrueDBGrid.C1TrueDBGrid, _
         ByVal clrHeaderForeColor As Color, _
         ByVal iArrColSize() As Integer, _
         ByVal iHeaderAlignment As Integer, _
         ByVal iArrColAlignment() As Integer, _
         ByVal strArrHideCol() As String, _
         Optional ByVal iGrandTotal As Integer = 0)
            Dim iNumOfColumns As Integer = grdCtrl.Columns.Count
            Dim i As Integer

            With grdCtrl
                'Heading style (Horizontal Alignment to Center)
                For i = 0 To iArrColSize.Length - 1
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = iHeaderAlignment       'C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    .Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = clrHeaderForeColor
                    .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = iArrColAlignment(i)       'C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    .Splits(0).DisplayColumns(i).Width = iArrColSize(i)
                Next i
                For i = 0 To strArrHideCol.Length - 1
                    .Splits(0).DisplayColumns(strArrHideCol(i)).Visible = False
                Next i
            End With
        End Sub

        '*****************************************************************
        Private Sub Clear(ByVal booKeepDeviceInfoData As Boolean)
            Me.txtDeviceSN.Text = ""
            Me.btnPass.BackColor = Color.SteelBlue
            Me.btnFail.BackColor = Color.SteelBlue
            Me.btnClear.BackColor = Color.SteelBlue

            If booKeepDeviceInfoData = False Then
                Me.lblSN.Text = ""
                Me.lblDateCode.Text = ""
                Me.lblWrtyStatus.Text = ""
                Me.lblDevRepType.Text = ""
                Me.lblDateCode.Visible = False
                Me.lblWrtyStatus.Visible = False
                Me.lblDevRepType.Visible = False
                Me.grdHistory.DataSource = Nothing
            End If

            Me.cboMoveTo.SelectedValue = 0
            Me.pnlFailCodes.Visible = False
            Me.cboPFCodes.SelectedValue = 0
            Me.lstFailCodes.Items.Clear()
            Me.lstFailCodes.Refresh()
            Me.btnSave.Visible = False
            Me._dtFailcodes.Clear()
            Me._iDevice_ID = 0
            Me._booUpdateCCIDFlag = False
            Me._iInWarranty = 0
            Me._iManufID = 0
            Me._iModelID = 0
            Me._iPretestResult = 0
            Me._iFuncRep = 0
            Me.txtFailOther.Text = ""
            If Me.pnlInboundCosmGrade.Visible = True AndAlso Not IsNothing(Me.cboCosmGrade.DataSource) Then Me.cboCosmGrade.SelectedValue = 0
            Me.lblRepType.Text = "" : Me.lblRepType.Tag = 0
            Me._iWOID = 0
        End Sub

        '*****************************************************************
        Private Sub btnPass_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPass.Click
            PassPretest()
        End Sub

        '*****************************************************************
        Private Sub PassPretest()
            If Me._iDevice_ID = 0 Then
                Me.txtDeviceSN.SelectAll()
                Me.txtDeviceSN.Focus()
                Exit Sub
            End If

            btnPass.BackColor = System.Drawing.Color.Green
            btnFail.BackColor = System.Drawing.Color.SteelBlue

            Me._iPretestResult = 1

            Me.SavePretestInfo()

            pnlFailCodes.Visible = False
            Me.cboPFCodes.SelectedValue = 0
        End Sub

        '*****************************************************************
        Private Sub btnFail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFail.Click
            FailPretest()
        End Sub

        '*****************************************************************
        Private Sub FailPretest()
            Try
                If Me._iDevice_ID = 0 Then
                    Me.txtDeviceSN.SelectAll()
                    Me.txtDeviceSN.Focus()
                    Exit Sub
                End If

                Me._iPretestResult = 2

                If Me._iMenuCustID = Buisness.NI.CUSTOMERID Then
                    Me.cboPFCodes.SelectedValue = 0 : Me.lstFailCodes.Items.Clear() : Me.lstFailCodes.Refresh()
                    Me.cboPFCodes.SelectedValue = Buisness.NI.SCRAP_FAILCODE
                    AddFailCode(cboPFCodes.Text.Trim)
                    SavePretestInfo()
                Else
                    btnPass.BackColor = System.Drawing.Color.SteelBlue
                    btnFail.BackColor = System.Drawing.Color.Red

                    pnlFailCodes.Visible = True
                    If Me.cboCustomers.SelectedValue <> PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID Then
                        Me.cboMoveTo.Visible = False
                        Me.Label4.Visible = False
                    End If

                    Me.cboPFCodes.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Fail Pretest", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '*****************************************************************
        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
            Try
                Me.Clear(False)
                Me.txtDeviceSN.Focus()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error in btnClear_Click")
            End Try
        End Sub

        '*****************************************************************
        Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
            If Me._iDevice_ID = 0 Then
                Me.txtDeviceSN.Focus()
                Exit Sub
            End If
            SavePretestInfo()
        End Sub

        '*****************************************************************
        Private Sub SavePretestInfo()
            Dim objACC As Data.Production.AssignCostCenter
            Dim i, iStationFailed As Integer, iWipOwnerID As Integer = 0
            Dim strFailCodes As String = "", strNextWrkStation As String = ""
            Dim booAMSSharedCust As Boolean = False

            Try
                i = 0 : iStationFailed = 0

                If Me.cboProduct.SelectedValue = 0 Then
                    MsgBox("Please select product.", MsgBoxStyle.Critical, "Load Pretest Codes")
                ElseIf Me._iDevice_ID = 0 Then
                    MsgBox("You must enter a device serial number.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Information")
                    Me.txtDeviceSN.Focus()
                ElseIf Me._iMenuCustID = NI.CUSTOMERID And Me.grdHistory.RowCount > 0 Then
                    MsgBox("Device has already processed at triage.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Information")
                    Me.txtDeviceSN.Focus()
                ElseIf Me._iPretestResult = 2 AndAlso (Me.lstFailCodes.Items.Count = 0 Or Me._dtFailcodes.Rows.Count = 0) Then
                    MsgBox("You must select a fail code.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Information")
                    Me.cboPFCodes.Focus()
                    'ElseIf Me._iPretestResult = 2 AndAlso Me.cboCustomers.SelectedValue = PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID AndAlso Me.cboMoveTo.SelectedValue = 0 Then
                    '    MsgBox("You must select move to station.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Information")
                    '    Me.cboPFCodes.Focus()
                ElseIf Me._iManufID = 0 Then
                    MsgBox("Unable to define manufacture.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Information")
                    Me.txtDeviceSN.Focus()
                ElseIf Me._strScreenName <> "Test, Triage and Sort" AndAlso Me.pnlInboundCosmGrade.Visible = True AndAlso Me.cboCosmGrade.SelectedValue = 0 Then     ' andalso Me._iPretestResult <> 2 AndAlso Me.lblRepType.Text.Trim.ToLower <> "sendnew" 
                    MessageBox.Show("Please select cosmestic grade.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboCosmGrade.SelectAll() : Me.cboCosmGrade.Focus()
                ElseIf Me._strScreenName = "Test, Triage and Sort" AndAlso Me._iPretestResult <> 2 AndAlso Me.pnlInboundCosmGrade.Visible = True AndAlso Me.cboCosmGrade.SelectedValue = 0 Then
                    'NI - if 
                    MessageBox.Show("Please select cosmestic grade.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboCosmGrade.SelectAll() : Me.cboCosmGrade.Focus()
                ElseIf Me.cboCustomers.SelectedValue = NI.CUSTOMERID AndAlso Me.pnlInboundCosmGrade.Visible = True AndAlso Me.cboSelfInflicted.SelectedValue = -1 Then
                    'NI - if 
                    MessageBox.Show("Please select a self inflicted reason.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboCosmGrade.SelectAll() : Me.cboCosmGrade.Focus()
                Else
                    'If Me._objPreTest.CheckPassFail(Me.cboPFCodes.SelectedValue, Me.txtDeviceSN.Text.Trim, Me._bChangePretestStatus) Then
                    If Me._iPretestResult <> 0 Then
                        If Me._iPretestResult = 2 Then
                            iStationFailed = 1
                            Me.txtFailOther.Text = Trim(Me.txtFailOther.Text)
                        Else
                            iStationFailed = 0
                            Me.txtFailOther.Text = ""
                        End If

                        '*********************************
                        'Move unit to machine mapped CC
                        '*********************************
                        If Me._booUpdateCCIDFlag = True Then
                            objACC = New Data.Production.AssignCostCenter()
                            i = objACC.AssignCostCenterToUnit(Me._iDevice_ID, Me._icc_id, Me.cboProduct.SelectedValue, strNextWrkStation)
                            If i = 0 Then Throw New Exception("System has failed to assign unit into a work center.")
                        End If

                        If Me._iMenuCustID = PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID Then
                            '***********************************************
                            'Get and assign unit to workstation for TracFone
                            '***********************************************
                            If Me.chkDoNotMove.Checked = True Then        'pass & don't want to move
                                strNextWrkStation = ""
                            ElseIf Me._dtFailcodes.Select("Dcode_ID = 3263").Length > 0 Then       'RUR
                                strNextWrkStation = "BER HOLD"
                            ElseIf iStationFailed = 1 And Me.cboMoveTo.SelectedValue > 0 Then
                                strNextWrkStation = Me.cboMoveTo.DataSource.Table.Select("ID = " & Me.cboMoveTo.SelectedValue)(0)("ToStation")
                            ElseIf Me._dtFailcodes.Select("Dcode_ID = 2391").Length > 0 Then       'No Power
                                strNextWrkStation = "PRE-BILL"
                            ElseIf Me._iFuncRep = 1 AndAlso (Me._iManufID = 1 Or Me._iManufID = 21) Then
                                strNextWrkStation = "RF1"
                            Else
                                strNextWrkStation = Generic.GetNextWorkStationInWFP(Me._strScreenName, 0, Me.cboCustomers.SelectedValue, iStationFailed, )
                            End If
                        Else
                            strNextWrkStation = Generic.GetNextWorkStationInWFP(Me._strScreenName, 0, Me.cboCustomers.SelectedValue, iStationFailed, )
                        End If

                        If Me._iMenuCustID = PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID Then strNextWrkStation = PSS.Data.Buisness.WIKO.WIKO.WIKO_PreBill_WorkStation
                        '---------------------add by Bonke 07-31-2020-------------------------
                        If Me._iMenuCustID = PSS.Data.Buisness.CP.CoolPad.CoolPad_CUSTOMER_ID Then strNextWrkStation = PSS.Data.Buisness.CP.CoolPad.CoolPad_PreBill_WorkStation
                        '---------------------add by Bonke 09-1-2020-------------------------
                        If Me._iMenuCustID = PSS.Data.Buisness.VV.Vivint.Vivint_CUSTOMER_ID Then strNextWrkStation = PSS.Data.Buisness.VV.Vivint.Vivint_PreBill_WorkStation
                        '---------------------add by Amazech-Thanga 07-06-2021-------------------------
                        If Me._iMenuCustID = PSS.Data.Buisness.WingTech.WingTech.WingTech_CUSTOMER_ID Then strNextWrkStation = PSS.Data.Buisness.WingTech.WingTech.WingTech_PreBill_WorkStation
                        '---------------------add by Amazech-Thanga 07-08-2021-------------------------
                        If Me._iMenuCustID = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_CUSTOMER_ID Then strNextWrkStation = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_PreBill_WorkStation
                        '---------------------add by Amazech-Thanga 07-09-2021-------------------------
                        If Me._iMenuCustID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID Then strNextWrkStation = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_PreBill_WorkStation

                        If strNextWrkStation.Trim.Length > 0 Then Generic.SetTcelloptWorkStationForDevice(strNextWrkStation, _iDevice_ID, Core.ApplicationUser.IDuser, Me._strScreenName, Me.Name, , , , , , )

                        '**********************************
                        'Get Wipowner for Messaging
                        '**********************************
                        booAMSSharedCust = Data.Buisness.MessLabel.IsAMSShareableInventoryCustomer(Me._iMenuCustID)
                        If booAMSSharedCust Then iWipOwnerID = Data.Buisness.MessReceive.GetAMSNextWipOwner(Me.cboCustomers.SelectedValue, Me._strScreenName, iStationFailed)
                        '**********************************

                        If Me.cboCustomers.SelectedValue = NI.CUSTOMERID Then
                            If Me._strScreenName = "Test, Triage and Sort" Then
                                If Me._iPretestResult = 2 Then
                                    If Me.NIBillReclamation(Me._iDevice_ID) = False Then Exit Sub
                                Else
                                    If Me.NIBillTestTriageAndSort(Me._iDevice_ID) = False Then Exit Sub
                                End If
                            Else
                                Me.WriteSOData()
                                If Me._iPretestResult = 2 AndAlso Me.lblRepType.Text.Trim.ToLower <> "repairthisunit" Then
                                    If NIBillScrap(Me._iDevice_ID) = False Then Exit Sub
                                End If
                            End If

                            UpdateSelfInflicted()
                        End If
                        '**********************************
                        If Me._objPreTest.UpdatePFData(Me._iDevice_ID, Me._iPretestResult, Me._dtFailcodes, Me._iTechID, System.Net.Dns.GetHostName, Me.lblWorkDate.Tag, Me._iWCLocation_ID, Me._iGrpLineMap_ID, PSS.Core.Global.ApplicationUser.IDuser, _iMenuCustID, Me.txtFailOther.Text) Then
                            '********************
                            If Me.cboCustomers.SelectedValue = NI.CUSTOMERID Then
                                If (Me._iPretestResult = 2 AndAlso Me.lblRepType.Text.Trim.ToLower <> "repairthisunit") OrElse Me._strScreenName = "Test, Triage and Sort" Then
                                    If Gui.NativeInstruments.frmBilling.NIAutoShip(Me._iDevice_ID, Me._iWOID) = False Then
                                        MessageBox.Show("System has failed to auto-ship this unit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                        Exit Sub
                                    End If
                                End If
                            End If

                            '**********************************
                            'Set Wipowner for Messaging
                            '**********************************
                            If booAMSSharedCust Then
                                Generic.SetTmessdataWipOwnerdataForDevices(_iDevice_ID, iWipOwnerID, 0, 0)
                            End If


                            ' ADD DEVICE JOURNAL ENTRY.

                            Dim _wipowner_id As Integer = 0
                            Dim _wipownersubloc_id As Integer = 0
                            Dim _messdata As New BOL.tMessData(_iDevice_ID)
                            _wipowner_id = _messdata.wipowner_id
                            _wipownersubloc_id = _messdata.wipownersubloc_id
                            _messdata = Nothing
                            Data.BLL.MsgDeviceMovement.DeviceMovementJornalInsert(_iDevice_ID, cboProduct.SelectedValue, _wipowner_id, _wipownersubloc_id, IIf(_iPretestResult = 1, "Pre-Test - Passed", "Pre-Test - Failed"))

                            '**********************************

                            Me.LoadPretestHistory(Me._iDevice_ID)
                            Me.Clear(True)
                            Me.LoadUserPassFailNumber()
                        Else
                            Me.txtDeviceSN.SelectAll()
                        End If
                    Else
                        MsgBox("No update data to save.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Information")
                    End If

                    Me.txtDeviceSN.Focus()
                    'End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "SavePretestResult")
            Finally
                objACC = Nothing
            End Try
        End Sub

        '*****************************************************************
        Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            Dim i As Integer = 0

            Try
                If Me._iDevice_ID = 0 Then
                    MsgBox("Can't define device ID. Please scan 'Serial Number' again.", MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "DeletePretest")
                ElseIf MessageBox.Show("Are you sure you want to delete?", "DeletePretestInfo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Exit Sub
                Else
                    i = Me._objPreTest.DeletePretestDataByDeviceID(Me._iDevice_ID)
                    If i > 0 Then Me.Clear(False)
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "DeletePretest")
            Finally
                Me.txtDeviceSN.Focus()
            End Try
        End Sub

        '*****************************************************************
        Private Sub AddFailCode(ByVal strFailCode As String, _
           Optional ByVal iTpretest_id As Integer = 0)
            Dim drNewRow As DataRow
            Dim i As Integer = 0

            Try
                If Me._iDevice_ID = 0 Then
                    Exit Sub
                End If

                ''***************************************
                ''Allow only 1 failed code for cellular
                ''***************************************
                'If Me.cboProduct.SelectedValue = 2 And Me.lstFailCodes.Items.Count >= 1 Then
                '    MessageBox.Show("Can't accept more one fail code for cellular product.", "Add Fail Code", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                '    Exit Sub
                'End If

                '***************************************
                'Allow only 1 failed code for cellular
                '***************************************
                If Me.cboPFCodes.SelectedValue = 0 Or Me.cboPFCodes.Text = "" Or Me.cboPFCodes.Text = "-- SELECT --" Then
                    MessageBox.Show("Please select a valid fail code.", "Add Fail Code", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                '*****************************
                'Check for duplicate in list
                '*****************************
                If Me.lstFailCodes.Items.IndexOf(strFailCode) > -1 Then
                    MsgBox("Code is already existed.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Add Fail Code")
                    Me.cboPFCodes.Focus()
                    Exit Sub
                End If

                ''*****************************************************
                ''RUR Lock Phone and send to Quantine, confirm message
                ''*****************************************************
                'If Me._iManufID = 21 AndAlso Me.cboCustomers.SelectedValue = 2258 AndAlso Me.cboPFCodes.SelectedValue = 2350 Then
                '    If MessageBox.Show("You are about to BER this unit and send to BER HOLD station. Are you sure you want to proceed?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then Exit Sub
                'End If
                If iTpretest_id = 0 AndAlso Me.cboCustomers.SelectedValue = 2258 AndAlso Me.cboPFCodes.SelectedValue = 3263 Then
                    If SelectRURBillcode() = False Then
                        Exit Sub
                    End If
                End If

                '***************************************
                'Add code
                '***************************************
                For i = 0 To Me.cboPFCodes.DataSource.Table.rows.Count - 1
                    If strFailCode = Me.cboPFCodes.DataSource.Table.rows(i)("DCode_LDesc") Then
                        Me.lstFailCodes.Items.Add(Me.cboPFCodes.DataSource.Table.rows(i)("DCode_LDesc"))
                        drNewRow = Me._dtFailcodes.NewRow
                        drNewRow("Dcode_ID") = Me.cboPFCodes.DataSource.Table.rows(i)("Dcode_ID")
                        drNewRow("DCode_LDesc") = Me.cboPFCodes.DataSource.Table.rows(i)("DCode_LDesc")
                        drNewRow("tpretest_id") = iTpretest_id
                        Me._dtFailcodes.Rows.Add(drNewRow)
                        Me._dtFailcodes.AcceptChanges()
                        Exit For
                    End If
                Next i

                If iTpretest_id = 0 AndAlso Me.cboCustomers.SelectedValue = 2258 Then
                    If Me.cboPFCodes.SelectedValue = 3263 Then
                        Me.SavePretestInfo()
                    Else
                        '***************************************
                        If Me._iManufID = 1 Or Me._iManufID = 21 Then
                            If (Me.cboMoveTo.DataSource.Table.Select("ToStation = 'RF1'").Length > 0) Then Me.cboMoveTo.SelectedValue = CInt(Me.cboMoveTo.DataSource.Table.Select("ToStation = 'RF1'")(0)("ID"))
                        Else
                            If (Me.cboMoveTo.DataSource.Table.Select("ToStation = 'Pre-bill'").Length > 0) Then Me.cboMoveTo.SelectedValue = CInt(Me.cboMoveTo.DataSource.Table.Select("ToStation = 'Pre-bill'")(0)("ID"))
                        End If
                    End If
                End If

                Me.cboPFCodes.Focus()

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Add Failure Code")
            Finally
                drNewRow = Nothing
            End Try
        End Sub

        '*****************************************************************
        Private Function SelectRURBillcode() As Boolean
            Dim objBillcodeWin As Gui.Billing.frmBillcodesSelection
            Dim booReturnVal As Boolean = False
            Try
                objBillcodeWin = New Gui.Billing.frmBillcodesSelection(Me._iDevice_ID, 1, 1, , )
                objBillcodeWin.ShowDialog()
                If objBillcodeWin._booCancel = False Then booReturnVal = True

                Return booReturnVal
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "SelectRURBillcode", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Function

        '*****************************************************************
        Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click
            Dim strFailCode As String = ""
            Dim R1 As DataRow
            Dim booRefestHistory As Boolean = False

            Try
                If Me.lstFailCodes.SelectedIndex <> -1 Then    'If nothing is selected
                    strFailCode = Me.lstFailCodes.Items.Item(Me.lstFailCodes.SelectedIndex).ToString
                    For Each R1 In Me._dtFailcodes.Rows
                        If R1("DCode_LDesc") = strFailCode Then
                            If R1("tpretest_id") > 0 Then
                                Me._objPreTest.DeletePretestDataByPretestID(R1("tpretest_id"))
                                booRefestHistory = True
                            End If
                            R1.Delete()
                            Exit For
                        End If
                    Next R1
                    Me._dtFailcodes.AcceptChanges()

                    Me.lstFailCodes.Items.RemoveAt(Me.lstFailCodes.SelectedIndex)
                    Me.lstFailCodes.Refresh()

                    If booRefestHistory = True Then
                        Me.LoadPretestHistory(Me._iDevice_ID)
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Remove Failure Code")
            Finally
                Me.cboPFCodes.Focus()
            End Try
        End Sub

        '*****************************************************************
        Private Sub AllControlsKeyupEvent(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPFCodes.KeyUp, lstFailCodes.KeyUp, grdHistory.KeyUp, btnPass.KeyUp, btnFail.KeyUp, btnClear.KeyUp, btnSave.KeyUp, txtDeviceSN.KeyUp
            If e.KeyValue = 13 AndAlso sender.name = "txtDeviceSN" Then
                Me.ProcessSN()
            ElseIf e.KeyValue = Keys.Escape Then
                Me.Clear(False)
                Me.txtDeviceSN.Focus()
            ElseIf Me._iDevice_ID = 0 Then
                Me.txtDeviceSN.Focus()
            ElseIf e.KeyValue = Keys.F9 Then    'Pass
                PassPretest()
            ElseIf e.KeyValue = Keys.F12 Then   'Fail
                FailPretest()
                Me.cboPFCodes.Focus()
            ElseIf e.KeyValue = Keys.F5 Then    'Save
                SavePretestInfo()
                Me.txtDeviceSN.Focus()
            ElseIf e.KeyValue = 13 AndAlso sender.name = "cboPFCodes" AndAlso Me.cboPFCodes.SelectedValue = 3408 AndAlso Me.txtFailOther.Text = "" Then
                MsgBox("Please enter 'Fail Other' description.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Information")
            ElseIf e.KeyValue = 13 AndAlso sender.name = "cboPFCodes" AndAlso Me._iPretestResult = 2 Then
                AddFailCode(sender.text.trim)
            End If
        End Sub

        ''*****************************************************************
        'Private Sub cboPFCodes_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPFCodes.SelectionChangeCommitted
        '    AddFailCode(sender.text.trim)
        'End Sub

        '*****************************************************************
        Private Sub btnAssignCostCenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAssignCostCenter.Click
            Dim frmACC As frmAssignCostCenter

            Try
                Me.Enabled = False

                frmACC = New frmAssignCostCenter()

                frmACC.ShowDialog()

                Me.txtDeviceSN.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error in btnAssignCostCenter_Click", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Finally
                Me.Enabled = True
            End Try
        End Sub

        '*****************************************************************
        Private Sub cboCustomers_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCustomers.KeyUp
            If e.KeyCode = Keys.Enter Then
                If Me.cboCustomers.SelectedValue > 0 Then
                    If Me.cboCustomers.SelectedValue = 2258 Then
                        Me.btnCompleteBox.Visible = True
                    ElseIf Not Me._bIsWIKO_Customer AndAlso Me.cboCustomers.SelectedValue = PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID Then
                        MessageBox.Show("If you want to do WIKO Pretest, you must select PreTest submenu from WIKO menu.", "Check WIKO Menu", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.cboCustomers.SelectedValue = 0
                        '--------------Add by Bonke ----------------------------------
                    ElseIf Not Me._bIsWIKO_Customer AndAlso Me.cboCustomers.SelectedValue = PSS.Data.Buisness.CP.CoolPad.CoolPad_CUSTOMER_ID Then
                        MessageBox.Show("If you want to do Coolpad Pretest, you must select PreTest submenu from Coolpad menu.", "Check Coolpad Menu", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.cboCustomers.SelectedValue = 0

                    ElseIf Not Me._bIsWIKO_Customer AndAlso Me.cboCustomers.SelectedValue = PSS.Data.Buisness.VV.Vivint.Vivint_CUSTOMER_ID Then
                        MessageBox.Show("If you want to do Vivint Pretest, you must select PreTest submenu from Vivint menu.", "Check Vivint Menu", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.cboCustomers.SelectedValue = 0
                        '--------------------------------------------------------------
                        'added by Amazech-thanga 07.06.2021
                    ElseIf Not Me._bIsWIKO_Customer AndAlso Me.cboCustomers.SelectedValue = PSS.Data.Buisness.WingTech.WingTech.WingTech_CUSTOMER_ID Then
                        MessageBox.Show("If you want to do WingTech Pretest, you must select PreTest submenu from WingTech menu.", "Check WingTech Menu", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.cboCustomers.SelectedValue = 0
                        'added by Amazech-thanga 07.07.2021
                    ElseIf Not Me._bIsWIKO_Customer AndAlso Me.cboCustomers.SelectedValue = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_CUSTOMER_ID Then
                        MessageBox.Show("If you want to do WingTechATT Pretest, you must select PreTest submenu from WingTechATT menu.", "Check WingTechATT Menu", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.cboCustomers.SelectedValue = 0
                        'added by Amazech-thanga 08.07.2021
                    ElseIf Not Me._bIsWIKO_Customer AndAlso Me.cboCustomers.SelectedValue = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID Then
                        MessageBox.Show("If you want to doVinsmart Pretest, you must select PreTest submenu from Vinsmart menu.", "Check Vinsmart Menu", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.cboCustomers.SelectedValue = 0

                    Else
                        Me.btnCompleteBox.Visible = True
                    End If
                    Me.txtDeviceSN.Focus()
                End If
            End If
        End Sub

        '*********************************************************************************************
        Private Sub btnCompleteBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompleteBox.Click
            Dim dt As DataTable
            Dim i As Integer = 0
            Dim strBoxID, strNextStation As String

            Try
                strBoxID = "" : strNextStation = ""
                If Me.cboCustomers.SelectedValue = 0 Then
                    MessageBox.Show("Please select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                strBoxID = InputBox("Enter warehouse box:", "Complete Box").Trim

                If strBoxID.Trim.Length > 0 Then
                    dt = Me._objPreTest.GetPretestDevices(strBoxID, Me.cboCustomers.SelectedValue)

                    If dt.Rows.Count > 0 Then
                        If dt.Rows(0)("Manuf_ID") = 16 Then
                            strNextStation = "PRE-BILL"
                        Else
                            strNextStation = "RF1"
                        End If

                        i = Me._objPreTest.CompletePretestBox(strBoxID, strNextStation, ApplicationUser.IDuser, Me._strScreenName, Me.Name)
                        If i > 0 Then MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("This box has been completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnCompleteBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Finally
                Me.Enabled = True
            End Try
        End Sub

        '*********************************************************************************************
        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub

        '*********************************************************************************************
        Private Sub cboProduct_RowChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProduct.Close
            Try
                If Me._booLoadData = True OrElse IsNothing(Me.cboProduct.DataSource) Then Exit Sub

                If Me.cboProduct.SelectedValue > 0 Then
                    LoadPFCodes(Me._iMenuCustID)
                    Me.LoadUserPassFailNumber()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "cboProduct_RowChange", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End Sub

        '*********************************************************************************************
        Private Sub WriteSOData()
            Dim objNI As New Buisness.NIRec()
            Dim i, iCosmGradeID As Integer
            Dim strMsg As String = ""

            Try
                i = 0 : iCosmGradeID = 0
                'Update Inbound Cosmetic Grade.
                objNI.SetInboundCosmeticGrade(Me._iDevice_ID, Me.cboCosmGrade.SelectedValue)
                If Me.lblRepType.Text.Trim.ToLower = "sendrefurb" OrElse Me.lblRepType.Text.Trim.ToLower = "sendnew" Then
                    If Me.lblRepType.Text.Trim.ToLower = "sendrefurb" Then iCosmGradeID = Me.cboCosmGrade.SelectedValue

                    If Me.lblRepType.Tag = 0 Then Throw New Exception("System can't define out bound condition of device.")
                    i = objNI.WriteOutBoundOrder(Me._iWOID, iCosmGradeID, Convert.ToInt32(Me.lblRepType.Tag), Me._iModelID, PSS.Core.ApplicationUser.IDuser, strMsg)
                End If
            Catch ex As Exception
                Throw ex
            Finally
                objNI = Nothing
            End Try
        End Sub

        '*********************************************************************************************
        Private Sub UpdateSelfInflicted()
            Dim objNI As New Buisness.NIRec()
            Dim i, iDcodeID As Integer
            Dim strMsg As String = ""

            Try
                i = 0 : iDcodeID = 0
                objNI.UpdateSelfInflicted(Me._iDevice_ID, Me.cboSelfInflicted.SelectedValue)

            Catch ex As Exception
                Throw ex
            Finally
                objNI = Nothing
            End Try
        End Sub


        '*********************************************************************************************
        Private Function NIBillScrap(ByVal iDeviceID As Integer) As Boolean
            Dim objDevice As Rules.Device
            Dim booResult As Boolean = False

            Try
                objDevice = New Rules.Device(iDeviceID)
                If objDevice.Parts.Select("Billcode_ID <> " & Buisness.NI.SCRAP_BILLCODE).Length > 0 Then
                    MessageBox.Show("Please remove all part/service.", "Bill Scrap", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Generic.IsBillcodeMapped(Me._iModelID, Buisness.NI.SCRAP_BILLCODE) = 0 Then
                    MessageBox.Show("Scrap billcode is not map for this model.", "Bill Scrap", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    booResult = True
                    If Generic.IsBillcodeExisted(iDeviceID, Buisness.NI.SCRAP_BILLCODE) = False Then
                        objDevice.AddPart(Buisness.NI.SCRAP_BILLCODE)
                        objDevice.Update()
                    End If
                End If

                Return booResult
            Catch ex As Exception
                Throw ex
            Finally
                objDevice = Nothing
            End Try
        End Function

        '*********************************************************************************************
        Private Function NIBillReclamation(ByVal iDeviceID As Integer) As Boolean
            Dim objDevice As Rules.Device
            Dim booResult As Boolean = False

            Try
                objDevice = New Rules.Device(iDeviceID)
                If objDevice.Parts.Select("Billcode_ID <> " & Buisness.NI.RECLAIM_BILLCODE).Length > 0 Then
                    MessageBox.Show("Please remove all part/service.", "Bill Reclamation", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Generic.IsBillcodeMapped(Me._iModelID, Buisness.NI.RECLAIM_BILLCODE) = 0 Then
                    MessageBox.Show("Reclamation billcode is not map for this model.", "Bill Reclamation", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    booResult = True
                    If Generic.IsBillcodeExisted(iDeviceID, Buisness.NI.RECLAIM_BILLCODE) = False Then
                        objDevice.AddPart(Buisness.NI.RECLAIM_BILLCODE)
                        objDevice.Update()
                    End If
                End If

                Return booResult
            Catch ex As Exception
                Throw ex
            Finally
                objDevice = Nothing
            End Try
        End Function

        '*********************************************************************************************
        Private Function NIBillTestTriageAndSort(ByVal iDeviceID As Integer) As Boolean
            Dim objDevice As Rules.Device
            Dim booResult As Boolean = False

            Try
                objDevice = New Rules.Device(iDeviceID)
                If objDevice.Parts.Select("Billcode_ID <> " & Buisness.NI.TESTTRIAGESORT_BILLCODE).Length > 0 Then
                    MessageBox.Show("Please remove all part/service.", "Bill Test, Triage and Sort", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Generic.IsBillcodeMapped(Me._iModelID, Buisness.NI.TESTTRIAGESORT_BILLCODE) = 0 Then
                    MessageBox.Show("Test, Triage and Sort billcode is not map for this model.", "Bill Test, Triage and Sort", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    booResult = True
                    If Generic.IsBillcodeExisted(iDeviceID, Buisness.NI.TESTTRIAGESORT_BILLCODE) = False Then
                        objDevice.AddPart(Buisness.NI.TESTTRIAGESORT_BILLCODE)
                        objDevice.Update()
                    End If
                End If

                Return booResult
            Catch ex As Exception
                Throw ex
            Finally
                objDevice = Nothing
            End Try
        End Function

        '*********************************************************************************************
        Private Function getInitialControlsVisibleTable() As DataTable
            Dim dt As New DataTable()
            Dim row As DataRow, col As DataColumn

            dt.Columns.Add("ID", GetType(Integer))
            dt.Columns.Add("CtrlName", GetType(String))
            dt.Columns.Add("CtrlVisibleState", GetType(Integer))

            row = dt.NewRow() : row("ID") = 1 : row("CtrlName") = "chkDoNotMove" : row("CtrlVisibleState") = 0 : dt.Rows.Add(row)
            row = dt.NewRow() : row("ID") = 2 : row("CtrlName") = "pnlInboundCosmGrade" : row("CtrlVisibleState") = 0 : dt.Rows.Add(row)
            row = dt.NewRow() : row("ID") = 3 : row("CtrlName") = "Panel3" : row("CtrlVisibleState") = 0 : dt.Rows.Add(row)
            row = dt.NewRow() : row("ID") = 4 : row("CtrlName") = "pnlFailCodes" : row("CtrlVisibleState") = 0 : dt.Rows.Add(row)
            row = dt.NewRow() : row("ID") = 5 : row("CtrlName") = "btnSave" : row("CtrlVisibleState") = 0 : dt.Rows.Add(row)
            row = dt.NewRow() : row("ID") = 6 : row("CtrlName") = "btnCompleteBox" : row("CtrlVisibleState") = 0 : dt.Rows.Add(row)
            row = dt.NewRow() : row("ID") = 7 : row("CtrlName") = "btnAssignCostCenter" : row("CtrlVisibleState") = 0 : dt.Rows.Add(row)
            row = dt.NewRow() : row("ID") = 8 : row("CtrlName") = "lblCostCenterDesc" : row("CtrlVisibleState") = 0 : dt.Rows.Add(row)
            row = dt.NewRow() : row("ID") = 9 : row("CtrlName") = "lblDevRepType" : row("CtrlVisibleState") = 0 : dt.Rows.Add(row)
            row = dt.NewRow() : row("ID") = 10 : row("CtrlName") = "lblWrtyStatus" : row("CtrlVisibleState") = 0 : dt.Rows.Add(row)
            row = dt.NewRow() : row("ID") = 11 : row("CtrlName") = "lblDateCode" : row("CtrlVisibleState") = 0 : dt.Rows.Add(row)
            row = dt.NewRow() : row("ID") = 12 : row("CtrlName") = "btnPass" : row("CtrlVisibleState") = 0 : dt.Rows.Add(row)
            row = dt.NewRow() : row("ID") = 13 : row("CtrlName") = "btnFail" : row("CtrlVisibleState") = 0 : dt.Rows.Add(row)
            row = dt.NewRow() : row("ID") = 14 : row("CtrlName") = "btnClear" : row("CtrlVisibleState") = 0 : dt.Rows.Add(row)


            Return dt
        End Function

        ''*********************************************************************************************
        'Private Function getNI_InitialFailCodeTable() As DataTable
        '    Dim dt As New DataTable()
        '    Dim row As DataRow, col As DataColumn

        '    dt.Columns.Add("DCodeID", GetType(Integer))
        '    dt.Columns.Add("DCode_Desc", GetType(String))

        '    'row = dt.NewRow() : row("ID") = 1 : row("CtrlName") = "chkDoNotMove" : row("CtrlVisibleState") = 0 : dt.Rows.Add(row)

        '    Return dt
        'End Function

        '*********************************************************************************************
        'Private Sub btnNIKeyboardPass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNIKeyboardPass.Click
        '    Dim ctrl As Control, row As DataRow, strCtrlName As String = ""

        '    Me.pnlNIKeyBoard.Visible = False

        '    For Each ctrl In Me.Controls 'Make visible
        '        strCtrlName = ctrl.Name
        '        For Each row In Me._dtControls.Rows
        '            If Trim(row("CtrlName")).ToUpper = strCtrlName.Trim.ToUpper Then
        '                If row("CtrlVisibleState") = 1 Then ctrl.Visible = True
        '                Exit For
        '            End If
        '        Next
        '    Next
        'End Sub

        '*********************************************************************************************
        Private Sub DoNIKeyboardBilling(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
         btnNIKeyboardPass.Click, btnNIKeyboardFail1.Click, btnNIKeyboardFail2.Click
            Dim ctrl As Control, row As DataRow, strCtrlName As String = ""
            Dim dtFC, dtBill, dtFC_Result, dtBilledData As DataTable
            Dim iBillMethod As Integer = 1    '1 or 2
            Dim iFC_DCode_ID As Integer = 0
            Dim vBillPrice As Double = 0
            Dim iModel_ID As Integer = 0
            Dim iDevice_ID As Integer = 0
            Dim iBillCode_ID As Integer = 0
            Dim iBillCode_ID_2 As Integer = 0
            Dim objNI As PSS.Data.Buisness.NI
            Dim strWorkDate As String
            Dim strBillDateTime As String
            Dim i As Integer = 0

            Try

                'Make sure it is NI
                If Me._iMenuCustID <> NI.CUSTOMERID Then
                    MessageBox.Show("Not NI customer! Can't process it.", "DoNIKeyboardBilling", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                'Fail codes
                dtFC = Me._objPreTest.GetNI_FailedCodesForKeyBoard
                dtFC_Result = dtFC.Clone
                If sender.name = "btnNIKeyboardFail1" Then
                    For Each row In dtFC.Rows
                        If row("DCode_ID") = 4159 Then
                            iFC_DCode_ID = row("DCode_ID") : dtFC_Result.ImportRow(row) : Exit For
                        End If
                    Next
                    If Not iFC_DCode_ID > 0 Then
                        MessageBox.Show("No valid Fail Code for Keyboard Fail Test", "DoNIKeyboardBilling", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                ElseIf sender.name = "btnNIKeyboardFail2" Then
                    For Each row In dtFC.Rows
                        If row("DCode_ID") = 4160 Then
                            iFC_DCode_ID = row("DCode_ID") : dtFC_Result.ImportRow(row) : Exit For
                        End If
                    Next
                    If Not iFC_DCode_ID > 0 Then
                        MessageBox.Show("No valid Fail Code for Keyboard Fail Test", "DoNIKeyboardBilling", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                End If

                iDevice_ID = Me.lblDeviceID.Text : iModel_ID = Me.lblModelID.Text

                'Bill price and Billcode_Id for current Method
                dtBill = Me._objPreTest.GetNI_KeyBoardBillPrice(iBillMethod)
                For Each row In dtBill.Rows
                    If row("Model_ID") = iModel_ID Then
                        vBillPrice = row("Charge") : iBillCode_ID = row("BillCode_ID") : Exit For
                    End If
                Next

                'Billcode id  for another Method
                If iBillMethod = 1 Then
                    dtBill = Me._objPreTest.GetNI_KeyBoardBillPrice(2)
                ElseIf iBillMethod = 2 Then
                    dtBill = Me._objPreTest.GetNI_KeyBoardBillPrice(1)
                End If
                For Each row In dtBill.Rows
                    If row("Model_ID") = iModel_ID Then
                        iBillCode_ID_2 = row("BillCode_ID") : Exit For
                    End If
                Next

                'Validate BillCode_ID and Bill Price
                If Not iBillCode_ID > 0 Then
                    MessageBox.Show("No billing code.", "DoNIKeyboardBilling", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                ElseIf Not vBillPrice > 0.0 Then
                    MessageBox.Show("No billing price.", "DoNIKeyboardBilling", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                'Set test result
                If sender.name = "btnNIKeyboardPass" Then    'pass
                    Me._iPretestResult = 1
                ElseIf sender.name = "btnNIKeyboardFail1" Or sender.name = "btnNIKeyboardFail2" Then    'fail
                    Me._iPretestResult = 2
                End If

                'Get billed data
                objNI = New PSS.Data.Buisness.NI()
                dtBilledData = objNI.GetDeviceBillData(iDevice_ID)


                'Check if billed
                For Each row In dtBilledData.Rows
                    If row("BillCode_ID") = iBillCode_ID OrElse row("BillCode_ID") = iBillCode_ID_2 Then
                        MessageBox.Show("Test Fee has been applied to this unit. Can't bill it again.", "DoNIKeyboardBilling", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                Next

                'Update test data and do billing
                If Me._objPreTest.UpdatePFData(iDevice_ID, Me._iPretestResult, dtFC_Result, _
                 PSS.Core.Global.ApplicationUser.IDuser, System.Net.Dns.GetHostName, _
                 Me.lblWorkDate.Tag, Me._iWCLocation_ID, _
                 Me._iGrpLineMap_ID, PSS.Core.Global.ApplicationUser.IDuser, _
                 "", True) Then

                    strWorkDate = Format(CDate(PSS.Core.Global.ApplicationUser.Workdate), "yyyy-MM-dd")
                    strBillDateTime = Format(Now, "yyyy-MM-dd HH:mm:ss")
                    i = objNI.UpdateKeyboardDeviceBilling(iDevice_ID, iBillCode_ID, PSS.Core.Global.ApplicationUser.IDuser, _
                      vBillPrice, ApplicationUser.NumberEmp, PSS.Core.Global.ApplicationUser.IDShift, _
                      Me._iMenuProdID, strWorkDate, strBillDateTime, System.Net.Dns.GetHostName)
                    If Not i > 0 Then
                        MessageBox.Show("Failed to bill!", "DoNIKeyboardBilling", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If

                    If Me._iPretestResult = 1 Then       'Passed, good unit, so close production-----------------
                        i = objNI.UpdateKeyboardDeviceAutoShip(iDevice_ID, NI.PalletID_KeyboardSP, PSS.Core.Global.ApplicationUser.IDShift, NI.RefurbDevConditionID, strBillDateTime, strWorkDate)
                    End If
                    objNI = Nothing
                Else
                    MessageBox.Show("Failed to update test data and failed to bill!", "DoNIKeyboardBilling", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

                'Reset after done
                Me.pnlNIKeyBoard.Visible = False
                For Each ctrl In Me.Controls    'Make visible
                    strCtrlName = ctrl.Name
                    For Each row In Me._dtControls.Rows
                        If Trim(row("CtrlName")).ToUpper = strCtrlName.Trim.ToUpper Then
                            If row("CtrlVisibleState") = 1 Then ctrl.Visible = True
                            Exit For
                        End If
                    Next
                Next

            Catch ex As Exception
                'MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "DoNIKeyboardBilling")
                MessageBox.Show(ex.ToString, "DoNIKeyboardBilling", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dtFC) : Generic.DisposeDT(dtBill)
                Generic.DisposeDT(dtFC_Result) : Generic.DisposeDT(dtBilledData)
            End Try
        End Sub

        Private Sub chkNI_KeyboardTestBilling_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkNI_KeyboardTestBilling.CheckedChanged
            Dim ctrl As Control
            Dim strCtrlName As String = ""
            Dim row As DataRow

            Try
                If Me.chkNI_KeyboardTestBilling.Checked = False Then
                    Me.pnlNIKeyBoard.Visible = False
                    For Each ctrl In Me.Controls       'Make visible
                        strCtrlName = ctrl.Name
                        For Each row In Me._dtControls.Rows
                            If Trim(row("CtrlName")).ToUpper = strCtrlName.Trim.ToUpper Then
                                If row("CtrlVisibleState") = 1 Then ctrl.Visible = True
                                Exit For
                            End If
                        Next
                    Next

                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, " chkNI_KeyboardTestBilling_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub txtDeviceSN_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDeviceSN.GotFocus
            txtDeviceSN.BackColor = Color.Yellow

        End Sub

        Private Sub txtDeviceSN_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDeviceSN.LostFocus
            txtDeviceSN.BackColor = Color.White

        End Sub

    End Class
End Namespace

