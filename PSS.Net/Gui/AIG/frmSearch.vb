Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.AIG
    Public Class frmSearch
        Inherits System.Windows.Forms.Form

        Private _iMenuCustID As Integer
        Private _objAIG As Data.Buisness.AIG

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iCustID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _iMenuCustID = iCustID
            _objAIG = New Data.Buisness.AIG()
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
        Friend WithEvents cboCustomers As C1.Win.C1List.C1Combo
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents lblEmptyBoxToCustTrackNo As System.Windows.Forms.Label
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents Label13 As System.Windows.Forms.Label
        Friend WithEvents Label14 As System.Windows.Forms.Label
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents lblEmptyBoxShipDate As System.Windows.Forms.Label
        Friend WithEvents lblClaimReceiptDate As System.Windows.Forms.Label
        Friend WithEvents Label20 As System.Windows.Forms.Label
        Friend WithEvents Label21 As System.Windows.Forms.Label
        Friend WithEvents lblUnitReceiptDate As System.Windows.Forms.Label
        Friend WithEvents Label17 As System.Windows.Forms.Label
        Friend WithEvents lblUnitShipDate As System.Windows.Forms.Label
        Friend WithEvents Label22 As System.Windows.Forms.Label
        Friend WithEvents lblUnitShipTrackNo As System.Windows.Forms.Label
        Friend WithEvents Label23 As System.Windows.Forms.Label
        Friend WithEvents lblShippingBoxName As System.Windows.Forms.Label
        Friend WithEvents Label24 As System.Windows.Forms.Label
        Friend WithEvents lblPssWrtyApproveBy As System.Windows.Forms.Label
        Friend WithEvents Label25 As System.Windows.Forms.Label
        Friend WithEvents lblEDIDef1 As System.Windows.Forms.Label
        Friend WithEvents Label26 As System.Windows.Forms.Label
        Friend WithEvents lblEDIDef2 As System.Windows.Forms.Label
        Friend WithEvents Label28 As System.Windows.Forms.Label
        Friend WithEvents Label27 As System.Windows.Forms.Label
        Friend WithEvents lblTechNotes As System.Windows.Forms.Label
        Friend WithEvents Label29 As System.Windows.Forms.Label
        Friend WithEvents lblEDIErr As System.Windows.Forms.Label
        Friend WithEvents lblExceptionRep As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents lblExceptionRepApprovedBy As System.Windows.Forms.Label
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents lblTechHrs As System.Windows.Forms.Label
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents lblPssStatus As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents lblWorkStation As System.Windows.Forms.Label
        Friend WithEvents dbgPartNeeds As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents dbgPartService As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents dbgTechFailureCodes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents dbgSearchResult As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnSearch As System.Windows.Forms.Button
        Friend WithEvents txtSearchVal As System.Windows.Forms.TextBox
        Friend WithEvents lblUnitRecTrackNo As System.Windows.Forms.Label
        Friend WithEvents lblQuoteApprovedStatus As System.Windows.Forms.Label
        Friend WithEvents lblReceivedSN As System.Windows.Forms.Label
        Friend WithEvents lblQuoteApprovedBy As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents lblPssWrty As System.Windows.Forms.Label
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents lblPssWrtyApprovedStatus As System.Windows.Forms.Label
        Friend WithEvents lblEdiSN As System.Windows.Forms.Label
        Friend WithEvents Label16 As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSearch))
            Me.cboCustomers = New C1.Win.C1List.C1Combo()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtSearchVal = New System.Windows.Forms.TextBox()
            Me.dbgSearchResult = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.lblQuoteApprovedBy = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.dbgTechFailureCodes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.dbgPartService = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.dbgPartNeeds = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lblQuoteApprovedStatus = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.lblTechHrs = New System.Windows.Forms.Label()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.lblExceptionRepApprovedBy = New System.Windows.Forms.Label()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.lblExceptionRep = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.lblTechNotes = New System.Windows.Forms.Label()
            Me.Label29 = New System.Windows.Forms.Label()
            Me.lblEDIErr = New System.Windows.Forms.Label()
            Me.Label27 = New System.Windows.Forms.Label()
            Me.lblEDIDef2 = New System.Windows.Forms.Label()
            Me.Label28 = New System.Windows.Forms.Label()
            Me.lblEDIDef1 = New System.Windows.Forms.Label()
            Me.Label26 = New System.Windows.Forms.Label()
            Me.lblUnitRecTrackNo = New System.Windows.Forms.Label()
            Me.lblEmptyBoxToCustTrackNo = New System.Windows.Forms.Label()
            Me.lblReceivedSN = New System.Windows.Forms.Label()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.Label13 = New System.Windows.Forms.Label()
            Me.Label14 = New System.Windows.Forms.Label()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.lblPssWrtyApprovedStatus = New System.Windows.Forms.Label()
            Me.lblPssWrty = New System.Windows.Forms.Label()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.lblWorkStation = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.lblPssStatus = New System.Windows.Forms.Label()
            Me.lblShippingBoxName = New System.Windows.Forms.Label()
            Me.Label24 = New System.Windows.Forms.Label()
            Me.lblUnitShipTrackNo = New System.Windows.Forms.Label()
            Me.Label23 = New System.Windows.Forms.Label()
            Me.lblUnitShipDate = New System.Windows.Forms.Label()
            Me.Label22 = New System.Windows.Forms.Label()
            Me.lblUnitReceiptDate = New System.Windows.Forms.Label()
            Me.Label17 = New System.Windows.Forms.Label()
            Me.lblEmptyBoxShipDate = New System.Windows.Forms.Label()
            Me.lblClaimReceiptDate = New System.Windows.Forms.Label()
            Me.Label20 = New System.Windows.Forms.Label()
            Me.Label21 = New System.Windows.Forms.Label()
            Me.Label25 = New System.Windows.Forms.Label()
            Me.lblPssWrtyApproveBy = New System.Windows.Forms.Label()
            Me.btnSearch = New System.Windows.Forms.Button()
            Me.lblEdiSN = New System.Windows.Forms.Label()
            Me.Label16 = New System.Windows.Forms.Label()
            CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dbgSearchResult, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox1.SuspendLayout()
            CType(Me.dbgTechFailureCodes, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dbgPartService, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dbgPartNeeds, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox2.SuspendLayout()
            Me.SuspendLayout()
            '
            'cboCustomers
            '
            Me.cboCustomers.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
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
            Me.cboCustomers.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCustomers.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboCustomers.ItemHeight = 15
            Me.cboCustomers.Location = New System.Drawing.Point(136, 16)
            Me.cboCustomers.MatchEntryTimeout = CType(2000, Long)
            Me.cboCustomers.MaxDropDownItems = CType(5, Short)
            Me.cboCustomers.MaxLength = 32767
            Me.cboCustomers.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCustomers.Name = "cboCustomers"
            Me.cboCustomers.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCustomers.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCustomers.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCustomers.Size = New System.Drawing.Size(344, 21)
            Me.cboCustomers.TabIndex = 0
            Me.cboCustomers.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
            "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Microsoft" & _
            " Sans Serif, 8.25pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:" & _
            "Highlight;}Style9{AlignHorz:Near;}OddRow{}RecordSelector{AlignImage:Center;}Head" & _
            "ing{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;B" & _
            "ackColor:Control;}Style8{}Style10{}Style11{}Style1{}</Data></Styles><Splits><C1." & _
            "Win.C1List.ListBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""1" & _
            "7"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" Hori" & _
            "zontalScrollGroup=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height" & _
            "><VScrollBar><Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScr" & _
            "ollBar><CaptionStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow" & _
            """ me=""Style7"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""G" & _
            "roup"" me=""Style11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowS" & _
            "tyle parent=""HighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""St" & _
            "yle4"" /><OddRowStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""" & _
            "RecordSelector"" me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><S" & _
            "tyle parent=""Normal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedSt" & _
            "yles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style" & _
            " parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style pa" & _
            "rent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style par" & _
            "ent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style pa" & _
            "rent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style" & _
            " parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSpli" & _
            "ts>1</horzSplits><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelW" & _
            "idth></Blob>"
            '
            'Label7
            '
            Me.Label7.BackColor = System.Drawing.Color.Transparent
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.Black
            Me.Label7.Location = New System.Drawing.Point(16, 18)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(113, 16)
            Me.Label7.TabIndex = 127
            Me.Label7.Text = "Customer:"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Black
            Me.Label1.Location = New System.Drawing.Point(496, 18)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(113, 16)
            Me.Label1.TabIndex = 128
            Me.Label1.Text = "Claim #: "
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtSearchVal
            '
            Me.txtSearchVal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtSearchVal.Location = New System.Drawing.Point(616, 16)
            Me.txtSearchVal.Name = "txtSearchVal"
            Me.txtSearchVal.Size = New System.Drawing.Size(344, 21)
            Me.txtSearchVal.TabIndex = 1
            Me.txtSearchVal.Text = ""
            '
            'dbgSearchResult
            '
            Me.dbgSearchResult.AllowUpdate = False
            Me.dbgSearchResult.AlternatingRows = True
            Me.dbgSearchResult.CaptionHeight = 17
            Me.dbgSearchResult.FilterBar = True
            Me.dbgSearchResult.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dbgSearchResult.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgSearchResult.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.dbgSearchResult.Location = New System.Drawing.Point(16, 48)
            Me.dbgSearchResult.Name = "dbgSearchResult"
            Me.dbgSearchResult.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgSearchResult.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgSearchResult.PreviewInfo.ZoomFactor = 75
            Me.dbgSearchResult.RowHeight = 15
            Me.dbgSearchResult.Size = New System.Drawing.Size(1072, 176)
            Me.dbgSearchResult.TabIndex = 2
            Me.dbgSearchResult.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Normal{Font:Tahoma, 8.25pt;BackColor:SteelBlu" & _
            "e;}Selected{ForeColor:HighlightText;BackColor:Highlight;}Editor{}Style18{}Style1" & _
            "9{}Style14{}Style15{}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{B" & _
            "ackColor:LightSteelBlue;}Style13{}Style12{}HighlightRow{ForeColor:HighlightText;" & _
            "BackColor:Highlight;}RecordSelector{AlignImage:Center;}Footer{}Style21{}Style20{" & _
            "}Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}EvenRow{BackC" & _
            "olor:NavajoWhite;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;" & _
            "ForeColor:ControlText;AlignVert:Center;}FilterBar{Font:Microsoft Sans Serif, 9.7" & _
            "5pt, style=Bold;ForeColor:Red;BackColor:White;}Style4{}Style9{}Style8{}Style5{}G" & _
            "roup{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style7{}Sty" & _
            "le6{}Style1{}Style3{}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeV" & _
            "iew Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""1" & _
            "7"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" Reco" & _
            "rdSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrol" & _
            "lGroup=""1""><Height>172</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><Edi" & _
            "torStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8" & _
            """ /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Foote" & _
            "r"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=" & _
            """Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><" & _
            "InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""S" & _
            "tyle9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedSt" & _
            "yle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><Client" & _
            "Rect>0, 0, 1068, 172</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</" & _
            "BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent=" & _
            """"" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" m" & _
            "e=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""" & _
            "Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Ed" & _
            "itor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""Ev" & _
            "enRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""Record" & _
            "Selector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""" & _
            "Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layo" & _
            "ut>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 106" & _
            "8, 172</ClientArea><PrintPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFoot" & _
            "erStyle parent="""" me=""Style21"" /></Blob>"
            '
            'GroupBox1
            '
            Me.GroupBox1.BackColor = System.Drawing.Color.Gainsboro
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblQuoteApprovedBy, Me.Label5, Me.dbgTechFailureCodes, Me.dbgPartService, Me.dbgPartNeeds, Me.lblQuoteApprovedStatus, Me.Label6, Me.lblTechHrs, Me.Label11, Me.lblExceptionRepApprovedBy, Me.Label10, Me.lblExceptionRep, Me.Label8, Me.lblTechNotes, Me.Label29, Me.lblEDIErr, Me.Label27, Me.lblEDIDef2, Me.Label28, Me.lblEDIDef1, Me.Label26})
            Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox1.ForeColor = System.Drawing.Color.Black
            Me.GroupBox1.Location = New System.Drawing.Point(16, 344)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(1072, 376)
            Me.GroupBox1.TabIndex = 130
            Me.GroupBox1.TabStop = False
            '
            'lblQuoteApprovedBy
            '
            Me.lblQuoteApprovedBy.BackColor = System.Drawing.Color.White
            Me.lblQuoteApprovedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblQuoteApprovedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblQuoteApprovedBy.ForeColor = System.Drawing.Color.Black
            Me.lblQuoteApprovedBy.Location = New System.Drawing.Point(384, 88)
            Me.lblQuoteApprovedBy.Name = "lblQuoteApprovedBy"
            Me.lblQuoteApprovedBy.Size = New System.Drawing.Size(176, 16)
            Me.lblQuoteApprovedBy.TabIndex = 202
            Me.lblQuoteApprovedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label5
            '
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.Black
            Me.Label5.Location = New System.Drawing.Point(264, 88)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(112, 16)
            Me.Label5.TabIndex = 201
            Me.Label5.Text = "Quote Approved By"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dbgTechFailureCodes
            '
            Me.dbgTechFailureCodes.AllowUpdate = False
            Me.dbgTechFailureCodes.AlternatingRows = True
            Me.dbgTechFailureCodes.Caption = "Tech Failure Codes"
            Me.dbgTechFailureCodes.CaptionHeight = 17
            Me.dbgTechFailureCodes.FilterBar = True
            Me.dbgTechFailureCodes.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dbgTechFailureCodes.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgTechFailureCodes.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.dbgTechFailureCodes.Location = New System.Drawing.Point(784, 144)
            Me.dbgTechFailureCodes.Name = "dbgTechFailureCodes"
            Me.dbgTechFailureCodes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgTechFailureCodes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgTechFailureCodes.PreviewInfo.ZoomFactor = 75
            Me.dbgTechFailureCodes.RowHeight = 15
            Me.dbgTechFailureCodes.Size = New System.Drawing.Size(272, 216)
            Me.dbgTechFailureCodes.TabIndex = 200
            Me.dbgTechFailureCodes.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Normal{Font:Tahoma, 8.25pt;BackColor:SteelBlu" & _
            "e;}Selected{ForeColor:HighlightText;BackColor:Highlight;}Editor{}Style18{}Style1" & _
            "9{}Style14{}Style15{}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{B" & _
            "ackColor:LightSteelBlue;}Style13{}Style12{}HighlightRow{ForeColor:HighlightText;" & _
            "BackColor:Highlight;}RecordSelector{AlignImage:Center;}Footer{}Style21{}Style20{" & _
            "}Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}EvenRow{BackC" & _
            "olor:NavajoWhite;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;" & _
            "ForeColor:ControlText;AlignVert:Center;}FilterBar{Font:Microsoft Sans Serif, 9.7" & _
            "5pt, style=Bold;ForeColor:Red;BackColor:White;}Style4{}Style9{}Style8{}Style5{}G" & _
            "roup{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style7{}Sty" & _
            "le6{}Style1{}Style3{}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeV" & _
            "iew Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""1" & _
            "7"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" Reco" & _
            "rdSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrol" & _
            "lGroup=""1""><Height>195</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><Edi" & _
            "torStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8" & _
            """ /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Foote" & _
            "r"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=" & _
            """Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><" & _
            "InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""S" & _
            "tyle9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedSt" & _
            "yle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><Client" & _
            "Rect>0, 17, 268, 195</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</" & _
            "BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent=" & _
            """"" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" m" & _
            "e=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""" & _
            "Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Ed" & _
            "itor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""Ev" & _
            "enRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""Record" & _
            "Selector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""" & _
            "Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layo" & _
            "ut>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 268" & _
            ", 212</ClientArea><PrintPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFoote" & _
            "rStyle parent="""" me=""Style21"" /></Blob>"
            '
            'dbgPartService
            '
            Me.dbgPartService.AllowUpdate = False
            Me.dbgPartService.AlternatingRows = True
            Me.dbgPartService.Caption = "Part/Service"
            Me.dbgPartService.CaptionHeight = 17
            Me.dbgPartService.FilterBar = True
            Me.dbgPartService.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dbgPartService.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgPartService.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.dbgPartService.Location = New System.Drawing.Point(400, 144)
            Me.dbgPartService.Name = "dbgPartService"
            Me.dbgPartService.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgPartService.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgPartService.PreviewInfo.ZoomFactor = 75
            Me.dbgPartService.RowHeight = 15
            Me.dbgPartService.Size = New System.Drawing.Size(368, 216)
            Me.dbgPartService.TabIndex = 199
            Me.dbgPartService.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Normal{Font:Tahoma, 8.25pt;BackColor:SteelBlu" & _
            "e;}Selected{ForeColor:HighlightText;BackColor:Highlight;}Editor{}Style18{}Style1" & _
            "9{}Style14{}Style15{}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{B" & _
            "ackColor:LightSteelBlue;}Style13{}Style12{}HighlightRow{ForeColor:HighlightText;" & _
            "BackColor:Highlight;}RecordSelector{AlignImage:Center;}Footer{}Style21{}Style20{" & _
            "}Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}EvenRow{BackC" & _
            "olor:NavajoWhite;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;" & _
            "ForeColor:ControlText;AlignVert:Center;}FilterBar{Font:Microsoft Sans Serif, 9.7" & _
            "5pt, style=Bold;ForeColor:Red;BackColor:White;}Style4{}Style9{}Style8{}Style5{}G" & _
            "roup{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style7{}Sty" & _
            "le6{}Style1{}Style3{}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeV" & _
            "iew Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""1" & _
            "7"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" Reco" & _
            "rdSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrol" & _
            "lGroup=""1""><Height>195</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><Edi" & _
            "torStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8" & _
            """ /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Foote" & _
            "r"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=" & _
            """Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><" & _
            "InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""S" & _
            "tyle9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedSt" & _
            "yle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><Client" & _
            "Rect>0, 17, 364, 195</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</" & _
            "BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent=" & _
            """"" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" m" & _
            "e=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""" & _
            "Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Ed" & _
            "itor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""Ev" & _
            "enRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""Record" & _
            "Selector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""" & _
            "Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layo" & _
            "ut>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 364" & _
            ", 212</ClientArea><PrintPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFoote" & _
            "rStyle parent="""" me=""Style21"" /></Blob>"
            '
            'dbgPartNeeds
            '
            Me.dbgPartNeeds.AllowUpdate = False
            Me.dbgPartNeeds.AlternatingRows = True
            Me.dbgPartNeeds.Caption = "Part Needs"
            Me.dbgPartNeeds.CaptionHeight = 17
            Me.dbgPartNeeds.FilterBar = True
            Me.dbgPartNeeds.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dbgPartNeeds.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgPartNeeds.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.dbgPartNeeds.Location = New System.Drawing.Point(8, 144)
            Me.dbgPartNeeds.Name = "dbgPartNeeds"
            Me.dbgPartNeeds.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgPartNeeds.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgPartNeeds.PreviewInfo.ZoomFactor = 75
            Me.dbgPartNeeds.RowHeight = 15
            Me.dbgPartNeeds.Size = New System.Drawing.Size(376, 216)
            Me.dbgPartNeeds.TabIndex = 198
            Me.dbgPartNeeds.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Normal{Font:Tahoma, 8.25pt;BackColor:SteelBlu" & _
            "e;}Selected{ForeColor:HighlightText;BackColor:Highlight;}Editor{}Style18{}Style1" & _
            "9{}Style14{}Style15{}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{B" & _
            "ackColor:LightSteelBlue;}Style13{}Style12{}HighlightRow{ForeColor:HighlightText;" & _
            "BackColor:Highlight;}RecordSelector{AlignImage:Center;}Footer{}Style21{}Style20{" & _
            "}Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}EvenRow{BackC" & _
            "olor:NavajoWhite;}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;F" & _
            "oreColor:ControlText;BackColor:Control;}FilterBar{Font:Microsoft Sans Serif, 9.7" & _
            "5pt, style=Bold;ForeColor:Red;BackColor:White;}Style4{}Style9{}Style8{}Style5{}G" & _
            "roup{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style7{}Sty" & _
            "le6{}Style1{}Style3{}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeV" & _
            "iew Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""1" & _
            "7"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" Reco" & _
            "rdSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrol" & _
            "lGroup=""1""><Height>195</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><Edi" & _
            "torStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8" & _
            """ /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Foote" & _
            "r"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=" & _
            """Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><" & _
            "InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""S" & _
            "tyle9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedSt" & _
            "yle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><Client" & _
            "Rect>0, 17, 372, 195</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</" & _
            "BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent=" & _
            """"" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" m" & _
            "e=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""" & _
            "Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Ed" & _
            "itor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""Ev" & _
            "enRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""Record" & _
            "Selector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""" & _
            "Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layo" & _
            "ut>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 372" & _
            ", 212</ClientArea><PrintPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFoote" & _
            "rStyle parent="""" me=""Style21"" /></Blob>"
            '
            'lblQuoteApprovedStatus
            '
            Me.lblQuoteApprovedStatus.BackColor = System.Drawing.Color.White
            Me.lblQuoteApprovedStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblQuoteApprovedStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblQuoteApprovedStatus.ForeColor = System.Drawing.Color.Black
            Me.lblQuoteApprovedStatus.Location = New System.Drawing.Point(384, 112)
            Me.lblQuoteApprovedStatus.Name = "lblQuoteApprovedStatus"
            Me.lblQuoteApprovedStatus.Size = New System.Drawing.Size(176, 16)
            Me.lblQuoteApprovedStatus.TabIndex = 197
            Me.lblQuoteApprovedStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label6
            '
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.Black
            Me.Label6.Location = New System.Drawing.Point(224, 112)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(152, 16)
            Me.Label6.TabIndex = 196
            Me.Label6.Text = "Quote Approved Status:"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblTechHrs
            '
            Me.lblTechHrs.BackColor = System.Drawing.Color.White
            Me.lblTechHrs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblTechHrs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTechHrs.ForeColor = System.Drawing.Color.Black
            Me.lblTechHrs.Location = New System.Drawing.Point(144, 88)
            Me.lblTechHrs.Name = "lblTechHrs"
            Me.lblTechHrs.Size = New System.Drawing.Size(40, 16)
            Me.lblTechHrs.TabIndex = 195
            Me.lblTechHrs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label11
            '
            Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.ForeColor = System.Drawing.Color.Black
            Me.Label11.Location = New System.Drawing.Point(32, 88)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(104, 16)
            Me.Label11.TabIndex = 194
            Me.Label11.Text = "Tech Hrs :"
            Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblExceptionRepApprovedBy
            '
            Me.lblExceptionRepApprovedBy.BackColor = System.Drawing.Color.White
            Me.lblExceptionRepApprovedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblExceptionRepApprovedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblExceptionRepApprovedBy.ForeColor = System.Drawing.Color.Black
            Me.lblExceptionRepApprovedBy.Location = New System.Drawing.Point(384, 64)
            Me.lblExceptionRepApprovedBy.Name = "lblExceptionRepApprovedBy"
            Me.lblExceptionRepApprovedBy.Size = New System.Drawing.Size(176, 16)
            Me.lblExceptionRepApprovedBy.TabIndex = 193
            Me.lblExceptionRepApprovedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label10
            '
            Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.Black
            Me.Label10.Location = New System.Drawing.Point(208, 64)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(168, 16)
            Me.Label10.TabIndex = 192
            Me.Label10.Text = "Exception Rep Approved By:"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblExceptionRep
            '
            Me.lblExceptionRep.BackColor = System.Drawing.Color.White
            Me.lblExceptionRep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblExceptionRep.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblExceptionRep.ForeColor = System.Drawing.Color.Black
            Me.lblExceptionRep.Location = New System.Drawing.Point(144, 64)
            Me.lblExceptionRep.Name = "lblExceptionRep"
            Me.lblExceptionRep.Size = New System.Drawing.Size(40, 16)
            Me.lblExceptionRep.TabIndex = 191
            Me.lblExceptionRep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label8
            '
            Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.Black
            Me.Label8.Location = New System.Drawing.Point(32, 64)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(104, 16)
            Me.Label8.TabIndex = 190
            Me.Label8.Text = "Exception Rep :"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblTechNotes
            '
            Me.lblTechNotes.BackColor = System.Drawing.Color.White
            Me.lblTechNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblTechNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTechNotes.ForeColor = System.Drawing.Color.Black
            Me.lblTechNotes.Location = New System.Drawing.Point(672, 64)
            Me.lblTechNotes.Name = "lblTechNotes"
            Me.lblTechNotes.Size = New System.Drawing.Size(384, 64)
            Me.lblTechNotes.TabIndex = 189
            Me.lblTechNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label29
            '
            Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label29.ForeColor = System.Drawing.Color.Black
            Me.Label29.Location = New System.Drawing.Point(568, 72)
            Me.Label29.Name = "Label29"
            Me.Label29.Size = New System.Drawing.Size(96, 16)
            Me.Label29.TabIndex = 188
            Me.Label29.Text = "Tech Notes :"
            Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblEDIErr
            '
            Me.lblEDIErr.BackColor = System.Drawing.Color.White
            Me.lblEDIErr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblEDIErr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblEDIErr.ForeColor = System.Drawing.Color.Black
            Me.lblEDIErr.Location = New System.Drawing.Point(672, 16)
            Me.lblEDIErr.Name = "lblEDIErr"
            Me.lblEDIErr.Size = New System.Drawing.Size(384, 40)
            Me.lblEDIErr.TabIndex = 187
            Me.lblEDIErr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label27
            '
            Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label27.ForeColor = System.Drawing.Color.Black
            Me.Label27.Location = New System.Drawing.Point(568, 24)
            Me.Label27.Name = "Label27"
            Me.Label27.Size = New System.Drawing.Size(96, 16)
            Me.Label27.TabIndex = 186
            Me.Label27.Text = "Error :"
            Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblEDIDef2
            '
            Me.lblEDIDef2.BackColor = System.Drawing.Color.White
            Me.lblEDIDef2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblEDIDef2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblEDIDef2.ForeColor = System.Drawing.Color.Black
            Me.lblEDIDef2.Location = New System.Drawing.Point(144, 40)
            Me.lblEDIDef2.Name = "lblEDIDef2"
            Me.lblEDIDef2.Size = New System.Drawing.Size(416, 16)
            Me.lblEDIDef2.TabIndex = 185
            Me.lblEDIDef2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label28
            '
            Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label28.ForeColor = System.Drawing.Color.Black
            Me.Label28.Location = New System.Drawing.Point(40, 40)
            Me.Label28.Name = "Label28"
            Me.Label28.Size = New System.Drawing.Size(96, 16)
            Me.Label28.TabIndex = 184
            Me.Label28.Text = "Defective 2 :"
            Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblEDIDef1
            '
            Me.lblEDIDef1.BackColor = System.Drawing.Color.White
            Me.lblEDIDef1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblEDIDef1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblEDIDef1.ForeColor = System.Drawing.Color.Black
            Me.lblEDIDef1.Location = New System.Drawing.Point(144, 16)
            Me.lblEDIDef1.Name = "lblEDIDef1"
            Me.lblEDIDef1.Size = New System.Drawing.Size(416, 16)
            Me.lblEDIDef1.TabIndex = 183
            Me.lblEDIDef1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label26
            '
            Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label26.ForeColor = System.Drawing.Color.Black
            Me.Label26.Location = New System.Drawing.Point(40, 16)
            Me.Label26.Name = "Label26"
            Me.Label26.Size = New System.Drawing.Size(96, 16)
            Me.Label26.TabIndex = 182
            Me.Label26.Text = "Defective 1 :"
            Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblUnitRecTrackNo
            '
            Me.lblUnitRecTrackNo.BackColor = System.Drawing.Color.White
            Me.lblUnitRecTrackNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblUnitRecTrackNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblUnitRecTrackNo.ForeColor = System.Drawing.Color.Black
            Me.lblUnitRecTrackNo.Location = New System.Drawing.Point(344, 40)
            Me.lblUnitRecTrackNo.Name = "lblUnitRecTrackNo"
            Me.lblUnitRecTrackNo.Size = New System.Drawing.Size(208, 16)
            Me.lblUnitRecTrackNo.TabIndex = 181
            Me.lblUnitRecTrackNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblEmptyBoxToCustTrackNo
            '
            Me.lblEmptyBoxToCustTrackNo.BackColor = System.Drawing.Color.White
            Me.lblEmptyBoxToCustTrackNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblEmptyBoxToCustTrackNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblEmptyBoxToCustTrackNo.ForeColor = System.Drawing.Color.Black
            Me.lblEmptyBoxToCustTrackNo.Location = New System.Drawing.Point(344, 16)
            Me.lblEmptyBoxToCustTrackNo.Name = "lblEmptyBoxToCustTrackNo"
            Me.lblEmptyBoxToCustTrackNo.Size = New System.Drawing.Size(208, 16)
            Me.lblEmptyBoxToCustTrackNo.TabIndex = 180
            Me.lblEmptyBoxToCustTrackNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblReceivedSN
            '
            Me.lblReceivedSN.BackColor = System.Drawing.Color.White
            Me.lblReceivedSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblReceivedSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblReceivedSN.ForeColor = System.Drawing.Color.Black
            Me.lblReceivedSN.Location = New System.Drawing.Point(656, 40)
            Me.lblReceivedSN.Name = "lblReceivedSN"
            Me.lblReceivedSN.Size = New System.Drawing.Size(208, 16)
            Me.lblReceivedSN.TabIndex = 179
            Me.lblReceivedSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label12
            '
            Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label12.ForeColor = System.Drawing.Color.Black
            Me.Label12.Location = New System.Drawing.Point(208, 40)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(128, 16)
            Me.Label12.TabIndex = 177
            Me.Label12.Text = "Unit Receive Track # :"
            Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label13
            '
            Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label13.ForeColor = System.Drawing.Color.Black
            Me.Label13.Location = New System.Drawing.Point(208, 16)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(128, 16)
            Me.Label13.TabIndex = 176
            Me.Label13.Text = "Empty Box Track # :"
            Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label14
            '
            Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label14.ForeColor = System.Drawing.Color.Black
            Me.Label14.Location = New System.Drawing.Point(560, 40)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(88, 16)
            Me.Label14.TabIndex = 175
            Me.Label14.Text = "Received S/N :"
            Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'GroupBox2
            '
            Me.GroupBox2.BackColor = System.Drawing.Color.Gainsboro
            Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblEdiSN, Me.Label16, Me.Label4, Me.lblPssWrtyApprovedStatus, Me.lblPssWrty, Me.Label9, Me.Label3, Me.lblWorkStation, Me.Label2, Me.lblPssStatus, Me.lblShippingBoxName, Me.Label24, Me.lblUnitShipTrackNo, Me.Label23, Me.lblUnitShipDate, Me.Label22, Me.lblUnitReceiptDate, Me.Label17, Me.lblEmptyBoxShipDate, Me.lblClaimReceiptDate, Me.Label20, Me.Label21, Me.lblUnitRecTrackNo, Me.lblEmptyBoxToCustTrackNo, Me.Label12, Me.Label13, Me.lblReceivedSN, Me.Label14, Me.Label25, Me.lblPssWrtyApproveBy})
            Me.GroupBox2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox2.ForeColor = System.Drawing.Color.Black
            Me.GroupBox2.Location = New System.Drawing.Point(16, 232)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(1072, 112)
            Me.GroupBox2.TabIndex = 187
            Me.GroupBox2.TabStop = False
            '
            'Label4
            '
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.Black
            Me.Label4.Location = New System.Drawing.Point(888, 40)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(152, 16)
            Me.Label4.TabIndex = 196
            Me.Label4.Text = "PSS Wrty Approved Status "
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblPssWrtyApprovedStatus
            '
            Me.lblPssWrtyApprovedStatus.BackColor = System.Drawing.Color.White
            Me.lblPssWrtyApprovedStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblPssWrtyApprovedStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPssWrtyApprovedStatus.ForeColor = System.Drawing.Color.Black
            Me.lblPssWrtyApprovedStatus.Location = New System.Drawing.Point(888, 56)
            Me.lblPssWrtyApprovedStatus.Name = "lblPssWrtyApprovedStatus"
            Me.lblPssWrtyApprovedStatus.Size = New System.Drawing.Size(168, 16)
            Me.lblPssWrtyApprovedStatus.TabIndex = 197
            Me.lblPssWrtyApprovedStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblPssWrty
            '
            Me.lblPssWrty.BackColor = System.Drawing.Color.White
            Me.lblPssWrty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblPssWrty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPssWrty.ForeColor = System.Drawing.Color.Black
            Me.lblPssWrty.Location = New System.Drawing.Point(976, 16)
            Me.lblPssWrty.Name = "lblPssWrty"
            Me.lblPssWrty.Size = New System.Drawing.Size(80, 16)
            Me.lblPssWrty.TabIndex = 195
            Me.lblPssWrty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label9
            '
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.Black
            Me.Label9.Location = New System.Drawing.Point(888, 16)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(88, 16)
            Me.Label9.TabIndex = 194
            Me.Label9.Text = "PSS Warranty :"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.Black
            Me.Label3.Location = New System.Drawing.Point(568, 88)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(80, 16)
            Me.Label3.TabIndex = 192
            Me.Label3.Text = "Work Station"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblWorkStation
            '
            Me.lblWorkStation.BackColor = System.Drawing.Color.White
            Me.lblWorkStation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblWorkStation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWorkStation.ForeColor = System.Drawing.Color.Black
            Me.lblWorkStation.Location = New System.Drawing.Point(656, 88)
            Me.lblWorkStation.Name = "lblWorkStation"
            Me.lblWorkStation.Size = New System.Drawing.Size(208, 16)
            Me.lblWorkStation.TabIndex = 193
            Me.lblWorkStation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.Black
            Me.Label2.Location = New System.Drawing.Point(568, 64)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(80, 16)
            Me.Label2.TabIndex = 190
            Me.Label2.Text = "PSS Status :"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblPssStatus
            '
            Me.lblPssStatus.BackColor = System.Drawing.Color.White
            Me.lblPssStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblPssStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPssStatus.ForeColor = System.Drawing.Color.Black
            Me.lblPssStatus.Location = New System.Drawing.Point(656, 64)
            Me.lblPssStatus.Name = "lblPssStatus"
            Me.lblPssStatus.Size = New System.Drawing.Size(208, 16)
            Me.lblPssStatus.TabIndex = 191
            Me.lblPssStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblShippingBoxName
            '
            Me.lblShippingBoxName.BackColor = System.Drawing.Color.White
            Me.lblShippingBoxName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblShippingBoxName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblShippingBoxName.ForeColor = System.Drawing.Color.Black
            Me.lblShippingBoxName.Location = New System.Drawing.Point(344, 88)
            Me.lblShippingBoxName.Name = "lblShippingBoxName"
            Me.lblShippingBoxName.Size = New System.Drawing.Size(208, 16)
            Me.lblShippingBoxName.TabIndex = 189
            Me.lblShippingBoxName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label24
            '
            Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label24.ForeColor = System.Drawing.Color.Black
            Me.Label24.Location = New System.Drawing.Point(208, 88)
            Me.Label24.Name = "Label24"
            Me.Label24.Size = New System.Drawing.Size(128, 16)
            Me.Label24.TabIndex = 188
            Me.Label24.Text = "Outbound Box Name :"
            Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblUnitShipTrackNo
            '
            Me.lblUnitShipTrackNo.BackColor = System.Drawing.Color.White
            Me.lblUnitShipTrackNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblUnitShipTrackNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblUnitShipTrackNo.ForeColor = System.Drawing.Color.Black
            Me.lblUnitShipTrackNo.Location = New System.Drawing.Point(344, 64)
            Me.lblUnitShipTrackNo.Name = "lblUnitShipTrackNo"
            Me.lblUnitShipTrackNo.Size = New System.Drawing.Size(208, 16)
            Me.lblUnitShipTrackNo.TabIndex = 187
            Me.lblUnitShipTrackNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label23
            '
            Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label23.ForeColor = System.Drawing.Color.Black
            Me.Label23.Location = New System.Drawing.Point(208, 64)
            Me.Label23.Name = "Label23"
            Me.Label23.Size = New System.Drawing.Size(128, 16)
            Me.Label23.TabIndex = 186
            Me.Label23.Text = "Unit Ship Track # :"
            Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblUnitShipDate
            '
            Me.lblUnitShipDate.BackColor = System.Drawing.Color.White
            Me.lblUnitShipDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblUnitShipDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblUnitShipDate.ForeColor = System.Drawing.Color.Black
            Me.lblUnitShipDate.Location = New System.Drawing.Point(136, 88)
            Me.lblUnitShipDate.Name = "lblUnitShipDate"
            Me.lblUnitShipDate.Size = New System.Drawing.Size(72, 16)
            Me.lblUnitShipDate.TabIndex = 185
            Me.lblUnitShipDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label22
            '
            Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label22.ForeColor = System.Drawing.Color.Black
            Me.Label22.Location = New System.Drawing.Point(40, 88)
            Me.Label22.Name = "Label22"
            Me.Label22.Size = New System.Drawing.Size(88, 16)
            Me.Label22.TabIndex = 184
            Me.Label22.Text = "Unit Ship Date:"
            Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblUnitReceiptDate
            '
            Me.lblUnitReceiptDate.BackColor = System.Drawing.Color.White
            Me.lblUnitReceiptDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblUnitReceiptDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblUnitReceiptDate.ForeColor = System.Drawing.Color.Black
            Me.lblUnitReceiptDate.Location = New System.Drawing.Point(136, 64)
            Me.lblUnitReceiptDate.Name = "lblUnitReceiptDate"
            Me.lblUnitReceiptDate.Size = New System.Drawing.Size(72, 16)
            Me.lblUnitReceiptDate.TabIndex = 183
            Me.lblUnitReceiptDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label17
            '
            Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label17.ForeColor = System.Drawing.Color.Black
            Me.Label17.Location = New System.Drawing.Point(24, 64)
            Me.Label17.Name = "Label17"
            Me.Label17.Size = New System.Drawing.Size(104, 16)
            Me.Label17.TabIndex = 182
            Me.Label17.Text = "Unit Receipt Date:"
            Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblEmptyBoxShipDate
            '
            Me.lblEmptyBoxShipDate.BackColor = System.Drawing.Color.White
            Me.lblEmptyBoxShipDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblEmptyBoxShipDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblEmptyBoxShipDate.ForeColor = System.Drawing.Color.Black
            Me.lblEmptyBoxShipDate.Location = New System.Drawing.Point(136, 40)
            Me.lblEmptyBoxShipDate.Name = "lblEmptyBoxShipDate"
            Me.lblEmptyBoxShipDate.Size = New System.Drawing.Size(72, 16)
            Me.lblEmptyBoxShipDate.TabIndex = 180
            Me.lblEmptyBoxShipDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblClaimReceiptDate
            '
            Me.lblClaimReceiptDate.BackColor = System.Drawing.Color.White
            Me.lblClaimReceiptDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblClaimReceiptDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblClaimReceiptDate.ForeColor = System.Drawing.Color.Black
            Me.lblClaimReceiptDate.Location = New System.Drawing.Point(136, 16)
            Me.lblClaimReceiptDate.Name = "lblClaimReceiptDate"
            Me.lblClaimReceiptDate.Size = New System.Drawing.Size(72, 16)
            Me.lblClaimReceiptDate.TabIndex = 179
            Me.lblClaimReceiptDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label20
            '
            Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label20.ForeColor = System.Drawing.Color.Black
            Me.Label20.Location = New System.Drawing.Point(0, 40)
            Me.Label20.Name = "Label20"
            Me.Label20.Size = New System.Drawing.Size(128, 16)
            Me.Label20.TabIndex = 176
            Me.Label20.Text = "Empty Box Ship Date:"
            Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label21
            '
            Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label21.ForeColor = System.Drawing.Color.Black
            Me.Label21.Location = New System.Drawing.Point(8, 16)
            Me.Label21.Name = "Label21"
            Me.Label21.Size = New System.Drawing.Size(120, 16)
            Me.Label21.TabIndex = 175
            Me.Label21.Text = "Claim Receipt Date:"
            Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label25
            '
            Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label25.ForeColor = System.Drawing.Color.Black
            Me.Label25.Location = New System.Drawing.Point(888, 72)
            Me.Label25.Name = "Label25"
            Me.Label25.Size = New System.Drawing.Size(136, 16)
            Me.Label25.TabIndex = 180
            Me.Label25.Text = "PSS Wrty Approved By "
            Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblPssWrtyApproveBy
            '
            Me.lblPssWrtyApproveBy.BackColor = System.Drawing.Color.White
            Me.lblPssWrtyApproveBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblPssWrtyApproveBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPssWrtyApproveBy.ForeColor = System.Drawing.Color.Black
            Me.lblPssWrtyApproveBy.Location = New System.Drawing.Point(888, 88)
            Me.lblPssWrtyApproveBy.Name = "lblPssWrtyApproveBy"
            Me.lblPssWrtyApproveBy.Size = New System.Drawing.Size(168, 16)
            Me.lblPssWrtyApproveBy.TabIndex = 181
            Me.lblPssWrtyApproveBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnSearch
            '
            Me.btnSearch.BackColor = System.Drawing.Color.Gainsboro
            Me.btnSearch.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSearch.ForeColor = System.Drawing.SystemColors.ControlText
            Me.btnSearch.Location = New System.Drawing.Point(976, 13)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.Size = New System.Drawing.Size(112, 23)
            Me.btnSearch.TabIndex = 2
            Me.btnSearch.Text = "Search"
            '
            'lblEdiSN
            '
            Me.lblEdiSN.BackColor = System.Drawing.Color.White
            Me.lblEdiSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblEdiSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblEdiSN.ForeColor = System.Drawing.Color.Black
            Me.lblEdiSN.Location = New System.Drawing.Point(656, 16)
            Me.lblEdiSN.Name = "lblEdiSN"
            Me.lblEdiSN.Size = New System.Drawing.Size(208, 16)
            Me.lblEdiSN.TabIndex = 199
            Me.lblEdiSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label16
            '
            Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label16.ForeColor = System.Drawing.Color.Black
            Me.Label16.Location = New System.Drawing.Point(560, 16)
            Me.Label16.Name = "Label16"
            Me.Label16.Size = New System.Drawing.Size(88, 16)
            Me.Label16.TabIndex = 198
            Me.Label16.Text = "EDI S/N :"
            Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'frmSearch
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(1112, 742)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnSearch, Me.GroupBox2, Me.GroupBox1, Me.dbgSearchResult, Me.txtSearchVal, Me.Label1, Me.cboCustomers, Me.Label7})
            Me.Name = "frmSearch"
            Me.Text = "frmSearch"
            CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dbgSearchResult, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox1.ResumeLayout(False)
            CType(Me.dbgTechFailureCodes, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dbgPartService, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dbgPartNeeds, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox2.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        '****************************************************************************************************      
        Private Sub frmSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable
            Try
                PSS.Core.Highlight.SetHighLight(Me)
                dt = Data.Buisness.Generic.GetCustomers(True, )
                Misc.PopulateC1DropDownList(Me.cboCustomers, dt, "Cust_Name1", "Cust_ID")
                Me.cboCustomers.SelectedValue = _iMenuCustID
                If _iMenuCustID > 0 Then Me.cboCustomers.Enabled = False

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '****************************************************************************************************
        Private Sub txtSearchVal_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchVal.KeyUp
            Try
                If e.KeyCode = Keys.Enter AndAlso Me.txtSearchVal.Text.Trim.Length > 0 Then Me.SearchClaimNo(Me.txtSearchVal.Text.Trim)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtSearchVal_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '****************************************************************************************************
        Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            Try
                If Me.txtSearchVal.Text.Trim.Length > 0 Then Me.SearchClaimNo(Me.txtSearchVal.Text.Trim)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnSearch_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '****************************************************************************************************
        Private Function SearchClaimNo(ByVal strClaimNo As String)
            Dim dt As DataTable
            Dim i As Integer = 0

            Try
                ClearControls()

                dt = Me._objAIG.GetSearchData(Me._iMenuCustID, strClaimNo)
                With Me.dbgSearchResult
                    .DataSource = Nothing
                    .DataSource = dt.DefaultView
                    For i = 0 To dt.Columns.Count - 1
                        Select Case dt.Columns(i).Caption
                            Case "Claim #", "Customer Name"
                                .Splits(0).DisplayColumns(i).Width = 150
                            Case "Customer Address"
                                .Splits(0).DisplayColumns(i).Width = 250
                            Case "Customer City"
                                .Splits(0).DisplayColumns(i).Width = 150
                            Case "State"
                                .Splits(0).DisplayColumns(i).Width = 40
                            Case "Phone #"
                                .Splits(0).DisplayColumns(i).Width = 50
                            Case "Email Addres"
                                .Splits(0).DisplayColumns(i).Width = 80
                            Case "Brand", "Model", "SerialNo"
                                .Splits(0).DisplayColumns(i).Width = 150
                            Case Else
                                .Splits(0).DisplayColumns(i).Visible = False
                        End Select
                    Next i
                End With
            Catch ex As Exception
                Throw ex
            Finally
                Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '****************************************************************************************************
        Private Sub dbgSearchResult_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles dbgSearchResult.RowColChange
            Dim iWOID, iDeviceID As Integer
            Dim dt As DataTable
            Dim objNewTech As Data.Buisness.NewTech

            Try
                Me.ClearControls()

                If Me.dbgSearchResult.Row >= 0 AndAlso Me.dbgSearchResult.Columns.Count > 0 Then
                    If Not IsDBNull(Me.dbgSearchResult.Columns("WO_ID").CellValue(Me.dbgSearchResult.Row)) Then iWOID = CInt(Me.dbgSearchResult.Columns("WO_ID").CellValue(Me.dbgSearchResult.Row))
                    If iWOID > 0 Then dt = Me._objAIG.GetDevicesInWorkorder(iWOID)

                    If Not IsNothing(dt) AndAlso dt.Rows.Count > 1 Then
                        MessageBox.Show("Claim contain multiple device. Please see IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    ElseIf Not IsNothing(dt) AndAlso dt.Rows.Count = 1 Then
                        'A.Device_Laborcharge, A.Device_PartCharge
                        iDeviceID = dt.Rows(0)("Device_ID")

                        Me.lblUnitReceiptDate.Text = Convert.ToDateTime(dt.Rows(0)("Device_DateRec")).ToString("MM/dd/yyyy")
                        If Not IsDBNull(dt.Rows(0)("Device_DateShip")) Then Me.lblUnitShipDate.Text = Convert.ToDateTime(dt.Rows(0)("Device_DateShip")).ToString("MM/dd/yyyy")
                        If Not IsDBNull(dt.Rows(0)("Pallett_Name")) Then Me.lblShippingBoxName.Text = dt.Rows(0)("Pallett_Name").ToString.Trim
                        If Not IsDBNull(dt.Rows(0)("SerialNo")) Then Me.lblEdiSN.Text = dt.Rows(0)("SerialNo").ToString.Trim

                        If dt.Rows(0)("Device_PSSWrty").ToString.Trim = "1" Then Me.lblPssWrty.Text = "Yes" Else Me.lblPssWrty.Text = "No"
                        If Not IsDBNull(dt.Rows(0)("user_fullname")) Then Me.lblPssWrtyApproveBy.Text = dt.Rows(0)("user_fullname").ToString
                        If Not IsDBNull(dt.Rows(0)("AV_Desc")) Then Me.lblPssWrtyApprovedStatus.Text = dt.Rows(0)("AV_Desc").ToString

                        Me.lblReceivedSN.Text = dt.Rows(0)("Device_SN")
                        If Not IsDBNull(dt.Rows(0)("WorkStation")) Then Me.lblWorkStation.Text = dt.Rows(0)("WorkStation").ToString

                        objNewTech = New Data.Buisness.NewTech()
                        Data.Buisness.Generic.DisposeDT(dt)
                        dt = objNewTech.GetTechNotesInfo(iDeviceID)
                        If dt.Rows.Count > 0 Then Me.lblTechNotes.Text = dt.Rows(0)("Notes").ToString

                        If Me._objAIG.HasExceptionRepairs(iDeviceID) Then Me.lblExceptionRep.Text = "Yes" Else Me.lblExceptionRep.Text = "No"

                        If Me.lblExceptionRep.Text = "Yes" Then
                            If Not IsDBNull(Me.dbgSearchResult.Columns("user_fullname").CellValue(Me.dbgSearchResult.Row)) Then Me.lblExceptionRepApprovedBy.Text = Me.dbgSearchResult.Columns("user_fullname").CellValue(Me.dbgSearchResult.Row)
                            Me.lblTechHrs.Text = Me.dbgSearchResult.Columns("EstimatedTechHrs").CellValue(Me.dbgSearchResult.Row)
                            Me.lblQuoteApprovedBy.Text = Me.dbgSearchResult.Columns("ApprovedBy").CellValue(Me.dbgSearchResult.Row)
                            If Not IsDBNull(Me.dbgSearchResult.Columns("AV_Desc").CellValue(Me.dbgSearchResult.Row)) Then Me.lblQuoteApprovedStatus.Text = Me.dbgSearchResult.Columns("AV_Desc").CellValue(Me.dbgSearchResult.Row)
                        End If

                        'Tech Failure Codes
                        Me.LoadTechFailure(iDeviceID)

                        'Consumed Part/Service
                        Me.LoadConsumedPartService(iDeviceID)
                    End If

                    'Part need
                    Me.LoadPartNeedGrid(iWOID)

                    If Not IsDBNull(Me.dbgSearchResult.Columns("LoadedDateTime").CellValue(Me.dbgSearchResult.Row)) Then Me.lblClaimReceiptDate.Text = Convert.ToDateTime(Me.dbgSearchResult.Columns("LoadedDateTime").CellValue(Me.dbgSearchResult.Row)).ToString("MM/dd/yyyy")
                    If Not IsDBNull(Me.dbgSearchResult.Columns("TrackCreatedDateTime").CellValue(Me.dbgSearchResult.Row)) Then Me.lblEmptyBoxShipDate.Text = Convert.ToDateTime(Me.dbgSearchResult.Columns("TrackCreatedDateTime").CellValue(Me.dbgSearchResult.Row)).ToString("MM/dd/yyyy")

                    If Not IsDBNull(Me.dbgSearchResult.Columns("PSSI2Cust_TrackNo").CellValue(Me.dbgSearchResult.Row)) Then Me.lblEmptyBoxToCustTrackNo.Text = Me.dbgSearchResult.Columns("PSSI2Cust_TrackNo").CellValue(Me.dbgSearchResult.Row).ToString.Trim
                    If Not IsDBNull(Me.dbgSearchResult.Columns("Cust2PSSI_TrackNo").CellValue(Me.dbgSearchResult.Row)) Then Me.lblUnitRecTrackNo.Text = Me.dbgSearchResult.Columns("Cust2PSSI_TrackNo").CellValue(Me.dbgSearchResult.Row).ToString.Trim
                    If Not IsDBNull(Me.dbgSearchResult.Columns("Final_PSSI2Cust_TrackNo").CellValue(Me.dbgSearchResult.Row)) Then Me.lblUnitShipTrackNo.Text = Me.dbgSearchResult.Columns("Final_PSSI2Cust_TrackNo").CellValue(Me.dbgSearchResult.Row)

                    If Not IsDBNull(Me.dbgSearchResult.Columns("PSSI_CurrentStatus").CellValue(Me.dbgSearchResult.Row)) Then Me.lblPssStatus.Text = Me.dbgSearchResult.Columns("PSSI_CurrentStatus").CellValue(Me.dbgSearchResult.Row)

                    If Not IsDBNull(Me.dbgSearchResult.Columns("DefectType1").CellValue(Me.dbgSearchResult.Row)) Then Me.lblEDIDef1.Text = Me.dbgSearchResult.Columns("DefectType1").CellValue(Me.dbgSearchResult.Row)
                    If Not IsDBNull(Me.dbgSearchResult.Columns("DefectType2").CellValue(Me.dbgSearchResult.Row)) Then Me.lblEDIDef2.Text = Me.dbgSearchResult.Columns("DefectType2").CellValue(Me.dbgSearchResult.Row)
                    If Not IsDBNull(Me.dbgSearchResult.Columns("ErrDesc_ItemSKU").CellValue(Me.dbgSearchResult.Row)) Then Me.lblEDIErr.Text = Me.dbgSearchResult.Columns("ErrDesc_ItemSKU").CellValue(Me.dbgSearchResult.Row)

                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgSearchResult_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                objNewTech = Nothing
                Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '****************************************************************************************************
        Public Sub LoadTechFailure(ByVal iDeviceID As Integer)
            Dim dt As DataTable
            Dim objNewTech As Data.Buisness.NewTech
            Dim i As Integer = 0

            Try
                objNewTech = New Data.Buisness.NewTech()
                dt = objNewTech.GetTechFailureResult(iDeviceID)
                dt.Columns("DCode_SLDesc").ColumnName = "Failure Code" : dt.AcceptChanges()
                With Me.dbgTechFailureCodes
                    .DataSource = dt.DefaultView
                    For i = 0 To dt.Columns.Count - 1
                        If dt.Columns(i).Caption = "Failure Code" Then 'DCode_SLDesc
                            .Splits(0).DisplayColumns(i).Visible = True
                        Else
                            .Splits(0).DisplayColumns(i).Visible = False
                        End If
                    Next i

                End With
            Catch ex As Exception
                Throw ex
            Finally
                objNewTech = Nothing : Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '****************************************************************************************************
        Public Sub LoadConsumedPartService(ByVal iDeviceID As Integer)
            Try
                With Me.dbgPartService
                    .DataSource = PSS.Rules.Search.GetParts(iDeviceID)
                    .Splits(0).DisplayColumns("Code").Visible = False
                End With
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '****************************************************************************************************
        Public Sub LoadPartNeedGrid(ByVal iWOID As Integer)
            Dim dt As DataTable

            Try
                dt = Me._objAIG.GetPartNeeds(iWOID)
                With Me.dbgPartNeeds
                    .DataSource = dt.DefaultView
                    .Splits(0).DisplayColumns("WO_ID").Visible = False
                    .Splits(0).DisplayColumns("PN_ID").Visible = False
                End With
            Catch ex As Exception
                Throw ex
            Finally
                Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '****************************************************************************************************
        Private Sub ClearControls()
            Try
                Me.lblClaimReceiptDate.Text = ""
                Me.lblEmptyBoxShipDate.Text = ""
                Me.lblUnitReceiptDate.Text = ""
                Me.lblUnitShipDate.Text = ""

                Me.lblEmptyBoxToCustTrackNo.Text = ""
                Me.lblUnitRecTrackNo.Text = ""
                Me.lblUnitShipTrackNo.Text = ""
                Me.lblShippingBoxName.Text = ""

                Me.lblReceivedSN.Text = ""
                Me.lblPssWrty.Text = ""
                lblPssWrtyApprovedStatus.Text = ""
                Me.lblPssWrtyApproveBy.Text = ""
                Me.lblPssStatus.Text = ""
                Me.lblWorkStation.Text = ""

                Me.lblEDIDef1.Text = ""
                Me.lblEDIDef2.Text = ""
                Me.lblEDIErr.Text = ""
                Me.lblTechNotes.Text = ""
                Me.lblExceptionRep.Text = ""
                Me.lblExceptionRepApprovedBy.Text = ""
                Me.lblTechHrs.Text = ""
                Me.lblQuoteApprovedBy.Text = ""
                Me.lblQuoteApprovedStatus.Text = ""

                Me.dbgPartNeeds.DataSource = Nothing
                Me.dbgPartService.DataSource = Nothing
                Me.dbgTechFailureCodes.DataSource = Nothing

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '****************************************************************************************************

    End Class
End Namespace