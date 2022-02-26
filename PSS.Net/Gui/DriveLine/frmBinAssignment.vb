Option Explicit On 

Imports PSS.Data
Imports System.Text

Namespace Gui

    Public Class frmBinAssignment
        Inherits System.Windows.Forms.Form

        Private _objDriveLine As PSS.Data.Buisness.DriveLine
        Private _IsFirstTime As Boolean = True

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._objDriveLine = New PSS.Data.Buisness.DriveLine()
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
        Friend WithEvents cboProjectIDs As C1.Win.C1List.C1Combo
        Friend WithEvents lblProject As System.Windows.Forms.Label
        Friend WithEvents grpStockLocation As System.Windows.Forms.GroupBox
        Friend WithEvents txtLocationNo As System.Windows.Forms.TextBox
        Friend WithEvents lblLocationNo As System.Windows.Forms.Label
        Friend WithEvents lblLocationName As System.Windows.Forms.Label
        Friend WithEvents txtLocationName As System.Windows.Forms.TextBox
        Friend WithEvents tdgData1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnAddUpdate As System.Windows.Forms.Button
        Friend WithEvents grpAssignment As System.Windows.Forms.GroupBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents lstLocComponents As System.Windows.Forms.ListBox
        Friend WithEvents lstAvailableComponents As System.Windows.Forms.ListBox
        Friend WithEvents tdgData2 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnMoveIn As System.Windows.Forms.Button
        Friend WithEvents btnMoveOut As System.Windows.Forms.Button
        Friend WithEvents btnSave As System.Windows.Forms.Button
        Friend WithEvents btnRefreshAssignment As System.Windows.Forms.Button
        Friend WithEvents cboLocationNo As C1.Win.C1List.C1Combo
        Friend WithEvents lblAvailableComponents As System.Windows.Forms.Label
        Friend WithEvents btnComponentInfo As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmBinAssignment))
            Me.cboProjectIDs = New C1.Win.C1List.C1Combo()
            Me.lblProject = New System.Windows.Forms.Label()
            Me.grpStockLocation = New System.Windows.Forms.GroupBox()
            Me.tdgData1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnAddUpdate = New System.Windows.Forms.Button()
            Me.lblLocationName = New System.Windows.Forms.Label()
            Me.txtLocationName = New System.Windows.Forms.TextBox()
            Me.lblLocationNo = New System.Windows.Forms.Label()
            Me.txtLocationNo = New System.Windows.Forms.TextBox()
            Me.grpAssignment = New System.Windows.Forms.GroupBox()
            Me.btnComponentInfo = New System.Windows.Forms.Button()
            Me.cboLocationNo = New C1.Win.C1List.C1Combo()
            Me.btnRefreshAssignment = New System.Windows.Forms.Button()
            Me.btnSave = New System.Windows.Forms.Button()
            Me.btnMoveOut = New System.Windows.Forms.Button()
            Me.btnMoveIn = New System.Windows.Forms.Button()
            Me.tdgData2 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lblAvailableComponents = New System.Windows.Forms.Label()
            Me.lstAvailableComponents = New System.Windows.Forms.ListBox()
            Me.lstLocComponents = New System.Windows.Forms.ListBox()
            Me.Label1 = New System.Windows.Forms.Label()
            CType(Me.cboProjectIDs, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grpStockLocation.SuspendLayout()
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grpAssignment.SuspendLayout()
            CType(Me.cboLocationNo, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.tdgData2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'cboProjectIDs
            '
            Me.cboProjectIDs.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboProjectIDs.AutoCompletion = True
            Me.cboProjectIDs.AutoDropDown = True
            Me.cboProjectIDs.AutoSelect = True
            Me.cboProjectIDs.Caption = ""
            Me.cboProjectIDs.CaptionHeight = 17
            Me.cboProjectIDs.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboProjectIDs.ColumnCaptionHeight = 17
            Me.cboProjectIDs.ColumnFooterHeight = 17
            Me.cboProjectIDs.ColumnHeaders = False
            Me.cboProjectIDs.ContentHeight = 15
            Me.cboProjectIDs.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboProjectIDs.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboProjectIDs.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboProjectIDs.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboProjectIDs.EditorHeight = 15
            Me.cboProjectIDs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboProjectIDs.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboProjectIDs.ItemHeight = 15
            Me.cboProjectIDs.Location = New System.Drawing.Point(80, 8)
            Me.cboProjectIDs.MatchEntryTimeout = CType(2000, Long)
            Me.cboProjectIDs.MaxDropDownItems = CType(10, Short)
            Me.cboProjectIDs.MaxLength = 32767
            Me.cboProjectIDs.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboProjectIDs.Name = "cboProjectIDs"
            Me.cboProjectIDs.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboProjectIDs.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboProjectIDs.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboProjectIDs.Size = New System.Drawing.Size(152, 21)
            Me.cboProjectIDs.TabIndex = 44
            Me.cboProjectIDs.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            "ultRecSelWidth>17</DefaultRecSelWidth></Blob>"
            '
            'lblProject
            '
            Me.lblProject.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblProject.ForeColor = System.Drawing.Color.MediumBlue
            Me.lblProject.Location = New System.Drawing.Point(0, 6)
            Me.lblProject.Name = "lblProject"
            Me.lblProject.Size = New System.Drawing.Size(88, 24)
            Me.lblProject.TabIndex = 43
            Me.lblProject.Text = "Project ID:"
            Me.lblProject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'grpStockLocation
            '
            Me.grpStockLocation.BackColor = System.Drawing.Color.LightSteelBlue
            Me.grpStockLocation.Controls.AddRange(New System.Windows.Forms.Control() {Me.tdgData1, Me.btnAddUpdate, Me.lblLocationName, Me.txtLocationName, Me.lblLocationNo, Me.txtLocationNo})
            Me.grpStockLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grpStockLocation.Location = New System.Drawing.Point(16, 40)
            Me.grpStockLocation.Name = "grpStockLocation"
            Me.grpStockLocation.Size = New System.Drawing.Size(216, 544)
            Me.grpStockLocation.TabIndex = 45
            Me.grpStockLocation.TabStop = False
            Me.grpStockLocation.Text = "Define Stock Location"
            '
            'tdgData1
            '
            Me.tdgData1.AllowColMove = False
            Me.tdgData1.AllowColSelect = False
            Me.tdgData1.AllowFilter = False
            Me.tdgData1.AllowSort = False
            Me.tdgData1.AllowUpdate = False
            Me.tdgData1.AlternatingRows = True
            Me.tdgData1.BackColor = System.Drawing.Color.GhostWhite
            Me.tdgData1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdgData1.Caption = "List of Locations"
            Me.tdgData1.CaptionHeight = 17
            Me.tdgData1.FetchRowStyles = True
            Me.tdgData1.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgData1.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.tdgData1.Location = New System.Drawing.Point(16, 136)
            Me.tdgData1.Name = "tdgData1"
            Me.tdgData1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgData1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgData1.PreviewInfo.ZoomFactor = 75
            Me.tdgData1.RowHeight = 15
            Me.tdgData1.Size = New System.Drawing.Size(184, 392)
            Me.tdgData1.TabIndex = 79
            Me.tdgData1.Text = "C1TrueDBGrid1"
            Me.tdgData1.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;ForeColor:Green;}Style1{}Normal{Font:Microsoft Sans Serif," & _
            " 9.75pt;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style14{}OddR" & _
            "ow{}RecordSelector{AlignImage:Center;}Style15{}Heading{Wrap:True;BackColor:Contr" & _
            "ol;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}Sty" & _
            "le10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style9{}</Data></Styles><Splits>" & _
            "<C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" Name=" & _
            """"" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" Column" & _
            "FooterHeight=""17"" FetchRowStyles=""True"" MarqueeStyle=""DottedCellBorder"" RecordSe" & _
            "lectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGro" & _
            "up=""1""><Height>373</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorS" & _
            "tyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" />" & _
            "<FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" m" & _
            "e=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Hea" & _
            "ding"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><Inac" & _
            "tiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style" & _
            "9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle " & _
            "parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect" & _
            ">0, 17, 182, 373</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</Bord" & _
            "erStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" m" & _
            "e=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""F" & _
            "ooter"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inac" & _
            "tive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor" & _
            """ /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRo" & _
            "w"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSele" & _
            "ctor"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Grou" & _
            "p"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>N" & _
            "one</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 182, 39" & _
            "0</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterSty" & _
            "le parent="""" me=""Style15"" /></Blob>"
            '
            'btnAddUpdate
            '
            Me.btnAddUpdate.Location = New System.Drawing.Point(16, 88)
            Me.btnAddUpdate.Name = "btnAddUpdate"
            Me.btnAddUpdate.Size = New System.Drawing.Size(184, 32)
            Me.btnAddUpdate.TabIndex = 4
            Me.btnAddUpdate.Text = "Add/Update"
            '
            'lblLocationName
            '
            Me.lblLocationName.Location = New System.Drawing.Point(8, 56)
            Me.lblLocationName.Name = "lblLocationName"
            Me.lblLocationName.Size = New System.Drawing.Size(104, 24)
            Me.lblLocationName.TabIndex = 3
            Me.lblLocationName.Text = "Location Name:"
            Me.lblLocationName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtLocationName
            '
            Me.txtLocationName.Location = New System.Drawing.Point(120, 56)
            Me.txtLocationName.Name = "txtLocationName"
            Me.txtLocationName.Size = New System.Drawing.Size(80, 22)
            Me.txtLocationName.TabIndex = 2
            Me.txtLocationName.Text = ""
            '
            'lblLocationNo
            '
            Me.lblLocationNo.Location = New System.Drawing.Point(32, 24)
            Me.lblLocationNo.Name = "lblLocationNo"
            Me.lblLocationNo.Size = New System.Drawing.Size(80, 24)
            Me.lblLocationNo.TabIndex = 1
            Me.lblLocationNo.Text = "Location No:"
            Me.lblLocationNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtLocationNo
            '
            Me.txtLocationNo.Location = New System.Drawing.Point(120, 24)
            Me.txtLocationNo.Name = "txtLocationNo"
            Me.txtLocationNo.Size = New System.Drawing.Size(80, 22)
            Me.txtLocationNo.TabIndex = 0
            Me.txtLocationNo.Text = ""
            '
            'grpAssignment
            '
            Me.grpAssignment.BackColor = System.Drawing.Color.Silver
            Me.grpAssignment.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnComponentInfo, Me.cboLocationNo, Me.btnRefreshAssignment, Me.btnSave, Me.btnMoveOut, Me.btnMoveIn, Me.tdgData2, Me.lblAvailableComponents, Me.lstAvailableComponents, Me.lstLocComponents, Me.Label1})
            Me.grpAssignment.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grpAssignment.Location = New System.Drawing.Point(240, 8)
            Me.grpAssignment.Name = "grpAssignment"
            Me.grpAssignment.Size = New System.Drawing.Size(744, 568)
            Me.grpAssignment.TabIndex = 46
            Me.grpAssignment.TabStop = False
            Me.grpAssignment.Text = "Assign Component to Location"
            '
            'btnComponentInfo
            '
            Me.btnComponentInfo.BackColor = System.Drawing.Color.Silver
            Me.btnComponentInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnComponentInfo.ForeColor = System.Drawing.Color.SaddleBrown
            Me.btnComponentInfo.Location = New System.Drawing.Point(576, 8)
            Me.btnComponentInfo.Name = "btnComponentInfo"
            Me.btnComponentInfo.Size = New System.Drawing.Size(168, 24)
            Me.btnComponentInfo.TabIndex = 86
            Me.btnComponentInfo.Text = "View Component Quantities"
            '
            'cboLocationNo
            '
            Me.cboLocationNo.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboLocationNo.AutoCompletion = True
            Me.cboLocationNo.AutoDropDown = True
            Me.cboLocationNo.AutoSelect = True
            Me.cboLocationNo.Caption = ""
            Me.cboLocationNo.CaptionHeight = 17
            Me.cboLocationNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboLocationNo.ColumnCaptionHeight = 17
            Me.cboLocationNo.ColumnFooterHeight = 17
            Me.cboLocationNo.ColumnHeaders = False
            Me.cboLocationNo.ContentHeight = 15
            Me.cboLocationNo.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboLocationNo.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboLocationNo.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboLocationNo.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboLocationNo.EditorHeight = 15
            Me.cboLocationNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboLocationNo.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboLocationNo.ItemHeight = 15
            Me.cboLocationNo.Location = New System.Drawing.Point(80, 56)
            Me.cboLocationNo.MatchEntryTimeout = CType(2000, Long)
            Me.cboLocationNo.MaxDropDownItems = CType(10, Short)
            Me.cboLocationNo.MaxLength = 32767
            Me.cboLocationNo.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboLocationNo.Name = "cboLocationNo"
            Me.cboLocationNo.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboLocationNo.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboLocationNo.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboLocationNo.Size = New System.Drawing.Size(72, 21)
            Me.cboLocationNo.TabIndex = 85
            Me.cboLocationNo.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            "ultRecSelWidth>17</DefaultRecSelWidth></Blob>"
            '
            'btnRefreshAssignment
            '
            Me.btnRefreshAssignment.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRefreshAssignment.ForeColor = System.Drawing.Color.ForestGreen
            Me.btnRefreshAssignment.Location = New System.Drawing.Point(8, 16)
            Me.btnRefreshAssignment.Name = "btnRefreshAssignment"
            Me.btnRefreshAssignment.Size = New System.Drawing.Size(128, 24)
            Me.btnRefreshAssignment.TabIndex = 84
            Me.btnRefreshAssignment.Text = "Refresh "
            '
            'btnSave
            '
            Me.btnSave.BackColor = System.Drawing.Color.Transparent
            Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSave.ForeColor = System.Drawing.Color.Purple
            Me.btnSave.Location = New System.Drawing.Point(8, 208)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(120, 32)
            Me.btnSave.TabIndex = 83
            Me.btnSave.Text = "Save"
            '
            'btnMoveOut
            '
            Me.btnMoveOut.BackColor = System.Drawing.Color.Gray
            Me.btnMoveOut.ForeColor = System.Drawing.Color.Blue
            Me.btnMoveOut.Location = New System.Drawing.Point(240, 54)
            Me.btnMoveOut.Name = "btnMoveOut"
            Me.btnMoveOut.Size = New System.Drawing.Size(64, 28)
            Me.btnMoveOut.TabIndex = 82
            Me.btnMoveOut.Text = " ----->"
            '
            'btnMoveIn
            '
            Me.btnMoveIn.BackColor = System.Drawing.Color.Gray
            Me.btnMoveIn.ForeColor = System.Drawing.Color.Blue
            Me.btnMoveIn.Location = New System.Drawing.Point(240, 204)
            Me.btnMoveIn.Name = "btnMoveIn"
            Me.btnMoveIn.Size = New System.Drawing.Size(64, 28)
            Me.btnMoveIn.TabIndex = 81
            Me.btnMoveIn.Text = " <-----"
            '
            'tdgData2
            '
            Me.tdgData2.AllowColMove = False
            Me.tdgData2.AllowColSelect = False
            Me.tdgData2.AllowFilter = False
            Me.tdgData2.AllowSort = False
            Me.tdgData2.AllowUpdate = False
            Me.tdgData2.AlternatingRows = True
            Me.tdgData2.BackColor = System.Drawing.Color.White
            Me.tdgData2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdgData2.Caption = "Result of Assignment"
            Me.tdgData2.CaptionHeight = 15
            Me.tdgData2.FetchRowStyles = True
            Me.tdgData2.FilterBar = True
            Me.tdgData2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgData2.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgData2.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.tdgData2.Location = New System.Drawing.Point(8, 312)
            Me.tdgData2.Name = "tdgData2"
            Me.tdgData2.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgData2.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgData2.PreviewInfo.ZoomFactor = 75
            Me.tdgData2.RowHeight = 15
            Me.tdgData2.Size = New System.Drawing.Size(712, 248)
            Me.tdgData2.TabIndex = 80
            Me.tdgData2.Text = "C1TrueDBGrid1"
            Me.tdgData2.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;ForeColor:OliveDrab;BackColor:Gainsboro;}Style9{}Normal{Fo" & _
            "nt:Microsoft Sans Serif, 9pt;}HighlightRow{ForeColor:HighlightText;BackColor:Hig" & _
            "hlight;}Style12{}OddRow{}RecordSelector{AlignImage:Center;}Style13{}Heading{Wrap" & _
            ":True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor" & _
            ":Control;}Style8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style1{}</D" & _
            "ata></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowCo" & _
            "lSelect=""False"" Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCapt" & _
            "ionHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""True"" FilterBar=""True"" Ma" & _
            "rqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Verti" & _
            "calScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>231</Height><CaptionStyle p" & _
            "arent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRo" & _
            "wStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Sty" & _
            "le13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me" & _
            "=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle par" & _
            "ent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" />" & _
            "<OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSe" & _
            "lector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style par" & _
            "ent=""Normal"" me=""Style1"" /><ClientRect>0, 15, 710, 231</ClientRect><BorderSide>0" & _
            "</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></" & _
            "Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""He" & _
            "ading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Capti" & _
            "on"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selecte" & _
            "d"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRo" & _
            "w"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" />" & _
            "<Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterB" & _
            "ar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSpli" & _
            "ts><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</Defaul" & _
            "tRecSelWidth><ClientArea>0, 0, 710, 246</ClientArea><PrintPageHeaderStyle parent" & _
            "="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'lblAvailableComponents
            '
            Me.lblAvailableComponents.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblAvailableComponents.ForeColor = System.Drawing.Color.Navy
            Me.lblAvailableComponents.Location = New System.Drawing.Point(304, 32)
            Me.lblAvailableComponents.Name = "lblAvailableComponents"
            Me.lblAvailableComponents.Size = New System.Drawing.Size(176, 24)
            Me.lblAvailableComponents.TabIndex = 4
            Me.lblAvailableComponents.Text = "Available Components:"
            Me.lblAvailableComponents.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lstAvailableComponents
            '
            Me.lstAvailableComponents.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lstAvailableComponents.ForeColor = System.Drawing.Color.Navy
            Me.lstAvailableComponents.HorizontalScrollbar = True
            Me.lstAvailableComponents.ItemHeight = 15
            Me.lstAvailableComponents.Location = New System.Drawing.Point(304, 56)
            Me.lstAvailableComponents.Name = "lstAvailableComponents"
            Me.lstAvailableComponents.Size = New System.Drawing.Size(416, 244)
            Me.lstAvailableComponents.TabIndex = 3
            '
            'lstLocComponents
            '
            Me.lstLocComponents.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lstLocComponents.ForeColor = System.Drawing.Color.Navy
            Me.lstLocComponents.HorizontalScrollbar = True
            Me.lstLocComponents.ItemHeight = 15
            Me.lstLocComponents.Location = New System.Drawing.Point(8, 80)
            Me.lstLocComponents.Name = "lstLocComponents"
            Me.lstLocComponents.Size = New System.Drawing.Size(288, 124)
            Me.lstLocComponents.TabIndex = 2
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Navy
            Me.Label1.Location = New System.Drawing.Point(0, 56)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(80, 24)
            Me.Label1.TabIndex = 1
            Me.Label1.Text = "Location No:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'frmBinAssignment
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.Gainsboro
            Me.ClientSize = New System.Drawing.Size(1008, 598)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpAssignment, Me.grpStockLocation, Me.cboProjectIDs, Me.lblProject})
            Me.Name = "frmBinAssignment"
            Me.Text = "frmBinAssignment"
            CType(Me.cboProjectIDs, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grpStockLocation.ResumeLayout(False)
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grpAssignment.ResumeLayout(False)
            CType(Me.cboLocationNo, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.tdgData2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region



        '********************************************************************************
        Private Sub frmBinAssignment_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            PopulateProjectIDs()
        End Sub


        '********************************************************************************
        Private Sub PopulateProjectIDs()
            Dim dt As DataTable
            Dim row As DataRow
            Dim i As Integer

            Try
                Me.cboProjectIDs.ClearItems()

                dt = Me._objDriveLine.GetDriveLine_ProjectIDs(True)

                Misc.PopulateC1DropDownList(cboProjectIDs, dt, "Project_ID", "Project_ID")
                Me.cboProjectIDs.SelectedValue = "--Select--"




            Catch ex As Exception
                MessageBox.Show(ex.ToString, " PopulateProjectIDs", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try

        End Sub

        '********************************************************************************
        Private Sub PopulateLocationNumbers(ByVal strProject_ID As String)
            Dim dt As DataTable
            Dim row As DataRow
            Dim i As Integer

            Try

                Me.cboLocationNo.ClearItems()
                dt = Me._objDriveLine.GetDriveLine_StockLocationData(strProject_ID)
                Misc.PopulateC1DropDownList(cboLocationNo, dt, "LocNo", "DBin_ID")
                If dt.Rows.Count > 0 Then
                    cboLocationNo.SelectedIndex = 0
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, " PopulateProjectIDs", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try

        End Sub

        '********************************************************************************
        Private Sub LoadData()
            Dim dt As DataTable, dtCloseDate As DataTable
            Dim row As DataRow
            Dim iEW_ID As Integer = 0

            Try
                'Me.tdgData1.DataSource = Nothing : Me.tdgData2.DataSource = Nothing
                'Me.txtShipTo.Text = "" : Me.lblOrderQty.Text = 0 : Me.lblShipQty.Text = 0
                'Me.tdgData2.Caption = ""
                If cboProjectIDs.SelectedValue = "--Select--" Or cboProjectIDs.SelectedValue = Nothing Then
                    Me.tdgData1.Visible = False
                    Me.lstAvailableComponents.Items.Clear()
                    Me.lstLocComponents.Items.Clear()
                    Me.tdgData2.DataSource = Nothing
                    Me.cboLocationNo.DataSource = Nothing : Me.cboLocationNo.ClearItems()
                    Me.cboLocationNo.SelectedText = "" : Me.cboLocationNo.Text = ""
                    setAvailableComponentsCount()
                    Exit Sub
                End If

                dt = Me._objDriveLine.GetDriveLine_ProductComponentNames(cboProjectIDs.SelectedValue)


                If Not dt.Rows.Count > 0 Then
                    MessageBox.Show("No components.", "Sub LoadData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                If Not Me._objDriveLine.GetDriveLine_StockLocationHasDefined(cboProjectIDs.SelectedValue) Then
                    'Dim message, title, defaultValue As String
                    'Dim myValue As Object
                    'message = "How many Locations for this project" & cboProjectIDs.SelectedValue & "?" & Environment.NewLine & "Enter a number:"
                    '' Set title.
                    'title = "InputBox"
                    'defaultValue = "1"   ' Set default value.

                    '' Display message, title, and default value.
                    'myValue = InputBox(message, title, defaultValue)
                    '' If user has clicked Cancel, set myValue to defaultValue 
                    'If myValue Is "" Then myValue = defaultValue

                    '' Display dialog box at position 100, 100.
                    'myValue = InputBox(message, title, defaultValue, 100, 100)
                    '' If user has clicked Cancel, set myValue to defaultValue 
                    'If myValue Is "" Then myValue = defaultValue
                Else
                    BindStockLocationData(cboProjectIDs.SelectedValue)
                    RefreshAssignmentGroup()
                    Me.tdgData1.Visible = True
                End If



                'If Not cboProjectIDs.ListCount > 0 Then Exit Sub

                'dt = Me._objDriveLine.GetDriveLineClosedOrder_ByProjectID(cboProjectIDs.SelectedValue)
                'If dt.Rows.Count > 0 Then
                '    'This parttis slow, disable it
                '    'dtCloseDate = Me._objDriveLine.GetDriveLineClosedTime(iEW_ID)
                '    'For Each row In dt.Rows
                '    '    iEW_ID = row("EW_ID")
                '    '    dtCloseDate = Me._objDriveLine.GetDriveLineClosedTime(iEW_ID)
                '    '    If dtCloseDate.Rows.Count > 0 Then
                '    '        row.BeginEdit()
                '    '        row("CloseTime") = dtCloseDate.Rows(0).Item("CloseTime")
                '    '        row.EndEdit() : row.AcceptChanges()
                '    '    End If
                '    'Next
                '    'Dim dataView As New DataView(dt)
                '    'dataView.Sort = " CloseTime DESC"
                '    'Me.tdgData1.DataSource = dataView.Table  'dt
                '    Me.tdgData1.DataSource = dt
                '    Me.tdgData1.Splits(0).DisplayColumns("OrderName").Width = 120
                '    'Me.tdgData1.Splits(0).DisplayColumns("Retailer").Width = 60
                '    Me.tdgData1.Splits(0).DisplayColumns("Project_ID").Width = 50
                '    Me.tdgData1.Splits(0).DisplayColumns("Rep_ID").Width = 50
                '    Me.tdgData1.Splits(0).DisplayColumns("ZipCode").Width = 70
                '    Me.tdgData1.Splits(0).DisplayColumns("State").Width = 40
                'Else
                '    MessageBox.Show("No order data!", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                'End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub LoadOrderData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                dt = Nothing
            End Try
        End Sub

        '********************************************************************************
        Private Sub cboProjectIDs_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProjectIDs.SelectedValueChanged
           
            If Not Me._IsFirstTime Then
                LoadData()
                If cboProjectIDs.SelectedValue = "--Select--" Or cboProjectIDs.SelectedValue = Nothing Then Exit Sub
                BindStockLocationData(Me.cboProjectIDs.SelectedValue)
                'refresh assignments
                RefreshAssignmentGroup()
            End If
            Me._IsFirstTime = False
        End Sub

        '********************************************************************************
        Private Sub txtLocationNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLocationNo.KeyPress
            Dim allowed As String = "0123456789"
            Dim curchar As Integer = Asc(e.KeyChar)

            If (allowed.IndexOf(e.KeyChar) = -1) And (curchar <> 8) Then
                e.Handled = True
            End If
        End Sub

        '********************************************************************************
        Private Sub txtLocationNo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLocationNo.KeyUp
            If IsNumeric(Me.txtLocationNo.Text) Then
                Dim iNum As Integer = Me.txtLocationNo.Text
                If iNum > 0 Then
                    Me.txtLocationNo.Text = iNum
                Else
                    Me.txtLocationNo.Text = ""
                End If
            Else
                Me.txtLocationNo.Text = ""
            End If
        End Sub

        '********************************************************************************
        Private Sub txtLocationName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLocationName.KeyPress
            Dim allowed As String = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"
            Dim curchar As Integer = Asc(e.KeyChar)

            If (allowed.IndexOf(e.KeyChar) = -1) And (curchar <> 8 And curchar <> 32) Then
                e.Handled = True
            End If
        End Sub

        '********************************************************************************
        Private Sub txtLocationName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLocationName.KeyUp
            Me.txtLocationNo.Text = Me.txtLocationNo.Text.Replace("'", "")
        End Sub

        '********************************************************************************
        Private Sub txtLocationName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLocationName.Leave
            Me.txtLocationNo.Text = Me.txtLocationNo.Text.Replace("'", "")
        End Sub

        '********************************************************************************
        Private Sub btnAddUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddUpdate.Click
            Dim strProjectID As String
            Dim i As Integer
            Dim iUserID As Integer = Core.ApplicationUser.IDuser
            Dim strDTime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            'MessageBox.Show(cboProjectIDs.SelectedText & "   " & Me.cboProjectIDs.SelectedValue)
            Try
                If cboProjectIDs.SelectedValue = "--Select--" Or cboProjectIDs.SelectedValue = Nothing Then Exit Sub
                strProjectID = Me.cboProjectIDs.SelectedValue

                If IsNumeric(Me.txtLocationNo.Text) And Me.txtLocationName.Text.Trim.Length > 0 Then
                    i = Me._objDriveLine.InsertUpdateStockLocation(Me.txtLocationNo.Text, Me.txtLocationName.Text.Trim, strProjectID, iUserID, strDTime)
                End If

                Me.txtLocationName.Text = "" : Me.txtLocationNo.Text = ""
                Me.txtLocationNo.Focus()
                BindStockLocationData(strProjectID)

                'refresh assignments
                RefreshAssignmentGroup()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub btnAddUpdate_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub

        '********************************************************************************
        Private Sub BindStockLocationData(ByVal strProjectID As String)
            Dim dt As DataTable
            Try
                dt = Me._objDriveLine.GetDriveLine_StockLocationData(strProjectID)
                Me.tdgData1.DataSource = dt
                Me.tdgData1.Splits(0).DisplayColumns("LocNo").Width = 40
                Me.tdgData1.Splits(0).DisplayColumns("Location").Width = 120
                Me.tdgData1.Visible = True
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub BindStockLocationData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub btnRefreshAssignment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshAssignment.Click
            Dim dt As DataTable
            Dim row As DataRow

            Try
               RefreshAssignmentGroup
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub  btnRefreshAssignment_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub RefreshAssignmentGroup()
            Dim dt As DataTable
            Dim row As DataRow

            Try
                If cboProjectIDs.SelectedValue = "--Select--" Or cboProjectIDs.SelectedValue = Nothing Then Exit Sub

                '1. Load components
                LoadAvailableComponents()

                '2. Load Location number
                PopulateLocationNumbers(cboProjectIDs.SelectedValue)

                '3. Load ComponentAssignment and Manipulate lstAvialableCoponents
                RefreshLocationComponentAssignmentDisplayData()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub  RefreshAssignmentGroup", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub setAvailableComponentsCount()
            Try
                Me.lblAvailableComponents.Text = "Available Components (" & Me.lstAvailableComponents.Items.Count & "):"
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub  setAvailableComponentsCount", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub LoadAvailableComponents()
            Dim dt As DataTable
            Dim row As DataRow
            Try
                dt = Me._objDriveLine.GetDriveLine_ProductComponentNames(cboProjectIDs.SelectedValue)
                Me.lstAvailableComponents.Items.Clear()
                For Each row In dt.Rows
                    Me.lstAvailableComponents.Items.Add(row("ProductName"))
                Next
                setAvailableComponentsCount()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub  setAvailableComponentsCount", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub cboLocationNo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLocationNo.SelectedValueChanged
            Dim dt As DataTable
            Dim row As DataRow

            Try
                Me.lstLocComponents.Items.Clear()
                If Not Me.cboLocationNo.SelectedValue > 0 Then Exit Sub

                dt = Me._objDriveLine.GetDriveLine_LocationBinComponents(Me.cboLocationNo.SelectedValue)
                For Each row In dt.Rows
                    Me.lstLocComponents.Items.Add(row("ProductName"))
                Next

                'reload
                LoadAvailableComponents()
                RefreshLocationComponentAssignmentDisplayData()

                ' Me.cboLocationNo.DataSource.Table.select("iDBin_ID = " & Me.cboLocationNo.SelectedValue)(0)("DBin_ID")

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub  cboLocationNo_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub

        Private Sub RefreshLocationComponentAssignmentDisplayData()
            Dim dt As DataTable
            Dim row As DataRow
            Dim strArrList1 As New ArrayList(), strArrList2 As New ArrayList()
            Dim i As Integer

            Try
                If cboProjectIDs.SelectedValue = "--Select--" Or cboProjectIDs.SelectedValue = Nothing Then
                    Exit Sub
                Else
                    dt = Me._objDriveLine.GetDriveLine_LocationComponentAssignmentData(cboProjectIDs.SelectedValue)
                    Me.tdgData2.DataSource = dt
                    Me.tdgData2.Caption = "Result of Assignment (" & dt.Rows.Count & ")"

                    'Copy to array lists
                    For Each row In dt.Rows
                        strArrList1.Add(row("Component"))
                    Next
                    For i = 0 To Me.lstAvailableComponents.Items.Count - 1
                        strArrList2.Add(Me.lstAvailableComponents.Items(i).ToString)
                    Next

                    'Exclude those that are already assigned
                    Me.lstAvailableComponents.Items.Clear()
                    For i = 0 To strArrList2.Count - 1
                        If Not strArrList1.Contains(strArrList2(i)) Then
                            Me.lstAvailableComponents.Items.Add(strArrList2(i))
                        End If
                    Next

                    setAvailableComponentsCount()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub  RefreshLocationComponentAssignmentDisplayData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub

        '********************************************************************************
        'Private Sub lstAvailableComponents_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstAvailableComponents.SelectedIndexChanged
        '    If Me.lstAvailableComponents.SelectedIndex >= 0 Then

        '    End If
        'End Sub

        '********************************************************************************
        Private Sub btnMoveIn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMoveIn.Click
            Try
                If Me.lstAvailableComponents.SelectedIndex >= 0 Then
                    Me.lstLocComponents.Items.Add(Me.lstAvailableComponents.SelectedItem)
                    Me.lstAvailableComponents.Items.RemoveAt(Me.lstAvailableComponents.SelectedIndex)
                    Me.lstAvailableComponents.SelectedIndex = -1
                End If
                setAvailableComponentsCount()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub btnMoveIn_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub btnMoveOut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMoveOut.Click
            Try
                If Me.lstLocComponents.SelectedIndex >= 0 Then
                    Me.lstAvailableComponents.Items.Add(Me.lstLocComponents.SelectedItem)
                    Me.lstLocComponents.Items.RemoveAt(Me.lstLocComponents.SelectedIndex)
                    Me.lstLocComponents.SelectedIndex = -1
                End If
                setAvailableComponentsCount()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub btnMoveOut_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
            Dim strErrMsg As String = ""
            Dim iDBin_ID, iProdOrder, i As Integer
            Dim iUserID As Integer = Core.ApplicationUser.IDuser
            Dim strDTime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            Dim strExpression As String = ""
            'Dim dt As DataTable , row As DataRow
            'Dim foundRows() As DataRow

            Try

                If Me.cboLocationNo.SelectedValue > 0 AndAlso Me.lstLocComponents.Items.Count > 0 Then
                    iDBin_ID = Me.cboLocationNo.SelectedValue

                    'clear
                    Me._objDriveLine.ClearComponentAssigment(iDBin_ID)

                    'Save 
                    For i = 0 To Me.lstLocComponents.Items.Count - 1
                        strErrMsg = "" : iProdOrder = i + 1
                        Me._objDriveLine.InsertLocationComponentAssigmentResult(iDBin_ID, Me.lstLocComponents.Items(i).ToString, _
                                                                                iProdOrder, iUserID, strDTime, strErrMsg)
                        If strErrMsg.Length > 0 Then
                            MessageBox.Show(strErrMsg, "Failed to save", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Next

                    Me.RefreshAssignmentGroup()
                    Me.cboLocationNo.SelectedValue = iDBin_ID

                ElseIf Me.cboLocationNo.SelectedValue > 0 AndAlso Me.lstLocComponents.Items.Count = 0 Then
                    iDBin_ID = Me.cboLocationNo.SelectedValue
                    'clear
                    Me._objDriveLine.ClearComponentAssigment(iDBin_ID)

                    Me.RefreshAssignmentGroup()
                    Me.cboLocationNo.SelectedValue = iDBin_ID

                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub btnComponentInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnComponentInfo.Click
            Dim dt As DataTable
            Dim row As DataRow
            Dim strS As String, strMsg As String = ""
            Dim strProject_ID As String = ""
            Dim i, j As Integer, iTotal As Integer = 0, iTotalStores As Integer = 0
            Dim L As Integer = 0, iMaxLen As Integer = 0

            Try

                If cboProjectIDs.SelectedValue = "--Select--" Or cboProjectIDs.SelectedValue = Nothing Then
                    Exit Sub
                End If

                strProject_ID = cboProjectIDs.SelectedValue

                dt = Me._objDriveLine.GetDriveLine_TotalQuantitiesOfComponents(strProject_ID)

                For Each row In dt.Rows
                    strS = row("ProductName")
                    If strS.Length > iMaxLen Then iMaxLen = strS.Length
                Next

                i = 0
                For Each row In dt.Rows
                    If i = 0 Then strMsg = "Quantities of Components for Project_ID """ & strProject_ID & """" & Environment.NewLine & Environment.NewLine
                    strS = row("ProductName")
                    L = (iMaxLen - strS.Length) + 5
                    strS = ""
                    For j = 1 To L
                        strS &= "-"
                    Next
                    If row("ComponentCount") > 0 Then
                        strMsg &= (i + 1).ToString & ". " & row("ProductName") & strS & row("ComponentCount") & " pieces (" & row("StoreCount") & " stores)" & Environment.NewLine
                    Else
                        strMsg &= (i + 1).ToString & ". " & row("ProductName") & strS & row("ComponentCount") & " piece (" & row("StoreCount") & " stores)" & Environment.NewLine
                    End If

                    iTotal += row("ComponentCount")
                    i += 1
                Next

                iTotalStores = Me._objDriveLine.GetDriveLine_TotalQuantitiesOfStores4Project(strProject_ID)

                If strMsg.Trim.Length > 0 Then
                    strMsg &= Environment.NewLine & "TOTAL COMPONENTS: " & iTotal.ToString
                    strMsg &= Environment.NewLine & "TOTAL STORES: " & iTotalStores.ToString & Environment.NewLine
                    MessageBox.Show(strMsg, "Info List", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnComponentInfo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
    End Class

End Namespace

