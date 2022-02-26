Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.TracFone
    Public Class frmBuildShipPallet
        Inherits System.Windows.Forms.Form

        Private _iMenuCustID As Integer = 0
        Private _strScreenName As String = ""

        Private _objTFBuildShipPallet As PSS.Data.Buisness.TracFone.BuildShipPallet
        Private _iMachineCC_GrpID As Integer = 0
        Private strMachine As String = System.Net.Dns.GetHostName
        Private objMisc As PSS.Data.Buisness.Misc
        Private iWCLocation_ID As Integer = 0
        Private iLine_ID As Integer = 0
        Private iGroup_ID As Integer = 0
        Private strGroup As String = ""
        Private strLineNumber As String = ""
        Private iLineSide_ID As Integer = 0
        Private strLineSide As String = ""
        Private strBin As String = ""
        Private strUserName As String = PSS.Core.[Global].ApplicationUser.User
        Private iShiftID As Integer = PSS.Core.[Global].ApplicationUser.IDShift
        Private strWorkDate As String = PSS.Core.[Global].ApplicationUser.Workdate
        Private _booAccessToFillBoxWithWHBox As Boolean = False

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iCustID As Integer, ByVal strScreenName As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _objTFBuildShipPallet = New PSS.Data.Buisness.TracFone.BuildShipPallet()
            _strScreenName = strScreenName
            _iMenuCustID = iCustID
            objMisc = New PSS.Data.Buisness.Misc()
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
                objMisc = Nothing
                _objTFBuildShipPallet = Nothing
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Friend WithEvents PanelPalletList As System.Windows.Forms.Panel
        Friend WithEvents btnDeleteBox As System.Windows.Forms.Button
        Friend WithEvents dbgPallets As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnReopenBox As System.Windows.Forms.Button
        Friend WithEvents btnReprintBoxLabel As System.Windows.Forms.Button
        Friend WithEvents pnlShipType As System.Windows.Forms.Panel
        Friend WithEvents cboBoxTypes As C1.Win.C1List.C1Combo
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents cboModels As C1.Win.C1List.C1Combo
        Friend WithEvents Button5 As System.Windows.Forms.Button
        Friend WithEvents btnCreateBoxID As System.Windows.Forms.Button
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents panelPallet As System.Windows.Forms.Panel
        Friend WithEvents txtDevSN As System.Windows.Forms.TextBox
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents btnCloseBox As System.Windows.Forms.Button
        Friend WithEvents btnRemoveAllSNs As System.Windows.Forms.Button
        Friend WithEvents btnRemoveSN As System.Windows.Forms.Button
        Friend WithEvents lstDevices As System.Windows.Forms.ListBox
        Friend WithEvents lblCount As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents lblBoxName As System.Windows.Forms.Label
        Friend WithEvents lblScreenName As System.Windows.Forms.Label
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents lblCostCenter As System.Windows.Forms.Label
        Friend WithEvents lblUserName As System.Windows.Forms.Label
        Friend WithEvents lblWorkDate As System.Windows.Forms.Label
        Friend WithEvents lblShift As System.Windows.Forms.Label
        Friend WithEvents lblMachine As System.Windows.Forms.Label
        Friend WithEvents lblLineSide As System.Windows.Forms.Label
        Friend WithEvents lblGroup As System.Windows.Forms.Label
        Friend WithEvents lblLine As System.Windows.Forms.Label
        Friend WithEvents Button2 As System.Windows.Forms.Button
        Friend WithEvents lblPassed As System.Windows.Forms.Label
        Friend WithEvents btnFillBoxWithWHBox As System.Windows.Forms.Button
        Friend WithEvents lblBERReason As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmBuildShipPallet))
            Me.PanelPalletList = New System.Windows.Forms.Panel()
            Me.btnDeleteBox = New System.Windows.Forms.Button()
            Me.dbgPallets = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnReopenBox = New System.Windows.Forms.Button()
            Me.btnReprintBoxLabel = New System.Windows.Forms.Button()
            Me.pnlShipType = New System.Windows.Forms.Panel()
            Me.cboBoxTypes = New C1.Win.C1List.C1Combo()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.cboModels = New C1.Win.C1List.C1Combo()
            Me.Button5 = New System.Windows.Forms.Button()
            Me.btnCreateBoxID = New System.Windows.Forms.Button()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.panelPallet = New System.Windows.Forms.Panel()
            Me.btnFillBoxWithWHBox = New System.Windows.Forms.Button()
            Me.txtDevSN = New System.Windows.Forms.TextBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.btnCloseBox = New System.Windows.Forms.Button()
            Me.btnRemoveAllSNs = New System.Windows.Forms.Button()
            Me.btnRemoveSN = New System.Windows.Forms.Button()
            Me.lstDevices = New System.Windows.Forms.ListBox()
            Me.lblCount = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.lblBoxName = New System.Windows.Forms.Label()
            Me.lblBERReason = New System.Windows.Forms.Label()
            Me.lblScreenName = New System.Windows.Forms.Label()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.lblCostCenter = New System.Windows.Forms.Label()
            Me.lblUserName = New System.Windows.Forms.Label()
            Me.lblWorkDate = New System.Windows.Forms.Label()
            Me.lblShift = New System.Windows.Forms.Label()
            Me.lblMachine = New System.Windows.Forms.Label()
            Me.lblLineSide = New System.Windows.Forms.Label()
            Me.lblGroup = New System.Windows.Forms.Label()
            Me.lblLine = New System.Windows.Forms.Label()
            Me.Button2 = New System.Windows.Forms.Button()
            Me.lblPassed = New System.Windows.Forms.Label()
            Me.PanelPalletList.SuspendLayout()
            CType(Me.dbgPallets, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlShipType.SuspendLayout()
            CType(Me.cboBoxTypes, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboModels, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.panelPallet.SuspendLayout()
            Me.Panel2.SuspendLayout()
            Me.SuspendLayout()
            '
            'PanelPalletList
            '
            Me.PanelPalletList.BackColor = System.Drawing.Color.SteelBlue
            Me.PanelPalletList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.PanelPalletList.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnDeleteBox, Me.dbgPallets, Me.btnReopenBox, Me.btnReprintBoxLabel})
            Me.PanelPalletList.Location = New System.Drawing.Point(3, 184)
            Me.PanelPalletList.Name = "PanelPalletList"
            Me.PanelPalletList.Size = New System.Drawing.Size(421, 344)
            Me.PanelPalletList.TabIndex = 118
            '
            'btnDeleteBox
            '
            Me.btnDeleteBox.BackColor = System.Drawing.Color.Red
            Me.btnDeleteBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnDeleteBox.ForeColor = System.Drawing.Color.White
            Me.btnDeleteBox.Location = New System.Drawing.Point(240, 240)
            Me.btnDeleteBox.Name = "btnDeleteBox"
            Me.btnDeleteBox.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnDeleteBox.Size = New System.Drawing.Size(168, 32)
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
            Me.dbgPallets.CaptionHeight = 19
            Me.dbgPallets.CollapseColor = System.Drawing.Color.White
            Me.dbgPallets.ExpandColor = System.Drawing.Color.White
            Me.dbgPallets.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dbgPallets.ForeColor = System.Drawing.Color.White
            Me.dbgPallets.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgPallets.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dbgPallets.Location = New System.Drawing.Point(8, 9)
            Me.dbgPallets.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.dbgPallets.Name = "dbgPallets"
            Me.dbgPallets.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgPallets.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgPallets.PreviewInfo.ZoomFactor = 75
            Me.dbgPallets.RowHeight = 20
            Me.dbgPallets.Size = New System.Drawing.Size(400, 223)
            Me.dbgPallets.TabIndex = 0
            Me.dbgPallets.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            "eDBGrid.MergeView HBarHeight=""17"" AllowColMove=""False"" AllowColSelect=""False"" Na" & _
            "me="""" AllowRowSizing=""None"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFo" & _
            "oterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefRecS" & _
            "elWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>219</Heig" & _
            "ht><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=" & _
            """Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""" & _
            "FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle" & _
            " parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><Hig" & _
            "hLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inacti" & _
            "ve"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyl" & _
            "e parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""St" & _
            "yle6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 396, 219</ClientR" & _
            "ect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDB" & _
            "Grid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style paren" & _
            "t=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""H" & _
            "eading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""No" & _
            "rmal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal" & _
            """ me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Norma" & _
            "l"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""No" & _
            "rmal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertS" & _
            "plits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSe" & _
            "lWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 396, 219</ClientArea><PrintPageH" & _
            "eaderStyle parent="""" me=""Style16"" /><PrintPageFooterStyle parent="""" me=""Style17""" & _
            " /></Blob>"
            '
            'btnReopenBox
            '
            Me.btnReopenBox.BackColor = System.Drawing.Color.Green
            Me.btnReopenBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReopenBox.ForeColor = System.Drawing.Color.White
            Me.btnReopenBox.Location = New System.Drawing.Point(8, 240)
            Me.btnReopenBox.Name = "btnReopenBox"
            Me.btnReopenBox.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnReopenBox.Size = New System.Drawing.Size(168, 32)
            Me.btnReopenBox.TabIndex = 1
            Me.btnReopenBox.Text = "REOPEN  BOX"
            '
            'btnReprintBoxLabel
            '
            Me.btnReprintBoxLabel.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnReprintBoxLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprintBoxLabel.ForeColor = System.Drawing.Color.Black
            Me.btnReprintBoxLabel.Location = New System.Drawing.Point(8, 288)
            Me.btnReprintBoxLabel.Name = "btnReprintBoxLabel"
            Me.btnReprintBoxLabel.Size = New System.Drawing.Size(168, 31)
            Me.btnReprintBoxLabel.TabIndex = 3
            Me.btnReprintBoxLabel.Text = "REPRINT BOX LABEL"
            '
            'pnlShipType
            '
            Me.pnlShipType.BackColor = System.Drawing.Color.SteelBlue
            Me.pnlShipType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlShipType.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboBoxTypes, Me.Label2, Me.cboModels, Me.Button5, Me.btnCreateBoxID, Me.Label1})
            Me.pnlShipType.Location = New System.Drawing.Point(3, 80)
            Me.pnlShipType.Name = "pnlShipType"
            Me.pnlShipType.Size = New System.Drawing.Size(421, 104)
            Me.pnlShipType.TabIndex = 117
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
            Me.cboBoxTypes.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboBoxTypes.ItemHeight = 15
            Me.cboBoxTypes.Location = New System.Drawing.Point(88, 32)
            Me.cboBoxTypes.MatchEntryTimeout = CType(2000, Long)
            Me.cboBoxTypes.MaxDropDownItems = CType(5, Short)
            Me.cboBoxTypes.MaxLength = 32767
            Me.cboBoxTypes.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboBoxTypes.Name = "cboBoxTypes"
            Me.cboBoxTypes.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboBoxTypes.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboBoxTypes.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboBoxTypes.Size = New System.Drawing.Size(240, 21)
            Me.cboBoxTypes.TabIndex = 1
            Me.cboBoxTypes.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            "aultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(8, 32)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(72, 23)
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
            Me.cboModels.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboModels.ItemHeight = 15
            Me.cboModels.Location = New System.Drawing.Point(88, 6)
            Me.cboModels.MatchEntryTimeout = CType(2000, Long)
            Me.cboModels.MaxDropDownItems = CType(5, Short)
            Me.cboModels.MaxLength = 32767
            Me.cboModels.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModels.Name = "cboModels"
            Me.cboModels.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModels.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModels.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModels.Size = New System.Drawing.Size(240, 21)
            Me.cboModels.TabIndex = 0
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
            "aultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'Button5
            '
            Me.Button5.BackColor = System.Drawing.Color.Black
            Me.Button5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Button5.Location = New System.Drawing.Point(985, 274)
            Me.Button5.Name = "Button5"
            Me.Button5.Size = New System.Drawing.Size(410, 409)
            Me.Button5.TabIndex = 66
            Me.Button5.TabStop = False
            Me.Button5.Text = "Generate Report"
            '
            'btnCreateBoxID
            '
            Me.btnCreateBoxID.BackColor = System.Drawing.Color.Green
            Me.btnCreateBoxID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCreateBoxID.ForeColor = System.Drawing.Color.White
            Me.btnCreateBoxID.Location = New System.Drawing.Point(88, 60)
            Me.btnCreateBoxID.Name = "btnCreateBoxID"
            Me.btnCreateBoxID.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnCreateBoxID.Size = New System.Drawing.Size(240, 32)
            Me.btnCreateBoxID.TabIndex = 3
            Me.btnCreateBoxID.Text = "CREATE BOX ID"
            Me.btnCreateBoxID.Visible = False
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(8, 10)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(72, 21)
            Me.Label1.TabIndex = 85
            Me.Label1.Text = "Model:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'panelPallet
            '
            Me.panelPallet.BackColor = System.Drawing.Color.SteelBlue
            Me.panelPallet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.panelPallet.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnFillBoxWithWHBox, Me.txtDevSN, Me.Label10, Me.btnCloseBox, Me.btnRemoveAllSNs, Me.btnRemoveSN, Me.lstDevices, Me.lblCount, Me.Label3, Me.lblBoxName, Me.lblBERReason})
            Me.panelPallet.Location = New System.Drawing.Point(424, 80)
            Me.panelPallet.Name = "panelPallet"
            Me.panelPallet.Size = New System.Drawing.Size(400, 448)
            Me.panelPallet.TabIndex = 119
            Me.panelPallet.Visible = False
            '
            'btnFillBoxWithWHBox
            '
            Me.btnFillBoxWithWHBox.BackColor = System.Drawing.Color.DarkOliveGreen
            Me.btnFillBoxWithWHBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnFillBoxWithWHBox.ForeColor = System.Drawing.Color.White
            Me.btnFillBoxWithWHBox.Location = New System.Drawing.Point(200, 312)
            Me.btnFillBoxWithWHBox.Name = "btnFillBoxWithWHBox"
            Me.btnFillBoxWithWHBox.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnFillBoxWithWHBox.Size = New System.Drawing.Size(152, 40)
            Me.btnFillBoxWithWHBox.TabIndex = 100
            Me.btnFillBoxWithWHBox.Text = "Fill Ship Box With Warehouse Box"
            Me.btnFillBoxWithWHBox.Visible = False
            '
            'txtDevSN
            '
            Me.txtDevSN.Location = New System.Drawing.Point(8, 64)
            Me.txtDevSN.Name = "txtDevSN"
            Me.txtDevSN.Size = New System.Drawing.Size(176, 20)
            Me.txtDevSN.TabIndex = 0
            Me.txtDevSN.Text = ""
            '
            'Label10
            '
            Me.Label10.BackColor = System.Drawing.Color.Transparent
            Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.White
            Me.Label10.Location = New System.Drawing.Point(8, 48)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(176, 16)
            Me.Label10.TabIndex = 99
            Me.Label10.Text = "Serial Number:"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnCloseBox
            '
            Me.btnCloseBox.BackColor = System.Drawing.Color.Green
            Me.btnCloseBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCloseBox.ForeColor = System.Drawing.Color.White
            Me.btnCloseBox.Location = New System.Drawing.Point(200, 392)
            Me.btnCloseBox.Name = "btnCloseBox"
            Me.btnCloseBox.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnCloseBox.Size = New System.Drawing.Size(152, 30)
            Me.btnCloseBox.TabIndex = 2
            Me.btnCloseBox.Text = "CLOSE BOX"
            '
            'btnRemoveAllSNs
            '
            Me.btnRemoveAllSNs.BackColor = System.Drawing.Color.Red
            Me.btnRemoveAllSNs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveAllSNs.ForeColor = System.Drawing.Color.White
            Me.btnRemoveAllSNs.Location = New System.Drawing.Point(200, 264)
            Me.btnRemoveAllSNs.Name = "btnRemoveAllSNs"
            Me.btnRemoveAllSNs.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveAllSNs.Size = New System.Drawing.Size(152, 30)
            Me.btnRemoveAllSNs.TabIndex = 4
            Me.btnRemoveAllSNs.Text = "REMOVE ALL SNs"
            '
            'btnRemoveSN
            '
            Me.btnRemoveSN.BackColor = System.Drawing.Color.Red
            Me.btnRemoveSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveSN.ForeColor = System.Drawing.Color.White
            Me.btnRemoveSN.Location = New System.Drawing.Point(200, 208)
            Me.btnRemoveSN.Name = "btnRemoveSN"
            Me.btnRemoveSN.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveSN.Size = New System.Drawing.Size(152, 30)
            Me.btnRemoveSN.TabIndex = 3
            Me.btnRemoveSN.Text = "REMOVE SN"
            '
            'lstDevices
            '
            Me.lstDevices.Location = New System.Drawing.Point(8, 88)
            Me.lstDevices.Name = "lstDevices"
            Me.lstDevices.Size = New System.Drawing.Size(176, 342)
            Me.lstDevices.TabIndex = 1
            '
            'lblCount
            '
            Me.lblCount.BackColor = System.Drawing.Color.Black
            Me.lblCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCount.ForeColor = System.Drawing.Color.Lime
            Me.lblCount.Location = New System.Drawing.Point(232, 136)
            Me.lblCount.Name = "lblCount"
            Me.lblCount.Size = New System.Drawing.Size(96, 43)
            Me.lblCount.TabIndex = 97
            Me.lblCount.Text = "0"
            Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(232, 120)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(96, 16)
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
            Me.lblBoxName.Location = New System.Drawing.Point(8, 7)
            Me.lblBoxName.Name = "lblBoxName"
            Me.lblBoxName.Size = New System.Drawing.Size(384, 33)
            Me.lblBoxName.TabIndex = 98
            Me.lblBoxName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblBERReason
            '
            Me.lblBERReason.BackColor = System.Drawing.Color.Black
            Me.lblBERReason.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblBERReason.Font = New System.Drawing.Font("Verdana", 8.25!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBERReason.ForeColor = System.Drawing.Color.Yellow
            Me.lblBERReason.Location = New System.Drawing.Point(192, 52)
            Me.lblBERReason.Name = "lblBERReason"
            Me.lblBERReason.Size = New System.Drawing.Size(200, 32)
            Me.lblBERReason.TabIndex = 99
            Me.lblBERReason.Text = "RUR - Invalid/Out of Date Proof of Purchase"
            Me.lblBERReason.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.lblBERReason.Visible = False
            '
            'lblScreenName
            '
            Me.lblScreenName.BackColor = System.Drawing.Color.Black
            Me.lblScreenName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblScreenName.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblScreenName.ForeColor = System.Drawing.Color.Yellow
            Me.lblScreenName.Location = New System.Drawing.Point(3, 1)
            Me.lblScreenName.Name = "lblScreenName"
            Me.lblScreenName.Size = New System.Drawing.Size(221, 79)
            Me.lblScreenName.TabIndex = 120
            Me.lblScreenName.Text = "TRACFONE BUILD SHIP BOX"
            Me.lblScreenName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Panel2
            '
            Me.Panel2.BackColor = System.Drawing.Color.Black
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblCostCenter, Me.lblUserName, Me.lblWorkDate, Me.lblShift, Me.lblMachine, Me.lblLineSide, Me.lblGroup, Me.lblLine, Me.Button2, Me.lblPassed})
            Me.Panel2.Location = New System.Drawing.Point(224, 0)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(602, 80)
            Me.Panel2.TabIndex = 126
            '
            'lblCostCenter
            '
            Me.lblCostCenter.BackColor = System.Drawing.Color.Transparent
            Me.lblCostCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCostCenter.ForeColor = System.Drawing.Color.Lime
            Me.lblCostCenter.Location = New System.Drawing.Point(418, 6)
            Me.lblCostCenter.Name = "lblCostCenter"
            Me.lblCostCenter.Size = New System.Drawing.Size(168, 22)
            Me.lblCostCenter.TabIndex = 101
            Me.lblCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblUserName
            '
            Me.lblUserName.BackColor = System.Drawing.Color.Transparent
            Me.lblUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblUserName.ForeColor = System.Drawing.Color.Lime
            Me.lblUserName.Location = New System.Drawing.Point(232, 7)
            Me.lblUserName.Name = "lblUserName"
            Me.lblUserName.Size = New System.Drawing.Size(184, 22)
            Me.lblUserName.TabIndex = 100
            Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblWorkDate
            '
            Me.lblWorkDate.BackColor = System.Drawing.Color.Transparent
            Me.lblWorkDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWorkDate.ForeColor = System.Drawing.Color.Lime
            Me.lblWorkDate.Location = New System.Drawing.Point(232, 28)
            Me.lblWorkDate.Name = "lblWorkDate"
            Me.lblWorkDate.Size = New System.Drawing.Size(184, 21)
            Me.lblWorkDate.TabIndex = 99
            Me.lblWorkDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblShift
            '
            Me.lblShift.BackColor = System.Drawing.Color.Transparent
            Me.lblShift.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblShift.ForeColor = System.Drawing.Color.Lime
            Me.lblShift.Location = New System.Drawing.Point(232, 48)
            Me.lblShift.Name = "lblShift"
            Me.lblShift.Size = New System.Drawing.Size(184, 22)
            Me.lblShift.TabIndex = 98
            Me.lblShift.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblMachine
            '
            Me.lblMachine.BackColor = System.Drawing.Color.Transparent
            Me.lblMachine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMachine.ForeColor = System.Drawing.Color.Lime
            Me.lblMachine.Location = New System.Drawing.Point(6, 48)
            Me.lblMachine.Name = "lblMachine"
            Me.lblMachine.Size = New System.Drawing.Size(221, 22)
            Me.lblMachine.TabIndex = 97
            Me.lblMachine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblLineSide
            '
            Me.lblLineSide.BackColor = System.Drawing.Color.Transparent
            Me.lblLineSide.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLineSide.ForeColor = System.Drawing.Color.Lime
            Me.lblLineSide.Location = New System.Drawing.Point(90, 28)
            Me.lblLineSide.Name = "lblLineSide"
            Me.lblLineSide.Size = New System.Drawing.Size(134, 21)
            Me.lblLineSide.TabIndex = 96
            Me.lblLineSide.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblGroup
            '
            Me.lblGroup.BackColor = System.Drawing.Color.Transparent
            Me.lblGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblGroup.ForeColor = System.Drawing.Color.Lime
            Me.lblGroup.Location = New System.Drawing.Point(6, 7)
            Me.lblGroup.Name = "lblGroup"
            Me.lblGroup.Size = New System.Drawing.Size(221, 22)
            Me.lblGroup.TabIndex = 95
            Me.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblLine
            '
            Me.lblLine.BackColor = System.Drawing.Color.Transparent
            Me.lblLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLine.ForeColor = System.Drawing.Color.Lime
            Me.lblLine.Location = New System.Drawing.Point(6, 28)
            Me.lblLine.Name = "lblLine"
            Me.lblLine.Size = New System.Drawing.Size(77, 21)
            Me.lblLine.TabIndex = 94
            Me.lblLine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Button2
            '
            Me.Button2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Button2.Location = New System.Drawing.Point(196, 334)
            Me.Button2.Name = "Button2"
            Me.Button2.Size = New System.Drawing.Size(274, 44)
            Me.Button2.TabIndex = 66
            Me.Button2.TabStop = False
            Me.Button2.Text = "Generate Report"
            '
            'lblPassed
            '
            Me.lblPassed.BackColor = System.Drawing.Color.Black
            Me.lblPassed.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPassed.ForeColor = System.Drawing.Color.Lime
            Me.lblPassed.Location = New System.Drawing.Point(418, 37)
            Me.lblPassed.Name = "lblPassed"
            Me.lblPassed.Size = New System.Drawing.Size(168, 32)
            Me.lblPassed.TabIndex = 84
            Me.lblPassed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'frmBuildShipPallet
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(832, 541)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.PanelPalletList, Me.pnlShipType, Me.panelPallet, Me.lblScreenName, Me.Panel2})
            Me.Name = "frmBuildShipPallet"
            Me.Text = "frmBuildShipPallet"
            Me.PanelPalletList.ResumeLayout(False)
            CType(Me.dbgPallets, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlShipType.ResumeLayout(False)
            CType(Me.cboBoxTypes, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboModels, System.ComponentModel.ISupportInitialize).EndInit()
            Me.panelPallet.ResumeLayout(False)
            Me.Panel2.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        '********************************************************************
        Private Sub frmTracFone_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Const ProdID As Integer = 1
            Dim dt As DataTable
            Dim i As Integer = 0

            Try
                '*****************************
                'check computer mapping
                '*****************************
                i = CheckIfMachineTiedToLine()
                'If i = 0 Then
                '    MessageBox.Show("Machine is not associated with any 'Line'. Can't continue.", "Validate Computer", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                '    Me.Close()
                'ElseIf Me.iGroup_ID <> 85 Then
                '    MessageBox.Show("Machine is not map to TracFone group.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                '    Me.Close()
                'End If

                '******************************************
                'populate data to dropdown list controls
                '******************************************
                dt = Me._objTFBuildShipPallet.GetModelsWithMotoSku()
                Misc.PopulateC1DropDownList(Me.cboModels, dt, "Model_Desc", "Model_ID")

                Generic.DisposeDT(dt)
                dt = Me._objTFBuildShipPallet.GetTracFoneShipBoxTypes()
                Misc.PopulateC1DropDownList(Me.cboBoxTypes, dt, "ShipTypeLDesc", "ShipTypeID")
                Me.cboBoxTypes.SelectedValue = 0

                '******************************************
                'Special Access
                '******************************************
                If PSS.Core.ApplicationUser.GetPermission("TFShipReturnUnit") > 0 Then _booAccessToFillBoxWithWHBox = True

                '******************************************
                Me.cboModels.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "FormLoad", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '********************************************************************
        Private Sub cbos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboModels.KeyUp, cboBoxTypes.KeyUp
            Try
                If e.KeyCode = Keys.Enter Then
                    Me.btnFillBoxWithWHBox.Visible = False
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
                            Me.cboBoxTypes.Text = ""
                        End If
                    ElseIf sender.name.trim = "cboBoxTypes" Then
                        If Not IsNothing(Me.cboBoxTypes.SelectedValue) AndAlso Me.cboBoxTypes.SelectedValue >= 0 AndAlso Me.cboModels.SelectedValue > 0 Then
                            Dim iShipType As Integer = Me.cboBoxTypes.SelectedValue
                            Me.PopulateOpenBoxs()
                            Me.cboBoxTypes.SelectedValue = iShipType
                            If IsNothing(Me.dbgPallets.DataSource) OrElse Me.dbgPallets.DataSource.Table.select("Pallet_SkuLen = '' AND Pallet_ShipType = " & iShipType).length = 0 Then Me.btnCreateBoxID.Visible = True Else Me.btnCreateBoxID.Visible = False
                        Else
                            Me.btnCreateBoxID.Visible = False
                        End If
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
                    dt = Me._objTFBuildShipPallet.GetTFOpenPallets(Me.cboModels.SelectedValue)
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
                .Splits(0).DisplayColumns("Box Name").Width = 160
                .Splits(0).DisplayColumns("BER Reason").Width = 200

                'Make some columns invisible
                .Splits(0).DisplayColumns("Box Name").Visible = True
                .Splits(0).DisplayColumns("BER Reason").Visible = True

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
            Dim strModelShortName As String = ""
            Dim iPallettID As Integer = 0

            Try
                If IsNothing(Me.cboModels.SelectedValue) OrElse Me.cboModels.SelectedValue = 0 Then
                    MessageBox.Show("Please select model.", "Create Box ID", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboModels.Focus()
                ElseIf IsNothing(Me.cboBoxTypes.SelectedValue) Then
                    MessageBox.Show("Please select Box Type.", "Create Box ID", MessageBoxButtons.OK, MessageBoxIcon.Stop)
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
                    '2: Get and validate Model short name
                    '**********************************
                    strModelShortName = Me.GetModelShortName()

                    If strModelShortName.Trim.Length <> 0 Then

                        iModelID = Me.cboModels.SelectedValue
                        iBoxType = Me.cboBoxTypes.SelectedValue

                        'check for open pallet
                        If Me._objTFBuildShipPallet.IsOpenBoxExisted(iModelID, iBoxType, Me._iMachineCC_GrpID) = False Then
                            iPallettID = Me._objTFBuildShipPallet.CreateBoxID(iModelID, iBoxType, strModelShortName & Me.cboBoxTypes.DataSource.Table.Select("ShipTypeID = " & Me.cboBoxTypes.SelectedValue)(0)("ShipTypeSDesc"))
                            Me.PopulateOpenBoxs(iPallettID)
                        Else
                            MessageBox.Show("An open box is currently availalbe to fill for selected Model and Box Type combination.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.PopulateOpenBoxs()
                            Me.txtDevSN.Focus()
                        End If  'check if there is an box available to fill

                        If Me.cboBoxTypes.SelectedValue = 12 AndAlso Me._booAccessToFillBoxWithWHBox = True Then Me.btnFillBoxWithWHBox.Visible = True
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
                If dtBoxType.Select("ShipTypeLDesc = '" & Me.cboBoxTypes.Text & "'").Length = 0 Then
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
                Me.lblBERReason.Text = ""
                Me.lblBoxName.Text = ""
                Me.lblCount.Text = "0"
                Me.txtDevSN.Text = ""
                Me.lstDevices.DataSource = Nothing
                Me.panelPallet.Visible = True
                Me.btnCreateBoxID.Visible = False
                Me.btnFillBoxWithWHBox.Visible = False

                If Me.dbgPallets.Columns.Count = 0 OrElse Me.dbgPallets.RowCount = 0 Then
                    Me.panelPallet.Visible = False
                    Exit Sub
                End If
                If Me.dbgPallets.Columns("Box Name").Value.ToString.Trim = "" Then
                    Exit Sub
                End If

                Me.lblBoxName.Text = Me.dbgPallets.Columns("Box Name").Value.ToString

                '**********************************
                'Display BER Reason
                '**********************************
                If Me.dbgPallets.Columns("Pallet_ShipType").Value = 1 Then
                    Me.lblBERReason.Text = Me.dbgPallets.Columns("BER Reason").Value
                    Me.lblBERReason.Visible = True
                Else
                    Me.lblBERReason.Text = ""
                    Me.lblBERReason.Visible = False
                End If
                '**********************************

                Select Case Me.dbgPallets.Columns("Pallet_ShipType").Value.ToString
                    Case "0"    'REFURBISHED
                        Me.cboBoxTypes.SelectedValue = 0
                        'Me.cboFreqs.SelectedValue = CInt(Me.dbgPallets.Columns("Pallet_SkuLen").Value.ToString)
                        Me.Enabled = True
                    Case Else
                        Me.cboBoxTypes.SelectedValue = CInt(Me.dbgPallets.Columns("Pallet_ShipType").Value.ToString)
                        ' Me.cboFreqs.SelectedValue = 0
                        'Me.cboFreqs.Enabled = False
                        If Me.cboBoxTypes.SelectedValue = 12 AndAlso Me._booAccessToFillBoxWithWHBox = True Then Me.btnFillBoxWithWHBox.Visible = True
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
                'Get all devices add put them in them in list box for a pallet

                dt1 = objMisc.GetAllSNsForPallet(iPallet_ID)
                Me.lstDevices.DataSource = dt1.DefaultView
                Me.lstDevices.ValueMember = dt1.Columns("device_id").ToString
                Me.lstDevices.DisplayMember = dt1.Columns("device_sn").ToString
                Me.lblBoxName.Text = strPalletName

                '*******************************************
                Me.lblCount.Text = dt1.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt1)
                Me.txtDevSN.Focus()
            End Try
        End Sub

        '********************************************************************
        Private Sub txtDevSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDevSN.KeyUp
            Try
                If e.KeyCode = Keys.Enter Then
                    If Me.txtDevSN.Text.Trim.Length > 0 Then Me.ProcessTracFoneSN()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtDevSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************
        Private Sub ProcessTracFoneSN()
            Dim i As Integer = 0
            Dim strSN As String = Me.txtDevSN.Text.Trim.ToUpper
            Dim dtDevice As DataTable
            Dim booFailUnitHasPart As Boolean = False
            Dim strBERBillcodeID As String = ""
            Dim booRefreshBoxes As Boolean = False

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

                '***************************************************
                'Step 1: Check if the Device is already scanned in
                For i = 0 To Me.lstDevices.Items.Count - 1
                    If UCase(Trim(Me.lstDevices.Items(i).ToString)) = strSN.Trim.ToUpper Then
                        MsgBox("This device is already scanned in. Try another one.", MsgBoxStyle.Information, "Device Scan")
                        Me.txtDevSN.Text = ""
                        Me.txtDevSN.Focus()
                        Exit Sub
                    End If
                Next

                '***************************************************
                If Me.lstDevices.Items.Count > 89 Then
                    Throw New Exception("Box can't contain more than 90 units.")
                End If
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

                dtDevice = Me._objTFBuildShipPallet.GetDeviceInfoInWIP(Me.txtDevSN.Text.Trim, CInt(Me.dbgPallets.Columns("Loc_ID").Value))

                If dtDevice.Rows.Count > 1 Then
                    MsgBox("This device existed twice in the system. Please contact IT.", MsgBoxStyle.Information, "Information")
                    Me.txtDevSN.SelectAll()
                    Exit Sub
                ElseIf dtDevice.Rows.Count = 0 Then
                    MsgBox("This device does not exist in the system, already ship or belong to a different customer.", MsgBoxStyle.Information, "Information")
                    Me.txtDevSN.SelectAll()
                    Exit Sub
                Else
                    If Me.cboBoxTypes.SelectedValue = 0 AndAlso dtDevice.Rows(0)("WorkStation").ToString.Trim.ToUpper <> Me._strScreenName.Trim.ToUpper Then
                        MessageBox.Show("The device belongs to " & dtDevice.Rows(0)("WorkStation").ToString & " workstation.", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.txtDevSN.Text = ""
                        Exit Sub
                    ElseIf Me.cboBoxTypes.SelectedValue = 10 AndAlso dtDevice.Rows(0)("WorkStation").ToString.Trim.ToUpper <> "FUNCTIONAL FAIL BS" Then
                        MessageBox.Show("The device is not FUNCTIONAL FAIL BS.", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.txtDevSN.Text = ""
                        Exit Sub
                    ElseIf Me.cboBoxTypes.SelectedValue = 11 AndAlso dtDevice.Rows(0)("WorkStation").ToString.Trim.ToUpper <> "FUNCTIONAL FAIL CP" Then
                        MessageBox.Show("The device is not FUNCTIONAL FAIL CP.", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.txtDevSN.Text = ""
                        Exit Sub
                    ElseIf Me.cboBoxTypes.SelectedValue = 1 AndAlso dtDevice.Rows(0)("WorkStation").ToString.Trim.ToUpper <> "BER HOLD" Then
                        MessageBox.Show("Device must come from BER HOLD bucket.", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.txtDevSN.Text = ""
                        Exit Sub
                    End If

                    If Not IsDBNull(dtDevice.Rows(0)("Pallett_ID")) Then
                        MsgBox("This device already has assigned into a box ID (" & dtDevice.Rows(0)("Pallett_ID") & ").", MsgBoxStyle.Information, "Information")
                        Me.txtDevSN.Text = ""
                    ElseIf dtDevice.Rows(0)("Model_Desc") <> Me.dbgPallets.Columns("Model_Desc").Value Then
                        MsgBox("Wrong Model.", MsgBoxStyle.Information, "Information")
                        Me.txtDevSN.Text = ""
                    ElseIf CInt(Me.dbgPallets.Columns("Pallet_ShipType").Value) = 0 AndAlso IsDBNull(dtDevice.Rows(0)("Device_DateBill")) Then
                        MsgBox("This device has not been billed.", MsgBoxStyle.Information, "Information")
                        Me.txtDevSN.Text = ""
                    ElseIf Me._objTFBuildShipPallet.CheckDeviceShipType(CInt(Me.dbgPallets.Columns("Pallet_ShipType").Value), dtDevice.Rows(0)("Device_ID"), booFailUnitHasPart) = False Then
                        Me.txtDevSN.SelectAll()
                    ElseIf CInt(Me.dbgPallets.Columns("Pallet_ShipType").Value) = 0 AndAlso Generic.IsValidQCResults(dtDevice.Rows(0)("Device_ID"), 2, "FQA", False) = False Then    'must Final passed
                        Me.txtDevSN.Text = ""
                    Else
                        Me.Enabled = False
                        Cursor.Current = Cursors.WaitCursor

                        '***************************************
                        'Remove all part if Unit Pallett is BER
                        '***************************************
                        If CInt(Me.dbgPallets.Columns("Pallet_ShipType").Value) = 1 AndAlso booFailUnitHasPart = True Then
                            Me.RemoveAllParts(dtDevice.Rows(0)("Device_ID"))
                        End If

                        '*****************************************
                        'Set pallett sku length
                        '*****************************************
                        If CInt(Me.dbgPallets.Columns("Pallet_ShipType").Value) = 1 Then
                            strBERBillcodeID = Me._objTFBuildShipPallet.GetBERBillcodeID(Convert.ToInt32(dtDevice.Rows(0)("Device_ID")))
                            If Me.lstDevices.Items.Count = 0 Then
                                If Me.dbgPallets.DataSource.Table.Select("Pallet_ShipType = 1 AND Model_ID = " & Me.dbgPallets.Columns("Model_ID").Value & " AND Pallet_SkuLen = '" & strBERBillcodeID & "'").length > 0 Then
                                    MessageBox.Show("Please close all the open box(s) before start the new box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                    Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus() : Exit Sub
                                End If
                                Me._objTFBuildShipPallet.SetPalletSkuLen(CInt(Me.dbgPallets.Columns("Pallett_id").Value), strBERBillcodeID)
                                booRefreshBoxes = True

                                'Disable this 08-27-2012
                                'ElseIf Me.lstDevices.Items.Count > 0 AndAlso Me.dbgPallets.Columns("Pallet_SkuLen").Value <> strBERBillcodeID.Trim Then
                                '    MessageBox.Show("BER reason does not match.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                '    Me.Enabled = True : Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus() : Exit Sub
                            End If
                        End If

                        '***************************************************
                        'if above all is fine then add it to the list and update the database
                        i = PSS.Data.Production.Shipping.AssignDeviceToPallet(dtDevice.Rows(0)("Device_ID"), CInt(Me.dbgPallets.Columns("Pallett_ID").Value))

                        '***************************************************
                        Me.RefreshSNList()
                        If booRefreshBoxes = True Then Me.PopulateOpenBoxs(CInt(Me.dbgPallets.Columns("Pallett_id").Value))
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
        Private Sub btnFillBoxWithWHBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFillBoxWithWHBox.Click
            Dim i As Integer = 0
            Dim strWHBox As String = ""
            Dim dt As DataTable

            Try
                '************************
                'Validations
                If CInt(Me.dbgPallets.Columns("Pallett_ID").Value) = 0 Then
                    Throw New Exception("Box Name is not selected.")
                ElseIf Me.dbgPallets.Columns("Box Name").Value.ToString.Trim = "" Then
                    Throw New Exception("Box Name is not selected.")
                ElseIf Me.dbgPallets.Columns("Pallet_ShipType").Value <> 12 Then
                    Throw New Exception("This function only apply to forward to repair box type.")
                End If

                '***************************************************
                If CInt(Me.dbgPallets.Columns("Pallet_ShipType").Value) <> 1 AndAlso Me.lstDevices.Items.Count > 89 Then
                    Throw New Exception("Box can't contain more than 90 units.")
                End If
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

                strWHBox = InputBox("Enter Warehouse Box:").Trim
                If strWHBox.Trim.Length = 0 Then
                    Me.txtDevSN.SelectAll()
                    Me.txtDevSN.Focus()
                    Exit Sub
                End If

                'Get Warehouse box
                dt = Me._objTFBuildShipPallet.GetTracFoneDeviceInWHBox(strWHBox)

                If dt.Rows.Count = 0 Then
                    MsgBox("This box is empty.", MsgBoxStyle.Information, "Information")
                    Exit Sub
                ElseIf dt.Select("Workstation = 'WH-WIP'").Length <> dt.Rows.Count Then
                    MsgBox("Some units in this box are not in 'WH-WIP'.", MsgBoxStyle.Information, "Information")
                    Exit Sub
                ElseIf dt.Select("Pallett_ID > 0").Length > 0 Then
                    MsgBox("Some units in this box have already assigned to ship box(" & dt.Select("Pallett_ID > 0")(0)("Pallett_ID") & ").", MsgBoxStyle.Information, "Information")
                    Exit Sub
                ElseIf dt.Select("cust_model_number <> '" & Me.dbgPallets.Columns("Model_Desc").Value & "'").Length > 0 Then
                    MsgBox("Devices in this box have different model with ship box.", MsgBoxStyle.Information, "Information")
                    Exit Sub
                ElseIf (dt.Rows.Count + Me.lstDevices.Items.Count) > 90 Then
                    MsgBox("Box can't contain more than 90 units.", MsgBoxStyle.Information, "Information")
                    Exit Sub
                Else
                    If MessageBox.Show("Qty: " & dt.Rows.Count & " unit will be assigned to ship box " & Me.dbgPallets.Columns("Box Name").Value & Environment.NewLine & "Would you like to continue?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then Exit Sub

                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor

                    '***************************************************
                    'if above all is fine then add it to the list and update the database
                    i = Me._objTFBuildShipPallet.AssignDeviceInWHBoxToPallet(strWHBox, CInt(Me.dbgPallets.Columns("Pallett_ID").Value))

                    '***************************************************
                    Me.RefreshSNList()
                    Me.Enabled = True
                    Cursor.Current = Cursors.Default
                    Me.txtDevSN.Text = ""
                    Me.txtDevSN.Focus()
                End If

            Catch ex As Exception
                MessageBox.Show("ProcessSN: " & ex.Message, "Device Scan", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.txtDevSN.Text = ""
                Me.txtDevSN.Focus()
            Finally
                Generic.DisposeDT(dt)
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        '********************************************************************
        Private Sub txtDevSN_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDevSN.KeyPress
            Try
                If Not (e.KeyChar.IsLetterOrDigit(e.KeyChar) Or e.KeyChar.IsControl(e.KeyChar)) Then
                    e.Handled = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtSN_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************
        Private Sub btnCloseBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseBox.Click
            Dim i, iFailStation As Integer
            Dim strNextWrkStation As String = ""
            Dim iDeviceID As Integer = 0

            Try
                i = 0 : iFailStation = 0
                '************************
                'Validations
                If CInt(Me.dbgPallets.Columns("Pallett_id").Value) = 0 Then
                    Throw New Exception("Box name is not selected.")
                ElseIf Me.dbgPallets.Columns("Box Name").Value.ToString.Trim = "" Then
                    Throw New Exception("Box name is not selected.")
                ElseIf Me.lstDevices.Items.Count = 0 Then
                    MessageBox.Show("This box is empty.", "Close Box", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.txtDevSN.Focus() : Exit Sub
                ElseIf Me.lstDevices.Items.Count > 90 Then
                    MessageBox.Show("Box can't contain more than 90 units.", "Close Box", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.txtDevSN.Focus() : Exit Sub
                ElseIf Me.IsValidBoxTypeSelection = False Then
                    MessageBox.Show("Invalid Box type. Please select Box Name again.", "Close Box", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                ElseIf MessageBox.Show("Are you sure you want to close this box?", "Close Box", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Exit Sub
                End If

                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                i = objMisc.ClosePallet(PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, CInt(Me.dbgPallets.Columns("Pallett_ID").Value), Me.dbgPallets.Columns("Box Name").Value, Me.lstDevices.Items.Count, Me.dbgPallets.Columns("Pallet_ShipType").Value, 0, )
                If i = 0 Then
                    Throw New Exception("Box has not closed yet due to an error. Please contact IT.")
                End If

                Me.cboBoxTypes.SelectedValue = CInt(Me.dbgPallets.Columns("Pallet_ShipType").Value)
                'PSS.Data.Production.Shipping.PrintPalletLicensePlate(Me.dbgPallets.Columns("Box Name").Value, Me.dbgPallets.Columns("Model_ID").Value, Me.cboBoxTypes.Text, Me.lstDevices.Items.Count, 3)

                '************************
                'Push units to next station
                '************************
                If Me._iMenuCustID > 0 Then
                    If CInt(Me.dbgPallets.Columns("Pallet_ShipType").Value) > 0 Then iFailStation = 1
                    strNextWrkStation = Generic.GetNextWorkStationInWFP(Me._strScreenName, 0, Me._iMenuCustID, iFailStation, )
                    If strNextWrkStation.Trim.Length > 0 Then Generic.SetTcelloptWorkStationForPallet(strNextWrkStation, CInt(Me.dbgPallets.Columns("Pallett_ID").Value))
                End If

                '************************
                'Print 4 x 4 Box Label
                '************************
                Me._objTFBuildShipPallet.PrintBoxLabel(CInt(Me.dbgPallets.Columns("Pallett_id").Value), CInt(Me.dbgPallets.Columns("Pallet_ShipType").Value))

                'Refresh Pallet (Box) 
                Me.PopulateOpenBoxs()

                '******************************
                'Reset Screen control properties.
                Me.lblBoxName.Text = ""
                Me.lblCount.Text = 0
                Me.lstDevices.DataSource = Nothing
                Me.panelPallet.Visible = False
                Me.btnFillBoxWithWHBox.Visible = False
                '******************************
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnCloseBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
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

                    '*****************************************
                    'Set pallett sku length
                    '*****************************************
                    If Me.lstDevices.Items.Count = 0 Then
                        Me._objTFBuildShipPallet.SetPalletSkuLen(CInt(Me.dbgPallets.Columns("Pallett_id").Value), "")
                        Me.PopulateOpenBoxs(CInt(Me.dbgPallets.Columns("Pallett_id").Value))
                    End If
                    '*****************************************
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

                '*****************************************
                'Set pallett sku length
                '*****************************************
                If Me.lstDevices.Items.Count = 0 Then
                    Me._objTFBuildShipPallet.SetPalletSkuLen(CInt(Me.dbgPallets.Columns("Pallett_id").Value), "")
                    Me.PopulateOpenBoxs(CInt(Me.dbgPallets.Columns("Pallett_id").Value))
                End If
                '*****************************************
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
            Dim strCurrentStation As String = ""

            Try
                '************************
                strPallet = InputBox("Enter Box ID.", "Reopen Box")
                If strPallet = "" Then
                    Throw New Exception("Please enter a Box ID if you want to re-open it.")
                End If

                'Refresh open box list
                Me.PopulateOpenBoxs()

                dt = Me._objTFBuildShipPallet.GetTracFonePallet(strPallet)
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Box does not exist in the system or has been removed from the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf dt.Rows.Count > 1 Then
                    MessageBox.Show("Box name existed more than one in the system. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf Not IsDBNull(dt.Rows(0)("Pallett_ShipDate")) Then
                    MessageBox.Show("Box has been shipped. Not allow to reopen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf dt.Rows(0)("Pallett_ReadyToShipFlg") = 0 Then
                    MessageBox.Show("Box is already open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf Not IsNothing(Me.dbgPallets.DataSource) AndAlso Me.dbgPallets.RowCount > 0 AndAlso Me.dbgPallets.DataSource.Table.Select("Model_ID = " & dt.Rows(0)("Model_ID") & " AND Pallet_SkuLen = '" & dt.Rows(0)("Pallet_SkuLen") & "' AND Pallet_ShipType = " & dt.Rows(0)("Pallet_ShipType")).Length > 0 Then
                    MessageBox.Show("There is an open box in the list.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    If Me._objTFBuildShipPallet.GetWorkStationCountInPallet(dt.Rows(0)("Pallett_ID")) > 1 Then
                        MessageBox.Show("Box contains units with different workstation. Please contact IT>", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        'Reset work-station
                        If CInt(dt.Rows(0)("Pallet_ShipType")) = 1 Then
                            strCurrentStation = "UNWORKABLE"
                        Else
                            strCurrentStation = Me._strScreenName
                        End If

                        i = Me._objTFBuildShipPallet.ReopenTFBox(dt.Rows(0)("Pallett_ID"), strCurrentStation)
                        If i = 0 Then
                            Throw New Exception("Box was not reopened.")
                        End If

                        Me.cboModels.SelectedValue = dt.Rows(0)("Model_ID")
                        Me.cboBoxTypes.SelectedValue = dt.Rows(0)("Pallet_ShipType")

                        'Refresh Pallet( Box )
                        Me.PopulateOpenBoxs(dt.Rows(0)("Pallett_ID"))

                        '************************
                        Me.lstDevices.DataSource = Nothing
                        Me.lblCount.Text = "0"
                        Me.lblBoxName.Text = ""
                        Me.panelPallet.Visible = False
                        '************************
                        Me.txtDevSN.Focus()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Reopen Box.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
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

            Try
                str_pallett = InputBox("Enter Box Name.", "Reprint Box Label")
                If str_pallett = "" Then
                    Throw New Exception("Please enter a Box Name if you want to reprint the box label.")
                End If

                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor
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
                        strPalletType = "BER"
                    ElseIf R1("Pallet_ShipType") = 12 Then
                        strPalletType = "FTR"
                    Else
                        MessageBox.Show("System can't define Box Type.", "Information", MessageBoxButtons.OK)
                        Exit Sub
                    End If

                    If Not IsDBNull(R1("Cust_ID")) Then
                        '_objMisc.PrintPalletDeviceCountRpt(R1("Pallett_ID"), R1("Cust_ID"), 1)
                        Me._objTFBuildShipPallet.PrintBoxLabel(R1("Pallett_ID"), R1("Pallet_ShipType"))

                        If R1("AQL_QCResult_ID") = 2 Then Me._objTFBuildShipPallet.SetAQLResultOfBox(R1("Pallett_ID"), 1)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Reprint Box Label.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                R1 = Nothing
                If Not IsNothing(dtPallettInfo) Then
                    dtPallettInfo.Dispose()
                    dtPallettInfo = Nothing
                End If
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        '**************************************************************************************************
        Private Function CheckIfMachineTiedToLine() As Integer
            Dim dt1 As DataTable
            Dim R1 As DataRow

            Try
                dt1 = objMisc.CheckIfMachineTiedToLine(strMachine)
                If dt1.Rows.Count = 0 Then
                    Return 0
                End If

                For Each R1 In dt1.Rows
                    iGroup_ID = R1("Group_ID")
                    strGroup = Trim(R1("Group_Desc"))
                    iLine_ID = R1("Line_ID")
                    strLineNumber = Trim(R1("Line_Number"))
                    iLineSide_ID = R1("LineSide_ID")
                    strLineSide = Trim(R1("LineSide_Desc"))
                    'strBin = Trim(R1("WC_Location"))
                    iWCLocation_ID = R1("WCLocation_ID")
                Next R1

                Me.lblGroup.Text = "Group: " & strGroup
                Me.lblLine.Text = strLineNumber
                Me.lblLineSide.Text = strLineSide
                Me.lblMachine.Text = "Machine: " & strMachine
                Me.lblUserName.Text = "User: " & strUserName
                Me.lblShift.Text = "Shift: " & iShiftID
                Me.lblWorkDate.Text = "Work Date: " & Format(CDate(strWorkDate), "MM/dd/yyyy")
                'Me.lblBin.Text = "BIN: " & strBin

                Return 1
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                PSS.Data.Buisness.Generic.DisposeDT(dt1)
            End Try
        End Function

        '********************************************************************
        Private Function RemoveAllParts(ByVal iDeviceID As Integer) As Integer
            Dim objDevice As Rules.Device
            Dim dtParts As DataTable
            Dim R1 As DataRow
            Dim objTFMisc As New PSS.Data.Buisness.TracFone.clsMisc()

            Try
                'Delete all parts
                dtParts = objTFMisc.GetPartsOfDevice(iDeviceID)
                If dtParts.Rows.Count > 0 Then
                    objDevice = New Rules.Device(iDeviceID)
                    For Each R1 In dtParts.Rows
                        objDevice.DeletePart(R1("Billcode_ID"))
                    Next R1
                    objDevice.Update()
                End If
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(objDevice) Then
                    objDevice.Dispose()
                    objDevice = Nothing
                End If
            End Try
        End Function

        '********************************************************************

    End Class
End Namespace