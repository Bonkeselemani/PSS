Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.DriveCam

    Public Class frmDCAdmin
        Inherits System.Windows.Forms.Form

        Private _objDC As PSS.Data.Buisness.DriveCam

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _objDC = New PSS.Data.Buisness.DriveCam()
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
                _objDC = Nothing
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Friend WithEvents tpgInvoicing As System.Windows.Forms.TabPage
        Friend WithEvents tpgHoldUnit As System.Windows.Forms.TabPage
        Friend WithEvents dbgHoldUnits As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnExportToExcel As System.Windows.Forms.Button
        Friend WithEvents tcAdmin As System.Windows.Forms.TabControl
        Friend WithEvents tpgApUnApCompactFlash As System.Windows.Forms.TabPage
        Friend WithEvents dbgReadyToInvoice As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents gbInvoiceRpt As System.Windows.Forms.GroupBox
        Friend WithEvents dtpShipFr As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpShipTo As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents dbgWaitingCFApprove As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents btnEmailCFReqAp As System.Windows.Forms.Button
        Friend WithEvents rdbUnApproved As System.Windows.Forms.RadioButton
        Friend WithEvents rdbApproved As System.Windows.Forms.RadioButton
        Friend WithEvents txtSN As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents btnUpdate As System.Windows.Forms.Button
        Friend WithEvents gbCompactFlashApproval As System.Windows.Forms.GroupBox
        Friend WithEvents btnCreateInvoicingRpt As System.Windows.Forms.Button
        Friend WithEvents btnReprintInvRpt As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDCAdmin))
            Me.tcAdmin = New System.Windows.Forms.TabControl()
            Me.tpgHoldUnit = New System.Windows.Forms.TabPage()
            Me.btnExportToExcel = New System.Windows.Forms.Button()
            Me.dbgHoldUnits = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.tpgApUnApCompactFlash = New System.Windows.Forms.TabPage()
            Me.gbCompactFlashApproval = New System.Windows.Forms.GroupBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtSN = New System.Windows.Forms.TextBox()
            Me.rdbApproved = New System.Windows.Forms.RadioButton()
            Me.rdbUnApproved = New System.Windows.Forms.RadioButton()
            Me.btnUpdate = New System.Windows.Forms.Button()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.btnEmailCFReqAp = New System.Windows.Forms.Button()
            Me.dbgWaitingCFApprove = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.tpgInvoicing = New System.Windows.Forms.TabPage()
            Me.btnReprintInvRpt = New System.Windows.Forms.Button()
            Me.gbInvoiceRpt = New System.Windows.Forms.GroupBox()
            Me.dtpShipTo = New System.Windows.Forms.DateTimePicker()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.btnCreateInvoicingRpt = New System.Windows.Forms.Button()
            Me.dtpShipFr = New System.Windows.Forms.DateTimePicker()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.dbgReadyToInvoice = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.tcAdmin.SuspendLayout()
            Me.tpgHoldUnit.SuspendLayout()
            CType(Me.dbgHoldUnits, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpgApUnApCompactFlash.SuspendLayout()
            Me.gbCompactFlashApproval.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            CType(Me.dbgWaitingCFApprove, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpgInvoicing.SuspendLayout()
            Me.gbInvoiceRpt.SuspendLayout()
            CType(Me.dbgReadyToInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'tcAdmin
            '
            Me.tcAdmin.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.tcAdmin.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpgHoldUnit, Me.tpgApUnApCompactFlash, Me.tpgInvoicing})
            Me.tcAdmin.Location = New System.Drawing.Point(8, 8)
            Me.tcAdmin.Name = "tcAdmin"
            Me.tcAdmin.SelectedIndex = 0
            Me.tcAdmin.Size = New System.Drawing.Size(736, 480)
            Me.tcAdmin.TabIndex = 0
            '
            'tpgHoldUnit
            '
            Me.tpgHoldUnit.BackColor = System.Drawing.Color.SteelBlue
            Me.tpgHoldUnit.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnExportToExcel, Me.dbgHoldUnits})
            Me.tpgHoldUnit.Location = New System.Drawing.Point(4, 22)
            Me.tpgHoldUnit.Name = "tpgHoldUnit"
            Me.tpgHoldUnit.Size = New System.Drawing.Size(728, 454)
            Me.tpgHoldUnit.TabIndex = 1
            Me.tpgHoldUnit.Text = "Hold Unit(s)"
            '
            'btnExportToExcel
            '
            Me.btnExportToExcel.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnExportToExcel.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnExportToExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnExportToExcel.ForeColor = System.Drawing.Color.Black
            Me.btnExportToExcel.Location = New System.Drawing.Point(552, 8)
            Me.btnExportToExcel.Name = "btnExportToExcel"
            Me.btnExportToExcel.Size = New System.Drawing.Size(160, 24)
            Me.btnExportToExcel.TabIndex = 143
            Me.btnExportToExcel.Text = "Export to Excel"
            '
            'dbgHoldUnits
            '
            Me.dbgHoldUnits.AllowColMove = False
            Me.dbgHoldUnits.AllowColSelect = False
            Me.dbgHoldUnits.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.dbgHoldUnits.AllowUpdate = False
            Me.dbgHoldUnits.AllowUpdateOnBlur = False
            Me.dbgHoldUnits.AlternatingRows = True
            Me.dbgHoldUnits.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgHoldUnits.BackColor = System.Drawing.Color.SteelBlue
            Me.dbgHoldUnits.FilterBar = True
            Me.dbgHoldUnits.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dbgHoldUnits.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgHoldUnits.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dbgHoldUnits.Location = New System.Drawing.Point(16, 40)
            Me.dbgHoldUnits.MaintainRowCurrency = True
            Me.dbgHoldUnits.Name = "dbgHoldUnits"
            Me.dbgHoldUnits.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgHoldUnits.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgHoldUnits.PreviewInfo.ZoomFactor = 75
            Me.dbgHoldUnits.RowHeight = 20
            Me.dbgHoldUnits.Size = New System.Drawing.Size(696, 366)
            Me.dbgHoldUnits.TabIndex = 140
            Me.dbgHoldUnits.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            "eeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidth=""16"" Vertical" & _
            "ScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>362</Height><CaptionStyle pare" & _
            "nt=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowSt" & _
            "yle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style1" & _
            "3"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""S" & _
            "tyle12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent" & _
            "=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><Od" & _
            "dRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelec" & _
            "tor"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent" & _
            "=""Normal"" me=""Style1"" /><ClientRect>0, 0, 692, 362</ClientRect><BorderSide>0</Bo" & _
            "rderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Spli" & _
            "ts><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Headin" & _
            "g"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" " & _
            "/><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /" & _
            "><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /" & _
            "><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Sty" & _
            "le parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" " & _
            "/><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><" & _
            "horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>16</DefaultRec" & _
            "SelWidth><ClientArea>0, 0, 692, 362</ClientArea><PrintPageHeaderStyle parent="""" " & _
            "me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'tpgApUnApCompactFlash
            '
            Me.tpgApUnApCompactFlash.BackColor = System.Drawing.Color.SteelBlue
            Me.tpgApUnApCompactFlash.Controls.AddRange(New System.Windows.Forms.Control() {Me.gbCompactFlashApproval, Me.GroupBox1, Me.dbgWaitingCFApprove})
            Me.tpgApUnApCompactFlash.Location = New System.Drawing.Point(4, 22)
            Me.tpgApUnApCompactFlash.Name = "tpgApUnApCompactFlash"
            Me.tpgApUnApCompactFlash.Size = New System.Drawing.Size(728, 454)
            Me.tpgApUnApCompactFlash.TabIndex = 2
            Me.tpgApUnApCompactFlash.Text = "Compact Flash Approving"
            '
            'gbCompactFlashApproval
            '
            Me.gbCompactFlashApproval.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.gbCompactFlashApproval.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label3, Me.txtSN, Me.rdbApproved, Me.rdbUnApproved, Me.btnUpdate})
            Me.gbCompactFlashApproval.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbCompactFlashApproval.ForeColor = System.Drawing.Color.WhiteSmoke
            Me.gbCompactFlashApproval.Location = New System.Drawing.Point(528, 6)
            Me.gbCompactFlashApproval.Name = "gbCompactFlashApproval"
            Me.gbCompactFlashApproval.Size = New System.Drawing.Size(186, 149)
            Me.gbCompactFlashApproval.TabIndex = 149
            Me.gbCompactFlashApproval.TabStop = False
            Me.gbCompactFlashApproval.Visible = False
            '
            'Label3
            '
            Me.Label3.Location = New System.Drawing.Point(8, 64)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(80, 16)
            Me.Label3.TabIndex = 148
            Me.Label3.Text = "S/N:"
            '
            'txtSN
            '
            Me.txtSN.Location = New System.Drawing.Point(8, 80)
            Me.txtSN.Name = "txtSN"
            Me.txtSN.Size = New System.Drawing.Size(168, 20)
            Me.txtSN.TabIndex = 1
            Me.txtSN.Text = ""
            '
            'rdbApproved
            '
            Me.rdbApproved.Checked = True
            Me.rdbApproved.Location = New System.Drawing.Point(40, 16)
            Me.rdbApproved.Name = "rdbApproved"
            Me.rdbApproved.Size = New System.Drawing.Size(74, 16)
            Me.rdbApproved.TabIndex = 2
            Me.rdbApproved.TabStop = True
            Me.rdbApproved.Text = "Approved"
            '
            'rdbUnApproved
            '
            Me.rdbUnApproved.Location = New System.Drawing.Point(40, 40)
            Me.rdbUnApproved.Name = "rdbUnApproved"
            Me.rdbUnApproved.Size = New System.Drawing.Size(106, 16)
            Me.rdbUnApproved.TabIndex = 3
            Me.rdbUnApproved.Text = "Un-Approved"
            '
            'btnUpdate
            '
            Me.btnUpdate.BackColor = System.Drawing.Color.DarkCyan
            Me.btnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnUpdate.ForeColor = System.Drawing.Color.White
            Me.btnUpdate.Location = New System.Drawing.Point(8, 112)
            Me.btnUpdate.Name = "btnUpdate"
            Me.btnUpdate.Size = New System.Drawing.Size(168, 24)
            Me.btnUpdate.TabIndex = 4
            Me.btnUpdate.Text = "Update"
            '
            'GroupBox1
            '
            Me.GroupBox1.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnEmailCFReqAp})
            Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox1.ForeColor = System.Drawing.Color.WhiteSmoke
            Me.GroupBox1.Location = New System.Drawing.Point(533, 255)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(186, 61)
            Me.GroupBox1.TabIndex = 148
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Visible = False
            '
            'btnEmailCFReqAp
            '
            Me.btnEmailCFReqAp.BackColor = System.Drawing.Color.DarkCyan
            Me.btnEmailCFReqAp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnEmailCFReqAp.ForeColor = System.Drawing.Color.White
            Me.btnEmailCFReqAp.Location = New System.Drawing.Point(8, 16)
            Me.btnEmailCFReqAp.Name = "btnEmailCFReqAp"
            Me.btnEmailCFReqAp.Size = New System.Drawing.Size(168, 37)
            Me.btnEmailCFReqAp.TabIndex = 144
            Me.btnEmailCFReqAp.Text = "Notify Selected S/N to Customer"
            '
            'dbgWaitingCFApprove
            '
            Me.dbgWaitingCFApprove.AllowColMove = False
            Me.dbgWaitingCFApprove.AllowColSelect = False
            Me.dbgWaitingCFApprove.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.dbgWaitingCFApprove.AllowUpdate = False
            Me.dbgWaitingCFApprove.AllowUpdateOnBlur = False
            Me.dbgWaitingCFApprove.AlternatingRows = True
            Me.dbgWaitingCFApprove.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgWaitingCFApprove.BackColor = System.Drawing.Color.SteelBlue
            Me.dbgWaitingCFApprove.FilterBar = True
            Me.dbgWaitingCFApprove.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dbgWaitingCFApprove.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgWaitingCFApprove.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.dbgWaitingCFApprove.Location = New System.Drawing.Point(13, 10)
            Me.dbgWaitingCFApprove.MaintainRowCurrency = True
            Me.dbgWaitingCFApprove.Name = "dbgWaitingCFApprove"
            Me.dbgWaitingCFApprove.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgWaitingCFApprove.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgWaitingCFApprove.PreviewInfo.ZoomFactor = 75
            Me.dbgWaitingCFApprove.RowHeight = 20
            Me.dbgWaitingCFApprove.Size = New System.Drawing.Size(504, 405)
            Me.dbgWaitingCFApprove.TabIndex = 141
            Me.dbgWaitingCFApprove.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            "eeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidth=""16"" Vertical" & _
            "ScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>401</Height><CaptionStyle pare" & _
            "nt=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowSt" & _
            "yle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style1" & _
            "3"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""S" & _
            "tyle12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent" & _
            "=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><Od" & _
            "dRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelec" & _
            "tor"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent" & _
            "=""Normal"" me=""Style1"" /><ClientRect>0, 0, 500, 401</ClientRect><BorderSide>0</Bo" & _
            "rderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Spli" & _
            "ts><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Headin" & _
            "g"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" " & _
            "/><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /" & _
            "><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /" & _
            "><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Sty" & _
            "le parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" " & _
            "/><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><" & _
            "horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>16</DefaultRec" & _
            "SelWidth><ClientArea>0, 0, 500, 401</ClientArea><PrintPageHeaderStyle parent="""" " & _
            "me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'tpgInvoicing
            '
            Me.tpgInvoicing.BackColor = System.Drawing.Color.SteelBlue
            Me.tpgInvoicing.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnReprintInvRpt, Me.gbInvoiceRpt, Me.dbgReadyToInvoice})
            Me.tpgInvoicing.Location = New System.Drawing.Point(4, 22)
            Me.tpgInvoicing.Name = "tpgInvoicing"
            Me.tpgInvoicing.Size = New System.Drawing.Size(728, 454)
            Me.tpgInvoicing.TabIndex = 0
            Me.tpgInvoicing.Text = "Invoicing"
            '
            'btnReprintInvRpt
            '
            Me.btnReprintInvRpt.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnReprintInvRpt.BackColor = System.Drawing.Color.DarkCyan
            Me.btnReprintInvRpt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprintInvRpt.ForeColor = System.Drawing.Color.White
            Me.btnReprintInvRpt.Location = New System.Drawing.Point(544, 167)
            Me.btnReprintInvRpt.Name = "btnReprintInvRpt"
            Me.btnReprintInvRpt.Size = New System.Drawing.Size(168, 24)
            Me.btnReprintInvRpt.TabIndex = 148
            Me.btnReprintInvRpt.Text = "Reprint Invoice Rpt"
            '
            'gbInvoiceRpt
            '
            Me.gbInvoiceRpt.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.gbInvoiceRpt.Controls.AddRange(New System.Windows.Forms.Control() {Me.dtpShipTo, Me.Label1, Me.btnCreateInvoicingRpt, Me.dtpShipFr, Me.Label2})
            Me.gbInvoiceRpt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbInvoiceRpt.ForeColor = System.Drawing.Color.WhiteSmoke
            Me.gbInvoiceRpt.Location = New System.Drawing.Point(533, 3)
            Me.gbInvoiceRpt.Name = "gbInvoiceRpt"
            Me.gbInvoiceRpt.Size = New System.Drawing.Size(187, 148)
            Me.gbInvoiceRpt.TabIndex = 147
            Me.gbInvoiceRpt.TabStop = False
            Me.gbInvoiceRpt.Visible = False
            '
            'dtpShipTo
            '
            Me.dtpShipTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpShipTo.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpShipTo.Location = New System.Drawing.Point(11, 83)
            Me.dtpShipTo.Name = "dtpShipTo"
            Me.dtpShipTo.Size = New System.Drawing.Size(168, 24)
            Me.dtpShipTo.TabIndex = 147
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(8, 66)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(157, 16)
            Me.Label1.TabIndex = 148
            Me.Label1.Text = "Prod Ship To Date:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnCreateInvoicingRpt
            '
            Me.btnCreateInvoicingRpt.BackColor = System.Drawing.Color.DarkCyan
            Me.btnCreateInvoicingRpt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCreateInvoicingRpt.ForeColor = System.Drawing.Color.White
            Me.btnCreateInvoicingRpt.Location = New System.Drawing.Point(9, 115)
            Me.btnCreateInvoicingRpt.Name = "btnCreateInvoicingRpt"
            Me.btnCreateInvoicingRpt.Size = New System.Drawing.Size(168, 24)
            Me.btnCreateInvoicingRpt.TabIndex = 144
            Me.btnCreateInvoicingRpt.Text = "Create Invoicing Rpt"
            '
            'dtpShipFr
            '
            Me.dtpShipFr.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpShipFr.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpShipFr.Location = New System.Drawing.Point(10, 31)
            Me.dtpShipFr.Name = "dtpShipFr"
            Me.dtpShipFr.Size = New System.Drawing.Size(168, 24)
            Me.dtpShipFr.TabIndex = 145
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(7, 13)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(157, 16)
            Me.Label2.TabIndex = 146
            Me.Label2.Text = "Prod Ship From Date:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'dbgReadyToInvoice
            '
            Me.dbgReadyToInvoice.AllowColMove = False
            Me.dbgReadyToInvoice.AllowColSelect = False
            Me.dbgReadyToInvoice.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.dbgReadyToInvoice.AllowUpdate = False
            Me.dbgReadyToInvoice.AllowUpdateOnBlur = False
            Me.dbgReadyToInvoice.AlternatingRows = True
            Me.dbgReadyToInvoice.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgReadyToInvoice.BackColor = System.Drawing.Color.SteelBlue
            Me.dbgReadyToInvoice.FilterBar = True
            Me.dbgReadyToInvoice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dbgReadyToInvoice.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgReadyToInvoice.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.dbgReadyToInvoice.Location = New System.Drawing.Point(9, 9)
            Me.dbgReadyToInvoice.MaintainRowCurrency = True
            Me.dbgReadyToInvoice.Name = "dbgReadyToInvoice"
            Me.dbgReadyToInvoice.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgReadyToInvoice.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgReadyToInvoice.PreviewInfo.ZoomFactor = 75
            Me.dbgReadyToInvoice.RowHeight = 20
            Me.dbgReadyToInvoice.Size = New System.Drawing.Size(515, 397)
            Me.dbgReadyToInvoice.TabIndex = 1
            Me.dbgReadyToInvoice.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            "eeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidth=""16"" Vertical" & _
            "ScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>393</Height><CaptionStyle pare" & _
            "nt=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowSt" & _
            "yle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style1" & _
            "3"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""S" & _
            "tyle12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent" & _
            "=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><Od" & _
            "dRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelec" & _
            "tor"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent" & _
            "=""Normal"" me=""Style1"" /><ClientRect>0, 0, 511, 393</ClientRect><BorderSide>0</Bo" & _
            "rderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Spli" & _
            "ts><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Headin" & _
            "g"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" " & _
            "/><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /" & _
            "><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /" & _
            "><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Sty" & _
            "le parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" " & _
            "/><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><" & _
            "horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>16</DefaultRec" & _
            "SelWidth><ClientArea>0, 0, 511, 393</ClientArea><PrintPageHeaderStyle parent="""" " & _
            "me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'frmDCAdmin
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(752, 509)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tcAdmin})
            Me.Name = "frmDCAdmin"
            Me.Text = "frmDCAdmin"
            Me.tcAdmin.ResumeLayout(False)
            Me.tpgHoldUnit.ResumeLayout(False)
            CType(Me.dbgHoldUnits, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpgApUnApCompactFlash.ResumeLayout(False)
            Me.gbCompactFlashApproval.ResumeLayout(False)
            Me.GroupBox1.ResumeLayout(False)
            CType(Me.dbgWaitingCFApprove, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpgInvoicing.ResumeLayout(False)
            Me.gbInvoiceRpt.ResumeLayout(False)
            CType(Me.dbgReadyToInvoice, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '******************************************************************
        Private Sub frmDCAdmin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                'Set Special permissions
                If PSS.Core.ApplicationUser.GetPermission("DC_Admin") > 0 Then
                    Me.gbInvoiceRpt.Visible = True
                    Me.gbCompactFlashApproval.Visible = True
                End If
                PSS.Core.Highlight.SetHighLight(Me)
                Me.tpgHoldUnit.Visible = True

            Catch ex As Exception
                MessageBox.Show(ex.Message, "FormLoad", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '******************************************************************
        Private Sub tpgs_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpgHoldUnit.VisibleChanged, tpgApUnApCompactFlash.VisibleChanged, tpgInvoicing.VisibleChanged
            Try
                If sender.Name = "tpgHoldUnit" Then
                    If Me.tpgHoldUnit.Visible = True Then Me.PopulateHoldUnitsGrid()
                ElseIf sender.Name = "tpgApUnApCompactFlash" Then
                    If Me.tpgApUnApCompactFlash.Visible = True Then Me.PopulateAppUnAppUnitsGrid()
                ElseIf sender.Name = "tpgInvoicing" Then
                    If Me.tpgInvoicing.Visible = True Then Me.PopulateTobeInvoicingUnitsGrid()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "tpgs_VisibleChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '******************************************************************
        Private Sub PopulateHoldUnitsGrid()
            Dim dt As DataTable
            Dim i As Integer
            Try
                dt = Me._objDC.GetHoldUnits()

                With Me.dbgHoldUnits
                    .DataSource = Nothing
                    .DataSource = dt.DefaultView

                    For i = 0 To dt.Columns.Count - 1
                        .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near

                        If dt.Columns(i).Caption.EndsWith("Date") = True Then
                            .Splits(0).DisplayColumns(i).Width = 130
                        ElseIf dt.Columns(i).Caption.EndsWith("Customer") = True Then
                            .Splits(0).DisplayColumns(i).Width = 180
                        Else
                            .Splits(0).DisplayColumns(i).Width = 100
                        End If
                    Next i

                End With
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportToExcel.Click
            'Excel Related variables
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet
            Dim dt As DataTable
            Dim objArrData As Object
            Dim i, j As Integer
            Dim iSNColIndex As Integer = -1
            Dim strArrTextCols() As String

            Try
                dt = New DataTable()
                dt = Me.dbgHoldUnits.DataSource.Table.Copy

                If dt.Rows.Count > 0 Then
                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor

                    ReDim objArrData(dt.Rows.Count, dt.Columns.Count)
                    ReDim strArrTextCols(dt.Columns.Count)
                    'instantiate excel object
                    objExcel = New Excel.Application()      'Starts the Excel Session
                    objBook = objExcel.Workbooks.Add                    'Add a Workbook
                    objSheet = objBook.Worksheets.Item(1)               'Select a Sheet 1 for this
                    objExcel.Application.Visible = False                'Make excel invisible to user

                    'header
                    For j = 0 To dt.Columns.Count - 1
                        If dt.Columns(j).Caption = "S/N" Then
                            iSNColIndex = j
                            objArrData(0, j) = dt.Columns(j).Caption
                            objArrData(0, j + 1) = "S/N Barcode"

                            '*************************************
                            'format column to text
                            '*************************************
                            objSheet.Columns(Generic.CalExcelColLetter(j + 1).ToString & ":" & Generic.CalExcelColLetter(j + 1).ToString).Select()
                            objExcel.Selection.NumberFormat = "@"
                            '*************************************
                        ElseIf iSNColIndex >= 0 Then
                            objArrData(0, j + 1) = dt.Columns(j).Caption
                            If dt.Columns(j).Caption.ToString.StartsWith("Wo") = True Or dt.Columns(j).Caption.ToString.StartsWith("Customer") = True Then
                                '*************************************
                                'format column to text
                                '*************************************
                                objSheet.Columns(Generic.CalExcelColLetter(j + 2).ToString & ":" & Generic.CalExcelColLetter(j + 2).ToString).Select()
                                objExcel.Selection.NumberFormat = "@"
                                '*************************************
                            End If
                        Else
                            objArrData(0, j) = dt.Columns(j).Caption

                            If dt.Columns(j).Caption.ToString.StartsWith("Wo") = True Or dt.Columns(j).Caption.ToString.StartsWith("Customer") = True Then
                                '*************************************
                                'format column to text
                                '*************************************
                                objSheet.Columns(Generic.CalExcelColLetter(j + 1).ToString & ":" & Generic.CalExcelColLetter(j + 1).ToString).Select()
                                objExcel.Selection.NumberFormat = "@"
                                '*************************************
                            End If
                        End If
                    Next j

                    'Data
                    For i = 0 To dt.Rows.Count - 1
                        For j = 0 To dt.Columns.Count - 1
                            If j = iSNColIndex Then
                                objArrData(i + 1, j) = dt.Rows(i)(j)
                                objArrData(i + 1, j + 1) = "*" & dt.Rows(i)(j) & "*"
                            ElseIf j < iSNColIndex Then
                                objArrData(i + 1, j) = dt.Rows(i)(j)
                            Else
                                objArrData(i + 1, j + 1) = dt.Rows(i)(j)
                            End If
                        Next j
                    Next i

                    objExcel.Application.Visible = True                'Make excel invisible to user
                    objExcel.Application.DisplayAlerts = False
                    objExcel.ActiveSheet.Pagesetup.Orientation = 1      ' 1 = Portrait ; 2 = landscape

                    'post data to excel
                    objSheet.Range("A1:" & Generic.CalExcelColLetter(dt.Columns.Count + 1) & (dt.Rows.Count + 1).ToString).Value = objArrData

                    '************************************************
                    'Set the Barcode Font
                    objSheet.Range(Generic.CalExcelColLetter(iSNColIndex + 2) & "2:" & Generic.CalExcelColLetter(iSNColIndex + 2) & (dt.Rows.Count + 1).ToString).Select()
                    With objExcel.Selection
                        .Font.Name = "C39P12DhTt"
                    End With
                    '************************************************
                Else
                    MessageBox.Show("No data is available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnExportToExcel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                '*************************************
                'Excel clean up
                If Not IsNothing(objSheet) Then
                    objSheet = Nothing
                    Generic.NAR(objSheet)
                End If
                If Not IsNothing(objBook) Then
                    objBook.Close()
                    objBook = Nothing
                    Generic.NAR(objBook)
                End If
                If Not IsNothing(objExcel) Then
                    objExcel.Quit()
                    objExcel = Nothing
                    Generic.NAR(objExcel)
                End If
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            Finally
                Generic.DisposeDT(dt)
                objArrData = Nothing
                Me.Enabled = True
                Cursor.Current = Cursors.Default

                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Sub

        '******************************************************************
        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Dim booResult As Boolean = False
            Try
                If Me.txtSN.Text.Trim.Length > 0 Then booResult = Me.ProcessSN()
                If booResult = True Then
                    Me.PopulateAppUnAppUnitsGrid()
                    Me.txtSN.Text = ""
                    Me.txtSN.Focus()
                Else
                    Me.txtSN.SelectAll()
                    Me.txtSN.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnUpdate_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                If Me.txtSN.Text.Trim > 0 Then Me.txtSN.SelectAll()
                Me.txtSN.Focus()
            End Try
        End Sub

        '******************************************************************
        Private Sub txtSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp
            Dim booResult As Boolean = False
            Try
                If e.KeyCode = Keys.Enter Then
                    If Me.txtSN.Text.Trim.Length > 0 Then
                        booResult = Me.ProcessSN()
                        If booResult = True Then
                            Me.txtSN.Text = ""
                            Me.txtSN.Focus()
                        Else
                            Me.txtSN.SelectAll()
                            Me.txtSN.Focus()
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "txtSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                If Me.txtSN.Text.Trim > 0 Then Me.txtSN.SelectAll()
                Me.txtSN.Focus()
            End Try
        End Sub

        '******************************************************************
        Private Function ProcessSN() As Boolean
            Dim booResult As Boolean = False
            Dim iStatus As Integer = 0
            Dim objDevice As PSS.Rules.Device
            Dim iDeviceID As Integer

            Try
                If Me.rdbApproved.Checked = True Then iStatus = 1

                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                booResult = Me._objDC.UpdateCFlashApproveStatus(Me.txtSN.Text.Trim, iStatus, PSS.Core.ApplicationUser.IDuser, iDeviceID)

                If booResult = True AndAlso iStatus = 0 Then
                    objDevice = New PSS.Rules.Device(iDeviceID)
                    If Generic.IsBillcodeExisted(iDeviceID, 1590) Then
                        objDevice.DeletePart(1590)
                        objDevice.Update()
                    End If

                    Me.Enabled = True
                    Cursor.Current = Cursors.Default
                    Me.txtSN.Focus()

                    MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                Return booResult
            Catch ex As Exception
                Throw ex
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Function

        '******************************************************************
        Private Sub PopulateAppUnAppUnitsGrid()
            Dim dt As DataTable
            Dim i As Integer

            Try
                dt = Me._objDC.GetApprovedUnApprovedUntis()

                With Me.dbgWaitingCFApprove
                    .DataSource = Nothing
                    .DataSource = dt.DefaultView

                    For i = 0 To dt.Columns.Count - 1
                        .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near

                        If dt.Columns(i).Caption.EndsWith("Customer") = True Then
                            .Splits(0).DisplayColumns(i).Width = 150
                        ElseIf dt.Columns(i).Caption.EndsWith("Date") Then
                            .Columns(i).NumberFormat = "MM/dd/yyyy HH:mm"
                            .Splits(0).DisplayColumns(i).Width = 110
                        ElseIf dt.Columns(i).Caption.EndsWith("CF Approved?") Then
                            .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                            .Splits(0).DisplayColumns(i).Width = 90
                        Else
                            .Splits(0).DisplayColumns(i).Width = 100
                        End If

                        If dt.Columns(i).Caption.EndsWith("Wo ID") = True Then .Splits(0).DisplayColumns(i).Visible = False
                    Next i
                End With
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '******************************************************************
        Private Sub PopulateTobeInvoicingUnitsGrid()
            Dim dt As DataTable
            Dim i As Integer

            Try
                dt = Me._objDC.GetDriveCamTobeInvoicingUnits()

                With Me.dbgReadyToInvoice
                    .DataSource = Nothing
                    .DataSource = dt.DefaultView

                    For i = 0 To dt.Columns.Count - 1
                        .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near

                        If dt.Columns(i).Caption.EndsWith("Labor") = True Or dt.Columns(i).Caption.EndsWith("Parts/Services") = True Then
                            .Columns(i).NumberFormat = "$#0.00"
                            .Splits(0).DisplayColumns(i).Width = 80
                            .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                        ElseIf dt.Columns(i).Caption.EndsWith("Customer") = True Or dt.Columns(i).Caption.EndsWith("Prod Completion") Then
                            If dt.Columns(i).Caption.EndsWith("Prod Completion") Then .Columns(i).NumberFormat = "MM/dd/yyyy HH:mm"
                            .Splits(0).DisplayColumns(i).Width = 130
                        Else
                            .Splits(0).DisplayColumns(i).Width = 100
                        End If

                        If dt.Columns(i).Caption.EndsWith("Pallett_ID") = True Then .Splits(0).DisplayColumns(i).Visible = False
                    Next i

                    If dt.Rows.Count > 0 Then
                        'Total
                        Me.dbgReadyToInvoice.FooterStyle.BackColor = Color.Black
                        Me.dbgReadyToInvoice.FooterStyle.ForeColor = Color.Lime
                        Me.dbgReadyToInvoice.ColumnFooters = True
                        Me.dbgReadyToInvoice.FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                        Me.dbgReadyToInvoice.Columns("Customer").FooterText = "TOTAL:"
                        Me.dbgReadyToInvoice.Columns("S/N").FooterText = dt.Rows.Count
                        Me.dbgReadyToInvoice.Columns("Labor").FooterText = "$" & Format(CDec(dt.Compute("Sum(Labor)", "").ToString), "#0.00")
                        Me.dbgReadyToInvoice.Columns("Parts/Services").FooterText = "$" & Format(CDec(dt.Compute("Sum([Parts/Services])", "").ToString), "#0.00")
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '*********************************************************
        Private Sub dbgReadyToInvoice_AfterFilter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles dbgReadyToInvoice.AfterFilter
            Dim iRow As Integer = 0
            Dim decTotalLabor, decTotalPartShipAHandling As Decimal

            Try
                If Me.dbgReadyToInvoice.RowCount > 0 And Me.dbgReadyToInvoice.Columns.Count > 0 Then
                    decTotalLabor = 0
                    decTotalPartShipAHandling = 0

                    'loop through each selected row
                    For iRow = 0 To Me.dbgReadyToInvoice.RowCount - 1
                        'Calculate Grand Total
                        decTotalLabor = decTotalLabor + CInt(Me.dbgReadyToInvoice.Columns("Labor").CellText(iRow).ToString)
                        decTotalPartShipAHandling = decTotalPartShipAHandling + CInt(Me.dbgReadyToInvoice.Columns("Parts/Services").CellText(iRow).ToString)
                    Next iRow

                    Me.dbgReadyToInvoice.ColumnFooters = True
                    Me.dbgReadyToInvoice.Columns("Customer").FooterText = "TOTAL:"
                    Me.dbgReadyToInvoice.Columns("S/N").FooterText = Me.dbgReadyToInvoice.RowCount
                    Me.dbgReadyToInvoice.Columns("Labor").FooterText = "$" & Format(decTotalLabor, "#0.00")
                    Me.dbgReadyToInvoice.Columns("Parts/Services").FooterText = "$" & Format(decTotalPartShipAHandling, "#0.00")
                Else
                    Me.dbgReadyToInvoice.ColumnFooters = False
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Calculate Grand Total", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnGetInvoicingRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateInvoicingRpt.Click
            Dim i As Integer

            Try
                If Me.dtpShipFr.Value >= DateAdd(DateInterval.Day, 1, Now()) Then
                    MessageBox.Show("Ship from date can't be in future.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.dtpShipFr.Value >= DateAdd(DateInterval.Day, 1, Now()) Then
                    MessageBox.Show("Ship to date can't be in future.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf CDate(Me.dtpShipFr.Value) > CDate(Me.dtpShipTo.Value) Then
                    MessageBox.Show("Ship from date can't greater than ship to date.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor
                    i = Me._objDC.CreateInvoiceReport(Format(Me.dtpShipFr.Value, "yyyy-MM-dd"), Format(Me.dtpShipTo.Value, "yyyy-MM-dd"), PSS.Core.ApplicationUser.IDuser)
                    If i > 0 Then Me.PopulateTobeInvoicingUnitsGrid()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnGetInvoicingRpt_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        '******************************************************************
        Private Sub btnReprintInvRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintInvRpt.Click
            Dim i As Integer
            Dim strSqlBoxName As String = ""

            Try
                strSqlBoxName = InputBox("Box Name:").Trim
                If strSqlBoxName.Trim.Length = 0 Then
                    Exit Sub
                Else
                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor
                    i = Me._objDC.ReprintInvoiceReport(strSqlBoxName)
                    If i > 0 Then MsgBox("Completed.", MsgBoxStyle.Information, "Information")
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnGetInvoicingRpt_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        '******************************************************************

    End Class
End Namespace