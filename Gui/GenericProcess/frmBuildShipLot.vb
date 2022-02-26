Option Explicit On 

Imports PSS.Data.Buisness
Imports PSS.Core.[Global]

Namespace Gui.GenericProcess
    Public Class frmBuildShipLot
        Inherits System.Windows.Forms.Form

        Private _iMenuCustID As Integer = 0
        Private _objGP As Data.Buisness.GenericProcess.clsGenericProcess
        Private _booPopulatePallet As Boolean = False
        Private _strManifestFilePath As String = ""

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _objGP = New Data.Buisness.GenericProcess.clsGenericProcess()
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
        Friend WithEvents PanelPalletList As System.Windows.Forms.Panel
        Friend WithEvents dbgPallets As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents pnlShipType As System.Windows.Forms.Panel
        Friend WithEvents Button5 As System.Windows.Forms.Button
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
        Friend WithEvents chkMixModel As System.Windows.Forms.CheckBox
        Friend WithEvents cboLocations As C1.Win.C1List.C1Combo
        Friend WithEvents cboCustomers As C1.Win.C1List.C1Combo
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents cboProduct As C1.Win.C1List.C1Combo
        Friend WithEvents cboModels As C1.Win.C1List.C1Combo
        Friend WithEvents pnlCreateLot As System.Windows.Forms.Panel
        Friend WithEvents cboRepTypes As C1.Win.C1List.C1Combo
        Friend WithEvents cboLotTypes As C1.Win.C1List.C1Combo
        Friend WithEvents lblLotName As System.Windows.Forms.Label
        Friend WithEvents btnReopenLot As System.Windows.Forms.Button
        Friend WithEvents btnDeleteLot As System.Windows.Forms.Button
        Friend WithEvents btnReprintLotLabel As System.Windows.Forms.Button
        Friend WithEvents chkDontMixInboundWO As System.Windows.Forms.CheckBox
        Friend WithEvents lblInboundWO As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmBuildShipLot))
            Me.PanelPalletList = New System.Windows.Forms.Panel()
            Me.dbgPallets = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnReopenLot = New System.Windows.Forms.Button()
            Me.btnDeleteLot = New System.Windows.Forms.Button()
            Me.btnReprintLotLabel = New System.Windows.Forms.Button()
            Me.pnlShipType = New System.Windows.Forms.Panel()
            Me.cboLocations = New C1.Win.C1List.C1Combo()
            Me.cboCustomers = New C1.Win.C1List.C1Combo()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Button5 = New System.Windows.Forms.Button()
            Me.chkMixModel = New System.Windows.Forms.CheckBox()
            Me.cboModels = New C1.Win.C1List.C1Combo()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.cboProduct = New C1.Win.C1List.C1Combo()
            Me.btnCreateBoxID = New System.Windows.Forms.Button()
            Me.panelPallet = New System.Windows.Forms.Panel()
            Me.lblInboundWO = New System.Windows.Forms.Label()
            Me.chkDontMixInboundWO = New System.Windows.Forms.CheckBox()
            Me.txtDevSN = New System.Windows.Forms.TextBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.btnCloseBox = New System.Windows.Forms.Button()
            Me.btnRemoveAllSNs = New System.Windows.Forms.Button()
            Me.btnRemoveSN = New System.Windows.Forms.Button()
            Me.lblCount = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.lblLotName = New System.Windows.Forms.Label()
            Me.lstDevices = New System.Windows.Forms.ListBox()
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
            Me.pnlCreateLot = New System.Windows.Forms.Panel()
            Me.cboLotTypes = New C1.Win.C1List.C1Combo()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.cboRepTypes = New C1.Win.C1List.C1Combo()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.PanelPalletList.SuspendLayout()
            CType(Me.dbgPallets, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlShipType.SuspendLayout()
            CType(Me.cboLocations, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboModels, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboProduct, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.panelPallet.SuspendLayout()
            Me.Panel2.SuspendLayout()
            Me.pnlCreateLot.SuspendLayout()
            CType(Me.cboLotTypes, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboRepTypes, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'PanelPalletList
            '
            Me.PanelPalletList.BackColor = System.Drawing.Color.SteelBlue
            Me.PanelPalletList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.PanelPalletList.Controls.AddRange(New System.Windows.Forms.Control() {Me.dbgPallets, Me.btnReopenLot, Me.btnDeleteLot, Me.btnReprintLotLabel})
            Me.PanelPalletList.Location = New System.Drawing.Point(1, 328)
            Me.PanelPalletList.Name = "PanelPalletList"
            Me.PanelPalletList.Size = New System.Drawing.Size(455, 200)
            Me.PanelPalletList.TabIndex = 4
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
            Me.dbgPallets.Location = New System.Drawing.Point(8, 6)
            Me.dbgPallets.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.dbgPallets.Name = "dbgPallets"
            Me.dbgPallets.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgPallets.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgPallets.PreviewInfo.ZoomFactor = 75
            Me.dbgPallets.RowHeight = 20
            Me.dbgPallets.Size = New System.Drawing.Size(440, 138)
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
            "ticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>134</Height><CaptionStyle" & _
            " parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><Even" & _
            "RowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""S" & _
            "tyle13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" " & _
            "me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle p" & _
            "arent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" " & _
            "/><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""Record" & _
            "Selector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style p" & _
            "arent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 436, 134</ClientRect><BorderSide>" & _
            "0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView><" & _
            "/Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""H" & _
            "eading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Capt" & _
            "ion"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Select" & _
            "ed"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightR" & _
            "ow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /" & _
            "><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""Filter" & _
            "Bar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSpl" & _
            "its><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</Defau" & _
            "ltRecSelWidth><ClientArea>0, 0, 436, 134</ClientArea><PrintPageHeaderStyle paren" & _
            "t="""" me=""Style16"" /><PrintPageFooterStyle parent="""" me=""Style17"" /></Blob>"
            '
            'btnReopenLot
            '
            Me.btnReopenLot.BackColor = System.Drawing.Color.Red
            Me.btnReopenLot.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReopenLot.ForeColor = System.Drawing.Color.White
            Me.btnReopenLot.Location = New System.Drawing.Point(8, 152)
            Me.btnReopenLot.Name = "btnReopenLot"
            Me.btnReopenLot.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnReopenLot.Size = New System.Drawing.Size(88, 32)
            Me.btnReopenLot.TabIndex = 1
            Me.btnReopenLot.Text = "REOPEN  LOT"
            '
            'btnDeleteLot
            '
            Me.btnDeleteLot.BackColor = System.Drawing.Color.Red
            Me.btnDeleteLot.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnDeleteLot.ForeColor = System.Drawing.Color.White
            Me.btnDeleteLot.Location = New System.Drawing.Point(112, 152)
            Me.btnDeleteLot.Name = "btnDeleteLot"
            Me.btnDeleteLot.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnDeleteLot.Size = New System.Drawing.Size(128, 32)
            Me.btnDeleteLot.TabIndex = 2
            Me.btnDeleteLot.Text = "DELETE EMPTY LOT"
            '
            'btnReprintLotLabel
            '
            Me.btnReprintLotLabel.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnReprintLotLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprintLotLabel.ForeColor = System.Drawing.Color.Black
            Me.btnReprintLotLabel.Location = New System.Drawing.Point(256, 152)
            Me.btnReprintLotLabel.Name = "btnReprintLotLabel"
            Me.btnReprintLotLabel.Size = New System.Drawing.Size(128, 32)
            Me.btnReprintLotLabel.TabIndex = 3
            Me.btnReprintLotLabel.Text = "REPRINT LOT LABEL"
            '
            'pnlShipType
            '
            Me.pnlShipType.BackColor = System.Drawing.Color.SteelBlue
            Me.pnlShipType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlShipType.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboLocations, Me.cboCustomers, Me.Label5, Me.Label6, Me.Button5, Me.chkMixModel, Me.cboModels, Me.Label1, Me.Label7, Me.cboProduct})
            Me.pnlShipType.Location = New System.Drawing.Point(1, 72)
            Me.pnlShipType.Name = "pnlShipType"
            Me.pnlShipType.Size = New System.Drawing.Size(455, 152)
            Me.pnlShipType.TabIndex = 2
            '
            'cboLocations
            '
            Me.cboLocations.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboLocations.Caption = ""
            Me.cboLocations.CaptionHeight = 17
            Me.cboLocations.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboLocations.ColumnCaptionHeight = 17
            Me.cboLocations.ColumnFooterHeight = 17
            Me.cboLocations.ContentHeight = 15
            Me.cboLocations.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboLocations.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboLocations.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboLocations.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboLocations.EditorHeight = 15
            Me.cboLocations.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboLocations.ItemHeight = 15
            Me.cboLocations.Location = New System.Drawing.Point(104, 72)
            Me.cboLocations.MatchEntryTimeout = CType(2000, Long)
            Me.cboLocations.MaxDropDownItems = CType(5, Short)
            Me.cboLocations.MaxLength = 32767
            Me.cboLocations.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboLocations.Name = "cboLocations"
            Me.cboLocations.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboLocations.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboLocations.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboLocations.Size = New System.Drawing.Size(240, 21)
            Me.cboLocations.TabIndex = 3
            Me.cboLocations.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            Me.cboCustomers.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboCustomers.ItemHeight = 15
            Me.cboCustomers.Location = New System.Drawing.Point(104, 40)
            Me.cboCustomers.MatchEntryTimeout = CType(2000, Long)
            Me.cboCustomers.MaxDropDownItems = CType(5, Short)
            Me.cboCustomers.MaxLength = 32767
            Me.cboCustomers.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCustomers.Name = "cboCustomers"
            Me.cboCustomers.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCustomers.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCustomers.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCustomers.Size = New System.Drawing.Size(240, 21)
            Me.cboCustomers.TabIndex = 2
            Me.cboCustomers.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label5
            '
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.White
            Me.Label5.Location = New System.Drawing.Point(8, 74)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(88, 16)
            Me.Label5.TabIndex = 93
            Me.Label5.Text = "Location:"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label6
            '
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.White
            Me.Label6.Location = New System.Drawing.Point(8, 43)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(88, 16)
            Me.Label6.TabIndex = 92
            Me.Label6.Text = "Customer:"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            'chkMixModel
            '
            Me.chkMixModel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkMixModel.ForeColor = System.Drawing.Color.Lime
            Me.chkMixModel.Location = New System.Drawing.Point(256, 96)
            Me.chkMixModel.Name = "chkMixModel"
            Me.chkMixModel.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.chkMixModel.Size = New System.Drawing.Size(88, 16)
            Me.chkMixModel.TabIndex = 4
            Me.chkMixModel.Text = "? Mix Model"
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
            Me.cboModels.Location = New System.Drawing.Point(104, 120)
            Me.cboModels.MatchEntryTimeout = CType(2000, Long)
            Me.cboModels.MaxDropDownItems = CType(5, Short)
            Me.cboModels.MaxLength = 32767
            Me.cboModels.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModels.Name = "cboModels"
            Me.cboModels.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModels.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModels.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModels.Size = New System.Drawing.Size(240, 21)
            Me.cboModels.TabIndex = 5
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
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(8, 121)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(88, 16)
            Me.Label1.TabIndex = 95
            Me.Label1.Text = "Model:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label7
            '
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.White
            Me.Label7.Location = New System.Drawing.Point(8, 9)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(88, 16)
            Me.Label7.TabIndex = 97
            Me.Label7.Text = "Product:"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            Me.cboProduct.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.cboProduct.ItemHeight = 15
            Me.cboProduct.Location = New System.Drawing.Point(104, 7)
            Me.cboProduct.MatchEntryTimeout = CType(2000, Long)
            Me.cboProduct.MaxDropDownItems = CType(5, Short)
            Me.cboProduct.MaxLength = 32767
            Me.cboProduct.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboProduct.Name = "cboProduct"
            Me.cboProduct.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboProduct.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboProduct.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboProduct.Size = New System.Drawing.Size(240, 21)
            Me.cboProduct.TabIndex = 1
            Me.cboProduct.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'btnCreateBoxID
            '
            Me.btnCreateBoxID.BackColor = System.Drawing.Color.Green
            Me.btnCreateBoxID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCreateBoxID.ForeColor = System.Drawing.Color.White
            Me.btnCreateBoxID.Location = New System.Drawing.Point(152, 72)
            Me.btnCreateBoxID.Name = "btnCreateBoxID"
            Me.btnCreateBoxID.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnCreateBoxID.Size = New System.Drawing.Size(192, 24)
            Me.btnCreateBoxID.TabIndex = 3
            Me.btnCreateBoxID.Text = "CREATE LOT ID"
            Me.btnCreateBoxID.Visible = False
            '
            'panelPallet
            '
            Me.panelPallet.BackColor = System.Drawing.Color.SteelBlue
            Me.panelPallet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.panelPallet.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblInboundWO, Me.chkDontMixInboundWO, Me.txtDevSN, Me.Label10, Me.btnCloseBox, Me.btnRemoveAllSNs, Me.btnRemoveSN, Me.lblCount, Me.Label3, Me.lblLotName, Me.lstDevices})
            Me.panelPallet.Location = New System.Drawing.Point(456, 72)
            Me.panelPallet.Name = "panelPallet"
            Me.panelPallet.Size = New System.Drawing.Size(344, 456)
            Me.panelPallet.TabIndex = 1
            Me.panelPallet.Visible = False
            '
            'lblInboundWO
            '
            Me.lblInboundWO.BackColor = System.Drawing.Color.Transparent
            Me.lblInboundWO.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblInboundWO.ForeColor = System.Drawing.Color.WhiteSmoke
            Me.lblInboundWO.Location = New System.Drawing.Point(24, 66)
            Me.lblInboundWO.Name = "lblInboundWO"
            Me.lblInboundWO.Size = New System.Drawing.Size(304, 16)
            Me.lblInboundWO.TabIndex = 101
            Me.lblInboundWO.Tag = "0"
            Me.lblInboundWO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'chkDontMixInboundWO
            '
            Me.chkDontMixInboundWO.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkDontMixInboundWO.ForeColor = System.Drawing.Color.Lime
            Me.chkDontMixInboundWO.Location = New System.Drawing.Point(8, 48)
            Me.chkDontMixInboundWO.Name = "chkDontMixInboundWO"
            Me.chkDontMixInboundWO.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.chkDontMixInboundWO.Size = New System.Drawing.Size(216, 16)
            Me.chkDontMixInboundWO.TabIndex = 100
            Me.chkDontMixInboundWO.Text = "Don't Mix Inbound Workorder"
            '
            'txtDevSN
            '
            Me.txtDevSN.Location = New System.Drawing.Point(8, 112)
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
            Me.Label10.Location = New System.Drawing.Point(8, 96)
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
            Me.btnCloseBox.Location = New System.Drawing.Point(192, 392)
            Me.btnCloseBox.Name = "btnCloseBox"
            Me.btnCloseBox.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnCloseBox.Size = New System.Drawing.Size(136, 32)
            Me.btnCloseBox.TabIndex = 2
            Me.btnCloseBox.Text = "CLOSE LOT"
            '
            'btnRemoveAllSNs
            '
            Me.btnRemoveAllSNs.BackColor = System.Drawing.Color.Red
            Me.btnRemoveAllSNs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveAllSNs.ForeColor = System.Drawing.Color.White
            Me.btnRemoveAllSNs.Location = New System.Drawing.Point(192, 248)
            Me.btnRemoveAllSNs.Name = "btnRemoveAllSNs"
            Me.btnRemoveAllSNs.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveAllSNs.Size = New System.Drawing.Size(128, 33)
            Me.btnRemoveAllSNs.TabIndex = 5
            Me.btnRemoveAllSNs.Text = "REMOVE ALL SNs"
            '
            'btnRemoveSN
            '
            Me.btnRemoveSN.BackColor = System.Drawing.Color.Red
            Me.btnRemoveSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveSN.ForeColor = System.Drawing.Color.White
            Me.btnRemoveSN.Location = New System.Drawing.Point(192, 192)
            Me.btnRemoveSN.Name = "btnRemoveSN"
            Me.btnRemoveSN.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveSN.Size = New System.Drawing.Size(128, 32)
            Me.btnRemoveSN.TabIndex = 4
            Me.btnRemoveSN.Text = "REMOVE SN"
            '
            'lblCount
            '
            Me.lblCount.BackColor = System.Drawing.Color.Black
            Me.lblCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCount.ForeColor = System.Drawing.Color.Lime
            Me.lblCount.Location = New System.Drawing.Point(192, 112)
            Me.lblCount.Name = "lblCount"
            Me.lblCount.Size = New System.Drawing.Size(128, 32)
            Me.lblCount.TabIndex = 97
            Me.lblCount.Text = "0"
            Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(192, 96)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(88, 16)
            Me.Label3.TabIndex = 96
            Me.Label3.Text = "Lot Count"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblLotName
            '
            Me.lblLotName.BackColor = System.Drawing.Color.Black
            Me.lblLotName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblLotName.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLotName.ForeColor = System.Drawing.Color.Lime
            Me.lblLotName.Location = New System.Drawing.Point(8, 5)
            Me.lblLotName.Name = "lblLotName"
            Me.lblLotName.Size = New System.Drawing.Size(320, 32)
            Me.lblLotName.TabIndex = 98
            Me.lblLotName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lstDevices
            '
            Me.lstDevices.Location = New System.Drawing.Point(8, 136)
            Me.lstDevices.Name = "lstDevices"
            Me.lstDevices.Size = New System.Drawing.Size(156, 290)
            Me.lstDevices.TabIndex = 1
            '
            'Panel2
            '
            Me.Panel2.BackColor = System.Drawing.Color.Black
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblBin, Me.lblLineSide, Me.lblMachine, Me.lblGroup, Me.lblLine, Me.lblShift, Me.lblWorkDate, Me.lblUserName})
            Me.Panel2.Location = New System.Drawing.Point(229, 1)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(571, 71)
            Me.Panel2.TabIndex = 121
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
            Me.lblScreenName.Location = New System.Drawing.Point(1, 1)
            Me.lblScreenName.Name = "lblScreenName"
            Me.lblScreenName.Size = New System.Drawing.Size(229, 70)
            Me.lblScreenName.TabIndex = 120
            Me.lblScreenName.Text = "BUILD SHIP LOT"
            Me.lblScreenName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'pnlCreateLot
            '
            Me.pnlCreateLot.BackColor = System.Drawing.Color.SteelBlue
            Me.pnlCreateLot.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlCreateLot.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboLotTypes, Me.Label4, Me.cboRepTypes, Me.Label2, Me.btnCreateBoxID})
            Me.pnlCreateLot.Enabled = False
            Me.pnlCreateLot.Location = New System.Drawing.Point(1, 224)
            Me.pnlCreateLot.Name = "pnlCreateLot"
            Me.pnlCreateLot.Size = New System.Drawing.Size(455, 104)
            Me.pnlCreateLot.TabIndex = 3
            '
            'cboLotTypes
            '
            Me.cboLotTypes.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboLotTypes.Caption = ""
            Me.cboLotTypes.CaptionHeight = 17
            Me.cboLotTypes.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboLotTypes.ColumnCaptionHeight = 17
            Me.cboLotTypes.ColumnFooterHeight = 17
            Me.cboLotTypes.ContentHeight = 15
            Me.cboLotTypes.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboLotTypes.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboLotTypes.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboLotTypes.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboLotTypes.EditorHeight = 15
            Me.cboLotTypes.Images.Add(CType(resources.GetObject("resource.Images5"), System.Drawing.Bitmap))
            Me.cboLotTypes.ItemHeight = 15
            Me.cboLotTypes.Location = New System.Drawing.Point(152, 40)
            Me.cboLotTypes.MatchEntryTimeout = CType(2000, Long)
            Me.cboLotTypes.MaxDropDownItems = CType(5, Short)
            Me.cboLotTypes.MaxLength = 32767
            Me.cboLotTypes.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboLotTypes.Name = "cboLotTypes"
            Me.cboLotTypes.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboLotTypes.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboLotTypes.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboLotTypes.Size = New System.Drawing.Size(192, 21)
            Me.cboLotTypes.TabIndex = 2
            Me.cboLotTypes.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(64, 41)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(80, 16)
            Me.Label4.TabIndex = 99
            Me.Label4.Text = "Lot Type:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboRepTypes
            '
            Me.cboRepTypes.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboRepTypes.Caption = ""
            Me.cboRepTypes.CaptionHeight = 17
            Me.cboRepTypes.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboRepTypes.ColumnCaptionHeight = 17
            Me.cboRepTypes.ColumnFooterHeight = 17
            Me.cboRepTypes.ContentHeight = 15
            Me.cboRepTypes.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboRepTypes.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboRepTypes.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboRepTypes.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboRepTypes.EditorHeight = 15
            Me.cboRepTypes.Images.Add(CType(resources.GetObject("resource.Images6"), System.Drawing.Bitmap))
            Me.cboRepTypes.ItemHeight = 15
            Me.cboRepTypes.Location = New System.Drawing.Point(152, 8)
            Me.cboRepTypes.MatchEntryTimeout = CType(2000, Long)
            Me.cboRepTypes.MaxDropDownItems = CType(5, Short)
            Me.cboRepTypes.MaxLength = 32767
            Me.cboRepTypes.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboRepTypes.Name = "cboRepTypes"
            Me.cboRepTypes.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboRepTypes.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboRepTypes.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboRepTypes.Size = New System.Drawing.Size(192, 21)
            Me.cboRepTypes.TabIndex = 1
            Me.cboRepTypes.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(64, 11)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(80, 16)
            Me.Label2.TabIndex = 97
            Me.Label2.Text = "Repair Type:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'frmBuildShipLot
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(808, 541)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlCreateLot, Me.PanelPalletList, Me.pnlShipType, Me.panelPallet, Me.Panel2, Me.lblScreenName})
            Me.Name = "frmBuildShipLot"
            Me.Text = "frmBuildShipLot"
            Me.PanelPalletList.ResumeLayout(False)
            CType(Me.dbgPallets, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlShipType.ResumeLayout(False)
            CType(Me.cboLocations, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboModels, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboProduct, System.ComponentModel.ISupportInitialize).EndInit()
            Me.panelPallet.ResumeLayout(False)
            Me.Panel2.ResumeLayout(False)
            Me.pnlCreateLot.ResumeLayout(False)
            CType(Me.cboLotTypes, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboRepTypes, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '***************************************************************************************
        Private Sub frmBuildShipLot_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable
            Dim objShip As PSS.Data.Production.Shipping

            Try
                'Populate product type
                dt = Generic.GetProducts(True)
                Misc.PopulateC1DropDownList(Me.cboProduct, dt, "Prod_Desc", "Prod_ID")
                Me.cboProduct.SelectedValue = 0

                'Populate Customer
                If _iMenuCustID > 0 Then
                    _strManifestFilePath = Me._objGP.ManifestBaseDir & _iMenuCustID & "\" & Me._objGP.ManifestFolderName & "\"

                    dt = Generic.GetCustomers(True, )
                    Misc.PopulateC1DropDownList(Me.cboCustomers, dt, "Cust_Name1", "Cust_ID")
                    Me.cboCustomers.SelectedValue = _iMenuCustID
                    Me.cboCustomers.Enabled = False

                    'Populate Location
                    Generic.DisposeDT(dt)
                    dt = Generic.GetLocations(True, Me.cboCustomers.SelectedValue)
                    Misc.PopulateC1DropDownList(Me.cboLocations, dt, "Loc_Name", "Loc_ID")
                    Me.cboLocations.Enabled = True
                    If dt.Rows.Count = 2 Then
                        Me.cboLocations.SelectedValue = dt.Rows(0)("Loc_ID")
                        Me.cboLocations.Enabled = False
                    End If
                End If

                'Populate Repair Type (lprojecttype)
                objShip = New PSS.Data.Production.Shipping()
                dt = objShip.GetProjectTypes(True)
                Misc.PopulateC1DropDownList(Me.cboRepTypes, dt, "pt_desc", "pt_id")
                Me.cboRepTypes.SelectedValue = 0

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "FormLoad", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                objShip = Nothing : Generic.DisposeDT(dt)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub cboProduct_cboCustomers_cboLocations_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProduct.Enter, cboCustomers.Enter, cboLocations.Enter
            Try
                Me.ClearPanelPallet()
                Me.dbgPallets.DataSource = Nothing
                Me.pnlCreateLot.Enabled = False : Me.btnCreateBoxID.Visible = False
                Me.cboRepTypes.SelectedValue = 0
                Me.chkMixModel.Checked = False : Me.chkMixModel.Enabled = True

                If sender.name = "cboProduct" Then
                    '********************************
                    'Reset Customer and Location
                    '********************************
                    If Me._iMenuCustID = 0 Then
                        If Not IsNothing(Me.cboCustomers.DataSource) Then
                            Me.cboCustomers.DataSource = Nothing
                            Me.cboCustomers.Text = ""
                        End If
                        If Not IsNothing(Me.cboLocations.DataSource) Then
                            Me.cboLocations.DataSource = Nothing
                            Me.cboLocations.Text = ""
                        End If
                    End If

                    '********************
                    'Reset Model
                    '********************
                    If Not IsNothing(Me.cboModels.DataSource) Then
                        Me.cboModels.DataSource = Nothing
                        Me.cboModels.Text = ""
                    End If

                    Me.cboProduct.SelectAll()
                ElseIf sender.name = "cboCustomers" Then
                    _strManifestFilePath = ""
                    '********************
                    'Reset Location
                    '********************
                    If Not IsNothing(Me.cboLocations.DataSource) Then
                        Me.cboLocations.DataSource = Nothing
                        Me.cboLocations.Text = ""
                    End If
                    '********************
                    Me.cboCustomers.SelectAll()
                ElseIf sender.name = "cboLocations" Then
                    Me.cboLocations.SelectAll()
                ElseIf sender.name = "cboRepTypes" Then
                    '********************
                    'Reset Box(Lot) Type
                    '********************
                    If Not IsNothing(Me.cboLotTypes.DataSource) Then
                        Me.cboLotTypes.DataSource = Nothing
                        Me.cboLotTypes.Text = ""
                    End If
                    '********************
                    Me.cboRepTypes.SelectAll()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cbo_EnterEvent", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub ClearPanelPallet()
            Try
                Me.txtDevSN.Text = ""
                Me.lblLotName.Text = ""
                Me.lblCount.Text = ""
                Me.lstDevices.DataSource = Nothing
                Me.lstDevices.Refresh()
                Me.panelPallet.Visible = False
                Me.chkDontMixInboundWO.Checked = False : Me.chkDontMixInboundWO.Enabled = True
                Me.lblInboundWO.Text = ""
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '***************************************************************************************
        Private Sub cboProduct_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboProduct.KeyUp
            Dim dt As DataTable

            Try
                If e.KeyCode = Keys.Enter Then
                    If Me.cboProduct.SelectedValue > 0 Then
                        If Me._iMenuCustID = 0 Then
                            '*******************************
                            'Load Customers list
                            '*******************************
                            dt = Generic.GetCustomers(True, Me.cboProduct.SelectedValue)
                            Misc.PopulateC1DropDownList(Me.cboCustomers, dt, "Cust_Name1", "Cust_ID")
                            Me.cboCustomers.SelectedValue = 0
                            '*******************************
                            Me.cboCustomers.SelectAll()
                            Me.cboCustomers.Focus()
                        Else
                            If Me.cboLocations.Enabled = False Then
                                Me.cboLocations.SelectAll()
                                Me.cboLocations.Focus()
                            End If
                        End If

                        '*******************************
                        'Load Model List
                        '*******************************
                        Me.chkMixModel.Enabled = True
                        Me.cboModels.Enabled = True
                        dt = Generic.GetModels(True, Me.cboProduct.SelectedValue)
                        Misc.PopulateC1DropDownList(Me.cboModels, dt, "Model_desc", "Model_id")
                        Me.cboModels.SelectedValue = 0
                        '*******************************
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboProdID_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub cboCustomers_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCustomers.KeyUp
            Dim dtLoc As DataTable

            Try
                If e.KeyCode = Keys.Enter Then
                    'Set Manifest file path
                    If Me.cboCustomers.SelectedValue > 0 Then _strManifestFilePath = Me._objGP.ManifestBaseDir & Me.cboCustomers.SelectedValue & "\" & Me._objGP.ManifestFolderName & "\"

                    If Me.cboCustomers.SelectedValue > 0 AndAlso Me.cboProduct.SelectedValue > 0 Then
                        dtLoc = Generic.GetLocations(True, Me.cboCustomers.SelectedValue)
                        Misc.PopulateC1DropDownList(Me.cboLocations, dtLoc, "Loc_Name", "Loc_ID")
                        Me.cboLocations.Enabled = True
                        If dtLoc.Rows.Count = 2 Then
                            Me.cboLocations.SelectedValue = dtLoc.Rows(0)("Loc_ID")
                            Me.cboLocations.Enabled = False
                            Me.chkMixModel.Focus()
                        Else
                            Me.cboLocations.SelectedValue = 0
                            Me.cboLocations.SelectAll()
                            Me.cboLocations.Focus()
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboCustomers_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dtLoc)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub cbotxt_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboLocations.KeyUp, cboModels.KeyUp, cboRepTypes.KeyUp, txtDevSN.KeyUp, cboLotTypes.KeyUp
            Dim dt As DataTable

            Try
                If e.KeyCode = Keys.Enter Then
                    If sender.name = "cboLocations" Then
                        If Me.cboProduct.SelectedValue = 0 Then
                            MessageBox.Show("Please select Product Type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.cboProduct.Focus()
                        ElseIf Me.cboLocations.SelectedValue > 0 Then
                            Me.chkMixModel.Focus()
                        End If
                    ElseIf sender.name = "cboModels" AndAlso Me.cboModels.SelectedValue > 0 Then
                        If Me.cboLocations.SelectedValue = 0 Then
                            MessageBox.Show("Please select Location.", sender.name & "_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.cboLocations.SelectAll()
                            Me.cboLocations.Focus()
                        Else
                            Me.PopulateOpenPallets()
                            Me.pnlCreateLot.Enabled = True
                            Me.cboRepTypes.SelectAll()
                            Me.cboRepTypes.Focus()
                        End If
                    ElseIf sender.name = "cboRepTypes" AndAlso Me.cboRepTypes.SelectedValue > 0 Then
                        Me.PopulateComboLotTypes()
                        Me.cboLotTypes.SelectAll()
                        Me.cboLotTypes.Focus()
                    ElseIf sender.name = "cboLotTypes" AndAlso Me.cboLotTypes.SelectedValue > 0 Then
                        If Me.cboLocations.SelectedValue > 0 AndAlso Me.cboLotTypes.SelectedValue > 0 AndAlso Me._objGP.GetOpenPalletCount(Me.cboLocations.SelectedValue, Me.cboLotTypes.SelectedValue, Me.cboModels.SelectedValue) = 0 Then Me.btnCreateBoxID.Visible = True
                    ElseIf sender.name = "txtDevSN" AndAlso Me.txtDevSN.Text.Trim.Length > 0 Then
                        Me.ProcessSN()
                    End If 'Controls name
                End If  'Enter Key pressed
            Catch ex As Exception
                MessageBox.Show(ex.ToString, sender.name & "_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub PopulateComboLotTypes()
            Dim dt As DataTable
            Dim objShip As PSS.Data.Production.Shipping

            Try
                Me.cboLotTypes.DataSource = Nothing
                Me.cboLotTypes.Text = ""
                objShip = New PSS.Data.Production.Shipping()
                dt = objShip.GetShipPalletTypes(True, Me.cboRepTypes.SelectedValue)
                Misc.PopulateC1DropDownList(Me.cboLotTypes, dt, "Pallettype_LDesc", "pallettype_id")

            Catch ex As Exception
                Throw ex
            Finally
                objShip = Nothing : Generic.DisposeDT(dt)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub chkMixModel_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkMixModel.CheckedChanged
            Dim dt As DataTable

            Try
                Me.cboRepTypes.SelectedValue = 0
                Me.dbgPallets.DataSource = Nothing
                Me.pnlCreateLot.Enabled = True
                Me.ClearPanelPallet()

                If Me.chkMixModel.Checked = True Then
                    Me.cboModels.SelectedValue = 0
                    Me.cboModels.Enabled = False

                    If Me.cboLocations.SelectedValue = 0 Then
                        MessageBox.Show("Please select Location.", "chkMixModel_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.cboLocations.SelectAll()
                        Me.cboLocations.Focus()
                    Else
                        dt = Me._objGP.GetOpenPallets(Me.cboLocations.SelectedValue)
                        Me.PopulateOpenPallets()
                        Me.pnlCreateLot.Enabled = True
                        Me.cboRepTypes.SelectAll()
                        Me.cboRepTypes.Focus()
                    End If
                Else
                    Me.cboModels.Enabled = True
                    Me.cboModels.SelectAll()
                    Me.cboModels.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "chkMixModel_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '***************************************************************************************
        Private Function PopulateOpenPallets(Optional ByVal iPalletID As Integer = 0) As Boolean
            Dim i As Integer
            Dim dt As DataTable

            Try
                dt = Me._objGP.GetOpenPallets(Me.cboLocations.SelectedValue)

                With Me.dbgPallets
                    _booPopulatePallet = True

                    .DataSource = Nothing
                    .DataSource = dt.DefaultView
                    .AlternatingRows = True

                    For i = 0 To dt.Columns.Count - 1
                        .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        .Splits(0).DisplayColumns(i).HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center

                        .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        .Splits(0).DisplayColumns(i).Style.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center

                        If dt.Columns(i).Caption = "Lot Name" Then
                            .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                            .Splits(0).DisplayColumns(i).Visible = True
                            .Splits(0).DisplayColumns(i).Width = 135
                        ElseIf dt.Columns(i).Caption = "Model" Then
                            .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                            .Splits(0).DisplayColumns(i).Visible = True
                            .Splits(0).DisplayColumns(i).Width = 150
                        ElseIf dt.Columns(i).Caption = "Workorder" Then
                            .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                            .Splits(0).DisplayColumns(i).Visible = True
                            .Splits(0).DisplayColumns(i).Width = 100
                        Else
                            .Splits(0).DisplayColumns(i).Visible = False
                        End If
                    Next i

                    '*******************************
                    'Select Pallet
                    '*******************************
                    If iPalletID > 0 Then
                        .MoveFirst()
                        For i = 0 To .RowCount - 1
                            If .Columns("Pallett_ID").CellValue(i) <> iPalletID Then
                                .MoveNext()
                            Else
                                _booPopulatePallet = False : Me.dbgPallets_RowColChange(Nothing, Nothing) : Exit For
                            End If
                        Next i
                    End If

                    '*******************************
                End With

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
                _booPopulatePallet = False
            End Try
        End Function

        '***************************************************************************************
        Private Sub dbgPallets_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles dbgPallets.RowColChange
            Dim dt As DataTable

            Try
                If Me._booPopulatePallet = True Then
                    Exit Sub
                Else
                    Me.ClearPanelPallet()

                    If Me.dbgPallets.RowCount > 0 Then

                        Me.Enabled = False
                        Cursor.Current = Cursors.WaitCursor

                        If CInt(Me.dbgPallets.Columns("Model_ID").CellValue(Me.dbgPallets.Row)) <> 0 Then Me.cboModels.SelectedValue = CInt(Me.dbgPallets.Columns("Model_ID").CellValue(Me.dbgPallets.Row))

                        Me.cboRepTypes.SelectedValue = Me.dbgPallets.Columns("pt_id").CellValue(Me.dbgPallets.Row)

                        Me.PopulateComboLotTypes()

                        Me.cboLotTypes.SelectedValue = Me.dbgPallets.Columns("PalletType_ID").CellValue(Me.dbgPallets.Row)

                        Me.lblInboundWO.Text = Me.dbgPallets.Columns("Workorder").CellValue(Me.dbgPallets.Row)

                        If CInt(Me.dbgPallets.Columns("WO_ID").CellValue(Me.dbgPallets.Row)) > 0 Then Me.chkDontMixInboundWO.Checked = True Else Me.chkDontMixInboundWO.Enabled = True

                        Me.RefreshSNList()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgPallets_RowColChange", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        '***************************************************************************************
        Private Sub RefreshSNList()
            Dim dt As DataTable
            Dim iPalletID As Integer = 0
            Dim strPalletName As String = ""
            Dim objMisc As PSS.Data.Buisness.Misc

            Try
                '************************
                'Validations
                iPalletID = CInt(Me.dbgPallets.Columns("Pallett_ID").Value.ToString)
                strPalletName = Me.dbgPallets.Columns("Lot Name").Value.ToString.Trim

                If iPalletID = 0 Then
                    Throw New Exception("Lot is not selected.")
                ElseIf strPalletName.Trim = "" Then
                    Throw New Exception("Lot is not selected.")
                End If

                '*******************************************
                'Get all devices add put them in them in list box for a pallet
                objMisc = New PSS.Data.Buisness.Misc()
                dt = objMisc.GetAllSNsForPallet(iPalletID)
                Me.lstDevices.DataSource = dt.DefaultView
                Me.lstDevices.ValueMember = dt.Columns("device_id").ToString
                Me.lstDevices.DisplayMember = dt.Columns("device_sn").ToString
                Me.lblLotName.Text = strPalletName
                Me.panelPallet.Visible = True
                If Me.lstDevices.Items.Count > 0 Then Me.chkDontMixInboundWO.Enabled = False Else Me.chkDontMixInboundWO.Enabled = True

                Me.Enabled = True : Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()

                '*******************************************
                Me.lblCount.Text = dt.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                objMisc = Nothing
                Generic.DisposeDT(dt)
                Me.txtDevSN.Focus()
            End Try
        End Sub

        '***************************************************************************************
        Private Sub btnCreateBoxID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateBoxID.Click
            Dim dt As DataTable
            Dim iPalletID As Integer = 0

            Try
                If Me.cboCustomers.SelectedValue = 0 Then
                    MessageBox.Show("Please select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboCustomers.SelectAll()
                    Me.cboCustomers.Focus()
                ElseIf Me.cboLocations.SelectedValue = 0 Then
                    MessageBox.Show("Please select location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboLocations.SelectAll()
                    Me.cboLocations.Focus()
                ElseIf Me.chkMixModel.Checked = False AndAlso Me.cboModels.SelectedValue = 0 Then
                    MessageBox.Show("Please select model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboModels.SelectAll()
                    Me.cboModels.Focus()
                ElseIf Me.cboRepTypes.SelectedValue = 0 Then
                    MessageBox.Show("Please select repair type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboRepTypes.SelectAll()
                    Me.cboRepTypes.Focus()
                ElseIf Me.cboLotTypes.SelectedValue = 0 Then
                    MessageBox.Show("Please select lot type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboLotTypes.SelectAll()
                    Me.cboLotTypes.Focus()
                Else
                    If Me._objGP.GetOpenPalletCount(Me.cboLocations.SelectedValue, Me.cboLotTypes.SelectedValue, Me.cboModels.SelectedValue) = 0 Then
                        Me.Enabled = False
                        Cursor.Current = Cursors.WaitCursor

                        iPalletID = Me._objGP.CreatePalletGP(Me.cboCustomers.SelectedValue, Me.cboLocations.SelectedValue, Me.cboModels.SelectedValue, Me.cboLotTypes.SelectedValue, Me.cboLotTypes.DataSource.Table.select("PalletType_ID = " & Me.cboLotTypes.SelectedValue)(0)("Pallettype_SDesc"), Me.cboLotTypes.DataSource.Table.select("PalletType_ID = " & Me.cboLotTypes.SelectedValue)(0)("BillRule_ID"))

                        If iPalletID = 0 Then
                            MessageBox.Show("System has failed to create lot.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If

                        Me.btnCreateBoxID.Visible = False
                        Me.ClearPanelPallet()
                        Me.PopulateOpenPallets(iPalletID)
                    End If
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '***************************************************************************************
        Private Function ProcessSN() As Boolean
            Dim i As Integer = 0
            Dim strSN As String = Me.txtDevSN.Text.Trim.ToUpper
            Dim dtDevice As DataTable
            Dim booRefreshPalletList As Boolean = False
            Dim objQC As New PSS.Data.Buisness.QC()


            Try
                '************************
                'Validations
                If strSN.Length = 0 Then
                    Exit Function
                ElseIf CInt(Me.dbgPallets.Columns("Pallett_ID").Value) = 0 Then
                    MessageBox.Show("Lot Name is not selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtDevSN.SelectAll()
                    Me.txtDevSN.Focus()
                ElseIf Me.dbgPallets.Columns("Lot Name").Value.ToString.Trim = "" Then
                    MessageBox.Show("Lot Name is not selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtDevSN.SelectAll()
                    Me.txtDevSN.Focus()
                ElseIf Me.lstDevices.DataSource.table.select("device_sn = '" & strSN.Trim & "'").length > 0 Then
                    '***************************************************
                    'Check if the Device is already scanned in
                    '***************************************************
                    MessageBox.Show("This device is already listed. Try another one.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtDevSN.Text = ""
                    Me.txtDevSN.Focus()
                ElseIf Generic.IsPalletClosed(CInt(Me.dbgPallets.Columns("Pallett_ID").Value)) = True Then
                    '***************************************************
                    'Added by Lan on 09/16/2007
                    'Prevent the user from adding more devices to closed pallet.
                    'This happen when a pallet open at the 2 computer, computer 1 
                    '  close the pallet and refesh the screen while the other computer screen 
                    '  did not get refresh. This check will force the user to refresh the screen.
                    '***************************************************
                    MessageBox.Show("Lot had been closed by another machine. Please refresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtDevSN.Text = ""
                    Me.txtDevSN.Focus()

                ElseIf Me.cboProduct.SelectedValue = 18 And objQC.IsAQLPassed(Me.txtDevSN.Text) = False Then
                    '***************************************************
                    'Check if the Device pass AQL Station for Plastronics Socket Company
                    '***************************************************
                    MessageBox.Show("This device has not passed AQL station.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtDevSN.Text = ""
                    Me.txtDevSN.Focus()
                Else
                    i = 0

                    dtDevice = Generic.GetDeviceInfoInWIP(Me.txtDevSN.Text.Trim, CInt(Me.dbgPallets.Columns("Cust_ID").Value))

                    If dtDevice.Rows.Count > 1 Then
                        MessageBox.Show("This device existed twice in the system. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtDevSN.SelectAll()
                    ElseIf dtDevice.Rows.Count = 0 Then
                        MessageBox.Show("This device does not exist in the system, already ship or belongs to a different customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtDevSN.SelectAll()
                    ElseIf Not IsDBNull(dtDevice.Rows(0)("Pallett_ID")) Then
                        MessageBox.Show("This device has assigned to Lot ID (" & dtDevice.Rows(0)("Pallett_ID") & ").", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtDevSN.Text = ""
                    ElseIf Me.dbgPallets.Columns("Model_ID").Value > 0 AndAlso dtDevice.Rows(0)("Model_ID") <> CInt(Me.dbgPallets.Columns("Model_ID").Value) Then
                        MessageBox.Show("This device is of a different model. Can't put into this lot.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtDevSN.Text = ""
                    ElseIf Me.cboProduct.SelectedValue <> 18 And IsDBNull(dtDevice.Rows(0)("Device_DateBill")) Then
                        MessageBox.Show("This device has not been billed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtDevSN.Text = ""
                    ElseIf Me.cboProduct.SelectedValue <> 18 And Me.dbgPallets.Columns("BillRule_ID").Value <> Generic.GetMaxBillRule(dtDevice.Rows(0)("Device_ID")) Then
                        MessageBox.Show("Bill rule of device and lot type does not match. Please verify device's billing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtDevSN.Text = ""
                        'ElseIf Me._objSkytel.CheckDeviceShipType(CInt(Me.dbgPallets.Columns("Pallet_ShipType").Value), dtDevice.Rows(0)("Device_ID")) = False Then
                        '    Me.txtDevSN.SelectAll()
                    ElseIf CInt(Me.dbgPallets.Columns("NoPartAllow").Value) = 1 AndAlso Generic.IsDeviceHadParts(dtDevice.Rows(0)("Device_ID")) = True Then
                        MessageBox.Show("This lot type does not allow unit with part.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtDevSN.Text = ""
                    ElseIf CInt(Me.dbgPallets.Columns("WO_ID").Value) > 0 AndAlso Me.dbgPallets.Columns("WO_ID").Value.ToString.Equals(dtDevice.Rows(0)("WO_ID").ToString) = False Then
                        MessageBox.Show("Device does not belong to RMA '" & Me.lblInboundWO.Text & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                        'ElseIf CInt(Me.dbgPallets.Columns("Pallet_ShipType").Value) = 0 AndAlso Generic.IsValidQCResults(dtDevice.Rows(0)("Device_ID"), 1, "Functional", False) = False Then    'must Final passed
                        '    Me.txtDevSN.Text = ""
                    Else
                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                        If Me.chkDontMixInboundWO.Checked = True AndAlso Me.lstDevices.Items.Count = 0 Then
                            Me.chkDontMixInboundWO.Enabled = False
                            i = Me._objGP.AttachedPalletToWO(CInt(Me.dbgPallets.Columns("Pallett_ID").Value), CInt(dtDevice.Rows(0)("WO_ID")))
                            If i = 0 Then
                                MessageBox.Show("System has failed to set workorder for selected lot.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.Enabled = True : Cursor.Current = Cursors.Default
                                Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus() : Exit Function
                            Else
                                booRefreshPalletList = True
                            End If
                        End If

                        '***************************************************
                        'if above all is fine then add it to the list and update the database
                        i = PSS.Data.Production.Shipping.AssignDeviceToPallet(dtDevice.Rows(0)("Device_ID"), CInt(Me.dbgPallets.Columns("Pallett_ID").Value))

                        '***************************************************
                        If booRefreshPalletList = True Then
                            Me.PopulateOpenPallets(CInt(Me.dbgPallets.Columns("Pallett_ID").Value))
                        Else
                            Me.RefreshSNList()
                        End If

                        Me.Enabled = True : Cursor.Current = Cursors.Default
                        Me.txtDevSN.Text = "" : Me.txtDevSN.Focus()
                        '***************************************************
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("ProcessSN: " & ex.Message, "Device Scan", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.txtDevSN.Text = ""
                Me.txtDevSN.Focus()
            Finally
                Generic.DisposeDT(dtDevice)
                objQC = Nothing
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Function

        '***************************************************************************************
        Private Sub btnCloseBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseBox.Click
            Dim i As Integer = 0
            Dim objDevice As Rules.Device
            Dim deviceid As Integer
            Const iSocketProdPassBillcodeID As Integer = 2141

            Try
                '************************
                'Validations
                If Me.dbgPallets.RowCount = 0 Then
                    Exit Sub
                ElseIf CInt(Me.dbgPallets.Columns("Pallett_id").Value) = 0 Then
                    MessageBox.Show("Lot name is not selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtDevSN.Text = ""
                    Me.txtDevSN.Focus()
                ElseIf Me.dbgPallets.Columns("Lot Name").Value.ToString.Trim = "" Then
                    MessageBox.Show("Lot name is not selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtDevSN.Text = ""
                    Me.txtDevSN.Focus()
                ElseIf Me.lstDevices.Items.Count = 0 Then
                    MessageBox.Show("Lot is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtDevSN.Text = ""
                    Me.txtDevSN.Focus()
                ElseIf Me.cboCustomers.SelectedValue = 0 Then
                    MessageBox.Show("Select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboCustomers.SelectAll()
                    Me.cboCustomers.Focus()
                ElseIf Me._strManifestFilePath.Trim.Length = 0 Then
                    MessageBox.Show("Manifest file location is missing. Please select customer again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboCustomers.SelectAll()
                    Me.cboCustomers.Focus()
                ElseIf MessageBox.Show("Are you sure you want to close this lot (" & Me.dbgPallets.Columns("Lot Name").Value & ")?", "Close Lot", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Me.txtDevSN.Text = ""
                    Me.txtDevSN.Focus()
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                    '*****************************************************
                    'PLASTRONIC ONLY
                    '*****************************************************
                    If Me.cboProduct.SelectedValue = 18 Then
                        If Generic.IsBillcodeMapped(Me.cboModels.SelectedValue, iSocketProdPassBillcodeID) = 0 Then
                            MessageBox.Show("This model hasn't mapped to the bill code ""Pass"". Please contact Material department.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        End If
                        'Bill Pass service
                        For i = 0 To Me.lstDevices.Items.Count - 1
                            deviceid = CType(CType(CType(Me.lstDevices.Items(i), Object), System.Data.DataRowView).Row, System.Data.DataRow).ItemArray(0)
                            If Generic.IsBillcodeExisted(deviceid, iSocketProdPassBillcodeID) = False Then
                                objDevice = New Rules.Device(deviceid)
                                objDevice.AddPart(iSocketProdPassBillcodeID)
                                objDevice.Update()
                                If Not IsNothing(objDevice) Then
                                    objDevice.Dispose() : objDevice = Nothing
                                End If
                            End If
                        Next i
                    End If

                    '*****************************************************

                    Me.cboLotTypes.SelectedValue = CInt(Me.dbgPallets.Columns("PalletType_ID").Value)

                    'Do not create Manifest for PLASTRONIC Socket per Angel requested.
                    If Me.cboProduct.SelectedValue <> 18 Then
                        i = Me._objGP.CreateManifest(CInt(Me.dbgPallets.Columns("Pallett_ID").Value), Me._strManifestFilePath, 0)
                    End If

                    '************************ BEGIN AQL LOT ***********************************
                    ' AQL Lot for Round2 customer only for now ....
                    ' This block must excuted before the Me._objGP.ClosePalletGP statement.
                    ' This will assign AQL_Lot_ID in tPallett table before
                    ' ClosePalletGP() event, which eventually will print 4x4 label with AQL_Lot_Name.
                    If Me.cboCustomers.SelectedValue = 2371 Then
                        Const maxAQLQty As Integer = 240 ' Max quantity allow per AQL Lot
                        Dim AQL_Lot_ID As Integer = 0
                        Dim AQLQty As Integer = 0

                        AQL_Lot_ID = Me._objGP.AQL_GetOpenLotID(Me.cboCustomers.SelectedValue)
                        If AQL_Lot_ID > 0 Then

                            AQLQty = Me._objGP.AQL_GetQty(AQL_Lot_ID) + Me.lstDevices.Items.Count

                            If AQLQty <= maxAQLQty Then
                                'Update existing AQL Lot quantity and assign tPallette.AQL_Lot_ID
                                Me._objGP.AQL_UpdateQty(AQL_Lot_ID, AQLQty)
                                Me._objGP.AQL_AssignLotID(CInt(Me.dbgPallets.Columns("Pallett_ID").Value), AQL_Lot_ID)
                            Else
                                'Close existing and create new AQL_Lot
                                Me._objGP.AQL_CloseLot(AQL_Lot_ID)
                                AQL_Lot_ID = Me._objGP.AQL_CreateLot(Me.cboCustomers.SelectedValue, Me.lstDevices.Items.Count)
                                Me._objGP.AQL_AssignLotID(CInt(Me.dbgPallets.Columns("Pallett_ID").Value), AQL_Lot_ID)
                            End If

                        Else
                            AQL_Lot_ID = Me._objGP.AQL_CreateLot(Me.cboCustomers.SelectedValue, Me.lstDevices.Items.Count)
                            Me._objGP.AQL_AssignLotID(CInt(Me.dbgPallets.Columns("Pallett_ID").Value), AQL_Lot_ID)
                            'Force to close the last AQL_Lot from previous date
                            Me._objGP.AQL_CloseLot(AQL_Lot_ID - 1)
                        End If

                    End If
                    '************************* END AQL LOT ***********************************

                    i = Me._objGP.ClosePalletGP(CInt(Me.dbgPallets.Columns("Pallett_ID").Value), Me.dbgPallets.Columns("Lot Name").Value, Me.dbgPallets.Columns("Model_ID").Value, Me.dbgPallets.Columns("Pallettype_LDesc").Value, Me.lstDevices.Items.Count, Me.cboProduct.SelectedValue, Me.cboCustomers.Text)

                    '************************
                    If i > 0 Then


                        'Refresh Pallet (Box) 
                        Me.PopulateOpenPallets()

                        '******************************
                        'Reset Screen control properties.
                        '******************************
                        Me.ClearPanelPallet()
                        Me.cboLotTypes.SelectAll()
                        Me.cboLotTypes.Focus()
                        '******************************
                    Else
                        MessageBox.Show("System has failed to close lot.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                    '******************************
                    End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnCloseLot_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        '***************************************************************************************
        Private Sub btnRemoveSN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveSN.Click
            Dim strSN As String = ""
            Dim i As Integer = 0
            Dim iDeviceID As Integer = 0

            Try
                '************************
                'Validations
                If Me.lstDevices.Items.Count = 0 Or Me.dbgPallets.RowCount = 0 Then
                    Exit Sub
                ElseIf CInt(Me.dbgPallets.Columns("Pallett_id").Value) = 0 Then
                    MessageBox.Show("Lot name is not selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    '************************
                    strSN = InputBox("Enter S/N:", "S/N").Trim
                    If strSN = "" Then
                        MessageBox.Show("Please enter a S/N if you want to remove it from the selected lot.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Me.lstDevices.DataSource.Table.select("Device_SN = '" & strSN & "'").length = 0 Then
                        MessageBox.Show("S/N was not listed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        iDeviceID = Me.lstDevices.DataSource.Table.select("Device_SN = '" & strSN & "'")(0)("Device_ID")
                        If iDeviceID > 0 Then
                            Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                            i = PSS.Data.Production.Shipping.RemoveSNfromPallet(CInt(Me.dbgPallets.Columns("Pallett_id").Value), iDeviceID)
                            If i = 0 Then
                                MessageBox.Show("System has failed to remove S/N from lot.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Else
                                If Me.chkDontMixInboundWO.Checked = True AndAlso Me.lstDevices.Items.Count = 1 Then
                                    Me._objGP.ReleasePalletFromWO(CInt(Me.dbgPallets.Columns("Pallett_id").Value))
                                    Me.PopulateOpenPallets(CInt(Me.dbgPallets.Columns("Pallett_id").Value))
                                Else
                                    Me.RefreshSNList()
                                End If
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Clear S/N", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                Me.txtDevSN.Text = "" : Me.txtDevSN.Focus()
            End Try
        End Sub

        '***************************************************************************************
        Private Sub btnRemoveAllSNs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAllSNs.Click
            Dim str_sn As String = ""
            Dim i As Integer = 0

            Try
                '************************
                'Validations
                '************************
                If Me.lstDevices.Items.Count = 0 Or Me.dbgPallets.RowCount = 0 Then
                    Exit Sub
                ElseIf CInt(Me.dbgPallets.Columns("Pallett_id").Value) = 0 Then
                    MessageBox.Show("Lot name is not selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf MessageBox.Show("Are you sure you want to remove all devices from this Box (" & Me.dbgPallets.Columns("Lot Name").Value & ")?", "Clear All S/Ns", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Exit Sub
                Else
                    '************************
                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor

                    i = PSS.Data.Production.Shipping.RemoveSNfromPallet(CInt(Me.dbgPallets.Columns("Pallett_id").Value), )
                    If i = 0 Then
                        MessageBox.Show("System has failed to remove S/Ns from lot.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        If Me.chkDontMixInboundWO.Checked = True Then
                            Me._objGP.ReleasePalletFromWO(CInt(Me.dbgPallets.Columns("Pallett_id").Value))
                            Me.PopulateOpenPallets(CInt(Me.dbgPallets.Columns("Pallett_id").Value))
                        Else
                            Me.RefreshSNList()
                        End If
                    End If
                    '************************
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Clear All SNs", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                Me.txtDevSN.Text = ""
                Me.txtDevSN.Focus()
            End Try
        End Sub

        '***************************************************************************************
        Private Sub btnReopenLot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReopenLot.Click
            Dim strPallet As String = ""
            Dim i As Integer = 0
            Dim dt As DataTable
            Dim R1 As DataRow

            Try
                '************************
                If Me.cboCustomers.SelectedValue = 0 Then
                    MessageBox.Show("Please select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.cboCustomers.SelectAll()
                    Me.cboCustomers.Focus()
                ElseIf IsNothing(Me.cboLocations.SelectedValue) = True Then
                    MessageBox.Show("Please select customer and press enter.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.cboCustomers.SelectAll()
                    Me.cboCustomers.Focus()
                Else
                    strPallet = InputBox("Enter Lot Number.", "Reopen Lot")
                    If strPallet = "" Then
                        MessageBox.Show("Please enter lot number to re-open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.cboLotTypes.SelectAll()
                        Me.cboLotTypes.Focus()
                    Else
                        Me.Enabled = False

                        dt = PSS.Data.Production.Shipping.GetPalletInfoByName(strPallet, Me.cboCustomers.SelectedValue)
                        If dt.Rows.Count = 0 Then
                            MessageBox.Show("Lot does not exist in the system for selected customer or has been removed from the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        ElseIf dt.Rows.Count > 1 AndAlso Me.cboLocations.SelectedValue = 0 Then
                            MessageBox.Show("Lot name existed more than one in the system for selected customer. Please select location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.cboCustomers.SelectAll()
                            Me.cboCustomers.Focus()
                        ElseIf dt.Rows.Count > 1 AndAlso Me.cboLocations.SelectedValue > 0 AndAlso dt.Select("Loc_ID = " & Me.cboLocations.SelectedValue).Length > 1 Then
                            MessageBox.Show("Lot name existed more than one in the system for selected location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            '*************************
                            'Get Pallett Information
                            '*************************
                            If dt.Rows.Count = 1 Then
                                R1 = dt.Rows(0)
                            ElseIf dt.Rows.Count > 1 AndAlso dt.Select("Cust_ID = " & Me.cboCustomers.SelectedValue).Length = 1 Then
                                R1 = dt.Select("Cust_ID = " & Me.cboCustomers.SelectedValue)(0)
                            ElseIf dt.Rows.Count > 1 AndAlso dt.Select("Cust_ID = " & Me.cboCustomers.SelectedValue & " AND Loc_ID = " & Me.cboLocations.SelectedValue).Length = 1 Then
                                R1 = dt.Select("Cust_ID = " & Me.cboCustomers.SelectedValue & " AND Loc_ID = " & Me.cboLocations.SelectedValue)(0)
                            Else
                                MessageBox.Show("Unable to define lot.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Exit Sub
                            End If

                            '*************************

                            If Not IsDBNull(R1("Pallett_ShipDate")) Then
                                MessageBox.Show("Lot has been shipped. Not allow to re-open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            ElseIf R1("Pallet_Invalid") = 1 Then
                                MessageBox.Show("This lot has been deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            ElseIf R1("Pallett_ReadyToShipFlg") = 0 Then
                                MessageBox.Show("Lot is already open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Else
                                Cursor.Current = Cursors.WaitCursor

                                i = PSS.Data.Production.Shipping.ReopenPallet(R1("Pallett_ID"))
                                If i = 0 Then
                                    MessageBox.Show("System has failed to re-open the lot.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Else

                                    'Recalulate AQL Lot quantity and unmarried tpallet and AQL_Lot; Round2 only
                                    If Me.cboCustomers.SelectedValue = 2371 Then 'Round2 Cust_ID=2371
                                        Dim iPallett_QTY As Integer = CInt(R1("Pallett_QTY"))
                                        Dim iAQL_Lot_ID As Integer = CInt(R1("AQL_Lot_ID"))
                                        Dim iAQL_QTY As Integer = Me._objGP.AQL_GetQty(iAQL_Lot_ID)

                                        Me._objGP.AQL_AssignLotID(CInt(R1("Pallett_ID")), 0)
                                        Me._objGP.AQL_UpdateQty(iAQL_Lot_ID, iAQL_QTY - iPallett_QTY)

                                    End If

                                    Me.ClearPanelPallet()

                                    'Refresh Pallet( Box )
                                    Me.PopulateOpenPallets(dt.Rows(0)("Pallett_ID"))

                                    Me.cboModels.SelectedValue = R1("Model_ID")

                                    If Not IsDBNull(R1("pt_id")) Then
                                        Me.cboRepTypes.SelectedValue = R1("pt_id")
                                        Me.PopulateComboLotTypes()

                                        Me.cboLotTypes.SelectedValue = R1("Pallettype_ID")
                                    End If
                                End If 'Re-Open status 
                            End If  'validate pallet information
                        End If  'duplicate record of pallet
                    End If  'Empty input
                End If 'Customer & Location selected value
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Reopen Box", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub btnDeleteLot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteLot.Click
            Dim i As Integer = 0

            Try
                If Me.dbgPallets.RowCount = 0 Or CInt(Me.dbgPallets.Columns("Pallett_ID").Value) = 0 Then
                    Exit Sub
                ElseIf MessageBox.Show("Are you sure you want to delete lot " & Me.dbgPallets.Columns("Lot Name").Value & ")?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Exit Sub
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                    i = PSS.Data.Production.Shipping.DeleteEmptyPallet(CInt(Me.dbgPallets.Columns("Pallett_ID").Value), PSS.Core.ApplicationUser.IDuser)
                    If i > 0 Then
                        MessageBox.Show("This lot has been deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("System has failed to delete lot.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If

                    Me.ClearPanelPallet()
                    Me.PopulateOpenPallets()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnDeleteLot_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        '***************************************************************************************
        Private Sub btnReprintLotLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintLotLabel.Click
            Dim str_pallett, strPalletType As String
            Dim dt As DataTable
            Dim iPalletQty, iProdID As Integer
            Dim R1 As DataRow
            Dim objMisc As PSS.Data.Buisness.Misc

            Try
                str_pallett = InputBox("Enter Lot Name.", "Reprint Lot Label")
                If str_pallett = "" Then
                    Throw New Exception("Please enter a Lot Name if you want to reprint the lot label.")
                End If

                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                iPalletQty = 0 : iProdID = 0

                objMisc = New PSS.Data.Buisness.Misc()
                dt = objMisc.GetPalletInfo_ByPallettName(str_pallett)
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Lot Name was not defined in system.", "Reprint Lot Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf dt.Rows.Count > 1 Then
                    MessageBox.Show("Lot Name existed more than one in the system.", "Reprint Lot Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf dt.Rows(0)("Pallett_ReadyToShipFlg") = 0 Then
                    MessageBox.Show("Lot is still open.", "Information", MessageBoxButtons.OK)
                Else
                    R1 = dt.Rows(0)
                    If Not IsDBNull(R1("Pallett_QTY")) Then iPalletQty = R1("Pallett_QTY")

                    If R1("Model_ID").ToString.Trim.Length > 0 Then iProdID = Me._objGP.GetProdID(R1("Model_ID").ToString)

                    If iProdID = 14 Then
                        Const strReportName As String = "C:\Label\4x4GenericShipBoxLabel.rpt"
                        PSS.Data.Production.Shipping.Print4x4GenericShipBoxLabel(R1("Pallett_ID"), strReportName, 1)
                        'PSS.Data.Production.Shipping.PrintPalletLicensePlate(R1("Pallett_Name"), R1("Model_ID"), strPalletType, iPalletQty, 3)
                    ElseIf iProdID = 18 Then 'Plastronics Socket Company
                        Dim strCustomerName As String = PSS.Data.Buisness.Generic.GetCustomerName(R1("Cust_ID"))
                        'Angel said leave Pallet Type blank
                        'PSS.Data.Production.Shipping.PrintCustomerPallet(strCustomerName, R1("Pallett_Name"), R1("Model_ID"), strPalletType, iPalletQty, 3)
                        PSS.Data.Production.Shipping.PrintCustomerPallet(strCustomerName, R1("Pallett_Name"), R1("Model_ID"), "", iPalletQty, 3)
                    Else
                        PSS.Data.Production.Shipping.PrintPalletLicensePlate(R1("Pallett_Name"), R1("Model_ID"), strPalletType, iPalletQty, 3)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Reprint Lot Label.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                objMisc = Nothing : R1 = Nothing : Generic.DisposeDT(dt)
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '***************************************************************************************

    End Class
End Namespace