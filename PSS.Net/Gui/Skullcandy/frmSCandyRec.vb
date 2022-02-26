Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui
    Public Class frmSCandyRec
        Inherits System.Windows.Forms.Form

        Private _iMenuCustID As Integer = 0
        'Private _strScreenName As String = ""
        Private _iEndUser As Integer = 0
        Private _iScrap As Integer = -1
        Private _iDateCode As Integer = -1
        Private _iAudioTest As Integer = -1
        Private _booLoadData As Boolean = False
        Private _objSkullcandy As Skullcandy
        Private _objSkullcandyRec As SkullcandyRec
        Private _iReceivedDeviceIDs As New ArrayList()
        Private _objPreTest As Data.Buisness.PreTest
        Private _iQCResult As Integer = 0
        Private _dtFailcodes As DataTable

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iCustID As Integer, ByVal strScreenName As String, ByVal iEndUser As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _iMenuCustID = iCustID
            _objSkullcandyRec = New SkullcandyRec()
            Me.lblTitle.Text = strScreenName
            _iEndUser = iEndUser
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
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents btnCloseWorkOrder As System.Windows.Forms.Button
        Friend WithEvents rbtPass As System.Windows.Forms.RadioButton
        Friend WithEvents rbtFail As System.Windows.Forms.RadioButton
        Friend WithEvents grpRMA As System.Windows.Forms.GroupBox
        Friend WithEvents chkRMA As System.Windows.Forms.CheckBox
        Friend WithEvents lblSN As System.Windows.Forms.Label
        Friend WithEvents txtSN As System.Windows.Forms.TextBox
        Friend WithEvents lblRMA As System.Windows.Forms.Label
        Friend WithEvents txtRMA As System.Windows.Forms.TextBox
        Friend WithEvents grpPretest As System.Windows.Forms.GroupBox
        Friend WithEvents GrpMismatch As System.Windows.Forms.GroupBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents pnlCustWO As System.Windows.Forms.Panel
        Friend WithEvents lblWorkOrder As System.Windows.Forms.Label
        Friend WithEvents cboWorkorder As C1.Win.C1List.C1Combo
        Friend WithEvents lblCustomer As System.Windows.Forms.Label
        Friend WithEvents cboCustomer As C1.Win.C1List.C1Combo
        Friend WithEvents pnlFamilyModel As System.Windows.Forms.Panel
        Friend WithEvents lblScrapYN As System.Windows.Forms.Label
        Friend WithEvents chkNoModelRequired As System.Windows.Forms.CheckBox
        Friend WithEvents lblModels As System.Windows.Forms.Label
        Friend WithEvents cboModels As C1.Win.C1List.C1Combo
        Friend WithEvents lblFamily As System.Windows.Forms.Label
        Friend WithEvents cboFamily As C1.Win.C1List.C1Combo
        Friend WithEvents lblDateCode As System.Windows.Forms.Label
        Friend WithEvents txtDateCode As System.Windows.Forms.TextBox
        Friend WithEvents chkMismatchReceiveEDI As System.Windows.Forms.CheckBox
        Friend WithEvents pnlDateCode As System.Windows.Forms.Panel
        Friend WithEvents cboModelsMismatchReceiveEDI As C1.Win.C1List.C1Combo
        Friend WithEvents cboFamilyMismatchReceiveEDI As C1.Win.C1List.C1Combo
        Friend WithEvents cboPFCodes As C1.Win.C1List.C1Combo
        Friend WithEvents btnLanUseOnly As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSCandyRec))
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.btnCloseWorkOrder = New System.Windows.Forms.Button()
            Me.grpPretest = New System.Windows.Forms.GroupBox()
            Me.cboPFCodes = New C1.Win.C1List.C1Combo()
            Me.rbtFail = New System.Windows.Forms.RadioButton()
            Me.rbtPass = New System.Windows.Forms.RadioButton()
            Me.grpRMA = New System.Windows.Forms.GroupBox()
            Me.chkRMA = New System.Windows.Forms.CheckBox()
            Me.lblSN = New System.Windows.Forms.Label()
            Me.txtSN = New System.Windows.Forms.TextBox()
            Me.lblRMA = New System.Windows.Forms.Label()
            Me.txtRMA = New System.Windows.Forms.TextBox()
            Me.GrpMismatch = New System.Windows.Forms.GroupBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.cboModelsMismatchReceiveEDI = New C1.Win.C1List.C1Combo()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.cboFamilyMismatchReceiveEDI = New C1.Win.C1List.C1Combo()
            Me.chkMismatchReceiveEDI = New System.Windows.Forms.CheckBox()
            Me.pnlCustWO = New System.Windows.Forms.Panel()
            Me.lblWorkOrder = New System.Windows.Forms.Label()
            Me.cboWorkorder = New C1.Win.C1List.C1Combo()
            Me.lblCustomer = New System.Windows.Forms.Label()
            Me.cboCustomer = New C1.Win.C1List.C1Combo()
            Me.pnlFamilyModel = New System.Windows.Forms.Panel()
            Me.lblScrapYN = New System.Windows.Forms.Label()
            Me.chkNoModelRequired = New System.Windows.Forms.CheckBox()
            Me.lblModels = New System.Windows.Forms.Label()
            Me.cboModels = New C1.Win.C1List.C1Combo()
            Me.lblFamily = New System.Windows.Forms.Label()
            Me.cboFamily = New C1.Win.C1List.C1Combo()
            Me.pnlDateCode = New System.Windows.Forms.Panel()
            Me.lblDateCode = New System.Windows.Forms.Label()
            Me.txtDateCode = New System.Windows.Forms.TextBox()
            Me.btnLanUseOnly = New System.Windows.Forms.Button()
            Me.grpPretest.SuspendLayout()
            CType(Me.cboPFCodes, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grpRMA.SuspendLayout()
            Me.GrpMismatch.SuspendLayout()
            CType(Me.cboModelsMismatchReceiveEDI, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboFamilyMismatchReceiveEDI, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlCustWO.SuspendLayout()
            CType(Me.cboWorkorder, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlFamilyModel.SuspendLayout()
            CType(Me.cboModels, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboFamily, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlDateCode.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTitle.ForeColor = System.Drawing.Color.Navy
            Me.lblTitle.Location = New System.Drawing.Point(136, 0)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(464, 40)
            Me.lblTitle.TabIndex = 43
            Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnCloseWorkOrder
            '
            Me.btnCloseWorkOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCloseWorkOrder.ForeColor = System.Drawing.Color.Red
            Me.btnCloseWorkOrder.Location = New System.Drawing.Point(640, 80)
            Me.btnCloseWorkOrder.Name = "btnCloseWorkOrder"
            Me.btnCloseWorkOrder.Size = New System.Drawing.Size(96, 40)
            Me.btnCloseWorkOrder.TabIndex = 15
            Me.btnCloseWorkOrder.Text = "Close WorkOrder"
            Me.btnCloseWorkOrder.Visible = False
            '
            'grpPretest
            '
            Me.grpPretest.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboPFCodes, Me.rbtFail, Me.rbtPass})
            Me.grpPretest.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.grpPretest.Location = New System.Drawing.Point(80, 272)
            Me.grpPretest.Name = "grpPretest"
            Me.grpPretest.Size = New System.Drawing.Size(344, 80)
            Me.grpPretest.TabIndex = 47
            Me.grpPretest.TabStop = False
            Me.grpPretest.Text = "Pretest"
            '
            'cboPFCodes
            '
            Me.cboPFCodes.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboPFCodes.AutoCompletion = True
            Me.cboPFCodes.AutoDropDown = True
            Me.cboPFCodes.AutoSelect = True
            Me.cboPFCodes.Caption = ""
            Me.cboPFCodes.CaptionHeight = 17
            Me.cboPFCodes.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboPFCodes.ColumnCaptionHeight = 17
            Me.cboPFCodes.ColumnFooterHeight = 17
            Me.cboPFCodes.ColumnHeaders = False
            Me.cboPFCodes.ContentHeight = 15
            Me.cboPFCodes.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboPFCodes.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboPFCodes.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboPFCodes.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboPFCodes.EditorHeight = 15
            Me.cboPFCodes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboPFCodes.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboPFCodes.ItemHeight = 15
            Me.cboPFCodes.Location = New System.Drawing.Point(56, 48)
            Me.cboPFCodes.MatchEntryTimeout = CType(2000, Long)
            Me.cboPFCodes.MaxDropDownItems = CType(10, Short)
            Me.cboPFCodes.MaxLength = 32767
            Me.cboPFCodes.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboPFCodes.Name = "cboPFCodes"
            Me.cboPFCodes.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboPFCodes.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboPFCodes.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboPFCodes.Size = New System.Drawing.Size(280, 21)
            Me.cboPFCodes.TabIndex = 8
            Me.cboPFCodes.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'rbtFail
            '
            Me.rbtFail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rbtFail.Location = New System.Drawing.Point(216, 16)
            Me.rbtFail.Name = "rbtFail"
            Me.rbtFail.Size = New System.Drawing.Size(56, 32)
            Me.rbtFail.TabIndex = 1
            Me.rbtFail.Text = "Fail"
            '
            'rbtPass
            '
            Me.rbtPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rbtPass.Location = New System.Drawing.Point(56, 16)
            Me.rbtPass.Name = "rbtPass"
            Me.rbtPass.Size = New System.Drawing.Size(56, 32)
            Me.rbtPass.TabIndex = 0
            Me.rbtPass.Text = "Pass"
            '
            'grpRMA
            '
            Me.grpRMA.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkRMA, Me.lblSN, Me.txtSN, Me.lblRMA, Me.txtRMA})
            Me.grpRMA.Location = New System.Drawing.Point(80, 352)
            Me.grpRMA.Name = "grpRMA"
            Me.grpRMA.Size = New System.Drawing.Size(344, 104)
            Me.grpRMA.TabIndex = 49
            Me.grpRMA.TabStop = False
            '
            'chkRMA
            '
            Me.chkRMA.ForeColor = System.Drawing.Color.Navy
            Me.chkRMA.Location = New System.Drawing.Point(56, 16)
            Me.chkRMA.Name = "chkRMA"
            Me.chkRMA.Size = New System.Drawing.Size(184, 24)
            Me.chkRMA.TabIndex = 21
            Me.chkRMA.TabStop = False
            Me.chkRMA.Text = "Check if RMA same as SN"
            '
            'lblSN
            '
            Me.lblSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSN.Location = New System.Drawing.Point(16, 72)
            Me.lblSN.Name = "lblSN"
            Me.lblSN.Size = New System.Drawing.Size(40, 24)
            Me.lblSN.TabIndex = 20
            Me.lblSN.Text = "SN:"
            Me.lblSN.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'txtSN
            '
            Me.txtSN.Location = New System.Drawing.Point(56, 72)
            Me.txtSN.Name = "txtSN"
            Me.txtSN.Size = New System.Drawing.Size(280, 20)
            Me.txtSN.TabIndex = 10
            Me.txtSN.Text = ""
            '
            'lblRMA
            '
            Me.lblRMA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRMA.Location = New System.Drawing.Point(16, 40)
            Me.lblRMA.Name = "lblRMA"
            Me.lblRMA.Size = New System.Drawing.Size(40, 24)
            Me.lblRMA.TabIndex = 17
            Me.lblRMA.Text = "RMA:"
            Me.lblRMA.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'txtRMA
            '
            Me.txtRMA.Location = New System.Drawing.Point(56, 40)
            Me.txtRMA.Name = "txtRMA"
            Me.txtRMA.Size = New System.Drawing.Size(280, 20)
            Me.txtRMA.TabIndex = 9
            Me.txtRMA.Text = ""
            '
            'GrpMismatch
            '
            Me.GrpMismatch.BackColor = System.Drawing.Color.FromArgb(CType(205, Byte), CType(205, Byte), CType(223, Byte))
            Me.GrpMismatch.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label2, Me.cboModelsMismatchReceiveEDI, Me.Label3, Me.cboFamilyMismatchReceiveEDI})
            Me.GrpMismatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.255!, System.Drawing.FontStyle.Bold)
            Me.GrpMismatch.Location = New System.Drawing.Point(80, 456)
            Me.GrpMismatch.Name = "GrpMismatch"
            Me.GrpMismatch.Size = New System.Drawing.Size(344, 80)
            Me.GrpMismatch.TabIndex = 50
            Me.GrpMismatch.TabStop = False
            Me.GrpMismatch.Text = "EDI"
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.Location = New System.Drawing.Point(16, 48)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(40, 24)
            Me.Label2.TabIndex = 13
            Me.Label2.Text = "Model:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'cboModelsMismatchReceiveEDI
            '
            Me.cboModelsMismatchReceiveEDI.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboModelsMismatchReceiveEDI.AutoCompletion = True
            Me.cboModelsMismatchReceiveEDI.AutoDropDown = True
            Me.cboModelsMismatchReceiveEDI.AutoSelect = True
            Me.cboModelsMismatchReceiveEDI.Caption = ""
            Me.cboModelsMismatchReceiveEDI.CaptionHeight = 17
            Me.cboModelsMismatchReceiveEDI.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboModelsMismatchReceiveEDI.ColumnCaptionHeight = 17
            Me.cboModelsMismatchReceiveEDI.ColumnFooterHeight = 17
            Me.cboModelsMismatchReceiveEDI.ColumnHeaders = False
            Me.cboModelsMismatchReceiveEDI.ContentHeight = 15
            Me.cboModelsMismatchReceiveEDI.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboModelsMismatchReceiveEDI.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboModelsMismatchReceiveEDI.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboModelsMismatchReceiveEDI.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboModelsMismatchReceiveEDI.EditorHeight = 15
            Me.cboModelsMismatchReceiveEDI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboModelsMismatchReceiveEDI.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboModelsMismatchReceiveEDI.ItemHeight = 15
            Me.cboModelsMismatchReceiveEDI.Location = New System.Drawing.Point(56, 48)
            Me.cboModelsMismatchReceiveEDI.MatchEntryTimeout = CType(2000, Long)
            Me.cboModelsMismatchReceiveEDI.MaxDropDownItems = CType(10, Short)
            Me.cboModelsMismatchReceiveEDI.MaxLength = 32767
            Me.cboModelsMismatchReceiveEDI.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModelsMismatchReceiveEDI.Name = "cboModelsMismatchReceiveEDI"
            Me.cboModelsMismatchReceiveEDI.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModelsMismatchReceiveEDI.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModelsMismatchReceiveEDI.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModelsMismatchReceiveEDI.Size = New System.Drawing.Size(280, 21)
            Me.cboModelsMismatchReceiveEDI.TabIndex = 6
            Me.cboModelsMismatchReceiveEDI.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.Location = New System.Drawing.Point(8, 20)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(48, 24)
            Me.Label3.TabIndex = 11
            Me.Label3.Text = "Family:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'cboFamilyMismatchReceiveEDI
            '
            Me.cboFamilyMismatchReceiveEDI.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboFamilyMismatchReceiveEDI.AutoCompletion = True
            Me.cboFamilyMismatchReceiveEDI.AutoDropDown = True
            Me.cboFamilyMismatchReceiveEDI.AutoSelect = True
            Me.cboFamilyMismatchReceiveEDI.Caption = ""
            Me.cboFamilyMismatchReceiveEDI.CaptionHeight = 17
            Me.cboFamilyMismatchReceiveEDI.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboFamilyMismatchReceiveEDI.ColumnCaptionHeight = 17
            Me.cboFamilyMismatchReceiveEDI.ColumnFooterHeight = 17
            Me.cboFamilyMismatchReceiveEDI.ColumnHeaders = False
            Me.cboFamilyMismatchReceiveEDI.ContentHeight = 15
            Me.cboFamilyMismatchReceiveEDI.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboFamilyMismatchReceiveEDI.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboFamilyMismatchReceiveEDI.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboFamilyMismatchReceiveEDI.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboFamilyMismatchReceiveEDI.EditorHeight = 15
            Me.cboFamilyMismatchReceiveEDI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboFamilyMismatchReceiveEDI.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboFamilyMismatchReceiveEDI.ItemHeight = 15
            Me.cboFamilyMismatchReceiveEDI.Location = New System.Drawing.Point(56, 20)
            Me.cboFamilyMismatchReceiveEDI.MatchEntryTimeout = CType(2000, Long)
            Me.cboFamilyMismatchReceiveEDI.MaxDropDownItems = CType(10, Short)
            Me.cboFamilyMismatchReceiveEDI.MaxLength = 32767
            Me.cboFamilyMismatchReceiveEDI.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboFamilyMismatchReceiveEDI.Name = "cboFamilyMismatchReceiveEDI"
            Me.cboFamilyMismatchReceiveEDI.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboFamilyMismatchReceiveEDI.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboFamilyMismatchReceiveEDI.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboFamilyMismatchReceiveEDI.Size = New System.Drawing.Size(280, 21)
            Me.cboFamilyMismatchReceiveEDI.TabIndex = 5
            Me.cboFamilyMismatchReceiveEDI.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:HotTrack;}Style3{}Inactive{ForeColor:InactiveCaptionText;Bac" & _
            "kColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{F" & _
            "oreColor:HighlightText;BackColor:Highlight;}Style9{AlignHorz:Near;}OddRow{}Recor" & _
            "dSelector{AlignImage:Center;}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1" & _
            ", 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{}Style11{}Sty" & _
            "le1{}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" N" & _
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
            'chkMismatchReceiveEDI
            '
            Me.chkMismatchReceiveEDI.ForeColor = System.Drawing.Color.Navy
            Me.chkMismatchReceiveEDI.Location = New System.Drawing.Point(136, 216)
            Me.chkMismatchReceiveEDI.Name = "chkMismatchReceiveEDI"
            Me.chkMismatchReceiveEDI.Size = New System.Drawing.Size(280, 24)
            Me.chkMismatchReceiveEDI.TabIndex = 51
            Me.chkMismatchReceiveEDI.TabStop = False
            Me.chkMismatchReceiveEDI.Text = "Check if mismatch of receiving unit with EDI "
            '
            'pnlCustWO
            '
            Me.pnlCustWO.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblWorkOrder, Me.cboWorkorder, Me.lblCustomer, Me.cboCustomer})
            Me.pnlCustWO.Location = New System.Drawing.Point(40, 48)
            Me.pnlCustWO.Name = "pnlCustWO"
            Me.pnlCustWO.Size = New System.Drawing.Size(560, 72)
            Me.pnlCustWO.TabIndex = 52
            '
            'lblWorkOrder
            '
            Me.lblWorkOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWorkOrder.Location = New System.Drawing.Point(8, 48)
            Me.lblWorkOrder.Name = "lblWorkOrder"
            Me.lblWorkOrder.Size = New System.Drawing.Size(88, 24)
            Me.lblWorkOrder.TabIndex = 50
            Me.lblWorkOrder.Text = "Work Order:"
            Me.lblWorkOrder.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'cboWorkorder
            '
            Me.cboWorkorder.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboWorkorder.AutoCompletion = True
            Me.cboWorkorder.AutoDropDown = True
            Me.cboWorkorder.AutoSelect = True
            Me.cboWorkorder.Caption = ""
            Me.cboWorkorder.CaptionHeight = 17
            Me.cboWorkorder.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboWorkorder.ColumnCaptionHeight = 17
            Me.cboWorkorder.ColumnFooterHeight = 17
            Me.cboWorkorder.ColumnHeaders = False
            Me.cboWorkorder.ContentHeight = 15
            Me.cboWorkorder.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboWorkorder.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboWorkorder.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboWorkorder.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboWorkorder.EditorHeight = 15
            Me.cboWorkorder.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboWorkorder.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.cboWorkorder.ItemHeight = 15
            Me.cboWorkorder.Location = New System.Drawing.Point(96, 48)
            Me.cboWorkorder.MatchEntryTimeout = CType(2000, Long)
            Me.cboWorkorder.MaxDropDownItems = CType(10, Short)
            Me.cboWorkorder.MaxLength = 32767
            Me.cboWorkorder.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboWorkorder.Name = "cboWorkorder"
            Me.cboWorkorder.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboWorkorder.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboWorkorder.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboWorkorder.Size = New System.Drawing.Size(280, 21)
            Me.cboWorkorder.TabIndex = 2
            Me.cboWorkorder.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:HotTrack;}Style3{}Inactive{ForeColor:InactiveCaptionText;Bac" & _
            "kColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{F" & _
            "oreColor:HighlightText;BackColor:Highlight;}Style9{AlignHorz:Near;}OddRow{}Recor" & _
            "dSelector{AlignImage:Center;}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1" & _
            ", 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{}Style11{}Sty" & _
            "le1{}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" N" & _
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
            'lblCustomer
            '
            Me.lblCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCustomer.Location = New System.Drawing.Point(32, 8)
            Me.lblCustomer.Name = "lblCustomer"
            Me.lblCustomer.Size = New System.Drawing.Size(64, 24)
            Me.lblCustomer.TabIndex = 48
            Me.lblCustomer.Text = "Customer:"
            Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.TopRight
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
            Me.cboCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCustomer.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.cboCustomer.ItemHeight = 15
            Me.cboCustomer.Location = New System.Drawing.Point(96, 8)
            Me.cboCustomer.MatchEntryTimeout = CType(2000, Long)
            Me.cboCustomer.MaxDropDownItems = CType(10, Short)
            Me.cboCustomer.MaxLength = 32767
            Me.cboCustomer.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCustomer.Name = "cboCustomer"
            Me.cboCustomer.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCustomer.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCustomer.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCustomer.Size = New System.Drawing.Size(280, 21)
            Me.cboCustomer.TabIndex = 1
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
            'pnlFamilyModel
            '
            Me.pnlFamilyModel.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblScrapYN, Me.chkNoModelRequired, Me.lblModels, Me.cboModels, Me.lblFamily, Me.cboFamily})
            Me.pnlFamilyModel.Location = New System.Drawing.Point(40, 120)
            Me.pnlFamilyModel.Name = "pnlFamilyModel"
            Me.pnlFamilyModel.Size = New System.Drawing.Size(560, 88)
            Me.pnlFamilyModel.TabIndex = 53
            '
            'lblScrapYN
            '
            Me.lblScrapYN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblScrapYN.Font = New System.Drawing.Font("Arial Black", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblScrapYN.Location = New System.Drawing.Point(384, 24)
            Me.lblScrapYN.Name = "lblScrapYN"
            Me.lblScrapYN.Size = New System.Drawing.Size(96, 34)
            Me.lblScrapYN.TabIndex = 54
            Me.lblScrapYN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'chkNoModelRequired
            '
            Me.chkNoModelRequired.ForeColor = System.Drawing.Color.Navy
            Me.chkNoModelRequired.Location = New System.Drawing.Point(96, 8)
            Me.chkNoModelRequired.Name = "chkNoModelRequired"
            Me.chkNoModelRequired.Size = New System.Drawing.Size(208, 24)
            Me.chkNoModelRequired.TabIndex = 53
            Me.chkNoModelRequired.TabStop = False
            Me.chkNoModelRequired.Text = "Check if no model required"
            '
            'lblModels
            '
            Me.lblModels.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModels.Location = New System.Drawing.Point(0, 64)
            Me.lblModels.Name = "lblModels"
            Me.lblModels.Size = New System.Drawing.Size(96, 24)
            Me.lblModels.TabIndex = 52
            Me.lblModels.Text = "Receive Model:"
            Me.lblModels.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'cboModels
            '
            Me.cboModels.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboModels.AutoCompletion = True
            Me.cboModels.AutoDropDown = True
            Me.cboModels.AutoSelect = True
            Me.cboModels.Caption = ""
            Me.cboModels.CaptionHeight = 17
            Me.cboModels.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboModels.ColumnCaptionHeight = 17
            Me.cboModels.ColumnFooterHeight = 17
            Me.cboModels.ColumnHeaders = False
            Me.cboModels.ContentHeight = 15
            Me.cboModels.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboModels.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboModels.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboModels.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboModels.EditorHeight = 15
            Me.cboModels.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboModels.Images.Add(CType(resources.GetObject("resource.Images5"), System.Drawing.Bitmap))
            Me.cboModels.ItemHeight = 15
            Me.cboModels.Location = New System.Drawing.Point(96, 64)
            Me.cboModels.MatchEntryTimeout = CType(2000, Long)
            Me.cboModels.MaxDropDownItems = CType(10, Short)
            Me.cboModels.MaxLength = 32767
            Me.cboModels.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModels.Name = "cboModels"
            Me.cboModels.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModels.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModels.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModels.Size = New System.Drawing.Size(280, 21)
            Me.cboModels.TabIndex = 4
            Me.cboModels.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'lblFamily
            '
            Me.lblFamily.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblFamily.Location = New System.Drawing.Point(8, 32)
            Me.lblFamily.Name = "lblFamily"
            Me.lblFamily.Size = New System.Drawing.Size(88, 24)
            Me.lblFamily.TabIndex = 50
            Me.lblFamily.Text = "Receive Family:"
            Me.lblFamily.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'cboFamily
            '
            Me.cboFamily.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboFamily.AutoCompletion = True
            Me.cboFamily.AutoDropDown = True
            Me.cboFamily.AutoSelect = True
            Me.cboFamily.Caption = ""
            Me.cboFamily.CaptionHeight = 17
            Me.cboFamily.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboFamily.ColumnCaptionHeight = 17
            Me.cboFamily.ColumnFooterHeight = 17
            Me.cboFamily.ColumnHeaders = False
            Me.cboFamily.ContentHeight = 15
            Me.cboFamily.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboFamily.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboFamily.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboFamily.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboFamily.EditorHeight = 15
            Me.cboFamily.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboFamily.Images.Add(CType(resources.GetObject("resource.Images6"), System.Drawing.Bitmap))
            Me.cboFamily.ItemHeight = 15
            Me.cboFamily.Location = New System.Drawing.Point(96, 32)
            Me.cboFamily.MatchEntryTimeout = CType(2000, Long)
            Me.cboFamily.MaxDropDownItems = CType(10, Short)
            Me.cboFamily.MaxLength = 32767
            Me.cboFamily.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboFamily.Name = "cboFamily"
            Me.cboFamily.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboFamily.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboFamily.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboFamily.Size = New System.Drawing.Size(280, 21)
            Me.cboFamily.TabIndex = 3
            Me.cboFamily.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:HotTrack;}Style3{}Inactive{ForeColor:InactiveCaptionText;Bac" & _
            "kColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{F" & _
            "oreColor:HighlightText;BackColor:Highlight;}Style9{AlignHorz:Near;}OddRow{}Recor" & _
            "dSelector{AlignImage:Center;}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1" & _
            ", 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{}Style11{}Sty" & _
            "le1{}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" N" & _
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
            'pnlDateCode
            '
            Me.pnlDateCode.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblDateCode, Me.txtDateCode})
            Me.pnlDateCode.Location = New System.Drawing.Point(40, 240)
            Me.pnlDateCode.Name = "pnlDateCode"
            Me.pnlDateCode.Size = New System.Drawing.Size(560, 24)
            Me.pnlDateCode.TabIndex = 54
            '
            'lblDateCode
            '
            Me.lblDateCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDateCode.Location = New System.Drawing.Point(24, 0)
            Me.lblDateCode.Name = "lblDateCode"
            Me.lblDateCode.Size = New System.Drawing.Size(72, 24)
            Me.lblDateCode.TabIndex = 13
            Me.lblDateCode.Text = "Date Code:"
            Me.lblDateCode.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'txtDateCode
            '
            Me.txtDateCode.Location = New System.Drawing.Point(96, 0)
            Me.txtDateCode.Name = "txtDateCode"
            Me.txtDateCode.Size = New System.Drawing.Size(280, 20)
            Me.txtDateCode.TabIndex = 7
            Me.txtDateCode.Text = ""
            '
            'btnLanUseOnly
            '
            Me.btnLanUseOnly.BackColor = System.Drawing.Color.Red
            Me.btnLanUseOnly.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnLanUseOnly.ForeColor = System.Drawing.Color.White
            Me.btnLanUseOnly.Location = New System.Drawing.Point(656, 392)
            Me.btnLanUseOnly.Name = "btnLanUseOnly"
            Me.btnLanUseOnly.Size = New System.Drawing.Size(96, 40)
            Me.btnLanUseOnly.TabIndex = 55
            Me.btnLanUseOnly.Text = "Lan Use Only"
            Me.btnLanUseOnly.Visible = False
            '
            'frmSCandyRec
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.FromArgb(CType(205, Byte), CType(205, Byte), CType(223, Byte))
            Me.ClientSize = New System.Drawing.Size(768, 614)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnLanUseOnly, Me.pnlDateCode, Me.pnlFamilyModel, Me.pnlCustWO, Me.chkMismatchReceiveEDI, Me.GrpMismatch, Me.grpRMA, Me.grpPretest, Me.btnCloseWorkOrder, Me.lblTitle})
            Me.Name = "frmSCandyRec"
            Me.Text = "frmSCandyRec"
            Me.grpPretest.ResumeLayout(False)
            CType(Me.cboPFCodes, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grpRMA.ResumeLayout(False)
            Me.GrpMismatch.ResumeLayout(False)
            CType(Me.cboModelsMismatchReceiveEDI, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboFamilyMismatchReceiveEDI, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlCustWO.ResumeLayout(False)
            CType(Me.cboWorkorder, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlFamilyModel.ResumeLayout(False)
            CType(Me.cboModels, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboFamily, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlDateCode.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        '***************************************************************************************
        Private Sub frmSCandyRec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable

            Try
                'Me.btnLanUseOnly.Visible = True

                PSS.Core.Highlight.SetHighLight(Me)
                ' Me.lblTitle.Text = "SKULLCANDY - " & _strScreenName

                'LoadOpenRecWorkorder()

                _booLoadData = True

                'Load customer
                _objSkullcandy = New Skullcandy()
                dt = _objSkullcandy.GetCustomer(_iMenuCustID)
                If dt.Rows.Count > 0 Then
                    Misc.PopulateC1DropDownList(Me.cboCustomer, dt, "Cust_name1", "cust_ID")
                    Me.cboCustomer.SelectedValue = Me._iMenuCustID
                    Me.cboCustomer.Enabled = False
                    ' Me.cboCustomer.ReadOnly = True
                Else
                    MessageBox.Show("No customer!") : Exit Sub
                End If

                'Load WorkOrder
                dt = _objSkullcandy.GetWorkOrder(_objSkullcandy.LOCID, _iEndUser)
                If dt.Rows.Count > 0 Then
                    Misc.PopulateC1DropDownList(Me.cboWorkorder, dt, "WO_CustWO", "WO_ID")
                    Me.cboWorkorder.SelectedIndex = 0 '.SelectedValue = 0
                Else
                    MessageBox.Show("No Workorder!") : Exit Sub
                End If

                'Load Family
                'Load models
                'LoadModels()

                Me.chkNoModelRequired.Checked = True
                Me.chkMismatchReceiveEDI.Checked = True : Me.chkMismatchReceiveEDI.Checked = False
                Me.cboPFCodes.Visible = False

                SetModelDisplay()

                LoadPFCodes()

                Me.txtDateCode.Focus()
                'Load device condition
                'dt = Generic.GetConditionDefinitionForRecvDevice(True)
                'Misc.PopulateC1DropDownList(Me.cboDevCon, dt, "DCode_LDesc", "DCode_ID")
                'Me.cboDevCon.SelectedValue = 0

                'Load device condition
                'Dim strNextStation As String = Generic.GetNextWorkStationInWFP(Me._strScreenName, 0, NI.CUSTOMERID, , )
                'dt = Generic.BuildDTWithAutoIncrementID(strNextStation.Split("|"), True)
                'Misc.PopulateC1DropDownList(Me.cboWipNextLoc, dt, "Desc", "ID")
                'If dt.Rows.Count = 2 Then
                '    Me.cboWipNextLoc.SelectedValue = 1 : Me.cboWipNextLoc.Enabled = False
                'End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt) : _booLoadData = False
            End Try

        End Sub

        '***************************************************************************************
        Private Sub UpdateScrapDateCodeYN()  '(ByRef ctrlCbo As C1.Win.C1List.C1Combo)
            Try

                If _iMenuCustID > 0 AndAlso Me.cboFamily.SelectedValue > 0 Then

                    _iScrap = CInt(Me.cboFamily.DataSource.Table.Select("ModelFamiliesID =" & Me.cboFamily.SelectedValue)(0)("ScrapUponRec"))
                    If CInt(Me.cboFamily.DataSource.Table.Select("ModelFamiliesID =" & Me.cboFamily.SelectedValue)(0)("CollectDateCodeInternal")) = 1 OrElse CInt(Me.cboFamily.DataSource.Table.Select("ModelFamiliesID =" & Me.cboFamily.SelectedValue)(0)("CollectDateCodeExternal")) = 1 Then
                        _iDateCode = 1
                    Else
                        _iDateCode = 0
                    End If
                    _iAudioTest = CInt(Me.cboFamily.DataSource.Table.Select("ModelFamiliesID =" & Me.cboFamily.SelectedValue)(0)("AudioTest"))

                    If _iScrap = 1 Then
                        Me.lblScrapYN.Text = "SCRAP"
                        Me.lblScrapYN.ForeColor = Color.Red
                    ElseIf _iScrap = 0 Then
                        Me.lblScrapYN.Text = "HOLD" 'Good one
                        Me.lblScrapYN.ForeColor = Color.Blue
                    Else
                        Me.lblScrapYN.Text = "Unsure" 'Exception
                        Me.lblScrapYN.ForeColor = Color.Yellow
                    End If

                    If _iDateCode = 1 Then
                        Me.txtDateCode.BackColor = Color.White
                        Me.txtDateCode.Enabled = True
                    Else
                        Me.txtDateCode.BackColor = Me.BackColor
                        Me.txtDateCode.Enabled = False
                    End If

                    UpdatePretestAndRMADisplay()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "UpdateScrapDateCodeYN", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub

        '***************************************************************************************
        Private Sub UpdatePretestAndRMADisplay()
            If _iScrap = 1 Then
                Me.grpRMA.Top = Me.grpPretest.Top
                Me.grpPretest.Visible = False
            Else
                Me.grpRMA.Top = Me.grpPretest.Top + Me.grpPretest.Height + 8
                Me.grpPretest.Visible = True
            End If
        End Sub

        '***************************************************************************************
        Private Sub SetModelDisplay()
            Try

                If Me.chkNoModelRequired.Checked Then
                    Me.cboModels.Visible = False '.Enabled = False '.Visible = False
                    Me.lblModels.Visible = False '.Enabled = False '.Visible = False
                Else
                    Me.cboModels.Visible = True '.Enabled = True '.Visible = True
                    Me.lblModels.Visible = True '.Enabled = True '.Visible = True
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "SetModelDisplay", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub

        '***************************************************************************************
        Private Sub chkRMA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRMA.CheckedChanged
            If Me.chkRMA.Checked Then
                Do_Checkbox_Checked()
            Else
                Do_Checkbox_UnChecked()
            End If
        End Sub

        '***************************************************************************************
        Private Sub Do_Checkbox_Checked()
            Try
                Me.txtRMA.Text = "" : Me.txtRMA.ReadOnly = True
                Me.txtSN.Text = "" : Me.txtSN.ReadOnly = False : Me.txtSN.Focus()
            Catch ex As Exception
                MessageBox.Show("Do_Checkbox_Checked: " & ex.ToString)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub Do_Checkbox_UnChecked()
            Try
                Me.txtSN.Text = "" : Me.txtSN.ReadOnly = False
                Me.txtRMA.Text = "" : Me.txtRMA.ReadOnly = False : Me.txtRMA.Focus()
            Catch ex As Exception
                MessageBox.Show("Do_Checkbox_Checked: " & ex.ToString)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub LoadFamilies()
            'Load Family
            Dim dt As DataTable
            Try
                dt = _objSkullcandy.GetFamily(_iMenuCustID, Me.chkNoModelRequired.Checked)
                If dt.Rows.Count > 0 Then
                    Misc.PopulateC1DropDownList(cboFamily, dt, "Name", "ModelFamiliesID")
                    Me.cboFamily.SelectedIndex = 0
                Else
                    MessageBox.Show("No Family!") : Exit Sub
                End If

            Catch ex As Exception
                MessageBox.Show("LoadFamilies: " & ex.ToString)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub LoadFamilies_MismatchReceiveEDI()
            'Load Family
            Dim dt As DataTable
            Try
                dt = _objSkullcandy.GetFamily(_iMenuCustID, False)
                If dt.Rows.Count > 0 Then
                    Misc.PopulateC1DropDownList(Me.cboFamilyMismatchReceiveEDI, dt, "Name", "ModelFamiliesID")
                    Me.cboFamily.SelectedIndex = 0
                Else
                    MessageBox.Show("No Family!") : Exit Sub
                End If

            Catch ex As Exception
                MessageBox.Show("LoadFamilies: " & ex.ToString)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub ProcessSN()
            Dim iWOID As Integer, iFamilyID As Integer, iModelID As Integer, iModelID_EDI As Integer = 0
            Dim IsModelEndOfLife As Boolean = False, IsModelAudioTest As Boolean = False
            Dim iCCID As Integer = 0, i As Integer = 0, iDateCodeInternal As Integer = 0, iDateCodeExternal As Integer = 0, iEndUser As Integer = 0
            Dim strDateCode As String = "", strRMA As String = "", strSN As String = ""
            Dim iScrapPalletID As Integer = 0
            Dim dt, dtReqServices As DataTable
            Dim strFailSuccessReturned As String = ""
            Dim iDeviceID As Integer = 0
            Dim strModelFamily As String = ""

            Try
                If Not Me.cboCustomer.SelectedValue > 0 Then
                    MessageBox.Show("Please select a customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboCustomer.Focus()
                ElseIf Not Me.cboWorkorder.SelectedValue > 0 Then
                    MessageBox.Show("Please select a workorder.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboWorkorder.Focus()
                ElseIf Not Me.cboFamily.SelectedValue > 0 Then
                    MessageBox.Show("Please select a family.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboFamily.Focus()
                ElseIf Not Me.cboModels.SelectedValue > 0 AndAlso Me.chkNoModelRequired.Checked = False Then 'when molde is required
                    MessageBox.Show("Please select a model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboModels.Focus()
                ElseIf Me.txtSN.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter a SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtSN.Focus()
                ElseIf Me.txtRMA.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter a RMA.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    If Me.chkRMA.Checked Then 'if RMA same as SN
                        Me.txtSN.SelectAll() : Me.txtSN.Focus()
                    Else
                        Me.txtRMA.SelectAll() : Me.txtRMA.Focus()
                    End If
                    'ElseIf Generic.IsBillcodeMapped(iModelID, Skullcandy.ScrapBillcodeID) = 0 Then '(Me.cboModels.SelectedValue, Skullcandy.ScrapBillcodeID) = 0 Then
                    '    MessageBox.Show("Scrap billcode is not map. Please contact Material.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    '    Me.txtSN.SelectAll() : Me.txtSN.Focus()
                    'ElseIf Generic.IsBillcodeMapped(iModelID, Skullcandy.ClaimProcessingBillcodeID) = 0 Then '(Me.cboModels.SelectedValue, Skullcandy.ClaimProcessingBillcodeID) = 0 Then
                    '    MessageBox.Show("Claim Processing billcode is not map. Please contact Material.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    '    Me.txtSN.SelectAll() : Me.txtSN.Focus()
                Else
                    If CInt(Me.cboFamily.DataSource.Table.Select("ModelFamiliesID =" & Me.cboFamily.SelectedValue)(0)("CollectDateCodeInternal")) = 1 Then iDateCodeInternal = 1
                    If CInt(Me.cboFamily.DataSource.Table.Select("ModelFamiliesID =" & Me.cboFamily.SelectedValue)(0)("CollectDateCodeExternal")) = 1 Then iDateCodeExternal = 1

                    iEndUser = CInt(Me.cboWorkorder.DataSource.Table.Select("WO_ID =" & Me.cboWorkorder.SelectedValue)(0)("EndUser"))
                    '  _objSkullcandy = New Skullcandy() : _objSkullcandyRec = New SkullcandyRec()

                    'Get ModelID 
                    If Me.chkNoModelRequired.Checked = False Then
                        iModelID = Me.cboModels.SelectedValue
                    Else 'No model required, need to automatically get from tModel, if no, create it
                        Dim iModelID_Tmp As Integer = 0
                        strModelFamily = Me.cboFamily.DataSource.Table.Select("ModelFamiliesID =" & Me.cboFamily.SelectedValue)(0)("Name")
                        If Not strModelFamily.Trim.Length > 0 Then
                            MessageBox.Show("No model family name. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub
                        End If
                        iModelID_Tmp = _objSkullcandy.GetModelID(_objSkullcandy.MANUFID, _objSkullcandy.PRODID, strModelFamily)
                        If Not iModelID_Tmp > 0 Then 'Can create it automatically? - complicated. Popup message
                            MessageBox.Show("Model '" & strModelFamily & "' doesn't exist.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub
                        Else
                            iModelID = iModelID_Tmp
                        End If
                    End If

                    'Check if receiving unit mismatches EDI
                    iModelID_EDI = 0
                    If Me.chkMismatchReceiveEDI.Checked Then
                        If Me.cboModelsMismatchReceiveEDI.SelectedValue > 0 Then
                            iModelID_EDI = Me.cboModelsMismatchReceiveEDI.SelectedValue
                        Else
                            MessageBox.Show("Invalid modelID_EDI", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub
                        End If
                    End If

                    'Get other values
                    iWOID = Me.cboWorkorder.SelectedValue : iFamilyID = Me.cboFamily.SelectedValue
                    strRMA = Me.txtRMA.Text.Trim.Replace("'", "''")
                    strSN = Me.txtSN.Text.Trim.Replace("'", "''")

                    'Check if a duplicated device
                    ' _objSkullcandy = New Skullcandy() : _objSkullcandyRec = New SkullcandyRec()
                    If _objSkullcandyRec.GetDevicesCountInWIP(Skullcandy.LOCID, iWOID, strSN) > 0 Then
                        MessageBox.Show("This device has been received in WIP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub
                    End If

                    'Check if duplicated RMA
                    If _objSkullcandyRec.GetDeviceRMACount(Skullcandy.LOCID, strRMA) > 0 Then
                        MessageBox.Show("RMA has already received.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        If Me.chkRMA.Checked Then 'if RMA same as SN
                            Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub
                        Else
                            Me.txtRMA.SelectAll() : Me.txtRMA.Focus() : Exit Sub
                        End If
                    End If

                    'Pretest validation-------------------------------------------------------------------------------
                    If Me._iAudioTest = 1 Then 'Not Me._iScrap = 1 Then
                        If Not (Me.rbtPass.Checked) AndAlso Not (Me.rbtFail.Checked) Then
                            MessageBox.Show("Please perform Pretest.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        End If
                        If Me._iQCResult <> 1 AndAlso Me._iQCResult <> 2 Then
                            MessageBox.Show("Please perform Pretest (Can't determine QC result).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        End If
                        If Me.rbtPass.Checked AndAlso Me._iQCResult <> 1 Then
                            MessageBox.Show("Pass but invalid result.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        End If
                        If Me.rbtFail.Checked AndAlso Me._iQCResult <> 2 Then
                            MessageBox.Show("Fail but invalid result.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        End If
                        If Me.rbtFail.Checked AndAlso Not Me.cboPFCodes.SelectedValue > 0 Then
                            MessageBox.Show("Please select a fail code", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.cboPFCodes.Focus() : Exit Sub
                        End If
                        'Define Fail code datatable and add selected failcode data to the datatable
                        Dim row As DataRow
                        Me._dtFailcodes = New DataTable()
                        PSS.Data.Buisness.Generic.AddNewColumnToDataTable(Me._dtFailcodes, "DCode_ID", "System.Int32", )
                        PSS.Data.Buisness.Generic.AddNewColumnToDataTable(Me._dtFailcodes, "DCode_LDesc", "System.String", )
                        row = Me._dtFailcodes.NewRow()
                        row("DCode_ID") = Me.cboPFCodes.SelectedValue
                        row("DCode_LDesc") = Me.cboPFCodes.DataSource.Table.Select("DCode_ID =" & Me.cboPFCodes.SelectedValue)(0)("DCode_LDesc")
                        Me._dtFailcodes.Rows.Add(row)
                        If Not Me._dtFailcodes.Rows.Count > 0 Then
                            MessageBox.Show("Make sure to select a fail code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.cboPFCodes.Focus() : Exit Sub
                        End If
                    End If

                    If Me._iScrap = 1 Then
                        IsModelEndOfLife = True
                    Else
                        IsModelEndOfLife = False
                    End If

                    'Handle date code---------------------------------------------------------------------------
                    If Me.txtDateCode.Text.Trim.Length = 0 AndAlso Me._iDateCode = 1 Then
                        MessageBox.Show("Please enter a Date Code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtDateCode.Focus() : Exit Sub
                    End If
                    strDateCode = Me.txtDateCode.Text.Trim.Replace("'", "''")

                    'Ready to receive----------------------------------------------------------------------
                    If IsModelEndOfLife OrElse iEndUser = 1 Then 'SCRAP - 
                        dt = _objSkullcandyRec.GetOpenPalletName(_iMenuCustID, _objSkullcandy.LOCID)
                        If dt.Rows.Count = 0 Then
                            MessageBox.Show("No pallet name found for the scrap.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub
                        ElseIf dt.Rows.Count > 1 Then
                            MessageBox.Show("System only allow one open pallet. Please close all other pallets.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub
                        ElseIf dt.Rows.Count = 1 Then
                            iScrapPalletID = dt.Rows(0).Item("Pallett_ID")
                        End If
                    End If

                    'Get Service 
                    dtReqServices = Me._objSkullcandyRec.GetReqServiceBillcodes("SC_WRTY_PROCESS_SERVICE_BILLCODES")
                    'Check if model has sevice billcode map
                    If Me.HasServiceBillcodeMap(iModelID, dtReqServices) = False Then Exit Sub

                    iDeviceID = _objSkullcandyRec.ReceiveDeviceIntoWIP(iWOID, iModelID, strRMA, strSN, PSS.Core.ApplicationUser.IDShift, _
                                            PSS.Core.ApplicationUser.IDuser, PSS.Core.ApplicationUser.User, _
                                            iCCID, strDateCode, iScrapPalletID, iModelID_EDI)
                    If iDeviceID > 0 Then
                        'Bill Service Billcode
                        If iEndUser = 1 Then Me.BillServiceBillcode(iDeviceID, _iAudioTest, iDateCodeInternal, iDateCodeExternal, dtReqServices)

                        Me._iReceivedDeviceIDs.Add(iDeviceID)

                        If IsModelEndOfLife = True OrElse iEndUser = 1 Then 'auto ship for scrap unit
                            Dim strWrkDate As String = Generic.GetWorkDate(PSS.Core.ApplicationUser.IDShift)
                            SkullcandyRec.SkullcandyAutoShip(iDeviceID, iScrapPalletID, strWrkDate, PSS.Core.ApplicationUser.IDShift, "")
                            'Else 'Save PreTest data
                            '    Dim errMsg As String = ""
                            '    If Not Me.SavePretestInfo(iDeviceID, errMsg) Then
                            '        MessageBox.Show("Failed to save QC pretest data! " & errMsg, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "SavePretestResult")
                            '        Exit Sub
                            '    End If
                        End If
                        If Not IsModelEndOfLife = True Then
                            Dim errMsg As String = ""
                            If Not Me.SavePretestInfo(iDeviceID, errMsg) Then
                                MessageBox.Show("Failed to save QC pretest data! " & errMsg, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "SavePretestResult")
                                Exit Sub
                            End If
                        End If

                        ''Do log
                        'DoLogForReceivedDevices()
                        'Clean up
                        Me.rbtPass.Checked = False : Me.rbtFail.Checked = False
                        Me.rbtPass.ForeColor = Color.Black : Me.rbtFail.ForeColor = Color.Black
                        Me.cboPFCodes.Visible = False : Me.chkMismatchReceiveEDI.Checked = False
                        Me.txtDateCode.Text = "" : Me.txtRMA.Text = "" : Me.txtSN.Text = ""
                    Else
                        MessageBox.Show("System has failed to receive.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show("ProcessSN: " & ex.ToString, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtSN.SelectAll() : Me.txtSN.Focus()
            Finally
                Data.Buisness.Generic.DisposeDT(dt) : Data.Buisness.Generic.DisposeDT(dtReqServices)
            End Try
        End Sub

        '***************************************************************************************
        Private Function HasServiceBillcodeMap(ByVal iModelID As Integer, ByVal dtReqServices As DataTable) As Boolean
            Dim booReturnVal As Boolean = False
            Dim R1 As DataRow

            Try
                If Generic.IsBillcodeMapped(iModelID, Data.Buisness.Skullcandy.WrtyClaimServiceBillcode.Wrty_Audio_Testing) = 0 Then
                    MessageBox.Show("Service billcode Wrty_Audio_Testing is not map.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Generic.IsBillcodeMapped(iModelID, Data.Buisness.Skullcandy.WrtyClaimServiceBillcode.Wrty_Date_Code_External) = 0 Then
                    MessageBox.Show("Service billcode Wrty_Date_Code_External is not map.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Generic.IsBillcodeMapped(iModelID, Data.Buisness.Skullcandy.WrtyClaimServiceBillcode.Wrty_Date_Code_Internal) = 0 Then
                    MessageBox.Show("Service billcode Wrty_Date_Code_Internal is not map.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    booReturnVal = True
                End If

                For Each R1 In dtReqServices.Rows
                    If Generic.IsBillcodeMapped(iModelID, CInt(R1("Billcode_ID"))) = 0 Then
                        MessageBox.Show(R1("Billcode_Desc").ToString & " billcode is not map. Please contact Material.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        booReturnVal = False : Exit For
                    End If
                Next R1

                Return booReturnVal
            Catch ex As Exception
                Throw ex
            Finally
                Data.Buisness.Generic.DisposeDT(dtReqServices)
            End Try
        End Function

        '***************************************************************************************
        Private Function BillServiceBillcode(ByVal iDeviceID As Integer, ByVal iAudioTest As Integer, _
                                             ByVal iDateCodeInternal As Integer, ByVal iDateCodeExternal As Integer, _
                                             ByVal dtReqServices As DataTable) As Integer
            Dim objDevice As Rules.Device
            Dim R1 As DataRow

            Try
                objDevice = New Rules.Device(iDeviceID)

                For Each R1 In dtReqServices.Rows
                    objDevice.AddPart(CInt(R1("Billcode_ID")))
                Next R1

                If iAudioTest > 0 Then objDevice.AddPart(Data.Buisness.Skullcandy.WrtyClaimServiceBillcode.Wrty_Audio_Testing)

                If iDateCodeInternal > 0 Then objDevice.AddPart(Data.Buisness.Skullcandy.WrtyClaimServiceBillcode.Wrty_Date_Code_Internal)

                If iDateCodeExternal > 0 Then objDevice.AddPart(Data.Buisness.Skullcandy.WrtyClaimServiceBillcode.Wrty_Date_Code_External)

                objDevice.Update()
            Catch ex As Exception
                Throw ex
            Finally
                objDevice.Dispose() : objDevice = Nothing : Data.Buisness.Generic.DisposeDT(dtReqServices)
            End Try
        End Function

        '***************************************************************************************
        Private Sub LoadModels()
            Dim dt As DataTable
            Dim iFamilyID As Integer = Me.cboFamily.SelectedValue

            Try
                If _iMenuCustID > 0 AndAlso iFamilyID > 0 Then  'AndAlso Me.chkNoModelRequired.Checked = False
                    _objSkullcandy = New Skullcandy()
                    dt = _objSkullcandy.GetModelByFamilyID(_iMenuCustID, iFamilyID)
                    If dt.Rows.Count > 0 Then
                        Misc.PopulateC1DropDownList(Me.cboModels, dt, "Model_desc", "Model_ID")
                        Me.cboModels.SelectedValue = 0
                    Else
                        MessageBox.Show("No Model!") : Exit Sub
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show("LoadModels: " & ex.ToString)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub LoadModels_MismatchReceiveEDI()
            Dim dt As DataTable
            Dim iFamilyID As Integer = Me.cboFamily.SelectedValue

            Try
                If _iMenuCustID > 0 AndAlso iFamilyID > 0 Then
                    _objSkullcandy = New Skullcandy()
                    dt = _objSkullcandy.GetModelByFamilyID(_iMenuCustID, iFamilyID)
                    If dt.Rows.Count > 0 Then
                        Misc.PopulateC1DropDownList(Me.cboModelsMismatchReceiveEDI(), dt, "Model_desc", "Model_ID")
                        Me.cboModels.SelectedValue = 0
                    Else
                        MessageBox.Show("No Model!") : Exit Sub
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show("LoadModels: " & ex.ToString)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub cboFamily_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFamily.Change

            UpdateScrapDateCodeYN()

            LoadModels()
        End Sub

        '***************************************************************************************
        Private Sub txtSN_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp
            Try

                If e.KeyCode = Keys.Enter AndAlso txtSN.Text.Trim.Length > 0 Then
                    If Me.chkRMA.Checked Then Me.txtRMA.Text = Me.txtSN.Text
                    Me.ProcessSN()
                End If 'Key up and input length > 0
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Enabled = True : txtSN.SelectAll() : txtSN.Focus()
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '***************************************************************************************
        Private Sub DoLogForReceivedDevices()
            Dim i As Integer = 0
            Dim strIDs As String
            For i = 0 To Me._iReceivedDeviceIDs.Count - 1
                strIDs &= Me._iReceivedDeviceIDs(i)
            Next
            ' MessageBox.Show(strIDs)
            'Will add log so that user can view it.
        End Sub

        '***************************************************************************************
        Private Sub chkNoModelRequired_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNoModelRequired.CheckedChanged
            LoadFamilies()
            'LoadModels()
            SetModelDisplay()
        End Sub

        '***************************************************************************************
        Private Sub chkMismatchReceiveEDI_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkMismatchReceiveEDI.CheckedChanged
            If Me.chkMismatchReceiveEDI.Checked Then
                Me.GrpMismatch.Top = Me.chkMismatchReceiveEDI.Top + Me.chkMismatchReceiveEDI.Height + 5
                Me.pnlDateCode.Top = Me.GrpMismatch.Top + Me.GrpMismatch.Height + 5
                Me.grpPretest.Top = Me.pnlDateCode.Top + Me.pnlDateCode.Height + 5
                Me.grpRMA.Top = Me.grpPretest.Top + Me.grpPretest.Height + 5
                Me.GrpMismatch.Visible = True

                LoadFamilies_MismatchReceiveEDI()
            Else
                Me.pnlDateCode.Top = Me.chkMismatchReceiveEDI.Top + Me.chkMismatchReceiveEDI.Height + 10
                Me.grpPretest.Top = Me.pnlDateCode.Top + Me.pnlDateCode.Height + 5
                Me.grpRMA.Top = Me.grpPretest.Top + Me.grpPretest.Height + 5
                Me.GrpMismatch.Visible = False
            End If

            UpdatePretestAndRMADisplay()
        End Sub

        '***************************************************************************************
        Private Sub cboFamilyMismatchReceiveEDI_Change(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFamilyMismatchReceiveEDI.Change
            LoadModels_MismatchReceiveEDI()
        End Sub

        '***************************************************************************************
        Private Sub LoadPFCodes()
            Dim dt As DataTable

            Try
                _objSkullcandy = New Skullcandy()
                _objPreTest = New Data.Buisness.PreTest()

                Me.cboPFCodes.DataSource = Nothing
                dt = Me._objPreTest.GetPFCodesComboData(_objSkullcandy.PRODID)

                If Not IsNothing(dt) Then
                    Misc.PopulateC1DropDownList(cboPFCodes, dt, "DCode_LDesc", "DCode_ID")
                    Me.cboPFCodes.SelectedValue = 0
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error in LoadPFCodes")
            End Try
        End Sub

        '***************************************************************************************
        Private Sub rbtPass_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtPass.CheckedChanged
            If Me.rbtPass.Checked Then
                Me._iQCResult = 1
                Me.rbtPass.ForeColor = Color.Green
                Me.rbtFail.ForeColor = Color.Black
                Me.rbtPass.Font = New Font("Arial", 10, FontStyle.Bold)
                Me.rbtFail.Font = New Font("Arial", 10, FontStyle.Regular)
                Me.cboPFCodes.Visible = False
            Else
                Me.rbtPass.Font = New Font("Arial", 10, FontStyle.Regular)
            End If
        End Sub

        '***************************************************************************************
        Private Sub rbtFail_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtFail.CheckedChanged
            If Me.rbtFail.Checked Then
                Me._iQCResult = 2
                Me.rbtPass.ForeColor = Color.Black
                Me.rbtFail.ForeColor = Color.Red
                Me.rbtPass.Font = New Font("Arial", 10, FontStyle.Regular)
                Me.rbtFail.Font = New Font("Arial", 10, FontStyle.Bold)
                Me.cboPFCodes.Visible = True
                Me.cboPFCodes.Focus()
            Else
                rbtFail.Font = New Font("Arial", 10, FontStyle.Regular)
            End If
        End Sub

        '***************************************************************************************
        Private Function SavePretestInfo(ByVal iDeviceID As Integer, ByRef errMsg As String) As Boolean
            'Dim objACC As Data.Production.AssignCostCenter
            ' Dim i, iStationFailed As Integer
            Dim strFailCodes As String = ""
            Dim strNextWrkStation As String = ""
            errMsg = ""

            Try
                'i = 0 : iStationFailed = 0

                'If Me._iQCResult = 2 Then
                '    iStationFailed = 1
                'Else
                '    iStationFailed = 0
                'End If

                'strNextWrkStation = Generic.GetNextWorkStationInWFP(Me._strScreenName, 0, Me.cboCustomers.SelectedValue, iStationFailed, )
                'If strNextWrkStation.Trim.Length > 0 Then Generic.SetTcelloptWorkStationForDevice(strNextWrkStation, _iDevice_ID)

                'If Me._objPreTest.UpdatePFData(iDeviceID, Me._iQCResult, Me._dtFailcodes, _
                '                                             PSS.Core.Global.ApplicationUser.IDuser, System.Net.Dns.GetHostName, _
                '                                             Me.lblWorkDate.Tag, Me._iWCLocation_ID, Me._iGrpLineMap_ID, _
                '                                             PSS.Core.Global.ApplicationUser.IDuser, "") Then

                ''**********************************
                Return Me._objPreTest.UpdatePFData(iDeviceID, Me._iQCResult, Me._dtFailcodes, _
                                               PSS.Core.Global.ApplicationUser.IDuser, System.Net.Dns.GetHostName, _
                                               PSS.Core.Global.ApplicationUser.Workdate, 1, _
                                               PSS.Core.Global.ApplicationUser.LineID, _
                                               PSS.Core.Global.ApplicationUser.IDuser, "")

            Catch ex As Exception
                ' MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "SavePretestResult")
                errMsg = ex.Message
                Return False
            Finally
                ' objACC = Nothing
            End Try
        End Function

        '***************************************************************************************
        Private Sub btnLanUseOnly_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLanUseOnly.Click
            'Dim objTFRec As PSS.Data.Buisness.TracFone.Receive
            'Dim objDevice As Rules.Device
            'Dim strSql As String = ""
            'Dim dt As DataTable
            'Dim R1 As DataRow

            'Try
            '    objTFRec = New PSS.Data.Buisness.TracFone.Receive()
            '    strSql = "SELECT tdevice.*, modelfamilies_cust_map.* FROM tdevice INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID" & Environment.NewLine
            '    strSql &= "INNER JOIN tcustmodel_pssmodel_map ON tdevice.Model_ID = tcustmodel_pssmodel_map.Model_ID" & Environment.NewLine
            '    strSql &= "INNER JOIN cogs.modelfamilies on tcustmodel_pssmodel_map.modelfamiliesID = cogs.modelfamilies.modelfamiliesid" & Environment.NewLine
            '    strSql &= "INNER JOIN cogs.modelfamilies_cust_map on cogs.modelfamilies.modelfamiliesid = cogs.modelfamilies_cust_map.modelfamiliesid" & Environment.NewLine
            '    strSql &= "WHERE tdevice.loc_id = 3352 AND Device_Daterec between '2013-09-02 00:00:00' AND '2013-09-08 23:59:59'" & Environment.NewLine
            '    strSql &= "AND tworkorder.EndUser = 1 "
            '    dt = objTFRec.GetSpecialDeviceIDs(strSql)
            '    For Each R1 In dt.Rows
            '        objDevice = New Rules.Device(CInt(R1("Device_ID")))

            '        If Generic.IsBillcodeExisted(CInt((R1("Device_ID"))), Data.Buisness.Skullcandy.WrtyClaimServiceBillcode.Wrty_Receiving) = False Then objDevice.AddPart(Data.Buisness.Skullcandy.WrtyClaimServiceBillcode.Wrty_Receiving)
            '        If Generic.IsBillcodeExisted(CInt((R1("Device_ID"))), Data.Buisness.Skullcandy.WrtyClaimServiceBillcode.Wrty_Scrap) = False Then objDevice.AddPart(Data.Buisness.Skullcandy.WrtyClaimServiceBillcode.Wrty_Scrap)

            '        If CInt(R1("AudioTest")) = 1 AndAlso Generic.IsBillcodeExisted(CInt((R1("Device_ID"))), Data.Buisness.Skullcandy.WrtyClaimServiceBillcode.Wrty_Audio_Testing) = False Then objDevice.AddPart(Data.Buisness.Skullcandy.WrtyClaimServiceBillcode.Wrty_Audio_Testing)

            '        If CInt(R1("CollectDateCodeInternal")) = 1 AndAlso Generic.IsBillcodeExisted(CInt((R1("Device_ID"))), Data.Buisness.Skullcandy.WrtyClaimServiceBillcode.Wrty_Date_Code_Internal) = False Then objDevice.AddPart(Data.Buisness.Skullcandy.WrtyClaimServiceBillcode.Wrty_Date_Code_Internal)

            '        If CInt(R1("CollectDateCodeExternal")) = 1 AndAlso Generic.IsBillcodeExisted(CInt((R1("Device_ID"))), Data.Buisness.Skullcandy.WrtyClaimServiceBillcode.Wrty_Date_Code_External) = False Then objDevice.AddPart(Data.Buisness.Skullcandy.WrtyClaimServiceBillcode.Wrty_Date_Code_External)

            '        objDevice.Update()
            '    Next R1

            '    MessageBox.Show("Completed.", "btnLanUseOnly_Click", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Catch ex As Exception
            '    MessageBox.Show(ex.ToString, "btnLanUseOnly_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Finally
            '    objDevice.Dispose() : objDevice = Nothing
            'End Try
        End Sub

        '***************************************************************************************


    End Class
End Namespace
