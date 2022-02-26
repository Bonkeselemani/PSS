Imports PSS.Data
Imports PSS.Core
Imports PSS.Rules
Imports PSS.Core.[Global]
Imports PSS.Data.Buisness

Namespace Gui.pretest

    Public Class frmPreTest
        Inherits System.Windows.Forms.Form

        Public Shared mReturnCode As Int16
        Public Shared returnWaitState As Int16 = 0
        Private _strScreenName As String = ""
        Private _iMenuCustID As Integer = 0
        Private _iMenuProdID As Integer = 0

        Private _iTechID As Integer = PSS.Core.[Global].ApplicationUser.IDtech
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

#Region " Windows Form Designer generated code "

        Public Sub New(Optional ByVal strScreenName As String = "", _
                       Optional ByVal iCustID As Integer = 0, _
                       Optional ByVal iProdID As Integer = 0, _
                       Optional ByVal booSelectInboundCosmGrade As Boolean = False, _
                       Optional ByVal booCheckCompMapping As Boolean = True)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._objPreTest = New Data.Buisness.PreTest()
            _strScreenName = strScreenName
            _iMenuCustID = iCustID
            _iMenuProdID = iProdID
            _booCheckCompMap = booCheckCompMapping

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
            Me.lblRepType = New System.Windows.Forms.Label()
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
            Me.SuspendLayout()
            '
            'btnClear
            '
            Me.btnClear.BackColor = System.Drawing.Color.SteelBlue
            Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClear.ForeColor = System.Drawing.Color.White
            Me.btnClear.Location = New System.Drawing.Point(784, 80)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(104, 80)
            Me.btnClear.TabIndex = 4
            Me.btnClear.Text = "CLEAR     (ESC)"
            '
            'txtDeviceSN
            '
            Me.txtDeviceSN.BackColor = System.Drawing.Color.Khaki
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
            Me.btnFail.Location = New System.Drawing.Point(576, 80)
            Me.btnFail.Name = "btnFail"
            Me.btnFail.Size = New System.Drawing.Size(192, 80)
            Me.btnFail.TabIndex = 3
            Me.btnFail.Text = "FAIL(F12)"
            '
            'btnPass
            '
            Me.btnPass.BackColor = System.Drawing.Color.SteelBlue
            Me.btnPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPass.ForeColor = System.Drawing.Color.White
            Me.btnPass.Location = New System.Drawing.Point(416, 80)
            Me.btnPass.Name = "btnPass"
            Me.btnPass.Size = New System.Drawing.Size(144, 80)
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
            Me.btnSave.Location = New System.Drawing.Point(705, 392)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(184, 64)
            Me.btnSave.TabIndex = 6
            Me.btnSave.Text = "SAVE (F5)"
            '
            'pnlFailCodes
            '
            Me.pnlFailCodes.BackColor = System.Drawing.Color.LightSteelBlue
            Me.pnlFailCodes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlFailCodes.Controls.AddRange(New System.Windows.Forms.Control() {Me.LabelFailOther, Me.txtFailOther, Me.pnlMoveToStation, Me.cmdRemove, Me.lstFailCodes, Me.Label7, Me.cboPFCodes})
            Me.pnlFailCodes.Location = New System.Drawing.Point(0, 384)
            Me.pnlFailCodes.Name = "pnlFailCodes"
            Me.pnlFailCodes.Size = New System.Drawing.Size(673, 152)
            Me.pnlFailCodes.TabIndex = 5
            Me.pnlFailCodes.Visible = False
            '
            'LabelFailOther
            '
            Me.LabelFailOther.Location = New System.Drawing.Point(8, 112)
            Me.LabelFailOther.Name = "LabelFailOther"
            Me.LabelFailOther.Size = New System.Drawing.Size(100, 12)
            Me.LabelFailOther.TabIndex = 127
            Me.LabelFailOther.Text = "Fail Other:"
            Me.LabelFailOther.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtFailOther
            '
            Me.txtFailOther.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(224, Byte), CType(192, Byte))
            Me.txtFailOther.Location = New System.Drawing.Point(8, 128)
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
            Me.lstFailCodes.Location = New System.Drawing.Point(8, 40)
            Me.lstFailCodes.Name = "lstFailCodes"
            Me.lstFailCodes.Size = New System.Drawing.Size(448, 69)
            Me.lstFailCodes.TabIndex = 2
            '
            'Label7
            '
            Me.Label7.BackColor = System.Drawing.Color.Transparent
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.Black
            Me.Label7.Location = New System.Drawing.Point(9, 0)
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
            Me.cboPFCodes.Location = New System.Drawing.Point(8, 16)
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
            Me.Panel3.Location = New System.Drawing.Point(0, 240)
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
            Me.btnAssignCostCenter.Location = New System.Drawing.Point(672, 496)
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
            Me.btnCompleteBox.Location = New System.Drawing.Point(708, 464)
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
            Me.cboCosmGrade.Location = New System.Drawing.Point(120, 7)
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
            Me.Label5.Location = New System.Drawing.Point(8, 8)
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
            Me.pnlInboundCosmGrade.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblRepType, Me.cboCosmGrade, Me.Label5})
            Me.pnlInboundCosmGrade.Location = New System.Drawing.Point(0, 200)
            Me.pnlInboundCosmGrade.Name = "pnlInboundCosmGrade"
            Me.pnlInboundCosmGrade.Size = New System.Drawing.Size(888, 40)
            Me.pnlInboundCosmGrade.TabIndex = 2
            Me.pnlInboundCosmGrade.Visible = False
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
            'frmPreTest
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(897, 541)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlInboundCosmGrade, Me.btnCompleteBox, Me.lblDevRepType, Me.lblDateCode, Me.lblWrtyStatus, Me.btnAssignCostCenter, Me.Panel3, Me.btnSave, Me.pnlFailCodes, Me.Panel1, Me.btnFail, Me.btnPass, Me.Panel2, Me.Label3, Me.btnClear})
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
            Me.ResumeLayout(False)

        End Sub

