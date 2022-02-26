Option Explicit On 

Imports System
Imports System.Data
'Imports System.ComponentModel


Namespace Gui

    Public Class TMIShipReturnLabel
        Inherits System.Windows.Forms.Form

        Public _strScreenName As String = ""
        Private _iCust_ID As Integer
        Private _iLoc_ID As Integer
        Private _iGroup_ID As Integer
        Private objTMI As PSS.Data.Buisness.TMI
        Private GiUserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
        Private _emptyBoxYes As Boolean = True

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName As String, ByVal Cust_ID As Integer, _
                        ByVal Loc_ID As Integer, ByVal Group_ID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._strScreenName = strScreenName
            Me._iCust_ID = Cust_ID
            Me._iLoc_ID = Loc_ID
            Me._iGroup_ID = Group_ID

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
        Friend WithEvents lblClaimNo As System.Windows.Forms.Label
        Friend WithEvents lblOutTrackNo As System.Windows.Forms.Label
        Friend WithEvents txtOutTrackNo As System.Windows.Forms.TextBox
        Friend WithEvents lblInTrackNo As System.Windows.Forms.Label
        Friend WithEvents txtInTrackNo As System.Windows.Forms.TextBox
        Friend WithEvents lblCarrier As System.Windows.Forms.Label
        Friend WithEvents txtShipmentLabel As System.Windows.Forms.TextBox
        Friend WithEvents lblShipmentLabel As System.Windows.Forms.Label
        Friend WithEvents btnSaveData As System.Windows.Forms.Button
        Friend WithEvents cboCarrier As C1.Win.C1List.C1Combo
        Friend WithEvents cboClaimNo As C1.Win.C1List.C1Combo
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents LstboxSavedLog As System.Windows.Forms.ListBox
        Friend WithEvents lblSavedLog As System.Windows.Forms.Label
        Friend WithEvents btnCopy2Clipboard As System.Windows.Forms.Button
        Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
        Friend WithEvents btnCopy2ClipboardSavedLog As System.Windows.Forms.Button
        Friend WithEvents tdgDetailInfo As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
        Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
        Friend WithEvents txtNoteIssue As System.Windows.Forms.TextBox
        Friend WithEvents picYes As System.Windows.Forms.PictureBox
        Friend WithEvents picNo As System.Windows.Forms.PictureBox
        Friend WithEvents btnRefresh As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(TMIShipReturnLabel))
            Me.txtOutTrackNo = New System.Windows.Forms.TextBox()
            Me.lblClaimNo = New System.Windows.Forms.Label()
            Me.lblOutTrackNo = New System.Windows.Forms.Label()
            Me.lblInTrackNo = New System.Windows.Forms.Label()
            Me.txtInTrackNo = New System.Windows.Forms.TextBox()
            Me.lblCarrier = New System.Windows.Forms.Label()
            Me.txtShipmentLabel = New System.Windows.Forms.TextBox()
            Me.lblShipmentLabel = New System.Windows.Forms.Label()
            Me.btnSaveData = New System.Windows.Forms.Button()
            Me.cboCarrier = New C1.Win.C1List.C1Combo()
            Me.cboClaimNo = New C1.Win.C1List.C1Combo()
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.LstboxSavedLog = New System.Windows.Forms.ListBox()
            Me.lblSavedLog = New System.Windows.Forms.Label()
            Me.btnCopy2Clipboard = New System.Windows.Forms.Button()
            Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            Me.btnCopy2ClipboardSavedLog = New System.Windows.Forms.Button()
            Me.tdgDetailInfo = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.TabPage1 = New System.Windows.Forms.TabPage()
            Me.txtNoteIssue = New System.Windows.Forms.TextBox()
            Me.TabPage2 = New System.Windows.Forms.TabPage()
            Me.picYes = New System.Windows.Forms.PictureBox()
            Me.picNo = New System.Windows.Forms.PictureBox()
            Me.btnRefresh = New System.Windows.Forms.Button()
            CType(Me.cboCarrier, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboClaimNo, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.tdgDetailInfo, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControl1.SuspendLayout()
            Me.TabPage1.SuspendLayout()
            Me.TabPage2.SuspendLayout()
            Me.SuspendLayout()
            '
            'txtOutTrackNo
            '
            Me.txtOutTrackNo.BackColor = System.Drawing.Color.White
            Me.txtOutTrackNo.Location = New System.Drawing.Point(232, 104)
            Me.txtOutTrackNo.Name = "txtOutTrackNo"
            Me.txtOutTrackNo.Size = New System.Drawing.Size(304, 20)
            Me.txtOutTrackNo.TabIndex = 1
            Me.txtOutTrackNo.Text = ""
            '
            'lblClaimNo
            '
            Me.lblClaimNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblClaimNo.Location = New System.Drawing.Point(40, 64)
            Me.lblClaimNo.Name = "lblClaimNo"
            Me.lblClaimNo.Size = New System.Drawing.Size(192, 24)
            Me.lblClaimNo.TabIndex = 3
            Me.lblClaimNo.Text = "Claim Customer Name:"
            Me.lblClaimNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblOutTrackNo
            '
            Me.lblOutTrackNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblOutTrackNo.Location = New System.Drawing.Point(72, 104)
            Me.lblOutTrackNo.Name = "lblOutTrackNo"
            Me.lblOutTrackNo.Size = New System.Drawing.Size(160, 24)
            Me.lblOutTrackNo.TabIndex = 4
            Me.lblOutTrackNo.Text = "PSSI to Customer Track No:"
            Me.lblOutTrackNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblInTrackNo
            '
            Me.lblInTrackNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblInTrackNo.Location = New System.Drawing.Point(24, 136)
            Me.lblInTrackNo.Name = "lblInTrackNo"
            Me.lblInTrackNo.Size = New System.Drawing.Size(208, 24)
            Me.lblInTrackNo.TabIndex = 6
            Me.lblInTrackNo.Text = "Customer to PSSI (Return) Track No:"
            Me.lblInTrackNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtInTrackNo
            '
            Me.txtInTrackNo.BackColor = System.Drawing.Color.White
            Me.txtInTrackNo.Location = New System.Drawing.Point(232, 136)
            Me.txtInTrackNo.Name = "txtInTrackNo"
            Me.txtInTrackNo.Size = New System.Drawing.Size(304, 20)
            Me.txtInTrackNo.TabIndex = 5
            Me.txtInTrackNo.Text = ""
            '
            'lblCarrier
            '
            Me.lblCarrier.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCarrier.Location = New System.Drawing.Point(24, 32)
            Me.lblCarrier.Name = "lblCarrier"
            Me.lblCarrier.Size = New System.Drawing.Size(208, 24)
            Me.lblCarrier.TabIndex = 11
            Me.lblCarrier.Text = "Shipment Carrier:"
            Me.lblCarrier.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtShipmentLabel
            '
            Me.txtShipmentLabel.Location = New System.Drawing.Point(232, 176)
            Me.txtShipmentLabel.Multiline = True
            Me.txtShipmentLabel.Name = "txtShipmentLabel"
            Me.txtShipmentLabel.ReadOnly = True
            Me.txtShipmentLabel.Size = New System.Drawing.Size(304, 64)
            Me.txtShipmentLabel.TabIndex = 16
            Me.txtShipmentLabel.Text = ""
            '
            'lblShipmentLabel
            '
            Me.lblShipmentLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblShipmentLabel.Location = New System.Drawing.Point(136, 176)
            Me.lblShipmentLabel.Name = "lblShipmentLabel"
            Me.lblShipmentLabel.Size = New System.Drawing.Size(96, 24)
            Me.lblShipmentLabel.TabIndex = 17
            Me.lblShipmentLabel.Text = "Shipment Label:"
            Me.lblShipmentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnSaveData
            '
            Me.btnSaveData.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSaveData.ForeColor = System.Drawing.SystemColors.HotTrack
            Me.btnSaveData.Location = New System.Drawing.Point(552, 120)
            Me.btnSaveData.Name = "btnSaveData"
            Me.btnSaveData.Size = New System.Drawing.Size(128, 40)
            Me.btnSaveData.TabIndex = 18
            Me.btnSaveData.Text = "Save"
            '
            'cboCarrier
            '
            Me.cboCarrier.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboCarrier.AutoCompletion = True
            Me.cboCarrier.AutoDropDown = True
            Me.cboCarrier.AutoSelect = True
            Me.cboCarrier.Caption = ""
            Me.cboCarrier.CaptionHeight = 17
            Me.cboCarrier.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboCarrier.ColumnCaptionHeight = 17
            Me.cboCarrier.ColumnFooterHeight = 17
            Me.cboCarrier.ColumnHeaders = False
            Me.cboCarrier.ContentHeight = 15
            Me.cboCarrier.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboCarrier.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboCarrier.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCarrier.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCarrier.EditorHeight = 15
            Me.cboCarrier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCarrier.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboCarrier.ItemHeight = 15
            Me.cboCarrier.Location = New System.Drawing.Point(232, 32)
            Me.cboCarrier.MatchEntryTimeout = CType(2000, Long)
            Me.cboCarrier.MaxDropDownItems = CType(10, Short)
            Me.cboCarrier.MaxLength = 32767
            Me.cboCarrier.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCarrier.Name = "cboCarrier"
            Me.cboCarrier.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCarrier.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCarrier.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCarrier.Size = New System.Drawing.Size(304, 21)
            Me.cboCarrier.TabIndex = 19
            Me.cboCarrier.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'cboClaimNo
            '
            Me.cboClaimNo.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboClaimNo.AutoCompletion = True
            Me.cboClaimNo.AutoDropDown = True
            Me.cboClaimNo.AutoSelect = True
            Me.cboClaimNo.Caption = ""
            Me.cboClaimNo.CaptionHeight = 17
            Me.cboClaimNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboClaimNo.ColumnCaptionHeight = 17
            Me.cboClaimNo.ColumnFooterHeight = 17
            Me.cboClaimNo.ColumnHeaders = False
            Me.cboClaimNo.ContentHeight = 15
            Me.cboClaimNo.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboClaimNo.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboClaimNo.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboClaimNo.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboClaimNo.EditorHeight = 15
            Me.cboClaimNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboClaimNo.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboClaimNo.ItemHeight = 15
            Me.cboClaimNo.Location = New System.Drawing.Point(232, 64)
            Me.cboClaimNo.MatchEntryTimeout = CType(2000, Long)
            Me.cboClaimNo.MaxDropDownItems = CType(10, Short)
            Me.cboClaimNo.MaxLength = 32767
            Me.cboClaimNo.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboClaimNo.Name = "cboClaimNo"
            Me.cboClaimNo.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboClaimNo.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboClaimNo.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboClaimNo.Size = New System.Drawing.Size(304, 21)
            Me.cboClaimNo.TabIndex = 20
            Me.cboClaimNo.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'lblTitle
            '
            Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTitle.ForeColor = System.Drawing.Color.Navy
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(416, 24)
            Me.lblTitle.TabIndex = 21
            Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'LstboxSavedLog
            '
            Me.LstboxSavedLog.BackColor = System.Drawing.SystemColors.Info
            Me.LstboxSavedLog.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.LstboxSavedLog.ForeColor = System.Drawing.Color.Maroon
            Me.LstboxSavedLog.Location = New System.Drawing.Point(552, 192)
            Me.LstboxSavedLog.Name = "LstboxSavedLog"
            Me.LstboxSavedLog.Size = New System.Drawing.Size(280, 325)
            Me.LstboxSavedLog.TabIndex = 22
            '
            'lblSavedLog
            '
            Me.lblSavedLog.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSavedLog.ForeColor = System.Drawing.Color.Maroon
            Me.lblSavedLog.Location = New System.Drawing.Point(552, 168)
            Me.lblSavedLog.Name = "lblSavedLog"
            Me.lblSavedLog.Size = New System.Drawing.Size(64, 24)
            Me.lblSavedLog.TabIndex = 23
            Me.lblSavedLog.Text = "Saved Log:"
            Me.lblSavedLog.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'btnCopy2Clipboard
            '
            Me.btnCopy2Clipboard.Location = New System.Drawing.Point(208, 200)
            Me.btnCopy2Clipboard.Name = "btnCopy2Clipboard"
            Me.btnCopy2Clipboard.Size = New System.Drawing.Size(20, 20)
            Me.btnCopy2Clipboard.TabIndex = 25
            Me.ToolTip1.SetToolTip(Me.btnCopy2Clipboard, "Copy Shipment Label Info to Clipboard")
            '
            'btnCopy2ClipboardSavedLog
            '
            Me.btnCopy2ClipboardSavedLog.Location = New System.Drawing.Point(624, 168)
            Me.btnCopy2ClipboardSavedLog.Name = "btnCopy2ClipboardSavedLog"
            Me.btnCopy2ClipboardSavedLog.Size = New System.Drawing.Size(20, 20)
            Me.btnCopy2ClipboardSavedLog.TabIndex = 26
            Me.ToolTip1.SetToolTip(Me.btnCopy2ClipboardSavedLog, "Copy Saved Log Info to Clipboard")
            '
            'tdgDetailInfo
            '
            Me.tdgDetailInfo.AlternatingRows = True
            Me.tdgDetailInfo.BackColor = System.Drawing.SystemColors.ActiveCaptionText
            Me.tdgDetailInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdgDetailInfo.CaptionHeight = 17
            Me.tdgDetailInfo.FilterBar = True
            Me.tdgDetailInfo.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgDetailInfo.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.tdgDetailInfo.Location = New System.Drawing.Point(8, 8)
            Me.tdgDetailInfo.Name = "tdgDetailInfo"
            Me.tdgDetailInfo.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgDetailInfo.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgDetailInfo.PreviewInfo.ZoomFactor = 75
            Me.tdgDetailInfo.RowHeight = 15
            Me.tdgDetailInfo.Size = New System.Drawing.Size(488, 240)
            Me.tdgDetailInfo.TabIndex = 27
            Me.tdgDetailInfo.Text = "C1TrueDBGrid1"
            Me.tdgDetailInfo.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Lavender;}Selec" & _
            "ted{ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inac" & _
            "tiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:" & _
            "Center;}Style1{}Normal{Font:Microsoft Sans Serif, 10pt;}HighlightRow{ForeColor:H" & _
            "ighlightText;BackColor:Highlight;}Style14{}OddRow{}RecordSelector{AlignImage:Cen" & _
            "ter;}Style15{}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;Fore" & _
            "Color:ControlText;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}Sty" & _
            "le12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Na" & _
            "me="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" Col" & _
            "umnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSele" & _
            "ctorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup" & _
            "=""1""><Height>238</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorSty" & _
            "le parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><F" & _
            "ilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=" & _
            """Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Headi" & _
            "ng"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><Inacti" & _
            "veStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9""" & _
            " /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle pa" & _
            "rent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0" & _
            ", 0, 486, 238</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderS" & _
            "tyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""" & _
            "Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Foot" & _
            "er"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactiv" & _
            "e"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /" & _
            "><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" " & _
            "/><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelecto" & _
            "r"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" " & _
            "/></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None" & _
            "</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 486, 238</" & _
            "ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle " & _
            "parent="""" me=""Style15"" /></Blob>"
            '
            'TabControl1
            '
            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabPage1, Me.TabPage2})
            Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TabControl1.Location = New System.Drawing.Point(16, 256)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(512, 280)
            Me.TabControl1.TabIndex = 30
            '
            'TabPage1
            '
            Me.TabPage1.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtNoteIssue})
            Me.TabPage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TabPage1.Location = New System.Drawing.Point(4, 22)
            Me.TabPage1.Name = "TabPage1"
            Me.TabPage1.Size = New System.Drawing.Size(504, 254)
            Me.TabPage1.TabIndex = 0
            Me.TabPage1.Text = "Note/Issue"
            '
            'txtNoteIssue
            '
            Me.txtNoteIssue.BackColor = System.Drawing.Color.Beige
            Me.txtNoteIssue.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.txtNoteIssue.ForeColor = System.Drawing.Color.Firebrick
            Me.txtNoteIssue.Location = New System.Drawing.Point(8, 8)
            Me.txtNoteIssue.Multiline = True
            Me.txtNoteIssue.Name = "txtNoteIssue"
            Me.txtNoteIssue.ReadOnly = True
            Me.txtNoteIssue.Size = New System.Drawing.Size(488, 240)
            Me.txtNoteIssue.TabIndex = 0
            Me.txtNoteIssue.Text = "TextBox1"
            '
            'TabPage2
            '
            Me.TabPage2.Controls.AddRange(New System.Windows.Forms.Control() {Me.tdgDetailInfo})
            Me.TabPage2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TabPage2.Location = New System.Drawing.Point(4, 22)
            Me.TabPage2.Name = "TabPage2"
            Me.TabPage2.Size = New System.Drawing.Size(504, 254)
            Me.TabPage2.TabIndex = 1
            Me.TabPage2.Text = "Detail Data"
            '
            'picYes
            '
            Me.picYes.Image = CType(resources.GetObject("picYes.Image"), System.Drawing.Bitmap)
            Me.picYes.Name = "picYes"
            Me.picYes.Size = New System.Drawing.Size(74, 55)
            Me.picYes.TabIndex = 31
            Me.picYes.TabStop = False
            '
            'picNo
            '
            Me.picNo.Image = CType(resources.GetObject("picNo.Image"), System.Drawing.Bitmap)
            Me.picNo.Location = New System.Drawing.Point(40, 176)
            Me.picNo.Name = "picNo"
            Me.picNo.Size = New System.Drawing.Size(74, 55)
            Me.picNo.TabIndex = 32
            Me.picNo.TabStop = False
            '
            'btnRefresh
            '
            Me.btnRefresh.BackColor = System.Drawing.SystemColors.ActiveBorder
            Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRefresh.ForeColor = System.Drawing.SystemColors.HotTrack
            Me.btnRefresh.Location = New System.Drawing.Point(552, 64)
            Me.btnRefresh.Name = "btnRefresh"
            Me.btnRefresh.Size = New System.Drawing.Size(128, 20)
            Me.btnRefresh.TabIndex = 33
            Me.btnRefresh.Text = "Refresh"
            '
            'TMIShipReturnLabel
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.SystemColors.ControlLight
            Me.ClientSize = New System.Drawing.Size(848, 534)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRefresh, Me.picNo, Me.picYes, Me.TabControl1, Me.btnCopy2ClipboardSavedLog, Me.btnCopy2Clipboard, Me.lblSavedLog, Me.LstboxSavedLog, Me.lblTitle, Me.cboClaimNo, Me.cboCarrier, Me.btnSaveData, Me.lblShipmentLabel, Me.txtShipmentLabel, Me.lblCarrier, Me.lblInTrackNo, Me.txtInTrackNo, Me.lblOutTrackNo, Me.lblClaimNo, Me.txtOutTrackNo})
            Me.Name = "TMIShipReturnLabel"
            Me.Text = "TMIShipReturnLabel"
            CType(Me.cboCarrier, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboClaimNo, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.tdgDetailInfo, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControl1.ResumeLayout(False)
            Me.TabPage1.ResumeLayout(False)
            Me.TabPage2.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region
        

        Private Sub TMIShipReturnLabel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Me.lblTitle.Text = Me._strScreenName
            Me.txtNoteIssue.Text = ""
            Me.TabControl1.Visible = False
            Me.lblSavedLog.Visible = False
            Me.LstboxSavedLog.Visible = False
            Me.LstboxSavedLog.HorizontalScrollbar = True
            Me.btnCopy2ClipboardSavedLog.Visible = False
            Me.picNo.Visible = False
            Me.picYes.Visible = False

            PopulateClaimIDNo()
            PopulateShipmentCarrier()
        End Sub

        Private Sub PopulateClaimIDNo()
            Dim row As DataRow
            Dim i As Integer
            Dim dTB As DataTable

            Try
                Me.cboClaimNo.ClearItems()

                objTMI = New PSS.Data.Buisness.TMI()
                dTB = objTMI.GetClaimNoIDName(Me._iCust_ID)

                If dTB.Rows.Count > 0 Then
                    Misc.PopulateC1DropDownList(Me.cboClaimNo, dTB, "ShipTo_Name", "EW_ID")
                End If

                dTB = Nothing
                objTMI = Nothing

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "PopulateClaimIDNo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub PopulateShipmentCarrier()
            Dim row As DataRow
            Dim i As Integer
            Dim dTB As DataTable

            Try
                Me.cboCarrier.ClearItems()

                objTMI = New PSS.Data.Buisness.TMI()
                dTB = objTMI.GetShipCarriers

                If dTB.Rows.Count > 0 Then
                    Misc.PopulateC1DropDownList(Me.cboCarrier, dTB, "SC_Desc", "SC_ID")
                    Me.cboCarrier.SelectedValue = 2 'FedEx Ground
                End If

                dTB = Nothing
                objTMI = Nothing

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "PopulateShipmentCarrier", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub PopulateTMIServiceClient()
            Dim row As DataRow
            Dim i As Integer
            Dim dTB As DataTable

            Try
                Me.cboCarrier.ClearItems()

                objTMI = New PSS.Data.Buisness.TMI()
                dTB = objTMI.GetShipCarriers

                If dTB.Rows.Count > 0 Then
                    Misc.PopulateC1DropDownList(Me.cboCarrier, dTB, "SC_Desc", "SC_ID")
                    Me.cboCarrier.SelectedValue = 2 'FedEx Ground
                End If

                dTB = Nothing
                objTMI = Nothing

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "PopulateShipmentCarrier", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try

        End Sub

        Private Function ClaimTB() As DataTable
            Dim dTB As New DataTable()
            dTB.Columns.Add("ID", GetType(Integer))
            dTB.Columns.Add("Column_Label", GetType(String))
            dTB.Columns.Add("Column_Value", GetType(String))

            Return dTB
        End Function

        Private Sub RefreshDataGrid(ByVal iEW_ID As Integer)

            Dim dTB As New DataTable()
            Dim dTBOut As DataTable
            Dim i As Integer
            Dim FullAddressStr As String = ""
            Dim strReturnBoxYN As String = ""

            Try
                objTMI = New PSS.Data.Buisness.TMI()
                dTB = objTMI.GetClaimFullInfo(iEW_ID, Me._iCust_ID)

                If Not dTB.Rows.Count > 0 Then
                    Me.tdgDetailInfo.DataSource = Nothing
                    Exit Sub
                End If

                Me.txtShipmentLabel.Text = ""
                For i = 0 To dTB.Rows.Count - 1
                    FullAddressStr = dTB.Rows(i).Item("ShipTo_Name")
                    FullAddressStr += vbNewLine & dTB.Rows(i).Item("Address1") & _
                                      " " & dTB.Rows(i).Item("Address2")
                    FullAddressStr += vbNewLine & dTB.Rows(i).Item("City") & _
                                      ", " & dTB.Rows(i).Item("State_Short") & _
                                      ", " & dTB.Rows(i).Item("ZipCode")
                    Me.txtShipmentLabel.Text = FullAddressStr
                    strReturnBoxYN = dTB.Rows(i).Item("ReturnBoxYesNo")

                    If strReturnBoxYN.ToUpper = "YES" Then
                        Me.picNo.Visible = False : Me.picYes.Visible = True
                        Me.picYes.Left = 40 : Me.picYes.Top = Me.txtShipmentLabel.Top + 5
                        Me._emptyBoxYes = True
                    Else
                        Me.picNo.Visible = True : Me.picYes.Visible = False
                        Me.picNo.Left = 40 : Me.picNo.Top = Me.txtShipmentLabel.Top + 5
                        Me._emptyBoxYes = False
                    End If

                    If Not (IsDBNull(dTB.Rows(i).Item("PSSI2Cust_TrackNo"))) Then
                        Me.txtOutTrackNo.Text = dTB.Rows(i).Item("PSSI2Cust_TrackNo")
                    Else
                        If strReturnBoxYN.ToUpper = "YES" Then
                            Me.txtOutTrackNo.Text = ""
                        Else
                            Me.txtOutTrackNo.Text = "No Box Required"
                        End If
                    End If
                    If Not (IsDBNull(dTB.Rows(i).Item("Cust2PSSI_TrackNo"))) Then
                        Me.txtInTrackNo.Text = dTB.Rows(i).Item("Cust2PSSI_TrackNo")
                    Else
                        Me.txtInTrackNo.Text = ""
                    End If

                    If Not (IsDBNull(dTB.Rows(i).Item("Note"))) Then
                        Me.txtNoteIssue.Text = dTB.Rows(i).Item("Note")
                    Else
                        Me.txtNoteIssue.Text = ""
                    End If

                    Exit For
                Next

                'For grid data
                dTBOut = ClaimTB()
                For i = 0 To dTB.Columns.Count - 1
                    Dim dtNewRow As DataRow
                    dtNewRow = dTBOut.NewRow()
                    dtNewRow.Item("id") = i + 1
                    dtNewRow.Item("Column_Label") = dTB.Columns(i).ColumnName
                    dtNewRow.Item("Column_Value") = dTB.Rows(0).Item(i)
                    dTBOut.Rows.Add(dtNewRow)
                Next


                Me.tdgDetailInfo.DataSource = dTBOut
                'Me.tdgDetailInfo.Visible = True
                Me.TabControl1.Visible = True

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "RefreshDataGrid", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            End Try
        End Sub

        Private Sub btnSaveData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveData.Click
            Dim sStr As String = ""
            Dim outboundTrackStr As String = ""
            Dim returnTrackStr As String = ""
            Dim WOCustWOStr As String = ""
            Dim ClaimNoStr As String = ""
            Dim iSC_ID As Integer
            Dim iWO_ID As Integer = 0, iWO_Quantity As Integer = 0
            Dim i As Integer = 0
            Dim tmpStr As String = ""
            'Dim PSSIStatusStr As String = ""
            Dim PSSIStatus_ID As Integer = 0
            Dim PSSIStatus_Str As String
            Const PSSI2CustomerShippingCost As Double = 15 'charge a flat rate at $15
            Dim objRecShip As PSS.Data.Buisness.TMIRecShip
            Dim shippingCost As Double = 0

            ' Dim arrS() As String

            Dim iEW_ID As Integer = 0

            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            objTMI = New PSS.Data.Buisness.TMI()

            Try

                If Not Me.cboCarrier.ListCount > 0 Then
                    MessageBox.Show("No carrier!")
                    Exit Sub
                End If

                If Not Me.cboClaimNo.ListCount > 0 Then
                    MessageBox.Show("No claim!")
                    Exit Sub
                End If

                sStr = Me.cboCarrier.Text
                If sStr Is Nothing Or sStr.Length = 0 Then
                    MessageBox.Show("Please select a carrier!")
                    Exit Sub
                End If

                sStr = Me.cboClaimNo.Text
                If sStr Is Nothing Or sStr.Length = 0 Then
                    MessageBox.Show("Please select a claim!")
                    Exit Sub
                End If

                sStr = Me.txtOutTrackNo.Text.Trim
                If sStr Is Nothing Or sStr.Length = 0 Then
                    MessageBox.Show("PSSI to Customer Track No can't be nothing!")
                    Exit Sub
                End If

                sStr = Me.txtInTrackNo.Text.Trim
                If sStr Is Nothing Or sStr.Length = 0 Then
                    MessageBox.Show("Customer to PSSI (Return) Track No can't be nothing!")
                    Exit Sub
                End If

                'Start 
                outboundTrackStr = Me.txtOutTrackNo.Text.Trim
                returnTrackStr = Me.txtInTrackNo.Text.Trim
                If outboundTrackStr = returnTrackStr Then
                    MessageBox.Show("'PSSI to Customer Track No' and 'Customer to PSSI (Return) Track No' are the same!")
                    Exit Sub
                End If

                'sStr = Me.cboClaimNo.SelectedValue
                'arrS = sStr.Split("-")
                'iEW_ID = arrS(0)
                'ClaimNoStr = arrS(1)
                'WOCustWOStr = ClaimNoStr '"TMI_" & iEW_ID & "_" & ClaimNoStr

                iEW_ID = Me.cboClaimNo.SelectedValue
                ClaimNoStr = objTMI.GetClaimNo(iEW_ID)

                If Not ClaimNoStr.Trim.Length > 0 Then
                    MessageBox.Show("Can't find ClaimNo.")
                    Exit Sub
                End If

                If Me._emptyBoxYes Then
                    PSSIStatus_ID = 2 '"Ship Empty Box"
                Else
                    PSSIStatus_ID = 12 '"No Box Required"
                End If
                PSSIStatus_Str = Data.Buisness.TMIRecShip.GetTMIStatusDesc(PSSIStatus_ID)

                WOCustWOStr = ClaimNoStr.Trim
                iSC_ID = Me.cboCarrier.SelectedValue

                iWO_ID = objTMI.GetWorkOrderID(WOCustWOStr, Me._iLoc_ID)

                If iWO_ID = 0 Then
                    iWO_Quantity = objTMI.GetClaimNoCount(ClaimNoStr, Me._iCust_ID)
                    iWO_ID = objTMI.InsertWorkOrderData(WOCustWOStr, iWO_Quantity, Me._iLoc_ID, Me._iGroup_ID)

                    If iWO_ID > 0 Then
                        shippingCost = 0
                        i = objTMI.UpdateExdenedWarrantyData(iEW_ID, iWO_ID, outboundTrackStr, _
                                              returnTrackStr, PSSIStatus_ID, PSSIStatus_Str, iSC_ID, GiUserID, shippingCost)

                        'Add saved log info
                        tmpStr = Me.cboClaimNo.Text & "; " & iEW_ID & "; " & _
                                  ClaimNoStr & "; " & iWO_ID & "; " & Me.cboCarrier.Text & "; " & _
                                outboundTrackStr & "; " & returnTrackStr & "; $" & shippingCost
                        Me.LstboxSavedLog.Items.Add(tmpStr)
                        Me.LstboxSavedLog.Visible = True
                        Me.btnCopy2ClipboardSavedLog.Visible = True
                        Me.lblSavedLog.Visible = True

                        PopulateClaimIDNo()
                    Else
                        MessageBox.Show("Failed to save! See IT.")
                    End If
                Else
                    MessageBox.Show("Found an existing WorkOrder record!")
                End If

                RefreshDataGrid(cboClaimNo.SelectedValue)

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnSaveData_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                objTMI = Nothing
                objRecShip = Nothing
                Me.Cursor = Windows.Forms.Cursors.Default
            End Try

        End Sub

        'Private Sub cboClaimNo_Change(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboClaimNo.Change
        '    'Dim iEW_ID As Integer = GetEWID()

        '    'Try
        '    '    RefreshDataGrid(iEW_ID)
        '    'Catch ex As Exception
        '    '    MessageBox.Show(ex.ToString, "cboClaimNo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        '    'End Try

        'End Sub

        'Private Function GetEWID() As Integer
        '    Dim S As String = ""
        '    Dim arrS() As String
        '    Dim iEW_ID As Integer = 0

        '    Try
        '        S = Trim(cboClaimNo.SelectedValue)
        '        If S.Length > 0 Then
        '            arrS = S.Split("-")
        '            iEW_ID = arrS(0)
        '        End If
        '        Return iEW_ID

        '    Catch ex As Exception
        '        Return iEW_ID
        '    End Try
        'End Function

        Private Sub btnCopy2Clipboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy2Clipboard.Click
            Try
                Clipboard.SetDataObject(Me.txtShipmentLabel.Text)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCopy2Clipboard_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub btnCopy2ClipboardSavedLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy2ClipboardSavedLog.Click
            Dim sStr As String = ""
            Dim i As Integer = 0

            Try

                For i = 0 To Me.LstboxSavedLog.Items.Count - 1
                    sStr += Me.LstboxSavedLog.Items(i) & vbNewLine
                Next

                Clipboard.SetDataObject(sStr)

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCopy2ClipboardSavedLog_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub cboClaimNo_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboClaimNo.SelectedValueChanged
            Try
                Dim iEW_ID As Integer = cboClaimNo.SelectedValue
                RefreshDataGrid(iEW_ID)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboClaimNo_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
            Try
                PopulateClaimIDNo()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

    End Class
End Namespace