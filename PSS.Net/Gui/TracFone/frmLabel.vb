Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.TracFone
    Public Class frmLabel
        Inherits System.Windows.Forms.Form

        Private _iMenuCustID As Integer = 0
        Private _strScreenName As String = ""
        Private _iDevice_ID As Integer = 0
        Private _objTracLabel As PSS.Data.Buisness.TracFone.Label
        Private _iModel_ID As Integer = 0
        Private _strOSInfo As System.OperatingSystem = System.Environment.OSVersion


#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iCustID As Integer, ByVal strScreenName As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _strScreenName = strScreenName
            Me._iMenuCustID = iCustID
            _objTracLabel = New PSS.Data.Buisness.TracFone.Label()
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
        Friend WithEvents cmdlblprint As System.Windows.Forms.Button
        Friend WithEvents txtIMEI As System.Windows.Forms.TextBox
        Friend WithEvents txtSNMSN As System.Windows.Forms.TextBox
        Friend WithEvents lblIMEI As System.Windows.Forms.Label
        Friend WithEvents txtBtAddr As System.Windows.Forms.TextBox
        Friend WithEvents lblBtAddr As System.Windows.Forms.Label
        Friend WithEvents lblFCC As System.Windows.Forms.Label
        Friend WithEvents lblTFModel As System.Windows.Forms.Label
        Friend WithEvents txtN As System.Windows.Forms.TextBox
        Friend WithEvents lblHWREV As System.Windows.Forms.Label
        Friend WithEvents txtHW As System.Windows.Forms.TextBox
        Friend WithEvents lblDate As System.Windows.Forms.Label
        Friend WithEvents txtDate As System.Windows.Forms.TextBox
        Friend WithEvents lblProdCode As System.Windows.Forms.Label
        Friend WithEvents txtProdCode As System.Windows.Forms.TextBox
        Friend WithEvents lblSW As System.Windows.Forms.Label
        Friend WithEvents txtSW As System.Windows.Forms.TextBox
        Friend WithEvents lblModel As System.Windows.Forms.Label
        Friend WithEvents lblPNo As System.Windows.Forms.Label
        Friend WithEvents txtPNo As System.Windows.Forms.TextBox
        Friend WithEvents lblMadeIn As System.Windows.Forms.Label
        Friend WithEvents lblSJUG As System.Windows.Forms.Label
        Friend WithEvents lblSN As System.Windows.Forms.Label
        Friend WithEvents txtFCCID As System.Windows.Forms.TextBox
        Friend WithEvents txtModelNo As System.Windows.Forms.TextBox
        Friend WithEvents txtTFModelNo As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents cboLabelType As System.Windows.Forms.ComboBox
        Friend WithEvents lblModels As System.Windows.Forms.Label
        Friend WithEvents cboModels As C1.Win.C1List.C1Combo
        Friend WithEvents C1Combo1 As C1.Win.C1List.C1Combo
        Friend WithEvents cboSJUG As C1.Win.C1List.C1Combo
        Friend WithEvents cboMadeIn As C1.Win.C1List.C1Combo
        Friend WithEvents pnlMain As System.Windows.Forms.Panel
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents Panel5 As System.Windows.Forms.Panel
        Friend WithEvents Panel4 As System.Windows.Forms.Panel
        Friend WithEvents pnlMSNSN As System.Windows.Forms.Panel
        Friend WithEvents pnlESN As System.Windows.Forms.Panel
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtESN As System.Windows.Forms.TextBox
        Friend WithEvents Panel6 As System.Windows.Forms.Panel
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents txtManufProdSN As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents txtSeq As System.Windows.Forms.TextBox
        Friend WithEvents pnlSjug As System.Windows.Forms.Panel
        Friend WithEvents grbLabelSetUpInfo As System.Windows.Forms.GroupBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents lblName As System.Windows.Forms.Label
        Friend WithEvents lblModelNo1 As System.Windows.Forms.Label
        Friend WithEvents lblModelNo2 As System.Windows.Forms.Label
        Friend WithEvents lblFCCID As System.Windows.Forms.Label
        Friend WithEvents lblLabelSize As System.Windows.Forms.Label
        Friend WithEvents btnViewLabelSetUpInfo As System.Windows.Forms.Button
        Friend WithEvents Panel7 As System.Windows.Forms.Panel
        Friend WithEvents txtIMEI_HEX As System.Windows.Forms.TextBox
        Friend WithEvents lblIMEI_HEX As System.Windows.Forms.Label
        Friend WithEvents Panel8 As System.Windows.Forms.Panel
        Friend WithEvents lblSSID As System.Windows.Forms.Label
        Friend WithEvents txtSSID As System.Windows.Forms.TextBox
        Friend WithEvents Panel9 As System.Windows.Forms.Panel
        Friend WithEvents txtLocation As System.Windows.Forms.TextBox
        Friend WithEvents lblLocation As System.Windows.Forms.Label
        Friend WithEvents Panel10 As System.Windows.Forms.Panel
        Friend WithEvents txtMEIDHEX As System.Windows.Forms.TextBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Panel11 As System.Windows.Forms.Panel
        Friend WithEvents txtMEIDDEC As System.Windows.Forms.TextBox
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Panel12 As System.Windows.Forms.Panel
        Friend WithEvents txtBluetooth As System.Windows.Forms.TextBox
        Friend WithEvents lblBluetooth As System.Windows.Forms.Label
        Friend WithEvents Panel13 As System.Windows.Forms.Panel
        Friend WithEvents lblWebUIPW As System.Windows.Forms.Label
        Friend WithEvents txtWebUIPW As System.Windows.Forms.TextBox
        Friend WithEvents btnRemoveLabelInfo As System.Windows.Forms.Button
        Friend WithEvents btnResetManufDateCode As System.Windows.Forms.Button
        Friend WithEvents chkBoxIntermec As System.Windows.Forms.CheckBox
        Friend WithEvents grpBoxPrint As System.Windows.Forms.GroupBox
        Friend WithEvents ChkBoxNoIntermec As System.Windows.Forms.CheckBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmLabel))
            Me.txtIMEI = New System.Windows.Forms.TextBox()
            Me.lblIMEI = New System.Windows.Forms.Label()
            Me.pnlMain = New System.Windows.Forms.Panel()
            Me.Panel13 = New System.Windows.Forms.Panel()
            Me.lblWebUIPW = New System.Windows.Forms.Label()
            Me.txtWebUIPW = New System.Windows.Forms.TextBox()
            Me.Panel11 = New System.Windows.Forms.Panel()
            Me.txtMEIDDEC = New System.Windows.Forms.TextBox()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.Panel10 = New System.Windows.Forms.Panel()
            Me.txtMEIDHEX = New System.Windows.Forms.TextBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Panel9 = New System.Windows.Forms.Panel()
            Me.txtLocation = New System.Windows.Forms.TextBox()
            Me.lblLocation = New System.Windows.Forms.Label()
            Me.Panel8 = New System.Windows.Forms.Panel()
            Me.txtIMEI_HEX = New System.Windows.Forms.TextBox()
            Me.lblIMEI_HEX = New System.Windows.Forms.Label()
            Me.pnlSjug = New System.Windows.Forms.Panel()
            Me.cboSJUG = New C1.Win.C1List.C1Combo()
            Me.lblSJUG = New System.Windows.Forms.Label()
            Me.Panel6 = New System.Windows.Forms.Panel()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.txtSeq = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtManufProdSN = New System.Windows.Forms.TextBox()
            Me.pnlESN = New System.Windows.Forms.Panel()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtESN = New System.Windows.Forms.TextBox()
            Me.pnlMSNSN = New System.Windows.Forms.Panel()
            Me.lblSN = New System.Windows.Forms.Label()
            Me.txtSNMSN = New System.Windows.Forms.TextBox()
            Me.Panel4 = New System.Windows.Forms.Panel()
            Me.txtDate = New System.Windows.Forms.TextBox()
            Me.lblDate = New System.Windows.Forms.Label()
            Me.cboMadeIn = New C1.Win.C1List.C1Combo()
            Me.cboLabelType = New System.Windows.Forms.ComboBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtFCCID = New System.Windows.Forms.TextBox()
            Me.lblFCC = New System.Windows.Forms.Label()
            Me.txtModelNo = New System.Windows.Forms.TextBox()
            Me.txtTFModelNo = New System.Windows.Forms.TextBox()
            Me.lblTFModel = New System.Windows.Forms.Label()
            Me.lblModel = New System.Windows.Forms.Label()
            Me.lblMadeIn = New System.Windows.Forms.Label()
            Me.Panel5 = New System.Windows.Forms.Panel()
            Me.lblSW = New System.Windows.Forms.Label()
            Me.txtSW = New System.Windows.Forms.TextBox()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.txtBtAddr = New System.Windows.Forms.TextBox()
            Me.lblBtAddr = New System.Windows.Forms.Label()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.lblPNo = New System.Windows.Forms.Label()
            Me.txtProdCode = New System.Windows.Forms.TextBox()
            Me.txtPNo = New System.Windows.Forms.TextBox()
            Me.lblProdCode = New System.Windows.Forms.Label()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.txtN = New System.Windows.Forms.TextBox()
            Me.txtHW = New System.Windows.Forms.TextBox()
            Me.lblHWREV = New System.Windows.Forms.Label()
            Me.Panel7 = New System.Windows.Forms.Panel()
            Me.lblSSID = New System.Windows.Forms.Label()
            Me.txtSSID = New System.Windows.Forms.TextBox()
            Me.Panel12 = New System.Windows.Forms.Panel()
            Me.txtBluetooth = New System.Windows.Forms.TextBox()
            Me.lblBluetooth = New System.Windows.Forms.Label()
            Me.cboModels = New C1.Win.C1List.C1Combo()
            Me.lblModels = New System.Windows.Forms.Label()
            Me.cmdlblprint = New System.Windows.Forms.Button()
            Me.C1Combo1 = New C1.Win.C1List.C1Combo()
            Me.grbLabelSetUpInfo = New System.Windows.Forms.GroupBox()
            Me.lblLabelSize = New System.Windows.Forms.Label()
            Me.lblFCCID = New System.Windows.Forms.Label()
            Me.lblModelNo2 = New System.Windows.Forms.Label()
            Me.lblModelNo1 = New System.Windows.Forms.Label()
            Me.lblName = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.btnViewLabelSetUpInfo = New System.Windows.Forms.Button()
            Me.btnRemoveLabelInfo = New System.Windows.Forms.Button()
            Me.btnResetManufDateCode = New System.Windows.Forms.Button()
            Me.chkBoxIntermec = New System.Windows.Forms.CheckBox()
            Me.grpBoxPrint = New System.Windows.Forms.GroupBox()
            Me.ChkBoxNoIntermec = New System.Windows.Forms.CheckBox()
            Me.pnlMain.SuspendLayout()
            Me.Panel13.SuspendLayout()
            Me.Panel11.SuspendLayout()
            Me.Panel10.SuspendLayout()
            Me.Panel9.SuspendLayout()
            Me.Panel8.SuspendLayout()
            Me.pnlSjug.SuspendLayout()
            CType(Me.cboSJUG, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel6.SuspendLayout()
            Me.pnlESN.SuspendLayout()
            Me.pnlMSNSN.SuspendLayout()
            Me.Panel4.SuspendLayout()
            CType(Me.cboMadeIn, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel5.SuspendLayout()
            Me.Panel1.SuspendLayout()
            Me.Panel2.SuspendLayout()
            Me.Panel3.SuspendLayout()
            Me.Panel7.SuspendLayout()
            Me.Panel12.SuspendLayout()
            CType(Me.cboModels, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.C1Combo1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grbLabelSetUpInfo.SuspendLayout()
            Me.grpBoxPrint.SuspendLayout()
            Me.SuspendLayout()
            '
            'txtIMEI
            '
            Me.txtIMEI.Location = New System.Drawing.Point(96, 40)
            Me.txtIMEI.Name = "txtIMEI"
            Me.txtIMEI.Size = New System.Drawing.Size(184, 20)
            Me.txtIMEI.TabIndex = 35
            Me.txtIMEI.Text = ""
            '
            'lblIMEI
            '
            Me.lblIMEI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblIMEI.Location = New System.Drawing.Point(16, 40)
            Me.lblIMEI.Name = "lblIMEI"
            Me.lblIMEI.Size = New System.Drawing.Size(80, 16)
            Me.lblIMEI.TabIndex = 1
            Me.lblIMEI.Text = "IMEI/MEID:"
            Me.lblIMEI.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'pnlMain
            '
            Me.pnlMain.BackColor = System.Drawing.Color.LightSteelBlue
            Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlMain.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel13, Me.Panel11, Me.Panel10, Me.Panel9, Me.Panel8, Me.pnlSjug, Me.Panel6, Me.pnlESN, Me.pnlMSNSN, Me.Panel4, Me.cboMadeIn, Me.cboLabelType, Me.Label1, Me.txtFCCID, Me.lblFCC, Me.txtModelNo, Me.txtTFModelNo, Me.lblTFModel, Me.lblModel, Me.lblMadeIn, Me.txtIMEI, Me.lblIMEI, Me.Panel5, Me.Panel1, Me.Panel2, Me.Panel3, Me.Panel7, Me.Panel12})
            Me.pnlMain.Location = New System.Drawing.Point(8, 10)
            Me.pnlMain.Name = "pnlMain"
            Me.pnlMain.Size = New System.Drawing.Size(632, 350)
            Me.pnlMain.TabIndex = 2
            '
            'Panel13
            '
            Me.Panel13.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblWebUIPW, Me.txtWebUIPW})
            Me.Panel13.Location = New System.Drawing.Point(440, 0)
            Me.Panel13.Name = "Panel13"
            Me.Panel13.Size = New System.Drawing.Size(192, 24)
            Me.Panel13.TabIndex = 34
            Me.Panel13.Visible = False
            '
            'lblWebUIPW
            '
            Me.lblWebUIPW.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWebUIPW.Location = New System.Drawing.Point(8, 0)
            Me.lblWebUIPW.Name = "lblWebUIPW"
            Me.lblWebUIPW.Size = New System.Drawing.Size(80, 16)
            Me.lblWebUIPW.TabIndex = 30
            Me.lblWebUIPW.Text = "Web UI PW:"
            Me.lblWebUIPW.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtWebUIPW
            '
            Me.txtWebUIPW.Location = New System.Drawing.Point(88, 0)
            Me.txtWebUIPW.Name = "txtWebUIPW"
            Me.txtWebUIPW.Size = New System.Drawing.Size(88, 20)
            Me.txtWebUIPW.TabIndex = 29
            Me.txtWebUIPW.Text = ""
            '
            'Panel11
            '
            Me.Panel11.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtMEIDDEC, Me.Label7})
            Me.Panel11.Location = New System.Drawing.Point(8, 112)
            Me.Panel11.Name = "Panel11"
            Me.Panel11.Size = New System.Drawing.Size(280, 24)
            Me.Panel11.TabIndex = 33
            Me.Panel11.Visible = False
            '
            'txtMEIDDEC
            '
            Me.txtMEIDDEC.Location = New System.Drawing.Point(88, 0)
            Me.txtMEIDDEC.Name = "txtMEIDDEC"
            Me.txtMEIDDEC.Size = New System.Drawing.Size(184, 20)
            Me.txtMEIDDEC.TabIndex = 1
            Me.txtMEIDDEC.Text = ""
            '
            'Label7
            '
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.Location = New System.Drawing.Point(-8, 0)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(88, 16)
            Me.Label7.TabIndex = 26
            Me.Label7.Text = "MEID DEC:"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Panel10
            '
            Me.Panel10.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtMEIDHEX, Me.Label6})
            Me.Panel10.Location = New System.Drawing.Point(8, 88)
            Me.Panel10.Name = "Panel10"
            Me.Panel10.Size = New System.Drawing.Size(280, 24)
            Me.Panel10.TabIndex = 32
            Me.Panel10.Visible = False
            '
            'txtMEIDHEX
            '
            Me.txtMEIDHEX.Location = New System.Drawing.Point(88, 0)
            Me.txtMEIDHEX.Name = "txtMEIDHEX"
            Me.txtMEIDHEX.Size = New System.Drawing.Size(184, 20)
            Me.txtMEIDHEX.TabIndex = 1
            Me.txtMEIDHEX.Text = ""
            '
            'Label6
            '
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.Location = New System.Drawing.Point(-8, 0)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(88, 16)
            Me.Label6.TabIndex = 26
            Me.Label6.Text = "MEID HEX:"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Panel9
            '
            Me.Panel9.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtLocation, Me.lblLocation})
            Me.Panel9.Location = New System.Drawing.Point(160, 272)
            Me.Panel9.Name = "Panel9"
            Me.Panel9.Size = New System.Drawing.Size(128, 32)
            Me.Panel9.TabIndex = 30
            Me.Panel9.Visible = False
            '
            'txtLocation
            '
            Me.txtLocation.Location = New System.Drawing.Point(80, 8)
            Me.txtLocation.Name = "txtLocation"
            Me.txtLocation.Size = New System.Drawing.Size(40, 20)
            Me.txtLocation.TabIndex = 1
            Me.txtLocation.Text = ""
            '
            'lblLocation
            '
            Me.lblLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLocation.Location = New System.Drawing.Point(8, 8)
            Me.lblLocation.Name = "lblLocation"
            Me.lblLocation.Size = New System.Drawing.Size(64, 16)
            Me.lblLocation.TabIndex = 17
            Me.lblLocation.Text = "Location: "
            Me.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Panel8
            '
            Me.Panel8.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtIMEI_HEX, Me.lblIMEI_HEX})
            Me.Panel8.Location = New System.Drawing.Point(8, 64)
            Me.Panel8.Name = "Panel8"
            Me.Panel8.Size = New System.Drawing.Size(280, 24)
            Me.Panel8.TabIndex = 29
            Me.Panel8.Visible = False
            '
            'txtIMEI_HEX
            '
            Me.txtIMEI_HEX.Location = New System.Drawing.Point(88, 0)
            Me.txtIMEI_HEX.Name = "txtIMEI_HEX"
            Me.txtIMEI_HEX.Size = New System.Drawing.Size(184, 20)
            Me.txtIMEI_HEX.TabIndex = 1
            Me.txtIMEI_HEX.Text = ""
            '
            'lblIMEI_HEX
            '
            Me.lblIMEI_HEX.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblIMEI_HEX.Location = New System.Drawing.Point(-8, 0)
            Me.lblIMEI_HEX.Name = "lblIMEI_HEX"
            Me.lblIMEI_HEX.Size = New System.Drawing.Size(88, 16)
            Me.lblIMEI_HEX.TabIndex = 26
            Me.lblIMEI_HEX.Text = "IMEI HEX:"
            Me.lblIMEI_HEX.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'pnlSjug
            '
            Me.pnlSjug.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboSJUG, Me.lblSJUG})
            Me.pnlSjug.Location = New System.Drawing.Point(296, 80)
            Me.pnlSjug.Name = "pnlSjug"
            Me.pnlSjug.Size = New System.Drawing.Size(320, 32)
            Me.pnlSjug.TabIndex = 6
            Me.pnlSjug.Visible = False
            '
            'cboSJUG
            '
            Me.cboSJUG.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboSJUG.AutoCompletion = True
            Me.cboSJUG.AutoDropDown = True
            Me.cboSJUG.AutoSelect = True
            Me.cboSJUG.Caption = ""
            Me.cboSJUG.CaptionHeight = 17
            Me.cboSJUG.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboSJUG.ColumnCaptionHeight = 17
            Me.cboSJUG.ColumnFooterHeight = 17
            Me.cboSJUG.ColumnHeaders = False
            Me.cboSJUG.ContentHeight = 15
            Me.cboSJUG.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboSJUG.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboSJUG.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboSJUG.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboSJUG.EditorHeight = 15
            Me.cboSJUG.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboSJUG.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboSJUG.ItemHeight = 15
            Me.cboSJUG.Location = New System.Drawing.Point(112, 5)
            Me.cboSJUG.MatchEntryTimeout = CType(2000, Long)
            Me.cboSJUG.MaxDropDownItems = CType(10, Short)
            Me.cboSJUG.MaxLength = 32767
            Me.cboSJUG.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboSJUG.Name = "cboSJUG"
            Me.cboSJUG.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboSJUG.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboSJUG.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboSJUG.Size = New System.Drawing.Size(192, 21)
            Me.cboSJUG.TabIndex = 2
            Me.cboSJUG.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'lblSJUG
            '
            Me.lblSJUG.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSJUG.Location = New System.Drawing.Point(56, 5)
            Me.lblSJUG.Name = "lblSJUG"
            Me.lblSJUG.Size = New System.Drawing.Size(48, 16)
            Me.lblSJUG.TabIndex = 5
            Me.lblSJUG.Text = "SJUG:"
            Me.lblSJUG.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Panel6
            '
            Me.Panel6.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label4, Me.txtSeq, Me.Label3, Me.txtManufProdSN})
            Me.Panel6.Location = New System.Drawing.Point(296, 184)
            Me.Panel6.Name = "Panel6"
            Me.Panel6.Size = New System.Drawing.Size(320, 56)
            Me.Panel6.TabIndex = 11
            Me.Panel6.Visible = False
            '
            'Label4
            '
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.Location = New System.Drawing.Point(40, 32)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(72, 16)
            Me.Label4.TabIndex = 5
            Me.Label4.Text = "SEQ:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtSeq
            '
            Me.txtSeq.Location = New System.Drawing.Point(112, 32)
            Me.txtSeq.Name = "txtSeq"
            Me.txtSeq.Size = New System.Drawing.Size(197, 20)
            Me.txtSeq.TabIndex = 4
            Me.txtSeq.Text = ""
            '
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.Location = New System.Drawing.Point(8, 8)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(104, 16)
            Me.Label3.TabIndex = 3
            Me.Label3.Text = "Manuf Prod SN:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtManufProdSN
            '
            Me.txtManufProdSN.Location = New System.Drawing.Point(112, 8)
            Me.txtManufProdSN.Name = "txtManufProdSN"
            Me.txtManufProdSN.Size = New System.Drawing.Size(197, 20)
            Me.txtManufProdSN.TabIndex = 1
            Me.txtManufProdSN.Text = ""
            '
            'pnlESN
            '
            Me.pnlESN.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label2, Me.txtESN})
            Me.pnlESN.Location = New System.Drawing.Point(296, 48)
            Me.pnlESN.Name = "pnlESN"
            Me.pnlESN.Size = New System.Drawing.Size(320, 32)
            Me.pnlESN.TabIndex = 8
            Me.pnlESN.Visible = False
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.Location = New System.Drawing.Point(32, 8)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(80, 16)
            Me.Label2.TabIndex = 3
            Me.Label2.Text = "ESN:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtESN
            '
            Me.txtESN.Location = New System.Drawing.Point(112, 8)
            Me.txtESN.Name = "txtESN"
            Me.txtESN.Size = New System.Drawing.Size(197, 20)
            Me.txtESN.TabIndex = 1
            Me.txtESN.Text = ""
            '
            'pnlMSNSN
            '
            Me.pnlMSNSN.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblSN, Me.txtSNMSN})
            Me.pnlMSNSN.Location = New System.Drawing.Point(296, 24)
            Me.pnlMSNSN.Name = "pnlMSNSN"
            Me.pnlMSNSN.Size = New System.Drawing.Size(320, 24)
            Me.pnlMSNSN.TabIndex = 7
            Me.pnlMSNSN.Visible = False
            '
            'lblSN
            '
            Me.lblSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSN.Location = New System.Drawing.Point(8, 0)
            Me.lblSN.Name = "lblSN"
            Me.lblSN.Size = New System.Drawing.Size(104, 16)
            Me.lblSN.TabIndex = 3
            Me.lblSN.Text = "SN/MSN/CODE:"
            Me.lblSN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtSNMSN
            '
            Me.txtSNMSN.Location = New System.Drawing.Point(112, 0)
            Me.txtSNMSN.Name = "txtSNMSN"
            Me.txtSNMSN.Size = New System.Drawing.Size(197, 20)
            Me.txtSNMSN.TabIndex = 1
            Me.txtSNMSN.Text = ""
            '
            'Panel4
            '
            Me.Panel4.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtDate, Me.lblDate})
            Me.Panel4.Location = New System.Drawing.Point(8, 272)
            Me.Panel4.Name = "Panel4"
            Me.Panel4.Size = New System.Drawing.Size(144, 32)
            Me.Panel4.TabIndex = 5
            Me.Panel4.Visible = False
            '
            'txtDate
            '
            Me.txtDate.Location = New System.Drawing.Point(72, 8)
            Me.txtDate.Name = "txtDate"
            Me.txtDate.Size = New System.Drawing.Size(88, 20)
            Me.txtDate.TabIndex = 1
            Me.txtDate.Text = ""
            '
            'lblDate
            '
            Me.lblDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDate.Location = New System.Drawing.Point(8, 8)
            Me.lblDate.Name = "lblDate"
            Me.lblDate.Size = New System.Drawing.Size(56, 16)
            Me.lblDate.TabIndex = 17
            Me.lblDate.Text = "DATE:"
            Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboMadeIn
            '
            Me.cboMadeIn.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboMadeIn.AutoCompletion = True
            Me.cboMadeIn.AutoDropDown = True
            Me.cboMadeIn.AutoSelect = True
            Me.cboMadeIn.Caption = ""
            Me.cboMadeIn.CaptionHeight = 17
            Me.cboMadeIn.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboMadeIn.ColumnCaptionHeight = 17
            Me.cboMadeIn.ColumnFooterHeight = 17
            Me.cboMadeIn.ColumnHeaders = False
            Me.cboMadeIn.ContentHeight = 15
            Me.cboMadeIn.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboMadeIn.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboMadeIn.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboMadeIn.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboMadeIn.EditorHeight = 15
            Me.cboMadeIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboMadeIn.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboMadeIn.ItemHeight = 15
            Me.cboMadeIn.Location = New System.Drawing.Point(408, 128)
            Me.cboMadeIn.MatchEntryTimeout = CType(2000, Long)
            Me.cboMadeIn.MaxDropDownItems = CType(10, Short)
            Me.cboMadeIn.MaxLength = 32767
            Me.cboMadeIn.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboMadeIn.Name = "cboMadeIn"
            Me.cboMadeIn.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboMadeIn.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboMadeIn.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboMadeIn.Size = New System.Drawing.Size(197, 21)
            Me.cboMadeIn.TabIndex = 9
            Me.cboMadeIn.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'cboLabelType
            '
            Me.cboLabelType.Items.AddRange(New Object() {"Label", "Relabel"})
            Me.cboLabelType.Location = New System.Drawing.Point(96, 8)
            Me.cboLabelType.Name = "cboLabelType"
            Me.cboLabelType.Size = New System.Drawing.Size(179, 21)
            Me.cboLabelType.TabIndex = 0
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.Location = New System.Drawing.Point(16, 8)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(80, 16)
            Me.Label1.TabIndex = 27
            Me.Label1.Text = "Label Type:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtFCCID
            '
            Me.txtFCCID.Enabled = False
            Me.txtFCCID.Location = New System.Drawing.Point(408, 320)
            Me.txtFCCID.Name = "txtFCCID"
            Me.txtFCCID.Size = New System.Drawing.Size(197, 20)
            Me.txtFCCID.TabIndex = 14
            Me.txtFCCID.Text = ""
            '
            'lblFCC
            '
            Me.lblFCC.Enabled = False
            Me.lblFCC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblFCC.Location = New System.Drawing.Point(336, 320)
            Me.lblFCC.Name = "lblFCC"
            Me.lblFCC.Size = New System.Drawing.Size(72, 16)
            Me.lblFCC.TabIndex = 24
            Me.lblFCC.Text = "FCC ID:"
            Me.lblFCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtModelNo
            '
            Me.txtModelNo.Enabled = False
            Me.txtModelNo.Location = New System.Drawing.Point(408, 288)
            Me.txtModelNo.Name = "txtModelNo"
            Me.txtModelNo.Size = New System.Drawing.Size(197, 20)
            Me.txtModelNo.TabIndex = 13
            Me.txtModelNo.Text = ""
            '
            'txtTFModelNo
            '
            Me.txtTFModelNo.Enabled = False
            Me.txtTFModelNo.Location = New System.Drawing.Point(408, 256)
            Me.txtTFModelNo.Name = "txtTFModelNo"
            Me.txtTFModelNo.Size = New System.Drawing.Size(197, 20)
            Me.txtTFModelNo.TabIndex = 12
            Me.txtTFModelNo.Text = ""
            '
            'lblTFModel
            '
            Me.lblTFModel.Enabled = False
            Me.lblTFModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTFModel.Location = New System.Drawing.Point(328, 256)
            Me.lblTFModel.Name = "lblTFModel"
            Me.lblTFModel.Size = New System.Drawing.Size(80, 16)
            Me.lblTFModel.TabIndex = 21
            Me.lblTFModel.Text = "TFModel No:"
            Me.lblTFModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblModel
            '
            Me.lblModel.Enabled = False
            Me.lblModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModel.Location = New System.Drawing.Point(328, 288)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(80, 16)
            Me.lblModel.TabIndex = 11
            Me.lblModel.Text = "Model No:"
            Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblMadeIn
            '
            Me.lblMadeIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMadeIn.Location = New System.Drawing.Point(336, 128)
            Me.lblMadeIn.Name = "lblMadeIn"
            Me.lblMadeIn.Size = New System.Drawing.Size(72, 16)
            Me.lblMadeIn.TabIndex = 7
            Me.lblMadeIn.Text = "Made in:"
            Me.lblMadeIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Panel5
            '
            Me.Panel5.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblSW, Me.txtSW})
            Me.Panel5.Location = New System.Drawing.Point(448, 152)
            Me.Panel5.Name = "Panel5"
            Me.Panel5.Size = New System.Drawing.Size(168, 35)
            Me.Panel5.TabIndex = 10
            Me.Panel5.Visible = False
            '
            'lblSW
            '
            Me.lblSW.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSW.Location = New System.Drawing.Point(8, 8)
            Me.lblSW.Name = "lblSW"
            Me.lblSW.Size = New System.Drawing.Size(40, 16)
            Me.lblSW.TabIndex = 13
            Me.lblSW.Text = "SW:"
            Me.lblSW.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtSW
            '
            Me.txtSW.Location = New System.Drawing.Point(56, 8)
            Me.txtSW.Name = "txtSW"
            Me.txtSW.Size = New System.Drawing.Size(109, 20)
            Me.txtSW.TabIndex = 1
            Me.txtSW.Text = ""
            '
            'Panel1
            '
            Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtBtAddr, Me.lblBtAddr})
            Me.Panel1.Location = New System.Drawing.Point(8, 152)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(280, 24)
            Me.Panel1.TabIndex = 2
            Me.Panel1.Visible = False
            '
            'txtBtAddr
            '
            Me.txtBtAddr.Location = New System.Drawing.Point(88, 0)
            Me.txtBtAddr.Name = "txtBtAddr"
            Me.txtBtAddr.Size = New System.Drawing.Size(184, 20)
            Me.txtBtAddr.TabIndex = 1
            Me.txtBtAddr.Text = ""
            '
            'lblBtAddr
            '
            Me.lblBtAddr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBtAddr.Location = New System.Drawing.Point(-8, 0)
            Me.lblBtAddr.Name = "lblBtAddr"
            Me.lblBtAddr.Size = New System.Drawing.Size(88, 16)
            Me.lblBtAddr.TabIndex = 26
            Me.lblBtAddr.Text = "BtAddr:"
            Me.lblBtAddr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Panel2
            '
            Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblPNo, Me.txtProdCode, Me.txtPNo, Me.lblProdCode})
            Me.Panel2.Location = New System.Drawing.Point(8, 184)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(280, 48)
            Me.Panel2.TabIndex = 3
            Me.Panel2.Visible = False
            '
            'lblPNo
            '
            Me.lblPNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPNo.Location = New System.Drawing.Point(27, 24)
            Me.lblPNo.Name = "lblPNo"
            Me.lblPNo.Size = New System.Drawing.Size(62, 16)
            Me.lblPNo.TabIndex = 9
            Me.lblPNo.Text = "P No:"
            Me.lblPNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtProdCode
            '
            Me.txtProdCode.Location = New System.Drawing.Point(88, 0)
            Me.txtProdCode.Name = "txtProdCode"
            Me.txtProdCode.Size = New System.Drawing.Size(109, 20)
            Me.txtProdCode.TabIndex = 1
            Me.txtProdCode.Text = "(G 8/19)"
            '
            'txtPNo
            '
            Me.txtPNo.Location = New System.Drawing.Point(88, 24)
            Me.txtPNo.Name = "txtPNo"
            Me.txtPNo.Size = New System.Drawing.Size(179, 20)
            Me.txtPNo.TabIndex = 1
            Me.txtPNo.Text = ""
            '
            'lblProdCode
            '
            Me.lblProdCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblProdCode.Location = New System.Drawing.Point(16, 0)
            Me.lblProdCode.Name = "lblProdCode"
            Me.lblProdCode.Size = New System.Drawing.Size(72, 20)
            Me.lblProdCode.TabIndex = 15
            Me.lblProdCode.Text = "Prod Code:"
            Me.lblProdCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Panel3
            '
            Me.Panel3.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtN, Me.txtHW, Me.lblHWREV})
            Me.Panel3.Location = New System.Drawing.Point(8, 240)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(280, 32)
            Me.Panel3.TabIndex = 4
            Me.Panel3.Visible = False
            '
            'txtN
            '
            Me.txtN.Location = New System.Drawing.Point(184, 8)
            Me.txtN.Name = "txtN"
            Me.txtN.Size = New System.Drawing.Size(85, 20)
            Me.txtN.TabIndex = 2
            Me.txtN.Text = ""
            '
            'txtHW
            '
            Me.txtHW.Location = New System.Drawing.Point(88, 8)
            Me.txtHW.Name = "txtHW"
            Me.txtHW.Size = New System.Drawing.Size(88, 20)
            Me.txtHW.TabIndex = 1
            Me.txtHW.Text = ""
            '
            'lblHWREV
            '
            Me.lblHWREV.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblHWREV.Location = New System.Drawing.Point(16, 8)
            Me.lblHWREV.Name = "lblHWREV"
            Me.lblHWREV.Size = New System.Drawing.Size(72, 16)
            Me.lblHWREV.TabIndex = 19
            Me.lblHWREV.Text = "H/W REV:"
            Me.lblHWREV.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Panel7
            '
            Me.Panel7.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblSSID, Me.txtSSID})
            Me.Panel7.Location = New System.Drawing.Point(288, 0)
            Me.Panel7.Name = "Panel7"
            Me.Panel7.Size = New System.Drawing.Size(152, 24)
            Me.Panel7.TabIndex = 27
            Me.Panel7.Visible = False
            '
            'lblSSID
            '
            Me.lblSSID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSSID.Location = New System.Drawing.Point(8, 0)
            Me.lblSSID.Name = "lblSSID"
            Me.lblSSID.Size = New System.Drawing.Size(40, 16)
            Me.lblSSID.TabIndex = 30
            Me.lblSSID.Text = "SSID:"
            Me.lblSSID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtSSID
            '
            Me.txtSSID.Location = New System.Drawing.Point(64, 0)
            Me.txtSSID.Name = "txtSSID"
            Me.txtSSID.Size = New System.Drawing.Size(88, 20)
            Me.txtSSID.TabIndex = 29
            Me.txtSSID.Text = ""
            '
            'Panel12
            '
            Me.Panel12.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtBluetooth, Me.lblBluetooth})
            Me.Panel12.Location = New System.Drawing.Point(8, 312)
            Me.Panel12.Name = "Panel12"
            Me.Panel12.Size = New System.Drawing.Size(280, 32)
            Me.Panel12.TabIndex = 31
            Me.Panel12.Visible = False
            '
            'txtBluetooth
            '
            Me.txtBluetooth.Location = New System.Drawing.Point(168, 8)
            Me.txtBluetooth.Name = "txtBluetooth"
            Me.txtBluetooth.Size = New System.Drawing.Size(104, 20)
            Me.txtBluetooth.TabIndex = 1
            Me.txtBluetooth.Text = ""
            '
            'lblBluetooth
            '
            Me.lblBluetooth.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBluetooth.Location = New System.Drawing.Point(12, 8)
            Me.lblBluetooth.Name = "lblBluetooth"
            Me.lblBluetooth.Size = New System.Drawing.Size(148, 16)
            Me.lblBluetooth.TabIndex = 17
            Me.lblBluetooth.Text = "Bluetooth Declaration ID: "
            Me.lblBluetooth.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboModels
            '
            Me.cboModels.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboModels.Caption = ""
            Me.cboModels.CaptionHeight = 17
            Me.cboModels.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboModels.ColumnCaptionHeight = 17
            Me.cboModels.ColumnFooterHeight = 17
            Me.cboModels.ContentHeight = 15
            Me.cboModels.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboModels.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboModels.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboModels.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboModels.EditorHeight = 15
            Me.cboModels.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboModels.ItemHeight = 15
            Me.cboModels.Location = New System.Drawing.Point(8, 40)
            Me.cboModels.MatchEntryTimeout = CType(2000, Long)
            Me.cboModels.MaxDropDownItems = CType(5, Short)
            Me.cboModels.MaxLength = 32767
            Me.cboModels.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModels.Name = "cboModels"
            Me.cboModels.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModels.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModels.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModels.Size = New System.Drawing.Size(176, 21)
            Me.cboModels.TabIndex = 31
            Me.cboModels.Visible = False
            Me.cboModels.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'lblModels
            '
            Me.lblModels.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModels.Location = New System.Drawing.Point(8, 24)
            Me.lblModels.Name = "lblModels"
            Me.lblModels.Size = New System.Drawing.Size(64, 16)
            Me.lblModels.TabIndex = 29
            Me.lblModels.Text = "Model:"
            Me.lblModels.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblModels.Visible = False
            '
            'cmdlblprint
            '
            Me.cmdlblprint.BackColor = System.Drawing.Color.Green
            Me.cmdlblprint.Enabled = False
            Me.cmdlblprint.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdlblprint.ForeColor = System.Drawing.Color.White
            Me.cmdlblprint.Location = New System.Drawing.Point(176, 16)
            Me.cmdlblprint.Name = "cmdlblprint"
            Me.cmdlblprint.Size = New System.Drawing.Size(112, 80)
            Me.cmdlblprint.TabIndex = 12
            Me.cmdlblprint.Text = "Print "
            '
            'C1Combo1
            '
            Me.C1Combo1.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.C1Combo1.Caption = ""
            Me.C1Combo1.CaptionHeight = 17
            Me.C1Combo1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.C1Combo1.ColumnCaptionHeight = 19
            Me.C1Combo1.ColumnFooterHeight = 19
            Me.C1Combo1.ContentHeight = 14
            Me.C1Combo1.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.C1Combo1.EditorBackColor = System.Drawing.SystemColors.Window
            Me.C1Combo1.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.C1Combo1.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.C1Combo1.EditorHeight = 14
            Me.C1Combo1.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.C1Combo1.ItemHeight = 15
            Me.C1Combo1.Location = New System.Drawing.Point(520, 320)
            Me.C1Combo1.MatchEntryTimeout = CType(2000, Long)
            Me.C1Combo1.MaxDropDownItems = CType(5, Short)
            Me.C1Combo1.MaxLength = 32767
            Me.C1Combo1.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.C1Combo1.Name = "C1Combo1"
            Me.C1Combo1.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.C1Combo1.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.C1Combo1.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.C1Combo1.Size = New System.Drawing.Size(215, 20)
            Me.C1Combo1.TabIndex = 0
            Me.C1Combo1.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
            "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style9{AlignHorz:Near;}OddRow{}Reco" & _
            "rdSelector{AlignImage:Center;}Heading{Wrap:True;AlignVert:Center;Border:Raised,," & _
            "1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{}Style11{}St" & _
            "yle1{}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" " & _
            "Name=""Split[0,0]"" CaptionHeight=""19"" ColumnCaptionHeight=""19"" ColumnFooterHeight" & _
            "=""19"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 1" & _
            "56</ClientRect><Height>156</Height><VScrollBar><Width>20</Width></VScrollBar><HS" & _
            "crollBar><Height>20</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style" & _
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
            'grbLabelSetUpInfo
            '
            Me.grbLabelSetUpInfo.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblLabelSize, Me.lblFCCID, Me.lblModelNo2, Me.lblModelNo1, Me.lblName, Me.Label5, Me.lblModels, Me.cboModels})
            Me.grbLabelSetUpInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grbLabelSetUpInfo.ForeColor = System.Drawing.Color.White
            Me.grbLabelSetUpInfo.Location = New System.Drawing.Point(640, 1)
            Me.grbLabelSetUpInfo.Name = "grbLabelSetUpInfo"
            Me.grbLabelSetUpInfo.Size = New System.Drawing.Size(216, 359)
            Me.grbLabelSetUpInfo.TabIndex = 13
            Me.grbLabelSetUpInfo.TabStop = False
            Me.grbLabelSetUpInfo.Text = "Label Criteria"
            Me.grbLabelSetUpInfo.Visible = False
            '
            'lblLabelSize
            '
            Me.lblLabelSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLabelSize.ForeColor = System.Drawing.Color.Gold
            Me.lblLabelSize.Location = New System.Drawing.Point(8, 176)
            Me.lblLabelSize.Name = "lblLabelSize"
            Me.lblLabelSize.Size = New System.Drawing.Size(200, 16)
            Me.lblLabelSize.TabIndex = 37
            Me.lblLabelSize.Text = "Model# 1: MOTOROLA INC."
            Me.lblLabelSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblFCCID
            '
            Me.lblFCCID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblFCCID.ForeColor = System.Drawing.Color.Gold
            Me.lblFCCID.Location = New System.Drawing.Point(8, 152)
            Me.lblFCCID.Name = "lblFCCID"
            Me.lblFCCID.Size = New System.Drawing.Size(200, 16)
            Me.lblFCCID.TabIndex = 36
            Me.lblFCCID.Text = "Model# 1: MOTOROLA INC."
            Me.lblFCCID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblModelNo2
            '
            Me.lblModelNo2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModelNo2.ForeColor = System.Drawing.Color.Gold
            Me.lblModelNo2.Location = New System.Drawing.Point(8, 128)
            Me.lblModelNo2.Name = "lblModelNo2"
            Me.lblModelNo2.Size = New System.Drawing.Size(200, 16)
            Me.lblModelNo2.TabIndex = 35
            Me.lblModelNo2.Text = "Model# 1: MOTOROLA INC."
            Me.lblModelNo2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblModelNo1
            '
            Me.lblModelNo1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModelNo1.ForeColor = System.Drawing.Color.Gold
            Me.lblModelNo1.Location = New System.Drawing.Point(8, 104)
            Me.lblModelNo1.Name = "lblModelNo1"
            Me.lblModelNo1.Size = New System.Drawing.Size(200, 16)
            Me.lblModelNo1.TabIndex = 34
            Me.lblModelNo1.Text = "Model# 1: MOTOROLA INC."
            Me.lblModelNo1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblName
            '
            Me.lblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblName.ForeColor = System.Drawing.Color.Gold
            Me.lblName.Location = New System.Drawing.Point(8, 80)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(200, 16)
            Me.lblName.TabIndex = 33
            Me.lblName.Text = "Label_Motorola_V600G_ATT.rpt"
            Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label5
            '
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.Gold
            Me.Label5.Location = New System.Drawing.Point(8, 64)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(200, 16)
            Me.Label5.TabIndex = 32
            Me.Label5.Text = "Name:"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnViewLabelSetUpInfo
            '
            Me.btnViewLabelSetUpInfo.BackColor = System.Drawing.Color.Green
            Me.btnViewLabelSetUpInfo.Enabled = False
            Me.btnViewLabelSetUpInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnViewLabelSetUpInfo.ForeColor = System.Drawing.Color.White
            Me.btnViewLabelSetUpInfo.Location = New System.Drawing.Point(520, 376)
            Me.btnViewLabelSetUpInfo.Name = "btnViewLabelSetUpInfo"
            Me.btnViewLabelSetUpInfo.Size = New System.Drawing.Size(185, 46)
            Me.btnViewLabelSetUpInfo.TabIndex = 14
            Me.btnViewLabelSetUpInfo.Text = "View Label Set Up Info"
            Me.btnViewLabelSetUpInfo.Visible = False
            '
            'btnRemoveLabelInfo
            '
            Me.btnRemoveLabelInfo.BackColor = System.Drawing.Color.Olive
            Me.btnRemoveLabelInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveLabelInfo.ForeColor = System.Drawing.Color.White
            Me.btnRemoveLabelInfo.Location = New System.Drawing.Point(320, 376)
            Me.btnRemoveLabelInfo.Name = "btnRemoveLabelInfo"
            Me.btnRemoveLabelInfo.Size = New System.Drawing.Size(185, 46)
            Me.btnRemoveLabelInfo.TabIndex = 15
            Me.btnRemoveLabelInfo.Text = "Remove SN && Date Code"
            '
            'btnResetManufDateCode
            '
            Me.btnResetManufDateCode.BackColor = System.Drawing.Color.DarkGray
            Me.btnResetManufDateCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnResetManufDateCode.ForeColor = System.Drawing.Color.White
            Me.btnResetManufDateCode.Location = New System.Drawing.Point(320, 424)
            Me.btnResetManufDateCode.Name = "btnResetManufDateCode"
            Me.btnResetManufDateCode.Size = New System.Drawing.Size(184, 46)
            Me.btnResetManufDateCode.TabIndex = 16
            Me.btnResetManufDateCode.Text = "Reset Date Code"
            '
            'chkBoxIntermec
            '
            Me.chkBoxIntermec.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkBoxIntermec.Location = New System.Drawing.Point(8, 24)
            Me.chkBoxIntermec.Name = "chkBoxIntermec"
            Me.chkBoxIntermec.Size = New System.Drawing.Size(176, 24)
            Me.chkBoxIntermec.TabIndex = 17
            Me.chkBoxIntermec.Text = "Intermec Printer"
            '
            'grpBoxPrint
            '
            Me.grpBoxPrint.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdlblprint, Me.ChkBoxNoIntermec, Me.chkBoxIntermec})
            Me.grpBoxPrint.Location = New System.Drawing.Point(16, 368)
            Me.grpBoxPrint.Name = "grpBoxPrint"
            Me.grpBoxPrint.Size = New System.Drawing.Size(296, 104)
            Me.grpBoxPrint.TabIndex = 18
            Me.grpBoxPrint.TabStop = False
            Me.grpBoxPrint.Text = "Print"
            '
            'ChkBoxNoIntermec
            '
            Me.ChkBoxNoIntermec.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ChkBoxNoIntermec.Location = New System.Drawing.Point(8, 56)
            Me.ChkBoxNoIntermec.Name = "ChkBoxNoIntermec"
            Me.ChkBoxNoIntermec.Size = New System.Drawing.Size(176, 24)
            Me.ChkBoxNoIntermec.TabIndex = 18
            Me.ChkBoxNoIntermec.Text = "Other Label Printer"
            '
            'frmLabel
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(864, 486)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpBoxPrint, Me.btnRemoveLabelInfo, Me.btnViewLabelSetUpInfo, Me.grbLabelSetUpInfo, Me.pnlMain, Me.btnResetManufDateCode})
            Me.Name = "frmLabel"
            Me.Text = "frmLabel"
            Me.pnlMain.ResumeLayout(False)
            Me.Panel13.ResumeLayout(False)
            Me.Panel11.ResumeLayout(False)
            Me.Panel10.ResumeLayout(False)
            Me.Panel9.ResumeLayout(False)
            Me.Panel8.ResumeLayout(False)
            Me.pnlSjug.ResumeLayout(False)
            CType(Me.cboSJUG, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel6.ResumeLayout(False)
            Me.pnlESN.ResumeLayout(False)
            Me.pnlMSNSN.ResumeLayout(False)
            Me.Panel4.ResumeLayout(False)
            CType(Me.cboMadeIn, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel5.ResumeLayout(False)
            Me.Panel1.ResumeLayout(False)
            Me.Panel2.ResumeLayout(False)
            Me.Panel3.ResumeLayout(False)
            Me.Panel7.ResumeLayout(False)
            Me.Panel12.ResumeLayout(False)
            CType(Me.cboModels, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.C1Combo1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grbLabelSetUpInfo.ResumeLayout(False)
            Me.grpBoxPrint.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        '******************************************************************
        Private Sub frmLabel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable

            Try
                Me.cboLabelType.SelectedIndex = 0
                Me.txtIMEI.Focus()

                dt = _objTracLabel.GetManufCountry(True)
                Misc.PopulateC1DropDownList(Me.cboMadeIn, dt, "mc_name", "mc_id")
                Me.cboMadeIn.SelectedValue = 1

                Me.btnResetManufDateCode.Visible = False
                If Me._iMenuCustID = PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID Then
                    Me.btnRemoveLabelInfo.Visible = False
                    Me.btnViewLabelSetUpInfo.Visible = False

                End If

                ' MessageBox.Show(_strOSInfo.Platform.ToString & "    " & _strOSInfo.Version.ToString)

                If Me._iMenuCustID = PSS.Data.Buisness.TracFone.Admin.CUSTOMER_ID Then
                    Me.ChkBoxNoIntermec.Checked = True
                    Me.chkBoxIntermec.Enabled = False 'TF label uses Non-Intermec printer now as default
                ElseIf Me._iMenuCustID = PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID Then
                    Me.ChkBoxNoIntermec.Checked = True
                    Me.chkBoxIntermec.Enabled = False 'WIKO label uses Non-Intermec printer now as default
                    Me.btnRemoveLabelInfo.Visible = False
                    Me.btnViewLabelSetUpInfo.Visible = False
                    Me.lblTFModel.Text = "Model:"
                    Me.lblModel.Text = "SKU:"
                End If


            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmLabel_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '******************************************************************
        Private Sub FillLabelInfo_Label()
            Dim dt1, dt, dt2 As DataTable
            Dim R1 As DataRow
            Dim strWorkStation As String = " "
            Dim strMEIDHEX As String = ""
            Dim strMEIDDEC As String = ""
            'Dim strIMEI_Alt As String = ""

            Try
                If Me._iMenuCustID = PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID Then
                    dt1 = Me._objTracLabel.GetWiKoDeviceInfoForLabel(Trim(Me.txtIMEI.Text), Me._iMenuCustID)
                Else
                    dt1 = Me._objTracLabel.GetTracDeviceInfoForLabel(Trim(Me.txtIMEI.Text), Me._iMenuCustID)
                End If

                If dt1.Rows.Count > 0 Then
                    If dt1.Rows.Count > 1 Then
                        Throw New Exception("Serial #'s duplicated in the system. Please contact IT.")
                    ElseIf Not Me._iMenuCustID = PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID Then
                        If Me.cboLabelType.SelectedIndex = 0 Then
                            strWorkStation = dt1.Rows(0)("WorkStation").ToString.Trim.ToUpper
                            If strWorkStation <> "LABEL" Then
                                MessageBox.Show("This device belongs to " & dt1.Rows(0)("WorkStation").ToString & " workstation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                Me.txtIMEI.Text = ""
                                Exit Sub
                            End If
                        End If
                    End If
                Else
                    MessageBox.Show("The device scanned in does not exist or already shipped.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                    Exit Sub
                End If

                _iDevice_ID = dt1.Rows(0)("Device_id")
                _iModel_ID = dt1.Rows(0)("Model_id")

                dt2 = Me._objTracLabel.GetLabelPanel(_iModel_ID)
                If dt2.Rows.Count = 0 Then
                    MessageBox.Show("This model doesn't exist for label at the moment. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                '********************************
                'Display Label Panel(s)
                '********************************
                If dt2.Rows(0)("Panel1") = 1 Then
                    Me.Panel1.Visible = True
                    If dt1.Rows(0)("BT_Addr") <> "" Then : Me.txtBtAddr.Text = dt1.Rows(0)("BT_Addr") : End If
                End If

                If dt2.Rows(0)("Panel2") = 1 Then
                    Me.Panel2.Visible = True

                    If dt1.Rows(0)("P_No") <> "" Then : Me.txtPNo.Text = dt1.Rows(0)("P_No") : End If
                    If dt1.Rows(0)("Prod_Code") <> "" Then : Me.txtProdCode.Text = dt1.Rows(0)("Prod_Code") : End If
                End If

                If dt2.Rows(0)("Panel3") = 1 Then
                    Me.Panel3.Visible = True
                    If Not dt1.Rows(0).IsNull("HW_REV1") AndAlso dt1.Rows(0)("HW_REV1") <> "" Then : Me.txtHW.Text = dt1.Rows(0)("HW_REV1") : End If
                    If Not dt1.Rows(0).IsNull("HW_REV2") AndAlso dt1.Rows(0)("HW_REV2") <> "" Then : Me.txtN.Text = dt1.Rows(0)("HW_REV2") : End If
                End If

                'Panel 4
                If dt2.Rows(0)("Panel4") = 1 Then
                    Me.Panel4.Visible = True
                    Me.btnResetManufDateCode.Visible = False
                    If dt1.Rows(0)("Manuf_Date").ToString.Trim <> "" Then
                        Me.txtDate.Text = dt1.Rows(0)("Manuf_Date").ToString.Trim
                        Me.txtDate.Enabled = False
                    Else
                        Me.txtDate.Enabled = True
                    End If
                    If Me._iMenuCustID = PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID Then Me.btnResetManufDateCode.Visible = True
                End If

                'Panel 5
                If dt2.Rows(0)("Panel5") = 1 Then
                    Me.Panel5.Visible = True
                    If Not IsDBNull(dt1.Rows(0)("cellopt_softverin")) Then : Me.txtSW.Text = dt1.Rows(0)("cellopt_softverin") : End If
                End If

                'Panel 6
                If dt2.Rows(0)("Panel6") = 1 Then
                    Me.Panel6.Visible = True
                    If Not IsDBNull(dt1.Rows(0)("ManufProdSN")) Then : Me.txtManufProdSN.Text = dt1.Rows(0)("ManufProdSN") : End If
                    If Not IsDBNull(dt1.Rows(0)("ManufSEQ")) Then : Me.txtSeq.Text = dt1.Rows(0)("ManufSEQ") : End If
                End If

                'Panel 7: SSID
                If dt2.Rows(0)("Panel7") = 1 Then
                    Me.Panel7.Visible = True
                    If Not IsDBNull(dt1.Rows(0)("CellOpt_SSID")) Then
                        Me.txtSSID.Text = dt1.Rows(0)("CellOpt_SSID") : Me.txtSSID.Enabled = False
                    Else
                        Me.txtSSID.Enabled = True
                    End If
                End If

                'Panel 8: IMEI HEX
                If dt2.Rows(0)("Panel8") = 1 Then
                    Me.Panel8.Visible = True
                    Dim strIMEI_HEX As String
                    If Me.txtIMEI.Text.Trim.Length > 0 Then
                        strIMEI_HEX = Me._objTracLabel.GetIMEI_HEX(Me.txtIMEI.Text.Trim)
                        Me.txtIMEI_HEX.Text = strIMEI_HEX
                    End If
                End If

                'Panel 9: Label Location
                If dt2.Rows(0)("Panel9") = 1 Then
                    Me.Panel9.Visible = True
                    If dt1.Rows(0)("Label_Location").ToString.Trim <> "" Then
                        Me.txtLocation.Text = dt1.Rows(0)("Label_Location").ToString.Trim
                        Me.txtLocation.Enabled = False
                    Else
                        Me.txtLocation.Enabled = True
                    End If
                End If

                'Panel 10: MEID HEX
                If dt2.Rows(0)("Panel10") = 1 Then
                    Me.Panel10.Visible = True
                    If Me.txtIMEI.Text.Trim.Length > 0 Then
                        If Me._objTracLabel.GetMEIDHEXDEC_IMEIAlt(Me.txtIMEI.Text.Trim, strMEIDHEX, strMEIDDEC) Then
                            Me.txtMEIDHEX.Text = strMEIDHEX
                        End If
                    End If
                End If

                'Panel 11: MEID DEC
                If dt2.Rows(0)("Panel11") = 1 Then
                    Me.Panel11.Visible = True
                    If Me.txtIMEI.Text.Trim.Length > 0 Then
                        If Me._objTracLabel.GetMEIDHEXDEC_IMEIAlt(Me.txtIMEI.Text.Trim, strMEIDHEX, strMEIDDEC) Then
                            Me.txtMEIDDEC.Text = strMEIDDEC
                        End If
                    End If
                End If

                'Panel 12: Label Bluetooth Declaration ID
                If dt2.Rows(0)("Panel12") = 1 Then
                    Me.Panel12.Visible = True
                    If dt1.Rows(0)("Label_BlueTooth").ToString.Trim <> "" Then
                        Me.txtBluetooth.Text = dt1.Rows(0)("Label_BlueTooth").ToString.Trim
                        Me.txtBluetooth.Enabled = False
                    Else
                        Me.txtBluetooth.Enabled = True
                    End If
                End If

                'Panel 13: Label_WebUIPassword
                If dt2.Rows(0)("Panel13") = 1 Then
                    Me.Panel13.Visible = True
                    If dt1.Rows(0)("Label_WebUIPassword").ToString.Trim <> "" Then
                        Me.txtWebUIPW.Text = dt1.Rows(0)("Label_WebUIPassword").ToString.Trim
                        Me.txtWebUIPW.Enabled = False
                    Else
                        Me.txtWebUIPW.Enabled = True
                    End If
                End If

                'SJUG #
                If CInt(dt1.Rows(0)("Manuf_ID")) = 1 Then
                    dt = _objTracLabel.GetSug(True, _iModel_ID)
                    Misc.PopulateC1DropDownList(Me.cboSJUG, dt, "lensSUG_text", "LensSUG_ID")
                    Me.cboSJUG.SelectedValue = 0

                    If Not IsDBNull(dt1.Rows(0)("cellopt_sugin")) AndAlso dt.Select("lensSUG_text = '" & dt1.Rows(0)("cellopt_sugin") & "'").Length > 0 Then : Me.cboSJUG.SelectedValue = dt.Select("lensSUG_text = '" & dt1.Rows(0)("cellopt_sugin") & "'")(0)("LensSUG_ID") : End If

                    Me.pnlSjug.Visible = True
                Else
                    Me.pnlSjug.Visible = False
                End If
                If dt2.Rows(0)("pnlSJUG") = 2 Then 'override it
                    Me.pnlSjug.Visible = False
                End If

                'MSN/SN
                Me.pnlMSNSN.Visible = True
                If CInt(dt1.Rows(0)("Manuf_ID")) = 1 Or CInt(dt1.Rows(0)("Manuf_ID")) = 16 Or CInt(dt1.Rows(0)("Manuf_ID")) = 24 Or _
                   CInt(dt1.Rows(0)("Manuf_ID")) = 48 Or (CInt(dt1.Rows(0)("Manuf_ID")) = 21 Or CInt(dt1.Rows(0)("Manuf_ID")) = 201 And _
                   Me.txtIMEI.Text.Trim.Length < 17) Then
                    If Not IsDBNull(dt1.Rows(0)("cellopt_msn")) AndAlso dt1.Rows(0)("cellopt_msn").ToString.Trim.Length > 0 Then
                        Me.txtSNMSN.Text = dt1.Rows(0)("cellopt_msn").ToString.Trim.ToUpper
                        Me.txtSNMSN.Enabled = False
                    Else
                        Me.txtSNMSN.Enabled = True
                    End If
                    Me.pnlMSNSN.Visible = True
                End If
                If dt2.Rows(0)("pnlMSNSN") = 2 Then 'override it
                    Me.txtSNMSN.Text = ""
                    Me.pnlMSNSN.Visible = False
                End If

                'Corrected ZF
                ''MEID HEX  'tentatively add this, ZF. 
                'If CInt(dt1.Rows(0)("Manuf_ID")) = 201 AndAlso (CInt(dt1.Rows(0)("Model_ID")) = 3714 Or CInt(dt1.Rows(0)("Model_ID")) = 3715 _
                '                                                Or CInt(dt1.Rows(0)("Model_ID")) = 3742 Or CInt(dt1.Rows(0)("Model_ID")) = 3743 _
                '                                                Or CInt(dt1.Rows(0)("Model_ID")) = 3710 Or CInt(dt1.Rows(0)("Model_ID")) = 3711 _
                '                                                Or CInt(dt1.Rows(0)("Model_ID")) = 3835 Or CInt(dt1.Rows(0)("Model_ID")) = 3836 _
                '                                                ) Then
                '    Me.lblBtAddr.Text = "MEID HEX:"
                'End If

                'CSN
                If Me.txtIMEI.Text.Trim.Length > 17 AndAlso CInt(dt1.Rows(0)("Manuf_ID")) <> 16 Then
                    If Not IsDBNull(dt1.Rows(0)("CellOpt_CSN")) AndAlso dt1.Rows(0)("CellOpt_CSN").ToString.Trim.Length > 0 Then
                        Me.txtESN.Text = dt1.Rows(0)("CellOpt_CSN").ToString.Trim.ToUpper
                        Me.txtESN.Enabled = False
                    Else
                        Me.txtESN.Enabled = True
                    End If
                    Me.pnlESN.Visible = True
                End If

                'If _iModel_ID = 4125 Or _iModel_ID = 4126 Then 'Model specific
                '    Me.pnlESN.Visible = False
                'End If
                'pnlESN:
                If dt2.Rows(0)("PanelESN") = 2 Then
                    Me.pnlESN.Visible = False
                End If

                'Made In Country
                If dt1.Rows(0)("mc_id") > 0 Then
                    Me.cboMadeIn.SelectedValue = dt1.Rows(0)("mc_id")
                Else
                    Me.cboMadeIn.SelectedValue = Me._objTracLabel.GetTracDeviceMadeInCountryIDForLabel(dt1.Rows(0)("model_id"))
                End If
                If dt2.Rows(0)("MadeIn") = 2 Then
                    Me.cboMadeIn.Visible = False : Me.lblMadeIn.Visible = False
                Else
                    Me.cboMadeIn.Visible = True : Me.lblMadeIn.Visible = True
                End If



                For Each R1 In dt1.Rows
                    If Not IsDBNull(R1("label_model_numb")) AndAlso R1("label_model_numb") <> "" Then
                        Me.txtTFModelNo.Text = Trim(R1("label_model_numb"))
                    End If

                    If Not IsDBNull(R1("label_model_numb2")) AndAlso R1("label_model_numb2") <> "" Then
                        Me.txtModelNo.Text = Trim(R1("label_model_numb2"))
                    End If

                    If Not IsDBNull(R1("label_fcc")) Then
                        Me.txtFCCID.Text = Trim(R1("label_fcc"))
                    End If

                    Exit For
                Next R1

                If Me._iMenuCustID = PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID Then
                    Me.btnRemoveLabelInfo.Visible = False
                    Me.btnViewLabelSetUpInfo.Visible = False
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "SN Scan", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
                Generic.DisposeDT(dt1)
                R1 = Nothing
            End Try
        End Sub

        '******************************************************************
        Private Sub cmdlblprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdlblprint.Click
            Const iIMEILabelBillcode As Integer = 1624
            Dim strNextWrkStation, strSjug, strMSNSN, strESN As String
            Dim i As Integer = 0
            Dim j As Integer = 0
            Dim objDevice As Rules.Device
            Dim strIMEI_Alt As String = ""
            Dim bIsIntermecPrinter As Boolean = False

            Try
                If Me._iMenuCustID = PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID Then Me.PrintWiKoLabel()

                If Me.txtIMEI.Text.Trim.Length = 0 Then Exit Sub
                If Me._iDevice_ID = 0 Then
                    MessageBox.Show("System can't define device ID. Please re-enter IMEI #.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                Me._objTracLabel.GetMEIDHEXDEC_IMEIAlt(Me.txtIMEI.Text.Trim, , , strIMEI_Alt)

                DoValidation()

                strNextWrkStation = "" : strSjug = "" : strMSNSN = "" : strESN = ""

                '*****************************************************
                'GET SJUG NUMBER
                '*****************************************************
                If Not IsNothing(Me.cboSJUG.DataSource) AndAlso Me.cboSJUG.SelectedValue > 0 Then
                    strSjug = Me.cboSJUG.DataSource.Table.Select("LensSUG_ID = " & Me.cboSJUG.SelectedValue)(0)("lensSUG_text")
                End If

                '*****************************************************
                'WE DO NOT PUSH UNIT TO ANY WORKSTATION AT THIS POINT
                '*****************************************************
                If Me.cboLabelType.SelectedIndex = 0 Then
                    strNextWrkStation = PSS.Data.Buisness.Generic.GetNextWorkStationInWFP(Me._strScreenName, 0, Me._iMenuCustID, 0)
                    If strNextWrkStation.Trim.Length > 0 Then i = Generic.SetTcelloptWorkStationForDevice(strNextWrkStation, _iDevice_ID, Core.ApplicationUser.IDuser, "Label", Me.Name, , , , , , )
                    If i > 0 Then MessageBox.Show("This device now belongs to " & strNextWrkStation & " workstation.", "Information", MessageBoxButtons.OK)
                End If

                If Me.chkBoxIntermec.Checked Then
                    bIsIntermecPrinter = True
                ElseIf Me.ChkBoxNoIntermec.Checked Then
                    bIsIntermecPrinter = False
                Else
                    MessageBox.Show("Please select printer checkbox.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                '*******************************************
                'PRINT LABEL
                '*******************************************
                j = Me._objTracLabel.PrintLabel(bIsIntermecPrinter, Trim(Me.txtModelNo.Text), (Trim(Me.txtIMEI.Text)), Trim(Me.txtFCCID.Text), _
                    UCase(Trim(Me.txtSNMSN.Text)), Me.txtESN.Text.Trim.ToUpper, Me.cboMadeIn.Text, UCase(Trim(Me.txtProdCode.Text)), Me.cboSJUG.Text, _
                    UCase(Trim(Me.txtPNo.Text)), Trim(Me.txtTFModelNo.Text), Trim(Me.txtSW.Text), UCase(Trim(Me.txtBtAddr.Text)), _
                    Trim(Me.txtHW.Text), UCase(Trim(Me.txtN.Text)), Trim(Me.txtDate.Text), Me.txtManufProdSN.Text.Trim.ToUpper, Me.txtSeq.Text.Trim.ToUpper, _
                    Trim(Me.txtIMEI_HEX.Text), Trim(Me.txtSSID.Text), Trim(Me.txtLocation.Text), Trim(Me.txtMEIDHEX.Text), Trim(Me.txtMEIDDEC.Text), _
                    strIMEI_Alt.Trim, Trim(Me.txtBluetooth.Text), Trim(Me.txtWebUIPW.Text))

                '*******************************************
                'UPDATE LABEL INFO INTO TCELLOPT TABLE
                '*******************************************
                If Me.txtSNMSN.Text.Trim.Length > 0 Then strMSNSN = Me.txtSNMSN.Text.Trim.ToUpper
                If Me.txtESN.Text.Trim.Length > 0 Then strESN = Me.txtESN.Text.Trim.ToUpper

                j = Me._objTracLabel.UpdateLabelTcell(_iDevice_ID, strMSNSN, Me.cboMadeIn.SelectedValue, UCase(Trim(Me.txtProdCode.Text)), _
                strSjug, UCase(Trim(Me.txtPNo.Text)), Trim(Me.txtSW.Text), UCase(Trim(Me.txtBtAddr.Text)), _
                Trim(Me.txtHW.Text), UCase(Trim(Me.txtN.Text)), strESN, Me.txtManufProdSN.Text.Trim.ToUpper, Me.txtSeq.Text.Trim.ToUpper, _
                Trim(Me.txtSSID.Text), Trim(Me.txtLocation.Text), Trim(Me.txtBluetooth.Text), Trim(Me.txtWebUIPW.Text))

                '*******************************************
                'BILL ( label, IMEI ) 
                '*******************************************
                objDevice = New Rules.Device(Me._iDevice_ID)
                If Generic.IsBillcodeMapped(Me._iModel_ID, iIMEILabelBillcode) > 0 AndAlso Generic.IsBillcodeExisted(Me._iDevice_ID, iIMEILabelBillcode) = False Then
                    objDevice.AddPart(iIMEILabelBillcode)
                    objDevice.Update()
                End If
                '*******************************************

                ClearVarsAndCtrls()
                Me.txtIMEI.Text = ""
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString, "Print Label", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.txtIMEI.Focus()
                If Not IsNothing(objDevice) Then
                    objDevice.Dispose()
                    objDevice = Nothing
                End If
            End Try
        End Sub

        '******************************************************************
        Private Sub PrintWiKoLabel()
            Const iIMEILabelBillcode As Integer = 1624
            Dim strNextWrkStation, strSjug, strMSNSN, strESN As String
            Dim i As Integer = 0
            Dim j As Integer = 0
            Dim objDevice As Rules.Device
            Dim strIMEI_Alt As String = ""

            Try
                If Me.txtIMEI.Text.Trim.Length = 0 Then Exit Sub
                If Me._iDevice_ID = 0 Then
                    MessageBox.Show("System can't define device ID. Please re-enter IMEI #.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                Me.Cursor = Cursors.WaitCursor
                Me.cmdlblprint.Enabled = False

                Me._objTracLabel.GetMEIDHEXDEC_IMEIAlt(Me.txtIMEI.Text.Trim, , , strIMEI_Alt)

                DoValidation()

                strNextWrkStation = "" : strSjug = "" : strMSNSN = "" : strESN = ""

                '*****************************************************
                'GET SJUG NUMBER
                '*****************************************************
                If Not IsNothing(Me.cboSJUG.DataSource) AndAlso Me.cboSJUG.SelectedValue > 0 Then
                    strSjug = Me.cboSJUG.DataSource.Table.Select("LensSUG_ID = " & Me.cboSJUG.SelectedValue)(0)("lensSUG_text")
                End If

                '*****************************************************
                'WE DO NOT PUSH UNIT TO ANY WORKSTATION AT THIS POINT - LABEL
                '*****************************************************
                'If Me.cboLabelType.SelectedIndex = 0 Then
                '    strNextWrkStation = PSS.Data.Buisness.WIKO.WIKO.WIKO_FQA_WorkStation
                '    If strNextWrkStation.Trim.Length > 0 Then i = Generic.SetTcelloptWorkStationForDevice(strNextWrkStation, _iDevice_ID, Core.ApplicationUser.IDuser, "Label", Me.Name, , , , , , )
                '    If i > 0 Then MessageBox.Show("This device now belongs to " & strNextWrkStation & " workstation.", "Information", MessageBoxButtons.OK)
                'End If

                '*******************************************
                'PRINT LABEL
                '*******************************************
                j = Me._objTracLabel.PrintLabel(False, Trim(Me.txtModelNo.Text), (Trim(Me.txtIMEI.Text)), Trim(Me.txtFCCID.Text), _
                UCase(Trim(Me.txtSNMSN.Text)), Me.txtESN.Text.Trim.ToUpper, Me.cboMadeIn.Text, UCase(Trim(Me.txtProdCode.Text)), Me.cboSJUG.Text, _
                UCase(Trim(Me.txtPNo.Text)), Trim(Me.txtTFModelNo.Text), Trim(Me.txtSW.Text), UCase(Trim(Me.txtBtAddr.Text)), _
                Trim(Me.txtHW.Text), UCase(Trim(Me.txtN.Text)), Trim(Me.txtDate.Text), Me.txtManufProdSN.Text.Trim.ToUpper, Me.txtSeq.Text.Trim.ToUpper, _
                Trim(Me.txtIMEI_HEX.Text), Trim(Me.txtSSID.Text), Trim(Me.txtLocation.Text), Trim(Me.txtMEIDHEX.Text), Trim(Me.txtMEIDDEC.Text), _
                strIMEI_Alt.Trim, Trim(Me.txtBluetooth.Text), Trim(Me.txtWebUIPW.Text))

                '*******************************************
                'UPDATE LABEL INFO INTO TCELLOPT TABLE
                '*******************************************
                j = Me._objTracLabel.UpdateWiKoLabelTCellOpt(_iDevice_ID, Me.txtDate.Text, Me.cboMadeIn.SelectedValue, _
                                                             Me.txtHW.Text.Trim, Me.txtN.Text.Trim)


                ClearVarsAndCtrls()
                Me.txtIMEI.Text = ""
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString, "Print Label", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.txtIMEI.Focus()
                Me.Cursor = Cursors.Default
                Me.cmdlblprint.Enabled = True

                If Not IsNothing(objDevice) Then
                    objDevice.Dispose()
                    objDevice = Nothing
                End If
            End Try
        End Sub
        '******************************************************************
        Private Sub DoValidation()

            If Trim(Me.txtIMEI.Text) = "" Then
                Throw New Exception("IMEI is missing.")
            ElseIf Me.pnlMSNSN.Visible = True AndAlso Trim(Me.txtSNMSN.Text) = "" Then
                Throw New Exception("SN/MSN is missing.")
            ElseIf Me.pnlESN.Visible = True AndAlso Me.txtESN.Text.Trim = "" Then
                Throw New Exception("ESN is missing.")
            ElseIf Me.cboMadeIn.Visible = True AndAlso Trim(Me.cboMadeIn.SelectedValue) < 1 Then
                Throw New Exception("Made in is missing.")
            ElseIf Me.pnlSjug.Visible = True And Me.cboSJUG.SelectedValue < 1 Then
                Throw New Exception("SJUG is missing.")
            End If

            If Panel2.Visible = True Then
                If Trim(Me.txtProdCode.Text) = "" Then
                    Throw New Exception("Prod Code is missing.")
                ElseIf Trim(Me.txtPNo.Text) = "" Then
                    Throw New Exception("P No is missing.")
                End If

                If Panel1.Visible = True Then
                    If Trim(Me.txtBtAddr.Text) = "" Then
                        Throw New Exception("btAddr is missing.")
                    End If
                End If
            End If

            If Panel3.Visible = True Then
                If Trim(Me.txtHW.Text) = "" Then
                    Throw New Exception("HW REV is missing.")
                    'ElseIf Trim(Me.txtN.Text) = "" Then
                    '    Throw New Exception("HW N is missing.")
                End If
            End If

            If Panel4.Visible = True Then
                If Trim(Me.txtDate.Text) = "" Then
                    Throw New Exception("Date is missing.")
                End If
            End If

            If Panel5.Visible = True Then
                If Trim(Me.txtSW.Text) = "" Then
                    Throw New Exception("SW is missing.")
                End If
            End If
            If Panel6.Visible = True Then
                If Trim(Me.txtManufProdSN.Text) = "" Then
                    Throw New Exception("Manufacture production serial number is missing.")
                End If
                If Me.txtSeq.Text.Trim = "" Then
                    Throw New Exception("SEQ can't be blank.")
                End If
            End If
            If Panel7.Visible = True Then
                If Trim(Me.txtSSID.Text) = "" Then
                    Throw New Exception("SSID is missing.")
                End If
            End If
            If Panel8.Visible = True Then
                If Trim(Me.txtIMEI_HEX.Text) = "" Then
                    Throw New Exception("IMEI HEX is missing.")
                End If
            End If
            If Panel9.Visible = True Then
                If Trim(Me.txtLocation.Text) = "" Then
                    Throw New Exception("Location is missing.")
                End If
            End If
            If Panel10.Visible = True Then
                If Trim(Me.txtMEIDHEX.Text) = "" Then
                    Throw New Exception("MEID HEX is missing.")
                End If
            End If
            If Panel11.Visible = True Then
                If Trim(Me.txtMEIDDEC.Text) = "" Then
                    Throw New Exception("MEID DEC is missing.")
                End If
            End If
            If Panel12.Visible = True Then
                If Trim(Me.txtBluetooth.Text) = "" Then
                    Throw New Exception("Bluetooth Declaration ID is missing.")
                End If
            End If
            If Panel13.Visible = True Then
                If Trim(Me.txtWebUIPW.Text) = "" Then
                    Throw New Exception("Web UI Password is missing.")
                End If
            End If
        End Sub

        '******************************************************************
        Private Sub ClearVarsAndCtrls()
            Me._iDevice_ID = 0
            Me._iModel_ID = 0
            Me.txtBtAddr.Text = ""
            Me.txtModelNo.Text = ""
            Me.txtFCCID.Text = ""
            Me.txtSNMSN.Text = ""
            Me.txtESN.Text = ""
            'Me.cboMadeIn.SelectedIndex = -1
            'Me.cboSJUG.SelectedIndex = -1
            'Me.txtProdCode.Text = ""
            Me.txtPNo.Text = ""
            Me.txtTFModelNo.Text = ""
            Me.txtSW.Text = ""
            Me.txtDate.Text = ""
            Me.txtLocation.Text = ""
            Me.txtBluetooth.Text = ""
            Me.txtWebUIPW.Text = ""
            Me.txtHW.Text = ""
            Me.txtN.Text = ""
            Me.txtManufProdSN.Text = ""
            Me.txtSeq.Text = ""
            Me.txtDate.Enabled = True
            Me.cmdlblprint.Enabled = False

            Me.Panel1.Visible = False
            Me.Panel2.Visible = False
            Me.Panel3.Visible = False
            Me.Panel4.Visible = False
            Me.Panel5.Visible = False
            Me.Panel6.Visible = False
            Me.Panel7.Visible = False
            Me.Panel8.Visible = False
            Me.Panel9.Visible = False
            Me.Panel10.Visible = False
            Me.Panel11.Visible = False
            Me.Panel12.Visible = False
            Me.Panel13.Visible = False
            Me.pnlMSNSN.Visible = False
            Me.pnlESN.Visible = False

        End Sub

        '*******************************************************************
        Private Sub KeyUpEvent(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIMEI.KeyUp, txtBtAddr.KeyUp, txtProdCode.KeyUp, txtPNo.KeyUp, txtSNMSN.KeyUp, txtSW.KeyUp, txtHW.KeyUp, txtN.KeyUp, txtDate.KeyUp, cboSJUG.KeyUp, cboMadeIn.KeyUp
            Try
                If e.KeyCode = Keys.Enter Then
                    Select Case sender.Name
                        Case "txtIMEI"
                            If Me.txtIMEI.Text.Trim.Length = 0 Then
                                Me.txtIMEI.Focus()
                                Exit Sub
                            ElseIf Me.txtIMEI.Text.Trim.Length > 0 Then
                                ClearVarsAndCtrls()
                                FillLabelInfo_Label()
                                cmdlblprint.Enabled = True
                                If Me.Panel1.Visible = True Then
                                    Me.txtBtAddr.Focus()
                                ElseIf Me.Panel2.Visible = True Then
                                    Me.txtProdCode.Focus()
                                ElseIf Me.Panel3.Visible = True Then
                                    Me.txtHW.Focus()
                                ElseIf Me.Panel4.Visible = True Then
                                    Me.txtDate.Focus()
                                ElseIf Me.Panel7.Visible = True Then
                                    Me.txtSSID.Focus()
                                Else
                                    Me.txtSNMSN.Focus() : End If
                            End If

                        Case "txtBtAddr"
                            If Me.txtBtAddr.Text.Trim.Length > 0 Then
                                Me.txtProdCode.Focus()
                            Else
                                Me.txtBtAddr.Focus()
                            End If

                        Case "txtProdCode"
                            If Me.txtProdCode.Text.Trim.Length > 0 Then
                                Me.cboSJUG.Focus()
                            Else
                                Me.txtProdCode.Focus()
                            End If

                        Case "cboSJUG"
                            If Me.cboSJUG.SelectedValue > 0 Then
                                Me.txtPNo.Focus()
                            Else
                                Me.cboSJUG.SelectAll()
                                Me.cboSJUG.Focus()
                            End If
                        Case "txtPNo"
                            If Me.txtPNo.Text.Trim.Length > 0 Then
                                Me.txtSNMSN.Focus()
                            Else
                                Me.txtPNo.Focus()
                            End If
                        Case "txtHW"
                            If Me.txtHW.Text.Trim.Length > 0 Then
                                Me.txtN.Focus()
                            Else
                                Me.txtHW.Focus()
                            End If
                        Case "txtN"
                            If Me.txtN.Text.Trim.Length > 0 Then
                                Me.txtSNMSN.Focus()
                            Else
                                Me.txtN.Focus()
                            End If

                        Case "txtDate"
                            If Me.txtDate.Text.Trim.Length > 0 Then
                                Me.txtSNMSN.Focus()
                            Else
                                Me.txtDate.Focus()
                            End If

                        Case "txtSNMSN"
                            If Me.txtSNMSN.Text.Trim.Length > 0 Then
                                Me.cboMadeIn.Focus()
                            Else
                                Me.txtSNMSN.Focus()
                            End If

                        Case "cboMadeIn"
                            If Me.cboMadeIn.SelectedValue > 0 Then
                                Me.txtSW.Focus()
                            Else
                                Me.cboMadeIn.SelectAll()
                                Me.cboMadeIn.Focus()
                            End If

                        Case "txtSW"
                            If Me.txtSW.Text.Trim.Length > 0 Then
                                Me.cmdlblprint.Focus()
                            Else
                                Me.txtSW.Focus()
                            End If

                    End Select
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "KeyUpEvent", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*******************************************************************
        Private Sub cboLabelType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLabelType.SelectedIndexChanged
            ClearVarsAndCtrls()
        End Sub

        '*******************************************************************
        Private Sub btnViewLabelSetUpInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewLabelSetUpInfo.Click
            Try
                Me.grbLabelSetUpInfo.Visible = True
                'Load Models list

                'TO BE CONTINUE
            Catch ex As Exception
                MessageBox.Show(ex.Message, "KeyUpEvent", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*******************************************************************
        Private Sub btnRemoveLabelInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemoveLabelInfo.Click
            Dim strIMEI As String = ""
            Try
                strIMEI = Me.txtIMEI.Text
                Dim fm As New frmLabelInfoRemove(strIMEI)
                fm.ShowDialog()
                fm.Dispose()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnRemoveLabelInfo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*******************************************************************
        Private Sub btnResetManufDateCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetManufDateCode.Click
            Try
                Me.txtDate.Enabled = True

            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnResetManufDateCode_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

      
    End Class
End Namespace