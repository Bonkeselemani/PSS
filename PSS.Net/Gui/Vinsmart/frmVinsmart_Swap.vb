Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text

Namespace Gui.Vinsmart
    Public Class frmVinsmart_Swap
        Inherits System.Windows.Forms.Form

        Private _iCust_ID As Integer = 0
        'Private _iLoc_ID As Integer = 0
        Private _strScreenName As String = ""
        Private _objVinsmart As PSS.Data.Buisness.Vinsmart.Vinsmart
        Private _objVinsmart_Swap As PSS.Data.Buisness.Vinsmart.Vinsmart_swap
        Private _dtBulk As DataTable
        Private _dtFinal As New DataTable()
        Private _iModel_ID As Integer = 0

        Private _iUserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
        Private _strUser As String = PSS.Core.Global.ApplicationUser.User

#Region " Windows Form Designer generated code "
        Public Sub New(ByVal strScreenName As String, ByVal iCust_ID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._iCust_ID = iCust_ID
            ' Me._iLoc_ID = iLoc_ID
            Me._strScreenName = strScreenName
            Me._objVinsmart = New PSS.Data.Buisness.Vinsmart.Vinsmart()
            Me._objVinsmart_Swap = New PSS.Data.Buisness.Vinsmart.Vinsmart_swap()

            'Me._objVinsmartPad_BoxShip = New PSS.Data.Buisness.CP.VinsmartPad_BoxShip()
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                Try
                    Me._objVinsmart = Nothing
                    Me._objVinsmart_Swap = Nothing
                    'Me._objVinsmartPad_BoxShip = Nothing
                Catch ex As Exception
                End Try
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
        Friend WithEvents cboCustomer As C1.Win.C1List.C1Combo
        Friend WithEvents lblLocation As System.Windows.Forms.Label
        Friend WithEvents cboLocation As C1.Win.C1List.C1Combo
        Friend WithEvents btnUnDoAllSNs As System.Windows.Forms.Button
        Friend WithEvents btnUndoOneSN As System.Windows.Forms.Button
        Friend WithEvents tdgData1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents txtSeedStockSN As System.Windows.Forms.TextBox
        Friend WithEvents lblSeedStockSN As System.Windows.Forms.Label
        Friend WithEvents txtSwappedSN As System.Windows.Forms.TextBox
        Friend WithEvents lblSwappedSN As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmVinsmart_Swap))
            Me.lblCustomer = New System.Windows.Forms.Label()
            Me.cboCustomer = New C1.Win.C1List.C1Combo()
            Me.lblLocation = New System.Windows.Forms.Label()
            Me.cboLocation = New C1.Win.C1List.C1Combo()
            Me.btnUnDoAllSNs = New System.Windows.Forms.Button()
            Me.btnUndoOneSN = New System.Windows.Forms.Button()
            Me.tdgData1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.txtSeedStockSN = New System.Windows.Forms.TextBox()
            Me.lblSeedStockSN = New System.Windows.Forms.Label()
            Me.txtSwappedSN = New System.Windows.Forms.TextBox()
            Me.lblSwappedSN = New System.Windows.Forms.Label()
            CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboLocation, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblCustomer
            '
            Me.lblCustomer.BackColor = System.Drawing.Color.Transparent
            Me.lblCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCustomer.ForeColor = System.Drawing.Color.Black
            Me.lblCustomer.Location = New System.Drawing.Point(52, 19)
            Me.lblCustomer.Name = "lblCustomer"
            Me.lblCustomer.Size = New System.Drawing.Size(72, 21)
            Me.lblCustomer.TabIndex = 181
            Me.lblCustomer.Text = "Customer:"
            Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboCustomer
            '
            Me.cboCustomer.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboCustomer.Caption = ""
            Me.cboCustomer.CaptionHeight = 17
            Me.cboCustomer.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboCustomer.ColumnCaptionHeight = 17
            Me.cboCustomer.ColumnFooterHeight = 17
            Me.cboCustomer.ContentHeight = 15
            Me.cboCustomer.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboCustomer.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboCustomer.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCustomer.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCustomer.EditorHeight = 15
            Me.cboCustomer.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboCustomer.ItemHeight = 15
            Me.cboCustomer.Location = New System.Drawing.Point(132, 19)
            Me.cboCustomer.MatchEntryTimeout = CType(2000, Long)
            Me.cboCustomer.MaxDropDownItems = CType(5, Short)
            Me.cboCustomer.MaxLength = 32767
            Me.cboCustomer.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCustomer.Name = "cboCustomer"
            Me.cboCustomer.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCustomer.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCustomer.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCustomer.Size = New System.Drawing.Size(240, 21)
            Me.cboCustomer.TabIndex = 180
            Me.cboCustomer.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            "aultRecSelWidth>17</DefaultRecSelWidth></Blob>"
            '
            'lblLocation
            '
            Me.lblLocation.BackColor = System.Drawing.Color.Transparent
            Me.lblLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLocation.ForeColor = System.Drawing.Color.Black
            Me.lblLocation.Location = New System.Drawing.Point(52, 51)
            Me.lblLocation.Name = "lblLocation"
            Me.lblLocation.Size = New System.Drawing.Size(72, 21)
            Me.lblLocation.TabIndex = 179
            Me.lblLocation.Text = "Location:"
            Me.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboLocation
            '
            Me.cboLocation.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboLocation.Caption = ""
            Me.cboLocation.CaptionHeight = 17
            Me.cboLocation.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboLocation.ColumnCaptionHeight = 17
            Me.cboLocation.ColumnFooterHeight = 17
            Me.cboLocation.ContentHeight = 15
            Me.cboLocation.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboLocation.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboLocation.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboLocation.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboLocation.EditorHeight = 15
            Me.cboLocation.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboLocation.ItemHeight = 15
            Me.cboLocation.Location = New System.Drawing.Point(132, 51)
            Me.cboLocation.MatchEntryTimeout = CType(2000, Long)
            Me.cboLocation.MaxDropDownItems = CType(5, Short)
            Me.cboLocation.MaxLength = 32767
            Me.cboLocation.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboLocation.Name = "cboLocation"
            Me.cboLocation.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboLocation.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboLocation.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboLocation.Size = New System.Drawing.Size(240, 21)
            Me.cboLocation.TabIndex = 178
            Me.cboLocation.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            "aultRecSelWidth>17</DefaultRecSelWidth></Blob>"
            '
            'btnUnDoAllSNs
            '
            Me.btnUnDoAllSNs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnUnDoAllSNs.Location = New System.Drawing.Point(548, 115)
            Me.btnUnDoAllSNs.Name = "btnUnDoAllSNs"
            Me.btnUnDoAllSNs.Size = New System.Drawing.Size(200, 32)
            Me.btnUnDoAllSNs.TabIndex = 177
            Me.btnUnDoAllSNs.Text = "Undo All Swapped SNs"
            '
            'btnUndoOneSN
            '
            Me.btnUndoOneSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnUndoOneSN.Location = New System.Drawing.Point(548, 75)
            Me.btnUndoOneSN.Name = "btnUndoOneSN"
            Me.btnUndoOneSN.Size = New System.Drawing.Size(200, 32)
            Me.btnUndoOneSN.TabIndex = 176
            Me.btnUndoOneSN.Text = "Undo One Swapped SN"
            '
            'tdgData1
            '
            Me.tdgData1.AllowFilter = False
            Me.tdgData1.AllowSort = False
            Me.tdgData1.AllowUpdate = False
            Me.tdgData1.AlternatingRows = True
            Me.tdgData1.BackColor = System.Drawing.Color.GhostWhite
            Me.tdgData1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdgData1.CaptionHeight = 17
            Me.tdgData1.FetchRowStyles = True
            Me.tdgData1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgData1.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgData1.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.tdgData1.Location = New System.Drawing.Point(28, 155)
            Me.tdgData1.Name = "tdgData1"
            Me.tdgData1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgData1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgData1.PreviewInfo.ZoomFactor = 75
            Me.tdgData1.RowHeight = 15
            Me.tdgData1.Size = New System.Drawing.Size(720, 296)
            Me.tdgData1.TabIndex = 175
            Me.tdgData1.Text = "C1TrueDBGrid1"
            Me.tdgData1.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style9{}Normal{Font:Tahoma, 8.25pt;}HighlightRow{ForeColo" & _
            "r:HighlightText;BackColor:Highlight;}Style12{}OddRow{}RecordSelector{AlignImage:" & _
            "Center;}Style13{}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;Fo" & _
            "reColor:ControlText;BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style11{}" & _
            "Style14{}Style15{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView" & _
            " Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" " & _
            "ColumnFooterHeight=""17"" FetchRowStyles=""True"" MarqueeStyle=""DottedCellBorder"" Re" & _
            "cordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScr" & _
            "ollGroup=""1""><Height>294</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><E" & _
            "ditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Styl" & _
            "e8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Foo" & _
            "ter"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle paren" & _
            "t=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /" & _
            "><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=" & _
            """Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><Selected" & _
            "Style parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><Clie" & _
            "ntRect>0, 0, 718, 294</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken<" & _
            "/BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent" & _
            "="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" " & _
            "me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=" & _
            """Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""E" & _
            "ditor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""E" & _
            "venRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""Recor" & _
            "dSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=" & _
            """Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Lay" & _
            "out>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 71" & _
            "8, 294</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageFoot" & _
            "erStyle parent="""" me=""Style15"" /></Blob>"
            '
            'txtSeedStockSN
            '
            Me.txtSeedStockSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtSeedStockSN.Location = New System.Drawing.Point(132, 115)
            Me.txtSeedStockSN.Name = "txtSeedStockSN"
            Me.txtSeedStockSN.Size = New System.Drawing.Size(344, 22)
            Me.txtSeedStockSN.TabIndex = 173
            Me.txtSeedStockSN.Text = ""
            '
            'lblSeedStockSN
            '
            Me.lblSeedStockSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSeedStockSN.Location = New System.Drawing.Point(20, 115)
            Me.lblSeedStockSN.Name = "lblSeedStockSN"
            Me.lblSeedStockSN.Size = New System.Drawing.Size(104, 24)
            Me.lblSeedStockSN.TabIndex = 174
            Me.lblSeedStockSN.Text = "SeedStock SN:"
            Me.lblSeedStockSN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtSwappedSN
            '
            Me.txtSwappedSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtSwappedSN.Location = New System.Drawing.Point(132, 83)
            Me.txtSwappedSN.Name = "txtSwappedSN"
            Me.txtSwappedSN.Size = New System.Drawing.Size(344, 22)
            Me.txtSwappedSN.TabIndex = 171
            Me.txtSwappedSN.Text = ""
            '
            'lblSwappedSN
            '
            Me.lblSwappedSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSwappedSN.Location = New System.Drawing.Point(20, 83)
            Me.lblSwappedSN.Name = "lblSwappedSN"
            Me.lblSwappedSN.Size = New System.Drawing.Size(104, 24)
            Me.lblSwappedSN.TabIndex = 172
            Me.lblSwappedSN.Text = "Swapped SN:"
            Me.lblSwappedSN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'frmVinsmart_Swap
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.LightSkyBlue
            Me.ClientSize = New System.Drawing.Size(768, 470)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblCustomer, Me.cboCustomer, Me.lblLocation, Me.cboLocation, Me.btnUnDoAllSNs, Me.btnUndoOneSN, Me.tdgData1, Me.txtSeedStockSN, Me.lblSeedStockSN, Me.txtSwappedSN, Me.lblSwappedSN})
            Me.Name = "frmVinsmart_Swap"
            Me.Text = "frmVinsmart_Swap"
            CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboLocation, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmVinsmart_Swap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable, dtLoc As DataTable
            Dim iLoc_ID As Integer = 0

            Try
                PSS.Core.Highlight.SetHighLight(Me)

                'turn these off now
                Me.btnUndoOneSN.Visible = False
                Me.btnUnDoAllSNs.Visible = False

                'Populate customer
                dt = Generic.GetCustomers(True, )
                Misc.PopulateC1DropDownList(Me.cboCustomer, dt, "Cust_Name1", "Cust_ID")
                Me.cboCustomer.SelectedValue = Me._iCust_ID
                If Me.cboCustomer.SelectedValue > 0 Then Me.cboCustomer.Enabled = False

                'Location
                dtLoc = Generic.GetLocations(True, Me._iCust_ID)
                Misc.PopulateC1DropDownList(Me.cboLocation, dtLoc, "Loc_Name", "Loc_ID")
                If dtLoc.Rows.Count = 2 Then
                    iLoc_ID = dtLoc.Rows(0).Item("Loc_ID")
                    Me.cboLocation.SelectedValue = iLoc_ID
                Else
                    Me.cboLocation.SelectedValue = 0
                End If

                Me.txtSeedStockSN.Enabled = False
                Me.txtSeedStockSN.Text = ""
                Me.txtSwappedSN.Text = "" : Me.txtSwappedSN.SelectAll() : Me.txtSwappedSN.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        Private Sub btnSwap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            'If txtSeedStock.Text = String.Empty Or txtSN.Text = String.Empty Then
            '    MessageBox.Show("Please select a Serial Number or SeedStock ", "Serial Number", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            '    Exit Sub
            'ElseIf txtSwapSN.Text <> String.Empty Then
            '    MessageBox.Show("You can Update this SN, Please see the Administrator", "Serial Number", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '    Exit Sub

            'End If
            'Dim lSeedstock As Long = Long.Parse(txtSeedStock.Text)
            'Dim SN As Long = Long.Parse(txtSN.Text)
            'If txtModel.Text <> txtModelD.Text Then
            '    MessageBox.Show("Please SN must the same Model", "Model ID", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            'Else

            '    dbgSource.DataSource = _objVinsmart_Swap.updatedbg(lSeedstock, SN)
            'End If
        End Sub
        Private Sub dbgSource_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
            'Me.txtModel.Text = dbgSource.Columns("Model_ID").Value
            'Me.txtASNmodel.Text = dbgSource.Columns("ASN_Model").Value
            'Me.txtDescription.Text = dbgSource.Columns("Mode_desc").Value
            'Me.txtSKU.Text = dbgSource.Columns("ASN_SKU").Value
            'Me.txtSN.Text = dbgSource.Columns("SN").Value
            'Me.txtSwapSN.Text = dbgSource.Columns("Swaped_SN").Value

        End Sub

        Private Sub dbgDestination_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        End Sub

        Private Sub dbgDestination_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
            'Me.txtModelD.Text = dbgDestination.Columns("Model_ID").Value
            'Me.txtASNModelD.Text = dbgDestination.Columns("ASN_Model").Value
            'Me.txtDescriptionD.Text = dbgDestination.Columns("Mode_desc").Value
            'Me.txtSND.Text = dbgDestination.Columns("ASN_SKU").Value
            'Me.txtSeedStock.Text = dbgDestination.Columns("SeedStock_SN").Value

        End Sub


        Private Sub txtSwappedSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSwappedSN.KeyUp
            Try
                If e.KeyCode = Keys.Enter Then
                   If Me.txtSwappedSN.Text.Trim.Length > 0 AndAlso Me._iCust_ID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID Then
                        Me.ProcessSN(PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_OrderTypeBulk_ID)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtSwappedSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub txtSeedStockSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSeedStockSN.KeyUp
            Try
                If e.KeyCode = Keys.Enter Then
                  If Me.txtSwappedSN.Text.Trim.Length > 0 AndAlso Me._iCust_ID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID Then
                        Me.ProcessSN(PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_OrderTypeSeedStock_ID)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, " txtSeedStockSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub



        Private Sub ProcessSN(ByVal iSN_Type As Integer)
            Dim strSN As String = ""
            Dim dtSeedStock As DataTable
            Dim dtBill As DataTable
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
            Dim iBulk_Device_ID As Integer = 0
            Dim iSeeStock_Device_ID As Integer = 0

            'Dim iShift_ID As Integer = PSS.Core.ApplicationUser.IDShift
            'Dim strWorkDate As String = Generic.GetWorkDate(iShift_ID)
            'Dim iTray_ID As Integer = 0
            'Dim strTrayMemo As String = "Vinsmart Receiving"

            'Swap: This seedstock SN must be billed as swapped_BillCode_ID

            Try
                If iSN_Type = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_OrderTypeBulk_ID Then
                    Me.txtSeedStockSN.Enabled = False
                    If Not Me.cboLocation.SelectedValue > 0 Then
                        MessageBox.Show("Please select a location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.cboLocation.Focus() : Exit Sub
                    End If

                    strSN = Me.txtSwappedSN.Text.Trim
                    Me._dtBulk = Me._objVinsmart_Swap.getDeviceData(Me._iCust_ID, Me.cboLocation.SelectedValue, strSN, iSN_Type, "")

                    If Not Me._dtBulk.Rows.Count > 0 Then
                        MessageBox.Show("Can't find this SN '" & strSN & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtSwappedSN.SelectAll() : Me.txtSwappedSN.Focus() : Exit Sub
                    ElseIf Me._dtBulk.Rows.Count > 1 Then
                        MessageBox.Show("Duplicate SNs.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtSwappedSN.SelectAll() : Me.txtSwappedSN.Focus() : Exit Sub
                    Else '=1
                        If Not strSN.ToUpper = Trim(Me._dtBulk.Rows(0).Item("ASN_SN")).ToUpper Then
                            MessageBox.Show("This SN '" & strSN & "' is different from ASN SN '" & Me._dtBulk.Rows(0).Item("ASN_SN") & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.txtSwappedSN.SelectAll() : Me.txtSwappedSN.Focus() : Exit Sub
                        ElseIf Convert.ToInt32(Me._dtBulk.Rows(0).Item("Swapped_Device_ID")) > 0 Then
                            MessageBox.Show("This SN '" & strSN & "' has been swapped.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.txtSwappedSN.SelectAll() : Me.txtSwappedSN.Focus() : Exit Sub
                        End If
                        'Check if BER
                        iBulk_Device_ID = Convert.ToInt32(Me._dtBulk.Rows(0).Item("Device_ID"))
                        dtBill = Me._objVinsmart_Swap.getDeviceBillData(iBulk_Device_ID)
                        If Not dtBill.Rows.Count > 0 Then
                            If MsgBox("Device has no bill info. Do you still want to swap it (Caution: you may check with the supervisor)?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                                'MessageBox.Show("The device has not been billed yet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Me.txtSwappedSN.SelectAll() : Me.txtSwappedSN.Focus() : Exit Sub
                            Else
                                Me._iModel_ID = Convert.ToInt32(Me._dtBulk.Rows(0).Item("Model_ID"))
                                Me.txtSwappedSN.Enabled = False : Me.txtSeedStockSN.Enabled = True
                                Me.txtSeedStockSN.Text = "" : Me.txtSeedStockSN.SelectAll() : Me.txtSeedStockSN.Focus() : Exit Sub
                            End If
                        End If

                        Dim strMsg As String = ""
                        Dim bIsNormalRepairedDevice As Boolean = False
                        Me.CheckSwapDevice(Me._dtBulk, dtBill, strMsg, bIsNormalRepairedDevice)
                        If bIsNormalRepairedDevice Then
                            If MsgBox("This is a standard repaired device. Do you still want to swap it (Caution: you may check with the supervisor)?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                                'MessageBox.Show("The device has not been billed yet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Me.txtSwappedSN.SelectAll() : Me.txtSwappedSN.Focus() : Exit Sub
                            Else
                                Me._iModel_ID = Convert.ToInt32(Me._dtBulk.Rows(0).Item("Model_ID"))
                                Me.txtSwappedSN.Enabled = False : Me.txtSeedStockSN.Enabled = True
                                Me.txtSeedStockSN.Text = "" : Me.txtSeedStockSN.SelectAll() : Me.txtSeedStockSN.Focus() : Exit Sub
                            End If
                        Else
                            If strMsg.Trim.Length = 0 Then
                                Me._iModel_ID = Convert.ToInt32(Me._dtBulk.Rows(0).Item("Model_ID"))
                                Me.txtSwappedSN.Enabled = False : Me.txtSeedStockSN.Enabled = True
                                Me.txtSeedStockSN.Text = "" : Me.txtSeedStockSN.SelectAll() : Me.txtSeedStockSN.Focus() : Exit Sub
                            Else
                                MessageBox.Show(strMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Me.txtSwappedSN.SelectAll() : Me.txtSwappedSN.Focus() : Exit Sub
                            End If
                        End If
                    End If
                ElseIf iSN_Type = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_OrderTypeSeedStock_ID Then
                    strSN = Me.txtSeedStockSN.Text.Trim
                    Dim strVinsmartCricketOrATT As String = ""
                    Dim iLoc_ID As Integer = 0

                    If Me._iCust_ID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID Then
                        iLoc_ID = Convert.ToInt32(Me._dtBulk.Rows(0).Item("Loc_ID"))
                        If iLoc_ID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttCricket_LOC_ID Then
                            strVinsmartCricketOrATT = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_SeedStockSourceType_Cricket.Trim
                        ElseIf iLoc_ID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttCTDI_LOC_ID _
                        Or iLoc_ID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttFedEx_LOC_ID Then
                            strVinsmartCricketOrATT = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_SeedStockSourceType_ATT.Trim
                        Else

                            MessageBox.Show("Can't determine Vinsmart Location. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.txtSeedStockSN.SelectAll() : Me.txtSeedStockSN.Focus() : Exit Sub
                        End If
                    End If

                    dtSeedStock = Me._objVinsmart_Swap.getDeviceData(Me._iCust_ID, Me.cboLocation.SelectedValue, strSN, iSN_Type, strVinsmartCricketOrATT)

                    If Not dtSeedStock.Rows.Count > 0 Then
                        MessageBox.Show("Can't find this SeedStock SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtSeedStockSN.SelectAll() : Me.txtSeedStockSN.Focus() : Exit Sub
                    ElseIf dtSeedStock.Rows.Count > 1 Then
                        MessageBox.Show("Duplicate SeedStock SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtSeedStockSN.SelectAll() : Me.txtSeedStockSN.Focus() : Exit Sub
                    Else '=1
                        iSeeStock_Device_ID = Convert.ToInt32(dtSeedStock.Rows(0).Item("Device_ID"))
                        If Me._objVinsmart_Swap.Has_Swap_Bill_Code(iSeeStock_Device_ID, PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_Swap_BillCode_ID) Then
                            MessageBox.Show("This seedstock device has already been used for swapping. Try another one.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.txtSeedStockSN.SelectAll() : Me.txtSeedStockSN.Focus() : Exit Sub
                        End If
                        'dtBill = Me._objVinsmart_Swap.getDeviceBillData(iSeeStock_Device_ID)
                        'If dtBill.Rows.Count > 0 Then
                        '    MessageBox.Show("This seedstock device has bill code(s). See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        '    Me.txtSeedStockSN.SelectAll() : Me.txtSeedStockSN.Focus() : Exit Sub
                        'End If

                        If Me._iCust_ID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID _
                           AndAlso (Me._iModel_ID = 5084 OrElse Me._iModel_ID = 5046) _
                           AndAlso (Convert.ToInt32(dtSeedStock.Rows(0).Item("Model_ID")) = 5084 OrElse Convert.ToInt32(dtSeedStock.Rows(0).Item("Model_ID")) = 5046) Then
                            'do nothing, allow them to swap
                        ElseIf Not Me._iModel_ID = Convert.ToInt32(dtSeedStock.Rows(0).Item("Model_ID")) Then
                            MessageBox.Show("Not the same model (sku).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.txtSeedStockSN.SelectAll() : Me.txtSeedStockSN.Focus() : Exit Sub
                        End If

                        'Ready
                        If Me._dtBulk.Rows.Count = 1 AndAlso dtSeedStock.Rows.Count = 1 Then
                            Dim row As DataRow, row2 As DataRow
                            Dim i As Integer = 0, j As Integer = 0, k As Integer = 0
                            Dim iLaborLevel As Integer = 0 ' PSS.Data.Buisness.Vinsmart.Vinsmart_Swap_LabelLevel
                            Dim iPrcGroup_ID As Integer = 0 'PSS.Data.Buisness.Vinsmart.Vinsmart_PrcGroup_ID
                            Dim iPsPRice_ID As Integer = 0 'PSS.Data.Buisness.Vinsmart.Vinsmart_Swap_PSPrice_ID
                            Dim iSwap_BillCode_ID As Integer = 0 'PSS.Data.Buisness.Vinsmart.Vinsmart_Swap_BillCode_ID
                            Dim strWorkStation As String = "" 'PSS.Data.Buisness.Vinsmart.Vinsmart_DeviceSwap_WorkStation
                            Dim dPartCharge As Single = 0.0
                            Dim dLaborCharge As Single = 0.0
                            Dim strPartNum As String = ""
                            Dim strDateTime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
                            Dim dtTmp As DataTable


                            If Me._iCust_ID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID Then
                                iLaborLevel = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_Swap_LabelLevel
                                iPrcGroup_ID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_PrcGroup_ID
                                iPsPRice_ID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_Swap_PSPrice_ID
                                iSwap_BillCode_ID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_Swap_BillCode_ID
                                strWorkStation = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_DeviceSwap_WorkStation
                            Else
                                MessageBox.Show("Can't determine customer. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Me.txtSeedStockSN.SelectAll() : Me.txtSeedStockSN.Focus() : Exit Sub
                            End If

                            If MsgBox("Do you want to swap it now?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                                'get labor charge
                                dtTmp = Me._objVinsmart_Swap.getLaborChargeData(iLaborLevel, iPrcGroup_ID)
                                If Not dtTmp.Rows.Count > 0 Then
                                    MessageBox.Show("Can't find labor charge data for the labor level " & iLaborLevel.ToString & ". See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Me.txtSeedStockSN.SelectAll() : Me.txtSeedStockSN.Focus() : Exit Sub
                                Else
                                    dLaborCharge = Convert.ToSingle(dtTmp.Rows(0).Item("LaborPrc_RegPrc"))
                                End If
                                'Get part number
                                dtTmp = Me._objVinsmart_Swap.getPartNumberData(iPsPRice_ID)
                                If Not dtTmp.Rows.Count > 0 Then
                                    MessageBox.Show("Can't find part number! See IT " & iLaborLevel.ToString, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Me.txtSeedStockSN.SelectAll() : Me.txtSeedStockSN.Focus() : Exit Sub
                                Else
                                    strPartNum = Convert.ToString(dtTmp.Rows(0).Item("PSPrice_Number"))
                                End If
                                iBulk_Device_ID = Convert.ToInt32(Me._dtBulk.Rows(0).Item("Device_ID"))

                                Me._dtBulk.Rows(0).Item("SeedStock_SN") = strSN
                                Me._dtBulk.Rows(0).Item("Swapped_Device_ID") = iSeeStock_Device_ID
                                Me._dtBulk.AcceptChanges()

                                If Me._dtFinal Is Nothing OrElse Me._dtFinal.Rows.Count = 0 Then Me._dtFinal = Me._dtBulk.Clone

                                ' rowNew = Me._dtFinal.NewRow
                                For Each row In Me._dtBulk.Rows 'one row
                                    Me._dtFinal.ImportRow(row)

                                    For Each row2 In Me._dtFinal.Rows 'add index id
                                        i += 1
                                        row2.BeginEdit() : row2("RecID") = i : row2.AcceptChanges()
                                    Next

                                    'Bind data grid
                                    With Me.tdgData1
                                        .DataSource = Me._dtFinal.DefaultView

                                        For Each dbgc In .Splits(0).DisplayColumns
                                            dbgc.Locked = True
                                            dbgc.AutoSize()
                                            j += 1
                                            If j > 5 Then dbgc.Visible = False
                                        Next dbgc
                                        '.Splits(0).DisplayColumns("Sku").Width = 80
                                    End With
                                Next

                                'Update
                                k = Me._objVinsmart_Swap.UpdateSwappedData(iSeeStock_Device_ID, iBulk_Device_ID, iSwap_BillCode_ID, strPartNum, Me._iUserID, strDateTime, _
                                                                        dLaborCharge, dPartCharge, iLaborLevel, strWorkStation)
                                Me.txtSeedStockSN.Text = "" : Me.txtSeedStockSN.Enabled = False : Me._iModel_ID = 0
                                Me.txtSwappedSN.Enabled = True : Me._dtBulk.Rows.Clear()
                                Me.txtSwappedSN.Text = "" : Me.txtSwappedSN.SelectAll() : Me.txtSwappedSN.Focus()
                            Else
                                Me.txtSeedStockSN.Text = "" : Me.txtSeedStockSN.Enabled = False : Me._iModel_ID = 0
                                Me.txtSwappedSN.Enabled = True : Me._dtBulk.Rows.Clear()
                                Me.txtSwappedSN.Text = "" : Me.txtSwappedSN.SelectAll() : Me.txtSwappedSN.Focus()
                            End If
                        Else
                            MessageBox.Show("Invalid data! See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    End If
                Else
                    MessageBox.Show("Invalid SN type (should be bulk, seedstock?).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtSeedStockSN.Text = ""
                    Me.txtSwappedSN.SelectAll() : Me.txtSwappedSN.Focus() : Exit Sub
                End If



            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Finally
                Me.Cursor = Cursors.Default
                'dt = Nothing : dtModel = Nothing
            End Try
        End Sub

        Private Sub CheckSwapDevice(ByVal dt As DataTable, ByVal dtBill As DataTable, ByRef strMsg As String, ByRef bIsNormalRepairedDevice As Boolean)
            Dim iWrty As Integer = 0
            Dim iLoc_ID As Integer = 0
            Dim strATT_WexPos As String = ""

            Dim foundRows() As DataRow

            strMsg = "" : bIsNormalRepairedDevice = False
            If Not dt.Rows.Count > 0 Then
                strMsg = "Not device data!" : Exit Sub
            End If

            iWrty = Convert.ToInt32(dt.Rows(0).Item("Device_ManufWrty")) '0=OW=Out OF Warranty; 1=IW=In Warranty
            If Not iWrty = 0 AndAlso Not iWrty = 1 Then strMsg = "Invalid warranty!" : Exit Sub

            iLoc_ID = Convert.ToInt32(dt.Rows(0).Item("Loc_ID"))

            If Me._iCust_ID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID Then 'Vinsmart ===============================================================================
                foundRows = dtBill.Select("BillCode_ID=" & PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_BER_BillCode_ID) 'BER
                If foundRows.Length > 0 Then
                    strMsg = "" : Exit Sub
                Else
                    foundRows = dtBill.Select("BillCode_ID=" & PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_RUR_BillCode_ID) 'RUR Physical Abuse
                    If foundRows.Length > 0 Then
                        If iWrty = 1 Then strMsg = "Device is IW and RUR Physical Abuse. It is not eligible for swap." : Exit Sub
                        If iWrty = 0 Then strMsg = "" : Exit Sub
                    Else
                        foundRows = dtBill.Select("BillCode_ID=" & PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_RUR_BillCode_ID2) 'RUR Liquid Damage
                        If foundRows.Length > 0 Then
                            If iWrty = 0 Then strMsg = "Device is OW and RUR Liquid Damage. It is not eligible for swap." : Exit Sub
                        Else
                            bIsNormalRepairedDevice = True : Exit Sub
                        End If
                    End If
                End If
            ElseIf Me._iCust_ID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID AndAlso iLoc_ID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttCricket_LOC_ID Then 'Vinsmart Cricket =====
                If iWrty = 1 Then 'WEX, IW
                    foundRows = dtBill.Select("BillCode_ID=" & PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_BER_BillCode_ID) 'BER
                    If foundRows.Length > 0 Then
                        strMsg = "" : Exit Sub
                    Else
                        foundRows = dtBill.Select("BillCode_ID=" & PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_RUR_BillCode_ID) 'RUR Physical Abuse
                        If foundRows.Length > 0 Then
                            strMsg = "Device is IW and RUR Physical Abuse. It is not eligible for swap." : Exit Sub
                        Else
                            foundRows = dtBill.Select("BillCode_ID=" & PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_RUR_BillCode_ID2) 'RUR Liquid Damage
                            If foundRows.Length > 0 Then
                                strMsg = "Device is IW and RUR Liquid Damage. It is not eligible for swap." : Exit Sub
                            Else
                                bIsNormalRepairedDevice = True : Exit Sub
                            End If
                        End If
                    End If
                ElseIf iWrty = 0 Then 'DOA, OW
                    strMsg = "Device is DOA (OW). We are holding this and it is not eligible for swap now." : Exit Sub
                End If
            ElseIf Me._iCust_ID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID Then 'Vinsmart ATT CTDI and FedEx ======================================================
                If Not dt.Rows(0).IsNull("VendorID") Then strATT_WexPos = Convert.ToString(dt.Rows(0).Item("VendorID"))
                If strATT_WexPos.Trim.ToUpper = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_FexEx_PosCode.Trim.ToUpper Then strMsg = "Device is POS. We are holding this and it is not eligible for swap now." : Exit Sub

                foundRows = dtBill.Select("BillCode_ID=" & PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_BER_BillCode_ID) 'BER
                If foundRows.Length > 0 Then
                    strMsg = "" : Exit Sub
                Else
                    foundRows = dtBill.Select("BillCode_ID=" & PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_RUR_BillCode_ID) 'RUR Physical Abuse
                    If foundRows.Length > 0 Then
                        strMsg = "Device is IW and RUR Physical Abuse. It is not eligible for swap." : Exit Sub
                    Else
                        foundRows = dtBill.Select("BillCode_ID=" & PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_RUR_BillCode_ID2) 'RUR Liquid Damage
                        If foundRows.Length > 0 Then
                            strMsg = "Device is RUR Liquid Damage. It is not eligible for swap." : Exit Sub
                        Else
                            bIsNormalRepairedDevice = True : Exit Sub
                        End If
                    End If
                End If
            Else
                strMsg = "No defined customer."
            End If

        End Sub
    End Class
End Namespace

