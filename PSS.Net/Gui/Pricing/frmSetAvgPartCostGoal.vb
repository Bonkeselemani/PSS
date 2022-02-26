Option Explicit On 

Imports PSS.Data.Buisness

Public Class frmSetAvgPartCostGoal
    Inherits System.Windows.Forms.Form

    Private _objAvgPartCost As AvgPartsCost

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _objAvgPartCost = New AvgPartsCost()
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If

            _objAvgPartCost = Nothing
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents dbgAvgPartCostGoal As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents txtAvgPartCostGoal As System.Windows.Forms.TextBox
    Friend WithEvents cboCustomers As C1.Win.C1List.C1Combo
    Friend WithEvents cboModels As C1.Win.C1List.C1Combo
    Friend WithEvents cboProds As C1.Win.C1List.C1Combo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSetAvgPartCostGoal))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAvgPartCostGoal = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.dbgAvgPartCostGoal = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.cboCustomers = New C1.Win.C1List.C1Combo()
        Me.cboModels = New C1.Win.C1List.C1Combo()
        Me.cboProds = New C1.Win.C1List.C1Combo()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.dbgAvgPartCostGoal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboModels, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboProds, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(16, 112)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(168, 16)
        Me.Label1.TabIndex = 92
        Me.Label1.Text = "Avg Parts Cost/Unit Goal :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAvgPartCostGoal
        '
        Me.txtAvgPartCostGoal.Location = New System.Drawing.Point(192, 112)
        Me.txtAvgPartCostGoal.MaxLength = 6
        Me.txtAvgPartCostGoal.Name = "txtAvgPartCostGoal"
        Me.txtAvgPartCostGoal.Size = New System.Drawing.Size(216, 20)
        Me.txtAvgPartCostGoal.TabIndex = 4
        Me.txtAvgPartCostGoal.Text = ""
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(72, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 16)
        Me.Label5.TabIndex = 91
        Me.Label5.Text = "Model :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(72, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 16)
        Me.Label2.TabIndex = 94
        Me.Label2.Text = "Customer :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.Color.Green
        Me.btnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.ForeColor = System.Drawing.Color.White
        Me.btnUpdate.Location = New System.Drawing.Point(304, 144)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(104, 40)
        Me.btnUpdate.TabIndex = 5
        Me.btnUpdate.Text = "Update"
        '
        'dbgAvgPartCostGoal
        '
        Me.dbgAvgPartCostGoal.AllowColMove = False
        Me.dbgAvgPartCostGoal.AllowColSelect = False
        Me.dbgAvgPartCostGoal.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.dbgAvgPartCostGoal.AllowUpdate = False
        Me.dbgAvgPartCostGoal.AllowUpdateOnBlur = False
        Me.dbgAvgPartCostGoal.AlternatingRows = True
        Me.dbgAvgPartCostGoal.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left)
        Me.dbgAvgPartCostGoal.BackColor = System.Drawing.Color.SteelBlue
        Me.dbgAvgPartCostGoal.FilterBar = True
        Me.dbgAvgPartCostGoal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dbgAvgPartCostGoal.GroupByCaption = "Drag a column header here to group by that column"
        Me.dbgAvgPartCostGoal.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.dbgAvgPartCostGoal.Location = New System.Drawing.Point(16, 192)
        Me.dbgAvgPartCostGoal.MaintainRowCurrency = True
        Me.dbgAvgPartCostGoal.Name = "dbgAvgPartCostGoal"
        Me.dbgAvgPartCostGoal.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgAvgPartCostGoal.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgAvgPartCostGoal.PreviewInfo.ZoomFactor = 75
        Me.dbgAvgPartCostGoal.RowHeight = 20
        Me.dbgAvgPartCostGoal.Size = New System.Drawing.Size(392, 184)
        Me.dbgAvgPartCostGoal.TabIndex = 6
        Me.dbgAvgPartCostGoal.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Transparent;}Se" & _
        "lected{ForeColor:ControlText;BackColor:Yellow;}Style3{}Inactive{ForeColor:Inacti" & _
        "veCaptionText;BackColor:InactiveCaption;}FilterBar{ForeColor:Red;BackColor:Trans" & _
        "parent;}Footer{}Caption{AlignHorz:Center;ForeColor:White;BackColor:Transparent;}" & _
        "Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt;AlignVert:Center;BackColor:Cont" & _
        "rol;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style14{}OddRow{B" & _
        "ackColor:Transparent;}RecordSelector{AlignImage:Center;}Style15{}Heading{Wrap:Tr" & _
        "ue;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;BackColor:Ligh" & _
        "tSteelBlue;Border:Raised,,1, 1, 1, 1;ForeColor:Black;AlignVert:Center;}Style8{}S" & _
        "tyle10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style9{}</Data></Styles><Split" & _
        "s><C1.Win.C1TrueDBGrid.MergeView HBarHeight=""10"" AllowColMove=""False"" AllowColSe" & _
        "lect=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""True"" CaptionHei" & _
        "ght=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" Marqu" & _
        "eeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidth=""16"" Vertical" & _
        "ScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>180</Height><CaptionStyle pare" & _
        "nt=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowSt" & _
        "yle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style1" & _
        "3"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""S" & _
        "tyle12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent" & _
        "=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><Od" & _
        "dRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelec" & _
        "tor"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent" & _
        "=""Normal"" me=""Style1"" /><ClientRect>0, 0, 388, 180</ClientRect><BorderSide>0</Bo" & _
        "rderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Spli" & _
        "ts><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Headin" & _
        "g"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" " & _
        "/><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /" & _
        "><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /" & _
        "><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Sty" & _
        "le parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" " & _
        "/><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><" & _
        "horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>16</DefaultRec" & _
        "SelWidth><ClientArea>0, 0, 388, 180</ClientArea><PrintPageHeaderStyle parent="""" " & _
        "me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
        '
        'cboCustomers
        '
        Me.cboCustomers.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboCustomers.AllowDrop = True
        Me.cboCustomers.AutoCompletion = True
        Me.cboCustomers.AutoDropDown = True
        Me.cboCustomers.AutoSelect = True
        Me.cboCustomers.Caption = ""
        Me.cboCustomers.CaptionHeight = 17
        Me.cboCustomers.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboCustomers.ColumnCaptionHeight = 17
        Me.cboCustomers.ColumnFooterHeight = 17
        Me.cboCustomers.ContentHeight = 15
        Me.cboCustomers.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboCustomers.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboCustomers.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCustomers.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboCustomers.EditorHeight = 15
        Me.cboCustomers.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
        Me.cboCustomers.ItemHeight = 15
        Me.cboCustomers.Location = New System.Drawing.Point(192, 48)
        Me.cboCustomers.MatchEntryTimeout = CType(2000, Long)
        Me.cboCustomers.MaxDropDownItems = CType(10, Short)
        Me.cboCustomers.MaxLength = 32767
        Me.cboCustomers.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboCustomers.Name = "cboCustomers"
        Me.cboCustomers.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboCustomers.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboCustomers.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboCustomers.Size = New System.Drawing.Size(216, 21)
        Me.cboCustomers.TabIndex = 2
        Me.cboCustomers.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style9{AlignHorz:Near;}OddRow{}Reco" & _
        "rdSelector{AlignImage:Center;}Heading{Wrap:True;AlignVert:Center;Border:Raised,," & _
        "1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{}Style11{}St" & _
        "yle1{}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" " & _
        "Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight" & _
        "=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 1" & _
        "56</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HS" & _
        "crollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style" & _
        "9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" m" & _
        "e=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Hea" & _
        "ding"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inac" & _
        "tiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style" & _
        "8"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle " & _
        "parent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1" & _
        "List.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style par" & _
        "ent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=" & _
        """Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""" & _
        "Normal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent" & _
        "=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Hea" & _
        "ding"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><" & _
        "vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Def" & _
        "aultRecSelWidth>16</DefaultRecSelWidth></Blob>"
        '
        'cboModels
        '
        Me.cboModels.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboModels.AllowDrop = True
        Me.cboModels.AutoCompletion = True
        Me.cboModels.AutoDropDown = True
        Me.cboModels.AutoSelect = True
        Me.cboModels.Caption = ""
        Me.cboModels.CaptionHeight = 17
        Me.cboModels.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboModels.ColumnCaptionHeight = 17
        Me.cboModels.ColumnFooterHeight = 17
        Me.cboModels.ContentHeight = 15
        Me.cboModels.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboModels.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboModels.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboModels.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboModels.EditorHeight = 15
        Me.cboModels.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
        Me.cboModels.ItemHeight = 15
        Me.cboModels.Location = New System.Drawing.Point(192, 80)
        Me.cboModels.MatchEntryTimeout = CType(2000, Long)
        Me.cboModels.MaxDropDownItems = CType(10, Short)
        Me.cboModels.MaxLength = 32767
        Me.cboModels.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboModels.Name = "cboModels"
        Me.cboModels.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboModels.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboModels.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboModels.Size = New System.Drawing.Size(216, 21)
        Me.cboModels.TabIndex = 3
        Me.cboModels.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style9{AlignHorz:Near;}OddRow{}Reco" & _
        "rdSelector{AlignImage:Center;}Heading{Wrap:True;AlignVert:Center;Border:Raised,," & _
        "1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{}Style11{}St" & _
        "yle1{}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" " & _
        "Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight" & _
        "=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 1" & _
        "56</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HS" & _
        "crollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style" & _
        "9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" m" & _
        "e=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Hea" & _
        "ding"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inac" & _
        "tiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style" & _
        "8"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle " & _
        "parent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1" & _
        "List.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style par" & _
        "ent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=" & _
        """Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""" & _
        "Normal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent" & _
        "=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Hea" & _
        "ding"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><" & _
        "vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Def" & _
        "aultRecSelWidth>16</DefaultRecSelWidth></Blob>"
        '
        'cboProds
        '
        Me.cboProds.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboProds.AllowDrop = True
        Me.cboProds.AutoCompletion = True
        Me.cboProds.AutoDropDown = True
        Me.cboProds.AutoSelect = True
        Me.cboProds.Caption = ""
        Me.cboProds.CaptionHeight = 17
        Me.cboProds.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboProds.ColumnCaptionHeight = 17
        Me.cboProds.ColumnFooterHeight = 17
        Me.cboProds.ContentHeight = 15
        Me.cboProds.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboProds.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboProds.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboProds.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboProds.EditorHeight = 15
        Me.cboProds.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
        Me.cboProds.ItemHeight = 15
        Me.cboProds.Location = New System.Drawing.Point(192, 16)
        Me.cboProds.MatchEntryTimeout = CType(2000, Long)
        Me.cboProds.MaxDropDownItems = CType(10, Short)
        Me.cboProds.MaxLength = 32767
        Me.cboProds.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboProds.Name = "cboProds"
        Me.cboProds.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboProds.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboProds.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboProds.Size = New System.Drawing.Size(216, 21)
        Me.cboProds.TabIndex = 1
        Me.cboProds.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style1{}OddRow{}RecordSelector{Alig" & _
        "nImage:Center;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;For" & _
        "eColor:ControlText;AlignVert:Center;}Style8{}Style10{}Style11{}Style9{AlignHorz:" & _
        "Near;}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" " & _
        "Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight" & _
        "=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 1" & _
        "56</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HS" & _
        "crollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style" & _
        "9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" m" & _
        "e=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Hea" & _
        "ding"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inac" & _
        "tiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style" & _
        "8"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle " & _
        "parent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1" & _
        "List.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style par" & _
        "ent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=" & _
        """Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""" & _
        "Normal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent" & _
        "=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Hea" & _
        "ding"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><" & _
        "vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Def" & _
        "aultRecSelWidth>16</DefaultRecSelWidth></Blob>"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(72, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 16)
        Me.Label3.TabIndex = 97
        Me.Label3.Text = "Product :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmSetAvgPartCostGoal
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(600, 421)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboProds, Me.Label3, Me.cboModels, Me.cboCustomers, Me.dbgAvgPartCostGoal, Me.btnUpdate, Me.Label2, Me.Label1, Me.txtAvgPartCostGoal, Me.Label5})
        Me.Name = "frmSetAvgPartCostGoal"
        Me.Text = "frmSetAvgPartCostGoal"
        CType(Me.dbgAvgPartCostGoal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboModels, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboProds, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '*******************************************************************
    Private Sub frmSetAvgPartCostGoal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.PopulateProducts()
            Me.PopulateExistingAvgPartsCost()

            PSS.Core.Highlight.SetHighLight(Me)

            Me.txtAvgPartCostGoal.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "frmSetAvgPartCostGoal_Load", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    '*******************************************************************
    Private Sub PopulateProducts()
        Dim dt As DataTable
        Try
            dt = Generic.GetProducts(True)
            If dt.Rows.Count > 0 Then
                With Me.cboProds
                    .DataSource = dt.DefaultView
                    .ValueMember = "Prod_ID"
                    .DisplayMember = "Prod_Desc"
                    .Splits(0).DisplayColumns("Prod_ID").Visible = False
                    .Splits(0).DisplayColumns("Prod_Desc").Width = Me.cboProds.Width - (.VScrollBar.Width + 4)
                    .ColumnHeaders = False

                    'select default product
                    .Text = ""
                    .SelectedValue = 1
                    Me.PopulateCustomers(.SelectedValue)
                    Me.PopulateModels(.SelectedValue)
                    Me.txtAvgPartCostGoal.Focus()
                End With
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*******************************************************************
    Private Sub PopulateCustomers(ByVal iProdID As Integer)
        Dim dt As DataTable
        Try
            With Me.cboCustomers
                .DataSource = Nothing
                .Text = ""

                dt = Generic.GetCustomers(True, iProdID)
                If dt.Rows.Count > 0 Then

                    .DataSource = dt.DefaultView
                    .ValueMember = "Cust_ID"
                    .DisplayMember = "Cust_Name1"
                    .Splits(0).DisplayColumns("Cust_ID").Visible = False
                    .Splits(0).DisplayColumns("Cust_Name1").Width = Me.cboProds.Width - (.VScrollBar.Width + 4)
                    .ColumnHeaders = False

                    'select default product
                    .SelectedValue = 14
                End If
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*******************************************************************
    Private Sub PopulateModels(ByVal iProdID As Integer)
        Dim dt As DataTable
        Try
            With Me.cboModels
                .DataSource = Nothing
                .Text = ""

                dt = Generic.GetModels(True, iProdID, )
                If dt.Rows.Count > 0 Then

                    .DataSource = dt.DefaultView
                    .ValueMember = "Model_ID"
                    .DisplayMember = "Model_Desc"
                    .Splits(0).DisplayColumns("Model_ID").Visible = False
                    .Splits(0).DisplayColumns("Model_Desc").Width = Me.cboProds.Width - (.VScrollBar.Width + 4)
                    .ColumnHeaders = False

                    'select default product
                    .Focus()
                End If
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*******************************************************************
    Private Sub cboProds_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboProds.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                Me.cboCustomers.DataSource = Nothing
                Me.cboModels.DataSource = Nothing
                Me.txtAvgPartCostGoal.Text = ""
                With Me.cboProds
                    If Not IsNothing(.SelectedValue) AndAlso .SelectedValue > 0 Then
                        Me.PopulateCustomers(.SelectedValue)
                        Me.PopulateModels(.SelectedValue)
                        Me.cboCustomers.SelectedValue = 0
                        Me.cboModels.SelectedValue = 0
                        Me.cboCustomers.Focus()
                    End If
                End With
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "cboProds_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '*******************************************************************
    Private Sub cboProds_RowChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProds.RowChange
        Try
            Me.cboCustomers.DataSource = Nothing
            Me.cboModels.DataSource = Nothing
            Me.txtAvgPartCostGoal.Text = ""
            With Me.cboProds
                If Not IsNothing(.SelectedValue) AndAlso .SelectedValue > 0 Then
                    Me.PopulateCustomers(.SelectedValue)
                    Me.PopulateModels(.SelectedValue)
                    Me.cboCustomers.SelectedValue = 0
                    Me.cboModels.SelectedValue = 0
                    Me.cboCustomers.Focus()
                End If
            End With
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "cboProds_RowChange", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '*******************************************************************
    Private Sub cboCustomers_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCustomers.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                Me.txtAvgPartCostGoal.Text = ""
                If IsNothing(Me.cboCustomers.DataSource) = False AndAlso IsNothing(Me.cboCustomers.SelectedValue) = False AndAlso Me.cboCustomers.SelectedValue > 0 Then Me.cboModels.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "cboCustomers_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    '*******************************************************************
    Private Sub cboModels_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboModels.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                If IsNothing(Me.cboModels.DataSource) = False AndAlso IsNothing(Me.cboModels.SelectedValue) = False AndAlso Me.cboModels.SelectedValue > 0 Then
                    Me.txtAvgPartCostGoal.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "cboModels_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    '*******************************************************************
    Private Sub PopulateExistingAvgPartsCost(Optional ByVal iCustID As Integer = 0, _
                                             Optional ByVal iModelID As Integer = 0)
        Dim dt As DataTable
        Dim i As Integer = 0

        Try
            If Me.cboCustomers.SelectedValue > 0 And Me.cboModels.SelectedValue > 0 Then
                dt = Me._objAvgPartCost.GetAllDetailAPCG()
                With Me.dbgAvgPartCostGoal
                    .DataSource = Nothing
                    .DataSource = dt.DefaultView

                    For i = 0 To dt.Columns.Count - 1
                        .Splits(0).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        .Splits(0).HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
                    Next i

                    .Splits(0).DisplayColumns("Customer").Width = 130
                    .Splits(0).DisplayColumns("Model").Width = 130
                    .Splits(0).DisplayColumns("Avg Parts Cost").Width = 80
                    .Splits(0).DisplayColumns("Cust_ID").Visible = False
                    .Splits(0).DisplayColumns("Model_ID").Visible = False

                    If iCustID > 0 And iModelID > 0 Then
                        For i = 0 To .RowCount - 1
                            If .Columns("Cust_ID").CellValue(i) = iCustID And .Columns("Cust_ID").CellValue(i) = iModelID Then
                                If i + 1 <= .RowCount Then .Row = i + 1
                            End If
                        Next i
                    End If
                End With
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "cboModels_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            Generic.DisposeDT(dt)
        End Try
    End Sub

    '*******************************************************************
    Private Sub txtAvgPartCostGoal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAvgPartCostGoal.KeyPress
        Try
            If e.KeyChar.IsDigit(e.KeyChar) = False And e.KeyChar.IsControl(e.KeyChar) = False And e.KeyChar <> "." Then
                e.Handled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtAvgPartCostGoal_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    '*******************************************************************
    Private Sub txtAvgPartCostGoal_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAvgPartCostGoal.KeyUp
        Try
            If e.KeyValue = 13 AndAlso Me.txtAvgPartCostGoal.Text.Trim.Length > 0 Then
                Me.UpdateAvgPartCost()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtAvgPartCostGoal_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    '*******************************************************************
    Private Sub UpdateAvgPartCost()
        Dim decAvgPartCostGoal As Decimal = 0
        Dim iCustID As Integer = 0
        Dim iModelID As Integer = 0
        Dim i As Integer = 0

        Try
            If IsNothing(Me.cboCustomers.SelectedValue) = True OrElse Me.cboCustomers.SelectedValue = 0 Then
                MessageBox.Show("Please select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            ElseIf IsNothing(Me.cboModels.SelectedValue) = True OrElse Me.cboModels.SelectedValue = 0 Then
                MessageBox.Show("Please select model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            ElseIf Me.txtAvgPartCostGoal.Text.Trim.Length = 0 Then
                MessageBox.Show("Please enter average parts cost/unit goal.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                'ElseIf Me.txtAvgPartCostGoal.Text.Trim.GetType.IsValueType = False Then
                '    MessageBox.Show("Average part cost must be in decimal format.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Else
                iCustID = Me.cboCustomers.SelectedValue
                iModelID = Me.cboModels.SelectedValue
                decAvgPartCostGoal = CDec(Me.txtAvgPartCostGoal.Text)

                Me.Enabled = False
                Me.Cursor = Cursors.WaitCursor

                i = Me._objAvgPartCost.UpdateAvgPartCostGoal(iCustID, iModelID, decAvgPartCostGoal)
                If i > 0 Then
                    Me.PopulateExistingAvgPartsCost(iCustID, iModelID)

                    Me.Enabled = True
                    Me.Cursor = Cursors.Default

                    MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtAvgPartCostGoal.Text = ""
                    Me.txtAvgPartCostGoal.Focus()
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Me.Enabled = True
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    '*******************************************************************
    Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            Me.UpdateAvgPartCost()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtAvgPartCostGoal_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    '*******************************************************************

End Class
