Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.Pantech

    Public Class frmCustServices
        Inherits System.Windows.Forms.Form

        Private Const _iCustID As Integer = 2453
        Private Const _iLocID As Integer = 3251

        Private _objPTCustService As PSS.Data.Buisness.CustomerServices
        Private _dsApproved As DataSet = Nothing
        Private _dsHold As DataSet = Nothing
        Private ReadOnly _iOWRejectRepair As Integer
        Private _bLoading As Boolean = True
        Private _bClosing As Boolean = False
        Private _strOriginalTrackingNumber As String = String.Empty
        Private _dbgCurrentSN As C1.Win.C1TrueDBGrid.C1TrueDBGrid = Nothing
        Private _bCancelEdit As Boolean = False
        Friend WithEvents _txtApprovedTNEditor As New TextBox()
        Friend WithEvents _txtHoldTNEditor As New TextBox()
        Friend WithEvents _lstShipTypes As New ListBox()

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _objPTCustService = New PSS.Data.Buisness.CustomerServices()
            Me._iOWRejectRepair = Me._objPTCustService.GetOWRejectRepairBillCode()
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
        Friend WithEvents tcCustomerServices As System.Windows.Forms.TabControl
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents btnReprintInvoiceRpt As System.Windows.Forms.Button
        Friend WithEvents tpgHold As System.Windows.Forms.TabPage
        Friend WithEvents dbgHold As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnCopyAllRows As System.Windows.Forms.Button
        Friend WithEvents dbgWaitingToBePack As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents tpWaitingToDockShip As System.Windows.Forms.TabPage
        Friend WithEvents btnWaitingToBePack_CopyAll As System.Windows.Forms.Button
        Friend WithEvents dbgHoldDevices As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnApprove As System.Windows.Forms.Button
        Friend WithEvents btnReject As System.Windows.Forms.Button
        Friend WithEvents gbApproveInput As System.Windows.Forms.GroupBox
        Friend WithEvents dbgHoldSN As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents dbgApproved As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents dbgApprovedSN As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents dbgApprovedDevices As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents dtpApprovedEnd As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpApprovedStart As System.Windows.Forms.DateTimePicker
        Friend WithEvents tpgApproved As System.Windows.Forms.TabPage
        Friend WithEvents rtbIMEI As System.Windows.Forms.RichTextBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCustServices))
            Me.tcCustomerServices = New System.Windows.Forms.TabControl()
            Me.tpgApproved = New System.Windows.Forms.TabPage()
            Me.dbgApprovedDevices = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.dbgApprovedSN = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.dtpApprovedEnd = New System.Windows.Forms.DateTimePicker()
            Me.dtpApprovedStart = New System.Windows.Forms.DateTimePicker()
            Me.btnCopyAllRows = New System.Windows.Forms.Button()
            Me.dbgApproved = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.tpgHold = New System.Windows.Forms.TabPage()
            Me.dbgHoldDevices = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.dbgHoldSN = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnReprintInvoiceRpt = New System.Windows.Forms.Button()
            Me.gbApproveInput = New System.Windows.Forms.GroupBox()
            Me.rtbIMEI = New System.Windows.Forms.RichTextBox()
            Me.btnReject = New System.Windows.Forms.Button()
            Me.btnApprove = New System.Windows.Forms.Button()
            Me.dbgHold = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.tpWaitingToDockShip = New System.Windows.Forms.TabPage()
            Me.btnWaitingToBePack_CopyAll = New System.Windows.Forms.Button()
            Me.dbgWaitingToBePack = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.tcCustomerServices.SuspendLayout()
            Me.tpgApproved.SuspendLayout()
            CType(Me.dbgApprovedDevices, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dbgApprovedSN, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dbgApproved, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpgHold.SuspendLayout()
            CType(Me.dbgHoldDevices, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dbgHoldSN, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.gbApproveInput.SuspendLayout()
            CType(Me.dbgHold, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpWaitingToDockShip.SuspendLayout()
            CType(Me.dbgWaitingToBePack, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'tcCustomerServices
            '
            Me.tcCustomerServices.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpgApproved, Me.tpgHold, Me.tpWaitingToDockShip})
            Me.tcCustomerServices.Location = New System.Drawing.Point(8, 8)
            Me.tcCustomerServices.Name = "tcCustomerServices"
            Me.tcCustomerServices.SelectedIndex = 0
            Me.tcCustomerServices.Size = New System.Drawing.Size(1000, 584)
            Me.tcCustomerServices.TabIndex = 1
            '
            'tpgApproved
            '
            Me.tpgApproved.BackColor = System.Drawing.Color.SteelBlue
            Me.tpgApproved.Controls.AddRange(New System.Windows.Forms.Control() {Me.dbgApprovedDevices, Me.dbgApprovedSN, Me.Label2, Me.Label1, Me.dtpApprovedEnd, Me.dtpApprovedStart, Me.btnCopyAllRows, Me.dbgApproved})
            Me.tpgApproved.Location = New System.Drawing.Point(4, 22)
            Me.tpgApproved.Name = "tpgApproved"
            Me.tpgApproved.Size = New System.Drawing.Size(992, 558)
            Me.tpgApproved.TabIndex = 1
            Me.tpgApproved.Text = "Approved"
            '
            'dbgApprovedDevices
            '
            Me.dbgApprovedDevices.AllowColMove = False
            Me.dbgApprovedDevices.AllowColSelect = False
            Me.dbgApprovedDevices.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.dbgApprovedDevices.AllowUpdate = False
            Me.dbgApprovedDevices.AllowUpdateOnBlur = False
            Me.dbgApprovedDevices.AlternatingRows = True
            Me.dbgApprovedDevices.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgApprovedDevices.BackColor = System.Drawing.Color.SteelBlue
            Me.dbgApprovedDevices.FilterBar = True
            Me.dbgApprovedDevices.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dbgApprovedDevices.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgApprovedDevices.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dbgApprovedDevices.Location = New System.Drawing.Point(606, 319)
            Me.dbgApprovedDevices.MaintainRowCurrency = True
            Me.dbgApprovedDevices.Name = "dbgApprovedDevices"
            Me.dbgApprovedDevices.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgApprovedDevices.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgApprovedDevices.PreviewInfo.ZoomFactor = 75
            Me.dbgApprovedDevices.RowHeight = 20
            Me.dbgApprovedDevices.Size = New System.Drawing.Size(365, 219)
            Me.dbgApprovedDevices.TabIndex = 153
            Me.dbgApprovedDevices.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Transparent;}Se" & _
            "lected{ForeColor:ControlText;BackColor:Yellow;}Style3{}Inactive{ForeColor:Inacti" & _
            "veCaptionText;BackColor:InactiveCaption;}FilterBar{ForeColor:Red;BackColor:Trans" & _
            "parent;}Footer{}Caption{AlignHorz:Center;ForeColor:White;BackColor:Transparent;}" & _
            "Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt;AlignVert:Center;BackColor:Cont" & _
            "rol;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style14{}OddRow{B" & _
            "ackColor:Transparent;}RecordSelector{AlignImage:Center;}Style15{}Heading{Wrap:Tr" & _
            "ue;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;BackColor:Ligh" & _
            "tSteelBlue;Border:Raised,,1, 1, 1, 1;ForeColor:Black;AlignVert:Center;}Style8{}S" & _
            "tyle10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style9{}</Data></Styles><Split" & _
            "s><C1.Win.C1TrueDBGrid.MergeView HBarHeight=""10"" AllowColMove=""False"" AllowColSe" & _
            "lect=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""True"" CaptionHei" & _
            "ght=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" Marqu" & _
            "eeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Vertical" & _
            "ScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>215</Height><CaptionStyle pare" & _
            "nt=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowSt" & _
            "yle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style1" & _
            "3"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""S" & _
            "tyle12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent" & _
            "=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><Od" & _
            "dRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelec" & _
            "tor"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent" & _
            "=""Normal"" me=""Style1"" /><ClientRect>0, 0, 361, 215</ClientRect><BorderSide>0</Bo" & _
            "rderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Spli" & _
            "ts><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Headin" & _
            "g"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" " & _
            "/><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /" & _
            "><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /" & _
            "><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Sty" & _
            "le parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" " & _
            "/><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><" & _
            "horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRec" & _
            "SelWidth><ClientArea>0, 0, 361, 215</ClientArea><PrintPageHeaderStyle parent="""" " & _
            "me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'dbgApprovedSN
            '
            Me.dbgApprovedSN.AllowColMove = False
            Me.dbgApprovedSN.AllowColSelect = False
            Me.dbgApprovedSN.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.dbgApprovedSN.AllowUpdate = False
            Me.dbgApprovedSN.AllowUpdateOnBlur = False
            Me.dbgApprovedSN.AlternatingRows = True
            Me.dbgApprovedSN.BackColor = System.Drawing.Color.SteelBlue
            Me.dbgApprovedSN.FilterBar = True
            Me.dbgApprovedSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dbgApprovedSN.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgApprovedSN.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.dbgApprovedSN.Location = New System.Drawing.Point(19, 320)
            Me.dbgApprovedSN.MaintainRowCurrency = True
            Me.dbgApprovedSN.Name = "dbgApprovedSN"
            Me.dbgApprovedSN.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgApprovedSN.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgApprovedSN.PreviewInfo.ZoomFactor = 75
            Me.dbgApprovedSN.RowHeight = 20
            Me.dbgApprovedSN.Size = New System.Drawing.Size(555, 219)
            Me.dbgApprovedSN.TabIndex = 152
            Me.dbgApprovedSN.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Transparent;}Se" & _
            "lected{ForeColor:ControlText;BackColor:Yellow;}Style3{}Inactive{ForeColor:Inacti" & _
            "veCaptionText;BackColor:InactiveCaption;}FilterBar{ForeColor:Red;BackColor:Trans" & _
            "parent;}Footer{}Caption{AlignHorz:Center;ForeColor:White;BackColor:Transparent;}" & _
            "Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt;BackColor:Control;AlignVert:Cen" & _
            "ter;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddRow{B" & _
            "ackColor:Transparent;}RecordSelector{AlignImage:Center;}Style13{}Heading{Wrap:Tr" & _
            "ue;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;AlignVert:Cent" & _
            "er;Border:Raised,,1, 1, 1, 1;ForeColor:Black;BackColor:LightSteelBlue;}Style8{}S" & _
            "tyle10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style1{}</Data></Styles><Split" & _
            "s><C1.Win.C1TrueDBGrid.MergeView HBarHeight=""10"" AllowColMove=""False"" AllowColSe" & _
            "lect=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""True"" CaptionHei" & _
            "ght=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" Marqu" & _
            "eeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Vertical" & _
            "ScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>215</Height><CaptionStyle pare" & _
            "nt=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowSt" & _
            "yle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style1" & _
            "3"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""S" & _
            "tyle12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent" & _
            "=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><Od" & _
            "dRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelec" & _
            "tor"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent" & _
            "=""Normal"" me=""Style1"" /><ClientRect>0, 0, 551, 215</ClientRect><BorderSide>0</Bo" & _
            "rderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Spli" & _
            "ts><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Headin" & _
            "g"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" " & _
            "/><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /" & _
            "><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /" & _
            "><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Sty" & _
            "le parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" " & _
            "/><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><" & _
            "horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRec" & _
            "SelWidth><ClientArea>0, 0, 551, 215</ClientArea><PrintPageHeaderStyle parent="""" " & _
            "me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(216, 15)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(34, 16)
            Me.Label2.TabIndex = 151
            Me.Label2.Text = "To :"
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(20, 15)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(48, 16)
            Me.Label1.TabIndex = 150
            Me.Label1.Text = "From :"
            '
            'dtpApprovedEnd
            '
            Me.dtpApprovedEnd.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpApprovedEnd.CustomFormat = "MMM d, yyyy"
            Me.dtpApprovedEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpApprovedEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpApprovedEnd.Location = New System.Drawing.Point(250, 11)
            Me.dtpApprovedEnd.Name = "dtpApprovedEnd"
            Me.dtpApprovedEnd.Size = New System.Drawing.Size(130, 24)
            Me.dtpApprovedEnd.TabIndex = 149
            '
            'dtpApprovedStart
            '
            Me.dtpApprovedStart.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpApprovedStart.CustomFormat = "MMM d, yyyy"
            Me.dtpApprovedStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpApprovedStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpApprovedStart.Location = New System.Drawing.Point(71, 11)
            Me.dtpApprovedStart.Name = "dtpApprovedStart"
            Me.dtpApprovedStart.Size = New System.Drawing.Size(127, 24)
            Me.dtpApprovedStart.TabIndex = 148
            '
            'btnCopyAllRows
            '
            Me.btnCopyAllRows.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnCopyAllRows.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnCopyAllRows.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCopyAllRows.ForeColor = System.Drawing.Color.Black
            Me.btnCopyAllRows.Location = New System.Drawing.Point(811, 13)
            Me.btnCopyAllRows.Name = "btnCopyAllRows"
            Me.btnCopyAllRows.Size = New System.Drawing.Size(160, 24)
            Me.btnCopyAllRows.TabIndex = 143
            Me.btnCopyAllRows.Text = "Copy All Rows"
            '
            'dbgApproved
            '
            Me.dbgApproved.AllowColMove = False
            Me.dbgApproved.AllowColSelect = False
            Me.dbgApproved.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.dbgApproved.AllowUpdate = False
            Me.dbgApproved.AllowUpdateOnBlur = False
            Me.dbgApproved.AlternatingRows = True
            Me.dbgApproved.BackColor = System.Drawing.Color.SteelBlue
            Me.dbgApproved.FilterBar = True
            Me.dbgApproved.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dbgApproved.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgApproved.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.dbgApproved.Location = New System.Drawing.Point(18, 57)
            Me.dbgApproved.MaintainRowCurrency = True
            Me.dbgApproved.Name = "dbgApproved"
            Me.dbgApproved.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgApproved.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgApproved.PreviewInfo.ZoomFactor = 75
            Me.dbgApproved.RowHeight = 20
            Me.dbgApproved.Size = New System.Drawing.Size(950, 219)
            Me.dbgApproved.TabIndex = 140
            Me.dbgApproved.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Transparent;}Se" & _
            "lected{ForeColor:ControlText;BackColor:Yellow;}Style3{}Inactive{ForeColor:Inacti" & _
            "veCaptionText;BackColor:InactiveCaption;}FilterBar{ForeColor:Red;BackColor:Trans" & _
            "parent;}Footer{}Caption{AlignHorz:Center;ForeColor:White;BackColor:Transparent;}" & _
            "Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt;AlignVert:Center;BackColor:Cont" & _
            "rol;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style14{}OddRow{B" & _
            "ackColor:Transparent;}RecordSelector{AlignImage:Center;}Style15{}Heading{Wrap:Tr" & _
            "ue;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;BackColor:Ligh" & _
            "tSteelBlue;Border:Raised,,1, 1, 1, 1;ForeColor:Black;AlignVert:Center;}Style8{}S" & _
            "tyle10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style9{}</Data></Styles><Split" & _
            "s><C1.Win.C1TrueDBGrid.MergeView HBarHeight=""10"" AllowColMove=""False"" AllowColSe" & _
            "lect=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""True"" CaptionHei" & _
            "ght=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" Marqu" & _
            "eeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Vertical" & _
            "ScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>215</Height><CaptionStyle pare" & _
            "nt=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowSt" & _
            "yle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style1" & _
            "3"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""S" & _
            "tyle12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent" & _
            "=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><Od" & _
            "dRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelec" & _
            "tor"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent" & _
            "=""Normal"" me=""Style1"" /><ClientRect>0, 0, 946, 215</ClientRect><BorderSide>0</Bo" & _
            "rderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Spli" & _
            "ts><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Headin" & _
            "g"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" " & _
            "/><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /" & _
            "><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /" & _
            "><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Sty" & _
            "le parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" " & _
            "/><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><" & _
            "horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRec" & _
            "SelWidth><ClientArea>0, 0, 946, 215</ClientArea><PrintPageHeaderStyle parent="""" " & _
            "me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'tpgHold
            '
            Me.tpgHold.BackColor = System.Drawing.Color.SteelBlue
            Me.tpgHold.Controls.AddRange(New System.Windows.Forms.Control() {Me.dbgHoldDevices, Me.dbgHoldSN, Me.btnReprintInvoiceRpt, Me.gbApproveInput, Me.dbgHold})
            Me.tpgHold.Location = New System.Drawing.Point(4, 22)
            Me.tpgHold.Name = "tpgHold"
            Me.tpgHold.Size = New System.Drawing.Size(992, 558)
            Me.tpgHold.TabIndex = 2
            Me.tpgHold.Text = "Hold"
            Me.tpgHold.Visible = False
            '
            'dbgHoldDevices
            '
            Me.dbgHoldDevices.AllowColMove = False
            Me.dbgHoldDevices.AllowColSelect = False
            Me.dbgHoldDevices.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.dbgHoldDevices.AllowUpdate = False
            Me.dbgHoldDevices.AllowUpdateOnBlur = False
            Me.dbgHoldDevices.AlternatingRows = True
            Me.dbgHoldDevices.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgHoldDevices.BackColor = System.Drawing.Color.SteelBlue
            Me.dbgHoldDevices.FilterBar = True
            Me.dbgHoldDevices.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dbgHoldDevices.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgHoldDevices.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.dbgHoldDevices.Location = New System.Drawing.Point(603, 311)
            Me.dbgHoldDevices.MaintainRowCurrency = True
            Me.dbgHoldDevices.Name = "dbgHoldDevices"
            Me.dbgHoldDevices.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgHoldDevices.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgHoldDevices.PreviewInfo.ZoomFactor = 75
            Me.dbgHoldDevices.RowHeight = 20
            Me.dbgHoldDevices.Size = New System.Drawing.Size(365, 228)
            Me.dbgHoldDevices.TabIndex = 152
            Me.dbgHoldDevices.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Transparent;}Se" & _
            "lected{ForeColor:ControlText;BackColor:Yellow;}Style3{}Inactive{ForeColor:Inacti" & _
            "veCaptionText;BackColor:InactiveCaption;}FilterBar{ForeColor:Red;BackColor:Trans" & _
            "parent;}Footer{}Caption{AlignHorz:Center;ForeColor:White;BackColor:Transparent;}" & _
            "Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt;BackColor:Control;AlignVert:Cen" & _
            "ter;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddRow{B" & _
            "ackColor:Transparent;}RecordSelector{AlignImage:Center;}Style13{}Heading{Wrap:Tr" & _
            "ue;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;AlignVert:Cent" & _
            "er;Border:Raised,,1, 1, 1, 1;ForeColor:Black;BackColor:LightSteelBlue;}Style8{}S" & _
            "tyle10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style1{}</Data></Styles><Split" & _
            "s><C1.Win.C1TrueDBGrid.MergeView HBarHeight=""10"" AllowColMove=""False"" AllowColSe" & _
            "lect=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""True"" CaptionHei" & _
            "ght=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" Marqu" & _
            "eeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Vertical" & _
            "ScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>224</Height><CaptionStyle pare" & _
            "nt=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowSt" & _
            "yle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style1" & _
            "3"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""S" & _
            "tyle12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent" & _
            "=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><Od" & _
            "dRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelec" & _
            "tor"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent" & _
            "=""Normal"" me=""Style1"" /><ClientRect>0, 0, 361, 224</ClientRect><BorderSide>0</Bo" & _
            "rderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Spli" & _
            "ts><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Headin" & _
            "g"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" " & _
            "/><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /" & _
            "><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /" & _
            "><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Sty" & _
            "le parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" " & _
            "/><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><" & _
            "horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRec" & _
            "SelWidth><ClientArea>0, 0, 361, 224</ClientArea><PrintPageHeaderStyle parent="""" " & _
            "me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'dbgHoldSN
            '
            Me.dbgHoldSN.AllowColMove = False
            Me.dbgHoldSN.AllowColSelect = False
            Me.dbgHoldSN.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.dbgHoldSN.AllowUpdate = False
            Me.dbgHoldSN.AllowUpdateOnBlur = False
            Me.dbgHoldSN.AlternatingRows = True
            Me.dbgHoldSN.BackColor = System.Drawing.Color.SteelBlue
            Me.dbgHoldSN.FilterBar = True
            Me.dbgHoldSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dbgHoldSN.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgHoldSN.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.dbgHoldSN.Location = New System.Drawing.Point(13, 313)
            Me.dbgHoldSN.MaintainRowCurrency = True
            Me.dbgHoldSN.Name = "dbgHoldSN"
            Me.dbgHoldSN.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgHoldSN.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgHoldSN.PreviewInfo.ZoomFactor = 75
            Me.dbgHoldSN.RowHeight = 20
            Me.dbgHoldSN.Size = New System.Drawing.Size(555, 228)
            Me.dbgHoldSN.TabIndex = 151
            Me.dbgHoldSN.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Transparent;}Se" & _
            "lected{ForeColor:ControlText;BackColor:Yellow;}Style3{}Inactive{ForeColor:Inacti" & _
            "veCaptionText;BackColor:InactiveCaption;}FilterBar{ForeColor:Red;BackColor:Trans" & _
            "parent;}Footer{}Caption{AlignHorz:Center;ForeColor:White;BackColor:Transparent;}" & _
            "Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt;AlignVert:Center;BackColor:Cont" & _
            "rol;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style14{}OddRow{B" & _
            "ackColor:Transparent;}RecordSelector{AlignImage:Center;}Style15{}Heading{Wrap:Tr" & _
            "ue;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;BackColor:Ligh" & _
            "tSteelBlue;Border:Raised,,1, 1, 1, 1;ForeColor:Black;AlignVert:Center;}Style8{}S" & _
            "tyle10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style9{}</Data></Styles><Split" & _
            "s><C1.Win.C1TrueDBGrid.MergeView HBarHeight=""10"" AllowColMove=""False"" AllowColSe" & _
            "lect=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""True"" CaptionHei" & _
            "ght=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" Marqu" & _
            "eeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Vertical" & _
            "ScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>224</Height><CaptionStyle pare" & _
            "nt=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowSt" & _
            "yle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style1" & _
            "3"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""S" & _
            "tyle12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent" & _
            "=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><Od" & _
            "dRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelec" & _
            "tor"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent" & _
            "=""Normal"" me=""Style1"" /><ClientRect>0, 0, 551, 224</ClientRect><BorderSide>0</Bo" & _
            "rderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Spli" & _
            "ts><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Headin" & _
            "g"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" " & _
            "/><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /" & _
            "><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /" & _
            "><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Sty" & _
            "le parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" " & _
            "/><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><" & _
            "horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRec" & _
            "SelWidth><ClientArea>0, 0, 551, 224</ClientArea><PrintPageHeaderStyle parent="""" " & _
            "me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'btnReprintInvoiceRpt
            '
            Me.btnReprintInvoiceRpt.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnReprintInvoiceRpt.BackColor = System.Drawing.Color.DarkCyan
            Me.btnReprintInvoiceRpt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprintInvoiceRpt.ForeColor = System.Drawing.Color.White
            Me.btnReprintInvoiceRpt.Location = New System.Drawing.Point(800, 208)
            Me.btnReprintInvoiceRpt.Name = "btnReprintInvoiceRpt"
            Me.btnReprintInvoiceRpt.Size = New System.Drawing.Size(168, 31)
            Me.btnReprintInvoiceRpt.TabIndex = 150
            Me.btnReprintInvoiceRpt.Text = "Print Invoice Report"
            '
            'gbApproveInput
            '
            Me.gbApproveInput.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.gbApproveInput.Controls.AddRange(New System.Windows.Forms.Control() {Me.rtbIMEI, Me.btnReject, Me.btnApprove})
            Me.gbApproveInput.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbApproveInput.ForeColor = System.Drawing.Color.WhiteSmoke
            Me.gbApproveInput.Location = New System.Drawing.Point(792, 6)
            Me.gbApproveInput.Name = "gbApproveInput"
            Me.gbApproveInput.Size = New System.Drawing.Size(186, 181)
            Me.gbApproveInput.TabIndex = 149
            Me.gbApproveInput.TabStop = False
            Me.gbApproveInput.Text = "Device IMEI"
            '
            'rtbIMEI
            '
            Me.rtbIMEI.AcceptsTab = True
            Me.rtbIMEI.BackColor = System.Drawing.Color.FloralWhite
            Me.rtbIMEI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rtbIMEI.ForeColor = System.Drawing.Color.Blue
            Me.rtbIMEI.Location = New System.Drawing.Point(8, 24)
            Me.rtbIMEI.Multiline = False
            Me.rtbIMEI.Name = "rtbIMEI"
            Me.rtbIMEI.Size = New System.Drawing.Size(168, 24)
            Me.rtbIMEI.TabIndex = 151
            Me.rtbIMEI.TabStop = False
            Me.rtbIMEI.Text = ""
            Me.rtbIMEI.WordWrap = False
            '
            'btnReject
            '
            Me.btnReject.BackColor = System.Drawing.Color.Crimson
            Me.btnReject.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReject.ForeColor = System.Drawing.Color.White
            Me.btnReject.Location = New System.Drawing.Point(8, 136)
            Me.btnReject.Name = "btnReject"
            Me.btnReject.Size = New System.Drawing.Size(168, 40)
            Me.btnReject.TabIndex = 150
            Me.btnReject.Text = "Reject"
            '
            'btnApprove
            '
            Me.btnApprove.BackColor = System.Drawing.Color.Green
            Me.btnApprove.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnApprove.ForeColor = System.Drawing.Color.White
            Me.btnApprove.Location = New System.Drawing.Point(9, 80)
            Me.btnApprove.Name = "btnApprove"
            Me.btnApprove.Size = New System.Drawing.Size(168, 40)
            Me.btnApprove.TabIndex = 149
            Me.btnApprove.Text = "Approve"
            '
            'dbgHold
            '
            Me.dbgHold.AllowColMove = False
            Me.dbgHold.AllowColSelect = False
            Me.dbgHold.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.dbgHold.AllowUpdate = False
            Me.dbgHold.AllowUpdateOnBlur = False
            Me.dbgHold.AlternatingRows = True
            Me.dbgHold.BackColor = System.Drawing.Color.SteelBlue
            Me.dbgHold.FilterBar = True
            Me.dbgHold.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dbgHold.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgHold.Images.Add(CType(resources.GetObject("resource.Images5"), System.Drawing.Bitmap))
            Me.dbgHold.Location = New System.Drawing.Point(13, 10)
            Me.dbgHold.MaintainRowCurrency = True
            Me.dbgHold.Name = "dbgHold"
            Me.dbgHold.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgHold.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgHold.PreviewInfo.ZoomFactor = 75
            Me.dbgHold.RowHeight = 20
            Me.dbgHold.Size = New System.Drawing.Size(740, 229)
            Me.dbgHold.TabIndex = 141
            Me.dbgHold.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Transparent;}Se" & _
            "lected{ForeColor:ControlText;BackColor:Yellow;}Style3{}Inactive{ForeColor:Inacti" & _
            "veCaptionText;BackColor:InactiveCaption;}FilterBar{ForeColor:Red;BackColor:Trans" & _
            "parent;}Footer{}Caption{AlignHorz:Center;ForeColor:White;BackColor:Transparent;}" & _
            "Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt;BackColor:Control;AlignVert:Cen" & _
            "ter;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddRow{B" & _
            "ackColor:Transparent;}RecordSelector{AlignImage:Center;}Style13{}Heading{Wrap:Tr" & _
            "ue;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;AlignVert:Cent" & _
            "er;Border:Raised,,1, 1, 1, 1;ForeColor:Black;BackColor:LightSteelBlue;}Style8{}S" & _
            "tyle10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style1{}</Data></Styles><Split" & _
            "s><C1.Win.C1TrueDBGrid.MergeView HBarHeight=""10"" AllowColMove=""False"" AllowColSe" & _
            "lect=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""True"" CaptionHei" & _
            "ght=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" Marqu" & _
            "eeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Vertical" & _
            "ScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>225</Height><CaptionStyle pare" & _
            "nt=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowSt" & _
            "yle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style1" & _
            "3"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""S" & _
            "tyle12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent" & _
            "=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><Od" & _
            "dRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelec" & _
            "tor"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent" & _
            "=""Normal"" me=""Style1"" /><ClientRect>0, 0, 736, 225</ClientRect><BorderSide>0</Bo" & _
            "rderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Spli" & _
            "ts><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Headin" & _
            "g"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" " & _
            "/><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /" & _
            "><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /" & _
            "><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Sty" & _
            "le parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" " & _
            "/><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><" & _
            "horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRec" & _
            "SelWidth><ClientArea>0, 0, 736, 225</ClientArea><PrintPageHeaderStyle parent="""" " & _
            "me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'tpWaitingToDockShip
            '
            Me.tpWaitingToDockShip.BackColor = System.Drawing.Color.SteelBlue
            Me.tpWaitingToDockShip.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnWaitingToBePack_CopyAll, Me.dbgWaitingToBePack})
            Me.tpWaitingToDockShip.Location = New System.Drawing.Point(4, 22)
            Me.tpWaitingToDockShip.Name = "tpWaitingToDockShip"
            Me.tpWaitingToDockShip.Size = New System.Drawing.Size(992, 558)
            Me.tpWaitingToDockShip.TabIndex = 3
            Me.tpWaitingToDockShip.Text = "Waiting To Be Packed"
            '
            'btnWaitingToBePack_CopyAll
            '
            Me.btnWaitingToBePack_CopyAll.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnWaitingToBePack_CopyAll.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnWaitingToBePack_CopyAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnWaitingToBePack_CopyAll.ForeColor = System.Drawing.Color.Black
            Me.btnWaitingToBePack_CopyAll.Location = New System.Drawing.Point(864, 8)
            Me.btnWaitingToBePack_CopyAll.Name = "btnWaitingToBePack_CopyAll"
            Me.btnWaitingToBePack_CopyAll.Size = New System.Drawing.Size(112, 24)
            Me.btnWaitingToBePack_CopyAll.TabIndex = 144
            Me.btnWaitingToBePack_CopyAll.Text = "Copy All Rows"
            '
            'dbgWaitingToBePack
            '
            Me.dbgWaitingToBePack.AllowColMove = False
            Me.dbgWaitingToBePack.AllowColSelect = False
            Me.dbgWaitingToBePack.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.dbgWaitingToBePack.AllowUpdate = False
            Me.dbgWaitingToBePack.AllowUpdateOnBlur = False
            Me.dbgWaitingToBePack.AlternatingRows = True
            Me.dbgWaitingToBePack.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgWaitingToBePack.BackColor = System.Drawing.Color.SteelBlue
            Me.dbgWaitingToBePack.Caption = "Waiting To Be Pack"
            Me.dbgWaitingToBePack.FilterBar = True
            Me.dbgWaitingToBePack.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dbgWaitingToBePack.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgWaitingToBePack.Images.Add(CType(resources.GetObject("resource.Images6"), System.Drawing.Bitmap))
            Me.dbgWaitingToBePack.Location = New System.Drawing.Point(8, 40)
            Me.dbgWaitingToBePack.MaintainRowCurrency = True
            Me.dbgWaitingToBePack.Name = "dbgWaitingToBePack"
            Me.dbgWaitingToBePack.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgWaitingToBePack.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgWaitingToBePack.PreviewInfo.ZoomFactor = 75
            Me.dbgWaitingToBePack.RowHeight = 20
            Me.dbgWaitingToBePack.Size = New System.Drawing.Size(968, 496)
            Me.dbgWaitingToBePack.TabIndex = 142
            Me.dbgWaitingToBePack.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Transparent;}Se" & _
            "lected{ForeColor:ControlText;BackColor:Yellow;}Style3{}Inactive{ForeColor:Inacti" & _
            "veCaptionText;BackColor:InactiveCaption;}FilterBar{ForeColor:Red;BackColor:Trans" & _
            "parent;}Footer{}Caption{AlignHorz:Center;ForeColor:White;BackColor:SteelBlue;}St" & _
            "yle1{}Normal{Font:Microsoft Sans Serif, 8.25pt;AlignVert:Center;BackColor:Contro" & _
            "l;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style14{}OddRow{Bac" & _
            "kColor:Transparent;}RecordSelector{AlignImage:Center;}Style15{}Heading{Wrap:True" & _
            ";Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;BackColor:LightS" & _
            "teelBlue;Border:Raised,,1, 1, 1, 1;ForeColor:Black;AlignVert:Center;}Style8{}Sty" & _
            "le10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style9{}</Data></Styles><Splits>" & _
            "<C1.Win.C1TrueDBGrid.MergeView HBarHeight=""10"" AllowColMove=""False"" AllowColSele" & _
            "ct=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""True"" CaptionHeigh" & _
            "t=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" Marquee" & _
            "Style=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalSc" & _
            "rollGroup=""1"" HorizontalScrollGroup=""1""><Height>475</Height><CaptionStyle parent" & _
            "=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyl" & _
            "e parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13""" & _
            " /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Sty" & _
            "le12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""" & _
            "HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddR" & _
            "owStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelecto" & _
            "r"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""" & _
            "Normal"" me=""Style1"" /><ClientRect>0, 17, 964, 475</ClientRect><BorderSide>0</Bor" & _
            "derSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Split" & _
            "s><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading" & _
            """ /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /" & _
            "><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" />" & _
            "<Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" />" & _
            "<Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Styl" & _
            "e parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /" & _
            "><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><h" & _
            "orzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecS" & _
            "elWidth><ClientArea>0, 0, 964, 492</ClientArea><PrintPageHeaderStyle parent="""" m" & _
            "e=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'frmCustServices
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(1016, 614)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tcCustomerServices})
            Me.Name = "frmCustServices"
            Me.Text = "frmCustServices"
            Me.tcCustomerServices.ResumeLayout(False)
            Me.tpgApproved.ResumeLayout(False)
            CType(Me.dbgApprovedDevices, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dbgApprovedSN, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dbgApproved, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpgHold.ResumeLayout(False)
            CType(Me.dbgHoldDevices, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dbgHoldSN, System.ComponentModel.ISupportInitialize).EndInit()
            Me.gbApproveInput.ResumeLayout(False)
            CType(Me.dbgHold, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpWaitingToDockShip.ResumeLayout(False)
            CType(Me.dbgWaitingToBePack, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '*************************************************************************************************************
        Private Sub frmCustServices_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                PSS.Core.Highlight.SetHighLight(Me)

                Me._dsApproved = New DataSet()
                Me._dsHold = New DataSet()

                Me._objPTCustService.UpdatePartsCost()

                Me.dtpApprovedStart.Value = DateTime.Now.AddDays(-7)
                Me.dtpApprovedEnd.Value = DateTime.Now

                Me.SetScrollState(ScrollableControl.ScrollStateAutoScrolling, True)

                Me.Controls.AddRange(New System.Windows.Forms.Control() {Me._txtApprovedTNEditor, Me._txtHoldTNEditor, Me._lstShipTypes})
                Me._txtApprovedTNEditor.Visible = False
                Me._txtApprovedTNEditor.BackColor = Color.LightYellow
                Me._txtApprovedTNEditor.ForeColor = Color.Purple
                Me._txtApprovedTNEditor.CharacterCasing = CharacterCasing.Upper
                Me._txtHoldTNEditor.Visible = False
                Me._txtHoldTNEditor.BackColor = Me._txtApprovedTNEditor.BackColor
                Me._txtHoldTNEditor.ForeColor = Me._txtApprovedTNEditor.ForeColor
                Me._txtHoldTNEditor.CharacterCasing = Me._txtApprovedTNEditor.CharacterCasing
                Me._lstShipTypes.BackColor = Me._txtApprovedTNEditor.BackColor
                Me._lstShipTypes.ForeColor = Me._txtApprovedTNEditor.ForeColor

                SetupShipTypes()

                Me._bLoading = False
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmCustServices_Load", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub tpgApproved_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tpgHold.VisibleChanged, tpWaitingToDockShip.VisibleChanged, tpgApproved.VisibleChanged
            Try
                If sender.Name = "tpgApproved" Then
                    If Me.tpgApproved.Visible = True Then Me.PopulateApprovedUnitsGrid()
                ElseIf sender.Name = "tpgHold" Then
                    If Me.tpgHold.Visible = True Then Me.PopulateHoldUnitsGrid()
                ElseIf sender.Name = "tpWaitingToDockShip" Then
                    If Me.tpWaitingToDockShip.Visible = True Then Me.PopulateWaitingToBeDockShipGrid()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "tpgs_VisibleChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub PopulateApprovedUnitsGrid()
            Dim dt As DataTable
            Dim i As Integer
            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                Misc.InitializeC1DBGrid(Me.dbgApproved)
                Misc.InitializeC1DBGrid(Me.dbgApprovedDevices)
                Misc.InitializeC1DBGrid(Me.dbgApprovedSN)

                If (Me.dtpApprovedStart.Value > Me.dtpApprovedEnd.Value) Then
                    MessageBox.Show("The end date cannot precede the start date.", "Date Range Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    Return
                End If

                Me._dsApproved = Me._objPTCustService.GetApprovedUnits(Me._iLocID, Me.dtpApprovedStart.Value.ToString("yyyy-MM-dd"), Me.dtpApprovedEnd.Value.ToString("yyyy-MM-dd"))
                dt = Me._dsApproved.Tables("Approved RMAs")

                With Me.dbgApproved
                    .DataSource = Nothing
                    .DataSource = dt.DefaultView

                    .Caption = String.Format("RMAs Approved from {0:MMMM d, yyyy} to {1:MMMM d, yyyy}", Me.dtpApprovedStart.Value, Me.dtpApprovedEnd.Value)

                    For i = 0 To dt.Columns.Count - 1
                        .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                        .Splits(0).DisplayColumns(i).AutoSize()
                    Next i

                    .MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None

                    .Splits(0).DisplayColumns("wo_id").Visible = False

                    .Splits(0).DisplayColumns("RMA").Frozen = True

                    .Columns("Total Labor Charge").NumberFormat = "C2"
                    .Splits(0).DisplayColumns("Total Labor Charge").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                    .Columns("Total Parts Charge").NumberFormat = "C2"
                    .Splits(0).DisplayColumns("Total Parts Charge").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                    .Columns("Total Tax on Parts").NumberFormat = "C2"
                    .Splits(0).DisplayColumns("Total Tax on Parts").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far

                    Dim styYes As New C1.Win.C1TrueDBGrid.Style()
                    Dim fntStyYes As New Font(styYes.Font, FontStyle.Bold)

                    styYes.Font = fntStyYes
                    styYes.ForeColor = Color.Green

                    .AddRegexCellStyle(C1.Win.C1TrueDBGrid.CellStyleFlag.AllCells, styYes, "Yes")

                    Dim styNo As New C1.Win.C1TrueDBGrid.Style()
                    Dim fntStyNo As New Font(styNo.Font, FontStyle.Bold)

                    styNo.Font = fntStyNo
                    styNo.ForeColor = Color.Red

                    .AddRegexCellStyle(C1.Win.C1TrueDBGrid.CellStyleFlag.AllCells, styNo, "No")

                    .Columns("Total Labor Charge").NumberFormat = "C2"
                    .Splits(0).DisplayColumns("Total Labor Charge").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                    .Columns("Total Parts Charge").NumberFormat = "C2"
                    .Splits(0).DisplayColumns("Total Parts Charge").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                    .Columns("Total Tax on Parts").NumberFormat = "C2"
                    .Splits(0).DisplayColumns("Total Tax on Parts").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far

                    .FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far

                    .Columns("RMA").FooterText = "Total Charges"
                    .Columns("Total Labor Charge").FooterText = String.Format("{0:C2}", Misc.SumRowValues(Me.dbgApproved, "Total Labor Charge"))
                    .Columns("Total Parts Charge").FooterText = String.Format("{0:C2}", Misc.SumRowValues(Me.dbgApproved, "Total Parts Charge"))
                    .Columns("Total Tax on Parts").FooterText = String.Format("{0:C2}", Misc.SumRowValues(Me.dbgApproved, "Total Tax on Parts"))

                    .Splits(0).DisplayColumns("RMA").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                End With

                Misc.SetGridStyles(Me.dbgApproved, True)
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub PopulateHoldUnitsGrid()
            Dim dt As DataTable
            Dim i As Integer

            Try
                Misc.InitializeC1DBGrid(Me.dbgHold)
                Misc.InitializeC1DBGrid(Me.dbgHoldSN)
                Misc.InitializeC1DBGrid(Me.dbgHoldDevices)

                Me._dsHold = Me._objPTCustService.GetHoldUnits(Me._iLocID)
                dt = Me._dsHold.Tables("Hold Work Orders")

                With Me.dbgHold
                    .DataSource = Nothing
                    .DataSource = dt.DefaultView

                    .Caption = "RMAs On Hold"

                    For i = 0 To dt.Columns.Count - 1
                        .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                        .Splits(0).DisplayColumns(i).AutoSize()
                    Next i

                    .MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None

                    .Splits(0).DisplayColumns("wo_id").Visible = False

                    .Splits(0).DisplayColumns("wo_id").Frozen = True
                    .Splits(0).DisplayColumns("RMA").Frozen = True

                    .Columns("Total Labor Charge").NumberFormat = "C2"
                    .Splits(0).DisplayColumns("Total Labor Charge").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far

                    Dim styYes As New C1.Win.C1TrueDBGrid.Style()
                    Dim fntStyYes As New Font(styYes.Font, FontStyle.Bold)

                    styYes.Font = fntStyYes
                    styYes.ForeColor = Color.Green

                    .AddRegexCellStyle(C1.Win.C1TrueDBGrid.CellStyleFlag.AllCells, styYes, "Yes")

                    Dim styNo As New C1.Win.C1TrueDBGrid.Style()
                    Dim fntStyNo As New Font(styNo.Font, FontStyle.Bold)

                    styNo.Font = fntStyNo
                    styNo.ForeColor = Color.Red

                    .AddRegexCellStyle(C1.Win.C1TrueDBGrid.CellStyleFlag.AllCells, styNo, "No")

                    .Columns("Total Labor Charge").NumberFormat = "C2"
                    .Splits(0).DisplayColumns("Total Labor Charge").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far

                    '.FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far

                    '.Columns("RMA").FooterText = "Total Charges All Hold Units"
                    '.Columns("Total Labor Charge").FooterText = String.Format("{0:C2}", Misc.SumRowValues(Me.dbgHold, "Total Labor Charge"))

                    '.Splits(0).DisplayColumns("RMA").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                End With

                Misc.SetGridStyles(Me.dbgHold, False)
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub PopulateWaitingToBeDockShipGrid()
            Dim dt As DataTable
            Dim i As Integer

            Try
                dt = Me._objPTCustService.GetWaitingToBeDockShipRMA(Me._iLocID)

                With Me.dbgWaitingToBePack
                    .DataSource = Nothing
                    .DataSource = dt.DefaultView

                    For i = 0 To dt.Columns.Count - 1
                        .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near

                        If dt.Columns(i).Caption.EndsWith("RMA") Then .Splits(0).DisplayColumns(i).Width = 130
                    Next i

                End With
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub btnReprintInvoiceRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintInvoiceRpt.Click
            Dim strRMA As String = String.Empty
            Dim dtWOInfo As DataTable

            Try
                strRMA = InputBox("Enter RMA#:", "RMA#", Me.rtbIMEI.Text.Trim).Trim

                If strRMA.Equals(String.Empty) Then
                    Exit Sub
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                    dtWOInfo = Me._objPTCustService.GetPantechWOInfo(strRMA, Me._iLocID)

                    If dtWOInfo.Rows.Count = 0 Then
                        MessageBox.Show(String.Format("RMA {0} does not exist in the system.", strRMA), "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)

                    ElseIf dtWOInfo.Rows.Count > 1 Then
                        MessageBox.Show(String.Format("RMA {0} exists more than once in the system.  Please contact IT.", strRMA), "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)

                    ElseIf Convert.ToInt32(dtWOInfo.Rows(0)("WO_Closed")) = 0 Then
                        MessageBox.Show(String.Format("RMA {0} still open.", strRMA), "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)

                    Else
                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                        Me._objPTCustService.PrintInvoiceReceiptData(Convert.ToInt32(dtWOInfo.Rows(0)("WO_ID")))
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnReprintInvoiceRpt_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dtWOInfo)
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub btnCopyAllRows_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyAllRows.Click
            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                Misc.CopyAllData(Me.dbgApproved)
            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "CopyData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub btnWaitingToBePack_CopyAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWaitingToBePack_CopyAll.Click
            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                Misc.CopyAllData(Me.dbgWaitingToBePack)
            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "CopyData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '*************************************************************************************************************

        Private Sub dbgHold_SelChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles dbgHold.SelChange
            Try
                Me._bLoading = True

                Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = DirectCast(sender, C1.Win.C1TrueDBGrid.C1TrueDBGrid)

                Me.rtbIMEI.Text = String.Empty

                Misc.InitializeC1DBGrid(Me.dbgHoldSN)
                Misc.InitializeC1DBGrid(Me.dbgHoldDevices)

                Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn

                If dbg.SelectedRows.Count > 0 Then
                    If dbg.SelectedRows(0) > -1 Then
                        'Me.rtbIMEI.Text = Convert.ToString(dbg.Columns("RMA").CellValue(dbg.SelectedRows(0)))

                        Dim dbgr As System.Data.DataRowView = dbg.Item(dbg.SelectedRows(0))
                        Dim drel As DataRelation = Me._dsHold.Relations("Hold RMAs to Devices")
                        Dim drDevice() As DataRow = Me._dsHold.Tables("Hold Work Orders").Select(String.Format("wo_id = {0}", dbgr("wo_id").ToString))
                        Dim dpc As C1.Win.C1TrueDBGrid.C1DisplayColumn

                        If drDevice.Length > 0 Then
                            Dim drIMEI() As DataRow = drDevice(0).GetChildRows(drel)

                            If drIMEI.Length > 0 Then
                                With Me.dbgHoldSN
                                    .DataSource = Nothing
                                    .DataSource = Misc.InsertDataRowsIntoDataTable(drIMEI, Me._dsHold.Tables("Hold RMA Devices")).DefaultView

                                    Me._dbgCurrentSN = Me.dbgHoldSN

                                    .Caption = String.Format("Devices for RMA {0}", drDevice(0)("RMA"))

                                    .Splits(0).DisplayColumns("IMEI").Frozen = True

                                    .Splits(0).DisplayColumns("wo_id").Visible = False
                                    .Splits(0).DisplayColumns("device_id").Visible = False
                                    .Splits(0).DisplayColumns("model_id").Visible = False
                                    .Splits(0).DisplayColumns("ship_id").Visible = False
                                    .Splits(0).DisplayColumns("ShipTypeID").Visible = False
                                    .Splits(0).DisplayColumns("Original Tracking Number").Visible = False

                                    Dim styYes As New C1.Win.C1TrueDBGrid.Style()
                                    Dim fntStyYes As New Font(styYes.Font, FontStyle.Bold)

                                    styYes.Font = fntStyYes
                                    styYes.ForeColor = Color.Green

                                    .AddRegexCellStyle(C1.Win.C1TrueDBGrid.CellStyleFlag.AllCells, styYes, "Yes")

                                    Dim styNo As New C1.Win.C1TrueDBGrid.Style()
                                    Dim fntStyNo As New Font(styNo.Font, FontStyle.Bold)

                                    styNo.Font = fntStyNo
                                    styNo.ForeColor = Color.Red

                                    .AddRegexCellStyle(C1.Win.C1TrueDBGrid.CellStyleFlag.AllCells, styNo, "No")

                                    .Columns("Labor Charge").NumberFormat = "C2"
                                    .Splits(0).DisplayColumns("Labor Charge").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far

                                    .FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far

                                    .Columns("SN").FooterText = "Total Charges"
                                    .Columns("Labor Charge").FooterText = String.Format("{0:C2}", Misc.SumRowValues(Me.dbgHoldSN, "Labor Charge"))

                                    .Splits(0).DisplayColumns("Model").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near

                                    Dim styUnassigned As New C1.Win.C1TrueDBGrid.Style()
                                    Dim fntStyUnassigned As New Font(styUnassigned.Font, FontStyle.Bold)

                                    styUnassigned.Font = fntStyUnassigned
                                    styUnassigned.ForeColor = Color.Red

                                    .AddRegexCellStyle(C1.Win.C1TrueDBGrid.CellStyleFlag.AllCells, styUnassigned, "Unassigned")

                                    Dim styOther As New C1.Win.C1TrueDBGrid.Style()
                                    Dim fntStyOther As New Font(styOther.Font, FontStyle.Bold)

                                    styOther.Font = fntStyUnassigned
                                    styOther.ForeColor = Color.Crimson

                                    .AddRegexCellStyle(C1.Win.C1TrueDBGrid.CellStyleFlag.AllCells, styOther, "Other")

                                    'Allow editing of Ship Type and Tracking Number but no other columns
                                    .AllowUpdate = True

                                    For Each dpc In .Splits(0).DisplayColumns : dpc.Locked = True : Next dpc

                                    .Splits(0).DisplayColumns("Ship Type").Locked = False
                                    .Splits(0).DisplayColumns("Tracking Number").Locked = False

                                    .Columns("Tracking Number").Editor = Me._txtApprovedTNEditor

                                    Me._lstShipTypes.SelectedIndex = -1

                                    .Columns("Ship Type").Editor = Me._lstShipTypes

                                    .RowHeight = 50
                                End With

                                Misc.SetGridStyles(Me.dbgHoldSN, True)
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgHold_SelChange", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me._bLoading = False
            End Try
        End Sub

        Private Sub dtpApprovedStart_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpApprovedStart.ValueChanged
            Try
                PopulateApprovedUnitsGrid()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dtpApprovedStart_ValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub dtpApprovedEnd_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpApprovedEnd.ValueChanged
            Try
                PopulateApprovedUnitsGrid()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dtpApprovedEnd_ValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub dbgApproved_SelChange(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles dbgApproved.SelChange
            Try
                Me._bLoading = True

                Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = DirectCast(sender, C1.Win.C1TrueDBGrid.C1TrueDBGrid)

                Misc.InitializeC1DBGrid(Me.dbgApprovedSN)
                Misc.InitializeC1DBGrid(Me.dbgApprovedDevices)

                If dbg.SelectedRows.Count > 0 Then
                    If dbg.SelectedRows(0) > -1 Then
                        Dim dbgr As System.Data.DataRowView = dbg.Item(dbg.SelectedRows(0))
                        Dim drel As DataRelation = Me._dsApproved.Relations("Approved RMAs to Devices")
                        Dim drApproved() As DataRow = Me._dsApproved.Tables("Approved RMAs").Select(String.Format("wo_id = {0}", dbgr("wo_id").ToString))
                        Dim dpc As C1.Win.C1TrueDBGrid.C1DisplayColumn

                        If drApproved.Length > 0 Then
                            Dim drDevices() As DataRow = drApproved(0).GetChildRows(drel)

                            If drDevices.Length > 0 Then
                                With Me.dbgApprovedSN
                                    .DataSource = Nothing
                                    .DataSource = Misc.InsertDataRowsIntoDataTable(drDevices, Me._dsApproved.Tables("Approved RMA Devices")).DefaultView

                                    Me._dbgCurrentSN = Me.dbgApprovedSN

                                    .Caption = String.Format("Devices for RMA {0}", drApproved(0)("RMA"))

                                    .Splits(0).DisplayColumns("IMEI").Frozen = True

                                    .Splits(0).DisplayColumns("wo_id").Visible = False
                                    .Splits(0).DisplayColumns("device_id").Visible = False
                                    .Splits(0).DisplayColumns("ship_id").Visible = False
                                    .Splits(0).DisplayColumns("ShipTypeID").Visible = False
                                    .Splits(0).DisplayColumns("Original Tracking Number").Visible = False

                                    .Columns("Labor Charge").NumberFormat = "C2"
                                    .Splits(0).DisplayColumns("Labor Charge").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                                    .Columns("Parts Charge").NumberFormat = "C2"
                                    .Splits(0).DisplayColumns("Parts Charge").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                                    .Columns("Tax on Parts").NumberFormat = "C2"
                                    .Splits(0).DisplayColumns("Tax on Parts").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far

                                    .FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far

                                    .Columns("Model").FooterText = "Total Charges"
                                    .Columns("Labor Charge").FooterText = String.Format("{0:C2}", Misc.SumRowValues(Me.dbgApprovedSN, "Labor Charge"))
                                    .Columns("Parts Charge").FooterText = String.Format("{0:C2}", Misc.SumRowValues(Me.dbgApprovedSN, "Parts Charge"))
                                    .Columns("Tax on Parts").FooterText = String.Format("{0:C2}", Misc.SumRowValues(Me.dbgApprovedSN, "Tax on Parts"))

                                    .Splits(0).DisplayColumns("Model").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near

                                    Dim styUnassigned As New C1.Win.C1TrueDBGrid.Style()
                                    Dim fntStyUnassigned As New Font(styUnassigned.Font, FontStyle.Bold)

                                    styUnassigned.Font = fntStyUnassigned
                                    styUnassigned.ForeColor = Color.Red

                                    .AddRegexCellStyle(C1.Win.C1TrueDBGrid.CellStyleFlag.AllCells, styUnassigned, "Unassigned")

                                    Dim styOther As New C1.Win.C1TrueDBGrid.Style()
                                    Dim fntStyOther As New Font(styOther.Font, FontStyle.Bold)

                                    styOther.Font = fntStyUnassigned
                                    styOther.ForeColor = Color.Crimson

                                    .AddRegexCellStyle(C1.Win.C1TrueDBGrid.CellStyleFlag.AllCells, styOther, "Other")

                                    'Allow editing of Ship Type and Tracking Number but no other columns
                                    .AllowUpdate = True

                                    For Each dpc In .Splits(0).DisplayColumns : dpc.Locked = True : Next dpc

                                    .Splits(0).DisplayColumns("Ship Type").Locked = False
                                    .Splits(0).DisplayColumns("Tracking Number").Locked = False

                                    .Columns("Tracking Number").Editor = Me._txtApprovedTNEditor

                                    Me._lstShipTypes.SelectedIndex = -1

                                    .Columns("Ship Type").Editor = Me._lstShipTypes

                                    .RowHeight = 50
                                End With

                                Misc.SetGridStyles(Me.dbgApprovedSN, True)
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgApproved_SelChange", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me._bLoading = False
            End Try
        End Sub

        Private Sub dbgApprovedSN_SelChange(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles dbgApprovedSN.SelChange
            Try
                Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = DirectCast(sender, C1.Win.C1TrueDBGrid.C1TrueDBGrid)

                Misc.InitializeC1DBGrid(Me.dbgApprovedDevices)

                If dbg.SelectedRows.Count > 0 Then
                    If dbg.SelectedRows(0) > -1 Then
                        Dim dbgr As System.Data.DataRowView = dbg.Item(dbg.SelectedRows(0))
                        Dim drel As DataRelation = Me._dsApproved.Relations("Approved Devices to Parts")
                        Dim drRMA() As DataRow = Me._dsApproved.Tables("Approved RMA Devices").Select(String.Format("wo_id = {0}", dbgr("wo_id").ToString))

                        If drRMA.Length > 0 Then
                            Dim drIMEI() As DataRow = drRMA(0).GetChildRows(drel)

                            If drIMEI.Length > 0 Then
                                With Me.dbgApprovedDevices
                                    .DataSource = Nothing
                                    .DataSource = Misc.InsertDataRowsIntoDataTable(drIMEI, Me._dsApproved.Tables("Approved Device Parts")).DefaultView

                                    .Caption = String.Format("Parts for IMEI {0}", drRMA(0)("IMEI"))

                                    .Splits(0).DisplayColumns("Part").Frozen = True

                                    .Splits(0).DisplayColumns("device_id").Visible = False
                                    .Splits(0).DisplayColumns("billcode_id").Visible = False

                                    .Columns("Part Charge").NumberFormat = "C2"
                                    .Columns("Tax on Part").NumberFormat = "C2"

                                    .Columns("Part").FooterText = "Total Charges"
                                    .Columns("Part Charge").FooterText = String.Format("{0:C2}", Misc.SumRowValues(Me.dbgApprovedDevices, "Part Charge"))
                                    .Columns("Tax on Part").FooterText = String.Format("{0:C2}", Misc.SumRowValues(Me.dbgApprovedDevices, "Tax on Part"))

                                    .Splits(0).DisplayColumns("Part").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                                    .Splits(0).DisplayColumns("Part Charge").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                                    .Splits(0).DisplayColumns("Tax on Part").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                                End With

                                Misc.SetGridStyles(Me.dbgApprovedDevices, True)
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgApprovedSN_SelChange", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub dbgHoldSN_SelChange(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles dbgHoldSN.SelChange
            Try
                Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = DirectCast(sender, C1.Win.C1TrueDBGrid.C1TrueDBGrid)

                If dbg.SelectedRows.Count = 0 Then Return

                Me.rtbIMEI.Text = Convert.ToString(dbg.Columns("IMEI").CellValue(dbg.SelectedRows(0)))

                Misc.InitializeC1DBGrid(Me.dbgHoldDevices)

                If dbg.SelectedRows.Count > 0 Then
                    If dbg.SelectedRows(0) > -1 Then
                        Dim dbgr As System.Data.DataRowView = dbg.Item(dbg.SelectedRows(0))
                        Dim drel As DataRelation = Me._dsHold.Relations("Hold Devices to Parts")
                        Dim drRMA() As DataRow = Me._dsHold.Tables("Hold RMA Devices").Select(String.Format("wo_id = {0}", dbgr("wo_id").ToString))

                        If drRMA.Length > 0 Then
                            Dim drParts() As DataRow = drRMA(0).GetChildRows(drel)

                            If drParts.Length > 0 Then
                                With Me.dbgHoldDevices
                                    .DataSource = Nothing
                                    .DataSource = Misc.InsertDataRowsIntoDataTable(drParts, Me._dsHold.Tables("Hold Device Parts")).DefaultView

                                    .Caption = String.Format("Parts for IMEI {0}", drRMA(0)("IMEI"))

                                    .Splits(0).DisplayColumns("Part").Frozen = True

                                    .Splits(0).DisplayColumns("device_id").Visible = False
                                    .Splits(0).DisplayColumns("billcode_id").Visible = False

                                    .Columns("Part Charge").NumberFormat = "C2"
                                    .Columns("Tax on Part").NumberFormat = "C2"

                                    .Columns("Part").FooterText = "Total Charges"
                                    .Columns("Part Charge").FooterText = String.Format("{0:C2}", Misc.SumRowValues(Me.dbgHoldDevices, "Part Charge"))
                                    .Columns("Tax on Part").FooterText = String.Format("{0:C2}", Misc.SumRowValues(Me.dbgHoldDevices, "Tax on Part"))

                                    .Splits(0).DisplayColumns("Part").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                                    .Splits(0).DisplayColumns("Part Charge").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                                    .Splits(0).DisplayColumns("Tax on Part").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far

                                    Dim styNoPartsNA As New C1.Win.C1TrueDBGrid.Style()
                                    Dim fntStyNoPartsNA As New Font(styNoPartsNA.Font, FontStyle.Bold)

                                    styNoPartsNA.Font = fntStyNoPartsNA
                                    styNoPartsNA.ForeColor = Color.Purple

                                    .AddRegexCellStyle(C1.Win.C1TrueDBGrid.CellStyleFlag.AllCells, styNoPartsNA, "No Parts")
                                    .AddRegexCellStyle(C1.Win.C1TrueDBGrid.CellStyleFlag.AllCells, styNoPartsNA, "N/A")

                                    'Dim styZeroPartCharge As New C1.Win.C1TrueDBGrid.Style()
                                    'Dim fntZeroPartCharge As New Font(styZeroPartCharge.Font, FontStyle.Bold)

                                    'styZeroPartCharge.Font = fntZeroPartCharge
                                    'styZeroPartCharge.BackColor = Color.Goldenrod
                                    'styZeroPartCharge.ForeColor = Color.Red

                                    '.AddRegexCellStyle(C1.Win.C1TrueDBGrid.CellStyleFlag.AllCells, styZeroPartCharge, "0.00")
                                End With

                                Misc.SetGridStyles(Me.dbgHoldDevices, True)
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgHoldSN_SelChange", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Function CheckPartsAssignedAndRefurbCompleted(ByVal strIMEI As String, ByVal strRefurbCompleted As String)
            Dim strCheck As String = String.Empty

            Try
                Dim strTemp As String = String.Empty
                Dim iIndex As Integer = 0

                If strRefurbCompleted.Equals("No") Then strTemp &= "Refurb not completed."

                If strTemp.Length > 0 Then
                    iIndex += 1
                    strTemp = String.Format("{0}({1}) {2}", Chr(9), iIndex, strTemp)
                    strCheck &= strTemp
                End If

                If strCheck.Length > 0 Then strCheck = String.Format("IMEI {0} cannot be approved for the following reason(s):{1}{2}{3}", strIMEI, Chr(13), Chr(10), strCheck)

                Return strCheck
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Private Sub btnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove.Click
            Try
                Me.Cursor = Cursors.WaitCursor : Me.Enabled = False

                If Me.rtbIMEI.Text.Trim.Length = 0 Then
                    MessageBox.Show("You must select a device to approve.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Else
                    Dim strIMEI As String = Me.rtbIMEI.Text.Trim.ToUpper()

                    If Not CheckDeviceValidity(strIMEI) Then Exit Sub

                    If MessageBox.Show(String.Format("Approve device with IMEI {0}?", strIMEI), "Approve", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                        If Not CheckOnHoldIMEI(strIMEI, 1) Then Return

                        Dim iDeviceID As Integer = 0
                        Dim iModelID As Integer = 0
                        Dim strModel As String = String.Empty
                        Dim strRefurbCompleted As String = String.Empty

                        If Me.dbgHoldSN.SelectedRows.Count > 0 Then
                            Dim drv As DataRowView = Me.dbgHoldSN.Item(Me.dbgHoldSN.SelectedRows(0))

                            iDeviceID = Convert.ToInt32(drv("device_id"))
                            iModelID = Convert.ToInt32(drv("model_id"))
                            strModel = drv("Model").ToString()
                            strRefurbCompleted = drv("Refurb Completed?").ToString()
                        Else
                            Dim dr As DataRow = Me._objPTCustService.GetDeviceData(strIMEI)

                            If (Not IsNothing(dr)) Then
                                iDeviceID = Convert.ToInt32(dr("device_id"))
                                iModelID = Convert.ToInt32(dr("model_id"))
                                strModel = dr("Model").ToString()
                                strRefurbCompleted = dr("Refurb Completed?").ToString()
                            End If
                        End If

                        If iDeviceID = 0 Or iModelID = 0 Or strModel.Equals(String.Empty) Or strRefurbCompleted.Equals(String.Empty) Then
                            MessageBox.Show("Unable to retrieve model data for this IMEI.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Else
                            If Not CheckForZeroPartCharge(iDeviceID) Then Return

                            If Not CheckOnHoldIMEI(strIMEI, 1) Then Return

                            Dim strCheck As String = CheckPartsAssignedAndRefurbCompleted(strIMEI, strRefurbCompleted)

                            If strCheck.Length > 0 Then
                                MessageBox.Show(strCheck, "IMEI Validation", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                                Return
                            End If

                            ApproveOrRejectRMAUnits(iDeviceID, 1, strIMEI)

                            Me._objPTCustService.PrintInvoiceReceiptData(iDeviceID)
                            Me.rtbIMEI.Text = String.Empty : Me.PopulateHoldUnitsGrid() : Me.PopulateApprovedUnitsGrid()
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnApprove_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Me.Cursor = Cursors.Default
            End Try
        End Sub

        Private Function CheckForZeroPartCharge(ByVal iDeviceID As Integer) As Boolean
            Try
                Dim bCheckForZeroPartCharge As Boolean = True
                Dim i As Integer
                Dim j As Integer = 0
                Dim strErr As String = String.Empty
                Dim drParts As DataRow() = Me._dsHold.Tables("Hold Device Parts").Select(String.Format("device_id = {0}", iDeviceID))

                For i = 0 To drParts.Length - 1
                    If Convert.ToDecimal(drParts(i)("Part Charge")) = 0 And Not (drParts(i)("Part").ToString().ToLower().Equals("no parts") Or drParts(i)("Bill Code").ToString().ToLower().Equals("no parts")) Then
                        j += 1
                        strErr &= String.Format(vbNewLine & vbTab & "{0}. {1} ({2}).", j, drParts(i)("Part"), drParts(i)("Bill Code"))
                    End If
                Next i

                If strErr.Length > 0 Then
                    strErr = String.Format("The following part{0} zero associated charge.  The device cannot be approved until all parts have non-zero charge.", IIf(j = 1, " has", "s have")) & strErr
                    MessageBox.Show(strErr, "Invalid Part Charge", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    bCheckForZeroPartCharge = False
                End If

                Return bCheckForZeroPartCharge
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Private Sub btnReject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReject.Click
            Try
                Me.Cursor = Cursors.WaitCursor : Me.Enabled = False

                If Me.rtbIMEI.Text.Trim.Length = 0 Then
                    MessageBox.Show("You must select a device to reject.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Else
                    Dim strIMEI As String = Me.rtbIMEI.Text.Trim.ToUpper()

                    If Not CheckDeviceValidity(strIMEI) Then Exit Sub

                    If MessageBox.Show(String.Format("Reject device with IMEI {0}?", strIMEI), "Reject", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                        If Not CheckOnHoldIMEI(strIMEI, 1) Then Return

                        Dim iDeviceID As Integer = 0
                        Dim iModelID As Integer = 0
                        Dim strModel As String = String.Empty

                        If Me.dbgHoldSN.SelectedRows.Count > 0 Then
                            Dim drv As DataRowView = Me.dbgHoldSN.Item(Me.dbgHoldSN.SelectedRows(0))

                            iDeviceID = Convert.ToInt32(drv("device_id"))
                            iModelID = Convert.ToInt32(drv("model_id"))
                            strModel = drv("Model").ToString()
                        Else
                            Dim dr As DataRow = Me._objPTCustService.GetDeviceData(strIMEI)

                            If (Not IsNothing(dr)) Then
                                iDeviceID = Convert.ToInt32(dr("device_id"))
                                iModelID = Convert.ToInt32(dr("model_id"))
                                strModel = dr("Model").ToString()
                            End If
                        End If

                        If iDeviceID = 0 Or iModelID = 0 Or strModel.Equals(String.Empty) Then
                            MessageBox.Show("Unable to retrieve model data for this IMEI.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Else
                            If UpdateReject(iDeviceID, iModelID, strModel) Then
                                ApproveOrRejectRMAUnits(iDeviceID, 0, strIMEI)

                                Me.rtbIMEI.Text = String.Empty : Me.PopulateHoldUnitsGrid()
                            End If
                        End If
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnReject_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Me.Cursor = Cursors.Default
            End Try
        End Sub

        Private Function CheckOnHoldIMEI(ByVal strIMEI As String, ByVal iApprovedToRep As Integer) As Boolean
            Dim dt As DataTable = Nothing
            Dim dtApprovalData As DataTable = Nothing
            Dim bCheckRMA As Boolean = True

            Try
                dt = Generic.GetDeviceInfoInWIP(strIMEI, Me._iCustID, Me._iLocID)

                If dt.Rows.Count = 0 Then
                    MessageBox.Show(String.Format("IMEI {0} does not exist in the system.", strIMEI), "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    bCheckRMA = False

                ElseIf dt.Rows.Count > 1 Then
                    MessageBox.Show(String.Format("There is more than one record for IMEI {0} in the system. Please contact IT.", strIMEI), "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    bCheckRMA = False
                End If

                Return bCheckRMA
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
                Generic.DisposeDT(dtApprovalData)
            End Try
        End Function

        Private Sub ApproveOrRejectRMAUnits(ByVal iDeviceID As Integer, ByVal iApproveOrReject As Integer, ByVal strIMEI As String)
            Try
                Dim i As Integer = Me._objPTCustService.SetApproveToRepairData(iDeviceID, PSS.Core.ApplicationUser.IDuser, iApproveOrReject, Me._iOWRejectRepair)

                If i = 0 Then
                    Throw New Exception(String.Format("System has failed to update the approval status for IMEI {0}.", strIMEI))
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Protected Overrides Sub Finalize()
            Me._bClosing = True

            Generic.DisposeDS(Me._dsApproved)
            Generic.DisposeDS(Me._dsHold)

            MyBase.Finalize()
        End Sub

        Private Sub tcCustomerServices_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tcCustomerServices.SelectedIndexChanged
            Try
                Me.rtbIMEI.Text = String.Empty
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "tcCustomerServices_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Function UpdateReject(ByVal iDeviceID As Integer, ByVal iModelID As Integer, ByVal strModel As String) As Boolean
            Try
                Dim objDevice As New Rules.Device(iDeviceID)

                If Generic.IsBillcodeMapped(iModelID, Me._iOWRejectRepair) Then
                    If Me.dbgHoldSN.SelectedRows.Count > 0 Then
                        Dim drParts As DataRow() = Me._dsHold.Tables("Hold Device Parts").Select(String.Format("device_id = {0}", iDeviceID))

                        If drParts.Length > 0 Then
                            Dim i As Integer

                            For i = 0 To drParts.Length - 1
                                Dim iBillCodeID As Integer = Convert.ToInt32(drParts(i)("billcode_id"))

                                If iBillCodeID > 0 Then objDevice.DeletePart(iBillCodeID)
                            Next i
                        End If
                    Else
                        Dim dtParts As DataTable = Me._objPTCustService.GetHoldDeviceParts(iDeviceID)

                        If dtParts.Rows.Count > 0 Then
                            Dim drParts As DataRow

                            For Each drParts In dtParts.Rows
                                Dim iBillCodeID As Integer = Convert.ToInt32(drParts("billcode_id"))

                                If iBillCodeID > 0 Then objDevice.DeletePart(iBillCodeID)
                            Next drParts
                        End If
                    End If

                    objDevice.AddPart(Me._iOWRejectRepair)
                    objDevice.Update()

                    Return True
                Else
                    MessageBox.Show(String.Format("Bill code {0} has not been mapped for model {1}.", Me._iOWRejectRepair, strModel), "Unmapped Bill Code", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Return False
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Private Sub dbgApprovedSN_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles dbgApprovedSN.BeforeColEdit
            Try
                Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = Me.dbgApprovedSN

                HandleBeforeColEdit(dbg, e)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgApprovedSN_BeforeColEdit", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub dbgApprovedSN_AfterColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles dbgApprovedSN.AfterColEdit
            Try
                Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = Me.dbgApprovedSN
                Dim dtDevices As DataTable = Me._dsApproved.Tables("Approved RMA Devices")

                HandleAfterColEdit(dbg, dtDevices, e)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgApprovedSN_AfterColEdit", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub dbgApprovedSN_ButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles dbgApprovedSN.ButtonClick
            Try
                Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = DirectCast(sender, C1.Win.C1TrueDBGrid.C1TrueDBGrid)

                HandleButtonClick(dbg)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgApprovedSN_ButtonClick", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub _lstShipTypes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _lstShipTypes.SelectedIndexChanged
            Try
                Dim lst As ListBox = DirectCast(sender, ListBox)

                If Me._bLoading Or Me._bClosing Or Not lst.Visible Then Exit Sub

                Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = Me._dbgCurrentSN

                If dbg.Row > -1 Then
                    With lst
                        If .SelectedIndex > -1 And .Enabled Then
                            Me.Cursor = Cursors.WaitCursor
                            Me.Enabled = False

                            Dim dbgr As System.Data.DataRowView = dbg.Item(dbg.Row)
                            Dim iShipID As Integer = Convert.ToInt32(dbgr("ship_id"))
                            Dim iOldShipTypeID As Integer = Convert.ToInt32(dbgr("ShipTypeID"))
                            Dim iShipTypeID As Integer = .SelectedValue
                            Dim iDeviceID As Integer = Convert.ToInt32(dbgr("device_id"))

                            If iOldShipTypeID <> iShipTypeID And iShipID > 0 Then
                                Me._objPTCustService.UpdateShipType(iShipID, iShipTypeID)

                                dbgr.BeginEdit()

                                dbgr("ShipTypeID") = iShipTypeID
                                dbgr("Ship Type") = CType(CType(CType(lst.SelectedItem, Object), System.Data.DataRowView).Row, System.Data.DataRow).ItemArray(1).ToString

                                dbgr.EndEdit()

                                Dim drDevice() As DataRow = Me._dsApproved.Tables("Approved RMA Devices").Select(String.Format("device_id = {0}", iDeviceID))

                                If drDevice.Length > 0 Then
                                    drDevice(0).BeginEdit()

                                    drDevice(0)("ShipTypeID") = iShipTypeID
                                    drDevice(0)("Ship Type") = CType(CType(CType(lst.SelectedItem, Object), System.Data.DataRowView).Row, System.Data.DataRow).ItemArray(1).ToString

                                    drDevice(0).EndEdit()
                                    drDevice(0).AcceptChanges()
                                End If
                            End If
                        End If

                        .Visible = False
                        .SelectedIndex = -1
                    End With
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "lstShipTypes_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                If Me._lstShipTypes.Visible Then
                    Me._lstShipTypes.Visible = False
                    Me._lstShipTypes.SelectedIndex = -1
                End If

                Me.Enabled = True
                Me.Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub dbgApprovedSN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dbgApprovedSN.KeyPress
            Try
                Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = Me.dbgApprovedSN

                HandleKeyPress(dbg, e)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgApprovedSN_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub dbgApprovedSN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dbgApprovedSN.KeyDown
            Try
                Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = Me.dbgApprovedSN

                HandleKeyDown(dbg, e)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgApprovedSN_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub dbgHoldSN_ButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles dbgHoldSN.ButtonClick
            Try
                Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = DirectCast(sender, C1.Win.C1TrueDBGrid.C1TrueDBGrid)

                HandleButtonClick(dbg)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgHoldSN_ButtonClick", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub dbgHoldSN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dbgHoldSN.KeyPress
            Try
                Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = Me.dbgHoldSN

                HandleKeyPress(dbg, e)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgHoldSN_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub dbgHoldSN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dbgHoldSN.KeyDown
            Try
                Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = Me.dbgHoldSN

                HandleKeyDown(dbg, e)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgHoldSN_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub dbgHoldSN_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles dbgHoldSN.BeforeColEdit
            Try
                Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = Me.dbgHoldSN

                HandleBeforeColEdit(dbg, e)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgHoldSN_BeforeColEdit", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub dbgHoldSN_AfterColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles dbgHoldSN.AfterColEdit
            Try
                Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = Me.dbgHoldSN
                Dim dtDevices As DataTable = Me._dsHold.Tables("Hold RMA Devices")

                HandleAfterColEdit(dbg, dtDevices, e)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgHoldSN_AfterColEdit", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub HandleButtonClick(ByVal dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
            Try
                Dim dbgr As System.Data.DataRowView = dbg.Item(dbg.Row)

                If dbgr("ship_id") = 0 Then
                    Beep()
                    MessageBox.Show("This device has not yet shipped, therefore, a shipment type cannot be selected.", "Device Not Shipped", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    dbgr.CancelEdit()

                    Exit Sub
                Else
                    With Me._lstShipTypes
                        .Top = dbg.Top + dbg.RowTop(dbg.Row)
                        .Width = Math.Max(Me.dbgApprovedSN.Splits(0).DisplayColumns("Ship Type").Width, 75)
                        .Left = dbg.Left + dbg.Width - .Width
                        .Enabled = False 'To prevent the SelectedIndexChanged method from fully firing (see if after the with in the method)
                        .Visible = True
                        .Enabled = True
                    End With
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub HandleKeyPress(ByVal dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal e As System.Windows.Forms.KeyPressEventArgs)
            Try
                Dim dbgr As System.Data.DataRowView = dbg.Item(dbg.Row)
                Dim iShipID As Integer = dbgr("ship_id")

                If CType(dbg.Columns(dbg.Col), C1.Win.C1TrueDBGrid.C1DataColumn).Caption.Equals("Tracking Number") Then
                    If iShipID = 0 Then
                        Beep()
                        MessageBox.Show("This device has not yet shipped, therefore, the tracking number cannot be edited.", "Device Not Shipped", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        e.Handled = True
                    ElseIf Not (Char.IsLetterOrDigit(e.KeyChar) Or Char.IsControl(e.KeyChar)) Then
                        Beep()
                        e.Handled = True
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub HandleKeyDown(ByVal dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal e As System.Windows.Forms.KeyEventArgs)
            Try
                Dim dbgr As System.Data.DataRowView = dbg.Item(dbg.Row)
                Dim iShipID As Integer = dbgr("ship_id")

                If CType(dbg.Columns(dbg.Col), C1.Win.C1TrueDBGrid.C1DataColumn).Caption.Equals("Ship Type") Then
                    If e.KeyCode = Keys.Escape And Me._lstShipTypes.Visible Then
                        With Me._lstShipTypes
                            .Visible = False
                            .SelectedIndex = -1
                        End With

                        e.Handled = True
                    End If
                ElseIf CType(dbg.Columns(dbg.Col), C1.Win.C1TrueDBGrid.C1DataColumn).Caption.Equals("Tracking Number") Then
                    If e.KeyCode = Keys.Escape Then
                        dbgr.CancelEdit()
                        Me._bCancelEdit = True
                    ElseIf iShipID = 0 Then
                        Beep()
                        MessageBox.Show("This device has not yet shipped, therefore, the tracking number cannot be edited.", "Device Not Shipped", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        e.Handled = True
                    ElseIf e.KeyCode = Keys.Enter Then
                        dbgr.EndEdit()
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub HandleBeforeColEdit(ByVal dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs)
            Try
                Dim dbgr As System.Data.DataRowView = dbg.Item(dbg.Row)
                Dim iShipID As Integer = dbgr("ship_id")

                If e.Column.Name.Equals("Tracking Number") Then
                    If iShipID = 0 Then
                        Beep()
                        MessageBox.Show("This device has not yet shipped, therefore, the tracking number cannot be edited.", "Device Not Shipped", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        e.Cancel = True
                    Else
                        Dim strTN As String = dbgr("Tracking Number").ToString().Trim().ToUpper

                        Me._strOriginalTrackingNumber = strTN
                    End If
                ElseIf e.Column.Name.Equals("Ship Type") Then
                    If iShipID = 0 Then
                        Beep()
                        MessageBox.Show("This device has not yet shipped, therefore, a shipment type cannot be selected.", "Device Not Shipped", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        e.Cancel = True
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub HandleAfterColEdit(ByVal dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal dtDevices As DataTable, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs)
            Try
                If Me._bCancelEdit Or Me._bClosing Then Exit Sub

                Dim dbgr As System.Data.DataRowView = dbg.Item(dbg.Row)
                Dim iShipID As Integer = dbgr("ship_id")

                If e.Column.Name.Equals("Tracking Number") Then
                    Dim iDeviceID As Integer = Convert.ToInt32(dbgr("device_id"))
                    Dim strTN As String = dbgr("Tracking Number").ToString().Trim().ToUpper

                    If strTN.Length = 0 Then
                        If MessageBox.Show("Enter an empty tracking number?", "Empty Tracking Number", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                            dbgr("Tracking Number") = Me._strOriginalTrackingNumber

                            Exit Sub
                        End If
                    ElseIf Not strTN.Equals(Me._strOriginalTrackingNumber) Then
                        If MessageBox.Show(String.Format("Change tracking number from '{0}' to '{1}'?", Me._strOriginalTrackingNumber, strTN), "Change tracking Number", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                            dbgr("Tracking Number") = Me._strOriginalTrackingNumber

                            Exit Sub
                        End If
                    End If

                    Me._objPTCustService.UpdateTrackingNumber(iShipID, strTN)

                    dbgr("Original Tracking Number") = strTN

                    Dim drDevice() As DataRow = dtDevices.Select(String.Format("device_id = {0}", iDeviceID))

                    If drDevice.Length > 0 Then
                        drDevice(0).BeginEdit()

                        drDevice(0)("Original Tracking Number") = strTN
                        drDevice(0)("Tracking Number") = strTN

                        drDevice(0).EndEdit()
                        drDevice(0).AcceptChanges()
                    End If
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Me._bCancelEdit = False
            End Try
        End Sub

        Private Function CreateTrackingNumberEditMask() As String
            Try
                Dim strEditMask As String = ">"
                Dim i As Integer

                For i = 1 To 45 : strEditMask &= "A" : Next i

                Return strEditMask
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Private Sub _txtAcceptedRejectedTNEditor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _txtApprovedTNEditor.KeyDown
            Try
                Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = Me.dbgApprovedSN

                HandleKeyDown(dbg, e)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "_txtAcceptedRejectedTNEditor_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub _txtAcceptedRejectedTNEditor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _txtApprovedTNEditor.KeyPress
            Try
                Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = Me.dbgApprovedSN

                HandleKeyPress(dbg, e)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "_txtAcceptedRejectedTNEditor_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub SetupShipTypes()
            Dim dtShipTypes As DataTable = Nothing

            Try
                dtShipTypes = Me._objPTCustService.GetShipTypes()

                Me._lstShipTypes.DataSource = dtShipTypes.DefaultView
                Me._lstShipTypes.ValueMember = "ShipTypeID"
                Me._lstShipTypes.DisplayMember = "ShipType"

                Me._lstShipTypes.BackColor = Color.LightYellow
                Me._lstShipTypes.ForeColor = Color.Purple

                Me._lstShipTypes.SelectedIndex = -1
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtShipTypes)
            End Try
        End Sub

        Private Sub _txtHoldTNEditor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _txtHoldTNEditor.KeyDown
            Try
                Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = Me.dbgHoldSN

                HandleKeyDown(dbg, e)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "_txtHoldTNEditor_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub _txtHoldTNEditor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _txtHoldTNEditor.KeyPress
            Try
                Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = Me.dbgHoldSN

                HandleKeyPress(dbg, e)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "_txtHoldTNEditor_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Function CheckDeviceValidity(ByVal strIMEI As String) As Boolean
            Try
                Dim bPassed As Boolean = True

                If Not Me._objPTCustService.DeviceIsPantech(strIMEI, _iLocID) Then
                    MessageBox.Show("This is not a Pantech device.", "Invalid Device", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    bPassed = False
                End If

                If bPassed And Not Me._objPTCustService.DeviceOutOfWarranty(strIMEI) Then
                    MessageBox.Show("This device is still in warranty.", "IW Device", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    bPassed = False
                End If

                Return bPassed
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Private Sub rtbIMEI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles rtbIMEI.KeyDown
            Try
                If e.KeyCode = Keys.Enter Then
                    If Me.dbgHoldSN.SelectedRows.Count > 0 Then Me.dbgHoldSN.SelectedRows.Clear()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "rtbIMEI_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub
    End Class
End Namespace