#End Region

        '*****************************************************************
        Private Sub frmPreTest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim i As Integer = 0
            Dim iCustID As Integer = 0
            Dim dt As DataTable

            Try
                i = CheckIfMachineTiedToLine()

                If _booCheckCompMap AndAlso (i = 0 Or Me._icc_id = 0) Then
                    MessageBox.Show("Machine is not associated with any 'Line'. Can't continue.", "Check Machine Mapping", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.Close()
                End If

                '********************
                'Load Product type
                '********************
                Me._booLoadData = True : LoadProductTypes() : Me._booLoadData = False : Me.cboProduct.SelectedValue = Me._iMenuProdID
                If IsDBNull(Me.cboProduct.SelectedValue) OrElse IsNothing(Me.cboProduct.SelectedValue) OrElse Me.cboProduct.SelectedValue = 0 Then
                    Select Case Me.lblGroup.Tag
                        Case 1, 83          'Messaging
                            Me.cboProduct.SelectedValue = 1
                        Case 2, 3, 4, 5, 11, 85     'Cellular 1, 2, 3, cell1 staging, cell2 staging
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
                    LoadPFCodes()
                    Me.LoadUserPassFailNumber()
                End If

                If Me._iMenuCustID = PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID Then
                    Me.lblMainInputName.Text = "IMEI/MEID:"
                    Me.chkDoNotMove.Visible = True
                    Me.btnCompleteBox.Visible = True
                End If

                '****************************************
                'Load inbound cosmetic grade
                '****************************************
                If Me.pnlInboundCosmGrade.Visible = True Then
                    dt = Generic.GetCosmeticGrades(True)
                    Misc.PopulateC1DropDownList(Me.cboCosmGrade, dt, "DCode_LDesc", "DCode_ID")
                    Me.cboCosmGrade.SelectedValue = 0
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
                Me.lblGroup.Tag = dt1.Rows(0)("CC_Group_ID")
                Me.lblLine.Text = dt1.Rows(0)("Line_Number")
                Me.lblLine.Tag = dt1.Rows(0)("Line_ID")
                Me.lblLineSide.Text = dt1.Rows(0)("LineSide_Desc")
                Me._iWCLocation_ID = dt1.Rows(0)("WCLocation_ID")
                Me._iGrpLineMap_ID = dt1.Rows(0)("GrpLineMap_ID")
                Me.lblMachine.Text = "Machine: " & System.Net.Dns.GetHostName
                Me.lblUserName.Text = "User: " & PSS.Core.[Global].ApplicationUser.User
                Me.lblUserName.Tag = PSS.Core.[Global].ApplicationUser.IDuser
                Me.lblShift.Text = "Shift: " & PSS.Core.[Global].ApplicationUser.IDShift
                Me.lblWorkDate.Tag = PSS.Core.[Global].ApplicationUser.Workdate
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
        Private Sub LoadPFCodes()
            Dim dt As DataTable

            Try
                If Me.cboProduct.SelectedValue = 0 Then
                    Me.cboPFCodes.DataSource = Nothing
                    Me.cboPFCodes.Text = ""
                    Exit Sub
                End If

                Me.cboPFCodes.DataSource = Nothing
                dt = Me._objPreTest.GetPFCodesComboData(Me.cboProduct.SelectedValue)

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
            Dim strSN As String = ""
            Dim strDevice_ccDesc As String = ""
            Dim iDeviceCCID As Integer = 0
            Dim dt1 As DataTable
            Dim strWorkStation As String = ""

            Try
                strSN = Me.txtDeviceSN.Text.Trim
                Me._booUpdateCCIDFlag = False

                If Me.txtDeviceSN.Text.Trim.Length = 0 Then
                    Exit Sub
                End If

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
                    '****************************************************************
                    'Native Instruments: Get Repair type
                    '****************************************************************
                    If Me.cboCustomers.SelectedValue = NI.CUSTOMERID Then
                        Dim strRepairType As String()
                        strRepairType = NI.GetRepairType(dt1.Rows(0)("WO_ID"))
                        If strRepairType.Length <> 2 Then Throw New Exception("Invalid return value of repair type.")
                        Me.lblRepType.Tag = strRepairType(0) : Me.lblRepType.Text = strRepairType(1)
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

                    If Me.cboProduct.SelectedValue = 1 Then
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
                    Me.LoadPretestHistory(iDevice_ID)

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
        Private Sub LoadPretestHistory(ByVal iDevice_ID As Integer)
            Dim dt1 As DataTable
            Dim i As Integer
            Dim R1 As DataRow

            Try
                '**********************************************
                'Get history data and populate data to controls and variable
                '**********************************************
                dt1 = Me._objPreTest.GetPretestHistory(iDevice_ID)

                If dt1.Rows.Count > 0 Then
                    If dt1.Rows(0)("QCResult_ID") = 1 Then  'Passed
                        Me.btnPass.BackColor = Color.Green
                    Else                                    'Failed
                        Me.btnFail.BackColor = Color.Red

                        'Clear controls and variables
                        Me.pnlFailCodes.Visible = True
                        Me.lstFailCodes.Items.Clear()
                        Me.lstFailCodes.Refresh()
                        Me._dtFailcodes.Rows.Clear()

                        For Each R1 In dt1.Rows
                            For i = 0 To Me.cboPFCodes.DataSource.Table.rows.count - 1
                                If R1("DCode_ID") = Me.cboPFCodes.DataSource.Table.rows(i)("Dcode_ID") Then
                                    Me.cboPFCodes.SelectedValue = R1("DCode_ID")
                                    Me.AddFailCode(Me.cboPFCodes.DataSource.Table.rows(i)("DCode_LDesc"), R1("tpretest_id"))
                                    Exit For
                                End If
                            Next i
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
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = iHeaderAlignment 'C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    .Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = clrHeaderForeColor
                    .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = iArrColAlignment(i) 'C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
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
            If Me._iDevice_ID = 0 Then
                Me.txtDeviceSN.SelectAll()
                Me.txtDeviceSN.Focus()
                Exit Sub
            End If

            btnPass.BackColor = System.Drawing.Color.SteelBlue
            btnFail.BackColor = System.Drawing.Color.Red

            Me._iPretestResult = 2
            pnlFailCodes.Visible = True
            If Me.cboCustomers.SelectedValue <> PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID Then
                Me.cboMoveTo.Visible = False
                Me.Label4.Visible = False
            End If

            Me.cboPFCodes.Focus()
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
            Dim i, iStationFailed As Integer
            Dim strFailCodes As String = ""
            Dim strNextWrkStation As String = ""

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
                ElseIf Me.pnlInboundCosmGrade.Visible = True AndAlso Me.cboCosmGrade.SelectedValue = 0 Then
                    MessageBox.Show("Please select cosmestic grade.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
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
                            If Me.chkDoNotMove.Checked = True Then  'pass & don't want to move
                                strNextWrkStation = ""
                            ElseIf Me._dtFailcodes.Select("Dcode_ID = 3263").Length > 0 Then 'RUR
                                strNextWrkStation = "BER HOLD"
                            ElseIf iStationFailed = 1 And Me.cboMoveTo.SelectedValue > 0 Then
                                strNextWrkStation = Me.cboMoveTo.DataSource.Table.Select("ID = " & Me.cboMoveTo.SelectedValue)(0)("ToStation")
                            ElseIf Me._dtFailcodes.Select("Dcode_ID = 2391").Length > 0 Then 'No Power
                                strNextWrkStation = "PRE-BILL"
                            ElseIf Me._iFuncRep = 1 AndAlso (Me._iManufID = 1 Or Me._iManufID = 21) Then
                                strNextWrkStation = "RF1"
                            Else
                                strNextWrkStation = Generic.GetNextWorkStationInWFP(Me._strScreenName, 0, Me.cboCustomers.SelectedValue, iStationFailed, )
                            End If
                        Else
                            strNextWrkStation = Generic.GetNextWorkStationInWFP(Me._strScreenName, 0, Me.cboCustomers.SelectedValue, iStationFailed, )
                        End If

                        If strNextWrkStation.Trim.Length > 0 Then Generic.SetTcelloptWorkStationForDevice(strNextWrkStation, _iDevice_ID)

                        '**********************************
                        If Me.cboCustomers.SelectedValue = NI.CUSTOMERID Then
                            Me.WriteSOData()
                        End If
                        '**********************************
                        If Me._objPreTest.UpdatePFData(Me._iDevice_ID, Me._iPretestResult, Me._dtFailcodes, Me._iTechID, System.Net.Dns.GetHostName, Me.lblWorkDate.Tag, Me._iWCLocation_ID, Me._iGrpLineMap_ID, PSS.Core.[Global].ApplicationUser.IDuser, Me.txtFailOther.Text) Then
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

                        i = Me._objPreTest.CompletePretestBox(strBoxID, strNextStation)
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
                    LoadPFCodes()
                    Me.LoadUserPassFailNumber()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "cboProduct_RowChange", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End Sub

        '*********************************************************************************************
        Private Sub WriteSOData()
            Dim objNI As New Buisness.NIRec()
            Dim i As Integer = 0

            Try
                'Update Inbound Cosmetic Grade.
                objNI.SetInboundCosmeticGrade(Me._iDevice_ID, Me.cboCosmGrade.SelectedValue)
                If Me.lblRepType.Text.Trim.ToLower = "sendrefurb" OrElse Me.lblRepType.Text.Trim.ToLower = "sendnew" Then
                    If Me.lblRepType.Tag = 0 Then Throw New Exception("System can't define out bound condition of device.")
                    i = objNI.WriteOutBoundOrder(Me._iWOID, Me.cboCosmGrade.SelectedValue, Convert.ToInt32(Me.lblRepType.Tag), Me._iModelID)
                End If
            Catch ex As Exception
                Throw ex
            Finally
                objNI = Nothing
            End Try
        End Sub

        '*********************************************************************************************

    End Class
End Namespace

