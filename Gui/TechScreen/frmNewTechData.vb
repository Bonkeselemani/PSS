Imports PSS.Data
Imports PSS.Core
Imports PSS.Rules
Imports PSS.Core.[Global]

Namespace Gui.techscreen


    Public Class frmNewTechData
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
        Friend WithEvents lblModel As System.Windows.Forms.Label
        Friend WithEvents btnAdd As System.Windows.Forms.Button
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents cboCustomer As PSS.Gui.Controls.ComboBox
        Friend WithEvents cboModel As PSS.Gui.Controls.ComboBox
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents tbCustomer As System.Windows.Forms.TabPage
        Friend WithEvents tbManufModel As System.Windows.Forms.TabPage
        Friend WithEvents glCustomer As System.Windows.Forms.Label
        Friend WithEvents gridCustomer As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents glManufacturer As System.Windows.Forms.Label
        Friend WithEvents gridManufacturer As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents pnlAddUpdateDelete As System.Windows.Forms.Panel
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents btnSave As System.Windows.Forms.Button
        Friend WithEvents lblBillCode As System.Windows.Forms.Label
        Friend WithEvents lblProblemFound As System.Windows.Forms.Label
        Friend WithEvents lblRepairAction As System.Windows.Forms.Label
        Friend WithEvents lblRefDes As System.Windows.Forms.Label
        Friend WithEvents lblNumber As System.Windows.Forms.Label
        Friend WithEvents lblFailure As System.Windows.Forms.Label
        Friend WithEvents cboBillCode As System.Windows.Forms.ComboBox
        Friend WithEvents cboProblemFound As System.Windows.Forms.ComboBox
        Friend WithEvents cboRepairAction As System.Windows.Forms.ComboBox
        Friend WithEvents cboRefDes As System.Windows.Forms.ComboBox
        Friend WithEvents cboFailure As System.Windows.Forms.ComboBox
        Friend WithEvents txtNumber As System.Windows.Forms.TextBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmNewTechData))
            Dim GridLines1 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
            Dim GridLines2 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
            Me.lblCustomer = New System.Windows.Forms.Label()
            Me.lblModel = New System.Windows.Forms.Label()
            Me.btnAdd = New System.Windows.Forms.Button()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.cboCustomer = New PSS.Gui.Controls.ComboBox()
            Me.cboModel = New PSS.Gui.Controls.ComboBox()
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.tbManufModel = New System.Windows.Forms.TabPage()
            Me.glManufacturer = New System.Windows.Forms.Label()
            Me.gridManufacturer = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.tbCustomer = New System.Windows.Forms.TabPage()
            Me.glCustomer = New System.Windows.Forms.Label()
            Me.gridCustomer = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.pnlAddUpdateDelete = New System.Windows.Forms.Panel()
            Me.txtNumber = New System.Windows.Forms.TextBox()
            Me.cboFailure = New System.Windows.Forms.ComboBox()
            Me.cboRefDes = New System.Windows.Forms.ComboBox()
            Me.cboRepairAction = New System.Windows.Forms.ComboBox()
            Me.cboProblemFound = New System.Windows.Forms.ComboBox()
            Me.cboBillCode = New System.Windows.Forms.ComboBox()
            Me.lblFailure = New System.Windows.Forms.Label()
            Me.lblNumber = New System.Windows.Forms.Label()
            Me.lblRefDes = New System.Windows.Forms.Label()
            Me.lblRepairAction = New System.Windows.Forms.Label()
            Me.lblProblemFound = New System.Windows.Forms.Label()
            Me.lblBillCode = New System.Windows.Forms.Label()
            Me.btnSave = New System.Windows.Forms.Button()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.TabControl1.SuspendLayout()
            Me.tbManufModel.SuspendLayout()
            CType(Me.gridManufacturer, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tbCustomer.SuspendLayout()
            CType(Me.gridCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlAddUpdateDelete.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblCustomer
            '
            Me.lblCustomer.BackColor = System.Drawing.Color.SteelBlue
            Me.lblCustomer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblCustomer.ForeColor = System.Drawing.Color.White
            Me.lblCustomer.Location = New System.Drawing.Point(8, 56)
            Me.lblCustomer.Name = "lblCustomer"
            Me.lblCustomer.Size = New System.Drawing.Size(184, 16)
            Me.lblCustomer.TabIndex = 0
            Me.lblCustomer.Text = "Customer"
            '
            'lblModel
            '
            Me.lblModel.BackColor = System.Drawing.Color.SteelBlue
            Me.lblModel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblModel.ForeColor = System.Drawing.Color.White
            Me.lblModel.Location = New System.Drawing.Point(8, 8)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(184, 16)
            Me.lblModel.TabIndex = 1
            Me.lblModel.Text = "Model"
            '
            'btnAdd
            '
            Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnAdd.Location = New System.Drawing.Point(8, 104)
            Me.btnAdd.Name = "btnAdd"
            Me.btnAdd.Size = New System.Drawing.Size(184, 23)
            Me.btnAdd.TabIndex = 0
            Me.btnAdd.Text = "Add Record"
            '
            'btnClear
            '
            Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnClear.Location = New System.Drawing.Point(8, 136)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(184, 23)
            Me.btnClear.TabIndex = 0
            Me.btnClear.Text = "Clear"
            '
            'cboCustomer
            '
            Me.cboCustomer.AutoComplete = True
            Me.cboCustomer.Location = New System.Drawing.Point(8, 72)
            Me.cboCustomer.Name = "cboCustomer"
            Me.cboCustomer.Size = New System.Drawing.Size(184, 21)
            Me.cboCustomer.TabIndex = 0
            '
            'cboModel
            '
            Me.cboModel.AutoComplete = True
            Me.cboModel.Location = New System.Drawing.Point(8, 24)
            Me.cboModel.Name = "cboModel"
            Me.cboModel.Size = New System.Drawing.Size(184, 21)
            Me.cboModel.TabIndex = 0
            '
            'TabControl1
            '
            Me.TabControl1.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tbManufModel, Me.tbCustomer})
            Me.TabControl1.Location = New System.Drawing.Point(200, 8)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(640, 448)
            Me.TabControl1.TabIndex = 0
            '
            'tbManufModel
            '
            Me.tbManufModel.Controls.AddRange(New System.Windows.Forms.Control() {Me.glManufacturer, Me.gridManufacturer})
            Me.tbManufModel.Location = New System.Drawing.Point(4, 22)
            Me.tbManufModel.Name = "tbManufModel"
            Me.tbManufModel.Size = New System.Drawing.Size(632, 422)
            Me.tbManufModel.TabIndex = 1
            Me.tbManufModel.Text = "Manufacturer/Model"
            '
            'glManufacturer
            '
            Me.glManufacturer.BackColor = System.Drawing.Color.SteelBlue
            Me.glManufacturer.ForeColor = System.Drawing.Color.White
            Me.glManufacturer.Location = New System.Drawing.Point(8, 8)
            Me.glManufacturer.Name = "glManufacturer"
            Me.glManufacturer.Size = New System.Drawing.Size(608, 16)
            Me.glManufacturer.TabIndex = 22
            Me.glManufacturer.Text = "Manufacturer"
            '
            'gridManufacturer
            '
            Me.gridManufacturer.AllowFilter = True
            Me.gridManufacturer.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
            Me.gridManufacturer.AllowSort = True
            Me.gridManufacturer.AlternatingRows = True
            Me.gridManufacturer.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.gridManufacturer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.gridManufacturer.CaptionHeight = 17
            Me.gridManufacturer.CollapseColor = System.Drawing.Color.Black
            Me.gridManufacturer.DataChanged = False
            Me.gridManufacturer.BackColor = System.Drawing.Color.Empty
            Me.gridManufacturer.ExpandColor = System.Drawing.Color.Black
            Me.gridManufacturer.GroupByCaption = "Drag a column header here to group by that column"
            Me.gridManufacturer.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.gridManufacturer.Location = New System.Drawing.Point(8, 24)
            Me.gridManufacturer.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
            Me.gridManufacturer.Name = "gridManufacturer"
            Me.gridManufacturer.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.gridManufacturer.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.gridManufacturer.PreviewInfo.ZoomFactor = 75
            Me.gridManufacturer.PrintInfo.ShowOptionsDialog = False
            Me.gridManufacturer.RecordSelectorWidth = 16
            GridLines1.Color = System.Drawing.Color.DarkGray
            GridLines1.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single
            Me.gridManufacturer.RowDivider = GridLines1
            Me.gridManufacturer.RowHeight = 15
            Me.gridManufacturer.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.gridManufacturer.ScrollTips = False
            Me.gridManufacturer.Size = New System.Drawing.Size(608, 392)
            Me.gridManufacturer.TabIndex = 21
            Me.gridManufacturer.Text = "C1TrueDBGrid1"
            Me.gridManufacturer.PropBag = "<?xml version=""1.0""?><Blob><DataCols><C1DataColumn Level=""0"" Caption=""Bill Code"" " & _
            "DataField=""""><ValueItems /></C1DataColumn><C1DataColumn Level=""0"" Caption=""Probl" & _
            "em Found"" DataField=""""><ValueItems /></C1DataColumn><C1DataColumn Level=""0"" Capt" & _
            "ion=""Repair Action"" DataField=""""><ValueItems /></C1DataColumn><C1DataColumn Leve" & _
            "l=""0"" Caption=""Ref Des"" DataField=""""><ValueItems /></C1DataColumn><C1DataColumn " & _
            "Level=""0"" Caption=""Number"" DataField=""""><ValueItems /></C1DataColumn><C1DataColu" & _
            "mn Level=""0"" Caption=""Failure"" DataField=""""><ValueItems /></C1DataColumn></DataC" & _
            "ols><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrapper""><Data>RecordSelecto" & _
            "r{AlignImage:Center;}Style31{AlignHorz:Near;}Caption{AlignHorz:Center;}Normal{}S" & _
            "elected{ForeColor:HighlightText;BackColor:Highlight;}Editor{}Style18{AlignHorz:N" & _
            "ear;}Style19{AlignHorz:Near;}Style14{AlignHorz:Near;}Style15{AlignHorz:Near;}Sty" & _
            "le16{}Style17{}Style10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style37{}Style" & _
            "34{AlignHorz:Near;}Style35{AlignHorz:Near;}Style32{}Style33{}OddRow{}Footer{}Sty" & _
            "le29{}Style28{}Style27{AlignHorz:Near;}Style26{AlignHorz:Near;}Style25{}Style24{" & _
            "}Style23{AlignHorz:Near;}Style22{AlignHorz:Near;}Style21{}Style20{}Inactive{Fore" & _
            "Color:InactiveCaptionText;BackColor:InactiveCaption;}EvenRow{BackColor:Aqua;}Hea" & _
            "ding{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;" & _
            "BackColor:Control;}Style2{}FilterBar{}Style4{}Style9{}Style8{}Style36{}Style5{}G" & _
            "roup{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style7{}Sty" & _
            "le6{}Style1{}Style30{AlignHorz:Near;}Style3{}HighlightRow{ForeColor:HighlightTex" & _
            "t;BackColor:Highlight;}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Na" & _
            "me="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" Col" & _
            "umnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" De" & _
            "fRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>" & _
            "0, 0, 606, 390</ClientRect><BorderSide>0</BorderSide><CaptionStyle parent=""Style" & _
            "2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle paren" & _
            "t=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><Foo" & _
            "terStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /" & _
            "><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""Highlig" & _
            "htRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle" & _
            " parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""" & _
            "Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal""" & _
            " me=""Style1"" /><internalCols><C1DisplayColumn><HeadingStyle parent=""Style2"" me=""" & _
            "Style14"" /><Style parent=""Style1"" me=""Style15"" /><FooterStyle parent=""Style3"" me" & _
            "=""Style16"" /><EditorStyle parent=""Style5"" me=""Style17"" /><Visible>True</Visible>" & _
            "<ColumnDivider>DarkGray,Single</ColumnDivider><Height>15</Height><DCIdx>0</DCIdx" & _
            "></C1DisplayColumn><C1DisplayColumn><HeadingStyle parent=""Style2"" me=""Style18"" /" & _
            "><Style parent=""Style1"" me=""Style19"" /><FooterStyle parent=""Style3"" me=""Style20""" & _
            " /><EditorStyle parent=""Style5"" me=""Style21"" /><Visible>True</Visible><ColumnDiv" & _
            "ider>DarkGray,Single</ColumnDivider><Height>15</Height><DCIdx>1</DCIdx></C1Displ" & _
            "ayColumn><C1DisplayColumn><HeadingStyle parent=""Style2"" me=""Style22"" /><Style pa" & _
            "rent=""Style1"" me=""Style23"" /><FooterStyle parent=""Style3"" me=""Style24"" /><Editor" & _
            "Style parent=""Style5"" me=""Style25"" /><Visible>True</Visible><ColumnDivider>DarkG" & _
            "ray,Single</ColumnDivider><Height>15</Height><DCIdx>2</DCIdx></C1DisplayColumn><" & _
            "C1DisplayColumn><HeadingStyle parent=""Style2"" me=""Style26"" /><Style parent=""Styl" & _
            "e1"" me=""Style27"" /><FooterStyle parent=""Style3"" me=""Style28"" /><EditorStyle pare" & _
            "nt=""Style5"" me=""Style29"" /><Visible>True</Visible><ColumnDivider>DarkGray,Single" & _
            "</ColumnDivider><Height>15</Height><DCIdx>3</DCIdx></C1DisplayColumn><C1DisplayC" & _
            "olumn><HeadingStyle parent=""Style2"" me=""Style30"" /><Style parent=""Style1"" me=""St" & _
            "yle31"" /><FooterStyle parent=""Style3"" me=""Style32"" /><EditorStyle parent=""Style5" & _
            """ me=""Style33"" /><Visible>True</Visible><ColumnDivider>DarkGray,Single</ColumnDi" & _
            "vider><Height>15</Height><DCIdx>4</DCIdx></C1DisplayColumn><C1DisplayColumn><Hea" & _
            "dingStyle parent=""Style2"" me=""Style34"" /><Style parent=""Style1"" me=""Style35"" /><" & _
            "FooterStyle parent=""Style3"" me=""Style36"" /><EditorStyle parent=""Style5"" me=""Styl" & _
            "e37"" /><Visible>True</Visible><ColumnDivider>DarkGray,Single</ColumnDivider><Hei" & _
            "ght>15</Height><DCIdx>5</DCIdx></C1DisplayColumn></internalCols></C1.Win.C1TrueD" & _
            "BGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style pare" & _
            "nt=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""" & _
            "Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""N" & _
            "ormal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Norma" & _
            "l"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Norm" & _
            "al"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""N" & _
            "ormal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vert" & _
            "Splits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Default" & _
            "RecSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 606, 390</ClientArea></Blob" & _
            ">"
            '
            'tbCustomer
            '
            Me.tbCustomer.Controls.AddRange(New System.Windows.Forms.Control() {Me.glCustomer, Me.gridCustomer})
            Me.tbCustomer.Location = New System.Drawing.Point(4, 22)
            Me.tbCustomer.Name = "tbCustomer"
            Me.tbCustomer.Size = New System.Drawing.Size(632, 422)
            Me.tbCustomer.TabIndex = 0
            Me.tbCustomer.Text = "Customer"
            '
            'glCustomer
            '
            Me.glCustomer.BackColor = System.Drawing.Color.SteelBlue
            Me.glCustomer.ForeColor = System.Drawing.Color.White
            Me.glCustomer.Location = New System.Drawing.Point(8, 8)
            Me.glCustomer.Name = "glCustomer"
            Me.glCustomer.Size = New System.Drawing.Size(608, 16)
            Me.glCustomer.TabIndex = 21
            Me.glCustomer.Text = "Customer"
            '
            'gridCustomer
            '
            Me.gridCustomer.AllowFilter = True
            Me.gridCustomer.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
            Me.gridCustomer.AllowSort = True
            Me.gridCustomer.AlternatingRows = True
            Me.gridCustomer.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.gridCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.gridCustomer.CaptionHeight = 17
            Me.gridCustomer.CollapseColor = System.Drawing.Color.Black
            Me.gridCustomer.DataChanged = False
            Me.gridCustomer.BackColor = System.Drawing.Color.Empty
            Me.gridCustomer.ExpandColor = System.Drawing.Color.Black
            Me.gridCustomer.GroupByCaption = "Drag a column header here to group by that column"
            Me.gridCustomer.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.gridCustomer.Location = New System.Drawing.Point(8, 24)
            Me.gridCustomer.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
            Me.gridCustomer.Name = "gridCustomer"
            Me.gridCustomer.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.gridCustomer.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.gridCustomer.PreviewInfo.ZoomFactor = 75
            Me.gridCustomer.PrintInfo.ShowOptionsDialog = False
            Me.gridCustomer.RecordSelectorWidth = 16
            GridLines2.Color = System.Drawing.Color.DarkGray
            GridLines2.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single
            Me.gridCustomer.RowDivider = GridLines2
            Me.gridCustomer.RowHeight = 15
            Me.gridCustomer.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.gridCustomer.ScrollTips = False
            Me.gridCustomer.Size = New System.Drawing.Size(608, 392)
            Me.gridCustomer.TabIndex = 20
            Me.gridCustomer.Text = "C1TrueDBGrid1"
            Me.gridCustomer.PropBag = "<?xml version=""1.0""?><Blob><DataCols><C1DataColumn Level=""0"" Caption=""Bill Code"" " & _
            "DataField=""""><ValueItems /></C1DataColumn><C1DataColumn Level=""0"" Caption=""Probl" & _
            "em Found"" DataField=""""><ValueItems /></C1DataColumn><C1DataColumn Level=""0"" Capt" & _
            "ion=""Repair Action"" DataField=""""><ValueItems /></C1DataColumn><C1DataColumn Leve" & _
            "l=""0"" Caption=""Ref Des"" DataField=""""><ValueItems /></C1DataColumn><C1DataColumn " & _
            "Level=""0"" Caption=""Number"" DataField=""""><ValueItems /></C1DataColumn><C1DataColu" & _
            "mn Level=""0"" Caption=""Failure"" DataField=""""><ValueItems /></C1DataColumn></DataC" & _
            "ols><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrapper""><Data>Caption{Align" & _
            "Horz:Center;}Style27{AlignHorz:Near;}Normal{}Style25{}Style24{}Editor{}Style18{A" & _
            "lignHorz:Near;}Style19{AlignHorz:Near;}Style14{AlignHorz:Near;}Style15{AlignHorz" & _
            ":Near;}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{}Style13{}Style" & _
            "12{}Style29{}Style28{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}" & _
            "Style26{AlignHorz:Near;}RecordSelector{AlignImage:Center;}Footer{}Style23{AlignH" & _
            "orz:Near;}Style22{AlignHorz:Near;}Style21{}Style20{}Group{AlignVert:Center;Borde" & _
            "r:None,,0, 0, 0, 0;BackColor:ControlDark;}Inactive{ForeColor:InactiveCaptionText" & _
            ";BackColor:InactiveCaption;}EvenRow{BackColor:Aqua;}Heading{Wrap:True;BackColor:" & _
            "Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style3" & _
            "{}Style5{}Style7{}Style6{}FilterBar{}Selected{ForeColor:HighlightText;BackColor:" & _
            "Highlight;}Style4{}Style9{}Style8{}Style1{}Style36{}Style37{}Style34{AlignHorz:N" & _
            "ear;}Style35{AlignHorz:Near;}Style32{}Style33{}Style30{AlignHorz:Near;}Style31{A" & _
            "lignHorz:Near;}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Na" & _
            "me="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" Col" & _
            "umnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" De" & _
            "fRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>" & _
            "0, 0, 606, 390</ClientRect><BorderSide>0</BorderSide><CaptionStyle parent=""Style" & _
            "2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle paren" & _
            "t=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><Foo" & _
            "terStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /" & _
            "><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""Highlig" & _
            "htRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle" & _
            " parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""" & _
            "Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal""" & _
            " me=""Style1"" /><internalCols><C1DisplayColumn><HeadingStyle parent=""Style2"" me=""" & _
            "Style14"" /><Style parent=""Style1"" me=""Style15"" /><FooterStyle parent=""Style3"" me" & _
            "=""Style16"" /><EditorStyle parent=""Style5"" me=""Style17"" /><Visible>True</Visible>" & _
            "<ColumnDivider>DarkGray,Single</ColumnDivider><Height>15</Height><DCIdx>0</DCIdx" & _
            "></C1DisplayColumn><C1DisplayColumn><HeadingStyle parent=""Style2"" me=""Style18"" /" & _
            "><Style parent=""Style1"" me=""Style19"" /><FooterStyle parent=""Style3"" me=""Style20""" & _
            " /><EditorStyle parent=""Style5"" me=""Style21"" /><Visible>True</Visible><ColumnDiv" & _
            "ider>DarkGray,Single</ColumnDivider><Height>15</Height><DCIdx>1</DCIdx></C1Displ" & _
            "ayColumn><C1DisplayColumn><HeadingStyle parent=""Style2"" me=""Style22"" /><Style pa" & _
            "rent=""Style1"" me=""Style23"" /><FooterStyle parent=""Style3"" me=""Style24"" /><Editor" & _
            "Style parent=""Style5"" me=""Style25"" /><Visible>True</Visible><ColumnDivider>DarkG" & _
            "ray,Single</ColumnDivider><Height>15</Height><DCIdx>2</DCIdx></C1DisplayColumn><" & _
            "C1DisplayColumn><HeadingStyle parent=""Style2"" me=""Style26"" /><Style parent=""Styl" & _
            "e1"" me=""Style27"" /><FooterStyle parent=""Style3"" me=""Style28"" /><EditorStyle pare" & _
            "nt=""Style5"" me=""Style29"" /><Visible>True</Visible><ColumnDivider>DarkGray,Single" & _
            "</ColumnDivider><Height>15</Height><DCIdx>3</DCIdx></C1DisplayColumn><C1DisplayC" & _
            "olumn><HeadingStyle parent=""Style2"" me=""Style30"" /><Style parent=""Style1"" me=""St" & _
            "yle31"" /><FooterStyle parent=""Style3"" me=""Style32"" /><EditorStyle parent=""Style5" & _
            """ me=""Style33"" /><Visible>True</Visible><ColumnDivider>DarkGray,Single</ColumnDi" & _
            "vider><Height>15</Height><DCIdx>4</DCIdx></C1DisplayColumn><C1DisplayColumn><Hea" & _
            "dingStyle parent=""Style2"" me=""Style34"" /><Style parent=""Style1"" me=""Style35"" /><" & _
            "FooterStyle parent=""Style3"" me=""Style36"" /><EditorStyle parent=""Style5"" me=""Styl" & _
            "e37"" /><Visible>True</Visible><ColumnDivider>DarkGray,Single</ColumnDivider><Hei" & _
            "ght>15</Height><DCIdx>5</DCIdx></C1DisplayColumn></internalCols></C1.Win.C1TrueD" & _
            "BGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style pare" & _
            "nt=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""" & _
            "Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""N" & _
            "ormal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Norma" & _
            "l"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Norm" & _
            "al"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""N" & _
            "ormal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vert" & _
            "Splits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Default" & _
            "RecSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 606, 390</ClientArea></Blob" & _
            ">"
            '
            'pnlAddUpdateDelete
            '
            Me.pnlAddUpdateDelete.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlAddUpdateDelete.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtNumber, Me.cboFailure, Me.cboRefDes, Me.cboRepairAction, Me.cboProblemFound, Me.cboBillCode, Me.lblFailure, Me.lblNumber, Me.lblRefDes, Me.lblRepairAction, Me.lblProblemFound, Me.lblBillCode, Me.btnSave, Me.btnCancel})
            Me.pnlAddUpdateDelete.Location = New System.Drawing.Point(8, 168)
            Me.pnlAddUpdateDelete.Name = "pnlAddUpdateDelete"
            Me.pnlAddUpdateDelete.Size = New System.Drawing.Size(184, 288)
            Me.pnlAddUpdateDelete.TabIndex = 1
            '
            'txtNumber
            '
            Me.txtNumber.Location = New System.Drawing.Point(8, 184)
            Me.txtNumber.Name = "txtNumber"
            Me.txtNumber.Size = New System.Drawing.Size(56, 20)
            Me.txtNumber.TabIndex = 5
            Me.txtNumber.Text = ""
            '
            'cboFailure
            '
            Me.cboFailure.Location = New System.Drawing.Point(8, 224)
            Me.cboFailure.Name = "cboFailure"
            Me.cboFailure.Size = New System.Drawing.Size(168, 21)
            Me.cboFailure.TabIndex = 6
            '
            'cboRefDes
            '
            Me.cboRefDes.Location = New System.Drawing.Point(8, 144)
            Me.cboRefDes.Name = "cboRefDes"
            Me.cboRefDes.Size = New System.Drawing.Size(168, 21)
            Me.cboRefDes.TabIndex = 4
            '
            'cboRepairAction
            '
            Me.cboRepairAction.Location = New System.Drawing.Point(8, 104)
            Me.cboRepairAction.Name = "cboRepairAction"
            Me.cboRepairAction.Size = New System.Drawing.Size(168, 21)
            Me.cboRepairAction.TabIndex = 3
            '
            'cboProblemFound
            '
            Me.cboProblemFound.Location = New System.Drawing.Point(8, 64)
            Me.cboProblemFound.Name = "cboProblemFound"
            Me.cboProblemFound.Size = New System.Drawing.Size(168, 21)
            Me.cboProblemFound.TabIndex = 2
            '
            'cboBillCode
            '
            Me.cboBillCode.Location = New System.Drawing.Point(8, 24)
            Me.cboBillCode.Name = "cboBillCode"
            Me.cboBillCode.Size = New System.Drawing.Size(168, 21)
            Me.cboBillCode.TabIndex = 1
            '
            'lblFailure
            '
            Me.lblFailure.Location = New System.Drawing.Point(8, 208)
            Me.lblFailure.Name = "lblFailure"
            Me.lblFailure.Size = New System.Drawing.Size(88, 16)
            Me.lblFailure.TabIndex = 8
            Me.lblFailure.Text = "Failure:"
            Me.lblFailure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblNumber
            '
            Me.lblNumber.Location = New System.Drawing.Point(8, 168)
            Me.lblNumber.Name = "lblNumber"
            Me.lblNumber.Size = New System.Drawing.Size(88, 16)
            Me.lblNumber.TabIndex = 7
            Me.lblNumber.Text = "Number:"
            Me.lblNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblRefDes
            '
            Me.lblRefDes.Location = New System.Drawing.Point(8, 128)
            Me.lblRefDes.Name = "lblRefDes"
            Me.lblRefDes.Size = New System.Drawing.Size(88, 16)
            Me.lblRefDes.TabIndex = 6
            Me.lblRefDes.Text = "Ref Des:"
            Me.lblRefDes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblRepairAction
            '
            Me.lblRepairAction.Location = New System.Drawing.Point(8, 88)
            Me.lblRepairAction.Name = "lblRepairAction"
            Me.lblRepairAction.Size = New System.Drawing.Size(88, 16)
            Me.lblRepairAction.TabIndex = 5
            Me.lblRepairAction.Text = "Repair Action:"
            Me.lblRepairAction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblProblemFound
            '
            Me.lblProblemFound.Location = New System.Drawing.Point(8, 48)
            Me.lblProblemFound.Name = "lblProblemFound"
            Me.lblProblemFound.Size = New System.Drawing.Size(88, 16)
            Me.lblProblemFound.TabIndex = 4
            Me.lblProblemFound.Text = "Problem Found:"
            Me.lblProblemFound.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblBillCode
            '
            Me.lblBillCode.Location = New System.Drawing.Point(8, 8)
            Me.lblBillCode.Name = "lblBillCode"
            Me.lblBillCode.Size = New System.Drawing.Size(88, 16)
            Me.lblBillCode.TabIndex = 3
            Me.lblBillCode.Text = "Bill Code:"
            Me.lblBillCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnSave
            '
            Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnSave.Location = New System.Drawing.Point(8, 256)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.TabIndex = 7
            Me.btnSave.Text = "Save"
            '
            'btnCancel
            '
            Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCancel.Location = New System.Drawing.Point(96, 256)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.TabIndex = 8
            Me.btnCancel.Text = "Cancel"
            '
            'frmNewTechData
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(848, 461)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1, Me.cboModel, Me.cboCustomer, Me.btnClear, Me.btnAdd, Me.lblModel, Me.lblCustomer, Me.pnlAddUpdateDelete})
            Me.Name = "frmNewTechData"
            Me.Text = "frmNewTechData"
            Me.TabControl1.ResumeLayout(False)
            Me.tbManufModel.ResumeLayout(False)
            CType(Me.gridManufacturer, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tbCustomer.ResumeLayout(False)
            CType(Me.gridCustomer, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlAddUpdateDelete.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private mModelID As Int32 = 0
        Private mManufID As Int32 = 0
        Private mCustID As Int32 = 0

        Private dtBillCodes As DataTable
        Private dtCustomer As DataTable
        Private dtModel As DataTable
        Private dtProblemFound As DataTable
        Private dtRepairAction As DataTable
        Private dtRefDes As DataTable
        Private dtFailure As DataTable


        Private myDataRow As DataRow

        Private dtMDcustomer As DataTable
        Private dtMDmodel As DataTable

        Private connObj As PSS.Data.Production.Joins
        Private strSQL As String

        Private myDataColumn As DataColumn
        'Private myDataRow As DataRow

        Private vActiveBillCode As Long = 0
        Private vActiveCustomer As Long = 0
        Private vActiveType As String
        Private vMC As String
        Private vBillID As Long


        Private Sub frmNewTechData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            popComboBoxes()
            makeCustomerDatatable()
            makeManufDataTable()
            pnlAddUpdateDelete.Visible = False

        End Sub

#Region "LOAD DATATABLES"
        Private Sub popComboBoxes()

            Dim dt As DataTable

            '// Loading Customer Listing
            Try
                dtCustomer.Clear()
            Catch ex As Exception
            End Try
            strSQL = "select tcustomer.cust_id, tcustomer.cust_name1 from " & _
                     "tcustomer inner join tcusttoprice on tcustomer.cust_id = tcusttoprice.cust_id " & _
                     "where(tcusttoprice.prod_id = 2) and tcustomer.cust_name2 is null order by cust_name1"
            dt = connObj.OrderEntrySelect(strSQL)

            cboCustomer.DataSource = dt
            cboCustomer.DisplayMember = dt.Columns("Cust_Name1").ToString
            cboCustomer.ValueMember = dt.Columns("Cust_ID").ToString
            cboCustomer.Text = ""
            dtCustomer = dt
            '// Loading Customer Listing

            '// Loading Model Listing
            Try
                dtModel.Clear()
            Catch ex As Exception
            End Try
            strSQL = "Select tmodel.model_id, tmodel.model_desc, lmanuf.manuf_id, lmanuf.manuf_desc from " & _
                     "tmodel inner join lmanuf on tmodel.manuf_id = lmanuf.manuf_id " & _
                     "where(tmodel.prod_id = 2) order by tmodel.model_desc"
            dt = connObj.OrderEntrySelect(strSQL)

            cboModel.DataSource = dt
            cboModel.DisplayMember = dt.Columns("Model_Desc").ToString
            cboModel.ValueMember = dt.Columns("Model_ID").ToString
            cboModel.Text = ""
            dtModel = dt
            '// Loading Model Listing

            dt = Nothing

        End Sub
        Private Sub fillDataTables()

            '//Problem Found
            strSQL = "select dcode_id, dcode_sdesc, dcode_ldesc from lcodesdetail " & _
                     "where mcode_id = 9 and dcode_inactive=0 and manuf_id = " & mManufID
            dtProblemFound = connObj.OrderEntrySelect(strSQL)

            '//Repair Action
            strSQL = "select dcode_id, dcode_sdesc, dcode_ldesc from lcodesdetail " & _
                     "where mcode_id = 3 and dcode_inactive=0 and manuf_id = " & mManufID
            dtRepairAction = connObj.OrderEntrySelect(strSQL)
            '//Reference Designator
            strSQL = "select dcode_id, dcode_sdesc, dcode_ldesc from lcodesdetail " & _
                     "where mcode_id = 11 and dcode_inactive=0 and manuf_id = " & mManufID
            dtRefDes = connObj.OrderEntrySelect(strSQL)
            '//Failure
            strSQL = "select dcode_id, dcode_sdesc, dcode_ldesc from lcodesdetail " & _
                     "where mcode_id = 4 and dcode_inactive=0 and manuf_id = " & mManufID
            dtFailure = connObj.OrderEntrySelect(strSQL)

        End Sub
#End Region

#Region "ASSIGN mID VALUES"
        Private Sub DisplayIDvalues()
            Dim str As String
            str += "Customer ID = " & mCustID & vbCrLf
            str += "Model ID = " & mModelID & vbCrLf
            str += "Manufacturer ID = " & mManufID & vbCrLf
            MsgBox(str)
        End Sub
        Private Sub assignCustID()
            mCustID = cboCustomer.SelectedValue
            If mCustID > 0 And mModelID > 0 Then
                getMDcustomer()
            End If
            'DisplayIDvalues()
        End Sub
        Private Sub assignModelID()
            mModelID = cboModel.SelectedValue

            Dim x As Integer = 0
            Dim r As DataRow
            For x = 0 To dtModel.Rows.Count - 1
                r = dtModel.Rows(x)
                If r("Model_ID") = mModelID Then
                    mManufID = r("Manuf_ID")
                    Exit For
                End If
            Next
            fillDataTables()
            getMDmanufacturer()
            If mModelID > 0 Then make_dtBillCodes()
            If mManufID > 0 Then
                make_dtProblemFound()
                make_dtRepairAction()
                make_dtRefDes()
                make_dtFailure()
            End If
            'DisplayIDvalues()
        End Sub
        Private Sub cboCustomer_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomer.SelectionChangeCommitted
            assignCustID()
        End Sub
        Private Sub cboCustomer_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomer.Leave
            assignCustID()
        End Sub
        Private Sub cboModel_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboModel.SelectionChangeCommitted
            assignModelID()
        End Sub
        Private Sub cboModel_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboModel.Leave
            assignModelID()
        End Sub
#End Region

        Private Sub getMDmanufacturer()

            Try
                dtMDmodel.Clear()
            Catch ex As Exception
            End Try

            If mManufID > 0 Then

                Dim dtDCode As DataTable = PSS.Data.Production.Joins.OrderEntrySelect("SELECT * FROM lcodesdetail")
                Dim dtData As DataTable = PSS.Data.Production.Joins.OrderEntrySelect("SELECT twrtymap.*, lbillcodes.billcode_desc FROM (twrtymap inner join lbillcodes on twrtymap.billcode_id = lbillcodes.billcode_id) WHERE Model_ID = " & mModelID & " ORDER BY lbillcodes.billcode_desc")

                Dim rCode, rData As DataRow
                Dim xCode, xData As Integer

                Me.gridManufacturer.Splits(0).DisplayColumns(0).Width = 100
                Me.gridManufacturer.Splits(0).DisplayColumns(1).Width = 180
                Me.gridManufacturer.Splits(0).DisplayColumns(2).Width = 120
                Me.gridManufacturer.Splits(0).DisplayColumns(3).Width = 50
                Me.gridManufacturer.Splits(0).DisplayColumns(4).Width = 80
                Me.gridManufacturer.Splits(0).DisplayColumns(5).Width = 200
                Me.gridManufacturer.Splits(0).DisplayColumns(6).Width = 200

                For xData = 0 To dtData.Rows.Count - 1

                    myDataRow = dtMDmodel.NewRow()
                    rData = dtData.Rows(xData)

                    myDataRow("Bill ID") = rData("BillCode_ID")
                    myDataRow("Bill Desc") = rData("BillCode_Desc")
                    myDataRow("Number") = rData("WMap_RefDesNumb")

                    '//Get Problem Found
                    For xCode = 0 To dtDCode.Rows.Count - 1
                        rCode = dtDCode.Rows(xCode)
                        If rCode("Dcode_ID") = rData("WMap_ProblemFound") Then
                            myDataRow("ProblemFound") = rCode("Dcode_LDesc")
                            Exit For
                        End If
                    Next
                    '//Get Repair Action
                    For xCode = 0 To dtDCode.Rows.Count - 1
                        rCode = dtDCode.Rows(xCode)
                        If rCode("Dcode_ID") = rData("WMap_RepairAction") Then
                            myDataRow("RepairAction") = rCode("Dcode_LDesc")
                            Exit For
                        End If
                    Next
                    '//Get Reference Designator
                    For xCode = 0 To dtDCode.Rows.Count - 1
                        rCode = dtDCode.Rows(xCode)
                        If IsDBNull(rData("WMap_RefDes")) = False Then
                            If rCode("Dcode_ID") = rData("WMap_RefDes") Then
                                myDataRow("Ref Des") = rCode("Dcode_LDesc")
                                Exit For
                            End If
                        End If
                    Next
                    '//Get Failure Code
                    For xCode = 0 To dtDCode.Rows.Count - 1
                        rCode = dtDCode.Rows(xCode)
                        If IsDBNull(rData("WMap_Failure")) = False Then
                            If rCode("Dcode_ID") = rData("WMap_Failure") Then
                                myDataRow("Failure") = rCode("Dcode_LDesc")
                                Exit For
                            End If
                        End If
                    Next
                    dtMDmodel.Rows.Add(myDataRow)
                Next

            End If

        End Sub

        Private Sub getMDcustomer()

            Try
                dtMDcustomer.Clear()
            Catch ex As Exception
            End Try

            If mCustID > 0 And mModelID > 0 And mManufID > 0 Then

                Dim dtDCode As DataTable = PSS.Data.Production.Joins.OrderEntrySelect("SELECT * FROM lcodesdetail")
                Dim dtData As DataTable = PSS.Data.Production.Joins.OrderEntrySelect("SELECT tbillmap.*, lbillcodes.billcode_desc FROM (tbillmap inner join lbillcodes on tbillmap.billcode_id = lbillcodes.billcode_id) WHERE Model_ID = " & mModelID & " AND Cust_ID = " & mCustID & " ORDER BY lbillcodes.billcode_desc")

                Dim rCode, rData As DataRow
                Dim xCode, xData As Integer

                Me.gridCustomer.Splits(0).DisplayColumns(0).Width = 0
                Me.gridCustomer.Splits(0).DisplayColumns(1).Width = 180
                Me.gridCustomer.Splits(0).DisplayColumns(2).Width = 120
                Me.gridCustomer.Splits(0).DisplayColumns(3).Width = 50
                Me.gridCustomer.Splits(0).DisplayColumns(4).Width = 80
                Me.gridCustomer.Splits(0).DisplayColumns(5).Width = 200
                Me.gridCustomer.Splits(0).DisplayColumns(6).Width = 200

                For xData = 0 To dtData.Rows.Count - 1

                    myDataRow = dtMDcustomer.NewRow()
                    rData = dtData.Rows(xData)

                    myDataRow("Bill ID") = rData("BillCode_ID")
                    myDataRow("Bill Desc") = rData("BillCode_Desc")
                    myDataRow("Number") = rData("BMap_RefDesNumb")

                    '//Get Problem Found
                    For xCode = 0 To dtDCode.Rows.Count - 1
                        rCode = dtDCode.Rows(xCode)
                        If rCode("Dcode_ID") = rData("BMap_ProblemFound") Then
                            myDataRow("ProblemFound") = rCode("Dcode_LDesc")
                            Exit For
                        End If
                    Next
                    '//Get Repair Action
                    For xCode = 0 To dtDCode.Rows.Count - 1
                        rCode = dtDCode.Rows(xCode)
                        If rCode("Dcode_ID") = rData("BMap_RepairAction") Then
                            myDataRow("RepairAction") = rCode("Dcode_LDesc")
                            Exit For
                        End If
                    Next
                    '//Get Reference Designator
                    For xCode = 0 To dtDCode.Rows.Count - 1
                        rCode = dtDCode.Rows(xCode)
                        If IsDBNull(rData("BMap_RefDes")) = False Then
                            If rCode("Dcode_ID") = rData("BMap_RefDes") Then
                                myDataRow("Ref Des") = rCode("Dcode_LDesc")
                                Exit For
                            End If
                        End If
                    Next
                    '//Get Failure Code
                    For xCode = 0 To dtDCode.Rows.Count - 1
                        rCode = dtDCode.Rows(xCode)
                        If IsDBNull(rData("BMap_Failure")) = False Then
                            If rCode("Dcode_ID") = rData("BMap_Failure") Then
                                myDataRow("Failure") = rCode("Dcode_LDesc")
                                Exit For
                            End If
                        End If
                    Next
                    dtMDcustomer.Rows.Add(myDataRow)
                Next

            End If

        End Sub

        Private Sub makeCustomerDatatable()

            dtMDcustomer = New DataTable("Customer")
            myDataColumn = New DataColumn()
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "Bill ID"
            dtMDcustomer.Columns.Add(myDataColumn)
            myDataColumn = New DataColumn()
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "Bill Desc"
            dtMDcustomer.Columns.Add(myDataColumn)
            myDataColumn = New DataColumn()
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "Ref Des"
            dtMDcustomer.Columns.Add(myDataColumn)
            myDataColumn = New DataColumn()
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "Number"
            dtMDcustomer.Columns.Add(myDataColumn)
            myDataColumn = New DataColumn()
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "Failure"
            dtMDcustomer.Columns.Add(myDataColumn)
            myDataColumn = New DataColumn()
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "ProblemFound"
            dtMDcustomer.Columns.Add(myDataColumn)
            myDataColumn = New DataColumn()
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "RepairAction"
            dtMDcustomer.Columns.Add(myDataColumn)

            gridCustomer.DataSource = dtMDcustomer

        End Sub

        Private Sub makeManufDataTable()

            dtMDmodel = New DataTable("Manufacturer")
            myDataColumn = New DataColumn()
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "Bill ID"
            dtMDmodel.Columns.Add(myDataColumn)
            myDataColumn = New DataColumn()
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "Bill Desc"
            dtMDmodel.Columns.Add(myDataColumn)
            myDataColumn = New DataColumn()
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "Ref Des"
            dtMDmodel.Columns.Add(myDataColumn)
            myDataColumn = New DataColumn()
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "Number"
            dtMDmodel.Columns.Add(myDataColumn)
            myDataColumn = New DataColumn()
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "Failure"
            dtMDmodel.Columns.Add(myDataColumn)
            myDataColumn = New DataColumn()
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "ProblemFound"
            dtMDmodel.Columns.Add(myDataColumn)
            myDataColumn = New DataColumn()
            myDataColumn.DataType = System.Type.GetType("System.String")
            myDataColumn.ColumnName = "RepairAction"
            dtMDmodel.Columns.Add(myDataColumn)

            gridManufacturer.DataSource = dtMDmodel

        End Sub


        Private Sub make_dtBillCodes()
            Dim strSQL As String = "SELECT lbillcodes.* FROM tpsmap INNER JOIN lbillcodes ON tpsmap.billcode_id = lbillcodes.billcode_id WHERE tpsmap.model_id = " & mModelID & " ORDER BY lbillcodes.billcode_desc"
            dtBillCodes = PSS.Data.Production.Joins.OrderEntrySelect(strSQL)
        End Sub

        Private Sub make_dtProblemFound()
            Dim strSQL As String = "SELECT * FROM lcodesdetail WHERE MCode_ID = 9 AND Manuf_ID = " & mManufID
            dtProblemFound = PSS.Data.Production.Joins.OrderEntrySelect(strSQL)
        End Sub

        Private Sub make_dtRepairAction()
            Dim strSQL As String = "SELECT * FROM lcodesdetail WHERE MCode_ID = 3 AND Manuf_ID = " & mManufID
            dtRepairAction = PSS.Data.Production.Joins.OrderEntrySelect(strSQL)
        End Sub

        Private Sub make_dtRefDes()
            Dim strSQL As String = "SELECT * FROM lcodesdetail WHERE MCode_ID = 11 AND Manuf_ID = " & mManufID
            dtRefDes = PSS.Data.Production.Joins.OrderEntrySelect(strSQL)
        End Sub

        Private Sub make_dtFailure()
            Dim strSQL As String = "SELECT * FROM lcodesdetail WHERE MCode_ID = 4 AND Manuf_ID = " & mManufID
            dtFailure = PSS.Data.Production.Joins.OrderEntrySelect(strSQL)
        End Sub

        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click

            Try
                dtMDmodel.Clear()
            Catch ex As Exception
            End Try
            Try
                dtMDcustomer.Clear()
            Catch ex As Exception
            End Try
            cboCustomer.Text = ""
            cboModel.Text = ""
            cboModel.Focus()

        End Sub

        Private Sub cboCustomer_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomer.Enter
            If mManufID < 1 Then
                MsgBox("Please select a model before proceeding.", MsgBoxStyle.OKOnly)
                cboModel.Focus()
            End If
        End Sub

        Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click


            pnlAddUpdateDelete.Visible = True

            cboBillCode.DataSource = dtBillCodes
            cboBillCode.DisplayMember = dtBillCodes.Columns("BillCode_Desc").ToString
            cboBillCode.ValueMember = dtBillCodes.Columns("BillCode_ID").ToString
            cboBillCode.Text = ""

            cboProblemFound.DataSource = dtProblemFound
            cboProblemFound.DisplayMember = dtProblemFound.Columns("Dcode_LDesc").ToString
            cboProblemFound.ValueMember = dtProblemFound.Columns("Dcode_ID").ToString
            cboProblemFound.Text = ""

            cboRepairAction.DataSource = dtRepairAction
            cboRepairAction.DisplayMember = dtRepairAction.Columns("Dcode_LDesc").ToString
            cboRepairAction.ValueMember = dtRepairAction.Columns("Dcode_ID").ToString
            cboRepairAction.Text = ""

            cboRefDes.DataSource = dtRefDes
            cboRefDes.DisplayMember = dtRefDes.Columns("Dcode_LDesc").ToString
            cboRefDes.ValueMember = dtRefDes.Columns("Dcode_ID").ToString
            cboRefDes.Text = ""

            cboFailure.DataSource = dtFailure
            cboFailure.DisplayMember = dtFailure.Columns("Dcode_LDesc").ToString
            cboFailure.ValueMember = dtFailure.Columns("Dcode_ID").ToString
            cboFailure.Text = ""

            If Me.TabControl1.SelectedIndex = 0 Then
                vActiveType = "INSERT"
                vMC = "M"
            ElseIf Me.TabControl1.SelectedIndex = 1 Then
                vActiveType = "INSERT"
                vMC = "C"
            End If

            cboBillCode.Focus()

        End Sub

        Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

            Dim vSave As Boolean = False

            If vActiveType = "UPDATE" Then
                If vMC = "M" Then
                    If mModelID = 0 Then
                        MsgBox("Can Not Save", MsgBoxStyle.OKOnly, "ERROR")
                        Exit Sub
                    End If

                    '//Verify all data has been selected
                    Dim strErr As String = ""
                    If cboBillCode.SelectedValue < 1 Then strErr += "No BillCode." & vbCrLf
                    If cboRefDes.SelectedValue < 1 Then strErr += "No Ref Des Code." & vbCrLf
                    If cboFailure.SelectedValue < 1 Then strErr += "No Failure Code." & vbCrLf
                    If cboProblemFound.SelectedValue < 1 Then strErr += "No Problem Found Code." & vbCrLf
                    If cboRepairAction.SelectedValue < 1 Then strErr += "No Repair Action Code." & vbCrLf
                    If Len(Trim(strErr)) > 0 Then
                        MsgBox(strErr, MsgBoxStyle.OKOnly, "ERROR")
                        Exit Sub
                    End If

                    '//perform update
                    Try
                        Dim strSQL As String

                        If Len(Trim(txtNumber.Text)) < 1 Then
                            strSQL = "UPDATE twrtymap SET wmap_ProblemFound = " & cboProblemFound.SelectedValue & ", wmap_RepairAction = " & cboRepairAction.SelectedValue & ", wmap_RefDes = " & cboRefDes.SelectedValue & ", wmap_Failure = " & cboFailure.SelectedValue & " WHERE model_id = " & mModelID & " AND billcode_id = " & vBillID
                        Else
                            strSQL = "UPDATE twrtymap SET wmap_ProblemFound = " & cboProblemFound.SelectedValue & ", wmap_RepairAction = " & cboRepairAction.SelectedValue & ", wmap_RefDes = " & cboRefDes.SelectedValue & ", wmap_RefDesNumb = '" & txtNumber.Text & "', wmap_Failure = " & cboFailure.SelectedValue & " WHERE model_id = " & mModelID & " AND billcode_id = " & vBillID
                        End If
                        Dim dt As Boolean = PSS.Data.Production.Joins.OrderEntryUpdateDelete(strSQL)
                    Catch ex As Exception
                        MsgBox("The record could not be updated.", MsgBoxStyle.OKOnly, "ERROR")
                    End Try

                    cboBillCode.Enabled = True
                    cboBillCode.Text = ""
                    cboProblemFound.Text = ""
                    cboRepairAction.Text = ""
                    cboFailure.Text = ""
                    cboRefDes.Text = ""
                    txtNumber.Text = ""
                    Me.pnlAddUpdateDelete.Visible = False

                    getMDmanufacturer()
                    gridManufacturer.DataSource = dtMDmodel

                ElseIf vMC = "C" Then

                    If mModelID = 0 Or mCustID = 0 Then
                        MsgBox("Can Not Save", MsgBoxStyle.OKOnly, "ERROR")
                        Exit Sub
                    End If

                    '//Verify all data has been selected
                    Dim strErr As String = ""
                    If cboBillCode.SelectedValue < 1 Then strErr += "No BillCode." & vbCrLf
                    If cboRefDes.SelectedValue < 1 Then strErr += "No Ref Des Code." & vbCrLf
                    If cboFailure.SelectedValue < 1 Then strErr += "No Failure Code." & vbCrLf
                    If cboProblemFound.SelectedValue < 1 Then strErr += "No Problem Found Code." & vbCrLf
                    If cboRepairAction.SelectedValue < 1 Then strErr += "No Repair Action Code." & vbCrLf
                    If Len(Trim(strErr)) > 0 Then
                        MsgBox(strErr, MsgBoxStyle.OKOnly, "ERROR")
                        Exit Sub
                    End If

                    '//perform update
                    Try
                        Dim strSQL As String
                        If Len(Trim(txtNumber.Text)) < 1 Then
                            strSQL = "UPDATE tbillmap SET bmap_ProblemFound = " & cboProblemFound.SelectedValue & ", bmap_RepairAction = " & cboRepairAction.SelectedValue & ", bmap_RefDes = " & cboRefDes.SelectedValue & ", bmap_Failure = " & cboFailure.SelectedValue & " WHERE model_id = " & mModelID & " AND cust_id = " & mCustID & " AND billcode_id = " & vBillID
                        Else
                            strSQL = "UPDATE tbillmap SET bmap_ProblemFound = " & cboProblemFound.SelectedValue & ", bmap_RepairAction = " & cboRepairAction.SelectedValue & ", bmap_RefDes = " & cboRefDes.SelectedValue & ", bmap_RefDesNumb = '" & txtNumber.Text & "', bmap_Failure = " & cboFailure.SelectedValue & " WHERE model_id = " & mModelID & " AND cust_id = " & mCustID & " AND billcode_id = " & vBillID
                        End If
                        Dim dt As Boolean = PSS.Data.Production.Joins.OrderEntryUpdateDelete(strSQL)
                    Catch ex As Exception
                        MsgBox("The record could not be updated.", MsgBoxStyle.OKOnly, "ERROR")
                    End Try

                    cboBillCode.Enabled = True
                    cboBillCode.Text = ""
                    cboProblemFound.Text = ""
                    cboRepairAction.Text = ""
                    cboFailure.Text = ""
                    cboRefDes.Text = ""
                    txtNumber.Text = ""
                    Me.pnlAddUpdateDelete.Visible = False
                    getMDcustomer()

                End If

            ElseIf vActiveType = "INSERT" Then


                If vMC = "M" Then
                    If mModelID = 0 Then
                        MsgBox("Can Not Save", MsgBoxStyle.OKOnly, "ERROR")
                        Exit Sub
                    End If

                    '//Verify not in table
                    Dim strSQLcheck As String = "SELECT * FROM twrtymap WHERE model_id = " & mModelID & " AND billcode_id = " & cboBillCode.SelectedValue
                    Dim dtCheck As DataTable = PSS.Data.Production.Joins.OrderEntrySelect(strSQLcheck)
                    If dtCheck.Rows.Count > 0 Then
                        MsgBox("This billcode is already included for this model. It can not be added.", MsgBoxStyle.OKOnly, "ERROR")
                        Exit Sub
                    End If

                    '//Verify all data has been selected
                    Dim strErr As String = ""
                    If cboBillCode.SelectedValue < 1 Then strErr += "No BillCode." & vbCrLf
                    If cboRefDes.SelectedValue < 1 Then strErr += "No Ref Des Code." & vbCrLf
                    If cboFailure.SelectedValue < 1 Then strErr += "No Failure Code." & vbCrLf
                    If cboProblemFound.SelectedValue < 1 Then strErr += "No Problem Found Code." & vbCrLf
                    If cboRepairAction.SelectedValue < 1 Then strErr += "No Repair Action Code." & vbCrLf
                    If Len(Trim(strErr)) > 0 Then
                        MsgBox(strErr, MsgBoxStyle.OKOnly, "ERROR")
                        Exit Sub
                    End If

                    '//perform update
                    Try
                        Dim strSQL As String
                        If Len(Trim(txtNumber.Text)) < 1 Then
                            strSQL = "INSERT into twrtymap (wmap_ProblemFound, wmap_RepairAction, wmap_RefDes, wmap_Failure, model_id, billcode_id) VALUES (" & cboProblemFound.SelectedValue & ", " & cboRepairAction.SelectedValue & ", " & cboRefDes.SelectedValue & ", " & cboFailure.SelectedValue & ", " & mModelID & ", " & vBillID & ")"
                        Else
                            strSQL = "INSERT into twrtymap (wmap_ProblemFound, wmap_RepairAction, wmap_RefDes, wmap_RefDesNumb, wmap_Failure, model_id, billcode_id) VALUES (" & cboProblemFound.SelectedValue & ", " & cboRepairAction.SelectedValue & ", " & cboRefDes.SelectedValue & ", " & txtNumber.Text & ", " & cboFailure.SelectedValue & ", " & mModelID & ", " & vBillID & ")"
                        End If
                        Dim dt As Boolean = PSS.Data.Production.Joins.OrderEntryUpdateDelete(strSQL)
                    Catch ex As Exception
                        MsgBox("The record could not be updated.", MsgBoxStyle.OKOnly, "ERROR")
                    End Try

                    cboBillCode.Enabled = True
                    cboBillCode.Text = ""
                    cboProblemFound.Text = ""
                    cboRepairAction.Text = ""
                    cboFailure.Text = ""
                    cboRefDes.Text = ""
                    txtNumber.Text = ""
                    Me.pnlAddUpdateDelete.Visible = False
                    getMDmanufacturer()

                ElseIf vMC = "C" Then

                    If mModelID = 0 Or mCustID = 0 Then
                        MsgBox("Can Not Save", MsgBoxStyle.OKOnly, "ERROR")
                        Exit Sub
                    End If

                    '//Verify not in table
                    Dim strSQLcheck As String = "SELECT * FROM tbillmap WHERE model_id = " & mModelID & " AND billcode_id = " & cboBillCode.SelectedValue & " AND cust_id = " & mCustID
                    Dim dtCheck As DataTable = PSS.Data.Production.Joins.OrderEntrySelect(strSQLcheck)
                    If dtCheck.Rows.Count > 0 Then
                        MsgBox("This billcode is already included for this model. It can not be added.", MsgBoxStyle.OKOnly, "ERROR")
                        Exit Sub
                    End If

                    '//Verify all data has been selected
                    Dim strErr As String = ""
                    If cboBillCode.SelectedValue < 1 Then strErr += "No BillCode." & vbCrLf
                    If cboRefDes.SelectedValue < 1 Then strErr += "No Ref Des Code." & vbCrLf
                    If cboFailure.SelectedValue < 1 Then strErr += "No Failure Code." & vbCrLf
                    If cboProblemFound.SelectedValue < 1 Then strErr += "No Problem Found Code." & vbCrLf
                    If cboRepairAction.SelectedValue < 1 Then strErr += "No Repair Action Code." & vbCrLf
                    If Len(Trim(strErr)) > 0 Then
                        MsgBox(strErr, MsgBoxStyle.OKOnly, "ERROR")
                        Exit Sub
                    End If

                    '//perform update
                    Try
                        Dim strSQL As String
                        If Len(Trim(txtNumber.Text)) < 1 Then
                            strSQL = "INSERT into tbillmap (bmap_ProblemFound, bmap_RepairAction, bmap_RefDes, bmap_Failure, model_id, billcode_id, cust_id) VALUES (" & cboProblemFound.SelectedValue & ", " & cboRepairAction.SelectedValue & ", " & cboRefDes.SelectedValue & ", " & cboFailure.SelectedValue & ", " & mModelID & ", " & vBillID & ", " & mCustID & ")"
                        Else
                            strSQL = "INSERT into tbillmap (bmap_ProblemFound, bmap_RepairAction, bmap_RefDes, bmap_RefDesNumb, bmap_Failure, model_id, billcode_id, cust_id) VALUES (" & cboProblemFound.SelectedValue & ", " & cboRepairAction.SelectedValue & ", " & cboRefDes.SelectedValue & ", " & txtNumber.Text & ", " & cboFailure.SelectedValue & ", " & mModelID & ", " & vBillID & ", " & mCustID & ")"
                        End If
                        Dim dt As Boolean = PSS.Data.Production.Joins.OrderEntryUpdateDelete(strSQL)
                    Catch ex As Exception
                        MsgBox("The record could not be updated.", MsgBoxStyle.OKOnly, "ERROR")
                    End Try

                    cboBillCode.Enabled = True
                    cboBillCode.Text = ""
                    cboProblemFound.Text = ""
                    cboRepairAction.Text = ""
                    cboFailure.Text = ""
                    cboRefDes.Text = ""
                    txtNumber.Text = ""
                    Me.pnlAddUpdateDelete.Visible = False
                    getMDcustomer()

                End If

            End If


        End Sub

        Private Sub cboCustomer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomer.SelectedIndexChanged

        End Sub

        Private Sub gridManufacturer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridManufacturer.Click

        End Sub

        Private Sub gridManufacturer_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gridManufacturer.MouseUp

            Me.cboBillCode.Text = ""
            Me.cboRefDes.Text = ""
            Me.txtNumber.Text = ""
            Me.cboFailure.Text = ""
            Me.cboProblemFound.Text = ""
            Me.cboRepairAction.Text = ""

            Dim vBillCode, vRefDes, vNumber, vFailure, vProblemFound, vRepairAction As String

            vBillID = gridManufacturer.Columns("Bill ID").Text
            vBillCode = gridManufacturer.Columns("Bill Desc").Text
            vRefDes = gridManufacturer.Columns("Ref Des").Text
            vNumber = gridManufacturer.Columns("Number").Text
            vFailure = gridManufacturer.Columns("Failure").Text
            vProblemFound = gridManufacturer.Columns("ProblemFound").Text
            vRepairAction = gridManufacturer.Columns("RepairAction").Text
            activateEdit()

            Me.cboBillCode.Text = vBillCode
            Me.cboRefDes.Text = vRefDes
            Me.txtNumber.Text = vNumber
            Me.cboFailure.Text = vFailure
            Me.cboProblemFound.Text = vProblemFound
            Me.cboRepairAction.Text = vRepairAction

            Windows.Forms.Application.DoEvents()

            If vBillID > 0 Then
                vActiveBillCode = vBillID
                vActiveCustomer = 0
                vActiveType = "UPDATE"
                Me.cboBillCode.Enabled = False
                vMC = "M"

            End If

        End Sub

        Private Sub activateEdit()

            pnlAddUpdateDelete.Visible = True

            cboBillCode.DataSource = dtBillCodes
            cboBillCode.DisplayMember = dtBillCodes.Columns("BillCode_Desc").ToString
            cboBillCode.ValueMember = dtBillCodes.Columns("BillCode_ID").ToString
            cboBillCode.Text = ""

            cboProblemFound.DataSource = dtProblemFound
            cboProblemFound.DisplayMember = dtProblemFound.Columns("Dcode_LDesc").ToString
            cboProblemFound.ValueMember = dtProblemFound.Columns("Dcode_ID").ToString
            cboProblemFound.Text = ""

            cboRepairAction.DataSource = dtRepairAction
            cboRepairAction.DisplayMember = dtRepairAction.Columns("Dcode_LDesc").ToString
            cboRepairAction.ValueMember = dtRepairAction.Columns("Dcode_ID").ToString
            cboRepairAction.Text = ""

            cboRefDes.DataSource = dtRefDes
            cboRefDes.DisplayMember = dtRefDes.Columns("Dcode_LDesc").ToString
            cboRefDes.ValueMember = dtRefDes.Columns("Dcode_ID").ToString
            cboRefDes.Text = ""

            cboFailure.DataSource = dtFailure
            cboFailure.DisplayMember = dtFailure.Columns("Dcode_LDesc").ToString
            cboFailure.ValueMember = dtFailure.Columns("Dcode_ID").ToString
            cboFailure.Text = ""

            cboBillCode.Focus()

        End Sub


        Private Sub gridCustomer_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gridCustomer.MouseUp

            Me.cboBillCode.Text = ""
            Me.cboRefDes.Text = ""
            Me.txtNumber.Text = ""
            Me.cboFailure.Text = ""
            Me.cboProblemFound.Text = ""
            Me.cboRepairAction.Text = ""

            Dim vBillCode, vRefDes, vNumber, vFailure, vProblemFound, vRepairAction As String

            vBillID = gridManufacturer.Columns("Bill ID").Text
            vBillCode = gridCustomer.Columns("Bill Desc").Text
            vRefDes = gridCustomer.Columns("Ref Des").Text
            vNumber = gridCustomer.Columns("Number").Text
            vFailure = gridCustomer.Columns("Failure").Text
            vProblemFound = gridCustomer.Columns("ProblemFound").Text
            vRepairAction = gridCustomer.Columns("RepairAction").Text

            activateEdit()

            Me.cboBillCode.Text = vBillCode
            Me.cboRefDes.Text = vRefDes
            Me.txtNumber.Text = vNumber
            Me.cboFailure.Text = vFailure
            Me.cboProblemFound.Text = vProblemFound
            Me.cboRepairAction.Text = vRepairAction

            Windows.Forms.Application.DoEvents()

            If cboBillCode.SelectedValue > 0 Then
                vActiveBillCode = cboBillCode.SelectedValue
                vActiveCustomer = cboCustomer.SelectedValue
                vActiveType = "UPDATE"
                Me.cboBillCode.Enabled = False
                vMC = "C"
            End If

        End Sub


        Private Sub cboModel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboModel.SelectedIndexChanged

        End Sub

        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        End Sub

        Private Sub gridCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridCustomer.Click

        End Sub

        Private Sub tbManufModel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbManufModel.Click

        End Sub
    End Class

End Namespace
