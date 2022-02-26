Option Explicit On 

Imports PSS.Data.Buisness

Public Class frmSkyTelBuildShipBox
    Inherits System.Windows.Forms.Form

    Private _objSkytel As SkyTel
    Private _iMachineCC_GrpID As Integer = 0
    Private _iMenuCustID As Integer = 0
    Private _strTabPageTitle As String

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal strTabPageTitle As String, ByVal iCustID As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _objSkytel = New SkyTel()
        _strTabPageTitle = strTabPageTitle
        _iMenuCustID = iCustID
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
            _objSkytel = Nothing
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents btnReprintBoxLabel As System.Windows.Forms.Button
    Friend WithEvents PanelPalletList As System.Windows.Forms.Panel
    Friend WithEvents btnDeleteBox As System.Windows.Forms.Button
    Friend WithEvents btnReopenBox As System.Windows.Forms.Button
    Friend WithEvents pnlShipType As System.Windows.Forms.Panel
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCreateBoxID As System.Windows.Forms.Button
    Friend WithEvents panelPallet As System.Windows.Forms.Panel
    Friend WithEvents txtDevSN As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnCloseBox As System.Windows.Forms.Button
    Friend WithEvents btnRemoveAllSNs As System.Windows.Forms.Button
    Friend WithEvents btnRemoveSN As System.Windows.Forms.Button
    Friend WithEvents lstDevices As System.Windows.Forms.ListBox
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblBin As System.Windows.Forms.Label
    Friend WithEvents lblLineSide As System.Windows.Forms.Label
    Friend WithEvents lblMachine As System.Windows.Forms.Label
    Friend WithEvents lblGroup As System.Windows.Forms.Label
    Friend WithEvents lblLine As System.Windows.Forms.Label
    Friend WithEvents lblShift As System.Windows.Forms.Label
    Friend WithEvents lblWorkDate As System.Windows.Forms.Label
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents lblScreenName As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboModels As C1.Win.C1List.C1Combo
    Friend WithEvents cboFreqs As C1.Win.C1List.C1Combo
    Friend WithEvents dbgPallets As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents lblBoxName As System.Windows.Forms.Label
    Friend WithEvents cboBoxTypes As C1.Win.C1List.C1Combo
    Friend WithEvents lblFreq As System.Windows.Forms.Label
    Friend WithEvents btnRecreateManifest As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSkyTelBuildShipBox))
        Me.btnReprintBoxLabel = New System.Windows.Forms.Button()
        Me.PanelPalletList = New System.Windows.Forms.Panel()
        Me.btnRecreateManifest = New System.Windows.Forms.Button()
        Me.btnDeleteBox = New System.Windows.Forms.Button()
        Me.dbgPallets = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnReopenBox = New System.Windows.Forms.Button()
        Me.pnlShipType = New System.Windows.Forms.Panel()
        Me.cboFreqs = New C1.Win.C1List.C1Combo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboBoxTypes = New C1.Win.C1List.C1Combo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboModels = New C1.Win.C1List.C1Combo()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.btnCreateBoxID = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.panelPallet = New System.Windows.Forms.Panel()
        Me.lblFreq = New System.Windows.Forms.Label()
        Me.txtDevSN = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnCloseBox = New System.Windows.Forms.Button()
        Me.btnRemoveAllSNs = New System.Windows.Forms.Button()
        Me.btnRemoveSN = New System.Windows.Forms.Button()
        Me.lstDevices = New System.Windows.Forms.ListBox()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblBoxName = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblBin = New System.Windows.Forms.Label()
        Me.lblLineSide = New System.Windows.Forms.Label()
        Me.lblMachine = New System.Windows.Forms.Label()
        Me.lblGroup = New System.Windows.Forms.Label()
        Me.lblLine = New System.Windows.Forms.Label()
        Me.lblShift = New System.Windows.Forms.Label()
        Me.lblWorkDate = New System.Windows.Forms.Label()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.lblScreenName = New System.Windows.Forms.Label()
        Me.PanelPalletList.SuspendLayout()
        CType(Me.dbgPallets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlShipType.SuspendLayout()
        CType(Me.cboFreqs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboBoxTypes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboModels, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelPallet.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnReprintBoxLabel
        '
        Me.btnReprintBoxLabel.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnReprintBoxLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReprintBoxLabel.ForeColor = System.Drawing.Color.Black
        Me.btnReprintBoxLabel.Location = New System.Drawing.Point(24, 184)
        Me.btnReprintBoxLabel.Name = "btnReprintBoxLabel"
        Me.btnReprintBoxLabel.Size = New System.Drawing.Size(272, 32)
        Me.btnReprintBoxLabel.TabIndex = 3
        Me.btnReprintBoxLabel.Text = "REPRINT BOX LABEL"
        '
        'PanelPalletList
        '
        Me.PanelPalletList.BackColor = System.Drawing.Color.SteelBlue
        Me.PanelPalletList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelPalletList.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRecreateManifest, Me.btnDeleteBox, Me.dbgPallets, Me.btnReopenBox, Me.btnReprintBoxLabel})
        Me.PanelPalletList.Location = New System.Drawing.Point(1, 224)
        Me.PanelPalletList.Name = "PanelPalletList"
        Me.PanelPalletList.Size = New System.Drawing.Size(319, 272)
        Me.PanelPalletList.TabIndex = 1
        '
        'btnRecreateManifest
        '
        Me.btnRecreateManifest.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnRecreateManifest.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRecreateManifest.ForeColor = System.Drawing.Color.Black
        Me.btnRecreateManifest.Location = New System.Drawing.Point(24, 224)
        Me.btnRecreateManifest.Name = "btnRecreateManifest"
        Me.btnRecreateManifest.Size = New System.Drawing.Size(272, 32)
        Me.btnRecreateManifest.TabIndex = 4
        Me.btnRecreateManifest.Text = "Re-Create Excel Manifest"
        '
        'btnDeleteBox
        '
        Me.btnDeleteBox.BackColor = System.Drawing.Color.Red
        Me.btnDeleteBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteBox.ForeColor = System.Drawing.Color.White
        Me.btnDeleteBox.Location = New System.Drawing.Point(152, 144)
        Me.btnDeleteBox.Name = "btnDeleteBox"
        Me.btnDeleteBox.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnDeleteBox.Size = New System.Drawing.Size(144, 32)
        Me.btnDeleteBox.TabIndex = 2
        Me.btnDeleteBox.Text = "DELETE EMPTY BOX"
        '
        'dbgPallets
        '
        Me.dbgPallets.AllowColMove = False
        Me.dbgPallets.AllowColSelect = False
        Me.dbgPallets.AllowFilter = False
        Me.dbgPallets.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.dbgPallets.AllowSort = False
        Me.dbgPallets.AllowUpdate = False
        Me.dbgPallets.AllowUpdateOnBlur = False
        Me.dbgPallets.CollapseColor = System.Drawing.Color.White
        Me.dbgPallets.ExpandColor = System.Drawing.Color.White
        Me.dbgPallets.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dbgPallets.ForeColor = System.Drawing.Color.White
        Me.dbgPallets.GroupByCaption = "Drag a column header here to group by that column"
        Me.dbgPallets.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.dbgPallets.Location = New System.Drawing.Point(27, 9)
        Me.dbgPallets.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.dbgPallets.Name = "dbgPallets"
        Me.dbgPallets.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgPallets.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgPallets.PreviewInfo.ZoomFactor = 75
        Me.dbgPallets.RowHeight = 20
        Me.dbgPallets.Size = New System.Drawing.Size(269, 119)
        Me.dbgPallets.TabIndex = 0
        Me.dbgPallets.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:SteelBlue;}Sele" & _
        "cted{ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Whi" & _
        "te;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Center;ForeCo" & _
        "lor:White;}Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt, style=Bold;BackColo" & _
        "r:LightSteelBlue;ForeColor:White;AlignVert:Center;}HighlightRow{ForeColor:Highli" & _
        "ghtText;BackColor:Highlight;}Style12{}OddRow{BackColor:Teal;}RecordSelector{Alig" & _
        "nImage:Center;ForeColor:White;}Style13{}Heading{Wrap:True;Font:Microsoft Sans Se" & _
        "rif, 8.25pt, style=Bold;AlignHorz:Center;AlignVert:Center;Border:Raised,,1, 1, 1" & _
        ", 1;ForeColor:Blue;BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style11{}S" & _
        "tyle14{}Style15{}Style16{}Style17{}Style1{}</Data></Styles><Splits><C1.Win.C1Tru" & _
        "eDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" Name="""" AllowRowSi" & _
        "zing=""None"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" " & _
        "MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Ver" & _
        "ticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>115</Height><CaptionStyle" & _
        " parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><Even" & _
        "RowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""S" & _
        "tyle13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" " & _
        "me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle p" & _
        "arent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" " & _
        "/><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""Record" & _
        "Selector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style p" & _
        "arent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 265, 115</ClientRect><BorderSide>" & _
        "0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView><" & _
        "/Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""H" & _
        "eading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Capt" & _
        "ion"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Select" & _
        "ed"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightR" & _
        "ow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /" & _
        "><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""Filter" & _
        "Bar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSpl" & _
        "its><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</Defau" & _
        "ltRecSelWidth><ClientArea>0, 0, 265, 115</ClientArea><PrintPageHeaderStyle paren" & _
        "t="""" me=""Style16"" /><PrintPageFooterStyle parent="""" me=""Style17"" /></Blob>"
        '
        'btnReopenBox
        '
        Me.btnReopenBox.BackColor = System.Drawing.Color.Red
        Me.btnReopenBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReopenBox.ForeColor = System.Drawing.Color.White
        Me.btnReopenBox.Location = New System.Drawing.Point(24, 144)
        Me.btnReopenBox.Name = "btnReopenBox"
        Me.btnReopenBox.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnReopenBox.Size = New System.Drawing.Size(112, 32)
        Me.btnReopenBox.TabIndex = 1
        Me.btnReopenBox.Text = "REOPEN  BOX"
        '
        'pnlShipType
        '
        Me.pnlShipType.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlShipType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlShipType.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboFreqs, Me.Label4, Me.cboBoxTypes, Me.Label2, Me.cboModels, Me.Button5, Me.btnCreateBoxID, Me.Label1})
        Me.pnlShipType.Location = New System.Drawing.Point(1, 72)
        Me.pnlShipType.Name = "pnlShipType"
        Me.pnlShipType.Size = New System.Drawing.Size(319, 152)
        Me.pnlShipType.TabIndex = 0
        '
        'cboFreqs
        '
        Me.cboFreqs.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboFreqs.Caption = ""
        Me.cboFreqs.CaptionHeight = 17
        Me.cboFreqs.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboFreqs.ColumnCaptionHeight = 17
        Me.cboFreqs.ColumnFooterHeight = 17
        Me.cboFreqs.ContentHeight = 15
        Me.cboFreqs.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboFreqs.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboFreqs.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFreqs.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboFreqs.EditorHeight = 15
        Me.cboFreqs.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
        Me.cboFreqs.ItemHeight = 15
        Me.cboFreqs.Location = New System.Drawing.Point(80, 72)
        Me.cboFreqs.MatchEntryTimeout = CType(2000, Long)
        Me.cboFreqs.MaxDropDownItems = CType(5, Short)
        Me.cboFreqs.MaxLength = 32767
        Me.cboFreqs.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboFreqs.Name = "cboFreqs"
        Me.cboFreqs.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboFreqs.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboFreqs.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboFreqs.Size = New System.Drawing.Size(216, 21)
        Me.cboFreqs.TabIndex = 2
        Me.cboFreqs.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(8, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 16)
        Me.Label4.TabIndex = 89
        Me.Label4.Text = "Freq:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboBoxTypes
        '
        Me.cboBoxTypes.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboBoxTypes.Caption = ""
        Me.cboBoxTypes.CaptionHeight = 17
        Me.cboBoxTypes.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboBoxTypes.ColumnCaptionHeight = 17
        Me.cboBoxTypes.ColumnFooterHeight = 17
        Me.cboBoxTypes.ContentHeight = 15
        Me.cboBoxTypes.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboBoxTypes.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboBoxTypes.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBoxTypes.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboBoxTypes.EditorHeight = 15
        Me.cboBoxTypes.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
        Me.cboBoxTypes.ItemHeight = 15
        Me.cboBoxTypes.Location = New System.Drawing.Point(80, 40)
        Me.cboBoxTypes.MatchEntryTimeout = CType(2000, Long)
        Me.cboBoxTypes.MaxDropDownItems = CType(5, Short)
        Me.cboBoxTypes.MaxLength = 32767
        Me.cboBoxTypes.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboBoxTypes.Name = "cboBoxTypes"
        Me.cboBoxTypes.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboBoxTypes.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboBoxTypes.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboBoxTypes.Size = New System.Drawing.Size(216, 21)
        Me.cboBoxTypes.TabIndex = 1
        Me.cboBoxTypes.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(8, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 16)
        Me.Label2.TabIndex = 87
        Me.Label2.Text = "Box Type:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.cboModels.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
        Me.cboModels.ItemHeight = 15
        Me.cboModels.Location = New System.Drawing.Point(80, 4)
        Me.cboModels.MatchEntryTimeout = CType(2000, Long)
        Me.cboModels.MaxDropDownItems = CType(5, Short)
        Me.cboModels.MaxLength = 32767
        Me.cboModels.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboModels.Name = "cboModels"
        Me.cboModels.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboModels.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboModels.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboModels.Size = New System.Drawing.Size(216, 21)
        Me.cboModels.TabIndex = 0
        Me.cboModels.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.Black
        Me.Button5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(720, 200)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(300, 300)
        Me.Button5.TabIndex = 66
        Me.Button5.TabStop = False
        Me.Button5.Text = "Generate Report"
        '
        'btnCreateBoxID
        '
        Me.btnCreateBoxID.BackColor = System.Drawing.Color.Green
        Me.btnCreateBoxID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreateBoxID.ForeColor = System.Drawing.Color.White
        Me.btnCreateBoxID.Location = New System.Drawing.Point(80, 104)
        Me.btnCreateBoxID.Name = "btnCreateBoxID"
        Me.btnCreateBoxID.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCreateBoxID.Size = New System.Drawing.Size(216, 32)
        Me.btnCreateBoxID.TabIndex = 3
        Me.btnCreateBoxID.Text = "CREATE BOX ID"
        Me.btnCreateBoxID.Visible = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(8, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 16)
        Me.Label1.TabIndex = 85
        Me.Label1.Text = "Model:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'panelPallet
        '
        Me.panelPallet.BackColor = System.Drawing.Color.SteelBlue
        Me.panelPallet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panelPallet.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblFreq, Me.txtDevSN, Me.Label10, Me.btnCloseBox, Me.btnRemoveAllSNs, Me.btnRemoveSN, Me.lstDevices, Me.lblCount, Me.Label3, Me.lblBoxName})
        Me.panelPallet.Location = New System.Drawing.Point(322, 72)
        Me.panelPallet.Name = "panelPallet"
        Me.panelPallet.Size = New System.Drawing.Size(352, 424)
        Me.panelPallet.TabIndex = 2
        Me.panelPallet.Visible = False
        '
        'lblFreq
        '
        Me.lblFreq.BackColor = System.Drawing.Color.Black
        Me.lblFreq.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFreq.ForeColor = System.Drawing.Color.Lime
        Me.lblFreq.Location = New System.Drawing.Point(184, 48)
        Me.lblFreq.Name = "lblFreq"
        Me.lblFreq.Size = New System.Drawing.Size(144, 24)
        Me.lblFreq.TabIndex = 100
        Me.lblFreq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtDevSN
        '
        Me.txtDevSN.Location = New System.Drawing.Point(11, 56)
        Me.txtDevSN.Name = "txtDevSN"
        Me.txtDevSN.Size = New System.Drawing.Size(156, 20)
        Me.txtDevSN.TabIndex = 0
        Me.txtDevSN.Text = ""
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(11, 40)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(157, 16)
        Me.Label10.TabIndex = 99
        Me.Label10.Text = "Serial Number:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCloseBox
        '
        Me.btnCloseBox.BackColor = System.Drawing.Color.Green
        Me.btnCloseBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCloseBox.ForeColor = System.Drawing.Color.White
        Me.btnCloseBox.Location = New System.Drawing.Point(11, 368)
        Me.btnCloseBox.Name = "btnCloseBox"
        Me.btnCloseBox.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCloseBox.Size = New System.Drawing.Size(157, 32)
        Me.btnCloseBox.TabIndex = 2
        Me.btnCloseBox.Text = "CLOSE BOX"
        '
        'btnRemoveAllSNs
        '
        Me.btnRemoveAllSNs.BackColor = System.Drawing.Color.Red
        Me.btnRemoveAllSNs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveAllSNs.ForeColor = System.Drawing.Color.White
        Me.btnRemoveAllSNs.Location = New System.Drawing.Point(180, 248)
        Me.btnRemoveAllSNs.Name = "btnRemoveAllSNs"
        Me.btnRemoveAllSNs.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnRemoveAllSNs.Size = New System.Drawing.Size(148, 33)
        Me.btnRemoveAllSNs.TabIndex = 4
        Me.btnRemoveAllSNs.Text = "REMOVE ALL SNs"
        '
        'btnRemoveSN
        '
        Me.btnRemoveSN.BackColor = System.Drawing.Color.Red
        Me.btnRemoveSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveSN.ForeColor = System.Drawing.Color.White
        Me.btnRemoveSN.Location = New System.Drawing.Point(180, 208)
        Me.btnRemoveSN.Name = "btnRemoveSN"
        Me.btnRemoveSN.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnRemoveSN.Size = New System.Drawing.Size(148, 32)
        Me.btnRemoveSN.TabIndex = 3
        Me.btnRemoveSN.Text = "REMOVE SN"
        '
        'lstDevices
        '
        Me.lstDevices.Location = New System.Drawing.Point(11, 80)
        Me.lstDevices.Name = "lstDevices"
        Me.lstDevices.Size = New System.Drawing.Size(156, 277)
        Me.lstDevices.TabIndex = 1
        '
        'lblCount
        '
        Me.lblCount.BackColor = System.Drawing.Color.Black
        Me.lblCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCount.ForeColor = System.Drawing.Color.Lime
        Me.lblCount.Location = New System.Drawing.Point(205, 136)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(98, 32)
        Me.lblCount.TabIndex = 97
        Me.lblCount.Text = "0"
        Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(208, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 96
        Me.Label3.Text = "Box Count"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblBoxName
        '
        Me.lblBoxName.BackColor = System.Drawing.Color.Black
        Me.lblBoxName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBoxName.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBoxName.ForeColor = System.Drawing.Color.Lime
        Me.lblBoxName.Location = New System.Drawing.Point(10, 5)
        Me.lblBoxName.Name = "lblBoxName"
        Me.lblBoxName.Size = New System.Drawing.Size(318, 32)
        Me.lblBoxName.TabIndex = 98
        Me.lblBoxName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblBin, Me.lblLineSide, Me.lblMachine, Me.lblGroup, Me.lblLine, Me.lblShift, Me.lblWorkDate, Me.lblUserName})
        Me.Panel2.Location = New System.Drawing.Point(232, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(576, 71)
        Me.Panel2.TabIndex = 116
        '
        'lblBin
        '
        Me.lblBin.BackColor = System.Drawing.Color.Transparent
        Me.lblBin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBin.ForeColor = System.Drawing.Color.Lime
        Me.lblBin.Location = New System.Drawing.Point(176, 25)
        Me.lblBin.Name = "lblBin"
        Me.lblBin.Size = New System.Drawing.Size(178, 16)
        Me.lblBin.TabIndex = 94
        Me.lblBin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLineSide
        '
        Me.lblLineSide.BackColor = System.Drawing.Color.Transparent
        Me.lblLineSide.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLineSide.ForeColor = System.Drawing.Color.Lime
        Me.lblLineSide.Location = New System.Drawing.Point(8, 46)
        Me.lblLineSide.Name = "lblLineSide"
        Me.lblLineSide.Size = New System.Drawing.Size(146, 16)
        Me.lblLineSide.TabIndex = 93
        Me.lblLineSide.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMachine
        '
        Me.lblMachine.BackColor = System.Drawing.Color.Transparent
        Me.lblMachine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMachine.ForeColor = System.Drawing.Color.Lime
        Me.lblMachine.Location = New System.Drawing.Point(176, 4)
        Me.lblMachine.Name = "lblMachine"
        Me.lblMachine.Size = New System.Drawing.Size(178, 16)
        Me.lblMachine.TabIndex = 92
        Me.lblMachine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGroup
        '
        Me.lblGroup.BackColor = System.Drawing.Color.Transparent
        Me.lblGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroup.ForeColor = System.Drawing.Color.Lime
        Me.lblGroup.Location = New System.Drawing.Point(8, 4)
        Me.lblGroup.Name = "lblGroup"
        Me.lblGroup.Size = New System.Drawing.Size(146, 16)
        Me.lblGroup.TabIndex = 91
        Me.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLine
        '
        Me.lblLine.BackColor = System.Drawing.Color.Transparent
        Me.lblLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLine.ForeColor = System.Drawing.Color.Lime
        Me.lblLine.Location = New System.Drawing.Point(8, 25)
        Me.lblLine.Name = "lblLine"
        Me.lblLine.Size = New System.Drawing.Size(146, 16)
        Me.lblLine.TabIndex = 90
        Me.lblLine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblShift
        '
        Me.lblShift.BackColor = System.Drawing.Color.Transparent
        Me.lblShift.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShift.ForeColor = System.Drawing.Color.Lime
        Me.lblShift.Location = New System.Drawing.Point(376, 25)
        Me.lblShift.Name = "lblShift"
        Me.lblShift.Size = New System.Drawing.Size(178, 16)
        Me.lblShift.TabIndex = 88
        Me.lblShift.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWorkDate
        '
        Me.lblWorkDate.BackColor = System.Drawing.Color.Transparent
        Me.lblWorkDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWorkDate.ForeColor = System.Drawing.Color.Lime
        Me.lblWorkDate.Location = New System.Drawing.Point(376, 46)
        Me.lblWorkDate.Name = "lblWorkDate"
        Me.lblWorkDate.Size = New System.Drawing.Size(178, 16)
        Me.lblWorkDate.TabIndex = 84
        Me.lblWorkDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUserName
        '
        Me.lblUserName.BackColor = System.Drawing.Color.Transparent
        Me.lblUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserName.ForeColor = System.Drawing.Color.Lime
        Me.lblUserName.Location = New System.Drawing.Point(376, 4)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(178, 16)
        Me.lblUserName.TabIndex = 83
        Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblScreenName
        '
        Me.lblScreenName.BackColor = System.Drawing.Color.Black
        Me.lblScreenName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblScreenName.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScreenName.ForeColor = System.Drawing.Color.Yellow
        Me.lblScreenName.Name = "lblScreenName"
        Me.lblScreenName.Size = New System.Drawing.Size(229, 70)
        Me.lblScreenName.TabIndex = 115
        Me.lblScreenName.Text = "SKYTEL BUILD SHIP BOX"
        Me.lblScreenName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmSkyTelBuildShipBox
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(816, 509)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.PanelPalletList, Me.pnlShipType, Me.panelPallet, Me.Panel2, Me.lblScreenName})
        Me.Name = "frmSkyTelBuildShipBox"
        Me.Text = "frmSkyTelBuildShipBox"
        Me.PanelPalletList.ResumeLayout(False)
        CType(Me.dbgPallets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlShipType.ResumeLayout(False)
        CType(Me.cboFreqs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboBoxTypes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboModels, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelPallet.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************************************************************************************************
    Private Sub txtDevSN_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDevSN.KeyPress
        Try
            If Not (e.KeyChar.IsLetterOrDigit(e.KeyChar) Or e.KeyChar.IsControl(e.KeyChar)) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtSN_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '********************************************************************************************************************************************************
    Private Sub frmSkyTelShip_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Const ProdID As Integer = 1
        Dim dt As DataTable
        Dim isComputerNameMapped As Boolean = False
        Dim tmpStr As String = String.Empty

        Try
            '**********************************************************************************************************************************************
            'Set ScreenName
            '**********************************************************************************************************************************************
            Me.lblScreenName.Text = Me._strTabPageTitle
            If Me._iMenuCustID = _objSkytel.MorrisCom_CUSTOMER_ID Then Me.lblScreenName.Font = New Font("Microsoft Sans Serif", 15, FontStyle.Bold)

            '***********************************************************************************************************************************************
            'check computer mapping: 4 groups: Group_id=83 for Skytel; Group_id=100 for Morris Commiication; Group_id=101 for Propage, Group_id =96 fro Aquis
            '***********************************************************************************************************************************************
            Me._iMachineCC_GrpID = Generic.GetMachineCostCenterGrpID()
            Select Case Me._iMenuCustID
                Case Me._objSkytel.SKYTEL_CUSTOMER_ID
                    tmpStr = "SkyTel"
                    If Me._iMachineCC_GrpID = Me._objSkytel.SKYTEL_GROUPID Then
                        isComputerNameMapped = True
                    End If
                Case Me._objSkytel.MorrisCom_CUSTOMER_ID
                    tmpStr = "Morris Communcation"
                    If Me._iMachineCC_GrpID = Me._objSkytel.MorrisCom_GROUPID Then
                        isComputerNameMapped = True
                    End If
                Case Me._objSkytel.Propage_CUSTOMER_ID
                    tmpStr = "Propage"
                    If Me._iMachineCC_GrpID = Me._objSkytel.Propage_GROUPID Then
                        isComputerNameMapped = True
                    End If
                Case Me._objSkytel.Aquis_CUSTOMER_ID
                    tmpStr = "Aquis"
                    If Me._iMachineCC_GrpID = Me._objSkytel.Aquis_GROUPID Then
                        isComputerNameMapped = True
                    End If
                Case Else
                    'MessageBox.Show("Wrong customer! It must be one of these: SkyTel, Morris Communication, Propage, and Aquis.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    'Me.Close()
                    tmpStr = ""
                    If Me._iMenuCustID > 0 Then isComputerNameMapped = True
            End Select

            If Not isComputerNameMapped Then
                MessageBox.Show("Machine is not mapped to " & tmpStr & " group.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Close()
                If PSS.Gui.MainWin.MainWin.wrkArea.TabPages.Count > 0 Then
                    PSS.Gui.MainWin.MainWin.wrkArea.TabPages.RemoveAt(PSS.Gui.MainWin.MainWin.wrkArea.SelectedIndex)
                Else
                    PSS.Gui.MainWin.MainWin.wrkArea.TabPages.Clear()
                End If
            Else

                '02-03-2012
                'If Me._iMachineCC_GrpID = 0 Or Me._iMachineCC_GrpID <> 83 Then
                '    MessageBox.Show("Machine is not map to SkyTel group.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                '    Me.Close()
                '    If PSS.Gui.MainWin.MainWin.wrkArea.TabPages.Count > 0 Then
                '        PSS.Gui.MainWin.MainWin.wrkArea.TabPages.RemoveAt(PSS.Gui.MainWin.MainWin.wrkArea.SelectedIndex)
                '    Else
                '        PSS.Gui.MainWin.MainWin.wrkArea.TabPages.Clear()
                '    End If
                'End If

                '******************************************************************************************************************************
                'populate data to dropdown list controls
                '******************************************************************************************************************************
                dt = Me._objSkytel.GetMessModelsWithMotoSku()
                Misc.PopulateC1DropDownList(Me.cboModels, dt, "Model_Desc", "Model_ID")

                Generic.DisposeDT(dt)
                dt = Generic.GetFreqs(True)
                Misc.PopulateC1DropDownList(Me.cboFreqs, dt, "freq_Number", "freq_id")
                Me.cboFreqs.SelectedValue = 0

                Generic.DisposeDT(dt)
                dt = Me._objSkytel.GetSkyTelShipBoxTypes()
                Misc.PopulateC1DropDownList(Me.cboBoxTypes, dt, "ShipTypeDesc", "ShipTypeID")
                Me.cboBoxTypes.SelectedValue = 0
                '******************************************

                Me.cboModels.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "FormLoad", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Generic.DisposeDT(dt)
        End Try
    End Sub

    '********************************************************************************************************************************************************
    Private Sub cbos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboModels.KeyUp, cboFreqs.KeyUp, cboBoxTypes.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                If sender.name = "cboModels" Then
                    If Me.cboModels.SelectedValue > 0 Then
                        'Populate open box
                        Me.PopulateOpenBoxs()
                        Me.cboBoxTypes.Focus()
                    Else
                        Me.dbgPallets.DataSource = Nothing
                        Me.lblBoxName.Text = ""
                        Me.lblCount.Text = "0"
                        Me.txtDevSN.Text = ""
                        Me.lstDevices.DataSource = Nothing
                        Me.panelPallet.Visible = False
                        Me.btnCreateBoxID.Visible = False
                    End If
                ElseIf sender.name.trim = "cboBoxTypes" Then
                    If Not IsNothing(Me.cboBoxTypes.SelectedValue) Then
                        If Me.cboBoxTypes.SelectedValue = 0 Then
                            Me.cboFreqs.Enabled = True
                            Me.cboFreqs.Focus()
                        Else
                            Me.cboFreqs.SelectedValue = 0
                            Me.cboFreqs.Enabled = False
                            Me.btnCreateBoxID.Visible = True
                        End If 'Ship type
                    Else
                        Me.btnCreateBoxID.Visible = False
                    End If  'Ship type 
                ElseIf sender.name.trim = "cboFreqs" Then
                    If Me.cboFreqs.SelectedValue > 0 Then Me.btnCreateBoxID.Visible = True
                End If
            End If 'enter key
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "cbos_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '********************************************************************
    Private Sub PopulateOpenBoxs(Optional ByVal iPallettID As Integer = 0)
        Dim dt As DataTable
        Dim strModelMotoSku As String
        Dim strPalletnamePrefix As String = Me._objSkytel.GetPalletNamePrefixStr(Me._iMenuCustID)

        Try
            Me.dbgPallets.DataSource = Nothing
            Me.txtDevSN.Text = ""
            Me.lstDevices.DataSource = Nothing
            Me.lblBoxName.Text = ""
            Me.lblCount.Text = "0"
            Me.panelPallet.Visible = False
            Me.btnCreateBoxID.Visible = False
            strModelMotoSku = Me.GetModelShortName()

            If strModelMotoSku.Trim.Length > 0 Then
                'dt = Me._objSkytel.GetOpenPallets(Me.cboModels.SelectedValue, "SK" & strModelMotoSku)
                dt = Me._objSkytel.GetOpenPallets(Me.cboModels.SelectedValue, strPalletnamePrefix & strModelMotoSku, Me._iMenuCustID)
                With Me.dbgPallets
                    .DataSource = dt.DefaultView
                    SetGridOpenBoxProperties(iPallettID)
                End With
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "cbos_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Generic.DisposeDT(dt)
        End Try
    End Sub

    '********************************************************************
    Private Function GetModelShortName() As String
        Dim dtModels As DataTable
        Dim strModelMotoSku As String = ""

        Try
            dtModels = Me.cboModels.DataSource.Table
            If dtModels.Select("Model_ID = " & Me.cboModels.SelectedValue).Length = 0 Then
                MessageBox.Show("Can not define model short name. Please select model again.", "Populate Box", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf IsDBNull(dtModels.Select("Model_ID = " & Me.cboModels.SelectedValue)(0)("Model_MotoSku")) OrElse dtModels.Select("Model_ID = " & Me.cboModels.SelectedValue)(0)("Model_MotoSku").ToString.Trim.Length = 0 Then
                MessageBox.Show("Model short name is missing in the system. Please contact IT.", "Populate Box", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                strModelMotoSku = dtModels.Select("Model_ID = " & Me.cboModels.SelectedValue)(0)("Model_MotoSku")
            End If

            Return strModelMotoSku
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "cbos_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dtModels = Nothing
        End Try
    End Function

    '********************************************************************
    Private Sub SetGridOpenBoxProperties(Optional ByVal iPallet_ID As Integer = 0)
        Dim iNumOfColumns As Integer = Me.dbgPallets.Columns.Count
        Dim i As Integer

        With Me.dbgPallets
            'Heading style (Horizontal Alignment to Center)
            For i = 0 To (iNumOfColumns - 1)
                .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns(i).Visible = False
            Next
            'header forecolor
            .Splits(0).DisplayColumns(0).HeadingStyle.ForeColor = .ForeColor.Black
            .Splits(0).DisplayColumns(1).HeadingStyle.ForeColor = .ForeColor.Black
            .Splits(0).DisplayColumns(2).HeadingStyle.ForeColor = .ForeColor.Black
            .Splits(0).DisplayColumns(3).HeadingStyle.ForeColor = .ForeColor.Black

            'Set individual column data horizontal alignment
            .Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            .Splits(0).DisplayColumns(3).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

            'Body Forecolor
            .Splits(0).DisplayColumns(0).Style.ForeColor = .ForeColor.Black
            .Splits(0).DisplayColumns(1).Style.ForeColor = .ForeColor.Black
            .Splits(0).DisplayColumns(2).Style.ForeColor = .ForeColor.Black
            .Splits(0).DisplayColumns(3).Style.ForeColor = .ForeColor.Black

            'Set Column Widths
            .Splits(0).DisplayColumns("Box Name").Width = 200

            'Make some columns invisible
            .Splits(0).DisplayColumns("Box Name").Visible = True

            .AlternatingRows = True

            For i = 0 To .RowCount - 1
                If .Columns("Pallett_ID").CellValue(i) = iPallet_ID Then
                    Exit Sub
                End If
                .MoveNext()
            Next i
        End With
    End Sub

    '********************************************************************
    Private Sub btnCreateBoxID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateBoxID.Click
        Dim iModelID As Integer = 0
        Dim iBoxType As Integer = 0
        Dim iFreqID As Integer = 0
        Dim strModelShortName As String = ""
        Dim iPallettID As Integer = 0

        Try
            If IsNothing(Me.cboModels.SelectedValue) OrElse Me.cboModels.SelectedValue = 0 Then
                MessageBox.Show("Please select model.", "Create Box ID", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.cboModels.Focus()
            ElseIf IsNothing(Me.cboBoxTypes.SelectedValue) Then
                MessageBox.Show("Please select Box Type.", "Create Box ID", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.cboBoxTypes.Focus()
            ElseIf Me.cboBoxTypes.SelectedValue = 0 AndAlso (IsNothing(Me.cboFreqs.SelectedValue) OrElse Me.cboFreqs.SelectedValue = 0) Then
                MessageBox.Show("Please select frequency.", "Create Box ID", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.cboFreqs.Focus()
            Else
                '**********************************
                '1: Check valid selection of box type
                '**********************************
                If Me.IsValidBoxTypeSelection() = False Then
                    MessageBox.Show("Please select a valid Box Type.", "Create Box ID", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.cboBoxTypes.Focus()
                    Exit Sub
                End If

                '**********************************
                '2: Check valid selection of box type
                '**********************************
                If Me.IsValidFreqSelection = False Then
                    MessageBox.Show("Please select a valid frequency number.", "Create Box ID", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.cboFreqs.Focus()
                    Exit Sub
                End If

                '**********************************
                '3: Get and validate Model short name
                '**********************************
                strModelShortName = Me.GetModelShortName()

                If strModelShortName.Trim.Length <> 0 Then

                    iModelID = Me.cboModels.SelectedValue
                    iBoxType = Me.cboBoxTypes.SelectedValue
                    If iBoxType = 0 Then iFreqID = Me.cboFreqs.SelectedValue

                    'check for open pallet
                    If Me._objSkytel.IsOpenBoxExisted_Messaging(iModelID, iBoxType, Me._objSkytel.GetPalletNamePrefixStr(Me._iMenuCustID), Me._iMenuCustID) = False Then
                        'If Me._objSkytel.IsOpenBoxExisted(iModelID, iBoxType, Me._iMachineCC_GrpID, Me._iMenuCustID) = False Then
                        'iPallettID = Me._objSkytel.CreateBoxID(iModelID, iBoxType, iFreqID, "SK" & strModelShortName & Mid(Me.cboBoxTypes.Text.Trim, 1, 3))
                        iPallettID = Me._objSkytel.CreateBoxID(iModelID, iBoxType, iFreqID, _
                                                               Me._objSkytel.GetPalletNamePrefixStr(Me._iMenuCustID) & strModelShortName & Mid(Me.cboBoxTypes.Text.Trim, 1, 3), _
                                                               Me._iMenuCustID)

                        Me.PopulateOpenBoxs(iPallettID)
                    Else
                        MessageBox.Show("An open box is currently availalbe to fill for selected Model and Box Type combination.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.PopulateOpenBoxs()
                        Me.txtDevSN.Focus()
                    End If  'check if there is an box available to fill
                End If  'validate Model short name
                    '**********************************
                End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnCreateBoxID_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '********************************************************************
    Private Function IsValidBoxTypeSelection() As Boolean
        Dim dtBoxType As DataTable
        Try
            dtBoxType = Me.cboBoxTypes.DataSource.Table
            If dtBoxType.Select("ShipTypeDesc = '" & Me.cboBoxTypes.Text & "'").Length = 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dtBoxType = Nothing
        End Try
    End Function

    '********************************************************************
    Private Function IsValidFreqSelection() As Boolean
        Dim dt As DataTable
        Try
            dt = Me.cboFreqs.DataSource.Table
            If dt.Select("freq_Number = '" & Me.cboFreqs.Text & "'").Length = 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dt = Nothing
        End Try
    End Function

    '********************************************************************
    Private Sub dbgPallets_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dbgPallets.Click
        Try
            Me.ProcessPalletSelection()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "dbgPallets_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '********************************************************************
    Private Sub dbgPallets_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles dbgPallets.RowColChange
        Try
            Me.ProcessPalletSelection()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "dbgPallets_RowColChange", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '********************************************************************
    Private Sub ProcessPalletSelection()
        Dim strShipType As String = ""
        Dim i As Integer = 0
        Dim booFound As Boolean = False

        Try
            Me.lblBoxName.Text = ""
            Me.lblCount.Text = "0"
            Me.txtDevSN.Text = ""
            Me.lstDevices.DataSource = Nothing
            Me.panelPallet.Visible = True

            If Me.dbgPallets.Columns.Count = 0 OrElse Me.dbgPallets.RowCount = 0 Then
                Me.panelPallet.Visible = False
                Exit Sub
            End If
            If Me.dbgPallets.Columns("Box Name").Value.ToString.Trim = "" Then
                Exit Sub
            End If

            Me.lblBoxName.Text = Me.dbgPallets.Columns("Box Name").Value.ToString

            Select Case Me.dbgPallets.Columns("Pallet_ShipType").Value.ToString
                Case "0"    'REFURBISHED
                    Me.cboBoxTypes.SelectedValue = 0
                    Me.cboFreqs.SelectedValue = CInt(Me.dbgPallets.Columns("Pallet_SkuLen").Value.ToString)
                    Me.Enabled = True
                Case Else
                    Me.cboBoxTypes.SelectedValue = CInt(Me.dbgPallets.Columns("Pallet_ShipType").Value.ToString)
                    Me.cboFreqs.SelectedValue = 0
                    Me.cboFreqs.Enabled = False
            End Select

            Me.RefreshSNList()

            '*******************************************
            Me.txtDevSN.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '********************************************************************
    Private Sub RefreshSNList()
        Dim dt1 As DataTable
        Dim iPallet_ID As Integer = 0
        Dim strPalletName As String = ""
        Dim strFreqNo As String = ""
        Dim objMisc As PSS.Data.Buisness.Misc

        Try
            '************************
            'Validations
            iPallet_ID = CInt(Me.dbgPallets.Columns("Pallett_ID").Value.ToString)
            strPalletName = Me.dbgPallets.Columns("Box Name").Value.ToString.Trim
            strFreqNo = Me.dbgPallets.Columns("freq_Number").Value.ToString.Trim

            If iPallet_ID = 0 Then
                Throw New Exception("Box is not selected.")
            ElseIf strPalletName.Trim = "" Then
                Throw New Exception("Box is not selected.")
            End If

            '*******************************************
            'Get all devices add put them in them in list box for a pallet
            objMisc = New PSS.Data.Buisness.Misc()
            dt1 = objMisc.GetAllSNsForPallet(iPallet_ID)
            Me.lstDevices.DataSource = dt1.DefaultView
            Me.lstDevices.ValueMember = dt1.Columns("device_id").ToString
            Me.lstDevices.DisplayMember = dt1.Columns("device_sn").ToString
            Me.lblBoxName.Text = strPalletName
            Me.lblFreq.Text = strFreqNo

            '*******************************************
            Me.lblCount.Text = dt1.Rows.Count
        Catch ex As Exception
            Throw ex
        Finally
            objMisc = Nothing
            PSS.Data.Buisness.Generic.DisposeDT(dt1)
            Me.txtDevSN.Focus()
        End Try
    End Sub

    '********************************************************************
    Private Sub txtDevSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDevSN.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                If Me.txtDevSN.Text.Trim.Length > 0 Then Me.ProcessSkyTelSN()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtDevSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '********************************************************************
    Private Sub ProcessSkyTelSN()
        Dim i As Integer = 0
        Dim strSN As String = Me.txtDevSN.Text.Trim.ToUpper
        Dim dtDevice As DataTable

        Try
            '************************
            'Validations
            If CInt(Me.dbgPallets.Columns("Pallett_ID").Value) = 0 Then
                Throw New Exception("Box Name is not selected.")
            ElseIf Me.dbgPallets.Columns("Box Name").Value.ToString.Trim = "" Then
                Throw New Exception("Box Name is not selected.")
            ElseIf Me.dbgPallets.Columns("Pallet_ShipType").Value.ToString.Trim = "0" AndAlso (Me.dbgPallets.Columns("freq_id").Value.ToString.Trim = "" Or Me.dbgPallets.Columns("freq_Number").Value.ToString.Trim = "") Then
                Throw New Exception("Frequency is not defined for this box. Please verify box criteria.")
            ElseIf Me.txtDevSN.Text.Trim = "" Then
                Exit Sub
            End If

            '***************************************************
            'Step 1: Check if the Device is already scanned in
            For i = 0 To Me.lstDevices.Items.Count - 1
                If UCase(Trim(Me.lstDevices.Items(i).ToString)) = strSN Then
                    MsgBox("This device is already scanned in. Try another one.", MsgBoxStyle.Information, "Device Scan")
                    Me.txtDevSN.Text = ""
                    Me.txtDevSN.Focus()
                    Exit Sub
                End If
            Next

            '***************************************************
            'Added by Lan on 09/16/2007
            'Prevent the user from adding more devices to closed pallet.
            'This happen when a pallet open at the 2 computer, computer 1 
            '  close the pallet and refesh the screen while the other computer screen 
            '  did not get refresh. This check will force the user to refresh the screen.
            '***************************************************
            If Generic.IsPalletClosed(CInt(Me.dbgPallets.Columns("Pallett_ID").Value)) = True Then
                MsgBox("Box had been closed by another machine. Please refresh your screen.", MsgBoxStyle.Information, "Device Scan")
                Exit Sub
            End If
            i = 0

            dtDevice = Me._objSkytel.GetDeviceInfoInWIP(Me.txtDevSN.Text.Trim, CInt(Me.dbgPallets.Columns("Loc_ID").Value))

            If dtDevice.Rows.Count > 1 Then
                MsgBox("This device existed twice in the system. Please contact IT.", MsgBoxStyle.Information, "Information")
                Me.txtDevSN.SelectAll()
                Exit Sub
            ElseIf dtDevice.Rows.Count = 0 Then
                MsgBox("This device does not exist in the system, already ship or belong to a different customer.", MsgBoxStyle.Information, "Information")
                Me.txtDevSN.SelectAll()
                Exit Sub
            Else
                If Not IsDBNull(dtDevice.Rows(0)("Pallett_ID")) Then
                    MsgBox("This device already has assigned into a box ID (" & dtDevice.Rows(0)("Pallett_ID") & ").", MsgBoxStyle.Information, "Information")
                    Me.txtDevSN.Text = ""
                ElseIf dtDevice.Rows(0)("Model_ID") <> CInt(Me.dbgPallets.Columns("Model_ID").Value) Then
                    MsgBox("This device is of a different model. Can't put into this box.", MsgBoxStyle.Information, "Information")
                    Me.txtDevSN.Text = ""
                ElseIf CInt(Me.dbgPallets.Columns("Pallet_ShipType").Value) = 0 AndAlso dtDevice.Rows(0)("freq_id") <> CInt(Me.dbgPallets.Columns("Pallet_SkuLen").Value.ToString.Trim) Then
                    MsgBox("Frequency of the unit does not match with the box's frequency. Can't put into this box.", MsgBoxStyle.Information, "Information")
                    Me.txtDevSN.Text = ""
                ElseIf IsDBNull(dtDevice.Rows(0)("Device_DateBill")) Then
                    MsgBox("This device has not been billed.", MsgBoxStyle.Information, "Information")
                    Me.txtDevSN.Text = ""
                ElseIf Me._objSkytel.CheckDeviceShipType(CInt(Me.dbgPallets.Columns("Pallet_ShipType").Value), dtDevice.Rows(0)("Device_ID")) = False Then
                    Me.txtDevSN.SelectAll()
                ElseIf CInt(Me.dbgPallets.Columns("Pallet_ShipType").Value) = 0 AndAlso Generic.IsValidQCResults(dtDevice.Rows(0)("Device_ID"), 1, "Functional", True) = False Then    'must Final passed
                    Me.txtDevSN.Text = ""
                Else
                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor

                    '***************************************************
                    'if above all is fine then add it to the list and update the database
                    i = PSS.Data.Production.Shipping.AssignDeviceToPallet(dtDevice.Rows(0)("Device_ID"), CInt(Me.dbgPallets.Columns("Pallett_ID").Value))

                    '***************************************************
                    Me.RefreshSNList()
                    'Me.LoadCellProductionNumbers()
                    'Me.LoadWeeklyCellProductionNumbers()
                    Me.Enabled = True
                    Cursor.Current = Cursors.Default
                    Me.txtDevSN.Text = ""
                    Me.txtDevSN.Focus()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("ProcessSN: " & ex.Message, "Device Scan", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.txtDevSN.Text = ""
            Me.txtDevSN.Focus()
        Finally
            Generic.DisposeDT(dtDevice)
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '********************************************************************
    Private Sub btnCloseBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseBox.Click
        Dim i As Integer = 0
        Dim objMisc As PSS.Data.buisness.Misc
        Dim strRptTitle As String = ""

        Try
            '************************
            'Validations
            If CInt(Me.dbgPallets.Columns("Pallett_id").Value) = 0 Then
                Throw New Exception("Box name is not selected.")
            ElseIf Me.dbgPallets.Columns("Box Name").Value.ToString.Trim = "" Then
                Throw New Exception("Box name is not selected.")
            End If

            If Me.lstDevices.Items.Count = 0 Then
                Throw New Exception("There is no devices in this box.")
            End If

            If Me.IsValidBoxTypeSelection = False Then
                MessageBox.Show("Invalid Box type. Please select Box Name again.", "Close Box", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            '************************
            If MessageBox.Show("Are you sure you want to close this box?", "Close Box", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Exit Sub
            End If

            Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

            strRptTitle = Generic.GetCustomerName(_iMenuCustID) & " " & Me.cboBoxTypes.Text & " Manifest"

            '************************
            objMisc = New PSS.Data.Buisness.Misc()
            'i = objMisc.ClosePallet(SkyTel.SKYTEL_CUSTOMER_ID, CInt(Me.dbgPallets.Columns("Pallett_ID").Value), Me.dbgPallets.Columns("Box Name").Value, Me.lstDevices.Items.Count, 0)
            i = objMisc.ClosePallet(Me._iMenuCustID, CInt(Me.dbgPallets.Columns("Pallett_ID").Value), _
                                    Me.dbgPallets.Columns("Box Name").Value, _
                                    Me.lstDevices.Items.Count, Me.dbgPallets.Columns("Pallet_ShipType").Value, 0, strRptTitle)
            If i = 0 Then
                Throw New Exception("Box has not closed yet due to an error. Please contact IT.")
            End If

            Me.cboBoxTypes.SelectedValue = CInt(Me.dbgPallets.Columns("Pallet_ShipType").Value)
            PSS.Data.Production.Shipping.PrintPalletLicensePlate(Me.dbgPallets.Columns("Box Name").Value, Me.dbgPallets.Columns("Model_ID").Value, Me.cboBoxTypes.Text, Me.lstDevices.Items.Count, 3)
            '************************

            'Refresh Pallet (Box) 
            Me.PopulateOpenBoxs()

            '******************************
            'Reset Screen control properties.
            Me.lblBoxName.Text = ""
            Me.lblFreq.Text = ""
            Me.lblCount.Text = 0
            Me.lstDevices.DataSource = Nothing
            Me.panelPallet.Visible = False
            '******************************
        Catch ex As Exception
            MessageBox.Show(ex.Message, "btnCloseBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            objMisc = Nothing
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '********************************************************************
    Private Sub btnRemoveSN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveSN.Click
        Dim strSN As String = ""
        Dim i As Integer = 0
        Dim iDeviceID As Integer = 0

        Try
            '************************
            'Validations
            If Me.dbgPallets.RowCount = 0 Then
                Throw New Exception("Box Name is not selected.")
            ElseIf CInt(Me.dbgPallets.Columns("Pallett_id").Value) = 0 Then
                Throw New Exception("Box Name is not selected.")
            ElseIf Me.lstDevices.Items.Count = 0 Then
                'Throw New Exception("No IMEI in the list to remove.")
                Exit Sub
            End If

            '************************
            strSN = InputBox("Enter S/N:", "S/N").Trim
            If strSN = "" Then
                Throw New Exception("Please enter a S/N if you want to remove it from the selected box.")
            End If

            For i = 0 To Me.lstDevices.Items.Count
                If Me.lstDevices.Items.Item(i)("Device_SN").ToString.Trim = strSN Then
                    iDeviceID = CInt(Me.lstDevices.Items.Item(i)("Device_ID").ToString)
                    Exit For
                End If
            Next i

            If iDeviceID > 0 Then
                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                i = PSS.Data.Production.Shipping.RemoveSNfromPallet(CInt(Me.dbgPallets.Columns("Pallett_id").Value), iDeviceID)
                If i = 0 Then
                    Throw New Exception("S/N entered was not removed from Box.")
                End If

                Me.RefreshSNList()
                'Me.LoadCellProductionNumbers()
                'Me.LoadWeeklyCellProductionNumbers()
            Else
                Throw New Exception("S/N was not listed.")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Clear S/N", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
            Me.txtDevSN.Focus()
        End Try
    End Sub

    '********************************************************************
    Private Sub btnRemoveAllSNs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAllSNs.Click
        Dim str_sn As String = ""
        Dim i As Integer = 0

        If MessageBox.Show("Are you sure you want to remove all devices from this Box?", "Clear All S/Ns", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.No Then
            Exit Sub
        End If

        Try
            '************************
            'Validations
            If Me.dbgPallets.RowCount = 0 Then
                Throw New Exception("Box Name is not selected.")
            ElseIf CInt(Me.dbgPallets.Columns("Pallett_id").Value) = 0 Then
                Throw New Exception("Box Name is not selected.")
            ElseIf Me.lstDevices.Items.Count = 0 Then
                'Throw New Exception("No IMEI in the list to remove.")
                Exit Sub
            End If

            '************************
            Me.Enabled = False
            Cursor.Current = Cursors.WaitCursor

            i = PSS.Data.Production.Shipping.RemoveSNfromPallet(CInt(Me.dbgPallets.Columns("Pallett_id").Value), )
            If i = 0 Then
                Throw New Exception("No SNs were removed from box.")
            End If

            RefreshSNList()
            'Me.LoadCellProductionNumbers()
            'Me.LoadWeeklyCellProductionNumbers()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Clear All SNs", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
            Me.txtDevSN.Focus()
        End Try
    End Sub

    '********************************************************************
    Private Sub btnReopenBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReopenBox.Click
        Dim strPallet As String = ""
        Dim i As Integer = 0
        Dim strGroupChar As String = Me._iMachineCC_GrpID.ToString
        Dim dt As DataTable
        Dim objMisc As PSS.Data.Buisness.Misc

        Try
            '************************
            strPallet = InputBox("Enter Box ID.", "Reopen Box")
            If strPallet = "" Then
                Throw New Exception("Please enter a Box ID if you want to re-open it.")
            End If

            dt = Me._objSkytel.GetSkyTelPallet(strPallet, Me._iMenuCustID)
            If dt.Rows.Count = 0 Then
                MessageBox.Show("Box does not exist in the system or has been removed from the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf dt.Rows.Count > 1 Then
                MessageBox.Show("Box name existed more than one in the system. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf Not IsDBNull(dt.Rows(0)("Pallett_ShipDate")) Then
                MessageBox.Show("Box has been shipped. Not allow to reopen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf dt.Rows(0)("Pallett_ReadyToShipFlg") = 0 Then
                MessageBox.Show("Box is already open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                objMisc = New PSS.Data.Buisness.Misc()
                i = objMisc.ReopenPallet(strPallet)
                If i = 0 Then
                    Throw New Exception("Box was not reopened.")
                End If

                Me.cboModels.SelectedValue = dt.Rows(0)("Model_ID")
                Me.cboBoxTypes.SelectedValue = dt.Rows(0)("Pallet_ShipType")
                Me.cboFreqs.SelectedValue = CInt(dt.Rows(0)("Pallet_SkuLen"))

                'Refresh Pallet( Box )
                Me.PopulateOpenBoxs(dt.Rows(0)("Pallett_ID"))

                '************************
                Me.lstDevices.DataSource = Nothing
                Me.lblCount.Text = "0"
                Me.lblBoxName.Text = ""
                Me.panelPallet.Visible = False
                '************************
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Reopen Box.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            objMisc = Nothing
            Generic.DisposeDT(dt)
        End Try
    End Sub

    '********************************************************************
    Private Sub btnDeleteBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteBox.Click
        Dim i As Integer = 0

        Try
            If CInt(Me.dbgPallets.Columns("Pallett_ID").Value) = 0 Then
                Exit Sub
            End If

            If MessageBox.Show("Are you sure you want to delete selected Box?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                i = PSS.Data.Production.Shipping.DeleteEmptyPallet(CInt(Me.dbgPallets.Columns("Pallett_ID").Value), PSS.Core.ApplicationUser.IDuser)
                MessageBox.Show("Box has been deleted.")

                Me.PopulateOpenBoxs()
                Me.lstDevices.DataSource = Nothing
                Me.lblBoxName.Text = ""
                Me.lblCount.Text = ""
                Me.panelPallet.Visible = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '********************************************************************
    Private Sub btnReprintBoxLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintBoxLabel.Click
        Dim str_pallett As String = ""
        Dim dtPallettInfo As DataTable
        Dim strPalletType As String = ""
        Dim iPalletQty As Integer = 0
        Dim R1 As DataRow
        Dim objMisc As PSS.Data.Buisness.Misc

        Try
            str_pallett = InputBox("Enter Box Name.", "Reprint Box Label")
            If str_pallett = "" Then
                Throw New Exception("Please enter a Box Name if you want to reprint the box label.")
            End If

            Me.Enabled = False
            Cursor.Current = Cursors.WaitCursor

            objMisc = New PSS.Data.Buisness.Misc()
            dtPallettInfo = objMisc.GetPalletInfo_ByPallettName(str_pallett)
            If dtPallettInfo.Rows.Count = 0 Then
                MessageBox.Show("Box Name was not defined in system.", "Reprint Box Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            ElseIf dtPallettInfo.Rows.Count > 1 Then
                MessageBox.Show("Box Name existed twice in the system.", "Reprint Box Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                R1 = dtPallettInfo.Rows(0)

                If R1("Pallett_ReadyToShipFlg") = 0 Then
                    MessageBox.Show("Box is still open.", "Information", MessageBoxButtons.OK)
                    Exit Sub
                End If

                If R1("Pallet_ShipType") = 0 Then
                    strPalletType = "REFURBISHED"
                ElseIf R1("Pallet_ShipType") = 1 Then
                    strPalletType = "DBR"
                ElseIf R1("Pallet_ShipType") = 2 Then
                    strPalletType = "NER"
                Else
                    MessageBox.Show("System can't define Box Type.", "Information", MessageBoxButtons.OK)
                    Exit Sub
                End If

                If Not IsDBNull(R1("Pallett_QTY")) Then iPalletQty = R1("Pallett_QTY")

                If Not IsDBNull(R1("Cust_ID")) Then
                    '_objMisc.PrintPalletDeviceCountRpt(R1("Pallett_ID"), R1("Cust_ID"), 1)
                    PSS.Data.Production.Shipping.PrintPalletLicensePlate(str_pallett, R1("Model_ID"), strPalletType, iPalletQty, 1)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Reprint Box Label.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            objMisc = Nothing
            R1 = Nothing
            If Not IsNothing(dtPallettInfo) Then
                dtPallettInfo.Dispose()
                dtPallettInfo = Nothing
            End If
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '********************************************************************
    Private Sub btnRecreateManifest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecreateManifest.Click
        Dim str_pallett, strPalletType, strRptTitle, strFilePath As String
        Dim dtPallettInfo As DataTable
        Dim iPalletQty As Integer = 0
        Dim R1 As DataRow
        Dim objMisc As PSS.Data.Buisness.Misc
        Dim booPrintRpt As Boolean = False

        Try
            str_pallett = "" : strPalletType = "" : strRptTitle = "" : strFilePath = ""
            str_pallett = InputBox("Enter Box Name.", "Reprint Box Label")

            Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

            objMisc = New PSS.Data.buisness.Misc()
            dtPallettInfo = objMisc.GetPalletInfo_ByPallettName(str_pallett)
            If dtPallettInfo.Rows.Count = 0 Then
                MessageBox.Show("Box Name was not defined in system.", "Reprint Box Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            ElseIf dtPallettInfo.Rows.Count > 1 Then
                MessageBox.Show("Box Name existed twice in the system.", "Reprint Box Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                R1 = dtPallettInfo.Rows(0)

                If R1("Pallett_ReadyToShipFlg") = 0 Then
                    MessageBox.Show("Box is still open.", "Information", MessageBoxButtons.OK)
                    Exit Sub
                End If

                If MessageBox.Show("Do you want to print report?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then booPrintRpt = True

                strRptTitle = Generic.GetCustomerName(R1("Cust_ID")) & " " & Me.cboBoxTypes.DataSource.Table.Select("ShipTypeID = " & R1("Pallet_ShipType"))(0)("ShipTypeDesc") & " Manifest"

                If R1("Cust_ID") = Me._objSkytel.SKYTEL_CUSTOMER_ID Then
                    strFilePath = Me._objSkytel.SKYTEL_MANIFEST_DIR
                ElseIf R1("Cust_ID") = Me._objSkytel.MorrisCom_CUSTOMER_ID Then
                    strFilePath = Me._objSkytel.MorrisCom_MANIFEST_DIR
                ElseIf R1("Cust_ID") = Me._objSkytel.Propage_CUSTOMER_ID Then
                    strFilePath = Me._objSkytel.Propage_MANIFEST_DIR
                ElseIf R1("Cust_ID") = Me._objSkytel.Aquis_CUSTOMER_ID Then
                    strFilePath = Me._objSkytel.Aquis_MANIFEST_DIR
                End If

                Me._objSkytel.CreateShipManifestReport(R1("Pallett_ID"), R1("Pallett_Name"), strFilePath, strRptTitle, booPrintRpt, R1("Pallet_ShipType"))
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Reprint Box Label.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            objMisc = Nothing
            R1 = Nothing
            If Not IsNothing(dtPallettInfo) Then
                dtPallettInfo.Dispose()
                dtPallettInfo = Nothing
            End If
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '********************************************************************

   
End Class
