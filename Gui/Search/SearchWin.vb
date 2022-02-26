Option Explicit On 

Namespace Gui.Search

    Public Class SearchWin
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
        Friend WithEvents dbgMain As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents grpOptions As System.Windows.Forms.GroupBox
        Friend WithEvents cboOptions As PSS.Gui.Controls.ComboBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents btnSearch As System.Windows.Forms.Button
        Friend WithEvents dbgParts As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents dbgDetail As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents grpDate As System.Windows.Forms.GroupBox
        Friend WithEvents dtStart As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtEnd As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents chkUseDate As System.Windows.Forms.CheckBox
        Friend WithEvents txtSearch As System.Windows.Forms.TextBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents cboSearchType As PSS.Gui.Controls.ComboBox
        Friend WithEvents pnlSearchCriteria As System.Windows.Forms.Panel
        Friend WithEvents lblCriteriaValue As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SearchWin))
            Me.dbgMain = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.grpOptions = New System.Windows.Forms.GroupBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.cboSearchType = New PSS.Gui.Controls.ComboBox()
            Me.btnSearch = New System.Windows.Forms.Button()
            Me.pnlSearchCriteria = New System.Windows.Forms.Panel()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cboOptions = New PSS.Gui.Controls.ComboBox()
            Me.txtSearch = New System.Windows.Forms.TextBox()
            Me.lblCriteriaValue = New System.Windows.Forms.Label()
            Me.dbgParts = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.dbgDetail = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.grpDate = New System.Windows.Forms.GroupBox()
            Me.chkUseDate = New System.Windows.Forms.CheckBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.dtEnd = New System.Windows.Forms.DateTimePicker()
            Me.dtStart = New System.Windows.Forms.DateTimePicker()
            CType(Me.dbgMain, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grpOptions.SuspendLayout()
            Me.pnlSearchCriteria.SuspendLayout()
            CType(Me.dbgParts, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dbgDetail, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grpDate.SuspendLayout()
            Me.SuspendLayout()
            '
            'dbgMain
            '
            Me.dbgMain.AlternatingRows = True
            Me.dbgMain.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.dbgMain.Caption = "Main Search Data"
            Me.dbgMain.CaptionHeight = 17
            Me.dbgMain.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
            Me.dbgMain.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveDown
            Me.dbgMain.FilterBar = True
            Me.dbgMain.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgMain.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dbgMain.Location = New System.Drawing.Point(224, 8)
            Me.dbgMain.Name = "dbgMain"
            Me.dbgMain.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgMain.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgMain.PreviewInfo.ZoomFactor = 75
            Me.dbgMain.RowHeight = 15
            Me.dbgMain.Size = New System.Drawing.Size(512, 432)
            Me.dbgMain.SpringMode = True
            Me.dbgMain.TabIndex = 0
            Me.dbgMain.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style13{}EvenRow{BackColor:LightSkyBlue;}Selected{ForeColor:HighlightText" & _
            ";BackColor:Highlight;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1" & _
            ", 1;ForeColor:ControlText;AlignVert:Center;}Inactive{ForeColor:InactiveCaptionTe" & _
            "xt;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Center;}Style" & _
            "20{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Normal{Font:Verdan" & _
            "a, 8.25pt;}Style26{}Style25{}Style24{}Style23{AlignHorz:Near;}Style22{}Style21{}" & _
            "OddRow{}RecordSelector{AlignImage:Center;}Style18{}Style19{}Style2{}Style14{}Sty" & _
            "le15{}Style16{}Style17{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.Gro" & _
            "upByView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeig" & _
            "ht=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder""" & _
            " RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" Horizontal" & _
            "ScrollGroup=""1"" SpringMode=""True""><Height>413</Height><CaptionStyle parent=""Head" & _
            "ing"" me=""Style23"" /><EditorStyle parent=""Editor"" me=""Style15"" /><EvenRowStyle pa" & _
            "rent=""EvenRow"" me=""Style21"" /><FilterBarStyle parent=""FilterBar"" me=""Style26"" />" & _
            "<FooterStyle parent=""Footer"" me=""Style17"" /><GroupStyle parent=""Group"" me=""Style" & _
            "25"" /><HeadingStyle parent=""Heading"" me=""Style16"" /><HighLightRowStyle parent=""H" & _
            "ighlightRow"" me=""Style20"" /><InactiveStyle parent=""Inactive"" me=""Style19"" /><Odd" & _
            "RowStyle parent=""OddRow"" me=""Style22"" /><RecordSelectorStyle parent=""RecordSelec" & _
            "tor"" me=""Style24"" /><SelectedStyle parent=""Selected"" me=""Style18"" /><Style paren" & _
            "t=""Normal"" me=""Style14"" /><ClientRect>0, 46, 510, 413</ClientRect><BorderSide>0<" & _
            "/BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.GroupByView><" & _
            "/Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""H" & _
            "eading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Capt" & _
            "ion"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Select" & _
            "ed"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightR" & _
            "ow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /" & _
            "><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""Filter" & _
            "Bar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSpl" & _
            "its><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</Defau" & _
            "ltRecSelWidth><ClientArea>0, 0, 510, 430</ClientArea><PrintPageHeaderStyle paren" & _
            "t="""" me=""Style1"" /><PrintPageFooterStyle parent="""" me=""Style2"" /></Blob>"
            '
            'grpOptions
            '
            Me.grpOptions.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label5, Me.cboSearchType, Me.btnSearch, Me.pnlSearchCriteria, Me.txtSearch, Me.lblCriteriaValue})
            Me.grpOptions.Location = New System.Drawing.Point(8, 8)
            Me.grpOptions.Name = "grpOptions"
            Me.grpOptions.Size = New System.Drawing.Size(208, 184)
            Me.grpOptions.TabIndex = 1
            Me.grpOptions.TabStop = False
            Me.grpOptions.Text = "Search Options"
            '
            'Label5
            '
            Me.Label5.Location = New System.Drawing.Point(8, 19)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(152, 16)
            Me.Label5.TabIndex = 6
            Me.Label5.Text = "Search Type"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'cboSearchType
            '
            Me.cboSearchType.Items.AddRange(New Object() {"Device Codes", "Freq/Capcode", "General", "Pretest", "Pre-Bill Completed", "QC", "RF", "Repair Completed", "Refurbish Completed"})
            Me.cboSearchType.Location = New System.Drawing.Point(8, 35)
            Me.cboSearchType.Name = "cboSearchType"
            Me.cboSearchType.Size = New System.Drawing.Size(192, 21)
            Me.cboSearchType.TabIndex = 1
            '
            'btnSearch
            '
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnSearch.Location = New System.Drawing.Point(8, 152)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.Size = New System.Drawing.Size(192, 24)
            Me.btnSearch.TabIndex = 4
            Me.btnSearch.Text = "Search"
            '
            'pnlSearchCriteria
            '
            Me.pnlSearchCriteria.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.cboOptions})
            Me.pnlSearchCriteria.Location = New System.Drawing.Point(0, 56)
            Me.pnlSearchCriteria.Name = "pnlSearchCriteria"
            Me.pnlSearchCriteria.Size = New System.Drawing.Size(200, 48)
            Me.pnlSearchCriteria.TabIndex = 2
            Me.pnlSearchCriteria.Visible = False
            '
            'Label1
            '
            Me.Label1.Location = New System.Drawing.Point(8, 5)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(152, 16)
            Me.Label1.TabIndex = 2
            Me.Label1.Text = "Search Criteria"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'cboOptions
            '
            Me.cboOptions.Items.AddRange(New Object() {"", "Company Name", "Customer Last Name", "Customer Work Order", "PSS Work Order", "Tray Number", "Serial Number", "Ship Manifest", "Old Serial", "IMEI Number", "Pallet ID", "Liquidity Services DID", "Sonitrol RMA", "Packing #", "Syx Manufacturing Serial"})
            Me.cboOptions.Location = New System.Drawing.Point(8, 21)
            Me.cboOptions.Name = "cboOptions"
            Me.cboOptions.Size = New System.Drawing.Size(192, 21)
            Me.cboOptions.TabIndex = 0
            '
            'txtSearch
            '
            Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSearch.Location = New System.Drawing.Point(8, 120)
            Me.txtSearch.Name = "txtSearch"
            Me.txtSearch.Size = New System.Drawing.Size(192, 21)
            Me.txtSearch.TabIndex = 3
            Me.txtSearch.Text = ""
            Me.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'lblCriteriaValue
            '
            Me.lblCriteriaValue.Location = New System.Drawing.Point(8, 104)
            Me.lblCriteriaValue.Name = "lblCriteriaValue"
            Me.lblCriteriaValue.Size = New System.Drawing.Size(152, 16)
            Me.lblCriteriaValue.TabIndex = 3
            Me.lblCriteriaValue.Text = "SN/IMEI"
            Me.lblCriteriaValue.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'dbgParts
            '
            Me.dbgParts.AlternatingRows = True
            Me.dbgParts.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.dbgParts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.dbgParts.Caption = "Parts/Service"
            Me.dbgParts.CaptionHeight = 17
            Me.dbgParts.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgParts.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.dbgParts.Location = New System.Drawing.Point(8, 264)
            Me.dbgParts.Name = "dbgParts"
            Me.dbgParts.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgParts.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgParts.PreviewInfo.ZoomFactor = 75
            Me.dbgParts.RowHeight = 15
            Me.dbgParts.Size = New System.Drawing.Size(208, 176)
            Me.dbgParts.SpringMode = True
            Me.dbgParts.TabIndex = 2
            Me.dbgParts.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Salmon;}Selecte" & _
            "d{ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inacti" & _
            "veCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Ce" & _
            "nter;}Style1{}Normal{Font:Verdana, 8.25pt;}HighlightRow{ForeColor:HighlightText;" & _
            "BackColor:Highlight;}Style12{}OddRow{}RecordSelector{AlignImage:Center;}Style13{" & _
            "}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:Control" & _
            "Text;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style15" & _
            "{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" Alterna" & _
            "tingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeig" & _
            "ht=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=" & _
            """17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1"" SpringMode=""True""><Height" & _
            ">157</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""E" & _
            "ditor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyl" & _
            "e parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><" & _
            "GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Styl" & _
            "e2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle pare" & _
            "nt=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSe" & _
            "lectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Select" & _
            "ed"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 17, 206, 1" & _
            "57</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.W" & _
            "in.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><" & _
            "Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Styl" & _
            "e parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style" & _
            " parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style par" & _
            "ent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style pa" & _
            "rent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style" & _
            " parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedSt" & _
            "yles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><D" & _
            "efaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 206, 174</ClientArea>" & _
            "<PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" m" & _
            "e=""Style15"" /></Blob>"
            '
            'dbgDetail
            '
            Me.dbgDetail.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.dbgDetail.Caption = "Device Information"
            Me.dbgDetail.CaptionHeight = 17
            Me.dbgDetail.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgDetail.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.dbgDetail.Location = New System.Drawing.Point(8, 448)
            Me.dbgDetail.Name = "dbgDetail"
            Me.dbgDetail.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgDetail.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgDetail.PreviewInfo.ZoomFactor = 75
            Me.dbgDetail.RowHeight = 15
            Me.dbgDetail.Size = New System.Drawing.Size(728, 72)
            Me.dbgDetail.TabIndex = 3
            Me.dbgDetail.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Style1{}Normal{Font:Verdana, 8.25pt;}HighlightRow{ForeColor:HighlightText;Ba" & _
            "ckColor:Highlight;}Style12{}OddRow{}RecordSelector{AlignImage:Center;}Style13{}H" & _
            "eading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlTe" & _
            "xt;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style15{}" & _
            "Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" CaptionHe" & _
            "ight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedC" & _
            "ellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" " & _
            "HorizontalScrollGroup=""1""><Height>53</Height><CaptionStyle parent=""Style2"" me=""S" & _
            "tyle10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenR" & _
            "ow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle" & _
            " parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><Headin" & _
            "gStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" m" & _
            "e=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=" & _
            """OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11""" & _
            " /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Sty" & _
            "le1"" /><ClientRect>0, 17, 726, 53</ClientRect><BorderSide>0</BorderSide><BorderS" & _
            "tyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><" & _
            "Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style paren" & _
            "t=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""" & _
            "Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""N" & _
            "ormal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""N" & _
            "ormal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Headin" & _
            "g"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""" & _
            "Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</hor" & _
            "zSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientA" & _
            "rea>0, 0, 726, 70</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><Pr" & _
            "intPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'grpDate
            '
            Me.grpDate.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkUseDate, Me.Label4, Me.Label3, Me.dtEnd, Me.dtStart})
            Me.grpDate.Location = New System.Drawing.Point(8, 192)
            Me.grpDate.Name = "grpDate"
            Me.grpDate.Size = New System.Drawing.Size(208, 72)
            Me.grpDate.TabIndex = 4
            Me.grpDate.TabStop = False
            Me.grpDate.Text = "Date Options"
            '
            'chkUseDate
            '
            Me.chkUseDate.Location = New System.Drawing.Point(8, 17)
            Me.chkUseDate.Name = "chkUseDate"
            Me.chkUseDate.Size = New System.Drawing.Size(16, 16)
            Me.chkUseDate.TabIndex = 4
            '
            'Label4
            '
            Me.Label4.Location = New System.Drawing.Point(40, 40)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(32, 16)
            Me.Label4.TabIndex = 3
            Me.Label4.Text = "To:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label3
            '
            Me.Label3.Location = New System.Drawing.Point(32, 16)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(40, 16)
            Me.Label3.TabIndex = 2
            Me.Label3.Text = "From:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtEnd
            '
            Me.dtEnd.Enabled = False
            Me.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtEnd.Location = New System.Drawing.Point(80, 40)
            Me.dtEnd.Name = "dtEnd"
            Me.dtEnd.Size = New System.Drawing.Size(120, 21)
            Me.dtEnd.TabIndex = 1
            '
            'dtStart
            '
            Me.dtStart.Enabled = False
            Me.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtStart.Location = New System.Drawing.Point(80, 16)
            Me.dtStart.Name = "dtStart"
            Me.dtStart.Size = New System.Drawing.Size(120, 21)
            Me.dtStart.TabIndex = 0
            '
            'SearchWin
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
            Me.ClientSize = New System.Drawing.Size(744, 525)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpDate, Me.dbgDetail, Me.dbgParts, Me.grpOptions, Me.dbgMain})
            Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "SearchWin"
            Me.Text = "Search"
            CType(Me.dbgMain, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grpOptions.ResumeLayout(False)
            Me.pnlSearchCriteria.ResumeLayout(False)
            CType(Me.dbgParts, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dbgDetail, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grpDate.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private _useDate As Boolean = False

        Private Sub chkUseDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUseDate.CheckedChanged
            Me._useDate = Not Me._useDate
            Me.dtStart.Enabled = Not Me.dtStart.Enabled
            Me.dtEnd.Enabled = Not Me.dtEnd.Enabled
        End Sub

        Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            Me.dbgDetail.DataSource = Nothing
            Me.dbgParts.DataSource = Nothing
            MainWin.StatusBar.SetStatusText("Searching...")
            Dim _searchString As String = "'" & Me.FormatSS(Me.txtSearch.Text) & "'"
            Dim _startDate As Date = Me.dtStart.Value
            Dim _endDate As Date = Me.dtEnd.Value
            Dim _searchType As PSS.Rules.SearchTypes = Nothing
            Dim _objPretest As PSS.Data.Buisness.PreTest

            Try
                If Me.pnlSearchCriteria.Visible = False And Me.lblCriteriaValue.Text = "SN/IMEI" Then
                    Me.cboOptions.SelectedIndex = 6
                End If

                Select Case Me.cboOptions.SelectedIndex
                    Case 1
                        _searchType = Rules.SearchTypes.CompanyName
                        If _useDate = False Then
                            MsgBox("You must use a date range when searching by this type", MsgBoxStyle.Information, "")
                            Me.chkUseDate.Checked = True
                            Exit Sub
                        End If
                    Case 2
                        _searchType = Rules.SearchTypes.CustomerLastName
                        If _useDate = False Then
                            MsgBox("You must use a date range when searching by this type", MsgBoxStyle.Information, "")
                            Me.chkUseDate.Checked = True
                            Exit Sub
                        End If
                    Case 3
                        _searchType = Rules.SearchTypes.CustoemerWO
                    Case 4
                        _searchType = Rules.SearchTypes.PSSWO
                    Case 5
                        _searchType = PSS.Rules.SearchTypes.Tray
                    Case 6
                        _searchType = PSS.Rules.SearchTypes.Serial
                    Case 7
                        _searchType = Rules.SearchTypes.ShipManifest
                    Case 8
                        _searchType = Rules.SearchTypes.OldSerial
                    Case 9
                        _searchType = Rules.SearchTypes.IMEI
                    Case 10
                        _searchType = Rules.SearchTypes.Pallet
                    Case 11
                        _searchType = Rules.SearchTypes.DyscernDID
                    Case 12
                        _searchType = Rules.SearchTypes.SonitrolRMA
                    Case 13
                        _searchType = Rules.SearchTypes.PackingSlipNumber
                    Case 14
                        _searchType = Rules.SearchTypes.SyxMfgSerial
                    Case Else
                        Exit Select
                End Select

                If InStr(_searchString, "*", CompareMethod.Text) Then
                    _searchString = Microsoft.VisualBasic.Left(_searchString, _searchString.Length - 2) & "%'"
                    If _useDate = False Then
                        MsgBox("You must use a date range when searching by this type", MsgBoxStyle.Information, "")
                        Me.chkUseDate.Checked = True
                        Exit Sub
                    End If
                End If

                If _searchType.ToString.Length = 0 Then
                    MsgBox("You must select a search type", MsgBoxStyle.Exclamation, "Search Error")
                    Me.cboOptions.Focus()
                    Exit Sub
                End If

                If _searchString.Length < 3 Then
                    MsgBox("You must enter a search string.", MsgBoxStyle.Exclamation, "Search Error")
                    Me.txtSearch.Text = ""
                    Me.txtSearch.Focus()
                    Exit Sub
                End If


                If Me._useDate Then
                    If InStr(_searchString, "%") > 1 Then
                        Me.dbgMain.DataSource = PSS.Rules.Search.GetPartialData(_searchString, _searchType, _startDate, DateAdd(DateInterval.Day, 1, _endDate))
                    Else
                        Me.dbgMain.DataSource = PSS.Rules.Search.GetMainData(_searchString, _searchType, _startDate, DateAdd(DateInterval.Day, 1, _endDate))
                    End If
                Else
                    If Me.cboSearchType.SelectedIndex = 0 Then
                        Me.dbgMain.DataSource = PSS.Data.Buisness.Search.GetDeviceCodesData(_searchString)
                        Me.dbgMain.Splits(0).DisplayColumns("Device_ID").Visible = False
                    ElseIf Me.cboSearchType.SelectedIndex = 1 Then
                        Me.dbgMain.DataSource = PSS.Rules.Search.GetMessagingData(_searchString)
                        Me.dbgMain.Splits(0).DisplayColumns("Device_ID").Visible = False
                    ElseIf Me.cboSearchType.SelectedIndex = 3 Then
                        Me.dbgMain.DataSource = PSS.Rules.Search.GetPretestData(_searchString)
                        Me.dbgMain.Splits(0).DisplayColumns("Device_ID").Visible = False
                    ElseIf Me.cboSearchType.SelectedIndex = 4 Then
                        Me.dbgMain.DataSource = PSS.Data.Buisness.Search.GetDataInTestTable(_searchString, "12")
                        Me.dbgMain.Splits(0).DisplayColumns("Device_ID").Visible = False
                    ElseIf Me.cboSearchType.SelectedIndex = 5 Then
                        Me.dbgMain.DataSource = PSS.Rules.Search.GetQCData(_searchString)
                        Me.dbgMain.Splits(0).DisplayColumns("Device_ID").Visible = False
                    ElseIf Me.cboSearchType.SelectedIndex = 6 Then
                        Me.dbgMain.DataSource = PSS.Data.Buisness.Search.GetDataInTestTable(_searchString, "2, 10")
                        Me.dbgMain.Splits(0).DisplayColumns("Device_ID").Visible = False
                    ElseIf Me.cboSearchType.SelectedIndex = 7 Then
                        Me.dbgMain.DataSource = PSS.Data.Buisness.Search.GetDataInTestTable(_searchString, "7")
                        Me.dbgMain.Splits(0).DisplayColumns("Device_ID").Visible = False
                    ElseIf Me.cboSearchType.SelectedIndex = 8 Then
                        Me.dbgMain.DataSource = PSS.Data.Buisness.Search.GetDataInTestTable(_searchString, "13")
                        Me.dbgMain.Splits(0).DisplayColumns("Device_ID").Visible = False
                    ElseIf _searchType = Rules.SearchTypes.SyxMfgSerial And Me.cboSearchType.SelectedIndex = 2 Then
                        Me.dbgMain.DataSource = PSS.Data.Buisness.Search.GetSyxMfgSerialData(_searchString)
                    Else
                        Me.dbgMain.DataSource = PSS.Rules.Search.GetMainData(_searchString, _searchType)
                        Me.dbgMain.Splits(0).DisplayColumns("Ship To Address1").Width = 120
                    End If
                End If
                'Me.dbgMain.Splits(0).DisplayColumns(0).Visible = False
                MainWin.StatusBar.SetStatusText("Ready")
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Function FormatSS(ByVal [string] As String) As String
            Return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Trim([string])).ToString()
        End Function

        'Private Sub cboOptions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOptions.SelectedIndexChanged
        '    If Me.cboOptions.SelectedIndex = 0 Then
        '        Me.btnSearch.Enabled = False
        '    Else
        '        Me.btnSearch.Enabled = True
        '        Me.txtSearch.Focus()
        '    End If
        'End Sub

        Private Sub SearchWin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            PSS.Core.Highlight.SetHighLight(Me)
            Me.cboOptions.SelectedIndex = 0
            Me.grpDate.Visible = False
            Me.chkUseDate.Checked = False
            Me.cboSearchType.SelectedIndex = 2
            Me.cboOptions.Focus()
        End Sub

        Private Sub dbgMain_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles dbgMain.RowColChange
            Try
                Me.dbgDetail.DataSource = PSS.Rules.Search.GetDevice(Trim(Me.dbgMain.Columns("Device_ID").Text))
                Me.dbgParts.DataSource = PSS.Rules.Search.GetParts(Trim(Me.dbgMain.Columns("Device_ID").Text))
                If PSS.Core.ApplicationUser.GetPermission(Me.GetType.Name) < 2 Then
                    Me.dbgParts.Splits(0).DisplayColumns("Avg Cost").Visible = False
                    Me.dbgParts.Splits(0).DisplayColumns("Std Cost").Visible = False
                    Me.dbgParts.Splits(0).AllowColMove = False
                    'Me.dbgDetail.Splits(0).DisplayColumns(4).Visible = False
                    Me.dbgDetail.Splits(0).AllowColMove = False
                End If

                Me.dbgParts.Splits(0).DisplayColumns("Code").Visible = False
            Catch ex As Exception
                Me.dbgDetail.DataSource = Nothing
                Me.dbgParts.DataSource = Nothing
            End Try
        End Sub

        Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
            If e.KeyCode = Keys.Enter Then
                If txtSearch.Text.Length > 0 Then
                    Me.btnSearch_Click(Me, EventArgs.Empty)
                End If
            End If
        End Sub

        Private Sub cboSearchType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSearchType.SelectedIndexChanged
            Try
                If Me.cboSearchType.SelectedIndex = 2 Then
                    Me.pnlSearchCriteria.Visible = True
                    Me.lblCriteriaValue.Text = "Search Criteria Value"
                    Me.grpDate.Visible = True
                Else
                    Me.pnlSearchCriteria.Visible = False
                    Me.lblCriteriaValue.Text = "SN/IMEI"
                    Me.grpDate.Visible = False
                    Me.chkUseDate.Checked = False
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        Private Sub dbgMain_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dbgMain.MouseDown
            Try
                Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = DirectCast(sender, C1.Win.C1TrueDBGrid.C1TrueDBGrid)

                If dbg.RowCount = 0 Then Return

                If e.Button = MouseButtons.Right Then
                    Dim ctmCopyData As New ContextMenu()
                    Dim objCopyAll As New MenuItem()
                    Dim objCopySelected As New MenuItem()

                    objCopyAll.Text = "Copy all grid data to the clipboard."
                    objCopySelected.Text = "Copy selected rows to the clipboard."

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
                MessageBox.Show(ex.ToString, "dbgMain_MouseDown", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        Private Sub CMenuCopyAllData(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                Misc.CopyAllData(Me.dbgMain)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CMenuCopyData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        Private Sub CMenuCopySelectedData(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                Misc.CopySelectedRowsData(Me.dbgMain)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CMenuCopySelectedData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub
    End Class
End Namespace
