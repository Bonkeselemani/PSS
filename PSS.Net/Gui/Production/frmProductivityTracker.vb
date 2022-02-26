Public Class frmProductivityTracker
    Inherits System.Windows.Forms.Form
    Private objProdTracker As PSS.Data.Buisness.clsProdTracker
    Private objInventory As PSS.Data.Buisness.Inventory

    'Private strMachine As String = System.Net.Dns.GetHostName
    'Private strUserName As String = PSS.Core.Global.ApplicationUser.User
    'Private iUserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
    'Private iShiftID As Integer = PSS.Core.Global.ApplicationUser.IDShift
    'Private strWorkDate As String = PSS.Core.Global.ApplicationUser.Workdate

    Dim dtHourlyDetail As DataTable

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        objProdTracker = New PSS.Data.Buisness.clsProdTracker()
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
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDailyGoal As System.Windows.Forms.TextBox
    Friend WithEvents grdDaily As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbLine As PSS.Gui.Controls.ComboBox
    Friend WithEvents grdHourlyDetail As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents cmdStopTimer As System.Windows.Forms.Button
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbShift As PSS.Gui.Controls.ComboBox
    Friend WithEvents grdHourlyDetail_Xtra As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpWorkDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdExport As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmProductivityTracker))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpWorkDate = New System.Windows.Forms.DateTimePicker()
        Me.cmbShift = New PSS.Gui.Controls.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.cmbLine = New PSS.Gui.Controls.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDailyGoal = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdStopTimer = New System.Windows.Forms.Button()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.grdDaily = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.grdHourlyDetail = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.grdHourlyDetail_Xtra = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.cmdExport = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.grdDaily, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdHourlyDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdHourlyDetail_Xtra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label4, Me.dtpWorkDate, Me.cmbShift, Me.Label2, Me.cmdRefresh, Me.cmbLine, Me.Label3, Me.txtDailyGoal, Me.Label1, Me.cmdStopTimer})
        Me.Panel1.Location = New System.Drawing.Point(168, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(856, 64)
        Me.Panel1.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Lime
        Me.Label4.Location = New System.Drawing.Point(201, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 16)
        Me.Label4.TabIndex = 96
        Me.Label4.Text = "Work Date:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpWorkDate
        '
        Me.dtpWorkDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpWorkDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpWorkDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpWorkDate.Location = New System.Drawing.Point(285, 5)
        Me.dtpWorkDate.Name = "dtpWorkDate"
        Me.dtpWorkDate.Size = New System.Drawing.Size(114, 21)
        Me.dtpWorkDate.TabIndex = 95
        Me.dtpWorkDate.Value = New Date(2006, 1, 1, 0, 0, 0, 0)
        '
        'cmbShift
        '
        Me.cmbShift.AutoComplete = True
        Me.cmbShift.BackColor = System.Drawing.SystemColors.Window
        Me.cmbShift.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbShift.ForeColor = System.Drawing.Color.Black
        Me.cmbShift.Location = New System.Drawing.Point(48, 32)
        Me.cmbShift.Name = "cmbShift"
        Me.cmbShift.Size = New System.Drawing.Size(143, 21)
        Me.cmbShift.TabIndex = 91
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Lime
        Me.Label2.Location = New System.Drawing.Point(5, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 16)
        Me.Label2.TabIndex = 90
        Me.Label2.Text = "Shift:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdRefresh
        '
        Me.cmdRefresh.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRefresh.ForeColor = System.Drawing.Color.White
        Me.cmdRefresh.Location = New System.Drawing.Point(424, 6)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(88, 48)
        Me.cmdRefresh.TabIndex = 5
        Me.cmdRefresh.Text = "REFRESH"
        '
        'cmbLine
        '
        Me.cmbLine.AutoComplete = True
        Me.cmbLine.BackColor = System.Drawing.SystemColors.Window
        Me.cmbLine.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLine.ForeColor = System.Drawing.Color.Black
        Me.cmbLine.Location = New System.Drawing.Point(48, 5)
        Me.cmbLine.Name = "cmbLine"
        Me.cmbLine.Size = New System.Drawing.Size(143, 21)
        Me.cmbLine.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Lime
        Me.Label3.Location = New System.Drawing.Point(5, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Line:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDailyGoal
        '
        Me.txtDailyGoal.Location = New System.Drawing.Point(285, 32)
        Me.txtDailyGoal.Name = "txtDailyGoal"
        Me.txtDailyGoal.Size = New System.Drawing.Size(55, 20)
        Me.txtDailyGoal.TabIndex = 1
        Me.txtDailyGoal.Text = ""
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Lime
        Me.Label1.Location = New System.Drawing.Point(201, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Daily Goal:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdStopTimer
        '
        Me.cmdStopTimer.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdStopTimer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdStopTimer.ForeColor = System.Drawing.Color.White
        Me.cmdStopTimer.Location = New System.Drawing.Point(752, 8)
        Me.cmdStopTimer.Name = "cmdStopTimer"
        Me.cmdStopTimer.Size = New System.Drawing.Size(88, 48)
        Me.cmdStopTimer.TabIndex = 6
        Me.cmdStopTimer.Text = "STOP TIMER"
        '
        'lblHeader
        '
        Me.lblHeader.BackColor = System.Drawing.Color.Black
        Me.lblHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.Yellow
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(168, 64)
        Me.lblHeader.TabIndex = 1
        Me.lblHeader.Text = "REFURB TRACKER"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grdDaily
        '
        Me.grdDaily.AllowColMove = False
        Me.grdDaily.AllowColSelect = False
        Me.grdDaily.AllowFilter = False
        Me.grdDaily.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.grdDaily.AllowSort = False
        Me.grdDaily.AllowUpdate = False
        Me.grdDaily.AllowUpdateOnBlur = False
        Me.grdDaily.AlternatingRows = True
        Me.grdDaily.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDaily.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdDaily.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.grdDaily.Location = New System.Drawing.Point(0, 64)
        Me.grdDaily.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.grdDaily.Name = "grdDaily"
        Me.grdDaily.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdDaily.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdDaily.PreviewInfo.ZoomFactor = 75
        Me.grdDaily.RowHeight = 20
        Me.grdDaily.Size = New System.Drawing.Size(296, 488)
        Me.grdDaily.TabIndex = 2
        Me.grdDaily.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
        "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
        "er;}Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt;AlignVert:Center;BackColor:" & _
        "SteelBlue;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style14{}Od" & _
        "dRow{BackColor:LightSteelBlue;}RecordSelector{AlignImage:Center;}Style15{}Headin" & _
        "g{Wrap:True;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;Align" & _
        "Vert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}S" & _
        "tyle8{}Style10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style16{}Style17{}Styl" & _
        "e9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" " & _
        "AllowColSelect=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""True"" " & _
        "CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle" & _
        "=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollG" & _
        "roup=""1"" HorizontalScrollGroup=""1""><Height>484</Height><CaptionStyle parent=""Sty" & _
        "le2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle par" & _
        "ent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><F" & _
        "ooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12""" & _
        " /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""Highl" & _
        "ightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowSty" & _
        "le parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me" & _
        "=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Norma" & _
        "l"" me=""Style1"" /><ClientRect>0, 0, 292, 484</ClientRect><BorderSide>0</BorderSid" & _
        "e><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><Nam" & _
        "edStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><S" & _
        "tyle parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Styl" & _
        "e parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style" & _
        " parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style" & _
        " parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style pare" & _
        "nt=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Styl" & _
        "e parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSpl" & _
        "its>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidt" & _
        "h><ClientArea>0, 0, 292, 484</ClientArea><PrintPageHeaderStyle parent="""" me=""Sty" & _
        "le16"" /><PrintPageFooterStyle parent="""" me=""Style17"" /></Blob>"
        '
        'grdHourlyDetail
        '
        Me.grdHourlyDetail.AllowColMove = False
        Me.grdHourlyDetail.AllowColSelect = False
        Me.grdHourlyDetail.AllowFilter = False
        Me.grdHourlyDetail.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.grdHourlyDetail.AllowSort = False
        Me.grdHourlyDetail.AllowUpdate = False
        Me.grdHourlyDetail.AllowUpdateOnBlur = False
        Me.grdHourlyDetail.AlternatingRows = True
        Me.grdHourlyDetail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdHourlyDetail.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdHourlyDetail.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
        Me.grdHourlyDetail.Location = New System.Drawing.Point(296, 64)
        Me.grdHourlyDetail.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.grdHourlyDetail.Name = "grdHourlyDetail"
        Me.grdHourlyDetail.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdHourlyDetail.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdHourlyDetail.PreviewInfo.ZoomFactor = 75
        Me.grdHourlyDetail.RowHeight = 20
        Me.grdHourlyDetail.Size = New System.Drawing.Size(344, 488)
        Me.grdHourlyDetail.TabIndex = 3
        Me.grdHourlyDetail.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
        "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
        "er;}Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt;BackColor:SteelBlue;AlignVe" & _
        "rt:Center;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}Od" & _
        "dRow{BackColor:LightSteelBlue;}RecordSelector{AlignImage:Center;}Style13{}Headin" & _
        "g{Wrap:True;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;BackC" & _
        "olor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}S" & _
        "tyle8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style16{}Style17{}Styl" & _
        "e1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" " & _
        "AllowColSelect=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""True"" " & _
        "CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle" & _
        "=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollG" & _
        "roup=""1"" HorizontalScrollGroup=""1""><Height>484</Height><CaptionStyle parent=""Sty" & _
        "le2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle par" & _
        "ent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><F" & _
        "ooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12""" & _
        " /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""Highl" & _
        "ightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowSty" & _
        "le parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me" & _
        "=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Norma" & _
        "l"" me=""Style1"" /><ClientRect>0, 0, 340, 484</ClientRect><BorderSide>0</BorderSid" & _
        "e><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><Nam" & _
        "edStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><S" & _
        "tyle parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Styl" & _
        "e parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style" & _
        " parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style" & _
        " parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style pare" & _
        "nt=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Styl" & _
        "e parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSpl" & _
        "its>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidt" & _
        "h><ClientArea>0, 0, 340, 484</ClientArea><PrintPageHeaderStyle parent="""" me=""Sty" & _
        "le16"" /><PrintPageFooterStyle parent="""" me=""Style17"" /></Blob>"
        '
        'grdHourlyDetail_Xtra
        '
        Me.grdHourlyDetail_Xtra.AllowColMove = False
        Me.grdHourlyDetail_Xtra.AllowColSelect = False
        Me.grdHourlyDetail_Xtra.AllowFilter = False
        Me.grdHourlyDetail_Xtra.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.grdHourlyDetail_Xtra.AllowSort = False
        Me.grdHourlyDetail_Xtra.AllowUpdate = False
        Me.grdHourlyDetail_Xtra.AllowUpdateOnBlur = False
        Me.grdHourlyDetail_Xtra.AlternatingRows = True
        Me.grdHourlyDetail_Xtra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdHourlyDetail_Xtra.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdHourlyDetail_Xtra.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
        Me.grdHourlyDetail_Xtra.Location = New System.Drawing.Point(640, 64)
        Me.grdHourlyDetail_Xtra.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.grdHourlyDetail_Xtra.Name = "grdHourlyDetail_Xtra"
        Me.grdHourlyDetail_Xtra.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdHourlyDetail_Xtra.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdHourlyDetail_Xtra.PreviewInfo.ZoomFactor = 75
        Me.grdHourlyDetail_Xtra.RowHeight = 20
        Me.grdHourlyDetail_Xtra.Size = New System.Drawing.Size(384, 416)
        Me.grdHourlyDetail_Xtra.TabIndex = 4
        Me.grdHourlyDetail_Xtra.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
        "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
        "er;}Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt;AlignVert:Center;BackColor:" & _
        "SteelBlue;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style14{}Od" & _
        "dRow{BackColor:LightSteelBlue;}RecordSelector{AlignImage:Center;}Style15{}Headin" & _
        "g{Wrap:True;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;Align" & _
        "Vert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}S" & _
        "tyle8{}Style10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style16{}Style17{}Styl" & _
        "e9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" " & _
        "AllowColSelect=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""True"" " & _
        "CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle" & _
        "=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollG" & _
        "roup=""1"" HorizontalScrollGroup=""1""><Height>412</Height><CaptionStyle parent=""Sty" & _
        "le2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle par" & _
        "ent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><F" & _
        "ooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12""" & _
        " /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""Highl" & _
        "ightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowSty" & _
        "le parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me" & _
        "=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Norma" & _
        "l"" me=""Style1"" /><ClientRect>0, 0, 380, 412</ClientRect><BorderSide>0</BorderSid" & _
        "e><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><Nam" & _
        "edStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><S" & _
        "tyle parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Styl" & _
        "e parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style" & _
        " parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style" & _
        " parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style pare" & _
        "nt=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Styl" & _
        "e parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSpl" & _
        "its>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidt" & _
        "h><ClientArea>0, 0, 380, 412</ClientArea><PrintPageHeaderStyle parent="""" me=""Sty" & _
        "le16"" /><PrintPageFooterStyle parent="""" me=""Style17"" /></Blob>"
        '
        'cmdExport
        '
        Me.cmdExport.BackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExport.Location = New System.Drawing.Point(656, 504)
        Me.cmdExport.Name = "cmdExport"
        Me.cmdExport.Size = New System.Drawing.Size(136, 32)
        Me.cmdExport.TabIndex = 5
        Me.cmdExport.Text = "Export to Excel"
        Me.cmdExport.Visible = False
        '
        'frmProductivityTracker
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(1028, 566)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdExport, Me.grdHourlyDetail_Xtra, Me.grdHourlyDetail, Me.grdDaily, Me.lblHeader, Me.Panel1})
        Me.Name = "frmProductivityTracker"
        Me.Text = "Line Refurb Numbers"
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdDaily, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdHourlyDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdHourlyDetail_Xtra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Protected Overrides Sub Finalize()
        If Not IsNothing(dtHourlyDetail) Then
            dtHourlyDetail.Dispose()
            dtHourlyDetail = Nothing
        End If
        objProdTracker = Nothing
        objInventory = Nothing
        MyBase.Finalize()
    End Sub

    Private Sub LoadSummary()
        Dim iFlag As Integer = 0

        Try
            Me.Timer1.Stop()
            Me.cmdStopTimer.Text = "START TIMER"
            Application.DoEvents()

            Me.grdHourlyDetail.ClearFields()
            Me.grdHourlyDetail.DataSource = Nothing

            grdHourlyDetail_Xtra.ClearFields()
            grdHourlyDetail_Xtra.DataSource = Nothing

            If Trim(Me.txtDailyGoal.Text) = "" Then
                iFlag = 1
            Else
                If Not IsNumeric(Trim(Me.txtDailyGoal.Text)) Then
                    iFlag = 1
                End If
            End If
            If Me.cmbLine.SelectedValue = 0 Then
                iFlag = 1
            End If
            If Me.cmbShift.SelectedValue = 0 Then
                iFlag = 1
            End If

            If iFlag = 0 Then
                Dim dt1 As DataTable
                Try
                    dt1 = objProdTracker.GetRefurbNumbers(Format(Me.dtpWorkDate.Value, "yyyy-MM-dd"), Me.cmbShift.SelectedValue, Me.cmbLine.SelectedValue, Me.txtDailyGoal.Text)
                    Format(Me.dtpWorkDate.Value, "yyyy-MM-dd")
                    Me.grdDaily.ClearFields()
                    Me.grdDaily.DataSource = dt1.DefaultView
                    SetGridProperties()
                Catch ex1 As Exception
                    Throw ex1
                Finally
                    If Not IsNothing(dt1) Then
                        dt1.Dispose()
                        dt1 = Nothing
                    End If
                End Try
            Else
                Me.grdDaily.DataSource = Nothing
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "Timer", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            'Timer1.Enabled = True
            Me.Timer1.Start()
            Me.cmdStopTimer.Text = "STOP TIMER"
            Application.DoEvents()
        End Try

    End Sub

    Private Sub TimerEventProcessor(ByVal myObject As Object, ByVal myEventArgs As EventArgs)

        LoadSummary()

        'Try
        '    Me.Timer1.Stop()
        '    LoadSummary()
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message.ToString, "Timer", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        'Finally
        '    'Timer1.Enabled = True
        '    Me.Timer1.Start()
        'End Try
    End Sub
    '****************************************************
    Private Sub SetGridProperties()
        Dim iNumOfColumns As Integer = Me.grdDaily.Columns.Count
        Dim i As Integer


        With Me.grdDaily
            'Heading style (Horizontal Alignment to Center)
            For i = 0 To (iNumOfColumns - 1)
                .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Next

            'Set individual column data horizontal alignment
            .Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            .Splits(0).DisplayColumns(5).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns(6).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns(7).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Set Column Widths
            .Splits(0).DisplayColumns(0).Width = 90
            .Splits(0).DisplayColumns(5).Width = 46
            .Splits(0).DisplayColumns(6).Width = 59
            .Splits(0).DisplayColumns(7).Width = 58

            'Make some columns invisible
            .Splits(0).DisplayColumns(1).Visible = False
            .Splits(0).DisplayColumns(2).Visible = False
            .Splits(0).DisplayColumns(3).Visible = False
            .Splits(0).DisplayColumns(4).Visible = False

        End With
    End Sub
    '****************************************************
    'Load all lines
    '****************************************************
    Private Sub LoadAllLines()
        Dim dtLines As DataTable

        Try
            dtLines = objInventory.GetLines(, 1)
            With Me.cmbLine
                .DataSource = dtLines.DefaultView
                .DisplayMember = dtLines.Columns("Line").ToString
                .ValueMember = dtLines.Columns("Line_ID").ToString
                .SelectedValue = 0
            End With

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
    'Load all lines
    '****************************************************
    Private Sub LoadShifts()
        Dim dtShifts As DataTable

        Try
            dtShifts = objProdTracker.GetAllShifts
            With Me.cmbShift
                .DataSource = dtShifts.DefaultView
                .DisplayMember = dtShifts.Columns("Shift").ToString
                .ValueMember = dtShifts.Columns("Shift_ID").ToString
                .SelectedValue = 0
            End With

        Catch ex As Exception
            Throw New Exception("LoadAllLines:: " & ex.Message.ToString)
        Finally
            If Not IsNothing(dtShifts) Then
                dtShifts.Dispose()
                dtShifts = Nothing
            End If
        End Try
    End Sub
    '****************************************************
    Private Sub frmProductivityTracker_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim exitFlag As Boolean = False

        'Me.lblShift.Text = "SHIFT " & iShiftID
        'Me.lblWorkDate.Text = strWorkDate
        Me.LoadAllLines()
        LoadShifts()
        Me.dtpWorkDate.Value = Now

        AddHandler Timer1.Tick, AddressOf TimerEventProcessor

        '''Sets the timer interval to 60 seconds.
        Timer1.Interval = 60000
        Timer1.Start()

        '''Runs the timer, and raises the event.
        While exitFlag = False
            ' Processes all the events in the queue.
            Application.DoEvents()
        End While
    End Sub
    '****************************************************
    Private Sub grdDaily_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles grdDaily.RowColChange
        Dim dt1 As DataTable

        Try
            dt1 = objProdTracker.GetHourlyDetail(Me.cmbLine.SelectedValue, Me.grdDaily.Columns("Hour Start Time").Value, Me.grdDaily.Columns("Hour End Time").Value)
            Me.grdHourlyDetail.ClearFields()
            Me.grdHourlyDetail_Xtra.ClearFields()
            If Not IsNothing(dt1) Then
                Me.grdHourlyDetail.DataSource = dt1.DefaultView
                SetHourlyDetailGridProperties()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        Finally
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try

    End Sub
    '****************************************************
    Private Sub SetHourlyDetailGridProperties()
        Dim iNumOfColumns As Integer = Me.grdHourlyDetail.Columns.Count
        Dim i As Integer

        If iNumOfColumns = 0 Then
            Exit Sub
        End If

        With Me.grdHourlyDetail
            'Heading style (Horizontal Alignment to Center)
            For i = 0 To (iNumOfColumns - 1)
                .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Next

            'Set individual column data horizontal alignment
            .Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Set Column Widths
            .Splits(0).DisplayColumns(0).Width = 115
            .Splits(0).DisplayColumns(1).Width = 112
            .Splits(0).DisplayColumns(2).Width = 59


            'Make some columns invisible
            '.Splits(0).DisplayColumns(1).Visible = False
            '.Splits(0).DisplayColumns(2).Visible = False
            .Splits(0).DisplayColumns(3).Visible = False
            .Splits(0).DisplayColumns(4).Visible = False
            .Splits(0).DisplayColumns(5).Visible = False
            .Splits(0).DisplayColumns(6).Visible = False

        End With
    End Sub

    '****************************************************
    Private Sub SetHourlyDetailXtraGridProperties()
        Dim iNumOfColumns As Integer = Me.grdHourlyDetail_Xtra.Columns.Count
        Dim i As Integer

        If iNumOfColumns = 0 Then
            Exit Sub
        End If

        With Me.grdHourlyDetail_Xtra
            'Heading style (Horizontal Alignment to Center)
            For i = 0 To (iNumOfColumns - 1)
                .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Next

            'Set individual column data horizontal alignment
            .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

            'Set Column Widths
            .Splits(0).DisplayColumns(1).Width = 350

            'Make some columns invisible
            .Splits(0).DisplayColumns(0).Visible = False

        End With
    End Sub

    'Private Sub Asif()
    '    With Me.grdDaily
    '        MsgBox(.Splits(0).DisplayColumns(0).Width & Environment.NewLine & _
    '        .Splits(0).DisplayColumns(5).Width & Environment.NewLine & _
    '        .Splits(0).DisplayColumns(6).Width & Environment.NewLine & _
    '        .Splits(0).DisplayColumns(7).Width & Environment.NewLine)
    '    End With

    '    With Me.grdHourlyDetail
    '        MsgBox(.Splits(0).DisplayColumns(0).Width & Environment.NewLine & _
    '        .Splits(0).DisplayColumns(1).Width & Environment.NewLine & _
    '        .Splits(0).DisplayColumns(2).Width & Environment.NewLine)
    '    End With

    'End Sub


    Private Sub cmdStopTimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStopTimer.Click
        If UCase(Me.cmdStopTimer.Text) = "STOP TIMER" Then
            Me.Timer1.Stop()
            Me.cmdStopTimer.Text = "START TIMER"
        Else
            Me.Timer1.Start()
            Me.cmdStopTimer.Text = "STOP TIMER"
        End If
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        LoadSummary()
    End Sub

    Private Sub txtDailyGoal_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDailyGoal.KeyUp
        If e.KeyValue = 13 Then
            LoadSummary()
        End If
    End Sub

    Private Sub grdHourlyDetail_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles grdHourlyDetail.RowColChange
        'Dim dt1 As DataTable

        Try
            If Not IsNothing(dtHourlyDetail) Then
                dtHourlyDetail.Dispose()
                dtHourlyDetail = Nothing
            End If
            dtHourlyDetail = objProdTracker.GetHourlyDetail_Xtra(Me.cmbLine.SelectedValue, Me.grdDaily.Columns("Hour Start Time").Value, Me.grdDaily.Columns("Hour End Time").Value, Me.grdHourlyDetail.Columns("CellOpt_RefurbCompleteUserID").Value, Me.grdHourlyDetail.Columns("model_id").Value)
            Me.grdHourlyDetail_Xtra.ClearFields()
            If Not IsNothing(dtHourlyDetail) Then
                Me.grdHourlyDetail_Xtra.DataSource = dtHourlyDetail.DefaultView
                SetHourlyDetailXtraGridProperties()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
            'Finally
            'If Not IsNothing(dt1) Then
            '    dt1.Dispose()
            '    dt1 = Nothing
            'End If
        End Try
    End Sub


End Class
