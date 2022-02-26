Option Explicit On

Imports PSS.Data.Buisness
Imports System.Windows.Forms

Public Class frmPackingSlip
    Inherits System.Windows.Forms.Form

    Private _objPkSlip As PSS.Data.Buisness.PackingSlip
    Private _dsTable As DataSet

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me._objPkSlip = New PSS.Data.Buisness.PackingSlip()
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
    Friend WithEvents cmbCustomer As ComboBox
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents grdPkSlip As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents grdInvPkSlip As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents grdPkSlipPalletInfo As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents lblInstruction As System.Windows.Forms.Label
    Friend WithEvents btnMoveUp As System.Windows.Forms.Button
    Friend WithEvents btnMoveDown As System.Windows.Forms.Button
    Friend WithEvents btnCreateInvRpt As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPackingSlip))
        Me.lblCustomer = New System.Windows.Forms.Label()
        Me.cmbCustomer = New ComboBox()
        Me.grdPkSlip = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.btnMoveUp = New System.Windows.Forms.Button()
        Me.btnMoveDown = New System.Windows.Forms.Button()
        Me.grdInvPkSlip = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.grdPkSlipPalletInfo = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.lblInstruction = New System.Windows.Forms.Label()
        Me.btnCreateInvRpt = New System.Windows.Forms.Button()
        CType(Me.grdPkSlip, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdInvPkSlip, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdPkSlipPalletInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblCustomer
        '
        Me.lblCustomer.BackColor = System.Drawing.Color.Transparent
        Me.lblCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomer.ForeColor = System.Drawing.Color.White
        Me.lblCustomer.Location = New System.Drawing.Point(328, 11)
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.Size = New System.Drawing.Size(80, 16)
        Me.lblCustomer.TabIndex = 13
        Me.lblCustomer.Text = "Customer :  "
        Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbCustomer
        '
        'Me.cmbCustomer.AutoComplete = True
        Me.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCustomer.Location = New System.Drawing.Point(408, 8)
        Me.cmbCustomer.Name = "cmbCustomer"
        Me.cmbCustomer.Size = New System.Drawing.Size(224, 24)
        Me.cmbCustomer.TabIndex = 12
        '
        'grdPkSlip
        '
        Me.grdPkSlip.AllowColMove = False
        Me.grdPkSlip.AllowColSelect = False
        Me.grdPkSlip.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.grdPkSlip.AllowUpdate = False
        Me.grdPkSlip.AllowUpdateOnBlur = False
        Me.grdPkSlip.AlternatingRows = True
        Me.grdPkSlip.BackColor = System.Drawing.Color.SteelBlue
        Me.grdPkSlip.FilterBar = True
        Me.grdPkSlip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdPkSlip.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdPkSlip.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.grdPkSlip.Location = New System.Drawing.Point(336, 56)
        Me.grdPkSlip.MaintainRowCurrency = True
        Me.grdPkSlip.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
        Me.grdPkSlip.Name = "grdPkSlip"
        Me.grdPkSlip.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdPkSlip.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdPkSlip.PreviewInfo.ZoomFactor = 75
        Me.grdPkSlip.RowHeight = 20
        Me.grdPkSlip.Size = New System.Drawing.Size(296, 176)
        Me.grdPkSlip.TabIndex = 133
        Me.grdPkSlip.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Transparent;}Se" & _
        "lected{ForeColor:ControlText;BackColor:Yellow;}Style3{}Inactive{ForeColor:Inacti" & _
        "veCaptionText;BackColor:InactiveCaption;}FilterBar{ForeColor:Red;BackColor:Trans" & _
        "parent;}Footer{}Caption{AlignHorz:Center;ForeColor:White;BackColor:Transparent;}" & _
        "Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt;BackColor:Control;AlignVert:Cen" & _
        "ter;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddRow{B" & _
        "ackColor:Transparent;}RecordSelector{AlignImage:Center;}Style13{}Heading{Wrap:Tr" & _
        "ue;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;AlignVert:Cent" & _
        "er;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:SteelBlue;}Style8{}" & _
        "Style10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style1{}</Data></Styles><Spli" & _
        "ts><C1.Win.C1TrueDBGrid.MergeView HBarHeight=""10"" AllowColMove=""False"" AllowColS" & _
        "elect=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""True"" CaptionHe" & _
        "ight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" Marq" & _
        "ueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Vertica" & _
        "lScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>172</Height><CaptionStyle par" & _
        "ent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowS" & _
        "tyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style" & _
        "13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""" & _
        "Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle paren" & _
        "t=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><O" & _
        "ddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSele" & _
        "ctor"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style paren" & _
        "t=""Normal"" me=""Style1"" /><ClientRect>0, 0, 292, 172</ClientRect><BorderSide>0</B" & _
        "orderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Spl" & _
        "its><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Headi" & _
        "ng"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption""" & _
        " /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" " & _
        "/><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" " & _
        "/><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><St" & _
        "yle parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar""" & _
        " /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits>" & _
        "<horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRe" & _
        "cSelWidth><ClientArea>0, 0, 292, 172</ClientArea><PrintPageHeaderStyle parent=""""" & _
        " me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
        '
        'Splitter1
        '
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 518)
        Me.Splitter1.TabIndex = 134
        Me.Splitter1.TabStop = False
        '
        'btnMoveUp
        '
        Me.btnMoveUp.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnMoveUp.BackgroundImage = CType(resources.GetObject("btnMoveUp.BackgroundImage"), System.Drawing.Bitmap)
        Me.btnMoveUp.Location = New System.Drawing.Point(408, 240)
        Me.btnMoveUp.Name = "btnMoveUp"
        Me.btnMoveUp.Size = New System.Drawing.Size(32, 32)
        Me.btnMoveUp.TabIndex = 135
        '
        'btnMoveDown
        '
        Me.btnMoveDown.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnMoveDown.BackgroundImage = CType(resources.GetObject("btnMoveDown.BackgroundImage"), System.Drawing.Bitmap)
        Me.btnMoveDown.Location = New System.Drawing.Point(504, 240)
        Me.btnMoveDown.Name = "btnMoveDown"
        Me.btnMoveDown.Size = New System.Drawing.Size(32, 32)
        Me.btnMoveDown.TabIndex = 136
        '
        'grdInvPkSlip
        '
        Me.grdInvPkSlip.AllowColMove = False
        Me.grdInvPkSlip.AllowColSelect = False
        Me.grdInvPkSlip.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.grdInvPkSlip.AllowUpdate = False
        Me.grdInvPkSlip.AllowUpdateOnBlur = False
        Me.grdInvPkSlip.AlternatingRows = True
        Me.grdInvPkSlip.BackColor = System.Drawing.Color.SteelBlue
        Me.grdInvPkSlip.FilterBar = True
        Me.grdInvPkSlip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdInvPkSlip.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdInvPkSlip.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
        Me.grdInvPkSlip.Location = New System.Drawing.Point(336, 280)
        Me.grdInvPkSlip.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.grdInvPkSlip.Name = "grdInvPkSlip"
        Me.grdInvPkSlip.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdInvPkSlip.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdInvPkSlip.PreviewInfo.ZoomFactor = 75
        Me.grdInvPkSlip.RowHeight = 20
        Me.grdInvPkSlip.Size = New System.Drawing.Size(296, 176)
        Me.grdInvPkSlip.TabIndex = 3
        Me.grdInvPkSlip.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Transparent;}Se" & _
        "lected{ForeColor:HighlightText;BackColor:Yellow;}Style3{}Inactive{ForeColor:Inac" & _
        "tiveCaptionText;BackColor:InactiveCaption;}FilterBar{ForeColor:Red;BackColor:Tra" & _
        "nsparent;}Footer{}Caption{AlignHorz:Center;}Style1{}Normal{Font:Microsoft Sans S" & _
        "erif, 8.25pt;AlignVert:Center;BackColor:Control;}HighlightRow{ForeColor:Highligh" & _
        "tText;BackColor:LightSteelBlue;}Style14{}OddRow{BackColor:Transparent;}RecordSel" & _
        "ector{AlignImage:Center;}Style15{}Heading{Wrap:True;Font:Microsoft Sans Serif, 8" & _
        ".25pt, style=Bold;AlignHorz:Center;AlignVert:Center;Border:Raised,,1, 1, 1, 1;Fo" & _
        "reColor:ControlText;BackColor:SteelBlue;}Style8{}Style10{AlignHorz:Near;}Style11" & _
        "{}Style12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeVi" & _
        "ew HBarHeight=""10"" AllowColMove=""False"" AllowColSelect=""False"" Name="""" AllowRowS" & _
        "izing=""None"" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""" & _
        "17"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" Rec" & _
        "ordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScro" & _
        "llGroup=""1""><Height>172</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><Ed" & _
        "itorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style" & _
        "8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Foot" & _
        "er"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent" & _
        "=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" />" & _
        "<InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""" & _
        "Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedS" & _
        "tyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><Clien" & _
        "tRect>0, 0, 292, 172</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</" & _
        "BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent=" & _
        """"" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" m" & _
        "e=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""" & _
        "Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Ed" & _
        "itor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""Ev" & _
        "enRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""Record" & _
        "Selector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""" & _
        "Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layo" & _
        "ut>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 292" & _
        ", 172</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageFoote" & _
        "rStyle parent="""" me=""Style15"" /></Blob>"
        '
        'grdPkSlipPalletInfo
        '
        Me.grdPkSlipPalletInfo.AllowArrows = False
        Me.grdPkSlipPalletInfo.AllowColMove = False
        Me.grdPkSlipPalletInfo.AllowColSelect = False
        Me.grdPkSlipPalletInfo.AllowFilter = False
        Me.grdPkSlipPalletInfo.AllowRowSelect = False
        Me.grdPkSlipPalletInfo.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.grdPkSlipPalletInfo.AllowUpdate = False
        Me.grdPkSlipPalletInfo.AllowUpdateOnBlur = False
        Me.grdPkSlipPalletInfo.AlternatingRows = True
        Me.grdPkSlipPalletInfo.BackColor = System.Drawing.Color.Black
        Me.grdPkSlipPalletInfo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grdPkSlipPalletInfo.CollapseColor = System.Drawing.Color.White
        Me.grdPkSlipPalletInfo.ExpandColor = System.Drawing.Color.White
        Me.grdPkSlipPalletInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdPkSlipPalletInfo.ForeColor = System.Drawing.Color.White
        Me.grdPkSlipPalletInfo.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdPkSlipPalletInfo.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
        Me.grdPkSlipPalletInfo.Location = New System.Drawing.Point(8, 8)
        Me.grdPkSlipPalletInfo.MaintainRowCurrency = True
        Me.grdPkSlipPalletInfo.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.grdPkSlipPalletInfo.Name = "grdPkSlipPalletInfo"
        Me.grdPkSlipPalletInfo.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdPkSlipPalletInfo.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdPkSlipPalletInfo.PreviewInfo.ZoomFactor = 75
        Me.grdPkSlipPalletInfo.RecordSelectors = False
        Me.grdPkSlipPalletInfo.RowHeight = 20
        Me.grdPkSlipPalletInfo.Size = New System.Drawing.Size(312, 496)
        Me.grdPkSlipPalletInfo.TabIndex = 137
        Me.grdPkSlipPalletInfo.Visible = False
        Me.grdPkSlipPalletInfo.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Black;}Selected" & _
        "{ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:White;B" & _
        "ackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Center;ForeColor:" & _
        "White;}Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignVert:Ce" & _
        "nter;ForeColor:White;BackColor:LightSteelBlue;}HighlightRow{ForeColor:HighlightT" & _
        "ext;BackColor:Highlight;}Style14{}OddRow{BackColor:Black;}RecordSelector{ForeCol" & _
        "or:White;AlignImage:Center;}Style15{}Heading{Wrap:True;Font:Microsoft Sans Serif" & _
        ", 8.25pt, style=Bold;AlignHorz:Center;AlignVert:Center;Border:Raised,,1, 1, 1, 1" & _
        ";ForeColor:Blue;BackColor:ControlText;}Style8{}Style10{AlignHorz:Near;}Style11{}" & _
        "Style12{}Style13{}Style16{}Style17{}Style9{}</Data></Styles><Splits><C1.Win.C1Tr" & _
        "ueDBGrid.MergeView HBarHeight=""7"" AllowColMove=""False"" AllowColSelect=""False"" Al" & _
        "lowRowSelect=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""True"" Ca" & _
        "ptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""" & _
        "DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" RecordSelectors=""" & _
        "False"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>496</Height><Ca" & _
        "ptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style" & _
        "5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""Filter" & _
        "Bar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle paren" & _
        "t=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLight" & _
        "RowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me" & _
        "=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle pare" & _
        "nt=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" " & _
        "/><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 312, 496</ClientRect><B" & _
        "orderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.M" & _
        "ergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Nor" & _
        "mal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading" & _
        """ me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" " & _
        "me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""" & _
        "HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=" & _
        """OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" " & _
        "me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>" & _
        "1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth" & _
        ">17</DefaultRecSelWidth><ClientArea>0, 0, 312, 496</ClientArea><PrintPageHeaderS" & _
        "tyle parent="""" me=""Style16"" /><PrintPageFooterStyle parent="""" me=""Style17"" /></B" & _
        "lob>"
        '
        'lblInstruction
        '
        Me.lblInstruction.BackColor = System.Drawing.Color.Transparent
        Me.lblInstruction.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInstruction.ForeColor = System.Drawing.Color.Blue
        Me.lblInstruction.Location = New System.Drawing.Point(336, 40)
        Me.lblInstruction.Name = "lblInstruction"
        Me.lblInstruction.Size = New System.Drawing.Size(296, 16)
        Me.lblInstruction.TabIndex = 138
        Me.lblInstruction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCreateInvRpt
        '
        Me.btnCreateInvRpt.BackColor = System.Drawing.Color.Green
        Me.btnCreateInvRpt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreateInvRpt.ForeColor = System.Drawing.Color.White
        Me.btnCreateInvRpt.Location = New System.Drawing.Point(384, 472)
        Me.btnCreateInvRpt.Name = "btnCreateInvRpt"
        Me.btnCreateInvRpt.Size = New System.Drawing.Size(192, 32)
        Me.btnCreateInvRpt.TabIndex = 139
        Me.btnCreateInvRpt.Text = "Create Invoice Report"
        '
        'frmPackingSlip
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(712, 518)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCreateInvRpt, Me.lblInstruction, Me.grdPkSlipPalletInfo, Me.grdInvPkSlip, Me.btnMoveDown, Me.btnMoveUp, Me.Splitter1, Me.grdPkSlip, Me.lblCustomer, Me.cmbCustomer})
        Me.Name = "frmPackingSlip"
        Me.Text = "Packing Manifest Information"
        CType(Me.grdPkSlip, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdInvPkSlip, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdPkSlipPalletInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '****************************************************************
    Private Sub frmPackingSlip_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim objGen As New Data.Buisness.Generic()

        Try
            Me.lblInstruction.Text = "Double click to move record down."
            objGen.LoadCustomers(Me.cmbCustomer, )
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
        End Try
    End Sub

    '****************************************************************
    Private Sub cmbCustomer_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCustomer.SelectionChangeCommitted

        Try
            If Me.cmbCustomer.SelectedValue > 0 Then
                Me.GetPackingSlipTablesForDataset(Me.cmbCustomer.SelectedValue)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Customer Selection change", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '****************************************************************
    Private Sub GetPackingSlipTablesForDataset(ByVal iCustomer_ID As Integer)
        Try
            If Not IsNothing(Me._dsTable) Then
                Me._dsTable.Tables.Clear()
            End If
            Me._dsTable = Me._objPkSlip.GetPackingSlipInfoTable(iCustomer_ID)
            Me.grdPkSlip.DataSource = Me._dsTable.Tables("tpackingslip")
            Me.SetPkSlipGrid(Me.grdPkSlip, Color.White, New Integer() {100, 100, 70}, C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, C1.Win.C1TrueDBGrid.AlignHorzEnum.Center)
            Me.grdInvPkSlip.DataSource = Me._dsTable.Tables("InvoicePackingSlip")
            Me.SetPkSlipGrid(Me.grdInvPkSlip, Color.White, New Integer() {100, 100, 70}, C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, C1.Win.C1TrueDBGrid.AlignHorzEnum.Center)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Customer Selection change", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '****************************************************************
    Private Sub grdPkSlip_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdPkSlip.DoubleClick
        Try
            Me.MoveRecToInvoiceGrid()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Grid DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '****************************************************************
    Private Sub MoveRecToInvoiceGrid()
        Dim R1 As DataRow

        Try
            If Me.grdPkSlip.Columns.Count = 0 Then
                Exit Sub
            End If
            If Me.grdPkSlip.RowCount = 0 Then
                Exit Sub
            End If

            If Trim(Me.grdPkSlip.Columns("PackingNumber").Value) = "" Then
                Exit Sub
            End If
            If Me._dsTable.Tables("InvoicePackingSlip").Select("PackingNumber = " & Me.grdPkSlip.Columns("PackingNumber").Value).Length > 0 Then
                Exit Sub
            End If

            Me.grdPkSlipPalletInfo.Visible = False
            Me.grdPkSlipPalletInfo.DataSource = Nothing

            R1 = Me._dsTable.Tables("InvoicePackingSlip").NewRow
            R1("PackingNumber") = Me.grdPkSlip.Columns("PackingNumber").Value.ToString.Trim
            R1("CreationDate") = Me.grdPkSlip.Columns("CreationDate").Value.ToString.Trim
            R1("Quantity") = Me.grdPkSlip.Columns("Quantity").Value
            Me._dsTable.Tables("InvoicePackingSlip").Rows.Add(R1)
            Me._dsTable.Tables("InvoicePackingSlip").AcceptChanges()

            R1 = Nothing
            R1 = Me._dsTable.Tables("tpackingslip").Select("PackingNumber = " & Me.grdPkSlip.Columns("PackingNumber").Value)(0)
            Me._dsTable.Tables("tpackingslip").Rows.Remove(R1)
            Me._dsTable.Tables("tpackingslip").AcceptChanges()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Grid DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            R1 = Nothing
        End Try
    End Sub

    '****************************************************************
    Private Sub SetPkSlipGrid(ByRef grdPackingSlipCtrl As C1.Win.C1TrueDBGrid.C1TrueDBGrid, _
                              ByVal clrHeaderForeColor As Color, _
                              ByVal iArrColSize() As Integer, _
                              ByVal iHeaderAlignment As Integer, _
                              ByVal iRowAlignment As Integer)
        Dim iNumOfColumns As Integer = grdPackingSlipCtrl.Columns.Count
        Dim i As Integer

        With grdPackingSlipCtrl
            'Heading style (Horizontal Alignment to Center)
            For i = 0 To (iNumOfColumns - 1)
                .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = iHeaderAlignment 'C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = clrHeaderForeColor
                .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = iRowAlignment 'C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns(i).Width = iArrColSize(i)
            Next i
        End With
    End Sub

    '****************************************************************
    Private Sub btnMoveDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveDown.Click
        Try
            Me.MoveRecToInvoiceGrid()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "MoveDownButtonClick", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '****************************************************************
    Private Sub btnMoveUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveUp.Click
        Try
            Me.MoveRecOutFrInvoiceGrid()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "MoveDownButtonClick", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '****************************************************************
    Private Sub MoveRecOutFrInvoiceGrid()
        Dim R1 As DataRow

        Try
            If Me.grdInvPkSlip.Columns.Count = 0 Then
                Exit Sub
            End If
            If Me.grdInvPkSlip.RowCount = 0 Then
                Exit Sub
            End If

            If Trim(Me.grdInvPkSlip.Columns("PackingNumber").Value) = "" Then
                Exit Sub
            End If
            If Me._dsTable.Tables("tpackingslip").Select("PackingNumber = " & Me.grdInvPkSlip.Columns("PackingNumber").Value).Length > 0 Then
                Exit Sub
            End If

            Me.grdPkSlipPalletInfo.Visible = False
            Me.grdPkSlipPalletInfo.DataSource = Nothing

            R1 = Me._dsTable.Tables("tpackingslip").NewRow
            R1("PackingNumber") = Me.grdInvPkSlip.Columns("PackingNumber").Value.ToString.Trim
            R1("CreationDate") = Me.grdInvPkSlip.Columns("CreationDate").Value.ToString.Trim
            R1("Quantity") = Me.grdInvPkSlip.Columns("Quantity").Value
            Me._dsTable.Tables("tpackingslip").Rows.Add(R1)
            Me._dsTable.Tables("tpackingslip").AcceptChanges()

            R1 = Nothing
            R1 = Me._dsTable.Tables("InvoicePackingSlip").Select("PackingNumber = " & Me.grdInvPkSlip.Columns("PackingNumber").Value)(0)
            Me._dsTable.Tables("InvoicePackingSlip").Rows.Remove(R1)
            Me._dsTable.Tables("InvoicePackingSlip").AcceptChanges()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Grid DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            R1 = Nothing
        End Try
    End Sub

    '****************************************************************
    Private Sub grdPkSlip_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdPkSlip.Click
        Try
            If Me.grdPkSlip.Columns.Count = 0 Then
                Exit Sub
            End If
            If Me.grdPkSlip.RowCount = 0 Then
                Exit Sub
            End If

            If Trim(Me.grdPkSlip.Columns("PackingNumber").Value) = "" Then
                Exit Sub
            End If

            Me.grdPkSlipPalletInfo.Visible = False
            Me.grdPkSlipPalletInfo.DataSource = Nothing

            If Not IsNothing(Me._dsTable.Tables(Me.grdPkSlip.Columns("PackingNumber").Value.ToString.Trim)) Then
                Me.grdPkSlipPalletInfo.DataSource = Me._dsTable.Tables(Me.grdPkSlip.Columns("PackingNumber").Value.ToString.Trim)

                Me.SetPkSlipGrid(Me.grdPkSlipPalletInfo, Color.Lime, New Integer() {140, 100, 50}, C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, C1.Win.C1TrueDBGrid.AlignHorzEnum.Near)
                Me.grdPkSlipPalletInfo.Visible = True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "PkSlipGrid RowColmnChange", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '****************************************************************
    Private Sub btnCreateInvRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateInvRpt.Click
        Dim i As Integer = 0

        Try
            If Me.grdInvPkSlip.Columns.Count = 0 Then
                Exit Sub
            End If
            If Me.grdInvPkSlip.RowCount = 0 Then
                Exit Sub
            End If

            If Me._dsTable.Tables("InvoicePackingSlip").Rows.Count = 0 Then
                Exit Sub
            End If

            i = Me._objPkSlip.CreateInvoiceRpt(Me._dsTable.Tables("InvoicePackingSlip"), Me.cmbCustomer.Text)

            Me.GetPackingSlipTablesForDataset(Me.cmbCustomer.SelectedValue)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "PkSlipGrid RowColmnChange", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.cmbCustomer.Focus()
        End Try
    End Sub

    '****************************************************************


End Class
