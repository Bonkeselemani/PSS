Option Explicit On 

Imports PSS.Data.Buisness

Public Class frmTransferDevices
    Inherits System.Windows.Forms.Form

    Private _objTransferDev As TransferDevices
    Private _iWipowner_ID As Integer = 0
    Private _strWipownerDesc As String = ""

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal iWipownerID As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _objTransferDev = New TransferDevices()
        _iWipowner_ID = iWipownerID
        _strWipownerDesc = Generic.GetWipOwnerDesc(_iWipowner_ID)
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If

            _objTransferDev = Nothing
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents btnTransfer As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dbgWIP2Devices As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents txtScanItem As System.Windows.Forms.TextBox
    Friend WithEvents radTray_ID As System.Windows.Forms.RadioButton
    Friend WithEvents radSN As System.Windows.Forms.RadioButton
    Friend WithEvents cboCustomers As C1.Win.C1List.C1Combo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboProduct As C1.Win.C1List.C1Combo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboLoc As C1.Win.C1List.C1Combo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTransferDevices))
        Me.txtScanItem = New System.Windows.Forms.TextBox()
        Me.btnTransfer = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dbgWIP2Devices = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.radTray_ID = New System.Windows.Forms.RadioButton()
        Me.radSN = New System.Windows.Forms.RadioButton()
        Me.cboCustomers = New C1.Win.C1List.C1Combo()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboProduct = New C1.Win.C1List.C1Combo()
        Me.cboLoc = New C1.Win.C1List.C1Combo()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.dbgWIP2Devices, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboLoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtScanItem
        '
        Me.txtScanItem.Location = New System.Drawing.Point(16, 200)
        Me.txtScanItem.Name = "txtScanItem"
        Me.txtScanItem.Size = New System.Drawing.Size(216, 20)
        Me.txtScanItem.TabIndex = 6
        Me.txtScanItem.Text = ""
        '
        'btnTransfer
        '
        Me.btnTransfer.BackColor = System.Drawing.Color.Green
        Me.btnTransfer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTransfer.Location = New System.Drawing.Point(16, 248)
        Me.btnTransfer.Name = "btnTransfer"
        Me.btnTransfer.Size = New System.Drawing.Size(128, 48)
        Me.btnTransfer.TabIndex = 6
        Me.btnTransfer.Text = "Transfer"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(16, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 16)
        Me.Label5.TabIndex = 101
        Me.Label5.Text = "Product :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dbgWIP2Devices
        '
        Me.dbgWIP2Devices.AllowUpdate = False
        Me.dbgWIP2Devices.AllowUpdateOnBlur = False
        Me.dbgWIP2Devices.CaptionHeight = 17
        Me.dbgWIP2Devices.FilterBar = True
        Me.dbgWIP2Devices.GroupByCaption = "Drag a column header here to group by that column"
        Me.dbgWIP2Devices.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.dbgWIP2Devices.Location = New System.Drawing.Point(392, 8)
        Me.dbgWIP2Devices.Name = "dbgWIP2Devices"
        Me.dbgWIP2Devices.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgWIP2Devices.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgWIP2Devices.PreviewInfo.ZoomFactor = 75
        Me.dbgWIP2Devices.Size = New System.Drawing.Size(320, 384)
        Me.dbgWIP2Devices.TabIndex = 7
        Me.dbgWIP2Devices.Text = "C1TrueDBGrid1"
        Me.dbgWIP2Devices.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
        "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{ForeColor:Lime;BackColo" & _
        "r:Black;}Caption{Font:Microsoft Sans Serif, 12pt, style=Bold;AlignHorz:Center;Fo" & _
        "reColor:Yellow;BackColor:SteelBlue;}Style9{}Normal{}HighlightRow{ForeColor:Highl" & _
        "ightText;BackColor:Highlight;}Style14{}OddRow{}RecordSelector{AlignImage:Center;" & _
        "}Style15{}Heading{Wrap:True;Font:Microsoft Sans Serif, 9.75pt, style=Bold;AlignV" & _
        "ert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:White;BackColor:SteelBlue;}Style8" & _
        "{}Style10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style1{}</Data></Styles><Sp" & _
        "lits><C1.Win.C1TrueDBGrid.MergeView Name="""" CaptionHeight=""17"" ColumnCaptionHeig" & _
        "ht=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder""" & _
        " RecordSelectorWidth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" Horizontal" & _
        "ScrollGroup=""1""><Height>380</Height><CaptionStyle parent=""Style2"" me=""Style10"" /" & _
        "><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""S" & _
        "tyle8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""" & _
        "Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle pa" & _
        "rent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7" & _
        """ /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" " & _
        "me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><Selec" & _
        "tedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><C" & _
        "lientRect>0, 0, 316, 380</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunk" & _
        "en</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style par" & _
        "ent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Headin" & _
        "g"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" " & _
        "me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me" & _
        "=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me" & _
        "=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""Re" & _
        "cordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" " & _
        "me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><" & _
        "Layout>None</Layout><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0," & _
        " 316, 380</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageF" & _
        "ooterStyle parent="""" me=""Style15"" /></Blob>"
        '
        'radTray_ID
        '
        Me.radTray_ID.Checked = True
        Me.radTray_ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radTray_ID.Location = New System.Drawing.Point(16, 152)
        Me.radTray_ID.Name = "radTray_ID"
        Me.radTray_ID.Size = New System.Drawing.Size(64, 16)
        Me.radTray_ID.TabIndex = 4
        Me.radTray_ID.TabStop = True
        Me.radTray_ID.Text = "Tray ID"
        '
        'radSN
        '
        Me.radSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radSN.Location = New System.Drawing.Point(16, 176)
        Me.radSN.Name = "radSN"
        Me.radSN.Size = New System.Drawing.Size(64, 16)
        Me.radSN.TabIndex = 5
        Me.radSN.Text = "SN"
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
        Me.cboCustomers.Location = New System.Drawing.Point(16, 25)
        Me.cboCustomers.MatchEntryTimeout = CType(2000, Long)
        Me.cboCustomers.MaxDropDownItems = CType(5, Short)
        Me.cboCustomers.MaxLength = 32767
        Me.cboCustomers.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboCustomers.Name = "cboCustomers"
        Me.cboCustomers.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboCustomers.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboCustomers.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboCustomers.Size = New System.Drawing.Size(288, 21)
        Me.cboCustomers.TabIndex = 1
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
        "ts>1</horzSplits><Layout>Modified</Layout><DefaultRecSelWidth>16</DefaultRecSelW" & _
        "idth></Blob>"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(16, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 16)
        Me.Label7.TabIndex = 127
        Me.Label7.Text = "Customer:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.cboProduct.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
        Me.cboProduct.ItemHeight = 15
        Me.cboProduct.Location = New System.Drawing.Point(16, 120)
        Me.cboProduct.MatchEntryTimeout = CType(2000, Long)
        Me.cboProduct.MaxDropDownItems = CType(5, Short)
        Me.cboProduct.MaxLength = 32767
        Me.cboProduct.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboProduct.Name = "cboProduct"
        Me.cboProduct.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboProduct.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboProduct.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboProduct.Size = New System.Drawing.Size(216, 21)
        Me.cboProduct.TabIndex = 3
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
        "ts>1</horzSplits><Layout>Modified</Layout><DefaultRecSelWidth>16</DefaultRecSelW" & _
        "idth></Blob>"
        '
        'cboLoc
        '
        Me.cboLoc.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboLoc.Caption = ""
        Me.cboLoc.CaptionHeight = 17
        Me.cboLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboLoc.ColumnCaptionHeight = 17
        Me.cboLoc.ColumnFooterHeight = 17
        Me.cboLoc.ContentHeight = 15
        Me.cboLoc.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboLoc.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboLoc.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLoc.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboLoc.EditorHeight = 15
        Me.cboLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLoc.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
        Me.cboLoc.ItemHeight = 15
        Me.cboLoc.Location = New System.Drawing.Point(16, 72)
        Me.cboLoc.MatchEntryTimeout = CType(2000, Long)
        Me.cboLoc.MaxDropDownItems = CType(5, Short)
        Me.cboLoc.MaxLength = 32767
        Me.cboLoc.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboLoc.Name = "cboLoc"
        Me.cboLoc.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboLoc.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboLoc.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboLoc.Size = New System.Drawing.Size(216, 21)
        Me.cboLoc.TabIndex = 2
        Me.cboLoc.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
        "ts>1</horzSplits><Layout>Modified</Layout><DefaultRecSelWidth>16</DefaultRecSelW" & _
        "idth></Blob>"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(16, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 16)
        Me.Label1.TabIndex = 129
        Me.Label1.Text = "Location:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmTransferDevices
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(720, 454)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboLoc, Me.Label1, Me.cboProduct, Me.cboCustomers, Me.Label7, Me.radSN, Me.radTray_ID, Me.dbgWIP2Devices, Me.Label5, Me.btnTransfer, Me.txtScanItem})
        Me.ForeColor = System.Drawing.Color.White
        Me.Name = "frmTransferDevices"
        Me.Text = "Transfer Devices"
        CType(Me.dbgWIP2Devices, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboLoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmTransferDevices_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim iCustID As Integer = 0
        Dim dt As DataTable

        Try
            iCustID = Generic.GetCustIDByMachine()
            Me.cboCustomers.DataSource = Nothing
            dt = Generic.GetCustomers(True, Me.cboProduct.SelectedValue)
            Misc.PopulateC1DropDownList(Me.cboCustomers, dt, "Cust_Name1", "Cust_ID")
            Me.cboCustomers.SelectedValue = iCustID

            If iCustID > 0 Then
                If iCustID > 0 Then
                    Me.cboLoc.DataSource = Nothing
                    dt = Generic.GetLocations(True, iCustID)
                    Misc.PopulateC1DropDownList(Me.cboLoc, dt, "Loc_Name", "Loc_ID")
                    If dt.Rows.Count = 2 Then Me.cboLoc.SelectedValue = dt.Rows(0)("Loc_ID") Else Me.cboLoc.SelectedValue = 0
                End If

                Me.cboProduct.DataSource = Nothing
                dt = Generic.GetProductByCustID(True, iCustID)
                Misc.PopulateC1DropDownList(Me.cboProduct, dt, "Prod_Desc", "Prod_ID")
                If dt.Rows.Count = 2 Then
                    Me.cboProduct.SelectedValue = dt.Rows(0)("Prod_ID")
                    Me.txtScanItem.Focus()
                Else
                    Me.cboProduct.SelectedValue = 0
                    Me.cboProduct.Focus()
                End If

                Me.LoadDevicesQtyByWipLocation(_iWipowner_ID)
                Me.txtScanItem.Focus()
            Else
                Me.cboCustomers.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        Finally
            Generic.DisposeDT(dt)
        End Try
    End Sub

    '*********************************************************
    Private Sub LoadDevicesQtyByWipLocation(ByVal iWipLocation As Integer)
        Dim dt As DataTable
        Dim i As Integer = 0

        Try
            dt = _objTransferDev.GetDeviceQtyInWipBucket(Me.cboProduct.SelectedValue, iWipLocation, Me.cboLoc.SelectedValue)
            Me.dbgWIP2Devices.DataSource = Nothing
            If dt.Rows.Count > 0 Then
                Me.dbgWIP2Devices.DataSource = dt.DefaultView

                With Me.dbgWIP2Devices
                    'Heading style (Horizontal Alignment to Center)
                    For i = 0 To .Columns.Count - 1
                        .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    Next i

                    .Caption = Me._strWipownerDesc
                    .Splits(0).DisplayColumns("Model").Width = 180
                    .Splits(0).DisplayColumns("Qty").Width = 70

                    .ColumnFooters = True
                    .Columns(0).FooterText = "TOTAL"
                    .Columns(1).FooterText = dt.Compute("Sum(Qty)", "").ToString
                    '.Caption
                End With
            End If

        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If
        End Try
    End Sub

    '*********************************************************
    Private Sub txtScanItem_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtScanItem.KeyPress
        If Me.radTray_ID.Checked Then
            If Not (Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar)) Then
                e.Handled = True ' Allow only numbers and a period 
            End If
        End If
    End Sub

    '*********************************************************
    Private Sub txtScanItem_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtScanItem.KeyUp
        Try
            If e.KeyValue = 13 Then
                Me.ProcessScanItem()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End Try
    End Sub

    '*********************************************************
    Private Sub ProcessScanItem()
        Dim strMsg As String = ""
        Dim strScanItemType As String = "TrayID"

        Try
            'Validate input
            If Me.txtScanItem.Text = "" Then
                Exit Sub
            ElseIf Me.cboCustomers.SelectedValue = 0 Then
                MessageBox.Show("Please select Customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cboCustomers.Focus()
                Exit Sub
            ElseIf Me.cboLoc.SelectedValue = 0 Then
                MessageBox.Show("Please select location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cboCustomers.Focus()
                Exit Sub
            ElseIf Me.cboProduct.SelectedValue = 0 Then
                MessageBox.Show("Please select Product.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cboProduct.Focus()
                Exit Sub
            ElseIf Me.radTray_ID.Checked = True Then
                If IsNumeric(Me.txtScanItem.Text.Trim) = False Then
                    MessageBox.Show("Invalid Tray ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtScanItem.SelectAll()
                    Exit Sub
                ElseIf Me._objTransferDev.CheckShipDate(CInt(Me.txtScanItem.Text.Trim), Me.cboProduct.SelectedValue) = True Then
                    If MessageBox.Show("Some device(s) in this tray have already been shipped. Would you like to continue?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                        Me.txtScanItem.Text = ""
                        Exit Sub
                    End If
                End If
            End If

            If Me.radSN.Checked = True Then
                strScanItemType = "SN"
            End If

            Select Case Me._iWipowner_ID
                Case 2
                    strMsg = Me._objTransferDev.TranferDevIntoPreCellWIPBucket(strScanItemType, Me.txtScanItem.Text.Trim, Me.cboProduct.SelectedValue, Me.cboLoc.SelectedValue)
                Case 6
                    strMsg = Me._objTransferDev.TranferDevIntoHoldWIPBucket(strScanItemType, Me.txtScanItem.Text.Trim, Me.cboProduct.SelectedValue, Me.cboLoc.SelectedValue)
            End Select

            If strMsg = "" Then
                MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.LoadDevicesQtyByWipLocation(Me._iWipowner_ID)
                Me.txtScanItem.Text = ""
                Me.txtScanItem.Focus()
            Else
                MessageBox.Show(strMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtScanItem.Focus()
                Me.txtScanItem.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*********************************************************
    Private Sub btnTransfer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransfer.Click
        Try
            Me.ProcessScanItem()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End Try
    End Sub

    '*********************************************************
    Private Sub radTray_ID_SN_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radTray_ID.CheckedChanged, radSN.CheckedChanged
        Me.txtScanItem.Text = ""
        Me.txtScanItem.Focus()
    End Sub

    '*********************************************************
    Private Sub cboCustomers_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCustomers.KeyUp, cboProduct.KeyUp
        Dim dt As DataTable
        Try
            If e.KeyCode = Keys.Enter Then
                If sender.name.ToString.Trim = "cboCustomers" Then
                    If Me.cboCustomers.SelectedValue > 0 Then Me.cboLoc.Focus()
                ElseIf sender.name.ToString.Trim = "cboLoc" Then
                    If Me.cboLoc.SelectedValue > 0 Then Me.cboProduct.Focus()
                ElseIf sender.name.ToString.Trim = "cboProduct" Then
                    If Me.cboProduct.SelectedValue > 0 Then
                        Me.LoadDevicesQtyByWipLocation(_iWipowner_ID)
                        Me.txtScanItem.SelectAll()
                        Me.txtScanItem.Focus()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, sender.name.ToString, MessageBoxButtons.OK, MessageBoxIcon.Hand)
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
        End Try
    End Sub

    '*********************************************************
    Private Sub cboCustomers_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomers.Leave
        Dim dt As DataTable
        Try
            If Me.cboCustomers.SelectedValue > 0 Then
                Me.cboLoc.DataSource = Nothing
                dt = Generic.GetLocations(True, Me.cboCustomers.SelectedValue)
                Misc.PopulateC1DropDownList(Me.cboLoc, dt, "Loc_Name", "Loc_ID")
                If dt.Rows.Count = 2 Then Me.cboLoc.SelectedValue = dt.Rows(0)("Loc_ID") Else Me.cboLoc.SelectedValue = 0

                Me.cboProduct.DataSource = Nothing
                dt = Generic.GetProductByCustID(True, Me.cboCustomers.SelectedValue)
                Misc.PopulateC1DropDownList(Me.cboProduct, dt, "Prod_Desc", "Prod_ID")
                If dt.Rows.Count > 0 Then
                    Me.cboProduct.SelectedValue = dt.Rows(0)("Prod_ID")
                    Me.LoadDevicesQtyByWipLocation(Me._iWipowner_ID)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, sender.name.ToString, MessageBoxButtons.OK, MessageBoxIcon.Hand)
        Finally
            Generic.DisposeDT(dt)
        End Try
    End Sub

    '*********************************************************
    Private Sub cboCustomers_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomers.Enter
        Me.cboLoc.DataSource = Nothing
        Me.cboLoc.Text = ""
        Me.cboProduct.DataSource = Nothing
        Me.cboProduct.Text = ""
        Me.txtScanItem.Text = ""
        Me.dbgWIP2Devices.DataSource = Nothing
    End Sub

    '*********************************************************


End Class
