Namespace Gui.OrderEntry


    Public Class mtnPricingGroup
        Inherits System.Windows.Forms.Form

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
        Friend WithEvents grpPricingGroup As System.Windows.Forms.GroupBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents lblPrcType As System.Windows.Forms.Label
        Friend WithEvents cboPrcType As System.Windows.Forms.ComboBox
        Friend WithEvents cboProduct As System.Windows.Forms.ComboBox
        Friend WithEvents cboType As System.Windows.Forms.ComboBox
        Friend WithEvents txtLDesc As System.Windows.Forms.TextBox
        Friend WithEvents txtSDesc As System.Windows.Forms.TextBox
        Friend WithEvents lblProduct As System.Windows.Forms.Label
        Friend WithEvents lblType As System.Windows.Forms.Label
        Friend WithEvents lblLDesc As System.Windows.Forms.Label
        Friend WithEvents lblSDesc As System.Windows.Forms.Label
        Friend WithEvents btnAddPricingGroup As System.Windows.Forms.Button
        Friend WithEvents lblPrcGroup As System.Windows.Forms.Label
        Friend WithEvents cboPricingGroup As System.Windows.Forms.ComboBox
        Friend WithEvents tdbGrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents grpEdits As System.Windows.Forms.GroupBox
        Friend WithEvents lblRegular As System.Windows.Forms.Label
        Friend WithEvents lblWrty As System.Windows.Forms.Label
        Friend WithEvents txtRegular As System.Windows.Forms.TextBox
        Friend WithEvents txtWarranty As System.Windows.Forms.TextBox
        Friend WithEvents btnUpdate As System.Windows.Forms.Button
        Friend WithEvents lblProdGroup As System.Windows.Forms.Label
        Friend WithEvents cboProductGroup As System.Windows.Forms.ComboBox
        Friend WithEvents btnModify As System.Windows.Forms.Button
        Friend WithEvents lblTier As System.Windows.Forms.Label
        Friend WithEvents cboTier As System.Windows.Forms.ComboBox
        Friend WithEvents grpAggregates As System.Windows.Forms.GroupBox
        Friend WithEvents btnRemove As System.Windows.Forms.Button
        Friend WithEvents btnInsert As System.Windows.Forms.Button
        Friend WithEvents txtAmount As System.Windows.Forms.TextBox
        Friend WithEvents txtBillCode As System.Windows.Forms.TextBox
        Friend WithEvents Label70 As System.Windows.Forms.Label
        Friend WithEvents Label69 As System.Windows.Forms.Label
        Friend WithEvents gridAggregate As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents Label68 As System.Windows.Forms.Label
        Friend WithEvents lstAggCodes As System.Windows.Forms.ListBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(mtnPricingGroup))
            Me.grpPricingGroup = New System.Windows.Forms.GroupBox()
            Me.btnAddPricingGroup = New System.Windows.Forms.Button()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.lblPrcType = New System.Windows.Forms.Label()
            Me.cboPrcType = New System.Windows.Forms.ComboBox()
            Me.cboProduct = New System.Windows.Forms.ComboBox()
            Me.cboType = New System.Windows.Forms.ComboBox()
            Me.txtLDesc = New System.Windows.Forms.TextBox()
            Me.txtSDesc = New System.Windows.Forms.TextBox()
            Me.lblProduct = New System.Windows.Forms.Label()
            Me.lblType = New System.Windows.Forms.Label()
            Me.lblLDesc = New System.Windows.Forms.Label()
            Me.lblSDesc = New System.Windows.Forms.Label()
            Me.lblPrcGroup = New System.Windows.Forms.Label()
            Me.cboPricingGroup = New System.Windows.Forms.ComboBox()
            Me.tdbGrid = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.grpEdits = New System.Windows.Forms.GroupBox()
            Me.cboTier = New System.Windows.Forms.ComboBox()
            Me.lblTier = New System.Windows.Forms.Label()
            Me.cboProductGroup = New System.Windows.Forms.ComboBox()
            Me.lblProdGroup = New System.Windows.Forms.Label()
            Me.btnUpdate = New System.Windows.Forms.Button()
            Me.txtWarranty = New System.Windows.Forms.TextBox()
            Me.txtRegular = New System.Windows.Forms.TextBox()
            Me.lblWrty = New System.Windows.Forms.Label()
            Me.lblRegular = New System.Windows.Forms.Label()
            Me.btnModify = New System.Windows.Forms.Button()
            Me.grpAggregates = New System.Windows.Forms.GroupBox()
            Me.btnRemove = New System.Windows.Forms.Button()
            Me.btnInsert = New System.Windows.Forms.Button()
            Me.txtAmount = New System.Windows.Forms.TextBox()
            Me.txtBillCode = New System.Windows.Forms.TextBox()
            Me.Label70 = New System.Windows.Forms.Label()
            Me.Label69 = New System.Windows.Forms.Label()
            Me.gridAggregate = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label68 = New System.Windows.Forms.Label()
            Me.lstAggCodes = New System.Windows.Forms.ListBox()
            Me.grpPricingGroup.SuspendLayout()
            CType(Me.tdbGrid, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grpEdits.SuspendLayout()
            Me.grpAggregates.SuspendLayout()
            CType(Me.gridAggregate, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'grpPricingGroup
            '
            Me.grpPricingGroup.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnAddPricingGroup, Me.Label6, Me.lblPrcType, Me.cboPrcType, Me.cboProduct, Me.cboType, Me.txtLDesc, Me.txtSDesc, Me.lblProduct, Me.lblType, Me.lblLDesc, Me.lblSDesc})
            Me.grpPricingGroup.Location = New System.Drawing.Point(16, 16)
            Me.grpPricingGroup.Name = "grpPricingGroup"
            Me.grpPricingGroup.Size = New System.Drawing.Size(312, 168)
            Me.grpPricingGroup.TabIndex = 0
            Me.grpPricingGroup.TabStop = False
            Me.grpPricingGroup.Text = "Define Pricing Group"
            '
            'btnAddPricingGroup
            '
            Me.btnAddPricingGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnAddPricingGroup.Location = New System.Drawing.Point(264, 136)
            Me.btnAddPricingGroup.Name = "btnAddPricingGroup"
            Me.btnAddPricingGroup.Size = New System.Drawing.Size(40, 23)
            Me.btnAddPricingGroup.TabIndex = 6
            Me.btnAddPricingGroup.Text = "Add"
            '
            'Label6
            '
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.Location = New System.Drawing.Point(184, 32)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(72, 16)
            Me.Label6.TabIndex = 21
            Me.Label6.Text = "max length (4)"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'lblPrcType
            '
            Me.lblPrcType.BackColor = System.Drawing.Color.SteelBlue
            Me.lblPrcType.ForeColor = System.Drawing.Color.White
            Me.lblPrcType.Location = New System.Drawing.Point(16, 128)
            Me.lblPrcType.Name = "lblPrcType"
            Me.lblPrcType.Size = New System.Drawing.Size(100, 16)
            Me.lblPrcType.TabIndex = 0
            Me.lblPrcType.Text = "Pricing Type:"
            Me.lblPrcType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboPrcType
            '
            Me.cboPrcType.Location = New System.Drawing.Point(120, 128)
            Me.cboPrcType.Name = "cboPrcType"
            Me.cboPrcType.Size = New System.Drawing.Size(121, 21)
            Me.cboPrcType.TabIndex = 5
            '
            'cboProduct
            '
            Me.cboProduct.Location = New System.Drawing.Point(120, 104)
            Me.cboProduct.Name = "cboProduct"
            Me.cboProduct.Size = New System.Drawing.Size(121, 21)
            Me.cboProduct.TabIndex = 4
            '
            'cboType
            '
            Me.cboType.Location = New System.Drawing.Point(120, 80)
            Me.cboType.Name = "cboType"
            Me.cboType.Size = New System.Drawing.Size(121, 21)
            Me.cboType.TabIndex = 3
            '
            'txtLDesc
            '
            Me.txtLDesc.Location = New System.Drawing.Point(120, 56)
            Me.txtLDesc.Name = "txtLDesc"
            Me.txtLDesc.Size = New System.Drawing.Size(184, 20)
            Me.txtLDesc.TabIndex = 2
            Me.txtLDesc.Text = ""
            '
            'txtSDesc
            '
            Me.txtSDesc.Location = New System.Drawing.Point(120, 32)
            Me.txtSDesc.Name = "txtSDesc"
            Me.txtSDesc.Size = New System.Drawing.Size(56, 20)
            Me.txtSDesc.TabIndex = 1
            Me.txtSDesc.Text = ""
            '
            'lblProduct
            '
            Me.lblProduct.BackColor = System.Drawing.Color.SteelBlue
            Me.lblProduct.ForeColor = System.Drawing.Color.White
            Me.lblProduct.Location = New System.Drawing.Point(16, 104)
            Me.lblProduct.Name = "lblProduct"
            Me.lblProduct.Size = New System.Drawing.Size(100, 16)
            Me.lblProduct.TabIndex = 0
            Me.lblProduct.Text = "Product:"
            Me.lblProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblType
            '
            Me.lblType.Location = New System.Drawing.Point(16, 80)
            Me.lblType.Name = "lblType"
            Me.lblType.Size = New System.Drawing.Size(100, 16)
            Me.lblType.TabIndex = 0
            Me.lblType.Text = "Type:"
            Me.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblLDesc
            '
            Me.lblLDesc.Location = New System.Drawing.Point(16, 56)
            Me.lblLDesc.Name = "lblLDesc"
            Me.lblLDesc.Size = New System.Drawing.Size(100, 16)
            Me.lblLDesc.TabIndex = 0
            Me.lblLDesc.Text = "Long Description:"
            Me.lblLDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblSDesc
            '
            Me.lblSDesc.Location = New System.Drawing.Point(16, 32)
            Me.lblSDesc.Name = "lblSDesc"
            Me.lblSDesc.Size = New System.Drawing.Size(100, 16)
            Me.lblSDesc.TabIndex = 0
            Me.lblSDesc.Text = "Short Description:"
            Me.lblSDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblPrcGroup
            '
            Me.lblPrcGroup.Location = New System.Drawing.Point(16, 192)
            Me.lblPrcGroup.Name = "lblPrcGroup"
            Me.lblPrcGroup.Size = New System.Drawing.Size(80, 16)
            Me.lblPrcGroup.TabIndex = 1
            Me.lblPrcGroup.Text = "Pricing Group:"
            Me.lblPrcGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboPricingGroup
            '
            Me.cboPricingGroup.Location = New System.Drawing.Point(96, 192)
            Me.cboPricingGroup.Name = "cboPricingGroup"
            Me.cboPricingGroup.Size = New System.Drawing.Size(232, 21)
            Me.cboPricingGroup.TabIndex = 6
            '
            'tdbGrid
            '
            Me.tdbGrid.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdbGrid.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.tdbGrid.Location = New System.Drawing.Point(0, 224)
            Me.tdbGrid.Name = "tdbGrid"
            Me.tdbGrid.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdbGrid.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdbGrid.PreviewInfo.ZoomFactor = 75
            Me.tdbGrid.Size = New System.Drawing.Size(528, 168)
            Me.tdbGrid.TabIndex = 14
            Me.tdbGrid.Text = "C1TrueDBGrid1"
            Me.tdbGrid.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Style14{}Normal{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}S" & _
            "tyle9{}OddRow{}RecordSelector{AlignImage:Center;}Style15{}Heading{Wrap:True;Alig" & _
            "nVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}" & _
            "Style8{}Style10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style1{}</Data></Styl" & _
            "es><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" CaptionHeight=""17"" ColumnCapti" & _
            "onHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSele" & _
            "ctorWidth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup" & _
            "=""1""><Height>164</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorSty" & _
            "le parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><F" & _
            "ilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=" & _
            """Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Headi" & _
            "ng"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><Inacti" & _
            "veStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9""" & _
            " /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle pa" & _
            "rent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0" & _
            ", 0, 524, 164</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderS" & _
            "tyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""" & _
            "Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Foot" & _
            "er"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactiv" & _
            "e"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /" & _
            "><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" " & _
            "/><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelecto" & _
            "r"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" " & _
            "/></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None" & _
            "</Layout><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 524, 164</" & _
            "ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle " & _
            "parent="""" me=""Style15"" /></Blob>"
            '
            'grpEdits
            '
            Me.grpEdits.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboTier, Me.lblTier, Me.cboProductGroup, Me.lblProdGroup, Me.btnUpdate, Me.txtWarranty, Me.txtRegular, Me.lblWrty, Me.lblRegular})
            Me.grpEdits.Location = New System.Drawing.Point(336, 16)
            Me.grpEdits.Name = "grpEdits"
            Me.grpEdits.Size = New System.Drawing.Size(200, 168)
            Me.grpEdits.TabIndex = 13
            Me.grpEdits.TabStop = False
            Me.grpEdits.Text = "Modification Group"
            '
            'cboTier
            '
            Me.cboTier.Location = New System.Drawing.Point(128, 56)
            Me.cboTier.Name = "cboTier"
            Me.cboTier.Size = New System.Drawing.Size(64, 21)
            Me.cboTier.TabIndex = 9
            '
            'lblTier
            '
            Me.lblTier.Location = New System.Drawing.Point(96, 56)
            Me.lblTier.Name = "lblTier"
            Me.lblTier.Size = New System.Drawing.Size(32, 16)
            Me.lblTier.TabIndex = 8
            Me.lblTier.Text = "Tier:"
            Me.lblTier.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboProductGroup
            '
            Me.cboProductGroup.Location = New System.Drawing.Point(16, 32)
            Me.cboProductGroup.Name = "cboProductGroup"
            Me.cboProductGroup.Size = New System.Drawing.Size(176, 21)
            Me.cboProductGroup.TabIndex = 8
            '
            'lblProdGroup
            '
            Me.lblProdGroup.Location = New System.Drawing.Point(16, 16)
            Me.lblProdGroup.Name = "lblProdGroup"
            Me.lblProdGroup.Size = New System.Drawing.Size(88, 16)
            Me.lblProdGroup.TabIndex = 6
            Me.lblProdGroup.Text = "Product Group:"
            '
            'btnUpdate
            '
            Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnUpdate.Location = New System.Drawing.Point(88, 136)
            Me.btnUpdate.Name = "btnUpdate"
            Me.btnUpdate.Size = New System.Drawing.Size(104, 23)
            Me.btnUpdate.TabIndex = 12
            Me.btnUpdate.Text = "Update/Insert"
            '
            'txtWarranty
            '
            Me.txtWarranty.Location = New System.Drawing.Point(88, 104)
            Me.txtWarranty.Name = "txtWarranty"
            Me.txtWarranty.TabIndex = 11
            Me.txtWarranty.Text = ""
            '
            'txtRegular
            '
            Me.txtRegular.Location = New System.Drawing.Point(88, 80)
            Me.txtRegular.Name = "txtRegular"
            Me.txtRegular.TabIndex = 10
            Me.txtRegular.Text = ""
            '
            'lblWrty
            '
            Me.lblWrty.Location = New System.Drawing.Point(24, 104)
            Me.lblWrty.Name = "lblWrty"
            Me.lblWrty.Size = New System.Drawing.Size(56, 16)
            Me.lblWrty.TabIndex = 1
            Me.lblWrty.Text = "Warranty:"
            Me.lblWrty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblRegular
            '
            Me.lblRegular.Location = New System.Drawing.Point(24, 80)
            Me.lblRegular.Name = "lblRegular"
            Me.lblRegular.Size = New System.Drawing.Size(56, 16)
            Me.lblRegular.TabIndex = 0
            Me.lblRegular.Text = "Regular:"
            Me.lblRegular.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnModify
            '
            Me.btnModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnModify.Location = New System.Drawing.Point(336, 192)
            Me.btnModify.Name = "btnModify"
            Me.btnModify.TabIndex = 7
            Me.btnModify.Text = "Modify"
            '
            'grpAggregates
            '
            Me.grpAggregates.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRemove, Me.btnInsert, Me.txtAmount, Me.txtBillCode, Me.Label70, Me.Label69, Me.gridAggregate, Me.Label68, Me.lstAggCodes})
            Me.grpAggregates.Location = New System.Drawing.Point(552, 16)
            Me.grpAggregates.Name = "grpAggregates"
            Me.grpAggregates.Size = New System.Drawing.Size(240, 376)
            Me.grpAggregates.TabIndex = 45
            Me.grpAggregates.TabStop = False
            Me.grpAggregates.Text = "Aggregate Billing"
            '
            'btnRemove
            '
            Me.btnRemove.Location = New System.Drawing.Point(160, 184)
            Me.btnRemove.Name = "btnRemove"
            Me.btnRemove.Size = New System.Drawing.Size(72, 24)
            Me.btnRemove.TabIndex = 52
            Me.btnRemove.Text = "Remove"
            '
            'btnInsert
            '
            Me.btnInsert.Location = New System.Drawing.Point(80, 184)
            Me.btnInsert.Name = "btnInsert"
            Me.btnInsert.Size = New System.Drawing.Size(72, 24)
            Me.btnInsert.TabIndex = 51
            Me.btnInsert.Text = "Insert"
            '
            'txtAmount
            '
            Me.txtAmount.Location = New System.Drawing.Point(80, 160)
            Me.txtAmount.Name = "txtAmount"
            Me.txtAmount.TabIndex = 50
            Me.txtAmount.Text = ""
            '
            'txtBillCode
            '
            Me.txtBillCode.Location = New System.Drawing.Point(80, 136)
            Me.txtBillCode.Name = "txtBillCode"
            Me.txtBillCode.TabIndex = 49
            Me.txtBillCode.Text = ""
            '
            'Label70
            '
            Me.Label70.Location = New System.Drawing.Point(16, 160)
            Me.Label70.Name = "Label70"
            Me.Label70.Size = New System.Drawing.Size(56, 16)
            Me.Label70.TabIndex = 48
            Me.Label70.Text = "Amount:"
            Me.Label70.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label69
            '
            Me.Label69.Location = New System.Drawing.Point(16, 136)
            Me.Label69.Name = "Label69"
            Me.Label69.Size = New System.Drawing.Size(56, 16)
            Me.Label69.TabIndex = 47
            Me.Label69.Text = "BillCode:"
            Me.Label69.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'gridAggregate
            '
            Me.gridAggregate.AllowColMove = False
            Me.gridAggregate.AllowColSelect = False
            Me.gridAggregate.AllowDelete = True
            Me.gridAggregate.AllowFilter = False
            Me.gridAggregate.AllowSort = False
            Me.gridAggregate.AllowUpdate = False
            Me.gridAggregate.AlternatingRows = True
            Me.gridAggregate.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.gridAggregate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.gridAggregate.CaptionHeight = 17
            Me.gridAggregate.GroupByCaption = "Drag a column header here to group by that column"
            Me.gridAggregate.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.gridAggregate.Location = New System.Drawing.Point(16, 240)
            Me.gridAggregate.Name = "gridAggregate"
            Me.gridAggregate.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.gridAggregate.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.gridAggregate.PreviewInfo.ZoomFactor = 75
            Me.gridAggregate.RowHeight = 15
            Me.gridAggregate.Size = New System.Drawing.Size(208, 128)
            Me.gridAggregate.TabIndex = 46
            Me.gridAggregate.Text = "C1TrueDBGrid1"
            Me.gridAggregate.PropBag = "<?xml version=""1.0""?><Blob><DataCols><C1DataColumn Caption=""BillCode"" DataField=""" & _
            """><ValueItems /><GroupInfo /></C1DataColumn><C1DataColumn Caption=""ID"" DataField" & _
            "=""""><ValueItems /><GroupInfo /></C1DataColumn><C1DataColumn Caption=""Amount"" Dat" & _
            "aField=""""><ValueItems /><GroupInfo /></C1DataColumn></DataCols><Styles type=""C1." & _
            "Win.C1TrueDBGrid.Design.ContextWrapper""><Data>Caption{AlignHorz:Center;}Style27{" & _
            "}Normal{Font:Verdana, 8.25pt;}Style25{}Selected{ForeColor:HighlightText;BackColo" & _
            "r:Highlight;}Editor{}Style18{AlignHorz:Near;}Style19{AlignHorz:Near;}Style14{Ali" & _
            "gnHorz:Near;}Style15{AlignHorz:Near;}Style16{}Style17{}Style10{AlignHorz:Near;}S" & _
            "tyle11{}OddRow{}Style13{}Style12{}Style32{}Style33{}Style31{}Footer{}Style29{}St" & _
            "yle28{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style26{}Record" & _
            "Selector{AlignImage:Center;}Style24{}Style23{AlignHorz:Near;}Style22{AlignHorz:N" & _
            "ear;}Style21{}Style20{}Inactive{ForeColor:InactiveCaptionText;BackColor:Inactive" & _
            "Caption;}EvenRow{BackColor:Aqua;}Heading{Wrap:True;AlignVert:Center;Border:Raise" & _
            "d,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}FilterBar{}Style4{}Style9" & _
            "{}Style8{}Style5{}Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:" & _
            "Center;}Style7{}Style6{}Style1{}Style30{}Style3{}Style2{}</Data></Styles><Splits" & _
            "><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" Name" & _
            "="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" Colum" & _
            "nFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefR" & _
            "ecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>126</H" & _
            "eight><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" " & _
            "me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle paren" & _
            "t=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupSt" & _
            "yle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><" & _
            "HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Ina" & _
            "ctive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorS" & _
            "tyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=" & _
            """Style6"" /><Style parent=""Normal"" me=""Style1"" /><internalCols><C1DisplayColumn><" & _
            "HeadingStyle parent=""Style2"" me=""Style14"" /><Style parent=""Style1"" me=""Style15"" " & _
            "/><FooterStyle parent=""Style3"" me=""Style16"" /><EditorStyle parent=""Style5"" me=""S" & _
            "tyle17"" /><GroupHeaderStyle parent=""Style1"" me=""Style29"" /><GroupFooterStyle par" & _
            "ent=""Style1"" me=""Style28"" /><Visible>True</Visible><ColumnDivider>DarkGray,Singl" & _
            "e</ColumnDivider><Height>15</Height><DCIdx>0</DCIdx></C1DisplayColumn><C1Display" & _
            "Column><HeadingStyle parent=""Style2"" me=""Style18"" /><Style parent=""Style1"" me=""S" & _
            "tyle19"" /><FooterStyle parent=""Style3"" me=""Style20"" /><EditorStyle parent=""Style" & _
            "5"" me=""Style21"" /><GroupHeaderStyle parent=""Style1"" me=""Style31"" /><GroupFooterS" & _
            "tyle parent=""Style1"" me=""Style30"" /><Visible>True</Visible><ColumnDivider>DarkGr" & _
            "ay,Single</ColumnDivider><Height>15</Height><DCIdx>1</DCIdx></C1DisplayColumn><C" & _
            "1DisplayColumn><HeadingStyle parent=""Style2"" me=""Style22"" /><Style parent=""Style" & _
            "1"" me=""Style23"" /><FooterStyle parent=""Style3"" me=""Style24"" /><EditorStyle paren" & _
            "t=""Style5"" me=""Style25"" /><GroupHeaderStyle parent=""Style1"" me=""Style33"" /><Grou" & _
            "pFooterStyle parent=""Style1"" me=""Style32"" /><Visible>True</Visible><ColumnDivide" & _
            "r>DarkGray,Single</ColumnDivider><Height>15</Height><DCIdx>2</DCIdx></C1DisplayC" & _
            "olumn></internalCols><ClientRect>0, 0, 206, 126</ClientRect><BorderSide>0</Borde" & _
            "rSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits>" & _
            "<NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" " & _
            "/><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><" & _
            "Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><S" & _
            "tyle parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><S" & _
            "tyle parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style " & _
            "parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><" & _
            "Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><hor" & _
            "zSplits>1</horzSplits><Layout>Modified</Layout><DefaultRecSelWidth>16</DefaultRe" & _
            "cSelWidth><ClientArea>0, 0, 206, 126</ClientArea><PrintPageHeaderStyle parent=""""" & _
            " me=""Style26"" /><PrintPageFooterStyle parent="""" me=""Style27"" /></Blob>"
            '
            'Label68
            '
            Me.Label68.Location = New System.Drawing.Point(16, 24)
            Me.Label68.Name = "Label68"
            Me.Label68.Size = New System.Drawing.Size(120, 32)
            Me.Label68.TabIndex = 45
            Me.Label68.Text = "Available Aggregate Bill Codes"
            Me.Label68.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lstAggCodes
            '
            Me.lstAggCodes.Location = New System.Drawing.Point(16, 56)
            Me.lstAggCodes.Name = "lstAggCodes"
            Me.lstAggCodes.Size = New System.Drawing.Size(120, 69)
            Me.lstAggCodes.TabIndex = 44
            '
            'mtnPricingGroup
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(808, 397)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpAggregates, Me.btnModify, Me.grpEdits, Me.tdbGrid, Me.cboPricingGroup, Me.lblPrcGroup, Me.grpPricingGroup})
            Me.Name = "mtnPricingGroup"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Maintenance - Pricing Group"
            Me.grpPricingGroup.ResumeLayout(False)
            CType(Me.tdbGrid, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grpEdits.ResumeLayout(False)
            Me.grpAggregates.ResumeLayout(False)
            CType(Me.gridAggregate, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private xCount As Integer
        Private pricingGroupID As Int32
        Dim dsType, dsProd, dsPrcType As DataSet
        Dim dsPricingGroup As DataSet
        Dim dtGrid, dtProductGroup As New DataTable()

        Dim valPricing As String
        Dim recData As Boolean

        Private dtAggCodes, dtDefinedAggCodes As DataTable
        Private blnAggInsert As Boolean


        Private Sub mtnPricingGroup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            grpEdits.Visible = False

            '//Set initial values
            valPricing = "FLAT"

            '//Populate combo boxes to start form
            createDatasets()
            populateType()
            populateProduct()
            populatePrcType()

            '//Move to the first control on page
            txtSDesc.Focus()

            populatePricingGroup()
            createTdbGrid()

            Me.loadAggCodes()
            Me.loadDefinedAggCodes()

        End Sub

        Private Sub createTdbGrid()

            dtGrid.MinimumCapacity = 500
            dtGrid.CaseSensitive = False

            Dim colProdGrp As New DataColumn("Product Group")
            dtGrid.Columns.Add(colProdGrp)
            Dim colLaborLevel As New DataColumn("Labor Level")
            dtGrid.Columns.Add(colLaborLevel)
            Dim colRegPrc As New DataColumn("Regular Pricing")
            dtGrid.Columns.Add(colRegPrc)
            Dim colWrtyPrc As New DataColumn("Warranty Pricing")
            dtGrid.Columns.Add(colWrtyPrc)

        End Sub

        Private Function populatePricingGroup() As Boolean

            cboPricingGroup.Items.Clear()
            cboPricingGroup.Text = ""

            Try
                Dim r As DataRow
                Dim valProd As Integer = convertProduct(r)
                Dim tblPG As New PSS.Data.Production.lpricinggroup()
                dsPricingGroup = tblPG.GetRowsByProdID(valProd)
                tblPG = Nothing

                Dim rPricingGroup As DataRow
                For xCount = 0 To dsPricingGroup.Tables("lpricinggroup").Rows.Count - 1
                    rPricingGroup = dsPricingGroup.Tables("lpricinggroup").Rows(xCount)
                    cboPricingGroup.Items.Insert(xCount, rPricingGroup("PrcGroup_LDesc"))
                Next

            Catch exp As Exception
                'MsgBox(exp.tostring)
            End Try

            cboPricingGroup.Focus()

        End Function


#Region "Verify Data"

        Private Function verifyPricingGroup() As String

            Dim errMsg As String = ""

            '//Validate data for insertion to database
            '//cboPrcType - required
            If Len(cboPrcType.Text) < 1 Then
                errMsg += "Please select a rate type." & vbCrLf
                cboPrcType.Focus()
            End If

            '//cboProduct - required
            If Len(cboProduct.Text) < 1 Then
                errMsg += "Please select a product type." & vbCrLf
                cboProduct.Focus()
            End If

            '//cbotype - required
            If Len(cboType.Text) < 1 Then
                errMsg += "Please select a pricing type." & vbCrLf
                cboType.Focus()
            End If

            '//txtLDesc - required
            If Len(txtLDesc.Text) < 1 Then
                errMsg += "The long description field is required." & vbCrLf
                txtLDesc.Focus()
            ElseIf Len(txtLDesc.Text) > 255 Then
                errMsg += "The value for the long description field is too large." & vbCrLf
                txtLDesc.Focus()
            End If

            '//txtSDesc - not required
            If Len(txtSDesc.Text) > 4 Then
                errMsg += "The short description has to be 4 characters or less." & vbCrLf
                txtSDesc.Focus()
            End If

            verifyPricingGroup = errMsg

        End Function


#End Region


#Region "Populate Combo Boxes"

        Private Function createDatasets() As Boolean

            createDatasets = False

            Try
                Dim tblType As New PSS.Data.Production.lpgtype()
                dsType = tblType.GetData
                tblType = Nothing
            Catch exp As Exception
                'MsgBox(exp.tostring)
            End Try

            Try
                Dim tblProd As New PSS.Data.Production.lproduct()
                dsProd = tblProd.GetData
                'tblProd = Nothing
            Catch exp As Exception
                MsgBox(exp.tostring)
            End Try

            Try
                Dim tblPrcType As New PSS.Data.Production.lpricingtype()
                dsPrcType = tblPrcType.GetData
                'tblPrcType = Nothing
            Catch exp As Exception
                MsgBox(exp.tostring)
            End Try

            createDatasets = True

        End Function

        Private Function populateType() As Boolean

            populateType = False

            Try
                Dim rType As DataRow
                For xCount = 0 To dsType.Tables("lpgtype").Rows.Count - 1
                    '//load the records into the combo box
                    rType = dsType.Tables("lpgtype").Rows(xCount)
                    cboType.Items.Insert(xCount, rType("PGType_Desc"))
                Next

            Catch exp As Exception
                MsgBox(exp.ToString)
            Finally
                populateType = True
            End Try

        End Function

        Private Function populateProduct() As Boolean

            populateProduct = False

            Try
                Dim rProd As DataRow
                For xCount = 0 To dsProd.Tables("lproduct").Rows.Count - 1
                    '//load the records into the combo box
                    rProd = dsProd.Tables("lproduct").Rows(xCount)
                    cboProduct.Items.Insert(xCount, rProd("Prod_Desc"))
                Next

            Catch exp As Exception
                MsgBox(exp.ToString)
            Finally
                populateProduct = True
            End Try

        End Function

        Private Function populatePrcType() As Boolean

            populatePrcType = False

            Try
                Dim rPrcType As DataRow
                For xCount = 0 To dsPrcType.Tables("lpricingtype").Rows.Count - 1
                    '//load the records into the combo box
                    rPrcType = dsPrcType.Tables("lpricingtype").Rows(xCount)
                    cboPrcType.Items.Insert(xCount, rPrcType("PrcType_Desc"))
                Next

            Catch exp As Exception
                MsgBox(exp.ToString)
            Finally
                populatePrcType = True
            End Try

        End Function

#End Region

#Region "Group Actions Controls"

        Private Sub lockControls()

            txtSDesc.Enabled = False
            txtLDesc.Enabled = False
            cboType.Enabled = False
            cboProduct.Enabled = False
            cboPrcType.Enabled = False

        End Sub

        Private Sub enableControls()

            txtSDesc.Enabled = True
            txtLDesc.Enabled = True
            cboType.Enabled = True
            cboProduct.Enabled = True
            cboPrcType.Enabled = True

        End Sub

        Private Sub showControls()

            txtSDesc.Visible = True
            txtLDesc.Visible = True
            cboType.Visible = True
            cboProduct.Visible = True
            cboPrcType.Visible = True
            btnAddPricingGroup.Visible = True

        End Sub

#End Region

        Private Sub btnAddPricingGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddPricingGroup.Click

            Dim verify As String = verifyPricingGroup()

            If Len(Trim(verify)) > 0 Then
                MsgBox(verify, MsgBoxStyle.Exclamation, "Error")
                Exit Sub
            End If

            '//Convert combo box values to IDs
            Dim valType, valProd, valPrcType As Int32
            Dim r As DataRow

            valType = convertType(r)
            valProd = convertProduct(r)
            valPrcType = convertPrcType(r)

            '//Verify data is good for combo boxes
            If IsNumeric(valType) = True And IsNumeric(valProd) = True And IsNumeric(valPrcType) = True Then
                'Continue
            Else
                MsgBox("Problem with converting over combo box entries to IDs. Contact IT", MsgBoxStyle.Exclamation, "Error")
                Exit Sub
            End If

            '//Perform Insert
            Dim strFieldList As String = "(PrcGroup_SDesc, PrcGroup_LDesc, PrcGroup_Type, Prod_ID, PrcType_ID)"
            Dim strDataList As String = "( '" & txtSDesc.Text & "', '" & txtLDesc.Text & "', " & valType & ", " & valProd & ", " & valPrcType & ")"
            Dim strSQl As String = "INSERT into lpricinggroup " & strFieldList & " VALUES " & strDataList & ";"
            Dim xInsert As New PSS.Data.Production.lpricinggroup()
            Dim valID As Int32 = xInsert.idTransaction(strSQl)
            If IsNumeric(valID) = True Then
                '//Set value for part 2
                pricingGroupID = valID
            Else
                '//Throw error
                MsgBox("The record could not be saved to the database.", MsgBoxStyle.Exclamation, "Error")
                Exit Sub
            End If

            '//Lock controls for part 2
            lockControls()
            btnAddPricingGroup.Visible = False
            MsgBox("Save completed.", MsgBoxStyle.Information, "GOOD")
            '//Refresh cboPricingGroup
            populatePricingGroup()

            ''//Select newly added record from cboPricingGroup
            'For xCount = 0 To cboPricingGroup.Items.Count
            'If cboPricingGroup.Items(xCount) = txtLDesc.Text Then
            '    cboPricingGroup.SelectedIndex = xCount
            '    cboPricingGroup.Focus()
            '    Exit For
            'End If
            'Next

            'Continue on to part 2

        End Sub

        Private Sub cboProduct_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProduct.SelectedIndexChanged

            '//Clear out grid data is no longer accurate
            dtGrid.Clear()
            populatePricingGroup()

            grpEdits.Visible = False

            'Dim tblProductGroup As New PSS.Data.Production.lprodgrp()
            'Dim r As DataRow
            'Dim valProd As Int32 = convertProduct(r)
            'dtProductGroup = tblProductGroup.GetProdGrpByProdID(valProd)
            'cboProductGroup.Text = ""
            'cboProductGroup.Items.Clear()
            'For xCount = 0 To dtProductGroup.Rows.Count - 1
            '    r = dtProductGroup.Rows(xCount)
            '    cboProductGroup.Items.Insert(xCount, r("ProdGrp_LDesc"))
            'Next

        End Sub

        Private Sub cboPricingGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPricingGroup.SelectedIndexChanged

            grpEdits.Visible = False

            Dim r As DataRow
            Dim valProd As Int32 = convertProduct(r)
            If valProd < 1 Then
                '//Throw Error
                Exit Sub
            End If

            '//get the ID for Pricing Group
            For xCount = 0 To dsPricingGroup.Tables("lpricinggroup").Rows.Count - 1
                r = dsPricingGroup.Tables("lpricinggroup").Rows(xCount)
                If r("PrcGroup_LDesc") = cboPricingGroup.Text Then
                    pricingGroupID = r("PrcGroup_ID")
                    Exit For
                End If
            Next

            '//get data from tlaborprc
            Dim tblLaborPrc As New PSS.Data.Production.Joins()
            Dim dtLaborPrc As DataTable = tblLaborPrc.GetLaborPricingByPrcGroupProdID(valProd, pricingGroupID)

            '//Populate the grid
            dtGrid.Clear() '//Empty before refilling
            For xCount = 0 To dtLaborPrc.Rows.Count - 1
                r = dtLaborPrc.Rows(xCount)
                Dim dr1 As DataRow = dtGrid.NewRow
                dr1("Product Group") = Trim(r("ProdGrp_LDesc"))
                If IsDBNull(r("LaborLvl_ID")) = False Then
                    dr1("Labor Level") = Trim(r("LaborLvl_ID"))
                End If
                If IsDBNull(r("LaborPrc_RegPrc")) = False Then
                    dr1("Regular Pricing") = Trim(r("LaborPrc_RegPrc"))
                End If
                If IsDBNull(r("LaborPrc_WrtyPrc")) = False Then
                    dr1("Warranty Pricing") = Trim(r("LaborPrc_WrtyPrc"))
                End If
                dtGrid.Rows.Add(dr1)
            Next


            tdbGrid.DataSource = dtGrid

        End Sub

        Private Function convertType(ByVal ar As DataRow) As Int32

            For xCount = 0 To dsType.Tables("lpgtype").Rows.Count - 1
                ar = dsType.Tables("lpgtype").Rows(xCount)
                If ar("PGType_Desc") = cboType.Text Then
                    convertType = ar("PGType_ID")
                    Exit For
                End If
            Next

        End Function

        Private Function convertProduct(ByVal ar As DataRow) As Int32

            For xCount = 0 To dsProd.Tables("lproduct").Rows.Count - 1
                ar = dsProd.Tables("lproduct").Rows(xCount)
                If ar("Prod_Desc") = cboProduct.Text Then
                    convertProduct = ar("Prod_ID")
                    Exit For
                End If
            Next

        End Function

        Private Function convertPrcType(ByVal ar As DataRow) As Int32

            For xCount = 0 To dsPrcType.Tables("lpricingtype").Rows.Count - 1
                ar = dsPrcType.Tables("lpricingtype").Rows(xCount)
                If ar("PrcType_Desc") = cboPrcType.Text Then
                    convertPrcType = ar("PrcType_ID")
                    Exit For
                End If
            Next

        End Function

        Private Sub btnModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModify.Click

            grpEdits.Visible = True

            If Len(cboProduct.Text) < 1 Then
                MsgBox("Please select and entry for Product.", MsgBoxStyle.OKOnly, "Required Field")
                cboProduct.Focus()
                Exit Sub
            End If

            If Len(cboPrcType.Text) < 1 Then
                MsgBox("Please select and entry for Pricing Type.", MsgBoxStyle.OKOnly, "Required Field")
                cboPrcType.Focus()
                Exit Sub
            End If

            Dim tblProductGroup As New PSS.Data.Production.lprodgrp()
            Dim r As DataRow
            Dim valProd As Int32 = convertProduct(r)
            dtProductGroup = tblProductGroup.GetProdGrpByProdID(valProd)
            cboProductGroup.Items.Clear()
            For xCount = 0 To dtProductGroup.Rows.Count - 1
                r = dtProductGroup.Rows(xCount)
                cboProductGroup.Items.Insert(xCount, Trim(r("ProdGrp_LDesc")))
            Next

            '//Display Tier Selection if PrcType is Tiered.
            If valPricing = "TIER" Then
                showTier()
            Else
                hideTier()
            End If


            cboProductGroup.Focus()

        End Sub

        Private Sub cboProductGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProductGroup.SelectedIndexChanged

            Dim tmpCount As Integer = 0
            Dim i As Integer = 0

            recData = False

            Try

                '//Check grid and pull data if already there
                For xCount = 0 To cboPricingGroup.Items.Count - 1
                    '//This will get the first rate tier when loading
                    For i = 0 To dtGrid.Rows.Count - 1
                        If dtGrid.Rows(i).Item("Product Group") = cboProductGroup.Text Then
                            If IsDBNull(dtGrid.Rows(i).Item("Regular Pricing")) = False Then
                                txtRegular.Text = dtGrid.Rows(i).Item("Regular Pricing")
                                recData = True
                            End If
                            If IsDBNull(txtWarranty.Text = dtGrid.Rows(i).Item("Warranty Pricing")) = False Then
                                txtWarranty.Text = dtGrid.Rows(i).Item("Warranty Pricing")
                                recData = True
                            End If

                            If cboTier.Visible = True Then
                                For tmpCount = 0 To cboTier.Items.Count - 1

                                    If IsDBNull(dtGrid.Rows(i).Item("Labor Level")) = False Then

                                        If cboTier.Items(tmpCount) = dtGrid.Rows(i).Item("Labor Level") Then
                                            cboTier.SelectedIndex = tmpCount
                                            Exit For
                                        End If
                                    End If
                                Next tmpCount
                            End If

                            Exit For
                        End If
                    Next i
                Next xCount

                If recData = False Then
                    '//No data in grid - treat as insert
                    MsgBox("New Record")
                End If

            Catch exp As Exception
                MessageBox.Show(exp.ToString, "cboProductGroup_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub


        Private Sub showTier()

            lblTier.Visible = True
            cboTier.Visible = True

            cboTier.Items.Clear()
            cboTier.Text = ""

            cboTier.Items.Add("1")
            cboTier.Items.Add("2")
            cboTier.Items.Add("3")
            cboTier.Items.Add("5")
            cboTier.Items.Add("6")
            cboTier.Items.Add("8")

        End Sub

        Private Sub hideTier()

            lblTier.Visible = False
            cboTier.Visible = False

        End Sub

        Private Sub cboTier_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTier.SelectedIndexChanged

            Dim tmpCount1 As Integer = 0

            recData = False

            '//Check grid and pull data if already there
            For tmpCount1 = 0 To dtGrid.Rows.Count - 1
                If dtGrid.Rows(tmpCount1).Item("Product Group") = cboProductGroup.Text Then

                    If IsDBNull(dtGrid.Rows(tmpCount1).Item("Labor Level")) = False Then

                        If dtGrid.Rows(tmpCount1).Item("Labor Level") = cboTier.Text Then
                            'MsgBox("Tier= " & dtGrid.Rows(tmpCount1).Item("Labor Level"))
                            If IsDBNull(dtGrid.Rows(tmpCount1).Item("Regular Pricing")) = False Then
                                txtRegular.Text = dtGrid.Rows(tmpCount1).Item("Regular Pricing")
                                recData = True
                            End If
                            If IsDBNull(txtWarranty.Text = dtGrid.Rows(tmpCount1).Item("Warranty Pricing")) = False Then
                                txtWarranty.Text = dtGrid.Rows(tmpCount1).Item("Warranty Pricing")
                                recData = True
                            End If
                        End If

                    End If

                End If
            Next

            If recData = False Then
                '//Treat as new record - Insert

            End If

        End Sub

        Private Sub cboPrcType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPrcType.SelectedIndexChanged

            If Trim(cboPrcType.Text) = "Flat" Then
                valPricing = "FLAT"
            Else
                valPricing = "TIER"
            End If

        End Sub

        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

            'Validate
            If Len(Trim(txtRegular.Text)) < 1 Then Exit Sub
            '            If Len(Trim(txtWarranty.Text)) < 1 Then Exit Sub

            '//Determine pricing

            '//validate data
            If Len(txtWarranty.Text) > 0 Then
                Dim blnValidate As Boolean = validateData(txtRegular.Text, txtWarranty.Text)
                If blnValidate = False Then
                    Exit Sub
                End If
            End If

            '//Gather data together
            Dim valPrcGroup, valProdGroup, Laborlvl As Integer
            Dim r As DataRow

            For xCount = 0 To dsPricingGroup.Tables("lpricinggroup").Rows.Count - 1
                r = dsPricingGroup.Tables("lpricinggroup").Rows(xCount)
                If r("PrcGroup_LDesc") = cboPricingGroup.Text Then
                    valPrcGroup = Trim(r("PrcGroup_ID"))
                    Exit For
                End If
            Next

            For xCount = 0 To dtProductGroup.Rows.Count
                r = dtProductGroup.Rows(xCount)
                If Trim(r("ProdGrp_LDesc")) = cboProductGroup.Text Then
                    valProdGroup = Trim(r("ProdGrp_ID"))
                    Exit For
                End If
            Next

            Dim strSQL As String = ""
            Dim strLL As String = "Laborlvl_ID,"
            Dim strLLval As String = cboTier.Text & ", "
            Dim exeLabor As New PSS.Data.production.tlaborprc()
            Dim retVal As Int32

            Dim valWrty As String

            If Len(Trim(txtWarranty.Text)) < 1 Then
                valWrty = "Null"
            Else
                valWrty = txtWarranty.Text
            End If

            If recData = True Then 'Treat as update

                If cboTier.Visible = True Then
                    strLL = " AND (Laborlvl_ID = " & cboTier.Text & ") "
                Else
                    strLL = ""
                End If

                strSQL = "UPDATE tlaborprc SET " & _
                "LaborPrc_RegPrc = " & txtRegular.Text & ", " & _
                "LaborPrc_WrtyPrc = " & valWrty & _
                " WHERE ((PrcGroup_ID = " & valPrcGroup & ") " & _
                strLL & _
                " AND (ProdGrp_ID = " & valProdGroup & "))"

                retVal = exeLabor.idTransaction(strSQL)
                RefreshTDgrid()
                'clear out text fields
                txtRegular.Text = ""
                txtWarranty.Text = ""

                If cboTier.Visible = True Then
                    cboTier.Text = ""
                End If

            Else 'Treat as insert

                If cboTier.Visible = False Then
                    strLL = "LaborLvl_ID, "
                    strLLval = "0, "
                End If

                strSQL = "INSERT INTO tlaborprc (LaborPrc_RegPrc, LaborPrc_WrtyPrc, PrcGroup_ID," & strLL & "ProdGrp_ID) VALUES " & _
                "(" & txtRegular.Text & ", " & _
                valWrty & ", " & _
                valPrcGroup & ", " & _
                strLLval & _
                valProdGroup & ")"


                retVal = exeLabor.idTransaction(strSQL)
                RefreshTDgrid()
                'clear out text fields
                txtRegular.Text = ""
                txtWarranty.Text = ""
            End If
        End Sub

        Private Function validateData(ByVal valReg As Double, ByVal valWrty As Double) As Boolean

            Dim strError As String = ""
            Dim blnReg, blnWrty As Boolean

            validateData = False

            If IsNumeric(valReg) = True Then
                If valReg > 0 Then
                    If Trim(valReg * 100) = Trim(CLng(valReg * 100)) Then
                        blnReg = True
                    Else
                        strError += "Regular amount is invalid." & vbCrLf
                    End If
                End If
            End If


            If IsNumeric(valWrty) = True Then
                If valWrty > 0 Then
                    If Trim(valWrty * 100) = Trim(CLng(valWrty * 100)) Then
                        blnWrty = True
                    Else
                        strError += "Warranty amount is invalid." & vbCrLf
                    End If
                End If
            End If

            If Len(strError) > 0 Then
                MsgBox(strError, MsgBoxStyle.OKOnly, "Error")
                validateData = False
            Else
                validateData = True
            End If


        End Function

        Private Sub RefreshTDgrid()

            Dim r As DataRow
            Dim valProd As Int32 = convertProduct(r)
            If valProd < 1 Then
                '//Throw Error
                Exit Sub
            End If

            '//get the ID for Pricing Group
            For xCount = 0 To dsPricingGroup.Tables("lpricinggroup").Rows.Count - 1
                r = dsPricingGroup.Tables("lpricinggroup").Rows(xCount)
                If Trim(r("PrcGroup_LDesc")) = cboPricingGroup.Text Then
                    pricingGroupID = Trim(r("PrcGroup_ID"))
                    Exit For
                End If
            Next

            '//get data from tlaborprc
            Dim tblLaborPrc As New PSS.Data.production.Joins()
            Dim dtLaborPrc As DataTable = tblLaborPrc.GetLaborPricingByPrcGroupProdID(valProd, pricingGroupID)

            '//Populate the grid
            dtGrid.Clear() '//Empty before refilling
            For xCount = 0 To dtLaborPrc.Rows.Count - 1
                r = dtLaborPrc.Rows(xCount)
                Dim dr1 As DataRow = dtGrid.NewRow
                dr1("Product Group") = Trim(r("ProdGrp_LDesc"))
                If IsDBNull(r("LaborLvl_ID")) = False Then
                    dr1("Labor Level") = Trim(r("LaborLvl_ID"))
                End If
                If IsDBNull(r("LaborPrc_RegPrc")) = False Then
                    dr1("Regular Pricing") = Trim(r("LaborPrc_RegPrc"))
                End If
                If IsDBNull(r("LaborPrc_WrtyPrc")) = False Then
                    dr1("Warranty Pricing") = Trim(r("LaborPrc_WrtyPrc"))
                End If
                dtGrid.Rows.Add(dr1)
            Next


            tdbGrid.DataSource = dtGrid

        End Sub
















        Private Sub loadAggCodes()

            Dim ds As PSS.Data.production.Joins
            dtAggCodes = ds.OrderEntrySelect("SELECT Billcode_ID, Billcode_Desc FROM lbillcodes WHERE AggBill = 1")

            lstAggCodes.DataSource = dtAggCodes
            lstAggCodes.DisplayMember = dtAggCodes.Columns(1).ToString
            lstAggCodes.ValueMember = dtAggCodes.Columns(0).ToString

            ds = Nothing

        End Sub


        Private Sub loadDefinedAggCodes()

            txtBillCode.Text = ""
            txtAmount.Text = ""

            'Dim ds As PSS.Data.Production.Joins
            'dtDefinedAggCodes = ds.OrderEntrySelect("SELECT Billcode_Desc, tcustaggregatebilling.BillCode_ID, tcab_Amount FROM tcustaggregatebilling inner join lbillcodes on tcustaggregatebilling.billcode_id = lbillcodes.billcode_id WHERE Cust_ID = " & CustomerSelect)

            'gridAggregate.DataSource = dtDefinedAggCodes
            'ds = Nothing

        End Sub




        Private Sub lstAggCodes_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstAggCodes.MouseUp


            blnAggInsert = False

            txtBillCode.Text = ""
            txtAmount.Text = ""


            Dim xCount As Integer
            Dim r As DataRow
            For xCount = 0 To dtAggCodes.Rows.Count - 1
                r = dtAggCodes.Rows(xCount)
                If r(0) = lstAggCodes.SelectedValue Then
                    Me.txtBillCode.Text = r(1)
                    Exit For
                End If
            Next

            blnAggInsert = False

            '//Verify that the data is not already in the table - if so then use values form that
            'MsgBox(CustomerSelect)

            For xCount = 0 To Me.dtDefinedAggCodes.Rows.Count - 1
                r = dtDefinedAggCodes.Rows(xCount)
                If r("Billcode_ID") = lstAggCodes.SelectedValue Then
                    txtBillCode.Text = r("BillCode_Desc")
                    txtAmount.Text = r("tcab_Amount")

                    blnAggInsert = True

                    Exit For
                End If
            Next

        End Sub



        Private Sub btnInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsert.Click

            Dim ds As PSS.Data.production.Joins

            Dim valID As Integer = Me.lstAggCodes.SelectedValue
            Dim valAmount As Double = Me.txtAmount.Text
            'Dim valCustomer As Integer = CustomerSelect

            Dim blnInsert As Boolean


            'If blnAggInsert = False Then

            'blnInsert = ds.OrderEntryUpdateDelete("INSERT INTO tcustaggregatebilling (cust_id, billcode_id, tcab_amount) VALUES (" & valCustomer & ", " & valID & ", " & valAmount & ")")

            '//add record to grid



            'Else
            '    blnInsert = ds.OrderEntryUpdateDelete("UPDATE tcustaggregatebilling set tcab_amount = " & valAmount & " WHERE Cust_ID = " & valCustomer & " AND billcode_ID =  " & valID)
            'End If

            'blnAggInsert = False

            Me.loadDefinedAggCodes()

        End Sub





        Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click

            Dim ds As PSS.Data.production.Joins

            'Dim valID As Integer = Me.lstAggCodes.SelectedValue
            'Dim valAmount As Double = Me.txtAmount.Text
            'Dim valCustomer As Integer = CustomerSelect

            'Dim blnInsert As Boolean

            'If valID > 0 And valCustomer > 0 And valAmount <> 0 Then
            'blnInsert = ds.OrderEntryUpdateDelete("DELETE FROM tcustaggregatebilling WHERE Cust_ID = " & valCustomer & " AND billcode_ID =  " & valID)
            'End If

            'Me.loadDefinedAggCodes()

        End Sub


        Private Sub grpEdits_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grpEdits.Enter

        End Sub
    End Class
End Namespace
