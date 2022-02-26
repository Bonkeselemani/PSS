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
        Friend WithEvents btnUpdManuf As System.Windows.Forms.Button
        Friend WithEvents btnDelManuf As System.Windows.Forms.Button
        Friend WithEvents btnAddModel As System.Windows.Forms.Button
        Friend WithEvents btnUpdModel As System.Windows.Forms.Button
        Friend WithEvents btnDelModel As System.Windows.Forms.Button
        Friend WithEvents dbgProdGrp As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents cboProdGrp As PSS.Gui.Controls.ComboBox
        Friend WithEvents btnDelGrp As System.Windows.Forms.Button
        Friend WithEvents btnUpdateGrp As System.Windows.Forms.Button
        Friend WithEvents btnAddGrp As System.Windows.Forms.Button
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents dbgRptGrp As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnAddRptGrp As System.Windows.Forms.Button
        Friend WithEvents btnUpdateRptGrp As System.Windows.Forms.Button
        Friend WithEvents btnDeleteRptGrp As System.Windows.Forms.Button
        Friend WithEvents cboRptGrp As PSS.Gui.Controls.ComboBox
        Friend WithEvents dbgModelFamilies As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents ctmnModelFamiliesOption As System.Windows.Forms.ContextMenu
        Friend WithEvents btnAddModelFamily As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ModManufWin))
            Me.cboManuf = New PSS.Gui.Controls.ComboBox()
            Me.lblManuf = New System.Windows.Forms.Label()
            Me.lblModel = New System.Windows.Forms.Label()
            Me.cboModel = New PSS.Gui.Controls.ComboBox()
            Me.dbgMap = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnAddManuf = New System.Windows.Forms.Button()
            Me.btnUpdManuf = New System.Windows.Forms.Button()
            Me.btnDelManuf = New System.Windows.Forms.Button()
            Me.btnAddModel = New System.Windows.Forms.Button()
            Me.btnUpdModel = New System.Windows.Forms.Button()
            Me.btnDelModel = New System.Windows.Forms.Button()
            Me.dbgProdGrp = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cboProdGrp = New PSS.Gui.Controls.ComboBox()
            Me.btnDelGrp = New System.Windows.Forms.Button()
            Me.btnUpdateGrp = New System.Windows.Forms.Button()
            Me.btnAddGrp = New System.Windows.Forms.Button()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.cboRptGrp = New PSS.Gui.Controls.ComboBox()
            Me.btnAddRptGrp = New System.Windows.Forms.Button()
            Me.btnUpdateRptGrp = New System.Windows.Forms.Button()
            Me.btnDeleteRptGrp = New System.Windows.Forms.Button()
            Me.dbgRptGrp = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.dbgModelFamilies = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.ctmnModelFamiliesOption = New System.Windows.Forms.ContextMenu()
            Me.btnAddModelFamily = New System.Windows.Forms.Button()
            CType(Me.dbgMap, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dbgProdGrp, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dbgRptGrp, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dbgModelFamilies, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'cboManuf
            '
            Me.cboManuf.AutoComplete = True
            Me.cboManuf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboManuf.Location = New System.Drawing.Point(8, 24)
            Me.cboManuf.Name = "cboManuf"
            Me.cboManuf.Size = New System.Drawing.Size(216, 21)
            Me.cboManuf.TabIndex = 0
            '
            'lblManuf
            '
            Me.lblManuf.Location = New System.Drawing.Point(8, 8)
            Me.lblManuf.Name = "lblManuf"
            Me.lblManuf.Size = New System.Drawing.Size(184, 16)
            Me.lblManuf.TabIndex = 1
            Me.lblManuf.Text = "Manufactures:"
            '
            'lblModel
            '
            Me.lblModel.Location = New System.Drawing.Point(8, 56)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(184, 16)
            Me.lblModel.TabIndex = 3
            Me.lblModel.Text = "Models:"
            '
            'cboModel
            '
            Me.cboModel.AutoComplete = True
            Me.cboModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboModel.Location = New System.Drawing.Point(8, 72)
            Me.cboModel.Name = "cboModel"
            Me.cboModel.Size = New System.Drawing.Size(216, 21)
            Me.cboModel.TabIndex = 2
            '
            'dbgMap
            '
            Me.dbgMap.AllowUpdate = False
            Me.dbgMap.AlternatingRows = True
            Me.dbgMap.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.dbgMap.CaptionHeight = 17
            Me.dbgMap.FilterBar = True
            Me.dbgMap.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgMap.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dbgMap.Location = New System.Drawing.Point(232, 8)
            Me.dbgMap.Name = "dbgMap"
            Me.dbgMap.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgMap.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgMap.PreviewInfo.ZoomFactor = 75
            Me.dbgMap.RowHeight = 15
            Me.dbgMap.Size = New System.Drawing.Size(384, 208)
            Me.dbgMap.TabIndex = 4
            Me.dbgMap.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Style27{}Normal{Font:Verdana, 8.25pt;}Selecte" & _
            "d{ForeColor:Yellow;BackColor:Green;}Editor{}Style10{}Style11{}OddRow{}Style13{}S" & _
            "tyle12{AlignHorz:Near;}Footer{}Style29{}Style28{}HighlightRow{ForeColor:Highligh" & _
            "tText;BackColor:Highlight;}RecordSelector{AlignImage:Center;}Group{BackColor:Con" & _
            "trolDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Inactive{ForeColor:InactiveCa" & _
            "ptionText;BackColor:InactiveCaption;}EvenRow{BackColor:LightSkyBlue;}Heading{Wra" & _
            "p:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColo" & _
            "r:Control;}FilterBar{}Style9{}Style8{}Style5{}Style4{}Style7{}Style6{}Style1{}St" & _
            "yle3{}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" Alt" & _
            "ernatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooter" & _
            "Height=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth" & _
            "=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Hei" & _
            "ght>206</Height><CaptionStyle parent=""Heading"" me=""Style12"" /><EditorStyle paren" & _
            "t=""Editor"" me=""Style4"" /><EvenRowStyle parent=""EvenRow"" me=""Style10"" /><FilterBa" & _
            "rStyle parent=""FilterBar"" me=""Style29"" /><FooterStyle parent=""Footer"" me=""Style6" & _
            """ /><GroupStyle parent=""Group"" me=""Style28"" /><HeadingStyle parent=""Heading"" me=" & _
            """Style5"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style9"" /><InactiveStyle" & _
            " parent=""Inactive"" me=""Style8"" /><OddRowStyle parent=""OddRow"" me=""Style11"" /><Re" & _
            "cordSelectorStyle parent=""RecordSelector"" me=""Style27"" /><SelectedStyle parent=""" & _
            "Selected"" me=""Style7"" /><Style parent=""Normal"" me=""Style3"" /><ClientRect>0, 0, 3" & _
            "82, 206</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle><" & _
            "/C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal" & _
            """ /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" />" & _
            "<Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><" & _
            "Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Styl" & _
            "e parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Sty" & _
            "le parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><" & _
            "Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></Na" & _
            "medStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layo" & _
            "ut><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 382, 206</Client" & _
            "Area><PrintPageHeaderStyle parent="""" me=""Style1"" /><PrintPageFooterStyle parent=" & _
            """"" me=""Style2"" /></Blob>"
            '
            'btnAddManuf
            '
            Me.btnAddManuf.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnAddManuf.Location = New System.Drawing.Point(24, 104)
            Me.btnAddManuf.Name = "btnAddManuf"
            Me.btnAddManuf.Size = New System.Drawing.Size(88, 32)
            Me.btnAddManuf.TabIndex = 5
            Me.btnAddManuf.Text = "Add Manufacture"
            '
            'btnUpdManuf
            '
            Me.btnUpdManuf.Enabled = False
            Me.btnUpdManuf.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnUpdManuf.Location = New System.Drawing.Point(24, 144)
            Me.btnUpdManuf.Name = "btnUpdManuf"
            Me.btnUpdManuf.Size = New System.Drawing.Size(88, 32)
            Me.btnUpdManuf.TabIndex = 6
            Me.btnUpdManuf.Text = "Update Manufacture"
            '
            'btnDelManuf
            '
            Me.btnDelManuf.Enabled = False
            Me.btnDelManuf.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnDelManuf.Location = New System.Drawing.Point(24, 184)
            Me.btnDelManuf.Name = "btnDelManuf"
            Me.btnDelManuf.Size = New System.Drawing.Size(88, 32)
            Me.btnDelManuf.TabIndex = 7
            Me.btnDelManuf.Text = "Delete Manufacture"
            '
            'btnAddModel
            '
            Me.btnAddModel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnAddModel.Location = New System.Drawing.Point(120, 104)
            Me.btnAddModel.Name = "btnAddModel"
            Me.btnAddModel.Size = New System.Drawing.Size(88, 32)
            Me.btnAddModel.TabIndex = 8
            Me.btnAddModel.Text = "Add Model"
            '
            'btnUpdModel
            '
            Me.btnUpdModel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnUpdModel.Location = New System.Drawing.Point(120, 144)
            Me.btnUpdModel.Name = "btnUpdModel"
            Me.btnUpdModel.Size = New System.Drawing.Size(88, 32)
            Me.btnUpdModel.TabIndex = 9
            Me.btnUpdModel.Text = "Update Model"
            '
            'btnDelModel
            '
            Me.btnDelModel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnDelModel.Location = New System.Drawing.Point(120, 184)
            Me.btnDelModel.Name = "btnDelModel"
            Me.btnDelModel.Size = New System.Drawing.Size(88, 32)
            Me.btnDelModel.TabIndex = 10
            Me.btnDelModel.Text = "Delete Model"
            '
            'dbgProdGrp
            '
            Me.dbgProdGrp.AllowUpdate = False
            Me.dbgProdGrp.AlternatingRows = True
            Me.dbgProdGrp.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgProdGrp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.dbgProdGrp.CaptionHeight = 17
            Me.dbgProdGrp.FilterBar = True
            Me.dbgProdGrp.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgProdGrp.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.dbgProdGrp.Location = New System.Drawing.Point(232, 232)
            Me.dbgProdGrp.Name = "dbgProdGrp"
            Me.dbgProdGrp.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgProdGrp.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgProdGrp.PreviewInfo.ZoomFactor = 75
            Me.dbgProdGrp.RowHeight = 15
            Me.dbgProdGrp.Size = New System.Drawing.Size(152, 208)
            Me.dbgProdGrp.TabIndex = 11
            Me.dbgProdGrp.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Style27{}Normal{Font:Verdana, 8.25pt;}Selecte" & _
            "d{ForeColor:Yellow;BackColor:Green;}Editor{}Style10{}Style11{}OddRow{}Style13{}S" & _
            "tyle12{AlignHorz:Near;}Footer{}Style29{}Style28{}HighlightRow{ForeColor:Highligh" & _
            "tText;BackColor:Highlight;}RecordSelector{AlignImage:Center;}Group{AlignVert:Cen" & _
            "ter;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Inactive{ForeColor:InactiveCa" & _
            "ptionText;BackColor:InactiveCaption;}EvenRow{BackColor:LightSkyBlue;}Heading{Wra" & _
            "p:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVe" & _
            "rt:Center;}FilterBar{}Style9{}Style8{}Style5{}Style4{}Style7{}Style6{}Style1{}St" & _
            "yle3{}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" Alt" & _
            "ernatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooter" & _
            "Height=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth" & _
            "=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Hei" & _
            "ght>206</Height><CaptionStyle parent=""Heading"" me=""Style12"" /><EditorStyle paren" & _
            "t=""Editor"" me=""Style4"" /><EvenRowStyle parent=""EvenRow"" me=""Style10"" /><FilterBa" & _
            "rStyle parent=""FilterBar"" me=""Style29"" /><FooterStyle parent=""Footer"" me=""Style6" & _
            """ /><GroupStyle parent=""Group"" me=""Style28"" /><HeadingStyle parent=""Heading"" me=" & _
            """Style5"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style9"" /><InactiveStyle" & _
            " parent=""Inactive"" me=""Style8"" /><OddRowStyle parent=""OddRow"" me=""Style11"" /><Re" & _
            "cordSelectorStyle parent=""RecordSelector"" me=""Style27"" /><SelectedStyle parent=""" & _
            "Selected"" me=""Style7"" /><Style parent=""Normal"" me=""Style3"" /><ClientRect>0, 0, 1" & _
            "50, 206</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle><" & _
            "/C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal" & _
            """ /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" />" & _
            "<Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><" & _
            "Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Styl" & _
            "e parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Sty" & _
            "le parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><" & _
            "Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></Na" & _
            "medStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layo" & _
            "ut><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 150, 206</Client" & _
            "Area><PrintPageHeaderStyle parent="""" me=""Style1"" /><PrintPageFooterStyle parent=" & _
            """"" me=""Style2"" /></Blob>"
            '
            'Label1
            '
            Me.Label1.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.Label1.Location = New System.Drawing.Point(8, 264)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(184, 16)
            Me.Label1.TabIndex = 13
            Me.Label1.Text = "Product Groups:"
            '
            'cboProdGrp
            '
            Me.cboProdGrp.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.cboProdGrp.AutoComplete = True
            Me.cboProdGrp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboProdGrp.Location = New System.Drawing.Point(8, 280)
            Me.cboProdGrp.Name = "cboProdGrp"
            Me.cboProdGrp.Size = New System.Drawing.Size(216, 21)
            Me.cboProdGrp.TabIndex = 12
            '
            'btnDelGrp
            '
            Me.btnDelGrp.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.btnDelGrp.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnDelGrp.Location = New System.Drawing.Point(160, 312)
            Me.btnDelGrp.Name = "btnDelGrp"
            Me.btnDelGrp.Size = New System.Drawing.Size(64, 32)
            Me.btnDelGrp.TabIndex = 16
            Me.btnDelGrp.Text = "Delete Group"
            '
            'btnUpdateGrp
            '
            Me.btnUpdateGrp.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.btnUpdateGrp.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnUpdateGrp.Location = New System.Drawing.Point(80, 312)
            Me.btnUpdateGrp.Name = "btnUpdateGrp"
            Me.btnUpdateGrp.Size = New System.Drawing.Size(72, 32)
            Me.btnUpdateGrp.TabIndex = 15
            Me.btnUpdateGrp.Text = "Update Group"
            '
            'btnAddGrp
            '
            Me.btnAddGrp.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.btnAddGrp.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnAddGrp.Location = New System.Drawing.Point(8, 312)
            Me.btnAddGrp.Name = "btnAddGrp"
            Me.btnAddGrp.Size = New System.Drawing.Size(64, 32)
            Me.btnAddGrp.TabIndex = 14
            Me.btnAddGrp.Text = "Add Group"
            '
            'Label2
            '
            Me.Label2.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.Label2.Location = New System.Drawing.Point(8, 360)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(184, 16)
            Me.Label2.TabIndex = 17
            Me.Label2.Text = "Report Groups:"
            '
            'cboRptGrp
            '
            Me.cboRptGrp.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.cboRptGrp.AutoComplete = True
            Me.cboRptGrp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboRptGrp.Location = New System.Drawing.Point(8, 376)
            Me.cboRptGrp.Name = "cboRptGrp"
            Me.cboRptGrp.Size = New System.Drawing.Size(216, 21)
            Me.cboRptGrp.TabIndex = 18
            '
            'btnAddRptGrp
            '
            Me.btnAddRptGrp.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.btnAddRptGrp.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnAddRptGrp.Location = New System.Drawing.Point(8, 408)
            Me.btnAddRptGrp.Name = "btnAddRptGrp"
            Me.btnAddRptGrp.Size = New System.Drawing.Size(64, 32)
            Me.btnAddRptGrp.TabIndex = 19
            Me.btnAddRptGrp.Text = "Add Group"
            '
            'btnUpdateRptGrp
            '
            Me.btnUpdateRptGrp.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.btnUpdateRptGrp.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnUpdateRptGrp.Location = New System.Drawing.Point(80, 408)
            Me.btnUpdateRptGrp.Name = "btnUpdateRptGrp"
            Me.btnUpdateRptGrp.Size = New System.Drawing.Size(72, 32)
            Me.btnUpdateRptGrp.TabIndex = 20
            Me.btnUpdateRptGrp.Text = "Update Group"
            '
            'btnDeleteRptGrp
            '
            Me.btnDeleteRptGrp.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.btnDeleteRptGrp.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnDeleteRptGrp.Location = New System.Drawing.Point(160, 408)
            Me.btnDeleteRptGrp.Name = "btnDeleteRptGrp"
            Me.btnDeleteRptGrp.Size = New System.Drawing.Size(64, 32)
            Me.btnDeleteRptGrp.TabIndex = 21
            Me.btnDeleteRptGrp.Text = "Delete Group"
            '
            'dbgRptGrp
            '
            Me.dbgRptGrp.AllowUpdate = False
            Me.dbgRptGrp.AlternatingRows = True
            Me.dbgRptGrp.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgRptGrp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.dbgRptGrp.CaptionHeight = 17
            Me.dbgRptGrp.FilterBar = True
            Me.dbgRptGrp.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgRptGrp.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.dbgRptGrp.Location = New System.Drawing.Point(392, 232)
            Me.dbgRptGrp.Name = "dbgRptGrp"
            Me.dbgRptGrp.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgRptGrp.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgRptGrp.PreviewInfo.ZoomFactor = 75
            Me.dbgRptGrp.RowHeight = 15
            Me.dbgRptGrp.Size = New System.Drawing.Size(224, 208)
            Me.dbgRptGrp.TabIndex = 22
            Me.dbgRptGrp.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Style27{}Normal{Font:Verdana, 8.25pt;}Selecte" & _
            "d{ForeColor:Yellow;BackColor:Green;}Editor{}Style10{}Style11{}OddRow{}Style13{}S" & _
            "tyle12{AlignHorz:Near;}Footer{}Style29{}Style28{}HighlightRow{ForeColor:Highligh" & _
            "tText;BackColor:Highlight;}RecordSelector{AlignImage:Center;}Group{BackColor:Con" & _
            "trolDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Inactive{ForeColor:InactiveCa" & _
            "ptionText;BackColor:InactiveCaption;}EvenRow{BackColor:LightSkyBlue;}Heading{Wra" & _
            "p:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColo" & _
            "r:Control;}FilterBar{}Style9{}Style8{}Style5{}Style4{}Style7{}Style6{}Style1{}St" & _
            "yle3{}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" Alt" & _
            "ernatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooter" & _
            "Height=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth" & _
            "=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Hei" & _
            "ght>206</Height><CaptionStyle parent=""Heading"" me=""Style12"" /><EditorStyle paren" & _
            "t=""Editor"" me=""Style4"" /><EvenRowStyle parent=""EvenRow"" me=""Style10"" /><FilterBa" & _
            "rStyle parent=""FilterBar"" me=""Style29"" /><FooterStyle parent=""Footer"" me=""Style6" & _
            """ /><GroupStyle parent=""Group"" me=""Style28"" /><HeadingStyle parent=""Heading"" me=" & _
            """Style5"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style9"" /><InactiveStyle" & _
            " parent=""Inactive"" me=""Style8"" /><OddRowStyle parent=""OddRow"" me=""Style11"" /><Re" & _
            "cordSelectorStyle parent=""RecordSelector"" me=""Style27"" /><SelectedStyle parent=""" & _
            "Selected"" me=""Style7"" /><Style parent=""Normal"" me=""Style3"" /><ClientRect>0, 0, 2" & _
            "22, 206</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle><" & _
            "/C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal" & _
            """ /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" />" & _
            "<Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><" & _
            "Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Styl" & _
            "e parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Sty" & _
            "le parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><" & _
            "Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></Na" & _
            "medStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layo" & _
            "ut><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 222, 206</Client" & _
            "Area><PrintPageHeaderStyle parent="""" me=""Style1"" /><PrintPageFooterStyle parent=" & _
            """"" me=""Style2"" /></Blob>"
            '
            'dbgModelFamilies
            '
            Me.dbgModelFamilies.AllowUpdate = False
            Me.dbgModelFamilies.AlternatingRows = True
            Me.dbgModelFamilies.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.dbgModelFamilies.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.dbgModelFamilies.CaptionHeight = 17
            Me.dbgModelFamilies.FilterBar = True
            Me.dbgModelFamilies.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgModelFamilies.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.dbgModelFamilies.Location = New System.Drawing.Point(232, 456)
            Me.dbgModelFamilies.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.dbgModelFamilies.Name = "dbgModelFamilies"
            Me.dbgModelFamilies.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgModelFamilies.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgModelFamilies.PreviewInfo.ZoomFactor = 75
            Me.dbgModelFamilies.RowHeight = 15
            Me.dbgModelFamilies.Size = New System.Drawing.Size(192, 208)
            Me.dbgModelFamilies.TabIndex = 23
            Me.dbgModelFamilies.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Normal{Font:Verdana, 8.25pt;}Selected{ForeCol" & _
            "or:Yellow;BackColor:Green;}Editor{}Style14{}Style15{}Style16{}Style10{}Style11{}" & _
            "OddRow{}FilterBar{}Style12{AlignHorz:Near;}Style13{}HighlightRow{ForeColor:Highl" & _
            "ightText;BackColor:Highlight;}RecordSelector{AlignImage:Center;}Footer{}Group{Al" & _
            "ignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Inactive{ForeColor" & _
            ":InactiveCaptionText;BackColor:InactiveCaption;}EvenRow{BackColor:LightSkyBlue;}" & _
            "Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlT" & _
            "ext;AlignVert:Center;}Style9{}Style8{}Style5{}Style7{}Style4{}Style6{}Style1{}St" & _
            "yle3{}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" Alt" & _
            "ernatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooter" & _
            "Height=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth" & _
            "=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Hei" & _
            "ght>206</Height><CaptionStyle parent=""Heading"" me=""Style12"" /><EditorStyle paren" & _
            "t=""Editor"" me=""Style4"" /><EvenRowStyle parent=""EvenRow"" me=""Style10"" /><FilterBa" & _
            "rStyle parent=""FilterBar"" me=""Style16"" /><FooterStyle parent=""Footer"" me=""Style6" & _
            """ /><GroupStyle parent=""Group"" me=""Style15"" /><HeadingStyle parent=""Heading"" me=" & _
            """Style5"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style9"" /><InactiveStyle" & _
            " parent=""Inactive"" me=""Style8"" /><OddRowStyle parent=""OddRow"" me=""Style11"" /><Re" & _
            "cordSelectorStyle parent=""RecordSelector"" me=""Style14"" /><SelectedStyle parent=""" & _
            "Selected"" me=""Style7"" /><Style parent=""Normal"" me=""Style3"" /><ClientRect>0, 0, 1" & _
            "90, 206</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle><" & _
            "/C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal" & _
            """ /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" />" & _
            "<Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><" & _
            "Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Styl" & _
            "e parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Sty" & _
            "le parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><" & _
            "Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></Na" & _
            "medStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layo" & _
            "ut><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 190, 206</Client" & _
            "Area><PrintPageHeaderStyle parent="""" me=""Style1"" /><PrintPageFooterStyle parent=" & _
            """"" me=""Style2"" /></Blob>"
            '
            'btnAddModelFamily
            '
            Me.btnAddModelFamily.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.btnAddModelFamily.Location = New System.Drawing.Point(48, 624)
            Me.btnAddModelFamily.Name = "btnAddModelFamily"
            Me.btnAddModelFamily.Size = New System.Drawing.Size(128, 40)
            Me.btnAddModelFamily.TabIndex = 24
            Me.btnAddModelFamily.Text = "Add Model Family"
            '
            'ModManufWin
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
            Me.ClientSize = New System.Drawing.Size(624, 670)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnAddModelFamily, Me.dbgModelFamilies, Me.dbgRptGrp, Me.btnDeleteRptGrp, Me.btnUpdateRptGrp, Me.btnAddRptGrp, Me.cboRptGrp, Me.Label2, Me.btnDelGrp, Me.btnUpdateGrp, Me.btnAddGrp, Me.Label1, Me.cboProdGrp, Me.dbgProdGrp, Me.btnDelModel, Me.btnUpdModel, Me.btnAddModel, Me.btnDelManuf, Me.btnUpdManuf, Me.btnAddManuf, Me.dbgMap, Me.lblModel, Me.cboModel, Me.lblManuf, Me.cboManuf})
            Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "ModManufWin"
            Me.Text = "Models / Manufactures"
            CType(Me.dbgMap, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dbgProdGrp, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dbgRptGrp, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dbgModelFamilies, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

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

                dt.Columns.Add("Model Family", System.Type.GetType("System.String"))

                For Each dr In dt.Rows
                    Dim iModelID As Integer = dr("ID")
                    Dim strModelFamily As String = ModManuf.GetModelFamily(iModelID)

                    dr.BeginEdit()

                    dr("Model Family") = strModelFamily

                    dr.EndEdit()
                    dr.AcceptChanges()
                Next dr

                Me.dbgMap.DataSource = dt.DefaultView
                'Me.dbgMap.DataSource = ModManuf.GetMapped
                DoFields()
                PopulateModelFamilies()
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

        Private Sub btnAddManuf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddManuf.Click
            If ModManuf.DoManufAdd = True Then
                PopulateManuf()
            End If
        End Sub

        Private Sub btnUpdManuf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdManuf.Click
            Try
                If Me.cboManuf.Text = "" Then
                    MsgBox("Select a Manufacturer to update.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                If ModManuf.UpdateManuf(Me.cboManuf.GetID) = True Then
                    PopulateManuf()
                End If
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        End Sub
        'Private Sub btnUpdManuf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdManuf.Click
        '    If ModManuf.UpdateManuf(Me.cboManuf.GetID) = True Then
        '        PopulateManuf()
        '    End If
        'End Sub

        Private Sub btnDelManuf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelManuf.Click
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
        'Private Sub btnDelManuf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelManuf.Click
        '    If ModManuf.DeleteManuf(Me.cboManuf.GetID) = True Then
        '        PopulateManuf()
        '    End If
        'End Sub

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
                    Dim strModelFamily As String = ModManuf.GetModelFamily(iModelID)

                    dr.BeginEdit()

                    dr("Model Family") = strModelFamily

                    dr.EndEdit()
                    dr.AcceptChanges()
                Next dr

                Me.dbgMap.DataSource = dt.DefaultView
                'Me.dbgMap.DataSource = ModManuf.GetMapped
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

        Private Sub btnAddModel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddModel.Click
            'Dim i As Boolean

            'If ModManuf.DoModelAdd(Me.cboManuf.GetID) = True Then
            '    PopulateModel()
            'End If

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

        Private Sub btnUpdModel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdModel.Click
            Dim objWin As Model

            Try
                If Me.cboModel.Text = "" Then
                    MsgBox("Select a Model to update.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                'If ModManuf.UpdateModel(Me.cboManuf.GetID, Me.cboModel.GetID) = True Then
                '    PopulateModel()
                'End If

                objWin = New Model(Me.cboModel.GetID)
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
        'Private Sub btnUpdModel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdModel.Click
        '    If ModManuf.UpdateModel(Me.cboManuf.GetID, Me.cboModel.GetID) = True Then
        '        PopulateModel()
        '    End If
        'End Sub

        Private Sub btnDelModel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelModel.Click


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
        'Private Sub btnDelModel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelModel.Click
        '    If ModManuf.DeleteModel(Me.cboModel.GetID) = True Then
        '        PopulateModel()
        '    End If
        'End Sub

        Private Sub dbgMap_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles dbgMap.RowColChange
            Try
                Me.cboManuf.Text = Trim(Me.dbgMap.Columns(2).Text)
                Me.cboModel.Text = Trim(Me.dbgMap.Columns(3).Text)
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        End Sub

        Private Sub DoFields()

            Dim dt As DataTable
            Dim r As DataRow

            'MsgBox(Me.cboModel.Text)
            'Exit Sub
            'Dim dt As DataTable = ModManuf.GetProdGrps()
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
                Me.cboProdGrp.Items.Clear()
                Me.cboProdGrp.Text = ""
                dt = ModManuf.GetProductGroups
                Dim r As DataRow
                For Each r In dt.Rows
                    Me.cboProdGrp.AddItem(r(0), r(2))
                Next
                Me.dbgProdGrp.DataSource = dt.DefaultView
            Catch ex As Exception
                Throw ex
            Finally
                dt.Dispose()
                dt = Nothing
            End Try
        End Sub

        Private Sub dbgProdGrp_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles dbgProdGrp.RowColChange
            Try
                Me.cboProdGrp.Text = Trim(Me.dbgProdGrp.Columns(2).Text)
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        End Sub

        Private Sub btnUpdateGrp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateGrp.Click
            If Me.cboProdGrp.Text = "" Then
                MsgBox("Select a 'Product Group' to update.", MsgBoxStyle.Information)
                Exit Sub
            End If
            Try

                Dim win As New ProdGrp(Me.cboProdGrp.GetID)
                win.ShowDialog()
                Me.PopulateProgGrp()
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        End Sub
        'Private Sub btnUpdateGrp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateGrp.Click
        '    Dim win As New ProdGrp(Me.cboProdGrp.GetID)
        '    win.ShowDialog()
        '    Me.PopulateProgGrp()
        'End Sub

        Private Sub btnAddGrp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddGrp.Click
            Try
                Dim win As New ProdGrp(0)
                win.ShowDialog()
                Me.PopulateProgGrp()
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        End Sub


        Private Sub btnDelGrp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelGrp.Click
            If Me.cboProdGrp.Text = "" Then
                MsgBox("Select a 'Product Group' to delete.", MsgBoxStyle.Information)
                Exit Sub
            End If
            Try
                ModManuf.DeleteProductGroup(Me.cboProdGrp.GetID)
                Me.PopulateProgGrp()
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        End Sub
        'Private Sub btnDelGrp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelGrp.Click
        '    Try
        '        ModManuf.DeleteProductGroup(Me.cboProdGrp.GetID)
        '        Me.PopulateProgGrp()
        '    Finally
        '    End Try
        'End Sub

        '**********************************************************************************************
        'This code is added by Asif on 12/04/2003
        '**********************************************************************************************
        'This sub function Populated the Report group combo box and Report Group datagrid
        Private Sub PopulateRptGrp()
            Dim dt As DataTable
            Dim r As DataRow

            Try
                Me.cboRptGrp.Items.Clear()
                Me.cboRptGrp.Text = ""
                dt = ModManuf.GetReportGroups
                For Each r In dt.Rows
                    Me.cboRptGrp.AddItem(r("ID"), r("Desc"))
                Next
                Me.dbgRptGrp.DataSource = dt.DefaultView
            Catch ex As Exception
                Throw ex
            Finally
                dt.Dispose()
                dt = Nothing
            End Try
        End Sub

        'This row column change event fires up when a different column or row is clicked
        Private Sub dbgRptGrp_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles dbgRptGrp.RowColChange
            Try
                Me.cboRptGrp.Text = Trim(Me.dbgRptGrp.Columns("Desc").Text)
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
            If Me.cboRptGrp.Text = "" Then
                MsgBox("Select a 'Report Group' to update.", MsgBoxStyle.Information)
                Exit Sub
            End If
            Try
                Dim win As New RptGrp(Me.cboRptGrp.GetID)
                win.ShowDialog()
                Me.PopulateRptGrp()
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        End Sub

        'Click event that fires up when update Report Group is clicked
        'Private Sub btnUpdateRptGrp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateRptGrp.Click
        '    Dim win As New RptGrp(Me.cboRptGrp.GetID)
        '    win.ShowDialog()
        '    Me.PopulateRptGrp()
        'End Sub

        Private Sub btnDeleteRptGrp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteRptGrp.Click
            If Me.cboRptGrp.Text = "" Then
                MsgBox("Select a 'Report Group' to delete.", MsgBoxStyle.Information)
                Exit Sub
            End If
            Try
                'ModManuf.DeleteProductGroup(Me.cboProdGrp.GetID)
                ModManuf.DeleteReportGroup(Me.cboRptGrp.GetID)
                Me.PopulateRptGrp()
            Catch ex As Exception
                MsgBox("Error in deleting Report Group. " & ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        End Sub

        'click event that fires up when Delete Report is clicked
        'Private Sub btnDeleteRptGrp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteRptGrp.Click
        '    Try
        '        'ModManuf.DeleteProductGroup(Me.cboProdGrp.GetID)
        '        ModManuf.DeleteReportGroup(Me.cboRptGrp.GetID)
        '        Me.PopulateRptGrp()
        '    Catch ex As Exception
        '        MsgBox("Error in deleting Report Group. " & ex.Message.ToString, MsgBoxStyle.Critical)
        '    End Try
        'End Sub


        '**********************************************************************************************

        Private Sub PopulateModelFamilies()
            Dim dt As DataTable

            Try
                Me.dbgModelFamilies.DataSource = Nothing

                dt = ModManuf.GetModelFamilies()

                If dt.Rows.Count > 0 Then
                    Me.dbgModelFamilies.DataSource = dt.DefaultView
                    Me.dbgModelFamilies.Splits(0).DisplayColumns("ModelFamiliesID").Visible = False
                    'Me.dbgModelFamilies.Splits(0).DisplayColumns("Customer").AutoSize()
                    Me.dbgModelFamilies.Splits(0).DisplayColumns("Family").AutoSize()
                End If
            Catch ex As Exception
                Throw ex
            Finally
                dt.Dispose()
                dt = Nothing
            End Try
        End Sub

        Private Sub ModelFamiliesMouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dbgModelFamilies.MouseHover
            Dim tp As New ToolTip()

            Try
                tp.InitialDelay = 500
                tp.AutomaticDelay = 1000
                tp.AutoPopDelay = 1000
                tp.SetToolTip(Me.dbgModelFamilies, "Right click on a selected row to view customer/family options.")
            Catch ex As Exception
                MsgBox("Error in ModelFamiliesMouseHover(). " & ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        End Sub

        Private Sub ModelFamiliesRightClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dbgModelFamilies.MouseDown
            Try
                If Me.dbgModelFamilies.SelectedRows.Count > 0 And e.Button = MouseButtons.Right Then
                    'Dim strMenuItems() As String = {"Add new customer/model family", String.Format("Edit {0} - {1}", Me.dbgModelFamilies.Columns("Customer").Text, Me.dbgModelFamilies.Columns("Family").Text), String.Format("Delete {0} - {1}", Me.dbgModelFamilies.Columns("Customer").Text, Me.dbgModelFamilies.Columns("Family").Text)}
                    Dim strMenuItems() As String = {String.Format("Edit {0}", Me.dbgModelFamilies.Columns("Family").Text), String.Format("Delete {0}", Me.dbgModelFamilies.Columns("Family").Text)}
                    Dim strMenuItem As String
                    Me.ctmnModelFamiliesOption.MenuItems.Clear()

                    For Each strMenuItem In strMenuItems
                        Dim objMenuItem As New MenuItem(strMenuItem)

                        Me.ctmnModelFamiliesOption.MenuItems.Add(objMenuItem)
                        AddHandler objMenuItem.Click, AddressOf CMenuClick
                    Next strMenuItem

                    Me.ctmnModelFamiliesOption.Show(Me.dbgModelFamilies, New Point(e.X, e.Y))
                End If
            Catch ex As Exception
                MsgBox("Error in ModelFamiliesRightClick(). " & ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        End Sub

        Private Sub CMenuClick(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                Me.Cursor = Cursors.WaitCursor
                Me.Enabled = False

                Dim objCurMenuItem As MenuItem = CType(sender, MenuItem)

                Select Case objCurMenuItem.Text.Substring(0, objCurMenuItem.Text.IndexOf(" ")).ToLower
                    'Case "add"
                    '    Dim frmAEMF As New AddEditModelFamily(True, 0, String.Empty, String.Empty)

                    '    frmAEMF.StartPosition = FormStartPosition.CenterScreen
                    '    frmAEMF.ShowDialog()

                    Case "edit"
                        Dim iModelFamilyID As Integer = Convert.ToInt32(Me.dbgModelFamilies.Columns("ModelFamiliesID").Text)
                        Dim frmAEMF As New AddEditModelFamily(False, iModelFamilyID, Me.dbgModelFamilies.Columns("Family").Text)

                        frmAEMF.StartPosition = FormStartPosition.CenterScreen
                        frmAEMF.ShowDialog()

                        If Not frmAEMF.CancelProcess() Then
                            PopulateModel()
                            PopulateModelFamilies()
                        End If

                    Case "delete"
                            Dim strPrompt As String = String.Format("{0}?", objCurMenuItem.Text)
                            Dim iModelFamilyID As Integer = Convert.ToInt32(Me.dbgModelFamilies.Columns("ModelFamiliesID").Text)
                            Dim iCount As Integer = ModManuf.GetModelCountForModelFamily(iModelFamilyID)

                            strPrompt &= String.Format("  It contains {0} model{1}.", iCount, IIf(iCount = 1, String.Empty, "s"))

                            If MsgBox(strPrompt, MsgBoxStyle.YesNo Or MsgBoxStyle.Question Or MsgBoxStyle.DefaultButton2, "Delete Customer/Model Family") = MsgBoxResult.Yes Then
                            ModManuf.DeleteModelFamily(iModelFamilyID)
                                PopulateModel()
                                PopulateModelFamilies()
                            End If
                End Select
            Catch ex As Exception
                MsgBox("Error in CMenuClick(). " & ex.Message.ToString, MsgBoxStyle.Critical)
            Finally
                Me.Enabled = True
                Me.Cursor = Cursors.Default
            End Try
        End Sub


        Private Sub btnAddModelFamily_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddModelFamily.Click
            Try
                Me.Cursor = Cursors.WaitCursor
                Me.Enabled = False

                Dim frmAEMF As New AddEditModelFamily(True, 0, String.Empty)

                frmAEMF.MdiParent = Me.MdiParent
                frmAEMF.StartPosition = FormStartPosition.CenterParent
                frmAEMF.ShowDialog()

                If Not frmAEMF.CancelProcess() Then
                    PopulateModel()
                    PopulateModelFamilies()
                End If
            Catch ex As Exception
                MsgBox("Error in btnAddModelFamily_Click(). " & ex.Message.ToString, MsgBoxStyle.Critical)
            Finally
                Me.Enabled = True
                Me.Cursor = Cursors.Default
            End Try
        End Sub
    End Class

End Namespace
