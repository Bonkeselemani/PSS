Option Explicit On 
Imports PSS.Data

Namespace Gui
    Public Class frmManageFedexServiceSchedule
        Inherits System.Windows.Forms.Form

        Private _strScreenname As String = ""
        Private _iMenuCustID As Integer
        Private _objAIGProduceShip As Buisness.AIGProduceShip
        Private _iOldShipDays As Integer = 0
        Private _iOldStateID As Integer = 0
        Private _iShipDayID As Integer = 0
        Private _iCarrierID As Integer = 0
        Private _iCountryID As Integer = 0
        Private _strOldComment As String = ""
        Private _iDefSelectVal As Integer = 99999

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenname As String, ByVal Cust_ID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _strScreenname = strScreenname
            _iMenuCustID = Cust_ID
            _objAIGProduceShip = New Buisness.AIGProduceShip()

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
        Friend WithEvents tdgData1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents pnlDataEntry As System.Windows.Forms.Panel
        Friend WithEvents cboCustomers As C1.Win.C1List.C1Combo
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents cboCarrier As C1.Win.C1List.C1Combo
        Friend WithEvents cboCountry As C1.Win.C1List.C1Combo
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents cboState As C1.Win.C1List.C1Combo
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents txtShipDays As System.Windows.Forms.TextBox
        Friend WithEvents btnUpdate As System.Windows.Forms.Button
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents rbnAddNew As System.Windows.Forms.RadioButton
        Friend WithEvents rbnEdit As System.Windows.Forms.RadioButton
        Friend WithEvents lblrecNum As System.Windows.Forms.Label
        Friend WithEvents txtComment As System.Windows.Forms.TextBox
        Friend WithEvents lblComment As System.Windows.Forms.Label
        Friend WithEvents lblMsg As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmManageFedexServiceSchedule))
            Me.tdgData1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.pnlDataEntry = New System.Windows.Forms.Panel()
            Me.txtComment = New System.Windows.Forms.TextBox()
            Me.lblComment = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.btnUpdate = New System.Windows.Forms.Button()
            Me.txtShipDays = New System.Windows.Forms.TextBox()
            Me.cboState = New C1.Win.C1List.C1Combo()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.cboCountry = New C1.Win.C1List.C1Combo()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.cboCarrier = New C1.Win.C1List.C1Combo()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cboCustomers = New C1.Win.C1List.C1Combo()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.rbnAddNew = New System.Windows.Forms.RadioButton()
            Me.rbnEdit = New System.Windows.Forms.RadioButton()
            Me.lblrecNum = New System.Windows.Forms.Label()
            Me.lblMsg = New System.Windows.Forms.Label()
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlDataEntry.SuspendLayout()
            CType(Me.cboState, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboCountry, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboCarrier, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
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
            Me.tdgData1.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.tdgData1.Location = New System.Drawing.Point(8, 32)
            Me.tdgData1.Name = "tdgData1"
            Me.tdgData1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgData1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgData1.PreviewInfo.ZoomFactor = 75
            Me.tdgData1.Size = New System.Drawing.Size(780, 272)
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
            "alScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>270</Height><CaptionStyle pa" & _
            "rent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRow" & _
            "Style parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Styl" & _
            "e13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=" & _
            """Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle pare" & _
            "nt=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><" & _
            "OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSel" & _
            "ector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style pare" & _
            "nt=""Normal"" me=""Style1"" /><ClientRect>0, 0, 778, 270</ClientRect><BorderSide>0</" & _
            "BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Sp" & _
            "lits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Head" & _
            "ing"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption" & _
            """ /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected""" & _
            " /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow""" & _
            " /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><S" & _
            "tyle parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar" & _
            """ /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits" & _
            "><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultR" & _
            "ecSelWidth><ClientArea>0, 0, 778, 270</ClientArea><PrintPageHeaderStyle parent=""" & _
            """ me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'pnlDataEntry
            '
            Me.pnlDataEntry.BackColor = System.Drawing.Color.LightGray
            Me.pnlDataEntry.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblMsg, Me.txtComment, Me.lblComment, Me.Label4, Me.btnUpdate, Me.txtShipDays, Me.cboState, Me.Label3, Me.cboCountry, Me.Label2, Me.cboCarrier, Me.Label1, Me.cboCustomers, Me.Label7})
            Me.pnlDataEntry.Location = New System.Drawing.Point(8, 312)
            Me.pnlDataEntry.Name = "pnlDataEntry"
            Me.pnlDataEntry.Size = New System.Drawing.Size(776, 168)
            Me.pnlDataEntry.TabIndex = 59
            '
            'txtComment
            '
            Me.txtComment.Location = New System.Drawing.Point(312, 104)
            Me.txtComment.Multiline = True
            Me.txtComment.Name = "txtComment"
            Me.txtComment.Size = New System.Drawing.Size(416, 48)
            Me.txtComment.TabIndex = 137
            Me.txtComment.Text = ""
            '
            'lblComment
            '
            Me.lblComment.BackColor = System.Drawing.Color.Transparent
            Me.lblComment.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblComment.ForeColor = System.Drawing.Color.Black
            Me.lblComment.Location = New System.Drawing.Point(312, 86)
            Me.lblComment.Name = "lblComment"
            Me.lblComment.Size = New System.Drawing.Size(72, 24)
            Me.lblComment.TabIndex = 138
            Me.lblComment.Text = "Comment:"
            Me.lblComment.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.Black
            Me.Label4.Location = New System.Drawing.Point(8, 128)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(72, 24)
            Me.Label4.TabIndex = 136
            Me.Label4.Text = "Ship Days:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnUpdate
            '
            Me.btnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnUpdate.Location = New System.Drawing.Point(312, 8)
            Me.btnUpdate.Name = "btnUpdate"
            Me.btnUpdate.Size = New System.Drawing.Size(168, 40)
            Me.btnUpdate.TabIndex = 135
            Me.btnUpdate.Text = "Update"
            '
            'txtShipDays
            '
            Me.txtShipDays.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtShipDays.Location = New System.Drawing.Point(80, 128)
            Me.txtShipDays.Name = "txtShipDays"
            Me.txtShipDays.Size = New System.Drawing.Size(72, 26)
            Me.txtShipDays.TabIndex = 134
            Me.txtShipDays.Text = ""
            '
            'cboState
            '
            Me.cboState.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboState.Caption = ""
            Me.cboState.CaptionHeight = 17
            Me.cboState.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboState.ColumnCaptionHeight = 17
            Me.cboState.ColumnFooterHeight = 17
            Me.cboState.ContentHeight = 15
            Me.cboState.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboState.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboState.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboState.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboState.EditorHeight = 15
            Me.cboState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboState.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboState.ItemHeight = 15
            Me.cboState.Location = New System.Drawing.Point(80, 96)
            Me.cboState.MatchEntryTimeout = CType(2000, Long)
            Me.cboState.MaxDropDownItems = CType(5, Short)
            Me.cboState.MaxLength = 32767
            Me.cboState.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboState.Name = "cboState"
            Me.cboState.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboState.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboState.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboState.Size = New System.Drawing.Size(192, 21)
            Me.cboState.TabIndex = 132
            Me.cboState.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.Black
            Me.Label3.Location = New System.Drawing.Point(8, 96)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(72, 16)
            Me.Label3.TabIndex = 133
            Me.Label3.Text = "State:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboCountry
            '
            Me.cboCountry.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboCountry.Caption = ""
            Me.cboCountry.CaptionHeight = 17
            Me.cboCountry.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboCountry.ColumnCaptionHeight = 17
            Me.cboCountry.ColumnFooterHeight = 17
            Me.cboCountry.ContentHeight = 15
            Me.cboCountry.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboCountry.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboCountry.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCountry.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCountry.EditorHeight = 15
            Me.cboCountry.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCountry.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboCountry.ItemHeight = 15
            Me.cboCountry.Location = New System.Drawing.Point(80, 64)
            Me.cboCountry.MatchEntryTimeout = CType(2000, Long)
            Me.cboCountry.MaxDropDownItems = CType(5, Short)
            Me.cboCountry.MaxLength = 32767
            Me.cboCountry.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCountry.Name = "cboCountry"
            Me.cboCountry.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCountry.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCountry.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCountry.Size = New System.Drawing.Size(192, 21)
            Me.cboCountry.TabIndex = 130
            Me.cboCountry.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.Black
            Me.Label2.Location = New System.Drawing.Point(8, 64)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(72, 16)
            Me.Label2.TabIndex = 131
            Me.Label2.Text = "Country:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboCarrier
            '
            Me.cboCarrier.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboCarrier.Caption = ""
            Me.cboCarrier.CaptionHeight = 17
            Me.cboCarrier.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboCarrier.ColumnCaptionHeight = 17
            Me.cboCarrier.ColumnFooterHeight = 17
            Me.cboCarrier.ContentHeight = 15
            Me.cboCarrier.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboCarrier.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboCarrier.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCarrier.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCarrier.EditorHeight = 15
            Me.cboCarrier.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCarrier.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.cboCarrier.ItemHeight = 15
            Me.cboCarrier.Location = New System.Drawing.Point(80, 32)
            Me.cboCarrier.MatchEntryTimeout = CType(2000, Long)
            Me.cboCarrier.MaxDropDownItems = CType(5, Short)
            Me.cboCarrier.MaxLength = 32767
            Me.cboCarrier.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCarrier.Name = "cboCarrier"
            Me.cboCarrier.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCarrier.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCarrier.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCarrier.Size = New System.Drawing.Size(136, 21)
            Me.cboCarrier.TabIndex = 128
            Me.cboCarrier.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Black
            Me.Label1.Location = New System.Drawing.Point(8, 32)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(72, 16)
            Me.Label1.TabIndex = 129
            Me.Label1.Text = "Carrier:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            Me.cboCustomers.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.cboCustomers.ItemHeight = 15
            Me.cboCustomers.Location = New System.Drawing.Point(80, 8)
            Me.cboCustomers.MatchEntryTimeout = CType(2000, Long)
            Me.cboCustomers.MaxDropDownItems = CType(5, Short)
            Me.cboCustomers.MaxLength = 32767
            Me.cboCustomers.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCustomers.Name = "cboCustomers"
            Me.cboCustomers.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCustomers.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCustomers.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCustomers.Size = New System.Drawing.Size(192, 21)
            Me.cboCustomers.TabIndex = 126
            Me.cboCustomers.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
            "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Microsoft" & _
            " Sans Serif, 8.25pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:" & _
            "Highlight;}Style1{}OddRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;B" & _
            "ackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Cente" & _
            "r;}Style8{}Style10{}Style11{}Style9{AlignHorz:Near;}</Data></Styles><Splits><C1." & _
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
            Me.Label7.Location = New System.Drawing.Point(8, 8)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(72, 16)
            Me.Label7.TabIndex = 127
            Me.Label7.Text = "Customer:"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'rbnAddNew
            '
            Me.rbnAddNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rbnAddNew.Location = New System.Drawing.Point(120, 8)
            Me.rbnAddNew.Name = "rbnAddNew"
            Me.rbnAddNew.Size = New System.Drawing.Size(120, 24)
            Me.rbnAddNew.TabIndex = 61
            Me.rbnAddNew.Text = "Add New"
            '
            'rbnEdit
            '
            Me.rbnEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rbnEdit.Location = New System.Drawing.Point(8, 8)
            Me.rbnEdit.Name = "rbnEdit"
            Me.rbnEdit.Size = New System.Drawing.Size(96, 24)
            Me.rbnEdit.TabIndex = 60
            Me.rbnEdit.Text = "View/Edit"
            '
            'lblrecNum
            '
            Me.lblrecNum.ForeColor = System.Drawing.Color.Blue
            Me.lblrecNum.Location = New System.Drawing.Point(536, 16)
            Me.lblrecNum.Name = "lblrecNum"
            Me.lblrecNum.Size = New System.Drawing.Size(256, 16)
            Me.lblrecNum.TabIndex = 62
            Me.lblrecNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblMsg
            '
            Me.lblMsg.ForeColor = System.Drawing.Color.Blue
            Me.lblMsg.Location = New System.Drawing.Point(312, 49)
            Me.lblMsg.Name = "lblMsg"
            Me.lblMsg.Size = New System.Drawing.Size(424, 24)
            Me.lblMsg.TabIndex = 139
            Me.lblMsg.Text = " "
            '
            'frmManageFedexServiceSchedule
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(792, 486)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblrecNum, Me.rbnAddNew, Me.rbnEdit, Me.pnlDataEntry, Me.tdgData1})
            Me.Name = "frmManageFedexServiceSchedule"
            Me.Text = "frmManageFedexServiceSchedule"
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlDataEntry.ResumeLayout(False)
            CType(Me.cboState, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboCountry, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboCarrier, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmManageFedexServiceSchedule_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            PSS.Core.Highlight.SetHighLight(Me)

            LoadCustomers()
            PopulateShipmentCarrier()
            PopulateCountries()
            Me.rbnEdit.Checked = True

        End Sub

        '*********************************************************
        Private Sub LoadCustomers()
            Dim dt As New DataTable()
            Try

                Buisness.Generic.GetCustIDByMachine()
                Me.cboCustomers.DataSource = Nothing
                dt = Buisness.Generic.GetCustomers(True)
                Misc.PopulateC1DropDownList(Me.cboCustomers, dt, "Cust_Name1", "Cust_ID")
                Me.cboCustomers.SelectedValue = Me._iMenuCustID
                Me.cboCustomers.ReadOnly = True

            Catch ex As Exception
                MsgBox("Error in TMI_OBA.LoadCustomers(): " & ex.Message.ToString, MsgBoxStyle.Critical)
            Finally
                dt = Nothing
            End Try
        End Sub

        '*********************************************************
        Private Sub PopulateShipmentCarrier()
            Dim row As DataRow
            Dim i As Integer
            Dim dTB As DataTable

            Try
                Me.cboCarrier.ClearItems()

                dTB = Me._objAIGProduceShip.GetShipCarriers

                If dTB.Rows.Count > 0 Then
                    Misc.PopulateC1DropDownList(Me.cboCarrier, dTB, "SC_Desc", "SC_ID")
                    Me.cboCarrier.SelectedValue = 2 'FedEx Ground
                    'MessageBox.Show("Me.cboCarrier.SelectedValue=" & Me.cboCarrier.SelectedValue)
                    Me.cboCarrier.ReadOnly = True
                End If

                dTB = Nothing

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "PopulateShipmentCarrier", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try

        End Sub

        '*********************************************************
        Private Sub PopulateCountries()
            Dim row As DataRow
            Dim i As Integer
            Dim dTB As DataTable

            Try
                Me.cboCountry.ClearItems()

                dTB = Me._objAIGProduceShip.GetCountryAll

                If dTB.Rows.Count > 0 Then
                    Misc.PopulateC1DropDownList(Me.cboCountry, dTB, "Cntry_Name", "Cntry_ID")
                    Me.cboCountry.SelectedValue = 161 'USA
                    'MessageBox.Show("Me.cboCountry.SelectedValue=" & Me.cboCountry.SelectedValue)
                    Me.cboCountry.ReadOnly = True
                End If

                dTB = Nothing

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "PopulateCountries", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try

        End Sub

        '*********************************************************
        Private Sub PopulateStates(ByVal iCntry_ID As Integer, ByVal iState_ID As Integer)
            Dim row As DataRow
            Dim i As Integer
            Dim dTB As DataTable

            Try
                Me.cboState.ClearItems()

                dTB = Me._objAIGProduceShip.GetStates(iCntry_ID)

                If dTB.Rows.Count > 0 Then
                    Misc.PopulateC1DropDownList(Me.cboState, dTB, "StateFull", "State_ID")
                    Me.cboState.SelectedValue = iState_ID
                End If

                dTB = Nothing

            Catch ex As Exception
                MessageBox.Show(ex.ToString, " PopulateStates", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try

        End Sub


        '*********************************************************
        Private Sub PopulateStates4AddNew(ByVal iCntry_ID As Integer, _
                                          ByVal strExcludedStateIDs As String, _
                                          ByVal bHasStates As Boolean)
            Dim row As DataRow
            Dim i, iCnt As Integer
            Dim dTB As DataTable

            Try
                Me.cboState.ClearItems()

                dTB = Me._objAIGProduceShip.GetStates_Filtered(iCntry_ID, strExcludedStateIDs)

                If dTB.Rows.Count > 0 Then
                    iCnt = Me._iDefSelectVal
                    row = dTB.NewRow
                    row("State_ID") = iCnt
                    row("StateFull") = "Select a state"
                    dTB.Rows.Add(row)
                    Misc.PopulateC1DropDownList(Me.cboState, dTB, "StateFull", "State_ID")
                    Me.cboState.SelectedValue = iCnt
                    bHasStates = True
                Else
                    bHasStates = False
                End If

                dTB = Nothing

            Catch ex As Exception
                MessageBox.Show(ex.ToString, " PopulateStates4AddNew", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try

        End Sub


        '*********************************************************
        Private Sub rbnEdit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbnEdit.CheckedChanged
            Try
                If rbnEdit.Checked Then
                    Dim f As New Font("Arial", 9, FontStyle.Bold)
                    Dim f2 As New Font("Arial", 9, FontStyle.Regular)
                    Me.txtShipDays.ReadOnly = False
                    Me.txtComment.ReadOnly = False
                    Me.cboCountry.ReadOnly = True
                    Me.cboState.ReadOnly = True
                    rbnEdit.ForeColor = Color.Red
                    rbnEdit.Font = f
                    rbnAddNew.ForeColor = Color.Black
                    rbnAddNew.Font = f2
                    Me.tdgData1.Enabled = True
                    Me.pnlDataEntry.Visible = False
                    Me.btnUpdate.ForeColor = Color.Purple
                    Me.btnUpdate.Font = f
                    Me.btnUpdate.Text = "Update"
                    Me.lblMsg.Text = ""

                    LoadData()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, " rbnEdit_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*********************************************************
        Private Sub rbnAddNew_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbnAddNew.CheckedChanged
            Try
                If rbnAddNew.Checked Then
                    Dim f As New Font("Arial", 9, FontStyle.Bold)
                    Dim f2 As New Font("Arial", 9, FontStyle.Regular)

                    Me.txtShipDays.ReadOnly = False
                    Me.txtComment.ReadOnly = False
                    Me.cboCountry.ReadOnly = True
                    Me.cboState.ReadOnly = False
                    rbnEdit.ForeColor = Color.Black
                    rbnEdit.Font = f2
                    rbnAddNew.ForeColor = Color.Red
                    rbnAddNew.Font = f
                    'Me.tdgData1.Enabled = False
                    Me.pnlDataEntry.Visible = True
                    Me.btnUpdate.ForeColor = Color.Red
                    Me.btnUpdate.Font = f
                    Me.btnUpdate.Text = "Add New"
                    Me.txtShipDays.Text = ""
                    Me.txtComment.Text = ""
                    Me.lblMsg.Text = ""

                    PopulateShipmentCarrier()
                    PopulateCountries()

                    UpdateGridData_States_SelectAddedRowForAddNew(0, 0)

                    ' PopulateStates4AddNew(Me.cboCountry.SelectedValue)

                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, " rbnEdit_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*********************************************************
        Private Sub UpdateGridData_States_SelectAddedRowForAddNew(Optional ByVal iSelectedRowID As Integer = 0, _
                                                                  Optional ByVal iAddedNewShipDay_ID As Integer = 0)

            Dim dt As DataTable, row As DataRow, idx As Integer = 0
            Dim ArrUniqueStateIDs As New ArrayList()
            Dim strStateIDs As String = "", i As Integer
            Dim bHasStateIDs As Boolean = False

            Try
                LoadData() 'reload it

                'Update states
                i = 0
                For idx = 0 To Me.tdgData1.RowCount - 1
                    If Not IsDBNull(Me.tdgData1.Columns("State_ID").CellText(idx)) Then
                        If Not ArrUniqueStateIDs.Contains(Me.tdgData1.Columns("State_ID").CellText(idx)) Then
                            ArrUniqueStateIDs.Add(Me.tdgData1.Columns("State_ID").CellText(idx))
                            If i = 0 Then
                                strStateIDs = Me.tdgData1.Columns("State_ID").CellText(idx)
                            Else
                                strStateIDs &= "," & Me.tdgData1.Columns("State_ID").CellText(idx)
                            End If
                            i += 1
                        End If
                    End If
                Next
                PopulateStates4AddNew(Me.cboCountry.SelectedValue, strStateIDs, bHasStateIDs)

                'Select this new row added
                If iSelectedRowID = 1 AndAlso iAddedNewShipDay_ID > 0 Then
                    For idx = 0 To Me.tdgData1.RowCount - 1
                        If Not IsDBNull(Me.tdgData1.Columns("State_ID").CellText(idx)) Then
                            If Me.tdgData1.Columns("ShipDay_ID").CellText(idx) = iAddedNewShipDay_ID Then
                                Me.tdgData1.SelectedRows.Add(idx)  'select this row
                                Exit For
                            End If
                        End If
                    Next
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub UpdateStatesForAddNew", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                dt = Nothing
            End Try
        End Sub

        '*********************************************************
        Private Sub LoadData()
            Dim dt As DataTable, row As DataRow, i As Integer = 0
            Try
                Me.tdgData1.DataSource = Nothing
                dt = Me._objAIGProduceShip.GetShipDaysAll(Me._iMenuCustID)
                If dt.Rows.Count > 0 Then
                    Me.tdgData1.DataSource = dt
                    For Each row In dt.Rows
                        i += 1
                        row.BeginEdit()
                        row("RowID") = i
                        row.AcceptChanges()
                        row.EndEdit()
                    Next
                    'Me.tdgData1.Splits(0).DisplayColumns("OrderName").Width = 120
                    ''Me.tdgData1.Splits(0).DisplayColumns("Retailer").Width = 60
                    'Me.tdgData1.Splits(0).DisplayColumns("Project_ID").Width = 50
                    'Me.tdgData1.Splits(0).DisplayColumns("Rep_ID").Width = 50
                    'Me.tdgData1.Splits(0).DisplayColumns("ZipCode").Width = 70
                    'Me.tdgData1.Splits(0).DisplayColumns("State").Width = 40
                    'Me.lblrecNum.Text = "Record No: " & dt.Rows.Count

                    Me.pnlDataEntry.Visible = True
                Else
                    Me.lblrecNum.Text = "No Data"
                    Me.pnlDataEntry.Visible = False
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub LoadOrderData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                dt = Nothing
            End Try
        End Sub

        '********************************************************************************
        Private Sub tdgData1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdgData1.MouseUp

            Try
                If Me.tdgData1.PointAt(e.X, e.Y) = C1.Win.C1TrueDBGrid.PointAtEnum.AtFilterBar AndAlso Me.rbnEdit.Checked Then
                    Me.pnlDataEntry.Visible = False
                    Exit Sub
                End If
                ' Dim rtype As C1.Win.C1TrueDBGrid.RowTypeEnum = Me.tdgData1.Splits(0).Rows(Me.tdgData1.Row).RowType
                ' MessageBox.Show(rtype.ToString)
                'MessageBox.Show(tdgData1(tdgData1.Row, tdgData1.Col).ToString())

                If Me.tdgData1.RowCount > 0 AndAlso Me.rbnEdit.Checked Then
                    UpdatePanelData()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "tdgData1_MouseUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub tdgData1_AfterFilter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles tdgData1.AfterFilter
            RefreshGridRecNumLabel()
        End Sub

        '********************************************************************************
        Private Sub tdgData1_AfterSort(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles tdgData1.AfterSort
            RefreshGridRecNumLabel()
        End Sub

        '********************************************************************************
        Private Sub RefreshGridRecNumLabel()
            Try
                If tdgData1.RowCount > 0 Then
                    Me.lblrecNum.Text = "Record No: " & Me.tdgData1.RowCount
                Else
                    Me.lblrecNum.Text = "No Data"
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "RefreshGridRecNumLabel", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub



        '********************************************************************************
        Private Sub UpdatePanelData(Optional ByVal rowIdx As Integer = 0)
            Try
                Dim iRowID As Integer = Me.tdgData1.Row
                ' MessageBox.Show("Me.tdgData1.Row=" & Me.tdgData1.Row)

                'Initial select row
                If rowIdx > 0 Then iRowID = rowIdx
                Me.tdgData1.SelectedRows.Add(iRowID) 'select current row

                'Update panel data
                If Not IsDBNull(Me.tdgData1.Columns("ShipDay_ID").CellText(iRowID)) Then
                    Me._iShipDayID = Me.tdgData1.Columns("ShipDay_ID").CellText(iRowID)
                Else
                    MessageBox.Show("Failed to get ShipDay ID!", "UpdateDetailOrderData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                If Not IsDBNull(Me.tdgData1.Columns("State_ID").CellText(iRowID)) Then
                    Me._iOldStateID = Me.tdgData1.Columns("State_ID").CellText(iRowID)
                Else
                    MessageBox.Show("Failed to get State ID!", "UpdateDetailOrderData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                If Not IsDBNull(Me.tdgData1.Columns("ShipDays").CellText(iRowID)) Then
                    Me._iOldShipDays = Me.tdgData1.Columns("ShipDays").CellText(iRowID)
                Else
                    MessageBox.Show("Failed to get Ship Days!", "UpdateDetailOrderData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                If Not IsDBNull(Me.tdgData1.Columns("SC_ID").CellText(iRowID)) Then
                    Me._iCarrierID = Me.tdgData1.Columns("SC_ID").CellText(iRowID)
                Else
                    MessageBox.Show("Failed to get Carrier ID!", "UpdateDetailOrderData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                If Not IsDBNull(Me.tdgData1.Columns("cntry_ID").CellText(iRowID)) Then
                    Me._iCountryID = Me.tdgData1.Columns("cntry_ID").CellText(iRowID)
                Else
                    MessageBox.Show("Failed to get Country ID!", "UpdateDetailOrderData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                If Not IsDBNull(Me.tdgData1.Columns("Comment").CellText(iRowID)) Then
                    Me.txtComment.Text = Me.tdgData1.Columns("Comment").CellText(iRowID)
                    Me._strOldComment = Me.tdgData1.Columns("Comment").CellText(iRowID)
                End If

                Me.cboCarrier.SelectedValue = Me._iCarrierID
                Me.cboCountry.SelectedValue = Me._iCountryID
                Me.cboCustomers.SelectedValue = Me._iMenuCustID
                PopulateStates(Me._iCountryID, Me._iOldStateID)
                Me.txtShipDays.Text = Me._iOldShipDays

                Me.pnlDataEntry.Visible = True
                Me.txtShipDays.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "UpdatePanelData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub

        '********************************************************************************
        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

            Dim i As Integer = 0

            Try
                Me.lblMsg.Text = ""

                'Update----------------------------------------------------------------------------------------------
                If Me.rbnEdit.Checked Then
                    If Not (Me.txtShipDays.Text.Trim.Length > 0) Then
                        MessageBox.Show("Please enter valid ship days!", "btnUpdate_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtShipDays.SelectAll() : Exit Sub
                    ElseIf Not (IsNumeric(Me.txtShipDays.Text)) Then
                        MessageBox.Show("Please enter valid ship days!", "btnUpdate_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtShipDays.SelectAll() : Exit Sub
                    ElseIf Not (Me.txtShipDays.Text > 0) Then
                        MessageBox.Show("Please enter valid ship days!", "btnUpdate_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtShipDays.SelectAll() : Exit Sub
                    End If

                    If Me._iOldShipDays <> Me.txtShipDays.Text Or _
                       Me._strOldComment <> Me.txtComment.Text.Trim Then
                        MessageBox.Show("Update it now!", "btnUpdate_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        i = Me._objAIGProduceShip.UpdatePssiToStateShipDays(Me._iShipDayID, Me.txtShipDays.Text, Me.txtComment.Text.Trim)
                        If i > 0 Then
                            Me.lblMsg.Text = "Successfully updated!"
                            Me._iOldShipDays = Me.txtShipDays.Text
                            Me._strOldComment = Me.txtComment.Text.Trim
                        Else
                            Me.lblMsg.Text = "Failed to update!"
                        End If
                        LoadData() 'refresh
                    End If


                End If

                'Add new---------------------------------------------------------------------------------------
                If Me.rbnAddNew.Checked Then
                    If Not (Me.cboCarrier.SelectedValue > 0) Then
                        MessageBox.Show("No valid carrier!", "btnUpdate_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                    If Not (Me.cboCountry.SelectedValue > 0) Then
                        MessageBox.Show("No valid country!", "btnUpdate_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                    If Me.cboState.SelectedValue = Me._iDefSelectVal Or _
                       Not (Me.cboState.SelectedValue > 0) Then
                        MessageBox.Show("Please select a state!", "btnUpdate_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                    If Not (Me.txtShipDays.Text.Trim.Length > 0) Then
                        MessageBox.Show("Please enter valid ship days!", "btnUpdate_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtShipDays.SelectAll() : Exit Sub
                    ElseIf Not (IsNumeric(Me.txtShipDays.Text)) Then
                        MessageBox.Show("Please enter valid ship days!", "btnUpdate_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtShipDays.SelectAll() : Exit Sub
                    ElseIf Not (Me.txtShipDays.Text > 0) Then
                        MessageBox.Show("Please enter valid ship days!", "btnUpdate_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtShipDays.SelectAll() : Exit Sub
                    End If

                    If Not Me._objAIGProduceShip.PssiToStateShipDays_Duplicate(Me._iMenuCustID, Me.cboState.SelectedValue, Me.cboCarrier.SelectedValue) Then
                        Me._iShipDayID = Me._objAIGProduceShip.InsertPssiToStateShipDays(Me._iMenuCustID, Me.cboState.SelectedValue, Me.cboCarrier.SelectedValue, Me.txtShipDays.Text, Me.txtComment.Text.Trim)
                        If Me._iShipDayID > 0 Then
                            UpdateGridData_States_SelectAddedRowForAddNew(1, Me._iShipDayID)
                            Me.lblMsg.Text = "Successfully added!"
                        Else
                            Me.lblMsg.Text = "Failed to add!"
                        End If
                    Else
                        MessageBox.Show("Already exists! Can't add!", "btnUpdate_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnUpdate_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub

        '********************************************************************************
        Private Sub txtShipDays_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtShipDays.KeyPress
            Dim allowed As String = "0123456789"
            Dim curchar As Integer = Asc(e.KeyChar)

            If (allowed.IndexOf(e.KeyChar) = -1) And (curchar <> 8) Then
                e.Handled = True
            End If
        End Sub

        '********************************************************************************
        Private Sub txtShipDays_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtShipDays.KeyUp
            'Avoiding paste text into to the textbox or number with 0 at starting position
            If IsNumeric(Me.txtShipDays.Text) Then
                Dim iNum As Integer = Me.txtShipDays.Text
                If iNum > 0 Then
                    Me.txtShipDays.Text = iNum
                Else
                    Me.txtShipDays.Text = ""
                End If
            Else
                Me.txtShipDays.Text = ""
            End If
        End Sub
    End Class
End Namespace