Imports PSS.Data
Imports PSS.Core
Imports PSS.Rules
Imports PSS.Core.[Global]
Imports PSS.Data.Buisness

Namespace Gui

    Public Class syxtriage
        Inherits System.Windows.Forms.Form

        Public Shared mReturnCode As Int16
        Public Shared returnWaitState As Int16 = 0
        Private _strScreenName As String = ""
        Private _iMenuCustID As Integer = 0
        Private Const ScreenID As Integer = 3764

        Private _iTechID As Integer = PSS.Core.[Global].ApplicationUser.IDtech
        Private _iWCLocation_ID As Integer = 0
        Private _iGrpLineMap_ID As Integer = 0
        Private _objPreTest As Data.Buisness.PreTest
        Private _objSyx As Data.Buisness.Syx
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
        Private _iProductID As Integer = 0
        Private _booLoadData As Boolean = False

#Region " Windows Form Designer generated code "

        Public Sub New(Optional ByVal strScreenName As String = "", _
                       Optional ByVal iCustID As Integer = 0)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._objPreTest = New Data.Buisness.PreTest()
            Me._objSyx = New Data.Buisness.Syx()
            _strScreenName = strScreenName
            _iMenuCustID = iCustID
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
        Friend WithEvents lblCostCenterDesc As System.Windows.Forms.Label
        Friend WithEvents cboPFCodes As C1.Win.C1List.C1Combo
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents cboCustomers As C1.Win.C1List.C1Combo
        Friend WithEvents lblMainInputName As System.Windows.Forms.Label
        Friend WithEvents lblDevRepType As System.Windows.Forms.Label
        Friend WithEvents lblDateCode As System.Windows.Forms.Label
        Friend WithEvents lblWrtyStatus As System.Windows.Forms.Label
        Friend WithEvents chkDoNotMove As System.Windows.Forms.CheckBox
        Friend WithEvents LabelFailOther As System.Windows.Forms.Label
        Friend WithEvents txtFailOther As System.Windows.Forms.TextBox
        Friend WithEvents btnUpdateFailOther As System.Windows.Forms.Button
        Friend WithEvents lblManufSN As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents lblProdType As System.Windows.Forms.Label
        Friend WithEvents lblNextLoc As System.Windows.Forms.Label
        Friend WithEvents cboNextLoc As C1.Win.C1List.C1Combo
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(syxtriage))
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
            Me.btnFail = New System.Windows.Forms.Button()
            Me.btnPass = New System.Windows.Forms.Button()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.lblProdType = New System.Windows.Forms.Label()
            Me.chkDoNotMove = New System.Windows.Forms.CheckBox()
            Me.cboCustomers = New C1.Win.C1List.C1Combo()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.lblCostCenterDesc = New System.Windows.Forms.Label()
            Me.btnSave = New System.Windows.Forms.Button()
            Me.pnlFailCodes = New System.Windows.Forms.Panel()
            Me.LabelFailOther = New System.Windows.Forms.Label()
            Me.txtFailOther = New System.Windows.Forms.TextBox()
            Me.cmdRemove = New System.Windows.Forms.Button()
            Me.lstFailCodes = New System.Windows.Forms.ListBox()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.cboPFCodes = New C1.Win.C1List.C1Combo()
            Me.lblNextLoc = New System.Windows.Forms.Label()
            Me.cboNextLoc = New C1.Win.C1List.C1Combo()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.lblManufSN = New System.Windows.Forms.Label()
            Me.btnDelete = New System.Windows.Forms.Button()
            Me.grdHistory = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.lblSN = New System.Windows.Forms.Label()
            Me.lblDevRepType = New System.Windows.Forms.Label()
            Me.lblDateCode = New System.Windows.Forms.Label()
            Me.lblWrtyStatus = New System.Windows.Forms.Label()
            Me.btnUpdateFailOther = New System.Windows.Forms.Button()
            Me.Panel2.SuspendLayout()
            Me.Panel1.SuspendLayout()
            CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlFailCodes.SuspendLayout()
            CType(Me.cboPFCodes, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboNextLoc, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel3.SuspendLayout()
            CType(Me.grdHistory, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'btnClear
            '
            Me.btnClear.BackColor = System.Drawing.Color.SteelBlue
            Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClear.ForeColor = System.Drawing.Color.White
            Me.btnClear.Location = New System.Drawing.Point(848, 80)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(104, 64)
            Me.btnClear.TabIndex = 4
            Me.btnClear.Text = "CLEAR     (ESC)"
            '
            'txtDeviceSN
            '
            Me.txtDeviceSN.BackColor = System.Drawing.Color.Khaki
            Me.txtDeviceSN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtDeviceSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDeviceSN.Location = New System.Drawing.Point(120, 80)
            Me.txtDeviceSN.Name = "txtDeviceSN"
            Me.txtDeviceSN.Size = New System.Drawing.Size(320, 20)
            Me.txtDeviceSN.TabIndex = 2
            Me.txtDeviceSN.Tag = ""
            Me.txtDeviceSN.Text = ""
            '
            'lblMainInputName
            '
            Me.lblMainInputName.BackColor = System.Drawing.Color.Transparent
            Me.lblMainInputName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMainInputName.ForeColor = System.Drawing.Color.Black
            Me.lblMainInputName.Location = New System.Drawing.Point(32, 80)
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
            Me.Panel2.Location = New System.Drawing.Point(280, 1)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(672, 71)
            Me.Panel2.TabIndex = 120
            '
            'lblPretestTotal
            '
            Me.lblPretestTotal.BackColor = System.Drawing.Color.Black
            Me.lblPretestTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPretestTotal.ForeColor = System.Drawing.Color.Lime
            Me.lblPretestTotal.Location = New System.Drawing.Point(440, 41)
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
            Me.lblTotalFailed.Location = New System.Drawing.Point(440, 24)
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
            Me.lblUserName.Location = New System.Drawing.Point(224, 6)
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
            Me.lblWorkDate.Location = New System.Drawing.Point(224, 24)
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
            Me.lblShift.Location = New System.Drawing.Point(224, 41)
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
            Me.lblMachine.Location = New System.Drawing.Point(0, 41)
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
            Me.lblLineSide.Location = New System.Drawing.Point(56, 24)
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
            Me.lblGroup.Location = New System.Drawing.Point(0, 6)
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
            Me.lblLine.Location = New System.Drawing.Point(0, 24)
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
            Me.lblTotalPassed.Location = New System.Drawing.Point(440, 6)
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
            Me.Label3.Size = New System.Drawing.Size(279, 71)
            Me.Label3.TabIndex = 119
            Me.Label3.Text = "Pretest/Triage"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnFail
            '
            Me.btnFail.BackColor = System.Drawing.Color.SteelBlue
            Me.btnFail.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnFail.ForeColor = System.Drawing.Color.White
            Me.btnFail.Location = New System.Drawing.Point(640, 80)
            Me.btnFail.Name = "btnFail"
            Me.btnFail.Size = New System.Drawing.Size(192, 64)
            Me.btnFail.TabIndex = 3
            Me.btnFail.Text = "FAIL(F12)"
            '
            'btnPass
            '
            Me.btnPass.BackColor = System.Drawing.Color.SteelBlue
            Me.btnPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPass.ForeColor = System.Drawing.Color.White
            Me.btnPass.Location = New System.Drawing.Point(480, 80)
            Me.btnPass.Name = "btnPass"
            Me.btnPass.Size = New System.Drawing.Size(144, 64)
            Me.btnPass.TabIndex = 2
            Me.btnPass.Tag = "2515"
            Me.btnPass.Text = "PASS (F9)"
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label4, Me.lblProdType, Me.chkDoNotMove, Me.cboCustomers, Me.Label1, Me.lblMainInputName, Me.txtDeviceSN, Me.lblCostCenterDesc})
            Me.Panel1.Location = New System.Drawing.Point(0, 71)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(472, 129)
            Me.Panel1.TabIndex = 1
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.Black
            Me.Label4.Location = New System.Drawing.Point(8, 53)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(104, 19)
            Me.Label4.TabIndex = 138
            Me.Label4.Text = "Product Type :"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblProdType
            '
            Me.lblProdType.BackColor = System.Drawing.Color.White
            Me.lblProdType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblProdType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblProdType.ForeColor = System.Drawing.Color.Black
            Me.lblProdType.Location = New System.Drawing.Point(120, 50)
            Me.lblProdType.Name = "lblProdType"
            Me.lblProdType.Size = New System.Drawing.Size(320, 22)
            Me.lblProdType.TabIndex = 137
            Me.lblProdType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'chkDoNotMove
            '
            Me.chkDoNotMove.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkDoNotMove.ForeColor = System.Drawing.Color.Blue
            Me.chkDoNotMove.Location = New System.Drawing.Point(120, 104)
            Me.chkDoNotMove.Name = "chkDoNotMove"
            Me.chkDoNotMove.Size = New System.Drawing.Size(280, 16)
            Me.chkDoNotMove.TabIndex = 124
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
            Me.cboCustomers.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
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
            Me.cboCustomers.Size = New System.Drawing.Size(320, 21)
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
            Me.btnSave.Location = New System.Drawing.Point(705, 400)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(184, 64)
            Me.btnSave.TabIndex = 6
            Me.btnSave.Text = "SAVE (F5)"
            '
            'pnlFailCodes
            '
            Me.pnlFailCodes.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(255, Byte))
            Me.pnlFailCodes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlFailCodes.Controls.AddRange(New System.Windows.Forms.Control() {Me.LabelFailOther, Me.txtFailOther, Me.cmdRemove, Me.lstFailCodes, Me.Label7, Me.cboPFCodes, Me.lblNextLoc, Me.cboNextLoc})
            Me.pnlFailCodes.Location = New System.Drawing.Point(0, 376)
            Me.pnlFailCodes.Name = "pnlFailCodes"
            Me.pnlFailCodes.Size = New System.Drawing.Size(673, 160)
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
            'cmdRemove
            '
            Me.cmdRemove.BackColor = System.Drawing.Color.SteelBlue
            Me.cmdRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdRemove.ForeColor = System.Drawing.Color.White
            Me.cmdRemove.Location = New System.Drawing.Point(472, 72)
            Me.cmdRemove.Name = "cmdRemove"
            Me.cmdRemove.Size = New System.Drawing.Size(184, 32)
            Me.cmdRemove.TabIndex = 3
            Me.cmdRemove.Text = "Remove Fail Code"
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
            Me.cboPFCodes.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
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
            'lblNextLoc
            '
            Me.lblNextLoc.BackColor = System.Drawing.Color.Transparent
            Me.lblNextLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblNextLoc.ForeColor = System.Drawing.Color.Black
            Me.lblNextLoc.Location = New System.Drawing.Point(472, 8)
            Me.lblNextLoc.Name = "lblNextLoc"
            Me.lblNextLoc.Size = New System.Drawing.Size(97, 16)
            Me.lblNextLoc.TabIndex = 123
            Me.lblNextLoc.Text = "Next Location:"
            Me.lblNextLoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cboNextLoc
            '
            Me.cboNextLoc.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboNextLoc.Caption = ""
            Me.cboNextLoc.CaptionHeight = 17
            Me.cboNextLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboNextLoc.ColumnCaptionHeight = 17
            Me.cboNextLoc.ColumnFooterHeight = 17
            Me.cboNextLoc.ContentHeight = 15
            Me.cboNextLoc.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboNextLoc.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboNextLoc.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboNextLoc.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboNextLoc.EditorHeight = 15
            Me.cboNextLoc.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboNextLoc.ItemHeight = 15
            Me.cboNextLoc.Location = New System.Drawing.Point(472, 24)
            Me.cboNextLoc.MatchEntryTimeout = CType(2000, Long)
            Me.cboNextLoc.MaxDropDownItems = CType(5, Short)
            Me.cboNextLoc.MaxLength = 32767
            Me.cboNextLoc.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboNextLoc.Name = "cboNextLoc"
            Me.cboNextLoc.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboNextLoc.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboNextLoc.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboNextLoc.Size = New System.Drawing.Size(184, 21)
            Me.cboNextLoc.TabIndex = 124
            Me.cboNextLoc.Text = "C1Combo1"
            Me.cboNextLoc.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Panel3
            '
            Me.Panel3.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel3.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblManufSN, Me.btnDelete, Me.grdHistory, Me.Label8, Me.lblSN})
            Me.Panel3.Location = New System.Drawing.Point(0, 200)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(952, 180)
            Me.Panel3.TabIndex = 6
            '
            'lblManufSN
            '
            Me.lblManufSN.BackColor = System.Drawing.Color.Transparent
            Me.lblManufSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblManufSN.ForeColor = System.Drawing.Color.Red
            Me.lblManufSN.Location = New System.Drawing.Point(448, 8)
            Me.lblManufSN.Name = "lblManufSN"
            Me.lblManufSN.Size = New System.Drawing.Size(288, 19)
            Me.lblManufSN.TabIndex = 77
            Me.lblManufSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnDelete
            '
            Me.btnDelete.BackColor = System.Drawing.Color.Red
            Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnDelete.ForeColor = System.Drawing.Color.White
            Me.btnDelete.Location = New System.Drawing.Point(800, 4)
            Me.btnDelete.Name = "btnDelete"
            Me.btnDelete.Size = New System.Drawing.Size(136, 27)
            Me.btnDelete.TabIndex = 1
            Me.btnDelete.Text = "Delete (Are you sure?)"
            Me.btnDelete.Visible = False
            '
            'grdHistory
            '
            Me.grdHistory.GroupByCaption = "Drag a column header here to group by that column"
            Me.grdHistory.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.grdHistory.Location = New System.Drawing.Point(7, 37)
            Me.grdHistory.Name = "grdHistory"
            Me.grdHistory.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.grdHistory.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.grdHistory.PreviewInfo.ZoomFactor = 75
            Me.grdHistory.Size = New System.Drawing.Size(929, 131)
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
            "icalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>127</Height><CaptionStyle " & _
            "parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenR" & _
            "owStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""St" & _
            "yle13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" m" & _
            "e=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle pa" & _
            "rent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /" & _
            "><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordS" & _
            "elector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style pa" & _
            "rent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 925, 127</ClientRect><BorderSide>0" & _
            "</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></" & _
            "Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""He" & _
            "ading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Capti" & _
            "on"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selecte" & _
            "d"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRo" & _
            "w"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" />" & _
            "<Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterB" & _
            "ar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSpli" & _
            "ts><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</Defaul" & _
            "tRecSelWidth><ClientArea>0, 0, 925, 127</ClientArea><PrintPageHeaderStyle parent" & _
            "="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'Label8
            '
            Me.Label8.BackColor = System.Drawing.Color.Transparent
            Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.Black
            Me.Label8.Location = New System.Drawing.Point(4, 7)
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
            'lblDevRepType
            '
            Me.lblDevRepType.BackColor = System.Drawing.Color.Black
            Me.lblDevRepType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblDevRepType.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDevRepType.ForeColor = System.Drawing.Color.Lime
            Me.lblDevRepType.Location = New System.Drawing.Point(480, 160)
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
            Me.lblDateCode.Location = New System.Drawing.Point(848, 160)
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
            Me.lblWrtyStatus.Location = New System.Drawing.Point(640, 160)
            Me.lblWrtyStatus.Name = "lblWrtyStatus"
            Me.lblWrtyStatus.Size = New System.Drawing.Size(192, 32)
            Me.lblWrtyStatus.TabIndex = 134
            Me.lblWrtyStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.lblWrtyStatus.Visible = False
            '
            'btnUpdateFailOther
            '
            Me.btnUpdateFailOther.BackColor = System.Drawing.Color.Green
            Me.btnUpdateFailOther.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnUpdateFailOther.ForeColor = System.Drawing.Color.White
            Me.btnUpdateFailOther.Location = New System.Drawing.Point(704, 480)
            Me.btnUpdateFailOther.Name = "btnUpdateFailOther"
            Me.btnUpdateFailOther.Size = New System.Drawing.Size(184, 40)
            Me.btnUpdateFailOther.TabIndex = 137
            Me.btnUpdateFailOther.Text = "Update Fail Other"
            Me.btnUpdateFailOther.Visible = False
            '
            'syxtriage
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(968, 550)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnUpdateFailOther, Me.lblDevRepType, Me.lblDateCode, Me.lblWrtyStatus, Me.Panel3, Me.btnSave, Me.pnlFailCodes, Me.Panel1, Me.btnFail, Me.btnPass, Me.Panel2, Me.Label3, Me.btnClear})
            Me.Name = "syxtriage"
            Me.Text = "PreTest"
            Me.Panel2.ResumeLayout(False)
            Me.Panel1.ResumeLayout(False)
            CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlFailCodes.ResumeLayout(False)
            CType(Me.cboPFCodes, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboNextLoc, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel3.ResumeLayout(False)
            CType(Me.grdHistory, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '*****************************************************************
        Private Sub syxtriage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim i As Integer = 0
            Dim iCustID As Integer = 0
            Dim dt As DataTable
            Dim strFailUnitPushToList As String = ""

            Try
                i = CheckIfMachineTiedToLine()

                If i = 0 Or Me._icc_id = 0 Then
                    MessageBox.Show("Machine is not associated with any 'Line'. Can't continue.", "Check Machine Mapping", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.Close()
                End If

                '****************************************
                'Load Customer
                '***************************************
                iCustID = Generic.GetCustIDByMachine()
                Me.cboCustomers.DataSource = Nothing
                dt = Generic.GetCustomers(True)
                Misc.PopulateC1DropDownList(Me.cboCustomers, dt, "Cust_Name1", "Cust_ID")
                Me.cboCustomers.SelectedValue = iCustID


                '***************************
                'Hung 11/22/2011 Define Fail Status
                '***************************
                ' dt = Me._objSyx.GetSyxStatusList(3)
                strFailUnitPushToList = Generic.GetNextWorkStationInWFP(_strScreenName, 0, PSS.Data.Buisness.Syx.CUSTOMERID, 1, )
                dt = Me.CreateFailUnitNextLocation(strFailUnitPushToList)
                Misc.PopulateC1DropDownList(Me.cboNextLoc, dt, "Location", "ID")
                Me.cboNextLoc.SelectedValue = 0

                '***************************
                'Define Fail code datatable
                '***************************
                Me._dtFailcodes = New DataTable()
                Buisness.Generic.AddNewColumnToDataTable(Me._dtFailcodes, "DCode_ID", "System.Int32", )
                Buisness.Generic.AddNewColumnToDataTable(Me._dtFailcodes, "DCode_LDesc", "System.String", )
                Buisness.Generic.AddNewColumnToDataTable(Me._dtFailcodes, "tpretest_id", "System.Int32", "0")    '0:Add 1:Delete


                '****************************************
                'Set User Permission for delete record
                '****************************************
                If ApplicationUser.GetPermission("DeletePretestRecord") > 0 Then Me.btnDelete.Visible = True Else Me.btnDelete.Visible = False

                btnSave.Visible = False
                Me.txtFailOther.Text = ""

                Me.txtDeviceSN.Focus()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error in FormLoad")
            Finally
                Generic.DisposeDT(dt)
                Me._booLoadData = False
            End Try
        End Sub

        Private Function CreateFailUnitNextLocation(ByVal strFailUnitPushToList As String) As DataTable
            Dim dt As New DataTable()
            Dim strArr() As String
            Dim i As Integer = 0
            Dim drNewRow As DataRow

            Try
                Buisness.Generic.AddNewColumnToDataTable(dt, "ID", "System.Int32", )
                Buisness.Generic.AddNewColumnToDataTable(dt, "Location", "System.String", )

                drNewRow = dt.NewRow : drNewRow("ID") = 0 : drNewRow("Location") = "--SELECT--"
                dt.Rows.Add(drNewRow) : dt.AcceptChanges()

                strArr = strFailUnitPushToList.Trim.Split("|")
                For i = 0 To strArr.Length - 1
                    If strArr(i).Trim.Length > 0 Then
                        drNewRow = dt.NewRow
                        drNewRow("ID") = i + 1 : drNewRow("Location") = strArr(i).Trim
                        dt.Rows.Add(drNewRow) : dt.AcceptChanges()
                    End If
                Next i

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

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
        Private Sub LoadPFCodes()
            Dim dt As DataTable

            Try
                If Me._iProductID = 0 Then
                    Me.cboPFCodes.DataSource = Nothing
                    Me.cboPFCodes.Text = ""
                    Exit Sub
                End If

                Me.cboPFCodes.DataSource = Nothing
                dt = Me._objPreTest.GetPFCodesComboData(Me._iProductID)

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
                If Me._iProductID = 0 Then Exit Sub

                iArr = Me._objPreTest.GetLoadUserPassFailNumber(Me._iProductID, Me._iWCLocation_ID, Me._iTechID, Me.lblWorkDate.Tag)

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
            Dim iDevice_ID, i, iDeviceCCID As Integer
            Dim strSN, strDevice_ccDesc, strWorkStation, strAcceptLocs As String
            Dim dt1 As DataTable
            Dim booCurrentLocValidation As Boolean = False

            Try
                strSN = "" : strDevice_ccDesc = "" : strWorkStation = "" : strAcceptLocs = ""
                iDevice_ID = 0 : i = 0 : iDeviceCCID = 0

                strSN = Me.txtDeviceSN.Text.Trim
                Me._booUpdateCCIDFlag = False

                If Me.txtDeviceSN.Text.Trim.Length = 0 Then Exit Sub

                If Me._icc_id = 0 Then
                    MessageBox.Show("This machine is not mapped to any 'Cost Center'.", "Pretest", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtDeviceSN.Text = ""
                    Exit Sub
                ElseIf Me.cboCustomers.SelectedValue = 0 Then
                    MessageBox.Show("Please select cGustomer.", "Pretest", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.cboCustomers.Focus()
                    Exit Sub
                End If

                Me.Clear(False)

                If Me._iGrpLineMap_ID = 0 Or Me._iWCLocation_ID = 0 Then
                    MessageBox.Show("Group ID missing. This machine is not mapped to any Group.", "Pretest", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtDeviceSN.Text = strSN
                    Exit Sub
                End If

                'Set Product_ID
                Me._iProductID = objQC.GetDeviceProductType(strSN, Me.cboCustomers.SelectedValue)

                '******************************************
                'Get Device info and model type(Wip down/Non-WipeDown)
                ''******************************************
                dt1 = Me._objPreTest.GetPretestDeviceInfoInWIP(strSN, Me.cboCustomers.SelectedValue, PSS.Data.Buisness.Syx.LOCID, True)

                If dt1.Rows.Count = 1 Then
                    If Not IsDBNull(dt1.Rows(0)("Pallett_ID")) Then Throw New Exception("Device has already assigned to a ship pallet.")
                    '******************************************
                    'Validate current location
                    '******************************************
                    If Misc.ValidateFrStationOfScreenInWorkFlow(Me._strScreenName, dt1.Rows(0)("Workstation").ToString.Trim, Me.cboCustomers.SelectedValue, 0, True) = False Then
                        Me.btnPass.Visible = False : Me.btnFail.Visible = False
                    Else
                        Me.btnPass.Visible = True : Me.btnFail.Visible = True
                    End If

                    '******************************************
                    iDevice_ID = dt1.Rows(0)("Device_ID")
                    Me.LoadPFCodes()
                    Me.LoadPretestHistory(iDevice_ID)
                    Me.LoadUserPassFailNumber()
                    Me.lblManufSN.Text = Me._objSyx.GetSyxManufSN(Me._iDevice_ID)
                    Me.lblProdType.Text = Generic.GetProductDesc(Me._iProductID)
                    Me.lblSN.Text = strSN
                    Me._iDevice_ID = iDevice_ID
                    Me._iInWarranty = dt1.Rows(0)("Device_ManufWrty")
                    Me._iManufID = dt1.Rows(0)("Manuf_ID")
                    Me._iModelID = dt1.Rows(0)("Model_ID")

                    '****************************************************************
                    'Display Warranty status, Manufacture Date code and Repair type
                    '****************************************************************
                    If dt1.Rows(0)("ManufDate").ToString.Trim.Length > 0 Then
                        Me.lblWrtyStatus.Visible = True
                        Me.lblDateCode.Visible = True
                        Me.lblDateCode.Text = dt1.Rows(0)("ManufDate")
                        If dt1.Rows(0)("Device_ManufWrty") Then Me.lblWrtyStatus.Text = "In Warranty" Else Me.lblWrtyStatus.Text = "Out of Warranty"
                    End If
                    '****************************************************************
                    'Not allow to triage again
                    '****************************************************************
                    If Me.grdHistory.RowCount > 0 Then
                        MessageBox.Show("Unit has triage test. Can't process again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.btnPass.Visible = False : Me.btnFail.Visible = False : Exit Sub
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
                        Me.btnPass.BackColor = Color.Red
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
                        If Not IsDBNull(dt1.Rows(0)("Other failure")) Then Me.txtFailOther.Text = dt1.Rows(0)("Other failure")
                        If dt1.Rows.Count > 0 Then Me.btnUpdateFailOther.Visible = True
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
                Me.lblManufSN.Text = ""
                Me.lblDateCode.Text = ""
                Me.lblWrtyStatus.Text = ""
                Me.lblDevRepType.Text = ""
                Me.lblDateCode.Visible = False
                Me.lblWrtyStatus.Visible = False
                Me.lblDevRepType.Visible = False
                Me.grdHistory.DataSource = Nothing
            End If

            Me.cboNextLoc.SelectedValue = 0
            Me.pnlFailCodes.Visible = False
            Me.cboPFCodes.SelectedValue = 0
            Me.lstFailCodes.Items.Clear()
            Me.lstFailCodes.Refresh()
            Me.btnSave.Visible = False
            Me.btnUpdateFailOther.Visible = False
            Me._dtFailcodes.Clear()
            Me._iDevice_ID = 0
            Me._booUpdateCCIDFlag = False
            Me._iInWarranty = 0
            Me._iManufID = 0
            Me._iModelID = 0
            Me._iPretestResult = 0
            Me._iFuncRep = 0
            Me.txtFailOther.Text = ""
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
            btnSave.Visible = False
            Me.btnUpdateFailOther.Visible = False
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
            btnSave.Visible = True

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
            Dim strFailCodes, strNextWrkStation, strStatus As String
            Dim objDevice As Rules.Device

            Try
                i = 0 : iStationFailed = 0
                strFailCodes = "" : strNextWrkStation = "" : strStatus = ""

                If Me._iProductID = 0 Then
                    MsgBox("Please select product.", MsgBoxStyle.Critical, "Load Pretest Codes")
                ElseIf Me._iDevice_ID = 0 Then
                    MsgBox("You must enter a device serial number.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Information")
                    Me.txtDeviceSN.Focus()
                ElseIf Me._iPretestResult = 2 AndAlso (Me.lstFailCodes.Items.Count = 0 Or Me._dtFailcodes.Rows.Count = 0) Then
                    MsgBox("You must select a fail code.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Information")
                    Me.cboPFCodes.Focus()
                ElseIf Me._iManufID = 0 Then
                    MsgBox("Unable to define manufacture.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Information")
                    Me.txtDeviceSN.Focus()
                ElseIf Me._iPretestResult = 2 AndAlso Me.cboNextLoc.SelectedValue = 0 Then
                    MsgBox("You must select next location.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Information")
                    Me.cboNextLoc.SelectAll() : Me.cboNextLoc.Focus()
                ElseIf Me._iPretestResult = 2 AndAlso Me.cboNextLoc.Text.ToUpper = "SCRAP" AndAlso Me._objPreTest.IsNotAllowToScrap(Syx.CUSTOMERID, Me._iProductID) = True Then
                    MsgBox("NOT allowed to scrap this product type.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Information")
                    Me.cboNextLoc.SelectAll() : Me.cboNextLoc.Focus()
                Else

                    If Me._iPretestResult <> 0 Then
                        'REMOVE ALL SERVICES
                        Me.RemoveAllServices()

                        If Me._iPretestResult = 2 Then
                            iStationFailed = 1
                            Me.txtFailOther.Text = Trim(Me.txtFailOther.Text)

                            If Me.cboNextLoc.Text = "AWAP" Then
                                ''*******************************************
                                '' Hung 12/03/2011 COLLECT PART & ACCESSORY if device FAIL and AWAP
                                ''3764 = lcodesdetail-PreTest Screen
                                ''Lan 12/14/2011: don't display collect part when model has no part map to it
                                ''*******************************************
                                'Dim objSyxRec As New PSS.Data.Buisness.SyxReceivingShipping()
                                'If objSyxRec.GetModelAccessories(_iModelID, "2,3").rows.count > 0 Then
                                '    Dim dtAccessories As DataTable
                                '    Dim objAccessoryWind As Gui.SyxCollectAccessories
                                '    Dim booCancelCollectAccessories As Boolean = False

                                '    dtAccessories = New DataTable()
                                '    objAccessoryWind = New Gui.SyxCollectAccessories(ScreenID, Me._iModelID, Me._iDevice_ID)
                                '    objAccessoryWind.ShowDialog()
                                '    If objAccessoryWind._booCancel = True Then
                                '        If MessageBox.Show("Part and accessory selection has been cancel! Are you sure this device have no part or accessory?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                                '            MsgBox("Click on the 'SAVE' button and try again.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Information")
                                '            Exit Sub
                                '        End If
                                '    Else
                                '        dtAccessories = objAccessoryWind._dtSelectAccessories
                                '        If dtAccessories.Rows.Count = 0 AndAlso MessageBox.Show("No part or accessory selected ! Are you sure you this device have no part and accessory?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                                '            MsgBox("Click on the 'SAVE' button and try again.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Information")
                                '            Exit Sub
                                '        End If
                                '    End If
                                'End If
                                'objSyxRec = Nothing
                            ElseIf Me.cboNextLoc.Text.Trim.ToUpper = "SCRAP" Then
                                '*********************************************
                                'BILL scrap
                                '*********************************************
                                Dim iRURBillcodeID As Integer = 0
                                iRURBillcodeID = Me._objSyx.GetServiceBillcodeID(Me._iProductID, "RUR-Scrap")
                                If iRURBillcodeID > 0 Then
                                    If Generic.IsBillcodeMapped(Me._iModelID, iRURBillcodeID) > 0 Then
                                        If Generic.IsBillcodeExisted(Me._iDevice_ID, iRURBillcodeID) = False Then
                                            objDevice = New Rules.Device(Me._iDevice_ID)
                                            objDevice.ScreenID = PSS.Data.Buisness.Syx.ScreenID_PreTest
                                            objDevice.AddPart(iRURBillcodeID)
                                            objDevice.Update()
                                            If Not IsNothing(objDevice) Then
                                                objDevice.Dispose() : objDevice = Nothing
                                            End If
                                        End If
                                    Else
                                        MessageBox.Show("No RUR-Scrap service map.", "information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        Exit Sub : Me.txtDeviceSN.SelectAll()
                                    End If 'chek billcode map
                                Else
                                    MessageBox.Show("Billcode ""RUR-Scrap"" does not exist.", "information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Exit Sub : Me.txtDeviceSN.SelectAll()
                                End If 'check billcode existed
                                '*********************************************
                                strStatus = "Scrap"
                            ElseIf Me.cboNextLoc.Text.Trim.ToUpper = "MISC C" Then
                                '*********************************************
                                'BILL Misc C services billcode
                                '*********************************************
                                Dim iMiscCBillcodeID As Integer = 0
                                iMiscCBillcodeID = Me._objSyx.GetServiceBillcodeID(Me._iProductID, "Misc C")
                                If iMiscCBillcodeID > 0 Then
                                    If Generic.IsBillcodeMapped(Me._iModelID, iMiscCBillcodeID) > 0 Then
                                        If Generic.IsBillcodeExisted(Me._iDevice_ID, iMiscCBillcodeID) = False Then
                                            objDevice = New Rules.Device(Me._iDevice_ID)
                                            objDevice.ScreenID = PSS.Data.Buisness.Syx.ScreenID_PreTest
                                            objDevice.AddPart(iMiscCBillcodeID)
                                            objDevice.Update()
                                            If Not IsNothing(objDevice) Then
                                                objDevice.Dispose() : objDevice = Nothing
                                            End If
                                        End If
                                    Else
                                        MessageBox.Show("No ""Misc C"" service map.", "information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        Exit Sub : Me.txtDeviceSN.SelectAll()
                                    End If 'chek billcode map
                                Else
                                    MessageBox.Show("Billcode ""Misc C"" does not exist.", "information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Exit Sub : Me.txtDeviceSN.SelectAll()
                                End If 'check billcode existed
                                '*********************************************
                                strStatus = "Misc C"
                            End If
                        Else
                            iStationFailed = 0 : Me.txtFailOther.Text = "" : strStatus = "Good"

                            '*********************************************
                            'BILL Refurbish-No part needed
                            '*********************************************
                            If Generic.IsDeviceHadParts(Me._iDevice_ID) = False Then
                                Dim iRefNoPartBillcodeID As Integer = 0
                                iRefNoPartBillcodeID = Me._objSyx.GetServiceBillcodeID(Me._iProductID, "Refurbish - No part needed")
                                If iRefNoPartBillcodeID > 0 Then
                                    If Generic.IsBillcodeMapped(Me._iModelID, iRefNoPartBillcodeID) > 0 Then
                                        If Generic.IsBillcodeExisted(Me._iDevice_ID, iRefNoPartBillcodeID) = False Then
                                            objDevice = New Device(Me._iDevice_ID)
                                            objDevice.ScreenID = PSS.Data.Buisness.Syx.ScreenID_PreTest
                                            objDevice.AddPart(iRefNoPartBillcodeID)
                                            objDevice.Update()
                                            If Not IsNothing(objDevice) Then
                                                objDevice.Dispose() : objDevice = Nothing
                                            End If
                                        End If
                                    Else
                                        MessageBox.Show("No ""Refurbish - No part needed"" service map.", "information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        Exit Sub : Me.txtDeviceSN.SelectAll()
                                    End If 'chek billcode map
                                Else
                                    MessageBox.Show("Billcode ""Refurbish - No part needed"" does not exist.", "information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Exit Sub : Me.txtDeviceSN.SelectAll()
                                End If 'check billcode existed
                            End If 'check if device has part
                            '*********************************************
                        End If

                        '************************************
                        'Define next location/wip bucket
                        '************************************
                        If Me._iPretestResult = 2 Then  'Failed
                            strNextWrkStation = Me.cboNextLoc.Text
                        Else 'Passed
                            If (Me._iProductID = 33 OrElse Me._iProductID = 24 OrElse Me._iProductID = 76 OrElse Me._iProductID = 74) AndAlso Me._objPreTest.HasImageCount(Me._iModelID) = 0 AndAlso Generic.GetWorkStationCount(Me._iMenuCustID, "IMAGE HOLD", Me._iModelID) = 0 Then
                                'Hold for image on any product Note book, Desktop, PC (All In One), PC-Tower
                                strNextWrkStation = "IMAGE HOLD"
                                MessageBox.Show("Image needed for library. Place unit in ""IMAGE HOLD"" location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                strNextWrkStation = Generic.GetNextWorkStationInWFP(Me._strScreenName, 0, Me.cboCustomers.SelectedValue, , )
                            End If
                        End If
                        If strNextWrkStation.Trim.Length = 0 Then Throw New Exception("Next location is missing in in work flow.")
                        Generic.SetTcelloptWorkStationForDevice(strNextWrkStation, Me._iDevice_ID, , , , )
                        '****************************************
                        'Hung 11/22/2011 Update SyxData Status
                        '****************************************
                        Me._objSyx.UpdateSyxStatus(Me._iDevice_ID, strStatus)
                        '****************************************
                        'Move unit to machine mapped CC
                        '****************************************
                        If Me._booUpdateCCIDFlag = True Then
                            objACC = New Data.Production.AssignCostCenter()
                            i = objACC.AssignCostCenterToUnit(Me._iDevice_ID, Me._icc_id, Me._iProductID, strNextWrkStation)
                            If i = 0 Then Throw New Exception("System has failed to assign unit into a work center.")
                        End If
                        '****************************************

                        If Me._objPreTest.UpdatePFData(Me._iDevice_ID, Me._iPretestResult, Me._dtFailcodes, Me._iTechID, System.Net.Dns.GetHostName, Me.lblWorkDate.Tag, Me._iWCLocation_ID, Me._iGrpLineMap_ID, PSS.Core.[Global].ApplicationUser.IDuser, Me.txtFailOther.Text) Then
                            Me.LoadPretestHistory(Me._iDevice_ID)
                            Me.Clear(True)
                            Me.LoadUserPassFailNumber()
                        Else
                            Me.txtDeviceSN.SelectAll()
                        End If
                        '****************************************
                    Else
                        MsgBox("No update data to save.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Information")
                    End If

                    Me.txtDeviceSN.Focus()

                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "SavePretestResult")
            Finally
                objACC = Nothing
            End Try
        End Sub

        Private Sub RemoveAllServices()
            Dim dt As DataTable
            Dim objDevice As Rules.Device
            Dim R1 As DataRow

            Try
                dt = Me._objSyx.GetBilledServiceBillcodeIDs(Me._iDevice_ID)
                If dt.Rows.Count > 0 Then
                    objDevice = New Device(Me._iDevice_ID)
                    objDevice.ScreenID = PSS.Data.Buisness.Syx.ScreenID_PreTest
                    For Each R1 In dt.Rows
                        objDevice.DeletePart(R1("Billcode_ID"))
                    Next R1
                    objDevice.Update()
                End If
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(objDevice) Then
                    objDevice.Dispose() : objDevice = Nothing
                End If
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


        '*****************************************************************
        Private Sub cboCustomers_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCustomers.KeyUp
            If e.KeyCode = Keys.Enter Then
                If Me.cboCustomers.SelectedValue > 0 Then

                    Me.txtDeviceSN.Focus()
                End If
            End If
        End Sub

        '*********************************************************************************************
        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub

        '*********************************************************************************************
        Private Sub btnUpdateFailOther_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateFailOther.Click
            Try
                If Me._iDevice_ID > 0 Then
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    Me._objPreTest.UpdateFialOther(Me._iDevice_ID, Me.txtFailOther.Text.Trim)
                    Me.LoadPretestHistory(Me._iDevice_ID)
                    Me.Clear(True)
                    Me.txtDeviceSN.Focus()
                Else
                    MessageBox.Show("Device ID is missing. Please re-enter serial number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "UpdateFailOther", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '*********************************************************************************************

    End Class
End Namespace

