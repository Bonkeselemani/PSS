Option Explicit On 

Imports System.IO
Imports PSS.Core.[Global]
Imports System.Data

Namespace Gui.TracFone

    Public Class frmAdmin
        Inherits System.Windows.Forms.Form
        Private _objAdmin As PSS.Data.Buisness.TracFone.Admin
        Private _iOldPallettID As Integer = 0

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()
            _objAdmin = New PSS.Data.Buisness.TracFone.Admin()
            'Add any initialization after the InitializeComponent() call
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                    _objAdmin = Nothing
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Friend WithEvents btnWipRpt As System.Windows.Forms.Button
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents dtpShipTo As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpShipFr As System.Windows.Forms.DateTimePicker
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents btnEDITransRpt As System.Windows.Forms.Button
        Friend WithEvents cboModel As C1.Win.C1List.C1Combo
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents btnEDITransRptByModel As System.Windows.Forms.Button
        Friend WithEvents btnLoadSSRepCdMatGrpPmtCd As System.Windows.Forms.Button
        Friend WithEvents grbWrtyClaimData As System.Windows.Forms.GroupBox
        Friend WithEvents grpCalWrtyStatus As System.Windows.Forms.GroupBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents lblCalWrtyScanCnt As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents btnResetScanQty As System.Windows.Forms.Button
        Friend WithEvents gbCollectCSN As System.Windows.Forms.GroupBox
        Friend WithEvents btnColCSNResetQty As System.Windows.Forms.Button
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents txtColCsnImei As System.Windows.Forms.TextBox
        Friend WithEvents lblColCsnScanQty As System.Windows.Forms.Label
        Friend WithEvents tpgReports As System.Windows.Forms.TabPage
        Friend WithEvents tpgEDI As System.Windows.Forms.TabPage
        Friend WithEvents tpgEditDateCode As System.Windows.Forms.TabPage
        Friend WithEvents tpgMiscFun As System.Windows.Forms.TabPage
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents cboDirection As System.Windows.Forms.ComboBox
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents Label13 As System.Windows.Forms.Label
        Friend WithEvents lblShipFromTo As System.Windows.Forms.Label
        Friend WithEvents Label15 As System.Windows.Forms.Label
        Friend WithEvents gboxDirectionAndForm As System.Windows.Forms.GroupBox
        Friend WithEvents Label14 As System.Windows.Forms.Label
        Friend WithEvents cboShipFrom As C1.Win.C1List.C1Combo
        Friend WithEvents cboShipTo As C1.Win.C1List.C1Combo
        Friend WithEvents cboEDIModels As C1.Win.C1List.C1Combo
        Friend WithEvents dtpEDIPODate As System.Windows.Forms.DateTimePicker
        Friend WithEvents txtEDIOrderNo As System.Windows.Forms.TextBox
        Friend WithEvents lblEdiSNCnt As System.Windows.Forms.Label
        Friend WithEvents btnEDIRemoveAll As System.Windows.Forms.Button
        Friend WithEvents btnEDIRemoveOne As System.Windows.Forms.Button
        Friend WithEvents btnEDICancel As System.Windows.Forms.Button
        Friend WithEvents btnEDICreate As System.Windows.Forms.Button
        Friend WithEvents cboEDIForm As System.Windows.Forms.ComboBox
        Friend WithEvents txtEDIQty As System.Windows.Forms.TextBox
        Friend WithEvents lstEDISNs As System.Windows.Forms.ListBox
        Friend WithEvents txtEDISN As System.Windows.Forms.TextBox
        Friend WithEvents gbEDIOrder As System.Windows.Forms.GroupBox
        Friend WithEvents gbEDISNs As System.Windows.Forms.GroupBox
        Friend WithEvents gbEDIAddress As System.Windows.Forms.GroupBox
        Friend WithEvents chkEDISend944 As System.Windows.Forms.CheckBox
        Friend WithEvents btnEDI865InboudLoadFrExcel As System.Windows.Forms.Button
        Friend WithEvents tpgEditEDI As System.Windows.Forms.TabPage
        Friend WithEvents tcEDIData As System.Windows.Forms.TabControl
        Friend WithEvents tp940 As System.Windows.Forms.TabPage
        Friend WithEvents tp864 As System.Windows.Forms.TabPage
        Friend WithEvents dbg940 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btn940Activate As System.Windows.Forms.Button
        Friend WithEvents btn940InactiveOrder As System.Windows.Forms.Button
        Friend WithEvents dbg856WipOrders As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents gb864AddWipOrder As System.Windows.Forms.GroupBox
        Friend WithEvents Label16 As System.Windows.Forms.Label
        Friend WithEvents Label17 As System.Windows.Forms.Label
        Friend WithEvents Label18 As System.Windows.Forms.Label
        Friend WithEvents btn856AddWipOrder As System.Windows.Forms.Button
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents btnRefreshData As System.Windows.Forms.Button
        Friend WithEvents cboEdit856ModelList As C1.Win.C1List.C1Combo
        Friend WithEvents txtEdit856WipEntity As System.Windows.Forms.TextBox
        Friend WithEvents txtEdit856TransQty As System.Windows.Forms.TextBox
        Friend WithEvents btnFalloutCnt As System.Windows.Forms.Button
        Friend WithEvents txtCalcWrtyIMEI As System.Windows.Forms.TextBox
        Friend WithEvents lblIMEI As System.Windows.Forms.Label
        Friend WithEvents txtIMEI As System.Windows.Forms.TextBox
        Friend WithEvents lblCurPeriod As System.Windows.Forms.Label
        Friend WithEvents lblNewPeriod As System.Windows.Forms.Label
        Friend WithEvents btnUpdateWrtyData As System.Windows.Forms.Button
        Friend WithEvents tpgSplitOutboundBox As System.Windows.Forms.TabPage
        Friend WithEvents lblBoxName As System.Windows.Forms.Label
        Friend WithEvents txtBoxName As System.Windows.Forms.TextBox
        Friend WithEvents btnSplitBox As System.Windows.Forms.Button
        Friend WithEvents dbgDevicesInBox As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblDeviceIMEI As System.Windows.Forms.Label
        Friend WithEvents txtDeviceIMEI As System.Windows.Forms.TextBox
        Friend WithEvents dbgMovedDevices As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents pbxLeftArrow As System.Windows.Forms.PictureBox
        Friend WithEvents pbxRightArrow As System.Windows.Forms.PictureBox
        Friend WithEvents lblDeviceIMEIReturn As System.Windows.Forms.Label
        Friend WithEvents txtDeviceIMEIReturn As System.Windows.Forms.TextBox
        Friend WithEvents btnClearAllData As System.Windows.Forms.Button
        Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
        Friend WithEvents rbtnWipDetails As System.Windows.Forms.RadioButton
        Friend WithEvents rbtnWipSummary As System.Windows.Forms.RadioButton
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAdmin))
            Me.btnWipRpt = New System.Windows.Forms.Button()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.dtpShipTo = New System.Windows.Forms.DateTimePicker()
            Me.dtpShipFr = New System.Windows.Forms.DateTimePicker()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.btnEDITransRpt = New System.Windows.Forms.Button()
            Me.cboModel = New C1.Win.C1List.C1Combo()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.btnEDITransRptByModel = New System.Windows.Forms.Button()
            Me.grbWrtyClaimData = New System.Windows.Forms.GroupBox()
            Me.btnLoadSSRepCdMatGrpPmtCd = New System.Windows.Forms.Button()
            Me.grpCalWrtyStatus = New System.Windows.Forms.GroupBox()
            Me.btnResetScanQty = New System.Windows.Forms.Button()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.lblCalWrtyScanCnt = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtCalcWrtyIMEI = New System.Windows.Forms.TextBox()
            Me.gbCollectCSN = New System.Windows.Forms.GroupBox()
            Me.btnColCSNResetQty = New System.Windows.Forms.Button()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.lblColCsnScanQty = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.txtColCsnImei = New System.Windows.Forms.TextBox()
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.tpgReports = New System.Windows.Forms.TabPage()
            Me.GroupBox3 = New System.Windows.Forms.GroupBox()
            Me.rbtnWipSummary = New System.Windows.Forms.RadioButton()
            Me.rbtnWipDetails = New System.Windows.Forms.RadioButton()
            Me.btnFalloutCnt = New System.Windows.Forms.Button()
            Me.tpgSplitOutboundBox = New System.Windows.Forms.TabPage()
            Me.btnClearAllData = New System.Windows.Forms.Button()
            Me.txtDeviceIMEIReturn = New System.Windows.Forms.TextBox()
            Me.lblDeviceIMEIReturn = New System.Windows.Forms.Label()
            Me.pbxRightArrow = New System.Windows.Forms.PictureBox()
            Me.pbxLeftArrow = New System.Windows.Forms.PictureBox()
            Me.dbgMovedDevices = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.txtDeviceIMEI = New System.Windows.Forms.TextBox()
            Me.lblDeviceIMEI = New System.Windows.Forms.Label()
            Me.dbgDevicesInBox = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnSplitBox = New System.Windows.Forms.Button()
            Me.txtBoxName = New System.Windows.Forms.TextBox()
            Me.lblBoxName = New System.Windows.Forms.Label()
            Me.tpgEditEDI = New System.Windows.Forms.TabPage()
            Me.tcEDIData = New System.Windows.Forms.TabControl()
            Me.tp940 = New System.Windows.Forms.TabPage()
            Me.btnRefreshData = New System.Windows.Forms.Button()
            Me.dbg940 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btn940Activate = New System.Windows.Forms.Button()
            Me.btn940InactiveOrder = New System.Windows.Forms.Button()
            Me.tp864 = New System.Windows.Forms.TabPage()
            Me.gb864AddWipOrder = New System.Windows.Forms.GroupBox()
            Me.btn856AddWipOrder = New System.Windows.Forms.Button()
            Me.Label17 = New System.Windows.Forms.Label()
            Me.txtEdit856WipEntity = New System.Windows.Forms.TextBox()
            Me.Label18 = New System.Windows.Forms.Label()
            Me.txtEdit856TransQty = New System.Windows.Forms.TextBox()
            Me.cboEdit856ModelList = New C1.Win.C1List.C1Combo()
            Me.Label16 = New System.Windows.Forms.Label()
            Me.dbg856WipOrders = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.tpgEditDateCode = New System.Windows.Forms.TabPage()
            Me.btnUpdateWrtyData = New System.Windows.Forms.Button()
            Me.lblNewPeriod = New System.Windows.Forms.Label()
            Me.lblCurPeriod = New System.Windows.Forms.Label()
            Me.txtIMEI = New System.Windows.Forms.TextBox()
            Me.lblIMEI = New System.Windows.Forms.Label()
            Me.tpgEDI = New System.Windows.Forms.TabPage()
            Me.btnEDI865InboudLoadFrExcel = New System.Windows.Forms.Button()
            Me.gboxDirectionAndForm = New System.Windows.Forms.GroupBox()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.cboDirection = New System.Windows.Forms.ComboBox()
            Me.cboEDIForm = New System.Windows.Forms.ComboBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.gbEDIOrder = New System.Windows.Forms.GroupBox()
            Me.dtpEDIPODate = New System.Windows.Forms.DateTimePicker()
            Me.cboEDIModels = New C1.Win.C1List.C1Combo()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.txtEDIOrderNo = New System.Windows.Forms.TextBox()
            Me.Label13 = New System.Windows.Forms.Label()
            Me.chkEDISend944 = New System.Windows.Forms.CheckBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.txtEDIQty = New System.Windows.Forms.TextBox()
            Me.gbEDISNs = New System.Windows.Forms.GroupBox()
            Me.txtEDISN = New System.Windows.Forms.TextBox()
            Me.lblEdiSNCnt = New System.Windows.Forms.Label()
            Me.Label14 = New System.Windows.Forms.Label()
            Me.btnEDIRemoveAll = New System.Windows.Forms.Button()
            Me.btnEDIRemoveOne = New System.Windows.Forms.Button()
            Me.lstEDISNs = New System.Windows.Forms.ListBox()
            Me.gbEDIAddress = New System.Windows.Forms.GroupBox()
            Me.cboShipTo = New C1.Win.C1List.C1Combo()
            Me.Label15 = New System.Windows.Forms.Label()
            Me.cboShipFrom = New C1.Win.C1List.C1Combo()
            Me.lblShipFromTo = New System.Windows.Forms.Label()
            Me.btnEDICancel = New System.Windows.Forms.Button()
            Me.btnEDICreate = New System.Windows.Forms.Button()
            Me.tpgMiscFun = New System.Windows.Forms.TabPage()
            Me.GroupBox1.SuspendLayout()
            CType(Me.cboModel, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox2.SuspendLayout()
            Me.grbWrtyClaimData.SuspendLayout()
            Me.grpCalWrtyStatus.SuspendLayout()
            Me.gbCollectCSN.SuspendLayout()
            Me.TabControl1.SuspendLayout()
            Me.tpgReports.SuspendLayout()
            Me.GroupBox3.SuspendLayout()
            Me.tpgSplitOutboundBox.SuspendLayout()
            CType(Me.dbgMovedDevices, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dbgDevicesInBox, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpgEditEDI.SuspendLayout()
            Me.tcEDIData.SuspendLayout()
            Me.tp940.SuspendLayout()
            CType(Me.dbg940, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tp864.SuspendLayout()
            Me.gb864AddWipOrder.SuspendLayout()
            CType(Me.cboEdit856ModelList, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dbg856WipOrders, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpgEditDateCode.SuspendLayout()
            Me.tpgEDI.SuspendLayout()
            Me.gboxDirectionAndForm.SuspendLayout()
            Me.gbEDIOrder.SuspendLayout()
            CType(Me.cboEDIModels, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.gbEDISNs.SuspendLayout()
            Me.gbEDIAddress.SuspendLayout()
            CType(Me.cboShipTo, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboShipFrom, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpgMiscFun.SuspendLayout()
            Me.SuspendLayout()
            '
            'btnWipRpt
            '
            Me.btnWipRpt.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnWipRpt.ForeColor = System.Drawing.Color.White
            Me.btnWipRpt.Location = New System.Drawing.Point(16, 48)
            Me.btnWipRpt.Name = "btnWipRpt"
            Me.btnWipRpt.Size = New System.Drawing.Size(208, 24)
            Me.btnWipRpt.TabIndex = 3
            Me.btnWipRpt.Text = "WIP Report"
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(272, 16)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(74, 19)
            Me.Label2.TabIndex = 73
            Me.Label2.Text = "To Date:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label12
            '
            Me.Label12.BackColor = System.Drawing.Color.Transparent
            Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label12.ForeColor = System.Drawing.Color.White
            Me.Label12.Location = New System.Drawing.Point(24, 16)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(94, 19)
            Me.Label12.TabIndex = 71
            Me.Label12.Text = "From Date:"
            Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpShipTo
            '
            Me.dtpShipTo.CustomFormat = "yyyy-MM-dd"
            Me.dtpShipTo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpShipTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpShipTo.Location = New System.Drawing.Point(352, 16)
            Me.dtpShipTo.Name = "dtpShipTo"
            Me.dtpShipTo.Size = New System.Drawing.Size(141, 21)
            Me.dtpShipTo.TabIndex = 72
            Me.dtpShipTo.Value = New Date(2007, 3, 16, 0, 0, 0, 0)
            '
            'dtpShipFr
            '
            Me.dtpShipFr.CustomFormat = "yyyy-MM-dd"
            Me.dtpShipFr.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpShipFr.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpShipFr.Location = New System.Drawing.Point(120, 16)
            Me.dtpShipFr.Name = "dtpShipFr"
            Me.dtpShipFr.Size = New System.Drawing.Size(140, 21)
            Me.dtpShipFr.TabIndex = 70
            Me.dtpShipFr.Value = New Date(2007, 3, 16, 0, 0, 0, 0)
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.dtpShipFr, Me.dtpShipTo, Me.Label2, Me.Label12})
            Me.GroupBox1.Location = New System.Drawing.Point(16, 8)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(527, 47)
            Me.GroupBox1.TabIndex = 74
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Visible = False
            '
            'btnEDITransRpt
            '
            Me.btnEDITransRpt.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnEDITransRpt.ForeColor = System.Drawing.Color.White
            Me.btnEDITransRpt.Location = New System.Drawing.Point(16, 184)
            Me.btnEDITransRpt.Name = "btnEDITransRpt"
            Me.btnEDITransRpt.Size = New System.Drawing.Size(208, 24)
            Me.btnEDITransRpt.TabIndex = 75
            Me.btnEDITransRpt.Text = "EDI Transaction Report (90 days)"
            '
            'cboModel
            '
            Me.cboModel.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboModel.AutoCompletion = True
            Me.cboModel.AutoDropDown = True
            Me.cboModel.AutoSelect = True
            Me.cboModel.Caption = ""
            Me.cboModel.CaptionHeight = 17
            Me.cboModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboModel.ColumnCaptionHeight = 17
            Me.cboModel.ColumnFooterHeight = 17
            Me.cboModel.ColumnHeaders = False
            Me.cboModel.ContentHeight = 15
            Me.cboModel.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboModel.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboModel.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboModel.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboModel.EditorHeight = 15
            Me.cboModel.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboModel.ItemHeight = 15
            Me.cboModel.Location = New System.Drawing.Point(8, 24)
            Me.cboModel.MatchEntryTimeout = CType(2000, Long)
            Me.cboModel.MaxDropDownItems = CType(10, Short)
            Me.cboModel.MaxLength = 32767
            Me.cboModel.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModel.Name = "cboModel"
            Me.cboModel.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModel.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModel.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModel.Size = New System.Drawing.Size(232, 21)
            Me.cboModel.TabIndex = 88
            Me.cboModel.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(8, 15)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(104, 8)
            Me.Label1.TabIndex = 89
            Me.Label1.Text = "Model :"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboModel, Me.Label1, Me.btnEDITransRptByModel})
            Me.GroupBox2.Location = New System.Drawing.Point(16, 224)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(248, 88)
            Me.GroupBox2.TabIndex = 90
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Visible = False
            '
            'btnEDITransRptByModel
            '
            Me.btnEDITransRptByModel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnEDITransRptByModel.ForeColor = System.Drawing.Color.White
            Me.btnEDITransRptByModel.Location = New System.Drawing.Point(8, 56)
            Me.btnEDITransRptByModel.Name = "btnEDITransRptByModel"
            Me.btnEDITransRptByModel.Size = New System.Drawing.Size(232, 24)
            Me.btnEDITransRptByModel.TabIndex = 91
            Me.btnEDITransRptByModel.Text = "EDI Transaction Report (365 Days)"
            '
            'grbWrtyClaimData
            '
            Me.grbWrtyClaimData.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnLoadSSRepCdMatGrpPmtCd})
            Me.grbWrtyClaimData.Location = New System.Drawing.Point(16, 16)
            Me.grbWrtyClaimData.Name = "grbWrtyClaimData"
            Me.grbWrtyClaimData.Size = New System.Drawing.Size(248, 64)
            Me.grbWrtyClaimData.TabIndex = 91
            Me.grbWrtyClaimData.TabStop = False
            Me.grbWrtyClaimData.Visible = False
            '
            'btnLoadSSRepCdMatGrpPmtCd
            '
            Me.btnLoadSSRepCdMatGrpPmtCd.BackColor = System.Drawing.Color.SeaGreen
            Me.btnLoadSSRepCdMatGrpPmtCd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnLoadSSRepCdMatGrpPmtCd.ForeColor = System.Drawing.Color.White
            Me.btnLoadSSRepCdMatGrpPmtCd.Location = New System.Drawing.Point(8, 16)
            Me.btnLoadSSRepCdMatGrpPmtCd.Name = "btnLoadSSRepCdMatGrpPmtCd"
            Me.btnLoadSSRepCdMatGrpPmtCd.Size = New System.Drawing.Size(232, 32)
            Me.btnLoadSSRepCdMatGrpPmtCd.TabIndex = 91
            Me.btnLoadSSRepCdMatGrpPmtCd.Text = "Load Samsung Repair code, Material Group and Payment Code"
            '
            'grpCalWrtyStatus
            '
            Me.grpCalWrtyStatus.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnResetScanQty, Me.Label4, Me.lblCalWrtyScanCnt, Me.Label3, Me.txtCalcWrtyIMEI})
            Me.grpCalWrtyStatus.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grpCalWrtyStatus.ForeColor = System.Drawing.Color.White
            Me.grpCalWrtyStatus.Location = New System.Drawing.Point(448, 256)
            Me.grpCalWrtyStatus.Name = "grpCalWrtyStatus"
            Me.grpCalWrtyStatus.Size = New System.Drawing.Size(376, 96)
            Me.grpCalWrtyStatus.TabIndex = 92
            Me.grpCalWrtyStatus.TabStop = False
            Me.grpCalWrtyStatus.Text = "Calculate Warranty"
            Me.grpCalWrtyStatus.Visible = False
            '
            'btnResetScanQty
            '
            Me.btnResetScanQty.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnResetScanQty.ForeColor = System.Drawing.Color.White
            Me.btnResetScanQty.Location = New System.Drawing.Point(208, 62)
            Me.btnResetScanQty.Name = "btnResetScanQty"
            Me.btnResetScanQty.Size = New System.Drawing.Size(72, 24)
            Me.btnResetScanQty.TabIndex = 94
            Me.btnResetScanQty.Text = "Reset Qty"
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(296, 18)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(72, 16)
            Me.Label4.TabIndex = 93
            Me.Label4.Text = "Scan Qty"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblCalWrtyScanCnt
            '
            Me.lblCalWrtyScanCnt.BackColor = System.Drawing.Color.Transparent
            Me.lblCalWrtyScanCnt.Font = New System.Drawing.Font("Tahoma", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCalWrtyScanCnt.ForeColor = System.Drawing.Color.White
            Me.lblCalWrtyScanCnt.Location = New System.Drawing.Point(301, 40)
            Me.lblCalWrtyScanCnt.Name = "lblCalWrtyScanCnt"
            Me.lblCalWrtyScanCnt.Size = New System.Drawing.Size(64, 40)
            Me.lblCalWrtyScanCnt.TabIndex = 92
            Me.lblCalWrtyScanCnt.Text = "0"
            Me.lblCalWrtyScanCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(8, 32)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(80, 20)
            Me.Label3.TabIndex = 91
            Me.Label3.Text = "IMEI/MEID:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCalcWrtyIMEI
            '
            Me.txtCalcWrtyIMEI.Location = New System.Drawing.Point(88, 32)
            Me.txtCalcWrtyIMEI.Name = "txtCalcWrtyIMEI"
            Me.txtCalcWrtyIMEI.Size = New System.Drawing.Size(192, 23)
            Me.txtCalcWrtyIMEI.TabIndex = 90
            Me.txtCalcWrtyIMEI.Text = ""
            '
            'gbCollectCSN
            '
            Me.gbCollectCSN.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnColCSNResetQty, Me.Label5, Me.lblColCsnScanQty, Me.Label7, Me.txtColCsnImei})
            Me.gbCollectCSN.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbCollectCSN.ForeColor = System.Drawing.Color.White
            Me.gbCollectCSN.Location = New System.Drawing.Point(448, 368)
            Me.gbCollectCSN.Name = "gbCollectCSN"
            Me.gbCollectCSN.Size = New System.Drawing.Size(376, 96)
            Me.gbCollectCSN.TabIndex = 93
            Me.gbCollectCSN.TabStop = False
            Me.gbCollectCSN.Text = "Collect ESN/CSN"
            Me.gbCollectCSN.Visible = False
            '
            'btnColCSNResetQty
            '
            Me.btnColCSNResetQty.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnColCSNResetQty.ForeColor = System.Drawing.Color.White
            Me.btnColCSNResetQty.Location = New System.Drawing.Point(208, 62)
            Me.btnColCSNResetQty.Name = "btnColCSNResetQty"
            Me.btnColCSNResetQty.Size = New System.Drawing.Size(72, 24)
            Me.btnColCSNResetQty.TabIndex = 94
            Me.btnColCSNResetQty.Text = "Reset Qty"
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.White
            Me.Label5.Location = New System.Drawing.Point(296, 18)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(72, 16)
            Me.Label5.TabIndex = 93
            Me.Label5.Text = "Scan Qty"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblColCsnScanQty
            '
            Me.lblColCsnScanQty.BackColor = System.Drawing.Color.Transparent
            Me.lblColCsnScanQty.Font = New System.Drawing.Font("Tahoma", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblColCsnScanQty.ForeColor = System.Drawing.Color.White
            Me.lblColCsnScanQty.Location = New System.Drawing.Point(301, 40)
            Me.lblColCsnScanQty.Name = "lblColCsnScanQty"
            Me.lblColCsnScanQty.Size = New System.Drawing.Size(64, 40)
            Me.lblColCsnScanQty.TabIndex = 92
            Me.lblColCsnScanQty.Text = "0"
            Me.lblColCsnScanQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label7
            '
            Me.Label7.BackColor = System.Drawing.Color.Transparent
            Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.White
            Me.Label7.Location = New System.Drawing.Point(8, 32)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(80, 20)
            Me.Label7.TabIndex = 91
            Me.Label7.Text = "IMEI/MEID:"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtColCsnImei
            '
            Me.txtColCsnImei.Location = New System.Drawing.Point(88, 32)
            Me.txtColCsnImei.Name = "txtColCsnImei"
            Me.txtColCsnImei.Size = New System.Drawing.Size(192, 23)
            Me.txtColCsnImei.TabIndex = 90
            Me.txtColCsnImei.Text = ""
            '
            'TabControl1
            '
            Me.TabControl1.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpgReports, Me.tpgSplitOutboundBox, Me.tpgEditEDI, Me.tpgEditDateCode, Me.tpgEDI, Me.tpgMiscFun})
            Me.TabControl1.Location = New System.Drawing.Point(16, 16)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(912, 560)
            Me.TabControl1.TabIndex = 94
            '
            'tpgReports
            '
            Me.tpgReports.BackColor = System.Drawing.Color.SteelBlue
            Me.tpgReports.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox3, Me.btnFalloutCnt, Me.btnEDITransRpt, Me.GroupBox2, Me.GroupBox1})
            Me.tpgReports.Location = New System.Drawing.Point(4, 22)
            Me.tpgReports.Name = "tpgReports"
            Me.tpgReports.Size = New System.Drawing.Size(904, 534)
            Me.tpgReports.TabIndex = 0
            Me.tpgReports.Text = "Reports"
            '
            'GroupBox3
            '
            Me.GroupBox3.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbtnWipSummary, Me.rbtnWipDetails, Me.btnWipRpt})
            Me.GroupBox3.Location = New System.Drawing.Point(16, 64)
            Me.GroupBox3.Name = "GroupBox3"
            Me.GroupBox3.Size = New System.Drawing.Size(240, 88)
            Me.GroupBox3.TabIndex = 92
            Me.GroupBox3.TabStop = False
            '
            'rbtnWipSummary
            '
            Me.rbtnWipSummary.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rbtnWipSummary.ForeColor = System.Drawing.Color.White
            Me.rbtnWipSummary.Location = New System.Drawing.Point(120, 16)
            Me.rbtnWipSummary.Name = "rbtnWipSummary"
            Me.rbtnWipSummary.Size = New System.Drawing.Size(88, 24)
            Me.rbtnWipSummary.TabIndex = 2
            Me.rbtnWipSummary.Text = "Summary"
            '
            'rbtnWipDetails
            '
            Me.rbtnWipDetails.Checked = True
            Me.rbtnWipDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rbtnWipDetails.ForeColor = System.Drawing.Color.White
            Me.rbtnWipDetails.Location = New System.Drawing.Point(18, 16)
            Me.rbtnWipDetails.Name = "rbtnWipDetails"
            Me.rbtnWipDetails.Size = New System.Drawing.Size(64, 24)
            Me.rbtnWipDetails.TabIndex = 1
            Me.rbtnWipDetails.TabStop = True
            Me.rbtnWipDetails.Text = "Details"
            '
            'btnFalloutCnt
            '
            Me.btnFalloutCnt.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnFalloutCnt.ForeColor = System.Drawing.Color.White
            Me.btnFalloutCnt.Location = New System.Drawing.Point(272, 72)
            Me.btnFalloutCnt.Name = "btnFalloutCnt"
            Me.btnFalloutCnt.Size = New System.Drawing.Size(208, 24)
            Me.btnFalloutCnt.TabIndex = 91
            Me.btnFalloutCnt.Text = "Fall Out Count Report"
            Me.btnFalloutCnt.Visible = False
            '
            'tpgSplitOutboundBox
            '
            Me.tpgSplitOutboundBox.BackColor = System.Drawing.Color.SteelBlue
            Me.tpgSplitOutboundBox.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnClearAllData, Me.txtDeviceIMEIReturn, Me.lblDeviceIMEIReturn, Me.pbxRightArrow, Me.pbxLeftArrow, Me.dbgMovedDevices, Me.txtDeviceIMEI, Me.lblDeviceIMEI, Me.dbgDevicesInBox, Me.btnSplitBox, Me.txtBoxName, Me.lblBoxName})
            Me.tpgSplitOutboundBox.Location = New System.Drawing.Point(4, 22)
            Me.tpgSplitOutboundBox.Name = "tpgSplitOutboundBox"
            Me.tpgSplitOutboundBox.Size = New System.Drawing.Size(904, 534)
            Me.tpgSplitOutboundBox.TabIndex = 5
            Me.tpgSplitOutboundBox.Text = "Split Outbound Box"
            '
            'btnClearAllData
            '
            Me.btnClearAllData.BackColor = System.Drawing.Color.Green
            Me.btnClearAllData.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClearAllData.ForeColor = System.Drawing.Color.White
            Me.btnClearAllData.Location = New System.Drawing.Point(80, 424)
            Me.btnClearAllData.Name = "btnClearAllData"
            Me.btnClearAllData.Size = New System.Drawing.Size(160, 24)
            Me.btnClearAllData.TabIndex = 118
            Me.btnClearAllData.Text = "Clear All Data"
            '
            'txtDeviceIMEIReturn
            '
            Me.txtDeviceIMEIReturn.BackColor = System.Drawing.Color.FloralWhite
            Me.txtDeviceIMEIReturn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtDeviceIMEIReturn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDeviceIMEIReturn.ForeColor = System.Drawing.Color.Blue
            Me.txtDeviceIMEIReturn.Location = New System.Drawing.Point(368, 160)
            Me.txtDeviceIMEIReturn.Name = "txtDeviceIMEIReturn"
            Me.txtDeviceIMEIReturn.Size = New System.Drawing.Size(160, 21)
            Me.txtDeviceIMEIReturn.TabIndex = 117
            Me.txtDeviceIMEIReturn.Text = ""
            '
            'lblDeviceIMEIReturn
            '
            Me.lblDeviceIMEIReturn.BackColor = System.Drawing.Color.Transparent
            Me.lblDeviceIMEIReturn.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDeviceIMEIReturn.ForeColor = System.Drawing.Color.White
            Me.lblDeviceIMEIReturn.Location = New System.Drawing.Point(352, 136)
            Me.lblDeviceIMEIReturn.Name = "lblDeviceIMEIReturn"
            Me.lblDeviceIMEIReturn.Size = New System.Drawing.Size(184, 19)
            Me.lblDeviceIMEIReturn.TabIndex = 116
            Me.lblDeviceIMEIReturn.Text = "IMEI of Device to Return"
            Me.lblDeviceIMEIReturn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'pbxRightArrow
            '
            Me.pbxRightArrow.Image = CType(resources.GetObject("pbxRightArrow.Image"), System.Drawing.Bitmap)
            Me.pbxRightArrow.Location = New System.Drawing.Point(544, 56)
            Me.pbxRightArrow.Name = "pbxRightArrow"
            Me.pbxRightArrow.Size = New System.Drawing.Size(32, 32)
            Me.pbxRightArrow.TabIndex = 115
            Me.pbxRightArrow.TabStop = False
            '
            'pbxLeftArrow
            '
            Me.pbxLeftArrow.Image = CType(resources.GetObject("pbxLeftArrow.Image"), System.Drawing.Bitmap)
            Me.pbxLeftArrow.Location = New System.Drawing.Point(320, 128)
            Me.pbxLeftArrow.Name = "pbxLeftArrow"
            Me.pbxLeftArrow.Size = New System.Drawing.Size(32, 40)
            Me.pbxLeftArrow.TabIndex = 114
            Me.pbxLeftArrow.TabStop = False
            '
            'dbgMovedDevices
            '
            Me.dbgMovedDevices.AllowFilter = False
            Me.dbgMovedDevices.AllowUpdate = False
            Me.dbgMovedDevices.AlternatingRows = True
            Me.dbgMovedDevices.CaptionHeight = 17
            Me.dbgMovedDevices.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgMovedDevices.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.dbgMovedDevices.Location = New System.Drawing.Point(592, 64)
            Me.dbgMovedDevices.Name = "dbgMovedDevices"
            Me.dbgMovedDevices.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgMovedDevices.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgMovedDevices.PreviewInfo.ZoomFactor = 75
            Me.dbgMovedDevices.Size = New System.Drawing.Size(280, 336)
            Me.dbgMovedDevices.TabIndex = 113
            Me.dbgMovedDevices.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{Font:Tahoma, 9.75pt, style=Bold;AlignHorz:Near;ForeColor:White;" & _
            "BackColor:CadetBlue;}Normal{BackColor:SteelBlue;}Selected{ForeColor:HighlightTex" & _
            "t;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{}Style16{}Styl" & _
            "e17{}Style10{AlignHorz:Near;}Style11{}OddRow{BackColor:LightSteelBlue;}Style13{}" & _
            "Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}RecordSelecto" & _
            "r{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:InactiveCaptio" & _
            "nText;BackColor:InactiveCaption;}EvenRow{BackColor:NavajoWhite;}Heading{Wrap:Tru" & _
            "e;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Ce" & _
            "nter;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, style=Bold;ForeColor:Red;Back" & _
            "Color:White;}Style4{}Style9{}Style8{}Style5{}Group{AlignVert:Center;Border:None," & _
            ",0, 0, 0, 0;BackColor:ControlDark;}Style7{}Style6{}Style1{}Style3{}Style2{}</Dat" & _
            "a></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" AlternatingRowStyle=""T" & _
            "rue"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" Marquee" & _
            "Style=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalSc" & _
            "rollGroup=""1"" HorizontalScrollGroup=""1""><Height>332</Height><CaptionStyle parent" & _
            "=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyl" & _
            "e parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13""" & _
            " /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Sty" & _
            "le12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""" & _
            "HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddR" & _
            "owStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelecto" & _
            "r"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""" & _
            "Normal"" me=""Style1"" /><ClientRect>0, 0, 276, 332</ClientRect><BorderSide>0</Bord" & _
            "erSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits" & _
            "><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading""" & _
            " /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" />" & _
            "<Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><" & _
            "Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><" & _
            "Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style" & _
            " parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" />" & _
            "<Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><ho" & _
            "rzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSe" & _
            "lWidth><ClientArea>0, 0, 276, 332</ClientArea><PrintPageHeaderStyle parent="""" me" & _
            "=""Style20"" /><PrintPageFooterStyle parent="""" me=""Style21"" /></Blob>"
            '
            'txtDeviceIMEI
            '
            Me.txtDeviceIMEI.BackColor = System.Drawing.Color.FloralWhite
            Me.txtDeviceIMEI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtDeviceIMEI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDeviceIMEI.ForeColor = System.Drawing.Color.Blue
            Me.txtDeviceIMEI.Location = New System.Drawing.Point(368, 64)
            Me.txtDeviceIMEI.Name = "txtDeviceIMEI"
            Me.txtDeviceIMEI.Size = New System.Drawing.Size(160, 21)
            Me.txtDeviceIMEI.TabIndex = 111
            Me.txtDeviceIMEI.Text = ""
            '
            'lblDeviceIMEI
            '
            Me.lblDeviceIMEI.BackColor = System.Drawing.Color.Transparent
            Me.lblDeviceIMEI.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDeviceIMEI.ForeColor = System.Drawing.Color.White
            Me.lblDeviceIMEI.Location = New System.Drawing.Point(360, 40)
            Me.lblDeviceIMEI.Name = "lblDeviceIMEI"
            Me.lblDeviceIMEI.Size = New System.Drawing.Size(168, 19)
            Me.lblDeviceIMEI.TabIndex = 109
            Me.lblDeviceIMEI.Text = "IMEI of Device to Move"
            Me.lblDeviceIMEI.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dbgDevicesInBox
            '
            Me.dbgDevicesInBox.AllowUpdate = False
            Me.dbgDevicesInBox.AlternatingRows = True
            Me.dbgDevicesInBox.CaptionHeight = 17
            Me.dbgDevicesInBox.FilterBar = True
            Me.dbgDevicesInBox.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgDevicesInBox.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.dbgDevicesInBox.Location = New System.Drawing.Point(16, 64)
            Me.dbgDevicesInBox.Name = "dbgDevicesInBox"
            Me.dbgDevicesInBox.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgDevicesInBox.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgDevicesInBox.PreviewInfo.ZoomFactor = 75
            Me.dbgDevicesInBox.Size = New System.Drawing.Size(280, 336)
            Me.dbgDevicesInBox.TabIndex = 108
            Me.dbgDevicesInBox.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{Font:Tahoma, 9.75pt, style=Bold;AlignHorz:Near;ForeColor:White;" & _
            "BackColor:CadetBlue;}Normal{BackColor:SteelBlue;}Selected{ForeColor:HighlightTex" & _
            "t;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{}Style16{}Styl" & _
            "e17{}Style10{AlignHorz:Near;}Style11{}OddRow{BackColor:LightSteelBlue;}Style13{}" & _
            "Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}RecordSelecto" & _
            "r{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:InactiveCaptio" & _
            "nText;BackColor:InactiveCaption;}EvenRow{BackColor:NavajoWhite;}Heading{Wrap:Tru" & _
            "e;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Con" & _
            "trol;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, style=Bold;ForeColor:Red;Back" & _
            "Color:White;}Style4{}Style9{}Style8{}Style5{}Group{BackColor:ControlDark;Border:" & _
            "None,,0, 0, 0, 0;AlignVert:Center;}Style7{}Style6{}Style1{}Style3{}Style2{}</Dat" & _
            "a></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" AlternatingRowStyle=""T" & _
            "rue"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterB" & _
            "ar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidt" & _
            "h=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>332</Height><Ca" & _
            "ptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style" & _
            "5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""Filter" & _
            "Bar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle paren" & _
            "t=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLight" & _
            "RowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me" & _
            "=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle pare" & _
            "nt=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" " & _
            "/><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 276, 332</ClientRect><B" & _
            "orderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.M" & _
            "ergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Nor" & _
            "mal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading" & _
            """ me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" " & _
            "me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""" & _
            "HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=" & _
            """OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" " & _
            "me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>" & _
            "1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth" & _
            ">17</DefaultRecSelWidth><ClientArea>0, 0, 276, 332</ClientArea><PrintPageHeaderS" & _
            "tyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""Style21"" /></B" & _
            "lob>"
            '
            'btnSplitBox
            '
            Me.btnSplitBox.BackColor = System.Drawing.Color.Crimson
            Me.btnSplitBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSplitBox.ForeColor = System.Drawing.Color.White
            Me.btnSplitBox.Location = New System.Drawing.Point(656, 424)
            Me.btnSplitBox.Name = "btnSplitBox"
            Me.btnSplitBox.Size = New System.Drawing.Size(160, 24)
            Me.btnSplitBox.TabIndex = 107
            Me.btnSplitBox.Text = "Split Box"
            '
            'txtBoxName
            '
            Me.txtBoxName.BackColor = System.Drawing.Color.FloralWhite
            Me.txtBoxName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtBoxName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtBoxName.ForeColor = System.Drawing.Color.Blue
            Me.txtBoxName.Location = New System.Drawing.Point(96, 24)
            Me.txtBoxName.Name = "txtBoxName"
            Me.txtBoxName.Size = New System.Drawing.Size(200, 21)
            Me.txtBoxName.TabIndex = 96
            Me.txtBoxName.Text = ""
            '
            'lblBoxName
            '
            Me.lblBoxName.BackColor = System.Drawing.Color.Transparent
            Me.lblBoxName.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBoxName.ForeColor = System.Drawing.Color.White
            Me.lblBoxName.Location = New System.Drawing.Point(16, 24)
            Me.lblBoxName.Name = "lblBoxName"
            Me.lblBoxName.Size = New System.Drawing.Size(80, 19)
            Me.lblBoxName.TabIndex = 72
            Me.lblBoxName.Text = "Box Name:"
            Me.lblBoxName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'tpgEditEDI
            '
            Me.tpgEditEDI.BackColor = System.Drawing.Color.SteelBlue
            Me.tpgEditEDI.Controls.AddRange(New System.Windows.Forms.Control() {Me.tcEDIData})
            Me.tpgEditEDI.Location = New System.Drawing.Point(4, 22)
            Me.tpgEditEDI.Name = "tpgEditEDI"
            Me.tpgEditEDI.Size = New System.Drawing.Size(904, 534)
            Me.tpgEditEDI.TabIndex = 4
            Me.tpgEditEDI.Text = "Edit EDI Data"
            '
            'tcEDIData
            '
            Me.tcEDIData.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.tcEDIData.Controls.AddRange(New System.Windows.Forms.Control() {Me.tp940, Me.tp864})
            Me.tcEDIData.Location = New System.Drawing.Point(8, 24)
            Me.tcEDIData.Name = "tcEDIData"
            Me.tcEDIData.SelectedIndex = 0
            Me.tcEDIData.Size = New System.Drawing.Size(880, 488)
            Me.tcEDIData.TabIndex = 7
            '
            'tp940
            '
            Me.tp940.BackColor = System.Drawing.Color.SteelBlue
            Me.tp940.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRefreshData, Me.dbg940, Me.btn940Activate, Me.btn940InactiveOrder})
            Me.tp940.Location = New System.Drawing.Point(4, 22)
            Me.tp940.Name = "tp940"
            Me.tp940.Size = New System.Drawing.Size(872, 518)
            Me.tp940.TabIndex = 0
            Me.tp940.Text = "940-Transfer Orders"
            '
            'btnRefreshData
            '
            Me.btnRefreshData.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnRefreshData.BackColor = System.Drawing.Color.SteelBlue
            Me.btnRefreshData.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRefreshData.ForeColor = System.Drawing.Color.White
            Me.btnRefreshData.Location = New System.Drawing.Point(720, 112)
            Me.btnRefreshData.Name = "btnRefreshData"
            Me.btnRefreshData.Size = New System.Drawing.Size(136, 23)
            Me.btnRefreshData.TabIndex = 10
            Me.btnRefreshData.Text = "Refresh Data"
            '
            'dbg940
            '
            Me.dbg940.AllowUpdate = False
            Me.dbg940.AlternatingRows = True
            Me.dbg940.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbg940.Caption = "940-Transfer Orders"
            Me.dbg940.CaptionHeight = 17
            Me.dbg940.FilterBar = True
            Me.dbg940.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbg940.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.dbg940.Location = New System.Drawing.Point(24, 8)
            Me.dbg940.Name = "dbg940"
            Me.dbg940.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbg940.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbg940.PreviewInfo.ZoomFactor = 75
            Me.dbg940.Size = New System.Drawing.Size(680, 488)
            Me.dbg940.TabIndex = 9
            Me.dbg940.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{Font:Tahoma, 9.75pt, style=Bold;AlignHorz:Near;ForeColor:White;" & _
            "BackColor:CadetBlue;}Normal{BackColor:SteelBlue;}Selected{ForeColor:HighlightTex" & _
            "t;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{}Style16{}Styl" & _
            "e17{}Style10{AlignHorz:Near;}Style11{}OddRow{BackColor:LightSteelBlue;}Style13{}" & _
            "Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}RecordSelecto" & _
            "r{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:InactiveCaptio" & _
            "nText;BackColor:InactiveCaption;}EvenRow{BackColor:NavajoWhite;}Heading{Wrap:Tru" & _
            "e;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Ce" & _
            "nter;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, style=Bold;ForeColor:Red;Back" & _
            "Color:White;}Style4{}Style9{}Style8{}Style5{}Group{AlignVert:Center;Border:None," & _
            ",0, 0, 0, 0;BackColor:ControlDark;}Style7{}Style6{}Style1{}Style3{}Style2{}</Dat" & _
            "a></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" AlternatingRowStyle=""T" & _
            "rue"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterB" & _
            "ar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidt" & _
            "h=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>467</Height><Ca" & _
            "ptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style" & _
            "5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""Filter" & _
            "Bar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle paren" & _
            "t=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLight" & _
            "RowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me" & _
            "=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle pare" & _
            "nt=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" " & _
            "/><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 17, 676, 467</ClientRect><" & _
            "BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid." & _
            "MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""No" & _
            "rmal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Headin" & _
            "g"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal""" & _
            " me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=" & _
            """HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me" & _
            "=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal""" & _
            " me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits" & _
            ">1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidt" & _
            "h>17</DefaultRecSelWidth><ClientArea>0, 0, 676, 484</ClientArea><PrintPageHeader" & _
            "Style parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""Style21"" /></" & _
            "Blob>"
            '
            'btn940Activate
            '
            Me.btn940Activate.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btn940Activate.BackColor = System.Drawing.Color.Green
            Me.btn940Activate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btn940Activate.ForeColor = System.Drawing.Color.White
            Me.btn940Activate.Location = New System.Drawing.Point(720, 16)
            Me.btn940Activate.Name = "btn940Activate"
            Me.btn940Activate.Size = New System.Drawing.Size(136, 23)
            Me.btn940Activate.TabIndex = 2
            Me.btn940Activate.Text = "Activate Orders"
            '
            'btn940InactiveOrder
            '
            Me.btn940InactiveOrder.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btn940InactiveOrder.BackColor = System.Drawing.Color.DimGray
            Me.btn940InactiveOrder.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btn940InactiveOrder.ForeColor = System.Drawing.Color.White
            Me.btn940InactiveOrder.Location = New System.Drawing.Point(720, 64)
            Me.btn940InactiveOrder.Name = "btn940InactiveOrder"
            Me.btn940InactiveOrder.Size = New System.Drawing.Size(136, 23)
            Me.btn940InactiveOrder.TabIndex = 1
            Me.btn940InactiveOrder.Text = "Inactivate Orders"
            '
            'tp864
            '
            Me.tp864.BackColor = System.Drawing.Color.SteelBlue
            Me.tp864.Controls.AddRange(New System.Windows.Forms.Control() {Me.gb864AddWipOrder, Me.dbg856WipOrders})
            Me.tp864.Location = New System.Drawing.Point(4, 22)
            Me.tp864.Name = "tp864"
            Me.tp864.Size = New System.Drawing.Size(872, 518)
            Me.tp864.TabIndex = 1
            Me.tp864.Text = "856-Wip Orders"
            Me.tp864.Visible = False
            '
            'gb864AddWipOrder
            '
            Me.gb864AddWipOrder.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.gb864AddWipOrder.Controls.AddRange(New System.Windows.Forms.Control() {Me.btn856AddWipOrder, Me.Label17, Me.txtEdit856WipEntity, Me.Label18, Me.txtEdit856TransQty, Me.cboEdit856ModelList, Me.Label16})
            Me.gb864AddWipOrder.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gb864AddWipOrder.ForeColor = System.Drawing.Color.White
            Me.gb864AddWipOrder.Location = New System.Drawing.Point(608, 8)
            Me.gb864AddWipOrder.Name = "gb864AddWipOrder"
            Me.gb864AddWipOrder.Size = New System.Drawing.Size(256, 480)
            Me.gb864AddWipOrder.TabIndex = 1
            Me.gb864AddWipOrder.TabStop = False
            Me.gb864AddWipOrder.Text = "Add Wip Order"
            '
            'btn856AddWipOrder
            '
            Me.btn856AddWipOrder.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btn856AddWipOrder.BackColor = System.Drawing.Color.Green
            Me.btn856AddWipOrder.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btn856AddWipOrder.ForeColor = System.Drawing.Color.White
            Me.btn856AddWipOrder.Location = New System.Drawing.Point(8, 184)
            Me.btn856AddWipOrder.Name = "btn856AddWipOrder"
            Me.btn856AddWipOrder.Size = New System.Drawing.Size(72, 23)
            Me.btn856AddWipOrder.TabIndex = 4
            Me.btn856AddWipOrder.Text = "Add"
            '
            'Label17
            '
            Me.Label17.BackColor = System.Drawing.Color.Transparent
            Me.Label17.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label17.ForeColor = System.Drawing.Color.White
            Me.Label17.Location = New System.Drawing.Point(8, 72)
            Me.Label17.Name = "Label17"
            Me.Label17.Size = New System.Drawing.Size(130, 16)
            Me.Label17.TabIndex = 100
            Me.Label17.Text = "Order # :"
            Me.Label17.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'txtEdit856WipEntity
            '
            Me.txtEdit856WipEntity.Location = New System.Drawing.Point(8, 88)
            Me.txtEdit856WipEntity.Name = "txtEdit856WipEntity"
            Me.txtEdit856WipEntity.Size = New System.Drawing.Size(240, 21)
            Me.txtEdit856WipEntity.TabIndex = 2
            Me.txtEdit856WipEntity.Text = ""
            '
            'Label18
            '
            Me.Label18.BackColor = System.Drawing.Color.Transparent
            Me.Label18.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label18.ForeColor = System.Drawing.Color.White
            Me.Label18.Location = New System.Drawing.Point(9, 120)
            Me.Label18.Name = "Label18"
            Me.Label18.Size = New System.Drawing.Size(130, 16)
            Me.Label18.TabIndex = 99
            Me.Label18.Text = "Quantity :"
            Me.Label18.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'txtEdit856TransQty
            '
            Me.txtEdit856TransQty.Location = New System.Drawing.Point(8, 144)
            Me.txtEdit856TransQty.Name = "txtEdit856TransQty"
            Me.txtEdit856TransQty.Size = New System.Drawing.Size(72, 21)
            Me.txtEdit856TransQty.TabIndex = 3
            Me.txtEdit856TransQty.Text = ""
            '
            'cboEdit856ModelList
            '
            Me.cboEdit856ModelList.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboEdit856ModelList.AutoCompletion = True
            Me.cboEdit856ModelList.AutoDropDown = True
            Me.cboEdit856ModelList.AutoSelect = True
            Me.cboEdit856ModelList.Caption = ""
            Me.cboEdit856ModelList.CaptionHeight = 17
            Me.cboEdit856ModelList.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboEdit856ModelList.ColumnCaptionHeight = 17
            Me.cboEdit856ModelList.ColumnFooterHeight = 17
            Me.cboEdit856ModelList.ColumnHeaders = False
            Me.cboEdit856ModelList.ContentHeight = 15
            Me.cboEdit856ModelList.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboEdit856ModelList.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboEdit856ModelList.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboEdit856ModelList.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboEdit856ModelList.EditorHeight = 15
            Me.cboEdit856ModelList.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.cboEdit856ModelList.ItemHeight = 15
            Me.cboEdit856ModelList.Location = New System.Drawing.Point(8, 40)
            Me.cboEdit856ModelList.MatchEntryTimeout = CType(2000, Long)
            Me.cboEdit856ModelList.MaxDropDownItems = CType(10, Short)
            Me.cboEdit856ModelList.MaxLength = 32767
            Me.cboEdit856ModelList.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboEdit856ModelList.Name = "cboEdit856ModelList"
            Me.cboEdit856ModelList.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboEdit856ModelList.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboEdit856ModelList.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboEdit856ModelList.Size = New System.Drawing.Size(240, 21)
            Me.cboEdit856ModelList.TabIndex = 1
            Me.cboEdit856ModelList.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label16
            '
            Me.Label16.BackColor = System.Drawing.Color.Transparent
            Me.Label16.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label16.ForeColor = System.Drawing.Color.White
            Me.Label16.Location = New System.Drawing.Point(8, 24)
            Me.Label16.Name = "Label16"
            Me.Label16.Size = New System.Drawing.Size(130, 16)
            Me.Label16.TabIndex = 94
            Me.Label16.Text = "Model :"
            Me.Label16.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'dbg856WipOrders
            '
            Me.dbg856WipOrders.AllowUpdate = False
            Me.dbg856WipOrders.AlternatingRows = True
            Me.dbg856WipOrders.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbg856WipOrders.Caption = "864-Wip Orders"
            Me.dbg856WipOrders.CaptionHeight = 17
            Me.dbg856WipOrders.FilterBar = True
            Me.dbg856WipOrders.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbg856WipOrders.Images.Add(CType(resources.GetObject("resource.Images5"), System.Drawing.Bitmap))
            Me.dbg856WipOrders.Location = New System.Drawing.Point(8, 15)
            Me.dbg856WipOrders.Name = "dbg856WipOrders"
            Me.dbg856WipOrders.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbg856WipOrders.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbg856WipOrders.PreviewInfo.ZoomFactor = 75
            Me.dbg856WipOrders.Size = New System.Drawing.Size(592, 473)
            Me.dbg856WipOrders.TabIndex = 8
            Me.dbg856WipOrders.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{Font:Tahoma, 9.75pt, style=Bold;AlignHorz:Near;ForeColor:White;" & _
            "BackColor:CadetBlue;}Normal{BackColor:SteelBlue;}Selected{ForeColor:HighlightTex" & _
            "t;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{}Style16{}Styl" & _
            "e17{}Style10{AlignHorz:Near;}Style11{}OddRow{BackColor:LightSteelBlue;}Style13{}" & _
            "Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}RecordSelecto" & _
            "r{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:InactiveCaptio" & _
            "nText;BackColor:InactiveCaption;}EvenRow{BackColor:NavajoWhite;}Heading{Wrap:Tru" & _
            "e;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Con" & _
            "trol;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, style=Bold;ForeColor:Red;Back" & _
            "Color:White;}Style4{}Style9{}Style8{}Style5{}Group{BackColor:ControlDark;Border:" & _
            "None,,0, 0, 0, 0;AlignVert:Center;}Style7{}Style6{}Style1{}Style3{}Style2{}</Dat" & _
            "a></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" AlternatingRowStyle=""T" & _
            "rue"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterB" & _
            "ar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidt" & _
            "h=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>452</Height><Ca" & _
            "ptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style" & _
            "5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""Filter" & _
            "Bar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle paren" & _
            "t=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLight" & _
            "RowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me" & _
            "=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle pare" & _
            "nt=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" " & _
            "/><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 17, 588, 452</ClientRect><" & _
            "BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid." & _
            "MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""No" & _
            "rmal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Headin" & _
            "g"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal""" & _
            " me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=" & _
            """HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me" & _
            "=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal""" & _
            " me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits" & _
            ">1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidt" & _
            "h>17</DefaultRecSelWidth><ClientArea>0, 0, 588, 469</ClientArea><PrintPageHeader" & _
            "Style parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""Style21"" /></" & _
            "Blob>"
            '
            'tpgEditDateCode
            '
            Me.tpgEditDateCode.BackColor = System.Drawing.Color.SteelBlue
            Me.tpgEditDateCode.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnUpdateWrtyData, Me.lblNewPeriod, Me.lblCurPeriod, Me.txtIMEI, Me.lblIMEI, Me.grpCalWrtyStatus, Me.gbCollectCSN})
            Me.tpgEditDateCode.Location = New System.Drawing.Point(4, 22)
            Me.tpgEditDateCode.Name = "tpgEditDateCode"
            Me.tpgEditDateCode.Size = New System.Drawing.Size(904, 534)
            Me.tpgEditDateCode.TabIndex = 2
            Me.tpgEditDateCode.Text = "Edit Date Code"
            '
            'btnUpdateWrtyData
            '
            Me.btnUpdateWrtyData.BackColor = System.Drawing.Color.Crimson
            Me.btnUpdateWrtyData.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnUpdateWrtyData.ForeColor = System.Drawing.Color.White
            Me.btnUpdateWrtyData.Location = New System.Drawing.Point(344, 32)
            Me.btnUpdateWrtyData.Name = "btnUpdateWrtyData"
            Me.btnUpdateWrtyData.Size = New System.Drawing.Size(160, 24)
            Me.btnUpdateWrtyData.TabIndex = 106
            Me.btnUpdateWrtyData.Text = "Update Warranty Data"
            '
            'lblNewPeriod
            '
            Me.lblNewPeriod.BackColor = System.Drawing.Color.Transparent
            Me.lblNewPeriod.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblNewPeriod.ForeColor = System.Drawing.Color.White
            Me.lblNewPeriod.Location = New System.Drawing.Point(160, 128)
            Me.lblNewPeriod.Name = "lblNewPeriod"
            Me.lblNewPeriod.Size = New System.Drawing.Size(8, 20)
            Me.lblNewPeriod.TabIndex = 103
            Me.lblNewPeriod.Text = "."
            Me.lblNewPeriod.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'lblCurPeriod
            '
            Me.lblCurPeriod.BackColor = System.Drawing.Color.Transparent
            Me.lblCurPeriod.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCurPeriod.ForeColor = System.Drawing.Color.White
            Me.lblCurPeriod.Location = New System.Drawing.Point(160, 80)
            Me.lblCurPeriod.Name = "lblCurPeriod"
            Me.lblCurPeriod.Size = New System.Drawing.Size(8, 20)
            Me.lblCurPeriod.TabIndex = 98
            Me.lblCurPeriod.Text = "."
            Me.lblCurPeriod.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'txtIMEI
            '
            Me.txtIMEI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtIMEI.ForeColor = System.Drawing.Color.Blue
            Me.txtIMEI.Location = New System.Drawing.Point(128, 32)
            Me.txtIMEI.Name = "txtIMEI"
            Me.txtIMEI.Size = New System.Drawing.Size(192, 21)
            Me.txtIMEI.TabIndex = 95
            Me.txtIMEI.Text = ""
            '
            'lblIMEI
            '
            Me.lblIMEI.BackColor = System.Drawing.Color.Transparent
            Me.lblIMEI.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblIMEI.ForeColor = System.Drawing.Color.White
            Me.lblIMEI.Location = New System.Drawing.Point(8, 32)
            Me.lblIMEI.Name = "lblIMEI"
            Me.lblIMEI.Size = New System.Drawing.Size(120, 20)
            Me.lblIMEI.TabIndex = 94
            Me.lblIMEI.Text = "IMEI/MEID:"
            Me.lblIMEI.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'tpgEDI
            '
            Me.tpgEDI.BackColor = System.Drawing.Color.SteelBlue
            Me.tpgEDI.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnEDI865InboudLoadFrExcel, Me.gboxDirectionAndForm, Me.gbEDIOrder, Me.gbEDISNs, Me.gbEDIAddress, Me.btnEDICancel, Me.btnEDICreate})
            Me.tpgEDI.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tpgEDI.ForeColor = System.Drawing.Color.White
            Me.tpgEDI.Location = New System.Drawing.Point(4, 22)
            Me.tpgEDI.Name = "tpgEDI"
            Me.tpgEDI.Size = New System.Drawing.Size(904, 534)
            Me.tpgEDI.TabIndex = 1
            Me.tpgEDI.Text = "Load EDI Files Manually"
            '
            'btnEDI865InboudLoadFrExcel
            '
            Me.btnEDI865InboudLoadFrExcel.BackColor = System.Drawing.Color.Green
            Me.btnEDI865InboudLoadFrExcel.Location = New System.Drawing.Point(40, 544)
            Me.btnEDI865InboudLoadFrExcel.Name = "btnEDI865InboudLoadFrExcel"
            Me.btnEDI865InboudLoadFrExcel.Size = New System.Drawing.Size(192, 24)
            Me.btnEDI865InboudLoadFrExcel.TabIndex = 1084
            Me.btnEDI865InboudLoadFrExcel.Text = "Upload  From Excel"
            '
            'gboxDirectionAndForm
            '
            Me.gboxDirectionAndForm.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label8, Me.cboDirection, Me.cboEDIForm, Me.Label6})
            Me.gboxDirectionAndForm.Location = New System.Drawing.Point(8, 8)
            Me.gboxDirectionAndForm.Name = "gboxDirectionAndForm"
            Me.gboxDirectionAndForm.Size = New System.Drawing.Size(816, 56)
            Me.gboxDirectionAndForm.TabIndex = 1
            Me.gboxDirectionAndForm.TabStop = False
            '
            'Label8
            '
            Me.Label8.BackColor = System.Drawing.Color.Transparent
            Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.White
            Me.Label8.Location = New System.Drawing.Point(462, 28)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(56, 16)
            Me.Label8.TabIndex = 87
            Me.Label8.Text = "Form :"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboDirection
            '
            Me.cboDirection.Items.AddRange(New Object() {"Inbound", "Outbound"})
            Me.cboDirection.Location = New System.Drawing.Point(200, 27)
            Me.cboDirection.Name = "cboDirection"
            Me.cboDirection.Size = New System.Drawing.Size(240, 21)
            Me.cboDirection.TabIndex = 1
            '
            'cboEDIForm
            '
            Me.cboEDIForm.Items.AddRange(New Object() {"940", "856", "864"})
            Me.cboEDIForm.Location = New System.Drawing.Point(526, 27)
            Me.cboEDIForm.Name = "cboEDIForm"
            Me.cboEDIForm.Size = New System.Drawing.Size(240, 21)
            Me.cboEDIForm.TabIndex = 2
            '
            'Label6
            '
            Me.Label6.BackColor = System.Drawing.Color.Transparent
            Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.White
            Me.Label6.Location = New System.Drawing.Point(64, 28)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(130, 16)
            Me.Label6.TabIndex = 86
            Me.Label6.Text = "Direction :"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'gbEDIOrder
            '
            Me.gbEDIOrder.Controls.AddRange(New System.Windows.Forms.Control() {Me.dtpEDIPODate, Me.cboEDIModels, Me.Label11, Me.Label9, Me.txtEDIOrderNo, Me.Label13, Me.chkEDISend944, Me.Label10, Me.txtEDIQty})
            Me.gbEDIOrder.Location = New System.Drawing.Point(8, 152)
            Me.gbEDIOrder.Name = "gbEDIOrder"
            Me.gbEDIOrder.Size = New System.Drawing.Size(456, 344)
            Me.gbEDIOrder.TabIndex = 2
            Me.gbEDIOrder.TabStop = False
            Me.gbEDIOrder.Visible = False
            '
            'dtpEDIPODate
            '
            Me.dtpEDIPODate.Location = New System.Drawing.Point(200, 112)
            Me.dtpEDIPODate.Name = "dtpEDIPODate"
            Me.dtpEDIPODate.Size = New System.Drawing.Size(240, 21)
            Me.dtpEDIPODate.TabIndex = 3
            '
            'cboEDIModels
            '
            Me.cboEDIModels.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboEDIModels.AutoCompletion = True
            Me.cboEDIModels.AutoDropDown = True
            Me.cboEDIModels.AutoSelect = True
            Me.cboEDIModels.Caption = ""
            Me.cboEDIModels.CaptionHeight = 17
            Me.cboEDIModels.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboEDIModels.ColumnCaptionHeight = 17
            Me.cboEDIModels.ColumnFooterHeight = 17
            Me.cboEDIModels.ColumnHeaders = False
            Me.cboEDIModels.ContentHeight = 15
            Me.cboEDIModels.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboEDIModels.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboEDIModels.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboEDIModels.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboEDIModels.EditorHeight = 15
            Me.cboEDIModels.Images.Add(CType(resources.GetObject("resource.Images6"), System.Drawing.Bitmap))
            Me.cboEDIModels.ItemHeight = 15
            Me.cboEDIModels.Location = New System.Drawing.Point(200, 152)
            Me.cboEDIModels.MatchEntryTimeout = CType(2000, Long)
            Me.cboEDIModels.MaxDropDownItems = CType(10, Short)
            Me.cboEDIModels.MaxLength = 32767
            Me.cboEDIModels.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboEDIModels.Name = "cboEDIModels"
            Me.cboEDIModels.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboEDIModels.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboEDIModels.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboEDIModels.Size = New System.Drawing.Size(240, 21)
            Me.cboEDIModels.TabIndex = 4
            Me.cboEDIModels.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label11
            '
            Me.Label11.BackColor = System.Drawing.Color.Transparent
            Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.ForeColor = System.Drawing.Color.White
            Me.Label11.Location = New System.Drawing.Point(64, 33)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(130, 16)
            Me.Label11.TabIndex = 96
            Me.Label11.Text = "Order Number :"
            Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label9
            '
            Me.Label9.BackColor = System.Drawing.Color.Transparent
            Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.White
            Me.Label9.Location = New System.Drawing.Point(64, 152)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(130, 16)
            Me.Label9.TabIndex = 92
            Me.Label9.Text = "Model :"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtEDIOrderNo
            '
            Me.txtEDIOrderNo.Location = New System.Drawing.Point(200, 32)
            Me.txtEDIOrderNo.Name = "txtEDIOrderNo"
            Me.txtEDIOrderNo.Size = New System.Drawing.Size(240, 21)
            Me.txtEDIOrderNo.TabIndex = 1
            Me.txtEDIOrderNo.Text = ""
            '
            'Label13
            '
            Me.Label13.BackColor = System.Drawing.Color.Transparent
            Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label13.ForeColor = System.Drawing.Color.White
            Me.Label13.Location = New System.Drawing.Point(24, 113)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(168, 16)
            Me.Label13.TabIndex = 98
            Me.Label13.Text = "PO && Requested Date :"
            Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkEDISend944
            '
            Me.chkEDISend944.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkEDISend944.ForeColor = System.Drawing.Color.White
            Me.chkEDISend944.Location = New System.Drawing.Point(200, 192)
            Me.chkEDISend944.Name = "chkEDISend944"
            Me.chkEDISend944.Size = New System.Drawing.Size(240, 24)
            Me.chkEDISend944.TabIndex = 5
            Me.chkEDISend944.Text = "Send Receipt ( EDI-944)?"
            Me.chkEDISend944.Visible = False
            '
            'Label10
            '
            Me.Label10.BackColor = System.Drawing.Color.Transparent
            Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.White
            Me.Label10.Location = New System.Drawing.Point(64, 73)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(130, 16)
            Me.Label10.TabIndex = 93
            Me.Label10.Text = "Quantity :"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtEDIQty
            '
            Me.txtEDIQty.Location = New System.Drawing.Point(200, 72)
            Me.txtEDIQty.Name = "txtEDIQty"
            Me.txtEDIQty.Size = New System.Drawing.Size(72, 21)
            Me.txtEDIQty.TabIndex = 2
            Me.txtEDIQty.Text = ""
            '
            'gbEDISNs
            '
            Me.gbEDISNs.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtEDISN, Me.lblEdiSNCnt, Me.Label14, Me.btnEDIRemoveAll, Me.btnEDIRemoveOne, Me.lstEDISNs})
            Me.gbEDISNs.Location = New System.Drawing.Point(480, 64)
            Me.gbEDISNs.Name = "gbEDISNs"
            Me.gbEDISNs.Size = New System.Drawing.Size(344, 432)
            Me.gbEDISNs.TabIndex = 1083
            Me.gbEDISNs.TabStop = False
            Me.gbEDISNs.Visible = False
            '
            'txtEDISN
            '
            Me.txtEDISN.Location = New System.Drawing.Point(16, 41)
            Me.txtEDISN.Name = "txtEDISN"
            Me.txtEDISN.Size = New System.Drawing.Size(200, 21)
            Me.txtEDISN.TabIndex = 109
            Me.txtEDISN.Text = ""
            '
            'lblEdiSNCnt
            '
            Me.lblEdiSNCnt.BackColor = System.Drawing.Color.Black
            Me.lblEdiSNCnt.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblEdiSNCnt.ForeColor = System.Drawing.Color.White
            Me.lblEdiSNCnt.Location = New System.Drawing.Point(240, 40)
            Me.lblEdiSNCnt.Name = "lblEdiSNCnt"
            Me.lblEdiSNCnt.Size = New System.Drawing.Size(96, 48)
            Me.lblEdiSNCnt.TabIndex = 108
            Me.lblEdiSNCnt.Text = "0"
            Me.lblEdiSNCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label14
            '
            Me.Label14.BackColor = System.Drawing.Color.Transparent
            Me.Label14.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label14.ForeColor = System.Drawing.Color.White
            Me.Label14.Location = New System.Drawing.Point(16, 24)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(240, 16)
            Me.Label14.TabIndex = 107
            Me.Label14.Text = "Serial Number:"
            Me.Label14.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'btnEDIRemoveAll
            '
            Me.btnEDIRemoveAll.BackColor = System.Drawing.Color.Crimson
            Me.btnEDIRemoveAll.Location = New System.Drawing.Point(240, 176)
            Me.btnEDIRemoveAll.Name = "btnEDIRemoveAll"
            Me.btnEDIRemoveAll.Size = New System.Drawing.Size(96, 24)
            Me.btnEDIRemoveAll.TabIndex = 3
            Me.btnEDIRemoveAll.Text = "Remove All"
            '
            'btnEDIRemoveOne
            '
            Me.btnEDIRemoveOne.BackColor = System.Drawing.Color.Crimson
            Me.btnEDIRemoveOne.Location = New System.Drawing.Point(240, 120)
            Me.btnEDIRemoveOne.Name = "btnEDIRemoveOne"
            Me.btnEDIRemoveOne.Size = New System.Drawing.Size(96, 24)
            Me.btnEDIRemoveOne.TabIndex = 2
            Me.btnEDIRemoveOne.Text = "Remove One"
            '
            'lstEDISNs
            '
            Me.lstEDISNs.Location = New System.Drawing.Point(16, 65)
            Me.lstEDISNs.Name = "lstEDISNs"
            Me.lstEDISNs.Size = New System.Drawing.Size(200, 342)
            Me.lstEDISNs.TabIndex = 1
            '
            'gbEDIAddress
            '
            Me.gbEDIAddress.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboShipTo, Me.Label15, Me.cboShipFrom, Me.lblShipFromTo})
            Me.gbEDIAddress.Location = New System.Drawing.Point(8, 64)
            Me.gbEDIAddress.Name = "gbEDIAddress"
            Me.gbEDIAddress.Size = New System.Drawing.Size(456, 88)
            Me.gbEDIAddress.TabIndex = 107
            Me.gbEDIAddress.TabStop = False
            Me.gbEDIAddress.Visible = False
            '
            'cboShipTo
            '
            Me.cboShipTo.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboShipTo.AutoCompletion = True
            Me.cboShipTo.AutoDropDown = True
            Me.cboShipTo.AutoSelect = True
            Me.cboShipTo.Caption = ""
            Me.cboShipTo.CaptionHeight = 17
            Me.cboShipTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboShipTo.ColumnCaptionHeight = 17
            Me.cboShipTo.ColumnFooterHeight = 17
            Me.cboShipTo.ColumnHeaders = False
            Me.cboShipTo.ContentHeight = 15
            Me.cboShipTo.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboShipTo.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboShipTo.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboShipTo.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboShipTo.EditorHeight = 15
            Me.cboShipTo.Images.Add(CType(resources.GetObject("resource.Images7"), System.Drawing.Bitmap))
            Me.cboShipTo.ItemHeight = 15
            Me.cboShipTo.Location = New System.Drawing.Point(200, 56)
            Me.cboShipTo.MatchEntryTimeout = CType(2000, Long)
            Me.cboShipTo.MaxDropDownItems = CType(10, Short)
            Me.cboShipTo.MaxLength = 32767
            Me.cboShipTo.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboShipTo.Name = "cboShipTo"
            Me.cboShipTo.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboShipTo.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboShipTo.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboShipTo.Size = New System.Drawing.Size(240, 21)
            Me.cboShipTo.TabIndex = 2
            Me.cboShipTo.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label15
            '
            Me.Label15.BackColor = System.Drawing.Color.Transparent
            Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label15.ForeColor = System.Drawing.Color.White
            Me.Label15.Location = New System.Drawing.Point(104, 58)
            Me.Label15.Name = "Label15"
            Me.Label15.Size = New System.Drawing.Size(88, 16)
            Me.Label15.TabIndex = 108
            Me.Label15.Text = "Ship To:"
            Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboShipFrom
            '
            Me.cboShipFrom.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboShipFrom.AutoCompletion = True
            Me.cboShipFrom.AutoDropDown = True
            Me.cboShipFrom.AutoSelect = True
            Me.cboShipFrom.Caption = ""
            Me.cboShipFrom.CaptionHeight = 17
            Me.cboShipFrom.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboShipFrom.ColumnCaptionHeight = 17
            Me.cboShipFrom.ColumnFooterHeight = 17
            Me.cboShipFrom.ColumnHeaders = False
            Me.cboShipFrom.ContentHeight = 15
            Me.cboShipFrom.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboShipFrom.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboShipFrom.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboShipFrom.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboShipFrom.EditorHeight = 15
            Me.cboShipFrom.Images.Add(CType(resources.GetObject("resource.Images8"), System.Drawing.Bitmap))
            Me.cboShipFrom.ItemHeight = 15
            Me.cboShipFrom.Location = New System.Drawing.Point(200, 24)
            Me.cboShipFrom.MatchEntryTimeout = CType(2000, Long)
            Me.cboShipFrom.MaxDropDownItems = CType(10, Short)
            Me.cboShipFrom.MaxLength = 32767
            Me.cboShipFrom.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboShipFrom.Name = "cboShipFrom"
            Me.cboShipFrom.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboShipFrom.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboShipFrom.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboShipFrom.Size = New System.Drawing.Size(240, 21)
            Me.cboShipFrom.TabIndex = 1
            Me.cboShipFrom.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'lblShipFromTo
            '
            Me.lblShipFromTo.BackColor = System.Drawing.Color.Transparent
            Me.lblShipFromTo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblShipFromTo.ForeColor = System.Drawing.Color.White
            Me.lblShipFromTo.Location = New System.Drawing.Point(104, 26)
            Me.lblShipFromTo.Name = "lblShipFromTo"
            Me.lblShipFromTo.Size = New System.Drawing.Size(88, 16)
            Me.lblShipFromTo.TabIndex = 106
            Me.lblShipFromTo.Text = "Ship From:"
            Me.lblShipFromTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnEDICancel
            '
            Me.btnEDICancel.BackColor = System.Drawing.Color.Gray
            Me.btnEDICancel.Location = New System.Drawing.Point(480, 544)
            Me.btnEDICancel.Name = "btnEDICancel"
            Me.btnEDICancel.Size = New System.Drawing.Size(192, 24)
            Me.btnEDICancel.TabIndex = 5
            Me.btnEDICancel.Text = "Cancal"
            '
            'btnEDICreate
            '
            Me.btnEDICreate.BackColor = System.Drawing.Color.Green
            Me.btnEDICreate.Location = New System.Drawing.Point(272, 544)
            Me.btnEDICreate.Name = "btnEDICreate"
            Me.btnEDICreate.Size = New System.Drawing.Size(192, 24)
            Me.btnEDICreate.TabIndex = 4
            Me.btnEDICreate.Text = "Create"
            '
            'tpgMiscFun
            '
            Me.tpgMiscFun.BackColor = System.Drawing.Color.SteelBlue
            Me.tpgMiscFun.Controls.AddRange(New System.Windows.Forms.Control() {Me.grbWrtyClaimData})
            Me.tpgMiscFun.Location = New System.Drawing.Point(4, 22)
            Me.tpgMiscFun.Name = "tpgMiscFun"
            Me.tpgMiscFun.Size = New System.Drawing.Size(904, 534)
            Me.tpgMiscFun.TabIndex = 3
            Me.tpgMiscFun.Text = "Misc Functions"
            '
            'frmAdmin
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(960, 606)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1})
            Me.Name = "frmAdmin"
            Me.Text = "frmAdmin"
            Me.GroupBox1.ResumeLayout(False)
            CType(Me.cboModel, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox2.ResumeLayout(False)
            Me.grbWrtyClaimData.ResumeLayout(False)
            Me.grpCalWrtyStatus.ResumeLayout(False)
            Me.gbCollectCSN.ResumeLayout(False)
            Me.TabControl1.ResumeLayout(False)
            Me.tpgReports.ResumeLayout(False)
            Me.GroupBox3.ResumeLayout(False)
            Me.tpgSplitOutboundBox.ResumeLayout(False)
            CType(Me.dbgMovedDevices, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dbgDevicesInBox, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpgEditEDI.ResumeLayout(False)
            Me.tcEDIData.ResumeLayout(False)
            Me.tp940.ResumeLayout(False)
            CType(Me.dbg940, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tp864.ResumeLayout(False)
            Me.gb864AddWipOrder.ResumeLayout(False)
            CType(Me.cboEdit856ModelList, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dbg856WipOrders, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpgEditDateCode.ResumeLayout(False)
            Me.tpgEDI.ResumeLayout(False)
            Me.gboxDirectionAndForm.ResumeLayout(False)
            Me.gbEDIOrder.ResumeLayout(False)
            CType(Me.cboEDIModels, System.ComponentModel.ISupportInitialize).EndInit()
            Me.gbEDISNs.ResumeLayout(False)
            Me.gbEDIAddress.ResumeLayout(False)
            CType(Me.cboShipTo, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboShipFrom, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpgMiscFun.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        '*****************************************************************************
        Private Sub frmAdmin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable
            Dim ds As New DataSet()

            Try
                PSS.Core.Highlight.SetHighLight(Me)
                Me.GroupBox2.Visible = True

                '*******************************
                'PERMISSIONS
                '*******************************
                'If ApplicationUser.GetPermission("SS_LoadWrtyData") > 0 Then
                '    Me.grbWrtyClaimData.Visible = True : Me.gbCollectCSN.Visible = True
                'End If
                'If ApplicationUser.GetPermission("CalculateWarrantyStatus") > 0 Then Me.grpCalWrtyStatus.Visible = True
                If ApplicationUser.GetPermission("EDICreation") > 0 Then Me.tpgEDI.Enabled = True Else Me.tpgEDI.Enabled = False
                If ApplicationUser.GetPermission("EDI-Edit") > 0 Then
                    Me.btn940Activate.Enabled = True
                    Me.btn940InactiveOrder.Enabled = True
                    Me.gb864AddWipOrder.Enabled = True
                Else
                    Me.btn940Activate.Enabled = False
                    Me.btn940InactiveOrder.Enabled = False
                    Me.gb864AddWipOrder.Enabled = False
                End If

                '*******************************
                'REPORTS TAB
                '*******************************
                'Populate Models
                dt = _objAdmin.GetTFModel
                Misc.PopulateC1DropDownList(Me.cboModel, dt, "Model_Desc", "model_id")
                Me.cboModel.SelectedValue = 0

                '*******************************
                'EDI TAB
                '*******************************
                PSS.Data.Buisness.Generic.DisposeDT(dt)
                dt = Me._objAdmin.GetTracfoneOutBoundModelList(True)
                Misc.PopulateC1DropDownList(Me.cboEdit856ModelList, dt, "Model", "Model_ID")
                Me.cboEdit856ModelList.SelectedValue = 0

                ds = Me._objAdmin.GetEDIShipAddress
                If ds.Tables.IndexOf("SF") > -1 Then
                    Misc.PopulateC1DropDownList(Me.cboShipFrom, ds.Tables("SF"), "name", "ID")
                    Me.cboShipFrom.SelectedValue = 0
                End If
                If ds.Tables.IndexOf("ST") > -1 Then
                    Misc.PopulateC1DropDownList(Me.cboShipTo, ds.Tables("ST"), "name", "ID")
                    Me.cboShipTo.SelectedValue = 0
                End If

                '*******************************
                'EDI DATE CODE TAB
                '*******************************
                Me.btnUpdateWrtyData.Enabled = False

                '*******************************
                'SPLIT OUTBOUND BOX TAB
                '*******************************
                Me.lblDeviceIMEI.Enabled = False
                Me.txtDeviceIMEI.Enabled = False
                Me.pbxRightArrow.Enabled = False
                EnableShowMoveToControls(False)
                Me.dbgMovedDevices.FilterBar = False
                Me.dbgMovedDevices.AllowFilter = False
                Me._iOldPallettID = 0
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmAdmin_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
                PSS.Data.Buisness.Generic.DisposeDS(ds)
            End Try
        End Sub

        '*****************************************************************************

#Region "Reports"
        '*****************************************************************************
        Private Sub btnWipRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWipRpt.Click
            Dim booDetails As Boolean = False

            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                If Me.rbtnWipDetails.Checked = True Then booDetails = True

                PSS.Data.Buisness.TracFone.Reports.LoadWIPSummary(booDetails)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnWipRpt_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        '*****************************************************************************
        Private Sub btnEDITransRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEDITransRpt.Click
            Dim objReport As PSS.Data.Buisness.TracFone.Reports

            Try
                Me.cboModel.SelectedValue = 0
                objReport = New PSS.Data.Buisness.TracFone.Reports()

                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                objReport.LoadEDITranasctionReport()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnEDITransRpt_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                objReport = Nothing
            End Try
        End Sub

        '*****************************************************************************
        Private Sub btnEDITransRptByModel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEDITransRptByModel.Click
            Dim objReport As PSS.Data.Buisness.TracFone.Reports

            Try
                If Me.cboModel.SelectedValue > 0 Then
                    objReport = New PSS.Data.Buisness.TracFone.Reports()

                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor

                    objReport.LoadEDITranasctionReport(Me.cboModel.SelectedValue)
                    Me.cboModel.SelectedValue = 0
                Else
                    MessageBox.Show("Please select a model for this report.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnEDITransRpt_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                objReport = Nothing
            End Try
        End Sub

        '*****************************************************************************
        Private Sub btnFalloutCnt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFalloutCnt.Click
            Try
                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor
                Me._objAdmin.LoadRURFalloutCountReport(Me.dtpShipFr.Value.ToString("yyyy-MM-dd"), Me.dtpShipTo.Value.ToString("yyyy-MM-dd"))
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnFalloutCnt_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '*****************************************************************************

#End Region

#Region "Misc Functions"
        '*****************************************************************************
        Private Sub btnLoadSSRepCdMatGrpPmtCd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadSSRepCdMatGrpPmtCd.Click
            Dim objSSWrty As PSS.Data.Buisness.WarrantyClaim.SamSungWrty
            Dim fdOpenFile As OpenFileDialog
            Dim i As Integer = 0
            Dim strFilePath As String = ""

            Try
                objSSWrty = New PSS.Data.Buisness.WarrantyClaim.SamSungWrty()

                fdOpenFile = New OpenFileDialog()
                fdOpenFile.DefaultExt = ".xls"
                fdOpenFile.ShowDialog()
                strFilePath = fdOpenFile.FileName

                If strFilePath.Trim.Length = 0 Then
                    Exit Sub
                ElseIf strFilePath.Trim.EndsWith(".xls") = False Then
                    MessageBox.Show("Input file must be in excel format.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf File.Exists(strFilePath) = False Then
                    MessageBox.Show("File does not exist """ & strFilePath & """.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor

                    i = objSSWrty.LoadRepCodeMatGrpPmtMap(strFilePath)

                    If i > 0 Then
                        Me.Enabled = True
                        Cursor.Current = Cursors.Default
                        MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnLoadSSRepCdMatGrpPmtCd_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If Not IsNothing(fdOpenFile) Then
                    fdOpenFile.Dispose()
                    fdOpenFile = Nothing
                End If
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                objSSWrty = Nothing
            End Try
        End Sub

        '*****************************************************************************

#End Region

#Region "Edit Date Code"
        '*****************************************************************************
        'Private Sub txtIMEI_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCalcWrtyIMEI.KeyUp
        '    Dim dt, dtCelloptInfo As DataTable
        '    Dim iDeviceID, iModelID, iManufWrty, iManufID As Integer
        '    Dim objCollectWrtyCode As System.Object
        '    Dim strLastDateInWrty, strWrtyDateCode, strMSN, strAPC, strIMEI As String
        '    Dim i As Integer
        '    Try
        '        If e.KeyCode = Keys.Enter Then
        '            If Me.txtIMEI.Text.Trim.Length = 0 Then Exit Sub
        '            If Me.txtIMEI.Text.Trim.ToUpper = "UNREADABLE" Then Exit Sub

        '            'Reset variables
        '            iDeviceID = 0 : iManufWrty = 0
        '            strLastDateInWrty = "" : strWrtyDateCode = "" : strMSN = "" : strAPC = "" : strIMEI = ""

        '            dt = PSS.Data.Buisness.Generic.GetDeviceInfoInWIP(Me.txtIMEI.Text.Trim, 2258)

        '            If dt.Rows.Count = 0 Then
        '                MessageBox.Show("IMEI does not exist in WIP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '                Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
        '            ElseIf dt.Rows.Count > 1 Then
        '                MessageBox.Show("IMEI existed more than one in WIP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '                Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus() : Exit Sub
        '            ElseIf dt.Rows.Count = 1 AndAlso dt.Rows(0)("ManufDate").ToString.Trim.Length > 0 Then
        '                MessageBox.Show("This device has date code already.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '                Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus() : Exit Sub
        '            ElseIf dt.Rows.Count = 1 Then
        '                iManufID = dt.Rows(0)("Manuf_ID")
        '                Me.Enabled = False

        '                '************************************
        '                'Get Date code if Manuf is Samsung
        '                '************************************
        '                If iManufID = 21 Then 'Samsung
        '                    objCollectWrtyCode = New Samsung.frmCollectSSWrytData()
        '                    objCollectWrtyCode.ShowDialog()
        '                    If objCollectWrtyCode._booCancel = True Then
        '                        MessageBox.Show("You must enter manufacture date code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '                        Me.Enabled = True : Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus() : Exit Sub
        '                    Else
        '                        If objCollectWrtyCode._strMonth.Trim.Length = 0 Then
        '                            MessageBox.Show("Invalid Month of Manufacture Date Code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '                            Me.Enabled = True : Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus() : Exit Sub
        '                        ElseIf objCollectWrtyCode._strYear.Trim.Length = 0 Then
        '                            MessageBox.Show("Invalid Year of Manufacture Date Code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '                            Me.Enabled = True : Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus() : Exit Sub
        '                        Else
        '                            strWrtyDateCode = objCollectWrtyCode._strYear.Trim & "." & objCollectWrtyCode._strMonth.Trim
        '                            iManufWrty = objCollectWrtyCode._iWrty
        '                            strLastDateInWrty = objCollectWrtyCode._strLastDateInWarranty
        '                        End If
        '                    End If
        '                ElseIf iManufID = 16 Then   'LG
        '                    objCollectWrtyCode = New LG.frmCollectLGWrtyCode(Me.txtIMEI.Text.Trim)
        '                    objCollectWrtyCode.ShowDialog()
        '                    If objCollectWrtyCode._booCancel = True Then
        '                        MessageBox.Show("You must enter serial number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '                        Me.Enabled = True : Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus() : Exit Sub
        '                    Else
        '                        If objCollectWrtyCode._strDateCode.ToString.Trim.Length = 0 Then
        '                            MessageBox.Show("You must enter serial number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '                            Me.Enabled = True : Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus() : Exit Sub
        '                        Else
        '                            iManufWrty = objCollectWrtyCode._iWrty
        '                            strWrtyDateCode = objCollectWrtyCode._strDateCode.ToString.Trim
        '                            If objCollectWrtyCode._strSN.ToString.Trim.Length > 3 Then strMSN = objCollectWrtyCode._strSN.ToString.Trim.ToUpper
        '                            strLastDateInWrty = objCollectWrtyCode._strLastDateInWarranty
        '                        End If
        '                    End If
        '                ElseIf iManufID = 1 Then    'MOTOROLA
        '                    dtCelloptInfo = Me._objAdmin.GetCelloptInfo(dt.Rows(0)("Device_ID"))

        '                    If dtCelloptInfo.Rows.Count = 0 Then
        '                        MessageBox.Show("Cellopt data is missing. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '                        Me.Enabled = True : Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus() : Exit Sub
        '                        'ElseIf Not IsDBNull(dtCelloptInfo.Rows(0)("CellOpt_MSN")) Then
        '                        '    MessageBox.Show("Data code is existed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '                        '    Me.Enabled = True : Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus() : Exit Sub
        '                    Else
        '                        objCollectWrtyCode = New Gui.Motorola.frmCollectMotorolaWrtyCode(Me.txtIMEI.Text.Trim, dt.Rows(0)("Model_ID"))
        '                        objCollectWrtyCode.ShowDialog()
        '                        If objCollectWrtyCode._booCancel = True Then
        '                            MessageBox.Show("You must enter MSN number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '                            Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus() : Exit Sub
        '                        Else
        '                            If objCollectWrtyCode._strMSN.Trim.Length = 0 Then
        '                                MessageBox.Show("You must enter MSN number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '                                Me.Enabled = True : Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus() : Exit Sub
        '                            ElseIf objCollectWrtyCode._strMSN.ToString.Trim.ToUpper = "UNREADABLE" Then
        '                                iManufWrty = 0
        '                            Else
        '                                iManufWrty = objCollectWrtyCode._iWrty
        '                                strLastDateInWrty = objCollectWrtyCode._strLastDateInWarranty
        '                                strWrtyDateCode = objCollectWrtyCode._strDateCode.ToString.Trim
        '                                If objCollectWrtyCode._strMSN.ToString.Trim.Length > 0 Then strMSN = objCollectWrtyCode._strMSN.ToString.Trim.ToUpper
        '                                strAPC = objCollectWrtyCode._strAPC
        '                                If Me.txtIMEI.Text.Trim.Length = 15 Then strIMEI = Me.txtIMEI.Text.Trim
        '                            End If
        '                        End If  'User cancel from Date code window
        '                    End If  'Cellopt data > 0
        '                End If  'Manufacture

        '                '*****************************************
        '                'Update Warranty Data
        '                '*****************************************
        '                Cursor.Current = Cursors.WaitCursor

        '                If strLastDateInWrty.Trim.Length > 0 Then
        '                    i = Me._objAdmin.UpdateWarrantyData(dt.Rows(0)("Device_ID"), iManufID, iManufWrty, strLastDateInWrty, strWrtyDateCode, strMSN, strAPC, strIMEI)
        '                    If i > 0 Then
        '                        Me.txtIMEI.Text = "" : Me.lblCalWrtyScanCnt.Text = CInt(Me.lblCalWrtyScanCnt.Text) + 1
        '                        Me.Enabled = True : Me.txtIMEI.Focus()
        '                    End If
        '                Else
        '                    Me.Enabled = True : Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
        '                End If
        '                '*****************************************
        '            End If  'IMEI existed
        '        End If  'Enter Key
        '    Catch ex As Exception
        '        MessageBox.Show(ex.ToString, "txtIMEI_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Finally
        '        Cursor.Current = Cursors.Default
        '        Me.Enabled = True
        '        PSS.Data.Buisness.Generic.DisposeDT(dt)
        '        objCollectWrtyCode = Nothing
        '    End Try
        'End Sub

        '*****************************************************************************
        Private Sub btnResetScanQty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetScanQty.Click
            Me.lblCalWrtyScanCnt.Text = "0"
        End Sub

        '*****************************************************************************
        Private Sub btnColCSNResetQty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColCSNResetQty.Click
            Me.lblColCsnScanQty.Text = "0"
        End Sub

        '*****************************************************************************
        Private Sub txtColCsnImei_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtColCsnImei.KeyUp
            Dim dt, dtFuncPart As DataTable
            Dim iDeviceID, iModelID, iManufID As Integer
            Dim objColFCRC As Technician.frmCollectRepairFailCodes
            Dim strCSN, strIMEI As String
            Dim i As Integer

            Try
                If e.KeyCode = Keys.Enter Then
                    If Me.txtColCsnImei.Text.Trim.Length = 0 Then Exit Sub

                    'Reset variables
                    iDeviceID = 0 : iManufID = 0
                    strCSN = "" : strIMEI = ""

                    dt = PSS.Data.Buisness.Generic.GetDeviceInfoInWIP(Me.txtColCsnImei.Text.Trim, 2258)

                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("IMEI does not exist in WIP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtColCsnImei.SelectAll() : Me.txtColCsnImei.Focus()
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("IMEI existed more than one in WIP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtColCsnImei.SelectAll() : Me.txtColCsnImei.Focus() : Exit Sub
                    ElseIf dt.Rows.Count = 1 Then
                        iManufID = dt.Rows(0)("Manuf_ID")
                        iModelID = dt.Rows(0)("Model_ID")
                        dtFuncPart = Me._objAdmin.GetAnyHighestLaborLvlBilledPart(dt.Rows(0)("Device_ID"), iModelID)
                        If dtFuncPart.Rows.Count = 0 Then
                            MessageBox.Show("This device does not have any level part.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtColCsnImei.SelectAll() : Me.txtColCsnImei.Focus() : Exit Sub
                        End If

                        Me.Enabled = False

                        '************************************
                        'Collect MSN/CSN
                        '************************************
                        If iManufID = 21 Or iManufID = 1 Then 'Samsung
                            objColFCRC = New Technician.frmCollectRepairFailCodes(iManufID, iModelID, 2, dtFuncPart.Rows(0)("Billcode_ID"), True, False, dt.Rows(0)("Device_ID"), Me.txtColCsnImei.Text.Trim, dtFuncPart.Rows(0)("LaborLevel"))
                            objColFCRC.ShowDialog()
                            If objColFCRC._booCancel = True Then
                                MessageBox.Show("You must enter ESN/CSN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.Enabled = True : Me.txtColCsnImei.SelectAll() : Me.txtColCsnImei.Focus() : Exit Sub
                            Else
                                Me.lblColCsnScanQty.Text = CInt(Me.lblColCsnScanQty.Text) + 1
                            End If
                        End If  'Manufacture
                        '************************************
                    End If  'IMEI existed

                End If  'Enter Key
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtColCsnImei_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Cursor.Current = Cursors.Default
                Me.Enabled = True
                PSS.Data.Buisness.Generic.DisposeDT(dt)
                PSS.Data.Buisness.Generic.DisposeDT(dtFuncPart)
                objColFCRC = Nothing
            End Try
        End Sub

        '*****************************************************************************

#End Region

#Region "EDI"

        '*****************************************************************************
        Private Sub ClearCtrlsInEDITab()
            Try
                Me.cboEDIForm.Items.Clear()
                Me.cboEDIForm.Text = ""

                Me.cboShipTo.SelectedValue = 0
                Me.cboShipFrom.SelectedValue = 0

                Me.txtEDIOrderNo.Text = ""
                Me.txtEDIQty.Text = ""
                Me.cboEDIModels.SelectedValue = 0
                Me.chkEDISend944.Checked = False
                Me.chkEDISend944.Visible = False

                Me.txtEDISN.Text = ""
                Me.lblEdiSNCnt.Text = ""
                Me.lstEDISNs.Items.Clear()
                Me.lstEDISNs.Refresh()

                Me.gbEDIAddress.Visible = False
                Me.gbEDIOrder.Visible = False
                Me.gbEDISNs.Visible = False

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*****************************************************************************
        Private Sub cboDirection_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDirection.SelectedIndexChanged
            Try
                ClearCtrlsInEDITab()
                If Me.cboDirection.SelectedIndex = 0 Then
                    Me.cboEDIForm.Items.Add("940")
                    Me.cboEDIForm.Items.Add("856")
                    Me.cboEDIForm.Items.Add("864")
                ElseIf Me.cboDirection.SelectedIndex = 1 Then
                    Me.cboEDIForm.Items.Add("940")
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboDirection_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*****************************************************************************
        Private Sub cboEDIForm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEDIForm.SelectedIndexChanged
            Try
                If Me.cboEDIForm.Items.Item(Me.cboEDIForm.SelectedIndex).ToString = "940" Then
                    Me.gbEDIAddress.Visible = True
                    Me.gbEDIOrder.Visible = True
                    Me.gbEDISNs.Visible = False
                    Me.chkEDISend944.Checked = False
                    Me.chkEDISend944.Visible = True
                ElseIf Me.cboEDIForm.Items.Item(Me.cboEDIForm.SelectedIndex).ToString = "856" Then
                    Me.gbEDIAddress.Visible = True
                    Me.gbEDIOrder.Visible = True
                    Me.gbEDISNs.Visible = True
                    Me.chkEDISend944.Checked = False
                    Me.chkEDISend944.Visible = False
                ElseIf Me.cboEDIForm.Items.Item(Me.cboEDIForm.SelectedIndex).ToString = "864" Then
                    Me.gbEDIAddress.Visible = False
                    Me.gbEDIOrder.Visible = True
                    Me.gbEDISNs.Visible = False
                    Me.chkEDISend944.Checked = False
                    Me.chkEDISend944.Visible = False
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboDirection_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*****************************************************************************
        Private Sub txtEDISN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEDISN.KeyUp
            Try
                If e.KeyCode = Keys.Enter Then

                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtEDISN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*****************************************************************************
        Private Sub btnEDI865InboudLoadFrExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEDI865InboudLoadFrExcel.Click
            Dim strHeaders() As String = {"Job", "Type", "Assembly", "Class", "Quantity", "Status"}
            Dim dt As New DataTable()
            Dim drNewRow As DataRow
            Dim strFilePatth, strColLetter, strTransactionQty, strCustItemNo, strWIPEntity As String
            Dim i, j, iTransactionQty, iModelID As Integer
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet
            Dim OpenFileDialog1 As OpenFileDialog

            Try
                OpenFileDialog1 = New OpenFileDialog()
                OpenFileDialog1.FilterIndex = 1
                OpenFileDialog1.ShowDialog()
                strFilePatth = OpenFileDialog1.FileName.Trim

                If strFilePatth.Length = 0 Then
                    Exit Sub
                ElseIf File.Exists(strFilePatth) = False Then
                    MessageBox.Show("File does not exist.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    objExcel = New Excel.Application()
                    objBook = objExcel.Workbooks.Open(strFilePatth)
                    objSheet = objExcel.Worksheets(1)
                    objExcel.Visible = True

                    strColLetter = "" : iTransactionQty = 0 : strCustItemNo = "" : strWIPEntity = "" : iModelID = 0

                    For i = 0 To strHeaders.Length - 1
                        strColLetter = PSS.Data.Buisness.Generic.CalExcelColLetter(i + 1)
                        If strHeaders(i).ToLower <> objSheet.range(strColLetter & 1).value.ToString.ToLower Then
                            MessageBox.Show(objSheet.range(strColLetter & 1).value.ToString & " is not a valid header.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If
                    Next i

                    i = 2

                    strWIPEntity = objSheet.range("A" & i).value.ToString.Trim
                    strCustItemNo = objSheet.range("C" & i).value.ToString.Trim
                    iTransactionQty = Convert.ToInt32(objSheet.range("E" & i).value)
                    iModelID = Me._objAdmin.GetGetModelIDByCustOutBoundSku(strCustItemNo)

                    While strWIPEntity.Length > 0 AndAlso strCustItemNo.Length > 0 AndAlso iTransactionQty > 0
                        drNewRow = dt.NewRow
                        drNewRow("WipRefID") = "R7B"
                        drNewRow("WipRefID_Desc") = "WO REQUEST"
                        drNewRow("MsgRecordType") = "R7B"
                        drNewRow("OrganizationName") = "PSSI_IO"
                        drNewRow("TransactionQty") = iTransactionQty
                        drNewRow("CustItemNo") = strCustItemNo
                        drNewRow("WIPEntity") = strWIPEntity
                        drNewRow("StatusType") = 3
                        drNewRow("ScheduledStartDate") = Now.Year & "-" & Now.Month & "-01"
                        drNewRow("ScheduledCompletionDate") = Now.Year & "-" & Now.Month & "-" & Date.DaysInMonth(Now.Year, Now.Month)
                        drNewRow("GLNValue") = "1100001010554"
                        drNewRow("Msg_ID") = 0
                        drNewRow("Model_ID") = iModelID
                        dt.Rows.Add(drNewRow) : dt.AcceptChanges()

                        i += 1
                        strWIPEntity = objSheet.range("A" & i).value.ToString.Trim
                        strCustItemNo = objSheet.range("C" & i).value.ToString.Trim
                        iTransactionQty = Convert.ToInt32(objSheet.range("E" & i).value)
                        iModelID = Me._objAdmin.GetGetModelIDByCustOutBoundSku(strCustItemNo)
                    End While

                    If dt.Rows.Count > 0 AndAlso dt.Select("Model_ID = 0 ").Length > 0 Then
                        If MessageBox.Show("There are " & dt.Select("Model_ID = 0 ").Length & " items without model ID." & Environment.NewLine & "Would you like to continue and skip the all the rows with missing model?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Cancel Then
                            Exit Sub
                        Else
                            Me._objAdmin.LoadWipOrders(dt)
                            MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Finally
                If Not IsNothing(OpenFileDialog1) Then
                    OpenFileDialog1.Dispose()
                    OpenFileDialog1 = Nothing
                End If
            End Try
        End Sub

        '*****************************************************************************
#End Region

#Region "EDI-Edit"

        '*****************************************************************************************************************
        Private Sub tp940_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tp940.VisibleChanged, tp864.VisibleChanged
            Try
                If sender.name = "tp940" AndAlso Me.tp940.Visible = True Then
                    Me.Refresh940Grid()
                ElseIf sender.name = "tp864" AndAlso Me.tp864.Visible = True Then
                    Me.Refresh864Grid()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "tp940_VisibleChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*****************************************************************************************************************
        Private Sub btn940Activate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn940Activate.Click
            Dim iRow As Integer = 0
            Dim strOrderIDs As String = ""
            Dim dt As DataTable

            Try
                If Me.dbg940.SelectedRows.Count > 0 And Me.dbg940.SelectedCols.Count Then
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                    'loop through each selected row
                    For Each iRow In Me.dbg940.SelectedRows
                        If strOrderIDs.Trim.Length > 0 Then strOrderIDs &= ", "
                        strOrderIDs &= Me.dbg940.Columns("Order_ID").CellValue(iRow)
                    Next iRow
                    Me._objAdmin.SetOrderCancelVal(0, strOrderIDs)
                    Refresh940Grid()
                    MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Please select row(s).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btn940Activate_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '*****************************************************************************************************************
        Private Sub btn940InactiveOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn940InactiveOrder.Click
            Try
                Dim iRow As Integer = 0
                Dim strOrderIDs As String = ""
                Dim dt As DataTable

                Try
                    If Me.dbg940.SelectedRows.Count > 0 And Me.dbg940.SelectedCols.Count Then
                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                        'loop through each selected row
                        For Each iRow In Me.dbg940.SelectedRows
                            If strOrderIDs.Trim.Length > 0 Then strOrderIDs &= ", "
                            strOrderIDs &= Me.dbg940.Columns("Order_ID").CellValue(iRow)
                        Next iRow

                        If strOrderIDs.Trim.Length > 0 Then
                            dt = Me._objAdmin.GetWHReceivedCount(strOrderIDs)
                            If dt.Rows.Count > 0 Then
                                strOrderIDs = ""
                                For iRow = 0 To dt.Rows.Count - 1
                                    If strOrderIDs.Trim.Length > 0 Then strOrderIDs &= Environment.NewLine
                                    strOrderIDs &= Me.dbg940.Columns("Order_ID").CellValue(iRow)
                                Next iRow
                                MessageBox.Show("The following orders " & Environment.NewLine & strOrderIDs & Environment.NewLine & "are in the receiving process. Please refresh data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Else
                                Me._objAdmin.SetOrderCancelVal(1, strOrderIDs)
                                Refresh940Grid()
                                MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                        End If
                    Else
                        MessageBox.Show("Please select row(s).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.ToString, "btn940Activate_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btn940InactiveOrder_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '*****************************************************************************************************************
        Private Sub btnRefreshData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshData.Click
            Try
                Me.Refresh940Grid()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "tp940_VisibleChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*****************************************************************************************************************
        Private Sub Refresh940Grid()
            Dim dt As DataTable
            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                'Refresh data grid
                dt = Me._objAdmin.GetOpen940()
                With Me.dbg940
                    .DataSource = dt.DefaultView
                End With
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "tp940_VisibleChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '*****************************************************************************************************************
        Private Sub Refresh864Grid()
            Dim dt As DataTable
            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                'Refresh data grid
                dt = Me._objAdmin.GetAvailableWipOrders()
                With Me.dbg856WipOrders
                    .DataSource = dt.DefaultView
                End With
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "tp940_VisibleChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '*****************************************************************************************************************
        Private Sub btn856AddWipOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn856AddWipOrder.Click
            Dim dteToday As DateTime
            Dim strStartOfMonth, strEndOfMonth As String
            Dim dt As DataTable
            Dim i As Integer = 0

            Try
                If Me.cboEdit856ModelList.SelectedValue = 0 Then
                    MessageBox.Show("Please select model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.txtEdit856WipEntity.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter Wip Order", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.txtEdit856WipEntity.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter transaction quantity.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    dteToday = CDate(PSS.Data.Buisness.Generic.MySQLServerDateTime())
                    strEndOfMonth = dteToday.Year & "-" & dteToday.Month.ToString.PadLeft(2, "0") & "-" & dteToday.DaysInMonth(dteToday.Year, dteToday.Month)
                    strStartOfMonth = dteToday.Year & "-" & dteToday.Month.ToString.PadLeft(2, "0") & "-01"

                    dt = Me._objAdmin.GetThisMonthWipEntityByModel(Me.cboEdit856ModelList.SelectedValue, strStartOfMonth, strEndOfMonth)
                    If dt.Rows.Count > 0 Then
                        MessageBox.Show("There is an open wip order for this month and this model ( " & dt.Rows(0)("Wip Order") & " ).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        dt = Me._objAdmin.GetWipEntityInfo(Me.txtEdit856WipEntity.Text.Trim)
                        If dt.Rows.Count > 0 Then
                            MessageBox.Show("This Wip Order is already scheduled for this date range " & dt.Rows(0)("ScheduledStartDate") & " to " & dt.Rows(0)("ScheduledCompletionDate") & ". ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            i = Me._objAdmin.InsertWipOrder(CInt(Me.txtEdit856TransQty.Text), Me.cboEdit856ModelList.Text, Me.txtEdit856WipEntity.Text.Trim.ToUpper, dteToday.ToString("yyyy-MM-dd"), strEndOfMonth, Me.cboEdit856ModelList.SelectedValue)
                            If i > 0 Then
                                MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Refresh864Grid()
                                Me.cboEdit856ModelList.SelectedValue = 0 : Me.txtEdit856WipEntity.Text = "" : Me.txtEdit856TransQty.Text = ""
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btn856AddWipOrder_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '*****************************************************************************************************************

#End Region


        Private Sub txtIMEI_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIMEI.KeyPress
            Try
                If Not (Char.IsNumber(e.KeyChar) Or Char.IsControl(e.KeyChar)) Then
                    Beep()
                    e.Handled = True
                End If

                Me.btnUpdateWrtyData.Enabled = Me.txtIMEI.Text.Trim().Length > 0
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtIMEI_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnUpdateWrtyData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateWrtyData.Click
            Try
                UpdateWarrantyData()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnUpdateWrtyData_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub UpdateWarrantyData()
            Dim dt As DataTable = Nothing

            Try
                Me.Cursor = Cursors.WaitCursor
                Me.Enabled = False

                Dim strIMEI As String = Me.txtIMEI.Text.Trim
                Dim iDeviceID As Integer = Me._objAdmin.GetDeviceIDFromIMEI(strIMEI)

                If iDeviceID = 0 Then
                    MessageBox.Show(String.Format("Unable to obtain the device ID for IMEI {0}.", strIMEI), "Invalid IMEI", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Me.txtIMEI.Focus()
                Else
                    Dim frmRec As New TracFone.frmRec()
                    Dim dr As DataRow = Me._objAdmin.GetModelIDAndManufIDFromIMEI(strIMEI)
                    Dim iModelID As Integer = dr("model_id")
                    Dim iManufID As Integer = dr("manuf_id")
                    Dim iBoxType As Integer = Me._objAdmin.GetBoxTypeFromIMEI(strIMEI)

                    '***********************************************************
                    'The following are passed by ref to GetCurrentWarrantyData() and
                    'their values are populated there
                    Dim iManufWrty As Integer = 0
                    Dim iWrtyExpInLess31Days As Integer = 0
                    Dim strLastDateInWrty As String = String.Empty
                    Dim strWrtyDateCode As String = String.Empty
                    Dim strMSN As String = String.Empty
                    Dim strAPC As String = String.Empty
                    Dim iManufacturingCountryID As Integer = 0
                    '***********************************************************

                    Dim bCollected As Boolean = frmRec.CollectWarrantyData(iManufID, iModelID, strIMEI, iBoxType, iManufWrty, iWrtyExpInLess31Days, _
                        strLastDateInWrty, strWrtyDateCode, strMSN, strAPC, iManufacturingCountryID)

                    'MessageBox.Show(String.Format("iManufWrty = {0}, iWrtyExpInLess31Days = {1}, strLastDateInWrty = '{2}', strMSN = '{3}', strAPC = '{4}', iManufacturingCountryID = {5}, strWrtyDateCode = {6}", _
                    'iManufWrty, iWrtyExpInLess31Days, strLastDateInWrty, strMSN, strAPC, iManufacturingCountryID, strWrtyDateCode), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    If bCollected Then
                        Dim drCurrentWarrantyData As DataRow = Me._objAdmin.GetCurrentWarrantyData(iDeviceID)

                        If drCurrentWarrantyData("LastDateInWrty").ToString().Equals(strLastDateInWrty) And drCurrentWarrantyData("Manuf_Date").ToString().Equals(strWrtyDateCode) Then
                            MessageBox.Show("The last date in warranty and date code values agree with the calculated values.  There is nothing to change.", "Matching Values", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            Exit Sub
                        End If

                        Me._objAdmin.UpdateTItemWrtyData(strIMEI, strLastDateInWrty, strWrtyDateCode)

                        Dim iOrderID As Integer = Me._objAdmin.GetOrderID(strIMEI)

                        If iOrderID = 0 Then
                            MessageBox.Show("The order ID query returned zero.", "Invalid Order ID", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Else
                            dt = Me._objAdmin.GetBoxID(iOrderID, iManufWrty)

                            If dt.Rows.Count = 0 Then
                                MessageBox.Show(String.Format("There are no open boxes for Order_ID = {0} and WarrantyFlag = {1}.  Please contact IT", iOrderID, iManufWrty), "No Open Boxes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            ElseIf dt.Rows(0)("BoxID").ToString().Length = 0 Then
                                MessageBox.Show("The box ID query returned an empty value.", "Invalid Order ID", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Else
                                'Correct BoxID to reflect correct warranty status.
                                Dim strBoxID As String = dt.Rows(0)("BoxID")
                                Dim iWBID As Integer = dt.Rows(0)("wb_id")

                                If strBoxID.Trim().Length = 0 Or iWBID = 0 Then
                                    MessageBox.Show("Invalid values for either box ID or WB ID.  Please contact IT.", "Information", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Information)
                                Else
                                    Me._objAdmin.UpdateBoxIDWBID(strIMEI, strBoxID, iWBID)
                                    Me._objAdmin.UpdateWrtyStatus(iDeviceID, iManufWrty)
                                    Me._objAdmin.UpdateDateCode(iDeviceID, strWrtyDateCode)

                                    MessageBox.Show("Warranty data updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End If
                            End If
                        End If
                    Else
                        MessageBox.Show("The call to CollectWarrantyData() returned FALSE.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)

                Me.Enabled = True
                Me.Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub txtIMEI_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIMEI.KeyUp
            Try
                If e.KeyValue = 13 And Me.txtIMEI.Text.Trim.Length > 0 Then UpdateWarrantyData()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnUpdateWrtyData_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub txtBoxName_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBoxName.Enter
            Try
                Dim txt As TextBox = DirectCast(sender, TextBox)

                ConvertEnterExitStyle(txt, True)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtBoxName_Enter", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub txtBoxName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBoxName.Leave
            Try
                Dim txt As TextBox = DirectCast(sender, TextBox)

                ConvertEnterExitStyle(txt, False)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtBoxName_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnSplitBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSplitBox.Click
            Try
                SplitBox()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnSplitBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub txtBoxName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBoxName.KeyPress
            Try
                CheckCharAsLetterDigitorControl(e)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtBoxName_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub txtBoxName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBoxName.KeyDown
            Try
                If e.KeyCode = Keys.Enter Then
                    Dim strBoxName As String = Me.txtBoxName.Text.Trim
                    Dim iPallettID As Integer = Me._objAdmin.GetBoxID(strBoxName)

                    If iPallettID <> Me._iOldPallettID Then
                        ClearAllData()
                        Me.txtBoxName.Text = strBoxName
                    End If

                    Me._iOldPallettID = iPallettID

                    'Before loading the box devices grid, check that:
                    '1.  The box exists.
                    '2.  The box has a ship date.
                    '3.  The box has not yet been issued a packing slip.
                    '4.  The box has not yet been issued a work order.
                    If Me._iOldPallettID = 0 Or Not Me._objAdmin.BoxExists(Me._iOldPallettID) Then
                        MessageBox.Show(String.Format("Box {0} does not exist.", strBoxName), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ElseIf Not Me._objAdmin.BoxHasShipped(Me._iOldPallettID) Then
                        MessageBox.Show(String.Format("Box {0} has not yet shipped and cannot be split.", strBoxName), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ElseIf Me._objAdmin.BoxHasPackingSlip(Me._iOldPallettID) Then
                        MessageBox.Show(String.Format("Box {0} has been issued a packing slip and cannot be split.", strBoxName), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ElseIf Me._objAdmin.BoxHasWorkOrder(Me._iOldPallettID) Then
                        MessageBox.Show(String.Format("Box {0} has been issued a work order and cannot be split.", strBoxName), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        LoadDevicesInBox(Me._iOldPallettID)
                        EnableShowMoveToControls(False)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtBoxName_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub SplitBox()
            Try
                Me.Cursor = Cursors.WaitCursor
                Me.Enabled = False

                Dim bContinue As Boolean = True
                Dim strOldBoxName As String = Me.txtBoxName.Text.Trim()

                If strOldBoxName.Length = 0 Then
                    MessageBox.Show("Box name must be a non-empty string.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    bContinue = False
                ElseIf Not Me._objAdmin.BoxExists(Me._iOldPallettID) Then
                    MessageBox.Show(String.Format("A box named '{0}' could not be located in production.tpallett.", strOldBoxName), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    bContinue = False
                End If

                If bContinue Then
                    Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = Me.dbgMovedDevices
                    Dim drv As System.Data.DataRowView
                    Dim i As Integer
                    Dim strNewBoxName As String = strOldBoxName.Substring(0, strOldBoxName.LastIndexOf("N") + 1)
                    Dim strMaxBoxName As String = Me._objAdmin.GetMaxBoxName(strNewBoxName)
                    Dim iMax As Integer = Convert.ToInt32(strMaxBoxName.Substring(strNewBoxName.Length))
                    Dim iLength As Integer = strMaxBoxName.Length - strNewBoxName.Length
                    Dim iNewMax As Integer = iMax + 1
                    Dim strDeviceIDsIn As String = String.Empty
                    Dim iPallettID As Integer = 0, iMovedQty As Integer = dbg.RowCount

                    strNewBoxName &= String.Format("{0}{1}", New String("0", iLength - iNewMax.ToString().Length), iNewMax)

                    With dbg
                        Dim iRet As Integer = Me._objAdmin.InsertNewBox(Me._iOldPallettID, strNewBoxName, .RowCount)

                        If iRet = 0 Then Throw New Exception("An error occurred when attempting to create a new box.  Please contact IT.")

                        iPallettID = Me._objAdmin.GetBoxID(strNewBoxName)

                        If iPallettID <= 0 Then Throw New Exception("An error occurred when attempting to retrieve the pallett ID for the new box.  Please contact IT.")

                        For i = 0 To .RowCount - 1
                            drv = .Item(i)

                            Dim iDeviceID As Integer = drv("device_id")

                            strDeviceIDsIn &= IIf(strDeviceIDsIn.Length > 0, ", ", String.Empty) & iDeviceID.ToString()
                        Next i
                    End With

                    If strDeviceIDsIn.Length > 0 Then
                        Me._objAdmin.UpdateDeviceToNewBox(strDeviceIDsIn, iPallettID)
                        Me._objAdmin.UpdateOldBoxQuantity(Me._iOldPallettID, iMovedQty)
                    End If

                    MessageBox.Show(String.Format("Split complete. {0} device{1} been moved to box {2}.", Me.dbgMovedDevices.RowCount, IIf(Me.dbgMovedDevices.RowCount = 1, " has", "s have"), strNewBoxName), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    'To prevent further attempts to (accidentally) save the already-moved devices to 
                    'another new box:
                    Me.dbgMovedDevices.DataSource = Nothing
                    EnableShowMoveToControls(False)
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Me.Enabled = True
                Me.Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub LoadDevicesInBox(ByVal iPallettID As Integer)
            Dim dt As DataTable = Nothing

            Try
                Me.dbgMovedDevices.DataSource = Nothing
                Me.dbgDevicesInBox.DataSource = Nothing
                dt = Me._objAdmin.GetDevicesInBox(iPallettID)

                If dt.Rows.Count > 0 Then
                    With Me.dbgDevicesInBox
                        .Caption = String.Format("Devices in Box {0}", Me.txtBoxName.Text.Trim)
                    End With

                    ResetGridDataSource(Me.dbgDevicesInBox, dt)

                    Misc.SetGridStyles(Me.dbgDevicesInBox, True)

                    Me.lblDeviceIMEI.Enabled = True
                    Me.txtDeviceIMEI.Enabled = True
                End If
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        Private Sub dbgDevicesInBox_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dbgDevicesInBox.MouseDown
            Try
                If e.Button = MouseButtons.Right Then
                    Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = DirectCast(sender, C1.Win.C1TrueDBGrid.C1TrueDBGrid)

                    If dbg.SelectedRows.Count = 0 Then
                        MessageBox.Show("You must select at least one device (row) to move.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        Dim cMenu As New ContextMenu()
                        Dim objMenuItem As New MenuItem()

                        objMenuItem.Text = "Move selected devices to new box."
                        objMenuItem.Enabled = True

                        RemoveHandler objMenuItem.Click, AddressOf CMenuMoveDevicesToNewBoxClick
                        AddHandler objMenuItem.Click, AddressOf CMenuMoveDevicesToNewBoxClick

                        cMenu.MenuItems.Add(objMenuItem)

                        dbg.ContextMenu = cMenu

                        dbg.ContextMenu.Show(dbg, New Point(e.X, e.Y))
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgDevicesInBox_MouseDown", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub CMenuMoveDevicesToNewBoxClick(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                MoveDevicesTo()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CMenuMoveDevicesToNewBoxClick", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub MoveDeviceToNewBox(ByVal strIMEI As String)
            Try
                If strIMEI.Length = 0 Then
                    MessageBox.Show("IMEI must be a non-empty string.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    Dim dbgOldBox As C1.Win.C1TrueDBGrid.C1TrueDBGrid = Me.dbgDevicesInBox
                    Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = Me.dbgMovedDevices
                    Dim drv As System.Data.DataRowView
                    Dim i As Integer

                    If strIMEI.Length > 0 Then
                        If dbg.RowCount > 0 Then
                            For i = 0 To dbg.RowCount - 1
                                drv = dbg.Item(i)

                                If drv("IMEI").ToString().Equals(strIMEI) Then
                                    MessageBox.Show(String.Format("The device with IMEI '{0}' has already been selected for transfer.", strIMEI), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                    Exit Sub
                                End If
                            Next i
                        End If

                        For i = 0 To dbgOldBox.RowCount - 1
                            drv = dbgOldBox.Item(i)

                            If drv("IMEI").ToString().Equals(strIMEI) Then
                                AddRowToTransfer(drv)

                                Exit Sub
                            End If

                        Next i
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub AddRowToTransfer(ByVal drv As System.Data.DataRowView)
            Dim dt As New DataTable()

            Try
                Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = Me.dbgMovedDevices
                Dim drNew As DataRow
                Dim i As Integer, iDeviceID As Integer = drv("device_id")

                If Not dbg.Visible Then
                    dt.Columns.Add(New DataColumn("device_id", System.Type.GetType("System.Int32")))
                    dt.Columns.Add(New DataColumn("IMEI", System.Type.GetType("System.String")))

                    drNew = dt.NewRow

                    drNew("device_id") = iDeviceID
                    drNew("IMEI") = drv("IMEI")

                    dt.Rows.Add(drNew)

                    With dbg
                        .Caption = "Devices to Transfer to New Box"
                    End With

                    ResetGridDataSource(dbg, dt)

                    Misc.SetGridStyles(Me.dbgMovedDevices, True)
                    EnableShowMoveToControls(True)
                Else
                    With dbg
                        dt = DirectCast(.DataSource(), System.Data.DataView).Table()

                        drNew = dt.NewRow

                        drNew("device_id") = iDeviceID
                        drNew("IMEI") = drv("IMEI")

                        dt.Rows.Add(drNew)
                    End With

                    ResetGridDataSource(dbg, dt)
                End If
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        Private Sub CheckCharAsLetterDigitorControl(ByVal e As System.Windows.Forms.KeyPressEventArgs)
            Try
                If Not (Char.IsLetterOrDigit(e.KeyChar) Or Char.IsControl(e.KeyChar)) Then
                    Beep()

                    e.Handled = True
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub txtDeviceIMEI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDeviceIMEI.KeyPress
            Try
                CheckCharAsLetterDigitorControl(e)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtDeviceIMEI_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub dbgMovedDevices_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dbgMovedDevices.MouseDown
            Try
                If e.Button = MouseButtons.Right Then
                    Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = DirectCast(sender, C1.Win.C1TrueDBGrid.C1TrueDBGrid)

                    If dbg.SelectedRows.Count = 0 Then
                        MessageBox.Show("You must select at least one device (row) to return.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        Dim cMenu As New ContextMenu()
                        Dim objMenuItem As New MenuItem()

                        objMenuItem.Text = "Return selected devices to original box."
                        objMenuItem.Enabled = True

                        RemoveHandler objMenuItem.Click, AddressOf CMenuMoveDevicesToOriginalBoxClick
                        AddHandler objMenuItem.Click, AddressOf CMenuMoveDevicesToOriginalBoxClick

                        cMenu.MenuItems.Add(objMenuItem)

                        dbg.ContextMenu = cMenu

                        dbg.ContextMenu.Show(dbg, New Point(e.X, e.Y))
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgMovedDevices_MouseDown", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub CMenuMoveDevicesToOriginalBoxClick(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                MoveDevicesFrom()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CMenuMoveDevicesToNewBoxClick", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub ReturnDeviceToOriginalBox(ByVal drv As System.Data.DataRowView)
            Dim dt As DataTable

            Try
                Dim dbgOldBox As C1.Win.C1TrueDBGrid.C1TrueDBGrid = Me.dbgDevicesInBox
                Dim drNew As DataRow

                With dbgOldBox
                    dt = DirectCast(.DataSource(), System.Data.DataView).Table()

                    drNew = dt.NewRow

                    drNew("device_id") = drv("device_id")
                    drNew("IMEI") = drv("IMEI")

                    dt.Rows.Add(drNew)
                End With

                ResetGridDataSource(dbgOldBox, dt)
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        Private Sub txtDeviceIMEI_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDeviceIMEI.Enter
            Try
                Dim txt As TextBox = DirectCast(sender, TextBox)

                ConvertEnterExitStyle(txt, True)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtDeviceIMEI_Enter", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub txtDeviceIMEI_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDeviceIMEI.Leave
            Try
                Dim txt As TextBox = DirectCast(sender, TextBox)

                ConvertEnterExitStyle(txt, False)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtDeviceIMEI_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub ConvertEnterExitStyle(ByVal txt As TextBox, ByVal bIsEntering As Boolean)
            Try
                If bIsEntering Then
                    txt.BackColor = Color.Yellow
                    txt.ForeColor = Color.Indigo
                Else
                    txt.BackColor = Color.FloralWhite
                    txt.ForeColor = Color.Blue
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub txtDeviceIMEI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDeviceIMEI.KeyDown
            Try
                If e.KeyCode = Keys.Enter Then
                    Dim txt As TextBox = DirectCast(sender, TextBox)
                    Dim strIMEI As String = txt.Text.Trim

                    MoveDevicesTo(strIMEI)

                    txt.Text = String.Empty
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtDeviceIMEI_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub dbgDevicesInBox_AfterFilter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles dbgDevicesInBox.AfterFilter
            Try
                GridAfterFilter(DirectCast(sender, C1.Win.C1TrueDBGrid.C1TrueDBGrid))
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgDevicesInBox_AfterFilter", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub GridAfterFilter(ByVal dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
            Try
                With dbg
                    .Columns("IMEI").FooterText = String.Format("Total Devices: {0:#,##0}", .RowCount)
                End With
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub dbgMovedDevices_AfterFilter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles dbgMovedDevices.AfterFilter
            Try
                GridAfterFilter(DirectCast(sender, C1.Win.C1TrueDBGrid.C1TrueDBGrid))
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgMovedDevices_AfterFilter", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub ResetGridDataSource(ByVal dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal dt As DataTable)
            Try
                With dbg
                    Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
                    Dim dv As DataView = dt.DefaultView

                    dv.Sort = "IMEI ASC"

                    .DataSource = dv

                    .Splits(0).DisplayColumns("device_id").Visible = False

                    .Splits(0).DisplayColumns("IMEI").Width = 120

                    .Splits(0).DisplayColumns("IMEI").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                    .MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Extended

                    .Columns("IMEI").FooterText = String.Format("Total Devices: {0:#,##0}", .RowCount)

                    .Splits(0).DisplayColumns("IMEI").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near

                    For Each dbgc In .Splits(0).DisplayColumns : dbgc.Locked = True : Next dbgc
                End With
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub MoveDevicesTo(Optional ByVal strIMEI As String = "")
            Dim dt As DataTable = Nothing

            Try
                Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = Me.dbgDevicesInBox
                Dim drv As System.Data.DataRowView
                Dim i As Integer

                With dbg
                    dt = DirectCast(.DataSource, System.Data.DataView).Table()

                    Dim iDevicesRemaining As Integer = dt.Rows.Count

                    If iDevicesRemaining = 1 And .SelectedRows.Count = 1 Then
                        MessageBox.Show("You must leave at least one device in the original box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        Exit Sub
                    End If

                    If strIMEI.Length = 0 Then
                        Dim iSelectedRows(.SelectedRows.Count - 1) As Integer
                        Dim iRow As Integer = -1

                        For i = .SelectedRows.Count - 1 To 0 Step -1
                            iRow += 1
                            iSelectedRows(iRow) = dbg.SelectedRows(i)
                            drv = .Item(dbg.SelectedRows(i))
                            MoveDeviceToNewBox(drv("IMEI"))
                        Next i

                        For i = 0 To iSelectedRows.GetUpperBound(0) : dt.Rows.RemoveAt(iSelectedRows(i)) : Next i
                    Else
                        If IMEIInGrid(strIMEI, dbg) Then
                            MoveDeviceToNewBox(strIMEI)

                            Dim dr As DataRow

                            For Each dr In dt.Rows
                                If dr("IMEI").ToString().Equals(strIMEI) Then
                                    dt.Rows.Remove(dr)

                                    Exit For
                                End If
                            Next dr
                        End If
                    End If
                End With

                ResetGridDataSource(dbg, dt)
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        Private Sub MoveDevicesFrom(Optional ByVal strIMEI As String = "")
            Dim dt As DataTable = Nothing

            Try
                Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = Me.dbgMovedDevices
                Dim drv As System.Data.DataRowView = Nothing
                Dim i As Integer

                With dbg
                    dt = DirectCast(.DataSource(), System.Data.DataView).Table()

                    If strIMEI.Length = 0 Then
                        Dim iSelectedRows(.SelectedRows.Count - 1) As Integer
                        Dim iRow As Integer = -1

                        For i = .SelectedRows.Count - 1 To 0 Step -1
                            iRow += 1
                            iSelectedRows(iRow) = .SelectedRows(i)
                            drv = .Item(.SelectedRows(i))
                            ReturnDeviceToOriginalBox(drv)
                        Next i

                        For i = 0 To iSelectedRows.GetUpperBound(0) : dt.Rows.RemoveAt(iSelectedRows(i)) : Next i
                    Else
                        If IMEIInGrid(strIMEI, dbg) Then
                            For i = 0 To .RowCount - 1
                                drv = .Item(i)

                                If drv("IMEI").ToString().Equals(strIMEI) Then
                                    ReturnDeviceToOriginalBox(drv)
                                    dt.Rows.RemoveAt(i)

                                    Exit For
                                End If
                            Next i
                        End If
                    End If
                End With

                If dt.Rows.Count > 0 Then
                    ResetGridDataSource(dbg, dt)
                Else
                    dbg.DataSource = Nothing
                    EnableShowMoveToControls(False)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CMenuMoveDevicesToNewBoxClick", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        Private Sub txtDeviceIMEIReturn_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDeviceIMEIReturn.KeyDown
            Try
                If e.KeyCode = Keys.Enter Then
                    Dim txt As TextBox = DirectCast(sender, TextBox)
                    Dim strIMEI As String = txt.Text.Trim

                    MoveDevicesFrom(strIMEI)

                    txt.Text = String.Empty
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtDeviceIMEIReturn_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub txtDeviceIMEIReturn_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDeviceIMEIReturn.KeyPress
            Try
                CheckCharAsLetterDigitorControl(e)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtDeviceIMEIReturn_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub txtDeviceIMEIReturn_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDeviceIMEIReturn.Leave
            Try
                Dim txt As TextBox = DirectCast(sender, TextBox)

                ConvertEnterExitStyle(txt, False)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtDeviceIMEIReturn_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub EnableShowMoveToControls(ByVal bEnableShow As Boolean)
            Try
                Me.dbgMovedDevices.Visible = bEnableShow
                Me.lblDeviceIMEIReturn.Enabled = bEnableShow
                Me.txtDeviceIMEIReturn.Enabled = bEnableShow
                Me.txtDeviceIMEIReturn.Text = String.Empty
                Me.pbxLeftArrow.Enabled = bEnableShow
                Me.lblDeviceIMEIReturn.Visible = bEnableShow
                Me.txtDeviceIMEIReturn.Visible = bEnableShow
                Me.pbxLeftArrow.Visible = bEnableShow
                Me.btnSplitBox.Enabled = bEnableShow
                Me.btnSplitBox.Visible = bEnableShow
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub btnClearAllData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearAllData.Click
            Try
                Me.Cursor = Cursors.WaitCursor
                Me.Enabled = False

                ClearAllData()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnClearAllData_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True
                Me.Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub ClearAllData()
            Try
                Me.txtBoxName.Text = String.Empty
                Me.dbgDevicesInBox.DataSource = Nothing
                Me.dbgMovedDevices.DataSource = Nothing
                Me.dbgDevicesInBox.Caption = String.Empty
                Me.lblDeviceIMEI.Enabled = False
                Me.txtDeviceIMEI.Enabled = False
                Me.pbxRightArrow.Enabled = False
                Me.txtDeviceIMEI.Text = String.Empty
                EnableShowMoveToControls(False)
                Me._iOldPallettID = 0

                Me.txtBoxName.Focus()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Function IMEIInGrid(ByVal strIMEI As String, ByVal dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid) As Boolean
            Try
                Dim i As Integer
                Dim bFound As Boolean = False

                For i = 0 To dbg.RowCount - 1
                    Dim drv As System.Data.DataRowView = dbg.Item(i)

                    If drv("IMEI").ToString.Equals(strIMEI) Then
                        bFound = True

                        Exit For
                    End If
                Next i

                If Not bFound Then MessageBox.Show(String.Format("IMEI {0} is not in the data.", strIMEI), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Return bFound
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class
End Namespace