Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.NativeInstruments
    Public Class frmProductModelMap
        Inherits System.Windows.Forms.Form

        Private _strScreenName As String = ""
        Private _iCust_ID As Integer = 0



#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName As String, ByVal iCustID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _strScreenName = strScreenName
            _iCust_ID = iCustID

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
        Friend WithEvents tdbgProduct As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents tdbgModel As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblProduct As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents chkboxUnmapped As System.Windows.Forms.CheckBox
        Friend WithEvents lblRecNum1 As System.Windows.Forms.Label
        Friend WithEvents lblRecNum2 As System.Windows.Forms.Label
        Friend WithEvents btnRefresh As System.Windows.Forms.Button
        Friend WithEvents btnCreateMap As System.Windows.Forms.Button
        Friend WithEvents tdbgProductModelMap As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblProdModelMap As System.Windows.Forms.Label
        Friend WithEvents lblRecNum3 As System.Windows.Forms.Label
        Friend WithEvents btnExport As System.Windows.Forms.Button
        Friend WithEvents btnRemove As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmProductModelMap))
            Me.tdbgProduct = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.tdbgModel = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lblProduct = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.tdbgProductModelMap = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.chkboxUnmapped = New System.Windows.Forms.CheckBox()
            Me.lblRecNum1 = New System.Windows.Forms.Label()
            Me.lblRecNum2 = New System.Windows.Forms.Label()
            Me.btnRefresh = New System.Windows.Forms.Button()
            Me.btnCreateMap = New System.Windows.Forms.Button()
            Me.lblProdModelMap = New System.Windows.Forms.Label()
            Me.lblRecNum3 = New System.Windows.Forms.Label()
            Me.btnExport = New System.Windows.Forms.Button()
            Me.btnRemove = New System.Windows.Forms.Button()
            CType(Me.tdbgProduct, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.tdbgModel, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.tdbgProductModelMap, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'tdbgProduct
            '
            Me.tdbgProduct.AllowColSelect = False
            Me.tdbgProduct.AllowUpdate = False
            Me.tdbgProduct.AlternatingRows = True
            Me.tdbgProduct.FilterBar = True
            Me.tdbgProduct.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdbgProduct.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.tdbgProduct.Location = New System.Drawing.Point(8, 48)
            Me.tdbgProduct.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.tdbgProduct.Name = "tdbgProduct"
            Me.tdbgProduct.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdbgProduct.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdbgProduct.PreviewInfo.ZoomFactor = 75
            Me.tdbgProduct.Size = New System.Drawing.Size(248, 448)
            Me.tdbgProduct.TabIndex = 12
            Me.tdbgProduct.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Normal{BackColor:SteelBlue;}Selected{ForeColo" & _
            "r:HighlightText;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{" & _
            "}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{BackColor:LightSteelB" & _
            "lue;}Style13{}Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;" & _
            "}RecordSelector{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:" & _
            "InactiveCaptionText;BackColor:InactiveCaption;}EvenRow{BackColor:NavajoWhite;}He" & _
            "ading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlTex" & _
            "t;AlignVert:Center;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, style=Bold;Fore" & _
            "Color:Red;BackColor:White;}Style4{}Style9{}Style8{}Style5{}Group{AlignVert:Cente" & _
            "r;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style7{}Style6{}Style1{}Style3{" & _
            "}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColSelect=""" & _
            "False"" Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight" & _
            "=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" R" & _
            "ecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalSc" & _
            "rollGroup=""1""><Height>444</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><" & _
            "EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Sty" & _
            "le8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Fo" & _
            "oter"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle pare" & _
            "nt=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" " & _
            "/><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me" & _
            "=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><Selecte" & _
            "dStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><Cli" & _
            "entRect>0, 0, 244, 444</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken" & _
            "</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style paren" & _
            "t="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading""" & _
            " me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me" & _
            "=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""" & _
            "Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""" & _
            "EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""Reco" & _
            "rdSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me" & _
            "=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><La" & _
            "yout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 2" & _
            "44, 444</ClientArea><PrintPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFoo" & _
            "terStyle parent="""" me=""Style21"" /></Blob>"
            '
            'tdbgModel
            '
            Me.tdbgModel.AllowUpdate = False
            Me.tdbgModel.AlternatingRows = True
            Me.tdbgModel.FilterBar = True
            Me.tdbgModel.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdbgModel.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.tdbgModel.Location = New System.Drawing.Point(264, 48)
            Me.tdbgModel.Name = "tdbgModel"
            Me.tdbgModel.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdbgModel.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdbgModel.PreviewInfo.ZoomFactor = 75
            Me.tdbgModel.Size = New System.Drawing.Size(216, 448)
            Me.tdbgModel.TabIndex = 13
            Me.tdbgModel.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Normal{BackColor:SteelBlue;}Selected{ForeColo" & _
            "r:HighlightText;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{" & _
            "}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{BackColor:LightSteelB" & _
            "lue;}Style13{}Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;" & _
            "}RecordSelector{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:" & _
            "InactiveCaptionText;BackColor:InactiveCaption;}EvenRow{BackColor:NavajoWhite;}He" & _
            "ading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText" & _
            ";BackColor:Control;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, style=Bold;Fore" & _
            "Color:Red;BackColor:White;}Style4{}Style9{}Style8{}Style5{}Group{BackColor:Contr" & _
            "olDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style7{}Style6{}Style1{}Style3{" & _
            "}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" Alternat" & _
            "ingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeigh" & _
            "t=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17""" & _
            " DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>4" & _
            "44</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 212, 444<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 212, 444</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'lblProduct
            '
            Me.lblProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblProduct.Location = New System.Drawing.Point(8, 32)
            Me.lblProduct.Name = "lblProduct"
            Me.lblProduct.Size = New System.Drawing.Size(128, 16)
            Me.lblProduct.TabIndex = 14
            Me.lblProduct.Text = "NI Product (Family)"
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.Location = New System.Drawing.Point(264, 32)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(88, 16)
            Me.Label1.TabIndex = 15
            Me.Label1.Text = "PSSI Model"
            '
            'tdbgProductModelMap
            '
            Me.tdbgProductModelMap.AllowUpdate = False
            Me.tdbgProductModelMap.AlternatingRows = True
            Me.tdbgProductModelMap.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.tdbgProductModelMap.FilterBar = True
            Me.tdbgProductModelMap.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdbgProductModelMap.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.tdbgProductModelMap.Location = New System.Drawing.Point(496, 64)
            Me.tdbgProductModelMap.Name = "tdbgProductModelMap"
            Me.tdbgProductModelMap.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdbgProductModelMap.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdbgProductModelMap.PreviewInfo.ZoomFactor = 75
            Me.tdbgProductModelMap.Size = New System.Drawing.Size(384, 432)
            Me.tdbgProductModelMap.TabIndex = 16
            Me.tdbgProductModelMap.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Normal{BackColor:SteelBlue;}Selected{ForeColo" & _
            "r:HighlightText;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{" & _
            "}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{BackColor:LightSteelB" & _
            "lue;}Style13{}Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;" & _
            "}RecordSelector{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:" & _
            "InactiveCaptionText;BackColor:InactiveCaption;}EvenRow{BackColor:NavajoWhite;}He" & _
            "ading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlTex" & _
            "t;AlignVert:Center;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, style=Bold;Fore" & _
            "Color:Red;BackColor:White;}Style4{}Style9{}Style8{}Style5{}Group{AlignVert:Cente" & _
            "r;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style7{}Style6{}Style1{}Style3{" & _
            "}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" Alternat" & _
            "ingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeigh" & _
            "t=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17""" & _
            " DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>4" & _
            "28</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 380, 428<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 380, 428</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'chkboxUnmapped
            '
            Me.chkboxUnmapped.Location = New System.Drawing.Point(360, 32)
            Me.chkboxUnmapped.Name = "chkboxUnmapped"
            Me.chkboxUnmapped.Size = New System.Drawing.Size(136, 16)
            Me.chkboxUnmapped.TabIndex = 17
            Me.chkboxUnmapped.Text = "Models not mapped"
            '
            'lblRecNum1
            '
            Me.lblRecNum1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRecNum1.Location = New System.Drawing.Point(8, 496)
            Me.lblRecNum1.Name = "lblRecNum1"
            Me.lblRecNum1.Size = New System.Drawing.Size(160, 16)
            Me.lblRecNum1.TabIndex = 18
            Me.lblRecNum1.Text = "0"
            '
            'lblRecNum2
            '
            Me.lblRecNum2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRecNum2.Location = New System.Drawing.Point(264, 496)
            Me.lblRecNum2.Name = "lblRecNum2"
            Me.lblRecNum2.Size = New System.Drawing.Size(160, 16)
            Me.lblRecNum2.TabIndex = 19
            Me.lblRecNum2.Text = "0"
            '
            'btnRefresh
            '
            Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRefresh.ForeColor = System.Drawing.Color.Navy
            Me.btnRefresh.Location = New System.Drawing.Point(600, 2)
            Me.btnRefresh.Name = "btnRefresh"
            Me.btnRefresh.Size = New System.Drawing.Size(64, 30)
            Me.btnRefresh.TabIndex = 20
            Me.btnRefresh.Text = "Refresh"
            '
            'btnCreateMap
            '
            Me.btnCreateMap.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCreateMap.ForeColor = System.Drawing.Color.Green
            Me.btnCreateMap.Location = New System.Drawing.Point(496, 2)
            Me.btnCreateMap.Name = "btnCreateMap"
            Me.btnCreateMap.Size = New System.Drawing.Size(96, 40)
            Me.btnCreateMap.TabIndex = 21
            Me.btnCreateMap.Text = "Create Map"
            '
            'lblProdModelMap
            '
            Me.lblProdModelMap.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblProdModelMap.Location = New System.Drawing.Point(496, 48)
            Me.lblProdModelMap.Name = "lblProdModelMap"
            Me.lblProdModelMap.Size = New System.Drawing.Size(192, 16)
            Me.lblProdModelMap.TabIndex = 22
            Me.lblProdModelMap.Text = "Product (Family) Model Map"
            '
            'lblRecNum3
            '
            Me.lblRecNum3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRecNum3.Location = New System.Drawing.Point(496, 496)
            Me.lblRecNum3.Name = "lblRecNum3"
            Me.lblRecNum3.Size = New System.Drawing.Size(160, 16)
            Me.lblRecNum3.TabIndex = 23
            Me.lblRecNum3.Text = "0"
            '
            'btnExport
            '
            Me.btnExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnExport.ForeColor = System.Drawing.Color.Navy
            Me.btnExport.Location = New System.Drawing.Point(672, 2)
            Me.btnExport.Name = "btnExport"
            Me.btnExport.Size = New System.Drawing.Size(104, 30)
            Me.btnExport.TabIndex = 24
            Me.btnExport.Text = "Export Data"
            '
            'btnRemove
            '
            Me.btnRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemove.ForeColor = System.Drawing.Color.Crimson
            Me.btnRemove.Location = New System.Drawing.Point(672, 40)
            Me.btnRemove.Name = "btnRemove"
            Me.btnRemove.Size = New System.Drawing.Size(104, 24)
            Me.btnRemove.TabIndex = 25
            Me.btnRemove.Text = "Remove Map"
            '
            'frmProductModelMap
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(928, 662)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRemove, Me.btnExport, Me.lblRecNum3, Me.lblProdModelMap, Me.btnCreateMap, Me.btnRefresh, Me.lblRecNum2, Me.lblRecNum1, Me.chkboxUnmapped, Me.tdbgProductModelMap, Me.Label1, Me.lblProduct, Me.tdbgModel, Me.tdbgProduct})
            Me.Name = "frmProductModelMap"
            Me.Text = "frmProductModelMap"
            CType(Me.tdbgProduct, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.tdbgModel, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.tdbgProductModelMap, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region


        '********************************************************************
        Private Sub frmProductModelMap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Me.chkboxUnmapped.Checked = True
            LoadProductFamilyData()
            LoadModelData()
            LoadProductFamilyModelMapData()
        End Sub

        '********************************************************************
        Private Sub LoadProductFamilyData()
            Dim objNI As NI
            Dim dt1 As DataTable
            Dim row As DataRow
            Dim i As Integer

            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                objNI = New NI()

                'Product (family) data
                dt1 = objNI.GetNIProducts
                If dt1.Rows.Count > 0 Then
                    With Me.tdbgProduct
                        .DataSource = dt1.DefaultView
                        '.Splits(0).DisplayColumns("Pallett_ID").Visible = False
                        For i = 0 To .Columns.Count - 1 'Me.tdgBoxes.Splits(0).Rows.Count - 1
                            'Me.tdgBoxes.Splits(0).Rows(i).AutoSize()
                            .Splits(0).DisplayColumns(i).AutoSize()
                            Select Case .Splits(0).DisplayColumns(i).Name.ToString.Trim.ToUpper
                                Case "NI_Prod_Desc".ToUpper, "NI_Prod_Desc2".ToUpper '"NI_Prod_ID".ToUpper,
                                    .Splits(0).DisplayColumns(i).Visible = True
                                Case Else
                                    .Splits(0).DisplayColumns(i).Visible = False
                            End Select
                            '.Splits(0).DisplayColumns("Pallett_ID").Visible = False
                        Next

                        Me.lblRecNum1.Text = "Count: " & .RowCount

                        'For i = 0 To .Columns.Count - 1
                        '    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        '    If .Columns(i).Caption.EndsWith("Qty") Then
                        '        .Splits(0).DisplayColumns(i).Width = 40
                        '        .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                        '    End If
                        'Next i

                        '.Splits(0).DisplayColumns("Box").Width = 140
                        '.Splits(0).DisplayColumns("Produced Date").Width = 60
                        '.Splits(0).DisplayColumns("New Part #").Width = 75
                        '.Splits(0).DisplayColumns("Use Part #").Width = 80
                        '.Splits(0).DisplayColumns("RV Part #").Width = 80

                        '.Splits(0).DisplayColumns("Produced Date").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                        '.Splits(0).DisplayColumns("New/Use/RV Part").Visible = False
                        '.Splits(0).DisplayColumns("Pallett_ID").Visible = False

                        '.ColumnFooters = True
                        '.Columns("Use Part #").FooterText = "TOTAL"
                        'If Not IsDBNull(dt.Compute("Sum([Box Qty])", "")) Then .Columns("Box Qty").FooterText = Format(dt.Compute("Sum([Box Qty])", ""), "#,##0").ToString Else .Columns("Box Qty").FooterText = Format(0, "#,##0")
                        'If Not IsDBNull(dt.Compute("Sum([New Qty])", "")) Then .Columns("New Qty").FooterText = Format(dt.Compute("Sum([New Qty])", ""), "#,##0").ToString Else .Columns("New Qty").FooterText = Format(0, "#,##0")
                        'If Not IsDBNull(dt.Compute("Sum([Use Qty])", "")) Then .Columns("Use Qty").FooterText = Format(dt.Compute("Sum([Use Qty])", ""), "#,##0").ToString Else .Columns("Use Qty").FooterText = Format(0, "#,##0")
                        'If Not IsDBNull(dt.Compute("Sum([RV Qty])", "")) Then .Columns("RV Qty").FooterText = Format(dt.Compute("Sum([RV Qty])", ""), "#,##0").ToString Else .Columns("RV Qty").FooterText = Format(0, "#,##0")
                        'If Not IsDBNull(dt.Compute("Sum([Open Qty])", "")) Then .Columns("Open Qty").FooterText = Format(dt.Compute("Sum([Open Qty])", ""), "#,##0").ToString Else .Columns("Open Qty").FooterText = Format(0, "#,##0")
                    End With
                Else
                    Me.tdbgProduct.DataSource = dt1.DefaultView
                    Me.lblRecNum1.Text = "Count: 0"
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "LoadProductFamilyData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                objNI = Nothing
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '********************************************************************
        Private Sub LoadModelData()
            Dim objNI As NI
            Dim dt2, dtModelFinal As DataTable
            Dim row As DataRow
            Dim i As Integer

            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor


                objNI = New NI()

                'Model data
                dt2 = objNI.GetNIModels(NI.MANUFID, NI.PRODID)
                If dt2.Rows.Count > 0 Then
                    If Me.chkboxUnmapped.Checked Then
                        dtModelFinal = dt2.Clone
                        For Each row In dt2.Rows
                            If row("Mapped") = "No" Then
                                dtModelFinal.ImportRow(row)
                            End If
                        Next
                    Else
                        dtModelFinal = dt2.Copy
                    End If
                    dt2 = Nothing

                    With Me.tdbgModel
                        .DataSource = dtModelFinal.DefaultView
                        For i = 0 To .Columns.Count - 1
                            .Splits(0).DisplayColumns(i).AutoSize()
                            Select Case .Splits(0).DisplayColumns(i).Name.ToString.Trim.ToUpper
                                Case "Model".ToUpper, "Mapped".ToUpper
                                    .Splits(0).DisplayColumns(i).Visible = True
                                Case Else
                                    .Splits(0).DisplayColumns(i).Visible = False
                            End Select
                        Next

                        Me.lblRecNum2.Text = "Count: " & .RowCount

                    End With
                Else
                    Me.tdbgModel.DataSource = dtModelFinal.DefaultView
                    Me.lblRecNum2.Text = "Count: 0"
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "LoadModelData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                objNI = Nothing
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '********************************************************************
        Private Sub LoadProductFamilyModelMapData()
            Dim objNI As NI
            Dim dt2 As DataTable
            Dim row As DataRow
            Dim i As Integer

            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor


                objNI = New NI()

                'Mapping data
                dt2 = objNI.GetNIProductModelMapData()
                If dt2.Rows.Count > 0 Then

                    With Me.tdbgProductModelMap
                        .DataSource = dt2.DefaultView
                        For i = 0 To .Columns.Count - 1
                            .Splits(0).DisplayColumns(i).AutoSize()
                            Select Case .Splits(0).DisplayColumns(i).Name.ToString.Trim.ToUpper
                                Case "Model".ToUpper, "NI_Prod_Desc".ToUpper, "UpdateUser".ToUpper, "UpdateDateTime".ToUpper
                                    .Splits(0).DisplayColumns(i).Visible = True
                                Case Else
                                    .Splits(0).DisplayColumns(i).Visible = False
                            End Select
                        Next

                        Me.lblRecNum3.Text = "Count: " & .RowCount

                    End With
                Else
                    Me.tdbgProductModelMap.DataSource = dt2.DefaultView
                    Me.lblRecNum3.Text = "Count: 0"
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "LoadProductFamilyModelMapData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                objNI = Nothing
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '********************************************************************
        Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
            LoadProductFamilyData()
            LoadModelData()
            LoadProductFamilyModelMapData()
        End Sub

        '********************************************************************
        Private Sub btnCreateMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateMap.Click
            Dim iNIProdID As Integer
            'Dim dt As New DataTable()
            Dim dtTmp As DataTable
            Dim iRow As Integer
            Dim row As DataRow
            Dim strProdDesc As String = ""
            Dim objNI As New NI()
            Dim strMsg As String = ""
            Dim bReadyToProcess As Boolean = False
            Dim strDTime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            Dim iUserID As Integer = PSS.Core.ApplicationUser.IDuser
            Dim i As Integer

            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                If Me.tdbgProduct.SelectedRows.Count = 1 Then
                    For Each iRow In Me.tdbgProduct.SelectedRows
                        iNIProdID = Me.tdbgProduct.Columns("NI_Prod_ID").CellValue(iRow)
                        strProdDesc = Me.tdbgProduct.Columns("NI_Prod_Desc").CellValue(iRow)
                        Exit For
                    Next

                    If Me.tdbgModel.SelectedRows.Count >= 1 Then
                        'dt.Columns.Add("Model_ID", GetType(Integer))
                        'dt.Columns.Add("Model", GetType(String))
                        For Each iRow In Me.tdbgModel.SelectedRows
                            'row = dt.NewRow
                            'row("Model_ID") = Me.tdbgProduct.Columns("Model_ID").CellValue(iRow)
                            'row("Model") = Me.tdbgProduct.Columns("Model").CellValue(iRow)
                            'dt.Rows.Add(row)
                            dtTmp = objNI.GetNIProductModelMapData(Me.tdbgModel.Columns("Model_ID").CellValue(iRow))
                            If dtTmp.Rows.Count > 0 Then
                                If strMsg.Trim.Length = 0 Then
                                    strMsg = "Already mapped:" & Environment.NewLine
                                    strMsg &= strProdDesc & " - " & Me.tdbgModel.Columns("Model").CellValue(iRow)
                                Else
                                    strMsg &= Environment.NewLine & strProdDesc & " - " & Me.tdbgModel.Columns("Model").CellValue(iRow)
                                End If
                            End If
                        Next
                        If strMsg.Trim.Length > 0 Then
                            Dim result As Integer = MessageBox.Show(strMsg, "Selection", MessageBoxButtons.YesNo)
                            If result = DialogResult.Yes Then
                                bReadyToProcess = True
                            Else
                                bReadyToProcess = False
                            End If
                        Else
                            bReadyToProcess = True
                        End If

                        If bReadyToProcess Then
                            For Each iRow In Me.tdbgModel.SelectedRows
                                i = objNI.SaveNIProductModelMapData(iNIProdID, Me.tdbgModel.Columns("Model_ID").CellValue(iRow), iUserID, strDTime)
                            Next
                        End If
                    Else
                        MessageBox.Show("Please select at least one PSSI model.", "btnCreateMap_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("Please select a NI Product(family).", "btnCreateMap_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCreateMap_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                objNI = Nothing : LoadProductFamilyModelMapData()
                Me.Enabled = True : Cursor.Current = Cursors.Default

            End Try
        End Sub

        '********************************************************************
        Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
            Dim objExcelRpt As New PSS.Data.ExcelReports()
            Dim ds As New DataSet()
            Dim dtTmp As DataTable

            Try

                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                dtTmp = Me.tdbgProduct.DataSource.table
                dtTmp.TableName = "NI Product(Family)"
                ds.Tables.Add(dtTmp)

                dtTmp = Me.tdbgModel.DataSource.table
                dtTmp.TableName = "PSSI Model"
                ds.Tables.Add(dtTmp)

                dtTmp = Me.tdbgProductModelMap.DataSource.table
                dtTmp.TableName = "Mapped Data"
                ds.Tables.Add(dtTmp)

                objExcelRpt.RunSimpleExcelFormat_PerSheetPerTable(ds, "NI_Product PSSI_Model Map")

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnExport_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                objExcelRpt = Nothing
                Me.Enabled = True : Cursor.Current = Cursors.Default

            End Try
        End Sub

        '********************************************************************
        Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
            Dim iRow As Integer
            Dim iNI_PMM_ID As Integer = 0
            Dim objNI As New NI()
            Dim strMsg As String = ""

            Try

                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                If Me.tdbgProductModelMap.SelectedRows.Count > 0 Then
                    For Each iRow In Me.tdbgProductModelMap.SelectedRows
                        If strMsg.Trim.Length = 0 Then
                            strMsg = "Do you want to remove " & IIf(Me.tdbgProductModelMap.SelectedRows.Count = 1, "this map?", "these maps?") & Environment.NewLine
                            strMsg &= Me.tdbgProductModelMap.Columns("NI_Prod_Desc").CellValue(iRow) & " - " & Me.tdbgProductModelMap.Columns("Model").CellValue(iRow)
                        Else
                            strMsg &= Environment.NewLine & Me.tdbgProductModelMap.Columns("NI_Prod_Desc").CellValue(iRow) & " - " & Me.tdbgProductModelMap.Columns("Model").CellValue(iRow)

                        End If
                    Next
                    Dim result As Integer = MessageBox.Show(strMsg, "Selection", MessageBoxButtons.YesNo)
                    If result = DialogResult.Yes Then
                        For Each iRow In Me.tdbgProductModelMap.SelectedRows
                            iNI_PMM_ID = Me.tdbgProductModelMap.Columns("NI_PMM_ID").CellValue(iRow)
                            objNI.RemoveNIProductModelMap(iNI_PMM_ID)
                        Next
                    End If
                Else
                        MessageBox.Show("Please select row(s) to remove.", "btnCreateMap_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, " btnRemove_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                objNI = Nothing : LoadProductFamilyModelMapData()
            End Try
        End Sub
    End Class

End Namespace
