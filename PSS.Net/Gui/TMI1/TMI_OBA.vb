Option Explicit On 

Imports PSS.Data
Imports PSS.Core.Global

Namespace Gui
    Public Class TMI_OBA
        Inherits System.Windows.Forms.Form

        Public _strScreenName As String = ""
        Public _iMenuCustID As Integer = 0
        'Public _iSelectedQCTypeID As Integer
        Public _iMenufQCTypeID As Integer

        Private objQC As PSS.Data.Buisness.QC
        Private objNI As PSS.Data.Buisness.NI
        Private objAIG As PSS.Data.Buisness.AIG

        Private iDevice_ID As Integer = 0
        Private arrSplitLine(0)
        Private Const strdelimiter As String = "~"
        Private iQCResult As Integer = 0

        Private strWorkDate As String = ""

        Private strGroup As String = ""
        Private iLine_ID As Integer = 0
        Private strLineNumber As String = ""
        Private strLineSide As String = ""
        Private icc_id As Integer = 0
        Private _iCC_Group_ID As Integer = 0
        Private _iModelID As Integer = 0
        Private _iManufID As Integer = 0
        Private _iWrty As Integer = 0
        Private _iFunRep As Integer = 0
        Private _iLaborLevel As Integer = 0
        Private _iWO_GroupID As Integer = 0
        Private _iProductID As Integer = 0
        Private _bPSSWarranty As Boolean = False
        Private _bPSSWarranty_Approved As Boolean = False

        Private _iH As Integer = 0

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName As String, ByVal iCustID As Integer, ByVal iQCTypeID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _strScreenName = strScreenName
            _iMenuCustID = iCustID
            _iMenufQCTypeID = iQCTypeID
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
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents lblManufSN As System.Windows.Forms.Label
        Friend WithEvents grdHistory As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents lblSN As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents cboUsers As C1.Win.C1List.C1Combo
        Friend WithEvents btnPass As System.Windows.Forms.Button
        Friend WithEvents btnFail As System.Windows.Forms.Button
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents grdQCFailRate As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents lblCostCenter As System.Windows.Forms.Label
        Friend WithEvents lblUserName As System.Windows.Forms.Label
        Friend WithEvents lblWorkDate As System.Windows.Forms.Label
        Friend WithEvents lblShift As System.Windows.Forms.Label
        Friend WithEvents lblMachine As System.Windows.Forms.Label
        Friend WithEvents lblLineSide As System.Windows.Forms.Label
        Friend WithEvents lblGroup As System.Windows.Forms.Label
        Friend WithEvents lblLine As System.Windows.Forms.Label
        Friend WithEvents lblPassed As System.Windows.Forms.Label
        Friend WithEvents Panel6 As System.Windows.Forms.Panel
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents lblProdType As System.Windows.Forms.Label
        Friend WithEvents cboCustomers As C1.Win.C1List.C1Combo
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents lblTotalGoodUnitsByCell As System.Windows.Forms.Label
        Friend WithEvents lblDeviceLoc As System.Windows.Forms.Label
        Friend WithEvents cboQCType As PSS.Gui.Controls.ComboBox
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents txtSN As System.Windows.Forms.TextBox
        Friend WithEvents lblMainInputName As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents lblPCModel As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents lblPCSerial As System.Windows.Forms.Label
        Friend WithEvents pnlShippingInfo As System.Windows.Forms.Panel
        Friend WithEvents lstShippingInfo As System.Windows.Forms.ListBox
        Friend WithEvents lblEWID_ClaimNo As System.Windows.Forms.Label
        Friend WithEvents lblShippingInfo As System.Windows.Forms.Label
        Friend WithEvents lblPSSI_SN_OK As System.Windows.Forms.Label
        Friend WithEvents pnlFailCodes As System.Windows.Forms.Panel
        Friend WithEvents cmdRemove As System.Windows.Forms.Button
        Friend WithEvents lstFailCodes As System.Windows.Forms.ListBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents cboCodes As C1.Win.C1List.C1Combo
        Friend WithEvents btnSave As System.Windows.Forms.Button
        Friend WithEvents lblAccessory As System.Windows.Forms.Label
        Friend WithEvents lstAccessory As System.Windows.Forms.ListBox
        Friend WithEvents lblPssWrty As System.Windows.Forms.Label
        Friend WithEvents lblExpectedShipDate As System.Windows.Forms.Label
        Friend WithEvents txtNotes As System.Windows.Forms.TextBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(TMI_OBA))
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.lblManufSN = New System.Windows.Forms.Label()
            Me.grdHistory = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.lblSN = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.cboUsers = New C1.Win.C1List.C1Combo()
            Me.btnPass = New System.Windows.Forms.Button()
            Me.btnFail = New System.Windows.Forms.Button()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.grdQCFailRate = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.lblCostCenter = New System.Windows.Forms.Label()
            Me.lblUserName = New System.Windows.Forms.Label()
            Me.lblWorkDate = New System.Windows.Forms.Label()
            Me.lblShift = New System.Windows.Forms.Label()
            Me.lblMachine = New System.Windows.Forms.Label()
            Me.lblLineSide = New System.Windows.Forms.Label()
            Me.lblGroup = New System.Windows.Forms.Label()
            Me.lblLine = New System.Windows.Forms.Label()
            Me.lblPassed = New System.Windows.Forms.Label()
            Me.Panel6 = New System.Windows.Forms.Panel()
            Me.lblExpectedShipDate = New System.Windows.Forms.Label()
            Me.lblPssWrty = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.lblPCSerial = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.lblPCModel = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.lblProdType = New System.Windows.Forms.Label()
            Me.cboCustomers = New C1.Win.C1List.C1Combo()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.cboQCType = New PSS.Gui.Controls.ComboBox()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.txtSN = New System.Windows.Forms.TextBox()
            Me.lblMainInputName = New System.Windows.Forms.Label()
            Me.lblTotalGoodUnitsByCell = New System.Windows.Forms.Label()
            Me.lblDeviceLoc = New System.Windows.Forms.Label()
            Me.lblPSSI_SN_OK = New System.Windows.Forms.Label()
            Me.txtNotes = New System.Windows.Forms.TextBox()
            Me.pnlShippingInfo = New System.Windows.Forms.Panel()
            Me.lblAccessory = New System.Windows.Forms.Label()
            Me.lstAccessory = New System.Windows.Forms.ListBox()
            Me.lstShippingInfo = New System.Windows.Forms.ListBox()
            Me.lblShippingInfo = New System.Windows.Forms.Label()
            Me.lblEWID_ClaimNo = New System.Windows.Forms.Label()
            Me.pnlFailCodes = New System.Windows.Forms.Panel()
            Me.cmdRemove = New System.Windows.Forms.Button()
            Me.lstFailCodes = New System.Windows.Forms.ListBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.cboCodes = New C1.Win.C1List.C1Combo()
            Me.btnSave = New System.Windows.Forms.Button()
            Me.Panel3.SuspendLayout()
            CType(Me.grdHistory, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboUsers, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.grdQCFailRate, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel2.SuspendLayout()
            Me.Panel6.SuspendLayout()
            CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlShippingInfo.SuspendLayout()
            Me.pnlFailCodes.SuspendLayout()
            CType(Me.cboCodes, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'Panel3
            '
            Me.Panel3.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel3.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblManufSN, Me.grdHistory, Me.Label4, Me.lblSN, Me.Label6, Me.cboUsers})
            Me.Panel3.Location = New System.Drawing.Point(0, 322)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(976, 136)
            Me.Panel3.TabIndex = 137
            '
            'lblManufSN
            '
            Me.lblManufSN.BackColor = System.Drawing.Color.Transparent
            Me.lblManufSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblManufSN.ForeColor = System.Drawing.Color.Red
            Me.lblManufSN.Location = New System.Drawing.Point(296, 8)
            Me.lblManufSN.Name = "lblManufSN"
            Me.lblManufSN.Size = New System.Drawing.Size(216, 19)
            Me.lblManufSN.TabIndex = 91
            Me.lblManufSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'grdHistory
            '
            Me.grdHistory.AllowSort = False
            Me.grdHistory.GroupByCaption = "Drag a column header here to group by that column"
            Me.grdHistory.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.grdHistory.Location = New System.Drawing.Point(7, 32)
            Me.grdHistory.Name = "grdHistory"
            Me.grdHistory.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.grdHistory.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.grdHistory.PreviewInfo.ZoomFactor = 75
            Me.grdHistory.Size = New System.Drawing.Size(956, 96)
            Me.grdHistory.TabIndex = 14
            Me.grdHistory.Text = "C1TrueDBGrid1"
            Me.grdHistory.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Style1{}Normal{BackColor:LightSteelBlue;}HighlightRow{ForeColor:HighlightTex" & _
            "t;BackColor:Highlight;}Style14{}OddRow{}RecordSelector{AlignImage:Center;}Style1" & _
            "5{}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:Contr" & _
            "olText;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}Style12{}Style" & _
            "13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" Capti" & _
            "onHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""Dot" & _
            "tedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=" & _
            """1"" HorizontalScrollGroup=""1""><Height>92</Height><CaptionStyle parent=""Style2"" m" & _
            "e=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""E" & _
            "venRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterS" & _
            "tyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><He" & _
            "adingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRo" & _
            "w"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle par" & _
            "ent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Styl" & _
            "e11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=" & _
            """Style1"" /><ClientRect>0, 0, 952, 92</ClientRect><BorderSide>0</BorderSide><Bord" & _
            "erStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyle" & _
            "s><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style pa" & _
            "rent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style paren" & _
            "t=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent" & _
            "=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent" & _
            "=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Hea" & _
            "ding"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style paren" & _
            "t=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</" & _
            "horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><Clie" & _
            "ntArea>0, 0, 952, 92</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" />" & _
            "<PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.Black
            Me.Label4.Location = New System.Drawing.Point(4, 7)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(100, 19)
            Me.Label4.TabIndex = 74
            Me.Label4.Text = "QC History for "
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblSN
            '
            Me.lblSN.BackColor = System.Drawing.Color.Transparent
            Me.lblSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSN.ForeColor = System.Drawing.Color.Red
            Me.lblSN.Location = New System.Drawing.Point(104, 7)
            Me.lblSN.Name = "lblSN"
            Me.lblSN.Size = New System.Drawing.Size(160, 19)
            Me.lblSN.TabIndex = 76
            Me.lblSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label6
            '
            Me.Label6.BackColor = System.Drawing.Color.Transparent
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.Black
            Me.Label6.Location = New System.Drawing.Point(664, 6)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(48, 19)
            Me.Label6.TabIndex = 82
            Me.Label6.Text = "Tech:"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboUsers
            '
            Me.cboUsers.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboUsers.AutoCompletion = True
            Me.cboUsers.AutoDropDown = True
            Me.cboUsers.AutoSelect = True
            Me.cboUsers.Caption = ""
            Me.cboUsers.CaptionHeight = 17
            Me.cboUsers.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboUsers.ColumnCaptionHeight = 17
            Me.cboUsers.ColumnFooterHeight = 17
            Me.cboUsers.ColumnHeaders = False
            Me.cboUsers.ContentHeight = 15
            Me.cboUsers.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboUsers.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboUsers.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboUsers.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboUsers.EditorHeight = 15
            Me.cboUsers.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboUsers.ItemHeight = 15
            Me.cboUsers.Location = New System.Drawing.Point(712, 5)
            Me.cboUsers.MatchEntryTimeout = CType(2000, Long)
            Me.cboUsers.MaxDropDownItems = CType(10, Short)
            Me.cboUsers.MaxLength = 32767
            Me.cboUsers.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboUsers.Name = "cboUsers"
            Me.cboUsers.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboUsers.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboUsers.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboUsers.Size = New System.Drawing.Size(253, 21)
            Me.cboUsers.TabIndex = 90
            Me.cboUsers.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'btnPass
            '
            Me.btnPass.BackColor = System.Drawing.Color.SteelBlue
            Me.btnPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPass.ForeColor = System.Drawing.Color.White
            Me.btnPass.Location = New System.Drawing.Point(656, 72)
            Me.btnPass.Name = "btnPass"
            Me.btnPass.Size = New System.Drawing.Size(104, 56)
            Me.btnPass.TabIndex = 139
            Me.btnPass.Text = "PASS      (F9)"
            '
            'btnFail
            '
            Me.btnFail.BackColor = System.Drawing.Color.SteelBlue
            Me.btnFail.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnFail.ForeColor = System.Drawing.Color.White
            Me.btnFail.Location = New System.Drawing.Point(768, 72)
            Me.btnFail.Name = "btnFail"
            Me.btnFail.Size = New System.Drawing.Size(96, 56)
            Me.btnFail.TabIndex = 140
            Me.btnFail.Text = "FAIL       (F12)"
            '
            'btnClear
            '
            Me.btnClear.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte))
            Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClear.ForeColor = System.Drawing.Color.White
            Me.btnClear.Location = New System.Drawing.Point(880, 72)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(96, 56)
            Me.btnClear.TabIndex = 144
            Me.btnClear.Text = "CLEAR (ESC)"
            '
            'lblTitle
            '
            Me.lblTitle.BackColor = System.Drawing.Color.Black
            Me.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblTitle.Font = New System.Drawing.Font("Arial Black", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTitle.ForeColor = System.Drawing.Color.Yellow
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(321, 64)
            Me.lblTitle.TabIndex = 141
            Me.lblTitle.Text = "Quality Control - OBA"
            Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'grdQCFailRate
            '
            Me.grdQCFailRate.AllowArrows = False
            Me.grdQCFailRate.AllowColMove = False
            Me.grdQCFailRate.AllowColSelect = False
            Me.grdQCFailRate.AllowFilter = False
            Me.grdQCFailRate.AllowRowSelect = False
            Me.grdQCFailRate.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.grdQCFailRate.AllowSort = False
            Me.grdQCFailRate.AllowUpdate = False
            Me.grdQCFailRate.AllowUpdateOnBlur = False
            Me.grdQCFailRate.BackColor = System.Drawing.Color.Lavender
            Me.grdQCFailRate.CaptionHeight = 17
            Me.grdQCFailRate.CausesValidation = False
            Me.grdQCFailRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grdQCFailRate.GroupByCaption = "Drag a column header here to group by that column"
            Me.grdQCFailRate.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.grdQCFailRate.Location = New System.Drawing.Point(1, 64)
            Me.grdQCFailRate.Name = "grdQCFailRate"
            Me.grdQCFailRate.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.grdQCFailRate.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.grdQCFailRate.PreviewInfo.ZoomFactor = 75
            Me.grdQCFailRate.RowHeight = 15
            Me.grdQCFailRate.Size = New System.Drawing.Size(320, 256)
            Me.grdQCFailRate.TabIndex = 143
            Me.grdQCFailRate.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Style9{}Normal{Font:Microsoft Sans Serif, 9pt, style=Bold;ForeColor:Lime;Bac" & _
            "kColor:Black;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style14{" & _
            "}OddRow{}RecordSelector{AlignImage:Center;}Style15{}Heading{Wrap:True;AlignVert:" & _
            "Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8" & _
            "{}Style10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style1{}</Data></Styles><Sp" & _
            "lits><C1.Win.C1TrueDBGrid.MergeView HBarHeight=""24"" AllowColMove=""False"" AllowCo" & _
            "lSelect=""False"" AllowRowSelect=""False"" Name="""" AllowRowSizing=""None"" CaptionHeig" & _
            "ht=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCel" & _
            "lBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" Ho" & _
            "rizontalScrollGroup=""1""><Height>252</Height><CaptionStyle parent=""Style2"" me=""St" & _
            "yle10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRo" & _
            "w"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle " & _
            "parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><Heading" & _
            "Style parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me" & _
            "=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""" & _
            "OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" " & _
            "/><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Styl" & _
            "e1"" /><ClientRect>0, 0, 316, 252</ClientRect><BorderSide>0</BorderSide><BorderSt" & _
            "yle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><S" & _
            "tyle parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent" & _
            "=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""H" & _
            "eading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""No" & _
            "rmal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""No" & _
            "rmal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading" & _
            """ me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""C" & _
            "aption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horz" & _
            "Splits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientAr" & _
            "ea>0, 0, 316, 252</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><Pr" & _
            "intPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'Panel2
            '
            Me.Panel2.BackColor = System.Drawing.Color.Black
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblCostCenter, Me.lblUserName, Me.lblWorkDate, Me.lblShift, Me.lblMachine, Me.lblLineSide, Me.lblGroup, Me.lblLine, Me.lblPassed})
            Me.Panel2.Location = New System.Drawing.Point(321, 0)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(655, 66)
            Me.Panel2.TabIndex = 142
            '
            'lblCostCenter
            '
            Me.lblCostCenter.BackColor = System.Drawing.Color.Transparent
            Me.lblCostCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCostCenter.ForeColor = System.Drawing.Color.Lime
            Me.lblCostCenter.Location = New System.Drawing.Point(448, 5)
            Me.lblCostCenter.Name = "lblCostCenter"
            Me.lblCostCenter.Size = New System.Drawing.Size(200, 19)
            Me.lblCostCenter.TabIndex = 101
            Me.lblCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblUserName
            '
            Me.lblUserName.BackColor = System.Drawing.Color.Transparent
            Me.lblUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblUserName.ForeColor = System.Drawing.Color.Lime
            Me.lblUserName.Location = New System.Drawing.Point(256, 6)
            Me.lblUserName.Name = "lblUserName"
            Me.lblUserName.Size = New System.Drawing.Size(198, 19)
            Me.lblUserName.TabIndex = 100
            Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblWorkDate
            '
            Me.lblWorkDate.BackColor = System.Drawing.Color.Transparent
            Me.lblWorkDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWorkDate.ForeColor = System.Drawing.Color.Lime
            Me.lblWorkDate.Location = New System.Drawing.Point(256, 24)
            Me.lblWorkDate.Name = "lblWorkDate"
            Me.lblWorkDate.Size = New System.Drawing.Size(198, 18)
            Me.lblWorkDate.TabIndex = 99
            Me.lblWorkDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblShift
            '
            Me.lblShift.BackColor = System.Drawing.Color.Transparent
            Me.lblShift.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblShift.ForeColor = System.Drawing.Color.Lime
            Me.lblShift.Location = New System.Drawing.Point(256, 41)
            Me.lblShift.Name = "lblShift"
            Me.lblShift.Size = New System.Drawing.Size(198, 19)
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
            Me.lblMachine.Size = New System.Drawing.Size(254, 19)
            Me.lblMachine.TabIndex = 97
            Me.lblMachine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblLineSide
            '
            Me.lblLineSide.BackColor = System.Drawing.Color.Transparent
            Me.lblLineSide.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLineSide.ForeColor = System.Drawing.Color.Lime
            Me.lblLineSide.Location = New System.Drawing.Point(64, 24)
            Me.lblLineSide.Name = "lblLineSide"
            Me.lblLineSide.Size = New System.Drawing.Size(128, 18)
            Me.lblLineSide.TabIndex = 96
            Me.lblLineSide.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblGroup
            '
            Me.lblGroup.BackColor = System.Drawing.Color.Transparent
            Me.lblGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblGroup.ForeColor = System.Drawing.Color.Lime
            Me.lblGroup.Location = New System.Drawing.Point(0, 6)
            Me.lblGroup.Name = "lblGroup"
            Me.lblGroup.Size = New System.Drawing.Size(254, 19)
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
            'lblPassed
            '
            Me.lblPassed.BackColor = System.Drawing.Color.Black
            Me.lblPassed.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPassed.ForeColor = System.Drawing.Color.Lime
            Me.lblPassed.Location = New System.Drawing.Point(448, 32)
            Me.lblPassed.Name = "lblPassed"
            Me.lblPassed.Size = New System.Drawing.Size(200, 27)
            Me.lblPassed.TabIndex = 84
            Me.lblPassed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Panel6
            '
            Me.Panel6.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel6.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblExpectedShipDate, Me.lblPssWrty, Me.Label3, Me.lblPCSerial, Me.Label2, Me.lblPCModel, Me.Label1, Me.lblProdType, Me.cboCustomers, Me.Label7, Me.cboQCType, Me.Label8, Me.txtSN, Me.lblMainInputName, Me.lblTotalGoodUnitsByCell, Me.lblDeviceLoc, Me.lblPSSI_SN_OK})
            Me.Panel6.Location = New System.Drawing.Point(321, 68)
            Me.Panel6.Name = "Panel6"
            Me.Panel6.Size = New System.Drawing.Size(327, 252)
            Me.Panel6.TabIndex = 136
            '
            'lblExpectedShipDate
            '
            Me.lblExpectedShipDate.Location = New System.Drawing.Point(8, 200)
            Me.lblExpectedShipDate.Name = "lblExpectedShipDate"
            Me.lblExpectedShipDate.Size = New System.Drawing.Size(224, 24)
            Me.lblExpectedShipDate.TabIndex = 147
            Me.lblExpectedShipDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblPssWrty
            '
            Me.lblPssWrty.BackColor = System.Drawing.Color.DarkSeaGreen
            Me.lblPssWrty.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPssWrty.Location = New System.Drawing.Point(0, 224)
            Me.lblPssWrty.Name = "lblPssWrty"
            Me.lblPssWrty.Size = New System.Drawing.Size(320, 24)
            Me.lblPssWrty.TabIndex = 146
            Me.lblPssWrty.Text = "PSS Warranty"
            Me.lblPssWrty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.Black
            Me.Label3.Location = New System.Drawing.Point(-8, 144)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(104, 19)
            Me.Label3.TabIndex = 144
            Me.Label3.Text = "Serial:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblPCSerial
            '
            Me.lblPCSerial.BackColor = System.Drawing.Color.Gainsboro
            Me.lblPCSerial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblPCSerial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPCSerial.ForeColor = System.Drawing.Color.Black
            Me.lblPCSerial.Location = New System.Drawing.Point(96, 144)
            Me.lblPCSerial.Name = "lblPCSerial"
            Me.lblPCSerial.Size = New System.Drawing.Size(224, 22)
            Me.lblPCSerial.TabIndex = 143
            Me.lblPCSerial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.Black
            Me.Label2.Location = New System.Drawing.Point(-8, 120)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(104, 19)
            Me.Label2.TabIndex = 142
            Me.Label2.Text = "Model:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblPCModel
            '
            Me.lblPCModel.BackColor = System.Drawing.Color.Gainsboro
            Me.lblPCModel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblPCModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPCModel.ForeColor = System.Drawing.Color.Black
            Me.lblPCModel.Location = New System.Drawing.Point(96, 120)
            Me.lblPCModel.Name = "lblPCModel"
            Me.lblPCModel.Size = New System.Drawing.Size(224, 22)
            Me.lblPCModel.TabIndex = 141
            Me.lblPCModel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Black
            Me.Label1.Location = New System.Drawing.Point(-8, 96)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(104, 19)
            Me.Label1.TabIndex = 140
            Me.Label1.Text = "Brand/Type:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblProdType
            '
            Me.lblProdType.BackColor = System.Drawing.Color.Gainsboro
            Me.lblProdType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblProdType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblProdType.ForeColor = System.Drawing.Color.Black
            Me.lblProdType.Location = New System.Drawing.Point(96, 96)
            Me.lblProdType.Name = "lblProdType"
            Me.lblProdType.Size = New System.Drawing.Size(224, 22)
            Me.lblProdType.TabIndex = 139
            Me.lblProdType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
            Me.cboCustomers.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.cboCustomers.ItemHeight = 15
            Me.cboCustomers.Location = New System.Drawing.Point(96, 0)
            Me.cboCustomers.MatchEntryTimeout = CType(2000, Long)
            Me.cboCustomers.MaxDropDownItems = CType(5, Short)
            Me.cboCustomers.MaxLength = 32767
            Me.cboCustomers.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCustomers.Name = "cboCustomers"
            Me.cboCustomers.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCustomers.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCustomers.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCustomers.Size = New System.Drawing.Size(224, 21)
            Me.cboCustomers.TabIndex = 2
            Me.cboCustomers.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label7
            '
            Me.Label7.BackColor = System.Drawing.Color.Transparent
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.Black
            Me.Label7.Location = New System.Drawing.Point(-24, 0)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(113, 16)
            Me.Label7.TabIndex = 125
            Me.Label7.Text = "Customer:"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboQCType
            '
            Me.cboQCType.AutoComplete = True
            Me.cboQCType.BackColor = System.Drawing.SystemColors.Window
            Me.cboQCType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboQCType.ForeColor = System.Drawing.Color.Black
            Me.cboQCType.Location = New System.Drawing.Point(96, 24)
            Me.cboQCType.Name = "cboQCType"
            Me.cboQCType.Size = New System.Drawing.Size(224, 21)
            Me.cboQCType.TabIndex = 3
            '
            'Label8
            '
            Me.Label8.BackColor = System.Drawing.Color.Transparent
            Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.Black
            Me.Label8.Location = New System.Drawing.Point(16, 24)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(75, 19)
            Me.Label8.TabIndex = 83
            Me.Label8.Text = "QC Type:"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtSN
            '
            Me.txtSN.BackColor = System.Drawing.Color.Yellow
            Me.txtSN.Location = New System.Drawing.Point(96, 48)
            Me.txtSN.Name = "txtSN"
            Me.txtSN.Size = New System.Drawing.Size(224, 20)
            Me.txtSN.TabIndex = 4
            Me.txtSN.Text = ""
            '
            'lblMainInputName
            '
            Me.lblMainInputName.BackColor = System.Drawing.Color.Transparent
            Me.lblMainInputName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMainInputName.ForeColor = System.Drawing.Color.Blue
            Me.lblMainInputName.Location = New System.Drawing.Point(8, 48)
            Me.lblMainInputName.Name = "lblMainInputName"
            Me.lblMainInputName.Size = New System.Drawing.Size(80, 19)
            Me.lblMainInputName.TabIndex = 55
            Me.lblMainInputName.Text = "SN:"
            Me.lblMainInputName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblTotalGoodUnitsByCell
            '
            Me.lblTotalGoodUnitsByCell.BackColor = System.Drawing.Color.Transparent
            Me.lblTotalGoodUnitsByCell.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTotalGoodUnitsByCell.ForeColor = System.Drawing.Color.Red
            Me.lblTotalGoodUnitsByCell.Location = New System.Drawing.Point(240, 168)
            Me.lblTotalGoodUnitsByCell.Name = "lblTotalGoodUnitsByCell"
            Me.lblTotalGoodUnitsByCell.Size = New System.Drawing.Size(75, 40)
            Me.lblTotalGoodUnitsByCell.TabIndex = 85
            Me.lblTotalGoodUnitsByCell.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDeviceLoc
            '
            Me.lblDeviceLoc.BackColor = System.Drawing.Color.Transparent
            Me.lblDeviceLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDeviceLoc.ForeColor = System.Drawing.Color.Blue
            Me.lblDeviceLoc.Location = New System.Drawing.Point(8, 176)
            Me.lblDeviceLoc.Name = "lblDeviceLoc"
            Me.lblDeviceLoc.Size = New System.Drawing.Size(216, 19)
            Me.lblDeviceLoc.TabIndex = 84
            Me.lblDeviceLoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblPSSI_SN_OK
            '
            Me.lblPSSI_SN_OK.BackColor = System.Drawing.Color.LightSteelBlue
            Me.lblPSSI_SN_OK.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPSSI_SN_OK.ForeColor = System.Drawing.Color.Black
            Me.lblPSSI_SN_OK.Location = New System.Drawing.Point(96, 70)
            Me.lblPSSI_SN_OK.Name = "lblPSSI_SN_OK"
            Me.lblPSSI_SN_OK.Size = New System.Drawing.Size(224, 22)
            Me.lblPSSI_SN_OK.TabIndex = 145
            Me.lblPSSI_SN_OK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtNotes
            '
            Me.txtNotes.ForeColor = System.Drawing.Color.Navy
            Me.txtNotes.Location = New System.Drawing.Point(160, 240)
            Me.txtNotes.Multiline = True
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.Size = New System.Drawing.Size(24, 20)
            Me.txtNotes.TabIndex = 148
            Me.txtNotes.Text = ""
            '
            'pnlShippingInfo
            '
            Me.pnlShippingInfo.BackColor = System.Drawing.Color.LightSteelBlue
            Me.pnlShippingInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlShippingInfo.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblAccessory, Me.lstAccessory, Me.lstShippingInfo, Me.lblShippingInfo, Me.lblEWID_ClaimNo})
            Me.pnlShippingInfo.Location = New System.Drawing.Point(646, 130)
            Me.pnlShippingInfo.Name = "pnlShippingInfo"
            Me.pnlShippingInfo.Size = New System.Drawing.Size(330, 190)
            Me.pnlShippingInfo.TabIndex = 145
            Me.pnlShippingInfo.Visible = False
            '
            'lblAccessory
            '
            Me.lblAccessory.BackColor = System.Drawing.Color.LightSteelBlue
            Me.lblAccessory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblAccessory.Location = New System.Drawing.Point(0, 88)
            Me.lblAccessory.Name = "lblAccessory"
            Me.lblAccessory.Size = New System.Drawing.Size(312, 16)
            Me.lblAccessory.TabIndex = 135
            Me.lblAccessory.Text = "Accessory:"
            '
            'lstAccessory
            '
            Me.lstAccessory.BackColor = System.Drawing.Color.WhiteSmoke
            Me.lstAccessory.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lstAccessory.ForeColor = System.Drawing.Color.Black
            Me.lstAccessory.ItemHeight = 15
            Me.lstAccessory.Location = New System.Drawing.Point(4, 104)
            Me.lstAccessory.Name = "lstAccessory"
            Me.lstAccessory.Size = New System.Drawing.Size(308, 79)
            Me.lstAccessory.TabIndex = 134
            '
            'lstShippingInfo
            '
            Me.lstShippingInfo.BackColor = System.Drawing.Color.WhiteSmoke
            Me.lstShippingInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lstShippingInfo.ForeColor = System.Drawing.Color.Black
            Me.lstShippingInfo.ItemHeight = 15
            Me.lstShippingInfo.Location = New System.Drawing.Point(4, 16)
            Me.lstShippingInfo.Name = "lstShippingInfo"
            Me.lstShippingInfo.Size = New System.Drawing.Size(308, 64)
            Me.lstShippingInfo.TabIndex = 130
            '
            'lblShippingInfo
            '
            Me.lblShippingInfo.BackColor = System.Drawing.Color.LightSteelBlue
            Me.lblShippingInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblShippingInfo.Name = "lblShippingInfo"
            Me.lblShippingInfo.Size = New System.Drawing.Size(96, 16)
            Me.lblShippingInfo.TabIndex = 133
            Me.lblShippingInfo.Text = "Shipping Info:"
            '
            'lblEWID_ClaimNo
            '
            Me.lblEWID_ClaimNo.BackColor = System.Drawing.Color.LightSteelBlue
            Me.lblEWID_ClaimNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblEWID_ClaimNo.Location = New System.Drawing.Point(104, 0)
            Me.lblEWID_ClaimNo.Name = "lblEWID_ClaimNo"
            Me.lblEWID_ClaimNo.Size = New System.Drawing.Size(208, 16)
            Me.lblEWID_ClaimNo.TabIndex = 131
            '
            'pnlFailCodes
            '
            Me.pnlFailCodes.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(255, Byte))
            Me.pnlFailCodes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlFailCodes.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdRemove, Me.lstFailCodes, Me.Label5, Me.cboCodes, Me.btnSave})
            Me.pnlFailCodes.Location = New System.Drawing.Point(4, 464)
            Me.pnlFailCodes.Name = "pnlFailCodes"
            Me.pnlFailCodes.Size = New System.Drawing.Size(972, 112)
            Me.pnlFailCodes.TabIndex = 146
            Me.pnlFailCodes.Visible = False
            '
            'cmdRemove
            '
            Me.cmdRemove.BackColor = System.Drawing.Color.SteelBlue
            Me.cmdRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdRemove.ForeColor = System.Drawing.Color.White
            Me.cmdRemove.Location = New System.Drawing.Point(552, 40)
            Me.cmdRemove.Name = "cmdRemove"
            Me.cmdRemove.Size = New System.Drawing.Size(84, 24)
            Me.cmdRemove.TabIndex = 12
            Me.cmdRemove.Text = "REMOVE"
            '
            'lstFailCodes
            '
            Me.lstFailCodes.Location = New System.Drawing.Point(97, 34)
            Me.lstFailCodes.Name = "lstFailCodes"
            Me.lstFailCodes.Size = New System.Drawing.Size(449, 69)
            Me.lstFailCodes.TabIndex = 11
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.Black
            Me.Label5.Location = New System.Drawing.Point(16, 9)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(80, 19)
            Me.Label5.TabIndex = 71
            Me.Label5.Text = "Fail Code:"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboCodes
            '
            Me.cboCodes.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboCodes.AutoCompletion = True
            Me.cboCodes.AutoDropDown = True
            Me.cboCodes.AutoSelect = True
            Me.cboCodes.Caption = ""
            Me.cboCodes.CaptionHeight = 17
            Me.cboCodes.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboCodes.ColumnCaptionHeight = 17
            Me.cboCodes.ColumnFooterHeight = 17
            Me.cboCodes.ColumnHeaders = False
            Me.cboCodes.ContentHeight = 15
            Me.cboCodes.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboCodes.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboCodes.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCodes.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCodes.EditorHeight = 15
            Me.cboCodes.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.cboCodes.ItemHeight = 15
            Me.cboCodes.Location = New System.Drawing.Point(96, 5)
            Me.cboCodes.MatchEntryTimeout = CType(2000, Long)
            Me.cboCodes.MaxDropDownItems = CType(10, Short)
            Me.cboCodes.MaxLength = 32767
            Me.cboCodes.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCodes.Name = "cboCodes"
            Me.cboCodes.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCodes.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCodes.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCodes.Size = New System.Drawing.Size(448, 21)
            Me.cboCodes.TabIndex = 89
            Me.cboCodes.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'btnSave
            '
            Me.btnSave.BackColor = System.Drawing.Color.Green
            Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSave.ForeColor = System.Drawing.Color.White
            Me.btnSave.Location = New System.Drawing.Point(792, 8)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(128, 85)
            Me.btnSave.TabIndex = 8
            Me.btnSave.Text = "SAVE (F5)"
            '
            'TMI_OBA
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.RosyBrown
            Me.ClientSize = New System.Drawing.Size(984, 582)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlFailCodes, Me.pnlShippingInfo, Me.Panel3, Me.btnPass, Me.btnFail, Me.btnClear, Me.lblTitle, Me.grdQCFailRate, Me.Panel2, Me.Panel6, Me.txtNotes})
            Me.Name = "TMI_OBA"
            Me.Text = "TMI_OBA"
            Me.Panel3.ResumeLayout(False)
            CType(Me.grdHistory, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboUsers, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.grdQCFailRate, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel2.ResumeLayout(False)
            Me.Panel6.ResumeLayout(False)
            CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlShippingInfo.ResumeLayout(False)
            Me.pnlFailCodes.ResumeLayout(False)
            CType(Me.cboCodes, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub TMI_OBA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim i As Integer = 0

            Try
                strWorkDate = Buisness.Generic.GetWorkDate(ApplicationUser.IDShift)
                i = CheckIfMachineTiedToLine()

                If i = 0 Then
                    Throw New Exception("Machine is not associated with any 'Line'. Can't continue.")
                End If

                LoadQCTypes()
                LoadUsers()
                LoadCustomers()

                objQC.SetShiftInfo(ApplicationUser.IDShift)
                Me.lblShift.Text = objQC.Shift
                Me.lblUserName.Text = "Inspector: " & ApplicationUser.User
                objNI = New PSS.Data.Buisness.NI()
                objAIG = New PSS.Data.Buisness.AIG()

                If Me._iMenuCustID = objNI.CUSTOMERID Then
                    Me.Label1.Text = "Cometric Grade:"
                    Me.Label1.Width = 150
                    Me.lblProdType.Width = Me.lblProdType.Width - 46
                    Me.lblProdType.Left = Me.Label1.Left + Me.Label1.Width
                End If

                Me.lblPssWrty.Visible = False : Me.txtNotes.Visible = False
                Me._iH = Me.grdQCFailRate.Height

                Me.txtSN.Focus()

            Catch ex As Exception
                MsgBox("Error in TMI_OBA_Load:: " & ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        End Sub


        '*********************************************************
        Private Function CheckIfMachineTiedToLine() As Integer
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim objMisc As New PSS.Data.Buisness.Misc()

            Try
                dt1 = objMisc.CheckIfMachineTiedToLine(System.Net.Dns.GetHostName)
                If dt1.Rows.Count = 0 Then
                    Return 0
                End If

                For Each R1 In dt1.Rows
                    'iGroup_ID = R1("Group_ID")
                    strGroup = Trim(R1("CC_Group_Desc"))
                    iLine_ID = R1("Line_ID")
                    strLineNumber = Trim(R1("Line_Number"))
                    strLineSide = Trim(R1("LineSide_Desc"))
                    Me.icc_id = R1("cc_id")
                    Me._iCC_Group_ID = R1("CC_Group_ID")
                    Me.lblCostCenter.Text = R1("CC_Group_Desc").ToString.ToUpper & " CELL " & R1("CostCenter").ToString.ToUpper
                Next R1

                Me.lblGroup.Text = "Group: " & strGroup
                Me.lblLine.Text = strLineNumber
                Me.lblLineSide.Text = strLineSide
                Me.lblMachine.Text = "Machine: " & System.Net.Dns.GetHostName
                Me.lblUserName.Text = "User: " & ApplicationUser.User
                Me.lblShift.Text = "Shift: " & ApplicationUser.IDShift
                Me.lblWorkDate.Text = "Work Date: " & Format(CDate(Me.strWorkDate), "MM/dd/yyyy")

                Return 1
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                objMisc = Nothing
            End Try
        End Function

        '*********************************************************
        Private Sub LoadQCTypes()
            Dim dtUsers As New DataTable()
            Try
                objQC = New PSS.Data.Buisness.QC()
                dtUsers = objQC.GetQCTypeInfo(True)
                With Me.cboQCType
                    .DataSource = dtUsers.DefaultView
                    .DisplayMember = dtUsers.Columns("QCType").ToString
                    .ValueMember = dtUsers.Columns("QCType_id").ToString
                    .SelectedValue = Me._iMenufQCTypeID
                    .Enabled = False
                End With

            Catch ex As Exception
                MsgBox("Error in TMI_OBA.LoadQCTypes:: " & ex.Message.ToString, MsgBoxStyle.Critical)
            Finally
                objQC.DisposeDT(dtUsers)
            End Try
        End Sub

        '*********************************************************
        Private Sub LoadCustomers()
            Dim dt As New DataTable()
            Try

                Buisness.Generic.GetCustIDByMachine()
                Me.cboCustomers.DataSource = Nothing
                dt = Buisness.Generic.GetCustomers(True)
                Misc.PopulateC1DropDownList(Me.cboCustomers, dt, "Cust_Name1", "Cust_ID")
                Me.cboCustomers.SelectedValue = Me._iMenuCustID
                Me.cboCustomers.Enabled = False

            Catch ex As Exception
                MsgBox("Error in TMI_OBA.LoadCustomers(): " & ex.Message.ToString, MsgBoxStyle.Critical)
            Finally
                objQC.DisposeDT(dt)
            End Try
        End Sub

        '*********************************************************
        Private Sub LoadUsers()
            Dim dtUsers As New DataTable()
            Try
                dtUsers = objQC.LoadUsers()
                With Me.cboUsers
                    .DataSource = dtUsers.DefaultView
                    .DisplayMember = dtUsers.Columns("user_fullname").ToString
                    .ValueMember = dtUsers.Columns("user_id").ToString
                    .Splits(0).DisplayColumns("user_id").Visible = False
                    .Splits(0).DisplayColumns("user_fullname").Width = .Width - (.VScrollBar.Width + 4)
                    .SelectedValue = ApplicationUser.IDuser
                End With

            Catch ex As Exception
                MsgBox("Error in TMI_OBA.LoadUsers:: " & ex.Message.ToString, MsgBoxStyle.Critical)
            Finally
                objQC.DisposeDT(dtUsers)
            End Try
        End Sub

        '*********************************************************************
        Private Sub ResetControls()
            Me._iModelID = 0
            Me._iProductID = 0
            Me._iManufID = 0
            Me._iFunRep = 0
            Me._iWrty = 0
            iQCResult = 0
            iDevice_ID = 0
            _iWO_GroupID = 0
            'Me.txtSN.Text = ""
            Me.lblSN.Text = ""
            Me.lblProdType.Text = ""
            Me.lblPassed.Text = ""
            Me.lblManufSN.Text = ""
            Me.lblTotalGoodUnitsByCell.Text = ""
            Me.lblPCModel.Text = ""
            Me.lblPCSerial.Text = ""
            Me.lblEWID_ClaimNo.Text = ""
            'Me.lblShippingInfo.Text = ""
            Me.lblPSSI_SN_OK.Text = ""
            Me.lblPssWrty.Text = ""
            Me.lblExpectedShipDate.Text = ""
            Me.txtNotes.Text = ""

            btnPass.BackColor = System.Drawing.Color.SteelBlue
            btnFail.BackColor = System.Drawing.Color.SteelBlue
            Me.pnlShippingInfo.Visible = False
            Me.pnlFailCodes.Visible = False
            Me.grdHistory.DataSource = Nothing
            Me.lstFailCodes.Items.Clear()
        End Sub

        '*********************************************************************
        Private Sub txtSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp
            Dim dt1, dtApprovedData As DataTable
            Dim row As DataRow
            Dim strCompletedTech As String
            Dim iDevice_CC As Integer = 0
            Dim objFrmMD As QualityControl.frmGetManufactureDate
            Dim objTMIShip As PSS.Data.Buisness.TMIRecShip
            Dim iWO_ID As Integer = 0
            Dim strModel As String = "", strGrade As String = ""
            Dim tmpSN As String = "", strNotes As String = ""

            If e.KeyValue = 13 Then
                If Me.txtSN.Text.Trim.Length = 0 Then
                    Exit Sub
                ElseIf Me._iCC_Group_ID = 0 Then
                    MessageBox.Show("Group ID missing. This machine is not mapped to any Group.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtSN.Text = ""
                    'Me.cboGroup.Focus()
                    Exit Sub
                ElseIf iLine_ID = 0 Then
                    MessageBox.Show("Line ID missing. This machine is not mapped to any Line.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtSN.Text = ""
                    Exit Sub
                End If

                Try
                    ResetControls()

                    '******************************************
                    'Check if device QC AQL passed
                    ''******************************************
                    Me.txtSN.Text = Trim(Me.txtSN.Text)
                    dt1 = objQC.GetDeviceInfo(Me.txtSN.Text, _iMenuCustID, False)
                    If dt1.Rows.Count = 0 Then
                        MessageBox.Show("Can't find this device: " & Me.txtSN.Text, "OBA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub
                        'ElseIf dt1.Rows.Count > 1 Then
                        '    MessageBox.Show("Find duplicated device: " & Me.txtSN.Text & " Please see IT.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        '    Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub
                    End If
                    iDevice_ID = dt1.Rows(0).Item("Device_ID")
                    iWO_ID = dt1.Rows(0).Item("WO_ID")
                    Me._iProductID = dt1.Rows(0).Item("Prod_ID")
                    If Me._iMenuCustID <> objAIG.CUSTOMERID Then
                        If PSS.Data.Buisness.Generic.GetMaxBillRule(iDevice_ID) = 0 AndAlso Not objQC.IsDeviceQC_AQLPassed(iDevice_ID) Then
                            MessageBox.Show("This device " & Me.txtSN.Text & " is not QC AQL passed or not ready to ship.  ", "QC", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub
                        End If
                    End If

                    'Pull up any notes added when it was received
                    If Me._iMenuCustID = objAIG.CUSTOMERID Then
                        strNotes = Me.objAIG.GetReceivingNotes(iWO_ID)
                        If strNotes.Trim.Length > 0 Then
                            Me.grdQCFailRate.Height = (Me._iH / 3) * 2 : Me.txtNotes.Height = (Me._iH / 3) - 5
                            Me.txtNotes.Top = Me.grdQCFailRate.Top + Me.grdQCFailRate.Height + 3
                            Me.txtNotes.Width = Me.grdQCFailRate.Width : Me.txtNotes.Left = Me.grdQCFailRate.Left
                            Me.txtNotes.Text = "NOTES: " & strNotes.Trim : Me.txtNotes.Visible = True : Me.txtNotes.ReadOnly = True
                        Else
                            Me.grdQCFailRate.Height = Me._iH
                            Me.txtNotes.Text = "" : Me.txtNotes.Visible = False
                        End If

                        Me._bPSSWarranty = False : Me._bPSSWarranty_Approved = False
                        Me.lblPssWrty.Visible = False

                        If dt1.Rows(0).Item("Device_PSSWrty") = 1 Then
                            Me._bPSSWarranty = True
                            Me.lblPssWrty.Text = "PSS Warranty: YES"
                        Else
                            Me.lblPssWrty.Text = "PSS Warranty: NO"
                            Me.lblPssWrty.Visible = True
                        End If
                        '*****************************************************************
                        'Simply check PSSWrty and Quote Approval again even though OBA checked them
                        '*****************************************************************
                        dtApprovedData = objAIG.GetApprovedData(iDevice_ID)
                        If dtApprovedData.Rows.Count = 0 Then
                            MessageBox.Show("Cellopt data is missing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        ElseIf dtApprovedData.Rows.Count > 1 Then
                            MessageBox.Show("Duplicate record in cellopt data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        ElseIf dtApprovedData.Rows(0)("Cellopt_WIPOwner").ToString = "6" Then
                            MessageBox.Show("Device is on hold for approval.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        End If
                        'validate Quote approval
                        If objAIG.NeedExceptionRepairsApproval(iDevice_ID, objAIG.CUSTOMERID) AndAlso IsDBNull(dtApprovedData.Rows(0).Item("EstimatedPartCost_Date")) Then
                            MessageBox.Show("Quote is not approved!", "Quote validation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If
                        'validate PSS Wrty
                        If dt1.Rows(0).Item("Device_PSSWrty") = 1 AndAlso IsDBNull(dtApprovedData.Rows(0).Item("PSS_Wrty_Approval_DT")) Then
                            MessageBox.Show("PSS Warranty is not approved!", "PSS Wrty Approval Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        ElseIf dt1.Rows(0).Item("Device_PSSWrty") = 1 AndAlso Not IsDBNull(dtApprovedData.Rows(0).Item("PSS_Wrty_Approval_DT")) Then
                            Me._bPSSWarranty_Approved = True
                            Me.lblPssWrty.Text &= " Approved: YES"
                            Me.lblPssWrty.Visible = True
                        End If
                        '*****************************************************************
                    End If

                    '******************************************
                    'Load device shipping information
                    '******************************************

                    objNI = New PSS.Data.Buisness.NI()
                    If Me._iMenuCustID = objNI.CUSTOMERID Then 'NI
                        dt1 = objQC.NI_getShippingDataByDeviceID(iWO_ID)
                        strModel = objNI.GetModel4DeviceID(iDevice_ID)
                        strGrade = objNI.GetCosmeticGrade4DeviceID(iDevice_ID)
                        If Not strModel.Trim.Length > 0 Then strModel = "No Model Found"
                        If Not strGrade.Trim.Length > 0 Then strGrade = "No Cosmetic Grade Found"
                    ElseIf Me._iMenuCustID = objNI.CUSTOMERID Then 'AIG
                        dt1 = objQC.TMI_getShippingDataByDeviceID(iWO_ID)
                        Me.lblExpectedShipDate.Text = Me.objAIG.GetExpectedShipDate(iWO_ID, 0, False)
                    Else 'TMI
                        dt1 = objQC.TMI_getShippingDataByDeviceID(iWO_ID)
                    End If

                    If dt1.Rows.Count = 0 Then
                        MessageBox.Show("Can't find shipping info for " & Me.txtSN.Text & ". Please see IT.  ", "QC", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub
                    ElseIf dt1.Rows.Count > 1 Then
                        MessageBox.Show("Found the duplicates of shipping info for " & Me.txtSN.Text & ". Please see IT.  ", "QC", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub
                    End If

                    Me.lblEWID_ClaimNo.Text = "EW_ID: " & dt1.Rows(0).Item("EW_ID") & _
                             "  ClaimNo: " & dt1.Rows(0).Item("ClaimNo")
                    Me.lblEWID_ClaimNo.Enabled = False

                    With Me.lstShippingInfo
                        .Items.Clear()
                        .Items.Add(dt1.Rows(0).Item("Customer"))
                        .Items.Add(dt1.Rows(0).Item("Address"))
                        If Me._iMenuCustID = objNI.CUSTOMERID Then
                            .Items.Add(dt1.Rows(0).Item("City") & ", " & dt1.Rows(0).Item("State") & " " & dt1.Rows(0).Item("Zipcode"))
                            .Items.Add(dt1.Rows(0).Item("cntry_Name"))
                        Else 'TMI,AIG
                            .Items.Add(dt1.Rows(0).Item("City") & ", " & dt1.Rows(0).Item("State") & " " & dt1.Rows(0).Item("Zipcode"))
                        End If

                        Me.lblEWID_ClaimNo.TextAlign = ContentAlignment.MiddleRight
                        If Me._iMenuCustID = objNI.CUSTOMERID Then
                            Me.lblProdType.Text = strGrade
                            Me.lblPCModel.Text = strModel
                            tmpSN = dt1.Rows(0).Item("SerialNo")
                            If Not Trim(Me.txtSN.Text).ToUpper = Trim(tmpSN).ToUpper Then
                                Me.lblPCSerial.Text = Trim(Me.txtSN.Text)
                            Else
                                Me.lblPCSerial.Text = Trim(tmpSN)
                            End If
                        Else 'TMI
                            Me.lblProdType.Text = dt1.Rows(0).Item("BrandType")
                            Me.lblPCModel.Text = dt1.Rows(0).Item("Model")
                            Me.lblPCSerial.Text = dt1.Rows(0).Item("SerialNo")
                        End If
                    End With

                    With Me.lstAccessory
                        .Items.Clear()
                        If Me._iMenuCustID = objAIG.CUSTOMERID Then
                            dt1 = objQC.getDeviceAccessoryNames(iDevice_ID)
                            If dt1.Rows.Count > 0 Then
                                For Each row In objQC.getDeviceAccessoryNames(iDevice_ID).Rows
                                    .Items.Add(row("AccessoryDesc"))
                                Next
                                Me.lblAccessory.Text = "Accessory (" & dt1.Rows.Count & "):"
                            Else
                                Me.lblAccessory.Text = "Accessory (0):"
                            End If
                            Me.lblAccessory.Visible = True
                            Me.lstAccessory.Visible = True
                        Else
                            Me.lblAccessory.Visible = False
                            Me.lstAccessory.Visible = False
                        End If
                    End With

                    If Me._iMenuCustID = objAIG.CUSTOMERID Then
                        If Me._bPSSWarranty Then

                        End If
                    Else
                        Me.lblPssWrty.Text = "" : Me.lblPssWrty.Visible = False
                    End If

                    Me.lblPSSI_SN_OK.Text = Trim(Me.txtSN.Text)
                    Me.lblPSSI_SN_OK.ForeColor = Color.Red

                    Me.pnlShippingInfo.Visible = True

                    dt1 = Nothing

                    ''********************************
                    ''Get Device QC History
                    ''********************************
                    LoadFailureCodes()
                    LoadQCHistory()

                    Me.lblSN.Text = Trim(Me.txtSN.Text)
                    Me.txtSN.Text = ""
                    Me.txtSN.Focus()
                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString, "QC", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Finally
                    Buisness.Generic.DisposeDT(dt1)
                    Buisness.Generic.DisposeDT(dtApprovedData)
                    If Not IsNothing(objFrmMD) Then
                        objFrmMD.Dispose()
                        objFrmMD = Nothing
                    End If
                End Try
            ElseIf e.KeyCode = Keys.Escape Then
                Me.ResetControls() : Me.txtSN.Focus()
            ElseIf e.KeyValue = Keys.F9 Then
                PassQC()
            ElseIf e.KeyValue = Keys.F12 Then
                FailQC()
            ElseIf e.KeyValue = Keys.F5 Then
                SaveQCInfo()
            End If
        End Sub


        '*****************************************************************************
        Private Sub LoadQCHistory()
            Dim dt1 As DataTable

            Try
                dt1 = objQC.GetQCHistory(iDevice_ID)
                Me.grdHistory.ClearFields()
                Me.grdHistory.DataSource = dt1.DefaultView
                SetGridProperties()

            Catch ex As Exception
                Throw New Exception("TMI_OBA.LoadQCHistory(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                objQC.DisposeDT(dt1)
            End Try
        End Sub
        '*********************************************************
        Private Sub LoadFailureCodes()
            Dim dtCodes As New DataTable()
            Dim i As Integer
            Try
                dtCodes = objQC.LoadFailureCodes(Me._iProductID)

                With Me.cboCodes
                    .DataSource = dtCodes.DefaultView
                    .DisplayMember = dtCodes.Columns("DCode_SLDesc").ToString
                    .ValueMember = dtCodes.Columns("DCode_ID").ToString
                    For i = 0 To .Columns.Count - 1
                        .Splits(0).DisplayColumns(i).Visible = False
                    Next i
                    .Splits(0).DisplayColumns("DCode_SLDesc").Visible = True
                    .Splits(0).DisplayColumns("DCode_SLDesc").Width = .Width - (.VScrollBar.Width + 4)
                    .SelectedValue = 0
                End With

            Catch ex As Exception
                MsgBox("Error in TMI_OBA.LoadFailureCodes:: " & ex.Message.ToString, MsgBoxStyle.Critical)
            Finally
                objQC.DisposeDT(dtCodes)
            End Try
        End Sub

        '*****************************************************************************
        Private Sub PassQC()

            If iDevice_ID = 0 Then
                MessageBox.Show("Please scan in a device to do QC.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtSN.Focus()
                Exit Sub
            End If

            btnPass.BackColor = System.Drawing.Color.Green
            btnFail.BackColor = System.Drawing.Color.SteelBlue

            iQCResult = 1

            If Me.cboUsers.SelectedValue > 0 Then
                Me.SaveQCInfo()
            Else
                MessageBox.Show("Please select Technician name...", "QC", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.cboUsers.Focus()
            End If
        End Sub

        Private Sub FailQC()
            If iDevice_ID = 0 Then
                MessageBox.Show("Please scan in a device to do QC.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtSN.Focus()
                Exit Sub
            End If

            btnPass.BackColor = System.Drawing.Color.SteelBlue
            btnFail.BackColor = System.Drawing.Color.Red

            iQCResult = 2
            pnlFailCodes.Visible = True
            If Me.cboUsers.SelectedValue > 0 Then
                Me.cboCodes.SelectAll() : Me.cboCodes.Focus()
            Else
                'MessageBox.Show("Please select Technician name...", "QC", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.cboUsers.Focus()
            End If

        End Sub

        '*****************************************************************************
        Private Sub SaveQCInfo()
            Dim i As Integer = 0
            Dim strFailCodes As String = ""
            Dim strNextWrkStation As String = ""
            Dim iStationFailed As Integer = 0
            Dim objDevice As PSS.Rules.Device
            Dim iGroupID As Integer = 0
            Dim objTFMis As PSS.Data.Buisness.TracFone.clsMisc
            Dim booSkipPSDStation As Boolean = False
            Dim iDeviceQty As Integer = 0
            Dim IsValidQCResult As Boolean = False
            Dim strWorkstation As String = ""

            '********************************************************************
            'Required Field validations.
            If PSS.Core.Global.ApplicationUser.IDuser = 0 Then
                MessageBox.Show("Inspector does not have a QC Stamp Number assigned.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtSN.Focus()
                Exit Sub
            End If

            If iDevice_ID = 0 Then      'Adding a new Device_ID
                MessageBox.Show("Please scan in a device to do QC.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtSN.Focus()
                Exit Sub
            End If

            If iQCResult = 1 Or iQCResult = 2 Then 'either not pass or not fail.Must be one of them
                IsValidQCResult = True
            Else
                IsValidQCResult = False
            End If
            If Not IsValidQCResult Then
                MessageBox.Show("Please choose if this device passed or failed QC.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.btnPass.Focus()
                Exit Sub
            End If

            If Me.cboUsers.SelectedValue = 0 Then
                MessageBox.Show("Please select the Tech who worked on this device.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.cboUsers.Focus()
                Exit Sub
            End If

            If Me._iProductID = 1 AndAlso Me._iWO_GroupID > 0 Then
                iGroupID = _iWO_GroupID
            Else
                iGroupID = Me._iCC_Group_ID
            End If

            If iGroupID = 0 Then
                MessageBox.Show("Group ID missing.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            'Ready to save ********************************************************************
            Try
                If iQCResult = 1 AndAlso Me._iMenuCustID = Data.Buisness.AIG.CUSTOMERID Then
                    strWorkstation = Data.Buisness.Generic.GetNextWorkStationInWFP(Me._strScreenName, 0, Me._iMenuCustID, , )
                    If strWorkstation.Trim.Length = 0 Then
                        MessageBox.Show("Can't define workstation in workflow.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                End If

                'i = objQC.SaveQCResultsForOBA(iDevice_ID, Me._iMenufQCTypeID, _
                '          iQCResult, Me.cboUsers.SelectedValue, _
                '          PSS.Core.Global.ApplicationUser.IDuser, _
                '          PSS.Core.Global.ApplicationUser.Workdate, _
                '          iGroupID, iLine_ID, Me._iProductID)

                strFailCodes = Me.ConcatenateCodes()
                i = objQC.SaveQCResults(iDevice_ID, Me._iMenufQCTypeID, _
                      iQCResult, strFailCodes, Me.cboUsers.SelectedValue, _
                      ApplicationUser.IDuser, Me.strWorkDate, _
                      iGroupID, iLine_ID, Me._iProductID, Me.icc_id, , , , , , )

                If iQCResult = 1 AndAlso Me._iMenuCustID = Data.Buisness.AIG.CUSTOMERID Then Data.Buisness.Generic.SetTcelloptWorkStationForDevice(strWorkstation, iDevice_ID, Core.ApplicationUser.IDuser, Me._strScreenName, Me.Name, , , , , , )

                LoadQCHistory()
                LoadQCPASSNumber()
                LoadQCFailureRate()

                iQCResult = 0
                btnPass.BackColor = System.Drawing.Color.SteelBlue
                btnFail.BackColor = System.Drawing.Color.SteelBlue

                Me.iDevice_ID = 0 : Me._iFunRep = 0 : Me._iLaborLevel = 0 : Me._iManufID = 0
                Me._iModelID = 0 : Me._iWrty = 0 : Me._iWO_GroupID = 0

                Me.ClearCodeList()
                Me.pnlFailCodes.Visible = False

            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString, "QC", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                If Not IsNothing(objDevice) Then
                    objDevice.Dispose()
                    objDevice = Nothing
                End If
                Me.txtSN.Focus()
            End Try
        End Sub

        '*****************************************************************************
        Private Sub SetGridProperties()
            Dim iNumOfColumns As Integer = Me.grdHistory.Columns.Count
            Dim i As Integer

            'Heading style (Horizontal Alignment to Center)
            For i = 0 To (iNumOfColumns - 1)
                Me.grdHistory.Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Next

            'Set individual column data horizontal alignment
            Me.grdHistory.Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Set individual column data horizontal alignment
            With Me.grdHistory
                .Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                .Splits(0).DisplayColumns(3).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns(4).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                .Splits(0).DisplayColumns(5).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                .Splits(0).DisplayColumns(6).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                .Splits(0).DisplayColumns(7).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            End With

            'Set Column Widths
            With Me.grdHistory
                .Splits(0).DisplayColumns(0).Width = 50
                .Splits(0).DisplayColumns(1).Width = 65
                .Splits(0).DisplayColumns(2).Width = 61
                .Splits(0).DisplayColumns(3).Width = 58
                .Splits(0).DisplayColumns(4).Width = 69
                .Splits(0).DisplayColumns(5).Width = 213
                .Splits(0).DisplayColumns(6).Width = 171
                .Splits(0).DisplayColumns(7).Width = 145
            End With

            'Make some columns invisible
            Me.grdHistory.Splits(0).DisplayColumns(8).Visible = False
            Me.grdHistory.Splits(0).DisplayColumns(9).Visible = False
            Me.grdHistory.Splits(0).DisplayColumns(10).Visible = False
            Me.grdHistory.Splits(0).DisplayColumns(11).Visible = False
            Me.grdHistory.Splits(0).DisplayColumns("QCType_ID").Visible = False
        End Sub

        '*****************************************************************************
        Private Sub ClearCodeList()
            Me.lstFailCodes.Items.Clear()
        End Sub

        '*****************************************************************************
        Private Function ConcatenateCodes() As String
            Dim i As Integer = 0
            Dim strCodes As String = ""

            For i = 0 To Me.lstFailCodes.Items.Count - 1
                arrSplitLine = Split(Trim(lstFailCodes.Items(i)), strdelimiter)
                strCodes += Trim(arrSplitLine(1))
                If i <> Me.lstFailCodes.Items.Count - 1 Then
                    strCodes += ","
                End If

                ReDim arrSplitLine(0)
                arrSplitLine.Clear(arrSplitLine, 0, arrSplitLine.Length)
            Next i

            ReDim arrSplitLine(0)
            arrSplitLine.Clear(arrSplitLine, 0, arrSplitLine.Length)

            Return strCodes
        End Function

        '*****************************************************************************
        Private Sub LoadQCFailureRate()
            Dim dt1 As DataTable

            Try
                grdQCFailRate.DataSource = Nothing
                dt1 = objQC.LoadQCFailRate(ApplicationUser.Workdate, ApplicationUser.IDuser, _
                                           Me.cboQCType.SelectedValue)
                Me.grdQCFailRate.ClearFields()
                Me.grdQCFailRate.DataSource = dt1.DefaultView
                SetgrdQCFailRateProperties()

            Catch ex As Exception
                Throw New Exception("TMI_OBA.LoadQCHistory(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                objQC.DisposeDT(dt1)
            End Try
        End Sub

        '*********************************************************
        Private Sub LoadQCPASSNumber()
            Dim dt1 As New DataTable()
            Dim R1 As DataRow

            Try
                If ApplicationUser.IDShift = 0 Or ApplicationUser.IDuser = 0 Then
                    Exit Sub
                End If

                dt1 = objQC.GetQC_OBA_PASSNumber(ApplicationUser.IDuser, ApplicationUser.IDShift, Me.cboQCType.SelectedValue, Me._iCC_Group_ID)
                If dt1.Rows.Count > 0 Then
                    R1 = dt1.Rows(0)
                    Me.lblPassed.Text = "Total Passed: " & R1("PassCount")
                Else
                    Me.lblPassed.Text = "Total Passed: 0"
                End If

            Catch ex As Exception
                MsgBox("Error in TMI_OBA.LoadQCNumbers:: " & ex.Message.ToString, MsgBoxStyle.Critical)
            Finally
                R1 = Nothing
                objQC.DisposeDT(dt1)
            End Try
        End Sub

        '*********************************************************************
        Private Sub SetgrdQCFailRateProperties()
            Dim iNumOfColumns As Integer = Me.grdQCFailRate.Columns.Count
            Dim i As Integer

            With Me.grdQCFailRate
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
                .Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns(3).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                'Body Forecolor
                .Splits(0).DisplayColumns(0).Style.ForeColor = .ForeColor.Lime
                .Splits(0).DisplayColumns(1).Style.ForeColor = .ForeColor.Lime
                .Splits(0).DisplayColumns(2).Style.ForeColor = .ForeColor.Lime
                .Splits(0).DisplayColumns(3).Style.ForeColor = .ForeColor.Lime

                'Set Column Widths
                .Splits(0).DisplayColumns(0).Width = 72
                .Splits(0).DisplayColumns(1).Width = 53
                .Splits(0).DisplayColumns(2).Width = 49
                .Splits(0).DisplayColumns(3).Width = 74

                '.Splits(0).DisplayColumns(0).Visible = False
            End With
        End Sub

        Private Sub btnPass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPass.Click
            PassQC()
        End Sub

        Private Sub btnFail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFail.Click
            FailQC()
        End Sub

        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
            Try
                Me.ResetControls()
                Me.txtSN.Focus()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error in btnClear_Click")
            End Try
        End Sub

        Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
            Try
                Me.SaveQCInfo()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Save Result", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click
            Try
                If Me.lstFailCodes.SelectedIndex <> -1 Then    'If nothing is selected
                    Me.lstFailCodes.Items.RemoveAt(Me.lstFailCodes.SelectedIndex)
                    Me.lstFailCodes.Refresh()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Remove Fail Code", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub buttons_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnSave.KeyUp, btnFail.KeyUp, btnPass.KeyUp, btnClear.KeyUp, cmdRemove.KeyUp, cboCodes.KeyUp, cboCustomers.KeyUp, cboQCType.KeyUp, cboUsers.KeyUp, grdHistory.KeyUp, grdQCFailRate.KeyUp
            Try
                If e.KeyCode = Keys.Escape Then
                    Me.ResetControls() : Me.txtSN.Focus()
                ElseIf e.KeyValue = Keys.F9 Then
                    PassQC()
                ElseIf e.KeyValue = Keys.F12 Then
                    FailQC()
                ElseIf e.KeyValue = Keys.F5 Then
                    SaveQCInfo()
                ElseIf sender.name = "cboCodes" And e.KeyValue = 13 AndAlso Me.iQCResult = 2 Then
                    AddCodeToList()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, sender.name & "_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub AddCodeToList()
            Dim i As Integer = 0
            Try
                If Me.cboCodes.SelectedValue = 0 Then
                    MessageBox.Show("Please select the code again.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                Dim strItem As String = Trim(Me.cboCodes.Text) & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & strdelimiter & Me.cboCodes.SelectedValue

                For i = 0 To Me.lstFailCodes.Items.Count - 1
                    If Me.lstFailCodes.Items(i) = strItem Then  'UCase(txtDevice.Text) Then
                        MsgBox("This code is already added to the list.", MsgBoxStyle.Information, "QC")
                        Exit Sub
                    End If
                Next i

                Me.lstFailCodes.Items.Add(strItem)
                Me.cboCodes.SelectedValue = 0
            Catch ex As Exception
                Throw ex
            End Try
        End Sub


    End Class
End Namespace