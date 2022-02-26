Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui
    Public Class frmAstroProductionReceiving
        Inherits System.Windows.Forms.Form

        Private _iMenuCustID As Integer
        Private _objSkullcandy As Skullcandy
        Private _objSkullcandyRec As SkullcandyRec
        Private _iModelID As Integer = 0 'The first Model_ID of the Bundle
        Private _iModelID_2 As Integer = 0 'The second Model_ID of the Bundle
        Private _iWOID As Integer = 0
        Private _iWOLID As Integer = 0
        ' Private _bApprovedToReceive As Boolean = False
        Private _dtPeriod1 As Integer = 7 '7 days default for received data
        Private _FirstStart As Boolean = True
        Dim _toolTip1 As New ToolTip()

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iCustID As Integer, ByVal strScreenName As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._iMenuCustID = iCustID
            Me._objSkullcandy = New Skullcandy()
            Me._objSkullcandyRec = New SkullcandyRec()
            Me.lblTitle.Text = strScreenName

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
        Friend WithEvents cboCustomer As C1.Win.C1List.C1Combo
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents pnlBoxData As System.Windows.Forms.Panel
        Friend WithEvents lblBoxWO As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents lblModel As System.Windows.Forms.Label
        Friend WithEvents lbllblRetailer As System.Windows.Forms.Label
        Friend WithEvents lblRetailer As System.Windows.Forms.Label
        Friend WithEvents lbllblModel As System.Windows.Forms.Label
        Friend WithEvents lblQty As System.Windows.Forms.Label
        Friend WithEvents lblModelItemDesc As System.Windows.Forms.Label
        Friend WithEvents pnlBox As System.Windows.Forms.Panel
        Friend WithEvents lbllblQty2 As System.Windows.Forms.Label
        Friend WithEvents lblQty2 As System.Windows.Forms.Label
        Friend WithEvents lbllblQty1 As System.Windows.Forms.Label
        Friend WithEvents lblQty1 As System.Windows.Forms.Label
        Friend WithEvents lstPartialBox2 As System.Windows.Forms.ListBox
        Friend WithEvents lstPartialBox1 As System.Windows.Forms.ListBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents txtSN As System.Windows.Forms.TextBox
        Friend WithEvents pnlSN As System.Windows.Forms.Panel
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
        Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
        Friend WithEvents btnDelete As System.Windows.Forms.Button
        Friend WithEvents btnReceive As System.Windows.Forms.Button
        Friend WithEvents btnApproval As System.Windows.Forms.Button
        Friend WithEvents tdgData1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents lblRecNum As System.Windows.Forms.Label
        Friend WithEvents btnGetReceivedData As System.Windows.Forms.Button
        Friend WithEvents cboOpenBox As C1.Win.C1List.C1Combo
        Friend WithEvents lblProcessType As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAstroProductionReceiving))
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.cboCustomer = New C1.Win.C1List.C1Combo()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.pnlBoxData = New System.Windows.Forms.Panel()
            Me.lblBoxWO = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.lblModel = New System.Windows.Forms.Label()
            Me.lbllblRetailer = New System.Windows.Forms.Label()
            Me.lblRetailer = New System.Windows.Forms.Label()
            Me.lbllblModel = New System.Windows.Forms.Label()
            Me.lblQty = New System.Windows.Forms.Label()
            Me.lblModelItemDesc = New System.Windows.Forms.Label()
            Me.pnlBox = New System.Windows.Forms.Panel()
            Me.cboOpenBox = New C1.Win.C1List.C1Combo()
            Me.lbllblQty2 = New System.Windows.Forms.Label()
            Me.lblQty2 = New System.Windows.Forms.Label()
            Me.lbllblQty1 = New System.Windows.Forms.Label()
            Me.lblQty1 = New System.Windows.Forms.Label()
            Me.lstPartialBox2 = New System.Windows.Forms.ListBox()
            Me.lstPartialBox1 = New System.Windows.Forms.ListBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtSN = New System.Windows.Forms.TextBox()
            Me.pnlSN = New System.Windows.Forms.Panel()
            Me.lblProcessType = New System.Windows.Forms.Label()
            Me.btnDelete = New System.Windows.Forms.Button()
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.TabPage1 = New System.Windows.Forms.TabPage()
            Me.btnApproval = New System.Windows.Forms.Button()
            Me.btnReceive = New System.Windows.Forms.Button()
            Me.TabPage2 = New System.Windows.Forms.TabPage()
            Me.lblRecNum = New System.Windows.Forms.Label()
            Me.tdgData1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnGetReceivedData = New System.Windows.Forms.Button()
            Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
            Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label9 = New System.Windows.Forms.Label()
            CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlBoxData.SuspendLayout()
            Me.pnlBox.SuspendLayout()
            CType(Me.cboOpenBox, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlSN.SuspendLayout()
            Me.TabControl1.SuspendLayout()
            Me.TabPage1.SuspendLayout()
            Me.TabPage2.SuspendLayout()
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTitle.ForeColor = System.Drawing.Color.Navy
            Me.lblTitle.Location = New System.Drawing.Point(8, 0)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(224, 24)
            Me.lblTitle.TabIndex = 94
            Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
            Me.cboCustomer.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboCustomer.ItemHeight = 15
            Me.cboCustomer.Location = New System.Drawing.Point(208, 4)
            Me.cboCustomer.MatchEntryTimeout = CType(2000, Long)
            Me.cboCustomer.MaxDropDownItems = CType(10, Short)
            Me.cboCustomer.MaxLength = 32767
            Me.cboCustomer.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCustomer.Name = "cboCustomer"
            Me.cboCustomer.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCustomer.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCustomer.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCustomer.Size = New System.Drawing.Size(232, 21)
            Me.cboCustomer.TabIndex = 95
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
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.LightGray
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.Location = New System.Drawing.Point(8, 8)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(88, 24)
            Me.Label1.TabIndex = 100
            Me.Label1.Text = "Pallet Box/WO:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'pnlBoxData
            '
            Me.pnlBoxData.BackColor = System.Drawing.Color.LightGray
            Me.pnlBoxData.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblBoxWO, Me.Label4, Me.lblModel, Me.lbllblRetailer, Me.lblRetailer, Me.lbllblModel, Me.lblQty, Me.lblModelItemDesc})
            Me.pnlBoxData.Location = New System.Drawing.Point(0, 32)
            Me.pnlBoxData.Name = "pnlBoxData"
            Me.pnlBoxData.Size = New System.Drawing.Size(344, 120)
            Me.pnlBoxData.TabIndex = 108
            '
            'lblBoxWO
            '
            Me.lblBoxWO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBoxWO.ForeColor = System.Drawing.Color.DarkGreen
            Me.lblBoxWO.Location = New System.Drawing.Point(104, 1)
            Me.lblBoxWO.Name = "lblBoxWO"
            Me.lblBoxWO.Size = New System.Drawing.Size(232, 24)
            Me.lblBoxWO.TabIndex = 108
            '
            'Label4
            '
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.Location = New System.Drawing.Point(8, 24)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(88, 24)
            Me.Label4.TabIndex = 104
            Me.Label4.Text = "Box Qty:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblModel
            '
            Me.lblModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModel.Location = New System.Drawing.Point(216, 32)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(32, 24)
            Me.lblModel.TabIndex = 101
            '
            'lbllblRetailer
            '
            Me.lbllblRetailer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbllblRetailer.ForeColor = System.Drawing.Color.SlateGray
            Me.lbllblRetailer.Location = New System.Drawing.Point(0, 96)
            Me.lbllblRetailer.Name = "lbllblRetailer"
            Me.lbllblRetailer.Size = New System.Drawing.Size(280, 24)
            Me.lbllblRetailer.TabIndex = 106
            Me.lbllblRetailer.Text = "Retailer:"
            Me.lbllblRetailer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblRetailer
            '
            Me.lblRetailer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRetailer.Location = New System.Drawing.Point(272, 56)
            Me.lblRetailer.Name = "lblRetailer"
            Me.lblRetailer.Size = New System.Drawing.Size(48, 24)
            Me.lblRetailer.TabIndex = 107
            '
            'lbllblModel
            '
            Me.lbllblModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbllblModel.ForeColor = System.Drawing.Color.SlateGray
            Me.lbllblModel.Location = New System.Drawing.Point(0, 80)
            Me.lbllblModel.Name = "lbllblModel"
            Me.lbllblModel.Size = New System.Drawing.Size(288, 24)
            Me.lbllblModel.TabIndex = 100
            Me.lbllblModel.Text = "Item Desc:"
            Me.lbllblModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblQty
            '
            Me.lblQty.BackColor = System.Drawing.Color.Black
            Me.lblQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblQty.ForeColor = System.Drawing.Color.Lime
            Me.lblQty.Location = New System.Drawing.Point(104, 24)
            Me.lblQty.Name = "lblQty"
            Me.lblQty.Size = New System.Drawing.Size(96, 32)
            Me.lblQty.TabIndex = 105
            Me.lblQty.Text = "0"
            Me.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblModelItemDesc
            '
            Me.lblModelItemDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModelItemDesc.Location = New System.Drawing.Point(256, 32)
            Me.lblModelItemDesc.Name = "lblModelItemDesc"
            Me.lblModelItemDesc.Size = New System.Drawing.Size(56, 24)
            Me.lblModelItemDesc.TabIndex = 103
            '
            'pnlBox
            '
            Me.pnlBox.BackColor = System.Drawing.Color.LightGray
            Me.pnlBox.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.pnlBoxData, Me.cboOpenBox})
            Me.pnlBox.Location = New System.Drawing.Point(8, 16)
            Me.pnlBox.Name = "pnlBox"
            Me.pnlBox.Size = New System.Drawing.Size(360, 152)
            Me.pnlBox.TabIndex = 109
            '
            'cboOpenBox
            '
            Me.cboOpenBox.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboOpenBox.AutoCompletion = True
            Me.cboOpenBox.AutoDropDown = True
            Me.cboOpenBox.AutoSelect = True
            Me.cboOpenBox.Caption = ""
            Me.cboOpenBox.CaptionHeight = 17
            Me.cboOpenBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboOpenBox.ColumnCaptionHeight = 17
            Me.cboOpenBox.ColumnFooterHeight = 17
            Me.cboOpenBox.ColumnHeaders = False
            Me.cboOpenBox.ContentHeight = 15
            Me.cboOpenBox.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboOpenBox.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboOpenBox.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboOpenBox.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboOpenBox.EditorHeight = 15
            Me.cboOpenBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboOpenBox.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboOpenBox.ItemHeight = 15
            Me.cboOpenBox.Location = New System.Drawing.Point(104, 8)
            Me.cboOpenBox.MatchEntryTimeout = CType(2000, Long)
            Me.cboOpenBox.MaxDropDownItems = CType(10, Short)
            Me.cboOpenBox.MaxLength = 32767
            Me.cboOpenBox.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboOpenBox.Name = "cboOpenBox"
            Me.cboOpenBox.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboOpenBox.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboOpenBox.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboOpenBox.Size = New System.Drawing.Size(256, 21)
            Me.cboOpenBox.TabIndex = 113
            Me.cboOpenBox.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'lbllblQty2
            '
            Me.lbllblQty2.BackColor = System.Drawing.Color.Lavender
            Me.lbllblQty2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbllblQty2.Location = New System.Drawing.Point(200, 48)
            Me.lbllblQty2.Name = "lbllblQty2"
            Me.lbllblQty2.Size = New System.Drawing.Size(112, 24)
            Me.lbllblQty2.TabIndex = 108
            Me.lbllblQty2.Text = "Scan Qty:"
            Me.lbllblQty2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblQty2
            '
            Me.lblQty2.BackColor = System.Drawing.Color.Black
            Me.lblQty2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblQty2.ForeColor = System.Drawing.Color.Lime
            Me.lblQty2.Location = New System.Drawing.Point(312, 48)
            Me.lblQty2.Name = "lblQty2"
            Me.lblQty2.Size = New System.Drawing.Size(72, 24)
            Me.lblQty2.TabIndex = 109
            Me.lblQty2.Text = "0"
            Me.lblQty2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lbllblQty1
            '
            Me.lbllblQty1.BackColor = System.Drawing.Color.Lavender
            Me.lbllblQty1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbllblQty1.Location = New System.Drawing.Point(16, 48)
            Me.lbllblQty1.Name = "lbllblQty1"
            Me.lbllblQty1.Size = New System.Drawing.Size(112, 24)
            Me.lbllblQty1.TabIndex = 106
            Me.lbllblQty1.Text = "Scan Qty:"
            Me.lbllblQty1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblQty1
            '
            Me.lblQty1.BackColor = System.Drawing.Color.Black
            Me.lblQty1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblQty1.ForeColor = System.Drawing.Color.Lime
            Me.lblQty1.Location = New System.Drawing.Point(128, 48)
            Me.lblQty1.Name = "lblQty1"
            Me.lblQty1.Size = New System.Drawing.Size(72, 24)
            Me.lblQty1.TabIndex = 107
            Me.lblQty1.Text = "0"
            Me.lblQty1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lstPartialBox2
            '
            Me.lstPartialBox2.Location = New System.Drawing.Point(208, 72)
            Me.lstPartialBox2.Name = "lstPartialBox2"
            Me.lstPartialBox2.Size = New System.Drawing.Size(176, 355)
            Me.lstPartialBox2.TabIndex = 105
            '
            'lstPartialBox1
            '
            Me.lstPartialBox1.Location = New System.Drawing.Point(16, 72)
            Me.lstPartialBox1.Name = "lstPartialBox1"
            Me.lstPartialBox1.Size = New System.Drawing.Size(184, 355)
            Me.lstPartialBox1.TabIndex = 104
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Lavender
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.Location = New System.Drawing.Point(16, 16)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(24, 24)
            Me.Label3.TabIndex = 102
            Me.Label3.Text = "SN:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtSN
            '
            Me.txtSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtSN.Location = New System.Drawing.Point(48, 16)
            Me.txtSN.Name = "txtSN"
            Me.txtSN.Size = New System.Drawing.Size(232, 21)
            Me.txtSN.TabIndex = 3
            Me.txtSN.Text = ""
            '
            'pnlSN
            '
            Me.pnlSN.BackColor = System.Drawing.Color.Lavender
            Me.pnlSN.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblProcessType, Me.btnDelete, Me.lbllblQty2, Me.lblQty2, Me.lbllblQty1, Me.lblQty1, Me.lstPartialBox2, Me.lstPartialBox1, Me.Label3, Me.txtSN})
            Me.pnlSN.Location = New System.Drawing.Point(376, 16)
            Me.pnlSN.Name = "pnlSN"
            Me.pnlSN.Size = New System.Drawing.Size(440, 440)
            Me.pnlSN.TabIndex = 110
            '
            'lblProcessType
            '
            Me.lblProcessType.BackColor = System.Drawing.Color.Transparent
            Me.lblProcessType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblProcessType.ForeColor = System.Drawing.Color.Blue
            Me.lblProcessType.Location = New System.Drawing.Point(296, 8)
            Me.lblProcessType.Name = "lblProcessType"
            Me.lblProcessType.Size = New System.Drawing.Size(136, 32)
            Me.lblProcessType.TabIndex = 111
            Me.lblProcessType.Text = "0"
            Me.lblProcessType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnDelete
            '
            Me.btnDelete.ForeColor = System.Drawing.Color.Firebrick
            Me.btnDelete.Location = New System.Drawing.Point(392, 152)
            Me.btnDelete.Name = "btnDelete"
            Me.btnDelete.Size = New System.Drawing.Size(40, 40)
            Me.btnDelete.TabIndex = 110
            Me.btnDelete.Text = "Del"
            '
            'TabControl1
            '
            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabPage1, Me.TabPage2})
            Me.TabControl1.Location = New System.Drawing.Point(8, 32)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(832, 488)
            Me.TabControl1.TabIndex = 111
            '
            'TabPage1
            '
            Me.TabPage1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnApproval, Me.btnReceive, Me.pnlBox, Me.pnlSN})
            Me.TabPage1.Location = New System.Drawing.Point(4, 22)
            Me.TabPage1.Name = "TabPage1"
            Me.TabPage1.Size = New System.Drawing.Size(824, 462)
            Me.TabPage1.TabIndex = 0
            Me.TabPage1.Text = "Receiving"
            '
            'btnApproval
            '
            Me.btnApproval.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnApproval.ForeColor = System.Drawing.Color.Red
            Me.btnApproval.Location = New System.Drawing.Point(88, 272)
            Me.btnApproval.Name = "btnApproval"
            Me.btnApproval.Size = New System.Drawing.Size(280, 48)
            Me.btnApproval.TabIndex = 112
            Me.btnApproval.Text = "Close Discrepency Box"
            '
            'btnReceive
            '
            Me.btnReceive.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReceive.ForeColor = System.Drawing.Color.MediumBlue
            Me.btnReceive.Location = New System.Drawing.Point(200, 200)
            Me.btnReceive.Name = "btnReceive"
            Me.btnReceive.Size = New System.Drawing.Size(168, 48)
            Me.btnReceive.TabIndex = 111
            Me.btnReceive.Text = "Close Box"
            '
            'TabPage2
            '
            Me.TabPage2.BackColor = System.Drawing.Color.Honeydew
            Me.TabPage2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblRecNum, Me.tdgData1, Me.btnGetReceivedData, Me.dtpEndDate, Me.dtpStartDate, Me.Label5, Me.Label9})
            Me.TabPage2.Location = New System.Drawing.Point(4, 22)
            Me.TabPage2.Name = "TabPage2"
            Me.TabPage2.Size = New System.Drawing.Size(824, 462)
            Me.TabPage2.TabIndex = 1
            Me.TabPage2.Text = "Received Data"
            '
            'lblRecNum
            '
            Me.lblRecNum.ForeColor = System.Drawing.Color.RoyalBlue
            Me.lblRecNum.Location = New System.Drawing.Point(568, 32)
            Me.lblRecNum.Name = "lblRecNum"
            Me.lblRecNum.Size = New System.Drawing.Size(248, 16)
            Me.lblRecNum.TabIndex = 109
            Me.lblRecNum.TextAlign = System.Drawing.ContentAlignment.BottomRight
            '
            'tdgData1
            '
            Me.tdgData1.AllowColMove = False
            Me.tdgData1.AllowColSelect = False
            Me.tdgData1.AllowUpdate = False
            Me.tdgData1.AlternatingRows = True
            Me.tdgData1.BackColor = System.Drawing.Color.White
            Me.tdgData1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdgData1.Caption = "List of Received Units"
            Me.tdgData1.CaptionHeight = 15
            Me.tdgData1.FetchRowStyles = True
            Me.tdgData1.FilterBar = True
            Me.tdgData1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgData1.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgData1.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.tdgData1.Location = New System.Drawing.Point(8, 48)
            Me.tdgData1.Name = "tdgData1"
            Me.tdgData1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgData1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgData1.PreviewInfo.ZoomFactor = 75
            Me.tdgData1.RowHeight = 15
            Me.tdgData1.Size = New System.Drawing.Size(808, 392)
            Me.tdgData1.TabIndex = 108
            Me.tdgData1.Text = "C1TrueDBGrid1"
            Me.tdgData1.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;ForeColor:OliveDrab;BackColor:Gainsboro;}Style1{}Normal{Fo" & _
            "nt:Microsoft Sans Serif, 9pt;}HighlightRow{ForeColor:HighlightText;BackColor:Hig" & _
            "hlight;}Style14{}OddRow{}RecordSelector{AlignImage:Center;}Style15{}Heading{Wrap" & _
            ":True;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVer" & _
            "t:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style9{}</D" & _
            "ata></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowCo" & _
            "lSelect=""False"" Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCapt" & _
            "ionHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""True"" FilterBar=""True"" Ma" & _
            "rqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Verti" & _
            "calScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>375</Height><CaptionStyle p" & _
            "arent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRo" & _
            "wStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Sty" & _
            "le13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me" & _
            "=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle par" & _
            "ent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" />" & _
            "<OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSe" & _
            "lector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style par" & _
            "ent=""Normal"" me=""Style1"" /><ClientRect>0, 15, 806, 375</ClientRect><BorderSide>0" & _
            "</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></" & _
            "Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""He" & _
            "ading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Capti" & _
            "on"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selecte" & _
            "d"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRo" & _
            "w"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" />" & _
            "<Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterB" & _
            "ar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSpli" & _
            "ts><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</Defaul" & _
            "tRecSelWidth><ClientArea>0, 0, 806, 390</ClientArea><PrintPageHeaderStyle parent" & _
            "="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'btnGetReceivedData
            '
            Me.btnGetReceivedData.BackColor = System.Drawing.Color.NavajoWhite
            Me.btnGetReceivedData.Location = New System.Drawing.Point(208, 22)
            Me.btnGetReceivedData.Name = "btnGetReceivedData"
            Me.btnGetReceivedData.Size = New System.Drawing.Size(120, 24)
            Me.btnGetReceivedData.TabIndex = 107
            Me.btnGetReceivedData.Text = "Retrieve Data"
            '
            'dtpEndDate
            '
            Me.dtpEndDate.CalendarFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpEndDate.CustomFormat = "yyyy-MM-dd"
            Me.dtpEndDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpEndDate.Location = New System.Drawing.Point(112, 24)
            Me.dtpEndDate.Name = "dtpEndDate"
            Me.dtpEndDate.Size = New System.Drawing.Size(96, 21)
            Me.dtpEndDate.TabIndex = 104
            Me.dtpEndDate.Value = New Date(2007, 3, 16, 0, 0, 0, 0)
            '
            'dtpStartDate
            '
            Me.dtpStartDate.CalendarFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpStartDate.CustomFormat = "yyyy-MM-dd"
            Me.dtpStartDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpStartDate.Location = New System.Drawing.Point(8, 24)
            Me.dtpStartDate.Name = "dtpStartDate"
            Me.dtpStartDate.Size = New System.Drawing.Size(96, 21)
            Me.dtpStartDate.TabIndex = 103
            Me.dtpStartDate.Value = New Date(2007, 3, 16, 0, 0, 0, 0)
            '
            'Label5
            '
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.MidnightBlue
            Me.Label5.Location = New System.Drawing.Point(8, 10)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(72, 16)
            Me.Label5.TabIndex = 105
            Me.Label5.Text = "Start"
            '
            'Label9
            '
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.MidnightBlue
            Me.Label9.Location = New System.Drawing.Point(112, 10)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(72, 16)
            Me.Label9.TabIndex = 106
            Me.Label9.Text = "End"
            '
            'frmAstroProductionReceiving
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(856, 534)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1, Me.cboCustomer, Me.lblTitle})
            Me.Name = "frmAstroProductionReceiving"
            Me.Text = "frmAstroProductionReceiving"
            CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlBoxData.ResumeLayout(False)
            Me.pnlBox.ResumeLayout(False)
            CType(Me.cboOpenBox, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlSN.ResumeLayout(False)
            Me.TabControl1.ResumeLayout(False)
            Me.TabPage1.ResumeLayout(False)
            Me.TabPage2.ResumeLayout(False)
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '***************************************************************************************
        Private Sub frmAstroProductionReceiving_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable

            Try
                PSS.Core.Highlight.SetHighLight(Me)

                Me.pnlBoxData.Visible = False : Me.pnlSN.Visible = False
                Me.lblModel.Visible = False : Me.lblModel.Visible = False
                Me.lblModelItemDesc.Visible = False : Me.lblRetailer.Visible = False
                Me.btnReceive.Visible = False : Me.btnApproval.Visible = False
                Me.btnDelete.Visible = False
                Me._toolTip1.ShowAlways = True

                dt = _objSkullcandy.GetCustomer(_iMenuCustID)
                If dt.Rows.Count > 0 Then
                    Misc.PopulateC1DropDownList(Me.cboCustomer, dt, "Cust_name1", "cust_ID")
                    Me.cboCustomer.SelectedValue = Me._iMenuCustID
                    Me.cboCustomer.Enabled = False
                    PopulateOpenBox()
                Else
                    Dim objCtrl As Control
                    For Each objCtrl In Me.Controls
                        objCtrl.Enabled = False
                    Next
                    MessageBox.Show("No customer!") : Exit Sub
                End If

                Me.dtpStartDate.Value = Format(DateAdd(DateInterval.Day, -_dtPeriod1, Now), "yyyy-MM-dd")
                Me.dtpEndDate.Value = Format(Now, "yyyy-MM-dd")

                If PSS.Core.ApplicationUser.GetPermission("Astro_Close_Rec_Disp_Box") > 0 Then
                    Me.btnApproval.Visible = True
                Else
                    Me.btnApproval.Visible = False
                End If

                ' Me.txtBoxWO.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub PopulateOpenBox()
            Dim dt As DataTable
            Dim row As DataRow
            Dim i As Integer

            Try
                Me.cboOpenBox.ClearItems()

                dt = Me._objSkullcandyRec.GetAstro_OpenPalletBox(Me._objSkullcandy.ASTRO_LOCID, True)

                Misc.PopulateC1DropDownList(Me.cboOpenBox, dt, "WorkOrder", "WOL_ID")
                Me.cboOpenBox.SelectedValue = 0

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "PopulateOpenBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                Me._FirstStart = False
            End Try

        End Sub

        '***************************************************************************************

        Private Sub cboOpenBox_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOpenBox.SelectedValueChanged
            Try

                If Me._FirstStart Then Exit Sub
                If Not Me.cboOpenBox.SelectedValue > 0 Then Exit Sub

                ClearControls()
                LoadPalletBoxData()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, " txtBoxWO_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub


        '***************************************************************************************
        Private Sub ClearControls()
            Try
                Me.lblBoxWO.Text = "" : Me.txtSN.Text = ""
                Me.lblModel.Text = "" : Me.lbllblModel.Text = ""
                Me.lblModelItemDesc.Text = "" : Me.lblRetailer.Text = "" : Me.lbllblRetailer.Text = ""
                Me.lblQty.Text = 0 : Me._iModelID = 0 : Me._iWOID = 0 : Me._iWOLID = 0
                Me._iModelID_2 = 0 : Me.lbllblQty1.Text = "Scan Qty:" : Me.lbllblQty2.Text = "Scan Qty:"
                Me.lblQty1.Text = 0 : Me.lblQty2.Text = 0
                Me.lstPartialBox1.DataSource = Nothing : Me.lstPartialBox2.DataSource = Nothing
                Me.lstPartialBox1.Items.Clear() : Me.lstPartialBox2.Items.Clear()
                Me.lstPartialBox1.Refresh() : Me.lstPartialBox2.Refresh()
                Me.btnApproval.Visible = False ' : Me._bApprovedToReceive = False
                Me.btnReceive.Visible = False
                Me.lblProcessType.Text = ""
                Me.lblProcessType.BackColor = Color.Transparent
                Me.lblProcessType.ForeColor = Color.Red
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ClearControls", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
        '***************************************************************************************
        Private Sub LoadPalletBoxData()
            Dim dt As DataTable
            Dim row As DataRow

            Try
                Me.pnlBoxData.Visible = False : Me.pnlSN.Visible = False
                Me.lblQty.Text = 0 : Me._iModelID = 0 : Me._iWOID = 0 : Me._iWOLID = 0
                Me.txtSN.Text = ""
                Me._iModelID_2 = 0 : Me.lbllblQty1.Text = "Scan Qty:" : Me.lbllblQty2.Text = "Scan Qty:"
                Me.lblQty1.Text = 0 : Me.lblQty2.Text = 0
                Me.lstPartialBox1.Items.Clear() : Me.lstPartialBox2.Items.Clear()
                Me.lstPartialBox1.DataSource = Nothing : Me.lstPartialBox2.DataSource = Nothing
                Me.btnReceive.Visible = False : Me.lblBoxWO.Visible = False

                If Not Me.cboOpenBox.SelectedValue > 0 Then Exit Sub

                'If Not txtBoxWO.Text.Trim.Length > 0 Then Exit Sub
                'dt = Me._objSkullcandyRec.GetPalletBoxWOProductionReceivingDetailData(Me._objSkullcandy.ASTRO_LOCID, txtBoxWO.Text.Trim)

                'If Not dt.Rows.Count > 0 Then
                '    MessageBox.Show("Can't find this box '" & txtBoxWO.Text.Trim & "'. The box may be closed.", " txtBoxWO_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                '    txtBoxWO.SelectAll() : txtBoxWO.Focus() : Exit Sub
                'ElseIf dt.Rows.Count > 1 Then
                '    MessageBox.Show("This box '" & txtBoxWO.Text.Trim & "' has more than 1 orders.", " txtBoxWO_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                '    txtBoxWO.SelectAll() : txtBoxWO.Focus() : Exit Sub
                'End If

                Me.lblBoxWO.Text = Me.cboOpenBox.DataSource.Table.select("WOL_ID = " & Me.cboOpenBox.SelectedValue)(0)("WorkOrder")
                Me.lblModel.Text = Me.cboOpenBox.DataSource.Table.select("WOL_ID = " & Me.cboOpenBox.SelectedValue)(0)("Model") ' dt.Rows(0).Item("Model") : 
                Me.lbllblModel.Text = "ItemDesc: " & Me.cboOpenBox.DataSource.Table.select("WOL_ID = " & Me.cboOpenBox.SelectedValue)(0)("ItemDesc")  '"ItemDesc: " & dt.Rows(0).Item("ItemDesc")
                Me.lblModelItemDesc.Text = Me.cboOpenBox.DataSource.Table.select("WOL_ID = " & Me.cboOpenBox.SelectedValue)(0)("ItemDesc") ' dt.Rows(0).Item("ItemDesc")
                Me.lblRetailer.Text = Me.cboOpenBox.DataSource.Table.select("WOL_ID = " & Me.cboOpenBox.SelectedValue)(0)("Retailer") 'dt.Rows(0).Item("Retailer")
                Me.lbllblRetailer.Text = "Retailer: " & Me.cboOpenBox.DataSource.Table.select("WOL_ID = " & Me.cboOpenBox.SelectedValue)(0)("Retailer") ' dt.Rows(0).Item("Retailer")
                Me.lblQty.Text = Me.cboOpenBox.DataSource.Table.select("WOL_ID = " & Me.cboOpenBox.SelectedValue)(0)("Qty") 'dt.Rows(0).Item("Qty")
                Me._iModelID = Me.cboOpenBox.DataSource.Table.select("WOL_ID = " & Me.cboOpenBox.SelectedValue)(0)("Model_ID") 'dt.Rows(0).Item("Model_ID")
                Me._iWOID = Me.cboOpenBox.DataSource.Table.select("WOL_ID = " & Me.cboOpenBox.SelectedValue)(0)("WO_ID") 'dt.Rows(0).Item("WO_ID")
                Me._iWOLID = Me.cboOpenBox.SelectedValue 'dt.Rows(0).Item("WOL_ID")

                If Me.lblModel.Text.Trim.ToUpper = Me._objSkullcandy.ModelPrefixString.A50.ToString.ToUpper Then
                    Me.lbllblQty1.Text = Me.lblModel.Text.Trim.ToUpper & " Scan Qty:"
                    Me.lbllblQty2.Text = Me._objSkullcandy.ModelPrefixString.TXD.ToString.ToUpper & " Scan Qty:"
                    Me._iModelID_2 = Me._objSkullcandy.Astro_GetAstro_BundleModelID2(Me._iMenuCustID, Me._objSkullcandy.ModelPrefixString.TXD.ToString)


                ElseIf Me.lblModel.Text.Trim.ToUpper = Me._objSkullcandy.ModelPrefixString.A42.ToString.ToUpper Then
                    Me.lbllblQty1.Text = Me.lblModel.Text.Trim.ToUpper & " Scan Qty:"
                    Me.lbllblQty2.Text = Me._objSkullcandy.ModelPrefixString.MA3.ToString.ToUpper & " Scan Qty:"
                    Me._iModelID_2 = Me._objSkullcandy.Astro_GetAstro_BundleModelID2(Me._iMenuCustID, Me._objSkullcandy.ModelPrefixString.MA3.ToString)

                Else
                    MessageBox.Show("This box '" & Me.cboOpenBox.DataSource.Table.select("WOL_ID = " & Me.cboOpenBox.SelectedValue)(0)("WorkOrder") & "' doesn't belong to " & _
                                     Me._objSkullcandy.ModelPrefixString.A50.ToString.ToUpper & _
                                     " or " & Me._objSkullcandy.ModelPrefixString.A42.ToString.ToUpper, " txtBoxWO_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                'Get received devices if any
                dt = Me._objSkullcandyRec.GetAstro_PalletBoxReceivedDevices(Me._objSkullcandy.ASTRO_LOCID, Me._iWOID, Me._iModelID)
                If dt.Rows.Count > 0 Then
                    For Each row In dt.Rows
                        AddSN2ListBox(row("Device_SN"), Me.lstPartialBox1)
                    Next
                End If
                dt = Me._objSkullcandyRec.GetAstro_PalletBoxReceivedDevices(Me._objSkullcandy.ASTRO_LOCID, Me._iWOID, Me._iModelID_2)
                If dt.Rows.Count > 0 Then
                    For Each row In dt.Rows
                        AddSN2ListBox(row("Device_SN"), Me.lstPartialBox2)
                    Next
                End If

                Me.pnlBoxData.Visible = True : Me.pnlSN.Visible = True : Me.btnReceive.Visible = True : Me.btnApproval.Visible = True
                Me.txtSN.Text = "" : Me.txtSN.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "LoadPalletBoxData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub txtSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp
            Try

                If e.KeyCode = Keys.Enter AndAlso txtSN.Text.Trim.Length > 0 Then
                    Me.ProcessSN()
                End If 'Key up and input length > 0
            Catch ex As Exception
                MessageBox.Show(ex.ToString, " txtSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Enabled = True : txtSN.SelectAll() : txtSN.Focus()
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '***************************************************************************************
        Private Sub ProcessSN()
            Dim dt As DataTable, tmpDT As DataTable
            Dim strSN As String = "", strArrLstSN As New ArrayList()
            Dim drNewRow, R1 As DataRow
            Dim i As Integer = 0, iPalletID As Integer = 0
            Dim iModelID As Integer = 0, iDeviceID As Integer = 0, ICCID As Integer = 0
            Dim strWorkStation As String
            Dim iUserID As Integer = 0, iShiftID As Integer = 0, strUserName As String = "", iTrayID As Integer = 0, iWipOwner As Integer = 0
            Dim objRec As New PSS.Data.Production.Receiving()
            Dim bScrap As Boolean = False

            Try
                Me.lblProcessType.BackColor = Color.Transparent : Me.lblProcessType.ForeColor = Color.Red
                Me.lblProcessType.Text = ""

                'Validate Box input
                If Not Me.lblModel.Text.Trim.Length > 0 Then
                    MessageBox.Show("No box! Enter a box name.", "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                ElseIf Not Me.lblQty.Text > 0 Then
                    MessageBox.Show("Box qty must be greater than 0.", "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                ElseIf Not (Me._iModelID > 0) Or Not (Me._iModelID_2 > 0) Then
                    MessageBox.Show("Invalid model_ID.", "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                ElseIf Not Me._iWOID > 0 Then
                    MessageBox.Show("Invalid  Workorder ID.", "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                ElseIf Not Me._iWOLID > 0 Then
                    MessageBox.Show("Invalid  WorkorderLine ID.", "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                'Validate SN
                strSN = Me.txtSN.Text.Trim.ToUpper
                If Not strSN.Length > 0 Then
                    MessageBox.Show("Please enter a SN.", "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtSN.Focus() : Exit Sub
                ElseIf Me._objSkullcandy.Astro_GetModelRepairType(strSN) = Me._objSkullcandy.ModelProcessType.NotDefined.ToString Then
                    MessageBox.Show("Not a valid SN.", "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub
                End If

                'Validate SN in WIP
                strArrLstSN.Add(strSN)
                dt = Me._objSkullcandyRec.GetDevicesInWIP(Me._objSkullcandy.ASTRO_LOCID, strArrLstSN)
                If dt.Rows.Count > 0 Then
                    MessageBox.Show("SN '" & strSN & "' is in WIP. Can't receive it.", "Receive", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                Select Case Me._objSkullcandy.Astro_GetModelName(strSN)
                    Case Me._objSkullcandy.ModelPrefixString.A50.ToString, Me._objSkullcandy.ModelPrefixString.A42.ToString
                        iModelID = Me._iModelID
                    Case Me._objSkullcandy.ModelPrefixString.TXD.ToString, Me._objSkullcandy.ModelPrefixString.MA3.ToString
                        iModelID = Me._iModelID_2
                    Case Else 'should never happen
                        MessageBox.Show("Can't determine the model for SN '" & strSN & "'", "Receive", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                End Select

                'Get Service 
                Dim dtReqServices As DataTable = Me._objSkullcandyRec.GetReqServiceBillcodes("ASTRO_REC_SERVICE_BILLCODES")

                'Check if model has sevice billcode map
                If dtReqServices.Rows.Count > 0 AndAlso Me.HasServiceBillcodeMap(iModelID, dtReqServices) = False Then Exit Sub

                Cursor.Current = Cursors.WaitCursor

                'Set up some initials
                iShiftID = PSS.Core.ApplicationUser.IDShift
                iUserID = PSS.Core.ApplicationUser.IDuser : strUserName = PSS.Core.ApplicationUser.User
                iTrayID = objRec.GetTrayID(Me._iWOID) 'TrayID was created when warehouse receiving
                If iTrayID = 0 Then iTrayID = objRec.InsertIntoTtray(iUserID, strUserName, Me._iWOID, ) 'if not, create it

                'Save device
                Dim strErrMsg As String = ""
                Select Case Me._objSkullcandy.Astro_GetModelRepairType(strSN)
                    Case Me._objSkullcandy.ModelProcessType.Scrap.ToString 'Scrap-------------------------------------------------------
                        strWorkStation = "Scrap" : iWipOwner = 1 : bScrap = True

                        'pallet for scrap
                        tmpDT = Me._objSkullcandyRec.GetOpenPalletName(Me._iMenuCustID, _objSkullcandy.ASTRO_LOCID)
                        If tmpDT.Rows.Count = 0 Then
                            MessageBox.Show("No pallet name found for the scrap.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub
                        ElseIf tmpDT.Rows.Count > 1 Then
                            MessageBox.Show("System only allow one open pallet. Please close all other pallets.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub
                        ElseIf tmpDT.Rows.Count = 1 Then
                            iPalletID = tmpDT.Rows(0).Item("Pallett_ID")
                        End If

                        iDeviceID = Me._objSkullcandyRec.ReceiveAstro_DeviceIntoWIP(Me._iWOID, iModelID, strSN, iShiftID, iUserID, strUserName, ICCID, _
                                                                                    Me._objSkullcandy.ASTRO_LOCID, iTrayID, iWipOwner, strWorkStation, strErrMsg, _
                                                                                    iPalletID)
                    Case Me._objSkullcandy.ModelProcessType.Repair.ToString 'Repair ----------------------------------------------------------
                        strWorkStation = "Waiting Repair" : iWipOwner = 1
                        iDeviceID = Me._objSkullcandyRec.ReceiveAstro_DeviceIntoWIP(Me._iWOID, iModelID, strSN, iShiftID, iUserID, strUserName, ICCID, _
                                                                                    Me._objSkullcandy.ASTRO_LOCID, iTrayID, iWipOwner, strWorkStation, strErrMsg, )
                    Case Me._objSkullcandy.ModelProcessType.TestOnly.ToString 'TestOnly ----------------------------------------------------------
                        strWorkStation = "Waiting Test" : iWipOwner = 1
                        iDeviceID = Me._objSkullcandyRec.ReceiveAstro_DeviceIntoWIP(Me._iWOID, iModelID, strSN, iShiftID, iUserID, strUserName, ICCID, _
                                                                                    Me._objSkullcandy.ASTRO_LOCID, iTrayID, iWipOwner, strWorkStation, strErrMsg, )
                    Case Else 'should never happen
                        MessageBox.Show("Can't determine a repair process type for SN '" & strSN & "'", "Receive", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                End Select
                If strErrMsg.Trim.Length > 0 Then
                    MessageBox.Show("SN: '" & strSN & "'" & Environment.NewLine & strErrMsg, "Receive", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                ElseIf iDeviceID > 0 AndAlso dtReqServices.Rows.Count > 0 Then
                    Me.BillServiceBillcode(iDeviceID, dtReqServices, bScrap)
                End If

                'Display Process Type desc
                Me._toolTip1.RemoveAll()
                Select Case Me._objSkullcandy.Astro_GetModelRepairType(strSN)
                    Case Me._objSkullcandy.ModelProcessType.Scrap.ToString
                        Me.lblProcessType.Text = Me._objSkullcandy.ModelProcessType.Scrap.ToString
                        Me.lblProcessType.BackColor = Color.Orchid 'light pink
                    Case Me._objSkullcandy.ModelProcessType.TestOnly.ToString
                        Me.lblProcessType.Text = Me._objSkullcandy.ModelProcessType.TestOnly.ToString
                        Me.lblProcessType.BackColor = Color.DarkSeaGreen 'light yellow
                    Case Me._objSkullcandy.ModelProcessType.Repair.ToString()
                        Me.lblProcessType.Text = Me._objSkullcandy.ModelProcessType.Repair.ToString()
                        Me.lblProcessType.BackColor = Color.Khaki
                    Case Else
                        Me.lblProcessType.Text = Me._objSkullcandy.ModelProcessType.NotDefined.ToString()
                        Me.lblProcessType.BackColor = Color.Transparent
                        Me.lblProcessType.ForeColor = Color.Red
                End Select
                Me._toolTip1.SetToolTip(Me.lblProcessType, strSN)

                'Add SN to listboxes after succefully saved
                If Me.lblModel.Text.Trim.ToUpper = Me._objSkullcandy.ModelPrefixString.A50.ToString Then 'A50
                    Select Case Me._objSkullcandy.Astro_GetModelName(strSN)
                        Case Me._objSkullcandy.ModelPrefixString.A50.ToString
                            AddSN2ListBox(strSN, Me.lstPartialBox1)
                        Case Me._objSkullcandy.ModelPrefixString.TXD.ToString
                            AddSN2ListBox(strSN, Me.lstPartialBox2)
                        Case Else
                            MessageBox.Show("This device doesn't belong to " & Me.lblModelItemDesc.Text, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtSN.SelectAll() : Me.txtSN.Focus()
                    End Select
                ElseIf Me.lblModel.Text.Trim.ToUpper = Me._objSkullcandy.ModelPrefixString.A42.ToString Then 'A40
                    Select Case Me._objSkullcandy.Astro_GetModelName(strSN)
                        Case Me._objSkullcandy.ModelPrefixString.A42.ToString
                            AddSN2ListBox(strSN, Me.lstPartialBox1)
                        Case Me._objSkullcandy.ModelPrefixString.MA3.ToString
                            AddSN2ListBox(strSN, Me.lstPartialBox2)
                        Case Else
                            MessageBox.Show("This device doesn't belong to " & Me.lblModelItemDesc.Text, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtSN.SelectAll() : Me.txtSN.Focus()
                    End Select
                Else
                    MessageBox.Show("This device doesn't belong to " & Me.lblModelItemDesc.Text, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtSN.SelectAll() : Me.txtSN.Focus()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        '***************************************************************************************
        Private Sub ComputeTotal()
            Try
                Me.lblQty1.Text = Me.lstPartialBox1.Items.Count
                Me.lblQty2.Text = Me.lstPartialBox2.Items.Count
            Catch ex As Exception
                MessageBox.Show(ex.ToString, " ComputeTotal(", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub AddSN2ListBox(ByVal strSN As String, ByVal lstBox As ListBox)
            'Dim bRes As Boolean = False
            Dim i As Integer = 0
            Dim strItem As String = ""
            Dim drNewRow As DataRow

            Try

                If IsNothing(lstBox.DataSource) Then
                    Dim dt As New DataTable()
                    dt = DeviceTable()
                    lstBox.DataSource = dt.DefaultView
                    lstBox.DisplayMember = "SN"
                    lstBox.ValueMember = "ID"
                    drNewRow = lstBox.DataSource.Table.NewRow
                    drNewRow("SN") = strSN : drNewRow("recvdFlag") = 0
                    lstBox.DataSource.Table.Rows.Add(drNewRow)
                    lstBox.Refresh() : ComputeTotal() : lstBox.ClearSelected()
                Else
                    If lstBox.DataSource.table.select("SN = '" & strSN & "'").length > 0 Then
                        MessageBox.Show("This device  '" & strSN & "' is already listed. Try another one.", "AddSN2ListBox", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        drNewRow = lstBox.DataSource.Table.NewRow
                        drNewRow("SN") = strSN : drNewRow("recvdFlag") = 0
                        lstBox.DataSource.Table.Rows.Add(drNewRow)
                        lstBox.Refresh() : ComputeTotal() : lstBox.ClearSelected()
                    End If
                End If


            Catch ex As Exception
                MessageBox.Show(ex.ToString, "AddSN2ListBox", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.txtSN.Text = "" : Me.txtSN.Focus()
            End Try
        End Sub


        '***************************************************************************************
        Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            'Give up this delete
            Exit Sub

            Dim i As Integer
            Dim dt As New DataTable()

            Try

                If MessageBox.Show("Do you want to delete the selected item(s)?", "Information", MessageBoxButtons.YesNo, _
                  MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.Yes Then Exit Sub

                If Me.lstPartialBox1.SelectedIndices.Count > 0 Then
                    Dim idx(Me.lstPartialBox1.SelectedIndices.Count - 1)
                    dt = Me.lstPartialBox1.DataSource.Table
                    For i = 0 To Me.lstPartialBox1.SelectedIndices.Count - 1
                        idx(i) = Me.lstPartialBox1.SelectedIndices.Item(i)
                    Next
                    For i = idx.Length - 1 To 0 Step -1
                        dt.Rows(idx(i)).Delete()
                    Next
                    Me.lstPartialBox1.Refresh() : ComputeTotal()
                    Me.lstPartialBox1.ClearSelected()
                End If
                If Me.lstPartialBox2.SelectedIndices.Count > 0 Then
                    Dim idx(Me.lstPartialBox2.SelectedIndices.Count - 1)
                    dt = Me.lstPartialBox2.DataSource.Table
                    For i = 0 To Me.lstPartialBox2.SelectedIndices.Count - 1
                        idx(i) = Me.lstPartialBox2.SelectedIndices.Item(i)
                    Next
                    For i = idx.Length - 1 To 0 Step -1
                        dt.Rows(idx(i)).Delete()
                    Next
                    Me.lstPartialBox2.Refresh() : ComputeTotal()
                    Me.lstPartialBox2.ClearSelected()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnDelete_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub btnReceive_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReceive.Click
            Dim Msg As String = "'Discrepancy of quantity." & Environment.NewLine & " Can't receive! Please see your supervisor."
            Try
                If Not CInt(Me.lblQty.Text) > 0 Then Exit Sub
                If Not CInt(Me.lblQty1.Text) > 0 AndAlso Not CInt(Me.lblQty2.Text) > 0 Then Exit Sub

                'Check qty
                If (CInt(Me.lblQty1.Text) <> CInt(Me.lblQty.Text) Or CInt(Me.lblQty2.Text) <> CInt(Me.lblQty.Text)) Then
                    MessageBox.Show(Msg, "Receive", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                Me.ClosePalletBox()

                'Receive items in the box and close the box

                'Dim Msg As String = "'Discrepancy of quantity." & Environment.NewLine & " Can't receive! Please see your supervisor."
                'Dim strSN As String = "", strSerialNumbers As String = "", strWorkStation As String = "", strArrLstSNs As New ArrayList()
                'Dim dt1 As DataTable, dt2 As DataTable, tmpDT As DataTable, ds As New DataSet()
                'Dim row As DataRow
                'Dim iPalletID As Integer = 0, iModelID As Integer = 0, iDeviceID As Integer = 0, ICCID As Integer = 0, i As Integer = 0
                'Dim iUserID As Integer = 0, iShiftID As Integer = 0, strUserName As String = "", iTrayID As Integer = 0, iWipOwner As Integer = 0
                'Dim bHasScrapInBox As Boolean = False
                'Dim objRec As New PSS.Data.Production.Receiving()
                'Dim bScrap As Boolean = False

                'Try
                '    If Not CInt(Me.lblQty.Text) > 0 Then Exit Sub
                '    If Not CInt(Me.lblQty1.Text) > 0 AndAlso Not CInt(Me.lblQty2.Text) > 0 Then Exit Sub

                '    'Check qty
                '    If Me._bApprovedToReceive = False AndAlso (CInt(Me.lblQty1.Text) <> CInt(Me.lblQty.Text) Or CInt(Me.lblQty2.Text) <> CInt(Me.lblQty.Text)) Then
                '        MessageBox.Show(Msg, "Receive", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                '        Me.btnApproval.Visible = True : Me.btnApproval.Focus() : Exit Sub
                '    End If

                '    'Get SN datatables, set ds
                '    dt1 = Me.lstPartialBox1.DataSource.Table : dt2 = Me.lstPartialBox2.DataSource.Table
                '    dt1.TableName = "Table1" : dt2.TableName = "Table2"
                '    ds.Tables.Add(dt1.Copy) : ds.Tables.Add(dt2.Copy)
                '    strArrLstSNs.Clear()

                '    'Validae repair process type again. and check if having scrap
                '    For Each tmpDT In ds.Tables 'Each table
                '        For Each row In tmpDT.Rows 'each row
                '            If Me._objSkullcandy.GetASTRO_ModelRepairType(row("SN")) = Me._objSkullcandy.ModelProcessType.NotDefined.ToString Then
                '                If strSerialNumbers.Trim.Length = 0 Then
                '                    strSerialNumbers &= row("SN")
                '                Else
                '                    strSerialNumbers &= "," & row("SN")
                '                End If
                '            ElseIf bHasScrapInBox = False AndAlso Me._objSkullcandy.GetASTRO_ModelRepairType(row("SN")) = Me._objSkullcandy.ModelProcessType.Scrap.ToString Then
                '                bHasScrapInBox = True
                '            End If
                '            strArrLstSNs.Add(row("SN")) 'Get all SNs
                '        Next
                '    Next

                '    If strSerialNumbers.Trim.Length > 0 Then
                '        MessageBox.Show("Can't determine a repair process type for SN(s) '" & strSerialNumbers & "'", "Receive", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                '        Exit Sub
                '    End If

                '    'Validate items in WIP
                '    If strArrLstSNs.Count > 0 Then
                '        Dim strMyTempSNs As String = ""
                '        tmpDT = Me._objSkullcandyRec.GetDevicesInWIP(Me._objSkullcandy.ASTRO_LOCID, strArrLstSNs)
                '        If tmpDT.Rows.Count > 0 Then
                '            For Each row In tmpDT.Rows
                '                strMyTempSNs &= row("Device_SN") & Environment.NewLine
                '            Next
                '            MessageBox.Show("Can't receive. Follwing SNs are in WIP: " & Environment.NewLine & strMyTempSNs, "Receive", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                '            Exit Sub
                '        End If
                '    End If

                '    'Get Pallet ID when box has scrap unit(s)
                '    If bHasScrapInBox Then
                '        tmpDT = Me._objSkullcandyRec.GetOpenPalletName(Me._iMenuCustID, _objSkullcandy.ASTRO_LOCID)
                '        If tmpDT.Rows.Count = 0 Then
                '            MessageBox.Show("No pallet name found for the scrap.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                '            Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub
                '        ElseIf tmpDT.Rows.Count > 1 Then
                '            MessageBox.Show("System only allow one open pallet. Please close all other pallets.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                '            Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub
                '        ElseIf tmpDT.Rows.Count = 1 Then
                '            iPalletID = tmpDT.Rows(0).Item("Pallett_ID")
                '        End If
                '    End If

                '    Me.Enabled = True : Cursor.Current = Cursors.WaitCursor

                '    iShiftID = PSS.Core.ApplicationUser.IDShift
                '    iUserID = PSS.Core.ApplicationUser.IDuser : strUserName = PSS.Core.ApplicationUser.User
                '    iTrayID = objRec.GetTrayID(Me._iWOID)
                '    If iTrayID = 0 Then iTrayID = objRec.InsertIntoTtray(iUserID, strUserName, , )

                '    ''Get Service 
                '    'Dim dtReqServices As DataTable = Me._objSkullcandyRec.GetReqServiceBillcodes("ASTRO_REC_SERVICE_BILLCODES")
                '    ''Check if model has sevice billcode map
                '    'If dtReqServices.Rows.Count > 0 AndAlso Me.HasServiceBillcodeMap(iModelID, dtReqServices) = False Then Exit Sub

                '    'Ready to receive and close----------------------------------------------------------------------------------------------
                '    For Each tmpDT In ds.Tables 'Each table
                '        For Each row In tmpDT.Rows 'each row
                '            strSN = row("SN")
                '            Select Case Me._objSkullcandy.GetASTRO_ModelName(strSN)
                '                Case Me._objSkullcandy.ModelPrefixString.A50.ToString, Me._objSkullcandy.ModelPrefixString.A42.ToString
                '                    iModelID = Me._iModelID
                '                Case Me._objSkullcandy.ModelPrefixString.TXD.ToString, Me._objSkullcandy.ModelPrefixString.MA3.ToString
                '                    iModelID = Me._iModelID_2
                '                Case Else 'should never happen
                '                    MessageBox.Show("Can't determine the model for SN '" & strSN & "'", "Receive", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                '                    Exit Sub
                '            End Select

                '            Dim strErrMsg As String = ""
                '            Select Case Me._objSkullcandy.GetASTRO_ModelRepairType(strSN)
                '                Case Me._objSkullcandy.ModelProcessType.Scrap.ToString
                '                    strWorkStation = "Scrap" : iWipOwner = 1 : bScrap = True
                '                    iDeviceID = Me._objSkullcandyRec.ReceiveAstro_DeviceIntoWIP(Me._iWOID, iModelID, strSN, iShiftID, iUserID, strUserName, ICCID, _
                '                                                                                Me._objSkullcandy.ASTRO_LOCID, iTrayID, iWipOwner, strWorkStation, strErrMsg, iPalletID)
                '                Case Me._objSkullcandy.ModelProcessType.Repair.ToString
                '                    strWorkStation = "Waiting Repair" : iWipOwner = 1
                '                    iDeviceID = Me._objSkullcandyRec.ReceiveAstro_DeviceIntoWIP(Me._iWOID, iModelID, strSN, iShiftID, iUserID, strUserName, ICCID, _
                '                                                                                Me._objSkullcandy.ASTRO_LOCID, iTrayID, iWipOwner, strWorkStation, strErrMsg, )
                '                Case Me._objSkullcandy.ModelProcessType.TestOnly.ToString
                '                    strWorkStation = "Waiting Test" : iWipOwner = 1
                '                    iDeviceID = Me._objSkullcandyRec.ReceiveAstro_DeviceIntoWIP(Me._iWOID, iModelID, strSN, iShiftID, iUserID, strUserName, ICCID, _
                '                                                                                Me._objSkullcandy.ASTRO_LOCID, iTrayID, iWipOwner, strWorkStation, strErrMsg, )
                '                Case Else 'should never happen
                '                    MessageBox.Show("Can't determine a repair process type for SN '" & strSN & "'", "Receive", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                '                    Exit Sub
                '            End Select
                '            If strErrMsg.Trim.Length > 0 Then
                '            MessageBox.Show("SN: '" & strSN & "'" & Environment.NewLine & strErrMsg, "Receive", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                '            Exit Sub
                '        End If

                '        'If iDeviceID > 0 AndAlso dtReqServices.Rows.Count > 0 Then
                '        '    Me.BillServiceBillcode(iDeviceID, dtReqServices, bScrap)
                '        'End If
                '    Next
                'Next

                ''Close the box
                'i = Me._objSkullcandyRec.ReceiveAstro_CloseBoxReceiving(Me._iWOLID)
                'If Not i > 0 Then
                '    MessageBox.Show("Saved data, but failed to close the box. See IT.", "Receive", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                'End If

                'MessageBox.Show("OK")

                'ClearControls()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnReceive_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Finally
                'Me.Enabled = True : Cursor.Current = Cursors.Default
                'Data.Buisness.Generic.DisposeDT(dt1) : Data.Buisness.Generic.DisposeDT(dt2)
                'Data.Buisness.Generic.DisposeDS(ds)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub ClosePalletBox()
            Dim i As Integer = 0

            Try
                i = Me._objSkullcandyRec.ReceiveAstro_CloseBoxReceiving(Me._iWOLID)
                If Not i > 0 Then
                    MessageBox.Show("Saved data, but failed to close the box. See IT.", "Receive", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
                ClearControls()
                Me._FirstStart = True : PopulateOpenBox()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnReceive_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
        '***************************************************************************************
        Private Function HasServiceBillcodeMap(ByVal iModelID As Integer, ByVal dtReqServices As DataTable) As Boolean
            Dim booReturnVal As Boolean = True
            Dim R1 As DataRow

            Try
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
        Private Function BillServiceBillcode(ByVal iDeviceID As Integer, ByVal dtReqServices As DataTable, ByVal bScrap As Boolean) As Integer
            Dim objDevice As Rules.Device
            Dim R1 As DataRow

            Try
                objDevice = New Rules.Device(iDeviceID)

                For Each R1 In dtReqServices.Rows
                    objDevice.AddPart(CInt(R1("Billcode_ID")))
                Next R1

                If bScrap > 0 Then objDevice.AddPart(Data.Buisness.Skullcandy.AstroServiceBillcode.Scrap)

                objDevice.Update()
            Catch ex As Exception
                Throw ex
            Finally
                objDevice.Dispose() : objDevice = Nothing : Data.Buisness.Generic.DisposeDT(dtReqServices)
            End Try
        End Function

        '***************************************************************************************
        Private Sub btnApproval_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApproval.Click
            'need security here
            'Me._bApprovedToReceive = True
            Me.ClosePalletBox()

        End Sub

        '******************************************************************
        Private Function CreatePalletName() As String
            Dim strDateTime As String
            Dim DTime As Date
            Dim strPalletWOName As String
            Dim iWO_ID As Integer = 0
            Dim dt As DataTable

            'Try
            '    If IsDate(Generic.MySQLServerDateTime) Then
            '        DTime = Generic.MySQLServerDateTime
            '        strDateTime = Format(DTime, "yyyy-MM-dd HH:mm:ss")
            '        strPalletWOName = Me._objSkullcandy.PalletWO_Prefix & Format(DTime, "yyMMdd") & "N" & Format(DTime, "HHmmss")
            '    Else
            '        strPalletWOName = Me._objSkullcandy.PalletWO_Prefix & Format(Now, "yyMMdd") & "N" & Format(Now, "HHmmss")
            '    End If

            '    dt = Me._objSkullcandyRec.GetPalletWorkOrderData(Me._objSkullcandy.LOCID, strPalletWOName)

            '    If dt.Rows.Count > 0 Then
            '        MessageBox.Show("Pallet '" & strPalletWOName & " already exists. Can not create it.", "btnCreatePallet_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '        Exit Sub
            '    End If

            '    btnCreatePallet.Enabled = False
            '    iWO_ID = Me._objSkullcandyRec.CreatePalletWO(Me._objSkullcandy.LOCID, Me._objSkullcandy.PRODID, Me._objSkullcandy.GROUPID, strDateTime, strPalletWOName)
            '    If Not iWO_ID > 0 Then
            '        MessageBox.Show("Failed to create.", "btnCreatePallet_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '    Else
            '        PopulateOpenPalletNameWO(iWO_ID)
            '    End If

            'Catch ex As Exception
            '    MessageBox.Show(ex.ToString, " btnCreatePallet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Finally
            '    btnCreatePallet.Enabled = True
            'End Try
        End Function



        '***************************************************************************************
        Private Function DeviceTable() As DataTable
            Dim dt As New DataTable()
            dt.Columns.Add("ID", GetType(Integer)) 'seq no
            dt.Columns.Add("SN", GetType(String)) 'Serial No
            dt.Columns.Add("recvdFlag", GetType(Integer)) 'Received Flag 0=new, 1= received
            dt.Columns.Add("Col4", GetType(String))
            dt.Columns("ID").AutoIncrement = True
            dt.Columns("ID").AutoIncrementSeed = 1
            dt.Columns("ID").AutoIncrementStep = 1

            Return dt
        End Function

        '***************************************************************************************
#Region "Received Data"

        '***************************************************************************************
        Private Sub btnGetReceivedData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGetReceivedData.Click
            Dim strDateEnd As String = "", strDateStart As String = ""
            Dim dt As DataTable

            Try

                If Me.dtpStartDate.Value > Me.dtpEndDate.Value Then
                    strDateEnd = Me.dtpStartDate.Value.ToString("yyyy-MM-dd") & " 23:59:59"
                    strDateStart = Me.dtpEndDate.Value.ToString("yyyy-MM-dd") & " 00:00:00"
                Else
                    strDateStart = Me.dtpStartDate.Value.ToString("yyyy-MM-dd") & " 00:00:00"
                    strDateEnd = Me.dtpEndDate.Value.ToString("yyyy-MM-dd") & " 23:59:59"
                End If

                dt = Me._objSkullcandyRec.ReceiveAstro_GetReceivedData(Me._objSkullcandy.ASTRO_LOCID, strDateStart, strDateEnd)

                If dt.Rows.Count > 0 Then
                    Me.tdgData1.DataSource = dt : Me.lblRecNum.Text = "Rec Number: " & dt.Rows.Count
                    Me.tdgData1.Splits(0).DisplayColumns("BoxWO").Width = 180
                    Me.tdgData1.Splits(0).DisplayColumns("SN").Width = 80
                    Me.tdgData1.Splits(0).DisplayColumns("ItemDesc").Width = 60
                    Me.tdgData1.Splits(0).DisplayColumns("ModelDesc").Width = 60
                    Me.tdgData1.Splits(0).DisplayColumns("ShortName").Width = 40
                    Me.tdgData1.Splits(0).DisplayColumns("Retailer").Width = 30
                    Me.tdgData1.Splits(0).DisplayColumns("WorkStation").Width = 80
                Else
                    Me.tdgData1.DataSource = Nothing : Me.lblRecNum.Text = "Rec Number: " & 0
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnGetReceivedData_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub tdgData1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdgData1.MouseDown
            Try
                Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = DirectCast(sender, C1.Win.C1TrueDBGrid.C1TrueDBGrid)

                If dbg.RowCount = 0 Then Return

                'Event handle
                If e.Button = MouseButtons.Right Then
                    Dim ctmCopyData As New ContextMenu()
                    Dim objCopyAll As New MenuItem()
                    Dim objCopySelected As New MenuItem()
                    Dim objPrintAll As New MenuItem()
                    Dim objPrintSelected As New MenuItem()


                    objCopyAll.Text = "Copy all"
                    objCopySelected.Text = "Copy selected rows"

                    ctmCopyData.MenuItems.Add(objCopyAll)
                    ctmCopyData.MenuItems.Add(objCopySelected)


                    RemoveHandler objCopyAll.Click, AddressOf CMenuCopyAllData
                    AddHandler objCopyAll.Click, AddressOf CMenuCopyAllData
                    RemoveHandler objCopySelected.Click, AddressOf CMenuCopySelectedData
                    AddHandler objCopySelected.Click, AddressOf CMenuCopySelectedData

                    dbg.ContextMenu = ctmCopyData
                    dbg.ContextMenu.Show(dbg, New Point(e.X, e.Y))
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, " tdgData1_MouseDown", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '*******************************************************************
        Private Sub CMenuCopyAllData(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                Misc.CopyAllData(Me.tdgData1)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CMenuCopyData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '*******************************************************************
        Private Sub CMenuCopySelectedData(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                Misc.CopySelectedRowsData(Me.tdgData1)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CMenuCopySelectedData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '***************************************************************************************

#End Region

        '***************************************************************************************
    End Class
End Namespace
