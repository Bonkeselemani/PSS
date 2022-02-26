Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.OrderEntry
    Public Class mtnPricingGroup
        Inherits System.Windows.Forms.Form

        Private _objPricing As Pricing
        Private _booPopulateData As Boolean = False

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _objPricing = New Pricing()
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
        Friend WithEvents txtLDesc As System.Windows.Forms.TextBox
        Friend WithEvents txtSDesc As System.Windows.Forms.TextBox
        Friend WithEvents lblProduct As System.Windows.Forms.Label
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
        Friend WithEvents lblTier As System.Windows.Forms.Label
        Friend WithEvents cboTier As System.Windows.Forms.ComboBox
        Friend WithEvents cboPrcGrpType As System.Windows.Forms.ComboBox
        Friend WithEvents lblPrcTypeDesc As System.Windows.Forms.Label
        Friend WithEvents lblPrcGrpType As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(mtnPricingGroup))
            Me.grpPricingGroup = New System.Windows.Forms.GroupBox()
            Me.btnAddPricingGroup = New System.Windows.Forms.Button()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.lblPrcType = New System.Windows.Forms.Label()
            Me.cboPrcType = New System.Windows.Forms.ComboBox()
            Me.cboPrcGrpType = New System.Windows.Forms.ComboBox()
            Me.txtLDesc = New System.Windows.Forms.TextBox()
            Me.txtSDesc = New System.Windows.Forms.TextBox()
            Me.lblPrcGrpType = New System.Windows.Forms.Label()
            Me.lblLDesc = New System.Windows.Forms.Label()
            Me.lblSDesc = New System.Windows.Forms.Label()
            Me.cboProduct = New System.Windows.Forms.ComboBox()
            Me.lblProduct = New System.Windows.Forms.Label()
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
            Me.lblPrcTypeDesc = New System.Windows.Forms.Label()
            Me.grpPricingGroup.SuspendLayout()
            CType(Me.tdbGrid, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grpEdits.SuspendLayout()
            Me.SuspendLayout()
            '
            'grpPricingGroup
            '
            Me.grpPricingGroup.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnAddPricingGroup, Me.Label6, Me.lblPrcType, Me.cboPrcType, Me.cboPrcGrpType, Me.txtLDesc, Me.txtSDesc, Me.lblPrcGrpType, Me.lblLDesc, Me.lblSDesc})
            Me.grpPricingGroup.Location = New System.Drawing.Point(8, 80)
            Me.grpPricingGroup.Name = "grpPricingGroup"
            Me.grpPricingGroup.Size = New System.Drawing.Size(376, 160)
            Me.grpPricingGroup.TabIndex = 0
            Me.grpPricingGroup.TabStop = False
            Me.grpPricingGroup.Text = "Define Pricing"
            '
            'btnAddPricingGroup
            '
            Me.btnAddPricingGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnAddPricingGroup.Location = New System.Drawing.Point(120, 128)
            Me.btnAddPricingGroup.Name = "btnAddPricingGroup"
            Me.btnAddPricingGroup.Size = New System.Drawing.Size(96, 23)
            Me.btnAddPricingGroup.TabIndex = 6
            Me.btnAddPricingGroup.Text = "Add"
            '
            'Label6
            '
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.Location = New System.Drawing.Point(184, 24)
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
            Me.lblPrcType.Location = New System.Drawing.Point(16, 96)
            Me.lblPrcType.Name = "lblPrcType"
            Me.lblPrcType.Size = New System.Drawing.Size(100, 16)
            Me.lblPrcType.TabIndex = 0
            Me.lblPrcType.Text = "Type:"
            Me.lblPrcType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboPrcType
            '
            Me.cboPrcType.Location = New System.Drawing.Point(120, 96)
            Me.cboPrcType.Name = "cboPrcType"
            Me.cboPrcType.Size = New System.Drawing.Size(240, 21)
            Me.cboPrcType.TabIndex = 4
            '
            'cboPrcGrpType
            '
            Me.cboPrcGrpType.Location = New System.Drawing.Point(120, 72)
            Me.cboPrcGrpType.Name = "cboPrcGrpType"
            Me.cboPrcGrpType.Size = New System.Drawing.Size(240, 21)
            Me.cboPrcGrpType.TabIndex = 3
            '
            'txtLDesc
            '
            Me.txtLDesc.Location = New System.Drawing.Point(120, 48)
            Me.txtLDesc.MaxLength = 255
            Me.txtLDesc.Name = "txtLDesc"
            Me.txtLDesc.Size = New System.Drawing.Size(240, 20)
            Me.txtLDesc.TabIndex = 2
            Me.txtLDesc.Text = ""
            '
            'txtSDesc
            '
            Me.txtSDesc.Location = New System.Drawing.Point(120, 24)
            Me.txtSDesc.MaxLength = 4
            Me.txtSDesc.Name = "txtSDesc"
            Me.txtSDesc.Size = New System.Drawing.Size(56, 20)
            Me.txtSDesc.TabIndex = 1
            Me.txtSDesc.Text = ""
            '
            'lblPrcGrpType
            '
            Me.lblPrcGrpType.Location = New System.Drawing.Point(16, 72)
            Me.lblPrcGrpType.Name = "lblPrcGrpType"
            Me.lblPrcGrpType.Size = New System.Drawing.Size(100, 16)
            Me.lblPrcGrpType.TabIndex = 0
            Me.lblPrcGrpType.Text = "Group Type:"
            Me.lblPrcGrpType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblLDesc
            '
            Me.lblLDesc.Location = New System.Drawing.Point(16, 48)
            Me.lblLDesc.Name = "lblLDesc"
            Me.lblLDesc.Size = New System.Drawing.Size(100, 16)
            Me.lblLDesc.TabIndex = 0
            Me.lblLDesc.Text = "Long Description:"
            Me.lblLDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblSDesc
            '
            Me.lblSDesc.Location = New System.Drawing.Point(16, 24)
            Me.lblSDesc.Name = "lblSDesc"
            Me.lblSDesc.Size = New System.Drawing.Size(100, 16)
            Me.lblSDesc.TabIndex = 0
            Me.lblSDesc.Text = "Short Description:"
            Me.lblSDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboProduct
            '
            Me.cboProduct.Location = New System.Drawing.Point(80, 8)
            Me.cboProduct.Name = "cboProduct"
            Me.cboProduct.Size = New System.Drawing.Size(232, 21)
            Me.cboProduct.TabIndex = 5
            '
            'lblProduct
            '
            Me.lblProduct.BackColor = System.Drawing.Color.Transparent
            Me.lblProduct.ForeColor = System.Drawing.Color.Black
            Me.lblProduct.Location = New System.Drawing.Point(8, 8)
            Me.lblProduct.Name = "lblProduct"
            Me.lblProduct.Size = New System.Drawing.Size(72, 16)
            Me.lblProduct.TabIndex = 0
            Me.lblProduct.Text = "Product:"
            Me.lblProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblPrcGroup
            '
            Me.lblPrcGroup.Location = New System.Drawing.Point(0, 40)
            Me.lblPrcGroup.Name = "lblPrcGroup"
            Me.lblPrcGroup.Size = New System.Drawing.Size(80, 16)
            Me.lblPrcGroup.TabIndex = 1
            Me.lblPrcGroup.Text = "Pricing:"
            Me.lblPrcGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboPricingGroup
            '
            Me.cboPricingGroup.Location = New System.Drawing.Point(80, 40)
            Me.cboPricingGroup.Name = "cboPricingGroup"
            Me.cboPricingGroup.Size = New System.Drawing.Size(232, 21)
            Me.cboPricingGroup.TabIndex = 6
            '
            'tdbGrid
            '
            Me.tdbGrid.FilterBar = True
            Me.tdbGrid.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdbGrid.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.tdbGrid.Location = New System.Drawing.Point(8, 248)
            Me.tdbGrid.Name = "tdbGrid"
            Me.tdbGrid.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdbGrid.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdbGrid.PreviewInfo.ZoomFactor = 75
            Me.tdbGrid.Size = New System.Drawing.Size(696, 264)
            Me.tdbGrid.TabIndex = 14
            Me.tdbGrid.Text = "C1TrueDBGrid1"
            Me.tdbGrid.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Style1{}Normal{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}St" & _
            "yle12{}OddRow{}RecordSelector{AlignImage:Center;}Style13{}Heading{Wrap:True;Back" & _
            "Color:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}" & _
            "Style8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style9{}</Data></Styl" & _
            "es><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" CaptionHeight=""17"" ColumnCapti" & _
            "onHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellB" & _
            "order"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" Hori" & _
            "zontalScrollGroup=""1""><Height>260</Height><CaptionStyle parent=""Style2"" me=""Styl" & _
            "e10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow""" & _
            " me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle pa" & _
            "rent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingSt" & _
            "yle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""" & _
            "Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""Od" & _
            "dRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" />" & _
            "<SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1" & _
            """ /><ClientRect>0, 0, 692, 260</ClientRect><BorderSide>0</BorderSide><BorderStyl" & _
            "e>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Sty" & _
            "le parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""" & _
            "Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Hea" & _
            "ding"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Norm" & _
            "al"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Norm" & _
            "al"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" " & _
            "me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Cap" & _
            "tion"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSp" & _
            "lits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea" & _
            ">0, 0, 692, 260</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><Prin" & _
            "tPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'grpEdits
            '
            Me.grpEdits.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboTier, Me.lblTier, Me.cboProductGroup, Me.btnUpdate, Me.txtWarranty, Me.txtRegular, Me.lblWrty, Me.lblRegular, Me.lblProdGroup})
            Me.grpEdits.Location = New System.Drawing.Point(400, 80)
            Me.grpEdits.Name = "grpEdits"
            Me.grpEdits.Size = New System.Drawing.Size(304, 160)
            Me.grpEdits.TabIndex = 13
            Me.grpEdits.TabStop = False
            Me.grpEdits.Text = "Add/Modification Labor"
            '
            'cboTier
            '
            Me.cboTier.Location = New System.Drawing.Point(96, 48)
            Me.cboTier.Name = "cboTier"
            Me.cboTier.Size = New System.Drawing.Size(200, 21)
            Me.cboTier.TabIndex = 9
            '
            'lblTier
            '
            Me.lblTier.Location = New System.Drawing.Point(59, 48)
            Me.lblTier.Name = "lblTier"
            Me.lblTier.Size = New System.Drawing.Size(32, 16)
            Me.lblTier.TabIndex = 8
            Me.lblTier.Text = "Tier:"
            Me.lblTier.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboProductGroup
            '
            Me.cboProductGroup.Location = New System.Drawing.Point(96, 24)
            Me.cboProductGroup.Name = "cboProductGroup"
            Me.cboProductGroup.Size = New System.Drawing.Size(200, 21)
            Me.cboProductGroup.TabIndex = 8
            '
            'lblProdGroup
            '
            Me.lblProdGroup.Location = New System.Drawing.Point(4, 24)
            Me.lblProdGroup.Name = "lblProdGroup"
            Me.lblProdGroup.Size = New System.Drawing.Size(88, 16)
            Me.lblProdGroup.TabIndex = 6
            Me.lblProdGroup.Text = "Product Group:"
            Me.lblProdGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnUpdate
            '
            Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnUpdate.Location = New System.Drawing.Point(96, 128)
            Me.btnUpdate.Name = "btnUpdate"
            Me.btnUpdate.Size = New System.Drawing.Size(104, 23)
            Me.btnUpdate.TabIndex = 12
            Me.btnUpdate.Text = "Update/Insert"
            '
            'txtWarranty
            '
            Me.txtWarranty.Location = New System.Drawing.Point(96, 96)
            Me.txtWarranty.Name = "txtWarranty"
            Me.txtWarranty.Size = New System.Drawing.Size(200, 20)
            Me.txtWarranty.TabIndex = 11
            Me.txtWarranty.Text = ""
            '
            'txtRegular
            '
            Me.txtRegular.Location = New System.Drawing.Point(96, 72)
            Me.txtRegular.Name = "txtRegular"
            Me.txtRegular.Size = New System.Drawing.Size(200, 20)
            Me.txtRegular.TabIndex = 10
            Me.txtRegular.Text = ""
            '
            'lblWrty
            '
            Me.lblWrty.Location = New System.Drawing.Point(35, 96)
            Me.lblWrty.Name = "lblWrty"
            Me.lblWrty.Size = New System.Drawing.Size(56, 16)
            Me.lblWrty.TabIndex = 1
            Me.lblWrty.Text = "Warranty:"
            Me.lblWrty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblRegular
            '
            Me.lblRegular.Location = New System.Drawing.Point(35, 72)
            Me.lblRegular.Name = "lblRegular"
            Me.lblRegular.Size = New System.Drawing.Size(56, 16)
            Me.lblRegular.TabIndex = 0
            Me.lblRegular.Text = "Regular:"
            Me.lblRegular.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblPrcTypeDesc
            '
            Me.lblPrcTypeDesc.BackColor = System.Drawing.Color.SteelBlue
            Me.lblPrcTypeDesc.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPrcTypeDesc.ForeColor = System.Drawing.Color.White
            Me.lblPrcTypeDesc.Location = New System.Drawing.Point(320, 40)
            Me.lblPrcTypeDesc.Name = "lblPrcTypeDesc"
            Me.lblPrcTypeDesc.Size = New System.Drawing.Size(64, 21)
            Me.lblPrcTypeDesc.TabIndex = 46
            Me.lblPrcTypeDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mtnPricingGroup
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(712, 534)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblPrcTypeDesc, Me.grpEdits, Me.tdbGrid, Me.cboPricingGroup, Me.lblPrcGroup, Me.grpPricingGroup, Me.lblProduct, Me.cboProduct})
            Me.Name = "mtnPricingGroup"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Maintenance - Pricing Group"
            Me.grpPricingGroup.ResumeLayout(False)
            CType(Me.tdbGrid, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grpEdits.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private dtAggCodes, dtDefinedAggCodes As DataTable
        Private blnAggInsert As Boolean

        '*****************************************************************************
        Private Sub mtnPricingGroup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                PopulateProduct()
                Me.PopulatePrcGrpType()
                PopulatePrcType()
                PopulateLaborLevel()

                '//Move to the first control on page
                Me.cboProduct.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*****************************************************************************
        Private Function PopulateProduct() As Boolean
            Dim dt As DataTable

            Try
                Me._booPopulateData = True
                dt = Generic.GetProducts(True)
                Me.cboProduct.DataSource = dt.DefaultView
                Me.cboProduct.ValueMember = "Prod_ID"
                Me.cboProduct.DisplayMember = "Prod_Desc"
                Me.cboProduct.SelectedValue = 0

            Catch ex As Exception
                Throw ex
            Finally
                Me._booPopulateData = False
                Generic.DisposeDT(dt)
            End Try
        End Function

        '*****************************************************************************
        Private Function PopulatePrcGrpType() As Boolean
            Dim dt As DataTable

            Try
                Me._booPopulateData = True
                dt = Me._objPricing.GetPrcGrpType(True)
                Me.cboPrcGrpType.DataSource = dt.DefaultView
                Me.cboPrcGrpType.ValueMember = "PGType_ID"
                Me.cboPrcGrpType.DisplayMember = "PGType_Desc"
                Me.cboPrcGrpType.SelectedValue = 0
            Catch ex As Exception
                Throw ex
            Finally
                Me._booPopulateData = False
                Generic.DisposeDT(dt)
            End Try
        End Function

        '*****************************************************************************
        Private Function PopulatePrcType() As Boolean
            Dim dt As DataTable

            Try
                Me._booPopulateData = True
                'PrcType_ID, PrcType_Desc
                dt = Me._objPricing.GetPrcType(True)
                Me.cboPrcType.DataSource = dt.DefaultView
                Me.cboPrcType.ValueMember = "PrcType_ID"
                Me.cboPrcType.DisplayMember = "PrcType_Desc"
                Me.cboPrcType.SelectedValue = 0
            Catch ex As Exception
                Throw ex
            Finally
                Me._booPopulateData = False
                Generic.DisposeDT(dt)
            End Try
        End Function

        '*****************************************************************************
        Private Function PopulateLaborLevel() As Boolean
            Dim dt As DataTable

            Try
                Me._booPopulateData = True
                'LaborLvl_ID, LaborLvl_Desc, LaborLevel, Active
                dt = Me._objPricing.GetLaborLevel(True)
                Me.cboTier.DataSource = dt.DefaultView
                Me.cboTier.ValueMember = "LaborLvl_ID"
                Me.cboTier.DisplayMember = "LaborLvl_Desc"
                Me.cboTier.SelectedValue = 0
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
                Me._booPopulateData = False
            End Try
        End Function

        '*****************************************************************************
        Private Sub PopulatePricingGroup(ByVal iProdID As Integer, Optional ByVal iPrcGrpID As Integer = 0)
            Dim dt As DataTable

            Try
                _booPopulateData = True

                Me.cboPricingGroup.DataSource = Nothing
                Me.cboPricingGroup.Text = ""

                'PrcGroup_ID, PrcGroup_SDesc, PrcGroup_LDesc, PrcGroup_Type, Prod_ID, ProdGrp_ID, PrcType_ID, Cust_ID
                dt = Me._objPricing.GetPrcGrp(True, iProdID)
                Me.cboPricingGroup.DataSource = dt.DefaultView
                Me.cboPricingGroup.ValueMember = "PrcGroup_ID"
                Me.cboPricingGroup.DisplayMember = "PrcGroup_LDesc"
                If iPrcGrpID > 0 Then _booPopulateData = False
                Me.cboPricingGroup.SelectedValue = iPrcGrpID
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
                _booPopulateData = False
            End Try
        End Sub

        '*****************************************************************************
        Private Sub PopulateProductGroup(ByVal iProdID As Integer)
            Dim dt As DataTable

            Try
                _booPopulateData = True
                'ProdGrp_ID, ProdGrp_LDesc, Prod_ID
                dt = Me._objPricing.GetProdGrp(True, iProdID)
                Me.cboProductGroup.DataSource = dt.DefaultView
                Me.cboProductGroup.ValueMember = "ProdGrp_ID"
                Me.cboProductGroup.DisplayMember = "ProdGrp_LDesc"
                Me.cboProductGroup.SelectedValue = 0
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
                _booPopulateData = False
            End Try
        End Sub

        '*****************************************************************************
        Private Sub cboProduct_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProduct.SelectedIndexChanged
            Try
                If Me._booPopulateData = True Then Exit Sub

                'Reset Ctrls
                Me.cboPricingGroup.DataSource = Nothing
                Me.cboPricingGroup.Text = ""
                Me.cboProductGroup.DataSource = Nothing
                Me.cboProductGroup.Text = ""

                Me.tdbGrid.DataSource = Nothing
                Me.txtRegular.Text = ""
                Me.txtWarranty.Text = ""
                Me.cboTier.SelectedValue = 0
                Me.lblTier.Visible = False
                Me.cboTier.Visible = False

                If Me.cboProduct.SelectedValue > 0 Then
                    Me.PopulatePricingGroup(Me.cboProduct.SelectedValue)
                    Me.PopulateProductGroup(Me.cboProduct.SelectedValue)
                    Me.cboPricingGroup.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboProduct_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*****************************************************************************
        Private Sub cboPricingGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPricingGroup.SelectedIndexChanged
            Dim iProdID, iPrcGrpID, iPrcTypeID As Integer
            Dim R1 As DataRow

            Try
                If Me._booPopulateData = True Then Exit Sub

                'Reset Ctrls
                Me.tdbGrid.DataSource = Nothing
                Me.txtRegular.Text = ""
                Me.txtWarranty.Text = ""
                Me.cboTier.SelectedValue = 0
                Me.lblTier.Visible = False
                Me.cboTier.Visible = False
                Me.lblPrcTypeDesc.Text = ""

                iPrcGrpID = Me.cboPricingGroup.SelectedValue
                If iPrcGrpID = 0 Then Exit Sub

                R1 = Me.cboPricingGroup.DataSource.Table.Select("PrcGroup_ID = " & Me.cboPricingGroup.SelectedValue)(0)
                iProdID = Convert.ToInt32(R1("Prod_ID"))
                iPrcTypeID = Convert.ToInt32(R1("PrcType_ID"))

                If iPrcTypeID = 1 Then
                    Me.ShowHideTier(True)
                    Me.lblPrcTypeDesc.Text = "TIER"
                Else
                    Me.ShowHideTier(False)
                    Me.lblPrcTypeDesc.Text = "FLAT"
                End If

                Me.RefreshTDgrid(iPrcGrpID, iProdID)

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboPricingGroup_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*****************************************************************************
        Private Sub cboProductGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProductGroup.SelectedIndexChanged
            Dim dt As DataTable
            Dim iProdID As Integer
            Dim iPrcTypeID As Integer = 0 ' 1:Tier 2:Flat

            Try
                Me.txtRegular.Text = ""
                Me.txtWarranty.Text = ""
                Me.cboTier.SelectedValue = 0

                If Me._booPopulateData = True Then Exit Sub

                If Me.cboProductGroup.SelectedValue = 0 Then Exit Sub
                If Me.cboPricingGroup.SelectedValue = 0 Then
                    MessageBox.Show("Please Select Pricing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboProductGroup.SelectedValue = 0
                    Exit Sub
                Else
                    iPrcTypeID = Me.cboPricingGroup.DataSource.Table.Select("PrcGroup_ID = " & Me.cboPricingGroup.SelectedValue)(0)("PrcType_ID")
                    If iPrcTypeID = 1 Then 'Tier
                        Me.cboTier.Focus()
                    Else 'Flat
                        If Me.cboProductGroup.DataSource.Table.Select("ProdGrp_ID = " & Me.cboProductGroup.SelectedValue).Length = 0 Then
                            MessageBox.Show("Can't define product ID in product group.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            iProdID = Me.cboProductGroup.DataSource.Table.Select("ProdGrp_ID = " & Me.cboProductGroup.SelectedValue)(0)("Prod_ID")
                            dt = Me._objPricing.GetLaborPrice(Me.cboPricingGroup.SelectedValue, iProdID, Me.cboProductGroup.SelectedValue)

                            If dt.Rows.Count > 0 Then
                                If dt.Select("laborlvl_id = 0").Length > 0 Then
                                    Me.txtRegular.Text = dt.Select("laborlvl_id = 0")(0)("Reg")
                                    Me.txtWarranty.Text = dt.Select("laborlvl_id = 0")(0)("Warranty")
                                End If
                            End If
                        End If
                    End If 'Pricing type
                End If
            Catch exp As Exception
                MessageBox.Show(exp.ToString, "cboProductGroup_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*****************************************************************************
        Private Sub cboTier_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTier.SelectedIndexChanged
            Dim tmpCount1 As Integer = 0
            Dim dt As DataTable
            Dim iProdID As Integer
            Dim iPrcTypeID As Integer = 0 ' 1:Tier 2:Flat

            Try

                Me.txtRegular.Text = ""
                Me.txtWarranty.Text = ""

                If Me._booPopulateData = True Then Exit Sub
                If Me.cboTier.SelectedValue = 0 Then Exit Sub

                If Me.cboPricingGroup.SelectedValue = 0 Then
                    MessageBox.Show("Please Select Pricing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboTier.SelectedValue = 0
                ElseIf Me.cboProductGroup.SelectedValue = 0 Then
                    MessageBox.Show("Please Select Product Group.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboTier.SelectedValue = 0
                Else
                    iPrcTypeID = Me.cboPricingGroup.DataSource.Table.Select("PrcGroup_ID = " & Me.cboPricingGroup.SelectedValue)(0)("PrcType_ID")
                    If iPrcTypeID = 2 Then 'Flat
                        MessageBox.Show("This pricing defined as flat rate.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.cboTier.SelectedValue = 0
                    Else 'Flat
                        If Me.cboProductGroup.DataSource.Table.Select("ProdGrp_ID = " & Me.cboProductGroup.SelectedValue).Length = 0 Then
                            MessageBox.Show("Can't define product ID in product group.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            iProdID = Me.cboProductGroup.DataSource.Table.Select("ProdGrp_ID = " & Me.cboProductGroup.SelectedValue)(0)("Prod_ID")
                            dt = Me._objPricing.GetLaborPrice(Me.cboPricingGroup.SelectedValue, iProdID, Me.cboProductGroup.SelectedValue, Me.cboTier.SelectedValue)

                            If dt.Rows.Count > 1 Then
                                MessageBox.Show("Duplicate entry. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.txtRegular.Text = "" : Me.txtWarranty.Text = ""
                            ElseIf dt.Rows.Count = 1 Then

                                Me.txtRegular.Text = dt.Rows(0)("Reg")
                                Me.txtWarranty.Text = dt.Rows(0)("Warranty")
                            Else
                                Me.txtRegular.Text = "" : Me.txtWarranty.Text = ""
                            End If
                        End If
                    End If 'Pricing type
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboTier_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '*****************************************************************************
        Private Sub RefreshTDgrid(ByVal iPrcGrpID As Integer, ByVal iProdID As Integer)
            Dim dt As DataTable

            Try
                dt = Me._objPricing.GetLaborPrice(iPrcGrpID, iProdID)

                'LaborPrc_ID, LaborPrc_Desc, LaborPrc_RegPrc, LaborPrc_WrtyPrc
                ', PrcGroup_ID, LaborLvl_ID, ProdGrp_ID, prod_id, prodgrp_LDesc, LaborLvl_Desc
                dt.Columns("LaborPrc_Desc").ColumnName = "Description"
                dt.Columns("prodgrp_LDesc").ColumnName = "Product Group"
                dt.Columns("LaborLvl_Desc").ColumnName = "Labor Level"
                dt.Columns("Prod_Desc").ColumnName = "Product"
                dt.Columns("LastUpdateDT").ColumnName = "Date"
                dt.AcceptChanges()

                With Me.tdbGrid
                    .DataSource = dt.DefaultView
                    .Splits(0).DisplayColumns("LaborPrc_ID").Visible = False
                    .Splits(0).DisplayColumns("PrcGroup_ID").Visible = False
                    .Splits(0).DisplayColumns("LaborLvl_ID").Visible = False
                    .Splits(0).DisplayColumns("ProdGrp_ID").Visible = False
                    .Splits(0).DisplayColumns("Prod_ID").Visible = False

                    .Splits(0).DisplayColumns("Description").Width = 80
                    .Splits(0).DisplayColumns("Reg").Width = 45
                    .Splits(0).DisplayColumns("Warranty").Width = 55
                End With
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*****************************************************************************
        Private Sub btnAddPricingGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddPricingGroup.Click
            '//Convert combo box values to IDs
            Dim iPrcTypeID, iProdID, iPrcGrpTypeID As Integer
            Dim iPrcGrpID As Integer = 0
            Dim strShortDesc, strLongDesc As String

            Try
                iProdID = Me.cboProduct.SelectedValue
                iPrcGrpTypeID = Me.cboPrcGrpType.SelectedValue
                iPrcTypeID = Me.cboPrcType.SelectedValue
                strShortDesc = Me.txtSDesc.Text.Trim
                strLongDesc = Me.txtLDesc.Text.Trim
                If iProdID = 0 Then
                    MessageBox.Show("Please select product.", "Add Pricing Group", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboProduct.SelectAll() : Me.cboProduct.Focus()
                ElseIf iPrcGrpTypeID = 0 Then
                    MessageBox.Show("Please select group type.", "Add Pricing Group", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboPrcGrpType.SelectAll() : Me.cboPrcGrpType.Focus()
                ElseIf iPrcTypeID = 0 Then
                    MessageBox.Show("Please select type.", "Add Pricing Group", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboPrcType.SelectAll() : Me.cboPrcType.Focus()
                ElseIf strShortDesc.Length = 0 Then
                    MessageBox.Show("Please enter short description.", "Add Pricing Group", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtSDesc.SelectAll() : Me.txtSDesc.Focus()
                ElseIf strLongDesc.Length = 0 Then
                    MessageBox.Show("Please enter long description.", "Add Pricing Group", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtLDesc.SelectAll() : Me.txtLDesc.Focus()
                ElseIf Me._objPricing.IsPricingGroupExisted(Me.cboProduct.SelectedValue, Me.txtLDesc.Text.Trim) Then
                    MessageBox.Show("Pricing group is already existed.", "Add Pricing Group", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtLDesc.SelectAll() : Me.txtLDesc.Focus()
                ElseIf MessageBox.Show("Are you sure you want to add pricing group """ & Me.txtLDesc.Text.Trim & """?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Me.cboPrcType.SelectAll() : Me.cboPrcType.Focus()
                Else
                    Me.Cursor.Current = Cursors.WaitCursor : Me.Enabled = False

                    iPrcGrpID = Me._objPricing.AddPricingGroup(strShortDesc, strLongDesc, iPrcGrpTypeID, iProdID, iPrcTypeID, PSS.Core.ApplicationUser.IDuser)

                    If iPrcGrpID > 0 Then
                        MessageBox.Show("Save completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        '//Refresh cboPricingGroup
                        Me.Enabled = True
                        Me.txtSDesc.Text = ""
                        Me.txtLDesc.Text = ""
                        Me.cboPrcGrpType.SelectedValue = 0
                        Me.cboPrcType.SelectedValue = 0
                        PopulatePricingGroup(Me.cboProduct.SelectedValue, iPrcGrpID)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Cursor.Current = Cursors.Default : Me.Enabled = True
            End Try
        End Sub

        '*****************************************************************************
        Private Sub ShowHideTier(ByVal booVisible As Boolean)
            lblTier.Visible = booVisible
            cboTier.Visible = booVisible
        End Sub

        '*****************************************************************************
        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Dim strPrcTypeDesc As String = ""
            Dim i As Integer
            Dim iPrcGroupID, iProdGroupID, iLaborLevelID, iProdID, iPrcTypeID As Integer
            Dim dbRegLaborCharge, dbWrtyLaborCharge As Double

            Try
                '//validate data
                If Me.cboPricingGroup.SelectedValue = 0 Then
                    MessageBox.Show("Please select pricing group.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboPricingGroup.SelectAll() : Me.cboPricingGroup.Focus()
                ElseIf Me.cboProductGroup.SelectedValue = 0 Then
                    MessageBox.Show("Please select product group.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboPricingGroup.SelectAll() : Me.cboPricingGroup.Focus()
                ElseIf Me.txtRegular.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter regular price.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtRegular.SelectAll() : Me.txtRegular.Focus()
                ElseIf Me.txtWarranty.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter manufacture warranty price.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtWarranty.SelectAll() : Me.txtWarranty.Focus()
                ElseIf validateData(txtRegular.Text, txtWarranty.Text) = False Then
                    Exit Sub
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    dbRegLaborCharge = Convert.ToDouble(Me.txtRegular.Text)
                    dbWrtyLaborCharge = Convert.ToDouble(Me.txtWarranty.Text)
                    If dbRegLaborCharge < 0 OrElse dbWrtyLaborCharge < 0 Then
                        MessageBox.Show("Labor can't be negative.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If

                    iPrcGroupID = Me.cboPricingGroup.SelectedValue
                    iProdGroupID = cboProductGroup.SelectedValue
                    iProdID = Convert.ToInt32(Me.cboProductGroup.DataSource.Table.Select("ProdGrp_ID = " & Me.cboProductGroup.SelectedValue)(0)("Prod_ID"))

                    iPrcTypeID = Convert.ToInt32(Me.cboPricingGroup.DataSource.Table.Select("PrcGroup_ID = " & Me.cboPricingGroup.SelectedValue)(0)("PrcType_ID"))
                    If iPrcTypeID = 1 Then
                        iLaborLevelID = cboTier.SelectedValue
                        strPrcTypeDesc = "T-" & Me.cboPricingGroup.Text
                    Else
                        iLaborLevelID = 0
                        strPrcTypeDesc = "F-" & Me.cboPricingGroup.Text
                    End If

                    i = Me._objPricing.SetLaborPrice(strPrcTypeDesc, iPrcGroupID, iProdGroupID, iLaborLevelID, dbRegLaborCharge, dbWrtyLaborCharge, PSS.Core.ApplicationUser.IDuser)

                    If i > 0 Then
                        'Me.cboProductGroup.SelectedValue = 0
                        'Me.cboTier.SelectedValue = 0
                        Me.txtRegular.Text = ""
                        Me.txtWarranty.Text = ""
                        MessageBox.Show("Save completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        RefreshTDgrid(Me.cboPricingGroup.SelectedValue, iProdID)
                        Me.Enabled = True : Me.txtRegular.Focus()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnUpdate_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '*****************************************************************************
        Private Function validateData(ByVal valReg As Double, ByVal valWrty As Double) As Boolean

            Dim strError As String = ""
            Dim blnReg, blnWrty As Boolean

            Try
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
            Catch ex As Exception
                Throw ex
            End Try
        End Function

    End Class
End Namespace
