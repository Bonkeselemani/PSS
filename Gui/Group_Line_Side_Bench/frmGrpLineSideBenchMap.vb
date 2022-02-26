Option Explicit On 

Imports PSS.Core.[Global]
Imports PSS.Data.Buisness
Namespace Inventory
    Public Class frmGrpLineSideBenchMap
        Inherits System.Windows.Forms.Form
        Private objInventory As PSS.Data.Buisness.Inventory
    
#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            objInventory = New PSS.Data.Buisness.Inventory()

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
        Friend WithEvents TabLine As System.Windows.Forms.TabPage
        Friend WithEvents TabSide As System.Windows.Forms.TabPage
        Friend WithEvents TabMap As System.Windows.Forms.TabPage
        Friend WithEvents Group As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents TabSummary As System.Windows.Forms.TabPage
        Friend WithEvents TabGroup As System.Windows.Forms.TabPage
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents txtGroup As System.Windows.Forms.TextBox
        Friend WithEvents cmdAddGroup As System.Windows.Forms.Button
        Friend WithEvents cmdUpdateGroup As System.Windows.Forms.Button
        Friend WithEvents cmdUpdateLine As System.Windows.Forms.Button
        Friend WithEvents cmdAddLine As System.Windows.Forms.Button
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents TabGrpLinemap As System.Windows.Forms.TabControl
        Friend WithEvents txtLine As System.Windows.Forms.TextBox
        Friend WithEvents cmdUpdateSide As System.Windows.Forms.Button
        Friend WithEvents cmdAddSide As System.Windows.Forms.Button
        Friend WithEvents txtSide As System.Windows.Forms.TextBox
        Friend WithEvents grdGroups_TabSummary As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents GrdGroups_TabGroup As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents grdLines_TabLine As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents grdSides_TabSide As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents grdMachines_TabMachine As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents grdMachines_TabSummary As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents grdSides_TabSummary As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents grdLines_TabSummary As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents cmdUpdateMachine As System.Windows.Forms.Button
        Friend WithEvents cmdAddMachine As System.Windows.Forms.Button
        Friend WithEvents txtMachine As System.Windows.Forms.TextBox
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents TabMachine As System.Windows.Forms.TabPage
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents grdGroup_TabMap As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents grdLine_TabMap As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents grdSide_TabMap As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents grdMachine_TabMap As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents grdMapSummary_TabMap As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents cmdAddMap_TabMap As System.Windows.Forms.Button
        Friend WithEvents cmdDeleteMap As System.Windows.Forms.Button
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents TabCostCenter As System.Windows.Forms.TabPage
        Friend WithEvents TabCostCenterMap As System.Windows.Forms.TabPage
        Friend WithEvents lblCCExisiting As System.Windows.Forms.Label
        Friend WithEvents grdExistingCC_TabCostCenter As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnAddCC_TabCostCenter As System.Windows.Forms.Button
        Friend WithEvents txtName_TabCostCenter As System.Windows.Forms.TextBox
        Friend WithEvents lblGroup_TabCostCenter As System.Windows.Forms.Label
        Friend WithEvents lblName_TabCostCenter As System.Windows.Forms.Label
        Friend WithEvents btnDeleteCC_TabCostCenter As System.Windows.Forms.Button
        Friend WithEvents lblCostCenters_TabCostCenterMap As System.Windows.Forms.Label
        Friend WithEvents grdCostCenters_TabCostCenterMap As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblTable_TabCostCenterMap As System.Windows.Forms.Label
        Friend WithEvents numTable_TabCostCenterMap As System.Windows.Forms.NumericUpDown
        Friend WithEvents lblMachines_TabCostCenterMap As System.Windows.Forms.Label
        Friend WithEvents grdMachines_TabCostCenterMap As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnMapMachine_TabCostCenterMap As System.Windows.Forms.Button
        Friend WithEvents lblMappedMachines_TabCostCenterMap As System.Windows.Forms.Label
        Friend WithEvents grdMappedMachines_TabCostCenterMap As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnDeleteMappings_TabCostCenterMap As System.Windows.Forms.Button
        Friend WithEvents btnUpdateUPH As System.Windows.Forms.Button
        Friend WithEvents txtT1UPH As System.Windows.Forms.TextBox
        Friend WithEvents txtT2UPH As System.Windows.Forms.TextBox
        Friend WithEvents Label14 As System.Windows.Forms.Label
        Friend WithEvents Label15 As System.Windows.Forms.Label
        Friend WithEvents grbUpdCCUPH As System.Windows.Forms.GroupBox
        Friend WithEvents cboWorkAreas As C1.Win.C1List.C1Combo
        Friend WithEvents Label16 As System.Windows.Forms.Label
        Friend WithEvents cboOpenOrders As C1.Win.C1List.C1Combo
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
        Friend WithEvents Label17 As System.Windows.Forms.Label
        Friend WithEvents Label18 As System.Windows.Forms.Label
        Friend WithEvents NumericUpDown2 As System.Windows.Forms.NumericUpDown
        Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmGrpLineSideBenchMap))
            Me.TabGrpLinemap = New System.Windows.Forms.TabControl()
            Me.TabSummary = New System.Windows.Forms.TabPage()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.grdMachines_TabSummary = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.grdSides_TabSummary = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.grdLines_TabSummary = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Group = New System.Windows.Forms.Label()
            Me.grdGroups_TabSummary = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.TabCostCenter = New System.Windows.Forms.TabPage()
            Me.cboWorkAreas = New C1.Win.C1List.C1Combo()
            Me.Label16 = New System.Windows.Forms.Label()
            Me.grbUpdCCUPH = New System.Windows.Forms.GroupBox()
            Me.Label15 = New System.Windows.Forms.Label()
            Me.txtT2UPH = New System.Windows.Forms.TextBox()
            Me.Label14 = New System.Windows.Forms.Label()
            Me.txtT1UPH = New System.Windows.Forms.TextBox()
            Me.btnUpdateUPH = New System.Windows.Forms.Button()
            Me.btnDeleteCC_TabCostCenter = New System.Windows.Forms.Button()
            Me.txtName_TabCostCenter = New System.Windows.Forms.TextBox()
            Me.lblName_TabCostCenter = New System.Windows.Forms.Label()
            Me.lblGroup_TabCostCenter = New System.Windows.Forms.Label()
            Me.btnAddCC_TabCostCenter = New System.Windows.Forms.Button()
            Me.grdExistingCC_TabCostCenter = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lblCCExisiting = New System.Windows.Forms.Label()
            Me.TabGroup = New System.Windows.Forms.TabPage()
            Me.cmdUpdateGroup = New System.Windows.Forms.Button()
            Me.GrdGroups_TabGroup = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.cmdAddGroup = New System.Windows.Forms.Button()
            Me.txtGroup = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.TabSide = New System.Windows.Forms.TabPage()
            Me.cmdUpdateSide = New System.Windows.Forms.Button()
            Me.grdSides_TabSide = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.cmdAddSide = New System.Windows.Forms.Button()
            Me.txtSide = New System.Windows.Forms.TextBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.TabLine = New System.Windows.Forms.TabPage()
            Me.cmdUpdateLine = New System.Windows.Forms.Button()
            Me.grdLines_TabLine = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.cmdAddLine = New System.Windows.Forms.Button()
            Me.txtLine = New System.Windows.Forms.TextBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.TabMap = New System.Windows.Forms.TabPage()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.cmdDeleteMap = New System.Windows.Forms.Button()
            Me.cmdAddMap_TabMap = New System.Windows.Forms.Button()
            Me.grdMapSummary_TabMap = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.grdMachine_TabMap = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.grdSide_TabMap = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.grdLine_TabMap = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.grdGroup_TabMap = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.TabCostCenterMap = New System.Windows.Forms.TabPage()
            Me.btnDeleteMappings_TabCostCenterMap = New System.Windows.Forms.Button()
            Me.grdMappedMachines_TabCostCenterMap = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lblMappedMachines_TabCostCenterMap = New System.Windows.Forms.Label()
            Me.btnMapMachine_TabCostCenterMap = New System.Windows.Forms.Button()
            Me.lblMachines_TabCostCenterMap = New System.Windows.Forms.Label()
            Me.grdMachines_TabCostCenterMap = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.numTable_TabCostCenterMap = New System.Windows.Forms.NumericUpDown()
            Me.lblTable_TabCostCenterMap = New System.Windows.Forms.Label()
            Me.grdCostCenters_TabCostCenterMap = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lblCostCenters_TabCostCenterMap = New System.Windows.Forms.Label()
            Me.TabMachine = New System.Windows.Forms.TabPage()
            Me.cmdUpdateMachine = New System.Windows.Forms.Button()
            Me.grdMachines_TabMachine = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.cmdAddMachine = New System.Windows.Forms.Button()
            Me.txtMachine = New System.Windows.Forms.TextBox()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.cboOpenOrders = New C1.Win.C1List.C1Combo()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
            Me.Label17 = New System.Windows.Forms.Label()
            Me.Label18 = New System.Windows.Forms.Label()
            Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown()
            Me.CheckBox1 = New System.Windows.Forms.CheckBox()
            Me.TabGrpLinemap.SuspendLayout()
            Me.TabSummary.SuspendLayout()
            CType(Me.grdMachines_TabSummary, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.grdSides_TabSummary, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.grdLines_TabSummary, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.grdGroups_TabSummary, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabCostCenter.SuspendLayout()
            CType(Me.cboWorkAreas, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grbUpdCCUPH.SuspendLayout()
            CType(Me.grdExistingCC_TabCostCenter, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabGroup.SuspendLayout()
            CType(Me.GrdGroups_TabGroup, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabSide.SuspendLayout()
            CType(Me.grdSides_TabSide, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabLine.SuspendLayout()
            CType(Me.grdLines_TabLine, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabMap.SuspendLayout()
            CType(Me.grdMapSummary_TabMap, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.grdMachine_TabMap, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.grdSide_TabMap, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.grdLine_TabMap, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.grdGroup_TabMap, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabCostCenterMap.SuspendLayout()
            CType(Me.grdMappedMachines_TabCostCenterMap, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.grdMachines_TabCostCenterMap, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.numTable_TabCostCenterMap, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.grdCostCenters_TabCostCenterMap, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabMachine.SuspendLayout()
            CType(Me.grdMachines_TabMachine, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboOpenOrders, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox1.SuspendLayout()
            CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'TabGrpLinemap
            '
            Me.TabGrpLinemap.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabSummary, Me.TabCostCenter, Me.TabGroup, Me.TabSide, Me.TabLine, Me.TabMap, Me.TabCostCenterMap, Me.TabMachine})
            Me.TabGrpLinemap.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TabGrpLinemap.Location = New System.Drawing.Point(16, 32)
            Me.TabGrpLinemap.Name = "TabGrpLinemap"
            Me.TabGrpLinemap.SelectedIndex = 0
            Me.TabGrpLinemap.Size = New System.Drawing.Size(888, 520)
            Me.TabGrpLinemap.TabIndex = 0
            '
            'TabSummary
            '
            Me.TabSummary.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label3, Me.grdMachines_TabSummary, Me.Label2, Me.grdSides_TabSummary, Me.Label1, Me.grdLines_TabSummary, Me.Group, Me.grdGroups_TabSummary})
            Me.TabSummary.Location = New System.Drawing.Point(4, 25)
            Me.TabSummary.Name = "TabSummary"
            Me.TabSummary.Size = New System.Drawing.Size(880, 491)
            Me.TabSummary.TabIndex = 0
            Me.TabSummary.Text = "Summary"
            '
            'Label3
            '
            Me.Label3.Location = New System.Drawing.Point(372, 11)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(70, 16)
            Me.Label3.TabIndex = 9
            Me.Label3.Text = "Bench:"
            '
            'grdMachines_TabSummary
            '
            Me.grdMachines_TabSummary.AllowColMove = False
            Me.grdMachines_TabSummary.AllowColSelect = False
            Me.grdMachines_TabSummary.AllowFilter = False
            Me.grdMachines_TabSummary.AllowUpdate = False
            Me.grdMachines_TabSummary.AllowUpdateOnBlur = False
            Me.grdMachines_TabSummary.AlternatingRows = True
            Me.grdMachines_TabSummary.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grdMachines_TabSummary.GroupByCaption = "Drag a column header here to group by that column"
            Me.grdMachines_TabSummary.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.grdMachines_TabSummary.Location = New System.Drawing.Point(372, 27)
            Me.grdMachines_TabSummary.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.grdMachines_TabSummary.Name = "grdMachines_TabSummary"
            Me.grdMachines_TabSummary.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.grdMachines_TabSummary.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.grdMachines_TabSummary.PreviewInfo.ZoomFactor = 75
            Me.grdMachines_TabSummary.RowHeight = 20
            Me.grdMachines_TabSummary.Size = New System.Drawing.Size(360, 333)
            Me.grdMachines_TabSummary.TabIndex = 8
            Me.grdMachines_TabSummary.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt;BackColor:Control;AlignVert" & _
            ":Center;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddR" & _
            "ow{BackColor:Control;}RecordSelector{AlignImage:Center;}Style13{}Heading{Wrap:Tr" & _
            "ue;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;BackColor:Cont" & _
            "rol;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}St" & _
            "yle10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style1{}</Data></Styles><Splits" & _
            "><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" Name" & _
            "="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" Colum" & _
            "nFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefR" & _
            "ecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>329</H" & _
            "eight><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" " & _
            "me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle paren" & _
            "t=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupSt" & _
            "yle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><" & _
            "HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Ina" & _
            "ctive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorS" & _
            "tyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=" & _
            """Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 356, 329</Clie" & _
            "ntRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1Tru" & _
            "eDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style pa" & _
            "rent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent" & _
            "=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=" & _
            """Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Nor" & _
            "mal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""No" & _
            "rmal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=" & _
            """Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><ve" & _
            "rtSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRe" & _
            "cSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 356, 329</ClientArea><PrintPa" & _
            "geHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style" & _
            "15"" /></Blob>"
            '
            'Label2
            '
            Me.Label2.Location = New System.Drawing.Point(226, 217)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(54, 16)
            Me.Label2.TabIndex = 7
            Me.Label2.Text = "Side:"
            '
            'grdSides_TabSummary
            '
            Me.grdSides_TabSummary.AllowColMove = False
            Me.grdSides_TabSummary.AllowColSelect = False
            Me.grdSides_TabSummary.AllowFilter = False
            Me.grdSides_TabSummary.AllowUpdate = False
            Me.grdSides_TabSummary.AllowUpdateOnBlur = False
            Me.grdSides_TabSummary.AlternatingRows = True
            Me.grdSides_TabSummary.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grdSides_TabSummary.GroupByCaption = "Drag a column header here to group by that column"
            Me.grdSides_TabSummary.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.grdSides_TabSummary.Location = New System.Drawing.Point(226, 234)
            Me.grdSides_TabSummary.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.grdSides_TabSummary.Name = "grdSides_TabSummary"
            Me.grdSides_TabSummary.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.grdSides_TabSummary.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.grdSides_TabSummary.PreviewInfo.ZoomFactor = 75
            Me.grdSides_TabSummary.RowHeight = 20
            Me.grdSides_TabSummary.Size = New System.Drawing.Size(126, 126)
            Me.grdSides_TabSummary.TabIndex = 6
            Me.grdSides_TabSummary.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt;BackColor:Control;AlignVert" & _
            ":Center;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddR" & _
            "ow{BackColor:Control;}RecordSelector{AlignImage:Center;}Style13{}Heading{Wrap:Tr" & _
            "ue;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;BackColor:Cont" & _
            "rol;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}St" & _
            "yle10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style1{}</Data></Styles><Splits" & _
            "><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" Name" & _
            "="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" Colum" & _
            "nFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefR" & _
            "ecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>122</H" & _
            "eight><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" " & _
            "me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle paren" & _
            "t=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupSt" & _
            "yle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><" & _
            "HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Ina" & _
            "ctive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorS" & _
            "tyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=" & _
            """Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 122, 122</Clie" & _
            "ntRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1Tru" & _
            "eDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style pa" & _
            "rent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent" & _
            "=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=" & _
            """Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Nor" & _
            "mal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""No" & _
            "rmal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=" & _
            """Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><ve" & _
            "rtSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRe" & _
            "cSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 122, 122</ClientArea><PrintPa" & _
            "geHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style" & _
            "15"" /></Blob>"
            '
            'Label1
            '
            Me.Label1.Location = New System.Drawing.Point(18, 216)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(54, 16)
            Me.Label1.TabIndex = 5
            Me.Label1.Text = "Line:"
            '
            'grdLines_TabSummary
            '
            Me.grdLines_TabSummary.AllowColMove = False
            Me.grdLines_TabSummary.AllowColSelect = False
            Me.grdLines_TabSummary.AllowFilter = False
            Me.grdLines_TabSummary.AllowUpdate = False
            Me.grdLines_TabSummary.AllowUpdateOnBlur = False
            Me.grdLines_TabSummary.AlternatingRows = True
            Me.grdLines_TabSummary.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grdLines_TabSummary.GroupByCaption = "Drag a column header here to group by that column"
            Me.grdLines_TabSummary.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.grdLines_TabSummary.Location = New System.Drawing.Point(18, 234)
            Me.grdLines_TabSummary.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.grdLines_TabSummary.Name = "grdLines_TabSummary"
            Me.grdLines_TabSummary.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.grdLines_TabSummary.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.grdLines_TabSummary.PreviewInfo.ZoomFactor = 75
            Me.grdLines_TabSummary.RowHeight = 20
            Me.grdLines_TabSummary.Size = New System.Drawing.Size(198, 126)
            Me.grdLines_TabSummary.TabIndex = 4
            Me.grdLines_TabSummary.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt;AlignVert:Center;BackColor:" & _
            "Control;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddR" & _
            "ow{BackColor:Control;}RecordSelector{AlignImage:Center;}Style13{}Heading{Wrap:Tr" & _
            "ue;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;AlignVert:Cent" & _
            "er;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}St" & _
            "yle10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style9{}</Data></Styles><Splits" & _
            "><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" Name" & _
            "="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" Colum" & _
            "nFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefR" & _
            "ecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>122</H" & _
            "eight><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" " & _
            "me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle paren" & _
            "t=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupSt" & _
            "yle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><" & _
            "HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Ina" & _
            "ctive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorS" & _
            "tyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=" & _
            """Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 194, 122</Clie" & _
            "ntRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1Tru" & _
            "eDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style pa" & _
            "rent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent" & _
            "=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=" & _
            """Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Nor" & _
            "mal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""No" & _
            "rmal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=" & _
            """Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><ve" & _
            "rtSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRe" & _
            "cSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 194, 122</ClientArea><PrintPa" & _
            "geHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style" & _
            "15"" /></Blob>"
            '
            'Group
            '
            Me.Group.Location = New System.Drawing.Point(18, 10)
            Me.Group.Name = "Group"
            Me.Group.Size = New System.Drawing.Size(62, 16)
            Me.Group.TabIndex = 3
            Me.Group.Text = "Group:"
            '
            'grdGroups_TabSummary
            '
            Me.grdGroups_TabSummary.AllowColMove = False
            Me.grdGroups_TabSummary.AllowColSelect = False
            Me.grdGroups_TabSummary.AllowFilter = False
            Me.grdGroups_TabSummary.AllowUpdate = False
            Me.grdGroups_TabSummary.AllowUpdateOnBlur = False
            Me.grdGroups_TabSummary.AlternatingRows = True
            Me.grdGroups_TabSummary.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grdGroups_TabSummary.GroupByCaption = "Drag a column header here to group by that column"
            Me.grdGroups_TabSummary.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.grdGroups_TabSummary.Location = New System.Drawing.Point(18, 28)
            Me.grdGroups_TabSummary.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.grdGroups_TabSummary.Name = "grdGroups_TabSummary"
            Me.grdGroups_TabSummary.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.grdGroups_TabSummary.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.grdGroups_TabSummary.PreviewInfo.ZoomFactor = 75
            Me.grdGroups_TabSummary.RowHeight = 20
            Me.grdGroups_TabSummary.Size = New System.Drawing.Size(334, 180)
            Me.grdGroups_TabSummary.TabIndex = 2
            Me.grdGroups_TabSummary.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt;BackColor:Control;AlignVert" & _
            ":Center;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddR" & _
            "ow{BackColor:Control;}RecordSelector{AlignImage:Center;}Style13{}Heading{Wrap:Tr" & _
            "ue;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;BackColor:Cont" & _
            "rol;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}St" & _
            "yle10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style1{}</Data></Styles><Splits" & _
            "><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" Name" & _
            "="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" Colum" & _
            "nFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefR" & _
            "ecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>176</H" & _
            "eight><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" " & _
            "me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle paren" & _
            "t=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupSt" & _
            "yle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><" & _
            "HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Ina" & _
            "ctive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorS" & _
            "tyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=" & _
            """Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 330, 176</Clie" & _
            "ntRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1Tru" & _
            "eDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style pa" & _
            "rent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent" & _
            "=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=" & _
            """Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Nor" & _
            "mal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""No" & _
            "rmal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=" & _
            """Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><ve" & _
            "rtSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRe" & _
            "cSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 330, 176</ClientArea><PrintPa" & _
            "geHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style" & _
            "15"" /></Blob>"
            '
            'TabCostCenter
            '
            Me.TabCostCenter.Controls.AddRange(New System.Windows.Forms.Control() {Me.CheckBox1, Me.GroupBox1, Me.cboOpenOrders, Me.cboWorkAreas, Me.Label16, Me.grbUpdCCUPH, Me.btnDeleteCC_TabCostCenter, Me.txtName_TabCostCenter, Me.lblName_TabCostCenter, Me.lblGroup_TabCostCenter, Me.btnAddCC_TabCostCenter, Me.grdExistingCC_TabCostCenter, Me.lblCCExisiting})
            Me.TabCostCenter.Location = New System.Drawing.Point(4, 25)
            Me.TabCostCenter.Name = "TabCostCenter"
            Me.TabCostCenter.Size = New System.Drawing.Size(880, 491)
            Me.TabCostCenter.TabIndex = 7
            Me.TabCostCenter.Text = "Cost Center"
            '
            'cboWorkAreas
            '
            Me.cboWorkAreas.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboWorkAreas.AutoCompletion = True
            Me.cboWorkAreas.AutoDropDown = True
            Me.cboWorkAreas.AutoSelect = True
            Me.cboWorkAreas.Caption = ""
            Me.cboWorkAreas.CaptionHeight = 17
            Me.cboWorkAreas.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboWorkAreas.ColumnCaptionHeight = 17
            Me.cboWorkAreas.ColumnFooterHeight = 17
            Me.cboWorkAreas.ColumnHeaders = False
            Me.cboWorkAreas.ContentHeight = 15
            Me.cboWorkAreas.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboWorkAreas.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboWorkAreas.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboWorkAreas.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboWorkAreas.EditorHeight = 15
            Me.cboWorkAreas.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.cboWorkAreas.ItemHeight = 15
            Me.cboWorkAreas.Location = New System.Drawing.Point(168, 64)
            Me.cboWorkAreas.MatchEntryTimeout = CType(2000, Long)
            Me.cboWorkAreas.MaxDropDownItems = CType(10, Short)
            Me.cboWorkAreas.MaxLength = 32767
            Me.cboWorkAreas.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboWorkAreas.Name = "cboWorkAreas"
            Me.cboWorkAreas.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboWorkAreas.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboWorkAreas.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboWorkAreas.Size = New System.Drawing.Size(112, 21)
            Me.cboWorkAreas.TabIndex = 4
            Me.cboWorkAreas.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            "ultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'Label16
            '
            Me.Label16.BackColor = System.Drawing.Color.Transparent
            Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label16.ForeColor = System.Drawing.Color.Black
            Me.Label16.Location = New System.Drawing.Point(168, 48)
            Me.Label16.Name = "Label16"
            Me.Label16.Size = New System.Drawing.Size(94, 14)
            Me.Label16.TabIndex = 91
            Me.Label16.Text = "Work Area:"
            Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'grbUpdCCUPH
            '
            Me.grbUpdCCUPH.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label15, Me.txtT2UPH, Me.Label14, Me.txtT1UPH, Me.btnUpdateUPH})
            Me.grbUpdCCUPH.ForeColor = System.Drawing.SystemColors.ActiveCaption
            Me.grbUpdCCUPH.Location = New System.Drawing.Point(672, 296)
            Me.grbUpdCCUPH.Name = "grbUpdCCUPH"
            Me.grbUpdCCUPH.Size = New System.Drawing.Size(192, 112)
            Me.grbUpdCCUPH.TabIndex = 8
            Me.grbUpdCCUPH.TabStop = False
            Me.grbUpdCCUPH.Text = "Cost Center UPH"
            '
            'Label15
            '
            Me.Label15.Location = New System.Drawing.Point(112, 24)
            Me.Label15.Name = "Label15"
            Me.Label15.Size = New System.Drawing.Size(72, 16)
            Me.Label15.TabIndex = 22
            Me.Label15.Text = "Tier2"
            '
            'txtT2UPH
            '
            Me.txtT2UPH.Location = New System.Drawing.Point(116, 40)
            Me.txtT2UPH.Name = "txtT2UPH"
            Me.txtT2UPH.Size = New System.Drawing.Size(68, 22)
            Me.txtT2UPH.TabIndex = 2
            Me.txtT2UPH.Text = ""
            '
            'Label14
            '
            Me.Label14.Location = New System.Drawing.Point(8, 24)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(72, 16)
            Me.Label14.TabIndex = 21
            Me.Label14.Text = "Tier1"
            '
            'txtT1UPH
            '
            Me.txtT1UPH.Location = New System.Drawing.Point(10, 40)
            Me.txtT1UPH.Name = "txtT1UPH"
            Me.txtT1UPH.Size = New System.Drawing.Size(62, 22)
            Me.txtT1UPH.TabIndex = 1
            Me.txtT1UPH.Text = ""
            '
            'btnUpdateUPH
            '
            Me.btnUpdateUPH.ForeColor = System.Drawing.SystemColors.ActiveCaption
            Me.btnUpdateUPH.Location = New System.Drawing.Point(10, 72)
            Me.btnUpdateUPH.Name = "btnUpdateUPH"
            Me.btnUpdateUPH.Size = New System.Drawing.Size(174, 32)
            Me.btnUpdateUPH.TabIndex = 3
            Me.btnUpdateUPH.Text = "Update UPH"
            '
            'btnDeleteCC_TabCostCenter
            '
            Me.btnDeleteCC_TabCostCenter.ForeColor = System.Drawing.Color.Blue
            Me.btnDeleteCC_TabCostCenter.Location = New System.Drawing.Point(680, 224)
            Me.btnDeleteCC_TabCostCenter.Name = "btnDeleteCC_TabCostCenter"
            Me.btnDeleteCC_TabCostCenter.Size = New System.Drawing.Size(176, 40)
            Me.btnDeleteCC_TabCostCenter.TabIndex = 7
            Me.btnDeleteCC_TabCostCenter.Text = "Delete Selected Cost Center(s)"
            Me.btnDeleteCC_TabCostCenter.Visible = False
            '
            'txtName_TabCostCenter
            '
            Me.txtName_TabCostCenter.Location = New System.Drawing.Point(24, 64)
            Me.txtName_TabCostCenter.Name = "txtName_TabCostCenter"
            Me.txtName_TabCostCenter.Size = New System.Drawing.Size(136, 22)
            Me.txtName_TabCostCenter.TabIndex = 2
            Me.txtName_TabCostCenter.Text = ""
            '
            'lblName_TabCostCenter
            '
            Me.lblName_TabCostCenter.Location = New System.Drawing.Point(24, 48)
            Me.lblName_TabCostCenter.Name = "lblName_TabCostCenter"
            Me.lblName_TabCostCenter.Size = New System.Drawing.Size(62, 16)
            Me.lblName_TabCostCenter.TabIndex = 13
            Me.lblName_TabCostCenter.Text = "Name:"
            '
            'lblGroup_TabCostCenter
            '
            Me.lblGroup_TabCostCenter.Location = New System.Drawing.Point(24, 8)
            Me.lblGroup_TabCostCenter.Name = "lblGroup_TabCostCenter"
            Me.lblGroup_TabCostCenter.Size = New System.Drawing.Size(62, 16)
            Me.lblGroup_TabCostCenter.TabIndex = 12
            Me.lblGroup_TabCostCenter.Text = "Group:"
            '
            'btnAddCC_TabCostCenter
            '
            Me.btnAddCC_TabCostCenter.ForeColor = System.Drawing.Color.Blue
            Me.btnAddCC_TabCostCenter.Location = New System.Drawing.Point(304, 24)
            Me.btnAddCC_TabCostCenter.Name = "btnAddCC_TabCostCenter"
            Me.btnAddCC_TabCostCenter.Size = New System.Drawing.Size(152, 40)
            Me.btnAddCC_TabCostCenter.TabIndex = 5
            Me.btnAddCC_TabCostCenter.Text = "Add New Cost Center"
            '
            'grdExistingCC_TabCostCenter
            '
            Me.grdExistingCC_TabCostCenter.AllowUpdate = False
            Me.grdExistingCC_TabCostCenter.AllowUpdateOnBlur = False
            Me.grdExistingCC_TabCostCenter.AlternatingRows = True
            Me.grdExistingCC_TabCostCenter.CaptionHeight = 17
            Me.grdExistingCC_TabCostCenter.FilterBar = True
            Me.grdExistingCC_TabCostCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grdExistingCC_TabCostCenter.GroupByCaption = "Drag a column header here to group by that column"
            Me.grdExistingCC_TabCostCenter.Images.Add(CType(resources.GetObject("resource.Images5"), System.Drawing.Bitmap))
            Me.grdExistingCC_TabCostCenter.Location = New System.Drawing.Point(24, 224)
            Me.grdExistingCC_TabCostCenter.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
            Me.grdExistingCC_TabCostCenter.Name = "grdExistingCC_TabCostCenter"
            Me.grdExistingCC_TabCostCenter.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.grdExistingCC_TabCostCenter.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.grdExistingCC_TabCostCenter.PreviewInfo.ZoomFactor = 75
            Me.grdExistingCC_TabCostCenter.RowHeight = 15
            Me.grdExistingCC_TabCostCenter.Size = New System.Drawing.Size(640, 240)
            Me.grdExistingCC_TabCostCenter.TabIndex = 6
            Me.grdExistingCC_TabCostCenter.Text = "C1TrueDBGrid1"
            Me.grdExistingCC_TabCostCenter.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Style9{}Normal{Font:Microsoft Sans Serif, 9.75pt;}HighlightRow{ForeColor:Hig" & _
            "hlightText;BackColor:Highlight;}Style14{}OddRow{}RecordSelector{AlignImage:Cente" & _
            "r;}Style15{}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeCol" & _
            "or:ControlText;BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style11{}Style" & _
            "12{}Style13{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name" & _
            "="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" Colum" & _
            "nFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelect" & _
            "orWidth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""" & _
            "1""><Height>236</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle" & _
            " parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><Fil" & _
            "terBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""S" & _
            "tyle3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading" & _
            """ me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><Inactive" & _
            "Style parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /" & _
            "><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle pare" & _
            "nt=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, " & _
            "0, 636, 236</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderSty" & _
            "le></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""No" & _
            "rmal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer" & _
            """ /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive""" & _
            " /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><" & _
            "Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" />" & _
            "<Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector""" & _
            " /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" />" & _
            "</NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</" & _
            "Layout><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 636, 236</Cl" & _
            "ientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle pa" & _
            "rent="""" me=""Style15"" /></Blob>"
            '
            'lblCCExisiting
            '
            Me.lblCCExisiting.Location = New System.Drawing.Point(24, 205)
            Me.lblCCExisiting.Name = "lblCCExisiting"
            Me.lblCCExisiting.Size = New System.Drawing.Size(62, 16)
            Me.lblCCExisiting.TabIndex = 8
            Me.lblCCExisiting.Text = "Existing:"
            '
            'TabGroup
            '
            Me.TabGroup.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdUpdateGroup, Me.GrdGroups_TabGroup, Me.cmdAddGroup, Me.txtGroup, Me.Label4})
            Me.TabGroup.Location = New System.Drawing.Point(4, 25)
            Me.TabGroup.Name = "TabGroup"
            Me.TabGroup.Size = New System.Drawing.Size(880, 491)
            Me.TabGroup.TabIndex = 6
            Me.TabGroup.Text = "Group"
            '
            'cmdUpdateGroup
            '
            Me.cmdUpdateGroup.ForeColor = System.Drawing.Color.Blue
            Me.cmdUpdateGroup.Location = New System.Drawing.Point(400, 344)
            Me.cmdUpdateGroup.Name = "cmdUpdateGroup"
            Me.cmdUpdateGroup.Size = New System.Drawing.Size(128, 26)
            Me.cmdUpdateGroup.TabIndex = 8
            Me.cmdUpdateGroup.Text = "Update Group"
            '
            'GrdGroups_TabGroup
            '
            Me.GrdGroups_TabGroup.AllowColMove = False
            Me.GrdGroups_TabGroup.AllowColSelect = False
            Me.GrdGroups_TabGroup.AllowFilter = False
            Me.GrdGroups_TabGroup.AlternatingRows = True
            Me.GrdGroups_TabGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GrdGroups_TabGroup.GroupByCaption = "Drag a column header here to group by that column"
            Me.GrdGroups_TabGroup.Images.Add(CType(resources.GetObject("resource.Images6"), System.Drawing.Bitmap))
            Me.GrdGroups_TabGroup.Location = New System.Drawing.Point(95, 84)
            Me.GrdGroups_TabGroup.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.GrdGroups_TabGroup.Name = "GrdGroups_TabGroup"
            Me.GrdGroups_TabGroup.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.GrdGroups_TabGroup.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.GrdGroups_TabGroup.PreviewInfo.ZoomFactor = 75
            Me.GrdGroups_TabGroup.RowHeight = 20
            Me.GrdGroups_TabGroup.Size = New System.Drawing.Size(297, 284)
            Me.GrdGroups_TabGroup.TabIndex = 7
            Me.GrdGroups_TabGroup.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt;AlignVert:Center;BackColor:" & _
            "Control;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddR" & _
            "ow{BackColor:Control;}RecordSelector{AlignImage:Center;}Style13{}Heading{Wrap:Tr" & _
            "ue;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;AlignVert:Cent" & _
            "er;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}St" & _
            "yle10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style9{}</Data></Styles><Splits" & _
            "><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" Name" & _
            "="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" Colum" & _
            "nFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefR" & _
            "ecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>280</H" & _
            "eight><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" " & _
            "me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle paren" & _
            "t=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupSt" & _
            "yle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><" & _
            "HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Ina" & _
            "ctive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorS" & _
            "tyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=" & _
            """Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 293, 280</Clie" & _
            "ntRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1Tru" & _
            "eDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style pa" & _
            "rent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent" & _
            "=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=" & _
            """Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Nor" & _
            "mal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""No" & _
            "rmal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=" & _
            """Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><ve" & _
            "rtSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRe" & _
            "cSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 293, 280</ClientArea><PrintPa" & _
            "geHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style" & _
            "15"" /></Blob>"
            '
            'cmdAddGroup
            '
            Me.cmdAddGroup.ForeColor = System.Drawing.Color.Blue
            Me.cmdAddGroup.Location = New System.Drawing.Point(241, 32)
            Me.cmdAddGroup.Name = "cmdAddGroup"
            Me.cmdAddGroup.Size = New System.Drawing.Size(128, 26)
            Me.cmdAddGroup.TabIndex = 6
            Me.cmdAddGroup.Text = "Add Group"
            '
            'txtGroup
            '
            Me.txtGroup.Location = New System.Drawing.Point(96, 34)
            Me.txtGroup.Name = "txtGroup"
            Me.txtGroup.Size = New System.Drawing.Size(136, 22)
            Me.txtGroup.TabIndex = 5
            Me.txtGroup.Text = ""
            '
            'Label4
            '
            Me.Label4.Location = New System.Drawing.Point(40, 36)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(48, 16)
            Me.Label4.TabIndex = 4
            Me.Label4.Text = "Group:"
            '
            'TabSide
            '
            Me.TabSide.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdUpdateSide, Me.grdSides_TabSide, Me.cmdAddSide, Me.txtSide, Me.Label6})
            Me.TabSide.Location = New System.Drawing.Point(4, 25)
            Me.TabSide.Name = "TabSide"
            Me.TabSide.Size = New System.Drawing.Size(880, 491)
            Me.TabSide.TabIndex = 2
            Me.TabSide.Text = "Side"
            '
            'cmdUpdateSide
            '
            Me.cmdUpdateSide.ForeColor = System.Drawing.Color.Blue
            Me.cmdUpdateSide.Location = New System.Drawing.Point(248, 167)
            Me.cmdUpdateSide.Name = "cmdUpdateSide"
            Me.cmdUpdateSide.Size = New System.Drawing.Size(128, 26)
            Me.cmdUpdateSide.TabIndex = 18
            Me.cmdUpdateSide.Text = "Update Side"
            '
            'grdSides_TabSide
            '
            Me.grdSides_TabSide.AllowColMove = False
            Me.grdSides_TabSide.AllowColSelect = False
            Me.grdSides_TabSide.AllowFilter = False
            Me.grdSides_TabSide.AlternatingRows = True
            Me.grdSides_TabSide.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grdSides_TabSide.GroupByCaption = "Drag a column header here to group by that column"
            Me.grdSides_TabSide.Images.Add(CType(resources.GetObject("resource.Images7"), System.Drawing.Bitmap))
            Me.grdSides_TabSide.Location = New System.Drawing.Point(101, 71)
            Me.grdSides_TabSide.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.grdSides_TabSide.Name = "grdSides_TabSide"
            Me.grdSides_TabSide.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.grdSides_TabSide.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.grdSides_TabSide.PreviewInfo.ZoomFactor = 75
            Me.grdSides_TabSide.RowHeight = 20
            Me.grdSides_TabSide.Size = New System.Drawing.Size(139, 120)
            Me.grdSides_TabSide.TabIndex = 17
            Me.grdSides_TabSide.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt;AlignVert:Center;BackColor:" & _
            "Control;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddR" & _
            "ow{BackColor:Control;}RecordSelector{AlignImage:Center;}Style13{}Heading{Wrap:Tr" & _
            "ue;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;AlignVert:Cent" & _
            "er;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}St" & _
            "yle10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style9{}</Data></Styles><Splits" & _
            "><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" Name" & _
            "="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" Colum" & _
            "nFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefR" & _
            "ecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>116</H" & _
            "eight><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" " & _
            "me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle paren" & _
            "t=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupSt" & _
            "yle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><" & _
            "HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Ina" & _
            "ctive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorS" & _
            "tyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=" & _
            """Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 135, 116</Clie" & _
            "ntRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1Tru" & _
            "eDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style pa" & _
            "rent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent" & _
            "=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=" & _
            """Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Nor" & _
            "mal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""No" & _
            "rmal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=" & _
            """Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><ve" & _
            "rtSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRe" & _
            "cSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 135, 116</ClientArea><PrintPa" & _
            "geHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style" & _
            "15"" /></Blob>"
            '
            'cmdAddSide
            '
            Me.cmdAddSide.ForeColor = System.Drawing.Color.Blue
            Me.cmdAddSide.Location = New System.Drawing.Point(246, 30)
            Me.cmdAddSide.Name = "cmdAddSide"
            Me.cmdAddSide.Size = New System.Drawing.Size(128, 26)
            Me.cmdAddSide.TabIndex = 16
            Me.cmdAddSide.Text = "Add Side"
            '
            'txtSide
            '
            Me.txtSide.Location = New System.Drawing.Point(101, 32)
            Me.txtSide.Name = "txtSide"
            Me.txtSide.Size = New System.Drawing.Size(139, 22)
            Me.txtSide.TabIndex = 15
            Me.txtSide.Text = ""
            '
            'Label6
            '
            Me.Label6.Location = New System.Drawing.Point(45, 34)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(48, 16)
            Me.Label6.TabIndex = 14
            Me.Label6.Text = "Side:"
            '
            'TabLine
            '
            Me.TabLine.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdUpdateLine, Me.grdLines_TabLine, Me.cmdAddLine, Me.txtLine, Me.Label5})
            Me.TabLine.Location = New System.Drawing.Point(4, 25)
            Me.TabLine.Name = "TabLine"
            Me.TabLine.Size = New System.Drawing.Size(880, 491)
            Me.TabLine.TabIndex = 1
            Me.TabLine.Text = "Line"
            '
            'cmdUpdateLine
            '
            Me.cmdUpdateLine.ForeColor = System.Drawing.Color.Blue
            Me.cmdUpdateLine.Location = New System.Drawing.Point(272, 336)
            Me.cmdUpdateLine.Name = "cmdUpdateLine"
            Me.cmdUpdateLine.Size = New System.Drawing.Size(128, 26)
            Me.cmdUpdateLine.TabIndex = 13
            Me.cmdUpdateLine.Text = "Update Line"
            '
            'grdLines_TabLine
            '
            Me.grdLines_TabLine.AllowColMove = False
            Me.grdLines_TabLine.AllowColSelect = False
            Me.grdLines_TabLine.AllowFilter = False
            Me.grdLines_TabLine.AlternatingRows = True
            Me.grdLines_TabLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grdLines_TabLine.GroupByCaption = "Drag a column header here to group by that column"
            Me.grdLines_TabLine.Images.Add(CType(resources.GetObject("resource.Images8"), System.Drawing.Bitmap))
            Me.grdLines_TabLine.Location = New System.Drawing.Point(96, 72)
            Me.grdLines_TabLine.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.grdLines_TabLine.Name = "grdLines_TabLine"
            Me.grdLines_TabLine.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.grdLines_TabLine.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.grdLines_TabLine.PreviewInfo.ZoomFactor = 75
            Me.grdLines_TabLine.RowHeight = 20
            Me.grdLines_TabLine.Size = New System.Drawing.Size(170, 288)
            Me.grdLines_TabLine.TabIndex = 12
            Me.grdLines_TabLine.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt;BackColor:Control;AlignVert" & _
            ":Center;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddR" & _
            "ow{BackColor:Control;}RecordSelector{AlignImage:Center;}Style13{}Heading{Wrap:Tr" & _
            "ue;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;BackColor:Cont" & _
            "rol;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}St" & _
            "yle10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style1{}</Data></Styles><Splits" & _
            "><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" Name" & _
            "="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" Colum" & _
            "nFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefR" & _
            "ecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>284</H" & _
            "eight><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" " & _
            "me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle paren" & _
            "t=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupSt" & _
            "yle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><" & _
            "HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Ina" & _
            "ctive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorS" & _
            "tyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=" & _
            """Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 166, 284</Clie" & _
            "ntRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1Tru" & _
            "eDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style pa" & _
            "rent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent" & _
            "=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=" & _
            """Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Nor" & _
            "mal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""No" & _
            "rmal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=" & _
            """Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><ve" & _
            "rtSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRe" & _
            "cSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 166, 284</ClientArea><PrintPa" & _
            "geHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style" & _
            "15"" /></Blob>"
            '
            'cmdAddLine
            '
            Me.cmdAddLine.ForeColor = System.Drawing.Color.Blue
            Me.cmdAddLine.Location = New System.Drawing.Point(272, 32)
            Me.cmdAddLine.Name = "cmdAddLine"
            Me.cmdAddLine.Size = New System.Drawing.Size(128, 26)
            Me.cmdAddLine.TabIndex = 11
            Me.cmdAddLine.Text = "Add Line"
            '
            'txtLine
            '
            Me.txtLine.Location = New System.Drawing.Point(96, 34)
            Me.txtLine.Name = "txtLine"
            Me.txtLine.Size = New System.Drawing.Size(168, 22)
            Me.txtLine.TabIndex = 10
            Me.txtLine.Text = ""
            '
            'Label5
            '
            Me.Label5.Location = New System.Drawing.Point(40, 36)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(48, 16)
            Me.Label5.TabIndex = 9
            Me.Label5.Text = "Line:"
            '
            'TabMap
            '
            Me.TabMap.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button1, Me.Label12, Me.cmdDeleteMap, Me.cmdAddMap_TabMap, Me.grdMapSummary_TabMap, Me.grdMachine_TabMap, Me.grdSide_TabMap, Me.grdLine_TabMap, Me.grdGroup_TabMap, Me.Label11, Me.Label10, Me.Label9, Me.Label8})
            Me.TabMap.Location = New System.Drawing.Point(4, 25)
            Me.TabMap.Name = "TabMap"
            Me.TabMap.Size = New System.Drawing.Size(880, 491)
            Me.TabMap.TabIndex = 3
            Me.TabMap.Text = "Map"
            '
            'Button1
            '
            Me.Button1.Location = New System.Drawing.Point(776, 120)
            Me.Button1.Name = "Button1"
            Me.Button1.TabIndex = 28
            Me.Button1.Text = "Button1"
            Me.Button1.Visible = False
            '
            'Label12
            '
            Me.Label12.Location = New System.Drawing.Point(16, 273)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(77, 16)
            Me.Label12.TabIndex = 27
            Me.Label12.Text = "Mapping:"
            '
            'cmdDeleteMap
            '
            Me.cmdDeleteMap.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdDeleteMap.ForeColor = System.Drawing.Color.Red
            Me.cmdDeleteMap.Location = New System.Drawing.Point(601, 255)
            Me.cmdDeleteMap.Name = "cmdDeleteMap"
            Me.cmdDeleteMap.Size = New System.Drawing.Size(160, 32)
            Me.cmdDeleteMap.TabIndex = 26
            Me.cmdDeleteMap.Text = "Delete Mapping"
            '
            'cmdAddMap_TabMap
            '
            Me.cmdAddMap_TabMap.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdAddMap_TabMap.ForeColor = System.Drawing.Color.Blue
            Me.cmdAddMap_TabMap.Location = New System.Drawing.Point(768, 30)
            Me.cmdAddMap_TabMap.Name = "cmdAddMap_TabMap"
            Me.cmdAddMap_TabMap.Size = New System.Drawing.Size(80, 48)
            Me.cmdAddMap_TabMap.TabIndex = 25
            Me.cmdAddMap_TabMap.Text = "Create Mapping"
            '
            'grdMapSummary_TabMap
            '
            Me.grdMapSummary_TabMap.AllowColMove = False
            Me.grdMapSummary_TabMap.AllowColSelect = False
            Me.grdMapSummary_TabMap.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.grdMapSummary_TabMap.AllowUpdate = False
            Me.grdMapSummary_TabMap.AllowUpdateOnBlur = False
            Me.grdMapSummary_TabMap.AlternatingRows = True
            Me.grdMapSummary_TabMap.FilterBar = True
            Me.grdMapSummary_TabMap.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grdMapSummary_TabMap.GroupByCaption = "Drag a column header here to group by that column"
            Me.grdMapSummary_TabMap.Images.Add(CType(resources.GetObject("resource.Images9"), System.Drawing.Bitmap))
            Me.grdMapSummary_TabMap.Location = New System.Drawing.Point(18, 292)
            Me.grdMapSummary_TabMap.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.grdMapSummary_TabMap.Name = "grdMapSummary_TabMap"
            Me.grdMapSummary_TabMap.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.grdMapSummary_TabMap.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.grdMapSummary_TabMap.PreviewInfo.ZoomFactor = 75
            Me.grdMapSummary_TabMap.RowHeight = 20
            Me.grdMapSummary_TabMap.Size = New System.Drawing.Size(742, 188)
            Me.grdMapSummary_TabMap.TabIndex = 24
            Me.grdMapSummary_TabMap.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{BackColor:Window;}Footer{}Capti" & _
            "on{AlignHorz:Center;}Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt;AlignVert:" & _
            "Center;BackColor:Control;}HighlightRow{ForeColor:HighlightText;BackColor:Highlig" & _
            "ht;}Style12{}OddRow{BackColor:Control;}RecordSelector{AlignImage:Center;}Style13" & _
            "{}Heading{Wrap:True;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Cent" & _
            "er;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Co" & _
            "ntrol;}Style8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style9{}</Data" & _
            "></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSe" & _
            "lect=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""True"" CaptionHei" & _
            "ght=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" Marqu" & _
            "eeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidth=""16"" Vertical" & _
            "ScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>184</Height><CaptionStyle pare" & _
            "nt=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowSt" & _
            "yle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style1" & _
            "3"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""S" & _
            "tyle12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent" & _
            "=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><Od" & _
            "dRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelec" & _
            "tor"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent" & _
            "=""Normal"" me=""Style1"" /><ClientRect>0, 0, 738, 184</ClientRect><BorderSide>0</Bo" & _
            "rderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Spli" & _
            "ts><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Headin" & _
            "g"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" " & _
            "/><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /" & _
            "><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /" & _
            "><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Sty" & _
            "le parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" " & _
            "/><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><" & _
            "horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>16</DefaultRec" & _
            "SelWidth><ClientArea>0, 0, 738, 184</ClientArea><PrintPageHeaderStyle parent="""" " & _
            "me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'grdMachine_TabMap
            '
            Me.grdMachine_TabMap.AllowColMove = False
            Me.grdMachine_TabMap.AllowColSelect = False
            Me.grdMachine_TabMap.AllowFilter = False
            Me.grdMachine_TabMap.AllowUpdate = False
            Me.grdMachine_TabMap.AllowUpdateOnBlur = False
            Me.grdMachine_TabMap.AlternatingRows = True
            Me.grdMachine_TabMap.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grdMachine_TabMap.GroupByCaption = "Drag a column header here to group by that column"
            Me.grdMachine_TabMap.Images.Add(CType(resources.GetObject("resource.Images10"), System.Drawing.Bitmap))
            Me.grdMachine_TabMap.Location = New System.Drawing.Point(489, 30)
            Me.grdMachine_TabMap.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
            Me.grdMachine_TabMap.Name = "grdMachine_TabMap"
            Me.grdMachine_TabMap.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.grdMachine_TabMap.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.grdMachine_TabMap.PreviewInfo.ZoomFactor = 75
            Me.grdMachine_TabMap.RowHeight = 20
            Me.grdMachine_TabMap.Size = New System.Drawing.Size(271, 218)
            Me.grdMachine_TabMap.TabIndex = 23
            Me.grdMachine_TabMap.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt;AlignVert:Center;BackColor:" & _
            "Control;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddR" & _
            "ow{BackColor:Control;}RecordSelector{AlignImage:Center;}Style13{}Heading{Wrap:Tr" & _
            "ue;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;AlignVert:Cent" & _
            "er;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}St" & _
            "yle10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style9{}</Data></Styles><Splits" & _
            "><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" Name" & _
            "="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" Colum" & _
            "nFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefR" & _
            "ecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>214</H" & _
            "eight><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" " & _
            "me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle paren" & _
            "t=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupSt" & _
            "yle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><" & _
            "HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Ina" & _
            "ctive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorS" & _
            "tyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=" & _
            """Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 267, 214</Clie" & _
            "ntRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1Tru" & _
            "eDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style pa" & _
            "rent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent" & _
            "=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=" & _
            """Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Nor" & _
            "mal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""No" & _
            "rmal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=" & _
            """Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><ve" & _
            "rtSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRe" & _
            "cSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 267, 214</ClientArea><PrintPa" & _
            "geHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style" & _
            "15"" /></Blob>"
            '
            'grdSide_TabMap
            '
            Me.grdSide_TabMap.AllowColMove = False
            Me.grdSide_TabMap.AllowColSelect = False
            Me.grdSide_TabMap.AllowFilter = False
            Me.grdSide_TabMap.AllowUpdate = False
            Me.grdSide_TabMap.AllowUpdateOnBlur = False
            Me.grdSide_TabMap.AlternatingRows = True
            Me.grdSide_TabMap.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grdSide_TabMap.GroupByCaption = "Drag a column header here to group by that column"
            Me.grdSide_TabMap.Images.Add(CType(resources.GetObject("resource.Images11"), System.Drawing.Bitmap))
            Me.grdSide_TabMap.Location = New System.Drawing.Point(388, 30)
            Me.grdSide_TabMap.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.grdSide_TabMap.Name = "grdSide_TabMap"
            Me.grdSide_TabMap.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.grdSide_TabMap.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.grdSide_TabMap.PreviewInfo.ZoomFactor = 75
            Me.grdSide_TabMap.RowHeight = 20
            Me.grdSide_TabMap.Size = New System.Drawing.Size(96, 218)
            Me.grdSide_TabMap.TabIndex = 18
            Me.grdSide_TabMap.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt;BackColor:Control;AlignVert" & _
            ":Center;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddR" & _
            "ow{BackColor:Control;}RecordSelector{AlignImage:Center;}Style13{}Heading{Wrap:Tr" & _
            "ue;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;BackColor:Cont" & _
            "rol;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}St" & _
            "yle10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style1{}</Data></Styles><Splits" & _
            "><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" Name" & _
            "="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" Colum" & _
            "nFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefR" & _
            "ecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>214</H" & _
            "eight><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" " & _
            "me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle paren" & _
            "t=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupSt" & _
            "yle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><" & _
            "HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Ina" & _
            "ctive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorS" & _
            "tyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=" & _
            """Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 92, 214</Clien" & _
            "tRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1True" & _
            "DBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style par" & _
            "ent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=" & _
            """Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""" & _
            "Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Norm" & _
            "al"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Nor" & _
            "mal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""" & _
            "Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><ver" & _
            "tSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRec" & _
            "SelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 92, 214</ClientArea><PrintPage" & _
            "HeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15" & _
            """ /></Blob>"
            '
            'grdLine_TabMap
            '
            Me.grdLine_TabMap.AllowColMove = False
            Me.grdLine_TabMap.AllowColSelect = False
            Me.grdLine_TabMap.AllowFilter = False
            Me.grdLine_TabMap.AllowUpdate = False
            Me.grdLine_TabMap.AllowUpdateOnBlur = False
            Me.grdLine_TabMap.AlternatingRows = True
            Me.grdLine_TabMap.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grdLine_TabMap.GroupByCaption = "Drag a column header here to group by that column"
            Me.grdLine_TabMap.Images.Add(CType(resources.GetObject("resource.Images12"), System.Drawing.Bitmap))
            Me.grdLine_TabMap.Location = New System.Drawing.Point(213, 30)
            Me.grdLine_TabMap.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.grdLine_TabMap.Name = "grdLine_TabMap"
            Me.grdLine_TabMap.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.grdLine_TabMap.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.grdLine_TabMap.PreviewInfo.ZoomFactor = 75
            Me.grdLine_TabMap.RowHeight = 20
            Me.grdLine_TabMap.Size = New System.Drawing.Size(170, 218)
            Me.grdLine_TabMap.TabIndex = 13
            Me.grdLine_TabMap.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt;AlignVert:Center;BackColor:" & _
            "Control;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddR" & _
            "ow{BackColor:Control;}RecordSelector{AlignImage:Center;}Style13{}Heading{Wrap:Tr" & _
            "ue;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;AlignVert:Cent" & _
            "er;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}St" & _
            "yle10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style9{}</Data></Styles><Splits" & _
            "><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" Name" & _
            "="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" Colum" & _
            "nFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefR" & _
            "ecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>214</H" & _
            "eight><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" " & _
            "me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle paren" & _
            "t=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupSt" & _
            "yle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><" & _
            "HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Ina" & _
            "ctive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorS" & _
            "tyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=" & _
            """Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 166, 214</Clie" & _
            "ntRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1Tru" & _
            "eDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style pa" & _
            "rent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent" & _
            "=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=" & _
            """Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Nor" & _
            "mal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""No" & _
            "rmal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=" & _
            """Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><ve" & _
            "rtSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRe" & _
            "cSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 166, 214</ClientArea><PrintPa" & _
            "geHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style" & _
            "15"" /></Blob>"
            '
            'grdGroup_TabMap
            '
            Me.grdGroup_TabMap.AllowColMove = False
            Me.grdGroup_TabMap.AllowColSelect = False
            Me.grdGroup_TabMap.AllowFilter = False
            Me.grdGroup_TabMap.AllowUpdate = False
            Me.grdGroup_TabMap.AllowUpdateOnBlur = False
            Me.grdGroup_TabMap.AlternatingRows = True
            Me.grdGroup_TabMap.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grdGroup_TabMap.GroupByCaption = "Drag a column header here to group by that column"
            Me.grdGroup_TabMap.Images.Add(CType(resources.GetObject("resource.Images13"), System.Drawing.Bitmap))
            Me.grdGroup_TabMap.Location = New System.Drawing.Point(19, 30)
            Me.grdGroup_TabMap.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.grdGroup_TabMap.Name = "grdGroup_TabMap"
            Me.grdGroup_TabMap.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.grdGroup_TabMap.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.grdGroup_TabMap.PreviewInfo.ZoomFactor = 75
            Me.grdGroup_TabMap.RowHeight = 20
            Me.grdGroup_TabMap.Size = New System.Drawing.Size(189, 218)
            Me.grdGroup_TabMap.TabIndex = 11
            Me.grdGroup_TabMap.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt;BackColor:Control;AlignVert" & _
            ":Center;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddR" & _
            "ow{BackColor:Control;}RecordSelector{AlignImage:Center;}Style13{}Heading{Wrap:Tr" & _
            "ue;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;BackColor:Cont" & _
            "rol;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}St" & _
            "yle10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style1{}</Data></Styles><Splits" & _
            "><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" Name" & _
            "="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" Colum" & _
            "nFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefR" & _
            "ecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>214</H" & _
            "eight><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" " & _
            "me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle paren" & _
            "t=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupSt" & _
            "yle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><" & _
            "HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Ina" & _
            "ctive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorS" & _
            "tyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=" & _
            """Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 185, 214</Clie" & _
            "ntRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1Tru" & _
            "eDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style pa" & _
            "rent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent" & _
            "=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=" & _
            """Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Nor" & _
            "mal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""No" & _
            "rmal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=" & _
            """Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><ve" & _
            "rtSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRe" & _
            "cSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 185, 214</ClientArea><PrintPa" & _
            "geHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style" & _
            "15"" /></Blob>"
            '
            'Label11
            '
            Me.Label11.Location = New System.Drawing.Point(487, 12)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(77, 16)
            Me.Label11.TabIndex = 10
            Me.Label11.Text = "Machine:"
            '
            'Label10
            '
            Me.Label10.Location = New System.Drawing.Point(386, 12)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(62, 16)
            Me.Label10.TabIndex = 9
            Me.Label10.Text = "Side:"
            '
            'Label9
            '
            Me.Label9.Location = New System.Drawing.Point(211, 11)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(62, 16)
            Me.Label9.TabIndex = 8
            Me.Label9.Text = "Line:"
            '
            'Label8
            '
            Me.Label8.Location = New System.Drawing.Point(18, 11)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(62, 16)
            Me.Label8.TabIndex = 7
            Me.Label8.Text = "Group:"
            '
            'TabCostCenterMap
            '
            Me.TabCostCenterMap.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnDeleteMappings_TabCostCenterMap, Me.grdMappedMachines_TabCostCenterMap, Me.lblMappedMachines_TabCostCenterMap, Me.btnMapMachine_TabCostCenterMap, Me.lblMachines_TabCostCenterMap, Me.grdMachines_TabCostCenterMap, Me.numTable_TabCostCenterMap, Me.lblTable_TabCostCenterMap, Me.grdCostCenters_TabCostCenterMap, Me.lblCostCenters_TabCostCenterMap})
            Me.TabCostCenterMap.Location = New System.Drawing.Point(4, 25)
            Me.TabCostCenterMap.Name = "TabCostCenterMap"
            Me.TabCostCenterMap.Size = New System.Drawing.Size(880, 491)
            Me.TabCostCenterMap.TabIndex = 8
            Me.TabCostCenterMap.Text = "Cost Center Map"
            '
            'btnDeleteMappings_TabCostCenterMap
            '
            Me.btnDeleteMappings_TabCostCenterMap.ForeColor = System.Drawing.Color.Blue
            Me.btnDeleteMappings_TabCostCenterMap.Location = New System.Drawing.Point(520, 224)
            Me.btnDeleteMappings_TabCostCenterMap.Name = "btnDeleteMappings_TabCostCenterMap"
            Me.btnDeleteMappings_TabCostCenterMap.Size = New System.Drawing.Size(144, 26)
            Me.btnDeleteMappings_TabCostCenterMap.TabIndex = 18
            Me.btnDeleteMappings_TabCostCenterMap.Text = "Delete Mapping(s)"
            '
            'grdMappedMachines_TabCostCenterMap
            '
            Me.grdMappedMachines_TabCostCenterMap.AllowUpdate = False
            Me.grdMappedMachines_TabCostCenterMap.AlternatingRows = True
            Me.grdMappedMachines_TabCostCenterMap.CaptionHeight = 17
            Me.grdMappedMachines_TabCostCenterMap.FilterBar = True
            Me.grdMappedMachines_TabCostCenterMap.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grdMappedMachines_TabCostCenterMap.GroupByCaption = "Drag a column header here to group by that column"
            Me.grdMappedMachines_TabCostCenterMap.Images.Add(CType(resources.GetObject("resource.Images14"), System.Drawing.Bitmap))
            Me.grdMappedMachines_TabCostCenterMap.Location = New System.Drawing.Point(16, 224)
            Me.grdMappedMachines_TabCostCenterMap.Name = "grdMappedMachines_TabCostCenterMap"
            Me.grdMappedMachines_TabCostCenterMap.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.grdMappedMachines_TabCostCenterMap.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.grdMappedMachines_TabCostCenterMap.PreviewInfo.ZoomFactor = 75
            Me.grdMappedMachines_TabCostCenterMap.RowHeight = 15
            Me.grdMappedMachines_TabCostCenterMap.Size = New System.Drawing.Size(496, 136)
            Me.grdMappedMachines_TabCostCenterMap.TabIndex = 17
            Me.grdMappedMachines_TabCostCenterMap.Text = "C1TrueDBGrid1"
            Me.grdMappedMachines_TabCostCenterMap.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Style9{}Normal{Font:Microsoft Sans Serif, 9.75pt;}HighlightRow{ForeColor:Hig" & _
            "hlightText;BackColor:Highlight;}Style14{}OddRow{}RecordSelector{AlignImage:Cente" & _
            "r;}Style15{}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeCol" & _
            "or:ControlText;BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style11{}Style" & _
            "12{}Style13{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name" & _
            "="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" Colum" & _
            "nFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelect" & _
            "orWidth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""" & _
            "1""><Height>132</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle" & _
            " parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><Fil" & _
            "terBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""S" & _
            "tyle3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading" & _
            """ me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><Inactive" & _
            "Style parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /" & _
            "><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle pare" & _
            "nt=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, " & _
            "0, 492, 132</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderSty" & _
            "le></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""No" & _
            "rmal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer" & _
            """ /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive""" & _
            " /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><" & _
            "Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" />" & _
            "<Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector""" & _
            " /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" />" & _
            "</NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</" & _
            "Layout><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 492, 132</Cl" & _
            "ientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle pa" & _
            "rent="""" me=""Style15"" /></Blob>"
            '
            'lblMappedMachines_TabCostCenterMap
            '
            Me.lblMappedMachines_TabCostCenterMap.Location = New System.Drawing.Point(16, 208)
            Me.lblMappedMachines_TabCostCenterMap.Name = "lblMappedMachines_TabCostCenterMap"
            Me.lblMappedMachines_TabCostCenterMap.Size = New System.Drawing.Size(128, 16)
            Me.lblMappedMachines_TabCostCenterMap.TabIndex = 16
            Me.lblMappedMachines_TabCostCenterMap.Text = "Mapped Machines:"
            '
            'btnMapMachine_TabCostCenterMap
            '
            Me.btnMapMachine_TabCostCenterMap.ForeColor = System.Drawing.Color.Blue
            Me.btnMapMachine_TabCostCenterMap.Location = New System.Drawing.Point(688, 40)
            Me.btnMapMachine_TabCostCenterMap.Name = "btnMapMachine_TabCostCenterMap"
            Me.btnMapMachine_TabCostCenterMap.Size = New System.Drawing.Size(144, 26)
            Me.btnMapMachine_TabCostCenterMap.TabIndex = 15
            Me.btnMapMachine_TabCostCenterMap.Text = "Map Machine"
            '
            'lblMachines_TabCostCenterMap
            '
            Me.lblMachines_TabCostCenterMap.Location = New System.Drawing.Point(480, 24)
            Me.lblMachines_TabCostCenterMap.Name = "lblMachines_TabCostCenterMap"
            Me.lblMachines_TabCostCenterMap.Size = New System.Drawing.Size(104, 16)
            Me.lblMachines_TabCostCenterMap.TabIndex = 14
            Me.lblMachines_TabCostCenterMap.Text = "Machines:"
            '
            'grdMachines_TabCostCenterMap
            '
            Me.grdMachines_TabCostCenterMap.AllowUpdate = False
            Me.grdMachines_TabCostCenterMap.AlternatingRows = True
            Me.grdMachines_TabCostCenterMap.CaptionHeight = 17
            Me.grdMachines_TabCostCenterMap.FilterBar = True
            Me.grdMachines_TabCostCenterMap.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grdMachines_TabCostCenterMap.GroupByCaption = "Drag a column header here to group by that column"
            Me.grdMachines_TabCostCenterMap.Images.Add(CType(resources.GetObject("resource.Images15"), System.Drawing.Bitmap))
            Me.grdMachines_TabCostCenterMap.Location = New System.Drawing.Point(480, 40)
            Me.grdMachines_TabCostCenterMap.Name = "grdMachines_TabCostCenterMap"
            Me.grdMachines_TabCostCenterMap.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.grdMachines_TabCostCenterMap.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.grdMachines_TabCostCenterMap.PreviewInfo.ZoomFactor = 75
            Me.grdMachines_TabCostCenterMap.RowHeight = 15
            Me.grdMachines_TabCostCenterMap.Size = New System.Drawing.Size(184, 136)
            Me.grdMachines_TabCostCenterMap.TabIndex = 13
            Me.grdMachines_TabCostCenterMap.Text = "C1TrueDBGrid1"
            Me.grdMachines_TabCostCenterMap.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Style9{}Normal{Font:Microsoft Sans Serif, 9.75pt;}HighlightRow{ForeColor:Hig" & _
            "hlightText;BackColor:Highlight;}Style14{}OddRow{}RecordSelector{AlignImage:Cente" & _
            "r;}Style15{}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeCol" & _
            "or:ControlText;BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style11{}Style" & _
            "12{}Style13{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name" & _
            "="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" Colum" & _
            "nFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelect" & _
            "orWidth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""" & _
            "1""><Height>132</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle" & _
            " parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><Fil" & _
            "terBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""S" & _
            "tyle3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading" & _
            """ me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><Inactive" & _
            "Style parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /" & _
            "><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle pare" & _
            "nt=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, " & _
            "0, 180, 132</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderSty" & _
            "le></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""No" & _
            "rmal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer" & _
            """ /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive""" & _
            " /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><" & _
            "Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" />" & _
            "<Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector""" & _
            " /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" />" & _
            "</NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</" & _
            "Layout><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 180, 132</Cl" & _
            "ientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle pa" & _
            "rent="""" me=""Style15"" /></Blob>"
            '
            'numTable_TabCostCenterMap
            '
            Me.numTable_TabCostCenterMap.Location = New System.Drawing.Point(408, 40)
            Me.numTable_TabCostCenterMap.Maximum = New Decimal(New Integer() {9, 0, 0, 0})
            Me.numTable_TabCostCenterMap.Name = "numTable_TabCostCenterMap"
            Me.numTable_TabCostCenterMap.Size = New System.Drawing.Size(48, 22)
            Me.numTable_TabCostCenterMap.TabIndex = 12
            Me.numTable_TabCostCenterMap.Value = New Decimal(New Integer() {1, 0, 0, 0})
            '
            'lblTable_TabCostCenterMap
            '
            Me.lblTable_TabCostCenterMap.Location = New System.Drawing.Point(408, 24)
            Me.lblTable_TabCostCenterMap.Name = "lblTable_TabCostCenterMap"
            Me.lblTable_TabCostCenterMap.Size = New System.Drawing.Size(48, 16)
            Me.lblTable_TabCostCenterMap.TabIndex = 11
            Me.lblTable_TabCostCenterMap.Text = "Table:"
            '
            'grdCostCenters_TabCostCenterMap
            '
            Me.grdCostCenters_TabCostCenterMap.AllowUpdate = False
            Me.grdCostCenters_TabCostCenterMap.AlternatingRows = True
            Me.grdCostCenters_TabCostCenterMap.CaptionHeight = 17
            Me.grdCostCenters_TabCostCenterMap.FilterBar = True
            Me.grdCostCenters_TabCostCenterMap.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grdCostCenters_TabCostCenterMap.GroupByCaption = "Drag a column header here to group by that column"
            Me.grdCostCenters_TabCostCenterMap.Images.Add(CType(resources.GetObject("resource.Images16"), System.Drawing.Bitmap))
            Me.grdCostCenters_TabCostCenterMap.Location = New System.Drawing.Point(16, 40)
            Me.grdCostCenters_TabCostCenterMap.Name = "grdCostCenters_TabCostCenterMap"
            Me.grdCostCenters_TabCostCenterMap.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.grdCostCenters_TabCostCenterMap.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.grdCostCenters_TabCostCenterMap.PreviewInfo.ZoomFactor = 75
            Me.grdCostCenters_TabCostCenterMap.RowHeight = 15
            Me.grdCostCenters_TabCostCenterMap.Size = New System.Drawing.Size(360, 136)
            Me.grdCostCenters_TabCostCenterMap.TabIndex = 10
            Me.grdCostCenters_TabCostCenterMap.Text = "C1TrueDBGrid1"
            Me.grdCostCenters_TabCostCenterMap.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Style1{}Normal{Font:Microsoft Sans Serif, 9.75pt;}HighlightRow{ForeColor:Hig" & _
            "hlightText;BackColor:Highlight;}Style12{}OddRow{}RecordSelector{AlignImage:Cente" & _
            "r;}Style13{}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeCo" & _
            "lor:ControlText;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}Style" & _
            "14{}Style15{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name" & _
            "="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" Colum" & _
            "nFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelect" & _
            "orWidth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""" & _
            "1""><Height>132</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle" & _
            " parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><Fil" & _
            "terBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""S" & _
            "tyle3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading" & _
            """ me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><Inactive" & _
            "Style parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /" & _
            "><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle pare" & _
            "nt=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, " & _
            "0, 356, 132</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderSty" & _
            "le></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""No" & _
            "rmal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer" & _
            """ /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive""" & _
            " /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><" & _
            "Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" />" & _
            "<Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector""" & _
            " /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" />" & _
            "</NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</" & _
            "Layout><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 356, 132</Cl" & _
            "ientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle pa" & _
            "rent="""" me=""Style15"" /></Blob>"
            '
            'lblCostCenters_TabCostCenterMap
            '
            Me.lblCostCenters_TabCostCenterMap.Location = New System.Drawing.Point(16, 24)
            Me.lblCostCenters_TabCostCenterMap.Name = "lblCostCenters_TabCostCenterMap"
            Me.lblCostCenters_TabCostCenterMap.Size = New System.Drawing.Size(104, 16)
            Me.lblCostCenters_TabCostCenterMap.TabIndex = 9
            Me.lblCostCenters_TabCostCenterMap.Text = "Cost Centers:"
            '
            'TabMachine
            '
            Me.TabMachine.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdUpdateMachine, Me.grdMachines_TabMachine, Me.cmdAddMachine, Me.txtMachine, Me.Label7})
            Me.TabMachine.Location = New System.Drawing.Point(4, 25)
            Me.TabMachine.Name = "TabMachine"
            Me.TabMachine.Size = New System.Drawing.Size(880, 491)
            Me.TabMachine.TabIndex = 4
            Me.TabMachine.Text = "Machine"
            '
            'cmdUpdateMachine
            '
            Me.cmdUpdateMachine.ForeColor = System.Drawing.Color.Blue
            Me.cmdUpdateMachine.Location = New System.Drawing.Point(418, 264)
            Me.cmdUpdateMachine.Name = "cmdUpdateMachine"
            Me.cmdUpdateMachine.Size = New System.Drawing.Size(128, 26)
            Me.cmdUpdateMachine.TabIndex = 23
            Me.cmdUpdateMachine.Text = "Update Machine"
            '
            'grdMachines_TabMachine
            '
            Me.grdMachines_TabMachine.AllowColMove = False
            Me.grdMachines_TabMachine.AllowColSelect = False
            Me.grdMachines_TabMachine.AlternatingRows = True
            Me.grdMachines_TabMachine.FilterBar = True
            Me.grdMachines_TabMachine.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grdMachines_TabMachine.GroupByCaption = "Drag a column header here to group by that column"
            Me.grdMachines_TabMachine.Images.Add(CType(resources.GetObject("resource.Images17"), System.Drawing.Bitmap))
            Me.grdMachines_TabMachine.Location = New System.Drawing.Point(26, 74)
            Me.grdMachines_TabMachine.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.grdMachines_TabMachine.Name = "grdMachines_TabMachine"
            Me.grdMachines_TabMachine.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.grdMachines_TabMachine.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.grdMachines_TabMachine.PreviewInfo.ZoomFactor = 75
            Me.grdMachines_TabMachine.RowHeight = 20
            Me.grdMachines_TabMachine.Size = New System.Drawing.Size(382, 294)
            Me.grdMachines_TabMachine.TabIndex = 22
            Me.grdMachines_TabMachine.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt;BackColor:Control;AlignVert" & _
            ":Center;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddR" & _
            "ow{BackColor:Control;}RecordSelector{AlignImage:Center;}Style13{}Heading{Wrap:Tr" & _
            "ue;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;BackColor:Cont" & _
            "rol;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}St" & _
            "yle10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style1{}</Data></Styles><Splits" & _
            "><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" Name" & _
            "="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" Colum" & _
            "nFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelect" & _
            "orWidth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""" & _
            "1""><Height>290</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle" & _
            " parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><Fil" & _
            "terBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""S" & _
            "tyle3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading" & _
            """ me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><Inactive" & _
            "Style parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /" & _
            "><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle pare" & _
            "nt=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, " & _
            "0, 378, 290</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderSty" & _
            "le></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""No" & _
            "rmal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer" & _
            """ /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive""" & _
            " /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><" & _
            "Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" />" & _
            "<Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector""" & _
            " /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" />" & _
            "</NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</" & _
            "Layout><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 378, 290</Cl" & _
            "ientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle pa" & _
            "rent="""" me=""Style15"" /></Blob>"
            '
            'cmdAddMachine
            '
            Me.cmdAddMachine.ForeColor = System.Drawing.Color.Blue
            Me.cmdAddMachine.Location = New System.Drawing.Point(248, 34)
            Me.cmdAddMachine.Name = "cmdAddMachine"
            Me.cmdAddMachine.Size = New System.Drawing.Size(128, 26)
            Me.cmdAddMachine.TabIndex = 21
            Me.cmdAddMachine.Text = "Add Machine"
            '
            'txtMachine
            '
            Me.txtMachine.Location = New System.Drawing.Point(103, 36)
            Me.txtMachine.Name = "txtMachine"
            Me.txtMachine.Size = New System.Drawing.Size(136, 22)
            Me.txtMachine.TabIndex = 20
            Me.txtMachine.Text = ""
            '
            'Label7
            '
            Me.Label7.Location = New System.Drawing.Point(24, 38)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(72, 16)
            Me.Label7.TabIndex = 19
            Me.Label7.Text = "Machine:"
            '
            'cboOpenOrders
            '
            Me.cboOpenOrders.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboOpenOrders.AutoCompletion = True
            Me.cboOpenOrders.AutoDropDown = True
            Me.cboOpenOrders.AutoSelect = True
            Me.cboOpenOrders.Caption = ""
            Me.cboOpenOrders.CaptionHeight = 17
            Me.cboOpenOrders.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboOpenOrders.ColumnCaptionHeight = 17
            Me.cboOpenOrders.ColumnFooterHeight = 17
            Me.cboOpenOrders.ColumnHeaders = False
            Me.cboOpenOrders.ContentHeight = 15
            Me.cboOpenOrders.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboOpenOrders.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboOpenOrders.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboOpenOrders.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboOpenOrders.EditorHeight = 15
            Me.cboOpenOrders.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboOpenOrders.Images.Add(CType(resources.GetObject("resource.Images18"), System.Drawing.Bitmap))
            Me.cboOpenOrders.ItemHeight = 15
            Me.cboOpenOrders.Location = New System.Drawing.Point(24, 24)
            Me.cboOpenOrders.MatchEntryTimeout = CType(2000, Long)
            Me.cboOpenOrders.MaxDropDownItems = CType(10, Short)
            Me.cboOpenOrders.MaxLength = 32767
            Me.cboOpenOrders.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboOpenOrders.Name = "cboOpenOrders"
            Me.cboOpenOrders.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboOpenOrders.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboOpenOrders.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboOpenOrders.Size = New System.Drawing.Size(256, 21)
            Me.cboOpenOrders.TabIndex = 0
            Me.cboOpenOrders.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            "ultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label18, Me.NumericUpDown2, Me.Label17, Me.NumericUpDown1})
            Me.GroupBox1.Location = New System.Drawing.Point(24, 88)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(256, 72)
            Me.GroupBox1.TabIndex = 92
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Lunch Start"
            '
            'NumericUpDown1
            '
            Me.NumericUpDown1.Location = New System.Drawing.Point(16, 40)
            Me.NumericUpDown1.Maximum = New Decimal(New Integer() {14, 0, 0, 0})
            Me.NumericUpDown1.Minimum = New Decimal(New Integer() {11, 0, 0, 0})
            Me.NumericUpDown1.Name = "NumericUpDown1"
            Me.NumericUpDown1.Size = New System.Drawing.Size(64, 22)
            Me.NumericUpDown1.TabIndex = 93
            Me.NumericUpDown1.Value = New Decimal(New Integer() {11, 0, 0, 0})
            '
            'Label17
            '
            Me.Label17.Location = New System.Drawing.Point(16, 24)
            Me.Label17.Name = "Label17"
            Me.Label17.Size = New System.Drawing.Size(62, 16)
            Me.Label17.TabIndex = 94
            Me.Label17.Text = "Hour:"
            '
            'Label18
            '
            Me.Label18.Location = New System.Drawing.Point(128, 24)
            Me.Label18.Name = "Label18"
            Me.Label18.Size = New System.Drawing.Size(62, 16)
            Me.Label18.TabIndex = 96
            Me.Label18.Text = "Minute:"
            '
            'NumericUpDown2
            '
            Me.NumericUpDown2.Location = New System.Drawing.Point(128, 40)
            Me.NumericUpDown2.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
            Me.NumericUpDown2.Name = "NumericUpDown2"
            Me.NumericUpDown2.Size = New System.Drawing.Size(64, 22)
            Me.NumericUpDown2.TabIndex = 95
            '
            'CheckBox1
            '
            Me.CheckBox1.Location = New System.Drawing.Point(24, 168)
            Me.CheckBox1.Name = "CheckBox1"
            Me.CheckBox1.TabIndex = 93
            Me.CheckBox1.Text = "No Serialize"
            '
            'frmGrpLineSideBenchMap
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(920, 564)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabGrpLinemap})
            Me.Name = "frmGrpLineSideBenchMap"
            Me.Text = "Group, Line, Side, Bench and Cost Center Relationships"
            Me.TabGrpLinemap.ResumeLayout(False)
            Me.TabSummary.ResumeLayout(False)
            CType(Me.grdMachines_TabSummary, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.grdSides_TabSummary, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.grdLines_TabSummary, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.grdGroups_TabSummary, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabCostCenter.ResumeLayout(False)
            CType(Me.cboWorkAreas, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grbUpdCCUPH.ResumeLayout(False)
            CType(Me.grdExistingCC_TabCostCenter, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabGroup.ResumeLayout(False)
            CType(Me.GrdGroups_TabGroup, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabSide.ResumeLayout(False)
            CType(Me.grdSides_TabSide, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabLine.ResumeLayout(False)
            CType(Me.grdLines_TabLine, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabMap.ResumeLayout(False)
            CType(Me.grdMapSummary_TabMap, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.grdMachine_TabMap, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.grdSide_TabMap, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.grdLine_TabMap, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.grdGroup_TabMap, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabCostCenterMap.ResumeLayout(False)
            CType(Me.grdMappedMachines_TabCostCenterMap, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.grdMachines_TabCostCenterMap, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.numTable_TabCostCenterMap, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.grdCostCenters_TabCostCenterMap, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabMachine.ResumeLayout(False)
            CType(Me.grdMachines_TabMachine, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboOpenOrders, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox1.ResumeLayout(False)
            CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmGrpLineSideBenchMap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Me.LoadGroups()
                Me.LoadAllLines()
                Me.LoadAllSides()
                Me.LoadAllMachines()
                Me.LoadAllMappings()
                Me.LoadCostCenters()
                Me.LoadCostCenterMaps()
                Me.LoadWorkArea()

                '***********************************
                'Set security for delete cost center
                '***********************************
                If ApplicationUser.GetPermission("DeleteCostCenter") > 0 Then
                    btnDeleteCC_TabCostCenter.Visible = True
                Else
                    btnDeleteCC_TabCostCenter.Visible = False
                End If
                '***********************************
                'Set security for update UPH
                '***********************************
                If ApplicationUser.GetPermission("CCUPHUpdate") > 0 Then
                    Me.grbUpdCCUPH.Visible = True
                Else
                    grbUpdCCUPH.Visible = False
                End If
                '***********************************
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString)
            End Try
        End Sub

        '****************************************************
        'Private Sub TabGrpLinemap_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabGrpLinemap.SelectedIndexChanged
        '    Select Case LCase(TabGrpLinemap.SelectedTab.Name)
        '        Case LCase("tabSummary")

        '        Case LCase("tabGroup")

        '        Case LCase("tabLine")

        '        Case LCase("tabSide")

        '        Case LCase("tabMachine")

        '        Case LCase("tabMap")

        '    End Select
        'End Sub

        '****************************************************
        Private Sub LoadGroups()
            Dim dtGroups As DataTable

            Try
                dtGroups = Me.objInventory.GetGroups(, , 1)

                Me.grdGroups_TabSummary.ClearFields()
                Me.grdGroups_TabSummary.DataSource = dtGroups.DefaultView
                SetGroupGridProperties_TabSummary()

                Me.GrdGroups_TabGroup.ClearFields()
                Me.GrdGroups_TabGroup.DataSource = dtGroups.DefaultView
                SetGroupGridProperties_TabGroup()

                Me.grdGroup_TabMap.ClearFields()
                Me.grdGroup_TabMap.DataSource = dtGroups.DefaultView
                SetGroupGridProperties_TabMap()

            Catch ex As Exception
                Throw New Exception("LoadGroups:: " & ex.Message.ToString)
            Finally
                If Not IsNothing(dtGroups) Then
                    dtGroups.Dispose()
                    dtGroups = Nothing
                End If
            End Try
        End Sub
        '****************************************************
        'Load Lines for the group
        '****************************************************
        Private Sub LoadLinesForGroup(ByVal iGroupID As Integer)
            Dim dtLines As DataTable
            Try
                dtLines = Me.objInventory.GetLines(iGroupID)
                Me.grdLines_TabSummary.ClearFields()
                Me.grdLines_TabSummary.DataSource = dtLines.DefaultView
                SetLineGridProperties_TabSummary()

            Catch ex As Exception
                Throw New Exception("LoadLinesForGroup:: " & ex.Message.ToString)
            Finally
                If Not IsNothing(dtLines) Then
                    dtLines.Dispose()
                    dtLines = Nothing
                End If
            End Try
        End Sub

        '****************************************************
        'Load all lines
        '****************************************************
        Private Sub LoadAllLines()
            Dim dtLines As DataTable

            Try
                dtLines = Me.objInventory.GetLines()
                Me.grdLines_TabLine.ClearFields()
                Me.grdLines_TabLine.DataSource = dtLines.DefaultView
                SetLineGridProperties_TabLine()

                Me.grdLine_TabMap.ClearFields()
                Me.grdLine_TabMap.DataSource = dtLines.DefaultView
                SetLineGridProperties_TabMap()

            Catch ex As Exception
                Throw New Exception("LoadAllLines:: " & ex.Message.ToString)
            Finally
                If Not IsNothing(dtLines) Then
                    dtLines.Dispose()
                    dtLines = Nothing
                End If
            End Try
        End Sub

        '****************************************************
        Private Sub LoadCostCenters()
            Dim dt As DataTable
            Try
                SetExisitingCostCentersGridProperties_TabCostCenter()

                dt = Me.objInventory.GetCostCenterGroups(True)
                Misc.PopulateC1DropDownList(Me.cboOpenOrders, dt, "Group Desc", "Group_ID")
                Me.cboOpenOrders.SelectedValue = 0

            Catch ex As Exception
                Throw New Exception("LoadCostCenters:: " & ex.Message.ToString)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '****************************************************
        Private Sub LoadCostCenterMaps()
            Try
                SetCostCentersGridProperties_TabCostCenterMap()

                SetMachinesGridProperties_TabCostCenterMap()

                Me.btnMapMachine_TabCostCenterMap.Enabled = Me.grdCostCenters_TabCostCenterMap.Enabled And Me.grdMachines_TabCostCenterMap.Enabled

                SetMappedMachinesGridProperties_TabCostCenterMap()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error in LoadCostCenterMaps", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End Sub

        '******************************************************************
        Private Sub LoadWorkArea()
            Dim dt As DataTable
            Dim _objCC As IncentivePrg
            Try
                _objCC = New PSS.Data.Buisness.IncentivePrg()

                'Populate Work Areas
                dt = _objCC.GetWorkAreas(True)
                Misc.PopulateC1DropDownList(Me.cboWorkAreas, dt, "wa_desc", "wa_id")
                Me.cboWorkAreas.SelectedValue = 0

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "LoadWorkArea", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
                _objCC = Nothing
            End Try
        End Sub

        '****************************************************
        Protected Overrides Sub Finalize()
            objInventory = Nothing
            MyBase.Finalize()
        End Sub

        '****************************************************
        Private Sub grdGroups_RowColChange(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles grdGroups_TabSummary.RowColChange
            Try
                If Me.GrdGroups_TabGroup.Columns.Count > 0 Then
                    Me.grdLines_TabSummary.Columns.Clear()
                    Me.grdSides_TabSummary.Columns.Clear()
                    Me.grdMachines_TabSummary.Columns.Clear()
                    LoadLinesForGroup(CInt(Me.GrdGroups_TabGroup.Columns("Group_ID").Value))
                End If
            Catch ex As Exception

            End Try

        End Sub
        '****************************************************
        Private Sub Asif()
            With Me.grdGroup_TabMap
                'Dim x As String = "Group: " & .Splits(0).DisplayColumns(1).Width
                MsgBox(.Splits(0).DisplayColumns(1).Width)
            End With
            With Me.grdLine_TabMap
                'Dim x As String = "Group: " & .Splits(0).DisplayColumns(1).Width
                MsgBox(.Splits(0).DisplayColumns(1).Width)
            End With

            'With Me.grdLine_TabMap
            '    Dim x As String = "Line: " & .Splits(0).DisplayColumns(1).Width
            '    MsgBox(x)
            'End With
            'With Me.grdSide_TabMap
            '    Dim x As String = "Side: " & .Splits(0).DisplayColumns(1).Width
            '    MsgBox(x)
            'End With
            'With Me.grdMapSummary_TabMap
            '    Dim x As String = "Mapping: " & .Splits(0).DisplayColumns(1).Width & "***" & .Splits(0).DisplayColumns(2).Width & "***" & .Splits(0).DisplayColumns(3).Width & "***" & .Splits(0).DisplayColumns(4).Width & "***" & .Splits(0).DisplayColumns(5).Width
            '    MsgBox(x)
            'End With

        End Sub
        '****************************************************
        'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        '    'MsgBox(Me.chklstGroup_TabMap.SelectedValue)
        '    Asif()
        'End Sub
        '****************************************************
        Private Sub SetGroupGridProperties_TabSummary()
            Dim iNumOfColumns As Integer = Me.grdGroups_TabSummary.Columns.Count
            Dim i As Integer


            With Me.grdGroups_TabSummary
                'Heading style (Horizontal Alignment to Center)
                For i = 0 To (iNumOfColumns - 1)
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Next

                'Set individual column data horizontal alignment
                .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

                'Set Column Widths
                .Splits(0).DisplayColumns(1).Width = 150
                .Splits(0).DisplayColumns(2).Width = 115

                'Make some columns invisible
                .Splits(0).DisplayColumns(0).Visible = False

            End With
        End Sub
        '****************************************************
        Private Sub SetMachineGridProperties_TabSummary()
            Dim iNumOfColumns As Integer = Me.grdMachines_TabSummary.Columns.Count
            Dim i As Integer


            With Me.grdMachines_TabSummary
                'Heading style (Horizontal Alignment to Center)
                For i = 0 To (iNumOfColumns - 1)
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Next

                'Set individual column data horizontal alignment
                .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                .Splits(0).DisplayColumns(3).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                'Set Column Widths
                .Splits(0).DisplayColumns(1).Width = 125
                .Splits(0).DisplayColumns(2).Width = 115
                .Splits(0).DisplayColumns(3).Width = 80

                'Make some columns invisible
                .Splits(0).DisplayColumns(0).Visible = False

            End With
        End Sub

        Private Sub SetMachineGridProperties_TabMap()
            Dim iNumOfColumns As Integer = Me.grdMachine_TabMap.Columns.Count
            Dim i As Integer


            With Me.grdMachine_TabMap
                'Heading style (Horizontal Alignment to Center)
                For i = 0 To (iNumOfColumns - 1)
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Next

                'Set individual column data horizontal alignment
                .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                .Splits(0).DisplayColumns(3).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                'Set Column Widths
                .Splits(0).DisplayColumns(1).Width = 93
                .Splits(0).DisplayColumns(2).Width = 62
                .Splits(0).DisplayColumns(3).Width = 69

                'Make some columns invisible
                .Splits(0).DisplayColumns(0).Visible = False
                '.Splits(0).DisplayColumns(2).Visible = False
                '.Splits(0).DisplayColumns(3).Visible = False

            End With
        End Sub

        Private Sub SetMachineGridProperties_TabMachine()
            Dim iNumOfColumns As Integer = Me.grdMachines_TabMachine.Columns.Count
            Dim i As Integer


            With Me.grdMachines_TabMachine
                'Heading style (Horizontal Alignment to Center)
                For i = 0 To (iNumOfColumns - 1)
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Next

                'Set individual column data horizontal alignment
                .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                .Splits(0).DisplayColumns(3).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                'Set Column Widths
                .Splits(0).DisplayColumns(1).Width = 125
                .Splits(0).DisplayColumns(2).Width = 115
                .Splits(0).DisplayColumns(3).Width = 100

                'Make some columns invisible
                .Splits(0).DisplayColumns(0).Visible = False

            End With
        End Sub
        '****************************************************
        Private Sub SetGroupGridProperties_TabMap()
            Dim iNumOfColumns As Integer = Me.grdGroup_TabMap.Columns.Count
            Dim i As Integer


            With Me.grdGroup_TabMap
                'Heading style (Horizontal Alignment to Center)
                For i = 0 To (iNumOfColumns - 1)
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Next

                'Set individual column data horizontal alignment
                .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                '.Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

                'Set Column Widths
                .Splits(0).DisplayColumns(1).Width = 150
                '.Splits(0).DisplayColumns(2).Width = 115

                'Make some columns invisible
                .Splits(0).DisplayColumns(0).Visible = False
                .Splits(0).DisplayColumns(2).Visible = False

            End With
        End Sub
        '****************************************************
        Private Sub SetGroupGridProperties_TabGroup()
            Dim iNumOfColumns As Integer = Me.GrdGroups_TabGroup.Columns.Count
            Dim i As Integer


            With Me.GrdGroups_TabGroup
                'Heading style (Horizontal Alignment to Center)
                For i = 0 To (iNumOfColumns - 1)
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Next

                'Set individual column data horizontal alignment
                .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

                'Set Column Widths
                .Splits(0).DisplayColumns(1).Width = 150
                .Splits(0).DisplayColumns(2).Width = 115

                'Make some columns invisible
                .Splits(0).DisplayColumns(0).Visible = False

            End With
        End Sub
        '****************************************************
        Private Sub SetLineGridProperties_TabSummary()
            Dim iNumOfColumns As Integer = Me.grdLines_TabSummary.Columns.Count
            Dim i As Integer


            With Me.grdLines_TabSummary
                'Heading style (Horizontal Alignment to Center)
                For i = 0 To (iNumOfColumns - 1)
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Next

                'Set individual column data horizontal alignment
                .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

                'Set Column Widths
                .Splits(0).DisplayColumns(1).Width = 115

                'Make some columns invisible
                .Splits(0).DisplayColumns(0).Visible = False

            End With
        End Sub
        '****************************************************
        Private Sub SetLineGridProperties_TabMap()
            Dim iNumOfColumns As Integer = Me.grdLine_TabMap.Columns.Count
            Dim i As Integer


            With Me.grdLine_TabMap
                'Heading style (Horizontal Alignment to Center)
                For i = 0 To (iNumOfColumns - 1)
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Next

                'Set individual column data horizontal alignment
                .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

                'Set Column Widths
                .Splits(0).DisplayColumns(1).Width = 115

                'Make some columns invisible
                .Splits(0).DisplayColumns(0).Visible = False

            End With
        End Sub
        '****************************************************
        Private Sub SetLineGridProperties_TabLine()
            Dim iNumOfColumns As Integer = Me.grdLines_TabLine.Columns.Count
            Dim i As Integer


            With Me.grdLines_TabLine
                'Heading style (Horizontal Alignment to Center)
                For i = 0 To (iNumOfColumns - 1)
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Next

                'Set individual column data horizontal alignment
                .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

                'Set Column Widths
                .Splits(0).DisplayColumns(1).Width = 115

                'Make some columns invisible
                .Splits(0).DisplayColumns(0).Visible = False

            End With
        End Sub
        '****************************************************
        Private Sub grdLines_RowColChange(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles grdLines_TabSummary.RowColChange
            Try
                If Me.grdLines_TabSummary.Columns.Count > 0 Then
                    Me.grdSides_TabSummary.Columns.Clear()
                    Me.grdMachines_TabSummary.Columns.Clear()
                    LoadSidesforLine(CInt(Me.grdLines_TabSummary.Columns("Line_ID").Value))
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString, "grdLines_RowColChange", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try

        End Sub
        '****************************************************
        Private Sub SetSideGridProperties_TabSummary()
            Dim iNumOfColumns As Integer = Me.grdSides_TabSummary.Columns.Count
            Dim i As Integer

            With Me.grdSides_TabSummary
                'Heading style (Horizontal Alignment to Center)
                For i = 0 To (iNumOfColumns - 1)
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Next

                'Set individual column data horizontal alignment
                .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

                'Set Column Widths
                .Splits(0).DisplayColumns(1).Width = 100

                'Make some columns invisible
                .Splits(0).DisplayColumns(0).Visible = False

            End With
        End Sub
        '****************************************************
        Private Sub SetSideGridProperties_TabMap()
            Dim iNumOfColumns As Integer = Me.grdSide_TabMap.Columns.Count
            Dim i As Integer

            With Me.grdSide_TabMap
                'Heading style (Horizontal Alignment to Center)
                For i = 0 To (iNumOfColumns - 1)
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Next

                'Set individual column data horizontal alignment
                .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

                'Set Column Widths
                .Splits(0).DisplayColumns(1).Width = 73

                'Make some columns invisible
                .Splits(0).DisplayColumns(0).Visible = False

            End With
        End Sub
        '****************************************************
        Private Sub SetSideGridProperties_TabSide()
            Dim iNumOfColumns As Integer = Me.grdSides_TabSide.Columns.Count
            Dim i As Integer

            With Me.grdSides_TabSide
                'Heading style (Horizontal Alignment to Center)
                For i = 0 To (iNumOfColumns - 1)
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Next

                'Set individual column data horizontal alignment
                .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

                'Set Column Widths
                .Splits(0).DisplayColumns(1).Width = 100

                'Make some columns invisible
                .Splits(0).DisplayColumns(0).Visible = False

            End With
        End Sub
        '****************************************************
        Private Sub SetMapSummaryGridProperties_TabMap()
            Dim iNumOfColumns As Integer = Me.grdMapSummary_TabMap.Columns.Count
            Dim i As Integer

            With Me.grdMapSummary_TabMap
                'Heading style (Horizontal Alignment to Center)
                For i = 0 To (iNumOfColumns - 1)
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Next

                'Set individual column data horizontal alignment
                .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                .Splits(0).DisplayColumns(3).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                .Splits(0).DisplayColumns(4).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                .Splits(0).DisplayColumns(5).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

                'Set Column Widths
                .Splits(0).DisplayColumns(1).Width = 150
                .Splits(0).DisplayColumns(2).Width = 110
                .Splits(0).DisplayColumns(3).Width = 97
                .Splits(0).DisplayColumns(4).Width = 125
                .Splits(0).DisplayColumns(5).Width = 125

                'Make some columns invisible
                .Splits(0).DisplayColumns(0).Visible = False

            End With
        End Sub

        '****************************************************************
        Private Sub SetExisitingCostCentersGridProperties_TabCostCenter()
            Dim iNumOfColumns As Integer
            Dim i As Integer
            Dim dt As DataTable

            Try
                dt = Me.objInventory.GetExistingCostCenters()

                With Me.grdExistingCC_TabCostCenter
                    .ClearFields()
                    .DataSource = dt.DefaultView

                    iNumOfColumns = .Columns.Count

                    'Heading style (Horizontal Alignment to Center)
                    .AllowUpdate = False
                    .AllowFilter = True
                    .FilterBar = True

                    For i = 0 To (iNumOfColumns - 1)
                        .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        '.Splits(0).DisplayColumns(i).Locked = IIf(String.Equals(.Splits(0).DisplayColumns(i).Name, "Name"), False, True)
                    Next

                    .Splits(0).DisplayColumns("Group Desc").Locked = False

                    'Set individual column data horizontal alignment
                    .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

                    'Set Column Widths
                    '.Splits(0).DisplayColumns(1).Width = (.Width - (IIf(.VScrollBar.Visible, .VScrollBar.Width / 2, 0) + 20)) / 2
                    '.Splits(0).DisplayColumns(3).Width = (.Width - (IIf(.VScrollBar.Visible, .VScrollBar.Width / 2, 0) + 20)) / 2
                    .Splits(0).DisplayColumns("Name").Width = 100
                    .Splits(0).DisplayColumns("Group Desc").Width = 200
                    .Splits(0).DisplayColumns("Work Area").Width = 100
                    .Splits(0).DisplayColumns("T1 UPH").Width = 70
                    .Splits(0).DisplayColumns("T2 UPH").Width = 70
                    .Splits(0).DisplayColumns("Lunch Start").Width = 80
                    .Splits(0).DisplayColumns("Lunch End").Width = 80

                    '.Splits(0).DisplayColumns("T1 UPH"). = 100

                    'Make some columns invisible
                    .Splits(0).DisplayColumns("cc_id").Visible = False
                    .Splits(0).DisplayColumns("group_id").Visible = False

                    .SelectedStyle.BackColor = Color.Green
                    .SelectedStyle.ForeColor = Color.Yellow

                    .EditorStyle.BackColor = Color.White
                    .EditorStyle.ForeColor = Color.Black

                    .Splits(0).DisplayColumns("Name").Frozen = True

                    .Enabled = IIf(.RowCount > 0, True, False)
                    Me.lblCCExisiting.Enabled = .Enabled
                    Me.btnDeleteCC_TabCostCenter.Enabled = .Enabled
                End With
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        ''****************************************************************
        'Private Sub SetGroupsGridProperties_TabCostCenter()
        '    Dim iNumOfColumns As Integer
        '    Dim i As Integer
        '    Dim dt As DataTable

        '    Try
        '       dt = Me.objInventory.GetCostCenterGroups

        '        With Me.grdGroups_TabCostCenter
        '            .ClearFields()
        '            .DataSource = dt.DefaultView
        '            iNumOfColumns = Me.grdGroups_TabCostCenter.Columns.Count

        '            'Heading style (Horizontal Alignment to Center)
        '            For i = 0 To (iNumOfColumns - 1)
        '                .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        '            Next

        '            'Set individual column data horizontal alignment
        '            .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

        '            'Set Column Widths
        '            '.Splits(0).DisplayColumns(1).Width = .Width - (IIf(.VScrollBar.Visible, .VScrollBar.Width, 0) + 20)
        '            .Splits(0).DisplayColumns("Group Desc").Width = 200

        '            'Make some columns invisible
        '            .Splits(0).DisplayColumns("Group_ID").Visible = False

        '            .SelectedStyle.BackColor = Color.Green
        '            .SelectedStyle.ForeColor = Color.Yellow

        '            .Enabled = IIf(.RowCount > 0, True, False)

        '            'Me.lblGroup_TabCostCenter.Enabled = .Enabled
        '            'Me.lblName_TabCostCenter.Enabled = .Enabled
        '            'Me.txtName_TabCostCenter.Enabled = .Enabled
        '            Me.txtName_TabCostCenter.Text = ""
        '        End With
        '    Catch ex As Exception
        '        Throw ex
        '    Finally
        '        PSS.Data.Buisness.Generic.DisposeDT(dt)
        '    End Try
        'End Sub

        '****************************************************************
        Private Sub SetCostCentersGridProperties_TabCostCenterMap()
            Dim iNumOfColumns As Integer
            Dim i As Integer
            Dim dt As DataTable

            Try
                dt = Me.objInventory.GetExistingCostCenters()
                With Me.grdCostCenters_TabCostCenterMap
                    .ClearFields()
                    .DataSource = dt.DefaultView
                    iNumOfColumns = .Columns.Count

                    'Heading style (Horizontal Alignment to Center)
                    For i = 0 To (iNumOfColumns - 1)
                        .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    Next

                    'Set individual column data horizontal alignment
                    .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

                    'Set Column Widths
                    '.Splits(0).DisplayColumns(1).Width = (.Width - (IIf(.VScrollBar.Visible, .VScrollBar.Width, 0) + 20)) / 2
                    '.Splits(0).DisplayColumns(3).Width = (.Width - (IIf(.VScrollBar.Visible, .VScrollBar.Width, 0) + 20)) / 2
                    .Splits(0).DisplayColumns("Name").Width = 60
                    .Splits(0).DisplayColumns("Group Desc").Width = 200
                    .Splits(0).DisplayColumns("T1 UPH").Width = 70
                    .Splits(0).DisplayColumns("T2 UPH").Width = 70

                    'Make some columns invisible
                    .Splits(0).DisplayColumns("cc_id").Visible = False
                    .Splits(0).DisplayColumns("group_id").Visible = False

                    .SelectedStyle.BackColor = Color.Green
                    .SelectedStyle.ForeColor = Color.Yellow

                    .Splits(0).DisplayColumns("Name").Frozen = True

                    .Enabled = IIf(.RowCount > 0, True, False)
                    Me.lblCostCenters_TabCostCenterMap.Enabled = .Enabled
                End With
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '****************************************************************
        Private Sub SetMachinesGridProperties_TabCostCenterMap()
            Dim dt As DataTable
            Dim iNumOfColumns As Integer
            Dim i As Integer

            Try
                dt = Me.objInventory.GetActiveMachines

                With Me.grdMachines_TabCostCenterMap
                    Me.grdMachines_TabCostCenterMap.ClearFields()
                    Me.grdMachines_TabCostCenterMap.DataSource = dt.DefaultView
                    iNumOfColumns = .Columns.Count

                    'Heading style (Horizontal Alignment to Center)
                    For i = 0 To (iNumOfColumns - 1)
                        .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    Next

                    'Set individual column data horizontal alignment
                    .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

                    'Set Column Widths
                    '.Splits(0).DisplayColumns(1).Width = .Width - (IIf(.VScrollBar.Visible, .VScrollBar.Width, 0) + 25)
                    .Splits(0).DisplayColumns("Name").Width = 140

                    'Make some columns invisible
                    .Splits(0).DisplayColumns("Location ID").Visible = False

                    .SelectedStyle.BackColor = Color.Green
                    .SelectedStyle.ForeColor = Color.Yellow

                    .Enabled = IIf(.RowCount > 0, True, False)
                    Me.lblMachines_TabCostCenterMap.Enabled = .Enabled
                End With
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '****************************************************************
        Private Sub SetMappedMachinesGridProperties_TabCostCenterMap()
            Dim dt As DataTable
            Dim iNumOfColumns As Integer
            Dim i As Integer

            Try
                dt = Me.objInventory.GetMappedMachines()
                With Me.grdMappedMachines_TabCostCenterMap
                    .ClearFields()
                    .DataSource = dt.DefaultView
                    iNumOfColumns = .Columns.Count

                    'Heading style (Horizontal Alignment to Center)
                    For i = 0 To (iNumOfColumns - 1)
                        .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    Next

                    'Set individual column data horizontal alignment
                    .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                    .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                    .Splits(0).DisplayColumns(3).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

                    'Set Column Widths
                    '.Splits(0).DisplayColumns(1).Width = (.Width - (IIf(.VScrollBar.Visible, .VScrollBar.Width, 0) + 23)) / 3
                    '.Splits(0).DisplayColumns(2).Width = (.Width - (IIf(.VScrollBar.Visible, .VScrollBar.Width, 0) + 23)) / 3
                    '.Splits(0).DisplayColumns(3).Width = (.Width - (IIf(.VScrollBar.Visible, .VScrollBar.Width, 0) + 23)) / 3
                    .Splits(0).DisplayColumns("Group").Width = 200
                    .Splits(0).DisplayColumns("Cost Center").Width = 80
                    .Splits(0).DisplayColumns("Desk").Width = 50
                    .Splits(0).DisplayColumns("Machine Name").Width = 105

                    'Make some columns invisible
                    .Splits(0).DisplayColumns("ccmap_id").Visible = False

                    .SelectedStyle.BackColor = Color.Green
                    .SelectedStyle.ForeColor = Color.Yellow

                    .Splits(0).DisplayColumns(2).Frozen = True

                    .Enabled = IIf(Me.grdMappedMachines_TabCostCenterMap.RowCount > 0, True, False)
                    Me.btnDeleteMappings_TabCostCenterMap.Enabled = .Enabled
                End With
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '****************************************************************
        Private Sub LoadSidesforLine(ByVal iLineID As Integer)
            Dim dtSides As DataTable
            Try
                dtSides = Me.objInventory.GetLineSides(iLineID)
                Me.grdSides_TabSummary.ClearFields()
                Me.grdSides_TabSummary.DataSource = dtSides.DefaultView
                SetSideGridProperties_TabSummary()

            Catch ex As Exception
                Throw New Exception("LoadSidesforLine:: " & ex.Message.ToString)
            Finally
                If Not IsNothing(dtSides) Then
                    dtSides.Dispose()
                    dtSides = Nothing
                End If
            End Try
        End Sub

        '****************************************************
        Private Sub LoadAllSides()
            Dim dtSides As DataTable
            Try
                dtSides = Me.objInventory.GetLineSides()
                Me.grdSides_TabSide.ClearFields()
                Me.grdSides_TabSide.DataSource = dtSides.DefaultView
                SetSideGridProperties_TabSide()

                Me.grdSide_TabMap.ClearFields()
                Me.grdSide_TabMap.DataSource = dtSides.DefaultView
                SetSideGridProperties_TabMap()

            Catch ex As Exception
                Throw New Exception("LoadAllSides:: " & ex.Message.ToString)
            Finally
                If Not IsNothing(dtSides) Then
                    dtSides.Dispose()
                    dtSides = Nothing
                End If
            End Try
        End Sub

        '****************************************************
        Private Sub LoadAllMappings()
            Dim dtMap As New DataTable()

            Try
                dtMap = Me.objInventory.GetMappings
                Me.grdMapSummary_TabMap.ClearFields()
                Me.grdMapSummary_TabMap.DataSource = dtMap.DefaultView
                SetMapSummaryGridProperties_TabMap()

            Catch ex As Exception
                Throw New Exception("LoadAllMappings:: " & ex.Message.ToString)
            Finally
                If Not IsNothing(dtMap) Then
                    dtMap.Dispose()
                    dtMap = Nothing
                End If
            End Try
        End Sub

        '****************************************************
        Private Sub LoadAllMachines()
            Dim dtMachines As DataTable

            Try
                dtMachines = Me.objInventory.GetMachines()
                Me.grdMachines_TabMachine.ClearFields()
                Me.grdMachines_TabMachine.DataSource = dtMachines.DefaultView
                SetMachineGridProperties_TabMachine()

                If Not IsNothing(dtMachines) Then
                    dtMachines.Dispose()
                    dtMachines = Nothing
                End If

                dtMachines = Me.objInventory.GetMachines(, , , , , 1)
                Me.grdMachine_TabMap.ClearFields()
                Me.grdMachine_TabMap.DataSource = dtMachines.DefaultView
                SetMachineGridProperties_TabMap()

            Catch ex As Exception
                Throw New Exception("LoadAllMachines:: " & ex.Message.ToString)
            Finally
                If Not IsNothing(dtMachines) Then
                    dtMachines.Dispose()
                    dtMachines = Nothing
                End If
            End Try
        End Sub

        '****************************************************
        Private Sub LoadMachinesForSide(ByVal iLineID As Integer, ByVal iSideID As Integer)
            Dim dtMachines As DataTable
            Try
                dtMachines = Me.objInventory.GetMachines(, iLineID, iSideID)
                Me.grdMachines_TabSummary.ClearFields()
                Me.grdMachines_TabSummary.DataSource = dtMachines.DefaultView
                SetMachineGridProperties_TabSummary()

            Catch ex As Exception
                Throw New Exception("LoadMachinesForSide:: " & ex.Message.ToString)
            Finally
                If Not IsNothing(dtMachines) Then
                    dtMachines.Dispose()
                    dtMachines = Nothing
                End If
            End Try
        End Sub

        '****************************************************
        Private Sub grdSides_RowColChange(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles grdSides_TabSummary.RowColChange
            Try
                If Me.grdSides_TabSummary.Columns.Count > 0 And Me.grdLines_TabSummary.Columns.Count > 0 Then
                    Me.grdMachines_TabSummary.Columns.Clear()
                    LoadMachinesForSide(CInt(Me.grdLines_TabSummary.Columns("Line_ID").Value), CInt(Me.grdSides_TabSummary.Columns("LineSide_ID").Value))
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString, "grdSides_RowColChange", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try

        End Sub

        '****************************************************
        Private Sub cmdAddGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddGroup.Click
            Dim i As Integer = 0
            Try
                If Me.txtGroup.Text.Trim = "" Then
                    Exit Sub
                End If

                i = Me.objInventory.SaveGroup(Trim(Me.txtGroup.Text), , )
                If i > 0 Then
                    MessageBox.Show("Group is saved successfully.", "Save Group", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtGroup.Text = ""
                End If
                'LoadGroups()
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString, "Save Group", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                LoadGroups()
            End Try
        End Sub

        Private Sub cmdUpdateGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateGroup.Click
            Dim i As Integer = 0
            Dim strGrp As String = ""
            Dim iGroup_ID As Integer = 0
            Dim strManager As String = ""

            Try
                If Len(Trim(Me.GrdGroups_TabGroup.Columns("Group").Value)) = 0 Then
                    Throw New Exception("Input a 'Group'.")
                Else
                    strGrp = Trim(Me.GrdGroups_TabGroup.Columns("Group").Value)
                End If

                If Len(Trim(Me.GrdGroups_TabGroup.Columns("Group_ID").Value)) = 0 Then
                    Throw New Exception("Select a 'Group'.")
                Else
                    iGroup_ID = CInt(Trim(Me.GrdGroups_TabGroup.Columns("Group_ID").Value))
                End If

                If Len(Trim(Me.GrdGroups_TabGroup.Columns("Manager").Value)) = 0 Then
                    Throw New Exception("Input a 'Manager'.")
                Else
                    strManager = Trim(Me.GrdGroups_TabGroup.Columns("Manager").Value)
                End If

                'i = Me.objInventory.SaveGroup(Trim(Me.GrdGroups_TabGroup.Columns("Group_Desc").Value), CInt(Me.GrdGroups_TabGroup.Columns("Group_ID").Value), Trim(Me.GrdGroups_TabGroup.Columns("Group_Manager").Value))
                i = Me.objInventory.SaveGroup(strGrp, iGroup_ID, strManager)
                If i > 0 Then
                    MessageBox.Show("Group is saved successfully.", "Save Group", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
                'LoadGroups()
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString, "Save Group", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                LoadGroups()
            End Try
        End Sub

        Private Sub cmdAddLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddLine.Click
            Dim i As Integer = 0
            Try
                If Me.txtLine.Text.Trim = "" Then
                    Exit Sub
                End If

                i = Me.objInventory.SaveLine(Trim(Me.txtLine.Text), )
                If i > 0 Then
                    MessageBox.Show("Line is saved successfully.", "Save Line", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtLine.Text = ""
                End If
                'Me.LoadAllLines()
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString, "Save Line", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                Me.LoadAllLines()
            End Try
        End Sub

        Private Sub cmdUpdateLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateLine.Click
            Dim i As Integer = 0
            Try
                i = Me.objInventory.SaveLine(Trim(Me.grdLines_TabLine.Columns("Line").Value), CInt(Me.grdLines_TabLine.Columns("Line_ID").Value))
                If i > 0 Then
                    MessageBox.Show("Line is saved successfully.", "Save Line", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
                'Me.LoadAllLines()
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString, "Save Line", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                Me.LoadAllLines()
            End Try
        End Sub

        Private Sub cmdUpdateSide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateSide.Click
            Dim i As Integer = 0
            Try
                i = Me.objInventory.SaveLineSide(Trim(Me.grdSides_TabSide.Columns("Line Side").Value), CInt(Me.grdSides_TabSide.Columns("LineSide_ID").Value))
                If i > 0 Then
                    MessageBox.Show("'Line Side' is saved successfully.", "Save Line Side", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
                'Me.LoadAllSides()
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString, "Save Line Side", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                Me.LoadAllSides()
            End Try
        End Sub

        Private Sub cmdAddSide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddSide.Click
            'SaveLineSide
            Dim i As Integer = 0
            Try
                If Me.txtSide.Text.Trim = "" Then
                    Exit Sub
                End If

                i = Me.objInventory.SaveLineSide(Trim(Me.txtSide.Text), )
                If i > 0 Then
                    MessageBox.Show("'Line Side' is saved successfully.", "Save Line Side", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtSide.Text = ""
                End If
                'Me.LoadAllSides()
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString, "Save Line Side", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                Me.LoadAllSides()
            End Try
        End Sub

        Private Sub cmdAddMachine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddMachine.Click
            Dim i As Integer = 0
            Try
                If Me.txtMachine.Text.Trim = "" Then
                    Exit Sub
                End If

                i = Me.objInventory.SaveMachine(Trim(Me.txtMachine.Text), , , )
                If i > 0 Then
                    MessageBox.Show("Machine is saved successfully.", "Save Machine", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtMachine.Text = ""
                End If
                'Me.LoadAllMachines()
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString, "Save Machine", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                Me.LoadAllMachines()
                Me.LoadCostCenterMaps()
            End Try
        End Sub

        Private Sub cmdUpdateMachine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateMachine.Click
            Dim i As Integer = 0
            Dim strBin As String = ""
            Dim iTrackParts As Integer = 0

            Try
                If Len(Trim(Me.grdMachines_TabMachine.Columns("Machine").Value)) = 0 Then
                    Throw New Exception("Please enter a 'Machine' Name.")
                End If

                If Len(Trim(Me.grdMachines_TabMachine.Columns("Bin").Value)) = 0 Then
                    strBin = ""
                Else
                    strBin = Trim(Me.grdMachines_TabMachine.Columns("Bin").Value)
                End If

                If Not IsDBNull(Me.grdMachines_TabMachine.Columns("Track Parts").Value) Then
                    If Len(Trim(Me.grdMachines_TabMachine.Columns("Track Parts").Value)) > 0 Then
                        iTrackParts = CInt(Me.grdMachines_TabMachine.Columns("Track Parts").Value)
                        If iTrackParts <> 1 And iTrackParts <> 0 Then
                            Throw New Exception("To turn on ""Track Parts"" for any machine enter 1 and to turn it off enter nothing or 0.")
                        End If
                    End If
                End If

                'Track Parts
                i = Me.objInventory.SaveMachine(Trim(Me.grdMachines_TabMachine.Columns("Machine").Value), CInt(Me.grdMachines_TabMachine.Columns("WCLocation_ID").Value), strBin, iTrackParts)
                If i > 0 Then
                    MessageBox.Show("Machine is saved successfully.", "Save Machine", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString, "Save Machine", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                Me.LoadAllMachines()
            End Try
        End Sub

        Private Sub cmdAddMap_TabMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddMap_TabMap.Click
            Dim i As Integer = 0

            If Len(Trim(Me.grdGroup_TabMap.Columns("Group").Value)) = 0 Then
                Throw New Exception("Please select a 'Group'.")
            End If
            If Len(Trim(Me.grdLine_TabMap.Columns("Line").Value)) = 0 Then
                Throw New Exception("Please select a 'Line'.")
            End If
            If Len(Trim(Me.grdSide_TabMap.Columns("Line Side").Value)) = 0 Then
                Throw New Exception("Please select a 'Line Side'.")
            End If
            If Len(Trim(Me.grdMachine_TabMap.Columns("Machine").Value)) = 0 Then
                Throw New Exception("Please select a 'Machine'.")
            End If

            Try
                i = Me.objInventory.CreateMapping(CInt(Me.grdGroup_TabMap.Columns("Group_ID").Value), _
                                                CInt(Me.grdLine_TabMap.Columns("Line_ID").Value), _
                                                CInt(Me.grdSide_TabMap.Columns("LineSide_ID").Value), _
                                                CInt(Me.grdMachine_TabMap.Columns("wclocation_id").Value))

                If i > 0 Then
                    MessageBox.Show("Mapping is created successfully.", "Create Mapping", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtMachine.Text = ""
                End If
                'Me.LoadAllMappings()
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString, "Create Mapping", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                Try
                    Me.LoadAllMachines()
                    Me.LoadAllMappings()
                Catch ex1 As Exception
                    MessageBox.Show(ex1.Message.ToString)
                End Try

            End Try
        End Sub

        Private Sub cmdDeleteMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteMap.Click
            Dim i As Integer = 0
            Try
                If MessageBox.Show("Are you sure you want to delete this 'Mapping'?", "Delete Mapping", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    If Len(Trim(Me.grdMapSummary_TabMap.Columns("WCLocation_ID").Value)) = 0 Then
                        Throw New Exception("Please select a 'Mapping' to delete.")
                    End If

                    i = Me.objInventory.DeleteMapping(CInt(Trim(Me.grdMapSummary_TabMap.Columns("WCLocation_ID").Value)))
                    'If i > 0 Then
                    '    MessageBox.Show("Mapping deleted.", "Delete Mapping", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    '    'Me.txtGroup.Text = ""
                    'End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString, "Delete Mapping", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                Me.LoadAllMachines()
                Me.LoadAllMappings()
            End Try
        End Sub

        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
            Me.Asif()
        End Sub

        Private Sub btnAddCC_TabCostCenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddCC_TabCostCenter.Click
            Dim i As Integer = 0
            Try
                If Me.cboOpenOrders.SelectedValue = 0 Then
                    MessageBox.Show("You must select a group.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'ElseIf Me.grdGroups_TabCostCenter.SelectedRows.Count > 1 Then
                    'MessageBox.Show("You can select only one group.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf Me.txtName_TabCostCenter.Text.Trim.Length = 0 Then
                    MessageBox.Show("You must enter a cost center name.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf Me.objInventory.CheckCostCenter(Me.cboOpenOrders.SelectedValue, Me.txtName_TabCostCenter.Text.Trim) Then
                    MessageBox.Show("A cost center with this name already exists for the selected group.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf Me.cboWorkAreas.SelectedValue = 0 Then
                    MessageBox.Show("You must select a work area.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Else
                    If MessageBox.Show("Are you sure you want to add?", "Close Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
                    If Me.CheckBox1.Checked Then
                        i = 1
                    End If
                    If Me.objInventory.AddCostCenter(Me.cboOpenOrders.SelectedValue, Me.txtName_TabCostCenter.Text.Trim, Me.cboWorkAreas.SelectedValue, Me.NumericUpDown1.Text, Me.NumericUpDown2.Text, i) Then
                        Me.LoadCostCenters()
                        Me.LoadCostCenterMaps()
                        Me.txtName_TabCostCenter.Text = ""
                    End If
                    End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error in btnAddCC_TabCostCenter_Click", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End Sub

        Private Sub btnMapMachine_TabCostCenterMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMapMachine_TabCostCenterMap.Click
            Try
                If Me.grdCostCenters_TabCostCenterMap.SelectedRows.Count = 0 Then
                    MessageBox.Show("You must select a cost center.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf Me.grdCostCenters_TabCostCenterMap.SelectedRows.Count > 1 Then
                    MessageBox.Show("You can select only one cost center.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf Me.numTable_TabCostCenterMap.Value < Me.numTable_TabCostCenterMap.Minimum Or Me.numTable_TabCostCenterMap.Value > Me.numTable_TabCostCenterMap.Maximum Then
                    MessageBox.Show("The table number must be in the range " & Me.numTable_TabCostCenterMap.Minimum.ToString & " to " & Me.numTable_TabCostCenterMap.Maximum.ToString & ".", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf Me.grdMachines_TabCostCenterMap.SelectedRows.Count = 0 Then
                    MessageBox.Show("You must select a machine.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf Me.grdMachines_TabCostCenterMap.SelectedRows.Count > 1 Then
                    MessageBox.Show("You can select only one machine.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf Me.objInventory.CheckCostCenterMachineMapping(Me.grdCostCenters_TabCostCenterMap(Me.grdCostCenters_TabCostCenterMap.Row, 0), Me.grdMachines_TabCostCenterMap(Me.grdMachines_TabCostCenterMap.Row, 0)) Then
                    MessageBox.Show("This mapping already exists.", "Mapping Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    If Me.objInventory.AddMachineMapping(Me.grdCostCenters_TabCostCenterMap(Me.grdCostCenters_TabCostCenterMap.Row, 0), Me.numTable_TabCostCenterMap.Value, Me.grdMachines_TabCostCenterMap(Me.grdMachines_TabCostCenterMap.Row, 0)) Then
                        Me.LoadCostCenterMaps()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error in btnMapMachine_TabCostCenterMap_Click", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End Sub

        Private Sub btnDeleteMappings_TabCostCenterMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteMappings_TabCostCenterMap.Click
            Dim objSRC As C1.Win.C1TrueDBGrid.SelectedRowCollection
            Dim i, iCCMapID As Integer

            Try
                If Me.grdMappedMachines_TabCostCenterMap.SelectedRows.Count = 0 Then
                    MessageBox.Show("You must select at least one mapping to delete.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    If MessageBox.Show("Are you sure want to delete " & IIf(Me.grdMappedMachines_TabCostCenterMap.SelectedRows.Count > 1, "these mappings", "this mapping") & "?", "Delete Cost Center Mappings", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                        objSRC = Me.grdMappedMachines_TabCostCenterMap.SelectedRows

                        For i = 0 To objSRC.Count - 1
                            iCCMapID = Me.grdMappedMachines_TabCostCenterMap(objSRC.Item(i), "ccmap_id")

                            Me.objInventory.DeleteCostCenterMapping(iCCMapID)
                        Next i

                        LoadCostCenterMaps()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error in btnDeleteMappings_TabCostCenterMap_Click", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End Sub

        'Private Sub grdGoals_TabCostCenterGoals_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grdExistingCC_TabCostCenter.KeyPress
        '    Try
        '        If sender.Row > -1 Then
        '            If sender.Col = 1 Then
        '                If Not (Char.IsLetter(e.KeyChar) Or Char.IsControl(e.KeyChar)) Then
        '                    e.Handled = True ' Allow only numbers and a period 
        '                End If
        '            ElseIf sender.Col = 4 Then
        '                If Not (Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Or Char.IsPunctuation(e.KeyChar)) Then
        '                    e.Handled = True ' Allow only numbers and a period 
        '                End If
        '            Else
        '                e.Handled = True ' No editing 
        '            End If
        '        End If
        '    Catch ex As Exception
        '        MessageBox.Show(ex.Message, "Error in grdGoals_TabCostCenterGoals_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    End Try
        'End Sub

        'Private Sub grdExistingCC_TabCostCenter_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles grdExistingCC_TabCostCenter.BeforeColUpdate
        '    If sender.Columns(sender.Col).Text.Trim = "" Then
        '        MessageBox.Show("Update value can't be blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        e.Cancel = False
        '        Me.grdExistingCC_TabCostCenter.Columns(e.ColIndex).Value = e.OldValue
        '    End If
        'End Sub

        'Private Sub grdExistingCC_TabCostCenter_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles grdExistingCC_TabCostCenter.AfterColUpdate
        '    Try
        '        If sender.Row > -1 Then
        '            If sender.Col = 1 Then
        '                Me.objInventory.UpdateCostCenterName(CInt(sender.Columns("cc_id").Text), sender.Columns(sender.Col).Text.Trim)
        '            ElseIf sender.Col = 4 Then
        '                Me.objInventory.UpdateUPHGoal(CInt(sender.Columns("cc_id").Text), sender.Columns(sender.Col).Text.Trim)
        '            End If
        '        End If
        '    Catch ex As Exception
        '        MessageBox.Show(ex.Message, "Error in grdExistingCC_TabCostCenter_AfterColUpdate", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    End Try
        'End Sub

        Private Sub txtGoal_TabCostCenter_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
            If Not (Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Or Char.IsPunctuation(e.KeyChar)) Then
                e.Handled = True ' Allow only numbers and a period 
            End If
        End Sub

        '****************************************************************
        Private Sub txtT1UPH_T2UPH_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtT1UPH.KeyPress
            Try
                If Not (e.KeyChar.IsDigit(e.KeyChar) Or e.KeyChar = "." Or Char.IsControl(e.KeyChar)) Then e.Handled = True
            Catch ex As Exception
                MessageBox.Show(ex.Message, "txtT1UPH_T2UPH_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End Sub

        '****************************************************************
        Private Sub btnUpdateUPH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdateUPH.Click
            Dim iCCID As Integer = 0
            Dim decOldT1UPH, decOldT2UPH, decNewT1UPH, decNewT2UPH As Decimal

            Try
                If Me.grdExistingCC_TabCostCenter.SelectedRows.Count = 0 Then
                    MessageBox.Show("Please select record to update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.grdExistingCC_TabCostCenter.Focus()
                ElseIf Me.txtT1UPH.Text.Trim.Length = 0 OrElse CInt(Me.txtT1UPH.Text) <= 0 Then
                    MessageBox.Show("Please enter Tier 1 UPH.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtT1UPH.Focus()
                ElseIf Me.txtT2UPH.Text.Trim.Length = 0 OrElse CInt(Me.txtT2UPH.Text) <= 0 Then
                    MessageBox.Show("Please enter Tier 2 UPH.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtT2UPH.Focus()
                Else
                    If MessageBox.Show("Are you sure you want to update UPH of line " & Me.grdExistingCC_TabCostCenter.Columns("Name").Value.ToString() & "?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) Then

                        decOldT1UPH = 0.0 : decOldT2UPH = 0.0 : decNewT1UPH = 0.0 : decNewT2UPH = 0.0
                        iCCID = CInt(Me.grdExistingCC_TabCostCenter.Columns("CC_ID").Value)
                        decOldT1UPH = Me.grdExistingCC_TabCostCenter.Columns("T1 UPH").Value
                        decOldT2UPH = Me.grdExistingCC_TabCostCenter.Columns("T2 UPH").Value
                        decNewT1UPH = CDec(Me.txtT1UPH.Text)
                        decNewT2UPH = CDec(Me.txtT2UPH.Text)
                        Me.objInventory.UpdateCostCenterUPH(iCCID, decOldT1UPH, decOldT2UPH, decNewT1UPH, decNewT2UPH, PSS.Core.ApplicationUser.IDuser, PSS.Core.ApplicationUser.User)

                        '********************************
                        'Refresh cost centermapping data
                        '********************************
                        SetCostCentersGridProperties_TabCostCenterMap()

                        '********************************
                        'Refresh cost centermapping data
                        '********************************
                        SetExisitingCostCentersGridProperties_TabCostCenter()
                        '********************************
                        Me.txtT1UPH.Text = ""
                        Me.txtT2UPH.Text = ""
                        MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnUpdateUPH_Click", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End Sub

        '****************************************************************

    End Class
End Namespace