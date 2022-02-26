Option Explicit On 

Imports C1.Win.C1TrueDBGrid
Imports PSS.Data.Buisness

Public Class frmHTCSearch
    Inherits System.Windows.Forms.Form

    Private _objHTC As HTC
    Private _dsSearchData As DataSet

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _objHTC = New HTC()
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
    Friend WithEvents lblCriteria As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSearchCriteria As System.Windows.Forms.TextBox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents dbgridPartsServices As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents dbgridTraveler As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents dbgridSearchData As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents cboSearchBy As System.Windows.Forms.ComboBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnCopyAll As System.Windows.Forms.Button
    Friend WithEvents chkMain As System.Windows.Forms.CheckBox
    Friend WithEvents chkRepair As System.Windows.Forms.CheckBox
    Friend WithEvents btnCopyData As System.Windows.Forms.Button
    Friend WithEvents chkTraveler As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmHTCSearch))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblCriteria = New System.Windows.Forms.Label()
        Me.cboSearchBy = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSearchCriteria = New System.Windows.Forms.TextBox()
        Me.dbgridPartsServices = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.dbgridTraveler = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.dbgridSearchData = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnCopyData = New System.Windows.Forms.Button()
        Me.btnCopyAll = New System.Windows.Forms.Button()
        Me.chkTraveler = New System.Windows.Forms.CheckBox()
        Me.chkRepair = New System.Windows.Forms.CheckBox()
        Me.chkMain = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.dbgridPartsServices, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dbgridTraveler, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dbgridSearchData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.Black
        Me.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle.Location = New System.Drawing.Point(1, 1)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(191, 55)
        Me.lblTitle.TabIndex = 101
        Me.lblTitle.Text = "HTC SEARCH ENGINE"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCriteria
        '
        Me.lblCriteria.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCriteria.ForeColor = System.Drawing.Color.White
        Me.lblCriteria.Location = New System.Drawing.Point(200, 32)
        Me.lblCriteria.Name = "lblCriteria"
        Me.lblCriteria.Size = New System.Drawing.Size(112, 16)
        Me.lblCriteria.TabIndex = 105
        Me.lblCriteria.Text = "Search Criteria:"
        Me.lblCriteria.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboSearchBy
        '
        Me.cboSearchBy.Items.AddRange(New Object() {"Serial Number", "Work Order"})
        Me.cboSearchBy.Location = New System.Drawing.Point(320, 6)
        Me.cboSearchBy.Name = "cboSearchBy"
        Me.cboSearchBy.Size = New System.Drawing.Size(300, 21)
        Me.cboSearchBy.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(224, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 104
        Me.Label1.Text = "Search by:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSearchCriteria
        '
        Me.txtSearchCriteria.Location = New System.Drawing.Point(320, 32)
        Me.txtSearchCriteria.Name = "txtSearchCriteria"
        Me.txtSearchCriteria.Size = New System.Drawing.Size(232, 20)
        Me.txtSearchCriteria.TabIndex = 2
        Me.txtSearchCriteria.Text = ""
        '
        'dbgridPartsServices
        '
        Me.dbgridPartsServices.AllowColMove = False
        Me.dbgridPartsServices.AllowFilter = False
        Me.dbgridPartsServices.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.dbgridPartsServices.AllowSort = False
        Me.dbgridPartsServices.AllowUpdate = False
        Me.dbgridPartsServices.AllowUpdateOnBlur = False
        Me.dbgridPartsServices.AlternatingRows = True
        Me.dbgridPartsServices.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.dbgridPartsServices.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dbgridPartsServices.Caption = "Repair Data"
        Me.dbgridPartsServices.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dbgridPartsServices.GroupByCaption = "Drag a column header here to group by that column"
        Me.dbgridPartsServices.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.dbgridPartsServices.Location = New System.Drawing.Point(1, 217)
        Me.dbgridPartsServices.Name = "dbgridPartsServices"
        Me.dbgridPartsServices.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgridPartsServices.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgridPartsServices.PreviewInfo.ZoomFactor = 75
        Me.dbgridPartsServices.RowHeight = 20
        Me.dbgridPartsServices.Size = New System.Drawing.Size(880, 207)
        Me.dbgridPartsServices.TabIndex = 3
        Me.dbgridPartsServices.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Font:Arial, 6.75pt, style" & _
        "=Bold;ForeColor:White;BackColor:SteelBlue;}Selected{ForeColor:Black;BackColor:Ye" & _
        "llow;}Style3{}Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}" & _
        "FilterBar{Font:Arial, 8.25pt, style=Bold;BackColor:White;}Footer{}Caption{AlignH" & _
        "orz:Center;}Style1{}Normal{Font:Arial, 9pt, style=Bold;AlignVert:Center;BackColo" & _
        "r:SteelBlue;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style14{}" & _
        "OddRow{Font:Arial, 6.75pt, style=Bold;ForeColor:White;BackColor:SlateGray;}Recor" & _
        "dSelector{AlignImage:Center;}Style15{}Heading{AlignVert:Center;Wrap:True;Font:Mi" & _
        "crosoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;Border:Raised,,1, 1, 1, " & _
        "1;ForeColor:Orange;BackColor:ActiveCaption;}Style8{}Style10{AlignHorz:Near;}Styl" & _
        "e11{}Style12{}Style13{}Style16{}Style17{}Style9{}</Data></Styles><Splits><C1.Win" & _
        ".C1TrueDBGrid.MergeView AllowColMove=""False"" Name="""" AllowRowSizing=""None"" Alter" & _
        "natingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHe" & _
        "ight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidt" & _
        "h=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>186</Height><Ca" & _
        "ptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style" & _
        "5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""Filter" & _
        "Bar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle paren" & _
        "t=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLight" & _
        "RowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me" & _
        "=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle pare" & _
        "nt=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" " & _
        "/><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 17, 876, 186</ClientRect><" & _
        "BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid." & _
        "MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""No" & _
        "rmal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Headin" & _
        "g"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal""" & _
        " me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=" & _
        """HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me" & _
        "=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal""" & _
        " me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits" & _
        ">1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidt" & _
        "h>16</DefaultRecSelWidth><ClientArea>0, 0, 876, 203</ClientArea><PrintPageHeader" & _
        "Style parent="""" me=""Style16"" /><PrintPageFooterStyle parent="""" me=""Style17"" /></" & _
        "Blob>"
        '
        'dbgridTraveler
        '
        Me.dbgridTraveler.AllowColMove = False
        Me.dbgridTraveler.AllowColSelect = False
        Me.dbgridTraveler.AllowFilter = False
        Me.dbgridTraveler.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.dbgridTraveler.AllowSort = False
        Me.dbgridTraveler.AllowUpdate = False
        Me.dbgridTraveler.AllowUpdateOnBlur = False
        Me.dbgridTraveler.AlternatingRows = True
        Me.dbgridTraveler.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left)
        Me.dbgridTraveler.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dbgridTraveler.Caption = "Travel Data"
        Me.dbgridTraveler.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dbgridTraveler.GroupByCaption = "Drag a column header here to group by that column"
        Me.dbgridTraveler.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
        Me.dbgridTraveler.Location = New System.Drawing.Point(1, 426)
        Me.dbgridTraveler.Name = "dbgridTraveler"
        Me.dbgridTraveler.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgridTraveler.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgridTraveler.PreviewInfo.ZoomFactor = 75
        Me.dbgridTraveler.RowHeight = 20
        Me.dbgridTraveler.Size = New System.Drawing.Size(643, 88)
        Me.dbgridTraveler.TabIndex = 4
        Me.dbgridTraveler.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Font:Arial, 6.75pt, style" & _
        "=Bold;ForeColor:White;BackColor:SteelBlue;}Selected{ForeColor:Black;BackColor:Ye" & _
        "llow;}Style3{}Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}" & _
        "FilterBar{Font:Arial, 8.25pt, style=Bold;BackColor:White;}Footer{}Caption{AlignH" & _
        "orz:Center;}Style9{}Normal{Font:Arial, 9pt, style=Bold;BackColor:SteelBlue;Align" & _
        "Vert:Center;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}" & _
        "OddRow{Font:Arial, 6.75pt, style=Bold;ForeColor:White;BackColor:DarkSeaGreen;}Re" & _
        "cordSelector{AlignImage:Center;}Style13{}Heading{AlignVert:Center;Wrap:True;Font" & _
        ":Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;Border:Raised,,1, 1, " & _
        "1, 1;ForeColor:Blue;BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style11{}" & _
        "Style14{}Style15{}Style16{}Style17{}Style1{}</Data></Styles><Splits><C1.Win.C1Tr" & _
        "ueDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" Name="""" AllowRowS" & _
        "izing=""None"" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""" & _
        "17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=" & _
        """16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Heig" & _
        "ht>67</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""" & _
        "Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarSty" & _
        "le parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" />" & _
        "<GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Sty" & _
        "le2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle par" & _
        "ent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordS" & _
        "electorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selec" & _
        "ted"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 17, 639, " & _
        "67</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.W" & _
        "in.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><" & _
        "Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Styl" & _
        "e parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style" & _
        " parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style par" & _
        "ent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style pa" & _
        "rent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style" & _
        " parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedSt" & _
        "yles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><D" & _
        "efaultRecSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 639, 84</ClientArea><" & _
        "PrintPageHeaderStyle parent="""" me=""Style16"" /><PrintPageFooterStyle parent="""" me" & _
        "=""Style17"" /></Blob>"
        '
        'dbgridSearchData
        '
        Me.dbgridSearchData.AllowColMove = False
        Me.dbgridSearchData.AllowColSelect = False
        Me.dbgridSearchData.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.dbgridSearchData.AllowUpdate = False
        Me.dbgridSearchData.AllowUpdateOnBlur = False
        Me.dbgridSearchData.AlternatingRows = True
        Me.dbgridSearchData.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.dbgridSearchData.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dbgridSearchData.FilterBar = True
        Me.dbgridSearchData.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dbgridSearchData.GroupByCaption = "Drag a column header here to group by that column"
        Me.dbgridSearchData.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
        Me.dbgridSearchData.Location = New System.Drawing.Point(1, 56)
        Me.dbgridSearchData.Name = "dbgridSearchData"
        Me.dbgridSearchData.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgridSearchData.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgridSearchData.PreviewInfo.ZoomFactor = 75
        Me.dbgridSearchData.RowHeight = 20
        Me.dbgridSearchData.Size = New System.Drawing.Size(880, 160)
        Me.dbgridSearchData.TabIndex = 5
        Me.dbgridSearchData.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{ForeColor:White;BackColor" & _
        ":SteelBlue;}Selected{ForeColor:Black;BackColor:Yellow;}Style3{}Inactive{ForeColo" & _
        "r:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{BackColor:White;}Foot" & _
        "er{}Caption{AlignHorz:Center;}Style1{}Normal{Font:Arial, 9pt, style=Bold;AlignVe" & _
        "rt:Center;BackColor:SteelBlue;}HighlightRow{ForeColor:HighlightText;BackColor:Hi" & _
        "ghlight;}Style14{}OddRow{BackColor:LightSteelBlue;}RecordSelector{AlignImage:Cen" & _
        "ter;}Style15{}Heading{AlignVert:Center;Wrap:True;Font:Microsoft Sans Serif, 8.25" & _
        "pt, style=Bold;AlignHorz:Center;Border:Raised,,1, 1, 1, 1;ForeColor:Lime;BackCol" & _
        "or:Black;}Style8{}Style10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style16{}St" & _
        "yle17{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMo" & _
        "ve=""False"" AllowColSelect=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowSt" & _
        "yle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" F" & _
        "ilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefRecS" & _
        "elWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>156</Heig" & _
        "ht><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=" & _
        """Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""" & _
        "FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle" & _
        " parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><Hig" & _
        "hLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inacti" & _
        "ve"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyl" & _
        "e parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""St" & _
        "yle6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 876, 156</ClientR" & _
        "ect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDB" & _
        "Grid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style paren" & _
        "t=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""H" & _
        "eading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""No" & _
        "rmal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal" & _
        """ me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Norma" & _
        "l"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""No" & _
        "rmal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertS" & _
        "plits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSe" & _
        "lWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 876, 156</ClientArea><PrintPageH" & _
        "eaderStyle parent="""" me=""Style16"" /><PrintPageFooterStyle parent="""" me=""Style17""" & _
        " /></Blob>"
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.Black
        Me.btnSearch.Location = New System.Drawing.Point(559, 32)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(63, 20)
        Me.btnSearch.TabIndex = 3
        Me.btnSearch.Text = "Search"
        '
        'btnCopyData
        '
        Me.btnCopyData.BackColor = System.Drawing.Color.SteelBlue
        Me.btnCopyData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopyData.ForeColor = System.Drawing.Color.White
        Me.btnCopyData.Location = New System.Drawing.Point(120, 8)
        Me.btnCopyData.Name = "btnCopyData"
        Me.btnCopyData.Size = New System.Drawing.Size(104, 20)
        Me.btnCopyData.TabIndex = 3
        Me.btnCopyData.Text = "Copy  Data"
        '
        'btnCopyAll
        '
        Me.btnCopyAll.BackColor = System.Drawing.Color.SteelBlue
        Me.btnCopyAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopyAll.ForeColor = System.Drawing.Color.White
        Me.btnCopyAll.Location = New System.Drawing.Point(120, 44)
        Me.btnCopyAll.Name = "btnCopyAll"
        Me.btnCopyAll.Size = New System.Drawing.Size(104, 20)
        Me.btnCopyAll.TabIndex = 4
        Me.btnCopyAll.Text = "Copy All"
        '
        'chkTraveler
        '
        Me.chkTraveler.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTraveler.ForeColor = System.Drawing.Color.Black
        Me.chkTraveler.Location = New System.Drawing.Point(8, 51)
        Me.chkTraveler.Name = "chkTraveler"
        Me.chkTraveler.Size = New System.Drawing.Size(96, 17)
        Me.chkTraveler.TabIndex = 2
        Me.chkTraveler.Text = "Travel Data"
        '
        'chkRepair
        '
        Me.chkRepair.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRepair.ForeColor = System.Drawing.Color.Black
        Me.chkRepair.Location = New System.Drawing.Point(8, 30)
        Me.chkRepair.Name = "chkRepair"
        Me.chkRepair.Size = New System.Drawing.Size(96, 16)
        Me.chkRepair.TabIndex = 1
        Me.chkRepair.Text = "Repair Data"
        '
        'chkMain
        '
        Me.chkMain.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMain.ForeColor = System.Drawing.Color.Black
        Me.chkMain.Location = New System.Drawing.Point(8, 8)
        Me.chkMain.Name = "chkMain"
        Me.chkMain.Size = New System.Drawing.Size(96, 16)
        Me.chkMain.TabIndex = 0
        Me.chkMain.Text = "Main Data"
        '
        'Panel1
        '
        Me.Panel1.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCopyData, Me.chkTraveler, Me.chkRepair, Me.btnCopyAll, Me.chkMain})
        Me.Panel1.Location = New System.Drawing.Point(648, 426)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(232, 88)
        Me.Panel1.TabIndex = 106
        '
        'frmHTCSearch
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(888, 525)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel1, Me.btnSearch, Me.dbgridSearchData, Me.dbgridTraveler, Me.dbgridPartsServices, Me.lblCriteria, Me.cboSearchBy, Me.Label1, Me.txtSearchCriteria, Me.lblTitle})
        Me.Name = "frmHTCSearch"
        Me.Text = "HTC Search"
        CType(Me.dbgridPartsServices, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dbgridTraveler, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dbgridSearchData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    Private Sub frmHTCSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            PSS.Core.Highlight.SetHighLight(Me)

            Me.cboSearchBy.SelectedIndex = 0
            Me.txtSearchCriteria.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "FormLoad", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************
    Private Sub cboSearchBy_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSearchBy.SelectedIndexChanged
        Me.txtSearchCriteria.Text = ""
        Me.txtSearchCriteria.Focus()
    End Sub

    '******************************************************************
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            Me.ProcessSearch()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnSearch_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************
    Private Sub txtSearchCriteria_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchCriteria.KeyUp
        Try
            If e.KeyValue = 13 Then
                Me.ProcessSearch()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtSearchCriteria_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************
    Private Sub ProcessSearch()
        Try
            If Me.txtSearchCriteria.Text.Trim.Length = 0 Then Exit Sub

            Me.dbgridPartsServices.DataSource = Nothing
            Me.dbgridSearchData.DataSource = Nothing
            Me.dbgridTraveler.DataSource = Nothing

            If Not IsNothing(Me._dsSearchData) Then
                Me._dsSearchData.Dispose()
                Me._dsSearchData = Nothing
            End If

            Me.PopulateSearchData()

        Catch ex As Exception
            Throw ex
        Finally
            Me.txtSearchCriteria.Focus()
        End Try
    End Sub

    '******************************************************************
    Private Sub PopulateSearchData()
        Dim i As Integer = 0
        Try
            Me._dsSearchData = Me._objHTC.GetSearchData(Me.cboSearchBy.Text, Me.txtSearchCriteria.Text.Trim)

            If IsNothing(Me._dsSearchData) Then Exit Sub
            If IsNothing(Me._dsSearchData.Tables("SearchData")) Then Exit Sub

            With Me.dbgridSearchData
                .DataSource = Me._dsSearchData.Tables("SearchData").DefaultView

                For i = 0 To .Columns.Count - 1
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Next i

                .Splits(0).DisplayColumns("Device_ID").Visible = False

                .Splits(0).DisplayColumns("IMEI In").Width = 110
                .Splits(0).DisplayColumns("IMEI Out").Width = 110

                .Splits(0).DisplayColumns("Counter").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            End With

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '******************************************************************
    Private Sub dbgridSearchData_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles dbgridSearchData.RowColChange
        Try
            If Me.txtSearchCriteria.Text.Trim.Length = 0 Then Exit Sub
            If Me.dbgridSearchData.RowCount = 0 Then Exit Sub

            Me.PopulateDeviceHistory(Me.dbgridSearchData.Columns("Device_ID").CellValue(Me.dbgridSearchData.Row))
            Me.PopulateDeviceBilling(Me.dbgridSearchData.Columns("Device_ID").CellValue(Me.dbgridSearchData.Row))
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "dbgridSearchData_RowColChange", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.txtSearchCriteria.Focus()
        End Try
    End Sub

    '******************************************************************
    Private Sub PopulateDeviceHistory(ByVal iDeviceID As Integer)
        Dim i As Integer = 0
        Dim dt As DataTable

        Try
            If IsNothing(Me._dsSearchData) Then Exit Sub
            dt = Me._dsSearchData.Tables(iDeviceID.ToString)
            If IsNothing(dt) Then dt = Me._objHTC.GetTestStationHistory(iDeviceID, )

            With Me.dbgridTraveler
                .DataSource = dt.DefaultView
                .Visible = True
                .RowHeight = 15

                For i = 0 To .Columns.Count - 1
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Next i

                .Columns("Date").NumberFormat = "MM/dd/yyyy hh:mm tt"

                .Splits(0).DisplayColumns("Station").Width = 60
                .Splits(0).DisplayColumns("Result").Width = 45
                .Splits(0).DisplayColumns("FailDetails").Width = 100
                .Splits(0).DisplayColumns("Inspector").Width = 80
                .Splits(0).DisplayColumns("Tech").Width = 80
                .Splits(0).DisplayColumns("FinalTester").Width = 80
                .Splits(0).DisplayColumns("Date").Width = 95
                .Splits(0).DisplayColumns("Seq").Width = 40

                .Splits(0).DisplayColumns("Device_ID").Visible = False
                .Splits(0).DisplayColumns("TD_ID").Visible = False
                .Splits(0).DisplayColumns("Test_ID").Visible = False
                .Splits(0).DisplayColumns("QCResult_ID").Visible = False
                .Splits(0).DisplayColumns("Reject").Visible = False
                .Splits(0).DisplayColumns("TD_UsrID").Visible = False

                '.Splits(0).DisplayColumns("Date").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                '.Splits(0).DisplayColumns("Result").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                '.Splits(0).DisplayColumns("Seq").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            End With
        Catch ex As Exception
            Throw ex
        Finally
            Generic.DisposeDT(dt)
        End Try
    End Sub

    '******************************************************************
    Private Sub PopulateDeviceBilling(ByVal iDeviceID As Integer)
        Dim i As Integer = 0
        Dim dt As DataTable
        Dim objNewTech As NewTech

        Try
            If IsNothing(Me._dsSearchData) Then Exit Sub
            dt = Me._dsSearchData.Tables("Billing_" & iDeviceID.ToString)
            If IsNothing(dt) Then
                objNewTech = New NewTech()
                dt = objNewTech.GetBillingSelectionInformation(iDeviceID, HTC.HTC_CUSTOMER_ID)
            End If

            With Me.dbgridPartsServices
                .DataSource = dt.DefaultView
                .Visible = True

                .Splits(0).Style.WrapText = True
                .FilterBar = True
                .RowHeight = 28
                .AlternatingRows = True

                For i = 0 To .Columns.Count - 1
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Next i

                .Splits(0).DisplayColumns("Complain Description").Width = 120
                .Splits(0).DisplayColumns("Main Category").Width = 100
                .Splits(0).DisplayColumns("Fail Code").Width = 120

                .Splits(0).DisplayColumns("Fail At").Width = 80
                .Splits(0).DisplayColumns("Failed Inspector").Width = 80
                .Splits(0).DisplayColumns("Repair Code").Width = 120
                .Splits(0).DisplayColumns("Part Desc").Width = 65
                .Splits(0).DisplayColumns("Part Number").Width = 70
                .Splits(0).DisplayColumns("Part SN").Width = 65
                .Splits(0).DisplayColumns("Part IMEI").Width = 65
                .Splits(0).DisplayColumns("Tech").Width = 100
                .Splits(0).DisplayColumns("Completed").Width = 62
                .Splits(0).DisplayColumns("Completed Tech").Width = 80
                .Splits(0).DisplayColumns("Completed Date").Width = 80
                .Splits(0).DisplayColumns("Seq").Width = 40

                .Columns("Completed Date").NumberFormat = "MM/dd/yyyy hh:mm tt"

                .Splits(0).DisplayColumns("BillCode_ID").Visible = False
                .Splits(0).DisplayColumns("Fail_ID").Visible = False
                .Splits(0).DisplayColumns("Repair_ID").Visible = False
                .Splits(0).DisplayColumns("MC_ID").Visible = False
                .Splits(0).DisplayColumns("RI_ID").Visible = False
                .Splits(0).DisplayColumns("Device_ID").Visible = False
                .Splits(0).DisplayColumns("FailDetails").Visible = False

            End With
        Catch ex As Exception
            Throw ex
        Finally
            objNewTech = Nothing
            Generic.DisposeDT(dt)
        End Try
    End Sub

    '******************************************************************
    Private Sub btnCopyData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyData.Click
        Dim strData As String = ""

        Try
            Me.Enabled = False

            If Me.chkMain.Checked = True Then
                strData = CopyDataFromDBGrid(Me.dbgridSearchData)
                strData &= vbCrLf
            End If

            If Me.chkRepair.Checked = True Then
                strData &= CopyDataFromDBGrid(Me.dbgridPartsServices)
                strData &= vbCrLf
            End If

            If Me.chkTraveler.Checked = True Then
                strData &= CopyDataFromDBGrid(Me.dbgridTraveler)
            End If

            'Copy Data to Clipboard
            System.Windows.Forms.Clipboard.SetDataObject(strData, False)
            Me.Enabled = True

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnCopyData_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Enabled = True
        End Try
    End Sub

    '******************************************************************
    Private Sub btnCopyAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyAll.Click
        Dim strData As String = ""

        Try
            Me.Enabled = False

            strData = CopyDataFromDBGrid(Me.dbgridSearchData)
            strData &= vbCrLf

            strData &= CopyDataFromDBGrid(Me.dbgridPartsServices)
            strData &= vbCrLf

            strData &= CopyDataFromDBGrid(Me.dbgridTraveler)

            'Copy Data to Clipboard
            System.Windows.Forms.Clipboard.SetDataObject(strData, False)
            Me.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnCopyData_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Enabled = True
        End Try
    End Sub

    '******************************************************************
    Private Function CopyDataFromDBGrid(ByRef dbgridCtrl As C1TrueDBGrid) As String
        Dim strData As String
        Dim iRow As Integer
        Dim booCompleteHeader As Boolean = False
        Dim col As C1.Win.C1TrueDBGrid.C1DataColumn
        Dim strHeader As String = ""

        Try
            If dbgridCtrl.RowCount > 0 And dbgridCtrl.Columns.Count Then
                Me.Enabled = False

                'loop through each selected row
                For iRow = 0 To dbgridCtrl.RowCount - 1

                    'loop through each selected column
                    For Each col In dbgridCtrl.Columns
                        If dbgridCtrl.Splits(0).DisplayColumns(col.Caption).Visible = True Then
                            'header
                            If booCompleteHeader = False Then
                                strHeader = strHeader & col.Caption & vbTab
                            End If
                            'data
                            strData = strData & col.CellText(iRow) & vbTab
                        End If
                    Next col

                    'add new line to data
                    strData = strData & vbCrLf

                    'Stop collect header
                    booCompleteHeader = True
                Next iRow

                'combine header and data
                strData = strHeader & vbCrLf & strData

                Return strData
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "CopyDataFromDBGrid", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Enabled = True
        End Try
    End Function

    '******************************************************************

End Class
