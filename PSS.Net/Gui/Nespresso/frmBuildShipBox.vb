Option Explicit On 

Imports PSS.Data
Imports PSS.Data.Buisness
Imports PSS.Core

Namespace Gui.Nespresso
    Public Class frmBuildShipBox
        Inherits System.Windows.Forms.Form

        Private _objNespresso As New PSS.Data.Buisness.Nespresso.Nespresso()
        Private _objShip As New PSS.Data.Production.Shipping()
        Private _objMisc As New PSS.Data.Buisness.Misc()
        Private _LocID = PSS.Data.Buisness.Nespresso.Nespresso.intLocID
        Private _MfgID = PSS.Data.Buisness.Nespresso.Nespresso.intMfgID
        Private _ProdID = PSS.Data.Buisness.Nespresso.Nespresso.intProdID
        Private _CusID = PSS.Data.Buisness.Nespresso.Nespresso.intCustID
        Private _strShortCustDesc As String = PSS.Data.Buisness.Nespresso.Nespresso.ShortCustDesc
        Private _strShortModelName As String = ""
        Private _Pallet_ID As Integer = 0
        Private _booPopulateDataToCtrl As Boolean = False

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

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
        Friend WithEvents _Tittle As System.Windows.Forms.Label
        Friend WithEvents _Model As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents _ShipType As System.Windows.Forms.Label
        Friend WithEvents lblSkuLen As System.Windows.Forms.Label
        Friend WithEvents txtSN As System.Windows.Forms.TextBox
        Friend WithEvents lblCount As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents lblPalletName As System.Windows.Forms.Label
        Friend WithEvents _Serial As System.Windows.Forms.Label
        Friend WithEvents btnRemoveAll As System.Windows.Forms.Button
        Friend WithEvents btnRemove As System.Windows.Forms.Button
        Friend WithEvents lstSerials As System.Windows.Forms.ListBox
        Friend WithEvents pnlCreatePallet As System.Windows.Forms.GroupBox
        Friend WithEvents btnRefreshOpenPallets As System.Windows.Forms.Button
        Friend WithEvents btnSelectPallet As System.Windows.Forms.Button
        Friend WithEvents btnCreatePallet As System.Windows.Forms.Button
        Friend WithEvents pnlOpenPallets As System.Windows.Forms.GroupBox
        Friend WithEvents pnlPalletInfo As System.Windows.Forms.GroupBox
        Friend WithEvents gdOpenPallets As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnDeletePallet As System.Windows.Forms.Button
        Friend WithEvents btnReopenPallet As System.Windows.Forms.Button
        Friend WithEvents btnClearPallet As System.Windows.Forms.Button
        Friend WithEvents cboModels As C1.Win.C1List.C1Combo
        Friend WithEvents cboShipType As C1.Win.C1List.C1Combo
        Friend WithEvents cboSkuLen As C1.Win.C1List.C1Combo
        Friend WithEvents btnClosePallet As System.Windows.Forms.Button
        Friend WithEvents btnReprintPalletLabel As System.Windows.Forms.Button
        Friend WithEvents pnlMain As System.Windows.Forms.Panel
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmBuildShipBox))
            Me._Tittle = New System.Windows.Forms.Label()
            Me._Model = New System.Windows.Forms.Label()
            Me._ShipType = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.pnlCreatePallet = New System.Windows.Forms.GroupBox()
            Me.cboSkuLen = New C1.Win.C1List.C1Combo()
            Me.cboShipType = New C1.Win.C1List.C1Combo()
            Me.cboModels = New C1.Win.C1List.C1Combo()
            Me.btnClearPallet = New System.Windows.Forms.Button()
            Me.btnCreatePallet = New System.Windows.Forms.Button()
            Me.pnlOpenPallets = New System.Windows.Forms.GroupBox()
            Me.btnRefreshOpenPallets = New System.Windows.Forms.Button()
            Me.btnDeletePallet = New System.Windows.Forms.Button()
            Me.gdOpenPallets = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnReopenPallet = New System.Windows.Forms.Button()
            Me.pnlPalletInfo = New System.Windows.Forms.GroupBox()
            Me.btnReprintPalletLabel = New System.Windows.Forms.Button()
            Me.lblSkuLen = New System.Windows.Forms.Label()
            Me.txtSN = New System.Windows.Forms.TextBox()
            Me._Serial = New System.Windows.Forms.Label()
            Me.btnClosePallet = New System.Windows.Forms.Button()
            Me.btnRemoveAll = New System.Windows.Forms.Button()
            Me.btnRemove = New System.Windows.Forms.Button()
            Me.lstSerials = New System.Windows.Forms.ListBox()
            Me.lblCount = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.lblPalletName = New System.Windows.Forms.Label()
            Me.btnSelectPallet = New System.Windows.Forms.Button()
            Me.pnlMain = New System.Windows.Forms.Panel()
            Me.pnlCreatePallet.SuspendLayout()
            CType(Me.cboSkuLen, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboShipType, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboModels, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlOpenPallets.SuspendLayout()
            CType(Me.gdOpenPallets, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlPalletInfo.SuspendLayout()
            Me.pnlMain.SuspendLayout()
            Me.SuspendLayout()
            '
            '_Tittle
            '
            Me._Tittle.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me._Tittle.BackColor = System.Drawing.Color.Black
            Me._Tittle.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me._Tittle.ForeColor = System.Drawing.Color.Yellow
            Me._Tittle.Name = "_Tittle"
            Me._Tittle.Size = New System.Drawing.Size(854, 48)
            Me._Tittle.TabIndex = 121
            Me._Tittle.Text = "Nespresso Build Ship Pallets"
            Me._Tittle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            '_Model
            '
            Me._Model.BackColor = System.Drawing.Color.Transparent
            Me._Model.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
            Me._Model.ForeColor = System.Drawing.Color.Black
            Me._Model.Location = New System.Drawing.Point(120, 8)
            Me._Model.Name = "_Model"
            Me._Model.Size = New System.Drawing.Size(64, 21)
            Me._Model.TabIndex = 123
            Me._Model.Text = "Model :"
            Me._Model.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            '_ShipType
            '
            Me._ShipType.BackColor = System.Drawing.Color.Transparent
            Me._ShipType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me._ShipType.ForeColor = System.Drawing.Color.Black
            Me._ShipType.Location = New System.Drawing.Point(96, 40)
            Me._ShipType.Name = "_ShipType"
            Me._ShipType.Size = New System.Drawing.Size(86, 19)
            Me._ShipType.TabIndex = 125
            Me._ShipType.Text = "Ship Type:"
            Me._ShipType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label8
            '
            Me.Label8.BackColor = System.Drawing.Color.Transparent
            Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.Black
            Me.Label8.Location = New System.Drawing.Point(96, 72)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(88, 19)
            Me.Label8.TabIndex = 127
            Me.Label8.Text = "SKU Length:"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'pnlCreatePallet
            '
            Me.pnlCreatePallet.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.pnlCreatePallet.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
            Me.pnlCreatePallet.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboSkuLen, Me.cboShipType, Me.cboModels, Me.btnClearPallet, Me.btnCreatePallet, Me._Model, Me._ShipType, Me.Label8})
            Me.pnlCreatePallet.Location = New System.Drawing.Point(420, 0)
            Me.pnlCreatePallet.Name = "pnlCreatePallet"
            Me.pnlCreatePallet.Size = New System.Drawing.Size(400, 144)
            Me.pnlCreatePallet.TabIndex = 125
            Me.pnlCreatePallet.TabStop = False
            Me.pnlCreatePallet.Text = "Create Pallet"
            '
            'cboSkuLen
            '
            Me.cboSkuLen.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboSkuLen.AutoCompletion = True
            Me.cboSkuLen.AutoDropDown = True
            Me.cboSkuLen.AutoSelect = True
            Me.cboSkuLen.Caption = ""
            Me.cboSkuLen.CaptionHeight = 17
            Me.cboSkuLen.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboSkuLen.ColumnCaptionHeight = 17
            Me.cboSkuLen.ColumnFooterHeight = 17
            Me.cboSkuLen.ColumnHeaders = False
            Me.cboSkuLen.ContentHeight = 15
            Me.cboSkuLen.DataMode = C1.Win.C1List.DataModeEnum.AddItem
            Me.cboSkuLen.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboSkuLen.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboSkuLen.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboSkuLen.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboSkuLen.EditorHeight = 15
            Me.cboSkuLen.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboSkuLen.ItemHeight = 15
            Me.cboSkuLen.Location = New System.Drawing.Point(192, 72)
            Me.cboSkuLen.MatchEntryTimeout = CType(2000, Long)
            Me.cboSkuLen.MaxDropDownItems = CType(10, Short)
            Me.cboSkuLen.MaxLength = 32767
            Me.cboSkuLen.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboSkuLen.Name = "cboSkuLen"
            Me.cboSkuLen.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboSkuLen.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboSkuLen.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboSkuLen.Size = New System.Drawing.Size(176, 21)
            Me.cboSkuLen.TabIndex = 135
            Me.cboSkuLen.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:HotTrack;}Style3{}Inactive{ForeColor:InactiveCaptionText;Bac" & _
            "kColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Tahoma, 11" & _
            "world;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style1{}OddRow{" & _
            "}RecordSelector{AlignImage:Center;}Heading{Wrap:True;BackColor:Control;Border:Ra" & _
            "ised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}Style10{}Style1" & _
            "1{}Style9{AlignHorz:Near;}</Data></Styles><Splits><C1.Win.C1List.ListBoxView All" & _
            "owColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17" & _
            """ ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Cli" & _
            "entRect>0, 0, 116, 156</ClientRect><Height>156</Height><VScrollBar><Width>16</Wi" & _
            "dth></VScrollBar><HScrollBar><Height>16</Height></HScrollBar><CaptionStyle paren" & _
            "t=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterSty" & _
            "le parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><Head" & _
            "ingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow""" & _
            " me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle paren" & _
            "t=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style1" & _
            "0"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""S" & _
            "tyle1"" /></C1.Win.C1List.ListBoxView></Splits><NamedStyles><Style parent="""" me=""" & _
            "Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Foot" & _
            "er"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactiv" & _
            "e"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Highlight" & _
            "Row"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" " & _
            "/><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Grou" & _
            "p"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>M" & _
            "odified</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth></Blob>"
            '
            'cboShipType
            '
            Me.cboShipType.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboShipType.AutoCompletion = True
            Me.cboShipType.AutoDropDown = True
            Me.cboShipType.AutoSelect = True
            Me.cboShipType.Caption = ""
            Me.cboShipType.CaptionHeight = 17
            Me.cboShipType.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboShipType.ColumnCaptionHeight = 17
            Me.cboShipType.ColumnFooterHeight = 17
            Me.cboShipType.ColumnHeaders = False
            Me.cboShipType.ContentHeight = 15
            Me.cboShipType.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboShipType.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboShipType.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboShipType.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboShipType.EditorHeight = 15
            Me.cboShipType.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboShipType.ItemHeight = 15
            Me.cboShipType.Location = New System.Drawing.Point(192, 40)
            Me.cboShipType.MatchEntryTimeout = CType(2000, Long)
            Me.cboShipType.MaxDropDownItems = CType(10, Short)
            Me.cboShipType.MaxLength = 32767
            Me.cboShipType.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboShipType.Name = "cboShipType"
            Me.cboShipType.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboShipType.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboShipType.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboShipType.Size = New System.Drawing.Size(176, 21)
            Me.cboShipType.TabIndex = 134
            Me.cboShipType.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            Me.cboModels.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboModels.ItemHeight = 15
            Me.cboModels.Location = New System.Drawing.Point(192, 8)
            Me.cboModels.MatchEntryTimeout = CType(2000, Long)
            Me.cboModels.MaxDropDownItems = CType(10, Short)
            Me.cboModels.MaxLength = 32767
            Me.cboModels.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModels.Name = "cboModels"
            Me.cboModels.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModels.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModels.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModels.Size = New System.Drawing.Size(176, 21)
            Me.cboModels.TabIndex = 133
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
            'btnClearPallet
            '
            Me.btnClearPallet.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
            Me.btnClearPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
            Me.btnClearPallet.ForeColor = System.Drawing.Color.White
            Me.btnClearPallet.Location = New System.Drawing.Point(72, 104)
            Me.btnClearPallet.Name = "btnClearPallet"
            Me.btnClearPallet.Size = New System.Drawing.Size(96, 30)
            Me.btnClearPallet.TabIndex = 132
            Me.btnClearPallet.Text = "CLEAR"
            '
            'btnCreatePallet
            '
            Me.btnCreatePallet.BackColor = System.Drawing.Color.Green
            Me.btnCreatePallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCreatePallet.ForeColor = System.Drawing.Color.White
            Me.btnCreatePallet.Location = New System.Drawing.Point(216, 104)
            Me.btnCreatePallet.Name = "btnCreatePallet"
            Me.btnCreatePallet.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnCreatePallet.Size = New System.Drawing.Size(152, 30)
            Me.btnCreatePallet.TabIndex = 129
            Me.btnCreatePallet.Text = "CREATE PALLET"
            '
            'pnlOpenPallets
            '
            Me.pnlOpenPallets.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
            Me.pnlOpenPallets.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRefreshOpenPallets, Me.btnDeletePallet, Me.gdOpenPallets, Me.btnReopenPallet})
            Me.pnlOpenPallets.Name = "pnlOpenPallets"
            Me.pnlOpenPallets.Size = New System.Drawing.Size(382, 504)
            Me.pnlOpenPallets.TabIndex = 126
            Me.pnlOpenPallets.TabStop = False
            '
            'btnRefreshOpenPallets
            '
            Me.btnRefreshOpenPallets.BackColor = System.Drawing.Color.Green
            Me.btnRefreshOpenPallets.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRefreshOpenPallets.ForeColor = System.Drawing.Color.White
            Me.btnRefreshOpenPallets.Location = New System.Drawing.Point(272, 456)
            Me.btnRefreshOpenPallets.Name = "btnRefreshOpenPallets"
            Me.btnRefreshOpenPallets.Size = New System.Drawing.Size(96, 30)
            Me.btnRefreshOpenPallets.TabIndex = 127
            Me.btnRefreshOpenPallets.Text = "Refresh"
            '
            'btnDeletePallet
            '
            Me.btnDeletePallet.BackColor = System.Drawing.Color.Red
            Me.btnDeletePallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnDeletePallet.ForeColor = System.Drawing.Color.White
            Me.btnDeletePallet.Location = New System.Drawing.Point(8, 456)
            Me.btnDeletePallet.Name = "btnDeletePallet"
            Me.btnDeletePallet.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnDeletePallet.Size = New System.Drawing.Size(120, 30)
            Me.btnDeletePallet.TabIndex = 108
            Me.btnDeletePallet.Text = "Delete Pallet"
            '
            'gdOpenPallets
            '
            Me.gdOpenPallets.AllowColMove = False
            Me.gdOpenPallets.AllowColSelect = False
            Me.gdOpenPallets.AllowFilter = False
            Me.gdOpenPallets.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.gdOpenPallets.AllowSort = False
            Me.gdOpenPallets.AllowUpdate = False
            Me.gdOpenPallets.AllowUpdateOnBlur = False
            Me.gdOpenPallets.Caption = "Open Pallets"
            Me.gdOpenPallets.CaptionHeight = 25
            Me.gdOpenPallets.CollapseColor = System.Drawing.Color.White
            Me.gdOpenPallets.ExpandColor = System.Drawing.Color.White
            Me.gdOpenPallets.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gdOpenPallets.ForeColor = System.Drawing.Color.White
            Me.gdOpenPallets.GroupByCaption = "Drag a column header here to group by that column"
            Me.gdOpenPallets.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.gdOpenPallets.Location = New System.Drawing.Point(8, 16)
            Me.gdOpenPallets.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.gdOpenPallets.Name = "gdOpenPallets"
            Me.gdOpenPallets.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.gdOpenPallets.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.gdOpenPallets.PreviewInfo.ZoomFactor = 75
            Me.gdOpenPallets.RowHeight = 20
            Me.gdOpenPallets.Size = New System.Drawing.Size(366, 424)
            Me.gdOpenPallets.TabIndex = 106
            Me.gdOpenPallets.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:MintCream;}Sele" & _
            "cted{ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Whi" & _
            "te;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{Font:Microsoft Sans Ser" & _
            "if, 12pt, style=Bold;AlignHorz:Center;ForeColor:64, 0, 64;}Style1{}Normal{Font:M" & _
            "icrosoft Sans Serif, 8.25pt;BackColor:LightYellow;ForeColor:DarkGreen;AlignVert:" & _
            "Center;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style14{}OddRo" & _
            "w{BackColor:LightYellow;}RecordSelector{AlignImage:Center;ForeColor:White;}Style" & _
            "15{}Heading{AlignVert:Center;Wrap:True;Font:Microsoft Sans Serif, 10pt, style=Bo" & _
            "ld;AlignHorz:Center;Border:Raised,,1, 1, 1, 1;ForeColor:Navy;BackColor:Control;}" & _
            "Style8{}Style10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style16{}Style17{}Sty" & _
            "le9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView HBarHeight=""24"" Allo" & _
            "wColMove=""False"" AllowColSelect=""False"" Name="""" AllowRowSizing=""None"" CaptionHei" & _
            "ght=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCe" & _
            "llBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" H" & _
            "orizontalScrollGroup=""1""><Height>395</Height><CaptionStyle parent=""Style2"" me=""S" & _
            "tyle10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenR" & _
            "ow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle" & _
            " parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><Headin" & _
            "gStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" m" & _
            "e=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=" & _
            """OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11""" & _
            " /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Sty" & _
            "le1"" /><ClientRect>0, 25, 362, 395</ClientRect><BorderSide>0</BorderSide><Border" & _
            "Style>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles>" & _
            "<Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style pare" & _
            "nt=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=" & _
            """Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""" & _
            "Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""" & _
            "Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Headi" & _
            "ng"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=" & _
            """Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</ho" & _
            "rzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><Client" & _
            "Area>0, 0, 362, 420</ClientArea><PrintPageHeaderStyle parent="""" me=""Style16"" /><" & _
            "PrintPageFooterStyle parent="""" me=""Style17"" /></Blob>"
            '
            'btnReopenPallet
            '
            Me.btnReopenPallet.BackColor = System.Drawing.Color.Purple
            Me.btnReopenPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReopenPallet.ForeColor = System.Drawing.Color.White
            Me.btnReopenPallet.Location = New System.Drawing.Point(136, 456)
            Me.btnReopenPallet.Name = "btnReopenPallet"
            Me.btnReopenPallet.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnReopenPallet.Size = New System.Drawing.Size(128, 30)
            Me.btnReopenPallet.TabIndex = 107
            Me.btnReopenPallet.Text = "ReOpen Pallet"
            '
            'pnlPalletInfo
            '
            Me.pnlPalletInfo.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.pnlPalletInfo.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
            Me.pnlPalletInfo.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnReprintPalletLabel, Me.lblSkuLen, Me.txtSN, Me._Serial, Me.btnClosePallet, Me.btnRemoveAll, Me.btnRemove, Me.lstSerials, Me.lblCount, Me.Label3, Me.lblPalletName})
            Me.pnlPalletInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.pnlPalletInfo.Location = New System.Drawing.Point(420, 152)
            Me.pnlPalletInfo.Name = "pnlPalletInfo"
            Me.pnlPalletInfo.Size = New System.Drawing.Size(400, 352)
            Me.pnlPalletInfo.TabIndex = 127
            Me.pnlPalletInfo.TabStop = False
            Me.pnlPalletInfo.Text = "Pallet Information"
            '
            'btnReprintPalletLabel
            '
            Me.btnReprintPalletLabel.BackColor = System.Drawing.Color.SlateBlue
            Me.btnReprintPalletLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
            Me.btnReprintPalletLabel.ForeColor = System.Drawing.Color.White
            Me.btnReprintPalletLabel.Location = New System.Drawing.Point(200, 256)
            Me.btnReprintPalletLabel.Name = "btnReprintPalletLabel"
            Me.btnReprintPalletLabel.Size = New System.Drawing.Size(173, 30)
            Me.btnReprintPalletLabel.TabIndex = 118
            Me.btnReprintPalletLabel.Text = "Reprint Pallet Label"
            '
            'lblSkuLen
            '
            Me.lblSkuLen.BackColor = System.Drawing.Color.Salmon
            Me.lblSkuLen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblSkuLen.Font = New System.Drawing.Font("Verdana", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSkuLen.ForeColor = System.Drawing.Color.Black
            Me.lblSkuLen.Location = New System.Drawing.Point(280, 16)
            Me.lblSkuLen.Name = "lblSkuLen"
            Me.lblSkuLen.Size = New System.Drawing.Size(112, 37)
            Me.lblSkuLen.TabIndex = 117
            Me.lblSkuLen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtSN
            '
            Me.txtSN.Location = New System.Drawing.Point(8, 80)
            Me.txtSN.Name = "txtSN"
            Me.txtSN.Size = New System.Drawing.Size(182, 20)
            Me.txtSN.TabIndex = 113
            Me.txtSN.Text = ""
            '
            '_Serial
            '
            Me._Serial.BackColor = System.Drawing.Color.Transparent
            Me._Serial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me._Serial.ForeColor = System.Drawing.Color.Black
            Me._Serial.Location = New System.Drawing.Point(8, 56)
            Me._Serial.Name = "_Serial"
            Me._Serial.Size = New System.Drawing.Size(108, 19)
            Me._Serial.TabIndex = 112
            Me._Serial.Text = "Serial Number : "
            Me._Serial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnClosePallet
            '
            Me.btnClosePallet.BackColor = System.Drawing.Color.Green
            Me.btnClosePallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClosePallet.ForeColor = System.Drawing.Color.White
            Me.btnClosePallet.Location = New System.Drawing.Point(200, 304)
            Me.btnClosePallet.Name = "btnClosePallet"
            Me.btnClosePallet.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnClosePallet.Size = New System.Drawing.Size(173, 30)
            Me.btnClosePallet.TabIndex = 108
            Me.btnClosePallet.Text = "CLOSE PALLET"
            '
            'btnRemoveAll
            '
            Me.btnRemoveAll.BackColor = System.Drawing.Color.Red
            Me.btnRemoveAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveAll.ForeColor = System.Drawing.Color.White
            Me.btnRemoveAll.Location = New System.Drawing.Point(200, 200)
            Me.btnRemoveAll.Name = "btnRemoveAll"
            Me.btnRemoveAll.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveAll.Size = New System.Drawing.Size(173, 30)
            Me.btnRemoveAll.TabIndex = 107
            Me.btnRemoveAll.Text = "Remove All Serials"
            '
            'btnRemove
            '
            Me.btnRemove.BackColor = System.Drawing.Color.Red
            Me.btnRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemove.ForeColor = System.Drawing.Color.White
            Me.btnRemove.Location = New System.Drawing.Point(200, 152)
            Me.btnRemove.Name = "btnRemove"
            Me.btnRemove.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemove.Size = New System.Drawing.Size(173, 30)
            Me.btnRemove.TabIndex = 106
            Me.btnRemove.Text = "Remove Serial"
            '
            'lstSerials
            '
            Me.lstSerials.Location = New System.Drawing.Point(8, 112)
            Me.lstSerials.Name = "lstSerials"
            Me.lstSerials.Size = New System.Drawing.Size(182, 225)
            Me.lstSerials.TabIndex = 105
            '
            'lblCount
            '
            Me.lblCount.BackColor = System.Drawing.Color.Black
            Me.lblCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCount.ForeColor = System.Drawing.Color.Lime
            Me.lblCount.Location = New System.Drawing.Point(248, 80)
            Me.lblCount.Name = "lblCount"
            Me.lblCount.Size = New System.Drawing.Size(64, 37)
            Me.lblCount.TabIndex = 110
            Me.lblCount.Text = "0"
            Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label3.Location = New System.Drawing.Point(248, 64)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(61, 18)
            Me.Label3.TabIndex = 109
            Me.Label3.Text = "Count"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblPalletName
            '
            Me.lblPalletName.BackColor = System.Drawing.Color.Black
            Me.lblPalletName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblPalletName.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPalletName.ForeColor = System.Drawing.Color.Lime
            Me.lblPalletName.Location = New System.Drawing.Point(8, 16)
            Me.lblPalletName.Name = "lblPalletName"
            Me.lblPalletName.Size = New System.Drawing.Size(264, 38)
            Me.lblPalletName.TabIndex = 111
            Me.lblPalletName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnSelectPallet
            '
            Me.btnSelectPallet.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnSelectPallet.BackColor = System.Drawing.Color.Transparent
            Me.btnSelectPallet.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnSelectPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSelectPallet.ForeColor = System.Drawing.Color.Transparent
            Me.btnSelectPallet.Image = CType(resources.GetObject("btnSelectPallet.Image"), System.Drawing.Bitmap)
            Me.btnSelectPallet.Location = New System.Drawing.Point(384, 240)
            Me.btnSelectPallet.Name = "btnSelectPallet"
            Me.btnSelectPallet.Size = New System.Drawing.Size(35, 35)
            Me.btnSelectPallet.TabIndex = 130
            '
            'pnlMain
            '
            Me.pnlMain.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnSelectPallet, Me.pnlOpenPallets, Me.pnlCreatePallet, Me.pnlPalletInfo})
            Me.pnlMain.Location = New System.Drawing.Point(0, 48)
            Me.pnlMain.Name = "pnlMain"
            Me.pnlMain.Size = New System.Drawing.Size(832, 520)
            Me.pnlMain.TabIndex = 132
            '
            'frmBuildShipBox
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(846, 572)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlMain, Me._Tittle})
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
            Me.MaximumSize = New System.Drawing.Size(856, 608)
            Me.MinimumSize = New System.Drawing.Size(856, 608)
            Me.Name = "frmBuildShipBox"
            Me.Text = "frmBuildShipBox"
            Me.pnlCreatePallet.ResumeLayout(False)
            CType(Me.cboSkuLen, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboShipType, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboModels, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlOpenPallets.ResumeLayout(False)
            CType(Me.gdOpenPallets, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlPalletInfo.ResumeLayout(False)
            Me.pnlMain.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Loading Events"
        '********************************************************************************************************
        Private Sub frmBuildShipBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            LoadDefault()
        End Sub

        '********************************************************************************************************

        Private Sub LoadDefault()
            Try
                'Loading Default values at start up
                LoadModels()
                LoadShipType()
                LoadSKuLength()
                LoadOpenPallets()
                btnCreatePallet.Enabled = False
                btnRemove.Enabled = False
                btnRemoveAll.Enabled = False
                btnClosePallet.Enabled = False

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Gui.Nespresso.frmReceiving_LoadDefault", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

            End Try
        End Sub

        '********************************************************************************************************
        Private Sub LoadOpenPallets(Optional ByVal iPalletID As Integer = 0)

            Dim dt As DataTable
            Dim i As Integer
            Try
                Me._booPopulateDataToCtrl = True

                dt = Me._objNespresso.GetOpenPallet(Me._LocID, Me._CusID)

                If dt.Rows.Count > 0 Then
                    btnDeletePallet.Enabled = True
                    btnSelectPallet.Enabled = True
                Else
                    btnDeletePallet.Enabled = False
                    btnSelectPallet.Enabled = False
                End If

                dt.Columns("Model_Desc").ColumnName = "Model"
                dt.Columns("Pallett_Name").ColumnName = "Box"
                dt.Columns("Pallettype_SDesc").ColumnName = "Type" : dt.AcceptChanges()
                dt.Columns("Pallet_SkuLen").ColumnName = "Sku Length" : dt.AcceptChanges()

                With Me.gdOpenPallets
                    .DataSource = Nothing
                    .DataSource = dt.DefaultView

                    For i = 0 To dt.Columns.Count - 1
                        'Make some columns invisible
                        .Splits(0).DisplayColumns(i).Visible = False
                    Next i
                    .Splits(0).DisplayColumns("Model").Width = 75
                    .Splits(0).DisplayColumns("Box").Width = 120
                    .Splits(0).DisplayColumns("Type").Width = 75
                    .Splits(0).DisplayColumns("SKu Length").Width = 85

                    .Splits(0).DisplayColumns("Model").Visible = True
                    .Splits(0).DisplayColumns("Box").Visible = True
                    .Splits(0).DisplayColumns("Type").Visible = True
                    .Splits(0).DisplayColumns("Sku Length").Visible = True

                    If iPalletID > 0 Then
                        .MoveFirst()
                        For i = 0 To dt.Rows.Count - 1
                            If CInt(Me.gdOpenPallets.Columns("Pallett_ID").Value.ToString) <> iPalletID Then .MoveNext() Else Exit For
                        Next i
                    End If

                End With

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt) : Me._booPopulateDataToCtrl = False
            End Try

        End Sub
        '********************************************************************************************************
        Private Sub LoadModels()

            Dim dt As New DataTable()
            Try
                _booPopulateDataToCtrl = True
                Me.cboModels.DataSource = Nothing : Me.cboModels.Text = ""
                dt = Me._objNespresso.GetModelsList(True)
                Misc.PopulateC1DropDownList(Me.cboModels, dt, "Model_Desc", "Model_ID")
                Me.cboModels.SelectedValue = 0

            Catch ex As Exception
                MsgBox("Error in Nespresso.frmBuildShipBox_LoadModels: " & ex.Message.ToString, MsgBoxStyle.Critical)
            Finally
                Generic.DisposeDT(dt)
                _booPopulateDataToCtrl = False
            End Try

        End Sub
        '********************************************************************************************************
        Private Sub LoadShipType()

            Dim dt As New DataTable()
            Try
                _booPopulateDataToCtrl = True
                Me.cboShipType.DataSource = Nothing : Me.cboShipType.Text = ""
                dt = Me._objNespresso.GetShipType(True)
                Misc.PopulateC1DropDownList(Me.cboShipType, dt, "Pallettype_LDesc", "PalletType_ID")
                Me.cboShipType.SelectedValue = 0

            Catch ex As Exception
                MsgBox("Error in Nespresso.frmBuildShipBox_LoadShipType: " & ex.Message.ToString, MsgBoxStyle.Critical)
            Finally
                Generic.DisposeDT(dt)
                _booPopulateDataToCtrl = False
            End Try

        End Sub
        '********************************************************************************************************
        Private Sub LoadSKuLength()

            _booPopulateDataToCtrl = True
            cboSkuLen.ClearItems()
            cboSkuLen.AddItem("-- Select SKU Length ---")
            cboSkuLen.AddItem("Grade A")
            cboSkuLen.AddItem("Grade B")
            _booPopulateDataToCtrl = False

        End Sub
#End Region

#Region "Buttons Events"
        '********************************************************************************************************
        Private Sub btnCreatePallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreatePallet.Click

            Dim dt As DataTable

            Try
                If Me.cboModels.SelectedValue = 0 Then
                    MessageBox.Show("Please select model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboModels.SelectAll()
                    Me.cboModels.Focus()
                ElseIf Me.cboShipType.SelectedValue = 0 Then
                    MessageBox.Show("Please select Ship Type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboShipType.SelectAll() : Me.cboShipType.Focus()
                ElseIf Me.cboSkuLen.SelectedIndex = 0 Then
                    MessageBox.Show("Please select SKU Length.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboSkuLen.SelectAll() : Me.cboSkuLen.Focus()
                ElseIf IsDBNull(Me.cboShipType.DataSource.Table.Select("PalletType_ID = " & Me.cboShipType.SelectedValue)(0)("BillRule_ID")) Then
                    MessageBox.Show("Box ship type is missing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboShipType.SelectAll() : Me.cboShipType.Focus()
                ElseIf IsDBNull(Me.cboShipType.DataSource.Table.Select("PalletType_ID = " & Me.cboShipType.SelectedValue)(0)("Pallettype_SDesc")) Then
                    MessageBox.Show("Ship type short description is missing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboShipType.SelectAll() : Me.cboShipType.Focus()
                Else
                    dt = Me._objShip.GetAvailablePallets(False, Me._LocID, Me._CusID, 0, Me.cboModels.SelectedValue, , , , Me.cboShipType.SelectedValue)
                    If dt.Rows.Count = 0 Then
                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                        Dim strWorkDate As String = PSS.Core.Global.ApplicationUser.Workdate
                        Dim strdate As String = Format(CDate(strWorkDate), "MMddyy")
                        Dim iPalletShipType As Integer = 0
                        Dim strPalletName, strShortShipType, strLastAlphaInPallet As String
                        strShortShipType = Microsoft.VisualBasic.Left(cboShipType.Text.ToUpper, 3)
                        strLastAlphaInPallet = _objMisc.GetLastCharFromPalletName(Me._strShortCustDesc & Me._strShortModelName, strdate)
                        'strPalletName = Me._strShortCustDesc & Me._strShortModelName & strShortShipType & strdate & strLastAlphaInPallet
                        'Lan said not to include Model 07/28/2011    
                        strPalletName = Me._strShortCustDesc & strShortShipType & strdate & strLastAlphaInPallet
                        Me.lblPalletName.Text = strPalletName
                        Me.lblSkuLen.Text = Me.cboSkuLen.Text
                        iPalletShipType = Convert.ToInt32(Me.cboShipType.DataSource.Table.Select("PalletType_ID = " & Me.cboShipType.SelectedValue)(0)("BillRule_ID"))

                        Dim objDataProc As New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                        Me._Pallet_ID = _objShip.CreatePallet(Me._CusID, Me._LocID, Me.cboModels.SelectedValue, 0, strPalletName, iPalletShipType, Me.lblSkuLen.Text, 0, 0, Me.cboShipType.SelectedValue)
                        If Me._Pallet_ID = 0 Then
                            MessageBox.Show("System has failed to create Pallet ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else

                            Me.LoadOpenPallets(Me._Pallet_ID)
                            If CInt(Me.gdOpenPallets.Columns("Pallett_ID").Value) = Me._Pallet_ID Then
                                Me.lblPalletName.Text = Me.gdOpenPallets.Columns("Box").Value.ToString
                                Me.RefreshSNList(Me._Pallet_ID)
                                Me.cboModels.Enabled = False : Me.cboShipType.Enabled = False : Me.cboSkuLen.Enabled = False : Me.btnCreatePallet.Enabled = False
                            End If
                            Me.Enabled = True : Me.txtSN.Focus()
                        End If
                    Else
                        MessageBox.Show("An open pallet is already existed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.gdOpenPallets.Columns("Box").FilterText = dt.Rows(0)("Pallett_Name")
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCreatePallet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt)
            End Try

        End Sub

        '********************************************************************************************************
        Private Sub btnSelectPallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectPallet.Click
            Me._Pallet_ID = 0
            Dim strPalletName As String = ""

            Try
                _booPopulateDataToCtrl = True : Me.cboModels.SelectedValue = 0 : Me.cboShipType.SelectedValue = 0 : Me.cboSkuLen.Text = ""
                Me.btnCreatePallet.Enabled = False : Me.ClearPanelPalletInfo()

                If Me.gdOpenPallets.RowCount > 0 AndAlso Me.gdOpenPallets.Columns.Count > 0 Then
                    Me._Pallet_ID = CInt(Me.gdOpenPallets.Columns("Pallett_ID").Value)
                    strPalletName = Me.gdOpenPallets.Columns("Box").Value.ToString.Trim

                    If Me._Pallet_ID = 0 Then
                        MessageBox.Show("Pallet is not selected.", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf strPalletName.Trim = "" Then
                        MessageBox.Show("Pallet is not selected.", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Convert.ToInt32(Me.gdOpenPallets.Columns("Model_ID").Value) = 0 Then
                        MessageBox.Show("Model is missing for selected pallet.", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Convert.ToInt32(Me.gdOpenPallets.Columns("PalletType_ID").Value) = 0 Then
                        MessageBox.Show("Ship Type is missing.", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        Me.cboModels.SelectedValue = Convert.ToInt32(Me.gdOpenPallets.Columns("Model_ID").Value) : Me.cboModels.Enabled = False
                        Me.cboShipType.SelectedValue = Convert.ToInt32(Me.gdOpenPallets.Columns("PalletType_ID").Value) : Me.cboShipType.Enabled = False
                        Me.lblSkuLen.Text = Me.gdOpenPallets.Columns("Sku Length").Value : Me.cboSkuLen.Enabled = False
                        Me.cboSkuLen.Text = Me.lblSkuLen.Text
                        Me.lblPalletName.Text = strPalletName
                        Me.RefreshSNList(Me._Pallet_ID) : Me.txtSN.Focus()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnSelectPallet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                _booPopulateDataToCtrl = False
            End Try


        End Sub

        '*************************************************************************************************************
        Private Sub btnDeletePallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeletePallet.Click
            Dim i As Integer = 0
            Dim booResetSelectedPallet As Boolean = False

            Try
                If Me.gdOpenPallets.RowCount = 0 OrElse Me.gdOpenPallets.Columns.Count = 0 Then
                    Exit Sub
                ElseIf Convert.ToInt32(Me.gdOpenPallets.Columns("Pallett_ID").CellValue(Me.gdOpenPallets.Row)) = 0 Then
                    MessageBox.Show("Pallet ID is missing for selected row.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf MessageBox.Show("Are you sure you want to delete pallet " & Me.gdOpenPallets.Columns("Box").Value & "?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Exit Sub
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    If Me._Pallet_ID > 0 AndAlso Me._Pallet_ID = Convert.ToInt32(Me.gdOpenPallets.Columns("Pallett_ID").CellValue(Me.gdOpenPallets.Row)) Then booResetSelectedPallet = True

                    i = PSS.Data.Production.Shipping.DeleteEmptyPallet(Convert.ToInt32(Me.gdOpenPallets.Columns("Pallett_ID").CellValue(Me.gdOpenPallets.Row)), PSS.Core.ApplicationUser.IDuser)
                    If i > 0 Then
                        If booResetSelectedPallet = True Then
                            Me.ClearPanelPalletInfo()
                            Me._booPopulateDataToCtrl = True
                            Me.cboModels.SelectedValue = 0 : Me.cboModels.Enabled = True
                            Me.cboShipType.SelectedValue = 0 : Me.cboShipType.Enabled = True
                            Me.cboSkuLen.SelectedIndex = 0 : Me.cboSkuLen.Enabled = True
                            Me.btnCreatePallet.Enabled = False
                        End If
                        Me.LoadOpenPallets()
                        MessageBox.Show("Pallet has been deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("System has failed to delete pallet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnDeleteBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default : Me._booPopulateDataToCtrl = False
            End Try
        End Sub
        '*************************************************************************************************************
        Private Sub btnReopenPallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReopenPallet.Click
            Dim strPallet As String = ""
            Dim i As Integer = 0
            Dim dt, dt2 As DataTable

            Try
                '************************
                strPallet = InputBox("Enter Pallet Name:", "Reopen Pallet").ToUpper
                If strPallet = "" Then
                    MessageBox.Show("Please enter Pallet Name to re-open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    dt = PSS.Data.Production.Shipping.GetPalletInfoByName(strPallet, Me._CusID)
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("Pallet " & strPallet & " does not exist in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("Pallet " & strPallet & " existed more than one in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Not IsDBNull(dt.Rows(0)("Pallett_ShipDate")) Then
                        MessageBox.Show("Pallet " & strPallet & " has already been shipped. Not allow to re-open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf dt.Rows(0)("Pallet_Invalid") = 1 Then
                        MessageBox.Show("This Pallet " & strPallet & " has been deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf dt.Rows(0)("Pallett_ReadyToShipFlg") = 0 Then
                        MessageBox.Show("Pallet " & strPallet & " is already open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                        dt2 = Me._objShip.GetAvailablePallets(False, Me._LocID, Me._CusID, 0, dt.Rows(0)("Model_ID"), , dt.Rows(0)("Pallet_ShipType"), , dt.Rows(0)("PalletType_ID"))
                        If dt2.Rows.Count = 0 Then
                            Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                            i = PSS.Data.Production.Shipping.ReopenPallet(dt.Rows(0)("Pallett_ID"))
                            If i = 0 Then
                                MessageBox.Show("System has failed to re-open the box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Else
                                Me._Pallet_ID = dt.Rows(0)("Pallett_ID")
                                Me.ClearPanelPalletInfo() : Me.LoadOpenPallets(Me._Pallet_ID)
                                Me.cboModels.SelectedValue = Convert.ToInt32(dt.Rows(0)("Model_ID")) : Me.cboModels.Enabled = False
                                Me.cboShipType.SelectedValue = Convert.ToInt32(dt.Rows(0)("PalletType_ID")) : Me.cboShipType.Enabled = False
                                Me.cboSkuLen.Text = dt.Rows(0)("Pallet_Skulen") : Me.cboSkuLen.Enabled = False
                                Me.lblPalletName.Text = dt.Rows(0)("Pallett_Name")
                                Me.btnCreatePallet.Enabled = False : Me.RefreshSNList(Me._Pallet_ID)

                                Me.Enabled = True : Me.txtSN.Focus()
                            End If 'Re-Open status 
                        ElseIf dt2.Rows.Count > 1 Then
                            MessageBox.Show("More than one open Pallet is existed. Please contact IT", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            MessageBox.Show("An open Pallet is already existed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.gdOpenPallets.Columns("Box").FilterText = dt.Rows(0)("Pallett_Name")
                            If Me.gdOpenPallets.RowCount = 0 Then Me.LoadOpenPallets(dt2.Rows(0)("Pallett_ID"))
                        End If 'check for open box
                    End If  'validate pallet information
                End If  'Empty input
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnReopenPallet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt)
            End Try
        End Sub
        '*************************************************************************************************************
        Private Sub btnClearPallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearPallet.Click
            Try
                Me._booPopulateDataToCtrl = True
                Me.ClearPanelPalletInfo()
                Me.cboModels.SelectedValue = 0 : Me.cboModels.Enabled = True
                Me.cboShipType.SelectedValue = 0 : Me.cboShipType.Enabled = True
                Me.cboSkuLen.SelectedIndex = 0 : Me.cboSkuLen.Enabled = True
                Me.btnCreatePallet.Enabled = False
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnClearPallet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me._booPopulateDataToCtrl = False
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
            Dim strSN As String = ""
            Dim i As Integer = 0
            Dim iDeviceID As Integer = 0

            Try
                '************************
                'Validations
                If Me.lstSerials.Items.Count = 0 Or Me._Pallet_ID = 0 Or Me.lblPalletName.Text.Trim.Length = 0 Then
                    Exit Sub
                ElseIf Me._Pallet_ID = 0 Then
                    MessageBox.Show("Pallet name is not selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    '************************
                    strSN = InputBox("Enter Serial #:", "Serial").Trim.ToUpper
                    If strSN = "" Then
                        MessageBox.Show("Please enter a Serial number if you want to remove it from the selected box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Me.lstSerials.DataSource.Table.select("Device_SN = '" & strSN & "'").length = 0 Then
                        MessageBox.Show("Serial#" & strSN & " was not listed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        iDeviceID = Me.lstSerials.DataSource.Table.select("Device_SN = '" & strSN & "'")(0)("Device_ID")
                        If iDeviceID > 0 Then
                            Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                            i = PSS.Data.Production.Shipping.RemoveSNfromPallet(Me._Pallet_ID, iDeviceID)
                            If i = 0 Then
                                MessageBox.Show("System has failed to remove Serial#" & strSN & " from pallet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Else
                                Me.RefreshSNList(Me._Pallet_ID)
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRemoveSN_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                Me.txtSN.Text = "" : Me.txtSN.Focus()
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub btnRemoveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAll.Click
            Dim str_sn As String = ""
            Dim i As Integer = 0

            Try
                '************************
                'Validations
                '************************
                If Me.lstSerials.Items.Count = 0 Or Me._Pallet_ID = 0 Then
                    Exit Sub
                ElseIf Me._Pallet_ID = 0 Then
                    MessageBox.Show("Pallet name is not selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf MessageBox.Show("Are you sure you want to remove all devices from this Box (" & Me.lblPalletName.Text & ")?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Exit Sub
                Else
                    '************************
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                    i = PSS.Data.Production.Shipping.RemoveSNfromPallet(Me._Pallet_ID, )
                    If i = 0 Then
                        MessageBox.Show("System has failed to remove all serials from box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        Me.RefreshSNList(Me._Pallet_ID)
                    End If
                    '************************
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRemoveAllSNs_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                Me.txtSN.Text = "" : Me.txtSN.Focus()
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub btnRefreshOpenPallets_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshOpenPallets.Click
            Dim booResetSelectedPallet As Boolean = False
            Try
                Me.LoadOpenPallets()
                If Me.gdOpenPallets.RowCount = 0 OrElse Me._Pallet_ID > 0 AndAlso Me.gdOpenPallets.DataSource.Table.Select("Pallett_ID = " & Me._Pallet_ID = 0) Then
                    Me._booPopulateDataToCtrl = True
                    Me.cboModels.SelectedValue = 0 : Me.cboModels.Enabled = True
                    Me.cboShipType.SelectedValue = 0 : Me.cboShipType.Enabled = False
                    Me.cboSkuLen.Text = "" : Me.cboSkuLen.Enabled = False
                    Me.ClearPanelPalletInfo()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRefreshOpenPallets_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me._booPopulateDataToCtrl = False
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub btnClosePallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClosePallet.Click
            Dim i As Integer = 0

            Try
                '************************
                'Validations
                If Me._Pallet_ID = 0 Then
                    MessageBox.Show("Pallet ID is not selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtSN.SelectAll() : Me.txtSN.Focus()
                ElseIf Me.lblPalletName.Text.ToString.Trim = "" Then
                    MessageBox.Show("Pallet Name is not selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtSN.SelectAll() : Me.txtSN.Focus()
                ElseIf Me.lstSerials.Items.Count = 0 Then
                    MessageBox.Show("This Pallet is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtSN.Text = "" : Me.txtSN.Focus()
                ElseIf MessageBox.Show("Are you sure you want to close this pallet (" & Me.lblPalletName.Text.ToString.Trim & ")?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Me.txtSN.Text = "" : Me.txtSN.Focus()
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                    i = Me._objNespresso.CreateShippingManifest(Me._Pallet_ID)
                    i = Me._objMisc.ClosePallet(Me._CusID, Me._Pallet_ID, Me.lblPalletName.Text, Me.lstSerials.Items.Count, )

                    PSS.Data.Production.Shipping.Print4x4GenericShipBoxLabel(Me._Pallet_ID, PSS.Data.Buisness.Nespresso.Nespresso.ShipBoxLabelLocation, 1)
                    '************************
                    If i > 0 Then
                        '******************************
                        'Reset Screen control properties.
                        '******************************
                        Me.LoadOpenPallets() : Me._booPopulateDataToCtrl = True
                        Me.Enabled = True : Me.ClearPanelPalletInfo()
                        Me.cboModels.SelectedValue = 0 : Me.cboModels.Enabled = True
                        Me.cboShipType.SelectedValue = 0 : Me.cboShipType.Enabled = True
                        Me.cboSkuLen.SelectedIndex = 0 : Me.cboSkuLen.Enabled = True
                        Me.btnCreatePallet.Enabled = False
                        Me.cboModels.SelectAll() : Me.cboModels.Focus()
                        '******************************
                    Else
                        MessageBox.Show("System has failed to close pallet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                    '******************************
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnClosePallet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                Me._booPopulateDataToCtrl = False
            End Try
        End Sub

        '*************************************************************************************************************

        Private Sub btnReprintPalletLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintPalletLabel.Click
            Dim str_pallett As String
            Dim dt As DataTable

            Try
                str_pallett = InputBox("Enter pallet name.", "Reprint Pallet Label")
                If str_pallett = "" Then
                    Throw New Exception("Please enter a pallet name if you want to reprint the pallet label.")
                End If

                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                dt = Me._objShip.GetPalletInfoByName(str_pallett, Me._CusID)
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Pallet is not defined in system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf dt.Rows.Count > 1 Then
                    MessageBox.Show("Pallet existed more than one in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf dt.Rows(0)("Pallett_ReadyToShipFlg") = 0 Then
                    MessageBox.Show("Pallet is still open.", "Information", MessageBoxButtons.OK)
                Else
                    'Me._objNespresso.CreateShippingManifest(CInt(dt.Rows(0)("Pallett_ID")))
                    PSS.Data.Production.Shipping.Print4x4GenericShipBoxLabel(dt.Rows(0)("Pallett_ID"), PSS.Data.Buisness.Nespresso.Nespresso.ShipBoxLabelLocation, 1)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnReprintBoxLabel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

#End Region

#Region "Text and Combo Box Events"
        '*************************************************************************************************************
        Private Sub cbo_RowChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboModels.RowChange, cboShipType.RowChange, cboSkuLen.RowChange

            Try
                If _booPopulateDataToCtrl = False Then
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    Me.ClearPanelPalletInfo()
                    If sender.name = "cboModels" Then
                        If Me.cboModels.SelectedValue > 0 Then
                            Me._strShortModelName = Trim(_objMisc.GetShortModelName(Me.cboModels.SelectedValue))
                            If Me._strShortModelName = "" Then
                                Me._strShortModelName = Trim(InputBox("This Model does not have a 'Short Name'. Please input it now to continue."))
                                If Me._strShortModelName = "" Then
                                    Me.cboModels.SelectedValue = 0
                                    Throw New Exception("You must input a 'Short Model Name'. Can't continue.")
                                Else
                                    _objMisc.SaveShortModelName(Me.cboModels.SelectedValue, Me._strShortModelName)
                                End If
                            End If
                            cboShipType.Focus()
                        End If
                    ElseIf sender.name = "cboShipType" Then
                        cboSkuLen.Focus()
                    ElseIf sender.name = "cboSkuLen" Then
                        btnCreatePallet.Focus()
                    End If

                    If Me.cboModels.SelectedValue > 0 And Me.cboShipType.SelectedValue > 0 And Me.cboSkuLen.SelectedIndex > 0 Then
                        Me.btnCreatePallet.Enabled = True
                    Else
                        Me.btnCreatePallet.Enabled = False
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cbo_RowChange", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

          '*************************************************************************************************************
        Private Sub txtSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp
            Dim i, iDevMaxBillRule As Integer
            Dim strSN As String = Me.txtSN.Text.Trim.ToUpper
            Dim dtDevice As DataTable

            Try
                If e.KeyCode <> Keys.Enter Then Exit Sub
                '************************
                'Validations
                If strSN.Length = 0 Then
                    Exit Sub
                ElseIf Me._Pallet_ID = 0 Then
                    MessageBox.Show("Pallet ID is not selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtSN.SelectAll() : Me.txtSN.Focus()
                ElseIf Me.lblPalletName.Text.ToString.Trim = "" Then
                    MessageBox.Show("Pallet Name is not selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtSN.SelectAll() : Me.txtSN.Focus()
                ElseIf Me.lstSerials.DataSource.table.select("device_sn = '" & strSN.Trim & "'").length > 0 Then
                    '***************************************************
                    'Check if the Device is already scanned in
                    '***************************************************
                    MessageBox.Show("This serial#" & strSN & " is already listed. Try another one.", "Duplicated Serial Number !", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtSN.Text = ""
                    Me.txtSN.Focus()
                ElseIf Me.cboModels.SelectedValue = 0 Then
                    MessageBox.Show("Model is not selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtSN.SelectAll() : Me.txtSN.Focus()
                ElseIf Me.cboShipType.SelectedValue = 0 Then
                    MessageBox.Show("Ship Type is not selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtSN.SelectAll() : Me.txtSN.Focus()
                ElseIf Me.cboSkuLen.SelectedIndex = 0 Then
                    MessageBox.Show("SKU Length is not selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtSN.SelectAll() : Me.txtSN.Focus()
                ElseIf Generic.IsPalletClosed(Me._Pallet_ID) = True Then
                    MessageBox.Show("Pallet had been closed by another machine. Please refresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtSN.Text = "" : Me.txtSN.Focus()
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    dtDevice = Generic.GetDeviceInfoInWIP(Me.txtSN.Text.Trim, Me._CusID, Me._LocID, False)

                    If dtDevice.Rows.Count > 1 Then
                        MessageBox.Show("This serial#" & strSN & " existed twice in the system. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.Enabled = True : Me.txtSN.SelectAll() : Me.txtSN.Focus()
                    ElseIf dtDevice.Rows.Count = 0 Then
                        MessageBox.Show("This serial#" & strSN & " does not exist in the system, already ship or belongs to a different customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.Enabled = True : Me.txtSN.SelectAll() : Me.txtSN.Focus()
                      ElseIf Not IsDBNull(dtDevice.Rows(0)("Pallett_ID")) Then
                        MessageBox.Show("This serial#" & strSN & " has assigned to Pallet ID (" & dtDevice.Rows(0)("Pallett_ID") & ").", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.Enabled = True : Me.txtSN.SelectAll() : Me.txtSN.Focus()
                    ElseIf Me.cboModels.SelectedValue > 0 AndAlso dtDevice.Rows(0)("Model_ID") <> Me.cboModels.SelectedValue Then
                        MessageBox.Show("Wrong model! This serial#" & strSN & " is not belongs to " & Me.cboModels.Text & " model", "Wrong Model !", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.Enabled = True : Me.txtSN.SelectAll() : Me.txtSN.Focus()
                    ElseIf IsDBNull(dtDevice.Rows(0)("Device_DateBill")) Then
                        MessageBox.Show("This serial#" & strSN & " has not been billed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.Enabled = True : Me.txtSN.SelectAll() : Me.txtSN.Focus()
                    ElseIf CInt(Me.cboShipType.DataSource.Table.Select("PalletType_ID = " & Me.cboShipType.SelectedValue)(0)("NoPartAllow")) = 1 AndAlso Generic.IsDeviceHadParts(dtDevice.Rows(0)("Device_ID")) = True Then
                        MessageBox.Show("Box type does not allow device with part. Please un-bill all parts.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.Enabled = True : Me.txtSN.SelectAll() : Me.txtSN.Focus()
                    Else
                        iDevMaxBillRule = Generic.GetMaxBillRule(dtDevice.Rows(0)("Device_ID"))
                        If CInt(Me.cboShipType.DataSource.Table.Select("PalletType_ID = " & Me.cboShipType.SelectedValue)(0)("BillRule_ID")) = 0 AndAlso iDevMaxBillRule > 0 Then
                            MessageBox.Show("Can't mix RUR/BER device with refurbished box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.Enabled = False : Me.txtSN.SelectAll() : Me.txtSN.Focus()
                        ElseIf CInt(Me.cboShipType.DataSource.Table.Select("PalletType_ID = " & Me.cboShipType.SelectedValue)(0)("BillRule_ID")) > 0 AndAlso iDevMaxBillRule = 0 Then
                            MessageBox.Show("Can't mix refurbished device with RUR/BER box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.Enabled = True : Me.txtSN.SelectAll() : Me.txtSN.Focus()
                        Else
                            '*****************************************************
                            'Check QC
                            '*****************************************************
                            If iDevMaxBillRule = 0 AndAlso Generic.IsValidQCResults(dtDevice.Rows(0)("Device_ID"), 1, "Functional", True, True) = False Then
                                MessageBox.Show("This serial#" & strSN & " has not passed QC.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.Enabled = True : Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub
                            End If

                            '***************************************************
                            'if above all is fine then add it to the list and update the database
                            i = PSS.Data.Production.Shipping.AssignDeviceToPallet(dtDevice.Rows(0)("Device_ID"), Me._Pallet_ID)

                            '***************************************************
                            Me.RefreshSNList(Me._Pallet_ID)
                            Me.Enabled = True : Cursor.Current = Cursors.Default
                            Me.txtSN.Text = "" : Me.txtSN.Focus()
                            '***************************************************
                        End If 'Bill Rule
                    End If 'Device Data
                End If 'Input data
            Catch ex As Exception
                MessageBox.Show(ex.Message, "txtSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.Enabled = True : Me.txtSN.SelectAll() : Me.txtSN.Focus()
            Finally
                Generic.DisposeDT(dtDevice)
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '*************************************************************************************************************

#End Region

#Region "Functions & Subs"
        '********************************************************************************************************
        Private Sub SetOpenPalletsProperties()

            Dim iNumOfColumns As Integer = Me.gdOpenPallets.Columns.Count
            Dim i As Integer

            With Me.gdOpenPallets
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
                .Splits(0).DisplayColumns(0).Width = 100
                .Splits(0).DisplayColumns(1).Width = 150
                .Splits(0).DisplayColumns(2).Width = 150
                .Splits(0).DisplayColumns(3).Width = 150

                'Make some columns invisible
                .Splits(0).DisplayColumns(0).Visible = True
                .Splits(0).DisplayColumns(1).Visible = True
                .Splits(0).DisplayColumns(2).Visible = True
                .Splits(0).DisplayColumns(3).Visible = True
            End With
        End Sub

        '********************************************************************************************************
        Private Sub RefreshSNList(ByVal iPalletID As Integer)
            Dim dt As DataTable
            Try
                '************************
                'Validations
                If iPalletID = 0 Then
                    Throw New Exception("Pallet is not selected.")
                End If
                '*******************************************
                'Get all devices add put them in them in list box for a pallet
                dt = _objMisc.GetAllSNsForPallet(iPalletID)
                Me.lstSerials.DataSource = dt.DefaultView
                Me.lstSerials.ValueMember = dt.Columns("device_id").ToString
                Me.lstSerials.DisplayMember = dt.Columns("device_sn").ToString
                '*******************************************
                Me.lblCount.Text = dt.Rows.Count
                If dt.Rows.Count > 0 Then
                    btnRemove.Enabled = True
                    btnRemoveAll.Enabled = True
                    btnClosePallet.Enabled = True
                Else
                    btnRemove.Enabled = False
                    btnRemoveAll.Enabled = False
                    btnClosePallet.Enabled = False
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Me.txtSN.Focus()
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Sub
        '*************************************************************************************************************
        Private Sub ClearPanelPalletInfo()
            Try
                Me._Pallet_ID = 0
                btnRemove.Enabled = False
                btnRemoveAll.Enabled = False
                btnClosePallet.Enabled = False
                Me.txtSN.Text = "" : Me.lblPalletName.Text = "" : Me.lblCount.Text = ""
                Me.lstSerials.DataSource = Nothing : Me.lstSerials.Items.Clear() : Me.lstSerials.Refresh()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        '*************************************************************************************************************


#End Region


    End Class
End Namespace