Imports PSS.Rules

Namespace Gui
    Public Class ModManufWin
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
        Friend WithEvents cboManuf As PSS.Gui.Controls.ComboBox
        Friend WithEvents lblManuf As System.Windows.Forms.Label
        Friend WithEvents lblModel As System.Windows.Forms.Label
        Friend WithEvents cboModel As PSS.Gui.Controls.ComboBox
        Friend WithEvents dbgMap As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnAddManuf As System.Windows.Forms.Button
        Friend WithEvents btnAddModel As System.Windows.Forms.Button
        Friend WithEvents dbgProdGrp As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnUpdateGrp As System.Windows.Forms.Button
        Friend WithEvents btnAddGrp As System.Windows.Forms.Button
        Friend WithEvents dbgRptGrp As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnAddRptGrp As System.Windows.Forms.Button
        Friend WithEvents btnUpdateRptGrp As System.Windows.Forms.Button
        Friend WithEvents ctmnModelFamiliesOption As System.Windows.Forms.ContextMenu
        Friend WithEvents dbgCustModelFamiliesMap As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents tbProductGroups As System.Windows.Forms.TabPage
        Friend WithEvents tpReportGroups As System.Windows.Forms.TabPage
        Friend WithEvents tbModelFamilies As System.Windows.Forms.TabPage
        Friend WithEvents btnAddModelFamily As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ModManufWin))
            Me.cboManuf = New PSS.Gui.Controls.ComboBox()
            Me.lblManuf = New System.Windows.Forms.Label()
            Me.lblModel = New System.Windows.Forms.Label()
            Me.cboModel = New PSS.Gui.Controls.ComboBox()
            Me.dbgMap = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnAddManuf = New System.Windows.Forms.Button()
            Me.btnAddModel = New System.Windows.Forms.Button()
            Me.dbgProdGrp = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnUpdateGrp = New System.Windows.Forms.Button()
            Me.btnAddGrp = New System.Windows.Forms.Button()
            Me.btnAddRptGrp = New System.Windows.Forms.Button()
            Me.btnUpdateRptGrp = New System.Windows.Forms.Button()
            Me.dbgRptGrp = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.ctmnModelFamiliesOption = New System.Windows.Forms.ContextMenu()
            Me.btnAddModelFamily = New System.Windows.Forms.Button()
            Me.dbgCustModelFamiliesMap = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.tbModelFamilies = New System.Windows.Forms.TabPage()
            Me.tbProductGroups = New System.Windows.Forms.TabPage()
            Me.tpReportGroups = New System.Windows.Forms.TabPage()
            CType(Me.dbgMap, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dbgProdGrp, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dbgRptGrp, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dbgCustModelFamiliesMap, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControl1.SuspendLayout()
            Me.tbModelFamilies.SuspendLayout()
            Me.tbProductGroups.SuspendLayout()
            Me.tpReportGroups.SuspendLayout()
            Me.SuspendLayout()
            '
            'cboManuf
            '
            Me.cboManuf.AutoComplete = True
            Me.cboManuf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboManuf.Location = New System.Drawing.Point(8, 61)
            Me.cboManuf.Name = "cboManuf"
            Me.cboManuf.Size = New System.Drawing.Size(216, 21)
            Me.cboManuf.TabIndex = 0
            '
            'lblManuf
            '
            Me.lblManuf.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblManuf.Location = New System.Drawing.Point(8, 45)
            Me.lblManuf.Name = "lblManuf"
            Me.lblManuf.Size = New System.Drawing.Size(184, 16)
            Me.lblManuf.TabIndex = 1
            Me.lblManuf.Text = "Manufactures:"
            '
            'lblModel
            '
            Me.lblModel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModel.Location = New System.Drawing.Point(8, 93)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(184, 16)
            Me.lblModel.TabIndex = 3
            Me.lblModel.Text = "Models:"
            '
            'cboModel
            '
            Me.cboModel.AutoComplete = True
            Me.cboModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboModel.Location = New System.Drawing.Point(8, 109)
            Me.cboModel.Name = "cboModel"
            Me.cboModel.Size = New System.Drawing.Size(216, 21)
            Me.cboModel.TabIndex = 2
            '
            'dbgMap
            '
            Me.dbgMap.AllowUpdate = False
            Me.dbgMap.AlternatingRows = True
            Me.dbgMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.dbgMap.CaptionHeight = 17
            Me.dbgMap.FilterBar = True
            Me.dbgMap.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgMap.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dbgMap.Location = New System.Drawing.Point(232, 45)
            Me.dbgMap.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow
            Me.dbgMap.Name = "dbgMap"
            Me.dbgMap.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgMap.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgMap.PreviewInfo.ZoomFactor = 75
            Me.dbgMap.RowHeight = 15
            Me.dbgMap.Size = New System.Drawing.Size(848, 251)
            Me.dbgMap.TabIndex = 4
            Me.dbgMap.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}S" & _
            "tyle12{AlignHorz:Near;}Style13{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColo" & _
            "r:LightSkyBlue;}Selected{ForeColor:Yellow;BackColor:Green;}Heading{Wrap:True;Bac" & _
            "kColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;" & _
            "}Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Fo" & _
            "oter{}Caption{AlignHorz:Center;}Editor{}Normal{Font:Verdana, 8.25pt;}Style29{}St" & _
            "yle28{}Style27{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style1" & _
            "{}Style2{}OddRow{}RecordSelector{AlignImage:Center;}Style9{}Style8{}Style3{}Styl" & _
            "e11{}Style10{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" Alt" & _
            "ernatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooter" & _
            "Height=""17"" FilterBar=""True"" MarqueeStyle=""HighlightRow"" RecordSelectorWidth=""17" & _
            """ DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>" & _
            "249</Height><CaptionStyle parent=""Heading"" me=""Style12"" /><EditorStyle parent=""E" & _
            "ditor"" me=""Style4"" /><EvenRowStyle parent=""EvenRow"" me=""Style10"" /><FilterBarSty" & _
            "le parent=""FilterBar"" me=""Style29"" /><FooterStyle parent=""Footer"" me=""Style6"" />" & _
            "<GroupStyle parent=""Group"" me=""Style28"" /><HeadingStyle parent=""Heading"" me=""Sty" & _
            "le5"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style9"" /><InactiveStyle par" & _
            "ent=""Inactive"" me=""Style8"" /><OddRowStyle parent=""OddRow"" me=""Style11"" /><Record" & _
            "SelectorStyle parent=""RecordSelector"" me=""Style27"" /><SelectedStyle parent=""Sele" & _
            "cted"" me=""Style7"" /><Style parent=""Normal"" me=""Style3"" /><ClientRect>0, 0, 846, " & _
            "249</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1." & _
            "Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" />" & _
            "<Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Sty" & _
            "le parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Styl" & _
            "e parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style pa" & _
            "rent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style p" & _
            "arent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Styl" & _
            "e parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedS" & _
            "tyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><" & _
            "DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 846, 249</ClientArea" & _
            "><PrintPageHeaderStyle parent="""" me=""Style1"" /><PrintPageFooterStyle parent="""" m" & _
            "e=""Style2"" /></Blob>"
            '
            'btnAddManuf
            '
            Me.btnAddManuf.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnAddManuf.Location = New System.Drawing.Point(160, 16)
            Me.btnAddManuf.Name = "btnAddManuf"
            Me.btnAddManuf.Size = New System.Drawing.Size(120, 18)
            Me.btnAddManuf.TabIndex = 5
            Me.btnAddManuf.Text = "Add Manufacture"
            '
            'btnAddModel
            '
            Me.btnAddModel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnAddModel.Location = New System.Drawing.Point(24, 16)
            Me.btnAddModel.Name = "btnAddModel"
            Me.btnAddModel.Size = New System.Drawing.Size(120, 18)
            Me.btnAddModel.TabIndex = 8
            Me.btnAddModel.Text = "Add Model"
            '
            'dbgProdGrp
            '
            Me.dbgProdGrp.AllowUpdate = False
            Me.dbgProdGrp.AlternatingRows = True
            Me.dbgProdGrp.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.dbgProdGrp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.dbgProdGrp.CaptionHeight = 17
            Me.dbgProdGrp.FilterBar = True
            Me.dbgProdGrp.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgProdGrp.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.dbgProdGrp.Location = New System.Drawing.Point(8, 48)
            Me.dbgProdGrp.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow
            Me.dbgProdGrp.Name = "dbgProdGrp"
            Me.dbgProdGrp.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgProdGrp.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgProdGrp.PreviewInfo.ZoomFactor = 75
            Me.dbgProdGrp.RowHeight = 15
            Me.dbgProdGrp.Size = New System.Drawing.Size(1048, 168)
            Me.dbgProdGrp.TabIndex = 11
            Me.dbgProdGrp.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}S" & _
            "tyle12{AlignHorz:Near;}Style13{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColo" & _
            "r:LightSkyBlue;}Selected{ForeColor:Yellow;BackColor:Green;}Heading{Wrap:True;Ali" & _
            "gnVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;" & _
            "}Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Fo" & _
            "oter{}Caption{AlignHorz:Center;}Editor{}Normal{Font:Verdana, 8.25pt;}Style29{}St" & _
            "yle28{}Style27{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style1" & _
            "{}Style2{}OddRow{}RecordSelector{AlignImage:Center;}Style9{}Style8{}Style3{}Styl" & _
            "e11{}Style10{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" Alt" & _
            "ernatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooter" & _
            "Height=""17"" FilterBar=""True"" MarqueeStyle=""HighlightRow"" RecordSelectorWidth=""17" & _
            """ DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>" & _
            "166</Height><CaptionStyle parent=""Heading"" me=""Style12"" /><EditorStyle parent=""E" & _
            "ditor"" me=""Style4"" /><EvenRowStyle parent=""EvenRow"" me=""Style10"" /><FilterBarSty" & _
            "le parent=""FilterBar"" me=""Style29"" /><FooterStyle parent=""Footer"" me=""Style6"" />" & _
            "<GroupStyle parent=""Group"" me=""Style28"" /><HeadingStyle parent=""Heading"" me=""Sty" & _
            "le5"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style9"" /><InactiveStyle par" & _
            "ent=""Inactive"" me=""Style8"" /><OddRowStyle parent=""OddRow"" me=""Style11"" /><Record" & _
            "SelectorStyle parent=""RecordSelector"" me=""Style27"" /><SelectedStyle parent=""Sele" & _
            "cted"" me=""Style7"" /><Style parent=""Normal"" me=""Style3"" /><ClientRect>0, 0, 1046," & _
            " 166</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1" & _
            ".Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /" & _
            "><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><St" & _
            "yle parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Sty" & _
            "le parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style p" & _
            "arent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style " & _
            "parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Sty" & _
            "le parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></Named" & _
            "Styles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout>" & _
            "<DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 1046, 166</ClientAr" & _
            "ea><PrintPageHeaderStyle parent="""" me=""Style1"" /><PrintPageFooterStyle parent=""""" & _
            " me=""Style2"" /></Blob>"
            '
            'btnUpdateGrp
            '
            Me.btnUpdateGrp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnUpdateGrp.Location = New System.Drawing.Point(80, 16)
            Me.btnUpdateGrp.Name = "btnUpdateGrp"
            Me.btnUpdateGrp.Size = New System.Drawing.Size(56, 18)
            Me.btnUpdateGrp.TabIndex = 15
            Me.btnUpdateGrp.Text = "Update Group"
            Me.btnUpdateGrp.Visible = False
            '
            'btnAddGrp
            '
            Me.btnAddGrp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnAddGrp.Location = New System.Drawing.Point(16, 16)
            Me.btnAddGrp.Name = "btnAddGrp"
            Me.btnAddGrp.Size = New System.Drawing.Size(56, 18)
            Me.btnAddGrp.TabIndex = 14
            Me.btnAddGrp.Text = "New"
            '
            'btnAddRptGrp
            '
            Me.btnAddRptGrp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnAddRptGrp.Location = New System.Drawing.Point(16, 16)
            Me.btnAddRptGrp.Name = "btnAddRptGrp"
            Me.btnAddRptGrp.Size = New System.Drawing.Size(56, 18)
            Me.btnAddRptGrp.TabIndex = 19
            Me.btnAddRptGrp.Text = "New"
            '
            'btnUpdateRptGrp
            '
            Me.btnUpdateRptGrp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnUpdateRptGrp.Location = New System.Drawing.Point(80, 16)
            Me.btnUpdateRptGrp.Name = "btnUpdateRptGrp"
            Me.btnUpdateRptGrp.Size = New System.Drawing.Size(56, 18)
            Me.btnUpdateRptGrp.TabIndex = 20
            Me.btnUpdateRptGrp.Text = "Update"
            Me.btnUpdateRptGrp.Visible = False
            '
            'dbgRptGrp
            '
            Me.dbgRptGrp.AllowUpdate = False
            Me.dbgRptGrp.AlternatingRows = True
            Me.dbgRptGrp.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.dbgRptGrp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.dbgRptGrp.CaptionHeight = 17
            Me.dbgRptGrp.FilterBar = True
            Me.dbgRptGrp.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgRptGrp.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.dbgRptGrp.Location = New System.Drawing.Point(8, 48)
            Me.dbgRptGrp.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow
            Me.dbgRptGrp.Name = "dbgRptGrp"
            Me.dbgRptGrp.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgRptGrp.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgRptGrp.PreviewInfo.ZoomFactor = 75
            Me.dbgRptGrp.RowHeight = 15
            Me.dbgRptGrp.Size = New System.Drawing.Size(1048, 168)
            Me.dbgRptGrp.TabIndex = 22
            Me.dbgRptGrp.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}S" & _
            "tyle12{AlignHorz:Near;}Style13{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColo" & _
            "r:LightSkyBlue;}Selected{ForeColor:Yellow;BackColor:Green;}Heading{Wrap:True;Bac" & _
            "kColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;" & _
            "}Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Od" & _
            "dRow{}Footer{}Caption{AlignHorz:Center;}Style27{}Style29{}Style28{}Normal{Font:V" & _
            "erdana, 8.25pt;}Style10{}HighlightRow{ForeColor:HighlightText;BackColor:Highligh" & _
            "t;}Editor{}Style11{}RecordSelector{AlignImage:Center;}Style9{}Style8{}Style3{}St" & _
            "yle2{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" Alt" & _
            "ernatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooter" & _
            "Height=""17"" FilterBar=""True"" MarqueeStyle=""HighlightRow"" RecordSelectorWidth=""17" & _
            """ DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>" & _
            "166</Height><CaptionStyle parent=""Heading"" me=""Style12"" /><EditorStyle parent=""E" & _
            "ditor"" me=""Style4"" /><EvenRowStyle parent=""EvenRow"" me=""Style10"" /><FilterBarSty" & _
            "le parent=""FilterBar"" me=""Style29"" /><FooterStyle parent=""Footer"" me=""Style6"" />" & _
            "<GroupStyle parent=""Group"" me=""Style28"" /><HeadingStyle parent=""Heading"" me=""Sty" & _
            "le5"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style9"" /><InactiveStyle par" & _
            "ent=""Inactive"" me=""Style8"" /><OddRowStyle parent=""OddRow"" me=""Style11"" /><Record" & _
            "SelectorStyle parent=""RecordSelector"" me=""Style27"" /><SelectedStyle parent=""Sele" & _
            "cted"" me=""Style7"" /><Style parent=""Normal"" me=""Style3"" /><ClientRect>0, 0, 1046," & _
            " 166</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1" & _
            ".Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /" & _
            "><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><St" & _
            "yle parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Sty" & _
            "le parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style p" & _
            "arent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style " & _
            "parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Sty" & _
            "le parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></Named" & _
            "Styles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Lay" & _
            "out><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 1046, 166</Clie" & _
            "ntArea><PrintPageHeaderStyle parent="""" me=""Style1"" /><PrintPageFooterStyle paren" & _
            "t="""" me=""Style2"" /></Blob>"
            '
            'btnAddModelFamily
            '
            Me.btnAddModelFamily.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnAddModelFamily.Location = New System.Drawing.Point(16, 16)
            Me.btnAddModelFamily.Name = "btnAddModelFamily"
            Me.btnAddModelFamily.Size = New System.Drawing.Size(56, 18)
            Me.btnAddModelFamily.TabIndex = 28
            Me.btnAddModelFamily.Text = "New"
            '
            'dbgCustModelFamiliesMap
            '
            Me.dbgCustModelFamiliesMap.AllowUpdate = False
            Me.dbgCustModelFamiliesMap.AlternatingRows = True
            Me.dbgCustModelFamiliesMap.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.dbgCustModelFamiliesMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.dbgCustModelFamiliesMap.CaptionHeight = 17
            Me.dbgCustModelFamiliesMap.FilterBar = True
            Me.dbgCustModelFamiliesMap.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgCustModelFamiliesMap.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.dbgCustModelFamiliesMap.Location = New System.Drawing.Point(8, 48)
            Me.dbgCustModelFamiliesMap.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow
            Me.dbgCustModelFamiliesMap.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.dbgCustModelFamiliesMap.Name = "dbgCustModelFamiliesMap"
            Me.dbgCustModelFamiliesMap.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgCustModelFamiliesMap.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgCustModelFamiliesMap.PreviewInfo.ZoomFactor = 75
            Me.dbgCustModelFamiliesMap.RowHeight = 15
            Me.dbgCustModelFamiliesMap.Size = New System.Drawing.Size(1048, 168)
            Me.dbgCustModelFamiliesMap.TabIndex = 26
            Me.dbgCustModelFamiliesMap.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Style11{}Style12{AlignHorz:Near;}FilterBar{}Style5{}Style4{}Style7{}Sty" & _
            "le6{}EvenRow{BackColor:LightSkyBlue;}Selected{ForeColor:Yellow;BackColor:Green;}" & _
            "Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlT" & _
            "ext;AlignVert:Center;}Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveC" & _
            "aption;}OddRow{}Footer{}Caption{AlignHorz:Center;}Normal{Font:Verdana, 8.25pt;}S" & _
            "tyle10{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Editor{}Record" & _
            "Selector{AlignImage:Center;}Style15{}Style9{}Style8{}Style3{}Style2{}Style14{}St" & _
            "yle13{}Style16{}Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:Control" & _
            "Dark;}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" Alt" & _
            "ernatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooter" & _
            "Height=""17"" FilterBar=""True"" MarqueeStyle=""HighlightRow"" RecordSelectorWidth=""17" & _
            """ DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>" & _
            "166</Height><CaptionStyle parent=""Heading"" me=""Style12"" /><EditorStyle parent=""E" & _
            "ditor"" me=""Style4"" /><EvenRowStyle parent=""EvenRow"" me=""Style10"" /><FilterBarSty" & _
            "le parent=""FilterBar"" me=""Style16"" /><FooterStyle parent=""Footer"" me=""Style6"" />" & _
            "<GroupStyle parent=""Group"" me=""Style15"" /><HeadingStyle parent=""Heading"" me=""Sty" & _
            "le5"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style9"" /><InactiveStyle par" & _
            "ent=""Inactive"" me=""Style8"" /><OddRowStyle parent=""OddRow"" me=""Style11"" /><Record" & _
            "SelectorStyle parent=""RecordSelector"" me=""Style14"" /><SelectedStyle parent=""Sele" & _
            "cted"" me=""Style7"" /><Style parent=""Normal"" me=""Style3"" /><ClientRect>0, 0, 1046," & _
            " 166</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1" & _
            ".Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /" & _
            "><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><St" & _
            "yle parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Sty" & _
            "le parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style p" & _
            "arent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style " & _
            "parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Sty" & _
            "le parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></Named" & _
            "Styles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout>" & _
            "<DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 1046, 166</ClientAr" & _
            "ea><PrintPageHeaderStyle parent="""" me=""Style1"" /><PrintPageFooterStyle parent=""""" & _
            " me=""Style2"" /></Blob>"
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.SteelBlue
            Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.Location = New System.Drawing.Point(8, 8)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(1048, 32)
            Me.Label3.TabIndex = 27
            Me.Label3.Text = "Model Family"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.SteelBlue
            Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.Location = New System.Drawing.Point(8, 8)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(1072, 32)
            Me.Label4.TabIndex = 28
            Me.Label4.Text = "Models"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.SteelBlue
            Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.Location = New System.Drawing.Point(8, 8)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(1048, 32)
            Me.Label5.TabIndex = 29
            Me.Label5.Text = "Product Groups"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label6
            '
            Me.Label6.BackColor = System.Drawing.Color.SteelBlue
            Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.Location = New System.Drawing.Point(8, 8)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(1048, 32)
            Me.Label6.TabIndex = 30
            Me.Label6.Text = "Report Groups"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'TabControl1
            '
            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tbModelFamilies, Me.tbProductGroups, Me.tpReportGroups})
            Me.TabControl1.Location = New System.Drawing.Point(8, 320)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(1072, 248)
            Me.TabControl1.TabIndex = 31
            '
            'tbModelFamilies
            '
            Me.tbModelFamilies.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnAddModelFamily, Me.Label3, Me.dbgCustModelFamiliesMap})
            Me.tbModelFamilies.Location = New System.Drawing.Point(4, 22)
            Me.tbModelFamilies.Name = "tbModelFamilies"
            Me.tbModelFamilies.Size = New System.Drawing.Size(1064, 222)
            Me.tbModelFamilies.TabIndex = 2
            Me.tbModelFamilies.Text = "Model Families"
            '
            'tbProductGroups
            '
            Me.tbProductGroups.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnAddGrp, Me.dbgProdGrp, Me.btnUpdateGrp, Me.Label5})
            Me.tbProductGroups.Location = New System.Drawing.Point(4, 22)
            Me.tbProductGroups.Name = "tbProductGroups"
            Me.tbProductGroups.Size = New System.Drawing.Size(1064, 222)
            Me.tbProductGroups.TabIndex = 0
            Me.tbProductGroups.Text = "Product Groups"
            '
            'tpReportGroups
            '
            Me.tpReportGroups.Controls.AddRange(New System.Windows.Forms.Control() {Me.dbgRptGrp, Me.btnUpdateRptGrp, Me.btnAddRptGrp, Me.Label6})
            Me.tpReportGroups.Location = New System.Drawing.Point(4, 22)
            Me.tpReportGroups.Name = "tpReportGroups"
            Me.tpReportGroups.Size = New System.Drawing.Size(1064, 222)
            Me.tpReportGroups.TabIndex = 1
            Me.tpReportGroups.Text = "Report Groups"
            '
            'ModManufWin
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
            Me.ClientSize = New System.Drawing.Size(1088, 574)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnAddManuf, Me.btnAddModel, Me.TabControl1, Me.Label4, Me.dbgMap, Me.lblModel, Me.cboModel, Me.lblManuf, Me.cboManuf})
            Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "ModManufWin"
            Me.Text = "Service Inventory"
            CType(Me.dbgMap, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dbgProdGrp, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dbgRptGrp, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dbgCustModelFamiliesMap, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControl1.ResumeLayout(False)
            Me.tbModelFamilies.ResumeLayout(False)
            Me.tbProductGroups.ResumeLayout(False)
            Me.tpReportGroups.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region
#Region "DECLARATIONS"

#End Region
#Region "FORM EVENTS"

        Private Sub ModManufWin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable
            Dim dr As DataRow
            Try
                Me.Cursor = Cursors.WaitCursor
                Me.Enabled = False
                PSS.Core.Highlight.SetHighLight(Me)
                PopulateManuf()
                PopulateModel()
                PopulateProgGrp()
                PopulateRptGrp()
                dt = ModManuf.GetModelsMapped
                Me.dbgMap.DataSource = dt.DefaultView
                DoFields()
                PopulateModelFamiliesMap()
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            Finally
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
                Me.Enabled = True
                Me.Cursor = Cursors.Default
            End Try
        End Sub

#End Region
#Region "CONTROL EVENTS"

        Private Sub btnAddManuf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddManuf.Click
            If ModManuf.DoManufAdd = True Then
                PopulateManuf()
            End If
        End Sub
        'Private Sub btnUpdManuf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdManuf.Click
        '    Try
        '        If Me.cboManuf.Text = "" Then
        '            MsgBox("Select a Manufacturer to update.", MsgBoxStyle.Information)
        '            Exit Sub
        '        End If
        '        If ModManuf.UpdateManuf(Me.cboManuf.GetID) = True Then
        '            PopulateManuf()
        '        End If
        '    Catch ex As Exception
        '        MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        '    End Try
        'End Sub
        Private Sub btnDelManuf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Try
                If Me.cboManuf.Text = "" Then
                    MsgBox("Select a Manufacturer to delete.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                If ModManuf.DeleteManuf(Me.cboManuf.GetID) = True Then
                    PopulateManuf()
                End If
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        End Sub
        Private Sub btnAddModel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddModel.Click
            Dim objWin As Model
            Try
                objWin = New Model(0)
                objWin.ShowDialog()

                If objWin._booCancel = False Then PopulateModel()
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            Finally
                If Not IsNothing(objWin) Then
                    objWin.Dispose()
                    objWin = Nothing
                End If
            End Try
        End Sub
        Private Sub btnDelModel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


            If Me.cboModel.Text = "" Then
                MsgBox("Select a Model to delete.", MsgBoxStyle.Information)
                Exit Sub
            Else
                Dim bxInput As String = MsgBox("You are about to delete model: " & cboModel.Text & ". Do you want to continue?", MsgBoxStyle.YesNo)
                Select Case bxInput
                    Case vbYes
                        '//Continue as normal
                    Case vbNo
                        MsgBox("Delete cancelled.")
                        Exit Sub
                    Case Else
                        MsgBox("Function failed. Delete cancelled.")
                        Exit Sub
                End Select
            End If

            Try
                If Me.cboModel.Text = "" Then
                    MsgBox("Select a Model to delete.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                If ModManuf.DeleteModel(Me.cboModel.GetID) = True Then
                    PopulateModel()
                End If
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        End Sub
        Private Sub dbgMap_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles dbgMap.RowColChange
            Try
                Me.cboManuf.Text = Trim(Me.dbgMap.Columns(2).Text)
                Me.cboModel.Text = Trim(Me.dbgMap.Columns(3).Text)
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        End Sub
        'click event that fires up when Add Report Group is clicked
        Private Sub btnAddRptGrp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddRptGrp.Click
            Try
                Dim win As New RptGrp(0)
                win.ShowDialog()
                Me.PopulateRptGrp()
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        End Sub
        Private Sub btnUpdateRptGrp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateRptGrp.Click
            'If Me.cboRptGrp.Text = "" Then
            '    MsgBox("Select a 'Report Group' to update.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If
            'Try
            '    Dim win As New RptGrp(Me.cboRptGrp.GetID)
            '    win.ShowDialog()
            '    Me.PopulateRptGrp()
            'Catch ex As Exception
            '    MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            'End Try
        End Sub
        Private Sub dbgPONeedPartList_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dbgCustModelFamiliesMap.MouseDown
            Try
                Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = DirectCast(sender, C1.Win.C1TrueDBGrid.C1TrueDBGrid)

                If dbg.RowCount = 0 Then Return

                If e.Button = MouseButtons.Right Then
                    Dim ctmCopyData As New ContextMenu()
                    Dim objCopyAll As New MenuItem()
                    Dim objCopySelected As New MenuItem()

                    objCopyAll.Text = "Copy all"
                    objCopySelected.Text = "Copy selected rows"

                    ctmCopyData.MenuItems.Add(objCopyAll)
                    ctmCopyData.MenuItems.Add(objCopySelected)

                    RemoveHandler objCopyAll.Click, AddressOf CMenuCopyAllData
                    AddHandler objCopyAll.Click, AddressOf CMenuCopyAllData
                    RemoveHandler objCopySelected.Click, AddressOf CMenuCopySelectedData
                    AddHandler objCopySelected.Click, AddressOf CMenuCopySelectedData

                    dbg.ContextMenu = ctmCopyData
                    dbg.ContextMenu.Show(dbg, New Point(e.X, e.Y))
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "grdDevice_MouseDown", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub
        'Private Sub btnUpdateGrp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateGrp.Click
        '    Try
        '        Dim win As New ProdGrp(0)
        '        win.ShowDialog()
        '        Me.PopulateProgGrp()
        '    Catch ex As Exception
        '        MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        '    End Try
        'End Sub






        Private Sub btnAddModelFamily_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddModelFamily.Click
            Dim _frm As New AddEditModelFamily()
            Try
                Me.Cursor = Cursors.WaitCursor
                _frm.ModelFamilyID = 0
                _frm.ShowDialog()
                If _frm.DialogResult = DialogResult.OK Then
                    PopulateModelFamiliesMap()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString, MessageBoxIcon.Exclamation)
            Finally
                _frm.Dispose()
                Me.Cursor = Cursors.Default
                Me.Refresh()
            End Try
        End Sub
        Private Sub dbgCustModelFamiliesMap_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dbgCustModelFamiliesMap.DoubleClick
            Dim _id As Integer
            _id = Integer.Parse(dbgCustModelFamiliesMap.Columns(0).CellText(dbgCustModelFamiliesMap.Row))
            EditModelFamily(_id)
        End Sub

        Private Sub btnAddGrp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddGrp.Click
            Dim _frm As New ProdGrp()
            Try
                Me.Cursor = Cursors.WaitCursor
                _frm.ProductGroupID = 0
                _frm.ShowDialog()
                If _frm.DialogResult = DialogResult.OK Then
                    PopulateProgGrp()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString, MessageBoxIcon.Exclamation)
            Finally
                _frm.Dispose()
                Me.Cursor = Cursors.Default
                Me.Refresh()
            End Try
        End Sub
        Private Sub dbgProdGrp_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dbgProdGrp.DoubleClick
            Dim _id As Integer
            _id = Integer.Parse(dbgProdGrp.Columns(0).CellText(dbgProdGrp.Row))
            EditProductGroup(_id)
        End Sub

        Private Sub dbgRptGrp_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dbgRptGrp.DoubleClick
            Dim _id As Integer
            _id = Integer.Parse(dbgRptGrp.Columns(0).CellText(dbgRptGrp.Row))
            EditReportGroup(_id)
        End Sub

#End Region
#Region "METHODS"

        Private Sub PopulateManuf()
            Try
                Me.cboManuf.Items.Clear()
                Me.cboManuf.Text = ""
                Dim dt As DataTable = ModManuf.PopulateManufs
                Dim r As DataRow
                For Each r In dt.Rows
                    Me.cboManuf.AddItem(r(0), r(1))
                Next
                dt.Dispose()
                dt = Nothing
                Me.dbgMap.DataSource = ModManuf.GetMapped
                DoFields()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Private Sub PopulateModel()
            Dim dt As DataTable
            Dim dr As DataRow

            Try
                Me.cboModel.Items.Clear()
                Me.cboModel.Text = ""
                dt = ModManuf.PopulateModels
                For Each dr In dt.Rows
                    Me.cboModel.AddItem(dr(0), dr(1))
                Next
                dt = ModManuf.GetModelsMapped

                dt.Columns.Add("Model Family", System.Type.GetType("System.String"))

                For Each dr In dt.Rows
                    Dim iModelID As Integer = dr("ID")
                    Dim strProductGroup As String = Data.Buisness.ModManuf.GetModelFamily(iModelID)

                    dr.BeginEdit()

                    dr("Model Family") = strProductGroup

                    dr.EndEdit()
                    dr.AcceptChanges()
                Next dr

                Me.dbgMap.DataSource = dt.DefaultView
                DoFields()
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Sub
        Private Sub DoFields()

            Dim dt As DataTable
            Dim r As DataRow
            'Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn

            Try
                If Me.cboModel.Text <> "" Then
                    dt = ModManuf.GetProdGrps(Me.cboModel.GetID)
                Else
                    dt = ModManuf.GetProdGrps()
                End If

                For Each r In dt.Rows
                    Dim item As New C1.Win.C1TrueDBGrid.ValueItem(r(0), r(1))
                    Me.dbgMap.Columns(4).ValueItems.Values.Add(item)
                    Me.dbgMap.Columns(5).ValueItems.Values.Add(item)
                Next

                Me.dbgMap.Columns(4).ValueItems.Translate = True
                Me.dbgMap.Columns(4).ValueItems.Validate = True
                Me.dbgMap.Columns(5).ValueItems.Translate = True
                Me.dbgMap.Columns(5).ValueItems.Validate = True

                'For Each dbgc In Me.dbgMap.Splits(0).DisplayColumns
                '    dbgc.Locked = True
                '    dbgc.AutoSize()
                'Next dbgc

            Catch ex As Exception
                Throw ex
            Finally
                dt.Dispose()
                dt = Nothing
            End Try

        End Sub
        Private Sub PopulateProgGrp()
            Dim dt As DataTable
            Try
                dt = ModManuf.GetProductGroups
                Dim r As DataRow
                Me.dbgProdGrp.DataSource = dt.DefaultView
            Catch ex As Exception
                Throw ex
            Finally
                dt.Dispose()
                dt = Nothing
            End Try
        End Sub
        Private Sub PopulateModelFamiliesMap()
            Dim dt As DataTable

            Try
                Me.dbgCustModelFamiliesMap.DataSource = Nothing

                dt = Data.Buisness.ModManuf.LoadModelFamiliesMap()

                If dt.Rows.Count > 0 Then
                    Me.dbgCustModelFamiliesMap.DataSource = dt.DefaultView
                    Me.dbgCustModelFamiliesMap.Splits(0).DisplayColumns("ModelFamiliesID").Visible = False
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub
        Private Sub PopulateRptGrp()
            Dim dt As DataTable
            Dim r As DataRow

            Try
                'Me.cboRptGrp.Items.Clear()
                ' Me.cboRptGrp.Text = ""
                dt = ModManuf.GetReportGroups
                'For Each r In dt.Rows
                '    Me.cboRptGrp.AddItem(r("ID"), r("Desc"))
                'Next
                Me.dbgRptGrp.DataSource = dt.DefaultView
            Catch ex As Exception
                Throw ex
            Finally
                dt.Dispose()
                dt = Nothing
            End Try
        End Sub
        Private Sub CMenuCopyAllData(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                Misc.CopyAllData(dbgCustModelFamiliesMap)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CMenuCopyData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub
        Private Sub CMenuCopySelectedData(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                Misc.CopySelectedRowsData(dbgCustModelFamiliesMap)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CMenuCopySelectedData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        Private Sub EditModelFamily(ByVal id As Integer)
            Dim _frm As New AddEditModelFamily()
            Try
                Me.Cursor = Cursors.WaitCursor
                _frm.ModelFamilyID = id
                _frm.DialogResult = DialogResult.None
                _frm.ShowDialog()
                If _frm.DialogResult = DialogResult.OK Then
                    PopulateModelFamiliesMap()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Finally
                _frm.Dispose()
                Me.Cursor = Cursors.Default
                Me.Refresh()
            End Try
        End Sub


        Private Sub EditProductGroup(ByVal id As Integer)
            Dim _frm As New Gui.ProdGrp(id)
            Try
                Me.Cursor = Cursors.WaitCursor
                _frm.ProductGroupID = id
                _frm.DialogResult = DialogResult.None
                _frm.ShowDialog()
                If _frm.DialogResult = DialogResult.OK Then
                    PopulateProgGrp()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Finally
                _frm.Dispose()
                Me.Cursor = Cursors.Default
                Me.Refresh()
            End Try
        End Sub


        Private Sub EditReportGroup(ByVal id As Integer)
            Dim _frm As New Gui.RptGrp(id)
            Try
                Me.Cursor = Cursors.WaitCursor
                _frm.ReportGroupID = id
                _frm.DialogResult = DialogResult.None
                _frm.ShowDialog()
                If _frm.DialogResult = DialogResult.OK Then
                    PopulateRptGrp()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Finally
                _frm.Dispose()
                Me.Cursor = Cursors.Default
                Me.Refresh()
            End Try
        End Sub

        Protected Sub EditMap(ByVal id As Integer)
            Dim objWin As Model
            Try
                If Me.cboModel.Text = "" Then
                    MsgBox("Select a Model to update.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                objWin = New Model(id)
                objWin.ShowDialog()
                If objWin._booCancel = False Then PopulateModel()
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            Finally
                If Not IsNothing(objWin) Then
                    objWin.Dispose()
                    objWin = Nothing
                End If
            End Try
        End Sub

#End Region

        Private Sub dbgMap_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dbgMap.DoubleClick
            Dim _id As Integer
            _id = Integer.Parse(dbgMap.Columns(0).CellText(dbgMap.Row))
            EditMap(_id)
        End Sub


    End Class
End Namespace
