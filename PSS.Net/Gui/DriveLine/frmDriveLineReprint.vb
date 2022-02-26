Public Class frmDriveLineReprint
    Inherits System.Windows.Forms.Form

    Private _objDriveLine As PSS.Data.Buisness.DriveLine
    Private _objDriveLinePrint As PSS.Data.Buisness.DriveLinePrint
    Private _IsFirstTime As Boolean = True

    Private _iEWID As Integer = 0
    Private _iWOID As Integer = 0
    Private _strOrderName As String, _strShipDate As String
    Private _strToShipName, _strToAddress, _strToCity, _strToState, _strToZip, _strToPhone As String
    Private _dtComponentsLocationDataTable As DataTable
    Private _strLastSelectedProjectID As String = ""
    Private _iDefaultRepLabelCount As Integer = 5

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me._IsFirstTime = True
        Me._objDriveLine = New PSS.Data.Buisness.DriveLine()
        Me._objDriveLinePrint = New PSS.Data.Buisness.DriveLinePrint()
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
    Friend WithEvents lblProject As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents tdgData1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblShipQty As System.Windows.Forms.Label
    Friend WithEvents lblOrderQty As System.Windows.Forms.Label
    Friend WithEvents txtShipTo As System.Windows.Forms.TextBox
    Friend WithEvents lblShipTo As System.Windows.Forms.Label
    Friend WithEvents tdgData2 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents cboProjectIDs As C1.Win.C1List.C1Combo
    Friend WithEvents btnAllYes As System.Windows.Forms.Button
    Friend WithEvents btnAllNo As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnReprintPickTicket As System.Windows.Forms.Button
    Friend WithEvents btnReprintLables As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtRepID As System.Windows.Forms.TextBox
    Friend WithEvents txtRepIDLabel As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnPrintRepIDLabel As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDriveLineReprint))
        Me.cboProjectIDs = New C1.Win.C1List.C1Combo()
        Me.lblProject = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.tdgData1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnAllNo = New System.Windows.Forms.Button()
        Me.btnReprintPickTicket = New System.Windows.Forms.Button()
        Me.btnAllYes = New System.Windows.Forms.Button()
        Me.tdgData2 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblShipQty = New System.Windows.Forms.Label()
        Me.lblOrderQty = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnReprintLables = New System.Windows.Forms.Button()
        Me.txtShipTo = New System.Windows.Forms.TextBox()
        Me.lblShipTo = New System.Windows.Forms.Label()
        Me.btnPrintRepIDLabel = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtRepID = New System.Windows.Forms.TextBox()
        Me.txtRepIDLabel = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.cboProjectIDs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.tdgData2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.Panel2.SuspendLayout()
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
        Me.cboProjectIDs.Location = New System.Drawing.Point(248, 0)
        Me.cboProjectIDs.MatchEntryTimeout = CType(2000, Long)
        Me.cboProjectIDs.MaxDropDownItems = CType(10, Short)
        Me.cboProjectIDs.MaxLength = 32767
        Me.cboProjectIDs.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboProjectIDs.Name = "cboProjectIDs"
        Me.cboProjectIDs.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboProjectIDs.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboProjectIDs.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboProjectIDs.Size = New System.Drawing.Size(144, 21)
        Me.cboProjectIDs.TabIndex = 42
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
        Me.lblProject.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProject.Location = New System.Drawing.Point(184, 0)
        Me.lblProject.Name = "lblProject"
        Me.lblProject.Size = New System.Drawing.Size(64, 24)
        Me.lblProject.TabIndex = 41
        Me.lblProject.Text = "Project ID:"
        Me.lblProject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTitle
        '
        Me.lblTitle.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.DarkOliveGreen
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(184, 24)
        Me.lblTitle.TabIndex = 57
        Me.lblTitle.Text = "DriveLine Reprint"
        '
        'tdgData1
        '
        Me.tdgData1.AllowUpdate = False
        Me.tdgData1.AlternatingRows = True
        Me.tdgData1.BackColor = System.Drawing.Color.GhostWhite
        Me.tdgData1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tdgData1.FetchRowStyles = True
        Me.tdgData1.FilterBar = True
        Me.tdgData1.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdgData1.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
        Me.tdgData1.Location = New System.Drawing.Point(8, 24)
        Me.tdgData1.Name = "tdgData1"
        Me.tdgData1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdgData1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdgData1.PreviewInfo.ZoomFactor = 75
        Me.tdgData1.Size = New System.Drawing.Size(848, 232)
        Me.tdgData1.TabIndex = 58
        Me.tdgData1.Text = "C1TrueDBGrid1"
        Me.tdgData1.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
        "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
        "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
        "tion{AlignHorz:Center;}Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt;}Highlig" & _
        "htRow{ForeColor:HighlightText;BackColor:Highlight;}Style14{}OddRow{}RecordSelect" & _
        "or{AlignImage:Center;}Style15{}Heading{Wrap:True;BackColor:Control;Border:Raised" & _
        ",,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}Style10{AlignHorz:N" & _
        "ear;}Style11{}Style12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDB" & _
        "Grid.MergeView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCapti" & _
        "onHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""True"" FilterBar=""True"" Mar" & _
        "queeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Vertic" & _
        "alScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>230</Height><CaptionStyle pa" & _
        "rent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRow" & _
        "Style parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Styl" & _
        "e13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=" & _
        """Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle pare" & _
        "nt=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><" & _
        "OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSel" & _
        "ector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style pare" & _
        "nt=""Normal"" me=""Style1"" /><ClientRect>0, 0, 846, 230</ClientRect><BorderSide>0</" & _
        "BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Sp" & _
        "lits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Head" & _
        "ing"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption" & _
        """ /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected""" & _
        " /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow""" & _
        " /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><S" & _
        "tyle parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar" & _
        """ /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits" & _
        "><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultR" & _
        "ecSelWidth><ClientArea>0, 0, 846, 230</ClientArea><PrintPageHeaderStyle parent=""" & _
        """ me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
        '
        'Panel1
        '
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel2, Me.Label3, Me.btnAllNo, Me.btnReprintPickTicket, Me.btnAllYes, Me.tdgData2, Me.GroupBox2, Me.btnReprintLables, Me.txtShipTo, Me.lblShipTo})
        Me.Panel1.Location = New System.Drawing.Point(8, 264)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(848, 328)
        Me.Panel1.TabIndex = 65
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(104, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(352, 16)
        Me.Label3.TabIndex = 82
        Me.Label3.Text = "Note: Double Click a row to toggle print Yes or No "
        '
        'btnAllNo
        '
        Me.btnAllNo.BackColor = System.Drawing.Color.DarkGray
        Me.btnAllNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAllNo.ForeColor = System.Drawing.Color.DarkRed
        Me.btnAllNo.Location = New System.Drawing.Point(42, 2)
        Me.btnAllNo.Name = "btnAllNo"
        Me.btnAllNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnAllNo.Size = New System.Drawing.Size(40, 22)
        Me.btnAllNo.TabIndex = 81
        Me.btnAllNo.Text = "No"
        '
        'btnReprintPickTicket
        '
        Me.btnReprintPickTicket.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnReprintPickTicket.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReprintPickTicket.ForeColor = System.Drawing.Color.MediumBlue
        Me.btnReprintPickTicket.Location = New System.Drawing.Point(608, 208)
        Me.btnReprintPickTicket.Name = "btnReprintPickTicket"
        Me.btnReprintPickTicket.Size = New System.Drawing.Size(232, 40)
        Me.btnReprintPickTicket.TabIndex = 80
        Me.btnReprintPickTicket.Text = "Print Pick Ticket"
        '
        'btnAllYes
        '
        Me.btnAllYes.BackColor = System.Drawing.Color.DarkGray
        Me.btnAllYes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAllYes.ForeColor = System.Drawing.Color.DarkRed
        Me.btnAllYes.Location = New System.Drawing.Point(0, 2)
        Me.btnAllYes.Name = "btnAllYes"
        Me.btnAllYes.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnAllYes.Size = New System.Drawing.Size(40, 22)
        Me.btnAllYes.TabIndex = 79
        Me.btnAllYes.Text = "Yes"
        '
        'tdgData2
        '
        Me.tdgData2.AllowColMove = False
        Me.tdgData2.AllowColSelect = False
        Me.tdgData2.AllowFilter = False
        Me.tdgData2.AllowSort = False
        Me.tdgData2.AllowUpdate = False
        Me.tdgData2.AlternatingRows = True
        Me.tdgData2.BackColor = System.Drawing.Color.GhostWhite
        Me.tdgData2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tdgData2.Caption = "Caption"
        Me.tdgData2.FetchRowStyles = True
        Me.tdgData2.FilterBar = True
        Me.tdgData2.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdgData2.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
        Me.tdgData2.Location = New System.Drawing.Point(0, 24)
        Me.tdgData2.Name = "tdgData2"
        Me.tdgData2.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdgData2.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdgData2.PreviewInfo.ZoomFactor = 75
        Me.tdgData2.Size = New System.Drawing.Size(600, 296)
        Me.tdgData2.TabIndex = 78
        Me.tdgData2.Text = "C1TrueDBGrid1"
        Me.tdgData2.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
        "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
        "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
        "tion{AlignHorz:Center;ForeColor:Green;}Style9{}Normal{Font:Microsoft Sans Serif," & _
        " 8.25pt;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddR" & _
        "ow{}RecordSelector{AlignImage:Center;}Style13{}Heading{Wrap:True;AlignVert:Cente" & _
        "r;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Sty" & _
        "le10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style1{}</Data></Styles><Splits>" & _
        "<C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" Name=" & _
        """"" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" Column" & _
        "FooterHeight=""17"" FetchRowStyles=""True"" FilterBar=""True"" MarqueeStyle=""DottedCel" & _
        "lBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" Ho" & _
        "rizontalScrollGroup=""1""><Height>277</Height><CaptionStyle parent=""Style2"" me=""St" & _
        "yle10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRo" & _
        "w"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle " & _
        "parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><Heading" & _
        "Style parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me" & _
        "=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""" & _
        "OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" " & _
        "/><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Styl" & _
        "e1"" /><ClientRect>0, 17, 598, 277</ClientRect><BorderSide>0</BorderSide><BorderS" & _
        "tyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><" & _
        "Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style paren" & _
        "t=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""" & _
        "Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""N" & _
        "ormal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""N" & _
        "ormal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Headin" & _
        "g"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""" & _
        "Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</hor" & _
        "zSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientA" & _
        "rea>0, 0, 598, 294</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><P" & _
        "rintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.lblShipQty, Me.lblOrderQty, Me.Label2})
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox2.Location = New System.Drawing.Point(608, 104)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(232, 54)
        Me.GroupBox2.TabIndex = 74
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Total"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "Order:"
        '
        'lblShipQty
        '
        Me.lblShipQty.BackColor = System.Drawing.Color.White
        Me.lblShipQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblShipQty.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShipQty.ForeColor = System.Drawing.Color.Black
        Me.lblShipQty.Location = New System.Drawing.Point(152, 16)
        Me.lblShipQty.Name = "lblShipQty"
        Me.lblShipQty.Size = New System.Drawing.Size(64, 32)
        Me.lblShipQty.TabIndex = 67
        Me.lblShipQty.Text = "0"
        Me.lblShipQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOrderQty
        '
        Me.lblOrderQty.BackColor = System.Drawing.Color.White
        Me.lblOrderQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOrderQty.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrderQty.ForeColor = System.Drawing.Color.Black
        Me.lblOrderQty.Location = New System.Drawing.Point(48, 16)
        Me.lblOrderQty.Name = "lblOrderQty"
        Me.lblOrderQty.Size = New System.Drawing.Size(64, 32)
        Me.lblOrderQty.TabIndex = 66
        Me.lblOrderQty.Text = "0"
        Me.lblOrderQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(112, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 16)
        Me.Label2.TabIndex = 69
        Me.Label2.Text = "Ship:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnReprintLables
        '
        Me.btnReprintLables.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnReprintLables.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReprintLables.ForeColor = System.Drawing.Color.MediumBlue
        Me.btnReprintLables.Location = New System.Drawing.Point(608, 160)
        Me.btnReprintLables.Name = "btnReprintLables"
        Me.btnReprintLables.Size = New System.Drawing.Size(232, 40)
        Me.btnReprintLables.TabIndex = 73
        Me.btnReprintLables.Text = "Print Labels"
        '
        'txtShipTo
        '
        Me.txtShipTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShipTo.Location = New System.Drawing.Point(608, 32)
        Me.txtShipTo.Multiline = True
        Me.txtShipTo.Name = "txtShipTo"
        Me.txtShipTo.ReadOnly = True
        Me.txtShipTo.Size = New System.Drawing.Size(232, 72)
        Me.txtShipTo.TabIndex = 71
        Me.txtShipTo.Text = ""
        '
        'lblShipTo
        '
        Me.lblShipTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShipTo.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.lblShipTo.Location = New System.Drawing.Point(608, 16)
        Me.lblShipTo.Name = "lblShipTo"
        Me.lblShipTo.Size = New System.Drawing.Size(200, 24)
        Me.lblShipTo.TabIndex = 70
        Me.lblShipTo.Text = "Ship To:"
        '
        'btnPrintRepIDLabel
        '
        Me.btnPrintRepIDLabel.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnPrintRepIDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintRepIDLabel.ForeColor = System.Drawing.Color.MediumBlue
        Me.btnPrintRepIDLabel.Location = New System.Drawing.Point(8, 32)
        Me.btnPrintRepIDLabel.Name = "btnPrintRepIDLabel"
        Me.btnPrintRepIDLabel.Size = New System.Drawing.Size(216, 32)
        Me.btnPrintRepIDLabel.TabIndex = 86
        Me.btnPrintRepIDLabel.Text = "Print RepID Label"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightSlateGray
        Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtRepID, Me.txtRepIDLabel, Me.btnPrintRepIDLabel, Me.Label4})
        Me.Panel2.Location = New System.Drawing.Point(608, 256)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(232, 72)
        Me.Panel2.TabIndex = 87
        '
        'txtRepID
        '
        Me.txtRepID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRepID.ForeColor = System.Drawing.Color.Black
        Me.txtRepID.Location = New System.Drawing.Point(88, 8)
        Me.txtRepID.Name = "txtRepID"
        Me.txtRepID.Size = New System.Drawing.Size(88, 22)
        Me.txtRepID.TabIndex = 88
        Me.txtRepID.Text = ""
        Me.txtRepID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtRepIDLabel
        '
        Me.txtRepIDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRepIDLabel.ForeColor = System.Drawing.Color.Black
        Me.txtRepIDLabel.Location = New System.Drawing.Point(184, 8)
        Me.txtRepIDLabel.Name = "txtRepIDLabel"
        Me.txtRepIDLabel.Size = New System.Drawing.Size(32, 22)
        Me.txtRepIDLabel.TabIndex = 87
        Me.txtRepIDLabel.Text = "5"
        Me.txtRepIDLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(-8, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 24)
        Me.Label4.TabIndex = 88
        Me.Label4.Text = "RepID Label"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmDriveLineReprint
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(864, 598)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel1, Me.tdgData1, Me.lblTitle, Me.cboProjectIDs, Me.lblProject})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmDriveLineReprint"
        Me.ShowInTaskbar = False
        Me.Text = "DriveLine - Reprint"
        CType(Me.cboProjectIDs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.tdgData2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

 
    '********************************************************************************
    Private Sub frmDriveLineReprint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        PopulateProjectIDs()
    End Sub

    '********************************************************************************
    Private Sub PopulateProjectIDs()
        Dim dt As DataTable
        Dim row As DataRow
        Dim i As Integer

        Try
            Me.cboProjectIDs.ClearItems()

            dt = Me._objDriveLine.GetDriveLineClosedOrder_ProjectIDs

            If dt.Rows.Count > 0 Then
                Misc.PopulateC1DropDownList(cboProjectIDs, dt, "Project_ID", "Project_ID")
            End If

            dt = Nothing


        Catch ex As Exception
            MessageBox.Show(ex.ToString, " PopulateProjectIDs", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Try

    End Sub

    '********************************************************************************
    Private Sub LoadClosedOrderData()
        Dim dt As DataTable, dtCloseDate As DataTable
        Dim row As DataRow
        Dim iEW_ID As Integer = 0

        Try
            Me.tdgData1.DataSource = Nothing : Me.tdgData2.DataSource = Nothing
            Me.txtShipTo.Text = "" : Me.lblOrderQty.Text = 0 : Me.lblShipQty.Text = 0
            Me.tdgData2.Caption = ""


            If Not cboProjectIDs.ListCount > 0 Then Exit Sub

            dt = Me._objDriveLine.GetDriveLineClosedOrder_ByProjectID(cboProjectIDs.SelectedValue)
            If dt.Rows.Count > 0 Then
                'This parttis slow, disable it
                'dtCloseDate = Me._objDriveLine.GetDriveLineClosedTime(iEW_ID)
                'For Each row In dt.Rows
                '    iEW_ID = row("EW_ID")
                '    dtCloseDate = Me._objDriveLine.GetDriveLineClosedTime(iEW_ID)
                '    If dtCloseDate.Rows.Count > 0 Then
                '        row.BeginEdit()
                '        row("CloseTime") = dtCloseDate.Rows(0).Item("CloseTime")
                '        row.EndEdit() : row.AcceptChanges()
                '    End If
                'Next
                'Dim dataView As New DataView(dt)
                'dataView.Sort = " CloseTime DESC"
                'Me.tdgData1.DataSource = dataView.Table  'dt
                Me.tdgData1.DataSource = dt
                Me.tdgData1.Splits(0).DisplayColumns("OrderName").Width = 120
                'Me.tdgData1.Splits(0).DisplayColumns("Retailer").Width = 60
                Me.tdgData1.Splits(0).DisplayColumns("Project_ID").Width = 50
                Me.tdgData1.Splits(0).DisplayColumns("Rep_ID").Width = 50
                Me.tdgData1.Splits(0).DisplayColumns("ZipCode").Width = 70
                Me.tdgData1.Splits(0).DisplayColumns("State").Width = 40
            Else
                MessageBox.Show("No order data!", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Sub LoadOrderData", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dt = Nothing
        End Try
    End Sub

    '********************************************************************************
    Private Sub cboProjectIDs_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProjectIDs.SelectedValueChanged
        If Not Me._IsFirstTime Then
            LoadClosedOrderData()
        End If
        Me._IsFirstTime = False
    End Sub

    '********************************************************************************
    Private Sub tdgData1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdgData1.MouseUp


        Try
            If Me.tdgData1.PointAt(e.X, e.Y) = C1.Win.C1TrueDBGrid.PointAtEnum.AtFilterBar Then
                Exit Sub
            End If
            ' Dim rtype As C1.Win.C1TrueDBGrid.RowTypeEnum = Me.tdgData1.Splits(0).Rows(Me.tdgData1.Row).RowType
            ' MessageBox.Show(rtype.ToString)
            'MessageBox.Show(tdgData1(tdgData1.Row, tdgData1.Col).ToString())

            If Me.tdgData1.RowCount > 0 Then

                UpdateDetailOrderData()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "tdgData1_MouseUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    '********************************************************************************
    Private Sub UpdateDetailOrderData(Optional ByVal rowIdx As Integer = 0)
        Try

            'Dim iRowID As Integer = Me.tdgData1.Row
            'Dim strDetailName As String = "", strProjectID As String = ""
            'Dim dt As DataTable, row As DataRow, col As DataColumn
            ''Dim myD As Date
            'Dim j As Integer = 0, i As Integer = 0
            'Dim strTableName As String = "DetailData"

            Dim iRowID As Integer = Me.tdgData1.Row
            Dim strDetailName As String = "", strProjectID As String = ""
            Dim dt, dtFinal As DataTable, row, row2 As DataRow, col As DataColumn
            Dim foundRows As DataRow()
            Dim rowView As DataRowView
            'Dim myD As Date
            Dim j As Integer = 0, i As Integer = 0
            Dim strTableName As String = "DetailData"
            Dim strExpression As String = ""

            Me.Panel1.Visible = False

            'Initial select row
            If rowIdx > 0 Then iRowID = rowIdx
            Me.tdgData1.SelectedRows.Add(iRowID) 'select current row

            'Ship Address info
            Me.txtShipTo.Text = ""
            Me._strToShipName = Me.tdgData1.Columns("ShipTo_Name").CellText(iRowID)
            Me._strToAddress = Me.tdgData1.Columns("Address").CellText(iRowID)
            Me._strToCity = Me.tdgData1.Columns("City").CellText(iRowID)
            Me._strToState = Me.tdgData1.Columns("State").CellText(iRowID)
            Me._strToZip = Me.tdgData1.Columns("ZipCode").CellText(iRowID)
            Me._strToPhone = Me.tdgData1.Columns("Phone").CellText(iRowID)

            Me.txtShipTo.Text = Me._strToShipName & Environment.NewLine
            Me.txtShipTo.Text &= Me._strToAddress & Environment.NewLine
            Me.txtShipTo.Text &= Me._strToCity & ", " & Me._strToState & " " & Me._strToZip & Environment.NewLine
            Me.txtShipTo.Text &= Me._strToPhone

            'Get key EW_ID
            If Not IsDBNull(Me.tdgData1.Columns("EW_ID").CellText(iRowID)) Then
                Me._iEWID = Me.tdgData1.Columns("EW_ID").CellText(iRowID)
            Else
                MessageBox.Show("Failed to get EW_ID!", "UpdateDetailOrderData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            If Not Me._iEWID > 0 Then
                MessageBox.Show("Failed to get EW_ID!", "UpdateDetailOrderData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            'Get WO_ID
            If Not IsDBNull(Me.tdgData1.Columns("WO_ID").CellText(iRowID)) Then
                Me._iWOID = Me.tdgData1.Columns("WO_ID").CellText(iRowID)
            Else
                MessageBox.Show("Failed to get WO_ID!", "UpdateDetailOrderData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            If Not Me._iWOID > 0 Then
                MessageBox.Show("Failed to get WO_ID!", "UpdateDetailOrderData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            Me._strOrderName = Me.tdgData1.Columns("OrderName").CellText(iRowID)
            Me._strShipDate = Me.tdgData1.Columns("WO_DateShip").CellText(iRowID)

            'Grid Title
            'strDetailName = "Order: " & Me._strOrderName & _
            '                ", Retailer: " & Me.tdgData1.Columns("Retailer").CellText(iRowID) & _
            '                ", Project: " & Me.tdgData1.Columns("Project_ID").CellText(iRowID) & _
            '                ", Rep: " & Me.tdgData1.Columns("Rep_ID").CellText(iRowID)
            strDetailName = "Order: " & Me._strOrderName & _
                            ", Project: " & Me.tdgData1.Columns("Project_ID").CellText(iRowID) & _
                            ", Rep: " & Me.tdgData1.Columns("Rep_ID").CellText(iRowID)
            strProjectID = Me.tdgData1.Columns("Project_ID").CellText(iRowID)
            Me.txtRepID.Text = Me.tdgData1.Columns("Rep_ID").CellText(iRowID)
            Me.tdgData2.Caption = strDetailName

            '---------------------------------------- DATA ------------------------------------------------------------------------
            'Keep ProjectID and get Components Location data
            If Not Me._strLastSelectedProjectID = strProjectID Then
                Me._strLastSelectedProjectID = strProjectID
                Me._dtComponentsLocationDataTable = Me._objDriveLine.GetDriveLine_LocationComponentAssignmentData(strProjectID)
            End If

            'Get data
            dt = Me._objDriveLine.GetDriveLineOrderDetails(Me._iEWID, strProjectID, True)
            If Not dt.Rows.Count > 0 Then
                MessageBox.Show("No detail data!", "UpdateDetailOrderData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            'Add Bin(LocNo)
            For Each row In dt.Rows
                strExpression = "Component='" & row("Component") & "'"
                foundRows = Me._dtComponentsLocationDataTable.Select(strExpression)
                For Each row2 In foundRows 'should be 1 row 
                    row.BeginEdit()
                    row("Bin") = row2("LocNo")
                    row.AcceptChanges() : row.EndEdit()
                    Exit For
                Next
            Next

            'Sort
            Dim dv As DataView = dt.DefaultView
            dv.Sort = "StoreNo Asc,Bin Asc"
            dtFinal = dt.Clone
            For Each rowView In dv
                row = rowView.Row
                dtFinal.ImportRow(row)
            Next

            'Add RowID
            i = 0
            For Each row In dtFinal.Rows 'dt.Rows
                i += 1
                row.BeginEdit()
                row("RowID") = i
                row.AcceptChanges()
                row.EndEdit()
            Next
            '------------------------------------------------------------------------------------------------------------------------------
            dt = Nothing : dv = Nothing

            dtFinal.TableName = strTableName 'dt.TableName = strTableName
            dtFinal.DefaultView.AllowNew = False 'dt.DefaultView.AllowNew = False
            Me.tdgData2.DataSource = dtFinal 'dt
            Me.tdgData2.Splits(0).DisplayColumns("RowID").Width = 15
            Me.tdgData2.Splits(0).DisplayColumns("Print").Width = 30
            Me.tdgData2.Splits(0).DisplayColumns("StoreNo").Width = 50
            Me.tdgData2.Splits(0).DisplayColumns("Component").Width = 200
            Me.tdgData2.Splits(0).DisplayColumns("Bin").Width = 30
            Me.tdgData2.Splits(0).DisplayColumns("UOM").Width = 30
            Me.tdgData2.Splits(0).DisplayColumns("OrderQty").Width = 60
            Me.tdgData2.Splits(0).DisplayColumns("ShipQty").Width = 60

            ComputeTotalQty()
            Me.Panel1.Visible = True

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "UpdateDetailOrderData", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tdgData2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdgData2.DoubleClick
        Dim iRowID As Integer
        Try
            iRowID = Me.tdgData2.Row
            If Me.tdgData2.Columns("Print").CellText(iRowID).ToUpper = "YES" Then
                Me.tdgData2(iRowID, 1) = "No"
            Else
                Me.tdgData2(iRowID, 1) = "Yes"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "tdgData2_DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub btnAllNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAllNo.Click
        Dim iRowID As Integer
        Try

            If Me.tdgData2.RowCount > 0 Then
                For iRowID = 0 To Me.tdgData2.RowCount - 1
                    Me.tdgData2(iRowID, 1) = "No"
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnAllNo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '********************************************************************************
    Private Sub ComputeTotalQty()
        Try

            Dim dt As DataTable = Me.tdgData2.DataSource
            Dim sumObj As Object = dt.Compute("Sum(ShipQty)", "")
            If sumObj Is Nothing Or sumObj.ToString.Trim.Length = 0 Then
                Me.lblOrderQty.Text = 0 : Me.lblShipQty.Text = 0
            Else
                Me.lblOrderQty.Text = sumObj : Me.lblShipQty.Text = sumObj
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, " ComputeTotalQty", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '********************************************************************************
    Private Sub btnAllYes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAllYes.Click
        Dim iRowID As Integer
        Try
            If Me.tdgData2.RowCount > 0 Then
                For iRowID = 0 To Me.tdgData2.RowCount - 1
                    Me.tdgData2(iRowID, 1) = "Yes"
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnYesNo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '********************************************************************************
    Private Sub btnReprintLables_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintLables.Click
        Dim strYN As String = "", strStoreNo As String = ""
        Dim strRetailer As String = "", strComponent As String = ""
        Dim i, iRowID
        Dim iCopyNum As Integer = 0, iTotalQty As Integer = 0
        Dim iLocNo As Integer = 0

        Try

            If Not Me.tdgData2.RowCount > 0 Then Exit Sub
            iTotalQty = Me.lblShipQty.Text

            For iRowID = 0 To Me.tdgData2.RowCount - 1
                If Not IsDBNull(Me.tdgData2.Columns("Print").CellText(iRowID)) Then
                    strYN = Me.tdgData2.Columns("Print").CellText(iRowID)
                End If
                If strYN.ToUpper = "YES" Then 'Print label
                    If Not IsDBNull(Me.tdgData2.Columns("ShipQty").CellText(iRowID)) Then
                        iCopyNum = Me.tdgData2.Columns("ShipQty").CellText(iRowID)
                        If Not IsDBNull(Me.tdgData2.Columns("StoreNo").CellText(iRowID)) Then strStoreNo = Me.tdgData2.Columns("StoreNo").CellText(iRowID)
                        If Not IsDBNull(Me.tdgData2.Columns("Component").CellText(iRowID)) Then strComponent = Me.tdgData2.Columns("Component").CellText(iRowID)
                        If Not IsDBNull(Me.tdgData2.Columns("Retailer").CellText(iRowID)) Then strRetailer = Me.tdgData2.Columns("Retailer").CellText(iRowID)
                        If Not IsDBNull(Me.tdgData2.Columns("Bin").CellText(iRowID)) Then iLocNo = Me.tdgData2.Columns("Bin").CellText(iRowID)

                        Me._objDriveLinePrint.Print_ShipBoxLabel(Me._strOrderName, strRetailer, strStoreNo, strComponent, iLocNo, iCopyNum)
                    End If
                End If
            Next

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnReprintLables_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '********************************************************************************
    Private Sub btnReprintPickTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintPickTicket.Click
        Dim dtDetails As DataTable
        Dim iTotalQty As Integer = 0

        Try
            If Not Me.tdgData2.RowCount > 0 Then Exit Sub
            iTotalQty = Me.lblShipQty.Text

            dtDetails = Me.tdgData2.DataSource

            Me._objDriveLinePrint.Print_ManifestReport(Me._strOrderName, Me._strShipDate, Me._strToShipName, Me._strToAddress, Me._strToCity, _
                                                       Me._strToState, Me._strToZip, Me._strToPhone, iTotalQty, dtDetails, 1)

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnReprintPickTicket_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '********************************************************************************
    Private Sub txtRepIDLabel_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRepIDLabel.KeyPress
        Dim allowed As String = "0123456789"
        Dim curchar As Integer = Asc(e.KeyChar)

        If (allowed.IndexOf(e.KeyChar) = -1) And (curchar <> 8) Then
            e.Handled = True
        End If
    End Sub

    '********************************************************************************
    Private Sub txtRepIDLabel_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRepIDLabel.KeyUp
        If IsNumeric(Me.txtRepIDLabel.Text) Then
            Dim iNum As Integer = Me.txtRepIDLabel.Text
            If iNum > 0 Then
                Me.txtRepIDLabel.Text = iNum
            Else
                Me.txtRepIDLabel.Text = Me._iDefaultRepLabelCount
            End If
        Else
            Me.txtRepIDLabel.Text = Me._iDefaultRepLabelCount
        End If
    End Sub

    '********************************************************************************
    Private Sub btnPrintRepIDLabel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintRepIDLabel.Click
        Dim iCopies As Integer = 0
        Try
            If IsNumeric(Me.txtRepIDLabel.Text) AndAlso Me.txtRepID.Text.Trim.Length > 0 Then
                iCopies = Me.txtRepIDLabel.Text
                If iCopies > 0 Then
                    Me._objDriveLinePrint.Print_ShipBoxLabel_RepID("", "", "", Me.txtRepID.Text, 0, iCopies)
                End If
            Else
                MessageBox.Show("No valid RepID data! Can't print.", "btnPrintRepIDLabel_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Sub PrintRepIDLabel", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '********************************************************************************
End Class
