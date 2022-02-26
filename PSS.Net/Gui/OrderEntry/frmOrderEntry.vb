Imports CrystalDecisions.CrystalReports.Engine
Imports C1.Win.C1TrueDBGrid


Namespace Gui.OrderEntry

    Public Class frmOrderEntry
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
        Friend WithEvents lblCustomer As System.Windows.Forms.Label
        Friend WithEvents cboCustomer As System.Windows.Forms.ComboBox
        Friend WithEvents lblLocation As System.Windows.Forms.Label
        Friend WithEvents cboLocation As System.Windows.Forms.ComboBox
        Friend WithEvents txtAddress1 As System.Windows.Forms.TextBox
        Friend WithEvents txtAddress2 As System.Windows.Forms.TextBox
        Friend WithEvents txtCity As System.Windows.Forms.TextBox
        Friend WithEvents txtZip As System.Windows.Forms.TextBox
        Friend WithEvents cboState As System.Windows.Forms.ComboBox
        Friend WithEvents txtPOdescription As System.Windows.Forms.TextBox
        Friend WithEvents lblDesc As System.Windows.Forms.Label
        Friend WithEvents chkPOPlusParts As System.Windows.Forms.CheckBox
        Friend WithEvents lblQuantity As System.Windows.Forms.Label
        Friend WithEvents txtPOQuantity As System.Windows.Forms.TextBox
        Friend WithEvents cboCountry As System.Windows.Forms.ComboBox
        Friend WithEvents chkChgManufWrty As System.Windows.Forms.CheckBox
        Friend WithEvents chkChgShip As System.Windows.Forms.CheckBox
        Friend WithEvents lblDueDate As System.Windows.Forms.Label
        Friend WithEvents txtDueDate As System.Windows.Forms.TextBox
        Friend WithEvents lblMemo As System.Windows.Forms.Label
        Friend WithEvents txtMemo As System.Windows.Forms.TextBox
        Friend WithEvents lblShipBox As System.Windows.Forms.Label
        Friend WithEvents lblPObox As System.Windows.Forms.Label
        Friend WithEvents lblMainBox As System.Windows.Forms.Label
        Friend WithEvents tdbGrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents cboLaborPrc As System.Windows.Forms.ComboBox
        Friend WithEvents lblLaborPrc As System.Windows.Forms.Label
        Friend WithEvents btnSave As System.Windows.Forms.Button
        Friend WithEvents txtName As System.Windows.Forms.TextBox
        Friend WithEvents txtCustomWorkOrder As System.Windows.Forms.TextBox
        Friend WithEvents lblProduct As System.Windows.Forms.Label
        Friend WithEvents cboProduct As System.Windows.Forms.ComboBox
        Friend WithEvents lblType As System.Windows.Forms.Label
        Friend WithEvents lblPurchaseOrder As System.Windows.Forms.Label
        Friend WithEvents lblName As System.Windows.Forms.Label
        Friend WithEvents lblAddress1 As System.Windows.Forms.Label
        Friend WithEvents lblAddress2 As System.Windows.Forms.Label
        Friend WithEvents lblCityStateZip As System.Windows.Forms.Label
        Friend WithEvents lblCountry As System.Windows.Forms.Label
        Friend WithEvents lblCustomWorkOrder As System.Windows.Forms.Label
        Friend WithEvents btnDelete As System.Windows.Forms.Button
        Friend WithEvents btnUpdate As System.Windows.Forms.Button
        Friend WithEvents lbLaborDetail As System.Windows.Forms.ListBox
        Friend WithEvents lblShipMthd As System.Windows.Forms.Label
        Friend WithEvents cboShipMethod As System.Windows.Forms.ComboBox
        Friend WithEvents lblShipMethod As System.Windows.Forms.Label
        Friend WithEvents btnShipTo As System.Windows.Forms.Button
        Friend WithEvents btnAddPricingGroup As System.Windows.Forms.Button
        Friend WithEvents ckStandard As System.Windows.Forms.CheckBox
        Friend WithEvents lblRUR As System.Windows.Forms.Label
        Friend WithEvents lblNER As System.Windows.Forms.Label
        Friend WithEvents lblRTM As System.Windows.Forms.Label
        Friend WithEvents txtRUR As System.Windows.Forms.TextBox
        Friend WithEvents txtNER As System.Windows.Forms.TextBox
        Friend WithEvents txtRTM As System.Windows.Forms.TextBox
        Friend WithEvents chkAggregate As System.Windows.Forms.CheckBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmOrderEntry))
            Dim GridLines1 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
            Me.lblCustomer = New System.Windows.Forms.Label()
            Me.cboCustomer = New System.Windows.Forms.ComboBox()
            Me.lblLocation = New System.Windows.Forms.Label()
            Me.cboLocation = New System.Windows.Forms.ComboBox()
            Me.txtAddress1 = New System.Windows.Forms.TextBox()
            Me.txtAddress2 = New System.Windows.Forms.TextBox()
            Me.txtCity = New System.Windows.Forms.TextBox()
            Me.txtZip = New System.Windows.Forms.TextBox()
            Me.cboState = New System.Windows.Forms.ComboBox()
            Me.lblPurchaseOrder = New System.Windows.Forms.Label()
            Me.txtPOdescription = New System.Windows.Forms.TextBox()
            Me.lblDesc = New System.Windows.Forms.Label()
            Me.chkPOPlusParts = New System.Windows.Forms.CheckBox()
            Me.lblQuantity = New System.Windows.Forms.Label()
            Me.txtPOQuantity = New System.Windows.Forms.TextBox()
            Me.cboCountry = New System.Windows.Forms.ComboBox()
            Me.chkChgManufWrty = New System.Windows.Forms.CheckBox()
            Me.chkChgShip = New System.Windows.Forms.CheckBox()
            Me.lblDueDate = New System.Windows.Forms.Label()
            Me.txtDueDate = New System.Windows.Forms.TextBox()
            Me.lblMemo = New System.Windows.Forms.Label()
            Me.txtMemo = New System.Windows.Forms.TextBox()
            Me.lblShipBox = New System.Windows.Forms.Label()
            Me.lblPObox = New System.Windows.Forms.Label()
            Me.lblMainBox = New System.Windows.Forms.Label()
            Me.tdbGrid = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.cboLaborPrc = New System.Windows.Forms.ComboBox()
            Me.lblLaborPrc = New System.Windows.Forms.Label()
            Me.btnSave = New System.Windows.Forms.Button()
            Me.txtName = New System.Windows.Forms.TextBox()
            Me.lblName = New System.Windows.Forms.Label()
            Me.lblAddress1 = New System.Windows.Forms.Label()
            Me.lblAddress2 = New System.Windows.Forms.Label()
            Me.lblCityStateZip = New System.Windows.Forms.Label()
            Me.lblCountry = New System.Windows.Forms.Label()
            Me.lblCustomWorkOrder = New System.Windows.Forms.Label()
            Me.txtCustomWorkOrder = New System.Windows.Forms.TextBox()
            Me.lblProduct = New System.Windows.Forms.Label()
            Me.cboProduct = New System.Windows.Forms.ComboBox()
            Me.lblType = New System.Windows.Forms.Label()
            Me.btnDelete = New System.Windows.Forms.Button()
            Me.btnUpdate = New System.Windows.Forms.Button()
            Me.lbLaborDetail = New System.Windows.Forms.ListBox()
            Me.lblShipMthd = New System.Windows.Forms.Label()
            Me.cboShipMethod = New System.Windows.Forms.ComboBox()
            Me.lblShipMethod = New System.Windows.Forms.Label()
            Me.btnShipTo = New System.Windows.Forms.Button()
            Me.btnAddPricingGroup = New System.Windows.Forms.Button()
            Me.ckStandard = New System.Windows.Forms.CheckBox()
            Me.lblRUR = New System.Windows.Forms.Label()
            Me.lblNER = New System.Windows.Forms.Label()
            Me.lblRTM = New System.Windows.Forms.Label()
            Me.txtRUR = New System.Windows.Forms.TextBox()
            Me.txtNER = New System.Windows.Forms.TextBox()
            Me.txtRTM = New System.Windows.Forms.TextBox()
            Me.chkAggregate = New System.Windows.Forms.CheckBox()
            CType(Me.tdbGrid, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblCustomer
            '
            Me.lblCustomer.Location = New System.Drawing.Point(24, 24)
            Me.lblCustomer.Name = "lblCustomer"
            Me.lblCustomer.Size = New System.Drawing.Size(56, 23)
            Me.lblCustomer.TabIndex = 0
            Me.lblCustomer.Text = "Customer"
            '
            'cboCustomer
            '
            Me.cboCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboCustomer.Location = New System.Drawing.Point(80, 24)
            Me.cboCustomer.Name = "cboCustomer"
            Me.cboCustomer.Size = New System.Drawing.Size(168, 21)
            Me.cboCustomer.TabIndex = 1
            '
            'lblLocation
            '
            Me.lblLocation.Location = New System.Drawing.Point(256, 24)
            Me.lblLocation.Name = "lblLocation"
            Me.lblLocation.Size = New System.Drawing.Size(56, 23)
            Me.lblLocation.TabIndex = 2
            Me.lblLocation.Text = "Location"
            '
            'cboLocation
            '
            Me.cboLocation.Location = New System.Drawing.Point(312, 24)
            Me.cboLocation.Name = "cboLocation"
            Me.cboLocation.Size = New System.Drawing.Size(168, 21)
            Me.cboLocation.TabIndex = 2
            '
            'txtAddress1
            '
            Me.txtAddress1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtAddress1.Location = New System.Drawing.Point(200, 104)
            Me.txtAddress1.Name = "txtAddress1"
            Me.txtAddress1.Size = New System.Drawing.Size(232, 20)
            Me.txtAddress1.TabIndex = 4
            Me.txtAddress1.Text = ""
            '
            'txtAddress2
            '
            Me.txtAddress2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtAddress2.Location = New System.Drawing.Point(200, 128)
            Me.txtAddress2.Name = "txtAddress2"
            Me.txtAddress2.Size = New System.Drawing.Size(232, 20)
            Me.txtAddress2.TabIndex = 5
            Me.txtAddress2.Text = ""
            '
            'txtCity
            '
            Me.txtCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtCity.Location = New System.Drawing.Point(200, 152)
            Me.txtCity.Name = "txtCity"
            Me.txtCity.Size = New System.Drawing.Size(104, 20)
            Me.txtCity.TabIndex = 6
            Me.txtCity.Text = ""
            '
            'txtZip
            '
            Me.txtZip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtZip.Location = New System.Drawing.Point(368, 152)
            Me.txtZip.Name = "txtZip"
            Me.txtZip.Size = New System.Drawing.Size(64, 20)
            Me.txtZip.TabIndex = 8
            Me.txtZip.Text = ""
            '
            'cboState
            '
            Me.cboState.Location = New System.Drawing.Point(312, 152)
            Me.cboState.Name = "cboState"
            Me.cboState.Size = New System.Drawing.Size(48, 21)
            Me.cboState.TabIndex = 7
            '
            'lblPurchaseOrder
            '
            Me.lblPurchaseOrder.Location = New System.Drawing.Point(24, 264)
            Me.lblPurchaseOrder.Name = "lblPurchaseOrder"
            Me.lblPurchaseOrder.Size = New System.Drawing.Size(160, 16)
            Me.lblPurchaseOrder.TabIndex = 11
            Me.lblPurchaseOrder.Text = "PURCHASE ORDER"
            '
            'txtPOdescription
            '
            Me.txtPOdescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPOdescription.Location = New System.Drawing.Point(144, 288)
            Me.txtPOdescription.Name = "txtPOdescription"
            Me.txtPOdescription.Size = New System.Drawing.Size(176, 20)
            Me.txtPOdescription.TabIndex = 11
            Me.txtPOdescription.Text = ""
            '
            'lblDesc
            '
            Me.lblDesc.Location = New System.Drawing.Point(72, 288)
            Me.lblDesc.Name = "lblDesc"
            Me.lblDesc.Size = New System.Drawing.Size(64, 16)
            Me.lblDesc.TabIndex = 15
            Me.lblDesc.Text = "Description:"
            Me.lblDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkPOPlusParts
            '
            Me.chkPOPlusParts.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.chkPOPlusParts.Location = New System.Drawing.Point(256, 384)
            Me.chkPOPlusParts.Name = "chkPOPlusParts"
            Me.chkPOPlusParts.Size = New System.Drawing.Size(80, 16)
            Me.chkPOPlusParts.TabIndex = 18
            Me.chkPOPlusParts.Text = "Plus Parts"
            '
            'lblQuantity
            '
            Me.lblQuantity.Location = New System.Drawing.Point(80, 336)
            Me.lblQuantity.Name = "lblQuantity"
            Me.lblQuantity.Size = New System.Drawing.Size(56, 16)
            Me.lblQuantity.TabIndex = 17
            Me.lblQuantity.Text = "Quantity:"
            Me.lblQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtPOQuantity
            '
            Me.txtPOQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPOQuantity.Location = New System.Drawing.Point(144, 336)
            Me.txtPOQuantity.Name = "txtPOQuantity"
            Me.txtPOQuantity.Size = New System.Drawing.Size(96, 20)
            Me.txtPOQuantity.TabIndex = 13
            Me.txtPOQuantity.Text = ""
            '
            'cboCountry
            '
            Me.cboCountry.Location = New System.Drawing.Point(200, 176)
            Me.cboCountry.Name = "cboCountry"
            Me.cboCountry.Size = New System.Drawing.Size(232, 21)
            Me.cboCountry.TabIndex = 9
            '
            'chkChgManufWrty
            '
            Me.chkChgManufWrty.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.chkChgManufWrty.Location = New System.Drawing.Point(256, 344)
            Me.chkChgManufWrty.Name = "chkChgManufWrty"
            Me.chkChgManufWrty.Size = New System.Drawing.Size(176, 16)
            Me.chkChgManufWrty.TabIndex = 16
            Me.chkChgManufWrty.Text = "Charge Manufacturer Warranty"
            '
            'chkChgShip
            '
            Me.chkChgShip.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.chkChgShip.Location = New System.Drawing.Point(256, 360)
            Me.chkChgShip.Name = "chkChgShip"
            Me.chkChgShip.Size = New System.Drawing.Size(136, 24)
            Me.chkChgShip.TabIndex = 17
            Me.chkChgShip.Text = "Change Ship Method"
            '
            'lblDueDate
            '
            Me.lblDueDate.Location = New System.Drawing.Point(80, 360)
            Me.lblDueDate.Name = "lblDueDate"
            Me.lblDueDate.Size = New System.Drawing.Size(56, 23)
            Me.lblDueDate.TabIndex = 22
            Me.lblDueDate.Text = "Due Date:"
            Me.lblDueDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDueDate
            '
            Me.txtDueDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDueDate.Location = New System.Drawing.Point(144, 360)
            Me.txtDueDate.Name = "txtDueDate"
            Me.txtDueDate.Size = New System.Drawing.Size(96, 20)
            Me.txtDueDate.TabIndex = 14
            Me.txtDueDate.Text = ""
            '
            'lblMemo
            '
            Me.lblMemo.Location = New System.Drawing.Point(48, 424)
            Me.lblMemo.Name = "lblMemo"
            Me.lblMemo.Size = New System.Drawing.Size(40, 23)
            Me.lblMemo.TabIndex = 25
            Me.lblMemo.Text = "Memo:"
            Me.lblMemo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtMemo
            '
            Me.txtMemo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtMemo.Location = New System.Drawing.Point(96, 424)
            Me.txtMemo.Multiline = True
            Me.txtMemo.Name = "txtMemo"
            Me.txtMemo.Size = New System.Drawing.Size(328, 56)
            Me.txtMemo.TabIndex = 19
            Me.txtMemo.Text = ""
            '
            'lblShipBox
            '
            Me.lblShipBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblShipBox.Location = New System.Drawing.Point(16, 72)
            Me.lblShipBox.Name = "lblShipBox"
            Me.lblShipBox.Size = New System.Drawing.Size(424, 136)
            Me.lblShipBox.TabIndex = 27
            '
            'lblPObox
            '
            Me.lblPObox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblPObox.Location = New System.Drawing.Point(16, 256)
            Me.lblPObox.Name = "lblPObox"
            Me.lblPObox.Size = New System.Drawing.Size(424, 232)
            Me.lblPObox.TabIndex = 28
            '
            'lblMainBox
            '
            Me.lblMainBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblMainBox.Location = New System.Drawing.Point(16, 16)
            Me.lblMainBox.Name = "lblMainBox"
            Me.lblMainBox.Size = New System.Drawing.Size(720, 40)
            Me.lblMainBox.TabIndex = 33
            '
            'tdbGrid
            '
            Me.tdbGrid.AllowFilter = True
            Me.tdbGrid.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
            Me.tdbGrid.AllowSort = True
            Me.tdbGrid.AlternatingRows = True
            Me.tdbGrid.Caption = "Select Labor Pricing"
            Me.tdbGrid.CaptionHeight = 17
            Me.tdbGrid.CollapseColor = System.Drawing.Color.Black
            Me.tdbGrid.DataChanged = False
            Me.tdbGrid.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
            Me.tdbGrid.BackColor = System.Drawing.Color.Empty
            Me.tdbGrid.ExpandColor = System.Drawing.Color.Black
            Me.tdbGrid.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Flat
            Me.tdbGrid.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdbGrid.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.tdbGrid.Location = New System.Drawing.Point(448, 120)
            Me.tdbGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
            Me.tdbGrid.Name = "tdbGrid"
            Me.tdbGrid.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdbGrid.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdbGrid.PreviewInfo.ZoomFactor = 75
            Me.tdbGrid.PrintInfo.ShowOptionsDialog = False
            Me.tdbGrid.RecordSelectorWidth = 16
            GridLines1.Color = System.Drawing.Color.DarkGray
            GridLines1.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single
            Me.tdbGrid.RowDivider = GridLines1
            Me.tdbGrid.RowHeight = 15
            Me.tdbGrid.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.tdbGrid.ScrollTips = False
            Me.tdbGrid.Size = New System.Drawing.Size(256, 8)
            Me.tdbGrid.TabIndex = 34
            Me.tdbGrid.Text = "C1TrueDBGrid1"
            Me.tdbGrid.ViewColumnWidth = 10
            Me.tdbGrid.Visible = False
            Me.tdbGrid.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style13{}EvenRow{BackColor:Aqua;}Selected{ForeColor:HighlightText;BackCol" & _
            "or:Highlight;}Heading{Wrap:True;AlignVert:Center;Border:Flat,ControlDark,0, 1, 0" & _
            ", 1;ForeColor:ControlText;BackColor:Control;}Inactive{ForeColor:InactiveCaptionT" & _
            "ext;BackColor:InactiveCaption;}FilterBar{}OddRow{BackColor:ActiveCaptionText;}Fo" & _
            "oter{}Caption{AlignHorz:Center;BackColor:Desktop;}Style25{}Normal{}Style26{}High" & _
            "lightRow{ForeColor:HighlightText;BackColor:Highlight;}Style24{}Style23{AlignHorz" & _
            ":Near;}Style22{}Style21{}Style20{}RecordSelector{AlignImage:Center;}Style18{}Sty" & _
            "le19{}Style14{}Style15{}Style16{}Style17{}</Data></Styles><Splits><C1.Win.C1True" & _
            "DBGrid.GroupByView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnC" & _
            "aptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" Record" & _
            "SelectorWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect" & _
            ">0, 17, 252, -13</ClientRect><DefRecSelWidth>16</DefRecSelWidth><CaptionStyle pa" & _
            "rent=""Heading"" me=""Style23"" /><EditorStyle parent=""Editor"" me=""Style15"" /><EvenR" & _
            "owStyle parent=""EvenRow"" me=""Style21"" /><FilterBarStyle parent=""FilterBar"" me=""S" & _
            "tyle26"" /><FooterStyle parent=""Footer"" me=""Style17"" /><GroupStyle parent=""Group""" & _
            " me=""Style25"" /><HeadingStyle parent=""Heading"" me=""Style16"" /><HighLightRowStyle" & _
            " parent=""HighlightRow"" me=""Style20"" /><InactiveStyle parent=""Inactive"" me=""Style" & _
            "19"" /><OddRowStyle parent=""OddRow"" me=""Style22"" /><RecordSelectorStyle parent=""R" & _
            "ecordSelector"" me=""Style24"" /><SelectedStyle parent=""Selected"" me=""Style18"" /><S" & _
            "tyle parent=""Normal"" me=""Style14"" /></C1.Win.C1TrueDBGrid.GroupByView></Splits><" & _
            "NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /" & _
            "><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><S" & _
            "tyle parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><St" & _
            "yle parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><St" & _
            "yle parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style p" & _
            "arent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><S" & _
            "tyle parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horz" & _
            "Splits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>16</DefaultRecSelW" & _
            "idth><ClientArea>0, 0, 252, 4</ClientArea></Blob>"
            '
            'cboLaborPrc
            '
            Me.cboLaborPrc.Location = New System.Drawing.Point(448, 96)
            Me.cboLaborPrc.Name = "cboLaborPrc"
            Me.cboLaborPrc.Size = New System.Drawing.Size(256, 21)
            Me.cboLaborPrc.TabIndex = 20
            '
            'lblLaborPrc
            '
            Me.lblLaborPrc.Location = New System.Drawing.Point(456, 72)
            Me.lblLaborPrc.Name = "lblLaborPrc"
            Me.lblLaborPrc.Size = New System.Drawing.Size(152, 16)
            Me.lblLaborPrc.TabIndex = 36
            Me.lblLaborPrc.Text = "Select Labor Pricing Schema"
            '
            'btnSave
            '
            Me.btnSave.Location = New System.Drawing.Point(448, 448)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(80, 40)
            Me.btnSave.TabIndex = 21
            Me.btnSave.Text = "Save Order Entry"
            '
            'txtName
            '
            Me.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtName.Location = New System.Drawing.Point(200, 80)
            Me.txtName.Name = "txtName"
            Me.txtName.Size = New System.Drawing.Size(232, 20)
            Me.txtName.TabIndex = 3
            Me.txtName.Text = ""
            '
            'lblName
            '
            Me.lblName.Location = New System.Drawing.Point(136, 80)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(56, 16)
            Me.lblName.TabIndex = 41
            Me.lblName.Text = "Name:"
            Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblAddress1
            '
            Me.lblAddress1.Location = New System.Drawing.Point(80, 104)
            Me.lblAddress1.Name = "lblAddress1"
            Me.lblAddress1.Size = New System.Drawing.Size(112, 16)
            Me.lblAddress1.TabIndex = 42
            Me.lblAddress1.Text = "Address:"
            Me.lblAddress1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblAddress2
            '
            Me.lblAddress2.Location = New System.Drawing.Point(80, 128)
            Me.lblAddress2.Name = "lblAddress2"
            Me.lblAddress2.Size = New System.Drawing.Size(112, 16)
            Me.lblAddress2.TabIndex = 43
            Me.lblAddress2.Text = "Address(2):"
            Me.lblAddress2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCityStateZip
            '
            Me.lblCityStateZip.Location = New System.Drawing.Point(80, 152)
            Me.lblCityStateZip.Name = "lblCityStateZip"
            Me.lblCityStateZip.Size = New System.Drawing.Size(112, 16)
            Me.lblCityStateZip.TabIndex = 44
            Me.lblCityStateZip.Text = "City, State, and Zip:"
            Me.lblCityStateZip.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCountry
            '
            Me.lblCountry.Location = New System.Drawing.Point(80, 176)
            Me.lblCountry.Name = "lblCountry"
            Me.lblCountry.Size = New System.Drawing.Size(112, 16)
            Me.lblCountry.TabIndex = 45
            Me.lblCountry.Text = "Country:"
            Me.lblCountry.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCustomWorkOrder
            '
            Me.lblCustomWorkOrder.Location = New System.Drawing.Point(24, 384)
            Me.lblCustomWorkOrder.Name = "lblCustomWorkOrder"
            Me.lblCustomWorkOrder.Size = New System.Drawing.Size(120, 23)
            Me.lblCustomWorkOrder.TabIndex = 46
            Me.lblCustomWorkOrder.Text = "Custom WorkOrder:"
            Me.lblCustomWorkOrder.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCustomWorkOrder
            '
            Me.txtCustomWorkOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtCustomWorkOrder.Location = New System.Drawing.Point(144, 384)
            Me.txtCustomWorkOrder.Name = "txtCustomWorkOrder"
            Me.txtCustomWorkOrder.Size = New System.Drawing.Size(96, 20)
            Me.txtCustomWorkOrder.TabIndex = 15
            Me.txtCustomWorkOrder.Text = ""
            '
            'lblProduct
            '
            Me.lblProduct.Location = New System.Drawing.Point(80, 312)
            Me.lblProduct.Name = "lblProduct"
            Me.lblProduct.Size = New System.Drawing.Size(56, 16)
            Me.lblProduct.TabIndex = 48
            Me.lblProduct.Text = "Product:"
            Me.lblProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboProduct
            '
            Me.cboProduct.Location = New System.Drawing.Point(144, 312)
            Me.cboProduct.Name = "cboProduct"
            Me.cboProduct.Size = New System.Drawing.Size(176, 21)
            Me.cboProduct.TabIndex = 12
            '
            'lblType
            '
            Me.lblType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblType.Location = New System.Drawing.Point(512, 24)
            Me.lblType.Name = "lblType"
            Me.lblType.Size = New System.Drawing.Size(208, 23)
            Me.lblType.TabIndex = 49
            '
            'btnDelete
            '
            Me.btnDelete.Location = New System.Drawing.Point(536, 448)
            Me.btnDelete.Name = "btnDelete"
            Me.btnDelete.Size = New System.Drawing.Size(80, 40)
            Me.btnDelete.TabIndex = 50
            Me.btnDelete.Text = "Delete Order Entry"
            '
            'btnUpdate
            '
            Me.btnUpdate.Location = New System.Drawing.Point(624, 448)
            Me.btnUpdate.Name = "btnUpdate"
            Me.btnUpdate.Size = New System.Drawing.Size(80, 40)
            Me.btnUpdate.TabIndex = 51
            Me.btnUpdate.Text = "Update Order Entry"
            '
            'lbLaborDetail
            '
            Me.lbLaborDetail.Location = New System.Drawing.Point(448, 152)
            Me.lbLaborDetail.Name = "lbLaborDetail"
            Me.lbLaborDetail.Size = New System.Drawing.Size(256, 212)
            Me.lbLaborDetail.TabIndex = 52
            '
            'lblShipMthd
            '
            Me.lblShipMthd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblShipMthd.Location = New System.Drawing.Point(16, 216)
            Me.lblShipMthd.Name = "lblShipMthd"
            Me.lblShipMthd.Size = New System.Drawing.Size(424, 32)
            Me.lblShipMthd.TabIndex = 53
            '
            'cboShipMethod
            '
            Me.cboShipMethod.Location = New System.Drawing.Point(200, 224)
            Me.cboShipMethod.Name = "cboShipMethod"
            Me.cboShipMethod.Size = New System.Drawing.Size(152, 21)
            Me.cboShipMethod.TabIndex = 10
            '
            'lblShipMethod
            '
            Me.lblShipMethod.Location = New System.Drawing.Point(80, 224)
            Me.lblShipMethod.Name = "lblShipMethod"
            Me.lblShipMethod.Size = New System.Drawing.Size(112, 16)
            Me.lblShipMethod.TabIndex = 55
            Me.lblShipMethod.Text = "Ship Method:"
            Me.lblShipMethod.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnShipTo
            '
            Me.btnShipTo.Location = New System.Drawing.Point(24, 80)
            Me.btnShipTo.Name = "btnShipTo"
            Me.btnShipTo.Size = New System.Drawing.Size(120, 23)
            Me.btnShipTo.TabIndex = 56
            Me.btnShipTo.Text = "SHIP TO ADDRESS"
            '
            'btnAddPricingGroup
            '
            Me.btnAddPricingGroup.Location = New System.Drawing.Point(448, 128)
            Me.btnAddPricingGroup.Name = "btnAddPricingGroup"
            Me.btnAddPricingGroup.Size = New System.Drawing.Size(256, 24)
            Me.btnAddPricingGroup.TabIndex = 57
            Me.btnAddPricingGroup.Text = "Add Pricing"
            '
            'ckStandard
            '
            Me.ckStandard.Location = New System.Drawing.Point(632, 72)
            Me.ckStandard.Name = "ckStandard"
            Me.ckStandard.Size = New System.Drawing.Size(72, 24)
            Me.ckStandard.TabIndex = 58
            Me.ckStandard.Text = "Standard"
            '
            'lblRUR
            '
            Me.lblRUR.Location = New System.Drawing.Point(600, 372)
            Me.lblRUR.Name = "lblRUR"
            Me.lblRUR.Size = New System.Drawing.Size(32, 16)
            Me.lblRUR.TabIndex = 59
            Me.lblRUR.Text = "RUR:"
            '
            'lblNER
            '
            Me.lblNER.Location = New System.Drawing.Point(600, 396)
            Me.lblNER.Name = "lblNER"
            Me.lblNER.Size = New System.Drawing.Size(32, 16)
            Me.lblNER.TabIndex = 60
            Me.lblNER.Text = "NER:"
            '
            'lblRTM
            '
            Me.lblRTM.Location = New System.Drawing.Point(600, 420)
            Me.lblRTM.Name = "lblRTM"
            Me.lblRTM.Size = New System.Drawing.Size(32, 16)
            Me.lblRTM.TabIndex = 61
            Me.lblRTM.Text = "RTM:"
            '
            'txtRUR
            '
            Me.txtRUR.Location = New System.Drawing.Point(640, 368)
            Me.txtRUR.Name = "txtRUR"
            Me.txtRUR.Size = New System.Drawing.Size(64, 20)
            Me.txtRUR.TabIndex = 62
            Me.txtRUR.Text = ""
            '
            'txtNER
            '
            Me.txtNER.Location = New System.Drawing.Point(640, 392)
            Me.txtNER.Name = "txtNER"
            Me.txtNER.Size = New System.Drawing.Size(64, 20)
            Me.txtNER.TabIndex = 63
            Me.txtNER.Text = ""
            '
            'txtRTM
            '
            Me.txtRTM.Location = New System.Drawing.Point(640, 416)
            Me.txtRTM.Name = "txtRTM"
            Me.txtRTM.Size = New System.Drawing.Size(64, 20)
            Me.txtRTM.TabIndex = 64
            Me.txtRTM.Text = ""
            '
            'chkAggregate
            '
            Me.chkAggregate.Location = New System.Drawing.Point(448, 368)
            Me.chkAggregate.Name = "chkAggregate"
            Me.chkAggregate.TabIndex = 65
            Me.chkAggregate.Text = "Aggreate Billing"
            '
            'frmOrderEntry
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(736, 497)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkAggregate, Me.txtRTM, Me.txtNER, Me.txtRUR, Me.lblRTM, Me.lblNER, Me.lblRUR, Me.ckStandard, Me.btnAddPricingGroup, Me.btnShipTo, Me.cboShipMethod, Me.lblShipMethod, Me.lblShipMthd, Me.lbLaborDetail, Me.btnUpdate, Me.btnDelete, Me.lblType, Me.cboProduct, Me.lblProduct, Me.txtCustomWorkOrder, Me.lblCustomWorkOrder, Me.lblCountry, Me.lblCityStateZip, Me.lblAddress2, Me.lblAddress1, Me.lblName, Me.txtName, Me.btnSave, Me.lblLaborPrc, Me.cboLaborPrc, Me.tdbGrid, Me.txtMemo, Me.lblMemo, Me.txtDueDate, Me.lblDueDate, Me.chkChgShip, Me.chkChgManufWrty, Me.cboCountry, Me.txtPOQuantity, Me.lblQuantity, Me.chkPOPlusParts, Me.lblDesc, Me.txtPOdescription, Me.lblPurchaseOrder, Me.cboState, Me.txtZip, Me.txtCity, Me.txtAddress2, Me.txtAddress1, Me.cboLocation, Me.lblLocation, Me.cboCustomer, Me.lblCustomer, Me.lblShipBox, Me.lblPObox, Me.lblMainBox})
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Name = "frmOrderEntry"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Order Entry"
            CType(Me.tdbGrid, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private xCount As Integer
        Private CustomerID(5000) As Integer
        Private LocationID(5000) As Integer
        Private StateID(100) As Integer
        Private CountryID(500) As Integer
        Private LaborPrcID(500, 1) As String
        Private ShipMethodID(500) As Integer
        Private ProductID(500) As Integer
        Private returnColor As String
        Private valChgManufWrty As Integer
        Private valChgShip As Integer
        Private valPOPlusParts As Integer
        Private ActionType As String

        Private editValPOID As Integer
        Private editValShipToID As Integer
        Private editValWorkOrder As Integer

        Private updValPOID As Integer
        Private updValCustID As Integer
        Private updValWOID As Integer
        Private updProdID As Integer
        Private updShipToID As Integer
        Private dtStandard As DataSet
        Private dtCustomer As DataSet
        Private dtDeviceType As DataSet

        Private editLocID As Integer = 0


        Sub LoadUpdate(ByVal valCustID As Integer, ByVal valLocID As Integer, ByVal valPO As String)

            Dim Verify As Boolean

            editLocID = valLocID

            EnableAllInputControls()

            PopulateCustomerList()

            For xCount = 0 To cboCustomer.Items.Count - 1
                If CustomerID(xCount) = valCustID Then
                    cboCustomer.SelectedIndex = xCount
                End If
            Next

            PopulateLaborPrc()
            PopulateShipMethodList()
            PopulateProductList()
            PopulateLocationList()

            For xCount = 0 To cboLocation.Items.Count - 1
                If LocationID(xCount) = valLocID Then
                    cboLocation.SelectedIndex = xCount
                    '                getShipToAddress()
                End If
            Next

            ClearFieldsCustomer()

            HideAllControls()

            populateStandardDataSet()

            Dim poNumber As Integer

            'Get PO Number
            poNumber = CInt(valPO)
            Verify = VerifyRecord(poNumber)
            If Verify = True Then

                GetPageData(poNumber)

                'This is a new record - stay as is
                ShowAllControls()
                btnSave.Visible = False
                btnDelete.Visible = False
                btnShipTo.Enabled = False

                btnUpdate.Top = 448
                btnUpdate.Left = 448
                btnUpdate.Height = 40
                btnUpdate.Width = 288

                ActionType = "Update"
                lblType.Text = "UPDATE RECORD:" & valPO
                cboCustomer.Select()
            Else
                MsgBox("Record could not be located.", MsgBoxStyle.OKOnly, "Missing")
                HideAllControls()
            End If

        End Sub

        Sub LoadDelete(ByVal valPO As String)

            DisableAllInputControls()

            Dim Verify As Boolean

            PopulateCustomerList()
            PopulateShipMethodList()
            PopulateProductList()

            ClearFieldsCustomer()

            cboLocation.Text = ""
            cboCustomer.Text = ""
            cboCustomer.SelectedIndex = 0

            cboProduct.Text = ""
            HideAllControls()

            Dim poNumber As Integer

            'Get PO Number
            poNumber = CInt(valPO)
            Verify = VerifyRecord(poNumber)
            If Verify = True Then

                GetPageData(poNumber)

                ShowAllControls()

                txtName.Enabled = False
                txtAddress1.Enabled = False
                txtAddress2.Enabled = False
                txtCity.Enabled = False
                cboState.Enabled = False
                txtZip.Enabled = False
                cboCountry.Enabled = False

                btnSave.Visible = False
                btnUpdate.Visible = False

                btnDelete.Top = 448
                btnDelete.Left = 448
                btnDelete.Height = 40
                btnDelete.Width = 288

                ActionType = "Delete"
                lblType.Text = "DELETE RECORD:" & valPO
                cboCustomer.Select()
            Else
                MsgBox("Record could not be located.", MsgBoxStyle.OKOnly, "Missing")
                HideAllControls()
            End If

        End Sub

        Sub LoadNew(ByVal valCust As Integer, ByVal valLoc As Integer)

            PopulateCustomerList()
            PopulateShipMethodList()
            PopulateProductList()
            PopulateStateList()
            PopulateCountryList()
            HideAllControls()

            For xCount = 0 To cboCustomer.Items.Count - 1
                If CustomerID(xCount) = valCust Then
                    cboCustomer.SelectedIndex = xCount
                End If
            Next

            PopulateLocationList()
            PopulateLaborPrc()

            For xCount = 0 To cboLocation.Items.Count - 1
                If LocationID(xCount) = valLoc Then
                    cboLocation.SelectedIndex = xCount
                    getShipToAddress()
                End If
            Next

            cboProduct.Text = ""

            ShowAllControls()
            EnableAllInputControls()
            DisableShipTo()

            btnDelete.Visible = False
            btnUpdate.Visible = False
            btnSave.Top = 448
            btnSave.Left = 448
            btnSave.Height = 40
            btnSave.Width = 288

            ActionType = "New"
            lblType.Text = "NEW RECORD"
            cboCustomer.Select()

        End Sub

        Private Sub GetPageData(ByVal inpval As Integer)

            ActionType = "Delete"

            Dim sqlRead As String
            Dim valPO As String
            Dim poID As String
            Dim CustID As String
            Dim prodID As String
            Dim ShipToID As String
            Dim ShipMethodID As String
            Dim LocID As String
            Dim LaborPrc_ID As String
            Dim xCount As Integer

            PopulateStateList()
            PopulateCountryList()
            PopulateShipMethodList()
            PopulateProductList()

            Dim dtWO As DataTable
            Dim drWO As DataRow
            Dim dtShipTo As DataTable
            Dim drShipTo As DataRow
            Dim dtPO As DataTable
            Dim drPO As DataRow
            Dim dtShipMthd As DataTable
            Dim drShipMthd As DataRow
            Dim dtCustomer As DataTable
            Dim drCustomer As DataRow
            Dim dtLocation As DataTable
            Dim drLocation As DataRow
            Dim dtProduct As DataTable
            Dim drProduct As DataRow
            Dim dtShipMthd2 As DataTable
            Dim drShipMthd2 As DataRow
            Dim drLaborPrc As DataRow
            Dim dtLaborPrc As DataTable

            Try

                drWO = PSS.Data.Production.tworkorder.GetRowByPO(CInt(inpval))
                '            dtWO = PSS.Data.Production.Joins.OrderEntrySelect("Select * from tworkorder where PO_ID = " & inpval)
                editValPOID = inpval

                If IsDBNull(drWO("PO_ID")) = False Then poID = drWO("PO_ID")
                If IsDBNull(drWO("PO_ID")) = False Then updValPOID = drWO("PO_ID")
                If IsDBNull(drWO("Prod_ID")) = False Then prodID = drWO("Prod_ID")
                If IsDBNull(drWO("Prod_ID")) = False Then updProdID = drWO("Prod_ID")
                If IsDBNull(drWO("ShipTo_ID")) = False Then ShipToID = drWO("ShipTo_ID")
                If IsDBNull(drWO("ShipTo_ID")) = False Then updShipToID = drWO("ShipTo_ID")
                If IsDBNull(drWO("Loc_ID")) = False Then LocID = drWO("Loc_ID")
                If IsDBNull(drWO("WO_CustWO")) = False Then txtCustomWorkOrder.Text = drWO("WO_CustWO")
                If IsDBNull(drWO("WO_ID")) = False Then editValWorkOrder = CInt(drWO("WO_ID"))
                updValWOID = editValWorkOrder


            Catch exp As Exception
                MsgBox(exp.ToString)
            Finally
                drWO = Nothing
            End Try

            Try
                'dtShipTo = PSS.Data.Production.Joins.OrderEntrySelect("Select * from tshipto where ShipTo_ID = " & CInt(ShipToID))

                txtName.Enabled = False '//This value is to disable controls if no shipping address is defined

                If ShipToID <> "0" Then
                    drShipTo = PSS.Data.Buisness.Generic.GetShipToData(CInt(ShipToID))
                    editValShipToID = CInt(ShipToID)

                    EnableShipTo()

                    If txtName.Enabled = True Then
                        If IsDBNull(drShipTo("ShipTo_Name")) = False Then txtName.Text = drShipTo("ShipTo_Name")
                        If IsDBNull(drShipTo("ShipTo_Address1")) = False Then txtAddress1.Text = drShipTo("ShipTo_Address1")
                        If IsDBNull(drShipTo("ShipTo_Address2")) = False Then txtAddress2.Text = drShipTo("ShipTo_Address2")
                        If IsDBNull(drShipTo("ShipTo_City")) = False Then txtCity.Text = drShipTo("ShipTo_City")
                        If IsDBNull(drShipTo("ShipTo_Zip")) = False Then txtZip.Text = drShipTo("ShipTo_Zip")
                        cboState.SelectedIndex = drShipTo("State_ID") - 1
                        cboCountry.SelectedIndex = drShipTo("Cntry_ID") - 1
                    End If
                End If

            Catch exp As Exception
                '                MsgBox(exp.ToString)
            Finally
                drShipTo = Nothing
            End Try

            Try
                '            dtPO = PSS.Data.Production.Joins.OrderEntrySelect("Select * from tpurchaseorder where PO_ID = " & CInt(poID))
                drPO = PSS.Data.Production.tpurchaseorder.GetRowByPK(CInt(poID))

                If IsDBNull(drPO("PO_Desc")) = False Then txtPOdescription.Text = drPO("PO_Desc")
                If drPO("PO_chgManufWrty") = 0 Then
                    chkChgManufWrty.Checked = False
                Else
                    chkChgManufWrty.Checked = True
                End If

                If drPO("PO_PlusParts") = 0 Then
                    chkPOPlusParts.Checked = False
                Else
                    chkPOPlusParts.Checked = True
                End If

                If drPO("PO_ChrgShip") = 0 Then
                    chkChgShip.Checked = False
                Else
                    chkChgShip.Checked = True
                End If

                If drPO("PO_Aggregate") = 1 Then
                    chkAggregate.Checked = True
                Else
                    chkAggregate.Checked = False
                End If

                If IsDBNull(drPO("PO_Quanity")) = False Then txtPOQuantity.Text = drPO("PO_Quanity")
                'If IsDBNull(drPO("Cust_ID")) = False Then CustID = drPO("Cust_ID")
                'If IsDBNull(drPO("Cust_ID")) = False Then updValCustID = drPO("Cust_ID")
                If IsDBNull(drPO("PO_DueDate")) = False Then txtDueDate.Text = Format(drPO("PO_DueDate"), "d")
                If IsDBNull(drPO("PrcGroup_ID")) = False Then LaborPrc_ID = drPO("PrcGroup_ID")
                If IsDBNull(drPO("PO_Memo")) = False Then txtMemo.Text = drPO("PO_Memo")
                If IsDBNull(drPO("ShipMthd_ID")) = False Then ShipMethodID = drPO("ShipMthd_ID")

                '//Craig Haney January 13, 2006
                If IsDBNull(drPO("PO_RUR")) = False Then txtRUR.Text = drPO("PO_RUR")
                If IsDBNull(drPO("PO_NER")) = False Then txtNER.Text = drPO("PO_NER")
                If IsDBNull(drPO("PO_RTM")) = False Then txtRTM.Text = drPO("PO_RTM")
                '//Craig Haney January 13, 2006

                LocID = drPO("Loc_ID")

            Catch exp As Exception
                MsgBox(exp.ToString)
            Finally
                dtPO = Nothing
            End Try

            Try
                '            dtShipMthd = PSS.Data.Production.Joins.OrderEntrySelect("Select * from lshipmethod where ShipMthd_ID = " & CInt(ShipMethodID))

                '//This will be used in the future
                '                drShipMthd = PSS.Data.Production.lshipmethod.GetRowByPK(CInt(ShipMethodID))

                '               If IsDBNull(drShipMthd("Ship_desc")) = False Then
                '                  For xCount = 0 To cboShipMethod.Items.Count - 1
                '                     If cboShipMethod.Items(xCount) = drShipMthd("Ship_desc") Then
                '                        cboShipMethod.SelectedIndex = xCount
                '                   End If
                '              Next
                '         End If

            Catch exp As Exception
                MsgBox(exp.ToString)
            Finally
                dtShipMthd = Nothing
            End Try

            Try

                Dim drLoc As DataRow = PSS.Data.Production.tlocation.GetRowByPK(LocID)
                CustID = drLoc("Cust_ID")

                'dtCustomer = PSS.Data.Production.Joins.OrderEntrySelect("Select * from tcustomer where Cust_ID = " & CInt(CustID))
                drCustomer = PSS.Data.Production.tcustomer.GetRowByPK(CInt(CustID))

                If IsDBNull(drCustomer("cust_name1")) = False Then
                    For xCount = 0 To cboCustomer.Items.Count - 1
                        If cboCustomer.Items(xCount) = drCustomer("cust_name1") Then
                            cboCustomer.SelectedIndex = xCount
                        End If
                    Next
                End If
                '            For xCount = 0 To dtCustomer.Rows.Count - 1
                '                drCustomer = dtCustomer.Rows(xCount)
                '                If cboCustomer.Items(xCount) = drCustomer("cust_name1") Then
                '                    cboCustomer.SelectedIndex = xCount
                '                End If
                '            Next
            Catch exp As Exception
                MsgBox(exp.ToString)
            Finally
                dtCustomer = Nothing
            End Try


            Try
                '            dtLocation = PSS.Data.Production.Joins.OrderEntrySelect("Select * from tlocation where Loc_ID = " & CInt(LocID))
                drLocation = PSS.Data.Production.tlocation.GetRowByPK(CInt(LocID))

                If IsDBNull(drLocation("Loc_Name")) = False Then cboLocation.Items.Add(drLocation("Loc_Name"))
                If IsDBNull(drLocation("Loc_Name")) = False Then cboLocation.SelectedItem = drLocation("Loc_Name")

                '            For xCount = 0 To dtLocation.Rows.Count - 1
                '                drLocation = dtLocation.Rows(xCount)
                '                cboLocation.Items.Add(drLocation("Loc_Name"))
                '                cboLocation.SelectedItem = drLocation("Loc_Name")
                '            Next
            Catch exp As Exception
                MsgBox(exp.ToString)
            Finally
                dtLocation = Nothing
            End Try

            Try
                '            dtProduct = PSS.Data.Production.Joins.OrderEntrySelect("Select * from lproduct where Prod_ID = " & CInt(prodID))
                drProduct = PSS.Data.Production.lproduct.GetRowByPK(CInt(prodID))

                If IsDBNull(drProduct("Prod_Desc")) = False Then
                    For xCount = 0 To cboProduct.Items.Count - 1
                        If cboProduct.Items(xCount) = drProduct("Prod_Desc") Then
                            cboProduct.SelectedIndex = xCount
                        End If
                    Next
                End If
                '            For xCount = 0 To dtProduct.Rows.Count - 1
                '            drProduct = dtProduct.Rows(xCount)
                '            If cboProduct.Items(xCount) = drProduct("Prod_Desc") Then
                '                cboProduct.SelectedIndex = xCount
                '            End If
                '            Next
            Catch exp As Exception
                MsgBox(exp.ToString)
            Finally
                dtProduct = Nothing
            End Try

            Try
                '            dtShipMthd2 = PSS.Data.Production.Joins.OrderEntrySelect("Select * from lshipmethod where ShipMthd_ID = " & CInt(ShipMethodID))

                '                drShipMthd2 = PSS.Data.Production.lshipmethod.GetRowByPK(CInt(ShipMethodID))

                '               If IsDBNull(drShipMthd2("Ship_Desc")) = False Then
                '                  For xCount = 0 To cboShipMethod.Items.Count - 1
                '                     If cboShipMethod.Items(xCount) = drShipMthd2("Ship_Desc") Then
                '                        cboShipMethod.SelectedIndex = xCount
                '                   End If
                '              Next
                '         End If
            Catch exp As Exception
                MsgBox(exp.ToString)
            Finally
                drShipMthd2 = Nothing
            End Try

            Try
                '            dtLaborPrc = PSS.Data.Production.Joins.OrderEntrySelect("Select * from tlaborprc where LaborPrc_ID = " & CInt(LaborPrc_ID))
                '            drLaborPrc = PSS.Data.Production.tlaborprc.GetRowByPK(CInt(LaborPrc_ID))
                PopulateLaborPrc()

                For xCount = 0 To cboLaborPrc.Items.Count - 1
                    If LaborPrcID(xCount, 0) = LaborPrc_ID Then
                        cboLaborPrc.SelectedIndex = xCount
                    End If
                Next

                '            For xCount = 0 To cboLaborPrc.Items.Count - 1
                '                If LaborPrcID(xCount) = LaborPrc_ID Then
                '                    cboLaborPrc.SelectedIndex = xCount
                '                End If
                '            Next
            Catch exp As Exception
                MsgBox(exp.ToString)
            Finally
                dtLaborPrc = Nothing
            End Try

            If Len(Trim(cboLaborPrc.Text)) < 1 Then
                Dim dtLaborPrc2 As DataTable
                Try
                    dtLaborPrc = PSS.Data.Production.Joins.OrderEntrySelect("Select lpricinggroup.* from lpricinggroup ORDER BY lpricinggroup.PrcGroup_LDesc")
                    Dim aCount As Integer = 0
                    cboLaborPrc.Items.Clear()
                    cboLaborPrc.Text = ""
                    lbLaborDetail.Items.Clear()
                    For xCount = 0 To dtLaborPrc.Rows.Count - 1
                        drLaborPrc = dtLaborPrc.Rows(xCount)
                        If drLaborPrc("PrcGroup_Type") = 1 Then
                            If drLaborPrc("PrcGroup_ID") = Trim(LaborPrc_ID) Then
                                cboLaborPrc.Items.Insert(aCount, drLaborPrc("PrcGroup_LDesc"))
                                LaborPrcID(aCount, 1) = drLaborPrc("PrcGroup_LDesc")
                                LaborPrcID(aCount, 0) = drLaborPrc("PrcGroup_ID")
                                cboLaborPrc.SelectedIndex = aCount
                                ckStandard.Checked = True
                                Exit For
                                aCount += 1
                            End If
                        End If
                    Next
                Catch exp As Exception
                    MsgBox(exp.ToString)
                Finally
                    dtLaborPrc.Dispose()
                    dtLaborPrc = Nothing
                End Try
            End If



            'Make the background color of all the objects that same as the form color
            '        txtName.BackColor = Color.LightGray

        End Sub

        Private Function VerifyInitIDs() As Boolean

            If chkChgManufWrty.Checked = True Then
                valChgManufWrty = 1
            Else
                valChgManufWrty = 0
            End If

            If chkChgShip.Checked = True Then
                valChgShip = 1
            Else
                valChgShip = 0
            End If

            If chkPOPlusParts.Checked = True Then
                valPOPlusParts = 1
            Else
                valPOPlusParts = 0
            End If

            Dim errMsg As String = ""

            If Len(CustomerID(cboCustomer.SelectedIndex)) < 1 Then
                errMsg += "Customer can not be found. " & vbCrLf
                VerifyInitIDs = False
            End If
            If Len(LocationID(cboLocation.SelectedIndex)) < 1 Then
                errMsg += "Location can not be found. " & vbCrLf
                VerifyInitIDs = False
            End If

            If txtName.Enabled = True Then
                If Len(StateID(cboState.SelectedIndex)) < 1 Then
                    errMsg += "State can not be found. " & vbCrLf
                    VerifyInitIDs = False
                End If
                If Len(CountryID(cboCountry.SelectedIndex)) < 1 Then
                    errMsg += "Country can not be found. " & vbCrLf
                    VerifyInitIDs = False
                End If
            End If

            If Len(LaborPrcID(cboLaborPrc.SelectedIndex, 0)) < 1 Then
                errMsg += "Labor Price can not be found. " & vbCrLf
                VerifyInitIDs = False
            End If
            'If Len(ShipMethodID(cboShipMethod.SelectedIndex)) < 1 Then
            'errMsg += "Ship method can not be found. " & vbCrLf
            'VerifyInitIDs = False
            'End If

            '//Craig Haney - January 13, 2005
            Dim ConvertDouble As Double
            If Len(txtRUR.Text) < 1 Then
                errMsg += "Please define an RUR Value. " & vbCrLf
                Try
                    ConvertDouble = CDbl(txtRUR.Text)
                Catch ex As Exception
                    errMsg += "RUR Value is not valid. " & vbCrLf
                End Try
            End If
            If Len(txtNER.Text) < 1 Then
                errMsg += "Please define an NER Value. " & vbCrLf
                Try
                    ConvertDouble = CDbl(txtNER.Text)
                Catch ex As Exception
                    errMsg += "NER Value is not valid. " & vbCrLf
                End Try
            End If
            If Len(txtRTM.Text) < 1 Then
                errMsg += "Please define an RTM Value. " & vbCrLf
                Try
                    ConvertDouble = CDbl(txtRTM.Text)
                Catch ex As Exception
                    errMsg += "RTM Value is not valid. " & vbCrLf
                End Try
            End If
            '//Craig Haney - January 13, 2005

            If Len(errMsg) > 0 Then
                MsgBox("The following errors have occurred: " & vbCrLf & vbCrLf & errMsg)
            Else
                VerifyInitIDs = True
            End If

        End Function

        Private Sub PopulateLaborPrc()

            Dim xCount As Integer

            Dim dtLaborPrc As New DataTable()
            Dim dtLaborPrc2 As DataTable

            Dim drLaborPrc As DataRow

            Try

                'dtLaborPrc = PSS.Data.Production.Joins.OrderEntrySelect("Select lpricinggroup.* from lpricinggroup where lpricinggroup.PrcGroup_Type=2 ORDER BY lpricinggroup.PrcGroup_LDesc")
                dtLaborPrc = PSS.Data.Production.Joins.OrderEntrySelect("Select lpricinggroup.* from lpricinggroup ORDER BY lpricinggroup.PrcGroup_LDesc")

                Dim aCount As Integer = 0

                For xCount = 0 To dtLaborPrc.Rows.Count - 1
                    drLaborPrc = dtLaborPrc.Rows(xCount)
                    If drLaborPrc("PrcGroup_Type") = 2 Then
                        cboLaborPrc.Items.Insert(aCount, drLaborPrc("PrcGroup_LDesc"))
                        LaborPrcID(aCount, 1) = drLaborPrc("PrcGroup_LDesc")
                        LaborPrcID(aCount, 0) = drLaborPrc("PrcGroup_ID")
                        aCount += 1
                    End If


                    '                    valPricingGroupID = drLaborPrc("PrcGroup_ID")
                Next

                'Get and populate labor levels
                '                dtLaborPrc2 = PSS.Data.Production.tlaborprc.GetTableByPrcGroup(valPricingGroupID)
                '                Dim dr As DataRow
                '                lbLaborDetail.Items.Clear()
                '                For xCount = 0 To dtLaborPrc2.Rows.Count - 1
                '                    dr = dtLaborPrc2.Rows(xCount)
                '                    lbLaborDetail.Items.Add("Labor Level: " & dr("LaborLvl_ID"))
                '                    lbLaborDetail.Items.Add("            Regular Price: " & dr("LaborPrc_RegPrc"))
                '                    lbLaborDetail.Items.Add("            Warranty Price: " & dr("LaborPrc_WrtyPrc"))
                '                    lbLaborDetail.Items.Add(" ")
                '                Next

            Catch exp As Exception
                MsgBox(exp.ToString)
            Finally
                dtLaborPrc.Dispose()
                dtLaborPrc = Nothing
            End Try

        End Sub

        Private Function verifyData() As Boolean

            Dim errMsg As String = ""

            If Len(cboCustomer.SelectedItem) < 1 Then
                errMsg += "No customer selected. " & vbCrLf
                verifyData = False
            End If

            If Len(cboLocation.SelectedItem) < 1 Then
                errMsg += "No location selected. " & vbCrLf
                verifyData = False
            End If

            If Len(cboLaborPrc.SelectedItem) < 1 Then
                errMsg += "No labor price selected. " & vbCrLf
                verifyData = False
            End If

            '            If Len(cboShipMethod.SelectedItem) < 1 Then
            '                errMsg += "No ship method selected. " & vbCrLf
            '                verifyData = False
            '            End If

            If txtName.Enabled = True Then

                If Len(cboState.SelectedItem) < 1 Then
                    errMsg += "No state selected. " & vbCrLf
                    verifyData = False
                End If

                If Len(cboCountry.SelectedItem) < 1 Then
                    errMsg += "No country selected. " & vbCrLf
                    verifyData = False
                End If

                If Len(txtAddress1.Text) < 1 Then
                    errMsg += "No address line 1. " & vbCrLf
                    verifyData = False
                End If

                If Len(txtCity.Text) < 1 Then
                    errMsg += "No city. " & vbCrLf
                    verifyData = False
                End If

                If Len(txtZip.Text) < 1 Then
                    errMsg += "No zip code. " & vbCrLf
                    verifyData = False
                End If

            End If

            If Len(txtPOdescription.Text) < 1 Then
                errMsg += "No purchase order description. " & vbCrLf
                verifyData = False
            End If

            If Len(txtPOQuantity.Text) < 1 Then
                errMsg += "No purchase order quantity. " & vbCrLf
                verifyData = False
            End If

            If Len(txtDueDate.Text) < 1 Then
                errMsg += "No due date. " & vbCrLf
                verifyData = False
            ElseIf IsDate(txtDueDate.Text) = False Then
                errMsg += "Due date is not a valid date. " & vbCrLf
                verifyData = False
            End If

            If Len(txtCustomWorkOrder.Text) < 1 Then
                errMsg += "No custom work order date. " & vbCrLf
                verifyData = False
            End If

            If IsNumeric(txtPOQuantity.Text) = False Then
                errMsg += "Quantity must be a numeric value. " & vbCrLf
                verifyData = False
            ElseIf CDbl(txtPOQuantity.Text) <> CInt(txtPOQuantity.Text) Then
                errMsg += "Quantity must be an integer value. " & vbCrLf
                verifyData = False
            End If

            'If IsNumeric(txtCustomWorkOrder.Text) = False Then
            '    errMsg += "Workorder must be a numeric value. " & vbCrLf
            '    verifyData = False
            'ElseIf CDbl(txtCustomWorkOrder.Text) <> CInt(txtCustomWorkOrder.Text) Then
            '    errMsg += "Workorder must be an integer value. " & vbCrLf
            '    verifyData = False
            'End If

            If Len(errMsg) > 0 Then
                MsgBox("The following errors have occurred: " & vbCrLf & vbCrLf & errMsg)
            Else
                verifyData = True
            End If

        End Function

        Private Sub cboCustomer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomer.SelectedIndexChanged

            If ActionType = "New" Then
                ClearFieldsCustomer()
                PopulateLocationList()
                PopulateLaborPrc()
            End If

        End Sub

        Private Sub PopulateLocationList()

            Dim xCount As Integer = 0

            'Populate the location list
            cboLocation.Items.Clear()
            cboLocation.Text = ""

            Dim dt As New DataTable()
            Dim dr As DataRow

            Try
                dt = PSS.Data.Production.Joins.OrderEntrySelect("Select distinct Loc_Name, Loc_ID, cust_ID from tlocation where Cust_id =" & CustomerID(cboCustomer.SelectedIndex))
                For xCount = 0 To dt.Rows.Count - 1
                    dr = dt.Rows(xCount)
                    cboLocation.Items.Insert(xCount, dr("Loc_Name"))


                    LocationID(xCount) = dr("loc_ID")
                Next
            Catch exp As Exception
                MsgBox(exp.ToString)
            Finally
                dt = Nothing
            End Try

        End Sub

        Private Sub cboLocation_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLocation.SelectedIndexChanged

            If ActionType = "New" Then
                getShipToAddress()
            End If

        End Sub

        Private Sub PopulateCustomerList()

            Dim xCount As Integer = 0

            Dim tblCustomer As New PSS.Data.Production.tcustomer()
            Dim rCustomer As DataRow


            Try
                Dim dsCustomer As DataSet = tblCustomer.GetData
                cboCustomer.Items.Clear()
                cboCustomer.Text = ""

                For xCount = 0 To dsCustomer.Tables("tcustomer").Rows.Count - 1
                    rCustomer = dsCustomer.Tables("tcustomer").Rows(xCount)
                    cboCustomer.Items.Insert(xCount, rCustomer("cust_name1"))
                    CustomerID(xCount) = rCustomer("cust_ID")
                Next
            Catch exp As Exception
                MsgBox(exp.ToString)
            Finally
                tblCustomer = Nothing
            End Try

        End Sub

        Private Sub PopulateShipMethodList()

            Dim xCount As Integer = 0

            Dim tblShipMthd As New PSS.Data.Production.lshipmethod()
            Dim rShipMthd As DataRow

            Try
                Dim dsShipMthd As DataSet = tblShipMthd.GetData
                cboShipMethod.Items.Clear()
                cboShipMethod.Text = ""

                For xCount = 0 To dsShipMthd.Tables("lshipmethod").Rows.Count - 1
                    rShipMthd = dsShipMthd.Tables("lshipmethod").Rows(xCount)
                    cboShipMethod.Items.Insert(xCount, rShipMthd("Ship_Desc"))
                    ShipMethodID(xCount) = rShipMthd("ShipMthd_ID")
                Next
            Catch exp As Exception
                MsgBox(exp.ToString)
            Finally
                tblShipMthd = Nothing
            End Try

        End Sub

        Private Sub PopulateStateList()


            Dim xCount As Integer = 0

            Dim tblState As New PSS.Data.Production.lstate()
            Dim rState As DataRow

            Try
                Dim dsState As DataSet = tblState.GetData
                cboState.Items.Clear()
                cboState.Text = ""

                For xCount = 0 To dsState.Tables("lstate").Rows.Count - 1
                    rState = dsState.Tables("lstate").Rows(xCount)
                    cboState.Items.Insert(xCount, rState("State_Short"))
                    StateID(xCount) = rState("State_ID")
                Next
            Catch exp As Exception
                MsgBox(exp.ToString)
            Finally
                tblState = Nothing
            End Try

        End Sub

        Private Sub PopulateProductList()

            Dim xCount As Integer = 0

            Dim tblProd As New PSS.Data.Production.lproduct()
            Dim rProd As DataRow

            Try
                Dim dsProd As DataSet = tblProd.GetData
                cboProduct.Items.Clear()
                cboProduct.Text = ""

                For xCount = 0 To dsProd.Tables("lproduct").Rows.Count - 1
                    rProd = dsProd.Tables("lproduct").Rows(xCount)
                    cboProduct.Items.Insert(xCount, rProd("Prod_Desc"))
                    ProductID(xCount) = rProd("Prod_ID")
                Next
            Catch exp As Exception
                MsgBox(exp.ToString)
            Finally
                tblProd = Nothing
            End Try

        End Sub

        Private Sub PopulateCountryList()

            Dim xCount As Integer = 0

            Dim tblCountry As New PSS.Data.Production.lcountry()
            Dim rCountry As DataRow

            Try
                Dim dsCountry As DataSet = tblCountry.GetData
                cboCountry.Items.Clear()
                cboCountry.Text = ""

                For xCount = 0 To dsCountry.Tables("lcountry").Rows.Count - 1
                    rCountry = dsCountry.Tables("lcountry").Rows(xCount)
                    cboCountry.Items.Insert(xCount, rCountry("Cntry_Name"))
                    CountryID(xCount) = rCountry("Cntry_ID")
                Next
            Catch exp As Exception
                MsgBox(exp.ToString)
            Finally
                tblCountry = Nothing
            End Try

        End Sub

        Private Sub getShipToAddress()

            Dim dt As New DataTable()
            Dim dr As DataRow

            dt = PSS.Data.Production.Joins.OrderEntrySelect("Select distinct Loc_Name, Loc_ID, cust_ID from tlocation where Cust_id =" & CustomerID(cboCustomer.SelectedIndex))


            '        Dim rs As New ADODB.Recordset()
            '        Dim tmpCount, Statecount, Cntrycount As Integer
            '        Dim strSQl As String = "Select * from tlocation where Loc_id = " & LocationID(cboLocation.SelectedIndex)
            '        conn.Open(dbProd)
            '        rs = conn.Execute(strSQl)

            '        'recordset should be one record
            '        rs.MoveFirst()
            '        If rs.BOF = False And rs.EOF = False Then
            '            PopulateStateList()
            '            PopulateCountryList()

            '            tmpCount = 0
            '            Statecount = cboState.Items.Count - 1
            '            For tmpCount = 0 To Statecount
            '                If StateID(tmpCount) = rs.Fields("State_ID").Value Then
            '                    cboState.SelectedIndex = tmpCount
            '                    Exit For
            '                End If
            '            Next

            '            tmpCount = 0
            '            Cntrycount = cboCountry.Items.Count - 1
            '            For tmpCount = 0 To Cntrycount
            '                If CountryID(tmpCount) = rs.Fields("Cntry_ID").Value Then
            '                    cboCountry.SelectedIndex = tmpCount
            '                    Exit For
            '                End If
            '            Next

            '            'load data into form
            '            txtAddress1.Text = rs.Fields("Loc_Address1").Value

            '           If Not IsDBNull(rs.Fields("Loc_Address2").Value) Then
            '               txtAddress2.Text = rs.Fields("Loc_Address2").Value
            '           End If

            '           txtCity.Text = rs.Fields("Loc_City").Value
            '           txtZip.Text = rs.Fields("Loc_Zip").Value
            '       End If

        End Sub

        Private Sub GetDataTDBgrid()

            Dim xCount As Integer = 0

            Dim dtGrid As DataTable
            Dim drGrid As DataRow

            Try
                dtGrid = PSS.Data.Production.Joins.OrderEntrySelect("Select LaborPrc_Desc as Description, LaborPrc_RegPrc as Price, LaborPrc_WrtyPrc as Warranty from tlaborprc where cust_id = " & CustomerID(cboCustomer.SelectedIndex))
                For xCount = 0 To dtGrid.Rows.Count - 1
                    drGrid = dtGrid.Rows(xCount)
                    tdbGrid.DataSource = dtGrid.DefaultView
                Next
            Catch exp As Exception
                MsgBox(exp.ToString)
            Finally
                drGrid = Nothing
                dtGrid.Dispose()
                dtGrid = Nothing
            End Try

        End Sub

        Private Sub cboLaborPrc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLaborPrc.SelectedIndexChanged


            Dim valPricingGroupID As Int32

            'GetDataTDBgrid()

            For xCount = 0 To UBound(LaborPrcID)
                If LaborPrcID(xCount, 1) = cboLaborPrc.Text Then
                    valPricingGroupID = LaborPrcID(xCount, 0)
                    Exit For
                End If
            Next

            'Get and populate labor levels
            Dim dtlaborprc2 As DataTable
            dtlaborprc2 = PSS.Data.Production.Joins.GetTableByPrcGroup(valPricingGroupID)

            Dim dr As DataRow
            lbLaborDetail.Items.Clear()
            For xCount = 0 To dtlaborprc2.Rows.Count - 1
                dr = dtlaborprc2.Rows(xCount)
                lbLaborDetail.Items.Add("Product Group: " & dr("ProdGrp_LDesc"))
                lbLaborDetail.Items.Add("            Regular Price: " & dr("LaborPrc_RegPrc"))
                lbLaborDetail.Items.Add("            Warranty Price: " & dr("LaborPrc_WrtyPrc"))
                lbLaborDetail.Items.Add(" ")
            Next

        End Sub

        Sub ClearFieldsCustomer()

            cboLocation.Items.Clear()

            txtName.Clear()
            txtAddress1.Clear()
            txtAddress2.Clear()
            txtCity.Clear()
            cboState.Items.Clear()
            cboState.Text = ""
            txtZip.Clear()
            cboCountry.Items.Clear()
            cboCountry.Text = ""

            txtPOdescription.Clear()
            txtPOQuantity.Clear()
            txtDueDate.Clear()
            txtCustomWorkOrder.Clear()
            chkChgManufWrty.Checked = False
            chkChgShip.Checked = False
            chkPOPlusParts.Checked = False
            txtMemo.Clear()

            cboLaborPrc.Items.Clear()
            cboLaborPrc.Text = ""
            tdbGrid.ClearFields()

            cboShipMethod.Text = ""

            chkAggregate.Checked = False

        End Sub

        Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

            Dim strReportLoc As String = PSS.Core.ReportPath

            Dim valSuccess As Boolean

            valSuccess = SaveOrderEntryRecord()
            If valSuccess = True Then
                HideAllControls()
                'MsgBox("Purchase Order: " & editValPOID & " has been successfully inserted.", MsgBoxStyle.OKOnly, "Insertion Successful")
                Me.Close()
            Else
                Exit Sub
            End If

            Try
                'Dim report As New ReportDocument()
                'report.Load(strReportLoc & "CustSrvs_PO.rpt", OpenReportMethod.OpenReportByTempCopy)
                'report.Refresh()
                'report.RecordSelectionFormula = "{tpurchaseorder.PO_ID} = " & editValPOID
                'report.PrintToPrinter(1, False, 0, 0)
                'report = Nothing


                'Dim rptApp As New CRAXDRT.Application()
                'Dim rpt As CRAXDRT.Report = rptApp.OpenReport(PSS.Core.Global.ReportPath & "CustSrvs_PO.rpt")
                Dim objRpt As ReportDocument

                objRpt = New ReportDocument()

                With objRpt
                    .RecordSelectionFormula = "{tpurchaseorder.PO_ID} = " & editValPOID
                    .PrintToPrinter(2, True, 0, 0)
                End With

                'rpt.RecordSelectionFormula = "{tpurchaseorder.PO_ID} = " & editValPOID
                'rpt.PrintOut(False, 2)
                'rpt = Nothing


            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try

        End Sub

        Function tworkorder_UPDATE(ByVal aWO_CustWO As String, ByVal aLoc_ID As Integer, ByVal aProd_ID As Integer, ByVal aShipTo_ID As Integer, ByVal aPO_ID As Integer) As String

            Dim vMnth As String
            Dim vDay As String
            Dim vYear As String
            Dim startDate As Date
            startDate = Now
            vMnth = DatePart(DateInterval.Month, startDate)
            vDay = DatePart(DateInterval.Day, startDate)
            If Len(vDay) < 2 Then vDay = "0" & vDay
            If Len(vMnth) < 2 Then vMnth = "0" & vMnth
            vYear = DatePart(DateInterval.Year, startDate)
            Dim newDate As String
            newDate = vYear & "-" & vMnth & "-" & vDay & " 01:01:01"

            tworkorder_UPDATE = "UPDATE tworkorder SET " & _
            "WO_CustWO = '" & aWO_CustWO & "', " & _
            "WO_Date = '" & newDate & "', " & _
            "Loc_ID = " & aLoc_ID & ", " & _
            "Prod_ID = " & updProdID & ", " & _
            "ShipTo_ID = " & updShipToID & ", " & _
            "PO_ID = " & updValPOID & _
            " WHERE ((WO_ID) = " & updValWOID & ")"

        End Function

        Function tworkorder_INSERT(ByVal aWO_CustWO As String, ByVal aLoc_ID As Integer, ByVal aProd_ID As Integer, ByVal aShipTo_ID As Integer, ByVal aPO_ID As Integer) As String

            'Dim vMnth As String
            'Dim vDay As String
            'Dim vYear As String
            'Dim startDate As Date
            'startDate = Now
            'vMnth = DatePart(DateInterval.Month, startDate)
            'vDay = DatePart(DateInterval.Day, startDate)
            'If Len(vDay) < 2 Then vDay = "0" & vDay
            'If Len(vMnth) < 2 Then vMnth = "0" & vMnth
            'vYear = DatePart(DateInterval.Year, startDate)
            Dim newDate As String
            'newDate = vYear & "-" & vMnth & "-" & vDay & " 01:01:01"
            newDate = PSS.Gui.Receiving.FormatDate(Now)

            tworkorder_INSERT = "INSERT into tworkorder ( " & _
            "WO_CustWO, " & _
            "WO_Date, " & _
            "Loc_ID, " & _
            "Prod_ID, " & _
            "ShipTo_ID, " & _
            "PO_ID) VALUES (" & _
            "'" & aWO_CustWO & "', " & _
            "'" & newDate & "', " & _
            aLoc_ID & ", " & _
            aProd_ID & ", " & _
            aShipTo_ID & ", " & _
            aPO_ID & ")"

        End Function

        Function tshipto_UPDATE(ByVal aShipTo_Name As String, ByVal aShipTo_Address1 As String, ByVal aShipTo_Address2 As String, ByVal aShipTo_City As String, ByVal aShipTo_Zip As String, ByVal aState_ID As Integer, ByVal aCntry_ID As Integer) As String

            tshipto_UPDATE = "UPDATE tshipto SET " & _
            "ShipTo_Name = '" & aShipTo_Name & "', " & _
            "ShipTo_Address1 = '" & aShipTo_Address1 & "', " & _
            "ShipTo_Address2 = '" & aShipTo_Address2 & "', " & _
            "ShipTo_City = '" & aShipTo_City & "', " & _
            "ShipTo_Zip = '" & aShipTo_Zip & "', " & _
            "State_ID = " & aState_ID & ", " & _
            "Cntry_ID = " & aCntry_ID & _
            " WHERE ((ShipTo_ID) = " & updShipToID & ")"

        End Function

        Function tshipto_INSERT(ByVal aShipTo_Name As String, ByVal aShipTo_Address1 As String, ByVal aShipTo_Address2 As String, ByVal aShipTo_City As String, ByVal aShipTo_Zip As String, ByVal aState_ID As Integer, ByVal aCntry_ID As Integer, ByVal avalPO As Integer) As String

            tshipto_INSERT = "INSERT into tshipto ( " & _
            "ShipTo_Name, " & _
            "ShipTo_Address1, " & _
            "ShipTo_Address2, " & _
            "ShipTo_City, " & _
            "ShipTo_Zip, " & _
            "State_ID, " & _
            "Cntry_ID, " & _
            "PO_ID) " & _
            "VALUES (" & _
            "'" & aShipTo_Name & "', " & _
            "'" & aShipTo_Address1 & "', " & _
            "'" & aShipTo_Address2 & "', " & _
            "'" & aShipTo_City & "', " & _
            "'" & aShipTo_Zip & "', " & _
            aState_ID & ", " & _
            aCntry_ID & ", " & _
            avalPO & ")"

        End Function

        Function tpurchaseorder_UPDATE(ByVal aPO_Desc As String, ByVal aPO_chgManufWrty As Integer, ByVal aPO_PlusParts As Integer, ByVal aPO_Quantity As Integer, ByVal aPO_ChgShip As Integer, ByVal aPO_DueDate As String, ByVal aPO_Memo As String, ByVal aLaborPrc_ID As Integer, ByVal aLoc_ID As Integer, ByVal aRUR As Double, ByVal aNER As Double, ByVal aRTM As Double, ByVal aAgg As Integer) As String

            Dim txtMemo As String

            txtMemo = "PO_Memo = '" & aPO_Memo & "', "

            If Len(aPO_Memo) < 1 Then
                txtMemo = ""
            End If

            tpurchaseorder_UPDATE = "UPDATE tpurchaseorder SET " & _
            "PO_Desc = '" & aPO_Desc & "', " & _
            "PO_ChgManufWrty = " & aPO_chgManufWrty & ", " & _
            "PO_PlusParts = " & aPO_PlusParts & ", " & _
            "PO_Quanity = " & aPO_Quantity & ", " & _
            "PO_ChrgShip = " & aPO_ChgShip & ", " & _
            "PO_DueDate = '" & aPO_DueDate & "', " & txtMemo & _
            "PrcGroup_ID = " & aLaborPrc_ID & ", " & _
            "Loc_ID = " & aLoc_ID & ", " & _
            "PO_RUR = " & aRUR & ", " & _
            "PO_NER = " & aNER & ", " & _
            "PO_RTM = " & aRTM & ", " & _
            "PO_Aggregate = " & aAgg & _
            " WHERE ((PO_ID) = " & updValPOID & ")"

        End Function

        Function tpurchaseorder_INSERT(ByVal aPO_Desc As String, ByVal aPO_chgManufWrty As Integer, ByVal aPO_PlusParts As Integer, ByVal aPO_Quantity As Integer, ByVal aPO_ChgShip As Integer, ByVal aPO_DueDate As String, ByVal aPO_Memo As String, ByVal aLaborPrc_ID As Integer, ByVal aLoc_ID As Integer, ByVal aRUR As Double, ByVal aNER As Double, ByVal aRTM As Double, ByVal aAgg As Integer) As String


            Dim fieldMemo As String
            Dim txtMemo As String

            fieldMemo = "PO_Memo, "
            txtMemo = "'" & aPO_Memo & "', "

            If Len(aPO_Memo) < 1 Then
                fieldMemo = ""
                txtMemo = ""
            End If

            tpurchaseorder_INSERT = "INSERT into tpurchaseorder ( " & _
            "PO_Desc, " & _
            "PO_ChgManufWrty, " & _
            "PO_PlusParts, " & _
            "PO_Quanity, " & _
            "PO_ChrgShip, " & _
            "PO_DueDate, " & fieldMemo & "PrcGroup_ID, " & _
            "Loc_ID, " & _
            "PO_RUR, " & _
            "PO_NER, " & _
            "PO_RTM, " & _
            "PO_Aggregate) " & _
            "VALUES (" & _
            "'" & aPO_Desc & "', " & _
            aPO_chgManufWrty & ", " & _
            aPO_PlusParts & ", " & _
            aPO_Quantity & ", " & _
            aPO_ChgShip & ", " & _
            "'" & aPO_DueDate & "', " & _
            txtMemo & aLaborPrc_ID & ", " & _
            aLoc_ID & ", " & _
            aRUR & ", " & _
            aNER & ", " & _
            aRTM & ", " & _
            aAgg & ")"

        End Function

        Function tworkorder_SELECT(ByVal aWO_CustWO As String, ByVal aLoc_ID As Integer, ByVal aProd_ID As Integer, ByVal aShipTo_ID As Integer, ByVal aPO_ID As Integer) As String

            tworkorder_SELECT = "SELECT * FROM tworkorder WHERE (" & _
             "((WO_CustWO)= '" & aWO_CustWO & "') AND " & _
            "((Loc_ID)= " & aLoc_ID & ") AND " & _
            "((Prod_ID)= " & aProd_ID & ") AND " & _
            "((ShipTo_ID)= " & aShipTo_ID & ") AND " & _
            "((PO_ID)= " & aPO_ID & "));"


        End Function

        Function tshipto_SELECT(ByVal aShipTo_Name As String, ByVal aShipTo_Address1 As String, ByVal aShipTo_Address2 As String, ByVal aShipTo_City As String, ByVal aShipTo_Zip As String, ByVal aState_ID As Integer, ByVal aCntry_ID As Integer) As String

            tshipto_SELECT = "SELECT * FROM tshipto WHERE (" & _
            "((ShipTo_Name)= '" & aShipTo_Name & "') AND " & _
            "((ShipTo_Address1)= '" & aShipTo_Address1 & "') AND " & _
            "((ShipTo_Address2)= '" & aShipTo_Address2 & "') AND " & _
            "((ShipTo_City)= '" & aShipTo_City & "') AND " & _
            "((ShipTo_Zip)= '" & aShipTo_Zip & "') AND " & _
            "((State_ID)= " & aState_ID & ") AND " & _
            "((Cntry_ID)= " & aCntry_ID & "));"

        End Function

        Function tpurchaseorder_SELECT(ByVal aPO_Desc As String, ByVal aPO_chgManufWrty As Integer, ByVal aPO_PlusParts As Integer, ByVal aPO_Quantity As Integer, ByVal aPO_ChgShip As Integer, ByVal aShipMthd_ID As Integer, ByVal aPO_Memo As String, ByVal aLoc_ID As Integer) As String

            tpurchaseorder_SELECT = "SELECT * FROM tpurchaseorder WHERE (" & _
            "((PO_Desc)= '" & aPO_Desc & "') AND " & _
            "((PO_ChgManufWrty)= " & aPO_chgManufWrty & ") AND " & _
            "((PO_PlusParts)= " & aPO_PlusParts & ") AND " & _
            "((PO_Quanity)= " & aPO_Quantity & ") AND " & _
            "((PO_ChrgShip)= " & aPO_ChgShip & ") AND " & _
            "((ShipMthd_ID)= " & aShipMthd_ID & ") AND " & _
            "((PO_Memo)= '" & aPO_Memo & "') AND " & _
            "((Loc_ID)= " & aLoc_ID & "));"

        End Function

        Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

            '        ClearFieldsCustomer()

            PopulateCustomerList()
            PopulateShipMethodList()
            PopulateProductList()
            HideAllControls()

            cboLocation.Text = ""
            cboCustomer.Text = ""

            '        cboCustomer.SelectedIndex = 0

            cboProduct.Text = ""
            PopulateLocationList()

            'This is a new record - stay as is
            ShowAllControls()
            EnableAllInputControls()

            btnDelete.Visible = False
            btnUpdate.Visible = False
            btnSave.Top = 448
            btnSave.Left = 448
            btnSave.Height = 40
            btnSave.Width = 288

            ActionType = "New"
            lblType.Text = "NEW RECORD"
            cboCustomer.Select()

        End Sub

        Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

            ClearFieldsCustomer()

            cboLocation.Text = ""
            cboCustomer.Text = ""
            cboCustomer.SelectedIndex = 0

            cboProduct.Text = ""


            HideAllControls()

            'This is to edit a record
            Dim poNumber As Integer
            poNumber = InputBox("Enter the Purchase Order Number:", "PO Number")
            GetPageData(poNumber)

            'This is a new record - stay as is
            ShowAllControls()
            EnableAllInputControls()

            btnDelete.Visible = False
            btnSave.Visible = False
            btnUpdate.Top = 448
            btnUpdate.Left = 448
            btnUpdate.Height = 40
            btnUpdate.Width = 288

            ActionType = "Update"
            lblType.Text = "UPDATE RECORD"
            cboCustomer.Select()



        End Sub

        Private Sub MenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

            Dim Verify As Boolean

            ClearFieldsCustomer()


            cboLocation.Text = ""
            cboCustomer.Text = ""
            cboCustomer.SelectedIndex = 0

            cboProduct.Text = ""


            HideAllControls()

            Dim poNumber As Integer
            poNumber = InputBox("Enter the Purchase Order Number:", "PO Number")


            Verify = VerifyRecord(poNumber)
            If Verify = True Then


                GetPageData(poNumber)

                'This is a new record - stay as is
                ShowAllControls()

                btnSave.Visible = False
                btnUpdate.Visible = False

                DisableAllInputControls()

                btnDelete.Top = 448
                btnDelete.Left = 448
                btnDelete.Height = 40
                btnDelete.Width = 288

                ActionType = "Delete"
                lblType.Text = "DELETE RECORD"
                cboCustomer.Select()
            Else
                MsgBox("Record could not be located.", MsgBoxStyle.OKOnly, "Missing")
                HideAllControls()
            End If

        End Sub

        Private Sub HideAllControls()

            'Hide all controls
            btnSave.Visible = False
            btnDelete.Visible = False
            btnUpdate.Visible = False
            cboCountry.Visible = False
            cboCustomer.Visible = False
            cboLaborPrc.Visible = False
            cboLocation.Visible = False
            cboProduct.Visible = False
            cboShipMethod.Visible = False
            cboState.Visible = False
            chkChgManufWrty.Visible = False
            chkChgShip.Visible = False
            chkPOPlusParts.Visible = False
            lblAddress1.Visible = False
            lblAddress2.Visible = False
            lblCityStateZip.Visible = False
            lblCountry.Visible = False
            lblCustomer.Visible = False
            lblCustomWorkOrder.Visible = False
            lblDesc.Visible = False
            lblDueDate.Visible = False
            lblLaborPrc.Visible = False
            lblLocation.Visible = False
            lblMainBox.Visible = False
            lblMemo.Visible = False
            lblName.Visible = False
            lblPObox.Visible = False
            lblProduct.Visible = False
            lblPurchaseOrder.Visible = False
            lblQuantity.Visible = False
            lblShipBox.Visible = False
            lblShipMethod.Visible = False
            btnShipTo.Visible = False
            lblShipMthd.Visible = False
            lblType.Visible = False
            tdbGrid.Visible = False
            txtAddress1.Visible = False
            txtAddress2.Visible = False
            txtCity.Visible = False
            txtZip.Visible = False
            txtCustomWorkOrder.Visible = False
            txtPOdescription.Visible = False
            txtDueDate.Visible = False
            txtMemo.Visible = False
            txtName.Visible = False
            txtPOQuantity.Visible = False
            lbLaborDetail.Visible = False
            btnAddPricingGroup.Visible = False


        End Sub

        Private Sub ShowAllControls()

            'Show all controls
            btnSave.Visible = True
            btnDelete.Visible = True
            btnUpdate.Visible = True
            cboCountry.Visible = True
            cboCustomer.Visible = True
            cboLaborPrc.Visible = True
            cboLocation.Visible = True
            cboProduct.Visible = True
            cboShipMethod.Visible = True
            cboState.Visible = True
            chkChgManufWrty.Visible = True
            chkChgShip.Visible = True
            chkPOPlusParts.Visible = True
            lblAddress1.Visible = True
            lblAddress2.Visible = True
            lblCityStateZip.Visible = True
            lblCountry.Visible = True
            lblCustomer.Visible = True
            lblCustomWorkOrder.Visible = True
            lblDesc.Visible = True
            lblDueDate.Visible = True
            lblLaborPrc.Visible = True
            lblLocation.Visible = True
            lblMainBox.Visible = True
            lblMemo.Visible = True
            lblName.Visible = True
            lblPObox.Visible = True
            lblProduct.Visible = True
            lblPurchaseOrder.Visible = True
            lblQuantity.Visible = True
            lblShipBox.Visible = True
            lblShipMethod.Visible = True
            btnShipTo.Visible = True
            lblShipMthd.Visible = True
            lblType.Visible = True
            tdbGrid.Visible = True
            txtAddress1.Visible = True
            txtAddress2.Visible = True
            txtCity.Visible = True
            txtZip.Visible = True
            txtCustomWorkOrder.Visible = True
            txtPOdescription.Visible = True
            txtDueDate.Visible = True
            txtMemo.Visible = True
            txtName.Visible = True
            txtPOQuantity.Visible = True
            lbLaborDetail.Visible = True
            btnAddPricingGroup.Visible = True

        End Sub

        Private Sub DisableAllInputControls()

            cboCountry.Enabled = False
            cboCustomer.Enabled = False
            cboLaborPrc.Enabled = False
            cboLocation.Enabled = False
            cboProduct.Enabled = False
            cboShipMethod.Enabled = False
            cboState.Enabled = False
            chkChgManufWrty.Enabled = False
            chkChgShip.Enabled = False
            chkPOPlusParts.Enabled = False
            tdbGrid.Enabled = False
            txtName.Enabled = False
            txtAddress1.Enabled = False
            txtAddress2.Enabled = False
            txtCity.Enabled = False
            txtZip.Enabled = False
            txtCustomWorkOrder.Enabled = False
            txtPOdescription.Enabled = False
            txtDueDate.Enabled = False
            txtMemo.Enabled = False
            txtName.Enabled = False
            txtPOQuantity.Enabled = False

        End Sub

        Private Sub EnableAllInputControls()

            cboCountry.Enabled = True
            cboCustomer.Enabled = True
            cboLaborPrc.Enabled = True
            cboLocation.Enabled = True
            cboProduct.Enabled = True
            cboShipMethod.Enabled = True
            cboState.Enabled = True
            chkChgManufWrty.Enabled = True
            chkChgShip.Enabled = True
            chkPOPlusParts.Enabled = True
            tdbGrid.Enabled = True
            txtName.Enabled = True
            txtAddress1.Enabled = True
            txtAddress2.Enabled = True
            txtCity.Enabled = True
            txtZip.Enabled = True
            txtCustomWorkOrder.Enabled = True
            txtPOdescription.Enabled = True
            txtDueDate.Enabled = True
            txtMemo.Enabled = True
            txtName.Enabled = True
            txtPOQuantity.Enabled = True

        End Sub

        Private Function deleteOrderEntryRecord() As Boolean

            deleteOrderEntryRecord = False

            Dim dltOE As New PSS.Data.Production.Joins()
            Dim blnDelete As Boolean

            Dim dtDelShipTo As DataTable
            Dim rDelShipTo As DataRow
            Dim sqlDelete As String

            Try

                If Len(editValShipToID) > 0 And IsNumeric(editValShipToID) = True Then
                    If Len(editValWorkOrder) > 0 And IsNumeric(editValWorkOrder) = True Then
                        If Len(editValPOID) > 0 And IsNumeric(editValPOID) = True Then
                            sqlDelete = "DELETE from tshipto where ShipTo_ID = " & editValShipToID
                            blnDelete = dltOE.OrderEntryUpdateDelete(sqlDelete)

                            sqlDelete = "DELETE from tworkorder where WO_ID = " & editValWorkOrder
                            blnDelete = dltOE.OrderEntryUpdateDelete(sqlDelete)

                            sqlDelete = "DELETE from tpurchaseorder where PO_ID = " & editValPOID
                            blnDelete = dltOE.OrderEntryUpdateDelete(sqlDelete)
                        End If
                    End If
                End If
            Catch exp As Exception
                MsgBox(exp.ToString)
            Finally
                deleteOrderEntryRecord = True
            End Try

        End Function

        Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

            Dim valSuccess As Boolean

            Dim retVal As Integer

            retVal = MsgBox("Are you sure that you want to delete PO number: " & editValPOID & "?", MsgBoxStyle.YesNo, "Confirm Delete")
            If retVal = 7 Then
                Exit Sub
            ElseIf retVal = 2 Then
                'continue as normal
            End If

            valSuccess = deleteOrderEntryRecord()
            HideAllControls()
            MsgBox("Purchase Order: " & editValPOID & " has been successfully deleted.", MsgBoxStyle.OKOnly, "Deletion Successful")
            Me.Close()

        End Sub

        Private Function UpdateOrderEntryRecord() As Boolean


            '        UpdateOrderEntryRecord = False


            Dim updOE As New PSS.Data.Production.Joins()
            Dim blnUpdate As Boolean


            Dim dataVer As Boolean = False
            Dim dataVerInit As Boolean
            Dim sqlUpdate As String
            Dim sqlRead As String
            Dim valPO As String
            Dim valShipTo As String
            Dim valWorkOrder As String

            dataVer = verifyData()
            If dataVer = True Then
                dataVerInit = VerifyInitIDs()
                If dataVerInit = True Then

                    Dim vMnth As String
                    Dim vDay As String
                    Dim vYear As String
                    Dim startDate As Date
                    startDate = txtDueDate.Text
                    vMnth = DatePart(DateInterval.Month, startDate)
                    vDay = DatePart(DateInterval.Day, startDate)
                    If Len(vDay) < 2 Then vDay = "0" & vDay
                    If Len(vMnth) < 2 Then vMnth = "0" & vMnth
                    vYear = DatePart(DateInterval.Year, startDate)
                    Dim newDate As String
                    newDate = vYear & "-" & vMnth & "-" & vDay & " 01:01:01"

                    Dim vAgg As Integer
                    If chkAggregate.Checked = True Then
                        vAgg = 1
                    Else
                        vAgg = 2
                    End If


                    'sqlUpdate = tpurchaseorder_UPDATE(txtPOdescription.Text, valChgManufWrty, valPOPlusParts, CInt(txtPOQuantity.Text), valChgShip, newDate, txtMemo.Text, LaborPrcID(cboLaborPrc.SelectedIndex, 0), LocationID(cboLocation.SelectedIndex))
                    '//New edit July, 21, 2003
                    sqlUpdate = tpurchaseorder_UPDATE(txtPOdescription.Text, valChgManufWrty, valPOPlusParts, CInt(txtPOQuantity.Text), valChgShip, newDate, txtMemo.Text, LaborPrcID(cboLaborPrc.SelectedIndex, 0), editLocID, txtRUR.Text, txtNER.Text, txtRTM.Text, vAgg)
                    '//New edit July, 21, 2003 - END
                    blnUpdate = updOE.OrderEntryUpdateDelete(sqlUpdate)
                    Try
                        sqlUpdate = tshipto_UPDATE(txtName.Text, txtAddress1.Text, txtAddress2.Text, txtCity.Text, txtZip.Text, StateID(cboState.SelectedIndex), CountryID(cboCountry.SelectedIndex))
                        blnUpdate = updOE.OrderEntryUpdateDelete(sqlUpdate)
                    Catch exp As Exception
                    End Try

                    'sqlUpdate = tworkorder_UPDATE(txtCustomWorkOrder.Text, LocationID(cboLocation.SelectedIndex), ProductID(cboProduct.SelectedIndex), updShipToID, updValPOID)
                    sqlUpdate = tworkorder_UPDATE(txtCustomWorkOrder.Text, editLocID, ProductID(cboProduct.SelectedIndex), updShipToID, updValPOID)
                    blnUpdate = updOE.OrderEntryUpdateDelete(sqlUpdate)
                End If
            End If

            editLocID = 0
            UpdateOrderEntryRecord = True

        End Function

        Private Function SaveOrderEntryRecord() As Boolean


            SaveOrderEntryRecord = False

            Dim dataVer As Boolean = False
            Dim dataVerInit As Boolean
            Dim sqlInsert As String
            Dim sqlRead As String
            Dim valPO As Int32
            Dim valShipTo As Int32
            Dim valWorkOrder As Int32


            '//Craig Haney - January 13, 2005
            '//Verify pricing entries are valid




            '//Craig Haney - January 13, 2005

            dataVer = verifyData()

            Dim strReportLoc As String = PSS.Core.ReportPath

            If dataVer = False Then
                MsgBox("The record could not be saved because the data to be saved in not in the correct format. Please modify the data as needed.", MsgBoxStyle.OKOnly, "Error")
                Exit Function
            End If

            If dataVer = True Then
                dataVerInit = VerifyInitIDs()

                If dataVerInit = False Then
                    MsgBox("The record could not be saved because the data to be saved in not in the correct format. Please modify the data as needed.", MsgBoxStyle.OKOnly, "Error")
                    Exit Function
                End If

                If dataVerInit = True Then
                    'tPurchaseOrder*****************************************************************
                    Dim vMnth As String
                    Dim vDay As String
                    Dim vYear As String
                    Dim startDate As Date
                    startDate = txtDueDate.Text
                    vMnth = DatePart(DateInterval.Month, startDate)
                    vDay = DatePart(DateInterval.Day, startDate)
                    If Len(vDay) < 2 Then vDay = "0" & vDay
                    If Len(vMnth) < 2 Then vMnth = "0" & vMnth
                    vYear = DatePart(DateInterval.Year, startDate)
                    Dim newDate As String
                    newDate = vYear & "-" & vMnth & "-" & vDay & " 01:01:01"


                    Dim vAgg As Integer
                    If chkAggregate.Checked = True Then
                        vAgg = 1
                    Else
                        vAgg = 2
                    End If


                    Try
                        sqlInsert = tpurchaseorder_INSERT(txtPOdescription.Text, valChgManufWrty, valPOPlusParts, CInt(txtPOQuantity.Text), valChgShip, newDate, txtMemo.Text, LaborPrcID(cboLaborPrc.SelectedIndex, 0), LocationID(cboLocation.SelectedIndex), txtRUR.Text, txtNER.Text, txtRTM.Text, vAgg)
                        Dim poInsert As New PSS.Data.Production.tpurchaseorder()
                        valPO = poInsert.idTransaction(sqlInsert)

                        If txtName.Enabled = True Then
                            sqlInsert = tshipto_INSERT(txtName.Text, txtAddress1.Text, txtAddress2.Text, txtCity.Text, txtZip.Text, StateID(cboState.SelectedIndex), CountryID(cboCountry.SelectedIndex), valPO)
                            Dim shiptoInsert As New PSS.Data.Production.tshipto()
                            valShipTo = shiptoInsert.idTransaction(sqlInsert)
                        Else
                            'sqlInsert = tshipto_INSERT(null, null, null, null, null, null, null, valPO)
                            'Dim shiptoInsert As New PSS.Data.Production.tshipto()
                        End If

                        '//New July 11, 2003
                        '//Update PO with ShipTo
                        If Len(Trim(valShipTo)) > 0 Then
                            Dim sqlUpdate As String
                            sqlUpdate = "UPDATE tpurchaseorder set ShipTo_ID = " & valShipTo & " WHERE PO_ID = " & valPO
                            Dim poUpdate As New PSS.Data.Production.Joins()
                            Dim blnUpdate As Boolean = poUpdate.OrderEntryUpdateDelete(sqlUpdate)
                        End If
                        '//New July 11, 2003 - END

                        sqlInsert = tworkorder_INSERT(txtCustomWorkOrder.Text, LocationID(cboLocation.SelectedIndex), ProductID(cboProduct.SelectedIndex), valShipTo, valPO)
                        Dim workorderInsert As New PSS.Data.Production.tworkorder()
                        valWorkOrder = workorderInsert.idTransaction(sqlInsert)
                    Catch exp As Exception
                        MsgBox(exp.ToString)

                    Finally
                        SaveOrderEntryRecord = True

                        '//Report to Print
                        MainWin.StatusBar.SetStatusText("Sending Purchase Order to Printer")
                        '                        Dim report1 As New ReportDocument()
                        '                        report1.Load(strReportLoc & "CustSrvs_PO.rpt", OpenReportMethod.OpenReportByTempCopy)
                        '                        report1.Refresh()
                        '                        report1.RecordSelectionFormula = "{tpurchaseorder.PO_ID}= " & valPO
                        'report1.PrintToPrinter(1, False, 0, 0)

                        'Dim rptApp As New CRAXDRT.Application()
                        'Dim rpt As CRAXDRT.Report = rptApp.OpenReport(PSS.Core.Global.ReportPath & "CustSrvs_PO.rpt")
                        Dim objRpt As ReportDocument

                        objRpt = New ReportDocument()

                        With objRpt
                            .Load(PSS.Core.Global.ReportPath & "CustSrvs_PO.rpt")
                            .RecordSelectionFormula = "{tpurchaseorder.PO_ID} = " & valPO
                            .PrintToPrinter(2, True, 0, 0)
                        End With

                        'rpt.RecordSelectionFormula = "{tpurchaseorder.PO_ID} = " & valPO
                        'rpt.PrintOut(False, 2)
                        'rpt = Nothing

                        Cursor.Current = System.Windows.Forms.Cursors.Default
                        MainWin.StatusBar.SetStatusText("")

                    End Try
                    MainWin.StatusBar.SetStatusText("")

                    'New
                    editValPOID = valPO
                    'End New
                End If
            End If

        End Function

        Private Function VerifyRecord(ByVal aPOnum As Integer) As Boolean

            Dim dtWorkOrder As DataTable
            Dim drWorkOrder As DataRow

            Try
                dtWorkOrder = PSS.Data.Production.Joins.OrderEntrySelect("Select * from tworkorder where PO_ID = '" & aPOnum & "';")
                VerifyRecord = False
                If dtWorkOrder.Rows.Count > -1 Then
                    VerifyRecord = True
                End If
            Catch exp As Exception
                MsgBox(exp.ToString)
            Finally

            End Try


        End Function

        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

            Dim strReportLoc As String = PSS.Core.ReportPath

            Dim valSuccess As Boolean

            valSuccess = UpdateOrderEntryRecord()
            HideAllControls()
            '            MsgBox("Purchase Order: " & editValPOID & " has been successfully updated.", MsgBoxStyle.OKOnly, "Update Successful")
            Me.Close()

            Try
                '                Dim report As New ReportDocument()
                '                report.Load(strReportLoc & "CustSrvs_PO.rpt", OpenReportMethod.OpenReportByTempCopy)
                '                report.Refresh()
                '                report.RecordSelectionFormula = "{tpurchaseorder.PO_ID} = " & editValPOID
                '                report.PrintToPrinter(1, False, 0, 0)
                '                report = Nothing


                'Dim rptApp As New CRAXDRT.Application()
                'Dim rpt As CRAXDRT.Report = rptApp.OpenReport(PSS.Core.Global.ReportPath & "CustSrvs_PO.rpt")
                Dim objRpt As ReportDocument

                objRpt = New ReportDocument()

                With objRpt
                    .Load(PSS.Core.Global.ReportPath & "CustSrvs_PO.rpt")
                    .RecordSelectionFormula = "{tpurchaseorder.PO_ID} = " & editValPOID
                    .PrintToPrinter(2, True, 0, 0)
                End With

                'rpt.RecordSelectionFormula = "{tpurchaseorder.PO_ID} = " & editValPOID
                'rpt.PrintOut(False, 2)
                'rpt = Nothing


            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try

        End Sub

        Private Sub frmOrderEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            If txtName.Enabled = False And Len(txtName.Text) < 1 Then
                DisableShipTo()
            End If
            cboShipMethod.Enabled = False '//This will be used in the future of the system

        End Sub

        Private Sub btnShipTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShipTo.Click

            'Toggle between enabled and disabled
            If txtName.Enabled = True Then
                '//Disable
                DisableShipTo()
            Else
                '//Enable
                EnableShipTo()
            End If

        End Sub


        Private Sub DisableShipTo()
            'Disable ship to controls for input
            '//Empty the controls first
            txtName.Text = ""
            txtAddress1.Text = ""
            txtAddress2.Text = ""
            txtCity.Text = ""
            cboState.Text = ""
            txtZip.Text = ""
            cboCountry.Text = ""
            '//Now Disable the controls
            txtName.Enabled = False
            txtAddress1.Enabled = False
            txtAddress2.Enabled = False
            txtCity.Enabled = False
            cboState.Enabled = False
            txtZip.Enabled = False
            cboCountry.Enabled = False
            cboShipMethod.Focus()
        End Sub

        Private Sub EnableShipTo()
            'Enable ship to controls for input
            txtName.Enabled = True
            txtAddress1.Enabled = True
            txtAddress2.Enabled = True
            txtCity.Enabled = True
            cboState.Enabled = True
            txtZip.Enabled = True
            cboCountry.Enabled = True
            '//Set focus to the start of the address
            txtName.Focus()
        End Sub

        Private Sub btnAddPricingGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddPricingGroup.Click

            Dim frmPG As New OrderEntry.mtnPricingGroup()
            frmPG.ShowDialog()

            PopulateLaborPrc()

        End Sub

        Private Sub populateStandardDataSet()

            Dim tmpC2P As New PSS.Data.Production.tcusttoprice()
            dtStandard = tmpC2P.GetData
            Dim tmpCust As New PSS.Data.Production.tcustomer()
            dtCustomer = tmpCust.GetData
            Dim tmpDeviceType As New PSS.Data.Production.lproduct()
            dtDeviceType = tmpDeviceType.GetData

        End Sub

        Private Sub ckStandard_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckStandard.CheckedChanged


            If ckStandard.Checked = True Then

                'read data from dtstandarddataset
                'get customer id

                Dim tmpCustID As Int32 = 0
                Dim tmpProdID As Integer = 0
                Dim tmpPrcGroup As Int32

                Dim tmpCust As New PSS.Data.Production.tcustomer()
                dtCustomer = tmpCust.GetData

                Dim r As DataRow
                For xCount = 0 To dtCustomer.Tables("tcustomer").Rows.Count - 1
                    r = dtCustomer.Tables("tcustomer").Rows(xCount)
                    If Trim(r("Cust_Name1")) = Trim(cboCustomer.Text) Then
                        tmpCustID = r("Cust_ID")
                        Exit For
                    End If
                Next

                Dim tmpC2P As New PSS.Data.Production.tcusttoprice()
                dtStandard = tmpC2P.GetData
                Dim tmpDeviceType As New PSS.Data.Production.lproduct()
                dtDeviceType = tmpDeviceType.GetData
                For xCount = 0 To dtDeviceType.Tables("lproduct").Rows.Count - 1
                    r = dtDeviceType.Tables("lproduct").Rows(xCount)
                    If Trim(r("Prod_Desc")) = Trim(cboProduct.Text) Then
                        tmpProdID = r("Prod_ID")
                        Exit For
                    End If
                Next

                If tmpCustID > 0 And tmpProdID > 0 Then

                    For xCount = 0 To dtStandard.Tables("tcusttoprice").Rows.Count - 1
                        r = dtStandard.Tables("tcusttoprice").Rows(xCount)
                        If Trim(r("Cust_ID")) = Trim(tmpCustID) And Trim(r("Prod_ID")) = Trim(tmpProdID) Then
                            tmpPrcGroup = r("PrcGroup_ID")
                            Exit For
                        End If
                    Next

                    Dim dtLaborPrc As New DataTable()
                    Dim dtLaborPrc2 As DataTable

                    Dim drLaborPrc As DataRow

                    Try

                        dtLaborPrc = PSS.Data.Production.Joins.OrderEntrySelect("Select lpricinggroup.* from lpricinggroup ORDER BY lpricinggroup.PrcGroup_LDesc")

                        Dim aCount As Integer = 0


                        cboLaborPrc.Items.Clear()
                        cboLaborPrc.Text = ""
                        lbLaborDetail.Items.Clear()

                        For xCount = 0 To dtLaborPrc.Rows.Count - 1
                            drLaborPrc = dtLaborPrc.Rows(xCount)
                            If drLaborPrc("PrcGroup_Type") = 1 Then
                                If drLaborPrc("PrcGroup_ID") = Trim(tmpPrcGroup) Then
                                    cboLaborPrc.Items.Insert(aCount, drLaborPrc("PrcGroup_LDesc"))
                                    LaborPrcID(aCount, 1) = drLaborPrc("PrcGroup_LDesc")
                                    LaborPrcID(aCount, 0) = drLaborPrc("PrcGroup_ID")
                                    cboLaborPrc.SelectedIndex = aCount
                                    Exit For
                                    aCount += 1
                                End If
                            End If
                        Next


                    Catch exp As Exception
                        MsgBox(exp.ToString)
                    Finally
                        dtLaborPrc.Dispose()
                        dtLaborPrc = Nothing
                    End Try

                End If
            Else
                cboLaborPrc.Items.Clear()
                cboLaborPrc.Text = ""
                lbLaborDetail.Items.Clear()
                PopulateLaborPrc()
            End If

        End Sub




    End Class

End Namespace
