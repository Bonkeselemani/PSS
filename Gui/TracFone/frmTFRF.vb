Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.TracFone
    Public Class frmTFRF
        Inherits System.Windows.Forms.Form

        Private _strScreenName As String = ""
        Private _iMenuCustID As Integer = 0
        Private _iTestTypeID As Integer = 0
        Private _objRF As PSS.Data.Buisness.TracFone.RFWrtyData
        Private _dtFailcodes As DataTable
        Private _iDevice_ID As Integer = 0
        Private _iManufID As Integer = 0
        Private _iModelID As Integer = 0
        Private _iRFResult As Integer = 0
        Private _iWCLocation_ID As Integer = 0
        Private _iGrpLineMap_ID As Integer = 0
        Private _iFuncRep As Integer = 0

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strSreenname As String, ByVal iCustID As Integer, ByVal iTestTypeID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _objRF = New PSS.Data.Buisness.TracFone.RFWrtyData()

            _strScreenName = strSreenname
            _iMenuCustID = iCustID
            _iTestTypeID = iTestTypeID
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
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents grdHistory As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents lblSN As System.Windows.Forms.Label
        Friend WithEvents btnSave As System.Windows.Forms.Button
        Friend WithEvents pnlFailCodes As System.Windows.Forms.Panel
        Friend WithEvents pnlMoveToStation As System.Windows.Forms.Panel
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents cmdRemove As System.Windows.Forms.Button
        Friend WithEvents lstFailCodes As System.Windows.Forms.ListBox
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents cboPFCodes As C1.Win.C1List.C1Combo
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents cboCustomers As C1.Win.C1List.C1Combo
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents lblMainInputName As System.Windows.Forms.Label
        Friend WithEvents txtDeviceSN As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents lblCostCenterDesc As System.Windows.Forms.Label
        Friend WithEvents btnFail As System.Windows.Forms.Button
        Friend WithEvents btnPass As System.Windows.Forms.Button
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents lblPretestTotal As System.Windows.Forms.Label
        Friend WithEvents lblTotalFailed As System.Windows.Forms.Label
        Friend WithEvents lblUserName As System.Windows.Forms.Label
        Friend WithEvents lblWorkDate As System.Windows.Forms.Label
        Friend WithEvents lblShift As System.Windows.Forms.Label
        Friend WithEvents lblMachine As System.Windows.Forms.Label
        Friend WithEvents lblLineSide As System.Windows.Forms.Label
        Friend WithEvents lblGroup As System.Windows.Forms.Label
        Friend WithEvents lblLine As System.Windows.Forms.Label
        Friend WithEvents Button2 As System.Windows.Forms.Button
        Friend WithEvents lblTotalPassed As System.Windows.Forms.Label
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents cboProduct As C1.Win.C1List.C1Combo
        Friend WithEvents lblDateCode As System.Windows.Forms.Label
        Friend WithEvents lblWrtyStatus As System.Windows.Forms.Label
        Friend WithEvents lblDevRepType As System.Windows.Forms.Label
        Friend WithEvents cboMoveTo As C1.Win.C1List.C1Combo
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTFRF))
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.grdHistory = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.lblSN = New System.Windows.Forms.Label()
            Me.btnSave = New System.Windows.Forms.Button()
            Me.pnlFailCodes = New System.Windows.Forms.Panel()
            Me.pnlMoveToStation = New System.Windows.Forms.Panel()
            Me.cboMoveTo = New C1.Win.C1List.C1Combo()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.cmdRemove = New System.Windows.Forms.Button()
            Me.lstFailCodes = New System.Windows.Forms.ListBox()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.cboPFCodes = New C1.Win.C1List.C1Combo()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.cboProduct = New C1.Win.C1List.C1Combo()
            Me.cboCustomers = New C1.Win.C1List.C1Combo()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.lblMainInputName = New System.Windows.Forms.Label()
            Me.txtDeviceSN = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.lblCostCenterDesc = New System.Windows.Forms.Label()
            Me.btnFail = New System.Windows.Forms.Button()
            Me.btnPass = New System.Windows.Forms.Button()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.lblPretestTotal = New System.Windows.Forms.Label()
            Me.lblTotalFailed = New System.Windows.Forms.Label()
            Me.lblUserName = New System.Windows.Forms.Label()
            Me.lblWorkDate = New System.Windows.Forms.Label()
            Me.lblShift = New System.Windows.Forms.Label()
            Me.lblMachine = New System.Windows.Forms.Label()
            Me.lblLineSide = New System.Windows.Forms.Label()
            Me.lblGroup = New System.Windows.Forms.Label()
            Me.lblLine = New System.Windows.Forms.Label()
            Me.Button2 = New System.Windows.Forms.Button()
            Me.lblTotalPassed = New System.Windows.Forms.Label()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.lblDateCode = New System.Windows.Forms.Label()
            Me.lblWrtyStatus = New System.Windows.Forms.Label()
            Me.lblDevRepType = New System.Windows.Forms.Label()
            Me.Panel3.SuspendLayout()
            CType(Me.grdHistory, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlFailCodes.SuspendLayout()
            Me.pnlMoveToStation.SuspendLayout()
            CType(Me.cboMoveTo, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboPFCodes, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            CType(Me.cboProduct, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel2.SuspendLayout()
            Me.SuspendLayout()
            '
            'Panel3
            '
            Me.Panel3.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel3.Controls.AddRange(New System.Windows.Forms.Control() {Me.grdHistory, Me.Label8, Me.lblSN})
            Me.Panel3.Location = New System.Drawing.Point(1, 185)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(799, 186)
            Me.Panel3.TabIndex = 7
            '
            'grdHistory
            '
            Me.grdHistory.GroupByCaption = "Drag a column header here to group by that column"
            Me.grdHistory.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.grdHistory.Location = New System.Drawing.Point(7, 37)
            Me.grdHistory.Name = "grdHistory"
            Me.grdHistory.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.grdHistory.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.grdHistory.PreviewInfo.ZoomFactor = 75
            Me.grdHistory.Size = New System.Drawing.Size(777, 141)
            Me.grdHistory.TabIndex = 14
            Me.grdHistory.Text = "C1TrueDBGrid1"
            Me.grdHistory.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Style9{}Normal{BackColor:LightSteelBlue;}HighlightRow{ForeColor:HighlightTex" & _
            "t;BackColor:Highlight;}Style12{}OddRow{}RecordSelector{AlignImage:Center;}Style1" & _
            "3{}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:Contro" & _
            "lText;BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style" & _
            "15{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView HBarHeight=""2" & _
            "4"" Name="""" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" M" & _
            "arqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidth=""16"" Vert" & _
            "icalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>137</Height><CaptionStyle " & _
            "parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenR" & _
            "owStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""St" & _
            "yle13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" m" & _
            "e=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle pa" & _
            "rent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /" & _
            "><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordS" & _
            "elector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style pa" & _
            "rent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 773, 137</ClientRect><BorderSide>0" & _
            "</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></" & _
            "Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""He" & _
            "ading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Capti" & _
            "on"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selecte" & _
            "d"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRo" & _
            "w"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" />" & _
            "<Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterB" & _
            "ar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSpli" & _
            "ts><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>16</Defaul" & _
            "tRecSelWidth><ClientArea>0, 0, 773, 137</ClientArea><PrintPageHeaderStyle parent" & _
            "="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'Label8
            '
            Me.Label8.BackColor = System.Drawing.Color.Transparent
            Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.Black
            Me.Label8.Location = New System.Drawing.Point(4, 7)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(137, 19)
            Me.Label8.TabIndex = 74
            Me.Label8.Text = "RF History for "
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblSN
            '
            Me.lblSN.BackColor = System.Drawing.Color.Transparent
            Me.lblSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSN.ForeColor = System.Drawing.Color.Red
            Me.lblSN.Location = New System.Drawing.Point(150, 7)
            Me.lblSN.Name = "lblSN"
            Me.lblSN.Size = New System.Drawing.Size(218, 19)
            Me.lblSN.TabIndex = 76
            Me.lblSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnSave
            '
            Me.btnSave.BackColor = System.Drawing.Color.Green
            Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSave.ForeColor = System.Drawing.Color.White
            Me.btnSave.Location = New System.Drawing.Point(648, 377)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(152, 79)
            Me.btnSave.TabIndex = 5
            Me.btnSave.Text = "SAVE (F5)"
            Me.btnSave.Visible = False
            '
            'pnlFailCodes
            '
            Me.pnlFailCodes.BackColor = System.Drawing.Color.LightSteelBlue
            Me.pnlFailCodes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlFailCodes.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlMoveToStation, Me.cmdRemove, Me.lstFailCodes, Me.Label7, Me.cboPFCodes})
            Me.pnlFailCodes.Location = New System.Drawing.Point(1, 372)
            Me.pnlFailCodes.Name = "pnlFailCodes"
            Me.pnlFailCodes.Size = New System.Drawing.Size(623, 165)
            Me.pnlFailCodes.TabIndex = 6
            Me.pnlFailCodes.Visible = False
            '
            'pnlMoveToStation
            '
            Me.pnlMoveToStation.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboMoveTo, Me.Label4})
            Me.pnlMoveToStation.Location = New System.Drawing.Point(416, -2)
            Me.pnlMoveToStation.Name = "pnlMoveToStation"
            Me.pnlMoveToStation.Size = New System.Drawing.Size(200, 56)
            Me.pnlMoveToStation.TabIndex = 2
            '
            'cboMoveTo
            '
            Me.cboMoveTo.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboMoveTo.Caption = ""
            Me.cboMoveTo.CaptionHeight = 17
            Me.cboMoveTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboMoveTo.ColumnCaptionHeight = 17
            Me.cboMoveTo.ColumnFooterHeight = 17
            Me.cboMoveTo.ContentHeight = 15
            Me.cboMoveTo.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboMoveTo.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboMoveTo.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboMoveTo.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboMoveTo.EditorHeight = 15
            Me.cboMoveTo.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboMoveTo.ItemHeight = 15
            Me.cboMoveTo.Location = New System.Drawing.Point(8, 24)
            Me.cboMoveTo.MatchEntryTimeout = CType(2000, Long)
            Me.cboMoveTo.MaxDropDownItems = CType(5, Short)
            Me.cboMoveTo.MaxLength = 32767
            Me.cboMoveTo.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboMoveTo.Name = "cboMoveTo"
            Me.cboMoveTo.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboMoveTo.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboMoveTo.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboMoveTo.Size = New System.Drawing.Size(184, 21)
            Me.cboMoveTo.TabIndex = 1
            Me.cboMoveTo.Text = "C1Combo1"
            Me.cboMoveTo.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.Black
            Me.Label4.Location = New System.Drawing.Point(8, 8)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(97, 16)
            Me.Label4.TabIndex = 123
            Me.Label4.Text = "Move To:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cmdRemove
            '
            Me.cmdRemove.BackColor = System.Drawing.Color.SteelBlue
            Me.cmdRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdRemove.ForeColor = System.Drawing.Color.White
            Me.cmdRemove.Location = New System.Drawing.Point(416, 119)
            Me.cmdRemove.Name = "cmdRemove"
            Me.cmdRemove.Size = New System.Drawing.Size(84, 37)
            Me.cmdRemove.TabIndex = 3
            Me.cmdRemove.Text = "REMOVE"
            '
            'lstFailCodes
            '
            Me.lstFailCodes.Location = New System.Drawing.Point(8, 48)
            Me.lstFailCodes.Name = "lstFailCodes"
            Me.lstFailCodes.Size = New System.Drawing.Size(400, 108)
            Me.lstFailCodes.TabIndex = 4
            '
            'Label7
            '
            Me.Label7.BackColor = System.Drawing.Color.Transparent
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.Black
            Me.Label7.Location = New System.Drawing.Point(9, 6)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(84, 16)
            Me.Label7.TabIndex = 71
            Me.Label7.Text = "Fail Code:"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cboPFCodes
            '
            Me.cboPFCodes.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboPFCodes.Caption = ""
            Me.cboPFCodes.CaptionHeight = 17
            Me.cboPFCodes.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboPFCodes.ColumnCaptionHeight = 17
            Me.cboPFCodes.ColumnFooterHeight = 17
            Me.cboPFCodes.ContentHeight = 15
            Me.cboPFCodes.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboPFCodes.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboPFCodes.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboPFCodes.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboPFCodes.EditorHeight = 15
            Me.cboPFCodes.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboPFCodes.ItemHeight = 15
            Me.cboPFCodes.Location = New System.Drawing.Point(8, 22)
            Me.cboPFCodes.MatchEntryTimeout = CType(2000, Long)
            Me.cboPFCodes.MaxDropDownItems = CType(5, Short)
            Me.cboPFCodes.MaxLength = 32767
            Me.cboPFCodes.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboPFCodes.Name = "cboPFCodes"
            Me.cboPFCodes.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboPFCodes.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboPFCodes.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboPFCodes.Size = New System.Drawing.Size(400, 21)
            Me.cboPFCodes.TabIndex = 1
            Me.cboPFCodes.Text = "C1Combo1"
            Me.cboPFCodes.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboProduct, Me.cboCustomers, Me.Label1, Me.lblMainInputName, Me.txtDeviceSN, Me.Label2, Me.lblCostCenterDesc})
            Me.Panel1.Location = New System.Drawing.Point(1, 73)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(335, 113)
            Me.Panel1.TabIndex = 1
            '
            'cboProduct
            '
            Me.cboProduct.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboProduct.Caption = ""
            Me.cboProduct.CaptionHeight = 17
            Me.cboProduct.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboProduct.ColumnCaptionHeight = 17
            Me.cboProduct.ColumnFooterHeight = 17
            Me.cboProduct.ContentHeight = 15
            Me.cboProduct.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboProduct.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboProduct.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboProduct.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboProduct.EditorHeight = 15
            Me.cboProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboProduct.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.cboProduct.ItemHeight = 15
            Me.cboProduct.Location = New System.Drawing.Point(104, 56)
            Me.cboProduct.MatchEntryTimeout = CType(2000, Long)
            Me.cboProduct.MaxDropDownItems = CType(5, Short)
            Me.cboProduct.MaxLength = 32767
            Me.cboProduct.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboProduct.Name = "cboProduct"
            Me.cboProduct.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboProduct.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboProduct.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboProduct.Size = New System.Drawing.Size(224, 21)
            Me.cboProduct.TabIndex = 2
            Me.cboProduct.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            "ts>1</horzSplits><Layout>Modified</Layout><DefaultRecSelWidth>16</DefaultRecSelW" & _
            "idth></Blob>"
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
            Me.cboCustomers.Location = New System.Drawing.Point(104, 28)
            Me.cboCustomers.MatchEntryTimeout = CType(2000, Long)
            Me.cboCustomers.MaxDropDownItems = CType(5, Short)
            Me.cboCustomers.MaxLength = 32767
            Me.cboCustomers.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCustomers.Name = "cboCustomers"
            Me.cboCustomers.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCustomers.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCustomers.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCustomers.Size = New System.Drawing.Size(224, 21)
            Me.cboCustomers.TabIndex = 1
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
            "ts>1</horzSplits><Layout>Modified</Layout><DefaultRecSelWidth>16</DefaultRecSelW" & _
            "idth></Blob>"
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Black
            Me.Label1.Location = New System.Drawing.Point(0, 32)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(96, 16)
            Me.Label1.TabIndex = 123
            Me.Label1.Text = "Customer:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblMainInputName
            '
            Me.lblMainInputName.BackColor = System.Drawing.Color.Transparent
            Me.lblMainInputName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMainInputName.ForeColor = System.Drawing.Color.Black
            Me.lblMainInputName.Location = New System.Drawing.Point(0, 84)
            Me.lblMainInputName.Name = "lblMainInputName"
            Me.lblMainInputName.Size = New System.Drawing.Size(93, 19)
            Me.lblMainInputName.TabIndex = 114
            Me.lblMainInputName.Text = "Device SN:"
            Me.lblMainInputName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDeviceSN
            '
            Me.txtDeviceSN.BackColor = System.Drawing.Color.Khaki
            Me.txtDeviceSN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtDeviceSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDeviceSN.Location = New System.Drawing.Point(104, 84)
            Me.txtDeviceSN.Name = "txtDeviceSN"
            Me.txtDeviceSN.Size = New System.Drawing.Size(224, 20)
            Me.txtDeviceSN.TabIndex = 0
            Me.txtDeviceSN.Tag = ""
            Me.txtDeviceSN.Text = ""
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.Black
            Me.Label2.Location = New System.Drawing.Point(0, 56)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(96, 16)
            Me.Label2.TabIndex = 122
            Me.Label2.Text = "Product Type:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCostCenterDesc
            '
            Me.lblCostCenterDesc.BackColor = System.Drawing.Color.Transparent
            Me.lblCostCenterDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCostCenterDesc.ForeColor = System.Drawing.Color.Blue
            Me.lblCostCenterDesc.Location = New System.Drawing.Point(8, 2)
            Me.lblCostCenterDesc.Name = "lblCostCenterDesc"
            Me.lblCostCenterDesc.Size = New System.Drawing.Size(320, 22)
            Me.lblCostCenterDesc.TabIndex = 122
            Me.lblCostCenterDesc.Text = "Cost Center H"
            Me.lblCostCenterDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnFail
            '
            Me.btnFail.BackColor = System.Drawing.Color.Red
            Me.btnFail.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnFail.ForeColor = System.Drawing.Color.White
            Me.btnFail.Location = New System.Drawing.Point(512, 80)
            Me.btnFail.Name = "btnFail"
            Me.btnFail.Size = New System.Drawing.Size(168, 63)
            Me.btnFail.TabIndex = 3
            Me.btnFail.Text = "FAIL(F12)"
            '
            'btnPass
            '
            Me.btnPass.BackColor = System.Drawing.Color.SteelBlue
            Me.btnPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPass.ForeColor = System.Drawing.Color.White
            Me.btnPass.Location = New System.Drawing.Point(344, 80)
            Me.btnPass.Name = "btnPass"
            Me.btnPass.Size = New System.Drawing.Size(152, 63)
            Me.btnPass.TabIndex = 2
            Me.btnPass.Tag = "2515"
            Me.btnPass.Text = "PASS      (F9)"
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Black
            Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.Yellow
            Me.Label3.Location = New System.Drawing.Point(1, 1)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(159, 71)
            Me.Label3.TabIndex = 129
            Me.Label3.Text = "RF"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Panel2
            '
            Me.Panel2.BackColor = System.Drawing.Color.Black
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblPretestTotal, Me.lblTotalFailed, Me.lblUserName, Me.lblWorkDate, Me.lblShift, Me.lblMachine, Me.lblLineSide, Me.lblGroup, Me.lblLine, Me.Button2, Me.lblTotalPassed})
            Me.Panel2.Location = New System.Drawing.Point(160, 1)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(640, 71)
            Me.Panel2.TabIndex = 130
            '
            'lblPretestTotal
            '
            Me.lblPretestTotal.BackColor = System.Drawing.Color.Black
            Me.lblPretestTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPretestTotal.ForeColor = System.Drawing.Color.Lime
            Me.lblPretestTotal.Location = New System.Drawing.Point(408, 41)
            Me.lblPretestTotal.Name = "lblPretestTotal"
            Me.lblPretestTotal.Size = New System.Drawing.Size(224, 19)
            Me.lblPretestTotal.TabIndex = 102
            Me.lblPretestTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblTotalFailed
            '
            Me.lblTotalFailed.BackColor = System.Drawing.Color.Black
            Me.lblTotalFailed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTotalFailed.ForeColor = System.Drawing.Color.Lime
            Me.lblTotalFailed.Location = New System.Drawing.Point(408, 24)
            Me.lblTotalFailed.Name = "lblTotalFailed"
            Me.lblTotalFailed.Size = New System.Drawing.Size(224, 18)
            Me.lblTotalFailed.TabIndex = 101
            Me.lblTotalFailed.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblUserName
            '
            Me.lblUserName.BackColor = System.Drawing.Color.Transparent
            Me.lblUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblUserName.ForeColor = System.Drawing.Color.Lime
            Me.lblUserName.Location = New System.Drawing.Point(208, 6)
            Me.lblUserName.Name = "lblUserName"
            Me.lblUserName.Size = New System.Drawing.Size(190, 19)
            Me.lblUserName.TabIndex = 100
            Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblWorkDate
            '
            Me.lblWorkDate.BackColor = System.Drawing.Color.Transparent
            Me.lblWorkDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWorkDate.ForeColor = System.Drawing.Color.Lime
            Me.lblWorkDate.Location = New System.Drawing.Point(208, 24)
            Me.lblWorkDate.Name = "lblWorkDate"
            Me.lblWorkDate.Size = New System.Drawing.Size(190, 18)
            Me.lblWorkDate.TabIndex = 99
            Me.lblWorkDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblShift
            '
            Me.lblShift.BackColor = System.Drawing.Color.Transparent
            Me.lblShift.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblShift.ForeColor = System.Drawing.Color.Lime
            Me.lblShift.Location = New System.Drawing.Point(208, 41)
            Me.lblShift.Name = "lblShift"
            Me.lblShift.Size = New System.Drawing.Size(190, 19)
            Me.lblShift.TabIndex = 98
            Me.lblShift.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblMachine
            '
            Me.lblMachine.BackColor = System.Drawing.Color.Transparent
            Me.lblMachine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMachine.ForeColor = System.Drawing.Color.Lime
            Me.lblMachine.Location = New System.Drawing.Point(3, 41)
            Me.lblMachine.Name = "lblMachine"
            Me.lblMachine.Size = New System.Drawing.Size(191, 19)
            Me.lblMachine.TabIndex = 97
            Me.lblMachine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblLineSide
            '
            Me.lblLineSide.BackColor = System.Drawing.Color.Transparent
            Me.lblLineSide.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLineSide.ForeColor = System.Drawing.Color.Lime
            Me.lblLineSide.Location = New System.Drawing.Point(59, 24)
            Me.lblLineSide.Name = "lblLineSide"
            Me.lblLineSide.Size = New System.Drawing.Size(65, 18)
            Me.lblLineSide.TabIndex = 96
            Me.lblLineSide.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblGroup
            '
            Me.lblGroup.BackColor = System.Drawing.Color.Transparent
            Me.lblGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblGroup.ForeColor = System.Drawing.Color.Lime
            Me.lblGroup.Location = New System.Drawing.Point(3, 6)
            Me.lblGroup.Name = "lblGroup"
            Me.lblGroup.Size = New System.Drawing.Size(191, 19)
            Me.lblGroup.TabIndex = 95
            Me.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblLine
            '
            Me.lblLine.BackColor = System.Drawing.Color.Transparent
            Me.lblLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLine.ForeColor = System.Drawing.Color.Lime
            Me.lblLine.Location = New System.Drawing.Point(3, 24)
            Me.lblLine.Name = "lblLine"
            Me.lblLine.Size = New System.Drawing.Size(66, 18)
            Me.lblLine.TabIndex = 94
            Me.lblLine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Button2
            '
            Me.Button2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Button2.Location = New System.Drawing.Point(168, 286)
            Me.Button2.Name = "Button2"
            Me.Button2.Size = New System.Drawing.Size(234, 37)
            Me.Button2.TabIndex = 66
            Me.Button2.TabStop = False
            Me.Button2.Text = "Generate Report"
            '
            'lblTotalPassed
            '
            Me.lblTotalPassed.BackColor = System.Drawing.Color.Black
            Me.lblTotalPassed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTotalPassed.ForeColor = System.Drawing.Color.Lime
            Me.lblTotalPassed.Location = New System.Drawing.Point(408, 6)
            Me.lblTotalPassed.Name = "lblTotalPassed"
            Me.lblTotalPassed.Size = New System.Drawing.Size(224, 19)
            Me.lblTotalPassed.TabIndex = 84
            Me.lblTotalPassed.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnClear
            '
            Me.btnClear.BackColor = System.Drawing.Color.SteelBlue
            Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClear.ForeColor = System.Drawing.Color.White
            Me.btnClear.Location = New System.Drawing.Point(696, 80)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(104, 63)
            Me.btnClear.TabIndex = 4
            Me.btnClear.Text = "CLEAR     (ESC)"
            '
            'lblDateCode
            '
            Me.lblDateCode.BackColor = System.Drawing.Color.Black
            Me.lblDateCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblDateCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDateCode.ForeColor = System.Drawing.Color.Lime
            Me.lblDateCode.Location = New System.Drawing.Point(696, 152)
            Me.lblDateCode.Name = "lblDateCode"
            Me.lblDateCode.Size = New System.Drawing.Size(104, 32)
            Me.lblDateCode.TabIndex = 132
            Me.lblDateCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.lblDateCode.Visible = False
            '
            'lblWrtyStatus
            '
            Me.lblWrtyStatus.BackColor = System.Drawing.Color.Black
            Me.lblWrtyStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblWrtyStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWrtyStatus.ForeColor = System.Drawing.Color.Lime
            Me.lblWrtyStatus.Location = New System.Drawing.Point(512, 152)
            Me.lblWrtyStatus.Name = "lblWrtyStatus"
            Me.lblWrtyStatus.Size = New System.Drawing.Size(168, 32)
            Me.lblWrtyStatus.TabIndex = 131
            Me.lblWrtyStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.lblWrtyStatus.Visible = False
            '
            'lblDevRepType
            '
            Me.lblDevRepType.BackColor = System.Drawing.Color.Black
            Me.lblDevRepType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblDevRepType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDevRepType.ForeColor = System.Drawing.Color.Lime
            Me.lblDevRepType.Location = New System.Drawing.Point(344, 152)
            Me.lblDevRepType.Name = "lblDevRepType"
            Me.lblDevRepType.Size = New System.Drawing.Size(152, 32)
            Me.lblDevRepType.TabIndex = 133
            Me.lblDevRepType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.lblDevRepType.Visible = False
            '
            'frmTFRF
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(808, 549)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblDevRepType, Me.lblDateCode, Me.lblWrtyStatus, Me.Panel3, Me.btnSave, Me.pnlFailCodes, Me.Panel1, Me.btnFail, Me.btnPass, Me.Label3, Me.Panel2, Me.btnClear})
            Me.Name = "frmTFRF"
            Me.Text = "frmTFRF"
            Me.Panel3.ResumeLayout(False)
            CType(Me.grdHistory, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlFailCodes.ResumeLayout(False)
            Me.pnlMoveToStation.ResumeLayout(False)
            CType(Me.cboMoveTo, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboPFCodes, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            CType(Me.cboProduct, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel2.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        '******************************************************************
        Private Sub frmTFRF_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim i As Integer = 0
            Dim iCustID As Integer = 0
            Dim dt As DataTable
            Dim objPreTest As New PSS.Data.Buisness.PreTest()

            Try
                i = CheckIfMachineTiedToLine()

                If i = 0 Then
                    MessageBox.Show("Machine is not associated with any 'Line'. Can't continue.", "Check Machine Mapping", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.Close()
                End If

                '****************************************
                'Load Customer
                '***************************************
                iCustID = Generic.GetCustIDByMachine()
                Me.cboCustomers.DataSource = Nothing
                dt = Generic.GetCustomers(True, Me.cboProduct.SelectedValue)
                Misc.PopulateC1DropDownList(Me.cboCustomers, dt, "Cust_Name1", "Cust_ID")
                Me.cboCustomers.SelectedValue = iCustID

                If _iMenuCustID > 0 Then
                    If Me._iMenuCustID = PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID Then
                        dt = objPreTest.GetMoveToFailStation(False, False, True, True)
                        Misc.PopulateC1DropDownList(Me.cboMoveTo, dt, "ToStation", "ID")
                        Me.cboMoveTo.SelectedValue = 0
                        Me.pnlMoveToStation.Visible = True
                    End If

                    Me.cboCustomers.Enabled = False
                End If

                '********************
                'Load Product type
                '********************
                dt = Generic.GetProductByCustID(True, Me._iMenuCustID)
                Me.cboProduct.DataSource = Nothing
                Misc.PopulateC1DropDownList(Me.cboProduct, dt, "Prod_Desc", "Prod_ID")
                If dt.Rows.Count = 2 Then
                    Me.cboProduct.SelectedValue = dt.Rows(0)("Prod_ID")
                    Me.cboProduct.Enabled = False
                End If

                '***************************
                'Define Fail code datatable
                '***************************
                Me._dtFailcodes = New DataTable()
                Generic.AddNewColumnToDataTable(Me._dtFailcodes, "Fail_ID", "System.Int32", )
                Generic.AddNewColumnToDataTable(Me._dtFailcodes, "Fail_LDesc", "System.String", )
                Generic.AddNewColumnToDataTable(Me._dtFailcodes, "trftest_id", "System.Int32", "0")    '0:Add 1:Delete

                '***************************
                If _iTestTypeID <> 11 Then LoadPFCodes()

                Me.LoadUserPassFailNumber()

                If Me._iMenuCustID = PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID Then Me.lblMainInputName.Text = "IMEI/MEID:"
                btnFail.BackColor = System.Drawing.Color.SteelBlue
                Me.Label3.Text = _strScreenName
                Me.txtDeviceSN.Focus()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error in FormLoad")
            Finally
                objPreTest = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '*****************************************************************
        Private Function CheckIfMachineTiedToLine() As Integer
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim objMisc As New PSS.Data.Buisness.Misc()

            Try
                dt1 = objMisc.CheckIfMachineTiedToLine(System.Net.Dns.GetHostName)
                If dt1.Rows.Count = 0 Then
                    Return 0
                End If

                'Me.lblGroup.Text = "Group: " & dt1.Rows(0)("Group_Desc")
                'Me.lblGroup.Tag = dt1.Rows(0)("Group_ID")
                Me.lblGroup.Text = "Group: " & dt1.Rows(0)("CC_Group_Desc")
                Me.lblGroup.Tag = dt1.Rows(0)("CC_Group_ID")
                Me.lblLine.Text = dt1.Rows(0)("Line_Number")
                Me.lblLine.Tag = dt1.Rows(0)("Line_ID")
                Me.lblLineSide.Text = dt1.Rows(0)("LineSide_Desc")
                Me._iWCLocation_ID = dt1.Rows(0)("WCLocation_ID")
                Me._iGrpLineMap_ID = dt1.Rows(0)("GrpLineMap_ID")
                Me.lblMachine.Text = "Machine: " & System.Net.Dns.GetHostName
                Me.lblUserName.Text = "User: " & PSS.Core.[Global].ApplicationUser.User
                Me.lblUserName.Tag = PSS.Core.[Global].ApplicationUser.IDuser
                Me.lblShift.Text = "Shift: " & PSS.Core.[Global].ApplicationUser.IDShift
                Me.lblWorkDate.Tag = PSS.Core.[Global].ApplicationUser.Workdate
                Me.lblWorkDate.Text = "Work Date: " & Format(CDate(Me.lblWorkDate.Tag), "MM/dd/yyyy")
                Me.lblCostCenterDesc.Text = "Cost Center " & dt1.Rows(0)("CostCenter")
                'Me._icc_id = dt1.Rows(0)("cc_id")

                If dt1.Rows(0)("Group_ID") = 0 Then
                    MessageBox.Show("Machine does not map to any group, line and side.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    If MainWin.MainWin.wrkArea.TabPages.Count > 0 Then
                        MainWin.MainWin.wrkArea.TabPages.RemoveAt(MainWin.MainWin.wrkArea.SelectedIndex)
                    Else
                        MainWin.MainWin.wrkArea.TabPages.Clear()
                    End If
                ElseIf dt1.Rows(0)("CC_Group_ID") = 0 Then
                    MessageBox.Show("Machine does not map to any cost center.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    If MainWin.MainWin.wrkArea.TabPages.Count > 0 Then
                        MainWin.MainWin.wrkArea.TabPages.RemoveAt(MainWin.MainWin.wrkArea.SelectedIndex)
                    Else
                        MainWin.MainWin.wrkArea.TabPages.Clear()
                    End If
                ElseIf dt1.Rows(0)("Group_ID") <> dt1.Rows(0)("CC_Group_ID") Then
                    MessageBox.Show("Group of line and group of cost center are not the same. Please correct the mapping.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    If MainWin.MainWin.wrkArea.TabPages.Count > 0 Then
                        MainWin.MainWin.wrkArea.TabPages.RemoveAt(MainWin.MainWin.wrkArea.SelectedIndex)
                    Else
                        MainWin.MainWin.wrkArea.TabPages.Clear()
                    End If
                ElseIf Me._iMenuCustID > 0 AndAlso Not IsDBNull(dt1.Rows(0)("CCG_CustID")) Then
                    If Me._iMenuCustID <> dt1.Rows(0)("CCG_CustID") Then
                        MessageBox.Show("This screen is not designed to work for the current mapped group.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        If MainWin.MainWin.wrkArea.TabPages.Count > 0 Then
                            MainWin.MainWin.wrkArea.TabPages.RemoveAt(MainWin.MainWin.wrkArea.SelectedIndex)
                        Else
                            MainWin.MainWin.wrkArea.TabPages.Clear()
                        End If
                    End If
                End If

                Return 1
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                objMisc = Nothing
            End Try
        End Function

        '******************************************************************
        Private Sub btnPass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPass.Click
            Me.PassTest()
        End Sub

        Private Sub btnFail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFail.Click
            Me.FailTest()
        End Sub

        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
            Try
                Me.Clear(False)
                Me.txtDeviceSN.Focus()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error in btnClear_Click")
            End Try
        End Sub

        Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
            If Me._iDevice_ID = 0 Then
                Me.txtDeviceSN.Focus()
                Exit Sub
            End If
            SaveTestInfo()
        End Sub

        Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click
            Dim strFailCode As String = ""
            Dim R1 As DataRow
            Dim booRefestHistory As Boolean = False

            Try
                If Me.lstFailCodes.SelectedIndex <> -1 Then    'If nothing is selected
                    strFailCode = Me.lstFailCodes.Items.Item(Me.lstFailCodes.SelectedIndex).ToString
                    For Each R1 In Me._dtFailcodes.Rows
                        If R1("Fail_LDesc") = strFailCode Then
                            If R1("trftest_id") > 0 Then
                                Me._objRF.DeletePretestDataByPretestID(R1("trftest_id"))
                                booRefestHistory = True
                            End If
                            R1.Delete()
                            Exit For
                        End If
                    Next R1
                    Me._dtFailcodes.AcceptChanges()

                    Me.lstFailCodes.Items.RemoveAt(Me.lstFailCodes.SelectedIndex)
                    Me.lstFailCodes.Refresh()

                    If booRefestHistory = True Then
                        Me.LoadTestHistory(Me._iDevice_ID)
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Remove Failure Code")
            Finally
                Me.cboPFCodes.Focus()
            End Try
        End Sub

        '*****************************************************************
        Private Sub Clear(ByVal booKeepDeviceInfoData As Boolean)
            Me.txtDeviceSN.Text = ""
            Me.btnPass.BackColor = Color.SteelBlue
            Me.btnFail.BackColor = Color.SteelBlue
            Me.btnClear.BackColor = Color.SteelBlue

            If booKeepDeviceInfoData = False Then
                Me.lblSN.Text = ""
                Me.lblDateCode.Text = ""
                Me.lblWrtyStatus.Text = ""
                Me.lblDevRepType.Text = ""
                Me.lblDateCode.Visible = False
                Me.lblWrtyStatus.Visible = False
                Me.lblDevRepType.Visible = False
                Me.grdHistory.DataSource = Nothing
            End If

            Me.pnlFailCodes.Visible = False
            Me.cboPFCodes.SelectedValue = 0
            Me.cboMoveTo.SelectedValue = 0
            Me.lstFailCodes.Items.Clear()
            Me.lstFailCodes.Refresh()
            Me.btnSave.Visible = False
            Me._dtFailcodes.Clear()
            Me._iDevice_ID = 0
            Me._iFuncRep = 0
            _iManufID = 0
            _iModelID = 0
        End Sub

        '*****************************************************************
        Private Sub AllControlsKeyupEvent(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboProduct.KeyUp, cboPFCodes.KeyUp, lstFailCodes.KeyUp, grdHistory.KeyUp, btnPass.KeyUp, btnFail.KeyUp, btnClear.KeyUp, btnSave.KeyUp, txtDeviceSN.KeyUp, cboMoveTo.KeyUp
            If e.KeyValue = 13 AndAlso sender.name = "txtDeviceSN" Then
                Me.ProcessSN()
            ElseIf e.KeyValue = Keys.Escape Then
                Me.Clear(False)
                Me.txtDeviceSN.Focus()
            ElseIf Me._iDevice_ID = 0 Then
                Me.txtDeviceSN.Focus()
            ElseIf e.KeyValue = Keys.F9 Then    'Pass
                PassTest()
            ElseIf e.KeyValue = Keys.F12 Then   'Fail
                FailTest()
                Me.cboPFCodes.Focus()
            ElseIf e.KeyValue = Keys.F5 Then    'Save
                SaveTestInfo()
                Me.txtDeviceSN.Focus()
            ElseIf e.KeyValue = 13 AndAlso sender.name = "cboPFCodes" AndAlso Me._iRFResult = 2 Then
                AddFailCode(sender.text.trim)
            End If
        End Sub

        '*****************************************************************
        Private Sub PassTest()
            If Me._iDevice_ID = 0 Then
                Me.txtDeviceSN.SelectAll()
                Me.txtDeviceSN.Focus()
                Exit Sub
            End If

            btnPass.BackColor = System.Drawing.Color.Red
            btnFail.BackColor = System.Drawing.Color.SteelBlue

            Me._iRFResult = 1
            pnlFailCodes.Visible = False
            Me.cboPFCodes.SelectedValue = 0
            Me.SaveTestInfo()
        End Sub

        '*****************************************************************
        Private Sub FailTest()
            If Me._iDevice_ID = 0 Then
                Me.txtDeviceSN.SelectAll()
                Me.txtDeviceSN.Focus()
                Exit Sub
            End If

            btnPass.BackColor = System.Drawing.Color.SteelBlue
            btnFail.BackColor = System.Drawing.Color.Red

            Me._iRFResult = 2

            If Me._iTestTypeID = 11 Then
                Me.SaveTestInfo()
            Else
                Me.btnSave.Visible = True
                pnlFailCodes.Visible = True
                Me.cboPFCodes.Focus()
            End If
        End Sub

        '*****************************************************************
        Private Sub ProcessSN()
            Dim objQC As New PSS.Data.Buisness.QC()
            Dim strSN As String = ""
            Dim strDevice_ccDesc As String = ""
            Dim dt1 As DataTable
            Dim strWorkStation As String = ""

            Try
                strSN = Me.txtDeviceSN.Text.Trim
                If Me.txtDeviceSN.Text.Trim.Length = 0 Then
                    Exit Sub
                End If

                If Me.cboCustomers.SelectedValue = 0 Then
                    MessageBox.Show("Please select customer.", "RF", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.cboCustomers.Focus()
                    Exit Sub
                End If

                Me.Clear(False)

                If Me.cboProduct.SelectedValue = 0 Then
                    MessageBox.Show("Please select Product.", "RF", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtDeviceSN.Text = strSN
                    Exit Sub
                ElseIf Me._iGrpLineMap_ID = 0 Or Me._iWCLocation_ID = 0 Then
                    MessageBox.Show("Group ID missing. This machine is not mapped to any Group.", "RF", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtDeviceSN.Text = strSN
                    Exit Sub
                End If

                'Check if this device is actually of the product type selected.
                If Me.cboProduct.SelectedValue <> objQC.GetDeviceProductType(strSN, Me.cboCustomers.SelectedValue) Then
                    MessageBox.Show("The device scanned in is not of the Product type selected on the screen.", "RF", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtDeviceSN.Text = strSN
                    Exit Sub
                End If

                '******************************************
                'Get Device info and model type(Wip down/Non-WipeDown)
                ''******************************************
                dt1 = Generic.GetDeviceInfoInWIP(strSN, Me.cboCustomers.SelectedValue)
                If dt1.Rows.Count = 1 Then
                    '******************************************
                    'tracfone only: check current station
                    '******************************************
                    If Me._iMenuCustID = PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID Then
                        strWorkStation = dt1.Rows(0)("WorkStation").ToString.Trim.ToUpper
                        If _iTestTypeID = 10 AndAlso strWorkStation.Trim.ToUpper <> Me._strScreenName.Trim.ToUpper Then
                            MessageBox.Show("This device belongs to " & strWorkStation & " workstation.", "RF", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.txtDeviceSN.Text = ""
                            Exit Sub
                        ElseIf strWorkStation.Trim.ToUpper <> Me._strScreenName.Trim.ToUpper AndAlso strWorkStation.Trim.ToUpper <> "PRODUCTION STAGING" Then
                            MessageBox.Show("This device belongs to " & strWorkStation & " workstation.", "RF", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.txtDeviceSN.Text = ""
                            Exit Sub
                        End If
                    End If

                    '******************************************
                    _iFuncRep = dt1.Rows(0)("FuncRep")
                    Me._iDevice_ID = dt1.Rows(0)("Device_ID")
                    _iManufID = dt1.Rows(0)("Manuf_ID")
                    _iModelID = dt1.Rows(0)("Model_ID")
                    Me.lblSN.Text = strSN

                    '****************************************************************
                    'Display Warranty status, Manufacture Date code and Repair type
                    '****************************************************************
                    If Me.cboCustomers.SelectedValue = 2258 Then
                        Me.lblDevRepType.Visible = True
                        If _iFuncRep = 1 Then Me.lblDevRepType.Text = "Functional" Else Me.lblDevRepType.Text = "Cosmetic"
                    End If

                    If dt1.Rows(0)("ManufDate").ToString.Trim.Length > 0 Then
                        Me.lblWrtyStatus.Visible = True
                        Me.lblDateCode.Visible = True
                        Me.lblDateCode.Text = dt1.Rows(0)("ManufDate")
                        If dt1.Rows(0)("Device_ManufWrty") Then Me.lblWrtyStatus.Text = "In Warranty" Else Me.lblWrtyStatus.Text = "Out of Warranty"
                    End If
                    '****************************************************************

                    Me.LoadTestHistory(Me._iDevice_ID)

                ElseIf dt1.Rows.Count = 0 Then
                    MessageBox.Show("Can't define Device SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    MessageBox.Show("Device exist more than one in WIP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error in ProcessSN")
                Me.Clear(False)
            Finally
                objQC = Nothing
            End Try
        End Sub

        '*****************************************************************
        Private Sub LoadPFCodes()
            Dim dt As DataTable

            Try
                If Me.cboProduct.SelectedValue = 0 Then
                    MsgBox("Please select product.", MsgBoxStyle.Critical, "Load Pretest Codes")
                    Exit Sub
                End If

                Me.cboPFCodes.DataSource = Nothing
                dt = Me._objRF.GetManufFailCodesList(Me.cboProduct.SelectedValue, True)

                If Not IsNothing(dt) Then
                    Misc.PopulateC1DropDownList(cboPFCodes, dt, "Fail_LDesc", "Fail_ID")
                    Me.cboPFCodes.SelectedValue = 0
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error in LoadPFCodes")
            End Try
        End Sub

        '*****************************************************************
        Private Sub LoadTestHistory(ByVal iDevice_ID As Integer)
            Dim dt1 As DataTable
            Dim i As Integer
            Dim R1 As DataRow

            Try
                '**********************************************
                'Get history data and populate data to controls and variable
                '**********************************************
                dt1 = Me._objRF.GetTestHistory(iDevice_ID, Me._iTestTypeID)

                If dt1.Rows.Count > 0 Then
                    '************************************************
                    'Set data grid layout
                    ''***********************************************
                    Me.grdHistory.DataSource = Nothing
                    Me.grdHistory.DataSource = dt1
                    Me.SetHistoryGridLayout(Me.grdHistory, _
                                                   Color.Black, _
                                                   New Integer() {80, 80, 70, 170, 170}, _
                                                   C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, _
                                                   New Integer() {C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, C1.Win.C1TrueDBGrid.AlignHorzEnum.Near}, _
                                                   New String() {"QCResult_ID", "Test_ID", "TD_UsrID", "completedTechUsrID", "Device_ID", "Fail_ID"}, )
                    '************************************************
                End If
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
            End Try
        End Sub

        '*****************************************************************
        Private Sub AddFailCode(ByVal strFailCode As String, _
                                Optional ByVal iTpretest_id As Integer = 0)
            Dim drNewRow As DataRow
            Dim i As Integer = 0

            Try
                If Me._iDevice_ID = 0 Then
                    Exit Sub
                End If

                ''***************************************
                ''Allow only 1 failed code for cellular
                ''***************************************
                'If Me.cboProduct.SelectedValue = 2 And Me.lstFailCodes.Items.Count >= 1 Then
                '    MessageBox.Show("Can't accept more one fail code for cellular product.", "Add Fail Code", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                '    Exit Sub
                'End If

                '***************************************
                'Allow only 1 failed code for cellular
                '***************************************
                If Me.cboPFCodes.SelectedValue = 0 Or Me.cboPFCodes.Text = "" Or Me.cboPFCodes.Text = "-- SELECT --" Then
                    MessageBox.Show("Please select a valid fail code.", "Add Fail Code", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                '*****************************
                'Check for duplicate in list
                '*****************************
                If Me.lstFailCodes.Items.IndexOf(strFailCode) > -1 Then
                    MsgBox("Code is already existed.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Add Fail Code")
                    Me.cboPFCodes.Focus()
                    Exit Sub
                End If

                '*****************************
                'Save 1 record at a time
                '*****************************
                If Me.lstFailCodes.Items.Count > 0 Then
                    MsgBox("Only one code can be selected.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Add Fail Code")
                    Me.cboPFCodes.Focus()
                    Exit Sub
                End If

                '***************************************
                'Add code
                '***************************************
                For i = 0 To Me.cboPFCodes.DataSource.Table.rows.Count - 1
                    If strFailCode = Me.cboPFCodes.DataSource.Table.rows(i)("Fail_LDesc") Then
                        Me.lstFailCodes.Items.Add(Me.cboPFCodes.DataSource.Table.rows(i)("Fail_LDesc"))
                        drNewRow = Me._dtFailcodes.NewRow
                        drNewRow("Fail_ID") = Me.cboPFCodes.DataSource.Table.rows(i)("Fail_ID")
                        drNewRow("Fail_LDesc") = Me.cboPFCodes.DataSource.Table.rows(i)("Fail_LDesc")
                        drNewRow("trftest_id") = iTpretest_id
                        Me._dtFailcodes.Rows.Add(drNewRow)
                        Me._dtFailcodes.AcceptChanges()
                        Exit For
                    End If
                Next i
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Add Failure Code")
            Finally
                drNewRow = Nothing
            End Try
        End Sub

        '*******************************************************************
        Private Sub SetHistoryGridLayout(ByRef grdCtrl As C1.Win.C1TrueDBGrid.C1TrueDBGrid, _
                                    ByVal clrHeaderForeColor As Color, _
                                    ByVal iArrColSize() As Integer, _
                                    ByVal iHeaderAlignment As Integer, _
                                    ByVal iArrColAlignment() As Integer, _
                                    ByVal strArrHideCol() As String, _
                                    Optional ByVal iGrandTotal As Integer = 0)
            Dim iNumOfColumns As Integer = grdCtrl.Columns.Count
            Dim i As Integer

            With grdCtrl
                'Heading style (Horizontal Alignment to Center)
                For i = 0 To iArrColSize.Length - 1
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = iHeaderAlignment 'C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    .Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = clrHeaderForeColor
                    .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = iArrColAlignment(i) 'C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    .Splits(0).DisplayColumns(i).Width = iArrColSize(i)
                Next i
                For i = 0 To strArrHideCol.Length - 1
                    .Splits(0).DisplayColumns(strArrHideCol(i)).Visible = False
                Next i
            End With
        End Sub

        '*****************************************************************
        Private Sub SaveTestInfo()
            Dim objACC As Data.Production.AssignCostCenter
            Dim i, iFuncRep As Integer
            Dim strFailCodes, strNextWrkStation As String
            Dim booSkipPSDStation As Boolean = False

            Try
                i = 0 : iFuncRep = 0 : strFailCodes = "" : strNextWrkStation = ""

                If Me.cboProduct.SelectedValue = 0 Then
                    MsgBox("Please select product.", MsgBoxStyle.Critical, "Load Pretest Codes")
                ElseIf Me._iDevice_ID = 0 Then
                    MsgBox("You must enter a device serial number.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Information")
                    Me.txtDeviceSN.Focus()
                ElseIf Me._iRFResult = 2 AndAlso Me._iTestTypeID <> 11 AndAlso (Me.lstFailCodes.Items.Count = 0 Or Me._dtFailcodes.Rows.Count = 0) Then
                    MsgBox("You must select a fail code.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Information")
                    Me.cboPFCodes.Focus()
                Else
                    'If Me._objPreTest.CheckPassFail(Me.cboPFCodes.SelectedValue, Me.txtDeviceSN.Text.Trim, Me._bChangePretestStatus) Then
                    If Me._iRFResult <> 0 Then
                        If Me._iMenuCustID = PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID Then
                            Dim objTFMis = New PSS.Data.Buisness.TracFone.clsMisc()
                            booSkipPSDStation = objTFMis.IsNoPSDNeeded(_iModelID)
                            objTFMis = Nothing
                            '***********************************************
                            'Get and assign unit to workstation for TracFone
                            '***********************************************
                            If cboMoveTo.SelectedValue <> 0 Then
                                strNextWrkStation = Me.cboMoveTo.Text
                            ElseIf Me._strScreenName = "PSD" AndAlso Me._iRFResult = 1 AndAlso Me._iManufID = 24 Then 'PSD station and Nokia 
                                strNextWrkStation = "SOFTWARE REFURBISH"
                                'ElseIf Me._strScreenName.Trim = "RF2" AndAlso Me._iRFResult = 1 AndAlso Me._iFuncRep = 1 Then
                                '    strNextWrkStation = "PSD"
                            ElseIf Me._strScreenName.Trim = "RF2" AndAlso Me._iRFResult = 1 AndAlso Me._iManufID = 24 AndAlso booSkipPSDStation = True Then
                                strNextWrkStation = "SOFTWARE REFURBISH"
                            ElseIf Me._strScreenName.Trim = "RF2" AndAlso Me._iRFResult = 1 AndAlso booSkipPSDStation = True Then
                                strNextWrkStation = "BOX"
                            ElseIf Me._strScreenName.Trim <> "RF1" AndAlso Me._iRFResult = 2 Then
                                strNextWrkStation = Generic.GetNextWorkStationInWFP(Me._strScreenName, 0, Me.cboCustomers.SelectedValue, 1, )
                            Else
                                strNextWrkStation = Generic.GetNextWorkStationInWFP(Me._strScreenName, 0, Me.cboCustomers.SelectedValue, , )
                            End If

                            '***********************************************
                            'Bill RUR code
                            '***********************************************
                            If _iRFResult = 2 AndAlso strNextWrkStation = "BER HOLD" Then
                                If SelectRURBillcode() = False Then Exit Sub
                            End If
                            '***********************************************
                            'Save RF Test Result
                            '***********************************************
                            If Me._objRF.InsertPFData(PSS.Core.[Global].ApplicationUser.IDuser, Me._iDevice_ID, Me._iTestTypeID, Me._dtFailcodes, Me._iRFResult, Me._strScreenName) Then
                                Me.LoadTestHistory(Me._iDevice_ID)
                                Me.LoadUserPassFailNumber()

                                '*************************
                                'Confirm message
                                '*************************
                                If strNextWrkStation.Trim.Length > 0 Then
                                    Generic.SetTcelloptWorkStationForDevice(strNextWrkStation, _iDevice_ID)
                                    MessageBox.Show("Results are saved. Unit has been pushed to " & strNextWrkStation & " workstation.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                Else
                                    MessageBox.Show("Results are saved.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                End If
                                '*************************
                                'Clear Data
                                '*************************
                                Me.Clear(True)
                            Else
                                Me.txtDeviceSN.SelectAll()
                            End If
                            '***********************************************
                        End If
                        '**********************************                       
                    Else
                        MsgBox("Please select either pass or fail.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Information")
                    End If

                    Me.txtDeviceSN.Focus()
                    'End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "SavePretestResult")
            Finally
                objACC = Nothing
            End Try
        End Sub

        '*****************************************************************
        Private Function SelectRURBillcode() As Boolean
            Dim objBillcodeWin As Gui.Billing.frmBillcodesSelection
            Dim booReturnVal As Boolean = False
            Try
                objBillcodeWin = New Gui.Billing.frmBillcodesSelection(Me._iDevice_ID, 1, 1, , )
                objBillcodeWin.ShowDialog()
                If objBillcodeWin._booCancel = False Then booReturnVal = True

                Return booReturnVal
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "SelectRURBillcode", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Function

        '*****************************************************************
        Private Sub LoadUserPassFailNumber()
            Dim iArr() As Integer

            Try
                If Me.cboProduct.SelectedValue = 0 Then
                    MsgBox("Please select product.", MsgBoxStyle.Critical, "Load Pretest Codes")
                    Exit Sub
                End If

                iArr = Me._objRF.GetLoadUserPassFailNumber(Me.cboProduct.SelectedValue, Me._iWCLocation_ID, PSS.Core.[Global].ApplicationUser.IDuser, Me.lblWorkDate.Tag)

                If Not IsNothing(iArr) Then
                    Me.lblTotalFailed.Text = "Total Passed: " & iArr(0).ToString
                    Me.lblTotalPassed.Text = "Total Failed: " & iArr(1).ToString.ToString
                    Me.lblPretestTotal.Text = "Total: " & (iArr(0) + iArr(1)).ToString
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Load User Pass/Fail Number")
            End Try
        End Sub

        '*****************************************************************

    End Class
End Namespace