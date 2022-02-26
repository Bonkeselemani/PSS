Option Explicit On 

Imports PSS.Data
Imports PSS.Core
Imports PSS.Rules
Imports PSS.Core.Global
Imports System.IO

Namespace Gui
    Public Class frmAIGBilling
        Inherits System.Windows.Forms.Form

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
        Private _objAIG As PSS.Data.Buisness.AIG

        Private _device As Device = Nothing
        Private tmpDeviceID, tmpModelID, tmpManufID, tmpProdID, tmpLoc, tmpCustID, tmpWO, tmpDeviceType, tmpConsignedParts, tmpCustCRbill As Integer

        ' Private dtCustomerSet As DataTable

        Private vManufWrty As Integer = 0
        Private _iPSSWrty As Integer = 0

        Dim zCount As Integer
        Dim rPresent As DataRow

        Private _drPreBillData, _drCelloptData As DataRow
        Private _iMachineGrpID As Integer = 0
        Private _iDeviceWipOwner As Integer = 0

        'WARRANTY CLAIM
        Private _iFailID As Integer = 0
        Private _iRepairID As Integer = 0
        Private _iBillType As Integer = 0

        'This customer ID send from the menu selection
        Private _iSCustID As Integer = 0
        Private _booStationCheck As Boolean = True

        Private _strReceiptDate As String = ""
        Private Const strdelimiter As String = "~"
        Private _bLoadDataToCtrl As Boolean = False
        Private _bHasQuoteApproved As Boolean = False
        Private _bHasAccessToResetQuoteApproval As Boolean = False

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

            _objAIG = New PSS.Data.Buisness.AIG()

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
        Friend WithEvents tbScrap As System.Windows.Forms.TabPage
        Friend WithEvents pnlScrap As System.Windows.Forms.Panel
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
        Friend WithEvents dgConsumed As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents tpPartHistory As System.Windows.Forms.TabPage
        Friend WithEvents tpPrevRep As System.Windows.Forms.TabPage
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents dgPreRepDev As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents dgPrevRepPartsServ As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblPrevRepTechNote As System.Windows.Forms.Label
        Friend WithEvents lblPSSWrtyStatus As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents lblCustErrDesc As System.Windows.Forms.Label
        Friend WithEvents lblDefectTypes As System.Windows.Forms.Label
        Friend WithEvents btnTechNotesSave As System.Windows.Forms.Button
        Friend WithEvents lblTestResult_Triage As System.Windows.Forms.TextBox
        Friend WithEvents lblTechNotesUpdDate As System.Windows.Forms.Label
        Friend WithEvents txtTechNotes As System.Windows.Forms.TextBox
        Friend WithEvents lblMake As System.Windows.Forms.Label
        Friend WithEvents dgPartNeeds As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnQuoteSumitted_TechHrs As System.Windows.Forms.Button
        Friend WithEvents lblTechHrs As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents lblExpectedShipDate As System.Windows.Forms.Label
        Friend WithEvents cboCodes As C1.Win.C1List.C1Combo
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents lstFailCodes As System.Windows.Forms.ListBox
        Friend WithEvents Label7 As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAIGBilling))
            Me.txtSerial = New System.Windows.Forms.TextBox()
            Me.lblDeviceSN = New System.Windows.Forms.Label()
            Me.tabMain = New System.Windows.Forms.TabControl()
            Me.tbParts = New System.Windows.Forms.TabPage()
            Me.pnlBill = New System.Windows.Forms.Panel()
            Me.tbTestResults = New System.Windows.Forms.TabPage()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.lstFailCodes = New System.Windows.Forms.ListBox()
            Me.cboCodes = New C1.Win.C1List.C1Combo()
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
            Me.tbScrap = New System.Windows.Forms.TabPage()
            Me.pnlScrap = New System.Windows.Forms.Panel()
            Me.tbRVParts = New System.Windows.Forms.TabPage()
            Me.pnlRVParts = New System.Windows.Forms.Panel()
            Me.tpPartHistory = New System.Windows.Forms.TabPage()
            Me.dgPartNeeds = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
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
            Me.lblPSSWrtyStatus = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.lblMake = New System.Windows.Forms.Label()
            Me.btnQuoteSumitted_TechHrs = New System.Windows.Forms.Button()
            Me.lblTechHrs = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.lblExpectedShipDate = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.tabMain.SuspendLayout()
            Me.tbParts.SuspendLayout()
            Me.tbTestResults.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            CType(Me.cboCodes, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlTestResults.SuspendLayout()
            Me.tbServices.SuspendLayout()
            Me.tbScrap.SuspendLayout()
            Me.tbRVParts.SuspendLayout()
            Me.tpPartHistory.SuspendLayout()
            CType(Me.dgPartNeeds, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dgConsumed, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpPrevRep.SuspendLayout()
            CType(Me.dgPrevRepPartsServ, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dgPreRepDev, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'txtSerial
            '
            Me.txtSerial.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
            Me.txtSerial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSerial.Location = New System.Drawing.Point(48, 33)
            Me.txtSerial.Name = "txtSerial"
            Me.txtSerial.Size = New System.Drawing.Size(136, 20)
            Me.txtSerial.TabIndex = 1
            Me.txtSerial.Text = ""
            '
            'lblDeviceSN
            '
            Me.lblDeviceSN.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
            Me.lblDeviceSN.Location = New System.Drawing.Point(0, 36)
            Me.lblDeviceSN.Name = "lblDeviceSN"
            Me.lblDeviceSN.Size = New System.Drawing.Size(48, 16)
            Me.lblDeviceSN.TabIndex = 104
            Me.lblDeviceSN.Text = "Serial #:"
            Me.lblDeviceSN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'tabMain
            '
            Me.tabMain.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.tabMain.Controls.AddRange(New System.Windows.Forms.Control() {Me.tbParts, Me.tbTestResults, Me.tbServices, Me.tbScrap, Me.tbRVParts, Me.tpPartHistory, Me.tpPrevRep})
            Me.tabMain.Location = New System.Drawing.Point(8, 64)
            Me.tabMain.Name = "tabMain"
            Me.tabMain.SelectedIndex = 0
            Me.tabMain.Size = New System.Drawing.Size(976, 488)
            Me.tabMain.TabIndex = 6
            '
            'tbParts
            '
            Me.tbParts.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlBill})
            Me.tbParts.Location = New System.Drawing.Point(4, 22)
            Me.tbParts.Name = "tbParts"
            Me.tbParts.Size = New System.Drawing.Size(968, 462)
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
            Me.pnlBill.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlBill.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.pnlBill.Location = New System.Drawing.Point(8, 8)
            Me.pnlBill.Name = "pnlBill"
            Me.pnlBill.Size = New System.Drawing.Size(952, 440)
            Me.pnlBill.TabIndex = 108
            '
            'tbTestResults
            '
            Me.tbTestResults.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox1, Me.lblTechNotesUpdDate, Me.btnTechNotesSave, Me.txtTechNotes, Me.Label1, Me.pnlTestResults})
            Me.tbTestResults.Location = New System.Drawing.Point(4, 22)
            Me.tbTestResults.Name = "tbTestResults"
            Me.tbTestResults.Size = New System.Drawing.Size(968, 462)
            Me.tbTestResults.TabIndex = 8
            Me.tbTestResults.Text = "TEST RESULTS"
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label7, Me.lstFailCodes, Me.cboCodes})
            Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox1.Location = New System.Drawing.Point(120, 160)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(840, 112)
            Me.GroupBox1.TabIndex = 132
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Tech Fail Code"
            '
            'lstFailCodes
            '
            Me.lstFailCodes.ItemHeight = 16
            Me.lstFailCodes.Location = New System.Drawing.Point(392, 16)
            Me.lstFailCodes.Name = "lstFailCodes"
            Me.lstFailCodes.Size = New System.Drawing.Size(368, 84)
            Me.lstFailCodes.TabIndex = 129
            '
            'cboCodes
            '
            Me.cboCodes.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboCodes.AutoCompletion = True
            Me.cboCodes.AutoDropDown = True
            Me.cboCodes.AutoSelect = True
            Me.cboCodes.Caption = ""
            Me.cboCodes.CaptionHeight = 17
            Me.cboCodes.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboCodes.ColumnCaptionHeight = 17
            Me.cboCodes.ColumnFooterHeight = 17
            Me.cboCodes.ColumnHeaders = False
            Me.cboCodes.ContentHeight = 15
            Me.cboCodes.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboCodes.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboCodes.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCodes.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCodes.EditorHeight = 15
            Me.cboCodes.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboCodes.ItemHeight = 15
            Me.cboCodes.Location = New System.Drawing.Point(16, 24)
            Me.cboCodes.MatchEntryTimeout = CType(2000, Long)
            Me.cboCodes.MaxDropDownItems = CType(10, Short)
            Me.cboCodes.MaxLength = 32767
            Me.cboCodes.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCodes.Name = "cboCodes"
            Me.cboCodes.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCodes.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCodes.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCodes.Size = New System.Drawing.Size(368, 21)
            Me.cboCodes.TabIndex = 131
            Me.cboCodes.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'lblTechNotesUpdDate
            '
            Me.lblTechNotesUpdDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTechNotesUpdDate.ForeColor = System.Drawing.Color.Blue
            Me.lblTechNotesUpdDate.Location = New System.Drawing.Point(328, 8)
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
            Me.btnTechNotesSave.Image = CType(resources.GetObject("btnTechNotesSave.Image"), System.Drawing.Bitmap)
            Me.btnTechNotesSave.Location = New System.Drawing.Point(24, 144)
            Me.btnTechNotesSave.Name = "btnTechNotesSave"
            Me.btnTechNotesSave.Size = New System.Drawing.Size(88, 40)
            Me.btnTechNotesSave.TabIndex = 124
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
            Me.txtTechNotes.Size = New System.Drawing.Size(832, 128)
            Me.txtTechNotes.TabIndex = 1
            Me.txtTechNotes.Text = ""
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.Location = New System.Drawing.Point(120, 0)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(104, 24)
            Me.Label1.TabIndex = 10
            Me.Label1.Text = "Tech Notes:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'pnlTestResults
            '
            Me.pnlTestResults.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.pnlTestResults.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label3, Me.lblCustErrDesc, Me.Label2, Me.lblDefectTypes, Me.lblTestResult_Triage, Me._LabelTestResult_QC, Me.lblTestResult_QC, Me._LabelTestResult_Triage})
            Me.pnlTestResults.Location = New System.Drawing.Point(16, 272)
            Me.pnlTestResults.Name = "pnlTestResults"
            Me.pnlTestResults.Size = New System.Drawing.Size(944, 176)
            Me.pnlTestResults.TabIndex = 0
            '
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.Location = New System.Drawing.Point(0, 136)
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
            Me.lblCustErrDesc.Location = New System.Drawing.Point(104, 136)
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
            Me.lblDefectTypes.Location = New System.Drawing.Point(104, 96)
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
            Me.lblTestResult_Triage.Location = New System.Drawing.Point(104, 16)
            Me.lblTestResult_Triage.Multiline = True
            Me.lblTestResult_Triage.Name = "lblTestResult_Triage"
            Me.lblTestResult_Triage.Size = New System.Drawing.Size(832, 32)
            Me.lblTestResult_Triage.TabIndex = 16
            Me.lblTestResult_Triage.Text = ""
            '
            '_LabelTestResult_QC
            '
            Me._LabelTestResult_QC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me._LabelTestResult_QC.Location = New System.Drawing.Point(32, 56)
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
            Me.lblTestResult_QC.Location = New System.Drawing.Point(104, 56)
            Me.lblTestResult_QC.Name = "lblTestResult_QC"
            Me.lblTestResult_QC.Size = New System.Drawing.Size(832, 32)
            Me.lblTestResult_QC.TabIndex = 14
            '
            '_LabelTestResult_Triage
            '
            Me._LabelTestResult_Triage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me._LabelTestResult_Triage.Location = New System.Drawing.Point(24, 16)
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
            Me.tbServices.Size = New System.Drawing.Size(968, 462)
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
            Me.pnlService.Location = New System.Drawing.Point(8, 8)
            Me.pnlService.Name = "pnlService"
            Me.pnlService.Size = New System.Drawing.Size(952, 440)
            Me.pnlService.TabIndex = 109
            '
            'tbScrap
            '
            Me.tbScrap.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlScrap})
            Me.tbScrap.Location = New System.Drawing.Point(4, 22)
            Me.tbScrap.Name = "tbScrap"
            Me.tbScrap.Size = New System.Drawing.Size(968, 462)
            Me.tbScrap.TabIndex = 2
            Me.tbScrap.Text = "SCRAP"
            '
            'pnlScrap
            '
            Me.pnlScrap.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.pnlScrap.AutoScroll = True
            Me.pnlScrap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlScrap.Location = New System.Drawing.Point(8, 8)
            Me.pnlScrap.Name = "pnlScrap"
            Me.pnlScrap.Size = New System.Drawing.Size(952, 440)
            Me.pnlScrap.TabIndex = 0
            '
            'tbRVParts
            '
            Me.tbRVParts.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlRVParts})
            Me.tbRVParts.Location = New System.Drawing.Point(4, 22)
            Me.tbRVParts.Name = "tbRVParts"
            Me.tbRVParts.Size = New System.Drawing.Size(968, 462)
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
            Me.pnlRVParts.Size = New System.Drawing.Size(952, 440)
            Me.pnlRVParts.TabIndex = 109
            '
            'tpPartHistory
            '
            Me.tpPartHistory.Controls.AddRange(New System.Windows.Forms.Control() {Me.dgPartNeeds, Me.dgConsumed})
            Me.tpPartHistory.Location = New System.Drawing.Point(4, 22)
            Me.tpPartHistory.Name = "tpPartHistory"
            Me.tpPartHistory.Size = New System.Drawing.Size(968, 462)
            Me.tpPartHistory.TabIndex = 11
            Me.tpPartHistory.Text = "Trans History"
            '
            'dgPartNeeds
            '
            Me.dgPartNeeds.AllowUpdate = False
            Me.dgPartNeeds.AlternatingRows = True
            Me.dgPartNeeds.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dgPartNeeds.Caption = "Part Needs"
            Me.dgPartNeeds.FilterBar = True
            Me.dgPartNeeds.GroupByCaption = "Drag a column header here to group by that column"
            Me.dgPartNeeds.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.dgPartNeeds.Location = New System.Drawing.Point(488, 32)
            Me.dgPartNeeds.Name = "dgPartNeeds"
            Me.dgPartNeeds.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dgPartNeeds.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dgPartNeeds.PreviewInfo.ZoomFactor = 75
            Me.dgPartNeeds.Size = New System.Drawing.Size(448, 400)
            Me.dgPartNeeds.TabIndex = 148
            Me.dgPartNeeds.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 17, 444, 379" & _
            "</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win" & _
            ".C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><St" & _
            "yle parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style " & _
            "parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style p" & _
            "arent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style paren" & _
            "t=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style pare" & _
            "nt=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style p" & _
            "arent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyl" & _
            "es><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Def" & _
            "aultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 444, 396</ClientArea><P" & _
            "rintPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=" & _
            """Style21"" /></Blob>"
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
            Me.dgConsumed.Size = New System.Drawing.Size(452, 400)
            Me.dgConsumed.TabIndex = 147
            Me.dgConsumed.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            " DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>3" & _
            "79</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 17, 448, 379" & _
            "</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win" & _
            ".C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><St" & _
            "yle parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style " & _
            "parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style p" & _
            "arent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style paren" & _
            "t=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style pare" & _
            "nt=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style p" & _
            "arent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyl" & _
            "es><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Def" & _
            "aultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 448, 396</ClientArea><P" & _
            "rintPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=" & _
            """Style21"" /></Blob>"
            '
            'tpPrevRep
            '
            Me.tpPrevRep.BackColor = System.Drawing.Color.SteelBlue
            Me.tpPrevRep.Controls.AddRange(New System.Windows.Forms.Control() {Me.dgPrevRepPartsServ, Me.Label4, Me.lblPrevRepTechNote, Me.dgPreRepDev})
            Me.tpPrevRep.Location = New System.Drawing.Point(4, 22)
            Me.tpPrevRep.Name = "tpPrevRep"
            Me.tpPrevRep.Size = New System.Drawing.Size(968, 462)
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
            "ading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlTex" & _
            "t;AlignVert:Center;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, style=Bold;Fore" & _
            "Color:Red;BackColor:White;}Style4{}Style9{}Style8{}Style5{}Group{AlignVert:Cente" & _
            "r;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style7{}Style6{}Style1{}Style3{" & _
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
            "ading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText" & _
            ";BackColor:Control;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, style=Bold;Fore" & _
            "Color:Red;BackColor:White;}Style4{}Style9{}Style8{}Style5{}Group{BackColor:Contr" & _
            "olDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style7{}Style6{}Style1{}Style3{" & _
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
            Me.btnClear.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnClear.Location = New System.Drawing.Point(808, 32)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(64, 22)
            Me.btnClear.TabIndex = 2
            Me.btnClear.Text = "&Clear"
            '
            'btnComplete
            '
            Me.btnComplete.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnComplete.BackColor = System.Drawing.Color.Green
            Me.btnComplete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnComplete.ForeColor = System.Drawing.Color.White
            Me.btnComplete.Location = New System.Drawing.Point(880, 32)
            Me.btnComplete.Name = "btnComplete"
            Me.btnComplete.Size = New System.Drawing.Size(104, 22)
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
            Me.lblModel.Location = New System.Drawing.Point(520, 8)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(144, 16)
            Me.lblModel.TabIndex = 139
            Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblWipLoc
            '
            Me.lblWipLoc.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWipLoc.ForeColor = System.Drawing.Color.RoyalBlue
            Me.lblWipLoc.Location = New System.Drawing.Point(568, 32)
            Me.lblWipLoc.Name = "lblWipLoc"
            Me.lblWipLoc.Size = New System.Drawing.Size(232, 16)
            Me.lblWipLoc.TabIndex = 141
            Me.lblWipLoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblPSSWrtyStatus
            '
            Me.lblPSSWrtyStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblPSSWrtyStatus.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPSSWrtyStatus.ForeColor = System.Drawing.Color.Red
            Me.lblPSSWrtyStatus.Location = New System.Drawing.Point(296, 32)
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
            Me.Label6.Location = New System.Drawing.Point(192, 34)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(104, 16)
            Me.Label6.TabIndex = 146
            Me.Label6.Text = "PSSI WRTY:"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblMake
            '
            Me.lblMake.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMake.ForeColor = System.Drawing.Color.RoyalBlue
            Me.lblMake.Location = New System.Drawing.Point(296, 8)
            Me.lblMake.Name = "lblMake"
            Me.lblMake.Size = New System.Drawing.Size(208, 16)
            Me.lblMake.TabIndex = 151
            Me.lblMake.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnQuoteSumitted_TechHrs
            '
            Me.btnQuoteSumitted_TechHrs.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnQuoteSumitted_TechHrs.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnQuoteSumitted_TechHrs.Location = New System.Drawing.Point(808, 0)
            Me.btnQuoteSumitted_TechHrs.Name = "btnQuoteSumitted_TechHrs"
            Me.btnQuoteSumitted_TechHrs.Size = New System.Drawing.Size(176, 22)
            Me.btnQuoteSumitted_TechHrs.TabIndex = 152
            Me.btnQuoteSumitted_TechHrs.Text = "Submit Estimate Tech Hrs"
            '
            'lblTechHrs
            '
            Me.lblTechHrs.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.lblTechHrs.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTechHrs.ForeColor = System.Drawing.Color.RoyalBlue
            Me.lblTechHrs.Location = New System.Drawing.Point(672, 8)
            Me.lblTechHrs.Name = "lblTechHrs"
            Me.lblTechHrs.Size = New System.Drawing.Size(128, 16)
            Me.lblTechHrs.TabIndex = 153
            Me.lblTechHrs.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label5
            '
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.RoyalBlue
            Me.Label5.Location = New System.Drawing.Point(352, 34)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(120, 16)
            Me.Label5.TabIndex = 154
            Me.Label5.Text = "ExpectedShipDate:"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'lblExpectedShipDate
            '
            Me.lblExpectedShipDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblExpectedShipDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblExpectedShipDate.ForeColor = System.Drawing.Color.RoyalBlue
            Me.lblExpectedShipDate.Location = New System.Drawing.Point(472, 32)
            Me.lblExpectedShipDate.Name = "lblExpectedShipDate"
            Me.lblExpectedShipDate.Size = New System.Drawing.Size(80, 20)
            Me.lblExpectedShipDate.TabIndex = 155
            Me.lblExpectedShipDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label7
            '
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.LightSlateGray
            Me.Label7.Location = New System.Drawing.Point(768, 16)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(70, 58)
            Me.Label7.TabIndex = 132
            Me.Label7.Text = "To remove an item, select it and hit Enter key"
            '
            'frmAIGBilling
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(992, 558)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblExpectedShipDate, Me.Label5, Me.lblTechHrs, Me.btnQuoteSumitted_TechHrs, Me.lblMake, Me.Label6, Me.lblPSSWrtyStatus, Me.lblWipLoc, Me.lblModel, Me.lblScreenName, Me.lblCustName, Me.btnComplete, Me.btnClear, Me.tabMain, Me.txtSerial, Me.lblDeviceSN})
            Me.Name = "frmAIGBilling"
            Me.Text = "frmAIGBilling"
            Me.tabMain.ResumeLayout(False)
            Me.tbParts.ResumeLayout(False)
            Me.tbTestResults.ResumeLayout(False)
            Me.GroupBox1.ResumeLayout(False)
            CType(Me.cboCodes, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlTestResults.ResumeLayout(False)
            Me.tbServices.ResumeLayout(False)
            Me.tbScrap.ResumeLayout(False)
            Me.tbRVParts.ResumeLayout(False)
            Me.tpPartHistory.ResumeLayout(False)
            CType(Me.dgPartNeeds, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dgConsumed, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpPrevRep.ResumeLayout(False)
            CType(Me.dgPrevRepPartsServ, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dgPreRepDev, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Generate Dynamic Buttons"

        '*****************************************************************
        Private Sub createScrapButtons(ByVal dt As DataTable)
            Dim btnWidthScrap As Integer = 225
            Dim btnHeightScrap As Integer = 30
            Dim NSCbtnWidthScrap As Integer = 220
            Dim NSCbtnHeightScrap As Integer = 5

            Dim r As DataRow
            'Dim dtScrap As DataTable
            Dim cBill() As Button
            Dim heightPanelSCRAP As Integer
            Dim widthPanelSCRAP As Integer
            Dim colLengthScrap As Integer = 16
            Dim x As Integer = 0
            Dim iCount As Integer = 0
            Dim objScrap As PSS.Data.Buisness.ScrapParts

            Try
                'dtScrap = Me._objNewTech.GetScrapParts(Me.tmpDeviceID)
                objScrap = New PSS.Data.Buisness.ScrapParts()

                colCount = 0
                pnlScrap.BackColor = Color.LightYellow
                pnlLeft = pnlScrap.Left
                pnlWidth = tabMain.Width - 48
                'gridLeft = gridBilling.Left
                'gridWidth = gridBilling.Width

                ReDim cBill(dt.Rows.Count)

                heightPanelSCRAP = pnlScrap.Height - 20
                widthPanelSCRAP = pnlScrap.Width

                btnLeft = hBuffer
                btnTop = vBuffer

                For x = 0 To dt.Rows.Count - 1
                    r = dt.Rows(x)
                    cBill(x) = New System.Windows.Forms.Button()

                    With cBill(x)
                        iCount = 0
                        '********************************************
                        If Not IsDBNull(r("BillCode_ID")) Then
                            iCount = objScrap.GetScrapCount(tmpDeviceID, tmpModelID, r("BillCode_ID"))
                        End If

                        If iCount > 0 Then
                            .BackColor = Color.LightGreen
                            .ForeColor = Color.Black
                        Else
                            .BackColor = Color.LightCoral
                            .ForeColor = Color.Black
                        End If
                        '********************************************

                        .Text = r("BillCode_DESC") & " " & Trim("(" & Trim(iCount) & ")")
                        .Size = New Size(btnWidthScrap, btnHeightScrap)
                        .Location = New Point(btnLeft, btnTop)
                        .Visible = True
                        colCount += 1
                        '.BackColor = Color.LightCoral
                        .Tag = r("BillCode_ID")
                        .Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                        AddHandler .Click, AddressOf Me.ScrapClick
                    End With

                    colLengthScrap = 16

                    If colCount > colLengthScrap Then
                        If tmpCustID = 1403 Then
                            btnLeft = btnLeft + NSCbtnWidthScrap
                        Else
                            btnLeft = btnLeft + btnWidthScrap + 5
                        End If
                        btnTop = vBuffer
                        colCount = 0
                    Else
                        If tmpCustID = 1403 Then
                            btnTop = btnTop + NSCbtnHeightScrap
                        Else
                            btnTop = btnTop + btnHeightScrap + 2
                        End If
                    End If
                Next
                Me.pnlScrap.Controls.AddRange(cBill)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CreateScrapButtons", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                r = Nothing
                cBill = Nothing

            End Try
        End Sub

        '*****************************************************************
        Private Sub createBillingButtons(ByVal dt As DataTable)
            Dim r As DataRow
            Dim colLength As Integer = 6
            Dim cBill() As Button
            Dim x As Integer = 0

            Try
                '*************************************
                'Create consumption buttons
                '*************************************
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

        '*****************************************************************
        Private Sub createServiceButtons(ByVal dt As DataTable)
            Dim cService() As Button
            Dim heightPanelSERVICE As Integer
            Dim widthPanelSERVICE As Integer
            Dim x As Integer = 0
            Dim r As DataRow

            Try
                colCount = 0
                pnlLeft = pnlService.Left
                pnlWidth = tabMain.Width - 48

                pnlService.Width = pnlService.Width

                ReDim cService(dt.Rows.Count)

                heightPanelSERVICE = pnlService.Height
                widthPanelSERVICE = pnlService.Width

                btnLeft = hBuffer
                btnTop = vBuffer

                For x = 0 To dt.Rows.Count - 1
                    r = dt.Rows(x)

                    cService(x) = New System.Windows.Forms.Button()
                    With cService(x)
                        Dim i As Integer = 0 : Dim booMainService As Boolean = False
                        For i = 0 To Buisness.NI._strRequiredBillcodes.Length - 1
                            If r("BillCode_DESC") = Buisness.NI._strRequiredBillcodes(i) Then
                                booMainService = True : Exit For
                            End If
                        Next i
                        If booMainService = True Then .BackColor = Color.LightBlue Else .BackColor = Color.LightGray

                        .Text = r("BillCode_DESC")
                        .Size = New Size(btnWidth, btnHeight)
                        .Location = New Point(btnLeft, btnTop)
                        .Visible = True
                        .Tag = r("BillCode_ID")
                        .Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                        AddHandler .Click, AddressOf Me.billingClick

                        If Me._iPSSWrty = 0 AndAlso (.Text.Trim = "PSS Warranty No Fault Found" OrElse .Text.Trim = "Repaired PSS Warranty") Then .Visible = False
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
                Me.pnlService.Controls.AddRange(cService)

            Catch ex As Exception
                Throw ex
            Finally
                cService = Nothing
                r = Nothing
            End Try
        End Sub

        '*****************************************************************
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
                '***************************************
                'RV Parts
                '***************************************
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

        '*******************************************************************
        Private Sub txtSerial_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSerial.KeyDown
            If e.KeyValue = 13 AndAlso Me.txtSerial.Text.Trim.Length > 0 Then
                Me.ProcessSN()
            End If
        End Sub

        '*******************************************************************
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
                '******************************
                'Clear controls and variables
                '******************************
                strOriginalDeviceSN = Me.txtSerial.Text.Trim.ToUpper
                ButtonClear_ClickEvent()
                Me.txtSerial.Text = strOriginalDeviceSN
                '******************************

                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                txtSerial.Text = txtSerial.Text.Trim.ToUpper  '//Format serial as all uppercase
                val = Me.verifySerialNumber(txtSerial.Text)

                If val = 0 Then
                    MessageBox.Show("SN/IMEI does not exist in the system or already has a pallet assigned to it.", "information", MessageBoxButtons.OK)
                    Me.txtSerial.SelectAll() : Me.txtSerial.Focus()
                    Exit Sub
                ElseIf val = 2 Then
                    MessageBox.Show("SN/IMEI existed more than one in the system. Please contact your lead or supervisor.", "information", MessageBoxButtons.OK)
                    Me.txtSerial.Text = ""
                    Me.txtSerial.Focus()
                Else
                    Me.tmpDeviceID = val

                    '******************************************************************
                    ' Added by Yuri on 21-Jun-2007.
                    ' Check ProdGrp_ID for NULL value.
                    If Not ProdGrpCheck.CheckProdGrpID(strOriginalDeviceSN) Then Exit Sub
                    '******************************************************************

                    If retreiveData() = False Then Exit Sub

                    '*************************************
                    'Added by Lan on 11/14/2007
                    'Device must be pretest before refurbish. 
                    '*************************************
                    If Me.tmpDeviceID > 0 Then
                        ''****************************************************
                        ''Validate screen name and device workstation
                        ''****************************************************
                        'strDevCurrWrkStation = PSS.Data.Buisness.Generic.GetDeviceCurrentWorkStation(Me.tmpDeviceID).Trim.ToUpper
                        'If Misc.ValidateFrStationOfScreenInWorkFlow(Me._strScreenName, strDevCurrWrkStation, Me.tmpCustID, 0) = False Then
                        '    Me.ButtonClear_ClickEvent()
                        '    Me.txtSerial.SelectAll()
                        '    Me.txtSerial.Focus()
                        '    Exit Sub
                        'End If

                        '****************************************************
                        'Validate cost center
                        '****************************************************
                        iDeviceCCID = PSS.Data.Buisness.Generic.GetCostCenterIDOfDevice(Me.tmpDeviceID)
                        iMachineCCID = PSS.Data.Buisness.Generic.GetMachineCostCenterID()
                        'If iDeviceCCID = 0 Then
                        '    MessageBox.Show("This Device has not received into cell.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        '    Me.ButtonClear_ClickEvent()
                        '    Me.txtSerial.SelectAll()
                        '    Me.txtSerial.Focus()
                        '    Exit Sub
                        'elseIf PSS.Data.Buisness.Generic.GetNextSeqNoInTtestdata(tmpDeviceID, 7) > 1 Then
                        ''//This is rework unit. Don't validate cost center
                        'ElseIf IsNothing(Me._drCelloptData) = True AndAlso PSS.Data.Buisness.Generic.GetNextSeqNoInTtestdata(tmpDeviceID, 7) = 1 AndAlso iDeviceCCID <> iMachineCCID Then
                        '    MessageBox.Show("This Device does not belong to your cell. Please receive into your cell.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        '    Me.ButtonClear_ClickEvent()
                        '    Me.txtSerial.SelectAll()
                        '    Me.txtSerial.Focus()
                        '    Exit Sub
                        'ElseIf Not IsNothing(Me._drCelloptData) AndAlso CInt(Me._drCelloptData("CellOpt_QCReject")) = 0 AndAlso iDeviceCCID <> iMachineCCID Then
                        '    MessageBox.Show("This Device belongs to cell " & PSS.Data.Buisness.Generic.GetCostCenterDescOfDevice(Me.tmpDeviceID) & "." & Environment.NewLine & "Please send it to the right workstation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        '    Me.ButtonClear_ClickEvent()
                        '    Me.txtSerial.SelectAll()
                        '    Me.txtSerial.Focus()
                        '    Exit Sub
                        '    'ElseIf Not IsNothing(Me._drCelloptData) AndAlso CInt(Me._drCelloptData("CellOpt_QCReject")) = 0 AndAlso Not IsDBNull(Me._drCelloptData("User_Fullname")) AndAlso CInt(Me._drCelloptData("CellOpt_TechAssigned")) <> PSS.Core.ApplicationUser.IDuser Then
                        '    '    MessageBox.Show("This Device belongs to technician " & Me._drCelloptData("User_Fullname") & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        '    '    Me.ButtonClear_ClickEvent()
                        '    '    Me.txtSerial.SelectAll()
                        '    '    Me.txtSerial.Focus()
                        '    '    Exit Sub
                        'End If
                        If IsNothing(Me._drCelloptData) Then
                            MessageBox.Show("Cellopt data is missing. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.ButtonClear_ClickEvent() : Me.txtSerial.SelectAll() : Me.txtSerial.Focus() : Exit Sub
                        ElseIf Me._iDeviceWipOwner = "6" Then 'Hold
                            MessageBox.Show("Device is on hold waiting for approval.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.ButtonClear_ClickEvent() : Me.txtSerial.SelectAll() : Me.txtSerial.Focus() : Exit Sub
                        End If

                        'Validate SN Discrepancy
                        If Me._drCelloptData.Item("SN_Discp_Flag") = 1 AndAlso Me._drCelloptData.Item("SN_Discp_AV_ID") <> 1 Then
                            MessageBox.Show("Non-approved (Rejeted) SN discrepancy device.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.ButtonClear_ClickEvent() : Me.txtSerial.SelectAll() : Me.txtSerial.Focus() : Exit Sub
                        End If

                        '***********************************************
                        Me.txtSerial.Enabled = False
                        loadTestResults()
                        '***********************************************

                        'Tech Failure Codes
                        LoadFailureCodes()
                        LoadTechFailureResult(Me.tmpDeviceID)

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

        '******************************************************************************************************
        Private Sub LoadFailureCodes()
            Dim dtCodes As New DataTable()
            Dim i As Integer
            Try
                dtCodes = Me._objAIG.LoadFailureCodes(True)
                _bLoadDataToCtrl = True

                With Me.cboCodes
                    .DataSource = dtCodes.DefaultView
                    .DisplayMember = dtCodes.Columns("DCode_SLDesc").ToString
                    .ValueMember = dtCodes.Columns("DCode_ID").ToString
                    For i = 0 To .Columns.Count - 1
                        .Splits(0).DisplayColumns(i).Visible = False
                    Next i
                    .Splits(0).DisplayColumns("DCode_SLDesc").Visible = True
                    .Splits(0).DisplayColumns("DCode_SLDesc").Width = .Width - (.VScrollBar.Width + 4)
                    .SelectedValue = 0
                End With

            Catch ex As Exception
                MsgBox("Error in frmQC.LoadFailureCodes:: " & ex.Message.ToString, MsgBoxStyle.Critical)
            Finally
                dtCodes = Nothing
                _bLoadDataToCtrl = False
            End Try
        End Sub

        '******************************************************************************************************
        Private Sub LoadTechFailureResult(ByVal iDevice_ID As Integer)
            Dim dtTechFailResult As New DataTable()
            Dim row As DataRow
            Dim i As Integer
            Dim strItem As String

            Try
                dtTechFailResult = Me._objNewTech.GetTechFailureResult(iDevice_ID)

                Me.lstFailCodes.Items.Clear()
                For Each row In dtTechFailResult.Rows
                    strItem = Trim(row("DCode_SLDesc") & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & strdelimiter & row("DCode_ID"))
                    Me.lstFailCodes.Items.Add(strItem)
                Next

            Catch ex As Exception
                MsgBox("Failed to LoadTechFailureResult: " & ex.Message.ToString, MsgBoxStyle.Critical)
            Finally
                dtTechFailResult = Nothing
            End Try
        End Sub
        '*******************************************************************
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

        '*******************************************************************
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
                        Me._iDeviceWipOwner = CInt(_drCelloptData("cellopt_WipOwner"))
                        If Not IsDBNull(_drCelloptData("Workstation")) Then Me.lblWipLoc.Text = _drCelloptData("Workstation") Else Me.lblWipLoc.Text = ""
                        If _drCelloptData("WIL_SDESC").ToString.Trim.Length > 0 Then Me.lblWipLoc.Text &= " - " & _drCelloptData("WIL_SDESC").ToString.Trim
                        '******************************************
                        'Validate current location
                        '******************************************
                        If Misc.ValidateFrStationOfScreenInWorkFlow(Me._strScreenName, _drCelloptData("Workstation").ToString.Trim, Me.tmpCustID, 0, True) = False Then
                            Me.btnClear_Click(Nothing, Nothing)
                        End If
                        '******************************************
                    Else
                        Throw New Exception("Cellopt data is missing.")
                    End If
                End If

                '//****************************************************************
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

        '***************************************************************************************************
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
                    Me.lblCustName.Text = dt.Rows(0)("Cust_Name1")

                    If tmpDeviceID = 0 Or tmpModelID = 0 Or tmpManufID = 0 Then
                        Throw New Exception("Can not define Device ID/ Model ID/ Manufacturer ID of this device.")
                    End If

                    If Me._iPSSWrty = 1 Then Me.lblPSSWrtyStatus.Text = "IW" Else Me.lblPSSWrtyStatus.Text = "OW"

                    Me.LoadConsumeTransaction()

                    Me.LoadPreviousRepairData()

                    Dim dtExtWrtyData As DataTable
                    dtExtWrtyData = Me._objNewTech.GetExtenedWarrantyData(tmpWO)
                    If dtExtWrtyData.Rows.Count > 0 Then
                        If dtExtWrtyData.Rows(0)("EstimatedTechHrs").ToString.Trim.Length > 0 AndAlso CInt(dtExtWrtyData.Rows(0)("EstimatedTechHrs")) > 0 Then lblTechHrs.Text = "Tech Hrs: " & dtExtWrtyData.Rows(0)("EstimatedTechHrs").ToString Else lblTechHrs.Text = ""
                        If Not IsDBNull(dtExtWrtyData.Rows(0)("DefectType1")) Then Me.lblDefectTypes.Text = dtExtWrtyData.Rows(0)("DefectType1").ToString
                        If Me.lblDefectTypes.Text.Trim.Length > 0 Then Me.lblDefectTypes.Text &= "; "
                        If Not IsDBNull(dtExtWrtyData.Rows(0)("DefectType2")) Then Me.lblDefectTypes.Text &= dtExtWrtyData.Rows(0)("DefectType2").ToString
                        If Not IsDBNull(dtExtWrtyData.Rows(0)("ErrDesc_ItemSKU")) Then Me.lblCustErrDesc.Text = dtExtWrtyData.Rows(0)("ErrDesc_ItemSKU").ToString
                        Me.lblModel.Text = dtExtWrtyData.Rows(0)("Model") : Me.lblMake.Text = dtExtWrtyData.Rows(0)("Brand")
                        If Not IsDBNull(dtExtWrtyData.Rows(0)("ExpectedShipDate")) AndAlso dtExtWrtyData.Rows(0)("ExpectedShipDate").ToString.Trim.Length > 0 Then Me.lblExpectedShipDate.Text = CDate(dtExtWrtyData.Rows(0)("ExpectedShipDate")).ToString("MM/dd/yyyy")
                        If Not IsDBNull(dtExtWrtyData.Rows(0)("EstimatedPartCost_Date")) Then _bHasQuoteApproved = True Else _bHasQuoteApproved = False
                    End If
                    If Me._bHasQuoteApproved AndAlso Me._bHasAccessToResetQuoteApproval = False Then
                        Me.btnComplete.Enabled = False : Me.btnQuoteSumitted_TechHrs.Enabled = False
                    Else
                        Me.btnComplete.Enabled = True : Me.btnQuoteSumitted_TechHrs.Enabled = True
                    End If
                End If

                Return booResult
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '*********************************************************************************************
        Private Sub LoadDevice()
            Try
                _device = Nothing
                _device = New Device(Me.tmpDeviceID)
                _device.ScreenID = Me._iScreenID
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*********************************************************************************************
        Private Sub loadBillCodes()
            Dim mthdGrp, mthdScrap As DataTable
            Dim objBD As Buisness.DeviceBilling
            Dim dtFuncParts As DataTable

            Try
                If tmpConsignedParts = 1 Then
                    mthdGrp = objBD.GetConsignedPartBillcodes(tmpModelID)
                Else
                    objBD = New Buisness.DeviceBilling()
                    mthdGrp = objBD.GetPartBillcodes(tmpCustID, tmpModelID, 5, , 0)
                End If

                '//New code to get scrap button datatable
                mthdScrap = objBD.GetScrapPartBillcodes(tmpModelID)
                '//New code to get scrap button datatable

                createBillingButtons(mthdGrp)
                System.Windows.Forms.Application.DoEvents()
                createScrapButtons(mthdScrap)
                System.Windows.Forms.Application.DoEvents()

            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(objBD) Then objBD = Nothing
                Buisness.Generic.DisposeDT(mthdGrp)
                Buisness.Generic.DisposeDT(mthdScrap)
            End Try
        End Sub

        '******************************************************************
        Private Sub loadServiceCodes()
            Dim mthd As New PSS.Data.Production.Joins()
            'Dim mthdGrp As DataTable = mthd.GenericSelect("SELECT lbillcodes.*, lpsprice.psprice_number FROM ((lbillcodes INNER JOIN tpsmap ON lbillcodes.billcode_id = tpsmap.billcode_id)INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id) WHERE tpsmap.model_id = " & tmpModelID & " AND billtype_id = 1 AND lbillcodes.billcode_id <> 278 ORDER BY BillCode_Desc")
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
                '//End of new code segment
                'February 26, 2007

                createServiceButtons(mthdGrp)

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

        '******************************************************************
        Private Sub populateParts()
            Dim x As Integer = 0
            Dim R1 As DataRow
            Dim tmpBtn As Button

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
                        tmpBtn = CType(pnlService.Controls(x), System.Windows.Forms.Button)
                        If R1("BillCode_ID") = tmpBtn.Tag Then
                            tmpBtn.ForeColor = Color.Blue : Exit For
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

        '*******************************************************************
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
                '*********************
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

        '********************************************************************************
        Private Sub billingClick(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim iFailID, iRepairID, iComplainID, iRVPart, iConsignedPart As Integer
            Dim dr1, drAddingBillcode, drBOMPart As DataRow
            Dim x As Integer
            Dim action As String
            Dim strAddPartNo, strBilledPartNo, strCorrectPart As String
            Dim dtContingent As DataTable
            Dim booIsRVPart As Boolean = False

            Try
                strAddPartNo = "" : strBilledPartNo = "" : iFailID = 0 : iRepairID = 0 : iComplainID = 0 : iRVPart = 0 : iConsignedPart = 0

                If Me._bHasQuoteApproved AndAlso Me._bHasAccessToResetQuoteApproval = False Then
                    MessageBox.Show("You don't have access to modify billing after quote has approved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                ElseIf Me._iPSSWrty = 1 AndAlso _drCelloptData("PSS_Wrty_Approval_User_ID").ToString = "0" Then
                    MessageBox.Show("Need pss warranty approval.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                ElseIf Me._bHasQuoteApproved AndAlso Me._bHasAccessToResetQuoteApproval = False Then
                    Me._objAIG.ResetQuoteApproval(Me.tmpWO)
                End If

                '//Determine action to be performed
                action = "add"
                If Me._device.Parts.Select("Billcode_ID = " & CInt(sender.tag.ToString)).Length > 0 Then action = "remove"

                'validate pss wrty and only one ship back hard drive can be billed
                If action = "add" AndAlso (sender.text = "PSS Warranty No Fault Found" OrElse sender.text = "Repaired PSS Warranty") AndAlso Me._iPSSWrty = 0 Then
                    MessageBox.Show("This device is not under PSS warranty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                ElseIf action = "add" AndAlso sender.text.ToString.Trim.ToLower.StartsWith("ship back hard drive") AndAlso Me._device.Parts.Select("Billcode_Desc = 'Ship Back Hard Drive' or Billcode_Desc = 'Ship Back Hard Drive With Unit'").Length > 0 Then
                    MessageBox.Show("Only allow one ""Ship Back Hard Drive"" service.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub

                End If

                '**************************************************************************
                'Because part is different every time therefore tech have to input part#
                '**************************************************************************
                If action = "add" AndAlso Me._device.BillableBillcodes.Select("Billcode_ID = " & sender.tag.ToString)(0)("BillType_ID") <> 1 Then
                    drBOMPart = Me.CollectCorrectPart(Convert.ToInt32(sender.tag), True)
                    If IsNothing(drBOMPart) Then Exit Sub
                End If

                '#########################################################################
                'Only allow one service ####THE SEQUENCE OF THIS IF IS IMPORTANCE. PLEASE DONT CHANGE ORDER OF THIS BLOCK
                If action = "add" AndAlso Me._device.BillableBillcodes.Select("Billcode_ID = " & sender.tag.ToString)(0)("BillType_ID") = 1 Then
                    Dim strMainServices As String = TMISharedFunc.GetMainService(Me._device.Parts)
                    If (strMainServices.Trim.Length = 0 AndAlso buisness.AIGProduceShip.IsMainService(sender.text) = False) OrElse (Me._device.Parts.Select("BillType_ID = 1").Length > 0 AndAlso strMainServices.Trim.Length = 0) Then
                        MessageBox.Show("Please select main service first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    ElseIf (sender.text = "Scrap" OrElse sender.text = "Exception Repairs Quote Rejected") AndAlso (strMainServices = "Scrap" OrElse strMainServices = "Exception Repairs Quote Rejected") Then
                        'OK to have scrap with Exception Repairs Quote Rejected
                    ElseIf strMainServices.Trim.Length > 0 AndAlso TMISharedFunc.IsMainService(sender.text) = True Then
                        MessageBox.Show("Only allow one main service.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    ElseIf sender.text = "Exception Repairs" AndAlso Me.lblTechHrs.Text.Trim.Length = 0 Then
                        MessageBox.Show("Please enter tech hour.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                        'ElseIf TMISharedFunc.ValidateServices(sender.text.ToString, Me._device.Parts) = False Then
                        '    Exit Sub
                    End If
                End If
                '#########################################################################

                If action = "add" AndAlso ValidateSelectionOfServiceBillcode(Convert.ToInt32(sender.tag), sender.Text) = False Then
                    Exit Sub
                End If

                '*********************************
                'Define Adding Part #
                '*********************************
                If action = "add" AndAlso Me._device.BillableBillcodes.Select("Billcode_ID = " & CInt(sender.tag.ToString)).Length = 0 Then
                    MessageBox.Show("Billcode ID is missing in billable list. Please refresh the screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                Else
                    strAddPartNo = Me._device.BillableBillcodes.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0)("PSPrice_Number").ToString.ToLower
                    iRVPart = Me._device.BillableBillcodes.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0)("RVFlag")
                    If iRVPart = 1 Then booIsRVPart = True
                    iConsignedPart = Me._device.BillableBillcodes.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0)("PSPrice_ConsignedPart")
                End If

                'If action = "add" AndAlso strAddPartNo.Trim.ToLower <> "temppart" AndAlso Me._device.BillableBillcodes.Select("Billcode_ID = " & sender.tag.ToString)(0)("BillType_ID") = 2 Then
                '    'Technician has to confirm corret part # in BOM
                '    If MessageBox.Show("Please confirm the following part number is correct by click on OK otherwise click Cancel and contact your suppervisor. " & Environment.NewLine & strAddPartNo, "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Cancel Then Exit Sub
                'End If

                '*********************************
                If action = "add" AndAlso Me.ValidateRVOEMAndConsighnedPartSelection(strAddPartNo, CInt(Trim(sender.tag.ToString)), iRVPart, iConsignedPart) = False Then
                    '***************************************************
                    'RV, EOM and Consigned Parts validation 05/05/2011
                    '***************************************************
                    Exit Sub
                End If

                '//March 24, 2006
                Me.Enabled = False

                dtContingent = Me._objNewTech.GetContingentBillcodes(Trim(sender.tag.ToString), tmpModelID, tmpLoc)
                If action = "remove" Then   '//turn off
                    For Each dr1 In dtContingent.Rows
                        If PSS.Data.buisness.Generic.IsBillcodeExisted(Me.tmpDeviceID, dr1("cbill_contBillcode")) Then Me._device.DeletePart(dr1("cbill_contBillcode"))
                    Next dr1

                    deleteComponent(Trim(sender.tag.ToString))
                Else    '//turn on
                    For Each dr1 In dtContingent.Rows
                        If PSS.Data.buisness.Generic.IsBillcodeMapped(tmpModelID, dr1("cbill_contBillcode")) > 0 AndAlso PSS.Data.buisness.Generic.IsBillcodeExisted(Me.tmpDeviceID, dr1("cbill_contBillcode")) = False Then Me._device.AddPart(dr1("cbill_contBillcode"))
                    Next dr1
                    addComponent(Trim(sender.tag.ToString), drBOMPart)
                End If

                Dim objAIG As New buisness.AIG()
                objAIG.BillExceptionRepairs(Me.tmpDeviceID, Me._device.Parts)
                objAIG = Nothing
                '*******************************
                Me.HighLightSelectedButtons()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "BillingButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True
                dr1 = Nothing : Buisness.Generic.DisposeDT(dtContingent)
                '********************************
                'Reset fail and repair code ID
                '********************************
                If Not IsNothing(Me._device) Then
                    Me._device.FailID = 0 : Me._device.RepairID = 0 : Me._device.ComplainID = 0
                End If
                '********************************
            End Try
        End Sub

        '********************************************************************************
        Private Function CollectCorrectPart(ByVal iBillcodeID As Integer, ByVal booValidateExistingOfPart As Boolean) As DataRow
            Dim strCorrectPart As String = ""
            Dim drCorrectPartInfo, drBOMPart As DataRow

            Try
                drBOMPart = Nothing
                strCorrectPart = InputBox("Enter Part #:", "Part #").Trim()
                If strCorrectPart.Trim.Length = 0 Then Exit Function
                drCorrectPartInfo = PSS.Data.Buisness.Pricing.GetPartInfo(strCorrectPart)
                If booValidateExistingOfPart = True AndAlso IsNothing(drCorrectPartInfo) Then
                    MessageBox.Show("Part does not exist.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf booValidateExistingOfPart = True AndAlso Convert.ToDecimal(drCorrectPartInfo("PSPrice_StndCost")) = 0 Then
                    MessageBox.Show("This part does not have price.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    drBOMPart = Me._device.BillableBillcodes.Select("BillCode_ID = " & iBillcodeID)(0)
                    drBOMPart.BeginEdit()
                    If IsNothing(drCorrectPartInfo) Then
                        drBOMPart("PSPrice_AvgCost") = 0
                        drBOMPart("PSPrice_StndCost") = 0
                        drBOMPart("PSPrice_Number") = strCorrectPart.ToUpper
                    Else
                        drBOMPart("PSPrice_AvgCost") = drCorrectPartInfo("PSPrice_AvgCost")
                        drBOMPart("PSPrice_StndCost") = drCorrectPartInfo("PSPrice_StndCost")
                        drBOMPart("PSPrice_Number") = drCorrectPartInfo("PSPrice_Number")
                    End If
                    drBOMPart.EndEdit()
                End If

                Return drBOMPart
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************
        Private Function ValidateSelectionOfServiceBillcode(ByVal iBillcodeID As Integer, ByVal strBillCodeDesc As String) As Boolean
            ValidateSelectionOfServiceBillcode = False
            Try
                If Me._device.BillableBillcodes.Select("Billcode_ID = " & iBillcodeID.ToString)(0)("BillType_ID") = 2 AndAlso Me._device.NTF Then
                    'Can't add part to NTF
                    MessageBox.Show("Not allow to add part to NTF device.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                ElseIf Me._device.BillableBillcodes.Select("Billcode_ID = " & iBillcodeID.ToString)(0)("BillCode_Rule") = 6 AndAlso Me._device.Parts.Select("BillType_ID = 2").Length > 0 Then
                    'Can't add part to NTF
                    MessageBox.Show("Please remove all part before select NTF.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                ElseIf Me._device.BillableBillcodes.Select("Billcode_ID = " & iBillcodeID.ToString)(0)("Billcode_Desc").ToString.Trim.ToLower = "Exception Repairs Quote Rejected" AndAlso (Me._device.Parts.Select("BillType_ID = 2").Length > 0) Then
                    'Exception Repairs Quote Rejected
                    MessageBox.Show("Please remove all part(s) before select ""Exception Repairs Quote Rejected"".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                ElseIf Me._device.BillableBillcodes.Select("Billcode_ID = " & iBillcodeID.ToString)(0)("BillType_ID") = 2 AndAlso Me._device.Parts.Select("Billcode_Desc = 'Exception Repairs Quote Rejected'").Length > 0 Then
                    MessageBox.Show("Can't add part to ""Exception Repairs Quote Rejected"" .", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                ElseIf Me._device.BillableBillcodes.Select("Billcode_ID = " & iBillcodeID.ToString)(0)("BillType_ID") = 2 AndAlso Me._device.Parts.Select("Billcode_Desc = 'PSS Warranty NFF'").Length > 0 Then
                    MessageBox.Show("Can't add part to ""PSS Warranty NFF"" .", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                ElseIf Me._device.BillableBillcodes.Select("Billcode_ID = " & iBillcodeID.ToString)(0)("Billcode_Desc") = "PSS Warranty NFF" AndAlso (Me._device.Parts.Select("BillType_ID = 2").Length > 0) Then
                    MessageBox.Show("Please remove part before select ""PSS Warranty NFF"".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                Else
                    Return True
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
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

        '**************************************************************
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

                'Panel Services
                For i = 0 To Me.pnlService.Controls.Count - 1
                    If Me._device.Parts.Select("Billcode_ID = " & Me.pnlService.Controls(i).Tag).Length > 0 Then
                        Me.pnlService.Controls(i).ForeColor = Color.Blue
                    Else
                        Me.pnlService.Controls(i).ForeColor = Color.Black
                    End If
                Next i

                'pnlRVParts
                For i = 0 To Me.pnlRVParts.Controls.Count - 1
                    If Me._device.Parts.Select("Billcode_ID = " & Me.pnlRVParts.Controls(i).Tag).Length > 0 Then
                        Me.pnlRVParts.Controls(i).ForeColor = Color.Blue
                    Else
                        Me.pnlRVParts.Controls(i).ForeColor = Color.Black
                    End If
                Next i

                ''pnlAccessories
                'For i = 0 To Me.pnlAccessories.Controls.Count - 1
                '    If Me._device.Parts.Select("Billcode_ID = " & Me.pnlAccessories.Controls(i).Tag).Length > 0 Then
                '        Me.pnlAccessories.Controls(i).ForeColor = Color.Blue
                '    Else
                '        Me.pnlAccessories.Controls(i).ForeColor = Color.Black
                '    End If
                'Next i

                ''pnlNeededAccessories
                'For i = 0 To Me.pnlNeededAccessories.Controls.Count - 1
                '    If Me._dtAWAP.Select("Billcode_ID = " & Me.pnlNeededAccessories.Controls(i).Tag).Length > 0 Then
                '        Me.pnlNeededAccessories.Controls(i).ForeColor = Color.Blue
                '    Else
                '        Me.pnlNeededAccessories.Controls(i).ForeColor = Color.Black
                '    End If
                'Next i

                ''pnlNeededParts
                'For i = 0 To Me.pnlNeededParts.Controls.Count - 1
                '    If Me._dtAWAP.Select("Billcode_ID = " & Me.pnlNeededParts.Controls(i).Tag).Length > 0 Then
                '        Me.pnlNeededParts.Controls(i).ForeColor = Color.Blue
                '    Else
                '        Me.pnlNeededParts.Controls(i).ForeColor = Color.Black
                '    End If
                'Next i
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '**************************************************************
        Private Sub frmNewTech_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable

            Try
                Me._objNewTech = New PSS.Data.Buisness.NewTech()
                origFrmWidth = Me.Width
                txtSerial.Focus()
                Me.lblScreenName.Text = Me._strScreenName

                If PSS.Core.ApplicationUser.GetPermission("AIG_ResetQuoteApproval") > 0 Then _bHasAccessToResetQuoteApproval = True Else _bHasAccessToResetQuoteApproval = False
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmNewTech_Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
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
                    'If btnTop + btnHeight + 120 > pnlBill.Height Then
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
                tmpBtn = CType(pnlService.Controls(x), System.Windows.Forms.Button)
                With tmpBtn
                    .Location = New Point(btnLeft, btnTop)
                End With

                colCount += 1
                If colCount > 6 Then
                    'If btnTop + btnHeight + 120 > pnlService.Height Then
                    btnLeft = btnLeft + btnWidth + 5
                    btnTop = vBuffer
                    colCount = 0
                Else
                    btnTop = btnTop + btnHeight + 5
                End If
            Next
        End Sub

        '*********************************************************************************************
        Private Sub addComponent(ByVal valBillCode As Integer, ByVal drPart As DataRow)
            Dim iUpdateDBRCode As Integer = 0

            Try
                '*************************************************
                'Get Part Data Information
                '*************************************************
                If valBillCode > 0 Then
                    _device.AddPart(valBillCode, drPart)
                    _device.Update()
                End If
                '*************************************************
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*********************************************************************************************
        Private Sub deleteComponent(ByVal valBillCode As Integer)
            Try
                '*************************************************
                '//Added by Asif
                If (tmpCustID = 1 Or tmpCustID = 14) And CInt(Trim(valBillCode)) = 25 Then  'Metrocall DBR devices
                    Dim objDeviceBilling As New PSS.Data.Buisness.DeviceBilling()
                    objDeviceBilling.UnShipMessDBR(tmpDeviceID)
                    objDeviceBilling.DeleteDBRCode(tmpDeviceID)
                    objDeviceBilling = Nothing
                End If

                If valBillCode > 0 Then
                    _device.DeletePart(valBillCode)
                    _device.Update()
                    ' TMISharedFunc.BillExceptionRepairs(Me.tmpDeviceID, Convert.ToDecimal(Me._device.CustMarkUp), Me._device.Parts)
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*********************************************************************************************
        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
            '*************************************
            ' Added by Lan on 10/19/2007.
            ' Get Prebill data.
            '*************************************
            Dim iIsDevHaspart As Integer = 0
            Dim booUpdateTechInfo As Boolean = True

            If Trim(Me.txtSerial.Text) <> "" And Me.tmpDeviceID > 0 Then
                Try
                    If Me.tmpCustID <> 2253 AndAlso Not (Me.tmpProdID = 9 AndAlso Me._device.Parts.Select("[Billcode_ID] = 1590").Length > 0) Then
                        If Me.tmpCustID = 2258 Then booUpdateTechInfo = False 'don't update tech data for Tracfone Customer
                        Me._objNewTech.UpdateWipOwnerID(tmpDeviceID, Me.tmpProdID, PSS.Core.ApplicationUser.IDuser, Me._iDeviceWipOwner, booUpdateTechInfo, , "AIG Billing")
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.ToString, "Send Device to WaitingPart", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                End Try
            End If
            '*************************************
            Me.dgConsumed.DataSource = Nothing
            Me.ButtonClear_ClickEvent()
            Me.txtSerial.Focus()
        End Sub

        '*********************************************************************************************
        Private Sub ButtonClear_ClickEvent()
            Me.txtSerial.Enabled = True
            Me.pnlBill.BackColor = Me.BackColor
            Me.pnlService.Controls.Clear()
            Me.pnlBill.Controls.Clear()
            Me.pnlScrap.Controls.Clear()
            Me.pnlRVParts.Controls.Clear()

            txtSerial.Text = ""

            Me.tmpDeviceID = 0 : Me.tmpModelID = 0 : Me.tmpManufID = 0 : Me.tmpProdID = 0
            Me.tmpWO = 0 : Me._iDeviceWipOwner = 0

            '//reset the bill tray feature

            tabMain.Visible = True
            Me.lblWipLoc.Text = "" : Me.lblModel.Text = "" : Me.lblMake.Text = ""

            Me.lblTechNotesUpdDate.Text = "" : Me.txtTechNotes.Text = ""
            Me.lblTestResult_Triage.Text = "" : Me.lblTestResult_QC.Text = ""
            Me.lblDefectTypes.Text = "" : Me.lblCustErrDesc.Text = ""
            Me.lblTechHrs.Text = "" : Me.lblExpectedShipDate.Text = ""

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
            _bLoadDataToCtrl = False
            _bHasQuoteApproved = False

            'Trans History
            Me.dgConsumed.DataSource = Nothing
            Me.dgPartNeeds.DataSource = Nothing

            Me._iPSSWrty = 0

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

        '**************************************************************
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

        '*********************************************************************************************
        Private Sub btnComplete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComplete.Click
            Dim iTestTypeID As Integer = 7
            Dim iRework As Integer = 1
            Dim objTFMisc As PSS.Data.Buisness.TracFone.clsMisc
            Dim objAIGShip As New PSS.Data.Buisness.AIGProduceShip()
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
                ElseIf objAIGShip.IsDeviceHasMainService(Me._device.Parts) = False Then
                    MessageBox.Show("Please select repair service.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Me.pnlBill.BackColor = Me.BackColor
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    strFrStation = PSS.Data.Buisness.Generic.GetCurrentWorkstaion(Me.tmpDeviceID) : strToStation = ""

                    If SetDeviceWipStation(strToStation) = True Then
                        '***********************************************
                        'Write Refurbished completed record
                        '***********************************************
                        If iTestTypeID > 0 Then
                            objTFMisc = New PSS.Data.Buisness.TracFone.clsMisc()
                            objTFMisc.WriteTestResult(Me.tmpDeviceID, iTestTypeID, PSS.Core.Global.ApplicationUser.IDuser, 0, iRework, , , , , , , PSS.Data.Buisness.Generic.GetMachineCostCenterID(), strFrStation, strToStation)
                        End If

                        'Update Cellopt completed data
                        Me._objNewTech.UpdateRefurbCompletedData(Me.tmpDeviceID, 0, ApplicationUser.IDuser, ApplicationUser.LineID, True)

                        Me.Enabled = False : Cursor.Current = Cursors.Default
                        '***********************************************
                        Me.dgConsumed.DataSource = Nothing
                        Me.ButtonClear_ClickEvent()
                        txtSerial.Focus()
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnComplete_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default : objAIGShip = Nothing : objTFMisc = Nothing : Me.txtSerial.Focus()
            End Try
        End Sub

        '*********************************************************************************************
        Private Function SetDeviceWipStation(ByRef strNextWrkStation As String) As Boolean
            Dim i, iMaxBillcodeRule, iWipOwner, iStatusID As Integer
            Dim R1 As DataRow
            Dim iSetAWAPFlag As Integer = 0
            Dim strStatusDesc As String = ""
            Dim objTMI As Data.Buisness.TMI

            Try
                i = 0 : iMaxBillcodeRule = 0 : iWipOwner = 9 'Out-Cell
                strNextWrkStation = ""

                '***********************************************
                'Get and assign unit to workstation 
                '***********************************************
                iMaxBillcodeRule = PSS.Data.Buisness.Generic.GetMaxBillRule(tmpDeviceID)
                If Me._device.Parts.Rows.Count > 0 AndAlso iMaxBillcodeRule < 0 Then
                    MessageBox.Show("Bill rule is missing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtSerial.Focus()
                    Return False
                ElseIf Me._device.Parts.Rows.Count > 0 AndAlso iMaxBillcodeRule = 1 Then
                    strNextWrkStation = PSS.Data.Buisness.Generic.GetNextWorkStationInWFP(Me._strScreenName, 0, Me.tmpCustID, 1)
                    iStatusID = 9
                ElseIf Me._device.Parts.Rows.Count > 0 AndAlso iMaxBillcodeRule = 2 Then
                    strNextWrkStation = PSS.Data.Buisness.Generic.GetNextWorkStationInWFP(Me._strScreenName, 0, Me.tmpCustID, 1)
                    iStatusID = 9
                Else
                    If Me._objAIG.NeedExceptionRepairsApproval(Me.tmpDeviceID, Me.tmpCustID) = True Then
                        iWipOwner = PSS.Data.Buisness.AIG.iAwaitApproval_WIPOwner_Hold ' 6 'Hold
                        strNextWrkStation = PSS.Data.Buisness.AIG.strAwaitApproval_Quote '"AWAIT APPROVAL (Quote)"
                        iStatusID = 10
                    Else
                        iWipOwner = 5 : iStatusID = 5
                        strNextWrkStation = PSS.Data.Buisness.Generic.GetNextWorkStationInWFP(Me._strScreenName, 0, Me.tmpCustID, 0, )
                    End If
                End If

                strStatusDesc = Data.buisness.TMIRecShip.GetTMIStatusDesc(iStatusID)
                If strStatusDesc.Trim.Length = 0 Then
                    MessageBox.Show("Can't define Pssi status.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                End If

                If Me.txtTechNotes.Text.Trim.Length = 0 AndAlso Me._objNewTech.GetTechNotesString(Me.tmpDeviceID).Trim.Length = 0 Then
                    MessageBox.Show("Can't complete repair without work performance.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                End If

                'Next workstation
                If strNextWrkStation.Trim.Length > 0 Then
                    PSS.Data.Buisness.Generic.SetTcelloptWorkStationForDevice(strNextWrkStation, tmpDeviceID, Core.ApplicationUser.IDuser, Me._strScreenName, Me.Name, iWipOwner, , , , , )
                    MessageBox.Show("This unit now belongs to " & strNextWrkStation & " workstation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                If strNextWrkStation = "AWAIT APPROVAL (Quote)" Then Me._objAIG.ResetQuoteApproval(Me.tmpWO)
                Me._objAIG.SetPssiStatus(Me.tmpWO, iStatusID, strStatusDesc)

                i = Me._objNewTech.SaveTechNotes(Me.tmpDeviceID, Me.txtTechNotes.Text.Trim, ApplicationUser.IDuser)
                Dim strErrMsg As String = ""
                Me._objNewTech.SaveTechFailureResult(Me.tmpDeviceID, Me.GetCorrectCodes, ApplicationUser.IDuser, strErrMsg)

                Return True
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************************************
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

        '*********************************************************************************************

#Region "Test Results"

        '******************************************************************
        Private Sub loadTestResults()
            Dim dtTechNotes As DataTable

            Try
                Me.lblTestResult_Triage.Text = ""
                Me.lblTestResult_QC.Text = ""

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

        '***************************************************************************
        Private Sub txtTechNotes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTechNotes.KeyPress
            Try
                If e.KeyChar = Chr(Keys.Enter) Then
                    e.Handled = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtTechNotes_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***************************************************************************
        Private Sub btnTechNotesSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTechNotesSave.Click
            Dim i As Integer = 0
            Dim strErrMsg As String = ""

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
                        'Save failure result
                        Me._objNewTech.SaveTechFailureResult(Me.tmpDeviceID, Me.GetCorrectCodes, ApplicationUser.IDuser, strErrMsg)
                        If strErrMsg.Trim.Length > 0 Then
                            MessageBox.Show("Note did not save." & strErrMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If
                        MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Note did not save the Tech Notes.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnSaveTechNotes_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*****************************************************************************
        Private Sub lstFailCodes_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lstFailCodes.KeyUp
            If e.KeyValue = 13 Then        'Enter Key Pressed
                RemoveItemFromList()
            End If
        End Sub

        '*****************************************************************************
        Private Sub RemoveItemFromList()
            If Me.lstFailCodes.SelectedIndex <> -1 Then    'If nothing is selected
                Me.lstFailCodes.Items.RemoveAt(Me.lstFailCodes.SelectedIndex)
                Me.lstFailCodes.Refresh()
            End If
        End Sub

        '***************************************************************************

#End Region

        '*********************************************************************************************
        Private Sub tpInfo_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tpPartHistory.VisibleChanged
            Try
                If Me.tpPartHistory.Visible = True Then LoadConsumeTransaction()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "tbDevInfo_VisibleChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*********************************************************************************************
        Private Sub LoadConsumeTransaction()
            Dim dt As DataTable
            Dim objAIG As New Buisness.AIG()

            Try
                '***************************************************
                'Populate consume transaction and need transaction
                '***************************************************
                dt = Me._objNewTech.GetPartConsumedTrans(Me.tmpDeviceID)
                With Me.dgConsumed
                    .DataSource = dt.DefaultView
                    .Splits(0).DisplayColumns("Seq").Width = 30
                    .Splits(0).DisplayColumns("Action").Width = 60
                End With
                dt = Nothing

                dt = objAIG.GetPartNeeds(Me.tmpWO)
                With Me.dgPartNeeds
                    .DataSource = dt.DefaultView
                    .Splits(0).DisplayColumns("WO_ID").Width = 30
                    .Splits(0).DisplayColumns("PN_ID").Width = 60
                End With
            Catch ex As Exception
                Throw ex
            Finally
                objAIG = Nothing : Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '*********************************************************************************************
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

        '*********************************************************************************************
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

        '*********************************************************************************************
        Private Sub dgPreRepDev_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles dgPreRepDev.RowColChange
            Dim dteLastDateInPSSWrty As DateTime

            Try
                If Me.dgPreRepDev.RowCount > 0 AndAlso Me.dgPreRepDev.Columns.Count > 0 Then
                    If Convert.ToInt32(Me.dgPreRepDev.Columns("Device_ID").CellValue(Me.dgPreRepDev.Row)) > 0 Then
                        LoadPrevRepPartsServiceData(Me.dgPreRepDev.Columns("Device_ID").CellValue(Me.dgPreRepDev.Row))
                        Me.lblPrevRepTechNote.Text = Me.dgPreRepDev.Columns("Tech Notes").CellValue(Me.dgPreRepDev.Row)

                        'dteLastDateInPSSWrty = DateAdd(DateInterval.Day, 90, Convert.ToDateTime(Me.dgPreRepDev.Columns("Ship Date").CellValue(Me.dgPreRepDev.Row)))
                        'If DateDiff(DateInterval.Day, Convert.ToDateTime(Me._strReceiptDate), dteLastDateInPSSWrty) >= 0 Then
                        '    Me.lblPSSWrtyStatus.Text = "PSS Warranty : YES"
                        '    Me.lblPSSWrtyStatus.Tag = 1
                        'Else
                        '    Me.lblPSSWrtyStatus.Text = "PSS Warranty : N0"
                        '    Me.lblPSSWrtyStatus.Tag = 0
                        'End If
                    Else
                        Me.lblDefectTypes.Text = ""
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dgPreRepDev_RowColChange", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        ''*********************************************************************************************
        'Public Shared Function NIAutoShip(ByVal iDeviceID As Integer, ByVal iWOID As Integer) As Boolean
        '    Dim objNIShip As New Buisness.NIRecShip()
        '    Dim objProdShip As New Data.Production.Shipping()
        '    Dim i, iBoxQty As Integer
        '    Dim strBoxName, strNextStation, strRMA As String

        '    Try
        '        NIAutoShip = False
        '        strBoxName = objProdShip.GetPalletName(Buisness.NI.PalletID_Scrap)
        '        PSS.Data.Production.Shipping.AssignDeviceToPallet(iDeviceID, Buisness.NI.PalletID_Scrap)
        '        iBoxQty = PSS.Data.Buisness.Generic.GetPalletQty(Buisness.NI.PalletID_Scrap)
        '        strRMA = PSS.Data.Buisness.Generic.GetWONameByWOID(iWOID)
        '        strNextStation = "IN-TRANSIT"
        '        i = objNIShip.CloseAndShipBox_Refurb(Buisness.NI.PalletID_Scrap, iWOID, iDeviceID, _
        '                                             ApplicationUser.IDShift, iBoxQty, strNextStation, _
        '                                             objProdShip, 0, "Shipped to Warehouse", False)
        '        Return True
        '    Catch ex As Exception
        '        Throw ex
        '    Finally
        '        objNIShip = Nothing
        '    End Try
        'End Function

        '*********************************************************************************************
        Private Sub btnQuoteSumitted_TechHrs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuoteSumitted_TechHrs.Click
            Dim strTechHrs As String = ""
            Dim objAIG As New Buisness.AIG()
            Dim j As Integer = 0

            Try
                If Me.tmpDeviceID > 0 Then
                    strTechHrs = InputBox("Estimate tech hour(s):", "Estimate Tech Hrs").Trim
                    If strTechHrs.Trim.Length = 0 Then
                        MessageBox.Show("Estimate tech hour(s) can't be blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    Else
                        Dim i As Integer = 0
                        For i = 0 To strTechHrs.Length - 1
                            If Char.IsDigit(strTechHrs, i) = False AndAlso strTechHrs.Substring(i).Trim.Equals(".") = False Then
                                MessageBox.Show("Invalid format.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Exit Sub
                            End If
                        Next i

                        j = objAIG.SetTechHour(Me.tmpWO, Math.Ceiling(Convert.ToDouble(strTechHrs)))
                        objAIG.BillExceptionRepairs(Me.tmpDeviceID, Me._device.Parts)

                        If j = 1 Then Me.lblTechHrs.Text = "Tech Hrs: " & strTechHrs
                    End If
                Else
                    MessageBox.Show("An estimate for this unit has already submitted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                objAIG = Nothing
            End Try
        End Sub

        '*********************************************************************************************

        Private Sub cboCodes_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCodes.SelectedValueChanged
            Dim i As Integer = 0

            Try
                If _bLoadDataToCtrl = True Then Exit Sub

                If Me.cboCodes.SelectedValue = 0 Then
                    'MessageBox.Show("Please select the code again.", "Tech Failure Code", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                Dim strItem As String = Trim(Me.cboCodes.Text) & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & strdelimiter & Me.cboCodes.SelectedValue

                For i = 0 To Me.lstFailCodes.Items.Count - 1
                    If Me.lstFailCodes.Items(i) = strItem Then  'UCase(txtDevice.Text) Then
                        MsgBox("This code is already added to the list.", MsgBoxStyle.Information, "Tech Failure Code")
                        Exit Sub
                    End If
                Next

                Me.lstFailCodes.Items.Add(strItem)
                Me.cboCodes.SelectedValue = 0
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Function GetCorrectCodes() As ArrayList
            Dim i As Integer = 0
            Dim strCodes As New ArrayList()
            Dim arrSplitLine()

            For i = 0 To Me.lstFailCodes.Items.Count - 1
                arrSplitLine = Split(Trim(lstFailCodes.Items(i)), strdelimiter)
                strCodes.Add(Trim(arrSplitLine(1)))
                ReDim arrSplitLine(0)
                arrSplitLine.Clear(arrSplitLine, 0, arrSplitLine.Length)
            Next i

            ReDim arrSplitLine(0)
            arrSplitLine.Clear(arrSplitLine, 0, arrSplitLine.Length)

            Return strCodes
        End Function

        '*********************************************************************************************
    End Class
End Namespace

