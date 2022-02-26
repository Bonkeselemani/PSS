Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.Ziosk
    Public Class frmLabel
        Inherits System.Windows.Forms.Form

        Private _iMenuCust_ID As Integer = 0
        Private _strScreenName As String = ""
        Private _objZiosk As PSS.Data.Buisness.Ziosk
        Private _objTracLabel As PSS.Data.Buisness.TracFone.Label

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName As String, ByVal iCust_ID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._iMenuCust_ID = iCust_ID
            Me._strScreenName = strScreenName
            Me._objZiosk = New PSS.Data.Buisness.Ziosk()
            Me._objTracLabel = New PSS.Data.Buisness.TracFone.Label()
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
                Me._objZiosk = Nothing
                Me._objTracLabel = Nothing
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Friend WithEvents cboLabelType As System.Windows.Forms.ComboBox
        Friend WithEvents txtlblSN As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents lblCusts As System.Windows.Forms.Label
        Friend WithEvents lblModels As System.Windows.Forms.Label
        Friend WithEvents Label31 As System.Windows.Forms.Label
        Friend WithEvents cmdlblPrint As System.Windows.Forms.Button
        Friend WithEvents cboCustomers As C1.Win.C1List.C1Combo
        Friend WithEvents cboModels As C1.Win.C1List.C1Combo
        Friend WithEvents txtHWVER As System.Windows.Forms.TextBox
        Friend WithEvents lblHWVER As System.Windows.Forms.Label
        Friend WithEvents lblFCC As System.Windows.Forms.Label
        Friend WithEvents txtFCC As System.Windows.Forms.TextBox
        Friend WithEvents lblDevice As System.Windows.Forms.Label
        Friend WithEvents txtDevice As System.Windows.Forms.TextBox
        Friend WithEvents lblPN As System.Windows.Forms.Label
        Friend WithEvents txtPN As System.Windows.Forms.TextBox
        Friend WithEvents lblMadeIn As System.Windows.Forms.Label
        Friend WithEvents cboMadeIn As C1.Win.C1List.C1Combo
        Friend WithEvents chkNoNeed As System.Windows.Forms.CheckBox
        Friend WithEvents pnlDetail As System.Windows.Forms.Panel
        Friend WithEvents pnlMaster As System.Windows.Forms.Panel
        Friend WithEvents lblMFGSite As System.Windows.Forms.Label
        Friend WithEvents txtMFGSite As System.Windows.Forms.TextBox
        Friend WithEvents lblModelLabledesc As System.Windows.Forms.Label
        Friend WithEvents txtModelLabledesc As System.Windows.Forms.TextBox
        Friend WithEvents btnReset As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmLabel))
            Me.cboLabelType = New System.Windows.Forms.ComboBox()
            Me.txtlblSN = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.lblCusts = New System.Windows.Forms.Label()
            Me.lblModels = New System.Windows.Forms.Label()
            Me.Label31 = New System.Windows.Forms.Label()
            Me.cmdlblPrint = New System.Windows.Forms.Button()
            Me.cboCustomers = New C1.Win.C1List.C1Combo()
            Me.cboModels = New C1.Win.C1List.C1Combo()
            Me.txtHWVER = New System.Windows.Forms.TextBox()
            Me.lblHWVER = New System.Windows.Forms.Label()
            Me.pnlDetail = New System.Windows.Forms.Panel()
            Me.lblModelLabledesc = New System.Windows.Forms.Label()
            Me.txtModelLabledesc = New System.Windows.Forms.TextBox()
            Me.chkNoNeed = New System.Windows.Forms.CheckBox()
            Me.lblMadeIn = New System.Windows.Forms.Label()
            Me.cboMadeIn = New C1.Win.C1List.C1Combo()
            Me.lblPN = New System.Windows.Forms.Label()
            Me.txtPN = New System.Windows.Forms.TextBox()
            Me.lblDevice = New System.Windows.Forms.Label()
            Me.txtDevice = New System.Windows.Forms.TextBox()
            Me.lblFCC = New System.Windows.Forms.Label()
            Me.txtFCC = New System.Windows.Forms.TextBox()
            Me.lblMFGSite = New System.Windows.Forms.Label()
            Me.txtMFGSite = New System.Windows.Forms.TextBox()
            Me.pnlMaster = New System.Windows.Forms.Panel()
            Me.btnReset = New System.Windows.Forms.Button()
            CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboModels, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlDetail.SuspendLayout()
            CType(Me.cboMadeIn, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlMaster.SuspendLayout()
            Me.SuspendLayout()
            '
            'cboLabelType
            '
            Me.cboLabelType.Items.AddRange(New Object() {"Label", "Relabel"})
            Me.cboLabelType.Location = New System.Drawing.Point(888, 16)
            Me.cboLabelType.Name = "cboLabelType"
            Me.cboLabelType.Size = New System.Drawing.Size(32, 21)
            Me.cboLabelType.TabIndex = 7
            Me.cboLabelType.Visible = False
            '
            'txtlblSN
            '
            Me.txtlblSN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtlblSN.Location = New System.Drawing.Point(128, 72)
            Me.txtlblSN.Name = "txtlblSN"
            Me.txtlblSN.Size = New System.Drawing.Size(215, 22)
            Me.txtlblSN.TabIndex = 0
            Me.txtlblSN.Text = ""
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Black
            Me.Label1.Location = New System.Drawing.Point(768, 16)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(112, 19)
            Me.Label1.TabIndex = 6
            Me.Label1.Text = "Label Type:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
            Me.Label1.Visible = False
            '
            'lblCusts
            '
            Me.lblCusts.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCusts.ForeColor = System.Drawing.Color.Black
            Me.lblCusts.Location = New System.Drawing.Point(16, 8)
            Me.lblCusts.Name = "lblCusts"
            Me.lblCusts.Size = New System.Drawing.Size(112, 24)
            Me.lblCusts.TabIndex = 1
            Me.lblCusts.Text = "Customer:"
            Me.lblCusts.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'lblModels
            '
            Me.lblModels.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModels.ForeColor = System.Drawing.Color.Black
            Me.lblModels.Location = New System.Drawing.Point(16, 40)
            Me.lblModels.Name = "lblModels"
            Me.lblModels.Size = New System.Drawing.Size(112, 19)
            Me.lblModels.TabIndex = 3
            Me.lblModels.Text = "Model:"
            Me.lblModels.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'Label31
            '
            Me.Label31.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label31.Location = New System.Drawing.Point(8, 72)
            Me.Label31.Name = "Label31"
            Me.Label31.Size = New System.Drawing.Size(112, 20)
            Me.Label31.TabIndex = 8
            Me.Label31.Text = "Serial Number:"
            Me.Label31.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'cmdlblPrint
            '
            Me.cmdlblPrint.BackColor = System.Drawing.Color.SteelBlue
            Me.cmdlblPrint.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdlblPrint.ForeColor = System.Drawing.Color.White
            Me.cmdlblPrint.Location = New System.Drawing.Point(280, 240)
            Me.cmdlblPrint.Name = "cmdlblPrint"
            Me.cmdlblPrint.Size = New System.Drawing.Size(215, 38)
            Me.cmdlblPrint.TabIndex = 30
            Me.cmdlblPrint.Text = "Print Label"
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
            Me.cboCustomers.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCustomers.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboCustomers.ItemHeight = 15
            Me.cboCustomers.Location = New System.Drawing.Point(128, 8)
            Me.cboCustomers.MatchEntryTimeout = CType(2000, Long)
            Me.cboCustomers.MaxDropDownItems = CType(5, Short)
            Me.cboCustomers.MaxLength = 32767
            Me.cboCustomers.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCustomers.Name = "cboCustomers"
            Me.cboCustomers.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCustomers.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCustomers.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCustomers.Size = New System.Drawing.Size(215, 21)
            Me.cboCustomers.TabIndex = 2
            Me.cboCustomers.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
            "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Arial, 9." & _
            "75pt;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style1{}OddRow{}" & _
            "RecordSelector{AlignImage:Center;}Heading{Wrap:True;BackColor:Control;Border:Rai" & _
            "sed,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}Style10{}Style11" & _
            "{}Style9{AlignHorz:Near;}</Data></Styles><Splits><C1.Win.C1List.ListBoxView Allo" & _
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
            Me.cboModels.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboModels.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboModels.ItemHeight = 15
            Me.cboModels.Location = New System.Drawing.Point(128, 40)
            Me.cboModels.MatchEntryTimeout = CType(2000, Long)
            Me.cboModels.MaxDropDownItems = CType(5, Short)
            Me.cboModels.MaxLength = 32767
            Me.cboModels.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModels.Name = "cboModels"
            Me.cboModels.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModels.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModels.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModels.Size = New System.Drawing.Size(215, 21)
            Me.cboModels.TabIndex = 4
            Me.cboModels.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
            "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Arial, 9." & _
            "75pt;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style9{AlignHorz" & _
            ":Near;}OddRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;AlignVert:Cen" & _
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
            'txtHWVER
            '
            Me.txtHWVER.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtHWVER.Location = New System.Drawing.Point(136, 96)
            Me.txtHWVER.Name = "txtHWVER"
            Me.txtHWVER.Size = New System.Drawing.Size(215, 22)
            Me.txtHWVER.TabIndex = 22
            Me.txtHWVER.Text = ""
            '
            'lblHWVER
            '
            Me.lblHWVER.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblHWVER.Location = New System.Drawing.Point(16, 96)
            Me.lblHWVER.Name = "lblHWVER"
            Me.lblHWVER.Size = New System.Drawing.Size(112, 20)
            Me.lblHWVER.TabIndex = 10
            Me.lblHWVER.Text = "H/W VER:"
            Me.lblHWVER.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'pnlDetail
            '
            Me.pnlDetail.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblModelLabledesc, Me.txtModelLabledesc, Me.chkNoNeed, Me.lblMadeIn, Me.cboMadeIn, Me.lblPN, Me.txtPN, Me.lblDevice, Me.txtDevice, Me.lblFCC, Me.txtFCC, Me.lblMFGSite, Me.txtMFGSite, Me.lblHWVER, Me.txtHWVER, Me.cmdlblPrint})
            Me.pnlDetail.Location = New System.Drawing.Point(24, 136)
            Me.pnlDetail.Name = "pnlDetail"
            Me.pnlDetail.Size = New System.Drawing.Size(856, 424)
            Me.pnlDetail.TabIndex = 11
            '
            'lblModelLabledesc
            '
            Me.lblModelLabledesc.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModelLabledesc.Location = New System.Drawing.Point(16, 32)
            Me.lblModelLabledesc.Name = "lblModelLabledesc"
            Me.lblModelLabledesc.Size = New System.Drawing.Size(104, 20)
            Me.lblModelLabledesc.TabIndex = 23
            Me.lblModelLabledesc.Text = "Model Desc:"
            Me.lblModelLabledesc.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'txtModelLabledesc
            '
            Me.txtModelLabledesc.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtModelLabledesc.Location = New System.Drawing.Point(136, 32)
            Me.txtModelLabledesc.Name = "txtModelLabledesc"
            Me.txtModelLabledesc.Size = New System.Drawing.Size(216, 22)
            Me.txtModelLabledesc.TabIndex = 20
            Me.txtModelLabledesc.Text = ""
            '
            'chkNoNeed
            '
            Me.chkNoNeed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkNoNeed.Location = New System.Drawing.Point(704, 32)
            Me.chkNoNeed.Name = "chkNoNeed"
            Me.chkNoNeed.TabIndex = 21
            Me.chkNoNeed.Text = "No Need"
            '
            'lblMadeIn
            '
            Me.lblMadeIn.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMadeIn.ForeColor = System.Drawing.Color.Black
            Me.lblMadeIn.Location = New System.Drawing.Point(400, 112)
            Me.lblMadeIn.Name = "lblMadeIn"
            Me.lblMadeIn.Size = New System.Drawing.Size(80, 19)
            Me.lblMadeIn.TabIndex = 19
            Me.lblMadeIn.Text = "Made In :"
            Me.lblMadeIn.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'cboMadeIn
            '
            Me.cboMadeIn.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboMadeIn.Caption = ""
            Me.cboMadeIn.CaptionHeight = 17
            Me.cboMadeIn.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboMadeIn.ColumnCaptionHeight = 17
            Me.cboMadeIn.ColumnFooterHeight = 17
            Me.cboMadeIn.ContentHeight = 15
            Me.cboMadeIn.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboMadeIn.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboMadeIn.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboMadeIn.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboMadeIn.EditorHeight = 15
            Me.cboMadeIn.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboMadeIn.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboMadeIn.ItemHeight = 15
            Me.cboMadeIn.Location = New System.Drawing.Point(488, 112)
            Me.cboMadeIn.MatchEntryTimeout = CType(2000, Long)
            Me.cboMadeIn.MaxDropDownItems = CType(5, Short)
            Me.cboMadeIn.MaxLength = 32767
            Me.cboMadeIn.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboMadeIn.Name = "cboMadeIn"
            Me.cboMadeIn.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboMadeIn.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboMadeIn.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboMadeIn.Size = New System.Drawing.Size(215, 21)
            Me.cboMadeIn.TabIndex = 26
            Me.cboMadeIn.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
            "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Arial, 9." & _
            "75pt;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style1{}OddRow{}" & _
            "RecordSelector{AlignImage:Center;}Heading{Wrap:True;BackColor:Control;Border:Rai" & _
            "sed,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}Style10{}Style11" & _
            "{}Style9{AlignHorz:Near;}</Data></Styles><Splits><C1.Win.C1List.ListBoxView Allo" & _
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
            'lblPN
            '
            Me.lblPN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPN.Location = New System.Drawing.Point(400, 72)
            Me.lblPN.Name = "lblPN"
            Me.lblPN.Size = New System.Drawing.Size(80, 20)
            Me.lblPN.TabIndex = 18
            Me.lblPN.Text = "Label PN:"
            Me.lblPN.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'txtPN
            '
            Me.txtPN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPN.Location = New System.Drawing.Point(488, 72)
            Me.txtPN.Name = "txtPN"
            Me.txtPN.Size = New System.Drawing.Size(215, 22)
            Me.txtPN.TabIndex = 25
            Me.txtPN.Text = ""
            '
            'lblDevice
            '
            Me.lblDevice.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDevice.Location = New System.Drawing.Point(408, 32)
            Me.lblDevice.Name = "lblDevice"
            Me.lblDevice.Size = New System.Drawing.Size(72, 20)
            Me.lblDevice.TabIndex = 16
            Me.lblDevice.Text = "Device:"
            Me.lblDevice.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'txtDevice
            '
            Me.txtDevice.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDevice.Location = New System.Drawing.Point(488, 32)
            Me.txtDevice.Name = "txtDevice"
            Me.txtDevice.Size = New System.Drawing.Size(215, 22)
            Me.txtDevice.TabIndex = 24
            Me.txtDevice.Text = ""
            '
            'lblFCC
            '
            Me.lblFCC.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblFCC.Location = New System.Drawing.Point(16, 64)
            Me.lblFCC.Name = "lblFCC"
            Me.lblFCC.Size = New System.Drawing.Size(112, 20)
            Me.lblFCC.TabIndex = 14
            Me.lblFCC.Text = "FCC ID:"
            Me.lblFCC.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'txtFCC
            '
            Me.txtFCC.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtFCC.Location = New System.Drawing.Point(136, 64)
            Me.txtFCC.Name = "txtFCC"
            Me.txtFCC.Size = New System.Drawing.Size(215, 22)
            Me.txtFCC.TabIndex = 21
            Me.txtFCC.Text = ""
            '
            'lblMFGSite
            '
            Me.lblMFGSite.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMFGSite.Location = New System.Drawing.Point(16, 136)
            Me.lblMFGSite.Name = "lblMFGSite"
            Me.lblMFGSite.Size = New System.Drawing.Size(112, 20)
            Me.lblMFGSite.TabIndex = 12
            Me.lblMFGSite.Text = "MFG SITE:"
            Me.lblMFGSite.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'txtMFGSite
            '
            Me.txtMFGSite.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtMFGSite.Location = New System.Drawing.Point(136, 136)
            Me.txtMFGSite.Name = "txtMFGSite"
            Me.txtMFGSite.Size = New System.Drawing.Size(215, 22)
            Me.txtMFGSite.TabIndex = 23
            Me.txtMFGSite.Text = ""
            '
            'pnlMaster
            '
            Me.pnlMaster.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblCusts, Me.lblModels, Me.cboCustomers, Me.Label31, Me.cboModels, Me.txtlblSN})
            Me.pnlMaster.Location = New System.Drawing.Point(32, 24)
            Me.pnlMaster.Name = "pnlMaster"
            Me.pnlMaster.Size = New System.Drawing.Size(376, 104)
            Me.pnlMaster.TabIndex = 12
            '
            'btnReset
            '
            Me.btnReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReset.ForeColor = System.Drawing.Color.Black
            Me.btnReset.Location = New System.Drawing.Point(432, 88)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.Size = New System.Drawing.Size(104, 32)
            Me.btnReset.TabIndex = 13
            Me.btnReset.Text = "Reset"
            '
            'frmLabel
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(936, 598)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnReset, Me.pnlMaster, Me.pnlDetail, Me.cboLabelType, Me.Label1})
            Me.Name = "frmLabel"
            Me.Text = "frmLabel"
            CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboModels, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlDetail.ResumeLayout(False)
            CType(Me.cboMadeIn, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlMaster.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmLabel_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt1, dt2, dt3 As DataTable
            Try
                PSS.Core.Highlight.SetHighLight(Me)

                'Load Customer
                dt1 = Generic.GetCustomers(True, Me._objZiosk.Prod_ID)
                Misc.PopulateC1DropDownList(Me.cboCustomers, dt1, "Cust_Name1", "Cust_ID")
                Me.cboCustomers.SelectedValue = Me._iMenuCust_ID
                Me.cboCustomers.Enabled = False

                'Load Model
                dt2 = Generic.GetModels(True, Me._objZiosk.Prod_ID, )
                Misc.PopulateC1DropDownList(Me.cboModels, dt2, "Model_desc", "Model_id")
                Try
                    Me.cboModels.SelectedValue = 4413
                Catch ex As Exception
                End Try

                dt3 = _objTracLabel.GetManufCountry(True)
                Misc.PopulateC1DropDownList(Me.cboMadeIn, dt3, "mc_name", "mc_id")
                Me.cboMadeIn.SelectedValue = 2
                Me.pnlDetail.Visible = False

                Me.txtlblSN.SelectAll() : Me.txtlblSN.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.Message, "frmLabel_Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub cmdlblPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdlblPrint.Click
            Dim strSN As String = Me.txtlblSN.Text.Trim
            Dim dt As DataTable
            Dim strDeviceRev As String = ""
            Dim strPN As String = ""
            ' Dim strCountry As String = ""

            Try
                Me.Cursor = Cursors.WaitCursor

                If strSN.Length = 0 Then
                    MessageBox.Show("No device SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtlblSN.SelectAll() : Me.txtlblSN.Focus()
                ElseIf Not Me.cboModels.SelectedValue > 0 Then
                    MessageBox.Show("Please select a model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ElseIf Not Me._objZiosk.IsSNExist(Me._iMenuCust_ID, Me.cboModels.SelectedValue, strSN) Then
                    MessageBox.Show("Can't find this device based on your selections.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ElseIf Me.txtHWVER.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter HW VER.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtHWVER.SelectAll() : Me.txtHWVER.Focus()
                ElseIf Me.txtMFGSite.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter MFG SITE.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtMFGSite.SelectAll() : Me.txtMFGSite.Focus()
                ElseIf Me.txtFCC.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter FCC ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtFCC.SelectAll() : Me.txtFCC.Focus()
                ElseIf Not Me.cboMadeIn.SelectedValue > 0 Then
                    MessageBox.Show("Please select Made In (country name).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtFCC.SelectAll() : Me.txtFCC.Focus()
                ElseIf Not Me.chkNoNeed.Checked AndAlso Me.txtDevice.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter device.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtDevice.SelectAll() : Me.txtDevice.Focus()
                ElseIf Me.txtPN.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter label PN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtPN.SelectAll() : Me.txtPN.Focus()
                ElseIf Me.txtModelLabledesc.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter model desc.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtModelLabledesc.SelectAll() : Me.txtModelLabledesc.Focus()
                Else
                    If Not Me.chkNoNeed.Checked Then strDeviceRev = "Device: " & Me.txtDevice.Text.Trim
                    ' strDeviceRev = "Device: " & Me.txtDevice.Text.Trim

                    strPN = "Label PN " & Me.txtPN.Text

                    Me.cmdlblPrint.Enabled = False
                    Me._objZiosk.PrintZioskLabel(Me._iMenuCust_ID, Me.cboModels.SelectedValue, strSN.ToUpper, Me.txtHWVER.Text.ToUpper, Me.txtModelLabledesc.Text, _
                                                 Me.txtMFGSite.Text.ToUpper, strDeviceRev, strPN, Me.cboMadeIn.Text, Me.txtFCC.Text)
                    ClearFields()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "frmLabel_Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Cursor = Cursors.Default : Me.cmdlblPrint.Enabled = True
            End Try
        End Sub

        Private Sub ClearFields()
            Try
                With Me
                    .pnlMaster.Enabled = True
                    .txtDevice.Text = ""
                    .txtFCC.Text = ""
                    .txtHWVER.Text = ""
                    .txtlblSN.Text = ""
                    .txtMFGSite.Text = ""
                    .txtModelLabledesc.Text = ""
                    .txtPN.Text = ""
                    .chkNoNeed.Checked = False
                    .pnlDetail.Visible = False
                    .txtDevice.Enabled = True
                    .chkNoNeed.ForeColor = Color.Black
                    .txtlblSN.SelectAll()
                    .txtlblSN.Focus()
                End With
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ClearFields", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
        Private Sub txtlblSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtlblSN.KeyUp
            Try
                Me.pnlMaster.Enabled = True : Me.chkNoNeed.Checked = False
                Dim strSN As String = Me.txtlblSN.Text.Trim

                If e.KeyCode = Keys.Enter AndAlso strSN.Length > 0 Then
                    If Not Me.cboModels.SelectedValue > 0 Then
                        MessageBox.Show("Please select a model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.pnlMaster.Enabled = True : Me.txtlblSN.SelectAll() : Me.txtlblSN.Focus() : Exit Sub
                    ElseIf Not Me._objZiosk.IsSNExist(Me._iMenuCust_ID, Me.cboModels.SelectedValue, strSN) Then
                        MessageBox.Show("Can't find this device based on your selections.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.pnlMaster.Enabled = True : Me.txtlblSN.SelectAll() : Me.txtlblSN.Focus() : Exit Sub
                    End If

                    Dim strFCC As String = "", strModelLabelDesc As String = ""
                    Me.pnlDetail.Visible = True

                    Me._objZiosk.getFCCAndModelLabelDesc(Me.cboModels.SelectedValue, strFCC, strModelLabelDesc)
                    Me.txtFCC.Text = strFCC : Me.txtModelLabledesc.Text = strModelLabelDesc
                    Me.txtHWVER.SelectAll() : Me.txtHWVER.Focus()
                    Me.pnlMaster.Enabled = False
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, sender.name & "_KeyUP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub chkNoNeed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNoNeed.CheckedChanged
            Try
                If Me.chkNoNeed.Checked Then
                    Me.txtDevice.Text = "" : Me.txtDevice.Enabled = False : Me.chkNoNeed.ForeColor = Color.MediumBlue
                    Me.txtPN.SelectAll() : Me.txtPN.Focus()
                Else
                    Me.txtDevice.Enabled = True : Me.chkNoNeed.ForeColor = Color.Black
                    Me.txtDevice.SelectAll() : Me.txtDevice.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, sender.name & "_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
            Me.ClearFields()
        End Sub

        Private Sub txtlblSN_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlblSN.Leave
            Try
                Me.txtlblSN.Text = Me.txtlblSN.Text.ToUpper
            Catch ex As Exception
                MessageBox.Show(ex.Message, sender.name & "_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub txtHWVER_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHWVER.Leave
            Try
                Me.txtHWVER.Text = Me.txtHWVER.Text.ToUpper
            Catch ex As Exception
                MessageBox.Show(ex.Message, sender.name & "_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub txtMFGSite_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMFGSite.Leave
            Try
                Me.txtMFGSite.Text = Me.txtMFGSite.Text.ToUpper
            Catch ex As Exception
                MessageBox.Show(ex.Message, sender.name & "_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub txtModelLabledesc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtModelLabledesc.KeyUp
            Try
                If e.KeyCode = Keys.Enter AndAlso txtModelLabledesc.Text.Trim.Length > 0 Then
                    Me.txtFCC.SelectAll() : Me.txtFCC.Focus()
                End If
            Catch ex As Exception
            End Try
        End Sub

        Private Sub txtFCC_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFCC.KeyUp
            Try
                If e.KeyCode = Keys.Enter AndAlso txtFCC.Text.Trim.Length > 0 Then
                    Me.txtHWVER.SelectAll() : Me.txtHWVER.Focus()
                End If
            Catch ex As Exception
            End Try
        End Sub

        Private Sub txtHWVER_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHWVER.KeyUp
            Try
                If e.KeyCode = Keys.Enter AndAlso Me.txtHWVER.Text.Trim.Length > 0 Then
                    Me.txtMFGSite.SelectAll() : Me.txtMFGSite.Focus()
                End If
            Catch ex As Exception
            End Try
        End Sub

        Private Sub txtMFGSite_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMFGSite.KeyUp
            Try
                If e.KeyCode = Keys.Enter AndAlso Me.txtMFGSite.Text.Trim.Length > 0 Then
                    Me.txtDevice.SelectAll() : Me.txtDevice.Focus()
                End If
            Catch ex As Exception
            End Try
        End Sub

        Private Sub txtDevice_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDevice.KeyUp
            Try
                If e.KeyCode = Keys.Enter AndAlso Not Me.chkNoNeed.Checked AndAlso Me.txtDevice.Text.Trim.Length > 0 Then
                    Me.txtPN.SelectAll() : Me.txtPN.Focus()
                ElseIf e.KeyCode = Keys.Enter AndAlso Me.chkNoNeed.Checked Then
                    Me.txtPN.SelectAll() : Me.txtPN.Focus()
                End If
            Catch ex As Exception
            End Try
        End Sub

        Private Sub txtPN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPN.KeyUp
            Try
                If e.KeyCode = Keys.Enter AndAlso Me.txtPN.Text.Trim.Length > 0 Then
                    Me.cboMadeIn.Focus()
                End If
            Catch ex As Exception
            End Try
        End Sub
    End Class
End Namespace
