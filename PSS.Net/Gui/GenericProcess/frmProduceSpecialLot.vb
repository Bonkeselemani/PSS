Option Explicit On 

Imports PSS.Data
Imports PSS.Data.Buisness
Imports PSS.Core
Namespace GUI.GenericProcess

    Public Class frmProduceSpecialLot
        Inherits System.Windows.Forms.Form

        Private _objGeneric As New Generic()
        Private _LocID As Integer = 0
        Private _ProdID As Integer = 0
        Private _CusID As Integer = 0
        Private _ModelID As Integer = 0
        Private _booPopDataToCombo As Boolean = False

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
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents Status As System.Windows.Forms.Label
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents txtLotPallet As System.Windows.Forms.TextBox
        Friend WithEvents cboModels As C1.Win.C1List.C1Combo
        Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
        Friend WithEvents _lblModel As System.Windows.Forms.Label
        Friend WithEvents _lblLotPallet As System.Windows.Forms.Label
        Friend WithEvents _lblQuantity As System.Windows.Forms.Label
        Friend WithEvents cboProducts As C1.Win.C1List.C1Combo
        Friend WithEvents cboCustomers As C1.Win.C1List.C1Combo
        Friend WithEvents cboLocations As C1.Win.C1List.C1Combo
        Friend WithEvents _lblProduct As System.Windows.Forms.Label
        Friend WithEvents _lblCustomer As System.Windows.Forms.Label
        Friend WithEvents _lblLocation As System.Windows.Forms.Label
        Friend WithEvents pnlInfo As System.Windows.Forms.Panel
        Friend WithEvents btnProduce As System.Windows.Forms.Button
        Friend WithEvents _lblShipType As System.Windows.Forms.Label
        Friend WithEvents cboShipType As C1.Win.C1List.C1Combo
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmProduceSpecialLot))
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.Status = New System.Windows.Forms.Label()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.btnProduce = New System.Windows.Forms.Button()
            Me.txtLotPallet = New System.Windows.Forms.TextBox()
            Me._lblLotPallet = New System.Windows.Forms.Label()
            Me._lblModel = New System.Windows.Forms.Label()
            Me.cboModels = New C1.Win.C1List.C1Combo()
            Me.txtQuantity = New System.Windows.Forms.TextBox()
            Me._lblQuantity = New System.Windows.Forms.Label()
            Me.cboProducts = New C1.Win.C1List.C1Combo()
            Me.cboCustomers = New C1.Win.C1List.C1Combo()
            Me.cboLocations = New C1.Win.C1List.C1Combo()
            Me._lblProduct = New System.Windows.Forms.Label()
            Me._lblCustomer = New System.Windows.Forms.Label()
            Me._lblLocation = New System.Windows.Forms.Label()
            Me.pnlInfo = New System.Windows.Forms.Panel()
            Me._lblShipType = New System.Windows.Forms.Label()
            Me.cboShipType = New C1.Win.C1List.C1Combo()
            CType(Me.cboModels, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboProducts, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboLocations, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlInfo.SuspendLayout()
            CType(Me.cboShipType, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.lblTitle.BackColor = System.Drawing.Color.Black
            Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold)
            Me.lblTitle.ForeColor = System.Drawing.Color.Yellow
            Me.lblTitle.Location = New System.Drawing.Point(-240, 0)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(1380, 48)
            Me.lblTitle.TabIndex = 138
            Me.lblTitle.Text = "PRODUCE SPECIAL LOT"
            Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Status
            '
            Me.Status.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Status.ForeColor = System.Drawing.Color.Lime
            Me.Status.Location = New System.Drawing.Point(0, 48)
            Me.Status.Name = "Status"
            Me.Status.Size = New System.Drawing.Size(776, 72)
            Me.Status.TabIndex = 150
            Me.Status.Text = "Status"
            '
            'btnClear
            '
            Me.btnClear.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
            Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClear.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
            Me.btnClear.Location = New System.Drawing.Point(248, 272)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(88, 32)
            Me.btnClear.TabIndex = 154
            Me.btnClear.Text = "&Clear"
            '
            'btnProduce
            '
            Me.btnProduce.BackColor = System.Drawing.Color.Green
            Me.btnProduce.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnProduce.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
            Me.btnProduce.Location = New System.Drawing.Point(64, 272)
            Me.btnProduce.Name = "btnProduce"
            Me.btnProduce.Size = New System.Drawing.Size(168, 32)
            Me.btnProduce.TabIndex = 153
            Me.btnProduce.Text = "Produce"
            '
            'txtLotPallet
            '
            Me.txtLotPallet.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
            Me.txtLotPallet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtLotPallet.Location = New System.Drawing.Point(152, 200)
            Me.txtLotPallet.Name = "txtLotPallet"
            Me.txtLotPallet.Size = New System.Drawing.Size(184, 20)
            Me.txtLotPallet.TabIndex = 151
            Me.txtLotPallet.Text = ""
            '
            '_lblLotPallet
            '
            Me._lblLotPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me._lblLotPallet.ForeColor = System.Drawing.Color.White
            Me._lblLotPallet.Location = New System.Drawing.Point(16, 200)
            Me._lblLotPallet.Name = "_lblLotPallet"
            Me._lblLotPallet.Size = New System.Drawing.Size(128, 16)
            Me._lblLotPallet.TabIndex = 152
            Me._lblLotPallet.Text = "Lot/Pallet:"
            Me._lblLotPallet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            '_lblModel
            '
            Me._lblModel.BackColor = System.Drawing.Color.Transparent
            Me._lblModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
            Me._lblModel.ForeColor = System.Drawing.Color.White
            Me._lblModel.Location = New System.Drawing.Point(16, 120)
            Me._lblModel.Name = "_lblModel"
            Me._lblModel.Size = New System.Drawing.Size(130, 21)
            Me._lblModel.TabIndex = 156
            Me._lblModel.Text = "Model :"
            Me._lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            Me.cboModels.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboModels.ItemHeight = 15
            Me.cboModels.Location = New System.Drawing.Point(152, 120)
            Me.cboModels.MatchEntryTimeout = CType(2000, Long)
            Me.cboModels.MaxDropDownItems = CType(10, Short)
            Me.cboModels.MaxLength = 32767
            Me.cboModels.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModels.Name = "cboModels"
            Me.cboModels.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModels.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModels.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModels.Size = New System.Drawing.Size(184, 21)
            Me.cboModels.TabIndex = 155
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
            'txtQuantity
            '
            Me.txtQuantity.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
            Me.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtQuantity.Location = New System.Drawing.Point(152, 232)
            Me.txtQuantity.Name = "txtQuantity"
            Me.txtQuantity.Size = New System.Drawing.Size(184, 20)
            Me.txtQuantity.TabIndex = 157
            Me.txtQuantity.Text = ""
            '
            '_lblQuantity
            '
            Me._lblQuantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me._lblQuantity.ForeColor = System.Drawing.Color.White
            Me._lblQuantity.Location = New System.Drawing.Point(16, 232)
            Me._lblQuantity.Name = "_lblQuantity"
            Me._lblQuantity.Size = New System.Drawing.Size(128, 16)
            Me._lblQuantity.TabIndex = 158
            Me._lblQuantity.Text = "Quantity:"
            Me._lblQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboProducts
            '
            Me.cboProducts.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboProducts.AutoCompletion = True
            Me.cboProducts.AutoDropDown = True
            Me.cboProducts.AutoSelect = True
            Me.cboProducts.Caption = ""
            Me.cboProducts.CaptionHeight = 17
            Me.cboProducts.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboProducts.ColumnCaptionHeight = 17
            Me.cboProducts.ColumnFooterHeight = 17
            Me.cboProducts.ColumnHeaders = False
            Me.cboProducts.ContentHeight = 15
            Me.cboProducts.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboProducts.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboProducts.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboProducts.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboProducts.EditorHeight = 15
            Me.cboProducts.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboProducts.ItemHeight = 15
            Me.cboProducts.Location = New System.Drawing.Point(152, 24)
            Me.cboProducts.MatchEntryTimeout = CType(2000, Long)
            Me.cboProducts.MaxDropDownItems = CType(10, Short)
            Me.cboProducts.MaxLength = 32767
            Me.cboProducts.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboProducts.Name = "cboProducts"
            Me.cboProducts.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboProducts.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboProducts.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboProducts.Size = New System.Drawing.Size(184, 21)
            Me.cboProducts.TabIndex = 159
            Me.cboProducts.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'cboCustomers
            '
            Me.cboCustomers.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboCustomers.AutoCompletion = True
            Me.cboCustomers.AutoDropDown = True
            Me.cboCustomers.AutoSelect = True
            Me.cboCustomers.Caption = ""
            Me.cboCustomers.CaptionHeight = 17
            Me.cboCustomers.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboCustomers.ColumnCaptionHeight = 17
            Me.cboCustomers.ColumnFooterHeight = 17
            Me.cboCustomers.ColumnHeaders = False
            Me.cboCustomers.ContentHeight = 15
            Me.cboCustomers.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboCustomers.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboCustomers.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCustomers.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCustomers.EditorHeight = 15
            Me.cboCustomers.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboCustomers.ItemHeight = 15
            Me.cboCustomers.Location = New System.Drawing.Point(152, 56)
            Me.cboCustomers.MatchEntryTimeout = CType(2000, Long)
            Me.cboCustomers.MaxDropDownItems = CType(10, Short)
            Me.cboCustomers.MaxLength = 32767
            Me.cboCustomers.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCustomers.Name = "cboCustomers"
            Me.cboCustomers.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCustomers.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCustomers.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCustomers.Size = New System.Drawing.Size(184, 21)
            Me.cboCustomers.TabIndex = 160
            Me.cboCustomers.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'cboLocations
            '
            Me.cboLocations.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboLocations.AutoCompletion = True
            Me.cboLocations.AutoDropDown = True
            Me.cboLocations.AutoSelect = True
            Me.cboLocations.Caption = ""
            Me.cboLocations.CaptionHeight = 17
            Me.cboLocations.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboLocations.ColumnCaptionHeight = 17
            Me.cboLocations.ColumnFooterHeight = 17
            Me.cboLocations.ColumnHeaders = False
            Me.cboLocations.ContentHeight = 15
            Me.cboLocations.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboLocations.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboLocations.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboLocations.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboLocations.EditorHeight = 15
            Me.cboLocations.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.cboLocations.ItemHeight = 15
            Me.cboLocations.Location = New System.Drawing.Point(152, 88)
            Me.cboLocations.MatchEntryTimeout = CType(2000, Long)
            Me.cboLocations.MaxDropDownItems = CType(10, Short)
            Me.cboLocations.MaxLength = 32767
            Me.cboLocations.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboLocations.Name = "cboLocations"
            Me.cboLocations.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboLocations.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboLocations.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboLocations.Size = New System.Drawing.Size(184, 21)
            Me.cboLocations.TabIndex = 161
            Me.cboLocations.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            '_lblProduct
            '
            Me._lblProduct.BackColor = System.Drawing.Color.Transparent
            Me._lblProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
            Me._lblProduct.ForeColor = System.Drawing.Color.White
            Me._lblProduct.Location = New System.Drawing.Point(16, 24)
            Me._lblProduct.Name = "_lblProduct"
            Me._lblProduct.Size = New System.Drawing.Size(130, 21)
            Me._lblProduct.TabIndex = 162
            Me._lblProduct.Text = "Product :"
            Me._lblProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            '_lblCustomer
            '
            Me._lblCustomer.BackColor = System.Drawing.Color.Transparent
            Me._lblCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
            Me._lblCustomer.ForeColor = System.Drawing.Color.White
            Me._lblCustomer.Location = New System.Drawing.Point(16, 56)
            Me._lblCustomer.Name = "_lblCustomer"
            Me._lblCustomer.Size = New System.Drawing.Size(130, 21)
            Me._lblCustomer.TabIndex = 163
            Me._lblCustomer.Text = "Customer :"
            Me._lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            '_lblLocation
            '
            Me._lblLocation.BackColor = System.Drawing.Color.Transparent
            Me._lblLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
            Me._lblLocation.ForeColor = System.Drawing.Color.White
            Me._lblLocation.Location = New System.Drawing.Point(16, 88)
            Me._lblLocation.Name = "_lblLocation"
            Me._lblLocation.Size = New System.Drawing.Size(130, 21)
            Me._lblLocation.TabIndex = 164
            Me._lblLocation.Text = "Location :"
            Me._lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'pnlInfo
            '
            Me.pnlInfo.BackColor = System.Drawing.Color.Indigo
            Me.pnlInfo.Controls.AddRange(New System.Windows.Forms.Control() {Me._lblShipType, Me.cboShipType, Me.txtLotPallet, Me._lblModel, Me.cboCustomers, Me._lblCustomer, Me.cboProducts, Me.txtQuantity, Me.cboModels, Me._lblQuantity, Me._lblProduct, Me._lblLotPallet, Me._lblLocation, Me.cboLocations, Me.btnProduce, Me.btnClear})
            Me.pnlInfo.Location = New System.Drawing.Point(0, 120)
            Me.pnlInfo.Name = "pnlInfo"
            Me.pnlInfo.Size = New System.Drawing.Size(360, 328)
            Me.pnlInfo.TabIndex = 165
            '
            '_lblShipType
            '
            Me._lblShipType.BackColor = System.Drawing.Color.Transparent
            Me._lblShipType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
            Me._lblShipType.ForeColor = System.Drawing.Color.White
            Me._lblShipType.Location = New System.Drawing.Point(16, 154)
            Me._lblShipType.Name = "_lblShipType"
            Me._lblShipType.Size = New System.Drawing.Size(130, 21)
            Me._lblShipType.TabIndex = 166
            Me._lblShipType.Text = "ShipType :"
            Me._lblShipType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            Me.cboShipType.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.cboShipType.ItemHeight = 15
            Me.cboShipType.Location = New System.Drawing.Point(152, 154)
            Me.cboShipType.MatchEntryTimeout = CType(2000, Long)
            Me.cboShipType.MaxDropDownItems = CType(10, Short)
            Me.cboShipType.MaxLength = 32767
            Me.cboShipType.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboShipType.Name = "cboShipType"
            Me.cboShipType.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboShipType.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboShipType.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboShipType.Size = New System.Drawing.Size(184, 21)
            Me.cboShipType.TabIndex = 165
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
            'frmProduceSpecialLot
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(776, 526)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlInfo, Me.Status, Me.lblTitle})
            Me.Name = "frmProduceSpecialLot"
            Me.Text = "frmProduceSpecialLot"
            CType(Me.cboModels, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboProducts, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboLocations, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlInfo.ResumeLayout(False)
            CType(Me.cboShipType, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Loading"

        Private Sub frmProduceSpecialLot_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            lblTitle.Text = "Produce Lot Without Serial Number"
            LoadProducts()
            'Load, set ShipType default to Refurbished, and disable combo for now. 
            LoadShipType()
            Me.cboShipType.Text = "Refurbished"
            Me.cboShipType.Enabled = False

            ResetVariables()
  
        End Sub

        '********************************************************************************************************

        Private Sub LoadProducts()
            Dim dt As DataTable
            Try
                Me._booPopDataToCombo = True
                Me.cboProducts.DataSource = Nothing : Me.cboProducts.Text = ""
                dt = Generic.GetProducts(True)
                Misc.PopulateC1DropDownList(Me.cboProducts, dt, "Prod_Desc", "Prod_ID")
                Me.cboProducts.SelectedValue = 0
                Me._ProdID = 0

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Gui.GenericProcess.frmProduceSpecialLot_LoadProducts", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                _booPopDataToCombo = False
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '********************************************************************************************************

        Private Sub LoadCustomers()
            Dim dt As DataTable
            Try
                Me._booPopDataToCombo = True
                Me.cboCustomers.DataSource = Nothing : Me.cboCustomers.Text = ""
                dt = Generic.GetCustomers(True, Me._ProdID)
                Misc.PopulateC1DropDownList(Me.cboCustomers, dt, "Cust_Name1", "Cust_ID")
                Me.cboCustomers.SelectedValue = 0
                Me._CusID = 0

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Gui.GenericProcess.frmProduceSpecialLot_LoadCustomers", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                _booPopDataToCombo = False
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '********************************************************************************************************

        Private Sub LoadLocations()
            Dim dt As DataTable
            Try
                Me._booPopDataToCombo = True
                Me.cboLocations.DataSource = Nothing : Me.cboLocations.Text = ""
                dt = Generic.GetLocations(True, Me.cboCustomers.SelectedValue)
                Misc.PopulateC1DropDownList(Me.cboLocations, dt, "Loc_Name", "Loc_ID")
                Me.cboLocations.SelectedValue = 0
                Me._LocID = 0
                Me.cboLocations.Enabled = True
                If dt.Rows.Count = 2 Then
                    Me.cboLocations.SelectedValue = dt.Rows(0)("Loc_ID")
                    Me._LocID = Me.cboLocations.SelectedValue
                    Me.cboLocations.Enabled = False
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Gui.GenericProcess.frmProduceSpecialLot_LoadLocations", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                _booPopDataToCombo = False
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '********************************************************************************************************

        Private Sub LoadModels()
            Dim dt As DataTable
            Try
                Me._booPopDataToCombo = True
                Me.cboModels.DataSource = Nothing : Me.cboModels.Text = ""
                dt = Generic.GetModels(True, Me._ProdID)
                Misc.PopulateC1DropDownList(Me.cboModels, dt, "Model_Desc", "Model_ID")
                Me.cboModels.SelectedValue = 0
                Me._ModelID = 0

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Gui.GenericProcess.frmProduceSpecialLot_LoadModels", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                _booPopDataToCombo = False
                Generic.DisposeDT(dt)
            End Try
        End Sub
        '********************************************************************************************************
        Private Sub LoadShipType()

            Dim dt As New DataTable()
            Dim objNespresso As New PSS.Data.Buisness.Nespresso.Nespresso()

            Try

                Me._booPopDataToCombo = True
                Me.cboShipType.DataSource = Nothing : Me.cboShipType.Text = ""
                dt = objNespresso.GetShipType(True)
                Misc.PopulateC1DropDownList(Me.cboShipType, dt, "Pallettype_LDesc", "PalletType_ID")
                Me.cboShipType.SelectedValue = 0

            Catch ex As Exception
                MsgBox("Error in Nespresso.frmBuildShipBox_LoadShipType: " & ex.Message.ToString, MsgBoxStyle.Critical)
            Finally
                Generic.DisposeDT(dt)
                If Not IsNothing(objNespresso) Then objNespresso = Nothing
                Me._booPopDataToCombo = False
            End Try

        End Sub

        '********************************************************************************************************

#End Region

#Region "Combo/ Button / Text Events "

        '********************************************************************************************************
        Private Sub Contrls_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLotPallet.KeyUp, txtQuantity.KeyUp

            Dim objPJoins As New PSS.Data.Production.Joins()
            Dim dtPalletName As DataTable

            Try
                Me.Status.Text = ""
                Me.btnProduce.Visible = False

                If sender.name = "txtLotPallet" And e.KeyCode = Keys.Enter Then
                    Me.txtLotPallet.Text = Trim(Me.txtLotPallet.Text).ToUpper
                    If Me.txtLotPallet.Text = "" Then
                        Me.Status.ForeColor = Color.Red
                        Me.Status.Text = "Please scan or enter Lot or Pallet name...."
                        Exit Sub
                    Else
                        dtPalletName = objPJoins.GenericSelect("SELECT Pallett_Name From tpallett WHERE Pallett_Name= '" & Me.txtLotPallet.Text & "'")
                        If dtPalletName.Rows.Count > 0 Then
                            Me.Status.ForeColor = Color.Red
                            Me.Status.Text = "This Lot or Pallet# :" & Me.txtLotPallet.Text & " already entered in the system...."
                            Me.txtLotPallet.Text = ""
                            Me.txtLotPallet.Focus()
                            Exit Sub
                        Else
                            Me.txtQuantity.Focus()
                            Me.doValidation()
                        End If
                    End If

                ElseIf sender.name = "txtQuantity" And e.KeyCode = Keys.Enter Then
                    Me.txtQuantity.Text = Trim(Me.txtQuantity.Text)
                    If Me.txtQuantity.Text = "" Then
                        Me.Status.ForeColor = Color.Red
                        Me.Status.Text = "Invalid Quantity ! Please enter quantity...."
                        Exit Sub
                    ElseIf IsNumeric(Me.txtQuantity.Text) = False Then
                        Me.Status.ForeColor = Color.Red
                        Me.Status.Text = "Invalid Quantity ! The quantity you entered: '" & Me.txtQuantity.Text & "' is not a number...."
                        Me.txtQuantity.Text = ""
                        Me.txtQuantity.Focus()
                        Exit Sub
                    ElseIf CInt(Me.txtQuantity.Text) < 1 Then
                        Me.Status.ForeColor = Color.Red
                        Me.Status.Text = "Invalid Quantity ! The quantity must greater than 0 "
                        Me.txtQuantity.Text = ""
                        Me.txtQuantity.Focus()
                        Exit Sub
                    Else
                        Me.doValidation()
                    End If

                End If



            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Gui.Nespresso.frmReceiving_Contrls_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            Finally
                Buisness.Generic.DisposeDT(dtPalletName)
                objPJoins = Nothing
            End Try

        End Sub

        '********************************************************************************************************

        Private Sub cbo_RowChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProducts.RowChange, cboCustomers.RowChange, cboLocations.RowChange, cboModels.RowChange

            Try
                If Me._booPopDataToCombo = False Then
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    Me.Status.Text = ""
                    Me.btnProduce.Visible = False


                    If sender.name = "cboProducts" Then
                        Me._ProdID = 0
                        If Me.cboProducts.SelectedValue > 0 Then
                            Me._ProdID = Me.cboProducts.SelectedValue
                            Me.LoadCustomers()
                            Me.LoadModels()
                            Me.cboLocations.DataSource = Nothing : Me.cboLocations.Text = ""
                            Me._LocID = 0
                            Me.cboCustomers.Focus()
                        End If

                    ElseIf sender.name = "cboCustomers" Then
                        Me._CusID = 0
                        If Me.cboCustomers.SelectedValue > 0 Then
                            Me._CusID = Me.cboCustomers.SelectedValue
                            Me.LoadLocations()
                        End If

                    ElseIf sender.name = "cboLocations" Then
                        Me._LocID = 0
                        If Me.cboLocations.SelectedValue > 0 Then
                            Me._LocID = Me.cboLocations.SelectedValue
                        End If
                    ElseIf sender.name = "cboModels" Then
                        Me._ModelID = 0
                        If Me.cboModels.SelectedValue > 0 Then
                            Me._ModelID = Me.cboModels.SelectedValue
                            Me.txtLotPallet.Focus()
                        End If

                    End If

                    Me.doValidation()

                End If


            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cbo_RowChange", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub
        '*************************************************************************************************************
        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click

            Me.ResetVariables()

        End Sub
        '*************************************************************************************************************

        Private Sub btnProduce_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProduce.Click
            Dim iPallet_ID As Integer
            Dim objclsGeneric As New Buisness.GenericProcess.clsGenericProcess()
            Dim strWorkDate As String = PSS.Core.Global.ApplicationUser.Workdate

            Dim objMisc As New PSS.Data.Buisness.Misc()
            Dim strdate As String = Format(CDate(strWorkDate), "MMddyy")
            Dim strShortCustomer = Microsoft.VisualBasic.Left(Me.cboCustomers.Text.ToUpper, 3)
            Dim strShortModelName = Trim(objMisc.GetShortModelName(Me.cboModels.SelectedValue))
            Dim strPalletName
            Dim strShortShipType = Microsoft.VisualBasic.Left(cboShipType.Text.ToUpper, 3)
            Dim strLastAlphaInPallet = objMisc.GetLastCharFromPalletName(strShortCustomer & strShortModelName, strdate)

            strPalletName = strShortCustomer & strShortShipType & strdate & strLastAlphaInPallet
            Me.txtLotPallet.Text = strPalletName

            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                iPallet_ID = objclsGeneric.CreateSpecialLotPallet(Me._CusID, Me._LocID, Me._ModelID, Me.txtLotPallet.Text, strWorkDate, 1, 1, 1, Me.txtQuantity.Text)
                If iPallet_ID > 0 Then
                    Me.Enabled = True 'enable to set focus
                    'Print 4x4 Label if required
                    PSS.Data.Production.Shipping.Print4x4GenericShipBoxLabel(iPallet_ID, PSS.Data.Buisness.Nespresso.Nespresso.ShipBoxLabelLocation, 1)
                    Me.Status.ForeColor = Color.Lime
                    Me.Status.Text = "The Lot/Pallet# " & Me.txtLotPallet.Text & " has been created successful ! Please move this Lot/Pallet to shipping area ..."
                    Me.btnProduce.Visible = False
                    Me.txtLotPallet.Text = ""
                    Me.txtQuantity.Text = ""
                    Me.txtLotPallet.Focus()

                Else
                    Me.Status.ForeColor = Color.Red
                    Me.Status.Text = "ERROR: Unable to produce this Lot/Pallet# " & Me.txtLotPallet.Text & ". An error occurs during tPallet insertion. Please capture the screen and contact IT Department."
                End If


            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnProduce_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally

                If Not IsNothing(objclsGeneric) Then objclsGeneric = Nothing
                If Not IsNothing(objMisc) Then objMisc = Nothing
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub
        '*************************************************************************************************************

#End Region

#Region "Functions & Subs"



        '*******************************************************************

        Private Sub ResetVariables()

            'Clear global variable
            Me.btnProduce.Visible = False
            Me._LocID = 0
            Me._ProdID = 0
            Me._CusID = 0
            Me._ModelID = 0
            Me.cboProducts.SelectedValue = 0
            Me.cboCustomers.DataSource = Nothing : Me.cboCustomers.Text = ""
            Me.cboLocations.DataSource = Nothing : Me.cboLocations.Text = ""
            Me.cboModels.DataSource = Nothing : Me.cboModels.Text = ""
            Me.txtLotPallet.Text = ""
            Me.txtLotPallet.Enabled = False
            Me.txtQuantity.Text = ""
            Me.Status.ForeColor = Color.Lime
            'Me.Status.Text = "Select Product, Customer, Location, Models, and enter Lot Number and Quantity ..."
            Me.Status.Text = "Select Product, Customer, Location, Models, and Quantity ..."
            'Me.cboProducts.Focus()
            Me.txtQuantity.Focus()

        End Sub
        '*******************************************************************

        Private Sub doValidation()

            Me.btnProduce.Visible = False
            Me.Status.ForeColor = Color.Lime
            Dim objMisc As New PSS.Data.Buisness.Misc()

            Try

                'If Me._ProdID <> 0 And Me._CusID <> 0 And Me._LocID <> 0 And Me._ModelID <> 0 And Me.txtLotPallet.Text <> "" And Me.txtQuantity.Text <> "" Then
                If Me._ProdID <> 0 And Me._CusID <> 0 And Me._LocID <> 0 And Me._ModelID <> 0 And Me.txtQuantity.Text <> "" Then
                    Dim strWorkDate As String = PSS.Core.Global.ApplicationUser.Workdate

                    Dim strdate As String = Format(CDate(strWorkDate), "MMddyy")
                    Dim strShortCustomer = Microsoft.VisualBasic.Left(Me.cboCustomers.Text.ToUpper, 3)
                    Dim strShortModelName = Trim(objMisc.GetShortModelName(Me.cboModels.SelectedValue))
                    Dim strPalletName
                    Dim strShortShipType = Microsoft.VisualBasic.Left(cboShipType.Text.ToUpper, 3)
                    Dim strLastAlphaInPallet = objMisc.GetLastCharFromPalletName(strShortCustomer & strShortModelName, strdate)
                    strPalletName = strShortCustomer & strShortShipType & strdate & strLastAlphaInPallet
                    Me.txtLotPallet.Text = strPalletName
                    Me.Status.Text = "The Lot/Pallet is ready. Click on the 'Produce' button to produce and ship ...."
                    Me.btnProduce.Visible = True

                ElseIf Me._ProdID = 0 Then
                    Me.Status.Text = "Please select Product from the list ...."
                ElseIf Me._CusID = 0 Then
                    Me.Status.Text = "Please select Customer from the list ...."
                ElseIf Me._LocID = 0 Then
                    Me.Status.Text = "Please select Location from the list ...."
                ElseIf Me._ModelID = 0 Then
                    Me.Status.Text = "Please select Model from the list ...."
                    'ElseIf Me.txtLotPallet.Text = "" Then
                    '    Me.Status.Text = "Please enter Lot or Pallet number ...."
                ElseIf Me.txtQuantity.Text = "" Then
                    Me.Status.Text = "Please enter quantity number ...."
                End If


            Catch ex As Exception
                MessageBox.Show(ex.ToString, "doValidation", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally

                If Not IsNothing(objMisc) Then objMisc = Nothing
            End Try
          


        End Sub
        '*******************************************************************

#End Region


    End Class
End Namespace