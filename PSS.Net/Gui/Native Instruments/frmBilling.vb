
Option Explicit On 

Imports PSS.Data
Imports PSS.Core
Imports PSS.Rules
Imports PSS.Core.Global
Imports System.IO

Namespace Gui.NativeInstruments
    Public Class frmBilling
        Inherits System.Windows.Forms.Form
#Region " Windows Form Designer generated code "

        Public Sub New(Optional ByVal iBillType As Integer = 2, _
                       Optional ByVal iCustID As Integer = 0, _
                       Optional ByVal strScreenName As String = "", _
                       Optional ByVal iCheckDeviceStation As Integer = -1, _
                       Optional ByVal iScreenID As Integer = 0)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._iBillType = iBillType   'Magic number 1: Pre-Bill, 2:Tech  3:Pre-Bill Lot

            If iCustID > 0 Then
                Me._iSCustID = iCustID
                Me.lblCustName.Text = PSS.Data.Buisness.Generic.GetCustomerName(iCustID)
            End If

            If strScreenName.Trim.Length > 0 Then Me._strScreenName = strScreenName
            If iCheckDeviceStation >= 0 Then
                If iCheckDeviceStation = 0 Then Me._booStationCheck = False Else Me._booStationCheck = True
            End If
            Me._iScreenID = iScreenID
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
        Friend WithEvents txtSerial As System.Windows.Forms.TextBox
        Friend WithEvents lblDeviceSN As System.Windows.Forms.Label
        Friend WithEvents tabMain As System.Windows.Forms.TabControl
        Friend WithEvents tbParts As System.Windows.Forms.TabPage
        Friend WithEvents tbServices As System.Windows.Forms.TabPage
        Friend WithEvents pnlBill As System.Windows.Forms.Panel
        Friend WithEvents pnlService As System.Windows.Forms.Panel
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents btnComplete As System.Windows.Forms.Button
        Friend WithEvents lblCustName As System.Windows.Forms.Label
        Friend WithEvents tbRVParts As System.Windows.Forms.TabPage
        Friend WithEvents pnlRVParts As System.Windows.Forms.Panel
        Friend WithEvents lblScreenName As System.Windows.Forms.Label
        Friend WithEvents tbTestResults As System.Windows.Forms.TabPage
        Friend WithEvents pnlTestResults As System.Windows.Forms.Panel
        Friend WithEvents lblTestResult_QC As System.Windows.Forms.Label
        Friend WithEvents _LabelTestResult_QC As System.Windows.Forms.Label
        Friend WithEvents lblModel As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents lblWipLoc As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents _LabelTestResult_Triage As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents btnQuoteSumitted As System.Windows.Forms.Button
        Friend WithEvents dgConsumed As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents tpPartHistory As System.Windows.Forms.TabPage
        Friend WithEvents tpPrevRep As System.Windows.Forms.TabPage
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents dgPreRepDev As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents dgPrevRepPartsServ As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblPrevRepTechNote As System.Windows.Forms.Label
        Friend WithEvents lblPSSWrtyStatus As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents txtEstimateQuote As System.Windows.Forms.TextBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents cboOBCosmGrade As C1.Win.C1List.C1Combo
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents lblEDIRepType As System.Windows.Forms.Label
        Friend WithEvents pnlQuote As System.Windows.Forms.Panel
        Friend WithEvents lblCustErrDesc As System.Windows.Forms.Label
        Friend WithEvents lblDefectTypes As System.Windows.Forms.Label
        Friend WithEvents btnTechNotesSave As System.Windows.Forms.Button
        Friend WithEvents lblTestResult_Triage As System.Windows.Forms.TextBox
        Friend WithEvents lblTechNotesUpdDate As System.Windows.Forms.Label
        Friend WithEvents txtTechNotes As System.Windows.Forms.TextBox
        Friend WithEvents pnlDefectReason As System.Windows.Forms.Panel
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents btnRemove As System.Windows.Forms.Button
        Friend WithEvents tdgData1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents pnlDefectClass As System.Windows.Forms.Panel
        Friend WithEvents cboDefectClass1 As C1.Win.C1List.C1Combo
        Friend WithEvents lblMsg As System.Windows.Forms.Label
        Friend WithEvents cb400 As System.Windows.Forms.CheckBox
        Friend WithEvents cb500 As System.Windows.Forms.CheckBox
        Friend WithEvents cb600 As System.Windows.Forms.CheckBox
        Friend WithEvents cb001 As System.Windows.Forms.CheckBox
        Friend WithEvents cb720 As System.Windows.Forms.CheckBox
        Friend WithEvents cb700 As System.Windows.Forms.CheckBox
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents Label13 As System.Windows.Forms.Label
        Friend WithEvents Label14 As System.Windows.Forms.Label
        Friend WithEvents Label15 As System.Windows.Forms.Label
        Friend WithEvents Label16 As System.Windows.Forms.Label
        Friend WithEvents Label17 As System.Windows.Forms.Label
        Friend WithEvents Label18 As System.Windows.Forms.Label
        Friend WithEvents Label19 As System.Windows.Forms.Label
        Friend WithEvents Label20 As System.Windows.Forms.Label
        Friend WithEvents lbl720Parts As System.Windows.Forms.Label
        Friend WithEvents lbl600Parts As System.Windows.Forms.Label
        Friend WithEvents cbCustAbuse As System.Windows.Forms.CheckBox
        Friend WithEvents Label21 As System.Windows.Forms.Label
        Friend WithEvents Label23 As System.Windows.Forms.Label
        Private WithEvents Label22 As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmBilling))
            Me.txtSerial = New System.Windows.Forms.TextBox()
            Me.lblDeviceSN = New System.Windows.Forms.Label()
            Me.tabMain = New System.Windows.Forms.TabControl()
            Me.tbParts = New System.Windows.Forms.TabPage()
            Me.pnlBill = New System.Windows.Forms.Panel()
            Me.tbTestResults = New System.Windows.Forms.TabPage()
            Me.pnlDefectClass = New System.Windows.Forms.Panel()
            Me.lblMsg = New System.Windows.Forms.Label()
            Me.cboDefectClass1 = New C1.Win.C1List.C1Combo()
            Me.btnRemove = New System.Windows.Forms.Button()
            Me.tdgData1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.lblTechNotesUpdDate = New System.Windows.Forms.Label()
            Me.btnTechNotesSave = New System.Windows.Forms.Button()
            Me.txtTechNotes = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.pnlTestResults = New System.Windows.Forms.Panel()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.lblCustErrDesc = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.lblDefectTypes = New System.Windows.Forms.Label()
            Me.lblTestResult_Triage = New System.Windows.Forms.TextBox()
            Me._LabelTestResult_QC = New System.Windows.Forms.Label()
            Me.lblTestResult_QC = New System.Windows.Forms.Label()
            Me._LabelTestResult_Triage = New System.Windows.Forms.Label()
            Me.tbServices = New System.Windows.Forms.TabPage()
            Me.pnlService = New System.Windows.Forms.Panel()
            Me.Label23 = New System.Windows.Forms.Label()
            Me.Label22 = New System.Windows.Forms.Label()
            Me.lbl720Parts = New System.Windows.Forms.Label()
            Me.lbl600Parts = New System.Windows.Forms.Label()
            Me.Label15 = New System.Windows.Forms.Label()
            Me.Label13 = New System.Windows.Forms.Label()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.Label16 = New System.Windows.Forms.Label()
            Me.Label17 = New System.Windows.Forms.Label()
            Me.Label14 = New System.Windows.Forms.Label()
            Me.cb720 = New System.Windows.Forms.CheckBox()
            Me.cb400 = New System.Windows.Forms.CheckBox()
            Me.cb600 = New System.Windows.Forms.CheckBox()
            Me.Label18 = New System.Windows.Forms.Label()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.Label19 = New System.Windows.Forms.Label()
            Me.cb001 = New System.Windows.Forms.CheckBox()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.Label20 = New System.Windows.Forms.Label()
            Me.cb700 = New System.Windows.Forms.CheckBox()
            Me.cb500 = New System.Windows.Forms.CheckBox()
            Me.tbRVParts = New System.Windows.Forms.TabPage()
            Me.pnlRVParts = New System.Windows.Forms.Panel()
            Me.tpPartHistory = New System.Windows.Forms.TabPage()
            Me.dgConsumed = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.tpPrevRep = New System.Windows.Forms.TabPage()
            Me.dgPrevRepPartsServ = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.lblPrevRepTechNote = New System.Windows.Forms.Label()
            Me.dgPreRepDev = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.btnComplete = New System.Windows.Forms.Button()
            Me.lblCustName = New System.Windows.Forms.Label()
            Me.lblScreenName = New System.Windows.Forms.Label()
            Me.lblModel = New System.Windows.Forms.Label()
            Me.lblWipLoc = New System.Windows.Forms.Label()
            Me.btnQuoteSumitted = New System.Windows.Forms.Button()
            Me.lblPSSWrtyStatus = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.txtEstimateQuote = New System.Windows.Forms.TextBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.cboOBCosmGrade = New C1.Win.C1List.C1Combo()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.lblEDIRepType = New System.Windows.Forms.Label()
            Me.pnlQuote = New System.Windows.Forms.Panel()
            Me.pnlDefectReason = New System.Windows.Forms.Panel()
            Me.cbCustAbuse = New System.Windows.Forms.CheckBox()
            Me.Label21 = New System.Windows.Forms.Label()
            Me.tabMain.SuspendLayout()
            Me.tbParts.SuspendLayout()
            Me.tbTestResults.SuspendLayout()
            Me.pnlDefectClass.SuspendLayout()
            CType(Me.cboDefectClass1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlTestResults.SuspendLayout()
            Me.tbServices.SuspendLayout()
            Me.pnlService.SuspendLayout()
            Me.tbRVParts.SuspendLayout()
            Me.tpPartHistory.SuspendLayout()
            CType(Me.dgConsumed, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpPrevRep.SuspendLayout()
            CType(Me.dgPrevRepPartsServ, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dgPreRepDev, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboOBCosmGrade, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlQuote.SuspendLayout()
            Me.SuspendLayout()
            '
            'txtSerial
            '
            Me.txtSerial.BackColor = System.Drawing.Color.FromArgb(CType(197, Byte), CType(250, Byte), CType(254, Byte))
            Me.txtSerial.Location = New System.Drawing.Point(104, 33)
            Me.txtSerial.Name = "txtSerial"
            Me.txtSerial.Size = New System.Drawing.Size(136, 20)
            Me.txtSerial.TabIndex = 1
            Me.txtSerial.Text = ""
            Me.txtSerial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'lblDeviceSN
            '
            Me.lblDeviceSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDeviceSN.ForeColor = System.Drawing.Color.Red
            Me.lblDeviceSN.Location = New System.Drawing.Point(-16, 33)
            Me.lblDeviceSN.Name = "lblDeviceSN"
            Me.lblDeviceSN.Size = New System.Drawing.Size(120, 16)
            Me.lblDeviceSN.TabIndex = 104
            Me.lblDeviceSN.Text = "PSS Serial #:"
            Me.lblDeviceSN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'tabMain
            '
            Me.tabMain.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.tabMain.Controls.AddRange(New System.Windows.Forms.Control() {Me.tbParts, Me.tbTestResults, Me.tbServices, Me.tbRVParts, Me.tpPartHistory, Me.tpPrevRep})
            Me.tabMain.Location = New System.Drawing.Point(8, 96)
            Me.tabMain.Name = "tabMain"
            Me.tabMain.SelectedIndex = 0
            Me.tabMain.Size = New System.Drawing.Size(976, 496)
            Me.tabMain.TabIndex = 6
            '
            'tbParts
            '
            Me.tbParts.BackColor = System.Drawing.SystemColors.Control
            Me.tbParts.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlBill})
            Me.tbParts.Location = New System.Drawing.Point(4, 22)
            Me.tbParts.Name = "tbParts"
            Me.tbParts.Size = New System.Drawing.Size(968, 470)
            Me.tbParts.TabIndex = 0
            Me.tbParts.Text = "PARTS"
            '
            'pnlBill
            '
            Me.pnlBill.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.pnlBill.AutoScroll = True
            Me.pnlBill.AutoScrollMargin = New System.Drawing.Size(10, 10)
            Me.pnlBill.AutoScrollMinSize = New System.Drawing.Size(10, 10)
            Me.pnlBill.BackColor = System.Drawing.SystemColors.Control
            Me.pnlBill.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlBill.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.pnlBill.Location = New System.Drawing.Point(8, 8)
            Me.pnlBill.Name = "pnlBill"
            Me.pnlBill.Size = New System.Drawing.Size(952, 456)
            Me.pnlBill.TabIndex = 108
            '
            'tbTestResults
            '
            Me.tbTestResults.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlDefectClass, Me.lblTechNotesUpdDate, Me.btnTechNotesSave, Me.txtTechNotes, Me.Label1, Me.pnlTestResults})
            Me.tbTestResults.Location = New System.Drawing.Point(4, 22)
            Me.tbTestResults.Name = "tbTestResults"
            Me.tbTestResults.Size = New System.Drawing.Size(968, 470)
            Me.tbTestResults.TabIndex = 8
            Me.tbTestResults.Text = "TEST RESULTS"
            '
            'pnlDefectClass
            '
            Me.pnlDefectClass.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblMsg, Me.cboDefectClass1, Me.btnRemove, Me.tdgData1, Me.Label8})
            Me.pnlDefectClass.Location = New System.Drawing.Point(16, 352)
            Me.pnlDefectClass.Name = "pnlDefectClass"
            Me.pnlDefectClass.Size = New System.Drawing.Size(936, 112)
            Me.pnlDefectClass.TabIndex = 130
            '
            'lblMsg
            '
            Me.lblMsg.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMsg.ForeColor = System.Drawing.Color.DarkSlateGray
            Me.lblMsg.Location = New System.Drawing.Point(464, 88)
            Me.lblMsg.Name = "lblMsg"
            Me.lblMsg.Size = New System.Drawing.Size(464, 16)
            Me.lblMsg.TabIndex = 132
            '
            'cboDefectClass1
            '
            Me.cboDefectClass1.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboDefectClass1.AutoCompletion = True
            Me.cboDefectClass1.AutoDropDown = True
            Me.cboDefectClass1.AutoSelect = True
            Me.cboDefectClass1.Caption = ""
            Me.cboDefectClass1.CaptionHeight = 17
            Me.cboDefectClass1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboDefectClass1.ColumnCaptionHeight = 17
            Me.cboDefectClass1.ColumnFooterHeight = 17
            Me.cboDefectClass1.ColumnHeaders = False
            Me.cboDefectClass1.ContentHeight = 15
            Me.cboDefectClass1.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboDefectClass1.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboDefectClass1.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboDefectClass1.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboDefectClass1.EditorHeight = 15
            Me.cboDefectClass1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboDefectClass1.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboDefectClass1.ItemHeight = 15
            Me.cboDefectClass1.Location = New System.Drawing.Point(112, 0)
            Me.cboDefectClass1.MatchEntryTimeout = CType(2000, Long)
            Me.cboDefectClass1.MaxDropDownItems = CType(10, Short)
            Me.cboDefectClass1.MaxLength = 32767
            Me.cboDefectClass1.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboDefectClass1.Name = "cboDefectClass1"
            Me.cboDefectClass1.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboDefectClass1.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboDefectClass1.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboDefectClass1.Size = New System.Drawing.Size(352, 21)
            Me.cboDefectClass1.TabIndex = 131
            Me.cboDefectClass1.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'btnRemove
            '
            Me.btnRemove.Location = New System.Drawing.Point(464, 40)
            Me.btnRemove.Name = "btnRemove"
            Me.btnRemove.Size = New System.Drawing.Size(72, 32)
            Me.btnRemove.TabIndex = 84
            Me.btnRemove.Text = "Remove"
            '
            'tdgData1
            '
            Me.tdgData1.AllowColMove = False
            Me.tdgData1.AllowColSelect = False
            Me.tdgData1.AllowFilter = False
            Me.tdgData1.AllowSort = False
            Me.tdgData1.AllowUpdate = False
            Me.tdgData1.AlternatingRows = True
            Me.tdgData1.BackColor = System.Drawing.Color.White
            Me.tdgData1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdgData1.Caption = "Defect Class Selected"
            Me.tdgData1.FetchRowStyles = True
            Me.tdgData1.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgData1.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.tdgData1.Location = New System.Drawing.Point(104, 24)
            Me.tdgData1.Name = "tdgData1"
            Me.tdgData1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgData1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgData1.PreviewInfo.ZoomFactor = 75
            Me.tdgData1.RowHeight = 15
            Me.tdgData1.Size = New System.Drawing.Size(360, 82)
            Me.tdgData1.TabIndex = 83
            Me.tdgData1.Text = "C1TrueDBGrid1"
            Me.tdgData1.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{Font:Microsoft Sans Serif, 8.25pt;AlignHorz:Center;ForeColor:Green;}Style9{" & _
            "}Normal{Font:Microsoft Sans Serif, 9.75pt;}HighlightRow{ForeColor:HighlightText;" & _
            "BackColor:Highlight;}Style12{}OddRow{}RecordSelector{AlignImage:Center;}Style13{" & _
            "}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlT" & _
            "ext;BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style15" & _
            "{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""F" & _
            "alse"" AllowColSelect=""False"" Name="""" AlternatingRowStyle=""True"" CaptionHeight=""1" & _
            "7"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""True"" Marque" & _
            "eStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalS" & _
            "crollGroup=""1"" HorizontalScrollGroup=""1""><Height>63</Height><CaptionStyle parent" & _
            "=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyl" & _
            "e parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13""" & _
            " /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Sty" & _
            "le12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""" & _
            "HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddR" & _
            "owStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelecto" & _
            "r"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""" & _
            "Normal"" me=""Style1"" /><ClientRect>0, 17, 358, 63</ClientRect><BorderSide>0</Bord" & _
            "erSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits" & _
            "><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading""" & _
            " /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" />" & _
            "<Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><" & _
            "Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><" & _
            "Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style" & _
            " parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" />" & _
            "<Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><ho" & _
            "rzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSe" & _
            "lWidth><ClientArea>0, 0, 358, 80</ClientArea><PrintPageHeaderStyle parent="""" me=" & _
            """Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'Label8
            '
            Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(104, 24)
            Me.Label8.TabIndex = 129
            Me.Label8.Text = "Defect Class:"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'lblTechNotesUpdDate
            '
            Me.lblTechNotesUpdDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTechNotesUpdDate.ForeColor = System.Drawing.Color.Blue
            Me.lblTechNotesUpdDate.Location = New System.Drawing.Point(120, 8)
            Me.lblTechNotesUpdDate.Name = "lblTechNotesUpdDate"
            Me.lblTechNotesUpdDate.Size = New System.Drawing.Size(600, 16)
            Me.lblTechNotesUpdDate.TabIndex = 127
            Me.lblTechNotesUpdDate.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'btnTechNotesSave
            '
            Me.btnTechNotesSave.BackColor = System.Drawing.Color.Green
            Me.btnTechNotesSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnTechNotesSave.ForeColor = System.Drawing.Color.White
            Me.btnTechNotesSave.Location = New System.Drawing.Point(24, 80)
            Me.btnTechNotesSave.Name = "btnTechNotesSave"
            Me.btnTechNotesSave.Size = New System.Drawing.Size(88, 22)
            Me.btnTechNotesSave.TabIndex = 124
            Me.btnTechNotesSave.Text = "Save"
            '
            'txtTechNotes
            '
            Me.txtTechNotes.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.txtTechNotes.BackColor = System.Drawing.SystemColors.Window
            Me.txtTechNotes.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtTechNotes.ForeColor = System.Drawing.Color.Black
            Me.txtTechNotes.Location = New System.Drawing.Point(120, 24)
            Me.txtTechNotes.Multiline = True
            Me.txtTechNotes.Name = "txtTechNotes"
            Me.txtTechNotes.Size = New System.Drawing.Size(832, 144)
            Me.txtTechNotes.TabIndex = 1
            Me.txtTechNotes.Text = ""
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.Location = New System.Drawing.Point(8, 48)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(104, 24)
            Me.Label1.TabIndex = 10
            Me.Label1.Text = "Tech Notes:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'pnlTestResults
            '
            Me.pnlTestResults.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.pnlTestResults.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label3, Me.lblCustErrDesc, Me.Label2, Me.lblDefectTypes, Me.lblTestResult_Triage, Me._LabelTestResult_QC, Me.lblTestResult_QC, Me._LabelTestResult_Triage})
            Me.pnlTestResults.Location = New System.Drawing.Point(16, 176)
            Me.pnlTestResults.Name = "pnlTestResults"
            Me.pnlTestResults.Size = New System.Drawing.Size(944, 176)
            Me.pnlTestResults.TabIndex = 0
            '
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.Location = New System.Drawing.Point(0, 129)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(96, 23)
            Me.Label3.TabIndex = 20
            Me.Label3.Text = "Err Description : "
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCustErrDesc
            '
            Me.lblCustErrDesc.BackColor = System.Drawing.SystemColors.ControlText
            Me.lblCustErrDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCustErrDesc.ForeColor = System.Drawing.Color.White
            Me.lblCustErrDesc.Location = New System.Drawing.Point(104, 128)
            Me.lblCustErrDesc.Name = "lblCustErrDesc"
            Me.lblCustErrDesc.Size = New System.Drawing.Size(832, 32)
            Me.lblCustErrDesc.TabIndex = 19
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.Location = New System.Drawing.Point(8, 90)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(88, 23)
            Me.Label2.TabIndex = 18
            Me.Label2.Text = "DefectTypes : "
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDefectTypes
            '
            Me.lblDefectTypes.BackColor = System.Drawing.SystemColors.ControlText
            Me.lblDefectTypes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDefectTypes.ForeColor = System.Drawing.Color.White
            Me.lblDefectTypes.Location = New System.Drawing.Point(104, 88)
            Me.lblDefectTypes.Name = "lblDefectTypes"
            Me.lblDefectTypes.Size = New System.Drawing.Size(832, 32)
            Me.lblDefectTypes.TabIndex = 17
            '
            'lblTestResult_Triage
            '
            Me.lblTestResult_Triage.BackColor = System.Drawing.SystemColors.WindowText
            Me.lblTestResult_Triage.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.lblTestResult_Triage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTestResult_Triage.ForeColor = System.Drawing.Color.White
            Me.lblTestResult_Triage.Location = New System.Drawing.Point(104, 8)
            Me.lblTestResult_Triage.Multiline = True
            Me.lblTestResult_Triage.Name = "lblTestResult_Triage"
            Me.lblTestResult_Triage.Size = New System.Drawing.Size(832, 32)
            Me.lblTestResult_Triage.TabIndex = 16
            Me.lblTestResult_Triage.Text = ""
            '
            '_LabelTestResult_QC
            '
            Me._LabelTestResult_QC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me._LabelTestResult_QC.Location = New System.Drawing.Point(32, 51)
            Me._LabelTestResult_QC.Name = "_LabelTestResult_QC"
            Me._LabelTestResult_QC.Size = New System.Drawing.Size(64, 23)
            Me._LabelTestResult_QC.TabIndex = 15
            Me._LabelTestResult_QC.Text = "QC:"
            Me._LabelTestResult_QC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblTestResult_QC
            '
            Me.lblTestResult_QC.BackColor = System.Drawing.SystemColors.ControlText
            Me.lblTestResult_QC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTestResult_QC.ForeColor = System.Drawing.Color.White
            Me.lblTestResult_QC.Location = New System.Drawing.Point(104, 48)
            Me.lblTestResult_QC.Name = "lblTestResult_QC"
            Me.lblTestResult_QC.Size = New System.Drawing.Size(832, 32)
            Me.lblTestResult_QC.TabIndex = 14
            '
            '_LabelTestResult_Triage
            '
            Me._LabelTestResult_Triage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me._LabelTestResult_Triage.Location = New System.Drawing.Point(24, 11)
            Me._LabelTestResult_Triage.Name = "_LabelTestResult_Triage"
            Me._LabelTestResult_Triage.Size = New System.Drawing.Size(72, 23)
            Me._LabelTestResult_Triage.TabIndex = 9
            Me._LabelTestResult_Triage.Text = "TRIAGE:"
            Me._LabelTestResult_Triage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'tbServices
            '
            Me.tbServices.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlService})
            Me.tbServices.Location = New System.Drawing.Point(4, 22)
            Me.tbServices.Name = "tbServices"
            Me.tbServices.Size = New System.Drawing.Size(968, 470)
            Me.tbServices.TabIndex = 1
            Me.tbServices.Text = "SERVICES"
            '
            'pnlService
            '
            Me.pnlService.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.pnlService.AutoScroll = True
            Me.pnlService.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlService.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label23, Me.Label22, Me.lbl720Parts, Me.lbl600Parts, Me.Label15, Me.Label13, Me.Label9, Me.Label16, Me.Label17, Me.Label14, Me.cb720, Me.cb400, Me.cb600, Me.Label18, Me.Label10, Me.Label12, Me.Label19, Me.cb001, Me.Label11, Me.Label20, Me.cb700, Me.cb500})
            Me.pnlService.Location = New System.Drawing.Point(8, 8)
            Me.pnlService.Name = "pnlService"
            Me.pnlService.Size = New System.Drawing.Size(952, 456)
            Me.pnlService.TabIndex = 109
            '
            'Label23
            '
            Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label23.ForeColor = System.Drawing.Color.Green
            Me.Label23.Location = New System.Drawing.Point(168, 272)
            Me.Label23.Name = "Label23"
            Me.Label23.Size = New System.Drawing.Size(488, 24)
            Me.Label23.TabIndex = 143
            Me.Label23.Text = "(This button will take you to the Reclaimation Screen)"
            '
            'Label22
            '
            Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label22.ForeColor = System.Drawing.Color.Green
            Me.Label22.Location = New System.Drawing.Point(168, 160)
            Me.Label22.Name = "Label22"
            Me.Label22.Size = New System.Drawing.Size(488, 24)
            Me.Label22.TabIndex = 142
            Me.Label22.Text = "(Select Parts from the Parts && RV Parts Tab for this Service Code)"
            '
            'lbl720Parts
            '
            Me.lbl720Parts.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbl720Parts.ForeColor = System.Drawing.Color.Navy
            Me.lbl720Parts.Location = New System.Drawing.Point(424, 248)
            Me.lbl720Parts.Name = "lbl720Parts"
            Me.lbl720Parts.Size = New System.Drawing.Size(216, 23)
            Me.lbl720Parts.TabIndex = 141
            Me.lbl720Parts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lbl600Parts
            '
            Me.lbl600Parts.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbl600Parts.ForeColor = System.Drawing.Color.Navy
            Me.lbl600Parts.Location = New System.Drawing.Point(424, 136)
            Me.lbl600Parts.Name = "lbl600Parts"
            Me.lbl600Parts.Size = New System.Drawing.Size(216, 23)
            Me.lbl600Parts.TabIndex = 140
            Me.lbl600Parts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label15
            '
            Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label15.Location = New System.Drawing.Point(152, 304)
            Me.Label15.Name = "Label15"
            Me.Label15.Size = New System.Drawing.Size(472, 40)
            Me.Label15.TabIndex = 139
            Me.Label15.Text = "Repaired PSS Warranty (Not Implemented)"
            Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label13
            '
            Me.Label13.BackColor = System.Drawing.Color.FromArgb(CType(215, Byte), CType(199, Byte), CType(241, Byte))
            Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Label13.Location = New System.Drawing.Point(20, 248)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(8, 40)
            Me.Label13.TabIndex = 132
            '
            'Label9
            '
            Me.Label9.BackColor = System.Drawing.Color.MediumAquamarine
            Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Label9.Location = New System.Drawing.Point(20, 24)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(8, 40)
            Me.Label9.TabIndex = 128
            '
            'Label16
            '
            Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label16.Location = New System.Drawing.Point(152, 248)
            Me.Label16.Name = "Label16"
            Me.Label16.Size = New System.Drawing.Size(264, 24)
            Me.Label16.TabIndex = 138
            Me.Label16.Text = "Reclamation && Parts Harvesting"
            Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label17
            '
            Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label17.Location = New System.Drawing.Point(152, 192)
            Me.Label17.Name = "Label17"
            Me.Label17.Size = New System.Drawing.Size(264, 40)
            Me.Label17.TabIndex = 137
            Me.Label17.Text = "Scrapping"
            Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label14
            '
            Me.Label14.BackColor = System.Drawing.Color.FromArgb(CType(215, Byte), CType(199, Byte), CType(241, Byte))
            Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Label14.Location = New System.Drawing.Point(20, 192)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(8, 40)
            Me.Label14.TabIndex = 131
            '
            'cb720
            '
            Me.cb720.Appearance = System.Windows.Forms.Appearance.Button
            Me.cb720.BackColor = System.Drawing.SystemColors.Control
            Me.cb720.Enabled = False
            Me.cb720.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cb720.Location = New System.Drawing.Point(32, 248)
            Me.cb720.Name = "cb720"
            Me.cb720.Size = New System.Drawing.Size(104, 40)
            Me.cb720.TabIndex = 126
            Me.cb720.Tag = "2823"
            Me.cb720.Text = "720"
            Me.cb720.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'cb400
            '
            Me.cb400.Appearance = System.Windows.Forms.Appearance.Button
            Me.cb400.BackColor = System.Drawing.SystemColors.Control
            Me.cb400.Enabled = False
            Me.cb400.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cb400.Location = New System.Drawing.Point(32, 24)
            Me.cb400.Name = "cb400"
            Me.cb400.Size = New System.Drawing.Size(104, 40)
            Me.cb400.TabIndex = 122
            Me.cb400.Tag = "2325"
            Me.cb400.Text = "400"
            Me.cb400.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'cb600
            '
            Me.cb600.Appearance = System.Windows.Forms.Appearance.Button
            Me.cb600.BackColor = System.Drawing.SystemColors.Control
            Me.cb600.Enabled = False
            Me.cb600.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cb600.Location = New System.Drawing.Point(32, 136)
            Me.cb600.Name = "cb600"
            Me.cb600.Size = New System.Drawing.Size(104, 40)
            Me.cb600.TabIndex = 124
            Me.cb600.Tag = "2323"
            Me.cb600.Text = "600"
            Me.cb600.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label18
            '
            Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label18.Location = New System.Drawing.Point(152, 80)
            Me.Label18.Name = "Label18"
            Me.Label18.Size = New System.Drawing.Size(264, 40)
            Me.Label18.TabIndex = 136
            Me.Label18.Text = "Test, Triage and Sort"
            Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label10
            '
            Me.Label10.BackColor = System.Drawing.Color.MediumAquamarine
            Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Label10.Location = New System.Drawing.Point(20, 80)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(8, 40)
            Me.Label10.TabIndex = 129
            '
            'Label12
            '
            Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(179, Byte), CType(168, Byte), CType(147, Byte))
            Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Label12.Location = New System.Drawing.Point(20, 304)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(8, 40)
            Me.Label12.TabIndex = 133
            '
            'Label19
            '
            Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label19.Location = New System.Drawing.Point(152, 136)
            Me.Label19.Name = "Label19"
            Me.Label19.Size = New System.Drawing.Size(264, 24)
            Me.Label19.TabIndex = 135
            Me.Label19.Text = "Repair and Refurbish"
            Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cb001
            '
            Me.cb001.Appearance = System.Windows.Forms.Appearance.Button
            Me.cb001.BackColor = System.Drawing.SystemColors.Control
            Me.cb001.Enabled = False
            Me.cb001.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cb001.Location = New System.Drawing.Point(32, 304)
            Me.cb001.Name = "cb001"
            Me.cb001.Size = New System.Drawing.Size(104, 40)
            Me.cb001.TabIndex = 127
            Me.cb001.Tag = "2397"
            Me.cb001.Text = "001"
            Me.cb001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label11
            '
            Me.Label11.BackColor = System.Drawing.Color.MediumAquamarine
            Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Label11.Location = New System.Drawing.Point(20, 136)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(8, 40)
            Me.Label11.TabIndex = 130
            '
            'Label20
            '
            Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label20.Location = New System.Drawing.Point(152, 24)
            Me.Label20.Name = "Label20"
            Me.Label20.Size = New System.Drawing.Size(264, 40)
            Me.Label20.TabIndex = 134
            Me.Label20.Text = "Beyond Repair"
            Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cb700
            '
            Me.cb700.Appearance = System.Windows.Forms.Appearance.Button
            Me.cb700.BackColor = System.Drawing.SystemColors.Control
            Me.cb700.Enabled = False
            Me.cb700.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cb700.Location = New System.Drawing.Point(32, 192)
            Me.cb700.Name = "cb700"
            Me.cb700.Size = New System.Drawing.Size(104, 40)
            Me.cb700.TabIndex = 125
            Me.cb700.Tag = "3020"
            Me.cb700.Text = "700"
            Me.cb700.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'cb500
            '
            Me.cb500.Appearance = System.Windows.Forms.Appearance.Button
            Me.cb500.BackColor = System.Drawing.SystemColors.Control
            Me.cb500.Enabled = False
            Me.cb500.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cb500.Location = New System.Drawing.Point(32, 80)
            Me.cb500.Name = "cb500"
            Me.cb500.Size = New System.Drawing.Size(104, 40)
            Me.cb500.TabIndex = 123
            Me.cb500.Tag = "2849"
            Me.cb500.Text = "500"
            Me.cb500.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'tbRVParts
            '
            Me.tbRVParts.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlRVParts})
            Me.tbRVParts.Location = New System.Drawing.Point(4, 22)
            Me.tbRVParts.Name = "tbRVParts"
            Me.tbRVParts.Size = New System.Drawing.Size(968, 470)
            Me.tbRVParts.TabIndex = 5
            Me.tbRVParts.Text = "RV PARTS"
            '
            'pnlRVParts
            '
            Me.pnlRVParts.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.pnlRVParts.AutoScroll = True
            Me.pnlRVParts.AutoScrollMargin = New System.Drawing.Size(10, 10)
            Me.pnlRVParts.AutoScrollMinSize = New System.Drawing.Size(10, 10)
            Me.pnlRVParts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlRVParts.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.pnlRVParts.Location = New System.Drawing.Point(8, 11)
            Me.pnlRVParts.Name = "pnlRVParts"
            Me.pnlRVParts.Size = New System.Drawing.Size(952, 448)
            Me.pnlRVParts.TabIndex = 109
            '
            'tpPartHistory
            '
            Me.tpPartHistory.Controls.AddRange(New System.Windows.Forms.Control() {Me.dgConsumed})
            Me.tpPartHistory.Location = New System.Drawing.Point(4, 22)
            Me.tpPartHistory.Name = "tpPartHistory"
            Me.tpPartHistory.Size = New System.Drawing.Size(968, 430)
            Me.tpPartHistory.TabIndex = 11
            Me.tpPartHistory.Text = "Trans History"
            '
            'dgConsumed
            '
            Me.dgConsumed.AllowUpdate = False
            Me.dgConsumed.AlternatingRows = True
            Me.dgConsumed.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dgConsumed.Caption = "Consumed"
            Me.dgConsumed.FilterBar = True
            Me.dgConsumed.GroupByCaption = "Drag a column header here to group by that column"
            Me.dgConsumed.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.dgConsumed.Location = New System.Drawing.Point(12, 31)
            Me.dgConsumed.Name = "dgConsumed"
            Me.dgConsumed.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dgConsumed.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dgConsumed.PreviewInfo.ZoomFactor = 75
            Me.dgConsumed.Size = New System.Drawing.Size(804, 400)
            Me.dgConsumed.TabIndex = 147
            Me.dgConsumed.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Normal{BackColor:SteelBlue;}Selected{ForeColo" & _
            "r:HighlightText;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{" & _
            "}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{BackColor:LightSteelB" & _
            "lue;}Style13{}Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;" & _
            "}RecordSelector{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:" & _
            "InactiveCaptionText;BackColor:InactiveCaption;}EvenRow{BackColor:NavajoWhite;}He" & _
            "ading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText" & _
            ";BackColor:Control;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, style=Bold;Fore" & _
            "Color:Red;BackColor:White;}Style4{}Style9{}Style8{}Style5{}Group{BackColor:Contr" & _
            "olDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style7{}Style6{}Style1{}Style3{" & _
            "}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" Alternat" & _
            "ingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeigh" & _
            "t=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17""" & _
            " DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>3" & _
            "79</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 17, 800, 379" & _
            "</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win" & _
            ".C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><St" & _
            "yle parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style " & _
            "parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style p" & _
            "arent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style paren" & _
            "t=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style pare" & _
            "nt=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style p" & _
            "arent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyl" & _
            "es><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Def" & _
            "aultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 800, 396</ClientArea><P" & _
            "rintPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=" & _
            """Style21"" /></Blob>"
            '
            'tpPrevRep
            '
            Me.tpPrevRep.BackColor = System.Drawing.Color.SteelBlue
            Me.tpPrevRep.Controls.AddRange(New System.Windows.Forms.Control() {Me.dgPrevRepPartsServ, Me.Label4, Me.lblPrevRepTechNote, Me.dgPreRepDev})
            Me.tpPrevRep.Location = New System.Drawing.Point(4, 22)
            Me.tpPrevRep.Name = "tpPrevRep"
            Me.tpPrevRep.Size = New System.Drawing.Size(968, 430)
            Me.tpPrevRep.TabIndex = 12
            Me.tpPrevRep.Text = "Prev Repair"
            '
            'dgPrevRepPartsServ
            '
            Me.dgPrevRepPartsServ.AllowUpdate = False
            Me.dgPrevRepPartsServ.AlternatingRows = True
            Me.dgPrevRepPartsServ.Caption = "Part(s) / Service"
            Me.dgPrevRepPartsServ.FilterBar = True
            Me.dgPrevRepPartsServ.GroupByCaption = "Drag a column header here to group by that column"
            Me.dgPrevRepPartsServ.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.dgPrevRepPartsServ.Location = New System.Drawing.Point(16, 184)
            Me.dgPrevRepPartsServ.Name = "dgPrevRepPartsServ"
            Me.dgPrevRepPartsServ.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dgPrevRepPartsServ.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dgPrevRepPartsServ.PreviewInfo.ZoomFactor = 75
            Me.dgPrevRepPartsServ.Size = New System.Drawing.Size(680, 256)
            Me.dgPrevRepPartsServ.TabIndex = 159
            Me.dgPrevRepPartsServ.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Normal{BackColor:SteelBlue;}Selected{ForeColo" & _
            "r:HighlightText;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{" & _
            "}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{BackColor:LightSteelB" & _
            "lue;}Style13{}Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;" & _
            "}RecordSelector{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:" & _
            "InactiveCaptionText;BackColor:InactiveCaption;}EvenRow{BackColor:NavajoWhite;}He" & _
            "ading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText" & _
            ";BackColor:Control;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, style=Bold;Fore" & _
            "Color:Red;BackColor:White;}Style4{}Style9{}Style8{}Style5{}Group{BackColor:Contr" & _
            "olDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style7{}Style6{}Style1{}Style3{" & _
            "}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" Alternat" & _
            "ingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeigh" & _
            "t=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17""" & _
            " DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>2" & _
            "35</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 17, 676, 235" & _
            "</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win" & _
            ".C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><St" & _
            "yle parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style " & _
            "parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style p" & _
            "arent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style paren" & _
            "t=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style pare" & _
            "nt=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style p" & _
            "arent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyl" & _
            "es><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Def" & _
            "aultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 676, 252</ClientArea><P" & _
            "rintPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=" & _
            """Style21"" /></Blob>"
            '
            'Label4
            '
            Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(712, 184)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(120, 16)
            Me.Label4.TabIndex = 157
            Me.Label4.Text = "Work performance:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'lblPrevRepTechNote
            '
            Me.lblPrevRepTechNote.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.lblPrevRepTechNote.BackColor = System.Drawing.Color.Black
            Me.lblPrevRepTechNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPrevRepTechNote.ForeColor = System.Drawing.Color.White
            Me.lblPrevRepTechNote.Location = New System.Drawing.Point(712, 200)
            Me.lblPrevRepTechNote.Name = "lblPrevRepTechNote"
            Me.lblPrevRepTechNote.Size = New System.Drawing.Size(240, 240)
            Me.lblPrevRepTechNote.TabIndex = 156
            Me.lblPrevRepTechNote.Text = "lan test"
            '
            'dgPreRepDev
            '
            Me.dgPreRepDev.AllowUpdate = False
            Me.dgPreRepDev.AlternatingRows = True
            Me.dgPreRepDev.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dgPreRepDev.Caption = "Device Information"
            Me.dgPreRepDev.FilterBar = True
            Me.dgPreRepDev.GroupByCaption = "Drag a column header here to group by that column"
            Me.dgPreRepDev.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.dgPreRepDev.Location = New System.Drawing.Point(16, 8)
            Me.dgPreRepDev.Name = "dgPreRepDev"
            Me.dgPreRepDev.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dgPreRepDev.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dgPreRepDev.PreviewInfo.ZoomFactor = 75
            Me.dgPreRepDev.Size = New System.Drawing.Size(936, 168)
            Me.dgPreRepDev.TabIndex = 148
            Me.dgPreRepDev.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Normal{BackColor:SteelBlue;}Selected{ForeColo" & _
            "r:HighlightText;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{" & _
            "}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{BackColor:LightSteelB" & _
            "lue;}Style13{}Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;" & _
            "}RecordSelector{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:" & _
            "InactiveCaptionText;BackColor:InactiveCaption;}EvenRow{BackColor:NavajoWhite;}He" & _
            "ading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlTex" & _
            "t;AlignVert:Center;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, style=Bold;Fore" & _
            "Color:Red;BackColor:White;}Style4{}Style9{}Style8{}Style5{}Group{AlignVert:Cente" & _
            "r;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style7{}Style6{}Style1{}Style3{" & _
            "}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" Alternat" & _
            "ingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeigh" & _
            "t=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17""" & _
            " DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>1" & _
            "47</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 17, 932, 147" & _
            "</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win" & _
            ".C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><St" & _
            "yle parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style " & _
            "parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style p" & _
            "arent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style paren" & _
            "t=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style pare" & _
            "nt=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style p" & _
            "arent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyl" & _
            "es><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Def" & _
            "aultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 932, 164</ClientArea><P" & _
            "rintPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=" & _
            """Style21"" /></Blob>"
            '
            'btnClear
            '
            Me.btnClear.Location = New System.Drawing.Point(248, 32)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(88, 24)
            Me.btnClear.TabIndex = 2
            Me.btnClear.Text = "&Clear"
            '
            'btnComplete
            '
            Me.btnComplete.BackColor = System.Drawing.Color.Green
            Me.btnComplete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnComplete.ForeColor = System.Drawing.Color.White
            Me.btnComplete.Location = New System.Drawing.Point(352, 64)
            Me.btnComplete.Name = "btnComplete"
            Me.btnComplete.Size = New System.Drawing.Size(136, 24)
            Me.btnComplete.TabIndex = 4
            Me.btnComplete.Text = "Complete Device"
            '
            'lblCustName
            '
            Me.lblCustName.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCustName.ForeColor = System.Drawing.Color.RoyalBlue
            Me.lblCustName.Location = New System.Drawing.Point(8, 8)
            Me.lblCustName.Name = "lblCustName"
            Me.lblCustName.Size = New System.Drawing.Size(128, 16)
            Me.lblCustName.TabIndex = 135
            Me.lblCustName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblScreenName
            '
            Me.lblScreenName.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblScreenName.ForeColor = System.Drawing.Color.RoyalBlue
            Me.lblScreenName.Location = New System.Drawing.Point(152, 8)
            Me.lblScreenName.Name = "lblScreenName"
            Me.lblScreenName.Size = New System.Drawing.Size(136, 16)
            Me.lblScreenName.TabIndex = 138
            Me.lblScreenName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblModel
            '
            Me.lblModel.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModel.ForeColor = System.Drawing.Color.RoyalBlue
            Me.lblModel.Location = New System.Drawing.Point(288, 8)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(168, 16)
            Me.lblModel.TabIndex = 139
            Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblWipLoc
            '
            Me.lblWipLoc.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWipLoc.ForeColor = System.Drawing.Color.RoyalBlue
            Me.lblWipLoc.Location = New System.Drawing.Point(560, 8)
            Me.lblWipLoc.Name = "lblWipLoc"
            Me.lblWipLoc.Size = New System.Drawing.Size(208, 16)
            Me.lblWipLoc.TabIndex = 141
            Me.lblWipLoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnQuoteSumitted
            '
            Me.btnQuoteSumitted.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnQuoteSumitted.Location = New System.Drawing.Point(784, 8)
            Me.btnQuoteSumitted.Name = "btnQuoteSumitted"
            Me.btnQuoteSumitted.Size = New System.Drawing.Size(96, 22)
            Me.btnQuoteSumitted.TabIndex = 143
            Me.btnQuoteSumitted.Text = "Submit Estimate"
            Me.btnQuoteSumitted.Visible = False
            '
            'lblPSSWrtyStatus
            '
            Me.lblPSSWrtyStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblPSSWrtyStatus.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPSSWrtyStatus.ForeColor = System.Drawing.Color.Red
            Me.lblPSSWrtyStatus.Location = New System.Drawing.Point(448, 32)
            Me.lblPSSWrtyStatus.Name = "lblPSSWrtyStatus"
            Me.lblPSSWrtyStatus.Size = New System.Drawing.Size(48, 20)
            Me.lblPSSWrtyStatus.TabIndex = 144
            Me.lblPSSWrtyStatus.Text = "OW"
            Me.lblPSSWrtyStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label6
            '
            Me.Label6.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.RoyalBlue
            Me.Label6.Location = New System.Drawing.Point(344, 34)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(96, 16)
            Me.Label6.TabIndex = 146
            Me.Label6.Text = "PSSI WRTY:"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtEstimateQuote
            '
            Me.txtEstimateQuote.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.txtEstimateQuote.Location = New System.Drawing.Point(88, 8)
            Me.txtEstimateQuote.Name = "txtEstimateQuote"
            Me.txtEstimateQuote.Size = New System.Drawing.Size(48, 20)
            Me.txtEstimateQuote.TabIndex = 147
            Me.txtEstimateQuote.Text = ""
            '
            'Label5
            '
            Me.Label5.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label5.Location = New System.Drawing.Point(80, 8)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(8, 16)
            Me.Label5.TabIndex = 148
            Me.Label5.Text = "$"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboOBCosmGrade
            '
            Me.cboOBCosmGrade.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboOBCosmGrade.Caption = ""
            Me.cboOBCosmGrade.CaptionHeight = 17
            Me.cboOBCosmGrade.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboOBCosmGrade.ColumnCaptionHeight = 17
            Me.cboOBCosmGrade.ColumnFooterHeight = 17
            Me.cboOBCosmGrade.ContentHeight = 15
            Me.cboOBCosmGrade.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboOBCosmGrade.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboOBCosmGrade.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboOBCosmGrade.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboOBCosmGrade.EditorHeight = 15
            Me.cboOBCosmGrade.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboOBCosmGrade.Images.Add(CType(resources.GetObject("resource.Images5"), System.Drawing.Bitmap))
            Me.cboOBCosmGrade.ItemHeight = 15
            Me.cboOBCosmGrade.Location = New System.Drawing.Point(104, 64)
            Me.cboOBCosmGrade.MatchEntryTimeout = CType(2000, Long)
            Me.cboOBCosmGrade.MaxDropDownItems = CType(5, Short)
            Me.cboOBCosmGrade.MaxLength = 32767
            Me.cboOBCosmGrade.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboOBCosmGrade.Name = "cboOBCosmGrade"
            Me.cboOBCosmGrade.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboOBCosmGrade.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboOBCosmGrade.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboOBCosmGrade.Size = New System.Drawing.Size(112, 21)
            Me.cboOBCosmGrade.TabIndex = 5
            Me.cboOBCosmGrade.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            Me.Label7.Location = New System.Drawing.Point(8, 64)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(88, 16)
            Me.Label7.TabIndex = 150
            Me.Label7.Text = "Cosm Grade:"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblEDIRepType
            '
            Me.lblEDIRepType.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblEDIRepType.ForeColor = System.Drawing.Color.RoyalBlue
            Me.lblEDIRepType.Location = New System.Drawing.Point(552, 32)
            Me.lblEDIRepType.Name = "lblEDIRepType"
            Me.lblEDIRepType.Size = New System.Drawing.Size(208, 16)
            Me.lblEDIRepType.TabIndex = 151
            Me.lblEDIRepType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'pnlQuote
            '
            Me.pnlQuote.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtEstimateQuote, Me.Label5})
            Me.pnlQuote.Location = New System.Drawing.Point(784, 48)
            Me.pnlQuote.Name = "pnlQuote"
            Me.pnlQuote.Size = New System.Drawing.Size(144, 32)
            Me.pnlQuote.TabIndex = 3
            Me.pnlQuote.Visible = False
            '
            'pnlDefectReason
            '
            Me.pnlDefectReason.Location = New System.Drawing.Point(512, 24)
            Me.pnlDefectReason.Name = "pnlDefectReason"
            Me.pnlDefectReason.Size = New System.Drawing.Size(40, 24)
            Me.pnlDefectReason.TabIndex = 152
            '
            'cbCustAbuse
            '
            Me.cbCustAbuse.AutoCheck = False
            Me.cbCustAbuse.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cbCustAbuse.Location = New System.Drawing.Point(552, 64)
            Me.cbCustAbuse.Name = "cbCustAbuse"
            Me.cbCustAbuse.Size = New System.Drawing.Size(16, 16)
            Me.cbCustAbuse.TabIndex = 153
            '
            'Label21
            '
            Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label21.Location = New System.Drawing.Point(576, 60)
            Me.Label21.Name = "Label21"
            Me.Label21.Size = New System.Drawing.Size(168, 23)
            Me.Label21.TabIndex = 154
            Me.Label21.Text = "Customer Abuse Indicated"
            Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'frmBilling
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(992, 598)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label21, Me.cbCustAbuse, Me.btnClear, Me.pnlDefectReason, Me.pnlQuote, Me.lblEDIRepType, Me.cboOBCosmGrade, Me.Label7, Me.Label6, Me.lblPSSWrtyStatus, Me.lblWipLoc, Me.lblModel, Me.lblScreenName, Me.lblCustName, Me.btnComplete, Me.tabMain, Me.txtSerial, Me.lblDeviceSN, Me.btnQuoteSumitted})
            Me.Name = "frmBilling"
            Me.Text = "frmBilling"
            Me.tabMain.ResumeLayout(False)
            Me.tbParts.ResumeLayout(False)
            Me.tbTestResults.ResumeLayout(False)
            Me.pnlDefectClass.ResumeLayout(False)
            CType(Me.cboDefectClass1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlTestResults.ResumeLayout(False)
            Me.tbServices.ResumeLayout(False)
            Me.pnlService.ResumeLayout(False)
            Me.tbRVParts.ResumeLayout(False)
            Me.tpPartHistory.ResumeLayout(False)
            CType(Me.dgConsumed, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpPrevRep.ResumeLayout(False)
            CType(Me.dgPrevRepPartsServ, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dgPreRepDev, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboOBCosmGrade, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlQuote.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region
#Region "DECLARATIONS"

        Private Const _custAbuseID = 2324
        Private _loading As Boolean = False
        Private _resetBER As Boolean = False
        Private _allowAutoShip As Boolean = False
        Private _strScreenName As String = "REPAIR"
        Private _iScreenID As Integer = 3414
        Private Const vBuffer As Integer = 5
        Private Const hBuffer As Integer = 5
        Private Const btnWidth = 120
        Private Const btnHeight = 50
        Private btnLeft As Int32 = 5
        Private btnTop As Int32 = 5
        Private pnlLeft As Integer
        Private pnlWidth As Integer
        Private origFrmWidth As Integer
        Private formDiffWidth As Integer
        Private colCount As Integer
        Private _objNewTech As PSS.Data.Buisness.NewTech
        Private _objNI As PSS.Data.Buisness.NI
        Private _device As Device = Nothing
        Private tmpDeviceID, tmpModelID, tmpManufID, tmpProdID, tmpLoc, tmpCustID, tmpWO, tmpDeviceType, tmpConsignedParts, tmpCustCRbill As Integer
        Private vManufWrty As Integer = 0
        Private _iPSSWrty As Integer = 0
        Private zCount As Integer
        Private rPresent As DataRow
        Private _drPreBillData, _drCelloptData As DataRow
        Private _iMachineGrpID As Integer = 0
        Private _iDeviceWipOwner As Integer = 0
        'WARRANTY CLAIM
        Private _iFailID As Integer = 0
        Private _iRepairID As Integer = 0
        Private _iBillType As Integer = 0
        Private _booPopulatingReflowCheckListFlg As Boolean = False
        'This customer ID send from the menu selection
        Private _iSCustID As Integer = 0
        Private _booStationCheck As Boolean = True
        Private _strReceiptDate As String = ""
        Private _iMaxSelectedReasons As Integer = 2 '2 reasons allowed to select at most
        Private _tts_already_selected As Boolean

#End Region
#Region "FORM EVENTS"

        Private Sub frmNewTech_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable
            Try
                Me._objNI = New PSS.Data.Buisness.NI()
                Me.pnlDefectClass.Enabled = False
                Me._objNewTech = New PSS.Data.Buisness.NewTech()
                origFrmWidth = Me.Width
                txtSerial.Focus()
                Me.lblScreenName.Text = Me._strScreenName
                'Load outbound cosmetic grade
                dt = PSS.Data.Buisness.Generic.GetCosmeticGrades(True)
                Misc.PopulateC1DropDownList(Me.cboOBCosmGrade, dt, "DCode_LDesc", "DCode_ID")
                Me.cboOBCosmGrade.SelectedValue = 0
                LoadDefectReasons()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmNewTech_Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub
        Private Sub frmBilling_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
            SetAggragateButtons()
            EnableControls()
            AdjustCBColor()
        End Sub

#End Region

#Region "PROPERTIES"

        Private ReadOnly Property IsChecked_SC400() As Boolean
            Get
                Return (_device.Parts.Select("billcode_id = 2325").Length > 0)
            End Get
        End Property
        Private ReadOnly Property IsChecked_SC500() As Boolean
            Get
                Return (_device.Parts.Select("billcode_id = 2849").Length > 0)
            End Get
        End Property
        Private ReadOnly Property IsChecked_SC600() As Boolean
            Get
                Return (PartsCount() > 0)
            End Get
        End Property
        Private ReadOnly Property IsChecked_SC700() As Boolean
            Get
                Return (_device.Parts.Select("billcode_id = 3020").Length > 0)
            End Get
        End Property
        Private ReadOnly Property IsChecked_SC720() As Boolean
            Get
                Return (_objNewTech.GetReclaimParts(_device.ID).Rows.Count > 0)
            End Get
        End Property
        'Private ReadOnly Property IsChecked_SC001() As Boolean
        '    Get

        '    End Get
        'End Property

#End Region

#Region "CONTROL EVENTS"

        Private Sub txtSerial_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSerial.KeyDown
            Me.Cursor = Cursors.WaitCursor
            _loading = True
            If e.KeyValue = 13 AndAlso Me.txtSerial.Text.Trim.Length > 0 Then
                Me.ProcessSN()
                If Not IsNothing(_device) Then
                    EnableControls()
                End If
            End If
            _loading = False
            Me.Cursor = Cursors.Default
        End Sub
        Private Sub tabMain_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabMain.SelectedIndexChanged
            EnableControls()
        End Sub
        Private Sub cb400_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cb400.Click
            If _loading Then
                Exit Sub
            End If
            cb400.BackColor = IIf(cb400.Checked, Color.MediumAquamarine, SystemColors.Control)
            If cb400.Checked Then
                If ContinueWithBer() Then
                    billingClick(sender, e)
                Else
                    cb400.Checked = False
                End If
            End If
            EnableControls()
            AdjustCBColor()
        End Sub
        Private Sub cb500_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cb500.CheckedChanged
            If _loading Then
                Exit Sub
            End If
            cb500.BackColor = IIf(cb500.Checked, Color.MediumAquamarine, SystemColors.Control)
            billingClick(sender, e)
            EnableControls()
        End Sub
        Private Sub cb600_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cb600.Click
            If _loading Then
                Exit Sub
            End If
            _device.ReFreshBilledData()
            If PartsCount() < 1 And cb600.Checked Then
                MessageBox.Show("Please select a part before selecting this Serive Code.", Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Information)
                cb600.Checked = False
                Exit Sub
            Else
                cb600.Checked = True
            End If
            cb600.BackColor = IIf(cb600.Checked, Color.MediumAquamarine, SystemColors.Control)
            billingClick(sender, e)
            EnableControls()
        End Sub
        Private Sub cb700_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cb700.CheckedChanged
            If _loading Then
                Exit Sub
            End If
            cb700.BackColor = IIf(cb700.Checked, Color.FromArgb(215, 199, 241), SystemColors.Control)
            billingClick(sender, e)
            EnableControls()
        End Sub
        Private Sub cb720_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cb720.Click
            If _loading Then
                Exit Sub
            End If
            Dim _frm As New frmPartReclaim(_device.CustID, 3332, Me.Name, txtSerial.Text)
            _frm.ShowDialog(Me)
            Me.Cursor = Cursors.WaitCursor
            SetAggragateButtons()
            UpdateLabels()
            EnableControls()
            AdjustCBColor()
            Me.Cursor = Cursors.Default
        End Sub
        Private Sub cb001_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cb001.CheckedChanged
            cb001.BackColor = IIf(cb001.Checked, Color.FromArgb(179, 168, 147), SystemColors.Control)
            billingClick(sender, e)
            EnableControls()
        End Sub
        Private Sub billingClick(ByVal sender As Object, ByVal e As System.EventArgs)
            If _loading Then Exit Sub
            Dim iFailID, iRepairID, iComplainID, iRVPart, iConsignedPart As Integer
            Dim dr1, drAddingBillcode As DataRow
            Dim x As Integer
            Dim action As String
            Dim strAddPartNo, strBilledPartNo As String
            Dim dtContingent As DataTable
            Dim booIsRVPart As Boolean = False, booHasReclaimParts As Boolean = False
            Try
                'CHECK IF ANY DEFECTCLASS SELECTED.
                If Me.tabMain.SelectedTab.Name.Trim.ToUpper = "tbServices".ToUpper _
                   AndAlso sender.tag.ToString = "2323" Then
                    ' FOR DEPOT REPAIR CHECK IF ANY DEFECTCLASS SELECTED.
                    loadDefectClassesSelected()
                    If Me.tdgData1.RowCount = 0 Then
                        MessageBox.Show("Please select defect class (Go to tab TEST RESULTS).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                ElseIf Me.tabMain.SelectedTab.Name.Trim.ToUpper = "tbParts".ToUpper Then
                    'FOR PARTS CHECK IF ANY DEFECTCLASS SELECTED.
                    loadDefectClassesSelected()
                    If Me.tdgData1.RowCount = 0 Then
                        MessageBox.Show("Please select defect class (Go to tab TEST RESULTS).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                End If

                ' REFRESH BILLED DATA IF THERE ARE RECLAIMED PARTS.
                strAddPartNo = "" : strBilledPartNo = "" : iFailID = 0 : iRepairID = 0 : iComplainID = 0 : iRVPart = 0 : iConsignedPart = 0
                booHasReclaimParts = Me._objNewTech.IsDevHasReclaimParts(Me.tmpDeviceID)
                Me._device.ReFreshBilledData()

                ' DETERMINE ACTION TO BE PERFORMED.
                If sender.GetType.ToString = "System.Windows.Forms.CheckBox" Then
                    action = IIf(sender.checked, "add", "remove")
                Else
                    action = "add"
                    If Me._device.Parts.Select("Billcode_ID = " & CInt(sender.tag.ToString)).Length > 0 Then action = "remove"
                End If

                'VALIDATE RECLAMATION.
                If action = "add" AndAlso Me.lblEDIRepType.Text.Trim.ToLower = "repairthisunit" AndAlso sender.tag.ToString.Trim = Data.Buisness.NI.RECLAIM_BILLCODE Then
                    MessageBox.Show("Can't Reclaim part on 'repairthisunit' unit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                'VALIDATE PSS WRTY AND ONLY ONE SHIP BACK HARD DRIVE CAN BE BILLED.
                If action = "add" AndAlso (sender.text = "PSS Warranty NFF" OrElse sender.text = "Repaired PSS Warranty") AndAlso Me._iPSSWrty = 0 Then
                    MessageBox.Show("This device is not under PSS warranty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                ElseIf action = "add" AndAlso sender.text.ToString.Trim.ToLower.StartsWith("ship back hard drive") AndAlso Me._device.Parts.Select("Billcode_Desc = 'Ship Back Hard Drive' or Billcode_Desc = 'Ship Back Hard Drive With Unit'").Length > 0 Then
                    MessageBox.Show("Only allow one ""Ship Back Hard Drive"" service.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                'If sender.tag.ToString() <> "3020" And _device.BillableBillcodes.Rows.Count > 0 Then
                If action = "add" AndAlso ValidateSelectionOfServiceBillcode(Convert.ToInt32(sender.tag), sender.Text) = False Then
                    Exit Sub
                End If
                'End If

                'DEFINE ADDING PART #.
                If action = "add" AndAlso Me._device.BillableBillcodes.Select("Billcode_ID = " & CInt(sender.tag.ToString)).Length = 0 Then
                    MessageBox.Show("Billcode ID is missing in billable list. Please refresh the screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                Else
                    strAddPartNo = Me._device.BillableBillcodes.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0)("PSPrice_Number").ToString.ToLower
                    iRVPart = Me._device.BillableBillcodes.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0)("RVFlag")
                    If iRVPart = 1 Then booIsRVPart = True
                    iConsignedPart = Me._device.BillableBillcodes.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0)("PSPrice_ConsignedPart")
                End If
                If action = "add" AndAlso Me.ValidateRVOEMAndConsighnedPartSelection(strAddPartNo, CInt(Trim(sender.tag.ToString)), iRVPart, iConsignedPart) = False Then
                    'RV, EOM AND CONSIGNED PARTS VALIDATION 05/05/2011
                    Exit Sub
                End If

                ' COLLECT REAL PART AND REPALCE WITH TEMPORAY PART.
                If action = "add" AndAlso (strAddPartNo.Trim.ToLower.Equals("temppart") = True OrElse strAddPartNo.Trim.ToLower.Equals("temppart_rv") = True) AndAlso Me.CollectPartAndReplaceTempPartInBOM(sender.tag.ToString.Trim, booIsRVPart) = False Then
                    Exit Sub
                End If
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                dtContingent = Me._objNewTech.GetContingentBillcodes(Trim(sender.tag.ToString), tmpModelID, tmpLoc)

                ' ADD OR REMOVE PARTS.
                If action = "remove" Then   '//turn off
                    For Each dr1 In dtContingent.Rows
                        If PSS.Data.Buisness.Generic.IsBillcodeExisted(Me.tmpDeviceID, dr1("cbill_contBillcode")) Then
                            Me._device.DeletePart(dr1("cbill_contBillcode"))
                        End If
                    Next dr1
                    deleteComponent(Trim(sender.tag.ToString))
                Else    '//turn on
                    For Each dr1 In dtContingent.Rows
                        If PSS.Data.Buisness.Generic.IsBillcodeMapped(tmpModelID, dr1("cbill_contBillcode")) > 0 AndAlso _
                                PSS.Data.Buisness.Generic.IsBillcodeExisted(Me.tmpDeviceID, dr1("cbill_contBillcode")) = False Then
                            Me._device.AddPart(dr1("cbill_contBillcode"))
                        End If
                    Next dr1
                    addComponent(Trim(sender.tag.ToString))
                End If

                ' ADD OR REMOVE THE SERVICE CODE 600 IF NEEDED.
                If PartsCount() > 0 Then
                    AddSC600()
                    cb600.Checked = True
                Else
                    DeleteSC600()
                    cb600.Checked = False
                End If

                'IF BER, CLEAR DEFECT CLASSES SELECTED IF ANY. WE ONLY KEEP IT FOR DEPOT REPAIR.
                If Me.tabMain.SelectedTab.Name.Trim.ToUpper = "tbServices".ToUpper _
                   AndAlso sender.tag.ToString = "2325" Then 'BER
                    ClearAllDefectClasses()
                End If

                'AUTO SHIP BER OF NONE REPAIRTHISUNIT.
                If Me.lblEDIRepType.Text.Trim.ToLower <> "repairthisunit" AndAlso Me._device.RUR_DBR = True Then
                    Me.NIAutoShip(Me.tmpDeviceID, Me.tmpWO)
                    Me.btnClear_Click(Nothing, Nothing)
                    Exit Sub
                End If

                If Me.tabMain.SelectedTab.Name.Trim.ToUpper <> "tbServices".ToUpper Then
                    Me.HighLightSelectedButtons()
                End If

                If PartsCount() > 0 Then cb600.Checked = True
                UpdateLabels()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "BillingButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                dr1 = Nothing : Buisness.Generic.DisposeDT(dtContingent)
                'RESET FAIL AND REPAIR CODE ID.
                If Not IsNothing(Me._device) Then
                    Me._device.FailID = 0 : Me._device.RepairID = 0 : Me._device.ComplainID = 0
                End If
                EnableControls()

            End Try
        End Sub
        Private Sub btnComplete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComplete.Click
            Dim iTestTypeID As Integer = 7
            Dim iRework As Integer = 1
            Dim objTFMisc As PSS.Data.Buisness.TracFone.clsMisc
            Dim dialogMsg As Windows.Forms.DialogResult
            Dim strFrStation, strToStation As String

            Try
                If Me.txtSerial.Text.Trim.Length = 0 Then
                    Exit Sub
                ElseIf tmpDeviceID = 0 Then
                    MsgBox("This device can not be identified. Can NOT complete.", MsgBoxStyle.Exclamation, "ERROR")
                    Me.txtSerial.SelectAll() : Me.txtSerial.Focus() : Exit Sub
                ElseIf Me._device.Parts.Rows.Count = 0 Then
                    MessageBox.Show("Can't complete without any billing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me._device.RUR_DBR = False AndAlso Me._device.NEr = False AndAlso Me.cboOBCosmGrade.SelectedValue = 0 Then
                    MessageBox.Show("Please select comestic grade.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboOBCosmGrade.SelectAll() : Me.cboOBCosmGrade.Focus() : Exit Sub
                Else
                    Me.pnlBill.BackColor = Me.BackColor
                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor
                    strFrStation = PSS.Data.Buisness.Generic.GetCurrentWorkstaion(Me.tmpDeviceID) : strToStation = ""
                    If SetDeviceWipStation(strToStation) = True Then
                        'Write Refurbished completed record
                        If iTestTypeID > 0 Then
                            objTFMisc = New PSS.Data.Buisness.TracFone.clsMisc()
                            objTFMisc.WriteTestResult(Me.tmpDeviceID, iTestTypeID, PSS.Core.Global.ApplicationUser.IDuser, 0, iRework, , , , , , , PSS.Data.Buisness.Generic.GetMachineCostCenterID(), strFrStation, strToStation)
                        End If
                        'Update Cellopt completed data
                        Me._objNewTech.UpdateRefurbCompletedData(Me.tmpDeviceID, 0, ApplicationUser.IDuser, ApplicationUser.LineID, True)
                        ' ADD SCRAPPING PALETT ID TO DEVICE RECORD IF SCRAPPING OR RECLAMATION.
                        If cb700.Checked OrElse cb720.Checked Then
                            _objNI.CompleteScrapDevice(_device.ID)
                        End If
                        ' BILL FOR CUSTOMER ABUSE IF NEEDED.
                        If cbCustAbuse.Checked Then
                            If _device.Parts.Select("[Billcode_ID] = " & _custAbuseID.ToString()).Length = 0 Then
                                Me._device.AddPart(_custAbuseID)
                            End If
                        End If
                        Me.Enabled = False : Cursor.Current = Cursors.Default
                        Me.dgConsumed.DataSource = Nothing
                        btnClear_Click(sender, e)
                        txtSerial.Focus()
                    End If

                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnComplete_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                objTFMisc = Nothing
                EnableControls()
                AdjustCBColor()
                Me.txtSerial.Focus()
            End Try
        End Sub
        Private Sub frmNewTech_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize

            colCount = 0

            btnLeft = hBuffer
            btnTop = vBuffer

            formDiffWidth += Me.Width - origFrmWidth

            Dim x As Integer
            Dim tmpBtn As System.Windows.Forms.Button
            For x = 0 To pnlBill.Controls.Count - 1
                tmpBtn = CType(pnlBill.Controls(x), System.Windows.Forms.Button)
                With tmpBtn
                    .Location = New Point(btnLeft, btnTop)
                End With

                colCount += 1
                If colCount > 6 Then
                    btnLeft = btnLeft + btnWidth + 5
                    btnTop = vBuffer
                    colCount = 0
                Else
                    btnTop = btnTop + btnHeight + 5
                End If

            Next

            btnLeft = hBuffer
            btnTop = vBuffer

            For x = 0 To pnlService.Controls.Count - 1
                If pnlService.Controls(x).GetType().ToString() = "System.Windows.Forms.Button" Then
                    tmpBtn = CType(pnlService.Controls(x), System.Windows.Forms.Button)
                    With tmpBtn
                        .Location = New Point(btnLeft, btnTop)
                    End With

                    colCount += 1
                    If colCount > 6 Then
                        btnLeft = btnLeft + btnWidth + 5
                        btnTop = vBuffer
                        colCount = 0
                    Else
                        btnTop = btnTop + btnHeight + 5
                    End If
                End If

            Next

        End Sub
        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
            ' Added by Lan on 10/19/2007.  Get Prebill data.
            Dim iIsDevHaspart As Integer = 0
            Dim booUpdateTechInfo As Boolean = True
            Me.Cursor = Cursors.WaitCursor
            If Trim(Me.txtSerial.Text) <> "" And Me.tmpDeviceID > 0 Then
                Try
                    If Me.tmpCustID <> 2253 AndAlso Not (Me.tmpProdID = 9 AndAlso Me._device.Parts.Select("[Billcode_ID] = 1590").Length > 0) Then
                        If Me.tmpCustID = 2258 Then booUpdateTechInfo = False 'don't update tech data for Tracfone Customer
						Me._objNewTech.UpdateWipOwnerID(tmpDeviceID, Me.tmpProdID, PSS.Core.ApplicationUser.IDuser, Me._iDeviceWipOwner, booUpdateTechInfo, , "Billing Screen")
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.ToString, "Send Device to WaitingPart", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                End Try
            End If
            _loading = True
            cb400.Checked = False
            cb500.Checked = False
            cb600.Checked = False
            cb700.Checked = False
            cb720.Checked = False
            cb001.Checked = False
            lbl600Parts.Text = ""
            lbl720Parts.Text = ""
            cbCustAbuse.Checked = False
            AdjustCBColor()
            Me.dgConsumed.DataSource = Nothing
            Me.ButtonClear_ClickEvent()
            EnableControls()
            Me.txtSerial.Focus()
            _loading = False
            Me.Cursor = Cursors.Default
        End Sub
        Private Sub btnQuoteSumitted_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuoteSumitted.Click
            Const iNIStatus As Integer = 4
            Dim strNIStatusDesc, strEstimatedPrice As String
            Dim objTMI As New PSS.Data.Buisness.TMIRecShip()
            Dim strQuoteSubmittedDate As String = ""

            Try
                strNIStatusDesc = "" : strEstimatedPrice = ""
                If Me.tmpDeviceID > 0 Then
                    strQuoteSubmittedDate = objTMI.GetQuoteSubmittedDate(Me.tmpWO)
                    If Me.txtEstimateQuote.Text.Trim.Length > 0 Then
                        strEstimatedPrice = Me.txtEstimateQuote.Text.Trim
                        If strEstimatedPrice.Trim.Length = 0 Then
                            MessageBox.Show("Estimate price can't be blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        Else
                            Dim i As Integer = 0
                            For i = 0 To strEstimatedPrice.Length - 1
                                If Char.IsDigit(strEstimatedPrice, i) = False AndAlso strEstimatedPrice.Substring(i).Trim.Equals(".") = False Then
                                    MessageBox.Show("Invalid format.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                    Exit Sub
                                End If
                            Next i

                            strNIStatusDesc = objTMI.GetTMIStatusDesc(iNIStatus)
                            If strNIStatusDesc.Trim.Length = 0 Then strNIStatusDesc = "Quote Submitted"
                            objTMI.UpdateTMIOrderCurrentStatus(Me.tmpWO, strNIStatusDesc, True, iNIStatus, "", 0, Convert.ToDouble(strEstimatedPrice))
                            Me.dgConsumed.DataSource = Nothing
                            Me.ButtonClear_ClickEvent() : Me.txtSerial.Focus()
                        End If
                    Else
                        MessageBox.Show("An estimate for this unit has already submitted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                objTMI = Nothing
            End Try
        End Sub
        Private Sub tpInfo_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tpPartHistory.VisibleChanged
            Try
                If Me.tpPartHistory.Visible = True Then LoadConsumeTransaction()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "tbDevInfo_VisibleChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub
        Private Sub cboDefectClass1_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDefectClass1.SelectedValueChanged
            Dim strDefectDesc As String = ""
            Dim dt As DataTable
            Dim row As DataRow
            Dim rowNew As DataRow
            Dim i As Integer = 0
            Dim iDeviceID As Integer = 0

            Try

                If Me._device Is Nothing OrElse Me.txtSerial.Text.Trim.Length = 0 Then
                    Exit Sub
                End If

                loadDefectClassesSelected()
                iDeviceID = Me._device.ID

                If Me.cboDefectClass1.SelectedValue > 0 Then
                    If Me.tdgData1.RowCount < Me._iMaxSelectedReasons Then
                        strDefectDesc = Me.cboDefectClass1.DataSource.Table.select("DefectClass_ID = " & Me.cboDefectClass1.SelectedValue)(0)("DefectClass_Desc")
                        i = Me._objNI.SaveSelectedDefectClassReasonData(iDeviceID, CInt(Me.cboDefectClass1.SelectedValue))
                        If Not i > 0 Then MessageBox.Show("Failed to save.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        loadDefectClassesSelected()
                        'Else
                        '    Me.cboDefectClass1.SelectedValue = 0
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, " LoadDefectReasons", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub
        Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
            Dim iRow As Integer
            Dim iDevice_DC_ID As Integer = 0
            Dim i As Integer = 0

            Try
                If Me.tdgData1.SelectedRows.Count > 0 Then
                    For Each iRow In Me.tdgData1.SelectedRows

                        iDevice_DC_ID = Me.tdgData1.Columns("Device_DC_ID").CellText(iRow)
                        i = Me._objNI.DeleteSelectedDefectClassReason(iDevice_DC_ID)
                    Next iRow
                    loadDefectClassesSelected()
                Else
                    MessageBox.Show("Please select row(s) to remove.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, " btnRemove_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub
        Private Sub dgPreRepDev_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles dgPreRepDev.RowColChange
            Dim dteLastDateInPSSWrty As DateTime

            Try
                If Me.dgPreRepDev.RowCount > 0 AndAlso Me.dgPreRepDev.Columns.Count > 0 Then
                    If Convert.ToInt32(Me.dgPreRepDev.Columns("Device_ID").CellValue(Me.dgPreRepDev.Row)) > 0 Then
                        LoadPrevRepPartsServiceData(Me.dgPreRepDev.Columns("Device_ID").CellValue(Me.dgPreRepDev.Row))
                        Me.lblPrevRepTechNote.Text = Me.dgPreRepDev.Columns("Tech Notes").CellValue(Me.dgPreRepDev.Row)
                    Else
                        Me.lblDefectTypes.Text = ""
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dgPreRepDev_RowColChange", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
        Private Sub ScrapClick(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim i As Integer = 0
            Dim objScrap As New PSS.Data.Buisness.ScrapParts()
            Dim iEmpNo As Integer = PSS.Core.Global.ApplicationUser.NumberEmp
            Dim strWorkDate As String = PSS.Core.Global.ApplicationUser.Workdate
            Dim iBillcode_ID As Integer = 0
            Dim DlgRslt As DialogResult
            Dim iCount As Integer = 0
            Dim stroldText As String = Trim(sender.text.ToString)
            Dim strnewText As String = ""

            If Trim(sender.tag.ToString) <> "" Then
                iBillcode_ID = CInt(Trim(sender.tag.ToString))
            Else
                Throw New Exception("BillcodeID could not be determined.")
            End If

            Try
                DlgRslt = MessageBox.Show("To Scrap: Click 'YES'." & Environment.NewLine & "To Unscrap: Click 'NO'." & Environment.NewLine & "To Cancel without changing anything: Click 'CANCEL'.", "Add to Scrap or Remove from Scrap", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)

                Select Case DlgRslt
                    Case DialogResult.Yes
                        iCount = 1
                    Case DialogResult.No
                        iCount = -1
                    Case DialogResult.Cancel
                        iCount = 0
                        Exit Sub
                    Case Else
                        Throw New Exception("Unable to determine if the part is being scrapped or removed from the scrap.")
                End Select
                '*********************
                i = objScrap.ScrapParts(tmpDeviceID, tmpModelID, iBillcode_ID, tmpProdID, iEmpNo, strWorkDate, iCount, PSS.Core.ApplicationUser.IDuser)
                '*********************
                If i > 0 Then
                    iCount = objScrap.GetScrapCount(tmpDeviceID, tmpModelID, iBillcode_ID)
                    strnewText = Mid(stroldText, 1, InStr(stroldText, "(") - 1) & "(" & iCount & ")"
                    sender.text = strnewText
                    If iCount > 0 Then
                        sender.backcolor = Color.LightGreen
                        sender.forecolor = Color.Black
                    Else
                        sender.backcolor = Color.LightCoral
                        sender.forecolor = Color.Black
                    End If
                End If
                '*********************
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Scrap Part Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                objScrap = Nothing
            End Try
        End Sub
        Private Sub txtTechNotes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTechNotes.KeyPress
            Try
                If e.KeyChar = Chr(Keys.Enter) Then
                    e.Handled = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtTechNotes_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
        Private Sub btnTechNotesSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTechNotesSave.Click
            Dim i As Integer = 0

            Try
                If Me.txtSerial.Text.Trim.Length = 0 OrElse Me.tmpDeviceID = 0 Then
                    MessageBox.Show("Please enter serial number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.txtSerial.SelectAll() : Me.txtSerial.Focus()
                ElseIf Me.txtTechNotes.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter tech notes.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.txtTechNotes.SelectAll() : Me.txtTechNotes.Focus()
                Else
                    i = Me._objNewTech.SaveTechNotes(Me.tmpDeviceID, Me.txtTechNotes.Text.Trim, ApplicationUser.IDuser)
                    If i > 0 Then
                        MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Note did not save.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnSaveTechNotes_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

#End Region
#Region "METHODS"

#Region "Generate Dynamic Buttons"

        Private Sub createBillingButtons(ByVal dt As DataTable)
            Dim r As DataRow
            Dim colLength As Integer = 6
            Dim cBill() As Button
            Dim x As Integer = 0

            Try
                ' CREATE CONSUMPTION BUTTONS
                colCount = 0
                pnlLeft = pnlBill.Left
                pnlWidth = tabMain.Width - 48

                ReDim cBill(dt.Rows.Count)

                btnLeft = hBuffer
                btnTop = vBuffer

                For x = 0 To dt.Rows.Count - 1
                    r = dt.Rows(x)
                    cBill(x) = New System.Windows.Forms.Button()
                    With cBill(x)
                        .Text = r("BillCode_DESC")
                        .Size = New Size(btnWidth, btnHeight)
                        colCount += 1
                        .Location = New Point(btnLeft, btnTop)
                        .Visible = True

                        .BackColor = Color.LightGray
                        .Tag = r("BillCode_ID")
                        .Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                        AddHandler .Click, AddressOf Me.billingClick
                    End With

                    If colCount > colLength Then
                        btnLeft = btnLeft + btnWidth + 5
                        btnTop = vBuffer
                        colCount = 0
                    Else
                        btnTop = btnTop + btnHeight + 5
                    End If
                Next

                Me.pnlBill.Controls.AddRange(cBill)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CreateBillingButtons", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                r = Nothing
                cBill = Nothing
            End Try
        End Sub

        'Private Sub createServiceButtons(ByVal dt As DataTable)
        '    'Dim cService() As Button
        '    'Dim heightPanelSERVICE As Integer
        '    'Dim widthPanelSERVICE As Integer
        '    'Dim x As Integer = 0
        '    'Dim r As DataRow

        '    'Try
        '    '    colCount = 0
        '    '    pnlLeft = pnlService.Left
        '    '    pnlWidth = tabMain.Width - 48
        '    '    pnlService.Width = pnlService.Width
        '    '    ReDim cService(dt.Rows.Count)
        '    '    heightPanelSERVICE = pnlService.Height
        '    '    widthPanelSERVICE = pnlService.Width
        '    '    btnLeft = hBuffer
        '    '    btnTop = vBuffer
        '    '    For x = 0 To dt.Rows.Count - 1
        '    '        r = dt.Rows(x)
        '    '        cService(x) = New System.Windows.Forms.Button()
        '    '        With cService(x)
        '    '            Dim i As Integer = 0 : Dim booMainService As Boolean = False
        '    '            For i = 0 To Buisness.NI._strRequiredBillcodes.Length - 1
        '    '                If r("BillCode_DESC") = Buisness.NI._strRequiredBillcodes(i) Then
        '    '                    booMainService = True : Exit For
        '    '                End If
        '    '            Next i
        '    '            If booMainService = True Then .BackColor = Color.LightBlue Else .BackColor = Color.LightGray
        '    '            .Text = r("BillCode_DESC")
        '    '            .Size = New Size(btnWidth, btnHeight)
        '    '            .Location = New Point(btnLeft, btnTop)
        '    '            .Visible = True
        '    '            .Tag = r("BillCode_ID")
        '    '            .Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '    '            AddHandler .Click, AddressOf Me.billingClick
        '    '        End With
        '    '        colCount += 1
        '    '        If colCount > 6 Then
        '    '            btnLeft = btnLeft + btnWidth + 5
        '    '            btnTop = vBuffer
        '    '            colCount = 0
        '    '        Else
        '    '            btnTop = btnTop + btnHeight + 5
        '    '        End If
        '    '    Next
        '    '    Me.pnlService.Controls.AddRange(cService)
        '    'Catch ex As Exception
        '    '    Throw ex
        '    'Finally
        '    '    cService = Nothing
        '    '    r = Nothing
        '    'End Try
        'End Sub

        Private Function CreateRVBillCodesButtons() As Boolean
            Dim booResult As Boolean = True
            Dim r, drNewRow As DataRow
            Dim colLength As Integer = 6
            Dim cBill() As Button
            Dim x As Integer = 0
            Dim myBillColumn As DataColumn
            Dim dt, dtReflow As DataTable
            Dim objBD As New Buisness.DeviceBilling()

            Try
                ' RV PARTS
                dt = objBD.GetPartBillcodes(Me.tmpCustID, Me.tmpModelID, , , 1)
                colCount = 0
                pnlLeft = Me.pnlRVParts.Left
                pnlWidth = tabMain.Width - 48

                ReDim cBill(dt.Rows.Count)

                btnLeft = hBuffer
                btnTop = vBuffer

                For x = 0 To dt.Rows.Count - 1
                    r = dt.Rows(x)
                    If r("ReflowTypeID") <> 4 Then
                        cBill(x) = New System.Windows.Forms.Button()
                        With cBill(x)
                            .Text = r("BillCode_DESC")
                            .Size = New Size(btnWidth, btnHeight)

                            colCount += 1
                            .Location = New Point(btnLeft, btnTop)
                            .Visible = True

                            .BackColor = Color.LightGray
                            .Tag = r("BillCode_ID")
                            .Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                            AddHandler .Click, AddressOf Me.billingClick
                        End With

                        If colCount > colLength Then
                            btnLeft = btnLeft + btnWidth + 5
                            btnTop = vBuffer
                            colCount = 0
                        Else
                            btnTop = btnTop + btnHeight + 5
                        End If
                    End If
                Next x

                Me.pnlRVParts.Controls.AddRange(cBill)

                Return booResult
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CreateRVBillingButtons", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                If Not IsNothing(objBD) Then objBD = Nothing
                r = Nothing : drNewRow = Nothing
                cBill = Nothing
                If Not IsNothing(myBillColumn) Then
                    myBillColumn.Dispose() : myBillColumn = Nothing
                End If
                PSS.Data.Buisness.Generic.DisposeDT(dt)
                PSS.Data.Buisness.Generic.DisposeDT(dtReflow)
            End Try
        End Function

#End Region

        Private Sub UpdateLabels()
            Dim _600cnt = PartsCount()
            Dim _720cnt = _objNewTech.GetReclaimParts(_device.ID).Rows.Count
            lbl600Parts.Text = IIf(_600cnt = 0, "", _600cnt.ToString() & " Part(s) Selected")
            lbl720Parts.Text = IIf(_720cnt = 0, "", _720cnt.ToString() & " Part(s) Selected")
        End Sub
        Private Function ValidateSelectionOfServiceBillcode(ByVal iBillcodeID As Integer, ByVal strBillCodeDesc As String) As Boolean
            ValidateSelectionOfServiceBillcode = False
            Try
                If Me._device.BillableBillcodes.Select("Billcode_ID = " & iBillcodeID.ToString)(0)("BillType_ID") = 2 AndAlso Me._device.NTF Then
                    'Can't add part to NTF
                    MessageBox.Show("Not allow to add part to NTF device.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                ElseIf Me._device.BillableBillcodes.Select("Billcode_ID = " & iBillcodeID.ToString)(0)("BillCode_Rule") = 6 AndAlso _
                            Me._device.Parts.Select("BillType_ID = 2").Length > 0 Then
                    'Can't add part to NTF
                    MessageBox.Show("Please remove all part before select NTF.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                ElseIf Me._device.BillableBillcodes.Select("Billcode_ID = " & iBillcodeID.ToString)(0)("Billcode_Desc").ToString.Trim.ToLower = "Exception Repairs Quote Rejected" AndAlso _
                        (Me._device.Parts.Select("BillType_ID = 2").Length > 0) Then
                    'Exception Repairs Quote Rejected
                    MessageBox.Show("Please remove all part(s) before select ""Exception Repairs Quote Rejected"".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                ElseIf Me._device.BillableBillcodes.Select("Billcode_ID = " & iBillcodeID.ToString)(0)("BillType_ID") = 2 AndAlso _
                        Me._device.Parts.Select("Billcode_Desc = 'Exception Repairs Quote Rejected'").Length > 0 Then
                    MessageBox.Show("Can't add part to ""Exception Repairs Quote Rejected"" .", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                ElseIf Me._device.BillableBillcodes.Select("Billcode_ID = " & iBillcodeID.ToString)(0)("BillType_ID") = 2 AndAlso _
                        Me._device.Parts.Select("Billcode_Desc = 'PSS Warranty NFF'").Length > 0 Then
                    MessageBox.Show("Can't add part to ""PSS Warranty NFF"" .", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                ElseIf Me._device.BillableBillcodes.Select("Billcode_ID = " & iBillcodeID.ToString)(0)("Billcode_Desc") = "PSS Warranty NFF" AndAlso _
                        (Me._device.Parts.Select("BillType_ID = 2").Length > 0) Then
                    MessageBox.Show("Please remove part before select ""PSS Warranty NFF"".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                Else
                    Return True
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Private Sub ProcessSN()
            Dim ProdGrpCheck As New PSS.Data.Buisness.ProdGrpCheck()
            Dim val As Long = 0
            Dim bIsGSdevice, booCorrectStation As Boolean
            Dim strGSLotNum As String
            Dim strOriginalDeviceSN As String
            Dim dtPretestData As DataTable
            Dim strDevCurrWrkStation As String = ""
            Dim iDeviceCCID, iMachineCCID As Integer
            Try
                If PSS.Data.Buisness.Generic.GetMachineCostCenterID() = 0 Then
                    MessageBox.Show("This computer does not map to any cost center. Please contact your supervisor for advises.", "Computer Mapping", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                booCorrectStation = False
                'Clear controls and variables
                strOriginalDeviceSN = Me.txtSerial.Text.Trim.ToUpper
                ButtonClear_ClickEvent()
                Me.txtSerial.Text = strOriginalDeviceSN.TrimEnd()
                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor
                txtSerial.Text = txtSerial.Text.Trim.ToUpper  '//Format serial as all uppercase
                val = Me.verifySerialNumber(txtSerial.Text)
                If val = 0 Then
                    MessageBox.Show("SN/IMEI does not exist in the system or already has a pallet assigned to it.", "information", MessageBoxButtons.OK)
                    Me.btnClear_Click(Nothing, Nothing)
                    Me.txtSerial.Focus()
                    Exit Sub
                ElseIf val = 2 Then
                    MessageBox.Show("SN/IMEI existed more than one in the system. Please contact your lead or supervisor.", "information", MessageBoxButtons.OK)
                    Me.btnClear_Click(Nothing, Nothing)
                    Me.txtSerial.Text = ""
                    Me.txtSerial.Focus()
                Else
                    Me.tmpDeviceID = val
                    ' Added by Yuri on 21-Jun-2007.
                    ' Check ProdGrp_ID for NULL value.
                    If Not ProdGrpCheck.CheckProdGrpID(strOriginalDeviceSN) Then Exit Sub
                    If retreiveData() = False Then Exit Sub
                    'Added by Lan on 11/14/2007
                    'Device must be pretest before refurbish. 
                    If Me.tmpDeviceID > 0 Then
                        'Validate cost center
                        iDeviceCCID = PSS.Data.Buisness.Generic.GetCostCenterIDOfDevice(Me.tmpDeviceID)
                        iMachineCCID = PSS.Data.Buisness.Generic.GetMachineCostCenterID()
                        Me.txtSerial.Enabled = False
                        loadTestResults()
                        loadDefectClassesSelected()
                        Me.pnlDefectClass.Enabled = True
                        CheckForAbuse()
                        UpdateLabels()
                    End If 'Device ID > 0
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "SN KeyDownEvent", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.ButtonClear_ClickEvent()
            Finally
                Cursor.Current = Cursors.Default : Me.Enabled = True
                ProdGrpCheck = Nothing
                PSS.Data.Buisness.Generic.DisposeDT(dtPretestData)
            End Try
        End Sub
        Private Function verifySerialNumber(ByVal mDeviceSN As String) As Long
            Dim dt As DataTable
            Try
                dt = Me._objNewTech.GetDeviceInWip(mDeviceSN, Me._iSCustID)
                If dt.Rows.Count < 1 Then     'If records returned = 0 then 
                    Return 0                    'send trigger to display error message
                ElseIf dt.Rows.Count > 1 Then 'If more than 1 record is returned then 
                    Return 2                    'send trigger to display tray textbox
                Else
                    Return dt.Rows(0)("Device_ID")       'Send back device ID
                End If
            Catch ex As Exception
                Return 0
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function
        Private Function retreiveData() As Boolean
            Dim xr As DataRow
            Dim blnNER As Boolean = False
            Dim iWC_ActiveConsume As Integer = 0
            Dim booReturnVal As Boolean = False

            Try
                If Not IsNothing(Me._device) Then Me._device = Nothing

                If getData() = False Then Return False

                'get machine group
                Me._iMachineGrpID = Me._objNewTech.GetGroupID(System.Net.Dns.GetHostName)

                If Me.tmpDeviceID > 0 Then
                    _drCelloptData = Me._objNewTech.GetCellOptAndTechData(Me.tmpDeviceID)
                    '//Identify status of device
                    If Not IsNothing(_drCelloptData) Then
                        If _drCelloptData("Workstation").ToString.Trim.ToUpper = "WAREHOUSE" Then Throw New Exception("Can't process unit at Warehouse station.")
                        Me._iDeviceWipOwner = _drCelloptData("cellopt_WipOwner")
                        If Not IsDBNull(_drCelloptData("Workstation")) Then Me.lblWipLoc.Text = _drCelloptData("Workstation") Else Me.lblWipLoc.Text = ""
                        If _drCelloptData("WIL_SDESC").ToString.Trim.Length > 0 Then Me.lblWipLoc.Text &= " - " & _drCelloptData("WIL_SDESC").ToString.Trim
                        Me.cboOBCosmGrade.SelectedValue = Convert.ToInt32(_drCelloptData("OutBoundCosmGradeID"))
                        ' VALIDATE CURRENT LOCATION
                        If Misc.ValidateFrStationOfScreenInWorkFlow(Me._strScreenName, _drCelloptData("Workstation").ToString.Trim, Me.tmpCustID, 0, True) = False Then
                            Me.btnClear_Click(Nothing, Nothing)
                        End If
                    Else
                        Throw New Exception("Cellopt data is missing.")
                    End If
                End If

                Me.LoadDevice()
                loadBillCodes()
                loadServiceCodes()
                CreateRVBillCodesButtons()
                populateParts()
                Return True
            Catch ex As Exception
                Throw ex
            Finally
                xr = Nothing
            End Try
        End Function
        Private Function getData() As Boolean
            Dim booResult As Boolean = True
            Dim xCount As Integer
            Dim r As DataRow
            Dim dt As DataTable

            Try
                tmpModelID = 0 : tmpManufID = 0 : tmpProdID = 0 : tmpWO = 0 : tmpCustID = 0

                tmpCustCRbill = 0 : tmpDeviceType = 0 : vManufWrty = 0 : _iPSSWrty = 0
                tmpConsignedParts = 0

                If Me.tmpDeviceID = 0 Then Throw New Exception("Device ID is missing.")

                dt = Me._objNewTech.GetDeviceInfo(Me.tmpDeviceID)
                If dt.Rows.Count = 0 Then
                    Throw New Exception("Can't define device's model.")
                ElseIf dt.Rows.Count > 1 Then
                    Throw New Exception("Device ID existed more than one in the system.")
                Else
                    tmpModelID = dt.Rows(0)("Model_ID")
                    tmpManufID = dt.Rows(0)("Manuf_ID")
                    tmpProdID = dt.Rows(0)("Prod_ID")
                    tmpWO = dt.Rows(0)("WO_ID")
                    tmpLoc = dt.Rows(0)("Loc_ID")
                    tmpCustID = dt.Rows(0)("Cust_ID")
                    tmpCustCRbill = dt.Rows(0)("Cust_CRBilling")
                    vManufWrty = dt.Rows(0)("Device_ManufWrty")
                    tmpConsignedParts = dt.Rows(0)("cust_consignedparts")
                    _iPSSWrty = dt.Rows(0)("Device_PSSWrty")
                    Me.lblModel.Text = dt.Rows(0)("Model_Desc")
                    Me._strReceiptDate = dt.Rows(0)("Device_DateRec")

                    If tmpDeviceID = 0 Or tmpModelID = 0 Or tmpManufID = 0 Then
                        Throw New Exception("Can not define Device ID/ Model ID/ Manufacturer ID of this device.")
                    ElseIf PSS.Data.Buisness.Generic.HasPrestestRecord(Me.tmpDeviceID) = False Then
                        Throw New Exception("Device has not been to triage.")
                    End If

                    If Me._iPSSWrty = 1 Then Me.lblPSSWrtyStatus.Text = "IW" Else Me.lblPSSWrtyStatus.Text = "OW"

                    Me.LoadConsumeTransaction()

                    Me.LoadPreviousRepairData()

                    Dim dtExtWrtyData As DataTable
                    dtExtWrtyData = Me._objNewTech.GetExtenedWarrantyData(tmpWO)
                    If dtExtWrtyData.Rows.Count > 0 Then
                        If Not IsDBNull(dtExtWrtyData.Rows(0)("QuoteSubmittedDate")) AndAlso dtExtWrtyData.Rows(0)("QuoteSubmittedDate").ToString.Trim.Length > 0 Then
                            Me.txtEstimateQuote.Text = dtExtWrtyData.Rows(0)("EstimatedPrice") : Me.txtEstimateQuote.Enabled = False
                        Else
                            Me.txtEstimateQuote.Text = "" : Me.txtEstimateQuote.Enabled = True
                        End If
                        If Not IsDBNull(dtExtWrtyData.Rows(0)("DefectType1")) Then Me.lblDefectTypes.Text = dtExtWrtyData.Rows(0)("DefectType1").ToString
                        If Me.lblDefectTypes.Text.Trim.Length > 0 Then Me.lblDefectTypes.Text &= "; "
                        If Not IsDBNull(dtExtWrtyData.Rows(0)("DefectType2")) Then Me.lblDefectTypes.Text &= dtExtWrtyData.Rows(0)("DefectType2").ToString
                        If Not IsDBNull(dtExtWrtyData.Rows(0)("ErrDesc_ItemSKU")) Then Me.lblCustErrDesc.Text = dtExtWrtyData.Rows(0)("ErrDesc_ItemSKU").ToString
                    End If

                    'Get EDI Repair Type
                    Dim strRepairType() As String
                    strRepairType = PSS.Data.Buisness.NI.GetRepairType(Me.tmpWO)
                    Me.lblEDIRepType.Text = strRepairType(1)
                End If

                Return booResult
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function
        Private Sub LoadDevice()
            Try
                _device = Nothing
                _device = New Device(Me.tmpDeviceID)
                _device.ScreenID = Me._iScreenID
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Private Sub loadBillCodes()
            Dim mthd As New PSS.Data.Production.Joins()
            Dim mthdGrp As DataTable
            Dim mthdScrap As DataTable
            Dim objBD As Buisness.DeviceBilling
            Dim dtFuncParts As DataTable

            Try
                If tmpConsignedParts = 1 Then
                    mthdGrp = mthd.GenericSelect("SELECT lbillcodes.*, lpsprice.psprice_number, lpsprice.PSPrice_ConsignedPart FROM ((lbillcodes INNER JOIN tpsmap ON lbillcodes.billcode_id = tpsmap.billcode_id)INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id) WHERE tpsmap.model_id = " & tmpModelID & " AND billtype_id = 2 AND lpsprice.psprice_consignedpart=1 AND tpsmap.Inactive = 0 ORDER BY BillCode_Desc")
                Else
                    objBD = New Buisness.DeviceBilling()
                    mthdGrp = objBD.GetPartBillcodes(tmpCustID, tmpModelID, 5, , 0)
                End If

                '//New code to get scrap button datatable
                mthdScrap = mthd.OrderEntrySelect("SELECT lbillcodes.*, lpsprice.psprice_number, lpsprice.PSPrice_ConsignedPart FROM ((lbillcodes INNER JOIN tpsmap ON lbillcodes.billcode_id = tpsmap.billcode_id)INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id) WHERE tpsmap.model_id = " & tmpModelID & " AND billtype_id = 2 AND lpsprice.psprice_flgCountScrap = 1 AND tpsmap.Inactive = 0 ORDER BY lpsprice.psprice_ordergroup desc, BillCode_Desc asc")
                '//New code to get scrap button datatable

                createBillingButtons(mthdGrp)
                System.Windows.Forms.Application.DoEvents()
                System.Windows.Forms.Application.DoEvents()

            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(objBD) Then objBD = Nothing
                Buisness.Generic.DisposeDT(mthdGrp)
                Buisness.Generic.DisposeDT(mthdScrap)
            End Try
        End Sub
        Private Sub loadServiceCodes()
            Dim mthd As New PSS.Data.Production.Joins()
            Dim mthdGrp As DataTable

            Try
                'February 26, 2007
                '//This new code allows for the inclusion of a table which will allow for the 
                '//hiding of specific billcodes on models for specific customers.
                mthdGrp = mthd.GenericSelect("SELECT lbillcodes.*, lpsprice.psprice_number FROM " & _
                "lbillcodes INNER JOIN tpsmap ON lbillcodes.billcode_id = tpsmap.billcode_id " & _
                "INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id " & _
                "LEFT OUTER JOIN tbilldisplayexceptions ON tpsmap.model_id = tbilldisplayexceptions.model_id AND tpsmap.billcode_id = tbilldisplayexceptions.billcode_id " & _
                "AND tbilldisplayexceptions.cust_id = " & tmpCustID & " " & _
                "WHERE tpsmap.model_id = " & tmpModelID & " " & _
                " AND billtype_id = 1 " & _
                "AND lpsprice.psprice_consignedpart = 0 " & _
                "AND tpsmap.Inactive = 0 " & _
                "AND (tbilldisplayexceptions.cust_id is null or tbilldisplayexceptions.cust_id = " & tmpCustID & ") " & _
                "AND (tbilldisplayexceptions.display_type is null or tbilldisplayexceptions.tech = 0) " & _
                "ORDER BY BillCode_Desc")
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "loadServiceCodes", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Finally
                mthd = Nothing
                If Not IsNothing(mthdGrp) Then
                    mthdGrp.Dispose()
                    mthdGrp = Nothing
                End If
            End Try
        End Sub
        Private Sub populateParts()
            Dim x As Integer = 0
            Dim R1 As DataRow
            Dim tmpBtn As Button
            Dim tmpCb As CheckBox
            Try
                'Highlight button that are selected
                For Each R1 In Me._device.Parts.Rows
                    'Bill panel
                    For x = 0 To pnlBill.Controls.Count - 1
                        tmpBtn = CType(pnlBill.Controls(x), System.Windows.Forms.Button)
                        If R1("BillCode_ID") = tmpBtn.Tag Then
                            tmpBtn.ForeColor = Color.Blue : Exit For
                        End If
                    Next x

                    'Service panel
                    For x = 0 To pnlService.Controls.Count - 1
                        If pnlService.Controls(x).GetType.ToString = "System.Windows.Forms.CheckBox" Then
                            tmpCb = CType(pnlService.Controls(x), System.Windows.Forms.CheckBox)
                            If R1("BillCode_ID") = tmpCb.Tag Then
                                tmpCb.Checked = True
                                Exit For
                            End If
                        End If
                    Next x

                    'RV part panel
                    For x = 0 To Me.pnlRVParts.Controls.Count - 1
                        tmpBtn = CType(pnlRVParts.Controls(x), System.Windows.Forms.Button)
                        If R1("BillCode_ID") = tmpBtn.Tag Then
                            tmpBtn.ForeColor = Color.Blue : Exit For
                        End If
                    Next x
                Next R1
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
            End Try
        End Sub
        Private Function ValidateRVOEMAndConsighnedPartSelection(ByVal strAddingPartNo As String, _
                                                                 ByVal iBillcodeID As Integer, _
                                                                 ByVal iRVPart As Integer, _
                                                                 ByVal iConsignedPart As Integer) As Boolean
            Dim booReturnVal As Boolean = True
            Dim R1 As DataRow

            Try
                'No need to check if part list is empty or adding part is a services
                If Me._device.Parts.Rows.Count = 0 OrElse Me._device.GetPartTypeID(iBillcodeID) = 1 Then Return True

                ValidateRVOEMAndConsighnedPartSelection = True

                For Each R1 In Me._device.Parts.Rows
                    If iRVPart = 1 AndAlso (R1("Part_Number").ToString.Trim & "_RV").ToUpper.Equals(strAddingPartNo.Trim.ToUpper) Then
                        MessageBox.Show("An OEM part is already selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        booReturnVal = False : Exit For
                    ElseIf iConsignedPart = 1 AndAlso (R1("Part_Number").ToString.Trim & "_TT").ToUpper.Equals(strAddingPartNo.Trim.ToUpper) Then
                        MessageBox.Show("An OEM part is already selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        booReturnVal = False : Exit For
                    ElseIf (strAddingPartNo.Trim & "_RV").ToUpper.Equals(R1("Part_Number").ToString.Trim.ToUpper) Then
                        MessageBox.Show("RV part is already selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        booReturnVal = False : Exit For
                    ElseIf (strAddingPartNo.Trim & "_TT").ToUpper.Equals(R1("Part_Number").ToString.Trim.ToUpper) Then
                        MessageBox.Show("Consigned part is already selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        booReturnVal = False : Exit For
                    End If
                Next R1
                Return booReturnVal
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Private Sub HighLightSelectedButtons()
            Dim i As Integer = 0
            Try
                'Panel Bill
                For i = 0 To Me.pnlBill.Controls.Count - 1
                    If Me._device.Parts.Select("Billcode_ID = " & Me.pnlBill.Controls(i).Tag).Length > 0 Then
                        Me.pnlBill.Controls(i).ForeColor = Color.Blue
                    Else
                        Me.pnlBill.Controls(i).ForeColor = Color.Black
                    End If
                Next i
                ' PARTS.
                For i = 0 To Me.pnlRVParts.Controls.Count - 1
                    If Me._device.Parts.Select("Billcode_ID = " & Me.pnlRVParts.Controls(i).Tag).Length > 0 Then
                        Me.pnlRVParts.Controls(i).ForeColor = Color.Blue
                    Else
                        Me.pnlRVParts.Controls(i).ForeColor = Color.Black
                    End If
                Next i
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Private Sub addComponent(ByVal valBillCode As Integer)
            Dim iUpdateDBRCode As Integer = 0

            Try
                ' GET PART DATA INFORMATION
                If valBillCode > 0 Then
                    _device.AddPart(valBillCode)
                    _device.Update()
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Private Sub deleteComponent(ByVal valBillCode As Integer)
            Try
                If (tmpCustID = 1 Or tmpCustID = 14) And CInt(Trim(valBillCode)) = 25 Then  'Metrocall DBR devices
                    Dim objDeviceBilling As New PSS.Data.Buisness.DeviceBilling()
                    objDeviceBilling.UnShipMessDBR(tmpDeviceID)
                    objDeviceBilling.DeleteDBRCode(tmpDeviceID)
                    objDeviceBilling = Nothing
                End If

                If valBillCode > 0 Then
                    _device.DeletePart(valBillCode)
                    _device.Update()
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Private Sub ButtonClear_ClickEvent()
            Me.txtSerial.Enabled = True
            Me.pnlBill.BackColor = Me.BackColor
            Me.pnlBill.Controls.Clear()
            Me.pnlRVParts.Controls.Clear()

            txtSerial.Text = ""

            Me.tmpDeviceID = 0 : Me.tmpModelID = 0 : Me.tmpManufID = 0 : Me.tmpProdID = 0
            Me.tmpWO = 0 : Me._iDeviceWipOwner = 0

            '//reset the bill tray feature
            tabMain.Visible = True
            Me.lblWipLoc.Text = "" : Me.lblModel.Text = ""

            Me.lblTechNotesUpdDate.Text = "" : Me.txtTechNotes.Text = ""
            Me.lblTestResult_Triage.Text = "" : Me.lblTestResult_QC.Text = ""
            Me.lblDefectTypes.Text = "" : Me.lblCustErrDesc.Text = ""

            'Clear global variable
            If Not IsNothing(Me._device) Then
                Me._device.Dispose() : Me._device = Nothing
            End If

            rPresent = Nothing
            _drPreBillData = Nothing
            _drCelloptData = Nothing

            Me.dgConsumed.DataSource = Nothing

            'Previous Repair
            Me.dgPreRepDev.DataSource = Nothing
            Me.dgPrevRepPartsServ.DataSource = Nothing
            Me.lblPrevRepTechNote.Text = ""
            Me._strReceiptDate = ""

            Me._iPSSWrty = 0

            Me.txtEstimateQuote.Text = "" : Me.lblEDIRepType.Text = "" : Me.cboOBCosmGrade.SelectedValue = 0
            Me.pnlQuote.Visible = False
            EnableControls()
            AdjustCBColor()
            txtSerial.Focus()
        End Sub
        Private Function verifySerialNumberTray(ByVal mDeviceSN As String, ByVal mTray As String) As Long
            Try
                Dim dRec As New PSS.Data.Production.tdevice()
                Dim tRec As DataTable = dRec.GetDataTableBySNTray(mDeviceSN, mTray)
                Dim r As DataRow

                If tRec.Rows.Count < 1 Then     'If records returned = 0 then 
                    Return 0                    'send trigger to display error message
                ElseIf tRec.Rows.Count > 1 Then 'If more than 1 record is returned then 
                    Return 2                    'send trigger to display tray textbox
                Else
                    r = tRec.Rows(0)
                    Return r("Device_ID")       'Send back device ID
                End If
            Catch ex As Exception
                Return 0
            End Try
        End Function
        Private Function ShowDBRReasonScreen() As Integer
            Dim objDBR As New Billing.frmDBRReason()
            Dim i As Integer = 0
            Try
                With objDBR
                    .CustID = tmpCustID
                    .DeviceID = tmpDeviceID
                    .ShowDialog()
                    'Update the DB with the selected DBR reason
                    If objDBR.DBRCode > 0 Then i = .UPD
                End With

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(objDBR) Then
                    objDBR.Dispose() : objDBR = Nothing
                End If
            End Try
        End Function
        Private Function SetDeviceWipStation(ByRef strNextWrkStation As String) As Boolean
            Dim i, iMaxBillcodeRule, iWipOwner, iNIStatus As Integer
            Dim strBillcodeIDs As String
            Dim R1 As DataRow
            Dim dt As DataTable
            Dim objTMI As New PSS.Data.Buisness.TMIRecShip()
            Dim iSetAWAPFlag As Integer = 0

            Try
                i = 0 : iMaxBillcodeRule = 0 : iWipOwner = 9 'Out-Cell
                strNextWrkStation = "" : strBillcodeIDs = ""

                ' GET AND ASSIGN UNIT TO WORKSTATION 
                iMaxBillcodeRule = PSS.Data.Buisness.Generic.GetMaxBillRule(tmpDeviceID)
                If Me._device.Parts.Rows.Count > 0 AndAlso iMaxBillcodeRule < 0 Then
                    MessageBox.Show("Bill rule is missing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtSerial.Focus()
                    Return False
                ElseIf Me._device.Parts.Rows.Count > 0 AndAlso iMaxBillcodeRule = 1 Then
                    strNextWrkStation = PSS.Data.Buisness.Generic.GetNextWorkStationInWFP(Me._strScreenName, 0, Me.tmpCustID, 1)
                    iNIStatus = 9
                ElseIf Me._device.Parts.Rows.Count > 0 AndAlso iMaxBillcodeRule = 2 Then
                    strNextWrkStation = PSS.Data.Buisness.Generic.GetNextWorkStationInWFP(Me._strScreenName, 0, Me.tmpCustID, 1)
                    iNIStatus = 10
                Else
                    strNextWrkStation = PSS.Data.Buisness.Generic.GetNextWorkStationInWFP(Me._strScreenName, 0, Me.tmpCustID, 0, )
                    iNIStatus = 5
                End If

                If strNextWrkStation.Trim.Length > 0 Then
                    PSS.Data.Buisness.Generic.SetTcelloptWorkStationForDevice(strNextWrkStation, tmpDeviceID, Core.ApplicationUser.IDuser, Me._strScreenName, Me.Name, iWipOwner, , , , , Me.cboOBCosmGrade.SelectedValue)
                    MessageBox.Show("This unit now belongs to " & strNextWrkStation & " workstation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                'NI status
                Dim strTMIStatusDesc As String = ""
                strTMIStatusDesc = objTMI.GetTMIStatusDesc(iNIStatus)
                If strTMIStatusDesc.Trim.Length = 0 Then
                    If iWipOwner = 8 Then strTMIStatusDesc = "Waiting Parts" Else strTMIStatusDesc = "Repaired"
                End If

                objTMI.UpdateTMIOrderCurrentStatus(Me.tmpWO, strTMIStatusDesc, False, iNIStatus, "", 0, 0)

                Return True
            Catch ex As Exception
                Throw ex
            Finally
                objTMI = Nothing : PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function
        Private Function CollectPartAndReplaceTempPartInBOM(ByVal iBillcodeID As Integer, ByVal booIsRVPart As Boolean) As Boolean
            Dim objColPartAndMapBOM As Gui.frmCollectPartAndRemapBOM
            Dim booResult As Boolean = False
            Dim iPspriceID As Integer = 0

            Try
                iPspriceID = Me._device.BillableBillcodes.Select("Billcode_ID = " & iBillcodeID)(0)("PSPrice_ID")
                objColPartAndMapBOM = New Gui.frmCollectPartAndRemapBOM(Me.tmpModelID, iBillcodeID, iPspriceID, booIsRVPart, Me.tmpProdID)
                objColPartAndMapBOM.ShowDialog()

                If objColPartAndMapBOM._booCancel = False Then
                    booResult = True
                    If objColPartAndMapBOM._booRefreshBOM = True Then Me._device.ReFreshPartMapBOM()
                End If
                Return booResult
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(objColPartAndMapBOM) Then
                    objColPartAndMapBOM.Dispose() : objColPartAndMapBOM = Nothing
                End If
            End Try
        End Function
        Private Sub loadTestResults()
            Dim dtTechNotes As DataTable
            Try
                Me.lblTestResult_Triage.Text = ""
                Me.lblTestResult_QC.Text = ""
                Me.lblDefectTypes.Text = ""
                Me.lblCustErrDesc.Text = ""
                Me.lblTestResult_Triage.Text = Me._objNewTech.GetTestResult_Triage(Me.tmpDeviceID)
                Me.lblTestResult_QC.Text = Me._objNewTech.GetTestResult_QC(Me.tmpDeviceID)
                dtTechNotes = Me._objNewTech.GetTechNotesInfo(Me.tmpDeviceID)
                If dtTechNotes.Rows.Count > 0 Then
                    Me.lblTechNotesUpdDate.Text = "Saved on " & dtTechNotes.Rows(0)("UpdatedDT") & " by " & dtTechNotes.Rows(0)("User_FullName")
                    Me.txtTechNotes.Text = dtTechNotes.Rows(0)("Notes").ToString
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "loadTestResults", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dtTechNotes)
            End Try
        End Sub
        Private Sub LoadConsumeTransaction()
            Dim dt As DataTable

            Try
                ' POPULATE CONSUME TRANSACTION AND NEED TRANSACTION
                dt = Me._objNewTech.GetPartConsumedTrans(Me.tmpDeviceID)
                With Me.dgConsumed
                    .DataSource = dt.DefaultView
                    .Splits(0).DisplayColumns("Seq").Width = 30
                    .Splits(0).DisplayColumns("Action").Width = 60
                End With

            Catch ex As Exception
                Throw ex
            Finally
                : Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub
        Private Sub LoadPreviousRepairData()
            Dim strPrevCustWorkOrder As String = ""
            Dim dt As DataTable
            Dim objTMI As New Buisness.TMI()

            Try
                strPrevCustWorkOrder = objTMI.GetPrevRepRMA(Me.tmpWO)
                If strPrevCustWorkOrder.Trim.Length > 0 Then
                    dt = objTMI.GetPreviousRepairData(strPrevCustWorkOrder)
                    With Me.dgPreRepDev
                        .DataSource = dt.DefaultView
                        .Splits(0).DisplayColumns("Device_ID").Visible = False
                        .Splits(0).DisplayColumns("Tech Notes").Visible = False
                    End With
                End If
            Catch ex As Exception
                Throw ex
            Finally
                objTMI = Nothing
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub
        Private Sub LoadPrevRepPartsServiceData(ByVal iDeviceID As Integer)
            Dim dt As DataTable
            Dim objTMI As New Buisness.TMI()

            Try
                dt = objTMI.GetPreviousRepairPartsService(iDeviceID)
                With Me.dgPrevRepPartsServ
                    .DataSource = dt.DefaultView
                    .Splits(0).DisplayColumns("Device_ID").Visible = False
                End With

            Catch ex As Exception
                Throw ex
            Finally
                objTMI = Nothing
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub
        Public Shared Function NIAutoShip(ByVal iDeviceID As Integer, ByVal iWOID As Integer) As Boolean
            Dim objNIShip As New Buisness.NIRecShip()
            Dim objProdShip As New Data.Production.Shipping()
            Dim i, iBoxQty As Integer
            Dim strBoxName, strNextStation, strRMA As String

            Try
                NIAutoShip = False
                strBoxName = objProdShip.GetPalletName(Buisness.NI.PalletID_Scrap)
                PSS.Data.Production.Shipping.AssignDeviceToPallet(iDeviceID, Buisness.NI.PalletID_Scrap)
                iBoxQty = PSS.Data.Buisness.Generic.GetPalletQty(Buisness.NI.PalletID_Scrap)
                strRMA = PSS.Data.Buisness.Generic.GetWONameByWOID(iWOID)
                strNextStation = "IN-TRANSIT"
                i = objNIShip.CloseAndShipBox_Refurb(Buisness.NI.PalletID_Scrap, iWOID, iDeviceID, _
                                                     ApplicationUser.IDShift, iBoxQty, strNextStation, _
                                                     objProdShip, 0, "Shipped to Warehouse", False)
                Return True
            Catch ex As Exception
                Throw ex
            Finally
                objNIShip = Nothing
            End Try
        End Function
        Private Sub loadDefectClassesSelected()
            Dim row As DataRow
            Dim dt As DataTable
            Dim rowNew As DataRow
            Dim dt2 As DataTable = Me._objNI.getDefectClassReasonSelected_TableDef.Clone
            Try
                If Me._device Is Nothing OrElse Me.txtSerial.Text.Trim.Length = 0 Then
                    Exit Sub
                End If

                dt = Me._objNI.GetSelectedDefectClassReasonData(Me._device.ID)
                For Each row In dt.Rows
                    rowNew = dt2.NewRow
                    rowNew("DefectClass_ID") = row("DefectClass_ID")
                    rowNew("DefectClass_Desc") = row("DefectClass_Desc")
                    rowNew("Device_ID") = row("Device_ID")
                    rowNew("Device_DC_ID") = row("Device_DC_ID")
                    dt2.Rows.Add(rowNew)
                Next
                Me.tdgData1.DataSource = dt2
                Me.tdgData1.Splits(0).DisplayColumns("DefectClass_ID").Width = 0
                Me.tdgData1.Splits(0).DisplayColumns("Device_ID").Width = 0
                Me.tdgData1.Splits(0).DisplayColumns("Device_DC_ID").Width = 0
                Me.tdgData1.Splits(0).DisplayColumns("DefectClass_Desc").Width = 300

                If Me.tdgData1.RowCount >= Me._iMaxSelectedReasons Then
                    Me.lblMsg.Text = "Maximum number of defect calsses allowed is " & Me._iMaxSelectedReasons.ToString & "."
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "loadDefectClassesSelected", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub
        Private Sub LoadDefectReasons()
            Dim dt1 As DataTable

            Try
                dt1 = Me._objNI.GetDefectClassReason(0, True)
                Misc.PopulateC1DropDownList(Me.cboDefectClass1, dt1, "DefectClass_Desc", "DefectClass_ID")
                Me.cboDefectClass1.SelectedValue = 0

            Catch ex As Exception
                MessageBox.Show(ex.ToString, " LoadDefectReasons", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub
        Private Sub ClearAllDefectClasses()
            Dim iDevice_ID As Integer = 0
            Dim i As Integer = 0

            Try
                iDevice_ID = Me._device.ID
                i = Me._objNI.DeleteSelectedDefectClassReasonByDeviceID(iDevice_ID)
                loadDefectClassesSelected()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, " ClearAllDefectClasses", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub
        Private Sub EnableControls()
            If txtSerial.Text.TrimEnd = "" Then
                cb400.Enabled = False
                cb500.Enabled = False
                cb600.Enabled = False
                cb700.Enabled = False
                cb720.Enabled = False
                cb001.Enabled = False
                cb400.Checked = False
                cb500.Checked = False
                cb600.Checked = False
                cb700.Checked = False
                cb720.Checked = False
                cb001.Checked = False
            Else
                cb400.Enabled = Not cb500.Checked And Not cb600.Checked And Not cb700.Checked And Not cb001.Checked And PartsCount() < 1
                cb500.Enabled = Not cb400.Checked And Not cb600.Checked And Not cb700.Checked And Not cb720.Checked And Not cb001.Checked And PartsCount() < 1
                ' CB600 STAYS DISABLED.
                cb700.Enabled = Not cb400.Checked And Not cb500.Checked And Not cb600.Checked And Not cb720.Checked And Not cb001.Checked And PartsCount() < 1
                cb720.Enabled = Not cb500.Checked And Not cb600.Checked And Not cb700.Checked And Not cb001.Checked And PartsCount() < 1
                cb001.Enabled = Not cb400.Checked And Not cb500.Checked And Not cb600.Checked And Not cb700.Checked And Not cb720.Checked And PartsCount() < 1
            End If
            AdjustCBColor()
        End Sub
        Private Sub AdjustCBColor()
            cb400.BackColor = IIf(cb400.Checked, Color.MediumAquamarine, SystemColors.Control)
            cb500.BackColor = IIf(cb500.Checked, Color.MediumAquamarine, SystemColors.Control)
            cb600.BackColor = IIf(cb600.Checked, Color.MediumAquamarine, SystemColors.Control)
            cb700.BackColor = IIf(cb700.Checked, Color.MediumAquamarine, SystemColors.Control)
            cb720.BackColor = IIf(cb720.Checked, Color.MediumAquamarine, SystemColors.Control)
            cb001.BackColor = IIf(cb001.Checked, Color.MediumAquamarine, SystemColors.Control)
        End Sub
        Private Function PartsCount() As Integer
            Dim _cnt As Integer
            _cnt = _device.Parts.Rows.Count
            Dim dr As DataRow
            For Each dr In _device.Parts.Rows
                If dr(11) = 1 Then
                    _cnt = _cnt - 1
                End If
            Next
            Return _cnt
        End Function
        Private Function ContinueWithBer() As Boolean
            ' PROMPT TO CONTINUE WITH BER.
            If MessageBox.Show("Continue to BER this Unit?", "BER Unit", _
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Return True
            Else
                Return False
            End If
        End Function
        Private Sub SetAggragateButtons()
            _device.ReFreshBilledData()
            cb600.Checked = PartsCount() > 0
            _device.ReFreshBilledData()
            cb720.Checked = _objNewTech.GetReclaimParts(_device.ID).Rows.Count > 0
        End Sub
        Private Sub CheckForAbuse()
            cbCustAbuse.Checked = _objNI.IsDeviceAbused(_device.ID)
        End Sub
        Private Sub AddSC600()
            ' THIS SUB WILL ADD THE SERVICE CODE 600 OF IT DOES NOT ALREADY EXISTS.
            If Me._device.Parts.Select("Billcode_ID = " & "2323").Length = 0 Then
                _device.AddPart(2323)
                _device.Update()
            End If
        End Sub
        Private Sub DeleteSC600()
            ' THIS SUB WILL DELETE THE SERVICE CODE 600 IF IT EXISTS.
            If Me._device.Parts.Select("Billcode_ID = " & "2323").Length > 0 Then
                _device.DeletePart(2323)
                _device.Update()
            End If
        End Sub

#End Region
    End Class
End Namespace