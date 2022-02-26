Option Explicit On 

Imports PSS.Data.Buisness

Public Class frmSkyTelBuildShipBox
    Inherits System.Windows.Forms.Form

    Private _objSkytel As SkyTel
    Private _iMachineCC_GrpID As Integer = 0
    Private _iMenuCustID As Integer = 0
    Private _iLocID As Integer = 0
    Private _strTabPageTitle As String
    Private _strScreenName As String = "Build Ship Box"
    Private _bShowMoreSPQtyControls As Boolean = False ' True for debug 
    Private _bOtherCustomers As Boolean = False

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
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblSPQty_Available As System.Windows.Forms.Label
    Friend WithEvents pnlSpecialQty1 As System.Windows.Forms.Panel
    Friend WithEvents cboBaud As C1.Win.C1List.C1Combo
    Friend WithEvents pnlSpecialQty2 As System.Windows.Forms.Panel
    Friend WithEvents lblBaud As System.Windows.Forms.Label
    Friend WithEvents lblBaudID As System.Windows.Forms.Label
    Friend WithEvents dbgSPQty As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnChangeSP2RG As System.Windows.Forms.Button
    Friend WithEvents lblLocID As System.Windows.Forms.Label
    Friend WithEvents lblLocName As System.Windows.Forms.Label
    Friend WithEvents pnlLoc As System.Windows.Forms.Panel
    Friend WithEvents labelLoc As System.Windows.Forms.Label
    Friend WithEvents cboLocation As C1.Win.C1List.C1Combo
    Friend WithEvents dbgCountByModel As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents lblCustomer As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSkyTelBuildShipBox))
        Me.btnReprintBoxLabel = New System.Windows.Forms.Button()
        Me.PanelPalletList = New System.Windows.Forms.Panel()
        Me.btnChangeSP2RG = New System.Windows.Forms.Button()
        Me.btnRecreateManifest = New System.Windows.Forms.Button()
        Me.btnDeleteBox = New System.Windows.Forms.Button()
        Me.dbgPallets = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnReopenBox = New System.Windows.Forms.Button()
        Me.pnlShipType = New System.Windows.Forms.Panel()
        Me.pnlLoc = New System.Windows.Forms.Panel()
        Me.cboLocation = New C1.Win.C1List.C1Combo()
        Me.labelLoc = New System.Windows.Forms.Label()
        Me.pnlSpecialQty1 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboBaud = New C1.Win.C1List.C1Combo()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboFreqs = New C1.Win.C1List.C1Combo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboBoxTypes = New C1.Win.C1List.C1Combo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboModels = New C1.Win.C1List.C1Combo()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.btnCreateBoxID = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCustomer = New System.Windows.Forms.Label()
        Me.panelPallet = New System.Windows.Forms.Panel()
        Me.dbgCountByModel = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.lblLocID = New System.Windows.Forms.Label()
        Me.lblLocName = New System.Windows.Forms.Label()
        Me.dbgSPQty = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.lblBaudID = New System.Windows.Forms.Label()
        Me.lblBaud = New System.Windows.Forms.Label()
        Me.pnlSpecialQty2 = New System.Windows.Forms.Panel()
        Me.lblSPQty_Available = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
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
        Me.pnlLoc.SuspendLayout()
        CType(Me.cboLocation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSpecialQty1.SuspendLayout()
        CType(Me.cboBaud, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboFreqs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboBoxTypes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboModels, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelPallet.SuspendLayout()
        CType(Me.dbgCountByModel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dbgSPQty, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSpecialQty2.SuspendLayout()
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
        Me.btnReprintBoxLabel.Size = New System.Drawing.Size(272, 24)
        Me.btnReprintBoxLabel.TabIndex = 3
        Me.btnReprintBoxLabel.Text = "REPRINT BOX LABEL"
        '
        'PanelPalletList
        '
        Me.PanelPalletList.BackColor = System.Drawing.Color.SteelBlue
        Me.PanelPalletList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelPalletList.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnChangeSP2RG, Me.btnRecreateManifest, Me.btnDeleteBox, Me.dbgPallets, Me.btnReopenBox, Me.btnReprintBoxLabel})
        Me.PanelPalletList.Location = New System.Drawing.Point(1, 256)
        Me.PanelPalletList.Name = "PanelPalletList"
        Me.PanelPalletList.Size = New System.Drawing.Size(343, 248)
        Me.PanelPalletList.TabIndex = 1
        '
        'btnChangeSP2RG
        '
        Me.btnChangeSP2RG.BackColor = System.Drawing.Color.Red
        Me.btnChangeSP2RG.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChangeSP2RG.ForeColor = System.Drawing.Color.White
        Me.btnChangeSP2RG.Location = New System.Drawing.Point(24, 160)
        Me.btnChangeSP2RG.Name = "btnChangeSP2RG"
        Me.btnChangeSP2RG.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnChangeSP2RG.Size = New System.Drawing.Size(272, 24)
        Me.btnChangeSP2RG.TabIndex = 5
        Me.btnChangeSP2RG.Text = "Change Produced Sp Box to Regular Box"
        '
        'btnRecreateManifest
        '
        Me.btnRecreateManifest.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnRecreateManifest.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRecreateManifest.ForeColor = System.Drawing.Color.Black
        Me.btnRecreateManifest.Location = New System.Drawing.Point(24, 208)
        Me.btnRecreateManifest.Name = "btnRecreateManifest"
        Me.btnRecreateManifest.Size = New System.Drawing.Size(272, 24)
        Me.btnRecreateManifest.TabIndex = 4
        Me.btnRecreateManifest.Text = "Re-Create Excel Manifest"
        '
        'btnDeleteBox
        '
        Me.btnDeleteBox.BackColor = System.Drawing.Color.Red
        Me.btnDeleteBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteBox.ForeColor = System.Drawing.Color.White
        Me.btnDeleteBox.Location = New System.Drawing.Point(152, 136)
        Me.btnDeleteBox.Name = "btnDeleteBox"
        Me.btnDeleteBox.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnDeleteBox.Size = New System.Drawing.Size(144, 24)
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
        Me.dbgPallets.Location = New System.Drawing.Point(8, 8)
        Me.dbgPallets.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.dbgPallets.Name = "dbgPallets"
        Me.dbgPallets.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgPallets.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgPallets.PreviewInfo.ZoomFactor = 75
        Me.dbgPallets.RowHeight = 20
        Me.dbgPallets.Size = New System.Drawing.Size(328, 119)
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
        "arent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 324, 115</ClientRect><BorderSide>" & _
        "0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView><" & _
        "/Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""H" & _
        "eading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Capt" & _
        "ion"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Select" & _
        "ed"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightR" & _
        "ow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /" & _
        "><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""Filter" & _
        "Bar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSpl" & _
        "its><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</Defau" & _
        "ltRecSelWidth><ClientArea>0, 0, 324, 115</ClientArea><PrintPageHeaderStyle paren" & _
        "t="""" me=""Style16"" /><PrintPageFooterStyle parent="""" me=""Style17"" /></Blob>"
        '
        'btnReopenBox
        '
        Me.btnReopenBox.BackColor = System.Drawing.Color.Red
        Me.btnReopenBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReopenBox.ForeColor = System.Drawing.Color.White
        Me.btnReopenBox.Location = New System.Drawing.Point(24, 136)
        Me.btnReopenBox.Name = "btnReopenBox"
        Me.btnReopenBox.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnReopenBox.Size = New System.Drawing.Size(112, 24)
        Me.btnReopenBox.TabIndex = 1
        Me.btnReopenBox.Text = "REOPEN  BOX"
        '
        'pnlShipType
        '
        Me.pnlShipType.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlShipType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlShipType.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlLoc, Me.pnlSpecialQty1, Me.cboFreqs, Me.Label4, Me.cboBoxTypes, Me.Label2, Me.cboModels, Me.Button5, Me.btnCreateBoxID, Me.Label1, Me.lblCustomer})
        Me.pnlShipType.Location = New System.Drawing.Point(1, 72)
        Me.pnlShipType.Name = "pnlShipType"
        Me.pnlShipType.Size = New System.Drawing.Size(343, 184)
        Me.pnlShipType.TabIndex = 0
        '
        'pnlLoc
        '
        Me.pnlLoc.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboLocation, Me.labelLoc})
        Me.pnlLoc.Location = New System.Drawing.Point(0, 72)
        Me.pnlLoc.Name = "pnlLoc"
        Me.pnlLoc.Size = New System.Drawing.Size(296, 32)
        Me.pnlLoc.TabIndex = 91
        '
        'cboLocation
        '
        Me.cboLocation.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboLocation.Caption = ""
        Me.cboLocation.CaptionHeight = 17
        Me.cboLocation.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboLocation.ColumnCaptionHeight = 17
        Me.cboLocation.ColumnFooterHeight = 17
        Me.cboLocation.ContentHeight = 15
        Me.cboLocation.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboLocation.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboLocation.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLocation.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboLocation.EditorHeight = 15
        Me.cboLocation.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
        Me.cboLocation.ItemHeight = 15
        Me.cboLocation.Location = New System.Drawing.Point(73, 7)
        Me.cboLocation.MatchEntryTimeout = CType(2000, Long)
        Me.cboLocation.MaxDropDownItems = CType(5, Short)
        Me.cboLocation.MaxLength = 32767
        Me.cboLocation.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboLocation.Name = "cboLocation"
        Me.cboLocation.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboLocation.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboLocation.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboLocation.Size = New System.Drawing.Size(216, 21)
        Me.cboLocation.TabIndex = 118
        Me.cboLocation.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
        'labelLoc
        '
        Me.labelLoc.BackColor = System.Drawing.Color.Transparent
        Me.labelLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelLoc.ForeColor = System.Drawing.Color.White
        Me.labelLoc.Location = New System.Drawing.Point(0, 8)
        Me.labelLoc.Name = "labelLoc"
        Me.labelLoc.Size = New System.Drawing.Size(73, 16)
        Me.labelLoc.TabIndex = 92
        Me.labelLoc.Text = "Cust_ Loc:"
        Me.labelLoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlSpecialQty1
        '
        Me.pnlSpecialQty1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label6, Me.cboBaud, Me.Label5})
        Me.pnlSpecialQty1.Location = New System.Drawing.Point(8, 104)
        Me.pnlSpecialQty1.Name = "pnlSpecialQty1"
        Me.pnlSpecialQty1.Size = New System.Drawing.Size(296, 40)
        Me.pnlSpecialQty1.TabIndex = 90
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(264, 16)
        Me.Label6.TabIndex = 92
        Me.Label6.Text = "For Special Requested (Forecasted)"
        '
        'cboBaud
        '
        Me.cboBaud.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboBaud.Caption = ""
        Me.cboBaud.CaptionHeight = 17
        Me.cboBaud.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboBaud.ColumnCaptionHeight = 17
        Me.cboBaud.ColumnFooterHeight = 17
        Me.cboBaud.ContentHeight = 15
        Me.cboBaud.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboBaud.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboBaud.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBaud.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboBaud.EditorHeight = 15
        Me.cboBaud.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
        Me.cboBaud.ItemHeight = 15
        Me.cboBaud.Location = New System.Drawing.Point(80, 16)
        Me.cboBaud.MatchEntryTimeout = CType(2000, Long)
        Me.cboBaud.MaxDropDownItems = CType(5, Short)
        Me.cboBaud.MaxLength = 32767
        Me.cboBaud.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboBaud.Name = "cboBaud"
        Me.cboBaud.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboBaud.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboBaud.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboBaud.Size = New System.Drawing.Size(216, 21)
        Me.cboBaud.TabIndex = 90
        Me.cboBaud.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(32, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 16)
        Me.Label5.TabIndex = 91
        Me.Label5.Text = "Baud:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.cboFreqs.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
        Me.cboFreqs.ItemHeight = 15
        Me.cboFreqs.Location = New System.Drawing.Point(80, 48)
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
        Me.Label4.Location = New System.Drawing.Point(8, 48)
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
        Me.cboBoxTypes.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
        Me.cboBoxTypes.ContentHeight = 15
        Me.cboBoxTypes.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboBoxTypes.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboBoxTypes.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBoxTypes.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboBoxTypes.EditorHeight = 15
        Me.cboBoxTypes.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
        Me.cboBoxTypes.ItemHeight = 15
        Me.cboBoxTypes.Location = New System.Drawing.Point(80, 26)
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
        Me.Label2.Location = New System.Drawing.Point(8, 26)
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
        Me.cboModels.Images.Add(CType(resources.GetObject("resource.Images5"), System.Drawing.Bitmap))
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
        Me.btnCreateBoxID.Location = New System.Drawing.Point(80, 144)
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
        'lblCustomer
        '
        Me.lblCustomer.BackColor = System.Drawing.Color.Transparent
        Me.lblCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomer.ForeColor = System.Drawing.Color.Yellow
        Me.lblCustomer.Location = New System.Drawing.Point(296, 0)
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.Size = New System.Drawing.Size(24, 16)
        Me.lblCustomer.TabIndex = 6
        Me.lblCustomer.Text = "customer"
        '
        'panelPallet
        '
        Me.panelPallet.BackColor = System.Drawing.Color.SteelBlue
        Me.panelPallet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panelPallet.Controls.AddRange(New System.Windows.Forms.Control() {Me.dbgCountByModel, Me.lblLocID, Me.lblLocName, Me.dbgSPQty, Me.lblBaudID, Me.lblBaud, Me.pnlSpecialQty2, Me.lblFreq, Me.txtDevSN, Me.Label10, Me.btnCloseBox, Me.btnRemoveAllSNs, Me.btnRemoveSN, Me.lstDevices, Me.lblCount, Me.Label3, Me.lblBoxName})
        Me.panelPallet.Location = New System.Drawing.Point(344, 72)
        Me.panelPallet.Name = "panelPallet"
        Me.panelPallet.Size = New System.Drawing.Size(464, 432)
        Me.panelPallet.TabIndex = 2
        Me.panelPallet.Visible = False
        '
        'dbgCountByModel
        '
        Me.dbgCountByModel.AllowColMove = False
        Me.dbgCountByModel.AllowColSelect = False
        Me.dbgCountByModel.AllowFilter = False
        Me.dbgCountByModel.AllowRowSelect = False
        Me.dbgCountByModel.AllowSort = False
        Me.dbgCountByModel.AllowUpdate = False
        Me.dbgCountByModel.AllowUpdateOnBlur = False
        Me.dbgCountByModel.BackColor = System.Drawing.Color.SteelBlue
        Me.dbgCountByModel.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dbgCountByModel.Caption = "Count by Model "
        Me.dbgCountByModel.CaptionHeight = 17
        Me.dbgCountByModel.CollapseColor = System.Drawing.Color.Azure
        Me.dbgCountByModel.FetchRowStyles = True
        Me.dbgCountByModel.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Flat
        Me.dbgCountByModel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dbgCountByModel.GroupByCaption = "Drag a column header here to group by that column"
        Me.dbgCountByModel.Images.Add(CType(resources.GetObject("resource.Images6"), System.Drawing.Bitmap))
        Me.dbgCountByModel.Location = New System.Drawing.Point(184, 248)
        Me.dbgCountByModel.Name = "dbgCountByModel"
        Me.dbgCountByModel.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgCountByModel.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgCountByModel.PreviewInfo.ZoomFactor = 75
        Me.dbgCountByModel.RecordSelectors = False
        Me.dbgCountByModel.RowSubDividerColor = System.Drawing.Color.SteelBlue
        Me.dbgCountByModel.Size = New System.Drawing.Size(272, 24)
        Me.dbgCountByModel.TabIndex = 177
        Me.dbgCountByModel.Text = "C1TrueDBGrid1"
        Me.dbgCountByModel.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor2:T" & _
        "ransparent;Border:Flat,ControlDark,0, 0, 0, 0;BackColor:Transparent;}Selected{Fo" & _
        "reColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive{ForeColor:InactiveCa" & _
        "ptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{Font:Arial, 9pt," & _
        " style=Bold;AlignHorz:Near;Border:None,,0, 0, 0, 0;ForeColor:White;BackColor:Ste" & _
        "elBlue;}Style9{}Normal{Font:Arial, 8.25pt;BackColor2:Transparent;BackColor:Trans" & _
        "parent;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddRo" & _
        "w{BackColor2:Transparent;BackColor:Transparent;}RecordSelector{AlignImage:Center" & _
        ";}Style13{}Heading{Wrap:True;BackColor2:SteelBlue;BackColor:SlateGray;Border:Non" & _
        "e,,0, 0, 0, 0;ForeColor:ControlText;AlignVert:Center;}Style8{}Style10{AlignHorz:" & _
        "Near;}Style11{}Style14{}Style15{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueD" & _
        "BGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" AllowRowSelect=""Fals" & _
        "e"" Name="""" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" F" & _
        "etchRowStyles=""True"" FilterBorderStyle=""Flat"" MarqueeStyle=""DottedCellBorder"" Re" & _
        "cordSelectorWidth=""17"" DefRecSelWidth=""17"" RecordSelectors=""False"" VerticalScrol" & _
        "lGroup=""1"" HorizontalScrollGroup=""1""><Height>7</Height><CaptionStyle parent=""Sty" & _
        "le2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle par" & _
        "ent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><F" & _
        "ooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12""" & _
        " /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""Highl" & _
        "ightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowSty" & _
        "le parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me" & _
        "=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Norma" & _
        "l"" me=""Style1"" /><ClientRect>0, 17, 272, 7</ClientRect><BorderSide>0</BorderSide" & _
        "><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><Name" & _
        "dStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><St" & _
        "yle parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style" & _
        " parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style " & _
        "parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style " & _
        "parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style paren" & _
        "t=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style" & _
        " parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSpli" & _
        "ts>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth" & _
        "><ClientArea>0, 0, 272, 24</ClientArea><PrintPageHeaderStyle parent="""" me=""Style" & _
        "14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
        '
        'lblLocID
        '
        Me.lblLocID.Location = New System.Drawing.Point(328, 56)
        Me.lblLocID.Name = "lblLocID"
        Me.lblLocID.Size = New System.Drawing.Size(16, 16)
        Me.lblLocID.TabIndex = 106
        Me.lblLocID.Text = "0"
        '
        'lblLocName
        '
        Me.lblLocName.BackColor = System.Drawing.Color.Black
        Me.lblLocName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocName.ForeColor = System.Drawing.Color.Lime
        Me.lblLocName.Location = New System.Drawing.Point(184, 48)
        Me.lblLocName.Name = "lblLocName"
        Me.lblLocName.Size = New System.Drawing.Size(144, 24)
        Me.lblLocName.TabIndex = 105
        Me.lblLocName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dbgSPQty
        '
        Me.dbgSPQty.AllowColMove = False
        Me.dbgSPQty.AllowColSelect = False
        Me.dbgSPQty.AllowFilter = False
        Me.dbgSPQty.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.dbgSPQty.AllowSort = False
        Me.dbgSPQty.AllowUpdate = False
        Me.dbgSPQty.AllowUpdateOnBlur = False
        Me.dbgSPQty.CollapseColor = System.Drawing.Color.White
        Me.dbgSPQty.ExpandColor = System.Drawing.Color.White
        Me.dbgSPQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dbgSPQty.ForeColor = System.Drawing.Color.White
        Me.dbgSPQty.GroupByCaption = "Drag a column header here to group by that column"
        Me.dbgSPQty.Images.Add(CType(resources.GetObject("resource.Images7"), System.Drawing.Bitmap))
        Me.dbgSPQty.Location = New System.Drawing.Point(176, 352)
        Me.dbgSPQty.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.dbgSPQty.Name = "dbgSPQty"
        Me.dbgSPQty.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgSPQty.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgSPQty.PreviewInfo.ZoomFactor = 75
        Me.dbgSPQty.RowHeight = 20
        Me.dbgSPQty.Size = New System.Drawing.Size(166, 73)
        Me.dbgSPQty.TabIndex = 104
        Me.dbgSPQty.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:SteelBlue;}Sele" & _
        "cted{ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Whi" & _
        "te;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Center;ForeCo" & _
        "lor:White;}Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignVer" & _
        "t:Center;ForeColor:White;BackColor:LightSteelBlue;}HighlightRow{ForeColor:Highli" & _
        "ghtText;BackColor:Highlight;}Style14{}OddRow{BackColor:Teal;}RecordSelector{Fore" & _
        "Color:White;AlignImage:Center;}Style15{}Heading{Wrap:True;Font:Microsoft Sans Se" & _
        "rif, 8.25pt, style=Bold;AlignHorz:Center;BackColor:Control;Border:Raised,,1, 1, " & _
        "1, 1;ForeColor:Blue;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}S" & _
        "tyle12{}Style13{}Style16{}Style17{}Style9{}</Data></Styles><Splits><C1.Win.C1Tru" & _
        "eDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" Name="""" AllowRowSi" & _
        "zing=""None"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" " & _
        "MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Ver" & _
        "ticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>69</Height><CaptionStyle " & _
        "parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenR" & _
        "owStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""St" & _
        "yle13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" m" & _
        "e=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle pa" & _
        "rent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /" & _
        "><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordS" & _
        "elector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style pa" & _
        "rent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 162, 69</ClientRect><BorderSide>0<" & _
        "/BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></S" & _
        "plits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Hea" & _
        "ding"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Captio" & _
        "n"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected" & _
        """ /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow" & _
        """ /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><" & _
        "Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBa" & _
        "r"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplit" & _
        "s><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</Default" & _
        "RecSelWidth><ClientArea>0, 0, 162, 69</ClientArea><PrintPageHeaderStyle parent=""" & _
        """ me=""Style16"" /><PrintPageFooterStyle parent="""" me=""Style17"" /></Blob>"
        '
        'lblBaudID
        '
        Me.lblBaudID.Location = New System.Drawing.Point(328, 88)
        Me.lblBaudID.Name = "lblBaudID"
        Me.lblBaudID.Size = New System.Drawing.Size(16, 16)
        Me.lblBaudID.TabIndex = 103
        Me.lblBaudID.Text = "0"
        '
        'lblBaud
        '
        Me.lblBaud.BackColor = System.Drawing.Color.Black
        Me.lblBaud.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBaud.ForeColor = System.Drawing.Color.Lime
        Me.lblBaud.Location = New System.Drawing.Point(184, 112)
        Me.lblBaud.Name = "lblBaud"
        Me.lblBaud.Size = New System.Drawing.Size(144, 24)
        Me.lblBaud.TabIndex = 102
        Me.lblBaud.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlSpecialQty2
        '
        Me.pnlSpecialQty2.BackColor = System.Drawing.Color.SlateGray
        Me.pnlSpecialQty2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblSPQty_Available, Me.Label11, Me.Label8})
        Me.pnlSpecialQty2.Location = New System.Drawing.Point(184, 200)
        Me.pnlSpecialQty2.Name = "pnlSpecialQty2"
        Me.pnlSpecialQty2.Size = New System.Drawing.Size(144, 40)
        Me.pnlSpecialQty2.TabIndex = 101
        '
        'lblSPQty_Available
        '
        Me.lblSPQty_Available.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSPQty_Available.ForeColor = System.Drawing.Color.Azure
        Me.lblSPQty_Available.Location = New System.Drawing.Point(72, 16)
        Me.lblSPQty_Available.Name = "lblSPQty_Available"
        Me.lblSPQty_Available.Size = New System.Drawing.Size(64, 16)
        Me.lblSPQty_Available.TabIndex = 97
        Me.lblSPQty_Available.Text = "0"
        Me.lblSPQty_Available.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Azure
        Me.Label11.Location = New System.Drawing.Point(0, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 16)
        Me.Label11.TabIndex = 94
        Me.Label11.Text = "Available:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.AliceBlue
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(144, 16)
        Me.Label8.TabIndex = 91
        Me.Label8.Text = "Special Qty Status"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFreq
        '
        Me.lblFreq.BackColor = System.Drawing.Color.Black
        Me.lblFreq.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFreq.ForeColor = System.Drawing.Color.Lime
        Me.lblFreq.Location = New System.Drawing.Point(184, 80)
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
        Me.btnRemoveAllSNs.Location = New System.Drawing.Point(180, 320)
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
        Me.btnRemoveSN.Location = New System.Drawing.Point(180, 280)
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
        Me.lblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCount.ForeColor = System.Drawing.Color.Lime
        Me.lblCount.Location = New System.Drawing.Point(205, 160)
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
        Me.Label3.Location = New System.Drawing.Point(208, 144)
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
        Me.ClientSize = New System.Drawing.Size(816, 502)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.PanelPalletList, Me.pnlShipType, Me.panelPallet, Me.Panel2, Me.lblScreenName})
        Me.Name = "frmSkyTelBuildShipBox"
        Me.Text = "frmSkyTelBuildShipBox"
        Me.PanelPalletList.ResumeLayout(False)
        CType(Me.dbgPallets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlShipType.ResumeLayout(False)
        Me.pnlLoc.ResumeLayout(False)
        CType(Me.cboLocation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSpecialQty1.ResumeLayout(False)
        CType(Me.cboBaud, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboFreqs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboBoxTypes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboModels, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelPallet.ResumeLayout(False)
        CType(Me.dbgCountByModel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dbgSPQty, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSpecialQty2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************************************************************************************************
    Private Sub txtDevSN_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDevSN.KeyPress
        Try
            'Disable it, many SNs have special characters such as '-',...
            'If Not (e.KeyChar.IsLetterOrDigit(e.KeyChar) Or e.KeyChar.IsControl(e.KeyChar)) Then
            '    e.Handled = True
            'End If
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
        Dim objMess As New PSS.Data.Buisness.Messaging()

        Try
            '**********************************************************************************************************************************************
            'Set ScreenName
            '**********************************************************************************************************************************************
            Me.lblScreenName.Text = Me._strTabPageTitle
            If Me._iMenuCustID = _objSkytel.MorrisCom_CUSTOMER_ID Then Me.lblScreenName.Font = New Font("Microsoft Sans Serif", 15, FontStyle.Bold)

            Me.pnlSpecialQty1.Visible = True : Me.pnlSpecialQty2.Visible = False
            Me.lblBaud.Visible = False : Me.lblBaudID.Visible = False
            Me.pnlLoc.Visible = False : Me.cboBoxTypes.Enabled = False
            Me.labelLoc.Visible = False : cboLocation.Visible = False
            Me.dbgCountByModel.Visible = False : Me.lblCustomer.Visible = False

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
                Case Me._objSkytel.CriticalAlert_CUSTOMER_ID
                    tmpStr = "Critical Alert"
                    'If Me._iMachineCC_GrpID = Me._objSkytel.CriticalAlert_GROUPID Then
                    isComputerNameMapped = True
                    'End If
                    Me.pnlLoc.Visible = True
                    'Me.Label5.Visible = False : Label6.Visible = False
                    'Me.cboBaud.Visible = False
                    Me.labelLoc.Visible = True : Me.cboLocation.Visible = True
                    Me.cboLocation.Left = Me.cboModels.Left
                    Dim dtLoc As DataTable = Me._objSkytel.GetLocations(Me._iMenuCustID, True)
                    Misc.PopulateC1DropDownList(Me.cboLocation, dtLoc, "Cust_Loc", "Loc_ID")
                    Me.cboLocation.SelectedValue = 0
                Case Me._objSkytel.Anna_CUSTOMER_ID, Me._objSkytel.Lahey_CUSTOMER_ID, _
                     Me._objSkytel.Masco_CUSTOMER_ID, Me._objSkytel.Franciscan_CUSTOMER_ID, _
                     Me._objSkytel.Maine_CUSTOMER_ID, Me._objSkytel.SMHC_CUSTOMER_ID

                    Me._bOtherCustomers = True : Me.btnChangeSP2RG.Visible = False
                    isComputerNameMapped = True : Me.pnlLoc.Visible = False
                    Me.pnlSpecialQty1.Visible = False : Me.btnCreateBoxID.Visible = True
                    Me.cboFreqs.Visible = False : Me.Label4.Visible = False
                    Me.lblCustomer.Text = objMess.GetMessCustomerByCustomerID(Me._iMenuCustID)
                    Me.lblCustomer.Top = 1 : Me.lblCustomer.Left = 1 : Me.lblCustomer.Width = pnlShipType.Width - 5
                    Me.lblCustomer.Visible = True
                    Me.Label1.Visible = False : Me.cboModels.Visible = False
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

                Generic.DisposeDT(dt)
                dt = Generic.GetBauds(True)
                Misc.PopulateC1DropDownList(Me.cboBaud, dt, "baud_Number", "baud_id")
                Me.cboBaud.SelectedValue = 0
                '******************************************

                Me.cboModels.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "FormLoad", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Generic.DisposeDT(dt) : objMess = Nothing
        End Try
    End Sub

    '********************************************************************************************************************************************************
    Private Sub cbos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
                Handles cboModels.KeyUp, cboFreqs.KeyUp, cboBoxTypes.KeyUp, cboBaud.KeyUp ',cboLocation.KeyUp
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
                ElseIf sender.name.trim = "cboBaud" Then
                    If Me.cboBaud.SelectedValue > 0 Then Me.btnCreateBoxID.Visible = True
                    'ElseIf sender.name.trim = "cboLocation" AndAlso Me._iMenuCustID = PSS.Data.Buisness.SkyTel.CriticalAlert_CUSTOMER_ID Then
                    '    Dim dtLoc As DataTable = Me._objSkytel.GetLocations(Me._iMenuCustID, True)
                    '    Misc.PopulateC1DropDownList(Me.cboLocation, dtLoc, "Cust_Loc", "Loc_ID")
                    '    Me.cboLocation.SelectedValue = 0
                End If

                'Baud for special requested qty if any
                'Me.pnlSpecialQty1.Visible = False : Me.pnlSpecialQty1.Enabled = True : Me.pnlSpecialQty2.Visible = False
                'If Me.dbgPallets.RowCount > 0 Then
                'PopulateSpecialQtyBaudList()
                'End If
                Me.pnlSpecialQty1.Visible = True
                'Me.cboBaud.SelectedValue = 0

            End If 'enter key
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "cbos_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '********************************************************************
    'Private Sub PopulateSpecialQtyBaudList()
    '    Dim dt As DataTable

    '    If Me._iMenuCustID > 0 AndAlso Me.cboBoxTypes.SelectedValue = 0 _
    '               AndAlso Me.cboModels.SelectedValue > 0 AndAlso Me.cboFreqs.SelectedValue Then
    '        dt = Me._objSkytel.GetSpecialRequestedQty(Me._iMenuCustID, Me.cboModels.SelectedValue, Me.cboFreqs.SelectedValue, True)
    '        If dt.Rows.Count > 0 Then
    '            Me.cboBaud.ClearItems() : Me.cboBaud.DataSource = Nothing
    '            Misc.PopulateC1DropDownList(Me.cboBaud, dt, "AMS_Baud", "PSSI_Baud_ID")
    '            Me.cboBaud.SelectedValue = 0

    '            Me.pnlSpecialQty1.Visible = True
    '        End If
    '    End If
    'End Sub

    '********************************************************************
    Private Sub PopulateOpenBoxs_OtherMessCustomer(Optional ByVal iPallettID As Integer = 0)
        Dim dt As DataTable
        Dim strPalletnamePrefix As String = Me._objSkytel.GetPalletNamePrefixStr(Me._iMenuCustID)

        Try
            Me.dbgPallets.DataSource = Nothing
            Me.txtDevSN.Text = ""
            Me.lstDevices.DataSource = Nothing
            Me.lblBoxName.Text = ""
            Me.lblCount.Text = "0"
            Me.panelPallet.Visible = False
            Me.btnCreateBoxID.Visible = False

            dt = Me._objSkytel.GetOpenPallets_OtherCustomer(strPalletnamePrefix, Me._iMenuCustID)
            With Me.dbgPallets
                .DataSource = dt.DefaultView
                SetGridOpenBoxProperties(iPallettID, False)
            End With

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "cbos_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Generic.DisposeDT(dt)
        End Try
    End Sub


    '********************************************************************
    Private Sub PopulateOpenBoxs(Optional ByVal iPallettID As Integer = 0)
        Dim dt As DataTable
        Dim row As DataRow
        Dim strModelMotoSku As String
        Dim bShowBaudCol As Boolean = False
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
                'dt = Me._objSkytel.GetOpenPallets(Me.cboModels.SelectedValue, strPalletnamePrefix & strModelMotoSku, Me._iMenuCustID)
                dt = Me._objSkytel.GetOpenPallets(Me.cboModels.SelectedValue, strPalletnamePrefix, Me._iMenuCustID)
                For Each row In dt.Rows
                    If row("Baud_ID") > 0 Then
                        bShowBaudCol = True : Exit For
                    End If
                Next
                With Me.dbgPallets
                    .DataSource = dt.DefaultView
                    SetGridOpenBoxProperties(iPallettID, bShowBaudCol)
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
    Private Sub SetGridOpenBoxProperties(Optional ByVal iPallet_ID As Integer = 0, Optional ByVal bShowBaudCol As Boolean = False)
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

            'Make some columns visible
            .Splits(0).DisplayColumns("Box Name").Visible = True
            If bShowBaudCol Then
                .Splits(0).DisplayColumns("Baud").Visible = True
            End If

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
    Private Sub CreateOtherMessCustomerBoxID()
        Dim iModelID As Integer = 0
        Dim iBoxType As Integer = 0
        Dim iFreqID As Integer = 0
        Dim iBaudID As Integer = 0
        ' Dim iAFSPQtyID As Integer = 0
        Dim strModelShortName As String = ""
        Dim iPallettID As Integer = 0
        Dim dt As DataTable
        Dim dtFilteredRows() As DataRow
        Dim bIsSPQty As Boolean = False
        Dim i As Integer = 0

        Try
            'Check valid selection of box type
            If Me.IsValidBoxTypeSelection() = False Then
                MessageBox.Show("Please select a valid Box Type.", "CreateOtherMessCustomerBoxID", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.cboBoxTypes.Focus()
                Exit Sub
            End If

            Me._iLocID = Generic.GetLocID(Me._iMenuCustID)

            If Not Me._iLocID > 0 Then
                MessageBox.Show("Invalid location ID.", "CreateOtherMessCustomerBoxID", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If Me._objSkytel.IsOpenBoxExisted_MessagingOtherCustomer(iBoxType, _
               Me._objSkytel.GetPalletNamePrefixStr(Me._iMenuCustID), Me._iMenuCustID, _
               Me._iLocID) = False Then 'New box

                iPallettID = Me._objSkytel.CreateBoxID(iModelID, iBoxType, iFreqID, _
                                                      Me._objSkytel.GetPalletNamePrefixStr(Me._iMenuCustID) & Mid(Me.cboBoxTypes.Text.Trim, 1, 3), _
                                                      Me._iMenuCustID, Me._iLocID)

                Me.PopulateOpenBoxs_OtherMessCustomer(iPallettID)
            Else 'Open box
                MessageBox.Show("An open box is currently availalbe to fill.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.PopulateOpenBoxs_OtherMessCustomer()
                Me.txtDevSN.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "CreateOtherMessCustomerBoxID", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    '********************************************************************
    Private Sub btnCreateBoxID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateBoxID.Click
        Dim iModelID As Integer = 0
        Dim iBoxType As Integer = 0
        Dim iFreqID As Integer = 0
        Dim iBaudID As Integer = 0
        ' Dim iAFSPQtyID As Integer = 0
        Dim strModelShortName As String = ""
        Dim iPallettID As Integer = 0
        Dim dt As DataTable
        Dim dtFilteredRows() As DataRow
        Dim bIsSPQty As Boolean = False
        Dim i As Integer = 0

        Try
            If Me._bOtherCustomers Then CreateOtherMessCustomerBoxID() : Exit Sub


            If IsNothing(Me.cboModels.SelectedValue) OrElse Me.cboModels.SelectedValue = 0 Then
                MessageBox.Show("Please select model.", "Create Box ID", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.cboModels.Focus()
            ElseIf IsNothing(Me.cboBoxTypes.SelectedValue) Then
                MessageBox.Show("Please select Box Type.", "Create Box ID", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.cboBoxTypes.Focus()
            ElseIf Me.cboBoxTypes.SelectedValue = 0 AndAlso (IsNothing(Me.cboFreqs.SelectedValue) OrElse Me.cboFreqs.SelectedValue = 0) Then
                MessageBox.Show("Please select frequency.", "Create Box ID", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.cboFreqs.Focus()
            ElseIf Me.cboBoxTypes.SelectedValue > 0 AndAlso Me.cboBaud.SelectedValue > 0 Then
                'Me.cboBoxTypes.SelectedValue=0 is "refurbished",a box for speical requested qty must be "refurbished"
                MessageBox.Show("Can't create a box for speical requested qty for this box type.", "Create Box ID", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.cboBoxTypes.Focus()
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

                'check Location for customer Critical Alert
                If Me._iMenuCustID = PSS.Data.Buisness.SkyTel.CriticalAlert_CUSTOMER_ID AndAlso (Not Me.cboLocation.SelectedValue > 0) Then
                    MessageBox.Show("Please select a valid customer - location.", "Create Box ID", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.cboLocation.Focus()
                    Exit Sub
                Else
                    Me._iLocID = Me.cboLocation.SelectedValue
                End If

                'Special requested Qty
                'If (Not Me._iMenuCustID = PSS.Data.Buisness.SkyTel.CriticalAlert_CUSTOMER_ID) AndAlso Me.cboBoxTypes.SelectedValue = 0 AndAlso Me.cboBaud.SelectedValue > 0 Then
                If Me.cboBoxTypes.SelectedValue = 0 AndAlso Me.cboBaud.SelectedValue > 0 Then
                    Dim strMsg As String = ""
                    Dim row As DataRow
                    dt = Me._objSkytel.GetSpecialRequestedQty(Me._iMenuCustID, Me.cboModels.SelectedValue, Me.cboFreqs.SelectedValue, Me._iLocID)
                    If dt.Rows.Count > 0 Then
                        dtFilteredRows = dt.Select("PSSI_Baud_ID=" & Me.cboBaud.SelectedValue)
                        If dtFilteredRows.Length > 0 Then 'should be 1 row if any
                            bIsSPQty = True ': iAFSPQtyID = CInt(dtFilteredRows(0).Item("AFSPQty_ID"))
                            iBaudID = Me.cboBaud.SelectedValue
                        Else
                            strMsg = "Can't create the box because of no special requested qty for the baud '"
                            strMsg &= Me.cboBaud.DataSource.Table.select("Baud_ID = " & Me.cboBaud.SelectedValue)(0)("Baud_Number") & "'."
                            strMsg &= Environment.NewLine & "But there are special requested qty for baud: "
                            i = 0
                            For Each row In dt.Rows
                                If i = 0 Then strMsg &= "'" & row("AMS_Baud") & "'" Else strMsg &= " or '" & row("AMS_Baud") & "'"
                                i += 1
                            Next
                            'strMsg = Me.cboBaud.DataSource.Table.select("Baud_ID = " & Me.cboBaud.SelectedValue)(0)("Baud_Number")
                            MessageBox.Show(strMsg & ".", "Create Box ID", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Me.cboBaud.Focus()
                            Exit Sub
                        End If
                    Else
                        strMsg = "'" & Me.cboModels.DataSource.Table.select("Model_ID = " & Me.cboModels.SelectedValue)(0)("Model_Desc")
                        strMsg &= "' and '" & Me.cboFreqs.DataSource.Table.select("Freq_ID = " & Me.cboFreqs.SelectedValue)(0)("Freq_Number") & "'"
                        MessageBox.Show("Can't create the box because of no special requested qty for " & strMsg & ".", "Create Box ID", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Me.cboBaud.Focus()
                        Exit Sub
                    End If
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
                    'If Me._iMenuCustID = PSS.Data.Buisness.SkyTel.CriticalAlert_CUSTOMER_ID Then
                    '    If Me._objSkytel.IsOpenBoxExisted_Messaging(iModelID, iBoxType, Me._objSkytel.GetPalletNamePrefixStr(Me._iMenuCustID), Me._iMenuCustID, iBaudID, bIsSPQty, Me.cboLocation.SelectedValue) = False Then

                    '        iPallettID = Me._objSkytel.CreateBoxID(iModelID, iBoxType, iFreqID, _
                    '                                              Me._objSkytel.GetPalletNamePrefixStr(Me._iMenuCustID) & Mid(Me.cboBoxTypes.Text.Trim, 1, 3), _
                    '                                              Me._iMenuCustID, Me.cboLocation.SelectedValue)
                    '        'If bIsSPQty Then
                    '        '    Me._objSkytel.SaveSpecialQtyPalletAndBaudInfoForCreatedBox(iPallettID, Me.cboBaud.SelectedValue) ', iAFSPQtyID)
                    '        'End If

                    '        Me.PopulateOpenBoxs(iPallettID)
                    '    Else
                    '        MessageBox.Show("An open box is currently availalbe to fill for selected Model and Box Type combination.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    '        Me.PopulateOpenBoxs()
                    '        Me.txtDevSN.Focus()
                    '    End If  'check if there is an box available to fill
                    'Else
                    If Me._objSkytel.IsOpenBoxExisted_Messaging(iModelID, iBoxType, Me._objSkytel.GetPalletNamePrefixStr(Me._iMenuCustID), Me._iMenuCustID, iBaudID, bIsSPQty, Me._iLocID) = False Then
                        'If Me._objSkytel.IsOpenBoxExisted(iModelID, iBoxType, Me._iMachineCC_GrpID, Me._iMenuCustID) = False Then
                        'iPallettID = Me._objSkytel.CreateBoxID(iModelID, iBoxType, iFreqID, "SK" & strModelShortName & Mid(Me.cboBoxTypes.Text.Trim, 1, 3))
                        'iPallettID = Me._objSkytel.CreateBoxID(iModelID, iBoxType, iFreqID, _
                        '                                       Me._objSkytel.GetPalletNamePrefixStr(Me._iMenuCustID) & strModelShortName & Mid(Me.cboBoxTypes.Text.Trim, 1, 3), _
                        '                                       Me._iMenuCustID)
                        iPallettID = Me._objSkytel.CreateBoxID(iModelID, iBoxType, iFreqID, _
                                                              Me._objSkytel.GetPalletNamePrefixStr(Me._iMenuCustID) & Mid(Me.cboBoxTypes.Text.Trim, 1, 3), _
                                                              Me._iMenuCustID, Me._iLocID)
                        If bIsSPQty Then
                            Me._objSkytel.SaveSpecialQtyPalletAndBaudInfoForCreatedBox(iPallettID, Me.cboBaud.SelectedValue) ', iAFSPQtyID)
                        End If

                        Me.PopulateOpenBoxs(iPallettID)
                    Else
                        MessageBox.Show("An open box is currently availalbe to fill for selected Model and Box Type combination.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.PopulateOpenBoxs()
                        Me.txtDevSN.Focus()
                    End If  'check if there is an box available to fill
                    'End If
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
            If Me._bOtherCustomers Then
                ProcessPalletSelection_OtherMessCustomer()
            Else
                Me.ProcessPalletSelection()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "dbgPallets_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '********************************************************************
    Private Sub dbgPallets_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles dbgPallets.RowColChange
        Try
            If Me._bOtherCustomers Then
                ProcessPalletSelection_OtherMessCustomer()
            Else
                Me.ProcessPalletSelection()
            End If
            'Me.ProcessPalletSelection()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "dbgPallets_RowColChange", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '********************************************************************
    Private Sub ProcessPalletSelection_OtherMessCustomer()
        Dim strShipType As String = ""
        Dim i As Integer = 0, iLoc_ID As Integer = 0
        Dim booFound As Boolean = False

        Try
            Me.lblBoxName.Text = ""
            Me.lblCount.Text = "0"
            Me.txtDevSN.Text = ""
            Me.lblLocName.Text = ""
            Me.lblLocID.Text = "0"

            Me.lstDevices.DataSource = Nothing
            Me.panelPallet.Visible = True

            Me.pnlSpecialQty2.Visible = False : Me.dbgSPQty.Visible = False
            Me.lblBaud.Visible = False : Me.lblBaudID.Visible = False
            Me.lblFreq.Visible = False
            Me.lblLocName.Visible = False : Me.lblLocID.Visible = False

            Me.Label3.Top = Me.Label10.Top : Me.lblCount.Top = Me.Label3.Top + Me.Label3.Height + 2
            Me.dbgCountByModel.Top = Me.lblCount.Top + Me.lblCount.Height + 5
            Me.dbgCountByModel.Height = btnRemoveSN.Top - Me.dbgCountByModel.Top - 10
            Me.dbgCountByModel.Visible = True : Me.dbgCountByModel.BackColor = Me.panelPallet.BackColor

            If Me.dbgPallets.Columns.Count = 0 OrElse Me.dbgPallets.RowCount = 0 Then
                Me.panelPallet.Visible = False
                Exit Sub
            End If
            If Me.dbgPallets.Columns("Box Name").Value.ToString.Trim = "" Then
                Exit Sub
            End If
            If Not CInt(Me.dbgPallets.Columns("Pallet_ShipType").Value.ToString) = 0 Then
                MessageBox.Show("Not a balid box type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Me.lblBoxName.Text = Me.dbgPallets.Columns("Box Name").Value.ToString

            Me.RefreshSNList_OtherMessCustomer()

            '*******************************************
            Me.txtDevSN.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '********************************************************************
    Private Sub ProcessPalletSelection()
        Dim strShipType As String = ""
        Dim i As Integer = 0, iLoc_ID As Integer = 0
        Dim booFound As Boolean = False

        Try
            Me.lblBoxName.Text = ""
            Me.lblCount.Text = "0"
            Me.txtDevSN.Text = ""
            Me.lblLocName.Text = ""
            Me.lblLocID.Text = "0"
            Me.lstDevices.DataSource = Nothing
            Me.panelPallet.Visible = True

            Me.pnlSpecialQty2.Visible = False : Me.dbgSPQty.Visible = False
            Me.lblBaud.Visible = False : Me.lblBaudID.Visible = False

            If Me.dbgPallets.Columns.Count = 0 OrElse Me.dbgPallets.RowCount = 0 Then
                Me.panelPallet.Visible = False
                Exit Sub
            End If
            If Me.dbgPallets.Columns("Box Name").Value.ToString.Trim = "" Then
                Exit Sub
            End If

            Me.lblBoxName.Text = Me.dbgPallets.Columns("Box Name").Value.ToString

            Me.lblLocName.Visible = False : Me.lblLocID.Visible = False
            If Me._iMenuCustID = PSS.Data.Buisness.SkyTel.CriticalAlert_CUSTOMER_ID Then
                iLoc_ID = Me.dbgPallets.Columns("Loc_ID").Value
                Dim strLocName As String = Me._objSkytel.GetLocationNameByLocID(iLoc_ID)
                Me.lblLocName.Text = strLocName : Me.lblLocID.Text = iLoc_ID
                Me.lblLocName.Visible = True ': Me.lblLocID.Visible = True
            End If

            Select Case Me.dbgPallets.Columns("Pallet_ShipType").Value.ToString
                Case "0"    'REFURBISHED
                    Me.cboBoxTypes.SelectedValue = 0
                    Me.cboFreqs.SelectedValue = CInt(Me.dbgPallets.Columns("Pallet_SkuLen").Value.ToString)
                    Me.cboBaud.SelectedValue = CInt(Me.dbgPallets.Columns("Baud_ID").Value.ToString)
                    Me.Enabled = True
                    If Me.dbgPallets.Columns("Baud_ID").Value > 0 Then
                        Me.pnlSpecialQty2.Visible = True
                        Me.lblBaud.Visible = True
                        If Me._bShowMoreSPQtyControls Then
                            Me.lblBaudID.Visible = True
                            Me.dbgSPQty.Visible = True
                        End If
                    End If

                Case Else
                    Me.cboBoxTypes.SelectedValue = CInt(Me.dbgPallets.Columns("Pallet_ShipType").Value.ToString)
                    Me.cboFreqs.SelectedValue = 0
                    Me.cboFreqs.Enabled = False
                    Me.cboBaud.SelectedValue = 0
            End Select

            Me.RefreshSNList()

            '*******************************************
            Me.txtDevSN.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '********************************************************************
    Private Sub RefreshSNList_OtherMessCustomer()
        Dim dt1, dtModelSummary As DataTable
        Dim row As DataRow
        Dim iPallet_ID As Integer = 0
        Dim strPalletName As String = ""
        Dim objMess As PSS.Data.Buisness.Messaging
        Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn

        Try
            '************************
            'Validations
            iPallet_ID = CInt(Me.dbgPallets.Columns("Pallett_ID").Value.ToString)
            strPalletName = Me.dbgPallets.Columns("Box Name").Value.ToString.Trim

            If iPallet_ID = 0 Then
                Throw New Exception("Box is not selected.")
            ElseIf strPalletName.Trim = "" Then
                Throw New Exception("Box is not selected.")
            End If

            '*******************************************
            'Get all devices add put them in list box for this pallet
            objMess = New PSS.Data.Buisness.Messaging()
            dt1 = objMess.GetAllSNsModelsForPallet(iPallet_ID)
            Me.lstDevices.DataSource = dt1.DefaultView
            Me.lstDevices.ValueMember = dt1.Columns("device_id").ToString
            Me.lstDevices.DisplayMember = dt1.Columns("device_sn").ToString

            dtModelSummary = objMess.GetPallettSummaryDataDefinition(dt1)
            With Me.dbgCountByModel
                .DataSource = dtModelSummary.DefaultView
                For Each dbgc In .Splits(0).DisplayColumns
                    dbgc.Locked = True
                    dbgc.AutoSize()
                Next dbgc
            End With


            Me.lblBoxName.Text = strPalletName
            Me.lblCount.Text = dt1.Rows.Count

        Catch ex As Exception
            Throw ex
        Finally
            objMess = Nothing
            PSS.Data.Buisness.Generic.DisposeDT(dt1)
            Me.txtDevSN.Focus()
        End Try
    End Sub

    '********************************************************************
    Private Sub RefreshSNList()
        Dim dt1, dt2 As DataTable
        Dim iPallet_ID As Integer = 0
        Dim strPalletName As String = ""
        Dim strFreqNo As String = ""
        Dim objMisc As PSS.Data.Buisness.Misc
        Dim vSum As Integer = 0

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
            'Special Requested Qty
            Me.lblBaud.Text = "" : Me.lblBaudID.Text = 0
            If CInt(Me.dbgPallets.Columns("Pallet_ShipType").Value.ToString) = 0 AndAlso Me.dbgPallets.Columns("Baud_ID").Value > 0 Then
                dt2 = Me._objSkytel.GetSpecialRequestedQty_Data(Me._iMenuCustID, Me.dbgPallets.Columns("Model_ID").Value, _
                                                                Me.dbgPallets.Columns("freq_id").Value, Me.dbgPallets.Columns("Baud_ID").Value, _
                                                                False, Me._iLocID)
                Me.dbgSPQty.DataSource = Nothing
                If dt2.Rows.Count > 0 Then
                    vSum = dt2.Compute("SUM(AvailableQty)", "")
                    Me.lblSPQty_Available.Text = vSum  'dt2.Rows(0).Item("AvailableQty")
                    Me.dbgSPQty.DataSource = dt2 '.DefaultView
                Else
                    Me.lblSPQty_Available.Text = 0
                End If

                Me.lblBaudID.Text = Me.dbgPallets.Columns("Baud_ID").Value
                Me.lblBaud.Text = Me.dbgPallets.Columns("Baud").Value

            End If

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
                If Me.txtDevSN.Text.Trim.Length > 0 Then
                    If Me._bOtherCustomers Then
                        ProcessSkyTelSN_OtherMessCustomer()
                    Else
                        Me.ProcessSkyTelSN()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtDevSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    '********************************************************************
    Private Sub ProcessSkyTelSN_OtherMessCustomer()
        Dim i As Integer = 0
        Dim strSN As String = Me.txtDevSN.Text.Trim.ToUpper
        Dim dtDevice As DataTable
        Dim dtTmp As DataTable
        Dim row As DataRow
        Dim iAFSPQtyID As Integer = 0
        Dim iBaudID As Integer = 0

        Try
            '************************
            'Validations
            If CInt(Me.dbgPallets.Columns("Pallett_ID").Value) = 0 Then
                Throw New Exception("Box Name is not selected.")
            ElseIf Me.dbgPallets.Columns("Box Name").Value.ToString.Trim = "" Then
                Throw New Exception("Box Name is not selected.")
            ElseIf Me.txtDevSN.Text.Trim = "" Then
                Exit Sub
            End If

            'refresh box to get most recent devices and other data in the box, for other users may doing the same box
            Me.RefreshSNList_OtherMessCustomer()

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
                ElseIf IsDBNull(dtDevice.Rows(0)("Device_DateBill")) Then
                    MsgBox("This device has not been billed.", MsgBoxStyle.Information, "Information")
                    Me.txtDevSN.Text = ""
                ElseIf CInt(Me.dbgPallets.Columns("Pallet_ShipType").Value) = 0 AndAlso Generic.IsValidQCResults(dtDevice.Rows(0)("Device_ID"), 1, "Functional", True) = False Then    'must Final passed
                    Me.txtDevSN.Text = ""
                Else
                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor


                    '***************************************************
                    'if above all is fine then add it to the list and update the database
                    i = PSS.Data.Production.Shipping.AssignDeviceToPallet(dtDevice.Rows(0)("Device_ID"), CInt(Me.dbgPallets.Columns("Pallett_ID").Value))

                    Me.Enabled = True
                    Cursor.Current = Cursors.Default
                    Me.txtDevSN.Text = ""
                    Me.txtDevSN.Focus()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("ProcessSkyTelSN_OtherMessCustomer: " & ex.Message, "Device Scan", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.txtDevSN.Text = ""
            Me.txtDevSN.Focus()
        Finally
            Me.RefreshSNList_OtherMessCustomer()
            Generic.DisposeDT(dtDevice)
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '********************************************************************
    Private Sub ProcessSkyTelSN()
        Dim i As Integer = 0
        Dim strSN As String = Me.txtDevSN.Text.Trim.ToUpper
        Dim dtDevice As DataTable
        Dim dtTmp As DataTable
        Dim row As DataRow
        Dim iAFSPQtyID As Integer = 0
        Dim iBaudID As Integer = 0

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

            'refresh box to get most recent devices and other data in the box, for other users may doing the same box
            Me.RefreshSNList()

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
            ElseIf Me._iMenuCustID = PSS.Data.Buisness.SkyTel.CriticalAlert_CUSTOMER_ID AndAlso CInt(dtDevice.Rows(0)("Loc_ID")) <> CInt(Me.lblLocID.Text) Then
                MsgBox("This device does not belong to Critical Alert - " & Me.lblLocName.Text & ".", MsgBoxStyle.Information, "Information")
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
                ElseIf CInt(Me.dbgPallets.Columns("Pallet_ShipType").Value.ToString) = 0 AndAlso _
                       Me.lblBaudID.Text > 0 AndAlso (dtDevice.Rows(0).IsNull("Baud_ID") OrElse CInt(dtDevice.Rows(0).Item("Baud_ID")) <> CInt(Me.lblBaudID.Text)) Then
                    'Special requested Qty 
                    MsgBox("Baud of the unit '" & Me.txtDevSN.Text & "' does not match with the box's baud. Can't put into this box.", MsgBoxStyle.Information, "Information")
                    Me.txtDevSN.Text = "" : Me.txtDevSN.Focus()
                ElseIf CInt(Me.dbgPallets.Columns("Pallet_ShipType").Value.ToString) = 0 AndAlso _
                        Me.lblBaudID.Text > 0 AndAlso Not CInt(Me.lblSPQty_Available.Text) > 0 Then
                    'Special requested Qty 
                    MsgBox("There are no requested (forecasted) quantity!", MsgBoxStyle.Information, "Information")
                    Me.txtDevSN.Text = "" : Me.txtDevSN.Focus()
                ElseIf CInt(Me.dbgPallets.Columns("Pallet_ShipType").Value.ToString) = 0 AndAlso _
                       Me.lblBaudID.Text > 0 AndAlso Me.dbgSPQty.RowCount = 0 Then
                    'Special requested Qty 
                    MsgBox("Invalid requested (forecasted) quantity!", MsgBoxStyle.Information, "Information")
                    Me.txtDevSN.Text = "" : Me.txtDevSN.Focus()
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

                    'Shen Special requested Qty 
                    If CInt(Me.dbgPallets.Columns("Pallet_ShipType").Value.ToString) = 0 AndAlso Me.lblBaudID.Text > 0 Then
                        dtTmp = Me.dbgSPQty.DataSource
                        For Each row In dtTmp.Rows
                            If Not Me.dbgPallets.Columns("Model_ID").Value = row("PSSI_Model_ID") Then
                                MsgBox("Pallet Model does not match Required Model.", MsgBoxStyle.Information, "Information")
                                Me.txtDevSN.Text = "" : Exit Sub
                            ElseIf Not Me.dbgPallets.Columns("Freq_ID").Value = row("PSSI_Freq_ID") Then
                                MsgBox("Pallet Freq does not match Required  Freq.", MsgBoxStyle.Information, "Information")
                                Me.txtDevSN.Text = "" : Exit Sub
                            ElseIf Me.dbgPallets.Columns("Baud_ID").Value <> row("PSSI_Baud_ID") _
                                  OrElse row("PSSI_Baud_ID") <> Me.lblBaudID.Text Then
                                MsgBox("Pallet Baud does not match Required Baud.", MsgBoxStyle.Information, "Information")
                                Me.txtDevSN.Text = "" : Exit Sub
                            End If
                        Next

                        'validate AvailableQty for selected row (alway select first row)
                        If Not dtTmp.Rows(0).Item("AvailableQty") > 0 Then
                            MsgBox("Can't add to this box. AvailableQty can't be less than 1.", MsgBoxStyle.Information, "Information")
                            Me.txtDevSN.Text = "" : Exit Sub
                        End If
                        iAFSPQtyID = dtTmp.Rows(0).Item("AFSPQty_ID")
                        iBaudID = dtTmp.Rows(0).Item("PSSI_Baud_ID")
                        dtTmp = Nothing

                        i = Me._objSkytel.UpdateSpecialForecastedData(iAFSPQtyID, Me.dbgPallets.Columns("Pallett_ID").Value, iBaudID, dtDevice.Rows(0)("Device_ID"))
                    End If

                    '***************************************************
                    'if above all is fine then add it to the list and update the database
                    i = PSS.Data.Production.Shipping.AssignDeviceToPallet(dtDevice.Rows(0)("Device_ID"), CInt(Me.dbgPallets.Columns("Pallett_ID").Value))

                    'When Special requested Qty 
                    If CInt(Me.dbgPallets.Columns("Pallet_ShipType").Value.ToString) = 0 AndAlso Me.lblBaudID.Text > 0 Then
                        If Not i > 0 Then MessageBox.Show("Failed to add the device. See IT (may need to manually clean table data. AFSPQty_ID=" & iAFSPQtyID.ToString & ").", "Device Scan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                    End If

                    '***************************************************
                    'Me.RefreshSNList()
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
            Me.RefreshSNList()
            Generic.DisposeDT(dtDevice)
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '********************************************************************
    Private Sub CloseBox_OthermessCustomer()
        Dim i As Integer = 0, iPrtLicensePlateQty As Integer = 2, iWipOwnerID As Integer = 0
        Dim objMisc As PSS.Data.Buisness.Misc
        Dim strRptTitle As String = ""
        Dim booAMSSharedCust As Boolean = False
        Dim dt As DataTable, row As DataRow
        Dim arrlstDevicesIDs As New ArrayList()
        Dim strMsg As String = ""
        Dim strExceptionalCaseFlag As String = ""

        Try
            'Validations
            If CInt(Me.dbgPallets.Columns("Pallett_id").Value) = 0 Then
                Throw New Exception("Box name is not selected.")
            ElseIf Me.dbgPallets.Columns("Box Name").Value.ToString.Trim = "" Then
                Throw New Exception("Box name is not selected.")
            End If

            If Me.lstDevices.Items.Count = 0 Then
                Throw New Exception("There is no devices in this box.")
            End If

            'Get Wipowner for Messaging: wipowner_ID=12,  Ready To Produce
            iWipOwnerID = 12

            'Ask to confirm 
            If MessageBox.Show("Are you sure you want to close this box?", "Close Box", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Exit Sub
            End If

            Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

            strRptTitle = Generic.GetCustomerName(_iMenuCustID) & " " & Me.cboBoxTypes.Text & " Manifest"

            'Close it
            objMisc = New PSS.Data.Buisness.Misc()
            i = objMisc.ClosePallet(Me._iMenuCustID, CInt(Me.dbgPallets.Columns("Pallett_ID").Value), _
                                    Me.dbgPallets.Columns("Box Name").Value, _
                                    Me.lstDevices.Items.Count, Me.dbgPallets.Columns("Pallet_ShipType").Value, iPrtLicensePlateQty, strRptTitle)
            If i = 0 Then Throw New Exception("Box has not closed yet due to an error. Please contact IT.")

            '**********************************
            'Set Wipowner for Messaging
            '**********************************
            Generic.SetTmessdataWipOwnerdataForDevices("", iWipOwnerID, 0, CInt(Me.dbgPallets.Columns("Pallett_ID").Value))
            ' INSERT THE DEVICE JOURNAL RECORDS.
            For i = 0 To lstDevices.Items.Count - 1
                Dim _device_id As Integer = 0
                _device_id = DirectCast(lstDevices.Items(i)(0), Integer)
                Data.BLL.MsgDeviceMovement.DeviceMovementJornalInsert(_device_id, 1, iWipOwnerID, 0, "AMS Build Ship Box")
            Next

            Me.cboBoxTypes.SelectedValue = CInt(Me.dbgPallets.Columns("Pallet_ShipType").Value)

            'Print label (due to moxed models allowed, model_ID =0 always
            PSS.Data.Production.Shipping.PrintPalletLicensePlate(Me.dbgPallets.Columns("Box Name").Value, Me.dbgPallets.Columns("Model_ID").Value, Me.cboBoxTypes.Text, Me.lstDevices.Items.Count, 3)

            'Refresh Pallet (Box) 
            Me.PopulateOpenBoxs_OtherMessCustomer()

            'Reset Screen control properties.
            Me.lblBoxName.Text = ""
            Me.lblCount.Text = 0
            Me.lstDevices.DataSource = Nothing
            Me.dbgCountByModel.DataSource = Nothing
            Me.panelPallet.Visible = False
            '******************************
        Catch ex As Exception
            MessageBox.Show(ex.Message, "CloseBox_OthermessCustomer", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            objMisc = Nothing
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '********************************************************************
    Private Sub btnCloseBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseBox.Click
        Dim i As Integer = 0, iPrtLicensePlateQty As Integer = 2, iWipOwnerID As Integer = 0
        Dim objMisc As PSS.Data.Buisness.Misc
        Dim strRptTitle As String = ""
        Dim booAMSSharedCust As Boolean = False
        Dim dt As DataTable, row As DataRow
        Dim arrlstDevicesIDs As New ArrayList()
        Dim strMsg As String = ""
        Dim strExceptionalCaseFlag As String = ""

        Try

            If Me._bOtherCustomers Then CloseBox_OthermessCustomer() : Exit Sub

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

            '*********************************
            'Validate (Regular Inbox + Produced + DockShipped) > Regular WeekFC  * 1.05 , if yes, stop it
            'Refurbished, regular
            If CInt(Me.dbgPallets.Columns("Pallet_ShipType").Value.ToString) = 0 AndAlso Me.dbgPallets.Columns("Baud_ID").Value = 0 Then
                strExceptionalCaseFlag = ModManuf.GetExceptionCriteria("AMS_BUILD_SHIP_BOX_CLOSE_REGULAR_CHECKPOINT", "Generic").Trim

                If strExceptionalCaseFlag.Length = 0 OrElse strExceptionalCaseFlag = "0" Then 'Do nothing
                    'No nothig to do, comtinue...
                Else
                    dt = Me._objSkytel.GetDevicesByPalletID(Me._iMenuCustID, CInt(Me.dbgPallets.Columns("Pallett_ID").Value.ToString))
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("Failed to find box devices in DB!", "btnCloseBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                    For Each row In dt.Rows
                        arrlstDevicesIDs.Add(row("Device_ID"))
                    Next
                    dt = Nothing

                    dt = getRegularFCInboxProducedDockShipped(arrlstDevicesIDs)
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("Failed to find box data!", "btnCloseBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    Else
                        'strExceptionalCaseFlag = ModManuf.GetExceptionCriteria("AMS_BUILD_SHIP_BOX_CLOSE_REGULAR_CHECKPOINT", "Generic").Trim
                        strMsg = ""
                        For Each row In dt.Rows 'check it
                            If CInt(row("InBox") + row("Produced") + row("DockShipped")) > CInt(row("WkFC") * 1.05) Then
                                strMsg = "More than the regular week FC quantity " & CInt(row("WkFC")).ToString & ". Can't close it. (" & _
                                          row("cust_name1").ToString & ", " & row("model_desc").ToString & _
                                           ", " & row("Freq_Number").ToString & ", " & row("Baud_Number").ToString & "). " & Environment.NewLine
                            End If
                        Next
                        If strMsg.Trim.Length > 0 Then
                            If strExceptionalCaseFlag.Length = 0 OrElse strExceptionalCaseFlag = "0" Then 'Do nothing
                                'No nothig to do, comtinue...
                            ElseIf strExceptionalCaseFlag = "1" Then 'Stop, exit sub
                                MessageBox.Show(strMsg, "btnCloseBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Exit Sub
                            ElseIf strExceptionalCaseFlag = "2" Then 'just warming, comtinue...
                                MessageBox.Show("Just warnning: " & strMsg, "btnCloseBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Else 'exception, stop, exit sub
                                MessageBox.Show("Can't define AMS_BUILD_SHIP_BOX_CLOSE_REGULAR_CHECKPOINT.", "btnCloseBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Exit Sub
                            End If
                        End If
                    End If
                    dt = Nothing
                End If
            End If


            '**********************************
            'Get Wipowner for Messaging
            '**********************************
            booAMSSharedCust = Data.Buisness.MessLabel.IsAMSShareableInventoryCustomer(Me._iMenuCustID)
            If booAMSSharedCust Then
                iWipOwnerID = Data.Buisness.MessReceive.GetAMSNextWipOwner(_iMenuCustID, Me._strScreenName, 0)
                If iWipOwnerID = 0 Then Throw New Exception("Can't define next wip location.")
            End If
            '**********************************

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
                                    Me.lstDevices.Items.Count, Me.dbgPallets.Columns("Pallet_ShipType").Value, iPrtLicensePlateQty, strRptTitle)
            If i = 0 Then Throw New Exception("Box has not closed yet due to an error. Please contact IT.")

            '**********************************
            'Set Wipowner for Messaging
            '**********************************
            If booAMSSharedCust Then
                Generic.SetTmessdataWipOwnerdataForDevices("", iWipOwnerID, 0, CInt(Me.dbgPallets.Columns("Pallett_ID").Value))
                ' INSERT THE DEVICE JOURNAL RECORDS.
                For i = 0 To lstDevices.Items.Count - 1
                    Dim _device_id As Integer = 0
                    _device_id = DirectCast(lstDevices.Items(i)(0), Integer)
                    Data.BLL.MsgDeviceMovement.DeviceMovementJornalInsert(_device_id, 1, iWipOwnerID, 0, "AMS Build Ship Box")
                Next
            End If

            Me.cboBoxTypes.SelectedValue = CInt(Me.dbgPallets.Columns("Pallet_ShipType").Value)

            'Special Requested Qty Pallet
            If CInt(Me.dbgPallets.Columns("Pallet_ShipType").Value.ToString) = 0 AndAlso Me.dbgPallets.Columns("Baud_ID").Value > 0 Then
                PSS.Data.Production.Shipping.PrintPalletLicensePlate(Me.dbgPallets.Columns("Box Name").Value, Me.dbgPallets.Columns("Model_ID").Value, Me.cboBoxTypes.Text, Me.lstDevices.Items.Count, 3, Me.dbgPallets.Columns("Baud").Value)
            Else    'regular pallet
                PSS.Data.Production.Shipping.PrintPalletLicensePlate(Me.dbgPallets.Columns("Box Name").Value, Me.dbgPallets.Columns("Model_ID").Value, Me.cboBoxTypes.Text, Me.lstDevices.Items.Count, 3)
            End If
            ' PSS.Data.Production.Shipping.PrintPalletLicensePlate(Me.dbgPallets.Columns("Box Name").Value, Me.dbgPallets.Columns("Model_ID").Value, Me.cboBoxTypes.Text, Me.lstDevices.Items.Count, 3)
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

                'Special Requested (Forecasted) Qty
                If CInt(Me.dbgPallets.Columns("Pallet_ShipType").Value.ToString) = 0 AndAlso Me.dbgPallets.Columns("Baud_ID").Value > 0 Then
                    i = Me._objSkytel.DeleteteSN_UpdateSpecialForecastedData(Me.dbgPallets.Columns("Pallett_ID").Value, iDeviceID)
                End If

                i = PSS.Data.Production.Shipping.RemoveSNfromPallet(CInt(Me.dbgPallets.Columns("Pallett_id").Value), iDeviceID)
                If i = 0 Then
                    Throw New Exception("S/N entered was not removed from Box.")
                End If

                If Me._bOtherCustomers Then
                    Me.RefreshSNList_OtherMessCustomer()
                Else
                    Me.RefreshSNList()
                End If

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

            'Special Requested (Forecasted) Qty
            If CInt(Me.dbgPallets.Columns("Pallet_ShipType").Value.ToString) = 0 AndAlso Me.dbgPallets.Columns("Baud_ID").Value > 0 Then
                i = Me._objSkytel.DeleteteAllSNs_UpdateSpecialForecastedData(Me.dbgPallets.Columns("Pallett_ID").Value)
            End If

            i = PSS.Data.Production.Shipping.RemoveSNfromPallet(CInt(Me.dbgPallets.Columns("Pallett_id").Value), )
            If i = 0 Then
                Throw New Exception("No SNs were removed from box.")
            End If

            If Me._bOtherCustomers Then
                Me.RefreshSNList_OtherMessCustomer()
            Else
                Me.RefreshSNList()
            End If

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
    Private Sub ReopenBox_OtherMessCustomer()
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

                'Refresh Pallet( Box )
                Me.PopulateOpenBoxs_OtherMessCustomer(dt.Rows(0)("Pallett_ID"))

                '************************
                Me.lstDevices.DataSource = Nothing
                Me.dbgCountByModel.DataSource = Nothing
                Me.lblCount.Text = "0"
                Me.lblBoxName.Text = ""
                Me.panelPallet.Visible = False
                '************************
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "ReopenBox_OtherMessCustomer", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            objMisc = Nothing
            Generic.DisposeDT(dt)
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

            If Me._bOtherCustomers Then ReopenBox_OtherMessCustomer() : Exit Sub


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


                'delete it 
                i = PSS.Data.Production.Shipping.DeleteEmptyPallet(CInt(Me.dbgPallets.Columns("Pallett_ID").Value), PSS.Core.ApplicationUser.IDuser)


                'Special Requested (Forecasted) Qty
                If CInt(Me.dbgPallets.Columns("Pallet_ShipType").Value.ToString) = 0 AndAlso Me.dbgPallets.Columns("Baud_ID").Value > 0 Then
                    i = Me._objSkytel.DeleteteEmptyPallet_UpdateSpecialForecastedData(Me.dbgPallets.Columns("Pallett_ID").Value)
                End If

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
                    'PSS.Data.Production.Shipping.PrintPalletLicensePlate(str_pallett, R1("Model_ID"), strPalletType, iPalletQty, 1)

                    If R1("Pallet_ShipType") = 0 AndAlso R1("Baud_ID") > 0 Then  'Special REquested Qty pallet
                        PSS.Data.Production.Shipping.PrintPalletLicensePlate(str_pallett, R1("Model_ID"), strPalletType, iPalletQty, 1, R1("Baud"))
                    Else 'regular pallet
                        PSS.Data.Production.Shipping.PrintPalletLicensePlate(str_pallett, R1("Model_ID"), strPalletType, iPalletQty, 1)
                    End If
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
                ElseIf R1("Cust_ID") = Me._objSkytel.AMS_CUSTOMER_ID Then
                    strFilePath = Me._objSkytel.AMS_MANIFEST_DIR
                ElseIf R1("Cust_ID") = Me._objSkytel.A1WirelessComm_CUSTOMER_ID Then
                    strFilePath = Me._objSkytel.A1WirelessComm_MANIFEST_DIR
                ElseIf R1("Cust_ID") = Me._objSkytel.CriticalAlert_CUSTOMER_ID Then
                    strFilePath = Me._objSkytel.CriticalAlert_MANIFEST_DIR
                ElseIf R1("Cust_ID") = Me._objSkytel.Anna_CUSTOMER_ID Then
                    strFilePath = Me._objSkytel.Anna_MANIFEST_DIR
                ElseIf R1("Cust_ID") = Me._objSkytel.Lahey_CUSTOMER_ID Then
                    strFilePath = Me._objSkytel.Lahey_MANIFEST_DIR
                ElseIf R1("Cust_ID") = Me._objSkytel.Masco_CUSTOMER_ID Then
                    strFilePath = Me._objSkytel.Masco_MANIFEST_DIR
                ElseIf R1("Cust_ID") = Me._objSkytel.Franciscan_CUSTOMER_ID Then
                    strFilePath = Me._objSkytel.Franciscan_MANIFEST_DIR
                ElseIf R1("Cust_ID") = Me._objSkytel.Maine_CUSTOMER_ID Then
                    strFilePath = Me._objSkytel.Maine_MANIFEST_DIR
                ElseIf R1("Cust_ID") = Me._objSkytel.SMHC_CUSTOMER_ID Then
                    strFilePath = Me._objSkytel.SMHC_MANIFEST_DIR
                ElseIf R1("Cust_ID") = Me._objSkytel.ATS_CUSTOMER_ID Then
                    strFilePath = Me._objSkytel.ATS_MANIFEST_DIR
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
    Private Function getRegularFCInboxProducedDockShipped(ByVal arrlstDevices As ArrayList) As DataTable
        Dim strDeviceIDs As String = ""
        Dim strSQL As String = ""
        Dim strToday, strDateWeekStart, strDateWeekEnd As String
        Dim i As Integer = 0, iQty As Integer = 0
        Dim iCustID As Integer = 0
        Dim row, row2, filteredRows() As DataRow
        Dim dtTmp, dtBoxCMFB As DataTable
        Dim objMessMisc As New PSS.Data.Buisness.MessMisc()
        Dim objMessReports As New PSS.Data.Buisness.MessReports()

        Try
            For i = 0 To arrlstDevices.Count - 1
                If i = 0 Then strDeviceIDs = arrlstDevices(i) Else strDeviceIDs &= "," & arrlstDevices(i)
            Next

            strToday = CDate(Generic.MySQLServerDateTime(1)).ToString("yyyy-MM-dd")

            ''Week begin and End date
            strDateWeekStart = Format(DateAdd(DateInterval.Day, (Weekday(CDate(strToday), FirstDayOfWeek.Monday) - 1) * -1, CDate(strToday)), "yyyy-MM-dd")
            'strDateWeekEnd = Format(DateAdd(DateInterval.Day, (6), CDate(strDateWeekStart)), "yyyy-MM-dd")

            'Get unique Cust Model Freq Baud data
            dtBoxCMFB = objMessMisc.getCustModelFreqBaud(strDeviceIDs)

            dtBoxCMFB.Columns.Add(New DataColumn("WkFC", GetType(Integer))) 'System.Type.GetType("System.Int16")))
            dtBoxCMFB.Columns.Add(New DataColumn("InBox", GetType(Integer)))
            dtBoxCMFB.Columns.Add(New DataColumn("Produced", GetType(Integer)))
            dtBoxCMFB.Columns.Add(New DataColumn("DockShipped", GetType(Integer)))

            For Each row In dtBoxCMFB.Rows
                'rowNew = dtFinal.NewRow
                iCustID = row("Cust_ID")

                'Regular Week Forcasted
                dtTmp = objMessMisc.getForecastedData(row("UniqueID"), strDateWeekStart)
                If dtTmp.Rows.Count > 0 Then iQty = dtTmp.Rows(0).Item("Forecast") Else iQty = 0
                'rowNew("UniqueID") = row("UniqueID")
                row("WkFC") = iQty

                'Regular Inbox 
                dtTmp = objMessMisc.getRegularInBoxQty(iCustID, row("UniqueID"))
                If dtTmp.Rows.Count > 0 Then iQty = dtTmp.Rows(0).Item("RegularQty") Else iQty = 0
                row("InBox") = iQty

                'Regular Produced 
                dtTmp = objMessMisc.getProducedButNotYetShippedData(iCustID)
                filteredRows = dtTmp.Select("UniqueID='" & row("UniqueID") & "'")
                iQty = 0
                For Each row2 In filteredRows
                    iQty += row2("Produced_NotYetShipped")
                Next
                row("Produced") = iQty

                'Regular Dock Shipped
                dtTmp = objMessReports.GetMessDShipCntByDateRange(iCustID, strToday, True, False, False, _
                                                                  row("Model_ID"), row("Freq_ID"), row("Baud_ID"), True)
                If dtTmp.Rows.Count > 0 Then iQty = dtTmp.Rows(0).Item("wk Ship") Else iQty = 0
                row("DockShipped") = iQty

                'dtFinal.Rows.Add(rowNew)
            Next

            Return dtBoxCMFB

        Catch ex As Exception
            Throw ex
        Finally
            objMessMisc = Nothing : objMessReports = Nothing
        End Try
    End Function

    '********************************************************************
    Private Sub btnChangeSP2RG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeSP2RG.Click
        Dim iPalletID As Integer = 0
        'Dim iModelID As Integer = 0
        'Dim iFreqID As Integer = 0
        'Dim iRow As Integer = 0

        Dim strPallet As String = ""
        Dim objMisc As New PSS.Data.Buisness.Misc()
        Dim dt, dtTmp As DataTable
        Dim row As DataRow
        Dim arrlstDevicesIDs As New ArrayList()
        Dim strMsg As String = ""
        Dim strExceptionalCaseFlag As String = ""

        Try

            'THIS IS METHOD CHANGE SPECIAL BOX (PRODUCED) TO REGULAR BOX

            strPallet = InputBox("Enter Special Box ID.", "Sp Box Entry")
            If strPallet = "" Then
                Throw New Exception("Please enter a special box name to change.")
            End If

            dt = objMisc.GetPalletInfo_ByPallettName(strPallet)

            If Not dt.Rows.Count > 0 Then
                MessageBox.Show("Can't find this box in the system.", "btnChangeSP2RG_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf dt.Rows.Count > 1 Then
                MessageBox.Show("Duplicated boxes.", "btnChangeSP2RG_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf dt.Rows.Count = 1 AndAlso dt.Rows(0).Item("Baud_ID") > 0 Then
                If Not dt.Rows(0).Item("Pallet_Invalid") = 0 Then
                    MessageBox.Show("Invalid box.", "btnChangeSP2RG_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf Not dt.Rows(0).Item("Pallet_ShipType") = 0 Then
                    MessageBox.Show("Not refurbished box.", "btnChangeSP2RG_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf dt.Rows(0).IsNull("Pallett_ShipDate") Then
                    MessageBox.Show("Not a produced box.", "btnChangeSP2RG_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf Not dt.Rows(0).IsNull("pkslip_ID") Then
                    MessageBox.Show("Box has been shipped. Can't change.", "btnChangeSP2RG_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else 'ready
                    If MessageBox.Show("Do you want to change this special box " & strPallet & " to regular box?", "Confirm Change", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

                        'get pallet_ID
                        iPalletID = dt.Rows(0).Item("Pallett_ID")

                        'Validate
                        dtTmp = Me._objSkytel.GetDevicesByPalletID(Me._iMenuCustID, iPalletID)
                        If dtTmp.Rows.Count = 0 Then
                            MessageBox.Show("Failed to find box devices in DB!", "btnCloseBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If
                        For Each row In dtTmp.Rows
                            arrlstDevicesIDs.Add(row("Device_ID"))
                        Next
                        dtTmp = Nothing

                        dtTmp = getRegularFCInboxProducedDockShipped(arrlstDevicesIDs)
                        If dt.Rows.Count = 0 Then
                            MessageBox.Show("Failed to find box data!", " btnChangeSP2RG_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        Else
                            strExceptionalCaseFlag = ModManuf.GetExceptionCriteria("AMS_BUILD_SHIP_BOX_CHANGE_REGULAR_CHECKPOINT", "Generic").Trim
                            strMsg = ""
                            For Each row In dt.Rows
                                If CInt(row("InBox") + row("Produced") + row("DockShipped")) > CInt(row("WkFC") * 1.05) Then
                                    strMsg = "More than the regular week FC quantity " & CInt(row("WkFC")).ToString & ". Can't change it. (" & _
                                              row("cust_name1").ToString & ", " & row("model_desc").ToString & _
                                               ", " & row("Freq_Number").ToString & ", " & row("Baud_Number").ToString & "). " & Environment.NewLine

                                End If
                            Next
                            If strMsg.Trim.Length > 0 Then
                                If strExceptionalCaseFlag.Length = 0 OrElse strExceptionalCaseFlag = "0" Then 'Do nothing
                                    'No nothig to do, comtinue...
                                ElseIf strExceptionalCaseFlag = "1" Then 'Stop, exit sub
                                    MessageBox.Show(strMsg, " btnChangeSP2RG_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                    Exit Sub
                                ElseIf strExceptionalCaseFlag = "2" Then 'just warming, comtinue...
                                    MessageBox.Show("Just warnning: " & strMsg, "btnCloseBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Else 'exception, stop, exit sub
                                    MessageBox.Show("Can't define AMS_BUILD_SHIP_BOX_CHANGE_REGULAR_CHECKPOINT.", "btnCloseBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                    Exit Sub
                                End If
                            End If
                        End If

                        'Change it
                        Me._objSkytel.ChangeSpecialBox2RegularBox(iPalletID)
                        MessageBox.Show("Completed!", "btnChangeSP2RG_Click", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            Else
                MessageBox.Show("Not a special box.", "btnChangeSP2RG_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If



            'THIS IS METHOD CHANGE SPECIAL BOX (UNPRODUCED) TO REGULAR BOX
            'If Me.dbgPallets.Columns.Count = 0 OrElse Me.dbgPallets.RowCount = 0 Then
            '    Me.panelPallet.Visible = False
            '    Exit Sub
            'End If
            'If Me.dbgPallets.Columns("Box Name").Value.ToString.Trim = "" Then
            '    Exit Sub
            'End If
            'If CInt(Me.dbgPallets.Columns("Pallet_ShipType").Value.ToString) = 0 AndAlso Me.dbgPallets.Columns("Baud_ID").Value > 0 Then
            '    'Selected special box info
            '    iPalletID = CInt(Me.dbgPallets.Columns("Pallett_ID").Value.ToString)
            '    iModelID = CInt(Me.dbgPallets.Columns("Model_ID").Value.ToString)
            '    iFreqID = CInt(Me.dbgPallets.Columns("Freq_ID").Value.ToString)

            '    'Check if already have same model-Freq open regular box, go through each box except selected special box
            '    For iRow = 0 To Me.dbgPallets.RowCount - 1
            '        If iPalletID <> CInt(Me.dbgPallets.Columns("Pallett_ID").CellText(iRow)) Then
            '            If iModelID = CInt(Me.dbgPallets.Columns("Model_ID").CellText(iRow)) _
            '               AndAlso iFreqID = CInt(Me.dbgPallets.Columns("Freq_ID").CellText(iRow)) Then
            '                MessageBox.Show("An regular open box is currently availalbe to fill for selected Model/Type/Freq combination. Can't change this special box to regular box.", "btnChangeSP2RG_Clickk", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '                Exit Sub
            '            End If
            '        End If
            '    Next

            '    'Ready to change
            '    Me._objSkytel.ChangeSpecialBox2RegularBox(iPalletID)

            '    'Refresh
            '    PopulateOpenBoxs()
            'Else
            '    MessageBox.Show("Not a special box.", "btnChangeSP2RG_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "btnChangeSP2RG_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            objMisc = Nothing : dt = Nothing : dtTmp = Nothing
            'Me.Enabled = True
            'Cursor.Current = Cursors.Default

        End Try
    End Sub

    '********************************************************************
    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    '  MessageBox.Show(Me._objSkytel.zfTest().ToString)
    '    Dim dt As DataTable

    '    Dim arrlstDevices As New ArrayList()
    '    arrlstDevices.Add("13554824")
    '    arrlstDevices.Add("15464894")
    '    dt = getRegularFCInboxProducedDockShipped(arrlstDevices)
    '    Me.C1TrueDBGrid1.DataSource = dt
    'End Sub



    '********************************************************************

End Class
